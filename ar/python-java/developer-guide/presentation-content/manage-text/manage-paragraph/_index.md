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
- إدارة النقطة
- إزاحة الفقرة
- إزاحة معلقة
- نقطة الفقرة
- قائمة مرقمة
- قائمة نقطية
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
description: "تعلم كيفية إنشاء وتنسيق الفقرات، الجزءات، النقاط، القوائم المرقمة، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides for Python via Java."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يمثل النص كهرمية من إطارات النص (TextFrame) والفقرات (Paragraph) والجزءات (Portion):

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) يمثل حاوية النص داخل الشكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) يمثل فقرة واحدة في إطار النص ويوفر الوصول إلى الجزءات وتنسيق مستوى الفقرة.
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) يمثل تشغيل نص داخل الفقرة. يمكن لكل Portion أن يكون له نصه الخاص وتنسيق على مستوى الأحرف.

يمكن للفقرة إذن أن تحتوي على نص بأنماط خطوط وألوان وأحجام وتنسيقات أخرى مختلفة باستخدام عدة جزءات.

## **إنشاء وتنسيق الفقرات**

إنشاء فقرات في إطار النص الخاص بالشكل واستخدام الجزءات لتنسيق تشغيلات النص الفردية. توضح هذه القسم كيفية دمج عدة جزءات داخل كل فقرة وتطبيق ألوان مختلفة، أحجام خطوط، وأنماط.

### **إنشاء فقرات مع جزءات متعددة**

المثال التالي بلغة Python يُنشئ ثلاث فقرات، كل منها يحتوي على ثلاث تشغيلات نصية في المجموعة التي تُرجعها [Paragraph.getPortions](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getPortions). يُعيد استخدام الفقرة الافتراضية والجزء الفارغ، ثم يُضيف الفقرات والجزءات المتبقية. يتم تطبيق التنسيق عبر [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat): الجزء الأول في كل فقرة يكون أحمر، عريض، وحجم 15 نقطة؛ الثاني أزرق، مائل، وحجم 18 نقطة. الجزء الثالث يحتفظ بتنسيقه الافتراضي:

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

## **إنشاء قوائم نقطية ومرقمة**

تنظيم نص الفقرة في قوائم باستخدام رموز أو أرقام أو صور مخصصة. تغطي الأمثلة في هذا القسم تنسيق النقاط، القوائم المتعددة المستويات، وأرقام البدء المخصصة.

### **إنشاء قائمة نقطية أو مرقمة**

النقاط والترقيم يجعل العناصر ذات الصلة أسهل في المسح. في Aspose.Slides يتم تعريف إعدادات القائمة عبر [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/).

يضيف هذا المثال بلغة Python نقطة رمزية وبند مرقم إلى نفس إطار النص. [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) يحدد نوع النقطة، بينما [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) يزود الرمز و[BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) يحدد نمط الترقيم. يستخدم العنصران نقاطًا سوداء بارتفاع 100 بالمئة وإزاحة فقرة 25 نقطة:

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

### **استخدام نقاط صورة**

نقاط الصورة تتيح لك استخدام صورة مخصصة بدلاً من رمز أو رقم.

يضيف هذا المثال بلغة Python صورة إلى مجموعة صور العرض ككائن [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) ويستخدمها كنقطة للفقرة. يستدعي [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) لاستخدام نقطة صورة ويعيّن الصورة عبر [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture). يتم ضبط [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) إلى 100 بالمئة لتحديد حجم النقطة بالنسبة لنص الفقرة:

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

ضبط [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) لوضع الفقرات عند مستويات مختلفة من القائمة. المستوى العلوي له عمق `0`.

يُعيّن هذا المثال بلغة Python قيم [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) من 0 إلى 3 لأربع فقرات، مما يُنشئ هرمية داخل إطار نص واحد. كل فقرة تستخدم نقطة رمزية، مع تبديل [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) بين نقطة دائرية وشرطة لتمييز المستويات المتقاربة:

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

### **بدء عناصر القائمة المرقمة بقيم مخصصة**

استخدام [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) لتعيين الرقم الأول المعروض لفقرة مرقمة.

