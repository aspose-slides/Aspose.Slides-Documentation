---
title: تحسين عروضك التقديمية باستخدام AutoFit في Java
linktitle: إعدادات Autofit
type: docs
weight: 30
url: /ar/java/manage-autofit-settings/
keywords:
- مربع نص
- تلقائي الملاءمة
- عدم الملاءمة التلقائية
- ملاءمة النص
- تصغير النص
- تغليف النص
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة إعدادات AutoFit في Aspose.Slides for Java لتحسين عرض النص في عروض PowerPoint و OpenDocument وتحسين قابلية قراءة المحتوى."
---

بشكل افتراضي، عند إضافة مربع نص، يستخدم Microsoft PowerPoint إعداد **Resize shape to fix text** لمربع النص—يُعيد تحجيم مربع النص تلقائيًا لضمان أن النص يظل دائمًا يتناسب معه. 

![مربع نص في PowerPoint](textbox-in-powerpoint.png)

* عندما يصبح النص داخل مربع النص أطول أو أكبر، يقوم PowerPoint تلقائيًا بتكبير مربع النص—زيادة ارتفاعه—للسماح بحفظ المزيد من النص. 
* عندما يصبح النص داخل مربع النص أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتصغير مربع النص—تقليل ارتفاعه—لإزالة المساحة الزائدة. 

في PowerPoint، هذه هي المعلمات أو الخيارات الأربعة المهمة التي تتحكم في سلوك الملاءمة التلقائية لمربع النص: 

* **عدم الملاءمة التلقائية**
* **تصغير النص عند تجاوز السعة**
* **تغيير حجم الشكل لتناسب النص**
* **تغليف النص داخل الشكل.**

![خيارات الملاءمة التلقائية في PowerPoint](autofit-options-powerpoint.png)

توفر Aspose.Slides for Java خيارات مماثلة—بعض الخصائص ضمن الفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) التي تتيح لك التحكم في سلوك الملاءمة التلقائية لمربعات النص في العروض التقديمية. 

## **تغيير حجم الشكل لتناسب النص**

إذا كنت تريد أن يتناسب النص داخل الصندوق دائمًا بعد إجراء تغييرات على النص، عليك استخدام خيار **Resize shape to fix text**. لتحديد هذا الإعداد، اضبط خاصية [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) إلى `Shape`.

![إعداد الملاءمة التلقائية الدائمة في PowerPoint](alwaysfit-setting-powerpoint.png)

هذا الكود Java يوضح لك كيفية تحديد أن النص يجب أن يتناسب دائمًا مع صندوقه في عرض PowerPoint:
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


إذا أصبح النص أطول أو أكبر، سيُعاد تحجيم مربع النص تلقائيًا (زيادة الارتفاع) لضمان أن كل النص يتناسب معه. إذا أصبح النص أقصر، يحدث العكس. 

## **عدم الملاءمة التلقائية**

إذا كنت تريد أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تُجرى على النص الموجود فيه، عليك استخدام خيار **Do not Autofit**. لتحديد هذا الإعداد، اضبط خاصية [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) إلى `None`. 

![إعداد عدم الملاءمة التلقائية في PowerPoint](donotautofit-setting-powerpoint.png)

هذا الكود Java يوضح لك كيفية تحديد أن مربع النص يجب أن يحتفظ بأبعاده دائمًا في عرض PowerPoint:
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


عندما يصبح النص طويلًا جدًا بالنسبة لصندوقه، سينفجر خارج الصندوق. 

## **تصغير النص عند تجاوز السعة**

إذا أصبح النص طويلًا جدًا بالنسبة لصندوقه، من خلال خيار **Shrink text on overflow** يمكنك تحديد أن حجم النص والمسافات يجب أن تُقلص لتتناسب مع الصندوق. لتحديد هذا الإعداد، اضبط خاصية [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) إلى `Normal`.

![إعداد تصغير النص عند تجاوز السعة في PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

هذا الكود Java يوضح لك كيفية تحديد أن النص يجب أن يُصغَر عند تجاوز السعة في عرض PowerPoint:
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
عند استخدام خيار **Shrink text on overflow**، يُطبّق الإعداد فقط عندما يصبح النص طويلًا جدًا بالنسبة لصندوقه. 
{{% /alert %}}

## **تغليف النص**

إذا كنت تريد أن يُلتف النص داخل الشكل عندما يتجاوز حدود الشكل (العرض فقط)، عليك استخدام معلمة **Wrap text in shape**. لتحديد هذا الإعداد، يجب ضبط خاصية [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) (من الفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) إلى `true`. 

هذا الكود Java يوضح لك كيفية استخدام إعداد تغليف النص في عرض PowerPoint:
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
إذا ضبطت خاصية `WrapText` إلى `False` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يُمد النص خارجه على خط واحد. 
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تؤثر الهوامش الداخلية لإطار النص على AutoFit؟**  
نعم. الهوامش الداخلية (Padding) تقلل مساحة النص المتاحة، لذا يبدأ AutoFit بالعمل مبكرًا—إما بتقليل حجم الخط أو تعديل حجم الشكل. تحقق من الهوامش قبل ضبط AutoFit.

**كيف يتفاعل AutoFit مع الفواصل اليدوية والمرنة؟**  
تظل الفواصل القسرية موجودة، ويتكيف AutoFit مع حجم الخط والمسافات حولها. إزالة الفواصل غير الضرورية غالبًا ما يقلل من شدة تقليل النص.

**هل يؤثر تغيير خط السمة أو استبدال الخط على نتائج AutoFit؟**  
نعم. استبدال الخط بخط له أبعاد مختلفة يغيّر عرض/ارتفاع النص، مما قد يغيّر حجم الخط النهائي وتغليف الأسطر. بعد أي تغيير أو استبدال للخط، أعد فحص الشرائح.