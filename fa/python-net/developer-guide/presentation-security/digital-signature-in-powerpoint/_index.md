---
title: "افزودن امضاهای دیجیتال به ارائه‌ها در پایتون"
linktitle: "امضای دیجیتال"
type: docs
weight: 10
url: /fa/python-net/digital-signature-in-powerpoint/
keywords:
- "امضای دیجیتال"
- "گواهی دیجیتال"
- "مرجع صدور گواهی"
- "گواهی PFX"
- "PKCS#12"
- "اعتبارسنجی امضا"
- "PowerPoint"
- "PPTX"
- "امنیت ارائه"
- "پایتون"
- "Aspose.Slides"
description: "یاد بگیرید چگونه ارائه‌های PPTX موجود را با گواهی‌های PFX امضا کنید و از Aspose.Slides برای پایتون از طریق .NET برای اعتبارسنجی یا حذف امضاهای دیجیتال استفاده کنید."
---
## **بررسی کلی**

یک امضای دیجیتال به گیرنده کمک می‌کند تا تعیین کند که چه کسی یک ارائه را امضا کرده است و آیا محتوای امضاشده تغییر کرده است. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- یک **گواهی دیجیتال** اعتبارنامه‌ای الکترونیکی است که یک هویت را با کلید عمومی مربوط می‌سازد. یک مرجع صدور گواهی (CA) مورد اعتماد می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند برای گردش کارهای داخلی از گواهی خودامضا استفاده کند.
- یک **امضای دیجیتال** از محتوای ارائه و کلید خصوصی دارنده گواهی ایجاد می‌شود. سپس می‌توان با استفاده از کلید عمومی گواهی امضا را تأیید کرد. یک امضا شواهدی از منبع و یکپارچگی فراهم می‌کند؛ اما ارائه را رمزنگاری نمی‌کند.
- **حفاظت با رمز عبور** کنترل می‌کند که آیا کاربر بتواند ارائه را باز یا ویرایش کند. این مورد جدا از امضای دیجیتال است و در [ارائه‌های محافظت‌شده با رمز عبور](/slides/fa/python-net/password-protected-presentation/) شرح داده شده است.

PowerPoint فرمان **Add a Digital Signature** را زیر **File > Info > Protect Presentation** فراهم می‌کند.

![منوی Protect Presentation در PowerPoint با گزینه Add a Digital Signature برجسته شده](add-digital-signature-in-powerpoint.png)

پس از باز شدن یک ارائه امضاشده، PowerPoint می‌تواند اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint که می‌گوید ارائه شامل امضاهای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [Presentation.digital_signatures](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/digital_signatures/)، یک [DigitalSignatureCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignaturecollection/) که آیتم‌های آن اشیای [DigitalSignature](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/) هستند، در دسترس قرار می‌دهد. یک ارائه می‌تواند شامل چندین امضا باشد.

## **درک گواهی‌های PFX و رمزهای عبور**

یک فایل PFX، که همچنین به عنوان فایل PKCS#12 شناخته می‌شود و به‌طور معمول پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیره گواهی باشد. کلید خصوصی همان چیزی است که به دارنده اجازه می‌دهد یک امضا ایجاد کند. گواهی بدون دسترسی به کلید خصوصی نمی‌تواند برای امضای ارائه استفاده شود.

رمز عبور PFX بسته گواهی و کلید خصوصی را محافظت می‌کند. این **رمز عبور** برای باز یا ویرایش ارائه نیست. فایل‌های PFX یا رمزهای عبور آن‌ها را به مخزن منبع تحویل ندهید. در محیط تولید، دسترسی به فایل گواهی را محدود کنید و رمز عبور آن را از یک مخزن رمز یا منبع پیکربندی محافظت‌شده دریافت کنید. نمونه‌های زیر فقط برای جلوگیری از جاسازی رمز عبور در کد، از یک متغیر محیطی استفاده می‌کنند.

## **Add a Digital Signature to a Presentation**

