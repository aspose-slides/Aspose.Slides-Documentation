---
title: "إدارة سمات العروض التقديمية في JavaScript"
linktitle: "سمة العرض التقديمي"
type: docs
weight: 10
url: /ar/nodejs-java/presentation-theme/
keywords:
- "سمة PowerPoint"
- "سمة العرض التقديمي"
- "سمة الشريحة"
- "تعيين سمة"
- "تغيير سمة"
- "إدارة سمة"
- "لون السمة"
- "لوحة ألوان إضافية"
- "خط السمة"
- "نمط السمة"
- "تأثير السمة"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "تحكم في سمات العروض التقديمية في JavaScript باستخدام Aspose.Slides لـ Node.js لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتناسقة."
---
تحدد سمة العرض خصائص عناصر التصميم. عند اختيار سمة عرض، فأنت في الواقع تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، تتكون السمة من الألوان، [الخطوط](/slides/ar/nodejs-java/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/nodejs-java/presentation-background/)، والتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان للعناصر المختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تعديلها بتطبيق ألوان جديدة للسمة. لتحديد لون سمة جديد، توفر Aspose.Slides قيمًا تحت تعداد [SchemeColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SchemeColor).

هذا الكود JavaScript يوضح لك كيفية تغيير لون التمييز لسمة:

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

يمكنك تحديد القيمة الفعلية للون الناتج بهذه الطريقة:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

لتوضيح عملية تغيير اللون بشكل أكبر، ننشئ عنصرًا آخر ونعيّن له لون التمييز (من العملية الأولية). ثم نغيّر اللون في السمة:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

يتم تطبيق اللون الجديد تلقائيًا على العنصرين.

### **تعيين لون السمة من لوحة الألوان الإضافية**

عند تطبيق تحويلات الإضاءة على لون السمة الرئيسي(1)، تتشكل ألوان من لوحة الألوان الإضافية(2). يمكنك بعد ذلك تعيين تلك الألوان والحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية  
**2** - ألوان من اللوحة الإضافية.

هذا الكود JavaScript يوضح عملية الحصول على ألوان لوحة إضافية من لون السمة الرئيسي واستخدامها في الأشكال:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // تمييز 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // تمييز 4, أفتح 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // تمييز 4, أفتح 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // تمييز 4, أفتح 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // تمييز 4, أغمق 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // تمييز 4, أغمق 50%
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

### **تخطيط `SchemeColor` إلى ألوان `ColorScheme`**

عند العمل مع [SchemeColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/schemecolor/)، قد تلاحظ أنه يحتوي على قيم ألوان السمة التالية:

`Background1`، `Background2`، `Text1`، و`Text2`.

ومع ذلك، `Presentation.getMasterTheme().getColorScheme()` يرجع [ColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colorscheme/)، الذي يعرض الألوان المقابلة كـ:

`Dark1`، `Dark2`، `Light1`، و`Light2`.

الفرق هذا فقط في التسمية. هذه القيم تشير إلى نفس فتحات ألوان السمة والربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

لا يوجد تحويل ديناميكي بين `Text`/`Background` و`Dark`/`Light`. إنها مجرد أسماء بديلة لنفس ألوان السمة.

هذا الاختلاف في التسمية يأتي من مصطلحات Microsoft Office. النسخ القديمة من Office استخدمت `Dark 1`، `Light 1`، `Dark 2`، و`Light 2`، بينما النسخ الحديثة تعرض نفس الفتحات كـ `Text 1`، `Background 1`، `Text 2`، و`Background 2`.

## **تغيير خط السمة**

للسماح لك باختيار الخطوط للسمة ولأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط الجسم اللاتيني (Minor Latin Font)
* **+mj-lt** - خط العنوان اللاتيني (Major Latin Font)
* **+mn-ea** - خط الجسم الآسيوي الشرقي (Minor East Asian Font)
* **+mj-ea** - خط الجسم الآسيوي الشرقي (Major East Asian Font)

هذا الكود JavaScript يوضح لك كيفية تعيين الخط اللاتيني لعناصر السمة:

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

هذا الكود JavaScript يوضح لك كيفية تغيير خط سمة العرض:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية معرفة مسبقًا ولكن يتم حفظ 3 منها فقط في العرض النموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تنفيذ هذا الكود JavaScript لمعرفة عدد الخلفيات المعرفة مسبقًا في العرض:

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
باستخدام الخاصية [BackgroundFillStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/FormatScheme)، يمكنك إضافة أو الوصول إلى نمط الخلفية في سمة PowerPoint.
{{% /alert %}} 

هذا الكود JavaScript يوضح لك كيفية تعيين الخلفية لعرض تقديمي:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**دليل الفهرس**: 0 يُستخدم لعدم الملء. يبدأ الفهرس من 1.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/nodejs-java/presentation-background/).
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما تحتوي سمة PowerPoint على 3 قيم لكل مصفوفة نمط. يتم دمج تلك المصفوفات في هذه التأثيرات الثلاثة: خفيف، متوسط، وشديد. على سبيل المثال، هذه هي النتيجة عند تطبيق التأثيرات على شكل محدد:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/FormatScheme#getFillStyles--)، [LineStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/FormatScheme#getLineStyles--)، [EffectStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/FormatScheme) يمكنك تغيير العناصر في السمة (أكثر مرونة من الخيارات المتاحة في PowerPoint).

هذا الكود JavaScript يوضح لك كيفية تغيير تأثير السمة عن طريق تعديل أجزاء من العناصر:

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

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير السمة الأصلية؟**  
نعم. تدعم Aspose.Slides تجاوزات سمة على مستوى الشريحة، بحيث يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على سمة الأصل (من خلال [SlideThemeManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟**  
استخدم [استنساخ الشرائح](/slides/ar/nodejs-java/clone-slides/) مع سمة الأصل إلى العرض المستهدف. هذا يحافظ على الأصل، وتخطيطات، والسمة المرتبطة بحيث يبقى المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعّالة" بعد كل الوراثة والتجاوزات؟**  
استخدم واجهات الـ API التي تُظهر القيم ["الفعّالة"](/slides/ar/nodejs-java/shape-effective-properties/) للسمة/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص النهائية المحلولة بعد تطبيق الأصل وأي تجاوزات محلية.