---
title: سفارشی‌سازی فونت‌های پاورپوینت در C++
linktitle: فونت سفارشی
type: docs
weight: 20
url: /fa/cpp/custom-font/
keywords:
- فونت
- فونت سفارشی
- فونت خارجی
- بارگذاری فونت
- مدیریت فونت‌ها
- پوشه فونت
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "فونت‌های اسلایدهای پاورپوینت را با Aspose.Slides برای C++ سفارشی کنید تا ارائه‌های خود را واضح و سازگار در همه دستگاه‌ها نگه دارید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد تا فونت‌های سفارشی را در ارائه‌ها بدون نصب بر روی سیستم‌عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، فونت‌ها را برای یک ارائه خاص از طریق منبع‌های فونت در سند تعیین کنید، یا فونت‌های خارجی را مستقیم از داده‌های باینری بارگذاری نمایید.

فونت‌های بارگذاری‌شده زمانی که ارائه رندر یا خروجی می‌شود، برای مثال به PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده، استفاده می‌شوند. این امر به حفظ سازگاری خروجی ارائه در محیط‌های مختلف کمک می‌کند. مقاله همچنین نحوه بررسی پوشه‌های فونت مورد استفاده توسط Aspose.Slides و چگونگی پاک‌سازی کش فونت پس از کار با فونت‌های خارجی را توضیح می‌دهد.

ثبت فونت‌های سفارشی برای رندری کردن متفاوت از جاسازی فونت‌ها در فایل PPTX است. اگر فونتی باید داخل خود ارائه ذخیره شود، از ویژگی‌های جاسازی فونت به‌طور صریح استفاده کنید.

{{% alert color="info" %}} 

Aspose Slides به شما اجازه می‌دهد این فونت‌ها را با استفاده از [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). مشاهده کنید [TrueType](https://en.wikipedia.org/wiki/TrueType).

* فونت‌های OpenType (.otf). مشاهده کنید [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های مورد استفاده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این مورد بر خروجی‌های صادراتی—مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده—اثر می‌گذارد تا اسناد حاصل در محیط‌های مختلف یکدست به نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های فونت را مشخص کنید.  
2. متد ثابت [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) را فراخوانی کنید تا فونت‌ها از آن پوشه‌ها بارگذاری شوند.  
3. ارائه را بارگذاری و رندر/صادر کنید.  
4. برای پاک‌سازی کش فونت، [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/clearcache/) را صدا بزنید.

مثال کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// پوشه‌هایی که حاوی فایل‌های فونت سفارشی هستند را تعریف کنید.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// فونت‌های سفارشی را از پوشه‌های مشخص شده بارگذاری کنید.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ارائه را رندر/صادرات کنید (مثلاً به PDF، تصویرها یا فرمت‌های دیگر) با استفاده از فونت‌های بارگذاری‌شده.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// پس از اتمام کار کش فونت را پاک کنید.
FontsLoader::ClearCache();
```

{{% alert color="info" title="توجه" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) پوشه‌های اضافی را به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب مقداردهی اولیه فونت را تغییر نمی‌دهد. فونت‌ها به ترتیب زیر مقداردهی می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم‌عامل.  
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/) بارگذاری شده‌اند.

{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**
Aspose.Slides متد [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/getfontfolders/) را فراهم می‌کند تا بتوانید پوشه‌های فونت را پیدا کنید. این متد پوشه‌های اضافه‌شده از طریق متد `LoadExternalFonts` و پوشه‌های فونت سیستم را برمی‌گرداند.

این کد C++ نشان می‌دهد چگونه از متد [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/getfontfolders/) استفاده کنید:

```cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// این خط پوشه‌هایی را که برای فایل‌های فونت بررسی می‌شوند، خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های فونت سیستم.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **مشخص کردن فونت‌های سفارشی استفاده‌شده در یک ارائه**
Aspose.Slides ویژگی [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) را فراهم می‌کند تا بتوانید فونت‌های خارجی را که با ارائه استفاده می‌شوند، مشخص کنید.

این کد C++ نشان می‌دهد چگونه از ویژگی [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) استفاده کنید:

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //کار با ارائه
    //CustomFont1، CustomFont2 و همچنین فونت‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آنها برای ارائه در دسترس هستند
}
```

## **مدیریت فونت‌ها به‌صورت خارجی**
Aspose.Slides متد [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfont/) را فراهم می‌کند تا بتوانید فونت‌های خارجی را به‌صورت آرایه بایت بارگذاری کنید.

این کد C++ فرآیند بارگذاری فونت از آرایه بایت را نشان می‌دهد:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

## **سوالات متداول**

### آیا فونت‌های سفارشی بر خروجی به تمام فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟

بله. فونت‌های ثبت‌شده توسط رندرر در تمام فرمت‌های خروجی استفاده می‌شوند.

### آیا فونت‌های سفارشی به‌صورت خودکار در PPTX نهایی جاسازی می‌شوند؟

خیر. ثبت یک فونت برای رندری کردن همانند جاسازی آن در PPTX نیست. اگر نیاز دارید فونت داخل فایل ارائه باشد، باید از ویژگی‌های **جاسازی صریح** استفاده کنید.

### آیا می‌توانم رفتار fallback را زمانی که یک فونت سفارشی برخی گلیف‌ها را ندارد، کنترل کنم؟

بله. می‌توانید [جایگزینی فونت](/slides/fa/cpp/font-substitution/)، [قوانین جایگزینی](/slides/fa/cpp/font-replacement/) و [مجموعه‌های fallback](/slides/fa/cpp/fallback-font/) را پیکربندی کنید تا دقیقاً تعیین کنید هنگام نبود گلیف درخواست‌شده چه فونتی استفاده شود.

### آیا می‌توانم در کانتینرهای Linux/Docker بدون نصب سیستم‌عامل فونت‌ها از آن‌ها استفاده کنم؟

بله. کافی است به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه بایت بارگذاری کنید. این کار وابستگی به پوشه‌های فونت سیستم در تصویر کانتینر را حذف می‌کند.

### درباره مجوزها—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟

شما مسئول رعایت حقوق مالکیت فونت هستید. شرایط مجوزها متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را ممنوع می‌کنند. همیشه قبل از توزیع خروجی‌ها، **EULA** فونت مربوطه را بررسی کنید.