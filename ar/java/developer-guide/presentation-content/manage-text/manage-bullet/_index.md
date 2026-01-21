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
- نقطة رمز
- نقطة بصورة
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
description: "تعلم كيفية إدارة القوائم النقطية والمرقمة في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Java. دليل خطوة بخطوة."
---

في **Microsoft PowerPoint**، يمكنك إنشاء القوائم النقطية والمرقمة بنفس الطريقة التي تفعلها في Word وتحرير النصوص الأخرى. كما يتيح **Aspose.Slides for Java** لك استخدام النقاط والأرقام في الشرائح ضمن عروضك التقديمية. 

## **لماذا نستخدم القوائم النقطية؟**

تساعد القوائم النقطية على تنظيم وتقديم المعلومات بسرعة وكفاءة. 

**مثال على قائمة نقطية**

في معظم الحالات، تخدم القائمة النقطية هذه الوظائف الثلاث الرئيسية:

- تجذب انتباه القراء أو المشاهدين إلى المعلومات الهامة
- تسمح للقراء أو المشاهدين بمسح النقاط الرئيسية بسهولة
- تنقل وتُفصح عن التفاصيل المهمة بكفاءة.

## **لماذا نستخدم القوائم المرقمة؟**

تساعد القوائم المرقمة أيضاً في تنظيم وتقديم المعلومات. من المثالي استخدام الأرقام (بدلاً من النقاط) عندما يكون ترتيب الإدخالات (على سبيل المثال، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يلزم الإشارة إلى إدخال ما (مثل *انظر الخطوة 3*).

**مثال على قائمة مرقمة**

هذا ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء النقاط** أدناه:

1. إنشاء كائن من فئة العرض التقديمي. 
2. تنفيذ عدة مهام (من الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي. 

## **إنشاء النقاط**

هذا الموضوع هو جزء من سلسلة مواضيع إدارة فقرات النص. ستوضح هذه الصفحة كيفية إدارة نقاط الفقرات. تكون النقاط أكثر فائدة عندما يتم وصف شيء ما على شكل خطوات. علاوة على ذلك، يبدو النص منظمًا بشكل جيد باستخدام النقاط. الفقرات النقطية دائمًا أسهل قراءة وفهمًا. سنرى كيف يمكن للمطورين استخدام هذه الميزة الصغيرة ولكن القوية في Aspose.Slides for Java. يرجى اتباع الخطوات أدناه لإدارة نقاط الفقرات باستخدام Aspose.Slides for Java:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
1. إضافة [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) للشكل المضاف.
1. إزالة الفقرة الافتراضية في الـ TextFrame.
1. إنشاء أول كائن فقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph).
1. تعيين نوع النقطة للفقرة.
1. تعيين نوع النقطة إلى [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) وتحديد رمز النقطة.
1. تعيين نص الفقرة.
1. تعيين مسافة الفقرة لتحديد النقطة.
1. تعيين لون النقطة.
1. تعيين ارتفاع النقاط.
1. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات الـ TextFrame.
1. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات **7 إلى 13**.
1. حفظ العرض التقديمي.

هذا المثال البرمجي بلغة Java—تنفيذ للخطوات أعلاه—يوضح كيفية إنشاء قائمة نقطية في شريحة:
```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للـ autoshape المُنشأ
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);
    
    // إنشاء فقرة
    Paragraph para = new Paragraph();
    
    // تعيين نمط النقطة للفقرة والرمز
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // تعيين نص الفقرة
    para.setText("Welcome to Aspose.Slides");
    
    // تعيين مسافة إزاحة النقطة
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


## **إنشاء نقاط بصورة**

يتيح Aspose.Slides for Java لك تغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا رغبت في إضافة عنصر بصري جذاب إلى القائمة أو جذب مزيد من الانتباه إلى العناصر، يمكنك استخدام صورتك الخاصة كنقطة.

{{% alert color="primary" %}} 

من الناحية المثالية، إذا كنت تنوي استبدال رمز النقطة العادي بصورة، قد ترغب في اختيار صورة رسومية بسيطة بخلفية شفافة. تعمل هذه الصور على نحو أفضل كرموز نقاط مخصصة. 

في جميع الأحوال، سيتم تقليل حجم الصورة التي تختارها إلى حجم صغير جدًا، لذا نوصي بشدة باختيار صورة تبدو جيدة (كبديل لرمز النقطة) في القائمة. 

{{% /alert %}} 

لإنشاء نقطة بصورة، اتبع هذه الخطوات:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide)
1. إضافة شكل تلقائي في الشريحة المختارة
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) للشكل المضاف
1. إزالة الفقرة الافتراضية في الـ [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)
1. إنشاء أول كائن فقرة باستخدام فئة Paragraph
1. تحميل صورة من القرص في [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)
1. تعيين نوع النقطة إلى Picture وتحديد الصورة
1. تعيين نص الفقرة
1. تعيين مسافة الفقرة لتحديد النقطة
1. تعيين لون النقطة
1. تعيين ارتفاع النقاط
1. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)
1. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات السابقة
1. حفظ العرض التقديمي

هذا الكود بلغة Java يوضح كيفية إنشاء نقطة بصورة في شريحة:
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

    // إضافة والوصول إلى Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للـ autoshape المُنشأ
    ITextFrame txtFrm = aShp.getTextFrame();
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);

    // إنشاء فقرة جديدة
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // تعيين نمط النقطة للفقرة والصورة
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


## **إنشاء نقاط متعددة المستويات**

لإنشاء قائمة نقطية تحتوي على عناصر بمستويات مختلفة—قوائم إضافية تحت القائمة الرئيسة—اتبع هذه الخطوات:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
1. إضافة شكل تلقائي في الشريحة المختارة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في الـ [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. إنشاء أول كائن فقرة باستخدام فئة Paragraph وتعيين العمق إلى 0.
1. إنشاء الفقرة الثانية باستخدام فئة Paragraph وتعيين العمق إلى 1.
1. إنشاء الفقرة الثالثة باستخدام فئة Paragraph وتعيين العمق إلى 2.
1. إنشاء الفقرة الرابعة باستخدام فئة Paragraph وتعيين العمق إلى 3.
1. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. حفظ العرض التقديمي.

هذا الكود، وهو تنفيذ للخطوات أعلاه، يوضح كيفية إنشاء قائمة نقطية متعددة المستويات في Java:
```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للـ autoshape المُنشأ
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().clear();
    
    // إنشاء الفقرة الأولى
    Paragraph para1 = new Paragraph();
    // تعيين نمط النقطة للفقرة والرمز
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para1.getParagraphFormat().setDepth ((short)0);
    
    // إنشاء الفقرة الثانية
    Paragraph para2 = new Paragraph();
    // تعيين نمط النقطة للفقرة والرمز
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para2.getParagraphFormat().setDepth ((short)1);
    
    // إنشاء الفقرة الثالثة
    Paragraph para3 = new Paragraph();
    // تعيين نمط النقطة للفقرة والرمز
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para3.getParagraphFormat().setDepth ((short)2);
    
    // إنشاء الفقرة الرابعة
    Paragraph para4 = new Paragraph();
    // تعيين نمط النقطة للفقرة والرمز
    para4.setText("Fourth Level");
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


## **إنشاء قوائم مرقمة مخصصة**

يوفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لإدارة الفقرات بأعداد مخصصة. لإضافة قائمة رقمية مخصصة في فقرة، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
1. إضافة شكل تلقائي في الشريحة المختارة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في الـ [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. إنشاء الفقرة الأولى باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 2
1. إنشاء الفقرة الثانية باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 3
1. إنشاء الفقرة الثالثة باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 7
1. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. حفظ العرض التقديمي.

هذا الكود بلغة Java يوضح كيفية إنشاء قائمة مرقمة في شريحة:
```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة والوصول إلى Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للـ autoshape المُنشأ
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

نعم، يحتفظ Aspose.Slides بالكامل بتنسيق وبنية القوائم النقطية والمرقمة عند تصدير العروض التقديمية إلى صيغ مثل PDF أو الصور وغيرها، مما يضمن نتائج متسقة.

**هل يمكن استيراد القوائم النقطية أو المرقمة من عروض تقديمية موجودة؟**

نعم، يسمح Aspose.Slides لك باستيراد وتحرير القوائم النقطية أو المرقمة من عروض تقديمية موجودة مع الحفاظ على تنسيقها ومظهرها الأصلي.

**هل يدعم Aspose.Slides القوائم النقطية والمرقمة في العروض المقدمة بعدة لغات؟**

نعم، يدعم Aspose.Slides بالكامل العروض المتعددة اللغات، مما يتيح لك إنشاء القوائم النقطية والمرقمة بأي لغة، بما في ذلك استخدام الأحرف الخاصة أو غير اللاتينية.