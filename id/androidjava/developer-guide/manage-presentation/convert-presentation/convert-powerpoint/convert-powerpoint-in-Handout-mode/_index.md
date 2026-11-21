---
title: Konversi Presentasi PowerPoint dalam Mode Handout di Android
linktitle: Mode Handout
type: docs
weight: 150
url: /id/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- konversi PowerPoint
- konversi presentasi
- mode handout
- handout
- PPT
- PPTX
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Konversi presentasi ke handout dalam Java. Atur slide per halaman, pertahankan catatan, ekspor ke PDF atau gambar dengan Aspose.Slides untuk Android, dengan contoh kode. Coba gratis."
---
## **Pendahuluan**

Aspose.Slides menyediakan kemampuan untuk mengonversi presentasi ke berbagai format, termasuk membuat handout untuk dicetak dalam mode Handout. Mode ini memungkinkan Anda mengonfigurasi bagaimana beberapa slide ditampilkan pada satu halaman, sehingga berguna untuk konferensi, seminar, dan acara lainnya. Anda dapat mengaktifkan mode ini dengan menyetel metode `setSlidesLayoutOptions` pada antarmuka [IPdfOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihtmloptions/), dan [ITiffOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiffoptions/) .

Untuk mengatur dimensi dan orientasi halaman handout sebelum ekspor, lihat [Ukuran Halaman Catatan](/slides/id/androidjava/notes-size/).

## **Ekspor Mode Handout**

Untuk mengkonfigurasi mode Handout, gunakan objek [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/handoutlayoutingoptions/), yang menentukan berapa banyak slide yang ditempatkan pada satu halaman serta parameter tampilan lainnya.

Berikut contoh kode yang menunjukkan cara mengonversi presentasi ke PDF dalam mode Handout.

```java
import com.aspose.slides.*;

// Muat presentasi.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Atur opsi ekspor.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slide pada satu halaman secara horizontal
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // cetak nomor slide
	slidesLayoutOptions.setPrintFrameSlide(true);                     // cetak bingkai di sekitar slide
	slidesLayoutOptions.setPrintComments(false);                      // tidak ada komentar

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Ekspor presentasi ke PDF dengan tata letak yang dipilih.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Perlu diingat bahwa metode `setSlidesLayoutOptions` hanya tersedia untuk format output tertentu, seperti PDF, HTML, TIFF, dan saat merender sebagai gambar.
{{% /alert %}} 

## **FAQ**

**Berapa jumlah maksimum thumbnail slide per halaman dalam mode Handout?**

Aspose.Slides mendukung [preset](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/handouttype/) hingga 9 thumbnail per halaman dengan urutan horizontal atau vertikal: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal), dan 9 (horizontal/vertikal).

**Bisakah saya menentukan grid khusus, seperti 5 atau 8 slide per halaman?**

Tidak. Jumlah dan urutan thumbnail dikontrol secara ketat oleh kelas [HandoutType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/handouttype/) ; tata letak arbitrer tidak didukung.

**Bisakah saya menyertakan slide tersembunyi dalam output Handout?**

Ya. Aktifkan slide tersembunyi dengan menggunakan metode `setShowHiddenSlides` dalam pengaturan ekspor untuk format target, seperti [PdfOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/htmloptions/), atau [TiffOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/).