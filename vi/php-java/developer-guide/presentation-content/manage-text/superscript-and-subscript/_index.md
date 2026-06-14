---
title: Quản lý Chỉ số trên và Chỉ số dưới trong Bản trình bày sử dụng PHP
linktitle: Chỉ số trên và Chỉ số dưới
type: docs
weight: 80
url: /vi/php-java/superscript-and-subscript/
keywords:
- chỉ số trên
- chỉ số dưới
- thêm chỉ số trên
- thêm chỉ số dưới
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Nắm vững chỉ số trên và chỉ số dưới trong Aspose.Slides cho PHP thông qua Java và nâng cao bản trình bày của bạn với định dạng văn bản chuyên nghiệp để đạt tối đa hiệu quả."
---
## **Tổng quan**

Aspose.Slides cung cấp các tính năng để tích hợp văn bản chỉ số trên và chỉ số dưới vào bản trình bày PowerPoint (PPT, PPTX) và OpenDocument (ODP) của bạn. Cho dù bạn cần làm nổi bật công thức hoá học, phương trình toán học, hay chú thích nội dung bằng ghi chú chân trang, các tùy chọn định dạng chuyên biệt này giúp duy trì độ rõ ràng và chính xác. Trong bài viết này, bạn sẽ học cách áp dụng phong cách chỉ số trên và chỉ số dưới một cách liền mạch và đảm bảo kết quả chuyên nghiệp cho mỗi slide.

## **Quản lý văn bản chỉ số trên và chỉ số dưới**
Bạn có thể thêm văn bản chỉ số trên hoặc chỉ số dưới trong bất kỳ phần đoạn văn nào. Để thêm văn bản Superscript hoặc Subscript trong khung văn bản Aspose.Slides, bạn phải sử dụng phương thức [**setEscapement**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setEscapement) của lớp [PortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PortionFormat).

Thuộc tính này trả về hoặc thiết lập văn bản chỉ số trên hoặc chỉ số dưới (giá trị từ -100 % (chỉ số dưới) đến 100 % (chỉ số trên)). Ví dụ:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
- Lấy tham chiếu đến một slide bằng cách sử dụng Index của nó.
- Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) có loại [Rectangle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ShapeType#Rectangle) vào slide.
- Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) liên kết với [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/).
- Xóa các Paragraph hiện có.
- Tạo một đối tượng paragraph mới để giữ văn bản chỉ số trên và thêm nó vào bộ sưu tập [IParagraphs](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParagraphs) của [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/).
- Tạo một đối tượng portion mới.
- Đặt thuộc tính Escapement cho portion trong khoảng 0 đến 100 để thêm chỉ số trên. (0 có nghĩa là không có chỉ số trên)
- Đặt một đoạn văn bản cho [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Portion) và sau đó thêm nó vào bộ sưu tập portion của paragraph.
- Tạo một đối tượng paragraph mới để giữ văn bản chỉ số dưới và thêm nó vào bộ sưu tập IParagraphs của ITextFrame.
- Tạo một đối tượng portion mới.
- Đặt thuộc tính Escapement cho portion trong khoảng 0 đến -100 để thêm chỉ số dưới. (0 có nghĩa là không có chỉ số dưới)
- Đặt một đoạn văn bản cho [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Portion) và sau đó thêm nó vào bộ sưu tập portion của paragraph.
- Lưu bản trình bày dưới dạng tệp PPTX.

Cách thực hiện các bước trên được đưa ra dưới đây.

```php
  # Khởi tạo lớp Presentation đại diện cho một tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide
    $slide = $pres->getSlides()->get_Item(0);
    # Tạo hộp văn bản
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Tạo đoạn văn cho văn bản chỉ số trên
    $superPar = new Paragraph();
    # Tạo phần với văn bản thông thường
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Tạo phần với văn bản chỉ số trên
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Tạo đoạn văn cho văn bản chỉ số dưới
    $paragraph2 = new Paragraph();
    # Tạo phần với văn bản thông thường
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Tạo phần với văn bản chỉ số dưới
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Thêm các đoạn văn vào hộp văn bản
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Chỉ số trên và chỉ số dưới có được giữ nguyên khi xuất sang PDF hoặc các định dạng khác không?**

Có, Aspose.Slides giữ đúng định dạng chỉ số trên và chỉ số dưới khi xuất bản trình bày sang PDF, PPT/PPTX, hình ảnh và các định dạng hỗ trợ khác. Định dạng chuyên biệt này vẫn nguyên vẹn trong mọi tệp đầu ra.

**Có thể kết hợp chỉ số trên và chỉ số dưới với các kiểu định dạng khác như in đậm hoặc in nghiêng không?**

Có, Aspose.Slides cho phép bạn kết hợp nhiều kiểu văn bản trong cùng một portion. Bạn có thể bật in đậm, in nghiêng, gạch dưới và đồng thời áp dụng chỉ số trên hoặc chỉ số dưới bằng cách cấu hình các thuộc tính tương ứng trong [PortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/).

**Định dạng chỉ số trên và chỉ số dưới có hoạt động cho văn bản trong bảng, biểu đồ hoặc SmartArt không?**

Có, Aspose.Slides hỗ trợ định dạng trong hầu hết các đối tượng, bao gồm các phần tử bảng và biểu đồ. Khi làm việc với SmartArt, bạn cần truy cập các phần tử thích hợp (chẳng hạn như [SmartArtNode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartnode/)) và các vùng chứa văn bản của chúng, sau đó cấu hình các thuộc tính [PortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/) theo cách tương tự.