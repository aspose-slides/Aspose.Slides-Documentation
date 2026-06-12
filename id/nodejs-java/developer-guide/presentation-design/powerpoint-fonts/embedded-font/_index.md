---
title: "Menyematkan Font dalam Presentasi Menggunakan JavaScript"
linktitle: "Menyematkan Font"
type: docs
weight: 40
url: /id/nodejs-java/embedded-font/
keywords:
- "menambahkan font"
- "menyematkan font"
- "penyematan font"
- "mengambil font yang disematkan"
- "menambahkan font yang disematkan"
- "menghapus font yang disematkan"
- "mengompres font yang disematkan"
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Menyematkan font TrueType dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Node.js via Java, memastikan rendering yang akurat di semua platform."
---
## **Pendahuluan**

**Font yang disematkan di PowerPoint** berguna ketika Anda ingin presentasi Anda tampil dengan benar saat dibuka di sistem atau perangkat apa pun. Jika Anda menggunakan font pihak ketiga atau non‑standar karena Anda berkreasi dengan pekerjaan Anda, maka Anda memiliki alasan lebih untuk menyematkan font tersebut. Sebaliknya (tanpa font yang disematkan), teks atau angka pada slide, tata letak, gaya, dll. dapat berubah atau menjadi kotak‑kotak yang membingungkan. 

Kelas [FontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontsManager), kelas [FontData](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontdata/), kelas [Compress](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/) dan kelas‑kelas mereka berisi sebagian besar properti dan metode yang Anda butuhkan untuk bekerja dengan font yang disematkan dalam presentasi PowerPoint.

## **Dapatkan atau Hapus Font yang Disematkan dari Presentasi**

Aspose.Slides menyediakan metode [getEmbeddedFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (yang dipaparkan oleh kelas [FontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontsManager)) untuk memungkinkan Anda mendapatkan (atau mengetahui) font yang disematkan dalam sebuah presentasi. Untuk menghapus font, metode [removeEmbeddedFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (yang dipaparkan oleh kelas yang sama) digunakan.

Kode JavaScript ini menunjukkan cara mendapatkan dan menghapus font yang disematkan dari sebuah presentasi:

```javascript
// Membuat objek Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Membuat gambar slide yang berisi frame teks yang menggunakan font "FunSized" yang disematkan
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Menyimpan gambar ke disk dalam format JPEG
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Mengambil semua font yang disematkan
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Mencari font "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Menghapus font "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Membuat gambar presentasi; font "Calibri" diganti dengan font yang ada
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Menyimpan gambar ke disk dalam format JPEG
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Menyimpan presentasi tanpa font "Calibri" yang disematkan ke disk
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tambah Font yang Disematkan ke Presentasi**

Dengan menggunakan enum [EmbedFontCharacters](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/embedfontcharacters/) dan dua overload dari metode [addEmbeddedFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-), Anda dapat memilih aturan (penyematan) yang Anda sukai untuk menyematkan font dalam sebuah presentasi. Kode JavaScript ini menunjukkan cara menyematkan dan menambah font ke sebuah presentasi:

```javascript
// Memuat presentasi
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Menyimpan presentasi ke disk
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kompresi Font yang Disematkan**

Untuk memungkinkan Anda mengompres font yang disematkan dalam sebuah presentasi dan mengurangi ukuran berkasnya, Aspose.Slides menyediakan metode [compressEmbeddedFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (yang dipaparkan oleh kelas [Compress](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/)).

Kode JavaScript ini menunjukkan cara mengompres font PowerPoint yang disematkan:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Bagaimana saya bisa mengetahui bahwa font tertentu dalam presentasi masih akan digantikan selama rendering meskipun sudah disematkan?**

Periksa [informasi substitusi](/slides/id/nodejs-java/font-substitution/) di font manager dan [aturan fallback/substitusi](/slides/id/nodejs-java/fallback-font/): jika font tidak tersedia atau dibatasi, fallback akan digunakan.

**Apakah layak menyematkan font "sistem" seperti Arial/Calibri?**

Biasanya tidak—mereka hampir selalu tersedia. Namun untuk portabilitas penuh di lingkungan "tipis" (Docker, server Linux tanpa font yang diinstal sebelumnya), menyematkan font sistem dapat menghilangkan risiko substitusi yang tidak terduga.