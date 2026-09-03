---
title: إدارة مربعات النص في العروض التقديمية باستخدام بايثون
linktitle: إدارة مربع النص
type: docs
weight: 20
url: /ar/python-net/manage-textbox/
keywords:
- مربع نص
- إطار نص
- إضافة نص
- تحديث نص
- إنشاء مربع نص
- التحقق من مربع النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتحديد وتنسيق وتحديث مربعات النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET."
---
## **مقدمة**

في Aspose.Slides for Python عبر .NET، يتم تخزين نص الشريحة في إطارات نصية تنتمي إلى الأشكال. تمثل الفئة AutoShape الشكل الأكثر شيوعًا الذي يحتوي على نص وتعرض نصه من خلال الخاصية AutoShape.text_frame.

{{% alert color="info" title="Note" %}}
كل شكل تلقائي يرث من Shape، لكن ليس كل شكل هو شكل تلقائي أو يدعم إطار نصي. عند معالجة عرض تقديمي موجود، استخدم `isinstance(shape, slides.AutoShape)` للتحقق من نوع الشكل قبل الوصول إلى نصه.
{{% /alert %}}

## **إنشاء مربع نص على شريحة**

لإنشاء مربع نص، أضف شكلاً تلقائيًا إلى شريحة، أضف نصًا إلى إطار النص الخاص به، واحفظ العرض التقديمي. المثال التالي ينشئ مربع نص مستطيل:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

الإحداثيات والأبعاد التي تُمرَّر إلى ShapeCollection.add_auto_shape تُقاس بالنقاط. تقوم AutoShape.add_text_frame بتهيئة إطار النص بالنص المزوَّد.

## **التحقق من شكل مربع النص**

استخدم الخاصية AutoShape.is_text_box لتحديد ما إذا كان الشكل التلقائي يُعامل كمربع نص. هذا مفيد عندما يحتوي العرض التقديمي على أشكال تلقائية تحمل نصًا وأخرى رسومية بحتة.

![مربع نص وشكل](istextbox.png)

المثال التالي يفحص كل شكل تلقائي في عرض تقديمي:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

لا يُعتبر الشكل التلقائي المضاف حديثًا مربع نص حتى يحتوي على نص غير فارغ. يمكنك توفير ذلك النص عبر AutoShape.add_text_frame أو TextFrame.text. إضافة أو تعيين سلسلة فارغة يترك الخاصية is_text_box مُعينة إلى `False`:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

ستطبع الاستدعائين الأولين `True`؛ والاثنين الأخيرين `False`.

## **إيجاد الشكل الذي يمتلك إطار النص**

قد يتلقى شفرة معالجة النص العامة كائن TextFrame دون معرفة أي كائن عرض تقديمي يحتويه. استخدم الخاصية للقراءة فقط TextFrame.parent_shape للانتقال مرة أخرى إلى الشكل المالك Shape.

لإطار نص مملوك لشكل تلقائي أو شكل آخر يحمل نصًا، يحتوي parent_shape على المالك وتكون TextFrame.parent_cell هي `None`. تحقق من القيمة المرجعة قبل الوصول إليها. لتحديد كل من مالكي الشكل وخلايا الجدول، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [بحث واستبدال النص](/slides/ar/python-net/search-and-replace-text/).

## **إضافة أعمدة إلى مربع النص**

خاصية TextFrameFormat.column_count تقسم إطار النص إلى أعمدة، بينما TextFrameFormat.column_spacing تحدد الفاصل بين الأعمدة بالنقاط. كلا الإعدادين ينتميان إلى TextFrameFormat ويمكن تغييرهما عبر إطار النص لمربع نص موجود. يعاد تدفق النص بين الأعمدة داخل الشكل نفسه؛ ولا يستمر إلى شكل آخر.

المثال التالي ينشئ مربع نص بثلاثة أعمدة مع مسافة 10 نقاط بين الأعمدة، يحفظ العرض التقديمي، ويقرأ الإعدادات المخزنة مرة أخرى من ملف الإخراج:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **استخراج النص من الأعمدة الفردية**

