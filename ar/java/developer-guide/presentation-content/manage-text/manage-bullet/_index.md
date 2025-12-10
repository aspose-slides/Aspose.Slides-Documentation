---
title: إدارة القوائم النقطية والرقمية في العروض التقديمية باستخدام Java
linktitle: إدارة القوائم
type: docs
weight: 60
url: /ar/java/manage-bullet/
keywords:
- نقطة
- قائمة نقطية
- قائمة رقمية
- نقطة رمزية
- نقطة صورة
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
description: "تعرف على كيفية إدارة القوائم النقطية والرقمية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Java. دليل خطوة بخطوة."
---

في **Microsoft PowerPoint**، يمكنك إنشاء قوائم نقطية ورقمية بنفس الطريقة التي تفعلها في Word وغيرها من محررات النصوص. **Aspose.Slides for Java** يسمح لك أيضًا باستخدام النقاط والأرقام في الشرائح في عروضك التقديمية. 

## **لماذا نستخدم القوائم النقطية؟**

تساعد القوائم النقطية على تنظيم المعلومات وتقديمها بسرعة وكفاءة. 

**مثال على قائمة نقطية**

في معظم الحالات، تخدم القائمة النقطية هذه الوظائف الثلاث الرئيسية:

- تجذب انتباه القارئ أو المشاهد إلى المعلومات المهمة
- تمكن القارئ أو المشاهد من مسح النقاط الرئيسية بسهولة
- تنقل وتُبلغ التفاصيل المهمة بكفاءة.

## **لماذا نستخدم القوائم الرقمية؟**

القوائم الرقمية تساعد أيضًا في تنظيم وتقديم المعلومات. من المثالي أن تستخدم الأرقام (بدلاً من النقاط) عندما يكون ترتيب العناصر (مثلاً، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يلزم الإشارة إلى عنصر (مثلاً، *انظر الخطوة 3*).

**مثال على قائمة رقمية**

هذا ملخص للخطوات (الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء النقاط** أدناه:

1. إنشاء نسخة من فئة Presentation. 
2. تنفيذ عدة مهام (من الخطوة 3 إلى الخطوة 14). 
3. حفظ العرض التقديمي. 

## **إنشاء النقاط**

هذا الموضوع هو أيضًا جزء من سلسلة مواضيع إدارة فقرات النص. ستوضح هذه الصفحة كيفية إدارة نقاط الفقرة. تكون النقاط أكثر فائدة عندما يتم وصف شيء على خطوات. علاوة على ذلك، يبدو النص منظمًا جيدًا باستخدام النقاط. الفقرات النقطية دائمًا أسهل للقراءة والفهم. سنرى كيف يمكن للمطورين استخدام هذه الميزة الصغيرة ولكن القوية في Aspose.Slides for Java. يرجى اتباع الخطوات أدناه لإدارة نقاط الفقرة باستخدام Aspose.Slides for Java:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) .
2. إضافة [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) للشكل المضاف.
5. إزالة الفقرة الافتراضية في TextFrame.
6. إنشاء نسخة الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) .
7. ضبط نوع النقطة للفقرة.
8. ضبط نوع النقطة إلى [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) وتعيين حرف النقطة.
9. ضبط نص الفقرة.
10. ضبط مسافة الفقرة لتحديد النقطة.
11. ضبط لون النقطة.
12. ضبط ارتفاع النقاط.
13. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات TextFrame.
14. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات **7 إلى 13**.
15. حفظ العرض التقديمي.

هذا مثال الشيفرة في Java—تنفيذ للخطوات أعلاه—يظهر لك كيفية إنشاء قائمة نقطية في شريحة:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للـ AutoShape المنشأ
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
    
    // تعيين إزاحة النقطة
    para.getParagraphFormat().setIndent(25);
    
    // تعيين لون النقطة
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // تعيين IsBulletHardColor إلى true لاستخدام لون نقطة مخصص
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

Aspose.Slides for Java يتيح لك تغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا كنت ترغب في إضافة اهتمام بصري إلى قائمة أو جذب انتباه أكثر إلى العناصر في القائمة، يمكنك استخدام صورتك الخاصة كنقطة. 

{{% alert color="primary" %}} 

من الناحية المثالية، إذا كنت تنوي استبدال رمز النقطة العادي بصورة، قد ترغب في اختيار صورة رسومية بسيطة بخلفية شفافة. تعمل هذه الصور بشكل أفضل كرموز نقاط مخصصة. 

في جميع الأحوال، سيتم تصغير الصورة التي تختارها إلى حجم صغير جدًا، لذا نوصيك بشدة باختيار صورة تبدو جيدة (كبديل لرمز النقطة) في القائمة. 

{{% /alert %}} 

