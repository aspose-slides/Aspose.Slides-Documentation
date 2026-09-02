---
title: افزودن امضای دیجیتال به ارائه‌ها در پایتون
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/python-net/digital-signature-in-powerpoint/
keywords:
- امضای دیجیتال
- گواهی دیجیتال
- مرجع گواهی
- گواهی PFX
- PKCS#12
- اعتبارسنجی امضا
- PowerPoint
- PPTX
- امنیت ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PPTX موجود را با گواهی‌های PFX امضا کنید و با استفاده از Aspose.Slides برای پایتون از طریق .NET امضاهای دیجیتال را اعتبارسنجی یا حذف کنید."
---
## **نمای کلی**

یک امضای دیجیتال به گیرنده کمک می‌کند تا تعیین کند چه کسی یک ارائه را امضا کرده است و آیا محتوای امضا شده تغییر کرده است. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- یک **گواهی دیجیتال** یک اعتبار الکترونیکی است که یک هویت را با یک کلید عمومی مرتبط می‌کند. یک مرجع گواهی‌نامه معتبر (CA) می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند برای جریان‌های کاری داخلی از یک گواهی خودامضا استفاده کند.
- یک **امضای دیجیتال** از محتوای ارائه و کلید خصوصی دارنده گواهی ساخته می‌شود. سپس می‌توان از کلید عمومی گواهی برای تأیید امضا استفاده کرد. امضا شواهدی از منبع و یکپارچگی فراهم می‌کند؛ آن ارائه را رمزنگاری نمی‌کند.
- **حفاظت با رمز عبور** کنترل می‌کند که آیا کاربر می‌تواند یک ارائه را باز یا ویرایش کند یا خیر. این مورد جدا از امضای دیجیتال است و در [ارائه‌های محافظت‌شده با رمز عبور](/python-net/password-protected-presentation/) توضیح داده شده است.

PowerPoint فرمان **Add a Digital Signature** را در زیر **File > Info > Protect Presentation** ارائه می‌دهد.

![منوی Protect Presentation در PowerPoint که گزینه Add a Digital Signature برجسته شده است](add-digital-signature-in-powerpoint.png)

پس از باز شدن یک ارائه امضا شده، PowerPoint می‌تواند یک اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint که بیان می‌کند ارائه شامل امضای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [Presentation.digital_signatures](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/digital_signatures/)، یک [DigitalSignatureCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignaturecollection/) که آیتم‌های آن اشیای [DigitalSignature](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/) هستند، در دسترس قرار می‌دهد. یک ارائه می‌تواند شامل چندین امضا باشد.

## **درک گواهی‌های PFX و گذرواژه‌ها**

یک فایل PFX، که همچنین به عنوان فایل PKCS#12 شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیره گواهی باشد. کلید خصوصی همان چیزی است که به دارنده اجازه می‌دهد امضا ایجاد کند. گواهی بدون کلید خصوصی قابل دسترسی نمی‌تواند برای امضای یک ارائه استفاده شود.

گذرواژه PFX بسته گواهی و کلید خصوصی را محافظت می‌کند. این **گذرواژه** برای باز کردن یا ویرایش ارائه نیست. فایل‌های PFX یا گذرواژه‌های آنها را به مخزن منبع (source control) تعهد نکنید. در محیط تولید، دسترسی به فایل گواهی را محدود کنید و گذرواژه آن را از یک مخزن مخفی یا منبع پیکربندی محافظت‌شده دیگر دریافت کنید. مثال‌های زیر فقط برای جلوگیری از قرار دادن مستقیم گذرواژه در کد، از یک متغیر محیطی استفاده می‌کنند.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک جریان کاری واقعی ارائه، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/) را از یک گواهی PFX و گذرواژه آن ایجاد کنید، امضا را به مجموعه ارائه اضافه کنید و در یک فایل PPTX ذخیره کنید.

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

ذخیره نتایج با یک نام جدید، فایل منبع بدون امضا را حفظ می‌کند. مقدار [DigitalSignature.comments](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/comments/) هدف امضا را توصیف می‌کند؛ این یک کنترل امنیتی نیست.

