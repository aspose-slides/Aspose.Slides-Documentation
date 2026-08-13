---
title: Menambahkan Tanda Air ke Presentasi dalam C++
linktitle: Tanda Air
type: docs
weight: 40
url: /id/cpp/watermark/
keywords:
- tanda air
- tanda air teks
- tanda air gambar
- tambahkan tanda air
- ubah tanda air
- hapus tanda air
- hapus tanda air
- tambahkan tanda air ke PPT
- tambahkan tanda air ke PPTX
- tambahkan tanda air ke ODP
- hapus tanda air dari PPT
- hapus tanda air dari PPTX
- hapus tanda air dari ODP
- hapus tanda air dari PPT
- hapus tanda air dari PPTX
- hapus tanda air dari ODP
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kelola tanda air teks dan gambar di presentasi PowerPoint dan OpenDocument menggunakan C++ untuk menandakan draft, informasi rahasia, hak cipta, dan lainnya."
---
## **Pendahuluan**

**Watermark** dalam presentasi adalah cap teks atau gambar yang digunakan pada satu slide atau pada semua slide presentasi. Biasanya, watermark digunakan untuk menandakan bahwa presentasi tersebut masih draft (misalnya watermark “Draft”), mengandung informasi rahasia (misalnya watermark “Confidential”), menunjukkan perusahaan mana yang memilikinya (misalnya watermark “Company Name”), mengidentifikasi penulis presentasi, dll. Watermark membantu mencegah pelanggaran hak cipta dengan menunjukkan bahwa presentasi tidak boleh disalin. Watermark digunakan dalam format presentasi PowerPoint maupun OpenOffice. Di Aspose.Slides, Anda dapat menambahkan watermark ke format file PowerPoint PPT, PPTX, dan OpenOffice ODP.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/cpp/), terdapat berbagai cara untuk membuat watermark pada dokumen PowerPoint atau OpenOffice serta memodifikasi desain dan perilakunya. Aspek umum adalah bahwa untuk menambahkan watermark teks, Anda harus menggunakan antarmuka [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/), dan untuk menambahkan watermark gambar, gunakan kelas [PictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/pictureframe/) atau isi bentuk watermark dengan gambar. `PictureFrame` mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/), memungkinkan Anda menggunakan semua pengaturan fleksibel objek bentuk. Karena `ITextFrame` bukan bentuk dan pengaturannya terbatas, ia dibungkus ke dalam objek [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/).

Ada dua cara penerapan watermark: pada satu slide saja atau pada semua slide presentasi. Slide Master digunakan untuk menerapkan watermark ke semua slide – watermark ditambahkan ke Slide Master, dirancang sepenuhnya di sana, dan diterapkan ke semua slide tanpa memengaruhi izin mengedit watermark pada slide individual.

Watermark biasanya dianggap tidak dapat diedit oleh pengguna lain. Untuk mencegah watermark (atau bentuk induknya) diedit, Aspose.Slides menyediakan fungsi penguncian bentuk. Sebuah bentuk tertentu dapat dikunci pada slide biasa atau pada Slide Master. Ketika bentuk watermark dikunci pada Slide Master, ia akan terkunci pada semua slide presentasi.

Anda dapat menetapkan nama untuk watermark sehingga di masa mendatang, jika ingin menghapusnya, Anda dapat menemukannya di koleksi bentuk slide berdasarkan nama.

Anda dapat merancang watermark dengan cara apa saja; namun biasanya watermark memiliki fitur umum seperti perataan tengah, rotasi, posisi depan, dll. Kami akan membahas cara menggunakan fitur-fitur tersebut dalam contoh di bawah.

## **Watermark Teks**

### **Tambah Watermark Teks ke Slide**

Untuk menambahkan watermark teks pada PPT, PPTX, atau ODP, pertama‑tama tambahkan sebuah bentuk ke slide, lalu tambahkan bingkai teks ke bentuk tersebut. Bingkai teks direpresentasikan oleh antarmuka [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/). Tipe ini tidak mewarisi dari [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/), yang memiliki banyak properti untuk menempatkan watermark secara fleksibel. Oleh karena itu, objek [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) dibungkus dalam objek [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/). Untuk menambahkan teks watermark ke bentuk, gunakan metode [AddTextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/addtextframe/) seperti contoh di bawah.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Lihat juga" %}} 
- [Cara Menggunakan Kelas TextFrame](/slides/id/cpp/text-formatting/)
{{% /alert %}}

### **Tambah Watermark Teks ke Presentasi**

