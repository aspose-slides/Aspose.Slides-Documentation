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
- شی باینری
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در جاوا باز کنید، رمزهای عبور باز کردن را فراهم کنید، بارگذاری منابع را کنترل کنید و با Aspose.Slides برای جاوا مصرف حافظه را کاهش دهید."
---
## **مقدمه**

[Aspose.Slides for Java](https://products.aspose.com/slides/fa/java/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در فرمت اصلی یا فرمت پشتیبانی‌شده دیگری ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) سفارشی شود. به عنوان مثال، می‌توانید رمز عبور باز کردن را فراهم کنید، اشیای بایناری بزرگ را خارج از حافظه heap جاوا نگه دارید، منابع خارجی را کنترل کنید یا داده‌های بایناری جاسازی‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بدهید. پس از استفاده، ارائه را آزاد (Dispose) کنید تا دستگیره‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال زیر در Java نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را به‌دست آورید:

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

یک رمز عبور باز کردن محتویات ارائه را رمزگذاری می‌کند. برای بارگذاری کامل ارائه، رمز عبور صحیح را به [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) بدهید و گزینه‌ها را به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ارائه کنید. اگر رمز عبور موجود نباشد یا نادرست باشد، بارگذاری شکست می‌خورد.

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

برای شناسایی، اعتبارسنجی و جریان‌های کاری رمزگذاری، به [Password-Protect Presentations](/slides/fa/java/password-protected-presentation/) مراجعه کنید. اگر یک ارائه رمزگذاری‌شده عمدتاً با ویژگی‌های عمومی سند ذخیره شده باشد، می‌توان این ویژگی‌ها را بدون رمز عبور خواند؛ به [Manage Presentation Properties](/slides/fa/java/presentation-properties/) نگاه کنید.

## **باز کردن ارائه‌های بزرگ**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) گزینه‌هایی را برمی‌گرداند که نحوهٔ مدیریت اشیای بایناری بزرگ (BLOB) مانند تصاویر، صدا و ویدئو توسط Aspose.Slides را کنترل می‌کند. می‌توانید فایل منبع را قفل نگه دارید، فایل‌های موقت را مجاز کنید و مقدار داده‌های BLOB نگهداری‌شده در حافظه را محدود کنید.

کد زیر در Java نحوه بارگذاری یک ارائه بزرگ (مثلاً ۲ گیگابایت) را نشان می‌دهد:

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
با استفاده از [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked)، فایل منبع تا زمانی که نمونهٔ ارائه آزاد (Dispose) نشود، قفل می‌ماند. هنگام زنده بودن آن نمونه، فایل منبع را جابه‌جا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است محتویات یک جریان ورودی را هنگام بارگذاری کپی کند. برای ارائه‌های بزرگ، مسیربندی فایل به‌طور کلی کارآمدتر از یک جریان است. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه به [Manage BLOBs](/slides/fa/java/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) یک پیاده‌سازی از [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iresourceloadingcallback/) را می‌پذیرد. این callback می‌تواند داده‌های جایگزین فراهم کند، منبعی را باز مسیردهی کند، از بارگذار پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این هنگامیکه ارائه‌ها شامل تصاویر خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی خاص برنامه حل شوند، مفید است.

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

## **بارگذاری ارائه‌ها بدون اشیای بایناری جاسازی‌شده**

یک ارائه ممکن است داده‌های بایناری جاسازی‌شده‌ای داشته باشد که برنامه به آنها نیاز ندارد یا نمی‌خواهد آنها را نگه دارد. نمونه‌ها عبارتند از:

- پروژه‌های VBA، که از طریق [IPresentation.getVbaProject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getVbaProject--) در دسترس هستند؛
- داده‌های OLE جاسازی‌شده، که از طریق [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) در دسترس هستند؛
- داده‌های کنترل ActiveX، که از طریق [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) در دسترس هستند.

برای حذف این داده‌های بایناری هنگام بارگذاری، [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) را روی `true` تنظیم کنید. پس از بارگذاری، ارائه را ذخیره کنید تا نتیجهٔ پاک‌سازی‌شده حفظ شود.

این گزینه معرض حملات مخرب جاسازی‌شده ناخواسته را کاهش می‌دهد، اما یک سامانهٔ کامل کشف بدافزار یا پاک‌سازی محتوا نیست.

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

**چگونه می‌توانم تشخیص دهم که یک فایل خراب است و نمی‌تواند باز شود؟**

Aspose.Slides هنگام بارگذاری یک استثنای تجزیه یا فرمت پرتاب می‌کند. این شکست را جدا از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند دلیل را به‌دقت گزارش دهد.

**اگر فونت‌های مورد نیاز موجود نباشند چه می‌شود؟**

ارائه همچنان می‌تواند بارگذاری شود، اما رندرینگ و خروجی ممکن است فونت‌ها را جایگزین کند. می‌توانید [configure font substitution](/slides/fa/java/font-substitution/) یا [provide custom fonts](/slides/fa/java/custom-font/) را برای پیش‌بینی بهتر خروجی تنظیم کنید.

**آیا بارگذاری یک ارائه همچنین رسانه‌های جاسازی‌شده آن را بارگذاری می‌کند؟**

صوت و ویدئوی جاسازی‌شده از طریق مدل شیء ارائه در دسترس می‌شوند. منابع خارجی بر اساس رفتار پیکربندی‌شدهٔ بارگذاری منابع حل می‌شوند و ممکن است در صورتی که مکان‌هایشان قابل دسترسی نباشد، در دسترس نباشند.