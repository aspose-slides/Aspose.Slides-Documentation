---
title: Kotak Teks
type: docs
weight: 40
url: /id/nodejs-java/examples/elements/text-box/
keywords:
- contoh kode
- kotak teks
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Bekerja dengan kotak teks di Aspose.Slides untuk Node.js: menambah, memformat, meratakan, membungkus, menyesuaikan otomatis, dan menata teks menggunakan JavaScript untuk presentasi PPT, PPTX, dan ODP."
---
Di Aspose.Slides, sebuah **text box** direpresentasikan oleh `AutoShape`. Hampir semua bentuk dapat berisi teks, tetapi text box tipikal tidak memiliki isian atau batas dan hanya menampilkan teks.

Panduan ini menjelaskan cara menambahkan, mengakses, dan menghapus text box secara programatis.

## **Menambahkan Text Box**

Text box hanyalah `AutoShape` tanpa isian atau batas dan dengan teks yang diformat. Berikut cara membuatnya:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Buat bentuk persegi panjang (default terisi dengan border dan tanpa teks).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Hapus isi dan border agar terlihat seperti kotak teks tipikal.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Atur pemformatan teks.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Tetapkan isi teks yang sebenarnya.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Catatan:** Setiap `AutoShape` yang berisi `TextFrame` yang tidak kosong dapat berfungsi sebagai text box.

## **Mengakses Text Box**

Ambil text box pertama dari slide.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Hanya AutoShape yang dapat berisi teks yang dapat diedit.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Text Box Berdasarkan Konten**

Contoh ini menemukan dan menghapus semua text box pada slide pertama yang berisi kata kunci tertentu:

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

> 💡 **Tip:** Selalu buat salinan koleksi bentuk sebelum memodifikasinya selama iterasi untuk menghindari kesalahan modifikasi koleksi.