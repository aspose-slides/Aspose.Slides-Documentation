---
title: Sesuaikan Batang Kesalahan dalam Diagram Presentasi Menggunakan C++
linktitle: Batang Kesalahan
type: docs
url: /id/cpp/error-bar/
keywords:
- batang kesalahan
- nilai khusus
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara menambahkan dan menyesuaikan batang kesalahan dalam diagram dengan Aspose.Slides untuk C++ — optimalkan visual data dalam presentasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan batang kesalahan (error bars) pada diagram presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menambahkan batang kesalahan ke seri diagram, mengonfigurasi pengaturan batang kesalahan X dan Y, serta menerapkan berbagai tipe nilai seperti tetap, persentase, dan nilai khusus.

Artikel ini juga memperlihatkan cara menetapkan nilai batang kesalahan khusus untuk poin data individu dalam sebuah seri dengan menggunakan koleksi poin data yang bersangkutan. Selain itu, artikel ini mencakup catatan singkat tentang perilaku batang kesalahan saat diekspor, kompatibilitasnya dengan penanda (markers) dan label data, serta di mana menemukan kelas referensi API dan enum yang terkait.

## **Menambahkan Batang Kesalahan**
Aspose.Slides for C++ menyediakan API sederhana untuk mengelola nilai batang kesalahan. Kode contoh berlaku saat menggunakan tipe nilai khusus. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** pada poin data tertentu dalam koleksi **DataPoints** pada seri:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Tambahkan diagram gelembung pada slide yang diinginkan.
1. Akses seri diagram pertama dan tetapkan format batang kesalahan X.
1. Akses seri diagram pertama dan tetapkan format batang kesalahan Y.
1. Menetapkan nilai dan format batang.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Menambahkan Batang Kesalahan Khusus**
Aspose.Slides for C++ menyediakan API sederhana untuk mengelola nilai batang kesalahan khusus. Kode contoh berlaku ketika properti **IErrorBarsFormat.ValueType** sama dengan **Custom**. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** pada poin data tertentu dalam koleksi **DataPoints** pada seri:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Tambahkan diagram gelembung pada slide yang diinginkan.
1. Akses seri diagram pertama dan tetapkan format batang kesalahan X.
1. Akses seri diagram pertama dan tetapkan format batang kesalahan Y.
1. Akses poin data individu pada seri diagram dan tetapkan nilai Batang Kesalahan untuk poin data seri tersebut.
1. Menetapkan nilai dan format batang.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**Apa yang terjadi pada batang kesalahan saat mengekspor presentasi ke PDF atau gambar?**

Batang kesalahan dirender sebagai bagian dari diagram dan dipertahankan selama konversi bersama dengan format diagram lainnya, dengan asumsi versi atau renderer yang kompatibel.

**Apakah batang kesalahan dapat digabungkan dengan penanda dan label data?**

Ya. Batang kesalahan merupakan elemen terpisah dan kompatibel dengan penanda serta label data; jika elemen saling tumpang tindih, Anda mungkin perlu menyesuaikan formatnya.

**Di mana saya dapat menemukan daftar properti dan enum untuk bekerja dengan batang kesalahan dalam API?**

Di referensi API: kelas [ErrorBarsFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/errorbarsformat/) dan enum terkait [ErrorBarType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/errorbartype/) serta [ErrorBarValueType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/errorbarvaluetype/).