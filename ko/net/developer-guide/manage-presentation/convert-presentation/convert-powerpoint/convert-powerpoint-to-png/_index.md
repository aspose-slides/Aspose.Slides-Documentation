---
title: PowerPoint 슬라이드를 .NET에서 PNG로 변환
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
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션을 고품질 PNG 이미지로 빠르게 변환하고, 정확하고 자동화된 결과를 보장합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX, ODP와 같은 형식의 프레젠테이션 파일을 로드하고, 슬라이드를 이미지로 렌더링한 뒤 PNG 형식으로 저장하는 과정을 보여줍니다.

또한 스케일 값을 설정하거나 원하는 가로·세로 크기를 지정하여 생성된 PNG 이미지를 사용자 정의하는 방법도 소개합니다.

## **PowerPoint을 PNG로 변환**

다음 단계를 수행합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. [ISlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide) 인터페이스 아래의 [Presentation.Slides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/properties/slides) 컬렉션에서 슬라이드 개체를 가져옵니다. 
3. [ISlide.GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/) 메서드를 사용하여 각 슬라이드의 썸네일을 가져옵니다. 
4. [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.ipresentation/save/methods/5) 메서드를 사용하여 슬라이드 썸네일을 PNG 형식으로 저장합니다. 

다음 C# 코드는 PowerPoint 프레젠테이션을 PNG로 변환하는 방법을 보여 줍니다. Presentation 개체는 PPT, PPTX, ODP 등을 로드할 수 있으며, 프레젠테이션 개체의 각 슬라이드는 PNG 형식 또는 기타 이미지 형식으로 변환됩니다.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **맞춤 크기로 PowerPoint을 PNG로 변환**

특정 배율의 PNG 파일을 얻고 싶다면, 결과 썸네일의 크기를 결정하는 `desiredX`와 `desiredY` 값을 설정할 수 있습니다. 

다음 C# 코드는 위에서 설명한 작업을 시연합니다:

```c#
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

## **맞춤 크기로 PowerPoint을 PNG로 변환**

특정 크기의 PNG 파일을 얻고 싶다면, `imageSize`에 원하는 `width`와 `height` 인수를 전달할 수 있습니다. 

다음 코드는 이미지를 위한 크기를 지정하면서 PowerPoint을 PNG로 변환하는 방법을 보여 줍니다:

```c#
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

**전체 슬라이드가 아닌 특정 도형(예: 차트 또는 그림)만 내보내려면 어떻게 해야 하나요?**

Aspose.Slides는 [개별 도형의 썸네일 생성](/slides/ko/net/create-shape-thumbnails/)을 지원하며, 도형을 PNG 이미지로 렌더링할 수 있습니다.

**서버에서 병렬 변환이 지원되나요?**

예, 하지만 스레드 간에 단일 프레젠테이션 인스턴스를 [공유하지 마십시오](/slides/ko/net/multithreading/). 스레드 또는 프로세스당 별도의 인스턴스를 사용하십시오.

**PNG로 내보낼 때 체험판 버전의 제한 사항은 무엇인가요?**

평가 모드에서는 출력 이미지에 워터마크를 추가하고 라이선스가 적용될 때까지 [기타 제한](/slides/ko/net/licensing/)을 적용합니다.