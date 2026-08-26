---
title: إدارة سمات العروض التقديمية في JavaScript
linktitle: سمة العرض
type: docs
weight: 10
url: /ar/nodejs-java/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض
- سمة الشريحة
- تعيين سمة
- تغيير سمة
- إدارة سمة
- سمة خارجية
- THMX
- لون السمة
- لوحة ألوان إضافية
- خط السمة
- نمط السمة
- مؤثر السمة
- PowerPoint
- OpenDocument
- العرض
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في JavaScript باستخدام Aspose.Slides لNode.js لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
## **مقدمة**

يعرّف سمة العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والمؤثرات. تُشير الكائنات التي تدرك السمة إلى هذه التعريفات المشتركة بدلًا من تخزين كل خاصية مرئية كقيمة ثابتة، لذا يمكن لتغيير السمة أن يُحدّث العديد من الكائنات دفعةً واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض عبر الدالة [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getmastertheme/). يمكن أيضًا أن يحتوي العرض على تجاوزات سمة على مستويات أدنى. يمكن للماستر أن يتجاوز سمة العرض عبر الدالة [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterthememanager/)، بينما يمكن للتخطيط أو الشريحة الفردية أن يتجاوز سمتها الموروثة عبر الدالة [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseoverridethememanager/). عمليًا، تُحَلّ السمة الفعّالة لشريحة ما من خلال سلسلة الوراثة هذه: سمة العرض → تجاوز الماستر → تجاوز التخطيط → تجاوز الشريحة.

![مكوّنات السمة: الألوان، الخطوط، أنماط الخلفية، والمؤثرات](theme-constituents.png)

تُظهر الأقسام أدناه أكثر سير عمل شائعًا للسمات: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والمؤثرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/) مخطط ألوان السمة، مخطط الخطوط، ومخطط الصيغ من خلال الدالات [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/). فحص هذه المجموعات قبل تعديلها مفيد خصوصًا عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للسمة ويُبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والمؤثرات المخزنة في السمة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لديها نفس السمة الفعّالة. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعّالة الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات على مستوى التخطيط أو الشريحة.

## **تغيير ألوان السمة**

يمكن للتعبئات، الخطوط، والنصوص التي تدرك السمة الإشارة إلى لون منطقِي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/schemecolor/). عند تغيير الإدخال المقابل في [ColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colorscheme/)، تُحلّ جميع الكائنات التي ما زالت تشير إلى ذلك اللون السُمِّي بالقيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغيّر بتحديث لون السمة.

المثال الشامل التالي ينشئ شكلاً يستخدم `Accent4`، يغيّر لون السمة `Accent4` إلى الأحمر، يحفظ العرض، يعيد فتحه، ويطبع لون التعبئة الفعّال:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

لأن المستطيل لا يزال مرتبطًا بـ `Accent4`، يصبح لونه الظاهر أحمر بعد تغيير السمة. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر على تلك التعبئة.

### **استخدام الألوان من اللوحة الإضافية**

يستخرج PowerPoint تدرجات أفتح وأغمق من لون السمة عبر تطبيق تحويلات الألوان. تُظهر Aspose.Slides هذه التحويلات من خلال تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للسمة والألوان الفاتحة والداكنة المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للسمة.  
**2** - التدرجات الفاتحة والداكنة المستخرجة من الألوان الرئيسية.

