---
title: افزودن امضای دیجیتال به ارائه‌ها در C++
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/cpp/digital-signature-in-powerpoint/
keywords:
- امضای دیجیتال
- گواهی دیجیتال
- مرجع گواهی
- گواهی PFX
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "بیاموزید چگونه با Aspose.Slides برای C++ فایل‌های PowerPoint و OpenDocument را به‌صورت دیجیتال امضا کنید. اسلایدهای خود را در عرض چند ثانیه با مثال‌های کد واضح ایمن کنید."
---
## **مقدمه**

**گواهی دیجیتال** برای ایجاد یک ارائه پاورپوینت محافظت‌شده با رمز عبور استفاده می‌شود که به‌عنوان ایجاد شده توسط یک سازمان یا شخص خاص علامت‌گذاری شده است. گواهی دیجیتال می‌تواند با تماس با یک سازمان مجاز – یک مرجع گواهی دریافت شود. پس از نصب گواهی دیجیتال در سیستم، می‌توان از آن برای افزودن امضای دیجیتال به ارائه از طریق File -> Info -> Protect Presentation استفاده کرد:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

ارائه ممکن است بیش از یک امضای دیجیتال داشته باشد. پس از افزودن امضای دیجیتال به ارائه، پیام ویژه‌ای در پاورپوینت ظاهر می‌شود:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

برای امضای ارائه یا بررسی اعتبار امضای ارائه، **Aspose.Slides API** رابط‌های [**IDigitalSignature**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_digital_signature) ، [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_digital_signature_collection) و روش [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) را فراهم می‌کند. در حال حاضر، امضای دیجیتال فقط برای قالب PPTX پشتیبانی می‌شود.
## **افزودن امضای دیجیتال از گواهی PFX**
نمونه کد زیر نشان می‌دهد چگونه می‌توان امضای دیجیتال را از یک گواهی PFX اضافه کرد:

1. فایل PFX را باز کنید و رمز عبور PFX را به شیء [**DigitalSignature**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.digital_signature) منتقل کنید.
1. امضای ایجاد‌شده را به شیء ارائه اضافه کنید.

``` cpp
auto pres = System::MakeObject<Presentation>();

// ایجاد شی DigitalSignature با فایل PFX و رمز عبور PFX 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// توضیح امضای دیجیتال جدید
signature->set_Comments(u"Aspose.Slides digital signing test.");

// افزودن امضای دیجیتال به ارائه
pres->get_DigitalSignatures()->Add(signature);

// ذخیره ارائه
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

اکنون می‌توان بررسی کرد که آیا ارائه دیجیتالی امضا شده است و تغییر نیافته است:

``` cpp
// باز کردن ارائه
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // بررسی اینکه آیا تمام امضاهای دیجیتال معتبر هستند
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **پرسش‌های متداول**

**آیا می‌توانم امضاهای موجود را از یک فایل حذف کنم؟**

بله. مجموعه امضای دیجیتال از [حذف آیتم‌های جداگانه](https://reference.aspose.com/slides/fa/cpp/aspose.slides/digitalsignaturecollection/removeat/) و [پاک‌سازی کامل آن](https://reference.aspose.com/slides/fa/cpp/aspose.slides/digitalsignaturecollection/clear/) پشتیبانی می‌کند؛ پس از ذخیره‌سازی فایل، ارائه هیچ امضایی نخواهد داشت.

**آیا پس از امضای فایل به حالت «فقط‑خواندنی» تبدیل می‌شود؟**

خیر. امضا یکپارچگی و مولفیت را حفظ می‌کند اما ویرایش‌ها را مسدود نمی‌کند. برای محدود کردن ویرایش، آن را با ["Read-only" یا یک رمز عبور](/slides/fa/cpp/password-protected-presentation/) ترکیب کنید.

**آیا امضا در نسخه‌های مختلف PowerPoint به‌درستی نمایش داده می‌شود؟**

امضا برای محفظه OOXML (PPTX) ایجاد شده است. نسخه‌های مدرن PowerPoint که از امضاهای OOXML پشتیبانی می‌کنند، وضعیت این امضاها را به‌درستی نمایش می‌دهند.