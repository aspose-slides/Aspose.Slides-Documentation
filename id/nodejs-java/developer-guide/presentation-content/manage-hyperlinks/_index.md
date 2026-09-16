---
title: Kelola Hyperlink Presentasi dalam JavaScript
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/nodejs-java/manage-hyperlinks/
keywords:
- menambah URL
- menambah hyperlink
- membuat hyperlink
- memformat hyperlink
- menghapus hyperlink
- memperbarui hyperlink
- hyperlink teks
- hyperlink slide
- hyperlink bentuk
- hyperlink gambar
- hyperlink video
- hyperlink dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Menambahkan, memformat, memperbarui, dan menghapus hyperlink dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Node.js melalui Java, menggunakan contoh JavaScript."
---
## **Pendahuluan**

Sebuah hyperlink menghubungkan konten presentasi ke situs web atau lokasi di dalam presentasi. Di PowerPoint, hyperlink biasanya melayani dua tujuan:

* Membuka situs web dari teks, bentuk, atau bingkai media.
* Menavigasi ke slide lain, misalnya, dari daftar isi.

Aspose.Slides for Node.js via Java memungkinkan Anda menambahkan tautan ini, mengontrol tampilan dan suaranya, memperbarui propertinya, dan menghapusnya. Contoh di bawah ini menunjukkan cara bekerja dengan hyperlink pada elemen individu dan cara mengakses hyperlink pada level presentasi, slide, atau bingkai teks.

