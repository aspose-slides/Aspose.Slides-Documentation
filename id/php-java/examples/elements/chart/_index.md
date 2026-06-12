---
title: Diagram
type: docs
weight: 60
url: /id/php-java/examples/elements/chart/
keywords:
- diagram
- menambahkan diagram
- mengakses diagram
- menghapus diagram
- memperbarui diagram
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Buat dan sesuaikan diagram di PHP dengan Aspose.Slides: tambahkan data, formatkan seri, sumbu, dan label, ubah tipe, serta ekspor—berfungsi dengan PPT, PPTX, dan ODP."
---
Contoh untuk menambahkan, mengakses, menghapus, dan memperbarui berbagai jenis diagram dengan **Aspose.Slides for PHP via Java**. Potongan kode di bawah ini menunjukkan operasi diagram dasar.

## **Menambahkan Diagram**

Metode ini menambahkan diagram area sederhana ke slide pertama.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Tambahkan diagram kolom sederhana ke slide.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mengakses Diagram**

Ambil diagram dari koleksi shape.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Akses diagram pertama pada slide.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Menghapus Diagram**

Kode berikut menghapus diagram dari sebuah slide.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengasumsikan bentuk pertama pada slide adalah diagram.
        $chart = $slide->getShapes()->get_Item(0);

        // Hapus diagram.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Memperbarui Data Diagram**

Anda dapat mengubah properti diagram seperti judul.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengasumsikan bentuk pertama pada slide adalah diagram.
        $chart = $slide->getShapes()->get_Item(0);

        // Ubah judul diagram.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```