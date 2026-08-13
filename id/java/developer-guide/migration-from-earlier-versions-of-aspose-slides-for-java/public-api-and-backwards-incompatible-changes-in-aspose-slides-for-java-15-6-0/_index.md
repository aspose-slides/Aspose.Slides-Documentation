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
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan mulus."
---
{{% alert color="info" %}} 
Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) , semua pembatasan baru, dan [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) lainnya yang diperkenalkan dengan API Aspose.Slides for Java 15.6.0.
{{% /alert %}} 
## **Perubahan API Publik**
#### **Tanda tangan konstruktor com.aspose.slides.DataLabel telah diubah**
Tanda tangan konstruktor telah diubah dari DataLabel(com.aspose.slides.IChartSeries) menjadi DataLabel(com.aspose.slides.IChartDataPoint).
#### **Anggota com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) telah ditandai sebagai Usang; pengganti telah diperkenalkan**
Metode IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) telah ditandai sebagai Usang. Sebagai gantinya, telah diperkenalkan metode IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name).
#### **Metode com.aspose.slides.INotesSlideManager.removeNotesSlide() telah ditambahkan**
Metode com.aspose.slides.INotesSlideManager.RemoveNotesSlide() telah ditambahkan untuk menghapus slide catatan dari sebuah slide.
#### **Metode com.aspose.slides.ISlide.getNotesSlideManager() telah ditambahkan. Metode ISlide.getNotesSlide() dan ISlide.addNotesSlide() telah ditandai sebagai Usang**
Metode ISlide.getNotesSlide() dan ISlide.addNotesSlide() telah ditandai sebagai Usang. Gunakan metode baru ISlide.getNotesSlideManager() sebagai gantinya.
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - usang

    // notes = slide.getNotesSlide(); - usang

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Metode getAppVersion() telah ditambahkan ke com.aspose.slides.IDocumentProperties**
Metode com.aspose.slides.IDocumentProperties.getAppVersion() telah ditambahkan untuk mendapatkan properti dokumen bawaan, yang mewakili nomor versi internal yang digunakan oleh Microsoft PowerPoint.
#### **Metode remove() telah ditambahkan ke com.aspose.slides.IComment**
Metode com.aspose.slides.IComment.remove() telah ditambahkan untuk menghapus komentar dari koleksi.
#### **Metode remove() telah ditambahkan ke com.aspose.slides.ICommentAuthor**
Metode ICommentAuthor.Remove telah ditambahkan untuk menghapus penulis komentar dari koleksi.
#### **Metode clearCustomProperties() dan clearBuiltInProperties() telah ditambahkan ke com.aspose.slides.IDocumentProperties**
Metode com.aspose.slides.IDocumentProperties.clearCustomProperties() telah ditambahkan untuk menghapus semua properti dokumen khusus.
Metode com.aspose.slides.IDocumentProperties.clearBuiltInProperties() telah ditambahkan untuk menghapus dan mengatur nilai default untuk semua properti dokumen bawaan (Company, Subject, Author, dll).
#### **Metode getBlackWhiteMode(), setBlackWhiteMode(byte) telah ditambahkan ke com.aspose.slides.IShape**
Metode getBlackWhiteMode() dan setBlackWhiteMode(byte) telah ditambahkan ke com.aspose.slides.IShape. Metode-metode ini menentukan bagaimana sebuah shape akan ditampilkan dalam mode tampilan hitam-putih. Nilai‑nilai yang mungkin ditentukan dalam kelas com.aspose.slides.BlackWhiteMode.

|**Nilai** |**Makna** |
| :- | :- |
|Color |Kembali dengan pewarnaan normal |
|Automatic |Kembali dengan pewarnaan otomatis |
|Gray |Kembali dengan pewarnaan abu-abu |
|LightGray |Kembali dengan pewarnaan abu-abu terang |
|InverseGray |Kembali dengan pewarnaan abu-abu terbalik |
|GrayWhite |Kembali dengan pewarnaan abu-abu dan putih |
|BlackGray |Kembali dengan pewarnaan hitam dan abu-abu |
|BlackWhite |Kembali dengan pewarnaan hitam dan putih |
|Black |Hanya kembali dengan pewarnaan hitam |
|White |Kembali dengan pewarnaan putih |
|Hidden |Objek tidak ditampilkan |
#### **Metode removeAt(int), remove(ICommentAuthor) dan clear() telah ditambahkan ke com.aspose.slides.ICommentAuthorCollection**
Metode ICommentAuthorCollection.removeAt(int) telah ditambahkan untuk menghapus penulis berdasarkan indeks yang ditentukan. Metode ICommentAuthorCollection.remove(ICommentAuthor) telah ditambahkan untuk menghapus penulis tertentu dari koleksi. Metode ICommentAuthorCollection.clear() telah ditambahkan untuk menghapus semua item dari koleksi.