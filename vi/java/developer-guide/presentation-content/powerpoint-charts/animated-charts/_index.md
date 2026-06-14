---
title: "Tạo hoạt ảnh cho biểu đồ PowerPoint trong Java"
linktitle: "Biểu đồ Động"
type: docs
weight: 80
url: /vi/java/animated-charts/
keywords:
- "biểu đồ"
- "biểu đồ động"
- "hoạt ảnh biểu đồ"
- "chuỗi biểu đồ"
- "danh mục biểu đồ"
- "phần tử chuỗi"
- "phần tử danh mục"
- "thêm hiệu ứng"
- "loại hiệu ứng"
- "PowerPoint"
- "bản trình bày"
- "Java"
- "Aspose.Slides"
description: "Tạo các biểu đồ động tuyệt đẹp trong Java bằng Aspose.Slides. Nâng cao bản trình bày với hình ảnh động trong các tệp PPT và PPTX—bắt đầu ngay."
---
## **Giới thiệu**

Aspose.Slides for Java hỗ trợ việc tạo hoạt ảnh cho các thành phần biểu đồ. **Series**, **Categories**, **Series Elements**, **Categories Elements** có thể được tạo hoạt ảnh bằng phương thức [ISequence.addEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) và hai enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/EffectChartMajorGroupingType) và [EffectChartMinorGroupingType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/EffectChartMinorGroupingType).

## **Hoạt ảnh chuỗi biểu đồ**
Nếu bạn muốn tạo hoạt ảnh cho một chuỗi biểu đồ, hãy viết mã theo các bước được liệt kê dưới đây:

1. Tải một bản trình bày.
1. Lấy tham chiếu của đối tượng biểu đồ.
1. Tạo hoạt ảnh cho chuỗi.
1. Ghi tệp bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho chuỗi biểu đồ.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Lấy tham chiếu của đối tượng biểu đồ
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Tạo hoạt ảnh cho chuỗi
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Ghi bản trình bày đã sửa đổi ra đĩa
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hoạt ảnh danh mục biểu đồ**
Nếu bạn muốn tạo hoạt ảnh cho một danh mục biểu đồ, hãy viết mã theo các bước được liệt kê dưới đây:

1. Tải một bản trình bày.
1. Lấy tham chiếu của đối tượng biểu đồ.
1. Tạo hoạt ảnh cho danh mục.
1. Ghi tệp bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho danh mục biểu đồ.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hoạt ảnh trong một phần tử chuỗi**
Nếu bạn muốn tạo hoạt ảnh cho các phần tử chuỗi, hãy viết mã theo các bước được liệt kê dưới đây:

1. Tải một bản trình bày.
1. Lấy tham chiếu của đối tượng biểu đồ.
1. Tạo hoạt ảnh cho các phần tử chuỗi.
1. Ghi tệp bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho các phần tử của chuỗi.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Lấy tham chiếu của đối tượng biểu đồ
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Tạo hoạt ảnh cho các phần tử chuỗi
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Ghi tệp bản trình bày ra đĩa 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hoạt ảnh trong một phần tử danh mục**
Nếu bạn muốn tạo hoạt ảnh cho các phần tử danh mục, hãy viết mã theo các bước được liệt kê dưới đây:

1. Tải một bản trình bày.
1. Lấy tham chiếu của đối tượng biểu đồ.
1. Tạo hoạt ảnh cho các phần tử danh mục.
1. Ghi tệp bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho các phần tử danh mục.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Lấy tham chiếu của đối tượng biểu đồ
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Tạo hoạt ảnh cho các phần tử danh mục
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Ghi tệp bản trình bày ra đĩa
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Các loại hiệu ứng khác nhau (ví dụ: xuất hiện, nhấn mạnh, thoát) có được hỗ trợ cho biểu đồ như đối với các hình dạng thông thường không?**

Có. Biểu đồ được coi là một hình dạng, do đó nó hỗ trợ các loại hiệu ứng hoạt ảnh tiêu chuẩn, bao gồm xuất hiện, nhấn mạnh và thoát, với khả năng kiểm soát đầy đủ thông qua dòng thời gian và chuỗi hoạt ảnh của slide.

**Tôi có thể kết hợp hoạt ảnh biểu đồ với chuyển tiếp slide không?**

Có. [Transitions](/slides/vi/java/slide-transition/) áp dụng cho slide, trong khi các hiệu ứng hoạt ảnh áp dụng cho các đối tượng trên slide. Bạn có thể sử dụng cả hai cùng nhau trong cùng một bản trình bày và kiểm soát chúng một cách độc lập.

**Các hoạt ảnh biểu đồ có được giữ nguyên khi lưu dưới dạng PPTX không?**

Có. Khi bạn [save to PPTX](/slides/vi/java/save-presentation/), tất cả các hiệu ứng hoạt ảnh và thứ tự của chúng được giữ nguyên vì chúng là một phần của mô hình hoạt ảnh gốc của bản trình bày.

**Tôi có thể đọc các hoạt ảnh biểu đồ hiện có từ một bản trình bày và chỉnh sửa chúng không?**

Có. API cung cấp quyền truy cập vào dòng thời gian slide, các chuỗi và hiệu ứng, cho phép bạn kiểm tra các hoạt ảnh biểu đồ hiện có và điều chỉnh chúng mà không cần tạo lại mọi thứ từ đầu.

**Tôi có thể tạo video bao gồm các hoạt ảnh biểu đồ bằng Aspose.Slides không?**

Có. Bạn có thể [export a presentation to video](/slides/vi/java/convert-powerpoint-to-video/) trong khi vẫn giữ nguyên các hoạt ảnh, cấu hình thời gian và các cài đặt xuất khác để đoạn video cuối cùng phản ánh việc phát lại có hoạt ảnh.