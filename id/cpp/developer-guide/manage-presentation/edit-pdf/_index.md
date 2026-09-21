---
title: Sunting Dokumen PDF dengan C++
linktitle: Sunting PDF
type: docs
weight: 65
url: /id/cpp/edit-pdf/
keywords:
- sunting PDF
- ganti teks PDF
- PDF ke PPTX
- PPTX ke PDF
- C++
- Aspose.Slides
description: "Sunting dokumen PDF dengan C++ dengan mengimpornya ke Aspose.Slides, mengganti teks, dan menyimpan presentasi yang dimodifikasi kembali ke PDF."
---
## **Ikhtisar**

Aspose.Slides for C++ memungkinkan Anda mengedit konten PDF dengan mengimpor halamannya sebagai slide, memodifikasi presentasi, dan mengekspornya kembali ke PDF. Artikel ini menunjukkan cara mengganti teks secara sederhana. Presentasi tetap berada di memori, sehingga menyimpan file PPTX sementara bersifat opsional.

## **Ganti Teks dalam PDF**

Gunakan [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidecollection/addfrompdf/) untuk mengimpor halaman, [Presentation::ReplaceText](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/replacetext/) untuk memperbarui teks, dan [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) untuk mengekspor hasilnya.

Contoh berikut mengharapkan `input.pdf` berisi kata "Draft" sebagai teks yang dapat diedit setelah impor. Kata tersebut diganti dengan "Final" dan ditulis ke `edited.pdf`. Mengosongkan slide pertama sebelum impor mencegah munculnya halaman kosong tambahan dalam output. Pencarian mencocokkan seluruh kata dengan huruf yang sama; `nullptr` berarti tidak diperlukan callback hasil.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

Untuk opsi lainnya, lihat [Search and Replace Text](/slides/id/cpp/search-and-replace-text/) dan [Convert PowerPoint to PDF](/slides/id/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Penggantian teks berfungsi pada teks yang diimpor, bukan pada teks dalam gambar yang dipindai. Konversi dapat mempengaruhi tata letak dan format, jadi tinjau output, terutama bila teks pengganti lebih panjang daripada teks asli.
{{% /alert %}}

## **Tanya Jawab**

**Apakah saya perlu menyimpan file PPTX sebelum mengekspor PDF?**

Tidak. Anda dapat mengedit dan mengekspor presentasi yang sama di memori. Simpan salinan PPTX hanya jika Anda juga ingin melanjutkan mengeditnya di PowerPoint; lihat [Save Presentations](/slides/id/cpp/save-presentation/).

**Mengapa beberapa teks tetap tidak berubah?**

Contoh mencocokkan seluruh kata "Draft" dengan huruf yang tepat. Teks yang diimpor sebagai gambar atau yang terpisah dalam beberapa frame teks tidak selalu cocok dengan pencarian. Periksa konten yang diimpor dan sesuaikan pencarian untuk dokumen Anda.