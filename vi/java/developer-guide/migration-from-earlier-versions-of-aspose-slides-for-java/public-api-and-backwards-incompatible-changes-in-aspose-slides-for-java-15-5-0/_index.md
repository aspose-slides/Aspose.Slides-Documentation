---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 15.5.0
linktitle: Aspose.Slides cho Java 15.5.0
type: docs
weight: 130
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- di chuyển
- mã di sản
- mã hiện đại
- cách tiếp cận di sản
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho Java để di chuyển suôn sẻ các giải pháp trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục tương tự đã được [đã thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/), bất kỳ hạn chế mới và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) nào được giới thiệu cùng với API Aspose.Slides for Java 15.5.0.

{{% /alert %}} 
## **Thay đổi API công khai**
### **Đã thêm lớp CommonSlideViewProperties và giao diện ICommonSlideViewProperties**
Lớp com.aspose.slides.CommonSlideViewProperties (và giao diện com.aspose.slides.ICommonSlideViewProperties) đại diện cho các thuộc tính xem slide chung (hiện tại là các tùy chọn tỉ lệ xem).
### **Đã thêm các phương thức IAxis.getLabelOffset(), setLabelOffset(int)**
Các phương thức IAxis.getLabelOffset(), setLabelOffset(int) cho phép lấy và chỉ định khoảng cách của các nhãn so với trục. Áp dụng cho trục danh mục hoặc trục ngày.
### **Đã thêm các phương thức IChartTextBlockFormat.getAutofitType(), setAutofitType(byte)**
Các phương thức getAutofitType(), setAutofitType(/**TextAutofitType**/byte) đã được thêm vào giao diện com.aspose.slides.IChartTextBlockFormat.  
Thay đổi giá trị này chỉ có thể tạo ra một ảnh hưởng nhất định cho các phần biểu đồ sau: DataLabel và DataLabelFormat (hỗ trợ đầy đủ trong PowerPoint 2013; trong PowerPoint 2007 không có hiệu ứng khi render).
### **Đã thêm các phương thức IChartTextBlockFormat.getWrapText(), setWrapText(byte)**
Các phương thức getWrapText(), setWrapText(/**NullableBool**/byte) đã được thêm vào giao diện com.aspose.slides.IChartTextBlockFormat.  
Thay đổi giá trị này chỉ có thể tạo ra một ảnh hưởng nhất định cho các phần biểu đồ sau: DataLabel và DataLabelFormat (hỗ trợ đầy đủ trong PowerPoint 2007/2013).
### **Các phương thức quản lý lề đã được thêm vào IChartTextBlockFormat**
Các phương thức getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() và setMarginBottom(double) đã được thêm vào giao diện com.aspose.slides.IChartTextBlockFormat.  
Thay đổi các giá trị này chỉ có thể tạo ra một ảnh hưởng nhất định cho các phần biểu đồ sau: DataLabel và DataLabelFormat (hỗ trợ đầy đủ trong PowerPoint 2013; trong PowerPoint 2007 không có hiệu ứng khi render).
### **Đã thêm phương thức ViewProperties.getNotesViewProperties()**
Đã thêm thuộc tính com.aspose.slides.ViewProperties.getNotesViewProperties(). Nó lấy các thuộc tính xem chung liên quan tới chế độ xem ghi chú.
### **Đã thêm phương thức ViewProperties.getSlideViewProperties()**
Đã thêm phương thức com.aspose.slides.ViewProperties.getSlideViewProperties(). Nó lấy các thuộc tính xem chung liên quan tới chế độ xem slide.