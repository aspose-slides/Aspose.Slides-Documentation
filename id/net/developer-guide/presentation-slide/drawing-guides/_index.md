---
title: Kelola Panduan Menggambar dalam Presentasi di .NET
linktitle: Panduan Menggambar
type: docs
weight: 85
url: /id/net/drawing-guides/
keywords:
- panduan menggambar
- panduan horizontal
- panduan vertikal
- panduan penyelarasan
- tampilan slide
- slide master
- slide tata letak
- master catatan
- master handout
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tambahkan, akses, dan hapus panduan gambar horizontal serta vertikal dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET."
---
## **Ikhtisar**

Panduan gambar adalah garis horizontal dan vertikal yang dapat disesuaikan yang membantu pengguna menyelaraskan bentuk secara konsisten saat mengedit presentasi di PowerPoint. Mereka sangat berguna ketika sebuah aplikasi menghasilkan presentasi yang kemudian akan disempurnakan secara manual: aplikasi dapat menyimpan bantuan penyelarasan yang sama yang harus diikuti penulis saat menambahkan atau memindahkan konten.

Panduan gambar adalah bantuan penyuntingan, bukan konten slide. Mereka tidak muncul dalam tampilan slide atau output yang dirender. Aspose.Slides untuk .NET menampilkannya melalui antarmuka [IDrawingGuidesCollection](https://reference.aspose.com/slides/id/net/aspose.slides/idrawingguidescollection/) . Sebuah panduan direpresentasikan oleh [IDrawingGuide](https://reference.aspose.com/slides/id/net/aspose.slides/idrawingguide/) dan memiliki orientasi, posisi, serta warna.

Posisinya diukur dalam poin dari sudut kiri atas slide atau master yang relevan. Panduan vertikal menggunakan koordinat horizontal, biasanya antara nol dan lebar slide. Panduan horizontal menggunakan koordinat vertikal, biasanya antara nol dan tinggi slide.

## **Tambahkan Panduan ke Tampilan Slide**

Gunakan [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/id/net/aspose.slides/icommonslideviewproperties/drawingguides/) untuk mengelola panduan yang ditampilkan saat mengedit slide normal. Panggil [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/id/net/aspose.slides/idrawingguidescollection/add/) dengan nilai [Orientation](https://reference.aspose.com/slides/id/net/aspose.slides/orientation/) dan posisi dalam poin.

Contoh berikut menambahkan satu panduan vertikal di sebelah kanan tengah slide dan satu panduan horizontal di bawahnya:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Akses Panduan Gambar**

Properti [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/id/net/aspose.slides/idrawingguidescollection/count/) dan pengindeks menyediakan akses ke panduan yang ada. Properti [IDrawingGuide.Orientation](https://reference.aspose.com/slides/id/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/id/net/aspose.slides/idrawingguide/position/), dan [IDrawingGuide.Color](https://reference.aspose.com/slides/id/net/aspose.slides/idrawingguide/color/) dapat dibaca atau diubah.

Contoh berikut membaca panduan tampilan slide dari presentasi yang dibuat di atas:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Tambahkan Panduan ke Slide Master dan Layout**

Slide master dan setiap slide layoutnya dapat memiliki koleksi panduan gambar masing-masing. Gunakan [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/drawingguides/) untuk slide master dan [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/drawingguides/) untuk slide layout.

Contoh berikut menambahkan satu panduan vertikal ke slide master pertama dan satu panduan horizontal ke slide layout pertama:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Tambahkan Panduan ke Master Catatan dan Handout**

Master catatan dan master handout juga mendukung panduan gambar. Gunakan [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/id/net/aspose.slides/imasternotesslide/drawingguides/) dan [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/id/net/aspose.slides/imasterhandoutslide/drawingguides/) untuk mengakses koleksinya. Jika sebuah presentasi tidak berisi salah satu master tersebut, [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/id/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) atau [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/id/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) membuat master default dan mengembalikannya.

Contoh berikut menambahkan satu panduan horizontal ke master catatan dan satu panduan vertikal ke master handout:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Hapus Panduan Gambar**

Panggil [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/id/net/aspose.slides/idrawingguidescollection/clear/) untuk menghapus semua panduan dari koleksi tertentu. Menghapus satu koleksi tidak memengaruhi panduan yang disimpan dalam lingkup lain.

Contoh berikut menghapus panduan tampilan slide dan semua panduan pada slide master, slide layout, master catatan, dan master handout tanpa membuat master yang hilang:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **Tanya Jawab**

**Apakah panduan gambar muncul dalam pertunjukan slide atau gambar yang diekspor?**

Tidak. Panduan gambar adalah bantuan penyelarasan untuk penyuntingan dan tidak dirender sebagai konten presentasi.

**Dapatkah panduan gambar ditambahkan langsung ke slide normal individual?**

Panduan penyuntingan slide normal disimpan dalam properti tampilan slide presentasi. Koleksi panduan terpisah tersedia untuk slide master, slide layout, master catatan, dan master handout.

**Unit apa yang digunakan untuk posisi panduan?**

Posisi ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Posisi vertikal diukur dari tepi kiri, dan posisi horizontal diukur dari tepi atas.

**Apakah menghapus panduan gambar menghilangkan bentuk atau mengubah konten slide?**

Tidak. Metode `Clear` hanya menghapus panduan dalam koleksi yang dipilih. Bentuk dan konten slide lainnya tetap tidak berubah.