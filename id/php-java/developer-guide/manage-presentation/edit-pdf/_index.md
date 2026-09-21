---
title: Edit Dokumen PDF di PHP
linktitle: Edit PDF
type: docs
weight: 65
url: /id/php-java/edit-pdf/
keywords:
- edit PDF
- ganti teks PDF
- PDF ke PPTX
- PPTX ke PDF
- PHP
- Aspose.Slides
description: "Edit dokumen PDF di PHP dengan mengimpornya ke Aspose.Slides, mengganti teks, dan menyimpan presentasi yang dimodifikasi kembali ke PDF."
---
## **Ikhtisar**

Aspose.Slides untuk PHP via Java memungkinkan Anda mengedit konten PDF dengan mengimpor halamannya sebagai slide, memodifikasi presentasi, dan mengekspornya kembali ke PDF. Artikel ini menunjukkan penggantian teks sederhana. Presentasi tetap berada di memori, sehingga menyimpan file PPTX menengah bersifat opsional.

## **Ganti Teks dalam PDF**

Gunakan [SlideCollection::addFromPdf](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/#addFromPdf) untuk mengimpor halaman, [Presentation::replaceText](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#replaceText) untuk memperbarui teks, dan [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) untuk mengekspor hasilnya.

Contoh berikut mengharapkan `input.pdf` berisi kata "Draft" sebagai teks yang dapat diedit setelah impor. Ia mengganti kata tersebut dengan "Final" dan menulis `edited.pdf`. Menghapus slide awal sebelum impor mencegah halaman kosong tambahan dalam output. Pencarian mencocokkan kata penuh dengan huruf yang sama; `null` berarti tidak diperlukan callback hasil.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

Untuk opsi lebih lanjut, lihat [Search and Replace Text](/slides/id/php-java/search-and-replace-text/) dan [Convert PowerPoint to PDF](/slides/id/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Penggantian teks bekerja pada teks yang diimpor, bukan teks dalam gambar yang dipindai. Konversi dapat memengaruhi tata letak dan format, jadi tinjau output, terutama ketika teks pengganti lebih panjang daripada yang asli.
{{% /alert %}}

## **FAQ**

**Apakah saya perlu menyimpan file PPTX sebelum mengekspor PDF?**

Tidak. Anda dapat mengedit dan mengekspor presentasi yang sama dalam memori. Simpan salinan PPTX hanya jika Anda juga ingin melanjutkan mengeditnya di PowerPoint; lihat [Save Presentations](/slides/id/php-java/save-presentation/).

**Mengapa beberapa teks mungkin tetap tidak berubah?**

Contoh tersebut mencocokkan kata lengkap "Draft" dengan huruf yang tepat. Teks yang diimpor sebagai gambar atau terbagi di beberapa frame teks tidak selalu cocok dengan pencarian. Periksa konten yang diimpor dan sesuaikan pencarian untuk dokumen Anda.