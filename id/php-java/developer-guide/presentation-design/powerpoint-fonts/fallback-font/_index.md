---
title: Kelola Font Cadangan untuk Presentasi di PHP
linktitle: Font Cadangan
type: docs
weight: 50
url: /id/php-java/fallback-font/
keywords:
- font cadangan
- font tersedia
- penggantian glif
- menentukan font
- menentukan aturan
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Lihat bagaimana Aspose.Slides untuk PHP menggunakan font cadangan untuk menjaga teks tetap dapat dibaca dalam presentasi PowerPoint dan OpenDocument ketika font asli tidak tersedia."
---
## **Pendahuluan**

Font cadangan digunakan ketika font yang ditentukan untuk teks tersedia di sistem tetapi tidak mengandung glif yang dibutuhkan. Dalam kasus ini, Aspose.Slides dapat menggunakan salah satu font cadangan yang ditentukan untuk menggantikan glif yang hilang.

## **Font Cadangan**
Font cadangan digunakan ketika font yang ditentukan untuk teks tersedia di sistem, tetapi font ini tidak mengandung glif yang diperlukan. Dalam kasus ini, memungkinkan untuk menggunakan salah satu font cadangan yang ditentukan untuk penggantian glif.

Aspose.Slides memungkinkan pembuatan font cadangan, menambahkannya ke koleksi font cadangan, menetapkan koleksi font cadangan untuk presentasi tertentu, menghapus font cadangan dari presentasi, menentukan aturan untuk menerapkan font cadangan, dan lain-lain.

Untuk mengenal fitur-fitur ini, gunakan tautan berikut:

- [Buat Font Cadangan](/slides/id/php-java/create-fallback-font)
- [Buat Koleksi Font Cadangan](/slides/id/php-java/create-fallback-fonts-collection)
- [Render Presentasi dengan Font Cadangan](/slides/id/php-java/render-presentation-with-fallback-font)

## **FAQ**

**Bagaimana font cadangan berbeda dari substitusi font?**

Font cadangan diterapkan per karakter atau per rentang Unicode ketika font utama tidak memiliki glif tertentu; ia mengisi hanya karakter yang hilang. [Substitusi](/slides/id/php-java/font-substitution/) menggantikan font yang hilang atau tidak tersedia untuk seluruh rentang atau bagian teks dengan font lain. Kedua metode dapat digabungkan, tetapi ruang lingkup dan logika pemilihannya berbeda.

**Apakah pengaturan font cadangan disimpan di dalam file presentasi?**

Tidak. Konfigurasi font cadangan hidup pada saat pemrosesan/rendering di dalam pustaka dan tidak diserialisasi ke dalam file PPTX. Presentasi tidak menyimpan aturan font cadangan Anda.

**Apakah font cadangan memengaruhi elemen yang dibuat oleh objek PowerPoint (SmartArt, diagram, WordArt)?**

Ya. Teks di dalam objek-objek ini melewati pipeline rendering yang sama, sehingga aturan font cadangan yang sama berlaku untuknya seperti pada teks biasa.