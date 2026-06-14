---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong bài thuyết trình bằng PHP
linktitle: Bảng Dữ liệu
type: docs
url: /vi/php-java/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tùy chỉnh bảng dữ liệu biểu đồ cho PPT và PPTX với Aspose.Slides for PHP via Java để tăng hiệu quả và sức hấp dẫn trong các bài thuyết trình."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với bảng dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách hiển thị bảng dữ liệu cho một biểu đồ và tùy chỉnh định dạng văn bản bằng cách đặt các thuộc tính phông chữ như kiểu in đậm và kích thước phông. Ví dụ minh họa quá trình tải một presentation, thêm biểu đồ, bật bảng dữ liệu biểu đồ, áp dụng cài đặt phông và lưu lại presentation đã cập nhật.

Nó cũng bao gồm các câu trả lời ngắn gọn cho những câu hỏi thường gặp về việc hiển thị phím chú giải trong bảng dữ liệu biểu đồ, bảo tồn bảng dữ liệu khi xuất, làm việc với các biểu đồ được tải từ presentation hoặc mẫu hiện có, và xác định các biểu đồ có bảng dữ liệu được bật.

## **Đặt Thuộc Tính Font cho Bảng Dữ Liệu Biểu Đồ**
Aspose.Slides for PHP via Java cung cấp hỗ trợ việc thay đổi màu của các danh mục trong màu chuỗi.  

1. Tạo một đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Thêm biểu đồ vào slide.
1. Đặt bảng dữ liệu cho biểu đồ.
1. Đặt kích thước phông.
1. Lưu presentation đã sửa đổi.

Ví dụ mẫu dưới đây được đưa ra.  

```php
  # Tạo bản trình chiếu trống
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Tôi có thể hiển thị các phím chú giải nhỏ cạnh các giá trị trong bảng dữ liệu của biểu đồ không?**

Có. Bảng dữ liệu hỗ trợ [phím chú giải](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datatable/setshowlegendkey/), và bạn có thể bật hoặc tắt chúng.

**Bảng dữ liệu có được bảo tồn khi xuất presentation sang PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides render biểu đồ như một phần của slide, vì vậy [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/vi/php-java/convert-powerpoint-to-html/)/[image](/slides/vi/php-java/convert-powerpoint-to-png/) xuất ra sẽ bao gồm biểu đồ cùng bảng dữ liệu của nó.

**Bảng dữ liệu có được hỗ trợ cho các biểu đồ được tạo từ tệp mẫu không?**

Có. Đối với bất kỳ biểu đồ nào được tải từ một presentation hoặc mẫu hiện có, bạn có thể kiểm tra và thay đổi việc bảng dữ liệu [được hiển thị](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/hasdatatable/) bằng cách sử dụng các thuộc tính của biểu đồ.

**Làm thế nào để nhanh chóng tìm ra các biểu đồ trong tệp có bảng dữ liệu được bật?**

Kiểm tra thuộc tính của mỗi biểu đồ cho biết bảng dữ liệu [được hiển thị](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/hasdatatable/) và duyệt qua các slide để xác định các biểu đồ mà tính năng này được bật.