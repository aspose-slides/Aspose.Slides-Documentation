---
title: Kelola Font Fallback untuk Presentasi di Android
linktitle: Font Fallback
type: docs
weight: 50
url: /id/androidjava/fallback-font/
keywords:
- font fallback
- font yang tersedia
- penggantian glyph
- menentukan font
- menentukan aturan
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Lihat bagaimana Aspose.Slides untuk Android via Java menggunakan font fallback untuk menjaga teks tetap terbaca dalam presentasi PowerPoint dan OpenDocument ketika font asli tidak tersedia."
---
## **Pendahuluan**

Font fallback digunakan ketika font yang ditentukan untuk teks tersedia di sistem, tetapi font tersebut tidak mengandung glyph yang diperlukan. Dalam kasus ini, dapat menggunakan salah satu font fallback yang ditentukan untuk menggantikan glyph.

## **Font Fallback**

Aspose.Slides memungkinkan untuk membuat font fallback, menambahkannya ke koleksi font fallback, mengatur koleksi font fallback untuk presentasi tertentu, menghapus font fallback dari presentasi, menentukan aturan untuk menerapkan font fallback, dan lain-lain.

Untuk mengenal fitur-fitur ini, gunakan tautan berikut:

- [Buat Font Fallback](/slides/id/androidjava/create-fallback-font)
- [Buat Koleksi Font Fallback](/slides/id/androidjava/create-fallback-fonts-collection)
- [Render Presentasi dengan Font Fallback](/slides/id/androidjava/render-presentation-with-fallback-font)

## **FAQ**

**Bagaimana font fallback berbeda dari substitusi font?**

Fallback diterapkan per karakter atau per rentang Unicode ketika font utama tidak memiliki glyph tertentu; ia mengisi hanya karakter yang hilang. [Substitution](/slides/id/androidjava/font-substitution/) menggantikan font yang hilang atau tidak tersedia untuk seluruh rangkaian atau bagian teks dengan font lain. Kedua teknik dapat digabungkan, tetapi ruang lingkup dan logika pemilihannya berbeda.

**Apakah pengaturan fallback disimpan di dalam file presentasi?**

Tidak. Konfigurasi fallback berada pada saat pemrosesan/rendering di dalam pustaka dan tidak diserialisasi ke dalam PPTX. Presentasi tidak menyimpan aturan fallback Anda.

**Apakah fallback memengaruhi elemen yang dibuat oleh objek PowerPoint (SmartArt, bagan, WordArt)?**

Ya. Teks di dalam objek-objek ini melewati pipeline rendering yang sama, sehingga aturan fallback yang sama diterapkan padanya seperti pada teks biasa.