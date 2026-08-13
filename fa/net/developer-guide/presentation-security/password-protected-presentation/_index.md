---
title: محافظت از ارائه‌ها با رمز عبور در .NET
linktitle: محافظت با رمز عبور
type: docs
weight: 20
url: /fa/net/password-protected-presentation/
keywords:
- قفل کردن PowerPoint
- قفل کردن ارائه
- باز کردن قفل PowerPoint
- باز کردن قفل ارائه
- محافظت از PowerPoint
- محافظت از ارائه
- تنظیم رمز عبور
- افزودن رمز عبور
- رمزنگاری PowerPoint
- رمزنگاری ارائه
- رمزگشایی PowerPoint
- رمزگشایی ارائه
- حفاظت نوشتن
- امنیت PowerPoint
- امنیت ارائه
- حذف رمز عبور
- حذف محافظت
- حذف رمزنگاری
- غیرفعال‌سازی رمز عبور
- غیرفعال‌سازی محافظت
- حذف حفاظت نوشتن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بیاموزید چگونه به راحتی ارائه‌های PowerPoint و OpenDocument محافظت‌شده با رمز عبور را با Aspose.Slides برای .NET قفل و باز کنید. ارائه‌های خود را ایمن کنید."
---
## **معرفی**

هنگامی که یک ارائه را با رمز عبور محافظت می‌کنید، به این معنی است که رمز عبوری تعیین می‌کنید که محدودیت‌های خاصی را بر روی ارائه اعمال می‌کند. برای حذف این محدودیت‌ها، باید رمز عبور وارد شود. یک ارائه محافظت‌شده با رمز عبور به عنوان یک ارائه قفل‌شده در نظر گرفته می‌شود.

به طور معمول، می‌توانید برای اعمال این محدودیت‌ها بر روی یک ارائه، رمز عبور تعیین کنید:

- **تغییر**

اگر می‌خواهید فقط کاربران خاصی بتوانند ارائه شما را تغییر دهند، می‌توانید محدودیت تغییر را تنظیم کنید. این محدودیت مانع از تغییر، اصلاح یا کپی عناصر در ارائه شما می‌شود مگر اینکه رمز عبور ارائه شود.

با این حال، حتی بدون رمز عبور، کاربر همچنان می‌تواند به سند شما دسترسی پیدا کند و آن را باز کند. در این حالت فقط-خواندنی، کاربر می‌تواند محتوای ارائه را مشاهده کند — از جمله پیوندها، انیمیشن‌ها، اثرها و سایر عناصر — اما نمی‌تواند موارد را کپی کند یا ارائه را ذخیره نماید.

- **باز کردن**

اگر می‌خواهید فقط کاربران خاصی بتوانند ارائه شما را باز کنند، می‌توانید محدودیت باز کردن را تنظیم کنید. این محدودیت مانع از مشاهده محتوای ارائه شما می‌شود مگر اینکه رمز عبور ارائه شود.

از نظر فنی، محدودیت باز کردن همچنین مانع از تغییر ارائه‌ها می‌شود — اگر کاربران نتوانند ارائه‌ای را باز کنند، نمی‌توانند آن را تغییر دهند یا ویرایش کنند.

**Note:** هنگامی که برای جلوگیری از باز کردن یک ارائه، آن را با رمز عبور محافظت می‌کنید، فایل ارائه رمزگذاری می‌شود.

## **حفاظت با رمز عبور در Aspose.Slides**

**فرمت‌های پشتیبانی‌شده**

Aspose.Slides برای ارائه‌های موجود در این فرمت‌ها، محافظت با رمز عبور، رمزگذاری و عملیات مشابه را پشتیبانی می‌کند:

- PPTX و PPT – ارائه‌های Microsoft PowerPoint
- ODP – ارائه‌های OpenDocument
- OTP – قالب‌های ارائه OpenDocument

**عملیات پشتیبانی‌شده**

Aspose.Slides به شما امکان می‌دهد تا با استفاده از محافظت با رمز عبور، از تغییرات ارائه‌ها به روش‌های زیر جلوگیری کنید:

