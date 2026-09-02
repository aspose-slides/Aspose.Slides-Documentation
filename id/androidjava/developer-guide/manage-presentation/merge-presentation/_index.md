---
title: Menggabungkan Presentasi secara Efisien di Android
linktitle: Gabungkan Presentasi
type: docs
weight: 40
url: /id/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Pelajari cara menggabungkan presentasi PowerPoint dan OpenDocument di Android dengan menyalin slide, mengontrol master dan tata letak, mengubah ukuran konten slide, mempertahankan bagian, serta menangani file yang dilindungi atau berukuran besar."
---
## **Ikhtisar**

Aspose.Slides for Android via Java menggabungkan presentasi dengan menyalin slide dari satu [Presentasi](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) ke yang lain. Operasi utama adalah [ISlideCollection.addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), yang dapat mempertahankan format slide sumber atau melampirkan slide yang disalin ke master atau tata letak di presentasi tujuan.

Artikel ini mencakup alur kerja penggabungan yang paling umum:

- menggabungkan semua slide sambil mempertahankan format sumbernya;
- menggabungkan slide terpilih;
- menerapkan master dari presentasi tujuan;
- menerapkan tata letak tertentu dari presentasi tujuan;
- menormalkan ukuran slide yang berbeda sebelum menggabungkan;
- menambahkan slide yang disalin ke sebuah bagian;
- menggabungkan beberapa presentasi dalam satu alur kerja end‑to‑end;
- menangani master, sumber daya, catatan, komentar, media, font, kata sandi, file besar, dan masalah multithreading.

## **Bagaimana Penyalinan Slide Mempengaruhi Master dan Tata Letak**

Sebuah slide mewarisi banyak tampilan dari tata letaknya dan masternya. Karena itu, overload penyalinan yang Anda pilih menentukan bagaimana slide yang digabungkan diintegrasikan ke dalam presentasi tujuan.

Gunakan [ISlideCollection.addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/) dengan salah satu cara berikut:

- `addClone(sourceSlide)` — mempertahankan tata letak dan format slide sumber. Jika diperlukan, master sumber dapat disalin ke presentasi tujuan secara otomatis. Aspose.Slides melacak master yang disalin secara otomatis sehingga slide berulang yang menggunakan master sumber yang sama tidak menyebabkan master tersebut disalin berulang kali.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — melampirkan slide yang disalin ke sebuah [IMasterSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslide/) tujuan tertentu. Aspose.Slides mencari tata letak yang cocok di bawah master tersebut berdasarkan tipe atau nama tata letak.
- `addClone(sourceSlide, destinationLayout)` — melampirkan slide yang disalin langsung ke sebuah [ILayoutSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/) tujuan tertentu.

Master atau tata letak yang diberikan ke overload `addClone` harus berasal dari **presentasi tujuan**, bukan presentasi sumber.

## **Menggabungkan Seluruh Presentasi dan Mempertahankan Format Sumber**

Penggabungan paling sederhana menyalin setiap slide dari presentasi sumber ke presentasi tujuan. Ini adalah pilihan yang tepat ketika slide yang diimpor harus mempertahankan tema, master, dan hubungan tata letaknya yang asli.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Presentasi yang dihasilkan mungkin berisi beberapa master ketika sumber dan tujuan menggunakan desain yang berbeda. Hal ini diharapkan ketika format sumber sengaja dipertahankan.

## **Menggabungkan Slide Terpilih**

Anda tidak harus menyalin setiap slide. Contoh berikut mengimpor hanya indeks slide terpilih dari presentasi sumber.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Validasi indeks slide sebelum menyalin ketika indeks tersebut berasal dari masukan pengguna atau konfigurasi eksternal.

## **Menggabungkan Slide Menggunakan Master Tujuan**

Gunakan overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ketika slide yang diimpor harus mengikuti master yang sudah ada di presentasi tujuan.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides memilih tata letak yang sesuai di bawah master yang ditentukan dengan mencocokkan tipe atau nama tata letak sumber. Jika tidak ada tata letak yang cocok dan `allowCloneMissingLayout` bernilai `true`, tata letak sumber akan disalin sehingga slide dapat ditambahkan. Jika `false`, sebuah [PptxEditException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxeditexception/) akan dilempar.

