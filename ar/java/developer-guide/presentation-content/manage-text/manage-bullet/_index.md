---
title: إدارة القوائم النقطية والمرقمة في العروض التقديمية باستخدام Java
linktitle: إدارة القوائم
type: docs
weight: 60
url: /ar/java/manage-bullet/
keywords:
- نقطة
- قائمة نقطية
- قائمة مرقمة
- نقطة رمزية
- نقطة صور
- نقطة مخصصة
- قائمة متعددة المستويات
- إنشاء نقطة
- إضافة نقطة
- إضافة قائمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة القوائم النقطية والمرقمة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Java. دليل خطوة بخطوة."
---

في **Microsoft PowerPoint**، يمكنك إنشاء قوائم نقطية ومرقمة بنفس الطريقة التي تفعلها في Word وغيرها من محرري النصوص. **Aspose.Slides for Java** يتيح لك أيضًا استخدام النقاط والأرقام في الشرائح في عروضك التقديمية. 

## **لماذا نستخدم القوائم النقطية؟**

القوائم النقطية تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. 

**مثال على قائمة نقطية**

في معظم الحالات، تخدم القائمة النقطية هذه الوظائف الثلاث الرئيسية:

- تجذب انتباه القراء أو المشاهدين إلى المعلومات الهامة
- تمكن القراء أو المشاهدين من مسح النقاط الرئيسية بسهولة
- تنقل وتقدم التفاصيل الهامة بكفاءة.

## **لماذا نستخدم القوائم المرقمة؟**

القوائم المرقمة تساعد أيضًا في تنظيم وعرض المعلومات. من المثالي استخدام الأرقام (بدلاً من النقاط) عندما يكون ترتيب الإدخالات (على سبيل المثال، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يجب الإشارة إلى إدخال ما (على سبيل المثال، *انظر الخطوة 3*).

**مثال على قائمة مرقمة**

هذا ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء النقاط** أدناه:

1. إنشاء مثيل لفئة العرض التقديمي.
2. تنفيذ عدة مهام (من الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي. 

## **إنشاء النقاط**

هذا الموضوع هو أيضًا جزء من سلسلة مواضيع إدارة فقرات النص. ستوضح هذه الصفحة كيفية إدارة نقاط الفقرات. تكون النقاط أكثر فائدة عندما يُوصف شيء على خطوات. علاوة على ذلك، يبدو النص منظمًا بشكل جيد باستخدام النقاط. الفقرات النقطية دائمًا أسهل في القراءة والفهم. سنرى كيف يمكن للمطورين استخدام هذه الميزة الصغيرة ولكن القوية في Aspose.Slides for Java. يرجى اتباع الخطوات أدناه لإدارة نقاط الفقرات باستخدام Aspose.Slides for Java:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) .
1. إضافة [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) للشكل المضاف.
1. إزالة الفقرة الافتراضية في TextFrame.
1. إنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) .
1. تعيين نوع النقطة للفقرة.
1. تعيين نوع النقطة إلى [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) وتحديد حرف النقطة.
1. تعيين نص الفقرة.
1. تعيين إزاحة الفقرة لتحديد النقطة.
1. تعيين لون النقطة.
1. تعيين ارتفاع النقاط.
1. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات TextFrame.
1. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات **7 إلى 13**.
1. حفظ العرض التقديمي.

