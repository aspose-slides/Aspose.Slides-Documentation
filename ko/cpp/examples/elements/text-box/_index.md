---
title: 텍스트 상자
type: docs
weight: 40
url: /ko/cpp/examples/elements/text-box/
keywords:
- 코드 예제
- 텍스트 상자
- 파워포인트
- 오픈문서
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 텍스트 상자를 처리합니다: C++를 사용하여 PPT, PPTX 및 ODP 프레젠테이션의 텍스트를 추가, 서식 지정, 정렬, 줄 바꿈, 자동 맞춤 및 스타일링합니다."
---
Aspose.Slides에서 **텍스트 상자**는 `AutoShape`으로 표현됩니다. 거의 모든 도형에 텍스트를 넣을 수 있지만, 일반적인 텍스트 상자는 채우기와 테두리가 없으며 텍스트만 표시합니다.

이 가이드는 텍스트 상자를 프로그래밍 방식으로 추가, 접근 및 제거하는 방법을 설명합니다.

## **텍스트 상자 추가**

텍스트 상자는 단순히 채우기와 테두리가 없고 서식이 적용된 텍스트가 포함된 `AutoShape`입니다. 다음은 텍스트 상자를 만드는 방법입니다:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 사각형 도형을 생성합니다 (기본적으로 테두리와 채우기가 있으며 텍스트는 없습니다).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // 채우기와 테두기를 제거하여 일반 텍스트 상자처럼 보이게 합니다.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // 텍스트 서식을 설정합니다.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // 실제 텍스트 내용을 할당합니다.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Note:** 비어 있지 않은 `TextFrame`을 포함하는 모든 `AutoShape`는 텍스트 상자로 사용할 수 있습니다.

## **내용으로 텍스트 상자 접근**

특정 키워드(예:"Slide")를 포함하는 모든 텍스트 상자를 찾으려면 도형을 순회하면서 텍스트를 확인합니다:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // 편집 가능한 텍스트를 포함할 수 있는 것은 AutoShape뿐입니다.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // 일치하는 텍스트 상자에 대해 작업을 수행합니다.
            }
        }
    }

    presentation->Dispose();
}
```

## **내용으로 텍스트 상자 삭제**

이 예제는 특정 키워드를 포함하는 첫 번째 슬라이드의 모든 텍스트 상자를 찾아 삭제합니다:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Tip:** 반복 중에 컬렉션을 수정하는 오류를 방지하려면 반복하기 전에 도형 컬렉션의 복사본을 항상 생성하십시오.