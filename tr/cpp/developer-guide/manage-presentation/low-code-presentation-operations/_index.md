---
title: C++'da Düşük Kodlu Sunum İşlemleri
linktitle: Düşük Kodlu API
type: docs
weight: 50
url: /tr/cpp/low-code-presentation-operations/
keywords:
- düşük kodlu sunum API
- sunumu dönüştür
- sunumları birleştir
- slaytları yinele
- şekilleri yinele
- metni yinele
- şekilleri topla
- sunumu sıkıştır
- kullanılmayan master slaytları kaldır
- kullanılmayan düzen slaytlarını kaldır
- gömülü yazı tiplerini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "C++'da Aspose.Slides düşük kodlu API'sini kullanarak sunumları dönüştürün ve birleştirin, içerikte yineleme yapın, şekilleri toplayın ve sunum boyutunu azaltın."
---
## **Genel Bakış**

[Aspose::Slides::LowCode](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/) isim alanı, ortak sunum işlemleri için statik yardımcı sınıflar sağlar. Bu yardımcılar, sık kullanılan nesne modeli iş akışlarını odaklanmış yöntemlerde sarar, böylece dosyaları dönüştürebilir veya birleştirebilir, sunum öğelerini işleyebilir, şekilleri toplayabilir ve kullanılmayan içeriği daha az kodla kaldırabilirsiniz.

Düşük kodlu yardımcılar, işlem tüm bir dosya veya sunuma uygulandığında ve varsayılan iş akışı gereksinimlerinize uyduğunda en yararlıdır. Tek tek slaytlar, masterlar, düzenler, şekiller, dışa aktarma ayarları veya sunum öğeleri arasındaki ilişkiler üzerinde ayrıntılı kontrol gerektiğinde tam [Aspose.Slides nesne modeli](https://reference.aspose.com/slides/tr/cpp/aspose.slides/) kullanın.

Aşağıdaki tablo mevcut yardımcıları özetlemektedir:

| Yardımcı | Ne için kullanılır |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/convert/) | Sunumu doğrudan dosyadan dosyaya çağrı ile başka bir formata dönüştürme. |
| [Merger](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/merger/) | Aynı formatta tam sunum dosyalarını birleştirme. |
| [ForEach](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/) | Her slayt, şekil, paragraf veya metin bölümü için bir eylem çalıştırma. |
| [Collect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/collect/) | Tekrar eden işleme veya analiz için tüm sunumdan şekilleri alma. |
| [Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) | Kullanılmayan master ve düzenleri kaldırma ve gömülü yazı tipi verilerini azaltma. |

## **Bir Sunumu Dönüştür**

Çıktı dosya uzantısının dışa aktarım formatını seçmek için yeterli olduğu durumlarda [Convert::AutoByExtension](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/convert/autobyextension/) kullanın. Yöntem kaynak sunumu açar, çıktı yolundan gereken formatı belirler ve sonucu yazar.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

[Convert](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/convert/) sınıfı ayrıca PDF, SVG, JPEG, PNG ve TIFF çıktısı için özel yöntemler sağlar. Dışa aktarma öncesinde sunumu denetlemeniz veya değiştirmeniz ya da seçilen yardımcı tarafından sunulmayan bir dışa aktarma seçeneği yapılandırmanız gerektiğinde tam nesne modelini kullanın. Biçime özgü iş akışları ve seçenekler için [Convert Presentation](/cpp/convert-presentation/) bölümüne bakın.

## **Sunumları Birleştir**

Tam sunum dosyalarını tek bir çağrı ile birleştirmek için [Merger::Process](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/merger/process/) kullanın. Giriş sunumları aynı dosya biçimine sahip olmalıdır.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Bu yardımcı, tüm slaytların tek bir sonuca seçilmeden veya yeniden eşlenmeden eklenmesi gerektiğinde uygundur. Seçili slaytları birleştirmeniz, hedef bir master veya düzen uygulamanız, bölümleri açıkça korumanız veya farklı slayt boyutlarını uyumlu hâle getirmeniz gerektiğinde tam nesne modelini kullanın. Bu senaryolar için [Merge Presentations](/cpp/merge-presentation/) bölümüne bakın.

## **Sunum Öğeleri Üzerinde Yineleme**

[ForEach](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/) sınıfı, istenen her sunum öğesi türü için bir geri çağırma (callback) çalıştırır. İç içe koleksiyon döngülerini önler ve sunum genelinde denetim veya biçimlendirme değişiklikleri için uygundur.

