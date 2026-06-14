---
title: Bảng
type: docs
weight: 120
url: /vi/cpp/examples/elements/table/
keywords:
- ví dụ mã
- bảng
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Làm việc với các bảng trong Aspose.Slides for C++: tạo, định dạng, hợp nhất các ô, áp dụng kiểu dáng, nhập dữ liệu và xuất với các ví dụ C++ cho PPT, PPTX và ODP."
---
Ví dụ về việc thêm bảng, truy cập chúng, xóa chúng và hợp nhất các ô bằng **Aspose.Slides for C++**.

## **Thêm bảng**

Tạo một bảng đơn giản với hai hàng và hai cột.

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

## **Truy cập bảng**

Lấy hình dạng bảng đầu tiên trên slide.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Truy cập bảng đầu tiên trên slide.
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

## **Xóa bảng**

Xóa một bảng khỏi slide.

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

## **Hợp nhất các ô bảng**

Hợp nhất các ô kề nhau của bảng thành một ô duy nhất.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Hợp nhất các ô.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```