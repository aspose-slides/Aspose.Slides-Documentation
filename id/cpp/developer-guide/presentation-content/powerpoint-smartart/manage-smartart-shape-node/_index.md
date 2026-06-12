---
title: "Kelola Node Bentuk SmartArt dalam Presentasi Menggunakan C++"
linktitle: "Node Bentuk SmartArt"
type: docs
weight: 30
url: /id/cpp/manage-smartart-shape-node/
keywords:
- "node SmartArt"
- "node anak"
- "tambah node"
- "posisi node"
- "akses node"
- "hapus node"
- "posisi kustom"
- "node asisten"
- "format isi"
- "render node"
- "PowerPoint"
- "presentasi"
- "C++"
- "Aspose.Slides"
description: "Kelola node bentuk SmartArt dalam file PPT dan PPTX dengan Aspose.Slides untuk C++. Dapatkan contoh kode yang jelas dan tip untuk menyederhanakan presentasi Anda."
---
## **Gambaran Umum**

Grafik SmartArt dalam presentasi PowerPoint diatur melalui node yang berisi teks dan mendefinisikan struktur diagram. Aspose.Slides memungkinkan Anda bekerja dengan node SmartArt ini secara programatis: menambahkan node dan node anak baru, menyisipkan node anak pada posisi tertentu, mengakses node yang ada, dan membaca teks, level, serta posisi mereka.

Artikel ini menjelaskan cara mengelola node bentuk SmartArt. Artikel ini menunjukkan cara menghapus node, bekerja dengan node anak berdasarkan indeks atau posisi, mengubah node asisten menjadi node normal, menyesuaikan posisi, ukuran, dan rotasi bentuk node SmartArt, mengatur format isi node, serta menghasilkan gambar thumbnail untuk node anak SmartArt.

## **Menambahkan Node SmartArt**
Aspose.Slides untuk C++ telah menyediakan API paling sederhana untuk mengelola bentuk SmartArt dengan cara termudah. Kode contoh berikut akan membantu menambahkan node dan node anak di dalam bentuk SmartArt.

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dan muat presentasi dengan Bentuk SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap bentuk di dalam slide pertama.
- Periksa apakah bentuk tersebut berjenis SmartArt dan lakukan Typecast pada bentuk yang dipilih ke SmartArt jika memang SmartArt.
- Tambahkan Node baru ke NodeCollection bentuk SmartArt dan atur teks di TextFrame.
- Sekarang, tambahkan Node Anak ke Node SmartArt yang baru ditambahkan dan atur teks di TextFrame.
- Simpan Presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Menambahkan Node SmartArt pada Posisi Tertentu**
Dalam kode contoh berikut kami menjelaskan cara menambahkan node anak yang terkait dengan node masing‑masing bentuk SmartArt pada posisi tertentu.

- Buat sebuah instance dari kelas `Presentation` .
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Tambahkan bentuk SmartArt tipe StackedList pada slide yang diakses.
- Akses node pertama dalam bentuk SmartArt yang ditambahkan.
- Sekarang, tambahkan Node Anak untuk Node yang dipilih pada posisi 2 dan atur teksnya.
- Simpan Presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **Mengakses Node SmartArt**
Kode contoh berikut akan membantu mengakses node dalam bentuk SmartArt. Harap diperhatikan bahwa Anda tidak dapat mengubah LayoutType SmartArt karena bersifat read‑only dan hanya diatur saat bentuk SmartArt ditambahkan.

- Buat sebuah instance dari kelas `Presentation` dan muat presentasi dengan Bentuk SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap bentuk di dalam slide pertama.
- Periksa apakah bentuk tersebut berjenis SmartArt dan lakukan Typecast pada bentuk yang dipilih ke SmartArt jika memang SmartArt.
- Telusuri semua Node di dalam Bentuk SmartArt.
- Akses dan tampilkan informasi seperti posisi Node SmartArt, level, dan Teks.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Mengakses Node Anak SmartArt**
Kode contoh berikut akan membantu mengakses node anak yang terkait dengan node masing‑masing bentuk SmartArt.

- Buat sebuah instance dari kelas PresentationEx dan muat presentasi dengan Bentuk SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap bentuk di dalam slide pertama.
- Periksa apakah bentuk tersebut berjenis SmartArt dan lakukan Typecast pada bentuk yang dipilih ke SmartArtEx jika memang SmartArt.
- Telusuri semua Node di dalam Bentuk SmartArt.
- Untuk setiap Node bentuk SmartArt yang dipilih, telusuri semua Node Anak di dalam node tertentu.
- Akses dan tampilkan informasi seperti posisi Node Anak, level, dan Teks.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Mengakses Node Anak SmartArt pada Posisi Tertentu**
Dalam contoh ini, kami akan belajar mengakses node anak pada posisi tertentu yang terkait dengan node masing‑masing bentuk SmartArt.

- Buat sebuah instance dari kelas `Presentation` .
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Tambahkan bentuk SmartArt tipe StackedList.
- Akses bentuk SmartArt yang ditambahkan.
- Akses node pada indeks 0 untuk bentuk SmartArt yang diakses.
- Sekarang, akses Node Anak pada posisi 1 untuk node SmartArt yang diakses menggunakan metode GetNodeByPosition().
- Akses dan tampilkan informasi seperti posisi Node Anak, level, dan Teks.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Menghapus Node SmartArt**
Dalam contoh ini, kami akan belajar menghapus node di dalam bentuk SmartArt.

