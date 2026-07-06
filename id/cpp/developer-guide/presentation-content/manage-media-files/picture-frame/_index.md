---
title: Kelola Bingkai Gambar dalam Presentasi Menggunakan C++
linktitle: Bingkai Gambar
type: docs
weight: 10
url: /id/cpp/picture-frame/
keywords:
- bingkai gambar
- menambahkan bingkai gambar
- buat bingkai gambar
- menambahkan gambar
- buat gambar
- ekstrak gambar
- gambar raster
- gambar vektor
- potong gambar
- area terpotong
- properti StretchOff
- pemformatan bingkai gambar
- properti bingkai gambar
- skala relatif
- efek gambar
- rasio aspek
- transparansi gambar
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Tambahkan bingkai gambar ke presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk C++. Permudah alur kerja Anda dan tingkatkan desain slide."
---
## **Pendahuluan**

Bingkai gambar adalah bentuk yang berisi sebuah gambar—itu seperti gambar dalam sebuah bingkai.  

Anda dapat menambahkan gambar ke slide melalui bingkai gambar. Dengan cara ini, Anda dapat memformat gambar dengan memformat bingkai gambar.

{{% alert  title="Tip" color="primary" %}} 
Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan orang membuat presentasi dengan cepat dari gambar. 
{{% /alert %}} 

## **Buat Bingkai Gambar**

