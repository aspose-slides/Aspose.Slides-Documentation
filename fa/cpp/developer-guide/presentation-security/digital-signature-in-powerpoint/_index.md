---
title: افزودن امضاهای دیجیتال به ارائه‌ها در C++
linktitle: امضای دیجیتال
type: docs
weight: 10
url: /fa/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PPTX موجود را با گواهی‌های PFX امضا کنید و از Aspose.Slides برای C++ برای اعتبارسنجی یا حذف امضاهای دیجیتال استفاده کنید."
---
## **بررسی کلی**

یک امضای دیجیتال به گیرنده کمک می‌کند تا تعیین کند چه کسی یک ارائه را امضا کرده و آیا محتوای امضا شده تغییر کرده است. سه مفهوم امنیتی مرتبط در اینجا مهم هستند:

- یک **گواهی دیجیتال** یک اعتبار الکترونیکی است که یک هویت را با یک کلید عمومی مرتبط می‌کند. یک مرجع صدور گواهی (CA) مورد اعتماد می‌تواند گواهی صادر کند، یا یک سازمان می‌تواند برای جریان‌های کاری داخلی از گواهی خودامضا استفاده کند.
- یک **امضا دیجیتال** از محتوای ارائه و کلید خصوصی دارنده گواهی ایجاد می‌شود. سپس می‌توان از کلید عمومی گواهی برای تأیید امضا استفاده کرد. امضا مدرکی از منبع و صحت ارائه می‌دهد؛ اما ارائه را رمزنگاری نمی‌کند.
- **حفاظت با رمز عبور** تعیین می‌کند که آیا کاربر می‌تواند ارائه را باز یا ویرایش کند. این مورد جدا از امضای دیجیتال است و در [ارائه‌های محافظت‌شده با رمز عبور](/slides/fa/cpp/password-protected-presentation/) توصیف شده است.

PowerPoint دستور **Add a Digital Signature** را در زیر منوی **File > Info > Protect Presentation** ارائه می‌دهد.

![منوی Protect Presentation در PowerPoint که گزینه Add a Digital Signature را برجسته کرده است](add-digital-signature-in-powerpoint.png)

پس از باز شدن یک ارائه امضاشده، PowerPoint می‌تواند اعلان وضعیت امضا را نمایش دهد.

![اعلان PowerPoint که نشان می‌دهد ارائه شامل امضاهای معتبر است](digital-signature-status-in-powerpoint.png)

Aspose.Slides امضاها را از طریق [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_digitalsignatures/) در اختیار می‌گذارد که یک [IDigitalSignatureCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignaturecollection/) را بازمی‌گرداند که آیتم‌های آن پیاده‌سازی‌کننده [IDigitalSignature](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignature/) هستند. یک ارائه می‌تواند شامل چندین امضا باشد.

## **درک گواهی‌های PFX و رمزهای عبور**

یک فایل PFX، که به عنوان فایل PKCS#12 نیز شناخته می‌شود و معمولاً پسوند `.pfx` یا `.p12` دارد، می‌تواند شامل یک گواهی X.509، کلید خصوصی آن و زنجیره گواهی باشد. کلید خصوصی همان چیزی است که به دارنده اجازه می‌دهد امضا ایجاد کند. گواهی بدون کلید خصوصی قابل دسترسی نمی‌تواند برای امضای ارائه استفاده شود.

رمز عبور PFX بسته گواهی و کلید خصوصی را محافظت می‌کند. این **رمز عبور** برای باز یا ویرایش ارائه نیست. فایل‌های PFX یا رمزهای عبور آنها را به مخازن سورس کنترل کمیت نکنید. در محیط تولید، دسترسی به فایل گواهی را محدود کنید و رمز عبور آن را از یک مخزن رمز یا منبع پیکربندی محافظت‌شده دریافت کنید. مثال‌های زیر از یک متغیر محیطی استفاده می‌کند تا از درج مستقیم رمز عبور در کد جلوگیری شود.

## **افزودن امضای دیجیتال به یک ارائه**

