---
title: باز کردن ارائه‌ها در Android
linktitle: باز کردن ارائه
type: docs
weight: 20
url: /fa/androidjava/open-presentation/
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
- شی باینری
- Android
- Java
- Aspose.Slides
description: "به‌راحتی ارائه‌های PowerPoint (.pptx, .ppt) و OpenDocument (.odp) را با Aspose.Slides برای Android از طریق Java باز کنید—سریع، قابل اعتماد، کاملاً پر ویژگی."
---
## **مقدمه**

علاوه بر ایجاد ارائه‌های PowerPoint از ابتدا، Aspose.Slides به شما امکان باز کردن ارائه‌های موجود را نیز می‌دهد. پس از بارگذاری یک ارائه، می‌توانید اطلاعاتی درباره آن به‌دست آورید، محتویات اسلایدها را ویرایش کنید، اسلایدهای جدید اضافه کنید، اسلایدهای موجود را حذف کنید و موارد دیگر.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را نمونه‌سازی کنید و مسیر فایل را به سازنده‌ آن پاس دهید.

مثال زیر در Java نشان می‌دهد چگونه یک ارائه را باز کرده و تعداد اسلایدهای آن را دریافت کنید:

```java
// نمونه‌سازی کلاس Presentation و پاس دادن مسیر فایل به سازنده‌ آن.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // چاپ تعداد کل اسلایدهای موجود در ارائه.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **باز کردن ارائه‌های محافظت‌شده با رمز عبور**

زمانی که نیاز دارید یک ارائه محافظت‌شده با رمز عبور را باز کنید، رمز عبور را از طریق متد [setPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) کلاس [LoadOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/) به‌منظور رمزگشایی و بارگذاری آن پاس دهید. کد زیر در Java این عملیات را نشان می‌دهد:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // انجام عملیات روی ارائهٔ رمزگشایی‌شده.
} finally {
    presentation.dispose();
}
```

## **باز کردن ارائه‌های بزرگ**

Aspose.Slides گزینه‌هایی—به‌ویژه متد [getBlobManagementOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) در کلاس [LoadOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/)—برای کمک به بارگذاری ارائه‌های بزرگ فراهم می‌کند.

کد زیر در Java بارگذاری یک ارائه بزرگ (به‌عنوان مثال ۲ گیگابایت) را نشان می‌دهد:

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// رفتار KeepLocked را انتخاب کنید—فایل ارائه برای طول عمر
// نمونه Presentation قفل می‌ماند، اما نیازی به بارگذاری در حافظه یا کپی به فایل موقت نیست.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // ارائه بزرگ بارگذاری شده و می‌توان از آن استفاده کرد، در حالی که مصرف حافظه کم باقی می‌ماند.

    // انجام تغییرات روی ارائه.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // ذخیره ارائه در فایل دیگر. در طول این عملیات مصرف حافظه کم می‌ماند.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // این کار را نکنید! یک استثنای I/O رخ می‌دهد زیرا فایل تا زمان آزاد شدن شی Presentation قفل است.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// اینجا انجام دادن آن اشکالی ندارد. فایل منبع دیگر توسط شی Presentation قفل نشده است.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
برای رفع برخی محدودیت‌ها هنگام کار با استریم‌ها، Aspose.Slides ممکن است محتویات یک استریم را کپی کند. بارگذاری یک ارائه بزرگ از یک استریم باعث کپی شدن ارائه می‌شود و می‌تواند سرعت بارگذاری را کاهش دهد. بنابراین، زمانی که نیاز به بارگذاری یک ارائه بزرگ دارید، به‌شدت توصیه می‌کنیم از مسیر فایل ارائه استفاده کنید نه از یک استریم.

هنگام ایجاد ارائه‌ای که شامل اشیای بزرگ (ویدیو، صدا، تصاویر با وضوح بالا و غیره) است، می‌توانید از [مدیریت BLOB](/slides/fa/androidjava/manage-blob/) برای کاهش مصرف حافظه استفاده کنید.
{{%/alert %}}

## **کنترل منابع خارجی**

Aspose.Slides اینترفیس [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iresourceloadingcallback/) را فراهم می‌کند که به شما امکان مدیریت منابع خارجی را می‌دهد. کد زیر در Java نحوه استفاده از اینترفیس `IResourceLoadingCallback` را نشان می‌دهد:

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
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // از هر روشی برای دریافت بایت‌ها استفاده کنید
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // تنظیم یک URL جایگزین.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // رد کردن تمام تصاویر دیگر.
        return ResourceLoadingAction.Skip;
    }
}
```

## **بارگذاری ارائه‌ها بدون اشیای باینری جاسازی‌شده**

یک ارائه PowerPoint می‌تواند شامل انواع زیر از اشیای باینری جاسازی‌شده باشد:

- پروژه VBA (قابل دسترسی از طریق [IPresentation.getVbaProject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- داده‌های شیء OLE جاسازی‌شده (قابل دسترسی از طریق [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- داده‌های باینری کنترل ActiveX (قابل دسترسی از طریق [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

با استفاده از متد [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) می‌توانید یک ارائه را بدون هیچ شیء باینری جاسازی‌شده‌ای بارگذاری کنید.

این متد برای حذف محتویات باینری احتمالی مخرب مفید است. کد زیر در Java نشان می‌دهد چگونه یک ارائه را بدون هیچ محتوی باینری جاسازی‌شده‌ای بارگذاری کنید:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // انجام عملیات روی ارائه.
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

در هنگام بارگذاری یک استثنای تجزیه/اعتبارسنجی فرمت دریافت می‌کنید. چنین خطاهایی اغلب به ساختار ZIP نامعتبر یا رکوردهای PowerPoint شکسته اشاره می‌کنند.

**اگر هنگام باز کردن، قلم‌های لازم موجود نباشند چه می‌شود؟**

فایل باز می‌شود، اما بعداً ممکن است هنگام [رندر/صادرات](/slides/fa/androidjava/convert-presentation/) قلم‌ها جایگزین شوند. برای تنظیم جایگزینی قلم‌ها به [پیکربندی جایگزینی قلم](/slides/fa/androidjava/font-substitution/) مراجعه کنید یا قلم‌های مورد نیاز را به محیط زمان اجرا اضافه کنید.

**در مورد رسانه‌های جاسازی‌شده (ویدیو/صدا) هنگام باز کردن چه می‌شود؟**

این‌ها به‌عنوان منابع ارائه در دسترس قرار می‌گیرند. اگر رسانه‌ها از طریق مسیرهای خارجی ارجاع داده شوند، اطمینان حاصل کنید این مسیرها در محیط شما قابل دسترسی باشند؛ در غیر این صورت ممکن است هنگام [رندر/صادرات](/slides/fa/androidjava/convert-presentation/) رسانه‌ها حذف شوند.