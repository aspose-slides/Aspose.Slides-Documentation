---
title: C++에서 프레젠테이션의 단락 경계 가져오기
linktitle: 단락 경계
type: docs
weight: 43
url: /ko/cpp/paragraph-bounds/
keywords:
- 단락 경계
- 단락 좌표
- 단락 크기
- 텍스트 프레임
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 단락 경계를 검색하여 PowerPoint 프레젠테이션의 텍스트 위치를 최적화하는 방법을 배웁니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 단락의 경계, 크기 및 좌표를 가져오는 방법을 설명합니다. [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)에서 [IParagraph::GetRect](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/getrect/)를 사용하여 단락 사각형을 검색하는 방법, 테이블 셀 텍스트 프레임 내부의 단락 좌표를 얻는 방법, 측정 단위, 텍스트 자동 줄 바꿈이 경계에 미치는 영향, 픽셀 변환 및 실제 단락 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **단락의 사각형 좌표 가져오기**

[IParagraph::GetRect](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/getrect/)를 사용하여 단락의 경계 사각형을 가져옵니다.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **테이블 셀 텍스트 프레임 내부 단락의 크기 가져오기**

테이블 셀 텍스트 프레임에서 [IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/)의 크기와 좌표를 얻으려면 [IParagraph::GetRect](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/getrect/)를 사용합니다. 반환된 사각형은 테이블 셀 텍스트 프레임을 기준으로 하므로 슬라이드 수준 좌표가 필요할 때는 테이블 위치와 셀 오프셋을 추가합니다.

다음 예제는 테이블 셀 내부의 단락 경계를 가져오고 해당 경계를 시각화하기 위해 슬라이드에 사각형을 그립니다:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **자주 묻는 질문**

**단락 좌표는 어떤 단위로 측정되나요?**

단락 좌표는 포인트 단위로 측정됩니다. 1인치는 72포인트에 해당합니다. 이는 슬라이드의 모든 좌표와 치수에 적용됩니다.

**단어 자동 줄 바꿈이 단락의 경계에 영향을 미치나요?**

예합니다. [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)에 대해 [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/set_wraptext/)가 활성화되어 있으면 텍스트가 영역 너비에 맞게 자동으로 줄 바꿈되어 단락의 실제 경계가 변경됩니다.

**단락 좌표를 내보낸 이미지의 픽셀에 신뢰할 수 있게 매핑할 수 있나요?**

예합니다. 포인트를 픽셀로 변환하려면 다음 공식을 사용합니다: 픽셀 = 포인트 × (DPI / 72). 결과는 렌더링 또는 내보내기에 선택한 DPI에 따라 달라집니다.

**스타일 상속을 고려한 “실제” 단락 서식 매개변수를 어떻게 얻나요?**

[effective paragraph formatting data structure](/slides/ko/cpp/shape-effective-properties/)를 사용합니다; 들여쓰기, 간격, 자동 줄 바꿈, RTL 등과 같은 최종 통합 값을 반환합니다.