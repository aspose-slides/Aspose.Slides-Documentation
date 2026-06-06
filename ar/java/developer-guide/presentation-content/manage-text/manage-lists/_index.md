---
title: إدارة القوائم النقطية والمرقمة في العروض التقديمية بلغة Java
linktitle: إدارة القوائم
type: docs
weight: 60
url: /ar/java/manage-lists/
keywords:
- رصاصة
- قائمة نقطية
- قائمة مرقمة
- رصاصة برمز
- رصاصة بصورة
- رصاصة مخصصة
- قائمة متعددة المستويات
- إنشاء رصاصة
- إضافة رصاصة
- إضافة قائمة
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "تعرف على كيفية إنشاء وتنسيق القوائم النقطية، والقوائم المصورة، والقوائم متعددة المستويات، والقوائم المرقمة في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

Aspose.Slides for Java يتيح لك إنشاء وتنسيق القوائم النقطية والمرقمة في عروض PowerPoint و OpenDocument. عنصر القائمة هو فقرة يتم التحكم في إعدادات الرصاصة الخاصة بها من خلال تنسيق الفقرة.

استخدم طريقة [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getParagraphFormat--) للوصول إلى إعدادات القائمة على مستوى الفقرة. النقطة الرئيسية هي [IParagraphFormat.getBullet](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#getBullet--)، التي تُعيد كائنًا من النوع [IBulletFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/). باستخدام هذا الكائن يمكنك ضبط نوع الرصاصة، الرمز، الصورة، اللون، الحجم، نمط الترقيم، ورقم البداية.

توضح هذه المقالة كيفية:

- إنشاء قائمة نقطية برمز مخصص
- إنشاء رصاصة بصورة
- إنشاء قائمة متعددة المستويات عن طريق ضبط عمق الفقرة
- إنشاء قائمة مرقمة
- فحص وتغيير تنسيق القائمة في عرض تقديمي موجود

## **إنشاء قائمة نقطية**

لإنشاء قائمة نقطية، أضف كائنات [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/) إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) واضبط [IBulletFormat.setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setType-byte-) إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/java/com.aspose.slides/bullettype/#Symbol). ثم يمكنك ضبط [IBulletFormat.setChar](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setChar-char-)، [IBulletFormat.getColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#getColor--)، و[IBulletFormat.setHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setHeight-float-) للتحكم في مظهر الرصاصة.

يوضح الشيفرة Java التالية كيفية إنشاء قائمة نقطية في شريحة:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الرموز النقطية](symbol_bullets.png)

## **إنشاء قائمة مرقمة**

استخدم القوائم المرقمة عندما يكون ترتيب العناصر مهمًا. اضبط [IBulletFormat.setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setType-byte-) إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/java/com.aspose.slides/bullettype/#Numbered). يمكنك أيضًا اختيار تنسيق الترقيم باستخدام [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) أو ضبط [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) عندما يجب أن يبدأ القائمة من قيمة غير 1.

تظهر الشيفرة Java التالية كيفية إنشاء قائمة مرقمة في شريحة:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الرموز المرقمة](numbered_bullets.png)

## **إنشاء رصاصة بصورة**

Aspose.Slides يسمح لك باستبدال رمز الرصاصة العادي بصورة. تعمل الرصاصات المصورة بشكل أفضل مع الصور البسيطة التي تظل قابلة للقراءة بحجم صغير، مثل الأيقونات أو ملفات PNG الشفافة الصغيرة.

{{% alert color="primary" %}}
من الناحية المثالية، إذا كنت تخطط لاستبدال رمز الرصاصة العادي بصورة، فمن الأفضل اختيار رسم بسيط بخلفية شفافة. تعمل مثل هذه الصور جيدًا كرموز رصاص مخصصة.

ضع في اعتبارك أن الصورة سيتم تقليصها إلى حجم صغير جدًا. لهذا السبب، نوصي بشدة باختيار صورة تظل واضحة وفعالة بصريًا عند استخدامها كرصاصة في قائمة.
{{% /alert %}}

لإنشاء رصاصة بصورة، أضف صورة إلى [Presentation.getImages](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getImages--) وعيّن كائن الصورة المرجع إلى [IBulletFormat.getPicture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#getPicture--). اضبط [IBulletFormat.setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setType-byte-) إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/bullettype/#Picture) قبل تعيين الصورة.

لنفترض أن لدينا ملف "image.png":

![صورة للرصاصات](picture_for_bullets.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الرصاصات المصورة](picture_bullets.png)

## **إنشاء قائمة متعددة المستويات**

استخدم [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setDepth-short-) لتضع عناصر القائمة في مستويات مختلفة. المستوى 0 هو المستوى الأعلى، المستوى 1 متداخل تحته، وهكذا.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![القائمة متعددة المستويات](multilevel_list.png)

## **تغيير قائمة موجودة**

لتغيير تنسيق القائمة في عرض تقديمي موجود، احصل على الفقرة المستهدفة وحدث إعدادات [IParagraphFormat.getBullet](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#getBullet--). يمكن استخدام نفس الخصائص المستخدمة لإنشاء القوائم لفحص أو تعديل القوائم التي تم تحميلها من ملف PPT أو PPTX أو ODP.

تغيّر الشيفرة Java التالية الفقرة الأولى في إطار نص لاستخدام نمط قائمة مرقمة:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يمكن تصدير القوائم النقطية والمرقمة إلى PDF أو صور؟**

نعم. تحتفظ Aspose.Slides بتنسيق القوائم عندما يدعم تنسيق الهدف تخطيط النص وميزات الرصاص المقابلة.

**هل يمكنني تعديل القوائم في العروض التقديمية الموجودة؟**

نعم. حمّل العرض التقديمي، احصل على الفقرة المستهدفة، افحص أو حدّث إعدادات [IParagraphFormat.getBullet](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#getBullet--) الخاصة بها، ثم احفظ العرض التقديمي.

**هل يمكن للقوائم احتواء نص غير لاتيني؟**

نعم. يمكن أن يحتوي نص عنصر القائمة على أحرف Unicode، وبالتالي يمكنك إنشاء قوائم في عروض تقديمية متعددة اللغات. تأكد من أن الخطوط المستخدمة في العرض تدعم الأحرف التي تحتاجها.