---
title: Format Diagram Presentasi di Java
linktitle: Pemformatan Diagram
type: docs
weight: 60
url: /id/java/chart-formatting/
keywords:
- format diagram
- pemformatan diagram
- entitas diagram
- properti diagram
- pengaturan diagram
- opsi diagram
- properti font
- garis tepi bulat
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari pemformatan diagram di Aspose.Slides untuk Java dan tingkatkan presentasi PowerPoint Anda dengan sumbu khusus, font, format angka, dan garis tepi diagram yang melengkung."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara memformat diagram dalam presentasi PowerPoint dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyesuaikan elemen diagram utama seperti sumbu, garis kisi, judul, legenda, area plot, dan isian dinding untuk meningkatkan tampilan dan keterbacaan data diagram.

Artikel ini juga mendemonstrasikan cara mengatur properti font untuk teks diagram, menerapkan format numerik bawaan pada data diagram, dan mengaktifkan sudut melengkung untuk area diagram. Bersama‑sama, contoh‑contoh ini menunjukkan cara mengendalikan baik gaya visual maupun penyajian data diagram dalam sebuah presentasi.

Untuk isian dan garis tepi terpisah pada interval naik dan turun, lihat [contoh diagram saham](/slides/id/java/create-chart/#create-stock-charts).

## **Format Entitas Diagram**

Gunakan [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) untuk memformat judul diagram, sumbu, garis kisi, legenda, dan area plot. Contoh ini membuat diagram garis dengan penanda dan data default, kemudian menerapkan gaya teks dan garis yang terpisah pada sumbu nilai dan sumbu kategori. Ukuran font dan lebar garis ditentukan dalam poin; label kategori diputar 45 derajat.

Sumbu nilai menggunakan [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) secara terpisah dari sel sumber. Skala sumbu berjalan dari -2 hingga 15, dengan interval utama 2 dan interval minor 0,5. Contoh ini juga menggabungkan pemformatan persentase dengan [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) yang disetel ke ribuan, jadi sesuaikan pengaturan ini dengan makna dan besaran data Anda. Legenda tetap di luar area plot karena [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) dipanggil dengan `false`. Isian dinding belakang dan lantai dikonfigurasi melalui [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) dan [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--), namun permukaan ini hanya terlihat pada diagram 3D.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Properti Font untuk Diagram**

Atur ukuran font default untuk teks diagram melalui [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--). Contoh ini membuat diagram kolom berkelompok dengan font 20 poin dan mengaktifkan label nilai untuk seri pertama melalui [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Elemen teks dengan pengaturan font eksplisitnya dapat menimpa default diagram.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gunakan Kembali Pemformatan Bingkai Teks untuk Legenda Diagram**

Untuk menyamakan legenda dengan judul slide, atur font judul melalui [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) pada paragraf pertama. Panggil [copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) pada format yang dikembalikan oleh [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) legenda. Metode ini menyalin pengaturan bingkai teks, pemformatan paragraf pertama, dan properti font default paragraf tersebut. Pemformatan yang diterapkan langsung pada bagian individual atau pada paragraf selanjutnya tetap lokal pada sumber.

Contoh menggunakan judul Calibri 26 poin tebal berwarna navy sebagai templat. Setelah menata legenda, contoh memanggil [copyTo](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) untuk menerapkan pemformatan yang sama pada keterangan terpisah.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(new Color(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pada presentasi yang disimpan, legenda dan keterangan cocok dengan judul dalam ukuran, ketebalan, dan warna. Legenda tetap menampilkan nama‑nama seri, dan keterangan mempertahankan teksnya sendiri. Jika sebuah bagian dalam keterangan sudah memiliki ukuran font eksplisit, ukuran tersebut akan mengambil prioritas atas default paragraf yang disalin.

| Sebelum menyalin | Setelah menyalin |
| --- | --- |
| ![Diagram penjualan kuartalan dengan label legenda hitam biasa dan keterangan hitam](legend-formatting-before.png) | ![Diagram yang sama dengan label legenda biru tua yang lebih besar, tebal, dan keterangan yang cocok](legend-formatting.png) |

## **Atur Format Numerik**

Gunakan [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) untuk menerapkan format angka bawaan pada sel buku kerja diagram. Contoh ini membuat diagram kolom berkelompok dengan data default yang didukung sel dan menerapkan indeks format 10 (`0.00%`) pada setiap sel nilai seri. Ini mengubah cara nilai ditampilkan di buku kerja tanpa mengubah angka dasar; misalnya, 0,25 ditampilkan sebagai 25,00%. Format sumbu dan label data dapat dikonfigurasi secara terpisah.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tabel berikut mencantumkan indeks format angka bawaan beserta contoh format Excel untuk lokal Inggris (Amerika Serikat). String format tepat dan tampilannya dapat bervariasi menurut aplikasi dan lokal, terutama untuk mata uang dan tanggal. Beberapa format Excel juga berbeda dari default dalam standar OOXML, seperti yang dijelaskan dalam [catatan implementasi format angka Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Indeks | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Atur Bingkai Sudut Membulat Area Diagram**

Panggil [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) dengan `true` untuk membulatkan sudut area diagram. Contoh ini membuat diagram kolom berkelompok dan menggunakan [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) untuk memberi outline warna abu‑abu solid dan gaya garis tunggal sebelum menyimpan presentasi.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunting Anotasi Diagram yang Ada**

Sebuah diagram dapat berisi bentuk khusus, seperti anotasi teks yang menjelaskan status sebuah laporan. Akses bentuk‑bentuk ini melalui [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--), juga tercantum di bawah [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) dalam Referensi API Diagram. Koleksi yang dikembalikan oleh [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) berisi bentuk‑bentuk milik diagram.

Kotak teks biasa yang ditempatkan di atas diagram termasuk ke slide, meskipun terlihat seperti bagian diagram. Iterasi melalui [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) menemukan diagram dan bentuk slide biasa, tetapi tidak menelusuri bentuk‑bentuk individual di dalam diagram. Judul diagram dan label data adalah elemen diagram terpisah, bukan anotasi khusus dalam koleksi ini.

Unduh [chart-annotations.pptx](chart-annotations.pptx) dan letakkan di direktori kerja aplikasi. Slide pertama berisi diagram dengan anotasi tidak tergabung berisi teks "Preliminary results", sebuah garis milik diagram, dan kotak teks slide biasa berisi teks "Slide overlay". Contoh menemukan diagram pertama pada slide tersebut dan mengubah anotasi menjadi "Final results" ketika laporan siap dipublikasikan. Contoh memeriksa apakah koleksi kosong dan hanya menyunting sebuah [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) dengan bingkai teks tidak null yang dikembalikan oleh [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) serta teks yang diharapkan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

Garis dan kotak teks slide tetap tidak berubah. Gambar berikut memperlihatkan input dan hasil yang disimpan serta dibuka kembali:

| Sebelum menyunting | Setelah menyunting |
| --- | --- |
| ![Anotasi diagram bertuliskan Preliminary results](chart-annotations-before.png) | ![Anotasi diagram bertuliskan Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Contoh hanya memeriksa bentuk milik diagram pada tingkat atas. Jika sebuah anotasi berada di dalam sebuah [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), periksa koleksi [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) grup tersebut juga. Lakukan ini secara rekursif untuk grup bersarang, menerapkan pemeriksaan teks yang sama pada bentuk anaknya. Sebuah grup sendiri adalah wadah; jangan memperlakukannya sebagai kotak teks.
{{% /alert %}}

## **Tanya Jawab**

**Apakah saya dapat mengatur isian semi‑transparan untuk kolom/area sambil menjaga batas tetap opak?**

Ya. Transparansi isian dan outline diatur secara terpisah. Ini berguna untuk meningkatkan keterbacaan kisi dan data pada visualisasi yang padat.

**Bagaimana saya bisa menangani label data ketika mereka tumpang tindih?**

Kurangi ukuran font, nonaktifkan komponen label yang tidak penting (misalnya kategori), sesuaikan posisi label, tampilkan label hanya untuk titik yang dipilih jika diperlukan, atau ubah format menjadi "value + legend".

**Apakah saya dapat menerapkan isian gradien atau pola pada seri?**

Ya. Seri mendukung isian solid, gradien, dan pola. Pada praktiknya, gunakan gradien secara hemat dan hindari kombinasi yang mengurangi kontras dengan kisi dan teks.