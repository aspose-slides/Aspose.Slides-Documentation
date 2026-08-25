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
- PKCS#12
- اعتبارسنجی امضا
- PowerPoint
- PPTX
- امنیت ارائه
- PHP
- Aspose.Slides
description: "بیاموزید چگونه ارائه‌های PPTX موجود را با گواهی‌های PFX امضا کنید و از Aspose.Slides برای PHP از طریق Java برای اعتبارسنجی یا حذف امضاهای دیجیتال استفاده کنید."
---
## **نمای کلی**

یک امضای دیجیتال به دریافت‌کننده کمک می‌کند تا تعیین کند چه کسی یک ارائه را امضا کرده و آیا محتوای امضا شده تغییر کرده است. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- یک **گواهی دیجیتال** یک اعتبار الکترونیکی است که یک هویت را با یک کلید عمومی مرتبط می‌کند. یک مرجع صدور گواهی (CA) مورد اعتماد می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند برای گردش‌های کاری داخلی از گواهی خود‌امضا استفاده کند.
- یک **امضای دیجیتال** از محتوای ارائه و کلید خصوصی دارنده گواهی ساخته می‌شود. سپس می‌توان از کلید عمومی گواهی برای تأیید امضا استفاده کرد. یک امضا شواهدی از منشأ و صحت ارائه می‌دهد؛ اما ارائه را رمزنگاری نمی‌کند.
- **حفاظت با رمز عبور** تعیین می‌کند که آیا کاربر می‌تواند ارائه را باز یا ویرایش کند. این مورد جدا از امضای دیجیتال است و در [Password-Protected Presentations](/slides/fa/php-java/password-protected-presentation/) توضیح داده شده است.

PowerPoint فرمان **Add a Digital Signature** را در زیر **File > Info > Protect Presentation** ارائه می‌دهد.

![منوی Protect Presentation در PowerPoint با برجسته شدن Add a Digital Signature](add-digital-signature-in-powerpoint.png)

پس از باز شدن یک ارائه امضا شده، PowerPoint می‌تواند یک اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint که اعلام می‌کند ارائه شامل امضاهای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getDigitalSignatures) در دسترس قرار می‌دهد که یک [DigitalSignatureCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignaturecollection/) را برمی‌گرداند؛ موارد این مجموعه توسط اشیای [DigitalSignature](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignature/) نمایندگی می‌شوند. یک ارائه می‌تواند شامل چندین امضا باشد.

## **درک گواهی‌های PFX و رمزهای عبور**

یک فایل PFX که به عنوان فایل PKCS#12 نیز شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیره گواهی باشد. کلید خصوصی همان عاملی است که به دارنده اجازه می‌دهد امضا ایجاد کند. گواهی بدون کلید خصوصی قابل دسترسی نمی‌تواند برای امضای ارائه استفاده شود.

رمز عبور PFX بسته گواهی و کلید خصوصی را محافظت می‌کند. این رمز **رمز عبور برای باز کردن یا ویرایش ارائه نیست**. فایل‌های PFX یا رمزهای عبورشان را به مخزن منبع متعهد نکنید. در محیط تولید، دسترسی به فایل گواهی را محدود کنید و رمز عبور آن را از یک مخزن راز یا منبعی پیکربندی محافظت‌شده دریافت کنید. مثال‌های زیر فقط برای جلوگیری از جاسازی رمز عبور در کد، از یک متغیر محیطی استفاده می‌کنند.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک جریان کاری واقعی، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignature/) را از یک گواهی PFX و رمز عبور آن ایجاد کنید، امضا را به مجموعه ارائه اضافه کنید و به یک فایل PPTX ذخیره کنید.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ذخیره نتیجه تحت نام جدید، فایل منبع بدون امضا را حفظ می‌کند. مقداری که توسط [DigitalSignature::setComments](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignature/setcomments/) تنظیم می‌شود، هدف امضا را توصیف می‌کند؛ این یک کنترل امنیتی نیست.

## **اعتبارسنجی امضاهای دیجیتال**

