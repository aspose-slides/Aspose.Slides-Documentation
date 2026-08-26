---
title: محافظت نوشتاری ارائه‌ها در .NET
linktitle: محافظت نوشتاری
type: docs
weight: 25
url: /fa/net/write-protected-presentation/
keywords:
- محافظت نوشتاری
- محافظت نوشتاری PowerPoint
- رمز عبور برای ویرایش
- محدود کردن ویرایش ارائه
- حذف محافظت نوشتاری
- اعتبارسنجی رمز عبور ویرایش
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تنظیم، شناسایی، اعتبارسنجی و حذف رمزهای محافظت نوشتاری در ارائه‌های PowerPoint PPT و PPTX با استفاده از Aspose.Slides برای .NET."
---
## **معرفی**

یک رمز عبور حفاظت نوشتاری، تغییرات یک ارائه را محدود می‌کند اما محتوا را رمزنگاری نمی‌کند. کاربران می‌توانند ارائه‌ای که دارای حفاظت نوشتاری است را بدون وارد کردن رمز عبور بارگذاری و مشاهده کنند. بسته به برنامه، ممکن است بتوانند محتوا را ویرایش کرده و تحت نامی دیگر ذخیره کنند، بنابراین حفاظت نوشتاری نباید به‌عنوان سازوکار محرمانگی محسوب شود.

یک رمز عبور باز کردن هدف متفاوتی دارد: ارائه را رمزنگاری می‌کند و برای بارگذاری محتوا باید وارد شود. برای رمزنگاری یک ارائه یا اعتبارسنجی رمز عبور باز کردن، به [محافظت از ارائه‌ها](/slides/fa/net/password-protected-presentation/) مراجعه کنید.

جریان‌های کاری این مقاله برای ارائه‌های PPT و PPTX کاربرد دارند. مثال‌ها از فایل‌های PPTX استفاده می‌کنند؛ هنگام ذخیره به فرمت PPT، پسوند `.ppt` و قالب ذخیره‌سازی متناسب با PPT را به کار ببرید.

## **تنظیم حفاظت نوشتاری در ارائه**

از [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/setwriteprotection/) برای اختصاص یک رمز عبور جهت تغییر یک ارائه استفاده کنید. ذخیره ارائه تنظیمات حفاظت را حفظ می‌کند.

مثال زیر حفاظت نوشتاری را بر روی یک ارائه PPTX اعمال می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **بارگذاری ارائه دارای حفاظت نوشتاری**

از آنجا که حفاظت نوشتاری محتوا را رمزنگاری نمی‌کند، برای بارگذاری ارائه نیازی به رمز عبور نیست. رمز عبور فقط هنگام اعتبارسنجی مجوز تغییر ارائه محافظت‌شده مورد استفاده قرار می‌گیرد.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

به [LoadOptions.Password](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/password/) رمز عبور حفاظت نوشتاری ارسال نکنید. این ویژگی تنها یک رمز عبور باز کردن برای محتوای رمزنگاری‌شده را می‌پذیرد. اگر یک ارائه هر دو نوع حفاظت را داشته باشد، رمز عبور باز کردن را برای بارگذاری ارائه فراهم کنید و رمز عبور حفاظت نوشتاری را به‌صورت جداگانه مدیریت کنید.

## **حذف حفاظت نوشتاری از یک ارائه**

از [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/removewriteprotection/) برای حذف محدودیت تغییر استفاده کنید، سپس ارائه را ذخیره کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **بررسی اینکه آیا یک ارائه دارای حفاظت نوشتاری است**

برای بررسی یک فایل بدون ایجاد یک نمونه کامل از [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ، متد [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationfactory/getpresentationinfo/) را فراخوانی کنید و ویژگی [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/iswriteprotected/) را بررسی کنید. این ویژگی از [NullableBool](https://reference.aspose.com/slides/fa/net/aspose.slides/nullablebool/) استفاده می‌کند و وقتی حفاظت نوشتاری شناسایی شود مقدار `NullableBool.True` برمی‌گرداند.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

بارگذاری جریان (stream) overload از [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationfactory/getpresentationinfo/) همان اطلاعات را برای ارائه‌ای که به‌صورت جریان فراهم شده است، ارائه می‌دهد.

## **اعتبارسنجی رمز عبور حفاظت نوشتاری**

از [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/checkwriteprotection/) برای اعتبارسنجی رمز عبور تغییر بدون بارگذاری کامل ارائه استفاده کنید. ابتدا [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/iswriteprotected/) را بررسی کنید تا برنامه فقط زمانی که حفاظت نوشتاری وجود دارد، رمز عبور را درخواست یا اعتبارسنجی کند.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/checkwriteprotection/) فقط رمز عبور حفاظت نوشتاری را اعتبارسنجی می‌کند. این ویژگی رمز عبور باز کردن یا تعیین امکان بارگذاری محتوای رمزنگاری‌شده را اعتبارسنجی نمی‌کند. برعکس، [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/checkpassword/) فقط رمز عبور باز کردن را اعتبارسنجی می‌کند. اگر یک ارائه کامل قبلاً بارگذاری شده باشد، [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/checkwriteprotection/) بررسی معادل حفاظت نوشتاری را از طریق مدیر حفاظت خود ارائه می‌دهد.

در برنامه‌های تولیدی، رمزهای عبور را لاگ نکنید یا در پیام‌های تشخیصی قرار ندهید. از تلاش‌های مکرر و بی‌ضرورت اعتبارسنجی جلوگیری کنید و رمزهای عبور را در حافظه فقط به مدت لازم نگه دارید.

{{% alert color="info" title="همچنین ببینید" %}}
- [محافظت از ارائه‌ها](/slides/fa/net/password-protected-presentation/)
- [ارائه‌های فقط خواندنی](/slides/fa/net/read-only-presentation/)
- [امضای دیجیتال در پاورپوینت](/slides/fa/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**آیا حفاظت نوشتاری یک ارائه را رمزنگاری می‌کند؟**

خیر. این ویژگی فقط تغییرات را محدود می‌کند اما محتوای ارائه برای بارگذاری و مشاهده در دسترس باقی می‌ماند.

**آیا برای باز کردن یک ارائه نیاز به رمز عبور حفاظت نوشتاری است؟**

خیر. تنها یک رمز عبور باز کردن برای بارگذاری محتوای رمزنگاری‌شده ارائه لازم است.

**آیا یک ارائه می‌تواند همزمان دارای رمز عبور باز کردن و رمز عبور حفاظت نوشتاری باشد؟**

بله. رمز عبور باز کردن را از طریق گزینه‌های بارگذاری برای باز کردن ارائه رمزنگاری‌شده فراهم کنید و رمز عبور حفاظت نوشتاری را به‌صورت جداگانه زمانی که نیاز به مجوز تغییر است، اعتبارسنجی کنید.