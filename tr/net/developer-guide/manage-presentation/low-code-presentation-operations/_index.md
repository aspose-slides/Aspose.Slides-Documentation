---
title: ".NET'te Düşük Kodlu Sunum İşlemleri"
linktitle: "Düşük Kodlu API"
type: docs
weight: 50
url: /tr/net/low-code-presentation-operations/
keywords:
- "düşük kodlu sunum API'si"
- "sunumu dönüştür"
- "sunumları birleştir"
- "slaytları yinele"
- "şekilleri yinele"
- "metni yinele"
- "şekilleri topla"
- "sunumu sıkıştır"
- "kullanılmayan master slaytları kaldır"
- "kullanılmayan layout slaytları kaldır"
- "gömülü fontları sıkıştır"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides düşük kodlu API'sini .NET'te kullanarak sunumları dönüştürün ve birleştirin, içeriği yineleyin, şekilleri toplayın ve sunum boyutunu azaltın."
---
## **Genel Bakış**

The [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code yardımcıları, işlem bir bütün dosya veya sunuma uygulandığında ve varsayılan iş akışı gereksinimlerinize uyduğunda en faydalıdır. Bireysel slaytlar, masterlar, düzenler, şekiller, dışa aktarma ayarları veya sunum öğeleri arasındaki ilişkiler üzerinde ince ayar denetimine ihtiyaç duyduğunuzda tam [Aspose.Slides object model](https://reference.aspose.com/slides/net/aspose.slides/) kullanın.

The following table summarizes the available helpers:

| Yardımcı | Kullanım Amacı |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Sunumu doğrudan dosya‑dosya çağrısıyla başka bir formata dönüştürme. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Aynı formatta tam sunum dosyalarını birleştirme. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Her slayt, şekil, paragraf veya metin bölümü için bir eylem çalıştırma. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Tekrar işleme veya analiz için tüm sunumdan şekilleri alma. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Kullanılmayan master/layouları kaldırma, gömülü font verisini azaltma ve resimleri sıkıştırma. |

## **Bir Sunumu Dönüştürme**

Use [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Sunumu Dönüştürme](/slides/tr/net/convert-presentation/) for format-specific workflows and options.

## **Sunumları Birleştirme**

Use [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Sunumları Birleştirme](/slides/tr/net/merge-presentation/) for those scenarios.

## **Sunum Öğeleri Üzerinde Döngü**

The [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **Şekilleri Toplama**

Use [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Use [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **Sunum İçeriğini Sıkıştırma**

The [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) removes layout slides that no normal slide references.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) removes master slides that are no longer used.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) removes unused characters from embedded fonts.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/tr/net/slide-master/) and [Embedded Font](/slides/tr/net/embedded-font/).

### **Tüm Sunumu Sıkıştırma**

Aspose.Slides for .NET 26.11 adds [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). It combines removal of unused layout/master slides, subsetting of embedded fonts to used characters, and picture compression at 150 DPI. Use the individual operations above when you need to control which changes are applied.

Install [Aspose.Slides for .NET](/slides/tr/net/installation/) 26.11 or later and provide `input.pptx`. Save to a separate file: removed layouts, font characters and cropped picture pixels may be needed for later editing.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Seçilen Çözünürlükte Resimleri Sıkıştırma**

Use [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) to process eligible pictures without also removing layouts or subsetting fonts. This example uses 96 DPI; select another [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) value for your output needs.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Both helpers use the following picture-processing scope:

| İçerik | İşlem |
| --- | --- |
| Normal, master ve layout slaytlarda raster resimler ve şekil resmi doldurmaları, gruplanmış şekiller dahil | Sıkıştırma için uygundur. |
| İstenen çözünürlüğün altında veya ona eşit olan resimler | Yeniden büyütülmez. Kırpılan bölgeler hâlâ kaldırılabilir. |
| Kırpılmış resim alanları | Gizli pikseller kalıcı olarak kaldırılır ve kırpma ötelemesi sıfırlanır. |
| Slayt arka planları ve tablo hücresi doldurmaları | Bu yardımcılar tarafından işlenmez. |
| Grafik/SmartArt iç yapıları, GIF ve SVG, EMF, WMF gibi vektör formatları | Belirtilen görüntü sıkıştırma kapsamı dışındadır. |

In 26.11, [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) avoids resolution-based downsampling of an uncropped picture, but **does not preserve cropped pixels**. A cropped picture can still be rewritten with its hidden areas removed. Neither helper exposes a preserve-crop option. For individual control, see the [per-picture compression example](/slides/tr/net/examples/optimization-batch/compression/).

Compare the output's appearance and file size before replacing the original. Savings depend on the source pictures, their displayed size and unused content; compression does not guarantee a smaller file. See [Embedded Fonts](/slides/tr/net/embedded-font/) for the implications of font subsetting.

## **SSS**

**Low-code API'sini tam nesne modeli yerine ne zaman kullanmalıyım?**

Low-code yardımcılarını, standart bir işlemin tüm dosya veya sunuma uygulanması ve bireysel öğeler üzerinde ayrıntılı kontrol gerektirmemesi durumunda kullanın. Belirli slaytları seçmek, master ve layout ilişkilerini kontrol etmek, ara durumu incelemek veya yardımcı tarafından sunulmayan bir davranışı yapılandırmak gerektiğinde tam nesne modelini kullanın.

**Merger farklı dosya formatlarındaki sunumları birleştirebilir mi?**

Hayır. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) aynı formatta giriş sunumları gerektirir. Önce giriş dosyalarını ortak bir formata dönüştürün, örneğin [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) ile, ardından dönüştürülmüş dosyaları birleştirin.

**ForEach master, layout ve not slaytlarını işler mi?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) normal sunum slaytlarını döner. Sunum genelinde [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), ve [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) işlemleri varsayılan olarak normal, master ve layout slaytlarını içerir. Not slaytlarını dahil etmek için `includeNotes` parametresi `true` olarak ayarlanan aşırı yüklemelerini kullanın.

**ForEach.Shape ile Collect.Shapes arasındaki fark nedir?**

[ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) her şekli anında bir geri çağırma ile işlemek için kullanın. [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) ise tutulabilir, filtrelenebilir, sayılabilir veya birden fazla kez gezilebilir bir enumerable sonuç gerektiğinde kullanılır.

**Compress her zaman sunum dosyasını küçültür mü?**

Zorunlu değildir. Tasarruf, kullanılmayan layout/master’lar, kullanılmayan karakterlere sahip gömülü fontlar ve sıkıştırmadan fayda sağlayan resimler gibi faktörlere bağlıdır. [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) yardımcıları bazı girdilerde dosya boyutunu aynı tutabilir veya hatta artırabilir. Hem boyutu hem de render kalitesini karşılaştırın ve orijinali saklayın.

**ForEach veya Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**

Hayır. Bu yardımcılar bellekte yüklü [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) geri çağırması içinde öğeleri değiştirdikten veya [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) çalıştırdıktan sonra sonucu yazmak için [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) metodunu çağırın.

## **İlgili Makaleler**

- [Sunumu Dönüştürme](/slides/tr/net/convert-presentation/)
- [Sunumları Birleştirme](/slides/tr/net/merge-presentation/)
- [Slide Master](/slides/tr/net/slide-master/)
- [Manage Text Box](/slides/tr/net/manage-textbox/)
- [Embedded Font](/slides/tr/net/embedded-font/)