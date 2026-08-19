---
title: Menggabungkan Presentasi Secara Efisien di Android
linktitle: Menggabungkan Presentasi
type: docs
weight: 40
url: /id/androidjava/merge-presentation/
keywords:
- menggabungkan PowerPoint
- menggabungkan presentasi
- menggabungkan slide
- menggabungkan PPT
- menggabungkan PPTX
- menggabungkan ODP
- menggabungkan PowerPoint
- menggabungkan presentasi
- menggabungkan slide
- menggabungkan PPT
- menggabungkan PPTX
- menggabungkan ODP
- Android
- Java
- Aspose.Slides
description: "Pelajari cara menggabungkan presentasi PowerPoint dan OpenDocument di Android dengan menyalin slide, mengontrol master dan layout, mengubah ukuran konten slide, mempertahankan bagian, serta menangani file yang dilindungi atau berukuran besar."
---
## **Ikhtisar**

Aspose.Slides for Android via Java menggabungkan presentasi dengan menyalin slide dari satu [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) ke yang lain. Operasi utama adalah [ISlideCollection.addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), yang dapat mempertahankan format slide sumber atau menempelkan slide yang disalin ke master atau layout dalam presentasi tujuan.

Artikel ini mencakup alur kerja penggabungan yang paling umum:

- menggabungkan semua slide sambil mempertahankan format sumbernya;
- menggabungkan slide yang dipilih;
- menerapkan master dari presentasi tujuan;
- menerapkan layout tertentu dari presentasi tujuan;
- menormalkan ukuran slide yang berbeda sebelum menggabungkan;
- menambahkan slide yang disalin ke sebuah bagian;
- menggabungkan beberapa presentasi dalam satu alur kerja end-to-end;
- menangani master, sumber daya, catatan, komentar, media, font, kata sandi, file besar, dan masalah multithreading.

## **Bagaimana Penyalinan Slide Mempengaruhi Master dan Layout**

Sebuah slide mewarisi banyak penampilannya dari layout dan master. Karena itu, overload penyalinan yang Anda pilih menentukan bagaimana slide yang digabungkan diintegrasikan ke dalam presentasi tujuan.

Gunakan [ISlideCollection.addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/) dengan salah satu cara berikut:

- `addClone(sourceSlide)` — mempertahankan layout dan format slide sumber. Jika diperlukan, master sumber dapat disalin secara otomatis ke dalam presentasi tujuan. Aspose.Slides melacak master yang disalin secara otomatis sehingga slide berulang yang menggunakan master sumber yang sama tidak menyebabkan master tersebut disalin berulang kali.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — menempelkan slide yang disalin ke [IMasterSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslide/) tujuan tertentu. Aspose.Slides mencari layout yang cocok di bawah master tersebut berdasarkan tipe atau nama layout.
- `addClone(sourceSlide, destinationLayout)` — menempelkan slide yang disalin langsung ke [ILayoutSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/) tujuan tertentu.

Master atau layout yang diberikan ke overload `addClone` harus berasal dari presentasi **tujuan**, bukan presentasi sumber.

## **Gabungkan Seluruh Presentasi dan Pertahankan Format Sumber**

Penggabungan paling sederhana menyalin setiap slide dari presentasi sumber ke presentasi tujuan. Ini adalah pilihan yang tepat ketika slide yang diimpor harus mempertahankan tema, master, dan hubungan layout asli mereka.

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

## **Gabungkan Slide yang Dipilih**

Anda tidak harus menyalin setiap slide. Contoh berikut mengimpor hanya indeks slide yang dipilih dari presentasi sumber.

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

Validasi indeks slide sebelum menyalin ketika mereka berasal dari masukan pengguna atau konfigurasi eksternal.

## **Gabungkan Slide Menggunakan Master Tujuan**

Gunakan overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ketika slide yang diimpor harus mengikuti master yang sudah ada di dalam presentasi tujuan.

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

