---
title: تنسيق النص
type: docs
weight: 50
url: /java/text-formatting/
keywords:
- تسليط الضوء على النص
- تعبير عادي
- محاذاة فقرات النص
- شفافية النص
- خصائص خط الفقرة
- عائلة الخط
- دوران النص
- دوران بزاوية مخصصة
- إطار النص
- تباعد الأسطر
- خاصية ضبط تلقائي
- تثبيت إطار النص
- جدول نصي
- نمط النص الافتراضي
- Java
- Aspose.Slides لـ Java
description: "إدارة وتحرير خصائص النص وإطار النص في Java"
---

## **تسليط الضوء على النص**
تم إضافة طريقة [highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) و فئة [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

يتيح تسليط الضوء على جزء من النص باستخدام لون خلفية باستخدام نموذج نص، مماثل لأداة لون تسليط الضوء على النص في PowerPoint 2019.

يوضح مقتطف الكود أدناه كيفية استخدام هذه الميزة:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // تسليط الضوء على جميع كلمات 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// تسليط الضوء على جميعOccurrences منفصلة 'the'
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

يوفر Aspose خدمة تحرير PowerPoint بسيطة [مجانية عبر الإنترنت](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **تسليط الضوء على النص باستخدام تعبير عادي**

تم إضافة طريقة [highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) و فئة [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

يتيح تسليط الضوء على جزء من النص باستخدام لون خلفية باستخدام regex، مماثل لأداة لون تسليط الضوء على النص في PowerPoint 2019.

يوضح مقتطف الكود أدناه كيفية استخدام هذه الميزة:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // تسليط الضوء على جميع الكلمات بأكثر من 10 رموز
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين لون خلفية النص**

تتيح لك Aspose.Slides تحديد اللون المفضل لديك لخلفية النص.

يوضح هذا الرمز في Java كيفية تعيين لون الخلفية لنص كامل:

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

هذا الرمز في Java يوضح لك كيفية تعيين لون الخلفية لجزء فقط من نص:

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

يعد تنسيق النص أحد العناصر الرئيسية عند إنشاء أي نوع من الوثائق أو العروض التقديمية. نعلم أن Aspose.Slides لـ Java يدعم إضافة النص إلى الشرائح ولكن في هذا الموضوع، سنرى كيف يمكننا التحكم في محاذاة فقرات النص في الشريحة. يرجى اتباع الخطوات أدناه لمحاذاة فقرات النص باستخدام Aspose.Slides لـ Java:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع شريحة باستخدام فهرسها.
3. الوصول إلى الأشكال النائبة الموجودة في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
4. احصل على الفقرة (التي تحتاج إلى محاذاتها) من [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#getTextFrame--) المقدمة بواسطة [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين أو اليسار أو المنتصف أو التبرير.
6. اكتب العرض التقديمي المعدل كملف PPTX.

يتم إعطاء تنفيذ الخطوات أعلاه أدناه.

```java
// إنشاء كائن Presentation يتمثل في ملف PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // الوصول إلى الشكلين النائبيين الأول والثاني في الشريحة وتحويلهما إلى AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // تغيير النص في كلا الشكلين النائبيين
    tf1.setText("محاذاة في المنتصف بواسطة Aspose");
    tf2.setText("محاذاة في المنتصف بواسطة Aspose");

    // الحصول على الفقرة الأولى من الشكلين النائبيين
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
توضح هذه المقالة كيفية تعيين خاصية الشفافية لأي شكل نص باستخدام Aspose.Slides لـ Java. لتعيين الشفافية للنص. يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع لشريحة.
3. تعيين لون الظل.
4. كتابة العرض التقديمي كملف PPTX.

يتم إعطاء تنفيذ الخطوات أعلاه أدناه.

```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - الشفافية هي: " + (shadowColor.getAlpha() / 255f) * 100);

    // تعيين الشفافية إلى صفر بالمئة
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين تباعد الحروف للنص**

تتيح لك Aspose.Slides تعيين المساحة بين الحروف في صندوق نص. بهذه الطريقة، يمكنك ضبط الكثافة البصرية لخط أو كتلة نص عن طريق توسيع أو تقليص المسافة بين الأحرف.

يوضح هذا الرمز في Java كيفية توسيع المسافة لخط واحد من النص وتقليص المسافة لخط آخر:

```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // توسيع
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // تقليص

presentation.save("out.pptx", SaveFormat.Pptx);
```

## **إدارة خصائص خط الفقرات**

تحتوي العروض التقديمية عادةً على نصوص وصور. يمكن تنسيق النص بطرق متنوعة، إما لتسليط الضوء على أقسام وكلمات معينة، أو لتتوافق مع الأنماط الخاصة بالشركات. يساعد تنسيق النص المستخدمين على تغيير شكل ومظهر محتوى العرض التقديمي. تعرض هذه المقالة كيفية استخدام Aspose.Slides لـ Java لتكوين خصائص خط الفقرات من النص على الشرائح. لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides لـ Java:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع شريحة باستخدام فهرسها.
3. الوصول إلى الأشكال النائبة في الشريحة وتحويلها إلى [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
4. احصل على [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) من [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) المقدمة بواسطة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. تبرير الفقرة.
6. الوصول إلى جزء النص في الفقرة.
7. تعريف الخط باستخدام FontData وتعيين الخط وفقًا لذلك.
   1. تعيين الخط كخط عريض.
   2. تعيين الخط كخط مائل.
8. تعيين لون الخط باستخدام [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#getFillFormat--) المقدمة بواسطة كائن [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
9. كتابة العرض التقديمي المعدل كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

يتم إعطاء تنفيذ الخطوات أعلاه أدناه. يأخذ عرضًا تقديميًا بسيطًا ويقوم بتنسيق الخطوط على إحدى الشرائح.

```java
// إنشاء كائن Presentation يتمثل في ملف PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // الوصول إلى شريحة باستخدام موضعها في الشريحة
    ISlide slide = pres.getSlides().get_Item(0);

    // الوصول إلى الشكلين النائبيين الأول والثاني في الشريحة وتحويلهما إلى AutoShape
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

    // كتابة PPTX إلى القرص
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة عائلة الخط للنص**
يستخدم الجزء للاحتفاظ بالنص بأسلوب تنسيق مشابه في فقرة. توضح هذه المقالة كيفية استخدام Aspose.Slides لـ Java لإنشاء صندوق نص ببعض النص ثم تعريف خط معين، والعديد من الخصائص الأخرى لفئة الخط. لإنشاء صندوق نص وتعيين خصائص الخط للنص فيه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع شريحة باستخدام فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
4. إزالة نمط التعبئة المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. الوصول إلى TextFrame الخاص بالشكل التلقائي.
6. إضافة بعض النص إلى TextFrame.
7. الوصول إلى كائن Portion المرتبط بـ [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
8. تعريف الخط الذي سيتم استخدامه لـ [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
9. تعيين خصائص الخط الأخرى مثل العريض والمائل والتسطير واللون والارتفاع باستخدام الخصائص ذات الصلة المقدمة بواسطة كائن Portion.
10. كتابة العرض التقديمي المعدل كملف PPTX.

يتم إعطاء تنفيذ الخطوات أعلاه كما يلي.

```java
// إنشاء تقديم
Presentation pres = new Presentation();
try {

    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // إزالة أي نمط تعبئة مرتبط بـ AutoShape
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // الوصول إلى TextFrame المرتبط بـ AutoShape
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("صندوق نص Aspose");

    // الوصول إلى Portion المرتبطة بـ TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // تعيين الخط لـ Portion
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // تعيين خاصية الخط العريض
    port.getPortionFormat().setFontBold(NullableBool.True);

    // تعيين خاصية الخط المائل
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين خاصية التسطير للخط
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // تعيين ارتفاع الخط
    port.getPortionFormat().setFontHeight(25);

    // تعيين لون الخط
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // كتابة PPTX إلى القرص 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **تعيين حجم الخط للنص**

تتيح لك Aspose.Slides اختيار حجم الخط المفضل لديك للنص الحالي في فقرة والنصوص الأخرى التي قد تضاف إلى الفقرة لاحقًا.

يوضح هذا الرمز في Java كيفية تعيين حجم الخط للنصوص الموجودة في فقرة:

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

تتيح لك Aspose.Slides لـ Java للمطورين تدوير النص. يمكن تعيين النص ليظهر كـ [أفقي](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal)، [عمودي](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical)، [عمودي 270](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270)، [WordArt عمودي](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical)، [عمودي شرق آسيوي](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical)، [عمودي منغولي](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) أو [WordArt عمودي من اليمين إلى اليسار](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). لتدوير نص أي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [تدوير النص](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. حفظ الملف إلى القرص.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من نوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // إنشاء كائن فقرات لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("أسرع ثعلب بني يقفز فوق الكلب الكسول. أسرع ثعلب بني يقفز فوق الكلب الكسول.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // حفظ العرض التقديمي
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين زاوية دوران مخصصة لـ TextFrame**
يدعم Aspose.Slides لـ Java الآن تعيين زاوية دوران مخصصة لإطار النص. في هذا الموضوع، سنرى مع مثال كيفية تعيين خاصية RotationAngle في Aspose.Slides. تمت إضافة الطريقتين [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) و[getRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) إلى واجهتي [IChartTextBlockFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) و[ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) تسمحان بتعيين زاوية دوران مخصصة لإطار النص. لتعيين زاوية الدوران، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إضافة مخطط على الشريحة.
3. [تعيين خاصية RotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. كتابة العرض التقديمي كملف PPTX.

في المثال المذكور أدناه، نقوم بتعيين خاصية RotationAngle.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // إنشاء كائن فقرات لإطار النص
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
يوفر Aspose.Slides الخصائص تحت [`ParagraphFormat`](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat)—`SpaceAfter`، `SpaceBefore` و`SpaceWithin`—التي تسمح لك بإدارة تباعد الأسطر لفقرة. تُستخدم الخصائص الثلاث بهذا الشكل:

* لتحديد تباعد الأسطر لفقرة كنسبة مئوية، استخدم قيمة إيجابية. 
* لتحديد تباعد الأسطر لفقرة بالنقاط، استخدم قيمة سلبية.

على سبيل المثال، يمكنك تطبيق 16 نقطة لتباعد الأسطر لفقرة ما من خلال تعيين خاصية `SpaceBefore` إلى -16.

هذه هي الطريقة التي تحدد بها تباعد الأسطر لفقرة معينة:

1. تحميل عرض تقديمي يحتوي على AutoShape مع بعض النص بداخله.
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى TextFrame.
4. الوصول إلى الفقرة.
5. تعيين خصائص الفقرة.
6. حفظ العرض التقديمي.

يوضح هذا الرمز في Java كيفية تحديد تباعد الأسطر لفقرة:

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
في هذا الموضوع، سنستكشف الخصائص المختلفة لتنسيق إطار النص. تغطي هذه المقالة كيفية تعيين خاصية AutofitType لإطار النص، وتثبيت النص وتدوير النص في العرض التقديمي. تتيح Aspose.Slides لـ Java للمطورين تعيين خاصية AutofitType لأي إطار نص. يمكن تعيين AutofitType إلى [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) أو [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape). إذا تم تعيينه على [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) فسيبقى الشكل كما هو بينما سيتم ضبط النص دون تغيير الشكل نفسه، بينما إذا تم تعيين AutofitType إلى [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape)، فسيتم تعديل الشكل بحيث يتم احتواء النص المطلوب فقط فيه. لتعيين خاصية AutofitType لإطار نص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [تعيين AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) لإطار النص.
6. حفظ الملف على القرص.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // إنشاء كائن فقرات لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("أسرع ثعلب بني يقفز فوق الكلب الكسول. أسرع ثعلب بني يقفز فوق الكلب الكسول.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // حفظ العرض التقديمي
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين تثبيت إطار النص**
تتيح Aspose.Slides لـ Java للمطورين تثبيت أي إطار نص. تحدد TextAnchorType مكان وضع النص داخل الشكل. يمكن تعيين نوع التثبيت إلى [أعلى](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top)، [مركز](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center)، [أسفل](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom)، [مبرر](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) أو [موزع](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed). لتعيين تثبيت أي إطار نص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [تعيين TextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) لإطار النص.
6. حفظ الملف على القرص.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من نوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // إنشاء كائن فقرات لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("أسرع ثعلب بني يقفز فوق الكلب الكسول. أسرع ثعلب بني يقفز فوق الكلب الكسول.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // حفظ العرض التقديمي
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الفواصل والتبويبات الفعالة في العرض التقديمي**
تُعطى جميع التبويبات النصية بالبكسل.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**الشكل: 2 تبويبات صريحة و2 تبويبات افتراضية**|
- خاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- تتضمن مجموعة EffectiveTabs جميع التبويبات (من مجموعة Tabs والتبويبات الافتراضية).
- خاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- خاصية EffectiveTabs.DefaultTabSize (294) تُظهر المسافة بين التبويبات الافتراضية (3 و4 في مثالنا).
- EffectiveTabs.GetTabByIndex(index) مع index = 0 ستعيد أول تبويب صريح (الموقع = 731)، index = 1 - التبويب الثاني (الموقع = 1241). إذا حاولت الحصول على التبويب التالي باستخدام index = 2 ستعيد أول تبويب افتراضي (الموقع = 1470) وهكذا.
- EffectiveTabs.GetTabAfterPosition(pos) تُستخدم للحصول على التبويب التالي بعد نص معين. على سبيل المثال، لديك نص: "مرحبًا بالعالم!". لرسم مثل هذا النص، يجب أن تعرف من أين تبدأ برسم "العالم!". أولاً، يجب عليك حساب طول "مرحبًا" بالبكسل واستدعاء GetTabAfterPosition مع هذه القيمة. ستحصل على موضع التبويب التالي لرسم "العالم!".

## **تعيين نمط النص الافتراضي**

إذا كنت بحاجة إلى تطبيق نفس تنسيق النص الافتراضي على جميع عناصر النص في عرض تقديمي مرة واحدة، فيمكنك استخدام طريقة `getDefaultTextStyle` من واجهة [IPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/) وتعيين التنسيق المفضل. يوضح مثال الكود أدناه كيفية تعيين الخط العريض الافتراضي (14 نقطة) للنص على جميع الشرائح في عرض تقديمي جديد.

```java
Presentation presentation = new Presentation();
try {
    // الحصول على تنسيق الفقرة الأعلى مستوى.
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