---
title: افزودن امضاهای دیجیتال به ارائه‌ها در .NET
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/net/digital-signature-in-powerpoint/
keywords:
- امضای دیجیتال
- گواهی دیجیتال
- مرجع گواهی‌نامه
- گواهی‌نامه PFX
- PKCS#12
- اعتبارسنجی امضا
- PowerPoint
- PPTX
- امنیت ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PPTX موجود را با گواهی‌نامه‌های PFX امضا کنید و از Aspose.Slides برای .NET برای اعتبارسنجی یا حذف امضاهای دیجیتال استفاده کنید."
---
## **مروری کلی**

یک امضای دیجیتال به گیرنده کمک می‌کند تا مشخص کند چه کسی ارائه را امضا کرده و آیا محتوای امضا شده تغییر کرده است. سه مفهوم امنیتی مرتبط در اینجا مهم‌اند:

- یک **گواهی دیجیتال** یک اعتبار الکترونیکی است که یک هویت را به کلید عمومی مرتبط می‌کند. یک مرجع گواهی‌نامه (CA) معتبر می‌تواند گواهی‌نامه‌ای صادر کند، یا یک سازمان می‌تواند برای جریان‌های کار داخلی از گواهی‌نامه خودامضاء استفاده کند.
- یک **امضای دیجیتال** از محتوای ارائه و کلید خصوصی دارنده گواهی‌نامه ایجاد می‌شود. سپس می‌توان از کلید عمومی گواهی‌نامه برای تأیید امضا استفاده کرد. امضا شواهدی از مبدأ و یکپارچگی ارائه می‌دهد؛ اما محتوا را رمزنگاری نمی‌کند.
- **حفاظت با رمز عبور** تعیین می‌کند که آیا کاربر می‌تواند ارائه را باز یا ویرایش کند. این موضوع جدا از امضای دیجیتال است و در بخش [ارائه‌های محافظت‌شده با رمز عبور](/net/password-protected-presentation/) توضیح داده شده است.

PowerPoint فرمان **Add a Digital Signature** را تحت **File > Info > Protect Presentation** فراهم می‌کند.

![منوی Protect Presentation در PowerPoint که Add a Digital Signature را برجسته کرده است](add-digital-signature-in-powerpoint.png)

پس از باز کردن یک ارائه امضا شده، PowerPoint می‌تواند یک اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint که می‌گوید ارائه شامل امضاهای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/digitalsignatures/)، یک [IDigitalSignatureCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignaturecollection/) که موارد آن پیاده‌سازی [IDigitalSignature](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignature/) هستند، در دسترس می‌گذارد. یک ارائه می‌تواند شامل چندین امضا باشد.

## **درک گواهی‌نامه‌های PFX و رمزهای عبور**

فایل PFX که به عنوان فایل PKCS#12 نیز شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی‌نامه X.509، کلید خصوصی آن و زنجیره گواهی‌نامه باشد. کلید خصوصی همان چیزی است که به دارنده اجازه می‌دهد امضا تولید کند. گواهی‌نامه‌ای بدون دسترسی به کلید خصوصی نمی‌تواند برای امضای ارائه استفاده شود.

رمز عبور PFX بسته گواهی‌نامه و کلید خصوصی را محافظت می‌کند. این **رمز عبوری** برای باز یا ویرایش ارائه نیست. فایل‌های PFX یا رمزهای عبور آن‌ها را به مخزن کد (source control) اضافه نکنید. در محیط تولید، دسترسی به فایل گواهی‌نامه محدود شود و رمز عبور آن از یک مخزن محرمانه یا منبع پیکربندی محافظت‌شده دریافت شود. مثال‌های زیر فقط برای جلوگیری از تعبیه مستقیم رمز عبور در کد، از یک متغیر محیطی استفاده می‌کنند.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک جریان کاری واقعی، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/net/aspose.slides/digitalsignature/) از گواهی‌نامه PFX و رمز عبور آن ایجاد کنید، امضا را به مجموعه امضاهای ارائه اضافه کنید و در نهایت به صورت فایل PPTX ذخیره کنید.

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

