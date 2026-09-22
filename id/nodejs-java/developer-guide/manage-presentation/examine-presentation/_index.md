---
title: Mendapatkan dan Memperbarui Informasi Presentasi dalam JavaScript
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/nodejs-java/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- mengambil properti
- membaca properti
- mengubah properti
- memodifikasi properti
- memperbarui properti
- memeriksa PPTX
- memeriksa PPT
- memeriksa ODP
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan JavaScript untuk wawasan yang lebih cepat dan audit konten yang lebih cerdas."
---
## **Gambaran Umum**

Aspose.Slides dapat mengidentifikasi format presentasi dan membaca metadata dokumen tanpa membuat model objek presentasi lengkap. Hal ini berguna ketika Anda perlu mengklasifikasikan file, membuat inventaris, atau memeriksa properti sebelum memutuskan apakah akan memuat dan memproses konten presentasi.

Artikel ini memperlihatkan inspeksi ringan melalui [PresentationFactory](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/) dan [PresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/), serta pembaruan terarah melalui [DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/).

## **Periksa Format Presentasi**

Jika Anda sudah memiliki presentasi yang dimuat, lihat [Determine the Original Presentation Format](/slides/id/nodejs-java/detect-presentation-source-format/) untuk deteksi setelah pemuatan dan keterbatasan aliran legacy PPT, PPS, dan POT.

Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/). Metode [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/getloadformat/) melaporkan format yang terdeteksi, seperti PPTX, PPT, atau ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Buat Inventaris Presentasi Ringan**

Saat Anda memproses banyak file presentasi, Anda mungkin memerlukan inventaris yang kompak untuk validasi, pengindeksan, atau sistem manajemen dokumen. Dalam skenario ini, gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) untuk memperoleh objek [PresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/), lalu panggil [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) untuk membaca metadata dokumen. Pendekatan ini tidak membuat instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) atau mengharuskan Anda menelusuri seluruh model objek presentasi.

Properti ekstended yang disediakan oleh [DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/) memberikan nilai inventaris berikut:

