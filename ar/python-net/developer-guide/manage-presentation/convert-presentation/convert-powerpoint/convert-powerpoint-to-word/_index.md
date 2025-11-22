---
title: تحويل عروض PowerPoint إلى مستندات Word في Python
linktitle: PowerPoint إلى Word
type: docs
weight: 110
url: /ar/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint إلى DOCX
- OpenDocument إلى DOCX
- عرض تقديمي إلى DOCX
- شريحة إلى DOCX
- PPT إلى DOCX
- PPTX إلى DOCX
- ODP إلى DOCX
- PowerPoint إلى DOC
- OpenDocument إلى DOC
- عرض تقديمي إلى DOC
- شريحة إلى DOC
- PPT إلى DOC
- PPTX إلى DOC
- ODP إلى DOC
- PowerPoint إلى Word
- OpenDocument إلى Word
- عرض تقديمي إلى Word
- شريحة إلى Word
- PPT إلى Word
- PPTX إلى Word
- ODP إلى Word
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- تحويل ODP
- بايثون
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint وOpenDocument بسهولة إلى مستندات Word باستخدام Aspose.Slides for Python عبر .NET. دليلنا خطوة بخطوة مع مثال شيفرة Python يقدم الحل للمطورين الذين يرغبون في تبسيط سير عمل المستندات."
---

## **نظرة عامة**

هذه المقالة توفر حلاً للمطورين لتحويل عروض PowerPoint وOpenDocument إلى مستندات Word باستخدام Aspose.Slides for Python عبر .NET وAspose.Words for Python عبر .NET. الدليل خطوة بخطوة يشرح كل مرحلة من عملية التحويل.

## **تحويل عرض تقديمي إلى مستند Word**

اتبع التعليمات أدناه لتحويل عرض PowerPoint أو OpenDocument إلى مستند Word:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل ملف عرض تقديمي.  
2. إنشاء كائنات الفئات [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) و[DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) لتوليد مستند Word.  
3. ضبط حجم الصفحة للمستند Word بحيث يطابق حجم الصفحة في العرض باستخدام خاصية [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).  
4. ضبط الهوامش في مستند Word باستخدام خاصية [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).  
5. الانتقال عبر جميع شرائح العرض باستخدام خاصية [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/).  
   - إنشاء صورة للشريحة باستخدام طريقة `get_image` من الفئة [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) وحفظها في تدفق الذاكرة.  
   - إضافة صورة الشريحة إلى مستند Word باستخدام طريقة `insert_image` من الفئة [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) .  
6. حفظ مستند Word إلى ملف.

لنفترض أن لدينا عرضًا تقديميًا باسم "sample.pptx" يبدو هكذا:

![عرض PowerPoint](PowerPoint.png)

مثال كود Python التالي يوضح كيفية تحويل عرض PowerPoint إلى مستند Word:
```py
import aspose.slides as slides
import aspose.words as words

# تحميل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:

    # إنشاء كائنات Document و DocumentBuilder.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # ضبط حجم الصفحة في مستند Word.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # ضبط الهوامش في مستند Word.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # المرور على جميع شرائح العرض التقديمي.
    for slide in presentation.slides:

        # إنشاء صورة شريحة وحفظها إلى تدفق الذاكرة.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # إضافة صورة الشريحة إلى مستند Word.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # حفظ مستند Word إلى ملف.
    document.save("output.docx")
```


النتيجة:

![مستند Word](Word.png)

{{% alert color="primary" %}} 
جرّب أداة [**Online PPT to Word Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) لمعرفة الفوائد التي ستحصل عليها من تحويل عروض PowerPoint وOpenDocument إلى مستندات Word. 
{{% /alert %}}

## **FAQ**

**ما المكونات التي يجب تثبيتها لتحويل عروض PowerPoint وOpenDocument إلى مستندات Word؟**

كل ما تحتاجه هو إضافة الحزم المناسبة لـ [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) و[Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) إلى مشروع Python الخاص بك. كلا الحزمتين تعملان كواجهات برمجة تطبيقات مستقلة، ولا يلزم تثبيت Microsoft Office.

**هل جميع صيغ عروض PowerPoint وOpenDocument مدعومة؟**

Aspose.Slides for Python .NET [supports all presentation formats](/slides/ar/python-net/supported-file-formats/)، بما في ذلك PPT وPPTX وODP وغيرها من أنواع الملفات الشائعة. يضمن ذلك إمكانية العمل مع عروض تم إنشاؤها باستخدام إصدارات مختلفة من Microsoft PowerPoint.