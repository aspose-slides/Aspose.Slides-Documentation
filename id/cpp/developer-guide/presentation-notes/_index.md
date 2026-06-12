---
title: Kelola Catatan Presentasi dalam C++
linktitle: Catatan Presentasi
type: docs
weight: 110
url: /id/cpp/presentation-notes/
keywords:
- catatan
- slide catatan
- menambahkan catatan
- menghapus catatan
- gaya catatan
- catatan master
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Sesuaikan catatan presentasi dengan Aspose.Slides untuk C++. Bekerja secara mulus dengan catatan PowerPoint dan OpenDocument untuk meningkatkan produktivitas Anda."
---
## **Ikhtisar**

Aspose.Slides mendukung menghapus slide catatan dari sebuah presentasi. Pada topik ini, kami akan memperkenalkan fitur ini, termasuk cara menghapus catatan dan cara menerapkan gaya pada slide catatan dalam sebuah presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun serta menerapkan gaya pada catatan yang ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Menghapus catatan dari slide tertentu dalam presentasi.
- Menghapus catatan dari semua slide dalam presentasi.

## **Menghapus Catatan dari Slide Tertentu**
Catatan pada slide tertentu dapat dihapus seperti contoh di bawah:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Menghapus Catatan dari Semua Slide**
Catatan pada semua slide dalam presentasi dapat dihapus seperti contoh di bawah:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Menambahkan Gaya Catatan**
Properti NotesStyle telah ditambahkan ke antarmuka IMasterNotesSlide dan kelas MasterNotesSlide masing‑masing. Properti ini menentukan gaya teks catatan. Implementasinya ditunjukkan pada contoh di bawah.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

**Entitas API mana yang memberikan akses ke catatan slide tertentu?**

Catatan diakses melalui pengelola catatan slide: slide memiliki [NotesSlideManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/notesslidemanager/) dan sebuah [method](https://reference.aspose.com/slides/id/cpp/aspose.slides/notesslidemanager/get_notesslide/) yang mengembalikan objek catatan, atau `null` jika tidak ada catatan.

**Apakah ada perbedaan dukungan catatan di antara versi PowerPoint yang didukung oleh perpustakaan ini?**

Perpustakaan ini mendukung berbagai format Microsoft PowerPoint (97‑terbaru) serta ODP; catatan didukung dalam format tersebut tanpa bergantung pada instalasi PowerPoint.