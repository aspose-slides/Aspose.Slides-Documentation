---
title: Truy cập các slide trong bản trình chiếu bằng Java
linktitle: Truy cập Slide
type: docs
weight: 20
url: /vi/java/access-slide-in-presentation/
keywords:
- truy cập slide
- chỉ mục slide
- id slide
- vị trí slide
- thay đổi vị trí
- thuộc tính slide
- số slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách truy cập và quản lý các slide trong bản trình chiếu PowerPoint và OpenDocument với Aspose.Slides cho Java. Tăng năng suất với các ví dụ mã."
---
## **Tổng quan**

Bài viết này giải thích cách truy cập và quản lý các slide trong một bản trình chiếu bằng Aspose.Slides. Nó cho thấy cách lấy slide theo chỉ mục bắt đầu từ 0 trong bộ sưu tập slide và cách truy cập slide bằng ID duy nhất của nó bằng phương thức `getSlideById`.

Bạn cũng sẽ học cách thay đổi vị trí của một slide bằng phương thức `setSlideNumber` và cách xác định số slide bắt đầu cho một bản trình chiếu bằng phương thức `setFirstSlideNumber`. Các ví dụ minh họa việc tải một bản trình chiếu, lấy tham chiếu slide, cập nhật thứ tự hoặc số thứ tự của slide, và lưu bản trình chiếu đã sửa.

## **Truy cập slide theo chỉ mục**

Tất cả các slide trong một bản trình chiếu được sắp xếp theo thứ tự số dựa trên vị trí slide, bắt đầu từ 0. Slide đầu tiên có thể truy cập qua chỉ mục 0; slide thứ hai qua chỉ mục 1; v.v.

Lớp Presentation, đại diện cho tệp bản trình chiếu, cung cấp tất cả các slide dưới dạng bộ sưu tập [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/) (bộ sưu tập các đối tượng [ISlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/) ). Đoạn mã Java sau cho bạn biết cách truy cập một slide qua chỉ mục của nó:

```java
// Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("demo.pptx");
try {
    // Truy cập một slide bằng chỉ mục slide của nó
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Truy cập slide theo ID**

Mỗi slide trong một bản trình chiếu đều có một ID duy nhất được gán cho nó. Bạn có thể sử dụng phương thức [getSlideById](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSlideById-long-) (được khai báo bởi lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/)) để chỉ tới ID đó. Đoạn mã Java sau cho bạn biết cách cung cấp một ID slide hợp lệ và truy cập slide đó thông qua phương thức [getSlideById](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSlideById-long-):

```java
// Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("demo.pptx");
try {
    // Lấy ID của một slide
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Truy cập slide thông qua ID của nó
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Thay đổi vị trí slide**

Aspose.Slides cho phép bạn thay đổi vị trí của một slide. Ví dụ, bạn có thể chỉ định rằng slide đầu tiên sẽ trở thành slide thứ hai.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Lấy tham chiếu slide (slide mà bạn muốn thay đổi vị trí) qua chỉ mục của nó
3. Đặt vị trí mới cho slide qua thuộc tính [setSlideNumber](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#setSlideNumber-int-).
4. Lưu bản trình chiếu đã sửa.

Đoạn mã Java sau minh họa một thao tác trong đó slide ở vị trí 1 được di chuyển tới vị trí 2:

```java
// Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Lấy slide mà vị trí sẽ được thay đổi
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Đặt vị trí mới cho slide
    sld.setSlideNumber(2);
    
    // Lưu bản trình chiếu đã sửa
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Slide đầu tiên trở thành slide thứ hai; slide thứ hai trở thành slide đầu tiên. Khi bạn thay đổi vị trí của một slide, các slide khác sẽ tự động được điều chỉnh.

## **Đặt số slide**

Sử dụng thuộc tính [setFirstSlideNumber](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (được khai báo bởi lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/)), bạn có thể chỉ định một số mới cho slide đầu tiên trong bản trình chiếu. Thao tác này sẽ làm cho các số slide khác được tính lại.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Lấy số của slide.
3. Đặt số slide.
4. Lưu bản trình chiếu đã sửa.

Đoạn mã Java sau minh họa một thao tác trong đó số slide đầu tiên được đặt thành 10:

```java
// Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Lấy số slide
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Đặt số slide
    pres.setFirstSlideNumber(10);
	
    // Lưu bản trình chiếu đã sửa
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Nếu bạn muốn bỏ qua slide đầu tiên, bạn có thể bắt đầu đánh số từ slide thứ hai (và ẩn số cho slide đầu tiên) như sau:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Đặt số cho slide đầu tiên của bản trình chiếu
    presentation.setFirstSlideNumber(0);

    // Hiển thị số slide cho tất cả các slide
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Ẩn số slide cho slide đầu tiên
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Lưu bản trình chiếu đã sửa
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Số slide mà người dùng thấy có khớp với chỉ mục bắt đầu từ 0 của bộ sưu tập không?**

Số hiển thị trên slide có thể bắt đầu từ bất kỳ giá trị nào (ví dụ: 10) và không nhất thiết phải khớp với chỉ mục; mối quan hệ này được kiểm soát bởi thiết lập [first slide number](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) của bản trình chiếu.

**Các slide ẩn có ảnh hưởng đến việc đánh chỉ mục không?**

Có. Một slide ẩn vẫn tồn tại trong bộ sưu tập và được tính vào chỉ mục; "ẩn" chỉ đề cập đến việc hiển thị, không phải vị trí trong bộ sưu tập.

**Chỉ mục của một slide có thay đổi khi các slide khác được thêm hoặc xóa không?**

Có. Chỉ mục luôn phản ánh thứ tự hiện tại của các slide và sẽ được tính lại khi thực hiện các thao tác chèn, xóa hoặc di chuyển.