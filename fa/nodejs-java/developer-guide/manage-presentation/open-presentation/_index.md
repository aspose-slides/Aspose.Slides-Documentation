---
title: "باز کردن ارائه‌ها در جاوااسکریپت"
linktitle: "باز کردن ارائه"
type: docs
weight: 20
url: /fa/nodejs-java/open-presentation/
keywords:
- "باز کردن پاورپوینت"
- "باز کردن ارائه"
- "باز کردن PPTX"
- "باز کردن PPT"
- "باز کردن ODP"
- "بارگذاری ارائه"
- "بارگذاری PPTX"
- "بارگذاری PPT"
- "بارگذاری ODP"
- "ارائهٔ محافظت‌شده"
- "ارائهٔ بزرگ"
- "منبع خارجی"
- "شیء دودویی"
- "Node.js"
- "جاوااسکریپت"
- "Aspose.Slides"
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در جاوااسکریپت باز کنید، رمزهای عبور باز کردن را فراهم کنید، بارگذاری منابع را کنترل کنید و با Aspose.Slides برای Node.js via Java استفاده از حافظه را کاهش دهید."
---
## **مقدمه**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/fa/nodejs-java/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در فرمت اصلی یا فرمت پشتیبانی‌شده دیگری ذخیره کنید.

رفتار بارگذاری را می‌توان از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/) سفارشی کرد. برای مثال، می‌توانید رمز عبور باز کردن را فراهم کنید، اشیای دودویی بزرگ را خارج از حافظه Node.js نگهداری کنید، منابع خارجی را کنترل کنید یا داده‌های دودویی جاسازی‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) پاس دهید. پس از استفاده از ارائه، آن را آزاد کنید تا دستگیره‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال جاوااسکریپت زیر نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را بخوانید:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **باز کردن ارائه‌های دارای رمز عبور**

یک رمز عبور برای باز کردن محتویات ارائه را رمزگذاری می‌کند. برای بارگذاری کامل ارائه، رمز عبور صحیح را به متد [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword) بدهید و گزینه‌ها را به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) پاس کنید. اگر رمز عبور گمشده یا نادرست باشد، بارگذاری با شکست مواجه می‌شود.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

برای تشخیص رمز عبور، اعتبارسنجی و گردش‌های کاری رمزگذاری، به بخش [Password-Protect Presentations](/slides/fa/nodejs-java/password-protected-presentation/) مراجعه کنید. اگر ارائه‌ای به‌صورت رمزگذاری شده‌ای ذخیره شده باشد که خصوصیات عمومی سند داشته باشد، می‌توان این خصوصیات را بدون رمز عبور خواند؛ برای جزئیات به [Manage Presentation Properties](/slides/fa/nodejs-java/presentation-properties/) نگاه کنید.

## **باز کردن ارائه‌های بزرگ**

متد [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) گزینه‌هایی را برمی‌گرداند که کنترل می‌کند Aspose.Slides چگونه اشیای دودویی بزرگ مانند تصاویر، صدا و ویدئو را مدیریت می‌کند. می‌توانید فایل منبع را قفل نگه دارید، اجازهٔ استفاده از فایل‌های موقت را بدهید و مقدار داده‌های BLOB نگهداری‌شده در حافظه را محدود کنید.

کد جاوااسکریپت زیر نشان می‌دهد چگونه یک ارائه بزرگ (به‌عنوان مثال ۲ گیگابایت) را بارگذاری کنید:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="توجه" %}}

با استفاده از [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، فایل منبع تا زمانی که نمونهٔ ارائه آزاد نشود، قفل می‌ماند. در طول حیات آن نمونه، فایل منبع را منتقل، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است محتویات یک جریان ورودی را هنگام بارگذاری کپی کند. برای ارائه‌های بزرگ، مسیر فایل معمولاً کارایی بیشتری نسبت به جریان دارد. برای گزینه‌های ذخیره‌سازی و مدیریت حافظهٔ اضافی به بخش [Manage BLOBs](/slides/fa/nodejs-java/manage-blob/) مراجعه کنید.

{{% /alert %}}

## **کنترل منابع خارجی**

متد [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) یک پیاده‌سازی از [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iresourceloadingcallback/) را می‌پذیرد. این کال‌بک می‌تواند دادهٔ جایگزین ارائه دهد، یک منبع را بازنویسی کند، از بارگذار پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این ویژگی زمانی مفید است که ارائه‌ها شامل تصاویر خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی خاص برنامه حل شوند.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **بارگذاری ارائه‌ها بدون اشیای دودویی جاسازی‌شده**

یک ارائه ممکن است شامل داده‌های دودویی جاسازی‌شده باشد که برنامه نیازی به آن ندارد یا نمی‌خواهد آن را نگه دارد. نمونه‌هایی شامل:

- پروژه‌های VBA که از طریق [Presentation.getVbaProject](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getVbaProject) در دسترس هستند؛
- داده‌های OLE جاسازی‌شده که از طریق [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) قابل دستیابی‌اند؛
- داده‌های کنترل ActiveX که از طریق [Control.getActiveXControlBinary](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/control/#getActiveXControlBinary) در دسترس هستند.

برای حذف این داده‌های دودویی هنگام بارگذاری، [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) را روی `true` تنظیم کنید. سپس ارائهٔ بارگذاری‌شده را ذخیره کنید تا نتیجهٔ پاک‌سازی شده حفظ شود.

این گزینه خطر مواجهه با بارهای جاسازی‌شدهٔ ناخواسته را کاهش می‌دهد، اما جایگزین یک سیستم کامل شناسایی بدافزار یا تصفیهٔ محتوا نیست.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**چگونه می‌توانم بفهمم فایلی خراب است و نمی‌توان آن را باز کرد؟**

Aspose.Slides در طول بارگذاری یک استثنای تجزیه یا فرمت پرتاب می‌کند. این شکست را جدا از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند دلیل را دقیقاً گزارش دهد.

**اگر فونت‌های موردنیاز موجود نباشند چه می‌شود؟**

ارائه همچنان بارگذاری می‌شود، اما هنگام رندر و خروجی ممکن است فونت‌ها جایگزین شوند. می‌توانید [جایگزینی فونت](/slides/fa/nodejs-java/font-substitution/) را پیکربندی کنید یا [فونت‌های سفارشی](/slides/fa/nodejs-java/custom-font/) فراهم کنید تا خروجی پیش‌بینی‌پذیرتر باشد.

**آیا بارگذاری یک ارائه باعث بارگذاری رسانه‌های جاسازی‌شدهٔ آن نیز می‌شود؟**

صوت و ویدئوی جاسازی‌شده از طریق مدل شیء ارائه در دسترس می‌شوند. منابع خارجی بر اساس رفتار پیکربندی‌شدهٔ بارگذاری منابع حل می‌شوند و در صورتی که مکان‌های آن‌ها قابل دسترسی نباشد، ممکن است در دسترس نباشند.