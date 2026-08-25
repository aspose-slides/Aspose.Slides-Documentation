---
title: Operasi Presentasi Low-Code di PHP
linktitle: API Low-Code
type: docs
weight: 50
url: /id/php-java/low-code-presentation-operations/
keywords:
- API presentasi low-code
- konversi presentasi
- gabungkan presentasi
- iterasi slide
- iterasi shape
- iterasi teks
- kumpulkan shape
- kompres presentasi
- hapus master slide yang tidak terpakai
- hapus layout slide yang tidak terpakai
- kompres font tertanam
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Gunakan API low-code Aspose.Slides di PHP untuk mengonversi dan menggabungkan presentasi, mengiterasi konten, mengumpulkan shape, dan mengurangi ukuran presentasi."
---
## **Gambaran Umum**

The [aspose.slides](https://reference.aspose.com/slides/id/php-java/aspose.slides/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/id/php-java/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Pembantu | Untuk apa |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/id/php-java/aspose.slides/convert/) | Mengonversi presentasi ke format lain dengan panggilan file-ke-file langsung. |
| [Merger](https://reference.aspose.com/slides/id/php-java/aspose.slides/merger/) | Menggabungkan file presentation lengkap dengan format yang sama. |
| [ForEach_](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/) | Menjalankan callback untuk setiap slide, shape, paragraf, atau bagian teks. |
| [Collect](https://reference.aspose.com/slides/id/php-java/aspose.slides/collect/) | Mengambil shape dari seluruh presentasi untuk pemrosesan atau analisis berulang. |
| [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/) | Menghapus master dan layout yang tidak terpakai serta mengurangi data font yang disematkan. |

## **Mengonversi Presentasi**

Use [Convert::autoByExtension](https://reference.aspose.com/slides/id/php-java/aspose.slides/convert/#autoByExtension) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/id/php-java/aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/id/php-java/convert-presentation/) for format-specific workflows and options.

## **Menggabungkan Presentasi**

Use [Merger::process](https://reference.aspose.com/slides/id/php-java/aspose.slides/merger/#process) to combine complete presentation files with one call. The input presentations must have the same file format.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/id/php-java/merge-presentation/) for those scenarios.

## **Iterasi Elemen Presentasi**

The [ForEach_](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach_::slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#paragraph), and [ForEach_::portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#portion) to inspect the corresponding elements:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **Kumpulkan Shape**

Use [Collect::shapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/collect/#shapes) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Use [ForEach_::shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#shape) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **Kompres Konten Presentasi**

The [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) removes layout slides that no normal slide references.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#removeUnusedMasterSlides) removes master slides that are no longer used.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#compressEmbeddedFonts) removes unused characters from embedded fonts.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/id/php-java/slide-master/) and [Embedded Font](/slides/id/php-java/embedded-font/).

## **FAQ**

**Kapan saya harus menggunakan API low-code alih-alih model objek lengkap?**

Gunakan pembantu low-code ketika operasi standar berlaku pada file atau presentasi lengkap dan tidak memerlukan kontrol detail atas elemen individual. Gunakan model objek lengkap ketika Anda perlu memilih slide tertentu, mengontrol hubungan master dan layout, memeriksa keadaan menengah, atau mengonfigurasi perilaku yang tidak disediakan oleh pembantu.

**Apakah Merger dapat menggabungkan presentasi dalam format file yang berbeda?**

Tidak. [Merger::process](https://reference.aspose.com/slides/id/php-java/aspose.slides/merger/#process) memerlukan presentasi masukan dalam format yang sama. Konversi file masukan ke format umum terlebih dahulu, misalnya dengan [Convert::autoByExtension](https://reference.aspose.com/slides/id/php-java/aspose.slides/convert/#autoByExtension), lalu gabungkan file yang telah dikonversi.

**Apakah ForEach_ memproses slide master, layout, dan catatan?**

[ForEach_::slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#slide) mengiterasi slide presentasi normal. Operasi [ForEach_::shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#paragraph), dan [ForEach_::portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#portion) pada seluruh presentasi mencakup slide normal, master, dan layout secara default. Gunakan overload mereka dengan `includeNotes` diset ke `true` untuk menyertakan slide catatan.

**Apa perbedaan antara ForEach_::shape dan Collect::shapes?**

Gunakan [ForEach_::shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#shape) untuk memproses setiap shape secara langsung melalui callback. Gunakan [Collect::shapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/collect/#shapes) ketika Anda memerlukan hasil yang dapat diiterasi, disimpan, difilter, dihitung, atau ditelusuri berulang kali.

**Apakah Compress selalu membuat file presentasi lebih kecil?**

Tidak selalu. Hasilnya tergantung apakah presentasi berisi layout yang tidak terpakai, master yang tidak terpakai, atau font yang disematkan dengan karakter yang tidak terpakai. Jika tidak ada yang demikian, operasi [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/) yang bersangkutan mungkin tidak mengurangi ukuran file.

**Apakah perubahan yang dilakukan oleh ForEach_ atau Compress disimpan secara otomatis?**

Tidak. Pembantu ini beroperasi pada objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang dimuat di memori. Setelah mengubah elemen dalam callback [ForEach_](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/), atau menjalankan [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/), panggil [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) untuk menulis hasilnya.

## **Artikel Terkait**

- [Konversi Presentasi](/slides/id/php-java/convert-presentation/)
- [Menggabungkan Presentasi](/slides/id/php-java/merge-presentation/)
- [Master Slide](/slides/id/php-java/slide-master/)
- [Kelola Kotak Teks](/slides/id/php-java/manage-textbox/)
- [Font Tertanam](/slides/id/php-java/embedded-font/)