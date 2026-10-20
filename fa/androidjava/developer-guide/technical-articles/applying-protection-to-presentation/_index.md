---
title: محدود کردن ویرایش‌های ارائه با قفل‌گذاری اشکال در اندروید
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/androidjava/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- حفاظت از ویرایش
- قفل‌گذاری شکل
- قفل‌گذاری موقعیت
- قفل‌گذاری انتخاب
- قفل‌گذاری تغییر اندازه
- قفل‌گذاری گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در ارائه‌های PPTX با Aspose.Slides برای اندروید از طریق جاوا قفل و بازقفل کنید تا انتخاب، جابجایی، تغییر اندازه و گروه‌بندی محدود شوند."
---
## **مروری**

یک استفادهٔ رایج از Aspose.Slides برای Android از طریق Java ایجاد، به‌روزرسانی و ذخیرهٔ ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کار خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات به شکل‌ها می‌تواند به حفظ طرح‌بندی و محتوای موردنظر کمک کند.

این مقاله توضیح می‌دهد که چگونه شکل‌ها در اسلایدها سازماندهی می‌شوند و چگونه می‌توان قفل‌های شکل را در یک ارائهٔ PPTX اعمال و حذف کرد. این قفل‌ها به شما امکان می‌دهند عملیات ویرایشی خاصی را روی شکل‌های منفرد محدود کنید.

## **ترکیب یک اسلاید**

یک اسلاید ارائه از اجزایی مانند اشکال خودکار، جدول‌ها، اشیای OLE، شکل‌های گروهی، قاب‌های تصویر، قاب‌های ویدئو، اتصال‌دهنده‌ها و سایر عناصری که برای ساخت یک ارائه استفاده می‌شوند، تشکیل شده است. در Aspose.Slides برای Android از طریق Java، هر عنصر در یک اسلاید توسط شیئی نشان داده می‌شود که رابط [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاسی که این کار را انجام می‌دهد ارث‌بری می‌کند.

انواع مختلف شکل‌ها گزینه‌های قفل‌گذاری متفاوتی را ارائه می‌دهند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) رابط پایه برای قفل‌های شکل است. Aspose.Slides برای Android از طریق Java رابط‌های قفل زیر را فراهم می‌کند:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) اشکال خودکار را قفل می‌کند.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) اشکال اتصال‌دهنده را قفل می‌کند.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) اشیای گرافیکی را قفل می‌کند.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) اشکال گروهی را قفل می‌کند.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) قاب‌های تصویر را قفل می‌کند.  

برای اعمال قفل‌ها بر تمام یک [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)، بر اسلایدهای آن پیمایش کنید و قفل‌های مناسب را بر هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

قفل‌های شکل عملیات‌هایی مانند انتخاب، جابجایی و تغییر اندازهٔ شکل‌ها را محدود می‌کنند. این قفل‌ها باعث نمی‌شوند کل ارائه غیرقابل ویرایش شود.

### **اعمال حفاظت به شکل‌های PPTX**

Aspose.Slides برای Android از طریق Java رابط [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) را برای کار با شکل‌ها در یک اسلاید فراهم می‌کند.

این مثال متدهای [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), و [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) را با مقدار `true` برای اشکال خودکار صدا می‌زند، و قفل‌های معادل برای اشکال گروهی، اتصال‌دهنده‌ها و قاب‌های تصویر اعمال می‌کند. اتصال‌دهنده‌ها از [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) برای جابجایی استفاده می‌کنند؛ گروه‌ها نیز از [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) برای محدود کردن گروه‌بندی استفاده می‌کنند.

این مثال یک ارائهٔ PPTX موجود را بارگذاری می‌کند، شکل‌ها را در مجموعهٔ شکل هر اسلاید بررسی می‌کند و یک نسخهٔ کپی با این محدودیت‌ها ذخیره می‌کند. شکل‌هایی که خارج از چهار نوع مدیریت‌شده هستند بدون تغییر باقی می‌مانند. حلقه به شکل‌های فرزند داخل یک گروه پیمایش نمی‌کند.

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

برای حذف یک قفل شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل را بارگذاری می‌کند و محدودیت‌های انتخاب، جابجایی و تغییر اندازه را از طریق [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), و [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) پاک می‌سازد. همچنین با ارسال `false` به متد [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) محدودیت گروه‌بندی را حذف می‌کند و یک نسخهٔ کپی از ارائه را ذخیره می‌کند. سایر تنظیمات قفل بدون تغییر می‌مانند.

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

### **نتیجه‌گیری**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد عملیات ویرایشی خاص را روی شکل‌های منفرد محدود کنید یا همان محدودیت‌ها را بر تمام اسلایدها اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و در صورتی که نیاز به حذف این محدودیت‌ها دارید، مقادیر آن‌ها را به `false` تنظیم کنید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در همان ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/androidjava/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را در اسلایدهای خاص بدون تأثیر بر دیگر اسلایدها محدود کنم؟**

بله. قفل‌ها را فقط بر شکل‌های اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر شکل‌های منفرد داخل یک گروه اعمال کنم؟**

از طریق مجموعه‌ای که متد [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) گروه بر می‌گرداند پیمایش کنید و قفل‌های مناسب را بر هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های بالا فقط مجموعهٔ شکل‌های اسلslide را پردازش می‌کنند، بنابراین قفل‌ها را بر اعضای منفرد گروه تنظیم نمی‌کنند.