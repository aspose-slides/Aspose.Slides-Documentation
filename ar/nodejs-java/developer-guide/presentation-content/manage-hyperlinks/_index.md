---
title: إدارة ارتباطات العرض التقديمي في JavaScript
linktitle: إدارة الارتباطات
type: docs
weight: 20
url: /ar/nodejs-java/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة ارتباط تشعبي
- إنشاء ارتباط تشعبي
- تنسيق ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- ارتباط تشعبي نصي
- ارتباط تشعبي شريحة
- ارتباط تشعبي شكل
- ارتباط تشعبي صورة
- ارتباط تشعبي فيديو
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إضافة وتنسيق وتحديث وإزالة الارتباطات التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java، باستخدام أمثلة JavaScript."
---
## **المقدمة**

يصل الارتباط التشعبي محتوى العرض التقديمي بموقع ويب أو بموقع داخل العرض نفسه. في PowerPoint، عادةً ما يخدم الارتباط التشعبي هدفين:

* فتح موقع ويب من نص أو شكل أو إطار وسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول محتويات.

تتيح لك Aspose.Slides for Node.js via Java إضافة هذه الروابط، التحكم في مظهرها وصوتها، تحديث خصائصها، وإزالتها. تُظهر الأمثلة أدناه كيفية العمل بالارتباطات التشعبية على عناصر فردية وكيفية الوصول إلى الارتباطات على مستوى العرض أو الشريحة أو إطار النص.

