---
title: Kelola Font Cadangan untuk Presentasi dalam JavaScript
linktitle: Font Cadangan
type: docs
weight: 50
url: /id/nodejs-java/fallback-font/
keywords:
- font cadangan
- font tersedia
- penggantian glif
- tentukan font
- tentukan aturan
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Lihat bagaimana Aspose.Slides untuk Node.js menggunakan fallback font untuk menjaga teks dapat dibaca dalam presentasi PowerPoint dan OpenDocument ketika font asli tidak tersedia."
---
## **Pendahuluan**

Fallback fonts digunakan ketika font yang ditentukan untuk teks tersedia di sistem tetapi tidak mengandung glif yang diperlukan. Dalam kasus ini, Aspose.Slides dapat menggunakan salah satu fallback font yang ditentukan untuk menggantikan glif yang hilang.

## **Fallback Font**

Aspose.Slides memungkinkan pembuatan fallback font, menambahkannya ke koleksi fallback font, mengatur koleksi fallback font untuk presentasi tertentu, menghapus fallback font dari presentasi, menentukan aturan untuk menerapkan fallback font, dan lain-lain.

Untuk mengenal fitur-fitur ini, gunakan tautan berikut:

- [Buat Font Cadangan](/slides/id/nodejs-java/create-fallback-font)
- [Buat Koleksi Font Cadangan](/slides/id/nodejs-java/create-fallback-fonts-collection)
- [Render Presentasi dengan Font Cadangan](/slides/id/nodejs-java/render-presentation-with-fallback-font)

## **FAQ**

**Bagaimana font cadangan berbeda dari substitusi font?**

Fallback diterapkan per karakter atau per rentang Unicode ketika font utama tidak memiliki glif tertentu; ia mengisi hanya karakter yang hilang. [Substitusi](/slides/id/nodejs-java/font-substitution/) menggantikan font yang hilang atau tidak tersedia untuk seluruh rentang atau bagian teks dengan font lain. Kedua metode dapat digabungkan, tetapi ruang lingkup dan logika pemilihannya berbeda.

**Apakah pengaturan cadangan disimpan di dalam file presentasi?**

Tidak. Konfigurasi fallback berada pada saat pemrosesan/rendering di dalam pustaka dan tidak diserialisasi ke dalam PPTX. Presentasi tidak menyimpan aturan fallback Anda.

**Apakah font cadangan memengaruhi elemen yang dibuat oleh objek PowerPoint (SmartArt, grafik, WordArt)?**

Ya. Teks di dalam objek-objek tersebut melewati jalur rendering yang sama, sehingga aturan fallback yang sama diterapkan pada teks tersebut seperti pada teks biasa.