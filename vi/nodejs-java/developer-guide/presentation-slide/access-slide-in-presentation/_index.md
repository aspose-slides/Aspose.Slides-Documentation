---
title: Truy cập các slide trong bài thuyết trình bằng JavaScript
linktitle: Truy cập Slide
type: docs
weight: 20
url: /vi/nodejs-java/access-slide-in-presentation/
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
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách truy cập và quản lý các slide trong bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js. Tăng năng suất với các ví dụ mã."
---
## **Tổng quan**

Bài viết này giải thích cách truy cập và quản lý các slide trong một bài trình chiếu bằng Aspose.Slides. Nó cho thấy cách lấy các slide theo chỉ mục bắt đầu từ 0 trong bộ sưu tập slide và cách truy cập một slide bằng ID duy nhất của nó bằng phương thức `getSlideById`.

Bạn cũng sẽ học cách thay đổi vị trí của slide bằng phương thức `setSlideNumber` và cách xác định số slide bắt đầu cho một bài trình chiếu bằng phương thức `setFirstSlideNumber`. Các ví dụ minh họa việc tải một bài trình chiếu, lấy tham chiếu slide, cập nhật thứ tự hoặc số thứ tự slide, và lưu lại bài trình chiếu đã chỉnh sửa.

## **Truy cập Slide theo Chỉ mục**

Tất cả các slide trong một bài trình chiếu được sắp xếp theo thứ tự số dựa trên vị trí slide, bắt đầu từ 0. Slide đầu tiên có thể truy cập bằng chỉ mục 0; slide thứ hai bằng chỉ mục 1; v.v.

Lớp Presentation, đại diện cho một tệp bài trình chiếu, cung cấp tất cả các slide dưới dạng một bộ sưu tập [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/) (bộ sưu tập các đối tượng [Slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/)). Đoạn mã JavaScript này cho bạn thấy cách truy cập một slide qua chỉ mục của nó:

```javascript
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Truy cập một slide bằng chỉ mục slide
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Truy cập Slide theo ID**

Mỗi slide trong một bài trình chiếu có một ID duy nhất gắn với nó. Bạn có thể sử dụng phương thức [getSlideById](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/)) để nhắm mục tiêu ID đó. Đoạn mã JavaScript này cho bạn thấy cách cung cấp một ID slide hợp lệ và truy cập slide đó qua phương thức [getSlideById](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSlideById-long-):

```javascript
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Nhận ID của slide
    var id = pres.getSlides().get_Item(0).getSlideId();
    // Truy cập slide thông qua ID của nó
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Thay đổi Vị trí Slide**

Aspose.Slides cho phép bạn thay đổi vị trí của một slide. Ví dụ, bạn có thể chỉ định rằng slide đầu tiên sẽ trở thành slide thứ hai.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy tham chiếu của slide (có vị trí bạn muốn thay đổi) qua chỉ mục của nó
1. Đặt vị trí mới cho slide qua thuộc tính [setSlideNumber](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#setSlideNumber-int-).
1. Lưu bài trình chiếu đã chỉnh sửa.

Đoạn mã JavaScript này minh họa một thao tác trong đó slide ở vị trí 1 được di chuyển tới vị trí 2:

```javascript
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Lấy slide mà vị trí sẽ được thay đổi
    var sld = pres.getSlides().get_Item(0);
    // Đặt vị trí mới cho slide
    sld.setSlideNumber(2);
    // Lưu bài thuyết trình đã chỉnh sửa
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Slide đầu tiên trở thành slide thứ hai; slide thứ hai trở thành slide đầu tiên. Khi bạn thay đổi vị trí của một slide, các slide khác sẽ tự động được điều chỉnh.

## **Đặt Số Slide**

Sử dụng thuộc tính [setFirstSlideNumber](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/)), bạn có thể chỉ định một số mới cho slide đầu tiên trong một bài trình chiếu. Thao tác này sẽ làm cho các số slide khác được tính lại.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy số slide.
1. Đặt số slide.
1. Lưu bài trình chiếu đã chỉnh sửa.

Đoạn mã JavaScript này minh họa một thao tác trong đó số slide đầu tiên được đặt thành 10:

```javascript
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // Lấy số slide
    var firstSlideNumber = pres.getFirstSlideNumber();
    // Đặt số slide
    pres.setFirstSlideNumber(10);
    // Lưu bài thuyết trình đã chỉnh sửa
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Nếu bạn muốn bỏ qua slide đầu tiên, bạn có thể bắt đầu đánh số từ slide thứ hai (và ẩn số thứ tự cho slide đầu tiên) như sau:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // Đặt số cho slide đầu tiên của bài thuyết trình
    presentation.setFirstSlideNumber(0);
    // Hiển thị số slide cho tất cả các slide
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);
    // Ẩn số slide cho slide đầu tiên
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);
    // Lưu bài thuyết trình đã chỉnh sửa
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Số slide mà người dùng thấy có khớp với chỉ mục bắt đầu từ 0 của bộ sưu tập không?**

Số được hiển thị trên một slide có thể bắt đầu từ một giá trị tùy ý (ví dụ, 10) và không bắt buộc phải khớp với chỉ mục; mối quan hệ này được điều khiển bởi thiết lập [first slide number](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) của bài trình chiếu.

**Các slide ẩn có ảnh hưởng đến việc đánh chỉ mục không?**

Có. Slide ẩn vẫn tồn tại trong bộ sưu tập và được tính vào việc đánh chỉ mục; “ẩn” chỉ đề cập đến việc hiển thị, không phải vị trí của nó trong bộ sưu tập.

**Chỉ mục của một slide có thay đổi khi các slide khác được thêm hoặc xóa không?**

Có. Chỉ mục luôn phản ánh thứ tự hiện tại của các slide và được tính lại khi thực hiện các thao tác chèn, xóa hoặc di chuyển.