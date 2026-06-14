---
title: Quản lý Hộp Văn Bản trong Bản Trình Bày bằng PHP
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
- bản trình bày
- PHP
- Aspose.Slides
description: "Aspose.Slides cho PHP giúp bạn dễ dàng tạo, chỉnh sửa và sao chép hộp văn bản trong các tệp PowerPoint và OpenDocument, nâng cao khả năng tự động hoá bản trình bày của bạn."
---
## **Giới thiệu**

Văn bản trên slide thường nằm trong hộp văn bản hoặc hình dạng. Do đó, để thêm văn bản vào một slide, bạn phải thêm một hộp văn bản và sau đó đặt một số văn bản vào trong hộp văn bản. Aspose.Slides cho PHP thông qua Java cung cấp lớp [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) cho phép bạn thêm một hình dạng chứa một số văn bản.

{{% alert title="Info" color="info" %}}

Aspose.Slides cũng cung cấp lớp [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) cho phép bạn thêm các hình dạng vào slide. Tuy nhiên, không phải tất cả các hình dạng được thêm thông qua lớp `Shape` đều có thể chứa văn bản. Nhưng các hình dạng được thêm thông qua lớp [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) có thể chứa văn bản.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Do đó, khi làm việc với một hình dạng mà bạn muốn thêm văn bản, bạn có thể muốn kiểm tra và xác nhận rằng nó đã được ép kiểu qua lớp `AutoShape`. Chỉ khi đó bạn mới có thể làm việc với [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/), là một thuộc tính của `AutoShape`. Xem phần [Update Text](/slides/vi/php-java/manage-textbox/#update-text) trên trang này.

{{% /alert %}}

## **Tạo một Hộp Văn Bản trên Slide**

Để tạo một hộp văn bản trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu tới slide đầu tiên trong bản trình bày mới tạo. 
3. Thêm một đối tượng [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) với loại hình dạng được đặt là [Rectangle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapetype/#Rectangle) tại vị trí chỉ định trên slide và lấy tham chiếu tới đối tượng `AutoShape` mới được thêm.
4. Thêm một `TextFrame` vào đối tượng `AutoShape` sẽ chứa văn bản. Trong ví dụ dưới đây, chúng tôi đã thêm văn bản này: *Aspose TextBox*
5. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`. 

Mã PHP này—một triển khai các bước trên—cho bạn thấy cách thêm văn bản vào slide:

```php
  # Khởi tạo Presentation
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên trong bản trình bày
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm AutoShape với loại đặt là Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Thêm TextFrame vào Rectangle
    $ashp->addTextFrame(" ");
    # Truy cập khung văn bản
    $txtFrame = $ashp->getTextFrame();
    # Tạo đối tượng Paragraph cho khung văn bản
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Tạo đối tượng Portion cho đoạn văn
    $portion = $para->getPortions()->get_Item(0);
    # Đặt Văn bản
    $portion->setText("Aspose TextBox");
    # Lưu bản trình bày vào đĩa
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kiểm tra Hình dạng Hộp Văn Bản**

Aspose.Slides cung cấp phương thức [isTextBox](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/istextbox/) từ lớp [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) , cho phép bạn kiểm tra các hình dạng và xác định hộp văn bản.

![Hộp văn bản và hình dạng](istextbox.png)

Mã PHP này cho bạn thấy cách kiểm tra xem một hình dạng có được tạo thành hộp văn bản hay không:

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Lưu ý rằng nếu bạn chỉ đơn giản thêm một autoshape bằng phương thức `addAutoShape` từ lớp [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/) , phương thức `isTextBox` của autoshape sẽ trả về `false`. Tuy nhiên, sau khi bạn thêm văn bản vào autoshape bằng phương thức `addTextFrame` hoặc `setText`, thuộc tính `isTextBox` sẽ trả về `true`.

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

## **Thêm Cột vào Hộp Văn Bản**

Aspose.Slides cung cấp các phương thức [setColumnCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/setcolumncount/) và [setColumnSpacing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/setcolumnspacing/) từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/) cho phép bạn thêm cột vào hộp văn bản. Bạn có thể chỉ định số cột trong một hộp văn bản và đặt khoảng cách giữa các cột tính bằng điểm.

Mã này minh họa thao tác đã mô tả:

```php
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên trong bản trình bày
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm AutoShape với loại đặt là Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Thêm TextFrame vào Rectangle
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Lấy định dạng văn bản của TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Xác định số cột trong TextFrame
    $format->setColumnCount(3);
    # Xác định khoảng cách giữa các cột
    $format->setColumnSpacing(10);
    # Lưu bản trình bày
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm Cột vào Khung Văn Bản**
Aspose.Slides cho PHP thông qua Java cung cấp phương thức [setColumnCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/setcolumncount/) từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/) cho phép bạn thêm cột trong khung văn bản. Thông qua thuộc tính này, bạn có thể chỉ định số cột mong muốn trong khung văn bản.

Mã PHP này cho bạn thấy cách thêm một cột vào trong khung văn bản:

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

## **Cập nhật Văn Bản**

Aspose.Slides cho phép bạn thay đổi hoặc cập nhật văn bản trong hộp văn bản hoặc tất cả các văn bản trong một bản trình bày. 

Mã PHP này minh họa một thao tác mà tất cả các văn bản trong bản trình bày được cập nhật hoặc thay đổi:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Kiểm tra xem hình dạng có hỗ trợ khung văn bản (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Duyệt qua các đoạn văn trong khung văn bản
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Duyệt qua mỗi phần trong đoạn văn
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Thay đổi văn bản

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Thay đổi định dạng

            }
          }
        }
      }
    }
    # Lưu bản trình bày đã chỉnh sửa
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm Hộp Văn Bản với Siêu liên kết** 

Bạn có thể chèn một liên kết vào bên trong hộp văn bản. Khi hộp văn bản được nhấp, người dùng sẽ được chuyển đến mở liên kết. 

Để thêm một hộp văn bản chứa liên kết, thực hiện các bước sau:

1. Tạo một thể hiện của lớp `Presentation`. 
2. Lấy tham chiếu tới slide đầu tiên trong bản trình bày mới tạo. 
3. Thêm một đối tượng `AutoShape` với `ShapeType` đặt là `Rectangle` tại vị trí chỉ định trên slide và lấy tham chiếu tới đối tượng AutoShape mới được thêm.
4. Thêm một `TextFrame` vào đối tượng `AutoShape` chứa *Aspose TextBox* làm văn bản mặc định. 
5. Khởi tạo lớp `HyperlinkManager`. 
6. Gán một siêu liên kết bằng phương thức [setExternalHyperlinkClick](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) liên kết với phần bạn muốn trong `TextFrame`.
7. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`. 

Mã PHP này—một triển khai các bước trên—cho bạn thấy cách thêm một hộp văn bản với siêu liên kết vào slide:

```php
  # Khởi tạo một lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên trong bản trình bày
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm một đối tượng AutoShape với loại đặt là Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Ép kiểu hình dạng thành AutoShape
    $pptxAutoShape = $shape;
    # Truy cập thuộc tính ITextFrame liên quan tới AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Thêm một số văn bản vào khung
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Đặt siêu liên kết cho văn bản phần
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Lưu bản trình bày PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa hộp văn bản và chỗ giữ chỗ văn bản khi làm việc với các slide mẫu là gì?**

Một [placeholder](/slides/vi/php-java/manage-placeholder/) thừa kế kiểu dáng/vị trí từ [master](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) và có thể được ghi đè trên [layouts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/), trong khi một hộp văn bản thường là một đối tượng độc lập trên một slide cụ thể và không thay đổi khi bạn chuyển đổi layout.

**Làm thế nào để thực hiện việc thay thế văn bản hàng loạt trên toàn bộ bản trình bày mà không ảnh hưởng đến văn bản trong biểu đồ, bảng và SmartArt?**

Hạn chế việc lặp lại của bạn chỉ vào các auto-shape có khung văn bản và loại bỏ các đối tượng nhúng ([charts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/vi/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/)) bằng cách duyệt các bộ sưu tập của chúng riêng biệt hoặc bỏ qua các loại đối tượng đó.