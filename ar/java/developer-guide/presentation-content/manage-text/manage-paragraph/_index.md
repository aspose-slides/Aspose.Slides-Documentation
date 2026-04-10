---
title: "إدارة فقرات نص PowerPoint في Java"
linktitle: "إدارة الفقرة"
type: docs
weight: 40
url: /ar/java/manage-paragraph/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة الرصاص
- إزاحة الفقرة
- إزاحة معلقة
- رصاص الفقرة
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
- Java
- Aspose.Slides
description: "إتقان تنسيق الفقرات باستخدام Aspose.Slides for Java—تحسين المحاذاة والمسافات والأسلوب في عروض PPT و PPTX و ODP في Java."
---
توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في Java.

* تُوفر Aspose.Slides الواجهة [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) لتسمح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو عدة فقرات (يتم إنشاء كل فقرة عبر إرجاع السطر).
* تُوفر Aspose.Slides الواجهة [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/) لتسمح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `IParagraph` أن يحتوي على جزء واحد أو عدة أجزاء (مجموعة من كائنات iPortions).
* تُوفر Aspose.Slides الواجهة [IPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/) لتسمح لك بإضافة كائنات تمثل نصوصًا وخصائص تنسيقها.

كائن `IParagraph` قادر على معالجة نصوص ذات خصائص تنسيق مختلفة عبر كائناته الأساسية `IPortion`.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، كل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة مستطيل [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على `ITextFrame` المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/).
5. إنشاء كائنين من [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).
6. إنشاء ثلاثة كائنات من [IPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/) لكل `IParagraph` جديد (جزءان للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. ضبط نص لكل جزء.
8. تطبيق خصائص التنسيق المفضلة على كل جزء باستخدام خصائص التنسيق المتوفرة في كائن `IPortion`.
9. حفظ العرض التقديمي المعدل.

هذا الكود Java هو تنفيذ للخطوات لإضافة فقرات تحتوي على أجزاء:

```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // الوصول إلى TextFrame للـ AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // إنشاء فقرات وأجزاء بصيغ نصية مختلفة
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // كتابة PPTX إلى القرص
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة تعداد الفقرات النقطية**

تساعد القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات النقطية دائمًا ما تكون أسهل في القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى `TextFrame` الخاص بالـ شكل التلقائي عبر [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/). 
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول فقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/).
7. ضبط `Type` للرصاص إلى `Symbol` وتحديد حرف الرصاص.
8. ضبط `Text` للفقرة.
9. ضبط `Indent` للرصاص.
10. تعيين لون للرصاص.
11. تعيين ارتفاع للرصاص.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية من الخطوة 7 إلى 13.
14. حفظ العرض التقديمي.

هذا الكود Java يوضح كيفية إضافة رصاص فقرة:

```java
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // يضيف ويصل إلى Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص للـ autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // يزيل الفقرة الافتراضية
    txtFrm.getParagraphs().removeAt(0);

    // ينشئ فقرة
    Paragraph para = new Paragraph();

    // يحدد نمط رصاص الفقرة والرمز
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // يحدد نص الفقرة
    para.setText("Welcome to Aspose.Slides");

    // يحدد إزاحة الرصاص
    para.getParagraphFormat().setIndent(25);

    // يحدد لون الرصاص
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // اضبط IsBulletHardColor إلى true لاستخدام لون رصاص مخصص

    // يحدد ارتفاع الرصاص
    para.getParagraphFormat().getBullet().setHeight(100);

    // يضيف الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);

    // ينشئ الفقرة الثانية
    Paragraph para2 = new Paragraph();

    // يحدد نوع رصاص الفقرة والنمط
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // يضيف نص الفقرة
    para2.setText("This is numbered bullet");

    // يحدد إزاحة الرصاص
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // اضبط IsBulletHardColor إلى true لاستخدام لون رصاص مخصص

    // يحدد ارتفاع الرصاص
    para2.getParagraphFormat().getBullet().setHeight(100);

    // يضيف الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para2);
    
    // يحفظ العرض التقديمي المعدل
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة رصاصات الصور**

تساعد القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة. فقرات الصور سهلة القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى `TextFrame` الخاص بالـ شكل التلقائي عبر [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/). 
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول فقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/).
8. ضبط نوع الرصاص إلى [Picture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) وتعيين الصورة.
9. ضبط `Text` للفقرة.
10. ضبط `Indent` للرصاص.
11. تعيين لون للرصاص.
12. ضبط ارتفاع للرصاص.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.

هذا الكود Java يوضح كيفية إضافة وإدارة رصاصات الصور:

