---
title: افزودن امضای دیجیتال به ارائه‌ها در اندروید
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/androidjava/digital-signature-in-powerpoint/
keywords:
- امضای دیجیتال
- گواهی دیجیتال
- مرجع صدور گواهی
- گواهی PFX
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه فایل‌های PowerPoint و OpenDocument را با Aspose.Slides برای اندروید به‌صورت دیجیتالی امضا کنید. اسلایدهای خود را در عرض چند ثانیه با مثال‌های واضح کد Java ایمن کنید."
---
## **مقدمه**

**گواهی دیجیتال** برای ایجاد یک ارائه پاورپوینت محافظت‌شده با رمز عبور استفاده می‌شود که به عنوان ساخته‌شده توسط سازمان یا شخص خاصی علامت‌گذاری شده است. گواهی دیجیتال می‌تواند با تماس با یک سازمان معتبر - مرجع صدور گواهی‌نامه - به‌دست آید. پس از نصب گواهی دیجیتال در سیستم، می‌توان از آن برای افزودن امضای دیجیتال به ارائه از طریق File -> Info -> Protect Presentation استفاده کرد:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

ارائه ممکن است بیش از یک امضای دیجیتال داشته باشد. پس از افزودن امضای دیجیتال به ارائه، یک پیام ویژه در پاورپوینت ظاهر می‌شود:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

برای امضای ارائه یا بررسی صحت امضاهای ارائه، **Aspose.Slides API** رابط‌های [**IDigitalSignature**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IDigitalSignature) ، [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IDigitalSignatureCollection) و متد [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) را فراهم می‌کند. در حال حاضر، امضای دیجیتال فقط برای قالب PPTX پشتیبانی می‌شود.
## **افزودن امضای دیجیتال از گواهی PFX**
نمونه کد زیر نشان می‌دهد چگونه امضای دیجیتال را از یک گواهی PFX اضافه کنید:

1. فایل PFX را باز کنید و رمز عبور PFX را به شیء [**DigitalSignature**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/DigitalSignature) پاس دهید.
1. امضای ایجاد شده را به شیء ارائه اضافه کنید.

```java
// باز کردن فایل ارائه
Presentation pres = new Presentation();
try {
    // ساخت شی DigitalSignature با فایل PFX و رمز عبور PFX
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // نظر به امضای دیجیتال جدید
    signature.setComments("Aspose.Slides digital signing test.");

    // اضافه کردن امضای دیجیتال به ارائه
    pres.getDigitalSignatures().add(signature);

    // ذخیره کردن ارائه
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

اکنون می‌توانید بررسی کنید که آیا ارائه به‌صورت دیجیتالی امضا شده و تغییر نیافته است یا خیر:

```java
// باز کردن ارائه
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // بررسی اینکه آیا همه امضاهای دیجیتال معتبر هستند
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم امضاهای موجود در یک فایل را حذف کنم؟**

بله. مجموعه امضاهای دیجیتال از [حذف آیتم‌های تک‌تکه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) و [پاک‌سازی کامل آن](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--) پشتیبانی می‌کند؛ پس از ذخیره‌سازی فایل، ارائه دیگر امضایی نخواهد داشت.

**آیا پس از امضای فایل به حالت "فقط‑خواندنی" تبدیل می‌شود؟**

خیر. یک امضا، یکپارچگی و نویسندگی را حفظ می‌کند اما ویرایش‌ها را مسدود نمی‌کند. برای محدود کردن ویرایش، آن را با ["فقط‑خواندنی" یا یک رمز عبور](/slides/fa/androidjava/password-protected-presentation/) ترکیب کنید.

**آیا امضا در نسخه‌های مختلف پاورپوینت به‌درستی نمایش داده می‌شود؟**

امضا برای کانتینر OOXML (PPTX) ایجاد شده است. نسخه‌های جدید PowerPoint که از امضاهای OOXML پشتیبانی می‌کنند، وضعیت این امضاها را به‌درستی نمایش می‌دهند.