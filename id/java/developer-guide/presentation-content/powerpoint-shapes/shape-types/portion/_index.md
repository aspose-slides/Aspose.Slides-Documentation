---
title: Kelola Bagian Teks dalam Presentasi Menggunakan Java
linktitle: Bagian Teks
type: docs
weight: 70
url: /id/java/portion/
keywords:
- bagian teks
- bagian teks
- koordinat teks
- posisi teks
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara mengelola bagian teks dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Java, meningkatkan kinerja dan kustomisasi."
---
## **Gambaran Umum**

Bagian teks mewakili fragmen teks tertentu di dalam sebuah paragraf dan memungkinkan Anda bekerja dengan fragmen itu secara independen dari konten di sekitarnya. Di Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil posisi fragmen teks, menerapkan pemformatan hanya pada sebagian paragraf, atau mengontrol perilaku teks pada tingkat yang lebih detail.

Artikel ini menunjukkan cara mendapatkan koordinat awal sebuah bagian dengan menggunakan metode `getCoordinates()`. Artikel ini juga menyoroti skenario umum terkait bagian, seperti menerapkan hyperlink pada satu fragmen teks, memahami bagaimana pemformatan diselesaikan melalui warisan bagian, paragraf, bingkai teks, dan tema, serta menangani kasus di mana font yang ditentukan tidak tersedia. Selain itu, dicatat bahwa isian teks, warna, dan transparansi dapat diatur secara berbeda untuk setiap bagian dalam paragraf yang sama.

## **Dapatkan Koordinat Bagian Teks**
[**getCoordinates()**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPortion#getCoordinates--) method telah ditambahkan ke [IPortion](https://reference.aspose.com/slides/id/java/com.aspose.slides/iportion/) dan [Portion](https://reference.aspose.com/slides/id/java/com.aspose.slides/portion/) class yang memungkinkan pengambilan koordinat awal bagian.

```java
// Membuat instance kelas Presentation yang mewakili PPTX
Presentation pres = new Presentation();
try {
    // Menyusun ulang konteks presentasi
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat menerapkan hyperlink hanya pada sebagian teks dalam satu paragraf?**

Ya, Anda dapat [assign a hyperlink](/slides/id/java/manage-hyperlinks/) pada sebuah bagian individual; hanya fragmen itu yang dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan gaya: apa yang di-override oleh Portion, dan apa yang diambil dari Paragraph/TextFrame?**

Properti tingkat Portion memiliki prioritas tertinggi. Jika suatu properti tidak diatur pada [Portion](https://reference.aspose.com/slides/id/java/com.aspose.slides/portion/), mesin akan mengambilnya dari [Paragraph](https://reference.aspose.com/slides/id/java/com.aspose.slides/paragraph/); jika tidak diatur di sana juga, dari [TextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/textframe/) atau gaya [theme](https://reference.aspose.com/slides/id/java/com.aspose.slides/theme/).

**Apa yang terjadi jika font yang ditentukan untuk sebuah Portion tidak ada di mesin/server target?**

[Font substitution rules](/slides/id/java/font-selection-sequence/) diterapkan. Teks mungkin berubah susunan: metrik, hyphenation, dan lebar dapat berubah, yang berpengaruh pada penempatan yang tepat.

**Apakah saya dapat mengatur transparansi atau gradien isian teks khusus untuk Portion secara terpisah dari paragraf lainnya?**

Ya, warna teks, isian, dan transparansi pada level [Portion](https://reference.aspose.com/slides/id/java/com.aspose.slides/portion/) dapat berbeda dari fragmen tetangga.