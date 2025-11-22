---
title: PythonでPowerPointプレゼンテーションをHTMLに変換
linktitle: PowerPointからHTMLへ
type: docs
weight: 30
url: /ja/python-net/convert-powerpoint-to-html/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからHTMLへ
- プレゼンテーションからHTMLへ
- スライドからHTMLへ
- PPTからHTMLへ
- PPTXからHTMLへ
- PowerPointをHTMLとして保存
- プレゼンテーションをHTMLとして保存
- スライドをHTMLとして保存
- PPTをHTMLとして保存
- PPTXをHTMLとして保存
- Python
- Aspose.Slides
description: "PythonでPowerPointプレゼンテーションをレスポンシブHTMLに変換します。レイアウト、リンク、画像を保持し、Aspose.Slidesの変換ガイドに従って高速かつ完璧な結果を得られます。"
---

## **概要**

本記事では、Python を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックについて解説します。

- Python で PowerPoint を HTML に変換
- Python で PPT を HTML に変換
- Python で PPTX を HTML に変換
- Python で ODP を HTML に変換
- Python で PowerPoint スライドを HTML に変換

## **Python PowerPoint を HTML に変換**

PowerPoint を HTML に変換する Python のサンプルコードについては、以下のセクション、すなわち [Convert PowerPoint to HTML](#convert-powerpoint-to-html) を参照してください。このコードは PPT、PPTX、ODP などの複数の形式を Presentation オブジェクトで読み込み、HTML 形式で保存できます。

## **PowerPoint から HTML への変換について**

[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを HTML に変換できます：**PPTX to HTML** または **PPT to HTML**。

Aspose.Slides は、PowerPoint を HTML に変換するプロセスを定義する多数のオプション（主に [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) クラス）を提供します：

* PowerPoint プレゼンテーション全体を HTML に変換します。
* PowerPoint プレゼンテーション内の特定のスライドを HTML に変換します。
* プレゼンテーションのメディア（画像、動画など）を HTML に変換します。
* PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。
* スピーカーノートを含めるか除外した HTML に PowerPoint プレゼンテーションを変換します。
* コメントを含めるか除外した HTML に PowerPoint プレゼンテーションを変換します。
* 元のフォントまたは埋め込みフォントを使用した HTML に PowerPoint プレゼンテーションを変換します。
* 新しい CSS スタイルを使用した HTML に PowerPoint プレゼンテーションを変換します。

{{% alert color="primary" %}} 

独自の API を使用して、Aspose は無料の [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) コンバータを開発しました： [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の Aspose の無料コンバータもご覧ください。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

ここで説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関わる以下の変換操作もサポートしています：

* [HTML to image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint を HTML に変換**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション全体を次のように HTML に変換できます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します
2. [Save ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)method を使用してオブジェクトを HTML ファイルとして保存します。

このコードは、PowerPoint を Python で HTML に変換する方法を示しています：
```python
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Saving the presentation to HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```


## **PowerPoint をレスポンシブ HTML に変換**

Aspose.Slides は、レスポンシブ HTML ファイルを生成できる [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) クラスを提供します。このコードは、PowerPoint プレゼンテーションを Python でレスポンシブ HTML に変換する方法を示しています：
```py
# プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# プレゼンテーションを HTML に保存します
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```


## **PowerPoint をノート付き HTML に変換**

このコードは、PowerPoint を Python でノート付き HTML に変換する方法を示しています：
```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```


## **PowerPoint を元フォント付き HTML に変換**

Aspose.Slides は、プレゼンテーションを HTML に変換する際にすべてのフォントを埋め込むことができる [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスを提供します。

特定のフォントを埋め込むのを防止するには、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスのパラメータ化されたコンストラクタにフォント名の配列を渡すことができます。Calibri や Arial などの一般的なフォントは、ほとんどのシステムに既に存在するため、埋め込む必要はありません。これらのフォントを埋め込むと、生成される HTML 文書が不必要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスは継承をサポートし、`WriteFont` メソッドを提供します。このメソッドはオーバーライドすることが想定されています。
```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# デフォルトのプレゼンテーションフォントを除外
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```


## **スライドを HTML に変換**

別個のプレゼンテーション スライドを HTML に変換します。そのためには、全体の PPT(X) プレゼンテーションを HTML ドキュメントに変換する際に使用される [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが提供する同じ [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドを使用します。また、追加の変換オプションを設定するために [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) クラスも使用できます：
```py
# [TODO[not_supported_yet]: .net インターフェイスの Python 実装]
```


## **HTML にエクスポートする際に CSS と画像を保存**

新しい CSS スタイル ファイルを使用すると、PowerPoint から HTML への変換プロセスで生成される HTML ファイルのスタイルを簡単に変更できます。

この例の Python コードは、オーバーライド可能なメソッドを使用して CSS ファイルへのリンクを含むカスタム HTML ドキュメントを作成する方法を示しています：
```py
# [TODO[not_supported_yet]: .net インターフェイスの Python 実装]
```


## **プレゼンテーションを HTML に変換する際にすべてのフォントをリンク**

フォントを埋め込みたくない（HTML のサイズ増加を防ぎたい）場合は、独自の `LinkAllFontsHtmlController` 実装によりすべてのフォントをリンクできます。

この Python コードは、すべてのフォントをリンクしつつ、システムに既に存在する「Calibri」と「Arial」を除外して PowerPoint を HTML に変換する方法を示しています：
```py
# [TODO[not_supported_yet]: .net インターフェイスの Python 実装]
```


## **SVG レスポンシブ プロパティのサポート**

以下のコードサンプルは、レスポンシブ レイアウトで PPT(X) プレゼンテーションを HTML にエクスポートする方法を示しています：
```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **メディアファイルを HTML ファイルへエクスポート**

Aspose.Slides for python を使用すると、次の手順でメディアファイルをエクスポートできます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドへの参照を取得します。
3. スライドにビデオを追加します。
4. プレゼンテーションを HTML ファイルとして書き出します。

この Python コードは、プレゼンテーションにビデオを追加し、HTML として保存する方法を示しています：
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


## **よくある質問**

### **Python を使用して PowerPoint プレゼンテーションを HTML に変換する方法は？**

`save()` メソッドに `SaveFormat.HTML` を指定して、Aspose.Slides for Python via .NET ライブラリで PPT、PPTX、または ODP ファイルを読み込み、HTML に変換できます。

### **Aspose.Slides は個々の PowerPoint スライドを HTML に変換することをサポートしていますか？**

はい、Aspose.Slides は `HtmlOptions` を構成することで、プレゼンテーション全体または特定のスライドを HTML に変換できます。

### **PowerPoint プレゼンテーションからレスポンシブ HTML を生成できますか？**

はい、`ResponsiveHtmlController` クラスを使用すると、さまざまな画面サイズに適応するレスポンシブ HTML レイアウトにエクスポートできます。

### **エクスポートされた HTML にスピーカーノートやコメントを含めることは可能ですか？**

はい、`HtmlOptions` を設定して、スピーカーノートやコメントを含めるか除外するかを選択できます。

### **プレゼンテーションを HTML に変換する際にフォントを埋め込むことはできますか？**

はい、`EmbedAllFontsHtmlController` クラスを使用すると、フォントを埋め込むか、特定のフォントを除外して出力ファイルサイズを削減するかを選択できます。

### **PowerPoint から HTML への変換はビデオやオーディオなどのメディアファイルをサポートしていますか？**

はい、`VideoPlayerHtmlController` などの関連クラスを使用して、スライドに埋め込まれたメディアコンテンツを HTML にエクスポートできます。

### **HTML への変換でサポートされているファイル形式は何ですか？**

Aspose.Slides は PPT、PPTX、ODP のプレゼンテーション形式を HTML に変換することをサポートしています。また、スライド内容を SVG として保存したり、メディア資産をエクスポートしたりできます。

### **フォントを埋め込まずに HTML の出力サイズを削減できますか？**

はい、Arial や Calibri などシステムに既に存在するフォントは埋め込まずにリンクするカスタム `HtmlController` 実装を作成できます。

### **PowerPoint を HTML に変換するオンラインツールはありますか？**

はい、[PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html) や [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html) など、Aspose の無料ウェブツールを使用してブラウザー上でコードを書かずに直接変換できます。

### **エクスポートされた HTML ファイルにカスタム CSS スタイルを使用できますか？**

はい、変換時に外部 CSS ファイルへのリンクを設定できるため、生成される HTML コンテンツの外観を完全にカスタマイズできます。