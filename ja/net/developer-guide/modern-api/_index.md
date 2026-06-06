---
title: モダン API で画像処理を強化する
linktitle: モダン API
type: docs
weight: 237
url: /ja/net/modern-api/
keywords:
- System.Drawing
- モダン API
- 描画
- スライド サムネイル
- スライドから画像へ
- シェイプ サムネイル
- シェイプから画像へ
- プレゼンテーション サムネイル
- プレゼンテーションから画像へ
- 画像を追加
- ピクチャを追加
- .NET
- C#
- Aspose.Slides
description: "非推奨の画像 API を .NET モダン API に置き換えて、PowerPoint と OpenDocument の自動化をシームレスにすることで、スライド画像処理を近代化します。"
---
## **はじめに**

歴史的に、Aspose Slides は System.Drawing に依存しており、パブリック API で以下のクラスを使用していました。
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

バージョン 24.4 以降、これらのパブリック API は非推奨と宣言されています。

.NET6 以降のバージョンでの System.Drawing のサポートが Windows 以外の環境で削除されたため（[breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)）、Slides は 2 つのパッケージ方式を実装しました。
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – Windows 用 .NET6+、Windows/Linux/MacOS 用 .NETStandard、Windows 用 .NETFramework 2+ をサポート。  
  - [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) に依存しています。
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – 依存関係のない Windows/Linux/MacOS バージョン。

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) の不便な点は、同じ名前空間に独自の System.Drawing 実装を持ち、パブリック API との下位互換性を保っていることです。そのため、Aspose.Slides.NET6.CrossPlatform と .NET Framework の System.Drawing、または System.Drawing.Common パッケージを同時に使用すると、エイリアスを使用しない限り名前の衝突が発生します。

メインの Aspose.Slides.NET パッケージから System.Drawing への依存を排除するために、いわゆる「モダン API」を追加しました。つまり、非推奨となった API の代わりに使用すべき API で、シグネチャには System.Drawing の [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) と [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) に対する依存が含まれます。[PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) と [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) は非推奨と宣言され、パブリック Slides API からは削除されました。

現在のバージョンでは、System.Drawing に依存するパブリック API をレガシー/非推奨として扱います。新しいコードや既存の画像処理ワークフローの移行にはモダン API を使用してください。

## **モダン API**

パブリック API に以下のクラスと列挙型を追加しました。

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) – ラスターまたはベクター画像を表します。
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/imageformat/) – 画像のファイル形式を表します。
- [Aspose.Slides.Images](https://reference.aspose.com/slides/ja/net/aspose.slides/images/) – [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) インターフェイスをインスタンス化し操作するためのメソッド。

[IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) は disposable であり（[IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) インターフェイスを実装）、使用時は using ブロックでラップするか、適切な方法で破棄してください。

`GetImage` を使用して単一スライドまたはシェイプをレンダリングします。`GetImages` を使用して複数のプレゼンテーションスライドをレンダリングします。[Images](https://reference.aspose.com/slides/ja/net/aspose.slides/images/) のメソッドで画像を読み込み、`AddImage` に [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) を渡してプレゼンテーションに追加し、`ReplaceImage` に [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) を渡して既存の画像を更新します。

新しい API の典型的な使用シナリオは次のようになります。

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // ディスク上のファイルから IImage の破棄可能インスタンスを生成します。
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

## **旧コードをモダン API に置き換える**

移行を容易にするために、新しい [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) のインターフェイスは、[Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) と [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) クラスの個別シグネチャを繰り返しています。基本的には、System.Drawing を使用した旧メソッド呼び出しを新しいものに置き換えるだけです。

### **スライドのサムネイル取得**

レガシー/非推奨 API:

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

レガシー/非推奨 API:

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

レガシー/非推奨 API:

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

レガシー/非推奨 API:

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
## **非推奨メソッド/プロパティとモダン API における置換**

### **Presentation**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|----------------------|--------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|----------------------|--------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|----------------------|--------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|----------------------|--------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/ja/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|----------------------|--------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/ja/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|----------------------|--------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/ja/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| メソッド/プロパティ シグネチャ | 置換メソッド シグネチャ |
|------------------------------|--------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/ja/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/ja/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|----------------------|--------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/ja/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/ja/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| メソッド シグネチャ | 置換メソッド シグネチャ |
|----------------------|--------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/ja/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Graphics と PrinterSettings 用 API のサポート**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) クラスは .NET6 以降のクロスプラットフォーム バージョンではサポートされていません。Aspose Slides では、[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) へのレンダリング API の代わりにモダン API の画像レンダリングメソッドを使用してください。
[ISlide](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/rendertographics/#rendertographics_5)

また、[PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) を使用した印刷関連 API には直接的なモダン API の置換はありません。

[IPresentation](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

**なぜ [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) が廃止されたのですか？**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) のサポートは、レンダリングと画像処理を統一し、プラットフォーム固有の依存関係を排除し、[IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) を使用したクロスプラットフォーム アプローチに切り替えるために、パブリック API で非推奨となりました。`GetImage` または `GetImages` を使用して、[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) へのレンダリングを置き換えてください。

**[IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) は [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) / [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) と比べて実務上の利点は何ですか？**

[IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) はラスタとベクタの両方の画像を統一的に扱い、[ImageFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/imageformat/) を通じた多様な形式への保存を簡素化し、`System.Drawing` への依存を減らすことで、環境間でのコードの移植性を向上させます。

**モダン API に切り替えるとサムネイル生成のパフォーマンスに影響がありますか？**

`GetThumbnail` から `GetImage` への切り替えは、性能を悪化させることはありません。新しいメソッドはオプションやサイズ指定を伴う画像生成に同等の機能を提供します。具体的な性能向上または低下はシナリオに依存しますが、機能的には置換は等価です。