برای امضای یک جریان کاری واقعی، یک فایل PPTX موجود را بارگذاری کنید، یک [DigitalSignature](https://reference.aspose.com/slides/fa/cpp/aspose.slides/digitalsignature/) را از یک گواهی PFX و رمز عبور آن ایجاد کنید، امضا را به مجموعه امضاهای ارائه اضافه کنید و به یک فایل PPTX ذخیره کنید.

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

ذخیره نتیجه با نام جدید، فایل منبع بدون امضا را حفظ می‌کند. مقدار [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignature/set_comments/) توصیف‌کننده هدف امضا است؛ این یک کنترل امنیتی نیست.

## **اعتبارسنجی امضاهای دیجیتال**

هنگامی که یک فایل PPTX امضاشده را بارگذاری می‌کنید، هر آیتم بازگردانده‌شده توسط [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_digitalsignatures/) را بررسی کنید. متد [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignature/get_isvalid/) نشان می‌دهد که آیا امضای تعبیه‌شده برای محتوای فعلی ارائه معتبر است یا خیر.

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

نتیجه نامعتبر معمولاً به این معنی است که محتوای ارائه امضاشده یا داده‌های امضا پس از امضا تغییر یافته‌اند، یا فایل آسیب دیده است. حذف تمام امضاها یک ارائه بدون امضا تولید می‌کند، بنابراین بررسی فقط اعتبار آیتم‌ها کافی نیست: یک جریان کاری حساس به امنیت باید تعداد مورد انتظار امضاها و هویت‌های امضاکنندگان مورد انتظار را نیز تأیید کند.

این نتایج اعتبار نباید به عنوان تصمیم نهایی در مورد اعتماد به گواهی محسوب شود. بسته به سیاست امنیتی شما، برنامه ممکن است نیاز داشته باشد زنجیره گواهی X.509 را بسازد و اعتبارسنجی کند، تاریخ اعتبار گواهی و وضعیت لغو را بررسی کند، موضوع یا اثر انگشت مورد انتظار را تأیید کند، استفاده از کلید را بررسی کند، و یک مهر زمان معتبر را ارزیابی کند. مقدار [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignature/get_signtime/) به تنهایی اثباتی از یک مرجع مهر زمان معتبر نیست.

## **حذف امضاهای دیجیتال**

حذف امضاها وضعیت امنیتی ارائه را تغییر می‌دهد. مثال زیر یک فایل PPTX امضاشده را بارگذاری می‌کند، تمام امضاها را با [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignaturecollection/clear/) حذف می‌کند و یک نسخه بدون امضا ذخیره می‌کند.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

برای حذف تنها یک امضا، متد [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idigitalsignaturecollection/removeat/) را با ایندکس صفرمحور آن فراخوانی کنید. مگر اینکه حذف امضای اصلی بخشی صریح از جریان کاری شما باشد، به یک فایل جدید ذخیره کنید تا از بازنویسی فایل امضاشده اصلی جلوگیری شود.

## **ملاحظات ویرایش و فرمت**

- امضا باعث نمی‌شود ارائه فقط خواندنی شود. کاربران و برنامه‌ها هنوز می‌توانند فایل را ویرایش کنند، اما تغییر محتوای امضا شده معمولاً امضای موجود را نامعتبر می‌کند.
- تمام ویرایش‌های موردنظر را قبل از امضا انجام دهید. اگر لازم باشد ارائه تغییر کند، نسخه اصلاح‌شده را ذخیره کرده و آن نسخه را دوباره امضا کنید.
- خروجی نهایی را در قالب PPTX نگه دارید. تبدیل یک ارائه امضاشده به قالب دیگر امضای اصلی PPTX را به عنوان امضای معتبر برای فایل تبدیل‌شده منتقل نمی‌کند.
- کلید خصوصی گواهی را حساس در نظر بگیرید. هر کس کلید خصوصی و رمز عبور آن را به دست آورد می‌تواند امضاهایی ایجاد کند که گویی از طرف دارنده گواهی هستند.
- منبع بدون امضا یا یک نسخه کنترل‌شده دیگر را زمانی که سیاست حفظ سند شما نیاز دارد، نگه دارید.

## **سوالات متداول**

**آیا امضای دیجیتال ارائه را رمزنگاری می‌کند؟**

خیر. امضای دیجیتال مدرکی درباره منبع و صحت ارائه می‌دهد، اما محتوای ارائه همچنان قابل خواندن است مگر اینکه رمزنگاری جداگانه‌ای اعمال شود. وقتی دسترسی به محتوا باید محدود شود، از [حفاظت با رمز عبور](/slides/fa/cpp/password-protected-presentation/) استفاده کنید.

**آیا رمز عبور PFX همان رمز عبور ارائه است؟**

خیر. رمز عبور PFX کلید خصوصی ذخیره‌شده در بسته گواهی را باز می‌کند. این کنترل نمی‌کند چه کسی می‌تواند فایل PPTX را باز یا ویرایش کند.

**آیا می‌توانم از گواهی خودامضا استفاده کنم؟**

از نظر فنی، گواهی خودامضا می‌تواند استفاده شود وقتی که شامل یک کلید خصوصی قابل دسترسی باشد. دریافت‌کنندگان به‌طور خودکار به آن اعتماد نمی‌کنند، مگر این که گواهی صراحتاً به محیط مورد اعتماد آنها اضافه شده باشد. جریان‌های کاری عمومی یا بین‌سازمانی معمولاً از گواهی صادر‌شده توسط یک CA مورد اعتماد استفاده می‌کنند.

**چه عواملی باعث نامعتبر شدن امضا می‌شود؟**

تغییر محتوای ارائه امضاشده یا داده‌های امضا پس از امضا می‌تواند امضا را نامعتبر کند. خراب شدن فایل نیز می‌تواند باعث شکست اعتبارسنجی شود. اگر تمام امضاها حذف شوند، ارائه بدون امضا است نه فایلی که شامل امضای نامعتبر باشد.

**آیا امضای معتبر به این معناست که باید به امضاکننده اعتماد کنم؟**

خیر؛ فقط خود امضا کافی نیست. یک سیاست اعتبارسنجی تولیدی باید زنجیره گواهی، دوره اعتبار، وضعیت لغو، هویت مورد انتظار، استفاده از کلید و هر الزامات مهر زمان معتبر را نیز بررسی کند.

**هنگامی که گواهی منقضی شود چه می‌شود؟**

انقضای گواهی بایت‌های ارائه را تغییر نمی‌دهد، اما ارزیابی اعتماد به گواهی را تحت تأثیر قرار می‌دهد. اینکه آیا یک امضا قابل قبول باقی می‌ماند بستگی به سیاست شما و این دارد که آیا یک مهر زمان معتبر نشان می‌دهد امضا در زمان معتبر بودن گواهی انجام شده است یا نه. فقط به زمان امضای نمایش‌داده‌شده به عنوان مهر زمان مورد اعتماد تکیه نکنید.

**آیا می‌توان یک ارائه امضاشده را ویرایش کرد؟**

بله. امضاکننده فایل را قفل نمی‌کند. ویرایش محتوای امضاشده معمولاً امضای موجود را نامعتبر می‌کند، بنابراین ابتدا ارائه را نهایی کنید و سپس نسخه نهایی را امضا کنید.

**آیا یک ارائه می‌تواند بیش از یک امضا داشته باشد؟**

بله. هر امضا را قبل از ذخیره به مجموعه‌ای که توسط [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_digitalsignatures/) برگردانده می‌شود اضافه کنید. هنگام اعتبارسنجی، هر امضا را بررسی کنید و تأیید کنید که تمام امضاکنندگان مورد نیاز حضور دارند.

**کدام فرمت‌های ارائه از این عملیات پشتیبانی می‌کنند؟**

Aspose.Slides این عملیات‌های امضای دیجیتال را فقط برای PPTX پشتیبانی می‌کند. فرمت‌های PPT و OpenDocument پشتیبانی نمی‌شوند.

**آیا می‌توانم یک امضا را حذف کنم بدون اینکه به اسلایدها آسیب برسد؟**

بله. می‌توانید یک امضا را حذف کنید یا کل مجموعه را پاک کنید و سپس ارائه را ذخیره کنید. محتوای اسلایدها باقی می‌ماند، اما فایل ذخیره‌شده دیگر شواهد امضای حذف‌شده را ندارند.