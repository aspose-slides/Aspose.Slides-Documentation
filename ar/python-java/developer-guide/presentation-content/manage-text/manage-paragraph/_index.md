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
  - مسافة بادئة للفقرة
  - مسافة بادئة معلقة
  - نقطة الفقرة
  - قائمة مرقّمة
  - قائمة منقّطة
  - خصائص الفقرة
  - استيراد HTML
  - نص إلى HTML
  - فقرة إلى HTML
  - فقرة إلى صورة
  - نص إلى صورة
  - تصدير الفقرة
  - PowerPoint
  - عرض تقديمي
  - Python
  - Java
  - Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق الفقرات والأجزاء والرموز النقطية والقوائم المرقّمة والمسافات البادئة ومحتوى HTML وصور الفقرات باستخدام Aspose.Slides للـ Python عبر Java."
---
## **نظرة عامة**

يمثل Aspose.Slides for Python via Java النص كهرمية تتكون من إطارات النص (TextFrame) والفقرات (Paragraph) والأجزاء (Portion):

* [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) يمثل حاوية النص داخل الشكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) يمثل فقرة واحدة في إطار النص ويوفر الوصول إلى أجزائه وتنسيق مستوى الفقرة.
* [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) يمثل جزء نص داخل الفقرة. يمكن لكل جزء أن يحتوي على نصه الخاص وتنسيق الأحرف الخاص به.

وبالتالي يمكن للفقرة أن تحتوي على نص بخطوط، ألوان، أحجام وتنسيقات أخرى مختلفة باستخدام عدة أجزاء.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات متعددة الأجزاء**

الخطوات التالية تُنشئ إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاثة أجزاء:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة كائنين إضافيين من نوع [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) إلى إطار النص.
6. إضافة عدد كافٍ من كائنات [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) لكل فقرة ليحتوي على ثلاثة أجزاء. الفقرة الافتراضية تحتوي بالفعل على جزء فارغ واحد.
7. تعيين نص كل جزء.
8. تطبيق تنسيق على مستوى الأحرف عبر [Portion.getPortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getPortionFormat).
9. حفظ العرض المعدل.

هذا المثال في بايثون يُنفّذ الخطوات:

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

## **إنشاء القوائم المرقّمة والمرقّمة بالنقاط**

### **إنشاء قائمة منقّطة أو مرقّمة**

