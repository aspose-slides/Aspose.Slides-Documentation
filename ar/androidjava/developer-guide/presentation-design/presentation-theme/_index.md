---
title: إدارة سمات العروض التقديمية على Android
linktitle: سمة العرض التقديمي
type: docs
weight: 10
url: /ar/androidjava/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض
- سمة الشريحة
- تعيين سمة
- تغيير سمة
- إدارة سمة
- لون السمة
- لوحة ألوان إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides لنظام Android عبر Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على هوية العلامة التجارية المتسقة."
---
موضوع العرض يحدد خصائص عناصر التصميم. عندما تختار موضوع عرض، فأنت في الأساس تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، يتألف الموضوع من ألوان، [الخطوط](/slides/ar/androidjava/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/androidjava/presentation-background/)، وتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون السمة**

يستخدم موضوع PowerPoint مجموعة محددة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة للموضوع. للسماح لك باختيار لون سمة جديد، توفر Aspose.Slides القيم تحت تعداد [SchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SchemeColor).

هذا الكود Java يوضح لك كيفية تغيير لون اللكنة للموضوع:

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

لتوضيح عملية تغيير اللون بشكل أكبر، ننشئ عنصرًا آخر ونعيّن له لون اللكنة (من العملية الأولية). ثم نغيّر اللون في السمة:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

يتم تطبيق اللون الجديد تلقائيًا على كلا العنصرين.

### **تعيين لون السمة من لوحة ألوان إضافية**

عند تطبيق تحويلات الإضاءة على لون السمة الرئيسي(1)، تتشكل ألوان من لوحة الألوان الإضافية(2). يمكنك بعدها تعيين هذه الألوان أو الحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية  
**2** - ألوان من لوحة الألوان الإضافية.

هذا الكود Java يوضح عملية الحصول على ألوان لوحة إضافية من لون السمة الرئيسي ثم استخدامها في الأشكال:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // اللون المميز 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // اللون المميز 4، أفتح 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // اللون المميز 4، أفتح 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // اللون المميز 4، أفتح 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // اللون المميز 4، أغمق 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // اللون المميز 4، أغمق 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **تخطيط `SchemeColor` إلى ألوان `IColorScheme`**

عند العمل مع [SchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/schemecolor/)، قد تلاحظ أنه يحتوي على قيم ألوان السمة التالية: `Background1`، `Background2`، `Text1`، و`Text2`.

مع ذلك، تُعيد `Presentation.getMasterTheme().getColorScheme()` كائنًا من نوع [IColorScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icolorscheme/)، الذي يعرض الألوان المقابلة كالتالي: `Dark1`، `Dark2`، `Light1`، و`Light2`.

هذا الاختلاف يكمن فقط في التسمية. هذه القيم تشير إلى نفس فتحات ألوان السمة والربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

لا يوجد تحويل ديناميكي بين `Text`/`Background` و`Dark`/`Light`. إنها مجرد أسماء بديلة لنفس ألوان السمة.

هذا الاختلاف في التسمية يأتي من مصطلحات Microsoft Office. الإصدارات القديمة من Office استخدمت `Dark 1`، `Light 1`، `Dark 2`، و`Light 2`، بينما إصدارات الواجهة الحديثة تعرض نفس الفتحات كـ `Text 1`، `Background 1`، `Text 2`، و`Background 2`.

## **تغيير خط السمة**

للسماح لك باختيار خطوط للسمات وأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - الخط الأساسي اللاتيني (خط لاتيني صغير)
* **+mj-lt** - الخط الرئيسي اللاتيني (خط لاتيني كبير)
* **+mn-ea** - الخط الأساسي الآسيوي الشرقي (خط آسيوي صغير)
* **+mj-ea** - الخط الرئيسي الآسيوي الشرقي (خط آسيوي كبير)

هذا الكود Java يوضح لك كيفية تعيين الخط اللاتيني لعنصر في السمة:

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
قد ترغب في عرض [خطوط PowerPoint](/slides/ar/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية مُعرّفة مسبقًا، لكن فقط 3 من تلك الخلفيات تُحفظ في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود Java لمعرفة عدد الخلفيات المُعرّفة مسبقًا في العرض:

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
باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FormatScheme)، يمكنك إضافة أو الوصول إلى نمط الخلفية في سمة PowerPoint.
{{% /alert %}} 

هذا الكود Java يوضح لك كيفية تعيين الخلفية لعرض تقديمي:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**دليل الفهرس**: 0 يُستخدم لعدم التعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في عرض [خلفية PowerPoint](/slides/ar/androidjava/presentation-background/).
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما يحتوي موضوع PowerPoint على 3 قيم لكل مصفوفة نمط. تُدمج هذه المصفوفات في 3 تأثيرات: خفيف، متوسط، وشديد. على سبيل المثال، هذه هي النتيجة عند تطبيق التأثيرات على شكل محدد:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FormatScheme#getFillStyles--)، [LineStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FormatScheme#getLineStyles--)، [EffectStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FormatScheme) يمكنك تعديل العناصر في السمة (بمرونة أكبر من الخيارات المتوفرة في PowerPoint).

هذا الكود Java يوضح لك كيفية تغيير تأثير السمة عن طريق تعديل أجزاء من العناصر:

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

## **الأسئلة المتداولة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير القالب الرئيسي؟**

نعم. تدعم Aspose.Slides تجاوزات سمة على مستوى الشريحة، لذا يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على سمة القالب الرئيسي دون تغيير (عبر [SlideThemeManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟**

[استنساخ الشرائح](/slides/ar/androidjava/clone-slides/) مع قوالبها إلى العرض المستهدف. هذا يحافظ على القالب الأصلي، التخطيطات، والسمة المرتبطة لضمان بقاء المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعّالة" بعد جميع الوراثات والتجاوزات؟**

استخدم "العروض الفعّالة" للـ API عبر [\"القيم الفعّالة\"](/slides/ar/androidjava/shape-effective-properties/) للسمة/اللون/الخط/التأثير. تُرجع هذه القيم الخصائص النهائية المحلّلة بعد تطبيق القالب بالإضافة إلى أي تجاوزات محلية.