---
title: Java üzerinden Python'da Düşük Kodlu Sunum İşlemleri
linktitle: Düşük Kodlu API
type: docs
weight: 50
url: /tr/python-java/low-code-presentation-operations/
keywords:
- düşük kodlu sunum API
- sunum dönüştürme
- sunumları birleştirme
- slaytları yineleme
- şekilleri yineleme
- metni yineleme
- şekilleri toplama
- sunumu sıkıştırma
- kullanılmayan master slaytları kaldırma
- kullanılmayan düzen slaytlarını kaldırma
- gömülü fontları sıkıştırma
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Java üzerinden Python'da Aspose.Slides düşük kodlu API'sini kullanarak sunumları dönüştürüp birleştirin, içeriği yineleyin, şekilleri toplayın ve sunum boyutunu küçültün."
---
## **Genel Bakış**

The [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/tr/python-java/aspose.slides/) API provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/tr/python-java/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Yardımcı | Ne için kullanılır |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/python-java/aspose.slides/convert/) | Bir sunumu başka bir formata, doğrudan dosya‑dosya çağrısı ile dönüştürme. |
| [Merger](https://reference.aspose.com/slides/tr/python-java/aspose.slides/merger/) | Aynı formatta tam sunum dosyalarını birleştirme. |
| [ForEach](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/) | Her slayt, şekil, paragraf veya metin bölümü için bir eylem çalıştırma. |
| [Collect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/collect/) | Tekrarlı işleme veya analiz için tüm sunumdan şekilleri alma. |
| [Compress](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/) | Kullanılmayan master ve düzenleri kaldırma ve gömülü font verilerini azaltma. |

## **Bir Sunumu Dönüştürme**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/tr/python-java/aspose.slides/convert/#autoByExtension) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

The [Convert](https://reference.aspose.com/slides/tr/python-java/aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/tr/python-java/convert-presentation/) for format-specific workflows and options.

## **Sunumları Birleştirme**

Use [Merger.process](https://reference.aspose.com/slides/tr/python-java/aspose.slides/merger/#process) to combine complete presentation files with one call. The input presentations must have the same file format.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/tr/python-java/merge-presentation/) for those scenarios.

## **Sunum Öğeleri Üzerinde Döngü**

The [ForEach](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/#paragraph), and [ForEach.portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/#portion) to inspect the corresponding elements:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **Şekilleri Toplama**

Use [Collect.shapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/collect/#shapes) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Use [ForEach.shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/#shape) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **Sunum İçeriğini Sıkıştırma**

The [Compress](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) normal bir slaytın referans vermediği düzen slaytlarını kaldırır.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/#removeUnusedMasterSlides) artık kullanılmayan master slaytları kaldırır.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/#compressEmbeddedFonts) gömülü fontlardan kullanılmayan karakterleri kaldırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/tr/python-java/slide-master/) and [Embedded Font](/slides/tr/python-java/embedded-font/).

## **SSS**

**Düşük kodlu API'yi tam nesne modeline ne zaman kullanmalıyım?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Merger farklı dosya formatlarındaki sunumları birleştirebilir mi?**

Hayır. [Merger.process](https://reference.aspose.com/slides/tr/python-java/aspose.slides/merger/#process) aynı formatta giriş sunumları gerektirir. Önce giriş dosyalarını ortak bir formata dönüştürün, örneğin [Convert.autoByExtension](https://reference.aspose.com/slides/tr/python-java/aspose.slides/convert/#autoByExtension) ile, ardından dönüştürülmüş dosyaları birleştirin.

**ForEach master, layout ve not slaytlarını işler mi?**

[ForEach.slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/#slide) normal sunum slaytları üzerinde iterasyon yapar. Sunum genelinde [ForEach.shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/#paragraph) ve [ForEach.portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/#portion) işlemleri varsayılan olarak normal, master ve layout slaytlarını içerir. Not slaytlarını dahil etmek için `includeNotes` parametresi `True` olarak ayarlanmış overload'ları kullanın.

**ForEach.shape ile Collect.shapes arasındaki fark nedir?**

[ForEach.shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/#shape) her şekli bir geri çağırma ile hemen işlemek için kullanılır. [Collect.shapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/collect/#shapes) ise şekilleri bir iterable sonuç olarak toplamak, filtrelemek, saymak veya birden çok kez gezmek istediğinizde kullanılır.

**Compress her zaman sunum dosyasını küçültür mü?**

Zorunlu değil. Sonuç, sunumun kullanılmayan düzenler, kullanılmayan masterlar veya kullanılmayan karakterlere sahip gömülü fontlar içerip içermediğine bağlıdır. Eğer bunlar yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/) işlemleri dosya boyutunu azaltmayabilir.

**ForEach veya Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**

Hayır. Bu yardımcılar, bellekteki [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach](https://reference.aspose.com/slides/tr/python-java/aspose.slides/foreach/) geri çağırma içinde öğeleri değiştirdikten veya [Compress](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/) çalıştırdıktan sonra sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu çağırın.

## **İlgili Makaleler**

- [Sunumu Dönüştürme](/slides/tr/python-java/convert-presentation/)
- [Sunumları Birleştirme](/slides/tr/python-java/merge-presentation/)
- [Slayt Masterı](/slides/tr/python-java/slide-master/)
- [Metin Kutusunu Yönetme](/slides/tr/python-java/manage-textbox/)
- [Gömülü Font](/slides/tr/python-java/embedded-font/)