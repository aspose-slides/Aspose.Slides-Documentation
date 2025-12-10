---
title: حسّن عروضك التقديمية باستخدام AutoFit في Java
linktitle: إعدادات AutoFit
type: docs
weight: 30
url: /ar/java/manage-autofit-settings/
keywords:
- مربع نص
- AutoFit
- عدم AutoFit
- تناسب النص
- تصغير النص
- لف النص
- تحجيم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرف على كيفية إدارة إعدادات AutoFit في Aspose.Slides for Java لتحسين عرض النص في عروض PowerPoint وOpenDocument وتحسين قابلية قراءة المحتوى."
---

بشكل افتراضي، عند إضافة مربع نص، يستخدم Microsoft PowerPoint الإعداد **Resize shape to fix text** لمربع النص—يقوم تلقائيًا بتغيير حجم مربع النص لضمان أن النص دائمًا يتناسب معه. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* عندما يصبح النص داخل مربع النص أطول أو أكبر، يقوم PowerPoint تلقائيًا بتوسيع مربع النص—يزيد ارتفاعه—للسماح له بحمل نص أكثر. 
* عندما يصبح النص داخل مربع النص أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل مربع النص—يقلل ارتفاعه—لإزالة المسافة الزائدة. 

في PowerPoint، هذه هي المعلمات أو الخيارات الأربعة المهمة التي تتحكم في سلوك الـ Autofit لمربع النص: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

يوفر Aspose.Slides for Java خيارات مشابهة—بعض الخصائص ضمن الفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)—التي تسمح لك بالتحكم في سلوك Autofit لمربعات النص في العروض التقديمية. 

## **تحجيم الشكل لتناسب النص**

إذا كنت تريد أن يتناسب النص داخل الصندوق دائمًا مع ذلك الصندوق بعد إجراء تغييرات على النص، عليك استخدام خيار **Resize shape to fix text**. لتحديد هذا الإعداد، قم بتعيين الخاصية [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) إلى `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

يعرض لك هذا الكود بلغة Java كيفية تحديد أن النص يجب أن يتناسب دائمًا مع صندوقه في عرض PowerPoint:
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


إذا أصبح النص أطول أو أكبر، سيتم تعديل حجم مربع النص تلقائيًا (زيادة في الارتفاع) لضمان أن كل النص يتناسب معه. إذا أصبح النص أقصر، يحدث العكس. 

## **Do Not Autofit**

إذا كنت تريد أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تُجرى على النص المحتوى فيه، عليك استخدام خيار **Do not Autofit**. لتحديد هذا الإعداد، قم بتعيين الخاصية [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) إلى `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

يعرض لك هذا الكود بلغة Java كيفية تحديد أن مربع النص يجب أن يحتفظ بأبعاده دائمًا في عرض PowerPoint:
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


عندما يصبح النص طويلًا جدًا بالنسبة للصندوق، يخرج خارج الصندوق. 

## **Shrink Text on Overflow**

إذا أصبح النص طويلًا جدًا بالنسبة للصندوق، من خلال خيار **Shrink text on overflow**، يمكنك تحديد أن حجم النص وتباعده يجب أن يُقلص لجعله يتناسب مع الصندوق. لتحديد هذا الإعداد، قم بتعيين الخاصية [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) إلى `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

يعرض لك هذا الكود بلغة Java كيفية تحديد أن النص يجب أن يُقلص عند الفائض في عرض PowerPoint:
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
عند استخدام خيار **Shrink text on overflow**، يتم تطبيق الإعداد فقط عندما يصبح النص طويلًا جدًا بالنسبة للصندوق. 
{{% /alert %}}

## **Wrap Text**

إذا كنت تريد أن يلتف النص داخل الشكل عندما يتجاوز النص حدود الشكل (العرض فقط)، عليك استخدام معلمة **Wrap text in shape**. لتحديد هذا الإعداد، يجب تعيين الخاصية [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) إلى `true`. 

يعرض لك هذا الكود بلغة Java كيفية استخدام إعداد Wrap Text في عرض PowerPoint:
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
إذا قمت بتعيين الخاصية `WrapText` إلى `False` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يتم تمديد النص خارج حدود الشكل على سطر واحد. 
{{% /alert %}}

## **FAQ**

**هل تؤثر الهوامش الداخلية لإطار النص على AutoFit؟**

نعم. تقليل الحشوة (الهوامش الداخلية) مساحة النص القابلة للاستخدام، لذلك سيبدأ AutoFit في العمل مبكرًا—بتصغير الخط أو تعديل حجم الشكل أسرع. تحقق من الهوامش واضبطها قبل تحسين AutoFit.  

**كيف يتفاعل AutoFit مع الفواصل السطرية اليدوية والمرنة؟**

تبقى الفواصل القسرية في مكانها، ويتكيف AutoFit مع حجم الخط والتباعد حولها. إزالة الفواصل غير الضرورية غالبًا ما يقلل من شدة تقليص النص بواسطة AutoFit.  

**هل يؤدي تغيير خط السمة أو تفعيل استبدال الخط إلى تأثير نتائج AutoFit؟**

نعم. استبدال الخط إلى خط بخصائص تشكيل مختلفة يغير عرض/ارتفاع النص، مما قد يغيّر حجم الخط النهائي وتغليف السطر. بعد أي تغيير أو استبدال للخط، أعد فحص الشرائح.