لإنشاء نقطة بصورة، اتبع هذه الخطوات:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) .
3. إضافة AutoShape في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) .
6. إنشاء نسخة الفقرة الأولى باستخدام فئة Paragraph .
7. تحميل الصورة من القرص إلى [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage) .
8. ضبط نوع النقطة إلى Picture وتعيين الصورة.
9. ضبط نص الفقرة.
10. ضبط مسافة الفقرة لتحديد النقطة.
11. ضبط لون النقطة.
12. ضبط ارتفاع النقاط.
13. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) .
14. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات السابقة.
15. حفظ العرض التقديمي

هذا الشيفرة في Java توضح لك كيفية إنشاء نقطة بصورة في شريحة:
```java
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إنشاء صورة للنقاط
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة والوصول إلى الشكل التلقائي
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للشكل التلقائي المنشأ
    ITextFrame txtFrm = aShp.getTextFrame();
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);

    // إنشاء فقرة جديدة
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // تعيين نمط نقطة الفقرة والصورة
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

لإنشاء قائمة نقطية تحتوي على عناصر بمستويات مختلفة—قوائم إضافية تحت القائمة النقطية الرئيسية—اتبع هذه الخطوات:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) .
3. إضافة AutoShape في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) .
6. إنشاء نسخة الفقرة الأولى باستخدام فئة Paragraph وتعيين العمق إلى 0.
7. إنشاء نسخة الفقرة الثانية باستخدام فئة Paragraph وتعيين العمق إلى 1.
8. إنشاء نسخة الفقرة الثالثة باستخدام فئة Paragraph وتعيين العمق إلى 2.
9. إنشاء نسخة الفقرة الرابعة باستخدام فئة Paragraph وتعيين العمق إلى 3.
10. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) .
11. حفظ العرض التقديمي.

هذا الشيفرة، التي هي تنفيذ للخطوات أعلاه، تظهر لك كيفية إنشاء قائمة نقطية متعددة المستويات في Java:
```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى الشكل التلقائي
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للـ AutoShape المنشأ
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
    //تعيين مستوى النقطة
    para1.getParagraphFormat().setDepth ((short)0);
    
    // إنشاء الفقرة الثانية
    Paragraph para2 = new Paragraph();
    // تعيين نمط النقطة للفقرة والرمز
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //تعيين مستوى النقطة
    para2.getParagraphFormat().setDepth ((short)1);
    
    // إنشاء الفقرة الثالثة
    Paragraph para3 = new Paragraph();
    // تعيين نمط النقطة للفقرة والرمز
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //تعيين مستوى النقطة
    para3.getParagraphFormat().setDepth ((short)2);
    
    // إنشاء الفقرة الرابعة
    Paragraph para4 = new Paragraph();
    // تعيين نمط النقطة للفقرة والرمز
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
    
    // حفظ العرض التقديمي كملف PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء قوائم رقمية مخصصة**

Aspose.Slides for Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة الفقرات بأرقام مخصصة. لإضافة قائمة رقمية مخصصة في فقرة، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) .
3. إضافة AutoShape في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) .
6. إنشاء نسخة الفقرة الأولى باستخدام فئة Paragraph وضبط **NumberedBulletStartWith** إلى 2.
7. إنشاء نسخة الفقرة الثانية باستخدام فئة Paragraph وضبط **NumberedBulletStartWith** إلى 3.
8. إنشاء نسخة الفقرة الثالثة باستخدام فئة Paragraph وضبط **NumberedBulletStartWith** إلى 7.
9. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) .
10. حفظ العرض التقديمي.

هذا الشيفرة في Java تظهر لك كيفية إنشاء قائمة رقمية في شريحة:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة والوصول إلى AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للـ AutoShape المنشأ
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


## **الأسئلة الشائعة**

**هل يمكن تصدير القوائم النقطية والرقمية التي تم إنشاؤها باستخدام Aspose.Slides إلى صيغ أخرى مثل PDF أو صور؟**

نعم، يحافظ Aspose.Slides بالكامل على تنسيق وبنية القوائم النقطية والرقمية عند تصدير العروض التقديمية إلى صيغ مثل PDF، الصور، وغيرها، مما يضمن نتائج متسقة.

**هل من الممكن استيراد القوائم النقطية أو الرقمية من عروض تقديمية موجودة؟**

نعم، يتيح Aspose.Slides لك استيراد وتحرير القوائم النقطية أو الرقمية من عروض تقديمية موجودة مع الحفاظ على تنسيقاتها ومظهرها الأصلي.

**هل يدعم Aspose.Slides القوائم النقطية والرقمية في العروض التي تم إنشاؤها بلغات متعددة؟**

نعم، يدعم Aspose.Slides بالكامل العروض التقديمية متعددة اللغات، مما يسمح لك بإنشاء القوائم النقطية والرقمية بأي لغة، بما في ذلك استخدام الأحرف الخاصة أو غير اللاتينية.