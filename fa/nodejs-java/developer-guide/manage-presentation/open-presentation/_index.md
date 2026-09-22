---
title: باز کردن ارائه‌ها در جاوا اسکریپت
linktitle: باز کردن ارائه
type: docs
weight: 20
url: /fa/nodejs-java/open-presentation/
keywords:
- باز کردن پاورپوینت
- باز کردن ارائه
- باز کردن PPTX
- باز کردن PPT
- باز کردن ODP
- بارگذاری ارائه
- بارگذاری PPTX
- بارگذاری PPT
- بارگذاری ODP
- ارائه محافظت‌شده
- ارائه بزرگ
- منابع خارجی
- شی باینری
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در جاوا اسکریپت باز کنید، رمزهای باز کردن را فراهم کنید، بارگذاری منابع را کنترل کنید و با Aspose.Slides برای Node.js از طریق Java مصرف حافظه را کاهش دهید."
---
## **مقدمه**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/fa/nodejs-java/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در قالب اصلی یا قالب دیگری که پشتیبانی می‌شود ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/) سفارشی شود. به عنوان مثال، می‌توانید یک رمز عبور باز کردن ارائه دهید، اشیاء باینری بزرگ را خارج از حافظه Node.js نگه دارید، منابع خارجی را کنترل کنید یا داده‌های باینری تعبیه‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

پس از بارگذاری یک فایل یا جریان، می‌توانید [قالب اصلی ارائه آن](/slides/fa/nodejs-java/detect-presentation-source-format/) را تعیین کنید تا نحوه پردازش آن توسط برنامه خود را انتخاب کنید.

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازنده [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) پاس دهید. پس از استفاده، ارائه را dispose کنید تا دستگیره‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال زیر به زبان JavaScript نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را به‌دست آورید:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **باز کردن ارائه‌های محافظت‌شده با رمز عبور**

یک رمز عبور باز کردن، محتویات ارائه را رمزنگاری می‌کند. برای بارگذاری کامل ارائه، رمز عبور صحیح را به [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword) پاس دهید و گزینه‌ها را به سازنده [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ارائه کنید. در صورتی که رمز عبور موجود نباشد یا نادرست باشد، بارگذاری شکست می‌خورد.

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

برای فرآیندهای تشخیص رمز عبور، اعتبارسنجی و رمزنگاری، به [Password-Protect Presentations](/slides/fa/nodejs-java/password-protected-presentation/) مراجعه کنید. اگر یک ارائه رمزنگاری‌شده عمداً با ویژگی‌های عمومی سند ذخیره شده باشد، می‌توان این ویژگی‌ها را بدون رمز عبور خواند؛ به [Manage Presentation Properties](/slides/fa/nodejs-java/presentation-properties/) نگاه کنید.

## **باز کردن ارائه‌های بزرگ**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) گزینه‌هایی را برمی‌گرداند که کنترل می‌کند Aspose.Slides چگونه اشیاء بزرگ باینری مانند تصاویر، صدا و ویدئو را مدیریت می‌کند. می‌توانید فایل منبع را قفل بمانید، اجازه فایل‌های موقتی بدهید و مقدار داده‌های BLOB نگهداری‌شده در حافظه را محدود کنید.

کد زیر به زبان JavaScript نحوه بارگذاری یک ارائه بزرگ (مثلاً ۲ گیگابایت) را نشان می‌دهد:

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

{{% alert color="info" title="Note" %}}
با استفاده از [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، فایل منبع تا زمانی که نمونهٔ ارائه dispose نشود، قفل می‌ماند. در حالی که این نمونه زنده است، فایل منبع را جابجا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است محتویات یک جریان ورودی را در هنگام بارگذاری کپی کند. برای ارائه‌های بزرگ، مسیر فایل عموماً کارآمدتر از یک جریان است. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه به [Manage BLOBs](/slides/fa/nodejs-java/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) یک پیاده‌سازی از [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iresourceloadingcallback/) را می‌پذیرد. این فراخوانی می‌تواند داده‌های جایگزین فراهم کند، منبعی را بازگردانی کند، از لودر پیش‌فرض استفاده کند یا آن منبع را نادیده بگیرد. این وقتی مفید است که ارائه‌ها شامل تصاویر خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی خاص برنامه حل شوند.

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

## **بارگذاری ارائه‌ها بدون اشیاء باینری تعبیه‌شده**

یک ارائه ممکن است داده‌های باینری تعبیه‌شده‌ای داشته باشد که برنامه نیاز ندارد یا نمی‌خواهد نگه دارد. مثال‌ها عبارتند از:

- پروژه‌های VBA، که از طریق [Presentation.getVbaProject](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getVbaProject) در دسترس هستند؛
- داده‌های OLE تعبیه‌شده، که از طریق [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) در دسترس هستند؛
- داده‌های کنترل ActiveX، که از طریق [Control.getActiveXControlBinary](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/control/#getActiveXControlBinary) در دسترس هستند.

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) را روی `true` تنظیم کنید تا این داده‌های باینری در هنگام بارگذاری حذف شوند. ارائهٔ بارگذاری‌شده را ذخیره کنید تا نتیجهٔ پاک‌سازی‌شده حفظ شود.

این گزینه ریسک مواجهه با بارهای مخفی ناخواسته را کاهش می‌دهد، اما یک سیستم کامل برای شناسایی بدافزار یا پاک‌سازی محتوا نیست.

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

**چگونه می‌توانم تشخیص دهم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

Aspose.Slides هنگام بارگذاری، یک استثنا مربوط به تجزیه یا قالب رخ می‌دهد. این شکست را جدا از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند علت را به‌دقت گزارش دهد.

**اگر قلم‌های مورد نیاز موجود نباشند چه اتفاقی می‌افتد؟**

ارائه هنوز می‌تواند بارگذاری شود، اما رندرینگ و خروجی ممکن است قلم‌ها را جایگزین کند. می‌توانید [پیکربندی جایگزینی قلم](/slides/fa/nodejs-java/font-substitution/) یا [ارائه قلم‌های سفارشی](/slides/fa/nodejs-java/custom-font/) را انجام دهید تا خروجی پیش‌بینی‌پذیرتر باشد.

**آیا بارگذاری یک ارائه، رسانه‌های تعبیه‌شده آن را نیز بارگذاری می‌کند؟**

صدا و ویدئوی تعبیه‌شده از طریق مدل شیء ارائه در دسترس قرار می‌گیرد. منابع خارجی بر اساس رفتار پیکربندی‌شدهٔ بارگذاری منابع حل می‌شوند و در صورتی که مکان آن‌ها قابل دسترسی نباشد ممکن است در دسترس نباشند.