---
title: Kelola Slide Master Presentasi di .NET
linktitle: Master Slide
type: docs
weight: 80
url: /id/net/slide-master/
keywords:
- master slide
- master slide
- master slide PPT
- banyak master slide
- bandingkan master slide
- latar belakang
- placeholder
- klon master slide
- salin master slide
- duplikasi master slide
- master slide yang tidak digunakan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola master slide di Aspose.Slides untuk .NET: akses, edit, klon, bandingkan, dan hapus master slide dalam presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Sebuah **slide master** mendefinisikan pengaturan desain bersama untuk sekelompok slide. Itu dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara umum untuk menjaga konsistensi presentasi tanpa mengulang format yang sama pada setiap slide.

Aspose.Slides for .NET mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih slide master, dan setiap slide master dapat berisi beberapa layout slide. Slide normal biasanya tidak merujuk langsung ke slide master. Sebaliknya, slide normal menggunakan layout slide, dan layout slide tersebut berada di bawah slide master.

Hierarki adalah:

1. **Slide master** - mendefinisikan desain bersama dan tema.  
2. **Layout slide** - mendefinisikan susunan spesifik placeholder dan format tingkat layout.  
3. **Normal slide** - berisi konten presentasi sebenarnya dan menggunakan satu layout slide.

![Hierarki slide master, layout slide, dan slide normal](slide-master_2.jpg)

Di Aspose.Slides, slide master direpresentasikan oleh antarmuka [IMasterSlide](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/). Semua slide master dalam sebuah presentasi tersedia melalui koleksi [Presentation.Masters](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/masters/), yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Ketika properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang menang. Misalnya, jika slide master dan layout slide keduanya mendefinisikan latar belakang, slide yang berbasis pada layout tersebut akan menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Terapkan atau Ubah Tata Letak Slide](/slides/id/net/slide-layout/).
{{% /alert %}}

## **Akses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master dari **View** > **Slide Master**.

![Perintah Slide Master pada tab View di PowerPoint](slide-master_3.jpg)

Di Aspose.Slides, gunakan koleksi `Masters` untuk mengakses slide master:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Anda juga dapat memperoleh slide master yang digunakan oleh slide normal melalui layout-nya:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Apa yang Dimiliki Slide Master**

Slide master adalah objek mirip slide. Ia mengimplementasikan [IBaseSlide](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/), sehingga menampilkan banyak properti slide yang sama digunakan oleh slide normal dan layout slide. Anggota khusus master tercantum pada halaman API [IMasterSlide](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/).

Anggota slide master yang sering digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `Background` | Mengatur latar belakang slide pada tingkat master. |
| `Shapes` | Menyimpan bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `LayoutSlides` | Menyimpan layout slide yang termasuk dalam master. |
| `ThemeManager` | Memberikan akses ke API tema master. |
| `HeaderFooterManager` | Mengontrol header, footer, tanggal, dan nomor slide untuk master dan layout turunannya. |
| `GetDependingSlides` | Mengembalikan slide normal yang bergantung pada master melalui layout mereka. |

## **Menambahkan Gambar ke Slide Master**

Saat Anda menambahkan gambar ke slide master, gambar tersebut muncul pada slide yang menggunakan layout dari master itu. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

Contoh berikut menambahkan logo ke slide master pertama:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Bingkai Gambar](/slides/id/net/picture-frame/).

## **Mengontrol Visibilitas Grafik Master**

