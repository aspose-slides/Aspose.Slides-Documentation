---
title: إدارة القوائم النقطية والمرقمة في العروض التقديمية باستخدام JavaScript
linktitle: إدارة القوائم
type: docs
weight: 60
url: /ar/nodejs-java/manage-lists/
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
description: "تعلم كيفية إنشاء وتنسيق القوائم النقطية، والقوائم المصورة، والقوائم متعددة المستويات، والقوائم المرقمة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

Aspose.Slides for Node.js via Java يتيح لك إنشاء وتنسيق القوائم النقطية والمرقمة في عروض PowerPoint وOpenDocument التقديمية. عنصر القائمة هو فقرة يتم التحكم في إعدادات الرصاصة الخاصة به من خلال تنسيق الفقرة.

استخدم فئة [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) للوصول إلى إعدادات القائمة على مستوى الفقرة. نقطة الدخول الرئيسية هي `Paragraph.getParagraphFormat().getBullet()` التي تُعيد كائنًا من نوع [BulletFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bulletformat/). باستخدام هذا الكائن يمكنك تعيين نوع الرصاصة أو الرمز أو الصورة أو اللون أو الحجم أو نمط الترقيم أو الرقم الابتدائي.

تُظهر هذه المقالة كيفية:

- إنشاء قائمة نقطية برمز مخصص
- إنشاء رصاصة صورة
- إنشاء قائمة متعددة المستويات عن طريق ضبط عمق الفقرة
- إنشاء قائمة مرقمة
- فحص وتغيير تنسيق القائمة في عرض تقديمي موجود

## **إنشاء قائمة نقطية**

لإنشاء قائمة نقطية، أضف كائنات [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) واضبط `BulletFormat.setType` إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bullettype/). يمكنك بعد ذلك تعيين `BulletFormat.setChar` و `BulletFormat.getColor` و `BulletFormat.setHeight` للتحكم في مظهر الرصاصة.

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الرموز النقطية](symbol_bullets.png)

## **إنشاء قائمة مرقمة**

استخدم القوائم المرقمة عندما يكون ترتيب العناصر مهمًا. اضبط `BulletFormat.setType` إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bullettype/). يمكنك أيضًا اختيار تنسيق الترقيم باستخدام `BulletFormat.setNumberedBulletStyle` أو ضبط `BulletFormat.setNumberedBulletStartWith` عندما يجب أن تبدأ القائمة من قيمة غير 1.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الرموز المرقمة](numbered_bullets.png)

## **إنشاء رصاصة صورة**

تسمح لك Aspose.Slides باستبدال رمز الرصاصة العادي بصورة. تعمل رصاصات الصور بشكل أفضل مع الصور البسيطة التي تظل مقروءة بحجم صغير، مثل الأيقونات أو ملفات PNG الشفافة الصغيرة.

{{% alert color="primary" %}}
من المثالي، إذا كنت تخطط لاستبدال رمز الرصاصة العادي بصورة، اختيار رسم بسيط بخلفية شفافة. تعمل هذه الصور جيدًا كرموز رصاصة مخصصة.

تذكر أن الصورة ستُصغر إلى حجم صغير جدًا. لذلك نوصي بشدة باختيار صورة تظل واضحة وفعّالة بصريًا عند استخدامها كرصاصة في قائمة.
{{% /alert %}}

لإنشاء رصاصة صورة، أضف صورة إلى [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) باستخدام `Presentation.getImages().addImage` وعيّن كائن [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) المرتجع إلى `BulletFormat.getPicture().setImage`. اضبط `BulletFormat.setType` إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/bullettype/) قبل تعيين الصورة.

لنفترض أن لدينا ملف "image.png":

![صورة للرّصاصات](picture_for_bullets.png)

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

النتيجة:

![رصاصات الصورة](picture_bullets.png)

## **إنشاء قائمة متعددة المستويات**

استخدم `ParagraphFormat.setDepth` لوضع عناصر القائمة على مستويات مختلفة. المستوى 0 هو المستوى العلوي، المستوى 1 متداخل تحته، وهكذا.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![القائمة متعددة المستويات](multilevel_list.png)

## **تعديل قائمة موجودة**

لتغيير تنسيق القائمة في عرض تقديمي موجود، احصل على الفقرة المستهدفة وحدث إعدادات `ParagraphFormat.getBullet` الخاصة بها. يمكن استخدام نفس الخصائص المستخدمة لإنشاء القوائم لفحص أو تعديل القوائم المحمّلة من ملف PPT أو PPTX أو ODP.

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يمكن تصدير القوائم النقطية والمرقمة إلى PDF أو صور؟**

نعم. تحتفظ Aspose.Slides بتنسيق القائمة عندما يدعم تنسيق الهدف تخطيط النص وميزات الرصاصة المقابلة.

**هل يمكن تحرير القوائم في العروض التقديمية الموجودة؟**

نعم. حمّل العرض التقديمي، احصل على الفقرة المستهدفة، افحص أو حدّث إعدادات `ParagraphFormat.getBullet` الخاصة بها، ثم احفظ العرض التقديمي.

**هل يمكن أن تحتوي القوائم على نص غير لاتيني؟**

نعم. يمكن أن يحتوي نص عنصر القائمة على أحرف يونيكود، لذا يمكنك إنشاء قوائم في عروض تقديمية متعددة اللغات. تأكد من أن الخطوط المستخدمة في العرض تدعم الأحرف التي تحتاجها.