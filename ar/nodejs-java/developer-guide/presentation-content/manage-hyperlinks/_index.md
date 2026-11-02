---
title: إدارة ارتباطات العرض التقديمي في JavaScript
linktitle: إدارة الارتباطات التشعبية
type: docs
weight: 20
url: /ar/nodejs-java/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة ارتباط تشعبي
- إنشاء ارتباط تشعبي
- تنسيق الارتباط التشعبي
- إزالة الارتباط التشعبي
- تحديث الارتباط التشعبي
- ارتباط تشعبي للنص
- ارتباط تشعبي للشريحة
- ارتباط تشعبي للشكل
- ارتباط تشعبي للصورة
- ارتباط تشعبي للفيديو
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إضافة، تنسيق، تحديث وإزالة الارتباطات التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java، باستخدام أمثلة JavaScript."
---
## **المقدمة**

يربط الارتباط التشعبي محتوى العرض التقديمي بموقع ويب أو موقع داخل العرض التقديمي. في PowerPoint، يُستخدم الارتباطات التشعبية عادةً لغرضين:
* فتح موقع ويب من النص أو الشكل أو إطار الوسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال، من جدول المحتويات.

يسمح Aspose.Slides for Node.js via Java لك بإضافة هذه الروابط، والتحكم في مظهرها وصوتها، وتحديث خصائصها، وإزالتها. تُظهر الأمثلة أدناه كيفية التعامل مع الارتباطات التشعبية على العناصر الفردية وكيفية الوصول إلى الارتباطات التشعبية على مستوى العرض التقديمي أو الشريحة أو إطار النص.

{{% alert color="info" title="Note" %}}
يمكنك أيضًا تعديل العروض التقديمية باستخدام [محرر Aspose PowerPoint المجاني عبر الإنترنت](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **إضافة ارتباطات URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. العنصر الذي تُعيّن إليه الارتباط التشعبي يحدّد المنطقة القابلة للنقر: ربط جزء النص يربط النص المحدد، بينما الشكل أو الإطار يربط كائن الشريحة.

للعروض التقديمية التي تحتوي على ارتباطات تشعبية نسبية، راجع [إدارة قاعدة الارتباط التشعبي](/slides/ar/nodejs-java/presentation-properties/#manage-the-hyperlink-base) للقراءة أو التغيير أو مسح القاعدة على مستوى المستند.

### **إضافة ارتباطات URL إلى النص**

لربط النص بموقع إلكتروني، مرّر كائن [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) إلى طريقة [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) لجزء النص، كما هو موضح أدناه. يصبح هذا الجزء فقط من النص قابلًا للنقر.

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

### **إضافة ارتباطات URL إلى الأشكال وإطارات الوسائط**

لجعل الشكل أو الإطار قابلًا للنقر، استدعِ طريقة [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) الخاصة به. ينتمي الارتباط التشعبي إلى الكائن نفسه بدلاً من جزء نص داخله.

ينطبق النهج نفسه على إطارات الصورة والصوت والفيديو: عيّن الارتباط التشعبي للإطار واستدعِ [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) إذا لزم الأمر.

المثال التالي يجعل المستطيل قابلًا للنقر:

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

## **استخدام الارتباطات التشعبية لإنشاء جدول محتويات**

تسمح الارتباطات التشعبية الداخلية للقراء بالتنقل من جدول المحتويات إلى شريحة محددة. يستخدم المثال التالي طريقة [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) لربط نص "Page 2" في الشريحة الأولى بالشريحة الثانية.

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

طريقة [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) لكائن [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) تحدد ما إذا كان الارتباط التشعبي يستخدم لون الارتباط التشعبي في العرض التقديمي أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) وعيّن لون تعبئة الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات القديمة لا تطبق هذا الإعداد.

المثال التالي يضيف ارتباطي نص إلى نفس الشريحة. الأول يستخدم تعبئة نص حمراء، بينما الثاني يحتفظ بلون الارتباط التشعبي الافتراضي.

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

يمكن للارتباط التشعبي تشغيل صوت عند التنشيط أو إيقاف صوت يتم تشغيله بالفعل. استخدم الطرق التالية لتكوين هذه السلوكيات:
- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) يحدد الصوت المرتبط بالارتباط التشعبي.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) يتحكم فيما إذا كان تنشيط الارتباط التشعبي يوقف الصوت السابق.

#### **إضافة صوت للارتباط التشعبي**

المثال التالي يحمل `sampleaudio.wav` ويربطه بزر في الشريحة الأولى. النقر على الزر يشغل الصوت وينتقل إلى الشريحة التالية. الشكل الثاني في نفس الشريحة يوقف الصوت السابق عند النقر، دون تنفيذ إجراء تنقل.

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

#### **استخراج صوت الارتباط التشعبي**

المثال التالي يفتح العرض التقديمي الذي تم إنشاؤه أعلاه ويقرأ صوت الارتباط التشعبي للشكل الأول إلى الذاكرة عبر [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) و[getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData).

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

