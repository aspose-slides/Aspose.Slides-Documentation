---
title: Animasi Diagram PowerPoint dalam JavaScript
linktitle: Diagram Animasi
type: docs
weight: 80
url: /id/nodejs-java/animated-charts/
keywords:
- diagram
- diagram animasi
- animasi diagram
- seri diagram
- kategori diagram
- elemen seri
- elemen kategori
- menambahkan efek
- tipe efek
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat diagram animasi yang menakjubkan dalam JavaScript dengan Aspose.Slides untuk Node.js. Tingkatkan presentasi dengan visual dinamis dalam file PPT dan PPTX—mulailah sekarang."
---
## **Pendahuluan**

Aspose.Slides for Node.js via Java mendukung animasi elemen diagram. **Series**, **Categories**, **Series Elements**, **Categories Elements** dapat dianimasikan dengan metode [Sequence.addEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/#addEffect) dan dua enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effectchartmajorgroupingtype/) serta [EffectChartMinorGroupingType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effectchartminorgroupingtype/).

## **Animasi Seri Diagram**
Jika Anda ingin menganimasikan seri diagram, tulis kode sesuai langkah‑langkah berikut:

1. Muat presentasi.  
1. Dapatkan referensi objek diagram.  
1. Animasi seri.  
1. Tulis file presentasi ke disk.

Dalam contoh di bawah ini, kami menganimasikan seri diagram.

```javascript
// Instansiasi kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Dapatkan referensi objek diagram
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animasi seri
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Tulis presentasi yang dimodifikasi ke disk
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animasi Kategori Diagram**
Jika Anda ingin menganimasikan kategori diagram, tulis kode sesuai langkah‑langkah berikut:

1. Muat presentasi.  
1. Dapatkan referensi objek diagram.  
1. Animasi kategori.  
1. Tulis file presentasi ke disk.

Dalam contoh di bawah ini, kami menganimasikan kategori diagram.

```javascript
// Instansiasi kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    pres.save("Sample_Animation_C.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animasi pada Elemen Seri**
Jika Anda ingin menganimasikan elemen‑elemen seri, tulis kode sesuai langkah‑langkah berikut:

1. Muat presentasi.  
1. Dapatkan referensi objek diagram.  
1. Animasi elemen seri.  
1. Tulis file presentasi ke disk.

Dalam contoh di bawah ini, kami telah menganimasikan elemen‑elemen seri.

```javascript
// Instansiasi kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Dapatkan referensi objek diagram
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animasi elemen seri
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Tulis file presentasi ke disk
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animasi pada Elemen Kategori**
Jika Anda ingin menganimasikan elemen‑elemen kategori, tulis kode sesuai langkah‑langkah berikut:

1. Muat presentasi.  
1. Dapatkan referensi objek diagram.  
1. Animasi elemen kategori.  
1. Tulis file presentasi ke disk.

Dalam contoh di bawah ini, kami telah menganimasikan elemen‑elemen kategori.

```javascript
// Instansiasi kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Dapatkan referensi objek diagram
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animasi elemen kategori
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Tulis file presentasi ke disk
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah tipe efek berbeda (mis., masuk, penekanan, keluar) didukung untuk diagram seperti pada bentuk biasa?**

Ya. Diagram diperlakukan sebagai bentuk, sehingga mendukung tipe efek animasi standar, termasuk masuk, penekanan, dan keluar, dengan kontrol penuh melalui timeline slide dan urutan animasi.

**Apakah saya dapat menggabungkan animasi diagram dengan transisi slide?**

Ya. [Transitions](/slides/id/nodejs-java/slide-transition/) diterapkan pada slide, sementara efek animasi diterapkan pada objek di dalam slide. Anda dapat menggunakan keduanya bersamaan dalam satu presentasi dan mengendalikan mereka secara independen.

**Apakah animasi diagram tetap terjaga saat menyimpan ke PPTX?**

Ya. Saat Anda [save to PPTX](/slides/id/nodejs-java/save-presentation/), semua efek animasi dan urutannya tetap terjaga karena mereka merupakan bagian dari model animasi native presentasi.

**Apakah saya dapat membaca animasi diagram yang ada dari presentasi dan memodifikasinya?**

Ya. API menyediakan akses ke timeline slide, urutan, dan efek, memungkinkan Anda memeriksa animasi diagram yang ada dan menyesuaikannya tanpa harus membuat semuanya dari awal.

**Apakah saya dapat menghasilkan video yang mencakup animasi diagram menggunakan Aspose.Slides?**

Ya. Anda dapat [export a presentation to video](/slides/id/nodejs-java/convert-powerpoint-to-video/) sambil mempertahankan animasi, mengonfigurasi durasi dan pengaturan ekspor lainnya sehingga klip yang dihasilkan memuat pemutaran animasi.