---
title: Kelola Slide Master Presentasi di .NET
linktitle: Master Slide
type: docs
weight: 80
url: /id/net/slide-master/
keywords:
- master slide
- slide master
- slide master PPT
- banyak master slide
- bandingkan master slide
- latar belakang
- placeholder
- kloning master slide
- salin master slide
- duplikasi master slide
- master slide tidak terpakai
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola master slide di Aspose.Slides untuk .NET: akses, edit, klon, bandingkan, dan hapus master slide dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Sebuah **slide master** mendefinisikan pengaturan desain bersama untuk sekelompok slide. Itu dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara biasa untuk menjaga konsistensi presentasi tanpa mengulangi pemformatan yang sama pada setiap slide.

Aspose.Slides untuk .NET mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih master slide, dan setiap master slide dapat berisi beberapa layout slide. Slide normal biasanya tidak merujuk langsung ke master slide. Sebaliknya, slide normal menggunakan layout slide, dan layout slide tersebut merupakan bagian dari master slide.

Hierarki adalah:

1. **Slide master** - mendefinisikan desain dan tema bersama.  
1. **Layout slide** - mendefinisikan susunan spesifik placeholder dan pemformatan tingkat layout.  
1. **Normal slide** - berisi konten presentasi sebenarnya dan menggunakan satu layout slide.

![Hierarki master slide, layout slide, dan slide normal](slide-master_2.jpg)

Dalam Aspose.Slides, slide master direpresentasikan oleh antarmuka [IMasterSlide](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/) . Semua master slide dalam sebuah presentasi dapat diakses melalui koleksi [Presentation.Masters](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/masters/) , yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection/) .

{{% alert color="info" title="Pewarisan" %}}
Saat properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang menang. Misalnya, jika master slide dan layout slide keduanya mendefinisikan latar belakang, slide yang berbasis pada layout tersebut akan menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Apply or Change Slide Layouts](/slides/id/net/slide-layout/) .
{{% /alert %}}

## **Akses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master dari **View** > **Slide Master**.

![Perintah Slide Master pada tab View di PowerPoint](slide-master_3.jpg)

Dalam Aspose.Slides, gunakan koleksi `Masters` untuk mengakses master slide:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Anda juga dapat memperoleh master slide yang digunakan oleh slide normal melalui layout-nya:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Apa yang Dimiliki Slide Master**

Sebuah master slide adalah objek yang mirip slide. Itu mengimplementasikan [IBaseSlide](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/) , sehingga menampilkan banyak properti slide yang sama yang digunakan oleh slide normal dan layout. Anggota khusus master terdaftar pada halaman API [IMasterSlide](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/) .

Anggota master slide yang sering digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `Background` | Mengatur latar belakang slide pada tingkat master. |
| `Shapes` | Menyimpan bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `LayoutSlides` | Menyimpan layout slide yang menjadi bagian dari master. |
| `ThemeManager` | Memberikan akses ke API tema master. |
| `HeaderFooterManager` | Mengontrol header, footer, tanggal, dan nomor slide untuk master dan layout anaknya. |
| `GetDependingSlides` | Mengembalikan slide normal yang bergantung pada master melalui layout mereka. |

## **Menambahkan Gambar ke Slide Master**

Saat Anda menambahkan gambar ke master slide, gambar tersebut muncul pada slide yang menggunakan layout dari master itu. Hal ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

Contoh berikut menambahkan logo ke master slide pertama:

```csharp
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

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Picture Frame](/slides/id/net/picture-frame/) .

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Master slide menyediakan gaya dan tema bersama yang diwariskan oleh layout tersebut, sementara setiap layout memutuskan placeholder mana yang tersedia dan di mana penempatannya.

Di PowerPoint, perintah placeholder tersedia di tampilan Slide Master.

![Perintah Insert Placeholder di tampilan Slide Master PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, bekerja dengan layout slide yang merupakan bagian dari master:

```csharp
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

Anda juga dapat memformat bentuk placeholder yang sudah ada pada master slide. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linear:

```csharp
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

Untuk opsi pemformatan placeholder dan teks lebih lanjut, lihat [Set Prompt Text in Placeholder](/slides/id/net/manage-placeholder/) dan [Text Formatting](/slides/id/net/text-formatting/) .

## **Ubah Latar Belakang Slide Master**

Latar belakang master diwariskan oleh layout dan slide yang tidak menimpanya. Contoh berikut mengatur warna latar belakang solid untuk master slide pertama:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Untuk topik terkait, lihat [Presentation Background](/slides/id/net/presentation-background/) dan [Presentation Theme](/slides/id/net/presentation-theme/) .

## **Menyalin Slide Master ke Presentasi Lain**

Gunakan [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection/addclone/) untuk menyalin master slide ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh layout dan slide dalam presentasi tujuan.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Jika Anda perlu menyalin slide normal bersama masternya, lihat [Clone Slides](/slides/id/net/clone-slides/) .

## **Menambahkan Beberapa Slide Master**

Sebuah presentasi dapat berisi beberapa master slide. Hal ini berguna ketika bagian yang berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola master slide](slide-master_9.jpg)

Contoh berikut menyalin master default, memberi salinan latar belakang yang berbeda, membuat layout di bawah master yang disalin, dan menambahkan slide baru berdasarkan layout tersebut:

```csharp
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

## **Membandingkan Slide Master**

Master slide dapat dibandingkan dengan metode `Equals` yang diwariskan dari [IBaseSlide](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/) . Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, pemformatan, animasi, dan pengaturan slide lainnya. Tidak memeriksa pengidentifikasi unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

```csharp
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

Untuk informasi lebih lanjut, lihat [Compare Presentation Slides](/slides/id/net/compare-slides/) .

## **Menetapkan Tampilan Slide Master sebagai Tampilan Default**

Gunakan properti `LastView` pada [ViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/) untuk mengontrol tampilan yang pertama kali dibuka PowerPoint. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Untuk pengaturan tampilan lebih lanjut, lihat [Save Presentation](/slides/id/net/save-presentation/) .

## **Menghapus Master Slide yang Tidak Digunakan**

Presentasi terkadang berisi master slide yang tidak lagi digunakan oleh slide normal mana pun. Menghapus master yang tidak digunakan dapat mengurangi ukuran file dan menyederhanakan pemeliharaan templat.

Gunakan [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/id/net/aspose.slides/masterslidecollection/removeunused/) untuk menghapus master yang tidak digunakan dari koleksi `Masters`:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Anda juga dapat menggunakan metode low‑code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apa perbedaan antara slide master dan layout slide?**

Slide master mendefinisikan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Layout slide merupakan bagian dari master slide dan mendefinisikan susunan spesifik placeholder. Slide normal menggunakan layout slide, sehingga mewarisi dari layout maupun master.

**Apakah satu presentasi dapat berisi beberapa slide master?**

Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan beberapa master ketika bagian yang berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke master slide atau layout slide?**

Dalam kebanyakan kasus, tambahkan placeholder ke layout slide. Letakkan elemen visual bersama dan pemformatan bersama pada master slide, kemudian tempatkan placeholder konten pada layout yang akan dipakai slide normal.

**Apakah saya dapat menghapus master slide yang masih digunakan?**

Tidak. Master slide yang memiliki slide bergantung tidak dapat dihapus secara aman. Pindahkan slide tersebut ke layout di bawah master lain terlebih dahulu, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.