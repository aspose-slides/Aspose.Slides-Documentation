---
title: Xóa các slide khỏi bản trình chiếu trong JavaScript
linktitle: Xóa Slide
type: docs
weight: 30
url: /vi/nodejs-java/remove-slide-from-presentation/
keywords:
- xóa slide
- xoá slide
- xóa slide không sử dụng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Dễ dàng xóa các slide khỏi bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js. Nhận các ví dụ mã rõ ràng và tăng năng suất công việc của bạn."
---
## **Giới thiệu**

Nếu một slide (hoặc nội dung của nó) trở nên thừa, bạn có thể xóa nó. Aspose.Slides cung cấp lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) mà bao gồm [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/), là kho lưu trữ cho tất cả các slide trong một bản trình chiếu. Bằng cách sử dụng con trỏ (tham chiếu hoặc chỉ số) cho một đối tượng [Slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/), bạn có thể chỉ định slide muốn xóa.

## **Xóa Slide bằng Tham chiếu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy tham chiếu của slide bạn muốn xóa thông qua ID hoặc Index của nó.
1. Xóa slide đã tham chiếu khỏi bản trình chiếu.
1. Lưu bản trình chiếu đã sửa đổi. 

```javascript
// Tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Truy cập một slide thông qua chỉ mục của nó trong tập hợp slide
    var slide = pres.getSlides().get_Item(0);
    // Xóa một slide thông qua tham chiếu của nó
    pres.getSlides().remove(slide);
    // Lưu bản trình chiếu đã sửa đổi
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Xóa Slide theo Chỉ mục**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Xóa slide khỏi bản trình chiếu thông qua vị trí chỉ mục của nó.
1. Lưu bản trình chiếu đã sửa đổi. 

```javascript
// Tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Xóa một slide thông qua chỉ mục slide của nó
    pres.getSlides().removeAt(0);
    // Lưu bản trình chiếu đã sửa đổi
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Xóa Layout Slide không sử dụng**

Aspose.Slides cung cấp phương thức [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) (từ lớp [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/)) để cho phép bạn xóa các layout slide không mong muốn và không được sử dụng. Đoạn mã JavaScript này cho bạn thấy cách xóa một layout slide khỏi bản trình chiếu PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xóa Master Slide không sử dụng**

Aspose.Slides cung cấp phương thức [removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (từ lớp [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/)) để cho phép bạn xóa các master slide không mong muốn và không được sử dụng. Đoạn mã JavaScript này cho bạn thấy cách xóa một master slide khỏi bản trình chiếu PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Xảy ra gì với chỉ mục slide sau khi tôi xóa một slide?**

Sau khi xóa, [collection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/) sẽ được đánh chỉ mục lại: mỗi slide tiếp theo dịch sang trái một vị trí, vì vậy các số chỉ mục trước đó trở nên lỗi thời. Nếu bạn cần một tham chiếu ổn định, hãy sử dụng ID bền vững của mỗi slide thay vì chỉ mục của nó.

**ID của slide có khác với chỉ mục của nó không, và nó có thay đổi khi các slide liền kề bị xóa không?**

Có. Chỉ mục là vị trí của slide và sẽ thay đổi khi slide được thêm hoặc xóa. ID của slide là một định danh bền vững và không thay đổi khi các slide khác bị xóa.

**Xóa slide ảnh hưởng như thế nào đến các phần (section) của slide?**

Nếu slide thuộc về một phần, phần đó sẽ chỉ còn ít hơn một slide. Cấu trúc phần vẫn giữ nguyên; nếu một phần trở nên rỗng, bạn có thể [xóa hoặc tổ chức lại các phần](/slides/vi/nodejs-java/slide-section/) theo nhu cầu.

**Điều gì xảy ra với ghi chú và bình luận gắn vào một slide khi nó bị xóa?**

[Notes](/slides/vi/nodejs-java/presentation-notes/) và [comments](/slides/vi/nodejs-java/presentation-comments/) được gắn vào slide đó và sẽ bị xóa cùng với nó. Nội dung trên các slide khác không bị ảnh hưởng.

**Xóa slide khác với việc dọn dẹp các layout/master không sử dụng như thế nào?**

Xóa loại bỏ các slide bình thường cụ thể khỏi bộ slide. Dọn dẹp các layout/master không sử dụng sẽ loại bỏ các layout hoặc master slide mà không có tham chiếu nào, giảm kích thước tệp mà không thay đổi nội dung các slide còn lại. Hai hành động này bổ trợ cho nhau: thường thực hiện xóa trước, sau đó dọn dẹp.