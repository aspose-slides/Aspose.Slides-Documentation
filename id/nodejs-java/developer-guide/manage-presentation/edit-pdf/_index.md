---
title: Edit Dokumen PDF di JavaScript
linktitle: Edit PDF
type: docs
weight: 65
url: /id/nodejs-java/edit-pdf/
keywords:
- mengedit PDF
- ganti teks PDF
- PDF ke PPTX
- PPTX ke PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "Edit dokumen PDF di JavaScript dengan mengimpornya ke Aspose.Slides, mengganti teks, dan menyimpan presentasi yang dimodifikasi kembali ke PDF."
---
## **Gambaran Umum**

Aspose.Slides untuk Node.js via Java memungkinkan Anda mengedit konten PDF dengan mengimpor halamannya sebagai slide, memodifikasi presentasi, dan mengekspornya kembali ke PDF. Artikel ini menunjukkan penggantian teks sederhana. Presentasi tetap berada di memori, sehingga menyimpan file PPTX menengah bersifat opsional.

## **Ganti Teks dalam PDF**

Gunakan [addFromPdf](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addFromPdf) untuk mengimpor halaman, [replaceText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#replaceText) untuk memperbarui teks, dan [save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) untuk mengekspor hasil.

Contoh berikut mengharapkan `input.pdf` berisi kata "Draft" sebagai teks yang dapat diedit setelah impor. Ia mengganti kata tersebut dengan "Final" dan menulis `edited.pdf`. Menghapus slide awal sebelum impor mencegah halaman kosong tambahan dalam output. Pencarian mencocokkan kata seluruh dengan huruf yang sama; `null` berarti tidak diperlukan callback hasil.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Untuk lebih banyak opsi, lihat [Cari dan Ganti Teks](/slides/id/nodejs-java/search-and-replace-text/) dan [Konversi PowerPoint ke PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Penggantian teks bekerja pada teks yang diimpor, bukan teks di dalam gambar yang dipindai. Konversi dapat memengaruhi tata letak dan format, jadi tinjau hasilnya, terutama ketika teks pengganti lebih panjang daripada teks asli.
{{% /alert %}}

## **FAQ**

**Apakah saya perlu menyimpan file PPTX sebelum mengekspor PDF?**

Tidak. Anda dapat mengedit dan mengekspor presentasi yang sama dalam memori. Simpan salinan PPTX hanya jika Anda juga ingin melanjutkan mengeditnya di PowerPoint; lihat [Simpan Presentasi](/slides/id/nodejs-java/save-presentation/).

**Mengapa beberapa teks mungkin tetap tidak berubah?**

Contoh ini mencocokkan kata seluruh "Draft" dengan huruf yang tepat. Teks yang diimpor sebagai gambar atau terpecah menjadi beberapa bingkai teks tidak selalu cocok dengan pencarian. Periksa konten yang diimpor dan sesuaikan pencarian untuk dokumen Anda.