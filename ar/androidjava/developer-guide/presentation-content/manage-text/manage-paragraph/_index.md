---
title: إدارة فقرة PowerPoint في Java
type: docs
weight: 40
url: /ar/androidjava/manage-paragraph/
keywords: "إضافة فقرة PowerPoint، إدارة الفقرات، مسافة الفقرة، خصائص الفقرة، نص HTML، تصدير نص الفقرة، عرض PowerPoint، Java، Aspose.Slides for Android عبر Java"
description: "إنشاء وإدارة الفقرة والنص والمسافة وخصائص في عروض PowerPoint في Java"
---

توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في Java.

* توفر Aspose.Slides واجهة [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن أن يحتوي كائن `ITextFrame` على فقرة واحدة أو أكثر (تُنشأ كل فقرة من خلال ضغط إنتر).
* توفر Aspose.Slides واجهة [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) للسماح لك بإضافة كائنات تمثل أجزاء. يمكن أن يحتوي كائن `IParagraph` على جزء واحد أو أكثر (مجموعة من كائنات iPortions).
* توفر Aspose.Slides واجهة [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) للسماح لك بإضافة كائنات تمثل النصوص وخصائص التنسيق الخاصة بها.

يمكن أن يتعامل كائن `IParagraph` مع نصوص بخصائص تنسيق مختلفة من خلال كائناته الأساسية `IPortion`.

## **إضافة عدة فقرات تحتوي على عدة أجزاء**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة شكل مستطيل [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على ITextFrame المرتبطة بـ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
5. إنشاء كائنين [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).
6. إنشاء ثلاثة كائنات [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) لكل `IParagraph` جديد (كائنان Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. تعيين نص معين لكل جزء.
8. تطبيق ميزات التنسيق المفضلة لديك على كل جزء باستخدام خصائص التنسيق التي يوفرها كائن `IPortion`.
9. حفظ العرض المعدل.

هذا الكود Java هو تنفيذ للخطوات الخاصة بإضافة فقرات تحتوي على أجزاء:

```java
// إنشاء مثيل من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة شكل AutoShape من نوع مستطيل
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // الوصول إلى TextFrame لشكل AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // إنشاء فقرات وأجزاء بتنسيقات نص مختلفة
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


## **إدارة النقاط في الفقرات**

تساعد قوائم النقاط في تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات ذات النقاط تكون دائمًا أسهل في القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) لشكل autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. تعيين نوع النقطة للفقرة إلى `Symbol` وتعيين حرف النقطة.
8. تعيين نص الفقرة.
9. تعيين مسافة الفقرة للنقطة.
10. تعيين لون للنقطة.
11. تعيين ارتفاع النقطة.
12. إضافة الفقرة الجديدة إلى مجموعة الفقرات في `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية الممنوحة في الخطوات من 7 إلى 13.
14. حفظ العرض.

هذا الكود Java يوضح لك كيفية إضافة نقطة فقرة:

```java
// إنشاء مثيل من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار نص autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // إزالة الفقرة الافتراضية
    txtFrm.getParagraphs().removeAt(0);

    // إنشاء فقرة
    Paragraph para = new Paragraph();

    // تعيين نمط النقطة للحقل ورمز
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // تعيين نص الفقرة
    para.setText("مرحبًا بك في Aspose.Slides");

    // تعيين مسافة النقطة
    para.getParagraphFormat().setIndent(25);

    // تعيين لون النقطة
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // تعيين IsBulletHardColor إلى true لاستخدام لون النقطة الخاص

    // تعيين ارتفاع النقطة
    para.getParagraphFormat().getBullet().setHeight(100);

    // إضافة فقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);

    // إنشاء فقرة الثانية
    Paragraph para2 = new Paragraph();

    // تعيين نوع النقطة ونمطها
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // إضافة نص الفقرة
    para2.setText("هذه نقطة مرقمة");

    // تعيين مسافة النقطة
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // تعيين IsBulletHardColor إلى true لاستخدام لون النقطة الخاص

    // تعيين ارتفاع النقطة
    para2.getParagraphFormat().getBullet().setHeight(100);

    // إضافة فقرة إلى إطار النص
    txtFrm.getParagraphs().add(para2);
    
    // حفظ العرض المعدل
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة النقاط بالصورة**

تساعد قوائم النقاط في تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات الخاصة بالصور سهلة القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) لشكل autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).
8. تعيين نوع النقطة إلى [Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) وتعيين الصورة.
9. تعيين نص الفقرة.
10. تعيين مسافة الفقرة للنقطة.
11. تعيين لون للنقطة.
12. تعيين ارتفاع للنقطة.
13. إضافة الفقرة الجديدة إلى مجموعة الفقرات في `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض المعدل.

هذا الكود Java يوضح لك كيفية إضافة وإدارة النقاط بالصورة:

```java
// إنشاء مثيل من فئة Presentation تمثل ملف PPTX
Presentation presentation = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = presentation.getSlides().get_Item(0);

    // إنشاء الصورة للنقاط
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // إضافة والوصول إلى Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى الإطار النصي للشكل autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // إزالة الفقرة الافتراضية
    textFrame.getParagraphs().removeAt(0);

    // إنشاء فقرة جديدة
    Paragraph paragraph = new Paragraph();
    paragraph.setText("مرحبًا بك في Aspose.Slides");

    // تعيين نمط النقطة للفقرة والصورة
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // تعيين ارتفاع النقطة
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // إضافة الفقرة إلى إطار النص
    textFrame.getParagraphs().add(paragraph);

    // كتابة العرض كملف PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // كتابة العرض كملف PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **إدارة النقاط متعددة المستويات**

تساعد قوائم النقاط في تنظيم وتقديم المعلومات بسرعة وكفاءة. النقاط متعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) لشكل autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى من خلال الفئة [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء مثيل الفقرة الثانية من خلال الفئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء مثيل الفقرة الثالثة من خلال الفئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء مثيل الفقرة الرابعة من خلال الفئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة الفقرات في `TextFrame`.
11. حفظ العرض المعدل.

هذا الكود Java يوضح لك كيفية إضافة وإدارة النقاط متعددة المستويات:

```java
// إنشاء مثيل من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة والوصول إلى Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى الإطار النصي للشكل autoshape
    ITextFrame text = aShp.addTextFrame("");

    // مسح الفقرة الافتراضية
    text.getParagraphs().clear();

    // إضافة الفقرة الأولى
    IParagraph para1 = new Paragraph();
    para1.setText("المحتوى");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para1.getParagraphFormat().setDepth((short)0);

    // إضافة الفقرة الثانية
    IParagraph para2 = new Paragraph();
    para2.setText("المستوى الثاني");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para2.getParagraphFormat().setDepth((short)1);

    // إضافة الفقرة الثالثة
    IParagraph para3 = new Paragraph();
    para3.setText("المستوى الثالث");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para3.getParagraphFormat().setDepth((short)2);

    // إضافة الفقرة الرابعة
    IParagraph para4 = new Paragraph();
    para4.setText("المستوى الرابع");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para4.getParagraphFormat().setDepth((short)3);

    // إضافة الفقرات إلى المجموعة
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // كتابة العرض كملف PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة الفقرة بقائمة مرقمة مخصصة**

توفر واجهة [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) الخصائص مثل [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) وغيرها التي تسمح لك بإدارة الفقرات مع ترقيم أو تنسيق مخصص.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) لشكل autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى من خلال الفئة [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى 2.
7. إنشاء مثيل الفقرة الثانية من خلال الفئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء مثيل الفقرة الثالثة من خلال الفئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة الفقرات في `TextFrame`.
10. حفظ العرض المعدل.

هذا الكود Java يوضح لك كيفية إضافة وإدارة الفقرات مع ترقيم أو تنسيق مخصص:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى الإطار النصي لشكل autoshape
    ITextFrame textFrame = shape.getTextFrame();

    // إزالة الفقرة الافتراضية الموجودة
    textFrame.getParagraphs().removeAt(0);

    // أول قائمة
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("النقطة 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("النقطة 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("النقطة 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **تعيين مسافة الفقرة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) مع ثلاث فقرات إلى الشكل المستطيل autoshape.
1. إخفاء خطوط المستطيل.
1. تعيين المسافة لكل [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) من خلال خاصية BulletOffset.
1. كتابة العرض المعدل كملف PPT.

هذا الكود Java يوضح لك كيفية تعيين مسافة الفقرة:

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إضافة شكل مستطيل
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // إضافة TextFrame إلى الشكل المستطيل
    ITextFrame tf = rect.addTextFrame("هذا هو السطر الأول \rهذا هو السطر الثاني \rهذا هو السطر الثالث");
    
    // تعيين النص ليتناسب مع الشكل
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // إخفاء خطوط الشكل المستطيل
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // الحصول على الفقرة الأولى في TextFrame وتعيين مسافتها
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // تعيين نمط النقطة للفقرة ورمز
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // الحصول على الفقرة الثانية في TextFrame وتعيين مسافتها
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // الحصول على الفقرة الثالثة في TextFrame وتعيين مسافتها
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    // كتابة العرض إلى القرص
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين المسافة المعلقة للفقرة**

هذا الكود Java يوضح لك كيفية تعيين المسافة المعلقة لفقرة:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("مثال");

    Paragraph para2 = new Paragraph();
    para2.setText("تعيين المسافة المعلقة للفقرة");

    Paragraph para3 = new Paragraph();
    para3.setText("يوضح لك هذا الكود C# كيفية تعيين المسافة المعلقة لفقرة: ");

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

## **إدارة خصائص نهاية فقرة الفقرة**

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة من خلال موضعها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) مع فقرتين إلى المستطيل.
1. تعيين `FontHeight` ونوع الخط للفقرات.
1. تعيين خصائص النهاية للفقرات.
1. كتابة العرض المعدل كملف PPTX.

هذا الكود Java يوضح لك كيفية تعيين خصائص النهاية للفقرات في PowerPoint: 

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("نص عينة"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("نص عينة 2"));

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

توفر Aspose.Slides دعمًا معززًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في TextReader.
7. إنشاء مثيل الفقرة الأولى من خلال الفئة [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML في TextReader المقروء إلى مجموعة [ParagraphCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/) الخاصة بـ TextFrame.
9. حفظ العرض المعدل.

هذا الكود Java هو تنفيذ للخطوات الخاصة باستيراد نصوص HTML في الفقرات:

```java
// إنشاء مثيل عرض فارغ
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى الافتراضية للعرض
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة الشكل AutoShape لاستيعاب محتوى HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // إضافة إطار نص إلى الشكل
    ashape.addTextFrame("");

    // مسح جميع الفقرات في إطار النص المضاف
    ashape.getTextFrame().getParagraphs().clear();

    // تحميل ملف HTML باستخدام قارئ النصوص
    TextReader tr = new StreamReader("file.html");

    // إضافة النص من تدفق HTML في إطار النص
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // حفظ العرض
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تصدير نص الفقرات إلى HTML**

توفر Aspose.Slides دعمًا معززًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class وتحميل العرض المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيتم تصديره إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء مثيل لـ `StreamWriter` وإضافة ملف HTML الجديد.
6. تقديم فهرس بدء لـ StreamWriter وتصدير الفقرات المفضلة لديك.

هذا الكود Java يوضح لك كيفية تصدير نصوص الفقرات في PowerPoint إلى HTML:

```java
// تحميل ملف العرض
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // الوصول إلى الشريحة الأولى الافتراضية للعرض
    ISlide slide = pres.getSlides().get_Item(0);

    // فهرس المطلوب
    int index = 0;

    // الوصول إلى الشكل المضاف
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // إنشاء ملف HTML الناتج
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // استخراج الفقرة الأولى كـ HTML
    // كتابة بيانات الفقرات إلى HTML من خلال تقديم فهرس بدء الفقرة، وإجمالي الفقرات المراد نسخها
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```