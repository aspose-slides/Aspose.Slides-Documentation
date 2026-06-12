---
title: Kelola Grafik SmartArt dalam Presentasi Menggunakan C++
linktitle: Grafik SmartArt
type: docs
weight: 20
url: /id/cpp/manage-smartart-shape/
keywords:
- objek SmartArt
- grafik SmartArt
- gaya SmartArt
- warna SmartArt
- buat SmartArt
- tambahkan SmartArt
- sunting SmartArt
- ubah SmartArt
- akses SmartArt
- tipe tata letak SmartArt
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Otomatisasi pembuatan, penyuntingan, dan penataan SmartArt PowerPoint dalam C++ menggunakan Aspose.Slides, dengan contoh kode ringkas dan panduan berfokus pada kinerja."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda membuat dan mengelola grafik SmartArt dalam presentasi PowerPoint secara programatis. Artikel ini menjelaskan cara menambahkan bentuk SmartArt ke slide, mengakses bentuk SmartArt yang ada, menemukan SmartArt berdasarkan tipe tata letak tertentu, dan memperbarui penampilan visualnya dengan mengubah gaya SmartArt atau gaya warna.

Contoh-contoh menunjukkan cara bekerja dengan bentuk SmartArt melalui koleksi bentuk pada slide presentasi, memeriksa apakah sebuah bentuk merupakan SmartArt, dan kemudian memodifikasi atau memeriksa propertinya.

## **Buat Bentuk SmartArt**
Aspose.Slides untuk C++ kini memudahkan penambahan bentuk SmartArt khusus ke slide dari awal. Aspose.Slides untuk C++ menyediakan API paling sederhana untuk membuat bentuk SmartArt dengan cara termudah. Untuk membuat bentuk SmartArt dalam sebuah slide, ikuti langkah‑langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
- Dapatkan referensi slide dengan menggunakan Indeksnya.
- Tambahkan bentuk SmartArt dengan menetapkan LayoutType‑nya.
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **Akses Bentuk SmartArt pada Slide**
Kode berikut akan digunakan untuk mengakses bentuk SmartArt yang ditambahkan pada slide presentasi. Pada contoh kode kami akan menelusuri setiap bentuk di dalam slide dan memeriksa apakah itu bentuk SmartArt. Jika bentuk tersebut berjenis SmartArt, kami akan melakukan typecast ke instance SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Akses Bentuk SmartArt dengan Tipe Tata Letak Tertentu**
Kode contoh berikut membantu mengakses bentuk SmartArt dengan LayoutType tertentu. Harap dicatat bahwa LayoutType SmartArt tidak dapat diubah karena bersifat read‑only dan hanya ditetapkan saat bentuk SmartArt ditambahkan.

- Buat instance kelas `Presentation` dan muat presentasi yang berisi Bentuk SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap bentuk di dalam slide pertama.
- Periksa apakah bentuk tersebut berjenis SmartArt dan lakukan typecast ke SmartArt jika memang SmartArt.
- Periksa bentuk SmartArt dengan LayoutType tertentu dan lakukan tindakan yang diperlukan selanjutnya.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **Ubah Gaya Bentuk SmartArt**
Kode contoh berikut membantu mengakses bentuk SmartArt dengan LayoutType tertentu.

- Buat instance kelas `Presentation` dan muat presentasi yang berisi Bentuk SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap bentuk di dalam slide pertama.
- Periksa apakah bentuk tersebut berjenis SmartArt dan lakukan typecast ke SmartArt jika memang SmartArt.
- Temukan bentuk SmartArt dengan Gaya tertentu.
- Tetapkan Gaya baru untuk bentuk SmartArt.
- Simpan Presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **Ubah Gaya Warna Bentuk SmartArt**
Pada contoh ini, kami akan mempelajari cara mengubah gaya warna untuk bentuk SmartArt apa pun. Kode contoh berikut akan mengakses bentuk SmartArt dengan gaya warna tertentu dan mengubah gayanya.

- Buat instance kelas `Presentation` dan muat presentasi yang berisi Bentuk SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap bentuk di dalam slide pertama.
- Periksa apakah bentuk tersebut berjenis SmartArt dan lakukan typecast ke SmartArt jika memang SmartArt.
- Temukan bentuk SmartArt dengan Gaya Warna tertentu.
- Tetapkan Gaya Warna baru untuk bentuk SmartArt.
- Simpan Presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**Apakah saya dapat memberi animasi pada SmartArt sebagai satu objek?**

Ya. SmartArt adalah bentuk, sehingga Anda dapat menerapkan [standard animations](/slides/id/cpp/powerpoint-animation/) melalui API animasi (masuk, keluar, penekanan, jalur gerak) seperti pada bentuk lainnya.

**Bagaimana cara menemukan SmartArt tertentu pada slide jika saya tidak tahu ID internalnya?**

Tetapkan dan gunakan Teks Alternatif (AltText) lalu cari bentuk berdasarkan nilai tersebut—ini merupakan cara yang direkomendasikan untuk menemukan bentuk target.

**Apakah saya dapat mengelompokkan SmartArt dengan bentuk lain?**

Ya. Anda dapat mengelompokkan SmartArt dengan bentuk lain (gambar, tabel, dll.) dan kemudian [manipulate the group](/slides/id/cpp/group/).

**Bagaimana cara mendapatkan gambar dari SmartArt tertentu (misalnya untuk pratinjau atau laporan)?**

Ekspor thumbnail/gambar bentuk; perpustakaan dapat [render individual shapes](/slides/id/cpp/create-shape-thumbnails/) ke file raster (PNG/JPG/TIFF).

**Apakah tampilan SmartArt akan dipertahankan saat mengonversi seluruh presentasi ke PDF?**

Ya. Mesin rendering menargetkan kesetiaan tinggi untuk [PDF export](/slides/id/cpp/convert-powerpoint-to-pdf/), dengan berbagai opsi kualitas dan kompatibilitas.