- رمزنگاری یک ارائه
- تنظیم حفاظت نوشتن بر روی یک ارائه

**سایر عملیات**

Aspose.Slides به شما اجازه می‌دهد تا وظایف اضافی مرتبط با محافظت با رمز عبور و رمزگذاری را به روش‌های زیر انجام دهید:

- رمزگشایی یک ارائه؛ باز کردن یک ارائه رمزنگاری‌شده
- حذف رمزنگاری؛ غیرفعال‌سازی حفاظت با رمز عبور
- حذف حفاظت نوشتن از یک ارائه
- دریافت ویژگی‌های یک ارائه رمزنگاری‌شده
- بررسی اینکه آیا یک ارائه قبل از بارگذاری با رمز عبور محافظت شده است یا نه
- بررسی اینکه آیا یک ارائه رمزنگاری شده است یا نه
- بررسی اینکه آیا یک ارائه با رمز عبور محافظت شده است یا نه

## **محافظت از یک ارائه با رمز عبور**

می‌توانید یک ارائه را با تنظیم رمز عبور رمزنگاری کنید. سپس برای اصلاح ارائهٔ قفل‌شده، کاربر باید رمز عبور را ارائه دهد.

برای رمزنگاری (یا محافظت با رمز عبور) یک ارائه، از متد `Encrypt` از [ProtectionManager](https://reference.aspose.com/slides/fa/net/aspose.slides/protectionmanager) استفاده کنید تا رمز عبور تنظیم شود. رمز عبور را به متد `Encrypt` پاس بدهید، سپس از متد `Save` برای ذخیرهٔ ارائهٔ رمزنگاری‌شده استفاده کنید.

این کد نمونه نشان می‌دهد چگونه یک ارائه را رمزنگاری کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **تنظیم حفاظت نوشتن بر روی یک ارائه**

می‌توانید علامتی با متن «Do not modify» به یک ارائه اضافه کنید. این به کاربران اطلاع می‌دهد که شما نمی‌خواهید آن‌ها تغییراتی در ارائه اعمال کنند.

**Note:** فرآیند حفاظت نوشتن ارائه را رمزگذاری نمی‌کند. بنابراین، کاربران — اگر مایل باشند — می‌توانند ارائه را تغییر دهند، اما برای ذخیرهٔ تغییرات باید آن را با نام دیگری ذخیره کنند.

برای تنظیم حفاظت نوشتن، از متد `SetWriteProtection` استفاده کنید. این کد نمونه نشان می‌دهد چگونه حفاظت نوشتن را بر روی یک ارائه تنظیم کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **بارگذاری یک ارائه رمزنگاری‌شده**

Aspose.Slides به شما امکان می‌دهد تا یک ارائه رمزنگاری‌شده را با پاس دادن رمز عبور صحیح بارگذاری کنید. این کد نمونه نشان می‌دهد چگونه یک ارائه رمزنگاری‌شده را بارگذاری کنید:

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // کار با ارائه‌ی رمزگشایی‌شده.
}
```

## **حذف رمزنگاری از یک ارائه**

می‌توانید رمزنگاری یا محافظت با رمز عبور را از یک ارائه حذف کنید تا کاربران بتوانند بدون محدودیت به آن دسترسی پیدا کنند یا آن را ویرایش نمایند.

برای حذف رمزنگاری یا محافظت با رمز عبور، متد [RemoveEncryption](https://reference.aspose.com/slides/fa/net/aspose.slides/protectionmanager/methods/removeencryption) را فراخوانی کنید. این کد نمونه نشان می‌دهد چگونه رمزنگاری را از یک ارائه حذف کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **حذف حفاظت نوشتن از یک ارائه**

می‌توانید با استفاده از Aspose.Slides، حفاظت نوشتن را از یک فایل ارائه حذف کنید. به این ترتیب، کاربران می‌توانند همان‌گونه که می‌خواهند آن را ویرایش کنند — و هنگام انجام این کار هیچ هشدار داده نخواهد شد.

می‌توانید حفاظت نوشتن را با استفاده از متد [RemoveWriteProtection](https://reference.aspose.com/slides/fa/net/aspose.slides/protectionmanager/methods/removewriteprotection) حذف کنید. این کد نمونه نشان می‌دهد چگونه حفاظت نوشتن را از یک ارائه حذف کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **دریافت ویژگی‌های یک ارائه رمزنگاری‌شده**

به طور معمول، کاربران برای دریافت ویژگی‌های سند یک ارائهٔ رمزنگاری‌شده یا محافظت‌شده با رمز عبور دچار مشکل می‌شوند. اما Aspose.Slides مکانیسمی ارائه می‌دهد که به شما امکان می‌دهد یک ارائه را با رمز عبور محافظت کنید و در عین حال کاربران بتوانند به ویژگی‌های آن دسترسی داشته باشند.

**Note:** به‌صورت پیش‌فرض، وقتی Aspose.Slides یک ارائه را رمزنگاری می‌کند، ویژگی‌های سند ارائه نیز با رمز عبور محافظت می‌شوند. اگر نیاز دارید که حتی پس از رمزگذاری، ویژگی‌های سند قابل دسترسی باشند، Aspose.Slides به شما این امکان را می‌دهد.

اگر می‌خواهید کاربران همچنان بتوانند به ویژگی‌های یک ارائهٔ رمزنگاری‌شده دسترسی داشته باشند، ویژگی `EncryptDocumentProperties` از [IProtectionManager](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/) را به `false` تنظیم کنید. این کد نمونه نشان می‌دهد چگونه یک ارائه را رمزنگاری کنید در حالی که همچنان به کاربران دسترسی به ویژگی‌های سند آن داده می‌شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **بارگذاری فقط ویژگی‌های سند از یک ارائه رمزنگاری‌شده**

برای بررسی فرادادهٔ یک ارائهٔ رمزنگاری‌شده بدون بارگذاری اسلایدها یا محتوای دیگر، یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) ایجاد کنید و ویژگی [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) را به `true` تنظیم کنید. در این حالت، Aspose.Slides رمز عبور را نادیده می‌گیرد و فقط ویژگی‌های سندی که به‌صورت عمومی در دسترس هستند را بارگذاری می‌کند.

مثال کد زیر ویژگی‌های سند پیش‌ساخته و سفارشی را از طریق [IPresentation.DocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/documentproperties/) می‌خواند:

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// خواندن ویژگی‌های پیش‌ساخت سند.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// خواندن ویژگی‌های سفارشی سند.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

این جریان کار فقط زمانی عمل می‌کند که ویژگی‌های سند هنگام رمزگذاری ارائه به‌صورت عمومی (غیررمزنگاری) باقی مانده باشند. اگر ویژگی‌های سند رمزنگاری شوند، تنظیم `OnlyLoadDocumentProperties` به `true` باعث بروز استثنا می‌شود زیرا در این حالت رمز عبور نادیده گرفته می‌شود. برای دسترسی به ویژگی‌های سند رمزنگاری‌شده یا بارگذاری کامل ارائه شامل اسلایدها و سایر محتوا، مقدار صحیح `Password` را در [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) فراهم کنید.

## **بررسی اینکه آیا یک ارائه با رمز عبور محافظت شده است**

قبل از بارگذاری یک ارائه، ممکن است بخواهید بررسی کنید که آیا آن با رمز عبور محافظت شده است یا نه. این کار به شما کمک می‌کند تا خطاها و مشکلات مشابهی که هنگام بارگذاری یک ارائهٔ محافظت‌شده با رمز عبور بدون رمز صحیح رخ می‌دهد، جلوگیری کنید.

این کد C# نشان می‌دهد چگونه یک ارائه را بدون بارگذاری واقعی آن بررسی کنید تا ببینید آیا با رمز عبور محافظت شده است یا نه:

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **بررسی اینکه آیا یک ارائه رمزنگاری شده است**

Aspose.Slides به شما امکان می‌دهد بررسی کنید آیا یک ارائه رمزنگاری شده است یا نه. برای انجام این کار، می‌توانید از ویژگی [IsEncrypted](https://reference.aspose.com/slides/fa/net/aspose.slides/protectionmanager/properties/isencrypted) استفاده کنید که `true` برمی‌گرداند اگر ارائه رمزگذاری شده باشد و در غیر این صورت `false`.

این کد نمونه نشان می‌دهد چگونه بررسی کنید آیا یک ارائه رمزنگاری شده است یا نه:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **بررسی اینکه آیا یک ارائه با حفاظت نوشتن است**

Aspose.Slides به شما امکان می‌دهد بررسی کنید آیا یک ارائه با حفاظت نوشتن است یا نه. برای انجام این کار، می‌توانید از ویژگی [IsWriteProtected](https://reference.aspose.com/slides/fa/net/aspose.slides/protectionmanager/properties/iswriteprotected) استفاده کنید که `true` برمی‌گرداند اگر ارائه با حفاظت نوشتن باشد و در غیر این صورت `false`.

این کد نمونه نشان می‌دهد چگونه بررسی کنید آیا یک ارائه با حفاظت نوشتن است یا نه:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **تایید استفاده از رمز عبور در ارائه**

ممکن است بخواهید بررسی و تأیید کنید که رمز عبور خاصی برای محافظت از سند یک ارائه استفاده شده است. Aspose.Slides ابزارهای لازم برای اعتبارسنجی یک رمز عبور را فراهم می‌کند.

این کد نمونه نشان می‌دهد چگونه یک رمز عبور را اعتبارسنجی کنید:

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // بررسی می‌کند آیا رمز عبور مطابقت دارد.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

این مقدار `true` باز می‌گرداند اگر ارائه با رمز عبور مشخص شده رمزگذاری شده باشد؛ در غیر این صورت `false`.

{{% alert color="info" title="همچنین ببینید" %}} 
- [امضای دیجیتال در PowerPoint](/slides/fa/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **محافظت از یک ارائه به‌صورت آنلاین**

1. به صفحه [**Aspose.Slides Lock**](https://products.aspose.app/slides/fa/lock) ما بروید. 
1. روی **Drop or upload your files** کلیک کنید.
1. فایلی که می‌خواهید با رمز عبور محافظت کنید را از رایانهٔ خود انتخاب کنید. 
1. رمز عبور مورد نظر خود را برای حفاظت از ویرایش و رمز عبور مورد نظر خود را برای حفاظت از مشاهده وارد کنید.
1. اگر می‌خواهید کاربران ارائه شما را به عنوان نسخهٔ نهایی ببینند، گزینهٔ **Mark as final** را علامت بزنید.
1. روی **PROTECT NOW.** کلیک کنید. 
1. روی **DOWNLOAD NOW.** کلیک کنید.

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Aspose.Slides چه روش‌های رمزگذاری را پشتیبانی می‌کند؟**

Aspose.Slides از روش‌های رمزگذاری مدرن، از جمله الگوریتم‌های مبتنی بر AES، پشتیبانی می‌کند که سطح بالایی از امنیت داده‌ها را برای ارائه‌های شما تضمین می‌نماید.

**اگر هنگام تلاش برای باز کردن یک ارائه، رمز عبور نادرست وارد شود چه اتفاقی می‌افتد؟**

در صورت استفاده از رمز عبور نادرست، یک استثنا پرتاب می‌شود که نشان می‌دهد دسترسی به ارائه رد شده است. این امر از دسترسی غیرمجاز جلوگیری کرده و محتوای ارائه را محافظت می‌کند.

**آیا هنگام کار با ارائه‌های محافظت‌شده با رمز عبور، تأثیرات عملکردی وجود دارد؟**

فرآیند رمزگذاری و رمزگشایی ممکن است بار کمی را هنگام عملیات باز کردن و ذخیره‌سازی ایجاد کند. در اکثر موارد این تأثیر عملکردی کم است و به‌طور قابل توجهی بر زمان کلی پردازش کارهای ارائه‌ شما تأثیر نمی‌گذارد.