---
title: إدارة فقرات نص PowerPoint في Java
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة التعداد
- إزاحة الفقرة
- إزاحة معلقة
- تعداد الفقرة
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
description: "إتقان تنسيق الفقرات باستخدام Aspose.Slides للـ Java—تحسين المحاذاة، والمسافات، والنمط في عروض PPT، PPTX، و ODP في Java."
---
## **المقدمة**

توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في Java.

* توفر Aspose.Slides الواجهة [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو متعددة (يتم إنشاء كل فقرة عبر إرجاع السطر).
* توفر Aspose.Slides الواجهة [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/) للسماح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `IParagraph` أن يحتوي على جزء واحد أو متعددة (مجموعة من كائنات iPortions).
* توفر Aspose.Slides الواجهة [IPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/) للسماح لك بإضافة كائنات تمثل نصوصًا وخصائص تنسيقها.

كائن `IParagraph` قادر على معالجة النصوص ذات الخصائص التنسيقية المختلفة من خلال كائنات `IPortion` الموجودة تحته.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة شكل مستطيل [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على `ITextFrame` المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/).
5. إنشاء كائنين من النوع [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).
6. إنشاء ثلاثة كائنات من النوع [IPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/) لكل `IParagraph` جديد (كائنان من النوع Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. تعيين نص لكل جزء.
8. تطبيق ميزات التنسيق المفضلة على كل جزء باستخدام خصائص التنسيق التي يوفرها كائن `IPortion`.
9. حفظ العرض التقديمي المعدل.

هذا الكود Java هو تنفيذ للخطوات لإضافة فقرات تحتوي على أجزاء:

```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من النوع مستطيل
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // الوصول إلى TextFrame الخاص بالـ AutoShape
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

    // حفظ PPTX إلى القرص
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة تعداد الفقرات**

قوائم التعداد تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات ذات التعداد دائمًا ما تكون أسهل في القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة المختارة.
4. الوصول إلى `TextFrame` الخاص بالـ [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/).
7. تعيين خاصية `Type` للتعداد إلى `Symbol` وتحديد رمز التعداد.
8. تعيين نص الفقرة.
9. تعيين `Indent` للفقرة بالنسبة للتعداد.
10. تعيين لون للتعداد.
11. تعيين ارتفاع للتعداد.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية من الخطوة 7 إلى 13.
14. حفظ العرض التقديمي.

هذا الكود Java يوضح كيفية إضافة تعداد للفقرة:

```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للـ Autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // إزالة الفقرة الافتراضية
    txtFrm.getParagraphs().removeAt(0);

    // إنشاء فقرة
    Paragraph para = new Paragraph();

    // تعيين نمط تعداد الفقرة والرمز
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // تعيين نص الفقرة
    para.setText("Welcome to Aspose.Slides");

    // تعيين إزاحة التعداد
    para.getParagraphFormat().setIndent(25);

    // تعيين لون التعداد
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // تعيين IsBulletHardColor إلى true لاستخدام لون تعداد مخصص

    // تعيين ارتفاع التعداد
    para.getParagraphFormat().getBullet().setHeight(100);

    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);

    // إنشاء الفقرة الثانية
    Paragraph para2 = new Paragraph();

    // تعيين نوع نمط تعداد الفقرة
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // إضافة نص الفقرة
    para2.setText("This is numbered bullet");

    // تعيين إزاحة التعداد
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // تعيين IsBulletHardColor إلى true لاستخدام لون تعداد مخصص

    // تعيين ارتفاع التعداد
    para2.getParagraphFormat().getBullet().setHeight(100);

    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para2);
    
    // حفظ العرض التقديمي المعدل
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة تعداد الصور**

قوائم التعداد تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات ذات الصور سهلة القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى `TextFrame` الخاص بالـ [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/).
8. تعيين نوع التعداد إلى [Picture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) وتعيين الصورة.
9. تعيين نص الفقرة.
10. تعيين `Indent` للفقرة بالنسبة للتعداد.
11. تعيين لون للتعداد.
12. تعيين ارتفاع للتعداد.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.

هذا الكود Java يوضح كيفية إضافة وإدارة تعداد الصور:

```java
// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
Presentation presentation = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = presentation.getSlides().get_Item(0);

    // ينشئ الصورة للتعداد
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // إضافة والوصول إلى Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للـ Autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // إزالة الفقرة الافتراضية
    textFrame.getParagraphs().removeAt(0);

    // إنشاء فقرة جديدة
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // تحديد نمط تعداد الفقرة والصورة
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // تحديد ارتفاع التعداد
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // إضافة الفقرة إلى إطار النص
    textFrame.getParagraphs().add(paragraph);

    // حفظ العرض التقديمي كملف PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // حفظ العرض التقديمي كملف PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إدارة تعداد متعدد المستويات**

قوائم التعداد تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة. التعداد متعدد المستويات سهل القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى `TextFrame` الخاص بالـ [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء الفقرة الثانية عبر فئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء الفقرة الثالثة عبر فئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء الفقرة الرابعة عبر فئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض التقديمي المعدل.

هذا الكود Java يوضح كيفية إضافة وإدارة تعداد متعدد المستويات:

```java
// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة والوصول إلى Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للـ Autoshape المُنشأ
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
    // تعيين مستوى التعداد
    para1.getParagraphFormat().setDepth((short)0);

    // إضافة الفقرة الثانية
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى التعداد
    para2.getParagraphFormat().setDepth((short)1);

    // إضافة الفقرة الثالثة
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى التعداد
    para3.getParagraphFormat().setDepth((short)2);

    // إضافة الفقرة الرابعة
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى التعداد
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

## **إدارة فقرة بقائمة مرقمة مخصصة**

