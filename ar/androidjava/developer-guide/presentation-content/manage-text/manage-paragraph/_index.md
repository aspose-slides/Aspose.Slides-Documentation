---
title: إدارة فقرات نص PowerPoint على Android
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/androidjava/manage-paragraph/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة الترقيم
- مسافة بادئة للفقرة
- مسافة بادئة معلقة
- ترقيم الفقرة
- قائمة مرقمة
- قائمة ذات ترقيم نقطي
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
description: "إتقان تنسيق الفقرات باستخدام Aspose.Slides لنظام Android—تحسين المحاذاة والتباعد والأسلوب في عروض PPT و PPTX و ODP في Java."
---
Aspose.Slides يوفر جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والجزءيات في Java.

* Aspose.Slides يوفر واجهة [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) لتسمح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو متعددة (كل فقرة تُنشأ عبر إرجاع السطر).
* Aspose.Slides يوفر واجهة [IParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/) لتسمح لك بإضافة كائنات تمثل الجزءيات. يمكن لكائن `IParagraph` أن يحتوي على جزءية واحدة أو متعددة (مجموعة كائنات iPortions).
* Aspose.Slides يوفر واجهة [IPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/) لتسمح لك بإضافة كائنات تمثل النصوص وخصائص تنسيقها.

كائن `IParagraph` قادر على معالجة النصوص ذات خصائص تنسيق مختلفة عبر كائناته الأساسية `IPortion`.

## **إضافة فقرات متعددة تحتوي على عدة جزءيات نصية**

