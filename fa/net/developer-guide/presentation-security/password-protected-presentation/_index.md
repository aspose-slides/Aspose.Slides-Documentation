---
title: "محافظت با رمز عبور از ارائه‌ها در .NET"
linktitle: "محافظت رمز عبور"
type: docs
weight: 20
url: /fa/net/password-protected-presentation/
keywords:
- "ارائه محافظت‌شده با رمز عبور"
- "رمز عبور باز کردن"
- "رمزنگاری پاورپوینت"
- "رمزگشایی پاورپوینت"
- "اعتبارسنجی رمز عبور ارائه"
- "بررسی رمز عبور ارائه"
- "باز کردن ارائه رمزنگاری‌شده"
- "حذف رمزنگاری"
- "PowerPoint"
- "PPT"
- "PPTX"
- "ارائه"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "رمزنگاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های پاورپوینت PPT و PPTX محافظت‌شده با رمز عبور در C# با Aspose.Slides برای .NET."
---
## **بررسی کلی**

یک رمز عبور بازکردن ارائه را رمزنگاری می‌کند. برای بارگذاری و مشاهده محتوای ارائه، نیاز به رمز عبور صحیح است، بنابراین این حفاظت محرمانگی را فراهم می‌کند.

یک رمز عبور بازکردن با رمز عبور حفاظت نوشتاری متفاوت است. حفاظت نوشتاری محدودیت در ویرایش ایجاد می‌کند اما محتوا را رمزنگاری نمی‌کند و مانع بارگذاری ارائه نمی‌شود. برای مدیریت رمزهای عبور برای ویرایش ارائه‌ها، به [محافظت از ارائه با نوشتن](/slides/fa/net/write-protected-presentation/) مراجعه کنید.

جریان‌های کاری زیر برای ارائه‌های PPT و PPTX اعمال می‌شود. مثال‌ها هر دو قالب را استفاده می‌کنند وقتی رفتار مبتنی بر فایل و جریان مهم است.

## **رمزنگاری یک ارائه با رمز عبور بازکردن**

از [IProtectionManager.Encrypt](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/encrypt/) برای اختصاص یک رمز عبور بازکردن استفاده کنید. سپس از [IPresentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/save/) برای ذخیره کردن ارائه رمزنگاری‌شده استفاده کنید.

مثال زیر یک ارائه PPTX را رمزنگاری می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **بارگذاری یک ارائه رمزنگاری‌شده**

[LoadOptions.Password](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/password/) را روی رمز عبور بازکردن تنظیم کنید و گزینه‌ها را هنگام بارگذاری فایل به [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) پاس دهید. در صورتی که رمز عبور بازکردن لازم باشد اما رمز ارائه نشده یا نادرست باشد، بارگذاری شکست می‌خورد.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// کار با ارائه رمزگشایی‌شده.
```

## **حذف رمزنگاری از یک ارائه**

ارائه را همراه با رمز عبور بازکردن بارگذاری کنید، [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/removeencryption/) را فراخوانی کنید و نتیجه را ذخیره کنید. ارائه ذخیره‌شده سپس می‌تواند بدون رمز عبور بارگذاری شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **اعتبارسنجی یک رمز عبور بازکردن قبل از بارگذاری**

از [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationfactory/getpresentationinfo/) برای به‌دست آوردن [IPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/) بدون ایجاد یک نمونه کامل از ارائه استفاده کنید. قبل از درخواست یا اعتبارسنجی یک رمز عبور، [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/ispasswordprotected/) را بررسی کنید. زمانی که حفاظتی وجود دارد، مقدار ارائه‌شده را با [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/checkpassword/) اعتبارسنجی کنید.

### **جریان کاری مسیر فایل**

مثال زیر یک رمز عبور بازکردن برای فایل PPTX را اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [LoadOptions.Password](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/password/) می‌گذارد و سپس تمام ارائه را بارگذاری می‌کند:

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

### **جریان کاری جریان**

بارگذاری بازنویسی [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationfactory/getpresentationinfo/) همان جریان کاری را فراهم می‌کند. قبل از بارگذاری کامل ارائه از همان جریان، موقعیت یک جریان قابل جستجو را بازنشانی کنید.

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

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/checkpassword/) تنها زمانی `true` برمی‌گرداند که ارائه دارای رمز عبور بازکردن باشد و رمز ارائه‌شده صحیح باشد. در هر یک از موارد زیر `false` برمی‌گرداند:

- رمز عبور نادرست است.
- ارائه رمز عبور بازکردن ندارد.
- رمز عبور ارائه‌شده `null` یا خالی است.

رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائه بارگذاری‌شده رمزنگاری شده است**

پس از بارگذاری یک ارائه با رمز عبور صحیح، [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/isencrypted/) را بررسی کنید تا تأیید کنید که ارائه منبع رمزنگاری شده است. برای کشف حفاظت رمز عبور بازکردن قبل از بارگذاری، از `IPresentationInfo.IsPasswordProtected` همان‌طور که در بالا نشان داده شد، استفاده کنید.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **توصیه‌های امنیتی**

{{% alert color="warning" title="Security" %}}
رمزهای عبور بازکردن را لاگ نکنید و در پیام‌های تشخیصی گنجانده نشوند. از تلاش‌های تکراری غیرضروری برای اعتبارسنجی جلوگیری کنید، رمزها را فقط به مدت لازم در حافظه نگه دارید و نتایج اعتبارسنجی موفق را زمانی که بلافاصله ارائه را بارگذاری می‌کنید، مجدداً استفاده کنید.
{{% /alert %}}

## **رمزگذاری یک ارائه به صورت آنلاین**

1. برنامه [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
1. ارائه را انتخاب یا بارگذاری کنید.
1. برای حفاظت نمایشی یک رمز عبور وارد کنید.
1. در صورت نیاز یک رمز عبور جداگانه برای حفاظت ویرایش وارد کنید.
1. حفاظت را اعمال کنید و فایل حاصل را دانلود کنید.

{{% alert color="info" title="See also" %}}
- [محافظت از ارائه با نوشتن](/slides/fa/net/write-protected-presentation/)
- [امضای دیجیتال در پاورپوینت](/slides/fa/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**تفاوت بین رمز عبور بازکردن و رمز عبور حفاظت نوشتاری چیست؟**

یک رمز عبور بازکردن ارائه را رمزنگاری می‌کند و برای بارگذاری محتوای آن لازم است. یک رمز عبور حفاظت نوشتاری بدون رمزنگاری محتوا، محدودیت در ویرایش ایجاد می‌کند.

**آیا می‌توانم یک رمز عبور بازکردن را بدون بارگذاری تمام اسلایدها اعتبارسنجی کنم؟**

بله. اطلاعات ارائه را به‌دست آورده، بررسی می‌کنید که آیا حفاظت رمز عبور بازکردن وجود دارد یا نه و قبل از ایجاد یک نمونه کامل از ارائه، رمز را اعتبارسنجی می‌کنید.

**آیا جریان‌های کاری بررسی رمز عبور برای هر دو فرمت PPT و PPTX پشتیبانی می‌شود؟**

بله. شناسایی و اعتبارسنجی رمز عبور بر پایه مسیر فایل و جریان برای ارائه‌های PPT و PPTX یکسان عمل می‌کند.