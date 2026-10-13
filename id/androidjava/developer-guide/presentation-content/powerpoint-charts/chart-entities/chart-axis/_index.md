---
title: Sesuaikan Sumbu Diagram dalam Presentasi di Android
linktitle: Sumbu Diagram
type: docs
url: /id/androidjava/chart-axis/
keywords:
- sumbu diagram
- sumbu vertikal
- sumbu horizontal
- sesuaikan sumbu
- manipulasi sumbu
- kelola sumbu
- properti sumbu
- nilai maksimum
- nilai minimum
- garis sumbu
- format tanggal
- judul sumbu
- posisi sumbu
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Temukan cara menggunakan Aspose.Slides untuk Android via Java untuk menyesuaikan sumbu diagram dalam presentasi PowerPoint untuk laporan dan visualisasi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan sumbu diagram dengan Aspose.Slides untuk Android via Java. Ini mencakup nilai sumbu yang dihitung, menukar baris dan kolom diagram, visibilitas sumbu, interval label kategori dan tanda centang, kategori tanggal dan pemformatannya, rotasi judul, posisi sumbu, satuan tampilan, dan skala logaritmik.

## **Dapatkan Nilai Maksimum pada Sumbu Vertikal pada Diagram**

Buat sebuah [Presentasi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) dan tambahkan diagram area dengan data bawaan. Panggil [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) sebelum membaca nilai sumbu yang dihitung agar tata letak diagram terbaru.

Baca [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) dan [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) untuk batas sumbu, serta [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) dan [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) untuk interval tanda. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) dan [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) menyediakan skala satuan waktu, yang relevan untuk sumbu tanggal. Contoh ini menyimpan nilai‑nilai tersebut dalam variabel lokal dan menyimpan diagram.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menukar Data antara Sumbu**

Gunakan [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) untuk menukar peran seri dan kategori dalam data diagram. Setiap kategori lama menjadi seri, dan tiap seri lama menjadi kategori. Ini mengubah cara data dikelompokkan; tidak menukar sumbu horizontal dan vertikal. Contoh ini menggunakan [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) untuk mengikat data bawaan ke `Sheet1!A1:D5`, termasuk baris judul dan kolom kategori, sebelum menukar baris dan kolom. Itu menyimpan diagram dengan empat seri dan tiga kategori.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menonaktifkan Sumbu Vertikal untuk Diagram Garis**

Panggil [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) dengan `false` pada sumbu vertikal untuk menyembunyikannya. Contoh ini membuat diagram garis dengan data bawaan dan menyimpannya dengan sumbu vertikal tersembunyi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menonaktifkan Sumbu Horizontal untuk Diagram Garis**

Panggil [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) dengan `false` pada sumbu horizontal untuk menyembunyikannya. Contoh ini membuat diagram garis dengan data bawaan dan menyimpannya dengan sumbu horizontal tersembunyi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengubah Sumbu Kategori**