برای امضای یک گردش کار واقعی، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/) از یک گواهی PFX و رمز عبور آن ایجاد کنید، امضا را به مجموعه امضای ارائه اضافه کنید و در یک فایل PPTX ذخیره کنید.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

ذخیره نتیجه با نام جدید، فایل منبع بدون امضا را حفظ می‌کند. مقدار [DigitalSignature.comments](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/comments/) هدف امضا را توضیح می‌دهد؛ این یک کنترل امنیتی نیست.

## **Validate Digital Signatures**

هنگامی که یک فایل PPTX امضاشده را بارگذاری می‌کنید، هر آیتم در [Presentation.digital_signatures](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/digital_signatures/) را بررسی کنید. ویژگی [DigitalSignature.is_valid](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/is_valid/) نشان می‌دهد که آیا امضای تعبیه‌شده برای محتوای فعلی ارائه معتبر است یا خیر.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

نتیجه نامعتبر معمولاً به این معنی است که محتویات ارائه امضاشده یا داده‌های امضا پس از امضا تغییر کرده‌اند، یا فایل خراب شده است. حذف تمام امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین بررسی فقط اعتبار آیتم‌ها کافی نیست: یک گردش کار حساس به امنیت باید همچنین تعداد مورد انتظار امضاها و هویت امضاکنندگان مورد انتظار را تأیید کند.

ویژگی [DigitalSignature.certificate](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/certificate/) داده‌های گواهی را به‌صورت یک آرایه بایت ارائه می‌دهد. مثال اثر انگشت SHA-256 آن را محاسبه می‌کند تا برنامه بتواند آن را با اثر انگشت گواهی امضاکننده مورد انتظار مقایسه کند.

این نتیجه اعتبار نباید به‌عنوان تصمیم کامل اعتماد به گواهی درنظر گرفته شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز داشته باشد زنجیره گواهی X.509 را ساخت و اعتبارسنجی کند، تاریخ‌های اعتبار گواهی و وضعیت لغو را بررسی کند، موضوع یا اثر انگشت مورد انتظار را تأیید کند، استفاده از کلید را بررسی کند و یک زمان‌سند مورد اعتماد را ارزیابی کند. مقدار [DigitalSignature.sign_time](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/sign_time/) به‌تنهایی مدارکی از یک مرجع زمان‌سند معتبر نیست.

## **Remove Digital Signatures**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضاشده را بارگذاری می‌کند، تمام امضاها را با [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignaturecollection/clear/) حذف می‌کند و یک نسخه بدون امضا ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

برای حذف فقط یک امضا، متد [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignaturecollection/remove_at/) را با اندیس صفر‑پایه‌اش صدا بزنید. مگر اینکه حذف فایل اصلی امضاشده یک بخش صریح از گردش کار شما باشد، به فایل جدیدی ذخیره کنید.

## **Editing and Format Considerations**

- یک امضا باعث نمی‌شود ارائه فقط‑خواندنی شود. کاربران و برنامه‌ها همچنان می‌توانند فایل را ویرایش کنند، اما تغییر در محتوای امضاشده معمولاً امضای موجود را نامعتبر می‌سازد.
- تمام ویرایش‌های موردنظر را پیش از امضا انجام دهید. اگر نیازی به تغییر ارائه باشد، نسخه اصلاح‌شده را ذخیره کنید و آن بازباری را دوباره امضا کنید.
- خروجی نهایی را در قالب PPTX حفظ کنید. تبدیل یک ارائه امضاشده به قالب دیگری امضای اصلی PPTX را به‌عنوان امضای معتبر برای فایل تبدیل‌شده منتقل نمی‌کند.
- کلید خصوصی گواهی را حساسی تلقی کنید. هرکسی که کلید خصوصی و رمز عبور آن را به دست آورد، می‌تواند امضاهایی ایجاد کند که گویی از طرف دارنده گواهی هستند.
- در صورت نیاز سیاست نگهداری اسناد، منبع بدون امضا یا یک کپی کنترل‌شده دیگر را نگه دارید.

## **FAQ**

**آیا امضای دیجیتال ارائه را رمزنگاری می‌کند؟**

