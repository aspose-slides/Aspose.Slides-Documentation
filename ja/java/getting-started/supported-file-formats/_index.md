---
title: サポートされているファイル形式
type: docs
weight: 106
url: /ja/java/supported-file-formats/
keywords:
- サポートされているファイル形式
- プレゼンテーションのロード
- PDF のインポート
- HTML のインポート
- プレゼンテーションの保存
- スライドのレンダリング
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- Java
- Aspose.Slides
description: "Aspose.Slides for Java がロード、インポート、保存、レンダリングできるファイル形式と、それぞれを読み書きする API を確認してください。"
---
## **概要**

Aspose.Slides for Java は PowerPoint および OpenDocument のプレゼンテーションを開いたり保存したりできます。また、PDF や HTML のコンテンツをスライドにインポートし、プレゼンテーションをドキュメント、Web、画像形式に保存し、個々のスライドや図形を画像としてレンダリングします。本記事ではサポートされている各形式と、それを読み書きする API を一覧にしています。

機能の概要については、[機能概要](/slides/ja/java/features-overview/) を参照してください。

## **サポートされている Microsoft PowerPoint バージョン**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}

PowerPoint 95 以前のバージョンで保存されたプレゼンテーションは開くことができません。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) は PowerPoint 95 のファイルを検出し `LoadFormat.Ppt95` を報告しますが、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) コンストラクタはそれに対して [PptUnsupportedFormatException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptunsupportedformatexception/) をスローします。

{{% /alert %}}

## **サポートされているファイル形式**

この表は 4 つの操作を示しています。

- **Load**: [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) コンストラクタがファイルを編集可能なプレゼンテーションとして開きます。
- **Import**: [SlideCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidecollection/) のメソッドがファイルのコンテンツからスライドを作成し、既存のプレゼンテーションに追加します。Presentation コンストラクタはこれらのファイルをスライドに変換しません。
- **Save**: [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) がプレゼンテーションをファイルまたはストリームに書き出します。XAML を除くすべての形式は [SaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) の値で指定します。
- **Render**: レンダリングメソッドがスライドまたは図形を画像として描画します。レンダリングのみ可能な形式は SaveFormat の値を持ちません。