```java
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation presentation = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide slide = presentation.getSlides().get_Item(0);

    // ينشئ الصورة للرصاصات
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // يضيف ويصل إلى Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص للـ autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // يزيل الفقرة الافتراضية
    textFrame.getParagraphs().removeAt(0);

    // ينشئ فقرة جديدة
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // يضبط نمط رصاص الفقرة والصورة
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // يضبط ارتفاع الرصاص
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // يضيف الفقرة إلى إطار النص
    textFrame.getParagraphs().add(paragraph);

    // يحفظ العرض التقديمي كملف PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // يحفظ العرض التقديمي كملف PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إدارة الرصاصات المتعددة المستويات**

تساعد القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة. رصاصات المستويات المتعددة سهلة القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى `TextFrame` الخاص بالـ شكل التلقائي عبر [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/). 
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء الفقرة الأولى عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/) وضبط العمق إلى 0.
7. إنشاء الفقرة الثانية عبر الفئة `Paragraph` وضبط العمق إلى 1.
8. إنشاء الفقرة الثالثة عبر الفئة `Paragraph` وضبط العمق إلى 2.
9. إنشاء الفقرة الرابعة عبر الفئة `Paragraph` وضبط العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض التقديمي المعدل.

هذا الكود Java يوضح كيفية إضافة وإدارة رصاصات متعددة المستويات:

```java
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف ويصل إلى Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص للـ autoshape المُنشأ
    ITextFrame text = aShp.addTextFrame("");

    // يمسح الفقرة الافتراضية
    text.getParagraphs().clear();

    // يضيف الفقرة الأولى
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // يضبط مستوى الرصاص
    para1.getParagraphFormat().setDepth((short)0);

    // يضيف الفقرة الثانية
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // يضبط مستوى الرصاص
    para2.getParagraphFormat().setDepth((short)1);

    // يضيف الفقرة الثالثة
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // يضبط مستوى الرصاص
    para3.getParagraphFormat().setDepth((short)2);

    // يضيف الفقرة الرابعة
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // يضبط مستوى الرصاص
    para4.getParagraphFormat().setDepth((short)3);

    // يضيف الفقرات إلى المجموعة
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // يحفظ العرض التقديمي كملف PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة فقرة باستخدام قائمة مرقمة مخصصة**

