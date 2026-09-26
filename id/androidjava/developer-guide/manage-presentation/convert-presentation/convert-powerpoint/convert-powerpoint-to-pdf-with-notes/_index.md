---
title: Mengonversi Presentasi PowerPoint ke PDF dengan Catatan di Android
linktitle: PowerPoint ke PDF dengan Catatan
type: docs
weight: 50
url: /id/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Mengonversi format PPT dan PPTX ke PDF dengan catatan menggunakan Aspose.Slides untuk Android via Java. Mempertahankan tata letak dan catatan pembicara untuk presentasi profesional."
---
## **Gambaran Umum**

Dalam artikel ini, Anda akan mempelajari cara mengonversi presentasi PowerPoint ke format PDF dengan catatan pembicara menggunakan Aspose.Slides. Panduan ini akan mencakup langkah‑langkah yang diperlukan dan menyediakan contoh kode untuk membantu Anda menyelesaikan tugas ini secara efisien. Pada akhir artikel ini, Anda akan dapat:

- Menerapkan proses konversi untuk mengubah slide PowerPoint menjadi dokumen PDF sambil mempertahankan catatan pembicara.
- Menyesuaikan PDF output untuk memastikan catatan pembicara disertakan dan diformat sesuai kebutuhan Anda.

Untuk mengatur dimensi dan orientasi halaman catatan sebelum diekspor, lihat [Ukuran Halaman Catatan](/slides/id/androidjava/notes-size/).

## **Mengonversi PowerPoint ke PDF dengan Catatan**

Metode `save` dalam kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dapat digunakan untuk mengonversi presentasi PPT atau PPTX menjadi PDF dengan catatan pembicara. Dengan Aspose.Slides, Anda cukup memuat presentasi, mengonfigurasi opsi tata letak menggunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/notescommentslayoutingoptions/) untuk menyertakan catatan pembicara, lalu menyimpan file sebagai PDF. Cuplikan kode berikut menunjukkan cara mengonversi contoh presentasi ke PDF dalam tampilan Slide Catatan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Konfigurasikan opsi PDF untuk merender catatan pembicara.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Render catatan pembicara di bawah slide.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Simpan presentasi ke PDF dengan catatan pembicara.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Catatan" %}}
Anda mungkin ingin mencoba Aspose [Konverter PowerPoint ke PDF Online](https://products.aspose.app/slides/id/conversion).
{{% /alert %}}