|**形式**|**説明**|**ロード / インポート**|**保存 / レンダリング**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 プレゼンテーション|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 テンプレート|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 スライドショー|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint プレゼンテーション|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint テンプレート|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint スライドショー|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint マクロ有効プレゼンテーション|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint マクロ有効テンプレート|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint マクロ有効スライドショー|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument プレゼンテーション|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument プレゼンテーション|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument プレゼンテーションテンプレート|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML プレゼンテーション|Load|Save|`SaveFormat.Xml`; 読み込まれたファイルは `SourceFormat.Xml` を報告します（`LoadFormat` の値はありません）|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff`（スライドごとに 1 ページ）; `ImageFormat.Tiff`（1 スライド）|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif`（アニメーション、全スライド）; `ImageFormat.Gif`（1 スライド）|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.save(IXamlOptions)`, スライドあたり 1 つの XAML ファイル; `SaveFormat` の値はありません|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG 画像|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap 画像|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **ロードとインポート**

- **Load:** ファイルパスまたはストリームを [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) コンストラクタに渡します。形式はコンテンツから自動検出され、[LoadOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/) でパスワードなどの設定を指定できます。開く前にファイルをチェックするには、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を呼び出し、[LoadFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadformat/) の値を取得します。PowerPoint XML については `LoadFormat.Unknown` が返りますが、コンストラクタはファイルを開き、[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSourceFormat--) は `SourceFormat.Xml` を返します。詳細は [プレゼンテーションを開く](/slides/ja/java/open-presentation/) と [元のプレゼンテーション形式を判定する](/slides/ja/java/detect-presentation-source-format/) を参照してください。
- **Import:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) は PDF の各ページを 1 スライドとしてプレゼンテーションの末尾に追加します。[SlideCollection.addFromHtml](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) は HTML から作成したスライドを追加し、[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) は指定位置に挿入します。Presentation コンストラクタはインポートを行わず、PDF ファイルに対しては [PptUnsupportedFormatException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptunsupportedformatexception/) をスローし、HTML マークアップをスライドコンテンツに変換しません。[PDF または HTML からプレゼンテーションをインポートする](/slides/ja/java/import-presentation/) を参照してください。

## **保存とレンダリング**

- **Save:** [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) は [SaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) の値で指定された形式でプレゼンテーションを書き出します。オプションオブジェクトを受け取るオーバーロードにより出力を制御でき、例として [PdfOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmloptions/)、[Html5Options](https://reference.aspose.com/slides/ja/java/com.aspose.slides/html5options/)、[TiffOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tiffoptions/)、[GifOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/gifoptions/) があります。スライド位置の配列（1 から開始）を受け取るオーバーロードは指定されたスライドだけを書き出し、PDF、XPS、TIFF、HTML、HTML5、SWF、GIF、Markdown に対応しますが、プレゼンテーション形式や PowerPoint XML には対応しません。XAML には独自のオーバーロード [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) があり、[IXamlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ixamloptions/) を受け取ります。詳細は [プレゼンテーションを保存](/slides/ja/java/save-presentation/)、[プレゼンテーションを変換](/slides/ja/java/convert-presentation/)、[XAML にエクスポート](/slides/ja/java/export-to-xaml/) をご覧ください。
- **Render:** [Slide.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/#getImage-float-float-) と [Shape.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getImage--) は [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) を返し、[IImage.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/#save-java.lang.String-int-) により PNG、JPEG、BMP、GIF、TIFF のいずれかで保存できます。保存形式は [ImageFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imageformat/) の値で指定します。[Presentation.getImages](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) はすべてのスライドまたは選択したスライドを一括でレンダリングします。[Slide.writeAsSvg](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) と [Shape.writeAsSvg](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) は SVG を、[Slide.writeAsEmf](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) は EMF を書き出します。[スライドを画像に変換](/slides/ja/java/convert-slide/) と [スライドを SVG 画像としてレンダリング](/slides/ja/java/render-a-slide-as-an-svg-image/) を参照してください。

{{% alert color="warning" title="Warning" %}}

ImageFormat には `Emf`、`Wmf`、`Icon`、`Exif`、`MemoryBmp` などの値もありますが、IImage.save ではそれらの形式は生成されず、書き出されるファイルは PNG データとなります。スライドの EMF 画像が必要な場合は Slide.writeAsEmf を使用してください。

{{% /alert %}}

## **FAQ**

**PPT プレゼンテーションを PPTX または ODP に変換できますか？**

はい。PPT ファイルを Presentation コンストラクタで開き、`SaveFormat.Pptx` または `SaveFormat.Odp` で保存します。[PPT から PPTX へ変換](/slides/ja/java/convert-ppt-to-pptx/) を参照してください。

**PDF や HTML ファイルをプレゼンテーションとして開くことはできますか？**

いいえ。Presentation コンストラクタは PDF ファイルに対して PptUnsupportedFormatException をスローし、HTML マークアップをスライドに変換しません。プレゼンテーションを作成または開き、上記のスライドコレクションメソッドで PDF ページや HTML コンテンツをインポートし、任意のサポート形式で保存してください。

**エクスポートした PNG や SVG 画像を編集可能なプレゼンテーションとして読み込めますか？**

いいえ。画像出力はスライドの見た目を記録するもので、テキストや図形、チャートは含まれません。後で編集が必要な場合は元のプレゼンテーションを保持してください。

**PDF/A や PDF/UA 文書を保存できますか？**

はい。[PdfOptions.setCompliance](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/#setCompliance-int-) に [PdfCompliance](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfcompliance/) の値を指定します。対応する形式は PDF/A-1a、PDF/A-1b、PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b、または PDF/UA です。

**ファイルがパスワード保護されているかどうかを開く前に確認できますか？**

はい。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) は Presentation オブジェクトを作成せずにファイルを検査し、[IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) がパスワードが必要かどうかを報告します。[プレゼンテーションにパスワードを設定](/slides/ja/java/password-protected-presentation/) を参照してください。