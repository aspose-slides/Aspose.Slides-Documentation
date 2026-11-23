---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در .NET
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 70
url: /fa/net/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش‌ها
- محافظت در برابر ویرایش
- قفل‌گذاری اشکال
- قفل‌گذاری موقعیت
- قفل‌گذاری انتخاب
- قفل‌گذاری تغییر اندازه
- قفل‌گذاری گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای .NET اشکال را در ارائه‌های PPTX قفل و بازقفل کنید تا انتخاب، جابجایی، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **Background**

یک استفاده رایج از Aspose.Slides برای .NET ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به‌عنوان بخشی از یک جریان کاری خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات در اشکال می‌تواند به حفظ چیدمان و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چگونه می‌توان قفل‌های اشکال را در یک ارائه PPTX اعمال و حذف کرد. این قفل‌ها به شما امکان می‌دهند عملیات ویرایشی خاصی را روی اشکال جداگانه محدود کنید.

## **Composition of a Slide**

یک اسلاید ارائه شامل اجزائی مانند Autoshapes، جداول، اشیای OLE، اشکال گروهی، فریم‌های تصویر، فریم‌های ویدئو، Connectorها و سایر عناصر مورد استفاده برای ساخت یک ارائه است. در Aspose.Slides برای .NET، هر عنصر در یک اسلاید توسط یک شیء که رابط [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاسی که این رابط را ارث می‌برد، نمایش داده می‌شود.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی ارائه می‌دهند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) رابط پایه برای قفل‌های اشکال است. Aspose.Slides برای .NET رابط‌های قفل زیر را فراهم می‌کند:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) اشکال Autoshape را قفل می‌کند.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) اشکال Connector را قفل می‌کند.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) اشیای گرافیکی را قفل می‌کند.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) اشکال گروهی را قفل می‌کند.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) فریم‌های تصویر را قفل می‌کند.  

برای اعمال قفل‌ها به یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **Apply and Remove Protection**

ویرایشگرهای سازگار با ارائه از قفل‌های شکل برای محدود کردن عملیات ویرایشی فردی استفاده می‌کنند. رمزنگاری فایل و محافظت نوشتاری سطح سند تنظیمات جداگانه‌ای از [presentation protection settings](/slides/fa/net/password-protected-presentation/) هستند.

### **Apply Protection to PPTX Shapes**

Aspose.Slides برای .NET رابط [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) را برای کار با اشکال در یک اسلاید ارائه می‌دهد.

این مثال [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)، [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) و [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) را برای Autoshapeها به مقدار `true` تنظیم می‌کند و قفل‌های معادل برای اشکال گروهی، Connectorها و فریم‌های تصویر اعمال می‌شود. Connectorها از [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) برای حرکت استفاده می‌کنند؛ گروه‌ها نیز از [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) برای محدود کردن گروه‌بندی بهره می‌برند.

این مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعه اشکال هر اسلاید را بررسی می‌کند و یک نسخه کپی با این محدودیت‌ها ذخیره می‌کند. اشکال خارج از چهار نوع پردازش‌شده بدون تغییر می‌مانند. حلقه داخلی اشکال فرزند داخل یک گروه را پیمایش نمی‌کند.

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

### **Remove Protection**

برای حذف قفل یک شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل بارگذاری می‌کند و محدودیت‌های انتخاب، حرکت و تغییر اندازه را از طریق [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) و [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) پاک می‌کند. همچنین [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) را پاک کرده و یک نسخه کپی از ارائه ذخیره می‌کند. سایر تنظیمات قفل بدون تغییر باقی می‌مانند.

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

### **Preserve a Picture Crop**

یک عکس به نام `photo.jpg` را در پوشه کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست را برش می‌دهد، سپس [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) را بر روی فریم تصویر تنظیم می‌کند. این پرچم برش‌های بعدی را محدود کرده و برش فعلی را حفظ می‌کند.

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

`PictureLocked.pptx` مقدار قفل برش را به `true` ذخیره می‌کند. در PowerPoint، فرمان **Crop** وقتی عکس انتخاب می‌شود غیرفعال است.

### **Keep a Diagram Grouped**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند، سپس [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) را بر روی خود گروه تنظیم می‌کند تا اجزای نمودار به‌هم پیوسته بمانند. سایر ویرایش‌ها، مانند جابه‌جایی گروه یا تغییر پر رنگی یک مؤلفه، در دسترس می‌مانند.

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

`DiagramLocked.pptx` مقدار قفل جداسازی را به `true` ذخیره می‌کند. در PowerPoint، فرمان **Ungroup** وقتی کل نمودار انتخاب می‌شود غیرفعال می‌شود.

### **Conclusion**

Aspose.Slides برای .NET به شما امکان می‌دهد عملیات ویرایشی خاصی را روی اشکال جداگانه محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای مختلف اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و مقادیر آن‌ها را به `false` تنظیم کنید زمانی که نیاز به حذف این محدودیت‌ها دارید.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

بله. قفل‌های شکل عملیات ویرایشی مشخصی را محدود می‌کنند، در حالی که [password protection](/slides/fa/net/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**Can I restrict editing on specific slides without affecting others?**

بله. قفل‌ها را تنها بر روی اشکال اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**How can I apply locks to individual shapes inside a group?**

مجموعه [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) گروه را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل فرزند اعمال کنید. این کار را برای هر گروه تودرتو تکرار کنید. مثال‌های بالا تنها مجموعه اشکال اسلاید را پردازش می‌کنند، بنابراین قفل‌ها را بر روی اعضای فردی گروه تنظیم نمی‌کنند.