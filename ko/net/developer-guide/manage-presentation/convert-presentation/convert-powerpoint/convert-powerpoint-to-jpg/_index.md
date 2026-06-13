---
title: .NET에서 PPT 및 PPTX를 JPG로 변환
linktitle: PowerPoint를 JPG로 변환
type: docs
weight: 60
url: /ko/net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 JPG로
- 프레젠테이션을 JPG로
- 슬라이드를 JPG로
- PPT를 JPG로
- PPTX를 JPG로
- PowerPoint를 JPG로 저장
- 프레젠테이션을 JPG로 저장
- 슬라이드를 JPG로 저장
- PPT를 JPG로 저장
- PPTX를 JPG로 저장
- PPT를 JPG로 내보내기
- PPTX를 JPG로 내보내기
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 C#에서 PowerPoint(PPT, PPTX) 슬라이드를 고품질 JPG 이미지로 빠르고 안정적인 코드 예제로 변환합니다."
---
## **소개**

PowerPoint 및 OpenDocument 프레젠테이션을 JPG 이미지로 변환하면 슬라이드 공유, 성능 최적화, 웹사이트 또는 애플리케이션에 콘텐츠를 삽입하는 데 도움이 됩니다. Aspose.Slides for .NET을 사용하면 PPTX, PPT 및 ODP 파일을 고품질 JPEG 이미지로 변환할 수 있습니다. 이 가이드는 변환을 위한 다양한 방법을 설명합니다.

이러한 기능을 사용하면 자체 프레젠테이션 뷰어를 구현하고 각 슬라이드에 대한 썸네일을 쉽게 만들 수 있습니다. 프레젠테이션 슬라이드를 복사로부터 보호하거나 읽기 전용 모드에서 프레젠테이션을 시연하려는 경우에 유용할 수 있습니다. Aspose.Slides를 사용하면 전체 프레젠테이션이나 특정 슬라이드를 이미지 형식으로 변환할 수 있습니다.

## **프레젠테이션 슬라이드를 JPG 이미지로 변환**

