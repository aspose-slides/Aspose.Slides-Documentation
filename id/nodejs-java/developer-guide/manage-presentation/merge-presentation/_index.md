---
title: Menggabungkan Presentasi Secara Efisien dengan JavaScript
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
description: "Pelajari cara menggabungkan presentasi PowerPoint dan OpenDocument dengan JavaScript dengan menyalin slide, mengontrol master dan layout, mengubah ukuran konten slide, mempertahankan section, serta menangani file yang dilindungi atau berukuran besar."
---
## **Ikhtisar**

Aspose.Slides untuk Node.js via Java menggabungkan presentasi dengan menyalin slide dari satu [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) ke yang lain. Operasi utama adalah [SlideCollection.addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), yang dapat mempertahankan format slide sumber atau melampirkan slide yang disalin ke master atau layout di presentasi tujuan.

Artikel ini mencakup alur kerja penggabungan yang paling umum:

- menggabungkan semua slide sambil mempertahankan format sumbernya;
- menggabungkan slide yang dipilih;
- menerapkan master dari presentasi tujuan;
- menerapkan layout tertentu dari presentasi tujuan;
- menormalkan ukuran slide yang berbeda sebelum menggabungkan;
- menambahkan slide yang disalin ke sebuah section;
- menggabungkan beberapa presentasi dalam satu alur kerja end‑to‑end;
- menangani master, sumber daya, catatan, komentar, media, font, kata sandi, file besar, serta masalah multithreading.

## **Bagaimana Penyalinan Slide Mempengaruhi Master dan Layout**

Sebuah slide mewarisi banyak tampilan dari layout dan master‑nya. Karena itu, overload penyalinan yang Anda pilih menentukan bagaimana slide yang digabungkan diintegrasikan ke dalam presentasi tujuan.

Gunakan [SlideCollection.addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/) dengan salah satu cara berikut:

- `addClone(sourceSlide)` — mempertahankan layout dan format slide sumber. Bila diperlukan, master sumber dapat disalin ke presentasi tujuan secara otomatis. Aspose.Slides melacak master yang disalin secara otomatis sehingga slide berulang yang menggunakan master sumber yang sama tidak menyebabkan master tersebut disalin berulang kali.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — melampirkan slide yang disalin ke [MasterSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/) tujuan tertentu. Aspose.Slides mencari layout yang cocok di bawah master tersebut berdasarkan tipe atau nama layout.
- `addClone(sourceSlide, destinationLayout)` — melampirkan slide yang disalin langsung ke [LayoutSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/) tujuan tertentu.

Master atau layout yang diberikan ke overload `addClone` harus berasal dari **presentasi tujuan**, bukan presentasi sumber.

## **Menggabungkan Seluruh Presentasi dan Mempertahankan Format Sumber**

Penggabungan paling sederhana menyalin setiap slide dari presentasi sumber ke presentasi tujuan. Pilihan ini tepat ketika slide yang diimpor harus mempertahankan tema, master, dan hubungan layout asli mereka.

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

Presentasi hasil dapat berisi beberapa master ketika sumber dan tujuan menggunakan desain yang berbeda. Hal ini diharapkan ketika format sumber sengaja dipertahankan.

## **Menggabungkan Slide yang Dipilih**

Anda tidak harus menyalin semua slide. Contoh berikut hanya mengimpor indeks slide yang dipilih dari presentasi sumber.

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

Validasikan indeks slide sebelum menyalin ketika indeks tersebut berasal dari masukan pengguna atau konfigurasi eksternal.

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

Aspose.Slides memilih layout yang sesuai di bawah master yang ditentukan dengan mencocokkan tipe atau nama layout sumber. Jika tidak ada layout yang cocok dan `allowCloneMissingLayout` bernilai `true`, layout sumber akan disalin sehingga slide dapat ditambahkan. Jika `false`, sebuah [PptxEditException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxeditexception/) akan dilempar.

