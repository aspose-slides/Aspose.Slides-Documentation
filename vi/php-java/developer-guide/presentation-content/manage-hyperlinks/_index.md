---
title: "Quản lý Siêu liên kết trong Bản trình bày bằng PHP"
linktitle: "Quản lý Siêu liên kết"
type: docs
weight: 20
url: /vi/php-java/manage-hyperlinks/
keywords:
- thêm URL
- thêm siêu liên kết
- tạo siêu liên kết
- định dạng siêu liên kết
- xóa siêu liên kết
- cập nhật siêu liên kết
- siêu liên kết văn bản
- siêu liên kết slide
- siêu liên kết hình dạng
- siêu liên kết hình ảnh
- siêu liên kết video
- siêu liên kết có thể thay đổi
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Quản lý siêu liên kết trong các bản trình bày PowerPoint và OpenDocument một cách dễ dàng với Aspose.Slides cho PHP thông qua Java — nâng cao tính tương tác và quy trình làm việc trong vài phút."
---
## **Giới thiệu**

Liên kết siêu văn bản là một tham chiếu đến một đối tượng, dữ liệu hoặc vị trí trong một tài liệu. Đây là các liên kết siêu văn bản phổ biến trong các bản trình bày PowerPoint:

* Liên kết đến các trang web trong văn bản, hình dạng hoặc phương tiện
* Liên kết đến các slide

Aspose.Slides for PHP via Java cho phép bạn thực hiện nhiều tác vụ liên quan đến liên kết siêu văn bản trong bản trình bày.

{{% alert color="primary" %}} 
Bạn có thể muốn xem trình chỉnh sửa PowerPoint trực tuyến miễn phí của Aspose, [trình chỉnh sửa PowerPoint trực tuyến miễn phí.](https://products.aspose.app/slides/vi/editor)
{{% /alert %}} 

## **Thêm Liên kết URL**

### **Thêm Liên kết URL vào Văn bản**

Mã PHP này cho bạn thấy cách thêm liên kết tới một trang web vào văn bản:
```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Thêm Liên kết URL vào Hình dạng hoặc Khung**

Mã mẫu này cho bạn thấy cách thêm liên kết tới một trang web vào một hình dạng:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Thêm Liên kết URL vào Phương tiện**

Aspose.Slides cho phép bạn thêm liên kết siêu văn bản vào các tệp hình ảnh, âm thanh và video.

Mã mẫu này cho bạn thấy cách thêm liên kết vào một **hình ảnh**:
```php
  $pres = new Presentation();
  try {
    # Thêm hình ảnh vào bản trình bày
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Tạo khung hình ảnh trên slide 1 dựa trên hình ảnh đã thêm trước đó
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Mã mẫu này cho bạn thấy cách thêm liên kết vào một **tệp âm thanh**:
```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "audio.mp3"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $audio = $pres->getAudios()->addAudio($bytes);

    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->addAudioFrameEmbedded(10, 10, 100, 100, $audio);
    $audioFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $audioFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Mã mẫu này cho bạn thấy cách thêm liên kết vào một **video**:
```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "video.avi"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $video = $pres->getVideos()->addVideo($bytes);

    $videoFrame = $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $videoFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $videoFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  title="Tip"  color="primary"  %}} 
Bạn có thể muốn xem *[Quản lý OLE](/slides/vi/php-java/manage-ole/)*.
{{% /alert %}}

## **Sử dụng Liên kết để Tạo Mục Lục**

Vì liên kết siêu văn bản cho phép bạn thêm tham chiếu đến các đối tượng hoặc vị trí, bạn có thể sử dụng chúng để tạo mục lục.

Mã mẫu này cho bạn thấy cách tạo mục lục với các liên kết siêu văn bản:
```php
  $pres = new Presentation();
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    $secondSlide = $pres->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());
    $contentTable = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $contentTable->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getTextFrame()->getParagraphs()->clear();
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);
    $paragraph->getPortions()->add($linkPortion);
    $contentTable->getTextFrame()->getParagraphs()->add($paragraph);
    $pres->save("link_to_slide.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Định dạng Liên kết**

### **Màu**

Với phương thức [setColorSource](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlink/setcolorsource/) trong lớp [Hyperlink](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlink/), bạn có thể đặt màu cho các liên kết siêu văn bản và cũng có thể lấy thông tin màu từ các liên kết siêu văn bản. Tính năng này lần đầu được giới thiệu trong PowerPoint 2019, vì vậy các thay đổi liên quan đến thuộc tính này sẽ không áp dụng cho các phiên bản PowerPoint cũ hơn.

Mã mẫu này minh họa một thao tác nơi các liên kết siêu văn bản với các màu khác nhau được thêm vào cùng một slide:
```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("This is a sample of colored hyperlink.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("This is a sample of usual hyperlink.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xóa Liên kết khỏi Bản trình bày**

### **Xóa Liên kết khỏi Văn bản**

Mã PHP này cho bạn thấy cách xóa liên kết khỏi văn bản trong một slide của bản trình bày:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $autoShape = $shape;
      if (!java_is_null($autoShape)) {
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          foreach($paragraph->getPortions() as $portion) {
            $portion->getPortionFormat()->getHyperlinkManager()->removeHyperlinkClick();
          }
        }
      }
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Xóa Liên kết khỏi Hình dạng hoặc Khung**

Mã PHP này cho bạn thấy cách xóa liên kết khỏi một hình dạng trong slide của bản trình bày:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $shape->getHyperlinkManager()->removeHyperlinkClick();
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Liên kết có thể thay đổi**

Lớp [Hyperlink](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlink/) có thể thay đổi. Với lớp này, bạn có thể thay đổi giá trị của các thuộc tính sau:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

Đoạn mã này cho bạn thấy cách thêm một liên kết vào slide và chỉnh sửa tooltip của nó sau này:
```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Các Thuộc tính Hỗ trợ trong IHyperlinkQueries**

Bạn có thể truy cập [HyperlinkQueries](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlinkqueries/) từ một bản trình bày, slide hoặc văn bản mà liên kết siêu văn bản được định nghĩa.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/gethyperlinkqueries/)

Lớp [HyperlinkQueries](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlinkqueries/) hỗ trợ các phương thức và thuộc tính sau:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **FAQ**

**Làm thế nào tôi có thể tạo điều hướng nội bộ không chỉ tới một slide mà còn tới một "phần" hoặc slide đầu tiên của một phần?**

Các phần trong PowerPoint là nhóm các slide; điều hướng thực tế nhắm tới một slide cụ thể. Để “đi đến một phần”, bạn thường liên kết tới slide đầu tiên của phần đó.

**Tôi có thể gắn liên kết siêu văn bản vào các phần tử của master slide để nó hoạt động trên tất cả các slide không?**

Có. Các phần tử master slide và layout hỗ trợ liên kết siêu văn bản. Những liên kết này xuất hiện trên các slide con và có thể nhấp được trong khi trình chiếu.

**Liên kết siêu văn bản sẽ được giữ lại khi xuất ra PDF, HTML, hình ảnh hoặc video không?**

Trong [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/php-java/convert-powerpoint-to-html/), có — các liên kết thường được giữ lại. Khi xuất ra [hình ảnh](/slides/vi/php-java/convert-powerpoint-to-png/) và [video](/slides/vi/php-java/convert-powerpoint-to-video/), tính năng nhấp sẽ không được chuyển tiếp do bản chất của các định dạng đó (khung raster/video không hỗ trợ liên kết siêu văn bản).