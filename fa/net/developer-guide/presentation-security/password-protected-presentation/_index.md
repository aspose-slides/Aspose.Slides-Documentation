---
title: ارائه‌های ایمن با رمز عبور در .NET
linktitle: محافظت با رمز عبور
type: docs
weight: 20
url: /fa/net/password-protected-presentation/
keywords:
- قفل کردن PowerPoint
- قفل کردن ارائه
- قفل‌گشایی PowerPoint
- قفل‌گشایی ارائه
- محافظت از PowerPoint
- محافظت از ارائه
- تنظیم رمز عبور
- اضافه کردن رمز عبور
- رمزگذاری PowerPoint
- رمزگذاری ارائه
- رمزگشایی PowerPoint
- رمزگشایی ارائه
- محافظت نوشتاری
- امنیت PowerPoint
- امنیت ارائه
- حذف رمز عبور
- حذف محافظت
- حذف رمزگذاری
- غیرفعال‌سازی رمز عبور
- غیرفعال‌سازی محافظت
- حذف محافظت نوشتاری
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بیاموزید چگونه به سادگی ارائه‌های PowerPoint و OpenDocument محافظت‌شده با رمز عبور را قفل و باز کنید با Aspose.Slides برای .NET. ارائه‌های خود را ایمن کنید."
---
## **مقدمه**

وقتی یک ارائه را با رمز عبور محافظت می‌کنید، به این معنی است که رمز عبوری تنظیم می‌کنید که برخی محدودیت‌ها را بر روی ارائه اعمال می‌کند. برای حذف این محدودیت‌ها، باید رمز عبور را وارد کنید. یک ارائه محافظت‌شده با رمز عبور به عنوان یک ارائه قفل‌شده در نظر گرفته می‌شود.

به‌طور معمول، می‌توانید یک رمز عبور تنظیم کنید تا این محدودیت‌ها را بر روی یک ارائه اعمال کنید:

- **تغییر**

  اگر می‌خواهید فقط کاربران خاصی بتوانند ارائه شما را تغییر دهند، می‌توانید محدودیت تغییر را تنظیم کنید. این محدودیت مانع افراد از تغییر، ویرایش یا کپی کردن عناصر در ارائه شما می‌شود مگر این که رمز عبور را وارد کنند.

  با این حال، حتی بدون وارد کردن رمز عبور، کاربر همچنان می‌تواند به سند شما دسترسی پیدا کند و آن را باز کند. در این حالت فقط‑خواندنی، کاربر می‌تواند محتوا—از جمله پیوندها، انیمیشن‌ها، افکت‌ها و سایر عناصر—را داخل ارائه مشاهده کند، اما نمی‌تواند موارد را کپی یا ارائه را ذخیره کند.

- **بازکردن**

  اگر می‌خواهید فقط کاربران خاصی بتوانند ارائه شما را باز کنند، می‌توانید محدودیت بازکردن را تنظیم کنید. این محدودیت مانع افراد از حتی مشاهده محتوای ارائه می‌شود مگر این که رمز عبور را وارد کنند.

  به‌صورت فنی، محدودیت بازکردن همچنین مانع کاربران از تغییر ارائه می‌شود—اگر افراد نتوانند ارائه‌ای را باز کنند، نمی‌توانند آن را تغییر دهند یا اصلاح کنند.

**توجه:** وقتی یک ارائه را برای جلوگیری از باز کردن با رمز عبور محافظت می‌کنید، فایل ارائه رمزگذاری می‌شود.

## **محافظت از رمز عبور در Aspose.Slides**

**قالب‌های پشتیبانی‌شده**

Aspose.Slides پشتیبانی از محافظت با رمز عبور، رمزگذاری و عملیات‌های مشابه را برای ارائه‌ها در این قالب‌ها دارد:

- PPTX و PPT – ارائه‌های Microsoft PowerPoint
- ODP – ارائه‌های OpenDocument
- OTP – قالب‌های ارائه OpenDocument

**عملیات پشتیبانی‌شده**

