---
title: "باز کردن ارائه‌ها در اندروید"
linktitle: "باز کردن ارائه"
type: docs
weight: 20
url: /fa/androidjava/open-presentation/
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
- "ارائه محافظت‌شده"
- "ارائه بزرگ"
- "منبع خارجی"
- "شیء دودویی"
- "اندروید"
- "جاوا"
- "Aspose.Slides"
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در اندروید باز کنید، رمزهای عبور باز کردن را فراهم کنید، بارگذاری منابع را کنترل کنید و با Aspose.Slides برای اندروید از طریق جاوا مصرف حافظه را کاهش دهید."
---
## **مقدمه**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/fa/androidjava/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگیری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در قالب اصلی یا قالب دیگری که پشتیبانی می‌شود ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/) سفارشی شود. به عنوان مثال، می‌توانید یک رمز عبور باز کردن فراهم کنید، اشیاء دودویی بزرگ را خارج از حافظه heap جاوا نگه دارید، منابع خارجی را کنترل کنید یا داده‌های دودویی توکار را حذف کنید.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازنده [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بدهید. پس از استفاده، ارائه را Dispose کنید تا دسته‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال زیر Java نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را به‌دست آورید:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **باز کردن ارائه‌های دارای رمز عبور**

یک رمز عبور باز کردن محتویات ارائه را رمزنگاری می‌کند. برای بارگذاری کامل ارائه، رمز صحیح را به [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) بدهید و گزینه‌ها را به سازنده [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ارائه دهید. بارگذاری زمانی که رمز عبور موجود نیست یا نادرست باشد شکست می‌خورد.

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

برای تشخیص رمز عبور، اعتبارسنجی و جریان‌های کاری رمزنگاری، به [Password-Protect Presentations](/slides/fa/androidjava/password-protected-presentation/) مراجعه کنید. اگر یک ارائه رمزگذاری‌شده عمداً با ویژگی‌های عمومی سند ذخیره شده باشد، می‌توان این ویژگی‌ها را بدون رمز عبور خواند؛ به [Manage Presentation Properties](/slides/fa/androidjava/presentation-properties/) نگاه کنید.

## **باز کردن ارائه‌های بزرگ**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) گزینه‌هایی را بر می‌گرداند که نحوهٔ مدیریت اشیاء دودویی بزرگ مانند تصاویر، صدا و ویدئو توسط Aspose.Slides را کنترل می‌کند. می‌توانید فایل منبع را قفل بمانید، اجازه استفاده از فایل‌های موقت را بدهید و مقدار داده‌های BLOB نگهداری‌شده در حافظه را محدود کنید.

کد زیر Java نشان می‌دهد چگونه یک ارائه بزرگ (مثلاً ۲ گیگابایت) بارگذاری شود:

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
با [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked)، فایل منبع تا زمانی که نمونهٔ ارائه حذف (disposed) شود، قفل می‌ماند. هنگام زنده بودن آن نمونه، فایل منبع را جابجا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است محتویات یک جریان ورودی را در حین بارگذاری کپی کند. برای ارائه‌های بزرگ، مسیر فایل عموماً کارآمدتر از یک جریان است. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه، به [Manage BLOBs](/slides/fa/androidjava/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) یک پیاده‌سازی از [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iresourceloadingcallback/) را می‌پذیرد. این بازگشت می‌تواند داده‌های جایگزین فراهم کند، یک منبع را بازگرداند، از بارگذار پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این زمانی مفید است که ارائه‌ها شامل تصاویر خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی مخصوص برنامه حل شوند.

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

## **بارگذاری ارائه‌ها بدون اشیاء دودویی توکار**

یک ارائه ممکن است شامل داده‌های دودویی توکار باشد که برنامه نیازی به آن ندارد یا نمی‌خواهد نگه دارد. مثال‌ها شامل:

- پروژه‌های VBA، که از طریق [IPresentation.getVbaProject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) در دسترس هستند؛
- داده‌های توکار OLE، که از طریق [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) در دسترس هستند؛
- داده‌های کنترل ActiveX، که از طریق [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) در دسترس هستند.

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) را به `true` تنظیم کنید تا این داده‌های دودویی هنگام بارگذاری حذف شوند. برای حفظ نتایج پاک‌سازی‌شده، ارائه بارگذاری‌شده را ذخیره کنید.

این گزینه میزان مواجهه با بارهای توکار ناخواسته را کاهش می‌دهد، اما یک سیستم کامل تشخیص بدافزار یا پاک‌سازی محتوا نیست.

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

## **پرسش‌های متداول**

**چگونه می‌توانم تشخیص دهم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

Aspose.Slides در حین بارگذاری یک استثنای تجزیه یا قالب‌‏یابی پرتاب می‌کند. این شکست را جدا از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند دلیل را به‌دقت گزارش دهد.

**اگر قلم‌های مورد نیاز موجود نباشند چه اتفاقی می‌افتد؟**

ارائه هنوز می‌تواند بارگذاری شود، اما رندرسازی و خروجی ممکن است قلم‌ها را جایگزین کند. می‌توانید [configure font substitution](/slides/fa/androidjava/font-substitution/) یا [provide custom fonts](/slides/fa/androidjava/custom-font/) را برای پیش‌بینی‌پذیرتر کردن خروجی تنظیم کنید.

**آیا بارگذاری یک ارائه، رسانه‌های توکار آن را نیز بارگذاری می‌کند؟**

صدا و ویدئوی توکار از طریق مدل شیء ارائه در دسترس می‌شوند. منابع خارجی بر اساس رفتار پیکربندی‌شدهٔ بارگذاری منبع حل می‌شوند و ممکن است در دسترس نباشند اگر مکان‌های آن‌ها قابل دسترسی نباشد.