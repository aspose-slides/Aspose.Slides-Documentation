---
title: تحويل عروض PowerPoint إلى مستندات Word في Python عبر Java
linktitle: PowerPoint إلى Word
type: docs
weight: 110
url: /ar/python-java/convert-powerpoint-to-word/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- PowerPoint إلى Word
- العرض التقديمي إلى Word
- PPT إلى Word
- PPTX إلى Word
- ODP إلى Word
- PowerPoint إلى DOCX
- PPT إلى DOCX
- PPTX إلى DOCX
- PowerPoint إلى DOC
- حفظ PPT كـ DOCX
- حفظ PPTX كـ DOCX
- تصدير PPT إلى DOCX
- تصدير PPTX إلى DOCX
- Python
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint و OpenDocument إلى مستند Word في Python عبر Java باستخدام Aspose.Slides و Aspose.Words، مع دمج صور الشرائح مع النص القابل للتحرير."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عروض PowerPoint و OpenDocument إلى مستندات Word باستخدام Aspose.Slides للـ Python عبر Java مع Aspose.Words للـ Java. يقوم Aspose.Slides بتصيير كل شريحة وقراءة نصها، بينما يقوم Aspose.Words بإنشاء مستند Word عبر JPype. لا يلزم وجود Microsoft Office.

يحتوي المستند الناتج على صورة الشريحة متبوعة بنص قابل للتحرير مستخرج من الأشكال التلقائية ذات المستوى العلوي لتلك الشريحة. تحافظ الصورة على المظهر البصري للشريحة؛ ولا يتم تحويل الأشكال الفردية والمخططات والجداول إلى كائنات Word قابلة للتحرير. لا يحتفظ النص المستخرج بتنسيق النص الأصلي أو موضعه.

## **تحويل PowerPoint إلى Word**

1. قم بتثبيت [Aspose.Slides for Python via Java](/slides/ar/python-java/installation/) وبيئة تشغيل Java متوافقة.
2. حمّل [Aspose.Words for Java](https://releases.aspose.com/words/java/). ضع ملف JAR الرئيسي الخاص به في دليل `lib` بجوار سكريبتك وأعد تسميته إلى `aspose-words.jar`، أو عدّل المسار في المثال ليتوافق مع الملف الذي حمّلته.
3. ضع عرض الإدخال، `sample.pptx`، في دليل العمل. مسار `lib/aspose-words.jar` أيضاً نسبياً إلى ذلك الدليل.
4. نفّذ الكود Python التالي لإنشاء `output.docx`.

يقوم المثال بتحميل المصدر باستخدام [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتصيير الشرائح باستخدام [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage). يستخدم [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) من Aspose.Words لإدراج الصور والنص في مستند Word.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # ضبط حجم صورة الشريحة لعرض مساحة النص، مع الحفاظ على نسبة أبعادها.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # إلحاق النص العادي من الأشكال التلقائية ذات المستوى العلوي، بما في ذلك صناديق النص.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

تبدأ كل شريحة في صفحة جديدة. قد يتطلب النص المستخرج الطويل أو الصور الشريحة ذات الارتفاع غير الاعتيادي صفحات إضافية. يضيف الكود فواصل صفحات فقط بين الشرائح ويعيد تحرير العرض والصور المصدرة في كتل `finally`. يبقى JVM متاحاً للتحويلات اللاحقة في نفس عملية Python.

## **الأسئلة الشائعة**

**ما المكتبات المطلوبة؟**

استخدم Aspose.Slides للـ Python عبر Java، JPype، بيئة تشغيل Java متوافقة، وAspose.Words للـ Java. تعمل المكتبتان في نفس JVM. يتولى Aspose.Slides معالجة العرض؛ ويكتب Aspose.Words مستند Word.

**هل يمكنني تحويل ملفات PPT و ODP بالإضافة إلى PPTX؟**

نعم. استبدل `sample.pptx` بملف PPT أو ODP. راجع [Supported File Formats](/slides/ar/python-java/supported-file-formats/) للحصول على صيغ ملفات العرض المدعومة.

**هل كل محتوى الشريحة قابل للتحرير في Word؟**

لا. تُدرج كل شريحة كصورة ثابتة، مع إضافة النص العادي من الأشكال التلقائية ذات المستوى العلوي أسفلها. لا يتم استخراج النص داخل المجموعات أو الجداول أو SmartArt أو المخططات، وكذلك ملاحظات المتحدث، في هذا المثال. لا تُعاد إنشاء الرسوم المتحركة والانتقالات في مستند Word.

**هل يمكنني الحفظ كملف DOC بدلاً من DOCX؟**

نعم. غيّر اسم الملف الناتج إلى `output.doc`. يحدد Aspose.Words تنسيق الإخراج بناءً على امتداد اسم الملف عند استخدام هذا التحميل الزائد للحفظ.