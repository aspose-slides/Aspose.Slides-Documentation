---
title: إدارة فقرات نص PowerPoint في Python عبر Java
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة الرمز النقطي
- إزاحة الفقرة
- إزاحة معلقة
- رمز فقرة
- قائمة مرقمة
- قائمة نقطية
- خصائص الفقرة
- استيراد HTML
- النص إلى HTML
- الفقرة إلى HTML
- الفقرة إلى صورة
- النص إلى صورة
- تصدير الفقرة
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعرّف على كيفية إنشاء وتنسيق الفقرات، القطع، الرموز النقطية، القوائم المرقمة، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides للـ Python عبر Java."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يمثل النص كهيكل هرمي يتكون من إطارات النص (TextFrame) والفقرات (Paragraph) والقطع (Portion):

* [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) يمثل حاوية النص داخل الشكل ويمنح الوصول إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) يمثل فقرة واحدة في إطار النص ويوفر الوصول إلى القطع وتنسيق الفقرة.
* [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) يمثل مجموعة نصية داخل الفقرة. يمكن لكل قطعة أن تحتوي على نصها الخاص وتنسيق الأحرف الخاص بها.

يمكن للفقرة إذًا أن تحتوي على نص بخطوط وألوان وأحجام وتنسيقات مختلفة باستخدام قطع متعددة.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات مع قطع متعددة**

