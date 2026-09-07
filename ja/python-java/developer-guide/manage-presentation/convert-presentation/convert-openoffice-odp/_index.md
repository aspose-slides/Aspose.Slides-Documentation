---
title: Python で OpenDocument プレゼンテーションを変換
linktitle: OpenDocument を変換
type: docs
weight: 10
url: /ja/python-java/convert-openoffice-odp/
keywords:
- ODP を変換
- ODP から PDF へ
- ODP から HTML へ
- ODP から TIFF へ
- ODP から PPT へ
- ODP から PPTX へ
- ODP から XPS へ
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: Aspose.Slides for Python via Java を使用して、OpenDocument（ODP）プレゼンテーションを PDF、HTML、その他の形式に変換します。OpenOffice や LibreOffice をインストールする必要はありません。
---
## **はじめに**

Aspose.Slides for Python via Java を使用すると、OpenDocument（ODP）プレゼンテーションを PDF、HTML、TIFF、XPS、PPT、PPTX などの形式に変換できます。ODP 変換は PowerPoint 変換と同じ API を使用します。ソース ファイルは [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) で読み込み、出力形式は [SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) で選択します。

## **ODP を PDF に変換**

サンプルを実行する前に、[インストール手順](/slides/ja/python-java/installation/) に従ってください。作業ディレクトリに `pres.odp` という名前の ODP プレゼンテーションを配置します。以下のコードは、必要に応じて JVM を起動し、プレゼンテーションを読み込み、`pres.pdf` として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **さまざまなアプリケーションでの OpenDocument プレゼンテーション**

PowerPoint と LibreOffice/OpenOffice Impress では、サポートしているプレゼンテーション機能やレンダリング動作が異なるため、ODP プレゼンテーションの表示が異なる場合があります。レイアウトが複雑な書式設定に依存している場合は、変換後のプレゼンテーションを確認してください。

互換性の違いは以下に影響する可能性があります：

- テーブルおよび他のシェイプとのスタッキング順序、画像塗りつぶしのサポート。
- テキストの回転と配置。
- テキストに適用された画像、グラデーション、パターン塗りつぶし。
- 番号付きリストと箇条書きリスト。

以下の画像は LibreOffice Impress で作成されたリストの例です：

![LibreOffice Impress の ODP リスト例](odp-list-example.png)

Aspose.Slides は LibreOffice/OpenOffice Impress との互換性のために ODP リストを保存します。

機能の互換性の詳細については、[Microsoft の OpenDocument プレゼンテーション形式に関するガイド](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0)をご覧ください。

## **FAQ**

**変換後に ODP ファイルの書式が変わってしまった場合はどうすればよいですか？**

ODP と PowerPoint は異なるプレゼンテーション モデルを使用しています。テーブル、フォント、塗りつぶしスタイルは異なる方法でレンダリングされる可能性があります。必要なフォントが利用可能か確認し、出力を確認し、必要に応じてレイアウトや書式を調整してください。

**ODP ファイルを変換するために OpenOffice または LibreOffice をインストールする必要がありますか？**

いいえ。Aspose.Slides for Python via Java は、いずれのアプリケーションも必要とせずにプレゼンテーションを処理します。互換性のある Java ランタイムと Python パッケージが必要です。

**ODP プレゼンテーションを変換するときに PDF の出力をカスタマイズできますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/) を使用して、画像品質や圧縮などの PDF エクスポート設定を構成できます。

**サーバーやコンテナ内で ODP プレゼンテーションを変換できますか？**

はい。Python パッケージ、互換性のある Java ランタイム、プレゼンテーションで必要なフォントを対象環境にインストールすれば、オフィス アプリケーションは不要です。