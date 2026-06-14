---
title: Biểu đồ
type: docs
weight: 60
url: /vi/cpp/examples/elements/chart/
keywords:
- ví dụ mã
- biểu đồ
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Thành thạo biểu đồ với Aspose.Slides for C++: tạo, định dạng, liên kết dữ liệu và xuất biểu đồ dưới dạng PPT, PPTX và ODP với các ví dụ C++."
---
Các ví dụ về việc thêm, truy cập, xóa và cập nhật các loại biểu đồ khác nhau với **Aspose.Slides for C++**. Các đoạn mã dưới đây minh họa các thao tác cơ bản với biểu đồ.

## **Thêm biểu đồ**

Phương pháp này thêm một biểu đồ khu vực đơn giản vào slide đầu tiên.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Thêm một biểu đồ khu vực đơn giản vào slide đầu tiên.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Truy cập biểu đồ**

Sau khi tạo biểu đồ, bạn có thể lấy nó thông qua bộ sưu tập shape.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Truy cập biểu đồ đầu tiên trên slide.
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Xóa biểu đồ**

Mã sau sẽ xóa một biểu đồ khỏi slide.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Xóa biểu đồ.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Cập nhật dữ liệu biểu đồ**

Bạn có thể thay đổi các thuộc tính của biểu đồ như tiêu đề.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Thay đổi tiêu đề biểu đồ.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```