---
title: تنسيق نص PowerPoint في Java
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/java/text-formatting/
keywords:
- تمييز النص
- تعبير نمطي
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- دوران النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الملاءمة التلقائية
- مرساة إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Java. تخصيص الخطوط والألوان والمحاذاة والمزيد."
---

## **تحديد النص**
تم إضافة الطريقة [highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) وفئة [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

تمكنك من تظليل جزء من النص بلون الخلفية باستخدام عينة النص، مشابهة لأداة تلوين النص في PowerPoint 2019.

الشفرة البرمجية أدناه تُظهر كيفية استخدام هذه الميزة:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // تسليط الضوء على جميع الكلمات 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// تسليط الضوء على جميع حالات 'the' المنفصلة
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
توفر Aspose خدمة تحرير PowerPoint مجانية على الإنترنت بسيطة، [خدمة تحرير PowerPoint مجانية على الإنترنت](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **تحديد النص باستخدام التعبير النمطي**
تم إضافة الطريقة [highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) وفئة [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

تمكنك من تظليل جزء من النص بلون الخلفية باستخدام تعبير نمطي، مشابهة لأداة تلوين النص في PowerPoint 2019.

الشفرة البرمجية أدناه تُظهر كيفية استخدام هذه الميزة:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // تسليط الضوء على جميع الكلمات التي طولها 10 أحرف أو أكثر
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين لون خلفية النص**
يتيح Aspose.Slides لك تحديد اللون المفضّل لخلفية النص.

هذه الشفرة Java توضح كيفية تعيين لون الخلفية لنص كامل:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
    portion3.getPortionFormat().setFontBold(NullableBool.True);

    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);

    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    StreamSupport.stream(autoShape.getTextFrame().getParagraphs().spliterator(), false)
            .map(p -> p.getPortions())
            .forEach(c -> c.forEach(ic -> ic.getPortionFormat().getHighlightColor().setColor(Color.BLUE)));

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


هذه الشفرة Java توضح كيفية تعيين لون الخلفية لجزء فقط من النص:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
    portion3.getPortionFormat().setFontBold(NullableBool.True);
    
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    
    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    Optional<IPortion> redPortion = StreamSupport.stream(autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false)
            .filter(p -> p.getText().contains("Red"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **محاذاة فقرات النص**
تنسيق النص هو أحد العناصر الأساسية أثناء إنشاء أي نوع من المستندات أو العروض التقديمية. نعلم أن Aspose.Slides for Java يدعم إضافة النص إلى الشرائح لكن في هذا الموضوع سنستعرض كيفية التحكم في محاذاة فقرات النص داخل الشريحة. يرجى اتباع الخطوات أدناه لمحاذاة فقرات النص باستخدام Aspose.Slides for Java:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة باستخدام فهرستها.
3. الوصول إلى الأشكال Placeholder الموجودة في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
4. الحصول على الفقرة (التي تحتاج إلى محاذاة) من [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#getTextFrame--) المعروضة بواسطة [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين أو اليسار أو الوسط أو ضبطها بالتساوي.
6. حفظ العرض المعدل كملف PPTX.

الشفرة البرمجية أدناه توضح التنفيذ:
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويله إلى AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // تغيير النص في كلا العنصرين النائبين
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // الحصول على الفقرة الأولى من العناصر النائبية
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // محاذاة فقرة النص إلى الوسط
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    //كتابة العرض التقديمي كملف PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين الشفافية للنص**
توضح هذه المقالة كيفية تعيين خاصية الشفافية لأي شكل نص باستخدام Aspose.Slides for Java. لتعيين الشفافية للنص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة.
3. تعيين لون الظل.
4. حفظ العرض كملف PPTX.

الشفرة البرمجية أدناه توضح التنفيذ:
```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparency is: "+ (shadowColor.getAlpha() / 255f) * 100);

    // تعيين الشفافية إلى صفر بالمائة
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين تباعد الأحرف للنص**
يتيح Aspose.Slides لك تعيين الفاصل بين الحروف داخل مربع النص. بهذه الطريقة يمكنك تعديل الكثافة البصرية لسطر أو كتلة نصية عن طريق توسيع أو تقليص التباعد بين الأحرف.

هذه الشفرة Java توضح كيفية توسيع التباعد لسطر نص واحد وتضييقه لسطر آخر:
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // توسيع
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // تقليص

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **إدارة خصائص خط الفقرة**
عادةً ما يحتوي العرض التقديمي على نصوص وصور. يمكن تنسيق النص بطرق متعددة، إما لتسليط الضوء على أقسام وكلمات معينة، أو للتماشى مع الأنماط المؤسسية. يساعد تنسيق النص المستخدمين على تغيير مظهر محتوى العرض. توضح هذه المقالة كيفية استخدام Aspose.Slides for Java لتكوين خصائص خط الفقرات في الشرائح. لإدارة خصائص الخط للفقرة باستخدام Aspose.Slides for Java:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع شريحة باستخدام فهرستها.
3. الوصول إلى الأشكال Placeholder في الشريحة وتحويلها إلى [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
4. الحصول على [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) من [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) المعروضة بواسطة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. ضبط الفقرة بالتساوي.
6. الوصول إلى جزء النص في الفقرة.
7. تعريف الخط باستخدام FontData وتعيين خط الجزء وفقًا لذلك.
   1. تعيين الخط إلى عريض.
   2. تعيين الخط إلى مائل.
8. تعيين لون الخط باستخدام [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#getFillFormat--) المعروض من كائن [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
9. حفظ العرض المعدل إلى ملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

الشفرة البرمجية أدناه توضح التنفيذ على عرض غير مزيّن وتنسيق الخطوط في إحدى الشرائح:
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // الوصول إلى الشريحة باستخدام موضعها
    ISlide slide = pres.getSlides().get_Item(0);

    // الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويلهما إلى AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // الوصول إلى الفقرة الأولى
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // الوصول إلى الجزء الأول
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // تعريف خطوط جديدة
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // تعيين الخطوط الجديدة إلى الجزء
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // تعيين الخط إلى عريض
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // تعيين الخط إلى مائل
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين لون الخط
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // كتابة ملف PPTX إلى القرص
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة عائلة الخط للنص**
يُستخدم الجزء لحمل نص بتنسيق موحد داخل الفقرة. توضح هذه المقالة كيفية استخدام Aspose.Slides for Java لإنشاء مربع نص به بعض النص ثم تعريف خط معين، إضافة إلى خصائص أخرى لعائلة الخط. لإنشاء مربع نص وتعيين خصائص الخط للنص داخله:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة باستخدام فهرستها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) من النوع [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
4. إزالة نمط التعبئة المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. الوصول إلى TextFrame الخاص بـ AutoShape.
6. إضافة بعض النص إلى TextFrame.
7. الوصول إلى كائن Portion المرتبط بـ [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
8. تعريف الخط لتطبيقه على [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
9. تعيين خصائص الخط الأخرى مثل العريض، المائل، التسطير، اللون والارتفاع باستخدام الخصائص المناسبة في كائن Portion.
10. حفظ العرض المعدل كملف PPTX.

الشفرة البرمجية أدناه توضح التنفيذ:
```java
// إنشاء كائن Presentation
Presentation pres = new Presentation();
try {

    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع مستطيل
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // إزالة أي نمط تعبئة مرتبط بـ AutoShape
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // الوصول إلى TextFrame المرتبط بـ AutoShape
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // الوصول إلى Portion المرتبط بـ TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // تعيين الخط للـ Portion
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // تعيين خاصية العريض للخط
    port.getPortionFormat().setFontBold(NullableBool.True);

    // تعيين خاصية المائل للخط
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين خاصية التسطير للخط
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // تعيين ارتفاع الخط
    port.getPortionFormat().setFontHeight(25);

    // تعيين لون الخط
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // كتابة ملف PPTX إلى القرص 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين حجم الخط للنص**
يتيح Aspose.Slides لك اختيار حجم الخط المفضّل للنص الموجود في الفقرة وأي نص قد يُضاف لاحقًا إلى الفقرة.

هذه الشفرة Java توضح كيفية تعيين حجم الخط للنصوص الموجودة في الفقرة:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // يحصل على الشكل الأول، على سبيل المثال.
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // يحصل على الفقرة الأولى، على سبيل المثال.
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // يضبط حجم الخط الافتراضي إلى 20 نقطة لجميع أجزاء النص في الفقرة.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // يضبط حجم الخط إلى 20 نقطة لأجزاء النص الحالية في الفقرة.
        for(IPortion portion : paragraph.getPortions())
        {
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **تعيين دوران النص**
يتيح Aspose.Slides for Java للمطورين تدوير النص. يمكن تعيين النص ليظهر كـ [Horizontal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal)، [Vertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical)، [Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270)، [WordArtVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical)، [EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical)، [MongolianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) أو [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). لتدوير النص في أي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [دوران النص](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. حفظ الملف إلى القرص.

```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من نوع مستطيل
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // إنشاء كائن Paragraph لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // حفظ العرض التقديمي
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين زاوية دوران مخصصة لإطار النص**
يدعم Aspose.Slides for Java الآن تعيين زاوية دوران مخصصة لإطار النص. في هذا الموضوع، سنوضح بمثال كيفية تعيين خاصية RotationAngle في Aspose.Slides. تمت إضافة الطريقتين [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) و [getRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) إلى واجهتي [IChartTextBlockFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) و [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)، مما يسمح بتعيين زاوية دوران مخصصة لإطار النص. لتعيين RotationAngle، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إضافة مخطط إلى الشريحة.
3. [تعيين خاصية RotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. حفظ العرض كملف PPTX.

في المثال أدناه، قمنا بتعيين خاصية RotationAngle.
```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع مستطيل
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // إنشاء كائن Paragraph لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // حفظ العرض التقديمي
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تباعد الأسطر للفقرة**
يوفر Aspose.Slides خصائص تحت [`ParagraphFormat`](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat)—`SpaceAfter`، `SpaceBefore` و `SpaceWithin`—تتيح لك إدارة تباعد الأسطر للفقرة. تُستخدم الخصائص الثلاثة بهذه الطريقة:

* لتحديد تباعد الأسطر للفقرة بنسبة مئوية، استخدم قيمة موجبة.
* لتحديد تباعد الأسطر للفقرة بوحدة النقاط، استخدم قيمة سالبة.

على سبيل المثال، يمكنك تطبيق تباعد أسطر 16pt للفقرة بتعيين خاصية `SpaceBefore` إلى -16.

هكذا يتم تحديد تباعد الأسطر لفقرة معينة:

1. تحميل عرض يحتوي على AutoShape به بعض النص.
2. الحصول على مرجع شريحة عبر فهرستها.
3. الوصول إلى TextFrame.
4. الوصول إلى Paragraph.
5. تعيين خصائص الفقرة.
6. حفظ العرض.

هذه الشفرة Java توضح كيفية تحديد تباعد الأسطر لفقرة:
```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // الحصول على مرجع الشريحة بواسطة فهرسها
    ISlide sld = pres.getSlides().get_Item(0);
    
    // الوصول إلى TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // الوصول إلى الفقرة
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // تعيين خصائص الفقرة
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // حفظ العرض التقديمي
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين خاصية AutofitType لإطار النص**
في هذا الموضوع، نستعرض الخصائص المختلفة لتنسيق إطار النص. تغطي هذه المقالة كيفية تعيين خاصية AutofitType لإطار النص، وتحديد موضع النص وتدويره في العرض. يتيح Aspose.Slides for Java للمطورين تعيين خاصية AutofitType لأي إطار نص. يمكن تعيين AutofitType إلى [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) أو [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape). إذا تم تعيينه إلى [Normal]، يبقى الشكل كما هو بينما يتم تعديل النص دون تغيير الشكل. إذا تم تعيينه إلى [Shape]، يتم تعديل الشكل بحيث يحتوي فقط على النص المطلوب. لتعيين خاصية AutofitType لإطار نص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [تعيين AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) لإطار النص.
6. حفظ الملف إلى القرص.

```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع مستطيل
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // إنشاء كائن Paragraph لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // حفظ العرض التقديمي
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين مرساة لإطار النص**
يتيح Aspose.Slides for Java للمطورين تعيين مرساة لأي TextFrame. يحدد TextAnchorType موضع النص داخل الشكل. يمكن تعيين AnchorType إلى [Top](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top)، [Center](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center)، [Bottom](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom)، [Justified](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) أو [Distributed](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed). لتعيين مرساة لأي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [تعيين TextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) لإطار النص.
6. حفظ الملف إلى القرص.

```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من نوع مستطيل
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // إنشاء كائن Paragraph لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // حفظ العرض التقديمي
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **علامات التبويب وEffectiveTabs في العرض**
جميع مسافات التبويب للنص تُعطى بوحدات البكسل.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|

- EffectiveTabs.ExplicitTabCount (2 في حالتنا) يساوي Tabs.Count.
- مجموعة EffectiveTabs تشمل جميع التبويبات (من مجموعة Tabs والتبويبات الافتراضية).
- EffectiveTabs.ExplicitTabCount (2 في حالتنا) يساوي Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) يوضح المسافة بين التبويبات الافتراضية (3 و 4 في مثالنا).
- EffectiveTabs.GetTabByIndex(index) مع index = 0 يعيد أول تبويب صريح (Position = 731)، index = 1 يُعيد التبويب الثاني (Position = 1241). إذا حاولت الحصول على التبويب التالي بـ index = 2 سيعيد أول تبويب افتراضي (Position = 1470) وهكذا.
- EffectiveTabs.GetTabAfterPosition(pos) يستخدم للحصول على التبويب التالي بعد بعض النص. على سبيل المثال لديك النص: "Hello World!". لتصوير هذا النص تحتاج إلى معرفة مكان بدء رسم "world!". أولًا، احسب طول "Hello" بالبكسل واستدعِ GetTabAfterPosition بالقيمة. ستحصل على موضع التبويب التالي لرسم "world!".

## **تعيين نمط النص الافتراضي**
إذا كنت بحاجة لتطبيق نفس تنسيق النص الافتراضي على جميع عناصر النص في عرض تقديمي مرة واحدة، يمكنك استخدام طريقة `getDefaultTextStyle` من واجهة [IPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/) وتعيين التنسيق المفضَّل. يوضح مثال الشفرة أدناه كيفية تعيين الخط العريض الافتراضي (14 نقطة) للنص في جميع الشرائح في عرض جديد.
```java
Presentation presentation = new Presentation();
try {
    // احصل على تنسيق الفقرة من المستوى الأعلى.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("DefaultTextStyle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **استخراج النص مع تأثير الأحرف الكبيرة كلها**
في PowerPoint، يؤدي تطبيق تأثير **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء من النص باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. للتعامل مع ذلك، تحقق من [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/)—إذا أظهر `All`، قم ببساطة بتحويل السلسلة المسترجعة إلى أحرف كبيرة بحيث يتطابق الخرج مع ما يراه المستخدمون على الشريحة.

لنفترض أن لدينا صندوق نص التالي في الشريحة الأولى من ملف sample2.pptx.

![The All Caps effect](all_caps_effect.png)

يوضح مثال الشفرة أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:
```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    IPortion textPortion = paragraph.getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```


الإخراج:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **الأسئلة المتكررة**

**How to modify text in a table on a slide?**  
لتعديل النص في جدول على شريحة، تحتاج إلى استخدام واجهة [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). يمكنك تكرار جميع الخلايا في الجدول وتغيير النص في كل خلية عبر الوصول إلى خصائص `TextFrame` و `ParagraphFormat` داخل كل خلية.

**How to apply gradient color to text in a PowerPoint slide?**  
لتطبيق لون تدرج على النص، استخدم طريقة `getFillFormat` في [BasePortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/). عيّن `FilFormat` إلى `Gradient`، حيث يمكنك تحديد ألوان البداية والنهاية للتدرج، بالإضافة إلى خصائص أخرى مثل الاتجاه والشفافية لإنشاء تأثير التدرج على النص.