```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للشكل المضاف
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);
    
    // إنشاء فقرة
    Paragraph para = new Paragraph();
    
    // تعيين نمط الفقرة النقطية والرمز
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // تعيين نص الفقرة
    para.setText("Welcome to Aspose.Slides");
    
    // تعيين إزاحة النقطية
    para.getParagraphFormat().setIndent(25);
    
    // تعيين لون النقطية
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // تعيين IsBulletHardColor إلى true لاستخدام لون نقطتك الخاص
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // تعيين ارتفاع النقطية
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);
    
    // حفظ العرض التقديمي كملف PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **إنشاء نقاط صورة**

Aspose.Slides for Java يتيح لك تغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا كنت ترغب في إضافة اهتمام بصري إلى القائمة أو جذب المزيد من الانتباه إلى العناصر في القائمة، يمكنك استخدام صورتك الخاصة كنقطة. 

{{% alert color="primary" %}} 
من المثالي، إذا كنت تنوي استبدال رمز النقطة العادي بصورة، قد ترغب في اختيار صورة رسومية بسيطة بخلفية شفافة. تعمل هذه الصور بشكل أفضل كرموز نقاط مخصصة. 

في جميع الأحوال، الصورة التي تختارها ستُصغر إلى حجم صغير جدًا، لذا نوصي بشدة باختيار صورة تبدو جيدة (كبديل لرمز النقطة) في القائمة. 
{{% /alert %}} 

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) .
1. إضافة شكل تلقائي في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) .
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph .
1. تحميل الصورة من القرص في [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage) .
1. تعيين نوع النقطة إلى Picture وتحديد الصورة.
1. تعيين نص الفقرة.
1. تعيين إزاحة الفقرة لتحديد النقطة.
1. تعيين لون النقطة.
1. تعيين ارتفاع النقاط.
1. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) .
1. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات السابقة.
1. حفظ العرض التقديمي

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

    // الوصول إلى إطار النص للشكل التلقائي المُنشأ
    ITextFrame txtFrm = aShp.getTextFrame();
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);

    // إنشاء فقرة جديدة
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // تحديد نمط الفقرة النقطية والصورة
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // تحديد ارتفاع النقطة
    para.getParagraphFormat().getBullet().setHeight(100);

    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);

    // حفظ العرض كملف PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء نقاط متعددة المستويات**

لإنشاء قائمة نقطية تحتوي على عناصر بمستويات مختلفة—قوائم إضافية تحت القائمة النقطية الرئيسية—اتبع الخطوات التالية:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) .
1. إضافة شكل تلقائي في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) .
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph وتحديد العمق إلى 0.
1. إنشاء مثيل الفقرة الثانية باستخدام فئة Paragraph وتحديد العمق إلى 1.
1. إنشاء مثيل الفقرة الثالثة باستخدام فئة Paragraph وتحديد العمق إلى 2.
1. إنشاء مثيل الفقرة الرابعة باستخدام فئة Paragraph وتحديد العمق إلى 3.
1. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) .
1. حفظ العرض التقديمي.

```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى الشكل التلقائي
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للشكل التلقائي المُنشأ
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().clear();
    
    // إنشاء الفقرة الأولى
    Paragraph para1 = new Paragraph();
    // تعيين نمط الفقرة النقطية والرمز
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //تعيين مستوى النقطة
    para1.getParagraphFormat().setDepth ((short)0);
    
    // إنشاء الفقرة الثانية
    Paragraph para2 = new Paragraph();
    // تعيين نمط الفقرة النقطية والرمز
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //تعيين مستوى النقطة
    para2.getParagraphFormat().setDepth ((short)1);
    
    // إنشاء الفقرة الثالثة
    Paragraph para3 = new Paragraph();
    // تعيين نمط الفقرة النقطية والرمز
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //تعيين مستوى النقطة
    para3.getParagraphFormat().setDepth ((short)2);
    
    // إنشاء الفقرة الرابعة
    Paragraph para4 = new Paragraph();
    // تعيين نمط الفقرة النقطية والرمز
    para4.setText("Fourth Level");
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


## **إنشاء قوائم مرقمة مخصصة**

Aspose.Slides for Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة الفقرات مع تنسيق أرقام مخصص. لإضافة قائمة أرقام مخصصة في فقرة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) .
1. إضافة شكل تلقائي في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) .
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 2.
1. إنشاء مثيل الفقرة الثانية باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 3.
1. إنشاء مثيل الفقرة الثالثة باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 7.
1. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) .
1. حفظ العرض التقديمي.

```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة والوصول إلى الشكل التلقائي
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للشكل التلقائي المُنشأ
    ITextFrame txtFrm = aShp.addTextFrame("");

    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().clear();

    // القائمة الأولى
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // القائمة الثانية
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكن تصدير القوائم النقطية والمرقمة التي تم إنشاؤها باستخدام Aspose.Slides إلى صيغ أخرى مثل PDF أو الصور؟**

نعم، Aspose.Slides يحافظ بالكامل على تنسيق وبنية القوائم النقطية والمرقمة عند تصدير العروض إلى صيغ مثل PDF أو الصور وغيرها، مما يضمن نتائج متسقة.

**هل من الممكن استيراد القوائم النقطية أو المرقمة من العروض التقديمية الموجودة؟**

نعم، Aspose.Slides يتيح لك استيراد وتحرير القوائم النقطية أو المرقمة من العروض التقديمية الموجودة مع الحفاظ على تنسيقها ومظهرها الأصلي.

**هل يدعم Aspose.Slides القوائم النقطية والمرقمة في العروض التي تم إنشاؤها بعدة لغات؟**

نعم، Aspose.Slides يدعم بالكامل العروض المتعددة اللغات، مما يتيح لك إنشاء القوائم النقطية والمرقمة بأي لغة، بما في ذلك استخدام الأحرف الخاصة أو غير اللاتينية.