Aspose.Slides به شما اجازه می‌دهد از محافظت با رمز عبور برای جلوگیری از تغییرات در ارائه‌ها به روش‌های زیر استفاده کنید:

- رمزگذاری یک ارائه
- تنظیم محافظت نوشتاری بر روی یک ارائه

**سایر عملیات**

Aspose.Slides امکان انجام وظایف اضافی مرتبط با محافظت با رمز عبور و رمزگذاری را به روش‌های زیر فراهم می‌کند:

- رمزگشایی یک ارائه؛ باز کردن یک ارائه رمزگذاری‌شده
- حذف رمزگذاری؛ غیرفعال کردن محافظت با رمز عبور
- حذف محافظت نوشتاری از یک ارائه
- بازیابی ویژگی‌های یک ارائه رمزگذاری‌شده
- بررسی اینکه آیا یک ارائه قبل از بارگذاری محافظت‌شده با رمز عبور است یا خیر
- بررسی اینکه آیا یک ارائه رمزگذاری شده است
- بررسی اینکه آیا یک ارائه محافظت‌شده با رمز عبور است

## **محافظت از یک ارائه با رمز عبور**

می‌توانید یک ارائه را با تنظیم رمز عبور رمزگذاری کنید. سپس برای تغییر ارائه قفل‌شده، کاربر باید رمز عبور را وارد کند.

