---
title: تأثير الشكل
type: docs
weight: 30
url: /androidjava/shape-effect
keywords: "تأثير الشكل, عرض PowerPoint, Java, Aspose.Slides لـ Android عبر Java"
description: "تطبيق تأثير على شكل PowerPoint في Java"
---

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل بارزًا، إلا أنها تختلف عن [التعبئات](/slides/androidjava/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، ونشر توهج الشكل، وما إلى ذلك.

<img src="shape-effect.png" alt="تأثير الشكل" style="zoom:50%;" />

* يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

* بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، خيارات PowerPoint تحت **النمط المحدد مسبقًا**. تعتبر خيارات النمط المحدد مسبقًا في الأساس تركيبة معروفة جيدة المظهر من تأثيرين أو أكثر. بهذه الطريقة، من خلال اختيار نمط محدد مسبقًا، لن تضطر إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة جيدة.

توفر Aspose.Slides خصائص وطرق تحت فئة [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectFormat) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

يوضح لك هذا الرمز بلغة Java كيفية تطبيق تأثير الظل الخارجي ([OuterShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) على مستطيل:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تطبيق تأثير الانعكاس**

يوضح لك هذا الرمز بلغة Java كيفية تطبيق تأثير الانعكاس على شكل:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تطبيق تأثير التوهج**

يوضح لك هذا الرمز بلغة Java كيفية تطبيق تأثير التوهج على شكل:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تطبيق تأثير الحواف الناعمة**

يوضح لك هذا الرمز بلغة Java كيفية تطبيق الحواف الناعمة على شكل:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```