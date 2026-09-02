---
title: .NET'te Düşük Kodlu Sunum İşlemleri
linktitle: Düşük Kodlu API
type: docs
weight: 50
url: /tr/net/low-code-presentation-operations/
keywords:
- düşük kodlu sunum API'si
- sunumu dönüştür
- sunumları birleştir
- slaytları yinele
- şekilleri yinele
- metni yinele
- şekilleri topla
- sunumu sıkıştır
- kullanılmayan ana slaytları kaldır
- kullanılmayan düzen slaytlarını kaldır
- gömülü yazı tiplerini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides düşük kodlu API'sini .NET'te kullanarak sunumları dönüştürün ve birleştirin, içerikte döngü yapın, şekilleri toplayın ve sunum boyutunu küçültün."
---
## **Genel Bakış**

[Aspose.Slides.LowCode](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/) ad alanı, yaygın sunum işlemleri için statik yardımcı sınıflar sağlar. Bu yardımcılar, sık kullanılan nesne‑model iş akışlarını odaklanmış yöntemlerde sarar, böylece dosyaları dönüştürebilir veya birleştirebilir, sunum öğelerini işleyebilir, şekilleri toplayabilir ve kullanılmayan içeriği daha az kodla kaldırabilirsiniz.

Low‑code yardımcıları, işlem tüm bir dosya veya sunuma uygulandığında ve varsayılan iş akışı gereksinimlerinize uygun olduğunda en faydalıdır. Bireysel slaytlar, ana slaytlar, düzenler, şekiller, dışa aktarma ayarları veya sunum öğeleri arasındaki ilişkiler üzerinde ince ayar yapmanız gerektiğinde tam [Aspose.Slides nesne modeli](https://reference.aspose.com/slides/tr/net/aspose.slides/) kullanın.

Aşağıdaki tablo mevcut yardımcıların özetini verir:

| Yardımcı | Ne için kullanılır |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/convert/) | Doğrudan dosya‑dosya çağrısı ile bir sunumu başka bir biçime dönüştürmek. |
| [Merger](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/merger/) | Aynı biçimdeki tam sunum dosyalarını birleştirmek. |
| [ForEach](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/) | Her slayt, şekil, paragraf veya metin bölümünde bir eylem yürütmek. |
| [Collect](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/collect/) | Tekrarlayan işleme veya analiz için tüm sunumdan şekilleri almak. |
| [Compress](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/) | Kullanılmayan ana slaytları ve düzenleri kaldırmak ve gömülü yazı tipi verisini azaltmak. |

## **Sunumu Dönüştür**

[Convert.AutoByExtension](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/convert/autobyextension/) çıktının dosya uzantısının dışa aktarma formatını seçmek için yeterli olduğu durumlarda kullanılır. Yöntem kaynak sunumu açar, çıktı yolundan gerekli biçimi belirler ve sonucu yazar.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/convert/) sınıfı ayrıca PDF, SVG, JPEG, PNG ve TIFF çıktısı için özel yöntemler sunar. Dışa aktarmadan önce sunumu incelemeniz veya değiştirmeniz, ya da seçili yardımcıda sunulmayan bir dışa aktarma seçeneği yapılandırmanız gerekiyorsa tam nesne modelini kullanın. Biçime özgü iş akışları ve seçenekler için [Sunumu Dönüştür](/slides/tr/net/convert-presentation/) sayfasına bakın.

## **Sunumları Birleştir**

[Merger.Process](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/merger/process/) aynı formatta olan tam sunum dosyalarını tek bir çağrı ile birleştirmek için kullanılır. Girdi sunumlarının aynı dosya biçiminde olması gerekir.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Bu yardımcı, tüm slaytların tek bir sonuçta ardışık olarak eklenmesi gerektiğinde uygundur; slaytları ayrı ayrı seçmek veya yeniden eşlemek gerekmez. Belirli slaytları birleştirmeniz, hedef ana slayt veya düzen uygulamanız, bölümleri açıkça korumanız veya farklı slayt boyutlarını uyumlaştırmanız gerektiğinde tam nesne modelini kullanın. Bu senaryolar için [Sunumları Birleştir](/slides/tr/net/merge-presentation/) sayfasına bakın.

## **Sunum Öğeleri Üzerinde Döngü**

[ForEach](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/) sınıfı, istenen sunum öğesi türü için bir geri çağırma (callback) tetikler. İç içe koleksiyon döngülerini önler ve sunum genelinde denetim veya biçimlendirme değişiklikleri için kullanışlıdır.

Aşağıdaki örnek, ilgili öğeleri incelemek için [ForEach.Slide](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/paragraph/) ve [ForEach.Portion](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/portion/) yöntemlerini kullanır:

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

