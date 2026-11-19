---
title: إدارة ارتباطات العرض التقديمي في Python عبر Java
linktitle: إدارة الارتباطات
type: docs
weight: 20
url: /ar/python-java/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة ارتباط تشعبي
- إنشاء ارتباط تشعبي
- تنسيق ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- ارتباط تشعبي للنص
- ارتباط تشعبي للشريحة
- ارتباط تشعبي للشكل
- ارتباط تشعبي للصورة
- ارتباط تشعبي للفيديو
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إضافة وتنسيق وتحديث وإزالة الارتباطات التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر Java، مع أمثلة بلغة Python."
---
## **المقدمة**

يوفر الارتباط التشعبي ربط محتوى العرض التقديمي بموقع ويب أو بموقع داخل العرض نفسه. في PowerPoint، يُستخدم الارتباط التشعبي عادةً لهدفين:

* فتح موقع ويب من نص أو شكل أو إطار وسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

يتيح Aspose.Slides for Python via Java إضافة هذه الروابط، التحكم في مظهرها وصوتها، تحديث خصائصها، وإزالتها. تُظهر الأمثلة أدناه كيفية العمل مع الارتباطات التشعبية على العناصر الفردية وكيفية الوصول إلى الارتباطات على مستوى العرض أو الشريحة أو إطار النص.

{{% alert color="info" title="Note" %}}
يمكنك أيضًا تعديل العروض التقديمية باستخدام [محرر Aspose PowerPoint المجاني على الإنترنت](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **إضافة ارتباطات URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. يحدد العنصر الذي تُعيّن إليه الارتباط التشعبي مساحة النقر: يربط جزء النص النص المحدد، بينما يربط الشكل أو الإطار كائن الشريحة بالكامل.

للعروض التي تحتوي على ارتباطات نسبية، راجع [إدارة أساس الارتباط التشعبي](/slides/ar/python-java/presentation-properties/#manage-the-hyperlink-base) للقراءة أو التغيير أو مسح أساس المستند.

### **إضافة ارتباطات URL إلى النص**

لربط نص بموقع ويب، مرّر [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) إلى طريقة [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) لجزء النص، كما هو موضح أدناه. يصبح ذلك الجزء فقط من النص قابلاً للنقر.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إضافة ارتباطات URL إلى الأشكال وإطارات الوسائط**

استدعِ [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) على المستطيل لجعل مساحته بالكامل قابلة للنقر. استخدم [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) لعرض تلميح للقراء حول الوجهة عند تمرير الفأرة فوق المستطيل. تنطبق الطريقتان أيضًا على إطارات الصورة والصوت والفيديو.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استخدام الارتباطات لإنشاء جدول محتويات**

تسمح الارتباطات الداخلية للقارئ بالانتقال من جدول المحتويات إلى شريحة محددة. يستخدم المثال التالي [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) لربط نص “Page 2” في الشريحة الأولى إلى الشريحة الثانية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنسيق الارتباطات التشعبية**

يمكنك تغيير لون النص المرتبط، تشغيل أو إيقاف صوت عندما ينشط القارئ الرابط، وتحديد تلميح الأدوات الذي يظهر عند التمرير.

### **اللون**

تحدد طريقة [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) الخاصة بـ [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) ما إذا كان الارتباط التشعبي يستخدم لون الارتباط في العرض أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) وحدد لون ملء الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات القديمة لا تطبق هذا الإعداد.

في هذا المثال، تجعل [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) الرابط الأول يستخدم ملء الجزء باللون الأحمر. يبقى الرابط الثاني يستخدم لون الارتباط في العرض.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **الصوت**

يمكن للارتباط التشعبي أن يشغّل صوتًا عند تنشيطه أو يوقف صوتًا يتم تشغيله بالفعل. استخدم الطرق التالية لضبط هذه السلوكيات:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) يحدد الصوت المرتبط بالارتباط التشعبي.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) يتحكم فيما إذا كان تنشيط الارتباط يوقف الصوت السابق.

