---
title: Kelola Font Fallback untuk Presentasi dalam С++
linktitle: Font Fallback
type: docs
weight: 50
url: /id/cpp/fallback-font/
keywords:
- font fallback
- font tersedia
- penggantian glif
- menentukan font
- menentukan aturan
- PowerPoint
- OpenDocument
- presentasi
- С++
- Aspose.Slides
description: "Lihat bagaimana Aspose.Slides untuk С++ menggunakan font fallback untuk menjaga teks tetap terbaca dalam presentasi PowerPoint dan OpenDocument ketika font asli tidak tersedia."
---
## **Pendahuluan**

Font fallback digunakan ketika font yang ditentukan untuk teks tersedia di sistem tetapi tidak mengandung glif yang diperlukan. Dalam hal ini, Aspose.Slides dapat menggunakan salah satu font fallback yang ditentukan untuk menggantikan glif yang hilang.

## **Font Fallback**
Font fallback digunakan ketika font yang ditentukan untuk teks tersedia di sistem, tetapi font tersebut tidak mengandung glif yang diperlukan. Dalam hal ini, memungkinkan untuk menggunakan salah satu font fallback yang ditentukan untuk penggantian glif.

Aspose.Slides memungkinkan untuk membuat font fallback, menambahkannya ke koleksi font fallback, menetapkan koleksi font fallback untuk presentasi tertentu, menghapus font fallback dari presentasi, menentukan aturan untuk menerapkan font fallback, dan lain-lain.

Untuk mengenal fitur-fitur ini, gunakan tautan berikut:

- [Buat Font Fallback](/slides/id/cpp/create-fallback-font)
- [Buat Koleksi Font Fallback](/slides/id/cpp/create-fallback-fonts-collection)
- [Render Presentasi dengan Font Fallback](/slides/id/cpp/render-presentation-with-fallback-font)

## **FAQ**

**Bagaimana cara font fallback berbeda dari substitusi font?**

Fallback diterapkan per karakter atau per rentang Unicode ketika font utama tidak memiliki glif tertentu; ia mengisi hanya karakter yang hilang. [Substitusi](/slides/id/cpp/font-substitution/) menggantikan font yang hilang atau tidak tersedia untuk seluruh run atau bagian teks dengan font lain. Kedua metode dapat digabungkan, tetapi ruang lingkup dan logika pemilihannya berbeda.

**Apakah pengaturan fallback disimpan di dalam file presentasi?**

Tidak. Konfigurasi fallback berada pada waktu pemrosesan/rendering di dalam pustaka dan tidak diserialisasi ke dalam PPTX. Presentasi tidak menyimpan aturan fallback Anda.

**Apakah fallback memengaruhi elemen yang dibuat oleh objek PowerPoint (SmartArt, diagram, WordArt)?**

Ya. Teks di dalam objek-objek ini melewati pipeline rendering yang sama, sehingga aturan fallback yang sama diterapkan padanya seperti pada teks biasa.