---
title: C++에서 프레젠테이션 테이블 관리
linktitle: 테이블 관리
type: docs
weight: 10
url: /ko/cpp/manage-table/
keywords:
- 테이블 추가
- 테이블 만들기
- 테이블 접근
- 종횡비
- 텍스트 정렬
- 텍스트 서식
- 테이블 스타일
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++용 Aspose.Slides를 사용하여 PowerPoint 슬라이드의 테이블을 생성 및 편집합니다. 테이블 작업 흐름을 간소화하는 간단한 코드 예제를 찾아보세요."
---
## **소개**

PowerPoint의 표는 정보를 표시하고 전달하는 효율적인 방법입니다. 행과 열로 배열된 셀 그리드에 있는 정보는 직관적이며 이해하기 쉽습니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/ko/cpp/aspose.slides/table/) 클래스, [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 인터페이스, [Cell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/cell/) 클래스, [ICell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icell/) 인터페이스 및 기타 유형을 제공하여 다양한 프레젠테이션에서 표를 만들고, 업데이트하고, 관리할 수 있도록 합니다. 

## **Table을 처음부터 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. `columnWidth` 배열을 정의합니다.  
4. `rowHeight` 배열을 정의합니다.  
5. [AddTable()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addtable/) 메서드를 사용하여 슬라이드에 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체를 추가합니다.  
6. 각 [ICell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icell/)을 반복하여 상하좌우 테두리 서식을 적용합니다.  
7. 표의 첫 번째 행에서 첫 두 셀을 병합합니다.  
8. [ICell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icell/)의 [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframe/)에 접근합니다.  
9. [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframe/)에 텍스트를 추가합니다.  
10. 수정된 프레젠테이션을 저장합니다.

This C++ code shows you how to create a table in a presentation:

```c++
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
auto pres = System::MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
auto sld = pres->get_Slides()->idx_get(0);

// 열 너비와 행 높이를 정의합니다
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// 슬라이드에 테이블 형태를 추가합니다
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 각 셀의 테두리 형식을 설정합니다
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}
// 1행의 셀 1과 2를 병합합니다
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// 병합된 셀에 텍스트를 추가합니다
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// 프레젠테이션을 디스크에 저장합니다
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **표준 Table의 번호 매기기**

표준 Table에서는 셀의 번호 매기기가 직관적이며 0부터 시작합니다. Table의 첫 번째 셀은 0,0 (열 0, 행 0)으로 인덱스됩니다. 

예를 들어, 4열 4행 Table의 셀 번호는 다음과 같습니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This C++ code shows you how to specify the numbering for cells in a table:

```c++
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
auto pres = System::MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
auto sld = pres->get_Slides()->idx_get(0);

// 열 너비와 행 높이를 정의합니다
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// 슬라이드에 테이블 형태를 추가합니다
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 각 셀의 테두리 형식을 설정합니다
for (const auto& row : tbl->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

// 프레젠테이션을 디스크에 저장합니다
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **기존 Table에 접근하기**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  

2. 인덱스를 통해 Table이 포함된 슬라이드에 대한 참조를 가져옵니다.  

3. [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체를 생성하고 null로 설정합니다.  

4. Table이 발견될 때까지 모든 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 객체를 반복합니다.  

   슬라이드에 단일 Table만 포함되어 있다고 의심되는 경우, 해당 슬라이드가 포함하고 있는 모든 Shape를 확인하면 됩니다. Shape가 Table로 식별되면 이를 [Table](https://reference.aspose.com/slides/ko/cpp/aspose.slides/table/) 객체로 형변환할 수 있습니다. 그러나 슬라이드에 여러 Table이 포함되어 있는 경우, [set_AlternativeText()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/set_alternativetext/)를 통해 필요한 Table을 검색하는 것이 좋습니다.  

5. [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체를 사용하여 Table을 조작합니다. 아래 예제에서는 Table에 새 행을 추가했습니다.  

6. 수정된 프레젠테이션을 저장합니다.  

This C++ code shows you how to access and work with an existing table:

```c++
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// 첫 번째 슬라이드에 접근합니다
auto sld = pres->get_Slides()->idx_get(0);

// Table을 null로 초기화합니다
System::SharedPtr<ITable> tbl;

// 모양들을 반복하면서 찾은 테이블에 대한 참조를 설정합니다
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// 두 번째 행의 첫 번째 열에 텍스트를 설정합니다
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// 수정된 프레젠테이션을 디스크에 저장합니다
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Table에서 텍스트 정렬**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. 슬라이드에 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체를 추가합니다.  
4. Table에서 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 객체에 접근합니다.  
5. [ITextFrame]의 [IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/)에 접근합니다.  
6. 텍스트를 수직으로 정렬합니다.  
7. 수정된 프레젠테이션을 저장합니다.  

This C++ code shows you how to align the text in a table:

```c++
// Presentation 클래스의 인스턴스를 생성합니다
auto presentation = System::MakeObject<Presentation>();

// 첫 번째 슬라이드를 가져옵니다 
auto slide = presentation->get_Slides()->idx_get(0);

// 열 너비와 행 높이를 정의합니다
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// 슬라이드에 테이블 형태를 추가합니다
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// 텍스트 프레임에 접근합니다
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// 텍스트 프레임용 Paragraph 객체를 생성합니다
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Paragraph용 Portion 객체를 생성합니다
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// 텍스트를 수직으로 정렬합니다
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// 프레젠테이션을 디스크에 저장합니다
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Table 수준에서 텍스트 서식 지정**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. 슬라이드에서 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체에 접근합니다.  
4. 텍스트의 [set_FontHeight()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_fontheight/)를 설정합니다.  
5. [set_Alignment()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_alignment/)와 [set_MarginRight()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_marginright/)를 설정합니다.  
6. [set_TextVerticalType()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframeformat/set_textverticaltype/)를 설정합니다.  
7. 수정된 프레젠테이션을 저장합니다.  

This C++ code shows you how to apply your preferred formatting options to the text in a table:

```c++
// Presentation 클래스의 인스턴스를 생성합니다
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// 첫 번째 슬라이드의 첫 번째 모양이 테이블이라고 가정합니다
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// 테이블 셀의 글꼴 높이를 설정합니다
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// 테이블 셀의 텍스트 정렬과 오른쪽 여백을 한 번에 설정합니다
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// 테이블 셀의 텍스트 수직 방향을 설정합니다
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Table 스타일 속성 가져오기**

Aspose.Slides를 사용하면 Table의 스타일 속성을 가져와 다른 Table이나 다른 위치에 사용할 수 있습니다. 이 C++ 코드는 Table 프리셋 스타일에서 스타일 속성을 가져오는 방법을 보여줍니다:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Table의 가로세로 비율 잠금**

기하학적 도형의 가로세로 비율은 각 차원의 크기 비율을 의미합니다. Aspose.Slides는 `AspectRatioLocked()` 속성을 제공하여 Table 및 기타 도형에 대해 가로세로 비율 설정을 잠글 수 있도록 합니다. 

This C++ code shows you how to lock the aspect ratio for a table:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **자주 묻는 질문**

**전체 Table 및 셀 내 텍스트에 대해 오른쪽-왼쪽(RTL) 읽기 방향을 활성화할 수 있나요?**

예. Table은 [set_RightToLeft](https://reference.aspose.com/slides/ko/cpp/aspose.slides/table/set_righttoleft/) 메서드를 제공하고, 단락은 [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraphformat/set_righttoleft/)를 제공합니다. 두 가지를 모두 사용하면 셀 내부에서 올바른 RTL 순서와 렌더링을 보장합니다.

**최종 파일에서 사용자가 Table을 이동하거나 크기를 조정하지 못하도록 방지하려면 어떻게 해야 하나요?**

[shape locks](/slides/ko/cpp/applying-protection-to-presentation/)를 사용하여 이동, 크기 조정, 선택 등을 비활성화합니다. 이러한 잠금은 Table에도 적용됩니다.

**셀 안에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 [picture fill](https://reference.aspose.com/slides/ko/cpp/aspose.slides/picturefillformat/)을 설정하면 이미지가 선택한 모드(늘리기 또는 타일)대로 셀 영역을 채웁니다.