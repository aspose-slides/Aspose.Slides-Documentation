---
title: Quản lý Đồ họa SmartArt trong Bản trình chiếu bằng PHP
linktitle: Đồ họa SmartArt
type: docs
weight: 20
url: /vi/php-java/manage-smartart-shape/
keywords:
- Đối tượng SmartArt
- Đồ họa SmartArt
- Kiểu SmartArt
- Màu SmartArt
- tạo SmartArt
- thêm SmartArt
- chỉnh sửa SmartArt
- thay đổi SmartArt
- truy cập SmartArt
- Kiểu bố cục SmartArt
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tự động tạo, chỉnh sửa và định dạng SmartArt trong PowerPoint bằng PHP sử dụng Aspose.Slides, kèm theo các ví dụ mã ngắn gọn và hướng dẫn tập trung vào hiệu năng."
---
## **Tổng quan**

Aspose.Slides cho phép bạn tạo và quản lý các đồ họa SmartArt trong các bản thuyết trình PowerPoint một cách lập trình. Bài viết này giải thích cách thêm một hình SmartArt vào slide, truy cập các hình SmartArt hiện có, tìm SmartArt theo một kiểu bố cục cụ thể, và cập nhật giao diện hiển thị của nó bằng cách thay đổi kiểu Style hoặc Color Style của SmartArt.

Các ví dụ cho thấy cách làm việc với các hình SmartArt thông qua bộ sưu tập hình dạng của slide trong bản thuyết trình, kiểm tra xem một hình có phải là SmartArt không và sau đó sửa đổi hoặc kiểm tra các thuộc tính của nó.

## **Tạo một hình SmartArt**
Aspose.Slides cho PHP thông qua Java đã cung cấp một API để tạo các hình SmartArt. Để tạo một hình SmartArt trong slide, vui lòng thực hiện các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục (Index) của nó.
3. [Thêm một hình SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addSmartArt) bằng cách thiết lập [LayoutType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SmartArtLayoutType).
4. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```php
  # Khởi tạo lớp Presentation
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm hình Smart Art
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Lưu bản trình chiếu
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Hình: Hình SmartArt được thêm vào slide**|

## **Truy cập một hình SmartArt trên một Slide**
Đoạn mã dưới đây sẽ được sử dụng để truy cập các hình SmartArt đã được thêm vào slide của bản thuyết trình. Trong mã mẫu, chúng ta sẽ duyệt qua mọi hình trong slide và kiểm tra xem nó có phải là hình [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SmartArt) hay không. Nếu hình thuộc loại SmartArt thì chúng ta sẽ ép kiểu nó thành thể hiện [**SmartArt**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SmartArt).

```php
  # Tải bản trình chiếu mong muốn
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Duyệt qua mọi hình bên trong slide đầu tiên
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Kiểm tra xem hình có phải là loại SmartArt hay không
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ép kiểu hình sang SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Truy cập một hình SmartArt với Kiểu Bố Cục cụ thể**
Đoạn mã mẫu dưới đây sẽ giúp truy cập hình [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SmartArt) với LayoutType cụ thể. Lưu ý rằng bạn không thể thay đổi LayoutType của SmartArt vì nó chỉ đọc và chỉ được đặt khi hình [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SmartArt) được thêm.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) và tải bản thuyết trình có chứa hình SmartArt.
2. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
3. Duyệt qua mọi hình trong slide đầu tiên.
4. Kiểm tra xem hình có thuộc loại [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SmartArt) không và nếu có, ép kiểu hình đã chọn sang SmartArt.
5. Kiểm tra hình SmartArt có LayoutType cụ thể và thực hiện các thao tác cần thiết sau đó.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Duyệt qua mọi hình bên trong slide đầu tiên
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Kiểm tra xem hình có phải là loại SmartArt hay không
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ép kiểu hình sang SmartArtEx
        $smart = $shape;
        # Kiểm tra Layout của SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thay đổi Style của hình SmartArt**
