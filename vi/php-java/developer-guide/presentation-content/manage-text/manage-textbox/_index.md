---
title: Quản lý các Hộp Văn Bản trong Bản Trình Chiếu bằng PHP
linktitle: Quản lý Hộp Văn Bản
type: docs
weight: 20
url: /vi/php-java/manage-textbox/
keywords:
- hộp văn bản
- khung văn bản
- thêm văn bản
- cập nhật văn bản
- tạo hộp văn bản
- kiểm tra hộp văn bản
- thêm cột văn bản
- thêm siêu liên kết
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Aspose.Slides cho PHP giúp bạn dễ dàng tạo, chỉnh sửa và sao chép các hộp văn bản trong các tệp PowerPoint và OpenDocument, nâng cao khả năng tự động hoá bản trình chiếu của bạn."
---
## **Giới thiệu**

Các đoạn văn bản trên các slide thường nằm trong các hộp văn bản hoặc hình dạng. Do đó, để thêm văn bản vào một slide, bạn phải thêm một hộp văn bản và sau đó đặt một đoạn văn bản vào trong hộp. Aspose.Slides for PHP via Java cung cấp lớp [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) cho phép bạn thêm một hình dạng chứa một đoạn văn bản.

{{% alert title="Thông tin" color="info" %}}

Aspose.Slides cũng cung cấp lớp [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) cho phép bạn thêm các hình dạng vào slide. Tuy nhiên, không phải tất cả các hình dạng được thêm bằng lớp `Shape` đều có thể chứa văn bản. Các hình dạng được thêm bằng lớp [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) có thể chứa văn bản.

{{% /alert %}}

{{% alert title="Lưu ý" color="warning" %}} 

Do đó, khi làm việc với một hình dạng mà bạn muốn thêm văn bản, bạn nên kiểm tra và xác nhận rằng nó đã được ép kiểu qua lớp `AutoShape`. Chỉ khi đó bạn mới có thể làm việc với [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/), một thuộc tính của `AutoShape`. Xem phần [Cập nhật Văn bản](/slides/vi/php-java/manage-textbox/#update-text) trên trang này.

{{% /alert %}}

## **Tạo một Hộp Văn Bản trên Slide**

Để tạo một hộp văn bản trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).  
2. Lấy tham chiếu tới slide đầu tiên trong bản trình chiếu mới tạo.  
3. Thêm một đối tượng [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) với kiểu hình dạng được đặt thành [Rectangle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapetype/#Rectangle) tại vị trí xác định trên slide và lấy tham chiếu tới đối tượng `AutoShape` mới thêm.  
4. Thêm một `TextFrame` vào đối tượng `AutoShape` để chứa văn bản. Trong ví dụ dưới, chúng tôi đã thêm văn bản: *Aspose TextBox*  
5. Cuối cùng, ghi file PPTX thông qua đối tượng `Presentation`.  

Đoạn mã PHP—một triển khai của các bước trên—cho bạn thấy cách thêm văn bản vào một slide:

```php
  # Tạo một đối tượng Presentation
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên trong bản trình chiếu
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm một AutoShape với kiểu được đặt là Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Thêm TextFrame vào Rectangle
    $ashp->addTextFrame(" ");
    # Truy cập vào khung văn bản
    $txtFrame = $ashp->getTextFrame();
    # Tạo đối tượng Paragraph cho khung văn bản
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Tạo đối tượng Portion cho đoạn văn
    $portion = $para->getPortions()->get_Item(0);
    # Đặt văn bản
    $portion->setText("Aspose TextBox");
    # Lưu bản trình chiếu vào đĩa
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kiểm Tra Hình Dạng Hộp Văn Bản**

Aspose.Slides cung cấp phương thức [isTextBox](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/istextbox/) của lớp [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/), cho phép bạn kiểm tra các hình dạng và xác định các hộp văn bản.

![Hộp văn bản và hình dạng](istextbox.png)

Đoạn mã PHP dưới đây cho bạn thấy cách kiểm tra xem một hình dạng có được tạo dưới dạng hộp văn bản hay không:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Lưu ý rằng nếu bạn chỉ thêm một AutoShape bằng phương thức `addAutoShape` của lớp [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/), phương thức `isTextBox` của AutoShape sẽ trả về `false`. Tuy nhiên, sau khi bạn thêm văn bản vào AutoShape bằng phương thức `addTextFrame` hoặc `setText`, thuộc tính `isTextBox` sẽ trả về `true`.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() trả về false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() trả về true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() trả về false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() trả về true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() trả về false
$shape3->addTextFrame("");
// shape3->isTextBox() trả về false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() trả về false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() trả về false
```

## **Tìm Hình Dạng Chủ Sở hữu TextFrame**

Trong mã xử lý văn bản chung, bạn có thể nhận được một đối tượng [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) mà chưa biết trước đối tượng trình chiếu nào chứa nó. Sử dụng phương thức [TextFrame::getParentShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentShape) để quay lại hình dạng sở hữu [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/).

Đối với một TextFrame thuộc về một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) hoặc một hình dạng khác chứa văn bản, [TextFrame::getParentShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentShape) trả về chủ sở hữu và [TextFrame::getParentCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentCell) trả về `null`. Cả hai phương thức đều cung cấp điều hướng chỉ đọc, vì vậy việc gọi chúng không thay đổi quyền sở hữu. Luôn kiểm tra giá trị trả về bằng `java_is_null` trước khi truy cập hình dạng.

