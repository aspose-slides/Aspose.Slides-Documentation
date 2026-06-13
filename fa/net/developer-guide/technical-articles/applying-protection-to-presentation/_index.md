---
title: جلوگیری از ویرایش ارائه با قفل‌های شکل در .NET
linktitle: جلوگیری از ویرایش ارائه
type: docs
weight: 70
url: /fa/net/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- محافظت از ویرایش
- قفل کردن شکل
- قفل موقعیت
- قفل انتخاب
- قفل اندازه
- قفل گروه‌بندی
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چگونه Aspose.Slides برای .NET شکل‌ها را در فایل‌های PPT، PPTX و ODP قفل یا باز می‌کند و ارائه‌ها را ایمن می‌سازد در حالی که ویرایش‌های کنترل‌شده را امکان‌پذیر می‌کند."
---
## **پیش‌زمینه**

یک استفاده رایج از Aspose.Slides ایجاد، به‌روزرسانی و ذخیرهٔ ارائه‌های Microsoft PowerPoint (PPTX) به‌عنوان بخشی از یک جریان کاری خودکار است. کاربران برنامه‌هایی که Aspose.Slides را به این‌صورت به کار می‌برند به ارائه‌های تولید شده دسترسی دارند، بنابراین محافظت آن‌ها در برابر ویرایش یک نگرانی رایج است. مهم است که ارائه‌های به‌طور خودکار تولید شده، قالب‌بندی و محتوای اصلی خود را حفظ کنند.

این مقاله توضیح می‌دهد که ارائه‌ها و اسلایدها چگونه ساختاریافته‌اند و Aspose.Slides for .NET چگونه می‌تواند حفاظت را بر یک ارائه اعمال کرده و سپس آن را حذف کند. این راهنما به توسعه‌دهندگان امکان کنترل نحوهٔ استفاده از ارائه‌هایی که برنامه‌هایشان تولید می‌کنند را می‌دهد.

## **ساختار یک اسلاید**

یک اسلاید ارائه از اجزایی مانند خودشکل‌ها (autoshapes)، جدول‌ها، اشیای OLE، اشکال گروهی، فریم‌های تصویر، فریم‌های ویدئو، کانکتورها و سایر عناصر مورد استفاده برای ساخت یک ارائه تشکیل شده است. در Aspose.Slides for .NET، هر عنصر روی اسلاید توسط یک شیء که رابط [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاسی که آن را ارث‌بری می‌کند، نشان داده می‌شود.

ساختار PPTX پیچیده است، بنابراین بر خلاف PPT که می‌توان از یک قفل عمومی برای همه انواع شکل‌ها استفاده کرد، انواع مختلف شکل‌ها به قفل‌های متفاوتی نیاز دارند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseshapelock/) کلاس قفل‌گذاری عمومی برای PPTX است. انواع قفل‌های زیر در Aspose.Slides for .NET برای PPTX پشتیبانی می‌شوند:

- [IAutoShapeLock](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshapelock/) قفل‌های خودشکل‌ها را اعمال می‌کند.  
- [IConnectorLock](https://reference.aspose.com/slides/fa/net/aspose.slides/iconnectorlock/) قفل‌های اشکال کانکتور را اعمال می‌کند.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/fa/net/aspose.slides/igraphicalobjectlock/) قفل‌های اشیای گرافیکی را اعمال می‌کند.  
- [IGroupShapeLock](https://reference.aspose.com/slides/fa/net/aspose.slides/igroupshapelock/) قفل‌های اشکال گروهی را اعمال می‌کند.  
- [IPictureFrameLock](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframelock/) قفل‌های فریم‌های تصویر را اعمال می‌کند.  

هر عملی که بر تمام اشیای شکل در یک شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) انجام شود، بر کل ارائه اعمال می‌گردد.

## **اعمال و حذف حفاظت**

اعمال حفاظت اطمینان می‌دهد که یک ارائه نمی‌تواند ویرایش شود. این تکنیکی مفید برای حفظ محتوای ارائه است.

### **اعمال حفاظت به اشکال PPTX**

Aspose.Slides for .NET رابط [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) را برای کار با اشکال روی اسلاید فراهم می‌کند.

همان‌طور که پیشتر ذکر شد، هر کلاس شکل یک کلاس قفل‑شکل مرتبط برای حفاظت دارد. این مقاله بر قفل‌های NoSelect، NoMove و NoResize تمرکز دارد. این قفل‌ها تضمین می‌کنند که اشکال نمی‌توانند انتخاب (از طریق کلیک ماوس یا روش‌های دیگر) شوند و همچنین نمی‌توانند جابه‌جا یا تغییر اندازه یابند.

نمونه کدی که در ادامه می‌آید، حفاظت را بر همهٔ انواع اشکال در یک ارائه اعمال می‌کند.

```cs
// ایجاد نمونه‌ای از کلاس Presentation که فایل PPTX را نشان می‌دهد.
using Presentation presentation = new Presentation("Sample.pptx");

// گردش در تمام اسلایدهای ارائه.
foreach (ISlide slide in presentation.Slides)
{
    // گردش در تمام اشکال موجود در اسلاید.
    foreach (IShape shape in slide.Shapes)
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

// ذخیره‌سازی فایل ارائه.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **حذف حفاظت**

برای باز کردن قفل یک شکل، مقدار قفل اعمال‌شده را به `false` تنظیم کنید. نمونه کد زیر نشان می‌دهد چگونه اشکال در یک ارائهٔ قفل‌شده را باز کنید.

```cs
// ایجاد نمونه‌ای از کلاس Presentation که نمایانگر یک فایل PPTX است.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// گردش در تمام اسلایدهای ارائه.
foreach (ISlide slide in presentation.Slides)
{
    // گردش در تمام اشکال موجود در اسلاید.
    foreach (IShape shape in slide.Shapes)
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

// ذخیره‌سازی فایل ارائه.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **نتیجه‌گیری**

Aspose.Slides گزینه‌های متعددی برای حفاظت از اشکال در یک ارائه ارائه می‌دهد. می‌توانید یک شکل را به‌صورت جداگانه قفل کنید یا بر روی تمام اشکال یک ارائه تکرار کنید و هر کدام را قفل نمایید تا به‌صورت مؤثری کل فایل را امن کنید. می‌توانید حفاظت را با تنظیم مقدار قفل به `false` حذف کنید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌ها ویرایش اشیاء داخل فایل را محدود می‌کنند، در حالی که [password protection](/slides/fa/net/password-protected-presentation/) دسترسی به باز کردن و/یا ذخیرهٔ تغییرات را کنترل می‌کند. این سازوکارها یکدیگر را تکمیل می‌کنند و به‌صورت مشترک عمل می‌نمایند.

**آیا می‌توانم ویرایش را در اسلایدهای خاص محدود کنم بدون اینکه بر دیگر اسلایدها تأثیر بگذارد؟**

بله. قفل‌ها را بر اشکال اسلایدهای انتخاب‌شده اعمال کنید؛ اسلایدهای باقی‌مانده قابل ویرایش خواهند بود.

**آیا قفل‌های شکل برای اشیای گروهی و کانکتورها اعمال می‌شوند؟**

بله. انواع قفل اختصاصی برای گروه‌ها، کانکتورها، اشیای گرافیکی و سایر انواع شکل‌ها پشتیبانی می‌شوند.