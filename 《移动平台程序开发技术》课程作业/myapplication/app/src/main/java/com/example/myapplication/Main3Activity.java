package com.example.myapplication;
import androidx.appcompat.app.AppCompatActivity;
import androidx.room.Room;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import java.util.Calendar;
import java.util.List;
public class Main3Activity extends AppCompatActivity {
    private EditText editText,editText2;
    private Button button;
    private NoteDao noteDao;
    private NoteDatabase noteDatabase;
    private int k;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main3);
        editText=findViewById(R.id.editText);
        editText2=findViewById(R.id.editText2);
        button=findViewById(R.id.button);
        noteDatabase= Room.databaseBuilder(this,NoteDatabase.class,"Note").allowMainThreadQueries().build();
        noteDao=noteDatabase.getNoteDao();
        Intent intent=getIntent();
        k=intent.getIntExtra("id",0);
        editText.setText(noteDao.getiNote(k).getTopic());
        editText2.setText(noteDao.getiNote(k).getTopic());
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String topic=editText.getText().toString();
                String content=editText2.getText().toString();
                Calendar calendar = Calendar.getInstance();
                String year = String.valueOf(calendar.get(Calendar.YEAR));
                String month = String.valueOf(calendar.get(Calendar.MONTH)+1);
                String day = String.valueOf(calendar.get(Calendar.DAY_OF_MONTH));
                String hour = String.valueOf(calendar.get(Calendar.HOUR_OF_DAY));
                String minute = String.valueOf(calendar.get(Calendar.MINUTE));
                String time=year+'.'+month+'.'+day+"\t\t "+hour+':'+minute;
                Note note= new Note(topic,content,time);
                note.setId(k);
                noteDao.updateNotes(note);
                finish();
            }
        });
    }
}
