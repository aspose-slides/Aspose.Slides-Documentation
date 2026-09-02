---
title: افزودن امضاهای دیجیتال به ارائه‌ها در جاوا
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

یک امضای دیجیتال به گیرنده این امکان را می‌دهد که تشخیص دهد چه کسی یک ارائه را امضا کرده و آیا محتوای امضا شده تغییر کرده است. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- **گواهی دیجیتال** یک اعتبار الکترونیکی است که یک هویت را با کلید عمومی مرتبط می‌کند. یک مرجع صدور گواهی (CA) مورد اعتماد می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند برای گردش کار داخلی از یک گواهی خودامضا استفاده کند.
- **امضای دیجیتال** از محتوای ارائه و کلید خصوصی صاحب گواهی ایجاد می‌شود. سپس می‌توان با استفاده از کلید عمومی گواهی امضا را تأیید کرد. امضا مدرکی از منشا و یکپارچگی فراهم می‌کند؛ اما ارائه را رمزنگاری نمی‌کند.
- **حفاظت با رمز عبور** تعیین می‌کند که آیا کاربر می‌تواند ارائه را باز یا ویرایش کند. این مورد جدا از امضای دیجیتال است و در بخش [Password-Protected Presentations](/java/password-protected-presentation/) توضیح داده شده است.

PowerPoint دستور **Add a Digital Signature** را تحت **File > Info > Protect Presentation** ارائه می‌دهد.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

پس از باز شدن یک ارائه امضا شده، PowerPoint می‌تواند اعلان وضعیت امضا را نمایش دهد.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ipresentation/#getDigitalSignatures--) افشا می‌کند که یک [IDigitalSignatureCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides.idigitalsignaturecollection/) را برمی‌گرداند؛ موارد این مجموعه پیاده‌سازی [IDigitalSignature](https://reference.aspose.com/slides/fa/java/com.aspose.slides.idigitalsignature/) را دارند. یک ارائه می‌تواند حاوی چندین امضا باشد.

## **درک گواهی‌های PFX و رمزهای عبور**

یک فایل PFX که به‌عنوان فایل PKCS#12 نیز شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیره گواهی باشد. کلید خصوصی همان چیزی است که به دارنده اجازه می‌دهد امضایی ایجاد کند. گواهی بدون دسترسی به کلید خصوصی نمی‌تواند برای امضای ارائه استفاده شود.

رمز عبور PFX بسته گواهی و کلید خصوصی را محافظت می‌کند. این **رمز عبور** برای باز کردن یا ویرایش ارائه نمی‌باشد. فایل‌های PFX یا رمزهای عبور آن‌ها را به مخزن منبع کد کامیت نکنید. در محیط تولید، دسترسی به فایل گواهی را محدود کنید و رمز عبور آن را از یک مخزن مخفی یا منبع پیکربندی محافظت‌شده دریافت کنید. مثال‌های زیر تنها برای جلوگیری از جاسازی رمز در کد از یک متغیر محیطی استفاده می‌کنند.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک گردش کار واقعی، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/java/com.aspose.slides.digitalsignature/) را از یک گواهی PFX و رمز عبور آن ایجاد کنید، امضا را به مجموعه ارائه اضافه کنید و به یک فایل PPTX ذخیره نمایید.

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

