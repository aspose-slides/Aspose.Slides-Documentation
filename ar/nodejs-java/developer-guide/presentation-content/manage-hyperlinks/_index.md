---
title: إدارة الروابط التشعبية للعرض التقديمي في JavaScript
linktitle: إدارة الروابط التشعبية
type: docs
weight: 20
url: /ar/nodejs-java/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة رابط تشعبي
- إنشاء رابط تشعبي
- تنسيق رابط تشعبي
- إزالة رابط تشعبي
- تحديث رابط تشعبي
- رابط تشعبي للنص
- رابط تشعبي للشرائح
- رابط تشعبي للشكل
- رابط تشعبي للصورة
- رابط تشعبي للفيديو
- رابط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إضافة وتنسيق وتحديث وإزالة الروابط التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java، مع أمثلة JavaScript."
---
## **المقدمة**

يُربط الرابط التشعبي محتوى العرض التقديمي بموقع ويب أو بموقع داخل العرض التقديمي. في PowerPoint، عادةً ما تخدم الروابط التشعبية هدفين:

* فتح موقع ويب من النص أو الشكل أو إطار وسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

يتيح لك Aspose.Slides for Node.js عبر Java إضافة هذه الروابط، والتحكم في مظهرها وصوتها، وتحديث خصائصها، وإزالتها. تُظهر الأمثلة أدناه كيفية العمل مع الروابط التشعبية على العناصر الفردية وكيفية الوصول إلى الروابط التشعبية على مستوى العرض التقديمي أو الشريحة أو إطار النص.

{{% alert color="info" title="Note" %}}
يمكنك أيضاً تحرير العروض التقديمية باستخدام [محرر Aspose PowerPoint المجاني على الإنترنت](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **إضافة روابط URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. العنصر الذي تُعيّن إليه الرابط التشعيبي يحدد المنطقة القابلة للنقر: يربط جزء النص النص المحدد، بينما يربط الشكل أو الإطار كائن الشريحة.

للعروض التقديمية التي تحتوي على روابط تشعبية نسبية، راجع [إدارة قاعدة الرابط التشعبي](/slides/ar/nodejs-java/presentation-properties/#manage-the-hyperlink-base) للقراءة أو التعديل أو مسح القاعدة على مستوى المستند.

### **إضافة روابط URL إلى النص**

لربط النص بموقع ويب، مرّر كائن [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) إلى طريقة [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) لجزء النص، كما هو موضح أدناه. سيصبح فقط ذلك الجزء من النص قابلًا للنقر.

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

استدعِ طريقة [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) على المستطيل لجعل كامل مساحته قابلة للنقر. استخدم [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) لعرض تلميح للقراء حول الوجهة عندما يمرّون فوق المستطيل. تُطبق كلتا الطريقتين أيضًا على إطارات الصور والصوت والفيديو.

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

## **استخدام الروابط التشعبية لإنشاء جدول محتويات**

يُستخدم المثال التالي طريقة [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) لربط نص "Page 2" في الشريحة الأولى بالشريحة الثانية.

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

## **تنسيق الروابط التشعبية**

يمكنك تغيير لون النص المرتبط، تشغيل أو إيقاف صوت عند تفعيل القارئ للرابط، وتعيين تلميح الأدوات الذي يظهر عند المرور.

### **اللون**

تحدد طريقة [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) لكائن [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) ما إذا كان الرابط التشعيبي يستخدم لون الروابط التشعبية في العرض التقديمي أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) وعيّن لون تعبئة الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات القديمة لا تطبق هذا الإعداد.

في هذا المثال، تجعل طريقة [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) الرابط الأول يستخدم تعبئة حمراء لجزء النص. الرابط الثاني يحتفظ بلون الروابط التشعبية في العرض التقديمي.

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

يمكن للرابط التشعيبي تشغيل صوت عند تفعيله أو إيقاف صوت يتم تشغيله بالفعل. استخدم الطرق التالية لتكوين هذه السلوكيات:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) يحدد ملف الصوت المرتبط بالرابط التشعيبي.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) يتحكم فيما إذا كان تفعيل الرابط التشعيبي يوقف الصوت السابق.

