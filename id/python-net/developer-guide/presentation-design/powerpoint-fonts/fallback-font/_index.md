---
title: "Kelola Font Fallback untuk Presentasi di Python"
linktitle: "Font Fallback"
type: docs
weight: 50
url: /id/python-net/fallback-font/
keywords:
- "font fallback"
- "font tersedia"
- "penggantian glif"
- "menentukan font"
- "menentukan aturan"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "Python"
- "Aspose.Slides"
description: "Lihat bagaimana Aspose.Slides untuk Python via .NET menggunakan font fallback untuk menjaga teks tetap terbaca dalam presentasi PowerPoint dan OpenDocument ketika font asli tidak tersedia."
---
## **Pendahuluan**

Font fallback digunakan ketika font yang ditentukan untuk teks tersedia di sistem tetapi tidak berisi glif yang diperlukan. Dalam kasus ini, Aspose.Slides dapat menggunakan salah satu font fallback yang ditentukan untuk menggantikan glif yang hilang.

## **Font Fallback**

Aspose.Slides memungkinkan pembuatan font fallback, menambahkannya ke koleksi font fallback, mengatur koleksi font fallback untuk presentasi tertentu, menghapus font fallback dari presentasi, menentukan aturan untuk menerapkan font fallback, dan lain-lain.

Untuk memahami fitur-fitur ini, gunakan tautan berikut:

- [Create Fallback Font](/slides/id/python-net/create-fallback-font)
- [Create Fallback Fonts Collection](/slides/id/python-net/create-fallback-fonts-collection)
- [Render Presentation with Fallback Font](/slides/id/python-net/render-presentation-with-fallback-font)

## **FAQ**

**Bagaimana perbedaan antara font fallback dan substitusi font?**

Fallback diterapkan per karakter atau per rentang Unicode ketika font utama tidak memiliki glif tertentu; ia hanya mengisi karakter yang hilang. [Substitution](/slides/id/python-net/font-substitution/) menggantikan font yang hilang atau tidak tersedia untuk seluruh run atau bagian teks dengan font lain. Kedua metode dapat digabungkan, tetapi cakupan dan logika pemilihannya berbeda.

**Apakah pengaturan fallback disimpan di dalam file presentasi?**

Tidak. Konfigurasi fallback hidup pada waktu pemrosesan/rendering di dalam perpustakaan dan tidak diserialisasikan ke dalam PPTX. Presentasi tidak menyimpan aturan fallback Anda.

**Apakah fallback memengaruhi elemen yang dibuat oleh objek PowerPoint (SmartArt, grafik, WordArt)?**

Ya. Teks di dalam objek-objek ini melewati pipeline rendering yang sama, sehingga aturan fallback yang sama berlaku untuknya seperti pada teks biasa.