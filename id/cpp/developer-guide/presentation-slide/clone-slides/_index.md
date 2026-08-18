---
title: Klon Slide Presentasi dalam C++
linktitle: Klon Slide
type: docs
weight: 40
url: /id/cpp/clone-slides/
keywords:
- klon slide
- salin slide
- simpan slide
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Duplikat slide PowerPoint dengan cepat menggunakan Aspose.Slides untuk C++. Ikuti contoh kode kami yang jelas untuk mengotomatiskan pembuatan PPT dalam hitungan detik dan menghilangkan pekerjaan manual."
---
## **Pendahuluan**

Cloning adalah proses membuat salinan atau replika yang tepat dari sesuatu. Aspose.Slides for C++ juga memungkinkan membuat salinan atau klon dari slide mana pun dan kemudian menyisipkan slide yang diklon tersebut ke presentasi saat ini atau presentasi lain yang terbuka. Proses mengkloning slide membuat slide baru yang dapat dimodifikasi oleh pengembang tanpa mengubah slide asli. Ada beberapa cara untuk mengklon slide:

- Klon di Akhir dalam Presentasi.
- Klon di Posisi Lain dalam Presentasi.
- Klon di Akhir dalam Presentasi lain.
- Klon di Posisi Lain dalam Presentasi lain.
- Klon pada posisi spesifik dalam Presentasi lain.

In Aspose.Slides for C++, (a collection of [ISlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/) objects) exposed by the [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) object provides the [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) and [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/insertclone/) methods to perform the above types of slide cloning

## **Klon Slide di Akhir Presentasi**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama di akhir slide yang ada, gunakan metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) menurut langkah-langkah di bawah ini:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dengan merujuk ke koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Panggil metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dan berikan slide yang akan diklon sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/).
1. Tuliskan file presentasi yang telah dimodifikasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Klon Slide ke Posisi Lain dalam Presentasi**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada posisi yang berbeda, gunakan metode [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/insertclone/):

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Instansiasi kelas dengan merujuk ke koleksi **Slides** yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Panggil metode [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/insertclone/) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dan berikan slide yang akan diklon bersama indeks posisi baru sebagai parameter ke metode [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/insertclone/).
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Klon Slide di Akhir Presentasi Lain**
Jika Anda perlu mengklon slide dari satu presentasi dan menggunakannya dalam file presentasi lain, di akhir slide yang ada:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang berisi presentasi tempat slide akan diklon.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dengan merujuk ke koleksi **Slides** yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dan berikan slide dari presentasi sumber sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/).
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klon Slide ke Posisi Lain dalam Presentasi Lain**
Jika Anda perlu mengklon slide dari satu presentasi dan menggunakannya dalam file presentasi lain, pada posisi tertentu:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang berisi presentasi sumber tempat slide akan diklon.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang berisi presentasi tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dengan merujuk ke koleksi Slides yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/insertclone/) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dan berikan slide dari presentasi sumber bersama posisi yang diinginkan sebagai parameter ke metode [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/insertclone/).
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klon Slide pada Posisi Spesifik dalam Presentasi Lain**
Jika Anda perlu mengklon slide beserta master slide dari satu presentasi dan menggunakannya dalam presentasi lain, Anda harus terlebih dahulu mengklon master slide yang diinginkan dari presentasi sumber ke presentasi tujuan. Kemudian Anda harus menggunakan master slide tersebut untuk mengklon slide dengan master slide. Metode **AddClone(ISlide, IMasterSlide)** mengharapkan master slide dari presentasi tujuan, bukan dari presentasi sumber. Untuk mengklon slide dengan master, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang berisi presentasi sumber tempat slide akan diklon.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang berisi presentasi tujuan tempat slide akan diklon.
1. Akses slide yang akan diklon beserta master slide‑nya.
1. Instansiasi kelas [IMasterSlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslidecollection/) dengan merujuk ke koleksi Masters yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dari presentasi tujuan.
1. Panggil metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) yang diekspos oleh objek [IMasterSlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslidecollection/) dan berikan master dari PPTX sumber yang akan diklon sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/).
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dengan mengatur referensi ke koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dari presentasi tujuan.
1. Panggil metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dan berikan slide dari presentasi sumber yang akan diklon serta master slide sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/).
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Klon Slide di Akhir Seksi yang Ditentukan**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada seksi yang berbeda, gunakan metode [**AddClone()**](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) yang diekspos oleh antarmuka [**ISlideCollection**](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/). Aspose.Slides for C++ memungkinkan mengklon slide dari seksi pertama lalu menyisipkan slide yang diklon tersebut ke seksi kedua dalam presentasi yang sama.

Potongan kode berikut menunjukkan cara mengklon slide dan menyisipkan slide yang diklon ke seksi yang ditentukan.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Pastikan Ukuran Slide Cocok**

Ketika mengklon slide ke presentasi lain, pastikan presentasi tujuan memiliki ukuran slide yang sama dengan sumber. Jika ukuran slide berbeda, Aspose.Slides tidak secara otomatis mengubah skala bentuk yang diklon—koordinat dan dimensi asli mereka dipertahankan, yang dapat menyebabkan konten tampak tidak rata atau melampaui batas slide.

Anda dapat mengatur ukuran slide presentasi tujuan agar cocok dengan sumber sebelum mengklon master dan slide:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Lakukan ini sebelum mengklon master dan slide.

## **FAQ**

**Apakah catatan pembicara dan komentar peninjau juga diklon?**

Ya. Halaman catatan dan komentar peninjau disertakan dalam klon. Jika Anda tidak menginginkannya, [hapus mereka](/slides/id/cpp/presentation-notes/) setelah penyisipan.

**Bagaimana diagram dan sumber data mereka ditangani?**

Objek diagram, pemformatannya, dan data tersemat disalin. Jika diagram terhubung ke sumber eksternal (misalnya, workbook yang tersemat OLE), tautan tersebut dipertahankan sebagai [objek OLE](/slides/id/cpp/manage-ole/). Setelah dipindahkan antar file, periksa ketersediaan data dan perilaku penyegaran.

**Apakah saya dapat mengontrol posisi penyisipan dan seksi untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke [seksi](/slides/id/cpp/slide-section/) yang dipilih. Jika seksi target belum ada, buat terlebih dahulu dan kemudian pindahkan slide ke dalamnya.