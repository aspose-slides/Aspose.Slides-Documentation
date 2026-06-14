---
title: Xóa các slide khỏi bài thuyết trình trên Android
linktitle: Xóa slide
type: docs
weight: 30
url: /vi/androidjava/remove-slide-from-presentation/
keywords:
- xóa slide
- xoá slide
- xóa slide không sử dụng
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Dễ dàng xóa các slide khỏi bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Android. Nhận các ví dụ mã Java rõ ràng và nâng cao quy trình làm việc của bạn."
---
## **Giới thiệu**

Nếu một slide (hoặc nội dung của nó) trở nên dư thừa, bạn có thể xóa nó. Aspose.Slides cung cấp lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) bao gói [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/), là kho chứa tất cả các slide trong một bài thuyết trình. Bằng cách sử dụng con trỏ (tham chiếu hoặc chỉ mục) cho một đối tượng [ISlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/) đã biết, bạn có thể chỉ định slide muốn xóa.

## **Xóa một slide bằng tham chiếu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu của slide bạn muốn xóa thông qua ID hoặc Chỉ mục của nó.
1. Xóa slide đã được tham chiếu khỏi bài thuyết trình.
1. Lưu bài thuyết trình đã chỉnh sửa. 

Đoạn mã Java dưới đây cho thấy cách xóa một slide bằng tham chiếu:

```java
// Tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình
Presentation pres = new Presentation("demo.pptx");
try {
    // Truy cập một slide thông qua chỉ mục của nó trong bộ sưu tập slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Xóa một slide bằng tham chiếu của nó
    pres.getSlides().remove(slide);
    
    // Lưu bài thuyết trình đã chỉnh sửa
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Xóa một slide bằng chỉ mục**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Xóa slide khỏi bài thuyết trình bằng vị trí chỉ mục của nó.
1. Lưu bài thuyết trình đã chỉnh sửa. 

Đoạn mã Java dưới đây cho thấy cách xóa một slide bằng chỉ mục:

```java
// Tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình
Presentation pres = new Presentation("demo.pptx");
try {
    // Xóa một slide bằng chỉ mục slide của nó
    pres.getSlides().removeAt(0);
    
    // Lưu bài thuyết trình đã chỉnh sửa
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Xóa các slide bố cục không dùng**

Aspose.Slides cung cấp phương thức [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (từ lớp [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/)) để cho phép bạn xóa các slide bố cục không mong muốn và không được sử dụng. Đoạn mã Java dưới đây cho thấy cách xóa một slide bố cục khỏi bài thuyết trình PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa các slide chủ không dùng**

Aspose.Slides cung cấp phương thức [removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (từ lớp [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/)) để cho phép bạn xóa các slide chủ không mong muốn và không được sử dụng. Đoạn mã Java dưới đây cho thấy cách xóa một slide chủ khỏi bài thuyết trình PowerPoint:

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

**Điều gì xảy ra với chỉ mục của slide sau khi tôi xóa một slide?**

Sau khi xóa, [collection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidecollection/) sẽ được đánh chỉ mục lại: mỗi slide tiếp theo dịch sang trái một vị trí, vì vậy các số chỉ mục trước đó trở nên lỗi thời. Nếu bạn cần một tham chiếu ổn định, hãy sử dụng ID bền vững của mỗi slide thay vì chỉ mục của nó.

**ID của slide có khác với chỉ mục không, và nó có thay đổi khi các slide lân cận bị xóa không?**

Có. Chỉ mục là vị trí của slide và sẽ thay đổi khi các slide được thêm hoặc xóa. ID của slide là một định danh cố định và không thay đổi khi các slide khác bị xóa.

**Xóa một slide ảnh hưởng như thế nào đến các phần (section) của slide?**

Nếu slide thuộc về một phần, phần đó sẽ chỉ còn ít hơn một slide. Cấu trúc phần vẫn giữ nguyên; nếu một phần trở nên trống, bạn có thể [xóa hoặc tổ chức lại các phần](/slides/vi/androidjava/slide-section/) khi cần.

**Điều gì xảy ra với ghi chú và bình luận gắn vào một slide khi nó bị xóa?**

[Notes](/slides/vi/androidjava/presentation-notes/) và [comments](/slides/vi/androidjava/presentation-comments/) được gắn vào slide cụ thể đó và sẽ bị xóa cùng với nó. Nội dung trên các slide khác không bị ảnh hưởng.

**Xóa slide khác như thế nào so với việc dọn dẹp các bố cục/master không sử dụng?**

Xóa loại bỏ các slide bình thường cụ thể khỏi bộ trình chiếu. Dọn dẹp các bố cục/master không sử dụng loại bỏ các slide bố cục hoặc master mà không có bất kỳ tham chiếu nào, giảm kích thước tệp mà không thay đổi nội dung các slide còn lại. Hai thao tác này bổ sung cho nhau: thường nên xóa trước, sau đó dọn dẹp.