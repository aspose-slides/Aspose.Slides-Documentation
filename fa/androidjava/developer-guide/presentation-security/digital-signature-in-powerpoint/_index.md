---
title: افزودن امضاهای دیجیتال به ارائه‌ها در اندروید
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/androidjava/digital-signature-in-powerpoint/
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
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PPTX موجود را با گواهی‌های PFX امضا کنید و از Aspose.Slides برای اندروید از طریق جاوا برای اعتبارسنجی یا حذف امضاهای دیجیتال استفاده کنید."
---
## **بررسی کلی**

یک امضای دیجیتال به گیرنده کمک می‌کند تعیین کند چه کسی ارائه را امضا کرده و آیا محتوای امضا شده تغییر کرده است. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- یک **گواهی دیجیتال** اعتبارنامهٔ الکترونیکی است که یک هویت را با یک کلید عمومی مرتبط می‌کند. یک مرجع گواهی مورد اعتماد (CA) می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند برای گردش‌های کاری داخلی از یک گواهی خودامضا استفاده کند.
- یک **امضای دیجیتال** از محتوای ارائه و کلید خصوصی دارندهٔ گواهی ساخته می‌شود. سپس کلید عمومی گواهی می‌تواند برای تأیید امضا استفاده شود. امضا شواهدی از منبع و یکپارچگی فراهم می‌کند؛ اما ارائه را رمزنگاری نمی‌کند.
- **حفاظت با رمز عبور** کنترل می‌کند که آیا کاربر می‌تواند ارائه را باز یا ویرایش کند. این مورد جدا از امضای دیجیتال است و در [ارائه‌های محافظت‌شده با رمز عبور](/androidjava/password-protected-presentation/) توضیح داده شده است.

PowerPoint فرمان **Add a Digital Signature** را در زیرمنوی **File > Info > Protect Presentation** ارائه می‌دهد.

![منوی Protect Presentation در PowerPoint که گزینه Add a Digital Signature را برجسته کرده است](add-digital-signature-in-powerpoint.png)

پس از باز شدن یک ارائهٔ امضا شده، PowerPoint می‌تواند اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint که نشان می‌دهد ارائه دارای امضاهای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) فراهم می‌کند، که یک [IDigitalSignatureCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignaturecollection/) را برمی‌گرداند که آیتم‌های آن پیاده‌ساز [IDigitalSignature](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignature/) هستند. یک ارائه می‌تواند شامل چندین امضا باشد.

## **درک گواهی‌های PFX و رمزهای عبور**

یک فایل PFX، که همچنین به عنوان فایل PKCS#12 شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیرهٔ گواهی باشد. کلید خصوصی همان چیزی است که به دارنده اجازه می‌دهد امضا ایجاد کند. گواهی بدون کلید خصوصی قابل دسترس نمی‌تواند برای امضای ارائه استفاده شود.

رمز عبور PFX بستهٔ گواهی و کلید خصوصی را محافظت می‌کند. این **رمز عبور برای باز کردن یا ویرایش ارائه نیست**. فایل‌های PFX یا رمزهای عبور آن‌ها را به مخزن کد منبع مشخص نکنید. در محیط تولید، دسترسی به فایل گواهی را محدود کنید و رمز عبور آن را از مخزن مخفی یا منبع پیکربندی محافظت‌شده دیگری دریافت کنید. مثال‌های زیر فقط برای جلوگیری از درج رمز عبور در کد، از یک متغیر محیطی استفاده می‌کنند.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک گردش کاری واقعی، یک فایل PPTX موجود را بارگیری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/digitalsignature/) از یک گواهی PFX و رمز عبور آن ایجاد کنید، امضا را به مجموعهٔ امضاهای ارائه اضافه کنید و سپس به یک فایل PPTX ذخیره کنید.

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

