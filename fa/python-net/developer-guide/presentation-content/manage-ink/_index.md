---
title: مدیریت اشیاء جوهر ارائه در پایتون
linktitle: مدیریت جوهر
type: docs
weight: 95
url: /fa/python-net/manage-ink/
keywords:
- جوهر
- شیء جوهر
- ردیابی جوهر
- مدیریت جوهر
- رسم جوهر
- رسم
- خروجی جوهر
- رندرینگ جوهر
- پنهان کردن جوهر
- InkOptions
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "مدیریت اشیاء جوهر PowerPoint، ویرایش ردیابی‌ها و ویژگی‌های قلم‌مو، و کنترل ظاهر جوهر هنگام خروجی PDF، HTML، SVG، TIFF و تصویر با Aspose.Slides برای Python از طریق .NET."
---
## **مقدمه**

PowerPoint ویژگی جوهر را فراهم می‌کند که به شما امکان می‌دهد خطوط آزاد رسم کنید. جوهر می‌تواند برای برجسته‌سازی اشیاء دیگر، نشان دادن ارتباطات و فرآیندها و جلب توجه به موارد خاص در یک اسلاید استفاده شود.

[aspose.slides.ink](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ink/) فضای‌نام حاوی کلاس‌های مورد نیاز برای کار با اشیاء جوهر است. برای مثال، کلاس [Ink](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ink/ink/) نمایانگر یک شیء جوهر در یک اسلاید است.

## **تفاوت بین اشیاء معمولی و اشیاء جوهر**

اشیاء روی یک اسلاید PowerPoint معمولاً توسط اشیاء shape (شکل) نشان داده می‌شوند. در ساده‌ترین شکل، یک shape یک محفظه است که ناحیهٔ خود شیء (قاب آن) را همراه با ویژگی‌هایی مانند اندازهٔ محفظه، شکل و پس‌زمینه تعریف می‌کند. برای اطلاعات بیشتر، به [Shape Layout Format](https://docs.aspose.com/slides/fa/python-net/shape-manipulations/#access-layout-formats-for-shape) مراجعه کنید.

اما وقتی PowerPoint یک شیء جوهر را مدیریت می‌کند، تمام ویژگی‌های قاب شیء (محفظه) به‌جز اندازهٔ آن را نادیده می‌گیرد. اندازهٔ ناحیهٔ محفظه توسط ویژگی‌های استاندارد [Ink.width](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ink/ink/width/) و [Ink.height](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ink/ink/height/) تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردیابی‌های جوهر**

یک ردیابی جوهر یک عنصر پایه‌ای است که مسیر قلم را هنگام نوشتن جوهر دیجیتال ثبت می‌کند. یک ردیابی توالی‌ای از نقاط متصل را ذخیره می‌کند.

ساده‌ترین شکل کدگذاری، مختصات X و Y هر نقطهٔ نمونه را مشخص می‌کند. وقتی تمام نقاط متصل رندر شوند، تصویری مانند زیر تولید می‌شود:

![ink_powerpoint2](ink_powerpoint2.png)

## **ویژگی‌های قلم‌مو برای رسم**

قلم‌مو برای رسم خطوطی که نقاط یک ردیابی جوهر را به هم وصل می‌کند، استفاده می‌شود. ویژگی‌های [InkBrush.color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ink/inkbrush/color/) و [InkBrush.size](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ink/inkbrush/size/) رنگ و اندازهٔ آن را کنترل می‌کنند.

### **تنظیم رنگ قلم‌موی جوهر**

این کد Python نشان می‌دهد چگونه رنگ یک قلم‌موی جوهر تنظیم شود:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **تنظیم اندازه قلم‌موی جوهر**

این کد Python نشان می‌دهد چگونه اندازهٔ یک قلم‌موی جوهر تنظیم شود:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

به طور کلی، عرض و ارتفاع یک قلم‌مو یکسان نیستند، بنابراین PowerPoint اندازهٔ قلم‌مو را نمایش نمی‌دهد (بخش دادهٔ مربوطه خاکستری می‌شود). وقتی عرض و ارتفاع قلم‌مو یکسان باشند، PowerPoint اندازهٔ آن را به این شکل نمایش می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح بیشتر، ارتفاع شیء جوهر را افزایش می‌دهیم و ابعاد مهم را مرور می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

محفظه (قاب) اندازهٔ قلم‌موها را در نظر نمی‌گیرد—همیشه فرض می‌کند ضخامت خط صفر است (به تصویر قبلی مراجعه کنید).

بنابراین برای تعیین ناحیهٔ قابل مشاهدهٔ کل شیء جوهر، باید اندازهٔ قلم‌موهای ردیابی‌های آن مد نظر قرار گیرد. در اینجا، شیء هدف (ردیابی متن دست‌نویس) به اندازهٔ محفظه (قاب) مقیاس‌بندی شده است. وقتی اندازهٔ محفظه تغییر می‌کند، اندازهٔ قلم‌مو ثابت می‌ماند و بالعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint رفتار مشابهی برای اشیاء متنی به‌کار می‌برد:

![ink_powerpoint6](ink_powerpoint6.png)

## **کنترل ظاهر جوهر هنگام خروجی‌گیری و رندرینگ**

Aspose.Slides کلاس [InkOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/inkoptions/) را برای کنترل نحوهٔ نمایش اشیاء جوهر در خروجی یا رندر فراهم می‌کند. می‌توانید از ویژگی‌های آن برای پنهان کردن کامل جوهر یا تغییر نحوهٔ تفسیر عملیات ماسک قلم‌مو استفاده کنید.

گزینه‌های جوهر از طریق گزینه‌های خروجی یا رندر برای انواع خروجی زیر در دسترس هستند:

| خروجی | ویژگی گزینه‌های جوهر |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| تصویر اسلاید | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/ink_options/) |

