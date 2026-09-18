---
title: Meningkatkan Presentasi PowerPoint dengan Animasi di C++
linktitle: Animasi PowerPoint
type: docs
weight: 150
url: /id/cpp/powerpoint-animation/
keywords:
- menambahkan animasi
- memperbarui animasi
- mengubah animasi
- menghapus animasi
- mengelola animasi
- mengendalikan animasi
- efek animasi
- animasi PowerPoint
- garis waktu animasi
- animasi interaktif
- animasi kustom
- animasi bentuk
- grafik beranimasi
- teks beranimasi
- bentuk beranimasi
- objek OLE beranimasi
- gambar beranimasi
- tabel beranimasi
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengendalikan efek animasi lanjutan di Aspose.Slides untuk C++ guna membuat presentasi PowerPoint dan OpenDocument yang dinamis."
---
## **Pendahuluan**

Karena presentasi dimaksudkan untuk menyajikan sesuatu, penampilan visual dan perilaku interaktifnya selalu dipertimbangkan selama pembuatan.

**Animasi PowerPoint** berperan penting dalam membuat presentasi menarik perhatian dan melibatkan penonton. Aspose.Slides menyediakan berbagai pilihan untuk menambahkan animasi ke presentasi PowerPoint:

- Terapkan berbagai jenis efek animasi PowerPoint pada bentuk, grafik, tabel, objek OLE, dan elemen presentasi lainnya.
- Gunakan beberapa efek animasi PowerPoint pada satu bentuk.
- Manfaatkan garis waktu animasi untuk mengontrol efek animasi.
- Buat animasi khusus.

Di Aspose.Slides, berbagai efek animasi dapat diterapkan pada bentuk. Karena setiap elemen pada slide, termasuk teks, gambar, objek OLE, dan tabel, dianggap sebagai bentuk, efek animasi dapat diterapkan pada elemen apa pun di slide.

Namespace [Aspose::Slides::Animation](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/) menyediakan kelas untuk bekerja dengan animasi PowerPoint.

## **Efek Animasi**

Aspose.Slides mendukung **lebih dari 150 efek animasi**, termasuk efek dasar seperti Bounce, PathFootball, dan Zoom, serta efek khusus seperti OLEObjectShow dan OLEObjectOpen. Anda dapat menemukan daftar lengkapnya di enumerasi [EffectType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/effecttype/).

Selain itu, efek animasi ini dapat digunakan bersama dengan perilaku berikut:

- [ColorEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/seteffect/)

## **Animasi Kustom**

Untuk contoh lengkap C++ yang membuat, memeriksa, dan memodifikasi perilaku serta jalur gerak yang dapat diedit, lihat [Custom Animation](/slides/id/cpp/custom-animation/).

Dimungkinkan untuk membuat **animasi kustom** Anda sendiri di Aspose.Slides. Hal ini dapat dicapai dengan menggabungkan beberapa perilaku menjadi animasi kustom baru.

[Behavior](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/behavior/) adalah blok bangunan dari efek animasi PowerPoint. Gabungkan perilaku untuk menyesuaikan sebuah efek, atau tambahkan perilaku untuk memperluas efek yang sudah ditentukan. Pengulangan dikonfigurasi melalui pengaturan waktu bukan melalui perilaku ulang terpisah.

[Animation Point](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/point/) adalah titik dimana sebuah perilaku harus diterapkan.

## **Garis Waktu Animasi**
[Sequence](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/sequence/) adalah kumpulan efek animasi yang dapat menargetkan bentuk yang berbeda.

[IAnimationTimeLine](https://reference.aspose.com/slides/id/cpp/aspose.slides/ianimationtimeline/) adalah sekumpulan urutan yang digunakan pada slide tertentu. Ini adalah mesin animasi yang diperkenalkan di PowerPoint 2002. Pada versi PowerPoint sebelumnya, menambahkan efek animasi ke presentasi cukup sulit dan hanya dapat dicapai dengan berbagai solusi alternatif. Timeline memberikan model objek yang lebih jelas untuk animasi PowerPoint. Sebuah slide hanya dapat memiliki satu timeline animasi.

## **Animasi Interaktif**
[Trigger](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/effecttriggertype/) memungkinkan Anda mendefinisikan aksi pengguna, seperti klik tombol, yang memulai animasi tertentu.

## **Animasi Bentuk**
Aspose.Slides memungkinkan Anda menerapkan animasi pada bentuk, yang dapat mencakup teks, persegi panjang, garis, kerangka, objek OLE, dan lainnya.

{{% alert color="info" title="Note" %}}
Baca selengkapnya [**Tentang Animasi Bentuk**](/slides/id/cpp/shape-animation/).
{{% /alert %}}

## **Diagram Beranimasi**
Untuk membuat diagram beranimasi, Anda harus menggunakan kelas yang sama seperti untuk bentuk. Namun, animasi PowerPoint hanya dapat diterapkan pada kategori diagram atau seri diagram. Anda juga dapat menerapkan efek animasi pada elemen kategori atau elemen seri.

{{% alert color="info" title="Note" %}}
Baca selengkapnya [**Tentang Diagram Beranimasi**](/slides/id/cpp/animated-charts/).
{{% /alert %}}

## **Teks Beranimasi**
Selain menganimasikan teks, Anda dapat menerapkan animasi pada sebuah paragraf.

{{% alert color="info" title="Note" %}}
Baca selengkapnya [**Tentang Teks Beranimasi**](/slides/id/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Apakah animasi akan dipertahankan saat mengekspor ke PDF?**

Tidak. PDF adalah format statis, sehingga animasi dan [slide transitions](/slides/id/cpp/slide-transition/) tidak diputar. Jika Anda memerlukan gerakan, ekspor ke [HTML5](/slides/id/cpp/export-to-html5/), [animated GIF](/slides/id/cpp/convert-powerpoint-to-animated-gif/), atau [video](/slides/id/cpp/convert-powerpoint-to-video/) sebagai gantinya.

**Bisakah saya mengubah presentasi beranimasi menjadi video dan mengontrol kecepatan frame serta ukuran frame?**

Ya. Anda dapat [render presentasi sebagai frame](/slides/id/cpp/convert-powerpoint-to-video/) dan mengenkodenya menjadi video (misalnya via ffmpeg), memilih FPS dan resolusi. Animasi dan transisi slide diputar selama proses rendering.

**Apakah animasi tetap utuh saat bekerja dengan ODP (bukan hanya PPTX)?**

PPT, PPTX, dan ODP didukung untuk [reading](/slides/id/cpp/open-presentation/) dan [writing](/slides/id/cpp/save-presentation/), namun ini tidak menjamin preservasi animasi. Data animasi kustom dapat hilang saat mengonversi ke ODP. Lihat [Custom Animation](/slides/id/cpp/custom-animation/) untuk contoh dan panduan memeriksa kompatibilitas format.