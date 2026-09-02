---
title: Menggabungkan Presentasi secara Efisien di JavaScript
linktitle: Gabungkan Presentasi
type: docs
weight: 40
url: /id/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menggabungkan presentasi PowerPoint dan OpenDocument di JavaScript dengan mengkloning slide, mengontrol master dan layout, mengubah ukuran konten slide, mempertahankan section, serta menangani file yang dilindungi atau berukuran besar."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via Java menggabungkan presentasi dengan mengkloning slide dari satu [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) ke presentasi lainnya. Operasi utama adalah [SlideCollection.addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), yang dapat mempertahankan format slide sumber atau melampirkan slide yang diklon ke master atau layout di presentasi tujuan.

Artikel ini mencakup alur kerja penggabungan yang paling umum:

- menggabungkan semua slide sambil mempertahankan format sumbernya;
- menggabungkan slide yang dipilih;
- menerapkan master dari presentasi tujuan;
- menerapkan layout tertentu dari presentasi tujuan;
- menormalkan ukuran slide yang berbeda sebelum penggabungan;
- menambahkan slide yang diklon ke sebuah section;
- menggabungkan beberapa presentasi dalam satu alur kerja end‑to‑end;
- menangani master, sumber daya, catatan, komentar, media, font, kata sandi, file besar, dan masalah multithreading.

## **Bagaimana Kloning Slide Mempengaruhi Master dan Layout**

Sebuah slide mewarisi banyak tampilan dari layout dan masternya. Karena itu, overload kloning yang Anda pilih menentukan bagaimana slide yang digabung diintegrasikan ke dalam presentasi tujuan.

Gunakan [SlideCollection.addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/) dengan salah satu cara berikut:

- `addClone(sourceSlide)` — mempertahankan layout dan format slide sumber. Jika diperlukan, master sumber dapat diklon ke presentasi tujuan secara otomatis. Aspose.Slides melacak master yang diklon otomatis sehingga slide berulang yang menggunakan master sumber yang sama tidak menyebabkan master tersebut diklon berulang kali.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — melampirkan slide yang diklon ke [MasterSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/) tujuan tertentu. Aspose.Slides mencari layout yang cocok di bawah master tersebut berdasarkan tipe atau nama layout.
- `addClone(sourceSlide, destinationLayout)` — melampirkan slide yang diklon langsung ke [LayoutSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/) tujuan tertentu.

Master atau layout yang diberikan ke overload `addClone` harus berasal dari **presentasi tujuan**, bukan presentasi sumber.

## **Menggabungkan Seluruh Presentasi dan Mempertahankan Format Sumber**

Penggabungan paling sederhana menyalin setiap slide dari presentasi sumber ke presentasi tujuan. Pilihan ini tepat ketika slide yang diimpor harus mempertahankan tema, master, dan hubungan layout aslinya.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Presentasi hasil dapat berisi beberapa master bila sumber dan tujuan menggunakan desain yang berbeda. Hal ini diharapkan ketika format sumber memang ingin dipertahankan.

## **Menggabungkan Slide yang Dipilih**

Anda tidak harus mengklon setiap slide. Contoh berikut mengimpor hanya indeks slide tertentu dari presentasi sumber.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Validasikan indeks slide sebelum mengklon ketika indeks berasal dari input pengguna atau konfigurasi eksternal.

## **Menggabungkan Slide Menggunakan Master Tujuan**

Gunakan overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) ketika slide yang diimpor harus mengikuti master yang sudah ada di presentasi tujuan.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides memilih layout yang sesuai di bawah master yang ditentukan dengan mencocokkan tipe atau nama layout sumber. Jika tidak ada layout yang cocok dan `allowCloneMissingLayout` bernilai `true`, layout sumber akan diklon sehingga slide dapat ditambahkan. Jika bernilai `false`, sebuah [PptxEditException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxeditexception/) akan dilempar.

Gunakan `false` bila Anda ingin penggabungan gagal alih‑alih menambahkan layout tambahan ke master tujuan.

## **Menggabungkan Slide Menggunakan Layout Tujuan Tertentu**

Gunakan overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) ketika Anda tahu persis layout tujuan mana yang harus digunakan slide yang diimpor.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Menerapkan layout tujuan mengubah hubungan layout yang diwarisi; ini tidak meredesain konten slide sumber. Jika layout sumber dan tujuan memiliki struktur placeholder yang berbeda, periksa hasilnya untuk memastikan format dan perilaku placeholder yang diwarisi sesuai.

## **Menggabungkan Presentasi dengan Ukuran Slide Berbeda**

Presentasi dengan dimensi slide yang berbeda dapat digabung, tetapi mengklon slide ke presentasi dengan ukuran slide lain tidak secara otomatis meredesain kontennya untuk kanvas yang baru. Oleh karena itu, bentuk dapat tampak bergeser, berskala tidak terduga, atau berada di luar area slide yang terlihat.

