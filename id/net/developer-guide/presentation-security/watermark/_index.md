---
title: Menambahkan Watermark ke Presentasi di .NET
linktitle: Watermark
type: docs
weight: 40
url: /id/net/watermark/
keywords:
- watermark
- watermark teks
- watermark gambar
- tambahkan watermark
- ubah watermark
- hapus watermark
- hapus watermark
- tambahkan watermark ke PPT
- tambahkan watermark ke PPTX
- tambahkan watermark ke ODP
- hapus watermark dari PPT
- hapus watermark dari PPTX
- hapus watermark dari ODP
- hapus watermark dari PPT
- hapus watermark dari PPTX
- hapus watermark dari ODP
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola watermark teks dan gambar dalam presentasi PowerPoint dan OpenDocument di .NET untuk menandakan draft, informasi rahasia, hak cipta, dan lainnya."
---
## **Pendahuluan**

**Watermark** dalam presentasi adalah cap teks atau gambar yang digunakan pada satu slide atau pada seluruh slide presentasi. Biasanya, watermark digunakan untuk menandakan bahwa presentasi tersebut masih berupa draft (misalnya watermark “Draft”), berisi informasi rahasia (misalnya watermark “Confidential”), menunjukkan perusahaan mana yang memilikinya (misalnya watermark “Company Name”), mengidentifikasi penulis presentasi, dll. Watermark membantu mencegah pelanggaran hak cipta dengan menunjukkan bahwa presentasi tidak boleh disalin. Watermark digunakan baik pada format presentasi PowerPoint maupun OpenDocument. Pada Aspose.Slides, Anda dapat menambahkan watermark ke format file PowerPoint PPT, PPTX, dan OpenDocument ODP.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/net/), terdapat berbagai cara untuk membuat watermark dalam dokumen PowerPoint atau OpenDocument serta memodifikasi desain dan perilakunya. Kesamaan utamanya adalah untuk menambahkan watermark teks, gunakan antarmuka [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/), dan untuk menambahkan watermark gambar, gunakan kelas [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/pictureframe/) atau isi bentuk watermark dengan gambar. `PictureFrame` mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape), sehingga Anda dapat menggunakan semua pengaturan fleksibel dari objek shape. Karena `ITextFrame` bukan shape dan pengaturannya terbatas, ia dibungkus ke dalam objek [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape).

Ada dua cara penerapan watermark: pada satu slide saja atau pada semua slide presentasi. Slide Master digunakan untuk menerapkan watermark pada semua slide — watermark ditambahkan ke Slide Master, didesain sepenuhnya di sana, dan diterapkan ke semua slide tanpa memengaruhi izin mengubah watermark pada slide individu.

Watermark biasanya dianggap tidak dapat diedit oleh pengguna lain. Untuk mencegah bentuk watermark (atau bentuk induknya) diubah, Aspose.Slides menyediakan fungsi penguncian shape. Sebuah shape tertentu dapat dikunci pada slide normal atau pada Slide Master. Ketika shape watermark dikunci pada Slide Master, ia akan terkunci pada semua slide presentasi.

Anda dapat memberi nama pada watermark sehingga di masa mendatang, bila ingin menghapusnya, Anda dapat menemukannya di dalam shape slide berdasarkan nama.

Anda dapat mendesain watermark dengan cara apa pun; namun umumnya watermark memiliki fitur umum seperti perataan tengah, rotasi, posisi depan, dll. Kami akan membahas cara menggunakan fitur-fitur tersebut dalam contoh berikut.

## **Watermark Teks**

### **Menambahkan Watermark Teks ke Slide**

