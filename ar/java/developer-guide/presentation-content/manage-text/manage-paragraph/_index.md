---
title: إدارة فقرات نص PowerPoint في جافا
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
- إدارة نص
- إدارة فقرة
- إدارة علامة نقطية
- إزاحة الفقرة
- إزاحة معلقة
- علامة الفقرة
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
description: "تعلم كيفية إنشاء وتنسيق الفقرات، الجزئيات، العلامات النقطية، القوائم المرقمة، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides للـ Java."
---
## **نظرة عامة**

Aspose.Slides for Java يمثل النص كهرمية من إطارات النص، الفقرات، والجزئيات:

* [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) يمثل حاوية النص في الشكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/) يمثل فقرة واحدة في إطار النص ويوفر الوصول إلى جزئياتها وتنسيق الفقرة.
* [IPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/) يمثل مجموعة نصية داخل فقرة. يمكن لكل جزئية أن تكون لها نص وتنسيق مستوى الحرف الخاص بها.

يمكن للفقرة إذن أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام عدة جزئيات.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات مع عدة جزئيات**

الخطوات التالية تنشئ إطار نص به ثلاث فقرات، كل منها يحتوي على ثلاث جزئيات:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر الفهرس الخاص بها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة فقرتين إضافيتين من نوع [IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/) إلى إطار النص.
6. إضافة ما يكفي من كائنات [IPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/) لكل فقرة لتحتوي على ثلاث جزئيات. الفقرة الافتراضية تحتوي بالفعل على جزئية فارغة واحدة.
7. تعيين نص كل جزئية.
8. تطبيق تنسيق مستوى الحرف عبر [IPortion.getPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#getPortionFormat--).
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

## **إنشاء القوائم النقطية والمرقمة**

### **إنشاء قائمة نقطية أو مرقمة**

تجعل العلامات النقطية والترقيم العناصر المرتبطة أسهل للقراءة. في Aspose.Slides، يتم تعريف إعدادات القائمة عبر [IBulletFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/).

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى الشريحة المختارة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/) لعلامة نقطية رمزية.
7. تعيين [IBulletFormat.setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setType-int-) إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/java/com.aspose.slides/bullettype/) وتحديد حرف العلامة النقطية.
8. تعيين نص الفقرة، الإزاحة، لون العلامة، وارتفاع العلامة.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وتعيين [IBulletFormat.setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setType-int-) إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/java/com.aspose.slides/bullettype/).
11. تكوين نمط العلامة المرقمة وإضافة الفقرة إلى إطار النص.
12. حفظ العرض.

هذا المثال بلغة Java ينشئ علامة نقطية رمزية وعلامة مرقمة:

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

### **استخدام علامات نقطية صورية**

تتيح لك العلامات النقطية الصورية استخدام صورة مخصصة بدلًا من رمز أو رقم.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) والوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) الخاص به.
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة العلامة وإضافتها إلى مجموعة صور العرض كـ [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/) وتعيين نصها.
7. تعيين [IBulletFormat.setType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setType-int-) إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/bullettype/).
8. ربط الصورة عبر [IBulletFormat.getPicture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#getPicture--) وتعيين ارتفاع العلامة.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض المعدل.

هذا المثال بلغة Java ينشئ علامة نقطية صورية:

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
2. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) وإزالة الفقرة الافتراضية من إطار النص الخاص به.
3. إنشاء أربع فقرات وتكوين رموز العلامات النقطية لها.
4. تعيين قيم [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setDepth-short-) إلى `0`، `1`، `2`، و`3`.
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

### **بدء ترقيم عناصر القائمة بقيم مخصصة**

استخدم [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) لتحديد الرقم الأولي المعروض للفقرة المرقمة.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) وإضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى شريحة.
2. مسح الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات مرقمة.
4. تعيين [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى `2`، `3`، و`7` لكل فقرة على حدة.
5. إضافة الفقرات إلى إطار النص وحفظ العرض.

هذا المثال بلغة Java يحدد رقم بدء مخصص لكل فقرة:

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

## **التحكم في تخطيط الفقرة وخواص النهاية**

### **تعيين مسافة إزاحة السطر الأول**

استخدم [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) للتحكم في إزاحة السطر الأول للفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الإيجابية تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذية لجسم الفقرة.

استخدم [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) عندما تريد تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مختلفة من [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) لتوضيح كيفية تأثير إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة الهدف.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-).
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض المعدل.

