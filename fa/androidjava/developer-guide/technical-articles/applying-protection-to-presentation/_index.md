---
title: محدود کردن ویرایش‌های ارائه با قفل‌گذاری بر اشکال در اندروید
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/androidjava/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- محافظت در برابر ویرایش
- قفل‌کردن شکل
- قفل‌کردن موقعیت
- قفل‌کردن انتخاب
- قفل‌کردن تغییر اندازه
- قفل‌کردن گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- Android
- Java
- Aspose.Slides
description: "چگونگی قفل‌کردن و بازقفل‌کردن اشکال در ارائه‌های PPTX با Aspose.Slides برای اندروید از طریق جاوا را بیاموزید تا انتخاب، جابجایی، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **نمای کلی**

یک استفاده رایج از Aspose.Slides for Android via Java ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کاری خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات در اشکال می‌تواند به حفظ طرح‌بندی و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چگونه می‌توان قفل‌های اشکال را در یک ارائه PPTX اعمال و حذف کرد. این قفل‌ها به شما امکان می‌دهند عملیات ویرایشی خاصی را برای هر شکل به‌صورت جداگانه محدود کنید.

## **ساختار یک اسلاید**

یک اسلاید ارائه از اجزائی نظیر اشکال خودکار، جداول، اشیاء OLE، اشکال گروه‌بندی‌شده، فریم‌های تصویر، فریم‌های ویدئو، اتصال‌دهنده‌ها و سایر عنصرهایی که برای ساخت یک ارائه استفاده می‌شوند، تشکیل شده است. در Aspose.Slides for Android via Java، هر عنصر در یک اسلاید توسط شیئی نمایان می‌شود که رابط [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاسی که این رابط را ارث می‌برد، مشتق شده است.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی ارائه می‌دهند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) رابط پایه برای قفل‌های اشکال است. Aspose.Slides for Android via Java رابط‌های قفل زیر را فراهم می‌کند:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) قفل‌گذاری بر روی اشکال خودکار.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) قفل‌گذاری بر روی اشکال اتصال‌دهنده.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) قفل‌گذاری بر روی اشیای گرافیکی.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) قفل‌گذاری بر روی اشکال گروهی.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) قفل‌گذاری بر روی فریم‌های تصویر.  

برای اعمال قفل‌ها در یک [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)، اسلایدهای آن را مرور کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

ویرایشگرهای سازگار ارائه از قفل‌های اشکال برای محدود کردن عملیات ویرایشی فردی استفاده می‌کنند. رمزگذاری فایل و حفاظت نوشتن سطح سند تنظیمات جداگانه‌ای تحت عنوان [presentation protection settings](/slides/fa/androidjava/password-protected-presentation/) دارند.

### **اعمال حفاظت به اشکال PPTX**

Aspose.Slides for Android via Java رابط [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) را برای کار با اشکال در یک اسلاید فراهم می‌کند.

مثال، متدهای [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)، [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) و [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) را با مقدار `true` برای اشکال خودکار صدا می‌کند و قفل‌های معادل برای اشکال گروهی، اتصال‌دهنده‌ها و فریم‌های تصویر اعمال می‌شود. برای اتصال‌دهنده‌ها از [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) برای حرکت استفاده می‌شود؛ گروه‌ها نیز از [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) برای محدود کردن گروه‌بندی استفاده می‌کنند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال هر اسلاید را در مجموعه اشکال بررسی می‌نماید و یک نسخهٔ کپی با این محدودیت‌ها ذخیره می‌کند. اشکالی که جز چهار نوع مدیریت‌شده باشند دست‌نخورده می‌مانند. حلقه داخل اشکال فرزند یک گروه پیمایش نمی‌کند.

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

