---
title: مدیریت دسترسی‌پذیری ارائه در C++
linktitle: دسترس‌پذیری ارائه
type: docs
weight: 30
url: /fa/cpp/presentation-accessibility/
keywords:
- دسترس‌پذیری ارائه
- متن جایگزین
- عنوان متن جایگزین
- توضیح متن جایگزین
- علامت‌گذاری به عنوان تزئینی
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "بررسی‌های دسترسی‌پذیری ارائه در فایل‌های PPT، PPTX و ODP را با Aspose.Slides برای C++ خودکار کنید—تجربه خوانندگان صفحه نمایش را بهبود ببخشید و انطباق را افزایش دهید."
---
## **معرفی**

متن جایگزین به افراد استفاده‌کننده از فناوری‌های کمکی کمک می‌کند تا معنای تصاویر، نمودارها و سایر اشکال اطلاعاتی را درک کنند. این مقاله توضیح می‌دهد چگونه عناوین و توضیحات متن جایگزین را با Aspose.Slides برای C++ بخوانید و به‌روزرسانی کنید، توصیفات دسترسی‌پذیری را از نام‌های اشکال استفاده شده در کد متمایز کنید و بررسی کنید آیا یک شکل به‌عنوان تزئینی علامت‌گذاری شده است یا خیر.

این ویژگی‌ها از دسترسی‌پذیری ارائه پشتیبانی می‌کنند، اما تضمین‌کننده آن نیستند. ترتیب خواندن، contrast رنگ، قابلیت خواندن متن و سایر الزامات دسترسی‌پذیری نیز باید بازبینی شوند.

## **مدیریت عناوین و توضیحات متن جایگزین**

از متن جایگزین برای توضیح معنای تصاویر، نمودارها و سایر اشکال اطلاعاتی به افرادی که نمی‌توانند آن‌ها را ببینند استفاده کنید. ویژگی‌های زیر مقاصد متفاوتی دارند:

| Property or content | Purpose |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_alternativetexttitle/) | عنوان کوتاهی برای توصیف جایگزین. |
| [AlternativeText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_alternativetext/) | توصیف معناداری از محتوای شکل یا هدف آن در زمینه اسلاید. |
| [Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_name/) | نام شکل که کد می‌تواند از آن برای یافتن شکل خاصی در ارائه استفاده کند. |
| متن قابل مشاهده | محتوایی که روی اسلاید نمایش داده می‌شود، مانند متن یک شکل یا عنوان و برچسب‌های یک نمودار. به‌روزرسانی متن جایگزین این محتوا را تغییر نمی‌دهد. |

زمانی که یک ارائه به‌عنوان قالب مجدداً استفاده می‌شود، کد ممکن است قبل از به‌روزرسانی، شکل را با استفاده از [Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_name/) پیدا کند. این نام هدف متفاوتی نسبت به متن جایگزین دارد که توضیح می‌دهد تصویری چه اطلاعاتی را به خواننده می‌رساند. جستجو بر پایه نام به نویسندگان امکان می‌دهد توصیفات را بهبود یا ترجمه کنند بدون این که نحوه یافتن شکل توسط کد تغییر کند. نام‌ها می‌توانند ویرایش شوند و تضمین نمی‌شود یکتا باشند، بنابراین اطمینان حاصل کنید که نام با شکل موردنظر مطابقت دارد؛ برای جزئیات بیشتر به [Identify and Find Shapes](/slides/fa/cpp/shape-manipulations/#identify-and-find-shapes) مراجعه کنید.

مثال زیر نیاز به فایلی به نام `input.pptx` دارد که تصویر یک ورودی دفتر به عنوان اولین شکل در اولین اسلاید داشته باشد. تصویر نباید به‌عنوان تزئینی علامت‌گذاری شود. این مثال عنوان و توضیح متن جایگزین فعلی را می‌خواند و چاپ می‌کند، هر دو مقدار را به‌روزرسانی می‌کند و ارائه را به‌عنوان `output.pptx` ذخیره می‌کند. واژگان را بر اساس تصویر واقعی و اطلاعاتی که منتقل می‌کند، تنظیم کنید.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

افزودن تنها متن جایگزین، دسترسی‌پذیری ارائه یا انطباق با استانداردهای دسترسی‌پذیری را تضمین نمی‌کند. توصیفات را برای دقت و مرتبط بودن بررسی کنید و همچنین ترتیب خواندن، contrast رنگ، متن قابل خواندن و سایر الزامات دسترسی‌پذیری را چک کنید. تصاویر اطلاعاتی نباید به‌عنوان تزئینی علامت‌گذاری شوند؛ بخش بعدی نشان می‌دهد چگونه [IsDecorative](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_isdecorative/) را بخوانید.

## **علامت‌گذاری به عنوان تزئینی**

علامت‌گذاری به‌عنوان تزئینی برای اشکال صرفاً تزئینی استفاده می‌شود تا نرم‌افزارهای خواندن صفحه‌نمایش از آن‌ها عبور کنند، در نتیجه نویز کاهش می‌یابد و تمرکز بر محتوای معنادار حفظ می‌شود. این ویژگی را برای پس‌زمینه‌ها، تزئینات و فضاهای خالی اعمال کنید—هرگز برای نمودارها، آیکون‌ها یا تصاویری که اطلاعات منتقل می‌کنند. Aspose.Slides این پرچم را برای تشخیص و اعتبارسنجی در دسترس می‌گذارد و امکان بررسی خودکار دسترسی‌پذیری و پاکسازی را فراهم می‌کند.

![علامت‌گذاری به عنوان تزئینی](mark_as_decorative.png)

نمونه کد زیر نشان می‌دهد چگونه تعیین کنید آیا یک شکل به‌عنوان تزئینی علامت‌گذاری شده است یا خیر.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **پرسش‌های متداول**

**چه چیزی باید در عنوان و توصیف متن جایگزین قرار دهم؟**

یک عنوان کوتاه برای شناسایی موضوع و یک توصیف برای توضیح اطلاعاتی که تصویر در زمینه اسلاید منتقل می‌کند استفاده کنید. برای یک نمودار، روند یا مقایسه مرتبط را توصیف کنید نه فقط «نمودار».

**آیا باید برای یافتن اشکال در یک قالب از متن جایگزین استفاده کنم؟**

ترجیحاً شکل را با استفاده از [Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_name/) پیدا کنید و اطمینان حاصل کنید که همان شکل موردنظر است. متن جایگزین ممکن است ویرایش یا ترجمه شود که می‌تواند کدی را که به دنبال توصیف دقیق است خراب کند؛ برای جزئیات بیشتر به [Identify and Find Shapes](/slides/fa/cpp/shape-manipulations/) مراجعه کنید.

**چه زمانی باید یک شکل به‌عنوان تزئینی علامت‌گذاری شود؟**

پرچم تزئینی را برای تصویری که هیچ اطلاعاتی اضافه نمی‌کند، مانند تزئینات صرفاً تزئینی، استفاده کنید. تصاویر و نمودارهایی که معنا منتقل می‌کنند نیاز به توصیف مناسب دارند.

**آیا افزودن متن جایگزین باعث می‌شود ارائه کاملاً دسترس‌پذیر شود؟**

خیر. متن جایگزین فقط بخشی از دسترسی‌پذیری را پوشش می‌دهد. همچنین باید ترتیب خواندن، contrast رنگ، قابلیت خواندن متن و سایر الزامات مرتبط را بررسی کنید؛ تنظیم تنها این ویژگی‌ها خود به تنهایی باعث انطباق نمی‌شود.