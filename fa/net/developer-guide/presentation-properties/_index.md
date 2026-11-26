---
title: مدیریت ویژگی‌های ارائه در .NET
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/net/presentation-properties/
keywords:
- ویژگی‌های PowerPoint
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های داخلی
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- فرادادهٔ سند
- ویرایش فراداده
- زبان تصحیح
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ویژگی‌های اصلی ارائه در Aspose.Slides برای .NET را مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه‌سازی نمایید."
---
## **معرفی**

Aspose.Slides for .NET از ویژگی‌های **ساخته‌شده درون‌سیستم** و **سفارشی** برای ویژگی‌های سند پشتیبانی می‌کند. از این ویژگی‌ها برای خواندن و به‌روزرسانی فراداده‌های ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما امکان می‌دهد تا با ویژگی‌های سند ارائه از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) کار کنید. یک نمونه از این رابط توسط [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides هنگام ذخیره‌سازی ارائه‌ها، فراداده‌های برنامه و تولیدکننده را مدیریت می‌کند؛ این فیلدها نرم‌افزاری که خروجی را ایجاد کرده است شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت ویژگی‌های ارائه**

ویژگی‌های سند اطلاعات توصیفی را در کنار محتوای ارائه ذخیره می‌کنند. این ویژگی‌ها به دو دسته تقسیم می‌شوند:

- **ویژگی‌های داخلی** شامل فراداده‌های استانداردی مانند عنوان، نویسنده و آمارهای سند هستند.
- **ویژگی‌های سفارشی** جفت‌های نام/مقدار تعریف شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides for .NET دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، **File → Info → Properties → Advanced Properties** را انتخاب کنید تا فراداده‌های سند را بررسی کنید. این گفتگو اطلاعات را در برگه‌هایی مانند **Summary**، **Statistics**، **Contents** و **Custom** گروه‌بندی می‌کند. برای مدیریت ویژگی‌های تعریف‌شده توسط کاربر، از برگه **Custom** استفاده کنید.

## **خواندن ویژگی‌های عمومی از یک ارائهٔ رمزنگاری‌شده**

یک رمز عبور باز کردن معمولاً هم محتوای ارائه و هم ویژگی‌های سند را محافظت می‌کند. وقتی ارائه‌ای با [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) که مقدار `false` دارد رمزنگاری می‌شود، ویژگی‌های سند آن عمومی می‌مانند. سپس یک برنامه می‌تواند [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) را به `true` تنظیم کند و فراداده‌های عمومی را بدون ارائهٔ رمز عبور باز کردن بخواند.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) کنترل می‌کند که Aspose.Slides چه چیزی را بارگذاری می‌کند؛ هیچ چیز را رمزگشایی نمی‌کند. اگر ویژگی‌ها در رمزنگاری گنجانده شده باشند، بارگذاری آن‌ها بدون رمز عبور شکست می‌خورد. اگر ارائه رمزنگاری نشده باشد، گزینه نادیده گرفته می‌شود و ارائه کامل بارگذاری می‌شود.

مثال نیاز به یک ارائهٔ رمزنگاری‌شده دارد که ویژگی‌های سند آن عمومی باقی مانده باشند. این مثال حالت بارگذاری را از طریق [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) تأیید می‌کند و سپس ویژگی‌های داخلی را از طریق [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) می‌خواند:

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

در این حالت، محتوای اسلایدها بارگذاری نمی‌شود. اسلایدها، مسترها، چینش‌ها، اشکال، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملی که نیاز به مدل شیء کامل ارائه دارد، [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) را بررسی کنند.

{{% alert color="warning" title="Security" %}}
فراداده‌های عمومی ممکن است نام نویسندگان، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کنند. ویژگی‌های حساس را به همراه ارائه رمزنگاری کنید. آنها را عمومی بگذارید فقط وقتی که سیستم‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی به دسترسی بدون رمز عبور داشته باشند.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائهٔ رمزنگاری‌شده**

