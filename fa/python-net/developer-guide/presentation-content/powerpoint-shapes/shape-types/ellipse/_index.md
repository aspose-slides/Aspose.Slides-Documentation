---
title: افزودن بیضی‌ها به ارائه‌ها در پایتون
linktitle: بیضی
type: docs
weight: 30
url: /fa/python-net/ellipse/
keywords:
- بیضی
- شکل
- افزودن بیضی
- ایجاد بیضی
- رسم بیضی
- بیضی قالب‌بندی‌شده
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه در Aspose.Slides برای پایتون از طریق .NET، شکل‌های بیضی را در ارائه‌های PPT، PPTX و ODP ایجاد، قالب‌بندی و دستکاری کنید—نمونه کدها نیز آورده شده است."
---
## **مروری کلی**

این مقاله نشان می‌دهد که چگونه می‌توان با استفاده از Aspose.Slides به اسلایدهای PowerPoint شکل‌های بیضی افزود. این شامل ایجاد یک بیضی ساده، ایجاد یک بیضی قالب‌بندی‌شده و ذخیرهٔ ارائه به‌روز‌شده به‌صورت فایل PPTX است. همچنین به سؤالات مرتبطی مانند کار با موقعیت و اندازهٔ بیضی، کنترل ترتیب لایه‌ها و اعمال افکت‌های انیمیشن می‌پردازد.

## **ایجاد بیضی**
در این بخش، توسعه‌دهندگان با افزودن شکل‌های بیضی به اسلایدهای خود با استفاده از Aspose.Slides برای Python via .NET آشنا می‌شوند. Aspose.Slides برای Python via .NET مجموعه‌ای ساده‌ از APIها را برای کشیدن انواع مختلف شکل‌ها با تنها چند خط کد فراهم می‌کند. برای افزودن یک بیضی ساده به اسلاید انتخابی ارائه، مراحل زیر را دنبال کنید:

1. یک نمونه از [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/)class ایجاد کنید
2. با استفاده از Index آن، ارجاع به یک اسلاید را به دست آورید
3. با استفاده از متد AddAutoShape که توسط شیء IShapes در دسترس است، یک AutoShape از نوع Ellipse اضافه کنید
4. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX بنویسید

در مثال زیر، یک بیضی به اسلاید اول اضافه شده است.

```py
import aspose.slides as slides

# ایجاد شیء کلاس Presentation که نمایانگر فایل PPTX است
with slides.Presentation() as pres:
    # دریافت اولین اسلاید
    sld = pres.slides[0]

    # افزودن AutoShape از نوع بیضی
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #نوشتن فایل PPTX در دیسک
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ایجاد بیضی قالب‌بندی‌شده**
برای افزودن یک بیضی با قالب‌بندی بهتر به اسلاید، مراحل زیر را انجام دهید:

1. یک نمونه از [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/)class ایجاد کنید.
2. با استفاده از Index آن، ارجاع به یک اسلاید را به دست آورید.
3. با استفاده از متد AddAutoShape که توسط شیء IShapes در دسترس است، یک AutoShape از نوع Ellipse اضافه کنید.
4. نوع پر شدن بیضی را به Solid تنظیم کنید.
5. رنگ بیضی را با استفاده از ویژگی SolidFillColor.Color که توسط شیء FillFormat مرتبط با شیء IShape در دسترس است، تنظیم کنید.
6. رنگ خطوط بیضی را تنظیم کنید.
7. پهنای خطوط بیضی را تنظیم کنید.
8. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

در مثال زیر، یک بیضی قالب‌بندی‌شده به اسلاید اول ارائه اضافه شده است.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# ایجاد شیء کلاس Presentation که نمایانگر فایل PPTX است
with slides.Presentation() as pres:
    # دریافت اولین اسلاید
    sld = pres.slides[0]

    # افزودن AutoShape از نوع بیضی
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # اعمال برخی قالب‌بندی‌ها به شکل بیضی
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # اعمال برخی قالب‌بندی‌ها به خط بیضی
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #نوشتن فایل PPTX در دیسک
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**چگونه می‌توان موقعیت و اندازه دقیق یک بیضی را نسبت به واحدهای اسلاید تنظیم کرد؟**

مختصات و اندازه‌ها معمولاً **به نقطه** (points) تعریف می‌شوند. برای نتایج قابل پیش‌بینی، محاسبات خود را بر اساس اندازه اسلاید انجام داده و میلی‌متر یا اینچ مورد نیاز را قبل از اختصاص مقدار به نقطه تبدیل کنید.

**چگونه می‌توان یک بیضی را بالای یا پایین اشیای دیگر قرار داد (کنترل ترتیب لایه‌ها)؟**

ترتیب رسم شیء را با آوردن به جلو یا پس‌زمینه تغییر دهید. این کار اجازه می‌دهد تا بیضی روی اشیای دیگر قرار بگیرد یا اشیای زیرین را نمایان کند.

**چگونه می‌توان ظاهر یا تأکید یک بیضی را انیمیشن داد؟**

[Apply](/slides/fa/python-net/shape-animation/) افکت‌های ورود، تأکید یا خروج را به شکل اعمال کنید و با تنظیم trigger‌ها و زمان‌بندی، زمان و نحوهٔ پخش انیمیشن را تنظیم کنید.