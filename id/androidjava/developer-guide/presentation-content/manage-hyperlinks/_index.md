---
title: Kelola Hyperlink Presentasi di Android
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/androidjava/manage-hyperlinks/
keywords:
- tambahkan URL
- tambahkan hyperlink
- buat hyperlink
- format hyperlink
- hapus hyperlink
- perbarui hyperlink
- hyperlink teks
- hyperlink slide
- hyperlink bentuk
- hyperlink gambar
- hyperlink video
- hyperlink dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Tambahkan, format, perbarui, dan hapus hyperlink dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Android via Java, menggunakan contoh Java."
---
## **Pendahuluan**

Hyperlink menghubungkan konten presentasi ke situs web atau lokasi dalam presentasi. Di PowerPoint, hyperlink biasanya berfungsi dua tujuan:

* Membuka situs web dari teks, bentuk, atau bingkai media.
* Menavigasi ke slide lain, misalnya, dari daftar isi.

Aspose.Slides for Android via Java memungkinkan Anda menambahkan tautan ini, mengendalikan penampilannya dan suara, memperbarui propertinya, serta menghapusnya. Contoh di bawah memperlihatkan cara bekerja dengan hyperlink pada elemen individu dan cara mengakses hyperlink pada tingkat presentasi, slide, atau bingkai teks.

{{% alert color="info" title="Catatan" %}}
Anda juga dapat mengedit presentasi dengan [editor PowerPoint online gratis Aspose](https://products.aspose.app/slides/id/editor).
{{% /alert %}}

## **Tambahkan Hyperlink URL**

Anda dapat menetapkan URL situs web ke teks, bentuk, atau bingkai media. Elemen yang Anda beri hyperlink menentukan area yang dapat diklik: bagian teks menautkan teks yang dipilih, sedangkan bentuk atau bingkai menautkan objek slide.

### **Tambahkan Hyperlink URL ke Teks**

Untuk menautkan teks ke situs web, berikan sebuah [Hyperlink](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/hyperlink/) ke metode [setHyperlinkClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) pada bagian teks, seperti contoh di bawah. Hanya bagian teks itu yang menjadi dapat diklik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Tambahkan Hyperlink URL ke Bentuk dan Bingkai Media**

Untuk membuat bentuk atau bingkai dapat diklik, panggil metode [setHyperlinkClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) pada objek tersebut. Hyperlink menjadi milik objek itu sendiri, bukan bagian teks di dalamnya.

Pendekatan yang sama berlaku untuk bingkai gambar, audio, dan video: tetapkan hyperlink ke bingkai dan panggil [setTooltip](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) jika diperlukan.

Contoh berikut membuat sebuah persegi panjang dapat diklik:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gunakan Hyperlink untuk Membuat Daftar Isi**

Hyperlink internal memungkinkan pembaca melompat dari daftar isi ke slide tertentu. Contoh berikut menggunakan [setInternalHyperlinkClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) untuk menautkan teks “Page 2” pada slide pertama ke slide kedua.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Format Hyperlink**

### **Warna**

Metode [setColorSource](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) pada [IHyperlink](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/) menentukan apakah hyperlink menggunakan warna hyperlink presentasi atau format bagian teks. Untuk menerapkan warna teks khusus, pilih [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/hyperlinkcolorsource/) dan setel warna isian bagian. Fitur ini diperkenalkan di PowerPoint 2019; versi sebelumnya tidak menerapkan pengaturan ini.

Contoh berikut menambahkan dua hyperlink teks ke slide yang sama. Yang pertama menggunakan isian teks merah, sedangkan yang kedua mempertahankan warna hyperlink default.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Suara**

Hyperlink dapat memutar suara saat diaktifkan atau menghentikan suara yang sudah diputar. Gunakan metode berikut untuk mengkonfigurasi perilaku ini:

- [IHyperlink.setSound](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) menentukan audio yang terkait dengan hyperlink.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) mengontrol apakah mengaktifkan hyperlink menghentikan suara sebelumnya.

#### **Tambahkan Suara Hyperlink**

Contoh berikut memuat `sampleaudio.wav` dan mengaitkannya dengan tombol pada slide pertama. Mengklik tombol memutar suara dan menavigasi ke slide berikutnya. Bentuk kedua pada slide itu menghentikan suara sebelumnya saat diklik, tanpa melakukan aksi navigasi.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Ekstrak Suara Hyperlink**