### **الإعدادات المتعلقة بأدوات التلميح والتفاعل**

يمكنك استدعاء طرق [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) التالية بعد تعيين ارتباط تشعبي إلى نص أو شكل:
- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) يحدد النص الذي يمكن للعارض عرضه كتلميح للارتباط.
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) يحدد إطار الهدف داخل مجموعة إطارات HTML الأبوية، عند الاقتضاء.
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) يتحكم فيما إذا كان تنشيط الرابط يضيف وجهته إلى قائمة الارتباطات المشاهدة.
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) يتحكم فيما إذا كان الارتباط التشعبي يُبرز عندما يُنقر.

## **إزالة الارتباطات التشعبية من العروض التقديمية**

استخدم [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) لجمع حاويات الارتباط التشعبي، بما في ذلك روابط أجزاء النص، قبل تعديلها. المثال التالي يزيل كلا نوعي التنشيط من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ فقط [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) أو [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver)؛ إزالة إجراء النقر لا يزيل نظيره عند مرور الفأرة.

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

لإزالة غير مشروطة، [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) يزيل كلا نوعي التنشيط في النطاق المحدد في مكالمة واحدة. للتنظيف الانتقائي وتغطية الماسترز، التخطيطات، والملاحظات، راجع [تقرير، تنقية، والتحقق من الارتباطات التشعبية](#report-sanitize-and-verify-hyperlinks).

## **إنشاء جرد كامل للارتباطات التشعبية**

قبل توزيع عرض تقديمي، قم بجرد إجراءات التفاعل بالإضافة إلى روابط الويب. [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) يُرجع حاويات الارتباط التشعبي، وليس قائمة مسطحة من سلاسل URL. افحص كلًا من [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) و[getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تعرض كلا الإجراءين، لذا يحتاج التقرير الكامل إلى صفّين كحد أقصى لكل حاوية.

فحص الارتباطات على مستوى الشكل فقط قد يفوت الروابط المرفقة بأجزاء النص. استعلم عن النطاق المناسب بدلًا من ذلك، واحتفظ بالحاويات المرجعة لتتمكن لاحقًا من تحديثها أو إزالة إجراءاتها.

### **استعلام نطاقات العرض التقديمي، الشريحة، وإطار النص**

فئة [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) متاحة عبر [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries)، [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries)، و[TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). كل نطاق يدعم نفس الاستعلامات:
- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) يُرجع الحاويات التي تحتوي على إجراء نقرة.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) يُرجع الحاويات التي تحتوي على إجراء مرور الفأرة.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) يُرجع الحاويات التي تحتوي على أي من الإجراءين أو كلاهما.

المثال التالي ينشئ `hyperlink-audit-input.pptx` مع رابط نقرة خارجي، رابط ملف عند مرور الفأرة، تنقل داخلي بين الشرائح، رابط نص عند مرور الفأرة، وإجراء ماكرو. لا ينفّذ أيًا من هذه الإجراءات. الاستعلامات الثلاث نفسها تعمل في كل نطاق؛ العدّات تصف الحاويات، وليس إجمالي الإجراءات. نطاق إطار النص يستثني روابط الشكل المحيط نفسها.

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

في هذا المثال، استعلامات العرض التقديمي والشريحة كل منها يُبلغ عن ثلاث حاويات نقرة، حاويتين لمرور الفأرة، وثلاث حاويات لأي من الإجراءين. استعلام إطار النص يُبلغ عن حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) لتفسير إجراء قبل تفسير وجهته. قيم [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) تغطي أكثر من تنقل الويب:

| القيم | المعنى في التدقيق |
| --- | --- |
| `Hyperlink` | ارتباط تشعبي خارجي؛ افحص عنوان URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة معينة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل مدمج في عرض الشرائح، يُفسّر في سياق عرض الشرائح. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تنفيذ ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ راجعها منفصلًا عن عناوين URL الويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل الوسائط. |
| `NoAction`, `Unknown` | لا إجراء تنقل، أو إجراء غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية من [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) والوجهات الداخلية المحددة من [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). قد لا تحتوي الإجراءات الداخلية أو الأوامر المدمجة على URL خارجي؛ URL فارغ لا يعني أن الحاوية لا تحتوي على إجراء. حافظ على القيمة التي تُرجعها [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) عندما تختلف عن URL المُعَدل، وتضمن أداة التلميح التي تُرجعها [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) عندما تكون متاحة.

### **تقرير، تنقية، والتحقق من الارتباطات التشعبية**

المثال التالي بلغة JavaScript يقرأ عرضًا تقديميًا موجودًا (استخدم الملف الذي تم إنشاؤه أعلاه)، يكتب `hyperlink-audit.json`، يطبق سياسة، يحفظ `hyperlink-sanitized.pptx`، ويعيد فتحه للتحقق من كلا نوعي التنشيط مرة أخرى. يجمع الحاويات قبل تعديلها ويستخدم مساواة المراجع لتجنب معالجة نفس الحاوية مرتين. تغطي استعلامات العرض الشرائح العادية؛ لإنشاء جرد على مستوى الحزمة، يتم أيضًا استعلام الماسترز، التخطيطات، الملاحظات، وماسترز الملاحظات والنسخ عندما تكون موجودة.

