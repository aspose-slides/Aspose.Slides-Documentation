---
title: Animasi Diagram PowerPoint di C++
linktitle: Diagram Animasi
type: docs
weight: 80
url: /id/cpp/animated-charts/
keywords:
- diagram
- diagram animasi
- animasi diagram
- seri diagram
- kategori diagram
- elemen seri
- elemen kategori
- tambahkan efek
- tipe efek
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Buat diagram animasi yang menakjubkan di C++ dengan Aspose.Slides. Tingkatkan presentasi dengan visual dinamis dalam file PPT dan PPTX—mulai sekarang."
---
## **Pendahuluan**

Aspose.Slides mendukung animasi elemen diagram. **Series**, **Categories**, **Series Elements**, **Categories Elements** dapat dianimasikan dengan metode [ISequence::AddEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/isequence/addeffect/) dan dua enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/effectchartmajorgroupingtype/) serta [EffectChartMinorGroupingType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/effectchartminorgroupingtype/).

## **Animasi Seri Diagram**
Jika Anda ingin menganimasi seri diagram, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.  
2. Dapatkan referensi objek diagram.  
3. Animasi seri.  
4. Tulis file presentasi ke disk.

Pada contoh di bawah, kami menganimasi seri diagram.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animasi pada Elemen Seri**
Jika Anda ingin menganimasi elemen seri, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.  
2. Dapatkan referensi objek diagram.  
3. Animasi elemen seri.  
4. Tulis file presentasi ke disk.

Pada contoh di bawah, kami telah menganimasi elemen seri.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Animasi Kategori Diagram**
Jika Anda ingin menganimasi kategori diagram, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.  
2. Dapatkan referensi objek diagram.  
3. Animasi Kategori.  
4. Tulis file presentasi ke disk.

Pada contoh di bawah, kami menganimasi kategori diagram.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animasi pada Elemen Kategori**
Jika Anda ingin menganimasi elemen kategori, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.  
2. Dapatkan referensi objek diagram.  
3. Animasi elemen kategori.  
4. Tulis file presentasi ke disk.

Pada contoh di bawah, kami telah menganimasi elemen kategori.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **FAQ**

**Apakah jenis efek yang berbeda (mis., masuk, penekanan, keluar) didukung untuk diagram seperti pada bentuk biasa?**

Ya. Diagram diperlakukan sebagai bentuk, sehingga mendukung jenis efek animasi standar, termasuk masuk, penekanan, dan keluar, dengan kontrol penuh melalui timeline slide dan urutan animasi.

**Bisakah saya menggabungkan animasi diagram dengan transisi slide?**

Ya. [Transitions](/slides/id/cpp/slide-transition/) diterapkan pada slide, sementara efek animasi diterapkan pada objek di dalam slide. Anda dapat menggunakan keduanya secara bersamaan dalam satu presentasi dan mengontrolnya secara terpisah.

**Apakah animasi diagram dipertahankan saat menyimpan ke PPTX?**

Ya. Ketika Anda [save to PPTX](/slides/id/cpp/save-presentation/), semua efek animasi dan urutannya dipertahankan karena menjadi bagian dari model animasi asli presentasi.

**Bisakah saya membaca animasi diagram yang ada dari sebuah presentasi dan memodifikasinya?**

Ya. [API](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/) memberikan akses ke timeline slide, urutan, dan efek, memungkinkan Anda memeriksa animasi diagram yang ada dan menyesuaikannya tanpa harus membuat semuanya kembali dari awal.

**Bisakah saya menghasilkan video yang menyertakan animasi diagram menggunakan Aspose.Slides?**

Ya. Anda dapat [export a presentation to video](/slides/id/cpp/convert-powerpoint-to-video/) sambil mempertahankan animasi, mengatur waktu dan pengaturan ekspor lainnya sehingga klip yang dihasilkan mencerminkan pemutaran animasi.