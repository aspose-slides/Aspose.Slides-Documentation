---
title: .NET에서 프레젠테이션의 그림 프레임 관리
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/net/picture-frame/
keywords:
- 그림 프레임
- 그림 프레임 추가
- 그림 프레임 만들기
- 이미지 추가
- 이미지 만들기
- 이미지 추출
- 래스터 이미지
- 벡터 이미지
- 이미지 자르기
- 잘린 영역
- StretchOff 속성
- 그림 프레임 서식 지정
- 그림 프레임 속성
- 상대적 스케일
- 이미지 효과
- 가로 세로 비율
- 이미지 투명도
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 그림 프레임을 추가합니다. 작업 흐름을 간소화하고 슬라이드 디자인을 향상시킵니다."
---
## **소개**

그림 프레임은 이미지를 포함하는 도형이며, 프레임 안의 그림과 같습니다.  

그림 프레임을 통해 슬라이드에 이미지를 추가할 수 있습니다. 이렇게 하면 그림 프레임을 서식 지정함으로써 이미지를 서식 지정할 수 있습니다.

{{% alert  title="Tip" color="info" %}} 
Aspose는 무료 컨버터—[JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 사용자가 이미지를 통해 빠르게 프레젠테이션을 만들 수 있도록 합니다. 
{{% /alert %}} 

## **그림 프레임 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 객체와 연결된 [IImagescollection](https://reference.aspose.com/slides/ko/net/aspose.slides/iimagecollection)에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage) 객체를 생성합니다.  
4. 이미지의 폭과 높이를 지정합니다.  
5. 참조된 슬라이드와 연결된 도형 객체가 제공하는 `AddPictureFrame` 메서드를 사용하여 이미지의 폭과 높이를 기반으로 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe)을 생성합니다.  
6. 슬라이드에 그림 프레임(그림을 포함)을 추가합니다.  
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다
    ISlide slide = pres.Slides[0];

    // 이미지를 로드하고 프레젠테이션 이미지 컬렉션에 추가합니다
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 같은 높이와 너비를 가진 그림 프레임을 추가합니다
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 그림 프레임에 일부 서식을 적용합니다
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // 프레젠테이션을 PPTX 파일로 저장합니다
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
그림 프레임을 사용하면 이미지를 기반으로 프레젠테이션 슬라이드를 빠르게 만들 수 있습니다. 그림 프레임을 Aspose.Slides 저장 옵션과 결합하면 입력/출력 작업을 조작하여 이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 다음 페이지를 참고하세요: 변환 [image to JPG](https://products.aspose.com/slides/ko/net/conversion/image-to-jpg/); 변환 [JPG to image](https://products.aspose.com/slides/ko/net/conversion/jpg-to-image/); 변환 [JPG to PNG](https://products.aspose.com/slides/ko/net/conversion/jpg-to-png/), 변환 [PNG to JPG](https://products.aspose.com/slides/ko/net/conversion/png-to-jpg/); 변환 [PNG to SVG](https://products.aspose.com/slides/ko/net/conversion/png-to-svg/), 변환 [SVG to PNG](https://products.aspose.com/slides/ko/net/conversion/svg-to-png/). 
{{% /alert %}}

## **비율 스케일이 적용된 그림 프레임 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 이미지 컬렉션에 이미지를 추가합니다.  
4. 프레젠테이션 객체와 연결된 [IImagescollection](https://reference.aspose.com/slides/ko/net/aspose.slides/iimagecollection)에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage) 객체를 생성합니다.  
5. 그림 프레임에서 이미지의 상대적인 폭과 높이를 지정합니다.  
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation())
{
    // 이미지를 로드하고 프레젠테이션 이미지 컬렉션에 추가합니다
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 슬라이드에 그림 프레임을 추가합니다
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 상대적 스케일 너비와 높이를 설정합니다
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // 프레젠테이션을 저장합니다
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **그림 프레임에서 래스터 이미지 추출**

[PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe) 객체에서 래스터 이미지를 추출하고 PNG, JPG 등 다양한 형식으로 저장할 수 있습니다. 아래 코드 예제는 문서 “sample.pptx”에서 이미지를 추출해 PNG 형식으로 저장하는 방법을 보여줍니다.  

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **그림 프레임에서 SVG 이미지 추출**

프레젠테이션에 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/) 도형 내부에 SVG 그래픽이 포함된 경우, Aspose.Slides for .NET은 원본 벡터 이미지를 완전한 정밀도로 가져올 수 있게 해줍니다. 슬라이드의 도형 컬렉션을 순회하면서 각 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/)을 확인하고, 해당 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)가 SVG 콘텐츠를 보유하고 있는지 확인한 뒤, 원본 SVG 형식으로 디스크나 스트림에 저장할 수 있습니다.  

다음 코드 예제는 그림 프레임에서 SVG 이미지를 추출하는 방법을 보여줍니다:  

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **이미지 투명도 가져오기**

Aspose.Slides를 사용하면 이미지에 적용된 투명도 효과를 가져올 수 있습니다. 아래 C# 코드는 해당 작업을 시연합니다.  

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **이미지 밝기 및 대비 가져오기**

