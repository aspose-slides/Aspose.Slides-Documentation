---
title: تبدیل PPT به PPTX در C++
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/cpp/convert-ppt-to-pptx/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به صورت PPTX
- صادرات PPT به PPTX
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "فایل‌های PPT قدیمی را به PPTX در C++ با Aspose.Slides تبدیل کنید. شامل مثال‌های C++ برای تبدیل تک‌فایلی و دسته‌ای، مدیریت خطا و نکات دقت می‌باشد."
---
## **نمای کلی**

PPT یک فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت جدید Open XML است. Aspose.Slides برای C++ می‌تواند یک فایل PPT را بارگذاری کرده و بدون نیاز به Microsoft PowerPoint به PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و پس از تبدیل چه مواردی را باید بررسی کنید.

## **تبدیل یک فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگذاری کنید، سپس با [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) و با استفاده از آرگومان [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) فراخوانی کنید. هنگامی که دیگر نیازی به ارائه نیست، آن را آزاد کنید تا منابع آن آزاد شود.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// بارگذاری ارائه PPT قدیمی.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// ذخیره ارائه در قالب PPTX.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

پسوند فایل به تنهایی فرمت خروجی را تعیین نمی‌کند؛ آرگومان [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) این کار را انجام می‌دهد. اگر نیاز به نگه داشتن فایل PPT اصلی دارید، مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر تمام فایل‌های `.ppt` موجود در یک پوشه را تبدیل می‌کند. هر فایل به‌طور مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق باعث توقف بقیهٔ دسته نمی‌شود.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

برای بارهای کاری تولیدی، استثنا کامل را لاگ کنید، تصمیم بگیرید آیا فایل خروجی موجود می‌تواند بازنویسی شود و نام فایل‌های ناموفق را به صف تلاش مجدد یا بررسی بنویسید. فایل‌های خراب، فایل‌های محافظت‌شده با رمز عبور که بدون رمز صحیح باز می‌شوند، مسیرهای غیرقابل دسترس و محتوای پشتیبانی‌نشده می‌توانند باعث شکست تبدیل شوند. برای بارگذاری فایل‌های رمزگذاری‌شده، به [Password-Protected Presentations](/slides/fa/cpp/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های قدیمی**

تبدیل معمولاً اسلایدها، مسترها، طرح‌ها، متن، اشکال، تصاویر، جدول‌ها و نمودارها را حفظ می‌کند. اما PPT و PPTX هر ویژگی را به‌طور دقیق یک‌سان نشان نمی‌دهند. ویژگی‌های ارثی که معادل PPTX ندارند یا توسط کتابخانه پشتیبانی نمی‌شوند ممکن است نرمال‌سازی، حذف یا به‌صورت متفاوت نمایش داده شوند.

فایل تبدیل‌شده را زمانی که شامل انیمیشن‌ها، انتقال‌ها، اشیای OLE جاسازی‌شده یا لینک‌شده، کنترل‌های ActiveX، رسانهٔ جاسازی‌شده، فونت‌های نامعمول یا ماکروهای VBA باشد بررسی کنید. یک فایل PPTX ساده فرمت پشتیبانی‌کنندهٔ ماکرو نیست، بنابراین زمانی که VBA باید در دسترس باشد، از فرآیند مناسب با ماکرو استفاده کنید. همچنین اطمینان حاصل کنید که فونت‌های مورد نیاز و منابع خارجی در محیطی که ارائهٔ تبدیل‌شده باز یا رندر می‌شود، موجود باشند.

برای اسناد مهم، PPTX تولیدشده را به‌صورت برنامه‌ای دوباره باز کنید و تعداد اسلایدها و محتوای کلیدی را بررسی کنید، سپس ظاهر و رفتار نمایش اسلایدها را در نمایشگر موردنظر مقایسه کنید. موفقیت فراخوانی [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) را به‌عنوان اثبات این‌که هر ویژگی قدیمی نمایان‌سازی دقیق در PPTX دارد در نظر نگیرید.

## **کِی باید از PPTX استفاده کرد**

در زمان‌هایی که ارائه در نسخه‌های فعلی PowerPoint ویرایش خواهد شد، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند تبادل می‌شود یا به‌صورت فرمت آسان‌تری برای بازرسی و بازیابی نسبت به PPT باینری قدیمی ذخیره می‌شود، از PPTX استفاده کنید. تا زمانی که ارائهٔ تبدیل‌شده آزمون‌های دقت شما را پاس کند، نسخهٔ اصلی PPT را به عنوان بایگانی یا کپی بازگشتی نگه دارید.

اگر به‌جای آن به PDF، HTML، تصاویر، XPS یا نوع خروجی دیگری نیاز دارید، به‌جای فرض اینکه همهٔ هدف‌ها ویژگی‌های ویرایشی PowerPoint را حفظ می‌کنند، راهنمایی مربوط به قالب را در [Convert Presentations to Multiple Formats](/slides/fa/cpp/convert-presentation/) استفاده کنید.

## **مبدل آنلاین**

برای یک فایل گاه به گاه یا مقایسهٔ سریع می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های قابل تکرار، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه، از API زبان C++ استفاده کنید.

## **مقالات مرتبط**

- [ذخیرهٔ ارائه‌ها در C++](/slides/fa/cpp/save-presentation/)
- [قالب‌های فایل پشتیبانی‌شده](/slides/fa/cpp/supported-file-formats/)
- [باز کردن ارائه‌ها در C++](/slides/fa/cpp/open-presentation/)

## **سوالات متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون نصب Microsoft PowerPoint؟**

بله. Aspose.Slides برای C++ فایل‌های ارائه را بارگذاری و ذخیره می‌کند بدون اینکه به Microsoft PowerPoint نیاز داشته باشد.

**آیا تبدیل PPT به PPTX تمام محتوا را به‌دقت حفظ می‌کند؟**

این تبدیل محتوای رایج ارائه را حفظ می‌کند، اما دقت کامل برای هر ویژگی قدیمی یا پشتیبانی‌نشده تضمین نمی‌شود. هنگامی که فایل شامل ماکروها، اشیای OLE یا ActiveX، رسانه‌ها، انیمیشن‌های خاص یا فونت‌های نامعمول باشد، فایل تولیدی را بررسی کنید.

**آیا می‌توانم یک فایل PPT محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله، اگر در زمان بارگذاری فایل رمز عبور صحیح را ارائه کنید. عدم وجود یا اشتباه بودن رمز عبور باعث شکست عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

نسخهٔ اصلی را تا زمانی که PPTX را در نمایشگرها و فرآیندهای مهم برای شما تأیید کرده‌اید، نگه دارید. این کار یک نسخهٔ بازگشتی فراهم می‌کند در صورتی که یک ویژگی قدیمی به‌صورت متفاوتی تبدیل شود.