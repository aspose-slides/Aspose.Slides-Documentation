---
title: إدارة التعداد النقطي
type: docs
weight: 60
url: /androidjava/manage-bullet/
keywords: "النقاط, قوائم نقطية, أرقام, قوائم مرقمة, نقاط بالصور, نقاط متعددة المستويات, عرض PowerPoint, Java, Aspose.Slides for Android عبر Java"
description: "إنشاء قوائم نقطية ومرقمة في عرض PowerPoint باستخدام Java"
---

في **مايكروسوفت باور بوينت**، يمكنك إنشاء قوائم نقطية ومرقمة بنفس الطريقة التي تقوم بها في Word و محررات النصوص الأخرى. كما أن **Aspose.Slides for Android عبر Java** يسمح لك أيضًا باستخدام النقاط والأرقام في الشرائح في عروضك.

## لماذا تستخدم القوائم النقطية؟

تساعد القوائم النقطية في تنظيم وتقديم المعلومات بسرعة وكفاءة.

**مثال على القائمة النقطية**

في معظم الحالات، تخدم القائمة النقطية هذه الوظائف الثلاث الرئيسية:

- تلفت انتباه قرائك أو مشاهدينك إلى المعلومات المهمة
- تتيح لقرائك أو مشاهدينك البحث عن النقاط الرئيسية بسهولة
- توصل وتقدم التفاصيل الهامة بكفاءة.

## لماذا تستخدم القوائم المرقمة؟

تساعد القوائم المرقمة أيضًا في تنظيم وتقديم المعلومات. من المثالي استخدام الأرقام (بدلاً من النقاط) عندما يكون ترتيب الإدخالات (على سبيل المثال، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يجب الإشارة إلى إدخال (على سبيل المثال، *انظر الخطوة 3*).

**مثال على القائمة المرقمة**

هذا ملخص للخطوات (الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء النقاط** أدناه:

1. إنشاء مثيل من فئة العرض.
2. تنفيذ عدة مهام (الخطوة 3 إلى الخطوة 14).
3. حفظ العرض.

## إنشاء النقاط
هذه الموضوع هو أيضًا جزء من سلسلة مواضيع إدارة فقرات النص. ستوضح هذه الصفحة كيف يمكننا إدارة النقاط الخاصة بالفقرة. النقاط أكثر فائدة حيث يجب وصف شيء ما في خطوات. علاوة على ذلك، تبدو النصوص منظمة جيدًا باستخدام النقاط. الفقرات النقطية دائمًا أسهل في القراءة والفهم. سنرى كيف يمكن للمطورين استخدام هذه الميزة الصغيرة ولكن القوية من Aspose.Slides for Android عبر Java. يرجى اتباع الخطوات أدناه لإدارة نقاط الفقرة باستخدام Aspose.Slides for Android عبر Java:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) object.
1. إضافة [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) للشكل المضاف.
1. إزالة الفقرة الافتراضية في TextFrame.
1. إنشاء مثيل الفقرة الأولى باستخدام [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) class.
1. تعيين نوع النقطة للفقرة.
1. تعيين نوع النقطة إلى [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) وتعيين حرف النقطة.
1. تعيين نص الفقرة.
1. تعيين المسافة البادئة للفقرة لتعيين النقطة.
1. تعيين لون النقطة.
1. تعيين ارتفاع النقاط.
1. إضافة الفقرة التي تم إنشاؤها في مجموعة فقرات TextFrame.
1. إضافة الفقرة الثانية وتكرار العملية الواردة في الخطوات **7 إلى 13**.
1. حفظ العرض.

يظهر هذا الرمز المصدري بلغة Java—تنفيذ الخطوات أعلاه—كيفية إنشاء قائمة نقطية في شريحة:

```java
// قم بإنشاء مثيل لفئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للشكل المنشأ
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);
    
    // إنشاء فقرة
    Paragraph para = new Paragraph();
    
    // تعيين نمط النقطة للفقرة والرمز
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // تعيين نص الفقرة
    para.setText("مرحبًا بكم في Aspose.Slides");
    
    // تعيين المسافة البادئة للنقطة
    para.getParagraphFormat().setIndent(25);
    
    // تعيين لون النقطة
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // تعيين IsBulletHardColor ليكون true لاستخدام لون النقطة الخاصة
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // تعيين ارتفاع النقطة
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);
    
    // حفظ العرض كملف PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## إنشاء نقاط بالصور

يسمح لك Aspose.Slides for Android عبر Java بتغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا كنت ترغب في إضافة اهتمام بصري للقائمة أو لزيادة جذب الانتباه إلى الإدخالات في القائمة، يمكنك استخدام صورتك الخاصة كنقطة.

{{% alert color="primary" %}} 

من المثالي، إذا كنت تنوي استبدال رمز النقطة العادية بصورة، قد ترغب في اختيار صورة رسومية بسيطة ذات خلفية شفافة. تعمل مثل هذه الصور بشكل أفضل كرموز نقطية مخصصة.

في أي حال، سيتم تقليل الصورة التي تختارها إلى حجم صغير جدًا، لذا نوصي بشدة بأن تختار صورة تبدو جيدة (كبديل لرمز النقطة) في القائمة.

{{% /alert %}} 

لإنشاء نقطة بالصورة، اتبع هذه الخطوات:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) object
1. إضافة شكل تلقائي في الشريحة المحددة
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) للشكل المضاف
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph
1. تحميل صورة من القرص في [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage)
1. تعيين نوع النقطة إلى صورة وتعيين الصورة
1. تعيين نص الفقرة
1. تعيين المسافة البادئة للفقرة لتعيين النقطة
1. تعيين لون النقطة
1. تعيين ارتفاع النقاط
1. إضافة الفقرة التي تم إنشاؤها في مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
1. إضافة الفقرة الثانية وتكرار العملية الواردة في الخطوات السابقة
1. حفظ العرض

هذا الرمز بلغة Java يوضح لك كيفية إنشاء نقطة بالصورة في شريحة:

```java
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إنشاء الصورة المستخدمة للنقاط
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة والوصول إلى AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للشكل المنشأ
    ITextFrame txtFrm = aShp.getTextFrame();
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);

    // إنشاء فقرة جديدة
    Paragraph para = new Paragraph();
    para.setText("مرحبًا بكم في Aspose.Slides");

    // تعيين نمط النقطة للفقرة والصورة
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // تعيين ارتفاع النقطة
    para.getParagraphFormat().getBullet().setHeight(100);

    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);

    // كتابة العرض كملف PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## إنشاء نقاط متعددة المستويات

