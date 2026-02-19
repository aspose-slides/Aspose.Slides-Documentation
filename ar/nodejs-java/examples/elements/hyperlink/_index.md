---
title: الارتباط التشعبي
type: docs
weight: 130
url: /ar/nodejs-java/examples/elements/hyperlink/
keywords:
- مثال على الشيفرة
- ارتباط تشعبي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إضافة وإدارة الارتباطات التشعبية في Aspose.Slides for Node.js: ربط النص، الأشكال، والصور، تعيين الأهداف والإجراءات لملفات PPT و PPTX و ODP مع أمثلة."
---
توضح هذه المقالة إضافة، والوصول إلى، وإزالة، وتحديث الروابط الفائقة على الأشكال باستخدام **Aspose.Slides for Node.js via Java**.

## **إضافة ارتباط تشعبي**

أنشئ شكلاً مستطيلاً يحتوي على ارتباط تشعبي يشير إلى موقع ويب خارجي.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى ارتباط تشعبي**

اقرأ الارتباط التشعبي من جزء النص في الشكل.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // افتراض أن الشكل الأول يحتوي على النص مع الارتباط التشعبي.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة ارتباط تشعبي**

قم بإزالة الارتباط التشعبي من نص الشكل.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // افتراض أن الشكل الأول يحتوي على النص مع الارتباط التشعبي.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **تحديث ارتباط تشعبي**

غيّر الهدف لارتباط تشعبي موجود. استخدم `HyperlinkManager` لتعديل النص الذي يحتوي بالفعل على ارتباط تشعبي، وهو ما يحاكي طريقة تحديث PowerPoint للارتباطات التشعبية بأمان.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // بافتراض أن الشكل الأول يحتوي على النص مع الارتباط التشعبي.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // تغيير الارتباط التشعبي داخل النص الموجود يجب أن يتم عبر
        // HyperlinkManager بدلاً من تعيين الخاصية مباشرة.
        // هذا يحاكي طريقة تحديث PowerPoint للارتباطات التشعبية بأمان.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```