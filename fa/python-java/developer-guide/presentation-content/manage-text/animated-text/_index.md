---
title: انیمیت کردن متن پاورپوینت در پایتون از طریق جاوا
linktitle: متن انیمیشنی
type: docs
weight: 60
url: /fa/python-java/animated-text/
keywords:
- متن انیمیشنی
- انیمیشن متن
- پاراگراف انیمیشنی
- انیمیشن پاراگراف
- افکت انیمیشن
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "با استفاده از Aspose.Slides برای پایتون از طریق جاوا، متن‌های انیمیشنی پویا را در ارائه‌های پاورپوینت و OpenDocument ایجاد کنید، به همراه مثال‌های کد پایتون آسان‌فهم و بهینه‌شده."
---
## **نمایش کلی**

این مقاله توضیح می‌دهد چگونه در Aspose.Slides با اعمال افکت‌های انیمیشن به پاراگراف‌های جداگانه کار کنید و افکت‌های قبلاً به پاراگراف‌های یک فریم متن اختصاص داده شده را بازیابی کنید. تمرکز بر روش‌های API برای اضافه کردن انیمیشن در سطح پاراگراف و بررسی افکت‌های انیمیشن موجود در یک ارائه است.

## **افزودن افکت‌های انیمیشن به پاراگراف‌ها**

متد [addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) کلاس [Sequence](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/) به شما امکان می‌دهد افکت انیمیشن را به یک پاراگراف اضافه کنید. این کد نمونه نشان می‌دهد چگونه یک افکت انیمیشن را به یک پاراگراف اضافه کنیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # پاراگرافی را که می‌خواهید افکتی به آن اضافه کنید، انتخاب کنید.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # افزودن افکت انیمیشن پرواز به پاراگراف انتخاب شده.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دریافت افکت‌های انیمیشن پاراگراف‌ها**

ممکن است بخواهید افکت‌های انیمیشن اعمال‌شده به یک پاراگراف را بازیابی کنید — برای مثال، برای اعمال این افکت‌ها به پاراگراف یا شکل دیگری.

Aspose.Slides for Python via Java به شما امکان می‌دهد تمام افکت‌های انیمیشن اعمال‌شده به پاراگراف‌های موجود در یک فریم متن (شکل) را دریافت کنید. این کد نمونه نشان می‌دهد چگونه افکت‌های انیمیشن اعمال‌شده به یک پاراگراف را دریافت کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **سوالات متداول**

**چگونه انیمیشن‌های متن با انتقالات اسلاید متفاوت هستند و آیا می‌توان آنها را ترکیب کرد؟**

انیمیشن‌های متن رفتار شیء را در طول زمان روی اسلاید کنترل می‌کنند، در حالی که [انتقالات](/slides/fa/python-java/slide-transition/) نحوه تغییر اسلایدها را تعیین می‌کنند. این دو مستقل هستند و می‌توانند با هم استفاده شوند؛ ترتیب پخش توسط خط زمان انیمیشن و تنظیمات انتقال تعیین می‌شود.

**آیا انیمیشن‌های متن هنگام خروجی به PDF یا تصاویر حفظ می‌شوند؟**

خیر. PDF و تصاویر رستر ثابت هستند، بنابراین فقط یک وضعیت ثابت از اسلاید بدون حرکت مشاهده می‌کنید. برای حفظ حرکت، از خروجی [ویدیو](/slides/fa/python-java/convert-powerpoint-to-video/) یا [HTML](/slides/fa/python-java/export-to-html5/) استفاده کنید.

**آیا انیمیشن‌های متن در چیدمان‌ها و مستر اسلاید کار می‌کنند؟**

افکت‌های اعمال‌شده به اشیای چیدمان/مستر به اسلایدها ارث می‌رسند، اما زمان‌بندی و تعامل آنها با انیمیشن‌های سطح اسلاید بستگی به توالی نهایی روی اسلاید دارد.