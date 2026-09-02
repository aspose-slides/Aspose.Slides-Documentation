---
title: Optimalkan Manajemen Gambar dalam Presentasi di .NET
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/net/image/
keywords:
- tambahkan gambar
- tambahkan foto
- ganti gambar
- koleksi gambar
- bingkai gambar
- gambar tertaut
- latar belakang
- tambahkan PNG
- tambahkan JPG
- tambahkan SVG
- SVG menjadi bentuk
- sumber daya SVG eksternal
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menambahkan, menggunakan kembali, menautkan, mengganti, dan mengelola gambar raster serta SVG dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET."
---
## **Pendahuluan**

Aspose.Slides untuk .NET menyediakan beberapa cara untuk bekerja dengan gambar, dan setiap cara melayani tujuan yang berbeda. Anda dapat menyimpan gambar dalam presentasi, menampilkannya dalam bingkai gambar, menggunakannya sebagai latar belakang slide, menautkan ke gambar eksternal, mengganti sumber daya gambar yang dibagikan, atau mengonversi konten SVG menjadi bentuk yang dapat diedit.

Artikel ini berfokus pada sumber daya gambar dan cara penggunaannya di seluruh presentasi. Untuk pemotongan, transparansi, efek, peregangan, dan format lain yang diterapkan pada bingkai gambar individu, lihat [Bingkai Gambar](/slides/id/net/picture-frame/).

## **Memahami Model Gambar**

Konsep API berikut terkait erat tetapi tidak dapat dipertukarkan:

- The [koleksi gambar presentasi](https://reference.aspose.com/slides/id/net/aspose.slides/iimagecollection/) menyimpan sumber daya gambar yang digunakan oleh presentasi. Gunakan [ImageCollection.AddImage](https://reference.aspose.com/slides/id/net/aspose.slides/imagecollection/addimage/) untuk menambahkan data gambar dan memperoleh sumber daya [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/).
- Sebuah [bingkai gambar](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe/) adalah bentuk yang menampilkan gambar pada slide, tata letak, atau master. Gunakan [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addpictureframe/) untuk menempatkan sumber daya gambar pada slide.
- Latar belakang slide menggunakan gambar sebagai bagian dari isian slide, bukan sebagai bentuk. Oleh karena itu tidak berperilaku seperti bingkai gambar.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/replaceimage/) mengganti sumber daya gambar. Jika beberapa elemen presentasi menggunakan sumber daya itu, semuanya akan menggunakan penggantiannya.
- Mengonversi SVG menjadi bentuk menghasilkan bentuk slide yang dapat diedit. Setelah konversi, konten tidak lagi dikelola sebagai satu sumber daya gambar.

Alur kerja umum karenanya: tambahkan data gambar ke koleksi gambar, terima sebuah [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/), dan kemudian gunakan sumber daya tersebut dalam satu atau lebih bingkai gambar atau isian.

## **Menambahkan Gambar yang Disematkan**

Untuk menyisipkan gambar lokal, baca file, tambahkan datanya ke koleksi gambar, dan buat bingkai gambar yang menggunakan `IPPImage` yang dikembalikan.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Gambar yang ditambahkan dengan cara ini disematkan dalam presentasi, sehingga file hasil tidak bergantung pada keberadaan file gambar asli.

### **Menambahkan Gambar dari Web**

Ketika sebuah gambar tersedia melalui HTTP atau HTTPS, unduh byte-nya dengan `HttpClient`, tambahkan ke koleksi gambar presentasi, dan gunakan sumber daya gambar yang dikembalikan dengan cara yang sama seperti gambar lokal.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

Dalam aplikasi yang berjalan lama, gunakan kembali `HttpClient` daripada membuat instance baru untuk setiap permintaan. Juga validasi URL jarak jauh, ukuran respons, dan tipe konten ketika sumber tidak dipercaya.

## **Gunakan Kembali Gambar di Seluruh Slide**

Jika gambar yang sama diperlukan lebih dari satu kali, tambahkan sekali ke presentasi dan gunakan kembali [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) yang dikembalikan saat membuat bingkai gambar tambahan. Ini menghindari pemuatan berulang data sumber yang sama dan menjadikan hubungan antara sumber daya gambar yang dibagikan dan penggunaannya menjadi eksplisit.

Untuk grafik yang seharusnya muncul secara otomatis pada banyak slide, seperti logo perusahaan, pertimbangkan menempatkan bingkai gambar pada [master slide](/slides/id/net/slide-master/) atau tata letak alih-alih menambahkan bentuk yang setara ke setiap slide.

## **Menggunakan Gambar sebagai Latar Belakang Slide**

