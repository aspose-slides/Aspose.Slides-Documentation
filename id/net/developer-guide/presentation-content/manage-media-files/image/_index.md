---
title: Optimalkan Manajemen Gambar dalam Presentasi di .NET
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/net/image/
keywords:
- tambahkan gambar
- tambahkan foto
- tambahkan bitmap
- ganti gambar
- ganti foto
- dari web
- latar belakang
- tambahkan PNG
- tambahkan JPG
- tambahkan SVG
- tambahkan EMF
- tambahkan WMF
- tambahkan TIFF
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Permudah manajemen gambar di PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET, mengoptimalkan kinerja dan mengotomatisasi alur kerja Anda."
---
## **Pendahuluan**

Gambar membuat presentasi lebih menarik dan hidup. Di Microsoft PowerPoint, Anda dapat menyisipkan gambar dari file, internet, atau lokasi lain ke slide. Demikian pula, Aspose.Slides memungkinkan Anda menambahkan gambar ke slide dalam presentasi melalui berbagai prosedur.

{{% alert  title="Tip" color="primary" %}} 
Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan orang membuat presentasi dengan cepat dari gambar. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Jika Anda ingin menambahkan gambar sebagai objek bingkai—terutama jika Anda berencana menggunakan opsi pemformatan standar untuk mengubah ukurannya, menambahkan efek, dan sebagainya—lihat [Picture Frame](https://docs.aspose.com/slides/id/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Anda dapat memanipulasi operasi input/output yang melibatkan gambar dan presentasi PowerPoint untuk mengonversi gambar dari satu format ke format lain. Lihat halaman-halaman berikut: konversi [gambar ke JPG](https://products.aspose.com/slides/id/net/conversion/image-to-jpg/); konversi [JPG ke gambar](https://products.aspose.com/slides/id/net/conversion/jpg-to-image/); konversi [JPG ke PNG](https://products.aspose.com/slides/id/net/conversion/jpg-to-png/), konversi [PNG ke JPG](https://products.aspose.com/slides/id/net/conversion/png-to-jpg/); konversi [PNG ke SVG](https://products.aspose.com/slides/id/net/conversion/png-to-svg/), konversi [SVG ke PNG](https://products.aspose.com/slides/id/net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides mendukung operasi dengan gambar dalam format populer berikut: JPEG, PNG, BMP, GIF, dan lainnya. 

## **Menambahkan Gambar yang Disimpan Secara Lokal ke Slide**

Anda dapat menambahkan satu atau beberapa gambar di komputer Anda ke sebuah slide dalam presentasi. Kode contoh ini dalam C# menunjukkan cara menambahkan gambar ke slide:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Menambahkan Gambar dari Web ke Slide**

Jika gambar yang ingin Anda tambahkan ke slide tidak tersedia di komputer Anda, Anda dapat menambahkan gambar tersebut langsung dari web. 

Kode contoh ini menunjukkan cara menambahkan gambar dari web ke slide dalam C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Menambahkan Gambar ke Slide Master**

Slide master adalah slide utama yang menyimpan dan mengontrol informasi (tema, tata letak, dll.) tentang semua slide di bawahnya. Jadi, ketika Anda menambahkan gambar ke slide master, gambar tersebut muncul pada setiap slide di bawah slide master tersebut. 

Kode contoh C# ini menunjukkan cara menambahkan gambar ke slide master:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Menambahkan Gambar sebagai Latar Belakang Slide**

Anda mungkin memutuskan untuk menggunakan gambar sebagai latar belakang untuk satu slide tertentu atau beberapa slide. Dalam hal itu, Anda harus melihat *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/id/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Menambahkan SVG ke Presentasi**
Anda dapat menambahkan atau menyisipkan gambar apa pun ke dalam presentasi dengan menggunakan metode [AddPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/methods/addpictureframe) yang merupakan bagian dari antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection). 

Untuk membuat objek gambar berdasarkan gambar SVG, Anda dapat melakukannya dengan cara berikut:

1. Buat objek SvgImage untuk menyisipkannya ke ImageShapeCollection
2. Buat objek PPImage dari ISvgImage
3. Buat objek PictureFrame menggunakan antarmuka IPPImage

