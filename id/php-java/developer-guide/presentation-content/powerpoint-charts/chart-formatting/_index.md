---
title: Format Diagram Presentasi dalam PHP
linktitle: Pemformatan Diagram
type: docs
weight: 60
url: /id/php-java/chart-formatting/
keywords:
- format diagram
- pemformatan diagram
- entitas diagram
- properti diagram
- pengaturan diagram
- opsi diagram
- properti font
- border bulat
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari pemformatan diagram di Aspose.Slides untuk PHP via Java dan tingkatkan presentasi PowerPoint Anda dengan gaya profesional yang menarik perhatian."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara memformat diagram dalam presentasi PowerPoint dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyesuaikan elemen diagram utama seperti sumbu, garis kisi, judul, legenda, area plot, dan isi dinding untuk meningkatkan tampilan dan keterbacaan data diagram.

Artikel ini juga mendemonstrasikan cara mengatur properti font untuk teks diagram, menerapkan format numerik bawaan dan khusus pada data diagram, serta mengaktifkan sudut bulat untuk area diagram. Bersama-sama, contoh-contoh ini menunjukkan cara mengontrol baik gaya visual maupun penyajian data diagram dalam sebuah presentasi.

## **Format Entitas Diagram**

Aspose.Slides for PHP via Java memungkinkan pengembang menambahkan diagram khusus ke slide mereka dari awal. Artikel ini menjelaskan cara memformat berbagai entitas diagram termasuk kategori diagram dan sumbu nilai.

Aspose.Slides for PHP via Java menyediakan API sederhana untuk mengelola berbagai entitas diagram dan memformatnya menggunakan nilai khusus:

1. Buat instance dari kelas [**Presentation**](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Dapatkan referensi slide berdasarkan indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan (dalam contoh ini kita akan menggunakan ChartType::LineWithMarkers).
4. Akses Sumbu Nilai diagram dan atur properti berikut:
   1. Menyetel **Line format** untuk Garis Kisi Utama Sumbu Nilai
   2. Menyetel **Line format** untuk Garis Kisi Minor Sumbu Nilai
   3. Menyetel **Number Format** untuk Sumbu Nilai
   4. Menyetel **Min, Max, Major and Minor units** untuk Sumbu Nilai
   5. Menyetel **Text Properties** untuk data Sumbu Nilai
   6. Menyetel **Title** untuk Sumbu Nilai
   7. Menyetel **Line Format** untuk Sumbu Nilai
5. Akses Sumbu Kategori diagram dan atur properti berikut:
   1. Menyetel **Line format** untuk Garis Kisi Utama Sumbu Kategori
   2. Menyetel **Line format** untuk Garis Kisi Minor Sumbu Kategori
   3. Menyetel **Text Properties** untuk data Sumbu Kategori
   4. Menyetel **Title** untuk Sumbu Kategori
   5. Menyetel **Label Positioning** untuk Sumbu Kategori
   6. Menyetel **Rotation Angle** untuk label Sumbu Kategori
6. Akses Legenda diagram dan atur **Text Properties** untuknya
7. Atur tampilan Legenda diagram agar tidak tumpang tindih dengan diagram
8. Akses **Secondary Value Axis** diagram dan atur properti berikut:
   1. Aktifkan **Value Axis** Sekunder
   2. Menyetel **Line Format** untuk Secondary Value Axis
   3. Menyetel **Number Format** untuk Secondary Value Axis
   4. Menyetel **Min, Max, Major and Minor units** untuk Secondary Value Axis
9. Sekarang plot seri diagram pertama pada Secondary Value Axis
10. Atur warna isian dinding belakang diagram
11. Atur warna isian area plot diagram
12. Tulis presentasi yang telah dimodifikasi ke file PPTX

```php
  # Buat instance dari kelas Presentation
  $pres = new Presentation();
  try {
    # Mengakses slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Menambahkan diagram contoh
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Mengatur Judul Diagram
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Mengatur format garis kisi utama untuk sumbu nilai
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Mengatur format garis kisi minor untuk sumbu nilai
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Mengatur format angka sumbu nilai
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Mengatur nilai maksimum, minimum diagram
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Mengatur Properti Teks Sumbu Nilai
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Mengatur judul sumbu nilai
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Mengatur format garis kisi utama untuk sumbu Kategori
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Mengatur format garis kisi minor untuk sumbu Kategori
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Mengatur Properti Teks Sumbu Kategori
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Mengatur Judul Kategori
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Mengatur posisi label sumbu kategori
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Mengatur sudut rotasi label sumbu kategori
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Mengatur Properti Teks Legenda
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Mengatur tampilan legenda diagram tanpa menumpuk diagram
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Mengatur sumbu nilai sekunder
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Mengatur format angka sumbu nilai sekunder
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Mengatur nilai maksimum, minimum diagram
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Mengatur warna dinding belakang diagram
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Mengatur warna area Plot
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Simpan Presentasi
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Properti Font untuk Diagram**

Aspose.Slides for PHP via Java menyediakan dukungan untuk mengatur properti terkait font untuk diagram. Silakan ikuti langkah-langkah di bawah ini untuk mengatur properti font diagram.

- Buat objek kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
- Tambahkan diagram pada slide.
- Atur tinggi font .
- Simpan presentasi yang telah dimodifikasi.

Contoh sampel di bawah ini diberikan.

```php
  # Buat instance dari kelas Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Format Numerik**

Aspose.Slides for PHP via Java menyediakan API sederhana untuk mengelola format data diagram:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) .
2. Dapatkan referensi slide berdasarkan indeksnya.
3. Tambahkan diagram dengan data default serta tipe yang diinginkan (contoh ini menggunakan **ChartType::ClusteredColumn**).
4. Atur format angka bawaan dari nilai preset yang tersedia.
5. Lakukan iterasi pada sel data diagram di setiap seri diagram dan atur format angka data diagram.
6. Simpan presentasi.
7. Atur format angka khusus.
8. Lakukan iterasi pada sel data diagram di setiap seri diagram dan atur format angka data diagram yang berbeda.
9. Simpan presentasi.

