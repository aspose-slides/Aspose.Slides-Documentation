---
title: Diagram
type: docs
weight: 60
url: /id/java/examples/elements/chart/
keywords:
- contoh kode
- diagram
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kuasi diagram dengan Aspose.Slides for Java: buat, format, hubungkan data, dan ekspor diagram dalam format PPT, PPTX, dan ODP dengan contoh Java."
---
Contoh menambah, mengakses, menghapus, dan memperbarui berbagai jenis diagram dengan **Aspose.Slides for Java**. Cuplikan kode di bawah menunjukkan operasi dasar diagram.

## **Add a Chart**
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

## **Access a Chart**
Setelah membuat diagram, Anda dapat mengambilnya melalui koleksi bentuk.

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

## **Remove a Chart**
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

## **Update Chart Data**
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