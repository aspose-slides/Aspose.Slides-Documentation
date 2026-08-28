---
title: إدارة سمات العرض في JavaScript
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
- لوحة إضافية
- خط السمة
- نمط السمة
- مؤثر السمة
- PowerPoint
- OpenDocument
- عرض
- Node.js
- JavaScript
- Aspose.Slides
description: "إتقان سمات العروض في JavaScript باستخدام Aspose.Slides لـ Node.js لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
## **مقدمة**

يحدد سمة العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والمؤثرات. تشير الكائنات الواعية بالسمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، بحيث يمكن لتغيير السمة تحديث العديد من الكائنات دفعة واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض من خلال [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getmastertheme/). يمكن للعرض أيضًا أن يحتوي على تجاوزات سمة على مستويات أدنى. يمكن للماستر تجاوز سمة العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterthememanager/)، بينما يمكن للتخطيط أو الشريحة الفردية تجاوز سمتها الموروثة عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseoverridethememanager/). عمليًا، يتم حل السمة الفعَّالة لشريحة ما عبر سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكوّنات السمة: الألوان، الخطوط، أنماط الخلفية، والمؤثرات](theme-constituents.png)

تُظهر الأقسام أدناه أكثر تدفقات العمل شيوعًا مع السمة: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والمؤثرات، وقراءة القيم الفعَّالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/) مخطط ألوان السمة، مخطط الخطوط، ومخطط الصيغ عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mastertheme/). فحص هذه المجموعات قبل تعديلها مفيد بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط قد يختلف.

المثال التالي يقرأ خصائص السمة الرئيسية ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والمؤثرات المخزّنة في السمة:

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

إذا كان الملف يستخدم عدة ماستِرات، لا تفترض أن كل شريحة لها نفس السمة الفعَّالة. افحص الماستر المرتبط بالشريحة، واستخدم تدفق عمل السمة الفعَّالة الموضح لاحقًا في هذه المقالة عندما تكون هناك تجاوزات على مستوى التخطيط أو الشريحة.

## **تغيير ألوان السمة**

يمكن للتعبئات، الخطوط، والنصوص الواعية بالسمة الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/schemecolor/). عند تغيير الإدخال المقابل في [ColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colorscheme/)، يتم حل جميع الكائنات التي لا تزال تشير إلى هذا اللون السمة وفق القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير عند تحديث لون السمة.

المثال الشامل التالي ينشئ شكلًا يستخدم `Accent4`، يغيّر لون السمة `Accent4` إلى الأحمر، يحفظ العرض، يعيده، ويطبع لون التعبئة الفعَّال:

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

نظرًا لأن المستطيل يظل مرتبطًا بـ `Accent4`، يصبح لونه الظاهر أحمر بعد تغيير السمة. إذا قمت باستبدال لون المخطط بلون مباشر على الشكل، فلن تؤثر تغييرات لاحقة على `Accent4` على تلك التعبئة.

### **استخدام الألوان من اللوحة الإضافية**

يستمد PowerPoint ألوانًا أفتح وأغمق من لون السمة عبر تطبيق تحولات لونية. تعرض Aspose.Slides هذه التحولات من خلال تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للسمة والألوان الأفتح والأغمق المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للسمة.  
**2** - المتغيرات الأفتح والأغمق المنتجة من الألوان الرئيسية للسمة.

المثال التالي ينشئ ستة مستطيلات تستند إلى `Accent4`، يطبق تحولات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

