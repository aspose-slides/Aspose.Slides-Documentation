---
title: Tingkatkan Presentasi PowerPoint dengan Animasi di Android
linktitle: Animasi PowerPoint
type: docs
weight: 150
url: /id/androidjava/powerpoint-animation/
keywords:
- tambahkan animasi
- perbarui animasi
- ubah animasi
- hapus animasi
- kelola animasi
- kontrol animasi
- efek animasi
- animasi PowerPoint
- garis waktu animasi
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
## **Pendahuluan**

Karena presentasi dimaksudkan untuk menyajikan sesuatu, tampilan visual dan perilaku interaktifnya selalu dipertimbangkan saat membuatnya.

**PowerPoint animation** memainkan peran penting untuk membuat presentasi menarik dan menawan bagi penonton. Aspose.Slides for Android via Java menawarkan berbagai pilihan untuk menambahkan animasi ke presentasi PowerPoint:

- menerapkan berbagai jenis efek animasi PowerPoint pada bentuk, diagram, tabel, OLE Object, dan elemen presentasi lainnya.
- menggunakan beberapa efek animasi PowerPoint pada satu bentuk.
- menggunakan timeline animasi untuk mengontrol efek animasi.
- membuat animasi kustom.

Di Aspose.Slides for Android via Java, berbagai efek animasi dapat diterapkan pada bentuk. Karena setiap elemen pada slide termasuk teks, gambar, OLE Object, tabel, dll dianggap sebagai bentuk, berarti kita dapat menerapkan efek animasi pada setiap elemen slide.

## **Efek Animasi**
Aspose.Slides mendukung **lebih dari 150 efek animasi**, termasuk efek animasi dasar seperti Bounce, PathFootball, efek Zoom, dan efek animasi khusus seperti OLEObjectShow, OLEObjectOpen. Anda dapat menemukan daftar lengkap efek animasi di enumerasi [**EffectType**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/effecttype/).

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
Anda dapat membuat **animasi kustom** Anda sendiri di Aspose.Slides. 
Hal ini dapat dicapai dengan menggabungkan beberapa perilaku menjadi satu animasi kustom baru.

[**Behavior**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Behavior) adalah unit pembangun dari setiap efek animasi PowerPoint. Semua efek animasi sebenarnya merupakan kumpulan perilaku yang digabung menjadi satu strategi. Anda dapat menggabungkan perilaku menjadi animasi kustom sekali dan menggunakannya kembali di presentasi lain. Jika Anda menambahkan perilaku baru ke efek animasi PowerPoint standar - itu akan menjadi animasi kustom lainnya. Misalnya, Anda dapat menambahkan perilaku pengulangan ke animasi agar animasi tersebut berulang beberapa kali.

[**Animation Point**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Point) adalah titik di mana perilaku harus diterapkan.

## **Garis Waktu Animasi**
[**Sequence**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Sequence) adalah kumpulan efek animasi, yang diterapkan pada bentuk tertentu.

[**Timeline**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/AnimationTimeLine) adalah sekumpulan Sequence yang digunakan dalam sebuah slide tertentu. Itu merupakan mesin animasi yang telah ada sejak PowerPoint 2002. Pada versi PowerPoint sebelumnya, menambahkan efek animasi ke presentasi cukup sulit dan hanya dapat dilakukan dengan berbagai solusi alternatif. Timeline menggantikan kelas AnimationSettings yang lama dan memberikan model objek yang lebih jelas untuk animasi PowerPoint. Satu slide hanya dapat memiliki satu timeline animasi.

## **Animasi Interaktif**
[**Trigger**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/EffectTriggerType) memungkinkan mendefinisikan aksi pengguna (misalnya klik tombol), yang akan memulai animasi tertentu. Trigger hanya ditambahkan pada versi PowerPoint terbaru.

## **Animasi Bentuk**
Aspose.Slides memungkinkan menerapkan animasi pada bentuk, yang dapat berupa teks, persegi panjang, garis, bingkai, OLE Object, dll.

{{% alert color="primary" %}} 
Baca selengkapnya [**Tentang Animasi Bentuk**](/slides/id/androidjava/shape-animation/).
{{% /alert %}}

## **Diagram Animasi**
Untuk membuat diagram animasi, Anda harus menggunakan semua kelas yang sama seperti untuk bentuk. Namun, hanya dapat menggunakan animasi PowerPoint pada kategori diagram atau seri diagram. Anda juga dapat menerapkan efek animasi pada elemen kategori atau elemen seri.

{{% alert color="primary" %}} 
Baca selengkapnya [**Tentang Diagram Animasi**](/slides/id/androidjava/animated-charts/).
{{% /alert %}}

## **Teks Animasi**
Selain teks animasi, Anda juga dapat menerapkan animasi pada paragraf.

{{% alert color="primary" %}} 
Baca selengkapnya [**Tentang Teks Animasi**](/slides/id/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Apakah animasi akan dipertahankan saat mengekspor ke PDF?**

Tidak. PDF adalah format statis, sehingga animasi dan [transisi slide](/slides/id/androidjava/slide-transition/) tidak diputar. Jika Anda memerlukan gerakan, ekspor ke [HTML5](/slides/id/androidjava/export-to-html5/), [GIF animasi](/slides/id/androidjava/convert-powerpoint-to-animated-gif/), atau [video](/slides/id/androidjava/convert-powerpoint-to-video/) sebagai gantinya.

**Apakah saya dapat mengubah presentasi animasi menjadi video dan mengontrol frame rate serta ukuran frame?**

Ya. Anda dapat [memrender presentasi menjadi frame](/slides/id/androidjava/convert-powerpoint-to-video/) dan mengenkodenya menjadi video (misalnya melalui ffmpeg), dengan memilih FPS dan resolusi. Animasi serta transisi slide diputar selama proses render.

**Apakah animasi akan tetap utuh saat bekerja dengan ODP (bukan hanya PPTX)?**

PPT, PPTX, dan ODP didukung untuk [pembacaan](/slides/id/androidjava/open-presentation/) dan [penulisan](/slides/id/androidjava/save-presentation/), namun perbedaan format berarti beberapa efek dapat terlihat atau berperilaku sedikit berbeda. Validasikan kasus kritis dengan contoh nyata.