---
title: Xóa slide khỏi bản trình chiếu trong Java
linktitle: Xóa slide
type: docs
weight: 30
url: /vi/java/remove-slide-from-presentation/
keywords:
- xóa slide
- xoá slide
- xóa slide không sử dụng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Dễ dàng xóa slide khỏi các bản trình chiếu PowerPoint và OpenDocument với Aspose.Slides cho Java. Nhận các ví dụ mã rõ ràng và tăng cường quy trình làm việc của bạn."
---
## **Giới thiệu**

Nếu một slide (hoặc nội dung của nó) trở nên thừa, bạn có thể xóa nó. Aspose.Slides cung cấp lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) bao bọc [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/), là kho lưu trữ cho tất cả các slide trong một bản trình chiếu. Bằng cách sử dụng con trỏ (tham chiếu hoặc chỉ mục) cho một đối tượng [ISlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/) đã biết, bạn có thể chỉ định slide mà bạn muốn xóa. 

## **Xóa một Slide bằng Tham chiếu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
1. Lấy tham chiếu của slide mà bạn muốn xóa thông qua ID hoặc Index của nó.
1. Xóa slide đã tham chiếu khỏi bản trình chiếu.
1. Lưu bản trình chiếu đã được chỉnh sửa. 

Đoạn mã Java này cho bạn thấy cách xóa một slide bằng tham chiếu của nó:
```java
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu
Presentation pres = new Presentation("demo.pptx");
try {
    // Truy cập một slide thông qua chỉ mục của nó trong bộ sưu tập slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Xóa một slide thông qua tham chiếu của nó
    pres.getSlides().remove(slide);
    
    // Lưu bản trình chiếu đã chỉnh sửa
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Xóa một Slide bằng Chỉ mục**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
1. Xóa slide khỏi bản trình chiếu thông qua vị trí chỉ mục của nó.
1. Lưu bản trình chiếu đã được chỉnh sửa. 

Đoạn mã Java này cho bạn thấy cách xóa một slide bằng chỉ mục của nó:
```java
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu
Presentation pres = new Presentation("demo.pptx");
try {
    // Xóa một slide thông qua chỉ mục slide của nó
    pres.getSlides().removeAt(0);
    
    // Lưu bản trình chiếu đã chỉnh sửa
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Xóa các Slide Bố cục Không được sử dụng**

Aspose.Slides cung cấp phương thức [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (từ lớp [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/)) để cho phép bạn xóa các slide bố cục không mong muốn và không được sử dụng. Đoạn mã Java này cho bạn thấy cách xóa một slide bố cục khỏi bản trình chiếu PowerPoint:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa các Slide Master Không được sử dụng**

Aspose.Slides cung cấp phương thức [removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (từ lớp [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/)) để cho phép bạn xóa các slide master không mong muốn và không được sử dụng. Đoạn mã Java này cho bạn thấy cách xóa một slide master khỏi bản trình chiếu PowerPoint:
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **Câu hỏi thường gặp**

**Đi gì xảy ra với chỉ mục slide sau khi tôi xóa một slide?**

Sau khi xóa, [collection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidecollection/) sẽ được lập chỉ mục lại: mọi slide tiếp theo sẽ dịch sang trái một vị trí, vì vậy các số chỉ mục trước đó trở nên lỗi thời. Nếu bạn cần tham chiếu ổn định, hãy sử dụng ID cố định của mỗi slide thay vì chỉ mục của nó.

**ID của một slide có khác với chỉ mục của nó không, và nó có thay đổi khi các slide lân cận bị xóa không?**

Có. Chỉ mục là vị trí của slide và sẽ thay đổi khi các slide được thêm hoặc xóa. ID slide là một định danh cố định và không thay đổi khi các slide khác bị xóa.

**Xóa một slide ảnh hưởng như thế nào đến các phần của slide?**

Nếu slide thuộc một phần, phần đó sẽ chỉ còn ít hơn một slide. Cấu trúc phần vẫn giữ nguyên; nếu một phần trở nên rỗng, bạn có thể [xóa hoặc tổ chức lại các phần](/slides/vi/java/slide-section/) khi cần.

**Đi gì xảy ra với ghi chú và bình luận gắn vào một slide khi nó bị xóa?**

[Notes](/slides/vi/java/presentation-notes/) và [comments](/slides/vi/java/presentation-comments/) được gắn vào slide cụ thể đó và sẽ bị xóa cùng với nó. Nội dung trên các slide khác không bị ảnh hưởng.

**Xóa slide khác với việc dọn dẹp các bố cục/master không được sử dụng như thế nào?**

Xóa bỏ các slide bình thường cụ thể khỏi bộ slide. Dọn dẹp các bố cục/master không được sử dụng loại bỏ các slide bố cục hoặc master mà không có ai tham chiếu, giảm kích thước tệp mà không thay đổi nội dung các slide còn lại. Hai hành động này bổ trợ cho nhau: thường thực hiện xóa trước, sau đó dọn dẹp.