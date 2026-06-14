---
title: Cách Thêm Headers & Footers vào Bản Trình Chiếu trong .NET
linktitle: Thêm Header & Footer
type: docs
weight: 20
url: /vi/net/how-to-add-header-footer-in-a-presentation/
keywords:
- di chuyển
- thêm header
- thêm footer
- mã legacy
- mã hiện đại
- cách tiếp cận legacy
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thêm headers và footers trong các bản trình chiếu PowerPoint PPT, PPTX và ODP trong .NET bằng cả API legacy và hiện đại của Aspose.Slides."
---
{{% alert color="primary" %}}

Một phiên bản mới của [Aspose.Slides for .NET API](/slides/vi/net/) đã được phát hành và hiện sản phẩm duy nhất này hỗ trợ khả năng tạo tài liệu PowerPoint từ đầu và chỉnh sửa các tài liệu hiện có.

{{% /alert %}}
## **Hỗ trợ Mã Legacy**
Để sử dụng mã legacy được phát triển với các phiên bản Aspose.Slides for .NET trước 13.x, bạn cần thực hiện một số thay đổi nhỏ trong mã của mình và mã sẽ hoạt động như trước. Tất cả các lớp đã có trong Aspose.Slides for .NET cũ dưới các namespace Aspose.Slide và Aspose.Slides.Pptx hiện đã được hợp nhất trong một namespace Aspose.Slides duy nhất. Vui lòng xem đoạn mã mẫu đơn giản dưới đây để thêm header footer vào bản trình chiếu trong API Aspose.Slides legacy và làm theo các bước mô tả cách di chuyển sang API hợp nhất mới.
## **Cách tiếp cận Legacy Aspose.Slides cho .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Thiết lập thuộc tính hiển thị Header Footer
sourcePres.UpdateSlideNumberFields = true;

//Cập nhật các trường Ngày Giờ
sourcePres.UpdateDateTimeFields = true;

//Hiển thị placeholder ngày giờ
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Hiển thị placeholder chân trang
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Hiển thị Số slide
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Đặt hiển thị  header footer trên Slide tiêu đề
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Ghi bản trình chiếu vào đĩa
sourcePres.Write("NewSource.pptx");
```

```c#
//Tạo bản trình chiếu
Presentation pres = new Presentation();

//Lấy slide đầu tiên
Slide sld = pres.GetSlideByPosition(1);

//Truy cập Header / Footer của slide
HeaderFooter hf = sld.HeaderFooter;

//Đặt hiển thị Số trang
hf.PageNumberVisible = true;

//Đặt hiển thị Footer
hf.FooterVisible = true;

//Đặt hiển thị Header
hf.HeaderVisible = true;

//Đặt hiển thị Ngày Giờ
hf.DateTimeVisible = true;

//Đặt định dạng Ngày Giờ
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Đặt văn bản Header
hf.HeaderText = "Header Text";

//Đặt văn bản Footer
hf.FooterText = "Footer Text";

//Ghi bản trình chiếu vào đĩa
pres.Write("HeadFoot.ppt");
```



## **Cách tiếp cận mới Aspose.Slides cho .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Thiết lập thuộc tính hiển thị Header Footer
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Cập nhật các trường Ngày Giờ
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Hiển thị placeholder ngày giờ
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Hiển thị placeholder chân trang
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Set the  header footer visibility on Title Slide
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Ghi bản trình chiếu vào đĩa
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```