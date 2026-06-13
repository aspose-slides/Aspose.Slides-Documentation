---
title: افزودن امضای دیجیتال به ارائه‌ها در جاوا
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/java/digital-signature-in-powerpoint/
keywords:
- امضای دیجیتال
- گواهی دیجیتال
- مرجع صدور گواهی
- گواهی PFX
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه فایل‌های PowerPoint و OpenDocument را با Aspose.Slides برای Java به‌صورت دیجیتالی امضا کنید. اسلایدهای خود را در عرض چند ثانیه با مثال‌های کدی روشن ایمن کنید."
---
## **مقدمه**

**گواهی دیجیتال** برای ایجاد یک ارائهٔ پاورپوینت محافظت‌شده با رمز عبور استفاده می‌شود که به عنوان ساخته‌شده توسط یک سازمان یا فرد خاص علامت‌گذاری شده است. گواهی دیجیتال می‌تواند با تماس با یک سازمان معتبر – مرجع صدور گواهی – دریافت شود. پس از نصب گواهی دیجیتال بر روی سیستم، می‌توان از آن برای افزودن یک امضای دیجیتال به ارائه از طریق File -> Info -> Protect Presentation استفاده کرد:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

ارائه می‌تواند بیش از یک امضای دیجیتال داشته باشد. پس از افزودن امضای دیجیتال به ارائه، یک پیام خاص در PowerPoint نمایش داده می‌شود:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

برای امضای ارائه یا بررسی اصالت امضاهای ارائه، **Aspose.Slides API** رابط‌های [**IDigitalSignature**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IDigitalSignature) و [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IDigitalSignatureCollection) و متد [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentation#getDigitalSignatures--) را فراهم می‌کند. در حال حاضر، امضای دیجیتال فقط برای فرمت PPTX پشتیبانی می‌شود.

## **افزودن امضای دیجیتال از گواهی PFX**

نمونه کد زیر نحوه افزودن امضای دیجیتال از یک گواهی PFX را نشان می‌دهد:

1. فایل PFX را باز کنید و رمز عبور PFX را به شیء [**DigitalSignature**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/DigitalSignature) پاس دهید.
2. امضای ایجاد شده را به شیء ارائه اضافه کنید.

```java
// باز کردن فایل ارائه
Presentation pres = new Presentation();
try {
    // ایجاد شی DigitalSignature با فایل PFX و رمز عبور PFX
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // توضیح امضای دیجیتال جدید
    signature.setComments("Aspose.Slides digital signing test.");

    // افزودن امضای دیجیتال به ارائه
    pres.getDigitalSignatures().add(signature);

    // ذخیره‌سازی ارائه
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

اکنون می‌توانید بررسی کنید که آیا ارائه دیجیتالی امضا شده است و تغییر نیافته است:

```java
// باز کردن ارائه
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // بررسی اینکه آیا همه امضای دیجیتال معتبر هستند
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

## **سؤالات متداول**

**آیا می‌توانم امضاهای موجود را از یک فایل حذف کنم؟**

بله. مجموعهٔ امضاهای دیجیتال امکان [حذف موارد جداگانه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) و [پاک‌سازی کامل آن](https://reference.aspose.com/slides/fa/java/com.aspose.slides/digitalsignaturecollection/#clear--) را فراهم می‌کند؛ پس از ذخیرهٔ فایل، ارائه هیچ امضایی نخواهد داشت.

**آیا فایل پس از امضا به حالت «فقط‑خواندنی» تبدیل می‌شود؟**

خیر. یک امضا یکپارچگی و نویسنده‌گی را حفظ می‌کند اما ویرایش‌ها را مسدود نمی‌کند. برای محدود کردن ویرایش، آن را با ["Read-only" or a password](/slides/fa/java/password-protected-presentation/) ترکیب کنید.

**آیا امضا در نسخه‌های مختلف PowerPoint به‌درستی نمایش داده می‌شود؟**

امضا برای کانتینر OOXML (PPTX) ایجاد شده است. نسخه‌های مدرن PowerPoint که از امضاهای OOXML پشتیبانی می‌کنند، وضعیت این امضاها را به‌درستی نمایش می‌دهند.