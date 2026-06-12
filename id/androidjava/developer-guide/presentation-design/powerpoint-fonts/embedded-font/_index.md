---
title: Sematkan Font dalam Presentasi di Android
linktitle: Menanamkan Font
type: docs
weight: 40
url: /id/androidjava/embedded-font/
keywords:
- tambahkan font
- menanamkan font
- penanaman font
- dapatkan font tertanam
- tambahkan font tertanam
- hapus font tertanam
- kompres font tertanam
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Sematkan font TrueType dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Android melalui Java, memastikan render yang akurat di semua platform."
---
## **Pendahuluan**

**Font tertanam di PowerPoint** bermanfaat ketika Anda ingin presentasi Anda muncul dengan benar ketika dibuka di sistem atau perangkat apa pun. Jika Anda menggunakan font pihak ketiga atau non‑standar karena berkreasi dengan karya Anda, maka Anda memiliki alasan lebih untuk menanamkan font Anda. Jika tidak (tanpa font tertanam), teks atau angka pada slide Anda, tata letak, gaya, dll. dapat berubah atau menjadi persegi panjang yang membingungkan. 

Kelas [FontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontsManager), kelas [FontData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontdata/), kelas [Compress](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/) , dan interfacenya berisi sebagian besar properti dan metode yang Anda perlukan untuk bekerja dengan font tertanam dalam presentasi PowerPoint.

## **Dapatkan dan Hapus Font Tertanam**

Aspose.Slides menyediakan metode [getEmbeddedFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (yang diakses melalui kelas [FontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontsManager)) untuk memungkinkan Anda mendapatkan (atau mengetahui) font yang tertanam dalam sebuah presentasi. Untuk menghapus font, metode [removeEmbeddedFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (yang diakses melalui kelas yang sama) digunakan.

Kode Java berikut menunjukkan cara mendapatkan dan menghapus font tertanam dari sebuah presentasi:

```java
// Membuat objek Presentation yang mewakili berkas presentasi
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Merender slide yang berisi bingkai teks yang menggunakan "FunSized" tertanam
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Simpan gambar ke disk dalam format JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Mendapatkan semua font yang tertanam
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Mencari font "Calibri"
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

    // Merender presentasi; "Calibri" font diganti dengan yang sudah ada
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Simpan gambar ke disk dalam format JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Menyimpan presentasi tanpa font "Calibri" yang tertanam ke disk
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tambahkan Font Tertanam**

Dengan menggunakan enum [EmbedFontCharacters](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/embedfontcharacters/) dan dua overload metode [addEmbeddedFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), Anda dapat memilih aturan (penanaman) yang Anda sukai untuk menanamkan font dalam sebuah presentasi. Kode Java berikut menunjukkan cara menanamkan dan menambahkan font ke sebuah presentasi:

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

## **Kompres Font Tertanam**

Untuk memungkinkan Anda mengompres font yang tertanam dalam sebuah presentasi dan mengurangi ukuran berkasnya, Aspose.Slides menyediakan metode [compressEmbeddedFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (yang diakses melalui kelas [Compress](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/)).

Kode Java berikut menunjukkan cara mengompres font PowerPoint yang tertanam:

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

**Bagaimana saya dapat mengetahui bahwa font tertentu dalam presentasi masih akan digantikan selama proses render meskipun sudah ditanamkan?**

Periksa informasi substitusi di pengelola font dan aturan [fallback/substitution rules](/slides/id/androidjava/fallback-font/): jika font tidak tersedia atau dibatasi, fallback akan digunakan.

**Apakah layak menanamkan font "sistem" seperti Arial/Calibri?**

Biasanya tidak—font tersebut hampir selalu tersedia. Namun untuk portabilitas penuh di lingkungan "tipis" (Docker, server Linux tanpa font yang terpasang sebelumnya), menanamkan font sistem dapat menghilangkan risiko substitusi yang tidak terduga.