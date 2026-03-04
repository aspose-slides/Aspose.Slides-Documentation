---
title: إدارة موضوعات العرض التقديمي في Java
linktitle: موضوع العرض
type: docs
weight: 10
url: /ar/java/presentation-theme/
keywords:
- موضوع PowerPoint
- موضوع العرض التقديمي
- موضوع الشريحة
- تعيين موضوع
- تغيير موضوع
- إدارة موضوع
- لون الموضوع
- لوحة إضافية
- خط الموضوع
- نمط الموضوع
- تأثير الموضوع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحكم في موضوعات العرض التقديمي في Aspose.Slides للـ Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
يحدد موضوع العرض (Presentation Theme) خصائص عناصر التصميم. عندما تختار موضوع عرض، فأنت في الواقع تختار مجموعة محددة من العناصر المرئية وخصائصها.

في PowerPoint، يتكون الموضوع من ألوان، [الخطوط](/slides/ar/java/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/java/presentation-background/)، وتأثيرات.

![theme-constituents](theme-constituents.png)

## **Change Theme Color**

يستخدم موضوع PowerPoint مجموعة محددة من الألوان لعناصر مختلفة في الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة على الموضوع. لإتاحة اختيار لون موضوع جديد، توفر Aspose.Slides قيمًا تحت تعداد [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SchemeColor).

هذا الكود Java يوضح لك كيفية تغيير لون التمييز (Accent) للموضوع:

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

يمكنك تحديد القيمة الفعّالة للون الناتج بهذه الطريقة:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

لإظهار عملية تغيير اللون بشكل إضافي، نقوم بإنشاء عنصر آخر ونعيّنه بلون التمييز (من العملية الأولية). ثم نغيّر اللون في الموضوع:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

يُطبّق اللون الجديد تلقائيًا على العنصرين.

### **Set Theme Color from an Additional Palette**

عند تطبيق تحويلات الإضاءة على لون الموضوع الرئيسي(1)، تتشكل ألوان من اللوحة الإضافية(2). يمكنك بعد ذلك تعيين تلك الألوان أو الحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان الموضوع الرئيسي

**2** - ألوان من اللوحة الإضافية.

هذا الكود Java يوضح عملية الحصول على ألوان اللوحة الإضافية من لون الموضوع الرئيسي ثم استخدامها في الأشكال:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // التأكيد 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // التأكيد 4، أفتح 80٪
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // التأكيد 4، أفتح 60٪
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // التأكيد 4، أفتح 40٪
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // التأكيد 4، أغمق 25٪
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // التأكيد 4، أغمق 50٪
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Map `SchemeColor` to `IColorScheme` Colors**

عند العمل مع [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/schemecolor/)، قد تلاحظ أنه يحتوي على قيم ألوان الموضوع التالية:

`Background1`، `Background2`، `Text1`، و`Text2`.

مع ذلك، `Presentation.getMasterTheme().getColorScheme()` يرجع [IColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icolorscheme/)، الذي يُظهر الألوان المقابلة كـ:

`Dark1`، `Dark2`، `Light1`، و`Light2`.

هذا الاختلاف يقتصر على التسمية فقط. هذه القيم تشير إلى نفس خانات ألوان الموضوع والربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

لا يوجد تحويل ديناميكي بين `Text`/`Background` و`Dark`/`Light`. إنها مجرد أسماء بديلة لنفس ألوان الموضوع.

هذا الاختلاف في التسميات يأتي من مصطلحات Microsoft Office. الإصدارات القديمة من Office استخدمت `Dark 1`، `Light 1`، `Dark 2`، و`Light 2`، بينما الإصدارات الحديثة تعرض نفس الخانات كـ `Text 1`، `Background 1`، `Text 2`، و`Background 2`.

## **Change Theme Font**

لإتاحة اختيار الخطوط للموضوعات وأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn‑lt** - خط النص الأساسي اللاتيني (Minor Latin Font)
* **+mj‑lt** - خط العنوان اللاتيني (Major Latin Font)
* **+mn‑ea** - خط النص الأساسي الآسيوي الشرقي (Minor East Asian Font)
* **+mj‑ea** - خط العنوان الآسيوي الشرقي (Major East Asian Font)

هذا الكود Java يوضح لك كيفية تعيين الخط اللاتيني لعنصر في الموضوع:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

هذا الكود Java يوضح لك كيفية تغيير خط موضوع العرض:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/java/powerpoint-fonts/).
{{% /alert %}}

## **Change Theme Background Style**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية مُحددة مسبقًا، لكن يتم حفظ 3 منها فقط في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود Java لمعرفة عدد الخلفيات المُحددة مسبقًا في العرض:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FormatScheme)، يمكنك إضافة أو الوصول إلى نمط الخلفية في موضوع PowerPoint. 
{{% /alert %}} 

هذا الكود Java يوضح لك كيفية تعيين الخلفية لعرض تقديمي:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**دليل الفهرس**: 0 يُستخدم لعدم التعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/java/presentation-background/).
{{% /alert %}}

## **Change Theme Effect**

عادةً ما يحتوي موضوع PowerPoint على 3 قيم لكل مجموعة أنماط. تُدمج تلك المجموعات في هذه الثلاث تأثيرات: خفيف، متوسط، وشديد. على سبيل المثال، هذا هو النتيجة عند تطبيق التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FormatScheme#getFillStyles--)، [LineStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FormatScheme#getLineStyles--)، [EffectStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FormatScheme#getEffectStyles--)) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FormatScheme) يمكنك تغيير عناصر الموضوع (بمرونة أكبر من الخيارات المتاحة في PowerPoint).

هذا الكود Java يوضح لك كيفية تغيير تأثير الموضوع عبر تعديل أجزاء من العناصر:

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

التغييرات الناتجة في لون التعبئة، نوع التعبئة، تأثير الظل، إلخ:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**هل يمكنني تطبيق موضوع على شريحة واحدة دون تغيير القالب الرئيسي؟**

نعم. تدعم Aspose.Slides تجاوزات موضوع على مستوى الشريحة، بحيث يمكنك تطبيق موضوع محلي على تلك الشريحة فقط مع الحفاظ على موضوع القالب الرئيسي (عبر [SlideThemeManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل موضوع من عرض تقديمي إلى آخر؟**

استخدم [استنساخ الشرائح](/slides/ar/java/clone-slides/) مع القالب الخاص بها إلى العرض المستهدف. هذا يحافظ على القالب الأصلي، التخطيطات، والموضوع المرتبط لضمان بقاء المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعّالة" بعد كل الوراثة والتجاوزات؟**

استخدم عروض ["الفعّالة"](/slides/ar/java/shape-effective-properties/) لخصائص الموضوع/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص النهائية المُحسوبة بعد تطبيق القالب الرئيسي وأي تجاوزات محلية.