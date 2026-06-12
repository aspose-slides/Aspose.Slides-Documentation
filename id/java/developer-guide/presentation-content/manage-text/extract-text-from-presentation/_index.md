---
title: Ekstraksi Teks Lanjutan dari Presentasi di Java
linktitle: Ekstrak Teks
type: docs
weight: 90
url: /id/java/extract-text-from-presentation/
keywords:
- ekstrak teks
- ekstrak teks dari slide
- ekstrak teks dari presentasi
- ekstrak teks dari PowerPoint
- ekstrak teks dari OpenDocument
- ekstrak teks dari PPT
- ekstrak teks dari PPTX
- ekstrak teks dari ODP
- ambil teks
- ambil teks dari slide
- ambil teks dari presentasi
- ambil teks dari PowerPoint
- ambil teks dari OpenDocument
- ambil teks dari PPT
- ambil teks dari PPTX
- ambil teks dari ODP
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Ekstrak teks dengan cepat dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Java. Ikuti panduan sederhana langkah demi langkah kami untuk menghemat waktu."
---
## **Gambaran Umum**

Mengekstrak teks dari presentasi adalah tugas yang umum namun penting bagi pengembang yang bekerja dengan konten slide. Baik Anda menangani file Microsoft PowerPoint dalam format PPT atau PPTX, maupun presentasi OpenDocument (ODP), mengakses dan mengambil data teks dapat menjadi krusial untuk analisis, otomasi, pengindeksan, atau tujuan migrasi konten.

Artikel ini memberikan panduan komprehensif tentang cara mengekstrak teks secara efisien dari berbagai format presentasi, termasuk PPT, PPTX, dan ODP, menggunakan Aspose.Slides for Java. Anda akan belajar cara mengiterasi elemen presentasi secara sistematis untuk mengambil konten teks yang Anda butuhkan dengan akurat.

## **Mengekstrak Teks dari Slide**

Aspose.Slides for Java menyediakan kelas [SlideUtil](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideutil/). Kelas ini mengekspos beberapa metode statis yang di‑overload untuk mengekstrak semua teks dari sebuah presentasi atau slide. Untuk mengekstrak teks dari slide dalam sebuah presentasi, gunakan metode [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Metode ini menerima objek bertipe [IBaseSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/) sebagai parameter. Saat dijalankan, metode ini memindai seluruh slide untuk teks dan mengembalikan array objek bertipe [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/), mempertahankan semua pemformatan teks.

Potongan kode berikut mengekstrak semua teks dari slide pertama presentasi:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Mengekstrak Teks dari Presentasi**

Untuk memindai teks dari seluruh presentasi, gunakan metode statis [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) yang diekspos oleh kelas [SlideUtil](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideutil/). Metode ini menerima dua parameter:

1. Pertama, objek [IPresentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/) yang mewakili presentasi PowerPoint atau OpenDocument dari mana teks akan diekstrak.
1. Kedua, nilai `boolean` yang menunjukkan apakah slide master harus disertakan saat memindai teks dari presentasi.

Metode ini mengembalikan array objek bertipe [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/), termasuk informasi pemformatan teks. Kode di bawah ini memindai teks dan detail pemformatan dari sebuah presentasi, termasuk slide master.

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ekstraksi Teks yang Terklasifikasi dan Cepat**

Kelas [PresentationFactory](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationfactory/) juga menyediakan metode untuk mengekstrak semua teks dari presentasi:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Argumen enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/id/java/com.aspose.slides/textextractionarrangingmode/) menunjukkan mode pengorganisasian hasil ekstraksi teks dan dapat diatur ke nilai berikut:

- `Unarranged` - Teks mentah tanpa memperhatikan posisinya pada slide.
- `Arranged` - Teks diatur dalam urutan yang sama seperti pada slide.

Mode **Unarranged** dapat digunakan ketika kecepatan sangat penting; mode ini lebih cepat dibandingkan mode **Arranged**.

[IPresentationText](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationtext/) mewakili teks mentah yang diekstrak dari presentasi. Metode `getSlidesText`‑nya mengembalikan array objek bertipe [ISlideText](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidetext/). Setiap objek mewakili teks pada slide yang bersangkutan. Objek bertipe [ISlideText](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidetext/) memiliki metode berikut:

- `getText` - Teks dalam bentuk pada slide.
- `getMasterText` - Teks dalam bentuk pada slide master yang terkait dengan slide ini.
- `getLayoutText` - Teks dalam bentuk pada slide layout yang terkait dengan slide ini.
- `getNotesText` - Teks dalam bentuk pada slide catatan yang terkait dengan slide ini.
- `getCommentsText` - Teks dalam bentuk pada komentar yang terkait dengan slide ini.

```java
String presentationPath = "presentation.ppt";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **FAQ**

**Seberapa cepat Aspose.Slides memproses presentasi besar saat ekstraksi teks?**

Aspose.Slides dioptimalkan untuk kinerja tinggi dan dapat memproses bahkan [presentasi besar](/slides/id/java/open-presentation/), menjadikannya cocok untuk skenario pemrosesan real‑time atau dalam jumlah besar.

**Apakah Aspose.Slides dapat mengekstrak teks dari tabel dan grafik dalam presentasi?**

Ya. Aspose.Slides dapat mengekstrak teks dari banyak elemen slide, termasuk tabel dan objek terkait grafik, sehingga Anda dapat mengakses serta menganalisis konten teks dalam struktur presentasi yang umum.

**Apakah saya memerlukan lisensi khusus Aspose.Slides untuk mengekstrak teks dari presentasi?**

Anda dapat mengekstrak teks menggunakan versi trial gratis Aspose.Slides, meskipun akan memiliki [batasan tertentu](/slides/id/java/licensing/), seperti memproses hanya sejumlah slide terbatas. Untuk penggunaan tanpa batas dan untuk menangani presentasi yang lebih besar, disarankan membeli lisensi penuh.