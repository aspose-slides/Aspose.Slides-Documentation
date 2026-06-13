---
title: Aspose.Slides for .NET에서 멀티스레딩
linktitle: 멀티스레딩
type: docs
weight: 310
url: /ko/net/multithreading/
keywords:
- 멀티스레딩
- 다중 스레드
- 병렬 작업
- 슬라이드 변환
- 슬라이드를 이미지로
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 멀티스레딩은 PowerPoint 및 OpenDocument 처리를 향상시킵니다. 효율적인 프레젠테이션 워크플로를 위한 모범 사례를 확인하세요."
---
## **소개**

프레젠테이션을 병렬로 작업하는 것이 가능하지만(파싱/로드/클론 제외) 대부분 경우 잘 동작하더라도, 라이브러리를 여러 스레드에서 사용할 경우 잘못된 결과가 나올 가능성이 있습니다.

다중 스레드 환경에서 단일 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 인스턴스를 **사용하지 말 것**을 강력히 권장합니다. 이는 예측할 수 없는 오류나 쉽게 감지되지 않는 실패를 초래할 수 있기 때문입니다.

여러 스레드에서 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 로드, 저장 및/또는 복제하는 것은 **안전하지 않으며** 지원되지 **않습니다**. 이러한 작업이 필요하면 여러 개의 단일 스레드 프로세스를 사용해 작업을 병렬화해야 하며, 각 프로세스는 자체 프레젠테이션 인스턴스를 사용해야 합니다.

## **프레젠테이션 슬라이드를 병렬로 이미지로 변환**

예를 들어 PowerPoint 프레젠테이션의 모든 슬라이드를 PNG 이미지로 병렬 변환하고 싶다고 가정해 보겠습니다. 여러 스레드에서 단일 `Presentation` 인스턴스를 사용하는 것이 안전하지 않으므로, 프레젠테이션 슬라이드를 별개의 프레젠테이션으로 분할하고 각 슬라이드를 별도 스레드에서 이미지로 변환합니다. 아래 코드 예제는 이를 수행하는 방법을 보여줍니다.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // 슬라이드 i를 별도 프레젠테이션으로 추출합니다.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // 슬라이드를 별도의 작업에서 이미지로 변환합니다.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **FAQ**

**모든 스레드에서 라이선스 설정을 호출해야 합니까?**

아니오. 스레드가 시작되기 전에 **프로세스/앱 도메인**당 한 번만 수행하면 충분합니다. [license setup](/slides/ko/net/licensing/)이 동시에 호출될 수 있는 경우(예: 지연 초기화 중) 해당 호출을 동기화하십시오. 라이선스 설정 메서드 자체가 스레드에 안전하지 않기 때문입니다.

**`Presentation` 또는 `Slide` 객체를 스레드 간에 전달할 수 있습니까?**

“실시간” 프레젠테이션 객체를 스레드 간에 전달하는 것은 권장되지 않습니다. 스레드당 독립 인스턴스를 사용하거나 각 스레드용 별도의 프레젠테이션/슬라이드 컨테이너를 사전에 생성하십시오. 이 방법은 단일 프레젠테이션 인스턴스를 스레드 간에 공유하지 말라는 일반 권고와 일치합니다.

**각 스레드가 자체 `Presentation` 인스턴스를 갖는 경우, 다양한 형식(PDF, HTML, 이미지)으로의 내보내기를 병렬화하는 것이 안전합니까?**

예. 독립 인스턴스와 별도의 출력 경로를 사용하면 이러한 작업은 일반적으로 정상적으로 병렬화됩니다. 공유 프레젠테이션 객체와 공유 I/O 스트림은 피하십시오.

**멀티스레딩 환경에서 전역 폰트 설정(폴더, 대체 등)을 어떻게 해야 합니까?**

스레드를 시작하기 전에 모든 전역 폰트 설정을 초기화하고, 병렬 작업 중에는 변경하지 마십시오. 이를 통해 공유 폰트 리소스에 대한 경쟁 상태를 방지할 수 있습니다.