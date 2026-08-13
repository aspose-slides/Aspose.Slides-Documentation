---
title: プレゼンテーションにおける画像管理の最適化（.NET）
linktitle: 画像管理
type: docs
weight: 10
url: /ja/net/image/
keywords:
- 画像を追加
- 図を追加
- ビットマップを追加
- 画像を置換
- 図を置換
- Web から
- 背景
- PNG を追加
- JPG を追加
- SVG を追加
- 外部 SVG リソース
- SVG リゾルバ
- リンクされた SVG 画像
- SVG フォント
- EMF を追加
- WMF を追加
- TIFF を追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: PowerPoint と OpenDocument の画像管理を Aspose.Slides for .NET で効率化し、パフォーマンスを最適化してワークフローを自動化します。
---
## **はじめに**

画像はプレゼンテーションをより魅力的で視覚的に訴えるものにします。Microsoft PowerPoint では、ファイルやインターネット、その他のソースからスライドに画像を挿入できます。同様に、Aspose.Slides を使用すると、さまざまな方法でプレゼンテーションスライドに画像を追加できます。

{{% alert  title="Tip" color="info" %}} 

Aspose は無料コンバータ―[JPEG から PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG から PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt)―を提供しており、画像から素早くプレゼンテーションを作成できます。 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

画像をピクチャーフレームとして追加したい場合、特にサイズ変更や効果の適用、その他の標準的な書式設定オプションを使用する予定がある場合は、[ピクチャーフレーム](/slides/ja/net/picture-frame/) を参照してください。 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

