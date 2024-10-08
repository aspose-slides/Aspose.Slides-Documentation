---
title: إدارة النقاط
type: docs
weight: 60
url: /ar/java/manage-bullet/
keywords: "النقاط، قوائم النقاط، الأرقام، قوائم مرقمة، نقاط صور، نقاط متعددة المستويات، عرض PowerPoint، Java، Aspose.Slides for Java"
description: "إنشاء قوائم نقاط وقوائم مرقمة في عرض PowerPoint باستخدام Java"
---

في **Microsoft PowerPoint**، يمكنك إنشاء قوائم نقاط وقوائم مرقمة بنفس الطريقة التي تستخدمها في Word ومحررات النصوص الأخرى. كما أن **Aspose.Slides for Java** يتيح لك استخدام النقاط والأرقام في الشرائح في العروض التقديمية الخاصة بك.

## لماذا نستخدم قوائم النقاط؟

تساعد قوائم النقاط على تنظيم وتقديم المعلومات بسرعة وكفاءة.

**مثال قائمة النقاط**

في معظم الحالات، تقوم قائمة النقاط بهذه الوظائف الرئيسية الثلاث:

- تجذب انتباه قرائك أو مشاهديك إلى المعلومات الهامة
- تسمح لقرائك أو مشاهديك بمسح النقاط الرئيسية بسهولة
- تتواصل وتقدم التفاصيل المهمة بكفاءة.

## لماذا نستخدم القوائم المرقمة؟

تساعد القوائم المرقمة أيضًا في تنظيم وتقديم المعلومات. من المثالي، يجب أن تستخدم الأرقام (بدلاً من النقاط) عندما يكون ترتيب الإدخالات (على سبيل المثال، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يجب الإشارة إلى إدخال (على سبيل المثال، *انظر الخطوة 3*).

**مثال قائمة مرقمة**

هذا هو ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء النقاط** أدناه:

1. إنشاء مثيل من فئة العرض التقديمي.
2. القيام بعدة مهام (الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي.

## إنشاء النقاط
هذا الموضوع هو أيضًا جزء من سلسلة مواضيع إدارة فقرات النصوص. ستوضح هذه الصفحة كيفية إدارة نقاط الفقرات. النقاط أكثر فائدة حيث يتعين وصف شيء ما في خطوات. علاوة على ذلك، يبدو النص منظمًا بشكل جيد مع استخدام النقاط. تعتبر فقرات النقاط دائمًا أسهل في القراءة والفهم. سنرى كيف يمكن للمطورين استخدام هذه الميزة الصغيرة ولكن القوية من Aspose.Slides for Java. يرجى اتباع الخطوات أدناه لإدارة نقاط الفقرات باستخدام Aspose.Slides for Java:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) object.
1. إضافة [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) للشكل المضاف.
1. إزالة الفقرة الافتراضية في TextFrame.
1. إنشاء مثيل الفقرة الأولى باستخدام [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) class.
1. تعيين نوع النقطة للفقرة.
1. تعيين نوع النقطة إلى [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) وتعيين حرف النقطة.
1. تعيين نص الفقرة.
1. تعيين مسافة الفقرة لتعيين النقطة.
1. تعيين لون النقطة.
1. تعيين ارتفاع النقاط.
1. إضافة الفقرة التي تم إنشاؤها في مجموعة فقرات TextFrame.
1. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات **7 إلى 13**.
1. حفظ العرض التقديمي.

هذا الكود المثال في Java—تنفيذ الخطوات أعلاه—يظهر لك كيفية إنشاء قائمة نقاط في شريحة:

```java
// إنشاء مثيل من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى الشكل التلقائي
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للشكل التلقائي الذي تم إنشاؤه
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);
    
    // إنشاء فقرة
    Paragraph para = new Paragraph();
    
    // تعيين نمط وشكل فقرة النقطة
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // تعيين نص الفقرة
    para.setText("مرحبًا بك في Aspose.Slides");
    
    // تعيين مسافة النقطة
    para.getParagraphFormat().setIndent(25);
    
    // تعيين لون النقطة
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // تعيين IsBulletHardColor إلى true لاستخدام لون النقطة الخاص
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // تعيين ارتفاع النقطة
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);
    
    // حفظ العرض التقديمي كملف PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## إنشاء نقاط الصور

يتيح لك Aspose.Slides for Java تغيير النقاط في قوائم النقاط. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا كنت ترغب في إضافة اهتمام بصري إلى قائمة أو جذب الانتباه أكثر إلى الإدخالات في قائمة، يمكنك استخدام صورتك الخاصة كنقطة.

{{% alert color="primary" %}} 

من المثالي، إذا كنت تنوي استبدال رمز النقطة العادية بصورة، قد ترغب في اختيار صورة رسومية بسيطة بخلفية شفافة. تعمل مثل هذه الصور بشكل أفضل كرموز نقاط مخصصة.

على أي حال، ستقلص الصورة التي تختارها إلى حجم صغير جدًا، لذا نوصي بشدة باختيار صورة تبدو جيدة (كبديل لرمز النقطة) في قائمة.

{{% /alert %}} 

لإنشاء نقطة صورة، اتبع هذه الخطوات:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) object.
1. إضافة شكل تلقائي في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph.
1. تحميل الصورة من القرص في [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage).
1. تعيين نوع النقطة إلى Picture وتعيين الصورة.
1. تعيين نص الفقرة.
1. تعيين مسافة الفقرة لتعيين النقطة.
1. تعيين لون النقطة.
1. تعيين ارتفاع النقاط.
1. إضافة الفقرة التي تم إنشاؤها في مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات السابقة.
1. حفظ العرض التقديمي.

هذا الكود في Java يظهر لك كيفية إنشاء نقطة صورة في شريحة:

```java
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إنشاء الصورة للنقاط
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة والوصول إلى الشكل التلقائي
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للشكل التلقائي الذي تم إنشاؤه
    ITextFrame txtFrm = aShp.getTextFrame();
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);

    // إنشاء فقرة جديدة
    Paragraph para = new Paragraph();
    para.setText("مرحبًا بك في Aspose.Slides");

    // تعيين نمط وشكل فقرة النقطة
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // تعيين ارتفاع النقطة
    para.getParagraphFormat().getBullet().setHeight(100);

    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);

    // كتابة العرض التقديمي كملف PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## إنشاء نقاط متعددة المستويات

