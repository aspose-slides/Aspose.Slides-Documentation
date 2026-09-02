---
title: Menggabungkan Presentasi Secara Efisien di .NET
linktitle: Gabungkan Presentasi
type: docs
weight: 40
url: /id/net/merge-presentation/
keywords:
- gabungkan PowerPoint
- gabungkan presentasi
- gabungkan slide
- gabungkan PPT
- gabungkan PPTX
- gabungkan ODP
- kombinasikan PowerPoint
- kombinasikan presentasi
- kombinasikan slide
- kombinasikan PPT
- kombinasikan PPTX
- kombinasikan ODP
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menggabungkan presentasi PowerPoint dan OpenDocument di .NET dengan mengkloning slide, mengontrol master dan tata letak, mengubah ukuran konten slide, mempertahankan bagian, serta menangani file yang dilindungi atau berukuran besar."
---
## **Gambaran Umum**

Aspose.Slides for .NET menggabungkan presentasi dengan mengkloning slide dari satu [Presentasi](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) ke presentasi lainnya. Operasi utama adalah [ISlideCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/), yang dapat mempertahankan format slide sumber atau menempelkan slide yang diklon ke master atau tata letak di presentasi tujuan.

Artikel ini mencakup alur kerja penggabungan yang paling umum:

- menggabungkan semua slide sambil mempertahankan format sumbernya;
- menggabungkan slide yang dipilih;
- menerapkan master dari presentasi tujuan;
- menerapkan tata letak tertentu dari presentasi tujuan;
- menormalkan ukuran slide yang berbeda sebelum menggabungkan;
- menambahkan slide yang diklon ke sebuah bagian;
- menggabungkan beberapa presentasi dalam satu alur kerja end-to-end;
- menangani master, sumber daya, catatan, komentar, media, font, kata sandi, file besar, dan masalah multithreading.

## **Bagaimana Kloning Slide Mempengaruhi Master dan Tata Letak**

Sebuah slide mewarisi banyak penampilannya dari tata letaknya dan masternya. Karena itu, overload kloning yang Anda pilih menentukan bagaimana slide yang digabung diintegrasikan ke dalam presentasi tujuan.

Gunakan [ISlideCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/) dengan salah satu cara berikut:

- `AddClone(sourceSlide)` — mempertahankan tata letak dan format slide sumber. Jika diperlukan, master sumber dapat diklon secara otomatis ke dalam presentasi tujuan. Aspose.Slides melacak master yang diklon secara otomatis sehingga slide berulang yang menggunakan master sumber yang sama tidak menyebabkan master tersebut diklon berulang kali.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — menempelkan slide yang diklon ke sebuah [IMasterSlide](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/) tujuan tertentu. Aspose.Slides mencari tata letak yang cocok di bawah master tersebut berdasarkan tipe atau nama tata letak.
- `AddClone(sourceSlide, destinationLayout)` — menempelkan slide yang diklon langsung ke sebuah [ILayoutSlide](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/) tujuan tertentu.

Master atau tata letak yang diteruskan ke overload `AddClone` harus berasal dari **presentasi tujuan**, bukan presentasi sumber.

## **Menggabungkan Seluruh Presentasi dan Mempertahankan Format Sumber**

Penggabungan paling sederhana menyalin setiap slide dari presentasi sumber ke presentasi tujuan. Ini adalah pilihan yang tepat ketika slide yang diimpor harus mempertahankan tema, master, dan hubungan tata letaknya yang asli.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

Presentasi yang dihasilkan mungkin berisi beberapa master ketika sumber dan tujuan menggunakan desain yang berbeda. Hal ini diharapkan ketika format sumber sengaja dipertahankan.

## **Menggabungkan Slide yang Dipilih**

Anda tidak harus mengklon setiap slide. Contoh berikut mengimpor hanya indeks slide terpilih dari presentasi sumber.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Validasi indeks slide sebelum mengklon ketika mereka berasal dari masukan pengguna atau konfigurasi eksternal.

## **Menggabungkan Slide Menggunakan Master Tujuan**

