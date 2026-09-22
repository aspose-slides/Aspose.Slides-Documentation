---
title: باز کردن ارائه‌ها در جاوا
linktitle: باز کردن ارائه
type: docs
weight: 20
url: /fa/java/open-presentation/
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
- منبع خارجی
- شیء باینری
- جاوا
- Aspose.Slides
description: "یاد بگیرید چطور در جاوا ارائه‌های PowerPoint و OpenDocument را باز کنید، رمزهای عبور باز کردن را فراهم کنید، بارگذاری منابع را کنترل کنید و مصرف حافظه را با Aspose.Slides برای جاوا کاهش دهید."
---
## **مقدمه**

[Aspose.Slides برای Java](https://products.aspose.com/slides/fa/java/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در قالب اصلی یا قالب پشتیبانی شده دیگر ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) سفارشی شود. برای مثال، می‌توانید رمز عبور باز کردن را فراهم کنید، اشیای باینری بزرگ را خارج از حافظه هِپ Java نگه دارید، منابع خارجی را کنترل کنید یا داده‌های باینری جاسازی‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

پس از بارگذاری یک فایل یا جریان، می‌توانید [فرمت اصلی ارائه را تشخیص دهید](/slides/fa/java/detect-presentation-source-format/) تا نحوه پردازش آن توسط برنامه‌تان را انتخاب کنید.

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازنده [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) پاس دهید. پس از استفاده، ارائه را آزاد کنید تا دسته‌های فایل، داده‌های موقت و سایر منابع به سرعت آزاد شوند.

مثال زیر در Java نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را دریافت کنید:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **باز کردن ارائه‌های محافظت‌شده با رمز عبور**

یک رمز عبور باز کردن، محتوای ارائه را رمزگذاری می‌کند. برای بارگذاری کامل ارائه، رمز درست را به متد [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) پاس دهید و گزینه‌ها را به سازنده [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بدهید. اگر رمز عبور غائب یا نادرست باشد، بارگذاری با شکست مواجه می‌شود.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

برای تشخیص رمز عبور، اعتبارسنجی و جریان‌های کاری رمزنگاری، به صفحه [Password-Protect Presentations](/slides/fa/java/password-protected-presentation/) مراجعه کنید. اگر یک ارائه رمزگذاری‌شده عمداً با ویژگی‌های عمومی سند ذخیره شده باشد، می‌توان این ویژگی‌ها را بدون رمز عبور خواند؛ برای جزئیات به [Manage Presentation Properties](/slides/fa/java/presentation-properties/) نگاه کنید.

## **باز کردن ارائه‌های بزرگ**

متد [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) گزینه‌هایی را برمی‌گرداند که کنترل می‌کند Aspose.Slides چگونه اشیای باینری بزرگ مانند تصویر، صدا و ویدئو را مدیریت می‌کند. می‌توانید فایل منبع را قفل نگه دارید، فایل‌های موقت را اجازه دهید و مقدار داده‌های BLOB نگه‌داشته‌شده در حافظه را محدود کنید.

کد زیر در Java نحوه بارگذاری یک ارائه بزرگ (به عنوان مثال ۲ گیگابایت) را نشان می‌دهد:

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
با استفاده از [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked)، فایل منبع تا زمان آزادسازی شیء ارائه قفل می‌ماند. در حین وجود این شیء، فایل منبع را جابه‌جا، بازنویسی یا حذف نکنید.
Aspose.Slides ممکن است محتویات یک جریان ورودی را در حین بارگذاری کپی کند. برای ارائه‌های بزرگ، مسیر فایل عموماً کارآمدتر از یک جریان است. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه به صفحه [Manage BLOBs](/slides/fa/java/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

متد [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) یک پیاده‌سازی از [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iresourceloadingcallback/) را می‌پذیرد. این بازگردانی می‌تواند داده‌های جایگزین فراهم کند، منبعی را تغییر مسیر دهد، از لودر پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این مورد زمانی مفید است که ارائه‌ها شامل تصاویر خارجی باشند که باید مطابق قوانین امنیتی یا ذخیره‌سازی خاص برنامه حل شوند.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **بارگذاری ارائه‌ها بدون اشیای باینری جاسازی‌شده**

یک ارائه ممکن است شامل داده‌های باینری جاسازی‌شده باشد که برنامه نیازی به آن ندارد یا نمی‌خواهد آنها را نگه دارد. مثال‌ها شامل:

- پروژه‌های VBA که از طریق [IPresentation.getVbaProject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getVbaProject--) در دسترس هستند؛
- داده‌های OLE جاسازی‌شده که از طریق [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) در دسترس هستند؛
- داده‌های کنترل ActiveX که از طریق [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) در دسترس هستند.

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) را روی `true` تنظیم کنید تا این داده‌های باینری در هنگام بارگذاری حذف شوند. ارائه بارگذاری‌شده را ذخیره کنید تا نتیجه پاک‌سازی شده حفظ شود.

این گزینه خطر مواجهه با بارگذاری‌های ناخواسته جاسازی‌شده را کاهش می‌دهد، اما یک سیستم کامل تشخیص بدافزار یا پاک‌سازی محتوا نیست.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

Aspose.Slides در هنگام بارگذاری استثناهای تجزیه یا قالب را پرتاب می‌کند. این شکست را جدا از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند دلیل را دقیقاً گزارش دهد.

**اگر قلم‌های لازم موجود نباشند چه می‌شود؟**

ارائه می‌تواند هنوز بارگذاری شود، اما رندرینگ و خروجی ممکن است قلم‌ها را جایگزین کند. می‌توانید [پیکربندی جایگزینی قلم](/slides/fa/java/font-substitution/) یا [ارائه قلم‌های سفارشی](/slides/fa/java/custom-font/) را انجام دهید تا خروجی پیش‌بینی‌پذیرتر باشد.

**آیا بارگذاری یک ارائه، رسانه‌های جاسازی‌شده آن را نیز بارگذاری می‌کند؟**

صوت و ویدئوهای جاسازی‌شده از طریق مدل شیء ارائه در دسترس می‌شوند. منابع خارجی بر اساس رفتار تنظیم‌شده بارگذاری منابع حل می‌شوند و در صورت عدم دسترسی به مکان‌های آنها ممکن است در دسترس نباشند.