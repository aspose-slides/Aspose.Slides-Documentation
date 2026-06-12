---
title: Mengonversi Presentasi PowerPoint ke Dokumen Word di Android
linktitle: PowerPoint ke Word
type: docs
weight: 110
url: /id/androidjava/convert-powerpoint-to-word/
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
- Android
- Java
- Aspose.Slides
description: "Mengonversi slide PowerPoint PPT dan PPTX menjadi dokumen Word yang dapat diedit di Java menggunakan Aspose.Slides untuk Android dengan tata letak, gambar, dan pemformatan yang tepat tetap dipertahankan."
---
## **Ikhtisar**

Artikel ini menyediakan solusi bagi pengembang dalam mengonversi presentasi PowerPoint dan OpenDocument ke dokumen Word menggunakan Aspose.Slides dan Aspose.Words. Panduan langkah demi langkah ini membawa Anda melalui setiap tahap proses konversi.

## **Aspose.Slides dan Aspose.Words**

Untuk mengonversi file PowerPoint (PPTX atau PPT) ke Word (DOCX atau DOC), Anda memerlukan kedua [Aspose.Slides for Android via Java](https://products.aspose.com/slides/id/androidjava/) dan [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/).

Sebagai API mandiri, [Aspose.Slides](https://products.aspose.app/slides) untuk java menyediakan fungsi yang memungkinkan Anda mengekstrak teks dari presentasi. 

[Aspose.Words](https://docs.aspose.com/words/androidjava/) adalah API pemrosesan dokumen canggih yang memungkinkan aplikasi untuk membuat, memodifikasi, mengonversi, merender, mencetak file, dan melakukan tugas lain dengan dokumen tanpa menggunakan Microsoft Word.

## **Konversi PowerPoint ke Word**

1. Unduh pustaka [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/id/java) dan [Aspose.Words for Java](https://downloads.aspose.com/words/java).
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

**Komponen apa yang perlu dipasang untuk mengonversi presentasi PowerPoint dan OpenDocument ke dokumen Word?**

Anda hanya perlu menambahkan paket yang sesuai untuk [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/id/androidjava/) dan [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) ke proyek Anda. Kedua pustaka beroperasi sebagai API mandiri, dan tidak ada keharusan untuk menginstal Microsoft Office.

**Apakah semua format presentasi PowerPoint dan OpenDocument didukung?**

Aspose.Slides [mendukung semua format presentasi](/slides/id/androidjava/supported-file-formats/), termasuk PPT, PPTX, ODP, dan jenis file umum lainnya. Hal ini memastikan Anda dapat bekerja dengan presentasi yang dibuat dalam berbagai versi Microsoft PowerPoint.