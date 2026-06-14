---
title: Truy cập các slide trong bản thuyết trình bằng PHP
linktitle: Truy cập Slide
type: docs
weight: 20
url: /vi/php-java/access-slide-in-presentation/
keywords:
- truy cập slide
- chỉ số slide
- id slide
- vị trí slide
- thay đổi vị trí
- thuộc tính slide
- số slide
- PowerPoint
- OpenDocument
- bản thuyết trình
- PHP
- Aspose.Slides
description: "Tìm hiểu cách truy cập và quản lý các slide trong bản thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho PHP qua Java. Tăng năng suất với các ví dụ mã."
---
## **Tổng quan**

Bài viết này giải thích cách truy cập và quản lý các slide trong một bản thuyết trình bằng Aspose.Slides. Nó chỉ ra cách lấy các slide bằng chỉ số bắt đầu từ 0 trong bộ sưu tập slide và cách truy cập một slide bằng ID duy nhất của nó bằng phương thức `getSlideById`.

Bạn cũng sẽ học cách thay đổi vị trí của slide bằng phương thức `setSlideNumber` và cách xác định số slide bắt đầu cho một bản thuyết trình bằng phương thức `setFirstSlideNumber`. Các ví dụ minh họa việc tải bản thuyết trình, lấy tham chiếu slide, cập nhật thứ tự hoặc đánh số slide, và lưu bản thuyết trình đã sửa đổi.

## **Truy cập Slide theo Chỉ số**

Tất cả các slide trong một bản thuyết trình được sắp xếp theo thứ tự số dựa trên vị trí slide, bắt đầu từ 0. Slide đầu tiên có thể truy cập qua chỉ số 0; slide thứ hai qua chỉ số 1; v.v.

Lớp Presentation, đại diện cho tệp bản thuyết trình, cung cấp tất cả các slide như một bộ sưu tập [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/) (tập hợp các đối tượng [Slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/)). Đoạn mã PHP sau cho bạn cách truy cập một slide thông qua chỉ số của nó:

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp bản thuyết trình
  $pres = new Presentation("demo.pptx");
  try {
    # Truy cập một slide bằng chỉ số slide của nó
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **Truy cập Slide theo ID**

Mỗi slide trong một bản thuyết trình có một ID duy nhất gắn với nó. Bạn có thể sử dụng phương thức [getSlideById](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSlideById-long-) (được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/)) để truy cập ID đó. Đoạn mã PHP sau cho bạn cách cung cấp một ID slide hợp lệ và truy cập slide đó qua phương thức [getSlideById](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSlideById-long-):

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp bản thuyết trình
  $pres = new Presentation("demo.pptx");
  try {
    # Lấy ID của một slide
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Truy cập slide thông qua ID của nó
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **Thay đổi Vị trí Slide**

Aspose.Slides cho phép bạn thay đổi vị trí của một slide. Ví dụ, bạn có thể chỉ định slide đầu tiên sẽ trở thành slide thứ hai.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu slide (slide mà bạn muốn thay đổi vị trí) qua chỉ số của nó
1. Đặt vị trí mới cho slide qua phương thức [setSlideNumber](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#setSlideNumber).
1. Lưu bản thuyết trình đã sửa đổi.

Đoạn mã PHP sau minh họa một thao tác trong đó slide ở vị trí 1 được chuyển đến vị trí 2:

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp bản thuyết trình
  $pres = new Presentation("Presentation.pptx");
  try {
    # Lấy slide mà vị trí sẽ được thay đổi
    $sld = $pres->getSlides()->get_Item(0);
    # Đặt vị trí mới cho slide
    $sld->setSlideNumber(2);
    # Lưu bản thuyết trình đã sửa đổi
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Slide đầu tiên trở thành slide thứ hai; slide thứ hai trở thành slide đầu tiên. Khi bạn thay đổi vị trí của một slide, các slide khác sẽ tự động được điều chỉnh.

## **Đặt Số Slide**

Bằng cách sử dụng phương thức [setFirstSlideNumber](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/)), bạn có thể chỉ định một số mới cho slide đầu tiên trong một bản thuyết trình. Thao tác này sẽ làm cho các số slide khác được tính lại.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy số slide.
1. Đặt số slide.
1. Lưu bản thuyết trình đã sửa đổi.

Đoạn mã PHP sau minh họa một thao tác trong đó số slide đầu tiên được đặt thành 10:

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp bản thuyết trình
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Lấy số slide
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Đặt số slide
    $pres->setFirstSlideNumber(10);
    # Lưu bản thuyết trình đã sửa đổi
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Nếu bạn muốn bỏ qua slide đầu tiên, bạn có thể bắt đầu đánh số từ slide thứ hai (và ẩn số thứ tự cho slide đầu tiên) như sau:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Đặt số cho slide đầu tiên của bản thuyết trình
    $presentation->setFirstSlideNumber(0);
    # Hiển thị số slide cho tất cả các slide
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # Ẩn số slide cho slide đầu tiên
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Lưu bản thuyết trình đã sửa đổi
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Số slide mà người dùng thấy có khớp với chỉ số bắt đầu từ 0 của bộ sưu tập không?**

Số hiển thị trên slide có thể bắt đầu từ bất kỳ giá trị nào (ví dụ: 10) và không nhất thiết phải khớp với chỉ số; mối quan hệ này được kiểm soát bởi cài đặt [first slide number](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/setfirstslidenumber/) của bản thuyết trình.

**Các slide ẩn có ảnh hưởng đến việc lập chỉ số không?**

Có. Một slide ẩn vẫn tồn tại trong bộ sưu tập và được tính vào chỉ số; “ẩn” chỉ đề cập đến việc hiển thị, không phải vị trí trong bộ sưu tập.

**Chỉ số của một slide có thay đổi khi các slide khác được thêm hoặc xóa không?**

Có. Chỉ số luôn phản ánh thứ tự hiện tại của các slide và được tính lại khi thực hiện các thao tác chèn, xóa và di chuyển.