يُحدد هذا المثال بلغة Python [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) لاستخدام الترقيم لثلاث فقرات ويعين قيم [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) 2، 3، و7. يتم تكوين القيمة الابتدائية بشكل مستقل لكل فقرة، مما يسمح بتجاوز الأرقام للقيم المختارة:

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

ضبط هوامش الفقرة والإزاحات للتحكم في موضع السطر الأول والأسطر المتغلفة. يمكنك أيضًا تنسيق علامة نهاية الفقرة بشكل منفصل عن الجزءات النصية المرئية.

### **تعيين مسافة الإزاحة للسطرة الأولى**

استخدام طريقة [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) للتحكم في إزاحة السطر الأول للفقرة. هذا الإعداد يحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذية لجسم الفقرة.

استخدم [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) عندما تحتاج إلى تحريك الفقرة بالكامل. استخدم [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) عندما تحتاج إلى تحريك السطر الأول فقط.

يعطي المثال التالي ثلاث فقرات نفس [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) البالغ 20 نقطة و قيم [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) 0، 20، و40 نقطة. تبدأ الأسطر الأولى بإزاحات متزايدة، بينما تحتفظ الأسطر المتغلفة بنفس الهامش الأيسر:

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

![مسافة الإزاحة للسطرة الأولى للفقرات](first_line_indent.png)

### **تعيين إزاحة معلقة**

الإزاحة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides تُنشئ هذا التأثير باستخدام خاصية [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent). اضبط `Indent` على قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

في الممارسة العملية، يحدد [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) موضع الفقرة الأيسر، ويحدد [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) موضع السطر الأول بالنسبة لهذا الهامش. لإنشاء إزاحة معلقة، ضع قيمة `MarginLeft` موجبة وقيمة `Indent` سالبة.

هذا التنسيق مفيد للمراجع، القوائم المراجع، مدخلات القاموس، وغيرها من الفقرات التي يجب أن تت align الأسطر المتغلفة تحت جسم الفقرة بدلاً من تحت الحرف الأول للسطر الأول.

يربط المثال التالي بلغة Python قيم [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) 40 و60 نقطة مع قيم [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) -20 و-30 نقطة. في كل فقرة، يبدأ السطر الأول إلى اليسار من الأسطر المتغلفة؛ الفقرة الثانية لديها إزاحة معلقة أعمق:

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

![الإزاحة المعلقة للفقرات](hanging_indent.png)

### **تعيين خصائص تشغيل الفقرة النهائية**

طريقة [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) تتحكم في تنسيق علامة نهاية الفقرة. يخلق المثال التالي كائن [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) مع ضبط [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) إلى 48 نقطة و[BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont) إلى Times New Roman. يُعيّن هذا التنسيق إلى علامة نهاية الفقرة الثانية، مع ترك الجزءات النصية المرئية دون تغيير:

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

## **عدد الأسطر المعروضة**

