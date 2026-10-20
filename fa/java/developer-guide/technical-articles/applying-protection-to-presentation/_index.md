---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در جاوا
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- حفاظت در برابر ویرایش
- قفل شکل
- قفل موقعیت
- قفل انتخاب
- قفل تغییر اندازه
- قفل گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در ارائه‌های PPTX با Aspose.Slides برای جاوا قفل و بازقفل کنید تا انتخاب، جابه‌جایی، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **پس‌زمینه**

استفاده رایج از Aspose.Slides for Java ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کاری خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات در اشکال می‌تواند به حفظ طرح و محتوای موردنظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چگونه می‌توان قفل‌های اشکال را در یک ارائه PPTX اعمال و حذف کرد. این قفل‌ها به شما اجازه می‌دهند عملیات ویرایشی خاصی را بر روی اشکال فردی محدود کنید.

## **ترکیب اسلاید**

یک اسلاید ارائه از اجزایی مانند اشکال خودکار، جدول‌ها، اشیاء OLE، اشکال گروه‌بندی‌شده، قاب‌های تصویر، قاب‌های ویدئویی، اتصال‌دهنده‌ها و سایر عناصر مورد استفاده برای ساخت یک ارائه تشکیل شده است. در Aspose.Slides for Java، هر عنصر در یک اسلاید توسط شیئی که پیاده‌سازی‌کنندهٔ رابط [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) است یا از کلاسی که این رابط را ارث می‌برد، نمایندگی می‌شود.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی را فراهم می‌کنند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) رابط پایه برای قفل‌های اشکال است. Aspose.Slides for Java رابط‌های قفل زیر را ارائه می‌دهد:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) قفل اشکال خودکار.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) قفل اشکال اتصال‌دهنده.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) قفل اشیاء گرافیکی.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) قفل اشکال گروهی.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) قفل قاب‌های تصویر.  

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)، اسلایدهای آن را مرور کنید و قفل‌های مناسب را بر هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

قفل‌های اشکال عملیات‌هایی مانند انتخاب، جابه‌جایی و تغییر اندازه اشکال را محدود می‌کنند. آن‌ها کل ارائه را غیرقابل ویرایش نمی‌سازند.

### **اعمال حفاظت بر اشکال PPTX**

Aspose.Slides for Java رابط [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) را برای کار با اشکال در یک اسلاید فراهم می‌کند.

مثال زیر متدهای [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)، [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) و [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) را با مقدار `true` برای اشکال خودکار فراخوانی می‌کند؛ برای اشکال گروهی، اتصال‌دهنده‌ها و قاب‌های تصویر نیز قفل‌های معادل اعمال می‌شود. اتصال‌دهنده‌ها برای جابه‌جایی از [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) استفاده می‌کنند؛ گروه‌ها همچنین از [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) برای محدود کردن گروه‌بندی بهره می‌برند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعهٔ اشکال هر اسلاید را بررسی می‌کند و نسخه‌ای را با این محدودیت‌ها ذخیره می‌نماید. اشکالی که خارج از چهار نوع پشتیبانی‌شده هستند بدون تغییر باقی می‌مانند. حلقه اشکال فرزند داخل یک گروه را مرور نمی‌کند.

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

برای حذف قفل یک اشکال، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های اشکال را بارگذاری کرده و محدودیت‌های انتخاب، جابه‌جایی و تغییر اندازه را از طریق [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) و [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) پاک می‌کند. همچنین محدودیت گروه‌بندی را با ارسال `false` به [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) حذف می‌کند و نسخه‌ای از ارائه را ذخیره می‌نماید. سایر تنظیمات قفل بدون تغییر باقی می‌مانند.

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

Aspose.Slides for Java به شما امکان می‌دهد عملیات ویرایشی خاصی را بر روی اشکال فردی محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای مختلف اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کرده و مقادیر آن‌ها را به `false` تنظیم کنید وقتی که نیاز به حذف این محدودیت‌ها دارید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های اشکال و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های اشکال عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/java/password-protected-presentation/) می‌تواند باز کردن یا ویرایش ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را فقط در اسلایدهای خاصی محدود کنم بدون اینکه بر دیگران تأثیر بگذارد؟**

بله. قفل‌ها را فقط بر روی اشکال اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال فردی داخل یک گروه اعمال کنم؟**

از طریق مجموعهٔ‌ای که متد [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) گروه برمی‌گرداند، عبور کنید و قفل‌های مناسب را بر هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های بالا تنها مجموعهٔ اشکال اسلاید را پردازش می‌کنند، بنابراین قفل‌ها را بر اعضای فردی گروه تنظیم نمی‌کنند.