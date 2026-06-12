---
title: Optimalkan Manajemen Gambar dalam Presentasi Menggunakan C++
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/cpp/image/
keywords:
- menambahkan gambar
- menambahkan foto
- menambahkan bitmap
- mengganti gambar
- mengganti foto
- dari web
- latar belakang
- menambahkan PNG
- menambahkan JPG
- menambahkan SVG
- menambahkan EMF
- menambahkan WMF
- menambahkan TIFF
- PowerPoint
- OpenDocument
- presentasi
- EMF
- SVG
- C++
- Aspose.Slides
description: "Menyederhanakan manajemen gambar dalam PowerPoint dan OpenDocument dengan Aspose.Slides untuk C++, mengoptimalkan kinerja dan mengotomatiskan alur kerja Anda."
---
## **Pendahuluan**

Gambar membuat presentasi menjadi lebih menarik dan menarik. Di Microsoft PowerPoint, Anda dapat menyisipkan gambar dari file, internet, atau lokasi lain ke slide. Demikian pula, Aspose.Slides memungkinkan Anda menambahkan gambar ke slide dalam presentasi Anda melalui berbagai prosedur. 

{{% alert title="Tip" color="primary" %}} 

Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan orang membuat presentasi dengan cepat dari gambar. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Jika Anda ingin menambahkan gambar sebagai objek bingkai—terutama jika Anda berencana menggunakan opsi pemformatan standar pada gambar tersebut untuk mengubah ukurannya, menambahkan efek, dan sebagainya—lihat [Bingkai Gambar](/slides/id/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Anda dapat memanipulasi operasi input/output yang melibatkan gambar dan presentasi PowerPoint untuk mengonversi gambar dari satu format ke format lain. Lihat halaman-halaman ini: konversi [gambar ke JPG](https://products.aspose.com/slides/id/cpp/conversion/image-to-jpg/); konversi [JPG ke gambar](https://products.aspose.com/slides/id/cpp/conversion/jpg-to-image/); konversi [JPG ke PNG](https://products.aspose.com/slides/id/cpp/conversion/jpg-to-png/), konversi [PNG ke JPG](https://products.aspose.com/slides/id/cpp/conversion/png-to-jpg/); konversi [PNG ke SVG](https://products.aspose.com/slides/id/cpp/conversion/png-to-svg/), konversi [SVG ke PNG](https://products.aspose.com/slides/id/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides mendukung operasi dengan gambar dalam format populer berikut: JPEG, PNG, GIF, dan lainnya. 

## **Menambahkan Gambar yang Disimpan Secara Lokal ke Slide**

Anda dapat menambahkan satu atau beberapa gambar di komputer Anda ke slide dalam presentasi. Kode contoh berikut dalam C++ menunjukkan cara menambahkan gambar ke slide:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Menambahkan Gambar dari Web ke Slide**

Jika gambar yang ingin Anda tambahkan ke slide tidak tersedia di komputer Anda, Anda dapat menambahkan gambar tersebut langsung dari web. 

Kode contoh berikut menunjukkan cara menambahkan gambar dari web ke slide dalam C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Menambahkan Gambar ke Slide Master**

Slide master adalah slide utama yang menyimpan dan mengontrol informasi (tema, tata letak, dll.) tentang semua slide di bawahnya. Jadi, ketika Anda menambahkan gambar ke slide master, gambar tersebut muncul pada setiap slide di bawah slide master tersebut. 

Kode contoh C++ berikut menunjukkan cara menambahkan gambar ke slide master:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Menambahkan Gambar sebagai Latar Belakang Slide**

Anda mungkin memutuskan untuk menggunakan gambar sebagai latar belakang untuk slide tertentu atau beberapa slide. Dalam hal ini, Anda harus melihat *[Mengatur Gambar sebagai Latar Belakang untuk Slide](https://docs.aspose.com/slides/id/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Menambahkan SVG ke Presentasi**
Anda dapat menambahkan atau menyisipkan gambar apa pun ke dalam presentasi dengan menggunakan metode [AddPictureFrame](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) yang merupakan bagian dari antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_shape_collection).

Untuk membuat objek gambar berdasarkan gambar SVG, Anda dapat melakukannya dengan cara berikut:

1. Buat objek SvgImage untuk menyisipkannya ke ImageShapeCollection
2. Buat objek PPImage dari ISvgImage
3. Buat objek PictureFrame menggunakan antarmuka IPPImage

Kode contoh berikut menunjukkan cara menerapkan langkah-langkah di atas untuk menambahkan gambar SVG ke dalam presentasi:
``` cpp 
// Jalur ke direktori dokumen
System::String dataDir = u"D:\\Documents\\";

// Nama file SVG sumber
System::String svgFileName = dataDir + u"sample.svg";

// Nama file presentasi output
System::String outPptxPath = dataDir + u"presentation.pptx";

// Membuat presentasi baru
auto p = System::MakeObject<Presentation>();

// Membaca konten file SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Membuat objek SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Membuat objek PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Membuat PictureFrame baru
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Simpan presentasi dalam format PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Mengonversi SVG menjadi Sekelompok Bentuk**
Konversi SVG menjadi sekumpulan bentuk oleh Aspose.Slides mirip dengan fungsi PowerPoint yang digunakan untuk bekerja dengan gambar SVG:

![PowerPoint Popup Menu](img_01_01.png)

Fungsionalitas ini disediakan oleh salah satu overload dari metode [AddGroupShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) pada antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_shape_collection) yang menerima objek [ISvgImage](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_svg_image) sebagai argumen pertama.

Kode contoh berikut menunjukkan cara menggunakan metode yang dijelaskan untuk mengonversi file SVG menjadi sekumpulan bentuk:

``` cpp 
// Jalur ke direktori dokumen
System::String dataDir = u"D:\\Documents\\";

// Nama file SVG sumber
System::String svgFileName = dataDir + u"sample.svg";

// Nama file presentasi output
System::String outPptxPath = dataDir + u"presentation.pptx";

// Membuat presentasi baru
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Membaca konten file SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Membuat objek SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Dapatkan ukuran slide
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Mengonversi gambar SVG menjadi grup bentuk dengan menskalakan ke ukuran slide
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Simpan presentasi dalam format PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Menambahkan Gambar sebagai EMF ke Slide**
Aspose.Slides untuk C++ memungkinkan Anda menghasilkan gambar EMF dari lembar Excel dan menambahkan gambar tersebut sebagai EMF di slide dengan Aspose.Cells. 

Kode contoh berikut menunjukkan cara melakukan tugas yang dijelaskan:

``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Save the workbook to stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

## **Mengganti Gambar dalam Koleksi Gambar**

Aspose.Slides memungkinkan Anda mengganti gambar yang disimpan dalam koleksi gambar presentasi (termasuk yang digunakan oleh bentuk slide). Bagian ini menunjukkan beberapa pendekatan untuk memperbarui gambar dalam koleksi. API menyediakan metode sederhana untuk mengganti gambar menggunakan data byte mentah, instance [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) , atau gambar lain yang sudah ada dalam koleksi.

Ikuti langkah-langkah berikut:

1. Muat file presentasi yang berisi gambar menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Muat gambar baru dari file ke dalam array byte.
3. Ganti gambar target dengan gambar baru menggunakan array byte.
4. Pada pendekatan kedua, muat gambar ke dalam objek [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) dan ganti gambar target dengan objek tersebut.
5. Pada pendekatan ketiga, ganti gambar target dengan gambar yang sudah ada dalam koleksi gambar presentasi.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```cpp
// Membuat instance kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Cara pertama.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Cara kedua.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Cara ketiga.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Simpan presentasi ke file.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Dengan konverter Aspose GRATIS [Text to GIF](https://products.aspose.app/slides/id/text-to-gif) , Anda dapat dengan mudah menggerakkan teks, membuat GIF dari teks, dll. 

{{% /alert %}}

## **FAQ**

**Apakah resolusi asli gambar tetap utuh setelah disisipkan?**

Ya. Piksel sumber dipertahankan, tetapi tampilan akhir tergantung pada bagaimana [picture](/slides/id/cpp/picture-frame/) diskalakan pada slide dan kompresi apa pun yang diterapkan saat menyimpan.

**Apa cara terbaik untuk mengganti logo yang sama di puluhan slide sekaligus?**

Tempatkan logo pada slide master atau layout dan ganti di koleksi gambar presentasi—perubahan akan diterapkan ke semua elemen yang menggunakan sumber daya tersebut.

**Apakah SVG yang disisipkan dapat dikonversi menjadi bentuk yang dapat diedit?**

Ya. Anda dapat mengonversi SVG menjadi grup bentuk, setelah itu bagian individual menjadi dapat diedit dengan properti bentuk standar.

**Bagaimana saya dapat mengatur gambar sebagai latar belakang untuk beberapa slide sekaligus?**

[Tetapkan gambar sebagai latar belakang](/slides/id/cpp/presentation-background/) pada slide master atau layout yang relevan—semua slide yang menggunakan master/layout tersebut akan mewarisi latar belakang.

**Bagaimana cara mencegah presentasi menjadi sangat besar karena banyak gambar?**

Gunakan kembali satu sumber gambar alih-alih duplikat, pilih resolusi yang wajar, terapkan kompresi saat menyimpan, dan letakkan grafik berulang pada master bila perlu.