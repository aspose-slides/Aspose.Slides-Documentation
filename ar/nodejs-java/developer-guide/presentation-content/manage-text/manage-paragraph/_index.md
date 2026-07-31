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
- إدارة النقطة
- إزاحة الفقرة
- إزاحة معلقة
- نقطة الفقرة
- قائمة مرقمة
- قائمة نقاط
- خصائص الفقرة
- استيراد HTML
- نص إلى HTML
- فقرة إلى HTML
- فقرة إلى صورة
- نص إلى صورة
- تصدير الفقرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إتقان تنسيق الفقرات مع Aspose.Slides لـ Node.js عبر Java—تحسين المحاذاة والمسافات والنمط في عروض PPT و PPTX و ODP باستخدام JavaScript."
---
## **مقدمة**

توفر Aspose.Slides جميع الفئات والصفوف التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في Java.

* توفر Aspose.Slides الفئة [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) التي تسمح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `TextFame` أن يحتوي على فقرة واحدة أو عدة فقرات (يتم إنشاء كل فقرة من خلال إدخال عودة سطر).
* توفر Aspose.Slides الفئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) التي تسمح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `Paragraph` أن يحتوي على جزء واحد أو عدة أجزاء (مجموعة من كائنات جزء النص).
* توفر Aspose.Slides الفئة [Portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/) التي تسمح لك بإضافة كائنات تمثل نصوصًا وخصائص تنسيقها.

يمكن لكائن `Paragraph` التعامل مع نصوص ذات خصائص تنسيق مختلفة من خلال كائنات `Portion` الأساسية الخاصة به.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

تُظهر هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الحصول على `ITextFrame` المرتبط بـ [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/).
5. إنشاء كائنين من الفئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) وإضافتهما إلى مجموعة `IParagraphs` في [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).
6. إنشاء ثلاثة كائنات من الفئة [Portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/) لكل `Paragraph` جديد (جزئين `Portion` للفقرة الافتراضية) وإضافة كل كائن `Portion` إلى مجموعة IPortion الخاصة بكل `Paragraph`.
7. تعيين نص لكل جزء.
8. تطبيق ميزات التنسيق المفضلة على كل جزء باستخدام خصائص تنسيق `Portion`.
9. حفظ العرض التقديمي المعدل.

هذا الكود JavaScript هو تنفيذ للخطوات لإضافة فقرات تحتوي على أجزاء:

```javascript
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // الوصول إلى TextFrame الخاص بـ AutoShape
    var tf = ashp.getTextFrame();
    // إنشاء فقرات وأجزاء بتنسيقات نص مختلفة
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // حفظ PPTX إلى القرص
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **إدارة تعداد الفقرات**

تساعد القوائم ذات النقاط في تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات ذات النقاط تكون دائمًا أسهل للقراءة والفهم.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول فقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/).
7. تعيين خاصية `Type` للنقطة إلى `Symbol` وتحديد حرف النقطة.
8. تعيين نص الفقرة.
9. تعيين `Indent` للفقرة بالنسبة للنقطة.
10. تعيين لون للنقطة.
11. تعيين ارتفاع للنقطة.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية من الخطوة 7 إلى 13.
14. حفظ العرض التقديمي.

هذا الكود JavaScript يوضح كيفية إضافة نقطة للفقرة:

```javascript
// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يصل إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // يضيف ويصل إلى AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // يصل إلى إطار النص للـ AutoShape
    var txtFrm = aShp.getTextFrame();
    // يزيل الفقرة الافتراضية
    txtFrm.getParagraphs().removeAt(0);
    // ينشئ فقرة
    var para = new aspose.slides.Paragraph();
    // يحدد نمط نقطة الفقرة والرمز
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // يحدد نص الفقرة
    para.setText("Welcome to Aspose.Slides");
    // يحدد إزاحة النقطة
    para.getParagraphFormat().setIndent(25);
    // يحدد لون النقطة
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // ضبط IsBulletHardColor إلى true لاستخدام لون نقطة مخصص
    // يحدد ارتفاع النقطة
    para.getParagraphFormat().getBullet().setHeight(100);
    // يضيف الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);
    // ينشئ الفقرة الثانية
    var para2 = new aspose.slides.Paragraph();
    // يحدد نوع نمط نقطة الفقرة
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // يضيف نص الفقرة
    para2.setText("This is numbered bullet");
    // يحدد إزاحة النقطة
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // ضبط IsBulletHardColor إلى true لاستخدام لون نقطة مخصص
    // يحدد ارتفاع النقطة
    para2.getParagraphFormat().getBullet().setHeight(100);
    // يضيف الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para2);
    // يحفظ العرض التقديمي المعدل
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **إدارة نقاط الصورة**