{{% alert color="info" title="ملاحظة" %}}
يمكنك أيضًا تعديل العروض التقديمية باستخدام [محرر Aspose PowerPoint المجاني على الإنترنت](https://products.aspose.app/slides/ar/editor).
{{% /alert %}} 

## **إضافة روابط URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. العنصر الذي تُعين إليه الارتباط التشعبي يحدد منطقة النقر: الجزء النصي يربط النص المحدد، بينما الشكل أو الإطار يربط كائن الشريحة.

### **إضافة روابط URL إلى النص**

لربط نص بموقع ويب، مرّر كائن [Hyperlink](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink) إلى طريقة [setHyperlinkClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) الخاصة بقطعة النص، كما هو موضح أدناه. يصبح هذا الجزء فقط من النص قابلًا للنقر.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **إضافة روابط URL إلى الأشكال وإطارات الوسائط**

لجعل شكل أو إطار قابل للنقر، استدعِ طريقة [setHyperlinkClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Shape#setHyperlinkClick) الخاصة به. الارتباط التشعبي ينتمي إلى الكائن نفسه وليس إلى جزء نص داخل الكائن.

ينطبق نفس النهج على إطارات الصور والصوت والفيديو: عيّن الارتباط التشعبي للإطار واستدعِ طريقة [setTooltip](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#setTooltip) إذا لزم الأمر.

المثال التالي يجعل مستطيلًا قابلًا للنقر:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استخدام الارتباطات لإنشاء جدول محتويات**

تسمح الارتباطات الداخلية للقراء بالانتقال من جدول المحتويات إلى شريحة معينة. يستخدم المثال التالي طريقة [setInternalHyperlinkClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) لربط النص “Page 2” في الشريحة الأولى بالشريحة الثانية.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنسيق الارتباطات التشعبية**

### **اللون**

تحدد طريقة [setColorSource](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#setColorSource) لكائن [Hyperlink](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink) ما إذا كان الارتباط التشعبي يستخدم لون الارتباطات في العرض أو تنسيق قطعة النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkColorSource) واضبط لون تعبئة القطعة. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات الأقدم لا تطبق هذا الإعداد.

المثال التالي يضيف رابطين نصيين إلى نفس الشريحة. الأول يستخدم تعبئة نص حمراء، بينما الثاني يبقى بلون الارتباط الافتراضي.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **الصوت**

يمكن للارتباط التشعبي تشغيل صوت عند تفعيله أو إيقاف صوت جارٍ. استخدم الطرق التالية لتكوين هذه السلوكيات:

- [Hyperlink.setSound](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#setSound) يحدد ملف الصوت المرتبط بالارتباط.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) يتحكم فيما إذا كان تنشيط الارتباط يوقف الصوت السابق.

#### **إضافة صوت للارتباط التشعبي**

المثال التالي يحمل الملف `sampleaudio.wav` ويربطه بزر في الشريحة الأولى. النقر على الزر يشغل الصوت وينتقل إلى الشريحة التالية. الشكل الثاني في نفس الشريحة يوقف الصوت السابق عند النقر دون تنفيذ إجراء تنقل.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **استخراج صوت للارتباط التشعبي**

المثال التالي يفتح العرض الذي تم إنشاؤه أعلاه ويقرأ صوت الارتباط التشعبي للشكل الأول إلى الذاكرة عبر [getSound](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#getSound) و[getBinaryData](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Audio#getBinaryData).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **التلميحات وإعدادات التفاعل**

يمكنك استدعاء طرق [Hyperlink](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink) التالية بعد تعيين ارتباط تشعبي إلى نص أو شكل:

- [setTooltip](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#setTooltip) يحدد النص الذي يمكن للمشاهد عرضه كتلميح للارتباط.
- [setTargetFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) يحدد إطار الهدف داخل مجموعة إطارات HTML إذا كان ذلك مناسبًا.
- [setHistory](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#setHistory) يتحكم فيما إذا كان تنشيط الارتباط يضيف وجهته إلى قائمة الارتباطات التي تم مشاهدتها.
- [setHighlightClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) يتحكم فيما إذا كان الارتباط يبرز عند النقر.

## **إزالة الارتباطات من العروض التقديمية**

استخدم طريقة [getAnyHyperlinks](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) لجمع حاويات الارتباطات، بما في ذلك روابط قطع النص، قبل تعديلها. المثال التالي يزيل كلا نوعي التنشيط من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ فقط [removeHyperlinkClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) أو [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver)؛ إزالة إجراء النقر لا يزيل نظيره عند مرور الفأرة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

لإزالة غير مشروطة، تقوم طريقة [removeAllHyperlinks](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) بحذف كلا نوعي التنشيط في النطاق المحدد بندرة واحدة. للحصول على تنظيف انتقائي وتغطية الماسترز والتخطيطات والملاحظات، راجع قسم [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **إنشاء جرد كامل للارتباطات التشعبية**

قبل توزيع العرض، قم بجرد الإجراءات التفاعلية بالإضافة إلى الروابط الويب. تُعيد طريقة [getAnyHyperlinks](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) حاويات الارتباطات، وليس قائمة مسطحة من سلاسل URL. افحص كل من [getHyperlinkClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Shape#getHyperlinkClick) و[getHyperlinkMouseOver](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تعرض كلا الإجراءين، لذا يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

قد يؤدي فحص الارتباطات على مستوى الشكل فقط إلى فقدان الروابط المرفقة بقطع النص. استعلم عن النطاق المناسب بدلًا من ذلك، واحتفظ بالحاويات المرجعة لتتمكن لاحقًا من تحديثها أو إزالتها.

### **استعلام نطاقات العرض والشريحة وإطار النص**

فئة [HyperlinkQueries](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkQueries) متاحة عبر [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries)، [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries)، و[TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). يدعم كل نطاق نفس الاستعلامات:

- [getHyperlinkClicks](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) يُعيد الحاويات التي تحتوي على إجراء نقر.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) يُعيد الحاويات التي تحتوي على إجراء مرور الفأرة.
- [getAnyHyperlinks](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) يُعيد الحاويات التي تحتوي على أحد الإجراءين أو كليهما.

المثال التالي ينشئ ملف `hyperlink-audit-input.pptx` يحتوي على رابط نقر خارجي، رابط مرور ملف، تنقل شريحة داخلي، رابط مرور نص، وإجراء ماكرو. لا يتم تنفيذ أي من هذه الإجراءات. تعمل الاستعلامات الثلاثة في كل نطاق؛ الأعداد تشير إلى الحاويات، وليس إلى مجموع الإجراءات. يستثني نطاق إطار النص الروابط الخاصة بالشكل المحيط.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في هذا المثال، تقارير استعلامات العرض والشريحة تُظهر ثلاث حاويات نقر، حاويتين مرور، وثلاث حاويات لديها أي إجراء. استعلام إطار النص يُظهر حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم طريقة [Hyperlink.getActionType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#getActionType) لتفسير الإجراء قبل تفسير وجهته. تغطي قيم [HyperlinkActionType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkActionType) ما يتجاوز التنقل الويب:

| القيم | المعنى عند التدقيق |
| --- | --- |
| `Hyperlink` | ارتباط تشعبي خارجي؛ افحص URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة محددة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل مدمج في عرض الشرائح، يُفسر في سياق العرض. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تنفيذ ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ راجه بشكل منفصل عن عناوين URL الويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل وسائط. |
| `NoAction`, `Unknown` | لا يوجد إجراء تنقل، أو إجراء غير معروف يحتاج إلى مراجعة. |

اقرأ الوجهات الخارجية عبر [getExternalUrl](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) والوجهات الداخلية المحددة عبر [getTargetSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). قد لا تحتوي الإجراءات الداخلية والأوامر المدمجة على URL خارجي؛ فارغ الـ URL لا يعني أن الحاوية لا تحمل إجراءً. احتفظ بالقيمة التي تُعيدها [getExternalUrlOriginal](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) عندما تختلف عن الـ URL المُعَدل، وضم التلميح الذي تُعيده [getTooltip](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Hyperlink#getTooltip) إذا كان متاحًا.

### **التقرير، التنقية، والتحقق من الارتباطات**

المثال التالي بلغة JavaScript يقرأ عرضًا مُوجودًا (استخدم الملف الذي تم إنشاؤه أعلاه)، يكتب `hyperlink-audit.json`، يطبق سياسة، يحفظ `hyperlink-sanitized.pptx`، ثم يفتحه مرة أخرى للتحقق من كلا نوعي التنشيط. يجمع الحاويات قبل تعديلها ويستخدم المساواة المرجعية لتجنب معالجة نفس الحاوية مرتين. تغطي استعلامات العرض الشرائح العادية؛ لجرد على مستوى الحزمة، يتم استعلام الماسترز، التخطيطات، الملاحظات، وماستر الملاحظات والملفّات عندما تكون موجودة.

يسجل التقرير فهرس الشريحة بدءًا من واحد و[getSlideId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/BaseSlide#getSlideId) حيثما توفّر. تُوفر طريقة [getSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Shape#getSlide) الشريحة المالكة للحاويات المدعومة. لا تحتوي الماسترز والتخطيطات والملاحظات على فهرس شريحة عادي وتُعرّف بنطاقها. تُصنّف حاويات الشكل وحاويات تنسيق قطع النص بشكل منفصل؛ تحتفظ الأنواع الأخرى بأسمائها النوعية وقت التشغيل. يحصل كل حاوية على معرف محلي داخل التقرير لربط الإجراءين معًا. تُخزن أنواع الإجراءات كقِيَم صحيحة من تعداد HyperlinkActionType.

تسمح هذه السياسة التقييدية فقط بعناوين URL مطلقة عبر HTTPS ووجهات شرائح داخلية صالحة. تُرفض الماكروهات، البرامج، إجراءات الملفات، إجراءات عرض الشرائح الأخرى، الإجراءات غير المعروفة، وأنواع URL أخرى. هذه الرفضات هي قرارات سياسة، لا حكم أمان من Aspose.Slides. لا يضمن وجود HTTPS وحده الثقة: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. تُفحص كل من URL الخارجية الأصلية والمُعدَّلة. يجري التدقيق على البيانات الوصفية دون اتباع الروابط أو تشغيل الإجراءات.

للتصحيح، يدعم [getHyperlinkManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Shape#getHyperlinkManager) الخاص بالحاوية طرق [setExternalHyperlinkClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick)، [removeHyperlinkClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick)، و[removeHyperlinkMouseOver](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). هنا، تُستبدل الروابط الخارجية غير المسموح بها بصفحة هبوط HTTPS ثابتة؛ تُزال باقي النقرات غير المسموح بها وإجراءات المرور على الفأرة بشكل مستقل. ضع `replaceExternalClicks` على `false` لإزالة كافة الانتهاكات بدلاً من ذلك. اختر صفحة بديلة مملوكة لتطبيقك قبل النشر.

تُعلم علامة تصدير التقرير بسياسة مراجعة PDF محافظة: تُعلَّم إجراءات المرور على الفأرة وأي شيء غير الرابط الخارجي أو القفزة إلى شريحة محددة على أنه قد لا يدعم التصدير. ليست هذه إشارة إلى قدرة أو ضمان أن الروابط غير المعلمة ستبقى بعد التصدير. قد تحتفظ تصديرات PDF وHTML المدعومة بـ [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/) بالارتباطات حسب الإجراء وخيارات التصدير والمستعرض. لا يمكن للصور النقطية [images](/slides/ar/nodejs-java/convert-powerpoint-to-png/) والفيديو [video](/slides/ar/nodejs-java/convert-powerpoint-to-video/) الاحتفاظ بالارتباطات التفاعلية؛ علم كل إجراء عند التدقيق لهذه المخرجات.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

مع الإدخال المُنشأ أعلاه، يحتوي التقرير على خمس صفوف إجراءات. يُزال رابط مرور الملف والماكرو النقر، بينما تبقى روابط HTTPS والتنقل الداخلي. تُظهر عملية التحقق عدم وجود إجراءات محظورة. يُظهر الإدخال الذي يحتوي على رابط نقر خارجي محظور أيضًا فرع الاستبدال. تحتفظ حاوية ذات نقر مسموح وبمرور غير مسموح به بإجراء النقر فقط.

هذا التنظيف الانتقائي يختلف عن طريقة [removeAllHyperlinks](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) التي تُزيل كلا نوعي التنشيط في النطاق المحدد بغض النظر عن السياسة. التحقق هنا يفحص إجراءات الارتباط فقط؛ لا يزيل مشاريع VBA المضمّنة، كائنات OLE، أو أي محتوى نشط آخر، ولا يُصَحّح ملف PDF أو HTML مُصدّر.

## **الأسئلة المتكررة**

**كيف يمكنني الربط بقسم أو أول شريحة له؟**

تُجَمّع الأقسام في PowerPoint شرائحًا، لكن الارتباط التشعبي الداخلي يستهدف شريحة فردية. لإنشاء تنقل إلى قسم، اربط إلى أول شريحة في ذلك القسم.

**هل يمكنني إلحاق ارتباط تشعبي بعناصر الشريحة الرئيسة ليعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسة والتخطيط الارتباطات التشعبية. تكون الروابط على هذه العناصر متاحة أثناء عرض الشرائح على الشرائح التي تستخدم الماستر أو التخطيط المقصود.

**هل سيتم الحفاظ على الارتباطات عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحافظ تصديرات PDF وHTML المدعومة على الارتباطات؛ ولا يمكن للصور النقطية والفيديو الاحتفاظ بالارتباطات التفاعلية. راجع اعتبارات التصدير في قسم [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).