## **اعتبارسنجی امضاهای دیجیتال**

هنگامی که یک فایل PPTX امضا شده را بارگذاری می‌کنید، هر آیتم در [Presentation.digital_signatures](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/digital_signatures/) را بررسی کنید. ویژگی [DigitalSignature.is_valid](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/is_valid/) نشان می‌دهد آیا امضای جاسازی‌شده برای محتوای فعلی ارائه معتبر است یا خیر.

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

یک نتیجه نامعتبر معمولاً به این معناست که محتوای ارائه امضا شده یا داده‌های امضا پس از امضا تغییر کرده‌اند، یا فایل آسیب دیده است. حذف تمام امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین تنها بررسی اعتبار آیتم‌ها کافی نیست: یک جریان کاری حساس به امنیت باید همچنین تعداد امضاهای مورد انتظار و هویت‌های امضاکنندگان مورد انتظار را تأیید کند.

ویژگی [DigitalSignature.certificate](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/certificate/) داده‌های گواهی را به‌صورت یک آرایه بایت ارائه می‌دهد. مثال اثر انگشت SHA-256 آن را محاسبه می‌کند تا یک برنامه بتواند آن را با اثر انگشت گواهی امضاکننده مورد انتظار مقایسه کند.

این نتیجه اعتبار نباید به عنوان تصمیم کامل در مورد اعتماد به گواهی در نظر گرفته شود. بسته به سیاست امنیتی شما، برنامه‌تان ممکن است نیاز داشته باشد زنجیره گواهی X.509 را ساخته و اعتبارسنجی کند، تاریخ‌های اعتبار گواهی و وضعیت لغو را بررسی کند، موضوع یا اثر انگشت مورد انتظار را تأیید کند، استفاده از کلید را بررسی کند و یک زمان‌مهر معتبر را ارزیابی کند. مقدار [DigitalSignature.sign_time](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignature/sign_time/) به‌خودی خود شواهدی از یک مرجع زمان‌مهر معتبر نیست.

## **حذف امضاهای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضا شده را بارگذاری می‌کند، تمام امضاها را با [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignaturecollection/clear/) حذف می‌کند و یک نسخه بدون امضا ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

برای حذف تنها یک امضا، [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/fa/python-net/aspose.slides/digitalsignaturecollection/remove_at/) را با شاخص صفر-پایه آن فراخوانی کنید. مگر اینکه بازنویسی اصلی امضا شده بخشی صریح از جریان کاری شما باشد، به یک فایل جدید ذخیره کنید.

## **ملاحظات ویرایش و قالب**

- یک امضا ارائه را به حالت فقط‌خواندنی تبدیل نمی‌کند. کاربران و برنامه‌ها می‌توانند هنوز فایل را ویرایش کنند، اما تغییرات در محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌کند.
- تمام ویرایش‌های موردنظر را قبل از امضا انجام دهید. اگر لازم باشد ارائه تغییر کند، نسخه اصلاح‌شده را ذخیره کنید و آن بازباری را دوباره امضا کنید.
- خروجی نهایی را در قالب PPTX نگه دارید. تبدیل یک ارائه امضا شده به قالب دیگری، امضای اصلی PPTX را به‌عنوان امضای معتبر برای فایل تبدیل‌شده منتقل نمی‌کند.
- کلید خصوصی گواهی را به‌عنوان اطلاعات حساس در نظر بگیرید. هر کسی که کلید خصوصی و گذرواژه آن را به‌دست آورد می‌تواند امضاهایی ایجاد کند که گویی از طرف دارنده گواهی هستند.
- در صورتی که سیاست نگهداری اسناد شما نیاز داشته باشد، منبع بدون امضا یا یک نسخه کنترل‌شده دیگر را نگه دارید.

## **سؤال‌های متداول**

**آیا امضای دیجیتال ارائه را رمزنگاری می‌کند؟**

