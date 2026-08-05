---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 15.6.0
linktitle: Aspose.Slides untuk Java 15.6.0
type: docs
weight: 140
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides for Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda secara mulus."
---
{{% alert color="primary" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/), setiap pembatasan baru, serta [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) lain yang diperkenalkan dengan API Aspose.Slides for Java 15.6.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **com.aspose.slides.DataLabel constructor signature has been changed**
Tanda tangan konstruktor telah diubah dari DataLabel(com.aspose.slides.IChartSeries) menjadi DataLabel(com.aspose.slides.IChartDataPoint).
#### **Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead**
Metode IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) telah ditandai sebagai Usang. Metode IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) telah diperkenalkan sebagai pengganti.
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() has been added**
Metode com.aspose.slides.INotesSlideManager.RemoveNotesSlide() telah ditambahkan untuk menghapus slide catatan dari sebuah slide.
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
Metode com.aspose.slides.ISlide.getNotesSlideManager() telah ditambahkan. Metode ISlide.getNotesSlide() dan ISlide.addNotesSlide() telah ditandai sebagai Usang. Gunakan metode baru ISlide.getNotesSlideManager() sebagai gantinya.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - usang

// notes = slide.getNotesSlide(); - usang

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Method getAppVersion() has been added to com.aspose.slides.IDocumentProperties**
Metode com.aspose.slides.IDocumentProperties.getAppVersion() telah ditambahkan untuk mendapatkan properti dokumen bawaan, yang mewakili nomor versi internal yang digunakan oleh Microsoft PowerPoint.
#### **Method remove() has been added to com.aspose.slides.IComment**
Metode com.aspose.slides.IComment.remove() telah ditambahkan untuk menghapus komentar dari koleksi.
#### **Method remove() has been added to com.aspose.slides.ICommentAuthor**
Metode ICommentAuthor.Remove telah ditambahkan untuk menghapus penulis komentar dari koleksi.
#### **Methods clearCustomProperties() and clearBuiltInProperties() have been added to com.aspose.slides.IDocumentProperties**
Metode com.aspose.slides.IDocumentProperties.clearCustomProperties() telah ditambahkan untuk menghapus semua properti dokumen kustom.
Metode com.aspose.slides.IDocumentProperties.clearBuiltInProperties() telah ditambahkan untuk menghapus dan mengatur nilai default untuk semua properti dokumen bawaan (Company, Subject, Author, dll).
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to com.aspose.slides.IShape**
Metode getBlackWhiteMode() dan setBlackWhiteMode(byte) telah ditambahkan ke com.aspose.slides.IShape.
Metode ini menentukan bagaimana sebuah bentuk akan ditampilkan dalam mode hitam-putih. Nilai yang mungkin ditentukan dalam kelas com.aspose.slides.BlackWhiteMode.

|**Nilai** |**Arti** |
| :- | :- |
|Color |Mengembalikan dengan pewarnaan normal |
|Automatic |Mengembalikan dengan pewarnaan otomatis |
|Gray |Mengembalikan dengan pewarnaan abu-abu |
|LightGray |Mengembalikan dengan pewarnaan abu-abu terang |
|InverseGray |Mengembalikan dengan pewarnaan abu-abu terbalik |
|GrayWhite |Mengembalikan dengan pewarnaan abu-abu dan putih |
|BlackGray |Mengembalikan dengan pewarnaan hitam dan abu-abu |
|BlackWhite |Mengembalikan dengan pewarnaan hitam dan putih |
|Black |Mengembalikan hanya dengan pewarnaan hitam |
|White |Mengembalikan dengan pewarnaan putih |
|Hidden |Objek tidak dirender |
#### **Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to com.aspose.slides.ICommentAuthorCollection**
Metode ICommentAuthorCollection.removeAt(int) telah ditambahkan untuk menghapus penulis berdasarkan indeks yang ditentukan. Metode ICommentAuthorCollection.remove(ICommentAuthor) telah ditambahkan untuk menghapus penulis tertentu dari koleksi. Metode ICommentAuthorCollection.clear() telah ditambahkan untuk menghapus semua item dari koleksi.