---
title: إدارة سمات العروض التقديمية على Android
linktitle: سمة العرض التقديمي
type: docs
weight: 10
url: /ar/androidjava/presentation-theme/
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
- Android
- Java
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides لنظام Android باستخدام Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على هوية العلامة التجارية المتسقة."
---

تعرف سمة العرض خصائص عناصر التصميم. عندما تختار سمة عرض، فإنك في الأساس تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، تتكون السمة من ألوان، [الخطوط](/slides/ar/androidjava/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/androidjava/presentation-background/)، وتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان لعناصر مختلفة في الشريحة. إذا لم تعجبك الألوان، يمكنك تغيّرها عن طريق تطبيق ألوان جديدة على السمة. للسماح لك باختيار لون سمة جديد، توفر Aspose.Slides قيمًا ضمن تعداد [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SchemeColor).

هذا الكود بلغة Java يوضح لك كيفية تغيير لون التمييز لسمة:
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


لتوضيح عملية تغيير اللون أكثر، نقوم بإنشاء عنصر آخر ونعيّن له لون التمييز (من العملية الأولية). ثم نغير اللون في السمة:
```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```


يتم تطبيق اللون الجديد تلقائيًا على العنصرين.

### **تعيين لون السمة من لوحة إضافية**

عند تطبيق تحويلات الإضاءة على اللون الرئيسي للسمة(1)، تتكون ألوان من اللوحة الإضافية(2). يمكنك بعد ذلك تعيين هذه الألوان السمة والحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية

**2** - ألوان من اللوحة الإضافية.

هذا الكود بلغة Java يوضح عملية يتم فيها الحصول على ألوان اللوحة الإضافية من اللون الرئيسي للسمة ثم تُستخدم في الأشكال:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // التمييز 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // التمييز 4، أخف 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // التمييز 4، أخف 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // التمييز 4، أخف 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // التمييز 4، أغمق 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // التمييز 4، أغمق 50%
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

للسماح لك باختيار الخطوط للسمة ولأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - الخط الأساسي اللاتيني (خط لاتيني ثانوي)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني رئيسي)
* **+mn-ea** - الخط الأساسي الآسيوي الشرقي (خط آسيوي شرقي ثانوي)
* **+mj-ea** - خط العنوان الآسيوي الشرقي (خط آسيوي شرقي رئيسي)

هذا الكود بلغة Java يوضح لك كيفية تعيين الخط اللاتيني لعنصر سمة:
```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```


هذا الكود بلغة Java يوضح لك كيفية تغيير خط سمة العرض:
```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```


سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في مشاهدة [خطوط PowerPoint](/slides/ar/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

افتراضيًا، يوفر تطبيق PowerPoint 12 خلفية معرفة مسبقًا ولكن يتم حفظ 3 فقط من تلك الخلفيات الـ12 في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود بلغة Java لمعرفة عدد الخلفيات المعرفة مسبقًا في العرض:
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
باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) من الفئة [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme)، يمكنك إضافة أو الوصول إلى نمط الخلفية في سمة PowerPoint.
{{% /alert %}} 

هذا الكود بلغة Java يوضح لك كيفية تعيين الخلفية لعرض تقديمي:
```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**دليل الفهرس**: يُستخدم 0 لعدم التعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في مشاهدة [خلفية PowerPoint](/slides/ar/androidjava/presentation-background/).
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما تحتوي سمة PowerPoint على 3 قيم لكل مصفوفة نمط. يتم دمج تلك المصفوفات في هذه التأثيرات الثلاثة: خفيف، متوسط، وشديد. على سبيل المثال، هذه هي النتيجة عندما يتم تطبيق التأثيرات على شكل محدد:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) من الفئة [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme) يمكنك تغيير العناصر في سمة (بمرونة أكبر من الخيارات في PowerPoint).

هذا الكود بلغة Java يوضح لك كيفية تغيير تأثير سمة عن طريق تعديل أجزاء من العناصر:
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

نعم. تدعم Aspose.Slides تجاوزات السمة على مستوى الشريحة، لذا يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على سمة الرئيسي intact (من خلال [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟**

[استنساخ الشرائح](/slides/ar/androidjava/clone-slides/) مع الماستر الخاص بها إلى العرض المستهدف. هذا يحافظ على الماستر الأصلي، التخطيطات، والسمة المرتبطة بحيث يبقى المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعّالة" بعد كل الوراثة والتجاوزات؟**

استخدم "عرض القيم الفعّالة" في الـ API عبر ["effective" views](/slides/ar/androidjava/shape-effective-properties/) للسمة/اللون/الخط/التأثير. تُرجع هذه القيم الخصائص النهائية بعد تطبيق الماستر وأي تجاوزات محلية.