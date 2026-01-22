---
title: إدارة القوائم النقطية والمرقمة في العروض التقديمية على أندرويد
linktitle: إدارة القوائم
type: docs
weight: 60
url: /ar/androidjava/manage-bullet/
keywords:
- نقطة
- قائمة نقطية
- قائمة مرقمة
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
- Android
- Java
- Aspose.Slides
description: "تعرّف على كيفية إدارة القوائم النقطية والمرقمة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لأندرويد عبر جافا. دليل خطوة بخطوة."
---

في **Microsoft PowerPoint**، يمكنك إنشاء القوائم ذات النقاط والمرقمة بنفس الطريقة التي تقوم بها في Word وتحريرات النص الأخرى. **Aspose.Slides for Android via Java** يتيح لك أيضًا استخدام النقاط والأرقام في الشرائح في عروضك التقديمية.

## **لماذا نستخدم القوائم النقطية؟**
تساعد القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة.

**مثال على قائمة نقطية**

في معظم الحالات، تخدم القائمة النقطية ثلاث وظائف رئيسية:
- تجذب انتباه القراء أو المشاهدين إلى المعلومات الهامة
- تسمح للقراء أو المشاهدين بتصفح النقاط الرئيسية بسهولة
- تنقل وتوفر التفاصيل الهامة بكفاءة.

