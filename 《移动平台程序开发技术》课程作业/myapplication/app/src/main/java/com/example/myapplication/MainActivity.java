package com.example.myapplication;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;
import java.util.Map;
public class MainActivity extends AppCompatActivity {
    private Button btnLogin, btnRegister;
    private ImageView ivLogin;
    private TextView tvUsername, tvUserId;
    private static final int REQUEST_REGISTER_CODE = 1;
    private static final int REQUEST_LOGIN_CODE = 2;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        tvUserId = findViewById(R.id.tv_main_userid);
        tvUsername = findViewById(R.id.tv_main_username);
        btnLogin = findViewById(R.id.btn_main_login);
        btnRegister = findViewById(R.id.btn_main_register);
        btnLogin.setOnClickListener(new onClick());
        btnRegister.setOnClickListener(new onClick());
    }
    private class onClick implements View.OnClickListener {
        @Override
        public void onClick(View view) {
            Intent intent = new Intent();
            switch (view.getId()) {
                case R.id.btn_main_login:
                    intent.setClass(MainActivity.this, LoginActivity.class);
                    startActivityForResult(intent, REQUEST_LOGIN_CODE);
                    break;
                case R.id.btn_main_register:
                    intent.setClass(MainActivity.this, RegisterActivity.class);
                    startActivityForResult(intent, REQUEST_REGISTER_CODE);
                    break;
            }
        }
    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent intent) {
        super.onActivityResult(requestCode, resultCode, intent);
        if (intent == null) {
            return;
        }
        switch (requestCode) {
            case REQUEST_REGISTER_CODE:
                if (resultCode == 11) {
                    tvUserId.setText(intent.getStringExtra("userId"));
                    tvUsername.setText(intent.getStringExtra("userName"));
                    Toast.makeText(this, "注册成功！", Toast.LENGTH_LONG).show();
                }else {
                    Toast.makeText(this, "注册失败！", Toast.LENGTH_LONG).show();
                }
                break;
            case REQUEST_LOGIN_CODE:
                if (resultCode == 21) {
                    tvUserId.setText(intent.getStringExtra("userId"));
                    tvUsername.setText(intent.getStringExtra("userName"));
                }else{
                    Toast.makeText(this, "登陆失败！", Toast.LENGTH_LONG).show();
                }
                break;
            default:
                Toast.makeText(this, "操作失败！", Toast.LENGTH_LONG).show();
                break;
        }
    }
}