Pendekatan yang praktis adalah mengubah ukuran presentasi sumber sebelum mengklon. Metode [SlideSize.setSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) dapat menskalakan konten yang ada sekaligus mengubah dimensi slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesizescaletype/) menskalakan konten agar pas dengan ukuran yang diminta.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Pengubahan ukuran mengubah objek presentasi sumber di memori. Jika Anda perlu mempertahankan presentasi sumber asli untuk operasi lain, buka instance terpisah untuk penggabungan.

## **Menggabungkan Slide ke Section Presentasi**

Loop dasar kloning slide tidak membuat kembali hierarki section dari presentasi sumber. Jika section penting dalam output, buat atau pilih section di presentasi tujuan dan klon slide ke dalamnya secara eksplisit dengan [addClone(Slide, Section)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Slide yang diklon ditambahkan ke section tujuan yang ditentukan. Untuk mempertahankan beberapa section sumber, buat kembali section tersebut di tujuan dan petakan setiap slide sumber ke section tujuan yang bersesuaian.

## **Menggabungkan Beberapa Presentasi dengan Aman**

Contoh end‑to‑end berikut menggunakan presentasi pertama sebagai tujuan, menormalkan ukuran slide setiap sumber tambahan, membuka tiap sumber hanya saat sedang disalin, dan menyimpan file akhir hanya sekali.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Ini merupakan baseline yang berguna untuk mempertahankan format sumber slide yang diimpor. Jika output harus menggunakan satu tema tujuan, gantilah pemanggilan sederhana `addClone(sourceSlide)` dengan overload master‑tujuan atau layout‑tujuan yang sesuai seperti yang ditunjukkan sebelumnya.

## **Pertimbangan Praktis**

### **Master, Layout, dan Kesetiaan Format**

Kloning slide default dapat secara otomatis membawa master sumber yang dibutuhkan ke presentasi tujuan. Aspose.Slides menyimpan registri internal untuk master yang diklon otomatis agar tidak mengklon master yang sama berulang kali. Master yang diklon secara manual tidak tercatat di registri tersebut, sehingga hindari pra‑kloning master kecuali Anda memerlukan kontrol eksplisit atas struktur master.

Jangan mengasumsikan bahwa dua master atau layout dengan nama yang sama visualnya identik. Jika template korporat harus mengontrol tampilan akhir, pilih master atau layout tujuan secara eksplisit dan verifikasi hasil setelah penggabungan.

### **Catatan dan Komentar**

Catatan pembicara dan komentar slide terkait dengan konten slide dan disalin ketika slide diklon. Aspose.Slides juga menyediakan API khusus untuk [presentation notes](https://docs.aspose.com/slides/id/nodejs-java/presentation-notes/) dan [presentation comments](https://docs.aspose.com/slides/id/nodejs-java/presentation-comments/).

Jika format halaman catatan penting, periksa presentasi yang digabung karena master catatan bersifat level presentasi dan mungkin berbeda antar file sumber. Untuk alur kerja review, periksa juga penulis komentar dan komentar berulir setelah menggabungkan file dari penulis atau template yang berbeda.

### **Gambar, Audio, Video, OLE, dan Tautan Eksternal**

Slide dapat merujuk ke sumber daya tingkat presentasi seperti gambar, audio tersemat, video tersemat, dan data OLE. Kloning slide secara keseluruhan, bukan hanya menyalin bentuk yang terlihat, supaya Aspose.Slides dapat mempertahankan hubungan slide dengan sumber dayanya.

Sumber daya yang tersemat dan yang ditautkan harus diperlakukan berbeda. Audio, video, objek OLE, atau hyperlink yang ditautkan tetap bergantung pada target eksternal; mengklon slide tidak mengubah tautan eksternal menjadi konten tersemat. Uji jalur dan URL sumber daya tertaut di lingkungan tempat presentasi yang digabung akan dibuka.

Aspose.Slides secara eksplisit melacak master yang diklon otomatis, tetapi ini bukan jaminan umum bahwa sumber daya biner yang identik dari presentasi sumber yang tidak terkait selalu akan dideduplicasi. Jika ukuran file output penting, inspeksi paket yang digabung dan ukur hasilnya alih‑alih mengandalkan deduplikasi implisit.

### **Font Tersemat dan Ketersediaan Font**

Font dikelola pada tingkat presentasi. Jika tipografi harus konsisten antar mesin, jangan mengasumsikan bahwa mengklon slide saja menjamin setiap font yang diperlukan tersedia di lingkungan tujuan. Anda dapat memeriksa font tersemat dengan [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) dan mengelola penyematan secara eksplisit seperti yang dijelaskan di [Embed Fonts in Presentations](https://docs.aspose.com/slides/id/nodejs-java/embedded-font/).

Juga pastikan Anda memiliki izin untuk menyematkan font yang digunakan oleh file sumber. Lisensi font dapat membatasi penyematan.

### **Presentasi yang Dilindungi Kata Sandi**

Sumber yang dilindungi kata sandi harus dibuka berhasil sebelum slidennya dapat diklon. Berikan kata sandi melalui [LoadOptions.setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Bekerja dengan presentasi yang sudah didekripsi.
} finally {
    source.dispose();
}
```

Membuka sumber yang terenkripsi tidak secara otomatis menerapkan perlindungan yang sama ke presentasi tujuan. Konfigurasikan perlindungan output secara terpisah bila diperlukan.

### **Presentasi Besar dan Penggunaan Memori**

Presentasi besar yang berisi gambar resolusi tinggi, audio, video, atau objek biner besar dapat memakan memori yang signifikan. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) menyediakan kontrol untuk penanganan BLOB dan penggunaan file sementara. Lihat [Manage Presentation BLOBs](https://docs.aspose.com/slides/id/nodejs-java/manage-blob/) untuk strategi file besar.

Untuk file besar, sebaiknya memuat dari jalur file bila memungkinkan, buang tiap presentasi sumber segera setelah selesai digabung, dan hindari menyimpan hasil antara secara berulang kecuali alur kerja memerlukan checkpoint.

### **Keamanan Thread**

Jangan memuat, menyimpan, atau mengklon instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) di beberapa thread. Operasi ini tidak didukung untuk penggunaan multithread. Jika Anda perlu memparalelkan pekerjaan penggabungan yang independen, gunakan beberapa proses single‑thread, masing‑masing dengan instance presentasi sendiri, dan ikuti [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/id/nodejs-java/multithreading/).

## **FAQ**

**Bagaimana cara mempertahankan desain asli setiap presentasi sumber?**

Gunakan [`addClone(sourceSlide)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) tanpa memberikan master atau layout tujuan. Aspose.Slides dapat secara otomatis mengklon master sumber bila diperlukan oleh slide yang diimpor.

**Bagaimana cara membuat slide yang diimpor menggunakan tema tujuan?**

Gunakan overload yang menerima master tujuan. Berikan master dari presentasi tujuan, bukan dari sumber. Aspose.Slides akan mencoba memetakan setiap slide sumber ke layout yang sesuai di bawah master tersebut.

**Kapan saya harus menggunakan layout tujuan spesifik alih‑alih master tujuan?**

Gunakan layout spesifik ketika setiap slide yang diimpor harus menggunakan satu layout yang diketahui. Gunakan master ketika Anda ingin Aspose.Slides memilih di antara layout master tersebut berdasarkan tipe atau nama layout sumber.

**Apakah presentasi dengan ukuran slide berbeda dapat digabung?**

Ya, tetapi konten slide tidak otomatis didesain ulang untuk dimensi tujuan. Ubah ukuran presentasi sumber terlebih dahulu bila Anda memerlukan penempatan yang dapat diprediksi, misalnya dengan [SlideSize.setSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) dan [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesizescaletype/).

**Bisakah saya menggabungkan presentasi PPT, PPTX, dan ODP menjadi satu file?**

Ya. Muat tiap presentasi sumber, klon slide yang diperlukan ke satu tujuan, dan simpan tujuan dalam format output yang didukung. Karena format presentasi tidak selalu mendukung set fitur yang sama, verifikasi konten kompleks setelah penggabungan lintas format. Lihat [Supported File Formats](https://docs.aspose.com/slides/id/nodejs-java/supported-file-formats/).

**Apakah section sumber dipertahankan secara otomatis?**

Tidak oleh loop dasar yang hanya mengklon slide. Buat kembali section yang diperlukan di tujuan dan gunakan overload section dari [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) ketika struktur section harus dipertahankan.

**Apakah catatan pembicara dan komentar dipertahankan?**

Mereka disalin bersama slide yang diklon. Untuk alur kerja yang bergantung pada styling master catatan, penulis komentar, atau data review berulir, verifikasi hasil gabungan karena skenario tersebut melibatkan struktur tingkat presentasi maupun konten tingkat slide.

**Apa yang terjadi pada audio, video, objek OLE, dan hyperlink?**

Konten yang tersemat dibawa sebagai bagian dari hubungan sumber daya slide yang diklon. Tautan eksternal tetap eksternal, sehingga file atau URL target harus tetap tersedia setelah penggabungan.

**Apakah font tersemat dari setiap sumber dijamin tersedia di presentasi yang digabung?**

Jangan mengandalkan kloning slide saja untuk penyebaran font. Periksa font tersemat di tujuan dan kelola penyematan font atau ketersediaan font eksternal secara eksplisit ketika tipografi penting.

**Bagaimana cara menggabungkan file yang dilindungi kata sandi?**

Buka dengan [LoadOptions.setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) yang benar, lalu klon slide-nya seperti biasa. Perlindungan output dikonfigurasikan secara terpisah.

**Bagaimana menangani presentasi yang sangat besar?**

Gunakan manajemen BLOB saat objek biner besar mendominasi penggunaan memori, pilih pemuatan dari jalur file untuk file yang sangat besar, buang presentasi sumber segera setelah selesai, dan simpan hasil akhir hanya ketika diperlukan.

**Bisakah saya menggabungkan slide dari banyak thread?**

Jangan memuat, menyimpan, atau mengklon instance presentasi di beberapa thread. Untuk pekerjaan penggabungan paralel, gunakan proses single‑thread terpisah dengan instance presentasi yang independen.