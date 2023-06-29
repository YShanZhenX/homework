package com.example.myapplication;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.room.Room;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ImageButton;
import android.widget.ListView;
import java.util.List;
public class Main1Activity extends AppCompatActivity {
    private ListView listView;
    private NoteDatabase noteDatabase;
    private ImageButton button;
    private NoteDao noteDao;
    private List<Note> list;
    private NoteAdapter noteAdapter;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main1);
        noteDatabase= Room.databaseBuilder(this,NoteDatabase.class,"Note").allowMainThreadQueries().build();
        noteDao=noteDatabase.getNoteDao();
        listView=findViewById(R.id.listview);
        updateView();
        button=findViewById(R.id.imageButton);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent=new Intent(Main1Activity.this,Main2Activity.class);
                startActivity(intent);
            }
        });
        listView.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> adapterView, View view, int position, long l) {
                AlertDialog.Builder alert=new AlertDialog.Builder(Main1Activity.this);
                alert.setMessage("您确定要删除这条记录吗？");
                alert.setNegativeButton("取消",null);
                alert.setPositiveButton("确定", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        List<Note>list1=noteDao.getAllNotes();
                        int j=list1.get(position).getId();
                        Note note= new Note("","","");
                        note.setId(j);
                        noteDao.deleteNotes(note);
                        updateView();
                    }
                });
                alert.show();
                return true;
            }
        });
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                Intent intent = new Intent(Main1Activity.this,Main3Activity.class);
                List<Note>list2=noteDao.getAllNotes();
                int k=list2.get(i).getId();
                intent.putExtra("id",k);
                startActivity(intent);
            }
        });
    }
    @Override
    protected void onResume() {
        super.onResume();
        updateView();
    }
    private void updateView() {
        list= noteDao.getAllNotes();
        noteAdapter=new NoteAdapter(list, Main1Activity.this);
        listView.setAdapter(noteAdapter);
    }

}
