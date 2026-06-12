---
title: Konfigurasi Substitusi Font dalam Presentasi Menggunakan С++
linktitle: Substitusi Font
type: docs
weight: 70
url: /id/cpp/font-substitution/
keywords:
- font
- ganti font
- substitusi font
- gantikan font
- penggantian font
- aturan substitusi
- aturan penggantian
- PowerPoint
- OpenDocument
- presentasi
- С++
- Aspose.Slides
description: "Aktifkan substitusi font yang optimal di Aspose.Slides untuk С++ saat mengonversi presentasi PowerPoint & OpenDocument ke format file lainnya."
---
## **Ikhtisar**

Pengganti font memungkinkan Aspose.Slides menggunakan font lain ketika font presentasi asli tidak tersedia selama proses rendering atau konversi. Anda dapat memeriksa font mana yang diganti dengan menggunakan metode `GetSubstitutions` dari antarmuka `IFontsManager`.

Aspose.Slides juga memungkinkan Anda untuk mendefinisikan aturan penggantian font. Misalnya, Anda dapat menentukan bahwa font yang tidak dapat diakses harus diganti dengan font lain yang tersedia dan kemudian menerapkan aturan tersebut melalui manajer font presentasi.

## **Atur Aturan Substitusi Font**

Aspose.Slides memungkinkan Anda mengatur aturan untuk font yang menentukan apa yang harus dilakukan dalam kondisi tertentu (misalnya, ketika font tidak dapat diakses) dengan cara berikut:

1. Muat presentasi yang relevan.  
2. Muat font yang akan diganti.  
3. Muat font baru.  
4. Tambahkan aturan untuk penggantian.  
5. Tambahkan aturan ke koleksi aturan penggantian font presentasi.  
6. Hasilkan gambar slide untuk mengamati efeknya.

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Memuat presentasi
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Mendefinisikan font yang akan diganti dan font baru
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Menambahkan aturan font untuk penggantian font
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Menambahkan aturan ke koleksi aturan substitusi font
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Menambahkan koleksi aturan font ke daftar aturan
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Menyimpan PPTX ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Anda mungkin ingin melihat [**Penggantian Font**](/slides/id/cpp/font-replacement/). 
{{% /alert %}}

## **Keterbatasan untuk Font Persamaan Matematika**

Aturan penggantian font berpartisipasi dalam proses pemilihan font standar yang digunakan selama rendering dan konversi. Mereka cocok untuk skenario teks biasa di mana Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font lain yang tersedia sesuai aturan yang dikonfigurasi.

Namun, persamaan matematika Office memiliki keterbatasan penting. Jika sebuah persamaan dibuat dengan **Cambria Math**, Aspose.Slides mungkin masih memerlukan font **Cambria Math** asli untuk menghitung dan merender tata letak persamaan dengan benar. Karena itu, mengganti **Cambria Math** dengan font matematika lain, seperti **STIX Two Math**, tidak didukung untuk perenderan persamaan dan masih dapat menghasilkan pengecualian yang menyatakan bahwa **Cambria Math** diperlukan.

Untuk mengonversi presentasi semacam itu dengan sukses, pastikan **Cambria Math** tersedia bagi Aspose.Slides pada saat runtime. Anda dapat menginstal font di sistem operasi atau menyediakannya sebagai [external font](/slides/id/cpp/custom-font/) sehingga dapat berpartisipasi dalam proses pemilihan font normal selama rendering dan konversi.

Keterbatasan ini khusus untuk perenderan persamaan. Aturan penggantian font standar yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa ketika font asli tidak dapat diakses.

## **FAQ**

**Apa perbedaan antara penggantian font dan substitusi font?**  

[Replacement](/slides/id/cpp/font-replacement/) adalah penimpaan paksa satu font dengan font lain di seluruh presentasi. Substitusi adalah aturan yang dipicu dalam kondisi tertentu, misalnya ketika font asli tidak tersedia, dan kemudian font cadangan yang ditentukan digunakan.

**Kapan tepatnya aturan substitusi diterapkan?**  

Aturan berpartisipasi dalam urutan [font selection](/slides/id/cpp/font-selection-sequence/) standar yang dievaluasi selama pemuatan, rendering, dan konversi; jika font yang dipilih tidak tersedia, penggantian atau substitusi diterapkan.

**Apa perilaku default jika tidak ada penggantian maupun substitusi yang dikonfigurasi dan font tidak ada di sistem?**  

Perpustakaan akan mencoba memilih font sistem terdekat yang tersedia, mirip dengan perilaku PowerPoint.

**Apakah saya dapat melampirkan font eksternal khusus saat runtime untuk menghindari substitusi?**  

Ya. Anda dapat [add external fonts](/slides/id/cpp/custom-font/) pada saat runtime sehingga perpustakaan mempertimbangkannya untuk pemilihan dan perenderan, termasuk untuk konversi berikutnya.

**Apakah Aspose mendistribusikan font apa pun bersama perpustakaan?**  

Tidak. Aspose tidak mendistribusikan font berbayar atau gratis; Anda menambahkan dan menggunakan font atas kebijaksanaan serta tanggung jawab Anda sendiri.

**Apakah ada perbedaan perilaku substitusi di Windows, Linux, dan macOS?**  

Ya. Penemuan font dimulai dari direktori font sistem operasi. Set font default yang tersedia dan jalur pencarian berbeda di setiap platform, yang memengaruhi ketersediaan dan kebutuhan akan substitusi.

**Bagaimana saya harus menyiapkan lingkungan untuk meminimalkan substitusi tak terduga selama konversi batch?**  

Sinkronkan set font antar mesin atau kontainer, [add the external fonts](/slides/id/cpp/custom-font/) yang diperlukan untuk dokumen output, dan [embed fonts](/slides/id/cpp/embedded-font/) dalam presentasi bila memungkinkan sehingga font yang dipilih tersedia selama rendering.