تبقى هذه المتغيِّرات معتمدة على لون السمة. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المحوَّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفتحات `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يكشف تعداد [ColorScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colorscheme/) عن نفس فتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الت映 هو ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط السمة**

تحتوي مخططات خطوط السمة على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية للنص الأساسي. تكشف طريقتا [FontScheme.getMajor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontscheme/) و[FontScheme.getMinor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontscheme/) عن هاتين المجموعتين.

يمكن استخدام معرفات خطوط سمة متوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي (Latin) (Minor Latin Font)
* `+mj-lt` - خط العنوان (Latin) (Major Latin Font)
* `+mn-ea` - خط النص الأساسي (East Asian) (Minor East Asian Font)
* `+mj-ea` - خط العنوان (East Asian) (Major East Asian Font)

المثال التالي ينشئ عنوانًا يستخدم الخط السمة الرئيسي Latin وخطًا أساسيًا يستخدم الخط السمة الثانوي Latin. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

يتبع العنوان الخط الرئيسي ويتبع النص الأساسي الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف سمة لن ينتقل تلقائيًا عند تغيير مخطط خط السمة.

يمكن لمجموعات الخطوط الرئيسية والثانوية أيضًا أن تحتوي على تعيينات خطوط لأنظمة كتابة فردية، مثل السيريلية، العربية، اليابانية، الجورجية، وثانا. لفحصها أو إضافة أو استبدال أو إزالة هذه التعيينات، راجع [خطوط السمة الخاصة بالسكريبت](/slides/ar/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="نصيحة" %}}
لمزيد من المعلومات حول خطوط العرض، اطّلع على [خطوط PowerPoint](/slides/ar/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

تحل تدفقات العمل أدناه مشكلات مختلفة تتعلق بالسمة.

### **تطبيق سمة خارجية على الشرائح التابعة للماستر**

استخدم [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/)، والتي تمثّلها [MasterSlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslidecollection/)، ومرّر مسار ملف السمة إلى الطريقة.

تنفّذ الطريقة العمليات التالية:

1. تنشئ شريحة ماستر جديدة بناءً على الماستر المحدد.  
2. تطبق السمة الخارجية على الماستر الجديد.  
3. تُعيّن الماستر الجديد إلى جميع الشرائح التي كانت تعتمد مسبقًا على الماستر المحدد.  
4. تُعيد كائن [MasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/) الجديد.

المثال التالي يطبق سمة خارجية على الشرائح التي تعتمد على أول ماستر ويحفظ العرض:

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

قد يتسبب سمة غير صالحة أو تالفة أو غير مدعومة في حدوث [PptxReadException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxreadexception/). تحقق من صحة المسارات التي يزوّدها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق السمة بنجاح.

يُعاد تعيين الشرائح التي كانت تعتمد على الماستر المحدد فقط. الشرائح المرتبطة بماسترات أخرى تحتفظ بالماسترات والسِّمات الحالية. تُحل الألوان، الخطوط، التعبئات، الخطوط، الخلفيات، والمؤثرات الواعية بالسمة مقابل السمة الخارجية. قد تظل الألوان، الخطوط، التعبئات، وغيرها من التنسيقات الصريحة غير متغيّرة. يمكن لتجاوزات مستوى التخطيط أو الشريحة أيضًا أن تتفوق على القيم الموروثة من الماستر الجديد.

قد تشير السمة إلى خطوط غير متوفرة في بيئة التنفيذ. لضمان التمثيل الصحيح والتصدير، ثبّت الخطوط المطلوبة، أو وفّرها عبر [مصادر الخطوط المخصَّصة](/slides/ar/nodejs-java/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/nodejs-java/font-substitution/).

هذا هو تدفق عمل على مستوى الماستر مباشرة: تقبل الطريقة مسار ملف `.thmx` ولا تتطلّب إنشاء تجاوزات سمة على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق سمات خارجية مختلفة في عرض متعدد الماسترات**

عندما لا يكون الماستر المناسب معروفًا مسبقًا، احصل عليه من شريحة تمثيلية عبر [Slide.getLayoutSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/) و[LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي سمات لأن كل استدعاء ينشئ ماسترًا آخر في العرض.

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

الاستدعاء الأول يؤثر فقط على الشرائح التي تعتمد على `firstGroupMaster`، والثاني يؤثر فقط على الشرائح التي تعتمد على `secondGroupMaster`. الشرائح التي تنتمي إلى أي ماستر آخر لا تُعاد تنسيقها.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslidecollection/)، ثم استنسخ الشريحة باستخدام [SlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/) مع الماستر المستنسخ. هذا يحمل الماستر، وتخطيطاته، والسمة المرتبطة معًا.

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

هذا هو تدفق العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى على ماستر غير متعلق بالوجهة قد يغيّر الألوان، الخطوط، الخلفيات، والمؤثرات التي تقودها السمة.

### **تطبيق قيم سمة على شريحة موجودة**

إذا كان يجب أن تبقى الشريحة المستهدفة على ماسترها وتخطيطها الحاليين، ابدئ تجاوزًا على مستوى الشريحة من سمة المصدر. تنسخ طرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/) المكوِّنات الثلاثة الرئيسية للسمة إلى التجاوز.

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

يُغيّر هذا السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/overridetheme/).

### **تطبيق تجاوز سمة على تخطيط**

يتطبيق التجاوز على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لها تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslidethememanager/):

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

استخدم سمة على مستوى الماستر أو العرض عندما يجب أن تتشارك العديد من التخطيطات والشرائح نفس التصميم الأساسي، واستخدم تجاوز تخطيط عندما تحتاج مجموعة تخطيطات واحدة إلى تنسيق مختلف، واستخدم تجاوز شريحة فقط في حالات الاستثناء الحقيقية. تجعل التجاوزات المتعددة على مستوى الشريحة تغييرات السمة العامة لاحقًا أصعب في التنبؤ.

## **تحديث أنماط خلفية السمة**

تُخزن تعبئات خلفية السمة في [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/). يمكن لـ PowerPoint عرض عدد أكبر من خيارات الخلفية في واجهته مقارنة بعدد تعريفات التعبئة المخزنة فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات السمة مع ألوان السمة وإشارات نمطية أخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/) الحالي. فهرس النمط `0` يعني عدم وجود تعبئة سمة؛ القيم الموجبة تمثل مراجع أنماط خلفية سمة. هذا مختلف عن فهرسة مجموعة JavaScript مباشرةً، حيث يعني الفهرس `0` أول عنصر مخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتوفرة، يعيّن مرجع خلفية سمة للماستر الأول، ويحفظ العرض:

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

تعتمد النتيجة الظاهرة على إدخال السمة الذي يشار إليه الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا كانت شريحة تستخدم خلفية خاصة بها، قد لا يغيّر تغيير خلفية الماستر فقط تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="تحذير" %}}
لا تُعامل فهرس النمط كفهرس مجموعة يبدأ من الصفر. واحذر من ترميز رقم نمط من ملف واحد وافتراض أن له نفس المظهر في ملف آخر؛ تعريفات نمط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="نصيحة" %}}
لمزيد من المعلومات حول تنسيق الخلفية المباشر ووراثة الخلفية، راجع [خلفية العرض](/slides/ar/nodejs-java/presentation-background/).
{{% /alert %}}

## **تحديث مؤثرات السمة**

يحتوي مخطط صيغ السمة على مجموعات منفصلة لتعبئات، خطوط، ومؤثرات يتم كشفها عبر [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/)، و[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/formatscheme/). غالبًا ما تحتوي سمات Office على ثلاثة إدخالات أساسية تتطابق بصريًا مع تنسيقات خفيفة، متوسطة، ومكثفة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![مؤثرات سمة خفيفة، متوسطة، ومكثفة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في JavaScript، يكون فهرس المجموعة يبدأ من الصفر: الفهرس `0` هو أول نمط مخزن والفهرس `2` هو الثالث. فهارس مرجع النمط للشكل هي مفهوم منفصل، يُكشف عبر [ShapeStyle](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود إدخالات النمط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يُفعّل ظلًا خارجيًا في النمط الثالث للمؤثر، ويحفظ النتيجة:

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

بالنسبة للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط خط سمة أحمر، والثالث نمط تعبئة سمة أخضر غامق صلب، وتكتسب نمط المؤثر الثالث ظلًا خارجيًا بمسافة 10 نقاط. لا يزال المظهر النهائي يعتمد على الفتحات التي تشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط مؤثرات السمة بعد تغيير إعدادات الخط، التعبئة، والظل](presentation-design_11.png)

## **تحديد ما إذا كانت تعبئة صلبة فعَّالة تستخدم لون سمة**

يمكن تخزين تعبئة إما مباشرةً على كائن أو موروثة من فقرة، تخطيط، ماستر، نمط سمة، أو مستوى تنسيق آخر. استدعِ [FillFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/) لحل تلك السلسلة إلى لقطة تعبئة صلبة ثابتة. أولاً تحقق من قيمة `getFillType`. فقط عندما تكون `FillType.Solid` ينبغي قراءة خصائص التعبئة الصلبة.

للتعبئة الصلبة، تُعيد `getSolidFillColor` القيمة النهائية RGB بعد تطبيق الوراثة، وlookup السمة، والتحولات اللونية. تُعيد طريقة `getSolidFillSchemeColor` الفتحة المنطقية في تعداد [SchemeColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/schemecolor/)، مثل `Text1` أو `Accent6`. قيمة `SchemeColor.NotDefined` تعني أن التعبئة الصلبة الفعَّالة ليست مبنية على لون مخطط. في تدفق عمل حيث تكون التعبئات إما ألوان سمة أو ألوان RGB مباشرة، تُعرّف هذه القيمة تعبئة RGB مباشرة.

لا تستخدم قيمة [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colorformat/) المحلية وحدها لتصنيف تعبئة. على سبيل المثال، قد لا يحتوي مقطع نص على لون مخطط معرف محليًا، لذا تكون قيمته المحلية `NotDefined`، بينما تُورث تعبئته الفعَّالة لون سمة وتُحل إلى `Text1` أو `Accent6`. بالمقابل، تُخبرك `getSolidFillSchemeColor` أي فتحة منطقية للسمة أنتجت اللون الفعَّال، لكنها لا تخبرك ما إذا كانت تلك الفتحة جاءت من الكائن، الفقرة، التخطيط، الماستر، أو مستوى تنسيق آخر.

المثال التالي يحمل عرضًا، يراجع تعبئات الأشكال وتعبئات مقاطع النص، يطبع كل قيمة RGB نهائية واللون المخطط المرتبط، ويُظهر التعبئات الصلبة التي لن تتتبع تغييرات ألوان السمة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

يقدم الفرع `NotDefined` قائمة تدقيق للتعبئات الصلبة التي لن تستجيب لتغييرات فتحات ألوان السمة. راجع تلك الكائنات عندما يجب أن يتبع العرض لوحة ألوان علامة تجارية جديدة. لا يزال قيمة RGB المعروضة تُظهر المظهر الحالي، بينما يوضح قيمة المخطط ما إذا كان هذا المظهر مرتبطًا بالسمة.

الكائنات الفعَّالة هي لقطات. بعد تغيير سمة العرض، أو تجاوز سمة، أو أي تنسيق موروث، استدعِ `getEffective` مرة أخرى واقرأ كائن تعبئة فعَّال جديد قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم السمة الفعَّالة**

تخبرك كائنات السمة الخام بما هو معرف على مستوى معين. تُظهر القيم الفعَّالة ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. للشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/)، وللتعبئة، استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/).

المثال التالي يقرأ السمة الفعَّالة، الخلفية، وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعَّالة للتشخيصات الرسومية، التحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getmastertheme/)، قد تفوتك تجاوزات ماستر أو تخطيط أو شريحة أو شكل تغير المظهر النهائي.

## **أسئلة شائعة**

**هل يؤثر تطبيق سمة خارجية على كل شريحة في العرض؟**

لا. تُعيد [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/) تعيين الشرائح التي تعتمد فقط على الماستر المحدد. الشرائح التي تستخدم ماسترات أخرى تحتفظ بسِماتها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidethememanager/) للشريحة وابدأ سمة تجاوزها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslidecollection/) و[SlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/). يضمن هذا بقاء الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعَّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseoverridethememanager/) لسمة شريحة أو تخطيط، والطُرُق المقابلة للبيانات الفعَّالة لكائنات الصيغة مثل [Background.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المحلولة بعد تطبيق الوراثة والتجاوزات.