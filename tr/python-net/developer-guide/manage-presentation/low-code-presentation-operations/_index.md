---
title: Python'da Düşük Kodlu Sunum İşlemleri
linktitle: Düşük Kodlu API
type: docs
weight: 50
url: /tr/python-net/low-code-presentation-operations/
keywords:
- düşük kodlu sunum API
- sunumu dönüştür
- sunumları birleştir
- şekilleri topla
- sunumu sıkıştır
- kullanılmayan master slaytları kaldır
- kullanılmayan düzen slaytlarını kaldır
- gömülü fontları sıkıştır
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python'da Aspose.Slides düşük kodlu API'sini kullanarak sunumları dönüştürün ve birleştirin, şekilleri toplayın ve sunum boyutunu küçültün."
---
## **Genel Bakış**

The [aspose.slides.lowcode](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/) module provides helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/tr/python-net/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Yardımcı | Ne İçin Kullanılır |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/convert/) | Sunumu doğrudan dosya‑dosya çağrısı ile başka bir formata dönüştürme. |
| [Merger](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/merger/) | Aynı formatta tam sunum dosyalarını birleştirme. |
| [Collect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/collect/) | Tam sunumdan şekilleri alarak tekrar tekrar işlemek veya analiz etmek. |
| [Compress](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/) | Kullanılmayan master ve düzenleri kaldırma ve gömülü font verisini azaltma. |

## **Sunumu Dönüştür**

Use [Convert.auto_by_extension](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/convert/auto_by_extension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

The [Convert](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/python-net/convert-presentation/) for format-specific workflows and options.

## **Sunumları Birleştir**

Use [Merger.process](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/python-net/merge-presentation/) for those scenarios.

## **Şekilleri Topla**

Use [Collect.shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation. This is useful when the same set will be filtered, counted, or processed more than once.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Use direct collection loops when traversal order, early exit, filtering before processing, or detailed parent-child control is important.

## **Sunum İçeriğini Sıkıştır**

The [Compress](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) normal bir slaytın referans etmediği düzen slaytlarını kaldırır.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) artık kullanılmayan master slaytları kaldırır.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) gömülü fontlardaki kullanılmayan karakterleri kaldırır.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/python-net/slide-master/) and [Embedded Font](/python-net/embedded-font/).

## **SSS**

**Low-code API'yi tam nesne modeline ne zaman kullanmalıyım?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Merger farklı dosya formatlarındaki sunumları birleştirebilir mi?**

Hayır. [Merger.process](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/merger/process/) aynı formatta giriş sunumları gerektirir. İlk olarak giriş dosyalarını ortak bir formata dönüştürün, örneğin [Convert.auto_by_extension](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/convert/auto_by_extension/) kullanarak, ardından dönüştürülmüş dosyaları birleştirin.

**Collect.shapes neleri içerir?**

[Collect.shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/collect/shapes/) sunumdan şekilleri alır böylece tutabilir, filtreleyebilir, sayabilir veya birden çok kez gezilebilir. Doğrudan koleksiyon döngüleri, hangi slayt türlerinin ya da iç içe nesnelerin ziyaret edildiği üzerinde kesin kontrol gerektiğinde kullanın.

**Compress her zaman sunum dosyasını küçültür mü?**

Gerekli değildir. Sonuç, sunumda kullanılmayan düzenler, kullanılmayan masterlar veya kullanılmayan karakterlere sahip gömülü fontlar olup olmamasına bağlıdır. Bunlardan hiçbiri yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/) işlemleri dosya boyutunu azaltmayabilir.

**Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**

Hayır. Bu yardımcılar, bellekte yüklü [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi üzerinde çalışır. [Compress](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/) çalıştırıldıktan sonra sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) çağırın.

## **İlgili Makaleler**

- [Sunumu Dönüştür](/python-net/convert-presentation/)
- [Sunumları Birleştir](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Metin Kutusunu Yönet](/python-net/manage-textbox/)
- [Gömülü Font](/python-net/embedded-font/)