---
title: إدارة إعدادات التكييف التلقائي
type: docs
weight: 30
url: /java/manage-autofit-settings/
keywords: "مربع النص، تكييف تلقائي، عرض بوربوينت، جافا، Aspose.Slides لـ Java"
description: "قم بتعيين إعدادات التكييف التلقائي لمربع النص في PowerPoint باستخدام جافا"
---

بشكل افتراضي، عندما تضيف مربع نص، يستخدم Microsoft PowerPoint إعداد **تغيير حجم الشكل ليتناسب مع النص** لمربع النص—حيث يقوم بتغيير حجم مربع النص تلقائيًا لضمان أن النص دائمًا يتناسب معه.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* عندما يصبح النص في مربع النص أطول أو أكبر، يقوم PowerPoint بتكبير مربع النص تلقائيًا—يزيد ارتفاعه—ليسمح له بحمل المزيد من النص.
* عندما يصبح النص في مربع النص أقصر أو أصغر، يقوم PowerPoint بتقليص مربع النص تلقائيًا—يقلل ارتفاعه—لتفريغ المساحة الزائدة.

في PowerPoint، هذه هي 4 معلمات أو خيارات مهمة تتحكم في سلوك التكييف التلقائي لمربع النص:

* **عدم التكييف التلقائي**
* **تقليص النص عند تجاوز الحجم**
* **تغيير حجم الشكل ليتناسب مع النص**
* **تغليف النص داخل الشكل.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

توفر Aspose.Slides لـ Java خيارات مشابهة—بعض الخصائص تحت فئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)—التي تتيح لك التحكم في سلوك التكييف التلقائي لمربعات النص في العروض التقديمية.

## **تغيير حجم الشكل ليتناسب مع النص**

إذا كنت ترغب في أن يتناسب النص في مربع دائمًا داخل هذا المربع بعد إجراء تغييرات على النص، عليك استخدام خيار **تغيير حجم الشكل ليتناسب مع النص**. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) إلى `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

هذا الكود بلغة جافا يظهر لك كيفية تحديد أن النص يجب أن يتناسب دائمًا مع صندوقه في عرض بوربوينت:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

إذا أصبح النص أطول أو أكبر، سيتم تغيير حجم مربع النص تلقائيًا (زيادة الارتفاع) لضمان أن كل النص يتناسب معه. إذا أصبح النص أقصر، يحدث العكس.

## **عدم التكييف التلقائي**

إذا كنت ترغب في أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تطرأ على النص الذي يحتويه، عليك استخدام خيار **عدم التكييف التلقائي**. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) إلى `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

هذا الكود بلغة جافا يظهر لك كيفية تحديد أن مربع النص يجب أن يحتفظ دائمًا بأبعاده في عرض بوربوينت:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

عندما يصبح النص طويلاً جداً بالنسبة لمربعه، فإنه يتجاوز الحدود.

## **تقليص النص عند تجاوز الحجم**

إذا أصبح النص طويلًا جدًا لمربعه، من خلال خيار **تقليص النص عند تجاوز الحجم**، يمكنك تحديد أن يتم تقليل حجم النص وتباعده ليكون ملائماً داخل صندوقه. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) إلى `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

هذا الكود بلغة جافا يظهر لك كيفية تحديد أن النص يجب أن يتقلص عند تجاوز الحجم في عرض بوربوينت:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="معلومات" color="info" %}}

عندما يتم استخدام خيار **تقليص النص عند تجاوز الحجم**، يتم تطبيق الإعداد فقط عندما يصبح النص طويلًا جدًا بالنسبة لمربعه.

{{% /alert %}}

## **تغليف النص**

إذا كنت ترغب في أن يتم تغليف النص داخل شكل ما عندما يتجاوز النص حدود الشكل (العرض فقط)، عليك استخدام معلمة **تغليف النص داخل الشكل**. لتحديد هذا الإعداد، عليك تعيين خاصية [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) إلى `true`.

هذا الكود بلغة جافا يظهر لك كيفية استخدام إعداد تغليف النص في عرض بوربوينت:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

إذا قمت بتعيين خاصية `WrapText` إلى `False` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يتم تمديد النص إلى ما وراء حدود الشكل في سطر واحد فقط.

{{% /alert %}}