تساعد القوائم ذات النقاط في تنظيم وعرض المعلومات بسرعة وكفاءة. فقرات الصورة سهلة القراءة والفهم.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول فقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/).
7. تحميل الصورة في الفئة [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/).
8. تعيين نوع النقطة إلى [Picture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) وتحديد الصورة.
9. تعيين نص الفقرة.
10. تعيين `Indent` للفقرة بالنسبة للنقطة.
11. تعيين لون للنقطة.
12. تعيين ارتفاع للنقطة.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.

هذا الكود JavaScript يوضح كيفية إضافة وإدارة نقاط الصورة:

```javascript
// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
var presentation = new aspose.slides.Presentation();
try {
    // يصل إلى الشريحة الأولى
    var slide = presentation.getSlides().get_Item(0);
    // ينشئ الصورة للنقاط
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // يضيف ويصل إلى AutoShape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // يصل إلى إطار النص للـ AutoShape
    var textFrame = autoShape.getTextFrame();
    // يزيل الفقرة الافتراضية
    textFrame.getParagraphs().removeAt(0);
    // ينشئ فقرة جديدة
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // يضبط نمط نقطة الفقرة والصورة
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // يضبط ارتفاع النقطة
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // يضيف الفقرة إلى إطار النص
    textFrame.getParagraphs().add(paragraph);
    // يحفظ العرض التقديمي كملف PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // يحفظ العرض التقديمي كملف PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **إدارة النقاط متعددة المستويات**

تساعد القوائم ذات النقاط في تنظيم وعرض المعلومات بسرعة وكفاءة. النقاط متعددة المستويات سهلة القراءة والفهم.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول فقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء الفقرة الثانية عبر الفئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء الفقرة الثالثة عبر الفئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء الفقرة الرابعة عبر الفئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض التقديمي المعدل.

هذا الكود JavaScript يوضح كيفية إضافة وإدارة النقاط متعددة المستويات:

```javascript
// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يصل إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // يضيف ويصل إلى AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // يصل إلى إطار النص للـ AutoShape الذي تم إنشاؤه
    var text = aShp.addTextFrame("");
    // يمسح الفقرة الافتراضية
    text.getParagraphs().clear();
    // يضيف الفقرة الأولى
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // يضبط مستوى النقطة
    para1.getParagraphFormat().setDepth(0);
    // يضيف الفقرة الثانية
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // يضبط مستوى النقطة
    para2.getParagraphFormat().setDepth(1);
    // يضيف الفقرة الثالثة
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // يضبط مستوى النقطة
    para3.getParagraphFormat().setDepth(2);
    // يضيف الفقرة الرابعة
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // يضبط مستوى النقطة
    para4.getParagraphFormat().setDepth(3);
    // يضيف الفقرات إلى المجموعة
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // يحفظ العرض التقديمي كملف PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **إدارة الفقرة مع قائمة مرقمة مخصصة**

توفر الفئة [BulletFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) وغيرها التي تسمح لك بإدارة الفقرات بأرقام أو تنسيقات مخصصة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول فقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) إلى 2.
7. إنشاء الفقرة الثانية عبر الفئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء الفقرة الثالثة عبر الفئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض التقديمي المعدل.