لقواعد الفقرة التي تؤثر على التغليف التلقائي وعلامات الترقيم عند نهايات الأسطر، راجع [Control Line Breaking](/slides/ar/python-java/text-formatting/#control-line-breaking) و[Control Hanging Punctuation](/slides/ar/python-java/text-formatting/#control-hanging-punctuation).

استخدم [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) لحساب عدد الأسطر التي تشغلها الفقرة بعد تخطيط النص، بما في ذلك التغليف التلقائي. هذا مفيد عند فحص طول النص وتخطيطه في قوالب العروض التقديمية.

الفقرة هي عنصر واحد في [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs)، ويمكنها شغل عدة أسطر معروضة. كسر السطر الصريح داخل الفقرة يُجبر سطرًا جديدًا دون إنشاء فقرة جديدة. التغليف التلقائي يُنشئ أسطرًا بناءً على العرض المتاح دون إدراج كسر سطر صريح في النص. لذلك لا يعطى عدّ الفقرات أو أحرف كسر السطر عدد الأسطر المعروضة.

المثال التالي يُنشئ شكل نص، يحسب أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. يفعّل المثال التغليف باستخدام [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) ويعطّل الملاءمة التلقائية باستخدام [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) بحيث يتحكم عرض الشكل في التغليف دون تقليل حجم النص أو تعديل أبعاد الشكل تلقائيًا. كل قياس يستخدم [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount). أبعاد الشكل بالنقاط. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص:

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

مع هذا النص وهذه الأبعاد، يزيد تضييق الشكل من عدد الأسطر، بينما يقلل استبدال النص بالسلسلة القصيرة عددها. قد تختلف الأعداد الدقيقة بناءً على توفر الخطوط والاستبدال، حجم الخط، الهوامش، الإزاحات، التغليف، وإعدادات الملاءمة التلقائية. استخدم الخطوط وإعدادات التخطيط المقصودة للبيئة المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدد ما إذا كان النص يفيض عن حاويته. الارتفاع المتاح، ارتفاعات الأسطر، مسافات الفقرة والسطر، وسلوك الملاءمة التلقائية أيضًا مهم؛ حتى سطر واحد قد يتجاوز العرض المتاح عندما يكون التغليف مُعطلًا.

## **استيراد وتصدير محتوى الفقرة**

استخدم HTML لإدخال نص إلى عرض تقديمي أو تصدير فقرات موجودة للاستخدام خارج العرض. يوضح هذا القسم أيضًا كيفية عرض فقرات فردية كصور، بما في ذلك الفقرات داخل خلايا الجداول.

### **استيراد نص HTML إلى الفقرات**

استخدام [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) لتحويل ترميز HTML إلى فقرات وجزءات داخل إطار نص.

يقرأ هذا المثال بلغة Python HTML من ملف ويمرّر الترميز إلى [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml). يُمسح الفقرة الافتراضية لإطار النص بحيث يحتوي الإطار فقط على المحتوى المستورد. يترك الشكل المستطيل هامشًا قدره 10 نقاط على كل جانب من الشريحة:

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

استخدام [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) لتصدير مجموعة مختارة من الفقرات كملف HTML. عند إعادة استخدام نص العرض على موقع ويب، قد ترغب في الحفاظ على التأكيد المحلي دون نقل خط العرض، وحجمه، أو أنماط صندوق النص. اضبط [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) للتحكم إلى أي مدى يتبع المُصدّر وراثة التنسيق.

قم بتنزيل [the sample presentation](text-inheritance.pptx) وضعه في دليل العمل للتطبيق. الشريحة الأولى تحتوي على شكل نص واحد بالنص "Inherited text; explicit red 18pt". يستخدم الإدخال عمدًا عدة مستويات تنسيق:

- النمط النصي الافتراضي للعرض يزود بـ Calibri وحجم 28 نقطة.
- نمط النص من المستوى الأول لإطار النص يزود بنص أزرق ومائل.
- الفقرة تعين نصًا عريضًا صراحةً.
- الجزء الثاني، "explicit red 18pt"، يعين نصًا أحمر وحجم 18 نقطة صراحةً.

يصدر المثال الكامل التالي الفقرات نفسها ثلاث مرات. يمرّر [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/) إلى طريقة التصدير ويكتب كل نتيجة كملف HTML UTF-8 منفصل:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, TextInheritanceLimit, TextToHtmlConversionOptions

presentation = Presentation("text-inheritance.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(shape, AutoShape):
        text_frame = shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            
            modes = [TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly]
            file_names = ["All.html", "TextBox.html", "ParagraphOnly.html"]

            for mode, file_name in zip(modes, file_names):
                options = TextToHtmlConversionOptions()
                options.setTextInheritanceLimit(mode)

                html = paragraphs.exportToHtml(0, paragraphs.getCount(), options)
                try:
                    Path(file_name).write_text(str(html), encoding="utf-8")
                except OSError as exception:
                    print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

يحتوي الـ HTML المُولد على CSS التالي للجزء الأول، "Inherited text; ". تُظهر الجدول التصريحات ذات الصلة؛ تُهمل الخصائص المولدة الأخرى للتوضيح.

| الإخراج | CSS ذات الصلة للجزء الأول | المظهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، عريض، مائل بحجم 28 نقطة في Calibri، إذا كان الخط متاحًا. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، عريض، مائل؛ توفر الصفحة أو المتصفح خط العائلة والحجم. |
| `ParagraphOnly.html` | `font-weight:bold` | نص عريض؛ توفر الصفحة أو المتصفح خط العائلة، الحجم، اللون، والنمط المائل. |

الجزء الثاني يحتفظ بـ `color:#ff0000`، `font-size:18pt`، و`font-weight:bold` في جميع المخرجات الثلاث. كما يحتفظ بالمائل في `All` و`TextBox`، لكن ليس في `ParagraphOnly`. تقليص الوراثة لا يزيل التنسيق المعين صراحةً لفقرة أو جزء.

افتح الملفات في المتصفح نفسه للمقارنة. في الوضعين المقيدين، تُحل الخصائص CSS المهملة بواسطة أنماط صفحة الوجهة أو القيم الافتراضية للمتصفح، لذا يعتمد المظهر الناتج على مكان استخدام HTML.

### **عرض فقرة كصورة**

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) يعرض فقرة فردية مباشرة ويُرجع كائن صورة. احفظ النتيجة إلى ملف أو تدفق باستخدام طريقة `save`. لا تحتاج إلى عرض الشكل الحاوي أو قص صورة bitmap يدويًا.

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) قد يُعيد `None` إذا لم تُعثر على الفقرة في مجموعة الأبوين، أو لا تملك حدود عرض صالحة، أو لا يمكن عرضها. تحقق من النتيجة قبل حفظها وتخلص من الصورة المرتجعة بعد الاستخدام.

