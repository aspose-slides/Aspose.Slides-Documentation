---
title: إدارة النقاط
type: docs
weight: 60
url: /ar/nodejs-java/manage-bullet/
keywords: "النقاط, قوائم نقطية, الأرقام, قوائم مرقمة, نقاط صورة, نقاط متعددة المستويات, PowerPoint Presentation, Java, Aspose.Slides for Node.js via Java"
description: "إنشاء قوائم نقطية ومرقمة في عرض PowerPoint باستخدام JavaScript"
---

في **Microsoft PowerPoint**، يمكنك إنشاء قوائم نقطية ومرقمة بنفس الطريقة التي تفعلها في Word وغيرها من محررات النص. **Aspose.Slides for Node.js via Java** يتيح لك أيضًا استخدام النقاط والأرقام في الشرائح داخل عروضك التقديمية.

## **لماذا نستخدم القوائم النقطية؟**

تساعد القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة.

**مثال على قائمة نقطية**

في معظم الحالات، تخدم القائمة النقطية هذه الوظائف الثلاث الرئيسية:

- تجذب انتباه القراء أو المشاهدين إلى المعلومات المهمة
- تسمح للقراء أو المشاهدين بمسح النقاط الرئيسية بسهولة
- تنقل وتوفر التفاصيل المهمة بكفاءة.

## **لماذا نستخدم القوائم المرقمة؟**

