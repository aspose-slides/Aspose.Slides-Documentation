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
- menambahkan watermark
- mengubah watermark
- menghapus watermark
- menghapus watermark
- menambahkan watermark ke PPT
- menambahkan watermark ke PPTX
- menambahkan watermark ke ODP
- menghapus watermark dari PPT
- menghapus watermark dari PPTX
- menghapus watermark dari ODP
- menghapus watermark dari PPT
- menghapus watermark dari PPTX
- menghapus watermark dari ODP
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola watermark teks dan gambar dalam presentasi PowerPoint dan OpenDocument di .NET untuk menunjukkan draf, informasi rahasia, hak cipta, dan lainnya."
---
## **Pendahuluan**

**Watermark** dalam sebuah presentasi adalah stempel teks atau gambar yang digunakan pada satu slide atau pada semua slide presentasi. Biasanya, watermark digunakan untuk menunjukkan bahwa presentasi tersebut masih draf (misalnya watermark "Draft"), bahwa berisi informasi rahasia (misalnya watermark "Confidential"), untuk menyebutkan perusahaan mana yang memilikinya (misalnya watermark "Company Name"), untuk mengidentifikasi penulis presentasi, dll. Watermark membantu mencegah pelanggaran hak cipta dengan menunjukkan bahwa presentasi tidak boleh disalin. Watermark digunakan baik dalam format presentasi PowerPoint maupun OpenDocument. Di Aspose.Slides, Anda dapat menambahkan watermark ke format file PowerPoint PPT, PPTX, dan OpenDocument ODP.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/net/), ada berbagai cara untuk membuat watermark dalam dokumen PowerPoint atau OpenDocument serta memodifikasi desain dan perilakunya. Aspek umum adalah untuk menambahkan watermark teks, Anda harus menggunakan antarmuka [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/), dan untuk menambahkan watermark gambar, gunakan kelas [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/pictureframe/) atau isi shape watermark dengan gambar. `PictureFrame` mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape) , memungkinkan Anda menggunakan semua pengaturan fleksibel dari objek shape. Karena `ITextFrame` bukan shape dan pengaturannya terbatas, ia dibungkus ke dalam objek [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape).

Ada dua cara watermark dapat diterapkan: pada satu slide atau pada semua slide presentasi. Slide Master digunakan untuk menerapkan watermark ke semua slide presentasi — watermark ditambahkan ke Slide Master, sepenuhnya didesain di sana, dan diterapkan ke semua slide tanpa memengaruhi izin untuk memodifikasi watermark pada slide individual.

Watermark biasanya dianggap tidak dapat diedit oleh pengguna lain. Untuk mencegah watermark (atau lebih tepatnya shape induk watermark) diedit, Aspose.Slides menyediakan fungsi penguncian shape. Sebuah shape tertentu dapat dikunci pada slide biasa atau pada Slide Master. Ketika shape watermark dikunci pada Slide Master, ia akan terkunci pada semua slide presentasi.

Anda dapat menetapkan nama untuk watermark sehingga di masa depan, jika ingin menghapusnya, Anda dapat menemukannya di shape slide berdasarkan nama.

Anda dapat merancang watermark dengan cara apa pun; namun biasanya ada fitur umum pada watermark, seperti perataan tengah, rotasi, posisi depan, dll. Kami akan membahas cara menggunakan ini dalam contoh di bawah.

## **Watermark Teks**

### **Tambahkan Watermark Teks ke Slide**

Untuk menambahkan watermark teks dalam PPT, PPTX, atau ODP, Anda dapat terlebih dahulu menambahkan shape ke slide, kemudian menambahkan text frame ke shape tersebut. Text frame diwakili oleh antarmuka [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe). Tipe ini tidak mewarisi dari [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/), yang memiliki banyak properti untuk menempatkan watermark secara fleksibel. Oleh karena itu, objek [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe) dibungkus dalam objek [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/). Untuk menambahkan teks watermark ke shape, gunakan metode [AddTextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/methods/addtextframe) seperti ditunjukkan di bawah.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Tambahkan watermark ke slide.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Lihat juga" %}} 
- [Cara Menggunakan Kelas TextFrame?](/slides/id/net/text-formatting/)
{{% /alert %}}