الخطوات التالية تنشئ إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاث قطع:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر رقمها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. الحصول على [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة كائنين آخرين من نوع [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) إلى إطار النص.
6. إضافة ما يكفي من كائنات [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) لكل فقرة لتحتوي على ثلاث قطع. الفقرة الافتراضية تحتوي بالفعل على قطعة فارغة واحدة.
7. تعيين نص كل قطعة.
8. تطبيق تنسيق على مستوى الأحرف عبر [Portion.getPortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getPortionFormat).
9. حفظ العرض المعدل.

هذا المثال بلغة Python يطبق الخطوات:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إنشاء قوائم نقطية ورقمية**

### **إنشاء قائمة نقطية أو رقمية**

الرموز النقطية والترقيم تجعل العناصر المرتبطة أسهل للقراءة. في Aspose.Slides يتم تعريف إعدادات القائمة عبر [BulletFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/).

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر رقمها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى الشريحة المختارة.
4. الحصول على [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) لرمز نقطي.
7. تعيين [BulletFormat.setType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/#setType) إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bullettype/#Symbol) وتحديد حرف الرمز النقطي.
8. ضبط نص الفقرة والمسافة البادئة ولون الرمز وحجم الرمز.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وتعيين [BulletFormat.setType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/#setType) إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bullettype/#Numbered).
11. تكوين نمط الترقيم وإضافة الفقرة إلى إطار النص.
12. حفظ العرض.

هذا المثال بلغة Python ينشئ رمزًا نقطيًا ورقميًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **استخدام الرموز النقطية المصورة**

الرموز النقطية المصورة تسمح باستخدام صورة مخصصة بدلاً من رمز أو رقم.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر رقمها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) والحصول على [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/).
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة الرمز وإضافتها إلى مجموعة صور العرض كـ [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) وتعيين نصه.
7. تعيين [BulletFormat.setType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/#setType) إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bullettype/#Picture).
8. ربط الصورة عبر [BulletFormat.getPicture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/#getPicture) وتعيين ارتفاع الرمز.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض المعدل.

هذا المثال بلغة Python ينشئ رمزًا نقطيًا مصورًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **إنشاء قائمة متعددة المستويات**

تعيين [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setDepth) يضع الفقرات في مستويات مختلفة من القائمة. المستوى العلوي له عمق `0`.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) وإزالة الفقرة الافتراضية من إطار النص.
3. إنشاء أربع فقرات وتكوين رموزها النقطية.
4. تعيين قيم [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setDepth) لتكون `0`، `1`، `2`، و`3`.
5. إضافة الفقرات إلى إطار النص وحفظ العرض.

هذا المثال بلغة Python ينشئ قائمة نقطية بأربع مستويات:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **بدء ترقيم العناصر بقيم مخصصة**

استخدم [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) لتحديد الرقم الأول الذي سيظهر للفقرة المرقمة.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وإضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى شريحة.
2. مسح الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات مرقمة.
4. تعيين [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) إلى `2`، `3`، و`7` لكل فقرة على حدة.
5. إضافة الفقرات إلى إطار النص وحفظ العرض.

هذا المثال بلغة Python يعيّن رقم بداية مخصص لكل فقرة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحكم في تخطيط الفقرة وخصائص النهاية**

### **تعيين إزاحة السطر الأول**

استخدم [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent) للتحكم في إزاحة السطر الأول للفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر الأخرى محاذية إلى جسم الفقرة.

استخدم [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setMarginLeft) عندما تحتاج إلى تحريك الفقرة بالكامل. استخدم [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent) عندما تريد تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مختلفة لـ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent) لتوضيح تأثير إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. الحصول على [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض المعدل.

هذا الكود يوضح كيفية تعيين إزاحة للفقرة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![إزاحة السطر الأول للفقرات](first_line_indent.png)

### **تعيين إزاحة معلقة**

الإزاحة المعلقة هي تخطيط فقرة حيث يبدأ السطر الأول إلى اليسار من بقية الأسطر. في Aspose.Slides يمكنك إنشاء هذا التأثير باستخدام [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent). مرّر قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

في الواقع، يحدد [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setMarginLeft) الموضع الأيسر لجسم الفقرة، ويحدد [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent) موضع السطر الأول بالنسبة لهذا الهامش. لإنشاء إزاحة معلقة، مرّر قيمة موجبة إلى [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setMarginLeft) وقيمة سالبة إلى [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent).

هذا التنسيق مفيد للببليوغرافيا، المراجع، مدخلات القواميس، وغير ذلك من الفقرات التي يجب أن تكون الأسطر المغلّفة محاذية تحت جسم الفقرة وليس تحت الحرف الأول للسطر الأول.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. الحصول على [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة موجبة إلى [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setMarginLeft) لكل فقرة.
6. تعيين قيمة سالبة إلى [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض المعدل.

هذا الكود يوضح كيفية تعيين إزاحة معلقة للفقرة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![إزاحة معلقة للفقرات](hanging_indent.png)

### **تعيين خصائص نهاية الفقرة**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) يتحكم في تنسيق علامة النهاية للفقرة. المثال التالي يعيّن حجم الخط والخط اللاتيني لعلامة النهاية للفقرة الثانية:

1. تحميل [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) ومسح الفقرة الافتراضية.
3. إنشاء فقرتين وإضافة قطع نصية لهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. تعيين [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setFontHeight) و[BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setLatinFont).
6. ربط التنسيق باستخدام [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) وحفظ العرض.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استيراد وتصدير محتوى الفقرة**

### **استيراد نص HTML إلى الفقرات**

استخدم [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphcollection/#addFromHtml) لتحويل وسوم HTML إلى فقرات وقطع داخل إطار النص.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/).
3. الحصول على [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالشكل ومسح الفقرة الافتراضية.
4. قراءة ملف HTML المصدر.
5. تمرير سلسلة HTML إلى [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. حفظ العرض المعدل.

هذا المثال بلغة Python يستورد HTML إلى إطار نص:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **تصدير نص الفقرة إلى HTML**

استخدم [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphcollection/#exportToHtml) لتصدير نطاق مختار من الفقرات كملف HTML.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض المطلوب.
2. الوصول إلى الشريحة وإيجاد [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) الذي يحتوي على النص.
3. الحصول على [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالشكل.
4. استدعاء [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphcollection/#exportToHtml) مع فهرس الفقرة البداية وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المرجعة إلى ملف.

هذا المثال بلغة Python يصدّر جميع الفقرات من الشكل النصي الأول:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **تحويل الفقرة إلى صورة**

[Paragraph.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) يُعيد صورة للفقرة الفردية مباشرةً. احفظ النتيجة إلى ملف أو تدفق باستخدام طريقة `save`. لا تحتاج إلى تحويل الشكل المحتوي أو قص صورة يدوية.

[Paragraph.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) قد يُعيد `None` إذا لم تُعثر على الفقرة في مجموعة الأصل، أو لا توجد أبعاد عرض صالحة، أو لا يمكن عرضها. تحقق من النتيجة قبل حفظها وتأكد من تحرير الصورة بعد الاستخدام.

#### **تحويل الفقرة بالقياس الافتراضي**

نفترض أن لدينا ملف عرض يُدعى `sample.pptx` يحتوي شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يحول الفقرة الثانية داخل شكل نص عادي إلى صورة بالقياس الافتراضي ويحفظ الصورة الناتجة بصيغة PNG. يضمن القسم `finally` تحرير الصورة بشكل صحيح.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

النتيجة:

![صورة الفقرة](paragraph_to_image_output.png)

#### **تحويل الفقرة داخل خلية جدول مع تعديل المقياس**

استخدم نسخة [Paragraph.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) التي تقبل معاملَي `scale_x` و`scale_y` لتعيين عوامل المقياس الأفقي والعمودي. المثال التالي ينشئ جدولًا، يحول الفقرة في خليةه الأولى إلى عرض وارتفاع مضاعفين، ويحفظ النتيجة كصورة PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

قيمة المقياس `1` تحافظ على الحجم الافتراضي للمحور. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، ما يعني أربعة أضعاف عدد البكسلات. القيم الأكبر تعطي نصًا أكثر حدة للتكبير أو الإخراج عالي الدقة، لكنها تستهلك ذاكرة ومساحة ملف أكبر. القيم الأقل من `1` تنتج صورًا أصغر مع تفاصيل أقل. استخدم عوامل متماثلة للحفاظ على نسبة عرض الفقرة إلى ارتفاعها؛ العوامل المختلفة تمدّ العرض أو الارتفاع بشكل مستقل.

تحويل الشكل كاملًا باستخدام [Shape.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) يظل مفيدًا عندما يحتاج الإخراج إلى تعبئة الشكل أو حدوده أو سياقه البصري. للحصول على صورة للفقرة فقط، استخدم [Paragraph.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/).

## **الأسئلة المتكررة**

**هل يمكنني إلغاء تمكين التفاف النص داخل إطار النص تمامًا؟**

نعم. تعيين [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setWrapText) إلى `false` يُعطّل التفاف الأسطر بحيث لا تنكسر عند حدود إطار النص.

**كيف يمكنني الحصول على الحدود الدقيقة للفقرة على الشريحة؟**

استخدم [Paragraph.getRect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/#getRect) لاسترجاع المستطيل المحيط بالفقرة. يوفر [Portion.getRect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getRect) حدود القطعة الفردية.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، مركز أو ضبط)؟**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setAlignment) هو إعداد على مستوى الفقرة ويُطبق على الفقرة بأكملها بغض النظر عن تنسيق القطع الفردية.

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. عيّن [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setLanguageId) للقطع الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بعدة لغات.