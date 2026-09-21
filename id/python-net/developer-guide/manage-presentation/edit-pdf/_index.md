---
title: Edit Dokumen PDF dengan Python
linktitle: Edit PDF
type: docs
weight: 65
url: /id/python-net/edit-pdf/
keywords:
- edit PDF
- ganti teks PDF
- PDF ke PPTX
- PPTX ke PDF
- Python
- Aspose.Slides
description: "Edit dokumen PDF di Python dengan mengimpornya ke Aspose.Slides, mengganti teks, dan menyimpan presentasi yang telah dimodifikasi kembali ke PDF."
---
## **Gambaran Umum**

Aspose.Slides for Python via .NET memungkinkan Anda mengedit konten PDF dengan mengimpor halamannya sebagai slide, memodifikasi presentasi, dan mengekspornya kembali ke PDF. Artikel ini menunjukkan penggantian teks sederhana. Presentasi tetap berada di memori, sehingga menyimpan file PPTX menengah bersifat opsional.

## **Ganti Teks dalam PDF**

Gunakan [add_from_pdf](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/add_from_pdf/) untuk mengimpor halaman, [replace_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/replace_text/) untuk memperbarui teks, dan [save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) untuk mengekspor hasilnya.

Contoh berikut mengharapkan `input.pdf` berisi kata "Draft" sebagai teks yang dapat diedit setelah diimpor. Itu mengganti kata tersebut dengan "Final" dan menulis `edited.pdf`. Mengosongkan slide awal sebelum impor mencegah halaman kosong tambahan dalam output. Pencarian mencocokkan seluruh kata dengan huruf kapital yang sama; `None` berarti tidak diperlukan callback hasil.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

Untuk opsi lebih lanjut, lihat [Cari dan Ganti Teks](/slides/id/python-net/search-and-replace-text/) dan [Konversi PowerPoint ke PDF](/slides/id/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Penggantian teks berfungsi pada teks yang diimpor, bukan teks dalam gambar yang dipindai. Konversi dapat memengaruhi tata letak dan pemformatan, jadi tinjau hasilnya, terutama ketika teks pengganti lebih panjang daripada yang asli.
{{% /alert %}}

## **FAQ**

**Apakah saya perlu menyimpan file PPTX sebelum mengekspor PDF?**

Tidak. Anda dapat mengedit dan mengekspor presentasi yang sama dalam memori. Simpan salinan PPTX hanya jika Anda juga ingin melanjutkan mengeditnya di PowerPoint; lihat [Simpan Presentasi](/slides/id/python-net/save-presentation/).

**Mengapa beberapa teks mungkin tetap tidak berubah?**

Contoh ini mencocokkan seluruh kata "Draft" dengan huruf kapital yang tepat. Teks yang diimpor sebagai gambar atau terpisah dalam beberapa bingkai teks tidak selalu cocok dengan pencarian. Periksa konten yang diimpor dan sesuaikan pencarian untuk dokumen Anda.