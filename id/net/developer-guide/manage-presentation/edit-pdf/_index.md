---
title: Edit Dokumen PDF di .NET
linktitle: Edit PDF
type: docs
weight: 65
url: /id/net/edit-pdf/
keywords:
- mengedit PDF
- ganti teks PDF
- PDF ke PPTX
- PPTX ke PDF
- .NET
- C#
- Aspose.Slides
description: "Edit dokumen PDF dalam C# dengan mengimpornya ke Aspose.Slides, mengganti teks, dan menyimpan presentasi yang dimodifikasi kembali ke PDF."
---
## **Gambaran Umum**

Aspose.Slides for .NET memungkinkan Anda mengedit konten PDF dengan mengimpor halamannya sebagai slide, memodifikasi presentasi, dan mengekspornya kembali ke PDF. Artikel ini menunjukkan contoh penggantian teks sederhana. Presentasi tetap berada di memori, sehingga menyimpan file PPTX sementara bersifat opsional.

## **Ganti Teks dalam PDF**

Gunakan [AddFromPdf](https://reference.aspose.com/slides/id/net/aspose.slides/slidecollection/addfrompdf/) untuk mengimpor halaman, [ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/replacetext/) untuk memperbarui teks, dan [Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) untuk mengekspor hasilnya.

Contoh berikut mengasumsikan `input.pdf` berisi kata "Draft" sebagai teks yang dapat diedit setelah impor. Kata tersebut diganti dengan "Final" dan hasilnya disimpan sebagai `edited.pdf`. Menghapus slide awal sebelum impor mencegah munculnya halaman kosong tambahan pada output. Pencarian mencocokkan kata lengkap dengan huruf yang sama; `null` berarti tidak diperlukan callback hasil.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Untuk opsi lebih lanjut, lihat [Search and Replace Text](/slides/id/net/search-and-replace-text/) dan [Convert PowerPoint to PDF](/slides/id/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Penggantian teks berfungsi pada teks yang diimpor, bukan pada teks dalam gambar yang dipindai. Konversi dapat memengaruhi tata letak dan pemformatan, jadi tinjau output, terutama bila teks pengganti lebih panjang daripada teks asli.
{{% /alert %}}

## **FAQ**

**Apakah saya perlu menyimpan file PPTX sebelum mengekspor PDF?**

Tidak. Anda dapat mengedit dan mengekspor presentasi yang sama di memori. Simpan salinan PPTX hanya jika Anda juga ingin terus mengeditnya di PowerPoint; lihat [Simpan Presentasi](/slides/id/net/save-presentation/).

**Mengapa beberapa teks tetap tidak berubah?**

Contoh ini mencocokkan kata lengkap "Draft" dengan huruf yang persis. Teks yang diimpor sebagai gambar atau terpisah ke dalam frame teks terpisah tidak akan selalu cocok dengan pencarian. Periksa konten yang diimpor dan sesuaikan pencarian untuk dokumen Anda.