Varsayılan olarak, sunum genelinde şekil ve metin dolaşımı normal, ana ve düzen slaytlarını içerir. `includeNotes` parametresiyle aşırı yüklenmiş sürümler not slaytlarını da işleyebilir. Dolaşım sırası, erken çıkış, geri çağırmadan önce filtreleme veya ayrıntılı ebeveyn‑çocuk kontrolü önemli ise doğrudan koleksiyon döngüleri kullanın.

## **Şekilleri Topla**

[Collect.Shapes](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/collect/shapes/) bir sunumdaki tüm şekillerin koleksiyonuna ihtiyacınız olduğunda kullanılır; bu, aynı kümenin birden fazla kez filtrelenmesi, sayılması veya işlenmesi gerektiğinde faydalıdır.

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

Her şekil anında işlenebiliyorsa ve toplanan sonucu saklamanıza gerek yoksa, [ForEach.Shape](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/shape/) kullanın.

## **Sunum İçeriğini Sıkıştır**

[Compress](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/) sınıfı kullanılmayan yapısal öğeleri kaldırabilir ve gömülü yazı tipi verisini azaltabilir:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) hiçbir normal slaytın referans vermediği düzen slaytlarını kaldırır.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) artık kullanılmayan ana slaytları kaldırır.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/compressembeddedfonts/) gömülü yazı tiplerinden kullanılmayan karakterleri kaldırır.

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

Kullanılmayan düzenleri, kullanılmayan ana slaytlardan önce kaldırın; böylece düzen temizliği sonrasında referansı kaybeden bir ana slayt da kaldırılabilir. Orijinal ana slaytlar, düzenler veya tam gömülü yazı tipi verisine daha sonra ihtiyaç duyulabilecekse, optimize edilmiş sunumu yeni bir dosyaya kaydedin. Daha fazla ayrıntı için [Slide Master](/slides/tr/net/slide-master/) ve [Embedded Font](/slides/tr/net/embedded-font/) sayfalarına bakın.

## **SSS**

**Low‑code API’yi tam nesne modeline ne zaman tercih etmeliyim?**

Standart bir işlem tüm dosya veya sunuma uygulanıyorsa ve bireysel öğeler üzerinde ayrıntılı kontrol gerektirmiyorsa low‑code yardımcıları kullanın. Belirli slaytları seçmeniz, ana‑düzen ilişkilerini kontrol etmeniz, ara durumu incelemeniz veya yardımcı tarafından sunulmayan bir davranışı yapılandırmanız gerektiğinde tam nesne modelini tercih edin.

**Merger farklı dosya biçimlerindeki sunumları birleştirebilir mi?**

Hayır. [Merger.Process](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/merger/process/) giriş sunumlarının aynı biçimde olmasını ister. Önce giriş dosyalarını ortak bir biçime dönüştürün; örneğin [Convert.AutoByExtension](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/convert/autobyextension/) ile, ardından dönüştürülmüş dosyaları birleştirin.

**ForEach ana, düzen ve not slaytlarını işler mi?**

[ForEach.Slide](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/slide/) normal sunum slaytları üzerinde döner. Sunum genelinde [ForEach.Shape](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/paragraph/) ve [ForEach.Portion](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/portion/) işlemleri varsayılan olarak normal, ana ve düzen slaytlarını içerir. Not slaytlarını da dahil etmek için `includeNotes` parametresiyle aşırı yüklenmiş sürümlerini kullanın.

**ForEach.Shape ile Collect.Shapes arasındaki fark nedir?**

[ForEach.Shape](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/shape/) her şekli anında bir geri çağırma ile işler. [Collect.Shapes](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/collect/shapes/) ise saklanabilir, filtrelenebilir, sayılabilir ve birden çok kez dolaşılabilir bir IEnumerable sonucu döndürür.

**Compress her zaman sunum dosyasını küçültür mü?**

Zorunlu değil. Sonuç, sunumda kullanılmayan düzenler, kullanılmayan ana slaytlar veya kullanılmayan karakterlere sahip gömülü yazı tipleri olup olmamasına bağlıdır. Bu öğeler yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/) işlemleri dosya boyutunu azaltmayabilir.

**ForEach veya Compress ile yapılan değişiklikler otomatik olarak kaydedilir mi?**

Hayır. Bu yardımcılar, bellekte yüklü olan [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/) geri çağırması içinde öğeleri değiştirdikten veya [Compress](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/) çalıştırdıktan sonra sonucu yazmak için [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) çağırmanız gerekir.

## **İlgili Makaleler**

- [Sunumu Dönüştür](/slides/tr/net/convert-presentation/)
- [Sunumları Birleştir](/slides/tr/net/merge-presentation/)
- [Slide Master](/slides/tr/net/slide-master/)
- [Manage Text Box](/slides/tr/net/manage-textbox/)
- [Embedded Font](/slides/tr/net/embedded-font/)