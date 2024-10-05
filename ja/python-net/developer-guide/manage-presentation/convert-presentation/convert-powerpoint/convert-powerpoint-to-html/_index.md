---
title: PythonでPowerPointをHTMLに変換する
linktitle: PowerPointをHTMLに変換する
type: docs
weight: 30
url: /python-net/convert-powerpoint-to-html/
keywords: "Python PowerPoint to HTML, PowerPointプレゼンテーションの変換, PPTX, PPT, PPTをHTMLに, PPTXをHTMLに, PowerPointをHTMLに, PowerPointをHTMLとして保存, PPTをHTMLとして保存, PPTXをHTMLとして保存, Python, Aspose.Slides, HTMLエクスポート"
description: "PowerPoint HTMLの変換: PPTXまたはPPTをHTMLとして保存。スライドをHTMLとして保存"
---

## **概要**

この記事では、Pythonを使用してPowerPointプレゼンテーションをHTML形式に変換する方法を説明します。以下のトピックを扱います。

- PythonでPowerPointをHTMLに変換する
- PythonでPPTをHTMLに変換する
- PythonでPPTXをHTMLに変換する
- PythonでODPをHTMLに変換する
- PythonでPowerPointスライドをHTMLに変換する

## **Python PowerPointをHTMLに**

PowerPointをHTMLに変換するPythonサンプルコードについては、以下のセクションを参照してください。すなわち、[PowerPointをHTMLに変換する](#convert-powerpoint-to-html)。このコードは、PPT、PPTX、およびODPなどの形式をPresentationオブジェクトに読み込み、HTML形式として保存できます。

## **PowerPointからHTMLへの変換について**
[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)を使用することで、アプリケーションや開発者はPowerPointプレゼンテーションをHTMLに変換できます：**PPTXをHTMLに**または**PPTをHTMLに**。 

**Aspose.Slides**は、PowerPointからHTMLへの変換プロセスを定義する多くのオプション（主に[**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)クラスから）を提供します：

* PowerPointプレゼンテーション全体をHTMLに変換する。
* PowerPointプレゼンテーションの特定のスライドをHTMLに変換する。
* プレゼンテーションメディア（画像、動画など）をHTMLに変換する。
* PowerPointプレゼンテーションをレスポンシブHTMLに変換する。
* スピーカーノートを含めたり除外したりしてPowerPointプレゼンテーションをHTMLに変換する。
* コメントを含めたり除外したりしてPowerPointプレゼンテーションをHTMLに変換する。
* 元のフォントや埋め込まれたフォントを使用してPowerPointプレゼンテーションをHTMLに変換する。
* 新しいCSSスタイルを使用してPowerPointプレゼンテーションをHTMLに変換する。

{{% alert color="primary" %}} 

独自のAPIを使用して、Asposeは無料の[プレゼンテーションをHTMLに](https://products.aspose.app/slides/conversion/powerpoint-to-html)変換ツールを開発しました：[PPTをHTMLに](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTXをHTMLに](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODPをHTMLに](https://products.aspose.app/slides/conversion/odp-to-html)など。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の[無料のAspose変換ツール](https://products.aspose.app/slides/conversion)もチェックしてみてください。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

ここで説明した変換プロセスに加えて、Aspose.SlidesはHTML形式を含むこれらの変換操作もサポートしています：

* [HTMLから画像へ](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTMLからJPGへ](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTMLからXMLへ](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTMLからTIFFへ](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPointをHTMLに変換する**
Aspose.Slidesを使用して、次のようにPowerPointプレゼンテーション全体をHTMLに変換できます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)メソッドを使用して、オブジェクトをHTMLファイルとして保存します。

このコードでは、PythonでPowerPointをHTMLに変換する方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# プレゼンテーションをHTMLとして保存
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **PowerPointをレスポンシブHTMLに変換する**

Aspose.Slidesは、レスポンシブHTMLファイルを生成するための[ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/)クラスを提供しています。このコードでは、PythonでPowerPointプレゼンテーションをレスポンシブHTMLに変換する方法を示しています：

```py
# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# プレゼンテーションをHTMLとして保存
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **ノート付きのPowerPointをHTMLに変換する**
このコードでは、Pythonでノート付きのPowerPointをHTMLに変換する方法を示しています：

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **元のフォントを使用したPowerPointをHTMLに変換する**
Aspose.Slidesは、プレゼンテーションをHTMLに変換する際にすべてのフォントを埋め込むことを可能にする[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/)クラスを提供しています。

特定のフォントを埋め込まれないようにするには、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/)クラスのパラメータ付きコンストラクターにフォント名の配列を渡すことができます。プレゼンテーションで使用される一般的なフォント（例えば、CalibriやArial）は、ほとんどのシステムに既に含まれているため、埋め込む必要はありません。これらのフォントを埋め込むと、結果として得られるHTMLドキュメントが不必要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/)クラスは継承をサポートしており、`WriteFont`メソッドを提供しており、これはオーバーライドすることを目的としています。

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# デフォルトのプレゼンテーションフォントを除外
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **スライドをHTMLに変換する**
別々のプレゼンテーションスライドをHTMLに変換します。そのためには、全体のPPT(X)プレゼンテーションをHTML文書に変換するのに使用される[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスによって公開される同じ[**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)メソッドを使用してください。[**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)クラスを使用して追加の変換オプションを設定することもできます：

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```


## **HTMLにエクスポートする際にCSSと画像を保存する**
新しいCSSスタイルファイルを使用すると、PowerPointからHTMLへの変換プロセスの結果として得られるHTMLファイルのスタイルを簡単に変更できます。 

この例のPythonコードでは、オーバーライド可能なメソッドを使用してCSSファイルへのリンクを含むカスタムHTMLドキュメントを作成する方法を示しています：

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **プレゼンテーションをHTMLに変換する際にすべてのフォントをリンクする**
フォントを埋め込みたくない場合（生成するHTMLのサイズを増やさないため）、独自の`LinkAllFontsHtmlController`バージョンを実装してすべてのフォントをリンクすることができます。

このPythonコードは、「Calibri」と「Arial」を除外（すでにシステムに存在するため）しながらPowerPointをHTMLに変換する方法を示しています：

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **SVGレスポンシブプロパティのサポート**
以下のコードサンプルは、PPT(X)プレゼンテーションをHTMLにレスポンシブレイアウトでエクスポートする方法を示しています：

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **メディアファイルをHTMLファイルにエクスポートする**
Python用のAspose.Slidesを使用すると、次のようにメディアファイルをエクスポートできます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. スライドの参照を取得します。
1. スライドに動画を追加します。
1. プレゼンテーションをHTMLファイルとして書き込みます。

このPythonコードでは、プレゼンテーションに動画を追加し、その後HTMLとして保存する方法を示しています：

```py
import aspose.slides as slides

# プレゼンテーションの読み込み
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