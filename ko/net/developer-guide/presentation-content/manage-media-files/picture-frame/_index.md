---
title: .NET에서 프레젠테이션의 그림 프레임 관리
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/net/picture-frame/
keywords:
- 그림 프레임
- 그림 프레임 추가
- 그림 프레임 생성
- 이미지 추가
- 이미지 생성
- 이미지 추출
- 래스터 이미지
- 벡터 이미지
- 이미지 자르기
- 잘린 영역
- StretchOff 속성
- 그림 프레임 서식 지정
- 그림 프레임 속성
- 상대 스케일
- 이미지 효과
- 가로 세로 비율
- 이미지 투명도
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: Aspose.Slides for .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 그림 프레임을 추가합니다. 작업 흐름을 간소화하고 슬라이드 디자인을 향상시킵니다.
---
## **소개**

그림 프레임은 이미지를 포함하는 도형이며, 마치 액자 안에 사진이 있는 것과 같습니다.  

그림 프레임을 통해 슬라이드에 이미지를 추가할 수 있습니다. 이렇게 하면 그림 프레임을 포맷함으로써 이미지도 포맷할 수 있습니다.  

{{% alert  title="Tip" color="primary" %}} 

Aspose는 무료 변환기인 [JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt)와 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)를 제공하여 사용자가 이미지를 빠르게 프레젠테이션으로 만들 수 있도록 합니다.  

{{% /alert %}} 

## **그림 프레임 만들기**