Gunakan [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/showmastershapes/) untuk menyembunyikan grafik master yang diwariskan, seperti logo atau bentuk dekoratif, tanpa menghapusnya dari master. Setel [Slide.ShowMasterShapes](https://reference.aspose.com/slides/id/net/aspose.slides/slide/showmastershapes/) menjadi `false` pada slide yang harus menghilangkan grafik tersebut dan tetap `true` pada slide yang harus menampilkannya.

Contoh mandiri berikut membuat pita dekoratif biru pada master dan dua slide yang menggunakan layout kosong yang sama. Pita terlihat pada slide pertama dan disembunyikan pada slide kedua. Tidak diperlukan presentasi atau gambar masukan.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

Contoh ini menggunakan layout **Blank** yang disertakan dengan presentasi baru dan menghapus placeholder slide pertama.

### **Pilih Lingkup Pengaturan**

Slide normal menggunakan master melalui [ISlide.LayoutSlide](https://reference.aspose.com/slides/id/net/aspose.slides/islide/layoutslide/) dan [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/masterslide/). Menetapkan properti pada slide individu hanya memengaruhi slide tersebut. Menetapkan [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/id/net/aspose.slides/layoutslide/showmastershapes/) menjadi `false` menyembunyikan grafik master untuk semua slide yang memakai layout bersama itu, bahkan jika pengaturan mereka sendiri `true`. Untuk menyembunyikan grafik pada satu slide saja, ubah properti slide dan biarkan layout bersama tetap tidak berubah.

Pengaturan ini tidak didukung sebagai kontrol visibilitas pada slide master itu sendiri. Pada master selalu mengembalikan `false`, dan menetapkan `true` menghasilkan `NotSupportedException`. Terapkan pada slide normal atau layout saja.

### **Bedakan Grafik dari Latar Belakang**

| Operasi | Efek |
| --- | --- |
| Sembunyikan grafik master | Mengontrol visibilitas bentuk master yang diwariskan tanpa menghapusnya atau mengubah bentuk pada slide itu sendiri. |
| Ubah isian latar belakang slide | Mengubah warna, gradien, atau gambar latar belakang. Grafik master adalah bentuk terpisah dan dapat tetap terlihat di atas latar tersebut. Lihat [Presentation Background](/slides/id/net/presentation-background/). |
| Hapus bentuk dari master | Menghapus bentuk sumber bersama, sehingga tidak lagi tersedia bagi slide apa pun yang menggunakan master tersebut. |

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Slide master menyediakan gaya dan tema bersama yang diwarisi oleh layout tersebut, sedangkan setiap layout menentukan placeholder mana yang tersedia dan di mana penempatannya.

Di PowerPoint, perintah placeholder tersedia dalam tampilan Slide Master.

![Perintah Insert Placeholder di tampilan Slide Master PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, bekerja dengan layout slide yang berada di bawah master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Anda juga dapat memformat bentuk placeholder yang sudah ada pada slide master. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linear:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Placeholder judul yang diformat diwariskan oleh slide normal](slide-master_8.png)

Untuk opsi format placeholder dan teks lebih lanjut, lihat [Set Prompt Text in Placeholder](/slides/id/net/manage-placeholder/) dan [Text Formatting](/slides/id/net/text-formatting/).

## **Ubah Latar Belakang Slide Master**

Latar belakang master diwariskan oleh layout dan slide yang tidak menggantinya. Contoh berikut menetapkan warna latar belakang solid untuk slide master pertama:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Untuk topik terkait, lihat [Presentation Background](/slides/id/net/presentation-background/) dan [Presentation Theme](/slides/id/net/presentation-theme/).

## **Klon Master Slide ke Presentasi Lain**

Gunakan [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection/addclone/) untuk menyalin slide master ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh layout dan slide di presentasi tujuan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Jika Anda perlu mengkloning slide normal bersama masternya, lihat [Clone Slides](/slides/id/net/clone-slides/).

## **Tambah Beberapa Slide Master**

Sebuah presentasi dapat berisi beberapa slide master. Ini berguna ketika bagian berbeda memerlukan merek, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola slide master](slide-master_9.jpg)

Contoh berikut mengkloning master default, memberi klon latar belakang berbeda, membuat layout di bawah master yang diklon, dan menambahkan slide baru berdasarkan layout tersebut:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Bandingkan Slide Master**

Slide master dapat dibandingkan dengan metode `Equals` yang diwarisi dari [IBaseSlide](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/). Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, format, animasi, dan pengaturan slide lainnya. Itu tidak membandingkan pengidentifikasi unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

```csharp
using Aspose.Slides;

using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Untuk informasi lebih lanjut, lihat [Compare Presentation Slides](/slides/id/net/compare-slides/).

## **Atur Tampilan Slide Master sebagai Tampilan Default**

Gunakan properti `LastView` pada [ViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/) untuk mengontrol tampilan yang dibuka PowerPoint pertama kali. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Untuk pengaturan tampilan lainnya, lihat [Save Presentation](/slides/id/net/save-presentation/).

## **Hapus Slide Master yang Tidak Digunakan**

Presentasi kadang berisi slide master yang tidak lagi dipakai oleh slide normal mana pun. Menghapus master yang tidak terpakai dapat mengurangi ukuran file dan menyederhanakan pemeliharaan templat.

Gunakan [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/id/net/aspose.slides/masterslidecollection/removeunused/) untuk menghapus master yang tidak terpakai dari koleksi `Masters`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Anda juga dapat menggunakan metode low-code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apa perbedaan antara slide master dan layout slide?**

Slide master mendefinisikan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Layout slide berada di bawah slide master dan mendefinisikan susunan spesifik placeholder. Slide normal menggunakan layout slide, sehingga mewarisi dari keduanya.

**Apakah satu presentasi dapat berisi beberapa slide master?**

Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan banyak master ketika bagian berbeda memerlukan sistem visual atau merek yang berbeda.

**Haruskah saya menambahkan placeholder ke slide master atau ke layout slide?**

Dalam kebanyakan kasus, tambahkan placeholder ke layout slide. Tempatkan elemen visual dan format bersama pada slide master, kemudian letakkan placeholder konten pada layout yang akan dipakai slide normal.

**Apakah saya dapat menghapus slide master yang masih digunakan?**

Tidak. Slide master yang memiliki slide tergantung tidak dapat dihapus secara langsung. Pindahkan slide tersebut ke layout di bawah master lain, atau gunakan metode pembersihan master yang tidak terpakai.