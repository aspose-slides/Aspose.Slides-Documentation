---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در .NET
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 70
url: /fa/net/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- حفاظت در مقابل ویرایش
- قفل کردن شکل
- قفل موقعیت
- قفل انتخاب
- قفل تغییر اندازه
- قفل گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه در ارائه‌های PPTX با Aspose.Slides for .NET شکل‌ها را قفل و بازقفل کنید تا انتخاب، حرکت، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **پیش‌زمینه**

یک استفاده رایج از Aspose.Slides for .NET ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کاری خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات شکل‌ها می‌تواند به حفظ چیدمان و محتوای موردنظر کمک کند.

این مقاله توضیح می‌دهد که شکل‌ها چگونه در اسلایدها سازماندهی می‌شوند و چگونه قفل‌های شکل را در یک ارائه PPTX اعمال و حذف کنید. این قفل‌ها به شما امکان می‌دهند عملیات ویرایشی خاصی را بر روی شکل‌های منفرد محدود کنید.

## **ترکیب یک اسلاید**

یک اسلاید ارائه از اجزایی مانند Autoshapes، جداول، اشیاء OLE، شکل‌های گروهی، فریم‌های تصویر، فریم‌های ویدئو، اتصال‌دهنده‌ها و سایر عناصری که برای ساخت یک ارائه استفاده می‌شوند، ترکیب شده است. در Aspose.Slides for .NET، هر عنصر در یک اسلاید توسط شیئی نمایان می‌شود که رابط [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاس مشتق شده‌ای است که این کار را انجام می‌دهد.

انواع مختلف شکل‌ها گزینه‌های قفل متفاوتی ارائه می‌دهند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) رابط پایه برای قفل‌های شکل است. Aspose.Slides for .NET رابط‌های قفل زیر را فراهم می‌کند:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) قفل‌های autoshapes را اعمال می‌کند.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) قفل‌های اتصال‌دهنده‌ها را اعمال می‌کند.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) قفل‌های اشیای گرافیکی را اعمال می‌کند.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) قفل‌های شکل‌های گروهی را اعمال می‌کند.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) قفل‌های فریم‌های تصویر را اعمال می‌کند.  

برای اعمال قفل‌ها بر تمام یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را بر هر شکل پشتیبانی‌شده تنظیم نمایید.

## **اعمال و حذف حفاظت**

ویرایشگرهای سازگار ارائه از قفل‌های شکل برای محدود کردن عملیات ویرایشی منفرد استفاده می‌کنند. رمزگذاری فایل و حفاظت نوشتن در سطح سند تنظیمات جداگانه‌ای در [presentation protection settings](/slides/fa/net/password-protected-presentation/) هستند.

### **اعمل حفاظت بر شکل‌های PPTX**

Aspose.Slides for .NET رابط [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) را برای کار با شکل‌ها روی یک اسلاید فراهم می‌کند.

مثال، [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)، [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) و [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) را برای autoshapes روی `true` تنظیم می‌کند، به‌همین ترتیب قفل‌های معادل برای شکل‌های گروهی، اتصال‌دهنده‌ها و فریم‌های تصویر نیز تنظیم می‌شوند. اتصال‌دهنده‌ها از [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) برای حرکت استفاده می‌کنند؛ گروه‌ها همچنین از [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) برای محدود کردن گروه‌بندی استفاده می‌کنند.

مثال یک ارائه PPTX موجود را بارگیری می‌کند، شکل‌های موجود در مجموعهٔ شکل هر اسلاید را بررسی می‌کند و یک کپی با این محدودیت‌ها ذخیره می‌نماید. شکل‌های خارج از چهار نوع مدیریت‌شده دست‌نخورده می‌مانند. حلقه داخل شکل‌های فرزند یک گروه را پیمایش نمی‌کند.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **حذف حفاظت**

