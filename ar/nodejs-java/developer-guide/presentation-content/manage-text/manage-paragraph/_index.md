---
title: إدارة فقرات نص PowerPoint في JavaScript
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة الرصاصة
- إزاحة الفقرة
- إزاحة معلقة
- رصاصة الفقرة
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرف على كيفية إنشاء وتنسيق الفقرات، الأجزاء، العلامات النقطية، القوائم المرقمة، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

Aspose.Slides for Node.js via Java يمثل النص كهرمية من إطارات النص، الفقرات، والأجزاء:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) يمثل حاوية النص داخل الشكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) يمثل فقرة واحدة داخل إطار النص ويوفر الوصول إلى أجزائه وتنسيق الفقرة.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) يمثل تشغيل نص داخل الفقرة. يمكن لكل جزء أن يحتوي على نصه وتنسيق مستوى الأحرف الخاص به.

يمكن للفقرة بذلك أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام عدة أجزاء.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات مع عدة أجزاء**

الخطوات التالية تنشئ إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاثة أجزاء:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة كائنين آخرين من نوع [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) إلى إطار النص.
6. إضافة عدد كافٍ من كائنات [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) لكل فقرة لتحتوي على ثلاثة أجزاء. الفقرة الافتراضية تحتوي بالفعل على جزء فارغ واحد.
7. ضبط نص كل جزء.
8. تطبيق تنسيق مستوى الأحرف عبر [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/).
9. حفظ العرض المعدل.

هذا المثال بـ JavaScript يطبق الخطوات:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إنشاء قوائم نقطية ومرقمة**

### **إنشاء قائمة نقطية أو مرقمة**

تجعل النقاط والترقيم العناصر ذات الصلة أسهل في القراءة. في Aspose.Slides، يتم تعريف إعدادات القائمة عبر [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/).

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) للنقطة الرمزية.
7. ضبط [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) إلى [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) وتحديد حرف العلامة.
8. ضبط نص الفقرة، والمسافة البادئة، ولون النقطة، وارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وضبط [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) إلى [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/).
11. تكوين نمط النقطة المرقمة وإضافة الفقرة إلى إطار النص.
12. حفظ العرض.

هذا المثال بـ JavaScript ينشئ نقطة رمزية ونقطة مرقمة:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **استخدام رصاصات صورة**

تتيح لك رصاصات الصورة استخدام صورة مخصصة بدلاً من رمز أو رقم.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) والوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص به.
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة الرصاصة وإضافتها إلى مجموعة صور العرض كـ [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) وضبط نصه.
7. ضبط [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) إلى [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/).
8. تعيين الصورة عبر [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/) وضبط ارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض المعدل.

هذا المثال بـ JavaScript ينشئ رصاصة صورة:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **إنشاء قائمة متعددة المستويات**

ضبط [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) لوضع الفقرات على مستويات مختلفة من القائمة. المستوى العلوي لديه عمق `0`.

