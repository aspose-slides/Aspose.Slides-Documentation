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
- slaytları dolaş
- şekilleri dolaş
- metni dolaş
- şekilleri toplama
- sunumu sıkıştır
- kullanılmayan ana-sayfa slaytlarını kaldır
- kullanılmayan yerleşim slaytlarını kaldır
- gömülü yazı tiplerini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides düşük kodlu API'sini .NET'te kullanarak sunumları dönüştürün ve birleştirin, içeriği dolaşın, şekilleri toplayın ve sunum boyutunu küçültün."
---
## **Genel Bakış**

[Aspose.Slides.LowCode](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/) isim alanı yaygın sunum işlemleri için statik yardımcı sınıflar sağlar. Bu yardımcılar sık kullanılan nesne‑modeli iş akışlarını odaklanmış yöntemlerde sarar, böylece dosyaları dönüştürebilir veya birleştirebilir, sunum öğelerini işleyebilir, şekilleri toplayabilir ve kullanılmayan içeriği daha az kodla kaldırabilirsiniz.

Low‑code yardımcıları, işlem bir bütün dosya ya da sunuma uygulandığında ve varsayılan iş akışı gereksinimlerinize uyarak en yararlı olur. Tek tek slaytlar, ana‑sayfalar, yerleşimler, şekiller, dışa aktarım ayarları veya sunum öğeleri arasındaki ilişkiler üzerinde ayrıntılı denetim gerektiğinde tam [Aspose.Slides nesne modeli](https://reference.aspose.com/slides/tr/net/aspose.slides/) kullanın.

Aşağıdaki tablo mevcut yardımcıları özetlemektedir:

| Helper | Kullanım Alanı |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/convert/) | Sunumu doğrudan dosya‑dosya çağrısı ile başka bir formata dönüştürme. |
| [Merger](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/merger/) | Aynı formatta tam sunum dosyalarını birleştirme. |
| [ForEach](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/) | Her slayt, şekil, paragraf veya metin bölümü için bir eylem çalıştırma. |
| [Collect](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/collect/) | Tekrar eden işleme ya da analiz için tüm sunumdan şekilleri toplama. |
| [Compress](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/) | Kullanılmayan ana‑sayfaları ve yerleşimleri kaldırma ve gömülü yazı tipi verilerini azaltma. |

## **Sunumu Dönüştürme**

Çıktı dosya uzantısının dışa aktarım formatını seçmek için yeterli olduğu durumlarda [Convert.AutoByExtension](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/convert/autobyextension/) kullanın. Yöntem kaynak sunumu açar, çıktı yolundan gerekli formatı belirler ve sonucu yazar.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/convert/) sınıfı ayrıca PDF, SVG, JPEG, PNG ve TIFF çıktısı için özel yöntemler sunar. Dışa aktarımdan önce sunumu incelemeniz veya değiştirmeniz ya da seçilen yardımcıda sunulmayan bir dışa aktarım seçeneği yapılandırmanız gerektiğinde tam nesne modelini kullanın. Biçim‑özel iş akışları ve seçenekler için [Convert Presentation](/net/convert-presentation/) bölümüne bakın.

## **Sunumları Birleştirme**

Tam bir çağrı ile tam sunum dosyalarını birleştirmek için [Merger.Process](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/merger/process/) kullanın. Girdi sunumları aynı dosya formatına sahip olmalıdır.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Tüm slaytların tek bir sonuç dosyasına eklenmesi gerektiğinde ve her birini ayrı ayrı seçme ya da yeniden haritalama ihtiyacı olmadığında bu yardımcı uygundur. Seçili slaytları birleştirmeniz, hedef bir ana‑sayfa ya da yerleşim uygulamanız, bölümleri açıkça korumanız ya da farklı slayt boyutlarını uzlaştırmanız gerektiğinde tam nesne modelini kullanın. Bu senaryolar için [Merge Presentations](/net/merge-presentation/) bölümüne bakın.

## **Sunum Öğeleri Üzerinde Döngü Oluşturma**

[ForEach](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/) sınıfı, istenen türdeki her sunum öğesi için bir geri çağırma (callback) yürütür. İç içe koleksiyon döngülerini önler ve sunum genelinde denetim ya da biçimlendirme değişiklikleri için uygundur.

Aşağıdaki örnek, ilgili öğeleri incelemek için [ForEach.Slide](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/paragraph/) ve [ForEach.Portion](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/portion/) kullanır:

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

