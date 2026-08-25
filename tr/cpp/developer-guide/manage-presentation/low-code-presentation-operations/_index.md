---
title: C++'ta Düşük Kodlu Sunum İşlemleri
linktitle: Düşük Kodlu API
type: docs
weight: 50
url: /tr/cpp/low-code-presentation-operations/
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
- kullanılmayan düzen slaytları kaldır
- gömülü yazı tiplerini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides düşük kodlu API'sini C++'ta kullanarak sunumları dönüştürüp birleştirin, içerik içinde yineleme yapın, şekilleri toplayın ve sunum boyutunu azaltın."
---
## **Genel Bakış**

The [Aspose::Slides::LowCode](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code yardımcılar, işlemin tüm dosya veya sunuma uygulanması ve varsayılan iş akışının gereksinimlerinizi karşılaması durumunda en yararlıdır. Bireysel slaytlar, masterlar, düzenler, şekiller, dışa aktarma ayarları veya sunum öğeleri arasındaki ilişkiler üzerinde ayrıntılı kontrol gerektiğinde tam [Aspose.Slides object model](https://reference.aspose.com/slides/tr/cpp/aspose.slides/) kullanın.

Aşağıdaki tablo mevcut yardımcıları özetler:

| Yardımcı | Ne için kullanılır |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/convert/) | Sunumu başka bir formata, doğrudan dosya‑dosya çağrısıyla dönüştürme. |
| [Merger](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/merger/) | Aynı formatta tam sunum dosyalarını birleştirme. |
| [ForEach](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/) | Her slayt, şekil, paragraf veya metin bölümü için bir eylem çalıştırma. |
| [Collect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/collect/) | Tekrarlanan işleme veya analiz için tüm sunumdan şekilleri alabilme. |
| [Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) | Kullanılmayan master ve düzenleri kaldırma ve gömülü yazı tipi verilerini azaltma. |

## **Bir Sunumu Dönüştür**

Çıktı dosya uzantısının dışa aktarma formatını seçmek için yeterli olduğu durumlarda [Convert::AutoByExtension](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/convert/autobyextension/) kullanın. Yöntem kaynak sunumu açar, çıktı yolundan gerekli formatı belirler ve sonucu yazar.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

[Convert](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/convert/) sınıfı ayrıca PDF, SVG, JPEG, PNG ve TIFF çıktısı için özel yöntemler sunar. Dışa aktarmadan önce sunumu incelemeniz veya değiştirmeniz ya da seçili yardımcı tarafından sunulmayan bir dışa aktarma seçeneği yapılandırmanız gerektiğinde tam nesne modelini kullanın. Biçime özgü iş akışları ve seçenekler için [Convert Presentation](/slides/tr/cpp/convert-presentation/) sayfasına bakın.

## **Sunumları Birleştir**

Tam sunum dosyalarını tek bir çağrı ile birleştirmek için [Merger::Process](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/merger/process/) kullanın. Girdi sunumları aynı dosya formatına sahip olmalıdır.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Bu yardımcı, tüm slaytların tek bir sonuca ayrı ayrı seçilmeden veya yeniden eşlenmeden eklenmesi gerektiğinde uygundur. Seçili slaytları birleştirmeniz, hedef bir master veya düzen uygulamanız, bölümleri açıkça korumanız ya da farklı slayt boyutlarını uyumlu hale getirmeniz gerektiğinde tam nesne modelini kullanın. Bu senaryolar için [Merge Presentations](/slides/tr/cpp/merge-presentation/) sayfasına bakın.

## **Sunum Öğeleri Üzerinde Döngü**

[ForEach](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/) sınıfı, her istenen sunum öğesi türü için bir geri çağırma (callback) çalıştırır. İç içe koleksiyon döngülerini önler ve sunum genelinde denetim veya biçimlendirme değişiklikleri için uygundur.

Şu örnek, ilgili öğeleri incelemek için [ForEach::Slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/paragraph/), ve [ForEach::Portion](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/portion/) kullanır:

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

Varsayılan olarak, sunum genelindeki şekil ve metin dolaşımı normal, master ve düzen slaytlarını içerir. `includeNotes` parametresiyle aşırı yüklemeler not slaytlarını da işleyebilir. Dolaşım sırası, erken çıkış, geri çağırma öncesi filtreleme veya ayrıntılı ebeveyn‑çocuk kontrolünün önemli olduğu durumlarda doğrudan koleksiyon döngüleri kullanın.

## **Şekilleri Topla**

Her şekil için bir geri çağırma yerine bir sunumdaki tüm şekillerin koleksiyonuna ihtiyaç duyduğunuzda [Collect::Shapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/collect/shapes/) kullanın. Aynı kümenin birden çok kez filtrelenmesi, sayılması veya işlenmesi gerektiğinde bu yararlıdır.

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

Her şekil anında işlenebiliyorsa ve topladığınız sonuçları tutmanıza gerek yoksa bunun yerine [ForEach::Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/shape/) kullanın.

## **Sunum İçeriğini Sıkıştır**

[Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) sınıfı kullanılmayan yapısal öğeleri kaldırabilir ve gömülü yazı tipi verilerini azaltabilir:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) normal slaytların referans vermediği düzen slaytlarını kaldırır.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) artık kullanılmayan master slaytları kaldırır.
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

