---
title: C++에서 프레젠테이션의 고급 텍스트 추출
linktitle: 텍스트 추출
type: docs
weight: 90
url: /ko/cpp/extract-text-from-presentation/
keywords:
- 텍스트 추출
- 슬라이드에서 텍스트 추출
- 프레젠테이션에서 텍스트 추출
- PowerPoint에서 텍스트 추출
- OpenDocument에서 텍스트 추출
- PPT에서 텍스트 추출
- PPTX에서 텍스트 추출
- ODP에서 텍스트 추출
- 텍스트 검색
- 슬라이드에서 텍스트 검색
- 프레젠테이션에서 텍스트 검색
- PowerPoint에서 텍스트 검색
- OpenDocument에서 텍스트 검색
- PPT에서 텍스트 검색
- PPTX에서 텍스트 검색
- ODP에서 텍스트 검색
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 빠르게 추출하세요. 간단하고 단계별 가이드를 따라 시간을 절약하십시오."
---
## **개요**

프레젠테이션에서 텍스트를 추출하는 것은 슬라이드 콘텐츠를 다루는 개발자에게 흔하면서도 필수적인 작업입니다. Microsoft PowerPoint 파일(PPT 또는 PPTX 형식)이나 OpenDocument 프레젠테이션(ODP)을 다루든, 텍스트 데이터를 접근하고 검색하는 것은 분석, 자동화, 인덱싱 또는 콘텐츠 마이그레이션에 중요한 역할을 할 수 있습니다.

이 문서에서는 Aspose.Slides for C++를 사용하여 PPT, PPTX 및 ODP를 포함한 다양한 프레젠테이션 형식에서 텍스트를 효율적으로 추출하는 방법에 대한 포괄적인 가이드를 제공합니다. 프레젠테이션 요소를 체계적으로 순회하면서 필요한 텍스트 내용을 정확히 검색하는 방법을 학습하게 됩니다.

## **슬라이드에서 텍스트 추출**

Aspose.Slides for C++는 [Aspose.Slides.Util](https://reference.aspose.com/slides/ko/cpp/aspose.slides.util/) 네임스페이스를 제공하며, 여기에는 [SlideUtil](https://reference.aspose.com/slides/ko/cpp/aspose.slides.util/slideutil/) 클래스가 포함됩니다. 이 클래스는 프레젠테이션이나 슬라이드에서 모든 텍스트를 추출하기 위한 여러 오버로드된 정적 메서드를 제공합니다. 프레젠테이션의 슬라이드에서 텍스트를 추출하려면 [GetAllTextBoxes](https://reference.aspose.com/slides/ko/cpp/aspose.slides.util/slideutil/getalltextboxes/) 메서드를 사용합니다. 이 메서드는 [IBaseSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslide/) 형식의 객체를 매개변수로 받습니다. 실행 시 메서드는 슬라이드 전체를 스캔하여 텍스트를 찾고, 텍스트 형식을 보존한 채 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 형식 객체 배열을 반환합니다.

다음 코드 조각은 프레젠테이션의 첫 번째 슬라이드에서 모든 텍스트를 추출합니다:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **프레젠테이션에서 텍스트 추출**

전체 프레젠테이션의 텍스트를 스캔하려면 [SlideUtil](https://reference.aspose.com/slides/ko/cpp/aspose.slides.util/slideutil/) 클래스에서 제공하는 [GetAllTextFrames](https://reference.aspose.com/slides/ko/cpp/aspose.slides.util/slideutil/getalltextframes/) 정적 메서드를 사용합니다. 이 메서드는 두 개의 매개변수를 받습니다:

1. 첫 번째 매개변수는 텍스트를 추출할 PowerPoint 또는 OpenDocument 프레젠테이션을 나타내는 [IPresentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/) 객체입니다.
1. 두 번째 매개변수는 프레젠테이션 텍스트를 스캔할 때 마스터 슬라이드를 포함할지 여부를 나타내는 `Boolean` 값입니다.

이 메서드는 텍스트 형식 정보를 포함하는 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 형식 객체 배열을 반환합니다. 아래 코드는 마스터 슬라이드를 포함하여 프레젠테이션의 텍스트 및 형식 세부 정보를 스캔합니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **분류된 및 빠른 텍스트 추출**

[PresentationFactory](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentationfactory/) 클래스는 프레젠테이션에서 모든 텍스트를 추출하는 메서드도 제공합니다:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textextractionarrangingmode/) 열거형 매개변수는 텍스트 추출 결과를 정리하는 방식을 나타내며 다음 값으로 설정할 수 있습니다:
- `Unarranged` - 슬라이드 상의 위치와 상관없이 원시 텍스트입니다.
- `Arranged` - 슬라이드와 동일한 순서대로 텍스트가 정렬됩니다.

속도가 중요한 경우에는 정렬되지 않은 모드를 사용할 수 있으며, 정렬된 모드보다 빠릅니다.

[IPresentationText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationtext/)은 프레젠테이션에서 추출한 원시 텍스트를 나타냅니다. 이 객체의 `get_SlidesText()` 메서드는 [ISlideText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidetext/) 형식 객체 배열을 반환합니다. 각 객체는 해당 슬라이드의 텍스트를 나타냅니다. [ISlideText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidetext/) 형식 객체는 다음 메서드를 제공합니다:
- `get_Text()` - 슬라이드 형태에 포함된 텍스트.
- `get_MasterText()` - 해당 슬라이드와 연결된 마스터 슬라이드 형태에 포함된 텍스트.
- `get_LayoutText()` - 해당 슬라이드와 연결된 레이아웃 슬라이드 형태에 포함된 텍스트.
- `get_NotesText()` - 해당 슬라이드와 연결된 노트 슬라이드 형태에 포함된 텍스트.
- `get_CommentsText()` - 해당 슬라이드와 연결된 주석에 포함된 텍스트.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **FAQ**

**Aspose.Slides가 대형 프레젠테이션을 텍스트 추출할 때 처리 속도는 어느 정도인가요?**

Aspose.Slides는 높은 성능을 위해 최적화되어 있어 [대형 프레젠테이션](/slides/ko/cpp/open-presentation/)도 처리할 수 있으며, 실시간 또는 대량 처리 시나리오에 적합합니다.

**Aspose.Slides가 프레젠테이션 내 표와 차트에서 텍스트를 추출할 수 있나요?**

예. Aspose.Slides는 표 및 차트와 관련된 객체를 포함한 다양한 슬라이드 요소에서 텍스트를 추출할 수 있으므로 일반적인 프레젠테이션 구조에서 텍스트 콘텐츠에 접근하고 분석할 수 있습니다.

**프레젠테이션에서 텍스트를 추출하려면 특별한 Aspose.Slides 라이선스가 필요합니까?**

무료 체험 버전의 Aspose.Slides를 사용하여 텍스트를 추출할 수 있지만, [일부 제한](/slides/ko/cpp/licensing/)이 있어 슬라이드 수가 제한됩니다. 제한 없이 사용하고 더 큰 프레젠테이션을 처리하려면 정식 라이선스를 구매하는 것이 권장됩니다.