---
title: افزودن امضاهای دیجیتال به ارائه‌ها در .NET
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/net/digital-signature-in-powerpoint/
keywords:
- امضای دیجیتال
- گواهی دیجیتال
- مرجع صدور گواهی
- گواهی PFX
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه فایل‌های PowerPoint و OpenDocument را با Aspose.Slides برای .NET به صورت دیجیتال امضا کنید. اسلایدهای خود را در چند ثانیه با مثال‌های کد واضح امن کنید."
---
## **مقدمه**

**گواهی دیجیتال** برای ایجاد یک ارائه پاورپوینت محافظت‌شده با رمز عبور استفاده می‌شود که به عنوان ساخته‌شده توسط یک سازمان یا شخص خاص علامت‌گذاری شده است. گواهی دیجیتال می‌تواند با تماس با یک سازمان مجاز – یک مرجع صدور گواهی – به دست آید. پس از نصب گواهی دیجیتال در سیستم، می‌توان از آن برای افزودن یک امضای دیجیتال به ارائه از طریق File -> Info -> Protect Presentation استفاده کرد:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

ارائه ممکن است بیش از یک امضای دیجیتال داشته باشد. پس از افزودن امضای دیجیتال به ارائه، پیغام خاصی در پاورپوینت نمایش داده می‌شود:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

برای امضای ارائه یا بررسی اصالت امضاهای ارائه، **Aspose.Slides API** رابط‌های [**IDigitalSignature**](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignature)، [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/fa/net/aspose.slides/IDigitalSignatureCollection) و[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/properties/digitalsignatures) را فراهم می‌کند. در حال حاضر، امضاهای دیجیتال فقط برای قالب PPTX پشتیبانی می‌شوند.

## **افزودن امضای دیجیتال از یک گواهی PFX**

نمونه کد زیر نحوه افزودن امضای دیجیتال از یک گواهی PFX را نشان می‌دهد:

1. فایل PFX را باز کنید و رمز عبور PFX را به شیء [**DigitalSignature**](https://reference.aspose.com/slides/fa/net/aspose.slides/digitalsignature) عبور دهید.  
1. امضای ایجادشده را به شیء ارائه اضافه کنید.

```c#
using (Presentation pres = new Presentation())
{
    // ایجاد شی DigitalSignature با فایل PFX و رمز عبور PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // کامنت امضای دیجیتال جدید 
    signature.Comments = "Aspose.Slides digital signing test.";

    // افزودن امضای دیجیتال به ارائه 
    pres.DigitalSignatures.Add(signature);

    // ذخیره‌سازی ارائه 
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```

اکنون می‌توانید بررسی کنید که آیا ارائه به صورت دیجیتالی امضا شده و تغییر نکرده است یا نه:

```c#
 // باز کردن ارائه
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // بررسی معتبر بودن تمام امضاهای دیجیتال
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```

## **پرسش‌های متداول**

**آیا می‌توانم امضاهای موجود را از یک فایل حذف کنم؟**

بله. مجموعه امضاهای دیجیتال از [حذف آیتم‌های منفرد](https://reference.aspose.com/slides/fa/net/aspose.slides/digitalsignaturecollection/removeat/) و [پاک کردن کامل آن](https://reference.aspose.com/slides/fa/net/aspose.slides/digitalsignaturecollection/clear/) پشتیبانی می‌کند؛ پس از ذخیره فایل، ارائه بدون هیچ امضایی خواهد بود.

**آیا پس از امضا شدن فایل به حالت «فقط‌خواندنی» تبدیل می‌شود؟**

خیر. یک امضا یکپارچگی و نویسندگی را حفظ می‌کند اما ویرایش‌ها را مسدود نمی‌کند. برای محدود کردن ویرایش، می‌توانید آن را با ["فقط‌خواندنی" یا یک رمز عبور](/slides/fa/net/password-protected-presentation/) ترکیب کنید.

**آیا امضا به درستی در نسخه‌های مختلف پاورپوینت نمایش داده می‌شود؟**

این امضا برای محفظه OOXML (PPTX) ایجاد شده است. نسخه‌های مدرن پاورپوینت که از امضاهای OOXML پشتیبانی می‌کنند، وضعیت این امضاها را به‌درستی نمایش می‌دهند.