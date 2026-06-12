---
title: Buat Penampil Presentasi dalam C++
linktitle: Penampil Presentasi
type: docs
weight: 50
url: /id/cpp/presentation-viewer/
keywords: 
- lihat presentasi
- penampil presentasi
- buat penampil presentasi
- lihat PPT
- lihat PPTX
- lihat ODP
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Buat penampil presentasi khusus dalam C++ menggunakan Aspose.Slides. Tampilkan file PowerPoint dan OpenDocument dengan mudah tanpa Microsoft PowerPoint."
---
## **Pendahuluan**

Aspose.Slides untuk C++ digunakan untuk membuat file presentasi dengan slide. Slide ini dapat dilihat dengan membuka presentasi di Microsoft PowerPoint, misalnya. Namun, terkadang pengembang mungkin perlu melihat slide sebagai gambar dalam penampil gambar pilihan mereka atau membuat penampil presentasi mereka sendiri. Dalam kasus seperti itu, Aspose.Slides memungkinkan Anda mengekspor slide individu sebagai gambar. Artikel ini menjelaskan cara melakukannya.

## **Hasilkan Gambar SVG dari Slide**

Untuk menghasilkan gambar SVG dari slide presentasi dengan Aspose.Slides, ikuti langkah-langkah di bawah ini:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Buka aliran file.
1. Simpan slide sebagai gambar SVG ke aliran file.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **Hasilkan SVG dengan ID Bentuk Kustom**

Aspose.Slides dapat digunakan untuk menghasilkan [SVG](https://docs.fileformat.com/page-description-language/svg/) dari slide dengan ID bentuk kustom. Untuk melakukan ini, gunakan metode `set_Id` dari [ISvgShape](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/isvgshape/). `CustomSvgShapeFormattingController` dapat digunakan untuk mengatur ID bentuk.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **Buat Gambar Miniatur Slide**

Aspose.Slides membantu Anda menghasilkan gambar miniatur slide. Untuk menghasilkan miniatur slide menggunakan Aspose.Slides, ikuti langkah-langkah di bawah ini:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar miniatur dari slide yang direferensikan dengan skala yang ditentukan.
1. Simpan gambar miniatur dalam format gambar apa pun yang diinginkan.

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Buat Miniatur Slide dengan Dimensi yang Ditentukan Pengguna**

Untuk membuat gambar miniatur slide dengan dimensi yang ditentukan oleh pengguna, ikuti langkah-langkah di bawah ini:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar miniatur dari slide yang direferensikan dengan dimensi yang ditentukan.
1. Simpan gambar miniatur dalam format gambar apa pun yang diinginkan.

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Buat Miniatur Slide dengan Catatan Pembicara**

Untuk menghasilkan miniatur slide dengan catatan pembicara menggunakan Aspose.Slides, ikuti langkah-langkah di bawah ini:

1. Buat instance dari kelas [RenderingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/renderingoptions/).
1. Gunakan metode `RenderingOptions.set_SlidesLayoutOptions` untuk mengatur posisi catatan pembicara.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar miniatur dari slide yang direferensikan dengan opsi rendering.
1. Simpan gambar miniatur dalam format gambar apa pun yang diinginkan.

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Contoh Langsung**

Anda dapat mencoba aplikasi gratis [**Aspose.Slides Viewer**](https://products.aspose.app/slides/id/viewer/) untuk melihat apa yang dapat Anda implementasikan dengan API Aspose.Slides:

![Penampil PowerPoint Online](online-PowerPoint-viewer.png)

## **FAQ**

**Apakah saya dapat menyematkan penampil presentasi dalam aplikasi web?**

Ya. Anda dapat menggunakan Aspose.Slides di sisi server untuk merender slide sebagai gambar atau HTML dan menampilkannya di peramban. Fitur navigasi dan zoom dapat diimplementasikan dengan JavaScript untuk pengalaman interaktif.

**Apa cara terbaik menampilkan slide di dalam penampil khusus?**

Pendekatan yang disarankan adalah merender setiap slide sebagai gambar (mis., PNG atau SVG) atau mengonversinya menjadi HTML menggunakan Aspose.Slides, kemudian menampilkan output di dalam kotak gambar (untuk desktop) atau kontainer HTML (untuk web).

**Bagaimana cara menangani presentasi besar dengan banyak slide?**

Untuk dek besar, pertimbangkan lazy-loading atau rendering on-demand slide. Ini berarti menghasilkan konten slide hanya saat pengguna menavigasinya, mengurangi penggunaan memori dan waktu pemuatan.