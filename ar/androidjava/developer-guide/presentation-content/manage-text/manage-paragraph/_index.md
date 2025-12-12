---
title: إدارة فقرات نص PowerPoint على Android
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/androidjava/manage-paragraph/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة نص
- إدارة فقرة
- إدارة نقط
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
- Android
- Java
- Aspose.Slides
description: "تحكم كامل في تنسيق الفقرات باستخدام Aspose.Slides لنظام Android—حسّن المحاذاة والمسافات والنمط في عروض PPT و PPTX و ODP باستخدام Java."
---

توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في Java.

* تقدم Aspose.Slides الواجهة [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو متعددة (يتم إنشاء كل فقرة عن طريق إرجاع السطر).
* تقدم Aspose.Slides الواجهة [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) للسماح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `IParagraph` أن يحتوي على جزء واحد أو متعددة (مجموعة من كائنات iPortions).
* تقدم Aspose.Slides الواجهة [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) للسماح لك بإضافة كائنات تمثل النصوص وخصائص تنسيقها.

كائن `IParagraph` قادر على معالجة النصوص ذات خصائص التنسيق المختلفة عبر كائناته الأساسية `IPortion`.

## **إضافة فقرات متعددة تحتوي على أجزاء نصية متعددة**

تُظهر هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة مستطيل [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على ITextFrame المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
5. إنشاء كائنين من [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).
6. إنشاء ثلاثة كائنات من [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) لكل `IParagraph` جديد (كائنان من Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. تعيين نص لكل جزء.
8. تطبيق ميزات التنسيق المفضلة على كل جزء باستخدام خصائص التنسيق التي يوفرها كائن `IPortion`.
9. حفظ العرض التقديمي المعدل.

```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // الوصول إلى TextFrame الخاص بـ AutoShape
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

    // حفظ PPTX إلى القرص
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة تعداد الفقرات النقطية**

تساعد القوائم النقطية في تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات النقطية دائمًا ما تكون أسهل في القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. تعيين `Type` للرصاص إلى `Symbol` وتحديد حرف الرصاصة.
8. تعيين نص الفقرة.
9. تعيين `Indent` للرصاص.
10. تعيين لون للرصاص.
11. تعيين ارتفاع للرصاص.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية من الخطوة 7 إلى 13.
14. حفظ العرض التقديمي.

```java
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // يضيف ويصل إلى AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص للـ AutoShape
    ITextFrame txtFrm = aShp.getTextFrame();

    // يزيل الفقرة الافتراضية
    txtFrm.getParagraphs().removeAt(0);

    // ينشئ فقرة
    Paragraph para = new Paragraph();

    // يحدد نمط الرصاصة للفقرة والرمز
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // يحدد نص الفقرة
    para.setText("Welcome to Aspose.Slides");

    // يحدد إزاحة الرصاصة
    para.getParagraphFormat().setIndent(25);

    // يحدد لون الرصاصة
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // تعيين IsBulletHardColor إلى true لاستخدام لون الرصاصة الخاص

    // يحدد ارتفاع الرصاصة
    para.getParagraphFormat().getBullet().setHeight(100);

    // يضيف الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);

    // ينشئ الفقرة الثانية
    Paragraph para2 = new Paragraph();

    // يحدد نوع الرصاصة للفقرة والنمط
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // يضيف نص الفقرة
    para2.setText("This is numbered bullet");

    // يحدد إزاحة الرصاصة
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // تعيين IsBulletHardColor إلى true لاستخدام لون الرصاصة الخاص

    // يحدد ارتفاع الرصاصة
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

تساعد القوائم النقطية في تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات التي تحتوي على صور سهلة القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).
8. تعيين نوع الرصاص إلى [Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) وتحديد الصورة.
9. تعيين نص الفقرة.
10. تعيين `Indent` للرصاص.
11. تعيين لون للرصاص.
12. تعيين ارتفاع للرصاص.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.

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
    // يضيف ويصل إلى AutoShape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص للـ AutoShape
    ITextFrame textFrame = autoShape.getTextFrame();

    // يزيل الفقرة الافتراضية
    textFrame.getParagraphs().removeAt(0);

    // ينشئ فقرة جديدة
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // يحدد نمط رصاص الفقرة والصورة
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // يحدد ارتفاع الرصاص
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


## **إدارة رصاصات متعددة المستويات**

تساعد القوائم النقطية في تنظيم وعرض المعلومات بسرعة وكفاءة. رصاصات متعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء مثال الفقرة الثاني عبر الفئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء مثال الفقرة الثالث عبر الفئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء مثال الفقرة الرابع عبر الفئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض التقديمي المعدل.

```java
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة والوصول إلى AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للـ AutoShape المخلق
    ITextFrame text = aShp.addTextFrame("");

    // مسح الفقرة الافتراضية
    text.getParagraphs().clear();

    // إضافة الفقرة الأولى
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى الرصاصة
    para1.getParagraphFormat().setDepth((short)0);

    // إضافة الفقرة الثانية
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى الرصاصة
    para2.getParagraphFormat().setDepth((short)1);

    // إضافة الفقرة الثالثة
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى الرصاصة
    para3.getParagraphFormat().setDepth((short)2);

    // إضافة الفقرة الرابعة
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى الرصاصة
    para4.getParagraphFormat().setDepth((short)3);

    // إضافة الفقرات إلى المجموعة
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // حفظ العرض التقديمي كملف PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة فقرة مع قائمة مرقمة مخصصة**

توفر الواجهة [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) وغيرها التي تسمح لك بإدارة الفقرات ذات الترقيم أو التنسيق المخصص.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى 2.
7. إنشاء مثال الفقرة الثاني عبر الفئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء مثال الفقرة الثالث عبر الفئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض التقديمي المعدل.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص للـ AutoShape المُنشأ
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


## **تعيين إزاحة الفقرة**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
1. إضافة مستطيل [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) يحتوي على ثلاث فقرات إلى المستطيل.
1. إخفاء خطوط المستطيل.
1. تعيين الإزاحة لكل [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) عبر خاصية BulletOffset.
1. كتابة العرض التقديمي المعدل كملف PPT.

```java
// إنشاء فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إضافة شكل مستطيل
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // إضافة TextFrame إلى المستطيل
    ITextFrame tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    
    // ضبط النص لملء الشكل
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // إخفاء خطوط المستطيل
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // الحصول على الفقرة الأولى في TextFrame وتعيين إزاحتها
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // تعيين نمط الرصاصة للفقرة والرمز
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // الحصول على الفقرة الثانية في TextFrame وتعيين إزاحتها
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // الحصول على الفقرة الثالثة في TextFrame وتعيين إزاحتها
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    // كتابة العرض التقديمي إلى القرص
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين إزاحة معلقة لفقرة**

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("Example");

    Paragraph para2 = new Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");

    Paragraph para3 = new Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");

    para2.getParagraphFormat().setMarginLeft(10f);
    para3.getParagraphFormat().setMarginLeft(20f);

    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة خصائص تشغيل الفقرة النهاية**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موقعها.
1. إضافة مستطيل [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) يحتوي على فقرتين إلى المستطيل.
1. تعيين `FontHeight` ونوع الخط للفقرات.
1. تعيين خصائص End للفقرات.
1. كتابة العرض التقديمي المعدل كملف PPTX.

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


## **استيراد نص HTML إلى فقرات**

توفر Aspose.Slides دعمًا محسنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في TextReader.
7. إنشاء أول مثال للفقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء من TextReader إلى [ParagraphCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/) الخاص بـ TextFrame.
9. حفظ العرض التقديمي المعدل.

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

    // إضافة TextFrame إلى الشكل
    ashape.addTextFrame("");

    // مسح جميع الفقرات في TextFrame المضاف
    ashape.getTextFrame().getParagraphs().clear();

    // تحميل ملف HTML باستخدام StreamReader
    TextReader tr = new StreamReader("file.html");

    // إضافة النص من StreamReader الخاص بـ HTML إلى TextFrame
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // حفظ العرض التقديمي
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تصدير نص الفقرة إلى HTML**

توفر Aspose.Slides دعمًا محسنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى مرجع الشريحة المطلوبة عبر فهرستها.
3. الوصول إلى الشكل الذي يحتوي على النص المراد تصديره إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء مثال من `StreamWriter` وإضافة ملف HTML الجديد.
6. تحديد فهرس البداية لـ StreamWriter وتصدير الفقرات المفضلة لديك.

```java
// تحميل ملف العرض التقديمي
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // الفهرس المطلوب
    int index = 0;

    // الوصول إلى الشكل المضاف
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // إنشاء ملف HTML للإخراج
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // استخراج الفقرة الأولى كـ HTML
    // كتابة بيانات الفقرات إلى HTML عن طريق تحديد فهرس بداية الفقرة وإجمالي الفقرات المراد نسخها
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **حفظ الفقرة كصورة**

في هذا القسم، نستعرض مثالين يوضحان كيفية حفظ الفقرة النصية، الممثلة بواجهة [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/)، كصورة. يتضمن كل مثال الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام أسلوب `getImage` من واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تتيح هذه الطرق استخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة للاستخدام في سيناريوهات مختلفة.

لنفترض أن لدينا ملف عرض تقديمي اسمه sample.pptx يحتوي على شريحة واحدة، حيث أول شكل هو صندوق نص يحتوي على ثلاث فقرات.

![The text box with three paragraphs](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. يتم ذلك باستخراج صورة الشكل من الشريحة الأولى للعرض التقديمي ثم حساب حدود الفقرة الثانية في إطار النص الخاص بالشكل. ثم تُعاد رسم الفقرة على صورة bitmap جديدة تُحفظ بصيغة PNG. هذه الطريقة مفيدة عندما تحتاج إلى حفظ فقرة معينة كصورة منفصلة مع الحفاظ على أبعاد وتنسيق النص الأصلي.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // احفظ الشكل في الذاكرة كصورة bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // أنشئ صورة bitmap للشكل من الذاكرة.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // احسب حدود الفقرة الثانية.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // احسب إحداثيات وحجم الصورة الناتجة (الحد الأدنى - بكسل واحد 1x1).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // قص صورة bitmap للشكل للحصول فقط على صورة bitmap للفقرة.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


النتيجة:

![The paragraph image](paragraph_to_image_output.png)

**مثال 2**

في هذا المثال، نُوسِّع النهج السابق بإضافة عوامل تكبير إلى صورة الفقرة. يُستخرج الشكل من العرض التقديمي وتُحفظ صوريًا بعامل تكبير `2`. يتيح ذلك إخراجًا بدقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع مراعاة التكبير. يمكن أن يكون التكبير مفيدًا عندما تحتاج إلى صورة ذات تفاصيل أكثر، مثل الاستخدام في مواد مطبوعة عالية الجودة.
```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // حفظ الشكل في الذاكرة كصورة bitmap مع التكبير.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // إنشاء صورة bitmap للشكل من الذاكرة.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // حساب حدود الفقرة الثانية.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // حساب إحداثيات وحجم الصورة الناتجة (الحد الأدنى - بكسل واحد 1x1).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // قص صورة bitmap للشكل للحصول فقط على صورة bitmap للفقرة.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكني إيقاف الالتفاف داخل إطار النص تمامًا؟**

نعم. استخدم إعداد الالتفاف لإطار النص ([setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) لتعطيل الالتفاف بحيث لا تنكسر الأسطر عند حواف الإطار.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة؟**

يمكنك استرجاع المستطيل المحيط بالفقرة (وحتى الجزء الواحد) لمعرفة موقعها وحجمها الدقيق على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يسار/يمين/وسط/ضبط)؟**

[Alignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) هو إعداد على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/); وهو يُطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق الإملائي لجزء من الفقرة فقط (مثلاً كلمة واحدة)؟**

نعم. تُحدد اللغة على مستوى الجزء ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-))، وبالتالي يمكن وجود لغات متعددة داخل نفس الفقرة.