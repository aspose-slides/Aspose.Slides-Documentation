---
title: افزودن امضای دیجیتال به ارائه‌ها در JavaScript
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
description: "یاد بگیرید چگونه ارائه‌های PPTX موجود را با گواهی‌های PFX امضا کنید و از Aspose.Slides برای Node.js از طریق Java برای اعتبارسنجی یا حذف امضاهای دیجیتال استفاده کنید."
---
## **مرور کلی**

یک امضای دیجیتال به دریافت‌کننده امکان می‌دهد تعیین کند که چه کسی یک ارائه را امضا کرده و آیا محتوای امضاشده تغییر یافته است یا خیر. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- **گواهی دیجیتال** یک شناسه الکترونیکی است که یک هویت را با کلید عمومی مرتبط می‌کند. یک مرجع صدور گواهی (CA) مورد اعتماد می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند از گواهی خودامضا برای جریان‌کارهای داخلی استفاده کند.
- **امضای دیجیتال** از محتوای ارائه و کلید خصوصی دارنده گواهی ساخته می‌شود. سپس می‌توان از کلید عمومی گواهی برای تأیید امضا استفاده کرد. امضا شواهدی از منبع و یکپارچگی فراهم می‌کند؛ این امر ارائه را رمزنگاری نمی‌کند.
- **حفاظت با گذرواژه** کنترل می‌کند که آیا کاربر می‌تواند یک ارائه را باز یا ویرایش کند. این موضوع منفصل از امضای دیجیتال است و در [Password-Protected Presentations](/slides/fa/nodejs-java/password-protected-presentation/) توضیح داده شده است.

PowerPoint فرمان **Add a Digital Signature** را تحت **File > Info > Protect Presentation** ارائه می‌دهد.

![منوی Protect Presentation در PowerPoint با برجسته‌شدن Add a Digital Signature](add-digital-signature-in-powerpoint.png)

پس از باز کردن یک ارائه امضاشده، PowerPoint می‌تواند اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint که نشان می‌دهد ارائه شامل امضای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) در دسترس می‌گذارد، که یک [DigitalSignatureCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignaturecollection/) حاوی اشیاء [DigitalSignature](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignature/) را برمی‌گرداند. یک ارائه می‌تواند چندین امضا داشته باشد.

## **درک گواهی‌های PFX و گذرواژه‌ها**

یک فایل PFX، که به عنوان فایل PKCS#12 نیز شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیره گواهی باشد. کلید خصوصی اجازه می‌دهد دارنده گواهی امضا ایجاد کند. گواهی بدون کلید خصوصی قابل دسترس نمی‌تواند برای امضای ارائه استفاده شود.

گذرواژه PFX بسته گواهی و کلید خصوصی را محافظت می‌کند. این گذرواژه **گذرواژه‌ای برای باز یا ویرایش ارائه نیست**. فایل‌های PFX یا گذرواژه‌های آن‌ها را به مخزن منبع اضافه نکنید. در محیط تولید دسترسی به فایل گواهی را محدود کنید و گذرواژه آن را از یک مخزن مخفی یا منبع پیکربندی محافظت‌شده دریافت کنید. مثال‌های زیر تنها برای اجتناب از جاسازی گذرواژه در کد، از یک متغیر محیطی استفاده می‌کنند.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک جریان‌کار واقعی، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignature/) از گواهی PFX و گذرواژه آن ایجاد کنید، امضا را به مجموعه ارائه اضافه کنید و به یک فایل PPTX ذخیره کنید.

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

## **اعتبارسنجی امضاهای دیجیتال**

هنگامی که یک فایل PPTX امضاشده را بارگذاری می‌کنید، به هر موردی که توسط [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) برگردانده می‌شود، نگاه کنید. متد [DigitalSignature.isValid](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignature/) نشان می‌دهد آیا امضای تعبیه‌شده برای محتوای فعلی ارائه معتبر است یا خیر.

مثال زیر علاوه بر آن از کلاس `X509Certificate` در Node.js برای خواندن نام موضوع از هر گواهی تعبیه‌شده استفاده می‌کند.

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

نتیجه نامعتبر معمولاً به این معناست که محتوای ارائه امضاشده یا داده‌های امضا پس از امضا تغییر کرده‌اند، یا فایل خراب شده است. حذف همه امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین تنها بررسی اعتبار موارد کافی نیست: یک جریان‌کار حساس به امنیت باید همچنین تعداد مورد انتظار امضاها و هویت‌های امضاکنندگان مورد انتظار را تأیید کند.

این نتیجه اعتبار نباید به‌عنوان تصمیم نهایی اعتماد به گواهی تلقی شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز به ساخت و اعتبارسنجی زنجیره گواهی X.509، بررسی تاریخ‌های اعتبار گواهی و وضعیت لغو، تأیید موضوع یا اثر انگشت مورد انتظار، بررسی استفاده از کلید و ارزیابی یک مهر زمان مورد اعتماد داشته باشد. مقدار [DigitalSignature.getSignTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignature/) به‌تنهایی اثباتی از مرجع مهر زمان مورد اعتماد نیست.

## **حذف امضاهای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضاشده را بارگذاری می‌کند، تمام امضاها را با [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) حذف می‌کند و یک کپی بدون امضا را ذخیره می‌کند.

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

