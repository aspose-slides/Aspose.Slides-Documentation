---
title: إدارة الروابط التشعبية للعرض التقديمي في بايثون عبر جافا
linktitle: إدارة الروابط التشعبية
type: docs
weight: 20
url: /ar/python-java/manage-hyperlinks/
keywords:
  - إضافة عنوان URL
  - إضافة ارتباط تشعبي
  - إنشاء ارتباط تشعبي
  - تنسيق ارتباط تشعبي
  - إزالة ارتباط تشعبي
  - تحديث ارتباط تشعبي
  - ارتباط تشعبي للنص
  - ارتباط تشعبي للشرائح
  - ارتباط تشعبي للشكل
  - ارتباط تشعبي للصورة
  - ارتباط تشعبي للفيديو
  - ارتباط تشعبي قابل للتغيير
  - PowerPoint
  - OpenDocument
  - عرض تقديمي
  - Python
  - Java
  - Aspose.Slides
description: "إضافة وتنسيق وتحديث وإزالة الروابط التشعبية في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides للبايثون عبر جافا، مع أمثلة بايثون."
---
## **المقدمة**

يُعَدّ الارتباط التشعبي وسيلةً لربط محتوى العرض التقديمي بموقع ويب أو بموقع داخل العرض نفسه. في PowerPoint، يُستَخدم الارتباط التشعبي عادةً لغرضين:

* فتح موقع ويب من نص أو شكل أو إطار وسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول محتويات.

يتيح Aspose.Slides for Python via Java إمكانية إضافة هذه الروابط، التحكم في مظهرها وصوتها، تحديث خصائصها، وإزالتها. تُظهر الأمثلة أدناه كيفية العمل مع الارتباطات التشعبية على عناصر فردية وكيفية الوصول إلى الارتباطات على مستوى العرض أو الشريحة أو إطار النص.

{{% alert color="info" title="Note" %}}