Kullanılmayan düzenleri, kullanılmayan masterlardan önce kaldırın; böylece düzen temizliği sonrasında referansı kaybolan bir master da kaldırılabilir. Orijinal master, düzen veya tam gömülü yazı tipi verilerine ileride ihtiyaç duyabilecekseniz optimize edilmiş sunumu yeni bir dosyaya kaydedin. Daha fazla ayrıntı için [Slide Master](/slides/tr/cpp/slide-master/) ve [Embedded Font](/slides/tr/cpp/embedded-font/) sayfalarına bakın.

## **SSS**

**Low-code API'yi tam nesne modeline ne zaman kullanmalıyım?**  
Low-code yardımcıları, standart bir işlem tüm dosya veya sunuma uygulanıp bireysel öğeler üzerinde ayrıntılı kontrol gerektirmediğinde kullanın. Belirli slaytları seçmeniz, master ve düzen ilişkilerini kontrol etmeniz, ara durumu incelemeniz ya da yardımcı tarafından sunulmayan bir davranışı yapılandırmanız gerektiğinde tam nesne modelini kullanın.

**Merger farklı dosya formatlarındaki sunumları birleştirebilir mi?**  
Hayır. [Merger::Process](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/merger/process/) aynı formatta giriş sunumları gerektirir. Giriş dosyalarını önce ortak bir formata dönüştürün, örneğin [Convert::AutoByExtension](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/convert/autobyextension/) ile, ardından dönüştürülmüş dosyaları birleştirin.

**ForEach master, layout ve not slaytlarını işler mi?**  
[ForEach::Slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/slide/) normal sunum slaytları üzerinde döner. Sunum genelinde [ForEach::Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/paragraph/), ve [ForEach::Portion](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/portion/) işlemleri varsayılan olarak normal, master ve layout slaytlarını içerir. Not slaytlarını dahil etmek için `includeNotes` parametresini `true` olarak ayarlayan aşırı yüklemeleri kullanın.

**ForEach::Shape ile Collect::Shapes arasındaki fark nedir?**  
[ForEach::Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/shape/) her şekli bir geri çağırma ile hemen işlemek için kullanın. [Collect::Shapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/collect/shapes/) sonuçları tutulabilir, filtrelenebilir, sayılabilir veya birden çok kez dolaşılabilir bir enumerable sonuç gerektiğinde kullanın.

**Compress her zaman sunum dosyasını küçültür mü?**  
Gerekli değildir. Sonuç, sunumun kullanılmayan düzenler, kullanılmayan masterlar veya kullanılmayan karakterlere sahip gömülü yazı tipleri içerip içermediğine bağlıdır. Bu öğeler yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) işlemleri dosya boyutunu azaltmayabilir.

**ForEach veya Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**  
Hayır. Bu yardımcılar, bellekte yüklü [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/foreach/) geri çağırma içinde öğeleri değiştirdikten veya [Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) çalıştırdıktan sonra sonucu yazmak için [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) çağırın.

## **İlgili Makaleler**

- [Sunumu Dönüştür](/slides/tr/cpp/convert-presentation/)
- [Sunumları Birleştir](/slides/tr/cpp/merge-presentation/)
- [Slayt Masterı](/slides/tr/cpp/slide-master/)
- [Metin Kutusunu Yönet](/slides/tr/cpp/manage-textbox/)
- [Gömülü Yazı Tipi](/slides/tr/cpp/embedded-font/)