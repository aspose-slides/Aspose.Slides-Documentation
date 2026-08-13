---
title: إدارة سمات العروض التقديمية في جافا
linktitle: سمة العرض التقديمي
type: docs
weight: 10
url: /ar/java/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض التقديمي
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
- Java
- Aspose.Slides
description: "إتقان سمات العروض التقديمية في Aspose.Slides لجافا لإنشاء وتخصيص وتحويل ملفات PowerPoint مع هوية علامة تجارية متسقة."
---
## **المقدمة**

تحدد سمة العرض خصائص عناصر التصميم. عند اختيارك لسمة العرض، فإنك في الأساس تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، تتكون السمة من الألوان، [الخطوط](/slides/ar/java/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/java/presentation-background/)، والتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها عن طريق تطبيق ألوان جديدة للسمة. للسماح لك باختيار لون سمة جديد، توفر Aspose.Slides القيم تحت تعداد [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SchemeColor).

يعرض لك هذا الكود Java كيفية تغيير لون التمييز لسمة:

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

يمكنك تحديد القيمة الفعلية للون الناتج بهذه الطريقة:

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

للتوضيح الإضافي لعملية تغيير اللون، نقوم بإنشاء عنصر آخر ونعينه بلون التمييز (من العملية الأولية). ثم نغير اللون في السمة:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

يتم تطبيق اللون الجديد تلقائيًا على كلا العنصرين.

### **تعيين لون السمة من لوحة ألوان إضافية**

عند تطبيق تحويلات الإضاءة على لون السمة الرئيسي(1)، تتشكل ألوان من لوحة الألوان الإضافية(2). يمكنك بعد ذلك تعيين تلك ألوان السمة والحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية  
**2** - ألوان من لوحة الألوان الإضافية.

يظهر لك هذا الكود Java عملية يتم فيها الحصول على ألوان لوحة إضافية من لون السمة الرئيسي ثم استخدامها في الأشكال:

```java
import com.aspose.slides.*;

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

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **تخطيط `SchemeColor` إلى ألوان `IColorScheme`**

عند العمل مع [SchemeColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/schemecolor/)، قد تلاحظ أنه يحتوي على قيم ألوان السمة التالية: `Background1`، `Background2`، `Text1`، و`Text2`.

مع ذلك، تُعيد `Presentation.getMasterTheme().getColorScheme()` كائنًا من النوع [IColorScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icolorscheme/)، الذي يكشف عن الألوان المقابلة كالتالي: `Dark1`، `Dark2`، `Light1`، و`Light2`.

الفرق هنا فقط في التسمية. هذه القيم تشير إلى نفس مواضع ألوان السمة والتطابق ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

لا يوجد تحويل ديناميكي بين `Text`/`Background` و `Dark`/`Light`. إنها مجرد أسماء بديلة لنفس ألوان السمة.

هذا الاختلاف في التسمية يأتي من مصطلحات Microsoft Office. استخدمت إصدارات Office القديمة `Dark 1`، `Light 1`، `Dark 2`، و`Light 2`، بينما تعرض إصدارات الواجهة الحديثة نفس المواضع كـ `Text 1`، `Background 1`، `Text 2`، و`Background 2`.

## **تغيير خط السمة**

للسماح لك باختيار الخطوط للسيمة ولأغراض أخرى، يستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - الخط الأساسي اللاتيني (خط لاتيني صغيري)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني رئيسي)
* **+mn-ea** - الخط الأساسي الآسيوي الشرقي (خط آسيوي شرقي صغيري)
* **+mj-ea** - الخط الأساسي الآسيوي الشرقي (خط آسيوي شرقي رئيسي)

يعرض لك هذا الكود Java كيفية تعيين الخط اللاتيني لعنصر سمة:

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

يعرض لك هذا الكود Java كيفية تغيير خط سمة العرض:

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
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/java/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

افتراضيًا، يقدم تطبيق PowerPoint 12 خلفية محددة مسبقًا ولكن يتم حفظ 3 فقط من تلك الخلفيات الـ12 في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود Java لمعرفة عدد الخلفيات المحددة مسبقًا في العرض:

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
باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FormatScheme)، يمكنك إضافة أو الوصول إلى نمط الخلفية في سمة PowerPoint. 
{{% /alert %}} 

يعرض لك هذا الكود Java كيفية تعيين الخلفية لعرض تقديمي:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**دليل الفهرس**: يُستخدم 0 لعدم التعبئة. يبدأ الفهرس من 1.

{{% alert color="info" title="TIP" %}} 
قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/java/presentation-background/).
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما تحتوي سمة PowerPoint على 3 قيم لكل مجموعة من الأنماط. تُدمج تلك المجموعات في هذه التأثيرات الثلاثة: خفيف، متوسط، ومكثف. على سبيل المثال، هذه هي النتيجة عند تطبيق التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام ثلاث خصائص ([FillStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FormatScheme#getEffectStyles--)) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FormatScheme) يمكنك تغيير العناصر في سمة (بمرونة أكبر من الخيارات المتوفرة في PowerPoint).

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

### **هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. تدعم Aspose.Slides تجاوز السمة على مستوى الشريحة، لذا يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على سمة الماستر كما هي (من خلال [SlideThemeManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidethememanager/)).

### **ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟**

[نسخ الشرائح](/slides/ar/java/clone-slides/) مع الماستر الخاص بها إلى العرض المستهدف. هذا يحافظ على الماستر الأصلي، وتخطيطات الشرائح، والسمة المرتبطة بحيث يبقى المظهر متسقًا.

### **كيف يمكنني مشاهدة القيم "الفعالة" بعد جميع الوراثة والتجاوزات؟**

استخدم "العروض الفعالة" في API عبر ["effective" views](/slides/ar/java/shape-effective-properties/) للسمة/اللون/الخط/التأثير. تُرجع هذه القيم الخصائص النهائية التي تم حلها بعد تطبيق الماستر وأي تجاوزات محلية.