| Method | Inventory value |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#getSlides) | Total jumlah slide. |
| [getHiddenSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Jumlah slide tersembunyi. |
| [getNotes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#getNotes) | Jumlah slide yang memiliki catatan. |
| [getParagraphs](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Total jumlah paragraf, jika tersedia. |
| [getWords](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#getWords) | Total jumlah kata. |
| [getMultimediaClips](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Total jumlah klip audio dan video. |

Contoh berikut membaca nilai‑nilai ini tanpa membuat objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan mencetak inventaris yang kompak. Ia juga menggabungkan [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) dengan [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) untuk menampilkan grup konten seperti font, tema, dan judul slide.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Setiap [HeadingPair](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/headingpair/) menyediakan nama grup melalui [HeadingPair.getName](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/headingpair/#getName) dan jumlah item dalam grup tersebut melalui [HeadingPair.getCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) mengembalikan array datar yang terurut, jadi konsumsi jumlah judul berurutan yang ditentukan oleh setiap heading pair.

### **Metadata yang Disimpan dan Batasan Format**

Properti inventaris yang dikembalikan oleh [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) mencerminkan metadata yang tersedia di dokumen sumber. Aspose.Slides tidak memuat dan menelusuri model objek presentasi untuk menghitung ulang nilai‑nilai ini pada pemanggilan ini. Properti yang hilang diwakili oleh nilai default, dan nilai yang disimpan mungkin usang jika aplikasi yang terakhir menyimpan file tidak memperbarui properti dokumennya.

- **PPTX:** Format ini menyediakan properti dokumen ekstended untuk hitungan slide, catatan, slide tersembunyi, paragraf, kata, dan multimedia, serta heading pair dan judul bagian. Ketersediaannya tergantung pada properti mana yang ditulis oleh pembuat dokumen.
- **PPT:** Format biner dapat menyimpan properti ringkasan dokumen yang sesuai. Jika sebuah properti tidak ada atau tidak diperbarui oleh pembuat dokumen, Aspose.Slides mengembalikan nilai yang disimpan atau nilai default alih‑alih menghitungnya dari slide.
- **ODP:** Metadata OpenDocument menyediakan statistik umum dokumen, seperti hitungan halaman, paragraf, dan kata, namun nilai‑nilai ini tidak selalu berkorespondensi dengan setiap properti ekstended khusus PowerPoint. Metadata slide tersembunyi, catatan slide, multimedia, heading pair, dan judul bagian mungkin tidak tersedia, dan properti inventaris dapat mengembalikan nilai default. Jangan menganggap nilai nol atau array kosong sebagai bukti otoritatif bahwa konten terkait tidak ada.

Gunakan pendekatan metadata ringan untuk inventaris dan pemeriksaan awal. Muat presentasi dan inspeksi model objek hidupnya ketika hasil harus mencerminkan perubahan dalam memori atau saat Anda perlu memverifikasi konten presentasi yang sebenarnya.

## **Perbarui Properti Presentasi**

Properti yang dikembalikan oleh [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) juga dapat diubah tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/). Terapkan perubahan dengan [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), lalu tulis presentasi yang terikat menggunakan [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

Gambar berikut menunjukkan properti dokumen asli.

![Original document properties of the PowerPoint presentation](input_properties.png)

Contoh berikut mengubah judul dan waktu terakhir disimpan serta menulis hasilnya ke file baru:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

Gambar berikut menunjukkan properti dokumen yang telah diperbarui.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Tautan Berguna**

Untuk pemeriksaan keamanan terkait dan pengaturan perlindungan, lihat artikel berikut:

- [Password-Protect Presentations](/slides/id/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/id/nodejs-java/write-protected-presentation/)

## **FAQ**

**Bagaimana cara memeriksa apakah font tertanam dan yang mana?**

Muat presentasi dan gunakan [Presentation.getFontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getfontsmanager/). Panggil [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) untuk memperoleh font yang tertanam dan [FontsManager.getFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getfonts/) untuk memperoleh font yang digunakan oleh presentasi. Bandingkan kedua hasil untuk menemukan font yang diperlukan untuk merender tetapi tidak tertanam.

**Bagaimana cara cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Jika metadata dokumen yang disimpan sudah cukup, baca [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) melalui [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) dan [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Ini cocok untuk inventaris ringan. Jika presentasi telah dimodifikasi di memori, metadata yang disimpan mungkin hilang atau usang, atau Anda perlu memverifikasi nilai hidup, iterasikan melalui [Presentation.getSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getslides/) dan inspeksi metode [Slide.getHidden](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/gethidden/) pada setiap slide.

**Bisakah saya mendeteksi apakah ukuran slide khusus dan orientasi digunakan, serta apakah berbeda dari nilai default?**

Ya. Muat presentasi dan panggil [Presentation.getSlideSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getslidesize/). Gunakan [SlideSize.getType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesize/getsize/), dan [SlideSize.getOrientation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesize/getorientation/) untuk membandingkan pengaturan saat ini dengan preset dan dimensi yang diharapkan.

**Apakah ada cara cepat untuk melihat apakah diagram mengacu pada sumber data eksternal?**

Ya. Temukan setiap [Chart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/) dan panggil [ChartData.getDataSourceType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Untuk workbook eksternal, panggil [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Jenis sumber data dan jalur mengidentifikasi referensi eksternal, tetapi memverifikasi apakah target tersedia memerlukan pemeriksaan sumber daya terpisah.

**Bagaimana saya menilai slide “berat” yang mungkin memperlambat perenderan atau ekspor PDF?**

Tidak ada properti kompleksitas tunggal. Telusuri [Presentation.getSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getslides/) dan koleksi [BaseSlide.getShapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/#getShapes) pada setiap slide. Gunakan hitungan bentuk dan keberadaan gambar besar, efek, animasi, atau multimedia sebagai sinyal penyaringan, dan ukur perenderan atau ekspor representatif sebelum menganggap slide sebagai bottleneck kinerja yang terkonfirmasi.