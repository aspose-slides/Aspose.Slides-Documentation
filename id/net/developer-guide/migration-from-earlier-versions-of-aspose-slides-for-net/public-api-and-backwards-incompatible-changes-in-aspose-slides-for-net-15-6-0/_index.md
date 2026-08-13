---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 15.6.0
linktitle: Aspose.Slides for .NET 15.6.0
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
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk .NET agar dapat memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="info" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/), serta perubahan lain yang diperkenalkan dengan API Aspose.Slides for .NET 15.6.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **Tanda Tangan Konstruktor DataLabel Telah Diubah**
Tanda tangan konstruktor DataLabel telah diubah:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Anggota IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) Telah Ditandai sebagai Usang dan Penggantiannya Telah Diperkenalkan.**
Properti IDocumentProperties.Count dan metode IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) telah ditandai sebagai Usang. Properti IDocumentProperties.CountOfCustomProperties dan metode IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) telah ditambahkan sebagai gantinya.
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
Properti IDocumentProperties.AppVersion telah ditambahkan untuk memperoleh properti dokumen bawaan yang mewakili nomor versi internal yang digunakan Microsoft selama pengembangan.
#### **Properti BlackWhiteMode Telah Ditambahkan ke IShape dan ke Shape**
Properti BlackWhiteMode telah ditambahkan ke IShape dan ke Shape.

Properti ini menentukan bagaimana sebuah bentuk akan ditampilkan dalam mode tampilan hitam‑putih.

|**Nilai** |**Makna** |
| :- | :- |
|Color |Render dengan pewarnaan normal |
|Automatic |Render dengan pewarnaan otomatis |
|Gray |Render dengan pewarnaan abu‑abu |
|LightGray |Render dengan pewarnaan abu‑abu terang |
|InverseGray |Render dengan pewarnaan abu‑abu terbalik |
|GrayWhite |Render dengan pewarnaan abu‑abu dan putih |
|BlackGray |Render dengan pewarnaan hitam dan abu‑abu |
|BlackWhite |Render dengan pewarnaan hitam dan putih |
|Black |Render hanya dengan pewarnaan hitam |
|White |Render dengan pewarnaan putih |
|Hidden |Tidak dirender |
|NotDefined |menandakan bahwa properti tidak diatur |
#### **Properti ISlide.NotesSlideManager Telah Ditambahkan. Properti ISlide.NotesSlide dan Metode ISlide.AddNotesSlide() Telah Ditandai sebagai Usang.**
Anggota ISlide.NotesSlide dan ISlide.AddNotesSlide() telah ditandai sebagai Usang. Gunakan properti baru ISlide.NotesSlideManager sebagai gantinya.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - usang
    // notes = slide.NotesSlide; - usang

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```