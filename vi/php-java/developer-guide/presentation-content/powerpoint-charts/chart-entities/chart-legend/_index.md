---
title: Tùy chỉnh chú giải biểu đồ trong bản trình bày bằng PHP
linktitle: Chú giải biểu đồ
type: docs
url: /vi/php-java/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho PHP qua Java để tối ưu hóa các bản trình bày PowerPoint với định dạng chú giải được thiết kế riêng."
---
## **Tổng quan**

Aspose.Slides cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong bản trình bày PowerPoint. Bài viết này trình bày cách đặt vị trí và kích thước cho chú giải, đặt kích thước phông chữ cho toàn bộ chú giải và áp dụng định dạng cho một mục chú giải riêng lẻ.

Ngoài ra còn đề cập đến một số hành vi liên quan trong phần Câu hỏi thường gặp, bao gồm việc sử dụng chế độ không chồng lấn để khu vực vẽ có chỗ cho chú giải, cho phép nhãn chú giải dài tự quay lại hoặc sử dụng ngắt dòng, và để định dạng chú giải kế thừa từ chủ đề bản trình bày khi không áp dụng cài đặt văn bản và tô màu rõ ràng.

## **Định vị Chú giải**
Để đặt các thuộc tính của chú giải, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) .
- Lấy tham chiếu tới slide.
- Thêm một biểu đồ vào slide.
- Đặt các thuộc tính của chú giải.
- Ghi bản trình bày dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã đặt vị trí và kích thước cho chú giải biểu đồ.

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    # Lấy tham chiếu của slide
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm biểu đồ cột nhóm vào slide
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Đặt các thuộc tính của chú giải
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Ghi bản trình bày ra đĩa
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt kích thước phông chữ cho Chú giải**
Aspose.Slides for PHP qua Java cho phép các nhà phát triển đặt kích thước phông chữ cho chú giải. Vui lòng thực hiện các bước sau:

- Tạo thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) .
- Tạo biểu đồ mặc định.
- Đặt kích thước phông chữ.
- Đặt giá trị tối thiểu cho trục.
- Đặt giá trị tối đa cho trục.
- Ghi bản trình bày ra đĩa.

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt kích thước phông chữ cho một mục chú giải riêng lẻ**
Aspose.Slides for PHP qua Java cho phép các nhà phát triển đặt kích thước phông chữ cho các mục chú giải riêng lẻ. Vui lòng thực hiện các bước sau:

- Tạo thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) .
- Tạo biểu đồ mặc định.
- Truy cập mục chú giải.
- Đặt kích thước phông chữ.
- Đặt giá trị tối thiểu cho trục.
- Đặt giá trị tối đa cho trục.
- Ghi bản trình bày ra đĩa.

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Tôi có thể bật chú giải để biểu đồ tự động dành chỗ cho nó thay vì chồng lên không?**

Vâng. Sử dụng chế độ không chồng lấn ([setOverlay(false)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/legend/setoverlay/)); trong trường hợp này, khu vực vẽ sẽ thu nhỏ để chứa chú giải.

**Tôi có thể tạo nhãn chú giải nhiều dòng không?**

Vâng. Nhãn dài sẽ tự động xuống dòng khi không đủ chỗ; các ngắt dòng bắt buộc được hỗ trợ qua ký tự xuống dòng trong tên series.

**Làm thế nào để chú giải tuân theo bảng màu của chủ đề bản trình bày?**

Không đặt màu sắc/tô đầy/phông chữ cụ thể cho chú giải hoặc văn bản của nó. Chúng sẽ kế thừa từ chủ đề và sẽ tự động cập nhật khi thiết kế thay đổi.