### **Tambahkan Watermark Teks ke Presentasi**

Jika Anda ingin menambahkan watermark teks ke seluruh presentasi (misalnya semua slide sekaligus), tambahkan ke [MasterSlide](https://reference.aspose.com/slides/id/net/aspose.slides/masterslide/). Logika sisanya sama seperti saat menambahkan watermark ke satu slide — buat objek [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) kemudian tambahkan watermark ke dalamnya menggunakan metode [AddTextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Tambahkan watermark ke slide master.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Lihat juga" %}} 
- [Cara Menggunakan Slide Master?](/slides/id/net/slide-master/)
{{% /alert %}}

### **Atur Transparansi Shape Watermark**

Secara default, shape persegi panjang memiliki warna isi dan garis. Ini berarti ketika watermark ditambahkan, mungkin muncul dengan latar belakang solid atau border yang dapat mengalihkan perhatian dari konten slide. Untuk memastikan watermark tetap halus dan tidak mengganggu desain visual presentasi, Anda dapat membuat shape sepenuhnya transparan.

Baris kode berikut membuat shape menjadi transparan dengan menghapus warna isi dan warna garisnya:

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Atur Font untuk Watermark Teks**

Sebelum menerapkan watermark teks ke slide Anda, penting untuk menyesuaikan tampilannya agar selaras dengan desain keseluruhan. Anda dapat mengubah jenis dan ukuran font untuk memastikan watermark dapat dibaca dan estetis. Menyesuaikan font juga dapat membantu memperkuat identitas merek atau sekadar menyesuaikan gaya presentasi.

Potongan kode di bawah menunjukkan cara menyesuaikan pengaturan font watermark dengan memilih font Latin tertentu dan menetapkan tinggi font yang sesuai:

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Atur Warna Teks Watermark**

Sebelum menerapkan watermark Anda, penting memastikan warna teks diatur dengan tepat sehingga menyatu dengan konten slide tanpa mendominasi. Mengatur transparansi warna (alpha) bersama komponen merah, hijau, dan biru memungkinkan Anda membuat watermark semi-transparan yang terlihat namun tidak mengganggu. Pendekatan ini membantu mempertahankan fokus pada presentasi utama sekaligus melindungi konten Anda.

Untuk mengatur warna teks watermark, gunakan kode berikut:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Pusatkan Watermark Teks**

Menempatkan watermark teks dengan tepat di tengah dapat secara signifikan meningkatkan estetika keseluruhan presentasi dengan memastikan watermark berada pada posisi simetris, terlepas dari dimensi slide. Pendekatan ini tidak hanya memberikan tampilan profesional tetapi juga memastikan watermark tidak mengganggu konten utama slide.

Potongan kode di bawah menunjukkan cara menghitung posisi tengah slide dan menempatkan watermark teks secara tepat:

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

![Watermark teks](text_watermark.png)

## **Watermark Gambar**

### **Tambahkan Watermark Gambar ke Presentasi**

Dalam banyak kasus, watermark gambar dapat memberikan elemen branding yang unik atau alternatif yang lebih menarik secara visual dibandingkan watermark teks. Sebelum menambahkan watermark, pastikan file gambar tersedia (misalnya PNG untuk transparansi). Contoh berikut menunjukkan cara memuat gambar dari sistem file Anda, menambahkannya ke presentasi, dan kemudian menerapkannya sebagai watermark menggunakan properti isi shape.

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Kunci Watermark agar Tidak Diedit**

Jika diperlukan untuk mencegah watermark diedit, gunakan properti [IAutoShape.ShapeLock](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/properties/shapelock) pada shape. Dengan properti ini, Anda dapat melindungi shape dari dipilih, diubah ukuran, dipindahkan, dikelompokkan dengan elemen lain, mengunci teksnya dari pengeditan, dan lain-lain:

```cs
// Kunci shape watermark agar tidak dapat dimodifikasi.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Bawa Watermark ke Depan**

Di Aspose.Slides, urutan Z (Z-order) shape dapat diatur melalui metode [IShapeCollection.Reorder](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/reorder/#reorder). Untuk melakukannya, panggil metode ini dari daftar slide presentasi dan berikan referensi shape serta nomor urutannya ke metode tersebut. Dengan cara ini, memungkinkan untuk membawa shape ke depan atau mengirimnya ke belakang slide. Fitur ini sangat berguna jika Anda perlu menempatkan watermark di depan presentasi:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Atur Rotasi Watermark**

Mengatur rotasi watermark Anda dapat secara signifikan meningkatkan dampak visual dan kesan halus pada presentasi. Misalnya, watermark diagonal dapat kurang mengganggu sambil tetap memberikan perlindungan kuat terhadap penggunaan tidak sah. Contoh berikut menghitung sudut yang tepat berdasarkan dimensi slide sehingga watermark ditempatkan secara diagonal melintasi slide. Perhitungan dinamis ini memastikan watermark tetap efektif terlepas dari variasi ukuran slide.

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Tetapkan Nama untuk Watermark**

Aspose.Slides memungkinkan Anda menetapkan nama pada sebuah shape. Dengan menggunakan nama shape, Anda dapat mengaksesnya di masa mendatang untuk memodifikasi atau menghapusnya. Untuk menetapkan nama pada shape watermark, beri nilai pada properti [IAutoShape.Name](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/properties/name):

```cs
watermarkShape.Name = "watermark";
```

## **Hapus Watermark**

Untuk menghapus shape watermark, gunakan properti [IAutoShape.Name](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/properties/name) untuk menemukannya di shape slide. Kemudian, berikan shape watermark ke metode [IShapeCollection.Remove](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/remove/):

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Contoh Langsung**

Anda mungkin ingin melihat alat daring **Aspose.Slides gratis** [Add Watermark](https://products.aspose.app/slides/id/watermark) dan [Remove Watermark](https://products.aspose.app/slides/id/watermark/remove-watermark).

![Alat daring untuk menambah dan menghapus watermark](online_tools.png)

## **FAQ**

**Apa itu watermark dan mengapa saya harus menggunakannya?**

Watermark adalah overlay teks atau gambar yang diterapkan pada slide yang membantu melindungi hak kekayaan intelektual, meningkatkan pengenalan merek, atau mencegah penggunaan tidak sah presentasi.

**Bisakah saya menambahkan watermark ke semua slide dalam sebuah presentasi?**

Ya, Aspose.Slides memungkinkan Anda secara programatik menambahkan watermark ke setiap slide dalam presentasi. Anda dapat iterasi semua slide dan menerapkan pengaturan watermark secara individual.

**Bagaimana cara menyesuaikan transparansi watermark?**

Anda dapat menyesuaikan transparansi watermark dengan memodifikasi pengaturan isi ([FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/shape/fillformat/)) shape. Ini memastikan watermark halus dan tidak mengalihkan perhatian dari konten slide.

**Format gambar apa yang didukung untuk watermark?**

Aspose.Slides mendukung berbagai format gambar seperti PNG, JPEG, GIF, BMP, SVG, dan lainnya.

**Dapatkah saya menyesuaikan font dan gaya watermark teks?**

Ya, Anda dapat memilih font, ukuran, dan gaya apa pun untuk mencocokkan desain presentasi dan menjaga konsistensi merek.

**Bagaimana cara mengubah posisi atau orientasi watermark?**

Anda dapat menyesuaikan posisi dan orientasi watermark secara programatik dengan memodifikasi koordinat, ukuran, dan properti rotasi shape.