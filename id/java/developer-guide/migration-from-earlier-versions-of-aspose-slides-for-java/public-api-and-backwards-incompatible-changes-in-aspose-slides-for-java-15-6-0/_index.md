---
title: Perubahan API Publik dan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 15.6.0
linktitle: Aspose.Slides untuk Java 15.6.0
type: docs
weight: 140
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
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
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="primary" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/), setiap batasan baru, dan [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) yang diperkenalkan dengan API Aspose.Slides for Java 15.6.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **Tanda tangan konstruktor com.aspose.slides.DataLabel telah diubah**
Tanda tangan konstruktor telah diubah dari DataLabel(com.aspose.slides.IChartSeries) menjadi DataLabel(com.aspose.slides.IChartDataPoint).
#### **Anggota com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) telah ditandai sebagai Deprecated; pengganti telah diperkenalkan**
Metode IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) telah ditandai sebagai Deprecated. Metode IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) telah diperkenalkan sebagai pengganti.
#### **Metode com.aspose.slides.INotesSlideManager.removeNotesSlide() telah ditambahkan**
Metode com.aspose.slides.INotesSlideManager.RemoveNotesSlide() telah ditambahkan untuk menghapus slide catatan dari suatu slide.
#### **Metode com.aspose.slides.ISlide.getNotesSlideManager() telah ditambahkan. Metode ISlide.getNotesSlide() dan ISlide.addNotesSlide() telah ditandai sebagai Deprecated**
Metode ISlide.getNotesSlide() dan ISlide.addNotesSlide() telah ditandai sebagai Deprecated. Gunakan metode baru ISlide.getNotesSlideManager() sebagai gantinya.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - tidak direkomendasikan

// notes = slide.getNotesSlide(); - tidak direkomendasikan

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Metode getAppVersion() telah ditambahkan ke com.aspose.slides.IDocumentProperties**
Metode com.aspose.slides.IDocumentProperties.getAppVersion() telah ditambahkan untuk mendapatkan properti dokumen bawaan yang mewakili nomor versi internal yang digunakan oleh Microsoft PowerPoint.
#### **Metode remove() telah ditambahkan ke com.aspose.slides.IComment**
Metode com.aspose.slides.IComment.remove() telah ditambahkan untuk menghapus komentar dari koleksi.
#### **Metode remove() telah ditambahkan ke com.aspose.slides.ICommentAuthor**
Metode ICommentAuthor.Remove telah ditambahkan untuk menghapus penulis komentar dari koleksi.
#### **Metode clearCustomProperties() dan clearBuiltInProperties() telah ditambahkan ke com.aspose.slides.IDocumentProperties**
Metode com.aspose.slides.IDocumentProperties.clearCustomProperties() telah ditambahkan untuk menghapus semua properti dokumen kustom.
Metode com.aspose.slides.IDocumentProperties.clearBuiltInProperties() telah ditambahkan untuk menghapus dan mengatur nilai default untuk semua properti dokumen bawaan (Company, Subject, Author, dll).
#### **Metode getBlackWhiteMode(), setBlackWhiteMode(byte) telah ditambahkan ke com.aspose.slides.IShape**
Metode getBlackWhiteMode(), setBlackWhiteMode(byte) telah ditambahkan ke com.aspose.slides.IShape. Metode‑metode ini menentukan bagaimana sebuah bentuk akan ditampilkan dalam mode tampilan hitam‑putih. Nilai‑nilai yang mungkin ditentukan dalam kelas com.aspose.slides.BlackWhiteMode.

|**Nilai**|**Makna**|
| :- | :- |
|Color|Kembalikan dengan pewarnaan normal|
|Automatic|Kembalikan dengan pewarnaan otomatis|
|Gray|Kembalikan dengan pewarnaan abu‑abu|
|LightGray|Kembalikan dengan pewarnaan abu‑abu terang|
|InverseGray|Kembalikan dengan pewarnaan abu‑abu terbalik|
|GrayWhite|Kembalikan dengan pewarnaan abu‑abu dan putih|
|BlackGray|Kembalikan dengan pewarnaan hitam dan abu‑abu|
|BlackWhite|Kembalikan dengan pewarnaan hitam dan putih|
|Black|Kembalikan hanya dengan pewarnaan hitam|
|White|Kembalikan dengan pewarnaan putih|
|Hidden|Objek tidak dirender|
#### **Metode removeAt(int), remove(ICommentAuthor) dan clear() telah ditambahkan ke com.aspose.slides.ICommentAuthorCollection**
Metode ICommentAuthorCollection.removeAt(int) telah ditambahkan untuk menghapus penulis berdasarkan indeks yang ditentukan. Metode ICommentAuthorCollection.remove(ICommentAuthor) telah ditambahkan untuk menghapus penulis yang ditentukan dari koleksi. Metode ICommentAuthorCollection.clear() telah ditambahkan untuk menghapus semua item dari koleksi.