---
title: Dapatkan Batas Bagian Teks dari Presentasi dalam JavaScript
linktitle: Batas Bagian
type: docs
weight: 47
url: /id/nodejs-java/portion-bounds/
keywords:
- batas bagian teks
- bagian teks
- potongan teks
- koordinat teks
- posisi teks
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengambil batas bagian teks dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Node.js melalui Java."
---
## **Gambaran Umum**

Sebuah bagian teks mewakili fragmen spesifik teks di dalam sebuah paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara terpisah dari konten di sekitarnya. Di Aspose.Slides, bagian-bagian teks dapat digunakan ketika Anda perlu mengambil batas dari sebuah fragmen teks, menerapkan pemformatan hanya pada sebagian paragraf, atau mengendalikan perilaku teks pada tingkat yang lebih detail.

Artikel ini menunjukkan cara mendapatkan persegi panjang pembatas sebuah bagian dengan menggunakan [Portion.getRect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/getrect/). Artikel ini juga menunjukkan cara mendapatkan koordinat awal sebuah bagian dengan menggunakan [Portion.getCoordinates](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/getcoordinates/). Selain itu, artikel ini menyoroti skenario umum terkait bagian, seperti menerapkan hyperlink pada satu fragmen teks, memahami bagaimana pemformatan diselesaikan melalui hierarki bagian, paragraf, bingkai teks, dan pewarisan tema, serta menangani kasus di mana font yang ditentukan tidak tersedia.

## **Dapatkan Batas Sebuah Bagian Teks**

Gunakan [Portion.getRect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/getrect/) untuk mengambil persegi panjang pembatas sebuah bagian teks:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Dapatkan Koordinat Sebuah Bagian Teks**

Gunakan [Portion.getCoordinates](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/getcoordinates/) untuk mengambil koordinat awal sebuah bagian teks:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat menerapkan hyperlink hanya pada bagian teks dalam satu paragraf?**

Ya, Anda dapat [menetapkan hyperlink](/slides/id/nodejs-java/manage-hyperlinks/) pada sebuah bagian individu; hanya fragmen tersebut yang dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan gaya: apa yang di-override oleh sebuah bagian, dan apa yang diambil dari paragraf atau bingkai teks?**

Properti pada tingkat Bagian memiliki prioritas tertinggi. Jika sebuah properti tidak diatur pada [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/), Aspose.Slides akan mengambilnya dari [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/). Jika tidak diatur di sana juga, Aspose.Slides menggunakan gaya dari [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) atau [theme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/theme/).

**Apa yang terjadi jika font yang ditentukan untuk sebuah bagian tidak tersedia di mesin atau server target?**

[aturan substitusi font](/slides/id/nodejs-java/font-selection-sequence/) berlaku. Teks mungkin mengalami aliran ulang: metrik, hyphenasi, dan lebar dapat berubah, yang penting untuk penempatan yang tepat.

**Apakah saya dapat mengatur transparansi isi teks spesifik untuk bagian atau gradien secara terpisah dari sisa paragraf?**

Ya, warna teks, isi, dan transparansi pada tingkat [Portion] dapat berbeda dari fragmen tetangga.