توفر الواجهة [IBulletFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) وغيرها التي تسمح لك بإدارة الفقرات ذات الترقيم أو التنسيق المخصص.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى `TextFrame` الخاص بالـ شكل التلقائي عبر [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء الفقرة الأولى عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/) وضبط [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى 2.
7. إنشاء الفقرة الثانية عبر الفئة `Paragraph` وضبط `NumberedBulletStartWith` إلى 3.
8. إنشاء الفقرة الثالثة عبر الفئة `Paragraph` وضبط `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض التقديمي المعدل.

هذا الكود Java يوضح كيفية إضافة وإدارة الفقرات ذات الترقيم أو التنسيق المخصص:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص للـ autoshape المُنشأ
    ITextFrame textFrame = shape.getTextFrame();

    // يزيل الفقرة الافتراضية الموجودة
    textFrame.getParagraphs().removeAt(0);

    // القائمة الأولى
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ضبط مسافة الإزاحة للسطر الأول لفقرة**

استخدم الطريقة [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) للتحكم في مسافة إزاحة السطر الأول للفقرة. تُحرك هذه الطريقة السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تُحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذاة إلى جسم الفقرة.

استخدم [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) عندما تحتاج إلى تحريك الفقرة بالكامل. استخدم [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم إزاحة مختلفة لتوضيح تأثير إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وضبط قيم مختلفة لـ [Indent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية ضبط إزاحة الفقرة:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

النتيجة:

![إزاحة السطر الأول للفقرات](first_line_indent.png)

## **ضبط إزاحة معلق للفقرة**

إزاحة المعلق هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام الطريقة [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-). اضبط الإزاحة إلى قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، تحدد [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) الموضع الأيسر لجسم الفقرة، وتحدد [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) موضع السطر الأول بالنسبة لهذا الهامش. لإنشاء إزاحة معلق، اضبط قيمة `MarginLeft` إلى قيمة موجبة و `Indent` إلى قيمة سالبة.

هذا التنسيق مفيد للبيبليوجرافيات، المراجع، مدخلات القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر المغلفّة محاذية تحت جسم الفقرة وليس تحت أول حرف من السطر الأول.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وضبط قيمة موجبة لـ [MarginLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) لكل فقرة.
6. ضبط قيمة سالبة لـ [Indent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية ضبط إزاحة معلقة للفقرة:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

النتيجة:

![إزاحة معلقة للفقرات](hanging_indent.png)

## **إدارة خصائص تشغيل نهاية الفقرة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موضعها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) يحتوي على فقرتين إلى المستطيل.
1. ضبط `FontHeight` ونوع الخط للفقرات.
1. ضبط خصائص End للفقرات.
1. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود Java يوضح كيفية ضبط خصائص End للفقرات في PowerPoint:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **استيراد نص HTML إلى الفقرات**

توفر Aspose.Slides دعمًا محسّنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة والوصول إلى `ITextFrame` الخاص بـ `autoshape` عبر [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر باستخدام `TextReader`.
7. إنشاء أول فقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء إلى مجموعة الفقرات الخاصة بـ `TextFrame` عبر [ParagraphCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphcollection/).
9. حفظ العرض التقديمي المعدل.

هذا الكود Java هو تنفيذ للخطوات لاستيراد نصوص HTML إلى الفقرات:

```java
// إنشاء مثيل عرض تقديمي فارغ
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape لاستيعاب محتوى HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // إضافة إطار نص إلى الشكل
    ashape.addTextFrame("");

    // مسح جميع الفقرات في إطار النص المضاف
    ashape.getTextFrame().getParagraphs().clear();

    // تحميل ملف HTML باستخدام قارئ تدفق
    TextReader tr = new StreamReader("file.html");

    // إضافة النص من قارئ تدفق HTML إلى إطار النص
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // حفظ العرض التقديمي
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تصدير نص الفقرة إلى HTML**

توفر Aspose.Slides دعمًا محسّنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيُصدر إلى HTML.
4. الوصول إلى `TextFrame` الخاص بالشكل عبر [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframe/).
5. إنشاء مثيل من `StreamWriter` وإضافة ملف HTML الجديد.
6. توفير فهرس بدء إلى `StreamWriter` وتصدير الفقرات المفضلة لديك.

هذا الكود Java يوضح كيفية تصدير نصوص فقرات PowerPoint إلى HTML:

```java
// تحميل ملف العرض التقديمي
// الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
// الفهرس المطلوب
// الوصول إلى الشكل المضاف
// إنشاء ملف HTML الناتج
//استخراج الفقرة الأولى كـ HTML
// كتابة بيانات الفقرات إلى HTML من خلال توفير فهرس بداية الفقرة وإجمالي عدد الفقرات التي سيتم نسخها
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Acesss the default first slide of presentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Desired index
    int index = 0;

    // Accessing the added shape
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Creating output HTML file
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extracting first paragraph as HTML
    // Writing Paragraphs data to HTML by providing paragraph starting index, total paragraphs to be copied
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **حفظ فقرة كصورة**

في هذا القسم، نستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بالواجهة [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/)، كصورة. يتضمن كلا المثالين الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طرق `getImage` من الواجهة [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تتيح هذه الأساليب استخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، ما قد يكون مفيدًا في سيناريوهات مختلفة.

نفترض وجود ملف عرض تقديمي يُدعى **sample.pptx** يحتوي على شريحة واحدة، حيث أول شكل هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى ثم نحسب حدود الفقرة الثانية داخل إطار النص الخاص بالشكل. بعد ذلك تُعاد رسم الفقرة على صورة bitmap جديدة تُحفظ بصيغة PNG. هذه الطريقة مفيدة عندما تحتاج إلى حفظ فقرة محددة كصورة منفصلة مع الحفاظ على أبعادها وتنسيقها الأصلي.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // حفظ الشكل في الذاكرة كصورة نقطية.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // إنشاء صورة نقطية للشكل من الذاكرة.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // حساب حدود الفقرة الثانية.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // حساب الإحداثيات والحجم لصورة الإخراج (الحد الأدنى - بكسل واحد × بكسل واحد).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // قص صورة الشكل للحصول فقط على صورة الفقرة.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

النتيجة:

![صورة الفقرة](paragraph_to_image_output.png)

**مثال 2**

في هذا المثال نوسّع النهج السابق بإضافة عوامل تكبير إلى صورة الفقرة. يتم استخراج الشكل من العرض التقديمي وحفظه كصورة بعامل تكبير `2`. يتيح ذلك إنتاج صورة بدقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع مراعاة مقياس التكبير. يُعد التكبير مفيدًا خصوصًا عند الحاجة إلى صورة مفصلة، مثل استخدامها في مواد مطبوعة ذات جودة عالية.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // حفظ الشكل في الذاكرة كصورة نقطية مع التكبير.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // إنشاء صورة نقطية للشكل من الذاكرة.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // حساب حدود الفقرة الثانية.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // حساب الإحداثيات والحجم لصورة الإخراج (الحد الأدنى - بكسل واحد × بكسل واحد).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // قص صورة الشكل للحصول فقط على صورة الفقرة.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكنني تعطيل الالتفاف داخل إطار النص تمامًا؟**

نعم. استخدم إعداد الالتفاف لإطار النص ([setWrapText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) لإيقاف الالتفاف بحيث لا تنكسر الأسطر عند حواف الإطار.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة بدقة؟**

يمكنك استرجاع المستطيل المحيط بالفقرة (وحتى الجزء الفردي) لمعرفة موقعها وحجمها الدقيقين على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يسار/يمين/وسط/ضبط)؟**

`[Alignment](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphformat/#setAlignment-int-)` هو إعداد على مستوى الفقرة في `[ParagraphFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphformat/)`؛ يطبق على الفقرة كاملةً بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق الإملائي لجزء فقط من الفقرة (مثلاً كلمة واحدة)؟**

نعم. اللغة تُضبط على مستوى الجزء عبر `[PortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)`، لذا يمكن أن تتواجد لغات متعددة داخل فقرة واحدة.