خیر. امضای دیجیتال شواهدی درباره منبع و یکپارچگی ارائه می‌دهد، اما محتوای ارائه به‌صورت قابل خواندن باقی می‌ماند مگر اینکه رمزنگاری جداگانه‌ای اعمال شود. وقتی دسترسی به محتوا باید محدود شود، از [حفاظت با رمز عبور](/python-net/password-protected-presentation/) استفاده کنید.

**آیا گذرواژه PFX همان گذرواژه ارائه است؟**

خیر. گذرواژه PFX کلید خصوصی ذخیره‌شده در بسته گواهی را باز می‌کند. این کنترل‌کننده این نیست که چه کسی می‌تواند فایل PPTX را باز یا ویرایش کند.

**آیا می‌توانم از یک گواهی خودامضا استفاده کنم؟**

از لحاظ فنی، یک گواهی خودامضا می‌تواند استفاده شود هنگامی که شامل یک کلید خصوصی قابل دسترس باشد. با این حال، دریافت‌کنندگان به‌طور خودکار به آن اعتماد نمی‌کنند مگر اینکه این گواهی صراحتاً به محیط مورد اعتماد آن‌ها افزوده شود. جریان‌های کاری عمومی یا میان‌سازمان‌ها معمولاً از گواهی صادر شده توسط یک CA معتبر استفاده می‌کنند.

**چه چیزی باعث نامعتبر شدن امضا می‌شود؟**

تغییر محتوای ارائه امضا شده یا داده‌های امضا پس از امضا می‌تواند امضا را نامعتبر کند. خراب شدن فایل نیز می‌تواند باعث شکست اعتبارسنجی شود. اگر تمام امضاها حذف شوند، ارائه بدون امضا می‌شود نه اینکه فایلی حاوی امضای نامعتبر باشد.

**آیا یک امضای معتبر به این معنی است که باید به امضاکننده اعتماد کنم؟**

خلاف این نیست. یکپارچگی امضا و اعتماد به امضاکننده تصمیمات جداگانه‌ای هستند. یک سیاست اعتبارسنجی در محیط تولید باید زنجیره گواهی، دوره اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هرگونه نیاز به زمان‌مهر معتبر را نیز بررسی کند.

**چه اتفاقی می‌افتد وقتی گواهی منقضی می‌شود؟**

منقضی شدن گواهی بایت‌های ارائه را تغییر نمی‌دهد، اما بر ارزیابی اعتماد به گواهی تأثیر می‌گذارد. اینکه آیا امضا همچنان قابل قبول است بستگی به سیاست شما و اینکه آیا یک زمان‌مهر معتبر نشان می‌دهد امضا در زمانی انجام شده که گواهی معتبر بوده است دارد. تنها به زمان امضای نمایش داده‌شده به‌عنوان زمان‌مهر معتبر اعتماد نکنید.

**آیا می‌توان یک ارائه امضا شده را ویرایش کرد؟**

بله. امضا کردن فایل را قفل نمی‌کند. ویرایش محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌کند، بنابراین ابتدا ارائه را تکمیل کنید و سپس نسخه نهایی را امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. هر امضا را قبل از ذخیره‌سازی به [Presentation.digital_signatures](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/digital_signatures/) اضافه کنید. هنگام اعتبارسنجی، هر امضا را بررسی کرده و تأیید کنید که تمام امضاکنندگان مورد نیاز حضور داشته‌اند.

**کدام فرمت‌های ارائه از این عملیات پشتیبانی می‌کنند؟**

Aspose.Slides فقط برای PPTX عملیات‌های امضای دیجیتال توضیح داده‌شده را پشتیبانی می‌کند. فرمت‌های PPT و ارائه‌های OpenDocument توسط این جریان کاری API پشتیبانی نمی‌شوند.

**آیا می‌توانم یک امضا را حذف کنم بدون اینکه بر اسلایدها تأثیر بگذارد؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را پاک کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها همچنان در دسترس است، اما فایل ذخیره‌شده دیگر شامل شواهد امضای حذف‌شده نمی‌شود.