---
title: Mengonfigurasi Substitusi Font dalam Presentasi dengan Java
linktitle: Penggantian Font
type: docs
weight: 70
url: /id/java/font-substitution/
keywords:
- font
- ganti font
- substitusi font
- ganti font
- penggantian font
- aturan substitusi
- aturan penggantian
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Aktifkan substitusi font optimal di Aspose.Slides untuk Java saat mengonversi presentasi PowerPoint & OpenDocument ke format file lain."
---
## **Gambaran Umum**

Penggantian font memungkinkan Aspose.Slides menggunakan font lain ketika font presentasi asli tidak tersedia selama proses render atau konversi. Anda dapat memeriksa font mana yang telah diganti dengan menggunakan metode `getSubstitutions` dari antarmuka `IFontsManager`.

Aspose.Slides juga memungkinkan Anda mendefinisikan aturan penggantian font. Misalnya, Anda dapat menentukan bahwa font yang tidak dapat diakses harus diganti dengan font lain yang tersedia dan kemudian menerapkan aturan tersebut melalui pengelola font presentasi.

## **Mengatur Aturan Penggantian Font**

Aspose.Slides memungkinkan Anda mengatur aturan untuk font yang menentukan apa yang harus dilakukan dalam kondisi tertentu (misalnya, ketika sebuah font tidak dapat diakses) dengan cara berikut:

1. Muat presentasi yang relevan.
2. Muat font yang akan diganti.
3. Muat font baru.
4. Tambahkan aturan untuk penggantian.
5. Tambahkan aturan ke koleksi aturan penggantian font presentasi.
6. Hasilkan gambar slide untuk melihat efeknya.

Kode Java ini menunjukkan proses penggantian font:

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
Anda mungkin ingin melihat [**Penggantian Font**](/slides/id/java/font-replacement/). 
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan penggantian font berpartisipasi dalam proses pemilihan font standar yang digunakan selama render dan konversi. Mereka cocok untuk skenario teks biasa dimana Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font lain yang tersedia sesuai aturan yang dikonfigurasi.

Namun, persamaan matematika Office memiliki batasan penting. Jika sebuah persamaan dibuat dengan **Cambria Math**, Aspose.Slides mungkin masih memerlukan font **Cambria Math** asli untuk menghitung dan merender tata letak persamaan dengan benar. Karena itu, mengganti **Cambria Math** dengan font matematika lain, seperti **STIX Two Math**, tidak didukung untuk perenderan persamaan dan masih dapat menghasilkan pengecualian yang menunjukkan bahwa **Cambria Math** diperlukan.

Untuk mengonversi presentasi tersebut dengan sukses, pastikan **Cambria Math** tersedia untuk Aspose.Slides pada waktu berjalan. Anda dapat menginstal font di sistem operasi atau menyediakan sebagai [font eksternal](/slides/id/java/custom-font/) sehingga dapat berpartisipasi dalam proses pemilihan font normal selama render dan konversi.

Batasan ini khusus untuk perenderan persamaan. Aturan penggantian font standar yang dijelaskan di atas masih berlaku untuk teks presentasi biasa ketika font asli tidak dapat diakses.

## **FAQ**

**Apa perbedaan antara penggantian font dan substitusi font?**

[Penggantian](/slides/id/java/font-replacement/) adalah pemaksaan mengganti satu font dengan font lain di seluruh presentasi. Substitusi adalah aturan yang dipicu di kondisi tertentu, misalnya ketika font asli tidak tersedia, dan kemudian font cadangan yang ditentukan digunakan.

**Kapan tepatnya aturan substitusi diterapkan?**

Aturan-aturan berpartisipasi dalam urutan [pemilihan font](/slides/id/java/font-selection-sequence/) standar yang dievaluasi selama pemuatan, render, dan konversi; jika font yang dipilih tidak tersedia, penggantian atau substitusi diterapkan.

**Apa perilaku default jika tidak ada penggantian maupun substitusi yang dikonfigurasi dan font tidak ada di sistem?**

Perpustakaan akan mencoba memilih font sistem terdekat yang tersedia, mirip dengan cara PowerPoint berperilaku.

**Apakah saya dapat melampirkan font eksternal khusus pada waktu berjalan untuk menghindari substitusi?**

Ya. Anda dapat [menambahkan font eksternal](/slides/id/java/custom-font/) pada waktu berjalan sehingga perpustakaan mempertimbangkannya untuk pemilihan dan render, termasuk untuk konversi selanjutnya.

**Apakah Aspose mendistribusikan font apa pun dengan perpustakaan?**

Tidak. Aspose tidak mendistribusikan font berbayar atau gratis; Anda menambahkan dan menggunakan font atas kebijaksanaan dan tanggung jawab Anda sendiri.

**Apakah ada perbedaan dalam perilaku substitusi pada Windows, Linux, dan macOS?**

Ya. Penemuan font dimulai dari direktori font sistem operasi. Set font default yang tersedia dan jalur pencarian berbeda di tiap platform, yang memengaruhi ketersediaan dan kebutuhan substitusi.

**Bagaimana saya harus menyiapkan lingkungan untuk meminimalkan substitusi tak terduga selama konversi batch?**

Sinkronkan set font antar mesin atau kontainer, [tambahkan font eksternal](/slides/id/java/custom-font/) yang diperlukan untuk dokumen keluaran, dan [sematkan font](/slides/id/java/embedded-font/) dalam presentasi bila memungkinkan sehingga font yang dipilih tersedia selama render.