---
title: افزودن امضای دیجیتال به ارائه‌ها در .NET
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/net/digital-signature-in-powerpoint/
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
- .NET
- C#
- Aspose.Slides
description: "نحوه امضای ارائه‌های PPTX موجود با گواهی‌های PFX و استفاده از Aspose.Slides برای .NET برای اعتبارسنجی یا حذف امضاهای دیجیتال را بیاموزید."
---
## **مرور کلی**

یک امضای دیجیتال به گیرنده این امکان را می‌دهد که تعیین کند چه کسی ارائه را امضا کرده و آیا محتوای امضا شده تغییر کرده است. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- **گواهی دیجیتال** یک اعتبار الکترونیکی است که یک هویت را با یک کلید عمومی مرتبط می‌کند. یک مرجع گواهی معتبر (CA) می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند برای گردش‌های داخلی از گواهی خودامضا استفاده کند.
- **امضای دیجیتال** از محتوای ارائه و کلید خصوصی دارنده گواهی ایجاد می‌شود. سپس می‌توان از کلید عمومی گواهی برای تأیید امضا استفاده کرد. امضا مدرکی از منبع و یکپارچگی فراهم می‌کند؛ اما ارائه را رمزنگاری نمی‌کند.
- **حفاظت با رمز عبور** تعیین می‌کند که آیا کاربر می‌تواند یک ارائه را باز یا ویرایش کند. این مورد جدا از امضای دیجیتال است و در [ارائه‌های محافظت‌شده با رمز عبور](/slides/fa/net/password-protected-presentation/) توصیف شده است.

PowerPoint فرمان **Add a Digital Signature** را تحت **File > Info > Protect Presentation** فراهم می‌کند.

![منوی Protect Presentation در PowerPoint با Add a Digital Signature برجسته شده](add-digital-signature-in-powerpoint.png)

پس از باز شدن یک ارائه امضا شده، PowerPoint می‌تواند یک اعلان وضعیت امضا نمایش دهد.

![اعلان PowerPoint که نشان می‌دهد ارائه حاوی امضاهای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/digitalsignatures/)، یک [IDigitalSignatureCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignaturecollection/) که آیتم‌های آن پیاده‌سازی [IDigitalSignature](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignature/) را دارند، فراهم می‌کند. یک ارائه می‌تواند شامل چندین امضا باشد.

## **درک گواهی‌های PFX و رمزهای عبور**

یک فایل PFX که به عنوان فایل PKCS#12 شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیره گواهی باشد. کلید خصوصی همان چیزی است که به دارنده اجازه می‌دهد امضا ایجاد کند. گواهی بدون کلید خصوصی قابل دسترس نمی‌تواند برای امضای یک ارائه استفاده شود.

رمز عبور PFX بسته گواهی و کلید خصوصی را محافظت می‌کند. این **رمز عبور** برای باز کردن یا ویرایش ارائه نیست. فایل‌های PFX یا رمزهای عبور آن‌ها را به مخزن کد منبع تعهد نکنید. در تولید، دسترسی به فایل گواهی را محدود کنید و رمز عبور آن را از یک مخزن راز یا منبع پیکربندی محافظت‌شده دیگری دریافت کنید. مثال‌های زیر فقط برای جلوگیری از جاسازی رمز عبور در کد، از یک متغیر محیطی استفاده می‌کنند.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک گردش‌کار واقعی، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/net/aspose.slides/digitalsignature/) از یک گواهی PFX و رمز عبور آن ایجاد کنید، امضا را به مجموعه ارائه اضافه کنید و به یک فایل PPTX ذخیره کنید.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

