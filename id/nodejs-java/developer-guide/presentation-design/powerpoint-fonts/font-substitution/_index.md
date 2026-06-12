---
title: "Konfigurasi Substitusi Font dalam Presentasi Menggunakan JavaScript"
linktitle: "Substitusi Font"
type: docs
weight: 70
url: /id/nodejs-java/font-substitution/
keywords:
- font
- font pengganti
- substitusi font
- ganti font
- penggantian font
- aturan substitusi
- aturan penggantian
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Aktifkan substitusi font optimal di Aspose.Slides untuk Node.js saat mengonversi presentasi PowerPoint & OpenDocument ke format file lain menggunakan JavaScript."
---
## **Ringkasan**

Penggantian font memungkinkan Aspose.Slides menggunakan font lain ketika font presentasi asli tidak tersedia selama proses render atau konversi. Anda dapat memeriksa font mana yang telah diganti dengan menggunakan metode `getSubstitutions` dari kelas `FontsManager`.

Aspose.Slides juga memungkinkan Anda mendefinisikan aturan penggantian font. Misalnya, Anda dapat menentukan bahwa font yang tidak dapat diakses harus diganti dengan font lain yang tersedia dan kemudian menerapkan aturan tersebut melalui manajer font presentasi.

## **Mengatur Aturan Penggantian Font**

Aspose.Slides memungkinkan Anda mengatur aturan untuk font yang menentukan apa yang harus dilakukan dalam kondisi tertentu (misalnya, ketika sebuah font tidak dapat diakses) dengan cara berikut:

1. Muat presentasi yang relevan.  
2. Muat font yang akan diganti.  
3. Muat font baru.  
4. Tambahkan aturan untuk penggantian.  
5. Tambahkan aturan ke koleksi aturan penggantian font presentasi.  
6. Hasilkan gambar slide untuk melihat efeknya.

Kode JavaScript berikut mendemonstrasikan proses penggantian font:

```javascript
// Memuat sebuah presentasi
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Memuat font sumber yang akan diganti
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Memuat font baru
    var destFont = new aspose.slides.FontData("Arial");
    // Menambahkan aturan font untuk penggantian font
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Menambahkan aturan ke koleksi aturan substitusi font
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Menambahkan koleksi aturan font ke daftar aturan
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // Font Arial akan digunakan menggantikan SomeRareFont ketika yang terakhir tidak dapat diakses
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Menyimpan gambar ke disk dalam format JPEG
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Anda mungkin ingin melihat [**Font Replacement**](/slides/id/nodejs-java/font-replacement/).  
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan penggantian font berpartisipasi dalam proses pemilihan font standar yang digunakan selama render dan konversi. Mereka cocok untuk skenario teks biasa di mana Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font lain yang tersedia sesuai aturan yang dikonfigurasi.

Namun, persamaan matematika Office memiliki batasan penting. Jika sebuah persamaan dibuat dengan **Cambria Math**, Aspose.Slides mungkin masih memerlukan font **Cambria Math** asli untuk menghitung dan merender tata letak persamaan dengan benar. Karena itu, mengganti **Cambria Math** dengan font matematika lain, seperti **STIX Two Math**, tidak didukung untuk perenderan persamaan dan masih dapat menghasilkan pengecualian yang menunjukkan bahwa **Cambria Math** diperlukan.

Untuk mengonversi presentasi semacam itu dengan berhasil, pastikan **Cambria Math** tersedia untuk Aspose.Slides pada waktu runtime. Anda dapat menginstal font tersebut di sistem operasi atau menyediakannya sebagai [external font](/slides/id/nodejs-java/custom-font/) sehingga dapat berpartisipasi dalam proses pemilihan font normal selama render dan konversi.

Batasan ini khusus untuk perenderan persamaan. Aturan penggantian font standar yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa ketika font asli tidak dapat diakses.

## **FAQ**

**Apa perbedaan antara penggantian font dan penggantian font (substitution)?**

[Replacement](/slides/id/nodejs-java/font-replacement/) adalah pemaksaan mengganti satu font dengan font lain di seluruh presentasi. Substitution adalah aturan yang aktif pada kondisi tertentu, misalnya ketika font asli tidak tersedia, dan kemudian font cadangan yang ditentukan digunakan.

**Kapan tepatnya aturan substitution diterapkan?**

Aturan-aturan berpartisipasi dalam urutan [font selection](/slides/id/nodejs-java/font-selection-sequence/) standar yang dievaluasi selama pemuatan, render, dan konversi; jika font yang dipilih tidak tersedia, penggantian atau substitution diterapkan.

**Apa perilaku default jika tidak ada penggantian maupun substitution yang dikonfigurasi dan font tidak ada di sistem?**

Perpustakaan akan mencoba memilih font sistem terdekat yang tersedia, mirip dengan perilaku PowerPoint.

**Bisakah saya menambahkan font eksternal khusus pada runtime untuk menghindari substitution?**

Ya. Anda dapat [add external fonts](/slides/id/nodejs-java/custom-font/) pada runtime sehingga perpustakaan mempertimbangkannya untuk pemilihan dan render, termasuk untuk konversi selanjutnya.

**Apakah Aspose mendistribusikan font apa pun bersama perpustakaan?**

Tidak. Aspose tidak mendistribusikan font berbayar atau gratis; Anda menambahkan dan menggunakan font atas kebijakan dan tanggung jawab Anda sendiri.

**Apakah ada perbedaan perilaku substitution pada Windows, Linux, dan macOS?**

Ya. Penemuan font dimulai dari direktori font sistem operasi. Set font default yang tersedia dan jalur pencarian berbeda di tiap platform, yang memengaruhi ketersediaan dan kebutuhan substitution.

**Bagaimana saya harus menyiapkan lingkungan untuk meminimalkan substitution yang tidak terduga selama konversi batch?**

Sinkronkan set font di semua mesin atau kontainer, [add the external fonts](/slides/id/nodejs-java/custom-font/) yang diperlukan untuk dokumen output, dan [embed fonts](/slides/id/nodejs-java/embedded-font/) dalam presentasi bila memungkinkan sehingga font yang dipilih tersedia selama render.