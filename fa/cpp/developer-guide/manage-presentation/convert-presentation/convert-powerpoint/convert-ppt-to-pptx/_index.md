---
title: تبدیل PPT به PPTX در C++
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/cpp/convert-ppt-to-pptx/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به عنوان PPTX
- صدور PPT به PPTX
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "تبدیل فایل‌های PPT قدیمی به PPTX در C++ با Aspose.Slides. شامل مثال‌های C++ برای تبدیل تک‌فایلی و دسته‌ای، مدیریت خطا و نکات دقت."
---
## **نمایش کلی**

PPT یک فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت جدید Open XML است. Aspose.Slides برای C++ می‌تواند یک فایل PPT را بارگذاری کند و بدون نیاز به Microsoft PowerPoint آن را به PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و توضیح می‌دهد پس از تبدیل چه مواردی را باید بررسی کنید.

## **تبدیل یک فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگذاری کنید، سپس با [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) و با استفاده از [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) ذخیره کنید. وقتی دیگر به ارائه نیاز ندارید آن را از بین ببرید تا منابع آن آزاد شود.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

پسوند فایل به تنهایی فرمت خروجی را تعیین نمی‌کند؛ آرگومان [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) این کار را انجام می‌دهد. اگر نیاز به حفظ فایل PPT اصلی دارید مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر هر فایل `.ppt` در یک پوشه را تبدیل می‌کند. هر فایل به‌ طور مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق باعث توقف بقیه دسته نمی‌شود.

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

برای بارهای کاری تولیدی، استثنای کامل را لاگ کنید، تصمیم بگیرید آیا فایل خروجی موجود می‌تواند بازنویسی شود یا خیر، و نام فایل‌های ناموفق را به صف retry یا review بنویسید. فایل‌های خراب، فایل‌های محافظت‌شده با رمز عبور که بدون رمز لازم باز می‌شوند، مسیرهای غیرقابل دسترسی، و محتواهای پشتیبانی‌نشده می‌توانند باعث شکست تبدیل شوند. برای بارگذاری فایل‌های رمزگذاری‌شده به [Password-Protected Presentations](/cpp/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های قدیمی**

تبدیل به طور معمول اسلایدها، استادها، طرح‌ها، متن، شکل‌ها، تصاویر، جداول و نمودارها را حفظ می‌کند. اما PPT و PPTX هر ویژگی را دقیقاً به همان شکل نشان نمی‌دهند. یک ویژگی قدیمی که معادل PPTX ندارد یا توسط کتابخانه پشتیبانی نمی‌شود، ممکن است نرمال‌سازی، حذف یا به‌ شکل متفاوتی نمایش داده شود.

زمانی که فایل تبدیل‌شده شامل انیمیشن‌ها، انتقال‌ها، اشیای OLE توکار یا لینک‌دار، کنترل‌های ActiveX، رسانه‌های توکار، فونت‌های غیرمعمول یا ماکروهای VBA باشد، آن را بررسی کنید. یک فایل PPTX ساده فرمت ماکروپذیر نیست، بنابراین وقتی VBA باید در دسترس باشد از یک گردش‌کار مناسب ماکروپذیر استفاده کنید. همچنین اطمینان حاصل کنید فونت‌های مورد نیاز و منابع خارجی در محیطی که ارائه تبدیل‌شده باز یا رندر خواهد شد، موجود باشند.

برای اسناد مهم، PPTX تولیدشده را برنامه‌نویسی باز کنید و تعداد اسلایدها و محتوای کلیدی را بررسی کنید، سپس ظاهر و رفتار اسلایدشو آن را در نمایشگر مورد نظر مقایسه کنید. یک فراخوانی موفق [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) را به‌ عنوان اثبات اینکه هر ویژگی قدیمی به‌ طور دقیق در PPTX نمایان شده است، در نظر نگیرید.

## **کی باید از PPTX استفاده کرد**

از PPTX استفاده کنید وقتی ارائه در نسخه‌های فعلی PowerPoint ویرایش خواهد شد، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند تبادل می‌شود، یا در قالبی ذخیره می‌شود که نسبت به PPT باینری قدیمی راحت‌تر قابل بازبینی و بازیابی است. تا زمانی که ارائه تبدیل‌شده آزمون‌های دقت شما را پشت‌سر بگذارد، فایل PPT اصلی را به‌ عنوان نسخهٔ آرشیوی یا بازگشتی نگه دارید.

اگر به‌ جای آن به PDF، HTML، تصاویر، XPS یا نوع خروجی دیگری نیاز دارید، راهنمایی‌های خاص قالب را در [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) استفاده کنید به‌ جای این‌ که فرض کنید تمام هدف‌ها ویژگی‌های ویرایش‌پذیر PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل گاهی یا مقایسه سریع می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های تکراری، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه از API C++ استفاده کنید.

## **مقالات مرتبط**

- [ذخیره ارائه‌ها در C++](/cpp/save-presentation/)
- [قالب‌های فایل پشتیبانی‌شده](/cpp/supported-file-formats/)
- [باز کردن ارائه‌ها در C++](/cpp/open-presentation/)

## **پرسش‌های متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون اینکه Microsoft PowerPoint نصب باشد؟**

بله. Aspose.Slides برای C++ فایل‌های ارائه را بدون نیاز به Microsoft PowerPoint بارگذاری و ذخیره می‌کند.

**آیا تبدیل PPT به PPTX تمام محتوا را به‌ طور دقیق حفظ می‌کند؟**

این تبدیل محتواهای رایج ارائه را حفظ می‌کند، اما دقت کامل برای هر ویژگی قدیمی یا پشتیبانی‌نشده تضمین نمی‌شود. هنگامیکه فایل تولیدشده شامل ماکروها، اشیای OLE یا ActiveX، رسانه‌ها، انیمیشن‌های تخصصی یا فونت‌های غیرمعمول باشد، آن را بررسی کنید.

**آیا می‌توانم یک فایل PPT محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله، اگر هنگام بارگذاری فایل رمز صحیح را ارائه دهید. نبود یا نادرست بودن رمز عبور باعث شکست عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

تا زمانی که PPTX را در نمایشگرها و گردش‌کارهای مهم برای شما تأیید کرده‌اید، اصل را نگه دارید. این یک نسخهٔ بازگشتی در صورت تبدیل متفاوت یک ویژگی قدیمی فراهم می‌کند.