Gunakan overload [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/) ketika slide yang diimpor harus mengikuti master yang sudah ada di presentasi tujuan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides memilih tata letak yang sesuai di bawah master yang ditentukan dengan mencocokkan tipe atau nama tata letak sumber. Jika tidak ada tata letak yang cocok dan `allowCloneMissingLayout` bernilai `true`, tata letak sumber akan diklon sehingga slide dapat ditambahkan. Jika bernilai `false`, sebuah [PptxEditException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxeditexception/) dilempar.

Gunakan `false` ketika Anda ingin penggabungan gagal alih-alih menambahkan tata letak tambahan ke master tujuan.

## **Menggabungkan Slide Menggunakan Tata Letak Tujuan Tertentu**

Gunakan overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/) ketika Anda tahu persis tata letak tujuan mana yang harus digunakan oleh slide yang diimpor.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Menerapkan tata letak tujuan mengubah hubungan tata letak yang diwarisi; itu tidak merancang ulang konten slide sumber. Jika tata letak sumber dan tujuan memiliki struktur placeholder yang berbeda, periksa hasilnya untuk memastikan bahwa format yang diwarisi dan perilaku placeholder sesuai.

## **Menggabungkan Presentasi dengan Ukuran Slide Berbeda**

Presentasi dengan dimensi slide yang berbeda dapat digabung, tetapi mengklon slide ke presentasi dengan ukuran slide lain tidak secara otomatis merancang ulang kontennya untuk kanvas baru. Bentuk dapat muncul bergeser, berskala tidak terduga, atau berada di luar area slide yang terlihat.