برای حذف قفل یک شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل بارگذاری می‌کند و محدودیت‌های انتخاب، حرکت و تغییر اندازه را از طریق [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) و [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) پاک می‌نماید. همچنین با ارسال `false` به متد [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) محدودیت گروه‌بندی را حذف می‌کند و یک نسخهٔ کپی از ارائه ذخیره می‌شود. سایر تنظیمات قفل دست‌نخورده می‌مانند.

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

یک عکس به نام `photo.jpg` را در پوشهٔ کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست را برش می‌دهد، سپس متد [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) را روی قفل فریم تصویر صدا می‌کند. ارسال `true` مانع برش‌های بیشتر می‌شود و برش موجود را نگه می‌دارد.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

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

`PictureLocked.pptx` قفل برش را به عنوان `true` ذخیره می‌کند. در PowerPoint، فرمان **Crop** هنگامی که تصویر انتخاب شده باشد غیرفعال می‌شود.

### **نگهداری یک نمودار به‌صورت گروهی**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند و سپس متد [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) را بر روی قفل گروه صدا می‌کند تا اجزای نمودار را به‌هم پیوسته نگه دارد. دیگر ویرایش‌ها مانند جابجایی گروه یا تغییر پر کردن یک جزء همچنان در دسترس است.

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

`DiagramLocked.pptx` قفل جداسازی گروه را به عنوان `true` ذخیره می‌کند. در PowerPoint، فرمان **Ungroup** هنگامی که کل نمودار انتخاب شده باشد غیرفعال می‌شود.

### **گزارش قفل‌های موجود بر روی اشکال**

برای بررسی یک قالب، آن را باز کنید و شیء قفل هر شکل را بخوانید. متد [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) زمانی که تمام پرچم‌های آن شیء غیرفعال باشد `true` و در صورتی که حداقل یک پرچم فعال باشد `false` برمی‌گرداند. یک گروه و فرزندان آن دارای اشیاء قفل جداگانه‌ای هستند، بنابراین حتی اگر گروه قفل نداشته باشد، باید فرزندان را نیز بررسی کنید.

این مثال حرکت اشکال خودکار، فریم‌های تصویر و گروه‌ها را بررسی می‌کند. همچنین برش تصاویر و جداسازی گروه‌ها را چک می‌کند. گزارش پرچم‌های فعال شناسایی‌شده را فهرست می‌کند و انواع اشکالی که بررسی نشده‌اند را علامت‌گذاری می‌کند.

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
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
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
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

فرض کنید اسلاید 1 از `Sample.pptx` شامل یک گروه به نام `Layout` باشد که جداسازی آن قفل شده است، یک تصویر به نام `Photo` داخل آن که برش آن قفل شده و یک مستطیل باز به نام `Free`. گزارش `Free` را رد می‌کند و این دو خط را چاپ می‌کند:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

گزارش پرچم‌های ویرایشی سطح شکل را بدون تغییر آن‌ها یا ذخیرهٔ ارائه می‌خواند. حفاظت نوشتن سطح سند تنظیم جداگانه‌ای است و اجرای هر پرچم به ویرایشگر وابسته است.

### **نتیجه‌گیری**

Aspose.Slides for Android via Java به شما امکان می‌دهد عملیات ویرایشی خاصی را بر روی اشکال فردی محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای مختلف اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و برای حذف آن‌ها مقادیرشان را به `false` تنظیم کنید.

## **پرسش‌های متداول**

**آیا می‌توانم قفل‌های اشکال و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های اشکال عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [password protection](/slides/fa/androidjava/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را فقط بر روی اسلایدهای خاصی محدود کنم بدون اینکه بر اسلایدهای دیگر تأثیر بگذارد؟**

بله. قفل‌ها را فقط بر روی اشکال اسلایدهای انتخابی اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال فردی داخل یک گروه اعمال کنم؟**

از مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) گروه بازگردانده می‌شود، پیمایش کنید و قفل‌های مناسب را بر هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تویی که وجود دارد، تکرار کنید و مسیر پیمایش را همان‌طور که در مثال گزارش‌گیری نشان داده شده دنبال کنید.