لإنشاء قائمة نقطية تحتوي على عناصر بمستويات مختلفة—قوائم إضافية تحت القائمة النقطية الرئيسية—اتبع هذه الخطوات:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) object.
1. إضافة شكل تلقائي في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph مع العمق المعين إلى 0.
1. إنشاء المثيل الثاني للفقرة باستخدام فئة Paragraph مع العمق المعين إلى 1.
1. إنشاء المثيل الثالث للفقرة باستخدام فئة Paragraph مع العمق المعين إلى 2.
1. إنشاء المثيل الرابع للفقرة باستخدام فئة Paragraph مع العمق المعين إلى 3.
1. إضافة الفقرات التي تم إنشاؤها في مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. حفظ العرض.

يوضح الكود أدناه، الذي هو تنفيذ للخطوات أعلاه، كيفية إنشاء قائمة نقطية متعددة المستويات في Java:

```java
// قم بإنشاء مثيل لفئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للشكل المنشأ
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().clear();
    
    // إنشاء الفقرة الأولى
    Paragraph para1 = new Paragraph();
    // تعيين نمط النقطة للفقرة والرمز
    para1.setText("المحتوى");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //تعيين مستوى النقطة
    para1.getParagraphFormat().setDepth ((short)0);
    
    // إنشاء الفقرة الثانية
    Paragraph para2 = new Paragraph();
    // تعيين نمط النقطة للفقرة والرمز
    para2.setText("المستوى الثاني");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //تعيين مستوى النقطة
    para2.getParagraphFormat().setDepth ((short)1);
    
    // إنشاء الفقرة الثالثة
    Paragraph para3 = new Paragraph();
    // تعيين نمط النقطة للفقرة والرمز
    para3.setText("المستوى الثالث");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //تعيين مستوى النقطة
    para3.getParagraphFormat().setDepth ((short)2);
    
    // إنشاء الفقرة الرابعة
    Paragraph para4 = new Paragraph();
    // تعيين نمط النقطة للفقرة والرمز
    para4.setText("المستوى الرابع");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //تعيين مستوى النقطة
    para4.getParagraphFormat().setDepth ((short)3);
    
    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // حفظ العرض كملف PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## إنشاء قائمة مرقمة مخصصة
يوفر Aspose.Slides for Android عبر Java واجهة برمجة تطبيقات بسيطة لإدارة الفقرات بتنسيق أرقام مخصص. لإضافة قائمة أرقام مخصصة في فقرة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) object.
1. إضافة شكل تلقائي في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. إنشاء المثيل الأول للفقرة باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 2
1. إنشاء المثيل الثاني للفقرة باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 3
1. إنشاء المثيل الثالث للفقرة باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 7
1. إضافة الفقرات التي تم إنشاؤها في مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. حفظ العرض.

يوضح لك هذا الرمز بلغة Java كيفية إنشاء قائمة مرقمة في شريحة:

```java
// قم بإنشاء مثيل لفئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة والوصول إلى AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للشكل المنشأ
    ITextFrame txtFrm = aShp.addTextFrame("");

    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().clear();

    // القائمة الأولى
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("نقطة 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("نقطة 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // القائمة الثانية
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("نقطة 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```