---
title: افزودن امضاهای دیجیتال به ارائه‌ها در جاوااسکریپت
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/nodejs-java/digital-signature-in-powerpoint/
keywords:
- امضای دیجیتال
- گواهی دیجیتال
- مرجع صدور گواهی
- گواهی PFX
- PKCS#12
- اعتبارسنجی امضا
- PowerPoint
- PPTX
- امنیت ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PPTX موجود را با گواهی‌های PFX امضا کنید و از Aspose.Slides برای Node.js از طریق Java برای اعتبارسنجی یا حذف امضای دیجیتال استفاده کنید."
---
## **بررسی کلی**

یک امضای دیجیتال به دریافت‌کننده کمک می‌کند تا تعیین کند چه کسی یک ارائه را امضا کرده و آیا محتوای امضا شده تغییر کرده است. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- یک **گواهی دیجیتال** اعتبار الکترونیکی است که هویت را با یک کلید عمومی مرتبط می‌کند. یک مرجع گواهی‌امضا (CA) قابل اعتماد می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند برای جریان‌های کاری داخلی از یک گواهی خودامضا استفاده کند.
- یک **امضای دیجیتال** از محتوای ارائه و کلید خصوصی دارنده گواهی ساخته می‌شود. سپس می‌توان با کلید عمومی گواهی امضا را تأیید کرد. امضا شواهدی از منبع و یکپارچگی ارائه می‌دهد؛ اما ارائه را رمزنگاری نمی‌کند.
- **حفاظت با گذرواژه** کنترل می‌کند که آیا کاربر می‌تواند یک ارائه را باز یا اصلاح کند. این مورد جدا از امضای دیجیتال است و در [ارائه‌های محافظت‌شده با گذرواژه](/nodejs-java/password-protected-presentation/) توضیح داده شده است.

PowerPoint فرمان **Add a Digital Signature** را تحت **File > Info > Protect Presentation** ارائه می‌دهد.

![منوی Protect Presentation در PowerPoint که گزینه Add a Digital Signature را برجسته نشان می‌دهد](add-digital-signature-in-powerpoint.png)

پس از باز شدن یک ارائه امضا شده، PowerPoint می‌تواند اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint مبنی بر اینکه ارائه شامل امضاهای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) در دسترس قرار می‌دهد که یک [DigitalSignatureCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignaturecollection/) شامل اشیاء [DigitalSignature](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignature/) برمی‌گرداند. یک ارائه می‌تواند شامل چندین امضا باشد.

## **درک گواهی‌های PFX و گذرواژه‌ها**

یک فایل PFX، که به عنوان فایل PKCS#12 نیز شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیره گواهی باشد. کلید خصوصی همان چیزی است که به دارنده اجازه می‌دهد امضا ایجاد کند. گواهی بدون کلید خصوصی قابل دسترس نمی‌تواند برای امضای یک ارائه استفاده شود.

گذرواژه PFX بسته گواهی و کلید خصوصی را محافظت می‌کند. این **گذرواژه‌ای برای باز یا ویرایش ارائه نیست**. فایل‌های PFX یا گذرواژه‌های آن‌ها را به مخزن منبع کد اضافه نکنید. در محیط تولید، دسترسی به فایل گواهی را محدود کنید و گذرواژه آن را از یک مخزن راز یا منبع پیکربندی محافظت‌شده دیگری دریافت کنید. مثال‌های زیر فقط برای جلوگیری از جاسازی گذرواژه در کد، از یک متغیر محیطی استفاده می‌کنند.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک جریان کاری واقعی، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignature/) از یک گواهی PFX و گذرواژه آن ایجاد کنید، امضا را به مجموعه امضاهای ارائه اضافه کنید و به یک فایل PPTX ذخیره کنید.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ذخیره نتیجه با نام جدید، فایل منبع بدون امضا را حفظ می‌کند. مقداری که توسط [DigitalSignature.setComments](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignature/) تنظیم می‌شود، هدف امضا را توصیف می‌کند؛ این یک کنترل امنیتی نیست.