استخدم TextFrame.split_text_by_columns لاسترجاع النص المخصص لكل عمود بصري في إطار نص موجود. تُرجع الطريقة سلسلة واحدة لكل عمود، بترتيب القراءة حسب الأعمدة. إطار نص بعمود واحد ينتج قائمة بعنصر واحد، والعمود الفارغ يُمثَّل بسلسلة فارغة. السلاسل تحتوي على نص عادي فقط؛ ولا يتم حفظ تنسيق مستوى الجزء.

هذا مفيد عندما تحتاج إلى:
- استخراج النص مع الحفاظ على ترتيب القراءة حسب الأعمدة.
- فهرسة أو مقارنة محتوى الشرائح متعددة الأعمدة.
- تصدير كل عمود إلى ملف منفصل أو حقل قاعدة بيانات أو هدف آخر.
- فحص كيفية إعادة توزيع النص بعد تغيير TextFrameFormat.column_count أو TextFrameFormat.column_spacing أو الخط أو حجم إطار النص.

الطريقة تُبلِّغ عن النص الموزَّع داخل TextFrame الحالي؛ ولا تُعيد تلقائيًا تدفق النص بين الأشكال أو مربعات النص المنفصلة. قد تعتمد توزيع الأعمدة على الخطوط المتوفرة وإعدادات تخطيط النص الأخرى، لذا تأكَّد من توفر الخطوط المطلوبة عندما تكون النتائج المتسقة مهمة.

المثال التالي يحمل عرضًا تقديميًا، يجد أول شكل تلقائي متعدد الأعمدة يحتوي على إطار نص، يقرأ عدد الأعمدة المُعدَّة، ويكتب النص من كل عمود إلى ملف منفصل. يتم تخطي الأشكال التي لا توفر إطار نص.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **تحديث النص**

لتحديث النص في جميع أنحاء العرض التقديمي، احرص على المرور عبر الشرائح والأشكال، اختر الأشكال التلقائية، ثم حرر أجزاء النص الخاصة بها. العمل على مستوى الجزء يتيح لك تعديل كل من النص وتنسيق الأحرف.

المثال التالي يستبدل كل ظهور لـ `years` بـ `months` في نص الشكل التلقائي ويجعل كل جزء متأثر بالخط عريض:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

هذا التجول يُحدّث النص فقط في الأشكال التلقائية. النص المخزن في الجداول أو المخططات أو SmartArt أو الأشكال المجمعة يتطلب مرورًا عبر مجموعات تلك الكائنات نفسها.

## **إضافة مربع نص مع ارتباط تشعبي**

يمكن تعيين ارتباط تشعبي إلى جزء نص محدد، بحيث يكون ذلك النص فقط هو الرابط القابل للنقر. استخدم HyperlinkManager.set_external_hyperlink_click لربط الجزء بعنوان URL خارجي.

المثال التالي ينشئ نصًا مرتبطًا ويحفظه في عرض تقديمي:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**ما الفرق بين مربع النص وعنصر نائب على شريحة رئيسية أو شريحة تخطيطية؟**

يمكن لعناصر الـ [عنصر نائب](/slides/ar/python-net/manage-placeholder/) أن يرث موقعه وتنسيقه من [الشريحة الرئيسية](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslide/) أو [شريحة تخطيط](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/). بينما يكون مربع النص العادي شكلاً مستقلاً على الشريحة التي تم إنشاؤه فيها ولا يكتسب سلوك العنصر النائب عندما يتغير التخطيط.

**كيف يمكنني استبدال النص دون تغيير النص في المخططات أو الجداول أو SmartArt؟**

قصر المرور على مثيلات AutoShape، كما هو موضح في مثال تحديث النص. تخزن المخططات والجداول وSmartArt النص في نماذج كائناتهم الخاصة، لذا لا يتم تعديلها بواسطة تلك الحلقة.