ذخیره نتیجه تحت نام جدید، فایل منبع بدون امضا را حفظ می‌کند. مقداری که توسط [IDigitalSignature.setComments](https://reference.aspose.com/slides/fa/java/com.aspose.slides.idigitalsignature/#setComments-java.lang.String-) تنظیم می‌شود، هدف امضا را توصیف می‌کند؛ اما یک کنترل امنیتی نیست.

## **اعتبارسنجی امضاهای دیجیتال**

هنگامی که یک فایل PPTX امضا شده را بارگذاری می‌کنید، هر موردی که توسط [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ipresentation/#getDigitalSignatures--) برگردانده می‌شود را بررسی کنید. متد [IDigitalSignature.isValid](https://reference.aspose.com/slides/fa/java/com.aspose.slides.idigitalsignature/#isValid--) نشان می‌دهد که آیا امضای تعبیه‌شده برای محتوای فعلی ارائه معتبر است یا خیر.

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

یک نتیجه نامعتبر معمولاً به این معنی است که محتوای ارائه امضا شده یا داده‌های امضا پس از امضا تغییر کرده‌اند، یا اینکه فایل آسیب دیده است. حذف تمام امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین صرف بررسی اعتبار موارد کافی نیست: یک گردش کار حساس به امنیت باید همچنین تعداد انتظار امضاها و هویت‌های انتظاردار امضاکنندگان را تأیید کند.

این نتیجه اعتبار نباید به‌عنوان تصمیم نهایی اعتماد به گواهی در نظر گرفته شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز داشته باشد زنجیره گواهی X.509 را ساخته و اعتبارسنجی کند، تاریخ‌های اعتبار گواهی و وضعیت لغو را بررسی کند، موضوع یا اثر انگشت مورد انتظار را تأیید کند، استفاده از کلید را بررسی کند و یک زمان‌ساز معتبر را ارزیابی نماید. مقدار بازگشتی توسط [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides.idigitalsignature/#getSignTime--) به تنهایی مدرکی از یک مرجع زمان‌ساز معتبر نیست.

## **حذف امضاهای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضا شده را بارگذاری می‌کند، تمام امضاها را با استفاده از [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides.idigitalsignaturecollection/#clear--) حذف می‌کند و یک نسخه بدون امضا ذخیره می‌نماید.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای حذف تنها یک امضا، با استفاده از [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/fa/java/com.aspose.slides.idigitalsignaturecollection/#removeAt-int-) و اندیس صفر‑محور آن فراخوانی کنید. مگر اینکه حذف امضا به‌صورت صریح بخشی از گردش کار شما باشد، به‌جای بازنویسی فایل اصلی امضا شده، در فایلی جدید ذخیره کنید.

## **موارد ویرایش و قالب‌بندی**

- یک امضا ارائه را به‌طور خودکار فقط‑خواندنی نمی‌کند. کاربران و برنامه‌ها هنوز می‌توانند فایل را ویرایش کنند، اما تغییر محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌سازد.
- تمام ویرایش‌های موردنظرتان را پیش از امضا انجام دهید. اگر لازم شد ارائه تغییر کند، نسخه اصلاح‌شده را ذخیره کنید و دوباره امضا کنید.
- خروجی نهایی را در قالب PPTX نگه دارید. تبدیل یک ارائه امضا شده به قالب دیگر امضای اصلی PPTX را به‌عنوان امضای معتبر برای فایل تبدیل‌شده منتقل نمی‌کند.
- کلید خصوصی گواهی را به‌عنوان اطلاعات حساس در نظر بگیرید. هر کسی که به کلید خصوصی و رمز عبور آن دست پیدا کند، می‌تواند امضاهایی ایجاد کند که گویی از طرف صاحب گواهی هستند.
- هنگام نیاز به سیاست نگهداری اسناد، منبع بدون امضا یا نسخهٔ کنترل‌شده دیگری را حفظ کنید.

## **سوالات متداول**

**آیا امضای دیجیتال ارائه را رمزنگاری می‌کند؟**

خیر. امضای دیجیتال مدرکی از منشا و یکپارچگی ارائه می‌دهد، اما محتوا همچنان قابل خواندن است مگر اینکه رمزنگاری جداگانه‌ای اعمال شود. برای محدود کردن دسترسی به محتوا از [حفاظت با رمز عبور](/java/password-protected-presentation/) استفاده کنید.

**آیا رمز عبور PFX همان رمز عبور ارائه است؟**

خیر. رمز عبور PFX کلید خصوصی ذخیره‌شده در بسته گواهی را باز می‌کند. این رمز عبور کسی را که می‌تواند فایل PPTX را باز یا ویرایش کند، کنترل نمی‌کند.

**آیا می‌توانم از گواهی خودامضا استفاده کنم؟**

از نظر فنی، گواهی خودامضا می‌تواند استفاده شود به‌شرط اینکه شامل کلید خصوصی دسترس‌پذیر باشد. دریافت‌کنندگان به‌طور خودکار به آن اعتماد نخواهند کرد مگر اینکه این گواهی صراحتاً به محیط مورد اعتمادشان اضافه شده باشد. معمولاً گردش‌کارهای عمومی یا میان‌سازمانی از گواهی صادرشده توسط یک CA مورد اعتماد استفاده می‌کنند.

**چه عواملی باعث می‌شوند یک امضا نامعتبر شود؟**

تغییر محتوای ارائه امضا شده یا داده‌های امضا پس از امضا، امضا را نامعتبر می‌کند. خراب‌شدن فایل نیز می‌تواند باعث عدم اعتبارسنجی شود. اگر همه امضاها حذف شوند، ارائه بدون امضا است نه اینکه حاوی امضای نامعتبر باشد.

**آیا امضای معتبر به این معناست که باید به امضاکننده اعتماد کرد؟**

خود امضای معتبر به تنهایی کافی نیست. یک تصمیم جداگانه دربارهٔ اعتماد به امضاکننده باید گرفته شود. سیاست اعتبارسنجی در محیط تولید باید زنجیره گواهی، دورهٔ اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هر نیاز به زمان‌ساز معتبر را نیز بررسی کند.

**وقتی گواهی منقضی می‌شود چه اتفاقی می‌افتد؟**

منقضی‌شدن گواهی محتوای بایت‌های ارائه را تغییر نمی‌دهد، اما ارزیابی اعتماد به گواهی را تحت تأثیر قرار می‌دهد. اینکه آیا یک امضا همچنان قابل قبول باشد، بستگی به سیاست شما و این دارد که آیا یک زمان‌ساز معتبر نشان می‌دهد امضا در زمان معتبر بودن گواهی صورت گرفته است یا نه. تنها زمان امضا نمایش داده‌شده را به‌عنوان زمان‌ساز معتبر در نظر نگیرید.

**آیا یک ارائه امضا شده می‌تواند ویرایش شود؟**

بله. امضای دیجیتال فایل را قفل نمی‌کند. ویرایش محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌سازد، لذا ابتدا ویرایش نهایی را انجام دهید و سپس نسخهٔ نهایی را امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. هر امضا را قبل از ذخیره به مجموعه‌ای که توسط [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ipresentation/#getDigitalSignatures--) برگردانده می‌شود، اضافه کنید. هنگام اعتبارسنجی، هر امضا را بررسی کنید و اطمینان حاصل کنید تمام امضاکنندگان موردنیاز حضور دارند.

**کدام فرمت‌های ارائه از این عملیات پشتیبانی می‌کنند؟**

Aspose.Slides عملیات‌های امضای دیجیتال توضیح‌داده‌شده در اینجا را فقط برای PPTX پشتیبانی می‌کند. فرمت‌های PPT و OpenDocument پشتیبانی نمی‌شوند.

**آیا می‌توانم امضا را حذف کنم بدون اینکه اسلایدها تحت تأثیر قرار گیرند؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را پاک کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها همان‌جا می‌ماند، اما فایل ذخیره‌شده دیگر شامل مدرک امضای حذف‌شده نخواهد بود.