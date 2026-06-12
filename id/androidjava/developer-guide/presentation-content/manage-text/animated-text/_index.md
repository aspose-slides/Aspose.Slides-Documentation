---
title: Animasi Teks PowerPoint di Android
linktitle: Teks Beranimasi
type: docs
weight: 60
url: /id/androidjava/animated-text/
keywords:
- teks beranimasi
- animasi teks
- paragraf beranimasi
- animasi paragraf
- efek animasi
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buat teks beranimasi yang dinamis dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android, dengan contoh kode Java yang mudah diikuti dan dioptimalkan."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan teks beranimasi di Aspose.Slides dengan menerapkan efek animasi pada paragraf individu dan mengambil efek yang sudah ditetapkan pada paragraf dalam sebuah bingkai teks. Fokusnya adalah pada metode API yang digunakan untuk menambahkan animasi tingkat paragraf dan memeriksa efek animasi paragraf yang ada dalam sebuah presentasi.

## **Tambahkan Efek Animasi ke Paragraf**

Kami menambahkan metode [**addEffect()**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) ke kelas [**Sequence**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Sequence) dan [**ISequence**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISequence). Metode ini memungkinkan Anda menambahkan efek animasi ke satu paragraf. Kode contoh berikut menunjukkan cara menambahkan efek animasi ke satu paragraf:

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

## **Dapatkan Efek Animasi pada Paragraf**

Anda mungkin ingin mengetahui efek animasi yang ditambahkan ke sebuah paragraf—misalnya, dalam satu skenario, Anda ingin mengambil efek animasi pada sebuah paragraf karena berencana menerapkan efek tersebut ke paragraf atau bentuk lain.

Aspose.Slides untuk Android via Java memungkinkan Anda mendapatkan semua efek animasi yang diterapkan pada paragraf yang terdapat dalam sebuah bingkai teks (shape). Kode contoh berikut menunjukkan cara mendapatkan efek animasi pada sebuah paragraf:

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

**Bagaimana animasi teks berbeda dari transisi slide, dan dapatkah keduanya digabungkan?**

Animasi teks mengendalikan perilaku objek seiring waktu pada slide, sementara [transitions](/slides/id/androidjava/slide-transition/) mengendalikan cara pergantian slide. Kedua hal ini bersifat independen dan dapat digunakan bersamaan; urutan pemutaran diatur oleh timeline animasi dan pengaturan transisi.

**Apakah animasi teks dipertahankan saat mengekspor ke PDF atau gambar?**

Tidak. PDF dan gambar raster bersifat statis, sehingga Anda akan melihat satu keadaan slide tanpa gerakan. Untuk mempertahankan pergerakan, gunakan ekspor [video](/slides/id/androidjava/convert-powerpoint-to-video/) atau [HTML](/slides/id/androidjava/export-to-html5/).

**Apakah animasi teks bekerja di tata letak dan master slide?**

Efek yang diterapkan pada objek tata letak/master diwariskan ke slide, tetapi timing dan interaksinya dengan animasi pada tingkat slide bergantung pada urutan akhir pada slide tersebut.