Aspose.Slides memilih layout yang sesuai di bawah master yang ditentukan dengan mencocokkan tipe atau nama layout sumber. Jika tidak ada layout yang cocok dan `allowCloneMissingLayout` bernilai `true`, layout sumber disalin sehingga slide dapat ditambahkan. Jika bernilai `false`, [PptxEditException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxeditexception/) dilempar.

Gunakan `false` ketika Anda ingin penggabungan gagal alih-alih menambahkan layout tambahan ke master tujuan.

## **Gabungkan Slide Menggunakan Layout Tujuan Spesifik**

Gunakan overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) ketika Anda tahu persis layout tujuan mana yang harus digunakan oleh slide yang diimpor.

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

Menerapkan layout tujuan mengubah hubungan layout yang diwariskan; hal ini tidak mendesain ulang konten slide sumber. Jika layout sumber dan tujuan memiliki struktur placeholder yang berbeda, periksa hasilnya untuk memastikan bahwa format yang diwariskan dan perilaku placeholder sesuai.

## **Gabungkan Presentasi dengan Ukuran Slide Berbeda**

Presentasi dengan dimensi slide yang berbeda dapat digabungkan, tetapi menyalin slide ke dalam presentasi dengan ukuran slide lain tidak secara otomatis mendesain ulang kontennya untuk kanvas baru. Oleh karena itu, bentuk dapat tampak bergeser, berskala tidak terduga, atau berada di luar area slide yang terlihat.

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

Mengubah ukuran mengubah objek presentasi sumber di memori. Jika Anda memerlukan presentasi sumber asli tetap tidak berubah untuk operasi lain, buka instansi terpisah untuk penggabungan.

## **Gabungkan Slide ke dalam Bagian Presentasi**

