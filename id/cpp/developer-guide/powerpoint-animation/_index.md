---
title: Tingkatkan Presentasi PowerPoint dengan Animasi di C++
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
- mengontrol animasi
- efek animasi
- animasi PowerPoint
- garis waktu animasi
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
- C++
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengontrol efek animasi lanjutan di Aspose.Slides untuk C++ guna membuat presentasi PowerPoint dan OpenDocument yang dinamis."
---
## **Pendahuluan**

Karena presentasi dimaksudkan untuk menyajikan sesuatu, penampilan visual dan perilaku interaktifnya selalu dipertimbangkan saat membuatnya.

**Animasi PowerPoint** memainkan peran penting untuk membuat presentasi menarik dan memikat bagi penonton. Aspose.Slides for C++ menawarkan beragam opsi untuk menambahkan animasi ke presentasi PowerPoint:

- menerapkan berbagai jenis efek animasi PowerPoint pada bentuk, diagram, tabel, OLE Object, dan elemen presentasi lainnya.
- menggunakan beberapa efek animasi PowerPoint pada satu bentuk.
- menggunakan garis waktu animasi untuk mengontrol efek animasi.
- membuat animasi kustom.

Di Aspose.Slides for C++, berbagai efek animasi dapat diterapkan pada bentuk. Karena setiap elemen pada slide termasuk teks, gambar, OLE Object, tabel, dll dianggap sebagai bentuk, artinya kita dapat menerapkan efek animasi pada setiap elemen slide.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides.animation) **namespace** menyediakan kelas untuk bekerja dengan animasi PowerPoint.
## **Efek Animasi**
Aspose.Slides mendukung **lebih dari 150 efek animasi**, termasuk efek animasi dasar seperti Bounce, PathFootball, efek Zoom, dan efek animasi khusus seperti OLEObjectShow, OLEObjectOpen. Anda dapat menemukan daftar lengkap efek animasi dalam enumerasi [**EffectType**](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Selain itu, efek animasi ini dapat digunakan dalam kombinasi dengan mereka:

- [ColorEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.set_effect)

## **Animasi Kustom**
Dimungkinkan untuk membuat **animasi kustom** Anda sendiri di Aspose.Slides. 
Hal ini dapat dicapai jika Anda menggabungkan beberapa perilaku menjadi sebuah animasi kustom baru.

[**Behavior**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.behavior) adalah unit pembangun dari setiap efek animasi PowerPoint. Semua efek animasi sebenarnya merupakan sekumpulan perilaku yang digabung menjadi satu strategi. Anda dapat menggabungkan perilaku menjadi animasi kustom satu kali dan menggunakannya kembali di presentasi lain. Jika Anda menambahkan perilaku baru ke dalam efek animasi PowerPoint standar, itu akan menjadi animasi kustom lainnya. Misalnya, Anda dapat menambahkan perilaku pengulangan ke sebuah animasi agar animasi tersebut diulang beberapa kali.

[**Animation Point**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.point) adalah titik di mana perilaku harus diterapkan.

## **Garis Waktu Animasi**
[**Sequence**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.sequence) adalah kumpulan efek animasi yang diterapkan pada bentuk tertentu.

[**AnimationTimeLine**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.animation_time_line) adalah sekumpulan Sequence yang digunakan pada slide tertentu. Ini adalah mesin animasi yang telah ada sejak PowerPoint 2002. Pada versi PowerPoint sebelumnya, menambahkan efek animasi ke presentasi cukup sulit dan hanya dapat dilakukan dengan berbagai solusi alternatif. Timeline menggantikan kelas AnimationSettings lama dan menyediakan model objek yang lebih jelas untuk animasi PowerPoint. Satu slide hanya dapat memiliki satu timeline animasi.

## **Animasi Interaktif**
[**EffectTriggerType**](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) memungkinkan mendefinisikan tindakan pengguna (misalnya klik tombol), yang akan memulai animasi tertentu. Trigger hanya ditambahkan pada versi PowerPoint terbaru.

## **Animasi Bentuk**
Aspose.Slides memungkinkan penerapan animasi pada bentuk, yang sebenarnya dapat berupa teks, persegi panjang, garis, bingkai, OLE Object, dll.

{{% alert color="info" %}} 
Baca selengkapnya [**Tentang Animasi Bentuk**](/slides/id/cpp/shape-animation/).
{{% /alert %}}

## **Diagram Beranimasi**
Untuk membuat diagram beranimasi, Anda harus menggunakan semua kelas yang sama seperti untuk bentuk. Namun, Anda dapat menggunakan animasi PowerPoint hanya pada kategori diagram atau seri diagram. Anda juga dapat menerapkan efek animasi pada elemen kategori atau elemen seri.

{{% alert color="info" %}} 
Baca selengkapnya [**Tentang Diagram Beranimasi**](/slides/id/cpp/animated-charts/).
{{% /alert %}}

## **Teks Beranimasi**
Selain teks beranimasi, Anda juga dapat menerapkan animasi pada sebuah paragraf.

{{% alert color="info" %}} 
Baca selengkapnya [**Tentang Teks Beranimasi**](/slides/id/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

### Apakah animasi akan tetap dipertahankan saat mengekspor ke PDF?

Tidak. PDF adalah format statis, sehingga animasi dan [transisi slide](/slides/id/cpp/slide-transition/) tidak diputar. Jika Anda membutuhkan gerakan, ekspor ke [HTML5](/slides/id/cpp/export-to-html5/), [GIF beranimasi](/slides/id/cpp/convert-powerpoint-to-animated-gif/), atau [video](/slides/id/cpp/convert-powerpoint-to-video/) sebagai gantinya.

### Apakah saya dapat mengubah presentasi beranimasi menjadi video dan mengontrol frame rate serta ukuran frame?

Ya. Anda dapat [render presentasi sebagai frame](/slides/id/cpp/convert-powerpoint-to-video/) dan mengenkode mereka menjadi video (misalnya, menggunakan ffmpeg), memilih FPS dan resolusi. Animasi dan transisi slide diputar selama proses rendering.

### Apakah animasi tetap utuh ketika bekerja dengan ODP (bukan hanya PPTX)?

PPT, PPTX, dan ODP didukung untuk [pembacaan](/slides/id/cpp/open-presentation/) dan [penulisan](/slides/id/cpp/save-presentation/), namun perbedaan format berarti beberapa efek mungkin terlihat atau berperilaku sedikit berbeda. Validasi kasus kritis dengan contoh nyata.