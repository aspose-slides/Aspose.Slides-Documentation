---
title: إدارة فقرات PowerPoint في JavaScript
type: docs
weight: 40
url: /ar/nodejs-java/manage-paragraph/
keywords:
- إضافة نص
- إضافة فقرات
- إدارة النص
- إدارة الفقرات
- إزاحة الفقرة
- نقطة الفقرة
- قائمة مرقمة
- خصائص الفقرة
- استيراد HTML
- النص إلى HTML
- الفقرة إلى HTML
- الفقرات إلى صور
- تصدير الفقرات
- عرض PowerPoint
- جافا سكريبت
- Aspose.Slides لـ Node.js عبر Java
description: إنشاء فقرات وإدارة خصائص الفقرة في عروض PowerPoint باستخدام جافا سكريبت
---

Aspose.Slides يوفر جميع الفئات والصفوف التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في Java.

* يوفر Aspose.Slides الفئة [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو متعددة (كل فقرة تُنشأ عبر إرجاع سطر).
* يوفر Aspose.Slides الفئة [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) للسماح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `IParagraph` أن يحتوي على جزء واحد أو متعدد (مجموعة كائنات iPortions).
* يوفر Aspose.Slides الفئة [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) للسماح لك بإضافة كائنات تمثل نصوصًا وخصائص تنسيقها.

كائن `IParagraph` قادر على معالجة النصوص ذات خصائص تنسيق مختلفة عبر كائناته الأساسية `IPortion`.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) على شكل مستطيل إلى الشريحة.
4. الحصول على `ITextFrame` المرتبط بـ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
5. إنشاء كائنين من الفئة [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
6. إنشاء ثلاثة كائنات من الفئة [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) لكل `IParagraph` جديد (اثنان من كائنات Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. ضبط نص لكل جزء.
8. تطبيق خصائص التنسيق المفضلة على كل جزء باستخدام خصائص التنسيق المتاحة في كائن `IPortion`.
9. حفظ العرض المعدل.

يُظهر هذا الكود Javascript تنفيذ الخطوات لإضافة فقرات تحتوي على أجزاء:
```javascript
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // الوصول إلى TextFrame الخاص بالـ AutoShape
    var tf = ashp.getTextFrame();
    // إنشاء فقرات وأقسام بتنسيقات نص مختلفة
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


## **إدارة نقط القوائم للفقرة**

تساعد قوائم النقط على تنظيم المعلومات وتقديمها بسرعة وكفاءة. الفقرات المرقمة تكون دائمًا أسهل للقراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة المختارة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول فقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
7. تعيين `Type` للنقطة إلى `Symbol` وضبط حرف النقطة.
8. تعيين نص الفقرة.
9. تعيين `Indent` للفقرة بالنسبة للنقطة.
10. تعيين لون للنقطة.
11. تعيين ارتفاع للنقطة.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية من الخطوة 7 إلى 13.
14. حفظ العرض.

يُظهر هذا الكود Javascript كيفية إضافة نقطة للفقرة:
```javascript
// ينشئ كائن من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة والوصول إلى AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // الوصول إلى إطار النص للـ AutoShape
    var txtFrm = aShp.getTextFrame();
    // إزالة الفقرة الافتراضية
    txtFrm.getParagraphs().removeAt(0);
    // إنشاء فقرة
    var para = new aspose.slides.Paragraph();
    // تعيين نمط نقطة الفقرة والرمز
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // تعيين نص الفقرة
    para.setText("Welcome to Aspose.Slides");
    // تعيين إزاحة النقطة
    para.getParagraphFormat().setIndent(25);
    // تعيين لون النقطة
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// ضع IsBulletHardColor إلى true لاستخدام لون نقطة مخصص
    // تعيين ارتفاع النقطة
    para.getParagraphFormat().getBullet().setHeight(100);
    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);
    // إنشاء الفقرة الثانية
    var para2 = new aspose.slides.Paragraph();
    // تعيين نوع ونمط نقطة الفقرة
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // إضافة نص الفقرة
    para2.setText("This is numbered bullet");
    // تعيين إزاحة النقطة
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// ضع IsBulletHardColor إلى true لاستخدام لون نقطة مخصص
    // تعيين ارتفاع النقطة
    para2.getParagraphFormat().getBullet().setHeight(100);
    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para2);
    // حفظ العرض المعدل
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إدارة نقط الصور للفقرة**

تساعد قوائم النقط على تنظيم المعلومات وتقديمها بسرعة وكفاءة. فقرات الصور تكون سهلة القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول فقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
7. تحميل الصورة في [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).
8. تعيين نوع النقطة إلى [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) وضبط الصورة.
9. تعيين نص الفقرة.
10. تعيين `Indent` للفقرة بالنسبة للنقطة.
11. تعيين لون للنقطة.
12. تعيين ارتفاع للنقطة.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض المعدل.

