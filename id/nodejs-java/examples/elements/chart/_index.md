---
title: Bagan
type: docs
weight: 60
url: /id/nodejs-java/examples/elements/chart/
keywords:
- contoh kode
- bagan
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kuasi pembuatan bagan dengan Aspose.Slides untuk Node.js via Java: buat, format, hubungkan data, dan ekspor bagan dalam PPT, PPTX, dan ODP dengan contoh JavaScript."
---
Contoh menambah, mengakses, menghapus, dan memperbarui berbagai tipe bagan dengan **Aspose.Slides for Node.js via Java**. Potongan kode di bawah menunjukkan operasi dasar bagan.

## **Menambahkan Bagan**

Metode ini menambahkan bagan area sederhana ke slide pertama.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Tambahkan bagan area sederhana ke slide pertama.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Bagan**

Setelah membuat bagan, Anda dapat mengambilnya melalui koleksi shape.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Akses bagan pertama pada slide.
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Bagan**

Kode berikut menghapus bagan dari slide.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Hapus bagan.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Perbarui Data Bagan**

Anda dapat mengubah properti bagan seperti judul.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Ubah judul bagan.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```