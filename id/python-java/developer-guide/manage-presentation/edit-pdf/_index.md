---
title: Edit Dokumen PDF di Python via Java
linktitle: Edit PDF
type: docs
weight: 65
url: /id/python-java/edit-pdf/
keywords:
- edit PDF
- ganti teks PDF
- PDF ke PPTX
- PPTX ke PDF
- Python
- Java
- Aspose.Slides
description: "Edit dokumen PDF di Python via Java dengan mengimpornya ke Aspose.Slides, mengganti teks, dan menyimpan presentasi yang dimodifikasi kembali ke PDF."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java memungkinkan Anda mengedit konten PDF dengan mengimpor halamannya sebagai slide, memodifikasi presentasi, dan mengekspornya kembali ke PDF. Artikel ini menunjukkan cara mengganti teks secara sederhana. Presentasi tetap berada di memori, sehingga menyimpan file PPTX sementara bersifat opsional.

## **Ganti Teks dalam PDF**

Gunakan [addFromPdf](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addFromPdf) untuk mengimpor halaman, [replaceText](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#replaceText) untuk memperbarui teks, dan [save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) untuk mengekspor hasilnya.

Contoh berikut mengharapkan `input.pdf` berisi kata "Draft" sebagai teks yang dapat diedit setelah impor. Kata tersebut diganti dengan "Final" dan hasilnya disimpan ke `edited.pdf`. Mengosongkan slide awal sebelum impor mencegah halaman kosong tambahan dalam output. Pencarian mencocokkan kata lengkap dengan huruf yang sama; `None` berarti tidak diperlukan callback hasil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Untuk pilihan lebih lanjut, lihat [Search and Replace Text](/slides/id/python-java/search-and-replace-text/) dan [Convert PowerPoint to PDF](/slides/id/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Penggantian teks berlaku pada teks yang diimpor, bukan pada teks di dalam gambar yang dipindai. Konversi dapat memengaruhi tata letak dan pemformatan, jadi tinjau hasilnya, terutama bila teks pengganti lebih panjang dari teks asli.
{{% /alert %}}

## **FAQ**

**Apakah saya harus menyimpan file PPTX sebelum mengekspor PDF?**

Tidak. Anda dapat mengedit dan mengekspor presentasi yang sama di memori. Simpan salinan PPTX hanya jika Anda juga ingin melanjutkan pengeditan di PowerPoint; lihat [Save Presentations](/slides/id/python-java/save-presentation/).

**Mengapa beberapa teks tidak berubah?**

Contoh ini mencocokkan kata lengkap "Draft" dengan kapitalisasi yang tepat. Teks yang diimpor sebagai gambar atau terpecah menjadi beberapa frame teks tidak selalu cocok dengan pencarian. Periksa konten yang diimpor dan sesuaikan pencarian untuk dokumen Anda.