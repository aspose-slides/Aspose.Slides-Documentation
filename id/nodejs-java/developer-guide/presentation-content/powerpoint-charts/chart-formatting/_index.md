---
title: Format Diagram Presentasi dalam JavaScript
linktitle: Pemformatan Diagram
type: docs
weight: 60
url: /id/nodejs-java/chart-formatting/
keywords:
- format diagram
- pemformatan diagram
- entitas diagram
- properti diagram
- pengaturan diagram
- opsi diagram
- properti font
- batas melengkung
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari pemformatan diagram di Aspose.Slides untuk Node.js dalam JavaScript dan tingkatkan presentasi PowerPoint Anda dengan gaya profesional yang menarik."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara memformat diagram dalam presentasi PowerPoint dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyesuaikan elemen diagram utama seperti sumbu, garis kisi, judul, legenda, area plot, dan isi dinding untuk meningkatkan tampilan dan keterbacaan data diagram.

Artikel ini juga menunjukkan cara mengatur properti font untuk teks diagram, menerapkan format numerik preset dan kustom pada data diagram, serta mengaktifkan sudut melengkung untuk area diagram. Bersama-sama, contoh-contoh ini menunjukkan cara mengendalikan baik gaya visual maupun penyajian data diagram dalam sebuah presentasi.

## **Format Entitas Diagram**

Aspose.Slides for Node.js via Java memungkinkan pengembang menambahkan diagram kustom ke slide dari awal. Artikel ini menjelaskan cara memformat berbagai entitas diagram termasuk sumbu kategori dan nilai diagram.

Aspose.Slides for Node.js via Java menyediakan API sederhana untuk mengelola berbagai entitas diagram dan memformatnya menggunakan nilai kustom:

1. Buat sebuah instance dari kelas [**Presentation**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) class.
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default bersama salah satu tipe yang diinginkan (dalam contoh ini kita akan menggunakan ChartType.LineWithMarkers).
1. Akses Value Axis diagram dan atur properti berikut:
   1. Mengatur **Line format** untuk garis kisi utama Value Axis.
   1. Mengatur **Line format** untuk garis kisi minor Value Axis.
   1. Mengatur **Number Format** untuk Value Axis.
   1. Mengatur **Min, Max, Major and Minor units** untuk Value Axis.
   1. Mengatur **Text Properties** untuk data Value Axis.
   1. Mengatur **Title** untuk Value Axis.
   1. Mengatur **Line Format** untuk Value Axis.
1. Akses Category Axis diagram dan atur properti berikut:
   1. Mengatur **Line format** untuk garis kisi utama Category Axis.
   1. Mengatur **Line format** untuk garis kisi minor Category Axis.
   1. Mengatur **Text Properties** untuk data Category Axis.
   1. Mengatur **Title** untuk Category Axis.
   1. Mengatur **Label Positioning** untuk Category Axis.
   1. Mengatur **Rotation Angle** untuk label Category Axis.
1. Akses Legend diagram dan atur **Text Properties** untuknya.
1. Atur agar Legend diagram ditampilkan tanpa tumpang tindih dengan diagram.
1. Akses **Secondary Value Axis** diagram dan atur properti berikut:
   1. Aktifkan **Value Axis** sekunder.
   1. Mengatur **Line Format** untuk Secondary Value Axis.
   1. Mengatur **Number Format** untuk Secondary Value Axis.
   1. Mengatur **Min, Max, Major and Minor units** untuk Secondary Value Axis.
