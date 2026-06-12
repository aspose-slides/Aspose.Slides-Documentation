---
title: Konversi Presentasi PowerPoint ke PDF dengan Catatan dalam JavaScript
linktitle: PowerPoint ke PDF dengan Catatan
type: docs
weight: 50
url: /id/nodejs-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke PDF
- presentasi ke PDF
- slide ke PDF
- PPT ke PDF
- PPTX ke PDF
- simpan presentasi sebagai PDF
- simpan PPT sebagai PDF
- simpan PPTX sebagai PDF
- ekspor PPT ke PDF
- ekspor PPTX ke PDF
- catatan pembicara
- PDF dengan catatan
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi format PPT dan PPTX ke PDF dengan catatan dalam JavaScript menggunakan Aspose.Slides untuk Node.js. Mempertahankan tata letak dan catatan pembicara untuk presentasi profesional."
---
## **Gambaran Umum**

Dalam artikel ini, Anda akan mempelajari cara mengonversi presentasi PowerPoint ke format PDF dengan catatan pembicara menggunakan Aspose.Slides. Panduan ini akan mencakup langkah‑langkah yang diperlukan dan memberikan contoh kode untuk membantu Anda menyelesaikan tugas ini secara efisien. Pada akhir artikel, Anda akan dapat:

- Menerapkan proses konversi untuk mengubah slide PowerPoint menjadi dokumen PDF sambil mempertahankan catatan pembicara.
- Menyesuaikan PDF output agar catatan pembicara disertakan dan diformat sesuai kebutuhan Anda.

## **Konversi PowerPoint ke PDF dengan Catatan**

Metode `save` di kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dapat digunakan untuk mengonversi presentasi PPT atau PPTX ke PDF dengan catatan pembicara. Dengan Aspose.Slides, Anda cukup memuat presentasi, mengonfigurasi opsi tata letak menggunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notescommentslayoutingoptions/) untuk menyertakan catatan pembicara, lalu menyimpan file sebagai PDF. Potongan kode berikut menunjukkan cara mengonversi presentasi contoh ke PDF dalam tampilan Slide Catatan.

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// Atur opsi PDF untuk merender catatan pembicara.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Render catatan pembicara di bawah slide.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Simpan presentasi ke PDF dengan catatan pembicara.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
Anda mungkin ingin melihat Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/id/conversion). 
{{% /alert %}}