#### **إضافة صوت للرابط التشعيبي**

يستخدم الزر في الشريحة الأولى طريقة [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) لتشغيل الصوت من `sampleaudio.wav` عندما ينقر القارئ للتقدم. في الشريحة الثانية، يستخدم زر منفصل طريقة [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) لإيقاف التشغيل وإبقاء القارئ على تلك الشريحة.

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

#### **استخراج صوت الرابط التشعيبي**

يفتح المثال التالي العرض التقديمي الذي تم إنشاؤه أعلاه ويقرأ الصوت المرتبط بالرابط التشعبي للشكل الأول إلى الذاكرة عبر [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) و [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData).

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

### **إعدادات تلميح الأدوات والتفاعل**

يمكنك استدعاء طرق [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) التالية بعد تعيين رابط تشعبي للنص أو الشكل:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) يضبط النص الذي يمكن للمشاهد عرضه كتلميح للرابط.
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) يحدد إطار الهدف داخل مجموعة إطارات HTML الأصلية، إذا كان ذلك قابلًا للتطبيق.
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) يتحكم فيما إذا كان تفعيل الرابط يضيف هدفه إلى قائمة الروابط المشاهدة.
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) يتحكم فيما إذا كان يتم تمييز الرابط عند النقر.

## **إزالة الروابط التشعبية من العروض التقديمية**

استخدم طريقة [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) لجمع حاويات الروابط التشعبية، بما في ذلك روابط أجزاء النص، قبل تعديلها. يزيل المثال التالي كلا نوعي التفعيل من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ إما [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) أو [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); إزالة إجراء النقر لا يزيل نظره عند المرور.

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

