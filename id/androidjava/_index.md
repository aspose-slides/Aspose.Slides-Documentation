---
title: Aspose.Slides for Android via Java
second_title: Aspose.Slides for Android
type: docs
weight: 40
url: /id/androidjava/
keywords:
- dokumentasi
- pemrosesan presentasi
- konversi presentasi
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Mulailah di sini: tambahkan Aspose.Slides for Android via Java ke aplikasi Anda, buat presentasi pertama, dan temukan panduan untuk tugas umum, referensi API, dan dukungan."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides untuk Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java adalah pustaka kelas untuk membuat, membaca, mengedit, dan mengonversi presentasi PowerPoint dan OpenDocument dalam aplikasi Android, tanpa Microsoft PowerPoint.

Pustaka ini memuat dan menyimpan PPT, PPTX, PPS, POT, dan ODP, termasuk varian yang mendukung makro dan templat, serta mengekspor ke PDF, XPS, HTML, SVG, TIFF, Markdown, dan gambar.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Mulai</b></p>
<hr>
<p>MEMULAI</p>
<ul>
<li><a href="/slides/id/androidjava/install-aspose-slides-for-android-via-java/">Instalasi</a></li>
<li><a href="/slides/id/androidjava/create-presentation/">Buat presentasi pertama Anda</a></li>
<li><a href="/slides/id/androidjava/getting-started/">Panduan memulai</a></li>
</ul>
<p>EVALUASI</p>
<ul>
<li><a href="/slides/id/androidjava/supported-file-formats/">Format file yang didukung</a></li>
<li><a href="/slides/id/androidjava/evaluate-aspose-slides/">Batasan percobaan</a></li>
<li><a href="/slides/id/androidjava/licensing/">Lisensi</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bangun dengan Slides</b></p>
<hr>
<p>TUGAS UMUM</p>
<ul>
<li><a href="/slides/id/androidjava/open-presentation/">Buka presentasi</a></li>
<li><a href="/slides/id/androidjava/save-presentation/">Simpan presentasi</a></li>
<li><a href="/slides/id/androidjava/convert-powerpoint-to-pdf/">Konversi ke PDF</a></li>
<li><a href="/slides/id/androidjava/convert-slide/">Render slide sebagai gambar</a></li>
<li><a href="/slides/id/androidjava/manage-text/">Edit teks dan bentuk</a></li>
</ul>
<p>ALUR KERJA SLIDES</p>
<ul>
<li><a href="/slides/id/androidjava/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/id/androidjava/powerpoint-animation/">Animasi</a></li>
<li><a href="/slides/id/androidjava/manage-media-files/">Audio dan video</a></li>
<li><a href="/slides/id/androidjava/presentation-design/">Desain slide</a></li>
<li><a href="/slides/id/androidjava/merge-presentation/">Gabungkan presentasi</a></li>
</ul>
<p>CONTOH</p>
<ul>
<li><a href="/slides/id/androidjava/examples/">Contoh berdasarkan elemen slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referensi &amp; Dukungan</b></p>
<hr>
<p>REFERENSI</p>
<ul>
<li><a href="https://reference.aspose.com/slides/id/androidjava/">Referensi API</a></li>
<li><a href="https://releases.aspose.com/slides/id/androidjava/release-notes/">Catatan rilis</a></li>
<li><a href="/slides/id/androidjava/known-issues/">Masalah yang diketahui</a></li>
<li><a href="https://releases.aspose.com/slides/id/androidjava/">Unduh</a></li>
</ul>
<p>DUKUNGAN</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/id/11">Forum dukungan gratis</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk dukungan berbayar</a></li>
</ul>
</div>
</div>

------

## **Presentasi pertama Anda**

Pustaka ini berasal dari repositori Maven Aspose. Proyek Android Studio baru sudah memiliki blok `dependencyResolutionManagement` di *settings.gradle.kts*. Tambahkan baris `maven` yang ditunjukkan di bawah ke dalam blok `repositories` di dalamnya, alih-alih menempelkan blok kedua:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

Kemudian tambahkan pustaka ke *app/build.gradle.kts* dan sinkronkan proyek:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installation](/slides/id/androidjava/install-aspose-slides-for-android-via-java/) mencakup skrip build Groovy, file JAR manual, dan cara memilih versi. Kode untuk presentasi pertama Anda ada di [Create Presentations](/slides/id/androidjava/create-presentation/): kode ini menambahkan kotak teks ke sebuah slide dan menyimpan presentasi ke penyimpanan aplikasi Anda. Contoh tersebut telah dikompilasi dan dibangun menjadi APK; belum dijalankan pada perangkat. Tanpa lisensi, presentasi yang disimpan memiliki watermark evaluasi — lihat [Licensing](/slides/id/androidjava/licensing/).