---
title: "Mengonversi Slide Presentasi menjadi Gambar dalam C++"
linktitle: "Slide ke Gambar"
type: docs
weight: 41
url: /id/cpp/convert-slide/
keywords:
- "konversi slide"
- "ekspor slide"
- "slide ke gambar"
- "simpan slide sebagai gambar"
- "slide ke PNG"
- "slide ke JPEG"
- "slide ke bitmap"
- "slide ke TIFF"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "C++"
- "Aspose.Slides"
description: "Mengonversi slide dari PPT, PPTX, dan ODP menjadi gambar dalam C++ menggunakan Aspose.Slides—rendering cepat, berkualitas tinggi dengan contoh kode yang jelas."
---
## **Pendahuluan**

Aspose.Slides untuk C++ memungkinkan Anda dengan mudah mengonversi slide presentasi PowerPoint dan OpenDocument ke berbagai format gambar, termasuk BMP, PNG, JPG (JPEG), GIF, dan lainnya.

Untuk mengonversi sebuah slide menjadi gambar, ikuti langkah-langkah berikut:

1. Tentukan pengaturan konversi yang diinginkan dan pilih slide yang ingin Anda ekspor dengan menggunakan:
    - Antarmuka [ITiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/itiffoptions/), atau
    - Antarmuka [IRenderingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/irenderingoptions/).
2. Buat gambar slide dengan memanggil metode [GetImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/getimage/).

Sebuah [Bitmap](https://reference.aspose.com/slides/id/cpp/system.drawing/bitmap/) adalah objek yang memungkinkan Anda bekerja dengan gambar yang didefinisikan oleh data piksel. Anda dapat menggunakan instance dari kelas ini untuk menyimpan gambar dalam berbagai format (BMP, JPG, PNG, dll).

## **Mengonversi Slide ke Bitmap dan Menyimpan Gambar dalam PNG**

Anda dapat mengonversi slide menjadi objek bitmap dan menggunakannya langsung dalam aplikasi Anda. Atau, Anda dapat mengonversi slide menjadi bitmap dan kemudian menyimpan gambar dalam format JPEG atau format lain yang diinginkan.

Kode C++ berikut menunjukkan cara mengonversi slide pertama dari sebuah presentasi menjadi objek bitmap dan kemudian menyimpan gambar dalam format PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide in the presentation to a bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Save the image in the PNG format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Mengonversi Slide ke Gambar dengan Ukuran Kustom**

Anda mungkin perlu mendapatkan gambar dengan ukuran tertentu. Dengan menggunakan overload dari [GetImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/getimage/), Anda dapat mengonversi slide menjadi gambar dengan dimensi spesifik (lebar dan tinggi).

Contoh kode berikut menunjukkan cara melakukannya:

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

## **Mengonversi Slide dengan Catatan dan Komentar menjadi Gambar**

Beberapa slide mungkin berisi catatan dan komentar.

Aspose.Slides menyediakan dua antarmuka—[ITiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/itiffoptions/) dan [IRenderingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/irenderingoptions/)—yang memungkinkan Anda mengontrol render slide presentasi menjadi gambar. Kedua antarmuka menyertakan metode `set_SlidesLayoutOptions`, yang memungkinkan Anda mengatur render catatan dan komentar pada slide saat mengonversinya menjadi gambar.

Dengan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notescommentslayoutingoptions/), Anda dapat menentukan posisi yang diinginkan untuk catatan dan komentar dalam gambar yang dihasilkan.

Kode C++ berikut menunjukkan cara mengonversi slide dengan catatan dan komentar:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Memuat file presentasi.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Mengatur posisi catatan.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Mengatur posisi komentar.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Mengatur lebar area komentar.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Mengatur warna area komentar.

// Membuat opsi rendering.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Mengonversi slide pertama presentasi menjadi gambar.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Simpan gambar dalam format GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

Dalam proses konversi slide ke gambar apa pun, metode [set_NotesPosition](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) tidak dapat menerapkan `BottomFull` (untuk menentukan posisi catatan) karena teks catatan mungkin terlalu besar, sehingga tidak dapat muat dalam ukuran gambar yang ditentukan.

{{% /alert %}} 

## **Mengonversi Slide ke Gambar Menggunakan Opsi TIFF**

Antarmuka [ITiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/itiffoptions/) memberikan kontrol yang lebih besar atas gambar TIFF yang dihasilkan dengan memungkinkan Anda menentukan parameter seperti ukuran, resolusi, palet warna, dan lainnya.

Kode C++ berikut menunjukkan proses konversi di mana opsi TIFF digunakan untuk menghasilkan gambar hitam-putih dengan resolusi 300 DPI dan ukuran 2160 × 2800:

```cpp 
// Muat file presentasi.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ambil slide pertama dari presentasi.
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

## **Mengonversi Semua Slide menjadi Gambar**

Aspose.Slides memungkinkan Anda mengonversi semua slide dalam sebuah presentasi menjadi gambar, secara efektif mengubah seluruh presentasi menjadi serangkaian gambar.

Contoh kode berikut menunjukkan cara mengonversi semua slide dalam sebuah presentasi menjadi gambar dalam C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Render presentasi menjadi gambar slide per slide.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Kontrol slide tersembunyi (jangan render slide tersembunyi).
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

## **Render Emoji Berwarna**

{{% alert title="Note" color="warning" %}} 
Untuk merender emoji berwarna dengan benar saat mengonversi slide presentasi menjadi gambar, font emoji yang digunakan dalam presentasi harus diinstal dan tersedia pada sistem yang melakukan konversi. Misalnya, jika presentasi menggunakan **Segoe UI Emoji** dan font ini tidak ada, emoji dapat muncul dalam monokrom pada gambar keluaran.
{{% /alert %}}

## **Tanya Jawab**

**Apakah Aspose.Slides mendukung render slide dengan animasi?**

Tidak, metode `GetImage` hanya menyimpan gambar statis dari slide, tanpa animasi.

**Dapatkah slide tersembunyi diekspor sebagai gambar?**

Ya, slide tersembunyi dapat diproses seperti slide biasa. Pastikan slide tersebut termasuk dalam loop pemrosesan.

**Dapatkah gambar disimpan dengan bayangan dan efek?**

Ya, Aspose.Slides mendukung render bayangan, transparansi, dan efek grafis lainnya saat menyimpan slide sebagai gambar.