---
title: サポートされているファイル形式
type: docs
weight: 96
url: /ja/net/supported-file-formats/
keywords:
- サポートされているファイル形式
- プレゼンテーションの読み込み
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET が読み込み、インポート、保存、レンダリングできるファイル形式と、各形式を読み書きする API を確認できます。"
---
## **概要**

Aspose.Slides for .NET は PowerPoint および OpenDocument プレゼンテーションを開いたり保存したりします。また、PDF および HTML コンテンツをスライドにインポートし、プレゼンテーションを文書、Web、画像形式で保存し、個々のスライドやシェイプを画像としてレンダリングします。本記事では、サポートされている各形式と、それを読み書きする API を列挙します。

Aspose.Slides.NET と Aspose.Slides.NET6.CrossPlatform の両方の NuGet パッケージは同じ形式をサポートしています。どちらを使用するかは [Installation](/slides/ja/net/installation/) を参照してください。編集機能の概要については、[Features Overview](/slides/ja/net/features-overview/) をご覧ください。

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
- Microsoft 365 用 PowerPoint（旧称 Office 365）

{{% alert color="info" title="Note" %}}
PowerPoint 95 以前のバージョンで保存されたプレゼンテーションは開くことができません。[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationfactory/getpresentationinfo/) は PowerPoint 95 ファイルを認識し、`LoadFormat.Ppt95` を報告しますが、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/presentation/) コンストラクタはそれに対して [PptUnsupportedFormatException](https://reference.aspose.com/slides/ja/net/aspose.slides/pptunsupportedformatexception/) をスローします。
{{% /alert %}}

## **サポートされているファイル形式**

表では次の 4 つの操作を使用します:

- **Load**: [Presentation] コンストラクタはファイルを編集可能なプレゼンテーションとして開きます。
- **Import**: [SlideCollection] メソッドはファイルのコンテンツからスライドを作成し、既存のプレゼンテーションに追加します。Presentation コンストラクタはこれらのファイルをプレゼンテーションとして読み込むことはできません。
- **Save**: [Presentation.Save] はプレゼンテーションをファイルまたはストリームに書き込みます。XAML を除くすべての形式は [SaveFormat] の値で選択されます。
- **Render**: レンダリング メソッドはスライドまたはシェイプを画像として描画します。レンダリングのみが可能な形式は SaveFormat の値がありません。

|**形式**|**説明**|**読み込み / インポート**|**保存 / レンダリング**|**API**|
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
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML プレゼンテーション|Load|Save|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|ポータブルドキュメントフォーマット|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|ハイパーテキストマークアップ言語|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML ペーパー仕様|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|タグ付き画像ファイル形式|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|グラフィックス交換形式|—|Save, Render|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format（Flash）|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|拡張可能アプリケーションマークアップ言語|—|Save|`Presentation.Save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|ポータブルネットワークグラフィックス|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG 画像|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|ビットマップ画像|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|拡張メタファイル|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|スケーラブルベクターグラフィックス|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **読み込みとインポート**

- **ロード:** ファイル パスまたはストリームを [Presentation] コンストラクタに渡します。形式はコンテンツから検出され、[LoadOptions] でパスワードなどの設定を提供できます。ファイルを開く前に確認するには、[PresentationFactory.GetPresentationInfo] を呼び出し、[LoadFormat] の値を取得します。PowerPoint XML については `LoadFormat.Unknown` が報告されますが、コンストラクタはそのファイルを開き、[Presentation.SourceFormat] は `SourceFormat.Xml` を返します。[Open Presentations](/slides/ja/net/open-presentation/) と [Determine the Original Presentation Format](/slides/ja/net/detect-presentation-source-format/) を参照してください。
- **インポート:** [SlideCollection.AddFromPdf] は PDF の各ページにつき1枚のスライドをプレゼンテーションの末尾に追加します。[SlideCollection.AddFromHtml] は HTML から作成されたスライドを追加し、[SlideCollection.InsertFromHtml] は指定位置に挿入します。Presentation コンストラクタはインポートしません。PDF ファイルに対しては [PptUnsupportedFormatException] がスローされ、HTML マークアップはスライド コンテンツに変換されません。[Import Presentations from PDF or HTML](/slides/ja/net/import-presentation/) を参照してください。

## **保存とレンダリング**

- **保存:** [Presentation.Save] は [SaveFormat] の値で指定された形式でプレゼンテーションを書き出します。オプション オブジェクトを受け取るオーバーロードで出力を制御できます。例: [PdfOptions]、[HtmlOptions]、[Html5Options]、[TiffOptions]、[GifOptions]。スライド位置の配列（1 から開始）を受け取るオーバーロードは、指定したスライドだけを書き出します。これらは PDF、XPS、TIFF、HTML、HTML5、SWF、GIF、Markdown に対応しますが、プレゼンテーション形式や PowerPoint XML には対応しません。XAML には [IXamlOptions] を受け取る独自のオーバーロードがあります。[Save Presentations](/slides/ja/net/save-presentation/)、[Convert Presentations](/slides/ja/net/convert-presentation/)、[Export Presentations to XAML](/slides/ja/net/export-to-xaml/) を参照してください。
- **レンダリング:** [Slide.GetImage] と [Shape.GetImage] は [IImage] を返し、[IImage.Save] は PNG、JPEG、BMP、GIF、TIFF のいずれかに書き出します。選択は [ImageFormat] の値で行います。[Presentation.GetImages] はすべてまたは選択したスライドを一度にレンダリングします。[Slide.WriteAsSvg] と [Shape.WriteAsSvg] は SVG を書き出し、[Slide.WriteAsEmf] は EMF を書き出します。[Convert Presentation Slides to Images](/slides/ja/net/convert-slide/) と [Render a Slide as an SVG Image](/slides/ja/net/render-a-slide-as-an-svg-image/) を参照してください。

{{% alert color="warning" title="Warning" %}}
ImageFormat には `Emf`、`Wmf`、`Icon`、`Exif`、`MemoryBmp` の値もありますが、IImage.Save はそれらの形式を生成しません。書き込まれるファイルは PNG データです。スライドの EMF 画像を取得するには Slide.WriteAsEmf を使用してください。
{{% /alert %}}

## **FAQ**

**PPT プレゼンテーションを PPTX または ODP に変換できますか？**

はい。PPT ファイルを Presentation コンストラクタで開き、`SaveFormat.Pptx` または `SaveFormat.Odp` で保存します。[Convert PPT to PPTX](/slides/ja/net/convert-ppt-to-pptx/) を参照してください。

**PDF または HTML ファイルをプレゼンテーションとして開くことはできますか？**

いいえ。プレゼンテーションを作成または開き、上記のスライドコレクション メソッドで PDF ページまたは HTML コンテンツをインポートし、任意のサポート形式で保存します。

**エクスポートした PNG または SVG 画像を編集可能なプレゼンテーションとして読み込むことはできますか？**

いいえ。画像の出力はスライドの見た目を記録したもので、テキストやシェイプ、チャートは含まれません。後で編集が必要な場合は元のプレゼンテーションを保持してください。

**PDF/A または PDF/UA ドキュメントを保存できますか？**

はい。[PdfOptions.Compliance] に [PdfCompliance] の値を設定します：PDF/A-1a、PDF/A-1b、PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b、または PDF/UA。

**ファイルがパスワード保護されているかどうかを開く前に確認できますか？**

はい。[PresentationFactory.GetPresentationInfo] は Presentation オブジェクトを作成せずにファイルを検査し、その [IsPasswordProtected] プロパティでパスワードが必要かどうかを報告します。[Password-Protect Presentations](/slides/ja/net/password-protected-presentation/) を参照してください。

**2 つの NuGet パッケージは異なる形式をサポートしていますか？**

いいえ。Aspose.Slides.NET と Aspose.Slides.NET6.CrossPlatform は同じ LoadFormat と SaveFormat の値、同じインポートおよびレンダリング メソッドを持ちます。実行プラットフォームとその要件が異なるだけです。[Installation](/slides/ja/net/installation/) を参照してください。