تساعد القوائم المرقمة أيضًا في تنظيم وعرض المعلومات. من المثالي استخدام الأرقام (بدلاً من النقاط) عندما يكون ترتيب العناصر (مثلاً، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يجب الإشارة إلى عنصر ما (مثلاً، *انظر الخطوة 3*).

**مثال على قائمة مرقمة**

هذا ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء النقاط** أدناه:

1. إنشاء كائن من فئة العرض التقديمي. 
2. تنفيذ عدة مهام (من الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي. 

## **إنشاء النقاط**

هذا الموضوع هو أيضًا جزء من سلسلة الموضوعات الخاصة بإدارة فقرات النص. ستوضح هذه الصفحة كيفية إدارة نقط الفقرات. تكون النقاط أكثر فائدة عندما يُراد وصف شيء على خطوات. علاوة على ذلك، يبدو النص منظمًا جيدًا باستخدام النقاط. الفقرات النقطية دائمًا أسهل في القراءة والفهم. سنرى كيف يمكن للمطورين استخدام هذه الميزة الصغيرة ولكن القوية في Aspose.Slides for Node.js via Java. يرجى اتباع الخطوات أدناه لإدارة نقاط الفقرة باستخدام Aspose.Slides for Node.js via Java:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
1. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) للشكل الذي تمت إضافته.
1. إزالة الفقرة الافتراضية في الـ TextFrame.
1. إنشاء أول كائن من فئة [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph).
1. تعيين نوع النقطة للفقرة.
1. تعيين نوع النقطة إلى [Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BulletType#Symbol) وتحديد حرف النقطة.
1. تعيين نص الفقرة.
1. تعيين مسافة الفقرة لضبط النقطة.
1. تعيين لون النقطة.
1. تعيين ارتفاع النقاط.
1. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات الـ TextFrame.
1. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات **7 إلى 13**.
1. حفظ العرض التقديمي.

هذا المثال البرمجي بلغة Java—تنفيذ للخطوات أعلاه—يظهر لك كيفية إنشاء قائمة نقطية في شريحة:
```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة والوصول إلى AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // الوصول إلى إطار النص للـ AutoShape المُنشأ
    var txtFrm = aShp.getTextFrame();
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);
    // إنشاء فقرة
    var para = new aspose.slides.Paragraph();
    // تحديد نمط الفقرة النقطية والرمز
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // تحديد نص الفقرة
    para.setText("Welcome to Aspose.Slides");
    // تحديد مسافة الفقرة النقطية
    para.getParagraphFormat().setIndent(25);
    // تحديد لون النقطة
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // تعيين IsBulletHardColor إلى true لاستخدام لون نقطة مخصص
    para.getParagraphFormat().getBullet().isBulletHardColor();
    // تحديد ارتفاع النقطة
    para.getParagraphFormat().getBullet().setHeight(100);
    // إضافة الفقرة إلى إطار النص
    txtFrm.getParagraphs().add(para);
    // حفظ العرض التقديمي كملف PPTX
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **إنشاء نقاط صورة**

Aspose.Slides for Node.js via Java يتيح لك تغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا أردت إضافة عنصر بصري إلى قائمة أو جذب انتباه أكبر إلى عناصر القائمة، يمكنك استخدام صورتك الخاصة كنقطة.

{{% alert color="primary" %}} 

من المثالي، إذا كنت تنوي استبدال رمز النقطة العادي بصورة، أن تختار صورة رسومية بسيطة بخلفية شفافة. تعمل مثل هذه الصور بأفضل شكل كرموز نقط مخصصة. 

في أي حال، سيتم تقليل حجم الصورة التي تختارها إلى حجم صغير جدًا، لذلك نوصي بشدة باختيار صورة تبدو جيدة (كبديل لرمز النقطة) في القائمة. 

{{% /alert %}} 

لإنشاء نقطة بصورة، اتبع هذه الخطوات:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide)
1. إضافة شكل تلقائي في الشريحة المحددة
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) للشكل المضاف
1. إزالة الفقرة الافتراضية في الـ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe)
1. إنشاء أول كائن من فئة Paragraph
1. تحميل صورة من القرص في [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/PPImage)
1. تعيين نوع النقطة إلى Picture وتحديد الصورة
1. تعيين نص الفقرة
1. تعيين مسافة الفقرة لضبط النقطة
1. تعيين لون النقطة
1. تعيين ارتفاع النقاط
1. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe)
1. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات السابقة
1. حفظ العرض التقديمي

هذا الكود بلغة JavaScript يوضح لك كيفية إنشاء نقطة صورة في شريحة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إنشاء صورة للنقاط
    var picture;
    var image = aspose.slides.Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // إضافة والوصول إلى Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // الوصول إلى إطار النص للـ autoshape المنشأ
    var txtFrm = aShp.getTextFrame();
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().removeAt(0);
    // إنشاء فقرة جديدة
    var para = new aspose.slides.Paragraph();
    para.setText("Welcome to Aspose.Slides");
    // ضبط نمط النقطة للفقرة والصورة
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // ضبط ارتفاع النقطة
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

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
1. إضافة شكل تلقائي في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في الـ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. إنشاء أول كائن من فئة Paragraph وتعيين العمق إلى 0.
1. إنشاء ثاني كائن من فئة Paragraph وتعيين العمق إلى 1.
1. إنشاء ثالث كائن من فئة Paragraph وتعيين العمق إلى 2.
1. إنشاء رابع كائن من فئة Paragraph وتعيين العمق إلى 3.
1. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. حفظ العرض التقديمي.

هذا الكود، الذي يُنفّذ الخطوات أعلاه، يوضح لك كيفية إنشاء قائمة نقطية متعددة المستويات بلغة JavaScript:
```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة والوصول إلى AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // الوصول إلى إطار النص للـ AutoShape المُنشأ
    var txtFrm = aShp.addTextFrame("");
    // إزالة الفقرة الافتراضية الموجودة
    txtFrm.getParagraphs().clear();
    // إنشاء الفقرة الأولى
    var para1 = new aspose.slides.Paragraph();
    // تحديد نمط الفقرة النقطية والرمز
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // تحديد مستوى النقطة
    para1.getParagraphFormat().setDepth(0);
    // إنشاء الفقرة الثانية
    var para2 = new aspose.slides.Paragraph();
    // تحديد نمط الفقرة النقطية والرمز
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // تحديد مستوى النقطة
    para2.getParagraphFormat().setDepth(1);
    // إنشاء الفقرة الثالثة
    var para3 = new aspose.slides.Paragraph();
    // تحديد نمط الفقرة النقطية والرمز
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // تحديد مستوى النقطة
    para3.getParagraphFormat().setDepth(2);
    // إنشاء الفقرة الرابعة
    var para4 = new aspose.slides.Paragraph();
    // تحديد نمط الفقرة النقطية والرمز
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // تحديد مستوى النقطة
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

Aspose.Slides for Node.js via Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة الفقرات بتنسيق أرقام مخصص. لإضافة قائمة أرقام مخصصة في فقرة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
1. إضافة شكل تلقائي في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في الـ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. إنشاء أول كائن من فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 2
1. إنشاء ثاني كائن من فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 3
1. إنشاء ثالث كائن من فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 7
1. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. حفظ العرض التقديمي.

هذا الكود بلغة JavaScript يوضح لك كيفية إنشاء قائمة مرقمة في شريحة:
```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة والوصول إلى AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // الوصول إلى إطار النص للـ AutoShape المنشأ
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


## **الأسئلة المتكررة**

**هل يمكن تصدير القوائم النقطية والمرقمة التي تم إنشاؤها باستخدام Aspose.Slides إلى صيغ أخرى مثل PDF أو الصور؟**

نعم، Aspose.Slides يحافظ تمامًا على تنسيق وبنية القوائم النقطية والمرقمة عند تصدير العروض إلى صيغ مثل PDF والصور وغيرها، مما يضمن نتائج متسقة.

**هل يمكن استيراد القوائم النقطية أو المرقمة من عروض تقديمية موجودة؟**

نعم، Aspose.Slides يتيح لك استيراد وتعديل القوائم النقطية أو المرقمة من عروض تقديمية موجودة مع الحفاظ على تنسيقها ومظهرها الأصلي.

**هل يدعم Aspose.Slides القوائم النقطية والمرقمة في العروض التي تم إنشاؤها بمجموعة متعددة من اللغات؟**

نعم، Aspose.Slides يدعم بالكامل العروض متعددة اللغات، ويسمح لك بإنشاء قوائم نقطية ومرقمة بأي لغة، بما في ذلك استخدام الأحرف الخاصة أو غير اللاتينية.