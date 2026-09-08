---
title: انیمیشن متن پاورپوینت در پایتون از طریق جاوا
linktitle: متن انیمیشنی
type: docs
weight: 60
url: /fa/python-java/animated-text/
keywords:
- متن انیمیشنی
- انیمیشن متن
- پاراگراف انیمیشنی
- انیمیشن پاراگراف
- اثر انیمیشن
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "متن پویا و انیمیشنی را در ارائه‌های پاورپوینت و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق جاوا ایجاد کنید، با مثال‌های کد پایتون بهینه و آسان برای پیگیری."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه می‌توانید با استفاده از Aspose.Slides به متن‌های انیمیشنی افکت‌های انیمیشن را بر روی پاراگراف‌های منفرد اعمال کنید و افکت‌های اختصاص داده‌شده به پاراگراف‌ها را در یک قاب متن بازیابی کنید. این مقاله بر روش‌های API برای افزودن انیمیشن سطح پاراگراف و بررسی افکت‌های انیمیشن موجود در یک ارائه تمرکز دارد.

## **افزودن اثرهای انیمیشن به پاراگراف‌ها**

متد [addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) کلاس [Sequence](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/) به شما امکان می‌دهد تا افکت‌های انیمیشن را به یک پاراگراف تنها اضافه کنید. این کد نمونه نشان می‌دهد چگونه یک افکت انیمیشن را به یک پاراگراف اضافه کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # پاراگرافی را که می‌خواهید افکت به آن اضافه کنید انتخاب کنید.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # افکت انیمیشن Fly را به پاراگراف انتخاب شده اضافه کنید.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دریافت اثرهای انیمیشن پاراگراف‌ها**

ممکن است بخواهید افکت‌های انیمیشن اضافه‌ شده به یک پاراگراف را بیابید—به عنوان مثال، در یک سناریو می‌خواهید افکت‌های انیمیشن یک پاراگراف را دریافت کنید تا آن‌ها را بر پاراگراف یا شکل دیگری اعمال کنید.

Aspose.Slides for Python via Java به شما اجازه می‌دهد تمام افکت‌های انیمیشن اعمال‌شده به پاراگراف‌های موجود در یک قاب متن (شکل) را دریافت کنید. این کد نمونه نشان می‌دهد چگونه افکت‌های انیمیشن یک پاراگراف را دریافت کنید:

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

## **سؤالات متداول**

**انیمیشن‌های متن چگونه با انتقال‌های اسلاید متفاوت هستند و آیا می‌توان آن‌ها را ترکیب کرد؟**
انیمیشن‌های متن رفتار اشیا را در طول زمان روی اسلاید کنترل می‌کنند، در حالی که [transitions](/slides/fa/python-java/slide-transition/) نحوهٔ تغییر اسلایدها را مدیریت می‌کنند. این دو مستقل هستند و می‌توانند با هم استفاده شوند؛ ترتیب پخش توسط تایم‌لاین انیمیشن و تنظیمات انتقال تعیین می‌شود.

**آیا انیمیشن‌های متن هنگام خروجی به PDF یا تصویر حفظ می‌شوند؟**
خیر. PDF و تصاویر رستری ایستا هستند، لذا فقط یک حالت ثابت از اسلاید بدون حرکت را می‌بینید. برای حفظ حرکت، از خروجی [video](/slides/fa/python-java/convert-powerpoint-to-video/) یا [HTML](/slides/fa/python-java/export-to-html5/) استفاده کنید.

**آیا انیمیشن‌های متن در لایه‌ها و مستر اسلاید کار می‌کنند؟**
افکت‌های اعمال‌شده به اشیای لایه/مستر به اسلایدها ارث می‌برند، اما زمان‌بندی و تعامل آن‌ها با انیمیشن‌های سطح اسلاید به ترتیب نهایی در اسلاید بستگی دارد.