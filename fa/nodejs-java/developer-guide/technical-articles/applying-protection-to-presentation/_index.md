---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در Node.js
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/nodejs-java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- محافظت در برابر ویرایش
- قفل کردن شکل
- قفل کردن موقعیت
- قفل کردن انتخاب
- قفل کردن تغییر اندازه
- قفل کردن گروه‌بندی
- پاورپوینت
- PPTX
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "دریابید که چگونه با Aspose.Slides برای Node.js از طریق Java می‌توان اشکال را در ارائه‌های PPTX قفل و بازقفل کرد تا انتخاب، جابجا شدن، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **نمای کلی**

یک کاربرد رایج Aspose.Slides برای Node.js از طریق Java ایجاد، به‌روزرسانی و ذخیرهٔ ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک گردش کار خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات در اشکال می‌تواند به حفظ طرح‌بندی و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چگونه قفل‌های اشکال را در یک ارائه PPTX اعمال و حذف کنید. این قفل‌ها به شما امکان می‌دهند عملیات‌های ویرایشی خاص را روی اشکال منفرد محدود کنید.

## **ساختار اسلاید**

یک اسلاید ارائه از اجزایی مانند اتوشک‌ها، جدول‌ها، اشیاء OLE، اشکال گروهی، فریم‌های تصویر، فریم‌های ویدیو، کانکتورها و سایر عناصر مورد استفاده برای ساخت یک ارائه تشکیل شده است. در Aspose.Slides برای Node.js از طریق Java، هر عنصر در یک اسلاید با شیئی که از کلاس [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) ارث‌بری می‌کند، نمایش داده می‌شود.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی ارائه می‌دهند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) پایهٔ کلاس‌های قفل‌ اشکال است. Aspose.Slides برای Node.js از طریق Java کلاس‌های قفل زیر را فراهم می‌کند:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) اشکال خودکار را قفل می‌کند.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) اشکال متصل‌کننده را قفل می‌کند.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) اشیاء گرافیکی را قفل می‌کند.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) اشکال گروهی را قفل می‌کند.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) فریم‌های تصویر را قفل می‌کند.  

برای اعمال قفل‌ها در یک [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)، بر روی اسلایدهای آن حلقه بزنید و قفل‌های مناسب را بر هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

قفل‌های شکل عملیات‌هایی مانند انتخاب، جابه‌جایی و تغییر اندازهٔ اشکال را محدود می‌کنند. آن‌ها کل ارائه را غیرقابل ویرایش نمی‌سازند.

### **اعمال حفاظت به اشکال PPTX**

Aspose.Slides برای Node.js از طریق Java کلاس [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) را برای کار با اشکال در یک اسلاید فراهم می‌کند.

در مثال، متدهای [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) و [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) با مقدار `true` برای اتوشک‌ها فراخوانی می‌شوند، و قفل‌های معادل برای اشکال گروهی، کانکتورها و فریم‌های تصویر اعمال می‌شود. کانکتورها از [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) برای حرکت استفاده می‌کنند؛ گروه‌ها همچنین از [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) برای محدود کردن گروه‌بندی استفاده می‌کنند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعهٔ اشکال هر اسلاید را بررسی می‌کند و یک نسخهٔ کپی با این محدودیت‌ها ذخیره می‌نماید. اشکالی که خارج از چهار نوع پشتیبانی‌شده هستند، دست نخورده می‌مانند. حلقه به اشکال فرزند داخل یک گروه نمی‌پردازد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **حذف حفاظت**

برای حذف یک قفل شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه را که قفل‌های شکل دارد بارگذاری می‌کند و محدودیت‌های انتخاب، جابه‌جایی و تغییر اندازه را از طریق [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) و [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) پاک می‌سازد. همچنین محدودیت گروه‌بندی را با ارسال `false` به [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) حذف می‌کند و یک نسخهٔ کپی از ارائه را ذخیره می‌نماید. تنظیمات قفل دیگر دست نخورده می‌مانند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **نتیجه‌گیری**

Aspose.Slides برای Node.js از طریق Java به شما اجازه می‌دهد عملیات‌های ویرایشی خاص را روی اشکال منفرد محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای مختلف اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و زمانی که نیاز به حذف این محدودیت‌ها دارید، مقدارشان را به `false` تنظیم کنید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در همان ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات‌های ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/nodejs-java/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را بر روی اسلایدهای خاص محدود کنم بدون اینکه بر اسلایدهای دیگر تأثیر بگذارد؟**

بله. قفل‌ها را فقط روی اشکال اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل روی اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را به اشکال منفرد داخل یک گروه اعمال کنم؟**

در مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) گروه برگردانده می‌شود، حلقه بزنید و قفل‌های مناسب را بر هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های بالا فقط مجموعهٔ اشکال اسلاید را پردازش می‌کنند، ולכן قفل‌ها را بر اعضای منفرد گروه تنظیم نمی‌کنند.