다음은 PPT, PPTX 또는 ODP 파일을 JPG로 변환하는 단계입니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 만듭니다.
1. [ISlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide) 유형의 슬라이드 객체를 [Presentation.Slides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/properties/slides) 컬렉션에서 가져옵니다.
1. [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/#getimage_5) 메서드를 사용하여 슬라이드 이미지를 생성합니다.
1. 이미지 객체에서 [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/save/#save_3) 메서드를 호출합니다. 출력 파일 이름과 이미지 형식을 인수로 전달합니다.

{{% alert color="primary" %}} 
**Note:** PPT, PPTX 또는 ODP를 JPG로 변환하는 방법은 Aspose.Slides .NET API에서 다른 형식으로 변환하는 방법과 다릅니다. 다른 형식의 경우 일반적으로 [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/save/#save_5) 메서드를 사용합니다. 그러나 JPG 변환의 경우 [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/save/#save_3) 메서드를 사용해야 합니다.
{{% /alert %}} 

```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 지정된 배율로 슬라이드 이미지를 생성합니다.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // 이미지를 JPEG 형식으로 디스크에 저장합니다.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **맞춤형 크기로 슬라이드를 JPG로 변환**

결과 JPG 이미지의 크기를 변경하려면 [ISlide.GetImage(Size)](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/#getimage_6) 메서드에 크기를 전달하여 이미지 크기를 설정할 수 있습니다. 이를 통해 특정 너비와 높이 값을 가진 이미지를 생성할 수 있어 해상도 및 종횡비 요구 사항을 충족할 수 있습니다. 이러한 유연성은 웹 애플리케이션, 보고서 또는 문서용 이미지를 생성할 때 정확한 이미지 차원이 필요할 때 특히 유용합니다.

```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 지정된 크기로 슬라이드 이미지를 생성합니다.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // 이미지를 JPEG 형식으로 디스크에 저장합니다.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **슬라이드를 이미지로 저장할 때 주석 렌더링**

Aspose.Slides for .NET은 프레젠테이션 슬라이드를 JPG 이미지로 변환할 때 주석을 렌더링할 수 있는 기능을 제공합니다. 이 기능은 PowerPoint 프레젠테이션에 공동 작업자가 추가한 주석, 피드백 또는 토론을 보존하는 데 특히 유용합니다. 이 옵션을 활성화하면 생성된 이미지에 주석이 표시되어 원본 프레젠테이션 파일을 열지 않고도 피드백을 검토하고 공유하기 쉬워집니다.

예를 들어, 주석이 포함된 슬라이드를 가진 프레젠테이션 파일 "sample.pptx"가 있다고 가정해 보겠습니다:
![주석이 포함된 슬라이드](slide_with_comments.png)

다음 C# 코드는 주석을 보존하면서 슬라이드를 JPG 이미지로 변환합니다:
```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // 슬라이드 주석에 대한 옵션을 설정합니다.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // 첫 번째 슬라이드를 이미지로 변환합니다.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

결과:
![주석이 포함된 JPG 이미지](image_with_comments.png)

## **또한 보기**

PPT, PPTX 또는 ODP를 이미지로 변환하는 다른 옵션을 확인하세요, 예:
- [PowerPoint를 GIF로 변환](/slides/ko/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint를 PNG로 변환](/slides/ko/net/convert-powerpoint-to-png/)
- [PowerPoint를 TIFF로 변환](/slides/ko/net/convert-powerpoint-to-tiff/)
- [PowerPoint를 SVG로 변환](/slides/ko/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
PowerPoint [PPTX를 JPG로](https://products.aspose.app/slides/ko/conversion/pptx-to-jpg) 및 [PPT를 JPG로](https://products.aspose.app/slides/ko/conversion/ppt-to-jpg) 무료 온라인 변환기를 사용해 보세요.
{{% /alert %}} 

![무료 온라인 PPTX를 JPG로 변환기](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose는 [FREE Collage 웹 앱](https://products.aspose.app/slides/ko/collage)을 제공합니다. 이 온라인 서비스를 사용하면 [JPG to JPG](https://products.aspose.app/slides/ko/collage/jpg) 또는 PNG to PNG 이미지를 병합하고, [photo grids](https://products.aspose.app/slides/ko/collage/photo-grid)를 만들 수 있습니다.

이 문서에 설명된 동일한 원칙을 사용하면 이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 자세한 내용은 다음 페이지를 확인하세요: 변환 [image to JPG](https://products.aspose.com/slides/ko/net/conversion/image-to-jpg/); 변환 [JPG to image](https://products.aspose.com/slides/ko/net/conversion/jpg-to-image/); 변환 [JPG to PNG](https://products.aspose.com/slides/ko/net/conversion/jpg-to-png/), 변환 [PNG to JPG](https://products.aspose.com/slides/ko/net/conversion/png-to-jpg/); 변환 [PNG to SVG](https://products.aspose.com/slides/ko/net/conversion/png-to-svg/), 변환 [SVG to PNG](https://products.aspose.com/slides/ko/net/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**이 방법이 일괄 변환을 지원합니까?**

예, Aspose.Slides는 한 번의 작업으로 여러 슬라이드를 JPG로 일괄 변환할 수 있습니다.

**변환이 SmartArt, 차트 및 기타 복잡한 개체를 지원합니까?**

예, Aspose.Slides는 SmartArt, 차트, 표, 도형 등 모든 콘텐츠를 렌더링합니다. 그러나 사용자 지정 글꼴이나 누락된 글꼴을 사용할 경우 PowerPoint와 비교하여 렌더링 정확도가 약간 다를 수 있습니다.

**처리할 수 있는 슬라이드 수에 제한이 있습니까?**

Aspose.Slides 자체에는 처리할 수 있는 슬라이드 수에 대한 엄격한 제한이 없습니다. 그러나 대용량 프레젠테이션이나 고해상도 이미지를 다룰 때 메모리 부족 오류가 발생할 수 있습니다.