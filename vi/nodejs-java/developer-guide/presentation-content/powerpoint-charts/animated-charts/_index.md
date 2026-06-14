---
title: Tạo hoạt ảnh cho biểu đồ PowerPoint trong JavaScript
linktitle: Biểu đồ Động
type: docs
weight: 80
url: /vi/nodejs-java/animated-charts/
keywords:
- biểu đồ
- biểu đồ động
- hoạt ảnh biểu đồ
- chuỗi biểu đồ
- danh mục biểu đồ
- phần tử chuỗi
- phần tử danh mục
- thêm hiệu ứng
- loại hiệu ứng
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo các biểu đồ động ấn tượng trong JavaScript bằng Aspose.Slides cho Node.js. Nâng cao bản trình chiếu với hình ảnh động trong các tệp PPT và PPTX—bắt đầu ngay."
---
## **Giới thiệu**

Aspose.Slides for Node.js via Java hỗ trợ tạo hoạt ảnh cho các phần tử biểu đồ. **Series**, **Categories**, **Series Elements**, **Categories Elements** có thể được tạo hoạt ảnh bằng phương thức [Sequence.addEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/#addEffect) và hai enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effectchartmajorgroupingtype/) và [EffectChartMinorGroupingType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effectchartminorgroupingtype/).

## **Hoạt ảnh chuỗi biểu đồ**
Nếu bạn muốn tạo hoạt ảnh cho một chuỗi biểu đồ, hãy viết mã theo các bước được liệt kê dưới đây:

1. Tải một bản trình chiếu.  
2. Lấy tham chiếu đến đối tượng biểu đồ.  
3. Tạo hoạt ảnh cho chuỗi.  
4. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho chuỗi biểu đồ.

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Lấy tham chiếu đến đối tượng biểu đồ
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Tạo hoạt ảnh cho chuỗi
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Ghi bản trình chiếu đã sửa đổi ra đĩa
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hoạt ảnh danh mục biểu đồ**
Nếu bạn muốn tạo hoạt ảnh cho một danh mục biểu đồ, hãy viết mã theo các bước được liệt kê dưới đây:

1. Tải một bản trình chiếu.  
2. Lấy tham chiếu đến đối tượng biểu đồ.  
3. Tạo hoạt ảnh cho danh mục.  
4. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho danh mục biểu đồ.

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    pres.save("Sample_Animation_C.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hoạt ảnh trong phần tử chuỗi**
Nếu bạn muốn tạo hoạt ảnh cho các phần tử chuỗi, hãy viết mã theo các bước được liệt kê dưới đây:

1. Tải một bản trình chiếu.  
2. Lấy tham chiếu đến đối tượng biểu đồ.  
3. Tạo hoạt ảnh cho các phần tử chuỗi.  
4. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho các phần tử của chuỗi.

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Lấy tham chiếu đến đối tượng biểu đồ
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Tạo hoạt ảnh cho các phần tử chuỗi
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Ghi tệp bản trình chiếu ra đĩa
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hoạt ảnh trong phần tử danh mục**
Nếu bạn muốn tạo hoạt ảnh cho các phần tử danh mục, hãy viết mã theo các bước được liệt kê dưới đây:

1. Tải một bản trình chiếu.  
2. Lấy tham chiếu đến đối tượng biểu đồ.  
3. Tạo hoạt ảnh cho các phần tử danh mục.  
4. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho các phần tử danh mục.

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Lấy tham chiếu đến đối tượng biểu đồ
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Tạo hoạt ảnh cho các phần tử danh mục
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Ghi tệp bản trình chiếu ra đĩa
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Các loại hiệu ứng khác nhau (ví dụ: xuất hiện, nhấn mạnh, thoát) có được hỗ trợ cho biểu đồ giống như các hình dạng thường không?**  
Có. Biểu đồ được coi là một hình dạng, vì vậy nó hỗ trợ các loại hiệu ứng hoạt ảnh tiêu chuẩn, bao gồm xuất hiện, nhấn mạnh và thoát, với khả năng kiểm soát đầy đủ thông qua dòng thời gian và các chuỗi hoạt ảnh của slide.

**Tôi có thể kết hợp hoạt ảnh biểu đồ với chuyển đổi slide không?**  
Có. [Transitions](/slides/vi/nodejs-java/slide-transition/) áp dụng cho slide, trong khi các hiệu ứng hoạt ảnh áp dụng cho các đối tượng trên slide. Bạn có thể sử dụng cả hai cùng nhau trong cùng một bản trình chiếu và kiểm soát chúng một cách độc lập.

**Các hoạt ảnh biểu đồ có được giữ lại khi lưu thành PPTX không?**  
Có. Khi bạn [save to PPTX](/slides/vi/nodejs-java/save-presentation/), tất cả các hiệu ứng hoạt ảnh và thứ tự của chúng được giữ nguyên vì chúng là một phần của mô hình hoạt ảnh gốc của bản trình chiếu.

**Tôi có thể đọc các hoạt ảnh biểu đồ hiện có từ một bản trình chiếu và chỉnh sửa chúng không?**  
Có. API cung cấp quyền truy cập vào dòng thời gian slide, các chuỗi và hiệu ứng, cho phép bạn kiểm tra các hoạt ảnh biểu đồ hiện có và điều chỉnh chúng mà không cần tạo lại mọi thứ từ đầu.

**Tôi có thể tạo video bao gồm các hoạt ảnh biểu đồ bằng Aspose.Slides không?**  
Có. Bạn có thể [export a presentation to video](/slides/vi/nodejs-java/convert-powerpoint-to-video/) trong khi giữ lại các hoạt ảnh, cấu hình thời gian và các cài đặt xuất khác để đoạn video kết quả phản ánh việc phát hoạt ảnh.