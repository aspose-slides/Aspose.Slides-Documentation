---
title: Dapatkan Panggilan Balik Peringatan untuk Substitusi Font
type: docs
weight: 90
url: /id/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- panggilan balik peringatan
- substitusi font
- proses rendering
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara mendapatkan panggilan balik peringatan untuk substitusi font di Aspose.Slides untuk Java dan menampilkan presentasi PowerPoint dan OpenDocument secara akurat."
---
## **Pendahuluan**

Aspose.Slides for Java memungkinkan Anda menerima panggilan balik peringatan untuk substitusi font ketika font yang diperlukan tidak tersedia di mesin saat rendering. Panggilan balik ini membantu mendiagnosis masalah dengan font yang hilang atau tidak dapat diakses.

## **Aktifkan Panggilan Balik Peringatan**

Aspose.Slides for Java menyediakan API yang sederhana untuk menerima panggilan balik peringatan saat merender slide presentasi. Ikuti langkah-langkah berikut untuk mengonfigurasi panggilan balik peringatan:

1. Buat kelas panggilan balik khusus yang mengimplementasikan antarmuka [IWarningCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iwarningcallback/) untuk menangani peringatan.  
1. Atur panggilan balik peringatan menggunakan kelas opsi seperti [RenderingOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/htmloptions/), dan lain-lain.  
1. Muat presentasi yang menggunakan font yang tidak tersedia di mesin target.  
1. Hasilkan thumbnail slide atau ekspor presentasi untuk mengamati efeknya.

**Kelas Panggilan Balik Peringatan Khusus:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// Contoh output:
//
// Font akan disubstitusi dari XYZ ke {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Hasilkan Thumbnail Slide:**

```java
// Siapkan panggilan balik peringatan untuk menangani peringatan terkait font selama rendering slide.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// Muat presentasi dari jalur file yang ditentukan.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Hasilkan gambar thumbnail untuk setiap slide dalam presentasi.
    for (ISlide slide : presentation.getSlides()) {
        // Dapatkan gambar thumbnail slide menggunakan opsi rendering yang ditentukan.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**Ekspor ke Format PDF:**

```java
// Siapkan panggilan balik peringatan untuk menangani peringatan terkait font selama ekspor PDF.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// Muat presentasi dari jalur file yang ditentukan.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ekspor presentasi sebagai PDF.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**Ekspor ke Format HTML:**

```java
// Siapkan panggilan balik peringatan untuk menangani peringatan terkait font selama ekspor HTML.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// Muat presentasi dari jalur file yang ditentukan.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ekspor presentasi dalam format HTML.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```