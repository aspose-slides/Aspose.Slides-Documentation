---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در .NET
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 70
url: /fa/net/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- حفاظت از ویرایش
- قفل کردن شکل
- قفل کردن موقعیت
- قفل کردن انتخاب
- قفل کردن تغییر اندازه
- قفل کردن گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در ارائه‌های PPTX با Aspose.Slides برای .NET قفل و بازقفل کنید تا انتخاب، جابه‌جایی، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **پس‌زمینه**

یک استفاده رایج از Aspose.Slides برای .NET ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک گردش کار خودکار است. وقتی کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات در اشکال می‌تواند به حفظ طرح‌بندی و محتوای موردنظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازمان‌دهی می‌شوند و چگونه قفل‌های اشکال را در یک ارائه PPTX اعمال و حذف کنید. این قفل‌ها به شما امکان می‌دهند عملیات ویرایش خاصی را بر روی اشکال منفرد محدود کنید.

## **ترکیب یک اسلاید**

یک اسلاید ارائه از اجزایی مانند اشکال خودکار، جداول، اشیای OLE، اشکال گروهی، قاب‌های تصویر، قاب‌های ویدئو، اتصال‌ها و سایر عناصری که برای ساخت یک ارائه استفاده می‌شوند، تشکیل شده است. در Aspose.Slides برای .NET، هر عنصر در یک اسلاید توسط شی‌ای نمایان می‌شود که رابط [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاسی که این رابط را ارث می‌برد، مشتق می‌شود.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی را ارائه می‌دهند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) رابط پایه برای قفل‌های اشکال است. Aspose.Slides برای .NET رابط‌های قفل زیر را فراهم می‌کند:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) قفل‌های اشکال خودکار را اعمال می‌کند.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) قفل‌های اشکال متصل‌کننده را اعمال می‌کند.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) قفل‌های اشیای گرافیکی را اعمال می‌کند.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) قفل‌های اشکال گروهی را اعمال می‌کند.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) قفل‌های قاب‌های تصویر را اعمال می‌کند.  

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

قفل‌های شکل عملیات‌هایی مانند انتخاب، جابه‌جایی و تغییر اندازه اشکال را محدود می‌کنند. آن‌ها تمام ارائه را غیرقابل ویرایش نمی‌کنند.

### **اعمال حفاظت به اشکال PPTX**

Aspose.Slides برای .NET رابط [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) را برای کار با اشکال در اسلاید فراهم می‌کند.

مثال، ویژگی‌های [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)، [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/)، و [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) را برای اشکال خودکار به مقدار `true` تنظیم می‌کند، و قفل‌های معادل برای اشکال گروهی، اتصال‌ها و قاب‌های تصویر نیز اعمال می‌شود. اتصال‌ها از [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) برای جابه‌جایی استفاده می‌کنند؛ گروه‌ها نیز از [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) برای محدود کردن گروه‌بندی استفاده می‌کنند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعه اشکال هر اسلاید را بررسی می‌کند و یک نسخه کپی را با این محدودیت‌ها ذخیره می‌کند. اشکالی که خارج از چهار نوع پردازش‌شده هستند بدون تغییر باقی می‌مانند. حلقه داخل اشکال فرزند یک گروه را پیمایش نمی‌کند.

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

برای حذف قفل یک شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های اشکال را بارگذاری می‌کند و محدودیت‌های انتخاب، جابه‌جایی و تغییر اندازه را از طریق [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/)، و [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) پاک می‌کند. همچنین [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) را پاک می‌کند و یک نسخه کپی از ارائه را ذخیره می‌نماید. سایر تنظیمات قفل بدون تغییر باقی می‌مانند.

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

### **نتیجه‌گیری**

Aspose.Slides برای .NET به شما امکان می‌دهد عملیات‌های ویرایشی خاص را بر روی اشکال منفرد محدود کنید یا همان محدودیت‌ها را بر روی اسلایدها اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و زمان نیاز به حذف این محدودیت‌ها، مقدار آن‌ها را به `false` تنظیم کنید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات‌های ویرایشی خاصی را محدود می‌کنند، در حالی که [password protection](/slides/fa/net/password-protected-presentation/) می‌تواند باز کردن یا اصلاح ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را در اسلایدهای خاص محدود کنم بدون اینکه بر دیگران تأثیر بگذارد؟**

بله. قفل‌ها را تنها بر روی اشکال اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را به اشکال منفرد داخل یک گروه اعمال کنم؟**

در مجموعه [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) گروه پیمایش کنید و قفل‌های مناسب را روی هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های بالا تنها مجموعه اشکال اسلاید را پردازش می‌کنند، بنابراین قفل‌ها را بر روی اعضای منفرد گروه تنظیم نمی‌کنند.