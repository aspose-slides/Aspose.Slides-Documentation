---
title: تنسيق نص PowerPoint على Android
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/androidjava/text-formatting/
keywords:
- تمييز النص
- تعبير عادي
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
- خاصية الضبط التلقائي
- تثبيت إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "قم بتنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Android عبر Java. خصّص الخطوط والألوان والمحاذاة والمزيد."
---

## **تمييز النص**
تمت إضافة الطريقة [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) وفئة [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

تتيح هذه الطريقة تمييز جزء من النص بلون خلفية باستخدام عينة النص، مشابهة لأداة تلوين النص الخلفية في PowerPoint 2019.

تظهر المقتطف البرمجي أدناه كيفية استخدام هذه الميزة:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // تمييز جميع الكلمات 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// تمييز جميع التكرارات المنفصلة لكلمة 'the'
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
توفر Aspose [خدمة تحرير PowerPoint عبر الإنترنت مجانية وبسيطة](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **تمييز النص باستخدام تعبير عادي**
تمت إضافة الطريقة [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) وفئة [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

تتيح هذه الطريقة تمييز جزء من النص بلون خلفية باستخدام تعبير عادي، مشابهة لأداة تلوين النص الخلفية في PowerPoint 2019.

تظهر المقتطف البرمجي أدناه كيفية استخدام هذه الميزة:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // تمييز جميع الكلمات التي تتكون من 10 رموز أو أكثر
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين لون خلفية النص**
تسمح Aspose.Slides بتحديد اللون المفضل لخلفية النص.

يظهر الكود التالي كيفية تعيين لون الخلفية لنص كامل:
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


يظهر الكود التالي كيفية تعيين لون الخلفية لجزء من النص:
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
تنسيق النص هو أحد العناصر الأساسية أثناء إنشاء المستندات أو العروض التقديمية. نعلم أن Aspose.Slides for Android via Java يدعم إضافة النص إلى الشرائح، وفي هذا الموضوع سنستعرض كيفية التحكم في محاذاة فقرات النص داخل الشريحة. يرجى اتباع الخطوات التالية لمحاذاة فقرات النص باستخدام Aspose.Slides for Android via Java:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
3. الوصول إلى الأشكال النائبة الموجودة في الشريحة وتحويلها إلى كائن من نوع [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
4. الحصول على الفقرة (التي تحتاج إلى محاذاة) من [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) المعروضة بواسطة [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين أو اليسار أو الوسط أو التبرير.
6. كتابة العرض المعدل كملف PPTX.

الشفرة التي تُطبق الخطوات المذكورة أدناه:
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويلهما إلى AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // تغيير النص في العنصرين النائبين
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // الحصول على الفقرة الأولى من العناصر النائبة
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // محاذاة فقرة النص إلى المركز
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    //كتابة العرض كملف PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين الشفافية للنص**
يوضح هذا المقال كيفية تعيين خاصية الشفافية لأي شكل نصي باستخدام Aspose.Slides for Android via Java. لتعيين الشفافية للنص، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة.
3. تعيين لون الظلال.
4. كتابة العرض كملف PPTX.

الشفرة التي تُطبق الخطوات المذكورة أدناه:
```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparency is: "+ (shadowColor.getAlpha() / 255f) * 100);

    // ضبط الشفافية إلى صفر بالمائة
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين تباعد الأحرف للنص**
تسمح Aspose.Slides بتعيين المسافة بين الأحرف داخل مربع النص. بهذه الطريقة يمكنك ضبط كثافة السطر أو كتلة النص بزيادة أو تقليل التباعد بين الأحرف.

الكود التالي يظهر كيفية زيادة التباعد لسطر نص واحد وتقليل التباعد لسطر آخر:
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // توسيع
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // تقليل

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **إدارة خصائص خط الفقرة**
عادةً ما تحتوي العروض التقديمية على نصوص وصور. يمكن تنسيق النص بطرق مختلفة، إما لتسليط الضوء على أقسام أو كلمات معينة، أو للامتثال لأنماط المؤسسة. يساعد تنسيق النص المستخدمين على تنويع مظهر المحتوى. يوضح هذا المقال كيفية استخدام Aspose.Slides for Android via Java لضبط خصائص الخط للفقرات النصية داخل الشرائح. لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides for Android via Java:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة باستخدام الفهرس.
1. الوصول إلى الأشكال النائبة في الشريحة وتحويلها إلى كائن من نوع [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
1. الحصول على [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) من [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) المعروض بواسطة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
1. تبرير الفقرة.
1. الوصول إلى جزء النص داخل الفقرة.
1. تعريف الخط باستخدام FontData وتعيين الخط للجزء وفقًا لذلك.
   1. ضبط الخط إلى غامق.
   1. ضبط الخط إلى مائل.
1. تعيين لون الخط باستخدام [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) المعروض بواسطة كائن [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion).
1. كتابة العرض المعدل إلى ملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

الشفرة التي تُطبق الخطوات المذكورة أدناه. تقوم بأخذ عرض غير معدل وتنسيق الخطوط في إحدى الشرائح:
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

    // تعريف خطوط جديدة
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // تعيين الخطوط الجديدة إلى الجزء
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
يُستخدم الجزء (Portion) للاحتفاظ بنص ذو تنسيق موحد داخل الفقرة. يوضح هذا المقال كيفية إنشاء مربع نص يحتوي على بعض النص وتحديد خط معين، بالإضافة إلى خصائص أخرى لعائلة الخط. لإنشاء مربع نص وتعيين خصائص الخط للنص داخلها:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة باستخدام الفهرس.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من النوع [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
4. إزالة نمط الملء المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. الوصول إلى TextFrame الخاص بـ AutoShape.
6. إضافة بعض النص إلى TextFrame.
7. الوصول إلى كائن Portion المرتبط بـ [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
8. تعريف الخط المستخدم للـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion).
9. تعيين خصائص الخط الأخرى مثل الغامق والمائل وتسطير اللون والارتفاع باستخدام الخصائص المناسبة للـ Portion.
10. كتابة العرض المعدل كملف PPTX.

الشفرة التي تُطبق الخطوات المذكورة أدناه:
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

    // تعيين خاصية الغامق للخط
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
تسمح Aspose.Slides باختيار حجم الخط المفضل للنص الموجود في الفقرة وأي نص قد يُضاف لاحقًا إلى الفقرة.

الكود التالي يوضح كيفية تعيين حجم الخط للنصوص الموجودة في فقرة:
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
يسمح Aspose.Slides for Android via Java للمطورين بتدوير النص. يمكن ضبط النص ليظهر كـ [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal)، [Vertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical)، [Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270)، [WordArtVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) أو [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). لتدوير نص أي TextFrame، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Rotate the text](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. حفظ الملف إلى القرص.

```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من النوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // إضافة TextFrame إلى الشكل المستطيل
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


## **تعيين زاوية دوران مخصصة لـ TextFrame**
يدعم Aspose.Slides for Android via Java الآن تعيين زاوية دوران مخصصة لإطار النص. في هذا الموضوع سنستعرض مثالًا يوضح كيفية تعيين خاصية RotationAngle في Aspose.Slides. تمت إضافة الطريقتين [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) و [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) إلى واجهات [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) و [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat)، مما يسمح بتعيين زاوية دوران مخصصة لإطار النص. لتعيين RotationAngle، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. إضافة مخطط إلى الشريحة.
3. [Set RotationAngle property](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. كتابة العرض كملف PPTX.

في المثال أدناه، تم تعيين خاصية RotationAngle.
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


## **مسافة السطر في الفقرة**
توفر Aspose.Slides خصائص ضمن [`ParagraphFormat`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat) — `SpaceAfter` و `SpaceBefore` و `SpaceWithin` — تتيح لك إدارة مسافة السطر للفقرة. تُستخدم الخصائص الثلاث كالتالي:

* لتحديد مسافة السطر بالنسبة المئوية، استخدم قيمة موجبة.
* لتحديد مسافة السطر بالنقاط، استخدم قيمة سالبة.

على سبيل المثال، يمكنك تطبيق مسافة سطر 16pt للفقرة عن طريق ضبط خاصية `SpaceBefore` إلى -16.

إليك طريقة تحديد مسافة السطر لفقرة معينة:

1. تحميل عرض يحتوي على AutoShape به بعض النص.
2. الحصول على مرجع الشريحة عبر فهرستها.
3. الوصول إلى TextFrame.
4. الوصول إلى Paragraph.
5. ضبط خصائص الفقرة.
6. حفظ العرض.

الكود التالي يوضح كيفية تحديد مسافة السطر لفقرة:
```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // الحصول على مرجع الشريحة بواسطة فهرستها
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
في هذا الموضوع نستعرض خصائص تنسيق إطار النص المختلفة. يوضح المقال كيفية تعيين خاصية AutofitType لإطار النص، وتثبيت النص وتدويره في العرض. يسمح Aspose.Slides for Android via Java للمطورين بتعيين خاصية AutofitType لأي إطار نص. يمكن أن تكون AutofitType إما [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) أو [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape). إذا تم تعيينها إلى [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) فإن الشكل يبقى كما هو بينما يُضبط النص دون تغيير الشكل؛ أما إذا تم تعيينها إلى [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape) فإن الشكل يتعدل ليحتوي فقط على النص المطلوب. لتعيين خاصية AutofitType لإطار نص، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)class.
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Set the AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) لإطار النص.
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


## **تعيين تثبيت (Anchor) لإطار النص**
يسمح Aspose.Slides for Android via Java للمطورين بتثبيت أي TextFrame. يحدد TextAnchorType موقع النص داخل الشكل. يمكن تعيين AnchorType إلى [Top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top)، [Center](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center)، [Bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom)، [Justified](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) أو [Distributed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed). لتعيين تثبيت أي TextFrame، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Set TextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) لإطار النص.
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


## **Tabs و EffectiveTabs في العرض**
جميع علامات التبويب للنص تُعطى بالبيكسل.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|

- الخاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- مجموعة EffectiveTabs تشمل جميع العلامات (من مجموعة Tabs والعلامات الافتراضية).
- الخاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- الخاصية EffectiveTabs.DefaultTabSize (294) تُظهر المسافة بين العلامات الافتراضية (3 و 4 في مثالنا).
- EffectiveTabs.GetTabByIndex(index) مع index = 0 تُعيد أول علامة صريحة (Position = 731)، index = 1 تُعيد العلامة الثانية (Position = 1241). إذا طلبت العلامة التالية مع index = 2 فستُعيد أول علامة افتراضية (Position = 1470) وهكذا.
- EffectiveTabs.GetTabAfterPosition(pos) تُستخدم للحصول على العلامة التالية بعد بعض النص. على سبيل المثال لديك النص: "Hello World!". لتصميم هذا النص يجب معرفة موقع بدء رسم "world!". أولاً احسب طول "Hello" بالبيكسل ثم استدعِ GetTabAfterPosition بهذه القيمة. ستحصل على موقع العلامة التالية لرسم "world!".

## **تعيين نمط النص الافتراضي**
إذا أردت تطبيق تنسيق نص افتراضي موحد على جميع عناصر النص في العرض دفعة واحدة، يمكنك استخدام طريقة `getDefaultTextStyle` من واجهة [IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) وتعيين التنسيق المفضل. المثال أدناه يُظهر كيفية تعيين الخط العريض الافتراضي (14 نقطة) للنص على جميع الشرائح في عرض جديد.
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


## **استخراج النص مع تأثير الأحرف الكبيرة كلها**
في PowerPoint، يُظهر تطبيق تأثير الخط **All Caps** النص بأحرف كبيرة على الشريحة حتى لو كُتب أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما أُدخل بالضبط. للتعامل مع ذلك، تحقق من [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/)—إذا أظهر `All`، حوّل السلسلة المسترجعة إلى أحرف كبيرة حتى يتطابق الناتج مع ما يراه المستخدمون على الشريحة.

لنفترض أن لدينا صندوق نص في الشريحة الأولى من الملف sample2.pptx.

![The All Caps effect](all_caps_effect.png)

المثال أدناه يُظهر كيفية استخراج النص مع تطبيق تأثير **All Caps**:
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


المخرجات:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**How to modify text in a table on a slide?**

لتعديل النص في جدول على شريحة، استخدم واجهة [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). يمكنك التجول عبر جميع الخلايا في الجدول وتغيير النص في كل خلية عبر الوصول إلى خصائص `TextFrame` و `ParagraphFormat` الخاصة بها.

**How to apply gradient color to text in a PowerPoint slide?**

لتطبيق لون تدرج على النص، استخدم طريقة `getFillFormat` في [BasePortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/). عيّن `FilFormat` إلى `Gradient` حيث يمكنك تحديد ألوان البداية والنهاية للتدرج، إضافة إلى خصائص أخرى مثل الاتجاه والشفافية لإنتاج تأثير التدرج على النص.