---
title: Kelola Bagian Teks dalam Presentasi Menggunakan JavaScript
linktitle: Bagian Teks
type: docs
weight: 70
url: /id/nodejs-java/portion/
keywords:
- bagian teks
- potongan teks
- koordinat teks
- posisi teks
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengelola bagian teks dalam presentasi PowerPoint menggunakan JavaScript dan Aspose.Slides untuk Node.js melalui Java, meningkatkan kinerja dan penyesuaian."
---
## **Gambaran Umum**

Bagian teks mewakili fragmen teks tertentu di dalam sebuah paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara independen dari konten di sekitarnya. Di Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil posisi fragmen teks, menerapkan pemformatan hanya pada sebagian paragraf, atau mengendalikan perilaku teks pada tingkat yang lebih detail.

Artikel ini menunjukkan cara mendapatkan koordinat awal sebuah bagian dengan menggunakan metode `getCoordinates()`. Artikel ini juga menyoroti skenario umum terkait bagian, seperti menerapkan hyperlink pada satu fragmen teks, memahami cara pemformatan diselesaikan melalui inheritance bagian, paragraf, bingkai teks, dan tema, serta menangani kasus di mana font yang ditentukan tidak tersedia. Selain itu, disebutkan bahwa isian teks, warna, dan transparansi dapat diatur secara berbeda untuk setiap bagian dalam paragraf yang sama.

## **Dapatkan Koordinat Posisi Bagian**
[**getCoordinates()**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Portion#getCoordinates--) method telah ditambahkan ke kelas [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) yang memungkinkan mengambil koordinat awal bagian.

```javascript
// Instansiasi kelas Presentation yang mewakili PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Membentuk kembali konteks presentasi
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat menerapkan hyperlink hanya pada sebagian teks di dalam satu paragraf?**

Ya, Anda dapat [assign a hyperlink](/slides/id/nodejs-java/manage-hyperlinks/) ke bagian individual; hanya fragmen itu yang dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan gaya: apa yang di-override oleh Portion, dan apa yang diambil dari Paragraph/TextFrame?**

Properti tingkat Portion memiliki prioritas tertinggi. Jika sebuah properti tidak diatur pada [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/), mesin akan mengambilnya dari [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/); jika tidak diatur di sana juga, maka dari [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) atau gaya [theme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/theme/).

**Apa yang terjadi jika font yang ditentukan untuk sebuah Portion tidak ada di mesin/server target?**

[Font substitution rules](/slides/id/nodejs-java/font-selection-sequence/) diterapkan. Teks dapat mengalir kembali: metrik, hyphenation, dan lebar dapat berubah, yang berpengaruh pada penempatan yang tepat.

**Apakah saya dapat mengatur transparansi atau gradien isian teks khusus untuk Portion secara independen dari paragraf lainnya?**

Ya, warna teks, isian, dan transparansi pada tingkat [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) dapat berbeda dari fragmen yang berdekatan.