Aşağıdaki örnek, ilgili öğeleri denetlemek için [ForEach::Slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/paragraph/) ve [ForEach::Portion](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/portion/) kullanır:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Varsayılan olarak, sunum genelindeki şekil ve metin dolaşımı normal, master ve düzen slaytlarını içerir. `includeNotes` parametresiyle aşırı yüklemeler not slaytlarını da işleyebilir. Dolaşım sırası, erken çıkış, geri çağırmadan önce filtreleme veya ayrıntılı ebeveyn‑çocuk kontrolünün önemli olduğu durumlarda doğrudan koleksiyon döngüleri kullanın.

## **Şekilleri Topla**

Her şekil için bir geri çağırma yerine sunumdaki tüm şekillerin bir koleksiyonuna ihtiyacınız olduğunda [Collect::Shapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/collect/shapes/) kullanın. Aynı küme birden fazla kez filtrelenecek, sayılacak veya işlenecekse bu faydalıdır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Her şekil anında işlenebiliyorsa ve toplanan sonucu tutmanız gerekmiyorsa yerine [ForEach::Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/shape/) kullanın.

## **Sunum İçeriğini Sıkıştır**

[Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) sınıfı, kullanılmayan yapısal öğeleri kaldırabilir ve gömülü yazı tipi verilerini azaltabilir:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) normal bir slaytın referans vermediği düzen slaytlarını kaldırır.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) artık kullanılmayan master slaytlarını kaldırır.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) gömülü yazı tiplerinden kullanılmayan karakterleri kaldırır.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Kullanılmayan düzenleri, kullanılmayan masterlardan önce kaldırın; böylece düzen temizliği sonrası referanssız kalan bir master da kaldırılabilir. Orijinal masterları, düzenleri veya tam gömülü yazı tipi verilerini daha sonra ihtiyaç duyabilecekseniz optimize edilmiş sunumu yeni bir dosyaya kaydedin. Daha fazla ayrıntı için [Slide Master](/cpp/slide-master/) ve [Embedded Font](/cpp/embedded-font/) bölümlerine bakın.

## **FAQ**

**Low-code API'yi tam nesne modeline ne zaman kullanmalıyım?**

Standart bir işlem tüm bir dosya veya sunuma uygulandığında ve tekil öğeler üzerinde ayrıntılı kontrol gerektirmediğinde düşük kodlu yardımcıları kullanın. Belirli slaytları seçmek, master ve düzen ilişkilerini kontrol etmek, ara durumu denetlemek veya yardımcı tarafından sunulmayan davranışı yapılandırmak gerektiğinde tam nesne modelini kullanın.

**Merger farklı dosya biçimlerinde sunumları birleştirebilir mi?**

Hayır. [Merger::Process](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/merger/process/) aynı biçimdeki giriş sunumlarını gerektirir. Önce giriş dosyalarını ortak bir biçime dönüştürün, örneğin [Convert::AutoByExtension](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/convert/autobyextension/) ile, ardından dönüştürülmüş dosyaları birleştirin.

**ForEach master, layout ve not slaytlarını işliyor mu?**

[ForEach::Slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/slide/) normal sunum slaytları üzerinde döner. Sunum genelindeki [ForEach::Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/paragraph/) ve [ForEach::Portion](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/portion/) işlemleri varsayılan olarak normal, master ve layout slaytlarını içerir. Not slaytlarını dahil etmek için `includeNotes` parametresini `true` olarak ayarlayan aşırı yüklemelerini kullanın.

**ForEach::Shape ile Collect::Shapes arasındaki fark nedir?**

Her şekli bir geri çağırma ile hemen işlemek için [ForEach::Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/shape/) kullanın. Toplanan sonucu saklayabileceğiniz, filtreleyebileceğiniz, sayabileceğiniz veya birden çok kez dolaşabileceğiniz bir enumerable sonuca ihtiyacınız olduğunda [Collect::Shapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/collect/shapes/) kullanın.

**Compress her zaman sunum dosyasını küçültür mü?**

Mutlaka değil. Sonuç, sunumun kullanılmayan düzenler, kullanılmayan masterlar ya da kullanılmayan karakterlere sahip gömülü yazı tipleri içerip içermediğine bağlıdır. Bunların hiçbiri yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) işlemleri dosya boyutunu azaltmayabilir.

**ForEach veya Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**

Hayır. Bu yardımcılar, bellekte yüklü [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/) geri çağırmasında öğeleri değiştirdikten veya [Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) çalıştırdıktan sonra sonucu yazmak için [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) metodunu çağırın.

## **İlgili Makaleler**

- [Sunumu Dönüştür](/cpp/convert-presentation/)
- [Sunumları Birleştir](/cpp/merge-presentation/)
- [Slayt Master](/cpp/slide-master/)
- [Metin Kutusunu Yönet](/cpp/manage-textbox/)
- [Gömülü Yazı Tipi](/cpp/embedded-font/)