Varsayılan olarak, sunum‑geneli şekil ve metin dolaşımı normal, ana‑sayfa ve yerleşim slaytlarını içerir. `includeNotes` parametresiyle aşırı yüklenen sürümler not slaytlarını da işleyebilir. Dolaşım sırası, erken çıkış, geri çağırmadan önce filtreleme veya ayrıntılı ebeveyn‑çocuk denetimi gerektiğinde doğrudan koleksiyon döngüleri kullanın.

## **Şekilleri Toplama**

Her şekil için bir geri çağırma yerine sunumdaki tüm şekillerin bir koleksiyonuna ihtiyacınız varsa [Collect.Shapes](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/collect/shapes/) kullanın. Aynı küme birden çok kez filtrelenecek, sayılacak veya işlenecekse bu yararlıdır.

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

Her şekil hemen işlenebilecekse ve toplanan sonuca ihtiyacınız yoksa bunun yerine [ForEach.Shape](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/shape/) kullanın.

## **Sunum İçeriğini Sıkıştırma**

[Compress](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/) sınıfı, kullanılmayan yapısal öğeleri kaldırabilir ve gömülü yazı tipi verilerini azaltabilir:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) hiçbir normal slaytın başvurduğu yerleşim slaytlarını kaldırır.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) artık kullanılmayan ana‑sayfa slaytlarını kaldırır.
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

Kullanılmayan yerleşimleri, kullanılmayan ana‑sayfalardan önce kaldırın; böylece yerleşim temizliğinden sonra başvuru kaybeden bir ana‑sayfa da silinebilir. Orijinal ana‑sayfalar, yerleşimler veya tam gömülü yazı tipi verilerine daha sonra ihtiyaç duyulabilecekse optimize edilmiş sunumu yeni bir dosyaya kaydedin. Daha fazla ayrıntı için [Slide Master](/net/slide-master/) ve [Embedded Font](/net/embedded-font/) bölümlerine bakın.

## **SSS**

**Low‑code API’sini tam nesne modeline ne zaman tercih etmeliyim?**  
Standart bir işlem bütün bir dosya ya da sunuma uygulanıyor ve tek tek öğeler üzerinde ayrıntılı denetim gerektirmiyorsa low‑code yardımcılarını kullanın. Belirli slaytları seçmeniz, ana‑sayfa ve yerleşim ilişkilerini kontrol etmeniz, ara durumu incelemeniz veya yardımcıda bulunmayan bir davranışı yapılandırmanız gerektiğinde tam nesne modelini kullanın.

**Merger farklı dosya formatlarındaki sunumları birleştirebilir mi?**  
Hayır. [Merger.Process](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/merger/process/) giriş sunumlarının aynı formatta olmasını ister. Önce giriş dosyalarını ortak bir formata dönüştürün (ör. [Convert.AutoByExtension](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/convert/autobyextension/)) ve ardından dönüştürülmüş dosyaları birleştirin.

**ForEach ana‑sayfa, yerleşim ve not slaytlarını işler mi?**  
[ForEach.Slide](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/slide/) normal sunum slaytları üzerinde döner. Sunum‑geneli [ForEach.Shape](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/paragraph/) ve [ForEach.Portion](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/portion/) işlemleri varsayılan olarak normal, ana‑sayfa ve yerleşim slaytlarını içerir. Not slaytlarını da dahil etmek için `includeNotes` parametresini `true` olarak ayarlayan aşırı yüklemeleri kullanın.

**ForEach.Shape ile Collect.Shapes arasındaki fark nedir?**  
[ForEach.Shape](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/shape/) her şekli doğrudan bir geri çağırma içinde işler. [Collect.Shapes](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/collect/shapes/) ise saklanabilir, filtrelenebilir, sayılabilir veya birden çok kez dolaşılabilir bir enumerable sonuç verir.

**Compress her zaman sunum dosyasını küçültür mü?**  
Zorunlu değildir. Sonuç, sunumda kullanılmayan yerleşimler, kullanılmayan ana‑sayfalar veya kullanılmayan karakterlere sahip gömülü yazı tipleri bulunup bulunmadığına bağlıdır. Bu öğeler yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/) işlemleri dosya boyutunu azaltmayabilir.

**ForEach veya Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**  
Hayır. Bu yardımcılar bellekte yüklü [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/foreach/) geri çağırması içinde öğeleri değiştirdikten veya [Compress](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/) çalıştırdıktan sonra sonucu yazmak için [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) çağırın.

## **İlgili Makaleler**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)