1. Buat instance dari [Presentation class](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [IPPImage](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_p_p_image) dengan menambahkan gambar ke [IImagescollection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_image_collection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.
4. Tentukan lebar dan tinggi gambar.
5. Buat [PictureFrame](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.picture_frame) berdasarkan lebar dan tinggi gambar melalui metode `AddPictureFrame` yang disediakan oleh objek shape yang terkait dengan slide yang direferensikan.
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide.
7. Tulis presentasi yang dimodifikasi sebagai file PPTX.

Kode C++ berikut menunjukkan cara membuat bingkai gambar:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Muat presentasi yang diinginkan
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Mengakses slide pertama
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Muat gambar yang akan ditambahkan ke koleksi gambar presentasi
// Mendapatkan gambar
auto image = Images::FromFile(filePath);

// Menambahkan gambar ke koleksi gambar presentasi
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Menambahkan bingkai gambar ke slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Mengatur skala relatif lebar dan tinggi
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Menerapkan beberapa pemformatan ke Bingkai Gambar
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Menulis file PPTX ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Bingkai gambar memungkinkan Anda dengan cepat membuat slide presentasi berdasarkan gambar. Saat Anda menggabungkan bingkai gambar dengan opsi penyimpanan Aspose.Slides, Anda dapat memanipulasi operasi input/output untuk mengonversi gambar dari satu format ke format lain. Anda mungkin ingin melihat halaman berikut: konversi [gambar ke JPG](https://products.aspose.com/slides/id/cpp/conversion/image-to-jpg/); konversi [JPG ke gambar](https://products.aspose.com/slides/id/cpp/conversion/jpg-to-image/); konversi [JPG ke PNG](https://products.aspose.com/slides/id/cpp/conversion/jpg-to-png/), konversi [PNG ke JPG](https://products.aspose.com/slides/id/cpp/conversion/png-to-jpg/); konversi [PNG ke SVG](https://products.aspose.com/slides/id/cpp/conversion/png-to-svg/), konversi [SVG ke PNG](https://products.aspose.com/slides/id/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **Buat Bingkai Gambar dengan Skala Relatif**

Dengan mengubah skala relatif gambar, Anda dapat membuat bingkai gambar yang lebih rumit. 

1. Buat instance dari [Presentation class](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan gambar ke koleksi gambar presentasi.
4. Buat objek [IPPImage](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_p_p_image) dengan menambahkan gambar ke [IImagescollection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_image_collection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.
5. Tentukan lebar dan tinggi relatif gambar dalam bingkai gambar.
6. Tulis presentasi yang dimodifikasi sebagai file PPTX.

Kode C++ berikut menunjukkan cara membuat bingkai gambar dengan skala relatif:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Memuat presentasi yang diinginkan
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Mengakses slide pertama
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Memuat gambar yang akan ditambahkan ke koleksi gambar presentasi
// Mendapatkan gambar
auto image = Images::FromFile(filePath);

// Menambahkan gambar ke koleksi gambar presentasi
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Menambahkan bingkai gambar ke slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Mengatur skala relatif lebar dan tinggi
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Menulis file PPTX ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ekstrak Gambar Raster dari Bingkai Gambar**

Anda dapat mengekstrak gambar raster dari objek [PictureFrame](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.picture_frame) dan menyimpannya dalam format PNG, JPG, dan format lainnya. Contoh kode di bawah ini menunjukkan cara mengekstrak gambar dari dokumen "sample.pptx" dan menyimpannya dalam format PNG.

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **Ekstrak Gambar SVG dari Bingkai Gambar**

Ketika sebuah presentasi berisi grafik SVG yang ditempatkan di dalam bentuk [PictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/pictureframe/), Aspose.Slides untuk C++ memungkinkan Anda mengambil gambar vektor asli dengan fidelitas penuh. Dengan menelusuri koleksi bentuk slide, Anda dapat mengidentifikasi setiap [PictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/pictureframe/), memeriksa apakah [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) yang mendasarinya berisi konten SVG, dan kemudian menyimpan gambar tersebut ke disk atau aliran dalam format SVG aslinya.

Contoh kode berikut menunjukkan cara mengekstrak gambar SVG dari bingkai gambar:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **Dapatkan Transparansi Gambar**

Aspose.Slides memungkinkan Anda mendapatkan efek transparansi yang diterapkan pada gambar. Kode C++ berikut mendemonstrasikan operasi tersebut:

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="primary" %}} 
Semua efek yang diterapkan pada gambar dapat ditemukan di [Aspose::Slides::Effects](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/).
{{% /alert %}}

## **Dapatkan Kecerahan dan Kontras Gambar**

Aspose.Slides memungkinkan Anda mendapatkan efek kecerahan dan kontras yang diterapkan pada gambar. Antarmuka [ILuminance](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iluminance/) mewakili efek transformasi gambar ini.

Kode C++ berikut menunjukkan cara mendapatkan pengaturan kecerahan dan kontras dari sebuah bingkai gambar:

```c++
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **Pemformatan Bingkai Gambar**

Aspose.Slides menyediakan banyak opsi pemformatan yang dapat diterapkan pada bingkai gambar. Dengan menggunakan opsi tersebut, Anda dapat mengubah bingkai gambar agar sesuai dengan kebutuhan spesifik.

1. Buat instance dari [Presentation class](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [IPPImage](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_p_p_image) dengan menambahkan gambar ke [IImagescollection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_image_collection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.
4. Tentukan lebar dan tinggi gambar.
5. Buat `PictureFrame` berdasarkan lebar dan tinggi gambar melalui metode [AddPictureFrame](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) yang disediakan oleh objek [IShapes](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_shape_collection) yang terkait dengan slide yang direferensikan.
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide.
7. Atur warna garis bingkai gambar.
8. Atur lebar garis bingkai gambar.
9. Putar bingkai gambar dengan memberikannya nilai positif atau negatif.
   * Nilai positif memutar gambar searah jarum jam. 
   * Nilai negatif memutar gambar berlawanan arah jarum jam.
10. Tambahkan bingkai gambar (yang berisi gambar) ke slide.
11. Tulis presentasi yang dimodifikasi sebagai file PPTX.

Kode C++ berikut mendemonstrasikan proses pemformatan bingkai gambar:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Memuat presentasi yang diinginkan
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Mengakses slide pertama
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Memuat gambar yang akan ditambahkan ke koleksi gambar presentasi
// Mendapatkan gambar
auto image = Images::FromFile(filePath);

// Menambahkan gambar ke koleksi gambar presentasi
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Menambahkan bingkai gambar ke slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Mengatur skala relatif lebar dan tinggi
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Menulis file PPTX ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}
Aspose baru-baru ini mengembangkan [Collage Maker gratis](https://products.aspose.app/slides/id/collage). Jika Anda pernah perlu [menggabungkan JPG/JPEG] atau gambar PNG, [membuat grid dari foto], Anda dapat menggunakan layanan ini. 
{{% /alert %}}

## **Tambahkan Gambar sebagai Tautan**

Untuk menghindari ukuran presentasi yang besar, Anda dapat menambahkan gambar (atau video) melalui tautan alih-alih menyematkan file secara langsung ke dalam presentasi. Kode C++ berikut menunjukkan cara menambahkan gambar dan video ke placeholder:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Potong Gambar**

Kode C++ berikut menunjukkan cara memotong gambar yang ada pada slide: 

```CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Membuat objek gambar baru
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Menambahkan PictureFrame ke Slide
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Memotong gambar (nilai persentase)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Menyimpan hasil
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Hapus Area yang Dipotong dari Gambar**

Jika Anda ingin menghapus area yang dipotong dari gambar yang terdapat dalam sebuah bingkai, Anda dapat menggunakan metode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Metode ini mengembalikan gambar yang dipotong atau gambar asli jika pemotongan tidak diperlukan.

Kode C++ berikut mendemonstrasikan operasi tersebut: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Mendapatkan PictureFrame dari slide pertama
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Menghapus area yang dipotong dari gambar PictureFrame dan mengembalikan gambar yang dipotong
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Menyimpan hasil
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 
Metode [IPictureFillFormat::DeletePictureCroppedAreas()] menambahkan gambar yang dipotong ke koleksi gambar presentasi. Jika gambar hanya digunakan dalam [PictureFrame] yang diproses, pengaturan ini dapat mengurangi ukuran presentasi. Jika tidak, jumlah gambar dalam presentasi yang dihasilkan akan meningkat.

Metode ini mengonversi file metafile WMF/EMF menjadi gambar PNG raster dalam operasi pemotongan. 
{{% /alert %}}

## **Kompres Gambar**

Anda dapat mengompres gambar dalam presentasi menggunakan metode [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/compressimage/).
Metode ini mengompres gambar dengan mengurangi ukurannya berdasarkan ukuran bentuk dan resolusi yang ditentukan, dengan opsi untuk menghapus area yang dipotong.

Ini menyesuaikan ukuran dan resolusi gambar serupa dengan fitur PowerPoint **Picture Format -> Compress Pictures -> Resolution**.

Contoh C++ berikut menunjukkan cara mengompres gambar dalam presentasi dengan menentukan resolusi target dan secara opsional menghapus area yang dipotong:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Kompres gambar dengan resolusi target 150 DPI (resolusi Web) dan hapus area yang dipotong.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Periksa hasil kompresi.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Atau menggunakan nilai DPI khusus secara langsung:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Kompres gambar ke 150 DPI (resolusi web), menghapus area yang dipotong.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Metode ini mengonversi gambar ke resolusi lebih rendah berdasarkan ukuran bentuk dan DPI yang diberikan. Region yang dipotong juga dapat dihapus untuk mengoptimalkan ukuran file.
Jika gambar merupakan metafile (WMF/EMF) atau SVG, kompresi tidak akan diterapkan. Selain itu, kualitas JPEG dipertahankan atau sedikit berkurang berdasarkan resolusi, serupa dengan cara PowerPoint menangani JPEG beresolusi tinggi.
{{% /alert %}}

## **Kunci Rasio Aspek**

Jika Anda ingin bentuk yang berisi gambar mempertahankan rasio aspeknya bahkan setelah Anda mengubah dimensi gambar, Anda dapat menggunakan metode [set_AspectRatioLocked()](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) untuk mengatur pengaturan *Lock Aspect Ratio*. 

Kode C++ berikut menunjukkan cara mengunci rasio aspek sebuah bentuk:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// atur bentuk agar mempertahankan rasio aspek saat diubah ukuran
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 
Pengaturan *Lock Aspect Ratio* ini hanya mempertahankan rasio aspek bentuk dan bukan gambar yang dikandungnya.
{{% /alert %}}

## **Gunakan Properti StretchOff**

Dengan menggunakan properti [StretchOffsetLeft](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) dan [StretchOffsetBottom](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_picture_fill_format) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.picture_fill_format), Anda dapat menentukan segi empat pengisian. 

Ketika peregangan gambar ditentukan, segi empat sumber diskalakan untuk mengisi segi empat pengisian yang ditentukan. Setiap sisi segi empat pengisian didefinisikan oleh offset persentase dari sisi yang bersesuaian pada kotak pembatas bentuk. Persentase positif menunjukkan inset. Persentase negatif menunjukkan outset.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan sebuah segi empat `AutoShape`. 
4. Buat gambar. 
5. Atur jenis isi bentuk. 
6. Atur mode isi gambar bentuk. 
7. Tambahkan gambar yang diatur untuk mengisi bentuk. 
8. Tentukan offset gambar dari sisi yang bersesuaian pada kotak pembatas bentuk
9. Tulis presentasi yang dimodifikasi sebagai file PPTX.

Kode C++ berikut mendemonstrasikan proses penggunaan properti StretchOff:

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Mengatur gambar agar meregang dari setiap sisi dalam badan bentuk
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Bagaimana saya dapat mengetahui format gambar apa yang didukung untuk PictureFrame?**

Aspose.Slides mendukung baik gambar raster (PNG, JPEG, BMP, GIF, dll.) maupun gambar vektor (misalnya, SVG) melalui objek gambar yang ditetapkan ke [PictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/pictureframe/). Daftar format yang didukung umumnya tumpang tindih dengan kemampuan mesin konversi slide dan gambar.

**Bagaimana penambahan puluhan gambar besar memengaruhi ukuran dan kinerja PPTX?**

Menyematkan gambar besar meningkatkan ukuran file dan penggunaan memori; menautkan gambar membantu menjaga ukuran presentasi tetap kecil namun memerlukan file eksternal tetap dapat diakses. Aspose.Slides menyediakan kemampuan menambahkan gambar melalui tautan untuk mengurangi ukuran file.

**Bagaimana saya dapat mengunci objek gambar agar tidak secara tidak sengaja dipindahkan/diperbesar?**

Gunakan [shape locks] untuk sebuah [PictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/pictureframe/) (misalnya, menonaktifkan pemindahan atau perubahan ukuran). Mekanisme penguncian dijelaskan untuk bentuk pada artikel [protection](/slides/id/cpp/applying-protection-to-presentation/) terpisah dan didukung untuk berbagai tipe bentuk, termasuk [PictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/pictureframe/).

**Apakah fidelitas vektor SVG terjaga saat mengekspor presentasi ke PDF/gambar?**

Aspose.Slides memungkinkan mengekstrak SVG dari sebuah [PictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/pictureframe/) sebagai vektor asli. Saat [mengekspor ke PDF](/slides/id/cpp/convert-powerpoint-to-pdf/) atau [format raster](/slides/id/cpp/convert-powerpoint-to-png/), hasilnya dapat menjadi raster tergantung pada pengaturan ekspor; fakta bahwa SVG asli disimpan sebagai vektor dikonfirmasi oleh perilaku ekstraksi.