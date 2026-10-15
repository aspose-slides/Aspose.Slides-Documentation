---
title: إدارة فقرات نص PowerPoint في Java
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
- Java
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق الفقرات، الأجزاء، النقاط، القوائم المرقمة، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides لل Java."
---
## **نظرة عامة**

Aspose.Slides for Java يمثل النص كهرمية من إطارات النص، الفقرات، والأجزاء:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) يمثل حاوية النص داخل شكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) يمثل فقرة واحدة في إطار النص ويوفر الوصول إلى أجزائه وتنسيق مستوى الفقرة.
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) يمثل تشغيل نص داخل فقرة. يمكن لكل جزء أن يمتلك نصه وتنسيق المستوى الحرفي الخاص به.

يمكن للفقرة إذًا أن تحتوي نصًا بخطوط، ألوان، أحجام وتنسيقات أخرى مختلفة باستخدام عدة أجزاء.

## **إنشاء وتنسيق الفقرات**

أنشئ فقرات في إطار نص الشكل واستخدم الأجزاء لتنسيق تشغيلات النص الفردية. يوضح هذا القسم كيفية دمج عدة أجزاء داخل كل فقرة وتطبيق ألوان، أحجام خطوط، وأنماط مختلفة.

### **إنشاء فقرات مع أجزاء متعددة**

المثال التالي بلغة Java ينشئ ثلاث فقرات، كل منها يحتوي على ثلاثة تشغيلات نص في مجموعة تم إرجاعها بواسطة [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--) . يعيد استخدام الفقرة الافتراضية والجزء الفارغ الخاص بها، ثم يضيف الفقرات والأجزاء المتبقية. يُطبق التنسيق عبر [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) : الجزء الأول في كل فقرة أحمر، غامق، وبحجم 15 نقطة؛ الثاني أزرق، مائل، وبحجم 18 نقطة. الجزء الثالث يحتفظ بالتنسيق الافتراضي:

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

## **إنشاء قوائم نقطية ومرقمة**

نظم نص الفقرة في قوائم باستخدام رموز، أرقام، أو صور مخصصة. تغطي الأمثلة في هذا القسم تنسيق النقاط، القوائم متعددة المستويات، وأرقام البدء المخصصة.

### **إنشاء قائمة نقطية أو مرقمة**

تجعل النقاط والترقيم العناصر ذات الصلة أسهل في القراءة. في Aspose.Slides يتم تعريف إعدادات القائمة عبر [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/).

هذا المثال بلغة Java يضيف نقطة رمز ورقمًا إلى نفس إطار النص. يحدد [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) نوع النقطة، بينما يزود [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) الرمز و[IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) نمط الترقيم. كلا العنصرين يستخدمان نقاط سوداء بارتفاع 100 بالمئة وإزاحة فقرة 25 نقطة:

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

تتيح نقاط الصورة استخدام صورة مخصصة بدلاً من الرمز أو الرقم.

هذا المثال بلغة Java يضيف صورة إلى مجموعة صور العرض كـ [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) ويستخدمها كنقطة فقرة. يستدعي [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) لاستخدام نقطة صورة ويعيّن الصورة عبر [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--). يُعيّن [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) إلى 100 بالمئة لتحديد حجم النقطة نسبة إلى نص الفقرة:

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

اضبط [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) لتحديد مستويات الفقرات في القائمة. المستوى الأعلى له عمق `0`.

هذا المثال بلغة Java يعيّن قيم [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) من 0 إلى 3 لأربع فقرات، مُنشئًا هرمًا داخل إطار نص واحد. كل فقرة تستخدم نقطة رمز، مع تبديل [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) بين نقطة دائرية وشَرطَة لتفريق المستويات المتجاورة:

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

### **بدء عناصر القائمة المرقمة بقيم مخصصة**

استخدم [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) لتعيين الرقم الأول الذي يُعرض لفقرة مرقمة.

