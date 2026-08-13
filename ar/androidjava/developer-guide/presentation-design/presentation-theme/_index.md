---
title: إدارة سمات العرض على Android
linktitle: سمة العرض
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
description: "أحكم سمة العروض التقديمية في Aspose.Slides لنظام Android عبر Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
## **المقدمة**

تعرف سمة العرض الخصائص لعناصر التصميم. عندما تختار سمة عرض، فأنت في الأساس تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، تتكون السمة من ألوان، [الخطوط](/slides/ar/androidjava/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/androidjava/presentation-background/)، وتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة على السمة. لتتمكن من اختيار لون سمة جديد، توفر Aspose.Slides قيمًا ضمن تعداد [SchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SchemeColor).

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

للتوضيح الإضافي لعملية تغيير اللون، نقوم بإنشاء عنصر آخر ونعين له لون التمييز (من العملية الأولية). ثم نغيّر اللون في السمة:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

يتم تطبيق اللون الجديد تلقائيًا على العنصرين.

### **تعيين لون السمة من لوحة ألوان إضافية**

عند تطبيق عمليات تحويل الإضاءة على لون السمة الرئيسي(1)، تتكون ألوان من لوحة الألوان الإضافية(2). يمكنك بعد ذلك تعيين تلك الألوان السمة والحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية  
**2** - ألوان من لوحة الألوان الإضافية.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // التمييز 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // التمييز 4، أخف بنسبة 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // التمييز 4، أخف بنسبة 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // التمييز 4، أخف بنسبة 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // التمييز 4، أغمق بنسبة 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // التمييز 4، أغمق بنسبة 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **خريطة `SchemeColor` إلى ألوان `IColorScheme`**

عند العمل مع [SchemeColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/schemecolor/)، قد تلاحظ أنه يحتوي على قيم ألوان السمة التالية: `Background1`، `Background2`، `Text1`، و`Text2`.

ومع ذلك، تُعيد `Presentation.getMasterTheme().getColorScheme()` كائنًا من نوع [IColorScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icolorscheme/)، الذي يعرض الألوان المقابلة على النحو التالي: `Dark1`، `Dark2`، `Light1`، و`Light2`.

هذا الاختلاف يقتصر على التسمية فقط. هذه القيم تشير إلى نفس الفتحات اللونية للسمة والخرائط ثابتة:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

لا يوجد تحويل ديناميكي بين `Text`/`Background` و `Dark`/`Light`. إنهما مجرد أسماء بديلة لنفس ألوان السمة.

هذا الاختلاف في التسمية يأتي من مصطلحات Microsoft Office. استخدمت إصدارات Office القديمة `Dark 1`، `Light 1`، `Dark 2`، و`Light 2`، بينما تعرض الإصدارات الحديثة من الواجهة نفس الفتحات كـ `Text 1`، `Background 1`، `Text 2`، و`Background 2`.

## **تغيير خط السمة**

لكي تتمكن من اختيار الخطوط للسمة والتطبيقات الأخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط النص الأساسي اللاتيني (خط لاتيني فرعي)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني رئيسي)
* **+mn-ea** - خط النص الأساسي الآسيوي الشرقي (خط آسيوي شرقي فرعي)
* **+mj-ea** - خط النص الأساسي الآسيوي الشرقي (خط آسيوي شرقي رئيسي)

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

يعرض هذا الكود Java كيفية تغيير خط سمة العرض:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="info" title="TIP" %}} 
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

افتراضيًا، توفر تطبيق PowerPoint 12 خلفية معرفة مسبقًا ولكن يتم حفظ 3 فقط من تلك الخلفيات الـ12 في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود Java لمعرفة عدد الخلفيات المعرفة مسبقًا في العرض:

```java
import com.aspose.slides.*;

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

يعرض هذا الكود Java كيفية تعيين الخلفية لعرض تقديمي:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**دليل الفهرس**: 0 تُستخدم للعدم تعبئة. يبدأ الفهرس من 1.

{{% alert color="info" title="TIP" %}} 
قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/androidjava/presentation-background/).
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما تحتوي سمة PowerPoint على 3 قيم لكل مصفوفة نمط. يتم دمج تلك المصفوفات في 3 تأثيرات: خفيف، متوسط، وشديد. على سبيل المثال، هذا هو النتيجة عندما يتم تطبيق التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FormatScheme) يمكنك تغيير العناصر في السمة (بمرونة أكبر من الخيارات في PowerPoint).

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **الأسئلة المتكررة**

### هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير القالب الرئيسي؟

نعم. يدعم Aspose.Slides تجاوز السمة على مستوى الشريحة، بحيث يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على سمة القالب الرئيسي دون تعديل (عبر [SlideThemeManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidethememanager/)).

### ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟

[Clone slides](/slides/ar/androidjava/clone-slides/) مع القالب الخاص بهم إلى العرض الهدف. هذا يحافظ على القالب الأصلي، والتصاميم، والسمة المرتبطة بحيث يبقى المظهر متسقًا.

### كيف يمكنني رؤية القيم “الفعّالة” بعد كل الوراثة والتجاوزات؟

استخدم “العروض الفعّالة” في الـ API [/slides/ar/androidjava/shape-effective-properties/] للسمة/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص النهائية المحسوبة بعد تطبيق القالب الرئيسي وأي تجاوزات محلية.