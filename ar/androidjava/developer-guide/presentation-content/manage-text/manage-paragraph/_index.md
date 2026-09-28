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
  - إزاحة معلقة
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
  - Android
  - Java
  - Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق الفقرات والأجزاء والنقاط والقوائم المرقمة والإزاحات ومحتوى HTML وصور الفقرات باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **نظرة عامة**

Aspose.Slides for Android via Java يمثل النص كهرمية من إطارات النص والفقرات والأجزاء:

* [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) يمثل حاوية النص في شكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [IParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/) يمثل فقرة واحدة في إطار النص ويوفر الوصول إلى أجزائه وتنسيق الفقرة.
* [IPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/) يمثل تشغيل نص داخل الفقرة. يمكن لكل جزء أن يحتوي على نصه وتنسيق المستوى الحرفي الخاص به.

وبالتالي يمكن للفقرة أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام أجزاء متعددة.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات متعددة الأجزاء**

الخطوات التالية تنشئ إطار نص يحتوي على ثلاثة فقرات، كل منها يحتوي على ثلاثة أجزاء:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. احصل على الشريحة ذات الصلة من خلال فهرسها.
3. أضف [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) مستطيل إلى الشريحة.
4. احصل على [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل.
5. استخدم الفقرة الافتراضية وأضف كائنين آخرين من [IParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/) إلى إطار النص.
6. أضف ما يكفي من كائنات [IPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/) لكل فقرة لتحتوي على ثلاثة أجزاء. الفقرة الافتراضية تحتوي بالفعل على جزء فارغ واحد.
7. اضبط نص كل جزء.
8. طبق تنسيق المستوى الحرفي عبر [IPortion.getPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. احفظ العرض التقديمي المعدل.

هذا المثال في Android عبر Java يطبق الخطوات:

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

## **إنشاء القوائم النقطية والمرقمة**

### **إنشاء قائمة نقطية أو مرقمة**

تجعل النقاط والترقيم العناصر المرتبطة أسهل في القراءة. في Aspose.Slides يتم تعريف إعدادات القائمة عبر [IBulletFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/).

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. احصل على الشريحة ذات الصلة من خلال فهرسها.
3. أضف [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى الشريحة المختارة.
4. احصل على [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل.
5. احذف الفقرة الافتراضية من إطار النص.
6. أنشئ [Paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraph/) لنقطة رمزية.
7. اضبط [IBulletFormat.setType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#setType-int-) إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/bullettype/) وحدد حرف النقطة.
8. اضبط نص الفقرة والمسافة واللون وارتفاع النقطة.
9. أضف الفقرة إلى إطار النص.
10. أنشئ فقرة ثانية واضبط [IBulletFormat.setType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#setType-int-) إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/bullettype/).
11. ركّب نمط النقطة المرقمة وأضف الفقرة إلى إطار النص.
12. احفظ العرض التقديمي.

هذا المثال في Android عبر Java ينشئ نقطة رمزية ونقطة مرقمة:

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

### **استخدام نقاط صور**

تتيح لك نقاط الصور استخدام صورة مخصصة بدلاً من رمز أو رقم.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. احصل على الشريحة ذات الصلة من خلال فهرسها.
3. أضف [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) واحصل على [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الخاص به.
4. احذف الفقرة الافتراضية من إطار النص.
5. حمّل صورة النقطة وأضفها إلى مجموعة صور العرض التقديمي كـ [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/).
6. أنشئ [Paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraph/) واضبط نصه.
7. اضبط [IBulletFormat.setType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#setType-int-) إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/bullettype/).
8. عيّن الصورة عبر [IBulletFormat.getPicture](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#getPicture--) واضبط ارتفاع النقطة.
9. أضف الفقرة إلى إطار النص.
10. احفظ العرض التقديمي المعدل.

هذا المثال في Android عبر Java ينشئ نقطة صورة:

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

اضبط [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) لتحديد مستويات الفقرات في القائمة. المستوى الأعلى له عمق `0`.

1. أنشئ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) واحصل على شريحة.
2. أضف [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) وأزل الفقرة الافتراضية من إطار النص الخاص به.
3. أنشئ أربع فقرات وضبط رموز النقاط الخاصة بها.
4. اضبط قيم [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) إلى `0`، `1`، `2` و`3`.
5. أضف الفقرات إلى إطار النص واحفظ العرض التقديمي.

هذا المثال في Android عبر Java ينشئ قائمة نقطية بأربع مستويات:

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

### **بدء عناصر القائمة المرقمة بقيم مخصصة**

استخدم [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) لتعيين الرقم الأولي المعروض لفقرة مرقمة.

1. أنشئ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) وأضف [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى شريحة.
2. احذف الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. أنشئ ثلاث فقرات مرقمة.
4. اضبط [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى `2`، `3` و`7` للفقرات المعنية.
5. أضف الفقرات إلى إطار النص واحفظ العرض التقديمي.

هذا المثال في Android عبر Java يعيّن رقم بدء مخصص لكل فقرة:

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

### **ضبط إزاحة السطر الأول**

استخدم [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) للتحكم في إزاحة السطر الأول للفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى السطور المتبقية محاذية إلى جسم الفقرة.

استخدم [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مختلفة من [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) لتوضيح تأثير إزاحة السطر الأول على تخطيط الفقرة.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. احصل على الشريحة المستهدفة.
3. أضف [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) مستطيل إلى الشريحة.
4. احصل على [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل وأزل الفقرة الافتراضية.
5. أنشئ عدة فقرات واضبط قيم مختلفة من [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) لها.
6. أضف الفقرات إلى إطار النص.
7. احفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية ضبط إزاحة الفقرة:

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

### **ضبط إزاحة معلقة**

الإزاحة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من السطور المتبقية. في Aspose.Slides يمكنك إنشاء هذا التأثير باستخدام [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). مرّر قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، يحدد [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) الموضع الأيسر للجسم، بينما يحدد [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) موضع السطر الأول نسبةً إلى ذلك الهامش. لإنشاء إزاحة معلقة، مرّر قيمة موجبة إلى `setMarginLeft` وقيمة سالبة إلى `setIndent`.

هذا التنسيق مفيد للمراجع، الفهارس، مدخلات القاموس، وغيرها من الفقرات التي يجب أن يكون للسطور الملتفة محاذاة تحت جسم الفقرة وليس تحت الحرف الأول للسطر الأول.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. احصل على الشريحة المستهدفة.
3. أضف [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) مستطيل إلى الشريحة.
4. احصل على [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل وأزل الفقرة الافتراضية.
5. أنشئ فقرات ومرّر قيمة موجبة إلى [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) لكل فقرة.
6. مرّر قيمة سالبة إلى [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) لإنشاء تأثير الإزاحة المعلقة.
7. أضف الفقرات إلى إطار النص.
8. احفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية ضبط إزاحة معلقة لفقرة:

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

![إزاحة معلقة للفقرات](hanging_indent.png)

### **ضبط خصائص نهاية الفقرة**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) يتحكم في تنسيق علامة نهاية الفقرة. المثال التالي يعيّن حجم الخط والخط اللاتيني لعلامة نهاية الفقرة الثانية:

1. حمّل [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) واحصل على شريحة.
2. أضف [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) واحذف الفقرة الافتراضية.
3. أنشئ فقرتين وأضف أجزاء نصية إليهما.
4. أنشئ [PortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. اضبط [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) و[IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. عيّن التنسيق باستخدام [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) واحفظ العرض التقديمي.

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

## **عدد السطور المرسومة**

للقواعد التي تؤثر على التفاف النص التلقائي وعلامات الترقيم عند نهاية السطر، راجع [Control Line Breaking](/slides/ar/androidjava/text-formatting/#control-line-breaking) و[Control Hanging Punctuation](/slides/ar/androidjava/text-formatting/#control-hanging-punctuation).

استخدم [IParagraph.getLinesCount](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) لحساب عدد السطور التي يشغلها الفقرة بعد تخطيط النص، بما في ذلك التفاف النص التلقائي. هذا مفيد عند فحص طول النص وتخطيطه في القوالب.

الفقرة هي عنصر في [ITextFrame.getParagraphs](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getParagraphs--)، ويمكنها أن تشغل عدة سطور مرسومة. كسر السطر الصريح داخل الفقرة يُنشئ سطرًا جديدًا دون إنشاء فقرة أخرى. التفاف النص التلقائي يُنشئ سطورًا بناءً على العرض المتاح دون إدخال فواصل صريحة في النص. لذا فإن عد الفقرات أو أحرف كسر السطر لا يعطي عدد السطور المرسومة.

المثال التالي ينشئ شكل نص، يحسب عدد سطوره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. تم تمكين الالتفاف وتعطيل الملاءمة الذاتية بحيث يتحكم عرض الشكل في الالتفاف دون تصغير النص تلقائيًا أو تغيير حجم الشكل. أبعاد الشكل بالنقاط. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد السطور عبر إطار النص.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

مع هذا النص وهذه الأبعاد، يؤدي تضييق الشكل إلى زيادة عدد السطور، بينما يقلل استبدال النص بالسلسلة القصيرة العدد. قد تختلف الأعداد الدقيقة وفقًا لتوافر الخطوط والاستبدال، حجم الخط، الهوامش، الإزاحة، الالتفاف وإعدادات الملاءمة. استخدم الخطوط وإعدادات التخطيط المستهدفة عند فحص القالب.

عدد السطور وحده لا يحدد ما إذا كان النص سيتجاوز حاويته. الارتفاع المتاح، ارتفاع السطر، تباعد الفقرات والأسطر، وسلوك الملاءمة الذاتية لها أيضًا أثر؛ حتى سطر واحد قد يتجاوز العرض المتاح إذا كان الالتفاف معطلًا.

## **استيراد وتصدير محتوى الفقرة**

### **استيراد نص HTML إلى الفقرات**

استخدم [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) لتحويل تعليمات HTML إلى فقرات وأجزاء في إطار النص.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. احصل على شريحة وأضف [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/).
3. احصل على [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل وأزل الفقرة الافتراضية.
4. اقرأ ملف HTML المصدر.
5. مرّر سلسلة HTML إلى [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. احفظ العرض التقديمي المعدل.

هذا المثال في Android عبر Java يستورد HTML إلى إطار نص:

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

استخدم [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) لتصدير نطاق مختار من الفقرات كـ HTML.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) وحمّل العرض التقديمي المطلوب.
2. احصل على الشريحة واعثر على [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) الذي يحتوي على النص.
3. احصل على [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الخاص بالشكل.
4. استدعِ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) مع فهرس الفقرة البداية وعدد الفقرات المطلوب تصديرها.
5. اكتب سلسلة HTML المستخرجة إلى ملف.

هذا المثال في Android عبر Java يصدر جميع الفقرات من أول شكل نص:

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

### **رندرة فقرة كصورة**

[IParagraph.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#getImage--) يرندِر فقرة فردية مباشرةً ويعيد كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/). احفظ النتيجة إلى ملف أو تدفق باستخدام [IImage.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). لا تحتاج إلى رندرة الشكل الحاوي أو قص صورة يدويًا.

[IParagraph.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#getImage--) قد يُعيد `null` إذا لم تُعثر على الفقرة في مجموعة الأبواب، أو لم يكن لديها حدود رندرة صالحة، أو لا يمكن رندرتها. افحص النتيجة قبل حفظها وتأكد من التخلص من الصورة المسترجعة بعد الاستخدام.

#### **رندرة فقرة بالمقياس الافتراضي**

لنفترض أن لدينا ملف عرض تقديمي اسمه sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يرندِر الفقرة الثانية في شكل نص عادي بالمقياس الافتراضي ويحفظ الصورة الناتجة بصيغة PNG. يضمن قسم `finally` التخلص الصحيح من الصورة.

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

#### **رندرة فقرة داخل خلية جدول مع مقياس**

استخدم نسخة [IParagraph.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) التي تقبل معلمات `float scaleX` و`float scaleY` لتعيين عوامل المقياس الأفقي والعمودي. المثال التالي ينشئ جدولًا، يرندِر الفقرة في خليةه الأولى بمضاعفة العرض والارتفاع الافتراضيين، ويحفظ النتيجة كصورة PNG.

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

العامل `1` يبقي هذا المحور بحجمه البكسلي الافتراضي. على سبيل المثال، `2` لكل العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، ما يعادل أربع مرات عدد البكسلات. العوامل الأكبر عمومًا تُنتج نصًا أكثر حدة للتكبير أو الإخراج عالي الدقة، لكنها تزيد أيضًا من استهلاك الذاكرة وحجم الملف. العوامل الأقل من `1` تُنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والعمودية المختلفة تُطيل الناتج بشكل مستقل.

رندرة شكل كامل باستخدام [IShape.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getImage--) يظل مفيدًا عندما يجب أن يتضمن الإخراج تعبئة الشكل أو حدوده أو سياقه البصري. للحصول على صورة للفقرة فقط، استخدم [IParagraph.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **الأسئلة المتداولة**

**هل يمكنني تعطيل التفاف السطر تمامًا داخل إطار النص؟**

نعم. اضبط [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) لتعطيل الالتفاف بحيث لا تنكسر السطور عند حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة على الشريحة بدقة؟**

استخدم [IParagraph.getRect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#getRect--) لاسترجاع مستطيل حدود الفقرة. [IPortion.getRect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#getRect--) يقدم حدود الجزء الفردي.

**أين يتم التحكم بمحاذاة الفقرة (يسار، يمين، مركز، مبرر)؟**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) هو إعداد على مستوى الفقرة ويطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. اضبط [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بعدة لغات.