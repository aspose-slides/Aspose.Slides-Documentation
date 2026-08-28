---
title: إدارة الفقرات النصية في PowerPoint باستخدام Java
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
  - إضافة نص
  - إضافة فقرة
  - إدارة النص
  - إدارة الفقرة
  - إدارة النقاط
  - المسافة البادئة للفقرة
  - المسافة البادئة المعلقة
  - نقطة الفقرة
  - قائمة مرقمة
  - قائمة نقطية
  - خصائص الفقرة
  - استيراد HTML
  - نص إلى HTML
  - فقرة إلى HTML
  - فقرة إلى صورة
  - نص إلى صورة
  - تصدير الفقرة
  - PowerPoint
  - عرض تقديمي
  - Java
  - Aspose.Slides
description: "تعرف على كيفية إنشاء وتنسيق الفقرات، الأقسام، العلامات النقطية، القوائم المرقمة، المسافات البادئة، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides للغة Java."
---
## **نظرة عامة**

تمثل Aspose.Slides for Java النص كهرمية من إطارات النص والفقرات والأقسام:

* [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) يمثل حاوية النص داخل الشكل ويوفر إمكانية الوصول إلى مجموعة الفقرات الخاصة به.
* [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/) يمثل فقرة واحدة في إطار النص ويوفر إمكانية الوصول إلى أقسامها وتنسيق الفقرة.
* [IPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/) يمثل جزءًا من النص داخل الفقرة. يمكن لكل جزء أن يحتوي على نصه الخاص وتنسيق الأحرف.

يمكن للفقرة إذًا أن تحتوي على نص بخطوط، ألوان، أحجام وتنسيقات أخرى مختلفة باستخدام عدة أقسام.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات ذات أقسام متعددة**

الخطوات التالية تنشئ إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاث أقسام:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة ذات الصلة عبر فهرستها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة كائنين آخرين من نوع [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/) إلى إطار النص.
6. إضافة عدد كافٍ من كائنات [IPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/) لكل فقرة لتحتوي على ثلاث أقسام. الفقرة الافتراضية تحتوي بالفعل على جزء فارغ واحد.
7. تعيين نص كل جزء.
8. تطبيق تنسيق الأحرف عبر [IPortion.getPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#getPortionFormat--).
9. حفظ العرض المعدل.

هذا المثال بلغة Java يطبق الخطوات:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إنشاء قوائم نقطية ورقمية**

### **إنشاء قائمة نقطية أو رقمية**

تساعد النقاط والترقيم على تسهيل قراءة العناصر ذات الصلة. في Aspose.Slides يتم تعريف إعدادات القائمة عبر [IBulletFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/).

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة ذات الصلة عبر فهرستها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة المختارة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/) لرمز النقطة.
7. تعيين [IBulletFormat.setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setType-int-) إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/java/com.aspose.slides/bullettype/) وتحديد حرف النقطة.
8. تعيين نص الفقرة، والمسافة البادئة، ولون النقطة، وارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وتعيين [IBulletFormat.setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setType-int-) إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/java/com.aspose.slides/bullettype/).
11. تكوين نمط النقطة الرقمية وإضافة الفقرة إلى إطار النص.
12. حفظ العرض.

هذا المثال بلغة Java ينشئ نقطة رمزية ونقطة رقمية:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **استخدام نقاط صورة**

تسمح نقاط الصورة باستخدام صورة مخصصة بدلاً من الرمز أو الرقم.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة ذات الصلة عبر فهرستها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) والوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) الخاص به.
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة النقطة وإضافتها إلى مجموعة صور العرض كـ [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/) وتعيين نصه.
7. تعيين [IBulletFormat.setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setType-int-) إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/bullettype/).
8. ربط الصورة عبر [IBulletFormat.getPicture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#getPicture--) وتعيين ارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض المعدل.

هذا المثال بلغة Java ينشئ نقطة صورة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **إنشاء قائمة متعددة المستويات**

تعيين [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setDepth-short-) يضع الفقرات في مستويات مختلفة من القائمة. المستوى الأعلى له عمق `0`.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) ومسح الفقرة الافتراضية من إطار النص الخاص به.
3. إنشاء أربع فقرات وتكوين رموز نقاطها.
4. تعيين قيم [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setDepth-short-) إلى `0` و `1` و `2` و `3`.
5. إضافة الفقرات إلى إطار النص وحفظ العرض.

هذا المثال بلغة Java ينشئ قائمة نقطية بأربع مستويات:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **بدء ترقيم العناصر بقيم مخصصة**

استخدام [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) لتعيين الرقم الأول المعروض للفقرة الرقمية.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) وإضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى شريحة.
2. مسح الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات رقمية.
4. تعيين [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى `2` و `3` و `7` للفقرات المقابلة.
5. إضافة الفقرات إلى إطار النص وحفظ العرض.

هذا المثال بلغة Java يعيّن رقمًا ابتدائيًا مخصصًا لكل فقرة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحكم في تخطيط الفقرة وخصائص النهاية**

### **تعيين مسافة البادئة للسطر الأول**

استخدام [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) للتحكم في مسافة البادئة للسطر الأول من الفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذية إلى جسم الفقرة.

استخدم [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) عندما تحتاج إلى تحريك الفقرة كاملة. واستخدم [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) لتحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيمًا مختلفة لـ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) لتوضيح تأثير مسافة البادئة للسطر الأول على تخطيط الفقرة.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض المعدل.

هذا الكود يوضح كيفية تعيين مسافة بادئة للفقرة:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![المسافة البادئة للسطر الأول من الفقرات](first_line_indent.png)

