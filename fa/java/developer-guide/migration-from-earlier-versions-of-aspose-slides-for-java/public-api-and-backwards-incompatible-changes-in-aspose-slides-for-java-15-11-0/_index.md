---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای Java 15.11.0
linktitle: Aspose.Slides برای Java 15.11.0
type: docs
weight: 190
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای Java را بررسی کنید تا بتوانید به‌صورت روان برنامه‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 
این صفحه تمام [اضافه‌شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) یا [حذف‌شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) کلاس‌ها، متدها، ویژگی‌ها و موارد مشابه، و سایر تغییراتی که با Aspose.Slides برای Java 15.11.0 API معرفی شده‌اند را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
#### **متدهای منسوخ‌شده در کلاس com.aspose.slides.DataLabelCollection حذف شده‌اند**
متدهای منسوخ‌شده در کلاس com.aspose.slides.DataLabelCollection حذف شده‌اند:

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


#### **متدهای جدید getFirstSlideNumber() و setFirstSlideNumber() به کلاس Presentation اضافه شده‌اند**
متدهای جدید getFirstSlideNumber() و setFirstSlideNumber() امکان دریافت یا تنظیم شماره اولین اسلاید در یک ارائه را فراهم می‌کنند.
هنگامی که مقدار جدید شماره اولین اسلاید مشخص شود، تمام شماره‌های اسلاید مجدداً محاسبه می‌شوند.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```