برای رمزگذاری (یا محافظت با رمز عبور) یک ارائه، از متد `Encrypt` در [ProtectionManager](https://reference.aspose.com/slides/fa/net/aspose.slides/protectionmanager) استفاده کنید. رمز عبور را به متد `Encrypt` پاس دهید، سپس با استفاده از متد `Save` ارائه رمزگذاری‌شده را ذخیره کنید.

این نمونه کد نشان می‌دهد چگونه یک ارائه را رمزگذاری کنید:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **تنظیم محافظت نوشتاری بر روی یک ارائه**

می‌توانید علامتی با متن «Do not modify» به ارائه اضافه کنید. این علامت به کاربران اطلاع می‌دهد که شما نمی‌خواهید آن‌ها تغییراتی در ارائه اعمال کنند.

**توجه:** فرآیند محافظت نوشتاری ارائه را رمزگذاری نمی‌کند. بنابراین، کاربران—اگر بخواهند—می‌توانند ارائه را تغییر دهند، اما برای ذخیره تغییرات باید آن را با نام دیگری ذخیره کنند.

برای تنظیم محافظت نوشتاری، از متد `SetWriteProtection` استفاده کنید. این نمونه کد نشان می‌دهد چگونه محافظت نوشتاری را بر روی یک ارائه تنظیم کنید:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **بارگذاری یک ارائه رمزگذاری‌شده**

Aspose.Slides به شما امکان می‌دهد یک ارائه رمزگذاری‌شده را با وارد کردن رمز عبور صحیح بارگذاری کنید. این نمونه کد نشان می‌دهد چگونه یک ارائه رمزگذاری‌شده را بارگذاری کنید:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // کار با ارائه رمزگشایی‌شده.
}
```

## **حذف رمزگذاری از یک ارائه**

می‌توانید رمزگذاری یا محافظت با رمز عبور را از یک ارائه حذف کنید تا کاربران بدون محدودیت به آن دسترسی یا آن را تغییر دهند.

برای حذف رمزگذاری یا محافظت با رمز عبور، متد [RemoveEncryption](https://reference.aspose.com/slides/fa/net/aspose.slides/protectionmanager/methods/removeencryption) را فراخوانی کنید. این نمونه کد نشان می‌دهد چگونه رمزگذاری را از یک ارائه حذف کنید:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **حذف محافظت نوشتاری از یک ارائه**

می‌توانید با استفاده از Aspose.Slides محافظت نوشتاری را از یک فایل ارائه حذف کنید. به این ترتیب، کاربران می‌توانند به دلخواه آن را تغییر دهند—و هنگام انجام چنین کاری هیچ هشداری دریافت نخواهند کرد.

می‌توانید محافظت نوشتاری را با استفاده از متد [RemoveWriteProtection](https://reference.aspose.com/slides/fa/net/aspose.slides/protectionmanager/methods/removewriteprotection) حذف کنید. این نمونه کد نشان می‌دهد چگونه محافظت نوشتاری را از یک ارائه حذف کنید:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **دریافت ویژگی‌های یک ارائه رمزگذاری‌شده**

به‌طور معمول، کاربران در دریافت ویژگی‌های سند یک ارائه رمزگذاری‌شده یا محافظت‌شده با رمز عبور مشکل دارند. با این حال، Aspose.Slides مکانیزمی را ارائه می‌دهد که به شما امکان می‌دهد یک ارائه را با رمز عبور محافظت کنید و در عین حال کاربران بتوانند به ویژگی‌های آن دسترسی داشته باشند.

**توجه:** به‌صورت پیش‌فرض، زمانی که Aspose.Slides یک ارائه را رمزگذاری می‌کند، ویژگی‌های سند آن نیز با رمز عبور محافظت می‌شوند. اگر نیاز دارید ویژگی‌های سند حتی پس از رمزگذاری قابل دسترسی باشند، Aspose.Slides به شما این امکان را می‌دهد.

اگر می‌خواهید کاربران توانایی دسترسی به ویژگی‌های یک ارائه رمزگذاری‌شده را حفظ کنند، ویژگی `EncryptDocumentProperties` در [IProtectionManager](https://reference.aspose.com/slides/fa/net/aspose.slides/iprotectionmanager/) را به `false` تنظیم کنید. این نمونه کد نشان می‌دهد چگونه یک ارائه را رمزگذاری کنید در حالی که همچنان به کاربران دسترسی به ویژگی‌های سند آن داده می‌شود:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **بارگذاری فقط ویژگی‌های سند از یک ارائه رمزگذاری‌شده**

برای بررسی متادیتای یک ارائه رمزگذاری‌شده بدون بارگذاری اسلایدها یا محتویات دیگر، یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) ایجاد کنید و ویژگی [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) را به `true` تنظیم کنید. در این حالت، Aspose.Slides رمز عبور را نادیده می‌گیرد و فقط ویژگی‌های سندی که به‌صورت عمومی قابل دسترسی هستند را بارگذاری می‌کند.

کد زیر ویژگی‌های پیش‌فرض و سفارشی سند را از طریق [IPresentation.DocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/documentproperties/) می‌خواند:

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

این جریان کاری فقط زمانی کار می‌کند که ویژگی‌های سند به‌صورت عمومی (بدون رمزگذاری) باقی مانده باشند. اگر ویژگی‌های سند رمزگذاری شده باشند، تنظیم `OnlyLoadDocumentProperties` به `true` باعث استثنا می‌شود زیرا در این حالت رمز عبور نادیده گرفته می‌شود. برای دسترسی به ویژگی‌های سند رمزگذاری‌شده یا بارگذاری کامل ارائه شامل اسلایدها و محتویات دیگر، مقدار صحیح `Password` را در [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) ارائه کنید.

## **بررسی اینکه آیا یک ارائه با رمز عبور محافظت شده است**

قبل از بارگذاری یک ارائه، ممکن است بخواهید بررسی کنید که آیا با رمز عبور محافظت شده است یا نه. این کار به شما کمک می‌کند از خطاها و مشکلات مشابهی که هنگام بارگذاری یک ارائه محافظت‌شده بدون رمز عبور صحیح رخ می‌دهد، جلوگیری کنید.

این کد C# نشان می‌دهد چگونه یک ارائه را بدون بارگذاری واقعی آن، بررسی کنید که آیا با رمز عبور محافظت شده است:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **بررسی اینکه آیا یک ارائه رمزگذاری شده است**

Aspose.Slides به شما امکان می‌دهد بررسی کنید که آیا یک ارائه رمزگذاری شده است یا نه. برای انجام این کار می‌توانید از ویژگی [IsEncrypted](https://reference.aspose.com/slides/fa/net/aspose.slides/protectionmanager/properties/isencrypted) استفاده کنید که اگر ارائه رمزگذاری شده باشد `true` و در غیر این صورت `false` برمی‌گرداند.

این نمونه کد نشان می‌دهد چگونه بررسی کنید که آیا یک ارائه رمزگذاری شده است:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **بررسی اینکه آیا یک ارائه محافظت نوشتاری دارد**

Aspose.Slides به شما امکان می‌دهد بررسی کنید که آیا یک ارائه محافظت نوشتاری دارد یا نه. برای انجام این کار می‌توانید از ویژگی [IsWriteProtected](https://reference.aspose.com/slides/fa/net/aspose.slides/protectionmanager/properties/iswriteprotected) استفاده کنید که اگر ارائه محافظت نوشتاری داشته باشد `true` و در غیر این صورت `false` برمی‌گرداند.

این نمونه کد نشان می‌دهد چگونه بررسی کنید که آیا یک ارائه محافظت نوشتاری دارد:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **تأیید استفاده از رمز عبور در ارائه**

ممکن است بخواهید بررسی کنید که آیا رمز عبور خاصی برای محافظت از سند ارائه استفاده شده است یا نه. Aspose.Slides ابزاری برای اعتبارسنجی رمز عبور در اختیار شما می‌گذارد.

این نمونه کد نشان می‌دهد چگونه یک رمز عبور را اعتبارسنجی کنید:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // بررسی می‌کند آیا رمز عبور مطابقت دارد.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

اگر ارائه با رمز عبور مشخص شده رمزگذاری شده باشد، `true` برمی‌گرداند؛ در غیر این صورت `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/fa/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **محافظت از یک ارائه به‌صورت آنلاین**