دو تنظیم زیر از طریق این ویژگی‌ها در دسترس هستند:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/inkoptions/hide_ink/) مشخص می‌کند که آیا اشیاء جوهر در خروجی گنجانده شوند یا نه. مقدار پیش‌فرض آن `False` است.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) تعیین می‌کند که آیا عملیات ماسک به‌عنوان شفافیت تفسیر شود هنگام رندر قلم‌مو جوهر. مقدار پیش‌فرض آن `True` است؛ برای استفاده از عملیات ROP آن را به `False` تنظیم کنید.

### **پنهان کردن اشیاء جوهر در خروجی PDF**

به‌صورت پیش‌فرض، اشیاء جوهر هنگام خروجی‌گیری قابل مشاهده‌اند. زمانی که نیاز به خروجی پاک بدون حاشیه‌نویسی‌های دست‌نویس یا محتوای جوهر دارید، [InkOptions.hide_ink](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/inkoptions/hide_ink/) را به `True` تنظیم کنید.

مثال Python زیر یک ارائه را به PDF صادر می‌کند در حالی که تمام اشیاء جوهر را پنهان می‌سازد:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **پنهان کردن اشیاء جوهر هنگام رندر اسلاید به صورت تصویر**

برای پنهان کردن اشیاء جوهر هنگام رندر اسلایدها به صورت تصاویر بیت‌مپ، [RenderingOptions.ink_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/ink_options/) را پیکربندی کنید و گزینه‌های رندر را به متد [Slide.get_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/) پاس دهید.

مثال Python زیر اولین اسلاید را به تصویر PNG بدون اشیاء جوهر رندر می‌کند:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **کنترل رندر ماسک جوهر**

ویژگی [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) نحوهٔ تفسیر عملیات ماسک را هنگام رندر قلم‌موهای جوهر کنترل می‌کند. مقدار پیش‌فرض `True` است که از شفافیت استفاده می‌کند. برای استفاده از عملیات ROP آن را به `False` تنظیم کنید.

