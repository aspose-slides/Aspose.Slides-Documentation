---
title: Buat Penampil Presentasi di Android
linktitle: Penampil Presentasi
type: docs
weight: 50
url: /id/androidjava/presentation-viewer/
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
- Android
- Java
- Aspose.Slides
description: "Buat penampil presentasi khusus dalam Java menggunakan Aspose.Slides untuk Android. Tampilkan file PowerPoint dan OpenDocument dengan mudah tanpa Microsoft PowerPoint."
---
## **Pendahuluan**

Aspose.Slides for Android via Java digunakan untuk membuat file presentasi dengan slide. Slide tersebut dapat dilihat dengan membuka presentasi di Microsoft PowerPoint, misalnya. Namun, kadang pengembang perlu melihat slide sebagai gambar di penampil gambar pilihan mereka atau membuat penampil presentasi sendiri. Dalam kasus seperti itu, Aspose.Slides memungkinkan Anda mengekspor slide individual sebagai gambar. Artikel ini menjelaskan cara melakukannya.

## **Hasilkan Gambar SVG dari Slide**

Untuk menghasilkan gambar SVG dari slide presentasi dengan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Buka aliran file.
1. Simpan slide sebagai gambar SVG ke aliran file.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Hasilkan SVG dengan ID Bentuk Kustom**

Aspose.Slides dapat digunakan untuk menghasilkan [SVG](https://docs.fileformat.com/page-description-language/svg/) dari slide dengan ID bentuk kustom. Untuk melakukan ini, gunakan metode `setId` dari [ISvgShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` dapat digunakan untuk menetapkan ID bentuk.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Buat Gambar Miniatur Slide**

Aspose.Slides membantu Anda menghasilkan gambar miniatur slide. Untuk menghasilkan miniatur slide menggunakan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar miniatur slide yang direferensikan dengan skala yang ditentukan.
1. Simpan gambar miniatur dalam format gambar apa pun yang diinginkan.

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Buat Miniatur Slide dengan Dimensi yang Ditentukan Pengguna**

Untuk membuat gambar miniatur slide dengan dimensi yang ditentukan pengguna, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar miniatur slide yang direferensikan dengan dimensi yang ditentukan.
1. Simpan gambar miniatur dalam format gambar apa pun yang diinginkan.

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Buat Miniatur Slide dengan Catatan Pembicara**

Untuk menghasilkan miniatur slide dengan catatan pembicara menggunakan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [RenderingOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/renderingoptions/).
1. Gunakan metode `RenderingOptions.setSlidesLayoutOptions` untuk mengatur posisi catatan pembicara.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar miniatur slide yang direferensikan dengan opsi rendering.
1. Simpan gambar miniatur dalam format gambar apa pun yang diinginkan.

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Contoh Langsung**

Anda dapat mencoba aplikasi gratis [**Aspose.Slides Viewer**](https://products.aspose.app/slides/id/viewer/) untuk melihat apa yang dapat Anda implementasikan dengan API Aspose.Slides:

![Penampil PowerPoint Online](online-PowerPoint-viewer.png)

## **FAQ**

**Apakah Saya dapat menyematkan penampil presentasi dalam aplikasi web?**

Ya. Anda dapat menggunakan Aspose.Slides di sisi server untuk merender slide sebagai gambar atau HTML dan menampilkannya di browser. Fitur navigasi dan zoom dapat diimplementasikan dengan JavaScript untuk pengalaman interaktif.

**Apa cara terbaik menampilkan slide di dalam penampil kustom?**

Pendekatan yang disarankan adalah merender setiap slide sebagai gambar (misalnya PNG atau SVG) atau mengonversinya ke HTML menggunakan Aspose.Slides, lalu menampilkan hasilnya di dalam kotak gambar (untuk desktop) atau kontainer HTML (untuk web).

**Bagaimana cara menangani presentasi besar dengan banyak slide?**

Untuk deck yang besar, pertimbangkan pemuatan malas atau rendering slide sesuai permintaan. Ini berarti menghasilkan konten slide hanya ketika pengguna menavigasi ke slide tersebut, sehingga mengurangi penggunaan memori dan waktu muat.