هنگامی که یک فایل PPTX امضا شده را بارگذاری می‌کنید، هر مورد بازگردانده‌شده توسط [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getDigitalSignatures) را بررسی کنید. متد [DigitalSignature::isValid](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignature/isvalid/) نشان می‌دهد که آیا امضای جاسازی‌شده برای محتوای فعلی ارائه معتبر است یا خیر.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```


نتیجه نامعتبر معمولاً به این معنی است که محتوای ارائه امضا شده یا داده‌های امضا پس از امضا تغییر کرده‌اند، یا اینکه فایل خسارت دیده است. حذف تمام امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین تنها بررسی اعتبار موارد کافی نیست: یک جریان کاری حساس به امنیت باید تعداد امضاهای مورد انتظار و هویت‌های امضاکنندگان مورد انتظار را نیز تأیید کند.

این نتیجه اعتبارسنجی نباید به عنوان یک تصمیم کامل درباره اعتماد به گواهی در نظر گرفته شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز داشته باشد زنجیره گواهی X.509 را ساخته و اعتبارسنجی کند، تاریخ‌های اعتبار گواهی و وضعیت ابطال را بررسی کند، موضوع یا اثر انگشت مورد انتظار را تأیید کند، استفاده از کلید را بررسی کرده و یک مهرزمان مورد اعتماد را ارزیابی کند. مقدار بازگردانده‌شده توسط [DigitalSignature::getSignTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignature/getsigntime/) به تنهایی اثباتی از یک مرجع مهرزمان مورد اعتماد نیست.

## **حذف امضاهای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضا شده را بارگذاری می‌کند، تمام امضاها را با استفاده از [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignaturecollection/clear/) حذف می‌کند و یک نسخه بدون امضا ذخیره می‌کند.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای حذف فقط یک امضا، متد [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignaturecollection/removeat/) را با شاخص صفر‑پایه آن فراخوانی کنید. مگر اینکه بازنویسی فایل اصلی امضا شده بخشی صریح از جریان کاری شما باشد، به یک فایل جدید ذخیره کنید.

## **ملاحظات ویرایش و قالب**

- یک امضا باعث نمی‌شود ارائه فقط‑خواندنی شود. کاربران و برنامه‌ها هنوز می‌توانند فایل را ویرایش کنند، اما تغییر محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌کند.
- تمام ویرایش‌های مورد نظر را قبل از امضا انجام دهید. اگر لازم است ارائه تغییر کند، نسخه اصلاح‌شده را ذخیره کنید و آن نسخه را دوباره امضا کنید.
- خروجی نهایی را در قالب PPTX حفظ کنید. تبدیل یک ارائه امضا شده به قالب دیگر امضای اصلی PPTX را به عنوان امضای معتبر برای فایل تبدیل‌شده منتقل نمی‌کند.
- کلید خصوصی گواهی را به عنوان اطلاعات حساس نگه دارید. هرکسی که کلید خصوصی و رمز عبور آن را به دست آورد، می‌تواند امضاهایی بسازد که به نظر می‌رسد از طرف دارنده گواهی بوده‌اند.
- هنگامیکه سیاست حفظ سند شما این نیاز را دارد، منبع بدون امضا یا یک نسخه کنترل‌شده دیگر را نگه دارید.

## **FAQ**

**آیا یک امضای دیجیتال ارائه را رمزنگاری می‌کند؟**

نه. یک امضای دیجیتال شواهدی درباره منشاء و صحت ارائه فراهم می‌کند، اما محتوای ارائه همچنان قابل خواندن باقی می‌ماند مگر اینکه رمزنگاری جداگانه‌ای اعمال شود. هنگام نیاز به محدود کردن دسترسی به محتوا از [password protection](/slides/fa/php-java/password-protected-presentation/) استفاده کنید.

**آیا رمز عبور PFX همان رمز عبور ارائه است؟**

نه. رمز عبور PFX کلید خصوصی ذخیره‌شده در بسته گواهی را باز می‌کند. این رمز کنترل نمی‌کند که چه کسی می‌تواند فایل PPTX را باز یا ویرایش کند.

**آیا می‌توانم از گواهی خودامضا استفاده کنم؟**

از نظر فنی، گواهی خودامضا می‌تواند استفاده شود وقتی شامل یک کلید خصوصی قابل دسترس باشد. دریافت‌کنندگان به‌صورت خودکار به آن اعتماد نمی‌کنند مگر اینکه این گواهی صریحاً به محیط مورد اعتماد آن‌ها اضافه شده باشد. گردش‌های کاری عمومی یا بین‌سازمانی معمولاً از گواهی صادرشده توسط یک CA معتبر استفاده می‌کنند.

**چه چیزی باعث می‌شود یک امضا نامعتبر شود؟**

تغییر محتوای ارائه امضا شده یا داده‌های امضا پس از امضا می‌تواند امضا را نامعتبر کند. خراب شدن فایل نیز می‌تواند باعث عدم اعتبارسنجی شود. اگر تمام امضاها حذف شوند، ارائه بدون امضا است نه اینکه حاوی امضای نامعتبر باشد.

**آیا یک امضای معتبر به این معنی است که باید به امضاکننده اعتماد کرد؟**

خود امضای معتبر به تنهایی کافی نیست. اعتبار امضا و اعتماد به امضاکننده تصمیمات جداگانه‌ای هستند. یک سیاست اعتبارسنجی تولیدی باید زنجیره گواهی، دوره اعتبار، وضعیت ابطال، هویت مورد انتظار، استفاده از کلید و هر نیاز به مهرزمان مورد اعتماد را نیز بررسی کند.

**وقتی گواهی منقضی می‌شود چه اتفاقی می‌افتد؟**

منقضی شدن گواهی محتویات بایت‌های ارائه را تغییر نمی‌دهد، اما ارزیابی اعتماد به گواهی را تحت تأثیر قرار می‌دهد. اینکه آیا یک امضا همچنان قابل قبول باشد بستگی به سیاست شما دارد و اینکه آیا یک مهرزمان معتبر نشان می‌دهد امضا در زمان اعتبار گواهی انجام شده است یا خیر. فقط به زمان امضای نمایش‌داده‌شده به عنوان مهرزمان مورد اعتماد اعتماد نکنید.

**آیا یک ارائه امضا شده هنوز می‌تواند ویرایش شود؟**

بله. امضا کردن فایل را قفل نمی‌کند. ویرایش محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌کند، بنابراین ابتدا ارائه را نهایی کنید و سپس نسخه نهایی را امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. هر امضا را به مجموعه‌ای که توسط [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getDigitalSignatures) بازگردانده می‌شود، اضافه کنید و سپس ذخیره کنید. هنگام اعتبارسنجی، هر امضا را بررسی کنید و تأیید کنید تمام امضاکنندگان مورد نیاز حضور دارند.

**کدام قالب‌های ارائه این عملیات‌ها را پشتیبانی می‌کنند؟**

Aspose.Slides عملیات‌های امضای دیجیتال توضیح‌داده‌شده را فقط برای PPTX پشتیبانی می‌کند. قالب‌های PPT و OpenDocument برای این API پشتیبانی نمی‌شوند.

**آیا می‌توانم امضا را حذف کنم بدون اینکه اسلایدها تحت تأثیر قرار گیرند؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را خالی کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها باقی می‌ماند، اما فایل ذخیره‌شده دیگر حاوی شواهد امضای حذف‌شده نیست.