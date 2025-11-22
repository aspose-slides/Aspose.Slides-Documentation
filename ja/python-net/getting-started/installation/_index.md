---
title: インストール
type: docs
weight: 70
url: /ja/python-net/installation/
keywords:
- Aspose.Slides のダウンロード
- Aspose.Slides のインストール
- Aspose.Slides の使用
- Aspose.Slides インストール
- Windows
- macOS
- Python
description: "Aspose.Slides for Python via .NET のインストール方法をすばやく学びましょう。ステップバイステップのガイド、システム要件、コードサンプルをご紹介し、すぐに PowerPoint プレゼンテーションの操作を開始できます！"
---

## **概要**

Aspose.Slides for Python via .NET パッケージには必須の .NET ライブラリがすべて同梱されているため、.NET を別途インストールする必要はありません。これによりセットアップが簡素化され、開発者はすぐにプレゼンテーションの操作を開始できます。ただし、使用しているオペレーティングシステムや環境によっては、.NET が必要とするプラットフォーム固有の依存関係を別途インストールする必要がある場合があります。また、パッケージの完全な互換性と正常な動作を保証するために、特定のシステム要件を満たす必要があります。

## **Windows**

**システム要件**

お使いのマシンの仕様が [システム要件](/slides/ja/python-net/system-requirements/) を満たしているか、またはそれ以上であることを確認してください。

### **Aspose.Slides のインストール**

`pip` は Windows 上で [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) をダウンロードしてインストールする最も簡単な方法です。

Aspose.Slides をインストールするには、次のコマンドを実行してください:
```sh
pip install aspose-slides
```


**Aspose.Slides の使用**

以下のコードを実行して PowerPoint プレゼンテーションを作成し、Aspose.Slides のインストールが正しく行われたことをテストしてください:
```python
# Aspose.Slides for Python via .NET モジュールをインポートします。
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **macOS**

**システム要件**

お使いのマシンの仕様が [システム要件](/slides/ja/python-net/system-requirements/) を満たしているか、またはそれ以上であることを確認してください。

### **前提条件**

**Shared Libraries を持つ Python**

macOS に Python をインストールする方法はいくつかありますが、[pyenv ツール](https://github.com/pyenv/pyenv#homebrew-in-macos) の使用を強く推奨します。

**pyenv** をインストールして設定した後、ターミナルアプリで次のコマンドを実行して Shared Libraries を持つ Python をインストールします:

1. Python をインストール:
```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```


2. グローバルな Python バージョンとして設定:
```sh
pyenv global 3.9.13
```


3. シェル固有の Python バージョンとして設定:
```sh
pyenv shell 3.9.13
```


4. システムライブラリディレクトリに libpython ライブラリへのシンボリックリンクを作成:
```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```


注意: Python 3.5 以上が必要です。ここでは例として 3.9.13 を使用しています。

**libgdiplus ライブラリのインストール**

**libgdiplus** ライブラリは macOS と Linux 用の Windows GDI+ 実装で、.NET がこれらのプラットフォームでグラフィック機能を利用する際に必要です。macOS にこのライブラリをインストールするには、次のコマンドを実行してください:
```sh
brew install mono-libgdiplus
```


### **Aspose.Slides のインストール**

`pip` は macOS 上で [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) をダウンロードしてインストールする最も簡単な方法です。

Aspose.Slides をインストールするには、次のコマンドを実行してください:
```sh
pip install aspose-slides
```


**Aspose.Slides の使用**

以下のコードを実行して PowerPoint プレゼンテーションを作成し、Aspose.Slides のインストールが正しく行われたことをテストしてください:
```python
# Aspose.Slides for Python via .NET モジュールをインポートします。
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**仮想環境に Aspose.Slides をインストールできますか？**

はい、`pip` を使用して任意の Python 仮想環境にインストールできます。OS に応じて必要なネイティブ依存関係にアクセスできることを確認してください。

**Docker コンテナで Aspose.Slides を使用できますか？**

はい、ただし Docker イメージに必須のネイティブライブラリ（**libgdiplus**、フォントパッケージなど）と適切なバージョンの Python を含める必要があります。

**無料版やトライアルの制限はありますか？**

はい、デフォルトでは Aspose.Slides は評価モードで動作し、透かしが付加されたりその他の制限があります。制限を解除するには、有効な [ライセンス](/slides/ja/python-net/licensing/) を適用してください。