يُظهر هذا الكود Javascript كيفية إضافة وإدارة نقط الصور:
```javascript
// ينشئ فئة Presentation تمثل ملف PPTX
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
    // يضيف ويصل إلى Autoshape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // يصل إلى إطار نص الشكل التلقائي
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
    // يكتب العرض كملف PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // يكتب العرض كملف PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **إدارة نقط متعددة المستويات**

تساعد قوائم النقط على تنظيم المعلومات وتقديمها بسرعة وكفاءة. النقاط متعددة المستويات تكون سهلة القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول فقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء الفقرة الثانية عبر الفئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء الفقرة الثالثة عبر الفئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء الفقرة الرابعة عبر الفئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض المعدل.

يُظهر هذا الكود Javascript كيفية إضافة وإدارة نقاط متعددة المستويات:
```javascript
    // ينشئ فئة Presentation تمثل ملف PPTX
    var pres = new aspose.slides.Presentation();
    try {
        // يصل إلى الشريحة الأولى
        var slide = pres.getSlides().get_Item(0);
        // يضيف ويصل إلى AutoShape
        var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
        // يصل إلى إطار النص للشكل التلقائي المُنشأ
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
        // يكتب العرض كملف PPTX
        pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **إدارة الفقرات بقائمة مرقمة مخصصة**

توفر الفئة [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) وغيرها التي تسمح لك بإدارة الفقرات ذات الترقيم أو التنسيق المخصص.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول فقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) إلى 2.
7. إنشاء الفقرة الثانية عبر الفئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء الفقرة الثالثة عبر الفئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض المعدل.

يُظهر هذا الكود Javascript كيفية إضافة وإدارة الفقرات ذات الترقيم أو التنسيق المخصص:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // يصل إلى إطار النص للشكل التلقائي المُنشأ
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


## **تعيين إزاحة الفقرة**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
1. إضافة [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) على شكل مستطيل إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) يحتوي على ثلاث فقرات إلى الشكل المستطيل.
1. إخفاء خطوط المستطيل.
1. تعيين الإزاحة لكل [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) عبر خاصية `BulletOffset`.
1. كتابة العرض المعدل كملف PPT.

يُظهر هذا الكود Javascript كيفية تعيين إزاحة للفقرة:
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة شكل مستطيل
    var rect = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 150);
    // إضافة TextFrame إلى المستطيل
    var tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    // ضبط النص ليتناسب مع الشكل
    tf.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // إخفاء خطوط المستطيل
    rect.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    // الحصول على الفقرة الأولى في TextFrame وتعيين إزاحة الفقرة
    var para1 = tf.getParagraphs().get_Item(0);
    // تحديد نمط نقطة الفقرة والرمز
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para1.getParagraphFormat().setDepth(2);
    para1.getParagraphFormat().setIndent(30);
    // الحصول على الفقرة الثانية في TextFrame وتعيين إزاحة الفقرة
    var para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar(8226);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para2.getParagraphFormat().setDepth(2);
    para2.getParagraphFormat().setIndent(40);
    // الحصول على الفقرة الثالثة في TextFrame وتعيين إزاحة الفقرة
    var para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para3.getParagraphFormat().setDepth(2);
    para3.getParagraphFormat().setIndent(50);
    // حفظ العرض على القرص
    pres.save("InOutDent_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين إزاحة معلقة للفقرة**

يُظهر هذا الكود Javascript كيفية تعيين إزاحة معلقة للفقرة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 250, 550, 150);
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Example");
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");
    var para3 = new aspose.slides.Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");
    para2.getParagraphFormat().setMarginLeft(10.0);
    para3.getParagraphFormat().setMarginLeft(20.0);
    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إدارة خصائص تشغيل النهاية للفقرة**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موقعها.
1. إضافة [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) على شكل مستطيل إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) يحتوي على فقرتين إلى المستطيل.
1. تعيين `FontHeight` ونوع الخط للفقرات.
1. تعيين خصائص النهاية للفقرات.
1. كتابة العرض المعدل كملف PPTX.

يُظهر هذا الكود Javascript كيفية تعيين خصائص النهاية للفقرات في PowerPoint:
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

يوفر Aspose.Slides دعمًا محسّنًا لاستيراد نصوص HTML إلى الفقرات.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في `TextReader`.
7. إنشاء أول فقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء إلى مجموعة [ParagraphCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/) الخاصة بـ TextFrame.
9. حفظ العرض المعدل.

