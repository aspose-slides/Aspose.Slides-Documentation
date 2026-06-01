---
title: استخراج النص المتقدم من العروض التقديمية في بايثون
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/python-net/extract-text-from-presentation/
keywords:
- استخراج النص
- استخراج النص من الشريحة
- استخراج النص من العرض التقديمي
- استخراج النص من PowerPoint
- استخراج النص من OpenDocument
- استخراج النص من PPT
- استخراج النص من PPTX
- استخراج النص من ODP
- استرجاع النص
- استرجاع النص من الشريحة
- استرجاع النص من العرض التقديمي
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
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

استخراج النص من العروض التقديمية مهمة شائعة ولكنها أساسية للمطورين الذين يعملون مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها يمكن أن يكون حاسمًا للتحليل أو الأتمتة أو الفهرسة أو أغراض ترحيل المحتوى.

توفر هذه المقالة دليلًا شاملًا حول كيفية استخراج النص بكفاءة من تنسيقات العروض المختلفة، بما في ذلك PPT و PPTX و ODP، باستخدام Aspose.Slides for Python via .NET. ستتعلم كيفية التجوال منهجي عبر عناصر العرض لاسترجاع المحتوى النصي الذي تحتاجه بدقة.

## **استخراج النص من شريحة**

Aspose.Slides for Python via .NET يوفر مساحة الاسم [aspose.slides.util](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/) التي تشمل الفئة [SlideUtil](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/). تكشف هذه الفئة عن عدة طرق ثابتة محمّلة لاستخراج كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم طريقة [get_all_text_boxes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). تقبل هذه الطريقة كمعامل كائن من النوع [BaseSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/). عند التنفيذ، تقوم الطريقة بمسح الشريحة بالكامل بحثًا عن النص وتعيد مصفوفة من الكائنات من النوع [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/)، مع الحفاظ على أي تنسيق نصي.

المقتطف البرمجي التالي يستخرج كل النص من الشريحة الأولى في العرض:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **استخراج النص من عرض تقديمي**

لمسح النص من العرض بالكامل، استخدم الطريقة الثابتة [get_all_text_frames](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/get_all_text_frames/) التي تكشف عنها الفئة [SlideUtil](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/). تقبل هذه الطريقة معاملين:

1. أولًا، كائن من النوع [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) يمثل عرض PowerPoint أو OpenDocument سيتم استخراج النص منه.
1. ثانيًا، قيمة `Boolean` تحدد ما إذا كان يجب تضمين الشرائح الرئيسية عند مسح النص من العرض.

تعيد الطريقة مصفوفة من الكائنات من النوع [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/)، متضمنة معلومات تنسيق النص. الكود أدناه يمسح النص وتفاصيل التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **استخراج النص المصنف والسريع**

الفئة [PresentationFactory](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/) توفر أيضًا طرقًا لاستخراج كل النص من العروض:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

معامل التعداد [TextExtractionArrangingMode](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textextractionarrangingmode/) يحدد وضع تنظيم نتيجة استخراج النص ويمكن تعيينه إلى القيم التالية:
- `UNARRANGED` - النص الخام دون مراعاة موقعه على الشريحة.
- `ARRANGED` - النص مرتب بنفس ترتيب ظهوره على الشريحة.

يمكن استخدام وضع `UNARR