للحذف غير المشروط، تقوم طريقة [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) بإزالة كلا نوعي التفعيل في النطاق المحدد بنداء واحد. للتنظيف الانتقائي وتغطية الرؤوس، التخطيطات، والملاحظات، راجع [تقرير، تنقية، والتحقق من الروابط التشعبية](#report-sanitize-and-verify-hyperlinks).

### **مسح الروابط التشعبية قبل استبدال نص SmartArt**

عند استبدال فقرة في عقدة SmartArt موجودة، قد يؤدي مسح أجزاء النص إلى ترك رابط قديم ساري. استخرج الفقرة عبر [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getTextFrame). قبل مسح أجزائها، استدعِ [getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) على إطار النص لشكل العقدة الذي يعرض الفقرة، ثم استدعِ [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) على الكائن المرجع. سيزيل ذلك كل الروابط التشعبية في ذلك الإطار، بما في ذلك الروابط في فقراته الأخرى.

يفترض المثال أن الشكل الثالث في الشريحة الأولى من `SmartArtHyperlink.pptx` هو رسم SmartArt. يستبدل الفقرة الأولى من العقدة الرابعة. في هذا العرض التقديمي، يعرض الشكل الأول للعقدة تلك الفقرة.

بعد إضافة كلا الجزئين، يقرأ المثال تنسيقهما الفعلي باستخدام [getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#getEffective). في ذلك التنسيق، تُعيد `getHyperlinkClick` الرابط التشعيبي الجديد للجزء الأول وتُعيد `null` للثاني.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("SmartArtHyperlink.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const smartArt = slide.getShapes().get_Item(2);
    const node = smartArt.getAllNodes().get_Item(3);
    const paragraph = node.getTextFrame().getParagraphs().get_Item(0);

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks();
    paragraph.getPortions().clear();

    const link = new aspose.slides.Portion("New reference");
    link.getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://example.com/new"));
    paragraph.getPortions().add(link);
    const text = new aspose.slides.Portion(" (updated)");
    paragraph.getPortions().add(text);

    console.log(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl()); // https://example.com/new
    console.log(text.getPortionFormat().getEffective().getHyperlinkClick()); // null
} finally {
    presentation.dispose();
}
```

## **بناء جرد كامل للروابط التشعبية**

قبل توزيع عرض تقديمي، قم بجرد إجراءات التفاعل وروابط الويب الخاصة به. تُعيد طريقة [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) حاويات الروابط التشعبية، وليس قائمة مسطحة من سلاسل URL. تفحص كلًا من [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) و [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تعرض كلا الإجراءين، لذا يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

قد يؤدي فحص الروابط التشعبية على مستوى الشكل فقط إلى فقدان الروابط المرفقة بأجزاء النص. استعلم عن النطاق المناسب بدلاً من ذلك، واحتفظ بالحاويات المرجعة لكي تتمكن لاحقًا من تحديث أو إزالة إجراءاتها.

### **استعلام عن نطاقات العرض التقديمي، الشريحة، وإطار النص**

فئة [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) متوفرة عبر [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries)، [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries)، و[TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). كل نطاق يدعم نفس الاستعلامات:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) تُعيد الحاويات التي تحتوي على إجراء نقر.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) تُعيد الحاويات التي تحتوي على إجراء تمرير الفأرة.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) تُعيد الحاويات التي تحتوي على أيٍ من الإجراءين أو كلاهما.

يعين هذا المثال إجراءات النقر والتمرير إلى شكل ونصه، وإجراء ماكرو إلى زر منفصل. يقارن عدد الحاويات التي تُعيدها طريقة [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) مع عدد الحاويات لكل نوع تفعيل. يُحسب استعلام إطار النص الروابط الموجودة في النص فقط. تظهر إجراءات الشكل المحيط في استعلامات الشريحة والعرض التقديمي.

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

في هذا المثال، يُبلغ استعلاما العرض التقديمي والشريحة عن ثلاث حاويات نقر، وحاويتين تمرير، وثلاث حاويات تحتوي على أيٍ من الإجراءين. يُبلغ استعلام إطار النص عن حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم طريقة [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) لتفسير إجراء قبل تفسير وجهته. قيم [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) تغطي أكثر من تنقل ويب:

| القيم | المعنى للتدقيق |
| --- | --- |
| `Hyperlink` | رابط تشعبي خارجي؛ افحص عنوان URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة معينة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل مدمج في عرض الشرائح، يُحل في سياق عرض الشرائح. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تنفيذ ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ راجعها منفصلًا عن عناوين URL الويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل وسائط. |
| `NoAction`, `Unknown` | لا إجراء تنقل، أو إجراء غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية من [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) والوجهات الداخلية المحددة من [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). قد لا تحتوي الإجراءات الداخلية والأوامر المدمجة على عنوان URL خارجي؛ عنوان URL فارغ لا يعني أن الحاوية لا تحتوي على إجراء. احفظ القيمة التي تُعيدها طريقة [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) عندما تختلف عن عنوان URL المُطبع، وشمل تلميح الأدوات الذي تُعيده طريقة [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) إذا كان متاحًا.

### **تقرير، تنقية، والتحقق من الروابط التشعبية**

يفتح هذا المثال العرض التقديمي من المثال السابق ويكتب سجل JSON واحد لكل إجراء. يستخدم [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) لجمع الحاويات في الشرائح العادية، والرؤوس، والتخطيطات، والملاحظات، بما في ذلك رؤوس الملاحظات والنُسخ عندما تكون موجودة. يستخدم مساواة المراجع لحساب كل حاوية مرة واحدة، يطبق السياسة الموصوفة أدناه، ويعيد فتح العرض الم保存 للتحقق من إجراءات النقر والتمرير.

يسجل التقرير فهرس الشريحة بدءًا من الواحد بواسطة [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) حيث يتوفر. تُوفر طريقة [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) الشريحة المالكة للحاويات المدعومة. لا تحتوي الرؤوس، التخطيطات، والملاحظات على فهرس شريحة عادي وتُحدد بنطاقها. تُصنف حاويات الشكل وحاويات تنسيق جزء النص بشكل منفصل؛ تحتفظ الأنواع الأخرى بأسمائها في وقت التشغيل. يحصل كل حاوية على معرف محلي في التقرير لتتبع إجراءاتها الاثنين. يخزن التقرير أنواع الإجراءات كقواميس عددية معرفة في تعداد HyperlinkActionType.

تسمح هذه السياسة التطبيقية المتعمدة الصارمة فقط بعناوين URL مطلقة عبر HTTPS وهدف شريحة داخلية صالح. ترفض الماكروز، البرامج، إجراءات الملفات، إجراءات الشرائح الأخرى، الإجراءات غير المعروفة، ومخططات URL الأخرى. هذه الرفضات هي قرارات سياسات، ليست حكمًا على أمان Aspose.Slides. HTTPS وحده لا يضمن الثقة: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. يُفحص كل من عناوين URL الأصلية والمُطبع. يقوم المثال بتدقيق البيانات الوصفية دون اتباع الروابط أو تشغيل الإجراءات.

للتصحيح، يدعم مدير الرابط التشعبي في الحاوية [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) الطرق [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick), و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). هنا، تُستبدل الروابط الخارجية الممنوعة بصفحة هبوط HTTPS ثابتة؛ وتُزال النقرات الممنوعة الأخرى وإجراءات التمرير الممنوعة بشكل مستقل. اضبط المتغيّر `replaceExternalClicks` إلى `false` لإزالة جميع مخالفات السياسة بدلاً من ذلك. اختر صفحة بديلة مملوكة للتطبيق قبل النشر.

تستخدم علم تصدير التقرير سياسة مراجعة PDF محافظة: يتم تعليم إجراءات التمرير وأي شيء آخر غير رابط خارجي أو قفزة شريحة محددة على أنه قد لا يكون مدعومًا. هذه مجرد إشارة مراجعة، ليست اختبار قدرة أو ضمان بأن الروابط غير الموسومة ستبقى عند التصدير. قد تحافظ صادرات [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/) المدعومة على الروابط التشعبية، بناءً على الإجراء، خيارات التصدير، والمستعرض. لا يمكن للـ[صور](/slides/ar/nodejs-java/convert-powerpoint-to-png/) و[فيديو](/slides/ar/nodejs-java/convert-powerpoint-to-video/) النقطية الحفاظ على الروابط التشعبية التفاعلية؛ علّم كل إجراء عند التدقيق لتلك المخرجات.

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

مع الإدخال الذي تم إنشاؤه أعلاه، يحتوي التقرير على خمسة صفوف إجراءات. تم إزالة رابط التمرير على الملف ونقر الماكرو، بينما تبقت روابط HTTPS والتنقل الداخلي بين الشرائح. تُظهر عملية التحقق عدم وجود إجراءات ممنوعة. يُظهر إدخال يحتوي على رابط نقر خارجي ممنوع أيضًا فرع الاستبدال. تحتفظ حاوية ذات نقر مسموح به وتمرير ممنوع بإجراء النقر الخاص بها.

يختلف هذا التنظيف الانتقائي عن طريقة [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) التي تُزيل كلا نوعي التفعيل في النطاق المحدد بغض النظر عن السياسة. تتحقق عملية التحقق هنا من إجراءات الروابط التشعبية فقط؛ لا تُزيل مشاريع VBA المدمجة، كائنات OLE، أو أي محتوى نشط آخر، ولا تتحقق من صحة ملف PDF أو HTML المُصدر.

## **الأسئلة الشائعة**

**كيف يمكنني الربط بقسم أو الشريحة الأولى له؟**

تقسّم الأقسام في PowerPoint الشرائح، لكن الرابط التشعبي الداخلي يستهدف شريحة فردية. لإنشاء تنقل إلى قسم، اربط إلى الشريحة الأولى في ذلك القسم.

**هل يمكنني إرفاق رابط تشعبي لعناصر الشريحة الرئيسية بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية والتخطيط الروابط التشعبية. تكون الروابط على هذه العناصر متاحة أثناء عرض الشرائح على الشرائح التي تستخدم الشريحة الرئيسية أو التخطيط المقابل.

**هل سيتم الحفاظ على الروابط التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحافظ صادرات PDF وHTML المدعومة على الروابط التشعبية؛ لا يمكن للصور النقطية والفيديو ذلك. راجع اعتبارات التصدير في [تقرير، تنقية، والتحقق من الروابط التشعبية](#report-sanitize-and-verify-hyperlinks).