---
title: Buat Penampil Presentasi dalam JavaScript
linktitle: Penampil Presentasi
type: docs
weight: 50
url: /id/nodejs-java/presentation-viewer/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat penampil presentasi khusus dalam JavaScript dengan Aspose.Slides untuk Node.js. Tampilkan file PowerPoint dan OpenDocument dengan mudah tanpa Microsoft PowerPoint."
---
## **Introduction**

Aspose.Slides for Node.js via Java digunakan untuk membuat file presentasi dengan slide. Slide ini dapat dilihat dengan membuka presentasi di Microsoft PowerPoint, misalnya. Namun, terkadang pengembang perlu melihat slide sebagai gambar di penampil gambar pilihan mereka atau membuat penampil presentasi mereka sendiri. Dalam kasus seperti itu, Aspose.Slides memungkinkan Anda mengekspor slide individu sebagai gambar. Artikel ini menjelaskan cara melakukannya.

## **Generate an SVG Image from a Slide**

Untuk menghasilkan gambar SVG dari slide presentasi dengan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) .
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Buka aliran file.
1. Simpan slide sebagai gambar SVG ke aliran file.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Generate an SVG with a Custom Shape ID**

Aspose.Slides dapat digunakan untuk menghasilkan sebuah [SVG](https://docs.fileformat.com/page-description-language/svg/) dari slide dengan ID bentuk kustom. Untuk melakukannya, gunakan metode `setId` dari [SvgShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` dapat digunakan untuk mengatur ID bentuk.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **Create a Slide Thumbnail Image**

Aspose.Slides membantu Anda menghasilkan gambar thumbnail slide. Untuk menghasilkan thumbnail slide dengan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) .
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar thumbnail slide yang direferensikan dengan skala tertentu.
1. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Create a Slide Thumbnail with User Defined Dimensions**

Untuk membuat gambar thumbnail slide dengan dimensi yang ditentukan pengguna, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) .
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar thumbnail slide yang direferensikan dengan dimensi yang ditentukan.
1. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Create a Slide Thumbnail with Speaker Notes**

Untuk menghasilkan thumbnail slide dengan catatan pembicara menggunakan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [RenderingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/renderingoptions/) .
1. Gunakan metode `RenderingOptions.setSlidesLayoutOptions` untuk mengatur posisi catatan pembicara.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) .
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar thumbnail slide yang direferensikan dengan opsi rendering.
1. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Live Example**

Anda dapat mencoba aplikasi gratis [**Aspose.Slides Viewer**](https://products.aspose.app/slides/id/viewer/) untuk melihat apa yang dapat Anda implementasikan dengan API Aspose.Slides:

![Penampil PowerPoint Online](online-PowerPoint-viewer.png)

## **FAQ**

**Apakah saya dapat menyematkan penampil presentasi dalam aplikasi web Node.js?**

Ya. Anda dapat menggunakan Aspose.Slides di sisi server untuk merender slide sebagai gambar atau HTML dan menampilkannya di browser. Fitur navigasi dan zoom dapat diimplementasikan dengan JavaScript untuk pengalaman interaktif.

**Apa cara terbaik menampilkan slide di dalam penampil kustom?**

Pendekatan yang disarankan adalah merender setiap slide sebagai gambar (misalnya PNG atau SVG) atau mengonversinya ke HTML menggunakan Aspose.Slides, kemudian menampilkan output di dalam picture box (untuk desktop) atau kontainer HTML (untuk web).

**Bagaimana cara menangani presentasi besar dengan banyak slide?**

Untuk dek besar, pertimbangkan lazy-loading atau rendering slide berdasarkan permintaan. Ini berarti menghasilkan konten slide hanya saat pengguna menavigasinya, mengurangi penggunaan memori dan waktu pemuatan.