Kode contoh ini menunjukkan cara menerapkan langkah-langkah di atas untuk menambahkan gambar SVG ke dalam presentasi:
``` csharp 
// Jalur ke direktori dokumen
string dataDir = @"D:\Documents\";

// Nama file SVG sumber
string svgFileName = dataDir + "sample.svg";

// Nama file presentasi output
string outPptxPath = dataDir + "presentation.pptx";

// Buat presentasi baru
using (var p = new Presentation())
{
    // Baca konten file SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Buat objek SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Buat objek PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Membuat PictureFrame baru 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Simpan presentasi dalam format PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Mengonversi SVG menjadi Sekumpulan Bentuk**
Konversi SVG menjadi sekumpulan bentuk oleh Aspose.Slides mirip dengan fungsi PowerPoint yang digunakan untuk bekerja dengan gambar SVG:


![PowerPoint Popup Menu](img_01_01.png)

Fungsi ini disediakan oleh salah satu overload dari metode [AddGroupShape](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/addgroupshape/methods/1) pada antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection) yang menerima objek [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage) sebagai argumen pertama.

Kode contoh ini menunjukkan cara menggunakan metode yang dijelaskan untuk mengonversi file SVG menjadi sekumpulan bentuk:

``` csharp 
// Jalur ke direktori dokumen
string dataDir = @"D:\Documents\";

// Nama file SVG sumber
string svgFileName = dataDir + "sample.svg";

// Nama file presentasi output
string outPptxPath = dataDir + "presentation.pptx";

// Buat presentasi baru
using (IPresentation presentation = new Presentation())
{
    // Baca konten file SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Buat objek SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Dapatkan ukuran slide
    SizeF slideSize = presentation.SlideSize.Size;

    // Konversi gambar SVG menjadi grup bentuk dengan menskalakan ke ukuran slide
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Simpan presentasi dalam format PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Menambahkan Gambar sebagai EMF ke Slide**
Aspose.Slides untuk .NET memungkinkan Anda menghasilkan gambar EMF dari lembar Excel dan menambahkan gambar tersebut sebagai EMF di slide dengan Aspose.Cells. 

Kode contoh ini menunjukkan cara melakukan tugas yang dijelaskan:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Simpan workbook ke aliran
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Mengganti Gambar dalam Koleksi Gambar**

Aspose.Slides memungkinkan Anda mengganti gambar yang disimpan dalam koleksi gambar presentasi (termasuk yang digunakan oleh bentuk slide). Bagian ini menunjukkan beberapa pendekatan untuk memperbarui gambar dalam koleksi. API menyediakan metode sederhana untuk mengganti gambar menggunakan data byte mentah, instance [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/), atau gambar lain yang sudah ada dalam koleksi.

Ikuti langkah-langkah berikut:

1. Muat file presentasi yang berisi gambar menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Muat gambar baru dari file ke dalam array byte.
3. Ganti gambar target dengan gambar baru menggunakan array byte.
4. Dalam pendekatan kedua, muat gambar ke dalam objek [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) dan ganti gambar target dengan objek tersebut.
5. Dalam pendekatan ketiga, ganti gambar target dengan gambar yang sudah ada dalam koleksi gambar presentasi.
6. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

```cs
// Instansiasikan kelas Presentation yang mewakili file presentasi.
using Presentation presentation = new Presentation("sample.pptx");

// Cara pertama.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Cara kedua.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Cara ketiga.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Simpan presentasi ke file.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Dengan konverter Aspose GRATIS [Text to GIF](https://products.aspose.app/slides/id/text-to-gif), Anda dapat dengan mudah menghidupkan teks, membuat GIF dari teks, dll. 

{{% /alert %}}

## **FAQ**

**Apakah resolusi asli gambar tetap utuh setelah penyisipan?**

Ya. Piksel sumber dipertahankan, tetapi tampilan akhir bergantung pada cara [picture](/slides/id/net/picture-frame/) diskalakan pada slide dan kompresi apa pun yang diterapkan saat menyimpan.

**Apa cara terbaik untuk mengganti logo yang sama pada puluhan slide sekaligus?**

Tempatkan logo pada slide master atau layout dan ganti di koleksi gambar presentasi—pembaruan akan menyebar ke semua elemen yang menggunakan sumber daya tersebut.

**Apakah SVG yang disisipkan dapat diubah menjadi bentuk yang dapat diedit?**

Ya. Anda dapat mengonversi SVG menjadi grup bentuk, setelah itu bagian-bagian individual menjadi dapat diedit dengan properti bentuk standar.

**Bagaimana cara menetapkan gambar sebagai latar belakang untuk beberapa slide sekaligus?**

[Tetapkan gambar sebagai latar belakang](/slides/id/net/presentation-background/) pada slide master atau layout yang relevan—semua slide yang menggunakan master/layout tersebut akan mewarisi latar belakang.

**Bagaimana cara mencegah presentasi menjadi sangat besar karena banyak gambar?**

Gunakan kembali satu sumber gambar alih-alih duplikat, pilih resolusi yang wajar, terapkan kompresi saat menyimpan, dan pertahankan grafik berulang pada master bila sesuai.