تُسهّل النقاط والترقيم مسح العناصر ذات الصلة. في Aspose.Slides تُعرّف إعدادات القائمة عبر [BulletFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/).

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى الشريحة المختارة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) لنقطة الرمز.
7. تعيين [BulletFormat.setType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/#setType) إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bullettype/#Symbol) وتحديد حرف النقطة.
8. تعيين نص الفقرة، والمسافة البادئة، ولون النقطة، وارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وتعيين [BulletFormat.setType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/#setType) إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bullettype/#Numbered).
11. تكوين نمط النقطة المرقّمة وإضافة الفقرة إلى إطار النص.
12. حفظ العرض.

هذا المثال في بايثون يُنشئ نقطة رمز ونقطة مرقّمة:

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

### **استخدام نقاط صور**

تسمح لك نقاط الصور باستخدام صورة مخصصة بدلاً من رمز أو رقم.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) والوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص به.
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة النقطة وإضافتها إلى مجموعة صور العرض كـ [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) وتعيين نصه.
7. تعيين [BulletFormat.setType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/#setType) إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bullettype/#Picture).
8. تعيين الصورة عبر [BulletFormat.getPicture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/#getPicture) وتحديد ارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض المعدل.

هذا المثال في بايثون يُنشئ نقطة صورة:

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

عيّن [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setDepth) لتحديد مستويات الفقرات في القائمة. المستوى العلوي له عمق `0`.

1. إنشاء عرض [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) ومسح الفقرة الافتراضية من إطار النص الخاص به.
3. إنشاء أربع فقرات وتكوين رموز النقاط الخاصة بها.
4. تعيين قيم [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setDepth) إلى `0` و`1` و`2` و`3`.
5. إضافة الفقرات إلى إطار النص وحفظ العرض.

هذا المثال في بايثون يُنشئ قائمة منقّطة بأربع مستويات:

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

### **بدء عناصر القائمة المرقّمة بقيم مخصصة**

استخدم [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) لتعيين الرقم الأول الظاهر للفقرة المرقّمة.

1. إنشاء عرض [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وإضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى شريحة.
2. مسح الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات مرقّمة.
4. تعيين [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) إلى `2` و`3` و`7` للفقرات المعنية.
5. إضافة الفقرات إلى إطار النص وحفظ العرض.

هذا المثال في بايثون يعيّن رقم بداية مخصص لكل فقرة:

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

### **تعيين مسافة بادئة للسطر الأول**

استخدم [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent) للتحكم في مسافة البادئة للسطر الأول من الفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذية إلى جسم الفقرة.

استخدم [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setMarginLeft) عندما تحتاج إلى تحريك الفقرة بأكملها. واستخدم [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent) عندما تريد تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبّق قيم مختلفة لـ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent) لتوضيح تأثير مسافة البادئة على تخطيط الفقرة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض المعدل.

هذا الشيفرة تُظهر كيفية تعيين مسافة بادئة للفقرة:

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

الناتج:

![مسافة البادئة للسطر الأول للفقرات](first_line_indent.png)

### **تعيين مسافة بادئة معلّقة**

المسافة البادئة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides يمكنك إنشاء هذا التأثير باستخدام [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent). مرّر قيمة سلبية لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

في الواقع، يحدد [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setMarginLeft) الموضع الأيسر لجسم الفقرة، ويحدد [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent) موضع السطر الأول بالنسبة إلى ذلك الهامش. لإنشاء مسافة بادئة معلّقة، مرّر قيمة موجبة إلى [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setMarginLeft) وقيمة سلبية إلى [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent).

هذا التنسيق مفيد في قوائم المراجع، والببليوغرافيات، ومدخلات القواميس، وغيرها من الفقرات التي يجب أن تكون الأسطر الملتفة محاذية تحت جسم الفقرة وليس تحت الحرف الأول للسطر الأول.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتمرير قيمة موجبة إلى [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setMarginLeft) لكل فقرة.
6. تمرير قيمة سلبية إلى [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setIndent) لإنشاء تأثير المسافة البادئة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض المعدل.

هذا الشيفرة تُظهر كيفية تعيين مسافة بادئة معلّقة للفقرة:

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

الناتج:

![المسافة البادئة المعلقة للفقرات](hanging_indent.png)

### **تعيين خصائص نهاية الفقرة**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) يتحكم في تنسيق علامة النهاية للفقرة. المثال التالي يعيّن حجم الخط والخط اللاتيني لعلامة النهاية في الفقرة الثانية:

1. تحميل عرض [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) ومسح الفقرة الافتراضية.
3. إنشاء فقرتين وإضافة أجزاء نصية إليهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. تعيين [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setFontHeight) و[BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setLatinFont).
6. تعيين التنسيق باستخدام [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) وحفظ العرض.

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

## **عدد الأسطر المُصورة**

للقواعد المتعلقة بالالتفاف التلقائي وعلامات الترقيم في نهاية الأسطر، راجع [Control Line Breaking](/slides/ar/python-java/text-formatting/#control-line-breaking) و[Control Hanging Punctuation](/slides/ar/python-java/text-formatting/#control-hanging-punctuation).

استخدم [Paragraph.getLinesCount](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/#getLinesCount) لعد الأسطر التي يشغلها فقرة بعد تخطيط النص، بما في ذلك الالتفاف التلقائي. هذا مفيد عند فحص طول النص وتخطيطه في قوالب العروض.

الفقرة هي عنصر واحد في [TextFrame.getParagraphs](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParagraphs)، ويمكن أن تشغل عدة أسطر مُصورة. كسر السطر الصريح داخل الفقرة يُنشئ سطرًا جديدًا دون إنشاء فقرة جديدة. الالتفاف التلقائي يخلق أسطرًا بناءً على العرض المتاح دون إدخال كسر سطر صريح في النص. لذا فإن عد الفقرات أو أحرف كسر السطر لا يعطي عدد الأسطر المُصورة.

المثال التالي يُنشئ شكل نص، يعد أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. تم تمكين الالتفاف وتعطيل الملاءمة التلقائية بحيث يتحكم عرض الشكل في الالتفاف دون تصغير النص أو تعديل حجم الشكل تلقائيًا. أبعاد الشكل بالنقاط. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

مع هذا النص وهذه الأبعاد، يزيد تضييق الشكل عدد الأسطر، بينما يقلل استبدال النص بالسلسلة القصيرة عددها. قد تختلف الأعداد الدقيقة حسب توفر الخطوط والاستبدال، وحجم الخط، والهامش، والمسافة البادئة، والالتفاف، وإعدادات الملاءمة التلقائية. استخدم الخطوط وإعدادات التخطيط المقصودة للبيئة المستهدفة عند فحص القالب.

عدد الأسطر لن يحدّ بمفرده ما إذا كان النص يخرج عن حاويته. الارتفاع المتاح، ارتفاع السطر، تباعد الفقرات والأسطر، وسلوك الملاءمة التلقائية كلها عوامل مهمة؛ حتى سطر واحد قد يتجاوز العرض المتاح إذا كان الالتفاف معطلًا.

## **استيراد وتصدير محتوى الفقرات**

### **استيراد نص HTML إلى الفقرات**

استخدم [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphcollection/#addFromHtml) لتحويل علامة HTML إلى فقرات وأجزاء داخل إطار النص.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/).
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالشكل ومسح الفقرة الافتراضية.
4. قراءة ملف HTML المصدر.
5. تمرير سلسلة HTML إلى [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. حفظ العرض المعدل.

هذا المثال في بايثون يستورد HTML إلى إطار نص:

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

استخدم [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphcollection/#exportToHtml) لتصدير نطاق محدد من الفقرات كـ HTML.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض المطلوب.
2. الوصول إلى الشريحة والعثور على [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) الذي يحتوي على النص.
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالشكل.
4. استدعاء [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphcollection/#exportToHtml) مع فهرس الفقرة الأولية وعدد الفقرات المطلوب تصديرها.
5. كتابة سلسلة HTML المُرجعة إلى ملف.

هذا المثال في بايثون يصدر جميع الفقرات من أول شكل نص:

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

### **تصيّر فقرة كصورة**

[Paragraph.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) يصيّر فقرة فردية مباشرةً ويعيد كائن صورة. احفظ النتيجة إلى ملف أو تدفق باستخدام طريقة `save`. لا تحتاج إلى تصيّر الشكل المحتوي أو قص صورة يدويًا.

يمكن أن تُعيد [Paragraph.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) القيمة `None` إذا لم تُعثر على الفقرة في مجموعة الأبوين، أو لا تملك حدود تصيّر صالحة، أو لا يمكن تصيّرها. تحقق من النتيجة قبل الحفظ وتخلّص من الصورة المُرجعة بعد الاستخدام.

#### **تصيّر فقرة بالمقياس الافتراضي**

لنفترض أن لدينا ملف عرض اسمه sample.pptx يحتوي شريحة واحدة، حيث يكون الشكل الأول صندوق نص يحتوي ثلاث فقرات.

![صندوق النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يصيّر الفقرة الثانية في شكل نص عادي بالمقياس الافتراضي ويحفظ الصورة الناتجة بصيغة PNG. يضمن القسم `finally` التخلص الصحيح من الصورة.

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

الناتج:

![صورة الفقرة](paragraph_to_image_output.png)

#### **تصيّر فقرة في خلية جدول مع تكبير/تصغير**

استخدم النسخة المتجاوزة من [Paragraph.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) التي تقبل معاملَي `scale_x` و`scale_y` لتحديد عوامل القياس الأفقي والرأسي. المثال التالي يُنشئ جدولًا، يصيّر الفقرة في خليةه الأولى بعرض وارتفاع يضاعفان القيم الافتراضية، ويحفظ النتيجة كصورة PNG.

```python
import jpype
import asposeslides

if not jpatype.isJVMStarted():
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

عامل القياس `1` يحافظ على البكسل الافتراضي للمحور. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، ما يساوي أربع مرات عدد البكسلات. القيم الأكبر عادةً ما تُنتج نصًا أدق للتكبير أو إخراج عالي الدقة، لكنها تزيد أيضًا من استهلاك الذاكرة وحجم الملف. القيم الأقل من `1` تُنتج صورًا أصغر مع تفاصيل أقل. استخدم قيمًا متساوية للحفاظ على نسبة أبعاد الفقرة؛ القيم المختلفة أفقياً وعمودياً ستمتدّ الناتج بصورة مستقلة.

تصيّر الشكل كاملًا باستخدام [Shape.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) يظل مفيدًا عندما يلزم تضمين تعبئة الشكل، حدوده، أو سياق بصري آخر. للحصول على صورة تحتوي الفقرة فقط، استخدم [Paragraph.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/).

## **الأسئلة المتكررة**

**هل يمكنني تعطيل التفاف الأسطر داخل إطار النص تمامًا؟**

نعم. عيّن [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setWrapText) لتعطيل الالتفاف بحيث لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة الدقيقة على الشريحة؟**

استخدم [Paragraph.getRect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/#getRect) لاسترداد المستطيل المحيط بالفقرة. يوفر [Portion.getRect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getRect) حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط أو ضبط)؟**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setAlignment) هو إعداد على مستوى الفقرة ويطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. عيّن [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setLanguageId) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بعدة لغات.