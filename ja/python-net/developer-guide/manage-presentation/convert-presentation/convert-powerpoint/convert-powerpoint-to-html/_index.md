---
title: PowerPoint プレゼンテーションを Python で HTML に変換
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/python-net/convert-powerpoint-to-html/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を HTML に変換
- プレゼンテーションを HTML に変換
- スライドを HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- PowerPoint を HTML として保存
- プレゼンテーションを HTML として保存
- スライドを HTML として保存
- PPT を HTML として保存
- PPTX を HTML として保存
- Python
- Aspose.Slides
description: "Python で PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。レイアウト、リンク、画像を保持し、Aspose.Slides の変換ガイドで高速かつ完璧な結果を実現します。"
---

## **概要**

この記事では、Python を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックを扱います。

- PowerPoint を Python で HTML に変換
- PPT を Python で HTML に変換
- PPTX を Python で HTML に変換
- ODP を Python で HTML に変換
- PowerPoint スライドを Python で HTML に変換

## **Python PowerPoint to HTML**

Python で PowerPoint を HTML に変換するサンプルコードについては、以下のセクション「[PowerPoint を HTML に変換](#convert-powerpoint-to-html)」をご覧ください。このコードは PPT、PPTX、ODP などの形式を Presentation オブジェクトで読み込み、HTML 形式で保存できます。

## **PowerPointからHTMLへの変換について**
[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを **PPTX から HTML** または **PPT から HTML** に変換できます。

**Aspose.Slides** は、主に [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) クラスから提供される多数のオプションを通じて、PowerPoint から HTML への変換プロセスを定義します。

* PowerPoint プレゼンテーション全体を HTML に変換
* PowerPoint プレゼンテーションの特定のスライドを HTML に変換
* プレゼンテーションのメディア（画像、動画など）を HTML に変換
* レスポンシブ HTML に変換
* スピーカーノートを含むまたは除外した HTML に変換
* コメントを含むまたは除外した HTML に変換
* 元のフォントまたは埋め込みフォントで HTML に変換
* 新しい CSS スタイルを使用した HTML に変換

{{% alert color="primary" %}} 

独自 API を使用して、Aspose は無料の[プレゼンテーションから HTML への変換](https://products.aspose.app/slides/conversion/powerpoint-to-html)コンバータを開発しました: [PPT から HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX から HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP から HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の Aspose の無料コンバータもぜひご確認ください: [free converters from Aspose](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

本稿で説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関する以下の変換操作もサポートしています。

* [HTML から画像](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML から JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML から XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML から TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint を HTML に変換**
Aspose.Slides を使用すると、次の手順で PowerPoint プレゼンテーション全体を HTML に変換できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成
1. [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドを使用してオブジェクトを HTML ファイルとして保存

以下のコードは、Python で PowerPoint を HTML に変換する方法を示しています:
```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# プレゼンテーションを HTML に保存します
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```


## **PowerPoint をレスポンシブ HTML に変換**

Aspose.Slides は、レスポンシブ HTML ファイルの生成を可能にする [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) クラスを提供しています。以下のコードは、Python でプレゼンテーションをレスポンシブ HTML に変換する方法を示しています:
```py
# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# プレゼンテーションを HTML に保存します
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```


## **PowerPoint をノート付き HTML に変換**
以下のコードは、Python でノート付きの PowerPoint を HTML に変換する方法を示しています:
```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```


## **PowerPoint を元フォント付き HTML に変換**
Aspose.Slides は、プレゼンテーションを HTML に変換する際にすべてのフォントを埋め込むことができる [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスを提供しています。

特定のフォントを埋め込まないようにするには、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) のパラメータ化されたコンストラクタにフォント名の配列を渡します。Calibri や Arial のような一般的なフォントは、ほとんどのシステムに既にインストールされているため、埋め込む必要はありません。これらのフォントを埋め込むと、生成される HTML ドキュメントが不要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスは継承をサポートし、`WriteFont` メソッドをオーバーライドできるように提供しています。 
```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# デフォルトのプレゼンテーション フォントを除外
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```


## **スライドを HTML に変換**
個別のスライドを HTML に変換します。その際は、全体の PPT(X) プレゼンテーションを HTML 文書に変換する際に使用する [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドと同じものを使用します。また、追加の変換オプションを設定するために [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) クラスも利用できます:
```py
# [TODO[not_supported_yet]: .net インターフェイスの Python 実装]
```



## **HTML エクスポート時に CSS と画像を保存**
新しい CSS スタイルファイルを使用すると、PowerPoint から HTML への変換プロセスで生成される HTML のスタイルを簡単に変更できます。

この例の Python コードは、オーバーライド可能なメソッドを使用して CSS ファイルへのリンクを含むカスタム HTML ドキュメントを作成する方法を示しています:
```py
# [TODO[not_supported_yet]: .net インターフェイスの Python 実装]
```


## **プレゼンテーションを HTML に変換する際にすべてのフォントをリンク**
フォントを埋め込まず（結果の HTML のサイズ増加を防ぐために）すべてのフォントをリンクしたい場合は、独自の `LinkAllFontsHtmlController` 実装を作成できます。

以下の Python コードは、すべてのフォントをリンクし、システムに既に存在する「Calibri」および「Arial」を除外して PowerPoint を HTML に変換する方法を示しています: 
```py
# [TODO[not_supported_yet]: python 実装の .net インターフェイス]
```


## **SVG レスポンシブ プロパティのサポート**
以下のサンプルコードは、レスポンシブレイアウトで PPT(X) プレゼンテーションを HTML にエクスポートする方法を示しています:
```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```



## **メディア ファイルを HTML ファイルにエクスポート**
Aspose.Slides for python を使用して、メディア ファイルを次の手順でエクスポートできます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成
1. スライドへの参照を取得
1. スライドにビデオを追加
1. プレゼンテーションを HTML ファイルとして書き込む

以下の Python コードは、プレゼンテーションにビデオを追加し、HTML として保存する方法を示しています:
```py
import aspose.slides as slides

# プレゼンテーションを読み込み
presentation = slides.Presentation("Media File.pptx")

path = "C:\\"
fileName = "ExportMediaFiles_out.html"
baseUri = "http://www.example.com/"

controller = slides.export.VideoPlayerHtmlController(path, fileName, baseUri)

htmlOptions = slides.export.HtmlOptions(controller)
svgOptions = slides.export.SVGOptions(controller)

htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
htmlOptions.slide_image_format = slides.export.SlideImageFormat.svg(svgOptions)

presentation.save(path + "ExportMediaFiles_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```


## **FAQ**

**Python を使用して PowerPoint プレゼンテーションを HTML に変換するにはどうすればよいですか？**

Aspose.Slides for Python via .NET ライブラリを使用して PPT、PPTX、または ODP ファイルを読み込み、`save()` メソッドに `SaveFormat.HTML` を指定して HTML に変換できます。

**Aspose.Slides は個々の PowerPoint スライドを HTML に変換することをサポートしていますか？**

はい。Aspose.Slides は `HtmlOptions` を構成することで、プレゼンテーション全体または特定のスライドを HTML に変換できます。

**PowerPoint プレゼンテーションからレスポンシブ HTML を生成できますか？**

はい。`ResponsiveHtmlController` クラスを使用すると、さまざまな画面サイズに適応するレスポンシブ HTML レイアウトにエクスポートできます。

**エクスポートした HTML にスピーカーノートやコメントを含めることは可能ですか？**

はい。`HtmlOptions` を設定して、スピーカーノートやコメントの含有・除外を制御できます。

**プレゼンテーションを HTML に変換する際にフォントを埋め込むことはできますか？**

はい。`EmbedAllFontsHtmlController` クラスを使用すると、フォントを埋め込んだり、特定のフォントを除外したりして出力ファイルサイズを削減できます。

**PowerPoint から HTML への変換はビデオや音声などのメディア ファイルをサポートしていますか？**

はい。`VideoPlayerHtmlController` などの関連クラスを使用して、スライドに埋め込まれたメディア コンテンツを HTML にエクスポートできます。

**HTML への変換でサポートされているファイル形式は何ですか？**

Aspose.Slides は PPT、PPTX、ODP のプレゼンテーション形式を HTML に変換できます。また、スライド コンテンツを SVG として保存したり、メディア資産をエクスポートしたりすることも可能です。

**フォントを埋め込まずに HTML の出力サイズを削減できますか？**

はい。Arial や Calibri などの一般的なシステムフォントは埋め込まずにリンクするカスタム `HtmlController` 実装を使用してサイズを抑えることができます。

**オンラインで PowerPoint を HTML に変換するツールはありますか？**

はい。Aspose の無料ウェブツール（例: [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html) や [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)）を使用すれば、コードを書かずにブラウザー上で直接変換できます。

**エクスポートした HTML にカスタム CSS スタイルを使用できますか？**

はい。変換時に外部 CSS ファイルへのリンクを設定できるため、生成された HTML の外観を自由にカスタマイズできます。