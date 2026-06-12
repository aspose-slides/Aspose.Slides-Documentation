---
title: Animasi Teks PowerPoint dalam Java
linktitle: Teks Beranimasi
type: docs
weight: 60
url: /id/java/animated-text/
keywords:
- teks animasi
- animasi teks
- paragraf animasi
- animasi paragraf
- efek animasi
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Buat teks animasi dinamis dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Java, dengan contoh kode Java yang mudah diikuti dan dioptimalkan."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan teks animasi di Aspose.Slides dengan menerapkan efek animasi pada paragraf individual dan mengambil efek yang sudah ditetapkan pada paragraf dalam sebuah bingkai teks. Fokusnya adalah pada metode API yang digunakan untuk menambahkan animasi tingkat paragraf dan memeriksa efek animasi paragraf yang sudah ada dalam presentasi.

## **Menambahkan Efek Animasi ke Paragraf**

Kami menambahkan metode [**addEffect()**](https://reference.aspose.com/slides/id/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) ke kelas [**Sequence**](https://reference.aspose.com/slides/id/java/com.aspose.slides/Sequence) dan [**ISequence**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISequence). Metode ini memungkinkan Anda menambahkan efek animasi ke satu paragraf. Kode contoh berikut menunjukkan cara menambahkan efek animasi ke satu paragraf:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // pilih paragraf untuk menambahkan efek
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // tambahkan efek animasi Fly ke paragraf yang dipilih
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Mendapatkan Efek Animasi Paragraf**

Anda mungkin ingin mengetahui efek animasi yang ditambahkan ke sebuah paragraf—misalnya, dalam satu skenario, Anda ingin mendapatkan efek animasi dalam sebuah paragraf karena Anda berencana menerapkan efek tersebut ke paragraf atau bentuk lain.

Aspose.Slides untuk Java memungkinkan Anda mendapatkan semua efek animasi yang diterapkan pada paragraf yang terdapat dalam bingkai teks (bentuk). Kode contoh berikut menunjukkan cara mendapatkan efek animasi dalam sebuah paragraf:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**Bagaimana animasi teks berbeda dari transisi slide, dan apakah keduanya dapat digabungkan?**

Animasi teks mengontrol perilaku objek seiring waktu pada sebuah slide, sementara [transitions](/slides/id/java/slide-transition/) mengontrol cara pergantian slide. Kedua hal tersebut independen dan dapat digunakan bersamaan; urutan pemutaran diatur oleh garis waktu animasi dan pengaturan transisi.

**Apakah animasi teks dipertahankan saat mengekspor ke PDF atau gambar?**

Tidak. PDF dan gambar raster bersifat statis, sehingga Anda akan melihat satu keadaan slide tanpa gerakan. Untuk mempertahankan pergerakan, gunakan ekspor ke [video](/slides/id/java/convert-powerpoint-to-video/) atau [HTML](/slides/id/java/export-to-html5/).

**Apakah animasi teks berfungsi di tata letak dan master slide?**

Efek yang diterapkan pada objek tata letak/master diwariskan ke slide, namun waktu dan interaksinya dengan animasi tingkat slide tergantung pada urutan akhir di slide.