#### **إضافة صوت للارتباط التشعبي**

يستخدم الزر في الشريحة الأولى [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) لتشغيل الصوت من `sampleaudio.wav` عندما ينقر القارئ للتقدم. في الشريحة الثانية، يستخدم زر منفصل [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) لإيقاف التشغيل وإبقاء القارئ على تلك الشريحة.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **استخلاص صوت الارتباط التشعبي**

يفتح المثال التالي العرض الذي تم إنشاؤه أعلاه ويقرأ صوت الارتباط التشعبي للشكل الأول إلى الذاكرة عبر [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) و[getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **تلميح الأدوات وإعدادات التفاعل**

يمكنك استدعاء طرق [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) التالية بعد تعيين ارتباط تشعبي إلى نص أو شكل:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) يحدد النص الذي يمكن للمشاهד عرضه كتلميح للارتباط.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) يحدد إطار الهدف داخل مجموعة إطارات HTML، إذا كان ذلك مناسبًا.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) يتحكم فيما إذا كان تنشيط الارتباط يضيف وجهته إلى قائمة الروابط التي تم عرضها.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) يتحكم فيما إذا كان يُبرز الارتباط عند النقر.

## **إزالة الارتباطات من العروض**

استخدم [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) لتجميع حاويات الارتباطات، بما في ذلك روابط أجزاء النص، قبل تعديلها. يزيل المثال التالي كلا نوعي التنشيط من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ فقط [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) أو [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver)؛ إزالة إجراء النقر لا يُزيل نظيره عند مرور الفأرة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

