---
title: إدارة القوائم النقطية والمرقمة في العروض التقديمية باستخدام JavaScript
linktitle: إدارة القوائم
type: docs
weight: 60
url: /ar/nodejs-java/manage-bullet/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إدارة القوائم النقطية والمرقمة في عروض PowerPoint و OpenDocument باستخدام JavaScript و Aspose.Slides لـ Node.js. دليل خطوة بخطوة."
---

في **Microsoft PowerPoint**، يمكنك إنشاء القوائم النقطية والمرقمة بنفس الطريقة التي تفعلها في Word وغيرها من محررات النص. **Aspose.Slides for Node.js via Java** يتيح لك أيضًا استخدام النقاط والأرقام في الشرائح في عروضك التقديمية.

## **لماذا تستخدم القوائم النقطية؟**

تساعد القوائم النقطية في تنظيم وتقديم المعلومات بسرعة وكفاءة.

**مثال على قائمة نقطية**

في معظم الحالات، تخدم القائمة النقطية هذه الوظائف الثلاث الرئيسية:

- تجذب انتباه القارئ أو المشاهد إلى معلومات هامة
- تسمح للقارئ أو المشاهد بمسح النقاط الرئيسية بسهولة
- تنقل وتوصل التفاصيل المهمة بكفاءة.

## **لماذا تستخدم القوائم المرقمة؟**

