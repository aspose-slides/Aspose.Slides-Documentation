---
title: PowerPointプレゼンテーションをPythonでHTMLに変換
linktitle: PowerPointからHTMLへ
type: docs
weight: 30
url: /ja/python-net/convert-powerpoint-to-html/
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
description: "PythonでPowerPointプレゼンテーションをレスポンシブなHTMLに変換します。レイアウト、リンク、画像を保持し、Aspose.Slides の変換ガイドで高速かつ完璧な結果を実現します。"
---

## **概要**

この記事では、Python を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックをカバーしています。

- Python で PowerPoint を HTML に変換
- Python で PPT を HTML に変換
- Python で PPTX を HTML に変換
- Python で ODP を HTML に変換
- Python で PowerPoint スライドを HTML に変換

## **Python PowerPoint から HTML へ**

PowerPoint を HTML に変換する Python のサンプルコードについては、以下のセクション **[Convert PowerPoint to HTML](#convert-powerpoint-to-html)** を参照してください。このコードは PPT、PPTX、ODP などの形式を Presentation オブジェクトに読み込み、HTML 形式で保存できます。

## **PowerPoint から HTML への変換について**
[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを **PPTX から HTML** または **PPT から HTML** に変換できます。

**Aspose.Slides** は、主に [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) クラスから提供される多数のオプションを通じて、PowerPoint から HTML への変換プロセスを定義します。

* プレゼンテーション全体を HTML に変換
* プレゼンテーション内の特定スライドを HTML に変換
* プレゼンテーションのメディア（画像、動画など）を HTML に変換
* レスポンシブ HTML に変換
* スピーカーノートを含める／除外した HTML に変換
* コメントを含める／除外した HTML に変換
* 元のフォントまたは埋め込みフォントで HTML に変換
* 新しい CSS スタイルを使用した HTML に変換

{{% alert color="primary" %}} 
独自 API を用いて、Aspose は無料の [プレゼンテーションから HTML への変換ツール](https://products.aspose.app/slides/conversion/powerpoint-to-html) を開発しています: [PPT から HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX から HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP から HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の無料コンバータもぜひご確認ください: [Aspose の無料コンバータ一覧](https://products.aspose.app/slides/conversion)。
{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 
ここで説明した変換プロセスに加えて、Aspose.Slides は以下の HTML 関連変換操作もサポートしています：

* [HTML から画像へ](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML から JPG へ](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML から XML へ](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML から TIFF へ](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)
{{% /alert %}}

## **PowerPoint を HTML に変換**
Aspose.Slides を使用して、プレゼンテーション全体を HTML に変換する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成
2. [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドでオブジェクトを HTML ファイルとして保存

以下のコードは、Python で PowerPoint を HTML に変換する例です。

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

Aspose.Slides の [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) クラスを使用すると、レスポンシブ HTML ファイルを生成できます。以下のコードは、Python でプレゼンテーションをレスポンシブ HTML に変換する例です。

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
以下のコードは、ノートを含めた状態で PowerPoint を HTML に変換する例です。

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **元のフォントを埋め込んで PowerPoint を HTML に変換**
Aspose.Slides の [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスを使用すると、変換時にプレゼンテーションのすべてのフォントを埋め込むことができます。

特定のフォントを埋め込みたくない場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) のパラメータ化コンストラクタにフォント名の配列を渡します。Calibri や Arial のようにシステムに既に存在するフォントは埋め込む必要がありません。埋め込むと HTML 文書が不要に大きくなるためです。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスは継承をサポートし、`WriteFont` メソッドをオーバーライドできます。

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
スライド単体を HTML に変換するには、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが提供する **[Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)** メソッドを使用します。追加の変換オプションは [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) クラスで設定できます。

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **HTML エクスポート時に CSS と画像を保存**
新しい CSS スタイルファイルを使用すると、PowerPoint から HTML への変換で生成される HTML のスタイルを簡単に変更できます。

以下の Python コードは、CSS ファイルへのリンクを持つカスタム HTML 文書を作成するためにオーバーライド可能なメソッドを使用する例です。

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **フォントを埋め込まずにリンクする**
フォントを埋め込まずにファイルサイズ増加を抑えたい場合は、独自の `LinkAllFontsHtmlController` を実装してすべてのフォントにリンクできます。

以下のコードは、Arial と Calibri を除外しながらすべてのフォントにリンクして PowerPoint を HTML に変換する例です。

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **SVG レスポンシブプロパティのサポート**
以下のサンプルは、レスポンシブレイアウトで PPT(X) プレゼンテーションを HTML にエクスポートする方法を示しています。

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **メディア ファイルを HTML にエクスポート**
Aspose.Slides for Python を使用すると、メディア ファイルを次の手順でエクスポートできます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成
2. スライドへの参照を取得
3. スライドに動画を追加
4. プレゼンテーションを HTML ファイルとして書き出し

以下のコードは、プレゼンテーションに動画を追加し、HTML として保存する例です。

```py
import aspose.slides as slides

# プレゼンテーションをロード
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

## FAQ

### **Python で PowerPoint プレゼンテーションを HTML に変換するには？**

Aspose.Slides for Python via .NET ライブラリを使用し、PPT、PPTX、ODP ファイルをロードして `save()` メソッドに `SaveFormat.HTML` を指定すれば変換できます。

### **個別スライドの HTML 変換はサポートされていますか？**

はい。Aspose.Slides は、プレゼンテーション全体または特定スライドを `HtmlOptions` で設定して HTML に変換できます。

### **レスポンシブ HTML を生成できますか？**

はい。`ResponsiveHtmlController` クラスを使用すると、画面サイズに応じてレイアウトが変化するレスポンシブ HTML をエクスポートできます。

### **スピーカーノートやコメントを HTML に含めることは可能ですか？**

はい。`HtmlOptions` を構成すれば、エクスポート時にノートやコメントの有無を選択できます。

### **フォントを埋め込んで HTML に変換できますか？**

はい。`EmbedAllFontsHtmlController` を使用してフォントを埋め込むか、特定のフォントを除外してファイルサイズを削減できます。

### **動画や音声などのメディアファイルは変換時にサポートされていますか？**

はい。`VideoPlayerHtmlController` などの関連クラスを使用して、スライドに埋め込まれたメディアを HTML にエクスポートできます。

### **HTML への変換でサポートされているファイル形式は？**

Aspose.Slides は PPT、PPTX、ODP を HTML に変換できます。また、スライドコンテンツを SVG として保存したり、メディア資産をエクスポートすることも可能です。

### **フォントを埋め込まずに HTML の出力サイズを抑えることはできますか？**

はい。Arial や Calibri などシステムに既に存在するフォントは埋め込まずにリンクする実装（`HtmlController` のカスタム実装）でサイズを削減できます。

### **オンラインで PowerPoint を HTML に変換できるツールはありますか？**

はい。無料の Web ツールとして [PPT から HTML](https://products.aspose.app/slides/conversion/ppt-to-html) や [PPTX から HTML](https://products.aspose.app/slides/conversion/pptx-to-html) を利用すれば、コードを書かずにブラウザ上で変換できます。

### **エクスポートされた HTML にカスタム CSS を適用できますか？**

はい。変換時に外部 CSS ファイルへのリンクを設定できるため、生成された HTML の外観を自由にカスタマイズできます。