Gunakan [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) untuk memilih sumbu kategori tanggal atau teks. Contoh ini memerlukan `ExistingChart.pptx`, dengan diagram sebagai bentuk pertama pada slide pertama dan sel kategori berisi nilai tanggal Excel numerik. Ia mengubah sumbu horizontal menjadi sumbu tanggal. Memanggil [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) dengan `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) dengan `1`, dan [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) dengan `TimeUnitType.Months` menempatkan tanda utama pada interval satu bulan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengontrol Interval Label Sumbu Kategori**

Ketika diagram memiliki banyak kategori, kurangi jumlah label sumbu yang terlihat tanpa menghapus kategori atau titik data. Panggil [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) dengan `false`, lalu berikan interval kategori yang diinginkan ke [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Untuk kategori teks dalam urutan normal, penghitungan dimulai dari kategori pertama:

| Interval | Label yang ditampilkan dalam contoh |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Interval `3` menampilkan setiap label ketiga, meninggalkan dua label tersembunyi di antara label yang ditampilkan. Ini tidak menghapus kolom yang bersangkutan. Penempatan otomatis memilih interval berdasarkan ruang yang tersedia; tidak harus menampilkan setiap label.

Tanda centang memiliki kontrol terpisah. Panggil [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) dengan `false` dan gunakan [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) untuk mengatur intervalnya. Misalnya, `1` mempertahankan tanda centang pada setiap interval kategori sementara label muncul hanya setiap kategori ketiga. Gunakan [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) dengan gaya yang terlihat agar Anda dapat melihat hasilnya. Memanggil salah satu pengatur penempatan otomatis dengan `true` lagi membiarkan diagram memilih interval itu kembali.

Contoh mandiri berikut membuat 24 kategori dan satu seri, lalu menyimpan tiga slide dalam `CategoryAxisIntervals.pptx`: penempatan otomatis, penempatan label manual dengan tanda centang independen, dan pemulihan penempatan otomatis. Kedua salinan mempertahankan data diagram asli. Tidak diperlukan presentasi masukan. Teks label horizontal memudahkan melihat perbedaan kepadatan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Slide 2: tampilkan setiap label ketiga, tetapi pertahankan tanda centang untuk setiap kategori.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Slide 3: biarkan diagram memilih kedua interval lagi.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Penempatan otomatis (slide 1):** Pada render ini, setiap label kategori kedua ditampilkan dan dibungkus menjadi dua baris. Hasil otomatis dapat bervariasi tergantung pada ukuran diagram, font, dan renderer.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Penempatan manual (slide 2):** Setiap label ketiga ditampilkan dalam satu baris, sementara tanda centang tetap pada setiap interval kategori. Semua 24 kolom, termasuk yang tanpa label, tetap terlihat dengan nilai yang sama. Slide 3 memulihkan tampilan otomatis seperti di atas.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Pilih Sumbu dan Interval yang Tepat**

Gunakan interval hitung‑kategori ini untuk sumbu kategori teks, seperti sumbu kategori pada diagram kolom, garis, area, atau batang. Pada diagram kolom, itu adalah sumbu horizontal. Pada diagram batang horizontal, sumbu kategori berada secara vertikal, jadi terapkan pengaturan ini pada sumbu yang dikembalikan oleh [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Penempatan interval tanda centang juga berlaku pada sumbu seri dalam diagram yang memilikinya.

Jangan gunakan penempatan label kategori untuk mengatur skala numerik sumbu nilai. Pada sumbu nilai, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) menentukan selisih nilai: misalnya, satuan utama `10` menghasilkan tanda pada 0, 10, 20, dan seterusnya ketika sumbu dimulai dari nol. Interval label kategori `3` malah menghitung posisi kategori, terlepas dari nilai datanya. Diagram pencar dan gelembung menggunakan sumbu nilai bukan sumbu kategori teks. Untuk sumbu tanggal, gunakan satuan utama berbasis waktu dan skala seperti dijelaskan pada [Mengubah Sumbu Kategori](#change-a-category-axis).

## **Atur Format Tanggal untuk Nilai Sumbu Kategori**

Contoh ini menggantikan data diagram bawaan dengan empat nilai tahunan. Tanggal disimpan sebagai nomor seri OLE Automation pada lembar kerja pertama (indeks `0`), dihitung sebagai jumlah hari sejak 30 Desember 1899, untuk tanggal‑tanggal ini. Kedua kalender menggunakan UTC dan dibersihkan sebelum menetapkan tanggal sehingga daylight saving time dan waktu hari ini tidak memengaruhi perhitungan. Gunakan [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) dengan `CategoryAxisType.Date`, panggil [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) dengan `false`, dan berikan `yyyy` ke [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) sehingga label kategori menampilkan tahun empat digit secara independen dari pemformatan sel.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Sudut Rotasi untuk Judul Sumbu Diagram**

Panggil [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) dengan `true` pada sumbu vertikal, berikan teks judul, dan gunakan [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) untuk memutar judul. Sudut diukur dalam derajat; contoh ini menyimpan diagram kolom dengan judul sumbu nilai diputar 90 derajat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Posisi Sumbu pada Sumbu Kategori atau Nilai**

Gunakan [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) untuk mengontrol apakah sumbu nilai melintasi sumbu kategori di antara kategori atau pada tanda centang kategori. Pengaturan ini berlaku pada sumbu kategori. Contoh mengaturnya ke `true` pada sumbu kategori horizontal diagram kolom dan menyimpan hasilnya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Satuan Tampilan pada Sumbu Nilai Diagram**

Gunakan [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) untuk mengubah skala label pada sumbu nilai tanpa mengubah data dasarnya. Dengan [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) disetel ke `Millions`, nilai 60.000.000 ditampilkan sebagai 60. Contoh ini membuat diagram kolom dan menerapkan satuan tampilan jutaan pada sumbu vertikalnya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Konfigurasi Sumbu Nilai Logaritmik**

Sumbu nilai logaritmik berguna ketika nilai positif mencakup beberapa orde besaran. Misalnya, sebuah layanan mungkin menerima 10, 100, 1.000, 10.000, dan 100.000 permintaan selama lima periode. Pada skala linear, nilai kecil tampak berdekatan di dekat nol. Skala logaritmik memudahkan membandingkan pertumbuhan relatif mereka: jarak yang sama mewakili rasio yang sama, bukan selisih yang sama.

Panggil [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) dengan `true` pada sumbu nilai dan gunakan [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) untuk memilih basis. Ini mengubah cara nilai yang ada ditampilkan; tidak mengubah data atau menambahkan garis tren logaritmik. Garis tren mewakili hubungan yang dipasangkan pada data dan merupakan fitur terpisah.

### **Pilih Sumbu Nilai dan Basisnya**

Untuk diagram garis atau kolom, sumbu nilai dikembalikan oleh [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Untuk diagram batang horizontal, itu dikembalikan oleh [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Diagram pencar dan gelembung memiliki dua sumbu nilai, jadi pilih sumbu horizontal untuk nilai X, sumbu vertikal untuk nilai Y, atau keduanya. Jangan terapkan skala logaritmik pada sumbu kategori.

Basis logaritmik bawaan adalah `10`. Untuk diagram PPTX, gunakan basis antara `2` hingga `1000`, inklusif; basis pecahan seperti `2.5` juga didukung. Dengan basis `10`, pangkat berurutan seperti 10, 100, 1.000, dan 10.000 berjarak sama.

### **Bandingkan Skala Linear dan Logaritmik**

Contoh mandiri berikut membuat diagram garis dengan lima hitungan permintaan pada slide pertama, kemudian menggandakan slide tersebut dan mengaktifkan sumbu nilai logaritmik basis‑10 pada slide kedua. Kedua slide mempertahankan data yang sama.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Pertahankan slide pertama linear dan ubah hanya skala sumbu nilai salinan.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Skala linear (slide 1):** Jarak vertikal yang sama mewakili perbedaan yang sama dalam hitungan permintaan. Nilai terbesar mendominasi diagram, membuat nilai kecil sulit dibedakan.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Skala logaritmik (slide 2):** Jarak vertikal yang sama mewakili rasio yang sama. Setiap periode memiliki sepuluh kali lebih banyak permintaan daripada periode sebelumnya, sehingga titik‑titik membentuk garis naik lurus pada skala basis‑10. Label sumbu masih menunjukkan hitungan permintaan asli.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Tangani Nilai Nol dan Negatif**

Skala logaritmik hanya dapat menampilkan nilai yang benar‑benar positif. Periksa data sebelum mengaktifkannya. Jika nilai nol atau negatif memiliki arti, pertahankan skala linear atau tampilkan secara terpisah. Jika mengeluarkan nilai‑nilai tersebut memang tepat untuk analisis, jelaskan penghilangan tersebut. Jangan diam‑diam menggantinya dengan angka positif kecil, karena hal itu mengubah makna data. Setiap minimum atau maksimum yang dikonfigurasi secara manual untuk sumbu logaritmik juga harus positif.

## **FAQ**

**Bagaimana cara mengatur nilai di mana satu sumbu memotong sumbu lainnya (crossing sumbu)?**

Gunakan [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) untuk memilih perilaku pemotongan. Untuk menentukan nilai pemotongan numerik, gunakan [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Pengaturan ini memungkinkan Anda memindahkan pemotongan sumbu ke baseline yang sesuai.

**Bagaimana cara memposisikan label tanda relatif terhadap sumbu?**

Panggil [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) menggunakan [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, atau `None`. Untuk mengontrol tanda centang itu sendiri, gunakan [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) atau [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); ini terpisah dari posisi label.