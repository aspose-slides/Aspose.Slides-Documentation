---
title: إدارة إعدادات Autofit
type: docs
weight: 30
url: /ar/nodejs-java/manage-autofit-settings/
keywords: "صندوق نص, الملاءمة التلقائية, عرض PowerPoint, Java, Aspose.Slides لـ Node.js عبر Java"
description: "ضبط إعدادات الملاءمة التلقائية لصندوق النص في PowerPoint باستخدام JavaScript"
---

بشكل افتراضي، عند إضافة صندوق نص، يستخدم Microsoft PowerPoint إعداد **Resize shape to fix text** لصندوق النص—فهو يغير حجم صندوق النص تلقائيًا لضمان أن النص يتناسب دائمًا معه. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* عندما يصبح النص في صندوق النص أطول أو أكبر، يقوم PowerPoint تلقائيًا بتوسيع صندوق النص—يزيد ارتفاعه—لسماح بتخزين المزيد من النص. 
* عندما يصبح النص في صندوق النص أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل حجم صندوق النص—يقلل ارتفاعه—لإزالة المساحة الزائدة. 

في PowerPoint، هناك 4 معلمات أو خيارات مهمة تتحكم في سلوك Autofit لصناديق النص: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

توفر Aspose.Slides for Node.js via Java خيارات مماثلة—بعض الخصائص تحت فئة [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat)—تسمح لك بالتحكم في سلوك Autofit لصناديق النص في العروض التقديمية.

## **تغيير حجم الشكل لتناسب النص**

إذا كنت تريد أن يتناسب النص داخل الصندوق دائمًا بعد إجراء أي تغييرات على النص، عليك استخدام خيار **Resize shape to fix text**. لتحديد هذا الإعداد، استدعِ الطريقة [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) بالقيمة `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

يظهر هذا الكود JavaScript كيفية تحديد أن النص يجب أن يتناسب دائمًا مع الصندوق في عرض PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


إذا أصبح النص أطول أو أكبر، سيتم تعديل حجم صندوق النص تلقائيًا (زيادة في الارتفاع) لضمان توافق جميع النص معه. إذا أصبح النص أقصر، يحدث العكس. 

## **عدم استخدام Autofit**

إذا كنت تريد أن يحتفظ صندوق النص أو الشكل بأبعادها بغض النظر عن التغييرات التي تطرأ على النص داخلها، عليك استخدام خيار **Do not Autofit**. لتحديد هذا الإعداد، استدعِ الطريقة [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) بالقيمة `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

يظهر هذا الكود JavaScript كيفية تحديد أن صندوق النص يجب أن يحتفظ بأبعاده دائمًا في عرض PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


عندما يصبح النص أطول من الصندوق، يفيض خارج الصندوق. 

## **تقليص النص عند الفائض**

إذا أصبح النص أطول من الصندوق، يمكنك باستخدام خيار **Shrink text on overflow** تحديد أن حجم النص وتباعده يجب أن يُخفض لتناسب الصندوق. لتحديد هذا الإعداد، استدعِ الطريقة [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) بالقيمة `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

يظهر هذا الكود JavaScript كيفية تحديد أن النص يُقَلَّص عند الفائض في عرض PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Info" color="info" %}}
عند استخدام خيار **Shrink text on overflow**، يتم تطبيق الإعداد فقط عندما يصبح النص أطول من الصندوق. 
{{% /alert %}}

## **التفاف النص**

إذا كنت تريد أن يلتف النص داخل الشكل عندما يتجاوز النص حدود الشكل (العرض فقط)، عليك استخدام معلمة **Wrap text in shape**. لتحديد هذا الإعداد، استدعِ الطريقة [setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) بالقيمة `true`.

يظهر هذا الكود JavaScript كيفية استخدام إعداد Wrap Text في عرض PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 
إذا استدعيت طريقة `setWrapText` بالقيمة `False` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، سيمتد النص خارج حدود الشكل على سطر واحد. 
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تؤثر الهوامش الداخلية لإطار النص على AutoFit؟**

نعم. الهوامش الداخلية (Padding) تقلل المساحة المتاحة للنص، لذا سيتدخل AutoFit في وقت أبكر—مقلّصًا الخط أو معدلًا حجم الشكل أسرع. تحقق من الهوامش واضبطها قبل تعديل AutoFit.

**كيف يتفاعل AutoFit مع الفواصل اليدوية واللفائف الناعمة؟**

تبقى الفواصل القسرية في مكانها، ويتكيف AutoFit مع حجم الخط والمسافات حولها. إزالة الفواصل غير الضرورية غالبًا ما يقلل من شدة تقليل النص عبر AutoFit.

**هل يؤثر تغيير خط السمة أو استبدال الخط على نتائج AutoFit؟**

نعم. استبدال الخط بآخر له مقاييس مختلفة يغيّر عرض/ارتفاع النص، مما قد يغيّر الحجم النهائي للخط وتوزيع الأسطر. بعد أي تغيير أو استبدال للخط، أعد فحص الشرائح.