لإنشاء قائمة نقاط تحتوي على عناصر على مستويات مختلفة—قوائم إضافية تحت القائمة الرئيسية—اتبع هذه الخطوات:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) object.
1. إضافة شكل تلقائي في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph مع تعيين العمق إلى 0.
1. إنشاء مثيل الفقرة الثانية باستخدام فئة Paragraph مع تعيين العمق إلى 1.
1. إنشاء مثيل الفقرة الثالثة باستخدام فئة Paragraph مع تعيين العمق إلى 2.
1. إنشاء مثيل الفقرة الرابعة باستخدام فئة Paragraph مع تعيين العمق إلى 3.
1. إضافة الفقرات التي تم إنشاؤها في مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. حفظ العرض التقديمي.

هذا الكود، وهو تنفيذ الخطوات أعلاه، يظهر لك كيفية إنشاء قائمة نقاط متعددة المستويات في Java:

```java
// إنشاء مثيل من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى الشكل التلقائي
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للشكل التلقائي الذي تم إنشاؤه
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().clear();
    
    // إنشاء الفقرة الأولى
    Paragraph para1 = new Paragraph();
    // تعيين نمط وشكل فقرة النقطة
    para1.setText("محتوى");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para1.getParagraphFormat().setDepth ((short)0);
    
    // إنشاء الفقرة الثانية
    Paragraph para2 = new Paragraph();
    // تعيين نمط وشكل فقرة النقطة
    para2.setText("المستوى الثاني");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para2.getParagraphFormat().setDepth ((short)1);
    
    // إنشاء الفقرة الثالثة
    Paragraph para3 = new Paragraph();
    // تعيين نمط وشكل فقرة النقطة
    para3.setText("المستوى الثالث");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para3.getParagraphFormat().setDepth ((short)2);
    
    // إنشاء الفقرة الرابعة
    Paragraph para4 = new Paragraph();
    // تعيين نمط وشكل فقرة النقطة
    para4.setText("المستوى الرابع");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para4.getParagraphFormat().setDepth ((short)3);
    
    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // حفظ العرض التقديمي كملف PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## إنشاء قائمة مرقمة مخصصة
يقدم Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لإدارة الفقرات مع تنسيق أرقام مخصصة. لإضافة قائمة مرقمة مخصصة في فقرة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) object.
1. إضافة شكل تلقائي في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 2.
1. إنشاء مثيل الفقرة الثانية باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 3.
1. إنشاء مثيل الفقرة الثالثة باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 7.
1. إضافة الفقرات التي تم إنشاؤها في مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. حفظ العرض التقديمي.

هذا الكود في Java يظهر لك كيفية إنشاء قائمة مرقمة في شريحة:

```java
// إنشاء مثيل من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة والوصول إلى الشكل التلقائي
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للشكل التلقائي الذي تم إنشاؤه
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