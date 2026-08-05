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
description: "قلم‌ها را در اسلایدهای پاورپوینت با Aspose.Slides برای C++ سفارشی کنید تا ارائه‌های خود را در هر دستگاهی واضح و سازگار نگه دارید."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد تا قلم‌های سفارشی را در ارائه‌ها بدون نصب بر روی سیستم عامل استفاده کنید. می‌توانید قلم‌ها را از پوشه‌های سفارشی بارگذاری کنید، قلم‌ها را برای یک ارائه خاص از طریق منابع قلم در سطح سند فراهم کنید، یا قلم‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

قلم‌های بارگذاری‌شده هنگام رندر یا استخراج یک ارائه مورد استفاده قرار می‌گیرند، برای مثال به PDF، تصویرها و سایر فرمت‌های پشتیبانی‌شده. این امر به حفظ سازگاری خروجی ارائه در محیط‌های مختلف کمک می‌کند. این مقاله همچنین نحوه بررسی پوشه‌های قلم مورد استفاده توسط Aspose.Slides و نحوه پاک‌سازی کش قلم پس از کار با قلم‌های خارجی را شرح می‌دهد.

ثبت قلم‌های سفارشی برای رندر کردن، متفاوت از جاسازی قلم‌ها در یک فایل PPTX است. اگر لازم باشد قلم داخل خود ارائه ذخیره شود، باید به صراحت از قابلیت‌های جاسازی قلم استفاده کنید.

{{% alert color="primary" %}} 

Aspose Slides به شما امکان می‌دهد این قلم‌ها را با استفاده از [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) بارگذاری کنید:

* قلم‌های TrueType (.ttf) و TrueType Collection (.ttc). به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.

* قلم‌های OpenType (.otf). به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.

{{% /alert %}}

## **بارگذاری قلم‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد قلم‌های مورد استفاده در یک ارائه را بدون نصب روی سیستم بارگذاری کنید. این موضوع بر خروجی استخراج—مانند PDF، تصویرها و سایر فرمت‌های پشتیبانی‌شده—تأثیر می‌گذارد، به‌طوری که اسناد حاصل در محیط‌های مختلف یک‌دست به نظر برسند. قلم‌ها از شاخه‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه که شامل فایل‌های قلم هستند را مشخص کنید.  
2. متد استاتیک [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) را صدا بزنید تا قلم‌ها از آن پوشه‌ها بارگذاری شوند.  
3. ارائه را بارگذاری و رندر/استخراج کنید.  
4. متد [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/clearcache/) را فراخوانی کنید تا کش قلم پاک شود.

مثال کد زیر فرآیند بارگذاری قلم را نشان می‌دهد:

```cpp
// پوشه‌هایی که شامل فایل‌های قلم سفارشی هستند را تعریف کنید.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// قلم‌های سفارشی را از پوشه‌های مشخص‌شده بارگذاری کنید.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ارائه را با استفاده از قلم‌های بارگذاری‌شده رندر/استخراج کنید (مثلاً به PDF، تصاویر یا فرمت‌های دیگر).
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// پس از اتمام کار، کش قلم را پاک کنید.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) پوشه‌های اضافی به مسیرهای جستجوی قلم می‌افزاید، اما ترتیب مقداردهی اولیه قلم را تغییر نمی‌دهد.
قلم‌ها به ترتیب زیر مقداردهی می‌شوند:

1. مسیر قلم پیش‌فرض سیستم عامل.  
2. مسیرهایی که توسط [FontsLoader](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/) بارگذاری شده‌اند.

{{%/alert %}}

## **دریافت پوشه‌های قلم سفارشی**
Aspose.Slides متد [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/getfontfolders/) را ارائه می‌دهد تا به شما امکان یافتن پوشه‌های قلم را بدهد. این متد پوشه‌های اضافه‌شده از طریق متد `LoadExternalFonts` و پوشه‌های قلم سیستم را برمی‌گرداند.

این کد C++ نشان می‌دهد چگونه از متد [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/getfontfolders/) استفاده کنید:

``` cpp
// این خط پوشه‌هایی را که برای فایل‌های قلم بررسی می‌شوند خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های قلم سیستم.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **تعیین قلم‌های سفارشی مورد استفاده در یک ارائه**
Aspose.Slides خصوصیت [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) را فراهم می‌کند تا به شما اجازه دهد قلم‌های خارجی که با ارائه استفاده می‌شوند را مشخص کنید.

این کد C++ نشان می‌دهد چگونه از خصوصیت [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) استفاده کنید:

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // کار با ارائه
    // CustomFont1 و CustomFont2 و همچنین قلم‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
}
```

## **مدیریت قلم‌ها به صورت خارجی**
Aspose.Slides متد [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfont/) را ارائه می‌دهد تا بتوانید قلم‌های خارجی را به یک آرایه بایت بارگذاری کنید.

این کد C++ فرآیند بارگذاری قلم به صورت آرایه بایت را نشان می‌دهد:

```cpp
// مسیر پوشه اسناد
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **سؤالات متداول**

**آیا قلم‌های سفارشی بر خروجی به تمام فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟**

بله. قلم‌های متصل توسط رندرر در تمام فرمت‌های استخراج استفاده می‌شوند.

**آیا قلم‌های سفارشی به طور خودکار در فایل PPTX نهایی جاسازی می‌شوند؟**

خیر. ثبت یک قلم برای رندر کردن برابر با جاسازی آن در یک PPTX نیست. اگر نیاز دارید قلم داخل فایل ارائه حفظ شود، باید به‌صورت صریح از [امکانات جاسازی](/slides/fa/cpp/embedded-font/) استفاده کنید.

**آیا می‌توانم رفتار جایگزینی را زمانی که قلم سفارشی برخی گلیف‌ها را ندارند کنترل کنم؟**

بله. می‌توانید [جایگزینی قلم](/slides/fa/cpp/font-substitution/)، [قوانین جایگزینی](/slides/fa/cpp/font-replacement/) و [مجموعه‌های جایگزین](/slides/fa/cpp/fallback-font/) را پیکربندی کنید تا دقیقاً مشخص کنید هنگام عدم وجود گلیف درخواست‌شده، از کدام قلم استفاده شود.

**آیا می‌توانم قلم‌ها را در کانتینرهای Linux/Docker بدون نصب سراسری استفاده کنم؟**

بله. به پوشه‌های قلم خود اشاره کنید یا قلم‌ها را از آرایه‌های بایت بارگذاری کنید. این کار تمام وابستگی به پوشه‌های قلم سیستم در تصویر کانتینر را حذف می‌کند.

**در مورد مجوزها چیست—آیا می‌توانم هر قلم سفارشی را بدون محدودیت جاسازی کنم؟**

شما مسئول رعایت مجوزهای قلم هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را منع می‌کنند. همیشه قبل از توزیع خروجی‌ها، قرارداد استفاده از قلم (EULA) را مرور کنید.