نه. امضای دیجیتال شواهدی درباره منبع و یکپارچگی فراهم می‌کند، اما محتوای ارائه تا زمان اعمال رمزنگاری جداگانه قابل خواندن باقی می‌ماند. هنگامی که دسترسی به محتوا باید محدود شود، از [حفاظت با رمز عبور](/slides/fa/python-net/password-protected-presentation/) استفاده کنید.

**آیا رمز عبور PFX همان رمز عبور ارائه است؟**

نه. رمز عبور PFX کلید خصوصی ذخیره‌شده در بسته گواهی را باز می‌کند. این رمز عبور کنترل دسترسی به باز کردن یا ویرایش فایل PPTX را انجام نمی‌دهد.

**آیا می‌توانم از گواهی خودامضا استفاده کنم؟**

از نظر فنی می‌توانید گواهی خودامضا را استفاده کنید به‌شرطی که شامل یک کلید خصوصی قابل دسترس باشد. دریافت‌کنندگان به‌طور خودکار به آن اعتماد نخواهند کرد مگر این که گواهی به‌صراحت به محیط مورد اعتماد آن‌ها افزوده شده باشد. گردش کارهای عمومی یا میان‌سازمان معمولاً از گواهی صادرشده توسط یک CA مورد اعتماد استفاده می‌کنند.

**چه چیزی باعث عدم اعتبار امضا می‌شود؟**

تغییر محتوای ارائه امضاشده یا داده‌های امضا پس از امضا می‌تواند امضا را نامعتبر کند. خرابی فایل نیز می‌تواند سبب شکست اعتبارسنجی شود. اگر تمام امضاها حذف شوند، ارائه بدون امضا است نه اینکه حاوی امضای نامعتبر باشد.

**آیا امضای معتبر به این معناست که باید به امضاکننده اعتماد کرد؟**

خود امضای معتبر کافی نیست. یک تصمیم جداگانه درباره اعتماد به امضاکننده باید گرفته شود. سیاست اعتبارسنجی در تولید باید زنجیره گواهی، دورهٔ اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هر نیاز به زمان‌سند مورد اعتماد را نیز بررسی کند.

**اگر گواهی منقضی شود چه اتفاقی می‌افتد؟**

انقضای گواهی محتوای بایت‌های ارائه را تغییر نمی‌دهد، اما ارزیابی اعتماد به گواهی را تحت تأثیر قرار می‌دهد. اینکه آیا امضا همچنان قابل قبول باشد بستگی به سیاست شما و این دارد که آیا یک زمان‌سند مورد اعتماد نشان می‌دهد امضا در زمان معتبر بودن گواهی انجام شده است یا نه. فقط به زمان امضا نمایش‌داده‌شده به‌عنوان زمان‌سند مورد اعتماد تکیه نکنید.

**آیا می‌توان یک ارائه امضاشده را ویرایش کرد؟**

بله. امضا فایل را قفل نمی‌کند. ویرایش محتوای امضاشده معمولاً امضای موجود را نامعتبر می‌کند، بنابراین ابتدا ارائه را تکمیل کنید و سپس نسخه نهایی را امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. قبل از ذخیره هر امضا را به [Presentation.digital_signatures](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/digital_signatures/) اضافه کنید. هنگام اعتبارسنجی، هر امضا را بررسی کنید و تأیید کنید تمام امضاکنندگان مورد نیاز حضور دارند.

**کدام فرمت‌های ارائه از این عملیات پشتیبانی می‌کنند؟**

Aspose.Slides عملیات امضای دیجیتال توصیف‌شده در اینجا را فقط برای PPTX پشتیبانی می‌کند. فرمت‌های PPT و OpenDocument پشتیبانی نمی‌شوند.

**آیا می‌توانم امضا را حذف کنم بدون اینکه اسلایدها تحت تأثیر قرار گیرند؟**

بله. می‌توانید یک امضا یا تمام مجموعه را حذف کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها باقی می‌ماند، اما فایل ذخیره‌شده دیگر شامل شواهد امضای حذف‌شده نخواهد بود.