برای یک فایل PPTX رمزنگاری‌شده، ارائه‌ای که با [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) بارگذاری می‌شود برای خواندن فراداده‌های عمومی در نظر گرفته شده است. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیء فقط‑متادیتا ذخیره کند زیرا ویژگی‌های عمومی باید با داده‌های متناظر درون ارائهٔ رمزنگاری شده سازگار باشند. بنابراین به‌روزرسانی آن‌ها نیازمند رمز عبور باز کردن صحیح و بارگذاری کامل است.

مثال نیاز به یک ارائهٔ PPTX رمزنگاری‌شده دارد که ویژگی‌های سند عمومی داشته باشد و رمز عبور باز کردن آن شناخته شده باشد. این مثال ارائه کامل را با [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) باز می‌کند، ویژگی‌های داخلی عمومی را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با استفاده از [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) اطمینان می‌یابد که رمزنگاری حفظ شده و فراداده‌های عمومی را بدون رمز عبور دوباره باز می‌کند تا مقادیر جدید را تأیید کند:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

اگر برنامه اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید ویژگی‌های عمومی یک فایل PPTX رمزنگاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های داخلی**

رابط [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) فراداده‌های داخلی را از طریق ویژگی‌های تایپی، شامل [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)، [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/)، و [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/) افشا می‌کند. این مثال یک ارائهٔ موجود را باز می‌کند و فراداده‌های ذخیره شدهٔ آن را در کنسول چاپ می‌کند. مقادیر بستگی به ارائهٔ ورودی دارد؛ برخی فیلدها ممکن است خالی باشند.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

### **گزارش شماره بازبینی و زمان ویرایش**

برای گزارش یک ردیف برای هر فایل PPTX در پوشه `presentations`، [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) را فراخوانی کنید تا [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) آن را بدون بارگذاری اسلایدها برای ویرایش دریافت کنید. قالب استاندارد `c` برای `TimeSpan` شامل تعداد روزها می‌شود زمانی که مدت زمان به ۲۴ ساعت برسد.

```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

خروجی نمونه برای یک ارائه با ۱ روز، ۲ ساعت و ۵ دقیقه زمان ویرایش ثبت‌شده:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) یک فرادادهٔ قابل نوشتن است. مقدار آن به تنهایی نمی‌تواند نشان دهد چند بار ارائه ذخیره شده یا تاریخچهٔ نسخهٔ آن را بازسازی کند.

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) مدت زمان ویرایش ثبت‌شده در فایل است. مقدار `00:00:00` به این معنی است که مدت زمان ذخیره‌شده صفر است. این نشان نمی‌دهد هیچ‌کس ارائه را ویرایش نکرده است.

## **تغییر ویژگی‌های داخلی**

برای به‌روزرسانی فراداده‌های داخلی، مقادیر را به ویژگی‌های قابل نوشتن که توسط [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) افشا شده‌اند اختصاص دهید. این مثال یک ارائهٔ موجود را باز می‌کند، [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)، [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/)، [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/)، [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/)، و [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/) را تنظیم می‌کند، سپس ارائهٔ به‌روزرسانی‌شده را با [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ذخیره می‌نماید. فایل PPTX ذخیره‌شده حاوی فراداده‌های جدید خواهد بود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **مدیریت پایهٔ پیوندها**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) پایهٔ سطری سطح سند برای پیوندهای نسبی را ذخیره می‌کند. این هنگام جابه‌جایی یک ارائه و فایل‌های لینک‌شده‌اش به مکان دیگری مفید است. این مقدار مستقل از [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) یک پیوند تک است؛ تغییر پایه، آدرس‌های ذخیره‌شدهٔ پیوندها را بازنویسی نمی‌کند و مقصدهای مطلق را تغییر نمی‌دهد.

مثال نیاز به یک ارائه دارد که هم یک پیوند نسبی مانند `target.html` و هم یک پیوند مطلق مانند `https://example.org/absolute.html` داشته باشد. پایهٔ موجود را می‌خواند، یک آدرس پایه جدید انتساب می‌دهد و ارائه را ذخیره و دوباره باز می‌کند تا مقدار را بررسی کند. سپس پایه را با `string.Empty` پاک می‌کند و مقدار خالی را در فایل ذخیره‌شدهٔ جداگانه تأیید می‌نماید. آدرس پایهٔ مثال را با مکان فایل‌های لینک‌شدهٔ خود جایگزین کنید.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

