---
title: افزودن امضای دیجیتال به ارائه‌ها در جاوا
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "نحوه امضای ارائه‌های PPTX موجود با گواهی‌های PFX و استفاده از Aspose.Slides برای جاوا برای اعتبارسنجی یا حذف امضاهای دیجیتال را بیاموزید."
---
## **نمای کلی**

امضای دیجیتال به گیرنده این امکان را می‌دهد که determines who signed a presentation و بررسی کند آیا محتوای امضا شده تغییر کرده است یا خیر. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- **گواهی دیجیتال** یک اعتبار الکترونیکی است که یک هویت را با یک کلید عمومی ارتباط می‌دهد. یک مرجع گواهی معتبر (CA) می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند برای جریان‌های کاری داخلی از گواهی خودامضا استفاده کند.
- **امضای دیجیتال** از محتوای ارائه و کلید خصوصی دارنده گواهی ساخته می‌شود. سپس می‌توان با استفاده از کلید عمومی گواهی، امضا را تأیید کرد. امضا شواهدی از منشاء و تمامیت فراهم می‌کند؛ اما ارائه را رمزنگاری نمی‌کند.
- **حفاظت با رمز عبور** کنترل می‌کند که آیا کاربر می‌تواند ارائه را باز یا ویرایش کند. این مورد جدا از امضای دیجیتال است و در [Password‑Protected Presentations](/slides/fa/java/password-protected-presentation/) توضیح داده شده است.

PowerPoint فرمان **Add a Digital Signature** را تحت **File > Info > Protect Presentation** ارائه می‌دهد.

![منوی Protect Presentation در PowerPoint با گزینه Add a Digital Signature برجسته شده](add-digital-signature-in-powerpoint.png)

پس از باز شدن یک ارائه‌ی امضا شده، PowerPoint می‌تواند اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint که می‌گوید ارائه شامل امضاهای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) در دسترس قرار می‌دهد، که یک [IDigitalSignatureCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idigitalsignaturecollection/) را برمی‌گرداند؛ آیتم‌های این مجموعه پیاده‌سازی [IDigitalSignature](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idigitalsignature/) هستند. یک ارائه می‌تواند شامل چندین امضا باشد.

## **درک گواهی‌های PFX و رمزهای عبور**

یک فایل PFX که به عنوان فایل PKCS#12 نیز شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیره گواهی باشد. کلید خصوصی است که به دارنده امکان ایجاد امضا را می‌دهد. گواهی بدون کلید خصوصی قابل دسترس نمی‌تواند برای امضای یک ارائه استفاده شود.

رمز عبور PFX بسته گواهی و کلید خصوصی را محافظت می‌کند. این **رمز عبور برای باز کردن یا ویرایش ارائه نیست**. فایل‌های PFX یا رمزهای عبور آن‌ها را به مخزن سورس کنترل کامیت نکنید. در محیط تولید، دسترسی به فایل گواهی را محدود کنید و رمز عبور آن را از یک مخزن محرمانه یا منبع پیکربندی محافظت‌شده دریافت کنید. مثال‌های زیر فقط برای جلوگیری از وارد کردن مستقیم رمز عبور در کد از یک متغیر محیطی استفاده می‌کنند.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک جریان کاری واقعی، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/java/com.aspose.slides/digitalsignature/) از گواهی PFX و رمز عبور آن ایجاد کنید، امضا را به مجموعه ارائه اضافه کنید و در یک فایل PPTX ذخیره کنید.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ذخیره نتیجه با نام جدید، فایل منبع بدون امضا را حفظ می‌کند. مقدار تنظیم‌شده توسط [IDigitalSignature.setComments](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) هدف امضا را توصیف می‌کند؛ این مورد یک کنترل امنیتی نیست.

## **اعتبارسنجی امضاهای دیجیتال**

