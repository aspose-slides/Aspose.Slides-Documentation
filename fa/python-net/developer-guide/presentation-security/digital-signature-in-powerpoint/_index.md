---
title: افزودن امضای دیجیتال به ارائه‌ها با پایتون
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/python-net/digital-signature-in-powerpoint/
keywords:
- امضای دیجیتال
- گواهی دیجیتال
- مرجع گواهی
- گواهی PFX
- پاورپوینت
- سند باز
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه فایل‌های پاورپوینت و OpenDocument را با Aspose.Slides برای پایتون از طریق .NET به صورت دیجیتالی امضا کنید. اسلایدهای خود را در عرض چند ثانیه با مثال‌های کد واضح ایمن کنید."
---
## **مقدمه**

**گواهی دیجیتال** برای ایجاد یک ارائه پاورپوینت با حفاظت رمز عبور استفاده می‌شود و به‌عنوان ساخته‌شده توسط سازمان یا شخص خاصی علامت‌گذاری می‑گردد. گواهی دیجیتال می‌تواند از طریق تماس با یک سازمان معتبر ‑ یک مرجع گواهی ‑ به دست آید. پس از نصب گواهی دیجیتال در سیستم، می‌توان از آن برای افزودن امضای دیجیتال به ارائه از طریق File → Info → Protect Presentation استفاده کرد:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

ممکن است ارائه بیش از یک امضای دیجیتال داشته باشد. پس از افزودن امضای دیجیتال به ارائه، پیام خاصی در پاورپوینت ظاهر می‌شود:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

برای امضای ارائه یا بررسی اصالت امضای ارائه، **Aspose.Slides API** کلاس‌های [**DigitalSignature**](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/) ، [**DigitalSignatureCollection**](https://reference.aspose.com/slides/fa/python-net/aspose.slides/DigitalSignatureCollection/) و خصوصیت [**Presentation.digital_signatures**](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/digital_signatures/) را فراهم می‌کند. در حال حاضر، امضای دیجیتال فقط برای قالب PPTX پشتیبانی می‌شود.

## **افزودن امضای دیجیتال از گواهی PFX**

نمونه کد زیر نشان می‌دهد چگونه امضای دیجیتال را از یک گواهی PFX اضافه کنید:

1. فایل PFX را باز کنید و رمز عبور PFX را به شیء [**DigitalSignature**](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/) سپارید.  
1. امضای ایجاد شده را به شیء ارائه اضافه کنید.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # ایجاد شی DigitalSignature با فایل PFX و رمز عبور PFX 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # افزودن توضیح جدید به امضای دیجیتال
    signature.comments = "Aspose.Slides digital signing test."

    # افزودن امضای دیجیتال به ارائه
    pres.digital_signatures.add(signature)

    # ذخیره ارائه
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

اکنون می‌توانید بررسی کنید که آیا ارائه به‌صورت دیجیتالی امضا شده است و دست‌نخورده باقی مانده است:

```py
# باز کردن ارائه
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # بررسی اعتبار تمام امضای دیجیتال
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **سوالات متداول**

**آیا می‌توانم امضاهای موجود را از یک فایل حذف کنم؟**

بله. مجموعه امضای دیجیتال از [حذف آیتم‌های جداگانه](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignaturecollection/remove_at/) و [پاک‌سازی کامل آن](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignaturecollection/clear/) پشتیبانی می‌کند؛ پس از ذخیره‌سازی فایل، ارائه بدون هیچ امضایی خواهد بود.

**آیا پس از امضا کردن فایل به حالت «فقط‑خواندنی» تبدیل می‌شود؟**

خیر. یک امضا یکپارچگی و نویسندگی را حفظ می‌کند اما ویرایش را مسدود نمی‌سازد. برای محدود کردن ویرایش، می‌توانید آن را با «فقط‑خواندنی» یا رمز عبور ترکیب کنید [/slides/fa/python-net/password-protected-presentation/].

**آیا امضا در نسخه‌های مختلف پاورپوینت به‌درستی نمایش داده می‌شود؟**

امضا برای کانتینر OOXML (PPTX) ایجاد می‌شود. نسخه‌های مدرن پاورپوینت که از امضاهای OOXML پشتیبانی می‌کنند، وضعیت این امضاها را به‌درستی نمایش می‌دهند.