---
title: Kelola Bingkai Gambar dalam Presentasi Menggunakan C++
linktitle: Bingkai Gambar
type: docs
weight: 10
url: /id/cpp/picture-frame/
keywords:
- bingkai gambar
- tambahkan bingkai gambar
- buat bingkai gambar
- gambar tersemat
- gambar tertaut
- ekstrak gambar
- gambar raster
- gambar SVG
- potong gambar
- hapus area yang dipotong
- kompres gambar
- StretchOffset
- pemformatan bingkai gambar
- skala relatif
- efek gambar
- rasio aspek
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: Buat, format, tautkan, potong, ekstrak, dan kompres bingkai gambar dalam presentasi dengan Aspose.Slides untuk C++.
---
## **Ikhtisar**

Bingkai gambar adalah bentuk slide yang menampilkan sebuah gambar. Dalam Aspose.Slides, sumber daya gambar dan bentuk yang menampilkannya adalah objek yang terpisah: sebuah [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) memiliki sumber daya gambar tersemat melalui [image collection](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_images/), sementara sebuah [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) mengontrol posisi gambar, ukuran, pemformatan garis, rotasi, pemotongan, efek gambar, dan pengaturan tingkat bingkai lainnya.

Pemisasian ini berguna ketika gambar yang sama ditampilkan lebih dari satu kali. Tambahkan gambar ke presentasi sekali saja, simpan [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) yang dikembalikan, dan gunakan sumber daya gambar tersebut saat membuat bingkai gambar.

Bingkai gambar dapat berisi gambar raster seperti PNG atau JPEG serta gambar vektor SVG. Mereka juga dapat merujuk ke gambar tertaut alih-alih menyimpan byte gambar di dalam presentasi. Pilihan ini memengaruhi portabilitas, ukuran file, ekstraksi, dan perilaku ekspor, jadi sebaiknya tentukan bagaimana gambar harus disimpan sebelum menerapkan pemformatan atau optimalisasi.

## **Menambahkan dan Memformat Gambar Tersemat**

Untuk gambar tersemat, tambahkan data gambar ke presentasi dan buat bingkai gambar dengan [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapecollection/addpictureframe/). Gambar menjadi bagian dari paket presentasi, sehingga presentasi tetap mandiri ketika dipindahkan ke komputer lain.

Contoh berikut menambahkan gambar JPEG, membuat bingkai dengan dimensi asli gambar, dan menerapkan pemformatan garis serta rotasi:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bingkai gambar mengontrol geometri yang ditampilkan; mengubah ukuran bingkai tidak mengubah dimensi piksel asli yang disimpan dalam sumber daya gambar tersemat. Perbedaan ini menjadi penting saat memotong atau mengompres gambar nanti.

## **Gunakan Skala Relatif**

[IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) memperlihatkan skala lebar dan tinggi relatif untuk bingkai. Nilai `1.0` bersesuaian dengan 100% ukuran gambar asli. Skala relatif berguna ketika alur kerja perlu mempertahankan hubungan dengan ukuran gambar sumber alih-alih menghitung dimensi akhir secara manual.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Skala relatif mengubah pengaturan skala bingkai; tidak melakukan resampling atau kompresi pada gambar tersemat.

## **Gambar Tersemat dan Tertaut**

Gambar tersemat menyimpan data gambar di dalam presentasi dan karena itu menjadi pilihan paling aman untuk portabilitas dan rendering yang dapat diprediksi. Gambar tertaut menyimpan lokasi eksternal melalui jalur tautan [ISlidesPicture](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidespicture/) alih-alih menyematkan data gambar dengan cara yang sama.

Gambar tertaut dapat mengurangi jumlah data gambar yang disimpan dalam PPTX, tetapi mereka memperkenalkan ketergantungan eksternal. File tertaut harus tetap dapat diakses oleh aplikasi yang membuka atau merender presentasi. Jika jalur berubah, file dipindahkan, atau sumber tidak tersedia, gambar tertaut mungkin tidak ditampilkan sebagaimana mestinya. Untuk presentasi yang harus dikirim lewat email, diarsipkan, atau dirender di lingkungan terisolasi, gambar tersemat biasanya lebih dapat diandalkan.

### **Menambahkan Gambar Tertaut**

Contoh berikut membuat bingkai gambar dan menunjukkannya ke file gambar lokal. Ini hanya menangani penautan gambar; penautan video adalah alur media terpisah dan sengaja tidak dicampur dalam contoh ini.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Gunakan tautan ketika manajemen file eksternal memang dimaksudkan. Jangan menggunakannya hanya sebagai pengganti kompresi: PPTX kecil dengan ketergantungan gambar yang rusak biasanya kurang berguna dibandingkan presentasi mandiri yang lebih besar.

## **Ekstrak Gambar dari Bingkai Gambar**

