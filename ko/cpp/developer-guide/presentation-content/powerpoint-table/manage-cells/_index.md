---
title: C++를 사용한 프레젠테이션에서 표 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/cpp/manage-cells/
keywords:
- 표 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 내 이미지
- 배경 색상
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint의 표 셀을 손쉽게 관리하세요. 셀에 접근하고 수정하며 스타일을 빠르게 적용하여 원활한 슬라이드 자동화를 구현합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 표 셀에 접근하고 수정할 수 있습니다. 이 문서에서는 병합된 표 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호 매기기, 셀 배경 색상을 변경하는 방법, 그리고 표 셀 안에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 생성하거나 열고, 슬라이드에서 표를 가져와 셀 속성을 통해 셀 서식을 업데이트한 뒤, 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 보여줍니다.

## **병합된 셀 식별**
1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에서 표를 가져옵니다. 
3. 표의 행과 열을 반복하면서 병합된 셀을 찾습니다.
4. 병합된 셀을 발견하면 메시지를 출력합니다.

다음 C++ 코드는 프레젠테이션에서 병합된 표 셀을 식별하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Slide#0.Shape#0이 표라고 가정합니다
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **표 셀 테두리 제거**
1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다. 
3. 너비가 지정된 열 배열을 정의합니다.
4. 높이가 지정된 행 배열을 정의합니다.
5. `AddTable` 메서드를 사용해 슬라이드에 표를 추가합니다.
6. 모든 셀을 반복하면서 위, 아래, 오른쪽, 왼쪽 테두리를 삭제합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C++ 코드는 표 셀의 테두리를 제거하는 방법을 보여줍니다:

``` cpp
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
auto pres = MakeObject<Presentation>();
// 첫 번째 슬라이드에 접근합니다
auto sld = pres->get_Slides()->idx_get(0);

// 열을 너비로, 행을 높이로 정의합니다
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// 슬라이드에 표 형상을 추가합니다
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 각 셀에 대한 테두리 형식을 설정합니다
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// PPTX 파일을 디스크에 씁니다
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **병합 셀의 번호 매기기**
2개의 셀 쌍 (1, 1) × (2, 1) 과 (1, 2) × (2, 2)를 병합하면 결과 표에 번호가 매겨집니다. 다음 C# 코드는 해당 과정을 보여줍니다:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// 원하는 프레젠테이션을 로드합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 열을 너비로, 행을 높이로 정의합니다
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 슬라이드에 표 형상을 추가합니다
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 각 셀에 대한 테두리 형식을 설정합니다
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
// 셀 (1, 1)과 (2, 1)을 병합합니다
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 셀 (1, 2)와 (2, 2)을 병합합니다
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// PPTX 파일을 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

그 후 (1, 1)과 (1, 2)를 추가로 병합합니다. 결과는 중앙에 큰 병합 셀이 있는 표가 됩니다:

```c++
// 문서 디렉터리 경로
const String outPath = u"../out/MergeCells_out.pptx";

// 원하는 프레젠테이션을 로드합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 열을 너비로, 행을 높이로 정의합니다
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 슬라이드에 표 형상을 추가합니다
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 각 셀에 대한 테두리 형식을 설정합니다
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

// 셀 (1, 1)과 (2, 1)을 병합합니다
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 셀 (1, 2)와 (2, 2)을 병합합니다
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// PPTX 파일을 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **분할된 셀의 번호 매기기**
이전 예제에서는 표 셀을 병합해도 다른 셀의 번호 매기기 체계가 변하지 않았습니다. 

이번에는 병합되지 않은 일반 표를 사용하고 (1,1) 셀을 분할하여 특수한 표를 만들겠습니다. 이 표의 번호 매기기가 다소 이상하게 보일 수 있지만, 이는 Microsoft PowerPoint가 표 셀에 번호를 매기는 방식이며 Aspose.Slides도 동일하게 동작합니다. 