هنگامی که یک فایل PPTX امضا شده را بارگذاری می‌کنید، هر آیتم بازگردانده‌شده توسط [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) را بررسی کنید. متد [IDigitalSignature.isValid](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idigitalsignature/#isValid--) نشان می‌دهد که آیا امضای جاسازی‌شده برای محتوای فعلی ارائه معتبر است یا نه.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

نتیجه نامعتبر معمولاً به این معناست که محتوای ارائهٔ امضا شده یا دادهٔ امضا پس از امضاکننده تغییر کرده یا فایل خراب شده است. حذف تمام امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین صرف بررسی اعتبار آیتم‌ها کافی نیست: یک جریان کاری حساس به امنیت باید همچنین عدد امضاهای مورد انتظار و هویت‌های امضاکنندهٔ مورد انتظار را نیز تأیید کند.

این نتیجه اعتبارسنجی نباید به‌تنهایی به‌عنوان تصمیم کامل اعتماد به گواهی تلقی شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز داشته باشد زنجیرهٔ گواهی X.509 را ساخت و اعتبارسنجی کند، تاریخ‌های اعتبار گواهی و وضعیت لغو را بررسی کند، موضوع یا اثر انگشت مورد انتظار را تأیید کند، استفاده از کلید را بررسی کرده و یک زمان‌مهر معتبر را ارزیابی نماید. مقدار [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idigitalsignature/#getSignTime--) به‌تنهایی اثباتی از یک مرجع زمان‌مهر مورد اعتماد نیست.

## **حذف امضاهای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضا شده را بارگذاری می‌کند، تمام امضاها را با [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idigitalsignaturecollection/#clear--) حذف می‌کند و یک نسخهٔ بدون امضا ذخیره می‌کند.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای حذف تنها یک امضا، متد [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) را با ایندکس صفرمحور آن صدا بزنید. مگر اینکه بازنویسی فایل امضا شدهٔ اصلی بخشی صریح از جریان کاری شما باشد، به‌جای آن در یک فایل جدید ذخیره کنید.

## **ملاحظات ویرایش و قالب‌بندی**

- یک امضا باعث نمی‌شود ارائه به‌صورت فقط‑خواندنی شود. کاربران و برنامه‌ها همچنان می‌توانند فایل را ویرایش کنند، اما تغییرات در محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌کند.
- تمام ویرایش‌های مورد نظر را قبل از امضا انجام دهید. اگر لازم است ارائه تغییر کند، نسخهٔ اصلاح‌شده را ذخیره کنید و مجدداً آن را امضا کنید.
- خروجی نهایی را در قالب PPTX نگه دارید. تبدیل یک ارائهٔ امضا شده به قالب دیگر امضای اصلی PPTX را به‌عنوان امضای معتبر برای فایل تبدیل‌شده منتقل نمی‌کند.
- کلید خصوصی گواهی را به‌عنوان اطلاعات حساس در نظر بگیرید. هرکسی که به کلید خصوصی و رمز عبور آن دست پیدا کند، می‌تواند امضاهایی ایجاد کند که گویی از طرف دارندهٔ گواهی هستند.
- هنگامیکه سیاست نگهداری اسناد شما آن را می‌طلبد، منبع بدون امضا یا یک کپی کنترل‌شده دیگر را حفظ کنید.

## **سوالات متداول**

**آیا امضای دیجیتال محتوای ارائه را رمزنگاری می‌کند؟**

خیر. امضای دیجیتال شواهدی دربارهٔ منشاء و تمامیت فراهم می‌کند، اما محتوای ارائه همچنان قابل خواندن است مگر اینکه رمزنگاری جداگانه‌ای اعمال شده باشد. هنگام نیاز به محدود کردن دسترسی به محتوا، از [password protection](/slides/fa/java/password-protected-presentation/) استفاده کنید.

**آیا رمز عبور PFX همان رمز عبور ارائه است؟**

خیر. رمز عبور PFX کلید خصوصی ذخیره‌شده در بسته گواهی را آزاد می‌کند. این رمز عبور کنترل نمی‌کند که چه کسی می‌تواند فایل PPTX را باز یا ویرایش کند.

**آیا می‌توانم از گواهی خودامضا استفاده کنم؟**

فنیاً، گواهی خودامضا می‌تواند استفاده شود هنگامی که شامل کلید خصوصی قابل دسترسی باشد. با این حال، گیرندگان به‌صورت خودکار به آن اعتماد نخواهند کرد مگر اینکه این گواهی به‌صورت صریح به محیط مورد اعتماد آن‌ها اضافه شده باشد. جریان‌های کاری عمومی یا بین‌سازمانی معمولاً از گواهی صادرشده توسط یک CA معتبر استفاده می‌کنند.

**چه عواملی باعث نامعتبر بودن امضا می‌شوند؟**

تغییر محتوای ارائهٔ امضا شده یا دادهٔ امضا پس از امضاکننده می‌تواند امضا را نامعتبر کند. خراب شدن فایل نیز می‌تواند باعث عدم اعتبارسنجی شود. اگر تمام امضاها حذف شوند، ارائه بدون امضا است نه یک فایل حاوی امضای نامعتبر.

**آیا امضای معتبر به این معناست که باید به امضاکننده اعتماد کرد؟**

خود امضا و اعتماد به امضاکننده تصمیمات جداگانه‌ای هستند. یک سیاست اعتبارسنجی در محیط تولید باید علاوه بر اعتبار امضا، زنجیرهٔ گواهی، دورهٔ اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هر نیاز به زمان‌مهر مورد اعتماد را نیز بررسی کند.

**وقتی گواهی منقضی می‌شود چه می‌شود؟**

منقضی شدن گواهی محتویات بایت‌های ارائه را تغییری نمی‌دهد، اما ارزیابی اعتماد به گواهی را تحت تأثیر قرار می‌دهد. این که آیا امضا همچنان قابل قبول است یا نه به سیاست شما و اینکه آیا زمان‌مهر معتبری وجود دارد که نشان دهد امضا در زمان معتبر بودن گواهی انجام شده است بستگی دارد. تنها به زمان امضا نشان داده‌شده به‌عنوان زمان‌مهر مورد اعتماد اکتفا نکنید.

**آیا می‌توان یک ارائهٔ امضا شده را هنوز ویرایش کرد؟**

بله. امضا کردن فایل را قفل نمی‌کند. ویرایش محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌سازد، بنابراین ابتدا ارائه را نهایی کنید و سپس امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. قبل از ذخیره، هر امضا را به مجموعه‌ای که [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) برمی‌گرداند، اضافه کنید. هنگام اعتبارسنجی، هر امضا را بررسی کنید و تأیید کنید که تمام امضاکنندگان مورد نیاز حضور دارند.

**کدام فرمت‌های ارائه از این عملیات پشتیبانی می‌کنند؟**

Aspose.Slides فقط برای PPTX عملیات امضای دیجیتال توصیف‌شده در اینجا را پشتیبانی می‌کند. فرمت‌های PPT و OpenDocument پشتیبانی نمی‌شوند.

**آیا می‌توانم امضا را حذف کنم بدون اینکه اسلایدها تحت تأثیر قرار گیرند؟**

بله. می‌توانید یک امضا یا تمام مجموعه را حذف کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها باقی می‌ماند، اما فایل ذخیره‌شده دیگر شواهد امضای حذف‌شده را شامل نمی‌شود.