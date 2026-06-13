---
title: C++를 사용하여 PowerPoint 테이블의 행과 열 관리
linktitle: 행과 열
type: docs
weight: 20
url: /ko/cpp/manage-rows-and-columns/
keywords:
- 테이블 행
- 테이블 열
- 첫 번째 행
- 테이블 머리글
- 행 복제
- 열 복제
- 행 복사
- 열 복사
- 행 제거
- 열 제거
- 행 텍스트 서식
- 열 텍스트 서식
- 테이블 스타일
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint에서 테이블 행과 열을 관리하고 프레젠테이션 편집 및 데이터 업데이트를 가속화합니다."
---
## **소개**

PowerPoint 프레젠테이션에서 테이블의 행과 열을 관리할 수 있도록 Aspose.Slides는 [Table](https://reference.aspose.com/slides/ko/cpp/aspose.slides/table/) 클래스, [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 인터페이스 및 기타 여러 유형을 제공합니다. 

## **첫 번째 행을 머리글로 설정**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다. 
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체를 생성하고 null로 설정합니다. 
4. 모든 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 객체를 반복하여 해당 테이블을 찾습니다. 
5. 테이블의 첫 번째 행을 머리글로 설정합니다. 

다음 C++ 코드는 테이블의 첫 번째 행을 머리글로 설정하는 방법을 보여줍니다:

```c++
// Presentation 클래스를 인스턴스화합니다 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// 첫 번째 슬라이드에 접근합니다
auto sld = pres->get_Slides()->idx_get(0);

// null TableEx를 초기화합니다
SharedPtr<ITable> tbl;

// 모양들을 반복하며 테이블에 대한 참조를 설정합니다
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// 테이블의 첫 번째 행을 머리글로 설정합니다 
tbl->set_FirstRow(true);
```

## **테이블 행 또는 열 복제**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다. 
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. `columnWidth` 배열을 정의합니다. 
4. `rowHeight` 배열을 정의합니다. 
5. [AddTable()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addtable/) 메서드를 사용하여 슬라이드에 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체를 추가합니다. 
6. 테이블 행을 복제합니다. 
7. 테이블 열을 복제합니다. 
8. 수정된 프레젠테이션을 저장합니다. 

다음 C++ 코드는 PowerPoint 테이블의 행 또는 열을 복제하는 방법을 보여줍니다:

```c++
 // 문서 디렉터리 경로.
const String outPath = u"../out/CloningInTable_out.pptx";

// Presentation 클래스를 인스턴스화합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 열 너비와 행 높이를 정의합니다
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 슬라이드에 테이블 형태를 추가합니다
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 각 셀의 테두리 형식을 설정합니다
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
	SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
	for (int y = 0; y < row->get_Count(); y++)
	{
		SharedPtr<ICell> cell = row->idx_get(y);

		cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderTop()->set_Width(5);

		cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderBottom()->set_Width(5);

		cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderLeft()->set_Width(5);

		cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderRight()->set_Width(5);

	}

}

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone은 테이블 끝에 행을 추가합니다
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone은 테이블의 특정 위치에 행을 추가합니다
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone은 테이블 끝에 열을 추가합니다
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone은 테이블의 특정 위치에 열을 추가합니다
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


 // 프레젠테이션을 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **테이블에서 행 또는 열 제거**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다. 
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. `columnWidth` 배열을 정의합니다. 
4. `rowHeight` 배열을 정의합니다. 
5. [AddTable()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addtable/) 메서드를 사용하여 슬라이드에 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체를 추가합니다. 
6. 테이블 행을 제거합니다. 
7. 테이블 열을 제거합니다. 
8. 수정된 프레젠테이션을 저장합니다. 

다음 C++ 코드는 테이블에서 행 또는 열을 제거하는 방법을 보여줍니다:

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Presentation 클래스를 인스턴스화합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 열 너비와 행 높이를 정의합니다
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 슬라이드에 테이블 형태를 추가합니다
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// 셀 (1, 1)과 (2, 1)을 병합합니다
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 셀 (1, 2)과 (2, 2)을 병합합니다
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// 프레젠테이션을 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **테이블 행 수준에서 텍스트 서식 설정**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다. 
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. 슬라이드에서 해당 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체에 접근합니다. 
4. 첫 번째 행 셀의 [set_FontHeight()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_fontheight/)를 설정합니다. 
5. 첫 번째 행 셀의 [set_Alignment()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_alignment/) 및 [set_MarginRight()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_marginright/)를 설정합니다. 
6. 두 번째 행 셀의 [set_TextVerticalType()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframeformat/set_textverticaltype/)를 설정합니다. 
7. 수정된 프레젠테이션을 저장합니다. 

다음 C++ 코드는 해당 작업을 시연합니다.

```c++
// Presentation 클래스의 인스턴스를 생성합니다
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// 첫 번째 슬라이드의 첫 번째 도형이 테이블이라고 가정합니다
// 첫 번째 행 셀의 글꼴 높이를 설정합니다
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// 첫 번째 행 셀의 텍스트 정렬과 오른쪽 여백을 설정합니다
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// 두 번째 행 셀의 텍스트 수직 방향을 설정합니다
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// 프레젠테이션을 디스크에 저장합니다
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **테이블 열 수준에서 텍스트 서식 설정**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다. 
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. 슬라이드에서 해당 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체에 접근합니다. 
4. 첫 번째 열 셀의 [set_FontHeight()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_fontheight/)를 설정합니다. 
5. 첫 번째 열 셀의 [set_Alignment()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_alignment/) 및 [set_MarginRight()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_marginright/)를 설정합니다. 
6. 두 번째 열 셀의 [set_TextVerticalType()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframeformat/set_textverticaltype/)를 설정합니다. 
7. 수정된 프레젠테이션을 저장합니다. 

다음 C++ 코드는 해당 작업을 시연합니다: 

```c++
// Presentation 클래스의 인스턴스를 생성합니다
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// 첫 번째 슬라이드의 첫 번째 도형이 테이블이라고 가정합니다

// 첫 번째 열 셀의 글꼴 높이를 설정합니다
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// 첫 번째 열 셀의 텍스트 정렬과 오른쪽 여백을 한 번에 설정합니다
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// 두 번째 열 셀의 텍스트 수직 방향을 설정합니다
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **테이블 스타일 속성 가져오기**

Aspose.Slides를 사용하면 테이블의 스타일 속성을 가져와 다른 테이블이나 다른 위치에 사용할 수 있습니다. 다음 C++ 코드는 테이블 사전 정의 스타일에서 스타일 속성을 가져오는 방법을 보여줍니다:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **자주 묻는 질문**

**PowerPoint 테마/스타일을 이미 만든 테이블에 적용할 수 있나요?**

예. 테이블은 슬라이드/레이아웃/마스터 테마를 상속받으며, 해당 테마 위에 채우기, 테두리 및 텍스트 색상을 여전히 재정의할 수 있습니다.

**Excel과 같이 테이블 행을 정렬할 수 있나요?**

아니요, Aspose.Slides 테이블에는 내장된 정렬이나 필터 기능이 없습니다. 먼저 메모리에서 데이터를 정렬한 다음 해당 순서대로 테이블 행을 다시 채워야 합니다.

**특정 셀에 사용자 정의 색상을 유지하면서 줄무늬(밴드) 열을 만들 수 있나요?**

예. 밴드 열을 활성화한 후 특정 셀에 로컬 서식을 적용하면 됩니다. 셀 수준 서식이 테이블 스타일보다 우선합니다.