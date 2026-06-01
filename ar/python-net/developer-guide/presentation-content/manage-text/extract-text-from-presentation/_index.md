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
description: "استخراج النص بسرعة من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

استخراج النص من العروض التقديمية هو مهمة شائعة ولكنها أساسية للمطورين الذين يعملون مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها يمكن أن يكون حيويًا للتحليل، والأتمتة، والفهرسة، أو لأغراض ترحيل المحتوى.

توفر هذه المقالة دليلًا شاملًا حول كيفية استخراج النص بكفاءة من صيغ العرض التقديمي المختلفة، بما في ذلك PPT وPPTX وODP، باستخدام Aspose.Slides for Python via .NET. ستتعلم كيفية التكرار المنهجي عبر عناصر العرض لاسترجاع المحتوى النصي بدقة ما تحتاجه.

## **استخراج النص من شريحة**

توفر Aspose.Slides for Python via .NET مساحة الاسم [aspose.slides.util](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/) التي تشمل الفئة [SlideUtil](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/). تكشف هذه الفئة عن عدة طرق ثابتة محملة زائدًا لاستخراج كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم الطريقة [get_all_text_boxes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). تقبل هذه الطريقة كائنًا من النوع [BaseSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/) كمعامل. عند التنفيذ، تقوم الطريقة بمسح الشريحة بالكامل للبحث عن النص وتُعيد مصفوفة من الكائنات من النوع [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/)، مع الحفاظ على أي تنسيق نصي.

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

لمسح النص من كامل العرض، استخدم الطريقة الثابتة [get_all_text_frames](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/get_all_text_frames/) التي تعرضها الفئة [SlideUtil](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/). تقبل هذه الطريقة معاملين:

1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/as