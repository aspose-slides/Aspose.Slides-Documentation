---
title: إدارة إعدادات الملاءمة التلقائية
type: docs
weight: 30
url: /ar/androidjava/manage-autofit-settings/
keywords: "مربع نص, ملاءمة تلقائية, تقديم باوربوينت, جافا, Aspose.Slides for Android via Java"
description: "تعيين إعدادات الملاءمة التلقائية لمربع النص في باوربوينت باستخدام جافا"
---

بشكل افتراضي، عندما تضيف مربع نص، يستخدم برنامج Microsoft PowerPoint إعداد **تغيير حجم الشكل ليتناسب مع النص** لمربع النص - يقوم تلقائيًا بتغيير حجم مربع النص لضمان ملاءمة النص بشكل دائم بداخله.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* عندما يصبح النص في مربع النص أطول أو أكبر، يقوم PowerPoint تلقائيًا بتكبير مربع النص - زيادة ارتفاعه - للسماح له بحمل المزيد من النص.
* عندما يصبح النص في مربع النص أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل حجم مربع النص - تقليل ارتفاعه - لإزالة المساحة الزائدة.

في PowerPoint، هناك 4 معلمات أو خيارات مهمة تتحكم في سلوك الملاءمة التلقائية لمربع النص:

* **عدم الملاءمة التلقائية**
* **تقليص النص عند تجاوز الحد**
* **تغيير حجم الشكل ليتناسب مع النص**
* **تغليف النص في الشكل.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

تقدم Aspose.Slides for Android via Java خيارات مشابهة - بعض الخصائص تحت فئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) - التي تسمح لك بالتحكم في سلوك الملاءمة التلقائية لمربعات النص في العروض التقديمية.

## **تغيير حجم الشكل ليتناسب مع النص**

إذا كنت ترغب في أن يتناسب النص في مربع مع هذا المربع دائمًا بعد إجراء تغييرات على النص، عليك استخدام خيار **تغيير حجم الشكل ليتناسب مع النص**. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) إلى `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

يوضح لك هذا الرمز في جافا كيفية تحديد وجوب ملاءمة النص دائمًا داخل مربعه في عرض باوربوينت:

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

إذا أصبح النص أطول أو أكبر، فسيتم تغيير حجم مربع النص تلقائيًا (زيادة في الارتفاع) لضمان ملاءمة كل النص داخله. إذا أصبح النص أقصر، يحدث العكس.

## **عدم الملاءمة التلقائية**

إذا كنت ترغب في أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تطرأ على النص الذي يحتويه، فعليك استخدام خيار **عدم الملاءمة التلقائية**. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) إلى `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

يوضح لك هذا الرمز في جافا كيفية تحديد ضرورة احتفاظ مربع النص بأبعاده دائمًا في عرض باوربوينت:

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

عندما يصبح النص طويلاً جدًا بالنسبة لمربعه، يتجاوز الحدود.

## **تقلص النص عند تجاوز الحد**

إذا أصبح النص طويلًا جدًا بالنسبة لمربعه، من خلال خيار **تقلص النص عند تجاوز الحد**، يمكنك تحديد أنه يجب تقليل حجم النص وتباعده ليتناسب مع مربعه. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) إلى `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

يوضح لك هذا الرمز في جافا كيفية تحديد ضرورة تقلص النص عند تجاوز الحد في عرض باوربوينت:

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

عند استخدام خيار **تقلص النص عند تجاوز الحد**، يتم تطبيق الإعداد فقط عندما يصبح النص طويلًا جدًا بالنسبة لمربعه.

{{% /alert %}}

## **تغليف النص**

إذا كنت ترغب في أن يتم تغليف النص داخل شكل عندما يتجاوز النص حدود الشكل (العرض فقط)، عليك استخدام معلمة **تغليف النص في الشكل**. لتحديد هذا الإعداد، يجب أن تعين خاصية [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) إلى `true`.

يوضح لك هذا الرمز في جافا كيفية استخدام إعداد تغليف النص في عرض باوربوينت:

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

إذا قمت بتعيين خاصية `WrapText` إلى `False` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يتم تمديد النص خارج حدود الشكل على شكل خط واحد.

{{% /alert %}}