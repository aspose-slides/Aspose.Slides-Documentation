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
description: "فونت‌ها را در اسلایدهای پاورپوینت با Aspose.Slides برای C++ سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و هماهنگ باشند."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد فونت‌های سفارشی را در ارائه‌ها بدون نصب آنها در سیستم‌عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، فونت‌ها را برای یک ارائه خاص از طریق منابع فونت در سطح سند فراهم کنید، یا فونت‌های خارجی را مستقیم از داده‌های باینری بارگذاری کنید.

فونت‌های بارگذاری‌شده هنگام رندر یا صادرات یک ارائه، برای مثال به PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده، استفاده می‌شوند. این کار به حفظ سازگاری خروجی ارائه در محیط‌های مختلف کمک می‌کند. مقاله همچنین روش بررسی پوشه‌های فونت استفاده‌شده توسط Aspose.Slides و نحوه پاک‌سازی کش فونت پس از کار با فونت‌های خارجی را توضیح می‌دهد.

ثبت فونت‌های سفارشی برای رندر کردن جدا از جاسازی فونت‌ها در فایل PPTX است. اگر لازم باشد فونت داخل خود ارائه ذخیره شود، باید از ویژگی‌های جاسازی فونت به‌صورت صریح استفاده کنید.

یک تم ارائه می‌تواند خانواده‌های فونت متفاوتی را برای سیستم‌های نوشتاری مختلف ارجاع دهد. این نگاشت‌ها فقط نام‌های فونت را ذخیره می‌کنند و فایل‌های فونت را نصب یا بارگذاری نمی‌کنند. برای مدیریت این نگاشت‌ها به [فونت‌های تم خاص اسکریپت](/slides/fa/cpp/script-specific-font-mappings/) مراجعه کنید و برای رندر سازگار از گزینه‌های بارگذاری زیر استفاده کنید.

{{% alert color="info" title="یادداشت" %}}
Aspose Slides به شما امکان می‌دهد این فونت‌ها را با استفاده از [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). برای اطلاعات بیشتر به [TrueType](https://en.wikipedia.org/wiki/TrueType) رجوع کنید.
* فونت‌های OpenType (.otf). برای اطلاعات بیشتر به [OpenType](https://en.wikipedia.org/wiki/OpenType) رجوع کنید.
{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های استفاده‌شده در یک ارائه را بدون نصب آنها در سیستم بارگذاری کنید. این موضوع بر خروجی صادرات—مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده—اثر می‌گذارد تا اسناد نهایی در محیط‌های مختلف یکدست به نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های فونت را مشخص کنید.
2. متد ایستاتیک [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) را فراخوانی کنید تا فونت‌ها از آن پوشه‌ها بارگذاری شوند.
3. ارائه را بارگذاری و رندر/صادر کنید.
4. برای پاک‌سازی کش فونت، [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/clearcache/) را فراخوانی کنید.

نمونه کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Define folders that contain custom font files.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Load custom fonts from the specified folders.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Render/export the presentation (e.g., to PDF, images, or other formats) using the loaded fonts.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Clear the font cache after the work is finished.
FontsLoader::ClearCache();
```

{{% alert color="info" title="یادداشت" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) پوشه‌های اضافی به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب اولیه‌سازی فونت را تغییر نمی‌دهد.
فونت‌ها به ترتیب زیر اولیه‌سازی می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم‌عامل.
1. مسیرهای بارگذاری‌شده از طریق [FontsLoader](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/).
{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**

Aspose.Slides متد [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/getfontfolders/) را فراهم می‌کند تا بتوانید پوشه‌های فونت را پیدا کنید. این متد پوشه‌های اضافه‌شده از طریق متد `LoadExternalFonts` و پوشه‌های فونت سیستم را بر می‌گرداند.

این کد C++ نشان می‌دهد چگونه از متد [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/getfontfolders/) استفاده کنید:

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// این خط پوشه‌هایی را که برای فایل‌های فونت بررسی می‌شوند، خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts افزوده شده‌اند و پوشه‌های فونت سیستم.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **مشخص‌کردن فونت‌های سفارشی استفاده‌شده با یک ارائه**

Aspose.Slides خصوصیت [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) را فراهم می‌کند تا بتوانید فونت‌های خارجی که با ارائه استفاده خواهند شد را مشخص کنید.

این کد C++ نشان می‌دهد چگونه از خصوصیت [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) استفاده کنید:

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
    //CustomFont1، CustomFont2 و همچنین فونت‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
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

// مسیر دایرکتوری اسناد
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

### آیا فونت‌های سفارشی بر صادرات به تمام فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟

بله. فونت‌های متصل‌شده توسط رندرر در تمام فرمت‌های صادراتی استفاده می‌شوند.

### آیا فونت‌های سفارشی به‌طور خودکار در فایل PPTX نهایی جاسازی می‌شوند؟

خیر. ثبت یک فونت برای رندر کردن همانند جاسازی آن در PPTX نیست. اگر نیاز دارید فونت داخل فایل ارائه ذخیره شود، باید از ویژگی‌های [جاسازی](/slides/fa/cpp/embedded-font/) به‌صورت صریح استفاده کنید.

### آیا می‌توانم رفتار fallback را وقتی یک فونت سفارشی گلیف‌های خاصی را ندارد، کنترل کنم؟

بله. با پیکربندی [جایگزینی فونت](/slides/fa/cpp/font-substitution/)، [قوانین جایگزینی](/slides/fa/cpp/font-replacement/) و [مجموعه‌های fallback](/slides/fa/cpp/fallback-font/) می‌توانید دقیقاً تعیین کنید که هنگام عدم وجود گلیف درخواست‌شده از کدام فونت استفاده شود.

### آیا می‌توانم فونت‌ها را در کانتینرهای Linux/Docker بدون نصب سراسری استفاده کنم؟

بله. می‌توانید به پوشه‌های خودتان اشاره کنید یا فونت‌ها را از آرایه‌های بایت بارگذاری کنید. این کار هرگونه وابستگی به دایرکتوری‌های فونت سیستم در تصویر کانتینر را حذف می‌کند.

### درباره مجوزها—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟

شما مسئول رعایت شرایط مجوز فونت هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را منع می‌کنند. پیش از توزیع خروجی‌ها، حتماً شرایط استفاده (EULA) فونت را بررسی کنید.