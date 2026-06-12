---
title: Menambahkan Watermark ke Presentasi dalam C++
linktitle: Watermark
type: docs
weight: 40
url: /id/cpp/watermark/
keywords:
- tanda air
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
- C++
- Aspose.Slides
description: "Kelola watermark teks dan gambar dalam presentasi PowerPoint dan OpenDocument menggunakan C++ untuk menunjukkan draf, informasi rahasia, hak cipta, dan lain-lain."
---
## **Pendahuluan**

**Watermark** dalam sebuah presentasi adalah stempel teks atau gambar yang digunakan pada satu slide atau pada semua slide presentasi. Biasanya, watermark digunakan untuk menunjukkan bahwa presentasi tersebut masih draft (misalnya watermark "Draft"), bahwa berisi informasi rahasia (misalnya watermark "Confidential"), untuk menentukan perusahaan mana yang memilikinya (misalnya watermark "Company Name"), untuk mengidentifikasi penulis presentasi, dll. Watermark membantu mencegah pelanggaran hak cipta dengan menunjukkan bahwa presentasi tidak boleh disalin. Watermark digunakan dalam format presentasi PowerPoint dan OpenOffice. Dalam Aspose.Slides, Anda dapat menambahkan watermark ke format file PowerPoint PPT, PPTX, dan OpenOffice ODP.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/cpp/), terdapat berbagai cara untuk membuat watermark dalam dokumen PowerPoint atau OpenOffice dan memodifikasi desain serta perilakunya. Aspek umum adalah untuk menambahkan watermark teks, Anda harus menggunakan antarmuka [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/), dan untuk menambahkan watermark gambar, gunakan kelas [PictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/pictureframe/) atau isi bentuk watermark dengan gambar. `PictureFrame` mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/), memungkinkan Anda menggunakan semua pengaturan fleksibel dari objek bentuk. Karena `ITextFrame` bukan bentuk dan pengaturannya terbatas, ia dibungkus ke dalam objek [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/).

Ada dua cara untuk menerapkan watermark: pada satu slide atau pada semua slide presentasi. Slide Master digunakan untuk menerapkan watermark ke semua slide presentasi — watermark ditambahkan ke Slide Master, sepenuhnya dirancang di sana, dan diterapkan ke semua slide tanpa mempengaruhi izin untuk memodifikasi watermark pada slide individu.

Watermark biasanya dianggap tidak dapat diedit oleh pengguna lain. Untuk mencegah watermark (atau lebih tepatnya bentuk induk watermark) agar tidak diedit, Aspose.Slides menyediakan fungsi penguncian bentuk. Sebuah bentuk tertentu dapat dikunci pada slide biasa atau pada Slide Master. Ketika bentuk watermark dikunci pada Slide Master, ia akan terkunci pada semua slide presentasi.

Anda dapat menetapkan nama untuk watermark sehingga di masa mendatang, jika ingin menghapusnya, Anda dapat menemukannya di bentuk-bentuk slide berdasarkan nama.

Anda dapat merancang watermark dengan cara apa pun; namun biasanya ada fitur umum pada watermark, seperti perataan tengah, rotasi, posisi di depan, dll. Kami akan menunjukkan cara menggunakan ini dalam contoh di bawah.

## **Watermark Teks**

### **Menambahkan Watermark Teks ke Slide**

Untuk menambahkan watermark teks dalam PPT, PPTX, atau ODP, Anda dapat pertama-tama menambahkan sebuah bentuk ke slide, lalu menambahkan sebuah frame teks ke bentuk tersebut. Frame teks diwakili oleh antarmuka [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/). Tipe ini tidak mewarisi dari [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/), yang memiliki banyak properti untuk memposisikan watermark secara fleksibel. Oleh karena itu, objek [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) dibungkus dalam objek [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/). Untuk menambahkan teks watermark ke bentuk, gunakan metode [AddTextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/addtextframe/) seperti ditunjukkan di bawah.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Lihat juga" %}} 
- [Cara Menggunakan Kelas TextFrame](/slides/id/cpp/text-formatting/)
{{% /alert %}}

### **Menambahkan Watermark Teks ke Presentasi**

