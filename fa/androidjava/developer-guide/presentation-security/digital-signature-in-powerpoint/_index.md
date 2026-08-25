---
title: افزودن امضاهای دیجیتال به ارائه‌ها در اندروید
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/androidjava/digital-signature-in-powerpoint/
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
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PPTX موجود را با گواهی‌های PFX امضا کنید و از Aspose.Slides برای اندروید از طریق جاوا برای اعتبارسنجی یا حذف امضاهای دیجیتال استفاده کنید."
---
## **مرور کلی**

یک امضای دیجیتال به گیرنده کمک می‌کند تا تعیین کند چه کسی یک ارائه را امضا کرده و آیا محتوای امضاشده تغییر کرده است. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- یک **گواهی دیجیتال** یک اعتبار الکترونیکی است که یک هویت را با یک کلید عمومی مرتبط می‌کند. یک مرجع گواهی‌نامه (CA) مورد اعتماد می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند از گواهی خودامضا برای کارهای داخلی استفاده کند.
- یک **امضای دیجیتال** از محتوای ارائه و کلید خصوصی صاحب گواهی ساخته می‌شود. سپس می‌توان از کلید عمومی گواهی برای تأیید امضا استفاده کرد. امضا شواهدی از اصل و تمامیت ارائه فراهم می‌کند؛ اما ارائه را رمزنگاری نمی‌کند.
- **حفاظت با رمز عبور** تعیین می‌کند که آیا کاربر می‌تواند ارائه را باز یا ویرایش کند. این مورد جدا از امضای دیجیتال است و در [ارائه‌های محافظت‌شده با رمز عبور](/slides/fa/androidjava/password-protected-presentation/) توضیح داده شده است.

PowerPoint فرمان **Add a Digital Signature** را زیر **File > Info > Protect Presentation** ارائه می‌دهد.

![منوی Protect Presentation در PowerPoint با برجسته شدن Add a Digital Signature](add-digital-signature-in-powerpoint.png)

پس از باز شدن یک ارائه‌امضاشده، PowerPoint می‌تواند یک اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint مبنی بر اینکه ارائه شامل امضاهای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) ارائه می‌دهد که یک [IDigitalSignatureCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignaturecollection/) را برمی‌گرداند که اقلام آن پیاده‌سازی‌کنندهٔ [IDigitalSignature](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignature/) هستند. یک ارائه می‌تواند شامل چندین امضا باشد.

## **درک گواهی‌های PFX و رمز عبور**

یک فایل PFX، که به عنوان فایل PKCS#12 نیز شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن، و زنجیره گواهی باشد. کلید خصوصی همان چیزی است که به صاحب اجازه می‌دهد امضا ایجاد کند. گواهی بدون یک کلید خصوصی قابل دسترسی نمی‌تواند برای امضای یک ارائه استفاده شود.

رمز عبور PFX بسته گواهی و کلید خصوصی را محافظت می‌کند. این **رمز عبور** برای باز کردن یا ویرایش ارائه نیست. فایل‌های PFX یا رمزهای عبور آن‌ها را به مخزن منبع (source control) کمیت نکنید. در محیط تولید، دسترسی به فایل گواهی را محدود کرده و رمز عبور آن را از یک مخزن محرمانه یا منبع پیکربندی محافظت‌شده دریافت کنید. مثال‌های زیر فقط برای جلوگیری از قراردادن رمز عبور در کد، از یک متغیر محیطی استفاده می‌کنند.

## **افزودن امضای دیجیتال به ارائه**

برای امضای یک جریان کاری واقعی ارائه، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/digitalsignature/) را از یک گواهی PFX و رمز عبور آن ایجاد کنید، امضا را به مجموعهٔ ارائه اضافه کنید و به صورت یک فایل PPTX ذخیره کنید.

