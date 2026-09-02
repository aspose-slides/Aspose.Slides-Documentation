---
title: Java'da Düşük Kodlu Sunum İşlemleri
linktitle: Düşük Kodlu API
type: docs
weight: 50
url: /tr/java/low-code-presentation-operations/
keywords:
- düşük kodlu sunum API'si
- sunumu dönüştür
- sunumları birleştir
- slaytları yinele
- şekilleri yinele
- metni yinele
- şekilleri topla
- sunumu sıkıştır
- kullanılmayan master slaytları kaldır
- kullanılmayan layout slaytları kaldır
- gömülü fontları sıkıştır
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java'da Aspose.Slides düşük kodlu API'yi kullanarak sunumları dönüştürüp birleştirin, içeriği yineleyin, şekilleri topla ve sunum boyutunu azaltın."
---
## **Genel Bakış**

The [com.aspose.slides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/) package provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/tr/java/com.aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/java/com.aspose.slides/convert/) | Sunumu başka bir biçime dosya‑dosya doğrudan çağrı ile dönüştürmek. |
| [Merger](https://reference.aspose.com/slides/tr/java/com.aspose.slides/merger/) | Aynı biçimdeki tam sunum dosyalarını birleştirmek. |
| [ForEach](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/) | Her slayt, şekil, paragraf veya metin parçası için bir işlem çalıştırmak. |
| [Collect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/collect/) | Tekrar tekrar işleme veya analiz için tüm sunumdaki şekilleri toplamak. |
| [Compress](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/) | Kullanılmayan master ve layoutları kaldırmak ve gömülü font verisini azaltmak. |

## **Bir Sunumu Dönüştürme**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/tr/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/tr/java/com.aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/tr/java/convert-presentation/) for format-specific workflows and options.

## **Sunumları Birleştirme**

Use [Merger.process](https://reference.aspose.com/slides/tr/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) to combine complete presentation files with one call. The input presentations must have the same file format.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/tr/java/merge-presentation/) for those scenarios.

## **Sunum Öğeleri Üzerinde Dolaşma**

The [ForEach](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), and [ForEach.portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) to inspect the corresponding elements:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent‑child control is important.

## **Şekilleri Toplama**

Use [Collect.shapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Use [ForEach.shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **Sunum İçeriğini Sıkıştırma**

The [Compress](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) removes layout slides that no normal slide references.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) removes master slides that are no longer used.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) removes unused characters from embedded fonts.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/tr/java/slide-master/) and [Embedded Font](/slides/tr/java/embedded-font/).

## **SSS**

**When should I use the low-code API instead of the full object model?**  
Low-code yardımcıları, standart bir işlem tüm dosya veya sunuma uygulanıyor ve bireysel öğeler üzerinde ayrıntılı kontrol gerektirmiyorsa kullanın. Bireysel slaytları seçmeniz, master‑layout ilişkilerini yönetmeniz, ara durumu incelemeniz veya yardımcı tarafından sunulmayan davranışları yapılandırmanız gerektiğinde tam nesne modelini kullanın.

**Can Merger combine presentations in different file formats?**  
Hayır. [Merger.process](https://reference.aspose.com/slides/tr/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) aynı biçimdeki giriş sunumlarını gerektirir. Önce giriş dosyalarını ortak bir biçime dönüştürün, örneğin [Convert.autoByExtension](https://reference.aspose.com/slides/tr/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) ile, ardından dönüştürülmüş dosyaları birleştirin.

**Does ForEach process master, layout, and notes slides?**  
[ForEach.slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) normal sunum slaytlarını iterasyona alır. Sunum‑geneli [ForEach.shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), ve [ForEach.portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) işlemleri varsayılan olarak normal, master ve layout slaytlarını içerir. Not slaytlarını da dahil etmek için `includeNotes` parametresi `true` olarak ayarlanmış aşırı yüklemelerini kullanın.

**What is the difference between ForEach.shape and Collect.shapes?**  
[ForEach.shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) her şekli anında bir geri çağrı ile işlemek içindir. [Collect.shapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) ise şekilleri bir koleksiyon olarak elde edip daha sonra filtreleme, sayma veya birden çok kez dolaşma ihtiyacınız olduğunda kullanılır.

**Does Compress always make the presentation file smaller?**  
Her zaman değildir. Sonuç, sunumda kullanılmayan layoutlar, kullanılmayan masterlar veya kullanılmayan karakterlere sahip gömülü fontlar olup olmamasına bağlıdır. Bu öğeler yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/) işlemleri dosya boyutunu azaltmayabilir.

**Are changes made by ForEach or Compress saved automatically?**  
Hayır. Bu yardımcılar, bellekte yüklü olan [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach](https://reference.aspose.com/slides/tr/java/com.aspose.slides/foreach/) geri çağrısında veya bir [Compress](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/) çalıştırdıktan sonra sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metodunu çağırın.

## **Related Articles**

- [Convert Presentation](/slides/tr/java/convert-presentation/)
- [Merge Presentations](/slides/tr/java/merge-presentation/)
- [Slide Master](/slides/tr/java/slide-master/)
- [Manage Text Box](/slides/tr/java/manage-textbox/)
- [Embedded Font](/slides/tr/java/embedded-font/)