المثال التالي ينشئ ستة مستطيلات مبنية على `Accent4`، يطبق تحولات الإضاءة على خمسة منها، ويحفظ النتيجة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تظل هذه التدرجات معتمدة على لون السمة. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المُحَوَّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفتحات `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر تعداد [ColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colorscheme/) نفس الفتحات كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه مجرد أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط السمة**

تحتوي مخططات خطوط السمة على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية للنص الأساسي. تُظهر الدالتان [FontScheme.getMajor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontscheme/) و[FontScheme.getMinor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontscheme/) هاتين المجموعتين.

يمكن استخدام معرفات خطوط السمة المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي (Latin Minor)
* `+mj-lt` - خط العنوان (Latin Major)
* `+mn-ea` - خط نص أسيا الشرقية (East Asian Minor)
* `+mj-ea` - خط عنوان أسيا الشرقية (East Asian Major)

المثال التالي ينشئ عنوانًا يستخدم الخط اللاتيني الرئيسي وخطًا نصيًا يستخدم الخط اللاتيني الثانوي. بعد ذلك يغيّر خطوط السمة ويحفظ النتيجة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يتبع العنوان الخط الرئيسى ويُتبع النص الأساسي الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلًا من معرف السمة لن ينتقل تلقائيًا عندما تتغيّر مخطّط خطوط السمة.

يمكن لمجموعات الخطوط الرئيسى والثانوي أيضًا احتواء تعيينات خطوط لأنظمة كتابة فردية، مثل السيران، العربية، اليابانية، الجورجية، والثانا. لاستعراض، إضافة، استبدال أو إزالة هذه التعيينات، راجع [خطوط السمة الخاصة بالسكريبت](/slides/ar/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="نصيحة" %}}
لمزيد من المعلومات حول خطوط العروض التقديمية، راجع [خطوط PowerPoint](/slides/ar/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

تحلّ سير العمل أدناه مشكلات السمة المختلفة.

### **تطبيق سمة خارجية على الشرائح التابعة لماستر**

استخدم الدالة [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل الشريحة التي تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/)، والتي يُمثّلها [MasterSlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslidecollection/)، ومرّر مسار ملف السمة إلى الدالة.

تُجري الدالة العمليات التالية:

1. إنشاء شريحة ماستر جديدة استنادًا إلى الماستر المختار.  
1. تطبيق السمة الخارجية على الماستر الجديد.  
1. إسناد الماستر الجديد إلى جميع الشرائح التي كانت تعتمد على الماستر المختار مسبقًا.  
1. إرجاع كائن [MasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/) الذي تم إنشاؤه حديثًا.

المثال التالي يطبق سمة خارجية على الشرائح التي تعتمد على الماستر الأول ويحفظ العرض:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قد يتسبب سمة غير صالحة، تالفة، أو غير مدعومة في استثناء [PptxReadException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxreadexception/). تحقق من صحة المسارات التي يقدّمها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد نجاح تطبيق السمة.

يُعاد توجيه الشرائح التي كانت تعتمد على الماستر المختار فقط. الشرائح المرتبطة بماسترات أخرى تحتفظ بماستراتها وسماها الحالية. تُحلّ الألوان، الخطوط، التعبئات، الخطوط، الخلفيات، والمؤثرات التي تدرك السمة وفقًا للسمة الخارجية. قد تبقى الألوان، الخطوط، التعبئات، وغيرها من التنسيقات الصريحة دون تغيير. يمكن لتجاوزات على مستوى التخطيط أو الشريحة أن تتفوّق على القيم الموروثة من الماستر الجديد.

قد تُشير السمة إلى خطوط غير متوفرة في بيئة التشغيل. للتصوير والتصدير المتسقين، ثبّت الخطوط المطلوبة، وفّرها عبر [مصادر الخطوط المخصصة](/slides/ar/nodejs-java/custom-font/)، أو ضبط [استبدال الخطوط](/slides/ar/nodejs-java/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: تقبل الدالة مسار ملف `.thmx` ولا تتطلّب إنشاء تجاوزات سمة على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق سمات خارجية مختلفة في عرض متعدد الماسترات**

عند عدم معرفة الماستر المناسب مسبقًا، احصل عليه من شريحة تمثيلية عبر الدالتين [Slide.getLayoutSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/) و[LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/). احفظ مراجع الماستر الأصلية قبل تطبيق أي سمات لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماستراتهما ويطبق سمة خارجية مختلفة على كل مجموعة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

الاستدعاء الأول يُؤثّر فقط على الشرائح التي كانت تعتمد على `firstGroupMaster`، والاستدعاء الثاني يُؤثّر فقط على الشرائح التي كانت تعتمد على `secondGroupMaster`. الشرائح المرتبطة بأي ماستر آخر لا تُعاد تنسيقها.

### **حفظ سمة المصدر عند نقل الشرائح**

إذا كنت ترغب في نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، انسخ الماستر المصدر إلى العرض الهدف باستخدام الدالة [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslidecollection/)، ثم انسخ الشريحة مع الماستر المنسوخ عبر الدالة [SlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/). سيحمل ذلك الماستر، التخطيطات، والسمة المرتبطة به معًا.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

هذا هو سير العمل المفضّل عندما يجب أن يبدو الشريحة المصدرية كما هي في الوجهة. مجرد نسخ المحتوى إلى ماستر غير مرتبط قد يغيّر الألوان، الخطوط، الخلفيات، والمؤثرات المدفوعة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على الماستر والتخطيط الحاليين، ابدأ بإنشاء تجاوز على مستوى الشريحة من السمة المصدر. الدوال [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/) تنسخ المكوّنات الثلاثة الرئيسية للسمة إلى التجاوز.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

يُغيّر هذا السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ الدالة [OverrideTheme.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/).

### **تطبيق تجاوز سمة على تخطيط**

تطبق التجاوزات على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لديها تجاوز خاص بها. يمكن استعمال نفس دوال التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

استخدم سمة على مستوى الماستر أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوُز التخطيط عندما تحتاج مجموعة تخطيطات واحدة إلى تنسيق مختلف، واستخدم تجاوُز الشريحة فقط للاستثناءات الحقيقية. التعدد المفرط لتجاوزات مستوى الشريحة يجعل التنبؤ بتغييرات السمة العامة لاحقًا أصعب.

## **تحديث أنماط خلفية السمة**

تُخزن تعبئات خلفية السمة في الدالة [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/). يستطيع PowerPoint عرض خيارات خلفية أكثر في واجهته مقارنة بعدد تعريفات التعبئة الفعلية المخزنة في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات السمة مع ألوان السمة وإشارات نمط أخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة والقيمة الحالية للدالة [Background.getStyleIndex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/). فهرس النمط `0` يعني عدم وجود تعبئة سمة؛ القيم الموجبة تشير إلى مراجع أنماط خلفية سمة. هذا يختلف عن فهرسة مجموعة JavaScript مباشرةً، حيث يعني الفهرس `0` العنصر المخزن الأول. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط التعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتاحة، يعيّن مرجع خلفية سمة للماستر الأول، ويحفظ العرض:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة الظاهرة تعتمد على إدخال السمة الذي يشير إليه الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم الدالة [Background.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="تحذير" %}}
لا تتعامل مع فهرس النمط كفهرس مجموعة يبدأ من الصفر. وتجنّب أيضًا الترميز الصلب لرقم نمط من ملف واحد والافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات نمط السمة خاصّة بالعرض.
{{% /alert %}}

{{% alert color="info" title="نصيحة" %}}
لمزيد من التفاصيل حول تنسيق الخلفية المباشر ووراثة الخلفية، راجع [خلفية العرض](/slides/ar/nodejs-java/presentation-background/).
{{% /alert %}}

## **تحديث مؤثرات السمة**

تحتوي مخطّط صيغ السمة على مجموعات منفصلة للتعبئة، الخط، والمؤثرات، تُظهرها الدالات [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/)، و[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/). غالبًا ما تحتوي سمات Office النموذجية على ثلاثة مدخلات رئيسية تمثل بصريًا تنسيقات خفيفة، متوسطة، وشديدة، لكن ينبغي على الشيفرة فحص كل مجموعة بدلاً من الافتراض بوجود عدد ثابت.

![مؤثرات سمة خفيفة، متوسطة، وشديدة مطبَّقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في JavaScript، يكون فهرس المجموعة صفرًا‑مبنيًا: الفهرس `0` هو أول نمط مخزن والفهرس `2` هو الثالث. فهارس مراجع النمط للشكِل مفهوم منفصل، تُظهرها الدالة [ShapeStyle](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تبقى الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود مدخلات الأنماط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يفعّل ظلًا خارجيًا في ثالث نمط مؤثر، ويحفظ النتيجة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

بالنسبة للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط خط سمة أحمر، وثالث نمط تعبئة سمة أخضر غابة صلب، ويضيف الظل الخارجي للمؤثر الثالث مسافة 10 نقاط. لا يزال الناتج البصري يعتمد على الفتحات التي تشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط مؤثرات السمة بعد تعديل الخط، التعبئة، وإعدادات الظل](presentation-design_11.png)

## **قراءة قيم السمة الفعّالة**

تُخبرك كائنات السمة الخام ما تم تعريفه على مستوى معيّن. تُظهر القيم الفعّالة ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. للشريحة، استدعِ الدالة [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/)، وللتعبئة استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/).

المثال التالي يقرأ السمة الفعّالة، الخلفية، وتعبئة الشكل الأول من شريحة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

استخدم البيانات الفعّالة لتشخيص العرض، التحقق، والمقارنات. إذا قمت بفحص فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getmastertheme/)، قد تغفل عن تجاوز ماستر، تخطيط، شريحة، أو شكل يغيّر المظهر النهائي.

## **أسئلة شائعة**

**هل يؤثر تطبيق سمة خارجية على كل شريحة في العرض؟**  
لا. الدالة [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/) تعيد تعيين الشرائح التي تعتمد فقط على الماستر المحدد. الشرائح التي تستخدم ماسترات أخرى تحتفظ بسماها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**  
نعم. استخدم مدير سمة الشريحة [SlideThemeManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidethememanager/) وابدأ تجاوُزه السمة. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة سماها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**  
عند نقل شريحة مع الحفاظ على مظهرها الأصلي، انسخ الماستر المصدر إلى الوجهة باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslidecollection/)، ثم انسخ الشريحة مع ذلك الماستر عبر [SlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/). سيحافظ هذا على الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**  
استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseoverridethememanager/) لسمة شريحة أو تخطيط، واستخدم الدالات الفعّالة المقابلة للكائنات مثل [Background.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/). تُرجع هذه الـ APIs القيم المُستخرجة بعد تطبيق الوراثة والتجاوزات.