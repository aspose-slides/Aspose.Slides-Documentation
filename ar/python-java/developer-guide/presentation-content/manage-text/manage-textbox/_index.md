---
title: إدارة صناديق النص في العروض التقديمية باستخدام Python عبر Java
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/python-java/manage-textbox/
keywords:
- صندوق نص
- إطار نص
- إضافة نص
- تحديث نص
- إنشاء صندوق نص
- التحقق من صندوق النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء وتحديد وتنسيق وتحديث صناديق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Python عبر Java."
---
## **المقدمة**

في Aspose.Slides for Python via Java، يتم تخزين نص الشرائح في إطارات نصية تتبع الأشكال. تمثل فئة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) الشكل الأكثر شيوعًا الذي يحمل نصًا وتعرض نصه عبر طريقة [AutoShape.getTextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
كل شكل تلقائي يرث من [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/)، لكن ليس كل شكل هو شكل تلقائي أو يدعم إطار نص. عند معالجة عرض تقديمي موجود، تحقق من أن الشكل هو نسخة من [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) قبل الوصول إلى نصه.
{{% /alert %}}

## **إنشاء مربع نص على شريحة**

لإنشاء مربع نص، أضف شكلاً تلقائيًا إلى شريحة، أضف نصًا إلى إطاره النصي، واحفظ العرض التقديمي. المثال التالي ينشئ مربع نص مستطيل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الإحداثيات والأبعاد التي تُمرَّر إلى [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addAutoShape) تُقاس بالنقاط. تقوم [AutoShape.addTextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/#addTextFrame) بتهيئة الإطار النصي بالنص المقدم.

## **التحقق من شكل مربع النص**

استخدم طريقة [AutoShape.isTextBox](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/#isTextBox) لتحديد ما إذا كان الشكل التلقائي يُعامل كمربع نص. هذا مفيد عندما يحتوي العرض التقديمي على أشكال تلقائية تحمل نصًا وأخرى رسومية بحتة.

![مربع نص وشكل](istextbox.png)

المثال التالي يفحص كل شكل تلقائي في العرض التقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

لا يُعتبر الشكل التلقائي المضاف حديثًا مربع نص حتى يحتوي على نص غير فارغ. يمكنك توفير هذا النص عبر [AutoShape.addTextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/#addTextFrame) أو [TextFrame.setText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#setText). إضافة أو تعيين سلسلة فارغة تجعل [AutoShape.isTextBox](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/#isTextBox) تُعيد `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

تطبع الاستدعاءات الأولى اثنين `True`؛ والاثنان الأخيرين `False`.

## **العثور على الشكل الذي يمتلك إطار نص**

قد يتلقى كود معالجة النص العام كائنًا من نوع [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) دون معرفة أي كائن عرض تقديمي يحتويه. استخدم طريقة القراءة فقط [TextFrame.getParentShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParentShape) للعودة إلى الشكل المالك لـ [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/).

بالنسبة لإطار نص مملوك لشكل تلقائي أو إلى شكل آخر يحمل نصًا، تُعيد [TextFrame.getParentShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParentShape) المالك وتُعيد [TextFrame.getParentCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParentCell) القيمة `None`. تحقق من القيمة المُسترجعة قبل الوصول إليها. لتحديد كلٍ من مالكي الشكل وخلايا الجدول، بما في ذلك الأشكال المرتبطة بعُقد SmartArt، راجع [Search and Replace Text](/slides/ar/python-java/search-and-replace-text/).

## **إضافة أعمدة إلى مربع النص**

طريقة [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setColumnCount) تقسم إطار النص إلى أعمدة، بينما تُحدد طريقة [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setColumnSpacing) الفراغ بين الأعمدة بالنقاط. كلا الإعدادين ينتميان إلى [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/) ويمكن تغييره من خلال إطار النص لمربع نص موجود. يتدفق النص بين الأعمدة داخل الشكل نفسه؛ ولا يستمر إلى شكل آخر.

المثال التالي ينشئ مربع نص بثلاثة أعمدة مع 10 نقاط بين الأعمدة، يحفظ العرض التقديمي، ويقرئ الإعدادات المخزنة من ملف الإخراج:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **استخراج النص من الأعمدة الفردية**

استخدم [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#splitTextByColumns) لاسترجاع النص المخصص لكل عمود بصري في إطار نص موجود. تُعيد الطريقة سلسلة نصية واحدة لكل عمود، بترتيب القراءة القائم على الأعمدة. يُنتج إطار نص بعمود واحد مصفوفة ذات عنصر واحد، وتمثّل العمود الفارغ سلسلة فارغة. تحتوي السلاسل على نص عادي فقط؛ ولا يُحافظ على تنسيق المستوى الجزئي.

هذا مفيد عندما تحتاج إلى:

- استخراج النص مع الحفاظ على ترتيب القراءة القائم على الأعمدة.
- فهرسة أو مقارنة محتوى الشرائح متعددة الأعمدة.
- تصدير كل عمود إلى ملف منفصل، حقل قاعدة بيانات، أو وجهة أخرى.
- فحص كيفية إعادة توزيع النص بعد تغيير عدد الأعمدة باستخدام [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setColumnCount)، أو الفراغ باستخدام [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setColumnSpacing)، أو الخط، أو حجم إطار النص.

الطريقة تُبلّغ عن النص الموزع داخل [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الحالي؛ ولا تُسْقِط النص تلقائيًا بين أشكال أو مربعات نص منفصلة. يمكن أن يعتمد توزيع الأعمدة على الخطوط المتوفرة وإعدادات تخطيط النص الأخرى، لذا تأكد من توفر الخطوط المطلوبة عندما تكون النتائج المتناسقة مهمة.

المثال التالي يحمِّل عرضًا تقديميًا، يجد أول شكل تلقائي متعدد الأعمدة يحتوي على إطار نص، يقرء عدد الأعمدة المُكوَّن، ويكتب نص كل عمود إلى ملف منفصل. تُستبعد الأشكال التي لا توفر إطار نص.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **تحديث النص**

لتحديث النص في جميع أنحاء العرض التقديمي، كرِّر عبر الشرائح والأشكال، اختر الأشكال التلقائية، ثم حرِّر أجزاء نصها. العمل على مستوى الجزء يتيح لك تغيير كل من النص وتنسيق الأحرف.

المثال التالي يستبدل كل ظهور لكلمة `years` بـ `months` في نص الشكل التلقائي ويجعل كل جزء متأثر غامقًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

هذا التجوال يُحدِّث النص فقط في الأشكال التلقائية. النص المخزن في الجداول أو المخططات أو SmartArt أو الأشكال المجمعة يتطلب تجوال مجموعات تلك الكائنات الخاصة.

## **إضافة مربع نص مع ارتباط تشعبي**

يمكن تعيين ارتباط تشعبي إلى جزء نص محدد، بحيث يعمل ذلك الجزء فقط كرابط قابل للنقر. استخدم [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) لربط الجزء بعنوان URL خارجي.

المثال التالي ينشئ نصًا مرتبطًا ويحفظه إلى عرض تقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**ما هو الفرق بين مربع النص وعنصر النائب النصي على شريحة رئيسية أو شريحة تخطيط؟**

يمكن لـ [placeholder](/slides/ar/python-java/manage-placeholder/) أن يرث موضعه وتنسيقه من [master slide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/) أو [layout slide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/). مربع النص العادي هو شكل مستقل على الشريحة التي تم إنشاؤه فيها ولا يكتسب سلوك العنصر النائب عندما يتغير التخطيط.

**كيف يمكنني استبدال النص دون تغيير النص في المخططات أو الجداول أو SmartArt؟**

قصر التجوال على الأشكال التي هي نسخ من [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/)، كما هو موضح في مثال تحديث النص. تخزن المخططات والجداول وSmartArt النص في نماذج كائناتها الخاصة، لذا لا يتم تعديلها بواسطة تلك الحلقة.