---
title: صورة
type: docs
weight: 50
url: /ar/nodejs-java/examples/elements/picture/
keywords:
- مثال برمجي
- صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "العمل مع الصور في Aspose.Slides for Node.js: إدراج، قص، ضغط، إعادة تلوين، وتصدير الصور مع أمثلة لعروض PPT و PPTX و ODP."
---
تُظهر هذه المقالة كيفية إدراج الصور والوصول إليها باستخدام **Aspose.Slides for Node.js via Java**. تقوم الأمثلة أدناه بقراءة صورة من ملف، ووضعها على شريحة، ثم استرجاعها.

## **إضافة صورة**
يقوم هذا الكود بقراءة صورة من ملف وإدراجها كإطار صورة على الشريحة الأولى.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // إدراج إطار صورة يعرض الصورة على الشريحة الأولى.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى صورة**
يتأكد هذا المثال من أن الشريحة تحتوي على إطار صورة ثم يصل إلى أول إطار يجدها.

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```