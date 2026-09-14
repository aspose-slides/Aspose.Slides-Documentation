---
title: Kelola Font Fallback untuk Presentasi di Python via Java
linktitle: Font Fallback
type: docs
weight: 50
url: /id/python-java/fallback-font/
keywords:
- font fallback
- font tersedia
- penggantian glyph
- menentukan font
- menentukan aturan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Lihat bagaimana Aspose.Slides untuk Python via Java menggunakan font fallback untuk menjaga teks tetap dapat dibaca di presentasi PowerPoint dan OpenDocument ketika font asli tidak tersedia."
---
## **Pendahuluan**

Font fallback digunakan ketika font yang ditentukan untuk teks tersedia di sistem tetapi tidak mengandung glyph yang diperlukan. Dalam kasus ini, Aspose.Slides dapat menggunakan salah satu font fallback yang ditentukan untuk menggantikan glyph yang hilang.

## **Font Fallback**

Aspose.Slides memungkinkan Anda membuat font fallback, menambahkannya ke koleksi font fallback, mengatur koleksi font fallback untuk presentasi tertentu, menghapus font fallback dari presentasi, menentukan aturan penerapan font fallback, dan melakukan operasi terkait lainnya.

Untuk mengenal fitur‑fitur ini, gunakan tautan berikut:

- [Buat Font Fallback](/slides/id/python-java/create-fallback-font/)
- [Buat Koleksi Font Fallback](/slides/id/python-java/create-fallback-fonts-collection/)
- [Render Presentasi dengan Font Fallback](/slides/id/python-java/render-presentation-with-fallback-font/)

## **Tanya Jawab**

**Bagaimana font fallback berbeda dari substitusi font?**

Font fallback diterapkan per karakter atau per rentang Unicode ketika font utama tidak memiliki glyph tertentu; ia mengisi hanya karakter yang hilang. [Substitusi](/slides/id/python-java/font-substitution/) menggantikan font yang hilang atau tidak tersedia untuk seluruh rangkaian atau bagian teks dengan font lain. Mereka dapat digabungkan, tetapi ruang lingkup dan logika pemilihannya berbeda.

**Apakah pengaturan fallback disimpan di dalam file presentasi?**

Tidak. Konfigurasi fallback hidup pada saat pemrosesan/rendering di perpustakaan dan tidak diserialisasi ke dalam PPTX. Presentasi tidak menyimpan aturan fallback Anda.

**Apakah fallback memengaruhi elemen yang dibuat oleh objek PowerPoint (SmartArt, diagram, WordArt)?**

Ya. Teks di dalam objek tersebut melewati pipeline rendering yang sama, sehingga aturan fallback yang sama diterapkan padanya seperti pada teks reguler.