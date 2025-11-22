---
title: استخراج نص متقدم من عروض PowerPoint التقديمية باستخدام Python
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/python-net/extract-text-from-presentation/
keywords:
- استخراج النص
- استخراج النص من الشريحة
- استخراج النص من العرض
- استخراج النص من PowerPoint
- استخراج النص من OpenDocument
- استخراج النص من PPT
- استخراج النص من PPTX
- استخراج النص من ODP
- استرجاع النص
- استرجاع النص من الشريحة
- استرجاع النص من العرض
- استرجاع النص من PowerPoint
- استرجاع النص من OpenDocument
- استرجاع النص من PPT
- استرجاع النص من PPTX
- استرجاع النص من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية استخراج النص بسرعة وسهولة من عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ Python عبر .NET. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت والوصول إلى محتوى الشرائح بفعالية في تطبيقاتك."
---

## **نظرة عامة**

استخراج النص من العروض التقديمية هو مهمة شائعة ولكنها أساسية للمطورين العاملين مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واستردادها يمكن أن يكون حاسمًا للتحليل، الأتمتة، الفهرسة، أو أغراض نقل المحتوى.

توفر هذه المقالة دليلًا شاملاً حول كيفية استخراج النص بكفاءة من تنسيقات عروض تقديمية مختلفة، بما في ذلك PPT و PPTX و ODP، باستخدام Aspose.Slides for Python. ستتعلم كيفية التكرار المنهجي عبر عناصر العرض لاسترجاع محتوى النص الذي تحتاجه بدقة.

## **استخراج النص من شريحة**

توفر Aspose.Slides for Python مساحة الاسم [aspose.slides.util](https://reference.aspose.com/slides/python-net/aspose.slides.util/) التي تشمل الفئة [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/). تعرض هذه الفئة عدة أساليب ثابتة محملة لتجاوز لتجميع كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم الأسلوب [get_all_text_boxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). يقبل هذا الأسلوب كائنًا من النوع [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) كمعامل. عند تنفيذه، يفحص الأسلوب الشريحة بالكامل بحثًا عن النص ويعيد مصفوفة من الكائنات من النوع [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، مع الحفاظ على أي تنسيق للنص.

القطعة البرمجية التالية تستخرج كل النص من الشريحة الأولى في العرض:
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # الحصول على مصفوفة من كائنات TextFrame من جميع الشرائح في ملف PPTX.
    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)
    # التكرار عبر مصفوفة إطارات النص.
    for text_frame in text_frames:
        # التكرار عبر الفقرات في إطار النص الحالي.
        for paragraph in text_frame.paragraphs:
            # التكرار عبر أجزاء النص في الفقرة الحالية.
            for portion in paragraph.portions:
                # عرض النص في الجزء الحالي.
                print(portion.text)
                # عرض ارتفاع الخط للنص.
                print(portion.portion_format.font_height)
                # عرض اسم الخط للنص.
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **استخراج النص من عرض تقديمي**

لمسح النص من كامل العرض التقديمي، استخدم الأسلوب الثابت [get_all_text_frames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_frames/) الذي تقدمه الفئة [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/). يقبل هذا الأسلوب معاملين:

1. كائن من النوع [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يمثل عرض PowerPoint أو OpenDocument سيتم استخراج النص منه.  
2. قيمة `Boolean` تشير إلى ما إذا كان يجب تضمين الشرائح الرئيسية عند مسح النص من العرض.

يعيد الأسلوب مصفوفة من الكائنات من النوع [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، متضمنةً معلومات تنسيق النص. الشيفرة أدناه تقوم بمسح النص وتفاصيل التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation("pres.pptx") as presentation:
    # الحصول على مصفوفة من كائنات TextFrame من جميع الشرائح في ملف PPTX.
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, True)
    # التكرار عبر مصفوفة إطارات النص.
    for text_frame in text_frames:
        # التكرار عبر الفقرات في إطار النص الحالي.
        for paragraph in text_frame.paragraphs:
            # التكرار عبر أجزاء النص في الفقرة الحالية.
            for portion in paragraph.portions:
                # عرض النص في الجزء الحالي.
                print(portion.text)
                # عرض ارتفاع الخط للنص.
                print(portion.portion_format.font_height)
                # عرض اسم الخط للنص.
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **استخراج النص المصنف والسريع**

الفئة [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationfactory/) توفر أيضًا أساليب ثابتة لاستخراج كل النص من العروض:
```py
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```


المعامل enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/python-net/aspose.slides/textextractionarrangingmode/) يحدد وضع تنظيم نتيجة استخراج النص ويمكن ضبطه على القيم التالية:
- `UNARRANGED` - النص الخام دون اعتبار لموقعه على الشريحة.  
- `ARRANGED` - يتم ترتيب النص بنفس الترتيب الموجود على الشريحة.

يمكن استخدام وضع `UNARRANGED` عندما تكون السرعة أمرًا حاسمًا؛ فهو أسرع من وضع `ARRANGED`.

الفئة [PresentationText](https://reference.aspose.com/slides/python-net/aspose.slides/presentationtext/) تمثل النص الخام المستخرج من العرض التقديمي. تحتوي على الخاصية `slides_text` التي تُعيد مصفوفة من الكائنات من النوع [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/). كل كائن يمثل النص على الشريحة المقابلة. كائن من النوع [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/) يمتلك الخصائص التالية:

- `text` - النص داخل أشكال الشريحة.  
- `master_text` - النص داخل أشكال الشريحة الرئيسية المرتبطة بهذه الشريحة.  
- `layout_text` - النص داخل أشكال شريحة التخطيط المرتبطة بهذه الشريحة.  
- `notes_text` - النص داخل أشكال شريحة الملاحظات المرتبطة بهذه الشريحة.  
- `comments_text` - النص داخل التعليقات المرتبطة بهذه الشريحة.
```py
import aspose.slides as slides

arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory().get_presentation_text("sample.pptx", arranging_mode)
slide_text = presentation_text.slides_text[0]
print(slide_text.text)
print(slide_text.layout_text)
print(slide_text.master_text)
print(slide_text.notes_text)
```


## **الأسئلة الشائعة**

**ما مدى سرعة معالجة Aspose.Slides للعرض التقديمي الكبير أثناء استخراج النص؟**

Aspose.Slides مُحسّنة لأداء عالٍ وتُعالج حتى [العروض الكبيرة](/slides/ar/python-net/open-presentation/) بكفاءة، مما يجعلها مناسبة للسيناريوهات الفورية أو المعالجة الضخمة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض؟**

نعم، يدعم Aspose.Slides استخراج النص من الجداول والرسوم البيانية وغيرها من العناصر المعقدة في الشريحة، مما يتيح لك الوصول إلى جميع المحتويات النصية وتحليلها بسهولة.

**هل أحتاج إلى ترخيص خاص لـ Aspose.Slides لاستخراج النص من العروض؟**

يمكنك استخراج النص باستخدام نسخة التجربة المجانية من Aspose.Slides، رغم أنها تحتوي على [قيود معينة](/slides/ar/python-net/licensing/)، مثل معالجة عدد محدود من الشرائح. للحصول على استخدام غير مقيد ومعالجة عروض أكبر، يُنصح بشراء ترخيص كامل.