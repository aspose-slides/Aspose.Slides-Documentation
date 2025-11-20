---
title: PyInstaller と cx_Freeze との互換性
linktitle: PyInstaller との互換性
type: docs
weight: 122
url: /ja/python-net/compatibility-with-pyinstaller/
keywords:
- 互換性
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を PyInstaller でパッケージ化します。このガイドに従って、アプリをスタンドアロン実行ファイルにバンドル、構成、トラブルシューティングしてください。"
---

## **PyInstaller と cx_Freeze との互換性**

Aspose.Slides for Python via .NET 拡張機能は標準的な Python C 拡張であるため、PyInstaller や cx_Freeze（その他類似ツール）などでプログラムの依存関係として凍結（freeze）できます。これにより、Python スクリプトから実行可能ファイルを作成できます。このようなツールは「フリーザー」と呼ばれ、コードとその依存関係を単一の配布可能ファイルにまとめ、他のマシンで Python のインストールや追加ライブラリなしで実行できるようにします。このアプローチは、Python アプリケーションの配布を簡素化します。

Aspose.Slides for Python via .NET 拡張機能を依存関係として凍結する例を、Aspose.Slides を使用したシンプルなプログラムで示します。

### **PyInstaller**

基本的に、Aspose.Slides for Python via .NET 拡張機能に依存するプログラムをパッケージ化する際に特別な作業は不要です。プログラムが PyInstaller に認識できる形で拡張機能をインポートすると、拡張機能はプログラムに同梱されます。Aspose.Slides for Python via .NET には PyInstaller フックが含まれているため、依存関係は自動的に検出され、バンドルにコピーされます。

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```


ただし、PyInstaller は動的にまたは間接的にインポートされるモジュール（隠しインポート）を見逃すことがあります。隠しインポートを含めるには、PyInstaller のオプションを使用します。拡張機能の依存関係は、Aspose.Slides for Python via .NET に同梱されている PyInstaller フックで指定されています。

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```


### **cx_Freeze**

cx_Freeze でプログラムを凍結するには、使用している Aspose.Slides for Python via .NET 拡張機能のルートパッケージを含めるように設定します。これにより、拡張機能とすべての依存モジュールがビルドにコピーされ、アプリケーションと共に配置されます。

#### **Using the cxfreeze Script**
```bash
$ cxfreeze slide_app.py --packages=aspose
```


#### **Using the Setup Script**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```


## **FAQ**

**ユーザーのマシンに Microsoft PowerPoint または .NET をインストールする必要がありますか？**

いいえ、PowerPoint は必要ありません。Aspose.Slides は自己完結型エンジンであり、Python パッケージは CPython 用の拡張として必要なものすべてを同梱しています。ユーザーが .NET を別途インストールする必要はありません。

**凍結したアプリケーションにライセンスを正しく添付するにはどうすればよいですか？**

ライセンス XML を実行ファイルの横に配置するか、リソースとして埋め込み、最初の API 呼び出しの前にアクセス可能なパスからロードできます。重要: XML の内容（改行さえも）を変更しないでください。

**ビルド後にフォントの表示が開発時と異なる場合はどうすべきですか？**

使用しているフォントがターゲット環境（バンドルされたものまたはシステムにインストールされたもの）に存在し、実行時にパスが正しく解決されていることを確認してください。フォントの挙動は特に Linux で敏感です。