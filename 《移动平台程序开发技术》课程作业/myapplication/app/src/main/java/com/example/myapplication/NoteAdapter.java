package com.example.myapplication;
import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;
import java.util.List;
public class NoteAdapter extends BaseAdapter {
    private List<Note> list;
    private Context context;
    public NoteAdapter(List<Note> list, Context context) {
        this.list = list;
        this.context = context;
    }
    @Override
    public int getCount() {
        return list.size();
    }
    @Override
    public Object getItem(int i) {
        return list.get(i);
    }
    @Override
    public long getItemId(int i) {
        return i;
    }
    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        if(view==null){
            view=View.inflate(context, R.layout.listview,null);
        }
        TextView topic=view.findViewById(R.id.textView5);
        TextView time=view.findViewById(R.id.textView6);
        TextView content=view.findViewById(R.id.textView7);
        Note iNote=list.get(i);
        topic.setText(iNote.getTopic());
        time.setText(iNote.getTime());
        content.setText(iNote.getContent());
        return view;
    }
}
