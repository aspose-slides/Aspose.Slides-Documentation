---
title: モダンAPI
type: docs
weight: 237
url: /ja/net/modern-api/
keywords: "クロスプラットフォーム モダンAPI System.Drawing"
description: "モダンAPI"
---

## はじめに

これまで、Aspose SlidesはSystem.Drawingに依存しており、公開APIには以下のクラスが含まれています：
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

バージョン24.4から、この公開APIは非推奨と宣言されました。

System.Drawingのサポートは、.NET6以降の非Windowsバージョンでは削除されました（[破壊的変更](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)）。したがって、Slidesは2つのライブラリバージョンアプローチを実施しました：
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - Windows向けの.NET6+サポート、Windows/Linux/MacOS向けの.NETStandard、.NETFramework 2+ (Windows)。
  - [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/)に依存しています。
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - 依存関係のないWindows/Linux/MacOSバージョン。

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)の不便さは、同じ名前空間で独自のSystem.Drawingのバージョンを実装していることです（公開APIとの後方互換性をサポートするため）。したがって、Aspose.Slides.NET6.CrossPlatformと.NETFrameworkまたはSystem.Drawing.CommonパッケージのSystem.Drawingを同時に使用する場合、エイリアスを使用しない限り、名前の衝突が発生します。

Aspose.Slides.NETのメインパッケージにおけるSystem.Drawingへの依存関係を排除するために、いわゆる「モダンAPI」を追加しました。これは、以下のSystem.Drawingからの型：ImageおよびBitmapに対する依存関係を含む非推奨のAPIの代わりに使用するAPIです。PrinterSettingsとGraphicsは非推奨として宣言され、そのサポートは公開Slides APIから削除されました。

System.Drawingへの依存関係を持つ非推奨の公開APIは、リリース24.8で削除される予定です。

## モダンAPI

以下のクラスと列挙型が公開APIに追加されました：

- Aspose.Slides.IImage - ラスタまたはベクトル画像を表します。
- Aspose.Slides.ImageFormat - 画像のファイル形式を表します。
- Aspose.Slides.Images - IImageインターフェースのインスタンス化および操作に使用されるメソッド。

IImageは破棄可能であることに注意してください（IDisposableインターフェースを実装しており、その使用はusingでラップするか、他の便利な方法で破棄する必要があります）。

新しいAPIの使用の典型的なシナリオは次のようになります：

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // ディスク上のファイルからIImageの破棄可能なインスタンスをインスタンス化。
    using (IImage image = Images.FromFile("image.png"))
    {
        // IImageのインスタンスをプレゼンテーションの画像に追加してPowerPoint画像を作成。
        ppImage = pres.Images.AddImage(image);
    }

    // スライド#1に画像シェイプを追加
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // スライド#1を表すIImageのインスタンスを取得。
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // ディスクに画像を保存。
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## 古いコードをモダンAPIに置き換える

移行を容易にするために、新しいIImageのインターフェースはImageおよびBitmapクラスの個別のシグニチャを繰り返します。一般的に、System.Drawingを使用した古いメソッドの呼び出しを新しいメソッドに置き換えるだけで済みます。

### スライドのサムネイルを取得

非推奨APIを使用したコード：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

モダンAPI：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### シェイプのサムネイルを取得

非推奨APIを使用したコード：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

モダンAPI：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### プレゼンテーションのサムネイルを取得

非推奨APIを使用したコード：

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

モダンAPI：

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

### プレゼンテーションに画像を追加

非推奨APIを使用したコード：

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

モダンAPI：

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
## 取り除かれるメソッド/プロパティとモダンAPIでの置き換え

### プレゼンテーション
| メソッドシグネチャ                               | 置き換えメソッドシグネチャ                             |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages)                   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1)   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | 完全に削除される予定 |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | 完全に削除される予定 |
| public void Print()                           | 完全に削除される予定                               |
| public void Print(PrinterSettings printerSettings) | 完全に削除される予定                            |
| public void Print(string printerName)         | 完全に削除される予定                               |
| public void Print(PrinterSettings printerSettings, string presName) | 完全に削除される予定                          |

### シェイプ
| メソッドシグネチャ                                                      | 置き換えメソッドシグネチャ                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail()                                          | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage)                                                           |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### スライド
| メソッドシグネチャ                                                      | 置き換えメソッドシグネチャ                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY)                | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5)                                 |
| public Bitmap GetThumbnail()                                         | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage)                                                              |
| public Bitmap GetThumbnail(IRenderingOptions options)                | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1)                                  |
| public Bitmap GetThumbnail(Size imageSize)                           | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6)                                             |
| public Bitmap GetThumbnail(ITiffOptions options)                    | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4)                                      |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3)               |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | 完全に削除される予定                                       |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | 完全に削除される予定                             |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | 完全に削除される予定                                    |

#### 出力
| メソッドシグネチャ                                                | 置き換えメソッドシグネチャ                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image)               | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1)                               |

### ImageCollection
| メソッドシグネチャ                          | 置き換えメソッドシグネチャ               |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image)           | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage)                      |

### ImageWrapperFactory
| メソッドシグネチャ                                         | 置き換えメソッドシグネチャ                            |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image)           | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper)                        |

### PPImage
| メソッド/プロパティシグネチャ                     | 置き換えメソッドシグネチャ   |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage)   | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage)            |
| Image SystemImage { get; }          | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image)                    |

### PatternFormat
| メソッドシグネチャ                                          | 置き換えメソッドシグネチャ                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1)         |
| Bitmap GetTileImage(Color styleColor)                     | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile)                           |

### IPatternFormatEffectiveData
| メソッドシグネチャ                                          | 置き換えメソッドシグネチャ                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage)                    |

## Aspose.Slides.NET6.CrossPlatformのサポートは終了します

[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET)バージョン24.8のリリースに続いて、[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)のサポートは終了する予定です。

## GraphicsおよびPrinterSettingsのAPIサポートは終了します

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)クラスは、.NET6以降のクロスプラットフォームバージョンではサポートされていません。Aspose Slidesでは、それを使用するAPIの一部が削除されます：
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

また、印刷に関連するAPIの一部も削除されます：

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)