Gunakan `false` ketika Anda ingin penggabungan gagal alih‑alih menambahkan tata letak tambahan ke master tujuan.

## **Menggabungkan Slide Menggunakan Tata Letak Tujuan Tertentu**

Gunakan overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) ketika Anda sudah tahu tata letak tujuan mana yang harus digunakan oleh slide yang diimpor.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Menerapkan tata letak tujuan mengubah hubungan tata letak yang diwariskan; hal ini tidak meredesain konten slide sumber. Jika tata letak sumber dan tujuan memiliki struktur placeholder yang berbeda, periksa hasilnya untuk memastikan bahwa format dan perilaku placeholder yang diwariskan sesuai.

## **Menggabungkan Presentasi dengan Ukuran Slide Berbeda**

Presentasi dengan dimensi slide yang berbeda dapat digabungkan, tetapi menyalin slide ke presentasi dengan ukuran slide lain tidak secara otomatis meredesain kontennya untuk kanvas baru. Oleh karena itu bentuk dapat muncul bergeser, diskalakan secara tak terduga, atau berada di luar area slide yang terlihat.

Pendekatan praktis adalah mengubah ukuran presentasi sumber sebelum menyalin. Metode [SlideSize.setSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) dapat menskalakan konten yang ada sambil mengubah dimensi slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidesizescaletype/) menskalakan konten agar sesuai dengan ukuran yang diminta.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Mengubah ukuran mengubah objek presentasi sumber dalam memori. Jika Anda memerlukan presentasi sumber asli tetap tidak berubah untuk operasi lain, buka instance terpisah untuk penggabungan.

## **Menggabungkan Slide ke Dalam Bagian Presentasi**

