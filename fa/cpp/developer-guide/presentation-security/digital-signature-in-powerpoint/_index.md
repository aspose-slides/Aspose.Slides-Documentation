---
title: افزودن امضای دیجیتال به ارائه‌ها در C++
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/cpp/digital-signature-in-powerpoint/
keywords:
- امضای دیجیتال
- گواهی دیجیتال
- مرجع گواهی
- گواهی PFX
- PKCS#12
- اعتبارسنجی امضا
- پاورپوینت
- PPTX
- امنیت ارائه
- C++
- Aspose.Slides
description: "نحوه امضای ارائه‌های PPTX موجود با گواهی‌های PFX و استفاده از Aspose.Slides برای C++ برای اعتبارسنجی یا حذف امضای دیجیتال را بیاموزید."
---
## **مروری کلی**

یک امضای دیجیتال به گیرنده کمک می‌کند تا مشخص کند چه کسی یک ارائه را امضا کرده و آیا محتوای امضاشده تغییر کرده است. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- **گواهی دیجیتال** اعتبار الکترونیکی است که یک هویت را با یک کلید عمومی مرتبط می‌سازد. یک مرجع صدور گواهی (CA) معتبر می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند برای جریان‌های کاری داخلی از گواهی خودامضا استفاده کند.
- **امضای دیجیتال** از محتوای ارائه و کلید خصوصی دارنده گواهی ساخته می‌شود. سپس می‌توان با کلید عمومی گواهی امضا را تأیید کرد. امضا شواهدی از منشاء و یکپارچگی提供 می‌کند؛ این کار ارائه را رمزنگاری نمی‌کند.
- **حفاظت با گذرواژه** کنترل می‌کند که آیا کاربر می‌تواند ارائه را باز یا ویرایش کند. این مورد جدا از امضای دیجیتال است و در [ارائه‌های محافظت‌شده با گذرواژه](/cpp/password-protected-presentation/) توضیح داده شده است.

PowerPoint فرمان **Add a Digital Signature** را تحت **File > Info > Protect Presentation** ارائه می‌دهد.

![منوی Protect Presentation در PowerPoint با برجسته شدن Add a Digital Signature](add-digital-signature-in-powerpoint.png)

پس از باز شدن یک ارائهٔ امضاشده، PowerPoint می‌تواند اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint که نشان می‌دهد ارائه دارای امضای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_digitalsignatures/) در دسترس قرار می‌دهد که یک [IDigitalSignatureCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignaturecollection/) را بر می‌گرداند؛ موارد آن پیاده‌سازی [IDigitalSignature](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignature/) هستند. یک ارائه می‌تواند چندین امضا داشته باشد.

## **درک گواهی‌های PFX و گذرواژه‌ها**

یک فایل PFX که به عنوان فایل PKCS#12 نیز شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیره گواهی باشد. کلید خصوصی امکان ایجاد امضا را برای دارنده فراهم می‌کند. گواهی بدون یک کلید خصوصی قابل دسترس نمی‌تواند برای امضای ارائه استفاده شود.

گذرواژه PFX بستهٔ گواهی و کلید خصوصی را محافظت می‌کند. این **گذرواژه‌ای** برای باز کردن یا ویرایش ارائه نیست. فایل‌های PFX یا گذرواژه‌هایشان را به مخزن منبع اضافه نکنید. در محیط تولید، دسترسی به فایل گواهی را محدود کنید و گذرواژه را از یک مخزن‌رمز یا منبع پیکربندی محافظت‌شده دریافت کنید. مثال‌های زیر فقط به‌منظور جلوگیری از درج مستقیم گذرواژه در کد، از متغیر محیطی استفاده می‌کنند.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک جریان کاری واقعی، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/cpp/aspose.slides/digitalsignature/) از گواهی PFX و گذرواژهٔ آن ایجاد کنید، امضا را به مجموعهٔ ارائه اضافه کنید و در یک فایل PPTX ذخیره کنید.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ذخیرهٔ نتیجه با نام جدید، فایل منبع بدون امضا را حفظ می‌کند. مقدار [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignature/set_comments/) هدف امضا را توصیف می‌کند؛ این یک کنترل امنیتی نیست.