Gunakan `false` ketika Anda ingin penggabungan gagal alih‑alih menambahkan layout tambahan ke master tujuan.

## **Menggabungkan Slide Menggunakan Layout Tujuan Tertentu**

Gunakan overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) ketika Anda sudah mengetahui layout tujuan mana yang harus dipakai oleh slide yang diimpor.

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

Menerapkan layout tujuan mengubah hubungan layout yang diwariskan; tidak mengubah desain konten slide sumber. Jika layout sumber dan tujuan memiliki struktur placeholder yang berbeda, periksa hasilnya untuk memastikan bahwa format yang diwariskan dan perilaku placeholder sesuai.

## **Menggabungkan Presentasi dengan Ukuran Slide Berbeda**

Presentasi dengan dimensi slide yang berbeda dapat digabungkan, tetapi menyalin slide ke presentasi dengan ukuran slide lain tidak secara otomatis mendesain ulang kontennya untuk kanvas baru. Karena itu, bentuk dapat tampak bergeser, berskala tak terduga, atau berada di luar area slide yang terlihat.

Pendekatan praktis adalah mengubah ukuran presentasi sumber sebelum menyalin. Metode [SlideSize.setSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) dapat menskalakan konten yang ada sambil mengubah dimensi slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesizescaletype/) menskalakan konten agar cocok dengan ukuran yang diminta.

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

Mengubah ukuran mengubah objek presentasi sumber di memori. Jika Anda memerlukan presentasi sumber asli tetap tidak berubah untuk operasi lain, buka instansi terpisah untuk proses penggabungan.

## **Menggabungkan Slide ke Section Presentasi**

