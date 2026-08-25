---
title: Kelola Frame Gambar dalam Presentasi Menggunakan C++
linktitle: Frame Gambar
type: docs
weight: 10
url: /id/cpp/picture-frame/
keywords:
- frame gambar
- tambahkan frame gambar
- buat frame gambar
- gambar tertanam
- gambar terhubung
- ekstrak gambar
- gambar raster
- gambar SVG
- potong gambar
- hapus area yang dipotong
- kompres gambar
- StretchOffset
- pemformatan frame gambar
- skala relatif
- efek gambar
- rasio aspek
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Buat, format, tautkan, potong, ekstrak, dan kompres frame gambar dalam presentasi dengan Aspose.Slides untuk C++."
---
## **Gambaran Umum**

Picture frame adalah bentuk slide yang menampilkan gambar. Di Aspose.Slides, sumber daya gambar dan bentuk yang menampilkannya adalah objek terpisah: sebuah [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) memiliki sumber daya gambar tertanam melalui [image collection](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_images/), sementara [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) mengontrol posisi gambar, ukuran, format garis, rotasi, pemotongan, efek gambar, dan pengaturan tingkat frame lainnya.

Pemisaian ini berguna ketika gambar yang sama ditampilkan lebih dari sekali. Tambahkan gambar ke presentasi sekali, simpan [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) yang dikembalikan, dan gunakan sumber daya gambar tersebut saat membuat picture frame.

Picture frame dapat berisi gambar raster seperti PNG atau JPEG dan gambar vektor SVG. Mereka juga dapat merujuk ke gambar terhubung alih‑alih menyimpan byte gambar di dalam presentasi. Pilihan ini memengaruhi portabilitas, ukuran file, ekstraksi, dan perilaku ekspor, sehingga berguna untuk memutuskan bagaimana gambar harus disimpan sebelum menerapkan format atau optimisasi.

## **Menambahkan dan Memformat Gambar Tertanam**

Untuk gambar tertanam, tambahkan data gambar ke presentasi dan buat picture frame dengan [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapecollection/addpictureframe/). Gambar menjadi bagian dari paket presentasi, sehingga presentasi tetap mandiri ketika dipindahkan ke komputer lain.

Contoh berikut menambahkan gambar JPEG, membuat frame dengan dimensi asli gambar, dan menerapkan format garis serta rotasi:

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

Picture frame mengontrol geometri yang ditampilkan; mengubah ukuran frame tidak mengubah dimensi piksel asli yang disimpan dalam sumber daya gambar tertanam. Distingsi ini menjadi penting ketika memotong atau mengompres gambar kemudian.

## **Gunakan Skala Relatif**

[IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) menyediakan skala lebar dan tinggi relatif untuk frame. Nilai `1.0` menyatakan 100 % dari ukuran gambar asli. Skala relatif berguna ketika alur kerja perlu mempertahankan hubungan dengan ukuran gambar sumber alih‑alih menghitung dimensi akhir secara manual.

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

Skala relatif mengubah pengaturan skala frame; ia tidak melakukan resampling atau kompresi pada gambar tertanam.

## **Gambar Tertanam dan Tertaut**

Gambar tertanam menyimpan data gambar di dalam presentasi dan oleh sebab itu merupakan pilihan paling aman untuk portabilitas dan rendering yang dapat diprediksi. Gambar terhubung menyimpan lokasi eksternal melalui jalur tautan [ISlidesPicture](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidespicture/) alih‑alih menanamkan data gambar dengan cara yang sama.

Gambar terhubung dapat mengurangi jumlah data gambar yang disimpan dalam PPTX, tetapi mereka memperkenalkan ketergantungan eksternal. File yang ditautkan harus tetap dapat diakses oleh aplikasi yang membuka atau merender presentasi. Jika jalur berubah, file dipindahkan, atau sumber tidak tersedia, gambar terhubung mungkin tidak ditampilkan sebagaimana mestinya. Untuk presentasi yang harus dikirim melalui email, diarsipkan, atau dirender di lingkungan terisolasi, gambar tertanam biasanya lebih dapat diandalkan.

### **Menambahkan Gambar Tertaut**

Contoh berikut membuat picture frame dan menunjukkannya ke file gambar lokal. Contoh ini hanya menangani penautan gambar; penautan video merupakan alur kerja media terpisah dan sengaja tidak dicampur dalam contoh ini.

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

Gunakan tautan ketika manajemen file eksternal memang diinginkan. Jangan gunakan hanya sebagai pengganti kompresi: PPTX kecil dengan ketergantungan gambar yang rusak biasanya kurang berguna dibandingkan presentasi yang lebih besar dan mandiri.

## **Mengekstrak Gambar dari Picture Frame**

