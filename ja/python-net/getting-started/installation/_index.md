---
title: インストール
type: docs
weight: 70
url: /ja/python-net/installation/
keywords: "Aspose.Slidesをダウンロード, Aspose.Slidesをインストール, Aspose.Slidesのインストール, Windows, macOS, Python"
description: "WindowsまたはmacOSで.NET経由でPython用のAspose.Slidesをインストール"
---

Aspose.Slides for Python via .NETパッケージには必要な.NETライブラリが含まれているため、別途.NETのインストールは必要ありません。ただし、プラットフォームによっては、特定の依存関係をインストールし、特定の要件を満たす必要がある場合があります。

## **Windows**

**システム要件**

お使いのマシンの仕様が[システム要件](/slides/ja/python-net/system-requirements/)を満たしているかどうか確認してください。

### **Aspose.Slidesをインストールする**

`pip`はWindowsデバイスに[ASP.NET用のAspose.Slides for Python](https://pypi.org/project/aspose.slides/)をダウンロードしてインストールする最も簡単な方法です。

Aspose.Slidesをインストールするには、次のコマンドを実行します:  `pip install aspose.slides`

**Aspose.Slidesを使用する**

このコードを実行してPowerPointプレゼンテーションを作成することで、Aspose.Slidesのインストールをテストします:

```python
# .NET経由でPython用のAspose.Slidesモジュールをインポート
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**システム要件**

お使いのマシンの仕様が[システム要件](/slides/ja/python-net/system-requirements/)を満たしているかどうか確認してください。

### **前提条件**

**共有ライブラリを持つPython**

macOSにPythonをインストールする方法はいくつかありますが、[pyenvツール](https://github.com/pyenv/pyenv#homebrew-in-macos)の使用を強くお勧めします。

pyenvをインストールして設定したら、Terminalアプリで次のコマンドを実行して共有ライブラリ付きのPythonをインストールします:

1. Pythonをインストール: `env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13`
2. グローバルPythonインストールとして設定: `pyenv global 3.9.13`
3. シェルPythonインストールとして設定: `pyenv shell 3.9.13`
4. システムライブラリディレクトリにlibpythonライブラリのシンボリックリンクを作成: `ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib` 

注: Python 3.5以上が必要です。Pythonバージョン3.9.13は単に例として使用されています。

**libgdiplusライブラリをインストールする**

libgdiplusライブラリは、Windows GDI+のmacOSおよびLinux用の実装であり、.NETがそれらのプラットフォームで使用します。このライブラリをインストールするには、次のコマンドを実行します: `brew install mono-libgdiplus` 

### **Aspose.Slidesをインストールする**

`pip`はmacOSデバイスに[ASP.NET用のAspose.Slides for Python](https://pypi.org/project/aspose.slides/)をダウンロードしてインストールする最も簡単な方法です。Aspose.Slidesをインストールするには、次のコマンドを実行します: `pip install aspose.slides`

**Aspose.Slidesを使用する**

このコードを実行してPowerPointプレゼンテーションを作成することで、Aspose.Slidesのインストールをテストします:

```python
# .NET経由でPython用のAspose.Slidesモジュールをインポート
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```