Loop penyalinan slide dasar tidak membuat ulang hirarki section dari presentasi sumber. Jika section penting dalam output, buat atau pilih section di presentasi tujuan dan salin slide ke dalamnya secara eksplisit dengan [addClone(Slide, Section)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

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

Slide yang disalin ditambahkan ke section tujuan yang ditentukan. Untuk mempertahankan beberapa section sumber, lakukan enumerasi pada [Presentation.getSections](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSections), ambil slide saat ini dari setiap section sumber dengan [Section.getSlidesListOfSection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/section/#getSlidesListOfSection), buat ulang section tersebut di tujuan, dan salin setiap slide yang dikembalikan ke section tujuan yang bersesuaian. Lihat [Manage Slide Sections](/slides/id/nodejs-java/slide-section/) untuk contoh lengkap enumerasi section, termasuk section kosong dan perubahan struktural.

## **Menggabungkan Beberapa Presentasi dengan Aman**

Contoh end‑to‑end berikut menggunakan presentasi pertama sebagai tujuan, menormalkan ukuran slide setiap sumber tambahan, menjaga tiap sumber tetap terbuka hanya saat sedang disalin, dan menyimpan file akhir sekali saja.

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

Ini merupakan baseline yang berguna untuk mempertahankan format sumber slide yang diimpor. Jika output Anda harus menggunakan satu tema tujuan, ganti pemanggilan sederhana `addClone(sourceSlide)` dengan overload master‑tujuan atau layout‑tujuan yang ditunjukkan sebelumnya.

## **Pertimbangan Praktis**

### **Master, Layout, dan Kesetiaan Format**

Penyalinan slide default dapat secara otomatis membawa master sumber yang dibutuhkan ke presentasi tujuan. Aspose.Slides menyimpan registri internal untuk master yang disalin secara otomatis agar tidak menyalin master yang sama berulang kali. Master yang disalin secara manual tidak dicatat di registri tersebut, jadi hindari menyalin master terlebih dahulu kecuali Anda memerlukan kontrol eksplisit atas struktur master.

Jangan mengasumsikan bahwa dua master atau layout dengan nama sama secara visual identik. Jika template korporat harus mengontrol tampilan akhir, pilih master atau layout tujuan secara eksplisit dan verifikasi hasil setelah penggabungan.

### **Catatan dan Komentar**

Catatan pembicara dan komentar slide terkait dengan konten slide dan disalin ketika slide disalin. Aspose.Slides juga menyediakan API khusus untuk [presentation notes](/slides/id/nodejs-java/presentation-notes/) dan [presentation comments](/slides/id/nodejs-java/presentation-comments/).

Jika format halaman catatan penting, verifikasi presentasi yang digabung karena master catatan berada pada level presentasi dan dapat berbeda antar file sumber. Untuk alur kerja review, periksa juga penulis komentar dan komentar berulir setelah menggabungkan file dari penulis atau template yang berbeda.

### **Gambar, Audio, Video, OLE Object, dan Tautan Eksternal**

Slide dapat merujuk pada sumber daya level presentasi seperti gambar, audio tersemat, video tersemat, dan data OLE. Salin seluruh slide bukan hanya bentuk yang terlihat supaya Aspose.Slides dapat mempertahankan hubungan slide dengan sumber dayanya.

Sumber daya tersemat dan tertaut harus diperlakukan berbeda. Audio, video, OLE object, atau hyperlink yang ditautkan tetap bergantung pada target eksternal; menyalin slide tidak mengubah tautan eksternal menjadi konten tersemat. Uji jalur dan URL sumber daya tertaut dalam lingkungan tempat presentasi yang digabung akan dibuka.

Aspose.Slides secara eksplisit melacak master yang disalin otomatis, tetapi ini bukan jaminan umum bahwa sumber daya biner yang identik dari presentasi sumber yang tidak terkait akan selalu terdeduplikasi. Jika ukuran file output penting, inspeksi paket yang digabung dan ukur hasilnya alih‑alih mengandalkan deduplikasi implisit.

### **Font yang Tersemat dan Ketersediaan Font**

Font dikelola pada level presentasi. Jika tipografi harus konsisten di semua mesin, jangan mengasumsikan bahwa menyalin slide saja menjamin setiap font yang diperlukan tersedia di lingkungan tujuan. Anda dapat memeriksa font tersemat dengan [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) dan mengelola penyematan secara eksplisit sebagaimana dijelaskan di [Embed Fonts in Presentations](/slides/id/nodejs-java/embedded-font/).

Juga pastikan bahwa Anda diizinkan menyematkan font yang dipakai oleh file sumber. Lisensi font dapat membatasi penyematan.

### **Presentasi yang Dilindungi Kata Sandi**

Sumber yang dilindungi kata sandi harus dibuka berhasil sebelum slidennya dapat disalin. Berikan kata sandi melalui [LoadOptions.setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Bekerja dengan presentasi yang telah didekripsi.
} finally {
    source.dispose();
}
```

Membuka sumber yang terenkripsi tidak secara otomatis menerapkan perlindungan yang sama pada presentasi tujuan. Konfigurasikan perlindungan output secara terpisah bila diperlukan.

### **Presentasi Besar dan Penggunaan Memori**

Presentasi besar yang berisi gambar resolusi tinggi, audio, video, atau objek biner besar lainnya dapat mengonsumsi memori secara signifikan. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) menyediakan kontrol untuk penanganan BLOB dan penggunaan file sementara. Lihat [Manage Presentation BLOBs](/slides/id/nodejs-java/manage-blob/) untuk strategi file besar.

Untuk file besar, sebaiknya muat dari jalur file bila memungkinkan, buang setiap presentasi sumber segera setelah digabung, dan hindari menyimpan hasil menengah berulang kali kecuali alur kerja memerlukan checkpoint.

### **Keamanan Thread**

Jangan muat, simpan, atau salin sebuah instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) di beberapa thread. Operasi ini tidak didukung untuk penggunaan multithread. Jika Anda perlu memparallelkan pekerjaan penggabungan yang independen, gunakan beberapa proses single‑thread, masing‑masing dengan instansi presentasi sendiri, dan ikuti panduan [Aspose.Slides multithreading](/slides/id/nodejs-java/multithreading/).

## **FAQ**

**Bagaimana cara mempertahankan desain asli setiap presentasi sumber?**

Gunakan [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) tanpa menyertakan master atau layout tujuan. Aspose.Slides dapat menyalin master sumber secara otomatis ketika diperlukan oleh slide yang diimpor.

**Bagaimana cara membuat slide yang diimpor menggunakan tema tujuan?**

Gunakan overload yang menerima master tujuan. Berikan master dari presentasi tujuan, bukan dari sumber. Aspose.Slides akan mencoba memetakan setiap slide sumber ke layout yang sesuai di bawah master tersebut.

**Kapan harus menggunakan layout tujuan tertentu alih‑alih master tujuan?**

Gunakan layout tertentu ketika setiap slide yang diimpor harus memakai satu layout yang diketahui. Gunakan master ketika Anda ingin Aspose.Slides memilih di antara layout master tersebut berdasarkan tipe atau nama layout sumber.

**Apakah presentasi dengan ukuran slide berbeda dapat digabungkan?**

Ya, tetapi konten slide tidak secara otomatis didesain ulang untuk dimensi tujuan. Ubah ukuran presentasi sumber terlebih dahulu ketika Anda memerlukan penempatan yang dapat diprediksi, misalnya dengan [SlideSize.setSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) dan [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesizescaletype/).

**Bisakah saya menggabungkan presentasi PPT, PPTX, dan ODP menjadi satu file?**

Ya. Muat setiap presentasi sumber, salin slide yang diperlukan ke satu tujuan, dan simpan tujuan dalam format output yang didukung. Karena format presentasi tidak mendukung set fitur yang persis sama, verifikasi konten kompleks setelah penggabungan lintas format. Lihat [Supported File Formats](/slides/id/nodejs-java/supported-file-formats/).

**Apakah section sumber dipertahankan secara otomatis?**

Tidak oleh loop dasar yang hanya menyalin slide. Buat ulang section yang diperlukan di tujuan dan gunakan overload section dari [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) ketika struktur section harus dipertahankan.

**Apakah catatan pembicara dan komentar dipertahankan?**

Mereka disalin bersama slide yang disalin. Untuk alur kerja yang bergantung pada styling master catatan, penulis komentar, atau data review berulir, verifikasi hasil yang digabung karena skenario tersebut melibatkan struktur level presentasi serta konten level slide.

**Apa yang terjadi pada audio, video, OLE object, dan hyperlink?**

Konten tersemat dibawa sebagai bagian dari hubungan sumber daya slide yang disalin. Tautan eksternal tetap eksternal, sehingga file atau URL targetnya harus tetap tersedia setelah penggabungan.

**Apakah font tersemat dari setiap sumber dijamin tersedia di presentasi yang digabung?**

Jangan mengandalkan penyalinan slide saja untuk penyebaran font. Periksa font tersemat di tujuan dan kelola penyematan font atau ketersediaan font eksternal secara eksplisit ketika tipografi penting.

**Bagaimana cara menggabungkan file yang dilindungi kata sandi?**

Buka dengan [LoadOptions.setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) yang benar, lalu salin slide seperti biasa. Perlindungan output dikonfigurasikan secara terpisah.

**Bagaimana menangani presentasi yang sangat besar?**

Gunakan manajemen BLOB ketika objek biner besar mendominasi penggunaan memori, pilih pemuatan dari jalur file untuk file yang sangat besar, buang presentasi sumber segera setelah selesai digabung, dan simpan hasil akhir hanya saat diperlukan.

**Bisakah saya menggabungkan slide dari beberapa thread?**

Jangan muat, simpan, atau salin instance presentasi di beberapa thread. Untuk pekerjaan penggabungan paralel, gunakan proses single‑thread terpisah dan instance presentasi yang independen.