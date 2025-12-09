---
title: モダンAPIで画像処理を強化する
linktitle: モダンAPI
type: docs
weight: 237
url: /ja/net/modern-api/
keywords:
- System.Drawing
- モダンAPI
- 描画
- スライドサムネイル
- スライドを画像へ変換
- シェイプサムネイル
- シェイプを画像へ変換
- プレゼンテーションサムネイル
- プレゼンテーションを画像へ変換
- 画像を追加
- 画像を追加
- .NET
- C#
- Aspose.Slides
description: "非推奨の画像処理 API を .NET モダン API に置き換えて、PowerPoint と OpenDocument の自動化をシームレスに行えるように、スライド画像処理を最新化します。"
---

## **概要**

Historically, Aspose Slides は System.Drawing に依存しており、公開 API には以下のクラスが含まれています:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

バージョン 24.4 以降、この公開 API は非推奨と宣言されています。

.NET6 以降のバージョンで非 Windows 環境向けに System.Drawing のサポートが削除されたため（[破壊的変更](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)）、Slides は 2 つのライブラリ バージョン アプローチを実装しました:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – Windows 用 .NET6+、Windows/Linux/MacOS 用 .NETStandard、Windows 用 .NETFramework 2+ をサポートします。  
  - [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) に依存します。
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – 依存関係のない Windows/Linux/MacOS 用バージョンです。

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) の不便な点は、同じ名前空間に独自の System.Drawing 実装を持ち、公開 API との下位互換性をサポートしていることです。そのため、Aspose.Slides.NET6.CrossPlatform と .NETFramework からの System.Drawing、または System.Drawing.Common パッケージを同時に使用すると、エイリアスを使用しない限り名前の衝突が発生します。

メインの Aspose.Slides.NET パッケージで System.Drawing への依存をなくすために、いわゆる「Modern API」を追加しました。これは、非推奨とされた API の代わりに使用すべき API で、署名に System.Drawing の Image と Bitmap が含まれています。PrinterSettings と Graphics は非推奨とされ、公開 Slides API からのサポートは削除されました。

System.Drawing への依存を持つ非推奨の公開 API の削除はバージョン 24.8 で行われます。

## **Modern API**

公開 API に以下のクラスと列挙型を追加しました:

- Aspose.Slides.IImage – ラスタまたはベクタ画像を表します。
- Aspose.Slides.ImageFormat – 画像のファイル形式を表します。
- Aspose.Slides.Images – IImage インターフェイスの生成と操作用メソッド。

IImage は IDisposable を実装しているため、`using` 文でラップするか、適切な方法で破棄してください。

新しい API の典型的な使用シナリオは以下のようになります:
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // ディスク上のファイルから IImage の破棄可能なインスタンスを作成します。
    using (IImage image = Images.FromFile("image.png"))
    {
        // IImage のインスタンスをプレゼンテーションの画像コレクションに追加して PowerPoint 画像を作成します。
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


## **古いコードを Modern API に置き換える**

移行を容易にするため、IImage のインターフェイスは Image と Bitmap クラスの個別シグネチャを繰り返しています。基本的には、System.Drawing を使用した古いメソッド呼び出しを新しいものに置き換えるだけです。

### **スライド サムネイルの取得**

非推奨 API を使用したコード:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```


Modern API:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```


### **シェイプ サムネイルの取得**

非推奨 API を使用したコード:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```


Modern API:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```


### **プレゼンテーション サムネイルの取得**

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


Modern API:
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


Modern API:
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


## **削除されるメソッド/プロパティと Modern API における置換**

### **Presentation**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|--------------------|------------------------|
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
| メソッド シグネチャ | 置換メソッド シグネチャ |
|--------------------|------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|--------------------|------------------------|
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
| メソッド シグネチャ | 置換メソッド シグネチャ |
|--------------------|------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|--------------------|------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|--------------------|------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| メソッド/プロパティ シグネチャ | 置換メソッド シグネチャ |
|------------------------------|------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|--------------------|------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|--------------------|------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Graphics と PrinterSettings の API サポートは終了します**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) クラスは .NET6 以降のクロスプラットフォーム バージョンではサポートされません。Aspose Slides では、これを使用する API 部分が削除されます:
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

# **FAQ**

**なぜ System.Drawing.Graphics が削除されたのですか？**

`Graphics` のサポートは、レンダリングと画像処理を統一し、プラットフォーム固有の依存関係を排除し、[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) によるクロスプラットフォーム アプローチへ移行するために、公開 API から削除されています。`Graphics` へのすべてのレンダリング メソッドが削除されます。

**IImage は Image/Bitmap と比べて実務的にどんなメリットがありますか？**

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) はラスタとベクタの両方の画像を統一的に扱い、[ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) を通じた様々なフォーマットへの保存を簡素化し、`System.Drawing` への依存を減らすことで、環境間でのコード移植性を向上させます。

**Modern API はサムネイル生成のパフォーマンスに影響しますか？**

`GetThumbnail` から `GetImage` への切り替えでパフォーマンスが低下することはありません。新しいメソッドはオプションやサイズ指定を保持しつつ同等の機能を提供します。実際の性能はシナリオ次第ですが、機能的には同等です。