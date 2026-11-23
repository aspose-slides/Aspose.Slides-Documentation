---
title: محدود کردن ویرایش ارائه با قفل‌های شکل در Android
linktitle: محدود کردن ویرایش ارائه
type: docs
weight: 60
url: /fa/androidjava/applying-protection-to-presentation/
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
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه شکل‌ها را در ارائه‌های PPTX با Aspose.Slides برای Android از طریق Java قفل و بازقفل کنید تا انتخاب، حرکت، تغییر اندازه و گروه‌بندی محدود شوند."
---
## **بررسی کلی**

یک استفاده رایج از Aspose.Slides برای Android از طریق Java ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کاری خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات شکل‌ها می‌تواند به حفظ چیدمان و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چگونه می‌توان قفل‌های شکل را در یک ارائه PPTX اعمال و حذف کرد. این قفل‌ها به شما امکان می‌دهند عملیات ویرایش خاصی را بر روی اشکال منفرد محدود کنید.

## **ساختار اسلاید**

یک اسلاید ارائه از اجزایی مانند شکل‌های خودکار، جداول، اشیای OLE، اشکال گروهی، قاب‌های تصویر، قاب‌های ویدئویی، اتصال‌ها و سایر عناصر مورد استفاده برای ساخت یک ارائه ترکیب شده است. در Aspose.Slides برای Android از طریق Java، هر عنصر در یک اسلاید توسط شیئی نمایان می‌شود که رابط [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاسی که این کار را انجام می‌دهد ارث می‌برد.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی ارائه می‌دهند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) رابط پایه برای قفل‌های شکل است. Aspose.Slides برای Android از طریق Java رابط‌های قفل زیر را فراهم می‌کند:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) قفل‌های شکل‌های خودکار را اعمال می‌کند.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) قفل‌های شکل‌های اتصال را اعمال می‌کند.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) قفل‌های اشیای گرافیکی را اعمال می‌کند.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) قفل‌های گروه‌های شکل را اعمال می‌کند.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) قفل‌های قاب‌های تصویر را اعمال می‌کند.  

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)، اسلایدهای آن را مرور کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی شده تنظیم کنید.

## **اعمال و حذف حفاظت**

ویرایشگرهای ارائه سازگار از قفل‌های شکل برای محدود کردن عملیات ویرایش منفرد استفاده می‌کنند. رمزگذاری فایل و حفاظت نوشتن در سطح سند تنظیمات جداگانه‌ای برای [تنظیمات حفاظت ارائه](/slides/fa/androidjava/password-protected-presentation/) هستند.

### **اعمال حفاظت بر اشکال PPTX**

Aspose.Slides برای Android از طریق Java رابط [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) را برای کار با اشکال در یک اسلاید فراهم می‌کند.

مثال زیر متدهای [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)، [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-)، و [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) را با مقدار `true` برای شکل‌های خودکار فراخوانی می‌کند؛ برای شکل‌های گروهی، اتصال‌ها و قاب‌های تصویر‌ نیز قفل‌های معادل اعمال می‌شود. اتصال‌ها برای حرکت از [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) استفاده می‌کنند؛ گروه‌ها همچنین از [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) برای محدود کردن گروه‌بندی استفاده می‌کنند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعه اشکال هر اسلاید را بررسی می‌کند و یک نسخهٔ کپی با این محدودیت‌ها ذخیره می‌کند. اشکال خارج از چهار نوع پردازش‌شده بدون تغییر باقی می‌مانند. حلقه به شکل‌های فرزند داخل یک گروه پیمایش نمی‌کند.

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

برای حذف قفل یک شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل را بارگذاری می‌کند و محدودیت‌های انتخاب، حرکت و تغییر اندازه را از طریق [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/)، و [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) پاک می‌کند. همچنین محدودیت گروه‌بندی را با ارسال `false` به متد [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) حذف می‌کند و یک نسخهٔ کپی از ارائه ذخیره می‌شود. تنظیمات دیگر قفل به همان صورت باقی می‌مانند.

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

یک عکس به نام `photo.jpg` را در پوشهٔ کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست را برش می‌دهد، سپس متد [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) را بر روی قفل قاب تصویر صدا می‌کند. ارسال `true` برش‌های بعدی را محدود کرده و برش موجود را حفظ می‌کند.

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

`PictureLocked.pptx` ذخیره می‌کند قفل برش به عنوان `true`. در PowerPoint، فرمان **Crop** زمانی که تصویر انتخاب شده باشد غیرفعال می‌شود.

### **نگه داشتن یک نمودار به صورت گروهی**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند، سپس متد [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) را بر روی قفل گروه فراخوانی می‌کند تا اجزای نمودار در کنار هم باقی بمانند. ویرایش‌های دیگر مانند جابه‌جایی گروه یا تغییر پر کردن یک جزء همچنان در دسترس هستند.

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

`DiagramLocked.pptx` ذخیره می‌کند قفل جداسازی به عنوان `true`. در PowerPoint، فرمان **Ungroup** زمانی که کل نمودار انتخاب شده باشد غیرفعال می‌شود.

### **نتیجه‌گیری**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد عملیات ویرایش خاصی را بر روی اشکال منفرد محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای مختلف اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و مقدار آن‌ها را به `false` تنظیم کنید هنگامی که نیاز به حذف این محدودیت‌ها دارید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات ویرایش خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/androidjava/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را در اسلایدهای خاصی بدون تاثیر بر سایر اسلایدها محدود کنم؟**

بله. قفل‌ها را فقط روی اشکال اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل سایر اسلایدها را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال منفرد داخل یک گروه اعمال کنم؟**

از طریق پیمایش مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) گروه بازگردانده می‌شود، قفل‌های مناسب را بر هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های بالا تنها مجموعهٔ اشکال اسلید را پردازش می‌کنند، بنابراین قفل‌ها را بر روی اعضای گروه به طور جداگانه تنظیم نمی‌کنند.