هذا المثال بلغة Java يحدد [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) لاستخدام الترقيم لثلاث فقرات ويعيّن قيم [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) بـ 2 و3 و7. يتم تكوين القيمة الابتدائية بشكل منفصل لكل فقرة، مما يسمح بتخطي الأرقام:

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

عدّل هوامش الفقرة وإزاحات السطر للتحكم في موقع السطر الأول والأسطر المتغلفة. يمكنك أيضًا تنسيق علامة نهاية الفقرة بشكل منفصل عن أجزاء النص المرئية.

### **تحديد إزاحة السطر الأول**

استخدم طريقة [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) للتحكم في إزاحة السطر الأول للفقرة. تنقل هذه الإعداد فقط السطر الأول نسبة إلى هوامش الفقرة اليسرى. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذية إلى جسم الفقرة.

استخدم [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) عندما تحتاج إلى تحريك الفقرة كلها. استخدم [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال التالي يمنح ثلاث فقرات نفس [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) البالغ 20 نقطة وقيم [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) بـ 0 و20 و40 نقطة. تبدأ السطور الأولى بإزاحات أكبر تدريجيًا، بينما تحتفظ الأسطر المتغلفة بهامش اليسار نفسه:

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

### **تحديد إزاحة معلقة**

الإزاحة المعلقة هي تخطيط فقرة يبدأ السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides، تنشئ هذا التأثير باستخدام خاصية [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-). اضبط `Indent` على قيمة سلبية لتحريك السطر الأول إلى اليسار نسبة إلى جسم الفقرة.

عمليًا، يحدد [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) موضع الفقرة اليساري، وتحدد [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) موضع السطر الأول نسبة إلى هذا الهامش. لإنشاء إزاحة معلقة، اضبط قيمة `MarginLeft` موجبة وقيمة `Indent` سالبة.

هذا التنسيق مفيد للمراجع والببليوجرافيات ومداخل القاموس وغيرها من الفقرات التي يجب أن تكون الأسطر المتغلفة محاذية تحت جسم الفقرة بدلاً من تحت الحرف الأول للسطر الأول.

المثال التالي بلغة Java يزوج قيم [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) بـ 40 و60 نقطة مع قيم [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) بـ -20 و-30 نقطة. في كل فقرة، يبدأ السطر الأول إلى اليسار من الأسطر المتغلفة؛ الفقرة الثانية لها إزاحة معلقة أعمق:

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

![الإزاحة المعلقة للفقرات](hanging_indent.png)

### **تحديد خصائص نهاية الفقرة**

طريقة [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) تتحكم في تنسيق علامة نهاية الفقرة. المثال التالي ينشئ كائنًا من النوع [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) مع [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) مضبوطًا على 48 نقطة و[IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) مضبوطًا على Times New Roman. يعيّن هذا التنسيق إلى علامة نهاية الفقرة الثانية، مع ترك أجزاء النص المرئية دون تغيير:

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

## **عدّ الأسطر المُرسَمة**

للقواعد التي تؤثر على التفاف النص التلقائي وعلامات الترقيم في نهايات الأسطر، راجع [Control Line Breaking](/slides/ar/java/text-formatting/#control-line-breaking) و[Control Hanging Punctuation](/slides/ar/java/text-formatting/#control-hanging-punctuation).

استخدم [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) لعد الأسطر التي يشغلها الفقرة بعد تخطيط النص، بما في ذلك الالتفاف التلقائي. هذا مفيد عند فحص طول النص وتخطيط القوالب التقديمية.

الفقرة هي عنصر واحد في [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--)، ويمكن أن تحتل عدة أسطر مُرسَمة. كسر سطر صريح داخل الفقرة يُجبر على سطر جديد دون إنشاء فقرة إضافية. الالتفاف التلقائي يُنشئ أسطرًا بناءً على العرض المتاح دون إدخال كسر سطر صريح في النص. لذلك لا يعطي عد الفقرات أو أحرف كسر السطر عدد الأسطر المُرسَمة.

المثال التالي ينشئ شكل نص، يحسب أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. يُفعِّل المثال الالتفاف عبر [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) ويُعطل الضبط التلقائي عبر [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) بحيث يتحكم عرض الشكل في الالتفاف دون تقليص النص أو تغيير حجم الشكل تلقائيًا. كل قياس يستخدم [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--). أبعاد الشكل بالنقاط. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

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

مع هذا النص وهذه الأبعاد، يؤدي تضييق الشكل إلى زيادة عدد الأسطر، بينما يقلل استبدال النص بالسلسلة القصيرة عددها. قد تختلف الأعداد الفعلية حسب توفر الخطوط والاستبدال، حجم الخط، الهوامش، الإزاحة، الالتفاف، وإعدادات الضبط التلقائي. استخدم الخطوط وإعدادات التخطيط المقصودة للبيئة المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدِّد ما إذا كان النص يتجاوز حاويته. الارتفاع المتاح، ارتفاع الأسطر، تباعد الفقرة والسطر، وسلوك الضبط التلقائي أيضًا مهم؛ حتى سطر واحد يمكن أن يتجاوز العرض المتاح عندما يكون الالتفاف معطلاً.

## **استيراد وتصدير محتوى الفقرة**

استخدم HTML لجلب نص إلى عرض تقديمي أو تصدير الفقرات الحالية للاستخدام خارجه. يُظهر هذا القسم أيضًا كيفية تصيير الفقرات الفردية كصور، بما في ذلك الفقرات داخل خلايا الجداول.

### **استيراد نص HTML إلى الفقرات**

استخدم [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) لتحويل علامات HTML إلى فقرات وأجزاء داخل إطار نص.

المثال التالي بلغة Java يقرأ HTML من ملف ويمرّر العلامات إلى [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-). يُزيل الفقرة الافتراضية لإطار النص بحيث يحتوي الإطار فقط على المحتوى المستورد. يترك الشكل المستطيل هوامشًا قدرها 10 نقاط على كل جانب من الشريحة:

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

استخدم [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) لتصدير مجموعة مختارة من الفقرات كـ HTML. عند إعادة استخدام نص العرض على موقع ويب، قد ترغب في الحفاظ على التأكيد المحلي دون نقل خط العرض، حجمه، أو أنماط صندوق النص. اضبط [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) للتحكم في مدى اتباع المُصدّر للوراثة التنسيقية.

حمّل [العرض التوضيحي](text-inheritance.pptx) وضعه في دليل العمل للتطبيق. تحتوي شريحته الأولى على شكل نص واحد بالنص "Inherited text; explicit red 18pt". يستخدم الإدخال عمدًا عدة مستويات تنسيق:

- نمط النص الافتراضي للعرض يزود بخط Calibri وحجم 28 pt.
- نمط النص للطبقة الأولى لإطار النص يزود بنص أزرق ومائلة.
- الفقرة تُحدد صراحةً النص الغامق.
- الجزء الثاني، "explicit red 18pt"، يحدد صراحةً نصًا أحمر وحجم 18 pt.

المثال الكامل التالي يصدر نفس الفقرات ثلاث مرات. يمرّر [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) إلى طريقة التصدير ويكتب كل نتيجة كملف HTML UTF‑8 منفصل:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
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

HTML المُولد يحتوي على CSS التالي للجزء الأول، "Inherited text; ". الجدول يوضح الإعلانات ذات الصلة؛ تُستبعد الخصائص المُولَّدة الأخرى لزيادة الوضوح.

| الناتج | CSS ذو صلة للجزء الأول | المظهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، غامق، مائل بحجم 28 pt في Calibri إذا كان الخط متاحًا. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، غامق، مائل؛ الصفحة أو المتصفح يُوفر خط العائلة والحجم. |
| `ParagraphOnly.html` | `font-weight:bold` | نص غامق؛ الصفحة أو المتصفح يُوفر خط العائلة، الحجم، اللون، والنمط المائل. |

الجزء الثاني يحتفظ بـ `color:#ff0000`، `font-size:18pt`، و`font-weight:bold` في جميع المخرجات الثلاث. كما يحتفظ بالمائل في `All` و`TextBox`، لكن ليس في `ParagraphOnly`. لذلك لا تُزيل تقييد الوراثة التنسيق المُعيّن صراحةً للفقرة أو الجزء.

افتح الملفات في نفس المتصفح للمقارنة. في الوضعين المُقيدين، تُحل الخصائص CSS المُهملة بواسطة أنماط الصفحة الوجهة أو القيم الافتراضية للمتصفح، لذا يعتمد المظهر النهائي على مكان استخدام HTML.

### **تصيير فقرة كصورة**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) يصدر فقرة فردية مباشرةً ويعيد كائنًا من النوع [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/). احفظ النتيجة إلى ملف أو تدفق باستخدام [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). لا تحتاج إلى تصيير الشكل الحاوي أو قص صورة bitmap يدويًا.

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) قد يُعيد `null` إذا تعذر العثور على الفقرة في مجموعتها الأصلية، أو لا توجد حدود تصيير صالحة، أو لا يمكن تصييرها. تحقق من النتيجة قبل حفظها وتخلص من الصورة المرجعة بعد الاستخدام.

#### **تصيير فقرة بالمقياس الافتراضي**

المثال يستخدم عرضًا يحتوي على شريحة واحدة حيث الشكل الأول هو صندوق نص يحتوي على ثلاث فقرات.

![صندوق النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يختار الفقرة الثانية عند الفهرس 1 ويستدعي [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) دون معاملات مقياس. يتحقق من أن الشكل يحتوي على الفقرة المطلوبة وأن التصيير أعاد صورة قبل استدعاء [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) لحفظها بصيغة PNG. كتلة `finally` تُعيد تحرير الصورة بعد الاستخدام.

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

#### **تصيير فقرة داخل خلية جدول مع تعديل المقياس**

استخدم نسخة [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) التي تقبل معاملات `float scaleX` و `float scaleY` لتحديد عوامل المقياس الأفقي والعمودي. يخلق المثال جدولًا، يصدر الفقرة في خليةه الأولى بمضاعفة العرض والارتفاع الافتراضيين، ويحفظ النتيجة كصورة PNG.

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

عامل مقياس `1` يحافظ على الأبعاد الافتراضية بالبكسل. على سبيل المثال، `2` لكل العاملين ينتج صورة عرضها وارتفاعها تقريبًا مزدوجان، أي أربع مرات عدد البكسلات. العوامل الأكبر تُنتج نصًا أكثر حدة للتكبير أو الإخراج عالي الدقة، لكنها تزيد أيضًا من استهلاك الذاكرة وحجم الملف. العوامل تحت `1` تُنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والعمودية المختلفة تُ Stretch الإخراج بشكل مستقل.

تصيير شكل كامل عبر [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) يبقى مفيدًا عندما يجب أن تشمل النتيجة تعبئة الشكل أو حدوده أو سياقه البصري. لتصوير الفقرة فقط، استخدم [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**هل يمكنني تعطيل التفاف السطر تمامًا داخل إطار النص؟**

نعم. اضبط [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) لتعطيل التفاف السطر بحيث لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة على الشريحة بدقة؟**

استخدم [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) لاسترداد مستطيل الحدود للفقرة. يوفر [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط، أو ضبط)؟**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) هو إعداد على مستوى الفقرة ويُطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

لتحاذي الأعمدة بأحجام خطوط مختلفة داخل كل سطر، راجع [Align Fonts Within a Line](/slides/ar/java/text-formatting/#align-fonts-within-a-line).

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. اضبط [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بعدة لغات.