برای حذف قفل یک شکل، مقدار آن را روی `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل بارگیری می‌کند و محدودیت‌های انتخاب، حرکت و تغییر اندازه را از طریق [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) و [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) پاک می‌سازد. همچنین [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) را پاک می‌کند و یک کپی از ارائه را ذخیره می‌نماید. تنظیمات دیگر قفل دست‌نخورده می‌مانند.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **حفظ برش تصویر**

یک عکس به نام `photo.jpg` را در پوشهٔ کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست برش می‌دهد، سپس [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) را بر فریم تصویر تنظیم می‌کند. این پرچم برش‌های بعدی را محدود کرده و برش موجود را حفظ می‌کند.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` قفل برش را به‌عنوان `true` ذخیره می‌کند. در PowerPoint، فرمان **Crop** زمانی که تصویر انتخاب شده باشد غیرفعال می‌شود.

### **نگهداری یک نمودار به صورت گروهی**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند، سپس [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) را بر خود گروه تنظیم می‌کند تا اجزای نمودار را با هم نگه دارد. ویرایش‌های دیگر مانند جابجایی گروه یا تغییر پر رنگی یک مؤلفه همچنان قابل دسترس هستند.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` قفل جداسازی را به‌عنوان `true` ذخیره می‌کند. در PowerPoint، فرمان **Ungroup** زمانی که کل نمودار انتخاب شده باشد غیرفعال می‌شود.

### **گزارش قفل‌های شکل موجود**

برای بررسی یک الگو، آن را باز کنید و شیء قفل هر شکل را بخوانید. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) زمانی که همهٔ پرچم‌ها در آن شیء غیرفعال باشند `true` و زمانی که حداقل یکی فعال باشد `false` است. یک گروه و فرزندانش دارای اشیاء قفل جداگانه‌ای هستند، بنابراین حتی وقتی گروه هیچ قفلی ندارد، فرزندان را نیز بررسی کنید.

این مثال حرکت را برای autoshapes، فریم‌های تصویر و گروه‌ها، برش را برای تصاویر و جداسازی را برای گروه‌ها بررسی می‌کند. پرچم‌هایی که شناسایی می‌کند گزارش می‌دهد و انواع شکل‌هایی که بررسی نمی‌کند را علامت‌گذاری می‌کند.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

فرض کنید اسلاید 1 از `Sample.pptx` شامل یک گروه به نام `Layout` باشد که جداسازی آن قفل شده است، یک تصویر به نام `Photo` داخل آن که برش آن قفل شده و یک مستطیل بدون قفل به نام `Free`. گزارش `Free` را نادیده می‌گیرد و این دو خط را چاپ می‌کند:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

گزارش پرچم‌های ویرایشی سطح شکل ذخیره‌شده را بدون تغییر آن‌ها یا ذخیرهٔ ارائه می‌خواند. حفاظت نوشتن در سطح سند تنظیم جداگانه‌ای است و اعمال هر پرچم به ویرایشگر بستگی دارد.

## **نتیجه‌گیری**

Aspose.Slides for .NET به شما امکان می‌دهد عملیات ویرایشی خاصی را بر روی شکل‌های منفرد محدود کنید یا همان محدودیت‌ها را بر تمام اسلایدها اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و مقدار آن‌ها را روی `false` تنظیم نمایید وقتی نیاز به حذف این محدودیت‌ها دارید.

## **سؤال‌های متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [password protection](/slides/fa/net/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود نماید. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را فقط روی اسلایدهای خاص محدود کنم بدون تأثیر بر دیگر اسلایدها؟**

بله. قفل‌ها را فقط بر روی شکل‌های اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی شکل‌های منفرد داخل یک گروه اعمال کنم؟**

از طریق پیمایش مجموعهٔ [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) گروه و اعمال قفل‌های مناسب بر هر شکل فرزند، این کار را انجام دهید. برای هر گروه تو در تو همین روند را تکرار کنید و از روش پیمایش در مثال گزارش استفاده کنید.