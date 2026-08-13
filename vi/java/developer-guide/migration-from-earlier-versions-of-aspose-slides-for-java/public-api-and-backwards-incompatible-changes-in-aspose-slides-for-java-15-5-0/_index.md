---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 15.5.0
linktitle: Aspose.Slides cho Java 15.5.0
type: docs
weight: 130
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
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
description: "Xem xét các cập nhật API công cộng và các thay đổi gây lỗi trong Aspose.Slides cho Java để di chuyển mượt mà các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính đã được thêm, bất kỳ hạn chế mới nào và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) được giới thiệu trong API Aspose.Slides for Java 15.5.0.

{{% /alert %}} 
## **Các thay đổi API công cộng**
### **Đã thêm lớp CommonSlideViewProperties và giao diện ICommonSlideViewProperties**
com.aspose.slides.CommonSlideViewProperties class (và giao diện com.aspose.slides.ICommonSlideViewProperties) đại diện cho các thuộc tính hiển thị slide chung (hiện tại là các tùy chọn tỷ lệ hiển thị).

### **Đã thêm các phương thức IAxis.getLabelOffset() và setLabelOffset(int)**
Các phương thức IAxis.getLabelOffset() và setLabelOffset(int) cho phép lấy và chỉ định khoảng cách của nhãn so với trục. Áp dụng cho trục danh mục hoặc trục ngày.

### **Đã thêm các phương thức IChartTextBlockFormat.getAutofitType() và setAutofitType(byte)**
Các phương thức getAutofitType() và setAutofitType(/**TextAutofitType**/byte) đã được thêm vào giao diện com.aspose.slides.IChartTextBlockFormat.  
Việc thay đổi giá trị này chỉ có thể ảnh hưởng nhất định đối với các thành phần biểu đồ sau: DataLabel và DataLabelFormat (hỗ trợ đầy đủ trong PowerPoint 2013; trong PowerPoint 2007 không có ảnh hưởng đối với việc render).

### **Đã thêm các phương thức IChartTextBlockFormat.getWrapText() và setWrapText(byte)**
Các phương thức getWrapText() và setWrapText(/**NullableBool**/byte) đã được thêm vào giao diện com.aspose.slides.IChartTextBlockFormat.  
Việc thay đổi giá trị này chỉ có thể ảnh hưởng nhất định đối với các thành phần biểu đồ sau: DataLabel và DataLabelFormat (hỗ trợ đầy đủ trong PowerPoint 2007/2013).

### **Đã thêm các phương thức quản lý lề vào IChartTextBlockFormat**
Các phương thức getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() và setMarginBottom(double) đã được thêm vào giao diện com.aspose.slides.IChartTextBlockFormat.  
Việc thay đổi các giá trị này chỉ có thể ảnh hưởng nhất định đối với các thành phần biểu đồ sau: DataLabel và DataLabelFormat (hỗ trợ đầy đủ trong PowerPoint 2013; trong PowerPoint 2007 không có ảnh hưởng đối với việc render).

### **Đã thêm phương thức ViewProperties.getNotesViewProperties()**
Thuộc tính com.aspose.slides.ViewProperties.getNotesViewProperties() đã được thêm. Nó lấy các thuộc tính hiển thị chung liên quan đến chế độ xem ghi chú.

### **Đã thêm phương thức ViewProperties.getSlideViewProperties()**
Phương thức com.aspose.slides.ViewProperties.getSlideViewProperties() đã được thêm. Nó lấy các thuộc tính hiển thị chung liên quan đến chế độ xem slide.