توفر الواجهة [IBulletFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) وغيرها التي تسمح لك بإدارة الفقرات ذات الترقيم أو التنسيق المخصص.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى `TextFrame` للـ [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى 2.
7. إنشاء الفقرة الثانية عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء الفقرة الثالثة عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض التقديمي المعدل.

هذا الكود Java يوضح كيفية إضافة وإدارة فقرات ذات ترقيم أو تنسيق مخصص:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للـ autoshape المُنشأ
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

## **تعيين إزاحة السطر الأول لفقرة**

استخدم طريقة [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) للتحكم في إزاحة السطر الأول لفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تُحرك السطر الأول إلى اليمين، بينما تبقى الخطوط الأخرى محاذاة إلى جسم الفقرة.

استخدم [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) عندما تحتاج إلى تحريك الفقرة بالكامل. واستخدم [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم إزاحة مختلفة لتوضيح كيف تؤثر إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة الهدف.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة للخاصية [Indent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-).
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين إزاحة للفقرة:

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
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid);
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

## **تعيين إزاحة معلقة لفقرة**

الإزاحة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من بقية الأسطر. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام طريقة [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-). عيّن الإزاحة إلى قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، تحدد طريقة [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) الموضع الأيسر لجسم الفقرة، وتحدد طريقة [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) موضع السطر الأول نسبةً إلى ذلك الهامش. لإنشاء إزاحة معلقة، عيّن قيمة `MarginLeft` موجبة وقيمة `Indent` سالبة.

هذا التنسيق مفيد للمراجع، السجلات، مداخل القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر المتفافرة تحت جسم الفقرة بدلاً من تحت الحرف الأول للسطر.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة الهدف.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة موجبة للخاصية [MarginLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) لكل منها.
6. تعيين قيمة سالبة للخاصية [Indent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين إزاحة معلقة لفقرة:

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
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid);
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

## **إدارة خصائص تشغيل الفقرة النهائية**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موضعها.
1. إضافة [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) مستطيل إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) يحتوي على فقرتين إلى المستطيل.
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

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة والوصول إلى `ITextFrame` للـ [شكل تلقائي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر باستخدام TextReader.
7. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء إلى مجموعة الفقرات `ParagraphCollection` لإطار النص.
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
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. الوصول إلى الشكل الذي يحتوي على النص المراد تصديره إلى HTML.
4. الوصول إلى `TextFrame` للشكل.
5. إنشاء مثيل من `StreamWriter` وإضافة ملف HTML الجديد.
6. توفير فهرس بداية إلى `StreamWriter` وتصدير الفقرات المفضلة لديك.

هذا الكود Java يوضح كيفية تصدير نصوص فقرات PowerPoint إلى HTML:

```java
// تحميل ملف العرض التقديمي
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // المؤشر المطلوب
    int index = 0;

    // الوصول إلى الشكل المضاف
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // إنشاء ملف HTML الناتج
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // استخراج الفقرة الأولى كـ HTML
    // كتابة بيانات الفقرات إلى HTML عن طريق توفير مؤشر بدء الفقرة وإجمالي عدد الفقرات التي سيتم نسخها
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **حفظ الفقرة كصورة**

في هذا القسم، نستكشف مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بواجهة [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/)، كصورة. يتضمن كل مثال الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طرق `getImage` من واجهة [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تسمح هذه الطرق باستخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، وهو ما قد يكون مفيدًا لاستخدامها لاحقًا في سيناريوهات مختلفة.

نفترض أن لدينا ملف عرض تقديمي اسمه **sample.pptx** يحتوي على شريحة واحدة، حيث الشكل الأول هو صندوق نص يحتوي على ثلاث فقرات.

![صندوق النص مع ثلاث فقرات](paragraph_to_image_input.png)

**المثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى ثم نحسب حدود الفقرة الثانية داخل إطار النص الخاص بالشكل. تُعاد رسم الفقرة على صورة bitmap جديدة تُحفظ بصيغة PNG. هذه الطريقة مفيدة عندما تحتاج إلى حفظ فقرة محددة كصورة منفصلة مع الحفاظ على الأبعاد والتنسيق الدقيق للنص.

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

    // حساب الإحداثيات والحجم لصورة الإخراج (الحد الأدنى - بكسل واحد في كل الاتجاه).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

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

**المثال 2**

في هذا المثال، نمدّ النهج السابق بإضافة عوامل تصعيد إلى صورة الفقرة. يُستخرج الشكل من العرض التقديمي ويُحفظ كصورة بعامل تصعيد `2`. يتيح ذلك إنتاج صورة بدقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع مراعاة معامل التصعيد. يكون التصدير مفيدًا عندما تحتاج إلى صورة أكثر تفصيلاً، على سبيل المثال للاستخدام في مواد مطبوعة عالية الجودة.

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
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // حساب الإحداثيات والحجم لصورة الإخراج (الحد الأدنى - بكسل واحد في كل اتجاه).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // قص صورة الشكل للحصول على صورة الفقرة فقط.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكنني تعطيل التفاف النص بالكامل داخل إطار النص؟**

نعم. استخدم إعداد التفاف إطار النص ([setWrapText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) لإيقاف التفاف النص بحيث لا تنكسر الأسطر عند حواف الإطار.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة بدقة؟**

يمكنك استرداد المستطيل المحيط بالفقرة (وحتى الجزء الواحد) لمعرفة موقعها وحجمها الدقيق على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (اليسار/اليمين/الوسط/المساواة)؟**

[Alignment](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphformat/#setAlignment-int-) هي إعداد على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphformat/); تُطبق على الفقرة كاملةً بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق الإملائي لجزء فقط من الفقرة (مثلاً كلمة واحدة)؟**

نعم. تُحدد اللغة على مستوى الجزء ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-))، لذا يمكن وجود لغات متعددة داخل فقرة واحدة.