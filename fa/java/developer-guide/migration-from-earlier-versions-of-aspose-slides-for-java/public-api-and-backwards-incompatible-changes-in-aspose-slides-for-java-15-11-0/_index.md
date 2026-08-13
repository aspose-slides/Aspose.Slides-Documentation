---
title: API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای جاوا 15.11.0
linktitle: Aspose.Slides برای جاوا 15.11.0
type: docs
weight: 190
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای جاوا را مرور کنید تا به‌صورت روان راه‌حل‌های ارائه PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره که [added](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) یا [removed](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) هستند را فهرست می‌کند و سایر تغییرات معرفی‌شده در API Aspose.Slides for Java 15.11.0.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **متدهای منسوخ شده در کلاس com.aspose.slides.DataLabelCollection حذف شده‌اند**
متدهای منسوخ شده در کلاس com.aspose.slides.DataLabelCollection حذف شده‌اند:

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
هنگامی که مقدار جدیدی برای شماره اولین اسلاید مشخص می‌شود، تمام شماره اسلایدها دوباره محاسبه می‌شوند.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    int firstSlideNumber = pres.getFirstSlideNumber();

    pres.setFirstSlideNumber(10);

    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```