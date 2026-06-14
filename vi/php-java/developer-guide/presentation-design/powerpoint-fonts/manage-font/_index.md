---
title: Quản lý phông chữ trong bản trình bày bằng PHP
linktitle: Quản lý Phông chữ
type: docs
weight: 10
url: /vi/php-java/manage-fonts/
keywords:
  - quản lý phông chữ
  - thuộc tính phông chữ
  - đoạn
  - định dạng văn bản
  - PowerPoint
  - OpenDocument
  - bản trình bày
  - PHP
  - Aspose.Slides
description: "Kiểm soát phông chữ trong PHP bằng Aspose.Slides: nhúng, thay thế và tải phông chữ tùy chỉnh để giữ cho các bản trình bày PPT, PPTX và ODP rõ ràng, an toàn thương hiệu và nhất quán."
---
## **Quản lý các thuộc tính liên quan đến phông chữ**
{{% alert color="primary" %}} 

Các bản trình bày thường chứa cả văn bản và hình ảnh. Văn bản có thể được định dạng theo nhiều cách khác nhau, để làm nổi bật các phần và từ cụ thể hoặc để tuân thủ phong cách công ty. Định dạng văn bản giúp người dùng thay đổi giao diện và cảm giác của nội dung bản trình bày. Bài viết này cho thấy cách sử dụng Aspose.Slides for PHP via Java để cấu hình các thuộc tính phông chữ của các đoạn văn bản trên các slide.

{{% /alert %}} 

Để quản lý các thuộc tính phông chữ của một đoạn văn bản bằng cách sử dụng Aspose.Slides for PHP via Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) .
2. Lấy tham chiếu của slide bằng cách sử dụng chỉ mục của nó.
3. Truy cập các hình dạng [Placeholder](https://reference.aspose.com/slides/vi/php-java/aspose.slides/placeholder/) trong slide và chuyển kiểu chúng thành [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) .
4. Lấy [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) từ [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) được hiển thị bởi [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) .
5. Căn chỉnh đoạn văn.
6. Truy cập [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) văn bản của một [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) .
7. Xác định phông chữ bằng cách sử dụng [FontData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontdata/) và đặt **Font** cho [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) văn bản tương ứng.
   1. Đặt phông chữ thành in đậm.
   1. Đặt phông chữ thành in nghiêng.
8. Đặt màu phông chữ bằng cách sử dụng [FillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/) được hiển thị bởi đối tượng [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) .
9. Lưu bản trình bày đã chỉnh sửa thành tệp PPTX.

Việc thực hiện các bước trên được trình bày dưới đây. Nó nhận một bản trình bày chưa được định dạng và thiết lập phông chữ trên một trong các slide. Các ảnh chụp màn hình bên dưới cho thấy tệp đầu vào và cách các đoạn mã thay đổi nó. Mã thay đổi phông chữ, màu và kiểu phông chữ.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Hình: Văn bản trong tệp đầu vào**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Hình: Văn bản với định dạng đã cập nhật**|

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Truy cập slide bằng vị trí slide của nó
    $slide = $pres->getSlides()->get_Item(0);
    # Truy cập placeholder đầu tiên và thứ hai trong slide và ép kiểu thành AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Truy cập đoạn văn đầu tiên
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Căn chỉnh đoạn văn
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Truy cập phần đầu tiên
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Xác định phông chữ mới
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Gán phông chữ mới cho phần
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Đặt phông chữ in đậm
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Đặt phông chữ in nghiêng
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Đặt màu phông chữ
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Lưu PPTX vào đĩa
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt các thuộc tính phông chữ cho văn bản**
{{% alert color="primary" %}} 

Như đã đề cập trong **Quản lý các thuộc tính liên quan đến phông chữ**, một [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) được dùng để chứa văn bản có cùng kiểu định dạng trong một đoạn. Bài viết này cho thấy cách sử dụng Aspose.Slides for PHP via Java để tạo một hộp văn bản chứa một số văn bản và sau đó xác định một phông chữ cụ thể, cùng các thuộc tính khác của họ font.

{{% /alert %}} 

Để tạo một hộp văn bản và đặt các thuộc tính phông chữ của văn bản trong đó:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) .
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
3. Thêm một [AutoShape] loại **Rectangle** vào slide.
4. Xóa kiểu đổ màu liên quan tới [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) .
5. Truy cập [TextFrame] của [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) .
6. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) .
7. Truy cập đối tượng [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) liên kết với [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) .
8. Xác định phông chữ sẽ được sử dụng cho [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) .
9. Đặt các thuộc tính phông chữ khác như in đậm, in nghiêng, gạch chân, màu và độ cao bằng cách sử dụng các thuộc tính tương ứng được cung cấp bởi đối tượng [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) .
10. Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.

Việc thực hiện các bước trên được trình bày dưới đây.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Hình: Văn bản với một số thuộc tính phông chữ được thiết lập bởi Aspose.Slides for PHP via Java**|

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm một AutoShape kiểu Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Xóa bất kỳ kiểu đổ màu nào liên quan tới AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Truy cập TextFrame liên kết với AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Truy cập Portion liên kết với TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Đặt Font cho Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Đặt thuộc tính Bold cho Font
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Đặt thuộc tính Italic cho Font
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Đặt thuộc tính Underline cho Font
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Đặt độ cao cho Font
    $port->getPortionFormat()->setFontHeight(25);
    # Đặt màu cho Font
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Lưu bản trình bày vào đĩa
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```