다음 C++ 코드는 해당 과정을 시연합니다:

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/CellSplit_out.pptx";

// 원하는 프레젠테이션을 로드합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 열을 너비로, 행을 높이로 정의합니다
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 슬라이드에 표 형상을 추가합니다
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 각 셀에 대한 테두리 형식을 설정합니다
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

// 셀 (1, 1)과 (2, 1)을 병합합니다
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 셀 (1, 2)와 (2, 2)을 병합합니다
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// 셀 (1, 1)을 분할합니다.
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// PPTX 파일을 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **표 셀 배경 색상 변경**

다음 C++ 코드는 표 셀의 배경 색상을 변경하는 방법을 보여줍니다:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
        // 새 표를 생성합니다
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
        // 셀 배경 색상을 설정합니다 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **표 셀 안에 이미지 추가**
1. `Presentation` 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. 너비가 지정된 열 배열을 정의합니다.
4. 높이가 지정된 행 배열을 정의합니다.
5. `AddTable` 메서드를 사용해 슬라이드에 표를 추가합니다. 
6. 이미지 파일을 보관할 `Bitmap` 객체를 생성합니다.
7. 비트맵 이미지를 `IPPImage` 객체에 추가합니다.
8. 셀의 `FillFormat`을 `Picture`로 설정합니다.
9. 이미지를 표의 첫 번째 셀에 추가합니다.
10. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C# 코드는 표를 만들 때 셀 안에 이미지를 배치하는 방법을 보여줍니다:

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// 원하는 프레젠테이션을 로드합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 열을 너비로, 행을 높이로 정의합니다
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// 슬라이드에 표 형상을 추가합니다
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// 이미지를 가져옵니다
auto img = Images::FromFile(ImagePath);

// 프레젠테이션의 이미지 컬렉션에 이미지를 추가합니다
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// 이미지를 첫 번째 표 셀에 추가합니다
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// PPTX 파일을 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**하나의 셀에 대해 서로 다른 면에 다른 두께와 스타일을 지정할 수 있나요?**

예. [위쪽](https://reference.aspose.com/slides/ko/cpp/aspose.slides/cellformat/get_bordertop/)/[아래쪽](https://reference.aspose.com/slides/ko/cpp/aspose.slides/cellformat/get_borderbottom/)/[왼쪽](https://reference.aspose.com/slides/ko/cpp/aspose.slides/cellformat/get_borderleft/)/[오른쪽](https://reference.aspose.com/slides/ko/cpp/aspose.slides/cellformat/get_borderright/) 테두리는 각각 별도의 속성을 가지고 있어 각 면의 두께와 스타일을 다르게 지정할 수 있습니다. 이는 본문에서 설명한 셀 별 면 테두기 제어와 논리적으로 일치합니다.

**셀 배경에 이미지를 설정한 뒤 열/행 크기를 변경하면 이미지가 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/ko/cpp/aspose.slides/picturefillmode/) (stretch/​tile)에 따라 달라집니다. stretch인 경우 이미지는 새로운 셀 크기에 맞게 조정되고, tile인 경우 타일이 재계산됩니다. 문서에서는 셀 내 이미지 표시 모드에 대해 언급하고 있습니다.

**셀 전체 내용에 하이퍼링크를 지정할 수 있나요?**

[Hyperlinks](/slides/ko/cpp/manage-hyperlinks/)는 셀의 텍스트 프레임 내부 텍스트(부분) 수준이나 전체 표/도형 수준에서 설정됩니다. 실제로는 텍스트의 일부 또는 셀 전체 텍스트에 링크를 지정합니다.

**하나의 셀 안에서 서로 다른 글꼴을 사용할 수 있나요?**

예. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/portion/) (run) 단위로 독립적인 서식을 지원합니다—글꼴 종류, 스타일, 크기, 색상 등을 개별적으로 지정할 수 있습니다.