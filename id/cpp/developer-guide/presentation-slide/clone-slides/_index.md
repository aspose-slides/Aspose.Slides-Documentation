---
title: Menggandakan Slide Presentasi di C++
linktitle: Gandakan Slide
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
description: "Dengan cepat menggandakan slide PowerPoint menggunakan Aspose.Slides untuk C++. Ikuti contoh kode kami yang jelas untuk mengotomatisasi pembuatan PPT dalam hitungan detik dan menghilangkan pekerjaan manual."
---
## **Pendahuluan**

Cloning adalah proses membuat salinan atau replika yang persis dari sesuatu. Aspose.Slides for C++ juga memungkinkan membuat salinan atau klon dari slide apa pun dan kemudian menyisipkan slide yang diklon ke presentasi yang sedang dibuka atau presentasi lain yang terbuka. Proses kloning slide menciptakan slide baru yang dapat dimodifikasi oleh pengembang tanpa mengubah slide asli. Ada beberapa cara untuk mengklon slide:

- Klon di Akhir dalam Presentasi.
- Klon di Posisi Lain dalam Presentasi.
- Klon di Akhir dalam Presentasi lain.
- Klon di Posisi Lain dalam Presentasi lain.
- Klon pada posisi spesifik dalam Presentasi lain.

Di Aspose.Slides for C++, (sekumpulan objek [ISlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/) yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/)) menyediakan metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) dan [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/insertclone/) untuk melakukan tipe‑tipe kloning slide di atas.

## **Klon Slide di Akhir Presentasi**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama di akhir slide yang ada, gunakan metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) menurut langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dengan merujuk ke koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Panggil metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dan berikan slide yang akan diklon sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/).
1. Tulis file presentasi yang telah dimodifikasi.

Dalam contoh di bawah, kami mengklon sebuah slide (yang berada pada posisi pertama – indeks nol – dari presentasi) ke akhir presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Klon Slide ke Posisi Lain dalam Presentasi**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada posisi yang berbeda, gunakan metode [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/insertclone/):

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Instansiasi kelas dengan merujuk ke koleksi **Slides** yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Panggil metode [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/insertclone/) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dan berikan slide yang akan diklon bersama indeks untuk posisi baru sebagai parameter ke metode [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/insertclone/).
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah, kami mengklon sebuah slide (yang berada pada indeks nol – posisi 1 – dari presentasi) ke indeks 1 – Posisi 2 – dari presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Klon Slide di Akhir Presentasi Lain**
Jika Anda perlu mengklon slide dari satu presentasi dan menggunakannya dalam file presentasi lain, di akhir slide yang ada:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang berisi presentasi sumber slide.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dengan merujuk ke koleksi **Slides** yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dan berikan slide dari presentasi sumber sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah, kami mengklon sebuah slide (dari indeks pertama presentasi sumber) ke akhir presentasi tujuan.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klon Slide ke Posisi Lain dalam Presentasi Lain**
Jika Anda perlu mengklon slide dari satu presentasi dan menggunakannya dalam file presentasi lain, pada posisi spesifik:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang berisi presentasi sumber slide.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dengan merujuk ke koleksi Slides yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/insertclone/) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dan berikan slide dari presentasi sumber bersama posisi yang diinginkan sebagai parameter ke metode [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/insertclone/).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah, kami mengklon sebuah slide (dari indeks nol presentasi sumber) ke indeks 1 (posisi 2) dari presentasi tujuan.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klon Slide pada Posisi Spesifik dalam Presentasi Lain**
Jika Anda perlu mengklon slide beserta master slide dari satu presentasi dan menggunakannya dalam presentasi lain, pertama‑tama klon master slide yang diinginkan dari presentasi sumber ke presentasi tujuan. Kemudian gunakan master slide tersebut untuk mengklon slide dengan master slide. Metode **AddClone(ISlide, IMasterSlide)** mengharapkan master slide dari presentasi tujuan, bukan dari presentasi sumber. Untuk mengklon slide dengan master, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang berisi presentasi sumber slide.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang berisi presentasi tujuan slide akan diklon ke.
1. Akses slide yang akan diklon bersama master slide‑nya.
1. Instansiasi kelas [IMasterSlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslidecollection/) dengan merujuk ke koleksi Masters yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dari presentasi tujuan.
1. Panggil metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) yang diekspos oleh objek [IMasterSlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslidecollection/) dan berikan master dari PPTX sumber yang akan diklon sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/).
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dengan mengatur referensi ke koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dari presentasi tujuan.
1. Panggil metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dan berikan slide dari presentasi sumber beserta master slide sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah, kami mengklon slide dengan master (yang berada pada indeks nol presentasi sumber) ke akhir presentasi tujuan menggunakan master dari slide sumber.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Klon Slide di Akhir Seksi yang Ditentukan**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada seksi yang berbeda, gunakan metode [**AddClone()**](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) yang diekspos oleh antarmuka [**ISlideCollection**](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/). Aspose.Slides for C++ memungkinkan mengklon slide dari seksi pertama dan kemudian menyisipkan slide yang diklon ke seksi kedua dari presentasi yang sama.

Potongan kode berikut menunjukkan cara mengklon slide dan menyisipkan slide yang diklon ke sektion yang ditentukan.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **FAQ**

**Apakah catatan pembicara dan komentar peninjau ikut diklon?**

Ya. Halaman catatan dan komentar peninjau termasuk dalam klon. Jika tidak menginginkannya, [hapus mereka](/slides/id/cpp/presentation-notes/) setelah penyisipan.

**Bagaimana chart dan sumber data mereka ditangani?**

Objek chart, pemformatannya, dan data yang tersemat disalin. Jika chart terhubung ke sumber eksternal (misalnya workbook OLE‑tersemat), tautan itu dipertahankan sebagai [objek OLE](/slides/id/cpp/manage-ole/). Setelah dipindahkan antar file, pastikan ketersediaan data dan perilaku penyegaran.

**Apakah saya dapat mengontrol posisi penyisipan dan seksi untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke [seksi](/slides/id/cpp/slide-section/) yang dipilih. Jika seksi target belum ada, buat dulu dan kemudian pindahkan slide ke dalamnya.