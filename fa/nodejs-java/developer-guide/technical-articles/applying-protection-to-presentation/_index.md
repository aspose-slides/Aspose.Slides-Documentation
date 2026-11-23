---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در Node.js
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/nodejs-java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- حفاظت در برابر ویرایش
- قفل کردن شکل
- قفل کردن موقعیت
- قفل کردن انتخاب
- قفل کردن تغییر اندازه
- قفل کردن گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "بیاموزید چگونه با Aspose.Slides برای Node.js از طریق Java، اشکال در ارائه‌های PPTX را قفل و بازقفل کنید تا انتخاب، حرکت، تغییر اندازه و گروه‌بندی را محدود نمایید."
---
## **نمای کلی**

یک استفاده رایج از Aspose.Slides برای Node.js از طریق Java، ایجاد، به روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک گردش کار خودکار است. زمانی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات در اشکال می‌تواند به حفظ چیدمان و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چگونه می‌توانید قفل‌های شکل را در یک ارائه PPTX اعمال و حذف کنید. این قفل‌ها به شما اجازه می‌دهند عملیات‌های ویرایشی خاص را بر روی اشکال منفرد محدود کنید.

## **ساختار اسلاید**

یک اسلاید ارائه شامل اجزایی مانند اشکال خودکار، جدول‌ها، اشیای OLE، اشکال گروهی، فریم‌های تصویر، فریم‌های ویدیو، کانکتورها و سایر عناصر مورد استفاده برای ساخت یک ارائه است. در Aspose.Slides برای Node.js از طریق Java، هر عنصر در یک اسلاید توسط شیئی نمایان می‌شود که از کلاس [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) ارث‌بری می‌کند.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی را ارائه می‌دهند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) کلاس پایه برای قفل‌های اشکال است. Aspose.Slides برای Node.js از طریق Java کلاس‌های قفل زیر را فراهم می‌کند:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) قفل می‌کند اشکال خودکار.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) قفل می‌کند اشکال کانکتور.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) قفل می‌کند اشیای گرافیکی.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) قفل می‌کند اشکال گروهی.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) قفل می‌کند فریم‌های تصویر.  

برای اعمال قفل‌ها روی یک [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

ویرایشگرهای ارائه سازگار از قفل‌های شکل برای محدود کردن عملیات‌های ویرایشی منفرد استفاده می‌کنند. رمزنگاری فایل و حفاظت نوشتن در سطح سند تنظیمات جداگانه‌ای در [تنظیمات حفاظت از ارائه](/slides/fa/nodejs-java/password-protected-presentation/) دارند.

### **اعمال حفاظت بر روی اشکال PPTX**

Aspose.Slides برای Node.js از طریق Java کلاس [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) را برای کار با اشکال روی یک اسلاید فراهم می‌کند.

مثال متدهای [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) و [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) را با مقدار `true` برای اشکال خودکار فراخوانی می‌کند، و قفل‌های معادل برای اشکال گروهی، کانکتورها و فریم‌های تصویر اعمال می‌شوند. کانکتورها برای حرکت از [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) استفاده می‌کنند؛ گروه‌ها نیز از [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) برای محدود کردن گروه‌بندی استفاده می‌نمایند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال در مجموعهٔ اشکال هر اسلاید را بررسی می‌کند و نسخه‌ای با این محدودیت‌ها ذخیره می‌نماید. اشکالی که در چهار نوع پشتیبانی‌شده نیستند، بدون تغییر می‌مانند. این حلقه به اشکال فرزند داخل یک گروه پیمایش نمی‌کند.

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

برای حذف قفل یک شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل بارگذاری می‌کند و محدودیت‌های انتخاب، حرکت و تغییر‌اندازه را از طریق [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) و [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) پاک می‌سازد. همچنین با ارسال `false` به متد [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) محدودیت گروه‌بندی را حذف می‌کند و یک نسخه از ارائه را ذخیره می‌نماید. سایر تنظیمات قفل بدون تغییر باقی می‌مانند.

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

### **حفظ برش تصویر**

یک عکس به نام `photo.jpg` را در پوشهٔ کاری قرار دهید. مثال ۱۲٪ از سمت چپ و ۸٪ از سمت راست را برش می‌دهد، سپس متد [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) را بر روی قفل فریم تصویر فراخوانی می‌کند. ارسال `true` برش‌های بعدی را محدود کرده و برش فعلی را حفظ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` قفل برش را به عنوان `true` ذخیره می‌کند. در PowerPoint، فرمان **برش** زمانی که عکس انتخاب شده باشد غیرفعال می‌شود.

### **نگه داشتن نمودار به صورت گروهی**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند، سپس متد [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) را بر روی قفل گروه فراخوانی می‌کند تا اجزای نمودار را به‌هم متصل نگه دارد. سایر ویرایش‌ها، مانند جابجایی گروه یا تغییر پرکننده یک جزء، همچنان در دسترس هستند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` قفل لغو گروه‌بندی را به عنوان `true` ذخیره می‌کند. در PowerPoint، فرمان **لغو گروه‌بندی** زمانی که کل نمودار انتخاب شود غیرفعال می‌شود.

### **نتیجه‌گیری**

Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد عملیات‌های ویرایشی خاص را بر روی هر شکل به‌صورت منفرد محدود کنید یا همان محدودیت‌ها را در سراسر اسلایدها اعمال نمایید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و هنگام نیاز به حذف این محدودیت‌ها مقدار آن‌ها را به `false` تنظیم کنید.

## **سؤالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**  
بله. قفل‌های شکل عملیات‌های ویرایشی خاص را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/nodejs-java/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را در اسلایدهای خاص بدون اثر بر سایر اسلایدها محدود کنم؟**  
بله. قفل‌ها را تنها بر روی اشکال اسلایدهای انتخابی اعمال کنید. این کار تنظیمات قفل در سایر اسلایدها را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال منفرد داخل یک گروه اعمال کنم؟**  
از مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) گروه برگردانده می‌شود عبور کنید و قفل‌های مناسب را بر هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار نمایید. مثال‌های فوق فقط بر روی مجموعهٔ اشکال اسلاید عمل می‌کنند، بنابراین قفل‌ها را بر روی اعضای منفرد گروه تنظیم نمی‌کنند.