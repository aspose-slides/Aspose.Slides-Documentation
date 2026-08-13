---
title: API عمومی و تغییرات ناسازگار با عقب‌گرد در Aspose.Slides برای .NET 15.6.0
linktitle: Aspose.Slides برای .NET 15.6.0
type: docs
weight: 170
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- مهاجرت
- کد ارثی
- کد مدرن
- رویکرد ارثی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روز‌رسانی‌های API عمومی و تغییرات مخرب در Aspose.Slides برای .NET را مرور کنید تا به‌راحتی راه‌حل‌های ارائه PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}}

این صفحه تمام کلاس‌ها، متدها، خصوصیت‌ها و غیره‌ای که [اضافه‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) یا [حذف‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) هستند، و سایر تغییرات معرفی‌شده در API Aspose.Slides برای .NET 15.6.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **امضای سازنده DataLabel تغییر کرده است**
امضای سازنده DataLabel تغییر کرده است: قبلاً: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries); اکنون: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).

#### **اعضای IDocumentProperties.Count، .GetPropertyName(int index)، .Remove(string name)، .Contains(string name) به عنوان منسوخ علامت‌گذاری شده‌اند و جایگزین‌های آنها معرفی شده‌اند.**
ویژگی IDocumentProperties.Count و متدهای IDocumentProperties.GetPropertyName(int index)، .Remove(string name)، .Contains(string name) به عنوان منسوخ علامت‌گذاری شده‌اند. ویژگی IDocumentProperties.CountOfCustomProperties و متدهای IDocumentProperties.GetCustomPropertyName(int index)، .RemoveCustomProperty(string name)، .ContainsCustomProperty(string name) به جای آن اضافه شده‌اند.

#### **متد INotesSlideManager.RemoveNotesSlide() اضافه شده است**
متد INotesSlideManager.RemoveNotesSlide() برای حذف اسلاید یادداشت‌های یک اسلاید اضافه شده است.

#### **متد Remove به IComment اضافه شده است**
متد IComment.Remove برای حذف نظر از مجموعه اضافه شده است.

#### **متد Remove به ICommentAuthor اضافه شده است**
متد ICommentAuthor.Remove برای حذف نویسنده نظرات از مجموعه اضافه شده است.

#### **متدهای ClearCustomProperties و ClearBuiltInProperties به IDocumentProperties اضافه شده‌اند**
متد IDocumentProperties.ClearCustomProperties برای حذف همه ویژگی‌های سفارشی سند اضافه شده است.
متد IDocumentProperties.ClearBuiltInProperties برای حذف و تنظیم مقادیر پیش‌فرض همه ویژگی‌های داخلی سند (Company، Subject، Author و غیره) اضافه شده است.

#### **متدهای RemoveAt، Remove و Clear به ICommentAuthorCollection اضافه شده‌اند**
متد ICommentAuthorCollection.RemoveAt برای حذف نویسنده بر اساس ایندکس مشخص شده اضافه شده است.
متد ICommentAuthorCollection.Remove برای حذف نویسنده مشخص از مجموعه اضافه شده است.
متد ICommentAuthorCollection.Clear برای حذف تمام آیتم‌ها از مجموعه اضافه شده است.

#### **ویژگی AppVersion به IDocumentProperties اضافه شده است**
ویژگی IDocumentProperties.AppVersion برای دریافت ویژگی داخلی سند که نشانگر شماره‌های نسخه داخلی مورد استفاده مایکروسافت در طول توسعه است، اضافه شده است.

#### **ویژگی BlackWhiteMode به IShape و Shape اضافه شده است**
ویژگی BlackWhiteMode به IShape و Shape اضافه شده است.

این ویژگی مشخص می‌کند که یک شکل در حالت نمایش سیاه‑سفید چگونه رندر شود.

|**مقدار** |**معنی** |
| :- | :- |
|Color |رندر با رنگ‌بندی عادی |
|Automatic |رندر با رنگ‌بندی خودکار |
|Gray |رندر با رنگ خاکستری |
|LightGray |رندر با رنگ خاکستری روشن |
|InverseGray |رندر با رنگ خاکستری معکوس |
|GrayWhite |رندر با رنگ خاکستری و سفید |
|BlackGray |رندر با رنگ سیاه و خاکستری |
|BlackWhite |رندر با رنگ سیاه و سفید |
|Black |رندر فقط با رنگ سیاه |
|White |رندر با رنگ سفید |
|Hidden |عدم رندر |
|NotDefined|به معنای این است که ویژگی تنظیم نشده است|

#### **ویژگی ISlide.NotesSlideManager اضافه شده است. ویژگی ISlide.NotesSlide و متد ISlide.AddNotesSlide() به عنوان منسوخ علامت‌گذاری شده‌اند.**
اعضای ISlide.NotesSlide و ISlide.AddNotesSlide() به عنوان منسوخ علامت‌گذاری شده‌اند. به جای آنها از ویژگی جدید ISlide.NotesSlideManager استفاده کنید.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - منسوخ
    // notes = slide.NotesSlide; - منسوخ

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```