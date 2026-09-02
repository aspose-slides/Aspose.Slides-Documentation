---
title: Mengambil dan Memperbarui Informasi Presentasi di Android
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan Java untuk wawasan yang lebih cepat dan audit konten yang lebih cerdas."
---
## **Gambaran Umum**

Aspose.Slides dapat mengidentifikasi format presentasi dan membaca metadata dokumen tanpa membuat model objek presentasi yang lengkap. Hal ini berguna ketika Anda perlu mengklasifikasikan file, membuat inventaris, atau memeriksa properti sebelum memutuskan apakah akan memuat dan memproses konten presentasi.

Artikel ini menunjukkan inspeksi ringan melalui [PresentationFactory](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationfactory/) dan [IPresentationInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/), serta pembaruan terarah melalui [IDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idocumentproperties/).

## **Periksa Format Presentasi**

Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Metode [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) melaporkan format yang terdeteksi, seperti PPTX, PPT, atau ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Bangun Inventaris Presentasi Ringan**

Ketika Anda memproses banyak file presentasi, Anda mungkin memerlukan inventaris yang kompak untuk validasi, pengindeksan, atau sistem manajemen dokumen. Dalam skenario ini, gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) untuk memperoleh objek [IPresentationInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/), lalu panggil [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) untuk membaca metadata dokumen. Pendekatan ini tidak membuat instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) atau mengharuskan Anda menelusuri model objek presentasi secara lengkap.

Properti tambahan yang disediakan oleh [IDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idocumentproperties/) memberikan nilai inventaris berikut:

| Metode | Nilai inventaris |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Total jumlah slide. |
| [getHiddenSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Jumlah slide tersembunyi. |
| [getNotes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Jumlah slide yang berisi catatan. |
| [getParagraphs](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Total jumlah paragraf, jika tersedia. |
| [getWords](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Total jumlah kata. |
| [getMultimediaClips](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Total jumlah klip audio dan video. |

Contoh berikut membaca nilai‑nilai ini tanpa membuat objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan mencetak inventaris yang kompak. Ini juga menggabungkan [getHeadingPairs](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) dengan [getTitlesOfParts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) untuk menampilkan grup konten seperti font, tema, dan judul slide.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Setiap [IHeadingPair](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iheadingpair/) menyediakan nama grup dan jumlah item dalam grup tersebut. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) mengembalikan array datar yang terurut, sehingga konsumsi jumlah judul berurutan yang ditentukan oleh setiap heading pair.

### **Metadata Tersimpan dan Batasan Format**

Properti inventaris yang dikembalikan oleh [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) mencerminkan metadata yang tersedia dalam dokumen sumber. Aspose.Slides tidak memuat dan menelusuri model objek presentasi untuk menghitung ulang nilai‑nilai ini pada pemanggilan ini. Properti yang tidak ada direpresentasikan oleh nilai default, dan nilai‑nilai yang disimpan dapat menjadi usang jika aplikasi yang terakhir menyimpan file tidak memperbarui properti dokumennya.

- **PPTX:** Format ini menyediakan properti dokumen tambahan untuk hitungan slide, catatan, slide tersembunyi, paragraf, kata, dan multimedia, serta heading pairs dan judul bagian. Ketersediaannya tergantung pada properti mana yang ditulis oleh pembuat dokumen.
- **PPT:** Format biner dapat menyimpan properti ringkasan dokumen yang bersesuaian. Jika suatu properti tidak ada atau tidak diperbarui oleh pembuat dokumen, Aspose.Slides mengembalikan nilai yang disimpan atau nilai default alih‑alih menghitungnya dari slide.
- **ODP:** Metadata OpenDocument menyediakan statistik umum dokumen, seperti hitungan halaman, paragraf, dan kata, namun nilai‑nilai ini tidak selalu berkorespondensi dengan setiap properti tambahan khusus PowerPoint. Metadata slide tersembunyi, slide catatan, multimedia, heading‑pair, dan judul bagian mungkin tidak tersedia, dan properti inventaris dapat mengembalikan nilai default. Jangan menganggap nilai nol atau array kosong sebagai bukti otoritatif bahwa konten yang bersangkutan tidak ada.

Gunakan pendekatan metadata ringan untuk inventaris dan pemeriksaan awal. Muat presentasi dan inspeksi model objeknya yang hidup ketika hasil harus mencerminkan perubahan dalam memori atau ketika Anda perlu memverifikasi konten presentasi yang sebenarnya.

## **Perbarui Properti Presentasi**

Properti yang dikembalikan oleh [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) juga dapat diubah tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Terapkan perubahan dengan [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), lalu tulis presentasi terikat dengan [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

Gambar berikut menunjukkan properti dokumen asli dari presentasi PowerPoint.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh berikut mengubah judul dan waktu penyimpanan terakhir serta menulis hasilnya ke file baru:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

Gambar berikut menunjukkan properti dokumen yang diubah dari presentasi PowerPoint.

![Properti dokumen yang diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk pemeriksaan keamanan dan pengaturan perlindungan yang terkait, lihat artikel berikut:

- [Presentasi yang Dilindungi Kata Sandi](/slides/id/androidjava/password-protected-presentation/)
- [Presentasi yang Dilindungi Penulisan](/slides/id/androidjava/write-protected-presentation/)

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font di-embed dan yang mana?**

Muat presentasi dan gunakan [Presentation.getFontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getFontsManager--). Panggil [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) untuk memperoleh font yang di‑embed dan [IFontsManager.getFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) untuk memperoleh font yang digunakan oleh presentasi. Bandingkan kedua hasil untuk menemukan font yang diperlukan untuk rendering tetapi tidak di‑embed.

**Bagaimana saya dapat dengan cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Ketika metadata dokumen yang disimpan cukup, baca [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) melalui [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) dan [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Ini cocok untuk inventaris ringan. Jika presentasi telah dimodifikasi dalam memori, metadata yang disimpan mungkin hilang atau usang, atau Anda perlu memverifikasi nilai hidup, iterasi melalui [Presentation.getSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getSlides--) dan inspeksi metode [ISlide.getHidden](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/#getHidden--) pada setiap slide.

**Apakah saya dapat mendeteksi apakah ukuran dan orientasi slide khusus digunakan, serta apakah berbeda dari nilai default?**

Ya. Muat presentasi dan panggil [Presentation.getSlideSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getSlideSize--). Gunakan [ISlideSize.getType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidesize/#getSize--) dan [ISlideSize.getOrientation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidesize/#getOrientation--) untuk membandingkan pengaturan saat ini dengan preset dan dimensi yang diharapkan.

**Apakah ada cara cepat untuk melihat apakah diagram merujuk ke sumber data eksternal?**

Ya. Temukan setiap [Chart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chart/) dan panggil [IChartData.getDataSourceType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--). Untuk workbook eksternal, panggil [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Tipe sumber data dan jalur mengidentifikasi referensi eksternal, namun memverifikasi ketersediaan target memerlukan pemeriksaan sumber daya terpisah.

**Bagaimana saya dapat menilai slide “berat” yang mungkin memperlambat rendering atau ekspor PDF?**

Tidak ada properti kompleksitas tunggal. Telusuri [Presentation.getSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getSlides--) dan koleksi [IBaseSlide.getShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseslide/#getShapes--) pada setiap slide. Gunakan jumlah shape serta keberadaan gambar besar, efek, animasi, atau multimedia sebagai sinyal penyaringan, dan ukur render atau ekspor representatif sebelum menganggap slide sebagai bottleneck kinerja yang terkonfirmasi.