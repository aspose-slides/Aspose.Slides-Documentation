---
title: تحسين عروضك التقديمية باستخدام AutoFit على Android
linktitle: إعدادات Autofit
type: docs
weight: 30
url: /ar/androidjava/manage-autofit-settings/
keywords:
- مربع نص
- ملاءمة تلقائية
- عدم الملاءمة التلقائية
- ملاءمة النص
- تصغير النص
- تغليف النص
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة إعدادات AutoFit في Aspose.Slides لنظام Android عبر Java لتحسين عرض النص في عروض PowerPoint وOpenDocument وزيادة قابلية قراءة المحتوى."
---


بشكل افتراضي، عندما تقوم بإضافة مربع نص، يستخدم Microsoft PowerPoint إعداد **Resize shape to fix text** لمربع النص—يقوم تلقائيًا بتغيير حجم مربع النص لضمان توافق النص دائمًا معه. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* عندما يصبح النص داخل مربع النص أطول أو أكبر، يقوم PowerPoint تلقائيًا بتكبير مربع النص—يزيد ارتفاعه—ليستوعب نصًا أكثر. 
* عندما يصبح النص داخل مربع النص أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل حجم مربع النص—ينقص ارتفاعه—لإزالة المساحة الزائدة. 

في PowerPoint، هناك أربعة معلمات أو خيارات مهمة تتحكم في سلوك الملاءمة التلقائية (autofit) لمربع النص:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

توفر Aspose.Slides لنظام Android عبر Java خيارات مماثلة—بعض الخصائص داخل الفئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) التي تتيح لك التحكم في سلوك الملاءمة التلقائية لمربعات النص في العروض التقديمية.

## **تغيير حجم الشكل ليتناسب مع النص**

إذا كنت تريد أن يتناسب النص داخل صندوق دائمًا مع ذلك الصندوق بعد إجراء تغييرات على النص، يجب عليك استخدام خيار **Resize shape to fix text**. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) إلى `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

يعرض هذا الكود Java كيفية تحديد أن النص يجب أن يتناسب دائمًا مع صندوقه في عرض PowerPoint:
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


إذا أصبح النص أطول أو أكبر، سيتم تعديل حجم مربع النص تلقائيًا (زيادة في الارتفاع) لضمان أن يتسع له جميع النص. إذا أصبح النص أقصر، يحدث العكس. 

## **عدم الملاءمة التلقائية**

إذا كنت تريد أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تُجرى على النص المحتوى، يجب عليك استخدام خيار **Do not Autofit**. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) إلى `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

يعرض هذا الكود Java كيفية تحديد أن مربع النص يجب أن يحتفظ بأبعاده دائمًا في عرض PowerPoint:
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


عندما يصبح النص أطول من الصندوق، يخرج خارجًا. 

## **تصغير النص عند التدفق الزائد**

إذا أصبح النص أطول من الصندوق، يمكنك عبر خيار **Shrink text on overflow** تحديد أن حجم النص وتباعده يجب تقليصهما ليتناسب مع الصندوق. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) إلى `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

يعرض هذا الكود Java كيفية تحديد أن النص يجب أن يُصغر عند التدفق الزائد في عرض PowerPoint:
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


{{% alert title="Info" color="info" %}}
عند استخدام خيار **Shrink text on overflow**، يتم تطبيق الإعداد فقط عندما يصبح النص أطول من الصندوق. 
{{% /alert %}}

## **تغليف النص**

إذا كنت تريد أن يتم تغليف النص داخل الشكل عندما يتجاوز النص حد الشكل (العرض فقط)، يجب عليك استخدام معامل **Wrap text in shape**. لتحديد هذا الإعداد، يجب تعيين خاصية [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) إلى `true`.

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


{{% alert title="Note" color="warning" %}} 
إذا قمت بتعيين خاصية `WrapText` إلى `False` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، سيتم تمديد النص خارج حدود الشكل على سطر واحد. 
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تؤثر الهوامش الداخلية لإطار النص على AutoFit؟**

نعم. تقلل الهوامش الداخلية (Padding) من المساحة المتاحة للنص، لذا سيُفعل AutoFit مبكرًا—سيتم تصغير الخط أو تعديل حجم الشكل بسرعة أكبر. تحقق من الهوامش واضبطها قبل ضبط AutoFit.

**كيف يتفاعل AutoFit مع الفواصل اليدوية والناعمة؟**

تظل الفواصل القسرية موجودة، ويتكيف AutoFit مع حجم الخط والتباعد حولها. إزالة الفواصل غير الضرورية غالبًا ما يقلل من مدى حاجة AutoFit لتصغير النص بشدة.

**هل يؤثر تغيير خط السمة أو تشغيل استبدال الخطوط على نتائج AutoFit؟**

نعم. استبدال الخط بخط له مقاييس حروف مختلفة يغيّر عرض/ارتفاع النص، مما قد يغيّر حجم الخط النهائي وتغليف السطر. بعد أي تغيير أو استبدال للخط، يجب مراجعة الشرائح مرة أخرى.