Sebelum mengekstrak gambar dari presentasi yang ada, periksa bahwa sebuah bentuk benar‑benar merupakan [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) dan bahwa ia berisi gambar tertanam. Picture frame terhubung mungkin tidak berisi byte gambar yang dapat diekstrak dengan cara yang sama.

### **Mengekstrak Gambar Raster**

API gambar modern menggunakan [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) secara langsung. Contoh berikut menemukan gambar raster tertanam pertama pada slide dan menyimpannya sebagai PNG:

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

Menyimpan melalui [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) mengonversi gambar yang diekstrak ke format output yang diminta. Jika Anda membutuhkan byte yang dikodekan yang disimpan dalam presentasi alih‑alih file raster yang telah dikonversi, gunakan data biner sumber daya gambar tersebut.

### **Mengekstrak Gambar SVG**

Untuk gambar SVG, [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) menyediakan objek [ISvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/). Ini memungkinkan Anda mengambil data SVG secara langsung alih‑alih merasterkan gambar terlebih dahulu.

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

Mempertahankan konten SVG sebagai SVG menjaga sumber vektor di dalam presentasi. Ekspor raster seperti PNG atau JPEG secara wajar merender konten vektor tersebut menjadi piksel. Ekspor slide ke PDF atau SVG juga merupakan operasi rendering, sehingga grafik yang diekspor tidak boleh diperlakukan sebagai salinan byte‑per‑byte dari SVG tertanam asli; gunakan data [ISvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/) yang tertanam ketika sumber vektor asli diperlukan.

## **Memotong Gambar**

Pemotongan mengubah bagian gambar mana yang terlihat di dalam frame. Nilai pemotongan pada [IPictureFillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/) adalah persentase dari dimensi gambar sumber. Pemotongan tidak langsung menghapus piksel tersembunyi dari gambar tertanam; ia hanya mengubah wilayah yang terlihat.

Contoh berikut menemukan picture frame secara aman dan menerapkan nilai pemotongan:

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

Karena data gambar yang tersembunyi masih ada, pemotongan dapat diubah nanti tanpa kehilangan piksel asli. Jika ukuran file lebih penting daripada kemampuan mengembalikan, wilayah yang dipotong dapat dihapus secara fisik seperti dijelaskan pada bagian berikutnya.

## **Menghapus Data Gambar yang Dipotong**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) menghapus data gambar di luar persegi pemotongan saat ini dan mengembalikan sumber daya gambar hasilnya. Ini dapat mengurangi ukuran file, tetapi merupakan optimisasi destruktif: setelah presentasi disimpan, piksel yang dihapus tidak lagi tersedia untuk operasi un‑crop di kemudian hari.

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

Metode ini mungkin menambahkan sumber daya gambar baru ke presentasi. Jika gambar asli juga digunakan oleh picture frame lain, frame‑frame tersebut tetap memerlukan sumber daya yang ada, sehingga penghapusan area yang dipotong tidak selalu mengurangi total jumlah gambar. Memotong konten WMF atau EMF dengan metode ini merasterkan hasil yang dipotong menjadi PNG.

## **Mengompres Gambar Raster**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/compressimage/) mengurangi resolusi gambar raster relatif terhadap ukuran saat gambar ditampilkan. Ia juga dapat menghapus wilayah yang dipotong dalam satu operasi. Metode mengembalikan `true` ketika gambar diubah ukurannya atau dipotong dan `false` ketika tidak ada perubahan yang diperlukan.

Gunakan nilai [PicturesCompression](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/picturescompression/) yang telah ditentukan sebelumnya ketika resolusi target standar sudah cukup:

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

Nilai DPI positif khusus dapat diberikan alih‑alih nilai enum ketika target spesifik dibutuhkan.

Kompresi dimaksudkan untuk gambar raster. Konten SVG dan metafile tidak berkurang oleh alur kerja kompresi raster ini. Juga ingat bahwa resolusi lebih rendah dan wilayah yang dipotong yang dihapus tidak dapat dipulihkan dari presentasi yang telah dioptimalkan. Pilih resolusi target berdasarkan ukuran terbesar di mana gambar akan benar‑benar dilihat atau diekspor, bukan menerapkan DPI terendah secara menyeluruh.

## **Mengelola Efek Transformasi Gambar**

Untuk alur kerja lengkap yang mencakup kecerahan, kontras, transformasi warna, blur, efek alfa, rantai terurut, inspeksi, penghapusan, dan verifikasi putar‑balik, lihat [Image Transform Effects](/slides/id/cpp/image-transform-effects/).

## **Kunci Geometri Picture Frame**

Pengaturan [IPictureFrameLock](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframelock/) mengontrol operasi penyuntingan mana yang dinonaktifkan untuk picture frame. Misalnya, [aspect‑ratio lock](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) mempertahankan proporsi bentuk saat diubah ukuran.

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

Kunci berlaku pada bentuk picture frame. Ia tidak memaksa gambar sumber untuk di‑resample atau diubah secara permanen menjadi rasio aspek yang sama.

