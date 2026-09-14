---
title: افزودن امضاهای دیجیتال به ارائه‌ها در پایتون
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/python-java/digital-signature-in-powerpoint/
keywords:
- امضای دیجیتال
- گواهی دیجیتال
- مرجع صدور گواهی
- گواهی PFX
- گواهی PKCS#12
- اعتبارسنجی امضا
- PowerPoint
- PPTX
- امنیت ارائه
- Python
- Aspose.Slides
description: "نحوه امضای ارائه‌های PPTX موجود با گواهی‌های PFX و استفاده از Aspose.Slides برای پایتون از طریق جاوا برای اعتبارسنجی یا حذف امضاهای دیجیتال را بیاموزید."
---
## **بررسی کلی**

یک امضای دیجیتال به گیرنده این امکان را می‌دهد تا تعیین کند چه کسی یک ارائه را امضا کرده و آیا محتویات امضا شده تغییر کرده‌اند یا نه. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- **گواهی دیجیتال** یک اعتبار الکترونیکی است که هویت را با یک کلید عمومی مرتبط می‌کند. یک مرجع صدور گواهی معتبر (CA) می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند برای جریان‌های کاری داخلی از گواهی خودامضا استفاده کند.
- **امضای دیجیتال** از محتویات ارائه و کلید خصوصی دارنده گواهی ساخته می‌شود. سپس می‌توان با کلید عمومی گواهی، امضا را بررسی کرد. امضا شواهدی از منبع و یکپارچگی فراهم می‌کند؛ اما محتوای ارائه را رمزنگاری نمی‌کند.
- **حمایت با گذرواژه** تعیین می‌کند که آیا کاربر می‌تواند یک ارائه را باز یا ویرایش کند. این مورد مستقل از امضای دیجیتال است و در بخش [Password-Protected Presentations](/slides/fa/python-java/password-protected-presentation/) توضیح داده شده است.

PowerPoint دستور **Add a Digital Signature** را تحت **File > Info > Protect Presentation** ارائه می‌دهد.

![منوی Protect Presentation در PowerPoint که گزینه Add a Digital Signature را برجسته کرده است](add-digital-signature-in-powerpoint.png)

پس از باز کردن یک ارائه امضا شده، PowerPoint می‌تواند اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint که نشان می‌دهد ارائه شامل امضاهای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getDigitalSignatures) در دسترس قرار می‌دهد که یک [DigitalSignatureCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/digitalsignaturecollection/) را باز می‌گرداند؛ عناصر این مجموعه نمونه‌هایی از [DigitalSignature](https://reference.aspose.com/slides/fa/python-java/aspose.slides/digitalsignature/) هستند. یک ارائه می‌تواند دارای امضای متعدد باشد.

## **درک گواهی‌های PFX و گذرواژه‌ها**

یک فایل PFX که به عنوان فایل PKCS#12 شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیره گواهی باشد. کلید خصوصی به دارنده امکان می‌دهد تا امضا ایجاد کند. گواهی بدون دسترسی به کلید خصوصی نمی‌تواند برای امضای یک ارائه استفاده شود.

گذرواژه PFX بسته گواهی و کلید خصوصی را محافظت می‌کند. این **گذرواژه‌ای برای باز یا ویرایش ارائه نیست**. فایل‌های PFX یا گذرواژه‌های آن را به مخزن کد منبع نادیده نگیرید. در محیط تولید، دسترسی به فایل گواهی را محدود کنید و گذرواژه را از مخزن رمز یا منبع پیکربندی محافظت‌شده دیگر دریافت کنید. مثال‌های زیر فقط برای جلوگیری از تعبیه گذرواژه در کد، از یک متغیر محیطی استفاده می‌کنند.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک جریان کاری واقعی، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/python-java/aspose.slides/digitalsignature/) از یک گواهی PFX و گذرواژه آن ایجاد کنید، امضا را به مجموعه ارائه اضافه کنید و در قالب PPTX ذخیره نمایید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

