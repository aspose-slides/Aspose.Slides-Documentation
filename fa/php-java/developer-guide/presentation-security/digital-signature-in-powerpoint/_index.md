---
title: افزودن امضای دیجیتال به ارائه‌ها در PHP
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
description: "یاد بگیرید چگونه ارائه‌های PPTX موجود را با گواهی‌های PFX امضا کنید و از Aspose.Slides برای PHP از طریق Java برای اعتبارسنجی یا حذف امضای دیجیتال استفاده کنید."
---
## **مروری کلی**

یک امضای دیجیتال به دریافت‌کننده کمک می‌کند تعیین کند چه کسی یک ارائه را امضا کرده است و آیا محتوای امضاشده تغییر کرده است یا نه. سه مفهوم امنیتی مرتبط در اینجا اهمیت دارند:

- **گواهی دیجیتال** یک اعتبار الکترونیکی است که یک هویت را با یک کلید عمومی پیوند می‌دهد. یک مرجع صدور گواهی معتبر (CA) می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند برای جریان‌های کاری داخلی از گواهی خودامضا استفاده کند.
- **امضای دیجیتال** از محتوای ارائه و کلید خصوصی دارنده گواهی ساخته می‌شود. سپس می‌توان با استفاده از کلید عمومی گواهی امضا را بررسی کرد. امضا شواهدی از منبع و یکپارچگی فراهم می‌کند؛ اما ارائه را رمزگذاری نمی‌کند.
- **حفاظت با رمز عبور** تعیین می‌کند که آیا کاربر می‌تواند یک ارائه را باز یا اصلاح کند. این جدا از امضای دیجیتال است و در بخش [ارائه‌های محافظت‌شده با رمز عبور](/php-java/password-protected-presentation/) توضیح داده شده است.

PowerPoint فرمان **Add a Digital Signature** را تحت **File > Info > Protect Presentation** ارائه می‌دهد.

![منوی Protect Presentation در PowerPoint با گزینه Add a Digital Signature برجسته شده](add-digital-signature-in-powerpoint.png)

پس از باز کردن یک ارائه امضاشده، PowerPoint می‌تواند اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint که نشان می‌دهد ارائه شامل امضاهای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getDigitalSignatures) در اختیار می‌گذارد، که یک [DigitalSignatureCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignaturecollection/) را برمی‌گرداند و اقلام آن توسط اشیاء [DigitalSignature](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignature/) نمایندگی می‌شوند. یک ارائه می‌تواند چندین امضا داشته باشد.

## **درک گواهی‌های PFX و رمزهای عبور**

یک فایل PFX، که به عنوان فایل PKCS#12 نیز شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیره گواهی باشد. کلید خصوصی به دارنده امکان ایجاد امضا را می‌دهد. گواهی بدون دسترسی به کلید خصوصی نمی‌تواند برای امضای ارائه استفاده شود.

رمز عبور PFX بسته گواهی و کلید خصوصی را محافظت می‌کند. این **رمز عبور برای باز کردن یا ویرایش ارائه نیست**. فایل‌های PFX یا رمزهای عبورشان را به مخزن کد نسخه‌بندی (source control) اختصاص ندهید. در محیط تولید، دسترسی به فایل گواهی را محدود کنید و رمز عبور آن را از یک مخزن محرمانه یا منبع پیکربندی محافظت‌شده دریافت کنید. مثال‌های زیر از یک متغیر محیطی استفاده می‌کنند تا از جاسازی مستقیم رمز عبور در کد جلوگیری شود.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک جریان کاری واقعی، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignature/) از یک گواهی PFX و رمز عبور آن ایجاد کنید، امضا را به مجموعه ارائه اضافه کنید و در یک فایل PPTX ذخیره کنید.

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

ذخیره نتیجه تحت نام جدید، فایل منبع بدون امضا را حفظ می‌کند. مقدار تنظیم شده توسط [DigitalSignature::setComments](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignature/setcomments/) هدف امضا را توصیف می‌کند؛ این یک کنترل امنیتی نیست.

## **اعتبارسنجی امضای دیجیتال**

هنگام بارگذاری یک فایل PPTX امضاشده، هر آیتمی که توسط [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getDigitalSignatures) بازگردانده می‌شود را بررسی کنید. متد [DigitalSignature::isValid](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignature/isvalid/) نشان می‌دهد که آیا امضای توکار برای محتوای فعلی ارائه معتبر است یا نه.

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

نتیجه نامعتبر معمولاً به این معناست که محتوای امضاشده یا داده‌های امضا پس از امضا تغییر کرده‌اند یا فایل آسیب دیده است. حذف همه امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین فقط بررسی اعتبار آیتم‌ها کافی نیست: یک جریان کاری حساس به امنیت باید همچنین تعداد مورد انتظار امضاها و هویت‌های امضاکنندگان مورد انتظار را تأیید کند.

این نتیجه اعتبار نباید به‌عنوان تصمیم نهایی اعتماد به گواهی در نظر گرفته شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز داشته باشد زنجیره گواهی X.509 را ساخته و اعتبارسنجی کند، تاریخ‌های اعتبار گواهی و وضعیت لغو را بررسی کند، موضوع یا اثر انگشت مورد انتظار را تأیید کند، استفاده از کلید را بررسی کند و یک مهر زمان معتبر را ارزیابی کند. مقدار [DigitalSignature::getSignTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignature/getsigntime/) به‌تنهایی اثباتی از یک مرجع زمان قابل اعتماد نیست.

