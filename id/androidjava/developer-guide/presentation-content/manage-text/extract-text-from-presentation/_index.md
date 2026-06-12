---
title: Ekstraksi Teks Lanjutan dari Presentasi di Android
linktitle: Ekstrak Teks
type: docs
weight: 90
url: /id/androidjava/extract-text-from-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Dengan cepat mengekstrak teks dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android via Java. Ikuti panduan sederhana langkah demi langkah kami untuk menghemat waktu."
---
## **Ikhtisar**

Mengekstrak teks dari presentasi adalah tugas yang umum namun penting bagi pengembang yang bekerja dengan konten slide. Baik Anda menangani file Microsoft PowerPoint dalam format PPT atau PPTX, maupun presentasi OpenDocument (ODP), mengakses dan mengambil data tekstual dapat menjadi krusial untuk analisis, otomatisasi, pengindeksan, atau tujuan migrasi konten.

Artikel ini memberikan panduan komprehensif tentang cara mengekstrak teks secara efisien dari berbagai format presentasi, termasuk PPT, PPTX, dan ODP, menggunakan Aspose.Slides for Android via Java. Anda akan belajar bagaimana menelusuri elemen presentasi secara sistematis untuk mengambil konten teks yang dibutuhkan dengan akurat.

## **Mengekstrak Teks dari Slide**

Aspose.Slides for Android via Java menyediakan kelas [SlideUtil](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideutil/). Kelas ini menyediakan beberapa metode statis yang berlebih untuk mengekstrak semua teks dari sebuah presentasi atau slide. Untuk mengekstrak teks dari sebuah slide dalam presentasi, gunakan metode [getAllTextBoxes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Metode ini menerima objek berjenis [IBaseSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseslide/) sebagai parameter. Saat dijalankan, metode ini memindai seluruh slide untuk teks dan mengembalikan sebuah array objek berjenis [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/), mempertahankan semua format teks.

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

Untuk memindai teks dari seluruh presentasi, gunakan metode statis [getAllTextFrames](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) yang disediakan oleh kelas [SlideUtil](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideutil/). Metode ini menerima dua parameter:

1. Pertama, objek [IPresentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/) yang merepresentasikan presentasi PowerPoint atau OpenDocument dari mana teks akan diekstrak.
1. Kedua, nilai `boolean` yang menunjukkan apakah slide master harus disertakan saat memindai teks dari presentasi.

Metode ini mengembalikan sebuah array objek berjenis [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/), termasuk informasi pemformatan teks. Kode di bawah ini memindai teks dan detail pemformatannya dari sebuah presentasi, termasuk slide master.

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

## **Ekstraksi Teks Terklasifikasi dan Cepat**

Kelas [PresentationFactory](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationfactory/) juga menyediakan metode untuk mengekstrak semua teks dari presentasi:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Argumen enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textextractionarrangingmode/) menunjukkan mode pengaturan hasil ekstraksi teks dan dapat diatur ke nilai berikut:
- `Unarranged` – Teks mentah tanpa memperhatikan posisinya pada slide.
- `Arranged` – Teks diatur dalam urutan yang sama seperti pada slide.

Mode unarranged dapat digunakan ketika kecepatan menjadi faktor kritis; mode ini lebih cepat daripada mode arranged.

[IPresentationText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationtext/) merepresentasikan teks mentah yang diekstrak dari presentasi. Metode `getSlidesText`‑nya mengembalikan sebuah array objek berjenis [ISlideText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidetext/). Setiap objek merepresentasikan teks pada slide yang bersangkutan. Objek berjenis [ISlideText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidetext/) memiliki metode‑metode berikut:

- `getText` – Teks dalam bentuk pada slide.
- `getMasterText` – Teks dalam bentuk pada slide master yang terkait dengan slide ini.
- `getLayoutText` – Teks dalam bentuk pada slide tata letak yang terkait dengan slide ini.
- `getNotesText` – Teks dalam bentuk pada slide catatan yang terkait dengan slide ini.
- `getCommentsText` – Teks dalam komentar yang terkait dengan slide ini.

```java
String presentationPath = "presentation.pptx";
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

**Seberapa cepat Aspose.Slides memproses presentasi besar saat mengekstrak teks?**

Aspose.Slides dioptimalkan untuk kinerja tinggi dan dapat memproses bahkan [presentasi besar](/slides/id/androidjava/open-presentation/), menjadikannya cocok untuk skenario pemrosesan real‑time atau batch.

**Apakah Aspose.Slides dapat mengekstrak teks dari tabel dan diagram dalam presentasi?**

Ya. Aspose.Slides dapat mengekstrak teks dari banyak elemen slide, termasuk tabel dan objek terkait diagram, sehingga Anda dapat mengakses dan menganalisis konten tekstual dalam struktur presentasi yang umum.

**Apakah saya memerlukan lisensi khusus Aspose.Slides untuk mengekstrak teks dari presentasi?**

Anda dapat mengekstrak teks menggunakan versi percobaan gratis Aspose.Slides, meskipun akan memiliki [batasan tertentu](/slides/id/androidjava/licensing/), seperti pemrosesan hanya pada jumlah slide terbatas. Untuk penggunaan tanpa batasan dan menangani presentasi yang lebih besar, disarankan membeli lisensi penuh.