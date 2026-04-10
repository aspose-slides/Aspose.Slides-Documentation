---
title: إدارة فقرات نصوص PowerPoint في JavaScript
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/nodejs-java/manage-paragraph/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة النقاط
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
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إتقان تنسيق الفقرات باستخدام Aspose.Slides لـ Node.js عبر Java—تحسين المحاذاة والمسافات والنمط في عروض PPT و PPTX و ODP باستخدام JavaScript."
---
توفر Aspose.Slides جميع الفئات والصفوف التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في Java.

* توفر Aspose.Slides الفئة [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `TextFame` أن يحتوي على فقرة واحدة أو عدة فقرات (كل فقرة تُنشأ عبر إدخال سطر جديد).
* توفر Aspose.Slides الفئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) للسماح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `Paragraph` أن يحتوي على جزء واحد أو عدة أجزاء (مجموعة من كائنات الجزء النصي).
* توفر Aspose.Slides الفئة [Portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/) للسماح لك بإضافة كائنات تمثل نصوصًا وخصائص التنسيق الخاصة بها.

كائن `Paragraph` قادر على معالجة النصوص ذات خصائص التنسيق المختلفة عبر كائنات `Portion` الأساسية الخاصة به.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) على شكل مستطيل إلى الشريحة.
4. الحصول على `ITextFrame` المرتبط بـ [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/).
5. إنشاء كائنين من الفئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) وإضافتهما إلى مجموعة `IParagraphs` في [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).
6. إنشاء ثلاثة كائنات من الفئة [Portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/) لكل `Paragraph` جديد (جزئين من الـ Portion للفقرة الافتراضية) وإضافة كل كائن `Portion` إلى مجموعة IPortion الخاصة بكل `Paragraph`.
7. ضبط نص لكل جزء.
8. تطبيق خصائص التنسيق المفضلة لكل جزء باستخدام خصائص التنسيق التي تُظهرها كائن `Portion`.
9. حفظ العرض التقديمي المعدل.

هذا الكود Javascript هو تنفيذ للخطوات الخاصة بإضافة فقرات تحتوي على أجزاء:

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
    // إنشاء فقرات وأجزاء بتنسيقات نصية مختلفة
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
    // كتابة ملف PPTX إلى القرص
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **إدارة نقط القوائم الفقرية**

تساعد قوائم النقط على تنظيم وتقديم المعلومات بسرعة وكفاءة. تكون الفقرات ذات النقط دائمًا أسهل في القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة المحددة.
4. الوصول إلى `TextFrame` الخاص بـ AutoShape عبر [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/).
7. ضبط `Type` للنقطة للفقرة إلى `Symbol` وتحديد حرف النقطة.
8. ضبط `Text` للفقرة.
9. ضبط `Indent` للفقرة بالنسبة للنقطة.
10. تحديد لون للنقطة.
11. تحديد ارتفاع للنقطة.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات من 7 إلى 13.
14. حفظ العرض التقديمي.

هذا الكود Javascript يوضح كيفية إضافة نقطة فقرة:

```javascript
    // ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
    var pres = new aspose.slides.Presentation();
    try {
        // يفتح الشريحة الأولى
        var slide = pres.getSlides().get_Item(0);
        // يضيف ويصل إلى Autoshape
        var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
        // يفتح إطار النص للـ Autoshape
        var txtFrm = aShp.getTextFrame();
        // يزيل الفقرة الافتراضية
        txtFrm.getParagraphs().removeAt(0);
        // ينشئ فقرة
        var para = new aspose.slides.Paragraph();
        // يضبط نمط نقطة الفقرة والرمز
        para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para.getParagraphFormat().getBullet().setChar(8226);
        // يضبط نص الفقرة
        para.setText("Welcome to Aspose.Slides");
        // يضبط إزاحة النقطة
        para.getParagraphFormat().setIndent(25);
        // يضبط لون النقطة
        para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
        para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // تعيين IsBulletHardColor إلى true لاستخدام لون نقطة مخصص
        // يضبط ارتفاع النقطة
        para.getParagraphFormat().getBullet().setHeight(100);
        // يضيف الفقرة إلى إطار النص
        txtFrm.getParagraphs().add(para);
        // ينشئ الفقرة الثانية
        var para2 = new aspose.slides.Paragraph();
        // يضبط نوع النقطة للفقرة والنمط
        para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
        para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
        // يضيف نص الفقرة
        para2.setText("This is numbered bullet");
        // يضبط إزاحة النقطة
        para2.getParagraphFormat().setIndent(25);
        para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
        para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // تعيين IsBulletHardColor إلى true لاستخدام لون نقطة مخصص
        // يضبط ارتفاع النقطة
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

## **إدارة نقط القوائم المصورة**

تساعد قوائم النقط على تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات المصورة سهلة القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى `TextFrame` الخاص بـ AutoShape عبر [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/).
7. تحميل الصورة في فئة [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/).
8. ضبط نوع النقطة إلى [Picture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) وتعيين الصورة.
9. ضبط `Text` للفقرة.
10. ضبط `Indent` للفقرة بالنسبة للنقطة.
11. تحديد لون للنقطة.
12. تحديد ارتفاع للنقطة.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.

هذا الكود Javascript يوضح كيفية إضافة وإدارة النقاط المصورة:

```javascript
// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
var presentation = new aspose.slides.Presentation();
try {
    // يصل إلى الشريحة الأولى
    var slide = presentation.getSlides().get_Item(0);
    // ينشئ الصورة المستخدمة للنقاط
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

تساعد قوائم النقط على تنظيم وتقديم المعلومات بسرعة وكفاءة. النقاط متعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) في الشريحة الجديدة.
4. الوصول إلى `TextFrame` الخاص بـ AutoShape عبر [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) وضبط العمق إلى 0.
7. إنشاء المثال الثاني للفقرة عبر فئة `Paragraph` وضبط العمق إلى 1.
8. إنشاء المثال الثالث للفقرة عبر فئة `Paragraph` وضبط العمق إلى 2.
9. إنشاء المثال الرابع للفقرة عبر فئة `Paragraph` وضبط العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض التقديمي المعدل.

