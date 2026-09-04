---
title: "محافظت از ارائه‌ها با رمز عبور در .NET"
linktitle: "حفاظت با رمز عبور"
type: docs
weight: 20
url: /fa/net/password-protected-presentation/
keywords:
- "ارائهٔ محافظت‌شده با رمز عبور"
- "رمز عبور بازکردن"
- "رمزگذاری پاورپوینت"
- "رمزگشایی پاورپوینت"
- "اعتبارسنجی رمز عبور ارائه"
- "بررسی رمز عبور ارائه"
- "باز کردن ارائهٔ رمزگذاری‌شده"
- "حذف رمزگذاری"
- "پاورپوینت"
- "PPT"
- "PPTX"
- "ارائه"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "رمزگذاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های پاورپوینت PPT و PPTX محافظت‌شده با رمز عبور در C# با Aspose.Slides برای .NET."
---
## **بررسی کلی**

یک رمز عبور بازکردن یک ارائه را رمزگذاری می‌کند. برای بارگذاری و مشاهده محتوای ارائه، رمز عبور صحیح لازم است، بنابراین این حفاظت محرمانگی را فراهم می‌کند.

یک رمز عبور بازکردن متفاوت از رمز عبور محافظت در نوشتن است. محافظت در نوشتن اصلاحات را محدود می‌کند اما محتوا را رمزگذاری نمی‌کند و مانع بارگذاری ارائه نمی‌شود. برای مدیریت رمزهای عبور جهت ویرایش ارائه‌ها، ببینید [Write-Protect Presentations](/slides/fa/net/write-protected-presentation/).

فرآیندهای زیر برای هر دو نوع ارائه PPT و PPTX اعمال می‌شود. مثال‌ها از هر دو قالب استفاده می‌کنند جایی که رفتار مبتنی بر فایل و مبتنی بر جریان مهم است.

## **رمزگذاری یک ارائه با رمز عبور بازکردن**

از [IProtectionManager.Encrypt](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/encrypt/) برای اختصاص یک رمز عبور بازکردن استفاده کنید. سپس از [IPresentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/save/) برای ذخیرهٔ ارائهٔ رمزگذاری‌شده استفاده کنید.

مثال زیر یک ارائه PPTX را رمزگذاری می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **حفظ عمومی بودن خصوصیات سند**

به‌طور پیش‌فرض، Aspose.Slides خصوصیات سند را در رمزگذاری ارائه گنجانده است. خصوصیت [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) این رفتار را به‌صورت مستقل از رمزگذاری محتوای اسلایدها کنترل می‌کند. هنگامیکه یک سیستم فهرست‌سازی، طبقه‌بندی، جستجو یا مدیریت سند باید فراداده‌ها را بدون رمز عبور بازکردن بخواند، قبل از فراخوانی [IProtectionManager.Encrypt](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/encrypt/) آن را به `false` تنظیم کنید.

مثال زیر یک ارائه PPTX رمزگذاری‌شده را ایجاد می‌کند در حالی که خصوصیات سند داخلی آن عمومی باقی می‌مانند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

تنظیم `EncryptDocumentProperties` به `false` اسلایدها، مسترها، طرح‌بندی‌ها، اشکال، رسانه‌ها یا سایر محتوای ارائه را عمومی نمی‌کند. این تنظیم فقط بر خصوصیات سند تأثیر دارد. برای خواندن این خصوصیات بدون بارگذاری محتوای رمزگذاری‌شده، به [Manage Presentation Properties](/slides/fa/net/presentation-properties/) مراجعه کنید.

## **بارگذاری یک ارائه رمزگذاری‌شده**

