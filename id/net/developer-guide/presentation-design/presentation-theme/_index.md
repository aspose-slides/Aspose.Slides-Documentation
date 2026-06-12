---
title: Kelola Tema Presentasi di .NET
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/net/presentation-theme/
keywords:
- tema PowerPoint
- tema presentasi
- tema slide
- atur tema
- ubah tema
- kelola tema
- warna tema
- palet tambahan
- font tema
- gaya tema
- efek tema
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kuasai tema presentasi di Aspose.Slides untuk .NET untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan merek yang konsisten."
---
## **Pendahuluan**

Tema presentasi mendefinisikan properti elemen desain. Ketika Anda memilih tema presentasi, Anda pada dasarnya memilih satu set elemen visual tertentu beserta propertinya.

Di PowerPoint, sebuah tema terdiri dari warna, [font](/slides/id/net/powerpoint-fonts/), [gaya latar belakang](/slides/id/net/presentation-background/), dan efek.

![theme-constituents](theme-constituents.png)

## **Ubah Warna Tema**

Tema PowerPoint menggunakan satu set warna tertentu untuk elemen‑elemen berbeda pada slide. Jika Anda tidak menyukai warna‑warna tersebut, Anda dapat mengubahnya dengan menerapkan warna baru untuk tema. Untuk memungkinkan Anda memilih warna tema baru, Aspose.Slides menyediakan nilai‑nilai di bawah enumerasi [SchemeColor](https://reference.aspose.com/slides/id/net/aspose.slides/schemecolor/).

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Anda dapat menentukan nilai efektif warna yang dihasilkan dengan cara berikut:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Warna [A=255, R=128, G=100, B=162])
```

Untuk lebih menunjukkan operasi perubahan warna, kami membuat elemen lain dan menetapkan warna aksen (dari operasi awal) kepadanya. Kemudian kami mengubah warna dalam tema:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

Warna baru diterapkan secara otomatis pada kedua elemen.

### **Atur Warna Tema dari Palet Tambahan**

Ketika Anda menerapkan transformasi luminansi pada warna tema utama(1), warna‑warna dari palet tambahan(2) terbentuk. Anda kemudian dapat mengatur dan mengambil warna‑warna tema tersebut.

![additional-palette-colors](additional-palette-colors.png)

**1** - Warna tema utama  

**2** - Warna dari palet tambahan.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aksen 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Aksen 4, Lebih Terang 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Aksen 4, Lebih Terang 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Aksen 4, Lebih Terang 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Aksen 4, Lebih Gelap 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Aksen 4, Lebih Gelap 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **Pemetaan `SchemeColor` ke Warna `IColorScheme`**

Saat Anda bekerja dengan [SchemeColor](https://reference.aspose.com/slides/id/net/aspose.slides/schemecolor/), Anda mungkin memperhatikan bahwa ia berisi nilai‑nilai warna tema berikut:

`Background1`, `Background2`, `Text1`, dan `Text2`.

Namun, `Presentation.MasterTheme.ColorScheme` mengembalikan [IColorScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/icolorscheme/), yang menampilkan warna‑warna yang bersesuaian sebagai:

`Dark1`, `Dark2`, `Light1`, dan `Light2`.

Perbedaan ini hanya pada penamaan. Nilai‑nilai tersebut merujuk pada slot warna tema yang sama dan pemetaan bersifat tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Tidak ada konversi dinamis antara `Text`/`Background` dan `Dark`/`Light`. Mereka hanyalah nama alternatif untuk warna tema yang sama.

Perbedaan penamaan ini berasal dari terminologi Microsoft Office. Versi Office yang lebih lama menggunakan `Dark 1`, `Light 1`, `Dark 2`, dan `Light 2`, sementara versi UI yang lebih baru menampilkan slot yang sama sebagai `Text 1`, `Background 1`, `Text 2`, dan `Background 2`.

## **Ubah Font Tema**

Untuk memungkinkan Anda memilih font untuk tema dan keperluan lainnya, Aspose.Slides menggunakan pengenal khusus berikut (mirip dengan yang digunakan di PowerPoint):

* **+mn-lt** - Font Tubuh Latin (Font Latin Minor)
* **+mj-lt** - Font Judul Latin (Font Latin Mayor)
* **+mn-ea** - Font Tubuh Asia Timur (Font Asia Timur Minor)
* **+mj-ea** - Font Judul Asia Timur (Font Asia Timur Mayor)

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

Font pada semua kotak teks akan diperbarui.

{{% alert color="primary" title="TIP" %}} 
Anda mungkin ingin melihat [font PowerPoint](/slides/id/net/powerpoint-fonts/). 
{{% /alert %}}

## **Ubah Gaya Latar Belakang Tema**

Secara default, aplikasi PowerPoint menyediakan 12 latar belakang bawaan tetapi hanya 3 di antaranya yang disimpan dalam presentasi standar.

![todo:image_alt_text](presentation-design_8.png)

Misalnya, setelah Anda menyimpan presentasi di aplikasi PowerPoint, Anda dapat menjalankan kode C# berikut untuk mengetahui jumlah latar belakang bawaan dalam presentasi:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
Dengan menggunakan properti [BackgroundFillStyles](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/), Anda dapat menambah atau mengakses gaya latar belakang dalam tema PowerPoint. 
{{% /alert %}}

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Panduan indeks**: 0 berarti tanpa isian. Indeks dimulai dari 1.

{{% alert color="primary" title="TIP" %}} 
Anda mungkin ingin melihat [Latar Belakang PowerPoint](/slides/id/net/presentation-background/). 
{{% /alert %}}

## **Ubah Efek Tema**

Tema PowerPoint biasanya berisi 3 nilai untuk setiap array gaya. Array‑array tersebut digabungkan menjadi 3 efek: halus, sedang, dan intens. Misalnya, inilah hasil ketika efek‑efek tersebut diterapkan pada sebuah bentuk tertentu:

![todo:image_alt_text](presentation-design_10.png)

Dengan menggunakan 3 properti ([FillStyles](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/effectstyles)) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme) Anda dapat mengubah elemen‑elemen dalam tema (lebih fleksibel dibandingkan opsi di PowerPoint).

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Perubahan yang dihasilkan pada warna isian, tipe isian, efek bayangan, dll:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Apakah saya dapat menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Aspose.Slides mendukung penimpaan tema tingkat slide, sehingga Anda dapat menerapkan tema lokal hanya pada slide tersebut sambil mempertahankan tema master tidak berubah (melalui [SlideThemeManager](https://reference.aspose.com/slides/id/net/aspose.slides.theme/slidethememanager/)).

**Apa cara paling aman untuk memindahkan tema dari satu presentasi ke presentasi lain?**

[Clone slides](/slides/id/net/clone-slides/) bersama masternya ke dalam presentasi target. Ini mempertahankan master asli, tata letak, dan tema terkait sehingga tampilan tetap konsisten.

**Bagaimana saya dapat melihat nilai "efektif" setelah semua pewarisan dan penimpaan?**

Gunakan tampilan ["effective"](/slides/id/net/shape-effective-properties/) API untuk tema/warna/font/efek. Tampilan ini mengembalikan properti yang telah diselesaikan dan final setelah menerapkan master serta setiap penimpaan lokal.