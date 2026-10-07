---
title: Aspose.Slides برای C++
second_title: Aspose.Slides برای C++
type: docs
weight: 30
url: /fa/cpp/
keywords:
- مستندات
- پردازش ارائه
- تبدیل ارائه
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "از اینجا شروع کنید: Aspose.Slides for C++ را نصب کنید، اولین ارائه را ایجاد کنید، و راهنماهای مرتبط با وظایف رایج، مرجع API و پشتیبانی را بیابید."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ یک کتابخانهٔ بومی C++ برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument است، بدون نیاز به Microsoft PowerPoint یا Office Automation.

این کتابخانه می‌تواند فایل‌های PPT، PPTX، PPS، POT و ODP را بارگذاری و ذخیره کند، شامل نسخه‌های دارای ماکرو و قالب، و خروجی به PDF، XPS، HTML، SVG، TIFF، Markdown و تصاویر را فراهم می‌سازد.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع کنید</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/fa/cpp/installation/">نصب</a></li>
<li><a href="/slides/fa/cpp/create-presentation/">ایجاد اولین ارائهٔ خود</a></li>
<li><a href="/slides/fa/cpp/getting-started/">راهنمای شروع کار</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/fa/cpp/supported-file-formats/">قالب‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/cpp/evaluate-aspose-slides/">محدودیت‌های نسخه آزمایشی</a></li>
<li><a href="/slides/fa/cpp/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/fa/cpp/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/cpp/save-presentation/">ذخیرهٔ یک ارائه</a></li>
<li><a href="/slides/fa/cpp/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/cpp/convert-slide/">رندر اسلایدها به عنوان تصاویر</a></li>
<li><a href="/slides/fa/cpp/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/fa/cpp/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/cpp/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/cpp/manage-media-files/">صدا و ویدئو</a></li>
<li><a href="/slides/fa/cpp/presentation-design/">طراحی اسلاید</a></li>
<li><a href="/slides/fa/cpp/merge-presentation/">ادغام ارائه‌ها</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/fa/cpp/examples/">نمونه‌ها بر اساس عنصر اسلاید</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">نمونه‌ها در GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>مرجع و پشتیبانی</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">یادداشت‌های نسخه</a></li>
<li><a href="/slides/fa/cpp/known-issues/">مشکلات شناخته‌شده</a></li>
<li><a href="https://products.aspose.com/slides/cpp/">صفحهٔ محصول</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">دانلود</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">پشتیبانی پرداختی (helpdesk)</a></li>
</ul>
</div>
</div>

------

## **اولین ارائهٔ شما**

در ویندوز، یک پروژهٔ C++ **Console App** در Visual Studio ایجاد کنید و بستهٔ NuGet را از طریق Package Manager Console (**Tools** > **NuGet Package Manager** > **Package Manager Console**) نصب کنید:

```powershell
Install-Package Aspose.Slides.Cpp
```

در لینوکس، بستهٔ ZIP لینوکس را دانلود کنید و پروژهٔ CMake را همان‌طور که در [Installation](/slides/fa/cpp/installation/#linux) توضیح داده شده است، تنظیم کنید.

سپس از این کد به عنوان فایل اصلی منبع برنامه‌تان استفاده کنید. این کد یک ارائه با یک جعبهٔ متن ایجاد کرده و ذخیره می‌کند:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

برای اجرای آن در ویندوز، پلتفرم **x64** را در نوار ابزار انتخاب کنید و **Ctrl+F5** را فشار دهید. در لینوکس، آن را به نام *main.cpp* در پوشهٔ پروژه ذخیره کنید، سپس بسازید و اجرا کنید:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

برنامه *hello.pptx* را با یک اسلاید حاوی جعبهٔ متن ذخیره می‌کند. بدون داشتن لایسنس، فایل ذخیره‌شده حاوی واترمارک ارزیابی خواهد بود — برای جزئیات به [Licensing](/slides/fa/cpp/licensing/) مراجعه کنید. برای روش‌های بیشتر ایجاد و پر کردن یک ارائه، به [Create Presentations](/slides/fa/cpp/create-presentation/) نگاه کنید.