لإزالة غير مشروطة، تقوم [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) بإزالة كلا النوعين في النطاق المحدد بنداء واحد. للقيام بتنظيف انتقائي وتغطية الماسترز، التخطيطات، والملاحظات، راجع [الإبلاغ، التنقية، والتحقق من الارتباطات](#report-sanitize-and-verify-hyperlinks).

### **مسح الارتباطات قبل استبدال نص SmartArt**

عند استبدال فقرة في عقدة SmartArt موجودة، قد يترك مسح أجزائها رابطًا قديمًا ساريًا. استخرج الفقرة عبر [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getTextFrame). قبل مسح أجزائها، استدعِ [getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) على إطار النص لشكل العقدة الذي يعرض الفقرة، ثم استدعِ [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) على الكائن المرتجع. يزيل ذلك كل الارتباطات في ذلك الإطار، بما في ذلك الروابط في فقراته الأخرى.

يفترض المثال أن الشكل الثالث في الشريحة الأولى من `SmartArtHyperlink.pptx` هو رسم SmartArt. وهو يستبدل الفقرة الأولى من العقدة الرابعة. في هذا العرض، يعرض الشكل الأول للعقدة تلك الفقرة.

بعد إضافة كلا الجزأين، يقرأ المثال تنسيقهما الفعلي عبر [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective). على ذلك التنسيق، تُعيد `getHyperlinkClick` الارتباط الجديد للجزء الأول وتُعيد `None` للثاني.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Portion, Presentation

presentation = Presentation("SmartArtHyperlink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    smart_art = slide.getShapes().get_Item(2)
    node = smart_art.getAllNodes().get_Item(3)
    paragraph = node.getTextFrame().getParagraphs().get_Item(0)

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks()
    paragraph.getPortions().clear()

    link = Portion("New reference")
    link.getPortionFormat().setHyperlinkClick(Hyperlink("https://example.com/new"))
    paragraph.getPortions().add(link)
    text = Portion(" (updated)")
    paragraph.getPortions().add(text)

    print(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl())  # https://example.com/new
    print(text.getPortionFormat().getEffective().getHyperlinkClick())  # None
finally:
    presentation.dispose()
```

## **إنشاء جرد كامل للارتباطات**

قبل توزيع عرض تقديمي، قم بجرد تفاعلاته الروابطية بالإضافة إلى روابط الويب. تُعيد [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) حاويات الارتباط، مثل كائنات [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) و[PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/)، وليست قائمة مسطحة من عناوين URL. فحص كل من [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) و[getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تعرض كلا الإجراءين، لذا يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

قد يغفل الفحص على مستوى الشكل الروابط المرتبطة بأجزاء النص. استعلم النطاق المناسب بدلاً من ذلك، واحتفظ بالحاويات المرتجعة لتتمكن لاحقًا من تحديثها أو إزالتها.

### **استعلام نطاقات العرض، الشريحة، وإطار النص**

فئة [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) متوفرة عبر [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries)، [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries)، و[TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries). يدعم كل نطاق نفس الاستعلامات:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) يُعيد الحاويات التي لها إجراء نقر.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) يُعيد الحاويات التي لها إجراء مرور بالفأرة.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) يُعيد الحاويات التي لها أي من الإجراءين أو كلاهما.

يعين هذا المثال إجراءات النقر والمرور بالفأرة إلى شكل ونصه، وإجراء ماكرو إلى زر منفصل. يقارن عدد الحاويات التي تُعيدها [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) مع عدد كل نوع من الإجراءات. يُظهر استعلام إطار النص عدد الروابط في النص فقط. تظهر إجراءات الشكل الخاصة في استعلامي الشريحة والعرض.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

في هذا المثال، يُرجع كل من استعلامات العرض والشريحة ثلاثة حاويات نقر، وحاويتين مرور بالفأرة، وثلاث حاويات إما أو كلا الإجراءين. يُرجع استعلام إطار النص حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) لتفسير الإجراء قبل تفسير الوجهة. تغطي قيم [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) ما يزيد عن التنقل عبر الويب:

| القيم | المعنى للتدقيق |
| --- | --- |
| `Hyperlink` | ارتباط تشعبي خارجي؛ افحص URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة محددة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل مدمج في عرض الشرائح، يُحل في سياق العرض. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تنفيذ ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ راجع منفصلًا عن عناوين الويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل وسائط. |
| `NoAction`, `Unknown` | لا يوجد إجراء تنقّل، أو إجراء غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية عبر [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) والوجهات الداخلية المحددة عبر [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide). قد لا تمتلك الإجراءات الداخلية أو الأوامر المدمجة URL خارجيًا؛ فإن URL فارغ لا يعني أن الحاوية لا تملك إجراءً. احفظ القيمة التي تُعيدها [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) عندما تختلف عن URL المُطبع، وضمّن تلميح الأدوات الذي تُعيده [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) إذا كان متوفرًا.

### **الإبلاغ، التنقية، والتحقق من الارتباطات**

يفتح هذا المثال العرض من المثال السابق ويكتب سجل JSON واحد لكل إجراء. يستخدم [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) لتجميع الحاويات على الشرائح العادية، والماستر، والتخطيطات، والملاحظات، بما في ذلك ماستر الملاحظات والنسخ عندما تكون موجودة. يستخدم مساواة المراجع لحساب كل حاوية مرة واحدة، يطبق السياسة المبيّنة أدناه، ثم يعيد فتح العرض المحفوظ للتحقق من كل من إجراءات النقر والمرور بالفأرة.

يسجل التقرير فهرس الشريحة (بدءًا من واحد) و[getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) عندما يكون متوفرًا. يُوفر [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) الشريحة المالكة للحاويات المدعومة. لا تمتلك الماسترز، التخطيطات، والملاحظات فهرس شريحة عادي وتُحدَّد بنطاقها. تُصنَّف حاويات الشكل وتنسيق جزء النص بشكل منفصل؛ تحتفظ الأنواع الأخرى باسم نوعها في وقت التشغيل. يحصل كل حاوية على معرف محلي في التقرير لتُربط إجراءً به.

تسمح سياسة التطبيق المقيدة هذه فقط بعناوين URL مطلقة HTTPS ووجهات شريحة داخلية صالحة. تُرفض الماكروز، البرامج، إجراءات الملفات، إجراءات عرض الشرائح الأخرى، الإجراءات غير المعروفة، ومخططات URL الأخرى. هذه الرفضات قرارات سياسة، ليست حكمًا على أمان Aspose.Slides. لا يضمن HTTPS وحده الثقة: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. تُفحص كل من URL الخارجي الأصلي والـ URL المُطبع. لا يتبع المثال الروابط أو ينفّذ الإجراءات أثناء تدقيق البيانات الوصفية.

للتصحيح، يدعم [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) الخاص بالحاوية [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick)، [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick)، و[removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). هنا، تُستبدل الروابط الخارجية غير المسموح بها بصفحة هبوط HTTPS ثابتة؛ تُزال النقرات غير المسموح بها وإجراءات المرور بالفأرة غير المسموح بها بشكل مستقل. اضبط `replace_external_clicks` إلى `False` لإزالة جميع المخالفات بدلاً من ذلك. اختر صفحة استبدال مملوكة للتطبيق قبل النشر.

تستخدم علامة تصدير التقرير سياسة مراجعة PDF متحفظة: علم إجراءات المرور بالفأرة وأي شيء غير رابط خارجي أو قفزة شريحة محددة على أنه قد لا يكون مدعومًا. إنها تلميح مراجعة، ليست اختبار قدرة أو ضمان بقاء الروابط غير المؤشرة بعد التصدير. قد تحتفظ تصديرات PDF وHTML المدعومة [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/python-java/convert-powerpoint-to-html/) بالارتباطات، حسب الإجراء، خيارات التصدير، والمشاهد. لا يمكن للصور النقطية [images](/slides/ar/python-java/convert-powerpoint-to-png/) والفيديو [video](/slides/ar/python-java/convert-powerpoint-to-video/) الحفاظ على الارتباطات التفاعلية؛ علم كل إجراء عند التدقيق لهذه المخرجات.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

مع الإدخال الذي تم إنشاؤه أعلاه، يحتوي التقرير على خمسة صفوف إجراءات. يُزال رابط مرور الفأرة في الملف والماكرو النقر، بينما تُبقى روابط HTTPS والتنقل الداخلي. تُظهر عملية التحقق عدم وجود إجراءات محظورة. يُظهر إدخال يحتوي على URL نقر خارجي محظور أيضًا فرع الاستبدال. يحتفظ حاوية ذات نقر مسموح به ومرور بالفأرة غير مسموح به بإجراء النقر.

هذه التنقية الانتقائية تختلف عن [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)، التي تُزيل كلا النوعين في النطاق المحدد بغض النظر عن السياسة. تتحقق عملية التحقق هنا من إجراءات الارتباط فقط؛ لا تُزيل المشاريع المدمجة VBA، كائنات OLE، أو محتوى نشط آخر، ولا تتحقق من صحة ملف PDF أو HTML المصدر.

## **الأسئلة الشائعة**

**كيف يمكنني ربط قسم أو شريحته الأولى؟**

تُجمّع الأقسام في PowerPoint الشرائح، لكن الارتباط الداخلي يستهدف شريحة واحدة. لإنشاء تنقل إلى قسم، اربط إلى الشريحة الأولى في ذلك القسم.

**هل يمكنني إرفاق ارتباط تشعبي لعناصر الشريحة الرئيسية بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية والتخطيط الارتباطات التشعبية. تكون الروابط على هذه العناصر متاحة أثناء عرض الشرائح على الشرائح التي تستخدم الماستر أو التخطيط المقابل.

**هل ستُحفظ الارتباطات عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحتفظ تصديرات PDF وHTML المدعومة بالارتباطات؛ لا يمكن للصور النقطية والفيديو حفظ الارتباطات التفاعلية. راجع اعتبارات التصدير في [الإبلاغ، التنقية، والتحقق من الارتباطات](#report-sanitize-and-verify-hyperlinks).