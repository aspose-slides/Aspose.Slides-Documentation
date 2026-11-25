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
- قفل کردن مکان
- قفل کردن انتخاب
- قفل کردن تغییر اندازه
- قفل کردن گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای Node.js از طریق Java، اشکال را در ارائه‌های PPTX قفل و بازقفل کنید تا انتخاب، حرکت، تغییر اندازه و گروه‌بندی محدود شوند."
---
## **نمای کلی**

یک استفاده رایج از Aspose.Slides برای Node.js از طریق Java، ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کار خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات اشکال می‌تواند به حفظ چینش و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چگونه می‌توان قفل‌های اشکال را در یک ارائه PPTX اعمال و حذف کرد. این قفل‌ها به شما اجازه می‌دهند عملیات ویرایشی خاصی را بر روی اشکال منفرد محدود کنید.

## **ترکیب یک اسلاید**

یک اسلاید ارائه از اجزایی مانند اتوشکل‌ها، جدول‌ها، اشیاء OLE، اشکال گروهی، فریم‌های تصویر، فریم‌های ویدئویی، اتصالات و دیگر عناصر استفاده‌شده برای ساخت ارائه تشکیل می‌شود. در Aspose.Slides برای Node.js از طریق Java، هر عنصر در یک اسلاید توسط شی‌ای نمایان می‌شود که از کلاس [کلاس Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) ارث‌بری می‌کند.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی ارائه می‌دهند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) پایه‌ای برای قفل‌های اشکال است. Aspose.Slides برای Node.js از طریق Java کلاس‌های قفل زیر را فراهم می‌کند:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) قفل‌های اتوشکل‌ها را اعمال می‌کند.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) قفل‌های اتصالات را اعمال می‌کند.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) قفل‌های اشیاء گرافیکی را اعمال می‌کند.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) قفل‌های اشکال گروهی را اعمال می‌کند.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) قفل‌های فریم‌های تصویر را اعمال می‌کند.  

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)، اسلایدهای آن را مرور کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

ویرایشگرهای سازگار با ارائه از قفل‌های شکل برای محدود کردن عملیات ویرایشی تک‌تک استفاده می‌کنند. رمزنگاری فایل و حفاظت نوشتن در سطح سند تنظیمات جداگانه‌ای تحت عنوان [تنظیمات حفاظت ارائه](/slides/fa/nodejs-java/password-protected-presentation/) دارند.

### **اعمال حفاظت به اشکال PPTX**

Aspose.Slides برای Node.js از طریق Java کلاس [کلاس Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) را برای کار با اشکال در یک اسلاید فراهم می‌کند.

مثال، متدهای [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) و [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) را با مقدار `true` برای اتوشکل‌ها فراخوانی می‌کند و قفل‌های معادل برای اشکال گروهی، اتصالات و فریم‌های تصویر اعمال می‌شود. برای جابجایی، اتصالات از [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) استفاده می‌کنند؛ گروه‌ها نیز از [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) برای محدود کردن گروه‌بندی استفاده می‌کنند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعه اشکال هر اسلاید را بررسی می‌کند و کپی‌ای با این محدودیت‌ها ذخیره می‌‫‏‏​‏​‏​‬‏‏​‏‏‏‏‏​‏سازد. اشکالی که در چهار نوع پشتیبانی‌شده نیستند دست نخورده می‌مانند. حلقه به اشکال فرزند داخل یک گروه پیمایش نمی‌کند.

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

برای حذف قفل یک شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل بارگذاری می‌کند و قفل‌های انتخاب، جابجایی و تغییر اندازه را از طریق [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) و [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) پاک می‌کند. همچنین با ارسال `false` به متد [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) محدودیت گروه‌بندی را حذف می‌کند و کپی‌ای از ارائه ذخیره می‌شود. سایر تنظیمات قفل دست نخورده می‌مانند.

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

یک عکس به نام `photo.jpg` را در پوشه کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست را برش می‌دهد، سپس متد [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) را بر روی قفل فریم تصویر فراخوانی می‌کند. ارسال `true` برش‌های بعدی را محدود کرده و برش فعلی را حفظ می‌کند.

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

`PictureLocked.pptx` قفل برش را به صورت `true` ذخیره می‌کند. در PowerPoint، فرمان **Crop** زمانی که تصویر انتخاب شده باشد غیرفعال می‌شود.

### **نگه داشتن یک نمودار به صورت گروهی**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند و سپس متد [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) را بر قفل گروه اعمال می‌کند تا اجزای نمودار با هم باقی بمانند. ویرایش‌های دیگر مانند جابجایی گروه یا تغییر رنگ پر کردن یک مؤلفه همچنان در دسترس هستند.

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

`DiagramLocked.pptx` قفل جداسازی را به صورت `true` ذخیره می‌کند. در PowerPoint، فرمان **Ungroup** زمانی که کل نمودار انتخاب شده باشد غیرفعال می‌شود.

### **گزارش قفل‌های موجود اشکال**

برای مرور یک قالب، آن را باز کنید و شی قفل هر شکل را بخوانید. متد [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) زمانی که تمام پرچم‌های آن شی غیرفعال باشند مقدار `true` و وقتی حداقل یکی فعال باشد مقدار `false` برمی‌گرداند. یک گروه و فرزندان آن شی‌های قفل جداگانه‌ای دارند، بنابراین حتی وقتی گروه هیچ قفلی ندارد، باید فرزندان را نیز بررسی کنید.

این مثال حرکت را برای اتوشکل‌ها، فریم‌های تصویر و گروه‌ها بررسی می‌کند. همچنین برش تصویرها و جداسازی گروه‌ها را بررسی می‌نماید. گزارش پرچم‌های فعال شناسایی‌شده را فهرست می‌کند و انواع اشکالی که بررسی نکرده است را علامت‌گذاری می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

فرض کنید اسلاید 1 فایل `Sample.pptx` شامل یک گروه به نام `Layout` باشد که جداسازی آن قفل شده است، یک تصویر به نام `Photo` داخل آن که برش قفل شده دارد و یک مستطیل باز به نام `Free`. گزارش `Free` را نادیده می‌گیرد و دو خط زیر را چاپ می‌کند:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

گزارش پرچم‌های سطح شکل ذخیره‌شده را می‌خواند بدون اینکه آن‌ها را تغییر داده یا ارائه را ذخیره کند. حفاظت نوشتن در سطح سند یک تنظیم جداگانه است و اجرای هر پرچم به ویرایشگر بستگی دارد.

### **نتیجه‌گیری**

Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد عملیات ویرایشی خاصی را بر روی اشکال منفرد محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای مختلف اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و برای حذف این محدودیت‌ها مقدارشان را به `false` تنظیم کنید.

## **پرسش‌های متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/nodejs-java/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را در اسلایدهای خاص محدود کنم بدون اینکه بر سایرین تأثیر بگذارد؟**

بله. قفل‌ها را فقط بر روی اشکال اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل را در اسلایدهای دیگر تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال تک‌تک داخل یک گروه اعمال کنم؟**

از مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) گروه بازگردانده می‌شود، عبور کنید و قفل‌های مناسب را بر هر شکل فرزند اعمال کنید. این کار را برای هر گروه تودرتو تکرار کنید و مسیر پیمایش را مطابق مثال گزارش دنبال کنید.