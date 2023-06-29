package com.example.myapplication;
import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;
import java.util.List;
@Dao
public interface NoteDao {
    @Insert
    void insertNotes(Note...notes);
    @Update
    void updateNotes(Note...notes);
    @Delete
    void deleteNotes(Note...notes);
    @Query("SELECT * FROM NOTE WHERE id=:id")
    Note getiNote(int id);
    @Query("SELECT * FROM NOTE ORDER BY id DESC")
    List<Note> getAllNotes();
}
