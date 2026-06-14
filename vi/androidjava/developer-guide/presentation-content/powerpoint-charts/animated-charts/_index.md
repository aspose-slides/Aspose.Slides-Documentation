---
title: Tạo hoạt ảnh cho biểu đồ PowerPoint trên Android
linktitle: Biểu đồ hoạt ảnh
type: docs
weight: 80
url: /vi/androidjava/animated-charts/
keywords:
- biểu đồ
- biểu đồ hoạt ảnh
- hoạt ảnh biểu đồ
- chuỗi biểu đồ
- danh mục biểu đồ
- phần tử chuỗi
- phần tử danh mục
- thêm hiệu ứng
- loại hiệu ứng
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tạo các biểu đồ hoạt ảnh ấn tượng trong Java với Aspose.Slides cho Android. Nâng cao bản trình chiếu với hình ảnh động trong các tệp PPT và PPTX—bắt đầu ngay."
---
## **Giới thiệu**

Aspose.Slides for Android via Java hỗ trợ việc tạo hoạt ảnh cho các thành phần biểu đồ. **Series**, **Categories**, **Series Elements**, **Categories Elements** có thể được tạo hoạt ảnh bằng phương thức [ISequence.addEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) và hai enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/EffectChartMajorGroupingType) và [EffectChartMinorGroupingType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/EffectChartMinorGroupingType).

## **Hoạt ảnh Series biểu đồ**
Nếu bạn muốn tạo hoạt ảnh cho một series biểu đồ, viết mã theo các bước dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Tạo hoạt ảnh cho series.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho series biểu đồ.

```java
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Lấy tham chiếu tới đối tượng biểu đồ
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Tạo hoạt ảnh cho series
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

    // Ghi bản trình chiếu đã chỉnh sửa ra đĩa
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hoạt ảnh Danh mục biểu đồ**
Nếu bạn muốn tạo hoạt ảnh cho một series biểu đồ, viết mã theo các bước dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Tạo hoạt ảnh cho Danh mục.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho danh mục biểu đồ.

```java
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu
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

## **Hoạt ảnh trong phần tử Series**
Nếu bạn muốn tạo hoạt ảnh cho các phần tử series, viết mã theo các bước dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Tạo hoạt ảnh cho các phần tử series.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho các phần tử của series.

```java
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Lấy tham chiếu tới đối tượng biểu đồ
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Tạo hoạt ảnh cho các phần tử series
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

    // Ghi tệp trình chiếu ra đĩa 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hoạt ảnh trong phần tử Category**
Nếu bạn muốn tạo hoạt ảnh cho các phần tử category, viết mã theo các bước dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Tạo hoạt ảnh cho các phần tử category.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho các phần tử category.

```java
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Lấy tham chiếu tới đối tượng biểu đồ
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Tạo hoạt ảnh cho các phần tử của danh mục
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

    // Ghi tệp trình chiếu ra đĩa
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Các loại hiệu ứng khác nhau (ví dụ: entrance, emphasis, exit) có được hỗ trợ cho biểu đồ giống như các hình dạng thông thường không?**

Có. Biểu đồ được coi như một hình dạng, vì vậy nó hỗ trợ các loại hiệu ứng hoạt ảnh tiêu chuẩn, bao gồm entrance, emphasis và exit, với khả năng kiểm soát đầy đủ qua thời gian biểu của slide và các chuỗi hoạt ảnh.

**Tôi có thể kết hợp hoạt ảnh biểu đồ với chuyển đổi slide không?**

Có. [Transitions](/slides/vi/androidjava/slide-transition/) áp dụng cho slide, trong khi các hiệu ứng hoạt ảnh áp dụng cho các đối tượng trên slide. Bạn có thể sử dụng cả hai trong cùng một bản trình chiếu và kiểm soát chúng một cách độc lập.

**Các hoạt ảnh biểu đồ có được giữ lại khi lưu dưới dạng PPTX không?**

Có. Khi bạn [save to PPTX](/slides/vi/androidjava/save-presentation/), tất cả các hiệu ứng hoạt ảnh và thứ tự của chúng được giữ nguyên vì chúng là một phần của mô hình hoạt ảnh gốc của bản trình chiếu.

**Tôi có thể đọc các hoạt ảnh biểu đồ hiện có từ một bản trình chiếu và chỉnh sửa chúng không?**

Có. API cung cấp quyền truy cập vào thời gian biểu của slide, các chuỗi và hiệu ứng, cho phép bạn kiểm tra các hoạt ảnh biểu đồ hiện có và điều chỉnh chúng mà không cần tạo lại toàn bộ từ đầu.

**Tôi có thể tạo video có chứa hoạt ảnh biểu đồ bằng Aspose.Slides không?**

Có. Bạn có thể [export a presentation to video](/slides/vi/androidjava/convert-powerpoint-to-video/) trong khi giữ nguyên các hoạt ảnh, cấu hình thời gian và các cài đặt xuất khác để đoạn video kết quả phản ánh đúng quá trình phát hoạt ảnh.