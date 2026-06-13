---
title: شکل گروهی
type: docs
weight: 170
url: /fa/nodejs-java/examples/elements/group-shape/
keywords:
- مثال کد
- شکل گروهی
- پاورپوینت
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت اشکال گروه‌بندی‌شده در Aspose.Slides برای Node.js: ایجاد، تو در تو کردن، تراز کردن، ترتیب دوباره و سبک‌دهی به اشکال گروهی با مثال‌ها در ارائه‌های PPT، PPTX و ODP."
---
نمونه‌هایی برای ایجاد گروه‌های اشکال، دسترسی به آن‌ها، جداسازی و حذف با استفاده از **Aspose.Slides for Node.js via Java**.

## **Add a Group Shape**
یک گروه حاوی دو شکل پایه ایجاد کنید.

```js
function addGroupShape() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 60, 0, 50, 50);

        presentation.save("group_shape.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Group Shape**
شکل گروهی اول را از اسلاید بازیابی کنید.

```js
function accessGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstGroup = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                firstGroup = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Group Shape**
یک شکل گروهی را از اسلاید حذف کنید.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض می‌شود که اولین شکل یک شکل گروهی است.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ungroup Shapes**
اشکال را از مخزن گروه خارج کنید.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض می‌شود که اولین شکل یک شکل گروهی است.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // هر شکل را از گروه به اسلاید کلون می‌کند.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```