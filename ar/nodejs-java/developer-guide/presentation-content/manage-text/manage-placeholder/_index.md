---
title: إدارة العنصر النائب
type: docs
weight: 10
url: /ar/nodejs-java/manage-placeholder/
description: تغيير النص في عنصر نائب في شرائح PowerPoint باستخدام JavaScript. تعيين نص التلميح في عنصر نائب في شرائح PowerPoint باستخدام JavaScript.
---

## **تغيير النص في العنصر النائب**

باستخدام [Aspose.Slides for Node.js via Java](/slides/ar/nodejs-java/)، يمكنك العثور على العناصر النائبة وتعديلها على الشرائح في العروض التقديمية. يتيح لك Aspose.Slides إجراء تغييرات على النص داخل العنصر النائب.

**المتطلب المسبق**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض التقديمي في تطبيق Microsoft PowerPoint القياسي.

هذا هو الطريقة التي تستخدم بها Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض التقديمي:

1. إنشاء كائن من الفئة [`Presentation`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) وتمرير العرض التقديمي كمعامل.
2. احصل على مرجع الشريحة عبر فهرستها.
3. التكرار عبر الأشكال للعثور على العنصر النائب.
4. تحويل نوع شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) وتغيير النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) المرتبط بـ[`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. احفظ العرض التقديمي المعدل.

يظهر هذا الشيفرة JavaScript كيفية تغيير النص في عنصر نائب:
```javascript
// ينشئ فئة Presentation
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // يصل إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // يتكرر عبر الأشكال للعثور على العنصر النائب
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // يغيّر النص في كل عنصر نائب
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // يحفظ العرض التقديمي إلى القرص
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين نص التلميح في العنصر النائب**

تحتوي التخطيطات القياسية والمبنية مسبقًا على نصوص تلميح للعنصر النائب مثل ***Click to add a title*** أو ***Click to add a subtitle***. باستخدام Aspose.Slides، يمكنك إدراج نصوص التلميح المفضلة لديك في تخطيطات العناصر النائبة.

يظهر لك هذا الشيفرة JavaScript كيفية تعيين نص التلميح في عنصر نائب:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // يتكرر عبر الشريحة
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // يعرض PowerPoint "Click to add title"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // يضيف العنوان الفرعي
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين شفافية صورة العنصر النائب**

يتيح لك Aspose.Slides تعيين شفافية الصورة الخلفية في عنصر نائب نصي. من خلال تعديل شفافية الصورة داخل هذا الإطار، يمكنك إبراز النص أو الصورة (اعتمادًا على ألوان النص والصورة).

يوضح لك هذا الشيفرة JavaScript كيفية تعيين شفافية خلفية الصورة (داخل شكل):
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **FAQ**

**ما هو العنصر النائب الأساسي، وكيف يختلف عن الشكل المحلي على الشريحة؟**

العنصر النائب الأساسي هو الشكل الأصلي على تخطيط أو ماستر التي يرث منها شكل الشريحة—النوع، الموقع، وبعض التنسيقات تأتي منه. الشكل المحلي مستقل؛ إذا لم يكن هناك عنصر نائب أساسي، لا يتم تطبيق الوراثة.

**كيف يمكنني تحديث جميع العناوين أو الشروح عبر عرض تقديمي دون التكرار على كل شريحة؟**

قم بتحرير العنصر النائب المقابل على التخطيط أو الماستר. ستورث الشرائح التي تعتمد على تلك التخطيطات/الماستر التغيير تلقائيًا.

**كيف أتحكم في عناصر النائب القياسية للرأس/التذييل—التاريخ والوقت، رقم الشريحة، ونص التذييل؟**

استخدم مديري HeaderFooter في النطاق المناسب (الشرائح العادية، التخطيطات، الماستر، الملاحظات/المطبوعات) لتفعيل أو إلغاء تفعيل تلك العناصر النائبة وتحديد محتواها.