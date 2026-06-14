---
title: Hoạt hình biểu đồ PowerPoint trong .NET
linktitle: Biểu đồ động
type: docs
weight: 80
url: /vi/net/animated-charts/
keywords:
- biểu đồ
- biểu đồ động
- hoạt hình biểu đồ
- chuỗi biểu đồ
- danh mục biểu đồ
- phần tử chuỗi
- phần tử danh mục
- thêm hiệu ứng
- loại hiệu ứng
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tạo các biểu đồ động ấn tượng trong .NET với Aspose.Slides. Nâng cao bản trình chiếu với hình ảnh động trong các tệp PPT và PPTX — bắt đầu ngay bây giờ."
---
## **Giới thiệu**

Aspose.Slides for .NET hỗ trợ hoạt hình cho các thành phần biểu đồ. **Series**, **Categories**, **Series Elements**, **Categories Elements** có thể được hoạt hình bằng phương thức [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/methods/addeffect) và hai enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effectchartmajorgroupingtype) và [EffectChartMinorGroupingType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effectchartminorgroupingtype).

## **Hoạt hình chuỗi biểu đồ**
Nếu bạn muốn hoạt hình một chuỗi biểu đồ, viết mã theo các bước dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu đến đối tượng biểu đồ.
1. Hoạt hình chuỗi.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã hoạt hình chuỗi biểu đồ.

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Lấy tham chiếu đến đối tượng biểu đồ
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Hoạt hình chuỗi
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
    EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 0,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 1,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 2,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 3,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Ghi bản trình chiếu đã sửa đổi ra đĩa 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```

## **Hoạt hình danh mục biểu đồ**
Nếu bạn muốn hoạt hình một danh mục biểu đồ, viết mã theo các bước dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu đến đối tượng biểu đồ.
1. Hoạt hình danh mục.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã hoạt hình danh mục biểu đồ.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Lấy tham chiếu đến đối tượng biểu đồ
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Hoạt hình các phần tử danh mục
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Ghi tệp bản trình chiếu ra đĩa
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Hoạt hình trong một phần tử chuỗi**
Nếu bạn muốn hoạt hình các phần tử chuỗi, viết mã theo các bước dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu đến đối tượng biểu đồ.
1. Hoạt hình các phần tử chuỗi.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã hoạt hình các phần tử của chuỗi.

```c#
// Tải một bản trình chiếu
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Lấy tham chiếu đến đối tượng biểu đồ
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Hoạt hình các phần tử chuỗi
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Ghi tệp bản trình chiếu ra đĩa 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
```

## **Hoạt hình trong một phần tử danh mục**
Nếu bạn muốn hoạt hình các phần tử danh mục, viết mã theo các bước dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu đến đối tượng biểu đồ.
1. Hoạt hình các phần tử danh mục.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã hoạt hình các phần tử danh mục.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Lấy tham chiếu đến đối tượng biểu đồ
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Hoạt hình các phần tử danh mục
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Ghi tệp bản trình chiếu ra đĩa
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Các loại hiệu ứng khác nhau (ví dụ: vào, nhấn mạnh, ra) có được hỗ trợ cho biểu đồ giống như các hình dạng thông thường không?**

Có. Một biểu đồ được coi là một hình dạng, vì vậy nó hỗ trợ các loại hiệu ứng hoạt hình tiêu chuẩn, bao gồm vào, nhấn mạnh và ra, với khả năng kiểm soát đầy đủ thông qua dòng thời gian và chuỗi hoạt hình của slide.

**Tôi có thể kết hợp hoạt hình biểu đồ với chuyển đổi slide không?**

Có. [Transitions](/slides/vi/net/slide-transition/) áp dụng cho slide, trong khi các hiệu ứng hoạt hình áp dụng cho các đối tượng trên slide. Bạn có thể sử dụng cả hai trong cùng một bản trình chiếu và kiểm soát chúng một cách độc lập.

**Các hoạt hình biểu đồ có được giữ lại khi lưu dưới dạng PPTX không?**

Có. Khi bạn [save to PPTX](/slides/vi/net/save-presentation/), tất cả các hiệu ứng hoạt hình và thứ tự của chúng được giữ lại vì chúng là một phần của mô hình hoạt hình gốc của bản trình chiếu.

**Tôi có thể đọc các hoạt hình biểu đồ hiện có từ một bản trình chiếu và sửa đổi chúng không?**

Có. [API](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/) cung cấp truy cập vào dòng thời gian slide, các chuỗi và hiệu ứng, cho phép bạn kiểm tra các hoạt hình biểu đồ hiện có và điều chỉnh chúng mà không cần tạo lại từ đầu.

**Tôi có thể tạo video bao gồm các hoạt hình biểu đồ bằng Aspose.Slides không?**

Có. Bạn có thể [export a presentation to video](/slides/vi/net/convert-powerpoint-to-video/) trong khi giữ lại các hoạt hình, cấu hình thời gian và các cài đặt xuất khác để đoạn video kết quả phản ánh đúng các hoạt ảnh đã được tạo.