Đối với một ví dụ hoàn chỉnh xác định chủ sở hữu hình dạng và ô bảng, bao gồm cả các hình dạng liên quan đến nút SmartArt, xem phần [Tìm kiếm và Thay thế Văn bản](/slides/vi/php-java/search-and-replace-text/).

## **Thêm Cột vào Hộp Văn Bản**

Aspose.Slides cung cấp các phương thức [setColumnCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/setcolumncount/) và [setColumnSpacing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/setcolumnspacing/) của lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/) cho phép bạn thêm cột vào hộp văn bản. Bạn có thể chỉ định số lượng cột trong một hộp văn bản và đặt khoảng cách (đơn vị điểm) giữa các cột.

Đoạn mã sau minh họa thao tác đã mô tả:

```php
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên trong bản trình chiếu
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm một AutoShape với kiểu được đặt là Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Thêm TextFrame vào Rectangle
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Lấy định dạng văn bản của TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Xác định số lượng cột trong TextFrame
    $format->setColumnCount(3);
    # Xác định khoảng cách giữa các cột
    $format->setColumnSpacing(10);
    # Lưu bản trình chiếu
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm Cột vào Text Frame**

Aspose.Slides for PHP via Java cung cấp phương thức [setColumnCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/setcolumncount/) của lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/) cho phép bạn thêm cột trong TextFrame. Thông qua thuộc tính này, bạn có thể chỉ định số cột mong muốn trong một TextFrame.

Đoạn mã PHP dưới đây cho bạn thấy cách thêm một cột vào TextFrame:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cập nhật Văn bản**

Aspose.Slides cho phép bạn thay đổi hoặc cập nhật văn bản có trong một hộp văn bản hoặc tất cả các văn bản trong một bản trình chiếu.

Đoạn mã PHP dưới đây trình bày một thao tác mà trong đó tất cả các văn bản trong bản trình chiếu được cập nhật hoặc thay đổi:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Kiểm tra xem hình dạng có hỗ trợ khung văn bản (IAutoShape) không.
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Duyệt qua các đoạn trong khung văn bản
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Duyệt qua từng phần trong đoạn
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Thay đổi văn bản

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Thay đổi định dạng

            }
          }
        }
      }
    }
    # Lưu bản trình chiếu đã chỉnh sửa
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm Hộp Văn Bản có Siêu Liên Kết** 

Bạn có thể chèn một liên kết bên trong hộp văn bản. Khi người dùng nhấp vào hộp văn bản, họ sẽ được chuyển hướng tới liên kết.

 Để thêm một hộp văn bản chứa liên kết, thực hiện các bước sau:

1. Tạo một thể hiện của lớp `Presentation`.  
2. Lấy tham chiếu tới slide đầu tiên trong bản trình chiếu mới tạo.  
3. Thêm một đối tượng `AutoShape` với `ShapeType` được đặt thành `Rectangle` tại vị trí xác định trên slide và lấy tham chiếu tới đối tượng AutoShape vừa thêm.  
4. Thêm một `TextFrame` vào đối tượng `AutoShape` chứa *Aspose TextBox* làm văn bản mặc định.  
5. Khởi tạo lớp `HyperlinkManager`.  
6. Gán một siêu liên kết bằng phương thức [setExternalHyperlinkClick](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) cho phần bạn muốn trong `TextFrame`.  
7. Cuối cùng, ghi file PPTX thông qua đối tượng `Presentation`.  

Đoạn mã PHP—một triển khai của các bước trên—cho bạn thấy cách thêm một hộp văn bản có siêu liên kết vào slide:

```php
  # Khởi tạo một lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên trong bản trình chiếu
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm một đối tượng AutoShape với kiểu được đặt là Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Ép kiểu hình dạng sang AutoShape
    $pptxAutoShape = $shape;
    # Truy cập thuộc tính ITextFrame liên kết với AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Thêm một số văn bản vào khung
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Đặt siêu liên kết cho văn bản phần
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Lưu bản trình chiếu PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa hộp văn bản và placeholder văn bản khi làm việc với master slide là gì?**

Một [placeholder](/slides/vi/php-java/manage-placeholder/) kế thừa kiểu/định vị từ [master](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) và có thể bị ghi đè trên [layout](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/), trong khi một hộp văn bản thông thường là một đối tượng độc lập trên một slide cụ thể và không thay đổi khi bạn chuyển đổi layout.

**Làm thế nào để thực hiện thay thế văn bản hàng loạt trên toàn bộ bản trình chiếu mà không ảnh hưởng tới văn bản trong biểu đồ, bảng và SmartArt?**

Hạn chế việc duyệt qua các auto‑shape có TextFrame và loại trừ các đối tượng nhúng ([chart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/), [table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/)) bằng cách duyệt riêng các bộ sưu tập của chúng hoặc bỏ qua các loại đối tượng này.