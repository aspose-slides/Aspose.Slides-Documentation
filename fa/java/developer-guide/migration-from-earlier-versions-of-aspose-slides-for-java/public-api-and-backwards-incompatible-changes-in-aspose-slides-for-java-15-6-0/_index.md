---
title: "API عمومی و تغییرات ناسازگار معکوس در Aspose.Slides برای جاوا 15.6.0"
linktitle: "Aspose.Slides برای جاوا 15.6.0"
type: docs
weight: 140
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
  - "مهاجرت"
  - "کدهای میراثی"
  - "کد مدرن"
  - "رویکرد قدیمی"
  - "رویکرد مدرن"
  - "PowerPoint"
  - "OpenDocument"
  - "ارائه"
  - "جاوا"
  - "Aspose.Slides"
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای جاوا را بررسی کنید تا به‌راحتی راه‌حل‌های ارائه PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره اضافه‌شده، هر محدودیت جدید و سایر تغییرات معرفی‌شده با API Aspose.Slides for Java 15.6.0 را فهرست می‌کند. برای جزئیات می‌توانید به صفحهٔ [added](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) و [changes](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) مراجعه کنید.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **امضای سازنده com.aspose.slides.DataLabel تغییر کرده است**
امضای سازنده از DataLabel(com.aspose.slides.IChartSeries) به DataLabel(com.aspose.slides.IChartDataPoint) تغییر یافت.

#### **اعضای com.aspose.slides.IDocumentProperties.getCount()، .getPropertyName(int index).، .remove(String name)، .contains(String name) به‌عنوان منسوخ علامت‌گذاری شده‌اند؛ به‌جای آن‌ها جایگزین‌هایی معرفی شده‌اند**
متدهای IDocumentProperties.getCount()، IDocumentProperties.getPropertyName(int index).، .remove(string name)، .contains(string name) به‌عنوان منسوخ علامت‌گذاری شده‌اند. به‌جای آن‌ها متدهای IDocumentProperties.countOfCustomProperties()، IDocumentProperties.getCustomPropertyName(int index).، .removeCustomProperty(String name)، .containsCustomProperty(string name) معرفی شده‌اند.

#### **متد com.aspose.slides.INotesSlideManager.removeNotesSlide() اضافه شده است**
متد com.aspose.slides.INotesSlideManager.RemoveNotesSlide() برای حذف اسلاید یادداشت یک اسلاید اضافه شده است.

#### **متد com.aspose.slides.ISlide.getNotesSlideManager() اضافه شده است. متدهای ISlide.getNotesSlide() و ISlide.addNotesSlide() به‌عنوان منسوخ علامت‌گذاری شده‌اند**
متدهای ISlide.getNotesSlide() و ISlide.addNotesSlide() به‌عنوان منسوخ علامت‌گذاری شده‌اند. به‌جای آن از متد جدید ISSlide.getNotesSlideManager() استفاده کنید.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - منسوخ

// notes = slide.getNotesSlide(); - منسوخ

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **متد getAppVersion() به com.aspose.slides.IDocumentProperties اضافه شده است**
متد com.aspose.slides.IDocumentProperties.getAppVersion() برای دریافت ویژگی داخلی سند که نشان‌دهنده شماره‌های نسخه داخلی استفاده‌شده توسط Microsoft PowerPoint است، اضافه شده است.

#### **متد remove() به com.aspose.slides.IComment اضافه شده است**
متد com.aspose.slides.IComment.remove() برای حذف نظر از مجموعه اضافه شده است.

#### **متد remove() به com.aspose.slides.ICommentAuthor اضافه شده است**
متد ICommentAuthor.Remove برای حذف نویسندهٔ نظرات از مجموعه اضافه شده است.

#### **متدهای clearCustomProperties() و clearBuiltInProperties() به com.aspose.slides.IDocumentProperties اضافه شده‌اند**
متد com.aspose.slides.IDocumentProperties.clearCustomProperties() برای حذف تمام ویژگی‌های سفارشی سند اضافه شده است.
متد com.aspose.slides.IDocumentProperties.clearBuiltInProperties() برای حذف و تنظیم مقادیر پیش‌فرض تمام ویژگی‌های داخلی سند (Company, Subject, Author و غیره) اضافه شده است.

#### **متدهای getBlackWhiteMode()، setBlackWhiteMode(byte) به com.aspose.slides.IShape اضافه شده‌اند**
متدهای getBlackWhiteMode() و setBlackWhiteMode(byte) به com.aspose.slides.IShape افزوده شده‌اند. این متدها تعیین می‌کنند شکل در حالت نمایش سیاه‑سفید چگونه رندر شود. مقادیر ممکن در کلاس com.aspose.slides.BlackWhiteMode تعریف شده‌اند.

|**مقدار**|**معنی**|
| :- | :- |
|Color|رنگ|
|Automatic|خودکار|
|Gray|خاکستری|
|LightGray|خاکستری روشن|
|InverseGray|خاکستری معکوس|
|GrayWhite|خاکستری‑سفید|
|BlackGray|سیاه‑خاکستری|
|BlackWhite|سیاه‑سفید|
|Black|سیاه|
|White|سفید|
|Hidden|پنهان|

#### **متدهای removeAt(int)، remove(ICommentAuthor) و clear() به com.aspose.slides.ICommentAuthorCollection اضافه شده‌اند**
متد ICommentAuthorCollection.removeAt(int) برای حذف نویسنده بر اساس اندیس مشخص اضافه شده است. متد ICommentAuthorCollection.remove(ICommentAuthor) برای حذف نویسندهٔ مشخص از مجموعه اضافه شده است. متد ICommentAuthorCollection.clear() برای حذف تمام موارد از مجموعه اضافه شده است.