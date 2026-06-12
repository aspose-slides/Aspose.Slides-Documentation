---
title: Diagram
type: docs
weight: 60
url: /id/androidjava/examples/elements/chart/
keywords:
- contoh kode
- diagram
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kuasi diagram dengan Aspose.Slides untuk Android: buat, format, hubungkan data, dan ekspor diagram dalam format PPT, PPTX, dan ODP dengan contoh Java."
---
Contoh untuk menambahkan, mengakses, menghapus, dan memperbarui berbagai jenis diagram dengan **Aspose.Slides for Android via Java**. Potongan kode di bawah menunjukkan operasi dasar diagram.

## **Tambah Diagram**

Metode ini menambahkan diagram area sederhana ke slide pertama.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Tambahkan diagram area sederhana ke slide pertama.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Diagram**

Setelah membuat diagram, Anda dapat mengambilnya melalui koleksi shape.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Akses diagram pertama pada slide.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Diagram**

Kode berikut menghapus diagram dari sebuah slide.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Hapus diagram.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Perbarui Data Diagram**

Anda dapat mengubah properti diagram seperti judul.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Ubah judul diagram.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```