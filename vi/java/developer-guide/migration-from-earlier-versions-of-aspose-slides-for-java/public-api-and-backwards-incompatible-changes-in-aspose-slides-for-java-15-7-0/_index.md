---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 15.7.0
linktitle: Aspose.Slides cho Java 15.7.0
type: docs
weight: 150
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- cách tiếp cận kế thừa
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi phá vỡ trong Aspose.Slides cho Java để di chuyển mượt mà các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 
Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các thành phần khác đã được [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) hoặc [đã loại bỏ](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) và các thay đổi khác được giới thiệu trong API Aspose.Slides cho Java 15.7.0. 
{{% /alert %}} 
## **Thay đổi API công khai**
#### **Enum com.aspose.slides.ImagePixelFormat đã được thêm**
Enum com.aspose.slides.ImagePixelFormat đã được thêm để chỉ định định dạng pixel cho các hình ảnh được tạo. 
#### **Phương thức com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() đã được thêm**
Phương thức này trả về màu tự động của điểm dữ liệu dựa trên chỉ số series, chỉ số điểm dữ liệu, parentSeriesGroup, giá trị isColorVaried và kiểu biểu đồ. Màu này được sử dụng mặc định nếu fillType bằng NotDefined. 
#### **Các phương thức getPixelFormat(), setPixelFormat(int) đã được thêm vào com.aspose.slides.ITiffOptions**
Các phương thức getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) đã được thêm vào com.aspose.slides.ITiffOptions và com.aspose.slides.TiffOptions để chỉ định định dạng pixel cho các ảnh TIFF được tạo. 
``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```