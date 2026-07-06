---
title: C++ 프레젠테이션에서 텍스트 부분 경계 가져오기
linktitle: 부분 경계
type: docs
weight: 47
url: /ko/cpp/portion-bounds/
keywords:
- 텍스트 부분 경계
- 텍스트 부분
- 텍스트 조각
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 텍스트 부분 경계를 가져오는 방법을 배웁니다."
---
## **개요**

텍스트 부분은 단락 내의 특정 텍스트 조각을 나타내며, 주변 콘텐츠와 독립적으로 해당 조각을 작업할 수 있게 합니다. Aspose.Slides에서 부분은 텍스트 조각의 경계를 가져와야 하거나, 단락의 일부만 서식을 적용해야 하거나, 텍스트 동작을 보다 상세하게 제어해야 할 때 사용할 수 있습니다.

이 문서에서는 [IPortion::GetRect](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/getrect/)을 사용하여 부분의 경계 사각형을 가져오는 방법을 보여줍니다. 또한 [IPortion::GetCoordinates](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/getcoordinates/)을 사용하여 부분 시작점의 좌표를 가져오는 방법을 설명합니다. 추가로, 단일 텍스트 조각에 하이퍼링크를 적용하거나, 부분, 단락, 텍스트 프레임 및 테마 상속을 통해 서식이 어떻게 해결되는지 이해하고, 지정된 글꼴이 없을 경우를 처리하는 등 일반적인 부분 관련 시나리오를 강조합니다.

## **텍스트 부분의 경계 가져오기**

[IPortion::GetRect](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/getrect/)을 사용하여 텍스트 부분의 경계 사각형을 가져옵니다:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **텍스트 부분의 좌표 가져오기**

[IPortion::GetCoordinates](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/getcoordinates/)을 사용하여 텍스트 부분 시작점의 좌표를 가져옵니다:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **FAQ**

**단일 단락 내 텍스트의 일부에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 부분에[하이퍼링크 할당](/slides/ko/cpp/manage-hyperlinks/)을 할 수 있습니다; 해당 조각만 클릭 가능하고 전체 단락은 클릭되지 않습니다.

**스타일 상속은 어떻게 작동하나요: 부분이 어떤 것을 재정의하고, 무엇을 단락이나 텍스트 프레임에서 가져오나요?**

부분 수준 속성이 가장 높은 우선순위를 가집니다. 속성이 [IPortion](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/)에 설정되지 않은 경우 Aspose.Slides는 [IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/)에서 가져옵니다. 거기에도 설정되지 않으면 Aspose.Slides는 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 또는 [theme](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/theme/) 스타일을 사용합니다.

**부분에 지정된 글꼴이 대상 컴퓨터나 서버에 없으면 어떻게 되나요?**

[Font substitution rules](/slides/ko/cpp/font-selection-sequence/)가 적용됩니다. 텍스트가 재배열될 수 있으며, 메트릭, 하이픈 및 너비가 변경되어 정확한 위치 지정에 영향을 줄 수 있습니다.

**부분별 텍스트 채우기 투명도나 그라디언트를 단락의 나머지와 독립적으로 설정할 수 있나요?**

예, [IPortion](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/) 수준에서 텍스트 색상, 채우기 및 투명성을 인접 조각과 다르게 설정할 수 있습니다.