هذا الكود Javascript يوضح كيفية إضافة وإدارة النقاط متعددة المستويات:

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
    // يحدد مستوى النقطة
    para1.getParagraphFormat().setDepth(0);
    // يضيف الفقرة الثانية
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // يحدد مستوى النقطة
    para2.getParagraphFormat().setDepth(1);
    // يضيف الفقرة الثالثة
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // يحدد مستوى النقطة
    para3.getParagraphFormat().setDepth(2);
    // يضيف الفقرة الرابعة
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // يحدد مستوى النقطة
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

توفر الفئة [BulletFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) وغيرها التي تسمح لك بإدارة الفقرات ذات الترقيم أو التنسيق المخصص.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى `TextFrame` الخاص بـ AutoShape عبر [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) وضبط [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) إلى 2.
7. إنشاء المثال الثاني للفقرة عبر فئة `Paragraph` وضبط `NumberedBulletStartWith` إلى 3.
8. إنشاء المثال الثالث للفقرة عبر فئة `Paragraph` وضبط `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض التقديمي المعدل.

هذا الكود Javascript يوضح كيفية إضافة وإدارة الفقرات ذات الترقيم أو التنسيق المخصص:

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

## **ضبط مسافة الإزاحة للسطرة الأولى في الفقرة**

استخدم الطريقة [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) للتحكم في إزاحة السطر الأول للفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذية لجسم الفقرة.

استخدم [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم إزاحة مختلفة لتوضيح تأثير إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وضبط قيم مختلفة لـ [Indent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية ضبط إزاحة الفقرة:

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

![إزاحة السطر الأول للفقرات](first_line_indent.png)

## **ضبط إزاحة معلقة للفقرة**

الإزاحة المعلقة هي تخطيط فقرة يكون فيه السطر الأول يبدأ إلى اليسار من الأسطر المتبقية. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام الطريقة [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/). اضبط الإزاحة إلى قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة لجسم الفقرة.

في الواقع، [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) يحدد الموضع الأيسر لجسم الفقرة، و[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) يحدد موضع السطر الأول نسبةً لهذا الهامش. لإنشاء إزاحة معلقة، اضبط قيمة `MarginLeft` إلى موجبة وقيمة `Indent` إلى سالبة.

هذا التنسيق مفيد للبيبليوغرافيات، المراجع، مداخل القاموس، والفقرات الأخرى التي يجب أن تتماشى الأسطر المغلفة تحت جسم الفقرة بدلاً من تحت الحرف الأول للسطر الأول.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وضبط قيمة موجبة لـ [MarginLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) لكل فقرة.
6. ضبط قيمة سالبة لـ [Indent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setindent/) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية ضبط إزاحة معلقة للفقرة:

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

![الإزاحة المعلقة للفقرات](hanging_indent.png)

## **إدارة خصائص تشغيل نهاية الفقرة للفقرة**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موقعها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) به فقرتان إلى المستطيل.
1. ضبط `FontHeight` ونوع الخط للفقرات.
1. ضبط خصائص End للفقرات.
1. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود Javascript يوضح كيفية ضبط خصائص End للفقرات في PowerPoint:

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

توفر Aspose.Slides دعمًا محسنًا لاستيراد نصوص HTML إلى الفقرات.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. إضافة والوصول إلى `TextFrame` الخاص بـ AutoShape عبر [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. قراءة ملف HTML المصدر في `TextReader`.
7. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء إلى مجموعة فقرات `ParagraphCollection` في `TextFrame`.
9. حفظ العرض التقديمي المعدل.

هذا الكود Javascript هو تنفيذ للخطوات الخاصة باستيراد نصوص HTML إلى الفقرات:

```javascript
// إنشاء مثيل عرض تقديمي فارغ
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

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) وتحميل العرض التقديمي المرغوب.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيُصدر إلى HTML.
4. الوصول إلى `TextFrame` الخاص بالشكل عبر [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).
5. إنشاء مثال من `StreamWriter` وإضافة ملف HTML الجديد.
6. تحديد فهرس بداية للـ `StreamWriter` وتصدير الفقرات المفضلة لديك.