ذخیره نتیجه با نامی جدید، فایل منبع بدون امضا را حفظ می‌کند. مقدار [DigitalSignature.Comments](https://reference.aspose.com/slides/fa/net/aspose.slides/digitalsignature/comments/) هدف امضا را توصیف می‌کند؛ این یک کنترل امنیتی نیست.

## **اعتبارسنجی امضای دیجیتال**

زمانی که یک فایل PPTX امضا شده را بارگذاری می‌کنید، هر آیتم در [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/digitalsignatures/) را بررسی کنید. ویژگی [IDigitalSignature.IsValid](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignature/isvalid/) نشان می‌دهد آیا امضای جاسازی‌شده برای محتوای فعلی ارائه معتبر است یا خیر.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

نتیجه نامعتبر معمولاً به این معناست که محتوای ارائه امضا شده یا داده‌های امضا پس از امضا تغییر کرده‌اند، یا فایل آسیب دیده است. حذف تمام امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین فقط بررسی اعتبار آیتم‌ها کافی نیست: یک گردش‌کار حساس به امنیت باید همچنین اطمینان حاصل کند که تعداد مورد انتظار امضاها و هویت‌های امضاکنندگان مورد انتظار حضور دارند.

این نتیجه اعتبار نباید به عنوان تصمیم کامل اعتماد به گواهی در نظر گرفته شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز داشته باشد زنجیره گواهی X.509 را بسازد و اعتبارسنجی کند، تاریخ‌های اعتبار گواهی و وضعیت لغو را بررسی کند، موضوع یا اثر انگشت مورد انتظار را تأیید کند، استفاده از کلید را بررسی کند و یک نشان زمان‌مورد اعتماد را ارزیابی کند. مقدار [IDigitalSignature.SignTime](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignature/signtime/) به تنهایی اثباتی از یک مرجع زمان‌مورد اعتماد نیست.

## **حذف امضای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضا شده را بارگذاری می‌کند، تمام امضاها را با [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignaturecollection/clear/) حذف می‌کند و یک کپی بدون امضا ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

برای حذف تنها یک امضا، با ایندکس صفر‑محور آن، [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignaturecollection/removeat/) را فراخوانی کنید. مگر اینکه حذف امضای اصلی بخشی صریح از گردش‌کار شما باشد، به یک فایل جدید ذخیره کنید نه اینکه فایل اصلی را بازنویسی کنید.

## **ملاحظات ویرایش و قالب**

- یک امضا فایل ارائه را به حالت فقط‑خواندنی تبدیل نمی‌کند. کاربران و برنامه‌ها همچنان می‌توانند فایل را ویرایش کنند، اما تغییر در محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌کند.
- تمام ویرایش‌های مورد نظر را قبل از امضا انجام دهید. اگر نیاز به تغییر ارائه باشد، نسخه اصلاح‌شده را ذخیره کرده و دوباره امضا کنید.
- خروجی نهایی را در قالب PPTX نگه دارید. تبدیل یک ارائه امضا شده به قالب دیگر امضای اصلی PPTX را به عنوان امضای معتبر برای فایل تبدیل‑شده منتقل نمی‌کند.
- کلید خصوصی گواهی را حساسی در نظر بگیرید. هرکسی که به کلید خصوصی و رمز عبور آن دست پیدا کند، می‌تواند امضاهایی ایجاد کند که به نظر می‌رسد از طرف دارنده گواهی باشد.
- هنگامیکه سیاست نگهداری اسناد شما ایجاب می‌کند، منبع بدون امضا یا یک کپی کنترل‌شده را نگه دارید.

## **سوالات متداول**

**آیا امضای دیجیتال ارائه را رمزنگاری می‌کند؟**

نه. امضای دیجیتال مدرکی از منبع و یکپارچگی فراهم می‌کند، اما محتوای ارائه همچنان قابل خواندن است مگر اینکه رمزنگاری جداگانه‌ای اعمال شود. برای محدود کردن دسترسی به محتوا از [حفاظت با رمز عبور](/slides/fa/net/password-protected-presentation/) استفاده کنید.

**آیا رمز عبور PFX همان رمز عبور ارائه است؟**

نه. رمز عبور PFX کلید خصوصی ذخیره شده در بسته گواهی را باز می‌کند. این رمز عبور کنترل نمی‌کند که چه کسی می‌تواند فایل PPTX را باز یا ویرایش کند.

**آیا می‌توانم از یک گواهی خودامضا استفاده کنم؟**

از نظر فنی، یک گواهی خودامضا می‌تواند استفاده شود اگر شامل کلید خصوصی قابل دسترس باشد. با این حال، دریافت‌کنندگان به طور خودکار به آن اعتماد نمی‌کنند مگر اینکه گواهی صریحاً به محیط مورد اعتماد آنها اضافه شده باشد. گردش‌کارهای عمومی یا بین‌سازمانی معمولاً از گواهی صادرشده توسط یک CA معتبر استفاده می‌کنند.

**چه چیزی باعث نامعتبر شدن یک امضا می‌شود؟**

تغییر محتوای ارائه امضا شده یا داده‌های امضا پس از امضا می‌تواند امضا را نامعتبر کند. خراب شدن فایل نیز ممکن است اعتبارسنجی را ناموفق کند. اگر تمام امضاها حذف شوند، ارائه بدون امضا است نه اینکه حاوی امضای نامعتبر باشد.

**آیا یک امضای معتبر به این معنی است که باید به امضاکننده اعتماد کرد؟**

خیر. اعتبار امضا و اعتماد به امضاکننده تصمیمات جداگانه‌ای هستند. یک سیاست اعتبارسنجی تولیدی باید علاوه بر بررسی یکپارچگی امضا، زنجیره گواهی، دوره اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هر نیاز به نشان زمان‌مورد اعتماد را نیز بررسی کند.

**وقتی گواهی منقضی می‌شود چه اتفاقی می‌افتد؟**

منقضی شدن گواهی محتویات بایت‌های ارائه را تغییر نمی‌دهد، اما ارزیابی اعتماد به گواهی را تحت تأثیر قرار می‌دهد. اینکه آیا یک امضا هنوز قابل قبول است یا نه، بستگی به سیاست شما و این دارد که آیا یک نشان زمان‌مورد اعتماد معتبر وجود دارد که ثابت کند امضا در زمان فعال بودن گواهی انجام شده است یا خیر. فقط بر زمان امضای نمایش داده‌شده به عنوان یک نشان زمان‑مورد اعتماد تکیه نکنید.

**آیا یک ارائه امضا شده می‌تواند ویرایش شود؟**

بله. امضا کردن فایل را قفل نمی‌کند. ویرایش محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌کند، بنابراین ابتدا ارائه را نهایی کنید و سپس امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. قبل از ذخیره، هر امضا را به [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/digitalsignatures/) اضافه کنید. در هنگام اعتبارسنجی، هر امضا را بررسی کنید و تأیید کنید که تمام امضاکنندگان مورد نیاز حضور دارند.

**کدام قالب‌های ارائه از این عملیات پشتیبانی می‌کنند؟**

Aspose.Slides تنها برای قالب PPTX عملیات امضای دیجیتال توصیف‌شده در اینجا را پشتیبانی می‌کند. قالب‌های PPT و OpenDocument پشتیبانی نمی‌شوند.

**آیا می‌توانم یک امضا را حذف کنم بدون اینکه اسلایدها تحت‌تأثیر قرار گیرند؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را پاک کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها باقی می‌ماند، اما فایل ذخیره‌شده دیگر حاوی مدرک امضای حذف‌شده نیست.