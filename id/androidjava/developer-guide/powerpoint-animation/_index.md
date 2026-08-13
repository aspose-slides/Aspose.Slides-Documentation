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
- timeline animasi
- animasi interaktif
- animasi kustom
- animasi bentuk
- diagram animasi
- teks animasi
- bentuk animasi
- objek OLE animasi
- gambar animasi
- tabel animasi
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Jelajahi kemampuan Aspose.Slides untuk Android via Java dalam menangani animasi PowerPoint. Ikhtisar umum ini menyoroti fitur utama."
---
## **Pengantar**

Karena presentasi dimaksudkan untuk menyajikan sesuatu, penampilan visual dan perilaku interaktifnya selalu dipertimbangkan saat membuatnya.

**Animasi PowerPoint** memainkan peran penting untuk membuat presentasi menarik dan menarik bagi penonton. Aspose.Slides for Android via Java menawarkan beragam pilihan untuk menambahkan animasi ke presentasi PowerPoint:

- menerapkan berbagai jenis efek animasi PowerPoint pada shape, diagram, tabel, OLE Object, dan elemen presentasi lainnya.
- menggunakan beberapa efek animasi PowerPoint pada satu shape.
- menggunakan timeline animasi untuk mengontrol efek animasi.
- membuat animasi kustom.

Di Aspose.Slides for Android via Java, berbagai efek animasi dapat diterapkan pada shape. Karena setiap elemen di slide termasuk teks, gambar, OLE Object, tabel, dll dianggap sebagai shape, berarti kita dapat menerapkan efek animasi pada setiap elemen slide.

## **Efek Animasi**
Aspose.Slides mendukung **150+ animation effects**, termasuk efek animasi dasar seperti Bounce, PathFootball, efek Zoom, dan efek animasi khusus seperti OLEObjectShow, OLEObjectOpen. Anda dapat menemukan daftar lengkap efek animasi di [**EffectType**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/effecttype/) enumerasi.

Selain itu, efek animasi ini dapat digunakan dalam kombinasi dengan:

- [ColorEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SetEffect)

## **Animasi Kustom**
Dimungkinkan untuk membuat **custom animations** Anda sendiri di Aspose.Slides. Hal ini dapat dicapai jika Anda menggabungkan beberapa perilaku menjadi animasi kustom baru.

[**Behavior**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Behavior) adalah unit bangunan dari setiap efek animasi PowerPoint. Semua efek animasi pada dasarnya adalah sekumpulan perilaku yang digabung menjadi satu strategi. Anda dapat menggabungkan perilaku menjadi animasi kustom sekali dan menggunakannya kembali di presentasi lain. Jika Anda menambahkan perilaku baru ke efek animasi PowerPoint standar, itu akan menjadi animasi kustom lainnya. Misalnya, Anda dapat menambahkan perilaku pengulangan ke sebuah animasi agar animasi tersebut mengulang beberapa kali.

[**Animation Point**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Point) adalah titik di mana perilaku harus diterapkan.

## **Garis Waktu Animasi**
[**Sequence**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Sequence) adalah kumpulan efek animasi, yang diterapkan pada shape tertentu.

[**Timeline**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/AnimationTimeLine) adalah sekumpulan Sequence yang digunakan dalam slide tertentu. Ini merupakan mesin animasi yang diperkenalkan sejak PowerPoint 2002. Pada versi PowerPoint sebelumnya, menambahkan efek animasi ke presentasi cukup menantang dan hanya dapat dicapai dengan berbagai solusi alternatif. Timeline menggantikan kelas AnimationSettings yang lama dan menyediakan model objek yang lebih jelas untuk animasi PowerPoint. Satu slide hanya dapat memiliki satu timeline animasi.

## **Animasi Interaktif**
[**Trigger**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/EffectTriggerType) memungkinkan mendefinisikan tindakan pengguna (mis. klik tombol) yang akan memulai animasi tertentu. Trigger hanya ditambahkan pada versi PowerPoint terbaru.

## **Animasi Bentuk**
Aspose.Slides memungkinkan penerapan animasi pada shape, yang dapat berupa teks, persegi panjang, garis, bingkai, OLE Object, dll.

{{% alert color="info" %}} 
Baca selengkapnya [**Tentang Animasi Bentuk**](/slides/id/androidjava/shape-animation/).
{{% /alert %}}

## **Diagram Animasi**
Untuk membuat diagram animasi, Anda harus menggunakan semua kelas yang sama seperti untuk shape. Namun, dimungkinkan hanya menggunakan animasi PowerPoint pada kategori diagram atau seri diagram. Anda juga dapat menerapkan efek animasi pada elemen kategori atau elemen seri.

{{% alert color="info" %}} 
Baca selengkapnya [**Tentang Diagram Animasi**](/slides/id/androidjava/animated-charts/).
{{% /alert %}}

## **Teks Animasi**
Selain teks animasi, Anda juga dapat menerapkan animasi pada paragraf.

{{% alert color="info" %}} 
Baca selengkapnya [**Tentang Teks Animasi**](/slides/id/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

### Apakah animasi akan tetap dipertahankan saat mengekspor ke PDF?

Tidak. PDF adalah format statis, sehingga animasi dan [transisi slide](/slides/id/androidjava/slide-transition/) tidak diputar. Jika Anda membutuhkan gerakan, ekspor ke [HTML5](/slides/id/androidjava/export-to-html5/), [animated GIF](/slides/id/androidjava/convert-powerpoint-to-animated-gif/), atau [video](/slides/id/androidjava/convert-powerpoint-to-video/) saja.

### Apakah saya dapat mengubah presentasi animasi menjadi video dan mengontrol frame rate serta ukuran frame?

Ya. Anda dapat [render the presentation as frames](/slides/id/androidjava/convert-powerpoint-to-video/) dan mengenkodenya menjadi video (mis., via ffmpeg), memilih FPS dan resolusi. Animasi dan transisi slide diputar selama proses rendering.

### Apakah animasi tetap utuh saat bekerja dengan ODP (bukan hanya PPTX)?

PPT, PPTX, dan ODP didukung untuk [reading](/slides/id/androidjava/open-presentation/) dan [writing](/slides/id/androidjava/save-presentation/), namun perbedaan format berarti beberapa efek mungkin terlihat atau berperilaku sedikit berbeda. Validasi kasus kritis dengan contoh nyata.