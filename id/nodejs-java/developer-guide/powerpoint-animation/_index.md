---
title: Tingkatkan Presentasi PowerPoint dengan Animasi dalam JavaScript
linktitle: Animasi PowerPoint
type: docs
weight: 150
url: /id/nodejs-java/powerpoint-animation/
keywords:
- tambahkan animasi
- perbarui animasi
- ubah animasi
- hapus animasi
- kelola animasi
- kontrol animasi
- efek animasi
- animasi PowerPoint
- timeline animasi
- animasi interaktif
- animasi kustom
- animasi bentuk
- diagram beranimasi
- teks beranimasi
- bentuk beranimasi
- objek OLE beranimasi
- gambar beranimasi
- tabel beranimasi
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Gunakan Aspose.Slides untuk Node.js via Java untuk menangani animasi PowerPoint. Ikhtisar ini menyoroti fitur utama dan memberikan wawasan untuk meningkatkan presentasi Anda."
---
## **Pendahuluan**

Karena presentasi dimaksudkan untuk menyajikan sesuatu, tampilan visual dan perilaku interaktifnya selalu dipertimbangkan selama pembuatan.

**PowerPoint animation** memainkan peran penting dalam membuat presentasi menarik perhatian dan melibatkan penonton. Aspose.Slides for Node.js via Java menyediakan berbagai pilihan untuk menambahkan animasi ke presentasi PowerPoint:

- Terapkan berbagai jenis efek animasi PowerPoint pada bentuk, diagram, tabel, objek OLE, dan elemen presentasi lainnya.
- Gunakan banyak efek animasi PowerPoint pada satu bentuk.
- Manfaatkan timeline animasi untuk mengontrol efek animasi.
- Buat animasi kustom.

Di Aspose.Slides for Node.js via Java, berbagai efek animasi dapat diterapkan pada bentuk. Karena setiap elemen pada slide, termasuk teks, gambar, objek OLE, dan tabel, dianggap sebagai bentuk, efek animasi dapat diterapkan pada elemen apa pun pada slide.

## **Efek Animasi**

Aspose.Slides mendukung **lebih dari 150 efek animasi**, termasuk efek dasar seperti Bounce, PathFootball, dan Zoom, serta efek khusus seperti OLEObjectShow dan OLEObjectOpen. Anda dapat menemukan daftar lengkapnya di enumerasi [EffectType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effecttype/).

Selain itu, efek animasi ini dapat digunakan bersama dengan perilaku berikut:

- [ColorEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SetEffect)

## **Animasi Kustom**

Untuk contoh JavaScript lengkap yang membuat, memeriksa, dan memodifikasi perilaku serta jalur gerak yang dapat disunting, lihat [Animasi Kustom](/slides/id/nodejs-java/custom-animation/).

Dimungkinkan untuk membuat **animasi kustom** Anda sendiri di Aspose.Slides. Hal ini dapat dicapai dengan menggabungkan beberapa perilaku menjadi animasi kustom baru.

[Behavior](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behavior/) adalah blok penyusun efek animasi PowerPoint. Gabungkan perilaku untuk menyesuaikan efek, atau tambahkan perilaku untuk memperluas efek yang telah didefinisikan. Pengulangan diatur melalui pengaturan waktu bukan melalui perilaku ulang terpisah.

[Animation Point](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/point/) adalah titik di mana sebuah perilaku harus diterapkan.

## **Timeline Animasi**

[Sequence](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/) adalah kumpulan efek animasi yang dapat menargetkan bentuk yang berbeda.

[Timeline](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/animationtimeline/) adalah sekumpulan urutan yang digunakan dalam slide tertentu. Ini adalah mesin animasi yang diperkenalkan di PowerPoint 2002. Pada versi PowerPoint sebelumnya, menambahkan efek animasi ke presentasi sulit dan hanya dapat dicapai dengan berbagai solusi kerja. Timeline menyediakan model objek yang lebih jelas untuk animasi PowerPoint. Sebuah slide hanya dapat memiliki satu timeline animasi.

## **Animasi Interaktif**

[Trigger](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effecttriggertype/) memungkinkan Anda mendefinisikan aksi pengguna, seperti klik tombol, yang memulai animasi tertentu.

## **Animasi Bentuk**

Aspose.Slides memungkinkan Anda menerapkan animasi pada bentuk, yang dapat mencakup teks, persegi panjang, garis, bingkai, objek OLE, dan lainnya.

{{% alert color="info" title="Note" %}}
Baca selengkapnya [**Tentang Animasi Bentuk**](/slides/id/nodejs-java/shape-animation/).
{{% /alert %}}

## **Diagram Beranimasi**

Untuk membuat diagram beranimasi, Anda harus menggunakan kelas yang sama seperti untuk bentuk. Namun, animasi PowerPoint hanya dapat diterapkan pada kategori diagram atau seri diagram. Anda juga dapat menerapkan efek animasi pada elemen kategori atau elemen seri.

{{% alert color="info" title="Note" %}}
Baca selengkapnya [**Tentang Diagram Beranimasi**](/slides/id/nodejs-java/animated-charts/).
{{% /alert %}}

## **Teks Beranimasi**

Selain menganimasikan teks, Anda dapat menerapkan animasi pada paragraf.

{{% alert color="info" title="Note" %}}
Baca selengkapnya [**Tentang Teks Beranimasi**](/slides/id/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Apakah animasi akan dipertahankan saat mengekspor ke PDF?**

Tidak. PDF adalah format statis, sehingga animasi dan [slide transitions](/slides/id/nodejs-java/slide-transition/) tidak diputar. Jika Anda membutuhkan gerakan, ekspor ke [HTML5](/slides/id/nodejs-java/export-to-html5/), [animated GIF](/slides/id/nodejs-java/convert-powerpoint-to-animated-gif/), atau [video](/slides/id/nodejs-java/convert-powerpoint-to-video/) sebagai gantinya.

**Bisakah saya mengubah presentasi beranimasi menjadi video dan mengontrol frame rate serta ukuran frame?**

Ya. Anda dapat [render presentasi sebagai frame](/slides/id/nodejs-java/convert-powerpoint-to-video/) dan mengkodekannya menjadi video (misalnya, melalui ffmpeg), memilih FPS dan resolusi. Animasi dan transisi slide diputar selama proses rendering.

**Apakah animasi tetap utuh saat bekerja dengan ODP (bukan hanya PPTX)?**

PPT, PPTX, dan ODP didukung untuk [reading](/slides/id/nodejs-java/open-presentation/) dan [writing](/slides/id/nodejs-java/save-presentation/), tetapi ini tidak menjamin preservasi animasi. Data animasi kustom dapat hilang saat mengonversi ke ODP. Lihat [Custom Animation](/slides/id/nodejs-java/custom-animation/) untuk contoh dan panduan memeriksa kompatibilitas format.