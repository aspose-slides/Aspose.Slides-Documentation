---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 15.11.0
linktitle: Aspose.Slides cho .NET 15.11.0
type: docs
weight: 210
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- cách tiếp cận cổ điển
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây lỗi trong Aspose.Slides cho .NET để di chuyển mượt mà các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các thành phần khác [được thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) hoặc [được loại bỏ](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) và các thay đổi khác được giới thiệu trong API Aspose.Slides for .NET 15.11.0.

{{% /alert %}} 
## **Thay đổi API công khai**

#### **Các thuộc tính lỗi thời trong lớp DataLabelCollection đã bị xóa**
Obsolete properties in DataLabelCollection class have been deleted:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **Thuộc tính mới FirstSlideNumber đã được thêm vào lớp Presentation**
Thuộc tính mới FirstSlideNumber được thêm vào Presentation cho phép lấy hoặc đặt số slide đầu tiên trong một bài thuyết trình.

Khi giá trị FirstSlideNumber mới được chỉ định, tất cả các số slide sẽ được tính lại.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```