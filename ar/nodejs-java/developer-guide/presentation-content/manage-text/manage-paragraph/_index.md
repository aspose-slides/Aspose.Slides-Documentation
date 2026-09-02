---
title: إدارة فقرات نص PowerPoint باستخدام JavaScript
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
  - إدارة النقطة
  - مسافة بادئة للفقرة
  - مسافة بادئة معلقة
  - نقطة الفقرة
  - قائمة رقمية
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
description: "تعرف على كيفية إنشاء وتنسيق الفقرات، الأقسام، النقاط، القوائم الرقمية، المسافات البادئة، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

Aspose.Slides for Node.js via Java يمثل النص كسلسلة من إطارات النص، الفقرات، والأقسام:

* [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) يمثل حاوية النص في الشكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) يمثل فقرة واحدة في إطار النص ويوفر الوصول إلى أقسامها وتنسيق الفقرة.
* [Portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/) يمثل تشغيل نص داخل الفقرة. يمكن لكل قسم أن يحتوي نصاً وتنسيقاً على مستوى الأحرف.

وبالتالي يمكن لفقرة أن تحتوي نصاً بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام أقسام متعددة.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات مع أقسام متعددة**

الخطوات التالية تنشئ إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاث أقسام:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة كائنين إضافيين من نوع [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) إلى إطار النص.
6. إضافة ما يكفي من كائنات [Portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/) لكل فقرة لتحتوي على ثلاث أقسام. الفقرة الافتراضية تحتوي بالفعل على قسم فارغ واحد.
7. تعيين نص كل قسم.
8. تطبيق تنسيق على مستوى الأحرف عبر [Portion.getPortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/getportionformat/).
9. حفظ العرض التقديمي المعدل.

هذا المثال بلغة JavaScript يطبق الخطوات:

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

## **إنشاء قوائم نقطية ورقمية**

### **إنشاء قائمة نقطية أو رقمية**

تُسهِّل النقاط والترقيم قراءة العناصر المرتبطة. في Aspose.Slides، يتم تعريف إعدادات القائمة عبر [BulletFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/).

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) لرمز نقطة.
7. تعيين [BulletFormat.setType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/settype/) إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bullettype/) وتحديد حرف النقطة.
8. تعيين نص الفقرة، والمسافة البادئة، ولون النقطة، وارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وتعيين [BulletFormat.setType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/settype/) إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bullettype/).
11. تكوين نمط النقطة الرقمية وإضافة الفقرة إلى إطار النص.
12. حفظ العرض التقديمي.

هذا المثال بلغة JavaScript ينشئ نقطة رمز ونقطة رقمية:

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

### **استخدام نقاط صورة**

تتيح لك نقاط الصورة استخدام صورة مخصصة بدلاً من الرمز أو الرقم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) والوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص به.
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة النقطة وإضافتها إلى مجموعة صور العرض التقديمي كـ [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) وتعيين نصها.
7. تعيين [BulletFormat.setType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/settype/) إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bullettype/).
8. إسناد الصورة عبر [BulletFormat.getPicture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/getpicture/) وتعيين ارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض التقديمي المعدل.

هذا المثال بلغة JavaScript ينشئ نقطة صورة:

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

تعيين [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setdepth/) لوضع الفقرات في مستويات مختلفة من القائمة. المستوى الأعلى له عمق `0`.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) ومسح الفقرة الافتراضية من إطار النص الخاص به.
3. إنشاء أربع فقرات وتكوين رموز النقاط الخاصة بها.
4. تعيين قيم [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setdepth/) إلى `0`، `1`، `2`، و `3`.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

هذا المثال بلغة JavaScript ينشئ قائمة نقطية بأربع مستويات:

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

### **بدء عناصر القائمة الرقمية بقيم مخصصة**

استخدام [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) لتعيين الرقم الأول المعروض لفقرة رقمية.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) وإضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى شريحة.
2. مسح الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات رقمية.
4. تعيين [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) إلى `2`، `3`، و `7` للفقرات ذات الصلة.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

هذا المثال بلغة JavaScript يعين رقم بدء مخصص لكل فقرة:

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

### **تعيين مسافة بادئة للسطر الأول**

استخدام [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) للتحكم في مسافة البادئة للسطر الأول من الفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى بقية الأسطر محاذاة إلى جسم الفقرة.

