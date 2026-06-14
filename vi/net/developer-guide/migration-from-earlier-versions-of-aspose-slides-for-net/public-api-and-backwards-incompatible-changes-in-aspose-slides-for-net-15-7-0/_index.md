---
title: Thay đổi API công cộng và không tương thích ngược trong Aspose.Slides cho .NET 15.7.0
linktitle: Aspose.Slides cho .NET 15.7.0
type: docs
weight: 180
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- di chuyển
- code cũ
- code hiện đại
- phương pháp cũ
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để di chuyển giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn một cách suôn sẻ."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các thành phần khác [đã thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) hoặc [đã loại bỏ](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/), và các thay đổi khác được giới thiệu trong API Aspose.Slides cho .NET 15.7.0.

{{% /alert %}} 
## **Thay đổi API công cộng**
#### **Enum ImagePixelFormat đã được thêm**
Enum Aspose.Slides.Export.ImagePixelFormat đã được thêm để chỉ định định dạng pixel cho các hình ảnh được tạo.
#### **Phương thức IChartDataPoint.GetAutomaticDataPointColor() đã được thêm**
Trả về màu tự động cho điểm dữ liệu dựa trên chỉ số chuỗi, chỉ số điểm dữ liệu, ParentSeriesGroup, thuộc tính IsColorVaried và kiểu biểu đồ.
Màu này sẽ được sử dụng mặc định nếu FillType bằng NotDefined.
#### **Phương thức RenderToGraphics đã được thêm vào Slide**
Phương thức RenderToGraphics (và các overload của nó) đã được thêm vào Aspose.Slides.Slide để vẽ một slide lên đối tượng Graphics.
#### **Thuộc tính PixelFormat đã được thêm vào ITiffOptions và TiffOptions**
Thuộc tính PixelFormat đã được thêm vào Aspose.Slides.Export.ITiffOptions và Aspose.Slides.Export.TiffOptions để chỉ định định dạng pixel cho các ảnh TIFF được tạo.