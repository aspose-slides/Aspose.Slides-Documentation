---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 15.11.0
linktitle: Aspose.Slides cho Java 15.11.0
type: docs
weight: 190
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- cách tiếp cận legacy
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và những thay đổi gây phá vỡ trong Aspose.Slides cho Java để di chuyển một cách suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 
Trang này liệt kê tất cả các lớp, phương thức, thuộc tính [added](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) hoặc [removed](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) và các thay đổi khác được giới thiệu trong API Aspose.Slides for Java 15.11.0.
{{% /alert %}} 
## **Thay đổi API công khai**
#### **Các phương thức lỗi thời trong lớp com.aspose.slides.DataLabelCollection đã bị xóa**
Obsolete methods in com.aspose.slides.DataLabelCollection class have been deleted:

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)


#### **Các phương thức mới getFirstSlideNumber() và setFirstSlideNumber() đã được thêm vào lớp Presentation**
Các phương thức mới getFirstSlideNumber() và setFirstSlideNumber() cho phép lấy hoặc đặt số thứ tự của slide đầu tiên trong một bản trình chiếu.
Khi giá trị số slide đầu tiên mới được chỉ định, tất cả các số slide sẽ được tính lại.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```