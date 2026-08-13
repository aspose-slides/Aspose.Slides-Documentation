---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 15.5.0
linktitle: Aspose.Slides برای .NET 15.5.0
type: docs
weight: 160
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را مرور کنید تا بتوانید به‌صورت روان راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت کنید."
---
{{% alert color="info" %}} 
این صفحه تمام [added](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) یا [removed](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) کلاس‌ها، متدها، ویژگی‌ها و غیره، و سایر تغییرات معرفی‌شده با Aspose.Slides برای .NET 15.5.0 API را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
#### **کلاس CommonSlideViewProperties و اینترفیس ICommonSlideViewProperties اضافه شدند**
کلاس Aspose.Slides.CommonSlideViewProperties و اینترفیس Aspose.Slides.ICommonSlideViewProperties ویژگی‌های نمای کلی اسلاید مشترک را نمایندگی می‌کنند (در حال حاضر گزینه‌های مقیاس‌نمایش).
#### **ویژگی IAxis.LabelOffset اضافه شد**
ویژگی IAxis.LabelOffset فاصله برچسب‌ها از محور را مشخص می‌کند. برای محور دسته‌بندی یا تاریخ اعمال می‌شود.
#### **ویژگی IChartTextBlockFormat.AutofitType اضافه شد**
تغییر این ویژگی می‌تواند تاثیر خاصی تنها بر روی این قسمت‌های نمودار داشته باشد: DataLabel و DataLabelFormat (پشتیبانی کامل در PowerPoint 2013؛ در PowerPoint 2007 هیچ اثری بر رندرینگ ندارد).
#### **ویژگی IChartTextBlockFormat.WrapText اضافه شد**
تغییر این ویژگی می‌تواند تاثیر خاصی تنها بر روی این قسمت‌های نمودار داشته باشد: DataLabel و DataLabelFormat (پشتیبانی کامل در PowerPoint 2007/2013).
#### **ویژگی‌های Margin به IChartTextBlockFormat اضافه شدند**
تغییر این ویژگی‌ها می‌تواند تاثیر خاصی تنها بر روی این قسمت‌های نمودار داشته باشد: DataLabel و DataLabelFormat (پشتیبانی کامل در PowerPoint 2013؛ در PowerPoint 2007 هیچ اثری بر رندرینگ ندارد).
#### **ویژگی ViewProperties.NotesViewProperties اضافه شد**
ویژگی Aspose.Slides.ViewProperties.NotesViewProperties اضافه شده است. این ویژگی ویژگی‌های نمای مشترک مرتبط با حالت نمای یادداشت‌ها را مشخص می‌کند.
#### **ویژگی ViewProperties.SlideViewProperties اضافه شد**
ویژگی Aspose.Slides.ViewProperties.SlideViewProperties اضافه شده است. این ویژگی ویژگی‌های نمای مشترک مرتبط با حالت نمای اسلاید را مشخص می‌کند.