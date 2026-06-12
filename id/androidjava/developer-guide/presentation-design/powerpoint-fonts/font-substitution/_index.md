---
title: Mengonfigurasi Substitusi Font dalam Presentasi di Android
linktitle: Substitusi Font
type: docs
weight: 70
url: /id/androidjava/font-substitution/
keywords:
- font
- ganti font
- substitusi font
- penggantian font
- penggantian font
- aturan substitusi
- aturan penggantian
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Aktifkan substitusi font optimal di Aspose.Slides untuk Android melalui Java saat mengonversi presentasi PowerPoint & OpenDocument ke format file lain."
---
## **Gambaran Umum**

Penggantian font memungkinkan Aspose.Slides menggunakan font lain ketika font presentasi asli tidak tersedia selama proses rendering atau konversi. Anda dapat memeriksa font mana yang telah diganti dengan menggunakan metode `getSubstitutions` dari antarmuka `IFontsManager`.

Aspose.Slides juga memungkinkan Anda mendefinisikan aturan penggantian font. Misalnya, Anda dapat menentukan bahwa font yang tidak dapat diakses harus diganti dengan font lain yang tersedia dan kemudian menerapkan aturan tersebut melalui manajer font presentasi.

## **Atur Aturan Penggantian Font**

Aspose.Slides memungkinkan Anda menetapkan aturan untuk font yang menentukan apa yang harus dilakukan dalam kondisi tertentu (misalnya, ketika sebuah font tidak dapat diakses) dengan cara berikut:

1. Muat presentasi yang relevan.
2. Muat font yang akan diganti.
3. Muat font baru.
4. Tambahkan aturan untuk penggantian.
5. Tambahkan aturan ke koleksi aturan penggantian font presentasi.
6. Hasilkan gambar slide untuk mengamati efeknya.

Kode Java berikut menunjukkan proses penggantian font:

```java
// Memuat presentasi
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Memuat font sumber yang akan diganti
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Memuat font baru
    IFontData destFont = new FontData("Arial");
    
    // Menambahkan aturan font untuk penggantian font
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Menambahkan aturan ke koleksi aturan substitusi font
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Menambahkan koleksi aturan font ke daftar aturan
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Font Arial akan digunakan menggantikan SomeRareFont ketika yang terakhir tidak dapat diakses
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Menyimpan gambar ke disk dalam format JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Anda mungkin ingin melihat [**Font Replacement**](/slides/id/androidjava/font-replacement/).
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan penggantian font berpartisipasi dalam proses pemilihan font standar yang digunakan selama rendering dan konversi. Aturan ini cocok untuk skenario teks biasa di mana Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font lain yang tersedia sesuai aturan yang dikonfigurasi.

Namun, persamaan matematika Office memiliki batasan penting. Jika sebuah persamaan dibuat dengan **Cambria Math**, Aspose.Slides masih mungkin memerlukan font **Cambria Math** asli untuk menghitung dan merender tata letak persamaan dengan benar. Karena itu, mengganti **Cambria Math** dengan font matematika lain, seperti **STIX Two Math**, tidak didukung untuk rendering persamaan dan masih dapat menghasilkan pengecualian yang menunjukkan bahwa **Cambria Math** diperlukan.

Untuk mengonversi presentasi semacam itu dengan sukses, pastikan **Cambria Math** tersedia untuk Aspose.Slides pada saat runtime. Anda dapat menginstal font tersebut di sistem operasi atau menyediakan sebagai [external font](/slides/id/androidjava/custom-font/) sehingga dapat berpartisipasi dalam proses pemilihan font normal selama rendering dan konversi.

Batasan ini khusus untuk rendering persamaan. Aturan penggantian font standar yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa ketika font asli tidak dapat diakses.

## **FAQ**

**Apa perbedaan antara penggantian font dan substitusi font?**  
[Replacement](/slides/id/androidjava/font-replacement/) adalah penimpaan paksa satu font dengan font lain di seluruh presentasi. Substitusi adalah aturan yang dipicu dalam kondisi tertentu, misalnya ketika font asli tidak tersedia, dan kemudian font cadangan yang ditentukan digunakan.

**Kapan tepatnya aturan substitusi diterapkan?**  
Aturan-aturan berpartisipasi dalam urutan [font selection](/slides/id/androidjava/font-selection-sequence/) standar yang dievaluasi selama pemuatan, rendering, dan konversi; jika font yang dipilih tidak tersedia, penggantian atau substitusi diterapkan.

**Apa perilaku default jika tidak ada penggantian maupun substitusi yang dikonfigurasi dan font tidak ada di sistem?**  
Perpustakaan akan mencoba memilih font sistem terdekat yang tersedia, mirip dengan perilaku PowerPoint.

**Bisakah saya menambahkan font eksternal khusus pada runtime untuk menghindari substitusi?**  
Ya. Anda dapat [add external fonts](/slides/id/androidjava/custom-font/) pada runtime sehingga perpustakaan mempertimbangkannya untuk pemilihan dan rendering, termasuk untuk konversi berikutnya.

**Apakah Aspose mendistribusikan font apa pun bersama perpustakaan?**  
Tidak. Aspose tidak mendistribusikan font berbayar atau gratis; Anda menambahkan dan menggunakan font atas kebijaksanaan dan tanggung jawab Anda sendiri.

**Apakah terdapat perbedaan perilaku substitusi di Windows, Linux, dan macOS?**  
Ya. Penemuan font dimulai dari direktori font sistem operasi. Set font default yang tersedia dan jalur pencarian berbeda di tiap platform, yang memengaruhi ketersediaan dan kebutuhan substitusi.

**Bagaimana sebaiknya saya menyiapkan lingkungan untuk meminimalkan substitusi tak terduga selama konversi batch?**  
Sinkronkan set font di seluruh mesin atau kontainer, [add the external fonts](/slides/id/androidjava/custom-font/) yang diperlukan untuk dokumen keluaran, dan [embed fonts](/slides/id/androidjava/embedded-font/) dalam presentasi bila memungkinkan sehingga font yang dipilih tersedia selama rendering.