Aspose.Slides를 사용하면 이미지에 적용된 밝기와 대비 효과를 가져올 수 있습니다. [ILuminance](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iluminance/) 인터페이스가 이러한 이미지 변환 효과를 나타냅니다.  

아래 C# 코드는 그림 프레임에서 밝기와 대비 설정을 가져오는 방법을 보여줍니다:  

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="info" %}} 
이미지에 적용된 모든 효과는 [Aspose.Slides.Effects](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/)에서 확인할 수 있습니다. 
{{% /alert %}}

## **그림 프레임 서식 지정**

Aspose.Slides는 그림 프레임에 적용할 수 있는 다양한 서식 옵션을 제공합니다. 이러한 옵션을 사용하면 특정 요구 사항에 맞게 그림 프레임을 조정할 수 있습니다.  

1. [Presentation](http://www.aspose.com/api/net/slides/ko/aspose.slides/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 객체와 연결된 [IImagescollection](https://reference.aspose.com/slides/ko/net/aspose.slides/iimagecollection)에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage) 객체를 생성합니다.  
4. 이미지의 폭과 높이를 지정합니다.  
5. [IShapes](http://www.aspose.com/api/net/slides/ko/aspose.slides/ishapecollection) 객체가 제공하는 [AddPictureFrame](http://www.aspose.com/api/net/slides/ko/aspose.slides/ishapecollection/methods/addpictureframe) 메서드를 사용해 이미지의 폭과 높이를 기반으로 `PictureFrame`을 생성합니다.  
6. 그림 프레임(그림을 포함)을 슬라이드에 추가합니다.  
7. 그림 프레임의 선 색을 설정합니다.  
8. 그림 프레임의 선 폭을 설정합니다.  
9. 양수 또는 음수 값을 지정해 그림 프레임을 회전합니다.  
   * 양수 값은 이미지를 시계 방향으로 회전시킵니다.  
   * 음수 값은 이미지를 반시계 방향으로 회전시킵니다.  
10. 그림 프레임(그림을 포함)을 슬라이드에 추가합니다.  
11. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다
    ISlide slide = presentation.Slides[0];

    // 이미지를 로드하고 프레젠테이션 이미지 컬렉션에 추가합니다
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 그림과 동일한 높이와 너비로 그림 프레임을 추가합니다
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 그림 프레임에 일부 서식을 적용합니다
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // 프레젠테이션을 PPTX 파일로 저장합니다
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 
Aspose는 최근에 무료 [Collage Maker](https://products.aspose.app/slides/ko/collage)를 출시했습니다. JPG/JPEG 또는 PNG 이미지를 [병합](https://products.aspose.app/slides/ko/collage/jpg)하거나, 사진으로 [그리드 만들기](https://products.aspose.app/slides/ko/collage/photo-grid)하고 싶을 때 이 서비스를 활용할 수 있습니다. 
{{% /alert %}}

## **링크로 이미지 추가**

프레젠테이션 파일 크기를 크게 줄이기 위해 이미지를 직접 삽입하는 대신 링크를 통해 이미지(또는 비디오)를 추가할 수 있습니다. 아래 C# 코드는 자리 표시자에 이미지와 비디오를 링크로 추가하는 방법을 보여줍니다.  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **이미지 자르기**

아래 C# 코드는 슬라이드에 있는 기존 이미지를 자르는 방법을 보여줍니다.  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // 새 이미지 객체를 생성합니다
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 슬라이드에 PictureFrame을 추가합니다
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // 이미지를 자릅니다 (백분율 값)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // 결과를 저장합니다
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **그림 프레임의 잘린 영역 삭제**

프레임에 포함된 이미지의 잘린 영역을 삭제하려면 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 메서드를 사용할 수 있습니다. 이 메서드는 잘린 이미지를 반환하거나, 자르기가 필요 없을 경우 원본 이미지를 반환합니다.  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 첫 번째 슬라이드에서 PictureFrame을 가져옵니다
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // PictureFrame 이미지의 잘린 영역을 삭제하고 잘린 이미지를 반환합니다
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // 결과를 저장합니다
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 메서드는 잘린 이미지를 프레젠테이션 이미지 컬렉션에 추가합니다. 해당 이미지가 처리된 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/)에만 사용된다면 프레젠테이션 크기를 줄일 수 있습니다. 그렇지 않으면 결과 프레젠테이션의 이미지 개수가 늘어납니다.  

이 메서드는 잘라내기 작업 중 WMF/EMF 메타파일을 래스터 PNG 이미지로 변환합니다. 
{{% /alert %}}

## **이미지 압축**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/compressimage/) 메서드를 사용하면 프레젠테이션 내 그림을 압축할 수 있습니다. 이 메서드는 도형 크기와 지정된 해상도를 기준으로 이미지 크기를 줄이며, 필요에 따라 잘린 영역을 삭제할 수도 있습니다.  

PowerPoint의 **Picture Format → Compress Pictures → Resolution** 기능과 유사하게 그림의 크기와 해상도를 조정합니다.  

아래 C# 예제는 목표 해상도를 지정하고 선택적으로 잘린 영역을 제거하여 프레젠테이션의 이미지를 압축하는 방법을 보여줍니다:  

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 이미지를 목표 해상도 150 DPI(웹 해상도)로 압축하고 잘린 영역을 제거합니다.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // 압축 결과를 확인합니다.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

또는 직접 사용자 정의 DPI 값을 사용하는 방법:  

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 이미지를 150 DPI(웹 해상도)로 압축하고, 잘린 영역을 제거합니다.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
이 메서드는 도형 크기와 제공된 DPI를 기준으로 이미지를 낮은 해상도로 변환합니다. 파일 크기 최적화를 위해 잘린 영역을 삭제할 수도 있습니다.  
이미지가 메타파일(WMF/EMF)이나 SVG인 경우 압축이 적용되지 않습니다. JPEG의 경우 해상도에 따라 품질이 보존되거나 약간 감소합니다(이는 PowerPoint에서 고해상도 JPEG를 처리하는 방식과 유사합니다). 
{{% /alert %}}

## **가로 세로 비율 잠그기**

이미지를 포함한 도형의 가로 세로 비율을 이미지 크기를 변경하더라도 유지하려면 [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframelock/aspectratiolocked/) 속성을 사용해 *가로 세로 비율 잠금* 설정을 지정할 수 있습니다.  

아래 C# 코드는 도형의 가로 세로 비율을 잠그는 방법을 보여줍니다:  

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // 리사이징 시 가로 세로 비율을 유지하도록 도형을 설정합니다
}
```

{{% alert title="NOTE" color="warning" %}} 
*가로 세로 비율 잠금* 설정은 도형 자체의 비율만 유지하고, 도형에 포함된 이미지는 영향을 받지 않습니다. 
{{% /alert %}}

## **StretchOff 속성 사용**

[IPictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat) 인터페이스와 [PictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat) 클래스에서 제공하는 [StretchOffsetLeft](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat/properties/stretchoffsetright), [StretchOffsetBottom](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) 속성을 사용하면 채우기 사각형을 지정할 수 있습니다.  

이미지에 스트레칭이 지정되면 원본 사각형이 지정된 채우기 사각형에 맞게 스케일됩니다. 채우기 사각형의 각 가장자리는 도형 경계 상자의 해당 가장자리로부터 백분율 오프셋으로 정의됩니다. 양수 백분율은 내부 삽입을 의미하고, 음수 백분율은 외부 확장을 의미합니다.  

1. [Presentation](http://www.aspose.com/api/net/slides/ko/aspose.slides/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 사각형 `AutoShape`을 추가합니다.  
4. 이미지를 생성합니다.  
5. 도형의 채우기 유형을 설정합니다.  
6. 도형의 그림 채우기 모드를 설정합니다.  
7. 도형을 채우기 위한 이미지를 추가합니다.  
8. 도형 경계 상자의 해당 가장자리로부터 이미지 오프셋을 지정합니다.  
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // 도형 본문에서 이미지가 각 측면으로 늘어나도록 설정합니다
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### 그림 프레임에서 지원되는 이미지 형식을 어떻게 확인할 수 있나요?

Aspose.Slides는 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/)에 할당된 이미지 객체를 통해 래스터 이미지(PNG, JPEG, BMP, GIF 등)와 벡터 이미지(SVG 등)를 모두 지원합니다. 지원되는 형식 목록은 슬라이드 및 이미지 변환 엔진의 기능과 대부분 겹칩니다.

### 수십 개의 대용량 이미지를 추가하면 PPTX 파일 크기와 성능에 어떤 영향을 미치나요?

큰 이미지를 삽입하면 파일 크기와 메모리 사용량이 증가합니다. 이미지를 링크 형태로 추가하면 프레젠테이션 크기를 줄일 수 있지만 외부 파일이 계속 접근 가능해야 합니다. Aspose.Slides는 링크로 이미지를 추가해 파일 크기를 최소화하는 기능을 제공합니다.

### 이미지 객체가 실수로 이동하거나 크기가 조정되는 것을 어떻게 방지할 수 있나요?

[PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/)에 대한 [shape locks](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/pictureframelock/)를 사용합니다(예: 이동 또는 크기 조정 비활성화). 잠금 메커니즘에 대한 자세한 내용은 별도의 [보호 기사](/slides/ko/net/applying-protection-to-presentation/)에 설명되어 있으며, 다양한 도형 유형(예: [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/))에 대해 지원됩니다.

### 프레젠테이션을 PDF/이미지로 내보낼 때 SVG 벡터 정밀도가 유지되나요?

Aspose.Slides는 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/)에서 원본 벡터 SVG를 추출할 수 있게 해줍니다. PDF(/slides/ko/net/convert-powerpoint-to-pdf/) 또는 래스터 형식(/slides/ko/net/convert-powerpoint-to-png/)으로 내보낼 때는 내보내기 설정에 따라 이미지가 래스터화될 수 있지만, 원본 SVG가 벡터로 저장된다는 점은 추출 동작을 통해 확인할 수 있습니다.