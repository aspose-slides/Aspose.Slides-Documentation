---
title: 하이퍼링크
type: docs
weight: 130
url: /ko/cpp/examples/elements/hyperlink/
keywords:
- 코드 예제
- 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 하이퍼링크를 추가하고 관리합니다: 텍스트, 도형 및 이미지에 링크를 설정하고, PPT, PPTX 및 ODP에 대한 대상과 동작을 C++ 예제로 지정합니다."
---
이 문서는 **Aspose.Slides for C++**를 사용하여 도형에 대한 하이퍼링크를 추가, 액세스, 제거 및 업데이트하는 방법을 보여줍니다.

## **하이퍼링크 추가**

외부 웹사이트를 가리키는 하이퍼링크가 포함된 사각형 도형을 생성합니다.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **하이퍼링크 액세스**

도형 텍스트 부분에서 하이퍼링크 정보를 읽어옵니다.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **하이퍼링크 제거**

도형 텍스트에서 하이퍼링크를 삭제합니다.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **하이퍼링크 업데이트**

기존 하이퍼링크의 대상을 변경합니다. `HyperlinkManager`를 사용하여 이미 하이퍼링크가 포함된 텍스트를 수정하면 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방합니다.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // 기존 텍스트 내부의 하이퍼링크를 변경할 때는
    // 속성을 직접 설정하는 대신 HyperlinkManager를 사용해야 합니다.
    // 이는 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방합니다.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```