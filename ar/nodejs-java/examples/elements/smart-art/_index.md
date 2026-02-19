---
title: SmartArt
type: docs
weight: 140
url: /ar/nodejs-java/examples/elements/smart-art/
keywords:
- مثال على الكود
- SmartArt
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "العمل مع SmartArt في Aspose.Slides لـ Node.js: إنشاء، تعديل، تحويل، وتنسيق المخططات باستخدام JavaScript لعروض PowerPoint وOpenDocument التقديمية."
---
توضح هذه المقالة كيفية إضافة رسومات SmartArt، والوصول إليها، وإزالتها، وتغيير التخطيطات باستخدام **Aspose.Slides for Node.js via Java**.

## **إضافة SmartArt**

إدراج رسم SmartArt باستخدام أحد التخطيطات المدمجة.

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى SmartArt**

استرجاع أول كائن SmartArt في الشريحة.

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة SmartArt**

حذف شكل SmartArt من الشريحة.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // بافتراض أن الشكل الأول هو SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **تغيير تخطيط SmartArt**

تحديث نوع التخطيط لرسم SmartArt الحالي.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // بافتراض أن الشكل الأول هو SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```