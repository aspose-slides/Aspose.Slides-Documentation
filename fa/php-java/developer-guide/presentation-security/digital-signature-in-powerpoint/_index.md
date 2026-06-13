---
title: افزودن امضاهای دیجیتال به ارائه‌ها در PHP
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/php-java/digital-signature-in-powerpoint/
keywords:
- امضای دیجیتال
- گواهی دیجیتال
- مرجع صدور گواهی
- گواهی PFX
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "چگونه فایل‌های PowerPoint و OpenDocument را با Aspose.Slides برای PHP از طریق Java به‌صورت دیجیتال امضا کنید بیاموزید. اسلایدهای خود را در عرض چند ثانیه با مثال‌های کد واضح امن کنید."
---
## **مقدمه**

گواهی دیجیتال برای ایجاد یک ارائهٔ پاورپوینت محافظت‌شده با رمز عبور استفاده می‌شود که به‌عنوان ساخته‌شده توسط سازمان یا شخص خاصی علامت‌گذاری شده است. می‌توان گواهی دیجیتال را با تماس با یک سازمان معتبر—یک مرجع صدور گواهی—به‌دست آورد. پس از نصب گواهی دیجیتال در سیستم، می‌توان از آن برای افزودن امضای دیجیتال به ارائه از طریق File -> Info -> Protect Presentation استفاده کرد:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

یک ارائه می‌تواند بیش از یک امضای دیجیتال داشته باشد. پس از افزودن امضای دیجیتال به ارائه، پیام ویژه‌ای در PowerPoint نمایش داده می‌شود:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

برای امضای ارائه یا بررسی صحت امضای ارائه‌ها، **Aspose.Slides API** کلاس‌های [**DigitalSignature**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/DigitalSignature)، [**DigitalSignatureCollection**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/DigitalSignatureCollection) و متد [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getDigitalSignatures) را فراهم می‌کند. در حال حاضر، امضای دیجیتال فقط برای فرمت PPTX پشتیبانی می‌شود.

## **افزودن امضای دیجیتال از گواهی PFX**

نمونه کد زیر نمایش می‌دهد که چگونه می‌توان امضای دیجیتال را از یک گواهی PFX اضافه کرد:

1. فایل PFX را باز کنید و رمز عبور PFX را به شیء [**DigitalSignature**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/DigitalSignature) پاس دهید.
2. امضای ایجادشده را به شیء ارائه اضافه کنید.

```php
  # در حال باز کردن فایل ارائه
  $pres = new Presentation();
  try {
    # ایجاد شیء DigitalSignature با فایل PFX و رمز عبور PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # توضیح امضای دیجیتال جدید
    $signature->setComments("Aspose.Slides digital signing test.");
    # افزودن امضای دیجیتال به ارائه
    $pres->getDigitalSignatures()->add($signature);
    # ذخیرهٔ ارائه
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

حال می‌توانید بررسی کنید که آیا ارائه به‌صورت دیجیتال امضا شده است و تغییر نیافته است:

```php
  # باز کردن ارائه
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # بررسی اعتبار تمام امضات دیجیتال
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا می‌توانم امضاهای موجود را از یک فایل حذف کنم؟**

بله. مجموعهٔ امضاهای دیجیتال امکان حذف موارد جداگانه را دارد و می‌تواند به‌طور کامل پاک شود؛ پس از ذخیرهٔ فایل، ارائه دیگر امضا نخواهد داشت.

**آیا پس از امضا شدن فایل به «فقط‑خواندنی» تبدیل می‌شود؟**

خیر. یک امضا یکپارچگی و مالکیت را حفظ می‌کند اما ویرایش‌ها را مسدود نمی‌کند. برای محدود کردن ویرایش، آن را با ["Read-only" یا یک رمز عبور](/slides/fa/php-java/password-protected-presentation/) ترکیب کنید.

**آیا امضا در نسخه‌های مختلف PowerPoint به‌درستی نمایش داده می‌شود؟**

امضا برای کانتینر OOXML (PPTX) ایجاد شده است. نسخه‌های جدید پاورپوینت که از امضای OOXML پشتیبانی می‌کنند، وضعیت این امضاها را به‌درستی نمایش می‌دهند.