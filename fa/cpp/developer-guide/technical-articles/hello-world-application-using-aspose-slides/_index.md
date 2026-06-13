---
title: برنامهٔ Hello World با Aspose.Slides برای C++
type: docs
weight: 80
url: /fa/cpp/hello-world-application-using-aspose-slides/
keywords:
- سلام دنیا
- برنامه
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "اولین برنامهٔ C++ خود را با Aspose.Slides ایجاد کنید؛ یک مثال سادهٔ Hello World که شما را برای خودکارسازی ارائه‌های PPT، PPTX و ODP آماده می‌کند."
---
## **Overview**

این مقاله نشان می‌دهد که چگونه یک ارائهٔ سادهٔ **Hello World** در PowerPoint با استفاده از Aspose.Slides ایجاد کنید. این مثال نحوهٔ ساخت یک ارائهٔ جدید، دسترسی به اسلاید اول، اضافه کردن یک AutoShape به شکل مستطیل در موقعیت مشخص، وارد کردن یک قاب متن حاوی متن **Hello World** و تنظیم قالب‌بندی شکل و متن را نشان می‌دهد.

همچنین توضیح می‌دهد که چگونه متن را با تغییر رنگ آن به سیاه قابل مشاهده کنید، حاشیهٔ شکل را با تنظیم رنگ خط به سفید پنهان کنید، پر کردن شکل را حذف کنید و ارائه را به‌عنوان فایل PPTX ذخیره کنید.

## **Steps to Create a Hello World Application**

- یک نمونه از کلاس Presentation ایجاد کنید
- مرجع اسلاید اول را که هنگام ساختن شی Presentation ایجاد می‌شود، به دست آورید
- یک AutoShape با ShapeType به عنوان Rectangle را در موقعیت مشخصی از اسلاید اضافه کنید
- یک TextFrame به AutoShape اضافه کنید که متن پیش‌فرض Hello World را شامل می‌شود
- رنگ متن را به سیاه تغییر دهید، زیرا به‌صورت پیش‌فرض سفید است و روی پس‌زمینهٔ سفید اسلاید قابل مشاهده نیست
- رنگ خط شکل را به سفید تغییر دهید تا حاشیهٔ شکل مخفی شود
- قالب پر کردن پیش‌فرض شکل را حذف کنید
- در نهایت، ارائه را با استفاده از شی Presentation به قالب فایل موردنظر ذخیره کنید

پیاده‌سازی مراحل فوق در یک مثال در زیر نشان داده شده است.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // دریافت اولین اسلاید
    auto slide = pres->get_Slides()->idx_get(0);

    // اضافه کردن یک AutoShape از نوع Rectangle
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // اضافه کردن TextFrame به Rectangle
    shape->AddTextFrame(u"Hello World");

    // تغییر رنگ متن به سیاه (که به طور پیش‌فرض سفید است)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // تغییر رنگ خط مستطیل به سفید
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // حذف هر قالب پر کردن در شکل
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // ذخیره ارائه در دیسک
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```