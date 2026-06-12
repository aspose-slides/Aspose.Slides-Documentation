---
title: Animasi Teks PowerPoint dengan JavaScript
linktitle: Teks Animasi
type: docs
weight: 60
url: /id/nodejs-java/animated-text/
keywords:
- teks animasi
- animasi teks
- paragraf animasi
- animasi paragraf
- efek animasi
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat teks animasi dinamis dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js, dengan contoh kode yang mudah diikuti dan dioptimalkan."
---
## **Gambaran Umum**

Artikel ini menjelaskan bagaimana cara bekerja dengan teks animasi di Aspose.Slides dengan menerapkan efek animasi pada paragraf individu dan mengambil efek yang sudah ditetapkan pada paragraf dalam sebuah bingkai teks. Fokusnya pada metode API yang digunakan untuk menambahkan animasi tingkat paragraf dan memeriksa efek animasi paragraf yang ada dalam presentasi.

## **Menambahkan Efek Animasi ke Paragraf**

Kami menambahkan metode [**addEffect()**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) ke kelas [**Sequence**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Sequence) dan [**Sequence**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Sequence). Metode ini memungkinkan Anda menambahkan efek animasi ke satu paragraf. Kode contoh ini menunjukkan cara menambahkan efek animasi ke satu paragraf:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // pilih paragraf untuk menambahkan efek
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // tambahkan efek animasi Fly ke paragraf yang dipilih
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Mendapatkan Efek Animasi dalam Paragraf**

Anda mungkin ingin mengetahui efek animasi yang ditambahkan ke sebuah paragraf—misalnya, dalam satu skenario, Anda ingin mendapatkan efek animasi dalam paragraf karena Anda berencana menerapkan efek tersebut ke paragraf atau bentuk lain.

Aspose.Slides untuk Node.js via Java memungkinkan Anda mengambil semua efek animasi yang diterapkan pada paragraf yang terdapat dalam bingkai teks (shape). Kode contoh ini menunjukkan cara mendapatkan efek animasi dalam sebuah paragraf:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**Bagaimana perbedaan animasi teks dengan transisi slide, dan dapatkah keduanya digabungkan?**

Animasi teks mengontrol perilaku objek seiring waktu pada sebuah slide, sedangkan [transitions](/slides/id/nodejs-java/slide-transition/) mengontrol cara slide berubah. Kedua fitur tersebut bersifat independen dan dapat digunakan bersamaan; urutan pemutaran diatur oleh garis waktu animasi dan pengaturan transisi.

**Apakah animasi teks dipertahankan saat mengekspor ke PDF atau gambar?**

Tidak. PDF dan gambar raster bersifat statis, jadi Anda akan melihat satu keadaan slide tanpa gerakan. Untuk mempertahankan gerakan, gunakan ekspor [video](/slides/id/nodejs-java/convert-powerpoint-to-video/) atau [HTML](/slides/id/nodejs-java/export-to-html5/).

**Apakah animasi teks berfungsi di tata letak dan master slide?**

Efek yang diterapkan pada objek tata letak/master diwariskan ke slide, tetapi timing dan interaksinya dengan animasi tingkat slide bergantung pada urutan akhir pada slide.