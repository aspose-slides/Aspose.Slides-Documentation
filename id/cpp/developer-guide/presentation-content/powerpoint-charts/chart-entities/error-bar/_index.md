---
title: Sesuaikan Error Bars dalam Diagram Presentasi dengan C++
linktitle: Error Bar
type: docs
url: /id/cpp/error-bar/
keywords:
- batang kesalahan
- nilai khusus
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara menambahkan dan menyesuaikan error bars dalam diagram dengan Aspose.Slides untuk C++ — optimalkan visualisasi data dalam presentasi PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan batang kesalahan (error bars) pada diagram presentasi menggunakan Aspose.Slides. Ini menunjukkan cara menambahkan error bars ke seri diagram, mengonfigurasi pengaturan error bar X dan Y, serta menerapkan tipe nilai yang berbeda seperti nilai tetap, persentase, dan nilai khusus.

Selain itu, artikel ini menunjukkan cara menetapkan nilai error bar khusus untuk titik data individu dalam sebuah seri dengan menggunakan koleksi titik data yang bersesuaian. Selain itu, artikel mencakup catatan singkat tentang perilaku error bars saat diekspor, kompatibilitasnya dengan penanda dan label data, serta dimana menemukan kelas referensi API dan enum yang terkait.

## **Menambahkan Error Bars**
Aspose.Slides untuk C++ menyediakan API sederhana untuk mengelola nilai error bar. Kode contoh berlaku ketika menggunakan tipe nilai khusus. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data tertentu dalam koleksi **DataPoints** pada seri:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Tambahkan diagram gelembung pada slide yang diinginkan.
1. Akses seri diagram pertama dan atur format error bar X.
1. Akses seri diagram pertama dan atur format error bar Y.
1. Mengatur nilai dan format batang.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}


## **Menambahkan Custom Error Bars**
Aspose.Slides untuk C++ menyediakan API sederhana untuk mengelola nilai error bar khusus. Kode contoh berlaku ketika properti **IErrorBarsFormat.ValueType** sama dengan **Custom**. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data tertentu dalam koleksi **DataPoints** pada seri:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Tambahkan diagram gelembung pada slide yang diinginkan.
1. Akses seri diagram pertama dan atur format error bar X.
1. Akses seri diagram pertama dan atur format error bar Y.
1. Akses titik data individu pada seri diagram dan atur nilai Error Bar untuk titik data seri tersebut.
1. Mengatur nilai dan format batang.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**Apa yang terjadi pada error bars saat mengekspor presentasi ke PDF atau gambar?**

Mereka dirender sebagai bagian dari diagram dan dipertahankan selama konversi bersama dengan seluruh format diagram, dengan asumsi versi atau renderer yang kompatibel.

**Apakah error bars dapat digabungkan dengan marker dan label data?**

Ya. Error bars merupakan elemen terpisah dan kompatibel dengan marker serta label data; jika elemen saling tumpang tindih, Anda mungkin perlu menyesuaikan formatnya.

**Di mana saya dapat menemukan daftar properti dan enum untuk bekerja dengan error bars di API?**

Dalam referensi API: kelas [ErrorBarsFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/errorbarsformat/) dan enum terkait [ErrorBarType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/errorbartype/) serta [ErrorBarValueType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/errorbarvaluetype/).