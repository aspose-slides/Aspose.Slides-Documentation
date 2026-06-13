---
title: تبدیل ارائه‌ها به HTML5 در C++
linktitle: ارائه به HTML5
type: docs
weight: 40
url: /fa/cpp/export-to-html5/
keywords:
- PowerPoint به HTML5
- OpenDocument به HTML5
- ارائه به HTML5
- اسلاید به HTML5
- PPT به HTML5
- PPTX به HTML5
- ODP به HTML5
- ذخیره PPT به صورت HTML5
- ذخیره PPTX به صورت HTML5
- ذخیره ODP به صورت HTML5
- صادرات PPT به HTML5
- صادرات PPTX به HTML5
- صادرات ODP به HTML5
- C++
- Aspose.Slides
description: "صادر کردن ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای C++. حفظ قالب‌بندی، انیمیشن‌ها و تعامل."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به HTML5 تبدیل کنید. این مقاله صادرات پایه HTML5 بدون افزونه‌های وب یا وابستگی‌های اضافی را پوشش می‌دهد، همچنین گزینه‌هایی برای کنترل انیمیشن‌های اشکال و انتقال اسلایدها ارائه می‌کند. مقاله همچنین فرآیند استاندارد صادرات PowerPoint به HTML را نشان می‌دهد، توضیح می‌دهد چگونه خروجی HTML5 را در حالت نمای اسلاید تولید کنید، و نشان می‌دهد چگونه با پیکربندی چیدمان آن‌ها، نظرات را در سند صادر شده گنجانید.

## **صادرات PowerPoint به HTML5**

این کد C++ نشان می‌دهد چگونه یک ارائه را به HTML5 صادر کنید.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 
در این حالت، HTML پاکی دریافت می‌کنید. 
{{% /alert %}}

ممکن است بخواهید تنظیمات انیمیشن‌های اشکال و انتقال اسلایدها را به این شکل تعیین کنید:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **صادرات PowerPoint به HTML**

این کد C++ فرآیند استاندارد تبدیل PowerPoint به HTML را نشان می‌دهد:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

در این حالت، محتوای ارائه از طریق SVG به شکلی مشابه زیر رندر می‌شود:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
هنگامی که از این روش برای صادرات PowerPoint به HTML استفاده می‌کنید، به دلیل رندر SVG، نمی‌توانید سبک‌ها را اعمال کنید یا عناصر خاصی را انیمیشن کنید. 
{{% /alert %}}

## **صادرات PowerPoint به نمای اسلاید HTML5**

**Aspose.Slides** به شما امکان می‌دهد یک ارائه PowerPoint را به سند HTML5 تبدیل کنید که در آن اسلایدها در حالت نمای اسلاید ارائه می‌شوند. در این حالت، هنگامی که فایل HTML5 حاصل را در مرورگر باز می‌کنید، ارائه را در حالت نمای اسلاید بر روی صفحه وب می‌بینید. 

این کد C++ فرآیند صادرات PowerPoint به نمای اسلاید HTML5 را نشان می‌دهد:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **تبدیل یک ارائه به سند HTML5 با نظرات**

نظرات در PowerPoint ابزاری هستند که به کاربران امکان می‌دهند یادداشت‌ها یا بازخوردهای خود را روی اسلایدهای ارائه بگذارند. این ویژگی به‌ویژه در پروژه‌های مشترک مفید است، جایی که چندین نفر می‌توانند پیشنهادات یا نظرات خود را به عناصر خاص اسلاید اضافه کنند بدون اینکه محتوای اصلی را تغییر دهند. هر نظر نام نویسنده را نشان می‌دهد که پیگیری‌کننده‌ی کسی که نظر را گذاشته آسان می‌شود.

فرض کنید ارائه PowerPoint زیر را در فایل «sample.pptx» ذخیره کرده‌ایم.

![دو نظر روی اسلاید ارائه](two_comments_pptx.png)

هنگامی که یک ارائه PowerPoint را به سند HTML5 تبدیل می‌کنید، می‌توانید به‌راحتی تعیین کنید که آیا نظرات موجود در ارائه در سند خروجی گنجانده شوند یا نه. برای این کار، باید پارامترهای نمایش نظرات را در متد `get_NotesCommentsLayouting` کلاس [Html5Options](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/) مشخص کنید.

مثال کد زیر یک ارائه را به سند HTML5 تبدیل می‌کند که نظرات به سمت راست اسلایدها نمایش داده می‌شوند.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

سند «output.html» در تصویر زیر نشان داده شده است.

![نظرات در سند HTML5 خروجی](two_comments_html5.png)

## **سوالات متداول**

**آیا می‌توانم کنترل کنم که آیا انیمیشن‌های اشیاء و انتقال اسلایدها در HTML5 اجرا شوند؟**

بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [shape animations](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/set_animateshapes/) و [slide transitions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/set_animatetransitions/) فراهم می‌کند.

**آیا خروجی نظرات پشتیبانی می‌شود و می‌توان آن‌ها را نسبت به اسلاید کجا قرار داد؟**

بله، نظرات می‌توانند در HTML5 افزوده شوند و از طریق تنظیمات چیدمان برای یادداشت‌ها و نظرات، در موقعیتی (به عنوان مثال، به سمت راست اسلاید) قرار گیرند.

**آیا می‌توانم لینک‌هایی که JavaScript را فراخوانی می‌کنند به دلایل امنیتی یا CSP نادیده بگیرم؟**

بله، یک [setting](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) وجود دارد که به شما امکان می‌دهد هنگام ذخیره‌سازی، پیوندهای حاوی فراخوانی‌های JavaScript را نادیده بگیرید. این کار به رعایت سیاست‌های امنیتی سخت کمک می‌کند.