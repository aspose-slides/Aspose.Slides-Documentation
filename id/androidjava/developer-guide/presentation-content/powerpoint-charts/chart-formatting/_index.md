---
title: Format Diagram Presentasi pada Android
linktitle: Pemformatan Diagram
type: docs
weight: 60
url: /id/androidjava/chart-formatting/
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
- Android
- Java
- Aspose.Slides
description: "Pelajari pemformatan diagram di Aspose.Slides untuk Android via Java dan tingkatkan presentasi PowerPoint Anda dengan gaya profesional yang menarik perhatian."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara memformat diagram dalam presentasi PowerPoint dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyesuaikan elemen diagram utama seperti sumbu, garis kisi, judul, legenda, area plot, dan isian dinding untuk meningkatkan tampilan dan keterbacaan data diagram. Artikel ini juga memperagakan cara mengatur properti font untuk teks diagram, menerapkan format numerik bawaan dan khusus pada data diagram, serta mengaktifkan sudut melengkung untuk area diagram. Bersama-sama, contoh-contoh ini menunjukkan cara mengontrol baik gaya visual maupun penyajian data diagram dalam sebuah presentasi.

## **Format Entitas Diagram**
Aspose.Slides for Android via Java memungkinkan pengembang menambahkan diagram khusus ke slide mereka dari awal. Artikel ini menjelaskan cara memformat berbagai entitas diagram termasuk kategori diagram dan sumbu nilai.

Aspose.Slides for Android via Java menyediakan API sederhana untuk mengelola berbagai entitas diagram dan memformatnya menggunakan nilai khusus:

1. Buat sebuah instance dari kelas [**Presentation**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) class.
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default beserta jenis yang diinginkan (dalam contoh ini kita akan menggunakan ChartType.LineWithMarkers).
1. Akses Sumbu Nilai diagram dan atur properti berikut:
   1. Mengatur **Line format** untuk garis kisi utama Sumbu Nilai
   1. Mengatur **Line format** untuk garis kisi minor Sumbu Nilai
   1. Mengatur **Number Format** untuk Sumbu Nilai
   1. Mengatur **Min, Max, Major and Minor units** untuk Sumbu Nilai
   1. Mengatur **Text Properties** untuk data Sumbu Nilai
   1. Mengatur **Title** untuk Sumbu Nilai
   1. Mengatur **Line Format** untuk Sumbu Nilai
1. Akses Sumbu Kategori diagram dan atur properti berikut:
   1. Mengatur **Line format** untuk garis kisi utama Sumbu Kategori
   1. Mengatur **Line format** untuk garis kisi minor Sumbu Kategori
   1. Mengatur **Text Properties** untuk data Sumbu Kategori
   1. Mengatur **Title** untuk Sumbu Kategori
   1. Mengatur **Label Positioning** untuk Sumbu Kategori
   1. Mengatur **Rotation Angle** untuk label Sumbu Kategori
1. Akses Legenda diagram dan atur **Text Properties** untuknya
1. Atur agar Legenda diagram ditampilkan tanpa tumpang tindih dengan diagram
1. Akses **Secondary Value Axis** diagram dan atur properti berikut:
   1. Aktifkan **Value Axis** Sekunder
   1. Mengatur **Line Format** untuk Secondary Value Axis
   1. Mengatur **Number Format** untuk Secondary Value Axis
   1. Mengatur **Min, Max, Major and Minor units** untuk Secondary Value Axis
1. Sekarang plot seri diagram pertama pada Secondary Value Axis
1. Atur warna isian dinding belakang diagram
1. Atur warna isian area plot diagram
1. Tuliskan presentasi yang dimodifikasi ke file PPTX