يسجل التقرير فهرس الشريحة بقاعدة 1 و[getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) إن توفّر. [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) يوفر الشريحة المالكة للحاويات المدعومة. الماسترز، التخطيطات، والملاحظات لا تحتوي على فهرس شريحة عادي وتُحدد بنطاقها. تُسمّى حاويات الشكل وحاويات تنسيق جزء النص بشكل منفصل؛ الأنواع الأخرى تحتفظ باسم نوع الruntime الخاص بها. يُعطى كل حاوية معرف تقرير محلي لتربط إجراءيها. يخزن التقرير أنواع الإجراءات كقيم عددية ثابتة معرفّة بواسطة تعداد HyperlinkActionType.

تسمح هذه السياسة المقيدة عمدًا فقط بـ URLs HTTPS مطلقة ووجهات شرائح داخلية صالحة. تُرفض الماكروهات، البرامج، إجراءات الملفات، إجراءات عرض الشرائح الأخرى، الإجراءات غير المعروفة، ومخططات URL الأخرى. هذه الرفض قرارات سياسات، ليس حكم أمان Aspose.Slides. HTTPS وحده لا يُنشئ الثقة: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. يُفحص كل من URL الخارجي الأصلي والمُعَدل. يراجع المثال بيانات التعريف دون اتباع الروابط أو تشغيل الإجراءات.

لتصحيح الأخطاء، يدعم [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) الخاص بالحاوية [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick)، [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick)، و[removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). هنا، تُستبدل روابط النقر الخارجية غير المسموح بها بصفحة هبوط HTTPS ثابتة؛ تُزال النقرات وما فوق الفأرة غير المسموح بها بشكل مستقل. ضع `replaceExternalClicks` على `false` لإزالة جميع الانتهاكات السياسية بدلاً من ذلك. اختر صفحة استبدال مملوكة للتطبيق قبل النشر.

علم تصدير التقرير يستخدم سياسة مراجعة PDF متحفظة: يتم وضع علامة على إجراءات مرور الفأرة وأي شيء غير رابط خارجي أو قفزة إلى شريحة محددة كـ "قد لا يكون مدعومًا". إنها إشارة مراجعة، ليست اختبار قدرة أو ضمان بقاء الروابط غير المعلَّمّة بعد التصدير. قد تحافظ الصادرات المدعومة من [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/) على الارتباطات التشعبية، حسب الإجراء، خيارات التصدير، والعارض. لا يمكن للصور النقطية [images](/slides/ar/nodejs-java/convert-powerpoint-to-png/) والفيديو [video](/slides/ar/nodejs-java/convert-powerpoint-to-video/) الحفاظ على الارتباطات التشعبية؛ ضع علامة على كل إجراء عند التدقيق لهذه المخرجات.

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

مع الإدخال الذي تم إنشاؤه أعلاه، يحتوي التقرير على خمس صفوف إجراءات. يُزال رابط ملف المرور الفأرة والماكرو النقر، بينما تُحافظ روابط HTTPS والتنقل بين الشرائح الداخلية. تُطبع عملية التحقق صفر إجراءات ممنوعة. إدخال يحتوي على رابط نقر خارجي ممنوع يختبر مسار الاستبدال. حاوية ذات نقرة مسموح بها ومرور فأرة ممنوع تحتفظ بإجراء النقر الخاص بها.

هذا التنظيف الانتقائي يختلف عن [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks)، الذي يزيل كلا نوعي التنشيط في النطاق المحدد بغض النظر عن السياسة. التحقق هنا يفحص إجراءات الارتباط التشعبي فقط؛ لا يزيل مشاريع VBA المدمجة، كائنات OLE، أو محتوى نشط آخر، ولا يتحقق من ملف PDF أو HTML المُصدّر.

## **الأسئلة الشائعة**

**كيف يمكنني الربط إلى قسم أو أول شريحة له؟**

تُجَمّع الأقسام في PowerPoint الشرائح، لكن الارتباط التشعبي الداخلي يستهدف شريحة فردية. لإنشاء تنقل إلى قسم، اربط إلى أول شريحة في ذلك القسم.

**هل يمكنني إرفاق ارتباط تشعبي إلى عناصر الشريحة الرئيسية ليعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية والتخطيط الارتباطات التشعبية. تكون الروابط على هذه العناصر متاحة أثناء عرض الشرائح على الشرائح التي تستخدم الماستر أو التخطيط المقابل.

**هل سيتم الحفاظ على الارتباطات التشعبية عند تصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحافظ صادرات PDF وHTML المدعومة على الارتباطات التشعبية؛ لا يمكن للصور النقطية أو الفيديو حفظ الارتباطات التشعبية. راجع اعتبارات التصدير في [تقرير، تنقية، والتحقق من الارتباطات التشعبية](#report-sanitize-and-verify-hyperlinks).