Pendekatan praktis adalah mengubah ukuran presentasi sumber sebelum mengklon. Metode [SlideSize.SetSize](https://reference.aspose.com/slides/id/net/aspose.slides/slidesize/setsize/) dapat menskalakan konten yang ada sekaligus mengubah dimensi slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/id/net/aspose.slides/slidesizescaletype/) menskalakan konten agar pas dalam ukuran yang diminta.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Mengubah ukuran mengubah objek presentasi sumber di memori. Jika Anda memerlukan presentasi sumber asli tetap tidak berubah untuk operasi lain, buka instance terpisah untuk penggabungan.

## **Menggabungkan Slide ke Bagian Presentasi**

Loop kloning slide dasar tidak membuat kembali hierarki bagian presentasi sumber. Jika bagian penting dalam output, buat atau pilih bagian di presentasi tujuan dan klon slide ke dalamnya secara eksplisit dengan [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

Slide yang diklon ditambahkan ke bagian tujuan yang ditentukan. Untuk mempertahankan beberapa bagian sumber, enumerasikan [Presentation.Sections](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/sections/), ambil slide saat ini dari setiap bagian sumber dengan [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/id/net/aspose.slides/isection/getslideslistofsection/), buat kembali bagian-bagian tersebut di tujuan, dan klon setiap slide yang dikembalikan ke bagian tujuan yang bersesuaian. Lihat [Manage Slide Sections](/slides/id/net/slide-section/) untuk contoh enumerasi bagian lengkap, termasuk bagian kosong dan perubahan struktural.

## **Menggabungkan Beberapa Presentasi dengan Aman**

Contoh end-to-end berikut menggunakan presentasi pertama sebagai tujuan, menormalkan ukuran slide setiap sumber tambahan, mempertahankan setiap sumber tetap terbuka hanya saat sedang disalin, dan menyimpan berkas akhir sekali saja.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Ini adalah baseline yang berguna untuk mempertahankan format sumber slide yang diimpor. Jika output Anda harus menggunakan satu tema tujuan, ganti panggilan sederhana `AddClone(slide)` dengan overload master tujuan atau tata letak tujuan yang sesuai seperti yang ditunjukkan sebelumnya.

## **Pertimbangan Praktis**

### **Master, Tata Letak, dan Keakuratan Format**

Kloning slide default dapat secara otomatis membawa master sumber yang diperlukan ke dalam presentasi tujuan. Aspose.Slides menyimpan registri internal untuk master yang diklon secara otomatis agar tidak mengklon master yang sama berulang kali. Master yang diklon secara manual tidak dilacak oleh registri tersebut, jadi hindari pra‑kloning master kecuali Anda memerlukan kontrol eksplisit atas struktur master.

Jangan mengasumsikan bahwa dua master atau tata letak dengan nama yang sama secara visual setara. Jika template perusahaan harus mengontrol tampilan akhir, pilih master atau tata letak tujuan secara eksplisit dan verifikasi hasil setelah penggabungan.

### **Catatan dan Komentar**

Catatan presenter dan komentar slide terkait dengan konten slide dan disalin ketika slide diklon. Aspose.Slides juga menyediakan API khusus untuk [presentation notes](/slides/id/net/presentation-notes/) dan [presentation comments](/slides/id/net/presentation-comments/).

Jika format halaman catatan penting, verifikasi presentasi yang digabung karena master catatan bersifat level‑presentasi dan dapat berbeda antara file sumber. Untuk alur kerja tinjauan, verifikasi juga penulis komentar dan komentar bersarang setelah menggabungkan file dari penulis atau template yang berbeda.

### **Gambar, Audio, Video, OLE, dan Tautan Eksternal**

Slide dapat merujuk ke sumber daya level‑presentasi seperti gambar, audio tersemat, video tersemat, dan data OLE. Klon slide itu sendiri bukan hanya menyalin bentuk yang terlihat sehingga Aspose.Slides dapat mempertahankan hubungan slide dengan sumber dayanya.

Sumber daya yang tersemat dan yang ditautkan harus diperlakukan berbeda. Audio, video, objek OLE, atau tautan yang ditautkan tetap bergantung pada target eksternal; mengklon slide tidak mengubah tautan eksternal menjadi konten tersemat. Uji jalur dan URL sumber daya yang ditautkan di lingkungan tempat presentasi yang digabung akan dibuka.

Aspose.Slides secara eksplisit melacak master yang diklon otomatis, tetapi hal ini tidak boleh dianggap sebagai jaminan umum bahwa sumber daya biner yang identik dari presentasi sumber yang tidak berhubungan akan selalu didedupelkan. Jika ukuran file output penting, periksa paket yang digabung dan ukur hasilnya alih‑alih mengandalkan deduplikasi implisit.

### **Font Tersemat dan Ketersediaan Font**

Font dikelola pada level presentasi. Jika tipografi harus tetap konsisten di semua mesin, jangan mengasumsikan bahwa mengklon slide saja menjamin setiap font yang diperlukan tersedia di lingkungan tujuan. Anda dapat memeriksa font tersemat dengan [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/getembeddedfonts/) dan mengelola penyematan secara eksplisit sebagaimana dijelaskan di [Embed Fonts in Presentations](/slides/id/net/embedded-font/).

Juga verifikasi bahwa Anda diperbolehkan menyematkan font yang digunakan oleh file sumber. Lisensi font dapat membatasi penyematan.

### **Presentasi yang Dilindungi Kata Sandi**

Sumber yang dilindungi kata sandi harus dibuka dengan berhasil sebelum slidennya dapat diklon. Berikan kata sandi melalui [LoadOptions.Password](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Membuka sumber yang terenkripsi tidak secara otomatis menerapkan perlindungan yang sama pada presentasi tujuan. Konfigurasikan perlindungan output secara terpisah bila diperlukan.

### **Presentasi Besar dan Penggunaan Memori**

Presentasi besar yang berisi gambar resolusi tinggi, audio, video, atau objek biner besar lainnya dapat mengonsumsi memori signifikan. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/blobmanagementoptions/) menyediakan kontrol untuk penanganan BLOB dan penggunaan file sementara. Lihat [Manage Presentation BLOBs](/slides/id/net/manage-blob/) untuk strategi file besar.

Untuk file besar, lebih baik memuat dari jalur file bila memungkinkan, buang masing‑masing presentasi sumber segera setelah selesai digabung, dan hindari menyimpan hasil antara berulang kali kecuali alur kerja memerlukan titik pemeriksaan.

### **Keamanan Thread**

Jangan memuat, memodifikasi, menyimpan, atau mengklon instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) yang sama secara bersamaan dari beberapa thread. Pertahankan setiap instance presentasi terbatas pada satu operasi penggabungan. Jika Anda memparalelkan pekerjaan independen, gunakan instance presentasi yang terpisah dan ikuti panduan [Aspose.Slides multithreading](/slides/id/net/multithreading/).

## **FAQ**

**Bagaimana cara mempertahankan desain asli setiap presentasi sumber?**

Gunakan [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/) tanpa menyertakan master atau tata letak tujuan. Aspose.Slides dapat secara otomatis mengklon master sumber bila diperlukan oleh slide yang diimpor.

**Bagaimana membuat slide yang diimpor menggunakan tema tujuan?**

Gunakan overload yang menerima master tujuan. Berikan master dari presentasi tujuan, bukan dari sumber. Aspose.Slides akan mencoba memetakan setiap slide sumber ke tata letak yang sesuai di bawah master tersebut.

**Kapan sebaiknya saya menggunakan tata letak tujuan tertentu alih‑alih master tujuan?**

Gunakan tata letak tertentu ketika setiap slide yang diimpor harus menggunakan satu tata letak yang diketahui. Gunakan master ketika Anda ingin Aspose.Slides memilih di antara tata letak master tersebut berdasarkan tipe atau nama tata letak sumber.

**Apakah presentasi dengan ukuran slide berbeda dapat digabung?**

Ya, tetapi konten slide tidak secara otomatis dirancang ulang untuk dimensi tujuan. Ubah ukuran presentasi sumber terlebih dahulu ketika Anda membutuhkan penempatan yang dapat diprediksi, misalnya dengan [SlideSize.SetSize](https://reference.aspose.com/slides/id/net/aspose.slides/slidesize/setsize/) dan [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/id/net/aspose.slides/slidesizescaletype/).

**Bisakah saya menggabungkan file PPT, PPTX, dan ODP menjadi satu berkas?**

Ya. Muat setiap presentasi sumber, klon slide yang diperlukan ke satu tujuan, dan simpan tujuan dalam format output yang didukung. Karena format presentasi tidak mendukung set fitur yang persis sama, verifikasi konten kompleks setelah penggabungan lintas format. Lihat [Supported File Formats](/slides/id/net/supported-file-formats/).

**Apakah bagian sumber dipertahankan secara otomatis?**

Tidak oleh loop dasar yang hanya mengklon slide. Buat kembali bagian yang diperlukan di tujuan dan gunakan overload bagian dari [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/) ketika struktur bagian harus dipertahankan.

**Apakah catatan presenter dan komentar dipertahankan?**

Mereka disalin bersama slide yang diklon. Untuk alur kerja yang bergantung pada gaya master catatan, penulis komentar, atau data ulasan berulir, verifikasi hasil gabungan karena skenario tersebut melibatkan struktur level‑presentasi serta konten level‑slide.

**Apa yang terjadi pada audio, video, objek OLE, dan tautan?**

Konten tersemat dibawa sebagai bagian dari hubungan sumber daya slide yang diklon. Tautan eksternal tetap eksternal, sehingga file target atau URL harus tetap tersedia setelah penggabungan.

**Apakah font tersemat dari setiap sumber dijamin tersedia di presentasi yang digabung?**

Jangan bergantung pada kloning slide saja untuk penyebaran font. Periksa font tersemat di tujuan dan kelola penyematan font atau ketersediaan font eksternal secara eksplisit ketika tipografi penting.

**Bagaimana cara menggabungkan file yang dilindungi kata sandi?**

Buka dengan [LoadOptions.Password](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/password/) yang benar, kemudian klon slide-nya secara normal. Perlindungan output dikonfigurasikan secara terpisah.

**Bagaimana cara menangani presentasi yang sangat besar?**

Gunakan manajemen BLOB ketika objek biner besar mendominasi penggunaan memori, lebih pilih pemuatan berbasis jalur file untuk file sangat besar, buang presentasi sumber segera setelah selesai digabung, dan simpan hasil akhir hanya ketika diperlukan.

**Apakah saya dapat menggabungkan slide dari beberapa thread?**

Jangan menggunakan satu instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) secara bersamaan dari beberapa thread. Pertahankan setiap operasi penggabungan terisolasi pada instance presentasi masing‑masing.