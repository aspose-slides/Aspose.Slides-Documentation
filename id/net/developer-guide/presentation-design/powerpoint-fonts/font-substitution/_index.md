---
title: Konfigurasi Substitusi Font dalam Presentasi di .NET
linktitle: Substitusi Font
type: docs
weight: 70
url: /id/net/font-substitution/
keywords:
- font
- substitusi font
- substitusi font
- ganti font
- penggantian font
- aturan substitusi
- aturan penggantian
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Aktifkan substitusi font yang optimal di Aspose.Slides untuk .NET saat mengonversi presentasi PowerPoint & OpenDocument ke format file lain."
---
## **Ikhtisar**

Penggantian font memungkinkan Aspose.Slides menggunakan font lain ketika font presentasi asli tidak tersedia selama rendering atau konversi. Anda dapat memeriksa font mana yang digantikan dengan menggunakan metode `GetSubstitutions` dari antarmuka `IFontsManager`.

Aspose.Slides juga memungkinkan Anda mendefinisikan aturan penggantian font. Misalnya, Anda dapat menentukan bahwa font yang tidak dapat diakses harus diganti dengan font lain yang tersedia dan kemudian menerapkan aturan tersebut melalui manajer font presentasi.

## **Dapatkan Substitusi Font**

Untuk memungkinkan Anda menemukan font presentasi yang digantikan selama proses rendering presentasi, Aspose.Slides menyediakan metode [GetSubstitution](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/getsubstitutions/) dari antarmuka [IFontsManager](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsmanager/).

Kode C# berikut menunjukkan cara mendapatkan semua substitusi font yang dilakukan saat sebuah presentasi dirender:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```

## **Atur Aturan Substitusi Font**

Aspose.Slides memungkinkan Anda mengatur aturan untuk font yang menentukan apa yang harus dilakukan dalam kondisi tertentu (misalnya, ketika font tidak dapat diakses) dengan cara berikut:

1. Muat presentasi yang relevan.
2. Muat font yang akan diganti.
3. Muat font baru.
4. Tambahkan aturan untuk penggantian.
5. Tambahkan aturan ke koleksi aturan penggantian font presentasi.
6. Hasilkan gambar slide untuk melihat efeknya.

Kode C# berikut mendemonstrasikan proses substitusi font:
```c#
// Memuat sebuah presentasi
Presentation presentation = new Presentation("Fonts.pptx");

// Memuat font sumber yang akan diganti
IFontData sourceFont = new FontData("SomeRareFont");

// Memuat font baru
IFontData destFont = new FontData("Arial");

// Menambahkan aturan font untuk penggantian font
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Menambahkan aturan ke koleksi aturan substitusi font
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Menambahkan koleksi aturan font ke daftar aturan
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Menyimpan gambar ke disk dalam format JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Anda mungkin ingin melihat [**Penggantian Font**](/slides/id/net/font-replacement/). 
{{% /alert %}}

## **Keterbatasan untuk Font Persamaan Matematika**

Aturan substitusi font berpartisipasi dalam proses pemilihan font standar yang digunakan selama rendering dan konversi. Mereka cocok untuk skenario teks reguler di mana Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font lain yang tersedia sesuai aturan yang dikonfigurasi.

Namun, persamaan matematika Office memiliki keterbatasan penting. Jika sebuah persamaan dibuat dengan **Cambria Math**, Aspose.Slides masih mungkin memerlukan font **Cambria Math** asli untuk menghitung dan merender tata letak persamaan dengan benar. Karena itu, menggantikan **Cambria Math** dengan font matematika lain, seperti **STIX Two Math**, tidak didukung untuk rendering persamaan dan masih dapat menghasilkan pengecualian yang menunjukkan bahwa **Cambria Math** diperlukan.

Untuk mengonversi presentasi seperti itu dengan sukses, pastikan **Cambria Math** tersedia untuk Aspose.Slides pada runtime. Anda dapat menginstal font tersebut di sistem operasi atau menyediakannya sebagai [font eksternal](/slides/id/net/custom-font/) sehingga dapat berpartisipasi dalam proses pemilihan font normal selama rendering dan konversi.

Keterbatasan ini khusus untuk rendering persamaan. Aturan substitusi font standar yang dijelaskan di atas masih berlaku untuk teks presentasi reguler ketika font asli tidak dapat diakses.

## **FAQ**

**Apa perbedaan antara penggantian font dan substitusi font?**

[Penggantian](/slides/id/net/font-replacement/) adalah penimpaan paksa satu font dengan font lain di seluruh presentasi. Substitusi adalah aturan yang dipicu pada kondisi tertentu, misalnya ketika font asli tidak tersedia, dan kemudian font cadangan yang ditentukan digunakan.

**Kapan tepatnya aturan substitusi diterapkan?**

Aturan berpartisipasi dalam urutan [pemilihan font](/slides/id/net/font-selection-sequence/) standar yang dievaluasi selama pemuatan, rendering, dan konversi; jika font yang dipilih tidak tersedia, penggantian atau substitusi diterapkan.

**Apa perilaku default jika tidak ada penggantian maupun substitusi yang dikonfigurasi dan font tidak ada di sistem?**

Pustaka akan mencoba memilih font sistem terdekat yang tersedia, mirip dengan cara PowerPoint berperilaku.

**Bisakah saya melampirkan font eksternal khusus pada runtime untuk menghindari substitusi?**

Ya. Anda dapat [menambahkan font eksternal](/slides/id/net/custom-font/) pada runtime sehingga pustaka mempertimbangkannya untuk pemilihan dan rendering, termasuk untuk konversi selanjutnya.

**Apakah Aspose mendistribusikan font apa pun dengan pustaka?**

Tidak. Aspose tidak mendistribusikan font berbayar atau gratis; Anda menambahkan dan menggunakan font atas kebijaksanaan dan tanggung jawab Anda sendiri.

**Apakah ada perbedaan perilaku substitusi pada Windows, Linux, dan macOS?**

Ya. Penemuan font dimulai dari direktori font sistem operasi. Set font default yang tersedia dan jalur pencarian berbeda antar platform, yang memengaruhi ketersediaan dan kebutuhan substitusi.

**Bagaimana saya harus menyiapkan lingkungan untuk meminimalkan substitusi tak terduga selama konversi batch?**

Sinkronkan set font antar mesin atau kontainer, [tambahkan font eksternal](/slides/id/net/custom-font/) yang diperlukan untuk dokumen keluaran, dan [sematkan font](/slides/id/net/embedded-font/) dalam presentasi bila memungkinkan sehingga font yang dipilih tersedia selama rendering.