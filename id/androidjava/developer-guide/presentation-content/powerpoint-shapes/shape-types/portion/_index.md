---
title: Kelola Bagian Teks dalam Presentasi di Android
linktitle: Bagian Teks
type: docs
weight: 70
url: /id/androidjava/portion/
keywords:
- bagian teks
- segmen teks
- koordinat teks
- posisi teks
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengelola bagian teks dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Android via Java, meningkatkan kinerja dan kustomisasi."
---
## **Pendahuluan**

Sebuah bagian teks mewakili fragmen teks tertentu di dalam sebuah paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara independen dari konten di sekitarnya. Dalam Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil posisi fragmen teks, menerapkan pemformatan hanya pada sebagian paragraf, atau mengendalikan perilaku teks pada tingkat yang lebih detail.

## **Dapatkan Koordinat Bagian Teks**
Metode [**getCoordinates()**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPortion#getCoordinates--) telah ditambahkan ke kelas [IPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/) dan [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portion/) yang memungkinkan mengambil koordinat awal bagian.

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
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

**Bisakah saya menerapkan hyperlink hanya pada sebagian teks dalam satu paragraf?**

Ya, Anda dapat [menetapkan hyperlink](/slides/id/androidjava/manage-hyperlinks/) ke bagian individual; hanya fragmen itu yang dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan style: apa yang ditimpa oleh Portion, dan apa yang diambil dari Paragraph/TextFrame?**

Properti pada tingkat Portion memiliki prioritas tertinggi. Jika suatu properti tidak diatur pada [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portion/), mesin mengambilnya dari [Paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraph/); jika juga tidak diatur di sana, maka diambil dari [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/) atau gaya [theme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/theme/).

**Apa yang terjadi jika font yang ditentukan untuk sebuah Portion tidak ada di mesin/server target?**

[Aturan substitusi font](/slides/id/androidjava/font-selection-sequence/) diterapkan. Teks dapat berubah susunan: metrik, hyphenasi, dan lebar dapat berubah, yang berpengaruh pada penempatan yang tepat.

**Bisakah saya mengatur transparansi atau gradien isi teks khusus Portion secara terpisah dari sisa paragraf?**

Ya, warna teks, isi, dan transparansi pada tingkat [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portion/) dapat berbeda dari fragmen tetangga.