دو پیام تأیید باید `True` چاپ کنند. پاک کردن پایه، آدرس‌های پیوندهای تک‌تکی را دست‌نخورده نگه می‌دارد.

یک پیوند نسبی به `target.pptx` وقتی پایه به پوشه `old` اشاره می‌کرد، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشه `new`، ذخیره و بازکردن مجدد ارائه، همان پیوند `new/target.pptx` را باز می‌کرد. یک پیوند مطلق همچنان همان فایل را باز می‌کرد. پیوندهای نسبی خود را در PowerPoint قبل و بعد از جابه‌جایی ارائه یا تغییر پایه تست کنید.

## **افزودن ویژگی‌های سفارشی به ارائه**

ویژگی‌های سفارشی فراداده‌هایی را ذخیره می‌کنند که فیلد داخلی متناظری ندارند. [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) به شما اجازه می‌دهد تا مقدار را بر اساس نام ویژگی اختصاص دهید. این مثال یک ارائه می‌ساشد، دو مقدار متنی و یک مقدار عددی نسخه را اضافه می‌کند، و ارائه را با [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ذخیره می‌نماید. اختصاص مقدار به یک نام موجود، مقدار آن ویژگی را جایگزین می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

این مثال یک ارائه حاوی ویژگی‌های سفارشی را باز می‌کند و با استفاده از [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) بر روی آن‌ها پیمایش می‌کند. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) یک شاخص صفر‑محور می‌پذیرد و نامی که توسط [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) استفاده می‌شود، برمی‌گرداند. مثال هر نام و مقدار اصلی را چاپ می‌کند، هر مقدار را با یک رشته شماره‌دار جایگزین می‌کند صرف‌نظر از نوع اصلی آن، و تغییرات را ذخیره می‌نماید. اگر ویژگی سفارشی وجود نداشته باشد، حلقه تغییری ایجاد نمی‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **مثال زنده**

اپلیکیشن آنلاین [**مشاهده و ویرایش فراداده‌های پاورپوینت**](https://products.aspose.app/slides/metadata) را امتحان کنید تا ببینید چگونه با ویژگی‌های سند با استفاده از API Aspose.Slides کار می‌کنید:

[![مشاهده و ویرایش فراداده‌های پاورپوینت](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **سوالات متداول**

**چگونه می‌توان یک ویژگی داخلی را از یک ارائه حذف کرد؟**

ویژگی‌های داخلی بخش جدایی‌نشدنی ارائه هستند و نمی‌توان آن‌ها را به‌طور کامل حذف کرد. با این حال، می‌توانید مقادیر آن‌ها را تغییر دهید یا اگر ویژگی اجازه دهد به مقدار خالی تنظیم کنید.

**اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنم چه می‌شود؟**

اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی قبلی ویژگی ندارید، زیرا Aspose.Slides به‌ طور خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توانم بدون بارگذاری کامل ارائه، ویژگی‌های ارائه را دسترسی داشته باشم؟**

بله. می‌توانید از [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) استفاده کنید و سپس [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) را فراخوانی کنید تا فرادادهٔ ذخیره‌شدهٔ سند را بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص قالب، به [ساخت یک فهرست سبک ارائه](/slides/fa/net/examine-presentation/) مراجعه کنید.

**آیا می‌توانم ویژگی‌های عمومی یک ارائهٔ رمزنگاری‌شده را بدون رمز عبور باز کردن آن بخوانم؟**

بله. ارائه باید با [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) که مقدار `false` دارد رمزنگاری شده باشد و با [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) که مقدار `true` دارد بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزنگاری‌شده را در حالت فقط‑ویژگی‌های‑سند به‌روزرسانی کنم؟**

خیر. داده‌های عمومی و رمزنگاری‌شده باید همگام باشند، بنابراین به‌روزرسانی یک فایل PPTX رمزنگاری‌شده مستلزم بارگذاری کامل ارائه با رمز عبور باز کردن صحیح است.