## **Sesuaikan Nilai StretchOffset**

Ketika mode isi gambar adalah stretch, nilai stretch‑offset pada [IPictureFillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/) mendefinisikan persegi isi relatif terhadap bounding box picture frame. Persentase positif membuat inset dari tepi, sementara persentase negatif membuat outset.

Ini berbeda dari pemotongan. Nilai pemotongan memilih bagian gambar sumber yang terlihat; stretch offset mengubah persegi tempat isi gambar yang terlihat diregangkan.

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

Gunakan stretch offset untuk penempatan isi. Gunakan properti pemotongan ketika tujuan Anda adalah menyembunyikan tepi gambar sumber.

## **Pertimbangan Penyimpanan, Ukuran File, dan Ekspor**

Trade‑off utama lebih mudah dikelola ketika penyimpanan gambar dan format picture‑frame diperlakukan secara terpisah:

- **Gambar tertanam** membuat presentasi mandiri dan paling dapat diandalkan untuk berbagi serta rendering sisi server, tetapi gambar raster besar meningkatkan ukuran PPTX dan penggunaan memori.
- **Gambar terhubung** dapat menjaga paket tetap lebih kecil, tetapi presentasi bergantung pada file eksternal yang tetap tersedia pada jalur atau lokasi yang disimpan.
- **Pemotongan** pada awalnya tidak destruktif. Piksel tersembunyi tetap tertanam sampai area yang dipotong dihapus secara eksplisit atau dihapus selama kompresi.
- **Kompresi** dapat secara signifikan mengurangi ukuran file untuk gambar raster yang terlalu besar, tetapi mengorbankan resolusi sumber. Sebaiknya diterapkan setelah ukuran pada slide yang dimaksud diketahui.
- **Gambar SVG** sebaiknya tetap sebagai SVG bila preservasi vektor penting. Ekstrak SVG tertanam secara langsung ketika Anda membutuhkan sumber vektor itu sendiri. Ekspor slide raster selalu mengonversi slide yang dirender menjadi piksel.
- **Gambar berulang** sebaiknya menggunakan kembali sumber daya [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) yang ada bila memungkinkan alih‑alih memuat berulang‑ulang berkas yang sama ke alur kerja presentasi.

Untuk presentasi besar, optimisasi gambar biasanya paling efektif bila dilakukan secara selektif: pertahankan logo dan diagram sebagai konten vektor, kompres foto sesuai ukuran tampilan sebenarnya, hapus piksel yang dipotong hanya ketika penyuntingan di kemudian hari tidak diperlukan, dan hindari tautan eksternal kecuali manajemen ketergantungan menjadi bagian dari desain penyebaran.

## **FAQ**

**Apa perbedaan antara picture frame dan sumber daya gambar?**

[IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) mewakili sumber daya gambar yang terkait dengan presentasi. [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) adalah bentuk pada slide yang menampilkan gambar dan menyimpan geometri serta format tingkat frame seperti ukuran, rotasi, nilai pemotongan, efek, dan kunci.

**Haruskah saya menanamkan atau menautkan gambar?**

Tanamkan gambar ketika presentasi harus portabel, diarsipkan, atau dirender tanpa akses ke sumber daya eksternal. Tautkan gambar hanya ketika menyimpan file gambar di luar PPTX memang diinginkan dan lokasi eksternal dapat dipertahankan secara andal.

**Apakah pemotongan mengurangi ukuran file PPTX?**

Tidak secara langsung. Pengaturan pemotongan normal menyembunyikan bagian gambar sumber tetapi tetap menyimpan piksel di bawahnya. Gunakan [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) atau kompresi gambar dengan penghapusan area yang dipotong ketika piksel tersebut dapat dibuang secara permanen.

**Bisakah saya mengembalikan kualitas gambar setelah kompresi?**

Tidak. Kompresi dapat mengurangi resolusi raster yang disimpan, dan menghapus wilayah yang dipotong membuang data gambar. Simpan gambar sumber asli di luar presentasi jika penyuntingan resolusi tinggi di kemudian hari mungkin diperlukan.

**Bagaimana sebaiknya menangani gambar SVG?**

Pertahankan konten SVG sebagai SVG ketika fidelitas vektor penting. [ISvgImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/isvgimage/) yang tertanam dapat diekstrak secara langsung. Merender slide ke format raster seperti PNG atau JPEG merasterkan SVG sebagai bagian dari gambar slide.

**Bagaimana cara menghindari cast tidak aman saat membaca slide yang ada?**

Periksa tipe bentuk sebelum menggunakan anggota khusus picture‑frame. Uji bentuk dengan [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) sebelum melakukan cast pada waktu‑runtime, dan tetapkan hasil cast ke variabel lokal sebelum mengakses anggota khusus picture‑frame.