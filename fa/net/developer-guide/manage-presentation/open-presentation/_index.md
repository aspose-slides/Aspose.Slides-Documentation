---
title: باز کردن ارائه‌ها در .NET
linktitle: باز کردن ارائه
type: docs
weight: 20
url: /fa/net/open-presentation/
keywords:
- باز کردن PowerPoint
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
- .NET
- C#
- Aspose.Slides
description: "چگونگی باز کردن ارائه‌های PowerPoint و OpenDocument در C# را بیاموزید، رمزهای عبور بازکردن را ارائه دهید، بارگذاری منابع را کنترل کنید و با Aspose.Slides برای .NET مصرف حافظه را کاهش دهید."
---
## **مقدمه**

Aspose.Slides for .NET می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در فرمت اصلی یا یک فرمت دیگر پشتیبانی‌شده ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس LoadOptions سفارشی شود. به عنوان مثال، می‌توانید یک رمز عبور باز کردن ارائه دهید، اشیای بزرگ باینری را خارج از حافظه مدیریت‌شده نگه دارید، منابع خارجی را کنترل کنید یا داده‌های باینری جاسازی‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

پس از بارگذاری یک فایل یا جریان، می‌توانید [تشخیص قالب اصلی ارائه](/slides/fa/net/detect-presentation-source-format/) را برای انتخاب نحوه پردازش آن توسط برنامه خود انجام دهید.

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازنده Presentation پاس کنید. پس از استفاده، ارائه را آزاد (Dispose) کنید تا دستگیره‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال زیر C# نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را به دست آورید:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **باز کردن ارائه‌های دارای رمز عبور**

یک رمز عبور بازکردن محتوای ارائه را رمزنگاری می‌کند. برای بارگذاری کامل ارائه، رمز صحیح را به LoadOptions.Password اختصاص دهید و گزینه‌ها را به سازنده Presentation پاس کنید. بارگذاری زمانی که رمز عبور موجود نباشد یا نادرست باشد، شکست می‌گیرد.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

برای شناسایی رمز عبور، اعتبارسنجی و جریان‌های کار رمزنگاری، به [Password-Protect Presentations](/slides/fa/net/password-protected-presentation/) مراجعه کنید. اگر یک ارائه رمزگذاری‌شده عمداً با ویژگی‌های عمومی سند ذخیره شده باشد، آن ویژگی‌ها بدون نیاز به رمز عبور قابل خواندن هستند؛ به [Manage Presentation Properties](/slides/fa/net/presentation-properties/) نگاه کنید.

## **باز کردن ارائه‌های بزرگ**

[LoadOptions.BlobManagementOptions] کنترل می‌کند که Aspose.Slides چگونه اشیای باینری بزرگ مانند تصاویر، صوت و ویدیو را مدیریت می‌کند. می‌توانید فایل منبع را قفل نگه دارید، فایل‌های موقت را مجاز کنید و مقدار داده‌های BLOB نگهداری‌شده در حافظه را محدود کنید.

کد زیر C# نشان می‌دهد چگونه یک ارائه بزرگ (به عنوان مثال ۲ گیگابایت) را بارگذاری کنید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
با `PresentationLockingBehavior.KeepLocked`، فایل منبع تا زمانی که آبجکت `Presentation` آزاد (Dispose) شود، قفل می‌ماند. تا زمانی که این شیء زنده است، فایل منبع را جابه‌جا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است محتوای یک جریان ورودی را هنگام بارگذاری کپی کند. برای ارائه‌های بزرگ، مسیر فایل عموماً کارآمدتر از یک جریان است. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه به [Manage BLOBs](/slides/fa/net/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

[LoadOptions.ResourceLoadingCallback] یک پیاده‌سازی IResourceLoadingCallback را می‌پذیرد. این بازگردانی (callback) می‌تواند داده جایگزین فراهم کند، منبعی را تغییر مسیر دهد، از لودر پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این در مواقعی مفید است که ارائه‌ها شامل تصاویر خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی خاص برنامه حل شوند.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **بارگذاری ارائه‌ها بدون اشیای باینری جاسازی‌شده**

یک ارائه ممکن است شامل داده‌های باینری جاسازی‌شده باشد که برنامه نیازی به آن ندارد یا نمی‌خواهد نگه دارد. مثال‌ها شامل:

- پروژه‌های VBA، که از طریق IPresentation.VbaProject در دسترس هستند؛
- داده‌های OLE جاسازی‌شده، که از طریق IOleEmbeddedDataInfo.EmbeddedFileData در دسترس هستند؛
- داده‌های کنترل ActiveX، که از طریق IControl.ActiveXControlBinary در دسترس هستند.

با تنظیم LoadOptions.DeleteEmbeddedBinaryObjects بر روی `true` این داده‌های باینری هنگام بارگذاری حذف می‌شوند. برای حفظ نتیجه پاک‌سازی‌شده، ارائه بارگذاری‌شده را ذخیره کنید.

این گزینه خطر مواجهه با بارهای جاسازی‌شده ناخواسته را کاهش می‌دهد، اما یک سیستم کامل برای شناسایی بدافزار یا پاک‌سازی محتوا نیست.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **سئوالات متداول**

**چگونه می‌توانم تشخیص دهم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

Aspose.Slides هنگام بارگذاری یک استثنای تجزیه یا قالب‌بندی می‌اندازد. این شکست را جدا از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند دلیل را به‌دقت گزارش دهد.

**اگر قلم‌های مورد نیاز موجود نباشند چه می‌شود؟**

ارائه همچنان می‌تواند بارگذاری شود، اما رندر و صادرات ممکن است قلم‌ها را جایگزین کند. می‌توانید [پیکربندی جایگزینی قلم](/slides/fa/net/font-substitution/) یا [ارائه قلم‌های سفارشی](/slides/fa/net/custom-font/) را تنظیم کنید تا خروجی پیش‌بینی‌پذیرتر باشد.

**آیا بارگذاری یک ارائه همچنین رسانه‌های جاسازی‌شده آن را بارگذاری می‌کند؟**

صدا و ویدیوهای جاسازی‌شده از طریق مدل شیء ارائه در دسترس می‌شوند. منابع خارجی بر اساس رفتار پیکربندی‌شده بارگذاری منابع حل می‌شوند و ممکن است در صورت عدم دسترسی به مکان‌های آن‌ها در دسترس نباشند.