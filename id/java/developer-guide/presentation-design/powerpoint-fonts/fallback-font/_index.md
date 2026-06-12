---
title: Kelola Font Cadangan untuk Presentasi di Java
linktitle: Font Cadangan
type: docs
weight: 50
url: /id/java/fallback-font/
keywords:
- font cadangan
- font tersedia
- penggantian glyph
- tentukan font
- tentukan aturan
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Lihat bagaimana Aspose.Slides untuk Java menggunakan font cadangan untuk menjaga teks tetap terbaca dalam presentasi PowerPoint dan OpenDocument ketika font asli tidak tersedia."
---
## **Pendahuluan**

Font cadangan digunakan ketika font yang ditentukan untuk teks tersedia di sistem tetapi tidak memiliki glyph yang diperlukan. Dalam hal ini, Aspose.Slides dapat menggunakan salah satu font cadangan yang ditentukan untuk menggantikan glyph yang hilang.

## **Font Cadangan**

Aspose.Slides memungkinkan pembuatan font cadangan, menambahkannya ke koleksi font cadangan, menetapkan koleksi font cadangan untuk presentasi tertentu, menghapus font cadangan dari presentasi, menentukan aturan untuk menerapkan font cadangan, dan lainnya.

Untuk mengenal fitur‑fitur ini, gunakan tautan berikut:

- [Buat Font Cadangan](/slides/id/java/create-fallback-font)
- [Buat Koleksi Font Cadangan](/slides/id/java/create-fallback-fonts-collection)
- [Render Presentasi dengan Font Cadangan](/slides/id/java/render-presentation-with-fallback-font)

## **FAQ**

**Bagaimana font cadangan berbeda dari substitusi font?**

Font cadangan diterapkan per karakter atau per rentang Unicode ketika font utama tidak memiliki glyph tertentu; ia mengisi hanya karakter yang hilang. [Substitusi](/slides/id/java/font-substitution/) menggantikan font yang hilang atau tidak tersedia untuk seluruh rentang atau bagian teks dengan font lain. Kedua cara dapat digabungkan, tetapi ruang lingkup dan logika pemilihannya berbeda.

**Apakah pengaturan font cadangan disimpan di dalam file presentasi?**

Tidak. Konfigurasi font cadangan hidup pada saat pemrosesan/rendering di dalam perpustakaan dan tidak diserialisasi ke dalam PPTX. Presentasi tidak menyimpan aturan font cadangan Anda.

**Apakah font cadangan memengaruhi elemen yang dibuat oleh objek PowerPoint (SmartArt, diagram, WordArt)?**

Ya. Teks di dalam objek‑objek ini melewati pipeline rendering yang sama, sehingga aturan font cadangan yang sama berlaku untuknya seperti pada teks biasa.