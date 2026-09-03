---
title: Kelola Kotak Teks dalam Presentasi Menggunakan JavaScript
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/nodejs-java/manage-textbox/
keywords:
- kotak teks
- bingkai teks
- tambahkan teks
- perbarui teks
- buat kotak teks
- periksa kotak teks
- tambahkan kolom teks
- tambahkan tautan hiperteks
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat, identifikasi, format, dan perbarui kotak teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js via Java."
---
## **Pendahuluan**

Dalam Aspose.Slides untuk Node.js via Java, teks slide disimpan dalam bingkai teks yang merupakan bagian dari shape. Kelas [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) mewakili shape paling umum yang berisi teks dan menampilkan teksnya melalui metode [AutoShape.getTextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Catatan" %}}
Setiap auto shape diturunkan dari [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/), tetapi tidak semua shape adalah auto shape atau mendukung bingkai teks. Saat memproses presentasi yang ada, periksa bahwa sebuah shape merupakan instance dari [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) sebelum mengakses teksnya.
{{% /alert %}}

## **Buat Kotak Teks pada Slide**

Untuk membuat kotak teks, tambahkan auto shape ke slide, tambahkan teks ke bingkai teksnya, dan simpan presentasi. Contoh berikut membuat kotak teks berbentuk persegi panjang:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Koordinat dan dimensi yang diberikan ke [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/#addAutoShape) diukur dalam poin. [AutoShape.addTextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/#addTextFrame) menginisialisasi bingkai teks dengan teks yang diberikan.

## **Periksa Shape Kotak Teks**

Gunakan metode [AutoShape.isTextBox](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/#isTextBox) untuk menentukan apakah sebuah auto shape diperlakukan sebagai kotak teks. Ini berguna ketika sebuah presentasi berisi baik auto shape yang berisi teks maupun yang hanya grafis.

![Kotak teks dan sebuah shape](istextbox.png)

Contoh berikut memeriksa setiap auto shape dalam sebuah presentasi:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Auto shape yang baru ditambahkan tidak dianggap sebagai kotak teks sampai mengandung teks yang tidak kosong. Anda dapat menyediakan teks tersebut melalui [AutoShape.addTextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/#addTextFrame) atau [TextFrame.setText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#setText). Menambahkan atau menetapkan string kosong membuat [AutoShape.isTextBox](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/#isTextBox) mengembalikan `false`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Dua panggilan pertama mencetak `true`; dua panggilan terakhir mencetak `false`.

## **Temukan Shape yang Memiliki Bingkai Teks**

Kode pemrosesan teks generik mungkin menerima sebuah [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) tanpa mengetahui objek presentasi mana yang memilikinya. Gunakan metode read-only [TextFrame.getParentShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentShape) untuk menavigasi kembali ke [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) pemiliknya.

Untuk bingkai teks yang dimiliki oleh auto shape atau shape lain yang berisi teks, [TextFrame.getParentShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentShape) mengembalikan pemiliknya dan [TextFrame.getParentCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentCell) mengembalikan `null`. Periksa nilai yang dikembalikan sebelum mengaksesnya. Untuk mengidentifikasi baik pemilik shape maupun sel tabel, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/nodejs-java/search-and-replace-text/).

## **Tambah Kolom ke Kotak Teks**

Metode [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setColumnCount) membagi bingkai teks menjadi kolom, sementara [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) mengatur jarak antar kolom dalam poin. Kedua pengaturan tersebut milik [TextFrameFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/) dan dapat diubah melalui bingkai teks dari kotak teks yang ada. Teks akan mengalir ulang antar kolom di dalam shape yang sama; tidak melanjutkan ke shape lain.

Contoh berikut membuat kotak teks dengan tiga kolom dengan jarak 10 poin antar kolom, menyimpan presentasi, dan membaca kembali pengaturan yang disimpan dari file output:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Ekstrak Teks dari Setiap Kolom**

Gunakan [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#splitTextByColumns) untuk mengambil teks yang ditetapkan ke setiap kolom visual dalam bingkai teks yang ada. Metode ini mengembalikan satu string untuk setiap kolom, dalam urutan baca berdasarkan kolom. Bingkai teks satu kolom menghasilkan array dengan satu elemen, dan kolom kosong direpresentasikan dengan string kosong. String berisi hanya teks polos; pemformatan pada tingkat bagian tidak dipertahankan.

Ini berguna ketika Anda perlu:

- Mengekstrak teks sambil mempertahankan urutan baca berbasis kolom.
- Mengindeks atau membandingkan konten slide multi-kolom.
- Mengekspor setiap kolom ke file terpisah, field basis data, atau tujuan lain.
- Memeriksa bagaimana teks didistribusikan kembali setelah mengubah jumlah kolom dengan [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setColumnCount), jarak dengan [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), font, atau ukuran bingkai teks.

Metode ini melaporkan teks yang didistribusikan dalam [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) saat ini; tidak otomatis mengalirkan teks antar shape atau kotak teks yang terpisah. Distribusi kolom dapat bergantung pada font yang tersedia dan pengaturan tata letak teks lainnya, jadi pastikan font yang diperlukan tersedia ketika hasil yang konsisten penting.

Contoh berikut memuat sebuah presentasi, menemukan auto shape multi-kolom pertama dengan bingkai teks, membaca jumlah kolom yang dikonfigurasikan, dan menulis teks dari setiap kolom ke file terpisah. Shape yang tidak menyediakan bingkai teks akan dilewati.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Perbarui Teks**

Untuk memperbarui teks dalam seluruh presentasi, iterasi melalui slide dan shape, pilih auto shape, lalu edit bagian teksnya. Bekerja pada tingkat bagian memungkinkan Anda mengubah baik teks maupun pemformatan karakter.

Contoh berikut mengganti setiap kemunculan `years` dengan `months` dalam teks auto-shape dan membuat setiap bagian yang terpengaruh menjadi tebal:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Penelusuran ini memperbarui teks hanya pada auto shape. Teks yang disimpan dalam tabel, diagram, SmartArt, atau shape yang dikelompokkan memerlukan penelusuran pada koleksi objek tersebut masing-masing.

## **Tambah Kotak Teks dengan Tautan Hiper**

Tautan hiperteks dapat diberikan kepada bagian teks tertentu, sehingga hanya teks itu yang berfungsi sebagai tautan yang dapat diklik. Gunakan [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) untuk mengaitkan bagian tersebut dengan URL eksternal.

Contoh berikut membuat teks bertautan dan menyimpannya ke sebuah presentasi:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks pada slide master atau layout?**

Sebuah [placeholder](/slides/id/nodejs-java/manage-placeholder/) dapat mewarisi posisi dan pemformatannya dari sebuah [master slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/) atau [layout slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/). Kotak teks biasa adalah shape independen pada slide tempat ia dibuat dan tidak memperoleh perilaku placeholder ketika tata letak berubah.

**Bagaimana saya dapat mengganti teks tanpa mengubah teks pada diagram, tabel, atau SmartArt?**

Batasi penelusuran hanya pada shape yang merupakan instance dari [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/), seperti yang ditunjukkan pada contoh Perbarui Teks. Diagram, tabel, dan SmartArt menyimpan teks dalam model objek mereka masing-masing, sehingga tidak diubah oleh loop tersebut.