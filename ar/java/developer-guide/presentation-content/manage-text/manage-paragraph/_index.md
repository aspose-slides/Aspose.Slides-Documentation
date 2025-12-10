---
title: إدارة فقرات نص PowerPoint في Java
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/java/manage-paragraph/
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
- الفقرة إلى HTML
- الفقرة إلى صورة
- نص إلى صورة
- تصدير الفقرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إتقان تنسيق الفقرات باستخدام Aspose.Slides للـ Java — تحسين المحاذاة والمسافات والأنماط في عروض PPT و PPTX و ODP في Java."
---

Aspose.Slides توفر جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في Java.

* Aspose.Slides توفر الواجهة [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو متعددة (كل فقرة تُنشأ عبر عودة السطر).
* Aspose.Slides توفر الواجهة [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) للسماح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `IParagraph` أن يحتوي على جزء واحد أو متعدد (مجموعة من كائنات iPortions).
* Aspose.Slides توفر الواجهة [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) للسماح لك بإضافة كائنات تمثل نصوص وخصائص تنسيقها.

كائن `IParagraph` قادر على معالجة النصوص ذات الخصائص التنسيقية المختلفة عبر كائنات `IPortion` الأساسية الخاصة به.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

تُظهر هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة مستطيل [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على ITextFrame المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
5. إنشاء كائنين من النوع [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).
6. إنشاء ثلاثة كائنات من النوع [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) لكل `IParagraph` جديد (جزئين للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. تعيين نص لكل جزء.
8. تطبيق ميزات التنسيق المفضلة على كل جزء باستخدام خصائص التنسيق التي يوفرها كائن `IPortion`.
9. حفظ العرض التقديمي المعدل.

هذا الكود Java هو تنفيذ للخطوات لإضافة فقرات تحتوي على أجزاء:
```java
// إنشاء كائن من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع مستطيل
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // الوصول إلى TextFrame الخاص بـ AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // إنشاء فقرات وأجزاء بتنسيقات نصية مختلفة
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

    // كتابة ملف PPTX إلى القرص
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة نقاط القوائم الفقرية**

قوائم النقاط تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات النقطية دائمًا أسهل في القراءة والفهم.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة المختارة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
7. تعيين نوع النقطة `Type` للفقرة إلى `Symbol` وتحديد حرف النقطة.
8. تعيين `Text` للفقرة.
9. تعيين `Indent` للفقرة للنقطة.
10. تعيين لون للنقطة.
11. تعيين ارتفاع للنقطة.
12. إضافة الفقرة الجديدة إلى مجموعة الفقرات في `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية من الخطوة 7 إلى 13.
14. حفظ العرض التقديمي.

هذا الكود Java يوضح كيفية إضافة نقطة فقرة:
```java
// ينشئ كائنًا من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للـ AutoShape
    ITextFrame txtFrm = aShp.getTextFrame();

    // إزالة الفقرة الافتراضية
    txtFrm.getParagraphs().removeAt(0);

    // إنشاء فقرة
    Paragraph para = new Paragraph();

    // تعيين نمط نقطة الفقرة والرمز
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // تعيين نص الفقرة
    para.setText("Welcome to Aspose.Slides");

    // تعيين إزاحة النقطة
    para.getParagraphFormat().setIndent(25);

    // تعيين لون النقطة
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // تعيين IsBulletHardColor إلى true لاستخدام لون النقطة الخاص

    // تعيين ارتفاع النقطة
    para.getParagraphFormat().getBullet().setHeight(100);

    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);

    // إنشاء الفقرة الثانية
    Paragraph para2 = new Paragraph();

    // تعيين نوع نمط نقطة الفقرة
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // إضافة نص الفقرة
    para2.setText("This is numbered bullet");

    // تعيين إزاحة النقطة
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // تعيين IsBulletHardColor إلى true لاستخدام لون النقطة الخاص

    // تعيين ارتفاع النقطة
    para2.getParagraphFormat().getBullet().setHeight(100);

    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para2);
    
    // حفظ العرض التقديمي المعدل
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة نقاط الصور**

قوائم النقاط تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات التي تحتوي على صور سهلة القراءة والفهم.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
7. تحميل الصورة عبر [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/).
8. تعيين نوع النقطة إلى [Picture](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) وتحديد الصورة.
9. تعيين `Text` للفقرة.
10. تعيين `Indent` للفقرة للنقطة.
11. تعيين لون للنقطة.
12. تعيين ارتفاع للنقطة.
13. إضافة الفقرة الجديدة إلى مجموعة الفقرات في `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.

هذا الكود Java يوضح كيفية إضافة وإدارة نقاط الصور:
```java
// ينشئ كائن Presentation يمثل ملف PPTX
Presentation presentation = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide slide = presentation.getSlides().get_Item(0);

    // ينشئ صورة للنقاط
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

    // يحدد نمط نقطة الفقرة والصورة
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // يحدد ارتفاع النقطة
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // يضيف الفقرة إلى إطار النص
    textFrame.getParagraphs().add(paragraph);

    // يكتب العرض التقديمي كملف PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // يكتب العرض التقديمي كملف PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **إدارة النقاط متعددة المستويات**

قوائم النقاط تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة. النقاط متعددة المستويات سهلة القراءة والفهم.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء مثال الفقرة الثاني عبر فئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء مثال الفقرة الثالث عبر فئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء مثال الفقرة الرابع عبر فئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة الفقرات في `TextFrame`.
11. حفظ العرض التقديمي المعدل.

هذا الكود Java يوضح كيفية إضافة وإدارة النقاط متعددة المستويات:
```java
// ينشئ كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف ويصل إلى AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص للـ AutoShape المنشأ
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
    // يحدد مستوى النقطة
    para1.getParagraphFormat().setDepth((short)0);

    // يضيف الفقرة الثانية
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // يحدد مستوى النقطة
    para2.getParagraphFormat().setDepth((short)1);

    // يضيف الفقرة الثالثة
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // يحدد مستوى النقطة
    para3.getParagraphFormat().setDepth((short)2);

    // يضيف الفقرة الرابعة
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // يحدد مستوى النقطة
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


## **إدارة فقرة بقائمة رقمية مخصصة**

توفر الواجهة [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) وغيرها التي تسمح لك بإدارة الفقرات باستخدام ترقيم أو تنسيق مخصص.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى 2.
7. إنشاء مثال الفقرة الثاني عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء مثال الفقرة الثالث عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة الفقرات في `TextFrame`.
10. حفظ العرض التقديمي المعدل.

هذا الكود Java يوضح كيفية إضافة وإدارة الفقرات ذات الترقيم أو التنسيق المخصص:
```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للـ AutoShape المُنشأ
    ITextFrame textFrame = shape.getTextFrame();

    // إزالة الفقرة الافتراضية الموجودة
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

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
1. إضافة [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) مستطيل إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) يحتوي على ثلاث فقرات إلى الشكل المستطيل.
1. إخفاء خطوط المستطيل.
1. تعيين الإزاحة لكل [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) عبر خاصية BulletOffset.
1. كتابة العرض التقديمي المعدل كملف PPT.

هذا الكود Java يوضح كيفية تعيين إزاحة الفقرة:
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
    
    // تعيين النص ليتناسب مع الشكل
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // إخفاء خطوط المستطيل
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // الحصول على الفقرة الأولى في TextFrame وتعيين إزاحتها
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // تعيين نمط نقطة الفقرة والرمز
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
    
    // حفظ العرض التقديمي إلى القرص
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين إزاحة معلّقة لفقرة**

هذا الكود Java يوضح كيفية تعيين إزاحة معلّقة لفقرة:
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


## **إدارة خصائص تشغيل الفقرة النهائية**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موقعها.
1. إضافة [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) مستطيل إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) يحتوي على فقرتين إلى المستطيل.
1. تعيين `FontHeight` ونوع الخط للفقرات.
1. تعيين خصائص End للفقرات.
1. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود Java يوضح كيفية تعيين خصائص End للفقرات في PowerPoint:
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

توفر Aspose.Slides دعمًا محسنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في TextReader.
7. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء من TextReader إلى [ParagraphCollection](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/) الخاص بـ TextFrame.
9. حفظ العرض التقديمي المعدل.

هذا الكود Java هو تنفيذ للخطوات لاستيراد نصوص HTML إلى الفقرات:
```java
// إنشاء مثال عرض تقديمي فارغ
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

    // مسح جميع الفقرات في TextFrame المضافة
    ashape.getTextFrame().getParagraphs().clear();

    // تحميل ملف HTML باستخدام StreamReader
    TextReader tr = new StreamReader("file.html");

    // إضافة النص من StreamReader للـ HTML إلى TextFrame
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // حفظ العرض التقديمي
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تصدير نص الفقرة إلى HTML**

توفر Aspose.Slides دعمًا محسنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. الوصول إلى الشكل الذي يحتوي على النص المراد تصديره إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء نسخة من `StreamWriter` وإضافة ملف HTML جديد.
6. تحديد فهرس البداية إلى StreamWriter وتصدير الفقرات المفضلة لديك.

هذا الكود Java يوضح كيفية تصدير نصوص فقرات PowerPoint إلى HTML:
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

    //استخراج الفقرة الأولى كـ HTML
    // كتابة بيانات الفقرات إلى HTML عن طريق تحديد فهرس بداية الفقرة وإجمالي الفقرات المراد نسخها
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **حفظ الفقرة كصورة**

في هذا القسم، نستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بواجهة [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/)، كصورة. يتضمن كلا المثالين الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طريقة `getImage` من واجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة بتنسيق bitmap. تُتيح هذه الأساليب استخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، ما قد يكون مفيدًا لاستخدامات مختلفة.

لنفترض أن لدينا ملف عرض تقديمي يُدعى sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو صندوق نص يحتوي على ثلاث فقرات.

![The text box with three paragraphs](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض التقديمي ثم نحسب حدود الفقرة الثانية داخل إطار النص الخاص بالشكل. يتم بعد ذلك إعادة رسم الفقرة على صورة bitmap جديدة، تُحفظ بصيغة PNG. هذه الطريقة مفيدة عندما تحتاج إلى حفظ فقرة معينة كصورة منفصلة مع الحفاظ على الأبعاد والتنسيق الأصلي للنص.
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
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // احسب إحداثيات وحجم الصورة الناتجة (الحد الأدنى - بكسل 1×1).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // قص صورة bitmap للشكل للحصول على صورة bitmap للفقرة فقط.
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

في هذا المثال، نمدّد النهج السابق بإضافة عوامل مقياس لصورة الفقرة. يتم استخراج الشكل من العرض التقديمي وحفظه كصورة بمعامل مقياس `2`. يتيح ذلك إخراجًا بدقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع مراعاة المقياس. يمكن أن يكون المقياس مفيدًا عندما تحتاج إلى صورة أكثر تفصيلاً، مثل استخدامها في مواد مطبوعة عالية الجودة.
```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // احفظ الشكل في الذاكرة كصورة bitmap مع التحجيم.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // أنشئ صورة bitmap للشكل من الذاكرة.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // احسب حدود الفقرة الثانية.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // احسب إحداثيات وحجم الصورة الناتجة (الحد الأدنى - بكسل 1×1).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // قص صورة bitmap للشكل للحصول على صورة bitmap للفقرة فقط.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني إلغاء تمكين التفاف الأسطر داخل إطار النص تمامًا؟**

نعم. استخدم إعداد التفاف إطار النص ([setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) لإيقاف التفاف الأسطر بحيث لا تنكسر عند حدود الإطار.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة بدقة؟**

يمكنك استرجاع المستطيل المحيط بالفقرة (أو حتى جزء واحد) لمعرفة موقعها الدقيق وحجمها على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يسار/يمين/وسط/ضبط)؟**

[Alignment](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setAlignment-int-) هو إعداد على مستوى الفقرة داخل [ParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/); يُطبق على الفقرة بأكملها بغض النظر عن تنسيق كل جزء.

**هل يمكنني تعيين لغة التدقيق الإملائي لجزء معين من الفقرة (مثلاً كلمة واحدة)؟**

نعم. اللغة تُحدد على مستوى الجزء ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-))، لذا يمكن أن تتواجد لغات متعددة داخل فقرة واحدة.