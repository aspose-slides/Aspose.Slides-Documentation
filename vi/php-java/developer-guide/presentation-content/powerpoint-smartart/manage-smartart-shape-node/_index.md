---
title: Quản lý các nút hình SmartArt trong bản trình chiếu bằng PHP
linktitle: Nút hình SmartArt
type: docs
weight: 30
url: /vi/php-java/manage-smartart-shape-node/
keywords:
- nút SmartArt
- nút con
- thêm nút
- vị trí nút
- truy cập nút
- xóa nút
- vị trí tùy chỉnh
- nút trợ lý
- định dạng tô nền
- kết xuất nút
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Quản lý các nút hình SmartArt trong PPT và PPTX bằng Aspose.Slides cho PHP thông qua Java. Nhận các mẫu mã rõ ràng và mẹo để tối ưu hoá các bản trình chiếu của bạn."
---
## **Tổng quan**

Đồ họa SmartArt trong các bản trình bày PowerPoint được tổ chức thông qua các nút (node) chứa văn bản và xác định cấu trúc của sơ đồ. Aspose.Slides cho phép bạn làm việc với các nút SmartArt này một cách lập trình: thêm nút và nút con mới, chèn nút con vào vị trí cụ thể, truy cập các nút hiện có và đọc văn bản, cấp độ và vị trí của chúng.

Bài viết này giải thích cách quản lý các nút hình SmartArt. Nó hiển thị cách xóa nút, làm việc với nút con theo chỉ mục hoặc vị trí, chuyển một nút trợ lý thành nút thường, điều chỉnh vị trí, kích thước và góc quay của các hình nút SmartArt, đặt định dạng tô nền cho nút, và tạo ảnh thumbnail cho một nút con của SmartArt.

## **Thêm một nút SmartArt**
Aspose.Slides for PHP via Java cung cấp API đơn giản nhất để quản lý các hình SmartArt một cách dễ dàng. Đoạn mã mẫu sau sẽ giúp bạn thêm nút và nút con vào trong hình SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) và nạp bản trình bày có hình SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
1. Duyệt qua mọi shape trong slide đầu tiên.
1. Kiểm tra xem shape có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) không và ép kiểu shape đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) nếu nó là SmartArt.
1. [Thêm một nút mới](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartnodecollection/#addNode) vào hình SmartArt **NodeCollection** và đặt văn bản trong TextFrame.
1. Bây giờ, [Thêm](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartnodecollection/#addNode) một **Child Node** vào nút SmartArt vừa mới thêm và đặt văn bản trong TextFrame.
1. Lưu bản trình bày.

```php
  # Tải bản trình chiếu mong muốn
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Duyệt qua mọi shape trong slide đầu tiên
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Kiểm tra xem shape có phải là loại SmartArt không
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ép kiểu shape sang SmartArt
        $smart = $shape;
        # Thêm một nút SmartArt mới
        $TemNode = $smart->getAllNodes()->addNode();
        # Thêm văn bản
        $TemNode->getTextFrame()->setText("Test");
        # Thêm nút con mới vào nút cha. Nó sẽ được thêm vào cuối bộ sưu tập
        $newNode = $TemNode->getChildNodes()->addNode();
        # Thêm văn bản
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Lưu bản trình chiếu
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm một nút SmartArt ở vị trí cụ thể**
Trong đoạn mã mẫu dưới đây, chúng tôi giải thích cách thêm các nút con thuộc về các nút tương ứng của hình SmartArt ở vị trí nhất định.

1. Tạo một thể hiện của lớp Presentation.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
1. Thêm một shape [**StackedList**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SmartArtLayoutType#StackedList) type [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SmartArt) vào slide đã truy cập.
1. Truy cập nút đầu tiên trong shape SmartArt đã thêm.
1. Bây giờ, thêm **Child Node** cho **Node** đã chọn tại vị trí 2 và đặt văn bản cho nó.
1. Lưu bản trình bày.

```php
  # Tạo một thể hiện bản trình chiếu
  $pres = new Presentation();
  try {
    # Truy cập slide của bản trình chiếu
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Truy cập nút SmartArt tại chỉ mục 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Thêm nút con mới tại vị trí 2 trong nút cha
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Thêm văn bản
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Lưu bản trình chiếu
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Truy cập một nút SmartArt**
Đoạn mã mẫu sau sẽ giúp bạn truy cập các nút bên trong shape SmartArt. Lưu ý rằng bạn không thể thay đổi LayoutType của SmartArt vì nó chỉ đọc và chỉ được đặt khi shape SmartArt được thêm.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) và nạp bản trình bày có shape SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
1. Duyệt qua mọi shape trong slide đầu tiên.
1. Kiểm tra xem shape có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) không và ép kiểu shape đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) nếu nó là SmartArt.
1. Duyệt qua tất cả **Nodes** trong shape SmartArt.
1. Truy cập và hiển thị thông tin như vị trí, cấp độ và Text của nút SmartArt.

