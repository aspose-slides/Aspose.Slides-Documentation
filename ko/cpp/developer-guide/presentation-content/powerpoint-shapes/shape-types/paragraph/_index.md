---
title: C++ 프레젠테이션에서 단락 경계 가져오기
linktitle: 단락
type: docs
weight: 60
url: /ko/cpp/paragraph/
keywords:
- 단락 경계
- 텍스트 부분 경계
- 단락 좌표
- 부분 좌표
- 단락 크기
- 텍스트 부분 크기
- 텍스트 프레임
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 단락 및 텍스트 부분 경계를 가져오는 방법을 알아보고 PowerPoint 프레젠테이션의 텍스트 배치를 최적화합니다."
---
## **Overview**

이 문서는 Aspose.Slides에서 단락 및 텍스트 부분의 경계, 크기 및 좌표를 가져오는 방법을 설명합니다. `GetRect()`를 사용하여 `TextFrame`에서 단락의 사각형을 가져오는 방법, 테이블 셀 텍스트 프레임 내부에서 단락 및 부분 좌표를 가져오는 방법을 보여주며, 측정 단위, 텍스트 줄 바꿈이 경계에 미치는 영향, 픽셀 변환 및 유효한 단락 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **Get Paragraph and Portion Coordinates in a TextFrame**

Aspose.Slides for C++를 사용하면 개발자는 이제 TextFrame의 단락 컬렉션 내 단락에 대한 사각형 좌표를 얻을 수 있습니다. 또한 단락의 부분 컬렉션 내 부분 좌표를 가져올 수도 있습니다. 이 항목에서는 예제를 통해 단락에 대한 사각형 좌표와 단락 내 부분의 위치를​​가져오는 방법을 보여줍니다.

## **Get Rectangular Coordinates of a Paragraph**

새 메서드 **GetRect()** 가 추가되었습니다. 이것을 사용하면 단락 경계 사각형을 가져올 수 있습니다.

``` cpp
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Get the Size of a Paragraph and Portion Inside a Table Cell TextFrame**

테이블 셀 텍스트 프레임에서 [부분](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.portion) 또는 [단락](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.paragraph) 크기와 좌표를 가져오려면 [IPortion::GetRect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) 및 [IParagraph::GetRect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t) 메서드를 사용할 수 있습니다.

다음 샘플 코드는 설명된 작업을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **FAQ**

**단락 및 텍스트 부분에 대한 좌표는 어떤 단위로 반환됩니까?**

포인트 단위이며, 1인치 = 72포인트입니다. 이는 슬라이드의 모든 좌표와 치수에 적용됩니다.

**단어 줄 바꿈이 단락의 경계에 영향을 줍니까?**

예. [wrapping](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframeformat/set_wraptext/)이 [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframe/)에서 활성화되면 텍스트가 영역 너비에 맞게 줄 바꿈되어 단락의 실제 경계가 변경됩니다.

**단락 좌표를 내보낸 이미지의 픽셀에 신뢰성 있게 매핑할 수 있습니까?**

예. 포인트를 픽셀로 변환하려면 다음을 사용합니다: pixels = points × (DPI / 72). 결과는 렌더링/내보내기에 선택한 DPI에 따라 달라집니다.

**스타일 상속을 고려한 "effective" 단락 서식 매개변수를 어떻게 가져오나요?**

[effective paragraph formatting data structure](/slides/ko/cpp/shape-effective-properties/)를 사용하십시오; 들여쓰기, 간격, 래핑, RTL 등에 대한 최종 통합 값을 반환합니다.