Loop penyalinan slide dasar tidak membuat ulang hierarki bagian presentasi sumber. Jika bagian penting dalam output, buat atau pilih bagian di presentasi tujuan dan salin slide ke dalamnya secara eksplisit dengan [addClone(ISlide, ISection)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Slide yang disalin ditambahkan ke bagian tujuan yang ditentukan. Untuk mempertahankan beberapa bagian sumber, iterasikan [Presentation.getSections](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getSections--), ambil slide saat ini dari setiap bagian sumber dengan [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--), buat ulang bagian‑bagian tersebut di tujuan, dan salin setiap slide yang dikembalikan ke bagian tujuan yang bersesuaian. Lihat [Manage Slide Sections](/slides/id/androidjava/slide-section/) untuk contoh lengkap enumerasi bagian, termasuk bagian kosong dan perubahan struktural.

## **Menggabungkan Beberapa Presentasi dengan Aman**

Contoh end‑to‑end berikut menggunakan presentasi pertama sebagai tujuan, menormalkan ukuran slide setiap sumber tambahan, membuka tiap sumber hanya selama penyalinan, dan menyimpan file akhir sekali saja.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Ini adalah basis yang berguna untuk mempertahankan format sumber slide yang diimpor. Jika output Anda harus menggunakan satu tema tujuan, ganti pemanggilan sederhana `addClone(slide)` dengan overload master‑tujuan atau tata‑letak‑tujuan yang sesuai seperti yang ditunjukkan sebelumnya.

## **Pertimbangan Praktis**

### **Master, Tata Letak, dan Kesetiaan Format**

Penyalinan slide standar dapat secara otomatis membawa master sumber yang diperlukan ke dalam presentasi tujuan. Aspose.Slides menyimpan registri internal untuk master yang disalin secara otomatis sehingga tidak menyalin master yang sama berulang kali. Master yang disalin secara manual tidak tercatat di registri tersebut, jadi hindari menyalin master terlebih dahulu kecuali Anda memerlukan kontrol eksplisit atas struktur master.

Jangan mengasumsikan bahwa dua master atau tata letak dengan nama yang sama secara visual identik. Jika template korporat harus mengontrol tampilan akhir, pilih master atau tata letak tujuan secara eksplisit dan verifikasi hasil setelah penggabungan.

### **Catatan dan Komentar**

Catatan pembicara dan komentar slide terkait dengan konten slide dan disalin ketika slide disalin. Aspose.Slides juga menyediakan API khusus untuk [presentation notes](/slides/id/androidjava/presentation-notes/) dan [presentation comments](/slides/id/androidjava/presentation-comments/).

Jika format halaman catatan penting, verifikasi presentasi yang digabungkan karena master catatan bersifat level‑presentasi dan dapat berbeda antar file sumber. Untuk alur kerja review, verifikasi juga penulis komentar dan komentar berutas setelah menggabungkan file dari penulis atau template yang berbeda.

### **Gambar, Audio, Video, OLE Objects, dan Tautan Eksternal**

Slide dapat merujuk ke sumber daya level‑presentasi seperti gambar, audio tersemat, video tersemat, dan data OLE. Salin slide itu sendiri alih‑alih menyalin hanya bentuk yang terlihat supaya Aspose.Slides dapat mempertahankan hubungan slide dengan sumber dayanya.

Sumber daya tersemat dan tertaut harus diperlakukan berbeda. Audio, video, objek OLE, atau hyperlink yang ditautkan tetap bergantung pada target eksternal; menyalin slide tidak mengubah tautan eksternal menjadi konten tersemat. Uji jalur dan URL sumber daya tertaut di lingkungan tempat presentasi yang digabungkan akan dibuka.

Aspose.Slides secara eksplisit melacak master yang disalin secara otomatis, tetapi hal ini tidak berarti bahwa sumber daya biner identik dari presentasi sumber yang tidak terkait akan selalu didedupplikasi. Jika ukuran file output penting, inspeksi paket yang digabungkan dan ukur hasilnya alih‑alih mengandalkan deduplikasi implisit.

### **Font Tersemat dan Ketersediaan Font**

Font dikelola pada level presentasi. Jika tipografi harus konsisten di semua mesin, jangan mengasumsikan bahwa menyalin slide saja menjamin setiap font yang diperlukan tersedia di lingkungan tujuan. Anda dapat memeriksa font tersemat dengan [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) dan mengelola penyematan secara eksplisit seperti dijelaskan di [Embed Fonts in Presentations](/slides/id/androidjava/embedded-font/).

Juga pastikan Anda diperbolehkan menyematkan font yang digunakan oleh file sumber. Lisensi font dapat membatasi penyematan.

### **Presentasi yang Dilindungi Kata Sandi**

Sumber yang dilindungi kata sandi harus dibuka berhasil sebelum slide‑nya dapat disalin. Berikan kata sandi melalui [LoadOptions.setPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Bekerja dengan presentasi yang sudah didekripsi.
} finally {
    source.dispose();
}
```

Membuka sumber yang terenkripsi tidak secara otomatis menerapkan perlindungan yang sama pada presentasi tujuan. Konfigurasikan perlindungan output secara terpisah bila diperlukan.

### **Presentasi Besar dan Penggunaan Memori**

Presentasi besar yang berisi gambar resolusi tinggi, audio, video, atau objek biner besar lainnya dapat memakan memori signifikan. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) menyediakan kontrol untuk penanganan BLOB dan penggunaan file sementara. Lihat [Manage Presentation BLOBs](/slides/id/androidjava/manage-blob/) untuk strategi file besar.

Untuk file besar, lebih baik memuat dari jalur file bila memungkinkan, buang setiap presentasi sumber segera setelah selesai digabungkan, dan hindari menyimpan hasil menengah berulang kali kecuali alur kerja memerlukan checkpoint.

### **Keamanan Thread**

Jangan memuat, memodifikasi, menyimpan, atau menyalin instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) yang sama secara bersamaan dari beberapa thread. Tetapkan setiap instance presentasi ke satu operasi penggabungan. Jika Anda memparallelkan pekerjaan independen, gunakan instance presentasi yang terpisah dan ikuti panduan [Aspose.Slides multithreading](/slides/id/androidjava/multithreading/).

## **FAQ**

**Bagaimana cara mempertahankan desain asli setiap presentasi sumber?**

Gunakan [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) tanpa menyertakan master atau tata letak tujuan. Aspose.Slides dapat menyalin master sumber secara otomatis ketika diperlukan oleh slide yang diimpor.

**Bagaimana cara membuat slide yang diimpor menggunakan tema tujuan?**

Gunakan overload yang menerima master tujuan. Berikan master dari presentasi tujuan, bukan dari sumber. Aspose.Slides akan berusaha memetakan setiap slide sumber ke tata letak yang sesuai di bawah master tersebut.

**Kapan saya harus menggunakan tata letak tujuan spesifik alih‑alih master tujuan?**

Gunakan tata letak spesifik ketika setiap slide yang diimpor harus menggunakan satu tata letak yang diketahui. Gunakan master ketika Anda ingin Aspose.Slides memilih di antara tata letak master tersebut berdasarkan tipe atau nama tata letak sumber.

**Apakah presentasi dengan ukuran slide berbeda dapat digabungkan?**

Ya, tetapi konten slide tidak secara otomatis diredesain untuk dimensi tujuan. Ubah ukuran presentasi sumber terlebih dahulu ketika Anda memerlukan penempatan yang dapat diprediksi, misalnya dengan [SlideSize.setSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) dan [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidesizescaletype/).

**Dapatkah saya menggabungkan PPT, PPTX, dan ODP menjadi satu file?**

Ya. Muat masing‑masing presentasi sumber, salin slide yang diperlukan ke satu tujuan, dan simpan tujuan dalam format output yang didukung. Karena format presentasi tidak mendukung set fitur yang persis sama, verifikasi konten kompleks setelah penggabungan lintas format. Lihat [Supported File Formats](/slides/id/androidjava/supported-file-formats/).

**Apakah bagian sumber dipertahankan secara otomatis?**

Tidak oleh loop dasar yang hanya menyalin slide. Buat ulang bagian yang diperlukan di tujuan dan gunakan overload bagian dari [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) ketika struktur bagian harus dipertahankan.

**Apakah catatan pembicara dan komentar dipertahankan?**

Mereka disalin bersama slide yang disalin. Untuk alur kerja yang bergantung pada gaya master catatan, penulis komentar, atau data review berutas, verifikasi hasil gabungan karena skenario tersebut melibatkan struktur level‑presentasi serta konten level‑slide.

**Apa yang terjadi pada audio, video, OLE objects, dan hyperlink?**

Konten tersemat dibawa sebagai bagian dari hubungan sumber daya slide yang disalin. Tautan eksternal tetap eksternal, sehingga file atau URL targetnya harus tetap tersedia setelah penggabungan.

**Apakah font tersemat dari setiap sumber dijamin tersedia di presentasi gabungan?**

Jangan mengandalkan penyalinan slide saja untuk penyebaran font. Periksa font tersemat pada tujuan dan kelola penyematan font atau ketersediaan font eksternal secara eksplisit ketika tipografi penting.

**Bagaimana cara menggabungkan file yang dilindungi kata sandi?**

Buka dengan [LoadOptions.setPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) yang benar, lalu salin slide‑nya seperti biasa. Perlindungan output dikonfigurasikan secara terpisah.

**Bagaimana menangani presentasi yang sangat besar?**

Gunakan manajemen BLOB ketika objek biner besar mendominasi penggunaan memori, pilih pemuatan berbasis jalur file untuk file sangat besar, buang presentasi sumber segera setelah selesai, dan simpan hasil akhir hanya bila diperlukan.

**Dapatkah saya menggabungkan slide dari beberapa thread?**

Jangan menggunakan satu instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) secara bersamaan dari beberapa thread. Tetapkan setiap operasi penggabungan ke instance presentasi yang terpisah.