---
title: "Kelola Transisi Slide dalam Presentasi Menggunakan C++"
linktitle: "Transisi Slide"
type: docs
weight: 80
url: /id/cpp/slide-transition/
keywords:
- "transisi slide"
- "menambahkan transisi slide"
- "menerapkan transisi slide"
- "transisi slide lanjutan"
- "transisi morph"
- "jenis transisi"
- "efek transisi"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "C++"
- "Aspose.Slides"
description: "Temukan cara menyesuaikan transisi slide dalam Aspose.Slides untuk C++, dengan panduan langkah demi langkah untuk presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengelola transisi slide dalam presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menerapkan jenis transisi pada slide, mengkonfigurasi perilaku transisi seperti maju saat diklik atau setelah waktu tertentu, memeriksa dan menonaktifkan maju otomatis, menggunakan transisi Morph beserta jenisnya, serta mengatur opsi efek transisi. Contoh-contoh menunjukkan cara memuat atau membuat presentasi, memodifikasi pengaturan transisi untuk slide terpilih, dan menyimpan hasilnya sebagai file PPTX. Artikel ini juga menjawab pertanyaan umum tentang kecepatan transisi, suara transisi, menerapkan transisi yang sama ke banyak slide, dan memeriksa transisi yang saat ini diatur pada slide.

## **Tambahkan Transisi Slide**

Untuk mempermudah pemahaman, kami telah mendemonstrasikan penggunaan Aspose.Slides untuk C++ dalam mengelola transisi slide sederhana. Pengembang tidak hanya dapat menerapkan efek transisi slide yang berbeda pada slide, tetapi juga menyesuaikan perilaku efek transisi tersebut. Untuk membuat efek transisi slide sederhana, ikuti langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
1. Terapkan Slide Transition Type pada slide dari salah satu efek transisi yang disediakan oleh Aspose.Slides untuk C++ melalui enum TransitionType.
1. Tuliskan file presentasi yang telah dimodifikasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Tambahkan Transisi Slide Lanjutan**

Pada bagian di atas, kami hanya menerapkan efek transisi sederhana pada slide. Sekarang, untuk membuat efek transisi sederhana tersebut menjadi lebih baik dan terkontrol, silakan ikuti langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
1. Terapkan Slide Transition Type pada slide dari salah satu efek transisi yang disediakan oleh Aspose.Slides untuk C++.
1. Anda juga dapat mengatur transisi menjadi Advance On Click, setelah periode waktu tertentu, atau keduanya.
1. Jika transisi slide diaktifkan menjadi Advance On Click, transisi hanya akan maju ketika seseorang mengklik mouse. Selain itu, jika properti Advance After Time diatur, transisi akan maju secara otomatis setelah waktu maju yang ditentukan berlalu.
1. Tuliskan presentasi yang dimodifikasi sebagai file presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Transisi Morph**

Aspose.Slides untuk C++ kini mendukung Morph Transition. Ini merupakan transisi morph baru yang diperkenalkan di PowerPoint 2019. Transisi Morph memungkinkan Anda menganimasikan perpindahan yang mulus dari satu slide ke slide berikutnya. Artikel ini menjelaskan konsep dan cara menggunakan Morph Transition. Untuk menggunakan Morph Transition secara efektif, Anda memerlukan dua slide dengan setidaknya satu objek yang sama. Cara termudah adalah menduplikasi slide dan kemudian memindahkan objek pada slide kedua ke tempat yang berbeda.

Potongan kode berikut menunjukkan cara menambahkan klon slide dengan beberapa teks ke dalam presentasi dan menetapkan transisi tipe morph pada slide kedua.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Jenis Transisi Morph**

Enum Aspose.Slides.SlideShow.TransitionMorphType yang baru telah ditambahkan. Enum ini mewakili berbagai jenis transisi slide Morph.

Enum TransitionMorphType memiliki tiga anggota:

- ByObject: Transisi Morph akan dilakukan dengan mempertimbangkan bentuk sebagai objek yang tidak dapat dibagi.
- ByWord: Transisi Morph akan dilakukan dengan memindahkan teks per kata bila memungkinkan.
- ByChar: Transisi Morph akan dilakukan dengan memindahkan teks per karakter bila memungkinkan.

Potongan kode berikut menunjukkan cara mengatur transisi morph pada slide dan mengubah jenis morph:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Atur Efek Transisi**

Aspose.Slides untuk C++ mendukung pengaturan efek transisi seperti from black, from left, from right, dll. Untuk mengatur Efek Transisi, silakan ikuti langkah-langkah di bawah ini:

- Buat sebuah instance dari kelas Presentation.
- Dapatkan referensi slide.
- Atur efek transisi.
- Simpan presentasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah mengatur efek transisi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**Apakah saya dapat mengontrol kecepatan pemutaran transisi slide?**

Ya. Atur [speed](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) transisi menggunakan pengaturan [TransitionSpeed](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/transitionspeed/) (misalnya, slow/medium/fast).

**Apakah saya dapat melampirkan audio ke transisi dan membuatnya berulang?**

Ya. Anda dapat menyematkan suara untuk transisi dan mengontrol perilakunya melalui pengaturan seperti mode suara dan pengulangan (misalnya, [set_Sound](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), serta metadata seperti [set_SoundIsBuiltIn](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) dan [set_SoundName](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**Apa cara tercepat untuk menerapkan transisi yang sama pada setiap slide?**

Konfigurasikan jenis transisi yang diinginkan pada pengaturan transisi setiap slide; transisi disimpan per slide, sehingga menerapkan jenis yang sama pada semua slide menghasilkan hasil yang konsisten.

**Bagaimana cara memeriksa transisi mana yang saat ini diatur pada slide?**

Periksa [transition settings](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseslide/get_slideshowtransition/) slide dan baca [transition type](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/slideshowtransition/get_type/); nilai tersebut memberi tahu dengan tepat efek apa yang diterapkan.