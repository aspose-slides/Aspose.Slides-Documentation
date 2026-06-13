---
title: باز کردن ارائه‌ها در JavaScript
linktitle: باز کردن ارائه
type: docs
weight: 20
url: /fa/nodejs-java/open-presentation/
keywords:
- باز کردن PowerPoint
- باز کردن OpenDocument
- باز کردن ارائه
- باز کردن PPTX
- باز کردن PPT
- باز کردن ODP
- بارگیری ارائه
- بارگیری PPTX
- بارگیری PPT
- بارگیری ODP
- ارائه محافظت‌شده
- ارائه بزرگ
- منبع خارجی
- شیء باینری
- Node.js
- JavaScript
- Aspose.Slides
description: "به راحتی ارائه‌های PowerPoint (.pptx, .ppt) و OpenDocument (.odp) را با Aspose.Slides برای Node.js از طریق Java—سرعت بالا، قابل اعتماد، کاملاً مجهز."
---
## **مقدمه**

علاوه بر ایجاد ارائه‌های PowerPoint از ابتدا، Aspose.Slides همچنین امکان باز کردن ارائه‌های موجود را فراهم می‌کند. پس از بارگذاری یک ارائه، می‌توانید اطلاعات مربوط به آن را بازیابی کنید، محتوای اسلایدها را ویرایش کنید، اسلایدهای جدید اضافه کنید، اسلایدهای موجود را حذف کنید و کارهای بیشتری انجام دهید.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را نمونه‌سازی کنید و مسیر فایل را به سازنده آن پاس بدهید.

مثال زیر در JavaScript نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را دریافت کنید:

```js
// یک نمونه از کلاس Presentation ایجاد کنید و مسیر فایل را به سازنده آن پاس دهید.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // تعداد کل اسلایدهای موجود در ارائه را چاپ کنید.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **باز کردن ارائه‌های محافظت‌شده با رمز عبور**

هنگامی که نیاز به باز کردن ارائه‌ای دارید که با رمز عبور محافظت می‌شود، رمز عبور را از طریق متد [setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword) کلاس [LoadOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/) ارسال کنید تا آن را رمزگشایی و بارگذاری کنید. کد زیر در JavaScript این عملیات را نشان می‌دهد:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // عملیات روی ارائه رمزگشایی‌شده را انجام دهید.
} finally {
    presentation.dispose();
}
```

## **باز کردن ارائه‌های بزرگ**

Aspose.Slides گزینه‌هایی—به‌ویژه متد [getBlobManagementOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) در کلاس [LoadOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/)—برای کمک به بارگذاری ارائه‌های بزرگ ارائه می‌دهد.

کد زیر در JavaScript بارگذاری یک ارائه بزرگ (به عنوان مثال ۲ گیگابایت) را نشان می‌دهد:

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// انتخاب رفتار KeepLocked — فایل ارائه برای طول عمر
// نمونه Presentation، اما نیازی به بارگیری در حافظه یا کپی به فایل موقت نیست.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // ۱۰ مگابایت

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // ارائه بزرگ بارگذاری شده و قابل استفاده است، در حالی که مصرف حافظه پایین باقی می‌ماند.
    
    // تغییرات مورد نیاز را در ارائه اعمال کنید.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // ارائه را در فایل دیگری ذخیره کنید. در حین این عملیات مصرف حافظه کم می‌ماند.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // این کار را انجام ندهید! یک استثنای I/O پرتاب می‌شود زیرا فایل تا زمان آزادسازی شیء Presentation قفل است.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// در اینجا انجام دادن آن اشکالی ندارد. فایل منبع دیگر توسط شیء Presentation قفل نشده است.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
برای دور زدن برخی محدودیت‌ها هنگام کار با جریان‌ها، Aspose.Slides ممکن است محتوای یک جریان را کپی کند. بارگذاری یک ارائه بزرگ از یک جریان باعث کپی شدن ارائه می‌شود و می‌تواند سرعت بارگذاری را کاهش دهد. بنابراین، زمانی که نیاز به بارگذاری یک ارائه بزرگ دارید، شدیداً توصیه می‌کنیم به‌جای استفاده از جریان، مسیر فایل ارائه را استفاده کنید.

هنگامی که یک ارائه شامل اشیاء بزرگ (ویدئو، صدا، تصاویر با وضوح بالا و غیره) است، می‌توانید از [مدیریت BLOB](/slides/fa/nodejs-java/manage-blob/) برای کاهش مصرف حافظه استفاده کنید.
{{%/alert %}}

## **کنترل منابع خارجی**

Aspose.Slides رابط [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iresourceloadingcallback/) را فراهم می‌کند که به شما امکان مدیریت منابع خارجی را می‌دهد. کد زیر در JavaScript نشان می‌دهد چگونه از رابط `IResourceLoadingCallback` استفاده کنید:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // بارگذاری یک تصویر جایگزین.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // تنظیم یک URL جایگزین.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // نادیده گرفتن تمام تصاویر دیگر.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **بارگذاری ارائه‌ها بدون اشیاء باینری جاسازی‌شده**

یک ارائه PowerPoint می‌تواند شامل انواع زیر از اشیاء باینری جاسازی‌شده باشد:

- پروژه VBA (دسترس‌پذیر از طریق [Presentation.getVbaProject](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getVbaProject));
- داده‌های جاسازی شده OLE (دسترس‌پذیر از طریق [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- داده‌های باینری کنترل ActiveX (دسترس‌پذیر از طریق [Control.getActiveXControlBinary](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

با استفاده از متد [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) می‌توانید یک ارائه را بدون هیچ‌گونه شیء باینری جاسازی‌شده‌ای بارگذاری کنید.

این متد برای حذف محتوای باینری احتمالی مخرب مفید است. کد زیر در JavaScript نحوه بارگذاری یک ارائه بدون هرگونه محتوا باینری جاسازی‌شده را نشان می‌دهد:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // عملیات روی ارائه را انجام دهید.
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**چگونه می‌توانم بفهمم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

در هنگام بارگذاری، یک استثنای تجزیه/اعتبارسندی فرمت دریافت می‌کنید. چنین خطاهایی اغلب به ساختار ZIP نامعتبر یا رکوردهای خراب PowerPoint اشاره می‌کنند.

**اگر فونت‌های مورد نیاز هنگام باز کردن موجود نباشند چه می‌شود؟**

فایل باز می‌شود، اما پس از آن ممکن است هنگام [رندر/خروجی](/slides/fa/nodejs-java/convert-presentation/) فونت‌ها جایگزین شوند. می‌توانید [جایگزینی فونت‌ها را پیکربندی کنید](/slides/fa/nodejs-java/font-substitution/) یا [فونت‌های مورد نیاز را اضافه کنید](/slides/fa/nodejs-java/custom-font/) به محیط زمان اجرا.

**در مورد رسانه‌های جاسازی‌شده (ویدئو/صدا) هنگام باز کردن چه اتفاقی می‌افتد؟**

آن‌ها به عنوان منابع ارائه در دسترس می‌شوند. اگر رسانه‌ها از طریق مسیرهای خارجی ارجاع داده شوند، اطمینان حاصل کنید که این مسیرها در محیط شما قابل دسترسی باشد؛ در غیر این صورت ممکن است هنگام [رندر/خروجی](/slides/fa/nodejs-java/convert-presentation/) رسانه‌ها حذف شوند.