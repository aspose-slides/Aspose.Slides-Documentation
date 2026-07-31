---
title: Menyematkan Font dalam Presentasi Menggunakan C++
linktitle: Menyematkan Font
type: docs
weight: 40
url: /id/cpp/embedded-font/
keywords:
- tambahkan font
- sematkan font
- penyematan font
- dapatkan font tersemat
- tambahkan font tersemat
- hapus font tersemat
- kompres font tersemat
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Menyematkan font TrueType dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk C++, memastikan rendering yang akurat di semua platform."
---
## **Pendahuluan**

**Font tersemat di PowerPoint** membantu memastikan bahwa presentasi Anda mempertahankan tampilan yang dimaksudkan ketika dibuka di sistem atau perangkat apa pun. Ini sangat penting ketika menggunakan font khusus, pihak ketiga, atau non‑standar untuk tujuan merek atau kreativitas. Tanpa font tersemat, teks dapat diganti, tata letak dapat rusak, dan karakter mungkin muncul sebagai simbol atau persegi panjang yang tidak dapat dibaca, mengorbankan desain keseluruhan.

Aspose.Slides untuk C++ menyediakan sekumpulan API kuat untuk mengelola font tersemat secara programatis. Anda dapat menggunakan kelas [FontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/) dan [FontData](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontdata/) untuk memeriksa, menambahkan, atau menghapus font tersemat dalam file presentasi Anda. Selain itu, kelas [Compress](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/) memungkinkan Anda mengoptimalkan ukuran file dengan mengompresi data font tanpa memengaruhi kualitas atau tampilan.

Alat‑alat ini memberi Anda kontrol penuh atas penyematan font, membantu Anda mempertahankan tipografi yang konsisten di seluruh platform sambil mengurangi ukuran file bila diperlukan.

## **Dapatkan Font Tersemat dari Presentasi**

Aspose.Slides untuk C++ menyediakan metode `GetEmbeddedFonts` melalui kelas [FontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/) yang memungkinkan Anda mengambil daftar font yang tersemat dalam presentasi PowerPoint. Ini dapat berguna untuk mengaudit penggunaan font, memastikan kepatuhan terhadap pedoman merek, atau memverifikasi bahwa semua font yang diperlukan telah disertakan dengan benar sebelum membagikan file.

The following C++ code demonstrates how to get embedded fonts from a presentation file:

```cpp
// Membuat instance kelas Presentation yang mewakili file presentasi.
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

## **Tambah Font Tersemat ke Presentasi**

Aspose.Slides untuk C++ memungkinkan Anda menyematkan font ke dalam presentasi PowerPoint menggunakan metode [AddEmbeddedFont](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/addembeddedfont/) yang memiliki dua overload untuk penggunaan fleksibel. Anda dapat mengontrol seberapa banyak font yang disematkan dengan menggunakan enumerasi [EmbedFontCharacters](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/embedfontcharacters/) — misalnya, memilih untuk menyematkan hanya karakter yang digunakan atau seluruh set font. Fitur ini sangat berguna saat menyiapkan presentasi untuk dibagikan atau didistribusikan, memastikan bahwa font khusus atau non‑standar muncul dengan benar di semua sistem, bahkan jika font tersebut tidak terpasang.

The following C++ code checks all the fonts used in a presentation, and embeds any fonts that are not already embedded.

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

    // Periksa apakah font sudah tersemat.
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

## **Hapus Font Tersemat dari Presentasi**

Aspose.Slides untuk C++ menyediakan metode `RemoveEmbeddedFont` melalui kelas [FontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/) yang memungkinkan Anda menghapus font tertentu yang tersemat dalam presentasi PowerPoint. Ini dapat membantu mengurangi ukuran file secara keseluruhan, terutama jika font tersemat tidak lagi digunakan atau diperlukan. Menghapus font yang tidak terpakai juga dapat meningkatkan kinerja dan memastikan bahwa presentasi Anda hanya menyertakan sumber daya penting.

The following C++ code demonstrates how to remove an embedded font from a presentation:

```cpp
auto fontName = u"Calibri";

// Membuat instance kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Dapatkan semua font yang tersemat.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Hapus font yang tersemat.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Kompresi Font Tersemat**

Aspose.Slides untuk C++ menyediakan metode `CompressEmbeddedFonts` melalui kelas [Compress](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/) yang memungkinkan Anda mengurangi ukuran file keseluruhan sebuah presentasi dengan mengoptimalkan data font tersemat. Ini sangat berguna ketika presentasi Anda mencakup font yang besar atau banyak, dan Anda ingin menjaga file tetap ringan untuk dibagikan, disimpan, atau digunakan secara daring — tanpa mengorbankan kesetiaan visual konten.

The following C++ code demonstrates how to compress embedded fonts in a PowerPoint presentation:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa font tertentu dalam presentasi tetap akan diganti selama rendering meskipun sudah disematkan?**

Periksa [informasi substitusi](/slides/id/cpp/font-substitution/) di manajer font dan [aturan fallback/substitusi](/slides/id/cpp/fallback-font/): jika font tidak tersedia atau dibatasi, fallback akan digunakan.

**Apakah layak menyematkan font "system" seperti Arial/Calibri?**

Biasanya tidak - mereka hampir selalu tersedia. Namun untuk portabilitas penuh di lingkungan "thin" (Docker, server Linux tanpa font yang terpasang sebelumnya), menyematkan font sistem dapat menghilangkan risiko substitusi yang tak terduga.