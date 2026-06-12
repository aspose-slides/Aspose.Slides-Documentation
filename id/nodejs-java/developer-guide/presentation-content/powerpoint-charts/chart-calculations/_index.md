---
title: Optimalkan Perhitungan Diagram untuk Presentasi dalam JavaScript
linktitle: Perhitungan Diagram
type: docs
weight: 50
url: /id/nodejs-java/chart-calculations/
keywords:
- perhitungan diagram
- elemen diagram
- posisi elemen
- posisi aktual
- elemen anak
- elemen induk
- nilai diagram
- nilai aktual
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pahami perhitungan diagram, pembaruan data, dan kontrol presisi di Aspose.Slides untuk Node.js untuk PPT dan PPTX, dengan contoh kode JavaScript yang praktis."
---
## **Gambaran Umum**

Aspose.Slides menyediakan API untuk bekerja dengan perhitungan diagram dan data tata letak dalam presentasi. Artikel ini menunjukkan cara mengambil nilai aktual elemen diagram, termasuk posisi dan ukuran sebenarnya dari elemen serta nilai aktual sumbu diagram. Artikel ini juga menjelaskan bahwa nilai-nilai ini diisi setelah validasi tata letak diagram.

Selain itu, artikel ini memperlihatkan cara mendapatkan posisi aktual elemen diagram induk dan cara menyembunyikan komponen diagram seperti judul, sumbu, legenda, dan garis kisi. Bersama-sama, contoh-contoh ini membantu Anda memeriksa informasi tata letak diagram dan mengendalikan visibilitas elemen diagram dalam presentasi PowerPoint secara programatis.

## **Hitung Nilai Aktual Elemen Diagram**

Aspose.Slides untuk Node.js melalui Java menyediakan API sederhana untuk mendapatkan properti ini. Properti kelas [Axis](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Axis) memberikan informasi tentang posisi aktual elemen sumbu diagram ([Axis.getActualMaxValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Perlu memanggil metode [Chart.validateChartLayout()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Chart#validateChartLayout--) sebelumnya untuk mengisi properti dengan nilai aktual.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hitung Posisi Aktual Elemen Diagram Induk**

Aspose.Slides untuk Node.js melalui Java menyediakan API sederhana untuk mendapatkan properti ini. Properti kelas `ActualLayout` memberikan informasi tentang posisi aktual elemen diagram induk `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. Perlu memanggil metode [Chart.validateChartLayout()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Chart#validateChartLayout--) sebelumnya untuk mengisi properti dengan nilai aktual.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sembunyikan Informasi dari Diagram**

Topik ini membantu Anda memahami cara menyembunyikan informasi dari diagram. Menggunakan Aspose.Slides untuk Node.js melalui Java Anda dapat menyembunyikan **Title, Vertical Axis, Horizontal Axis** dan **Grid Lines** dari diagram. Contoh kode di bawah ini menunjukkan cara menggunakan properti ini.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Menyembunyikan Judul diagram
    chart.setTitle(false);
    // /Menyembunyikan sumbu Nilai
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Visibilitas Sumbu Kategori
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Menyembunyikan Legenda
    chart.setLegend(false);
    // Menyembunyikan Garis Kisi Utama
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Mengatur warna garis seri
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah buku kerja Excel eksternal dapat digunakan sebagai sumber data, dan bagaimana hal itu memengaruhi perhitungan ulang?**

Ya. Diagram dapat merujuk ke buku kerja eksternal: ketika Anda menyambungkan atau menyegarkan sumber eksternal, formula dan nilai diambil dari buku kerja tersebut, dan diagram mencerminkan pembaruan selama operasi membuka/mengedit. API memungkinkan Anda [specify the external workbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) path dan mengelola data yang ditautkan.

**Apakah saya dapat menghitung dan menampilkan garis tren tanpa harus mengimplementasikan regresi sendiri?**

Ya. [Trendlines](/slides/id/nodejs-java/trend-line/) (linear, eksponensial, dan lain-lain) ditambahkan dan diperbarui oleh Aspose.Slides; parameternya dihitung ulang dari data seri secara otomatis, sehingga Anda tidak perlu mengimplementasikan perhitungan Anda sendiri.

**Jika sebuah presentasi memiliki beberapa diagram dengan tautan eksternal, dapatkah saya mengontrol buku kerja mana yang digunakan setiap diagram untuk nilai yang dihitung?**

Ya. Setiap diagram dapat menunjuk ke [external workbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) miliknya sendiri, atau Anda dapat membuat/mengganti buku kerja eksternal per diagram secara independen dari diagram lainnya.