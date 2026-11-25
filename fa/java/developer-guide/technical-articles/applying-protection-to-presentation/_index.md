---
title: محدود کردن ویرایش‌های ارائه با قفل‌گذاری اشکال در جاوا
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- محافظت در برابر ویرایش
- قفل کردن شکل
- قفل کردن موقعیت
- قفل کردن انتخاب
- قفل کردن تغییر اندازه
- قفل کردن گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در ارائه‌های PPTX با Aspose.Slides برای جاوا قفل و بازقفل کنید تا انتخاب، حرکت، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **پس‌زمینه**

یک کاربرد متداول Aspose.Slides for Java ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک گردش کار خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات در اشکال می‌تواند به حفظ چیدمان و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چگونه قفل‌های اشکال را در یک ارائه PPTX اعمال و حذف کنید. این قفل‌ها به شما امکان می‌دهند عملیات ویرایشی خاصی را بر روی اشکال منفرد محدود کنید.

## **ساختار اسلاید**

یک اسلاید ارائه از اجزایی مانند اتوشکل‌ها، جدول‌ها، اشیاء OLE، اشکال گروهی، فریم‌های تصویر، فریم‌های ویدیو، پیوست‌کننده‌ها و سایر عناصر استفاده‌شده برای ساختن ارائه تشکیل می‌شود. در Aspose.Slides for Java، هر عنصر روی اسلاید توسط شیئی که پیاده‌سازی‌کنندهٔ [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) است یا از کلاسی که اینترفیس را ارث می‌برد، نمایندگی می‌شود.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی ارائه می‌دهند. اینترفیس [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) پایهٔ اینترفیس‌های قفل‌گذاری اشکال است. Aspose.Slides for Java رابط‌های قفل زیر را فراهم می‌کند:

- [قفل‌‏های AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) اتوشکل‌ها را قفل می‌کند.  
- [قفل‌‏های Connector](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) اشکال پیوست‌کننده را قفل می‌کند.  
- [قفل‌‏های GraphicalObject](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) اشیاء گرافیکی را قفل می‌کند.  
- [قفل‌‏های GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) اشکال گروهی را قفل می‌کند.  
- [قفل‌‏های PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) فریم‌های تصویر را قفل می‌کند.  

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

ویرایشگرهای ارائهٔ سازگار از قفل‌های اشکال برای محدود کردن عملیات ویرایشی منفرد استفاده می‌کنند. رمزنگاری فایل و حفاظت نوشتن در سطح سند تنظیمات جداگانه‌ای از [presentation protection settings](/slides/fa/java/password-protected-presentation/) هستند.

### **اعمال حفاظت بر روی اشکال PPTX**

Aspose.Slides for Java اینترفیس [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) را برای کار با اشکال روی یک اسلاید فراهم می‌کند.

مثال زیر متدهای [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)، [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) و [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) را برای اتوشکل‌ها با مقدار `true` فراخوانی می‌کند، و قفل‌های معادل برای اشکال گروهی، پیوست‌کننده‌ها و فریم‌های تصویر اعمال می‌شود. پیوست‌کننده‌ها از [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) برای حرکت استفاده می‌کنند؛ گروه‌ها نیز از [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) برای محدود کردن گروه‌بندی بهره می‌برند.

مثال یک ارائهٔ PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعهٔ اشکال هر اسلاید را بررسی می‌کند و نسخه‌ای با این محدودیت‌ها ذخیره می‌سازد. اشکالی که در چهار نوع پشتیبانی‌شده نیستند، بدون تغییر باقی می‌مانند. حلقه اشکال فرزند داخل یک گروه را پیمایش نمی‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **حذف حفاظت**

برای حذف قفل یک شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائهٔ دارای قفل‌های شکل را بارگذاری می‌کند و محدودیت‌های انتخاب، حرکت و تغییر اندازه را از طریق [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) و [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) پاک می‌سازد. همچنین محدودیت گروه‌بندی را با عبور `false` به [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) حذف می‌کند و یک نسخهٔ دیگر از ارائه را ذخیره می‌نماید. سایر تنظیمات قفل دست‌نخورده می‌مانند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **حفظ برش تصویر**

یک عکس به نام `photo.jpg` را در پوشهٔ کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست تصویر را برش می‌دهد، سپس متد [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) را بر روی قفل فریم تصویر فراخوانی می‌کند. مقدار `true` برش‌های بعدی را محدود کرده و برش فعلی را حفظ می‌کند.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` قفل برش را به عنوان `true` ذخیره می‌کند. در PowerPoint، فرمان **Crop** هنگام انتخاب تصویر غیرفعال می‌شود.

### **نگهداری گروه‌بندی یک دیاگرام**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند، سپس متد [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) را بر روی قفل گروه فراخوانی می‌کند تا اجزای دیاگرام با هم باقی بمانند. سایر ویرایش‌ها مانند جابجایی گروه یا تغییر پر کردن یک جزء همچنان در دسترس هستند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` قفل جداسازی را به عنوان `true` ذخیره می‌کند. در PowerPoint، فرمان **Ungroup** هنگام انتخاب تمام دیاگرام غیرفعال می‌شود.

### **گزارش قفل‌های موجود بر روی اشکال**

برای بررسی یک قالب، آن را باز کنید و شیء قفل هر شکل را بخوانید. متد [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) هنگامیکه همهٔ پرچم‌ها روی آن شیء غیرفعال باشند `true` و در غیر اینصورت `false` بر می‌گرداند. یک گروه و فرزندان آن دارای اشیای قفل جداگانه هستند، بنابراین حتی اگر گروه قفل نداشته باشد، فرزندان را نیز بررسی کنید.

این مثال حرکت را برای اتوشکل‌ها، فریم‌های تصویر و گروه‌ها بررسی می‌کند. همچنین برش تصاویر و جداسازی گروه‌ها را بررسی می‌کند. گزارش پرچم‌های فعال شناخته‌شده را فهرست می‌کند و انواع اشکالی که بررسی نمی‌شوند را علامت‌گذاری می‌کند.

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

به عنوان نمونه، اسلاید 1 از `Sample.pptx` شامل یک گروه به نام `Layout` است که جداسازی آن قفل شده، یک تصویر به نام `Photo` داخل آن که برش قفل شده، و یک مستطیل بدون قفل به نام `Free`. گزارش `Free` را رد می‌کند و دو خط زیر را چاپ می‌کند:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

گزارش پرچم‌های ویرایشی ذخیره‌شدهٔ سطح شکل را می‌خواند بدون این که آنها را تغییر دهد یا ارائه را ذخیره کند. حفاظت نوشتن در سطح سند تنظیم جداگانه‌ای است و اجرای هر پرچم به ویرایشگر بستگی دارد.

### **نتیجه‌گیری**

Aspose.Slides for Java به شما امکان می‌دهد عملیات ویرایشی خاصی را بر روی اشکال منفرد محدود کنید یا همان محدودیت‌ها را در سراسر اسلایدها اعمال نمایید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و در صورت نیاز به حذف این محدودیت‌ها مقدار آنها را به `false` تنظیم کنید.

## **پرسش‌های متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/java/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را تنها بر روی اسلایدهای خاص محدود کنم بدون آنکه اسلایدهای دیگر تحت تأثیر قرار گیرند؟**

بله. قفل‌ها را فقط بر روی اشکال موجود در اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال منفرد داخل یک گروه اعمال کنم؟**

مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) گروه بازگردانده می‌شود را پیمایش کنید و قفل‌های مناسب را به هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو نیز تکرار کنید، همان‌طور که در مثال گزارش‌گیری نشان داده شده است.