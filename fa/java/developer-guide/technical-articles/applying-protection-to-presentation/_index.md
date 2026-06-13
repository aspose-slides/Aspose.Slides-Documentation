---
title: جلوگیری از ویرایش ارائه با قفل‌گذاری شکل‌ها
linktitle: جلوگیری از ویرایش ارائه
type: docs
weight: 60
url: /fa/java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- حفاظت از ویرایش
- قفل شکل
- قفل موقعیت
- قفل انتخاب
- قفل اندازه
- قفل گروه‌بندی
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "کشف کنید چگونه Aspose.Slides for Java شکل‌ها را در فایل‌های PPT، PPTX و ODP قفل یا بازقفل می‌کند، ارائه‌ها را امن می‌سازد در حالی که ویرایش‌های کنترل‌شده و تحویل سریع‌تر را ممکن می‌سازد."
---
## **پیش‌زمینه**

یک استفاده رایج از Aspose.Slides ایجاد، به‌روزرسانی و ذخیره ارائه‌های Microsoft PowerPoint (PPTX) به عنوان بخشی از یک جریان کاری خودکار است. کاربران برنامه‌هایی که به این شکل از Aspose.Slides استفاده می‌کنند به ارائه‌های تولید شده دسترسی دارند، بنابراین حفاظت از ویرایش آن‌ها یک نگرانی معمول است. مهم است که ارائه‌های تولید شده به‌صورت خودکار قالب‌بندی و محتوای اصلی خود را حفظ کنند.

این مقاله توضیح می‌دهد که ارائه‌ها و اسلایدها چگونه ساختار یافته‌اند و چگونه Aspose.Slides for Java می‌تواند حفاظت را بر یک ارائه اعمال کرده و بعداً آن را حذف کند. این مقاله به توسعه‌دهندگان راهی برای کنترل نحوه استفاده از ارائه‌هایی که برنامه‌هایشان تولید می‌کنند، ارائه می‌دهد.

## **ترکیب یک اسلاید**

یک اسلاید ارائه از اجزائی مانند شکل‌های خودکار، جدول‌ها، اشیاء OLE، شکل‌های گروهی، فریم‌های تصویر، فریم‌های ویدئو، کانکتورها و سایر عناصر مورد استفاده برای ساخت یک ارائه تشکیل می‌شود. در Aspose.Slides for Java، هر عنصر روی اسلاید توسط شیئی نماینده می‌شود که رابط [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاسی که این رابط را به ارث می‌برد، مشتق شده است.

ساختار PPTX پیچیده است، بنابراین برخلاف PPT که می‌توان یک قفل عمومی برای تمام انواع شکل‌ها استفاده کرد، انواع شکل‌های مختلف به قفل‌های متفاوتی نیاز دارند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseshapelock/) کلاس قفل‌گذاری عمومی برای PPTX است. انواع قفل‌های زیر در Aspose.Slides for Java برای PPTX پشتیبانی می‌شوند:

- [IAutoShapeLock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshapelock/) قفل خودکارشکل‌ها.
- [IConnectorLock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iconnectorlock/) قفل اشکال اتصال.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igraphicalobjectlock/) قفل اشیاء گرافیکی.
- [IGroupShapeLock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igroupshapelock/) قفل شکل‌های گروهی.
- [IPictureFrameLock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframelock/) قفل فریم‌های تصویر.

هر عملیاتی که بر تمام اشیای شکل در یک شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) انجام شود، بر کل ارائه اعمال می‌شود.

## **اعمال و حذف حفاظت**

اعمال حفاظت تضمین می‌کند که یک ارائه قابل ویرایش نباشد. این یک تکنیک مفید برای محافظت از محتویات ارائه است.

### **اعمال حفاظت به شکل‌های PPTX**

Aspose.Slides for Java رابط [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) را برای کار با شکل‌ها در یک اسلاید فراهم می‌کند.

همان‌طور که در بالا اشاره شد، هر کلاس شکل دارای کلاسی قفل‌شکل مرتبط برای حفاظت است. این مقاله بر قفل‌های NoSelect، NoMove و NoResize تمرکز می‌کند. این قفل‌ها تضمین می‌کنند که شکل‌ها نمی‌توانند انتخاب شوند (از طریق کلیک ماوس یا روش‌های دیگر انتخاب) و نمی‌توانند جابجا یا اندازه‌شان تغییر یابد.

نمونه کد زیر حفاظت را بر تمام انواع شکل‌ها در یک ارائه اعمال می‌کند.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است.
Presentation presentation = new Presentation("Sample.pptx");

// عبور از همه اسلایدهای موجود در ارائه.
for (ISlide slide : presentation.getSlides()) {

    // عبور از همه شکل‌ها در اسلاید.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // تبدیل نوع شکل به یک autoshape و دریافت قفل شکل آن.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // تبدیل نوع شکل به یک group shape و دریافت قفل شکل آن.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // تبدیل نوع شکل به یک connector shape و دریافت قفل شکل آن.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // تبدیل نوع شکل به یک picture frame و دریافت قفل شکل آن.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// ذخیره‌سازی فایل ارائه.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **حذف حفاظت**

برای باز کردن یک شکل، مقدار قفل اعمال‌شده را به `false` تنظیم کنید. نمونه کد زیر نشان می‌دهد چگونه شکل‌ها را در یک ارائه قفل‌شده باز کنید.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// گشتن در تمام اسلایدهای موجود در ارائه.
for (ISlide slide : presentation.getSlides()) {

    // گشتن در تمام شکل‌ها در اسلاید.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // تبدیل نوع شکل به یک autoshape و دریافت قفل شکل آن.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // تبدیل نوع شکل به یک group shape و دریافت قفل شکل آن.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // تبدیل نوع شکل به یک connector shape و دریافت قفل شکل آن.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // تبدیل نوع شکل به یک picture frame و دریافت قفل شکل آن.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// ذخیره‌سازی فایل ارائه.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **نتیجه‌گیری**

Aspose.Slides چندین گزینه برای حفاظت از شکل‌ها در یک ارائه ارائه می‌دهد. می‌توانید یک شکل را به‌تنهایی قفل کنید یا تمام شکل‌ها را در یک ارائه مرور کنید و هر یک را قفل کنید تا به‌طور مؤثری کل فایل را ایمن سازید. می‌توانید با تنظیم مقدار قفل به `false` حفاظت را حذف کنید.

## **سؤالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌ها ویرایش اشیاء داخل فایل را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/java/password-protected-presentation/) دسترسی به باز کردن و/یا ذخیره تغییرات را کنترل می‌کند. این مکانیزم‌ها یکدیگر را تکمیل می‌کنند و به‌صورت مشترک عمل می‌کنند.

**آیا می‌توانم ویرایش را در اسلایدهای خاص محدود کنم بدون اینکه بر سایر اسلایدها تأثیر بگذارد؟**

بله. قفل‌ها را بر شکل‌های اسلایدهای انتخاب‌شده اعمال کنید؛ اسلایدهای باقی‌مانده قابل ویرایش خواهند ماند.

**آیا قفل‌های شکل بر روی اشیاء گروهی و کانکتورها اعمال می‌شوند؟**

بله. انواع قفل مخصوص برای گروه‌ها، کانکتورها، اشیاء گرافیکی و سایر انواع شکل‌ها پشتیبانی می‌شود.