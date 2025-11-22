---
title: سمة العرض
type: docs
weight: 10
url: /ar/nodejs-java/presentation-theme/
keywords: "السمة, سمة PowerPoint, عرض PowerPoint, جافا, Aspose.Slides لـ Node.js عبر جافا"
description: "سمة عرض PowerPoint في JavaScript"
---

موضوع العرض يعرّف خصائص عناصر التصميم. عندما تختار موضوع عرض، فأنت أساسًا تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، يتكوّن الموضوع من ألوان، [الخطوط](/slides/ar/nodejs-java/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/nodejs-java/presentation-background/)، وتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون الموضوع**

يستخدم موضوع PowerPoint مجموعة محددة من الألوان لعناصر مختلفة في الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة للموضوع. لتحديد لون موضوع جديد، توفر Aspose.Slides قيمًا ضمن تعداد [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SchemeColor).

يعرض لك هذا الكود JavaScript كيفية تغيير لون التمييز للموضوع:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


يمكنك تحديد القيمة الفورية للون الناتج بهذه الطريقة:
```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```


لتوضيح عملية تغيير اللون أكثر، ننشئ عنصرًا آخر ونعيّن له لون التمييز (من العملية الأولية). ثم نغير اللون في الموضوع:
```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


يُطبق اللون الجديد تلقائيًا على العنصرين.

### **تعيين لون الموضوع من لوحة ألوان إضافية**

عند تطبيق تحولات الإضاءة على اللون الأساسي للموضوع(1)، تُنشأ ألوان من لوحة الألوان الإضافية(2). يمكنك بعدها تعيين هذه الألوان والحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان الموضوع الأساسية

**2** - ألوان من لوحة الألوان الإضافية.

يوضح لك هذا الكود JavaScript عملية الحصول على ألوان لوحة الألوان الإضافية من اللون الأساسي للموضوع ثم استخدامها في الأشكال:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // التمييز 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // التمييز 4، أخف 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // التمييز 4، أخف 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // التمييز 4، أخف 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // التمييز 4، أغمق 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // التمييز 4، أغمق 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **تغيير خط الموضوع**

لتمكينك من اختيار الخطوط للمواضيع وأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط النص الأساسي اللاتيني (خط لاتيني أصغر)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني أكبر)
* **+mn-ea** - خط النص الأساسي الآسيوي الشرقي (خط آسيوي شرقي أصغر)
* **+mj-ea** - خط النص الأساسي الآسيوي الشرقي (خط آسيوي شرقي أكبر)

يعرض لك هذا الكود JavaScript كيفية تعيين الخط اللاتيني لعنصر في الموضوع:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```


يعرض لك هذا الكود JavaScript كيفية تغيير خط موضوع العرض:
```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```


سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في الاطّلاع على [خطوط PowerPoint](/slides/ar/nodejs-java/powerpoint-fonts/).

{{% /alert %}}

## **تغيير نمط خلفية الموضوع**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية محددة مسبقًا، لكن يتم حفظ 3 منها فقط في العرض التقديمي المعتاد.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود JavaScript لمعرفة عدد الخلفيات المحددة مسبقًا في العرض:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" %}} 

باستخدام الخاصية [BackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) من الفئة [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme)، يمكنك إضافة أو الوصول إلى نمط الخلفية في موضوع PowerPoint.

{{% /alert %}} 

يعرض لك هذا الكود JavaScript كيفية تعيين خلفية للعرض التقديمي:
```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**دليل الفهرس**: 0 يُستخدم لعدم ملء. يبدأ الفهرس من 1.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في الاطّلاع على [خلفية PowerPoint](/slides/ar/nodejs-java/presentation-background/).

{{% /alert %}}

## **تغيير تأثير الموضوع**

عادةً ما يحتوي موضوع PowerPoint على 3 قيم لكل مجموعة أنماط. تُدمج هذه المجموعات لتُكوّن 3 تأثيرات: خفيف، متوسط، وشديد. على سبيل المثال، هذا هو الناتج عندما تُطبق التأثيرات على شكل محدد:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) من الفئة [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme) يمكنك تغيير عناصر الموضوع (بمرونة أكبر من الخيارات في PowerPoint).

يعرض لك هذا الكود JavaScript كيفية تغيير تأثير الموضوع عن طريق تعديل أجزاء من العناصر:
```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


التغييرات الناتجة في لون التعبئة، نوع التعبئة، تأثير الظل، إلخ:

![todo:image_alt_text](presentation-design_11.png)

## **الأسئلة الشائعة**

**هل يمكنني تطبيق موضوع على شريحة واحدة دون تغيير الرئيس؟**

نعم. تدعم Aspose.Slides تجاوزات موضوع مستوى الشريحة، بحيث يمكنك تطبيق موضوع محلي على تلك الشريحة فقط مع الحفاظ على موضوع الرئيس دون تغيير (من خلال [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل موضوع من عرض إلى آخر؟**

استخدم [استنساخ الشرائح](/slides/ar/nodejs-java/clone-slides/) مع الرئيس الخاص بها إلى العرض الهدف. يحافظ ذلك على الرئيس الأصلي، التخطيطات، والموضوع المرتبط لضمان بقاء المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعلية" بعد كل الوراثة والتجاوزات؟**

استخدم عرض ["الفعلية"](/slides/ar/nodejs-java/shape-effective-properties/) في الواجهة البرمجية للموضوع/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص النهائية المحلّلة بعد تطبيق الرئيس وأي تجاوزات محلية.