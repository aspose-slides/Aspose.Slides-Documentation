---
title: تحسين عروضك التقديمية باستخدام AutoFit على Android
linktitle: إعدادات Autofit
type: docs
weight: 30
url: /ar/androidjava/manage-autofit-settings/
keywords:
- مربع نص
- ضبط تلقائي
- عدم الضبط التلقائي
- ملاءمة النص
- تقليل النص
- التفاف النص
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة إعدادات AutoFit في Aspose.Slides لنظام Android عبر Java لتحسين عرض النص في عروض PowerPoint وOpenDocument وتحسين قابلية قراءة المحتوى."
---

بشكل افتراضي، عند إضافة مربع نص، يستخدم Microsoft PowerPoint إعداد **Resize shape to fix text** لمربع النص—فهو يقوم تلقائيًا بتغيير حجم مربع النص لضمان توافق النص دائمًا معه. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* عندما يصبح النص داخل مربع النص أطول أو أكبر، يقوم PowerPoint تلقائيًا بتوسيع مربع النص—زيادة ارتفاعه—لسعه على استيعاب المزيد من النص. 
* عندما يصبح النص داخل مربع النص أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل حجم مربع النص—تقليل ارتفاعه—لإزالة المساحة الزائدة. 

في PowerPoint، هذه هي الخيارات الأربعة الهامة التي تتحكم في سلوك الضبط التلقائي لمربع النص: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

توفر Aspose.Slides for Android عبر Java خيارات مشابهة—بعض الخصائص ضمن الفئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)—التي تتيح لك التحكم في سلوك الضبط التلقائي لمربعات النص في العروض التقديمية.

## **تغيير حجم الشكل ليتناسب مع النص**

إذا كنت تريد أن يتناسب النص داخل الصندوق دائمًا مع الصندوق بعد تعديل النص، عليك استخدام خيار **Resize shape to fix text**. لتحديد هذا الإعداد، قم بتعيين الخاصية [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) إلى `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

هذا الكود Java يوضح كيفية تحديد أن النص يجب أن يتناسب دائمًا مع الصندوق في عرض PowerPoint:
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


إذا أصبح النص أطول أو أكبر، سيتم تعديل حجم مربع النص تلقائيًا (زيادة الارتفاع) لضمان احتواء جميع النص. إذا أصبح النص أقصر، يحدث العكس. 

## **عدم الضبط التلقائي**

إذا كنت تريد أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تم إجراؤها على النص داخلها، عليك استخدام خيار **Do not Autofit**. لتحديد هذا الإعداد، قم بتعيين الخاصية [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) إلى `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

هذا الكود Java يوضح كيفية تحديد أن مربع النص يجب أن يحتفظ بأبعاده في عرض PowerPoint:
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


عندما يصبح النص طويلاً جدًا بالنسبة لصندوقه، سيخرج خارج الصندوق. 

## **تقليل حجم النص عند الزايدة**

إذا أصبح النص أطول من الصندوق، يمكنك من خلال خيار **Shrink text on overflow** تحديد أن حجم النص والمسافات يجب أن تُقلص لتتناسب مع الصندوق. لتحديد هذا الإعداد، قم بتعيين الخاصية [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) إلى `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

هذا الكود Java يوضح كيفية تحديد أن النص يُقلص عند الزايدة في عرض PowerPoint:
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

## **التفاف النص**

إذا كنت تريد أن يلتف النص داخل الشكل عندما يتجاوز النص حدود الشكل (العرض فقط)، عليك استخدام параметر **Wrap text in shape**. لتحديد هذا الإعداد، يجب تعيين الخاصية [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) إلى `true`.

هذا الكود Java يوضح كيفية استعمال إعداد Wrap Text في عرض PowerPoint:
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
إذا قمت بتعيين الخاصية `WrapText` إلى `False` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، سيتم تمديد النص خارج حدود الشكل على سطر واحد. 
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تؤثر الهوامش الداخلية لإطار النص على الضبط التلقائي؟**

نعم. الهوامش الداخلية (Padding) تقلل المنطقة القابلة للاستخدام للنص، لذا يبدأ الضبط التلقائي في العمل مبكرًا—إما بتصغير الخط أو تعديل حجم الشكل. تحقق من الهوامش واضبطها قبل تعديل الضبط التلقائي.

**كيف يتفاعل الضبط التلقائي مع فواصل الأسطر اليدوية والمرنة؟**

الفواصل القسرية تظل موجودة، والضبط التلقائي يعدل حجم الخط والمسافات حولها. إزالة الفواصل غير الضرورية غالبًا ما يقلل من شدة تقليل النص بواسطة الضبط التلقائي.

**هل يؤثر تغيير خط السمة أو استبدال الخط على نتائج الضبط التلقائي؟**

نعم. استبدال الخط بخط يختلف في أبعاد الحروف يغيّر عرض/ارتفاع النص، ما قد يغير حجم الخط النهائي وتغليف السطر. بعد أي تغيير أو استبدال للخط، أعد مراجعة الشرائح.