```php
  # Khởi tạo lớp Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Lấy slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Duyệt qua mọi shape trong slide đầu tiên
    foreach($slide->getShapes() as $shape) {
      # Kiểm tra xem shape có phải là loại SmartArt không
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ép kiểu shape sang SmartArt
        $smart = $shape;
        # Duyệt qua tất cả các nút trong SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Truy cập nút SmartArt tại chỉ mục i
          $node = $smart->getAllNodes()->get_Item($i);
          # In các tham số của nút SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Truy cập một nút con SmartArt**
Đoạn mã mẫu sau sẽ giúp bạn truy cập các nút con thuộc về các nút tương ứng của shape SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) và nạp bản trình bày có shape SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
1. Duyệt qua mọi shape trong slide đầu tiên.
1. Kiểm tra xem shape có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) không và ép kiểu shape đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) nếu nó là SmartArt.
1. Duyệt qua tất cả **Nodes** trong shape SmartArt.
1. Đối với mỗi **Node** của shape SmartArt đã chọn, duyệt qua tất cả **Child Nodes** trong nút cụ thể.
1. Truy cập và hiển thị thông tin như vị trí, cấp độ và Text của **Child Node**.

```php
  # Khởi tạo lớp Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Lấy slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Duyệt qua mọi shape trong slide đầu tiên
    foreach($slide->getShapes() as $shape) {
      # Kiểm tra xem shape có phải là loại SmartArt không
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ép kiểu shape sang SmartArt
        $smart = $shape;
        # Duyệt qua tất cả các nút trong SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Truy cập nút SmartArt tại chỉ mục i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Duyệt qua các nút con trong nút SmartArt tại chỉ mục i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Truy cập nút con trong nút SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # In các tham số của nút con SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Truy cập một nút con SmartArt ở vị trí cụ thể**
Trong ví dụ này, chúng ta sẽ học cách truy cập các nút con ở một vị trí nhất định thuộc về các nút tương ứng của shape SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) .
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
1. Thêm một shape SmartArt loại [**StackedList**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Truy cập shape SmartArt đã thêm.
1. Truy cập nút ở chỉ mục 0 cho shape SmartArt đã truy cập.
1. Bây giờ, truy cập **Child Node** tại vị trí 1 cho nút SmartArt đã truy cập bằng phương thức **get_Item()**.
1. Truy cập và hiển thị thông tin như vị trí, cấp độ và Text của **Child Node**.

```php
  # Khởi tạo bản trình chiếu
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm shape SmartArt vào slide đầu tiên
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Truy cập nút SmartArt tại chỉ mục 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Truy cập nút con tại vị trí 1 trong nút cha
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # In các tham số của nút con SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xóa một nút SmartArt**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút bên trong shape SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) và nạp bản trình bày có shape SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
1. Duyệt qua mọi shape trong slide đầu tiên.
1. Kiểm tra xem shape có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) không và ép kiểu shape đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) nếu nó là SmartArt.
1. Kiểm tra xem SmartArt có hơn 0 nút hay không.
1. Chọn nút SmartArt cần xóa.
1. Bây giờ, xóa nút đã chọn bằng phương thức **removeNode**.
1. Lưu bản trình bày.

```php
  # Tải bản trình chiếu mong muốn
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Duyệt qua mọi shape trong slide đầu tiên
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Kiểm tra xem shape có phải là loại SmartArt không
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ép kiểu shape sang SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Truy cập nút SmartArt tại chỉ mục 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Xóa nút đã chọn
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Lưu bản trình chiếu
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xóa một nút SmartArt ở vị trí cụ thể**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút bên trong shape SmartArt ở vị trí nhất định.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) và nạp bản trình bày có shape SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
1. Duyệt qua mọi shape trong slide đầu tiên.
1. Kiểm tra xem shape có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) không và ép kiểu shape đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) nếu nó là SmartArt.
1. Chọn nút shape SmartArt ở chỉ mục 0.
1. Bây giờ, kiểm tra xem nút SmartArt đã chọn có hơn 2 nút con hay không.
1. Sau đó, xóa nút ở **Position 1** bằng phương thức **removeNode**.
1. Lưu bản trình bày.

```php
  # Tải bản trình chiếu mong muốn
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Duyệt qua mọi shape trong slide đầu tiên
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Kiểm tra xem shape có phải là loại SmartArt không
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ép kiểu shape sang SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Truy cập nút SmartArt tại chỉ mục 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Xóa nút con tại vị trí 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Lưu bản trình chiếu
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt vị trí tùy chỉnh cho một nút con trong đối tượng SmartArt**
Aspose.Slides for PHP via Java hỗ trợ việc thiết lập các thuộc tính [SmartArtShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#setX) và [Y](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#setY). Đoạn mã dưới đây cho thấy cách đặt vị trí, kích thước và góc quay tùy chỉnh cho SmartArtShape; cũng lưu ý rằng việc thêm nút mới sẽ gây tính lại vị trí và kích thước của tất cả các nút. Với các cài đặt vị trí tùy chỉnh, người dùng có thể đặt các nút theo yêu cầu.

```php
  # Khởi tạo lớp Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Di chuyển shape SmartArt tới vị trí mới
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Thay đổi chiều rộng của shape SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Thay đổi chiều cao của shape SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Thay đổi góc quay của shape SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Kiểm tra một nút trợ lý**
{{% alert color="primary" %}} 

