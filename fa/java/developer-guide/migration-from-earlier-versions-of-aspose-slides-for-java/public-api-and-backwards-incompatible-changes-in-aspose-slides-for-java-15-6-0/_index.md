---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای Java 15.6.0
linktitle: Aspose.Slides برای Java 15.6.0
type: docs
weight: 140
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- روش قدیمی
- روش مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای Java را بررسی کنید تا به‌صورت روان ارائه‌های PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره که [اضافه شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) هستند، هر محدودیت جدید و سایر [تغییرات](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) معرفی شده با API Aspose.Slides for Java 15.6.0 را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
#### **امضای سازنده com.aspose.slides.DataLabel تغییر کرده است**
امضای سازنده از DataLabel(com.aspose.slides.IChartSeries) به DataLabel(com.aspose.slides.IChartDataPoint) تغییر یافته است.
#### **اعضای com.aspose.slides.IDocumentProperties.getCount()، .getPropertyName(int index).، .remove(String name)، .contains(String name) به عنوان منقضی علامت‌گذاری شده‌اند؛ به جای آن‌ها جایگزین‌هایی معرفی شده است**
متدهای IDocumentProperties.getCount()، IDocumentProperties.getPropertyName(int index).، .remove(string name)، .contains(string name) به عنوان منقضی علامت‌گذاری شده‌اند. به جای آن‌ها متدهای IDocumentProperties.countOfCustomProperties()، IDocumentProperties.getCustomPropertyName(int index).، .removeCustomProperty(String name)، .containsCustomProperty(string name) معرفی شده‌اند.
#### **متد com.aspose.slides.INotesSlideManager.removeNotesSlide() اضافه شده است**
متد com.aspose.slides.INotesSlideManager.RemoveNotesSlide() برای حذف اسلاید یادداشت یک اسلاید اضافه شده است.
#### **متد com.aspose.slides.ISlide.getNotesSlideManager() اضافه شده است. متدهای ISlide.getNotesSlide() و ISlide.addNotesSlide() به عنوان منقضی علامت‌گذاری شده‌اند**
متدهای ISlide.getNotesSlide() و ISlide.addNotesSlide() به عنوان منقضی علامت‌گذاری شده‌اند. به جای آن از متد جدید ISlide.getNotesSlideManager() استفاده کنید.
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - منقضی

    // notes = slide.getNotesSlide(); - منقضی

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **متد getAppVersion() به com.aspose.slides.IDocumentProperties اضافه شده است**
متد com.aspose.slides.IDocumentProperties.getAppVersion() برای دریافت ویژگی داخلی سند که نشانگر شماره‌های نسخه داخلی استفاده شده توسط Microsoft PowerPoint است، اضافه شده است.
#### **متد remove() به com.aspose.slides.IComment اضافه شده است**
متد com.aspose.slides.IComment.remove() برای حذف نظر از مجموعه اضافه شده است.
#### **متد remove() به com.aspose.slides.ICommentAuthor اضافه شده است**
متد ICommentAuthor.Remove برای حذف نویسنده نظرات از مجموعه اضافه شده است.
#### **متدهای clearCustomProperties() و clearBuiltInProperties() به com.aspose.slides.IDocumentProperties اضافه شده‌اند**
متد com.aspose.slides.IDocumentProperties.clearCustomProperties() برای حذف تمام ویژگی‌های سفارشی سند اضافه شده است.
متد com.aspose.slides.IDocumentProperties.clearBuiltInProperties() برای حذف و تنظیم مقادیر پیش‌فرض برای تمام ویژگی‌های داخلی سند (Company, Subject, Author و غیره) اضافه شده است.
#### **متدهای getBlackWhiteMode() و setBlackWhiteMode(byte) به com.aspose.slides.IShape اضافه شده‌اند**
متدهای getBlackWhiteMode() و setBlackWhiteMode(byte) به com.aspose.slides.IShape اضافه شده‌اند. این متدها تعیین می‌کنند که یک شکل چگونه در حالت نمایش سیاه‑سفید رندر شود. مقادیر ممکن در کلاس com.aspose.slides.BlackWhiteMode مشخص شده‌اند.

|Value|Meaning|
| :- | :- |
|Color|بازگشت با رنگ‌بندی عادی|
|Automatic|بازگشت با رنگ‌بندی خودکار|
|Gray|بازگشت با رنگ خاکستری|
|LightGray|بازگشت با رنگ خاکستری روشن|
|InverseGray|بازگشت با رنگ خاکستری معکوس|
|GrayWhite|بازگشت با رنگ خاکستری و سفید|
|BlackGray|بازگشت با رنگ سیاه و خاکستری|
|BlackWhite|بازگشت با رنگ سیاه و سفید|
|Black|بازگشت فقط با رنگ سیاه|
|White|بازگشت با رنگ سفید|
|Hidden|شیء رندر نمی‌شود|
#### **متدهای removeAt(int)، remove(ICommentAuthor) و clear() به com.aspose.slides.ICommentAuthorCollection اضافه شده‌اند**
متد ICommentAuthorCollection.removeAt(int) برای حذف نویسنده با ایندکس مشخص اضافه شده است. متد ICommentAuthorCollection.remove(ICommentAuthor) برای حذف نویسنده مشخص از مجموعه اضافه شده است. متد ICommentAuthorCollection.clear() برای حذف تمام آیتم‌ها از مجموعه اضافه شده است.