Loop penyalinan slide dasar tidak merekonstruksi hierarki bagian dari presentasi sumber. Jika bagian penting dalam output, buat atau pilih bagian di presentasi tujuan dan salin slide ke dalamnya secara eksplisit dengan [addClone(ISlide, ISection)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Slide yang disalin ditambahkan ke bagian tujuan yang ditentukan. Untuk mempertahankan beberapa bagian sumber, buat ulang bagian tersebut di presentasi tujuan dan petakan setiap slide sumber ke bagian tujuan yang sesuai.

## **Gabungkan Banyak Presentasi dengan Aman**

Contoh end-to-end berikut menggunakan presentasi pertama sebagai tujuan, menormalkan ukuran slide setiap sumber tambahan, menjaga setiap sumber tetap terbuka hanya saat disalin, dan menyimpan file akhir sekali saja.

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

Ini merupakan baseline yang berguna untuk mempertahankan format sumber slide yang diimpor. Jika output Anda harus menggunakan satu tema tujuan, gantilah pemanggilan sederhana `addClone(slide)` dengan overload master tujuan atau layout tujuan yang sesuai seperti yang ditunjukkan sebelumnya.

## **Pertimbangan Praktis**

### **Master, Layout, dan Keakuratan Format**

Penyalinan slide default dapat secara otomatis membawa master sumber yang diperlukan ke dalam presentasi tujuan. Aspose.Slides menyimpan registri internal untuk master yang disalin secara otomatis agar tidak menyalin master yang sama berulang kali. Master yang disalin secara manual tidak dilacak oleh registri tersebut, jadi hindari menyalin master sebelumnya kecuali Anda memerlukan kontrol eksplisit atas struktur master.

Jangan menganggap dua master atau layout dengan nama yang sama secara visual setara. Jika template perusahaan harus mengontrol tampilan akhir, pilih master atau layout tujuan secara eksplisit dan verifikasi hasil setelah penggabungan.

### **Catatan dan Komentar**

Catatan pembicara dan komentar slide terkait dengan konten slide dan disalin ketika slide disalin. Aspose.Slides juga menyediakan API khusus untuk [presentation notes](https://docs.aspose.com/slides/id/androidjava/presentation-notes/) dan [presentation comments](https://docs.aspose.com/slides/id/androidjava/presentation-comments/).

Jika format halaman catatan penting, verifikasi presentasi yang digabung karena master catatan bersifat tingkat presentasi dan dapat berbeda antara file sumber. Untuk alur kerja peninjauan, verifikasi juga penulis komentar dan komentar berulir setelah menggabungkan file dari penulis atau template yang berbeda.

### **Gambar, Audio, Video, Objek OLE, dan Tautan Eksternal**

Slide dapat merujuk pada sumber daya tingkat presentasi seperti gambar, audio tersemat, video tersemat, dan data OLE. Salin slide itu sendiri alih-alih hanya menyalin bentuk yang terlihat sehingga Aspose.Slides dapat menjaga hubungan slide dengan sumber dayanya.

Sumber daya tersemat dan tertaut harus diperlakukan berbeda. Audio, video, objek OLE, atau hyperlink yang tertaut tetap bergantung pada target eksternal; menyalin slide tidak mengubah tautan eksternal menjadi konten tersemat. Uji jalur dan URL sumber daya tertaut dalam lingkungan tempat presentasi yang digabung akan dibuka.

Aspose.Slides secara eksplisit melacak master yang disalin secara otomatis, tetapi hal ini tidak boleh dianggap sebagai jaminan umum bahwa sumber daya biner identik dari presentasi sumber yang tidak terkait selalu akan didedupikasi. Jika ukuran file output penting, inspeksi paket yang digabung dan ukur hasilnya alih-alih mengandalkan deduplikasi implisit.

### **Font yang Di-embed dan Ketersediaan Font**

Font dikelola pada tingkat presentasi. Jika tipografi harus tetap konsisten di semua mesin, jangan menganggap bahwa menyalin slide saja menjamin semua font yang diperlukan tersedia di lingkungan tujuan. Anda dapat memeriksa font yang di-embed dengan [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) dan mengelola embedding secara eksplisit seperti yang dijelaskan dalam [Embed Fonts in Presentations](https://docs.aspose.com/slides/id/androidjava/embedded-font/).

Juga verifikasi bahwa Anda diperbolehkan untuk meng-embed font yang digunakan oleh file sumber. Lisensi font dapat membatasi embedding.

### **Presentasi yang Dilindungi Password**

Sumber yang dilindungi password harus dibuka dengan sukses sebelum slidennya dapat disalin. Berikan password melalui [LoadOptions.setPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Bekerja dengan presentasi yang telah didekripsi.
} finally {
    source.dispose();
}
```

Membuka sumber yang dienkripsi tidak secara otomatis menerapkan perlindungan yang sama ke presentasi tujuan. Konfigurasikan perlindungan output secara terpisah bila diperlukan.

### **Presentasi Besar dan Penggunaan Memori**

Presentasi besar yang berisi gambar resolusi tinggi, audio, video, atau objek biner besar lainnya dapat mengonsumsi memori yang signifikan. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) menyediakan kontrol untuk penanganan BLOB dan penggunaan file sementara. Lihat [Manage Presentation BLOBs](https://docs.aspose.com/slides/id/androidjava/manage-blob/) untuk strategi file besar.

Untuk file besar, lebih baik memuat dari jalur file bila memungkinkan, buang setiap presentasi sumber segera setelah selesai digabung, dan hindari menyimpan hasil antara berulang kali kecuali alur kerja memerlukan checkpoint.

### **Keamanan Thread**

Jangan memuat, memodifikasi, menyimpan, atau menyalin instansi [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) yang sama secara bersamaan dari beberapa thread. Jaga setiap instansi presentasi terbatas pada satu operasi penggabungan. Jika Anda memparallelkan pekerjaan independen, gunakan instansi presentasi yang terpisah dan ikuti [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/id/androidjava/multithreading/).

## **FAQ**

**Bagaimana cara saya menjaga desain asli setiap presentasi sumber?**

Gunakan `addClone(sourceSlide)` tanpa menyediakan master atau layout tujuan. Aspose.Slides dapat menyalin master sumber secara otomatis ketika diperlukan oleh slide yang diimpor.

**Bagaimana cara membuat slide yang diimpor menggunakan tema tujuan?**

Gunakan overload yang menerima master tujuan. Berikan master dari presentasi tujuan, bukan dari sumber. Aspose.Slides akan mencoba memetakan setiap slide sumber ke layout yang sesuai di bawah master tersebut.

**Kapan saya harus menggunakan layout tujuan spesifik alih-alih master tujuan?**

Gunakan layout spesifik ketika setiap slide yang diimpor harus menggunakan satu layout yang diketahui. Gunakan master ketika Anda ingin Aspose.Slides memilih di antara layout master tersebut berdasarkan tipe atau nama layout sumber.

**Apakah presentasi dengan ukuran slide berbeda dapat digabungkan?**

Ya, tetapi konten slide tidak secara otomatis didesain ulang untuk dimensi tujuan. Ubah ukuran presentasi sumber terlebih dahulu ketika Anda memerlukan penempatan yang dapat diprediksi, misalnya dengan [SlideSize.setSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) dan [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidesizescaletype/).

**Dapatkah saya menggabungkan presentasi PPT, PPTX, dan ODP menjadi satu file?**

Ya. Muat setiap presentasi sumber, salin slide yang diperlukan ke satu tujuan, dan simpan tujuan dalam format output yang didukung. Karena format presentasi tidak mendukung set fitur yang persis sama, verifikasi konten kompleks setelah penggabungan lintas format. Lihat [Supported File Formats](https://docs.aspose.com/slides/id/androidjava/supported-file-formats/).

**Apakah bagian sumber dipertahankan secara otomatis?**

Tidak dengan loop dasar yang hanya menyalin slide. Buat ulang bagian yang diperlukan di tujuan dan gunakan overload bagian dari [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) ketika struktur bagian harus dipertahankan.

**Apakah catatan pembicara dan komentar dipertahankan?**

Mereka disalin bersama slide yang disalin. Untuk alur kerja yang bergantung pada stilisasi master catatan, penulis komentar, atau data ulasan berulir, verifikasi hasil gabungan karena skenario tersebut melibatkan struktur tingkat presentasi serta konten tingkat slide.

**Apa yang terjadi pada audio, video, objek OLE, dan hyperlink?**

Konten tersemat dibawa sebagai bagian dari hubungan sumber daya slide yang disalin. Tautan eksternal tetap eksternal, sehingga file atau URL target harus tetap tersedia setelah penggabungan.

**Apakah font yang di-embed dari setiap sumber dijamin tersedia dalam presentasi gabungan?**

Jangan mengandalkan penyalinan slide saja untuk penyebaran font. Periksa font yang di-embed di tujuan dan kelola embedding font secara eksplisit atau pastikan ketersediaan font eksternal ketika tipografi penting.

**Bagaimana cara menggabungkan file yang dilindungi password?**

Buka file dengan [LoadOptions.setPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) yang benar, lalu salin slide-nya secara normal. Perlindungan output dikonfigurasikan secara terpisah.

**Bagaimana saya harus menangani presentasi yang sangat besar?**

Gunakan manajemen BLOB ketika objek biner besar mendominasi penggunaan memori, lebih suka memuat dari jalur file untuk file sangat besar, buang presentasi sumber segera setelah selesai digabung, dan simpan hasil akhir hanya bila diperlukan.

**Dapatkah saya menggabungkan slide dari beberapa thread?**

Jangan menggunakan satu instansi [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) secara bersamaan dari beberapa thread. Jaga setiap operasi penggabungan terisolasi pada instansi presentasi masing-masing.