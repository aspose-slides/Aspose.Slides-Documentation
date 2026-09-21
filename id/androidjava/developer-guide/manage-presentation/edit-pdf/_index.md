---
title: Sunting Dokumen PDF di Android
linktitle: Sunting PDF
type: docs
weight: 65
url: /id/androidjava/edit-pdf/
keywords:
- sunting PDF
- ganti teks PDF
- PDF ke PPTX
- PPTX ke PDF
- Android
- Java
- Aspose.Slides
description: "Sunting dokumen PDF di Android dengan Java dengan mengimpor mereka ke Aspose.Slides, mengganti teks, dan menyimpan presentasi yang dimodifikasi kembali ke PDF."
---
## **Gambaran Umum**

Aspose.Slides for Android via Java memungkinkan Anda mengedit konten PDF dengan mengimpor halamannya sebagai slide, memodifikasi presentasi, dan mengekspornya kembali ke PDF. Artikel ini menunjukkan contoh penggantian teks sederhana. Presentasi tetap berada di memori, sehingga menyimpan file PPTX sementara bersifat opsional.

## **Ganti Teks dalam PDF**

Gunakan [addFromPdf](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) untuk mengimpor halaman, [replaceText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) untuk memperbarui teks, dan [save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) untuk mengekspor hasilnya.

Contoh berikut mengasumsikan `input.pdf` berisi kata "Draft" sebagai teks yang dapat diedit setelah impor. Kata tersebut diganti menjadi "Final" dan hasilnya ditulis ke `edited.pdf`. Mengosongkan slide awal sebelum impor mencegah munculnya halaman kosong tambahan pada output. Pencarian mencocokkan kata secara lengkap dengan huruf yang sama; `null` berarti tidak diperlukan callback hasil.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Untuk opsi lebih lanjut, lihat [Search and Replace Text](/slides/id/androidjava/search-and-replace-text/) dan [Convert PowerPoint to PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Penggantian teks bekerja pada teks yang diimpor, bukan pada teks di dalam gambar yang dipindai. Konversi dapat memengaruhi tata letak dan format, jadi tinjau output, terutama bila teks pengganti lebih panjang daripada teks aslinya.
{{% /alert %}}

## **FAQ**

**Apakah saya perlu menyimpan file PPTX sebelum mengekspor ke PDF?**

Tidak. Anda dapat mengedit dan mengekspor presentasi yang sama di memori. Simpan salinan PPTX hanya jika Anda juga ingin melanjutkan mengeditnya di PowerPoint; lihat [Save Presentations](/slides/id/androidjava/save-presentation/).

**Mengapa beberapa teks mungkin tetap tidak berubah?**

Contoh ini mencocokkan kata lengkap "Draft" dengan huruf yang tepat. Teks yang diimpor sebagai gambar atau terpisah di beberapa frame teks tidak akan selalu cocok dengan pencarian. Periksa konten yang diimpor dan sesuaikan pencarian untuk dokumen Anda.