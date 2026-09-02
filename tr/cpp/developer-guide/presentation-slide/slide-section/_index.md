---
title: C++ ile Sunumlarda Slayt Bölümlerini Yönetme
linktitle: Slayt Bölümü
type: docs
weight: 100
url: /tr/cpp/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölüm düzenle
- bölüm değiştir
- bölüm adı
- bölüm slaytlarını al
- bölüm slaytlarını işle
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile slayt bölümlerini yönetin: PPTX sunumlarında bölümler oluşturun, yeniden adlandırın, yeniden sıralayın, bölüm slaytlarını alın ve işleyin."
---
## **Giriş**

Bölümler, ardışık slaytları slayt içeriğini değiştirmeden adlandırılmış gruplar halinde düzenler. Aspose.Slides for C++ ile bir bölümü [Presentation::get_Sections](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_sections/) yöntemiyle oluşturabilir, yeniden sıralayabilir, yeniden adlandırabilir, inceleyebilir ve kaldırabilirsiniz.

Bölümler özellikle aşağıdaki durumlarda kullanışlıdır:

- büyük bir sunum mantıksal konulara veya bölümlere ayrılmalıdır;
- slaytların farklı grupları farklı iş ortaklarına atanır;
- slaytların gruplar halinde işlenmesi, taşınması veya birleştirilmesi gerekir.

Gruplanmış slaytların amacını açıklayan kısa bölüm adları seçin. Bölümler sunum yapısının bir parçası olduğundan, üyeliği slayt konumlarından türetmek yerine bölüm API'lerini kullanarak belirleyin.

## **Bölümleri Oluşturma ve Yönetme**

[ISectionCollection::AddSection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isectioncollection/addsection/) kullanarak bir bölümü adı ve başlangıç slaytı belirterek oluşturabilirsiniz. Aspose.Slides, bölüme hangi slaytların ait olduğunu sunumun mevcut bölüm yapısından belirler.

Aynı [ISectionCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isectioncollection/) ayrıca şunları yapmanıza olanak tanır:

- bir bölümü slaytlarıyla birlikte [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isectioncollection/reordersectionwithslides/) kullanarak taşıyabilirsiniz;
- yalnızca bölüm tanımını [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isectioncollection/removesection/) ile kaldırarak slaytlarını koruyabilirsiniz;
- bir bölümü ve slaytlarını [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isectioncollection/removesectionwithslides/) ile kaldırabilirsiniz;
- sonunda boş bir bölüm eklemek için [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isectioncollection/appendemptysection/) kullanabilirsiniz.

Aşağıdaki örnek iki bölüm oluşturur, birini taşır, onu slaytlarıyla birlikte kaldırır ve boş bir bölüm ekler:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

Bu işlemlerden sonra sunum, slaytlarıyla birlikte `Introduction` bölümünü ve boş bir `Appendix` bölümünü içerir. `Results` bölümü ve slaytları kaldırılmıştır.

## **Bölümleri Yeniden Adlandırma**

Bir bölümü yeniden adlandırmak için [ISection::set_Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isection/set_name/) metodunu çağırın. Bölümün slaytları ve konumu değişmeden kalır.

Aşağıdaki örnek bir bölüm oluşturur ve adını değiştirir:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **Bölümlerden Slaytları Almak**

[Presentation::get_Sections](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_sections/) yöntemi, üzerinde yineleme yapabileceğiniz bir [ISectionCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isectioncollection/) döndürür. Her bir [ISection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isection/) için, o bölüme şu anda ait slaytları elde etmek üzere [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isection/getslideslistofsection/) metodunu çağırın. Metod, bir sayım, indeksli erişim ve yineleme sağlayan bir [ISectionSlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isectionslidecollection/) döndürür.

Aşağıdaki örnek iki doldurulmuş bölüm ve bir boş bölüm oluşturur, ardından her bölümün [name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isection/get_name/), [identifier](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isection/get_sectionid/), [starting slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isection/get_startedfromslide/), slayt sayısı ve slayt numaralarını yazdırır. İlk slaytı okumak için indeksli erişim, tüm slaytları işlemek için ise aralık‑tabanlı `for` döngüsü kullanılır. Boş bölüm için döndürülen koleksiyonun sayısı sıfırdır, indeksli erişim kullanılmaz ve yineleme hiçbir iterasyon yapmaz.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

Bölüm üyeliği, sunumun bölüm yapısı tarafından belirlenir. Bir bölümün aralığını [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isection/get_startedfromslide/) değerinden, slayt indekslerinden ve bir sonraki bölümün başlangıç slaytından elle hesaplamayın.

Yapısal düzenlemeler, bir bölüm için döndürülen slaytları ve slayt numaralarını değiştirebilir. Buna slaytların yeniden sıralanması, bir slaytın bölüme kopyalanması, bir bölümün slaytlarıyla birlikte taşınması, slaytların kaldırılması ve bölümlerin kaldırılması dahildir. Sonraki örnek, bu tür her değişiklikten sonra bölüm sınırları hakkında varsayımları korumak yerine [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isection/getslideslistofsection/) metodunu tekrar çağırır.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

Slaytlar veya bölümler yeniden sıralandığında, kopyalandığında, taşındığında veya kaldırıldığında [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isection/getslideslistofsection/) metodunu tekrar çağırın. Bu, sonraki işlemlerin mevcut sunum yapısına uyumlu kalmasını sağlar.

PPT (PowerPoint 97–2003) formatı bölüm meta verilerini korumaz. Bölümleri destekleyen bir formatla, örneğin PPTX ile, bu iş akışını kullanın; PPT’ye dönüştürmek, daha sonraki yineleme için gereken bölüm yapısını kaldırır.

## **SSS**

**Bölümler PPT (PowerPoint 97–2003) formatına kaydedildiğinde korunur mu?**

Hayır. PPT formatı bölüm meta verilerini desteklemez, bu yüzden .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Bir bütün bölüm "gizlenebilir" mi?**

Hayır. Bir bölümün görünürlük durumu yoktur. İçeriğini gizlemek için bölümdeki her slayt için [ISlide::set_Hidden](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/set_hidden/) metodunu çağırın.

**Bir slaytı içeren bölümü nasıl bulabilirim?**

[Presentation::get_Sections](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_sections/) metodunu yineleyin, her bölüm için [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isection/getslideslistofsection/) metodunu çağırın ve döndürülen slaytları hedef slayt ile karşılaştırın. Boş olmayan bir bölüm için [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isection/get_startedfromslide/) ilk slaytını döndürür; boş bir bölüm için `nullptr` döndürür.