هنگامی که یک فایل PPTX امضا شده را بارگیری می‌کنید، هر آیتمی که توسط [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) برگردانده می‌شود را بررسی کنید. متد [IDigitalSignature.isValid](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignature/#isValid--) نشان می‌دهد آیا امضای جاسازی‌شده برای محتوای فعلی ارائه معتبر است یا خیر.

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

نتیجهٔ نامعتبر معمولاً به این معناست که محتوای ارائه یا داده‌های امضا پس از امضا تغییر کرده‌اند، یا فایل خراب شده است. حذف تمام امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین فقط بررسی اعتبار آیتم‌ها کافی نیست: یک گردش کاری حساس به امنیت باید همچنین تعداد مورد انتظار امضاها و هویت‌های امضاکنندگان مورد انتظار را تأیید کند.

این نتیجهٔ اعتبار نباید به‌عنوان تصمیم نهایی اعتماد به گواهی در نظر گرفته شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز داشته باشد زنجیرهٔ گواهی X.509 را ساخته و اعتبارسنجی کند، تاریخ‌های اعتبار گواهی و وضعیت لغو را بررسی کند، موضوع یا اثر انگشت مورد انتظار را تأیید کند، استفاده از کلید را ارزیابی کند و یک مهر زمان معتبر را بررسی نماید. مقدار برگشتی از [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) به تنهایی اثباتی از یک مرجع مهر زمان معتبر نیست.

## **حذف امضاهای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضا شده را بارگیری می‌کند، تمام امضاها را با استفاده از [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) حذف می‌کند و یک نسخهٔ بدون امضا را ذخیره می‌کند.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای حذف تنها یک امضا، متد [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) را با اندیس صفر‑محور آن صدا بزنید. مگر این‌که حذف امضای اصلی بخش صریحی از گردش کاری شما باشد، به‌جای بازنویسی فایل اصلی، به یک فایل جدید ذخیره کنید.

## **ملاحظات ویرایش و فرمت**

- یک امضا فایل را فقط‑خواندنی نمی‌کند. کاربران و برنامه‌ها هنوز می‌توانند فایل را ویرایش کنند، اما تغییر در محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌سازد.
- تمام ویرایش‌های موردنظر را قبل از امضا انجام دهید. اگر ارائه باید تغییر کند، نسخهٔ اصلاح‌شده را ذخیره کنید و آن بازنگری را دوباره امضا کنید.
- خروجی نهایی را در قالب PPTX نگه دارید. تبدیل یک ارائهٔ امضا شده به قالب دیگری، امضای اصلی PPTX را به‌عنوان امضای معتبر برای فایل تبدیل‌شده منتقل نمی‌کند.
- کلید خصوصی گواهی را به‌عنوان اطلاعات حساس در نظر بگیرید. هر کسی که کلید خصوصی و رمز عبور آن را به دست آورد، می‌تواند امضاهایی ایجاد کند که گویی از طرف دارندهٔ گواهی هستند.
- در صورتی که سیاست نگهداری سند شما این امر را می‌طلبد، منبع بدون امضا یا یک نسخهٔ کنترل‌شده دیگر را نگه دارید.

## **سؤالات متداول**

**آیا امضای دیجیتال ارائه را رمزنگاری می‌کند؟**

خیر. امضای دیجیتال شواهدی دربارهٔ منبع و یکپارچگی فراهم می‌کند، اما محتوای ارائه همچنان قابل خواندن است مگر اینکه رمزنگاری جداگانه‌ای اعمال شود. هنگامی که دسترسی به محتوا باید محدود شود، از [حفاظت با رمز عبور](/androidjava/password-protected-presentation/) استفاده کنید.

**آیا رمز عبور PFX همان رمز عبور ارائه است؟**

خیر. رمز عبور PFX کلید خصوصی ذخیره‌شده در بستهٔ گواهی را باز می‌کند. این رمز عبور کنترل نمی‌کند که چه کسی می‌تواند فایل PPTX را باز یا ویرایش کند.

**آیا می‌توانم از یک گواهی خودامضا استفاده کنم؟**

به‌صورت فنی، یک گواهی خودامضا می‌تواند استفاده شود مشروط بر این‌که شامل یک کلید خصوصی قابل دسترس باشد. دریافت‌کنندگان به‌طور خودکار به آن اعتماد نخواهند کرد مگر اینکه این گواهی به‌طور صریح به محیط مورد اعتماد آن‌ها اضافه شده باشد. گردش‌های کاری عمومی یا بین‌سازمانی معمولاً از گواهی صادرشده توسط یک CA معتبر استفاده می‌کنند.

**چه چیزی باعث می‌شود یک امضا نامعتبر شود؟**

تغییر محتویات ارائهٔ امضا شده یا داده‌های امضا پس از امضا، امضا را نامعتبر می‌کند. خراب شدن فایل نیز می‌تواند باعث عدم اعتبارسنجی شود. اگر تمام امضاها حذف شوند، ارائه بدون امضا است نه اینکه دارای امضای نامعتبر باشد.

**آیا یک امضای معتبر به این معنی است که باید به امضاکننده اعتماد کرد؟**

خودامضا کافی نیست. یک امضای معتبر نشان‌دهندهٔ یکپارچگی است، اما تصمیم دربارهٔ اعتماد به امضاکننده جداست. یک سیاست اعتبارسنجی در محیط تولید باید زنجیرهٔ گواهی، دورهٔ اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هر نیاز به مهر زمان معتبر را نیز بررسی کند.

**وقتی گواهی منقضی می‌شود چه اتفاقی می‌افتد؟**

منقضی شدن گواهی بر بایت‌های ارائه تأثیری ندارد، اما ارزیابی اعتماد به گواهی را تحت تأثیر قرار می‌دهد. اینکه آیا یک امضا همچنان قابل قبول باشد بستگی به سیاست شما و این دارد که آیا یک مهر زمان معتبر ثابت می‌کند امضا در زمان اعتبار گواهی انجام شده است یا خیر. فقط به زمان نمایش‌داده‌شدهٔ امضا برای به‌عنوان مهر زمان معتبر اکتفا نکنید.

**آیا می‌توان یک ارائهٔ امضا شده را ویرایش کرد؟**

بله. امضا کردن فایل را قفل نمی‌کند. ویرایش محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌سازد، بنابراین ابتدا ارائه را کامل کنید و سپس نسخهٔ نهایی را امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. هر امضا را قبل از ذخیره‌سازی به مجموعه‌ای که توسط [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) برگردانده می‌شود، اضافه کنید. در زمان اعتبارسنجی، هر امضا را بررسی و اطمینان حاصل کنید که همه امضاکنندگان مورد نیاز حضور دارند.

**کدام قالب‌های ارائه از این عملیات‌ها پشتیبانی می‌کنند؟**

Aspose.Slides عملیات‌های امضای دیجیتال توصیف‌شده در اینجا را فقط برای قالب PPTX پشتیبانی می‌کند. قالب‌های PPT و OpenDocument پشتیبانی نمی‌شوند.

**آیا می‌توانم یک امضا را حذف کنم بدون اینکه اسلایدها تحت تأثیر قرار گیرند؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را پاک کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها همچنان موجود است، اما فایل ذخیره‌شده دیگر شواهد امضای حذف‌شده را در بر ندارد.