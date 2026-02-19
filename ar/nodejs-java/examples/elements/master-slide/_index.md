---
title: شريحة رئيسية
type: docs
weight: 30
url: /ar/nodejs-java/examples/elements/master-slide/
keywords:
- مثال على الكود
- شريحة رئيسية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "استكشف أمثلة الشرائح الرئيسية في Aspose.Slides لـ Node.js: أنشئ، عدّل، وصمّم الشرائح الرئيسية، العناصر النائبة، والسمات في صيغ PPT و PPTX و ODP باستخدام كود واضح."
---
تشكل الشرائح الرئيسية المستوى الأعلى في تسلسل وراثة الشرائح في PowerPoint. **الشريحة الرئيسية** تحدد عناصر التصميم المشتركة مثل الخلفيات والشعارات وتنسيق النص. **شرائح التخطيط** تُورّث من الشرائح الرئيسية، و**الشرائح العادية** تُورّث من شرائح التخطيط.

يُظهر هذا المقال كيفية إنشاء وتعديل وإدارة الشرائح الرئيسية باستخدام Aspose.Slides لـ Node.js عبر Java.

## **إضافة شريحة رئيسية**

يوضح هذا المثال كيفية إنشاء شريحة رئيسية جديدة عن طريق استنساخ الشريحة الافتراضية. ثم يضيف شريط عنوان باسم الشركة إلى جميع الشرائح من خلال وراثة التخطيط.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // استنساخ الشريحة الرئيسية الافتراضية.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // أضف شريطًا بعنوان اسم الشركة إلى أعلى الشريحة الرئيسية.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // تعيين الشريحة الرئيسية الجديدة إلى شريحة تخطيط.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // تعيين شريحة التخطيط إلى الشريحة الأولى في العرض التقديمي.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ملاحظة 1:** توفر الشرائح الرئيسية وسيلة لتطبيق هوية تجارية متسقة أو عناصر تصميم مشتركة عبر جميع الشرائح. أي تغييرات تُجرى على الرئيسية ستنعكس تلقائيًا على تخطيطات الشرائح والشرائح العادية التابعة.
>
> 💡 **ملاحظة 2:** أي أشكال أو تنسيقات تُضاف إلى شريحة رئيسية تُورّث إلى شرائح التخطيط، ومن ثم إلى جميع الشرائح العادية التي تستخدم تلك التخطيطات.
> الصورة أدناه توضح كيف يتم عرض مربع نص مضاف إلى شريحة رئيسية تلقائيًا على الشريحة النهائية.

![مثال وراثة الشريحة الرئيسية](master-slide-banner.png)

## **الوصول إلى شريحة رئيسية**

يمكنك الوصول إلى الشرائح الرئيسية باستخدام مجموعة الشرائح الرئيسية في العرض التقديمي. إليك طريقة استرجاعها والعمل معها:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // تغيير نوع الخلفية.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة شريحة رئيسية**

يمكن إزالة الشرائح الرئيسية إما حسب الفهرس أو بالمرجع.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // إزالة شريحة رئيسية حسب الفهرس.
        presentation.getMasters().removeAt(0);

        // إزالة شريحة رئيسية حسب المرجع.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة الشرائح الرئيسية غير المستخدمة**

بعض العروض التقديمية تحتوي على شرائح رئيسية غير مستخدمة. إزالة هذه الشرائح يمكن أن تساعد في تقليل حجم الملف.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // إزالة جميع الشرائح الرئيسية غير المستخدمة (حتى تلك التي تم وضع علامة Preserve عليها).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```