ذخیره نتیجه با نام جدید، فایل منبع بدون امضا را حفظ می‌کند. مقداری که توسط [DigitalSignature.setComments](https://reference.aspose.com/slides/fa/python-java/aspose.slides/digitalsignature/#setComments) تنظیم می‌شود، هدف امضا را توصیف می‌کند؛ این یک کنترل امنیتی نیست.

## **اعتبارسنجی امضای دیجیتال**

زمانی که یک فایل PPTX امضا شده را بارگذاری می‌کنید، هر مورد بازگشتی توسط [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getDigitalSignatures) را بررسی کنید. متد [DigitalSignature.isValid](https://reference.aspose.com/slides/fa/python-java/aspose.slides/digitalsignature/#isValid) نشان می‌دهد که آیا امضای جاسازی‌شده برای محتوای فعلی ارائه معتبر است یا خیر.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

یک نتیجه نامعتبر معمولاً به این معنی است که محتویات ارائه امضا شده یا داده‌های امضا پس از امضا تغییر کرده‌اند، یا اینکه فایل خراب شده است. حذف تمام امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین فقط بررسی اعتبار موارد کافی نیست: یک جریان کاری حساس به امنیت باید همچنین تعداد مورد انتظار امضاها و هویت‌های امضاکنندگان مورد انتظار را تأیید کند.

این نتیجه اعتبار نباید به عنوان تصمیم کامل درباره اعتبار گواهی در نظر گرفته شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز به ساخت و اعتبارسنجی زنجیره گواهی X.509، بررسی تاریخ‌های اعتبار گواهی و وضعیت ابطال، تأیید موضوع یا اثر انگشت مورد انتظار، بررسی استفاده از کلید و ارزیابی یک زمان‌ساز قابل اعتماد داشته باشد. مقدار بازگردانده شده توسط [DigitalSignature.getSignTime](https://reference.aspose.com/slides/fa/python-java/aspose.slides/digitalsignature/#getSignTime) به تنهایی اثباتی از یک زمان‌ساز معتبر نیست.

## **حذف امضای دیجیتال**

حذف امضاها حالت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضا شده را بارگذاری می‌کند، همه امضاها را با استفاده از [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/digitalsignaturecollection/#clear) حذف می‌کند و یک نسخه بدون امضا ذخیره می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای حذف فقط یک امضا، می‌توانید با استفاده از شناسهٔ صفر‑مبنای آن، [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/digitalsignaturecollection/#removeAt) را فراخوانی کنید. مگر اینکه حذف امضا بخشی صریح از جریان کاری شما باشد، خروجی را در فایلی جدید ذخیره کنید نه اینکه فایل اصلی امضا شده را بازنویسی کنید.

## **ملاحظات ویرایش و قالب‌بندی**

- امضا یک ارائه را به حالت فقط‑خواندنی تبدیل نمی‌کند. کاربران و برنامه‌ها همچنان می‌توانند فایل را ویرایش کنند، اما تغییر در محتویات امضا شده معمولاً امضای موجود را نامعتبر می‌کند.
- تمام ویرایش‌های مطلوب را قبل از امضا انجام دهید. اگر نیاز به تغییر ارائه باشد، نسخهٔ بازنگری‌شده را ذخیره کنید و آن نسخه را دوباره امضا کنید.
- خروجی نهایی را در قالب PPTX نگه دارید. تبدیل یک ارائهٔ امضا شده به قالب دیگر، امضای PPTX اصلی را به عنوان امضای معتبر برای فایل تبدیل‌شده انتقال نمی‌دهد.
- کلید خصوصی گواهی را به عنوان اطلاعات حساس در نظر بگیرید. هرکسی که کلید خصوصی و گذرواژهٔ آن را به دست آورد، می‌تواند امضاهایی تولید کند که گویی از طرف دارندهٔ گواهی هستند.
- هنگامیکه سیاست نگهداری اسناد شما نیاز دارد، نسخهٔ منبع بدون امضا یا یک کپی کنترل‌شدهٔ دیگر را حفظ کنید.

## **پرسش‌های متداول**

**آیا امضای دیجیتال ارائه را رمزنگاری می‌کند؟**

خیر. امضای دیجیتال شواهدی درباره منبع و یکپارچگی ارائه می‌دهد، اما محتویات ارائه همچنان قابل خواندن است مگر اینکه به طور جداگانه رمزنگاری شده باشد. برای محدود کردن دسترسی به محتوا، از [password protection](/slides/fa/python-java/password-protected-presentation/) استفاده کنید.

**آیا گذرواژهٔ PFX با گذرواژهٔ ارائه یکسان است؟**

خیر. گذرواژهٔ PFX کلید خصوصی ذخیره‌شده در بستهٔ گواهی را باز می‌کند. این گذرواژه کنترل نمی‌کند چه کسی می‌تواند فایل PPTX را باز یا ویرایش کند.

**آیا می‌توانم از گواهی خودامضا استفاده کنم؟**

از نظر فنی، گواهی خودامضا می‌تواند استفاده شود به شرطی که شامل کلید خصوصی قابل دسترسی باشد. دریافت‌کنندگان به‌طور خودکار به آن اعتماد نمی‌کنند مگر اینکه این گواهی به‌صراحت به محیط‌های مورد اعتماد آنها اضافه شده باشد. معمولاً جریان‌های کاری عمومی یا میان‌سازمانی از گواهی صادرشده توسط یک CA معتبر استفاده می‌کنند.

**چه عواملی باعث نامعتبر شدن یک امضا می‌شود؟**

تغییر محتویات ارائه امضا شده یا داده‌های امضا پس از امضا، امضا را نامعتبر می‌کند. خراب شدن فایل نیز می‌تواند اعتبارسنجی را ناموفق کند. اگر همهٔ امضاها حذف شوند، ارائه بدون امضا خواهد بود نه اینکه شامل امضای نامعتبر باشد.

**آیا امضای معتبر به این معنی است که باید به امضاکننده اعتماد کرد؟**

خیر. صحت امضا و اعتماد به امضاکننده تصمیمات جداگانه‌ای هستند. یک سیاست اعتبارسنجی تولیدی باید علاوه بر بررسی امضا، زنجیره گواهی، دورهٔ اعتبار، وضعیت ابطال، هویت مورد انتظار، استفاده از کلید و نیازهای زمان‌ساز قابل اعتماد را نیز بررسی کند.

**هنگامی که گواهی منقضی شود چه اتفاقی می‌افتد؟**

منقضی شدن گواهی محتوای بایت‌های ارائه را تغییر نمی‌دهد، اما ارزیابی اعتماد گواهی را تحت تأثیر قرار می‌دهد. اینکه آیا امضا همچنان قابل قبول باشد، بستگی به سیاست شما و این دارد که آیا یک زمان‌ساز معتبر نشان می‌دهد امضا در زمان اعتبار گواهی انجام شده است یا خیر. تنها به زمان ثبت امضا به‌عنوان زمان‌ساز قابل اعتماد اعتماد نکنید.

**آیا یک ارائهٔ امضا شده هنوز قابل ویرایش است؟**

بله. امضا فایل را قفل نمی‌کند. ویرایش محتویات امضا شده معمولاً امضای موجود را نامعتبر می‌کند، بنابراین ابتدا ارائه را نهایی کنید و سپس امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. هر امضا را به مجموعه‌ای که توسط [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getDigitalSignatures) برگردانده می‌شود، اضافه کنید و سپس ذخیره نمایید. در هنگام اعتبارسنجی، هر امضا را بررسی کنید و تأیید کنید همهٔ امضاکنندگان مورد نیاز حضور دارند.

**کدام فرمت‌های ارائه از این عملیات‌ها پشتیبانی می‌کنند؟**

Aspose.Slides عملیات‌های امضای دیجیتال را که در اینجا توضیح داده شده‌اند فقط برای فرمت PPTX فراهم می‌کند. فرمت‌های PPT و OpenDocument پشتیبانی نمی‌شوند.

**آیا می‌توانم یک امضا را حذف کنم بدون اینکه اسلایدها تحت تأثیر قرار بگیرند؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را پاک کنید و سپس ارائه را ذخیره کنید. محتویات اسلایدها همان‌جا باقی می‌مانند، اما فایل ذخیره‌شده دیگر شواهد امضای حذف‌شده را شامل نمی‌شود.