Sebelum mengekstrak gambar dari presentasi yang ada, periksa bahwa sebuah bentuk memang merupakan [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) dan bahwa bentuk tersebut berisi gambar tersemat. Bingkai gambar tertaut mungkin tidak berisi byte gambar yang dapat diekstrak dengan cara yang sama.

### **Ekstrak Gambar Raster**

API gambar modern menggunakan [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) secara langsung. Contoh berikut menemukan gambar raster tersemat pertama pada slide dan menyimpannya sebagai PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

Menyimpan melalui [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) mengonversi gambar yang diekstrak ke format output yang diminta. Jika Anda membutuhkan byte terenkode yang disimpan dalam presentasi alih-alih file raster yang dikonversi, gunakan data biner sumber daya gambar tersebut.

### **Ekstrak Gambar SVG**

Untuk gambar SVG, [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) memperlihatkan objek [ISvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/). Ini memungkinkan Anda mengambil data SVG secara langsung alih-alih merasterkan gambar terlebih dahulu.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

Menyimpan konten SVG sebagai SVG mempertahankan sumber vektor di dalam presentasi. Ekspor raster seperti PNG atau JPEG secara otomatis merender konten vektor tersebut menjadi piksel. Ekspor slide ke PDF atau SVG juga merupakan operasi rendering, sehingga grafik yang diekspor tidak boleh dianggap sebagai salinan byte-per-byte dari SVG tersemat asli; gunakan data [ISvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/) tersemat ketika sumber vektor asli diperlukan.

## **Memotong Gambar**

Pemotongan mengubah bagian gambar yang terlihat di dalam bingkai. Nilai pemotongan pada [IPictureFillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/) adalah persentase dari dimensi gambar sumber. Pemotongan tidak langsung menghapus piksel tersembunyi dari gambar tersemat; hanya mengubah wilayah yang terlihat.

Contoh berikut menemukan bingkai gambar dengan aman dan menerapkan nilai pemotongan:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Karena data gambar tersembunyi masih ada, pemotongan dapat diubah nanti tanpa kehilangan piksel asli. Jika ukuran file lebih penting daripada kemampuan memulihkan, daerah yang dipotong dapat dihapus secara fisik seperti dijelaskan pada bagian berikutnya.

## **Menghapus Data Gambar yang Dipotong**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) menghapus data gambar di luar persegi pemotongan saat ini dan mengembalikan sumber daya gambar yang dihasilkan. Ini dapat mengurangi ukuran file, tetapi merupakan optimasi destruktif: setelah presentasi disimpan, piksel yang dihapus tidak lagi tersedia untuk operasi un-crop di kemudian hari.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

Metode ini dapat menambahkan sumber daya gambar baru ke presentasi. Jika gambar asli juga digunakan oleh bingkai gambar lain, bingkai tersebut masih memerlukan sumber daya yang ada, sehingga menghapus area yang dipotong tidak selalu mengurangi total jumlah gambar. Memotong konten WMF atau EMF dengan metode ini merasterkan hasil potongan menjadi PNG.

## **Kompres Gambar Raster**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/compressimage/) mengurangi resolusi gambar raster relatif terhadap ukuran di mana gambar ditampilkan. Ini juga dapat menghapus daerah yang dipotong dalam operasi yang sama. Metode mengembalikan `true` ketika gambar diubah ukuran atau dipotong dan `false` ketika tidak ada perubahan yang diperlukan.

Gunakan nilai [PicturesCompression](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/picturescompression/) yang telah ditentukan sebelumnya ketika resolusi target standar sudah memadai:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Nilai DPI positif khusus dapat diberikan alih-alih nilai enum ketika target spesifik diperlukan.

Kompresi ditujukan untuk gambar raster. Konten SVG dan metafile tidak berkurang dengan alur kerja kompresi raster ini. Juga ingat bahwa resolusi lebih rendah dan daerah yang dipotong yang dihapus tidak dapat dipulihkan dari presentasi yang dioptimalkan. Pilih resolusi target berdasarkan ukuran terbesar di mana gambar akan benar-benar dilihat atau diekspor, bukan dengan menerapkan DPI terendah secara global.

## **Memeriksa Efek Gambar**

Efek gambar disimpan pada gambar yang digunakan oleh bingkai. Koleksi transformasi gambar dapat berisi efek seperti modulasi alfa tetap untuk transparansi dan luminansi untuk kecerahan serta kontras. Contoh di bawah ini membaca kedua jenis efek dengan aman dari bingkai gambar pertama pada slide:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

Efek-efek ini mengubah cara gambar dirender dalam bingkai; mereka tidak menulis ulang byte gambar tersemat asli.

## **Kunci Geometri Bingkai Gambar**

Pengaturan [IPictureFrameLock](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframelock/) mengontrol operasi penyuntingan mana yang dinonaktifkan untuk sebuah bingkai gambar. Misalnya, [aspect-ratio lock](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) mempertahankan proporsi bentuk saat diubah ukuran.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kunci berlaku pada bentuk bingkai gambar. Itu tidak memaksa gambar sumber untuk di-resample atau diubah secara permanen menjadi rasio aspek yang sama.

