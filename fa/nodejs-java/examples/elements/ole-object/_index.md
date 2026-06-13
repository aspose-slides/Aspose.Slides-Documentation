---
title: شی OLE
type: docs
weight: 210
url: /fa/nodejs-java/examples/elements/ole-object/
keywords:
- مثال کد
- شی OLE
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "در Aspose.Slides برای Node.js، اشیاء OLE را مدیریت کنید: درج، لینک‌گذاری، به‌روزرسانی و استخراج محتویات جاسازی‌شده با JavaScript در ارائه‌های PPT، PPTX و ODP."
---
این مقاله نحوه‌ی درج یک فایل به‌عنوان شی OLE و به‌روزرسانی داده‌های آن را با استفاده از **Aspose.Slides for Node.js via Java** نشان می‌دهد.

## **اضافه کردن شی OLE**

یک فایل PDF را در یک ارائه درج کنید.

```js
function addOleObject() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pdfStream = fs.readFileSync("doc.pdf");
        let pdfData = java.newArray("byte", Array.from(pdfStream));
        let dataInfo = new aspose.slides.OleEmbeddedDataInfo(pdfData, "pdf");
        let oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

        presentation.save("ole_object.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به شی OLE**

قاب اول شی OLE را در یک اسلاید بازیابی کنید.

```js
function accessOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstOleFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IOleObjectFrame")) {
                firstOleFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف شی OLE**

یک شی OLE جاسازی‌شده را از اسلاید حذف کنید.

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض کنید اولین شکل، قاب شی OLE است.
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **به‌روزرسانی داده‌های شی OLE**

داده‌های جاسازی‌شده در یک شی OLE موجود را جایگزین کنید.

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // فرض کنید اولین شکل، قاب شی OLE است.
        let oleFrame = slide.getShapes().get_Item(0);

        let dataStream = fs.readFileSync("picture.png");
        let newData = java.newArray("byte", Array.from(dataStream));
        let dataInfo = new aspose.slides.OleEmbeddedDataInfo(newData, "png");
        oleFrame.setEmbeddedData(dataInfo);

        presentation.save("ole_object_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```