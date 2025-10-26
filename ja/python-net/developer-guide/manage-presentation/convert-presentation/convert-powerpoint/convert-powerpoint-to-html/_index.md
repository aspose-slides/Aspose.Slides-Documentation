---
title: PythonでPowerPointプレゼンテーションをHTMLに変換
linktitle: PowerPointからHTMLへ
type: docs
weight: 30
url: /ja/python-net/developer-guide/manage-presentation/convert-presentation/convert-powerpoint/convert-powerpoint-to-html/
keywords:
- PowerPoint変換
- プレゼンテーション変換
- スライド変換
- PPT変換
- PPTX変換
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
description: "PythonでPowerPointプレゼンテーションをレスポンシブなHTMLに変換します。Aspose.Slides の変換ガイドを使用して、レイアウト、リンク、画像を保持しながら高速で完璧な結果を実現します。"
---

## **概要**

この記事では、Python を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックをカバーします。

- Python で PowerPoint を HTML に変換
- Python で PPT を HTML に変換
- Python で PPTX を HTML に変換
- Python で ODP を HTML に変換
- Python で PowerPoint スライドを HTML に変換

## **PythonでPowerPointをHTMLへ**

PowerPoint を HTML に変換する Python のサンプルコードについては、以下のセクション「[PowerPoint を HTML に変換](#convert-powerpoint-to-html)」をご参照ください。このコードは PPT、PPTX、ODP など複数の形式を `Presentation` オブジェクトで読み込み、HTML 形式で保存します。

## **PowerPoint から HTML への変換について**
[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを **PPTX から HTML** または **PPT から HTML** に変換できます。

**Aspose.Slides** は、主に [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) クラスから提供される多数のオプションを通じて、PowerPoint から HTML への変換プロセスを定義します。

* プレゼンテーション全体を HTML に変換
* 特定のスライドのみを HTML に変換
* 画像、動画などのメディアを HTML に変換
* レスポンシブ HTML に変換
* スピーカーノートを含める・除外する HTML に変換
* コメントを含める・除外する HTML に変換
* 元のフォントまたは埋め込みフォントで HTML に変換
* 新しい CSS スタイルを使用して HTML に変換

{{% alert color="primary" %}} 

独自 API を使用し、Aspose は無料の [プレゼンテーションから HTML への変換ツール](https://products.aspose.app/slides/conversion/powerpoint-to-html) を開発しています: [PPT から HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX から HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP から HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の [Aspose の無料コンバータ](https://products.aspose.app/slides/conversion) もぜひご確認ください。

{{% /alert %}} 

{{% alert title="注" color="warning" %}} 

ここで説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関わる以下の変換操作もサポートしています: 

* [HTML から画像へ](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML から JPG へ](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML から XML へ](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML から TIFF へ](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint を HTML に変換**
Aspose.Slides を使用すると、以下の手順でプレゼンテーション全体を HTML に変換できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成
2. [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドを使用してオブジェクトを HTML ファイルとして保存

このコードは Python で PowerPoint を HTML に変換する方法を示しています。

```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# プレゼンテーションを HTML に保存
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **PowerPoint をレスポンシブ HTML に変換**

Aspose.Slides は [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) クラスを提供し、レスポンシブ HTML ファイルの生成を可能にします。以下のコードは Python でプレゼンテーションをレスポンシブ HTML に変換する方法を示しています。

```py
# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# プレゼンテーションを HTML に保存
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **ノート付きで PowerPoint を HTML に変換**
以下のコードは Python でノート付きの PowerPoint を HTML に変換する方法を示しています。

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **元のフォントで PowerPoint を HTML に変換**
Aspose.Slides は [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスを提供し、プレゼンテーションを HTML に変換する際にすべてのフォントを埋め込むことができます。

特定のフォントを埋め込みたくない場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) のパラメータ化コンストラクタにフォント名の配列を渡します。Calibri や Arial などの一般的なフォントは、ほとんどのシステムに既にインストールされているため埋め込む必要はありません。埋め込むと HTML 文書が不要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスは継承をサポートし、上書き可能な `WriteFont` メソッドを提供します。

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
個別のスライドを HTML に変換します。そのためには、プレゼンテーション全体を HTML に変換する際に使用したのと同じ [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドを利用します。追加の変換オプションを設定するために [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) クラスも使用できます。

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **HTML エクスポート時に CSS と画像を保存**
新しい CSS スタイル ファイルを使用すると、PowerPoint から HTML への変換プロセスで生成された HTML ファイルのスタイルを簡単に変更できます。

以下の Python コードは、CSS ファイルへのリンクを持つカスタム HTML ドキュメントを作成するために、オーバーライド可能なメソッドを使用する方法を示しています。

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **フォントを埋め込まずにリンク**
フォントを埋め込まず（結果の HTML のサイズ増加を防ぐため）にすべてのフォントをリンクしたい場合は、独自の `LinkAllFontsHtmlController` 実装を作成します。

以下の Python コードは、フォントをリンクしつつ「Calibri」と「Arial」を除外して PowerPoint を HTML に変換する方法を示しています。

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **SVG レスポンシブ プロパティのサポート**
以下のサンプルは、レスポンシブ レイアウトで PPT(X) プレゼンテーションを HTML にエクスポートする方法を示しています。

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **メディア ファイルを HTML にエクスポート**
Aspose.Slides for Python を使用して、メディア ファイルを次の手順でエクスポートできます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成
2. スライドへの参照を取得
3. スライドに動画を追加
4. プレゼンテーションを HTML ファイルとして書き出し

以下の Python コードは、プレゼンテーションに動画を追加し、HTML として保存する方法を示しています。

```py
import aspose.slides as slides

# プレゼンテーションを読み込む
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

### **PowerPoint プレゼンテーションを Python で HTML に変換するにはどうすればよいですか？**

Aspose.Slides for Python via .NET ライブラリを使用して PPT、PPTX、ODP ファイルを読み込み、`save()` メソッドに `SaveFormat.HTML` を指定して HTML に変換できます。

### **個別のスライドを HTML に変換できますか？**

はい、Aspose.Slides は `HtmlOptions` を設定することで、プレゼンテーション全体または特定のスライドを HTML に変換できます。

### **レスポンシブ HTML を生成できますか？**

はい、`ResponsiveHtmlController` クラスを使用すると、さまざまな画面サイズに適応するレスポンシブ HTML レイアウトでエクスポートできます。

### **スピーカーノートやコメントを HTML に含められますか？**

はい、`HtmlOptions` を構成して、エクスポート時にノートやコメントを含めるか除外するかを選択できます。

### **フォントを埋め込んで HTML に変換できますか？**

はい、`EmbedAllFontsHtmlController` クラスを使用すると、フォントを埋め込むか、特定のフォントを除外して出力サイズを削減できます。

### **動画や音声などのメディアファイルは HTML に含められますか？**

はい、`VideoPlayerHtmlController` などの関連クラスを使用して、スライドに埋め込まれたメディアコンテンツを HTML にエクスポートできます。

### **HTML への変換がサポートされているファイル形式は何ですか？**

Aspose.Slides は PPT、PPTX、ODP のプレゼンテーション形式を HTML に変換できます。また、スライド内容を SVG として保存し、メディア資産をエクスポートすることも可能です。

### **フォントを埋め込まずに HTML の出力サイズを減らす方法はありますか？**

はい、`HtmlController` のカスタム実装でシステムに標準でインストールされている Arial や Calibri などのフォントをリンクすることで、埋め込みを回避できます。

### **オンラインで PowerPoint を HTML に変換できるツールはありますか？**

はい、[PPT から HTML](https://products.aspose.app/slides/conversion/ppt-to-html) や [PPTX から HTML](https://products.aspose.app/slides/conversion/pptx-to-html) など、コードを書かずにブラウザ上で変換できる Aspose の無料ウェブツールがあります。

### **エクスポートした HTML ファイルでカスタム CSS を使用できますか？**

はい、変換時に外部 CSS ファイルへのリンクを設定できるため、生成された HTML の外観を自由にカスタマイズできます。