---
title: Bentuk Grup Presentasi di C++
linktitle: Grup Bentuk
type: docs
weight: 40
url: /id/cpp/group/
keywords:
- bentuk grup
- grup bentuk
- menambahkan grup
- teks alternatif
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengelompokkan dan memisahkan kelompok bentuk dalam deck PowerPoint menggunakan Aspose.Slides untuk C++ — panduan cepat langkah demi langkah dengan kode C++ gratis."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan bentuk grup di Aspose.Slides. Artikel ini menunjukkan cara menambahkan bentuk grup ke slide, menempatkan bentuk di dalamnya, dan menyimpan presentasi yang telah diperbarui. Artikel ini juga memperlihatkan cara mengakses bentuk yang disimpan di dalam grup dan membaca nilai `AlternativeText`-nya. Selain itu, artikel ini secara singkat membahas kemampuan bentuk grup terkait seperti grup bersarang, z-order, dan opsi penguncian.

## **Menambahkan Bentuk Grup**
Aspose.Slides mendukung pekerjaan dengan bentuk grup pada slide. Fitur ini membantu pengembang membuat presentasi yang lebih kaya. Aspose.Slides untuk C++ mendukung penambahan atau akses bentuk grup. Dimungkinkan untuk menambahkan bentuk ke dalam bentuk grup yang sudah ditambahkan untuk mengisinya atau mengakses properti apa pun dari bentuk grup. Untuk menambahkan bentuk grup ke slide menggunakan Aspose.Slides untuk C++:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide dengan menggunakan Index‑nya.
1. Tambahkan bentuk grup ke slide.
1. Tambahkan bentuk‑bentuk ke dalam bentuk grup yang telah ditambahkan.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Contoh di bawah menambahkan bentuk grup ke slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Mengakses Properti AltText**
Topik ini menunjukkan langkah‑langkah sederhana, lengkap dengan contoh kode, untuk menambahkan bentuk grup dan mengakses properti AltText dari bentuk grup pada slide. Untuk mengakses AltText dari bentuk grup di slide menggunakan Aspose.Slides untuk C++:

1. Instansiasikan kelas `Presentation` yang mewakili file PPTX.
1. Dapatkan referensi slide dengan menggunakan Index‑nya.
1. Akses koleksi bentuk pada slide.
1. Akses bentuk grup.
1. Akses properti AltText.

Contoh di bawah mengakses teks alternatif dari bentuk grup.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**Apakah pengelompokan bersarang (sebuah grup di dalam grup) didukung?**

Ya. [GroupShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/groupshape/) memiliki metode [get_ParentGroup](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/get_parentgroup/) yang secara langsung menunjukkan dukungan hierarki (sebuah grup dapat menjadi anak dari grup lain).

**Bagaimana cara mengontrol z-order grup relatif terhadap objek lain di slide?**

Gunakan [Z-Order position](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/get_zorderposition/) milik [GroupShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/groupshape/) untuk memeriksa posisinya dalam tumpukan tampilan.

**Apakah saya dapat mencegah pemindahan/pengeditan/pengelompokan kembali?**

Ya. Bagian penguncian grup diekspose melalui [get_GroupShapeLock](https://reference.aspose.com/slides/id/cpp/aspose.slides/groupshape/get_groupshapelock/), yang memungkinkan Anda membatasi operasi pada objek.