## **لماذا نستخدم القوائم المرقمة؟**
القوائم المرقمة تساعد أيضًا في تنظيم وعرض المعلومات. من الناحية المثالية، ينبغي عليك استخدام الأرقام (بدلاً من النقاط) عندما يكون ترتيب العناصر (على سبيل المثال، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يجب الإشارة إلى عنصر (على سبيل المثال، *انظر الخطوة 3*).

**مثال على قائمة مرقمة**

هذا ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء النقاط** أدناه:
1. إنشاء مثال لفئة العرض التقديمي.
2. تنفيذ عدة مهام (من الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي.

## **إنشاء النقاط**
هذا الموضوع هو أيضًا جزء من سلسلة المواضيع حول إدارة فقرات النص. ستوضح هذه الصفحة كيف يمكننا إدارة نقاط الفقرات. النقاط تكون أكثر فائدة عندما يُراد وصف شيء على مراحل. علاوة على ذلك، يبدو النص منظمًا جيدًا باستخدام النقاط. الفقرات ذات النقاط دائمًا أسهل في القراءة والفهم. سنتعرف على كيفية استخدام المطورين لهذه الميزة الصغيرة ولكن القوية في Aspose.Slides for Android via Java. يرجى اتباع الخطوات أدناه لإدارة نقاط الفقرات باستخدام Aspose.Slides for Android via Java:
1. إنشاء مثال لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
3. إضافة [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) للشكل المضاف.
5. إزالة الفقرة الافتراضية في الـ TextFrame.
6. إنشاء مثال الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph).
7. تعيين نوع النقطة للفقرة.
8. تعيين نوع النقطة إلى [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) وتحديد حرف النقطة.
9. تعيين نص الفقرة.
10. تعيين إزاحة الفقرة لتحديد النقطة.
11. تعيين لون النقطة.
12. تعيين ارتفاع النقاط.
13. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات الـ TextFrame.
14. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات **7 إلى 13**.
15. حفظ العرض التقديمي.

```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة والوصول إلى الشكل التلقائي
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للShape التلقائي المُنشأ
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);
    
    // إنشاء فقرة
    Paragraph para = new Paragraph();
    
    // تعيين نمط نقطة الفقرة والرمز
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


## **إنشاء نقاط بصور**
Aspose.Slides for Android via Java يسمح لك بتغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا أردت إضافة جاذبية بصرية إلى القائمة أو جذب انتباه أكبر إلى العناصر، يمكنك استخدام صورتك الخاصة كنقطة.

{{% alert color="primary" %}} 
من الناحية المثالية، إذا كنت تنوي استبدال رمز النقطة العادي بصورة، قد ترغب في اختيار صورة رسومية بسيطة بخلفية شفافة. هذه الأنواع من الصور تعمل بشكل أفضل كرموز نقاط مخصصة.

على أي حال، سيتم تقليص الصورة التي تختارها إلى حجم صغير جدًا، لذا نوصي بشدة باختيار صورة تبدو جيدة (كبديل للرمز النقطة) في القائمة. 
{{% /alert %}} 

لإنشاء نقطة بصورة، اتبع الخطوات التالية:
1. إنشاء مثال لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
3. إضافة شكل تلقائي في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
6. إنشاء مثال الفقرة الأولى باستخدام فئة Paragraph.
7. تحميل الصورة من القرص في [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).
8. تعيين نوع النقطة إلى Picture وتحديد الصورة.
9. تعيين نص الفقرة.
10. تعيين إزاحة الفقرة لتحديد النقطة.
11. تعيين لون النقطة.
12. تعيين ارتفاع النقاط.
13. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات [TextFrame].
14. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات السابقة.
15. حفظ العرض التقديمي.

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

    // الوصول إلى إطار النص للشكل التلقائي المُنشأ
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
لإنشاء قائمة نقطية تحتوي على عناصر بمستويات مختلفة — قوائم إضافية تحت القائمة النقطية الرئيسية — اتبع الخطوات التالية:
1. إنشاء مثال لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
3. إضافة شكل تلقائي في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
6. إنشاء مثال الفقرة الأولى باستخدام فئة Paragraph وتعيين العمق إلى 0.
7. إنشاء مثال الفقرة الثانية باستخدام فئة Paragraph وتعيين العمق إلى 1.
8. إنشاء مثال الفقرة الثالثة باستخدام فئة Paragraph وتعيين العمق إلى 2.
9. إنشاء مثال الفقرة الرابعة باستخدام فئة Paragraph وتعيين العمق إلى 3.
10. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame].
11. حفظ العرض التقديمي.

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
    // تعيين نمط نقطة الفقرة والرمز
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para1.getParagraphFormat().setDepth ((short)0);
    
    // إنشاء الفقرة الثانية
    Paragraph para2 = new Paragraph();
    // تعيين نمط نقطة الفقرة والرمز
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para2.getParagraphFormat().setDepth ((short)1);
    
    // إنشاء الفقرة الثالثة
    Paragraph para3 = new Paragraph();
    // تعيين نمط نقطة الفقرة والرمز
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تعيين مستوى النقطة
    para3.getParagraphFormat().setDepth ((short)2);
    
    // إنشاء الفقرة الرابعة
    Paragraph para4 = new Paragraph();
    // تعيين نمط نقطة الفقرة والرمز
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
Aspose.Slides for Android via Java يقدم واجهة برمجة تطبيقات بسيطة لإدارة الفقرات مع تنسيق أرقام مخصص. لإضافة قائمة أرقام مخصصة في فقرة، يرجى اتباع الخطوات أدناه:
1. إنشاء مثال لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
3. إضافة شكل تلقائي في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
6. إنشاء مثال الفقرة الأولى باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 2.
7. إنشاء مثال الفقرة الثانية باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 3.
8. إنشاء مثال الفقرة الثالثة باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 7.
9. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame].
10. حفظ العرض التقديمي.

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


## **الأسئلة الشائعة**
**هل يمكن تصدير القوائم النقطية والمرقمة التي تم إنشاؤها باستخدام Aspose.Slides إلى صيغ أخرى مثل PDF أو الصور؟**  
نعم، يحتفظ Aspose.Slides بالكامل بتنسيق وبنية القوائم النقطية والمرقمة عند تصدير العروض التقديمية إلى صيغ مثل PDF أو الصور أو غيرها، مما يضمن نتائج متسقة.

**هل من الممكن استيراد القوائم النقطية أو القوائم المرقمة من العروض التقديمية الموجودة؟**  
نعم، يسمح Aspose.Slides لك باستيراد وتعديل القوائم النقطية أو القوائم المرقمة من العروض التقديمية الموجودة مع الحفاظ على تنسيقها ومظهرها الأصلي.

**هل يدعم Aspose.Slides القوائم النقطية والمرقمة في العروض التقديمية التي تم إنشاؤها بعدة لغات؟**  
نعم، يدعم Aspose.Slides بالكامل العروض التقديمية متعددة اللغات، مما يتيح لك إنشاء القوائم النقطية والمرقمة بأي لغة، بما في ذلك استخدام الأحرف الخاصة أو غير اللاتينية.