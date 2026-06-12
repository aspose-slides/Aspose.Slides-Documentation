---
title: Konversi Presentasi PowerPoint ke Dokumen Word dalam Java
linktitle: PowerPoint ke Word
type: docs
weight: 110
url: /id/java/convert-powerpoint-to-word/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke Word
- presentasi ke Word
- slide ke Word
- PPT ke Word
- PPTX ke Word
- PowerPoint ke DOCX
- presentasi ke DOCX
- slide ke DOCX
- PPT ke DOCX
- PPTX ke DOCX
- PowerPoint ke DOC
- presentasi ke DOC
- slide ke DOC
- PPT ke DOC
- PPTX ke DOC
- simpan PPT sebagai DOCX
- simpan PPTX sebagai DOCX
- ekspor PPT ke DOCX
- ekspor PPTX ke DOCX
- Java
- Aspose.Slides
description: "Konversi slide PowerPoint PPT dan PPTX menjadi dokumen Word yang dapat diedit dalam Java menggunakan Aspose.Slides dengan tata letak, gambar, dan pemformatan yang tepat tetap terjaga."
---
## **Gambaran Umum**

Artikel ini menyediakan solusi bagi pengembang dalam mengonversi presentasi PowerPoint dan OpenDocument ke dokumen Word menggunakan Aspose.Slides dan Aspose.Words. Panduan langkah demi langkah ini akan memandu Anda melalui setiap tahap proses konversi.

## **Konversi PowerPoint ke Word**

Ikuti instruksi di bawah ini untuk mengonversi presentasi PowerPoint atau OpenDocument ke dokumen Word:

1. Unduh [Aspose.Slides for Java](https://downloads.aspose.com/slides/id/java) dan [Aspose.Words for Java](https://downloads.aspose.com/words/java) perpustakaan.
2. Tambahkan *aspose-slides-x.x-jdk16.jar* dan *aspose-words-x.x-jdk16.jar* ke CLASSPATH Anda.
3. Gunakan potongan kode ini untuk mengonversi PowerPoint ke Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // menghasilkan gambar slide sebagai aliran byte array
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // menyisipkan teks slide
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```

## **FAQ**

**Komponen apa yang perlu diinstal untuk mengonversi presentasi PowerPoint dan OpenDocument ke dokumen Word?**

Anda hanya perlu menambahkan paket yang sesuai untuk [Aspose.Slides for Java](https://releases.aspose.com/slides/id/java/) dan [Aspose.Words for Java](https://releases.aspose.com/words/java/) ke proyek Anda. Kedua perpustakaan beroperasi sebagai API mandiri, dan tidak ada persyaratan untuk menginstal Microsoft Office.

**Apakah semua format presentasi PowerPoint dan OpenDocument didukung?**

Aspose.Slides [mendukung semua format presentasi](/slides/id/java/supported-file-formats/), termasuk PPT, PPTX, ODP, dan jenis file umum lainnya. Ini memastikan bahwa Anda dapat bekerja dengan presentasi yang dibuat dalam berbagai versi Microsoft PowerPoint.