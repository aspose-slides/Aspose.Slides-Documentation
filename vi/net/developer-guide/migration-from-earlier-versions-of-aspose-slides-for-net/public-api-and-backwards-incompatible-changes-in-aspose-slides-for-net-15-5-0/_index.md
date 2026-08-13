---
title: "Công khai API và Các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 15.5.0"
linktitle: "Aspose.Slides cho .NET 15.5.0"
type: docs
weight: 160
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- phương pháp kế thừa
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi phá vỡ trong Aspose.Slides cho .NET để di chuyển suôn sẻ các giải pháp bản trình bày PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 
Trang này liệt kê tất cả các lớp, phương thức, thuộc tính đã [added](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) hoặc [removed](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) và các thay đổi khác được giới thiệu trong API Aspose.Slides cho .NET 15.5.0.
{{% /alert %}} 
## **Thay đổi API công khai**
#### **Lớp CommonSlideViewProperties và giao diện ICommonSlideViewProperties đã được thêm vào**
Lớp Aspose.Slides.CommonSlideViewProperties và giao diện Aspose.Slides.ICommonSlideViewProperties đại diện cho các thuộc tính hiển thị slide chung (hiện tại là các tùy chọn tỷ lệ hiển thị).
#### **Thuộc tính IAxis.LabelOffset đã được thêm vào**
Thuộc tính IAxis.LabelOffset xác định khoảng cách của các nhãn so với trục. Áp dụng cho trục danh mục hoặc trục ngày.
#### **Thuộc tính IChartTextBlockFormat.AutofitType đã được thêm vào**
Việc thay đổi thuộc tính này chỉ có thể tạo ra ảnh hưởng nhất định cho các phần biểu đồ sau: DataLabel và DataLabelFormat (hỗ trợ đầy đủ trong PowerPoint 2013; trong PowerPoint 2007 không có hiệu ứng khi render).
#### **Thuộc tính IChartTextBlockFormat.WrapText đã được thêm vào**
Việc thay đổi thuộc tính này chỉ có thể tạo ra ảnh hưởng nhất định cho các phần biểu đồ sau: DataLabel và DataLabelFormat (hỗ trợ đầy đủ trong PowerPoint 2007/2013).
#### **Các thuộc tính Margin đã được thêm vào IChartTextBlockFormat**
Việc thay đổi các thuộc tính này chỉ có thể tạo ra ảnh hưởng nhất định cho các phần biểu đồ sau: DataLabel và DataLabelFormat (hỗ trợ đầy đủ trong PowerPoint 2013; trong PowerPoint 2007 không có hiệu ứng khi render).
#### **Thuộc tính ViewProperties.NotesViewProperties đã được thêm vào**
Thuộc tính Aspose.Slides.ViewProperties.NotesViewProperties đã được thêm vào. Nó chỉ định các thuộc tính hiển thị chung liên quan đến chế độ hiển thị ghi chú.
#### **Thuộc tính ViewProperties.SlideViewProperties đã được thêm vào**
Thuộc tính Aspose.Slides.ViewProperties.SlideViewProperties đã được thêm vào. Nó chỉ định các thuộc tính hiển thị chung liên quan đến chế độ hiển thị slide.