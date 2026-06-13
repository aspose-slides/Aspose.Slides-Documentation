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
description: "به راحتی ارائه‌های PowerPoint (.pptx, .ppt) و OpenDocument (.odp) را با Aspose.Slides برای .NET باز کنید—سرعت بالا، قابل اعتماد، کامل."
---
## **مقدمه**

فراتر از ایجاد ارائه‌های PowerPoint از ابتدا، Aspose.Slides به شما امکان باز کردن ارائه‌های موجود را نیز می‌دهد. پس از بارگذاری یک ارائه، می‌توانید اطلاعات مربوط به آن را بازیابی کنید، محتوای اسلایدها را ویرایش کنید، اسلایدهای جدید اضافه کنید، اسلایدهای موجود را حذف کنید و کارهای دیگری انجام دهید.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) را ایجاد کنید و مسیر فایل را به سازندهٔ آن پاس دهید.

مثال C# زیر نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را به‌دست آورید:

```cs
// یک نمونه از کلاس Presentation ایجاد کنید و مسیر فایل را به سازنده‌اش پاس دهید.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // تعداد کل اسلایدهای موجود در ارائه را چاپ کنید.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **باز کردن ارائه‌های دارای رمز عبور**

زمانی که نیاز به باز کردن ارائه‌ای دارید که با رمز عبور محافظت شده است، رمز عبور را از طریق ویژگی [Password](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/password/) کلاس [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) به‌عنوان ورودی بدهید تا آن را رمزگشایی و بارگذاری کنید. کد C# زیر این عملیات را نشان می‌دهد:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // عملیات مورد نیاز را بر روی ارائهٔ رمزگشایی‌شده انجام دهید.
}
```

## **باز کردن ارائه‌های بزرگ**

Aspose.Slides گزینه‌هایی ارائه می‌دهد—به‌ویژه ویژگی [BlobManagementOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/blobmanagementoptions/) در کلاس [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/)—تا به شما در بارگذاری ارائه‌های بزرگ کمک کند.

کد C# زیر بارگذاری یک ارائه بزرگ (به عنوان مثال، ۲ گیگابایت) را نشان می‌دهد:

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // رفتار KeepLocked را انتخاب کنید — فایل ارائه برای طول عمر 
        // نمونهٔ Presentation قفل می‌ماند، اما نیازی به بارگذاری در حافظه یا کپی به فایل موقت نیست.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // ارائهٔ بزرگ بارگذاری شده و می‌تواند استفاده شود، در حالی که مصرف حافظه کم می‌ماند.

    // تغییرات موردنظر را در ارائه اعمال کنید.
    presentation.Slides[0].Name = "Large presentation";

    // ارائه را در فایل دیگری ذخیره کنید. در طول این عملیات مصرف حافظه کم می‌ماند.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // این کار را نکنید! یک استثنای I/O پرتاب می‌شود زیرا فایل تا زمان آزاد شدن شیء Presentation قفل باقی می‌ماند.
    File.Delete(filePath);
}

// این کار در اینجا امن است. فایل منبع دیگر توسط شیء Presentation قفل نشده است.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
برای دور زدن برخی محدودیت‌ها هنگام کار با جاری‌ها (streams)، Aspose.Slides ممکن است محتوای جاری را کپی کند. بارگذاری یک ارائه بزرگ از یک جاری باعث کپی شدن ارائه می‌شود و می‌تواند سرعت بارگذاری را کاهش دهد. بنابراین، وقتی نیاز به بارگذاری یک ارائه بزرگ دارید، به‌شدت توصیه می‌کنیم به جای استفاده از جاری، مسیر فایل ارائه را استفاده کنید.

هنگام ایجاد ارائه‌ای که شامل اشیاء بزرگ (ویدئو، صدا، تصاویر با وضوح بالا و غیره) باشد، می‌توانید از [BLOB management](/slides/fa/net/manage-blob/) برای کاهش مصرف حافظه استفاده کنید.
{{%/alert %}}

## **کنترل منابع خارجی**

Aspose.Slides اینترفیس [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/iresourceloadingcallback/) را ارائه می‌دهد که به شما امکان مدیریت منابع خارجی را می‌دهد. کد C# زیر نشان می‌دهد چگونه از اینترفیس `IResourceLoadingCallback` استفاده کنید:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // یک تصویر جانشین بارگیری کنید.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // یک URL جانشین تنظیم کنید.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // تمام تصاویر دیگر را رد کنید.
        return ResourceLoadingAction.Skip;
    }
}
```

## **بارگذاری ارائه‌ها بدون اشیاء باینری تعبیه‌شده**

یک ارائه PowerPoint می‌تواند انواع زیر از اشیاء باینری تعبیه‌شده را داشته باشد:

- پروژه VBA (قابل دسترسی از طریق [IPresentation.VbaProject](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/vbaproject/));
- داده‌های تعبیه‌شدهٔ شیء OLE (قابل دسترسی از طریق [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- داده‌های باینری کنترل ActiveX (قابل دسترسی از طریق [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/fa/net/aspose.slides/icontrol/activexcontrolbinary/)).

با استفاده از ویژگی [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/)، می‌توانید یک ارائه را بدون هیچ‌یک از اشیاء باینری تعبیه‌شده بارگذاری کنید.

این ویژگی برای حذف محتوای باینری احتمالی مخرب مفید است. کد C# زیر نحوهٔ بارگذاری یک ارائه بدون هیچ‌گونه محتوای باینری تعبیه‌شده را نشان می‌دهد:

```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // عملیات مورد نیاز را بر روی ارائه انجام دهید.
}
```

## **سؤالات متداول**

**چگونه می‌توانم بفهمم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

در هنگام بارگذاری، یک استثنای تجزیه/اعتبارسنجی قالب دریافت خواهید کرد. این خطاها معمولاً به ساختار ZIP نامعتبر یا رکوردهای خراب PowerPoint اشاره می‌کنند.

**اگر قلم‌های مورد نیاز هنگام باز کردن موجود نباشند چه اتفاقی می‌افتد؟**

فایل باز خواهد شد، اما در مراحل بعدی [rendering/export](/slides/fa/net/convert-presentation/) ممکن است قلم‌ها جایگزین شوند. برای جلوگیری از این‌مانند، می‌توانید [Configure font substitutions](/slides/fa/net/font-substitution/) یا [add the required fonts](/slides/fa/net/custom-font/) را به محیط زمان اجرا اضافه کنید.

**در مورد رسانه‌های تعبیه‌شده (ویدئو/صدا) هنگام باز کردن چه می‌شود؟**

آنها به‌عنوان منابع ارائه در دسترس قرار می‌گیرند. اگر رسانه‌ها از طریق مسیرهای خارجی ارجاع داده شوند، اطمینان حاصل کنید که این مسیرها در محیط شما قابل دسترسی باشند؛ در غیر این صورت [rendering/export](/slides/fa/net/convert-presentation/) ممکن است رسانه‌ها را حذف کند.