Gambar latar belakang ditetapkan pada isian slide; tidak ditambahkan sebagai bentuk bingkai gambar. Ini berguna ketika gambar harus menutupi latar belakang slide dan tidak boleh dimanipulasi sebagai objek slide biasa.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

Untuk opsi latar belakang tambahan, termasuk latar belakang master dan tata letak, lihat [Latar Belakang Presentasi](/slides/id/net/presentation-background/).

## **Gambar yang Disematkan dan Gambar Tertaut**

Gambar yang disematkan dan gambar tertaut memiliki pertukaran portabilitas dan ukuran file yang berbeda:

- **Gambar yang disematkan:** data gambar disimpan di dalam presentasi. Presentasi bersifat mandiri, tetapi ukuran file mencakup data gambar.
- **Gambar tertaut:** presentasi menyimpan jalur atau URL ke gambar eksternal. Ini dapat mengurangi ukuran presentasi, tetapi sumber daya eksternal harus tetap dapat diakses ketika presentasi dibuka atau dirender.

Gambar tertaut dapat dibuat dengan menetapkan jalur atau URL eksternal melalui [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/id/net/aspose.slides/islidespicture/linkpathlong/) alih-alih menyematkan data gambar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Gunakan gambar tertaut hanya ketika lingkungan penyebaran dapat mengakses sumber daya eksternal secara andal. Untuk presentasi yang harus berfungsi secara offline atau dipindahkan antar sistem, gambar yang disematkan biasanya lebih aman.

## **Bekerja dengan Gambar SVG**

SVG adalah format vektor, sehingga dapat berguna untuk ikon, diagram, dan grafik lain yang harus diskalakan tanpa kehilangan detail seperti gambar raster. Aspose.Slides mendukung SVG baik sebagai sumber daya gambar maupun sebagai sumber untuk bentuk slide yang dapat diedit.

### **Menambahkan SVG sebagai Gambar**

Buat sebuah [SvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/svgimage/), tambahkan ke koleksi gambar, dan tempatkan sumber daya gambar yang dihasilkan dalam bingkai gambar.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **File SVG dengan Sumber Daya Eksternal**

