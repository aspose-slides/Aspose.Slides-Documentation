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
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در C# باز کنید، رمزهای عبور باز کردن را تهیه کنید، بارگذاری منابع را کنترل کنید و با Aspose.Slides برای .NET مصرف حافظه را کاهش دهید."
---
## **مقدمه**

[Aspose.Slides for .NET](https://products.aspose.com/slides/fa/net/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در فرمت اصلی یا فرمت پشتیبانی‌شده دیگری ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) سفارشی شود. به عنوان مثال، می‌توانید رمز عبور باز کردن را ارائه دهید، اشیاء باینری بزرگ را خارج از حافظه مدیریت‌شده نگه دارید، منابع خارجی را کنترل کنید یا داده‌های باینری جاسازی‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازنده [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بدهید. پس از استفاده، ارائه را Dispose کنید تا دسته‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال C# زیر نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را دریافت کنید:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **باز کردن ارائه‌های با رمز عبور**

یک رمز عبور باز کردن، محتوای ارائه را رمزنگاری می‌کند. برای بارگذاری کامل ارائه، رمز عبور صحیح را به [LoadOptions.Password](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/password/) اختصاص داده و گزینه‌ها را به سازنده [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بدهید. در صورت عدم وجود یا نادرست بودن رمز عبور، بارگذاری ناموفق می‌شود.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

برای تشخیص، اعتبارسنجی و جریان‌های کار رمز عبور، به [Password-Protect Presentations](/slides/fa/net/password-protected-presentation/) مراجعه کنید. اگر یک ارائه رمزنگاری‌شده عمدا با خواص عمومی سند ذخیره شده باشد، آن خواص بدون نیاز به رمز عبور قابل خواندن هستند؛ ببینید [Manage Presentation Properties](/slides/fa/net/presentation-properties/).

## **باز کردن ارائه‌های بزرگ**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/blobmanagementoptions/) تعیین می‌کند که Aspose.Slides چگونه اشیاء باینری بزرگ مانند تصاویر، صوت و ویدیو را مدیریت می‌کند. می‌توانید فایل منبع را قفل نگه دارید، فایل‌های موقت را اجازه دهید و مقدار داده‌های BLOB نگه‌داشته‌شده در حافظه را محدود کنید.

کد C# زیر نشان می‌دهد چطور یک ارائه بزرگ (مثلاً ۲ گیگابایت) را بارگذاری کنید:

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

{{% alert color="info" title="یادداشت" %}}
با `PresentationLockingBehavior.KeepLocked`، فایل منبع تا زمان آزاد شدن (Dispose) شی `Presentation` قفل می‌ماند. تا زمانی که این شی زنده است، فایل منبع را جابه‌جا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است محتوای یک جریان ورودی را در هنگام بارگذاری کپی کند. برای ارائه‌های بزرگ، مسیر فایل عموماً نسبت به یک جریان کارایی بیشتری دارد. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه، به [Manage BLOBs](/slides/fa/net/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/resourceloadingcallback/) یک پیاده‌سازی از [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/iresourceloadingcallback/) را می‌پذیرد. این callback می‌تواند داده‌های جایگزین فراهم کند، یک منبع را باز yönlend کند، از بارگذار پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این زمانی مفید است که ارائه‌ها شامل تصاویر خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی خاص برنامه حل شوند.

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

## **بارگذاری ارائه‌ها بدون اشیاء باینری جاسازی‌شده**

یک ارائه ممکن است شامل داده‌های باینری جاسازی‌شده باشد که برنامه به آن نیاز ندارد یا نمی‌خواهد آنها را نگه دارد. مثال‌ها عبارتند از:

- پروژه‌های VBA، قابل دسترسی از طریق [IPresentation.VbaProject](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/vbaproject/)؛
- داده‌های OLE جاسازی‌شده، قابل دسترسی از طریق [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/)؛
- داده‌های کنترل ActiveX، قابل دسترسی از طریق [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/fa/net/aspose.slides/icontrol/activexcontrolbinary/)۔

[LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) را به `true` تنظیم کنید تا این داده‌های باینری هنگام بارگذاری حذف شوند. برای حفظ نتیجه پاک‌سازی‌شده، ارائه بارگذاری‌شده را ذخیره کنید.

این گزینه خطر مواجهه با بارگذاری‌های جاسازی‌شده ناخواسته را کاهش می‌دهد، اما یک سیستم کامل تشخیص بدافزار یا پاک‌سازی محتوا نیست.

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

## **پرسش‌های متداول**

**چگونه می‌توانم تشخیص دهم که یک فایل خراب شده و نمی‌توان آن را باز کرد؟**

Aspose.Slides در هنگام بارگذاری یک استثنا مربوط به تجزیه یا قالب پرتاب می‌کند. این شکست را جدا از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند دلیل را به‌دقت گزارش دهد.

**اگر قلم‌های مورد نیاز موجود نباشند چه اتفاقی می‌افتد؟**

ارائه می‌تواند همچنان بارگذاری شود، اما رندرینگ و خروجی ممکن است قلم‌ها را جایگزین کند. می‌توانید [configure font substitution](/slides/fa/net/font-substitution/) یا [provide custom fonts](/slides/fa/net/custom-font/) را انجام دهید تا خروجی پیش‌بینی‌پذیرتر باشد.

**آیا بارگذاری یک ارائه همچنین رسانه‌های جاسازی‌شده آن را بارگذاری می‌کند؟**

صدا و ویدیوهای جاسازی‌شده از طریق مدل شیء ارائه در دسترس می‌شوند. منابع خارجی بر اساس رفتار پیکربندی‌شده بارگذاری منابع حل می‌شوند و ممکن است در صورتی که مکان‌های آنها قابل دسترسی نباشد، در دسترس نباشند.