```java
import com.aspose.slides.*;

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

ذخیرهٔ نتیجه با نام جدید، فایل منبع بدون امضا را حفظ می‌کند. مقداری که توسط [IDigitalSignature.setComments](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) تنظیم می‌شود، هدف امضا را توصیف می‌کند؛ این یک کنترل امنیتی نیست.

## **اعتبارسنجی امضاهای دیجیتال**

هنگامی که یک فایل PPTX امضاشده را بارگذاری می‌کنید، هر موردی که توسط [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) بازگردانده می‌شود، بررسی کنید. متد [IDigitalSignature.isValid](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignature/#isValid--) نشان می‌دهد که آیا امضای توکار برای محتوای فعلی ارائه معتبر است یا خیر.

```java
import com.aspose.slides.*;

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

نتیجهٔ نامعتبر معمولاً به این معناست که محتوای ارائه‌امضاشده یا دادهٔ امضا پس از امضا تغییر کرده‌اند، یا اینکه فایل آسیب دیده است. حذف همهٔ امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین بررسی فقط صحت موارد کافی نیست: یک جریان کاری حساس به امنیت باید همچنین تعداد انتظارامضاها و هویت‌های امضاکنندگان مورد انتظار را تأیید کند.

این نتیجهٔ اعتبار نباید به عنوان تصمیم کامل در مورد اعتماد به گواهی در نظر گرفته شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز داشته باشد زنجیرهٔ گواهی X.509 را ساخته و اعتبارسنجی کند، تاریخ‌های اعتبار گواهی و وضعیت لغو را بررسی کند، موضوع یا اثر انگشت مورد انتظار را تأیید کند، استفاده از کلید را بررسی کند و یک مهر زمان مورد اعتماد را ارزیابی کند. مقدار [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) به تنهایی اثری از مرجع مهر زمان مورد اعتماد نیست.

## **حذف امضاهای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضاشده را بارگذاری می‌کند، تمام امضاها را با [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) حذف می‌کند و یک نسخهٔ بدون امضا را ذخیره می‌کند.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای حذف فقط یک امضا، با استفاده از اندیس صفر‑مبنا، متد [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) را فراخوانی کنید. مگر آنکه بازنویسی فایل اصلی امضاشده بخشی صریح از جریان کاری شما باشد، به یک فایل جدید ذخیره کنید.

## **نکات ویرایش و قالب‌بندی**

- یک امضا ارائه را به حالت فقط‑خواندنی تبدیل نمی‌کند. کاربران و برنامه‌ها هنوز می‌توانند فایل را ویرایش کنند، اما تغییرات در محتوای امضاشده معمولاً امضای موجود را نامعتبر می‌کند.
- تمام ویرایش‌های مورد نظر را قبل از امضا انجام دهید. اگر لازم باشد ارائه تغییر کند، نسخهٔ بازبینی‌شده را ذخیره کنید و دوباره آن را امضا کنید.
- خروجی نهایی را در قالب PPTX نگه دارید. تبدیل یک ارائهٔ امضاشده به قالب دیگر امضای اصلی PPTX را به عنوان امضای معتبر برای فایل تبدیل‌شده منتقل نمی‌کند.
- کلید خصوصی گواهی را به عنوان اطلاعات حساس در نظر بگیرید. هر کس که کلید خصوصی و رمز عبور آن را به دست آورد، ممکن است بتواند امضاهایی ایجاد کند که به نظر می‌رسد از طرف صاحب گواهی باشد.
- در صورتی که سیاست نگهداری اسناد شما نیاز داشته باشد، منبع بدون امضا یا یک نسخهٔ کنترل‌شدهٔ دیگر را حفظ کنید.

## **سوالات متداول**

**آیا امضای دیجیتال ارائه را رمزنگاری می‌کند؟**

خیر. امضای دیجیتال شواهدی دربارهٔ منشا و یکپارچگی ارائه فراهم می‌کند، اما محتویات ارائه قابل خواندن باقی می‌ماند مگر آنکه رمزنگاری جداگانه‌ای اعمال شود. هنگام نیاز به محدود کردن دسترسی به محتوا از [حفاظت با رمز عبور](/slides/fa/androidjava/password-protected-presentation/) استفاده کنید.