برای حذف تنها یک امضا، متد [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) را با اندیس صفرمحور آن فراخوانی کنید. مگر اینکه حذف امضای اصلی بخشی صریح از جریان‌کار شما باشد، به‌جای بازنویسی فایل اصلی امضاشده، به یک فایل جدید ذخیره کنید.

## **نکات و ملاحظات ویرایش و فرمت**

- یک امضا ارائه را فقط‌خوانا نمی‌کند. کاربران و برنامه‌ها هنوز می‌توانند فایل را ویرایش کنند، اما تغییر محتویات امضاشده معمولاً امضای موجود را نامعتبر می‌کند.
- تمام ویرایش‌های موردنظر را قبل از امضا انجام دهید. اگر باید ارائه تغییر کند، نسخه اصلاح‌شده را ذخیره کنید و دوباره امضا کنید.
- خروجی نهایی را در فرمت PPTX نگه دارید. تبدیل یک ارائه امضاشده به فرمت دیگری امضای اصلی PPTX را به‌عنوان امضای معتبر برای فایل تبدیل‌شده منتقل نمی‌کند.
- کلید خصوصی گواهی را حساس در نظر بگیرید. هر کسی که کلید خصوصی و گذرواژه آن را به‌دست آورد، می‌تواند امضاهایی ایجاد کند که به‌نظر می‌رسد از طرف دارنده گواهی هستند.
- منبع بدون امضا یا یک نسخه کنترل‌شده دیگر را در صورتی که سیاست نگهداری اسناد شما آن را نیاز دارد، نگه دارید.

## **سوالات متداول**

**آیا امضای دیجیتال ارائه را رمزنگاری می‌کند؟**

نه. یک امضای دیجیتال شواهدی درباره منبع و یکپارچگی فراهم می‌کند، اما محتوای ارائه قابل خواندن باقی می‌ماند مگر اینکه رمزنگاری جداگانه‌ای اعمال شود. هنگام نیاز به محدود کردن دسترسی به محتوا از [password protection](/slides/fa/nodejs-java/password-protected-presentation/) استفاده کنید.

**آیا گذرواژه PFX همان گذرواژه ارائه است؟**

نه. گذرواژه PFX کلید خصوصی ذخیره‌شده در بسته گواهی را باز می‌کند. این گذرواژه کنترل نمی‌کند که چه کسی می‌تواند فایل PPTX را باز یا ویرایش کند.

**آیا می‌توانم از گواهی خودامضا استفاده کنم؟**

از نظر فنی، وقتی گواهی شامل یک کلید خصوصی قابل دسترس باشد می‌توان از گواهی خودامضا استفاده کرد. دریافت‌کنندگان به‌صورت خودکار به آن اعتماد نخواهند کرد مگر اینکه این گواهی به‌صورت صریح به محیط مورداعتمادشان اضافه شود. جریان‌کارهای عمومی یا بین‌سازمانی معمولاً از گواهی صادرشده توسط یک CA مورد اعتماد استفاده می‌کنند.

**چه چیزی یک امضا را نامعتبر می‌کند؟**

تغییر محتوای ارائه امضاشده یا داده‌های امضا پس از امضا می‌تواند امضا را نامعتبر کند. خراب شدن فایل نیز می‌تواند اعتبارسنجی را شکست دهد. اگر تمام امضاها حذف شوند، ارائه بدون امضا است نه اینکه حاوی امضای نامعتبر باشد.

**آیا امضای معتبر به این معنی است که باید به امضاکننده اعتماد کرد؟**

خود امضای معتبر کافی نیست. یک سیاست اعتبارسنجی تولیدی باید همچنین زنجیره گواهی، دوره اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هر نیاز به مهر زمان مورد اعتماد را بررسی کند.

**زمان انتهاء گواهی چه اتفاقی می‌افتد؟**

انقضای گواهی بایت‌های ارائه را تغییر نمی‌دهد، اما ارزیابی اعتماد به گواهی را تحت تأثیر قرار می‌دهد. اینکه آیا امضا همچنان قابل قبول باشد بستگی به سیاست شما و این دارد که آیا یک مهر زمان قابل اعتماد نشان می‌دهد امضا در زمانی بوده که گواهی معتبر بوده است یا خیر. فقط به زمان نمایش داده‌شده امضا به‌عنوان مهر زمان مورد اعتماد تکیه نکنید.

**آیا یک ارائه امضاشده هنوز می‌تواند ویرایش شود؟**

بله. امضا کردن فایل را قفل نمی‌کند. ویرایش محتوای امضاشده معمولاً امضای موجود را نامعتبر می‌کند، بنابراین ابتدا ارائه را کامل کنید و سپس نسخه نهایی را امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. قبل از ذخیره، هر امضا را به مجموعه‌ای که توسط [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) برگردانده می‌شود، اضافه کنید. هنگام اعتبارسنجی، هر امضا را بررسی کنید و تأیید کنید تمام امضاکنندگان مورد نیاز حضور دارند.

**کدام فرمت‌های ارائه از این عملیات پشتیبانی می‌کنند؟**

Aspose.Slides فقط برای فرمت PPTX عملیات‌های امضای دیجیتال توصیف‌شده در اینجا را پشتیبانی می‌کند. فرمت‌های PPT و OpenDocument پشتیبانی نمی‌شوند.

**آیا می‌توانم امضا را حذف کنم بدون اینکه به اسلایدها آسیب برسد؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را پاک کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها باقی می‌ماند، اما فایل ذخیره‌شده دیگر شواهد امضای حذف‌شده را حمل نمی‌کند.