مقدار [LoadOptions.Password](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/password/) را به رمز عبور بازکردن تنظیم کنید و هنگام بارگذاری فایل، این گزینه‌ها را به [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) پاس دهید. اگر رمز عبور بازکردن لازم باشد ولی رمز ارائه‌شده موجود یا نادرست باشد، بارگذاری شکست می‌خورد.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// کار با ارائهٔ رمزگشایی‌شده.
```

## **حذف رمزگذاری از یک ارائه**

ارائه را با رمز عبور بازکردن آن بارگذاری کنید، [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/removeencryption/) را فراخوانی کنید و نتیجه را ذخیره کنید. سپس می‌توان ارائهٔ ذخیره‌شده را بدون رمز عبور بارگذاری کرد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **اعتبارسنجی رمز عبور بازکردن قبل از بارگذاری**

از [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationfactory/getpresentationinfo/) برای دریافت [IPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/) بدون ایجاد یک نمونهٔ کامل از ارائه استفاده کنید. قبل از درخواست یا اعتبارسنجی رمز عبور، [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/ispasswordprotected/) را بررسی کنید. هنگامی که محافظت وجود دارد، مقدار ارائه‌شده را با [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/checkpassword/) اعتبارسنجی کنید.

### **گردش کار مسیر فایل**

مثال زیر رمز عبور بازکردن یک فایل PPTX را اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [LoadOptions.Password](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/password/) می‌گذارد و سپس ارائهٔ کامل را بارگذاری می‌کند:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **گردش کار جریان**

بارگذاری اضافه‌بار (overload) جریان از [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationfactory/getpresentationinfo/) همان گردش کار را فراهم می‌کند. قبل از بارگذاری ارائهٔ کامل از آن جریان، موقعیت یک جریان قابل جستجو (seekable) را بازنشانی کنید.

مثال زیر از یک فایل PPT استفاده می‌کند:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **مقادیر بازگشتی CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/checkpassword/) فقط زمانی `true` بر می‌گرداند که ارائه دارای رمز عبور بازکردن باشد و رمز ارائه‌شده صحیح باشد. در هر یک از موارد زیر `false` بر می‌گرداند:

- رمز عبور نادرست است.
- ارائه رمز عبور بازکردن ندارد.
- رمز عبور ارائه‌شده `null` یا خالی است.

این رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائه بارگذاری‌شده رمزگذاری شده است**

پس از بارگذاری یک ارائه با رمز عبور صحیح، [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/isencrypted/) را بررسی کنید تا تأیید کنید که ارائهٔ منبع رمزگذاری شده است. برای تشخیص محافظت رمز عبور بازکردن قبل از بارگذاری، همان‌طور که در بالا نشان داده شد، از `IPresentationInfo.IsPasswordProtected` استفاده کنید.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **پیشنهادات امنیتی**

{{% alert color="warning" title="امنیت" %}}
رمزهای عبور بازکردن را لاگ نکنید و در پیام‌های تشخیصی گنجانده نشوند. از تلاش‌های تکراری و غیرضروری برای اعتبارسنجی جلوگیری کنید، رمزها را در حافظه تنها به‌مدت زمان مورد نیاز نگه دارید و نتایج موفقیت‌آمیز اعتبارسنجی را هنگام بارگذاری فوری ارائه دوباره استفاده کنید.

خصوصیات عمومی سند ممکن است نام نویسندگان، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کنند حتی اگر محتوای ارائه رمزگذاری شده باشد. متادیتاهای حساس را همراه با ارائه رمزگذاری کنید. گذاشتن خصوصیات به‌صورت عمومی باید تصمیمی صریح باشد و تنها زمانی انجام شود که سیستم‌ها برای فهرست‌سازی، طبقه‌بندی، جستجو یا مدیریت فایل بدون رمز عبور بازکردن نیاز داشته باشند.
{{% /alert %}}

## **حفاظت از ارائه با رمز عبور به صورت آنلاین**

1. برنامهٔ [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
2. ارائه را انتخاب یا بارگذاری کنید.
3. رمز عبور برای حفاظت از مشاهده وارد کنید.
4. در صورت تمایل رمز عبور جداگانه‌ای برای حفاظت از ویرایش وارد کنید.
5. حفاظت را اعمال کنید و فایل حاصل را دانلود کنید.

{{% alert color="info" title="موارد دیگر" %}}
- [محافظت نوشتاری از ارائه‌ها](/slides/fa/net/write-protected-presentation/)
- [امضای دیجیتال در پاورپوینت](/slides/fa/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**تفاوت بین رمز عبور بازکردن و رمز عبور محافظت نوشتاری چیست؟**

یک رمز عبور بازکردن ارائه را رمزگذاری می‌کند و برای بارگذاری محتوای آن لازم است. یک رمز عبور محافظت نوشتاری اصلاحات را محدود می‌کند بدون این که محتوا را رمزگذاری کند.

**آیا می‌توانم رمز عبور بازکردن را بدون بارگذاری تمام اسلایدها اعتبارسنجی کنم؟**

بله. اطلاعات ارائه را دریافت کنید، بررسی کنید آیا محافظت رمز عبور بازکردن وجود دارد یا خیر، و قبل از ایجاد یک نمونه کامل از ارائه، رمز عبور را اعتبارسنجی کنید.

**آیا یک برنامه می‌تواند متادیتا را بدون رمز عبور بازکردن بخواند؟**

بله، اما فقط زمانی که ارائه با تنظیم `EncryptDocumentProperties` روی `false` رمزگذاری شده باشد. در این صورت برنامه باید از حالت بارگذاری فقط‑خصوصیات‑سند که در [Manage Presentation Properties](/slides/fa/net/presentation-properties/) توضیح داده شده استفاده کند.

**آیا جریان‌های بررسی رمز عبور هم برای PPT و هم برای PPTX پشتیبانی می‌شوند؟**

بله. تشخیص و اعتبارسنجی رمز عبور بر پایه مسیر فایل و بر پایه جریان برای ارائه‌های PPT و PPTX به‌یک صورت عمل می‌کند.