Jika Anda ingin menambahkan watermark teks ke seluruh presentasi (yaitu semua slide sekaligus), tambahkan ke [MasterSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/masterslide/). Logika selanjutnya sama dengan menambahkan watermark ke satu slide – buat objek [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) lalu tambahkan watermark menggunakan metode [AddTextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Lihat juga" %}} 
- [Cara Menggunakan Slide Master](/slides/id/cpp/slide-master/)
{{% /alert %}}

### **Atur Transparansi Bentuk Watermark**

Secara default, bentuk persegi panjang memiliki warna isi dan garis. Baris kode berikut menjadikan bentuk tersebut transparan.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Atur Font untuk Watermark Teks**

Anda dapat mengubah font watermark teks seperti contoh di bawah.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Atur Warna Teks Watermark**

Untuk mengatur warna teks watermark, gunakan kode berikut:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Tengahkan Watermark Teks**

Watermark dapat ditengahkan pada slide dengan langkah berikut:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

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

### **Tambah Watermark Gambar ke Presentasi**

Untuk menambahkan watermark gambar ke slide presentasi, lakukan hal berikut:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Kunci Watermark agar Tidak Dapat Diedit**

Jika perlu mencegah watermark diedit, gunakan metode [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/get_autoshapelock/) pada bentuk. Dengan properti ini, Anda dapat melindungi bentuk dari pemilihan, pengubahan ukuran, pemindahan posisi, pengelompokan dengan elemen lain, mengunci teksnya dari penyuntingan, dan banyak lagi:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// Kunci bentuk watermark agar tidak dapat diubah
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **Bawa Watermark ke Depan**

Di Aspose.Slides, urutan Z bentuk dapat diatur melalui metode [IShapeCollection::Reorder](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/reorder/). Untuk melakukannya, panggil metode ini dari daftar slide presentasi dan berikan referensi bentuk serta nomor urutannya. Dengan cara ini, Anda dapat membawa bentuk ke depan atau mengirimnya ke belakang slide. Fitur ini sangat berguna jika Anda perlu menempatkan watermark di depan presentasi:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Atur Rotasi Watermark**

Berikut contoh kode untuk menyesuaikan rotasi watermark sehingga posisinya miring melintasi slide:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Atur Nama untuk Watermark**

Aspose.Slides memungkinkan Anda menetapkan nama untuk sebuah bentuk. Dengan menggunakan nama bentuk, Anda dapat mengaksesnya di masa mendatang untuk memodifikasi atau menghapusnya. Untuk menetapkan nama pada bentuk watermark, panggil metode [IAutoShape::set_Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/set_name/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **Hapus Watermark**

Untuk menghapus bentuk watermark, gunakan metode [IAutoShape::get_Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_name/) untuk menemukan bentuk tersebut dalam koleksi bentuk slide. Kemudian, berikan bentuk watermark ke metode [IShapeCollection::Remove](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/remove/):

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **Contoh Langsung**

Anda mungkin ingin mencoba **Aspose.Slides free** [Tambah Watermark](https://products.aspose.app/slides/id/watermark) dan [Hapus Watermark](https://products.aspose.app/slides/id/watermark/remove-watermark) secara daring.

![Alat daring untuk menambah dan menghapus watermark](online_tools.png)

## **FAQ**

### Apa itu watermark dan mengapa saya harus menggunakannya?

Watermark adalah lapisan teks atau gambar yang diterapkan pada slide untuk melindungi hak kekayaan intelektual, meningkatkan pengenalan merek, atau mencegah penggunaan presentasi tanpa izin.

### Bisakah saya menambahkan watermark ke semua slide dalam sebuah presentasi?

Ya, Aspose.Slides memungkinkan Anda menambahkan watermark secara programatis ke setiap slide dalam presentasi. Anda dapat iterasi melalui semua slide dan menerapkan pengaturan watermark secara individual.

### Bagaimana cara menyesuaikan transparansi watermark?

Anda dapat menyesuaikan transparansi watermark dengan mengubah pengaturan isi ([FillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/get_fillformat/)) pada bentuk. Ini memastikan watermark tetap halus dan tidak mengganggu konten slide.

### Format gambar apa saja yang didukung untuk watermark?

Aspose.Slides mendukung berbagai format gambar seperti PNG, JPEG, GIF, BMP, SVG, dan lain‑lain.

### Bisakah saya menyesuaikan font dan gaya watermark teks?

Ya, Anda dapat memilih font, ukuran, dan gaya apa pun untuk mencocokkan desain presentasi Anda dan menjaga konsistensi merek.

### Bagaimana cara mengubah posisi atau orientasi watermark?

Anda dapat menyesuaikan posisi dan orientasi watermark secara programatis dengan memodifikasi koordinat, ukuran, dan properti rotasi bentuk.