---
title: تصميم العرض
type: docs
weight: 10
url: /androidjava/presentation-theme/
keywords: "تصميم, تصميم PowerPoint, عرض PowerPoint, جافا, Aspose.Slides لجافا عبر Android"
description: "تصميم عرض PowerPoint في جافا"
---

يحدد تصميم العرض خصائص عناصر التصميم. عند اختيار تصميم عرض، فإنك تختار في الأساس مجموعة معينة من العناصر البصرية وخصائصها.

في PowerPoint، يتكون التصميم من الألوان، [الخطوط](/slides/androidjava/powerpoint-fonts/)، [أنماط الخلفية](/slides/androidjava/presentation-background/)، والتأثيرات.

![مكونات التصميم](theme-constituents.png)

## **تغيير لون التصميم**

يستخدم تصميم PowerPoint مجموعة معينة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها من خلال تطبيق ألوان جديدة للتصميم. لتمكينك من اختيار لون تصميم جديد، يوفر Aspose.Slides قيمًا تحت التعداد [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SchemeColor).

يوضح هذا الكود بلغة Java كيفية تغيير لون التمييز لتصميم:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

يمكنك تحديد القيمة الفعلية للون الناتج بهذه الطريقة:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

لإظهار عملية تغيير اللون بشكل أكبر، نقوم بإنشاء عنصر آخر ونعين له لون التمييز (من العملية الأولية). ثم نغير اللون في التصميم:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

يتم تطبيق اللون الجديد تلقائيًا على كلا العنصرين.

### **تعيين لون التصميم من لوحة إضافية**

عند تطبيق تحويلات السطوع على لون التصميم الرئيسي(1)، يتم تشكيل ألوان من اللوحة الإضافية(2). يمكنك بعد ذلك تعيين تلك الألوان للتصميم والحصول عليها.

![ألوان لوحة إضافية](additional-palette-colors.png)

**1** - ألوان التصميم الرئيسية

**2** - ألوان من اللوحة الإضافية.

يوضح هذا الكود بلغة Java عملية يتم فيها الحصول على ألوان من اللوحة الإضافية من لون التصميم الرئيسي ثم استخدامها في الأشكال:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // تمييز 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // تمييز 4، أفتح 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // تمييز 4، أفتح 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // تمييز 4، أفتح 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // تمييز 4، أغمق 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // تمييز 4، أغمق 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تغيير خط التصميم**

تمكينك من اختيار الخطوط للتصميمات وأغراض أخرى، يستخدم Aspose.Slides هذه المعرفات الخاصة (المشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط الجسم اللاتيني (خط اللاتيني الثانوي)
* **+mj-lt** - خط العناوين اللاتيني (خط اللاتيني الرئيسي)
* **+mn-ea** - خط الجسم شرق الآسيوي (خط شرق الآسيوي الثانوي)
* **+mj-ea** - خط الجسم شرق الآسيوي (خط شرق الآسيوي الرئيسي)

يوضح هذا الكود بلغة Java كيفية تعيين الخط اللاتيني لعنصر تصميم:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("تنسيق نص التصميم");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

يوضح هذا الكود بلغة Java كيفية تغيير خط تصميم العرض:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

سيتم تحديث الخط في جميع صناديق النص.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في رؤية [خطوط PowerPoint](/slides/androidjava/powerpoint-fonts/).

{{% /alert %}}

## **تغيير نمط خلفية التصميم**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفيات محددة مسبقًا ولكن فقط 3 من تلك الخلفيات محفوظة في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود بلغة Java لمعرفة عدد الخلفيات المحددة مسبقًا في العرض:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("عدد أنماط ملء الخلفية للتصميم هو " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) من فئة [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme)، يمكنك إضافة أو الوصول إلى نمط الخلفية في تصميم PowerPoint.

{{% /alert %}} 

يوضح هذا الكود بلغة Java كيفية تعيين الخلفية لعرض تقديمي:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**دليل الفهرس**: 0 يُستخدم لعannes. يبدأ الفهرس من 1.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في رؤية [خلفية PowerPoint](/slides/androidjava/presentation-background/).

{{% /alert %}}

## **تغيير تأثير التصميم**

عادةً ما يحتوي تصميم PowerPoint على 3 قيم لكل مجموعة أنماط. يتم دمج تلك المجموعات في هذه 3 تأثيرات: خفيف، معتدل، وشديد. على سبيل المثال، هذه هي النتيجة عند تطبيق التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) من فئة [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme) يمكنك تغيير العناصر في تصميم (بمرونة أكثر من الخيارات في PowerPoint).

يوضح هذا الكود بلغة Java كيفية تغيير تأثير التصميم عن طريق تغيير أجزاء من العناصر:

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

التغييرات الناتجة في لون التعبئة، ونوع التعبئة، وتأثير الظل، إلخ:

![todo:image_alt_text](presentation-design_11.png)