## **اعتبارسنجی امضاهای دیجیتال**

هنگامی که یک فایل PPTX امضاشده را بارگذاری می‌کنید، هر موردی که توسط [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_digitalsignatures/) برگردانده می‌شود را بررسی کنید. متد [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignature/get_isvalid/) نشان می‌دهد که آیا امضای جاسازی‌شده برای محتوای فعلی ارائه معتبر است یا خیر.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

یک نتیجهٔ نامعتبر معمولاً به این معنی است که محتوای امضاشده یا دادهٔ امضا پس از امضا تغییر کرده‌اند یا فایل خراب شده است. حذف تمام امضاها یک ارائهٔ بدون امضا تولید می‌کند، بنابراین فقط بررسی اعتبار موارد کافی نیست: یک جریان کاری حساس به امنیت باید همچنین تعداد امضاها و هویت‌های امضاکنندگان مورد انتظار را تأیید کند.

این نتیجهٔ اعتبار نباید به‌عنوان تصمیم نهایی دربارهٔ اعتماد به گواهی تلقی شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز به ساخت و اعتبارسنجی زنجیرهٔ گواهی X.509، بررسی تاریخ‌های اعتبار و وضعیت لغو، تأیید موضوع یا اثر انگشت مورد انتظار، بررسی استفاده از کلید و ارزیابی یک مهر زمانی معتبر داشته باشد. مقدار [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignature/get_signtime/) به‌تنهایی اثباتی از یک مرجع مهر زمانی معتبر نیست.

## **حذف امضاهای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضاشده را بارگذاری می‌کند، تمام امضاها را با [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignaturecollection/clear/) حذف می‌کند و یک نسخهٔ بدون امضا ذخیره می‌کند.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

برای حذف تنها یک امضا، متد [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignaturecollection/removeat/) را با ایندکس صفر‑محور آن فراخوانی کنید. مگر اینکه حذف امضای اصلی بخشی صریح از جریان کاری شما باشد، به‌جای بازنویسی فایل امضاشده، در یک فایل جدید ذخیره کنید.

## **موارد ویرایش و قالب‌بندی**

- یک امضا، ارائه را به‌صورت فقط‑خواندنی نمی‌کند. کاربران و برنامه‌ها همچنان می‌توانند فایل را ویرایش کنند، اما تغییر محتوای امضاشده معمولاً امضای موجود را نامعتبر می‌سازد.
- تمام ویرایش‌های مورد نظر را قبل از امضا انجام دهید. اگر نیاز به تغییر ارائه بود، نسخهٔ اصلاح‌شده را ذخیره کنید و دوباره آن را امضا کنید.
- خروجی نهایی را در قالب PPTX نگه دارید. تبدیل یک ارائهٔ امضاشده به قالب دیگر امضای اصلی PPTX را به‌عنوان امضای معتبر برای فایل تبدیل‌شده منتقل نمی‌کند.
- کلید خصوصی گواهی را به‌عنوان داده‌ای حساس در نظر بگیرید. هرکسی که کلید خصوصی و گذرواژهٔ آن را به دست آورد، می‌تواند امضاهایی ایجاد کند که به‌نظر می‌رسد از طرف دارنده گواهی باشد.
- هنگامیکه سیاست نگهداری سند شما این کار را می‌طلبد، منبع بدون امضا یا یک نسخهٔ کنترل‌شده دیگر را حفظ کنید.

## **سوالات متداول**

**آیا امضای دیجیتال محتوای ارائه را رمزنگاری می‌کند؟**

خیر. امضای دیجیتال شواهدی دربارهٔ منشاء و یکپارچگی فراهم می‌کند، اما محتوا تا زمانی که رمزنگاری جداگانه‌ای اعمال نشده باشد، قابل خواندن باقی می‌ماند. هنگام نیاز به محدود کردن دسترسی به محتوا، از [حفاظت با گذرواژه](/cpp/password-protected-presentation/) استفاده کنید.