Trong bài viết này chúng ta sẽ khảo sát sâu hơn các tính năng của các shape SmartArt được thêm vào các slide trình bày một cách lập trình bằng Aspose.Slides for PHP via Java.

{{% /alert %}} 

Chúng ta sẽ sử dụng shape SmartArt sau làm nguồn để khảo sát trong các phần khác nhau của bài viết.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Hình: Shape SmartArt nguồn trong slide**|

Trong đoạn mã mẫu dưới đây, chúng ta sẽ khảo sát cách xác định **Assistant Nodes** trong bộ sưu tập các nút SmartArt và thay đổi chúng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) và nạp bản trình bày có shape SmartArt.
1. Lấy tham chiếu của slide thứ hai bằng cách sử dụng Index của nó.
1. Duyệt qua mọi shape trong slide đầu tiên.
1. Kiểm tra xem shape có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) không và ép kiểu shape đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) nếu nó là SmartArt.
1. Duyệt qua tất cả các nút trong shape SmartArt và kiểm tra xem chúng có phải là **Assistant Nodes** không.
1. Thay đổi trạng thái của Assistant Node thành nút thường.
1. Lưu bản trình bày.

```php
  # Tạo một thể hiện trình chiếu
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Duyệt qua mọi shape trong slide đầu tiên
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Kiểm tra xem shape có phải là loại SmartArt không
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ép kiểu shape sang SmartArt
        $smart = $shape;
        # Duyệt qua tất cả các nút của shape SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Kiểm tra xem nút có phải là nút trợ lý không
          if ($node->isAssistant()) {
            # Đặt nút trợ lý thành false và chuyển nó thành nút thường
            $node->isAssistant();
          }
        }
      }
    }
    # Lưu bản trình chiếu
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Hình: Assistant Nodes đã được thay đổi trong shape SmartArt trong slide**|

## **Đặt định dạng tô nền cho một nút**
Aspose.Slides for PHP via Java cho phép bạn thêm các shape SmartArt tùy chỉnh và đặt định dạng tô nền cho chúng. Bài viết này giải thích cách tạo và truy cập các shape SmartArt và đặt định dạng tô nền cho các nút của chúng bằng Aspose.Slides for PHP via Java.

Vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Thêm một shape [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) bằng cách đặt **LayoutType** cho nó.
1. Đặt **Fill Format** cho các nút shape SmartArt.
1. Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.

```php
  # Khởi tạo bản trình chiếu
  $pres = new Presentation();
  try {
    # Truy cập slide
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm shape SmartArt và các nút
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Đặt màu nền cho nút
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Lưu bản trình chiếu
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tạo thumbnail cho một nút con SmartArt**
Các nhà phát triển có thể tạo thumbnail cho nút con của SmartArt bằng cách thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. [Thêm SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartnodecollection/#addNode).
1. Lấy tham chiếu của một nút bằng cách sử dụng Index của nó.
1. Lấy ảnh thumbnail.
1. Lưu ảnh thumbnail ở bất kỳ định dạng hình ảnh nào mong muốn.

```php
  # Khởi tạo lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Thêm SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Lấy tham chiếu của một nút bằng cách sử dụng Index của nó
    $node = $smart->getNodes()->get_Item(1);
    # Lấy thumbnail
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Lưu thumbnail
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**SmartArt có hỗ trợ hoạt ảnh không?**

Có. SmartArt được xem như một shape thông thường, vì vậy bạn có thể [áp dụng các hoạt ảnh tiêu chuẩn](/slides/vi/php-java/shape-animation/) (xuất hiện, biến mất, nhấn mạnh, đường di chuyển) và điều chỉnh thời gian. Bạn cũng có thể hoạt ảnh các shape bên trong các nút SmartArt khi cần.

**Làm thế nào để xác định một SmartArt cụ thể trên slide nếu không biết ID nội bộ?**

Gán và tìm kiếm bằng [văn bản thay thế](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getalternativetext/). Đặt AltText đặc trưng cho SmartArt giúp bạn tìm nó một cách lập trình mà không phụ thuộc vào các định danh nội bộ.

**Khi chuyển đổi bản trình bày sang PDF, hình dạng SmartArt có được giữ nguyên không?**

Có. Aspose.Slides render SmartArt với độ trung thực hình ảnh cao trong quá trình [xuất PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/), bảo toàn bố cục, màu sắc và hiệu ứng.

**Tôi có thể trích xuất hình ảnh toàn bộ SmartArt (để xem trước hoặc báo cáo) không?**

Có. Bạn có thể render shape SmartArt thành [định dạng raster](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage) hoặc thành [SVG](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/writeassvg/) để xuất ra vector có thể mở rộng, phù hợp cho thumbnail, báo cáo hoặc sử dụng trên web.