1. Sekarang plot seri diagram pertama pada Secondary Value Axis.
1. Atur warna isi back wall diagram.
1. Atur warna isi area plot diagram.
1. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```javascript
// Buat sebuah instance dari kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Menambahkan diagram contoh
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Mengatur Judul Diagram
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Mengatur format garis kisi utama untuk sumbu nilai
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Mengatur format garis kisi minor untuk sumbu nilai
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Mengatur format angka sumbu nilai
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Mengatur nilai maksimum, minimum diagram
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Mengatur Properti Teks Sumbu Nilai
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Mengatur judul sumbu nilai
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Mengatur format garis kisi utama untuk sumbu Kategori
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Mengatur format garis kisi minor untuk sumbu Kategori
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setFillFormat(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Mengatur Properti Teks Sumbu Kategori
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Mengatur Judul Kategori
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Mengatur posisi label sumbu kategori
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Mengatur sudut rotasi label sumbu kategori
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Mengatur Properti Teks Legenda
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Atur tampilan legenda diagram tanpa tumpang tindih dengan diagram
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Mengatur sumbu nilai sekunder
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Mengatur format angka sumbu nilai sekunder
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Mengatur nilai maksimum, minimum diagram
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Mengatur warna dinding belakang diagram
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Mengatur warna area plot
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Simpan Presentasi
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Properti Font untuk Diagram**

Aspose.Slides for Node.js via Java menyediakan dukungan untuk mengatur properti terkait font untuk diagram. Ikuti langkah-langkah berikut untuk mengatur properti font pada diagram.

- Instansiasi objek kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) class.
- Tambahkan diagram pada slide.
- Atur tinggi font.
- Simpan presentasi yang telah dimodifikasi.

Contoh kode contoh diberikan di bawah.

```javascript
// Buat sebuah instance dari kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Format Numerik**

Aspose.Slides for Node.js via Java menyediakan API sederhana untuk mengelola format data diagram:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) class.
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default bersama salah satu tipe yang diinginkan (contoh ini menggunakan **ChartType.ClusteredColumn**).
1. Atur format angka preset dari nilai preset yang tersedia.
1. Telusuri sel data diagram pada setiap seri diagram dan atur format angka data diagram.
1. Simpan presentasi.
1. Atur format angka kustom.
1. Telusuri sel data diagram di dalam setiap seri diagram dan atur format angka data diagram yang berbeda.
1. Simpan presentasi.

```javascript
// Buat sebuah instance dari kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Akses slide presentasi pertama
    var slide = pres.getSlides().get_Item(0);
    // Menambahkan diagram kolom terkelompok default
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Mengakses koleksi seri diagram
    var series = chart.getChartData().getSeries();
    // Menelusuri setiap seri diagram
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Menelusuri setiap sel data dalam seri
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Mengatur format angka
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // Menyimpan presentasi
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Nilai format angka preset yang tersedia beserta indeks presetnya dan dapat digunakan ditampilkan di bawah:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Atur Sudut Membulat Area Diagram**

Aspose.Slides for Node.js via Java menyediakan dukungan untuk mengatur area diagram. Metode [**hasRoundedCorners**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) dan [**setRoundedCorners**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) telah ditambahkan ke kelas [Chart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Chart).

1. Instansiasi objek kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) class.
1. Tambahkan diagram pada slide.
1. Atur tipe isian dan warna isian diagram.
1. Atur properti sudut melengkung menjadi True.
1. Simpan presentasi yang telah dimodifikasi.

Contoh kode contoh diberikan di bawah.

```javascript
// Buat sebuah instance dari kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat mengatur isi semi-transparan untuk kolom/area sekaligus menjaga batas tetap tidak tembus?**

Ya. Transparansi isi dan tepi dapat dikonfigurasi secara terpisah. Hal ini berguna untuk meningkatkan keterbacaan kisi dan data pada visualisasi yang padat.

**Bagaimana cara menangani label data ketika mereka tumpang tindih?**

Kurangi ukuran font, nonaktifkan komponen label yang tidak penting (misalnya, kategori), atur offset/posisi label, tampilkan label hanya untuk poin yang dipilih bila diperlukan, atau ubah format menjadi "value + legend".

**Apakah saya dapat menerapkan isian gradien atau pola pada seri?**

Ya. Baik isian solid maupun gradien/pola biasanya tersedia. Dalam praktik, gunakan gradien secara hemat dan hindari kombinasi yang mengurangi kontras dengan kisi dan teks.