يُظهر هذا الكود Javascript تنفيذ الخطوات لاستيراد نصوص HTML إلى الفقرات:
```javascript
// إنشاء مثال عرض فارغ
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى الافتراضية في العرض
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape لاستيعاب محتوى HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // إضافة إطار نص إلى الشكل
    ashape.addTextFrame("");
    // مسح جميع الفقرات في إطار النص المضاف
    ashape.getTextFrame().getParagraphs().clear();
    // تحميل ملف HTML باستخدام قارئ تدفق
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // إضافة النص من قارئ تدفق HTML إلى إطار النص
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // حفظ العرض
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تصدير نص الفقرات إلى HTML**

يوفر Aspose.Slides دعمًا محسّنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وتحميل العرض المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. الوصول إلى الشكل الذي يحتوي على النص المراد تصديره إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء مثال من `StreamWriter` وإضافة ملف HTML جديد.
6. توفير فهرس بدء إلى `StreamWriter` وتصدير الفقرات المفضلة لديك.

يُظهر هذا الكود Javascript كيفية تصدير نصوص فقرات PowerPoint إلى HTML:
```javascript
// تحميل ملف العرض
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // الوصول إلى الشريحة الأولى الافتراضية في العرض
    var slide = pres.getSlides().get_Item(0);
    // الفهرس المطلوب
    var index = 0;
    // الوصول إلى الشكل المضاف
    var ashape = slide.getShapes().get_Item(index);
    // إنشاء ملف HTML الناتج
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // استخراج الفقرة الأولى كـ HTML
    // كتابة بيانات الفقرات إلى HTML بتحديد فهرس بداية الفقرة وإجمالي الفقرات التي سيتم نسخها
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

في هذا القسم، نستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بواجهة [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/)، كصورة. يتضمن كل مثال الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طرق `getImage` من واجهة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة بتنسيق bitmap. تتيح هذه الأساليب استخراج أجزاء محددة من النص من عروض PowerPoint وت保存ها كصور منفصلة، مما قد يكون مفيدًا للاستخدامات المختلفة.

لنفترض أن لدينا ملف عرض يسمى **sample.pptx** يحتوي على شريحة واحدة، حيث أول شكل هو مربع نص يحتوي على ثلاث فقرات.

![The text box with three paragraphs](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض ثم نحسب حدود الفقرة الثانية داخل إطار النص الخاص بالشكل. ثم يُعاد رسم الفقرة على صورة bitmap جديدة تُحفظ بصيغة PNG. هذه الطريقة مفيدة عندما تحتاج إلى حفظ فقرة محددة كصورة منفصلة مع الحفاظ على الأبعاد والتنسيق الدقيق للنص.
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

    // احسب إحداثيات وحجم صورة الإخراج (الحد الأدنى - 1×1 بكسل).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // قصّ صورة الشكل النقطية للحصول على صورة الفقرة فقط.
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

![The paragraph image](paragraph_to_image_output.png)

**مثال 2**

في هذا المثال نوسع النهج السابق بإضافة عوامل مقياس إلى صورة الفقرة. يُستخرج الشكل من العرض ويحفظ كصورة بعامل مقياس `2`. يتيح ذلك مخرجات ذات دقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع أخذ المقياس في الاعتبار. يمكن أن يكون المقياس مفيدًا عندما تكون الصورة المفصلة مطلوبة، مثلًا للاستخدام في مواد مطبوعة عالية الجودة.
```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // احفظ الشكل في الذاكرة كصورة نقطية مع التحجيم.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // أنشئ صورة نقطية للشكل من الذاكرة.
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

    // احسب إحداثيات وحجم صورة الإخراج (الحد الأدنى - 1×1 بكسل).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // قصّ صورة الشكل النقطية للحصول على صورة الفقرة فقط.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**هل يمكنني تعطيل التفاف الأسطر داخل إطار النص تمامًا؟**

نعم. استخدم إعداد التفاف إطار النص ([setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/)) لإيقاف التفاف الأسطر بحيث لا تنكسر عند حدود الإطار.

**كيف يمكنني الحصول على حدود الفقرة المحددة بدقة داخل الشريحة؟**

يمكنك استرجاع المستطيل المحيط بالفقرة (وحتى بالجزء الواحد) لمعرفة موقعها وحجمها الدقيق على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يسار/يمين/وسط/ضبط)؟**

`[setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/)` هو طريقة لضبط محاذاة على مستوى الفقرة في `[ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/)`؛ وتطبق على الفقرة بالكامل بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة تدقيق إملائي لجزء فقط من الفقرة (مثلاً كلمة واحدة)؟**

نعم. اللغة تُحدد على مستوى الجزء (`[PortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)`)، لذا يمكن أن تت coexist عدة لغات داخل فقرة واحدة.