ذخیره نتایج تحت نام جدید، فایل منبع بدون امضا را حفظ می‌کند. مقدار [DigitalSignature.Comments](https://reference.aspose.com/slides/fa/net/aspose.slides/digitalsignature/comments/) هدف امضا را شرح می‌دهد؛ این یک کنترل امنیتی نیست.

## **اعتبارسنجی امضاهای دیجیتال**

زمانی که یک فایل PPTX امضا شده را بارگذاری می‌کنید، هر مورد در [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/digitalsignatures/) را بررسی کنید. ویژگی [IDigitalSignature.IsValid](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignature/isvalid/) نشان می‌دهد که آیا امضای جاسازی‌شده برای محتوای فعلی ارائه معتبر است یا خیر.

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

نتیجه‌ی نامعتبر معمولاً به این معنی است که محتویات ارائه یا داده‌های امضا پس از امضا تغییر کرده‌اند، یا فایل آسیب‌دیده است. حذف تمام امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین فقط بررسی اعتبار موارد کافی نیست: یک جریان کاری حساس به امنیت باید همچنین تعداد مورد انتظار امضاها و هویت‌های امضاکنندگان مورد انتظار را نیز تأیید کند.

این نتیجه‌ی اعتبارسنجی نباید به‌عنوان تصمیم نهایی در مورد اعتماد به گواهی‌نامه در نظر گرفته شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز به ساخت و اعتبارسنجی زنجیره گواهی‌نامه X.509، بررسی تاریخ‌های اعتبار گواهی‌نامه و وضعیت لغو، تأیید موضوع یا اثر انگشت مورد انتظار، بررسی استفاده از کلید و ارزیابی یک مهر زمانی معتبر داشته باشد. مقدار [IDigitalSignature.SignTime](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignature/signtime/) به تنهایی اثباتی از یک مرجع مهر زمانی معتبر نیست.

## **حذف امضای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضا شده را بارگذاری می‌کند، تمام امضاها را با استفاده از [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignaturecollection/clear/) حذف می‌کند و یک نسخه بدون امضا ذخیره می‌نماید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

برای حذف تنها یک امضا، می‌توانید با استفاده از شاخص صفر‐پایه آن، متد [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/fa/net/aspose.slides/idigitalsignaturecollection/removeat/) را صدا بزنید. مگر این‌که حذف مستقیم امضای اصلی جزء واضحی از جریان کاری شما باشد، بهتر است به‌جای بازنویسی فایل اصلی، به یک فایل جدید ذخیره کنید.

## **ملاحظات ویرایش و قالب‌بندی**

- امضا باعث نمی‌شود ارائه فقط‑خواندنی شود. کاربران و برنامه‌ها همچنان می‌توانند فایل را ویرایش کنند، اما تغییر در محتواهای امضا شده معمولاً امضای موجود را نامعتبر می‌کند.
- همه ویرایش‌های مورد نظر را پیش از امضا انجام دهید. اگر نیاز به تغییر ارائه باشد، نسخه اصلاح‌شده را ذخیره کنید و دوباره امضا کنید.
- خروجی نهایی را در قالب PPTX نگه دارید. تبدیل یک ارائه امضا شده به قالب دیگر، امضای اصلی PPTX را به‌عنوان امضای معتبر برای فایل تبدیل‌شده منتقل نمی‌کند.
- کلید خصوصی گواهی‌نامه را به‌عنوان اطلاعات حساسی در نظر بگیرید. هر کس به کلید خصوصی و رمز عبور آن دست یابد می‌تواند امضاهایی تولید کند که به‌نظر می‌رسد از طرف دارنده گواهی‌نامه باشد.
- هنگامیکه سیاست نگهداری اسناد شما این‌کار را می‌طلبد، منبع بدون امضا یا یک نسخه کنترل‌شده دیگر را نگه دارید.

## **سوالات متداول**

**آیا امضای دیجیتال ارائه را رمزنگاری می‌کند؟**

خیر. امضای دیجیتال شواهدی درباره مبداء و یکپارچگی ارائه فراهم می‌کند، اما محتوا همچنان خوانا می‌ماند مگر اینکه رمزنگاری جداگانه‌ای اعمال شود. وقتی دسترسی به محتوا باید محدود شود، از [حفاظت با رمز عبور](/net/password-protected-presentation/) استفاده کنید.

**آیا رمز عبور PFX همان رمز عبور ارائه است؟**

خیر. رمز عبور PFX کلید خصوصی ذخیره‌شده در بسته گواهی‌نامه را باز می‌کند. این رمز عبور کنترل‌کنندهٔ باز یا ویرایش فایل PPTX نیست.

**آیا می‌توانم از گواهی‌نامه خودامضاء استفاده کنم؟**

فنیاً، وقتی شامل کلید خصوصی قابل دسترسی باشد، می‌توان از گواهی‌نامه خودامضاء استفاده کرد. دریافت‌کنندگان به‌صورت خودکار به آن اعتماد نمی‌کنند، مگر اینکه گواهی‌نامه به‌صورت صریح به محیط مطمئن آن‌ها اضافه شده باشد. جریان‌های کاری عمومی یا میان‌سازمانی معمولاً از گواهی‌نامه صادر‌شده توسط یک CA معتبر استفاده می‌کنند.

**چه چیزی باعث می‌شود یک امضا نامعتبر شود؟**

تغییر محتویات ارائهٔ امضا شده یا داده‌های امضا پس از امضا، امضا را نامعتبر می‌کند. خراب شدن فایل نیز می‌تواند باعث عدم اعتبارسنجی شود. اگر تمام امضاها حذف شوند، ارائه بدون امضا باقی می‌ماند نه اینکه حاوی امضای نامعتبر باشد.

**آیا یک امضای معتبر به این معناست که باید به امضاکننده اعتماد کرد؟**

خیر. صحت امضا و اعتماد به امضاکننده تصمیم‌های جداگانه‌ای هستند. یک سیاست اعتبارسنجی تولیدی باید همچنین زنجیره گواهی‌نامه، دورهٔ اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هر نیاز به مهر زمانی معتبر را بررسی کند.

**هنگامی که گواهی‌نامه منقضی می‌شود چه اتفاقی می‌افتد؟**

انقضای گواهی‌نامه محتوای بایت‌های ارائه را تغییر نمی‌دهد، اما ارزیابی اعتماد به گواهی‌نامه را تحت تأثیر قرار می‌دهد. اینکه آیا امضا همچنان قابل قبول باشد بستگی به سیاست شما و این دارد که آیا یک مهر زمانی معتبر نشان می‌دهد امضا هنگام اعتبار گواهی‌نامه انجام شده است یا خیر. فقط به زمان نمایش داده‌شدهٔ امضا به‌عنوان مهر زمانی معتبر اعتماد نکنید.

**آیا یک ارائهٔ امضا شده می‌تواند ویرایش شود؟**

بله. امضاکنندۀ فایل را قفل نمی‌کند. ویرایش محتویات امضا شده معمولاً امضای موجود را نامعتبر می‌کند، بنابراین ابتدا ارائه را نهایی کنید و سپس امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. قبل از ذخیره، هر امضا را به [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/digitalsignatures/) اضافه کنید. در زمان اعتبارسنجی، هر امضا را بررسی کنید و اطمینان حاصل کنید تمام امضاکنندگان مورد نیاز موجودند.

**کدام فرمت‌های ارائه از این عملیات پشتیبانی می‌کنند؟**

Aspose.Slides تنها برای فرمت PPTX عملیات امضای دیجیتال توصیف‌شده در اینجا را پشتیبانی می‌کند. فرمت‌های PPT و OpenDocument پشتیبانی‌نشده‌اند.

**آیا می‌توانم یک امضا را حذف کنم بدون اینکه اسلایدها تحت‌تأثیر قرار گیرند؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را پاک کنید و سپس ارائه را ذخیره کنید. محتویات اسلایدها باقی می‌ماند، اما فایل ذخیره‌شده دیگر شواهد امضای حذف‌شده را حمل نمی‌کند.