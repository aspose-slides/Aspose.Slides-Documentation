---
title: C++에서 PPT 및 PPTX를 JPG로 변환
linktitle: PowerPoint를 JPG로
type: docs
weight: 60
url: /ko/cpp/convert-powerpoint-to-jpg/
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
- C++
- Aspose.Slides
description: "Aspose.Slides와 함께 빠르고 신뢰할 수 있는 코드 예제를 사용하여 C++에서 PowerPoint(PPT, PPTX) 슬라이드를 고품질 JPG 이미지로 변환합니다."
---
## **소개**

PowerPoint 및 OpenDocument 프레젠테이션을 JPG 이미지로 변환하면 슬라이드 공유, 성능 최적화 및 웹사이트나 애플리케이션에 콘텐츠를 삽입하는 데 도움이 됩니다. Aspose.Slides for C++를 사용하면 PPTX, PPT 및 ODP 파일을 고품질 JPEG 이미지로 변환할 수 있습니다. 이 가이드는 다양한 변환 방법을 설명합니다.

이 기능을 사용하면 자체 프레젠테이션 뷰어를 구현하고 각 슬라이드에 대한 썸네일을 손쉽게 생성할 수 있습니다. 프레젠테이션 슬라이드를 복사로부터 보호하거나 읽기 전용 모드로 프레젠테이션을 시연하려는 경우에 유용합니다. Aspose.Slides를 사용하면 전체 프레젠테이션 또는 특정 슬라이드를 이미지 형식으로 변환할 수 있습니다.

## **프레젠테이션 슬라이드를 JPG 이미지로 변환**

PPT, PPTX 또는 ODP 파일을 JPG로 변환하는 단계는 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 프레젠테이션의 슬라이드 컬렉션에서 [ISlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/) 타입의 슬라이드 객체를 가져옵니다.
1. [ISlide.GetImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/getimage/) 메서드를 사용하여 슬라이드의 이미지를 생성합니다.
1. 이미지 객체에 대해 [IImage.Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/save/) 메서드를 호출합니다. 출력 파일 이름과 이미지 형식을 인수로 전달합니다.

{{% alert color="primary" %}} 
**Note:** PPT, PPTX 또는 ODP를 JPG로 변환하는 방법은 Aspose.Slides for C++ API에서 다른 형식으로 변환하는 방법과 다릅니다. 다른 형식의 경우 일반적으로 [IPresentation.Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/save/) 메서드를 사용합니다. 그러나 JPG 변환의 경우 [IImage.Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/save/) 메서드를 사용해야 합니다.
{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // 지정된 배율로 슬라이드 이미지를 생성합니다.
    auto image = slide->GetImage(scaleX, scaleY);

    // 이미지를 JPEG 형식으로 디스크에 저장합니다.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **맞춤형 크기로 슬라이드 JPG 변환**

결과 JPG 이미지의 크기를 변경하려면 [ISlide.GetImage(Size)](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) 메서드에 원하는 크기를 전달하면 됩니다. 이를 통해 특정 너비와 높이 값을 가진 이미지를 생성할 수 있어 해상도와 종횡비 요구 사항을 만족시킬 수 있습니다. 이 유연성은 웹 애플리케이션, 보고서 또는 문서용 이미지를 정확한 크기로 생성해야 할 때 특히 유용합니다.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // 지정된 크기로 슬라이드 이미지를 생성합니다.
    auto image = slide->GetImage(imageSize);

    // 이미지를 JPEG 형식으로 디스크에 저장합니다.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **슬라이드 이미지를 저장할 때 주석 렌더링**

Aspose.Slides for C++는 슬라이드를 JPG 이미지로 변환할 때 프레젠테이션 슬라이드에 있는 주석을 렌더링하는 기능을 제공합니다. 이 기능은 PowerPoint 프레젠테이션에 협업자가 추가한 주석, 피드백 또는 토론 내용을 보존하는 데 유용합니다. 이 옵션을 활성화하면 생성된 이미지에 주석이 표시되어 원본 파일을 열지 않고도 피드백을 검토하고 공유할 수 있습니다.

예를 들어, 주석이 포함된 슬라이드가 있는 "sample.pptx" 파일이 있다고 가정해 보겠습니다:

![주석이 포함된 슬라이드](slide_with_comments.png)

다음 C++ 코드는 주석을 보존하면서 슬라이드를 JPG 이미지로 변환합니다:

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // 슬라이드 주석에 대한 옵션을 설정합니다.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // 첫 번째 슬라이드를 이미지로 변환합니다.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

결과:

![주석이 포함된 JPG 이미지](image_with_comments.png)

## **관련 항목**

다음과 같이 PPT, PPTX 또는 ODP를 이미지로 변환하는 다른 옵션을 확인하세요:

- [PowerPoint를 GIF로 변환](/slides/ko/cpp/convert-powerpoint-to-animated-gif/)
- [PowerPoint를 PNG로 변환](/slides/ko/cpp/convert-powerpoint-to-png/)
- [PowerPoint를 TIFF로 변환](/slides/ko/cpp/convert-powerpoint-to-tiff/)
- [PowerPoint를 SVG로 변환](/slides/ko/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Aspose.Slides가 PowerPoint를 JPG 이미지로 변환하는 방식을 확인하려면 무료 온라인 변환기를 사용해 보세요: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/ko/conversion/pptx-to-jpg) 및 [PPT to JPG](https://products.aspose.app/slides/ko/conversion/ppt-to-jpg). 
{{% /alert %}}

![무료 온라인 PPTX to JPG 변환기](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose는 [무료 콜라주 웹 앱](https://products.aspose.app/slides/ko/collage)을 제공합니다. 이 온라인 서비스를 사용하면 [JPG to JPG](https://products.aspose.app/slides/ko/collage/jpg) 또는 PNG to PNG 이미지를 병합하고, [포토 그리드](https://products.aspose.app/slides/ko/collage/photo-grid)를 만들 수 있습니다. 

이 문서에서 설명한 원칙을 동일하게 적용하면 이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 자세한 내용은 다음 페이지를 참고하세요: 이미지 [JPG로 변환](https://products.aspose.com/slides/ko/cpp/conversion/image-to-jpg/); [JPG를 이미지로 변환](https://products.aspose.com/slides/ko/cpp/conversion/jpg-to-image/); [JPG를 PNG로 변환](https://products.aspose.com/slides/ko/cpp/conversion/jpg-to-png/), [PNG를 JPG로 변환](https://products.aspose.com/slides/ko/cpp/conversion/png-to-jpg/); [PNG를 SVG로 변환](https://products.aspose.com/slides/ko/cpp/conversion/png-to-svg/), [SVG를 PNG로 변환](https://products.aspose.com/slides/ko/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**이 방법은 배치 변환을 지원합니까?**

예, Aspose.Slides를 사용하면 여러 슬라이드를 한번에 JPG로 배치 변환할 수 있습니다.

**변환이 SmartArt, 차트 및 기타 복잡한 개체를 지원합니까?**

예, Aspose.Slides는 SmartArt, 차트, 표, 도형 등 모든 콘텐츠를 렌더링합니다. 다만 사용자 지정 글꼴이나 누락된 글꼴을 사용할 경우 PowerPoint와 비교해 렌더링 정확도가 약간 다를 수 있습니다.

**처리 가능한 슬라이드 수에 제한이 있습니까?**

Aspose.Slides 자체에는 처리 가능한 슬라이드 수에 대한 엄격한 제한이 없습니다. 그러나 대용량 프레젠테이션이나 고해상도 이미지를 다룰 경우 메모리 부족 오류가 발생할 수 있습니다.