يمكنك أيضًا تعديل العروض باستخدام [محرر Aspose PowerPoint المجاني على الإنترنت](https://products.aspose.app/slides/ar/editor).

{{% /alert %}} 

## **إضافة روابط URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. يحدد العنصر الذي تُعيّن إليه الارتباط مساحة النقر: يربط جزء النص النص المحدد، بينما يربط الشكل أو الإطار عنصر الشريحة.

### **إضافة روابط URL إلى النص**

لربط نص بموقع ويب، مرّر كائنًا من نوع [Hyperlink](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/) إلى طريقة [setHyperlinkClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/#setHyperlinkClick) لجزء النص، كما هو موضح أدناه. يصبح هذا الجزء فقط من النص قابلًا للنقر.

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

### **إضافة روابط URL إلى الأشكال وإطارات الوسائط**

لجعل شكل أو إطار قابلًا للنقر، استدعِ طريقة [setHyperlinkClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#setHyperlinkClick) الخاصة به. ينتمي الارتباط التشعبي إلى الكائن نفسه وليس إلى جزء نصي داخله.

ينطبق نفس النهج على إطارات الصور والصوت والفيديو: عيّن الارتباط إلى الإطار واستدعِ [setTooltip](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setTooltip) إذا لزم الأمر.

المثال التالي يجعل مستطيلًا قابلًا للنقر:

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

تتيح الارتباطات الداخلية للقارئ القفز من جدول المحتويات إلى شريحة محددة. يستخدم المثال التالي طريقة [setInternalHyperlinkClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) لربط نص "Page 2" في الشريحة الأولى بالشريحة الثانية.

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

### **اللون**

تحدِّد طريقة [setColorSource](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setColorSource) لكائن [Hyperlink](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/) ما إذا كان الارتباط التشعبي يستخدم لون الارتباط التشعبي في العرض أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkcolorsource/) وحدد لون تعبئة الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات الأقدم لا تطبق هذا الإعداد.

المثال التالي يضيف رابطين نصيين إلى نفس الشريحة. يستخدم الأول تعبئة نص حمراء، بينما يحتفظ الثاني بلون الارتباط التشعبي الافتراضي.

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

يمكن للارتباط التشعبي تشغيل صوت عند تفعيله أو إيقاف صوت يُشغل بالفعل. استخدم الطرق التالية لتكوين هذه السلوكيات:

- [Hyperlink.setSound](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setSound) يحدد ملف الصوت المرتبط بالارتباط.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) يتحكم فيما إذا كان تفعيل الارتباط يوقف الصوت السابق.

#### **إضافة صوت إلى الارتباط التشعبي**

المثال التالي يحمل الملف `sampleaudio.wav` ويربطه بزرٍ في الشريحة الأولى. النقر على الزر يشغل الصوت وينقلك إلى الشريحة التالية. الشكل الثاني في تلك الشريحة يوقف الصوت السابق عند النقر، دون تنفيذ أي عملية انتقال.

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

المثال التالي يفتح العرض الذي تم إنشاؤه أعلاه ويقرأ صوت الارتباط التشعبي للشكل الأول إلى الذاكرة عبر طريقتي [getSound](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#getSound) و [getBinaryData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audio/#getBinaryData).

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

### **Tooltip وإعدادات التفاعل**

يمكنك استدعاء طرق [Hyperlink](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/) التالية بعد تعيين ارتباط تشعبي إلى نص أو شكل:

- [setTooltip](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setTooltip) يحدد النص الذي يمكن للمشاهد عرضه كتلميح للارتباط.
- [setTargetFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setTargetFrame) يحدد إطار الهدف داخل مجموعة إطارات HTML أصلية، إذا كان ذلك مناسبًا.
- [setHistory](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setHistory) يتحكم فيما إذا كان تنشيط الارتباط يضيف وجهته إلى قائمة الارتباطات التي تم عرضها.
- [setHighlightClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setHighlightClick) يتحكم فيما إذا كان يتم تمييز الارتباط عند النقر.

## **إزالة الارتباطات من العروض**

استخدم [getAnyHyperlinks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) لجمع حاويات الارتباطات، بما في ذلك روابط أجزاء النص، قبل تعديلها. المثال التالي يزيل كلا نوعي التنشيط من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ فقط [removeHyperlinkClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) أو [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver)؛ إزالة إجراء النقر لا يزيل نظيره عند مرور الفأرة.

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

لإزالة غير مشروطة، تقوم طريقة [removeAllHyperlinks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) بإزالة كلا نوعي التنشيط في النطاق المحدد بندٍ واحد. للحصول على تنظيف انتقائي وتغطية الماسترات والتخطيطات والملاحظات، راجع القسم [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **إنشاء جرد كامل للارتباطات التشعبية**

قبل توزيع عرض تقديمي، قم بجرد الإجراءات التفاعلية والروابط الويب الخاصة به. تُعيد طريقة [getAnyHyperlinks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) حاويات الارتباطات، مثل كائنات [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) و[PortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/)، وليس قائمة مسطحة من سلاسل URL. افحص كل من [getHyperlinkClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getHyperlinkClick) و[getHyperlinkMouseOver](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getHyperlinkMouseOver) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تعرض كلا الإجراءين، لذلك يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

قد يتغافل الفحص على مستوى الشكل عن الروابط المرفقة بأجزاء النص. استعلم النطاق المناسب بدلاً من ذلك، واحتفظ بالحاويات التي تم إرجاعها لتتمكن لاحقًا من تحديثها أو إزالتها.

### **استعلام نطاقات العرض والشريحة وإطار النص**

فئة [HyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/) متوفرة من خلال [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getHyperlinkQueries)، [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getHyperlinkQueries)، و[TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getHyperlinkQueries). يدعم كل نطاق نفس الاستعلامات:

- [getHyperlinkClicks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) يُرجع الحاويات التي لها إجراء نقر.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) يُرجع الحاويات التي لها إجراء مرور فارة.
- [getAnyHyperlinks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) يُرجع الحاويات التي لها أي من الإجراءين أو كلاهما.

المثال التالي يُنشئ ملف `hyperlink-audit-input.pptx` يحتوي على رابط نقر خارجي، رابط مرور فارة إلى ملف، تنقل داخلي إلى شريحة، رابط مرور فارة نصي، وإجراء ماكرو. لا يتم تنفيذ أي من هذه الإجراءات. تعمل الاستعلامات الثلاثة نفسها في كل نطاق؛ الأعداد تُعطي عدد الحاويات، وليس إجمالي الإجراءات. يستثني نطاق إطار النص الروابط الخاصة بالشكل المُحيط.

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

في هذا المثال، تُظهر استعلامات العرض والشريحة ثلاثة حاويات نقر، حاويتين مرور فارة، وثلاث حاويات ذات أي إجراء. يُظهر استعلام إطار النص حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم [Hyperlink.getActionType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#getActionType) لتفسير الإجراء قبل تفسير وجهته. تغطي قيم [HyperlinkActionType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkactiontype/) ما هو أكثر من تنقل ويب:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | ارتباط خارجي؛ افحص URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة معينة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل مدمج في العرض، يُحل في سياق العرض. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تنفيذ ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ راجع منفصلًا عن عناوين URL الويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل وسائط. |
| `NoAction`, `Unknown` | لا إجراء تنقل، أو إجراء غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية عبر [getExternalUrl](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#getExternalUrl) والوجهات الداخلية المحددة عبر [getTargetSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#getTargetSlide). قد لا تحتوي الإجراءات الداخلية والأوامر المدمجة على URL خارجي؛ وجود URL فارغ لا يعني عدم وجود إجراء. احتفظ بالقيمة التي تُرجعها [getExternalUrlOriginal](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) عندما تختلف عن URL المُطبع، وضمّن التلميح الذي تُرجعه [getTooltip](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#getTooltip) إذا كان متوفرًا.

### **التقارير، التنقية، والتحقق من الارتباطات**

المثال التالي بلغة Python يقرأ عرضًا تقديميًا موجودًا (استخدم الملف الذي تم إنشاؤه أعلاه)، يكتب `hyperlink-audit.json`، يطبق سياسة، يحفظ `hyperlink-sanitized.pptx`، ثم يعيده للتحقق مرة أخرى من كلا نوعي التنشيط. يجمع الحاويات قبل تعديلها ويستخدم المساواة المرجعية لتجنب معالجة الحاوية نفسها مرتين. تغطي استعلامات العرض الشرائح العادية؛ لجرد على مستوى الحزمة بالكامل، يستعلم أيضًا صراحةً عن الماسترات، التخطيطات، الملاحظات، والماسترات الخاصة بالملاحظات والنشرات عندما تكون موجودة.

يسجل التقرير فهرس شريحة يبدأ من واحد و[getSlideId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getSlideId) حيثما كان متاحًا. تُوفر طريقة [getSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getSlide) الشريحة المالكة للحاويات المدعومة. لا تملك الماسترات، التخطيطات، والملاحظات فهرس شريحة عادي وتُحدَّد بنطاقها. تُصنَّف حاويات الشكل وتنسيق جزء النص بصورة منفصلة؛ الأنواع الأخرى تحتفظ باسم نوعها في وقت التشغيل. يحصل كل حاوية على معرف تقرير محلي لربط إجراءيه. تُخزن أنواع الإجراءات كقيم صحيحة معرفة بواسطة تعداد Java.

تسمح هذه السياسة المقيدة فقط بعناوين HTTPS مطلقة ووجهات شرائح داخلية صالحة. تُرفض الماكروهات، البرامج، إجراءات الملفات، إجراءات العرض الأخرى، الإجراءات غير المعروفة، وأي مخططات URL أخرى. هذه الرفض قرارات سياسة، ليست حكمًا على أمان Aspose.Slides. لا يضمن وجود HTTPS وحده الثقة: أضف قوائم السماح للمضيفين وفحوصات أخرى لتطبيقك. يتم فحص كل من URL الخارجي الأصلي والمطبع. لا يتبع المثال الروابط أو ينفذ الإجراءات أثناء تدقيق البيانات الوصفية.

للإصلاح، يدعم [getHyperlinkManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getHyperlinkManager) الخاص بالحاوية طرق [setExternalHyperlinkClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick)، [removeHyperlinkClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick)، و[removeHyperlinkMouseOver](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). هنا، تُستبدل روابط النقر الخارجية المحظورة بصفحة هبوط HTTPS ثابتة؛ تُزال الروابط والنقرات الممنوعة الأخرى بشكل مستقل. اضبط المتغيّر `replace_external_clicks` إلى `False` لإزالة جميع مخالفات السياسة بدلاً من ذلك. اختر صفحة استبدال مملوكة للتطبيق قبل النشر.

يستخدم علم تصدير التقرير سياسة مراجعة PDF متحفظة: يدل على إجراءات مرور الفارة وأي شيء غير الرابط الخارجي أو القفزة إلى شريحة محددة على أنه قد لا يُدعم. هذا مجرد تلميح مراجعة، وليس اختبار قدرة أو ضمان بقاء الروابط غير المُشار إليها خلال التصدير. قد تحافظ تصديرات PDF وHTML المدعومة على الارتباطات وفقًا للإجراء، خيارات التصدير، والمشاهد. لا يمكن للصور النقطية والفيديو حفظ الارتباطات التفاعلية؛ يجب الإشارة إلى كل إجراء عند التدقيق لإخراج تلك الصيغ.

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

مع المدخلات التي أنشئتها أعلاه، يحتوي التقرير على خمس صفوف إجراءات. يُزال رابط مرور الفارة للملف والماكرو من النقر، بينما تبقى الروابط HTTPS والتنقل الداخلي إلى الشرائح. تُطبع عملية التحقق صفر إجراءات ممنوعة. يُظهر الإدخال الذي يحتوي على URL نقر خارجي ممنوع فرع الاستبدال. الحاوية ذات النقر المسموح ومرور الفارة الممنوع تحتفظ بإجراء النقر.

هذا التنظيف الانتقائي يختلف عن [removeAllHyperlinks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) الذي يزيل كلا نوعي التنشيط عبر النطاق المختار بغض النظر عن السياسة. التحقق هنا يفحص إجراءات الارتباط التشعبي فقط؛ لا يزيل مشاريع VBA المضمنة، كائنات OLE، أو أي محتوى نشط آخر، ولا يتحقق من ملف PDF أو HTML المصدر.

## **الأسئلة المتكررة**

**كيف يمكنني ربط قسم أو شريحته الأولى؟**

تُجمِّع الأقسام في PowerPoint الشرائح، لكن الارتباط التشعبي الداخلي يستهدف شريحة فردية. لإنشاء تنقل إلى قسم، اربط بالشريحة الأولى في ذلك القسم.

**هل يمكنني إرفاق ارتباط تشعبي لعناصر الشريحة الرئيسية بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية والتخطيط الارتباطات التشعبية. تكون الروابط على هذه العناصر متاحة أثناء العرض على الشرائح التي تستخدم الماستر أو التخطيط المقابل.

**هل تُحافظ الارتباطات عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحافظ تصديرات PDF وHTML المدعومة على الارتباطات؛ لا يمكن للصور النقطية والفيديو حفظ الارتباطات التفاعلية. راجع اعتبارات التصدير في القسم [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).