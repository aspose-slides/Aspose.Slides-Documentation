---
title: Kelola Font Fallback untuk Presentasi di .NET
linktitle: Font Fallback
type: docs
weight: 50
url: /id/net/fallback-font/
keywords:
- font fallback
- font tersedia
- penggantian glif
- tentukan font
- tentukan aturan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Lihat bagaimana Aspose.Slides untuk .NET menggunakan font fallback untuk menjaga teks tetap terbaca di presentasi PowerPoint dan OpenDocument ketika font asli tidak tersedia."
---
## **Pendahuluan**

Font fallback digunakan ketika font yang ditentukan untuk teks tersedia di sistem tetapi tidak mengandung glif yang diperlukan. Dalam kasus ini, Aspose.Slides dapat menggunakan salah satu font fallback yang ditentukan untuk mengganti glif yang hilang.

## **Font Fallback**

Aspose.Slides memungkinkan untuk membuat font fallback, menambahkannya ke koleksi font fallback, mengatur koleksi font fallback untuk presentasi tertentu, menghapus font fallback dari presentasi, menentukan aturan untuk menerapkan font fallback, dan lain-lain.

Untuk mengenal fitur-fitur ini, gunakan tautan berikut:

- [Buat Font Fallback](/slides/id/net/create-fallback-font)
- [Buat Koleksi Font Fallback](/slides/id/net/create-fallback-fonts-collection)
- [Render Presentasi dengan Font Fallback](/slides/id/net/render-presentation-with-fallback-font)

## **FAQ**

**Bagaimana font fallback berbeda dari substitusi font?**

Font fallback diterapkan per karakter atau per rentang Unicode ketika font utama tidak memiliki glif tertentu; ia hanya mengisi karakter yang hilang. [Substitusi](/slides/id/net/font-substitution/) menggantikan font yang hilang atau tidak tersedia untuk seluruh rentang atau bagian teks dengan font lain. Mereka dapat digabungkan, tetapi ruang lingkup dan logika pemilihannya berbeda.

**Apakah pengaturan fallback disimpan di dalam berkas presentasi?**

Tidak. Konfigurasi fallback berada pada waktu pemrosesan/rendering di dalam perpustakaan dan tidak diserialisasikan ke dalam PPTX. Presentasi tidak menyimpan aturan fallback Anda.

**Apakah fallback memengaruhi elemen yang dibuat oleh objek PowerPoint (SmartArt, diagram, WordArt)?**

Ya. Teks di dalam objek-objek ini melalui jalur rendering yang sama, sehingga aturan fallback yang sama berlaku untuknya seperti pada teks biasa.