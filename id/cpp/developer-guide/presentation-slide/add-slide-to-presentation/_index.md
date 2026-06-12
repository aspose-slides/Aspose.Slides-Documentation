---
title: Menambahkan Slide ke Presentasi dalam C++
linktitle: Tambah Slide
type: docs
weight: 10
url: /id/cpp/add-slide-to-presentation/
keywords:
- menambah slide
- membuat slide
- slide kosong
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Dengan mudah menambahkan slide ke presentasi PowerPoint dan OpenDocument Anda menggunakan Aspose.Slides untuk C++ — penyisipan slide yang mulus dan efisien dalam hitungan detik."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menambahkan slide ke presentasi PowerPoint secara programatis. Sebuah presentasi berisi slide master/layou t dan slide normal, dan slide normal diatur dengan indeks berbasis nol. Setiap slide memiliki ID unik, dan file presentasi tanpa slide tidak didukung.

Artikel ini menjelaskan cara membuat objek `Presentation`, mengakses koleksi slide‑nya, menambahkan slide kosong, bekerja dengan slide yang baru ditambahkan, dan menyimpan presentasi yang telah diperbarui. Artikel ini juga mencakup hal‑hal terkait seperti menyisipkan slide pada posisi tertentu, menggunakan layout, serta memahami slide kosong yang ada pada presentasi yang baru dibuat.

## **Menambahkan Slide ke Presentasi**
Sebelum membahas penambahan slide ke file presentasi, mari bahas beberapa fakta tentang slide. Setiap file presentasi PowerPoint berisi slide Master / Layout dan slide Normal lainnya. Ini berarti bahwa file presentasi berisi setidaknya satu slide atau lebih. Penting untuk diketahui bahwa file presentasi tanpa slide tidak didukung oleh Aspose.Slides untuk C++. Setiap slide memiliki Id unik dan semua Slide Normal diatur dalam urutan yang ditentukan oleh indeks berbasis nol. Aspose.Slides untuk C++ memungkinkan pengembang menambahkan slide kosong ke presentasi mereka. Untuk menambahkan slide kosong dalam presentasi, ikuti langkah‑langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
- Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) dengan menetapkan referensi ke properti Slides (koleksi objek Slide konten) yang disediakan oleh objek Presentation.
- Tambahkan slide kosong ke presentasi di akhir koleksi slide konten dengan memanggil metode AddEmptySlide yang disediakan oleh objek ISlideCollection.
- Lakukan beberapa pekerjaan dengan slide kosong yang baru ditambahkan.
- Akhirnya, tulis file presentasi menggunakan objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **FAQ**

**Apakah saya dapat menyisipkan slide baru pada posisi tertentu, bukan hanya di akhir?**

Ya. Perpustakaan mendukung koleksi slide dan operasi [insert](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidecollection/insertclone/) , sehingga Anda dapat menambahkan slide pada indeks yang diperlukan, bukan hanya di akhir.

**Apakah tema/gaya dipertahankan ketika menambahkan slide berdasarkan layout?**

Ya. Sebuah layout mewarisi pemformatan dari master‑nya, dan slide baru mewarisi dari layout yang dipilih serta master yang terkait.

**Slide mana yang ada dalam presentasi “kosong” baru sebelum menambahkan slide?**

Presentasi yang baru dibuat sudah berisi satu slide kosong dengan indeks nol. Hal ini penting dipertimbangkan saat menghitung indeks penyisipan.

**Bagaimana saya memilih layout yang “tepat” untuk slide baru jika master memiliki banyak opsi?**

Umumnya pilih [LayoutSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/layoutslide/) yang cocok dengan struktur yang diperlukan ([Title and Content, Two Content, dll.](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidelayouttype/)). Jika layout tersebut tidak ada, Anda dapat [add it to the master](/slides/id/cpp/slide-layout/) dan kemudian menggunakannya.