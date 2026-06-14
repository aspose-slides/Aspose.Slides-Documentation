---
title: Xóa các slide khỏi bản trình bày trong .NET
linktitle: Xóa slide
type: docs
weight: 30
url: /vi/net/remove-slide-from-presentation/
keywords:
- xóa slide
- xóa slide
- xóa slide không dùng
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Dễ dàng xóa các slide khỏi bản trình bày PowerPoint và OpenDocument với Aspose.Slides cho .NET. Nhận các ví dụ mã C# rõ ràng và nâng cao quy trình làm việc của bạn."
---
## **Giới thiệu**

Nếu một slide (hoặc nội dung của nó) trở nên không cần thiết, bạn có thể xóa nó. Aspose.Slides cung cấp lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) bao gồm [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection), là kho lưu trữ cho tất cả các slide trong một bản trình bày. Bằng cách dùng con trỏ (tham chiếu hoặc chỉ số) cho một đối tượng [ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/) đã biết, bạn có thể chỉ định slide muốn xóa.

## **Xóa một slide bằng tham chiếu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
1. Lấy tham chiếu của slide muốn xóa thông qua ID hoặc Index của nó.
1. Xóa slide đã tham chiếu khỏi bản trình bày.
1. Lưu bản trình bày đã chỉnh sửa.

Đoạn mã C# này cho thấy cách xóa một slide bằng tham chiếu:

```c#
 // Tạo một đối tượng Presentation đại diện cho một tệp bản trình bày
 using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
 {

     // Truy cập một slide thông qua chỉ mục của nó trong bộ sưu tập slides
     ISlide slide = pres.Slides[0];

     // Xóa một slide thông qua tham chiếu của nó
     pres.Slides.Remove(slide);

     // Lưu bản trình bày đã chỉnh sửa
     pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **Xóa một slide theo chỉ số**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
1. Xóa slide khỏi bản trình bày bằng vị trí chỉ số của nó.
1. Lưu bản trình bày đã chỉnh sửa.

Đoạn mã C# này cho thấy cách xóa một slide theo chỉ số:

```c#
 // Tạo một đối tượng Presentation đại diện cho một tệp bản trình bày
 using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
 {
 
     // Xóa một slide thông qua chỉ mục slide của nó
     pres.Slides.RemoveAt(0);
 
     // Lưu bản trình bày đã chỉnh sửa
     pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **Xóa các slide bố cục không dùng**

Aspose.Slides cung cấp phương thức [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (từ lớp [Compress](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/)) để cho phép bạn xóa các slide bố cục không mong muốn và không được sử dụng. Đoạn mã C# này cho thấy cách xóa một slide bố cục khỏi bản trình chiếu PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Xóa các slide chủ đề không dùng**

Aspose.Slides cung cấp phương thức [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (từ lớp [Compress](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/)) để cho phép bạn xóa các slide chủ đề không mong muốn và không được sử dụng. Đoạn mã C# này cho thấy cách xóa một slide chủ đề khỏi bản trình chiếu PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Điều gì xảy ra với chỉ số slide sau khi tôi xóa một slide?**

Sau khi xóa, [collection](https://reference.aspose.com/slides/vi/net/aspose.slides/slidecollection/) sẽ được đánh chỉ số lại: mỗi slide kế tiếp sẽ dịch sang trái một vị trí, do đó các số chỉ mục trước đó không còn chính xác. Nếu bạn cần một tham chiếu ổn định, hãy sử dụng ID cố định của mỗi slide thay vì chỉ mục của nó.

**ID của slide khác với chỉ số của nó, và nó có thay đổi khi các slide lân cận bị xóa không?**

Có. Chỉ số là vị trí của slide và sẽ thay đổi khi slide được thêm hoặc xóa. ID slide là một định danh cố định và không thay đổi khi các slide khác bị xóa.

**Việc xóa một slide ảnh hưởng như thế nào đến các phần (section) của slide?**

Nếu slide thuộc một phần, phần đó sẽ chỉ còn ít hơn một slide. Cấu trúc phần không thay đổi; nếu một phần trở nên trống, bạn có thể [xóa hoặc tổ chức lại các phần](/slides/vi/net/slide-section/) khi cần.

**Điều gì xảy ra với ghi chú và bình luận đính kèm vào slide khi nó bị xóa?**

[Notes](/slides/vi/net/presentation-notes/) và [comments](/slides/vi/net/presentation-comments/) được gắn vào slide cụ thể đó và sẽ bị xóa cùng với nó. Nội dung trên các slide khác không bị ảnh hưởng.

**Việc xóa slide khác gì so với việc dọn dẹp các bố cục/máster không dùng?**

Xóa sẽ loại bỏ các slide bình thường cụ thể khỏi bộ trình chiếu. Dọn dẹp các bố cục/máster không dùng sẽ xóa các slide bố cục hoặc máster mà không có slide nào tham chiếu, giảm kích thước tệp mà không thay đổi nội dung các slide còn lại. Hai hành động này bổ sung cho nhau: thường thực hiện xóa trước, sau đó dọn dẹp.