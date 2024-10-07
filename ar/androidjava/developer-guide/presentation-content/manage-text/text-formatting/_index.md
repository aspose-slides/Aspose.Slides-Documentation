---
title: تنسيق النص
type: docs
weight: 50
url: /androidjava/text-formatting/
keywords:
- تسليط الضوء على النص
- تعبير قياسي
- محاذاة فقرات النص
- شفافية النص
- خصائص خط الفقرة
- عائلة الخط
- دوران النص
- دوران الزاوية المخصصة
- إطار النص
- تباعد الأسطر
- خاصية الملاءمة التلقائية
- مرساة إطار النص
- تبويب النص
- النمط الافتراضي للنص
- جافا
- Aspose.Slides لـ Android عبر جافا
description: "إدارة ومعالجة النص وخصائص إطار النص في جافا"
---

## **تسليط الضوء على النص**
تمت إضافة الدالة [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) والفئة [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

تسمح بتسليط الضوء على جزء من النص بلون خلفية باستخدام عينة نص، مشابهة لأداة لون تمييز النص في PowerPoint 2019.

يظهر الكود أدناه كيفية استخدام هذه الميزة:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // تسليط الضوء على جميع الكلمات "المهمة"
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// تسليط الضوء على جميع حالات "the" المنفصلة
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

تقدم Aspose خدمة تحرير PowerPoint عبر الإنترنت [مجانية](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **تسليط الضوء على النص باستخدام تعبير قياسي**

تمت إضافة الدالة [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) والفئة [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

تسمح بتسليط الضوء على جزء من النص بلون خلفية باستخدام تعبير منتظم، مشابهة لأداة لون تمييز النص في PowerPoint 2019.

يظهر الكود أدناه كيفية استخدام هذه الميزة:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // تسليط الضوء على جميع الكلمات التي تحتوي على 10 رموز أو أكثر
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين لون خلفية النص**

تسمح Aspose.Slides لك بتحديد اللون المفضل لك لخلفية النص.

يوضح لك هذا الرمز بلغة جافا كيفية تعيين لون الخلفية لنص كامل:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("أسود");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" أحمر ");

    Portion portion3 = new Portion("أسود");
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

يوضح لك هذا الرمز بلغة جافا كيفية تعيين لون الخلفية لجزء فقط من النص:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("أسود");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" أحمر ");

    Portion portion3 = new Portion("أسود");
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
            .filter(p -> p.getText().contains("أحمر"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **محاذاة فقرات النص**

يعتبر تنسيق النص أحد العناصر الأساسية أثناء إنشاء أي نوع من المستندات أو العروض التقديمية. نحن نعلم أن Aspose.Slides لـ Android عبر جافا يدعم إضافة نص إلى الشرائح ولكن في هذا الموضوع، سنرى كيف يمكننا السيطرة على محاذاة فقرات النص في الشريحة. يرجى اتباع الخطوات أدناه لمحاذاة فقرات النص باستخدام Aspose.Slides لـ Android عبر جافا:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة باستخدام فهرسها.
3. الوصول إلى الأشكال النمطية الموجودة في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
4. الحصول على الفقرة (التي تحتاج إلى المحاذاة) من [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) المعروض بواسطة [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين، اليسار، الوسط والمبرر.
6. كتابة العرض التقديمي المعدل كملف PPTX.

تطبيق الخطوات السابقة موضح أدناه.

```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // الوصول إلى العنصر النمطي الأول والثاني في الشريحة وتحويلها إلى AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // تغيير النص في كلا العنصرين النمطيين
    tf1.setText("محاذاة المركز بواسطة Aspose");
    tf2.setText("محاذاة المركز بواسطة Aspose");

    // الحصول على الفقرة الأولى من العنصرين النمطيين
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // محاذاة فقرة النص إلى المنتصف
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // كتابة العرض التقديمي كملف PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين الشفافية للنص**
توضح هذه المقالة كيفية تعيين خاصية الشفافية لأي شكل نص باستخدام Aspose.Slides لـ Android عبر جافا. لتعيين الشفافية للنص. يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع للشريحة.
3. تعيين لون الظل.
4. كتابة العرض التقديمي كملف PPTX.

تطبيق الخطوات السابقة موضح أدناه.

```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - الشفافية هي: "+ (shadowColor.getAlpha() / 255f) * 100);

    // تعيين الشفافية إلى صفر في المئة
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين تباعد المحارف للنص**

تسمح Aspose.Slides لك بتعيين المسافة بين الحروف في مربع النص. بهذه الطريقة، يمكنك ضبط الكثافة البصرية لخط أو كتلة نصية عن طريق توسيع أو تقليص المسافة بين المحارف.

يوضح لك هذا الرمز بلغة جافا كيفية توسيع المسافة لخط واحد من النص وتكثيف المسافة لخط آخر:

```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // توسيع
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // تكثيف

presentation.save("out.pptx", SaveFormat.Pptx);
```

## **إدارة خصائص خط الفقرات**

تحتوي العروض التقديمية عادةً على نصوص وصور. يمكن تنسيق النص بطرق متنوعة، سواء لتسليط الضوء على أقسام وكلمات معينة، أو للتوافق مع الأنماط المؤسسية. يساعد تنسيق النص المستخدمين على تغيير مظهر ومضمون محتوى العرض التقديمي. توضح هذه المقالة كيفية استخدام Aspose.Slides لـ Android عبر جافا لتكوين خصائص الخط للفقرات النصية على الشرائح. لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides لـ Android عبر جافا:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الحصول على مرجع لشريحة باستخدام فهرسها.
1. الوصول إلى الأشكال النمطية في الشريحة وتحويلها إلى [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
1. الحصول على [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) من [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) المعروض بواسطة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
1. تبرير الفقرة.
1. الوصول إلى جزء نص الفقرة.
1. تعريف الخط باستخدام FontData وتعيين الخط وفقًا لذلك في جزء النص.
   1. تعيين الخط ليكون عريضًا.
   1. تعيين الخط ليكون مائلًا.
1. تعيين لون الخط باستخدام [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) المعروض بواسطة كائن [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion).
1. كتابة العرض التقديمي المعدل كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

تطبيق الخطوات السابقة موضح أدناه. يأخذ تقديمًا غير مزخرف وينسق الخطوط في إحدى الشرائح.

```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // الوصول إلى شريحة باستخدام موضع شريحتها
    ISlide slide = pres.getSlides().get_Item(0);

    // الوصول إلى العنصر النمطي الأول والثاني في الشريحة وتحويلها إلى AutoShape
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

    // تعيين الخط ليكون عريضًا
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // تعيين الخط ليكون مائلًا
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين لون الخط
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // كتابة الPPTX إلى القرص
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة عائلة الخط للنص**
يستخدم الجزء للإمساك بالنص بأسلوب تنسيق مماثل في فقرة. توضح هذه المقالة كيفية استخدام Aspose.Slides لـ Android عبر جافا لإنشاء مربع نص مع بعض النصوص ثم تعريف خط معين، وخصائص أخرى متعلقة بعائلة الخط. لإنشاء مربع نص وتعيين خصائص الخط للنص الموجود فيه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
4. إزالة نمط التعبئة المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. الوصول إلى TextFrame الخاص بـ AutoShape.
6. إضافة بعض النصوص إلى TextFrame.
7. الوصول إلى كائن Portion المرتبط بـ [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
8. تعريف الخط الذي سيتم استخدامه لـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion).
9. تعيين خصائص الخط الأخرى مثل العريض، المائل، الخط تحت، اللون والارتفاع باستخدام الخصائص ذات الصلة كما تظهرها  كائن Portion.
10. كتابة العرض التقديمي المعدل كملف PPTX.

تطبيق الخطوات السابقة موضح أدناه.

```java
// إنشاء عرض تقديمي
Presentation pres = new Presentation();
try {

    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة الشكل النمطي من نوع Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // إزالة أي نمط تعبئة مرتبط بالشكل النمطي
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // الوصول إلى TextFrame المرتبطة بالشكل النمطي
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("مربع نص Aspose");

    // الوصول إلى جزء المرتبط بـ TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // تعيين الخط للجزء
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // تعيين خاصية العريض للخط
    port.getPortionFormat().setFontBold(NullableBool.True);

    // تعيين خاصية المائل للخط
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين خاصية الخط تحت للخط
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // تعيين ارتفاع الخط
    port.getPortionFormat().setFontHeight(25);

    // تعيين لون الخط
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // كتابة الPPTX إلى القرص 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **تعيين حجم الخط للنص**

تسمح Aspose.Slides لك باختيار حجم الخط المفضل لديك للنصوص الموجودة في فقرة والنصوص الأخرى التي قد تتم إضافتها لاحقًا إلى الفقرة.

يوضح لك هذا الرمز بلغة جافا كيفية تعيين حجم الخط للنصوص الموجودة في فقرة:

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

        // تعيين حجم الخط إلى 20 نقطة للأجزاء النصية الحالية في الفقرة. 
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

تسمح Aspose.Slides لـ Android عبر جافا للمطورين بتدوير النص. يمكن تعيين النص ليظهر كـ [أفقي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal)، [عمودي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical)، [عمودي270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270)، [عموديWordArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical)، [عموديEastAsian](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical)، [عموديMongolian](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) أو [عموديWordArtمن اليمين إلى اليسار](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). لتدوير نص أي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [تدوير النص](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. حفظ الملف على القرص.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة شكل AutoShape من النوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // إضافة TextFrame إلى المضلع
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // إنشاء كائن الفقرة لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("خروف بني سريع يقفز فوق كلب كسول. خروف بني سريع يقفز فوق كلب كسول.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // حفظ العرض التقديمي
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين زاوية دوران مخصصة لإطار النص**
تدعم Aspose.Slides لـ Android عبر جافا الآن تعيين زاوية دوران مخصصة لإطار النص. في هذا الموضوع، سنرى من خلال مثال كيفية تعيين خاصية RotationAngle في Aspose.Slides. تمت إضافة الطريقتين [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) و[getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) إلى واجهتي [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) و[ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) ، مما يسمح بتعيين زاوية دوران مخصصة لإطار النص. لتعيين زاوية الدوران، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. إضافة مخطط على الشريحة.
3. [تعيين خاصية زاوية الدوران](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. كتابة العرض التقديمي كملف PPTX.

في المثال أدناه، نقوم بتعيين خاصية زاوية الدوران.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة شكل AutoShape من النوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // إضافة TextFrame إلى المضلع
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // إنشاء كائن الفقرة لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("مثال على دوران النص.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // حفظ العرض التقديمي
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تباعد الأسطر للفقرة**
تقدم Aspose.Slides خصائص تحت [`ParagraphFormat`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat) — `SpaceAfter`، `SpaceBefore` و`SpaceWithin` — التي تسمح لك بإدارة تباعد الأسطر لفقرة. يتم استخدام الخصائص الثلاث على النحو التالي:

* لتحديد تباعد الأسطر لفقرة كنسبة مئوية، استخدم قيمة موجبة. 
* لتحديد تباعد الأسطر لفقرة بالنقاط، استخدم قيمة سالبة.

على سبيل المثال، يمكنك تطبيق تباعد أسطر 16 نقطة لفقرة من خلال تعيين خاصية `SpaceBefore` إلى -16.

هذا هو كيفية تحديد تباعد الأسطر لفقرة معينة:

1. تحميل عرض تقديمي يحتوي على AutoShape به نص.
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى TextFrame.
4. الوصول إلى الفقرة.
5. تعيين خصائص الفقرة.
6. حفظ العرض التقديمي.

يوضح لك هذا الرمز بلغة جافا كيفية تحديد تباعد الأسطر لفقرة:

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // الحصول على مرجع الشريحة من خلال فهرسها
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
في هذا الموضوع، سنستكشف الخصائص المختلفة لتنسيق إطار النص. تغطي هذه المقالة كيفية تعيين خاصية AutofitType لإطار النص، ومرساة النص وتدوير النص في العرض التقديمي. تسمح Aspose.Slides لـ Android عبر جافا للمطورين بتعيين خاصية AutofitType لأي إطار نص. يمكن تعيين AutofitType إلى [عادي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) أو [شكل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape). إذا تم تعيينها إلى [عادي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) فستظل الشكل كما هو بينما سيتم ضبط النص دون التسبب في تغيير الشكل نفسه بينما إذا تم تعيين AutofitType إلى [شكل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape)، فسيتم تعديل الشكل بحيث يحتوي فقط على النص المطلوب. لتعيين خاصية AutofitType لإطار نص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [تعيين AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) لإطار النص.
6. حفظ الملف على القرص.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة شكل AutoShape من النوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // إضافة TextFrame إلى المضلع
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // إنشاء كائن الفقرة لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("خروف بني سريع يقفز فوق كلب كسول. خروف بني سريع يقفز فوق كلب كسول.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // حفظ العرض التقديمي
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين مرساة إطار النص**
تسمح Aspose.Slides لـ Android عبر جافا للمطورين بتعيين مرساة أي إطار نص. تحدد TextAnchorType المكان الذي يتم فيه وضع هذا النص في الشكل. يمكن تعيين نوع المرساة إلى [أعلى](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top)، [وسط](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center)، [أسفل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom)، [مبرر](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) أو [موزع](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed). لتعيين مرساة أي إطار نص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [تعيين TextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) لإطار النص.
6. حفظ الملف على القرص.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة شكل AutoShape من النوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // إضافة TextFrame إلى المضلع
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // إنشاء كائن الفقرة لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("خروف بني سريع يقفز فوق كلب كسول. خروف بني سريع يقفز فوق كلب كسول.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // حفظ العرض التقديمي
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **التبويبات و EffectiveTabs في العرض التقديمي**
جميع التبويبات النصية تُعطى بالبكسل.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**الشكل: 2 تبويبات صريحة و 2 تبويبات افتراضية**|
- خاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- تتضمن مجموعة EffectiveTabs جميع التبويبات (من مجموعة Tabs والتبويبات الافتراضية).
- خاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- خاصية EffectiveTabs.DefaultTabSize (294) تظهر المسافة بين التبويبات الافتراضية (3 و4 في مثالنا).
- EffectiveTabs.GetTabByIndex(index) مع index = 0 ستعيد أول تبويب صريح (الموضع = 731)، index = 1 - التبويب الثاني (الموضع = 1241). إذا حاولت الحصول على التبويب التالي مع index = 2 ستعيد أول تبويب افتراضي (الموضع = 1470) وهكذا.
- يستخدم EffectiveTabs.GetTabAfterPosition(pos) للحصول على التبويب التالي بعد بعض النص. على سبيل المثال لديك نص: "مرحبًا بالعالم!". لرسم مثل هذا النص يجب أن تعرف من أين تبدأ برسم "العالم!". في البداية، يجب أن تحسب طول "مرحبًا" بالبكسلات وتستدعي GetTabAfterPosition مع هذه القيمة. ستحصل على الموضع التالي للرسم "العالم!".

## **تعيين النمط الافتراضي للنص**

إذا كنت بحاجة إلى تطبيق نفس تنسيق النص الافتراضي على جميع عناصر النص في العرض التقديمي دفعة واحدة، يمكنك استخدام طريقة `getDefaultTextStyle` من واجهة [IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) وتعيين التنسيق المفضل. يوضح مثال الرمز أدناه كيفية تعيين خط عريض افتراضي (14 نقطة) للنص في جميع الشرائح في عرض تقديمي جديد.

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