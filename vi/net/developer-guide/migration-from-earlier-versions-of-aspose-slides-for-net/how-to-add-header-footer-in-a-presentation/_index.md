---
title: Cách Thêm Headers & Footers vào Presentations trong .NET
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
- bài trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thêm header và footer vào các bản trình chiếu PowerPoint PPT, PPTX và ODP trong .NET bằng cả API Aspose.Slides legacy và hiện đại."
---
{{% alert color="info" %}} 

Một [Aspose.Slides for .NET API](/slides/vi/net/) mới đã được phát hành và giờ sản phẩm duy nhất này hỗ trợ khả năng tạo tài liệu PowerPoint từ đầu và chỉnh sửa các tài liệu hiện có.

{{% /alert %}} 
## **Hỗ trợ mã legacy**
Để sử dụng mã legacy được phát triển với Aspose.Slides for .NET các phiên bản trước 13.x, bạn cần thực hiện một vài thay đổi nhỏ trong mã và mã sẽ hoạt động như trước. Tất cả các lớp từng có trong Aspose.Slides for .NET cũ dưới các không gian tên Aspose.Slide và Aspose.Slides.Pptx hiện đã được hợp nhất vào không gian tên duy nhất Aspose.Slides. Vui lòng xem đoạn mã mẫu dưới đây để thêm header footer vào bản trình chiếu trong API Aspose.Slides legacy và làm theo các bước mô tả cách di chuyển sang API hợp nhất mới.
## **Cách tiếp cận Legacy Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Thiết lập thuộc tính hiển thị Header Footer
//Cập nhật các trường Date Time
//Hiển thị trình giữ chỗ ngày giờ
//Hiển thị trình giữ chỗ footer
//Hiển thị số slide
//Đặt hiển thị header footer trên Slide tiêu đề
//Ghi bản trình chiếu vào đĩa
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//Tạo bản trình chiếu
//Lấy slide đầu tiên
//Truy cập Header / Footer của slide
//Đặt hiển thị số trang
//Đặt hiển thị Footer
//Đặt hiển thị Header
//Đặt hiển thị Date Time
//Đặt định dạng Date Time
//Đặt văn bản Header
//Đặt văn bản Footer
//Ghi bản trình chiếu vào đĩa
Presentation pres = new Presentation();

//Get first slide
Slide sld = pres.GetSlideByPosition(1);

//Access the Header / Footer of the slide
HeaderFooter hf = sld.HeaderFooter;

//Set Page Number Visibility
hf.PageNumberVisible = true;

//Set Footer Visibility
hf.FooterVisible = true;

//Set Header Visibility
hf.HeaderVisible = true;

//Set Date Time Visibility
hf.DateTimeVisible = true;

//Set Date Time format
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Set Header Text
hf.HeaderText = "Header Text";

//Set Footer Text
hf.FooterText = "Footer Text";

//Write the presentation to the disk
pres.Write("HeadFoot.ppt");
```



## **Cách tiếp cận Aspose.Slides for .NET 13.x mới**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Thiết lập các thuộc tính hiển thị Header Footer
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Cập nhật các trường Date Time
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Hiển thị trình giữ chỗ ngày giờ
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Hiển thị trình giữ chỗ footer
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Đặt hiển thị header footer trên Slide tiêu đề
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Ghi bản trình chiếu vào đĩa
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```