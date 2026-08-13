---
title: .NET에서 PowerPoint 슬라이드를 PNG로 변환
linktitle: PowerPoint를 PNG로
type: docs
weight: 30
url: /ko/net/convert-powerpoint-to-png/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 PNG로
- 프레젠테이션을 PNG로
- 슬라이드를 PNG로
- PPT를 PNG로
- PPTX를 PNG로
- PPT를 PNG로 저장
- PPTX를 PNG로 저장
- PPT를 PNG로 내보내기
- PPTX를 PNG로 내보내기
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 프레젠테이션을 고품질 PNG 이미지로 빠르게 변환하고, 정확하고 자동화된 결과를 보장합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX, ODP와 같은 형식의 프레젠테이션 파일을 로드하고, 슬라이드를 이미지로 렌더링하며, 결과를 PNG 형식으로 저장하는 방법을 보여줍니다.

또한 배율 값을 설정하거나 원하는 너비와 높이를 지정하여 생성된 PNG 이미지를 사용자 정의하는 방법도 시연합니다.

## **PowerPoint를 PNG로 변환**

다음 단계를 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. [ISlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide) 인터페이스 아래의 [Presentation.Slides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/properties/slides) 컬렉션에서 슬라이드 객체를 가져옵니다. 
3. 필요한 배율로 각 슬라이드를 렌더링하려면 [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/) 메서드를 사용합니다. 
4. 슬라이드 썸네일을 PNG 형식으로 저장하려면 [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.ipresentation/save/methods/5) 메서드를 사용합니다. 

이 C# 코드는 PowerPoint 프레젠테이션을 PNG로 변환하는 방법을 보여줍니다. Presentation 객체는 PPT, PPTX, ODP 등을 로드할 수 있으며, 프레젠테이션 객체의 각 슬라이드는 PNG 형식 또는 다른 이미지 형식으로 변환됩니다.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 

**Note:** 배율 인수 `1f, 1f`는 각 슬라이드를 전체 크기로 렌더링하므로 720×540 pt 슬라이드는 720×540 px 이미지가 됩니다. 인수가 없는 [GetImage()](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/) 오버로드는 훨씬 작은 미리보기 썸네일을 반환합니다.

{{% /alert %}} 

## **맞춤 배율로 PowerPoint를 PNG로 변환**

특정 배율에 맞는 PNG 파일을 얻고 싶다면 결과 썸네일의 크기를 결정하는 `desiredX`와 `desiredY` 값을 설정할 수 있습니다. 

이 C# 코드는 위에서 설명한 작업을 보여줍니다:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **맞춤 크기로 PowerPoint를 PNG로 변환**

특정 크기에 맞는 PNG 파일을 얻고 싶다면 `imageSize`에 원하는 `width`와 `height` 인수를 전달할 수 있습니다. 

이 코드는 이미지 크기를 지정하면서 PowerPoint를 PNG로 변환하는 방법을 보여줍니다: 

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **FAQ**

### 전체 슬라이드가 아니라 특정 도형(예: 차트 또는 그림)만 내보내려면 어떻게 해야 하나요?

Aspose.Slides는 [개별 도형에 대한 썸네일 생성](/slides/ko/net/create-shape-thumbnails/)을 지원하므로 도형을 PNG 이미지로 렌더링할 수 있습니다.

### 서버에서 병렬 변환을 지원합니까?

예, 하지만 단일 Presentation 인스턴스를 스레드 간에 공유하면 안 됩니다. 스레드 또는 프로세스당 별도의 인스턴스를 사용하십시오. [공유하지 마세요](/slides/ko/net/multithreading/).

### PNG로 내보낼 때 체험판 제한 사항은 무엇인가요?

평가 모드에서는 출력 이미지에 워터마크가 추가되고 라이선스가 적용될 때까지 [다른 제한](/slides/ko/net/licensing/)이 적용됩니다.