画像をある形式から別の形式に変換できます。以下のページをご覧ください：変換 [画像 to JPG](https://products.aspose.com/slides/ja/net/conversion/image-to-jpg/)、[JPG to 画像](https://products.aspose.com/slides/ja/net/conversion/jpg-to-image/)、[JPG to PNG](https://products.aspose.com/slides/ja/net/conversion/jpg-to-png/)、[PNG to JPG](https://products.aspose.com/slides/ja/net/conversion/png-to-jpg/)、[PNG to SVG](https://products.aspose.com/slides/ja/net/conversion/png-to-svg/)、および [SVG to PNG](https://products.aspose.com/slides/ja/net/conversion/svg-to-png/)。 

{{% /alert %}}

Aspose.Slides は JPEG、PNG、BMP、GIF などの一般的なフォーマットの画像をサポートしています。

## **ローカルに保存された画像をスライドへ追加**

コンピューターに保存されている画像を 1 つまたは複数、プレゼンテーションのスライドに追加できます。以下の C# サンプルコードは、スライドに画像を追加する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Web から画像をスライドに追加**

スライドに追加したい画像がコンピューターに保存されていない場合、Web から直接追加できます。

以下の C# サンプルコードは、Web から画像を取得してスライドに追加する方法を示しています。

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **スライドマスタに画像を追加**

スライドマスタは、テーマやレイアウトなど、マスタを使用するスライドの情報を保持・管理します。スライドマスタに画像を追加すると、そのマスタに基づくすべてのスライドに画像が表示されます。

以下の C# サンプルコードは、スライドマスタに画像を追加する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **画像をスライドの背景として追加**

画像を 1 枚または複数のスライドの背景として使用できます。詳細については、*[スライドの背景として画像を設定](/slides/ja/net/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加**

SVG コンテンツは、[SvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/svgimage/) クラスを使用してプレゼンテーションに追加できます。結果として得られる [ISvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/) オブジェクトは、プレゼンテーションの画像コレクションに追加でき、ピクチャーフレームの作成に使用できます。

以下の C# 例は、自己完結型の SVG 文字列をインポートします。この SVG で使用されているすべての画像、スタイル、およびその他のリソースは、SVG コンテンツに直接埋め込まれています。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **外部リソースを含む SVG コンテンツのインポート**

デザインツール、ダイアグラムエディタ、アイコンシステム、Web パイプラインからエクスポートされた SVG ファイルは、SVG ドキュメントの外部に保存されているリソースを参照する場合があります。たとえば、SVG は `images/photo.png` のような画像リンクや、CSS の `url(...)` 値、フォント URL を含むことがあります。

このような SVG コンテンツをインポートするには、[IExternalResourceResolver](https://reference.aspose.com/slides/ja/net/aspose.slides.import/iexternalresourceresolver/) の実装を作成し、ベース URI と共に適切な `SvgImage` コンストラクタに渡します。ベース URI は SVG ドキュメントの場所を示し、相対リンクの解決に使用されます。

[ISvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/) インターフェイスは、インポートされた SVG に関する情報へのアクセスを提供します：

- `SvgContent` は SVG のマークアップ文字列を返します。
- `SvgData` は SVG コンテンツをバイト配列で返します。
- `BaseUri` は相対リンクに使用されるベース URI を返します。
- `ExternalResourceResolver` は SVG 画像に割り当てられたリソースリゾルバを返します。

### **外部リソースリゾルバの実装**

リゾルバには 2 つのメソッドがあります：

- [ResolveUri](https://reference.aspose.com/slides/ja/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) はベース URI と相対リソースリンクを結合し、絶対 URI を返します。リンクが解決できない場合や許可されていない場合は `null` を返します。
- [GetEntity](https://reference.aspose.com/slides/ja/net/aspose.slides.import/iexternalresourceresolver/getentity/) は絶対リソース URI 用の読み取り可能なストリームを返します。リソースが欠落、ブロック、または利用不可の場合は `null` を返します。必要に応じてフォールバックストリームを返すこともできます。

以下のリゾルバは、許可されたローカルディレクトリからのみリンクされたリソースをロードします。ネットワークリソースや許可されたディレクトリ外のパスはブロックされます。解決できない画像リンクには、オプションでフォールバック画像が返されます。

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // このリゾルバは意図的にローカルファイルのみを許可します。
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // 画像リソースに対してのみフォールバックを使用します。画像ストリームを返す
        // 欠落したフォントやスタイルシートに対しては無効です。
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **SVG インポート時にリンクリソースを解決**

`assets/diagram.svg` が次のような相対参照を含んでいるとします：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下の C# 例は、SVG ファイルの URI をベース URI として渡し、カスタムリゾルバを提供します。リゾルバは相対画像リンクを絶対 URI に変換し、リンクされたリソースを含むストリームを返しながら Aspose.Slides が SVG を処理します。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// ベース URI は SVG ドキュメントの位置を表します。
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage はソース コンテンツ、バイナリ データ、ベース URI、リゾルバを提供します。
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

`SvgImage` クラスは、SVG データをバイト配列またはストリームで受け取り、外部リソースリゾルバとベース URI を指定できるオーバーロードも提供します。

{{% alert title="Important" color="warning" %}}

リソースリゾルバは、Aspose.Slides が SVG を処理・レンダリングする間、外部リソースを利用可能にします。元の SVG マークアップを変更したり、解決されたリソースを自動的に埋め込んだりはしません。

`ISvgImage` がプレゼンテーションの画像コレクションに追加されると、PPTX ファイルは元の SVG 表現とラスター形式のフォールバック画像の両方を含む可能性があります。リンクされたリソースは生成されたフォールバック画像に現れる一方、`images/photo.png` のような相対リンクは保存された SVG 内で変更されません。そのため、ネイティブな SVG 表現をレンダリングするアプリケーションは、元の外部リソースが利用できない場合にリンクされたコンテンツを省略することがあります。

{{% /alert %}}

### **ポータブルな SVG 画像の作成**

外部ファイルに依存しない SVG 画像を作成するには、`SvgImage` を作成する前に SVG を自己完結型にします。例として、リンクされた画像 URL を画像データを含む `data:` URI に置き換えます：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

必要なリソースをすべて SVG コンテンツに埋め込んだら、`SvgImage` を作成し、プレゼンテーションの画像コレクションに追加し、前述の例のようにピクチャーフレームに挿入します。

### **不足またはブロックされたリソースの処理**

`ResolveUri` では、リソース URI が無効、禁止、または解決できない場合に `null` を返します。`GetEntity` では、リソースを読み取れない場合に `null` を返します。可能な限り、Aspose.Slides はそのリソースなしで SVG の処理を続行します。

不足しているリソースに対してはフォールバックストリームを返すことができますが、その内容は要求されたリソースタイプと互換性がある必要があります。たとえば、欠落した画像に対してのみ画像ストリームを返し、フォントやスタイルシートに対しては返さないでください。

{{% alert title="Security" color="warning" %}}

信頼できない SVG ファイルから任意のファイルパスや無制限のネットワーク URL を解決しないでください。許可されるスキーム、ディレクトリ、ホストを制限します。ネットワークリソースについては、接続タイムアウト、レスポンスサイズの上限、コンテンツの検証も適用してください。

{{% /alert %}}

## **SVG をシェイプのセットに変換**

Aspose.Slides は、PowerPoint の同等機能と同様に、SVG をシェイプのセットに変換できます：

![PowerPoint ポップアップ メニュー](img_01_01.png)

この機能は、[AddGroupShape](https://reference.aspose.com/slides/ja/net/aspose.slides.ishapecollection/addgroupshape/methods/1) メソッドのオーバーロードで提供され、[IShapeCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection) インターフェイスの一部として、最初の引数に [ISvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage) オブジェクトを受け取ります。

以下の C# サンプルコードは、このメソッドを使用して SVG ファイルをシェイプのセットに変換する方法を示しています。

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// ソース SVG ファイル名
string svgFileName = "sample.svg";

// 出力プレゼンテーション ファイル名
string outPptxPath = "presentation.pptx";

// 新しいプレゼンテーションを作成
using (IPresentation presentation = new Presentation())
{
    // SVG ファイルの内容を読み取る
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage オブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // スライドのサイズを取得
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG 画像をシェイプのグループに変換し、スライドサイズに合わせてスケーリング
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // プレゼンテーションを PPTX 形式で保存
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **画像を EMF としてスライドに追加**

.NET 用 Aspose.Slides は、Aspose.Cells を使用して Excel ワークシートから EMF 画像を生成し、プレゼンテーションのスライドに追加することができます。

以下の C# サンプルコードは、その手順を示しています。

``` csharp
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // ワークブックをストリームに保存
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **画像コレクション内の画像を置換**

Aspose.Slides は、プレゼンテーションの画像コレクションに保存されている画像（スライドのシェイプで使用されている画像を含む）を置換できます。このセクションでは、コレクション内の画像を更新するいくつかの方法を説明します。生のバイトデータ、[IImage] インスタンス、またはコレクションに既に存在する別の画像を使用して画像を置換できます。

以下の手順に従ってください：

1. 画像を含むプレゼンテーション ファイルを [Presentation] クラスでロードします。
2. ファイルから新しい画像を読み込み、バイト配列に格納します。
3. バイト配列を使用して対象画像を新しい画像に置換します。
4. 2 番目の方法では、画像を [IImage] オブジェクトにロードし、そのオブジェクトで対象画像を置換します。
5. 3 番目の方法では、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。
6. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("sample.pptx");

// 最初の方法。
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// 2 番目の方法。
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// 3 番目の方法。
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// プレゼンテーションをファイルに保存します。
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Aspose の無料 [Text to GIF](https://products.aspose.app/slides/ja/text-to-gif) コンバータを使用すると、テキストを簡単にアニメーション化し、GIF に変換できます。 

{{% /alert %}}

## **よくある質問**

**挿入後も元の画像解像度は保持されますか？**

はい。元のピクセルは保持されますが、最終的な表示はスライド上での [画像](/slides/ja/net/picture-frame/) のスケーリング方法や保存時に適用される圧縮に依存します。

**数十枚のスライドに同じロゴを一括で置換する最適な方法は何ですか？**

ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置換します。これにより、そのリソースを使用しているすべての要素に変更が反映されます。

**挿入した SVG を編集可能なシェイプに変換できますか？**

はい。SVG をシェイプのグループに変換でき、その後は個々のパーツが標準的なシェイプ プロパティで編集可能になります。

**複数のスライドの背景に画像を一括で設定するにはどうすればよいですか？**

マスタースライドまたは該当レイアウトで [画像を背景として割り当て](/slides/ja/net/presentation-background/) すると、該当するマスタ/レイアウトを使用しているすべてのスライドがその背景を継承します。

**多数の画像によりプレゼンテーションが大きくなるのを防ぐにはどうすればよいですか？**

同一画像リソースを再利用し、重複を避けます。適切な解像度を選び、保存時に圧縮を適用し、繰り返し使用するグラフィックは適切にマスタに配置します。