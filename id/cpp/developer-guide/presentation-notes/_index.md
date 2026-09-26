---
title: Mengelola Catatan Presentasi dalam C++
linktitle: Catatan Presentasi
type: docs
weight: 110
url: /id/cpp/presentation-notes/
keywords:
- catatan
- slide catatan
- tambahkan catatan
- hapus catatan
- gaya catatan
- catatan master
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Sesuaikan catatan presentasi dengan Aspose.Slides untuk C++. Bekerja mulus dengan catatan PowerPoint dan OpenDocument untuk meningkatkan produktivitas Anda."
---
## **Gambaran Umum**

Aspose.Slides mendukung penghapusan slide catatan dari sebuah presentasi. Dalam topik ini, kami akan memperkenalkan fitur ini, termasuk cara menghapus catatan dan cara menerapkan gaya pada slide catatan dalam sebuah presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun dan juga menerapkan gaya pada catatan yang ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Menghapus catatan dari slide tertentu dalam presentasi.
- Menghapus catatan dari semua slide dalam presentasi.

Untuk membaca atau mengubah dimensi halaman catatan, mengubah orientasi, dan memeriksa perilaku ekspor, lihat [Ukuran Halaman Catatan](/slides/id/cpp/notes-size/).

## **Menghapus Catatan dari Slide Tertentu**
Catatan dari slide tertentu dapat dihapus seperti yang ditunjukkan dalam contoh di bawah:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Menghapus Catatan dari Semua Slide**
Catatan dari semua slide dalam presentasi dapat dihapus seperti yang ditunjukkan dalam contoh di bawah:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Menambahkan Gaya Catatan**
Properti NotesStyle telah ditambahkan ke antarmuka IMasterNotesSlide dan kelas MasterNotesSlide. Properti ini menentukan gaya teks catatan. Implementasinya ditunjukkan dalam contoh di bawah.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

### Entitas API mana yang menyediakan akses ke catatan slide tertentu?

Catatan diakses melalui manajer catatan slide: slide memiliki [NotesSlideManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/notesslidemanager/) dan sebuah [method](https://reference.aspose.com/slides/id/cpp/aspose.slides/notesslidemanager/get_notesslide/) yang mengembalikan objek catatan, atau `null` jika tidak ada catatan.

### Apakah ada perbedaan dalam dukungan catatan di berbagai versi PowerPoint yang didukung perpustakaan?

Perpustakaan ini mendukung berbagai format Microsoft PowerPoint (97–terbaru) dan ODP; catatan didukung dalam format-format ini tanpa bergantung pada instalasi PowerPoint.