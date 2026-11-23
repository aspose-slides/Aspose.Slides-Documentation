---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در جاوا
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- محافظت در برابر ویرایش
- قفل کردن شکل
- قفل موقعیت
- قفل انتخاب
- قفل تغییر اندازه
- قفل گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- Java
- Aspose.Slides
description: "نحوه قفل و بازقفل کردن اشکال در ارائه‌های PPTX با Aspose.Slides برای جاوا را بیاموزید تا انتخاب، حرکت، تغییر اندازه و گروه‌بندی محدود شوند."
---
## **پیش زمینه**

یک کاربرد رایج Aspose.Slides for Java ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کار خودکار است. وقتی کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات در اشکال می‌تواند به حفظ طرح‌بندی و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چگونه قفل‌های اشکال را در یک ارائه PPTX اعمال و حذف می‌کنید. این قفل‌ها به شما امکان محدود کردن عملیات ویرایشی خاص بر روی اشکال منفرد را می‌دهند.

## **ترکیب اسلاید**

یک اسلاید ارائه شامل اجزایی نظیر autoshapes، جداول، اشیای OLE، اشکال گروهی، فریم‌های تصویر، فریم‌های ویدئو، connectorها و سایر عناصر مورد استفاده برای ساخت یک ارائه است. در Aspose.Slides for Java، هر عنصر بر روی اسلاید توسط شیئی که رابط [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاسی که آن را به ارث می‌برد، نمایان می‌شود.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی را ارائه می‌دهند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) رابط پایه برای قفل‌های اشکال است. Aspose.Slides for Java رابط‌های قفل زیر را فراهم می‌کند:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) اشکال autoshape را قفل می‌کند.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) اشکال connector را قفل می‌کند.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) اشیای گرافیکی را قفل می‌کند.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) اشکال گروهی را قفل می‌کند.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) فریم‌های تصویر را قفل می‌کند.  

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را بر هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

ویرایشگرهای سازگار با ارائه از قفل‌های اشکال برای محدود کردن عملیات ویرایشی منفرد استفاده می‌کنند. رمزنگاری فایل و حفاظت نوشتن در سطح سند تنظیمات جداگانه‌ای برای [تنظیمات حفاظت ارائه](/slides/fa/java/password-protected-presentation/) هستند.

### **اعمال حفاظت به اشکال PPTX**

Aspose.Slides for Java رابط [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) را برای کار با اشکال در یک اسلاید فراهم می‌کند.

مثال متدهای [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)، [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) و [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) را با مقدار `true` برای autoshapes فراخوانی می‌کند، و قفل‌های معادل برای اشکال گروهی، connectorها و فریم‌های تصویر را اعمال می‌کند. connectorها از [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) برای حرکت استفاده می‌کنند؛ گروه‌ها همچنین از [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) برای محدود کردن گروه‌بندی استفاده می‌کنند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعه اشکال هر اسلاید را بررسی می‌کند و یک نسخه با این محدودیت‌ها ذخیره می‌کند. اشکالی که جزو چهار نوع پردازش‌شده هستند بدون تغییر می‌مانند. حلقه شکل‌های فرزند داخل یک گروه را پیمایش نمی‌کند.

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

برای حذف یک قفل اشکال، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه حاوی قفل‌های اشکال را بارگذاری می‌کند و محدودیت‌های انتخاب، حرکت و تغییر اندازه را از طریق [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) و [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) پاک می‌سازد. همچنین محدودیت گروه‌بندی را با ارسال `false` به [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) حذف می‌کند و یک نسخه از ارائه را ذخیره می‌نماید. سایر تنظیمات قفل بدون تغییر می‌مانند.

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

یک عکس به نام `photo.jpg` را در پوشه کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست را برش می‌دهد، سپس متد [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) را بر روی قفل فریم تصویر فراخوانی می‌کند. ارسال `true` برش‌های بعدی را محدود کرده و برش موجود را حفظ می‌کند.

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

`PictureLocked.pptx` قفل برش را به عنوان `true` ذخیره می‌کند. در PowerPoint، دستور **Crop** زمانی که عکس انتخاب شده باشد غیرفعال می‌شود.

### **حفظ گروه‌بندی یک نمودار**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند، سپس متد [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) را بر روی قفل گروه فراخوانی می‌کند تا اجزای نمودار را با هم نگه دارد. ویرایش‌های دیگر، مانند جابه‌جایی گروه یا تغییر رنگ پرکنش یک جزء، همچنان در دسترس هستند.

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

`DiagramLocked.pptx` قفل جداسازی (Ungroup) را به عنوان `true` ذخیره می‌کند. در PowerPoint، دستور **Ungroup** هنگام انتخاب کل نمودار غیرفعال می‌شود.

### **نتیجه‌گیری**

Aspose.Slides for Java به شما اجازه می‌دهد عملیات ویرایشی خاص را بر روی اشکال منفرد محدود کنید یا همان محدودیت‌ها را بر روی اسلایدها اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و مقادیر آنها را به `false` تنظیم کنید وقتی که نیاز به حذف این محدودیت‌ها دارید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در همان ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/java/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. شما می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را بر روی اسلایدهای خاص محدود کنم بدون اینکه بر سایر اسلایدها اثر بگذارد؟**

بله. قفل‌ها را فقط بر روی اشکال اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال منفرد داخل یک گروه اعمال کنم؟**

از طریق مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) گروه برگردانده می‌شود، پیمایش کنید و قفل‌های مناسب را بر هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های بالا فقط مجموعه اشکال اسلاید را پردازش می‌کنند، بنابراین قفل‌ها را بر روی اعضای منفرد گروه تنظیم نمی‌کنند.