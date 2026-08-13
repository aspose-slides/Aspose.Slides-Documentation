---
title: "API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای جاوا 15.5.0"
linktitle: "Aspose.Slides برای جاوا 15.5.0"
type: docs
weight: 130
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- "مهاجرت"
- "کد قدیمی"
- "کد مدرن"
- "رویکرد قدیمی"
- "رویکرد مدرن"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Java"
- "Aspose.Slides"
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای جاوا را مرور کنید تا به‌صورت روان راه‌حل‌های ارائه PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 

این صفحه تمام [added](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) کلاس‌ها، متدها، ویژگی‌ها و غیره، هر محدودیت جدید و سایر [changes](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) معرفی‌شده با API Aspose.Slides برای جاوا 15.5.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
### **CommonSlideViewProperties class and ICommonSlideViewProperties interface have been added**
کلاس CommonSlideViewProperties و اینترفیس ICommonSlideViewProperties اضافه شده‌اند
### **IAxis.getLabelOffset(), setLabelOffset(int) methods have been added**
متدهای IAxis.getLabelOffset() و setLabelOffset(int) اضافه شده‌اند
### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) methods have been added**
متدهای IChartTextBlockFormat.getAutofitType() و setAutofitType(byte) اضافه شده‌اند
متدهای getAutofitType() و setAutofitType(/**TextAutofitType**/byte) به اینترفیس com.aspose.slides.IChartTextBlockFormat اضافه شده‌اند. تغییر این مقدار می‌تواند تنها بر این بخش‌های نمودار تأثیر بگذارد: DataLabel و DataLabelFormat (پشتیبانی کامل در PowerPoint 2013؛ در PowerPoint 2007 هیچ اثر رندرینگ ندارد).
### **Methods IChartTextBlockFormat.getWrapText(), setWrapText(byte) have been added**
متدهای IChartTextBlockFormat.getWrapText() و setWrapText(byte) اضافه شده‌اند
متدهای getWrapText() و setWrapText(/**NullableBool**/byte) به اینترفیس com.aspose.slides.IChartTextBlockFormat اضافه شده‌اند. تغییر این مقدار می‌تواند تنها بر این بخش‌های نمودار تأثیر بگذارد: DataLabel و DataLabelFormat (پشتیبانی کامل در PowerPoint 2007/2013).
### **The methods to manage margins have been added to IChartTextBlockFormat**
متدهای مدیریت حاشیه‌ها به IChartTextBlockFormat اضافه شده‌اند
متدهای getMarginLeft()، setMarginLeft(double)، getMarginRight()، setMarginRight(double)، getMarginTop()، setMarginTop(double)، getMarginBottom() و setMarginBottom(double) به اینترفیس com.aspose.slides.IChartTextBlockFormat اضافه شده‌اند. تغییر این مقادیر می‌تواند تنها بر این بخش‌های نمودار تأثیر بگذارد: DataLabel و DataLabelFormat (پشتیبانی کامل در PowerPoint 2013؛ در PowerPoint 2007 هیچ اثر رندرینگ ندارد).
### **ViewProperties.getNotesViewProperties() method have been added**
متد ViewProperties.getNotesViewProperties() اضافه شده است
ویژگی com.aspose.slides.ViewProperties.getNotesViewProperties() اضافه شده است. این ویژگی ویژگی‌های نمای مشترک مرتبط با حالت نمای یادداشت‌ها را دریافت می‌کند.
### **ViewProperties.getSlideViewProperties() method has been added**
متد ViewProperties.getSlideViewProperties() اضافه شده است
متد com.aspose.slides.ViewProperties.getSlideViewProperties() اضافه شده است. این متد ویژگی‌های نمای مشترک مرتبط با حالت نمای اسلاید را دریافت می‌کند.