---
title: .NET でのプレゼンテーションにおける画像管理の最適化
linktitle: 画像管理
type: docs
weight: 10
url: /ja/net/image/
keywords:
- 画像の追加
- 画像の追加
- ビットマップの追加
- 画像の置換
- 画像の置換
- Web から
- 背景
- PNG の追加
- JPG の追加
- SVG の追加
- 外部 SVG リソース
- SVG リゾルバ
- リンクされた SVG 画像
- SVG フォント
- EMF の追加
- WMF の追加
- TIFF の追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint と OpenDocument の画像管理を効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---
## **概要**

画像はプレゼンテーションをより魅力的で視覚的に訴えるものにします。Microsoft PowerPoint では、ファイル、インターネット、その他のソースからスライドに画像を挿入できます。同様に、Aspose.Slides では、さまざまな方法でプレゼンテーション スライドに画像を追加できます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータ―「[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt)」および「[PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt)」―を提供しており、画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
画像を画像枠として追加したい場合、特にサイズ変更やエフェクト適用、その他の標準的な書式設定オプションを利用する場合は、[Picture Frame](/slides/ja/net/picture-frame/) を参照してください。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
画像はフォーマット間で変換できます。以下のページをご参照ください: 変換 [image to JPG](https://products.aspose.com/slides/ja/net/conversion/image-to-jpg/)、[JPG to image](https://products.aspose.com/slides/ja/net/conversion/jpg-to-image/)、[JPG to PNG](https://products.aspose.com/slides/ja/net/conversion/jpg-to-png/)、[PNG to JPG](https://products.aspose.com/slides/ja/net/conversion/png-to-jpg/)、[PNG to SVG](https://products.aspose.com/slides/ja/net/conversion/png-to-svg/)、および [SVG to PNG](https://products.aspose.com/slides/ja/net/conversion/svg-to-png/)。 
{{% /alert %}}

Aspose.Slides は JPEG、PNG、BMP、GIF などの一般的なフォーマットの画像をサポートしています。 

## **ローカルに保存された画像をスライドに追加する**

コンピューターに保存されている画像を 1 つまたは複数、プレゼンテーション スライドに追加できます。以下の C# サンプルコードは、スライドに画像を追加する方法を示しています：

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

## **Web から画像をスライドに追加する**

スライドに追加したい画像がコンピューターに保存されていない場合、Web から直接追加できます。 

以下の C# サンプルコードは、Web から画像を取得してスライドに追加する方法を示しています：

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

## **スライドマスターに画像を追加する**

スライドマスターは、テーマやレイアウトなどの情報を保持し、マスターを使用するスライドに適用されます。スライドマスターに画像を追加すると、そのマスターに基づくすべてのスライドに画像が表示されます。 

以下の C# サンプルコードは、スライドマスターに画像を追加する方法を示しています：

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

## **スライドの背景として画像を追加する**

1 つまたは複数のスライドの背景として画像を使用できます。詳細については、*[Setting Images as Backgrounds for Slides](/slides/ja/net/presentation-background/#setting-images-as-background-for-slides)* を参照してください。 

## **プレゼンテーションに SVG を追加する**

SVG コンテンツは [SvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/svgimage/) クラスを使用してプレゼンテーションに追加できます。生成された [ISvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/) オブジェクトは、プレゼンテーションの画像コレクションに追加でき、画像枠として使用できます。 

以下の C# 例は、自己完結型 SVG 文字列をインポートします。この SVG に使用されているすべての画像、スタイル、その他のリソースは SVG コンテンツ内に直接埋め込まれています。 

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

デザインツール、ダイアグラムエディタ、アイコンシステム、Web パイプラインなどからエクスポートされた SVG ファイルは、SVG ドキュメントの外部に保存されたリソースを参照することがあります。たとえば、`images/photo.png` のような画像リンク、CSS の `url(...)` 値、フォント URL などです。 

このような SVG コンテンツをインポートするには、[IExternalResourceResolver](https://reference.aspose.com/slides/ja/net/aspose.slides.import/iexternalresourceresolver/) 実装を作成し、ベース URI とともに適切な `SvgImage` コンストラクタに渡します。ベース URI は SVG ドキュメントの場所を示し、相対リンクの解決に使用されます。 

[ISvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/) インターフェイスは、インポートされた SVG に関する情報へのアクセスを提供します：

- `SvgContent` は SVG のマークアップを文字列として返します。 
- `SvgData` は SVG コンテンツをバイト配列として返します。 
- `BaseUri` は相対リンクに使用されたベース URI を返します。 
- `ExternalResourceResolver` は SVG 画像に割り当てられたリゾルバを返します。 

### **外部リソースリゾルバの実装**

リゾルバには次の 2 つのメソッドがあります：

- [ResolveUri](https://reference.aspose.com/slides/ja/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) はベース URI と相対リソースリンクを結合し、絶対 URI を返します。解決できない、または許可されていないリンクの場合は `null` を返します。 
- [GetEntity](https://reference.aspose.com/slides/ja/net/aspose.slides.import/iexternalresourceresolver/getentity/) は絶対リソース URI 用の読み取り可能なストリームを返します。リソースが不存在、ブロック、または利用不可の場合は `null` を返します。必要に応じてフォールバックストリームを返すこともできます。 

以下のリゾルバは、許可されたローカルディレクトリからのみリンクされたリソースをロードします。ネットワーク リソースや許可ディレクトリ外のパスはブロックされ、解決できない画像リンクにはオプションのフォールバック画像が返されます。 

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

        // 画像リソースの場合のみフォールバックを使用します。画像ストリームを返す
        // 欠落したフォントやスタイルシートに対しては有効ではありません。
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

### **SVG インポート時にリンクされたリソースを解決する**

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

// ベース URI は SVG ドキュメントの場所を表します。
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage はソースコンテンツ、バイナリ データ、ベース URI、リゾルバを公開します。
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

`SvgImage` クラスは、バイト配列またはストリームとして SVG データを受け取るオーバーロードも提供しており、外部リソースリゾルバとベース URI を併せて指定できます。 

{{% alert title="Important" color="warning" %}}
リソースリゾルバは、Aspose.Slides が SVG を処理・描画する間に外部リソースを利用可能にしますが、元の SVG マークアップを変更したり、解決されたリソースを自動的に埋め込んだりはしません。 

`ISvgImage` がプレゼンテーションの画像コレクションに追加されると、PPTX ファイルには元の SVG 表現とラスター フォールバック画像の両方が含まれる可能性があります。リンクされたリソースは生成されたフォールバック画像に現れますが、`images/photo.png` のような相対リンクは保存された SVG 内ではそのまま残ります。ネイティブ SVG 表現をレンダリングするアプリケーションは、元の外部リソースが利用できない場合にリンクされたコンテンツを省略することがあります。 
{{% /alert %}}

### **ポータブル SVG 画像の作成**

外部ファイルに依存しない SVG 画像を作成するには、`SvgImage` を生成する前に SVG を自己完結型にします。たとえば、リンクされた画像 URL を画像データを含む `data:` URI に置き換えます： 

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

必要なすべてのリソースが SVG コンテンツに埋め込まれたら、`SvgImage` を作成し、プレゼンテーションの画像コレクションに追加し、前述の例と同様に画像枠に挿入します。 

### **不足またはブロックされたリソースの処理**

`ResolveUri` でリソース URI が無効、禁止、または解決不能な場合は `null` を返します。`GetEntity` でリソースを読み取れない場合も `null` を返します。可能な限りリソースなしで SVG の処理を続行します。 

不足したリソースに対してフォールバックストリームを返すことはできますが、その内容は要求されたリソースの種類と互換性がなければなりません。たとえば、画像が欠落している場合のみ画像ストリームを返し、フォントやスタイルシートに対しては返さないでください。 

{{% alert title="Security" color="warning" %}}
信頼できない SVG ファイルから任意のファイルパスや制限なしのネットワーク URL を解決しないでください。許可されるスキーム、ディレクトリ、ホストを限定し、ネットワークリソースの場合は接続タイムアウト、応答サイズ制限、コンテンツ検証も適用してください。 
{{% /alert %}}

## **SVG をシェイプのセットに変換する**
Aspose.Slides は、PowerPoint の同等機能と同様に、SVG をシェイプのセットに変換できます：


![PowerPoint Popup Menu](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection) インターフェイスの [AddGroupShape](https://reference.aspose.com/slides/ja/net/aspose.slides.ishapecollection/addgroupshape/methods/1) メソッドのオーバーロードで提供され、最初の引数として [ISvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage) オブジェクトを受け取ります。 

以下の C# サンプルコードは、このメソッドを使用して SVG ファイルをシェイプのセットに変換する方法を示しています：

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
    // SVG ファイルの内容を読み込む
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage オブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // スライドサイズを取得
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG 画像をシェイプのグループに変換し、スライドサイズに合わせてスケーリング
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // プレゼンテーションを PPTX 形式で保存
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **画像を EMF としてスライドに追加する**
Aspose.Slides for .NET は、Aspose.Cells と組み合わせて Excel ワークシートから EMF 画像を生成し、プレゼンテーション スライドに追加できます。 

以下の C# サンプルコードは、その手順を示しています：

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

## **画像コレクション内の画像を置換する**

Aspose.Slides は、プレゼンテーションの画像コレクションに格納された画像（スライド シェイプで使用されている画像を含む）を置換できます。このセクションでは、コレクション内の画像を更新するいくつかの方法を説明します。バイト データ、[IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置換できます。 

以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスを使用して、画像を含むプレゼンテーション ファイルを読み込みます。 
2. ファイルから新しい画像をバイト配列に読み込みます。 
3. バイト配列を使用して対象画像を新しい画像に置換します。 
4. 2 番目の方法では、画像を [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) オブジェクトに読み込み、そのオブジェクトで対象画像を置換します。 
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

// 2番目の方法。
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// 3番目の方法。
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// プレゼンテーションをファイルに保存します。
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
Aspose の無料 [Text to GIF](https://products.aspose.app/slides/ja/text-to-gif) コンバータを使用すれば、テキストを簡単にアニメ化し、GIF に変換できます。 
{{% /alert %}}

## **FAQ**

**挿入後も元の画像解像度はそのまま保持されますか？**

はい。ソースピクセルは保持されますが、最終的な表示はスライド上での [picture](/slides/ja/net/picture-frame/) のスケーリング方法や保存時の圧縮設定に依存します。 

**多数のスライドで同じロゴを一度に置換する最良の方法は何ですか？**

ロゴをマスター スライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置換すれば、該当リソースを使用しているすべての要素に自動的に反映されます。 

**挿入した SVG を編集可能なシェイプに変換できますか？**

はい。SVG をシェイプのグループに変換でき、個々のパーツは標準のシェイプ プロパティで編集可能になります。 

**複数のスライドに一括で画像を背景として設定するにはどうすればよいですか？**

マスター スライドまたは該当レイアウトで画像を背景として割り当てれば、そのマスター/レイアウトを使用しているすべてのスライドが背景を継承します。 

**多くの画像が原因でプレゼンテーションが大きくなりすぎるのを防ぐには？**

画像の重複を避けて単一リソースを再利用し、解像度は適切に設定し、保存時に圧縮を適用し、必要に応じてマスターで共通グラフィックを保持してください。