هذا الكود يوضح كيفية تعيين إزاحة للفقرة:

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

![إزاحة السطر الأول للفقرات](first_line_indent.png)

### **تعيين إزاحة معلقة**

الإزاحة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-). مرّر قيمة سلبية لتحريك السطر الأول إلى اليسار بالنسبة لجسم الفقرة.

عمليًا، [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) يحدّد الموضع الأيسر لجسم الفقرة، و[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) يحدد موضع السطر الأول بالنسبة لهذا الهامش. لإنشاء إزاحة معلقة، مرّر قيمة إيجابية إلى `setMarginLeft` وقيمة سلبية إلى `setIndent`.

يكون هذا التنسيق مفيدًا للملاحق، المراجع، مدخلات القواميس، والفقرات الأخرى التي يتعين أن تكون الأسطر المغلّفة محاذية تحت جسم الفقرة وليس تحت الحرف الأول من السطر الأول.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الوصول إلى الشريحة الهدف.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتمرير قيمة إيجابية إلى [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) لكل منها.
6. تمرير قيمة سلبية إلى [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setIndent-float-) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض المعدل.

هذا الكود يوضح كيفية تعيين إزاحة معلقة لفقرة:

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

![إزاحة معلقة للفقرات](hanging_indent.png)

### **تعيين خصائص تشغيل نهاية الفقرة**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) يتحكم في تنسيق علامة نهاية الفقرة. المثال التالي يعيّن حجم الخط والخط اللاتيني لعلامة نهاية الفقرة الثانية:

1. تحميل [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) ومسح الفقرة الافتراضية.
3. إنشاء فقرتين وإضافة جزئيات نصية لهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. تعيين [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) و[IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. ربط التنسيق باستخدام [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) وحفظ العرض.

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

## **عدد الأسطر المرسومة**

للقواعد المتعلقة بالتفاف النص التلقائي وعلامات الترقيم في نهايات الأسطر، راجع [Control Line Breaking](/slides/ar/java/text-formatting/#control-line-breaking) و[Control Hanging Punctuation](/slides/ar/java/text-formatting/#control-hanging-punctuation).

استخدم [IParagraph.getLinesCount](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getLinesCount--) لعد الأسطر التي يشغلها الفقرة بعد تخطيط النص، بما في ذلك الالتفاف التلقائي. يفيد ذلك عند فحص طول النص وتخطيطه في قوالب العروض.

الفقرة هي عنصر واحد في [ITextFrame.getParagraphs](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getParagraphs--)، ويمكن أن تحتل عدة أسطر مرسومة. كسر السطر الصريح داخل الفقرة يفرض سطرًا جديدًا دون إنشاء فقرة إضافية. الالتفاف التلقائي يولّد أسطرًا بناءً على العرض المتاح دون إدخال فواصل صريحة في النص. لذلك لا يعطي عد الفقرات أو عدد أحرف الفاصل عدد الأسطر المرسومة.

المثال التالي ينشئ شكل نص، يعد أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. تم تمكين الالتفاف وتعطيل الضبط التلقائي بحيث يتحكم عرض الشكل في الالتفاف دون تصغير النص أو تعديل حجم الشكل تلقائيًا. أبعاد الشكل بوحدات النقاط. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

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

مع هذا النص وهذه الأبعاد، يؤدي تضييق الشكل إلى زيادة عدد الأسطر، بينما يقلل استبدال النص بالسلسلة القصيرة العدد. قد تختلف الأعداد الدقيقة بناءً على توفر الخطوط والاستبدال، حجم الخط، الهوامش، الإزاحة، الالتفاف، وإعدادات الضبط التلقائي. استخدم الخطوط وإعدادات التخطيط المخصصة للبيئة المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدد ما إذا كان النص يتعدى الحاوية. الارتفاع المتاح، ارتفاع الأسطر، تباعد الفقرات والأسطر، وسلوك الضبط التلقائي أيضًا مؤثر؛ حتى سطر واحد قد يتجاوز العرض المتاح إذا كان الالتفاف معطلًا.

## **استيراد وتصدير محتوى الفقرات**

### **استيراد نص HTML إلى فقرات**

استخدم [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) لتحويل ترميز HTML إلى فقرات وجزئيات في إطار نص.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
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

استخدم [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) لتصدير نطاق مختار من الفقرات كـ HTML.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) وتحميل العرض المطلوب.
2. الوصول إلى الشريحة والعثور على [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) الذي يحتوي النص.
3. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).
4. استدعاء [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) مع فهرس الفقرة البداية وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المرجعة إلى ملف.

