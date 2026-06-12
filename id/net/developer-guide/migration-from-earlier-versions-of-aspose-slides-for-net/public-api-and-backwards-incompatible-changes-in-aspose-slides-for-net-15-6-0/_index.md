---
title: API Publik dan Perubahan Tidak Kompatibel Mundur pada Aspose.Slides untuk .NET 15.6.0
linktitle: Aspose.Slides untuk .NET 15.6.0
type: docs
weight: 170
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang merusak pada Aspose.Slides untuk .NET guna memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan mulus."
---
{{% alert color="primary" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [added](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) atau [removed](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/), serta perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk .NET 15.6.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **Tanda Tangan Konstruktor DataLabel Telah Diubah**
Tanda tangan konstruktor DataLabel telah diubah:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Anggota IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) Telah Ditandai Sebagai Usang dan Penggantiannya Telah Diperkenalkan Sebagai Pengganti.**
Properti IDocumentProperties.Count dan metode IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) telah ditandai sebagai Usang. Properti IDocumentProperties.CountOfCustomProperties dan metode IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) telah ditambahkan sebagai penggantinya.
#### **Metode INotesSlideManager.RemoveNotesSlide() Telah Ditambahkan**
Metode INotesSlideManager.RemoveNotesSlide() telah ditambahkan untuk menghapus slide catatan dari suatu slide.
#### **Metode Remove Telah Ditambahkan ke IComment**
Metode IComment.Remove telah ditambahkan untuk menghapus komentar dari koleksi.
#### **Metode Remove Telah Ditambahkan ke ICommentAuthor**
Metode ICommentAuthor.Remove telah ditambahkan untuk menghapus penulis komentar dari koleksi.
#### **Metode ClearCustomProperties dan ClearBuiltInProperties Telah Ditambahkan ke IDocumentProperties**
Metode IDocumentProperties.ClearCustomProperties telah ditambahkan untuk menghapus semua properti dokumen khusus.
Metode IDocumentProperties.ClearBuiltInProperties telah ditambahkan untuk menghapus dan mengatur nilai default untuk semua properti dokumen bawaan (Company, Subject, Author, dll).
#### **Metode RemoveAt, Remove, dan Clear Telah Ditambahkan ke ICommentAuthorCollection**
Metode ICommentAuthorCollection.RemoveAt telah ditambahkan untuk menghapus penulis berdasarkan indeks yang ditentukan.
Metode ICommentAuthorCollection.Remove telah ditambahkan untuk menghapus penulis tertentu dari koleksi.
Metode ICommentAuthorCollection.Clear telah ditambahkan untuk menghapus semua item dari koleksi.
#### **Properti AppVersion Telah Ditambahkan ke IDocumentProperties**
Properti IDocumentProperties.AppVersion telah ditambahkan untuk mendapatkan properti dokumen bawaan yang mewakili nomor versi internal yang digunakan Microsoft selama pengembangan.
#### **Properti BlackWhiteMode Telah Ditambahkan ke IShape dan ke Shape**
Properti BlackWhiteMode telah ditambahkan ke IShape dan ke Shape.

Properti ini menentukan bagaimana sebuah shape akan ditampilkan dalam mode tampilan hitam-putih.

|**Nilai** |**Arti** |
| :- | :- |
|Color |Render dengan warna normal |
|Automatic |Render dengan pewarnaan otomatis |
|Gray |Render dengan warna abu-abu |
|LightGray |Render dengan warna abu-abu muda |
|InverseGray |Render dengan warna abu-abu terbalik |
|GrayWhite |Render dengan warna abu-abu dan putih |
|BlackGray |Render dengan warna hitam dan abu-abu |
|BlackWhite |Render dengan warna hitam dan putih |
|Black |Render hanya dengan warna hitam |
|White |Render dengan warna putih |
|Hidden |Tidak dirender |
|NotDefined|menandakan properti tidak diatur|
#### **Properti ISlide.NotesSlideManager Telah Ditambahkan. Properti ISlide.NotesSlide dan Metode ISlide.AddNotesSlide() Telah Ditandai Sebagai Usang.**
Anggota ISlide.NotesSlide, ISlide.AddNotesSlide() telah ditandai sebagai Usang. Gunakan properti baru ISlide.NotesSlideManager sebagai gantinya.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - usang

// notes = slide.NotesSlide; - usang

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```