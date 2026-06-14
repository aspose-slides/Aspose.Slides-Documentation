---
title: Quản lý Zoom trong bài thuyết trình bằng PHP
linktitle: Quản lý Zoom
type: docs
weight: 60
url: /vi/php-java/manage-zoom/
keywords:
- phóng to
- khung zoom
- zoom slide
- zoom phần
- zoom tổng kết
- thêm zoom
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tạo và tùy chỉnh Zoom với Aspose.Slides cho PHP thông qua Java — chuyển đổi giữa các phần, thêm hình thu nhỏ và chuyển tiếp trong các bản trình bày PPT, PPTX và ODP."
---
## **Giới thiệu**

Zoom trong PowerPoint cho phép bạn nhảy tới và từ các slide, phần, và đoạn cụ thể của bản trình bày. Khi bạn đang trình chiếu, khả năng điều hướng nhanh chóng qua nội dung này có thể rất hữu ích. 

![overview_image](overview.png)

* Để tóm tắt toàn bộ bài thuyết trình trên một slide duy nhất, hãy sử dụng [Zoom Tổng Kết](#Summary-Zoom).
* Để hiển thị chỉ các slide đã chọn, hãy sử dụng [Zoom Slide](#Slide-Zoom).
* Để hiển thị chỉ một phần, hãy sử dụng [Zoom Phần](#Section-Zoom).

## **Zoom Slide**

Zoom slide có thể làm cho bản trình bày của bạn năng động hơn, cho phép bạn điều hướng tự do giữa các slide theo bất kỳ thứ tự nào bạn muốn mà không làm gián đoạn dòng chảy của bài thuyết trình. Zoom slide rất phù hợp cho các bài trình bày ngắn gọn không có nhiều phần, nhưng bạn vẫn có thể sử dụng chúng trong các kịch bản trình bày khác nhau.

Zoom slide giúp bạn khám phá nhiều thông tin khác nhau trong khi vẫn cảm giác như đang ở trên một canvas duy nhất. 

![overview_image](slidezoomsel.png)

Đối với các đối tượng zoom slide, Aspose.Slides cung cấp enumeration [ZoomImageType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zoomimagetype/), lớp [ZoomFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zoomframe/), và một số phương thức trong lớp [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/).

### **Tạo Khung Zoom**

Bạn có thể thêm một khung zoom vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2.	Tạo các slide mới để bạn định liên kết các khung zoom.
3.	Thêm văn bản nhận dạng và nền cho các slide đã tạo.
4.	Thêm các khung zoom (chứa tham chiếu tới các slide đã tạo) vào slide đầu tiên.
5.	Ghi bản trình bày đã chỉnh sửa dưới dạng file PPTX.

```php
  $pres = new Presentation();
  try {
    # Thêm các slide mới vào bài thuyết trình
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Tạo nền cho slide thứ hai
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Tạo hộp văn bản cho slide thứ hai
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Tạo nền cho slide thứ ba
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Tạo hộp văn bản cho slide thứ ba
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Thêm các đối tượng ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Lưu bài thuyết trình
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Tạo Khung Zoom với Hình ảnh Tùy chỉnh**

Với Aspose.Slides cho PHP thông qua Java, bạn có thể tạo một khung zoom với hình ảnh xem trước slide khác nhau theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2.	Tạo một slide mới để bạn định liên kết khung zoom. 
3.	Thêm văn bản nhận dạng và nền cho slide.
4.	Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) sẽ được dùng để điền vào khung.
5.	Thêm các khung zoom (chứa tham chiếu tới slide đã tạo) vào slide đầu tiên.
6.	Ghi bản trình bày đã chỉnh sửa dưới dạng file PPTX.

```php
  $pres = new Presentation();
  try {
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Tạo nền cho slide thứ hai
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Tạo hộp văn bản cho slide thứ ba
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Tạo một hình ảnh mới cho đối tượng zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Thêm đối tượng ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Lưu bài thuyết trình
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Định dạng Khung Zoom**

Trong các phần trước, chúng tôi đã chỉ cho bạn cách tạo các khung zoom đơn giản. Để tạo các khung zoom phức tạp hơn, bạn phải thay đổi định dạng của khung đơn giản. Có một số tùy chọn định dạng mà bạn có thể áp dụng cho khung zoom.

Bạn có thể kiểm soát định dạng của khung zoom trên slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2.	Tạo các slide mới để liên kết với khung zoom mà bạn muốn.
3.	Thêm một số văn bản nhận dạng và nền cho các slide đã tạo.
4.	Thêm các khung zoom (chứa các tham chiếu tới các slide đã tạo) vào slide đầu tiên.
5.	Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) sẽ được dùng để điền vào khung.
6.	Đặt hình ảnh tùy chỉnh cho đối tượng khung zoom đầu tiên.
7.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
8.	Xóa nền khỏi hình ảnh của đối tượng khung zoom thứ hai.
9.	Ghi bản trình bày đã chỉnh sửa dưới dạng file PPTX.

```php
  $pres = new Presentation();
  try {
    # Thêm các slide mới vào bài thuyết trình
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Tạo nền cho slide thứ hai
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Tạo hộp văn bản cho slide thứ hai
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Tạo nền cho slide thứ ba
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Tạo hộp văn bản cho slide thứ ba
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Thêm các đối tượng ZoomFrame
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Tạo một hình ảnh mới cho đối tượng zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Đặt hình ảnh tùy chỉnh cho đối tượng zoomFrame1
    $zoomFrame1->setImage($picture);
    # Đặt định dạng khung zoom cho đối tượng zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Cài đặt không hiển thị nền cho đối tượng zoomFrame2
    $zoomFrame2->setShowBackground(false);
    # Lưu bài thuyết trình
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zoom Phần**

Zoom phần là một liên kết tới một phần trong bản trình bày của bạn. Bạn có thể sử dụng zoom phần để quay lại các phần bạn muốn nhấn mạnh. Hoặc bạn có thể dùng chúng để làm nổi bật cách các phần của bản trình bày liên kết với nhau. 

![overview_image](seczoomsel.png)

Đối với các đối tượng zoom phần, Aspose.Slides cung cấp lớp [SectionZoomFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sectionzoomframe/) và một số phương thức trong lớp [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/).

### **Tạo Khung Zoom Phần**

Bạn có thể thêm một khung zoom phần vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2.	Tạo một slide mới. 
3.	Thêm nền nhận dạng cho slide đã tạo.
4.	Tạo một phần mới để bạn định liên kết khung zoom. 
5.	Thêm một khung zoom phần (chứa tham chiếu tới phần đã tạo) vào slide đầu tiên.
6.	Ghi bản trình bày đã chỉnh sửa dưới dạng file PPTX.

```php
  $pres = new Presentation();
  try {
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Thêm một Section mới vào bài thuyết trình
    $pres->getSections()->addSection("Section 1", $slide);
    # Thêm một đối tượng SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Lưu bài thuyết trình
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Tạo Khung Zoom Phần với Hình ảnh Tùy chỉnh**

Với Aspose.Slides cho PHP thông qua Java, bạn có thể tạo một khung zoom phần với hình ảnh xem trước slide khác nhau theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2.	Tạo một slide mới.
3.	Thêm nền nhận dạng cho slide đã tạo.
4.	Tạo một phần mới để bạn định liên kết khung zoom. 
5.	Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) sẽ được dùng để điền vào khung.
6.	Thêm một khung zoom phần (chứa tham chiếu tới phần đã tạo) vào slide đầu tiên.
7.	Ghi bản trình bày đã chỉnh sửa dưới dạng file PPTX.

```php
  $pres = new Presentation();
  try {
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Thêm một Section mới vào bài thuyết trình
    $pres->getSections()->addSection("Section 1", $slide);
    # Tạo một hình ảnh mới cho đối tượng zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Thêm đối tượng SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # Lưu bài thuyết trình
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Định dạng Khung Zoom Phần**

Để tạo các khung zoom phần phức tạp hơn, bạn phải thay đổi định dạng của khung đơn giản. Có một số tùy chọn định dạng mà bạn có thể áp dụng cho khung zoom phần. 

Bạn có thể kiểm soát định dạng của khung zoom phần trên slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2.	Tạo một slide mới.
3.	Thêm nền nhận dạng cho slide đã tạo.
4.	Tạo một phần mới để bạn định liên kết khung zoom. 
5.	Thêm một khung zoom phần (chứa các tham chiếu tới phần đã tạo) vào slide đầu tiên.
6.	Thay đổi kích thước và vị trí cho đối tượng zoom phần đã tạo.
7.	Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) sẽ được dùng để điền vào khung.
8.	Đặt hình ảnh tùy chỉnh cho đối tượng khung zoom phần đã tạo.
9.	Đặt khả năng *trở về slide gốc từ phần đã liên kết*.
10.	Xóa nền khỏi hình ảnh của đối tượng khung zoom phần.
11.	Thay đổi định dạng đường viền cho khung zoom thứ hai.
12.	Thay đổi thời lượng chuyển đổi.
13.	Ghi bản trình bày đã chỉnh sửa dưới dạng file PPTX.

```php
  $pres = new Presentation();
  try {
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Thêm một Section mới vào bài thuyết trình
    $pres->getSections()->addSection("Section 1", $slide);
    # Thêm đối tượng SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Định dạng cho SectionZoomFrame
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # Lưu bài thuyết trình
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zoom Tổng Kết**

Zoom tổng kết giống như một trang đích mà ở đó tất cả các phần của bản trình bày được hiển thị cùng một lúc. Khi bạn đang trình chiếu, bạn có thể dùng zoom để di chuyển từ một vị trí trong bản trình bày đến vị trí khác theo bất kỳ thứ tự nào bạn muốn. Bạn có thể sáng tạo, bỏ qua một phần, hoặc quay lại các phần của slide mà không làm gián đoạn dòng chảy của bài thuyết trình.

![overview_image](sumzoomsel.png)

Đối với các đối tượng zoom tổng kết, Aspose.Slides cung cấp các lớp [SummaryZoomFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/summaryzoomsection/), và [SummaryZoomSectionCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/summaryzoomsectioncollection/), cùng một số phương thức trong lớp [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/).

### **Tạo Zoom Tổng Kết**

Bạn có thể thêm một khung zoom tổng kết vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm khung zoom tổng kết vào slide đầu tiên.
4.	Ghi bản trình bày đã chỉnh sửa dưới dạng file PPTX.

```php
  $pres = new Presentation();
  try {
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Thêm một section mới vào bài thuyết trình
    $pres->getSections()->addSection("Section 1", $slide);
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Thêm một section mới vào bài thuyết trình
    $pres->getSections()->addSection("Section 2", $slide);
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Thêm một section mới vào bài thuyết trình
    $pres->getSections()->addSection("Section 3", $slide);
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Thêm một section mới vào bài thuyết trình
    $pres->getSections()->addSection("Section 4", $slide);
    # Thêm một đối tượng SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Lưu bài thuyết trình
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Thêm và Xóa Phần Zoom Tổng Kết**

Tất cả các phần trong một khung zoom tổng kết được biểu diễn bằng các đối tượng [SummaryZoomSection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/summaryzoomsection/), được lưu trong đối tượng [SummaryZoomSectionCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/summaryzoomsectioncollection/). Bạn có thể thêm hoặc xóa một đối tượng phần zoom tổng kết thông qua lớp [SummaryZoomSectionCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/summaryzoomsectioncollection/) theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm một khung zoom tổng kết vào slide đầu tiên.
4.	Thêm một slide và một phần mới vào bản trình bày.
5.	Thêm phần đã tạo vào khung zoom tổng kết.
6.	Xóa phần đầu tiên khỏi khung zoom tổng kết.
7.	Ghi bản trình bày đã chỉnh sửa dưới dạng file PPTX.

```php
  $pres = new Presentation();
  try {
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Thêm một section mới vào bài thuyết trình
    $pres->getSections()->addSection("Section 1", $slide);
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Thêm một section mới vào bài thuyết trình
    $pres->getSections()->addSection("Section 2", $slide);
    # Thêm đối tượng SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Thêm một section mới vào bài thuyết trình
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Thêm một section vào Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Xóa section khỏi Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Lưu bài thuyết trình
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Định dạng Phần Zoom Tổng Kết**

Để tạo các phần zoom tổng kết phức tạp hơn, bạn phải thay đổi định dạng của khung đơn giản. Có một số tùy chọn định dạng mà bạn có thể áp dụng cho một phần zoom tổng kết. 

Bạn có thể kiểm soát định dạng của một phần zoom tổng kết trong khung zoom tổng kết theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm một khung zoom tổng kết vào slide đầu tiên.
4.	Lấy một đối tượng phần zoom tổng kết cho đối tượng đầu tiên từ `SummaryZoomSectionCollection`.
7.	Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) bằng cách thêm một hình ảnh vào bộ sưu tập images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) sẽ được dùng để điền vào khung.
8.	Đặt hình ảnh tùy chỉnh cho đối tượng khung zoom phần đã tạo.
9.	Đặt khả năng *trở về slide gốc từ phần đã liên kết*.
11.	Thay đổi định dạng đường viền cho khung zoom thứ hai.
12.	Thay đổi thời lượng chuyển đổi.
13.	Ghi bản trình bày đã chỉnh sửa dưới dạng file PPTX.

```php
  $pres = new Presentation();
  try {
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Thêm một section mới vào bài thuyết trình
    $pres->getSections()->addSection("Section 1", $slide);
    # Thêm một slide mới vào bài thuyết trình
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Thêm một section mới vào bài thuyết trình
    $pres->getSections()->addSection("Section 2", $slide);
    # Thêm một đối tượng SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Lấy đối tượng SummaryZoomSection đầu tiên
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Định dạng cho đối tượng SummaryZoomSection
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # Lưu bài thuyết trình
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Can I control returning to the 'parent' slide after showing the target?**

Có. Khung [Zoom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zoomframe/) hoặc [phần](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sectionzoomframe/) có thuộc tính `ReturnToParent` mà khi được bật, sẽ đưa người xem trở lại slide gốc sau khi họ truy cập nội dung mục tiêu.

**Can I adjust the 'speed' or duration of the Zoom transition?**

Có. Zoom hỗ trợ thiết lập `TransitionDuration` để bạn có thể kiểm soát thời gian của hiệu ứng nhảy.

**Are there limits on how many Zoom objects a presentation can contain?**

Không có giới hạn cứng nào được tài liệu API ghi nhận. Giới hạn thực tế phụ thuộc vào độ phức tạp tổng thể của bản trình bày và hiệu năng của người xem. Bạn có thể thêm nhiều khung Zoom, nhưng cần cân nhắc kích thước file và thời gian render.