---
title: Tạo hoạt ảnh cho biểu đồ PowerPoint trong PHP
linktitle: Biểu đồ động
type: docs
weight: 80
url: /vi/php-java/animated-charts/
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
- PHP
- Aspose.Slides
description: "Tạo các biểu đồ động tuyệt đẹp với Aspose.Slides cho PHP thông qua Java. Nâng cao các bản trình chiếu với hình ảnh động trong các tệp PPT và PPTX — bắt đầu ngay."
---
## **Giới thiệu**

Aspose.Slides cho PHP thông qua Java hỗ trợ tạo hoạt ảnh cho các thành phần biểu đồ. **Series**, **Categories**, **Series Elements**, **Categories Elements** có thể được tạo hoạt ảnh bằng phương thức [Sequence::addEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sequence/#addEffect) và hai enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/EffectChartMajorGroupingType) và [EffectChartMinorGroupingType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/EffectChartMinorGroupingType).

## **Hoạt ảnh chuỗi biểu đồ**
Nếu bạn muốn tạo hoạt ảnh cho một chuỗi biểu đồ, viết mã theo các bước được liệt kê dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Tạo hoạt ảnh cho chuỗi.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho chuỗi biểu đồ.

```php
  # Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Lấy tham chiếu tới đối tượng biểu đồ
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Tạo hoạt ảnh cho chuỗi
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Ghi bản trình chiếu đã sửa vào đĩa
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hoạt ảnh danh mục biểu đồ**
Nếu bạn muốn tạo hoạt ảnh cho một danh mục biểu đồ, viết mã theo các bước được liệt kê dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Tạo hoạt ảnh cho danh mục.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho danh mục biểu đồ.

```php
  # Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hoạt ảnh trong phần tử Series**
Nếu bạn muốn tạo hoạt ảnh cho các phần tử series, viết mã theo các bước được liệt kê dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Tạo hoạt ảnh cho các phần tử series.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho các phần tử của series.

```php
  # Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Lấy tham chiếu tới đối tượng biểu đồ
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Tạo hoạt ảnh cho các phần tử series
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Ghi tệp bản trình chiếu ra đĩa
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hoạt ảnh trong phần tử danh mục**
Nếu bạn muốn tạo hoạt ảnh cho các phần tử danh mục, viết mã theo các bước được liệt kê dưới đây:

1. Tải một bản trình chiếu.
1. Lấy tham chiếu tới đối tượng biểu đồ.
1. Tạo hoạt ảnh cho các phần tử danh mục.
1. Ghi tệp bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã tạo hoạt ảnh cho các phần tử danh mục.

```php
  # Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Lấy tham chiếu tới đối tượng biểu đồ
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Tạo hoạt ảnh cho các phần tử danh mục
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Ghi tệp bản trình chiếu ra đĩa
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Các loại hiệu ứng khác nhau (ví dụ: vào, nhấn mạnh, ra) có được hỗ trợ cho biểu đồ như các hình dạng thường không?**  
Có. Biểu đồ được coi như một hình dạng, do đó nó hỗ trợ các loại hiệu ứng hoạt ảnh tiêu chuẩn, bao gồm vào, nhấn mạnh và ra, với khả năng kiểm soát đầy đủ thông qua dòng thời gian và các chuỗi hoạt ảnh của slide.

**Tôi có thể kết hợp hoạt ảnh biểu đồ với chuyển tiếp slide không?**  
Có. [Chuyển tiếp](/slides/vi/php-java/slide-transition/) áp dụng cho slide, trong khi các hiệu ứng hoạt ảnh áp dụng cho các đối tượng trên slide. Bạn có thể sử dụng cả hai đồng thời trong cùng một bản trình chiếu và kiểm soát chúng một cách độc lập.

**Các hoạt ảnh biểu đồ có được giữ nguyên khi lưu dưới dạng PPTX không?**  
Có. Khi bạn [Lưu dưới dạng PPTX](/slides/vi/php-java/save-presentation/), tất cả các hiệu ứng hoạt ảnh và thứ tự của chúng được giữ lại vì chúng là một phần của mô hình hoạt ảnh gốc của bản trình chiếu.

**Tôi có thể đọc các hoạt ảnh biểu đồ hiện có từ một bản trình chiếu và chỉnh sửa chúng không?**  
Có. API cung cấp quyền truy cập vào dòng thời gian của slide, các chuỗi và hiệu ứng, cho phép bạn kiểm tra các hoạt ảnh biểu đồ hiện có và điều chỉnh chúng mà không cần tạo lại toàn bộ từ đầu.

**Tôi có thể tạo video bao gồm các hoạt ảnh biểu đồ bằng Aspose.Slides không?**  
Có. Bạn có thể [Xuất bản trình chiếu thành video](/slides/vi/php-java/convert-powerpoint-to-video/) đồng thời giữ lại các hoạt ảnh, cấu hình thời gian và các cài đặt xuất khác để đoạn video kết quả phản ánh việc phát lại có hoạt ảnh.