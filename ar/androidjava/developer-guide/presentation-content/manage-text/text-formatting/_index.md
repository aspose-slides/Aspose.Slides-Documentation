---
title: تنسيق نص PowerPoint على Android
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/androidjava/text-formatting/
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
- تدوير النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الضبط التلقائي
- مرساة إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تنسيق وتطبيق الأنماط على النص في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لأجهزة Android عبر Java. تخصيص الخطوط والألوان ومحاذاة النص وغيرها."
---

## **تمييز النص**
تمت إضافة الطريقة [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) وفئة [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

يسمح بتمييز جزء من النص بلون الخلفية باستخدام عينة نصية، مماثل لأداة تمييز النص بلون الخلفية في PowerPoint 2019.

يعرض المقتطف البرمجي أدناه كيفية استخدام هذه الميزة:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // تمييز جميع الكلمات 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// تمييز جميع الظواهر المنفصلة لكلمة 'the'
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
توفر Aspose خدمة تحرير PowerPoint مجانية على الإنترنت وبسيطة [free online PowerPoint editing service](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **تمييز النص باستخدام تعبير عادي**
تمت إضافة الطريقة [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) وفئة [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

يسمح بتمييز جزء من النص بلون الخلفية باستخدام تعبير عادي، مماثل لأداة تمييز النص بلون الخلفية في PowerPoint 2019.

يعرض المقتطف البرمجي أدناه كيفية استخدام هذه الميزة:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // تمييز جميع الكلمات التي تحتوي على 10 رموز أو أكثر
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين لون خلفية النص**
يتيح Aspose.Slides لك تحديد اللون المفضل لخلفية النص.

يعرض هذا الكود Java كيفية تعيين لون الخلفية لنص كامل:
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


يعرض هذا الكود Java كيفية تعيين لون الخلفية فقط لجزء من النص:
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
تنسيق النص هو أحد العناصر الأساسية أثناء إنشاء أي نوع من المستندات أو العروض التقديمية. نعلم أن Aspose.Slides for Android via Java يدعم إضافة النص إلى الشرائح، ولكن في هذا الموضوع سنرى كيف يمكننا التحكم في محاذاة فقرات النص في الشريحة. يرجى اتباع الخطوات أدناه لمحاذاة فقرات النص باستخدام Aspose.Slides for Android via Java:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
3. الوصول إلى الأشكال النائبة الموجودة في الشريحة وتحويل نوعها إلى [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) .
4. الحصول على الفقرة (التي تحتاج إلى محاذاة) من [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) المعرضة بواسطة [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) .
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين أو اليسار أو الوسط أو الضبط.
6. كتابة العرض التقديمي المعدل كملف PPTX.

تنفيذ الخطوات أعلاه موضح أدناه.
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويلهما إلى AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // تعديل النص في كلا العنصرين النائبين
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // الحصول على الفقرة الأولى من العنصرين النائبين
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // محاذاة الفقرة النصية إلى الوسط
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // كتابة العرض التقديمي كملف PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين شفافية للنص**
توضح هذه المقالة كيفية تعيين خاصية الشفافية لأي شكل نص باستخدام Aspose.Slides for Android via Java. لتعيين الشفافية للنص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع شريحة.
3. تعيين لون الظل.
4. كتابة العرض التقديمي كملف PPTX.

تنفيذ الخطوات أعلاه موضح أدناه.
```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparency is: "+ (shadowColor.getAlpha() / 255f) * 100);

    // تعيين الشفافية إلى صفر بالمئة
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين مسافة الأحرف للنص**
يتيح Aspose.Slides لك ضبط المسافة بين الحروف داخل مربع النص. بهذه الطريقة يمكنك تعديل الكثافة البصرية لسطر أو كتلة نصية بزيادة أو تقليل المسافة بين الأحرف.

يعرض هذا الكود Java كيفية توسيع المسافة لسطر نص واحد وتضييق المسافة لسطر آخر:
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // توسيع
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // تكثيف

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **إدارة خصائص خط الفقرة**
عادةً ما تحتوي العروض التقديمية على نصوص وصور. يمكن تنسيق النص بطرق متعددة، إما لتمييز أقسام وكلمات معينة، أو للامتثال للأنماط المؤسسية. يساعد تنسيق النص المستخدمين على تنويع مظهر محتوى العرض. توضح هذه المقالة كيفية استخدام Aspose.Slides for Android via Java لتكوين خصائص الخط للفقرات النصية على الشرائح. لإدارة خصائص الخط للفقرة باستخدام Aspose.Slides for Android via Java:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع شريحة باستخدام فهرسها.
3. الوصول إلى الأشكال النائبة في الشريحة وتحويل نوعها إلى [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) .
4. الحصول على [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) من [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) المعروض بواسطة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) .
5. محاذاة الفقرة.
6. الوصول إلى جزء النص في الفقرة.
7. تعريف الخط باستخدام FontData وتعيين الخط لجزء النص وفقًا لذلك.
   1. تعيين الخط إلى غامق.
   2. تعيين الخط إلى مائل.
8. تحديد لون الخط باستخدام [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) المعروض بواسطة كائن [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) .
9. كتابة العرض التقديمي المعدل إلى ملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

تنفيذ الخطوات أعلاه موضح أدناه. يأخذ عرضًا تقديميًا غير معدل ويضبط الخطوط في إحدى الشرائح.
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // الوصول إلى شريحة باستخدام موضعها
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

    // تحديد خطوط جديدة
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // تعيين الخطوط الجديدة للجزء
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // تعيين الخط إلى غامق
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
يُستخدم الجزء (Portion) لحمل نص ذو نمط تنسيق مشابه داخل الفقرة. توضح هذه المقالة كيفية استخدام Aspose.Slides for Android via Java لإنشاء مربع نص يحتوي على بعض النص ثم تعريف خط معين، بالإضافة إلى خصائص أخرى لعائلة الخط. لإنشاء مربع نص وتعيين خصائص الخط للنص داخله:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع شريحة باستخدام فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من النوع [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
4. إزالة نمط التعبئة المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) .
5. الوصول إلى TextFrame الخاص بالشكل التلقائي.
6. إضافة بعض النص إلى TextFrame.
7. الوصول إلى كائن Portion المرتبط بـ [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) .
8. تعريف الخط المستخدم لـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) .
9. تعيين خصائص الخط الأخرى مثل الغامق، المائل، التحتي، اللون والارتفاع باستخدام الخصائص ذات الصلة المعروضة بواسطة كائن Portion.
10. كتابة العرض التقديمي المعدل كملف PPTX.

تنفيذ الخطوات أعلاه موضح أدناه.
```java
// إنشاء كائن Presentation
Presentation pres = new Presentation();
try {

    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من النوع Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // إزالة أي نمط تعبئة مرتبط بـ AutoShape
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // الوصول إلى TextFrame المرتبط بـ AutoShape
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // الوصول إلى Portion المرتبط بـ TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // تعيين الخط للجزء
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // تعيين خاصية الخط الغامق
    port.getPortionFormat().setFontBold(NullableBool.True);

    // تعيين خاصية الخط المائل
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين خاصية الخط المسطر
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
يتيح Aspose.Slides لك اختيار حجم الخط المفضل للنص الموجود في الفقرة والنصوص التي قد تُضاف لاحقًا إلى الفقرة.

يعرض هذا الكود Java كيفية تعيين حجم الخط للنصوص الموجودة في الفقرة:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // الحصول على الشكل الأول، على سبيل المثال.
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // الحصول على الفقرة الأولى، على سبيل المثال.
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // تعيين حجم الخط الافتراضي إلى 20 نقطة لجميع أجزاء النص في الفقرة.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // تعيين حجم الخط إلى 20 نقطة لأجزاء النص الحالية في الفقرة.
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
يتيح Aspose.Slides for Android via Java للمطورين إمكانية تدوير النص. يمكن ضبط النص للظهور كـ [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal)، [Vertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical)، [Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270)، [WordArtVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical)، [EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical)، [MongolianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) أو [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). لتدوير نص أي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) .
5. تدوير النص باستخدام [Rotate the text](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) .
6. حفظ الملف إلى القرص.

```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من النوع Rectangle
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
يدعم الآن Aspose.Slides for Android via Java تعيين زاوية دوران مخصصة لإطار النص. في هذا الموضوع سنرى مثالًا على كيفية تعيين خاصية RotationAngle في Aspose.Slides. تم إضافة الطريقتين [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) و [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) إلى واجهات [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) و [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat)، مما يسمح بتعيين زاوية دوران مخصصة لإطار النص. لتعيين RotationAngle، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. إضافة رسم بياني إلى الشريحة.
3. تعيين خاصية RotationAngle باستخدام [Set RotationAngle property](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) .
4. كتابة العرض التقديمي كملف PPTX.

في المثال أدناه، نقوم بتعيين خاصية RotationAngle.
```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من النوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // الوصول إلى TextFrame
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


## **تباعد الأسطر في الفقرة**
يوفر Aspose.Slides خصائص ضمن [`ParagraphFormat`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat)—`SpaceAfter`، `SpaceBefore` و `SpaceWithin`—تتيح لك إدارة تباعد الأسطر للفقرة. تُستخدم الخصائص الثلاثة كالتالي:

* لتحديد تباعد الأسطر للفقرة بالنسبة المئوية، استخدم قيمة موجبة. 
* لتحديد تباعد الأسطر للفقرة بالنقاط، استخدم قيمة سالبة.

على سبيل المثال، يمكنك تطبيق تباعد أسطر 16pt للفقرة عن طريق تعيين خاصية `SpaceBefore` إلى -16.

هذه هي طريقة تحديد تباعد الأسطر لفقرة معينة:

1. تحميل عرض تقديمي يحتوي على AutoShape مع نص داخله.
2. الحصول على مرجع شريحة عبر فهرسه.
3. الوصول إلى TextFrame.
4. الوصول إلى الفقرة.
5. تعيين خصائص الفقرة.
6. حفظ العرض التقديمي.

يعرض هذا الكود Java كيفية تحديد تباعد الأسطر لفقرة:
```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها
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
في هذا الموضوع، نستكشف خصائص تنسيق مختلفة لإطار النص. تغطي هذه المقالة كيفية تعيين خاصية AutofitType لإطار النص، موضع النص وتدوير النص في العرض التقديمي. يسمح Aspose.Slides for Android via Java للمطورين بتعيين خاصية AutofitType لأي إطار نص. يمكن تعيين AutofitType إلى [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) أو [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape). إذا تم تعيينه إلى [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) فسيبقى الشكل كما هو بينما يتم تعديل النص دون تغيير الشكل، أما إذا تم تعيينه إلى [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape) فسيتم تعديل الشكل بحيث يحتوي فقط على النص المطلوب. لتعيين خاصية AutofitType لإطار نص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) .
5. تعيين AutofitType باستخدام [Set the AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) لإطار النص.
6. حفظ الملف إلى القرص.

```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من النوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // الوصول إلى TextFrame
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
يسمح Aspose.Slides for Android via Java للمطورين بتعيين مرساة لأي TextFrame. يحدد TextAnchorType موقع النص داخل الشكل. يمكن تعيين AnchorType إلى [Top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top)، [Center](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center)، [Bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom)، [Justified](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) أو [Distributed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed). لتعيين مرساة لأي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) .
5. تعيين TextAnchorType باستخدام [Set TextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) لإطار النص.
6. حفظ الملف إلى القرص.

```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من النوع Rectangle
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


## **التبويبات وEffectiveTabs في عرض تقديمي**
جميع مسافات التبويب النصية معطاة بوحدات البكسل.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|

- خاصية EffectiveTabs.ExplicitTabCount (2 في مثالنا) تساوي Tabs.Count.
- مجموعة EffectiveTabs تشمل جميع التبويبات (من مجموعة Tabs والتبويبات الافتراضية).
- خاصية EffectiveTabs.ExplicitTabCount (2 في مثالنا) تساوي Tabs.Count.
- خاصية EffectiveTabs.DefaultTabSize (294) تُظهر المسافة بين التبويبات الافتراضية (3 و 4 في مثالنا).
- الدالة EffectiveTabs.GetTabByIndex(index) مع index = 0 تُعيد أول تبويب صريح (Position = 731)، index = 1 تُعيد التبويب الثاني (Position = 1241). إذا حاولت الحصول على تبويب التالي بـ index = 2 فستعيد أول تبويب افتراضي (Position = 1470) وهكذا.
- الدالة EffectiveTabs.GetTabAfterPosition(pos) تُستخدم للحصول على التبويب التالي بعد بعض النص. على سبيل المثال لديك النص: "Hello World!". لتصوير هذا النص تحتاج إلى معرفة مكان بدء رسم "world!". أولًا، احسب طول "Hello" بالبكسل ثم استدعِ GetTabAfterPosition بالقيمة. ستحصل على موضع التبويب التالي لرسم "world!".

## **تعيين نمط النص الافتراضي**
إذا كنت تحتاج إلى تطبيق تنسيق نص افتراضي موحد على جميع عناصر النص في عرض تقديمي دفعة واحدة، يمكنك استخدام طريقة `getDefaultTextStyle` من واجهة [IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) وتعيين التنسيق المفضل. يوضح المثال البرمجي أدناه كيفية تعيين الخط الغامق الافتراضي (14 pt) للنص على جميع الشرائح في عرض تقديمي جديد.
```java
Presentation presentation = new Presentation();
try {
    // الحصول على تنسيق الفقرة من المستوى الأعلى.
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


## **استخراج النص مع تأثير الحروف الكبيرة**
في PowerPoint، تطبيق تأثير **All Caps** يجعل النص يظهر بأحرف كبيرة على الشريحة حتى لو تم كتابة النص أصلاً بأحرف صغيرة. عند استرجاع جزء نصي بهذه الطريقة باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. للتعامل مع ذلك، تحقق من [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/)—إذا كان يُشير إلى `All`، قم بتحويل السلسلة المسترجعة إلى أحرف كبيرة بحيث يتطابق الناتج مع ما يراه المستخدمون على الشريحة.

لنفترض أن لدينا صندوق نص التالي على الشريحة الأولى من ملف sample2.pptx.

![The All Caps effect](all_caps_effect.png)

يُظهر المثال البرمجي أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:
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


الناتج:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **الأسئلة الشائعة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، تحتاج إلى استخدام واجهة [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). يمكنك التنقل عبر جميع الخلايا في الجدول وتغيير النص في كل خلية عن طريق الوصول إلى خصائص `TextFrame` و `ParagraphFormat` داخل كل خلية.

**كيف يمكن تطبيق لون متدرج على النص في شريحة PowerPoint؟**

لتطبيق لون متدرج على النص، استخدم طريقة `getFillFormat` في [BasePortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/). عيّن `FilFormat` إلى `Gradient`، حيث يمكنك تحديد ألوان البداية والنهاية للمتدرج، بالإضافة إلى خصائص أخرى مثل الاتجاه والشفافية لإنشاء تأثير متدرج على النص.