Sebuah SVG dapat merujuk gambar eksternal, stylesheet, atau font. Untuk kasus ini, [SvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/svgimage/) menyediakan konstruktor yang menerima [IExternalResourceResolver](https://reference.aspose.com/slides/id/net/aspose.slides.import/iexternalresourceresolver/) dan basis URI. Resolver dapat memetakan URI relatif ke URI absolut yang diizinkan dan mengembalikan aliran untuk sumber daya yang diminta.

Resolver membuat sumber daya eksternal tersedia saat Aspose.Slides memproses SVG, tetapi tidak menulis ulang SVG menjadi dokumen mandiri. Jika SVG harus tetap portabel, sematkan sumber daya yang diperlukan ke dalam SVG itu sendiri, misalnya dengan menggunakan URI `data:` untuk gambar tertaut.

Ketika file SVG berasal dari sumber yang tidak terpercaya, batasi skema, lokasi file, dan host yang dapat diakses resolver. Resolver jaringan juga harus menerapkan batas waktu, batas ukuran respons, dan validasi konten.

### **Mengonversi SVG menjadi Bentuk yang Dapat Diedit**

Aspose.Slides dapat mengonversi SVG menjadi sekelompok bentuk slide yang dapat diedit, mirip dengan perintah PowerPoint yang sesuai.

![Menu Popup PowerPoint](img_01_01.png)

Gunakan overload [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addgroupshape/) yang menerima [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/) untuk melakukan konversi.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

Gunakan konversi SVG ke bentuk ketika elemen vektor individu perlu diedit sebagai bentuk PowerPoint. Jika SVG hanya perlu ditampilkan, menyimpannya sebagai gambar lebih sederhana dan menghindari pembuatan banyak bentuk terpisah.

## **Mengganti Sumber Daya Gambar yang Ada**

Gunakan [IPPImage.ReplaceImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/replaceimage/) ketika Anda ingin mengganti sumber daya gambar yang ada. Ini sangat berguna untuk grafik yang dibagikan seperti logo.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Jika beberapa bingkai gambar, latar belakang, master, atau tata letak menggunakan sumber daya gambar yang sama, mengganti sumber daya tersebut memperbarui semua penggunaan tersebut. Jika hanya satu bingkai gambar yang harus berubah, tetapkan gambar yang berbeda ke bingkai tersebut alih-alih mengganti sumber daya yang dibagikan.

`ReplaceImage` juga menyediakan overload yang menerima [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) atau [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) lainnya.

## **Panduan Praktis Manajemen Gambar**

### **Mengontrol Ukuran Presentasi**

Gambar raster besar dapat membuat presentasi terlalu besar. Gunakan gambar sumber dengan dimensi yang sesuai untuk ukuran tampilan yang dimaksud, gunakan kembali sumber daya gambar yang dibagikan bila memungkinkan, dan hindari menyematkan salinan berulang dari grafik resolusi penuh yang sama.

Untuk gambar raster yang sudah ditempatkan dalam bingkai gambar, [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/compressimage/) dapat mengurangi data gambar sesuai resolusi dan pengaturan pemotongan yang dipilih. Ini adalah pemrosesan bingkai gambar, bukan manajemen koleksi gambar, jadi lihat [Bingkai Gambar](/slides/id/net/picture-frame/) untuk operasi format terkait.

### **Memilih Antara Konten yang Disematkan dan Tertaut**

Penyematan membuat presentasi portabel karena semua data gambar yang diperlukan ikut dalam file. Penautan dapat mengurangi ukuran file, tetapi memperkenalkan ketergantungan eksternal. Gunakan tautan hanya ketika ketergantungan tersebut dapat diterima dan stabil.

### **Gunakan Kembali Merek yang Dibagikan**

Untuk logo, watermark, atau grafik dekoratif yang berulang, gunakan satu sumber daya gambar dan gunakan kembali. Jika grafik merupakan bagian dari desain presentasi bukan konten slide, tempatkan pada master atau tata letak sehingga diwariskan ke slide yang sesuai.

### **Menjaga Sumber Daya SVG Portabel**

SVG yang mandiri lebih mudah dipindahkan dan dirender secara konsisten dibandingkan SVG yang bergantung pada file eksternal atau sumber daya jaringan. Bila memungkinkan, sematkan sumber daya yang diperlukan sebelum mengimpor SVG. Konversi SVG ke bentuk hanya ketika elemen vektor individu perlu diedit.

### **Gunakan API Gambar Lintas Platform Modern**

Untuk kode .NET baru, gunakan API Aspose.Slides [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) dan [Images](https://reference.aspose.com/slides/id/net/aspose.slides/images/) alih-alih bergantung pada `System.Drawing.Image` atau `Bitmap`. Lihat [API Modern](/slides/id/net/modern-api/) untuk panduan migrasi.

WMF dan EMF memerlukan pertimbangan khusus. Ketika format ini diteruskan melalui [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/), [ImageCollection.AddImage](https://reference.aspose.com/slides/id/net/aspose.slides/imagecollection/addimage/) mengonversi metafile menjadi representasi PNG raster sebelum penyisipan. Jika mempertahankan data metafile penting, gunakan overload [ImageCollection.AddImage](https://reference.aspose.com/slides/id/net/aspose.slides/imagecollection/addimage/) berbasis aliran. Menghasilkan konten EMF dari spreadsheet atau produk lain adalah alur kerja integrasi terpisah dan berada di luar cakupan artikel ini.

## **FAQ**

**Apa perbedaan antara koleksi gambar dan bingkai gambar?**

Koleksi gambar menyimpan sumber daya gambar yang dapat digunakan kembali. Bingkai gambar adalah bentuk slide yang menampilkan salah satu sumber daya tersebut dan menyediakan format khusus gambar seperti pemotongan dan efek.

**Apa cara terbaik untuk mengganti logo yang sama di semua tempat?**

Jika logo sudah dibagikan sebagai satu sumber daya gambar, ganti sumber daya tersebut dengan [IPPImage.ReplaceImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/replaceimage/). Untuk branding di seluruh presentasi, menempatkan logo pada master atau tata letak juga dapat mengurangi konten slide yang duplikat.

**Mengapa gambar tertaut menghilang di komputer lain?**

Gambar tertaut bergantung pada file atau URL eksternalnya. Jika sumber daya tersebut tidak dapat dijangkau dari komputer lain, gambar tertaut mungkin tidak tersedia. Sematkan gambar ketika presentasi harus bersifat mandiri.

**Apakah SVG yang disisipkan dapat diedit sebagai bentuk PowerPoint?**

Ya. Konversi SVG dengan [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addgroupshape/); grup yang dihasilkan berisi bentuk slide yang dapat diedit, bukan satu gambar SVG.

**Bagaimana saya dapat menjaga presentasi dengan banyak gambar tetap kecil?**

Gunakan kembali sumber daya gambar yang dibagikan, hindari sumber raster yang tidak perlu besar, kompres gambar raster yang sesuai bila tepat, simpan branding yang berulang pada master atau tata letak, dan gunakan gambar tertaut hanya ketika ketergantungan eksternal dapat diterima.