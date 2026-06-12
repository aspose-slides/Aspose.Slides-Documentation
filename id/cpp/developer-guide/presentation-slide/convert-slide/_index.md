---
title: Mengonversi Slide Presentasi menjadi Gambar dalam C++
linktitle: Slide ke Gambar
type: docs
weight: 41
url: /id/cpp/convert-slide/
keywords:
- konversi slide
- ekspor slide
- slide ke gambar
- simpan slide sebagai gambar
- slide ke PNG
- slide ke JPEG
- slide ke bitmap
- slide ke TIFF
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Mengonversi slide dari PPT, PPTX, dan ODP menjadi gambar dalam C++ menggunakan Aspose.Slides—rendering cepat, berkualitas tinggi dengan contoh kode yang jelas."
---
## **Pendahuluan**

Aspose.Slides for C++ memungkinkan Anda dengan mudah mengonversi slide presentasi PowerPoint dan OpenDocument ke berbagai format gambar, termasuk BMP, PNG, JPG (JPEG), GIF, dan lainnya.

Untuk mengonversi slide menjadi gambar, ikuti langkah-langkah berikut:

1. Tentukan pengaturan konversi yang diinginkan dan pilih slide yang ingin Anda ekspor dengan menggunakan:
    - Antarmuka [ITiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/itiffoptions/) atau
    - Antarmuka [IRenderingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/irenderingoptions/)
2. Hasilkan gambar slide dengan memanggil metode [GetImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/getimage/).

Sebuah [Bitmap](https://reference.aspose.com/slides/id/cpp/system.drawing/bitmap/) adalah objek yang memungkinkan Anda bekerja dengan gambar yang didefinisikan oleh data piksel. Anda dapat menggunakan instance dari kelas ini untuk menyimpan gambar dalam berbagai format (BMP, JPG, PNG, dll.).

## **Konversi Slide ke Bitmap dan Simpan Gambar dalam PNG**

Anda dapat mengonversi slide menjadi objek bitmap dan menggunakannya langsung dalam aplikasi Anda. Atau, Anda dapat mengonversi slide menjadi bitmap dan kemudian menyimpan gambar dalam format JPEG atau format lain yang diinginkan.

Kode C++ berikut menunjukkan cara mengonversi slide pertama dari presentasi menjadi objek bitmap dan kemudian menyimpan gambar dalam format PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Mengonversi slide pertama dalam presentasi menjadi bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Simpan gambar dalam format PNG.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Konversi Slide ke Gambar dengan Ukuran Kustom**

Anda mungkin perlu mendapatkan gambar dengan ukuran tertentu. Dengan menggunakan overload dari [GetImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/getimage/), Anda dapat mengonversi slide menjadi gambar dengan dimensi spesifik (lebar dan tinggi). 

Kode contoh ini menunjukkan cara melakukannya:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Mengonversi slide pertama dalam presentasi menjadi bitmap dengan ukuran yang ditentukan.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Simpan gambar dalam format JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Konversi Slide dengan Catatan dan Komentar ke Gambar**

Beberapa slide mungkin berisi catatan dan komentar.

Aspose.Slides menyediakan dua antarmuka—[ITiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/itiffoptions/) dan [IRenderingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/irenderingoptions/)—yang memungkinkan Anda mengontrol rendering slide presentasi ke gambar. Kedua antarmuka menyertakan metode `set_SlidesLayoutOptions`, yang memungkinkan Anda mengatur rendering catatan dan komentar pada slide saat mengonversinya menjadi gambar.

Dengan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notescommentslayoutingoptions/), Anda dapat menentukan posisi yang diinginkan untuk catatan dan komentar dalam gambar yang dihasilkan.

Kode C++ berikut menunjukkan cara mengonversi slide dengan catatan dan komentar:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Atur posisi catatan.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Atur posisi komentar.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Atur lebar area komentar.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Atur warna area komentar.

// Buat opsi rendering.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Konversi slide pertama dari presentasi menjadi gambar.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Simpan gambar dalam format GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Catatan" color="warning" %}} 

Dalam proses konversi slide ke gambar apa pun, metode [set_NotesPosition](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) tidak dapat menerapkan `BottomFull` (untuk menentukan posisi catatan) karena teks catatan mungkin terlalu besar, sehingga tidak dapat muat dalam ukuran gambar yang ditentukan.

{{% /alert %}} 

## **Konversi Slide ke Gambar Menggunakan Opsi TIFF**

Antarmuka [ITiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/itiffoptions/) memberikan kontrol lebih besar atas gambar TIFF yang dihasilkan dengan memungkinkan Anda menentukan parameter seperti ukuran, resolusi, palet warna, dan lain-lain.

Kode C++ berikut menunjukkan proses konversi di mana opsi TIFF digunakan untuk menghasilkan gambar hitam-putih dengan resolusi 300 DPI dan ukuran 2160 × 2800:

```cpp 
// Muat file presentasi.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Dapatkan slide pertama dari presentasi.
auto slide = presentation->get_Slide(0);

// Konfigurasikan pengaturan gambar TIFF output.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Atur ukuran gambar.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Atur format piksel (hitam putih).
tiffOptions->set_DpiX(300);                                         // Atur resolusi horizontal.
tiffOptions->set_DpiY(300);                                         // Atur resolusi vertikal.

// Konversi slide menjadi gambar dengan opsi yang ditentukan.
auto image = slide->GetImage(tiffOptions);

// Simpan gambar dalam format TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Konversi Semua Slide ke Gambar**

Aspose.Slides memungkinkan Anda mengonversi semua slide dalam sebuah presentasi menjadi gambar, secara efektif mengubah seluruh presentasi menjadi serangkaian gambar.

Kode contoh ini menunjukkan cara mengonversi semua slide dalam presentasi menjadi gambar menggunakan C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Render presentasi menjadi gambar slide per slide.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Kendalikan slide tersembunyi (jangan render slide tersembunyi).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Konversi slide menjadi gambar.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Simpan gambar dalam format JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **FAQ**

**Apakah Aspose.Slides mendukung rendering slide dengan animasi?**

Tidak, metode `GetImage` hanya menyimpan gambar statis dari slide, tanpa animasi.

**Apakah slide tersembunyi dapat diekspor sebagai gambar?**

Ya, slide tersembunyi dapat diproses seperti slide biasa. Pastikan slide tersebut termasuk dalam loop pemrosesan.

**Apakah gambar dapat disimpan dengan bayangan dan efek?**

Ya, Aspose.Slides mendukung rendering bayangan, transparansi, dan efek grafis lainnya saat menyimpan slide sebagai gambar.