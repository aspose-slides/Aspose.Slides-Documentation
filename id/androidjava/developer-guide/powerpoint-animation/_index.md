---
title: Meningkatkan Presentasi PowerPoint dengan Animasi di Android
linktitle: Animasi PowerPoint
type: docs
weight: 150
url: /id/androidjava/powerpoint-animation/
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
- animasi grafik
- animasi teks
- animasi bentuk
- animasi objek OLE
- animasi gambar
- animasi tabel
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Jelajahi kemampuan Aspose.Slides untuk Android melalui Java dalam menangani animasi PowerPoint. Ikhtisar umum ini menyoroti fitur utama."
---
## **Pendahuluan**

Karena presentasi dimaksudkan untuk menyajikan sesuatu, penampilan visual dan perilaku interaktifnya selalu dipertimbangkan selama pembuatan.

**Animasi PowerPoint** berperan penting dalam membuat presentasi menarik dan memikat penonton. Aspose.Slides menyediakan berbagai opsi untuk menambahkan animasi ke presentasi PowerPoint:

- Gunakan berbagai jenis efek animasi PowerPoint pada shape, chart, tabel, objek OLE, dan elemen presentasi lainnya.
- Gunakan beberapa efek animasi PowerPoint pada satu shape.
- Manfaatkan timeline animasi untuk mengontrol efek animasi.
- Buat animasi kustom.

Di Aspose.Slides, berbagai efek animasi dapat diterapkan pada shape. Karena setiap elemen pada slide, termasuk teks, gambar, objek OLE, dan tabel, dianggap sebagai shape, efek animasi dapat diterapkan pada elemen apa pun di slide.

## **Efek Animasi**
Aspose.Slides mendukung **lebih dari 150 efek animasi**, termasuk efek dasar seperti Bounce, PathFootball, dan Zoom, serta efek khusus seperti OLEObjectShow dan OLEObjectOpen. Anda dapat menemukan daftar lengkapnya di kelas [EffectType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/effecttype/).

Selain itu, efek animasi ini dapat digunakan bersama dengan perilaku berikut:

- [ColorEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SetEffect)

## **Animasi Kustom**

Untuk contoh Java lengkap yang membuat, memeriksa, dan mengubah perilaku serta jalur gerak yang dapat diedit, lihat [Custom Animation](/slides/id/java/custom-animation/).

Dimungkinkan untuk membuat **animasi kustom** Anda sendiri di Aspose.Slides. Hal ini dapat dicapai dengan menggabungkan beberapa perilaku menjadi animasi kustom baru.

[Behavior](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/behavior/) adalah blok bangunan efek animasi PowerPoint. Gabungkan perilaku untuk menyesuaikan efek, atau tambahkan perilaku untuk memperluas efek yang telah ditentukan. Pengulangan dikonfigurasi melalui pengaturan timing bukan melalui perilaku pengulangan terpisah.

[Animation Point](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/point/) adalah titik di mana perilaku harus diterapkan.

## **Garis Waktu Animasi**
[Sequence](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/sequence/) adalah kumpulan efek animasi yang dapat menargetkan shape yang berbeda.

[Timeline](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/animationtimeline/) adalah sekumpulan urutan yang digunakan dalam slide tertentu. Ini adalah mesin animasi yang diperkenalkan di PowerPoint 2002. Pada versi PowerPoint sebelumnya, menambahkan efek animasi ke presentasi merupakan tantangan dan hanya dapat dicapai dengan berbagai solusi kerja. Timeline menyediakan model objek yang lebih jelas untuk animasi PowerPoint. Sebuah slide hanya dapat memiliki satu timeline animasi.

## **Animasi Interaktif**
[Trigger](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/effecttriggertype/) memungkinkan Anda mendefinisikan aksi pengguna, seperti klik tombol, yang memulai animasi tertentu.

## **Animasi Shape**
Aspose.Slides memungkinkan Anda menerapkan animasi pada shape, yang dapat mencakup teks, persegi panjang, garis, bingkai, objek OLE, dan lainnya.

{{% alert color="info" title="Note" %}}
Baca selengkapnya [**Tentang Animasi Shape**](/slides/id/androidjava/shape-animation/).
{{% /alert %}}

## **Chart Animasi**
Untuk membuat chart animasi, Anda harus menggunakan kelas yang sama seperti untuk shape. Namun, animasi PowerPoint hanya dapat diterapkan pada kategori chart atau seri chart. Anda juga dapat menerapkan efek animasi pada elemen kategori atau elemen seri.

{{% alert color="info" title="Note" %}}
Baca selengkapnya [**Tentang Chart Animasi**](/slides/id/androidjava/animated-charts/).
{{% /alert %}}

## **Teks Animasi**
Selain menganimasi teks, Anda dapat menerapkan animasi pada paragraf.

{{% alert color="info" title="Note" %}}
Baca selengkapnya [**Tentang Teks Animasi**](/slides/id/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Apakah animasi akan dipertahankan saat mengekspor ke PDF?**

Tidak. PDF adalah format statis, sehingga animasi dan [slide transitions](/slides/id/androidjava/slide-transition/) tidak diputar. Jika Anda membutuhkan gerakan, ekspor ke [HTML5](/slides/id/androidjava/export-to-html5/), [animated GIF](/slides/id/androidjava/convert-powerpoint-to-animated-gif/), atau [video](/slides/id/androidjava/convert-powerpoint-to-video/) sebagai gantinya.

**Apakah saya dapat mengubah presentasi animasi menjadi video dan mengontrol frame rate serta ukuran frame?**

Ya. Anda dapat [render the presentation as frames](/slides/id/androidjava/convert-powerpoint-to-video/) dan mengenkodenya menjadi video (misalnya, melalui ffmpeg), memilih FPS dan resolusi. Animasi dan transisi slide diputar selama proses rendering.

**Apakah animasi akan tetap utuh saat bekerja dengan ODP (bukan hanya PPTX)?**

PPT, PPTX, dan ODP didukung untuk [reading](/slides/id/androidjava/open-presentation/) dan [writing](/slides/id/androidjava/save-presentation/), tetapi ini tidak menjamin preservasi animasi. Data animasi kustom dapat hilang saat mengonversi ke ODP. Lihat [Custom Animation for Java](/slides/id/java/custom-animation/) untuk contoh dan panduan memeriksa kompatibilitas format.