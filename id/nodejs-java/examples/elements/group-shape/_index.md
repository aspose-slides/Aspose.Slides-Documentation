---
title: Bentuk Grup
type: docs
weight: 170
url: /id/nodejs-java/examples/elements/group-shape/
keywords:
- contoh kode
- bentuk grup
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola bentuk berkelompok di Aspose.Slides untuk Node.js: buat, susun, sejajarkan, urutkan kembali, dan ganti gaya bentuk grup dengan contoh pada presentasi PPT, PPTX, dan ODP."
---
Contoh membuat grup bentuk, mengaksesnya, membongkar grup, dan menghapusnya menggunakan **Aspose.Slides for Node.js via Java**.

## **Tambahkan Bentuk Grup**

Buat grup yang berisi dua bentuk dasar.

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

## **Akses Bentuk Grup**

Ambil bentuk grup pertama dari slide.

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

## **Hapus Bentuk Grup**

Hapus bentuk grup dari slide.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Mengasumsikan bahwa bentuk pertama adalah bentuk grup.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Bongkar Grup Bentuk**

Pindahkan bentuk keluar dari kontainer grup.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Mengasumsikan bahwa bentuk pertama adalah bentuk grup.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // Kloni setiap bentuk dari grup ke slide.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```