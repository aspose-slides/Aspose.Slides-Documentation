---
title: PyInstaller および cx_Freeze との互換性
linktitle: PyInstaller との互換性
type: docs
weight: 122
url: /ja/python-net/compatibility-with-pyinstaller/
keywords:
- compatibility
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を PyInstaller でパッケージ化します。このガイドに従って、アプリを単一の実行可能ファイルにバンドル、設定、トラブルシューティングできます。"
---

## **PyInstaller および cx_Freeze との互換性**

Aspose.Slides for Python via .NET 拡張は標準の Python C 拡張であるため、PyInstaller や cx_Freeze（その他類似ツール）などを使用してプログラムの依存関係として「フリーズ」できます。これにより、Python スクリプトから実行可能ファイルを作成できます。このようなツールは「フリーザ」と呼ばれ、コードとその依存関係を単一の配布可能ファイルにまとめ、別のマシン上で Python のインストールや追加ライブラリなしで実行できるようにします。このアプローチは Python アプリケーションの配布を簡素化します。

Aspose.Slides for Python via .NET 拡張を依存関係としてフリーズする例を、Aspose.Slides を使用したシンプルなプログラムで示します。

### **PyInstaller**

通常、Aspose.Slides for Python via .NET 拡張に依存するプログラムをパッケージ化する際に特別な作業は不要です。プログラムが PyInstaller に認識できる形で拡張をインポートすれば、拡張はプログラムにバンドルされます。Aspose.Slides for Python via .NET には PyInstaller フックが含まれているため、依存関係は自動的に検出され、バンドルにコピーされます。

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

しかし、PyInstaller は時折、隠しインポート（コードが動的または間接的にインポートするモジュール）を検出し漏らすことがあります。隠しインポートを含めるには、PyInstaller のオプションを使用します。拡張の依存関係は Aspose.Slides for Python via .NET に同梱されている PyInstaller フックで指定されています。

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

cx_Freeze でプログラムをフリーズするには、使用している Aspose.Slides for Python via .NET 拡張のルートパッケージを含めるよう設定します。これにより、拡張とすべての依存モジュールがビルド時にアプリケーションと共にコピーされます。

#### **cxfreeze スクリプトの使用**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **setup スクリプトの使用**

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

**ユーザーのマシンに Microsoft PowerPoint または .NET がインストールされている必要がありますか？**

いいえ、PowerPoint は不要です。Aspose.Slides は単体で動作するエンジンで、Python パッケージは CPython 用の拡張として必要なものをすべて含んでいます。ユーザーが別途 .NET をインストールする必要はありません。

**フリーズしたアプリケーションにライセンスを正しく添付するにはどうすればよいですか？**

ライセンス XML を実行ファイルと同じフォルダーに配置するか、リソースとして埋め込み、最初の API 呼び出しの前にアクセス可能なパスからロードしてください。重要: XML の内容（改行さえも）を変更しないでください。

**ビルド後にフォントの表示が開発時と異なる場合、どう対処すればよいですか？**

対象環境に使用しているフォントが（バンドルされているかシステムにインストールされているか）確実に存在し、実行時にパスが正しく解決されるようにしてください。フォントの動作は特に Linux で敏感です。