- Buat sebuah instance dari kelas `Presentation` dan muat presentasi dengan Bentuk SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap bentuk di dalam slide pertama.
- Periksa apakah bentuk tersebut berjenis SmartArt dan lakukan Typecast pada bentuk yang dipilih ke SmartArt jika memang SmartArt.
- Periksa apakah SmartArt memiliki lebih dari 0 node.
- Pilih node SmartArt yang akan dihapus.
- Sekarang, hapus node yang dipilih menggunakan metode RemoveNode() * Simpan Presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Menghapus Node SmartArt pada Posisi Tertentu**
Dalam contoh ini, kami akan belajar menghapus node di dalam bentuk SmartArt pada posisi tertentu.

- Buat sebuah instance dari kelas `Presentation` dan muat presentasi dengan Bentuk SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Indeksnya.
- Telusuri setiap bentuk di dalam slide pertama.
- Periksa apakah bentuk tersebut berjenis SmartArt dan lakukan Typecast pada bentuk yang dipilih ke SmartArt jika memang SmartArt.
- Pilih node bentuk SmartArt pada indeks 0.
- Sekarang, periksa apakah node SmartArt yang dipilih memiliki lebih dari 2 node anak.
- Sekarang, hapus node pada Posisi 1 menggunakan metode RemoveNodeByPosition().
- Simpan Presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **Menetapkan Posisi Kustom untuk Node Anak SmartArt**
Sekarang Aspose.Slides mendukung pengaturan properti X dan Y SmartArtShape. Potongan kode di bawah ini menunjukkan cara mengatur posisi, ukuran, dan rotasi kustom SmartArtShape; juga harap diperhatikan bahwa penambahan node baru menyebabkan perhitungan ulang posisi dan ukuran semua node.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Memeriksa Node Asisten**
Dalam kode contoh berikut kami akan menyelidiki cara mengidentifikasi Node Asisten dalam koleksi node SmartArt dan mengubahnya.

- Buat sebuah instance dari kelas PresentationEx dan muat presentasi dengan Bentuk SmartArt.
- Dapatkan referensi slide kedua dengan menggunakan Indeksnya.
- Telusuri setiap bentuk di dalam slide pertama.
- Periksa apakah bentuk tersebut berjenis SmartArt dan lakukan Typecast pada bentuk yang dipilih ke SmartArtEx jika memang SmartArt.
- Telusuri semua node di dalam bentuk SmartArt dan periksa apakah mereka adalah Node Asisten.
- Ubah status Node Asisten menjadi node normal.
- Simpan Presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Mengatur Format Isi Node**
Aspose.Slides untuk C++ memungkinkan penambahan bentuk SmartArt kustom dan mengatur format isi mereka. Artikel ini menjelaskan cara membuat dan mengakses bentuk SmartArt serta mengatur format isi menggunakan Aspose.Slides untuk C++.

Silakan ikuti langkah‑langkah berikut:

- Buat sebuah instance dari kelas `Presentation` .
- Dapatkan referensi slide menggunakan indeksnya.
- Tambahkan bentuk SmartArt dengan mengatur LayoutType‑nya.
- Atur FillFormat untuk node bentuk SmartArt.
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **Menghasilkan Thumbnail Node Anak SmartArt**
Pengembang dapat menghasilkan thumbnail dari node anak SmartArt dengan mengikuti langkah‑langkah berikut:

1. Instansiasi kelas `Presentation` yang merepresentasikan file PPTX.
1. Tambahkan SmartArt.
1. Dapatkan referensi sebuah node dengan menggunakan Indeksnya
1. Dapatkan gambar thumbnail.
1. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Apakah animasi SmartArt didukung?**

Ya. SmartArt diperlakukan sebagai bentuk biasa, sehingga Anda dapat [menerapkan animasi standar](/slides/id/cpp/shape-animation/) (masuk, keluar, penekanan, jalur gerakan) dan menyesuaikan waktu. Anda juga dapat menganimasi bentuk di dalam node SmartArt bila diperlukan.

**Bagaimana cara saya menemukan SmartArt tertentu pada slide secara andal jika ID internalnya tidak diketahui?**

Tetapkan dan cari dengan [teks alternatif](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/set_alternativetext/). Menetapkan AltText yang khas pada SmartArt memungkinkan Anda menemukannya secara programatis tanpa bergantung pada pengenal internal.

**Apakah tampilan SmartArt akan dipertahankan saat mengonversi presentasi ke PDF?**

Ya. Aspose.Slides merender SmartArt dengan tingkat kesetiaan visual tinggi selama [ekspor PDF](/slides/id/cpp/convert-powerpoint-to-pdf/), mempertahankan tata letak, warna, dan efek.

**Apakah saya dapat mengekstrak gambar seluruh SmartArt (untuk pratinjau atau laporan)?**

Ya. Anda dapat merender bentuk SmartArt ke [format raster](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getimage/) atau ke [SVG](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/writeassvg/) untuk output vektor yang dapat diskalakan, sehingga cocok untuk thumbnail, laporan, atau penggunaan web.