## **حذف امضای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضاشده را بارگذاری می‌کند، تمام امضاها را با [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignaturecollection/clear/) حذف می‌کند و یک نسخه بدون امضا ذخیره می‌کند.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای حذف فقط یک امضا، با استفاده از ایندکس صفر‑پایهٔ آن، متد [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/digitalsignaturecollection/removeat/) را فراخوانی کنید. مگر اینکه حذف امضای اصلی بخشی صریح از جریان کاری شما باشد، به‌جای بازنویسی فایل اصلی امضاشده، به فایل جدید ذخیره کنید.

## **ملاحظات ویرایش و قالب‌بندی**

- یک امضا، ارائه را به‌صورت فقط‑خواندنی نمی‌کند. کاربران و برنامه‌ها هنوز می‌توانند فایل را ویرایش کنند، اما تغییر در محتوای امضاشده معمولاً امضای موجود را نامعتبر می‌سازد.
- تمام ویرایش‌های موردنظر را پیش از امضا انجام دهید. اگر لازم است ارائه تغییر کند، نسخهٔ اصلاح‌شده را ذخیره کنید و مجدداً آن را امضا کنید.
- خروجی نهایی را در قالب PPTX نگه دارید. تبدیل یک ارائه امضاشده به قالب دیگری، امضای PPTX اصلی را به‌عنوان امضای معتبر برای فایل تبدیل‌شده منتقل نمی‌کند.
- کلید خصوصی گواهی را به‌عنوان اطلاعات حساس در نظر بگیرید. هر کسی که به کلید خصوصی و رمز عبور آن دست یابد، می‌تواند امضاهایی ایجاد کند که گویی از طرف دارنده گواهی هستند.
- در صورت نیاز به سیاست‌های نگهداری اسناد، منبع بدون امضا یا یک رونوشت کنترل‌شده دیگر را حفظ کنید.

## **سؤالات متداول**

**آیا امضای دیجیتال ارائه را رمزگذاری می‌کند؟**

نه. امضای دیجیتال شواهدی درباره منبع و یکپارچگی فراهم می‌کند، اما محتوای ارائه تا زمان اعمال رمزگذاری جداگانه خواندنی باقی می‌ماند. هنگام نیاز به محدود کردن دسترسی به محتوا، از [حفاظت با رمز عبور](/php-java/password-protected-presentation/) استفاده کنید.

**آیا رمز عبور PFX همان رمز عبور ارائه است؟**

نه. رمز عبور PFX کلید خصوصی ذخیره‌شده در بسته گواهی را باز می‌کند. این رمز عبور کنترل‌گری برای باز یا ویرایش فایل PPTX نیست.

**آیا می‌توانم از گواهی خودامضا استفاده کنم؟**

از نظر فنی می‌توان از گواهی خودامضا استفاده کرد، به شرطی که شامل یک کلید خصوصی قابل دسترس باشد. دریافت‌کنندگان به‌طور خودکار به آن اعتماد نخواهند کرد مگر اینکه گواهی به‌صورت صریح به محیط مورداعتمادشان اضافه شده باشد. در اکثر جریان‌های کاری عمومی یا بین‌سازمانی از گواهی صادرشده توسط یک CA معتبر استفاده می‌شود.

**چه چیزی باعث نامعتبر شدن یک امضا می‌شود؟**

تغییر محتوای امضاشده یا داده‌های امضا پس از امضا می‌تواند امضا را نامعتبر کند. خراب شدن فایل نیز ممکن است اعتبارسنجی را به شکست برساند. اگر تمام امضاها حذف شوند، ارائه بدون امضا می‌شود نه اینکه حاوی امضای نامعتبر باشد.

**آیا امضای معتبر یعنی باید به امضاکننده اعتماد کرد؟**

خیر. اعتبار امضا و اعتماد به امضاکننده تصمیمات جداگانه‌ای هستند. یک سیاست اعتبارسنجی تولیدی باید علاوه بر اعتبار امضا، زنجیره گواهی، دورهٔ اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هر نیاز به مهر زمان معتبر را نیز بررسی کند.

**چه اتفاقی می‌افتد وقتی گواهی منقضی می‌شود؟**

منقضی شدن گواهی خود بایت‌های ارائه را تغییر نمی‌دهد، اما ارزیابی اعتماد به گواهی را تحت تأثیر قرار می‌دهد. اینکه آیا امضا همچنان قابل قبول باشد بستگی به سیاست شما و این دارد که آیا یک مهر زمان معتبر نشان می‌دهد امضا در زمان معتبر بودن گواهی انجام شده است یا نه. تنها به زمان نمایش‌داده‌شدهٔ امضا به‌عنوان مهر زمان قابل اعتماد تکیه نکنید.

**آیا می‌توان یک ارائه امضاشده را هنوز ویرایش کرد؟**

بله. امضا فایل را قفل نمی‌کند. ویرایش محتوای امضاشده معمولاً امضای موجود را نامعتبر می‌کند، بنابراین ابتدا ارائه را نهایی کنید و سپس امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. هر امضا را به مجموعه‌ای که توسط [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getDigitalSignatures) بازگردانده می‌شود، اضافه کنید و سپس ذخیره کنید. هنگام اعتبارسنجی، هر امضا را بررسی کنید و تأیید کنید تمام امضاکنندگان مورد نیاز حضور دارند.

**کدام قالب‌های ارائه از این عملیات‌ها پشتیبانی می‌کنند؟**

Aspose.Slides عملیات‌های امضای دیجیتال توضیح داده‌شده را فقط برای قالب PPTX پشتیبانی می‌کند. قالب‌های PPT و OpenDocument برای این API پشتیبانی نمی‌شوند.

**آیا می‌توانم یک امضا را حذف کنم بدون اینکه اسلایدها تحت تأثیر قرار گیرند؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را پاک کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها باقی می‌مانند، اما فایل ذخیره‌شده دیگر شواهد امضای حذف‌شده را در برنمایی نمی‌کند.