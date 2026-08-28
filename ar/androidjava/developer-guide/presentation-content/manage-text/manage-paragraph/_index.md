---
title: إدارة فقرات نص PowerPoint على Android
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
  - إضافة نص
  - إضافة فقرة
  - إدارة النص
  - إدارة الفقرة
  - إدارة النقطة
  - إزاحة الفقرة
  - إزاحة متدلية
  - نقطة الفقرة
  - قائمة رقمية
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
  - Android
  - Java
  - Aspose.Slides
description: "تعلّم كيفية إنشاء وتنسيق الفقرات والقطع والنقاط والقوائم الرقمية والإزافات ومحتوى HTML وصور الفقرات باستخدام Aspose.Slides للـ Android عبر Java."
---
## **نظرة عامة**

Aspose.Slides للـ Android عبر Java تمثل النص كهرمية من إطارات النص، الفقرات، والقطع:

* [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) يمثل حاوية النص داخل الشكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [IParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/) يمثل فقرة واحدة في إطار النص ويوفر الوصول إلى قطعها وتنسيق الفقرة.
* [IPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/) يمثل تسلسل نص داخل الفقرة. يمكن لكل قطع أن يمتلك نصه وتنسيقه على مستوى الأحرف الخاص به.

لذا يمكن للفقرة أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام قطع متعددة.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات مع قطع متعددة**

الخطوات التالية تنشئ إطار نص بثلاث فقرات، كل منها يحتوي على ثلاث قطع:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة ذات الصلة عبر فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة كائنين [IParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/) إضافيين إلى إطار النص.
6. إضافة عدد كافٍ من كائنات [IPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/) لكل فقرة لتحتوي على ثلاث قطع. الفقرة الافتراضية تحتوي بالفعل على قطعة فارغة واحدة.
7. تعيين نص كل قطعة.
8. تطبيق تنسيق على مستوى الأحرف عبر [IPortion.getPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. حفظ العرض التقديمي المعدل.

هذا المثال للـ Android عبر Java ينفذ الخطوات:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **إنشاء القوائم ذات النقط والترقيم**

### **إنشاء قائمة نقطية أو رقمية**

النقاط والترقيم تجعل العناصر المتعلقة أسهل في القراءة. في Aspose.Slides تُعرّف إعدادات القائمة عبر [IBulletFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/).

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة ذات الصلة عبر فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraph/) لنقطة الرمز.
7. تعيين [IBulletFormat.setType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#setType-int-) إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/bullettype/) وتحديد حرف الرمز.
8. تعيين نص الفقرة، والمسافة البادئة، ولون الرمز، وارتفاع الرمز.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وتعيين [IBulletFormat.setType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#setType-int-) إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/bullettype/).
11. تكوين نمط الرمز الرقمي وإضافة الفقرة إلى إطار النص.
12. حفظ العرض التقديمي.

هذا المثال للـ Android عبر Java يخلق نقطة رمز و نقطة رقمية:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **استخدام رموز الصور**

تتيح لك رموز الصور استخدام صورة مخصصة بدلاً من رمز أو رقم.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة ذات الصلة عبر فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) والوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الخاص به.
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة الرمز وإضافتها إلى مجموعة صور العرض التقديمي كـ [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraph/) وتعيين نصها.
7. تعيين [IBulletFormat.setType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#setType-int-) إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/bullettype/).
8. ربط الصورة عبر [IBulletFormat.getPicture](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#getPicture--) وتعيين ارتفاع الرمز.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض التقديمي المعدل.

هذا المثال للـ Android عبر Java يخلق رمز صورة:

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

تعيين [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) لتحديد فقرات في مستويات مختلفة من القائمة. المستوى الأعلى له عمق `0`.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) ومسح الفقرة الافتراضية من إطار النص الخاص به.
3. إنشاء أربع فقرات وتكوين رموزها النقطية.
4. تعيين قيم [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) إلى `0`، `1`، `2`، و`3`.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

هذا المثال للـ Android عبر Java يخلق قائمة نقطية ذات أربع مستويات:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **بدء عناصر القائمة الرقمية بقيم مخصصة**

استخدام [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) لتحديد الرقم الأول المعروض للفقرة الرقمية.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) وإضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى شريحة.
2. مسح الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات رقمية.
4. تعيين [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى `2`، `3`، و`7` للفقرة المقابلة.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

هذا المثال للـ Android عبر Java يحدد رقم بداية مخصص لكل فقرة:

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

### **تعيين إزاحة السطر الأول**

استخدام [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) للتحكم في إزاحة السطر الأول للفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى باقي الأسطر محاذية إلى جسم الفقرة.

استخدم [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مختلفة لـ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) لتوضيح كيفية تأثير إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين إزاحة للفقرة:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![إزاحة السطر الأول للفقرات](first_line_indent.png)

### **تعيين إزاحة متدلية**

إزاحة متدلية هي تخطيط للفقرة حيث يبدأ السطر الأول إلى اليسار من باقي الأسطر. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). مرّر قيمة سلبية لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، يحدد [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) الموضع الأيسر لجسم الفقرة، ويحدد [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) موضع السطر الأول نسبة إلى هذا الهامش. لإنشاء إزاحة متدلية، مرّر قيمة موجبة إلى `setMarginLeft` وقيمة سلبية إلى `setIndent`.

هذا التنسيق مفيد للمراجع، القوائم الببليوغرافية، الملاحظات، وغيرها من الفقرات التي يجب أن تكون الأسطر المتخذة تحت جسم الفقرة وليس تحت أول حرف من السطر الأول.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتمرير قيمة موجبة إلى [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) لكل فقرة.
6. تمرير قيمة سلبية إلى [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) لإنشاء تأثير الإزاحة المتدلية.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين إزاحة متدلية للفقرة:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![إزاحة متدلية للفقرات](hanging_indent.png)

### **تعيين خصائص تشغيل نهاية الفقرة**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) يتحكم في تنسيق علامة نهاية الفقرة. المثال التالي يعيّن حجم الخط وخط Latin لعلامة نهاية الفقرة الثانية:

1. تحميل [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) ومسح الفقرة الافتراضية.
3. إنشاء فقرتين وإضافة قطع نص إليهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. تعيين [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) و[IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. ربط التنسيق باستخدام [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) وحفظ العرض التقديمي.

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

استخدام [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) لتحويل علامة HTML إلى فقرات وقطع داخل إطار نص.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/).
3. وصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) ومسح الفقرة الافتراضية.
4. قراءة ملف HTML المصدر.
5. تمرير سلسلة HTML إلى [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. حفظ العرض التقديمي المعدل.

هذا المثال للـ Android عبر Java يستورد HTML إلى إطار نص:

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

استخدام [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) لتصدير نطاق مختار من الفقرات كملف HTML.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى الشريحة والعثور على [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) الذي يحتوي على النص.
3. وصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/).
4. استدعاء [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) مع فهرس الفقرة البداية وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المُسترجعة إلى ملف.

