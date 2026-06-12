---
title: Menyematkan Font dalam Presentasi Menggunakan Java
linktitle: Menyematkan Font
type: docs
weight: 40
url: /id/java/embedded-font/
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
- Java
- Aspose.Slides
description: "Menyematkan font TrueType dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Java, memastikan rendering yang akurat di semua platform."
---
## **Pengantar**

**Font yang disematkan dalam PowerPoint** berguna ketika Anda ingin presentasi Anda tampil dengan benar saat dibuka di sistem atau perangkat apa pun. Jika Anda menggunakan font pihak ketiga atau non‑standar karena Anda berkreasi dengan pekerjaan Anda, maka Anda memiliki alasan lebih banyak untuk menyematkan font tersebut. Jika tidak (tanpa font yang disematkan), teks atau angka pada slide, tata letak, gaya, dll. dapat berubah atau menjadi kotak‑kotak yang membingungkan. 

Kelas [FontsManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontsManager), kelas [FontData](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontdata/) , kelas [Compress](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/) , dan antarmuka‑antarmukanya berisi sebagian besar properti dan metode yang Anda perlukan untuk bekerja dengan font yang disematkan dalam presentasi PowerPoint. 

## **Dapatkan dan Hapus Font yang Disematkan**

Aspose.Slides menyediakan metode [getEmbeddedFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (yang tersedia melalui kelas [FontsManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontsManager)) untuk memungkinkan Anda memperoleh (atau mengetahui) font yang disematkan dalam sebuah presentasi. Untuk menghapus font, metode [removeEmbeddedFont](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (yang tersedia melalui kelas yang sama) digunakan.

Kode Java ini menunjukkan cara mendapatkan dan menghapus font yang disematkan dari sebuah presentasi:

```java
// Membuat objek Presentation yang mewakili file presentasi
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Merender slide yang berisi frame teks yang menggunakan font "FunSized" yang disematkan
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Simpan gambar ke disk dalam format JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Mendapatkan semua font yang disematkan
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Menemukan font "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Menghapus font "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Merender presentasi; font "Calibri" diganti dengan yang sudah ada
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Simpan gambar ke disk dalam format JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Menyimpan presentasi tanpa font "Calibri" yang disematkan ke disk
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tambahkan Font yang Disematkan**

Dengan menggunakan enum [EmbedFontCharacters](https://reference.aspose.com/slides/id/java/com.aspose.slides/embedfontcharacters/) dan dua overload dari metode [addEmbeddedFont](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), Anda dapat memilih aturan (penyematan) yang diinginkan untuk menyematkan font dalam sebuah presentasi. Kode Java ini menunjukkan cara menyematkan dan menambahkan font ke sebuah presentasi:

```java
// Memuat presentasi
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // Menyimpan presentasi ke disk
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kompres Font yang Disematkan**

Untuk memungkinkan Anda mengompres font yang disematkan dalam sebuah presentasi dan mengurangi ukuran berkasnya, Aspose.Slides menyediakan metode [compressEmbeddedFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (yang tersedia melalui kelas [Compress](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/)).

Kode Java ini menunjukkan cara mengompres font PowerPoint yang disematkan:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa font tertentu dalam presentasi tetap akan digantikan saat rendering meskipun sudah disematkan?**

Periksa [informasi substitusi](/slides/id/java/font-substitution/) di font manager dan [aturan fallback/substitusi](/slides/id/java/fallback-font/): jika font tidak tersedia atau dibatasi, fallback akan digunakan.

**Apakah ada gunanya menyematkan font "sistem" seperti Arial/Calibri?**

Biasanya tidak—font tersebut hampir selalu tersedia. Namun untuk portabilitas penuh di lingkungan "tipis" (Docker, server Linux tanpa font yang dipasang sebelumnya), menyematkan font sistem dapat menghilangkan risiko substitusi yang tidak terduga.