Trong ví dụ này, chúng ta sẽ học cách thay đổi quick style cho bất kỳ hình SmartArt nào.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) và tải bản thuyết trình có chứa hình SmartArt.
2. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
3. Duyệt qua mọi hình trong slide đầu tiên.
4. Kiểm tra xem hình có thuộc loại [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SmartArt) không và nếu có, ép kiểu hình đã chọn sang SmartArt.
5. Tìm hình SmartArt có Style cụ thể.
6. Đặt Style mới cho hình SmartArt.
7. Lưu bản thuyết trình.

```php
  # Khởi tạo lớp Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Lấy slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Duyệt qua mọi hình bên trong slide đầu tiên
    foreach($slide->getShapes() as $shape) {
      # Kiểm tra xem hình có phải là loại SmartArt hay không
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ép kiểu hình sang SmartArtEx
        $smart = $shape;
        # Kiểm tra style của SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Thay đổi style của SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Lưu bản trình chiếu
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Hình: Hình SmartArt với Style đã thay đổi**|

## **Thay đổi Color Style của hình SmartArt**
Trong ví dụ này, chúng ta sẽ học cách thay đổi color style cho bất kỳ hình SmartArt nào. Đoạn mã mẫu sau sẽ truy cập hình SmartArt có color style cụ thể và sẽ thay đổi style của nó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) và tải bản thuyết trình có chứa hình SmartArt.
2. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
3. Duyệt qua mọi hình trong slide đầu tiên.
4. Kiểm tra xem hình có thuộc loại [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SmartArt) không và nếu có, ép kiểu hình đã chọn sang SmartArt.
5. Tìm hình SmartArt có Color Style cụ thể.
6. Đặt Color Style mới cho hình SmartArt.
7. Lưu bản thuyết trình.

```php
  # Khởi tạo lớp Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Lấy slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Duyệt qua mọi hình bên trong slide đầu tiên
    foreach($slide->getShapes() as $shape) {
      # Kiểm tra xem hình có phải là loại SmartArt hay không
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ép kiểu hình sang SmartArtEx
        $smart = $shape;
        # Kiểm tra kiểu màu của SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Thay đổi kiểu màu của SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Lưu bản trình chiếu
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Hình: Hình SmartArt với Color Style đã thay đổi**|

## **Câu hỏi thường gặp**

**Tôi có thể tạo hoạt ảnh cho SmartArt như một đối tượng duy nhất không?**

Có. SmartArt là một hình, vì vậy bạn có thể áp dụng [standard animations](/slides/vi/php-java/powerpoint-animation/) qua API hoạt ảnh (vào, ra, nhấn mạnh, đường chuyển động) giống như với các hình khác.

**Làm sao tôi có thể tìm một SmartArt cụ thể trên slide nếu không biết ID nội bộ của nó?**

Đặt và sử dụng Alternative Text (AltText) và tìm kiếm hình theo giá trị đó — đây là cách được khuyến nghị để tìm vị trí hình mục tiêu.

**Tôi có thể nhóm SmartArt với các hình khác không?**

Có. Bạn có thể nhóm SmartArt với các hình khác (hình ảnh, bảng, v.v.) và sau đó [manipulate the group](/slides/vi/php-java/group/).

**Làm sao tôi lấy hình ảnh của một SmartArt cụ thể (ví dụ: để xem trước hoặc báo cáo)?**

Xuất thumbnail/hình ảnh của hình; thư viện có thể [render individual shapes](/slides/vi/php-java/create-shape-thumbnails/) thành các tệp raster (PNG/JPG/TIFF).

**Giao diện của SmartArt có được bảo tồn khi chuyển đổi toàn bộ bản thuyết trình sang PDF không?**

Có. Engine render nhắm tới độ trung thực cao cho [PDF export](/slides/vi/php-java/convert-powerpoint-to-pdf/), với nhiều tùy chọn về chất lượng và khả năng tương thích.