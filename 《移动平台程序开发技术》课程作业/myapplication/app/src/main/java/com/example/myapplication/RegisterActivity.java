package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
public class RegisterActivity extends AppCompatActivity {
    private EditText etUsername,etUserId,etPasswd;
    private Button btnRegister;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
        etUsername=findViewById(R.id.reg_username);
        etUserId=findViewById(R.id.reg_userid);
        btnRegister=findViewById(R.id.btn_register);
        btnRegister.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent=new Intent();
                intent.putExtra("userId",etUserId.getText().toString());
                intent.putExtra("userName",etUsername.getText().toString());
                setResult(11,intent);
                finish();
            }
        });
    }
}
