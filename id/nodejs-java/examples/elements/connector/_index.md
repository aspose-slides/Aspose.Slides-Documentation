---
title: Konektor
type: docs
weight: 190
url: /id/nodejs-java/examples/elements/connector/
keywords:
- contoh kode
- Konektor
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menambahkan, mengarahkan, dan memberi gaya konektor antara bentuk menggunakan Aspose.Slides untuk Node.js, dengan contoh JavaScript untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menghubungkan bentuk dengan konektor dan mengubah targetnya menggunakan **Aspose.Slides for Node.js via Java**.

## **Tambah Konektor**

Sisipkan bentuk konektor di antara dua titik pada slide.

```js
function addConnector() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        presentation.save("connector.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Konektor**

Ambil bentuk konektor pertama yang ditambahkan ke slide.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Akses konektor pertama pada slide.
        let connector = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                connector = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Konektor**

Hapus konektor dari slide.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Anggap bahwa bentuk pertama adalah konektor dan hapus itu.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Sambungkan Ulang Bentuk**

Lampirkan konektor ke dua bentuk dengan menetapkan target awal dan akhir.

```js
function reconnectShapes() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 50, 50);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```