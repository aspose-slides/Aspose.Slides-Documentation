---
title: سفارشی‌سازی قلم‌های پاورپوینت در C++
linktitle: قلم سفارشی
type: docs
weight: 20
url: /fa/cpp/custom-font/
keywords:
- قلم
- قلم سفارشی
- قلم خارجی
- بارگذاری قلم
- مدیریت قلم‌ها
- پوشه قلم
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "قلم‌های اسلایدهای پاورپوینت را با Aspose.Slides برای C++ سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و سازگار باقی بمانند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد تا از قلم‌های سفارشی در ارائه‌ها بدون نصب آن‌ها بر روی سیستم‌عامل استفاده کنید. شما می‌توانید قلم‌ها را از پوشه‌های سفارشی بارگذاری کنید، قلم‌ها را برای یک ارائه خاص از طریق منابع قلم سطح سند فراهم کنید، یا قلم‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

قلم‌های بارگذاری‌شده زمانی که یک ارائه رندر یا خروجی می‌شود، برای مثال به PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده، استفاده می‌شوند. این کمک می‌کند تا خروجی ارائه در محیط‌های مختلف یکسان باشد. این مقاله همچنین توضیح می‌دهد چگونه پوشه‌های قلم استفاده‌شده توسط Aspose.Slides را بررسی کنید و پس از کار با قلم‌های خارجی، حافظه‌پنهان قلم‌ها را پاک کنید.

ثبت قلم‌های سفارشی برای رندر کردن جدا از جاسازی قلم‌ها در یک فایل PPTX است. اگر یک قلم باید داخل خود ارائه ذخیره شود، از ویژگی‌های جاسازی قلم به‌صورت صریح استفاده کنید.

{{% alert color="primary" %}} 

Aspose Slides به شما اجازه می‌دهد این قلم‌ها را با استفاده از [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) بارگذاری کنید:

* قلم‌های TrueType (.ttf) و TrueType Collection (.ttc). برای جزئیات به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.
* قلم‌های OpenType (.otf). برای جزئیات به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.

{{% /alert %}}

## **بارگذاری قلم‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد قلم‌های استفاده‌شده در یک ارائه را بدون نصب آن‌ها بر روی سیستم بارگذاری کنید. این بر خروجی صادرات تأثیر می‌گذارد—مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده—به‌طوری که اسناد نهایی در محیط‌های مختلف یکسان به‌نظر برسند. قلم‌ها از پوشه‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه که حاوی فایل‌های قلم هستند را مشخص کنید.
2. متد ایستا [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) را صدا بزنید تا قلم‌ها از آن پوشه‌ها بارگذاری شوند.
3. ارائه را بارگذاری و رندر/صادرات کنید.
4. برای پاک کردن حافظه‌پنهان قلم، [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/clearcache/) را فراخوانی کنید.

مثال کد زیر فرآیند بارگذاری قلم‌ها را نشان می‌دهد:

```cpp
// پوشه‌هایی را که شامل فایل‌های قلم سفارشی هستند تعریف کنید.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// قلم‌های سفارشی را از پوشه‌های مشخص‌شده بارگذاری کنید.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ارائه را رندر/صادرات کنید (مثلاً به PDF، تصاویر یا سایر فرمت‌ها) با استفاده از قلم‌های بارگذاری شده.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// پس از اتمام کار حافظه‌پنهان قلم را پاک کنید.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) پوشه‌های اضافی به مسیرهای جستجوی قلم اضافه می‌کند، اما ترتیب اولیه‌سازی قلم‌ها را تغییر نمی‌دهد.
قلم‌ها به ترتیب زیر مقداردهی اولیه می‌شوند:

1. مسیر قلم پیش‌فرض سیستم‌عامل.
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/) بارگذاری شده‌اند.

{{%/alert %}}

## **دریافت پوشه‌های قلم سفارشی**

Aspose.Slides [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/getfontfolders/) را ارائه می‌دهد تا به شما امکان پیدا کردن پوشه‌های قلم را بدهد. این متد پوشه‌هایی که از طریق متد `LoadExternalFonts` اضافه شده‌اند و پوشه‌های قلم سیستم را برمی‌گرداند.

این کد C++ نشان می‌دهد چگونه از متد [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/getfontfolders/) استفاده کنید:

``` cpp
// این خط پوشه‌هایی را که برای فایل‌های قلم بررسی می‌شوند، خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های قلم سیستم.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **تعیین قلم‌های سفارشی استفاده‌شده با یک ارائه**

Aspose.Slides property [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) را فراهم می‌کند تا بتوانید قلم‌های خارجی که با ارائه استفاده خواهند شد را مشخص کنید.

این کد C++ نشان می‌دهد چگونه از property [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) استفاده کنید:

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //کار با ارائه
    //CustomFont1، CustomFont2 به‌همراه قلم‌ها از پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
}
```

## **مدیریت قلم‌ها به‌صورت خارجی**

Aspose.Slides متد [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfont/) را فراهم می‌کند تا بتوانید قلم‌های خارجی را به یک آرایه بایت بارگذاری کنید.

این کد C++ فرآیند بارگذاری قلم به‌صورت آرایه بایت را نشان می‌دهد:

```cpp
// The path to the documents directory
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **پرسش‌های متداول**

**آیا قلم‌های سفارشی بر خروجی به همه فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟**

بله. قلم‌های متصل‌شده توسط رندرر در تمام فرمت‌های خروجی استفاده می‌شوند.

**آیا قلم‌های سفارشی به‌صورت خودکار در PPTX نهایی جاسازی می‌شوند؟**

خیر. ثبت یک قلم برای رندر کردن همانند جاسازی آن در یک PPTX نیست. اگر به قلمی نیاز دارید که داخل فایل ارائه ذخیره شود، باید از [ویژگی‌های جاسازی](/slides/fa/cpp/embedded-font/) صریحاً استفاده کنید.

**آیا می‌توانم رفتار جایگزینی را زمانی که یک قلم سفارشی برخی گلیف‌ها را ندارد، کنترل کنم؟**

بله. می‌توانید [جایگزینی قلم](/slides/fa/cpp/font-substitution/)، [قوانین جایگزینی](/slides/fa/cpp/font-replacement/)، و [مجموعه‌های جایگزین](/slides/fa/cpp/fallback-font/) را پیکربندی کنید تا دقیقاً تعیین کنید در صورت عدم وجود گلیف درخواست‌شده، از کدام قلم استفاده شود.

**آیا می‌توانم قلم‌ها را در کانتینرهای Linux/Docker بدون نصب کلی سیستم استفاده کنم؟**

بله. به پوشه‌های قلم خود اشاره کنید یا قلم‌ها را از آرایه‌های بایت بارگذاری کنید. این وابستگی به پوشه‌های قلم سیستم در تصویر کانتینر را حذف می‌کند.

**در مورد مجوزها—آیا می‌توانم هر قلم سفارشی را بدون محدودیت جاسازی کنم؟**

شما مسئول رعایت مجوزهای قلم هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را ممنوع می‌کنند. همواره پیش از توزیع خروجی‌ها، شرایط استفاده (EULA) قلم را مرور کنید.