هذا الكود JavaScript يوضح كيفية إضافة وإدارة الفقرات بأرقام مخصصة أو تنسيقات مخصصة:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // يصل إلى إطار النص للـ AutoShape الذي تم إنشاؤه
    var textFrame = shape.getTextFrame();
    // يزيل الفقرة الافتراضية الموجودة
    textFrame.getParagraphs().removeAt(0);
    // القائمة الأولى
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **تعيين المسافة البادئة للسطر الأول للفقرة**

استخدم الطريقة [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) للتحكم في المسافة البادئة للسطر الأول للفقرة. تنقل هذه الطريقة السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذية إلى جسم الفقرة.

استخدم [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) عندما تحتاج إلى تحريك الفقرة بالكامل. استخدم [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مسافة بادئة مختلفة لتوضيح تأثير المسافة البادئة للسطر الأول على تخطيط الفقرة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [Indent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين مسافة بادئة للفقرة:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

النتيجة:

![المسافة البادئة للسطر الأول للفقرات](first_line_indent.png)

## **تعيين مسافة بادئة معلقة للفقرة**

المسافة البادئة المعلقة هي تخطيط فقرة يكون فيه السطر الأول يبدأ إلى يسار الأسطر المتبقية. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام الطريقة [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/). اضبط المسافة على قيمة سلبية لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) يحدد الموضع الأيسر لجسم الفقرة، و[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) يحدد موضع السطر الأول بالنسبة لهذا الهامش. لإنشاء مسافة بادئة معلقة، اضبط قيمة `MarginLeft` موجبة وقيمة `Indent` سالبة.

يكون هذا التنسيق مفيدًا للمراجع، الفهارس، مدخلات القاموس، وفقرات أخرى تحتاج إلى محاذاة الأسطر المتلاحقة تحت جسم الفقرة بدلاً من تحت الحرف الأول للسطر الأول.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة `MarginLeft` موجبة لكل فقرة.
6. تعيين قيمة `Indent` سلبية لإنشاء تأثير المسافة البادئة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين مسافة بادئة معلقة للفقرة:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

النتيجة:

![المسافة البادئة المعلقة للفقرات](hanging_indent.png)

## **إدارة خصائص تشغيل الفقرة النهاية للفقرة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موقعها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) يحتوي على فقرتين إلى المستطيل.
1. تعيين `FontHeight` ونوع الخط للفقرات.
1. تعيين خصائص النهاية للفقرات.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود JavaScript يوضح كيفية تعيين خصائص النهاية للفقرات في PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **استيراد نص HTML إلى الفقرات**

توفر Aspose.Slides دعمًا محسنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. إضافة والوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بـ `AutoShape`.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. قراءة ملف HTML المصدر باستخدام `TextReader`.
7. إنشاء أول فقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء من `TextReader` إلى [ParagraphCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphcollection/) الخاص بـ `TextFrame`.
9. حفظ العرض التقديمي المعدل.

هذا الكود JavaScript هو تنفيذ للخطوات لاستيراد نصوص HTML إلى الفقرات:

```javascript
// إنشاء نسخة فارغة من العرض التقديمي
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape لاستيعاب محتوى HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // إضافة إطار نص إلى الشكل
    ashape.addTextFrame("");
    // مسح جميع الفقرات في إطار النص المضاف
    ashape.getTextFrame().getParagraphs().clear();
    // تحميل ملف HTML باستخدام StreamReader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // إضافة النص من StreamReader للـ HTML إلى إطار النص
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // حفظ العرض التقديمي
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تصدير نص الفقرات إلى HTML**

توفر Aspose.Slides دعمًا محسنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. الوصول إلى الشكل الذي يحتوي على النص المراد تصديره إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء نسخة من `StreamWriter` وإضافة ملف HTML الجديد.
6. توفير فهرس بدء إلى `StreamWriter` وتصدير الفقرات المفضلة لديك.

هذا الكود JavaScript يوضح كيفية تصدير نصوص فقرات PowerPoint إلى HTML:

```javascript
// تحميل ملف العرض التقديمي
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
    var slide = pres.getSlides().get_Item(0);
    // الفهرس المطلوب
    var index = 0;
    // الوصول إلى الشكل المضاف
    var ashape = slide.getShapes().get_Item(index);
    // إنشاء ملف HTML الناتج
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // استخراج الفقرة الأولى كـ HTML
    // كتابة بيانات الفقرات إلى HTML عن طريق توفير فهرس بدء الفقرة وإجمالي عدد الفقرات التي سيتم نسخها
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حفظ الفقرة كصورة**

في هذا القسم، سنستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بالفئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/)، كصورة. يتضمن كلا المثالين الحصول على صورة الشكل الذي يحتوي على الفقرة باستخدام طرق `getImage` من الفئة [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تسمح هذه الأساليب باستخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، وهو ما يمكن أن يكون مفيدًا في سيناريوهات متعددة.

لنفترض أن لدينا ملف عرض تقديمي يسمى sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص يحتوي على ثلاث فقرات](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض التقديمي ثم نحسب حدود الفقرة الثانية في إطار نص الشكل. ثم يتم إعادة رسم الفقرة على صورة bitmap جديدة تُحفظ بتنسيق PNG. هذه الطريقة مفيدة عندما تحتاج إلى حفظ فقرة معينة كصورة مستقلة مع الحفاظ على أبعاد النص وتنسيقه الدقيق.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // احفظ الشكل في الذاكرة كصورة نقطية.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // إنشاء صورة نقطية للشكل من الذاكرة.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // احسب حدود الفقرة الثانية.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // احسب إحداثيات وحجم الصورة الناتجة (الحد الأدنى - بكسل 1×1).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // قم بقص صورة الشكل للحصول على صورة الفقرة فقط.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

النتيجة:

![صورة الفقرة](paragraph_to_image_output.png)

**مثال 2**

في هذا المثال، نوسع النهج السابق بإضافة عوامل تكبير إلى صورة الفقرة. يتم استخراج الشكل من العرض التقديمي وحفظه كصورة بمعامل تكبير `2`. يتيح ذلك الحصول على مخرج بدقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع مراعاة التكبير. يمكن أن يكون التكبير مفيدًا عندما تحتاج إلى صورة أكثر تفصيلاً، على سبيل المثال لاستخدامها في مواد مطبوعة عالية الجودة.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // احفظ الشكل في الذاكرة كصورة نقطية مع التكبير.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // إنشاء صورة نقطية للشكل من الذاكرة.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // احسب حدود الفقرة الثانية.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // احسب إحداثيات وحجم الصورة الناتجة (الحد الأدنى - بكسل 1×1).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // قص صورة الشكل للحصول على صورة الفقرة فقط.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **الأسئلة الشائعة**

**هل يمكنني تعطيل التفاف النص بالكامل داخل إطار النص؟**

نعم. استخدم إعداد التفاف إطار النص ([setWrapText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/setwraptext/)) لإيقاف التفاف الأسطر بحيث لا تنكسر عند حدود الإطار.

**كيف يمكنني الحصول على حدود الفقرة المحددة بدقة على الشريحة؟**

يمكنك استخراج مستطيل الحدود للفقرة (وحتى لجزء واحد) لتعرف موقعها وحجمها الدقيق على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يسار/يمين/وسط/ضبط)؟**

`[setAlignment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setalignment/)` هي طريقة لضبط محاذاة الفقرة في `[ParagraphFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/)`؛ وتطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق الإملائي لجزء فقط من الفقرة (مثل كلمة واحدة)؟**

نعم. تُحدد اللغة على مستوى الجزء (`[PortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)`)، لذلك يمكن أن تتواجد لغات متعددة داخل نفس الفقرة.