---
title: PyInstaller および cx_Freeze との互換性
linktitle: PyInstaller との互換性
type: docs
weight: 122
url: /ja/python-net/developer-guide/technical-articles/compatibility-with-pyinstaller/
keywords:
- compatibility
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "PyInstaller を使用して .NET 経由の Python 用 Aspose.Slides をパッケージ化します。このガイドに従って、アプリケーションを単体実行ファイルにバンドル、構成、トラブルシューティングしてください。"
---

## **PyInstaller および cx_Freeze との互換性**

Aspose.Slides for Python via .NET の拡張機能は標準的な Python C 拡張であるため、PyInstaller や cx_Freeze（その他類似ツール）といったフリーザーでプログラムの依存関係として凍結できます。これにより、Python スクリプトから実行可能ファイルを作成できます。フリーザーとは、コードとその依存関係を単一の配布可能ファイルにまとめ、他のマシンでも Python のインストールや追加ライブラリなしで実行できるようにするツールのことです。この手法は Python アプリケーションの配布を簡素化します。

Aspose.Slides for Python via .NET の拡張機能を依存関係として凍結する例を、Aspose.Slides を使用したシンプルなプログラムで示します。

### **PyInstaller**

基本的に、Aspose.Slides for Python via .NET の拡張機能に依存するプログラムをパッケージ化する際に特別な作業は不要です。拡張機能が PyInstaller に認識できる形でインポートされていれば、プログラムに自動的にバンドルされます。Aspose.Slides for Python via .NET には PyInstaller 用のフックが同梱されているため、依存関係は自動的に検出され、バンドルにコピーされます。

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

ただし、PyInstaller が隠しインポート（コードから動的または間接的にインポートされるモジュール）を見逃すことがあります。隠しインポートを含めるには、PyInstaller のオプションを使用します。拡張機能の依存関係は、Aspose.Slides for Python via .NET に同梱されている PyInstaller フックで指定されています。

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

cx_Freeze でプログラムを凍結するには、使用している Aspose.Slides for Python via .NET 拡張機能のルートパッケージを含めるよう設定します。これにより、拡張機能とすべての依存モジュールがビルドにコピーされ、アプリケーションと共に配置されます。

#### **cxfreeze スクリプトを使用する場合**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **Setup スクリプトを使用する場合**

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

いいえ、PowerPoint は不要です。Aspose.Slides は自己完結型エンジンであり、Python パッケージは CPython 用の拡張として必要なすべてを同梱しています。ユーザーが別途 .NET をインストールする必要はありません。

**凍結したアプリケーションにライセンスを正しく組み込む方法は？**

ライセンス XML を実行ファイルの隣に配置するか、リソースとして埋め込み、最初の API 呼び出しの前にアクセス可能なパスからロードしてください。重要なのは XML コンテンツ（改行さえも）を変更しないことです。

**ビルド後にフォントの表示が開発時と異なる場合はどうすべきですか？**

ターゲット環境に使用しているフォントがバンドルされているか、システムにインストールされているかを確認し、実行時に正しいパスが解決されるようにしてください。フォントの挙動は特に Linux 環境で敏感です。