1. به صفحه [**Aspose.Slides Lock**](https://products.aspose.app/slides/fa/lock) ما مراجعه کنید. 
1. روی **Drop or upload your files** کلیک کنید. 
1. فایلی را که می‌خواهید با رمز عبور محافظت کنید از کامپیوتر خود انتخاب کنید. 
1. رمز عبور دلخواه خود را برای محافظت از ویرایش و رمز عبور دلخواه برای محافظت از نمایش وارد کنید. 
1. اگر می‌خواهید کاربران ارائه شما را به‌عنوان نسخه نهایی ببینند، گزینه **Mark as final** را علامت بزنید. 
1. روی **PROTECT NOW.** کلیک کنید. 
1. روی **DOWNLOAD NOW.** کلیک کنید.

![Password protect PowerPoint presentations](slides-lock.png)

## **سؤال‌های متداول**

**Aspose.Slides چه روش‌های رمزگذاری را پشتیبانی می‌کند؟**

Aspose.Slides از روش‌های رمزگذاری مدرن، از جمله الگوریتم‌های مبتنی بر AES، پشتیبانی می‌کند و امنیت بالایی برای داده‌های ارائه‌های شما فراهم می‌سازد.

**اگر هنگام تلاش برای باز کردن یک ارائه، رمز عبور نادرست وارد شود چه اتفاقی می‌افتد؟**

در صورت استفاده از رمز عبور نادرست، یک استثنا پرتاب می‌شود که نشان می‌دهد دسترسی به ارائه رد شده است. این مکانیزم از دسترسی غیرمجاز جلوگیری می‌کند و محتویات ارائه را محافظت می‌نماید.

**آیا استفاده از ارائه‌های محافظت‌شده با رمز عبور تأثیر عملکردی دارد؟**

فرآیند رمزگذاری و رمزگشایی ممکن است کمی بار اضافی هنگام عملیات باز کردن و ذخیره‌سازی ایجاد کند. در اکثر موارد، این تأثیر عملکردی کم است و به‌طور قابل‌توجهی زمان پردازش کلی وظایف ارائه شما را تحت تأثیر قرار نمی‌دهد.