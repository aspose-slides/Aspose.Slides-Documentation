---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 15.5.0
linktitle: Aspose.Slides cho .NET 15.5.0
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
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và các thay đổi phá vỡ trong Aspose.Slides cho .NET để di chuyển suôn sẻ các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}}

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác đã [được thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) hoặc [được xóa](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) và các thay đổi khác được giới thiệu trong API Aspose.Slides for .NET 15.5.0.

{{% /alert %}}
## **Thay đổi API công cộng**
#### **Lớp CommonSlideViewProperties và Giao diện ICommonSlideViewProperties đã được thêm**
Lớp Aspose.Slides.CommonSlideViewProperties và giao diện Aspose.Slides.ICommonSlideViewProperties đại diện cho các thuộc tính hiển thị slide chung (hiện tại là các tùy chọn tỷ lệ hiển thị).
#### **Thuộc tính IAxis.LabelOffset đã được thêm**
Thuộc tính IAxis.LabelOffset chỉ định khoảng cách của nhãn so với trục. Áp dụng cho trục danh mục hoặc trục ngày.
#### **Thuộc tính IChartTextBlockFormat.AutofitType đã được thêm**
Việc thay đổi thuộc tính này có thể gây ảnh hưởng nhất định chỉ đối với các phần biểu đồ sau: DataLabel và DataLabelFormat (hỗ trợ đầy đủ trong PowerPoint 2013; trong PowerPoint 2007 không có hiệu ứng khi hiển thị).
#### **Thuộc tính IChartTextBlockFormat.WrapText đã được thêm**
Việc thay đổi thuộc tính này có thể gây ảnh hưởng nhất định chỉ đối với các phần biểu đồ sau: DataLabel và DataLabelFormat (hỗ trợ đầy đủ trong PowerPoint 2007/2013).
#### **Các thuộc tính Margin đã được thêm vào IChartTextBlockFormat**
Việc thay đổi các thuộc tính này có thể gây ảnh hưởng nhất định chỉ đối với các phần biểu đồ sau: DataLabel và DataLabelFormat (hỗ trợ đầy đủ trong PowerPoint 2013; trong PowerPoint 2007 không có hiệu ứng khi hiển thị).
#### **Thuộc tính ViewProperties.NotesViewProperties đã được thêm**
Thuộc tính Aspose.Slides.ViewProperties.NotesViewProperties đã được thêm. Nó chỉ định các thuộc tính hiển thị chung liên quan đến chế độ xem ghi chú.
#### **Thuộc tính ViewProperties.SlideViewProperties đã được thêm**
Thuộc tính Aspose.Slides.ViewProperties.SlideViewProperties đã được thêm. Nó chỉ định các thuộc tính hiển thị chung liên quan đến chế độ xem slide.