هذا المثال للـ Android عبر Java يصدر جميع الفقرات من الشكل النصي الأول:

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

### **تحويل الفقرة إلى صورة**

[IParagraph.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#getImage--) يرسم فقرة منفردة مباشرة ويعيد كائن [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/). احفظ النتيجة إلى ملف أو تدفق باستخدام [IImage.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). لا تحتاج إلى رسم الشكل الحاوي أو قص صورة يدويًا.

[IParagraph.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#getImage--) قد يرجع `null` إذا تعذر العثور على الفقرة في المجموعة الأم، أو لا توجد حدود تصيير صالحة، أو لا يمكن تصييرها. تحقق من النتيجة قبل حفظها وتخلص من الصورة المرجعة بعد الاستخدام.

#### **تحويل الفقرة إلى صورة بالمقياس الافتراضي**

لنفترض أن لدينا ملف عرض تقديمي يُدعى sample.pptx يحتوي شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![The text box with three paragraphs](paragraph_to_image_input.png)

المثال التالي يرسم الفقرة الثانية في شكل نص عادي بالمقياس الافتراضي ويحفظ الصورة المسترجعة بصيغة PNG. يضمن الجزء `finally` تحرير الصورة بشكل صحيح.

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

![The paragraph image](paragraph_to_image_output.png)

#### **تحويل الفقرة إلى صورة داخل خلية جدول مع التحجيم**

استخدام نسخة [IParagraph.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) التي تقبل معلمات `float scaleX` و `float scaleY` لتحديد عوامل التحجيم الأفقي والعمودي. المثال التالي ينشئ جدولًا، يرسم الفقرة في خليةه الأولى بمضاعفة عرضها وارتفاعها الافتراضيين، ويحفظ النتيجة كصورة PNG.

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

عامل التحجيم `1` يحافظ على ذلك المحور بحجمه البكسلي الافتراضي. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، أي أربعة أضعاف عدد البكسلات. العوامل الأكبر عادةً ما تُنتج نصًا أكثر حدة للتقريب أو للإخراج عالي الدقة، لكنها تزيد من استهلاك الذاكرة وحجم الملف. العوامل أقل من `1` تنتج صورًا أصغر مع تفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة أبعاد الفقرة؛ عوامل أفقية وعمودية مختلفة تشد الإخراج بصورة مستقلة.

إصدار صورة الشكل بالكامل باستخدام [IShape.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getImage--) يبقى مفيدًا عندما يجب أن يتضمن الإخراج ملء الشكل أو حدوده أو سياقه البصري الآخر. للحصول على صورة للفقرة فقط، استخدم [IParagraph.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **الأسئلة المتكررة**

**هل يمكنني تعطيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. اضبط [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) لتعطيل التفاف النص بحيث لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على الحدود الدقيقة للفقرة على الشريحة؟**

استخدم [IParagraph.getRect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#getRect--) لاسترجاع المستطيل المحيط بالفقرة. يوفر [IPortion.getRect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#getRect--) حدود القطعة الفردية.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط أو ضبط)؟**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) هو إعداد على مستوى الفقرة ويطبق على الفقرة بأكملها بغض النظر عن تنسيق القطع الفردية.

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. اضبط [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) للقطع الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بعدة لغات.