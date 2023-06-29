package com.example.myapplication;
import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;
@Entity
public class Note {
    @PrimaryKey(autoGenerate = true)
    private int id;
    @ColumnInfo(name="topic")
    private String topic;
    @ColumnInfo(name="content")
    private String content;
    @ColumnInfo(name="time")
    private String time;
    public Note(String topic, String content, String time) {
        this.topic = topic;
        this.content = content;
        this.time = time;
    }
    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
    }
    public String getTopic() {
        return topic;
    }
    public void setTopic(String topic) {
        this.topic = topic;
    }
    public String getContent() {
        return content;
    }
    public void setContent(String content) {
        this.content = content;
    }
    public String getTime() {
        return time;
    }
    public void setTime(String time) {
        this.time = time;
    }
}
