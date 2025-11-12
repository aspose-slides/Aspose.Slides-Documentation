---
title: PyInstaller および cx_Freeze との互換性
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
description: "PyInstaller を使用して Aspose.Slides for Python via .NET をパッケージ化します。このガイドに従って、アプリをバンドル、構成、トラブルシューティングし、スタンドアロン実行ファイルにします。"
---

## **PyInstaller および cx_Freeze との互換性**

Aspose.Slides for Python via .NET 拡張機能は標準的な Python C 拡張であるため、PyInstaller や cx_Freeze（その他類似ツール）といったフリーザーツールでプログラム依存関係として凍結できます。これにより、Python スクリプトから実行可能ファイルを作成できます。フリーザーと呼ばれるこれらのツールは、コードとその依存関係を 1 つの配布可能ファイルにまとめ、Python のインストールや追加ライブラリが不要な他のマシンでも実行できるようにします。この手法は Python アプリケーションの配布を簡素化します。

Aspose.Slides for Python via .NET 拡張機能を依存関係として凍結する例を、Aspose.Slides を使用したシンプルなプログラムで示します。

### **PyInstaller**

通常、Aspose.Slides for Python via .NET 拡張機能に依存するプログラムをパッケージ化するときに特別な作業は不要です。プログラムが PyInstaller に検出可能な形で拡張機能をインポートすると、拡張機能はプログラムにバンドルされます。Aspose.Slides for Python via .NET には PyInstaller フックが同梱されているため、依存関係は自動的に検出され、バンドルにコピーされます。

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

ただし、PyInstaller は時々隠しインポート（動的または間接的にインポートされるモジュール）を見逃すことがあります。隠しインポートを含めるには、PyInstaller のオプションを使用します。拡張機能の依存関係は、Aspose.Slides for Python via .NET に同梱されている PyInstaller フックで指定されています。

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

cx_Freeze でプログラムを凍結するには、使用している Aspose.Slides for Python via .NET 拡張機能のルートパッケージを含めるように設定します。これにより、拡張機能とすべての依存モジュールがアプリケーションと共にビルドにコピーされます。

#### **cxfreeze スクリプトの使用**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **Setup スクリプトの使用**

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

いいえ、PowerPoint は不要です。Aspose.Slides は自己完結型エンジンであり、Python パッケージは CPython 用の拡張機能として必要なすべてを同梱しています。ユーザーが .NET を別途インストールする必要はありません。

**凍結されたアプリケーションにライセンスを正しく添付するにはどうすればよいですか？**

ライセンス XML を実行ファイルの隣に保存するか、リソースとして埋め込み、最初の API 呼び出しの前にアクセス可能なパスからロードします。重要: XML の内容（改行さえも）を変更しないでください。

**ビルド後にフォントの表示が開発時と異なる場合、どうすればよいですか？**

対象環境に使用しているフォントがバンドルされているかシステムにインストールされていることを確認し、実行時にパスが正しく解決されるようにしてください。フォントの挙動は特に Linux 環境で敏感です。