Untuk menambahkan watermark teks dalam PPT, PPTX, atau ODP, pertama‑tama tambahkan shape ke slide, lalu tambahkan text frame ke shape tersebut. Text frame diwakili oleh antarmuka [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe). Tipe ini tidak diturunkan dari [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/), yang memiliki banyak properti untuk menempatkan watermark secara fleksibel. Oleh karena itu, objek [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe) dibungkus dalam objek [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/). Untuk menambahkan teks watermark ke shape, gunakan metode [AddTextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/methods/addtextframe) seperti contoh di bawah.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Tambahkan watermark ke slide.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Lihat juga" %}} 
- [Cara Menggunakan Kelas TextFrame?](/slides/id/net/text-formatting/)
{{% /alert %}}

### **Menambahkan Watermark Teks ke Seluruh Presentasi**

Jika Anda ingin menambahkan watermark teks ke seluruh presentasi (yaitu semua slide sekaligus), tambahkan ke [MasterSlide](https://reference.aspose.com/slides/id/net/aspose.slides/masterslide/). Logika selanjutnya sama seperti saat menambahkan watermark ke slide tunggal — buat objek [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) lalu tambahkan watermark menggunakan metode [AddTextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Tambahkan watermark ke master slide.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Lihat juga" %}} 
- [Cara Menggunakan Slide Master?](/slides/id/net/slide-master/)
{{% /alert %}}

### **Mengatur Transparansi Shape Watermark**

Secara default, shape persegi panjang memiliki warna isi dan garis. Ini berarti bahwa ketika watermark ditambahkan, ia dapat muncul dengan latar belakang atau border yang solid dan berpotensi mengalihkan perhatian dari konten slide. Untuk memastikan watermark tetap halus dan tidak mengganggu desain visual presentasi, Anda dapat membuat shape menjadi sepenuhnya transparan.

Baris kode berikut membuat shape transparan dengan menghapus warna isi dan warna border:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Mengatur Font untuk Watermark Teks**

Sebelum menerapkan watermark teks pada slide, penting untuk menyesuaikan tampilannya agar selaras dengan desain keseluruhan. Anda dapat mengubah tipe dan ukuran font sehingga watermark tetap mudah dibaca dan estetis. Menyesuaikan font juga dapat memperkuat identitas merek atau sekadar menyesuaikan gaya presentasi.

Potongan kode di bawah memperlihatkan cara mengatur font watermark dengan memilih font Latin tertentu dan menetapkan tinggi font yang tepat:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Mengatur Warna Teks Watermark**

Sebelum menerapkan watermark, penting untuk memastikan warna teks diatur dengan tepat sehingga menyatu dengan konten slide tanpa mendominasi. Menyesuaikan transparansi warna (alpha) bersama komponen merah, hijau, dan biru memungkinkan Anda menciptakan watermark semi‑transparan yang terlihat namun tidak mengganggu. Pendekatan ini membantu menjaga fokus pada isi utama presentasi sekaligus melindungi konten Anda.

Untuk mengatur warna teks watermark, gunakan kode berikut:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Menengahkan Watermark Teks**

Menengahkan watermark teks secara tepat dapat meningkatkan estetika keseluruhan presentasi dengan memastikan watermark berada pada posisi simetris, terlepas dari dimensi slide. Pendekatan ini tidak hanya memberi tampilan profesional pada slide, tetapi juga memastikan watermark tidak mengganggu konten utama.

Potongan kode di bawah menunjukkan cara menghitung posisi tengah slide dan menempatkan watermark teks sesuai itu:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Gambar di bawah menunjukkan hasil akhir.

![Watermark teks](text_watermark.png)

## **Watermark Gambar**

### **Menambahkan Watermark Gambar ke Presentasi**

Dalam banyak kasus, watermark gambar dapat memberikan elemen branding yang unik atau alternatif visual yang lebih menarik dibandingkan watermark teks. Sebelum menambahkan watermark, pastikan file gambar tersedia (misalnya PNG untuk transparansi). Contoh berikut memperlihatkan cara memuat gambar dari sistem file, menambahkannya ke presentasi, dan kemudian menerapkannya sebagai watermark melalui properti isi shape.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Mengunci Watermark dari Pengeditan**

Jika perlu mencegah watermark diedit, gunakan properti [IAutoShape.ShapeLock](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/properties/shapelock) pada shape. Dengan properti ini, Anda dapat melindungi shape dari pemilihan, pengubahan ukuran, pemindahan posisi, pengelompokan dengan elemen lain, mengunci teks dari pengeditan, dan banyak lagi:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Kunci shape watermark agar tidak dapat dimodifikasi.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Membawa Watermark ke Depan**

Di Aspose.Slides, urutan Z (Z‑order) shape dapat diatur melalui metode [IShapeCollection.Reorder](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/reorder/#reorder). Untuk melakukannya, panggil metode ini dari daftar slide presentasi dan berikan referensi shape serta nomor urutannya ke metode tersebut. Dengan cara ini, shape dapat dibawa ke depan atau dikirim ke belakang slide. Fitur ini sangat berguna bila Anda ingin menempatkan watermark di depan presentasi:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Mengatur Rotasi Watermark**

Menyesuaikan rotasi watermark dapat secara signifikan meningkatkan dampak visual dan kehalusan presentasi. Watermark diagonal, misalnya, dapat menjadi kurang mengganggu namun tetap memberikan perlindungan kuat terhadap penggunaan tidak sah. Contoh berikut menghitung sudut yang tepat berdasarkan dimensi slide sehingga watermark diposisikan secara diagonal melintasi slide. Perhitungan dinamis ini memastikan watermark tetap efektif meski ukuran slide bervariasi.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Menetapkan Nama untuk Watermark**

Aspose.Slides memungkinkan Anda mengatur nama sebuah shape. Dengan menggunakan nama shape, Anda dapat mengaksesnya di masa mendatang untuk memodifikasi atau menghapusnya. Untuk menetapkan nama pada shape watermark, tetapkan ke properti [IAutoShape.Name](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/properties/name):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Menghapus Watermark**

Untuk menghapus shape watermark, gunakan properti [IAutoShape.Name](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/properties/name) untuk menemukannya di dalam shape slide. Kemudian, berikan shape watermark ke metode [IShapeCollection.Remove](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/remove/) :

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Contoh Langsung**

Anda dapat mencoba **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/id/watermark) dan [Remove Watermark](https://products.aspose.app/slides/id/watermark/remove-watermark) secara online.

![Alat daring untuk menambah dan menghapus watermark](online_tools.png)

## **FAQ**

### Apa itu watermark dan mengapa saya harus menggunakannya?

Watermark adalah lapisan teks atau gambar yang diterapkan pada slide untuk membantu melindungi hak kekayaan intelektual, meningkatkan pengenalan merek, atau mencegah penggunaan tidak sah terhadap presentasi.

### Bisakah saya menambahkan watermark ke semua slide dalam sebuah presentasi?

Ya, Aspose.Slides memungkinkan Anda menambahkan watermark secara programatik ke setiap slide dalam sebuah presentasi. Anda dapat mengiterasi semua slide dan menerapkan pengaturan watermark satu per satu.

### Bagaimana cara mengatur transparansi watermark?

Anda dapat mengatur transparansi watermark dengan memodifikasi pengaturan isi ([FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/shape/fillformat/)) pada shape. Ini memastikan watermark tetap halus dan tidak mengalihkan perhatian dari konten slide.

### Format gambar apa yang didukung untuk watermark?

Aspose.Slides mendukung berbagai format gambar seperti PNG, JPEG, GIF, BMP, SVG, dan lainnya.

### Bisakah saya menyesuaikan font dan gaya watermark teks?

Ya, Anda dapat memilih font, ukuran, dan gaya apa saja untuk menyesuaikan desain presentasi Anda serta menjaga konsistensi merek.

### Bagaimana cara mengubah posisi atau orientasi watermark?

Anda dapat menyesuaikan posisi dan orientasi watermark secara programatik dengan memodifikasi koordinat, ukuran, dan properti rotasi shape.