تظهر هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 جزءيات:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المعنية عبر الفهرس الخاص بها.
3. إضافة مستطيل [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على ITextFrame المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/).
5. إنشاء كائنين من [IParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/).
6. إنشاء ثلاثة كائنات من [IPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/) لكل `IParagraph` جديد (جزءيتان للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. تعيين بعض النص لكل جزء.
8. تطبيق خصائص التنسيق المفضلة على كل جزء باستخدام خصائص التنسيق التي ي exposeها كائن `IPortion`.
9. حفظ العرض المعدل.

```java
// إنشاء فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع مستطيل
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // الوصول إلى TextFrame الخاص بـ AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // إنشاء فقرات وجزءيات بتنسيقات نصية مختلفة
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

## **إدارة نقاط الفقرة**

قوائم الترقيم تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات ذات الترقيم تكون دائمًا أسهل في القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المعنية عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى `TextFrame` الخاص بـ autoshape عبر [TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraph/).
7. تعيين `Type` للترقيم إلى `Symbol` وتعيين حرف الترقيم.
8. تعيين `Text` للفقرة.
9. تعيين `Indent` للفقرة للترقيم.
10. تعيين لون للترقيم.
11. تعيين ارتفاع للترقيم.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات 7 إلى 13.
14. حفظ العرض.

```java
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // يضيف ويصل إلى Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص الخاص بـ autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // يزيل الفقرة الافتراضية
    txtFrm.getParagraphs().removeAt(0);

    // ينشئ فقرة
    Paragraph para = new Paragraph();

    // يضبط نمط ترقيم الفقرة والرمز
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // يحدد نص الفقرة
    para.setText("Welcome to Aspose.Slides");

    // يضبط مسافة بادئة للترقيم
    para.getParagraphFormat().setIndent(25);

    // يضبط لون الترقيم
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // اضبط IsBulletHardColor إلى true لاستخدام لون ترقيم مخصص

    // يضبط ارتفاع الترقيم
    para.getParagraphFormat().getBullet().setHeight(100);

    // يضيف الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);

    // ينشئ الفقرة الثانية
    Paragraph para2 = new Paragraph();

    // يضبط نوع ترقيم الفقرة والأسلوب
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // يضيف نص الفقرة
    para2.setText("This is numbered bullet");

    // يضبط مسافة بادئة للترقيم
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // اضبط IsBulletHardColor إلى true لاستخدام لون ترقيم مخصص

    // يضبط ارتفاع الترقيم
    para2.getParagraphFormat().getBullet().setHeight(100);

    // يضيف الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para2);
    
    // يحفظ العرض المعدل
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة نقاط الصور**

قوائم الترقيم تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. فقرات الصور سهلة القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المعنية عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى `TextFrame` الخاص بـ autoshape عبر [TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/).
8. تعيين نوع الترقيم إلى [Picture](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) وتعيين الصورة.
9. تعيين `Text` للفقرة.
10. تعيين `Indent` للفقرة للترقيم.
11. تعيين لون للترقيم.
12. تعيين ارتفاع للترقيم.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض المعدل.

```java
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation presentation = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide slide = presentation.getSlides().get_Item(0);

    // ينشئ الصورة للترقيم
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // يضيف ويصل إلى Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص الخاص بالـ autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // يزيل الفقرة الافتراضية
    textFrame.getParagraphs().removeAt(0);

    // ينشئ فقرة جديدة
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // يضبط نمط ترقيم الفقرة والصورة
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // يضبط ارتفاع الترقيم
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // يضيف الفقرة إلى إطار النص
    textFrame.getParagraphs().add(paragraph);

    // يكتب العرض كملف PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // يكتب العرض كملف PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إدارة الترقيم المتعدد المستويات**

قوائم الترقيم تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. الترقيم متعدد المستويات سهل القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المعنية عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى `TextFrame` الخاص بـ autoshape عبر [TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء المثال الثاني للفقرة عبر الفئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء المثال الثالث للفقرة عبر الفئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء المثال الرابع للفقرة عبر الفئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض المعدل.

```java
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف ويصل إلى Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص للـ autoshape المنشأ
    ITextFrame text = aShp.addTextFrame("");

    // يمسح الفقرة الافتراضية
    text.getParagraphs().clear();

    // Adds the first paragraph
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // يضبط مستوى الترقيم
    para1.getParagraphFormat().setDepth((short)0);

    // Adds the second paragraph
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // يضبط مستوى الترقيم
    para2.getParagraphFormat().setDepth((short)1);

    // Adds the third paragraph
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // يضبط مستوى الترقيم
    para3.getParagraphFormat().setDepth((short)2);

    // Adds the fourth paragraph
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // يضبط مستوى الترقيم
    para4.getParagraphFormat().setDepth((short)3);

    // يضيف الفقرات إلى المجموعة
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // يكتب العرض كملف PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة فقرة مع قائمة مرقمة مخصصة**

توفر واجهة [IBulletFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) وغيرها التي تسمح لك بإدارة الفقرات ذات الترقيم أو التنسيق المخصص.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى `TextFrame` الخاص بـ autoshape عبر [TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى 2.
7. إنشاء المثال الثاني للفقرة عبر الفئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء المثال الثالث للفقرة عبر الفئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض المعدل.

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

## **تعيين مسافة بادئة السطر الأول للفقرة**

استخدم الطريقة [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) للتحكم في مسافة البادئة للسطر الأول للفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذية إلى جسم الفقرة.

استخدم [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مسافة بادئة مختلفة لتوضيح كيف تؤثر مسافة البادئة للسطر الأول على تخطيط الفقرة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة للخاصية [Indent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض المعدل.

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

![المسافة البادئة للسطر الأول للفقرات](first_line_indent.png)

## **تعيين مسافة البادئة المعلقة للفقرة**

المسافة البادئة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى يسار الأسطر المتبقية. في Aspose.Slides، تنشئ هذا التأثير باستخدام الطريقة [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). عيّن البادئة إلى قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) يحدد الموضع الأيسر لجسم الفقرة، و[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) يحدد موضع السطر الأول بالنسبة لهذا الهامش. لإنشاء مسافة بادئة معلّقة، عيّن قيمة `MarginLeft` موجبة وقيمة `Indent` سالبة.

هذا التنسيق مفيد للبيبليوغرافيات والمراجع ومEntries القاموسية وغيرها من الفقرات التي يجب أن تكون الأسطر المُلتفة محاذية تحت جسم الفقرة بدلاً من تحت الحرف الأول للسطر الأول.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة `MarginLeft` موجبة لكل فقرة.
6. تعيين قيمة `Indent` سالبة لإنشاء تأثير المسافة البادئة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض المعدل.

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

![المسافة البادئة المعلقة للفقرات](hanging_indent.png)

## **إدارة خصائص تشغيل نهاية الفقرة**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موقعها.
1. إضافة مستطيل [autoshape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) يحتوي على فقرتين إلى المستطيل.
1. تعيين `FontHeight` ونوع الخط للفقرات.
1. تعيين خصائص End للفقرات.
1. كتابة العرض المعدل كملف PPTX.

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

Aspose.Slides يوفر دعمًا محسّنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة المعنية عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة والوصول إلى `ITextFrame` الخاص بـ autoshape عبر [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر باستخدام TextReader.
7. إنشاء أول مثال للفقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء من TextReader إلى [ParagraphCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraphcollection/) الخاص بـ TextFrame.
9. حفظ العرض المعدل.

```java
// إنشاء كائن Presentation فارغ
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى الافتراضية في العرض
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

    // حفظ العرض
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تصدير نص الفقرة إلى HTML**

Aspose.Slides يوفر دعمًا محسّنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) وتحميل العرض المطلوب.
2. الوصول إلى مرجع الشريحة المعنية عبر الفهرس الخاص بها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيُصدّر إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء مثيل من `StreamWriter` وإضافة ملف HTML جديد.
6. تحديد فهرس بدء للـ StreamWriter وتصدير الفقرات المفضلة لديك.

```java
// تحميل ملف العرض
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // الوصول إلى الشريحة الأولى الافتراضية في العرض
    ISlide slide = pres.getSlides().get_Item(0);

    // المؤشر المطلوب
    int index = 0;

    // الوصول إلى الشكل المضاف
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // إنشاء ملف HTML للإخراج
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //استخراج الفقرة الأولى كـ HTML
    // كتابة بيانات الفقرات إلى HTML عن طريق توفير مؤشر بداية الفقرة وإجمالي الفقرات التي سيتم نسخها
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **حفظ فقرة كصورة**

في هذا القسم، سنستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بواجهة [IParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/)، كصورة. يتضمن كل مثال الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طرق `getImage` من واجهة [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تسمح هذه الأساليب باستخلاص أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، ما قد يكون مفيدًا للاستخدامات المتعددة.

لنفترض أن لدينا ملف عرض يُدعى sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو صندوق نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض ثم نحسب حدود الفقرة الثانية في إطار النص الخاص بالشكل. تُعاد رسم الفقرة على صورة bitmap جديدة، تُحفظ بتنسيق PNG. هذه الطريقة مفيدة عندما تحتاج إلى حفظ فقرة محددة كصورة منفصلة مع الحفاظ على الأبعاد والتنسيق الدقيق للنص.

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
    RectF paragraphRectangle = secondParagraph.getRect();

    // حساب الإحداثيات والحجم لصورة الإخراج (الحد الأدنى - 1×1 بكسل).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // قص صورة الشكل للحصول على صورة الفقرة فقط.
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

في هذا المثال نمد النهج السابق بإضافة عوامل مقياس إلى صورة الفقرة. يُستخرج الشكل من العرض ويحفظ كصورة بمعامل مقياس `2`. يسمح ذلك بإخراج بدقة أعلى عند تصدير الفقرة. تُحسب حدود الفقرة مع مراعاة المقياس. يمكن أن يكون المقياس مفيدًا عندما تحتاج إلى صورة أكثر تفصيلًا، مثلاً للاستخدام في مواد مطبوعة عالية الجودة.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // حفظ الشكل في الذاكرة كصورة نقطية مع التحجيم.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // إنشاء صورة نقطية للشكل من الذاكرة.
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

    // حساب الإحداثيات والحجم لصورة الإخراج (الحد الأدنى - بكسل واحد × واحد).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // قص صورة الشكل للحصول على صورة الفقرة فقط.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكنني تعطيل الالتفاف داخل إطار النص تمامًا؟**

نعم. استخدم إعداد الالتفاف لإطار النص ([setWrapText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) لتقليل الالتفاف بحيث لا تنقسام الأسطر عند حواف الإطار.

**كيف يمكنني الحصول على حدود محددة على الشريحة لفقرة معينة؟**

يمكنك استرجاع المستطيل الحدودي للفقرة (وأو حتى للجزئية الواحدة) لمعرفة موقعها الدقيق وحجمها على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يسار/يمين/وسط/ضبط)؟**

[Alignment](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) هو إعداد على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraphformat/); يُطبق على الفقرة بالكامل بغض النظر عن تنسيق كل جزءية.

**هل يمكنني تعيين لغة تدقيق إملائي لجزء فقط من الفقرة (مثلاً كلمة واحدة)؟**

نعم. تُحدد اللغة على مستوى الجزءية ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-))، لذا يمكن أن تتعايش لغات متعددة داخل فقرة واحدة.