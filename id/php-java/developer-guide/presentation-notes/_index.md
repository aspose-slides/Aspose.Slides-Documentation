---
title: Kelola Catatan Presentasi di PHP
linktitle: Catatan Presentasi
type: docs
weight: 110
url: /id/php-java/presentation-notes/
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
- PHP
- Aspose.Slides
description: "Sesuaikan catatan presentasi dengan Aspose.Slides untuk PHP melalui Java. Bekerja mulus dengan catatan PowerPoint dan OpenDocument untuk meningkatkan produktivitas Anda."
---
## **Ikhtisar**

Aspose.Slides mendukung penghapusan slide catatan dari sebuah presentasi. Pada topik ini, kami akan memperkenalkan fitur tersebut, termasuk cara menghapus catatan dan cara menerapkan gaya pada slide catatan dalam sebuah presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun serta menerapkan gaya pada catatan yang ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Hapus catatan dari slide tertentu dalam presentasi.
- Hapus catatan dari semua slide dalam presentasi.

Untuk membaca atau mengubah dimensi halaman catatan, mengubah orientasi, dan memeriksa perilaku ekspor, lihat [Ukuran Halaman Catatan](/slides/id/php-java/notes-size/).

## **Hapus Catatan dari Slide**
Catatan dari slide tertentu dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```php
  # Membuat objek Presentation yang mewakili file presentasi
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Menghapus catatan slide pertama
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Menyimpan presentasi ke disk
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hapus Catatan dari Presentasi**
Catatan dari semua slide dalam presentasi dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```php
  # Membuat objek Presentation yang mewakili file presentasi
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Menghapus catatan semua slide
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Menyimpan presentasi ke disk
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tambahkan Gaya Catatan**
Metode [getNotesStyle](https://reference.aspose.com/slides/id/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) dari kelas [MasterNotesSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/MasterNotesSlide) menyediakan akses ke gaya teks catatan. Implementasinya ditunjukkan pada contoh di bawah ini.

```php
  # Membuat objek Presentation yang mewakili file presentasi
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Dapatkan gaya teks MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Atur bullet simbol untuk paragraf level pertama
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Entitas API mana yang menyediakan akses ke catatan slide tertentu?**

Catatan diakses melalui pengelola catatan slide: slide memiliki [NotesSlideManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/notesslidemanager/) dan sebuah [method](https://reference.aspose.com/slides/id/php-java/aspose.slides/notesslidemanager/getnotesslide/) yang mengembalikan objek catatan, atau `null` jika tidak ada catatan.

**Apakah ada perbedaan dukungan catatan di antara versi PowerPoint yang didukung perpustakaan?**

Perpustakaan ini menargetkan berbagai format Microsoft PowerPoint (97–terbaru) dan ODP; catatan didukung dalam format-format ini tanpa bergantung pada salinan PowerPoint yang terpasang.