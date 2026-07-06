---
title: Dapatkan Batas Bagian Teks dari Presentasi di Android
linktitle: Batas Bagian
type: docs
weight: 47
url: /id/androidjava/portion-bounds/
keywords:
- batas bagian teks
- bagian teks
- bagian teks
- koordinat teks
- posisi teks
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengambil batas bagian teks dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Android via Java."
---
## **Gambaran Umum**

Bagian teks mewakili fragmen teks spesifik di dalam sebuah paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara terpisah dari konten di sekitarnya. Di Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil batas fragmen teks, menerapkan pemformatan hanya pada sebagian paragraf, atau mengendalikan perilaku teks pada level yang lebih detail.

Artikel ini menunjukkan cara mendapatkan persegi panjang pembatas sebuah bagian dengan menggunakan [IPortion.getRect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPortion#getRect--). Artikel ini juga menunjukkan cara mendapatkan koordinat awal sebuah bagian dengan menggunakan [IPortion.getCoordinates](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPortion#getCoordinates--). Selain itu, artikel ini menyoroti skenario umum terkait bagian, seperti menerapkan hyperlink pada satu fragmen teks, memahami cara pemformatan diselesaikan melalui warisan bagian, paragraf, bingkai teks, dan tema, serta menangani kasus di mana font yang ditentukan tidak tersedia.

## **Dapatkan Batas Bagian Teks**

Gunakan [IPortion.getRect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPortion#getRect--) untuk mengambil persegi panjang pembatas sebuah bagian teks:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Dapatkan Koordinat Bagian Teks**

Gunakan [IPortion.getCoordinates](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPortion#getCoordinates--) untuk mengambil koordinat awal sebuah bagian teks:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat menerapkan hyperlink hanya pada bagian teks dalam satu paragraf?**

Ya, Anda dapat [menetapkan hyperlink](/slides/id/androidjava/manage-hyperlinks/) ke sebuah bagian individual; hanya fragmen itu yang akan dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan gaya: apa yang ditimpa oleh bagian, dan apa yang diambil dari paragraf atau bingkai teks?**

Properti pada tingkat bagian memiliki prioritas tertinggi. Jika sebuah properti tidak diatur pada [IPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/), Aspose.Slides mengambilnya dari [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/). Jika tidak diatur di sana juga, Aspose.Slides menggunakan gaya dari [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) atau [theme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/theme/) .

**Apa yang terjadi jika font yang ditentukan untuk sebuah bagian tidak tersedia di mesin atau server target?**

[aturan substitusi font](/slides/id/androidjava/font-selection-sequence/) diterapkan. Teks dapat berubah susunannya: metrik, hyphenation, dan lebar dapat berubah, yang penting untuk penempatan yang tepat.

**Apakah saya dapat mengatur transparansi isi teks atau gradien khusus bagian secara independen dari sisa paragraf?**

Ya, warna teks, isi, dan transparansi pada tingkat [IPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/) dapat berbeda dari fragmen tetangga.