1. 프레젠테이션 클래스의 인스턴스를 생성합니다.([Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation))  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 객체에 연결된 이미지 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage) 객체를 생성합니다.([IImagescollection](https://reference.aspose.com/slides/ko/net/aspose.slides/iimagecollection))  
4. 이미지의 너비와 높이를 지정합니다.  
5. 참조된 슬라이드와 연결된 shape 객체가 제공하는 `AddPictureFrame` 메서드를 사용하여 이미지의 너비와 높이를 기준으로 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe)을 생성합니다.  
6. 슬라이드에 그림 프레임(그림을 포함)을 추가합니다.  
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C# 코드는 그림 프레임을 만드는 방법을 보여줍니다:  

```c#
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

그림 프레임을 사용하면 이미지를 기반으로 프레젠테이션 슬라이드를 빠르게 만들 수 있습니다. 그림 프레임과 Aspose.Slides 저장 옵션을 결합하면 이미지 형식 간 변환을 위한 입력/출력 작업을 조작할 수 있습니다. 다음 페이지를 참고하세요: 변환 [image to JPG](https://products.aspose.com/slides/ko/net/conversion/image-to-jpg/); 변환 [JPG to image](https://products.aspose.com/slides/ko/net/conversion/jpg-to-image/); 변환 [JPG to PNG](https://products.aspose.com/slides/ko/net/conversion/jpg-to-png/), 변환 [PNG to JPG](https://products.aspose.com/slides/ko/net/conversion/png-to-jpg/); 변환 [PNG to SVG](https://products.aspose.com/slides/ko/net/conversion/png-to-svg/), 변환 [SVG to PNG](https://products.aspose.com/slides/ko/net/conversion/svg-to-png/).  

{{% /alert %}}

## **상대 스케일을 사용한 그림 프레임 만들기**

이미지의 상대 스케일을 변경하면 더 복잡한 그림 프레임을 만들 수 있습니다.  

1. 프레젠테이션 클래스의 인스턴스를 생성합니다.([Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation))  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 이미지 컬렉션에 이미지를 추가합니다.  
4. 프레젠테이션 객체에 연결된 이미지 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage) 객체를 생성합니다.([IImagescollection](https://reference.aspose.com/slides/ko/net/aspose.slides/iimagecollection))  
5. 그림 프레임 내에서 이미지의 상대적인 너비와 높이를 지정합니다.  
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C# 코드는 상대 스케일을 사용한 그림 프레임을 만드는 방법을 보여줍니다:  

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation())
{
    // 이미지를 로드하고 프레젠테이션 이미지 컬렉션에 추가합니다
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 슬라이드에 그림 프레임을 추가합니다
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 상대 스케일 너비와 높이를 설정합니다
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // 프레젠테이션을 저장합니다
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **그림 프레임에서 래스터 이미지 추출**

[PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe) 객체에서 래스터 이미지를 추출하여 PNG, JPG 등 다양한 형식으로 저장할 수 있습니다. 아래 코드 예제는 문서 “sample.pptx”에서 이미지를 추출해 PNG 형식으로 저장하는 방법을 보여줍니다.  

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **그림 프레임에서 SVG 이미지 추출**

프레젠테이션에 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/) 도형 안에 SVG 그래픽이 포함된 경우, Aspose.Slides for .NET을 사용하면 원본 벡터 이미지를 완전한 정밀도로 가져올 수 있습니다. 슬라이드의 shape 컬렉션을 순회하면서 각 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/)을 확인하고, 해당 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)가 SVG 내용을 보유하는지 검사한 뒤, 원본 SVG 형식으로 디스크나 스트림에 저장할 수 있습니다.  

다음 코드 예제는 그림 프레임에서 SVG 이미지를 추출하는 방법을 보여줍니다:  

```cs
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

Aspose.Slides를 사용하면 이미지에 적용된 투명도 효과를 가져올 수 있습니다. 다음 C# 코드는 해당 작업을 시연합니다:  

```c#
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

Aspose.Slides를 사용하면 이미지에 적용된 밝기와 대비 효과를 가져올 수 있습니다. [ILuminance](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iluminance/) 인터페이스가 이 이미지 변환 효과를 나타냅니다.  

다음 C# 코드는 그림 프레임에서 밝기와 대비 설정을 가져오는 방법을 보여줍니다:  

```csharp
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

{{% alert color="primary" %}} 
이미지에 적용된 모든 효과는 [Aspose.Slides.Effects](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/)에서 확인할 수 있습니다.  
{{% /alert %}}

## **그림 프레임 서식 지정**

Aspose.Slides는 그림 프레임에 적용할 수 있는 다양한 서식 옵션을 제공합니다. 이러한 옵션을 사용하면 특정 요구 사항에 맞게 그림 프레임을 조정할 수 있습니다.  

1. 프레젠테이션 클래스의 인스턴스를 생성합니다.([Presentation](http://www.aspose.com/api/net/slides/ko/aspose.slides/))  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 객체에 연결된 이미지 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage) 객체를 생성합니다.([IImagescollection](https://reference.aspose.com/slides/ko/net/aspose.slides/iimagecollection))  
4. 이미지의 너비와 높이를 지정합니다.  
5. [AddPictureFrame](http://www.aspose.com/api/net/slides/ko/aspose.slides/ishapecollection/methods/addpictureframe) 메서드를 통해 이미지의 너비와 높이를 기반으로 `PictureFrame`을 생성합니다.([IShapes](http://www.aspose.com/api/net/slides/ko/aspose.slides/ishapecollection) 객체와 연계)  
6. 슬라이드에 그림 프레임(그림을 포함)을 추가합니다.  
7. 그림 프레임의 선 색상을 설정합니다.  
8. 그림 프레임의 선 두께를 설정합니다.  
9. 양수 또는 음수 값을 지정하여 그림 프레임을 회전시킵니다.  
   * 양수 값은 시계 방향으로 회전합니다.  
   * 음수 값은 반시계 방향으로 회전합니다.  
10. 그림 프레임(그림을 포함)을 슬라이드에 다시 추가합니다.  
11. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C# 코드는 그림 프레임 서식 지정 프로세스를 보여줍니다:  

```c#
 // PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
 using (Presentation presentation = new Presentation())
 {
     // 첫 번째 슬라이드를 가져옵니다
     ISlide slide = presentation.Slides[0];

     // 이미지를 로드하고 프레젠테이션 이미지 컬렉션에 추가합니다
     IImage image = Images.FromFile("aspose-logo.jpg");
     IPPImage ppImage = presentation.Images.AddImage(image);
     image.Dispose();

     // 그림의 동일한 높이와 너비를 가진 그림 프레임을 추가합니다
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

{{% alert color="primary" %}}

Aspose는 최근에 무료 [Collage Maker](https://products.aspose.app/slides/ko/collage)를 출시했습니다. JPG/JPEG 또는 PNG 이미지를 병합하거나([merge JPG/JPEG](https://products.aspose.app/slides/ko/collage/jpg), [merge PNG](https://products.aspose.app/slides/ko/collage/png)), 사진으로 그리드를 만들고 싶을 때([create grids from photos](https://products.aspose.app/slides/ko/collage/photo-grid)) 이 서비스를 사용할 수 있습니다.  

{{% /alert %}}

## **이미지를 링크로 추가**

프레젠테이션 크기를 줄이기 위해 파일을 직접 삽입하는 대신 링크를 통해 이미지(또는 비디오)를 추가할 수 있습니다. 다음 C# 코드는 자리표시자에 이미지와 비디오를 추가하는 방법을 보여줍니다:  

```c#
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

다음 C# 코드는 슬라이드에 있는 기존 이미지를 자르는 방법을 보여줍니다:  

```c#
using (Presentation presentation = new Presentation())
{
    // 새로운 이미지 객체를 생성합니다
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 슬라이드에 PictureFrame을 추가합니다
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // 이미지 자르기 (백분율 값)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // 결과를 저장합니다
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **그림 프레임에서 잘린 영역 삭제**

프레임에 포함된 이미지의 잘린 영역을 삭제하려면 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 메서드를 사용할 수 있습니다. 이 메서드는 잘린 이미지를 반환하거나 잘라낼 필요가 없을 경우 원본 이미지를 반환합니다.  

다음 C# 코드는 해당 작업을 시연합니다:  

```c#
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

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 메서드는 잘린 이미지를 프레젠테이션 이미지 컬렉션에 추가합니다. 이미지가 처리된 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/)에만 사용되는 경우 프레젠테이션 크기를 줄일 수 있습니다. 그렇지 않으면 최종 프레젠테이션의 이미지 수가 증가합니다.  

이 메서드는 잘라내기 작업 중 WMF/EMF 메타파일을 래스터 PNG 이미지로 변환합니다.  

{{% /alert %}}

## **이미지 압축**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/compressimage/) 메서드를 사용하여 프레젠테이션 내 이미지를 압축할 수 있습니다. 이 메서드는 shape 크기와 지정된 해상도를 기준으로 이미지 크기를 줄이며, 필요에 따라 잘린 영역을 삭제할 수도 있습니다.  

PowerPoint의 **Picture Format → Compress Pictures → Resolution** 기능과 유사하게 이미지의 크기와 해상도를 조정합니다.  

다음 C# 예제는 목표 해상도를 지정하고 선택적으로 잘린 영역을 제거하여 프레젠테이션의 이미지를 압축하는 방법을 보여줍니다:  

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 이미지을 목표 해상도 150 DPI(웹 해상도)로 압축하고 잘린 영역을 제거합니다.
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

이 메서드는 shape 크기와 제공된 DPI를 기준으로 이미지 해상도를 낮추며, 파일 크기 최적화를 위해 잘린 영역을 삭제할 수도 있습니다. 이미지가 메타파일(WMF/EMF) 또는 SVG인 경우 압축이 적용되지 않습니다. JPEG의 경우 해상도에 따라 품질이 유지되거나 약간 감소합니다(이는 PowerPoint가 고해상도 JPEG를 처리하는 방식과 유사합니다).  

{{% /alert %}}

## **가로 세로 비율 고정**

이미지 차원 변경 후에도 이미지가 포함된 shape가 가로 세로 비율을 유지하도록 하려면 [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframelock/aspectratiolocked/) 속성을 사용하여 *Lock Aspect Ratio* 설정을 적용할 수 있습니다.  

다음 C# 코드는 shape의 가로 세로 비율을 고정하는 방법을 보여줍니다:  

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // 크기 조정 시 형태가 가로 세로 비율을 유지하도록 설정합니다
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

이 *Lock Aspect Ratio* 설정은 shape 자체의 비율만 보존하며, 포함된 이미지의 비율은 영향을 받지 않습니다.  

{{% /alert %}}

## **StretchOff 속성 사용**

[IPictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat) 인터페이스와 [PictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat) 클래스의 [StretchOffsetLeft](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat/properties/stretchoffsetright), [StretchOffsetBottom](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) 속성을 사용하면 채우기 사각형을 지정할 수 있습니다.  

이미지에 스트레칭이 지정되면 원본 사각형이 지정된 채우기 사각형에 맞게 확대/축소됩니다. 채우기 사각형의 각 가장자리는 shape 경계 상자의 해당 가장자리로부터 백분율 오프셋으로 정의됩니다. 양수 백분율은 안쪽으로 삽입을 의미하고, 음수 백분율은 바깥쪽으로 확장을 의미합니다.  

1. [Presentation](http://www.aspose.com/api/net/slides/ko/aspose.slides/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 사각형 `AutoShape`을 추가합니다.  
4. 이미지를 생성합니다.  
5. shape의 채우기 유형을 설정합니다.  
6. shape의 그림 채우기 모드를 설정합니다.  
7. 채우기에 사용할 이미지를 지정합니다.  
8. shape 경계 상자의 해당 가장자리로부터 이미지 오프셋을 지정합니다.  
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C# 코드는 StretchOff 속성을 사용하는 과정을 시연합니다:  

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // 모양 본문에서 이미지가 각 측면으로 늘어나도록 설정합니다
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**그림 프레임에서 지원되는 이미지 형식은 어떻게 확인할 수 있나요?**  

Aspose.Slides는 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/)에 할당된 이미지 객체를 통해 래스터 이미지(PNG, JPEG, BMP, GIF 등)와 벡터 이미지(SVG 등)를 모두 지원합니다. 지원 형식 목록은 슬라이드 및 이미지 변환 엔진의 기능과 대체로 일치합니다.  

**수십 개의 대용량 이미지를 추가하면 PPTX 크기와 성능에 어떤 영향을 미치나요?**  

대용량 이미지를 포함하면 파일 크기와 메모리 사용량이 증가합니다. 이미지를 링크로 연결하면 프레젠테이션 크기를 줄일 수 있지만 외부 파일이 계속 접근 가능해야 합니다. Aspose.Slides는 파일 크기 감소를 위해 링크를 통한 이미지 추가 기능을 제공합니다.  

**이미지 개체가 실수로 이동/크기 조정되는 것을 어떻게 방지할 수 있나요?**  

[shape locks](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/pictureframelock/) 를 사용하여 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/)에 대한 이동 또는 크기 조정 방지와 같은 잠금 옵션을 설정할 수 있습니다. 잠금 메커니즘은 별도의 [보호 기사](/slides/ko/net/applying-protection-to-presentation/)에서 설명되며, 다양한 shape 유형(예: [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/))에 적용됩니다.  

**PDF/이미지로 프레젠테이션을 내보낼 때 SVG 벡터 정밀도가 유지되나요?**  

Aspose.Slides는 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/)에서 SVG를 원본 벡터 형태로 추출할 수 있게 합니다. [PDF로 내보내기](/slides/ko/net/convert-powerpoint-to-pdf/) 또는 [래스터 형식으로 내보내기](/slides/ko/net/convert-powerpoint-to-png/) 시, 내보내기 설정에 따라 결과가 래스터화될 수 있지만, 추출 동작을 통해 원본 SVG가 벡터로 보존된다는 점을 확인할 수 있습니다.  