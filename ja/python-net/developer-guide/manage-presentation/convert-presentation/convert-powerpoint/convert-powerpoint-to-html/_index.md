---
title: Python で PowerPoint プレゼンテーションを HTML に変換
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
description: "Python で PowerPoint プレゼンテーションをレスポンシブな HTML に変換します。レイアウト、リンク、画像を保持し、Aspose.Slides の変換ガイドで迅速かつ完璧な結果を実現します。"
---

## **概要**

この記事では、Python を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックを扱います。

- Python で PowerPoint を HTML に変換
- Python で PPT を HTML に変換
- Python で PPTX を HTML に変換
- Python で ODP を HTML に変換
- Python で PowerPoint スライドを HTML に変換

## **Python PowerPoint を HTML に変換**

PowerPoint を HTML に変換する Python のサンプルコードについては、以下のセクション [PowerPoint を HTML に変換](#convert-powerpoint-to-html) を参照してください。このコードは PPT、PPTX、ODP などの複数の形式を Presentation オブジェクトで読み込み、HTML 形式で保存できます。

## **PowerPoint を HTML に変換について**
[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを HTML に変換できます: **PPTX を HTML に変換** または **PPT を HTML に変換**。

**Aspose.Slides** は、主に [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) クラスから提供される多数のオプションを介して、PowerPoint から HTML への変換プロセスを定義します。

* PowerPoint の全体プレゼンテーションを HTML に変換
* PowerPoint プレゼンテーションの特定のスライドを HTML に変換
* プレゼンテーションのメディア（画像、動画など）を HTML に変換
* PowerPoint プレゼンテーションをレスポンシブな HTML に変換
* スピーカーノートを含めるか除外した状態で PowerPoint プレゼンテーションを HTML に変換
* コメントを含めるか除外した状態で PowerPoint プレゼンテーションを HTML に変換
* オリジナルまたは埋め込みフォントで PowerPoint プレゼンテーションを HTML に変換
* 新しい CSS スタイルを使用しながら PowerPoint プレゼンテーションを HTML に変換

{{% alert color="primary" %}} 

独自の API を使用して、Aspose は無料の [プレゼンテーションから HTML への] コンバータを開発しました: [PPT を HTML に変換](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX を HTML に変換](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP を HTML に変換](https://products.aspose.app/slides/conversion/odp-to-html) など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の Aspose の無料コンバータもぜひご覧ください。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

ここで説明した変換プロセスに加えて、Aspose.Slides は HTML フォーマットに関する以下の変換操作もサポートしています:

* [HTML から画像へ](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML から JPG へ](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML から XML へ](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML から TIFF へ](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint を HTML に変換**
Aspose.Slides を使用すると、以下の手順で PowerPoint の全体プレゼンテーションを HTML に変換できます:

1. Presentation クラスのインスタンスを作成します
1. [Save] メソッドを使用してオブジェクトを HTML ファイルとして保存します

このコードは Python で PowerPoint を HTML に変換する方法を示しています:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Saving the presentation to HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **PowerPoint をレスポンシブ HTML に変換**
Aspose.Slides は [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) クラスを提供し、レスポンシブ HTML ファイルの生成を可能にします。このコードは Python で PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています:

```py
# Instantiate a Presentation object that represents a presentation file
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Saving the presentation to HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **PowerPoint を HTML に変換（ノート付き）**
このコードは Python でノートを含めて PowerPoint を HTML に変換する方法を示しています:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **PowerPoint を HTML に変換（オリジナルフォント付き）**
Aspose.Slides は、プレゼンテーションを HTML に変換する際にすべてのフォントを埋め込むことができる [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスを提供します。

特定のフォントを埋め込まないようにするには、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) のパラメータ化コンストラクタにフォント名の配列を渡します。Calibri や Arial などの一般的なフォントは、システムに既に存在するため埋め込む必要がありません。埋め込むと HTML ドキュメントが不要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスは継承をサポートし、`WriteFont` メソッドを上書きできるようにしています。

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# exclude default presentation fonts
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **スライドを HTML に変換**
個別のスライドを HTML に変換します。全体の PPT(X) プレゼンテーションを HTML ドキュメントに変換する際に使用する [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドと同じものを使用します。[**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) クラスを使用して追加の変換オプションを設定することもできます:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **HTML エクスポート時に CSS と画像を保存**
新しい CSS スタイル ファイルを使用すると、PowerPoint から HTML への変換プロセスで生成される HTML ファイルのスタイルを簡単に変更できます。

この例の Python コードは、CSS ファイルへのリンクを持つカスタム HTML ドキュメントを作成するために、オーバーライド可能なメソッドを使用する方法を示しています:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **プレゼンテーションを HTML に変換する際にすべてのフォントをリンク**
フォントを埋め込まず（結果の HTML のサイズ増加を回避するため）すべてのフォントをリンクしたい場合は、独自の `LinkAllFontsHtmlController` 実装を作成できます。

この Python コードは、フォントをリンクし、システムに既に存在する "Calibri" と "Arial" を除外して PowerPoint を HTML に変換する方法を示しています:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **SVG レスポンシブ プロパティのサポート**
以下のサンプルは、レスポンシブ レイアウトで PPT(X) プレゼンテーションを HTML にエクスポートする方法を示しています:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **メディア ファイルを HTML ファイルにエクスポート**
Aspose.Slides for Python を使用して、メディア ファイルを次のようにエクスポートできます:

1. Presentation クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. スライドにビデオを追加します。
1. プレゼンテーションを HTML ファイルとして書き出します。

この Python コードは、プレゼンテーションにビデオを追加し、HTML として保存する方法を示しています:

```py
import aspose.slides as slides

# Loading a presentation
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

## Frequently Asked Questions

### **How can I convert a PowerPoint presentation to HTML using Python?**
You can use the Aspose.Slides for Python via .NET library to load PPT, PPTX, or ODP files and convert them to HTML using the `save()` method with `SaveFormat.HTML`.

### **Does Aspose.Slides support converting individual PowerPoint slides to HTML?**
Yes, Aspose.Slides allows you to convert either the entire presentation or specific slides to HTML by configuring `HtmlOptions` accordingly.

### **Can I generate responsive HTML from PowerPoint presentations?**
Yes, with the `ResponsiveHtmlController` class, you can export your presentation to a responsive HTML layout that adapts to different screen sizes.

### **Is it possible to include speaker notes or comments in the exported HTML?**
Yes, you can configure the `HtmlOptions` to include or exclude speaker notes and comments when exporting PowerPoint presentations to HTML.

### **Can I embed fonts when converting a presentation to HTML?**
Yes, Aspose.Slides provides the `EmbedAllFontsHtmlController` class, which allows you to embed fonts or exclude certain fonts to reduce the output file size.

### **Does the PowerPoint to HTML conversion support media files like videos and audio?**
Yes, Aspose.Slides allows exporting media content embedded in slides to HTML using `VideoPlayerHtmlController` and related configuration classes.

### **What file formats are supported for conversion to HTML?**
Aspose.Slides supports converting PPT, PPTX, and ODP presentation formats to HTML. It also allows saving slide content as SVG and exporting media assets.

### **Can I avoid embedding fonts to reduce HTML output size?**
Yes, you can link commonly available system fonts like Arial or Calibri instead of embedding them, using a custom implementation of the `HtmlController`.

### **Is there an online tool to convert PowerPoint to HTML?**
Yes, you can try Aspose’s free web tools such as [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html) or [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html) to convert presentations directly in your browser without writing any code.

### **Can I use custom CSS styles in the exported HTML file?**
Yes, Aspose.Slides allows linking to external CSS files during conversion, enabling you to fully customize the appearance of the resulting HTML content.