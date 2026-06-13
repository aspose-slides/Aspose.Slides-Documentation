---
title: 현대 API로 이미지 처리 향상
linktitle: 모던 API
type: docs
weight: 237
url: /ko/net/modern-api/
keywords:
- System.Drawing
- 모던 API
- 그리기
- 슬라이드 썸네일
- 슬라이드 이미지 변환
- 도형 썸네일
- 도형 이미지 변환
- 프레젠테이션 썸네일
- 프레젠테이션 이미지 변환
- 이미지 추가
- 그림 추가
- .NET
- C#
- Aspose.Slides
description: ".NET 모던 API로 사용 중단된 이미지 처리 API를 교체하여 슬라이드 이미지 처리를 현대화하고, PowerPoint 및 OpenDocument 자동화를 원활하게 수행합니다."
---
## **소개**

역사적으로 Aspose Slides는 System.Drawing에 대한 종속성이 있었으며 공개 API에 다음 클래스들이 포함되어 있습니다:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

버전 24.4부터 이 공개 API는 사용 중단(deprecated)으로 선언되었습니다.

.NET6 이상 버전에서 비 Windows 플랫폼에 대한 System.Drawing 지원이 제거되면서([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides는 두 개의 패키지 접근 방식을 구현했습니다:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - Windows 용 .NET6+, Windows/Linux/MacOS 용 .NETStandard, Windows 용 .NETFramework 2+ 지원.
  - [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/)에 의존합니다.
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - 종속성이 없는 Windows/Linux/MacOS 버전.

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)의 불편함은 기존 API와의 하위 호환성을 위해 동일한 네임스페이스에 자체 System.Drawing 구현을 포함한다는 점입니다. 따라서 Aspose.Slides.NET6.CrossPlatform과 .NET Framework의 System.Drawing 또는 System.Drawing.Common 패키지를 동시에 사용할 경우 별칭을 사용하지 않으면 이름 충돌이 발생합니다.

주요 Aspose.Slides.NET 패키지에서 System.Drawing에 대한 종속성을 없애기 위해, 이른바 "Modern API"를 추가했습니다. 즉, 사용 중단된 API 대신에 사용해야 하는 API이며, 이 API의 시그니처는 System.Drawing의 다음 형식들인 [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)과 [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)에 대한 종속성을 포함합니다. [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)와 [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)는 사용 중단으로 선언되었으며 공개 Slides API에서 지원이 제거되었습니다.

현재 버전에서는 System.Drawing에 의존하는 공개 API를 레거시/사용 중단으로 간주하고, 새로운 코드와 기존 이미지 처리 워크플로를 마이그레이션할 때 Modern API를 사용하십시오.

## **모던 API**

공개 API에 다음 클래스와 열거형을 추가했습니다:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) - 래스터 또는 벡터 이미지를 나타냅니다.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/imageformat/) - 이미지 파일 형식을 나타냅니다.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/ko/net/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 인터페이스를 인스턴스화하고 작업하는 메서드들.

[IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/)은 disposable이며([IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) 인터페이스를 구현) 사용 시 `using` 구문으로 감싸거나 다른 편리한 방법으로 해제해야 함을 유의하십시오.

단일 슬라이드 또는 도형을 렌더링하려면 `GetImage`를 사용하고, 여러 프레젠테이션 슬라이드를 렌더링하려면 `GetImages`를 사용하십시오. 이미지를 로드하려면 [Images](https://reference.aspose.com/slides/ko/net/aspose.slides/images/) 메서드를 사용하고, 프레젠테이션에 이미지를 추가하려면 `AddImage`와 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/)를, 기존 프레젠테이션 이미지를 업데이트하려면 `ReplaceImage`와 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/)를 사용합니다.

새 API를 사용하는 전형적인 시나리오는 다음과 같을 수 있습니다:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // 디스크에 있는 파일에서 IImage의 disposable 인스턴스를 생성합니다.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // 프레젠테이션의 이미지 컬렉션에 IImage 인스턴스를 추가하여 PowerPoint 이미지를 생성합니다.
        ppImage = pres.Images.AddImage(image);
    }

    // 슬라이드 #1에 그림 모양을 추가합니다.
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // 슬라이드 #1을 나타내는 IImage 인스턴스를 가져옵니다.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // 이미지를 디스크에 저장합니다.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **레거시 코드를 모던 API로 교체하기**

전환을 용이하게 하기 위해, 새로운 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 인터페이스는 [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)와 [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) 클래스의 별도 시그니처를 반복합니다. 일반적으로 System.Drawing을 사용하던 기존 메서드 호출을 새로운 메서드로 교체하면 됩니다.

### **슬라이드 썸네일 가져오기**

레거시/사용 중단 API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

모던 API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **도형 썸네일 가져오기**

레거시/사용 중단 API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

모던 API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **프레젠테이션 썸네일 가져오기**

레거시/사용 중단 API:

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

모던 API:

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

### **프레젠테이션에 그림 추가하기**

레거시/사용 중단 API:

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

모던 API:

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

## **사용 중단된 메서드/속성 및 모던 API에서의 대체**

### **Presentation**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/ko/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|---------------------------|-----------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/ko/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|-----------------------------------------------|----------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/ko/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| 메서드/속성 시그니처 | 대체 메서드 시그니처 |
|----------------------------|------------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/ko/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/ko/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|-----------------------------------------------------------|---------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/ko/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/ko/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| 메서드 시그니처 | 대체 메서드 시그니처 |
|-----------------------------------------------------------|---------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/ko/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Graphics 및 PrinterSettings 지원에 대한 API**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 클래스는 .NET6 이상 크로스 플랫폼 버전에서는 지원되지 않습니다. Aspose Slides에서는 [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)로 렌더링하는 API 대신 Modern API 이미지 렌더링 메서드를 사용하십시오:
[ISlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/rendertographics/#rendertographics_5)

또한 [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)와 관련된 API는 직접적인 Modern API 대체가 없습니다:

[IPresentation](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

**왜 [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)가 제외되었나요?**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)에 대한 지원은 렌더링 및 이미지 작업을 통합하고, 플랫폼 종속성을 없애며, [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/)를 사용한 크로스 플랫폼 접근 방식으로 전환하기 위해 공개 API에서 사용 중단되었습니다. [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 대신 `GetImage` 또는 `GetImages`를 사용하십시오.

**[IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/)가 [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)보다 실용적인 장점은 무엇인가요?**

[IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/)은 래스터와 벡터 이미지를 모두 동일하게 다루며, [ImageFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/imageformat/)을 통한 다양한 형식 저장을 간소화하고, `System.Drawing`에 대한 의존성을 감소시켜 환경 간 코드 이식성을 높입니다.

**모던 API로 전환하면 썸네일 생성 성능에 영향을 미칠까요?**

`GetThumbnail`에서 `GetImage`로 전환해도 성능이 저하되지 않습니다. 새 메서드는 옵션 및 크기 지정 기능을 동일하게 제공하므로 시나리오에 따라 얻을 수 있는 이득이나 손실은 다를 수 있지만, 기능적으로는 동등합니다.