# MarkDownNote
WPF project Read&amp;Write MarkDown

![스크린샷(227)](https://github.com/keesung98/MarkDownNote/assets/70887592/7bafd0ef-7b77-4313-9e4a-e96791a65932)

README를 편리하게 작성하기 위한 프로그램입니다.
MarkDown 문법들을 알려주고 있으며 README 파일을 작성할 수 있습니다.

---

## Save File

```cs
private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "README";
            saveFileDialog.Filter = "MarkDown file (*.md)|*.md";
            if (saveFileDialog.ShowDialog() == true)
            {
                using(StreamWriter sw=new StreamWriter(saveFileDialog.FileName)) 
                {
                    TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                    sw.WriteLine(textRange.Text);
                }
                MessageBox.Show("파일이 저장되었습니다.");
            }
        }
```

README 파일들을 읽어올 수 있게 만들었습니다.
읽어온 파일들을 richTextBox에 쓰는 방식으로 구현하였습니다.

---

## Open File

```cs
private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter= "MarkDown file (*.md)|*.md";
            if(openFileDialog.ShowDialog() == true)
            {
                richTextBox.SelectAll();
                richTextBox.Selection.Text = "";

                using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                {
                    richTextBox.AppendText(streamReader.ReadToEnd());
                }
            }
        }
```

save와 마찬가지로 동작하며 읽어온 파일을 AppendText를 통해 richTextBox에 접근합니다.

---

## Clear File

```cs
private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgResult = MessageBox.Show("내용을 지우시겠습니까?", "경고", MessageBoxButton.YesNo);
            if (msgResult == MessageBoxResult.Yes)
            {
                richTextBox.SelectAll();
                richTextBox.Selection.Text = "";
            }
        }
```

