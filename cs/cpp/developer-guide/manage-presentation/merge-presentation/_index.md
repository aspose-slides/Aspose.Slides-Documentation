---
title: Efektivně sloučit prezentace v C++
linktitle: Sloučit prezentace
type: docs
weight: 40
url: /cs/cpp/merge-presentation/
keywords:
- sloučit PowerPoint
- sloučit prezentace
- sloučit snímky
- sloučit PPT
- sloučit PPTX
- sloučit ODP
- kombinovat PowerPoint
- kombinovat prezentace
- kombinovat snímky
- kombinovat PPT
- kombinovat PPTX
- kombinovat ODP
- C++
- Aspose.Slides
description: "Jednoduše sloučte prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) pomocí Aspose.Slides pro C++, což zjednoduší váš pracovní postup."
---
## **Přehled**

Aspose.Slides vám umožňuje sloučit prezentace klonováním snímků z jedné prezentace do druhé. Tento článek vysvětluje, jak sloučit celé prezentace nebo vybrané snímky, použít hlavní snímek nebo konkrétní rozložení během sloučení, zacházet s prezentacemi s různými velikostmi snímků a přidat sloučené snímky do sekce prezentace. také se zabývá praktickými poznámkami souvisejícími se sloučeným obsahem, včetně poznámek přednášejícího, komentářů, souborů chráněných heslem a používání vláken.

## **Sloučení prezentací**

Když sloučíte jednu prezentaci s druhou, v podstatě spojíte jejich snímky do jedné prezentace a získáte tak jeden soubor. 

{{% alert title="Info" color="info" %}}
Většina programů pro prezentace (PowerPoint nebo OpenOffice) postrádá funkce, které uživatelům umožňují takto kombinovat prezentace. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cs/cpp/) však umožňuje sloučit prezentace různými způsoby. Můžete sloučit prezentace se všemi jejich tvary, styly, texty, formátováním, komentáři, animacemi atd., aniž byste se museli obávat ztráty kvality nebo dat. 

**Viz také**

