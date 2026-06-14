---
title: Truy cập slide trong bản trình chiếu trên Android
linktitle: Truy cập Slide
type: docs
weight: 20
url: /vi/androidjava/access-slide-in-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách truy cập và quản lý các slide trong bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Android. Tăng năng suất với các ví dụ mã Java."
---
## **Overview**

Bài viết này giải thích cách truy cập và quản lý các slide trong một bài thuyết trình bằng Aspose.Slides. Nó cho thấy cách lấy các slide theo chỉ mục bắt đầu từ 0 từ bộ sưu tập slide và cách truy cập một slide bằng ID duy nhất của nó bằng phương thức `getSlideById`.

Bạn cũng sẽ học cách thay đổi vị trí của một slide bằng phương thức `setSlideNumber` và cách xác định số slide bắt đầu cho một bài thuyết trình bằng phương thức `setFirstSlideNumber`. Các ví dụ minh họa việc tải một bài thuyết trình, lấy tham chiếu slide, cập nhật thứ tự hoặc đánh số slide, và lưu lại bài thuyết trình đã sửa đổi.

## **Access a Slide by Index**

Tất cả các slide trong một bài thuyết trình được sắp xếp theo số dựa trên vị trí slide, bắt đầu từ 0. Slide đầu tiên có thể truy cập bằng chỉ mục 0; slide thứ hai bằng chỉ mục 1; v.v.

Lớp Presentation, đại diện cho tệp bài thuyết trình, cung cấp tất cả các slide dưới dạng một bộ sưu tập [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/) (bộ sưu tập các đối tượng [ISlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/)). Đoạn mã Java này cho bạn thấy cách truy cập một slide qua chỉ mục của nó:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("demo.pptx");
try {
    // Truy cập một slide bằng chỉ mục slide của nó
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Access a Slide by ID**

Mỗi slide trong một bài thuyết trình có một ID duy nhất liên kết với nó. Bạn có thể sử dụng phương thức [getSlideById](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSlideById-long-) (được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/)) để truy cập ID đó. Đoạn mã Java này cho bạn thấy cách cung cấp một ID slide hợp lệ và truy cập slide đó qua phương thức [getSlideById](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSlideById-long-):

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

## **Change the Slide Position**

Aspose.Slides cho phép bạn thay đổi vị trí của một slide. Ví dụ, bạn có thể chỉ định slide đầu tiên sẽ trở thành slide thứ hai.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu của slide (mà bạn muốn thay đổi vị trí) qua chỉ mục của nó
1. Đặt vị trí mới cho slide qua thuộc tính [setSlideNumber](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#setSlideNumber-int-).
1. Lưu bài thuyết trình đã chỉnh sửa.

Đoạn mã Java này minh họa một thao tác trong đó slide ở vị trí 1 được chuyển tới vị trí 2: 

```java
// Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Lấy slide mà vị trí sẽ được thay đổi
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Đặt vị trí mới cho slide
    sld.setSlideNumber(2);
    
    // Lưu bản trình chiếu đã chỉnh sửa
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Slide đầu tiên trở thành slide thứ hai; slide thứ hai trở thành slide đầu tiên. Khi bạn thay đổi vị trí của một slide, các slide khác sẽ tự động được điều chỉnh.

## **Set the Slide Number**

Sử dụng thuộc tính [setFirstSlideNumber](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/)), bạn có thể chỉ định một số mới cho slide đầu tiên trong một bài thuyết trình. Thao tác này sẽ làm cho các số slide khác được tính lại.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy số slide.
1. Đặt số slide.
1. Lưu bài thuyết trình đã chỉnh sửa.

Đoạn mã Java này minh họa một thao tác mà số slide đầu tiên được đặt thành 10: 

```java
// Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Lấy số slide
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Đặt số slide
    pres.setFirstSlideNumber(10);
	
    // Lưu bản trình chiếu đã chỉnh sửa
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Nếu bạn muốn bỏ qua slide đầu tiên, bạn có thể bắt đầu việc đánh số từ slide thứ hai (và ẩn việc đánh số cho slide đầu tiên) như sau:

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

    // Lưu bản trình chiếu đã chỉnh sửa
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Does the slide number a user sees match the collection’s zero-based index?**

Số được hiển thị trên một slide có thể bắt đầu từ một giá trị tùy ý (ví dụ, 10) và không nhất thiết phải khớp với chỉ mục; mối quan hệ này được kiểm soát bởi cài đặt [first slide number](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) của bài thuyết trình.

**Do hidden slides affect indexing?**

Đúng. Một slide ẩn vẫn nằm trong bộ sưu tập và được tính vào việc đánh chỉ mục; "ẩn" chỉ liên quan đến việc hiển thị, không phải vị trí của nó trong bộ sưu tập.

**Does a slide’s index change when other slides are added or removed?**

Đúng. Chỉ mục luôn phản ánh thứ tự hiện tại của các slide và được tính lại khi thực hiện các thao tác chèn, xóa hoặc di chuyển.