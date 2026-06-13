---
title: 표
type: docs
weight: 120
url: /ko/cpp/examples/elements/table/
keywords:
- 코드 예제
- 표
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 표를 작업합니다: 만들기, 서식 지정, 셀 병합, 스타일 적용, 데이터 가져오기 및 내보내기, PPT, PPTX 및 ODP에 대한 C++ 예제를 제공합니다."
---
**Aspose.Slides for C++**을(를) 사용하여 표를 추가하고, 접근하고, 제거하며, 셀을 병합하는 예제입니다.

## **표 추가**

두 개의 행과 두 개의 열을 가진 간단한 표를 만듭니다.

```cpp
static void AddTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    presentation->Dispose();
}
```

## **표 접근**

슬라이드에서 첫 번째 표 쉐이프를 가져옵니다.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // 슬라이드에서 첫 번째 표에 접근합니다.
    auto firstTable = SharedPtr<ITable>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            firstTable = ExplicitCast<ITable>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **표 삭제**

슬라이드에서 표를 삭제합니다.

```cpp
static void RemoveTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    slide->get_Shapes()->Remove(table);

    presentation->Dispose();
}
```

## **표 셀 병합**

표의 인접한 셀들을 하나의 셀로 병합합니다.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // 셀 병합.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```