هذا الكود Javascript يوضح كيفية تصدير نصوص فقرات PowerPoint إلى HTML:

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
    // كتابة بيانات الفقرات إلى HTML بتحديد فهرس بداية الفقرة وإجمالي عدد الفقرات التي سيتم نسخها
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

في هذا القسم، نستكشف مثالين يوضحان كيفية حفظ فقرة نصية، ممثلةً بفئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/)، كصورة. يتضمن كل مثال الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طرقي `getImage` من فئة [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تسمح هذه الأساليب باستخراج أجزاء محددة من النص من عروض PowerPoint وت保存ها كصور منفصلة، وهو ما يمكن أن يكون مفيدًا للاستخدام لاحقًا في سيناريوهات مختلفة.

لنفترض أن لدينا ملف عرض تقديمي يُدعى **sample.pptx** يحتوي على شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

**المثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نقوم باستخراج صورة الشكل من الشريحة الأولى للعرض التقديمي ثم نحسب حدود الفقرة الثانية في إطار النص الخاص بالشكل. تُعاد رسم الفقرة على صورة bitmap جديدة تُحفظ بصيغة PNG. هذه الطريقة مفيدة جدًا عندما تحتاج إلى حفظ فقرة معينة كصورة منفصلة مع الحفاظ على الأبعاد والتنسيق الدقيق للنص.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // حفظ الشكل في الذاكرة كصورة bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // إنشاء صورة bitmap للشكل من الذاكرة.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // حساب حدود الفقرة الثانية.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // حساب إحداثيات وحجم الصورة الناتجة (الحد الأدنى - بكسل واحد × 1).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // قص صورة bitmap الخاصة بالشكل للحصول على صورة bitmap للفقرة فقط.
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

**المثال 2**

في هذا المثال، نُوسّع النهج السابق بإضافة عوامل تكبير إلى صورة الفقرة. يُستخرج الشكل من العرض التقديمي ويُحفظ كصورة بمعامل تكبير `2`. يسمح ذلك بإنتاج صورة ذات دقة أعلى عند تصدير الفقرة. تُحسب حدود الفقرة مع مراعاة المقياس. التكبير يمكن أن يكون مفيدًا عندما تحتاج إلى صورة أكثر تفصيلاً، على سبيل المثال للاستخدام في مواد مطبوعة عالية الجودة.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // حفظ الشكل في الذاكرة كصورة bitmap مع التحجيم.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // إنشاء صورة bitmap للشكل من الذاكرة.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // حساب حدود الفقرة الثانية.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // حساب الإحداثيات والحجم للصورة الناتجة (الحد الأدنى - بكسل 1×1).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // قص صورة bitmap الخاصة بالشكل للحصول على صورة bitmap للفقرة فقط.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **الأسئلة المتكررة**

**هل يمكنني تعطيل التفاف الأسطر داخل إطار النص تمامًا؟**

نعم. استخدم إعداد التفاف إطار النص ([setWrapText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/setwraptext/)) لإيقاف التفاف الأسطر بحيث لا تُقَصَ الأسطر عند حدود الإطار.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة بدقة؟**

يمكنك استرداد المستطيل المحيط بالفقرة (وحتى الجزء الفردي) لمعرفة موقعها وحجمها الدقيق على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يسار/يمين/وسط/ضبط)؟**

[setAlignment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setalignment/) هو طريقة لضبط المحاذاة على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/); وتطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة تدقيق إملائي لجزء فقط من الفقرة (مثلاً كلمة واحدة)؟**

نعم. تُحدد اللغة على مستوى الجزء ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setLanguageId))، لذا يمكن أن تت coexist لغات متعددة داخل فقرة واحدة.