---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای Java 15.5.0
linktitle: Aspose.Slides برای Java 15.5.0
type: docs
weight: 130
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
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
description: "به‌روزرسانی‌های API عمومی و تغییرات مخرب در Aspose.Slides برای Java را بررسی کنید تا به‌صورت روان برنامه‌های ارائه PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 

این صفحه تمام [اضافه‌شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) کلاس‌ها، متدها، ویژگی‌ها و غیره، هر محدودیت جدید و سایر [تغییرات](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) معرفی‌شده با API Aspose.Slides for Java 15.5.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
### **کلاس CommonSlideViewProperties و رابط ICommonSlideViewProperties اضافه شده‌اند**
کلاس com.aspose.slides.CommonSlideViewProperties (و رابط آن com.aspose.slides.ICommonSlideViewProperties) ویژگی‌های نمای اسلاید عمومی را نمایان می‌کند (در حال حاضر گزینه‌های مقیاس‌گذاری نمای).
### **متدهای IAxis.getLabelOffset() و setLabelOffset(int) اضافه شده‌اند**
متدهای IAxis.getLabelOffset() و setLabelOffset(int) امکان دریافت و تعیین فاصله برچسب‌ها از محور را فراهم می‌کنند. برای محور دسته‌ای یا تاریخ اعمال می‌شود.
### **متدهای IChartTextBlockFormat.getAutofitType() و setAutofitType(byte) اضافه شده‌اند**
متدهای getAutofitType()، setAutofitType(/**TextAutofitType**/byte) به رابط com.aspose.slides.IChartTextBlockFormat اضافه شده‌اند.
تغییر این مقدار می‌تواند فقط بر روی این بخش‌های نمودار تأثیر بگذارد: DataLabel و DataLabelFormat (پشتیبانی کامل در PowerPoint 2013؛ در PowerPoint 2007 هیچ اثر رندری ندارد).
### **متدهای IChartTextBlockFormat.getWrapText() و setWrapText(byte) اضافه شده‌اند**
متدهای getWrapText()، setWrapText(/**NullableBool**/byte) به رابط com.aspose.slides.IChartTextBlockFormat اضافه شده‌اند.
تغییر این مقدار می‌تواند تنها بر این بخش‌های نمودار تأثیر بگذارد: DataLabel و DataLabelFormat (پشتیبانی کامل در PowerPoint 2007/2013).
### **متدهای مدیریت حاشیه‌ها به IChartTextBlockFormat اضافه شده‌اند**
متدهای getMarginLeft()، setMarginLeft(double)، getMarginRight()، setMarginRight(double)، getMarginTop()، setMarginTop(double)، getMarginBottom() و setMarginBottom(double) به رابط com.aspose.slides.IChartTextBlockFormat اضافه شده‌اند.
تغییر این مقادیر می‌تواند فقط بر این بخش‌های نمودار تأثیر بگذارد: DataLabel و DataLabelFormat (پشتیبانی کامل در PowerPoint 2013؛ در PowerPoint 2007 هیچ اثر رندری ندارد).
### **متد ViewProperties.getNotesViewProperties() اضافه شده است**
ویژگی com.aspose.slides.ViewProperties.getNotesViewProperties() اضافه شده است. این ویژگی ویژگی‌های نمای عمومی مرتبط با حالت نمای یادداشت‌ها را دریافت می‌کند.
### **متد ViewProperties.getSlideViewProperties() اضافه شده است**
متد com.aspose.slides.ViewProperties.getSlideViewProperties() اضافه شده است. این متد ویژگی‌های نمای عمومی مرتبط با حالت نمای اسلاید را دریافت می‌کند.