مثال Python زیر یک اسلاید را به SVG صادر می‌کند و رندر مبتنی بر ROP برای عملیات ماسک جوهر را به‌کار می‌گیرد:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

همین تنظیم می‌تواند از طریق [TiffOptions.ink_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/ink_options/) هنگام خروجی‌گیری یک ارائه یا رندر اسلاید به TIFF اعمال شود.

### **انتخاب اینکه جوهر را پنهان یا نگه‌دارید**

زمانی که فایل خروجی باید نسخهٔ پاکی از یک ارائه حاشیه‌دار باشد (مانند یک نسخهٔ نهایی برای توزیع بدون علامت‌های مرور)، [InkOptions.hide_ink](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/inkoptions/hide_ink/) را به `True` تنظیم کنید.

وقتی حاشیه‌نویسی‌های جوهر بخشی از محتوای موردنظر هستند (نظرات مرور، یادداشت‌های دست‌نویس، هایلایت‌ها یا نقاشی‌ها که باید در نتایج خروجی دیده شوند)، مقدار پیش‌فرض `False` را برای [InkOptions.hide_ink](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/inkoptions/hide_ink/) رها کنید. این امکان را می‌دهد که برنامه‌ها خروجی‌های مرور و نهایی جداگانه‌ای را از یک ارائهٔ یکسان بدون تغییر اشیاء جوهر منبع تولید کنند.

## **سؤالات متداول**

**آیا می‌توانم رنگ یا اندازهٔ یک خط جوهر موجود را تغییر دهم؟**  
بله. ردیابی را از [Ink.traces](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ink/ink/traces/) دریافت کنید، سپس [InkTrace.brush](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ink/inktrace/brush/) آن را تغییر دهید. می‌توانید رنگ [InkBrush.color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ink/inkbrush/color/) و اندازهٔ [InkBrush.size](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ink/inkbrush/size/) را تنظیم کنید.

**آیا پنهان کردن جوهر منبع ارائه را تغییر می‌دهد؟**  
خیر. [InkOptions.hide_ink](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/inkoptions/hide_ink/) تنها بر نتیجهٔ رندر یا خروجی تأثیر می‌گذارد؛ اشیاء جوهر در ارائهٔ منبع حذف یا تغییر نمی‌شوند.

**کدام فرمت‌های خروجی از گزینه‌های جوهر پشتیبانی می‌کنند؟**  
می‌توانید گزینه‌های جوهر را برای PDF، HTML، SVG، TIFF و تصاویر بیت‌مپ اسلاید از طریق گزینه‌های خروجی یا رندر مربوطه که در جدول بالا نشان داده شده‌اند، پیکربندی کنید.

**مطالعهٔ بیشتر**  
* برای آشنایی با اشکال به‌صورت کلی، بخش [PowerPoint Shapes](https://docs.aspose.com/slides/fa/python-net/powerpoint-shapes/) را ببینید.  
* برای اطلاعات بیشتر درباره مقادیر مؤثر، به [Shape Effective Properties](https://docs.aspose.com/slides/fa/python-net/shape-effective-properties/#get-effective-font-height-value) مراجعه کنید.  
* برای جزئیات خروجی PDF، به [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fa/python-net/convert-powerpoint-to-pdf/) نگاه کنید.  
* برای جزئیات خروجی HTML، به [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fa/python-net/convert-powerpoint-to-html/) مراجعه کنید.  
* برای جزئیات خروجی SVG، به [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fa/python-net/render-a-slide-as-an-svg-image/) مراجعه کنید.  
* برای جزئیات خروجی TIFF، به [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fa/python-net/convert-powerpoint-to-tiff/) نگاه کنید.  
* برای جزئیات رندر اسلاید به تصویر، به [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fa/python-net/convert-slide/) مراجعه کنید.