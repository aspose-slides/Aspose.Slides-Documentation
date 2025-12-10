---
title: إدارة سمات العروض التقديمية في Java
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
description: "إدارة سمات العروض التقديمية في Aspose.Slides لل Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---

يعرّف سمة العرض خصائص عناصر التصميم. عندما تختار سمة عرض، فإنك في الواقع تختار مجموعة محددة من العناصر المرئية وخصائصها.

في PowerPoint، تتكوّن السمة من الألوان، [الخطوط](/slides/ar/java/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/java/presentation-background/)، والتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان للعناصر المختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة للسمة. لتتمكن من اختيار لون سمة جديد، توفر Aspose.Slides القيم ضمن تعداد [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/SchemeColor).

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


لتوضيح عملية تغيير اللون بشكل أكبر، نقوم بإنشاء عنصر آخر ونعيّن له لون السمات (من العملية الأولية). ثم نغيّر اللون في السمة:
```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```


يُطبّق اللون الجديد تلقائيًا على العنصرين.

### **تعيين لون السمة من لوحة ألوان إضافية**

عند تطبيق تحويلات الإضاءة على لون السمة الرئيسي(1)، تتكوّن ألوان من لوحة الألوان الإضافية(2). يمكنك بعد ذلك تعيين هذه الألوان السمة والحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية  
**2** - ألوان من لوحة الألوان الإضافية.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // اللون المميز 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // اللون المميز 4، أفتح بنسبة 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // اللون المميز 4، أفتح بنسبة 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // اللون المميز 4، أفتح بنسبة 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // اللون المميز 4، أغمق بنسبة 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // اللون المميز 4، أغمق بنسبة 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **تغيير خط السمة**

للسماح لك باختيار الخطوط للسميات ولأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط النص الأساسي اللاتيني (خط لاتيني صغير)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني كبير)
* **+mn-ea** - خط النص الأساسي الآسيوي الشرقي (خط آسيوي شرقي صغير)
* **+mj-ea** - خط النص الأساسي الآسيوي الشرقي (خط آسيوي شرقي كبير)

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```


يعرض لك هذا الكود Java كيفية تعيين الخط اللاتيني إلى عنصر سمة:
```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```


سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/java/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

بشكلٍ افتراضي، يوفّر تطبيق PowerPoint 12 خلفية مُعرّفة مسبقًا، لكن يتم حفظ 3 فقط من تلك الخلفيات الـ12 في عرض تقديمي نمطي.

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
باستخدام الخاصية [BackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) من الصنف [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme)، يمكنك إضافة أو الوصول إلى نمط الخلفية في سمة PowerPoint. 
{{% /alert %}} 

يعرض لك هذا الكود Java كيفية تعيين الخلفية لعروض تقديمية:
```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**دليل الفهرس**: 0 يُستخدم لعدم التعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/java/presentation-background/).
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما تحتوي سمة PowerPoint على 3 قيم لكل مصفوفة نمط. تُدمج تلك المصفوفات لتكوين هذه الـ3 تأثيرات: خفيف، متوسط، ومكثف. على سبيل المثال، هذه هي النتيجة عند تطبيق التأثيرات على شكل محدد:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getEffectStyles--)) من الصنف [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme) يمكنك تغيير عناصر السمة (بمرونة أكبر من الخيارات المتاحة في PowerPoint).
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

## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الرئيسي؟**  
نعم. تدعم Aspose.Slides تجاوزات السمة على مستوى الشريحة، بحيث يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على سمة الرئيسي كما هي (عبر [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/)).

**ما هي الطريقة الأكثر أمناً لنقل سمة من عرض تقديمي إلى آخر؟**  
[Clone slides](/slides/ar/java/clone-slides/) مع الماستر الخاص بها إلى العرض الهدف. هذا يحافظ على الماستر الأصلي، التخطيطات، والسمة المرتبطة لضمان بقاء المظهر متسقاً.

**كيف يمكنني رؤية القيم "الفعّالة" بعد كل الوراثة وتجاوزات؟**  
استخدم عارضات "الفعّالة" في API (/slides/ar/java/shape-effective-properties/) للسمة/اللون/الخط/التأثير. هذه تُعيد الخصائص النهائية المُحلولة بعد تطبيق الماستر وأي تجاوزات محلية.