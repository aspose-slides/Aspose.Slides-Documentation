---
title: API Công khai và Các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 15.7.0
linktitle: Aspose.Slides cho .NET 15.7.0
type: docs
weight: 180
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- cách tiếp cận cũ
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và những thay đổi gây phá vỡ trong Aspose.Slides cho .NET để di chuyển suôn sẻ các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các thành phần khác [được thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) hoặc [được xóa](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/), và các thay đổi khác được đưa vào API Aspose.Slides cho .NET 15.7.0.

{{% /alert %}} 
## **Public API Changes**
#### **Enum ImagePixelFormat Has Been Added**
Enum Aspose.Slides.Export.ImagePixelFormat đã được thêm vào để chỉ định định dạng pixel cho các hình ảnh được tạo.
#### **IChartDataPoint.GetAutomaticDataPointColor() Method Has Been Added**
Phương thức IChartDataPoint.GetAutomaticDataPointColor() đã được thêm vào. Trả về màu tự động của điểm dữ liệu dựa trên chỉ số chuỗi, chỉ số điểm dữ liệu, ParentSeriesGroup, thuộc tính IsColorVaried và kiểu biểu đồ. Màu này được sử dụng mặc định nếu FillType bằng NotDefined.
#### **Method RenderToGraphics Has Been Added to Slide**
Phương thức RenderToGraphics (và các overload của nó) đã được thêm vào Aspose.Slides.Slide để render slide vào đối tượng Graphics.
#### **Property PixelFormat Has Been Added to ITiffOptions and TiffOptions**
Thuộc tính PixelFormat đã được thêm vào Aspose.Slides.Export.ITiffOptions và Aspose.Slides.Export.TiffOptions để chỉ định định dạng pixel cho các ảnh TIFF được tạo.