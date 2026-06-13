---
title: باز کردن ارائه‌ها در Java
linktitle: باز کردن ارائه
type: docs
weight: 20
url: /fa/java/open-presentation/
keywords:
- باز کردن PowerPoint
- باز کردن OpenDocument
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
- منبع خارجی
- شیء باینری
- جاوا
- Aspose.Slides
description: "به راحتی ارائه‌های PowerPoint (.pptx, .ppt) و OpenDocument (.odp) را با Aspose.Slides برای Java باز کنید — سریع، قابل اعتماد، کاملاً مجهز."
---
## **معرفی**

علاوه بر ساخت ارائه‌های PowerPoint از صفر، Aspose.Slides همچنین به شما اجازه می‌دهد ارائه‌های موجود را باز کنید. پس از بارگذاری یک ارائه، می‌توانید اطلاعات آن را بازیابی کنید، محتوای اسلایدها را ویرایش کنید، اسلایدهای جدید اضافه کنید، اسلایدهای موجود را حذف کنید و غیره.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را نمونه‌سازی کنید و مسیر فایل را به سازنده آن پاس دهید.

مثال زیر به زبان Java نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را دریافت کنید:

```java
// یک نمونه از کلاس Presentation ایجاد کنید و مسیر فایل را به سازنده آن پاس دهید.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // تعداد کل اسلایدهای موجود در ارائه را چاپ کنید.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **باز کردن ارائه‌های محافظت‌شده با رمز عبور**

زمانی که نیاز به باز کردن یک ارائه محافظت‌شده با رمز عبور دارید، رمز عبور را از طریق متد [setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) کلاس [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) به منظور رمزگشایی و بارگذاری ارائه پاس بدهید. کد Java زیر این عملیات را نشان می‌دهد:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // عملیات روی ارائه رمزگشایی‌شده را انجام دهید.
} finally {
    presentation.dispose();
}
```

## **باز کردن ارائه‌های بزرگ**

Aspose.Slides گزینه‌هایی ارائه می‌دهد—به‌ویژه متد [getBlobManagementOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) در کلاس [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/)—تا به شما در بارگذاری ارائه‌های بزرگ کمک کند.

کد Java زیر بارگذاری یک ارائه بزرگ (به‌عنوان مثال، ۲ گیگابایت) را نشان می‌دهد:

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// رفتار KeepLocked را انتخاب کنید—فایل ارائه برای طول عمر
// شیء Presentation، اما نیازی به بارگذاری در حافظه یا کپی به فایل موقت نیست.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 مگابایت

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // ارائه بزرگ بارگذاری شد و می‌تواند استفاده شود، در حالی که مصرف حافظه کم می‌ماند.

    // تغییرات را بر روی ارائه اعمال کنید.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // ارائه را در فایل دیگری ذخیره کنید. در طول این عملیات مصرف حافظه کم می‌ماند.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // این کار را نکنید! یک استثنای I/O صادر می‌شود زیرا فایل تا زمانی که شیء Presentation آزاد نشود قفل است.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// این کار در اینجا مجاز است. فایل منبع دیگر توسط شیء Presentation قفل نیست.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
برای دور زدن برخی محدودیت‌ها هنگام کار با جریان‌ها، Aspose.Slides ممکن است محتوای یک جریان را کپی کند. بارگذاری یک ارائه بزرگ از یک جریان باعث می‌شود که ارائه کپی شود و می‌تواند سرعت بارگذاری را کاهش دهد. بنابراین، زمانی که نیاز به بارگذاری یک ارائه بزرگ دارید، به‌شدید توصیه می‌کنیم از مسیر فایل ارائه به‌جای یک جریان استفاده کنید.

هنگام ایجاد یک ارائه که شامل اشیای بزرگ (ویدئو، صدا، تصاویر با وضوح بالا و غیره) باشد، می‌توانید از [BLOB management](/slides/fa/java/manage-blob/) برای کاهش مصرف حافظه استفاده کنید.
{{%/alert %}}

## **کنترل منابع خارجی**

Aspose.Slides رابط [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iresourceloadingcallback/) را فراهم می‌کند که به شما امکان مدیریت منابع خارجی را می‌دهد. کد Java زیر نشان می‌دهد چگونه از اینترفیس `IResourceLoadingCallback` استفاده کنید:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // بارگذاری یک تصویر جایگزین.
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // تنظیم URL جایگزین.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // از تمام تصاویر دیگر عبور کنید.
        return ResourceLoadingAction.Skip;
    }
}
```

## **بارگذاری ارائه‌ها بدون اشیای باینری جاسازی‌شده**

یک ارائه PowerPoint می‌تواند انواع زیر از اشیای باینری جاسازی‌شده را داشته باشد:

- پروژه VBA (accessible via [IPresentation.getVbaProject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getVbaProject--));
- داده‌های جاسازی‌شده شیء OLE (accessible via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- داده‌های باینری کنترل ActiveX (accessible via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

با استفاده از متد [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) می‌توانید یک ارائه را بدون هیچ‌یک از اشیای باینری جاسازی‌شده بارگذاری کنید.

این متد برای حذف محتوای باینری که ممکن است مخرب باشد مفید است. کد Java زیر نشان می‌دهد چگونه یک ارائه را بدون هیچ محتوای باینری جاسازی‌شده‌ای بارگذاری کنید:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // عملیات روی ارائه را انجام دهید.
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

هنگام بارگذاری، یک استثنای تجزیه/اعتبارسنجی فرمت دریافت خواهید کرد. این گونه خطاها اغلب ساختار ZIP نامعتبر یا رکوردهای خراب PowerPoint را ذکر می‌کنند.

**اگر فونت‌های مورد نیاز هنگام باز کردن موجود نباشند چه اتفاقی می‌افتد؟**

فایل باز می‌شود، اما بعداً ممکن است در [rendering/export](/slides/fa/java/convert-presentation/) فونت‌ها جایگزین شوند. برای جلوگیری از این امر می‌توانید [Configure font substitutions](/slides/fa/java/font-substitution/) یا [add the required fonts](/slides/fa/java/custom-font/) را به محیط زمان اجرا اضافه کنید.

**در مورد رسانه‌های جاسازی‌شده (ویدئو/صدا) هنگام باز کردن چه می‌شود؟**

آنها به‌عنوان منابع ارائه در دسترس می‌شوند. اگر رسانه‌ها از طریق مسیرهای خارجی ارجاع شوند، اطمینان حاصل کنید این مسیرها در محیط شما قابل دسترسی باشند؛ در غیر این صورت ممکن است [rendering/export](/slides/fa/java/convert-presentation/) رسانه‌ها را حذف کند.