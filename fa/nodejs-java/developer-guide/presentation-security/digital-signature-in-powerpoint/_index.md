---
title: افزودن امضاهای دیجیتال به ارائه‌ها در JavaScript
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/nodejs-java/digital-signature-in-powerpoint/
keywords:
- امضای دیجیتال
- گواهی دیجیتال
- مرجع صدور گواهی
- گواهی PFX
- پاورپوینت
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "بیاموزید چگونه فایل‌های PowerPoint و OpenDocument را با Aspose.Slides برای Node.js از طریق Java به‌صورت دیجیتال امضا کنید. ارائه‌های خود را در عرض چند ثانیه با مثال‌های کد واضح ایمن کنید."
---
## **مقدمه**

**گواهی دیجیتال** برای ایجاد یک ارائه پاورپوینت محافظت شده با رمز عبور استفاده می‌شود که به‌عنوان ایجاد شده توسط یک سازمان یا شخص خاص علامت‌گذاری شده است. می‌توان گواهی دیجیتال را با تماس با یک سازمان مجاز - یک مرکز صدور گواهی، به‌دست آورد. پس از نصب گواهی دیجیتال در سیستم، می‌توان از آن برای افزودن امضای دیجیتال به ارائه از طریق File -> Info -> Protect Presentation استفاده کرد:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

یک ارائه می‌تواند بیش از یک امضای دیجیتال داشته باشد. پس از افزودن امضای دیجیتال به ارائه، یک پیام ویژه در پاورپوینت نمایش داده می‌شود:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

برای امضای ارائه یا بررسی اصالت امضاهای ارائه، **Aspose.Slides API** کلاس‌های [**DigitalSignature**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/DigitalSignature)، [**DigitalSignatureCollection**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/DigitalSignatureCollection) و متد [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) را فراهم می‌کند. در حال حاضر، امضاهای دیجیتال فقط برای فرمت PPTX پشتیبانی می‌شوند.
## **افزودن امضای دیجیتال از گواهی PFX**
نمونه کد زیر نحوه افزودن امضای دیجیتال از یک گواهی PFX را نشان می‌دهد:

1. پوشه PFX را باز کنید و رمز عبور PFX را به شیء [**DigitalSignature**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/DigitalSignature) پاس دهید.
1. امضای ایجاد شده را به شیء ارائه اضافه کنید.

```javascript
// باز کردن فایل ارائه
var pres = new aspose.slides.Presentation();
try {
    // ایجاد شیء DigitalSignature با فایل PFX و رمز عبور PFX
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // افزودن توضیح به امضای دیجیتال جدید
    signature.setComments("Aspose.Slides digital signing test.");
    // افزودن امضای دیجیتال به ارائه
    pres.getDigitalSignatures().add(signature);
    // ذخیرهٔ ارائه
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

اکنون می‌توان بررسی کرد که آیا ارائه به‌صورت دیجیتال امضا شده است و تغییر نیافته باقی مانده است:

```javascript
// باز کردن ارائه
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // بررسی معتبر بودن تمام امضاهای دیجیتال
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا می‌توانم امضاهای موجود را از یک فایل حذف کنم؟**

بله. مجموعهٔ امضاهای دیجیتال از [حذف موارد جداگانه](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) و [پاک‌سازی کامل آن](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) پشتیبانی می‌کند؛ پس از ذخیرهٔ فایل، ارائه هیچ امضایی نخواهد داشت.

**آیا پس از امضا شدن فایل به حالت «فقط‑خواندنی» تبدیل می‌شود؟**

خیر. امضا یکپارچگی و نویسندگی را حفظ می‌کند اما ویرایش‌ها را مسدود نمی‌سازد. برای محدود کردن ویرایش، می‌توانید آن را با ["«فقط‑خواندنی» یا یک رمز عبور"](/slides/fa/nodejs-java/password-protected-presentation/) ترکیب کنید.

**آیا امضا در نسخه‌های مختلف پاورپوینت به‌درستی نمایش داده می‌شود؟**

امضا برای محفظهٔ OOXML (PPTX) ایجاد شده است. نسخه‌های مدرن پاورپوینت که از امضاهای OOXML پشتیبانی می‌کنند، وضعیت این امضاها را به‌درستی نمایش می‌دهند.