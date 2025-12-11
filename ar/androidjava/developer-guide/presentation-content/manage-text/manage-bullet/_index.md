---
title: إدارة القوائم النقطية والمرقمة في العروض التقديمية على Android
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
description: "تعلم كيفية إدارة القوائم النقطية والمرقمة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لأجهزة Android عبر Java. دليل خطوة بخطوة."
---

في **Microsoft PowerPoint**, يمكنك إنشاء القوائم النقطية والمرقمة بنفس الطريقة التي تقوم بها في Word وغيرها من محررات النصوص. **Aspose.Slides for Android via Java** يتيح لك أيضًا استخدام النقاط والأرقام في الشرائح في عروضك التقديمية.

## **لماذا نستخدم القوائم النقطية؟**

تساعدك القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة.

**مثال على قائمة نقطية**

في معظم الحالات, تخدم القائمة النقطية هذه الوظائف الثلاث الرئيسية:

- تجذب انتباه قرائك أو مشاهديك إلى المعلومات المهمة
- تسمح لقرائك أو مشاهديك بمسح النقاط الرئيسية بسهولة
- تنقل وتوصل التفاصيل المهمة بكفاءة.

## **لماذا نستخدم القوائم المرقمة؟**

تساعد القوائم المرقمة أيضًا في تنظيم وعرض المعلومات. من المثالي أن تستخدم الأرقام (بدلاً من النقاط) عندما يكون ترتيب العناصر (مثال، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يلزم الإشارة إلى عنصر (مثال، *انظر الخطوة 3*).

**مثال على قائمة مرقمة**

هذا ملخص للخطوات (الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء القوائم النقطية** أدناه:

1. إنشاء نسخة من فئة العرض التقديمي.
2. تنفيذ عدة مهام (الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي.

## **إنشاء القوائم النقطية**
هذا الموضوع هو أيضًا جزء من سلسلة موضوعات إدارة فقرات النص. ستوضح هذه الصفحة كيفية إدارة النقاط في الفقرات. تكون النقاط أكثر فائدة عندما يُراد وصف شيء على خطوات. علاوة على ذلك, يبدو النص منظمًا بشكل جيد باستخدام النقاط. الفقرات النقطية دائمًا ما تكون أسهل للقراءة والفهم. سنرى كيف يمكن للمطورين استخدام هذه الميزة الصغيرة ولكن القوية في Aspose.Slides for Android via Java. يرجى اتباع الخطوات التالية لإدارة نقاط الفقرات باستخدام Aspose.Slides for Android via Java:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام الكائن [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
3. إضافة [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) للشكل المضاف.
5. إزالة الفقرة الافتراضية في الـ TextFrame.
6. إنشاء نسخة الفقرة الأولى باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph).
7. ضبط نوع النقطة للفقرة.
8. ضبط نوع النقطة إلى [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) وتعيين حرف النقطة.
9. تعيين نص الفقرة.
10. ضبط مسافة الفقرة لتعيين النقطة.
11. تعيين لون النقطة.
12. ضبط ارتفاع النقاط.
13. إضافة الفقرة المُنشأة إلى مجموعة فقرات الـ TextFrame.
14. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات **7 إلى 13**.
15. حفظ العرض التقديمي.

```java
// إنشاء كائن من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة الشكل التلقائي والوصول إليه
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للشكل التلقائي المُنشأ
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);
    
    // إنشاء فقرة
    Paragraph para = new Paragraph();
    
    // ضبط نمط الرصاصة في الفقرة والرمز
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // ضبط نص الفقرة
    para.setText("Welcome to Aspose.Slides");
    
    // ضبط مسافة إزاحة الرصاصة
    para.getParagraphFormat().setIndent(25);
    
    // ضبط لون الرصاصة
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // تعيين IsBulletHardColor إلى true لاستخدام لون الرصاصة الخاص
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // ضبط ارتفاع الرصاصة
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

يسمح Aspose.Slides for Android via Java لك بتغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا رغبت في إضافة جذب بصري إلى قائمة أو جذب انتباه أكبر إلى العناصر في القائمة, يمكنك استخدام صورتك الخاصة كنقطة.

{{% alert color="primary" %}} 

من الناحية المثالية, إذا كنت تنوي استبدال رمز النقطة العادي بصورة, قد ترغب في اختيار صورة رسومية بسيطة بخلفية شفافة. تعمل هذه الصور بشكل أفضل كرموز نقاط مخصصة. 

على أي حال, سيتم تقليص حجم الصورة التي تختارها إلى حجم صغير جدًا, لذا نوصي بشدة باختيار صورة تبدو جيدة (كبديل لرمز النقطة) في القائمة. 

{{% /alert %}} 

لإنشاء نقطة صورة, اتبع هذه الخطوات:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام الكائن [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide)
3. إضافة شكل تلقائي في الشريحة المحددة
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) للشكل المضاف
5. إزالة الفقرة الافتراضية في الـ [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
6. إنشاء نسخة الفقرة الأولى باستخدام فئة Paragraph
7. تحميل الصورة من القرص في [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage)
8. ضبط نوع النقطة إلى Picture وتعيين الصورة
9. تعيين نص الفقرة
10. ضبط مسافة الفقرة لتعيين النقطة
11. ضبط لون النقطة
12. ضبط ارتفاع النقاط
13. إضافة الفقرة المُنشأة إلى مجموعة فقرات الـ [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
14. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات السابقة
15. حفظ العرض التقديمي

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

    // إضافة الشكل التلقائي والوصول إليه
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للشكل التلقائي المُنشأ
    ITextFrame txtFrm = aShp.getTextFrame();
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);

    // إنشاء فقرة جديدة
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // ضبط نمط رصاصة الفقرة والصورة
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // ضبط ارتفاع الرصاصة
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

لإنشاء قائمة نقطية تحتوي على عناصر في مستويات مختلفة — قوائم إضافية تحت القائمة النقطية الرئيسية — اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام الكائن [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
3. إضافة شكل تلقائي في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في الـ [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
6. إنشاء نسخة الفقرة الأولى باستخدام فئة Paragraph وتحديد العمق إلى 0.
7. إنشاء نسخة الفقرة الثانية باستخدام فئة Paragraph وتحديد العمق إلى 1.
8. إنشاء نسخة الفقرة الثالثة باستخدام فئة Paragraph وتحديد العمق إلى 2.
9. إنشاء نسخة الفقرة الرابعة باستخدام فئة Paragraph وتحديد العمق إلى 3.
10. إضافة الفقرات المُنشأة إلى مجموعة فقرات الـ [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
11. حفظ العرض التقديمي.

```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة الشكل التلقائي والوصول إليه
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // الوصول إلى إطار النص للشكل التلقائي المُنشأ
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().clear();
    
    // إنشاء الفقرة الأولى
    Paragraph para1 = new Paragraph();
    // ضبط نمط رصاصة الفقرة والرمز
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ضبط مستوى الرصاصة
    para1.getParagraphFormat().setDepth ((short)0);
    
    // إنشاء الفقرة الثانية
    Paragraph para2 = new Paragraph();
    // ضبط نمط رصاصة الفقرة والرمز
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ضبط مستوى الرصاصة
    para2.getParagraphFormat().setDepth ((short)1);
    
    // إنشاء الفقرة الثالثة
    Paragraph para3 = new Paragraph();
    // ضبط نمط رصاصة الفقرة والرمز
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ضبط مستوى الرصاصة
    para3.getParagraphFormat().setDepth ((short)2);
    
    // إنشاء الفقرة الرابعة
    Paragraph para4 = new Paragraph();
    // ضبط نمط رصاصة الفقرة والرمز
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ضبط مستوى الرصاصة
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

يقدم Aspose.Slides for Android via Java واجهة برمجة تطبيقات بسيطة لإدارة الفقرات مع تنسيق أرقام مخصص. لإضافة قائمة أرقام مخصصة في فقرة, يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام الكائن [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
3. إضافة شكل تلقائي في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في الـ [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
6. إنشاء نسخة الفقرة الأولى باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 2
7. إنشاء نسخة الفقرة الثانية باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 3
8. إنشاء نسخة الفقرة الثالثة باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 7
9. إضافة الفقرات المُنشأة إلى مجموعة فقرات الـ [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
10. حفظ العرض التقديمي.

```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة الشكل التلقائي والوصول إليه
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

نعم, يحافظ Aspose.Slides على تنسيق وبنية القوائم النقطية والمرقمة بالكامل عند تصدير العروض التقديمية إلى صيغ مثل PDF أو الصور وغيرها, مما يضمن نتائج متسقة.

**هل من الممكن استيراد قوائم نقطية أو مرقمة من عروض تقديمية موجودة؟**

نعم, يتيح Aspose.Slides لك استيراد وتحرير القوائم النقطية أو المرقمة من العروض الموجودة مع الحفاظ على تنسيقها ومظهرها الأصلي.

**هل يدعم Aspose.Slides القوائم النقطية والمرقمة في عروض تم إنشاؤها بلغات متعددة؟**

نعم, يدعم Aspose.Slides بالكامل العروض متعددة اللغات, مما يتيح لك إنشاء القوائم النقطية والمرقمة بأي لغة, بما في ذلك استخدام أحرف خاصة أو غير لاتينية.