[Klonovat snímky](https://docs.aspose.com/slides/cs/cpp/clone-slides/)*.* 
{{% /alert %}}

### **Co lze sloučit**

S Aspose.Slides můžete sloučit 

* celé prezentace. Všechny snímky z prezentací skončí v jedné prezentaci
* konkrétní snímky. Vybrané snímky skončí v jedné prezentaci
* prezentace v jednom formátu (PPT na PPT, PPTX na PPTX atd.) a v různých formátech (PPT na PPTX, PPTX na ODP atd.) mezi sebou. 

{{% alert title="Poznámka" color="warning" %}} 
Kromě prezentací umožňuje Aspose.Slides sloučit i jiné soubory:

* [Obrázky](https://products.aspose.com/slides/cs/cpp/merger/image-to-image/), například [JPG na JPG](https://products.aspose.com/slides/cs/cpp/merger/jpg-to-jpg/) nebo [PNG na PNG](https://products.aspose.com/slides/cs/cpp/merger/png-to-png/)
* Dokumenty, například [PDF na PDF](https://products.aspose.com/slides/cs/cpp/merger/pdf-to-pdf/) nebo [HTML na HTML](https://products.aspose.com/slides/cs/cpp/merger/html-to-html/)
* A dva různé soubory, například [obrázek na PDF](https://products.aspose.com/slides/cs/cpp/merger/image-to-pdf/), [JPG na PDF](https://products.aspose.com/slides/cs/cpp/merger/jpg-to-pdf/) nebo [TIFF na PDF](https://products.aspose.com/slides/cs/cpp/merger/tiff-to-pdf/).
{{% /alert %}}

### **Možnosti sloučení**

Můžete použít možnosti, které určují, zda

* každý snímek ve výstupní prezentaci zachová unikátní styl
* pro všechny snímky ve výstupní prezentaci bude použit konkrétní styl. 

K sloučení prezentací poskytuje Aspose.Slides metody [AddClone](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (z rozhraní [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_slide_collection)). Existuje několik implementací metod `AddClone`, které definují parametry procesu sloučení prezentací. Každý objekt Presentation má kolekci [Slides](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), takže můžete zavolat metodu `AddClone` z prezentace, do které chcete snímky sloučit. 

`AddClone` metoda vrací objekt `ISlide`, který je klonem zdrojového snímku. Snímky ve výstupní prezentaci jsou jednoduše kopií snímků ze zdroje. Proto můžete měnit vzniklé snímky (například aplikovat styly, formátování nebo rozložení) aniž byste se museli obávat, že by to ovlivnilo zdrojové prezentace.

## **Sloučit prezentace** 

Aspose.Slides poskytuje metodu [**AddClone (ISlide)**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee), která umožní kombinovat snímky, přičemž snímky si zachovají svá rozložení a styly (výchozí parametry). 

Tento C++ kód vám ukazuje, jak sloučit prezentace:
```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Sloučit prezentace s hlavním snímkem (Slide Master)**

Aspose.Slides poskytuje metodu [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640), která umožňuje kombinovat snímky při aplikaci šablony hlavního snímku (slide master). Tímto způsobem můžete v případě potřeby změnit styl snímků ve výstupní prezentaci. 

Tento C++ kód demonstruje popsanou operaci:
```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Poznámka" color="warning" %}} 
Rozložení snímku pro hlavní snímek je určeno automaticky. Pokud nelze vhodné rozložení určit, a parametr `allowCloneMissingLayout` metody `AddClone` je nastaven na true, použije se rozložení zdrojového snímku. V opačném případě bude vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 
{{% /alert %}}

Pokud chcete, aby snímky ve výstupní prezentaci měly jiné rozložení, použijte místo toho metodu [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) při sloučení. 

## **Sloučit vybrané snímky z prezentací**

Sloučení konkrétních snímků z více prezentací je užitečné pro tvorbu vlastních sad snímků. Aspose.Slides C++ vám umožňuje vybrat a importovat jen snímky, které potřebujete. API zachovává formátování, rozložení a design původních snímků.

Následující C++ kód vytvoří novou prezentaci, přidá úvodní snímky ze dvou dalších prezentací a výsledek uloží do souboru:
```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Deklarováno výše v kódu.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Sloučit prezentace s rozložením snímku**

Tento C++ kód vám ukazuje, jak kombinovat snímky z prezentací při aplikaci vámi preferovaného rozložení snímku, abyste získali jednu výstupní prezentaci:
```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Sloučit prezentace s různými velikostmi snímků**

{{% alert title="Poznámka" color="warning" %}} 
Nemůžete sloučit prezentace s různými velikostmi snímků. 
{{% /alert %}}

Pro sloučení dvou prezentací s různými velikostmi snímků musíte změnit velikost jedné z prezentací, aby odpovídala velikosti druhé. 

Tento ukázkový kód demonstruje popsanou operaci:
```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Sloučit snímky do sekce prezentace**

Tento C++ kód vám ukazuje, jak sloučit konkrétní snímek do sekce v prezentaci:
```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

Snímek je přidán na konec sekce. 

{{% alert title="Tip" color="info" %}} 
Aspose poskytuje [ZDARMA webovou aplikaci Collage](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit [JPG na JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG obrázky, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a podobně. 
{{% /alert %}}

## **FAQ**

### Jsou poznámky přednášejícího zachovány při sloučení?

Ano. Při klonování snímků Aspose.Slides přenáší všechny prvky snímku, včetně poznámek, formátování a animací.

### Přenášejí se komentáře a jejich autoři?

Komentáře, jako součást obsahu snímku, jsou zkopírovány se snímkem. Štítky autorů komentářů jsou zachovány jako objekty komentářů v výsledné prezentaci.

### Co když je zdrojová prezentace chráněna heslem?

Musí být [otevřena s heslem](/slides/cs/cpp/password-protected-presentation/) pomocí [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/); po načtení mohou být tyto snímky bezpečně klonovány do nechráněného cílového souboru (nebo také do chráněného).

### Jak bezpečná je operace sloučení při použití více vláken?

Nepoužívejte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) z [více vláken](/slides/cs/cpp/multithreading/). Doporučené pravidlo je „jeden dokument — jedno vlákno“; různé soubory mohou být zpracovávány paralelně v samostatných vláknech.