**آیا رمز عبور PFX همان رمز عبور ارائه است؟**

خیر. رمز عبور PFX کلید خصوصی ذخیره‌شده در بسته گواهی را باز می‌کند. این رمز عبور تعیین نمی‌کند که چه کسی می‌تواند فایل PPTX را باز یا ویرایش کند.

**آیا می‌توانم از گواهی خودامضا استفاده کنم؟**

از نظر فنی، گواهی خودامضا می‌تواند استفاده شود وقتی کلید خصوصی قابل دسترسی دارد. با این حال، دریافت‌کنندگان به‌صورت خودکار به آن اعتماد نمی‌کنند مگر اینکه این گواهی به‌صورت صریح به محیط مورد اعتماد آن‌ها افزوده شده باشد. در معمولاً جریان‌های کاری عمومی یا میان‌سازمانی از گواهی صادرشده توسط یک CA مورد اعتماد استفاده می‌شود.

**چه چیزی باعث نامعتبر بودن یک امضا می‌شود؟**

تغییر محتوای ارائهٔ امضاشده یا دادهٔ امضا پس از امضا می‌تواند امضا را نامعتبر کند. فساد فایل نیز می‌تواند باعث شکست اعتبارسنجی شود. اگر تمام امضاها حذف شوند، ارائه بدون امضا خواهد بود نه اینکه فایلی حاوی امضای نامعتبر باشد.

**آیا یک امضای معتبر به این معنی است که باید به امضاکننده اعتماد کنم؟**

خود به خود نه. یکپارچگی امضا و اعتماد به امضاکننده تصمیم‌های جداگانه‌ای هستند. یک سیاست اعتبارسنجی در تولید باید علاوه بر این، زنجیرهٔ گواهی، دورهٔ اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هر نیاز به مهر زمان مورد اعتماد را نیز بررسی کند.

**چه اتفاقی می‌افتد وقتی گواهی منقضی می‌شود؟**

منقضی شدن گواهی بایت‌های ارائه را تغییر نمی‌دهد، اما ارزیابی اعتماد به گواهی را تحت تأثیر قرار می‌دهد. اینکه آیا امضا همچنان قابل قبول است بستگی به سیاست شما و این دارد که آیا یک مهر زمان معتبر و مورد اعتماد اثبات می‌کند امضا در زمانی انجام شده که گواهی معتبر بوده است یا خیر. فقط به زمان نمایش داده‌شدهٔ امضا به‌عنوان یک مهر زمان مورد اعتماد اعتماد نکنید.

**آیا یک ارائهٔ امضاشده هنوز می‌تواند ویرایش شود؟**

بله. امضا کردن فایل را قفل نمی‌کند. ویرایش محتوای امضاشده معمولاً امضای موجود را نامعتبر می‌کند، بنابراین ابتدا ارائه را تکمیل کنید و سپس نسخهٔ نهایی را امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. قبل از ذخیره‌سازی، هر امضا را به مجموعه‌ای که توسط [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) برگردانده می‌شود، اضافه کنید. هنگام اعتبارسنجی، هر امضا را بررسی کرده و تأیید کنید که همه امضاکنندگان مورد نیاز حضور دارند.

**کدام قالب‌های ارائه از این عملیات پشتیبانی می‌کنند؟**

Aspose.Slides فقط برای قالب PPTX از عملیات امضای دیجیتال توصیف‌شده در اینجا پشتیبانی می‌کند. قالب‌های PPT و ارائه OpenDocument توسط این جریان کاری API پشتیبانی نمی‌شوند.

**آیا می‌توانم امضا را حذف کنم بدون اینکه بر اسلایدها تأثیر بگذارد؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را پاک کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها همچنان در دسترس است، اما فایل ذخیره‌شده دیگر شواهد امضای حذف‌شده را حمل نمی‌کند.