---
title: 마스터 슬라이드
type: docs
weight: 30
url: /ko/cpp/examples/elements/master-slide/
keywords:
- 코드 예제
- 마스터 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 마스터 슬라이드 예제를 탐색하세요: PPT, PPTX 및 ODP에서 마스터, 자리표시자 및 테마를 만들고, 편집하고, 스타일을 적용하는 방법을 명확한 C++ 코드와 함께 제공합니다."
---
마스터 슬라이드는 PowerPoint에서 슬라이드 상속 계층의 최상위 수준을 형성합니다. **마스터 슬라이드**는 배경, 로고 및 텍스트 서식과 같은 공통 디자인 요소를 정의합니다. **레이아웃 슬라이드**는 마스터 슬라이드에서 상속받으며, **일반 슬라이드**는 레이아웃 슬라이드에서 상속받습니다.

이 문서에서는 Aspose.Slides for C++를 사용하여 마스터 슬라이드를 만들고, 수정하고, 관리하는 방법을 보여줍니다.

## **마스터 슬라이드 추가**

이 예제에서는 기본 마스터 슬라이드를 복제하여 새로운 마스터 슬라이드를 만드는 방법을 보여줍니다. 그런 다음 레이아웃 상속을 통해 모든 슬라이드에 회사명 배너를 추가합니다.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 기본 마스터 슬라이드를 복제합니다.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // 마스터 슬라이드 상단에 회사 이름 배너를 추가합니다.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // 새 마스터 슬라이드를 레이아웃 슬라이드에 할당합니다.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // 프레젠테이션의 첫 슬라이드에 레이아웃 슬라이드를 할당합니다.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **주의 1:** 마스터 슬라이드는 모든 슬라이드에 일관된 브랜드 적용이나 공유 디자인 요소를 적용하는 방법을 제공합니다. 마스터에 변경을 가하면 종속된 레이아웃 및 일반 슬라이드에 자동으로 반영됩니다.

> 💡 **주의 2:** 마스터 슬라이드에 추가된 모든 도형이나 서식은 레이아웃 슬라이드에 상속되며, 그 레이아웃을 사용하는 모든 일반 슬라이드에도 전달됩니다.
> 아래 이미지에서는 마스터 슬라이드에 추가된 텍스트 상자가 최종 슬라이드에 자동으로 표시되는 방식을 보여줍니다.

![마스터 상속 예시](master-slide-banner.png)

## **마스터 슬라이드 액세스**

프레젠테이션 마스터 컬렉션을 사용하여 마스터 슬라이드에 접근할 수 있습니다. 아래는 해당 슬라이드를 검색하고 작업하는 방법입니다:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // 배경 유형을 변경합니다.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **마스터 슬라이드 제거**

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // 인덱스로 마스터 슬라이드를 제거합니다.
    presentation->get_Masters()->RemoveAt(0);

    // 참조로 마스터 슬라이드를 제거합니다.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **사용되지 않는 마스터 슬라이드 제거**

일부 프레젠테이션에는 사용되지 않는 마스터 슬라이드가 포함되어 있습니다. 이러한 슬라이드를 제거하면 파일 크기를 줄이는 데 도움이 됩니다.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 사용되지 않은 모든 마스터 슬라이드를 제거합니다 (보존으로 표시된 슬라이드 포함).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```