```php
  # Buat instance dari kelas Presentation
  $pres = new Presentation();
  try {
    # Akses slide presentasi pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Menambahkan diagram kolom berkelompok default
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Mengakses koleksi seri diagram
    $series = $chart->getChartData()->getSeries();
    # Menelusuri setiap seri diagram
    foreach($series as $ser) {
      # Menelusuri setiap sel data dalam seri
      foreach($ser->getDataPoints() as $cell) {
        # Mengatur format angka
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # Menyimpan presentasi
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Nilai format angka preset yang mungkin beserta indeks presetnya dan dapat digunakan ditampilkan di bawah ini:

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

## **Atur Pinggiran Bulat Area Diagram**

Aspose.Slides for PHP via Java menyediakan dukungan untuk mengatur area diagram. Metode [**hasRoundedCorners**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/hasroundedcorners/) dan [**setRoundedCorners**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/setroundedcorners/) telah ditambahkan ke kelas [Chart](https://reference.aspose.com/slides/id/php-java/aspose.slides/Chart) .

1. Buat objek kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) .
2. Tambahkan diagram pada slide.
3. Atur jenis isi dan warna isi diagram
4. Setel properti sudut bulat menjadi True.
5. Simpan presentasi yang telah dimodifikasi.

Contoh sampel di bawah ini diberikan. 

```php
  # Buat instance dari kelas Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat mengatur isian semi-transparan untuk kolom/area sambil menjaga border tetap opak?**

Ya. Transparansi isian dan garis tepi dikonfigurasi secara terpisah. Hal ini berguna untuk meningkatkan keterbacaan grid dan data pada visualisasi yang padat.

**Bagaimana saya dapat menangani label data ketika mereka tumpang tindih?**

Kurangi ukuran font, nonaktifkan komponen label yang tidak penting (misalnya kategori), atur offset/posisi label, tampilkan label hanya untuk titik yang dipilih jika diperlukan, atau ubah format menjadi "value + legend".

**Apakah saya dapat menerapkan isian gradien atau pola pada seri?**

Ya. Baik isian padat maupun gradien/pola biasanya tersedia. Pada praktiknya, gunakan gradien secara terbatas dan hindari kombinasi yang mengurangi kontras dengan grid dan teks.