---
title: مربع النص
type: docs
weight: 40
url: /ar/nodejs-java/examples/elements/text-box/
keywords:
- مثال على الكود
- مربع نص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "العمل مع مربعات النص في Aspose.Slides لـ Node.js: إضافة، تنسيق، محاذاة، التفاف، ضبط تلقائي، وتنسيق النص باستخدام JavaScript لعروض PPT و PPTX و ODP."
---
في Aspose.Slides، يتم تمثيل **مربع النص** ب`AutoShape`. يمكن لأي شكل تقريبًا أن يحتوي على نص، لكن مربع النص النموذجي لا يحتوي على تعبئة أو حد ويعرض النص فقط.

يشرح هذا الدليل كيفية إضافة مربعات النص والوصول إليها وإزالتها برمجياً.

## **إضافة مربع نص**

مربع النص هو ببساطة `AutoShape` لا يحتوي على تعبئة أو حد ويحتوي على بعض النص المنسق. إليك كيفية إنشائه:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // إنشاء شكل مستطيل (الإعدادات الافتراضية تعبئة مع حد ولا يحتوي على نص).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // إزالة التعبئة والحد لجعل الشكل يبدو كمربع نص نموذجي.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // تعيين تنسيق النص.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // تعيين محتوى النص الفعلي.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ملاحظة:** أي `AutoShape` يحتوي على `TextFrame` غير فارغ يمكنه العمل كمربع نص.

## **الوصول إلى مربع نص**

استرجع أول مربع نص من الشريحة.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // يمكن فقط لأشكال AutoShape أن تحتوي على نص قابل للتحرير.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة مربعات النص حسب المحتوى**

هذا المثال يقوم بالعثور على جميع مربعات النص في الشريحة الأولى التي تحتوي على كلمة مفتاحية معينة وحذفها:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **نصيحة:** احرص دائمًا على إنشاء نسخة من مجموعة الأشكال قبل تعديلها أثناء التكرار لتجنب أخطاء تعديل المجموعة.