**آیا گذرواژهٔ PFX همان گذرواژهٔ ارائه است؟**

خیر. گذرواژهٔ PFX کلید خصوصی داخل بستهٔ گواهی را باز می‌کند. این گذرواژه کنترل‌کنندهٔ این نیست که چه کسی می‌تواند فایل PPTX را باز یا ویرایش کند.

**آیا می‌توانم از گواهی خودامضا استفاده کنم؟**

از لحاظ فنی، گواهی خودامضا می‌تواند استفاده شود به شرطی که شامل یک کلید خصوصی قابل دسترس باشد. دریافت‌کنندگان به‌طور خودکار به آن اعتماد نمی‌کنند مگر اینکه گواهی به‌صورت صریح به محیط مورد اعتمادشان اضافه شده باشد. جریان‌های کاری عمومی یا بین‌سازمانی معمولاً از گواهی صادر شده توسط یک CA معتبر استفاده می‌کنند.

**چه چیزی باعث نامعتبر شدن یک امضا می‌شود؟**

تغییر محتوای ارائهٔ امضاشده یا داده‌های امضا پس از امضا، امضا را نامعتبر می‌کند. خرابی فایل نیز می‌تواند باعث شکست اعتبارسنجی شود. اگر تمام امضاها حذف شوند، ارائه بدون امضا باقی می‌ماند، نه اینکه حاوی امضای نامعتبر باشد.

**آیا امضای معتبر به این معنی است که باید به امضاکننده اعتماد کرد؟**

خود امضا کافی نیست. یکپارچگی امضا و اعتماد به امضاکننده تصمیمات جداگانه‌ای هستند. یک سیاست اعتبارسنجی در محیط تولید باید زنجیرهٔ گواهی، دورهٔ اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هرگونه نیاز به مهر زمانی معتبر را نیز بررسی کند.

**وقتی گواهی منقضی می‌شود چه اتفاقی می‌افتد؟**

انقضای گواهی محتوای بایت‌های ارائه را تغییر نمی‌دهد، اما ارزیابی اعتماد به گواهی را تحت تأثیر قرار می‌دهد. آیا امضا همچنان قابل قبول است یا نه، بستگی به سیاست شما و اینکه آیا یک مهر زمانی معتبر ثابت می‌کند امضا در زمان معتبر بودن گواهی انجام شده است یا نه دارد. فقط به زمان نمایش داده‌شدهٔ امضا به‌عنوان مهر زمانی معتبر اعتماد نکنید.

**آیا می‌توان یک ارائهٔ امضاشده را ویرایش کرد؟**

بله. امضا کردن فایل را قفل نمی‌کند. ویرایش محتوای امضاشده معمولاً امضای موجود را نامعتبر می‌کند، بنابراین قبل از امضا، ویرایش نهایی را انجام دهید و سپس امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. هر امضا را قبل از ذخیره‌سازی به مجموعه‌ای که توسط [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_digitalsignatures/) بازگردانده می‌شود اضافه کنید. در زمان اعتبارسنجی، هر امضا را بررسی کنید و تأیید کنید که تمام امضاکنندگان مورد نیاز حضور دارند.

**کدام فرمت‌های ارائه از این عملیات پشتیبانی می‌کنند؟**

Aspose.Slides عملیات‌های امضای دیجیتال توضیح‌داده‌شده در اینجا را تنها برای PPTX پشتیبانی می‌کند. فرمت‌های PPT و OpenDocument پشتیبانی نمی‌شوند.

**آیا می‌توانم یک امضا را حذف کنم بدون اینکه اسلایدها تحت تاثیر قرار بگیرند؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را پاک کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها همان‌جا می‌ماند، اما فایل ذخیره‌شده دیگر شواهد امضای حذف‌شده را ندارد.