#### **عرض الفقرة بالمقياس الافتراضي**

يستخدم المثال عرضًا به شريحة واحدة حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

يختار المثال التالي الفقرة الثانية عند الفهرس 1 ويستدعي [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) دون معاملات مقياس. يتحقق من أن الشكل يحتوي على الفقرة المطلوبة وأن العرض يُرجع صورة قبل استدعاء طريقة `save` لحفظها بصيغة PNG. يُحرًّر الكتلة `finally` الصورة بعد الاستخدام.

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

#### **عرض الفقرة في خلية جدول مع التكبير**

استخدم overload لـ [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) الذي يقبل معاملات `scale_x` و`scale_y` لتحديد عوامل التكبير الأفقي والرأسي. يخلق المثال التالي جدولًا، يعرض الفقرة في خليةه الأولى بضعف العرض والارتفاع الافتراضيين، ويحفظ النتيجة كصورة PNG.

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

عامل التكبير `1` يحافظ على ذلك المحور بحجمه البكسلي الافتراضي. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، ما يُنتج أربعة أضعاف عدد البكسلات. العوامل الأكبر عمومًا تُنتج نصًا أكثر وضوحًا للتكبير أو الإخراج عالي الدقة، لكنها تزيد أيضًا من استهلاك الذاكرة وحجم الملف. العوامل دون `1` تُنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل مساوية للحفاظ على نسبة العرض إلى الارتفاع للفقرة؛ العوامل الأفقية والرأسية المختلفة تمدد المخرج بشكل مستقل.

لا يزال عرض الشكل الكامل باستخدام [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) مفيدًا عندما يجب أن يتضمن الإخراج تعبئة الشكل أو حدوده أو سياقه البصري الآخر. لعرض صورة لفقرة فقط، استخدم [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/).

## **التعليمات المتكررة**

**هل يمكنني إلغاء تمكين تغليف الأسطر بالكامل داخل إطار النص؟**

نعم. اضبط [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) لإلغاء التغليف بحيث لا تنكسر الأسطر عند حدود إطار النص.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة بدقة؟**

استخدم [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) لاسترجاع مستطيل حدود الفقرة. يوفر [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط، أو توسيط)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) هو إعداد على مستوى الفقرة ويُطبق على الفقرة بأكملها بغض النظر عن تنسيق الجزء الفردي.

لتحاذي الخطوط ذات الأحجام المختلفة داخل كل سطر عموديًا، راجع [Align Fonts Within a Line](/slides/ar/python-java/text-formatting/#align-fonts-within-a-line).

**هل يمكنني تحديد لغة التدقيق لجزء من الفقرة؟**

نعم. اضبط [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي على نص بعدة لغات.