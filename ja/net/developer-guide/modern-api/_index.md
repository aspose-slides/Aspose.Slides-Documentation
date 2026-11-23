---
title: Modern APIで画像処理を強化
linktitle: モダン API
type: docs
weight: 234
url: /ja/net/modern-api/
keywords:
- System.Drawing
- モダン API
- 描画
- スライドサムネイル
- スライド → 画像
- シェイプサムネイル
- シェイプ → 画像
- プレゼンテーションサムネイル
- プレゼンテーション → 画像
- 画像を追加
- 画像を挿入
- .NET
- C#
- Aspose.Slides
description: "非推奨の画像 API を .NET モダン API に置き換えて、スライド画像処理を最新化し、PowerPoint および OpenDocument のシームレスな自動化を実現します。"
---
## **概要**

これまで、Aspose Slides は System.Drawing に依存しており、公開 API には以下のクラスが含まれていました。
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

バージョン 24.4 以降、この公開 API は非推奨と宣言されています。

バージョン .NET6 以降の非 Windows 環境では System.Drawing のサポートが削除されたため（[breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)）、Slides は 2 つのパッケージ方式を実装しました。
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - Windows 用 .NET6+、Windows/Linux/MacOS 用 .NETStandard、Windows 用 .NETFramework 2+ をサポート。
  - [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) に依存しています。
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - 依存関係のない Windows/Linux/MacOS 用バージョン。

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) が独自の System.Drawing 実装を同一名前空間に提供しているため、.NET Framework の System.Drawing または System.Drawing.Common パッケージと同時に使用すると、エイリアスを使用しない限り名前衝突が発生します。

メインの Aspose.Slides.NET パッケージから System.Drawing への依存を排除するため、いわゆる「モダン API」を追加しました。これは、非推奨となった API の代わりに使用すべき API で、シグネチャに System.Drawing の以下の型への依存が含まれています: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) と [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)。[PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) と [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) は非推奨と宣言され、公開 Slides API からはサポートが削除されました。

現在のバージョンでは、System.Drawing に依存する公開 API をレガシー/非推奨として扱い、 新規コードや既存の画像処理ワークフローの移行時にはモダン API を使用してください。

## **モダン API**

公開 API に以下のクラスと列挙型を追加しました。

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) – ラスタ画像またはベクター画像を表します。
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) – 画像のファイル形式を表します。
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) – [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) インターフェイスを生成・操作するメソッドを提供します。

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) は破棄可能であることに注意してください（[IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) インターフェイスを実装しており、`using` でラップするか他の適切な方法で破棄する必要があります）。

`GetImage` を使用して単一のスライドまたはシェイプをレンダリングします。`GetImages` を使用して複数のプレゼンテーションスライドをレンダリングします。[Images](https://reference.aspose.com/slides/net/aspose.slides/images/) のメソッドで画像を読み込み、`AddImage` と [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) でプレゼンテーションに画像を追加し、`ReplaceImage` と [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) で既存のプレゼンテーション画像を更新します。

新しい API の典型的な使用シナリオは次のようになります。

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // ディスク上のファイルから IImage の破棄可能なインスタンスを作成します。  
    using (IImage image = Images.FromFile("image.png"))
    {
        // IImage のインスタンスをプレゼンテーションの画像コレクションに追加して PowerPoint 画像を作成します。
        ppImage = pres.Images.AddImage(image);
    }

    // スライド #1 に画像シェイプを追加します。
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // スライド #1 を表す IImage のインスタンスを取得します。
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // 画像をディスクに保存します。
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **古いコードをモダン API に置き換える**

移行を容易にするため、新しい [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) のインターフェイスは、[Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) と [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) クラスの個別シグネチャをそのまま繰り返しています。基本的には、System.Drawing を使用した従来のメソッド呼び出しを新しいものに置き換えるだけです。

### **スライドサムネイルの取得**

Legacy/deprecated API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Modern API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **シェイプサムネイルの取得**

Legacy/deprecated API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Modern API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **プレゼンテーションサムネイルの取得**

Legacy/deprecated API:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    var bitmaps = pres.GetThumbnails(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < bitmaps.Length; index++)
        {
            Bitmap thumbnail = bitmaps[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (Bitmap bitmap in bitmaps)
        {
            bitmap.Dispose();
        }
    }
}
```

Modern API:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    var images = pres.GetImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < images.Length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (IImage image in images)
        {
            image.Dispose();
        }
    }
}
```

### **プレゼンテーションへの画像追加**

Legacy/deprecated API:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image image = Image.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

Modern API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (IImage image = Aspose.Slides.Images.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

## **非推奨メソッド/プロパティとモダン API における置換**

### **Presentation**
| メソッド シグネチャ                               | 置換メソッド シグネチャ                             |
|-----------------------------------------------|---------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print()                           | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName)         | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| メソッド シグネチャ                                                      | 置換メソッド シグネチャ                                       |
|----------------------------------------------------------------------|-----------------------------------------------------------|
| public Bitmap GetThumbnail()                                          | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| メソッド シグネチャ                                                      | 置換メソッド シグネチャ                                           |
|----------------------------------------------------------------------|---------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY)                | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail()                                         | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options)                | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize)                           | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options)                    | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| メソッド シグネチャ                                                | 置換メソッド シグネチャ                                |
|-------------------------------------------------------------|-----------------------------------------------------|
| public IOutputFile Add(string path, Image image)               | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| メソッド シグネチャ                          | 置換メソッド シグネチャ               |
|-------------------------------------------|------------------------------------|
| IPPImage AddImage(Image image)           | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| メソッド シグネチャ                                         | 置換メソッド シグネチャ                            |
|----------------------------------------------------------|-----------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image)           | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| メソッド/プロパティ シグネチャ                     | 置換メソッド シグネチャ   |
|--------------------------------------|---------------------------|
| void ReplaceImage(Image newImage)   | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; }          | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| メソッド シグネチャ                                          | 置換メソッド シグネチャ                        |
|-----------------------------------------------------------|-------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor)                     | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| メソッド シグネチャ                                          | 置換メソッド シグネチャ                        |
|-----------------------------------------------------------|-------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Graphics と PrinterSettings の API サポート**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) クラスは .NET6 以降のクロスプラットフォーム バージョンではサポートされていません。Aspose Slides では、[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) へ描画する API の代わりに、モダン API の画像レンダリングメソッドを使用してください：
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

また、[PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) に関連する印刷 API には直接的なモダン API 置換はありません：

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **よくある質問**

### なぜ [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) が削除されたのですか？

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) のサポートは、レンダリングと画像の取り扱いを統一し、プラットフォーム固有の依存関係を排除し、[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) に基づくクロスプラットフォーム アプローチに切り替えるために、公開 API で非推奨となりました。`GetImage` または `GetImages` を使用し、[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) への描画は行わないでください。

### [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) は [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) に比べて実務上どのようなメリットがありますか？

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) はラスタ画像とベクター画像の両方を統一的に扱えるようにし、[ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) を介した様々な形式への保存を簡素化し、`System.Drawing` への依存を削減することで、環境間のコード移植性を向上させます。

### モダン API に変更するとサムネイル生成のパフォーマンスに影響がありますか？

`GetThumbnail` から `GetImage` への置換で性能が劣化することはありません。新しいメソッドはオプションやサイズ指定による画像生成能力が同等であり、シナリオに応じた性能差はケースバイケースですが、機能的には同等です。