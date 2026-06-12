---
title: Ekstraksi Teks Lanjutan dari Presentasi dalam JavaScript
linktitle: Ekstrak Teks
type: docs
weight: 90
url: /id/nodejs-java/extract-text-from-presentation/
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
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Dengan cepat mengekstrak teks dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js via Java. Ikuti panduan sederhana langkah demi langkah kami untuk menghemat waktu."
---
## **Gambaran Umum**

Mengekstrak teks dari presentasi adalah tugas yang umum namun penting bagi pengembang yang bekerja dengan konten slide. Baik Anda menangani file Microsoft PowerPoint dalam format PPT atau PPTX, maupun presentasi OpenDocument (ODP), mengakses dan mengambil data teks dapat menjadi krusial untuk analisis, otomatisasi, pengindeksan, atau tujuan migrasi konten.

Artikel ini memberikan panduan komprehensif tentang cara mengekstrak teks secara efisien dari berbagai format presentasi, termasuk PPT, PPTX, dan ODP, menggunakan Aspose.Slides untuk Node.js via Java. Anda akan mempelajari cara secara sistematis mengiterasi elemen presentasi untuk secara akurat mengambil konten teks yang Anda butuhkan.

## **Ekstrak Teks dari Slide**

Aspose.Slides untuk Node.js via Java menyediakan kelas SlideUtil. Kelas ini memberikan beberapa metode statis yang overload untuk mengekstrak semua teks dari sebuah presentasi atau slide. Untuk mengekstrak teks dari slide dalam sebuah presentasi, gunakan metode getAllTextBoxes. Metode ini menerima objek slide sebagai parameter. Ketika dijalankan, metode ini memindai seluruh slide untuk teks dan mengembalikan array objek TextFrame, mempertahankan semua format teks.

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ekstrak Teks dari Presentasi**

Untuk memindai teks dari seluruh presentasi, gunakan metode statis getAllTextFrames yang disediakan oleh kelas SlideUtil. Metode ini menerima dua parameter:

1. Pertama, objek Presentation yang merepresentasikan presentasi PowerPoint atau OpenDocument yang teksnya akan diekstrak.
2. Kedua, nilai `boolean` yang menunjukkan apakah master slide harus termasuk saat memindai teks dari presentasi.

Metode ini mengembalikan array objek TextFrame, termasuk informasi pemformatan teks. Kode di bawah ini memindai teks dan detail pemformatan dari sebuah presentasi, termasuk master slide.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ekstraksi Teks Terpadu dan Cepat**

Kelas PresentationFactory juga menyediakan metode untuk mengekstrak semua teks dari presentasi:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

Argumen enum TextExtractionArrangingMode menunjukkan mode pengorganisasian hasil ekstraksi teks dan dapat diatur ke nilai berikut:

- `Unarranged` - Teks mentah tanpa memperhatikan posisinya pada slide.
- `Arranged` - Teks diatur dalam urutan yang sama seperti pada slide.

Mode unarranged dapat digunakan ketika kecepatan menjadi kritis; ia lebih cepat dibandingkan mode arranged.

PresentationText merepresentasikan teks mentah yang diekstrak dari presentasi. Metode `getSlidesText`-nya mengembalikan array objek, masing-masing mewakili teks pada slide yang bersangkutan. Setiap objek teks slide memiliki metode berikut:

- `getText` mengembalikan teks dalam shape slide.
- `getMasterText` mengembalikan teks dalam shape master slide yang terkait dengan slide ini.
- `getLayoutText` mengembalikan teks dalam shape layout slide yang terkait dengan slide ini.
- `getNotesText` mengembalikan teks dalam shape catatan slide yang terkait dengan slide ini.
- `getCommentsText` mengembalikan teks dalam komentar yang terkait dengan slide ini.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **FAQ**

**Seberapa cepat Aspose.Slides memproses presentasi besar saat ekstraksi teks?**

Aspose.Slides dioptimalkan untuk kinerja tinggi dan dapat memproses bahkan [large presentations](/slides/id/nodejs-java/open-presentation/), menjadikannya cocok untuk skenario pemrosesan waktu nyata atau massal.

**Apakah Aspose.Slides dapat mengekstrak teks dari tabel dan diagram dalam presentasi?**

Ya. Aspose.Slides dapat mengekstrak teks dari banyak elemen slide, termasuk tabel dan objek terkait diagram, sehingga Anda dapat mengakses dan menganalisis konten teks dalam struktur presentasi yang umum.

**Apakah saya memerlukan lisensi khusus Aspose.Slides untuk mengekstrak teks dari presentasi?**

Anda dapat mengekstrak teks menggunakan versi percobaan gratis Aspose.Slides, meskipun akan memiliki [certain limitations](/slides/id/nodejs-java/licensing/), seperti memproses hanya sejumlah slide terbatas. Untuk penggunaan tanpa batas dan menangani presentasi yang lebih besar, disarankan membeli lisensi penuh.