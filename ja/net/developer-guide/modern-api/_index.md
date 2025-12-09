---
title: モダン API で画像処理を強化
linktitle: モダン API
type: docs
weight: 237
url: /ja/net/modern-api/
keywords:
- System.Drawing
- モダン API
- 描画
- スライドサムネイル
- スライドから画像へ
- シェイプサムネイル
- シェイプから画像へ
- プレゼンテーションサムネイル
- プレゼンテーションから画像へ
- 画像を追加
- 画像を追加
- .NET
- C#
- Aspose.Slides
description: "レガシーな画像 API を .NET モダン API に置き換えて、スライド画像処理を最新化し、PowerPoint および OpenDocument の自動化をシームレスに実現します。"
---

## **はじめに**

歴史的に、Aspose Slides は System.Drawing に依存しており、公開 API には以下のクラスが含まれています:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

バージョン 24.4 以降、この公開 API は非推奨と宣言されています。

.NET6 以降のバージョンで非 Windows 環境向けに System.Drawing のサポートが削除されたため（[breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)）、Slides は 2 つのライブラリ バージョン アプローチを実装しました:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – Windows 用 .NET6+、Windows/Linux/MacOS 用 .NETStandard、Windows 用 .NETFramework 2+ をサポート。  
  - [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) に依存しています。
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – 依存関係なしの Windows/Linux/MacOS 用バージョン。

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) の不便な点は、同じ名前空間に System.Drawing の独自バージョンを実装していることです（公開 API の下位互換性をサポートするため）。そのため、Aspose.Slides.NET6.CrossPlatform と .NETFramework の System.Drawing、または System.Drawing.Common パッケージを同時に使用すると、エイリアスを使用しない限り名前衝突が発生します。

メインの Aspose.Slides.NET パッケージから System.Drawing への依存をなくすために、いわゆる「モダン API」を追加しました。つまり、非推奨 API の代わりに使用すべき API で、シグネチャに System.Drawing の Image および Bitmap 型への依存が含まれています。PrinterSettings と Graphics は非推奨と宣言され、公開 Slides API からのサポートは削除されました。

System.Drawing への依存を持つ非推奨の公開 API の削除は、リリース 24.8 で行われます。

## **モダン API**

公開 API に次のクラスと列挙型を追加しました:

- Aspose.Slides.IImage – ラスタまたはベクタ画像を表します。
- Aspose.Slides.ImageFormat – 画像のファイル形式を表します。
- Aspose.Slides.Images – IImage インターフェイスを生成して操作するためのメソッド。

IImage は破棄可能であることに注意してください（IDisposable を実装しており、using ステートメントでラップするか、別の適切な方法で破棄する必要があります）。

新しい API の典型的な使用シナリオは次のようになります:
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // ディスク上のファイルから IImage の破棄可能なインスタンスを生成します。
    using (IImage image = Images.FromFile("image.png"))
    {
        // IImage のインスタンスをプレゼンテーションの画像に追加して PowerPoint 画像を作成します。
        ppImage = pres.Images.AddImage(image);
    }

    // スライド #1 に画像シェイプを追加します
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

移行を容易にするために、新しい IImage のインターフェイスは Image と Bitmap クラスの個別シグネチャを繰り返しています。一般的には、System.Drawing を使用している古いメソッド呼び出しを新しいものに置き換えるだけです。

### **スライドのサムネイル取得**

非推奨 API を使用したコード:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```


モダン API:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```


### **シェイプのサムネイル取得**

非推奨 API を使用したコード:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```


モダン API:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```


### **プレゼンテーションのサムネイル取得**

非推奨 API を使用したコード:
``` csharp
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


モダン API:
``` csharp
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

非推奨 API を使用したコード:
``` csharp
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


モダン API:
``` csharp
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


## **削除されるメソッド/プロパティとモダン API での置換**

### **Presentation**
| メソッド署名 | 置換メソッド署名 |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | 完全に削除されます |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | 完全に削除されます |
| public void Print() | 完全に削除されます |
| public void Print(PrinterSettings printerSettings) | 完全に削除されます |
| public void Print(string printerName) | 完全に削除されます |
| public void Print(PrinterSettings printerSettings, string presName) | 完全に削除されます |

### **Shape**
| メソッド署名 | 置換メソッド署名 |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| メソッド署名 | 置換メソッド署名 |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | 完全に削除されます |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | 完全に削除されます |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | 完全に削除されます |

### **Output**
| メソッド署名 | 置換メソッド署名 |
|-----------------------------------------------|---------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| メソッド署名 | 置換メソッド署名 |
|-----------------------------------------------|---------------------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| メソッド署名 | 置換メソッド署名 |
|-----------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| メソッド/プロパティ署名 | 置換メソッド署名 |
|-----------------------------------------------|---------------------------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| メソッド署名 | 置換メソッド署名 |
|-----------------------------------------------|---------------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| メソッド署名 | 置換メソッド署名 |
|-----------------------------------------------|---------------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Graphics と PrinterSettings の API サポートは終了します**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) クラスは .NET6 以上のクロスプラットフォーム バージョンではサポートされません。Aspose Slides では、これを使用している API 部分が削除されます:
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

また、印刷に関連する API 部分も削除されます:

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

# **よくある質問**

**なぜ System.Drawing.Graphics が削除されたのですか？**

`Graphics` のサポートは、レンダリングと画像処理を統一し、プラットフォーム固有の依存関係を排除し、[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) によるクロスプラットフォーム アプローチへ切り替えるために、公開 API から削除されます。`Graphics` へのすべてのレンダリング メソッドが削除されます。

**IImage は Image/Bitmap と比べて実際にどのような利点がありますか？**

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) はラスタとベクタの両方の画像操作を統一し、[ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) を介したさまざまな形式への保存を簡素化し、`System.Drawing` への依存を減らし、環境間でのコードの移植性を高めます。

**モダン API はサムネイル生成のパフォーマンスに影響しますか？**

`GetThumbnail` から `GetImage` への切り替えは、シナリオを劣化させません。新しいメソッドはオプションやサイズ指定で画像を生成する同等の機能を提供し、レンダリング オプションも引き続きサポートします。具体的な性能向上または低下はシナリオ次第ですが、機能的には同等です。