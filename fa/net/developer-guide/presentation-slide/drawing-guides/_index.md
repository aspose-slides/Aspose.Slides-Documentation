---
title: مدیریت راهنماهای رسم در ارائه‌ها در .NET
linktitle: راهنماهای رسم
type: docs
weight: 85
url: /fa/net/drawing-guides/
keywords:
- راهنمای رسم
- راهنمای افقی
- راهنمای عمودی
- راهنمای هم‌ترازی
- نمای اسلاید
- اسلاید مستر
- اسلاید طرح‌بندی
- مستر یادداشت
- مستر جزوه
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "راهنماهای افقی و عمودی رسم را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET اضافه، دسترسی و حذف کنید."
---
## **نمای کلی**

راهنماهای رسم خطوط افقی و عمودی قابل تنظیمی هستند که به کاربران کمک می‌کنند تا اشکال را به‌صورت یکنواخت هنگام ویرایش ارائه در PowerPoint هم‌راستا کنند. این راهنماها به‌خصوص زمانی که یک برنامه یک ارائه را تولید می‌کند که بعداً به‌صورت دستی اصلاح خواهد شد، مفید هستند: برنامه می‌تواند همان ابزارهای هم‌راستایی را ذخیره کند تا نویسندگان هنگام افزودن یا جابجایی محتوا از آن‌ها پیروی کنند.

راهنماهای رسم ابزارهای ویرایشی هستند، نه محتوای اسلاید. آنها در نمایش اسلاید یا خروجی رندر شده ظاهر نمی‌شوند. Aspose.Slides برای .NET این‌ها را از طریق رابط [IDrawingGuidesCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/idrawingguidescollection/) ارائه می‌دهد. یک راهنما توسط [IDrawingGuide](https://reference.aspose.com/slides/fa/net/aspose.slides/idrawingguide/) نمایش داده می‌شود و دارای جهت، موقعیت و رنگ است.

موقعیت بر حسب پوینت از گوشهٔ بالا‑چپ اسلاید یا مستر مربوطه اندازه‌گیری می‌شود. یک راهنمای عمودی از مختصات افقی استفاده می‌کند، که معمولاً بین صفر و عرض اسلاید قرار دارد. یک راهنمای افقی از مختصات عمودی استفاده می‌کند، که معمولاً بین صفر و ارتفاع اسلاید قرار دارد.

## **افزودن راهنماها به نمای اسلاید**

از [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/fa/net/aspose.slides/icommonslideviewproperties/drawingguides/) برای مدیریت راهنماهای نمایش داده شده هنگام ویرایش اسلایدهای عادی استفاده کنید. با مقدار [Orientation](https://reference.aspose.com/slides/fa/net/aspose.slides/orientation/) و موقعیتی بر حسب پوینت، [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/fa/net/aspose.slides/idrawingguidescollection/add/) را فراخوانی کنید.

مثال زیر یک راهنمای عمودی در سمت راست مرکز اسلاید و یک راهنمای افقی زیر آن اضافه می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **دسترسی به راهنماهای رسم**

خاصیت [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/fa/net/aspose.slides/idrawingguidescollection/count/) و ایندکسر آن دسترسی به راهنماهای موجود را فراهم می‌کنند. خواص [IDrawingGuide.Orientation](https://reference.aspose.com/slides/fa/net/aspose.slides/idrawingguide/orientation/)، [IDrawingGuide.Position](https://reference.aspose.com/slides/fa/net/aspose.slides/idrawingguide/position/)، و [IDrawingGuide.Color](https://reference.aspose.com/slides/fa/net/aspose.slides/idrawingguide/color/) می‌توانند خوانده یا تغییر یابند.

مثال زیر راهنماهای نمای اسلاید را از ارائه‌ای که در قسمت قبل ایجاد شد می‌خواند:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **افزودن راهنماها به اسلایدهای مستر و طرح‌بندی**

یک مستر اسلاید و هر یک از اسلایدهای طرح‌بندی آن می‌توانند مجموعهٔ راهنماهای رسم خود را داشته باشند. برای یک اسلاید مستر از [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/drawingguides/) و برای یک اسلاید طرح‌بندی از [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/drawingguides/) استفاده کنید.

مثال زیر یک راهنمای عمودی به اولین اسلاید مستر و یک راهنمای افقی به اولین اسلاید طرح‌بندی اضافه می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **افزودن راهنماها به مسترهای یادداشت و جزوه**

مسترهای یادداشت و جزوه نیز از راهنماهای رسم پشتیبانی می‌کنند. برای دسترسی به مجموعه‌هایشان از [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/fa/net/aspose.slides/imasternotesslide/drawingguides/) و [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterhandoutslide/drawingguides/) استفاده کنید. اگر ارائه شامل یکی از این مسترها نباشد، [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) یا [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) مستر پیش‌فرض را ایجاد کرده و برمی‌گرداند.

مثال زیر یک راهنمای افقی به یک مستر یادداشت و یک راهنمای عمودی به یک مستر جزوه اضافه می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **پاک‌سازی راهنماهای رسم**

با فراخوانی [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides/idrawingguidescollection/clear/) می‌توانید تمام راهنماها را از یک مجموعه خاص حذف کنید. پاک‌سازی یک مجموعه تاثیر بر راهنماهای ذخیره شده در دامنهٔ دیگری ندارد.

مثال زیر راهنماهای نمای اسلاید و تمام راهنماهای موجود در مسترهای اسلاید، اسلایدهای طرح‌بندی، مستر یادداشت و مستر جزوه را بدون ایجاد مسترهای گمشده پاک می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **پرسش‌های متداول**

**آیا راهنماهای رسم در نمایش اسلاید یا تصاویر صادرشده ظاهر می‌شوند؟**

خیر. راهنماهای رسم ابزارهای هم‌راستایی برای ویرایش هستند و به‌عنوان محتوای ارائه رندر نمی‌شوند.

**آیا می‌توان یک راهنمای رسم را مستقیماً به یک اسلاید عادی اضافه کرد؟**

راهنماهای ویرایشی اسلایدهای عادی در ویژگی‌های نمای اسلاید ارائه ذخیره می‌شوند. مجموعه‌های راهنمای جداگانه‌ای برای مسترهای اسلاید، اسلایدهای طرح‌بندی، مسترهای یادداشت و مسترهای جزوه موجود است.

**واحدهای مورد استفاده برای موقعیت راهنماها چیست؟**

موقعیت‌ها بر حسب پوینت تعیین می‌شوند که ۷۲ پوینت برابر یک اینچ است. موقعیت‌های عمودی از لبهٔ چپ اندازه‌گیری می‌شوند و موقعیت‌های افقی از لبهٔ بالا.

**آیا پاک‌سازی راهنماهای رسم اشکال را حذف می‌کند یا محتوای اسلاید را تغییر می‌دهد؟**

خیر. متد `Clear` تنها راهنماهای موجود در مجموعهٔ انتخاب‌شده را حذف می‌کند. اشکال و سایر محتوای اسلاید بدون تغییر باقی می‌مانند.