1. إنشاء [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ومسح الفقرة الافتراضية من إطار النص الخاص به.
3. إنشاء أربع فقرات وتكوين رموز نقاطها.
4. ضبط قيم [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) إلى `0`، `1`، `2`، و`3`.
5. إضافة الفقرات إلى إطار النص وحفظ العرض.

هذا المثال بـ JavaScript ينشئ قائمة نقطية بأربع مستويات:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **بدء عناصر القائمة المرقمة بقيم مخصصة**

استخدام [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) لتعيين الرقم الأول المعروض لفقرة مرقمة.

1. إنشاء [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وإضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى شريحة.
2. مسح الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات مرقمة.
4. ضبط [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) إلى `2`، `3`، و`7` لكل فقرة على حدة.
5. إضافة الفقرات إلى إطار النص وحفظ العرض.

هذا المثال بـ JavaScript يعيّن رقم بداية مخصص لكل فقرة:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحكم في تخطيط الفقرة وخصائص النهاية**

### **تعيين إزاحة السطر الأول**

استخدام [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) للتحكم في إزاحة السطر الأول للفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذاة إلى جسم الفقرة.

استخدام [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) عندما تحتاج إلى تحريك الفقرة بالكامل. استخدم [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مختلفة من [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) لتوضيح كيف تؤثر إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وضبط قيم مختلفة من [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض المعدل.

هذا الكود يُظهر كيفية ضبط إزاحة الفقرة:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الإزاحة للسطر الأول في الفقرات](first_line_indent.png)

### **تعيين إزاحة معلقة**

الإزاحة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من باقي الأسطر. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/). مرّر قيمة سالبة لتحريك السطر الأول إلى اليسار نسبياً إلى جسم الفقرة.

عمليًا، يُعرِّف [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) الموضع الأيسر لجسم الفقرة، ويُعرِّف [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) موضع السطر الأول بالنسبة لهذا الهامش. لإنشاء إزاحة معلقة، مرّر قيمة موجبة إلى `setMarginLeft` وقيمة سالبة إلى `setIndent`.

هذا التنسيق مفيد للمراجع، الفهارس، المداخل القاموسية، وغيرها من الفقرات التي يجب أن تكون الأسطر الملفوفة متراصة تحت جسم الفقرة بدلاً من تحت الحرف الأول للسطر الأول.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتمرير قيمة موجبة إلى [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) لكل فقرة.
6. تمرير قيمة سالبة إلى [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض المعدل.

هذا الكود يُظهر كيفية ضبط إزاحة معلقة لفقرة:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الإزاحة المعلقة للفقرات](hanging_indent.png)

### **تعيين خصائص تشغيل نهاية الفقرة**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) يتحكم في تنسيق علامة نهاية الفقرة. المثال التالي يعيّن حجم الخط والخط اللاتيني لعلامة نهاية الفقرة الثانية:

1. إنشاء أو تحميل [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ومسح الفقرة الافتراضية.
3. إنشاء فقرتين وإضافة أجزاء نصية إليهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. ضبط [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) و[BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. تعيين التنسيق باستخدام [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) وحفظ العرض.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إحصاء الأسطر المرسومة**

للقواعد التي تؤثر على التفاف النص التلقائي وعلامات الترقيم في نهايات الأسطر، راجع [Control Line Breaking](/slides/ar/nodejs-java/text-formatting/#control-line-breaking) و[Control Hanging Punctuation](/slides/ar/nodejs-java/text-formatting/#control-hanging-punctuation).

استخدام [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) لحساب عدد الأسطر التي يشغلها فقرة بعد تخطيط النص، بما في ذلك التفاف النص التلقائي. هذا مفيد عند فحص طول النص وتخطيطه في قوالب العروض.

الفقرة هي عنصر واحد في [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParagraphs)، ويمكن أن تشغل عدة أسطر مُرسَمة. كسر السطر الصريح داخل الفقرة يُنشئ سطرًا جديدًا دون إنشاء فقرة أخرى. التفاف النص التلقائي يُنشئ أسطرًا بناءً على العرض المتاح دون إدراج فواصل سطر صريحة في النص. لذلك لا يعطي عدّ الفقرات أو أحرف كسر السطر عدد الأسطر المرسومة.

المثال التالي ينشئ شكل نص، يحصّ عدد أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. تم تمكين الالتفاف وتعطيل الضبط التلقائي بحيث يتحكم عرض الشكل في الالتفاف دون تقليص النص تلقائيًا أو تغيير حجم الشكل. أبعاد الشكل بالوحدات النقطية. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

مع هذا النص وهذه الأبعاد، يزداد عدد الأسطر عند تضييق الشكل، بينما يقلّ العدد عند استبدال النص بالسلسلة القصيرة. قد تختلف الأعداد الدقيقة بحسب توفر الخطوط والاستبدال، حجم الخط، الهوامش، الإزاحة، الالتفاف، وإعدادات الضبط التلقائي. استخدم الخطوط وإعدادات التخطيط المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدِّد ما إذا كان النص سيتجاوز الحاوية. الارتفاع المتاح، ارتفاع الأسطر، مسافات الفقرة والسطر، وسلوك الضبط التلقائي كلها عوامل مهمة؛ حتى سطر واحد قد يتجاوز العرض المتاح عندما يكون الالتفاف معطلًا.

## **استيراد وتصدير محتوى الفقرة**

### **استيراد نص HTML إلى الفقرات**

استخدام [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) لتحويل ترميز HTML إلى فقرات وأجزاء داخل إطار النص.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بالشكل ومسح الفقرة الافتراضية.
4. تعريف أو قراءة سلسلة HTML المصدر.
5. تمرير سلسلة HTML إلى [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. حفظ العرض المعدل.

هذا المثال بـ JavaScript يستورد HTML إلى إطار نص:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تصدير نص الفقرة إلى HTML**

استخدام [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) لتصدير نطاق محدد من الفقرات كملف HTML.

1. إنشاء أو تحميل نسخة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة والعثور على [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) التي تحتوي على النص.
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
4. استدعاء [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) مع فهرس الفقرة البداية وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المرجعة إلى ملف.

هذا المثال المستقل بـ JavaScript ينشئ شكل نص ويصدّر جميع فقراته:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **رندر الفقرة كصورة**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) يرندر فقرة فردية مباشرة ويعيد كائنًا من نوع [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/). احفظ النتيجة إلى ملف باستخدام [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). لا تحتاج إلى رندر الشكل الحاوي أو قص صورة يدوياً.

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) يمكن أن يُرجع `null` إذا لم تُعثر الفقرة في مجموعة الوالد، أو لا تملك حدود رسم صالحة، أو لا يمكن رسمها. تأكد من النتيجة قبل حفظها وتحرير الصورة بعد الاستخدام.

#### **رندر الفقرة بالحجم الافتراضي**

مربع النص التالي يحتوي على ثلاث فقرات:

![مربع النص بثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يرندر الفقرة الثانية في شكل نص عادي بالحجم الافتراضي ويحفظ الصورة المرجعة بصيغة PNG. يضمن قسم `finally` تحرير الصورة بصورة صحيحة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

النتيجة:

![صورة الفقرة](paragraph_to_image_output.png)

#### **رندر الفقرة في خلية جدول مع التحجيم**

استخدام نسخة [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) التي تقبل معلمات `scaleX` و`scaleY` لتعيين عوامل التحجيم الأفقي والعمودي. المثال التالي ينشئ جدولًا، يرندر الفقرة في خليةه الأولى بعرض وارتفاع مضاعفين عن الحجم الافتراضي، ويحفظ النتيجة كصورة PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

عامل التحجيم `1` يبقي هذا المحور بحجمه الافتراضي بالبكسل. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، أي أربعة أضعاف عدد البكسلات. القيم الأكبر عادةً ما تنتج نصًا أوضح للتكبير أو للإخراج عالي الدقة، لكنها تزيد أيضًا من استهلاك الذاكرة وحجم الملف. القيم أقل من `1` تنتج صورًا أصغر بأقل تفاصيل. استخدم عوامل متساوية للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والعمودية المختلفة تقوم بتمديد الناتج بشكل مستقل.

رندر شكل كامل باستخدام [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) يظل مفيدًا عندما يحتاج الإخراج إلى تضمين تعبئة الشكل، حدوده، أو سياق بصري آخر. للحصول على صورة للفقرة فقط، استخدم [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage).

## **الأسئلة المتكررة**

**هل يمكنني تعطيل التفاف الأسطر تمامًا داخل إطار النص؟**

نعم. اضبط [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) لتعطيل الالتفاف بحيث لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة بدقة؟**

استخدم [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) لاسترجاع مستطيل الحد للفقرة. يقدم [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/#getRect) حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط أو ضبط)؟**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) هو إعداد على مستوى الفقرة وينطبق على كامل الفقرة بغض النظر عن تنسيق الأجزاء الفردية.

لمحاذاة أجزاء مختلفة الأحجام داخل كل سطر عموديًا، راجع [Align Fonts Within a Line](/slides/ar/nodejs-java/text-formatting/#align-fonts-within-a-line).

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. اضبط [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي على نص بعدة لغات.