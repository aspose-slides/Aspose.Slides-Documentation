---
title: Sematkan Font dalam Presentasi Menggunakan C++
linktitle: Menyematkan Font
type: docs
weight: 40
url: /id/cpp/embedded-font/
keywords:
- menambah font
- menyematkan font
- penyematan font
- mengambil font yang disematkan
- menambahkan font yang disematkan
- menghapus font yang disematkan
- mengompres font yang disematkan
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Sematkan font TrueType dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk C++, memastikan rendering yang akurat di semua platform."
---
## **Pendahuluan**

**Embedded fonts in PowerPoint** membantu memastikan bahwa presentasi Anda tetap terlihat seperti yang dimaksudkan saat dibuka di sistem atau perangkat apa pun. Hal ini sangat penting ketika menggunakan font kustom, pihak ketiga, atau non‑standar untuk branding atau keperluan kreatif. Tanpa embedded fonts, teks dapat diganti, tata letak bisa rusak, dan karakter mungkin muncul sebagai simbol atau persegi panjang yang tidak dapat dibaca, sehingga merusak desain keseluruhan.

Aspose.Slides for C++ menyediakan serangkaian API kuat untuk mengelola embedded fonts secara programatik. Anda dapat menggunakan [FontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/) dan [FontData](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontdata/) untuk memeriksa, menambah, atau menghapus embedded fonts dalam file presentasi Anda. Selain itu, kelas [Compress](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/) memungkinkan Anda mengoptimalkan ukuran file dengan mengompresi data font tanpa memengaruhi kualitas atau tampilan.

Alat‑alat ini memberikan kontrol penuh atas penyematan font, membantu Anda mempertahankan tipografi yang konsisten di berbagai platform sambil mengurangi ukuran file bila diperlukan.

## **Dapatkan Embedded Fonts dari Presentasi**

Aspose.Slides for C++ menyediakan metode `GetEmbeddedFonts` melalui kelas [FontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/) yang memungkinkan Anda mengambil daftar font yang disematkan dalam presentasi PowerPoint. Hal ini berguna untuk mengaudit penggunaan font, memastikan kepatuhan terhadap pedoman branding, atau memverifikasi bahwa semua font yang diperlukan telah disertakan dengan benar sebelum membagikan file.

Contoh kode C++ berikut menunjukkan cara mendapatkan embedded fonts dari file presentasi:

```cpp
// Membuat instansi kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Get all embedded fonts.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Print names of the embedded fonts.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Tambahkan Embedded Fonts ke Presentasi**

Aspose.Slides for C++ memungkinkan Anda menyematkan font ke dalam presentasi PowerPoint menggunakan metode [AddEmbeddedFont](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/addembeddedfont/), yang memiliki dua overload untuk penggunaan yang fleksibel. Anda dapat mengontrol seberapa banyak font yang disematkan dengan menggunakan enumerasi [EmbedFontCharacters](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/embedfontcharacters/) — misalnya, memilih untuk menyematkan hanya karakter yang digunakan atau seluruh set font. Fitur ini sangat berguna saat menyiapkan presentasi untuk dibagikan atau didistribusikan, memastikan bahwa font kustom atau non‑standar muncul dengan benar di semua sistem, bahkan jika font tersebut tidak terinstal.

Contoh kode C++ berikut memeriksa semua font yang digunakan dalam presentasi, dan menyematkan font yang belum disematkan:

```cpp
// Muat file presentasi.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Periksa apakah font sudah disematkan.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Sematkan font ke dalam presentasi.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Simpan presentasi ke disk.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Hapus Embedded Fonts dari Presentasi**

Aspose.Slides for C++ menyediakan metode `RemoveEmbeddedFont` melalui kelas [FontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/) yang memungkinkan Anda menghapus font tertentu yang disematkan dalam presentasi PowerPoint. Hal ini dapat membantu mengurangi ukuran file secara keseluruhan, terutama jika font yang disematkan tidak lagi digunakan atau diperlukan. Menghapus font yang tidak terpakai juga dapat meningkatkan kinerja dan memastikan bahwa presentasi Anda hanya menyertakan sumber daya yang esensial.

Contoh kode C++ berikut menunjukkan cara menghapus embedded font dari sebuah presentasi:

```cpp
auto fontName = u"Calibri";

// Buat instansi kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Dapatkan semua font yang disematkan.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Hapus font yang disematkan.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Kompres Embedded Fonts**

Aspose.Slides for C++ menyediakan metode `CompressEmbeddedFonts` melalui kelas [Compress](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/) yang memungkinkan Anda mengurangi ukuran file presentasi secara keseluruhan dengan mengoptimalkan data font yang disematkan. Ini sangat berguna ketika presentasi Anda mencakup font yang besar atau banyak, dan Anda ingin menjaga file tetap ringan untuk dibagikan, disimpan, atau digunakan secara online — tanpa mengorbankan kesetiaan visual konten.

Contoh kode C++ berikut menunjukkan cara mengompresi embedded fonts dalam presentasi PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa font tertentu dalam presentasi masih akan diganti selama rendering meskipun sudah disematkan?**

Periksa [informasi substitusi](/slides/id/cpp/font-substitution/) di font manager dan [aturan fallback/substitusi](/slides/id/cpp/fallback-font/): jika font tidak tersedia atau dibatasi, fallback akan digunakan.

**Apakah layak menyematkan font "sistem" seperti Arial/Calibri?**

Biasanya tidak—font tersebut hampir selalu tersedia. Namun untuk portabilitas penuh di lingkungan "tipis" (Docker, server Linux tanpa font yang terpasang), menyematkan font sistem dapat menghilangkan risiko substitusi yang tak terduga.