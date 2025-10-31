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
description: "Python で PowerPoint プレゼンテーションをレスポンシブな HTML に変換します。レイアウト、リンク、画像を保持し、Aspose.Slides の変換ガイドで高速かつ完璧な結果が得られます。"
---

## **概要**

本記事では、Python を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックをカバーしています。

- Python で PowerPoint を HTML に変換
- Python で PPT を HTML に変換
- Python で PPTX を HTML に変換
- Python で ODP を HTML に変換
- Python で PowerPoint スライドを HTML に変換

## **Python PowerPoint を HTML に変換**

PowerPoint を HTML に変換する Python のサンプルコードについては、下記セクション [PowerPoint を HTML に変換](#convert-powerpoint-to-html) を参照してください。このコードは PPT、PPTX、ODP などの複数の形式を Presentation オブジェクトにロードし、HTML 形式で保存できます。

## **PowerPoint を HTML に変換する概要**
[**Python 用 Aspose.Slides (.NET 経由)**](https://products.aspose.com/slides/python-net/) を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを **PPTX から HTML** または **PPT から HTML** に変換できます。

**Aspose.Slides** は、主に [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) クラスから提供される多数のオプションを使用して、PowerPoint から HTML への変換プロセスを定義します。

* PowerPoint 全体のプレゼンテーションを HTML に変換  
* 特定のスライドだけを HTML に変換  
* プレゼンテーションのメディア（画像、動画など）を HTML に変換  
* レスポンシブ HTML に変換  
* スピーカーノートを含める／除外した HTML に変換  
* コメントを含める／除外した HTML に変換  
* 元のフォントまたは埋め込みフォントを使用した HTML に変換  
* 新しい CSS スタイルを使用した HTML に変換  

{{% alert color="primary" %}} 

独自 API を使用して、Aspose は無料の [プレゼンテーションから HTML へのコンバータ](https://products.aspose.app/slides/conversion/powerpoint-to-html) を開発しました: [PPT から HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX から HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP から HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。  

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の [Aspose の無料コンバータ](https://products.aspose.app/slides/conversion) もぜひご確認ください。  

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

本稿で説明した変換プロセスに加えて、Aspose.Slides は以下の HTML 関連変換もサポートしています:  

* [HTML から画像へ](https://products.aspose.com/slides/python-net/conversion/html-to-image/)  
* [HTML から JPG へ](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)  
* [HTML から XML へ](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)  
* [HTML から TIFF へ](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)  

{{% /alert %}}


## **PowerPoint を HTML に変換**
Aspose.Slides を使用して、プレゼンテーション全体を HTML に変換する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成  
2. [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドを使用してオブジェクトを HTML ファイルとして保存  

以下のコードは、Python で PowerPoint を HTML に変換する方法を示しています。

```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# プレゼンテーションを HTML として保存
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **レスポンシブ HTML に変換**

Aspose.Slides は、[ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) クラスを提供し、レスポンシブ HTML ファイルを生成できます。以下のコードは、Python でプレゼンテーションをレスポンシブ HTML に変換する方法を示しています。

```py
# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# プレゼンテーションを HTML として保存
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **ノート付きで PowerPoint を HTML に変換**
以下のコードは、ノートを含めて PowerPoint を HTML に変換する方法を示しています。

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **元フォントを埋め込んで PowerPoint を HTML に変換**
Aspose.Slides は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスを提供し、変換時にプレゼンテーション内のすべてのフォントを埋め込むことができます。

特定のフォントを埋め込まないようにするには、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) のパラメータ化コンストラクタにフォント名の配列を渡します。Calibri や Arial のような一般的なフォントは、システムに既に存在することが多いため埋め込む必要はありません。埋め込むと HTML ドキュメントが不要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) クラスは継承をサポートし、`WriteFont` メソッドをオーバーライドできます。

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
個別のスライドを HTML に変換します。そのためには、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが公開している **Save** メソッドを使用します。`HtmlOptions` クラスを使用して追加の変換オプションを設定することもできます。

```py
# [TODO[not_supported_yet]: python の .net インターフェイス 実装]
```

## **HTML エクスポート時に CSS と画像を保存**
新しい CSS スタイル ファイルを使用すると、PowerPoint から HTML への変換プロセスで生成される HTML ファイルのスタイルを簡単に変更できます。

この例の Python コードは、CSS ファイルへのリンクを持つカスタム HTML ドキュメントを作成するためにオーバーライド可能なメソッドを使用する方法を示しています。

```py
# [TODO[not_supported_yet]: python の .net インターフェイス 実装]
```

## **プレゼンテーション変換時にすべてのフォントをリンク**
フォントを埋め込まず、HTML のサイズ増加を防ぎたい場合は、独自の `LinkAllFontsHtmlController` を実装してすべてのフォントをリンクできます。

以下の Python コードは、フォント「Calibri」および「Arial」を除外しながら、すべてのフォントをリンクして PowerPoint を HTML に変換する方法を示しています。

```py
# [TODO[not_supported_yet]: python の .net インターフェイス 実装]
```

## **SVG レスポンシブプロパティのサポート**
以下のサンプルは、レスポンシブ レイアウトで PPT(X) プレゼンテーションを HTML にエクスポートする方法を示しています。

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **メディア ファイルを HTML にエクスポート**
Aspose.Slides for Python を使用してメディアファイルをエクスポートする手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成  
2. スライドへの参照を取得  
3. スライドにビデオを追加  
4. プレゼンテーションを HTML ファイルとして書き出し  

以下の Python コードは、プレゼンテーションにビデオを追加し、HTML として保存する方法を示しています。

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

## よくある質問

### **Python で PowerPoint プレゼンテーションを HTML に変換するにはどうすればよいですか？**

Aspose.Slides for Python via .NET ライブラリを使用して PPT、PPTX、または ODP ファイルをロードし、`save()` メソッドに `SaveFormat.HTML` を指定して HTML に変換できます。

### **Aspose.Slides は個々のスライドを HTML に変換できますか？**

はい、`HtmlOptions` を設定することで、プレゼンテーション全体または特定のスライドを HTML に変換できます。

### **PowerPoint プレゼンテーションからレスポンシブ HTML を生成できますか？**

はい、`ResponsiveHtmlController` クラスを使用して、さまざまな画面サイズに適応するレスポンシブ HTML レイアウトにエクスポートできます。

### **エクスポートした HTML にスピーカーノートやコメントを含めることは可能ですか？**

はい、`HtmlOptions` を構成して、スピーカーノートやコメントを含めるか除外するかを選択できます。

### **プレゼンテーションを HTML に変換する際にフォントを埋め込むことはできますか？**

はい、`EmbedAllFontsHtmlController` クラスを使用してフォントを埋め込んだり、特定のフォントを除外したりして出力ファイルのサイズを抑えることができます。

### **PowerPoint から HTML への変換はビデオやオーディオなどのメディアファイルをサポートしていますか？**

はい、`VideoPlayerHtmlController` などの関連クラスを使用して、スライドに埋め込まれたメディアコンテンツを HTML にエクスポートできます。

### **HTML への変換でサポートされているファイル形式は何ですか？**

Aspose.Slides は PPT、PPTX、ODP のプレゼンテーション形式を HTML に変換できます。また、スライドコンテンツを SVG として保存したり、メディア資産をエクスポートしたりすることも可能です。

### **フォントを埋め込まずに HTML の出力サイズを削減することはできますか？**

はい、Arial や Calibri などシステムに既に存在するフォントは埋め込まずにリンクするよう、`HtmlController` のカスタム実装で対応できます。

### **PowerPoint を HTML に変換するオンラインツールはありますか？**

はい、[PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html) や [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html) など、Aspose の無料 Web ツールを利用してブラウザだけでプレゼンテーションを変換できます。

### **エクスポートした HTML ファイルでカスタム CSS スタイルを使用できますか？**

はい、変換時に外部 CSS ファイルへのリンクを設定できるため、出力された HTML の外観を自由にカスタマイズできます。