تساعد القوائم المرقمة أيضًا في تنظيم وعرض المعلومات. من المثالي استخدام الأرقام (بدلاً من النقاط) عندما يكون ترتيب الإدخالات (على سبيل المثال، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يجب الإشارة إلى إدخال ما (على سبيل المثال، *انظر الخطوة 3*).

**مثال على قائمة مرقمة**

هذه ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء القوائم النقطية** أدناه:

1. إنشاء مثيل من فئة العرض التقديمي.
2. إجراء عدة مهام (من الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي.

## **إنشاء القوائم النقطية**

هذا الموضوع هو أيضًا جزء من سلسلة مواضيع إدارة فقرات النص. ستوضح هذه الصفحة كيفية إدارة نقاط الفقرات. تكون النقاط أكثر فائدة عندما يتم وصف شيء على مراحل. علاوة على ذلك، يبدو النص منظمًا جيدًا عند استخدام النقاط. الفقرات النقطية تكون دائمًا أسهل في القراءة والفهم. سنرى كيف يمكن للمطورين استخدام هذه الميزة الصغيرة ولكن القوية في Aspose.Slides for Node.js via Java. يرجى اتباع الخطوات أدناه لإدارة نقاط الفقرة باستخدام Aspose.Slides for Node.js via Java:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
1. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) في الشريحة المختارة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) للشكل المضاف.
1. إزالة الفقرة الافتراضية في TextFrame.
1. إنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph).
1. تعيين نوع النقطة للفقرة.
1. تعيين نوع النقطة إلى [Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BulletType#Symbol) وتحديد رمز النقطة.
1. تعيين نص الفقرة.
1. تعيين مسافة الفقرة لتعيين النقطة.
1. تعيين لون النقطة.
1. تعيين ارتفاع النقاط.
1. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات TextFrame.
1. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات **7 إلى 13**.
1. حفظ العرض التقديمي.

هذا مثال الكود في Java—تنفيذ للخطوات أعلاه—يوضح كيفية إنشاء قائمة نقطية في شريحة:
```javascript
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة والوصول إلى AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // الوصول إلى إطار النص للشكل التلقائي المُنشأ
    var txtFrm = aShp.getTextFrame();
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);
    // إنشاء فقرة
    var para = new aspose.slides.Paragraph();
    // تعيين نمط الرصاص للفقرة والرمز
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // تعيين نص الفقرة
    para.setText("Welcome to Aspose.Slides");
    // تعيين إزاحة الرصاص
    para.getParagraphFormat().setIndent(25);
    // تعيين لون الرصاص
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // اضبط IsBulletHardColor إلى true لاستخدام لون رصاص مخصص
    para.getParagraphFormat().getBullet().isBulletHardColor();
    // تعيين ارتفاع الرصاص
    para.getParagraphFormat().getBullet().setHeight(100);
    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);
    // حفظ العرض التقديمي كملف PPTX
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **إنشاء نقاط بصورة**

يتيح Aspose.Slides for Node.js via Java لك تغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا أردت إضافة اهتمام بصري إلى قائمة أو جذب انتباه أكبر إلى عناصر القائمة، يمكنك استخدام صورتك الخاصة كنقطة.

{{% alert color="primary" %}} 
من المثالي، إذا كنت تنوي استبدال رمز النقطة العادي بصورة، قد ترغب في اختيار صورة رسومية بسيطة بخلفية شفافة. تعمل مثل هذه الصور بشكل أفضل كرموز نقاط مخصصة. 

في جميع الأحوال، سيتم تقليل حجم الصورة التي تختارها إلى حجم صغير جدًا، لذا نوصي بشدة باختيار صورة تبدو جيدة (كبديل لرمز النقطة) في القائمة. 
{{% /alert %}} 

لإنشاء نقطة صورة، اتبع هذه الخطوات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide)
1. إضافة شكل أوتوشيب في الشريحة المختارة
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) للشكل المضاف
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe)
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph
1. تحميل الصورة من القرص في [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)
1. تعيين نوع النقطة إلى Picture وتحديد الصورة
1. تعيين نص الفقرة
1. تعيين مسافة الفقرة لتعيين النقطة
1. تعيين لون النقطة
1. تعيين ارتفاع النقاط
1. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe)
1. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات السابقة
1. حفظ العرض التقديمي

هذا الكود في JavaScript يوضح كيفية إنشاء نقطة صورة في شريحة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إنشاء الصورة للنقاط
    var picture;
    var image = aspose.slides.Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // إضافة والوصول إلى AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // الوصول إلى إطار النص للشكل التلقائي المُنشأ
    var txtFrm = aShp.getTextFrame();
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);
    // إنشاء فقرة جديدة
    var para = new aspose.slides.Paragraph();
    para.setText("Welcome to Aspose.Slides");
    // تعيين نمط نقطة الفقرة والصورة
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // تعيين ارتفاع النقطة
    para.getParagraphFormat().getBullet().setHeight(100);
    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);
    // كتابة العرض التقديمي كملف PPTX
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إنشاء نقاط متعددة المستويات**

لإنشاء قائمة نقطية تحتوي على عناصر في مستويات مختلفة—قوائم إضافية تحت القائمة الرئيسية—اتبع هذه الخطوات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
1. إضافة شكل أوتوشيب في الشريحة المختارة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph وتعيين العمق إلى 0.
1. إنشاء مثيل الفقرة الثانية باستخدام فئة Paragraph وتعيين العمق إلى 1.
1. إنشاء مثيل الفقرة الثالثة باستخدام فئة Paragraph وتعيين العمق إلى 2.
1. إنشاء مثيل الفقرة الرابعة باستخدام فئة Paragraph وتعيين العمق إلى 3.
1. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. حفظ العرض التقديمي.

هذا الكود، الذي هو تنفيذ للخطوات أعلاه، يوضح كيفية إنشاء قائمة نقطية متعددة المستويات في JavaScript:
```javascript
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة والوصول إلى AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // الوصول إلى إطار النص للشكل التلقائي المُنشأ
    var txtFrm = aShp.addTextFrame("");
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().clear();
    // إنشاء الفقرة الأولى
    var para1 = new aspose.slides.Paragraph();
    // تعيين نمط رصاص الفقرة والرمز
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // تعيين مستوى الرصاص
    para1.getParagraphFormat().setDepth(0);
    // إنشاء الفقرة الثانية
    var para2 = new aspose.slides.Paragraph();
    // تعيين نمط رصاص الفقرة والرمز
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // تعيين مستوى الرصاص
    para2.getParagraphFormat().setDepth(1);
    // إنشاء الفقرة الثالثة
    var para3 = new aspose.slides.Paragraph();
    // تعيين نمط رصاص الفقرة والرمز
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // تعيين مستوى الرصاص
    para3.getParagraphFormat().setDepth(2);
    // إنشاء الفقرة الرابعة
    var para4 = new aspose.slides.Paragraph();
    // تعيين نمط رصاص الفقرة والرمز
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // تعيين مستوى الرصاص
    para4.getParagraphFormat().setDepth(3);
    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    // حفظ العرض التقديمي كملف PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إنشاء قائمة مرقمة مخصصة**

يوفر Aspose.Slides for Node.js via Java واجهة برمجة تطبيقات بسيطة لإدارة الفقرات مع تنسيق أرقام مخصص. لإضافة قائمة أرقام مخصصة إلى فقرة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
1. إضافة شكل أوتوشيب في الشريحة المختارة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 2
1. إنشاء مثيل الفقرة الثانية باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 3
1. إنشاء مثيل الفقرة الثالثة باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 7
1. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. حفظ العرض التقديمي.

هذا الكود في JavaScript يوضح كيفية إنشاء قائمة مرقمة في شريحة:
```javascript
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة والوصول إلى AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // الوصول إلى إطار النص للشكل التلقائي المُنشأ
    var txtFrm = aShp.addTextFrame("");
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().clear();
    // القائمة الأولى
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);
    // القائمة الثانية
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(5);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);
    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل يمكن تصدير القوائم النقطية والمرقمة التي تم إنشاؤها باستخدام Aspose.Slides إلى صيغ أخرى مثل PDF أو الصور؟**

نعم، يحافظ Aspose.Slides بالكامل على تنسيق وبنية القوائم النقطية والمرقمة عند تصدير العروض التقديمية إلى صيغ مثل PDF أو الصور وغيرها، مما يضمن نتائج متسقة.

**هل من الممكن استيراد القوائم النقطية أو المرقمة من عروض تقديمية موجودة؟**

نعم، يتيح Aspose.Slides لك استيراد وتعديل القوائم النقطية أو المرقمة من عروض تقديمية موجودة مع الحفاظ على تنسيقها ومظهرها الأصلي.

**هل يدعم Aspose.Slides القوائم النقطية والمرقمة في العروض التقديمية التي تم إنشاؤها بعدة لغات؟**

نعم، يدعم Aspose.Slides بالكامل العروض التقديمية متعددة اللغات، مما يسمح لك بإنشاء القوائم النقطية والمرقمة بأي لغة، بما في ذلك استخدام الأحرف الخاصة أو غير اللاتينية.