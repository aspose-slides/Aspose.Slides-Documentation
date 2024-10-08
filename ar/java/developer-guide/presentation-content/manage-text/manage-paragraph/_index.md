---
title: إدارة فقرة PowerPoint في جافا
type: docs
weight: 40
url: /ar/java/manage-paragraph/
keywords: "إضافة فقرة PowerPoint، إدارة الفقرات، إزاحة الفقرة، خصائص الفقرة، نص HTML، تصدير نص الفقرة، عرض PowerPoint، جافا، Aspose.Slides لجافا"
description: "إنشاء وإدارة فقرة، نص، إزاحة، وخصائص في عروض PowerPoint في جافا"
---

توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint، الفقرات، والأجزاء في جافا.

* توفر Aspose.Slides واجهة [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن أن يحتوي كائن `ITextFame` على فقرة واحدة أو أكثر (كل فقرة يتم إنشاؤها من خلال إدخال سطر جديد).
* توفر Aspose.Slides واجهة [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) للسماح لك بإضافة كائنات تمثل أجزاء. يمكن أن يحتوي كائن `IParagraph` على جزء واحد أو أكثر (مجموعة من كائنات iPortions).
* توفر Aspose.Slides واجهة [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) للسماح لك بإضافة كائنات تمثل النصوص وخصائص تنسيقها.

يمكن كائن `IParagraph` معالجة النصوص باستخدام خصائص تنسيق مختلفة من خلال كائناته الأساسية `IPortion`.

## **إضافة عدة فقرات تحتوي على عدة أجزاء**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المعنية من خلال فهرسها.
3. إضافة شكل مستطيل [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على ITextFrame المرتبطة بـ [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
5. إنشاء كائنين [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` من [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).
6. إنشاء ثلاثة كائنات [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) لكل `IParagraph` جديد (كائنين Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion لكل `IParagraph`.
7. تعيين بعض النصوص لكل جزء.
8. تطبيق ميزات التنسيق المفضلة لديك على كل جزء باستخدام خصائص التنسيق التي يقدمها كائن `IPortion`.
9. حفظ العرض المعدل.

هذا الكود في جافا هو تنفيذ للخطوات الخاصة بإضافة فقرات تحتوي على أجزاء:

```java
// إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة شكل أوتوماتيكي من نوع المستطيل
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // الوصول إلى إطار النص الخاص بالشكل الأوتوماتيكي
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


## **إدارة رموز الفقرات النقطية**

تساعد قوائم النقاط في تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات النقطية دائمًا ما تكون أسهل قراءة وفهمًا.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المعنية من خلال فهرسها.
3. إضافة [شكل أوتوماتيكي](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) الخاص بالشكل الأوتوماتيكي. 
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
7. تعيين نوع الرمز `Type` للفقرة إلى `Symbol` وتعيين رمز الفقرة.
8. تعيين `Text` الفقرة.
9. تعيين `Indent` الفقرة للرمز.
10. تعيين لون للرمز.
11. تعيين ارتفاع الرمز.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات 7 إلى 13.
14. حفظ العرض.

هذا الكود في جافا يوضح لك كيفية إضافة رمز فقرة:

```java
// إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى الشكل الأوتوماتيكي
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص الخاص بالشكل الأوتوماتيكي
    ITextFrame txtFrm = aShp.getTextFrame();

    // إزالة الفقرة الافتراضية
    txtFrm.getParagraphs().removeAt(0);

    // إنشاء فقرة
    Paragraph para = new Paragraph();

    // تعيين نمط رمز الفقرة والرمز
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // تعيين نص الفقرة
    para.setText("مرحبًا بك في Aspose.Slides");

    // تعيين إزاحة الرمز
    para.getParagraphFormat().setIndent(25);

    // تعيين لون الرمز
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // تعيين IsBulletHardColor إلى true لاستخدام لون الرمز الخاص

    // تعيين ارتفاع الرمز
    para.getParagraphFormat().getBullet().setHeight(100);

    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);

    // إنشاء فقرة ثانية
    Paragraph para2 = new Paragraph();

    // تعيين نوع ورمز الفقرة النقطية
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // إضافة نص الفقرة
    para2.setText("هذا هو الرمز النقطي المرقم");

    // تعيين إزاحة الرمز
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // تعيين IsBulletHardColor إلى true لاستخدام لون الرموز الخاصة

    // تعيين ارتفاع الرمز
    para2.getParagraphFormat().getBullet().setHeight(100);

    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para2);
    
    // حفظ العرض المعدل
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة رموز الصور**

تساعد قوائم النقاط في تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات المصورة سهلة القراءة والفهم.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المعنية من خلال فهرسها.
3. إضافة [شكل أوتوماتيكي](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) الخاص بالشكل الأوتوماتيكي. 
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/).
8. تعيين نوع الرمز إلى [Picture](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) وتعيين الصورة.
9. تعيين نص الفقرة.
10. تعيين إزاحة الفقرة للرمز.
11. تعيين لون للرمز.
12. تعيين ارتفاع للرمز.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض المعدل.

هذا الكود في جافا يوضح لك كيفية إضافة وإدارة رموز الصور:

```java
// إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
Presentation presentation = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = presentation.getSlides().get_Item(0);

    // إنشاء الصورة للرموز
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // إضافة والوصول إلى شكل أوتوماتيكي
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص الخاص بالشكل الأوتوماتيكي
    ITextFrame textFrame = autoShape.getTextFrame();

    // إزالة الفقرة الافتراضية
    textFrame.getParagraphs().removeAt(0);

    // إنشاء فقرة جديدة
    Paragraph paragraph = new Paragraph();
    paragraph.setText("مرحبًا بك في Aspose.Slides");

    // تعيين نمط رمز الفقرة والصورة
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // تعيين ارتفاع الرمز
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

تساعد قوائم النقاط في تنظيم وعرض المعلومات بسرعة وكفاءة. نقاط متعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. الوصول إلى مرجع الشريحة المعنية من خلال فهرسها.
3. إضافة [شكل أوتوماتيكي](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) الخاص بالشكل الأوتوماتيكي. 
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى من خلال فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء مثيل الفقرة الثانية من خلال فئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء مثيل الفقرة الثالثة من خلال فئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء مثيل الفقرة الرابعة من خلال فئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض المعدل.

هذا الكود في جافا يوضح لك كيفية إضافة وإدارة النقاط متعددة المستويات:

```java
// إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة والوصول إلى شكل أوتوماتيكي
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للشكل الأوتوماتيكي الذي تم إنشاؤه
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
    // تعيين مستوى الرمز
    para1.getParagraphFormat().setDepth((short)0);

    // إضافة الفقرة الثانية
    IParagraph para2 = new Paragraph();
    para2.setText("المستوى الثاني");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى الرمز
    para2.getParagraphFormat().setDepth((short)1);

    // إضافة الفقرة الثالثة
    IParagraph para3 = new Paragraph();
    para3.setText("المستوى الثالث");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى الرمز
    para3.getParagraphFormat().setDepth((short)2);

    // إضافة الفقرة الرابعة
    IParagraph para4 = new Paragraph();
    para4.setText("المستوى الرابع");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى الرمز
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


## **إدارة فقرة بقائمة مرقمة مخصصة**

توفر واجهة [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) خاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) وغيرها التي تسمح لك بإدارة الفقرات مع ترقيم مخصص أو تنسيق.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [شكل أوتوماتيكي](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) للشكل الأوتوماتيكي.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء المثيل الأول للفقرة من خلال فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى 2.
7. إنشاء المثيل الثاني للفقرة من خلال فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء المثيل الثالث للفقرة من خلال فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض المعدل.

هذا الكود في جافا يوضح لك كيفية إضافة وإدارة الفقرات مع ترقيم مخصص أو تنسيق:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص الخاص بالشكل الأوتوماتيكي الذي تم إنشاؤه
    ITextFrame textFrame = shape.getTextFrame();

    // إزالة الفقرة الافتراضية الموجودة
    textFrame.getParagraphs().removeAt(0);

    // القائمة الأولى
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("رمز 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("رمز 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("رمز 7");
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

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الوصول إلى مرجع الشريحة المعنية من خلال فهرسها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) مع ثلاث فقرات إلى شكل المستطيل.
1. إخفاء خطوط المستطيل.
1. تعيين إزاحة لكل [فقرة](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) من خلال خاصية BulletOffset الخاصة بها.
1. كتابة العرض المعدل كملف PPT.

هذا الكود في جافا يوضح لك كيفية تعيين إزاحة الفقرة:

```java
// إنشاء مثيل من الفئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إضافة شكل مستطيل
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // إضافة إطار نص إلى المستطيل
    ITextFrame tf = rect.addTextFrame("هذه هي السطر الأول \rهذا هو السطر الثاني \rهذا هو السطر الثالث");
    
    // تأكد من أن النص يتناسب مع الشكل
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // إخفاء خطوط المستطيل
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // الحصول على الفقرة الأولى في إطار النص وتعيين إزاحتها
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // تعيين نمط الرمز الفقرة والرمز
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // الحصول على الفقرة الثانية في إطار النص وتعيين إزاحتها
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // الحصول على الفقرة الثالثة في إطار النص وتعيين إزاحتها
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

## **تعيين إزاحة معلقة للفقرة**

هذا الكود في جافا يوضح لك كيفية تعيين إزاحة معلقة لفقرة:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("مثال");

    Paragraph para2 = new Paragraph();
    para2.setText("تعيين إزاحة معلقة للفقرة");

    Paragraph para3 = new Paragraph();
    para3.setText("يوضح لك هذا الكود كيفية تعيين الإزاحة المعلقة للفقرة: ");

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

## **إدارة خصائص نهاية الفقرة للفقرات**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع للشريحة التي تحتوي على الفقرة من خلال موقعها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) مع فقرتين إلى المستطيل.
1. تعيين `FontHeight` ونوع الخط للفقرات.
1. تعيين خصائص النهاية للفقرات.
1. كتابة العرض المعدل كملف PPTX.

هذا الكود في جافا يوضح لك كيفية تعيين خصائص النهاية للفقرات في PowerPoint:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("نص مثال"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("نص مثال 2"));

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

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. الوصول إلى مرجع الشريحة المعنية من خلال فهرسها.
3. إضافة [شكل أوتوماتيكي](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة والوصول إلى [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) للشكل الأوتوماتيكي.
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في TextReader.
7. إنشاء المثيل الأول للفقرة من خلال فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) .
8. إضافة محتوى ملف HTML في TextReader المقروء إلى مجموعة فقرات TextFrame.
9. حفظ العرض المعدل.

هذا الكود في جافا هو تنفيذ للخطوات الخاصة باستيراد نصوص HTML في الفقرات:

```java
// إنشاء مثيل عرض تقديمي فارغ
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى الافتراضية من العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة شكل أوتوماتيكي لاستيعاب محتوى HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // إضافة إطار نص إلى الشكل
    ashape.addTextFrame("");

    // Clearing جميع الفقرات في إطار النص المُضاف
    ashape.getTextFrame().getParagraphs().clear();

    // تحميل ملف HTML باستخدام Text Reader
    TextReader tr = new StreamReader("file.html");

    // إضافة نص من تدفق HTML إلى إطار النص
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // حفظ العرض
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تصدير نصوص الفقرات إلى HTML**

توفر Aspose.Slides دعمًا محسّنًا لتصدير النصوص (المcontained في الفقرات) إلى HTML.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وتحميل العرض التقديمي المرغوب فيه.
2. الوصول إلى مرجع الشريحة المعنية من خلال فهرسها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيتم تصديره إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء مثيل من `StreamWriter` وإضافة ملف HTML الجديد.
6. توفير فهرس بدء لـ StreamWriter وتصدير فقراتك المفضلة.

هذا الكود في جافا يوضح لك كيفية تصدير نصوص الفقرة في PowerPoint إلى HTML:

```java
// تحميل ملف العرض التقديمي
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // الوصول إلى الشريحة الأولى الافتراضية من العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // الفهرس المرغوب
    int index = 0;

    // الوصول إلى الشكل المضاف
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // إنشاء ملف HTML الناتج
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // استخراج الفقرة الأولى كـ HTML
    // كتابة بيانات الفقرات إلى HTML عن طريق توفير فهرس الفقرة الابتدائية، وإجمالي الفقرات المراد نسخها
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```