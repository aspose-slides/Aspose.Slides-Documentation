---
title: Optimalkan Perhitungan Diagram untuk Presentasi di Java
linktitle: Perhitungan Diagram
type: docs
weight: 50
url: /id/java/chart-calculations/
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
- Java
- Aspose.Slides
description: "Pahami perhitungan diagram, pembaruan data, dan kontrol presisi dalam Aspose.Slides for Java untuk PPT dan PPTX, dengan contoh kode Java yang praktis."
---
## **Gambaran Umum**

Aspose.Slides menyediakan API untuk bekerja dengan perhitungan diagram dan data tata letak dalam presentasi. Artikel ini menunjukkan cara mengambil nilai aktual elemen diagram, termasuk posisi dan ukuran sebenarnya dari elemen yang mengimplementasikan `IActualLayout` serta nilai aktual sumbu diagram. Artikel ini juga menjelaskan bahwa nilai‑nilai tersebut diisi setelah validasi tata letak diagram.

Selain itu, artikel ini memperlihatkan cara mendapatkan posisi aktual elemen diagram induk dan cara menyembunyikan komponen diagram seperti judul, sumbu, legenda, dan garis kisi. Bersama‑sama, contoh‑contoh ini membantu Anda memeriksa informasi tata letak diagram dan mengendalikan visibilitas elemen diagram dalam presentasi PowerPoint secara programatis.

## **Hitung Nilai Aktual Elemen Diagram**

Aspose.Slides for Java menyediakan API sederhana untuk mendapatkan properti‑properti ini. Properti dari antarmuka [IAxis](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAxis) memberikan informasi tentang posisi aktual elemen sumbu diagram ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Anda harus memanggil metode [IChart.validateChartLayout()](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChart#validateChartLayout--) terlebih dahulu untuk mengisi properti‑properti dengan nilai aktual.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hitung Posisi Aktual Elemen Diagram Induk**

Aspose.Slides for Java menyediakan API sederhana untuk mendapatkan properti‑properti ini. Properti dari antarmuka [IActualLayout](https://reference.aspose.com/slides/id/java/com.aspose.slides/IActualLayout) memberikan informasi tentang posisi aktual elemen diagram induk ([IActualLayout.getActualX](https://reference.aspose.com/slides/id/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/id/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/id/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/id/java/com.aspose.slides/IActualLayout#getActualHeight--)). Anda harus memanggil metode [IChart.validateChartLayout()](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChart#validateChartLayout--) terlebih dahulu untuk mengisi properti‑properti dengan nilai aktual.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sembunyikan Elemen Diagram**

Topik ini membantu Anda memahami cara menyembunyikan informasi dari diagram. Menggunakan Aspose.Slides for Java Anda dapat menyembunyikan **Judul, Sumbu Vertikal, Sumbu Horizontal** dan **Garis Kisi** dari diagram. Contoh kode di bawah ini menunjukkan cara menggunakan properti‑properti tersebut.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Menyembunyikan Judul diagram
    chart.setTitle(false);

    ///Menyembunyikan sumbu Nilai
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Visibilitas Sumbu Kategori
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Menyembunyikan Legenda
    chart.setLegend(false);

    //Menyembunyikan Garis Kisi Utama
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Menetapkan warna garis seri
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah buku kerja Excel eksternal dapat berfungsi sebagai sumber data, dan bagaimana hal itu memengaruhi perhitungan ulang?**

Ya. Sebuah diagram dapat merujuk ke buku kerja eksternal: ketika Anda menyambungkan atau menyegarkan sumber eksternal, rumus dan nilai diambil dari buku kerja tersebut, dan diagram mencerminkan pembaruan selama operasi buka/sunting. API memungkinkan Anda [menentukan jalur buku kerja eksternal](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) dan mengelola data yang ditautkan.

**Apakah saya dapat menghitung dan menampilkan garis tren tanpa harus mengimplementasikan regresi sendiri?**

Ya. [Garis tren](/slides/id/java/trend-line/) (linier, eksponensial, dan lainnya) ditambahkan serta diperbarui oleh Aspose.Slides; parameternya dihitung ulang secara otomatis dari data seri, jadi Anda tidak perlu mengimplementasikan perhitungan Anda sendiri.

**Jika sebuah presentasi memiliki beberapa diagram dengan tautan eksternal, dapatkah saya mengendalikan buku kerja mana yang digunakan masing‑masing diagram untuk nilai yang dihitung?**

Ya. Setiap diagram dapat menunjuk ke [buku kerja eksternal](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) miliknya sendiri, atau Anda dapat membuat/mengganti buku kerja eksternal per diagram secara independen dari yang lain.