هذا المثال بلغة Java يصدر جميع الفقرات من أول شكل نص:

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

### **رسم الفقرة كصورة**

[IParagraph.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getImage--) يرسم فقرة واحدة مباشرةً ويعيد كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/). احفظ النتيجة إلى ملف أو تدفق باستخدام [IImage.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/#save-java.lang.String-int-). لا تحتاج إلى رسم الشكل الحاوي أو قص صورة يدوياً.

[IParagraph.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getImage--) قد يُعيد `null` إذا لم تُعثر على الفقرة في مجموعة الوالد، أو لا تحتوي على حدود رسم صالحة، أو لا يمكن رسمها. تحقق من النتيجة قبل حفظها وتأكد من تحرير الصورة بعد الاستخدام.

#### **رسم الفقرة بالمقياس الافتراضي**

لنفترض أن لدينا ملف عرض اسمه sample.pptx يحتوي شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يرسم الفقرة الثانية في شكل نص عادي بالمقياس الافتراضي ويحفظ الصورة المرجعة بتنسيق PNG. يضمن قسم `finally` تحرير الصورة بشكل صحيح.

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

#### **رسم الفقرة في خلية جدول مع مقياس**

استخدم نسخة [IParagraph.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getImage-float-float-) التي تقبل معلمي `float scaleX` و`float scaleY` لتحديد معاملَي القياس الأفقي والرأسي. المثال التالي ينشئ جدولًا، يرسم الفقرة في خليةه الأولى بمضاعفة العرض والارتفاع الافتراضيين، ويحفظ النتيجة كصورة PNG.

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

معامل قياس `1` يحافظ على البكسل الافتراضي للمحور. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، ما ينتج أربعة أضعاف عدد البكسلات. العوامل الأكبر عادةً ما تعطي نصًا أكثر وضوحًا للزوم أو الإخراج عالي الدقة، لكنها تزيد من استهلاك الذاكرة وحجم الملف. العوامل الأقل من `1` تُنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والرأسية المختلفة تُطيل الإخراج بشكل مستقل.

رسم شكل كامل باستخدام [IShape.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getImage--) يظل مفيدًا عندما يجب أن يتضمن الإخراج تعبئة الشكل أو حدوده أو سياقه البصري. للصور التي تحتوي على الفقرة فقط، استخدم [IParagraph.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getImage--).

## **الأسئلة المتكررة**

**هل يمكنني تعطيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. عيّن [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) لتعطيل الالتفاف بحيث لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على الحدود الفعلية للفقرة المحددة داخل الشريحة؟**

استخدم [IParagraph.getRect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getRect--) للحصول على مستطيل الحد الخاص بالفقرة. [IPortion.getRect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#getRect--) يقدّم حدود جزئية فردية.

**أين يتم التحكم بمحاذاة الفقرة (يسار، يمين، وسط أو ضبط)؟**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) هو إعداد على مستوى الفقرة ويطبق على الفقرة بالكامل بغض النظر عن تنسيق الجزئيات الفردية.

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. عيّن [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) للجزئيات الفردية، بحيث يمكن للفقرة أن تحتوي نصًا بأكثر من لغة.