## **اعتبارسنجی امضای دیجیتال**

هنگامی که یک فایل PPTX امضا شده را بارگذاری می‌کنید، هر موردی که توسط [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) بازگردانده می‌شود را بررسی کنید. متد [DigitalSignature.isValid](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignature/) نشان می‌دهد آیا امضای تعبیه‌شده برای محتوای فعلی ارائه معتبر است یا نه.

مثال زیر همچنین از کلاس Node.js `X509Certificate` برای خواندن نام موضوع از هر گواهی تعبیه‌شده استفاده می‌کند.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

یک نتیجه نامعتبر معمولاً به این معناست که محتوای ارائه امضا شده یا داده‌های امضا پس از امضا تغییر کرده‌اند، یا فایل خراب شده است. حذف تمام امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین بررسی فقط صحت موارد کافی نیست: یک جریان کاری حساس به امنیت باید همچنین تعداد توقع‌شده امضاها و هویت‌های توقع‌شده امضاکنندگان را تأیید کند.

این نتیجه اعتبار نباید به عنوان تصمیم نهایی درباره‌ی اعتماد به گواهی در نظر گرفته شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز داشته باشد زنجیره گواهی X.509 را ساخته و اعتبارسنجی کند، تاریخ‌های اعتبار گواهی و وضعیت لغو را بررسی کند، موضوع یا اثر انگشت مورد انتظار را تأیید کند، استفاده از کلید را بررسی کند و یک زمان‌سِمت معتبر را ارزیابی کند. مقدار بازگشتی توسط [DigitalSignature.getSignTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignature/) به تنهایی مدرکی از یک مرجع زمان‌سَمت قابل اعتماد نیست.

## **حذف امضای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضا شده را بارگذاری می‌کند، تمام امضاها را با استفاده از [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) حذف می‌کند و یک نسخه بدون امضا ذخیره می‌نماید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای حذف تنها یک امضا، متد [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) را با اندیس صفر‑پایهٔ آن فراخوانی کنید. مگر اینکه بازنویسی فایل اصلی امضا شده بخش صریحی از جریان کاری شما باشد، به یک فایل جدید ذخیره کنید.

## **موارد ویرایش و قالب‌بندی**

- یک امضا، ارائه را فقط‑خواندنی نمی‌کند. کاربران و برنامه‌ها همچنان می‌توانند فایل را ویرایش کنند، اما تغییر محتوای امضا شده به‌طور معمول امضای موجود را نامعتبر می‌کند.
- تمام ویرایش‌های موردنظر را پیش از امضا انجام دهید. اگر لازم باشد ارائه تغییر کند، نسخه اصلاح‌شده را ذخیره کنید و آن نسخه را دوباره امضا کنید.
- خروجی نهایی را در قالب PPTX نگه دارید. تبدیل یک ارائه امضا شده به قالب دیگر امضای اصلی PPTX را به عنوان امضای معتبر برای فایل تبدیل‌شده انتقال نمی‌دهد.
- کلید خصوصی گواهی را به‌عنوان اطلاعات حساس در نظر بگیرید. هر کسی که کلید خصوصی و گذرواژهٔ آن را به دست آورد، می‌تواند امضاهایی ایجاد کند که گویی از طرف دارنده گواهی هستند.
- هنگامیکه سیاست نگهداری سند شما نیاز دارد، منبع بدون امضا یا یک کپی کنترل‌شده را حفظ کنید.

## **پرسش‌های متداول**

**آیا یک امضای دیجیتال ارائه را رمزنگاری می‌کند؟**

نه. یک امضای دیجیتال شواهدی درباره منبع و یکپارچگی ارائه می‌دهد، اما محتوای ارائه تا زمانی که رمزنگاری جداگانه‌ای اعمال نشود، قابل خواندن باقی می‌ماند. هنگامی که دسترسی به محتوا باید محدود شود، از [حفاظت با گذرواژه](/nodejs-java/password-protected-presentation/) استفاده کنید.