## **Sesuaikan Nilai StretchOffset**

Ketika mode isi gambar adalah stretch, nilai stretch-offset pada [IPictureFillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/) mendefinisikan persegi isi relatif terhadap kotak pembatas bingkai gambar. Persentase positif membuat inset dari tepi, sementara persentase negatif membuat outset.

Ini berbeda dari pemotongan. Nilai crop memilih bagian gambar sumber yang terlihat; stretch offset mengubah persegi tempat isi gambar yang terlihat diregangkan.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Gunakan stretch offset untuk penempatan isi. Gunakan properti crop ketika tujuan menutup tepi gambar sumber.

## **Pertimbangan Penyimpanan, Ukuran File, dan Ekspor**

Pertukaran utama lebih mudah dikelola ketika penyimpanan gambar dan pemformatan bingkai gambar diperlakukan terpisah:

- **Embedded images** membuat presentasi mandiri dan paling dapat diandalkan untuk berbagi serta rendering sisi server, tetapi gambar raster besar meningkatkan ukuran PPTX dan penggunaan memori.
- **Linked images** dapat membuat paket lebih kecil, tetapi presentasi bergantung pada file eksternal yang tetap tersedia di jalur atau lokasi yang disimpan.
- **Cropping** pada awalnya tidak merusak. Piksel tersembunyi tetap tersemat hingga area yang dipotong secara eksplisit dihapus atau dihilangkan selama kompresi.
- **Compression** dapat mengurangi ukuran file secara signifikan untuk gambar raster yang terlalu besar, tetapi mengorbankan resolusi sumber. Ini harus diterapkan setelah ukuran pada slide yang diinginkan diketahui.
- **SVG images** sebaiknya tetap sebagai SVG ketika preservasi vektor penting. Ekstrak SVG tersemat secara langsung ketika Anda memerlukan sumber vektor itu sendiri. Ekspor slide raster selalu mengonversi slide yang dirender menjadi piksel.
- **Repeated images** sebaiknya menggunakan kembali sumber daya [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) yang ada bila memungkinkan alih-alih memuat berulang file yang sama ke dalam alur kerja presentasi.

Untuk presentasi besar, optimasi gambar biasanya paling efektif bila dilakukan secara selektif: pertahankan logo dan diagram sebagai konten vektor, kompres foto sesuai ukuran tampilan sebenarnya, hapus piksel yang dipotong hanya ketika penyuntingan nanti tidak diperlukan, dan hindari tautan eksternal kecuali manajemen ketergantungan merupakan bagian dari desain penyebaran.

## **FAQ**

**Apa perbedaan antara bingkai gambar dan sumber daya gambar?**

Sebuah [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) mewakili sumber daya gambar yang terkait dengan presentasi. Sebuah [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) adalah bentuk pada slide yang menampilkan gambar dan menyimpan geometri serta pemformatan tingkat bingkai seperti ukuran, rotasi, nilai crop, efek, dan kunci.

**Haruskah saya menyematkan atau menautkan gambar?**

Sematkan gambar ketika presentasi harus portabel, diarsipkan, atau dirender tanpa mengakses sumber daya eksternal. Tautkan gambar hanya ketika menyimpan file gambar di luar PPTX memang diinginkan dan lokasi eksternal dapat dipelihara secara dapat diandalkan.

**Apakah pemotongan mengurangi ukuran file PPTX?**

Tidak dengan sendirinya. Pengaturan crop normal menyembunyikan bagian gambar sumber tetapi tetap menyimpan piksel di bawahnya. Gunakan [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) atau kompresi gambar dengan penghapusan area yang dipotong ketika piksel tersebut dapat dibuang secara permanen.

**Bisakah saya memulihkan kualitas gambar setelah kompresi?**

Tidak. Kompresi dapat mengurangi resolusi raster yang disimpan, dan menghapus daerah yang dipotong membuang data gambar. Simpan gambar sumber asli di luar presentasi jika penyuntingan beresolusi tinggi di kemudian hari mungkin diperlukan.

**Bagaimana seharusnya gambar SVG ditangani?**

Pertahankan konten SVG sebagai SVG ketika kesetiaan vektor penting. [ISvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/) yang tersemat dapat diekstrak secara langsung. Merender slide ke format raster seperti PNG atau JPEG merasterkan SVG sebagai bagian dari gambar slide.

**Bagaimana saya dapat menghindari cast tidak aman saat membaca slide yang ada?**

Periksa jenis bentuk sebelum menggunakan anggota khusus bingkai gambar. Uji bentuk dengan [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) sebelum menerapkan cast waktu jalan, dan tetapkan hasil cast ke variabel lokal sebelum mengakses anggota khusus bingkai gambar.