Contoh berikut membuka presentasi yang dibuat di atas dan membaca audio hyperlink bentuk pertama ke memori melalui [getSound](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#getSound--) dan [getBinaryData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Tooltip dan Pengaturan Interaksi**

Anda dapat memanggil metode [IHyperlink](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/) berikut setelah menetapkan hyperlink ke teks atau bentuk:

- [setTooltip](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) menetapkan teks yang dapat ditampilkan penonton sebagai petunjuk tautan.
- [setTargetFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) menentukan bingkai target dalam kumpulan bingkai HTML induk, bila berlaku.
- [setHistory](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) mengontrol apakah mengaktifkan tautan menambahkan tujuannya ke daftar hyperlink yang telah dilihat.
- [setHighlightClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) mengontrol apakah hyperlink disorot saat diklik.

## **Hapus Hyperlink dari Presentasi**

Gunakan [getAnyHyperlinks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) untuk mengumpulkan wadah hyperlink, termasuk tautan bagian teks, sebelum mengubahnya. Contoh berikut menghapus kedua tipe aktivasi dari slide pertama. Untuk menghapus hanya satu tipe, panggil hanya [removeHyperlinkClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) atau [removeHyperlinkMouseOver](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); menghapus aksi klik tidak menghapus pasangan mouse‑over‑nya.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Untuk penghapusan tanpa syarat, [removeAllHyperlinks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) menghapus kedua tipe aktivasi dalam ruang lingkup yang dipilih sekaligus. Untuk pembersihan selektif dan mencakup master, layout, dan catatan, lihat [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Buat Inventaris Hyperlink Lengkap**

Sebelum mendistribusikan presentasi, inventarisasi aksi interaktif serta tautan webnya. [getAnyHyperlinks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) mengembalikan objek [IHyperlinkContainer](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkcontainer/), bukan daftar datar string URL. Periksa baik [getHyperlinkClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) maupun [getHyperlinkMouseOver](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) pada setiap wadah. Mereka independen: satu wadah dapat mengekspos kedua aksi, jadi laporan lengkap memerlukan hingga dua baris per wadah.

Pemindaian hanya hyperlink tingkat bentuk dapat melewatkan tautan pada bagian teks. Kueri ruang lingkup yang tepat sebagai gantinya, dan simpan wadah yang dikembalikan agar nanti dapat memperbarui atau menghapus aksinya.

### **Kueri Ruang Lingkup Presentasi, Slide, dan Bingkai Teks**

Antarmuka [IHyperlinkQueries](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkqueries/) tersedia melalui [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), dan [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Setiap ruang lingkup mendukung kueri yang sama:

- [getHyperlinkClicks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) mengembalikan wadah dengan aksi klik.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) mengembalikan wadah dengan aksi mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) mengembalikan wadah dengan salah satu atau kedua aksi.

Contoh berikut membuat `hyperlink-audit-input.pptx` dengan tautan klik eksternal, tautan mouse‑over berkas, navigasi slide internal, tautan mouse‑over teks, dan aksi makro. Ia tidak mengeksekusi aksi apa pun. Ketiga kueri bekerja pada setiap ruang lingkup; hitungan menggambarkan wadah, bukan total aksi. Ruang lingkup bingkai teks mengecualikan tautan milik bentuk yang menutupinya.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk contoh ini, kueri presentasi dan slide masing‑masing melaporkan tiga wadah klik, dua wadah mouse‑over, dan tiga wadah dengan salah satu aksi. Kueri bingkai teks melaporkan satu wadah di setiap kategori.

### **Klasifikasikan Aksi dan Tujuan**

Gunakan [IHyperlink.getActionType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#getActionType--) untuk menafsirkan aksi sebelum menafsirkan tujuannya. Nilai [HyperlinkActionType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/hyperlinkactiontype/) mencakup lebih dari navigasi web:

| Nilai | Makna untuk audit |
| --- | --- |
| `Hyperlink` | Hyperlink eksternal; periksa URL dan skemanya. |
| `JumpSpecificSlide` | Navigasi internal ke slide tertentu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigasi slideshow bawaan, diselesaikan dalam konteks slideshow. |
| `JumpEndShow`, `StartCustomSlideShow` | Mengakhiri pertunjukan saat ini atau memulai pertunjukan khusus. |
| `StartMacro` | Menjalankan makro. |
| `StartProgram` | Meluncurkan program. |
| `OpenFile`, `OpenPresentation` | Membuka file atau presentasi lain; tinjau terpisah dari URL web. |
| `StartStopMedia` | Memulai atau menghentikan pemutaran media. |
| `NoAction`, `Unknown` | Tidak ada aksi navigasi, atau aksi yang tidak dikenali yang memerlukan tinjauan. |

Baca tujuan eksternal melalui [getExternalUrl](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) dan tujuan internal spesifik melalui [getTargetSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Aksi internal dan perintah bawaan mungkin tidak memiliki URL eksternal; URL kosong tidak berarti wadah tidak memiliki aksi. Simpan nilai yang dikembalikan oleh [getExternalUrlOriginal](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) bila berbeda dari URL yang dinormalisasi, dan sertakan tooltip yang dikembalikan oleh [getTooltip](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) bila tersedia.

### **Laporan, Sanitasi, dan Verifikasi Hyperlink**

Contoh Java berikut membaca presentasi yang ada (gunakan berkas yang dibuat di atas), menulis `hyperlink-audit.json`, menerapkan kebijakan, menyimpan `hyperlink-sanitized.pptx`, dan membukanya kembali untuk memeriksa kembali kedua tipe aktivasi. Ia mengumpulkan wadah sebelum mengubahnya dan menggunakan kesetaraan referensi untuk menghindari pemrosesan wadah yang sama dua kali. Kueri presentasi mencakup slide biasa; untuk inventaris paket lengkap, ia juga secara eksplisit mengkueri master, layout, catatan, serta master catatan dan handout bila ada.

Laporan mencatat indeks slide berbasis satu dan [getSlideId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) bila tersedia. [ISlideComponent.getSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecomponent/#getSlide--) menyediakan slide pemilik untuk wadah yang didukung. Master, layout, dan catatan tidak memiliki indeks slide biasa dan diidentifikasi oleh ruang lingkupnya. Wadah bentuk dan wadah format bagian teks diberi label terpisah; tipe wadah lain mempertahankan nama tipe runtime mereka. Setiap wadah mendapatkan ID laporan lokal sehingga dua aksinya dapat dikorelasikan. Laporan menyimpan tipe aksi sebagai konstanta integer yang didefinisikan oleh enumerasi Java.

Kebijakan aplikasi yang sengaja restriktif ini hanya memperbolehkan URL HTTPS absolut dan target slide internal yang valid. Ia menolak makro, program, aksi berkas, aksi slideshow lainnya, aksi tidak dikenal, serta skema URL lain. Penolakan ini merupakan keputusan kebijakan, bukan penilaian keamanan Aspose.Slides. HTTPS saja tidak menjamin kepercayaan: tambahkan daftar putih host dan pemeriksaan lain untuk aplikasi Anda. Kedua URL eksternal, asli dan yang dinormalisasi, diperiksa. Contoh ini mengaudit metadata tanpa mengikuti tautan atau menjalankan aksi.

Untuk remediasi, [getHyperlinkManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) pada wadah mendukung [setExternalHyperlinkClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) dan [removeHyperlinkMouseOver](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Di sini, tautan klik eksternal yang dilarang diganti dengan halaman landas HTTPS tetap; klik dan mouse‑over yang dilarang lainnya dihapus secara independen. Atur `replaceExternalClicks` ke `false` untuk menghapus semua pelanggaran kebijakan. Pilih halaman pengganti milik aplikasi sebelum penyebaran.

Flag ekspor laporan menggunakan kebijakan peninjauan PDF yang konservatif: beri tanda pada aksi mouse‑over dan apa pun selain tautan eksternal atau loncatan slide spesifik sebagai potensi tidak didukung. Itu merupakan petunjuk peninjauan, bukan tes kemampuan atau jaminan bahwa tautan yang tidak ditandai akan bertahan pada ekspor. Ekspor [PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/androidjava/convert-powerpoint-to-html/) yang didukung dapat mempertahankan hyperlink, tergantung pada aksi, opsi ekspor, dan penampil. Raster [gambar](/slides/id/androidjava/convert-powerpoint-to-png/) dan [video](/slides/id/androidjava/convert-powerpoint-to-video/) tidak dapat mempertahankan hyperlink interaktif; beri tanda setiap aksi saat mengaudit untuk output tersebut.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // Serialisasi baris datar laporan ini tanpa dependensi JSON tambahan.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Dengan input yang dibuat di atas, laporan berisi lima baris aksi. Tautan mouse‑over berkas dan klik makro dihapus, sedangkan tautan HTTPS serta navigasi slide internal tetap. Verifikasi mencetak nol aksi yang dilarang. Input yang berisi URL klik eksternal yang dilarang juga menguji jalur penggantian. Wadah dengan klik yang diizinkan dan mouse‑over yang dilarang mempertahankan aksi kliknya.

Pembersihan selektif ini berbeda dari [removeAllHyperlinks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) yang menghapus kedua tipe aktivasi di seluruh ruang lingkup terpilih terlepas dari kebijakan. Verifikasi di sini hanya memeriksa aksi hyperlink; ia tidak menghapus proyek VBA tertanam, objek OLE, atau konten aktif lainnya, dan tidak memvalidasi berkas PDF atau HTML yang diekspor.

## **FAQ**

**Bagaimana cara menautkan ke sebuah bagian atau slide pertamanya?**

Bagian di PowerPoint mengelompokkan slide, namun hyperlink internal menargetkan slide individu. Untuk membuat navigasi ke sebuah bagian, tautkan ke slide pertama dalam bagian tersebut.

**Apakah saya dapat menempelkan hyperlink pada elemen master slide sehingga berfungsi pada semua slide?**

Ya. Elemen master slide dan layout mendukung hyperlink. Tautan pada elemen tersebut tersedia selama pertunjukan slide pada slide yang menggunakan master atau layout yang bersangkutan.

**Apakah hyperlink akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Ekspor PDF dan HTML yang didukung dapat mempertahankan hyperlink; gambar raster dan video tidak dapat. Lihat pertimbangan ekspor pada [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).