**آیا گذرواژهٔ PFX همان گذرواژهٔ ارائه است؟**

نه. گذرواژهٔ PFX کلید خصوصی ذخیره‌شده در بسته گواهی را باز می‌کند. این گذرواژه بر این کنترل ندارد که چه کسی می‌تواند فایل PPTX را باز یا ویرایش کند.

**آیا می‌توانم از یک گواهی خودامضا استفاده کنم؟**

از نظر فنی، یک گواهی خودامضا می‌تواند استفاده شود به شرطی که شامل یک کلید خصوصی قابل دسترس باشد. دریافت‌کنندگان به‌طور خودکار به آن اعتماد نمی‌کنند مگر این که گواهی به‌صورت صریح به محیط قابل اعتماد آنها اضافه شده باشد. جریان‌های کاری عمومی یا بین‌سازمانی عموماً از گواهی صادرشده توسط یک CA قابل اعتماد استفاده می‌کنند.

**چه چیزی باعث می‌شود یک امضا نامعتبر باشد؟**

تغییر محتوای ارائه امضا شده یا داده‌های امضا پس از امضا، امضا را نامعتبر می‌کند. خراب شدن فایل نیز می‌تواند باعث شکست اعتبارسنجی شود. اگر همهٔ امضاها حذف شوند، ارائه بدون امضا است نه فایلی که شامل یک امضای نامعتبر باشد.

**آیا یک امضای معتبر به این معنی است که باید به امضاکننده اعتماد کرد؟**

خلاف آن، خود امضای معتبر نشانگر اعتماد نیست. یک سیاست اعتبارسنجی در محیط تولید باید علاوه بر اعتبار امضا، زنجیره گواهی، دورهٔ اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هر نیاز به زمان‌سِمت قابل اعتماد را نیز بررسی کند.

**وقتی گواهی منقضی می‌شود چه اتفاقی می‌افتد؟**

انقضای گواهی محتوای بایت‌های ارائه را تغییر نمی‌دهد، اما ارزیابی اعتماد به گواهی را تحت تأثیر قرار می‌دهد. قابل‌قبول بودن امضا بستگی به سیاست شما و این دارد که آیا یک زمان‌سِمت معتبر نشان می‌دهد امضا در زمانی انجام شده که گواهی هنوز معتبر بوده است یا خیر. تنها به زمان امضای نمایش‌داده‌شده به‌عنوان زمان‌سِمت قابل اعتماد اعتماد نکنید.

**آیا می‌توان یک ارائه امضا شده را ویرایش کرد؟**

بله. امضای دیجیتال فایل را قفل نمی‌کند. ویرایش محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌کند، بنابراین ابتدا ارائه را تکمیل کنید و سپس نسخه نهایی را امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. قبل از ذخیره، هر امضا را به مجموعه‌ای که توسط [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) بازگردانده می‌شود، اضافه کنید. در مرحلهٔ اعتبارسنجی، هر امضا را بررسی کنید و تأیید کنید همهٔ امضاکنندگان موردنیاز موجود باشند.

**کدام فرمت‌های ارائه از این عملیات‌ها پشتیبانی می‌کنند؟**

Aspose.Slides فقط برای فرمت PPTX از عملیات‌های مربوط به امضای دیجیتال که در اینجا توضیح داده شده‌اند، پشتیبانی می‌کند. فرمت‌های PPT و OpenDocument پشتیبانی نمی‌شوند.

**آیا می‌توانم یک امضا را حذف کنم بدون اینکه على‌السلاسل اسلایدها تأثیر بگذارد؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را پاک کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها باقی می‌ماند، اما فایل ذخیره‌شده دیگر شواهد امضای حذف‌شده را حمل نمی‌کند.