```java
// Buat sebuah instance dari kelas Presentation
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide slide = pres.getSlides().get_Item(0);

    // Menambahkan diagram contoh
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Mengatur Judul Diagram
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Mengatur format garis kisi utama untuk sumbu nilai
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Mengatur format garis kisi minor untuk sumbu nilai
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Mengatur format angka sumbu nilai
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Mengatur nilai maksimum, minimum diagram
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Mengatur Properti Teks Sumbu Nilai
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Mengatur judul sumbu nilai
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Mengatur format garis kisi utama untuk sumbu Kategori
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Mengatur format garis kisi minor untuk sumbu Kategori
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Mengatur Properti Teks Sumbu Kategori
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Mengatur Judul Kategori
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Mengatur posisi label sumbu kategori
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Mengatur sudut rotasi label sumbu kategori
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Mengatur Properti Teks Legenda
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Atur tampilan legenda diagram tanpa menumpuk diagram

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Mengatur sumbu nilai sekunder
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Mengatur format angka sumbu nilai sekunder
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Mengatur nilai maksimum, minimum diagram
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Mengatur warna dinding belakang diagram
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Mengatur warna area plot
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Simpan Presentasi
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Properti Font untuk Diagram**
Aspose.Slides for Android via Java menyediakan dukungan untuk mengatur properti terkait font untuk diagram. Silakan ikuti langkah-langkah di bawah ini untuk mengatur properti font diagram.

- Instansiasikan objek kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) .
- Tambahkan diagram pada slide.
- Atur tinggi font.
- Simpan presentasi yang dimodifikasi.

Contoh sampel di bawah diberikan.

```java
// Buat sebuah instance dari kelas Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Format Numerik**
Aspose.Slides for Android via Java menyediakan API sederhana untuk mengelola format data diagram:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) .
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default beserta jenis yang diinginkan (contoh ini menggunakan **ChartType.ClusteredColumn**).
1. Atur format angka bawaan dari nilai preset yang tersedia.
1. Telusuri setiap sel data diagram dalam setiap seri diagram dan atur format angka data diagram.
1. Simpan presentasi.
1. Atur format angka khusus.
1. Telusuri setiap sel data diagram dalam setiap seri diagram dan atur format angka data diagram yang berbeda.
1. Simpan presentasi.

```java
// Buat sebuah instance dari kelas Presentation
Presentation pres = new Presentation();
try {
    // Akses slide presentasi pertama
    ISlide slide = pres.getSlides().get_Item(0);

    // Menambahkan diagram kolom berkelompok default
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Mengakses koleksi seri diagram
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Menelusuri setiap seri diagram
    for (IChartSeries ser : series) 
    {
        // Menelusuri setiap sel data dalam seri
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Mengatur format angka
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0,00%
        }
    }

    // Menyimpan presentasi
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Nilai format angka preset yang tersedia beserta indeks presetnya dan dapat digunakan diberikan di bawah ini:

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
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Atur Bingkai Sudut Bulat Area Diagram**
Aspose.Slides for Android via Java menyediakan dukungan untuk mengatur area diagram. Metode [**hasRoundedCorners**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) dan [**setRoundedCorners**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) telah ditambahkan ke antarmuka [IChart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChart) dan kelas [Chart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Chart) .

1. Instansiasikan objek kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) .
1. Tambahkan diagram pada slide.
1. Atur tipe isian dan warna isian diagram
1. Atur properti sudut bulat menjadi True.
1. Simpan presentasi yang dimodifikasi.

Contoh sampel di bawah diberikan.  

```java
// Buat sebuah instance dari kelas Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengatur isian semi-transparan untuk kolom/area sambil menjaga batas tetap tidak transparan?**

Ya. Transparansi isian dan garis tepi dikonfigurasi secara terpisah. Hal ini berguna untuk meningkatkan keterbacaan kisi dan data dalam visualisasi yang padat.

**Bagaimana saya dapat menangani label data ketika mereka saling tumpang tindih?**

Kurangi ukuran font, nonaktifkan komponen label yang tidak penting (misalnya kategori), atur offset/posisi label, tampilkan label hanya untuk poin yang dipilih bila diperlukan, atau ubah format menjadi "value + legend".

**Apakah saya dapat menerapkan isian gradasi atau pola pada seri?**

Ya. Baik isian solid maupun gradasi/pola biasanya tersedia. Dalam praktik, gunakan gradasi secara hemat dan hindari kombinasi yang mengurangi kontras dengan kisi dan teks.