استخدام [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مختلفة من [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) لتوضيح تأثير مسافة البادئة للسطر الأول على تخطيط الفقرة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بالشكل ومسح الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة من [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين مسافة بادئة للفقرة:

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

![مسافة البادئة للسطر الأول للفقرة](first_line_indent.png)

### **تعيين مسافة بادئة معلقة**

المسافة البادئة المعلقة هي تخطيط للفقرة بحيث يبدأ السطر الأول إلى اليسار من باقي الأسطر. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/). مرّر قيمة سلبية لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

في الممارسة العملية، يحدد [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) الموقع الأيسر لجسم الفقرة، ويحدد [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) موقع السطر الأول بالنسبة إلى ذلك الهامش. لإنشاء مسافة بادئة معلقة، مرّر قيمة موجبة إلى `setMarginLeft` وقيمة سلبية إلى `setIndent`.

هذا التنسيق مفيد للمراجع الببليوجرافية، المراجع، مدخلات القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر المتعبة محاذية تحت جسم الفقرة بدلاً من الحرف الأول للسطر الأول.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بالشكل ومسح الفقرة الافتراضية.
5. إنشاء فقرات وتمرير قيمة موجبة إلى [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) لكل فقرة.
6. تمرير قيمة سلبية إلى [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) لإنشاء تأثير المسافة البادئة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين مسافة بادئة معلقة لفقرة:

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

![المسافة البادئة المعلقة للفقرة](hanging_indent.png)

### **تعيين خصائص نهاية الفقرة**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) يتحكم في تنسيق علامة نهاية الفقرة. المثال التالي يعيّن حجم الخط وخط اللاتينية لعلامة نهاية الفقرة الثانية:

1. إنشاء أو تحميل [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) ومسح الفقرة الافتراضية الخاصة به.
3. إنشاء فقرتين وإضافة أقسام نصية إليهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. تعيين [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) و [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. إسناد التنسيق عبر [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) وحفظ العرض التقديمي.

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

## **استيراد وتصدير محتوى الفقرة**

### **استيراد نص HTML إلى الفقرات**

استخدام [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) لتحويل ترميز HTML إلى فقرات وأقسام داخل إطار نص.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/).
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بالشكل ومسح الفقرة الافتراضية.
4. تعريف أو قراءة سلسلة HTML المصدر.
5. تمرير سلسلة HTML إلى [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. حفظ العرض التقديمي المعدل.

هذا المثال بلغة JavaScript يستورد HTML إلى إطار نص:

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

استخدام [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) لتصدير مجموعة محددة من الفقرات كملف HTML.

1. إنشاء أو تحميل مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة والعثور على [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) الذي يحتوي على النص.
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
4. استدعاء [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) مع فهرس الفقرة البداية وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المسترجعة إلى ملف.

هذا المثال المستقل بلغة JavaScript ينشئ شكل نص ويصدر جميع فقراته:

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

### **عرض الفقرة كصورة**

[Paragraph.getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/#getImage) يعرض فقرة فردية مباشرة ويعيد كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/). احفظ النتيجة إلى ملف باستخدام [IImage.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/#save). لا تحتاج إلى عرض الشكل الحاوي أو قص صورة bitmap يدويًا.

[Paragraph.getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/#getImage) يمكن أن تُعيد `null` إذا لم يتم العثور على الفقرة في مجموعتها الأم، أو لا تملك حدود رسم صالحة، أو لا يمكن رسمها. تحقق من النتيجة قبل حفظها وتأكد من التخلص من الصورة المسترجعة بعد الاستخدام.

#### **عرض الفقرة بالمقياس الافتراضي**

صندوق النص التالي يحتوي على ثلاث فقرات:

![صندوق النص بثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يعرض الفقرة الثانية في شكل نص عادي بالمقياس الافتراضي ويحفظ الصورة المسترجعة بتنسيق PNG. يضمن القسم `finally` التخلص الصحيح من الصورة.

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

#### **عرض الفقرة في خلية جدول مع تكبير**

استخدام نسخة [Paragraph.getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/#getImage) التي تقبل معاملات `scaleX` و `scaleY` لتحديد عوامل التكبير الأفقي والعمودي. المثال التالي ينشئ جدولًا، يعرض الفقرة في خليةه الأولى بعرض وارتفاع ضعفين عن الافتراضي، ويحفظ النتيجة كصورة PNG.

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

عامل التكبير `1` يبقي المحور على حجمه البكسلي الافتراضي. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، أي أربعة أضعاف عدد البكسلات. العوامل الأكبر عادةً ما تعطي نصًا أوضح للتكبير أو الإخراج عالي الدقة، لكنها تزداد استهلاكًا للذاكرة وحجم الملف. العوامل الأقل من `1` تنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة عرض الفقرة إلى ارتفاعها؛ العوامل الأفقية والعمودية المختلفة تُشَدد المخرجات بشكل مستقل.

عرض شكل كامل باستخدام [Shape.getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getImage) يظل مفيدًا عندما يجب تضمين تعبئة الشكل أو حدوده أو سياقه البصري. للحصول على صورة للفقرة فقط، استخدم [Paragraph.getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**هل يمكنني تعطيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. تعيين [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/setwraptext/) لتعطيل التفاف السطر حتى لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة بدقة؟**

استخدم [Paragraph.getRect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/getrect/) لاسترجاع مستطيل الحدود للفقرة. يوفر [Portion.getRect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/#getRect) حدود القسم الفردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، مركز أو ضبط)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setalignment/) هو إعداد على مستوى الفقرة ويطبق على الفقرة بأكملها بغض النظر عن تنسيق الأقسام الفردية.

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. تعيين [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) للأقسام الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بعدة لغات.