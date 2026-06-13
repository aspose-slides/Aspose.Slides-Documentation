---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 15.6.0
linktitle: Aspose.Slides برای .NET 15.6.0
type: docs
weight: 170
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- مهاجرت
- کد ارثی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای .NET را بررسی کنید تا بتوانید به‌صورت روان راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}}

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابهی که [اضافه‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) یا [حذف‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) هستند، و سایر تغییرات معرفی‌شده در API Aspose.Slides for .NET 15.6.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **امضای سازنده DataLabel تغییر کرده است**
امضای سازنده DataLabel تغییر کرده است:
قبلاً: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
اکنون: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **اعضا IDocumentProperties.Count، .GetPropertyName(int index)، .Remove(string name)، .Contains(string name) به‌عنوان منسوخ علامت‌گذاری شده‌اند و جایگزین‌هایشان معرفی شده‌اند.**
خاصیت IDocumentProperties.Count و متدهای IDocumentProperties.GetPropertyName(int index)، .Remove(string name)، .Contains(string name) به‌عنوان منسوخ علامت‌گذاری شده‌اند. خاصیت IDocumentProperties.CountOfCustomProperties و متدهای IDocumentProperties.GetCustomPropertyName(int index)، .RemoveCustomProperty(string name)، .ContainsCustomProperty(string name) به‌جای آنها اضافه شده‌اند.
#### **متد INotesSlideManager.RemoveNotesSlide() اضافه شده است**
متد INotesSlideManager.RemoveNotesSlide() برای حذف اسلاید یادداشت‌های یک اسلاید اضافه شده است.
#### **متد Remove به IComment اضافه شده است**
متد IComment.Remove برای حذف نظرات از مجموعه اضافه شده است.
#### **متد Remove به ICommentAuthor اضافه شده است**
متد ICommentAuthor.Remove برای حذف نویسندهٔ نظرات از مجموعه اضافه شده است.
#### **متدهای ClearCustomProperties و ClearBuiltInProperties به IDocumentProperties اضافه شده‌اند**
متد IDocumentProperties.ClearCustomProperties برای حذف همهٔ خصوصیات سفارشی سند اضافه شده است.
متد IDocumentProperties.ClearBuiltInProperties برای حذف و تنظیم مقادیر پیش‌فرض همهٔ خصوصیات داخلی سند (Company، Subject، Author و غیره) اضافه شده است.
#### **متدهای RemoveAt، Remove و Clear به ICommentAuthorCollection اضافه شده‌اند**
متد ICommentAuthorCollection.RemoveAt برای حذف نویسنده بر اساس اندیس مشخص اضافه شده است.
متد ICommentAuthorCollection.Remove برای حذف نویسندهٔ مشخصی از مجموعه اضافه شده است.
متد ICommentAuthorCollection.Clear برای حذف تمام آیتم‌ها از مجموعه اضافه شده است.
#### **خاصیت AppVersion به IDocumentProperties اضافه شده است**
خاصیت IDocumentProperties.AppVersion برای دریافت خصوصیت داخلی سند که شماره‌های نسخه داخلی مورد استفاده مایکروسافت در طول توسعه را نشان می‌دهد، اضافه شده است.
#### **خاصیت BlackWhiteMode به IShape و Shape اضافه شده است**
خاصیت BlackWhiteMode به IShape و به Shape اضافه شده است.
این خاصیت تعیین می‌کند که یک شکل چگونه در حالت نمایش سیاه‑سفید رندر شود.

|**مقدار** |**معنی** |
| :- | :- |
|Color |رندر با رنگ‌بندی معمولی |
|Automatic |رندر با رنگ‌بندی خودکار |
|Gray |رندر با رنگ خاکستری |
|LightGray |رندر با رنگ خاکستری روشن |
|InverseGray |رندر با رنگ خاکستری معکوس |
|GrayWhite |رندر با رنگ خاکستری و سفید |
|BlackGray |رندر با رنگ سیاه و خاکستری |
|BlackWhite |رندر با رنگ سیاه و سفید |
|Black |فقط با رنگ سیاه رندر شود |
|White |با رنگ سفید رندر شود |
|Hidden |رندر نشود |
|NotDefined|به معنی این است که خاصیت تنظیم نشده است|
#### **خاصیت ISlide.NotesSlideManager اضافه شده است. خاصیت ISlide.NotesSlide و متد ISlide.AddNotesSlide() به عنوان منسوخ علامت‌گذاری شده‌اند.**
اعضای ISlide.NotesSlide و ISlide.AddNotesSlide() به‌عنوان منسوخ علامت‌گذاری شده‌اند. به‌جای آنها از خاصیت جدید ISlide.NotesSlideManager استفاده کنید.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - منسوخ

// notes = slide.NotesSlide; - منسوخ

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```