### **تعيين مسافة بادئة معلقة**

المسافة البادئة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides يمكنك إنشاء هذا التأثير باستخدام [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-). مرّر قيمة سلبية لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) يحدد الموضع الأيسر لجسم الفقرة، و[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) يحدد موضع السطر الأول بالنسبة إلى ذلك الهامش. لإنشاء مسافة بادئة معلقة، مرّر قيمة موجبة إلى `setMarginLeft` وقيمة سلبية إلى `setIndent`.

هذا التنسيق مفيد للمراجع، القوائم الببليوجرافية، مدخلات القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر الملتفة محاذية تحت جسم الفقرة وليس تحت الحرف الأول للسطر الأول.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتمرير قيمة موجبة إلى [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) لكل فقرة.
6. تمرير قيمة سلبية إلى [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) لإنشاء تأثير المسافة البادئة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض المعدل.

هذا الكود يوضح كيفية تعيين مسافة بادئة معلقة لفقرة:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![المسافة البادئة المعلقة للفقرة](hanging_indent.png)

### **تعيين خصائص تشغيل نهاية الفقرة**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) يتحكم في تنسيق علامة نهاية الفقرة. المثال التالي يعيّن حجم الخط والخط اللاتيني لعلامة النهاية في الفقرة الثانية:

1. تحميل [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) ومسح الفقرة الافتراضية.
3. إنشاء فقرتين وإضافة أقسام نصية لهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. تعيين [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) و[IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. ربط التنسيق عبر [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) وحفظ العرض.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استيراد وتصدير محتوى الفقرة**

### **استيراد نص HTML إلى الفقرات**

استخدام [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) لتحويل ترميز HTML إلى فقرات وأقسام داخل إطار النص.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/).
3. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) ومسح الفقرة الافتراضية.
4. قراءة ملف HTML المصدر.
5. تمرير سلسلة HTML إلى [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. حفظ العرض المعدل.

هذا المثال بلغة Java يستورد HTML إلى إطار نص:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **تصدير نص الفقرة إلى HTML**

استخدام [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) لتصدير نطاق محدد من الفقرات كـ HTML.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) وتحميل العرض المطلوب.
2. الوصول إلى الشريحة وإيجاد [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) الذي يحتوي على النص.
3. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).
4. استدعاء [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) مع مؤشر الفقرة البداية وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المسترجعة إلى ملف.

هذا المثال بلغة Java يصدر جميع الفقرات من الشكل النصي الأول:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **تحويل فقرة إلى صورة**

[IParagraph.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getImage--) يُعيد رسم الفقرة الفردية مباشرةً ويُعيد كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/). احفظ النتيجة في ملف أو تدفق باستخدام [IImage.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/#save-java.lang.String-int-). لا تحتاج إلى رسم الشكل المحتوي أو قص صورة يدوية.

[IParagraph.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getImage--) قد يُعيد `null` إذا لم تُعثر الفقرة في مجموعة父ها، أو لا تملك حدود رسم صالحة، أو لا يمكن رسمها. تحقق من النتيجة قبل حفظها وتخلص من الصورة المسترجعة بعد الاستخدام.

#### **رسم الفقرة بالمقياس الافتراضي**

افترض أن لدينا ملف عرض اسمه sample.pptx يحتوي على شريحة واحدة، حيث أول شكل هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يرسم الفقرة الثانية في شكل نص عادي بالمقياس الافتراضي ويُحفظ الصورة المسترجعة بصيغة PNG. يضمن القسم `finally` التخلص من الصورة بشكل صحيح.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

النتيجة:

![صورة الفقرة](paragraph_to_image_output.png)

#### **رسم الفقرة داخل خلية جدول مع ضبط المقياس**

استخدام نسخة [IParagraph.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getImage-float-float-) التي تقبل معايير `float scaleX` و `float scaleY` لتحديد عوامل المقياس الأفقي والعمودي. المثال التالي ينشئ جدولًا، يرسم الفقرة في خليةه الأولى بعرض وارتفاع مضاعفين، ويحفظ النتيجة كصورة PNG.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

القيمة `1` تحافظ على ذلك المحور بحجمه الأصلي بالبكسل. على سبيل المثال، `2` لكل العاملين ينتج صورة عرضها وارتفاعها تقريبًا مرتين عن الأبعاد الافتراضية، أي أربعة أضعاف عدد البكسلات. القيم الأكبر عادةً ما تُنتج نصًا أوضح للزوم أو الإخراج عالي الدقة، لكنها تزيد أيضًا من استهلاك الذاكرة وحجم الملف. القيم الأقل من `1` تُنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والعمودية المختلفة تمدد الإخراج بصورة مستقلة.

رسم الشكل كاملًا باستخدام [IShape.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getImage--) يظل مفيدًا عندما يجب включ включ включ. For a paragraph‑only image, use [IParagraph.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getImage--).

## **الأسئلة الشائعة**

**هل يمكنني تعطيل التفاف النص بالكامل داخل إطار النص؟**

نعم. تعيين [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) إلى تعطيل اللف بحيث لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة بدقة؟**

استخدم [IParagraph.getRect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getRect--) لاسترجاع المستطيل المحيط بالفقرة. يوفر [IPortion.getRect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#getRect--) حدود الجزء الفردي.

**أين يتم التحكم بمحاذاة الفقرة (اليسار، اليمين، الوسط، أو مبرر)؟**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) هو إعداد على مستوى الفقرة ويطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق部分 للفقرة؟**

نعم. تعيين [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) للأقسام الفردية، بحيث يمكن للفقرة أن تحتوي نصًا بعدة لغات.