Jika Anda ingin menambahkan watermark teks ke seluruh presentasi (yaitu semua slide sekaligus), tambahkan ke [MasterSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/masterslide/). Logika selanjutnya sama seperti menambahkan watermark ke satu slide — buat objek [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) dan kemudian tambahkan watermark ke dalamnya menggunakan metode [AddTextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Lihat juga" %}} 
- [Cara Menggunakan Slide Master](/slides/id/cpp/slide-master/)
{{% /alert %}}

### **Mengatur Transparansi Bentuk Watermark**

Secara default, bentuk persegi panjang memiliki warna isi dan garis. Baris kode berikut membuat bentuk menjadi transparan.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Mengatur Font untuk Watermark Teks**

Anda dapat mengubah font watermark teks seperti yang ditunjukkan di bawah.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Mengatur Warna Teks Watermark**

Untuk mengatur warna teks watermark, gunakan kode berikut:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Menengahkan Watermark Teks**

Anda dapat menengahkan watermark pada slide, dan untuk itu, lakukan hal berikut:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

Gambar di bawah menunjukkan hasil akhir.

![Watermark teks](text_watermark.png)

## **Watermark Gambar**

### **Menambahkan Watermark Gambar ke Presentasi**

Untuk menambahkan watermark gambar ke slide presentasi, Anda dapat melakukan hal berikut:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Mengunci Watermark agar Tidak Diedit**

Jika perlu mencegah watermark agar tidak diedit, gunakan metode [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/get_autoshapelock/) pada bentuk. Dengan properti ini, Anda dapat melindungi bentuk dari pemilihan, perubahan ukuran, pemindahan, pengelompokan dengan elemen lain, mengunci teksnya dari penyuntingan, dan banyak lagi:

```cpp
// Kunci bentuk watermark agar tidak dapat diubah
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Membawa Watermark ke Depan**

Dalam Aspose.Slides, urutan Z bentuk dapat diatur melalui metode [IShapeCollection::Reorder](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/reorder/). Untuk melakukannya, Anda perlu memanggil metode ini dari daftar slide presentasi dan menyertakan referensi bentuk serta nomor urutannya ke dalam metode. Dengan cara ini, Anda dapat membawa bentuk ke depan atau mengirimnya ke belakang slide. Fitur ini sangat berguna jika Anda perlu menempatkan watermark di depan presentasi:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Mengatur Rotasi Watermark**

Berikut contoh kode cara mengatur rotasi watermark sehingga posisinya diagonal melintasi slide:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Menetapkan Nama untuk Watermark**

Aspose.Slides memungkinkan Anda menetapkan nama pada sebuah bentuk. Dengan menggunakan nama bentuk, Anda dapat mengaksesnya di masa depan untuk memodifikasi atau menghapusnya. Untuk menetapkan nama pada bentuk watermark, berikan ke metode [IAutoShape::set_Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/set_name/):

```cpp
watermarkShape->set_Name(u"watermark");
```

## **Menghapus Watermark**

Untuk menghapus bentuk watermark, gunakan metode [IAutoShape::get_Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_name/) untuk menemukannya di bentuk-bentuk slide. Kemudian, berikan bentuk watermark ke metode [IShapeCollection::Remove](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/remove/):

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Contoh Langsung**

Anda mungkin ingin melihat **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/id/watermark) dan [Remove Watermark](https://products.aspose.app/slides/id/watermark/remove-watermark) alat daring.

![Alat daring untuk menambah dan menghapus watermark](online_tools.png)

## **FAQ**

**Apa itu watermark dan mengapa saya harus menggunakannya?**

Watermark adalah lapisan teks atau gambar yang diterapkan pada slide yang membantu melindungi hak kekayaan intelektual, meningkatkan pengenalan merek, atau mencegah penggunaan presentasi yang tidak sah.

**Apakah saya dapat menambahkan watermark ke semua slide dalam sebuah presentasi?**

Ya, Aspose.Slides memungkinkan Anda menambahkan watermark secara programatik ke setiap slide dalam sebuah presentasi. Anda dapat mengiterasi semua slide dan menerapkan pengaturan watermark secara individual.

**Bagaimana cara menyesuaikan transparansi watermark?**

Anda dapat menyesuaikan transparansi watermark dengan memodifikasi pengaturan isi ([FillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/get_fillformat/)) pada bentuk. Hal ini memastikan watermark terlihat halus dan tidak mengalihkan perhatian dari konten slide.

**Format gambar apa yang didukung untuk watermark?**

Aspose.Slides mendukung berbagai format gambar seperti PNG, JPEG, GIF, BMP, SVG, dan lainnya.

**Apakah saya dapat menyesuaikan font dan gaya watermark teks?**

Ya, Anda dapat memilih font, ukuran, dan gaya apa pun untuk menyesuaikan desain presentasi Anda dan mempertahankan konsistensi merek.

**Bagaimana cara mengubah posisi atau orientasi watermark?**

Anda dapat menyesuaikan posisi dan orientasi watermark secara programatik dengan memodifikasi koordinat, ukuran, dan properti rotasi bentuk.