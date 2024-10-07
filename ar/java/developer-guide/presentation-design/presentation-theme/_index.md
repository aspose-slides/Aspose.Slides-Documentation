---
title: موضوع العرض
type: docs
weight: 10
url: /java/presentation-theme/
keywords: "موضوع، موضوع PowerPoint، عرض PowerPoint، Java، Aspose.Slides لـ Java"
description: "موضوع عرض PowerPoint في Java"
---

يحدد موضوع العرض خصائص عناصر التصميم. عند اختيارك لموضوع عرض، فإنك تختار في الأساس مجموعة محددة من العناصر المرئية وخصائصها.

في PowerPoint، يتكون الموضوع من ألوان، [الخطوط](/slides/java/powerpoint-fonts/)، [أنماط الخلفية](/slides/java/presentation-background/)، والتأثيرات.

![مكونات الموضوع](theme-constituents.png)

## **تغيير لون الموضوع**

يستخدم موضوع PowerPoint مجموعة محددة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها من خلال تطبيق ألوان جديدة للموضوع. للسماح لك باختيار لون جديد للموضوع، توفر Aspose.Slides قيمًا تحت تعداد [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/SchemeColor).

يعرض كود Java هذا كيفية تغيير لون التمييز لموضوع:

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

يمكنك تحديد القيمة الفعالة للون الناتج بهذه الطريقة:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

لإظهار عملية تغيير اللون بشكل أكبر، نقوم بإنشاء عنصر آخر ونAssign لون التمييز (من العملية الأولية) له. ثم نغير اللون في الموضوع:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

يتم تطبيق اللون الجديد تلقائيًا على كلا العنصرين.

### **تعيين لون الموضوع من لوحة إضافية**

عند تطبيق تحويلات السطوع على لون الموضوع الرئيسي(1)، يتم تشكيل الألوان من اللوحة الإضافية(2). يمكنك بعد ذلك تعيين والحصول على تلك الألوان الموضوعية.

![ألوان اللوحة الإضافية](additional-palette-colors.png)

**1** - ألوان الموضوع الرئيسية

**2** - ألوان من اللوحة الإضافية.

يعرض كود Java هذا عملية يتم فيها الحصول على ألوان اللوحة الإضافية من لون الموضوع الرئيسي ثم استخدامها في الأشكال:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // تمييز 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // تمييز 4، أخف 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // تمييز 4، أخف 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // تمييز 4، أخف 40%
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

## **تغيير خط الموضوع**

للسماح لك باختيار الخطوط للمواضيع ولأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (المشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط الجسم اللاتيني (خط لاتيني ثانوي)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني رئيسي)
* **+mn-ea** - خط الجسم شرق آسيوي (خط شرق آسيوي ثانوي)
* **+mj-ea** - خط العنوان شرق آسيوي (خط شرق آسيوي رئيسي)

يعرض كود Java هذا كيفية تعيين الخط اللاتيني لعنصر موضوع:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("تنسيق نص الموضوع");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

يعرض كود Java هذا كيفية تغيير خط موضوع العرض:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في رؤية [خطوط PowerPoint](/slides/java/powerpoint-fonts/).

{{% /alert %}}

## **تغيير نمط خلفية الموضوع**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفيات محددة مسبقًا ولكن 3 فقط من تلك الخلفيات الـ 12 محفوظة في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود Java لمعرفة عدد الخلفيات المحددة مسبقًا في العرض التقديمي:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("عدد أساليب تعبئة الخلفية للموضوع هو " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) من فئة [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme)، يمكنك إضافة أو الوصول إلى نمط الخلفية في موضوع PowerPoint. 

{{% /alert %}} 

يعرض كود Java هذا كيفية تعيين الخلفية لعروض تقديمية:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**دليل الفهرس**: يُستخدم 0 لعدم وجود تعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في رؤية [خلفية PowerPoint](/slides/java/presentation-background/).

{{% /alert %}}

## **تغيير تأثير الموضوع**

عادة ما يحتوي موضوع PowerPoint على 3 قيم لكل مصفوفة أنماط. يتم دمج تلك المصفوفات في هذه 3 تأثيرات: خفيف، معتدل، وشديد. على سبيل المثال، هذا هو الناتج عندما يتم تطبيق التأثيرات على شكل محدد:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getFillStyles--)، [LineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getLineStyles--)، [EffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getEffectStyles--)) من فئة [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme)، يمكنك تغيير العناصر في موضوع (حتى أكثر مرونة من الخيارات في PowerPoint).

يعرض كود Java هذا كيفية تغيير تأثير الموضوع عن طريق تغيير أجزاء من العناصر:

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