{{% alert color="info" title="Catatan" %}}
Anda juga dapat mengedit presentasi dengan [editor Aspose PowerPoint online gratis](https://products.aspose.app/slides/id/editor).
{{% /alert %}} 

## **Menambahkan Hyperlink URL**

Anda dapat menetapkan URL situs web ke teks, bentuk, atau bingkai media. Elemen tempat Anda menetapkan hyperlink menentukan area yang dapat diklik: bagian teks menautkan teks yang dipilih, sementara bentuk atau bingkai menautkan objek slide.

### **Menambahkan Hyperlink URL ke Teks**

Untuk menautkan teks ke situs web, berikan sebuah [Hyperlink](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink) ke metode [setHyperlinkClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) pada bagian teks, seperti ditunjukkan di bawah. Hanya bagian teks itu yang menjadi dapat diklik.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Menambahkan Hyperlink URL ke Bentuk dan Bingkai Media**

Untuk membuat bentuk atau bingkai dapat diklik, panggil metode [setHyperlinkClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#setHyperlinkClick) pada bentuk atau bingkai tersebut. Hyperlink menjadi milik objek itu sendiri, bukan bagian teks di dalamnya.

Pendekatan yang sama berlaku untuk bingkai gambar, audio, dan video: tetapkan hyperlink ke bingkai dan panggil [setTooltip](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setTooltip) bila diperlukan.

Contoh berikut membuat sebuah persegi panjang dapat diklik:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gunakan Hyperlink untuk Membuat Daftar Isi**

Hyperlink internal memungkinkan pembaca melompat dari daftar isi ke slide tertentu. Contoh berikut menggunakan [setInternalHyperlinkClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) untuk menautkan teks “Page 2” pada slide pertama ke slide kedua.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Memformat Hyperlink**

### **Warna**

Metode [setColorSource](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setColorSource) pada [Hyperlink](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink) menentukan apakah hyperlink menggunakan warna hyperlink presentasi atau format bagian teks. Untuk menerapkan warna teks khusus, pilih [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkColorSource) dan atur warna isian bagian. Fitur ini diperkenalkan di PowerPoint 2019; versi yang lebih lama tidak menerapkan pengaturan ini.

Contoh berikut menambahkan dua hyperlink teks ke slide yang sama. Yang pertama menggunakan isian teks merah, sementara yang kedua tetap menggunakan warna hyperlink default.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Suara**

Sebuah hyperlink dapat memutar suara saat diaktifkan atau menghentikan suara yang sedang diputar. Gunakan metode berikut untuk mengonfigurasi perilaku ini:

- [Hyperlink.setSound](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setSound) menentukan audio yang terkait dengan hyperlink.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) mengontrol apakah mengaktifkan hyperlink menghentikan suara sebelumnya.

#### **Menambahkan Suara Hyperlink**

Contoh berikut memuat `sampleaudio.wav` dan mengaitkannya dengan tombol pada slide pertama. Mengklik tombol memutar suara dan menavigasi ke slide berikutnya. Bentuk kedua pada slide tersebut menghentikan suara sebelumnya saat diklik, tanpa melakukan tindakan navigasi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Mengekstrak Suara Hyperlink**

Contoh berikut membuka presentasi yang dibuat di atas dan membaca audio hyperlink bentuk pertama ke memori melalui [getSound](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#getSound) dan [getBinaryData](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Audio#getBinaryData).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Pengaturan Tooltip dan Interaksi**

Anda dapat memanggil metode [Hyperlink](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink) berikut setelah menetapkan hyperlink ke teks atau bentuk:

- [setTooltip](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setTooltip) menetapkan teks yang dapat ditampilkan penonton sebagai petunjuk untuk tautan.
- [setTargetFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) menentukan bingkai target dalam set bingkai HTML induk, bila berlaku.
- [setHistory](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setHistory) mengontrol apakah mengaktifkan tautan menambahkan destinasinya ke daftar hyperlink yang telah dilihat.
- [setHighlightClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) mengontrol apakah hyperlink disorot ketika diklik.

## **Menghapus Hyperlink dari Presentasi**

Gunakan [getAnyHyperlinks](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) untuk mengumpulkan kontainer hyperlink, termasuk tautan bagian teks, sebelum mengubahnya. Contoh berikut menghapus kedua jenis aktivasi dari slide pertama. Untuk menghapus hanya satu tipe, panggil hanya [removeHyperlinkClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) atau [removeHyperlinkMouseOver](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); menghapus aksi klik tidak menghapus pasangan mouse-over‑nya.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Untuk penghapusan tak bersyarat, [removeAllHyperlinks](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) menghapus kedua jenis aktivasi dalam lingkup yang dipilih dalam satu panggilan. Untuk pembersihan selektif dan cakupan master, layout, serta catatan, lihat [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Membangun Inventaris Hyperlink Lengkap**

Sebelum mendistribusikan presentasi, inventarisasikan tindakan interaktif serta tautan webnya. [getAnyHyperlinks](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) mengembalikan kontainer hyperlink, bukan daftar datar string URL. Periksa baik [getHyperlinkClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getHyperlinkClick) maupun [getHyperlinkMouseOver](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) pada setiap kontainer. Kedua metode bersifat independen: kontainer yang sama dapat mengekspos kedua aksi, sehingga laporan lengkap memerlukan hingga dua baris per kontainer.

Pemindaian hanya hyperlink tingkat bentuk dapat melewatkan tautan yang terpasang pada bagian teks. Kuery lingkup yang tepat sebagai gantinya, dan simpan kontainer yang dikembalikan sehingga Anda dapat memperbarui atau menghapus aksi mereka kemudian.

### **Kueri Lingkup Presentasi, Slide, dan Bingkai Teks**

Kelas [HyperlinkQueries](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries) tersedia melalui [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries), dan [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Setiap lingkup mendukung kueri yang sama:

- [getHyperlinkClicks](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) mengembalikan kontainer dengan aksi klik.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) mengembalikan kontainer dengan aksi mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) mengembalikan kontainer dengan salah satu atau kedua aksi.

Contoh berikut membuat `hyperlink-audit-input.pptx` dengan tautan klik eksternal, tautan mouse‑over file, navigasi slide internal, tautan mouse‑over teks, dan aksi makro. Contoh ini tidak mengeksekusi aksi apa pun. Ketiga kueri yang sama berfungsi pada setiap lingkup; hitungan menggambarkan kontainer, bukan total aksi. Lingkup bingkai teks mengecualikan tautan milik bentuk yang membungkusnya.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk contoh ini, kueri presentasi dan slide masing‑masing melaporkan tiga kontainer klik, dua kontainer mouse‑over, dan tiga kontainer dengan salah satu aksi. Kueri bingkai teks melaporkan satu kontainer di setiap kategori.

### **Klasifikasikan Aksi dan Destinasi**

Gunakan [Hyperlink.getActionType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#getActionType) untuk menginterpretasikan aksi sebelum menafsirkan destinasi. Nilai [HyperlinkActionType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkActionType) mencakup lebih dari sekadar navigasi web:

| Nilai | Makna untuk audit |
| --- | --- |
| `Hyperlink` | Hyperlink eksternal; periksa URL dan skemanya. |
| `JumpSpecificSlide` | Navigasi internal ke slide tertentu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigasi bawaan presentasi, diselesaikan dalam konteks slideshow. |
| `JumpEndShow`, `StartCustomSlideShow` | Mengakhiri pertunjukan saat ini atau memulai pertunjukan khusus. |
| `StartMacro` | Menjalankan makro. |
| `StartProgram` | Meluncurkan program. |
| `OpenFile`, `OpenPresentation` | Membuka file atau presentasi lain; tinjau terpisah dari URL web. |
| `StartStopMedia` | Memulai atau menghentikan pemutaran media. |
| `NoAction`, `Unknown` | Tidak ada aksi navigasi, atau aksi yang tidak dikenali yang memerlukan tinjauan. |

Baca destinasi eksternal melalui [getExternalUrl](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) dan destinasi internal spesifik melalui [getTargetSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Aksi internal dan perintah bawaan mungkin tidak memiliki URL eksternal; URL kosong tidak berarti kontainer tidak memiliki aksi. Simpan nilai yang dikembalikan oleh [getExternalUrlOriginal](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) bila berbeda dari URL normalisasi, dan sertakan tooltip yang dikembalikan oleh [getTooltip](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#getTooltip) bila tersedia.

### **Lapor, Sanitasi, dan Verifikasi Hyperlink**

Contoh JavaScript berikut membaca presentasi yang ada (gunakan file yang dibuat di atas), menulis `hyperlink-audit.json`, menerapkan kebijakan, menyimpan `hyperlink-sanitized.pptx`, dan membukanya kembali untuk memeriksa kembali kedua jenis aktivasi. Ia mengumpulkan kontainer sebelum mengubahnya dan menggunakan kesetaraan referensi untuk menghindari pemrosesan kontainer yang sama dua kali. Kueri presentasi mencakup slide biasa; untuk inventaris seluruh paket, ia juga secara eksplisit mengkueri master, layout, catatan, serta master catatan dan handout bila ada.

Laporan mencatat indeks slide berbasis satu dan [getSlideId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/BaseSlide#getSlideId) bila tersedia. [getSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getSlide) menyediakan slide pemilik untuk kontainer yang didukung. Master, layout, dan catatan tidak memiliki indeks slide biasa dan diidentifikasi berdasarkan lingkupnya. Kontainer bentuk dan kontainer format bagian teks diberi label terpisah; tipe kontainer lainnya mempertahankan nama tipe runtime-nya. Setiap kontainer mendapatkan ID lokal laporan sehingga dua aksinya dapat dikorelasikan. Laporan menyimpan tipe aksi sebagai konstanta integer yang didefinisikan oleh enumerasi HyperlinkActionType.

Kebijakan aplikasi yang sengaja restriktif ini hanya mengizinkan URL HTTPS absolut dan target slide internal yang valid. Ia menolak makro, program, aksi file, aksi slideshow lain, aksi tidak dikenal, dan skema URL lain. Penolakan ini merupakan keputusan kebijakan, bukan penilaian keamanan Aspose.Slides. HTTPS saja tidak menjamin kepercayaan: tambahkan daftar putih host dan pemeriksaan lain untuk aplikasi Anda. Baik URL eksternal asli maupun yang dinormalisasi diperiksa. Contoh ini mengaudit metadata tanpa mengikuti tautan atau menjalankan aksi.

Untuk perbaikan, [getHyperlinkManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getHyperlinkManager) pada kontainer mendukung [setExternalHyperlinkClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick), dan [removeHyperlinkMouseOver](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Di sini, tautan klik eksternal yang dilarang diganti dengan halaman landasan HTTPS tetap; klik yang dilarang lainnya dan aksi mouse‑over yang dilarang dihapus secara independen. Atur `replaceExternalClicks` menjadi `false` untuk menghapus semua pelanggaran kebijakan. Pilih halaman pengganti milik aplikasi sebelum penyebaran.

Flag ekspor laporan menggunakan kebijakan peninjauan PDF yang konservatif: beri flag pada aksi mouse‑over dan apa pun selain tautan eksternal atau loncatan slide spesifik sebagai potensi tidak didukung. Itu hanya petunjuk peninjauan, bukan tes kemampuan atau jaminan bahwa tautan yang tidak di‑flag akan bertahan pada ekspor. Ekspor [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/) yang didukung mungkin mempertahankan hyperlink, tergantung pada aksi, opsi ekspor, dan penampil. Gambar raster [images](/slides/id/nodejs-java/convert-powerpoint-to-png/) dan [video](/slides/id/nodejs-java/convert-powerpoint-to-video/) tidak dapat mempertahankan hyperlink interaktif; beri flag setiap aksi saat audit untuk output tersebut.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Dengan input yang dibuat di atas, laporan berisi lima baris aksi. Tautan mouse‑over file dan klik makro dihapus, sementara tautan HTTPS dan navigasi slide internal tetap. Verifikasi mencetak nol aksi terlarang. Input yang berisi URL klik eksternal terlarang juga menguji cabang penggantian. Kontainer dengan klik yang diizinkan dan mouse‑over terlarang mempertahankan aksi kliknya.

Pembersihan selektif ini berbeda dari [removeAllHyperlinks](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), yang menghapus kedua jenis aktivasi di seluruh lingkup terpilih tanpa memperhatikan kebijakan. Verifikasi di sini hanya memeriksa aksi hyperlink; ia tidak menghapus proyek VBA yang tertanam, objek OLE, atau konten aktif lainnya, dan tidak memvalidasi file PDF atau HTML yang diekspor.

## **FAQ**

**Bagaimana cara menautkan ke sebuah bagian atau slide pertamanya?**

Bagian di PowerPoint mengelompokkan slide, tetapi hyperlink internal menargetkan slide individu. Untuk membuat navigasi ke sebuah bagian, tautkan ke slide pertama dalam bagian tersebut.

**Apakah saya dapat menempelkan hyperlink pada elemen master slide sehingga berfungsi pada semua slide?**

Ya. Elemen master slide dan layout mendukung hyperlink. Tautan pada elemen ini tersedia selama presentasi pada slide yang menggunakan master atau layout bersangkutan.

**Apakah hyperlink akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Ekspor PDF dan HTML yang didukung mungkin mempertahankan hyperlink; gambar raster dan video tidak dapat. Lihat pertimbangan ekspor di [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).