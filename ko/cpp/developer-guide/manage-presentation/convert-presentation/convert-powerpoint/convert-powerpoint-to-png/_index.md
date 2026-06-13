---
title: C++에서 PowerPoint 슬라이드를 PNG로 변환
linktitle: PowerPoint를 PNG로
type: docs
weight: 30
url: /ko/cpp/convert-powerpoint-to-png/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션을 고품질 PNG 이미지로 빠르게 변환하고, 정확하고 자동화된 결과를 보장합니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX 및 ODP와 같은 형식의 프레젠테이션 파일을 로드하고, 슬라이드를 이미지로 렌더링하며, 결과를 PNG 형식으로 저장하는 방법을 보여줍니다.

이 문서는 또한 스케일 값을 설정하거나 원하는 너비와 높이를 지정하여 생성된 PNG 이미지를 사용자 지정하는 방법을 보여줍니다.

## **PowerPoint를 PNG로 변환**

다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.
2. [ISlide](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_slide) 인터페이스 아래의 [Presentation::get_Slides()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) 컬렉션에서 슬라이드 객체를 가져옵니다.
3. 각 슬라이드의 썸네일을 얻기 위해 [ISlide::GetImage()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/getimage) 메서드를 사용합니다.
4. [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) 메서드를 사용하여 슬라이드 썸네일을 PNG 형식으로 저장합니다.

다음 C++ 코드는 PowerPoint 프레젠테이션을 PNG로 변환하는 방법을 보여줍니다:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **맞춤 크기로 PowerPoint를 PNG로 변환**

특정 스케일에 맞는 PNG 파일을 얻고자 하는 경우, 결과 썸네일의 크기를 결정하는 `desiredX` 및 `desiredY` 값을 설정할 수 있습니다.

다음 C++ 코드는 설명된 작업을 보여줍니다:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **맞춤 크기로 PowerPoint를 PNG로 변환**

특정 크기의 PNG 파일을 얻고자 하는 경우, `ImageSize`에 원하는 `width` 및 `height` 인수를 전달할 수 있습니다.

다음 코드는 이미지를 위한 크기를 지정하면서 PowerPoint를 PNG로 변환하는 방법을 보여줍니다:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **FAQ**

**전체 슬라이드가 아니라 특정 도형(예: 차트 또는 그림)만 내보내려면 어떻게 해야 하나요?**

Aspose.Slides는 [개별 도형에 대한 썸네일 생성](/slides/ko/cpp/create-shape-thumbnails/)을 지원합니다; 도형을 PNG 이미지로 렌더링할 수 있습니다.

**서버에서 병렬 변환을 지원합니까?**

예, 하지만 단일 프레젠테이션 인스턴스를 스레드 간에 [공유하지 마세요](/slides/ko/cpp/multithreading/). 스레드 또는 프로세스당 별도의 인스턴스를 사용하십시오.

**PNG로 내보낼 때 평가판의 제한 사항은 무엇인가요?**

평가 모드에서는 출력 이미지에 워터마크가 추가되고 라이선스가 적용될 때까지 [다른 제한](/slides/ko/cpp/licensing/)이 적용됩니다.