---
title: Použít nebo změnit rozvržení snímků v C++
linktitle: Rozvržení snímku
type: docs
weight: 60
url: /cs/cpp/slide-layout/
keywords:
- rozvržení snímku
- rozvržení obsahu
- zástupný objekt
- návrh prezentace
- návrh snímku
- nepoužité rozvržení
- viditelnost zápatí
- snímek s nadpisem
- nadpis a obsah
- hlavička sekce
- dva obsahy
- porovnání
- pouze nadpis
- prázdné rozvržení
- obsah s popiskem
- obrázek s popiskem
- nadpis a svislý text
- svislý nadpis a text
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Použijte, vytvořte a upravte rozvržení snímků v Aspose.Slides pro C++, přidejte zástupné objekty, odstraňte nepoužitá rozvržení a ovládejte viditelnost zápatí."
---
## **Přehled**

Rozvržení snímku definuje pozice a formátování zástupných objektů, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použití rozvržení poskytuje snímkům konzistentní strukturu a zároveň umožňuje, aby každý snímek obsahoval vlastní obsah.

Nejčastější rozvržení zahrnují:

- **Title Slide**: Obsahuje zástupné objekty nadpisu a podnadpisu.
- **Title and Content**: Obsahuje zástupný objekt nadpisu a obecný zástupný objekt pro obsah.
- **Blank**: Neobsahuje žádné zástupné objekty obsahu a je užitečné, když bude každá forma umístěna ručně.

## **Pochopení dědičnosti rozvržení**

Prezentace má tři související úrovně:

1. [Hlavní snímek](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/) definuje téma, sdílené formátování, pozadí a společné objekty.
2. [Rozvržení snímku](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/) patří hlavnímu snímku a definuje konkrétní uspořádání zástupných objektů.
3. [Normální snímek](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/) využívá jedno rozvržení a ukládá obsah zadaný pro tento snímek.

Normální snímek dědí téma a formátování ze svého rozvržení a rozvržení dědí z hlavního snímku. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Když je normální snímek vytvořen, jeho tvary zástupných objektů jsou generovány z vybraného rozvržení, zatímco obsah zadaný do těchto zástupných objektů patří normálnímu snímku.

Přidejte požadované zástupné objekty do rozvržení před vytvořením snímků z něj. Přidání dalšího zástupného objektu do rozvržení později automaticky nepřidá odpovídající tvar zástupného objektu do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo existující geometrie zástupného objektu v rozvržení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozvržení, které je již používáno, zkontrolujte jeho závislé snímky a přezkoumejte výslednou prezentaci.
- Rozvržení, které je stále používáno snímkem, nelze odstranit. Předtím přesuňte jeho závislé snímky na jiné rozvržení, nebo odstraňte jen nepoužívaná rozvržení.

Pro více informací o nejvyšší úrovni této hierarchie viz [Hlavní snímek](/slides/cs/cpp/slide-master/).

## **Vyberte a použijte rozvržení snímku**

Používejte typ rozvržení, když prezentace používá standardní definice rozvržení PowerPointu. Názvy rozvržení lze upravovat a lokalizovat, takže výběr založený na názvu je méně spolehlivý, pokud neovládáte zdrojovou šablonu.

Následující příklad hledá **Title and Content** v prvním hlavním snímku. Pokud toto rozvržení není k dispozici, úmyslně přejde na **Blank**. Druhá kontrola na null je nutná, protože prezentace může obsahovat jen vlastní rozvržení. Vybrané rozvržení je následně použito na první normální snímek pomocí metody [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/set_layoutslide/).

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Změna rozvržení snímku neodstraní běžné tvary přidané přímo na snímek. Nicméně pozice zástupných objektů, zděděné formátování a shoda mezi existujícími zástupnými objekty a novým rozvržením se mohou změnit, proto při přepínání mezi podstatně odlišnými rozvrženími zkontrolujte výstup.

## **Přidejte rozvržení snímku**

Výběr a vytvoření jsou samostatné operace. Předchozí příklad vybere existující rozvržení; nevytvoří ho. Pro vytvoření rozvržení zavolejte metodu [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterlayoutslidecollection/add/) na kolekci rozvržení cílového hlavního snímku.

Následující příklad vždy přidá nové rozvržení **Title and Content** pojmenované `Report Title and Content` a poté přidá normální snímek založený na něm. Názvy rozvržení musí být v kolekci jedinečné.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Přidejte rozvržení pouze tehdy, když šablona skutečně potřebuje další opakovaně použitelnou strukturu. Pokud již existuje vhodné rozvržení, vyberte a znovu jej použijte místo vytváření duplikátu.

## **Přidejte zástupné objekty do rozvržení snímku**

Metoda [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) poskytuje [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/) pro přidávání tvarů zástupných objektů do rozvržení.

| Zástupný objekt PowerPoint | `ILayoutPlaceholderManager` Metoda |
| -------------------------- | ---------------------------------- |
| ![Obsah](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Obsah (vertikální)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (vertikální)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Obrázek](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Graf](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tabulka](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Média](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online obrázek](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Následující příklad ověří, že rozvržení **Blank** existuje, přidá k němu čtyři zástupné objekty a poté vytvoří normální snímek, který používá upravené rozvržení. Pořadí je úmyslné: zástupné objekty jsou přidány před vytvořením normálního snímku, takže Aspose.Slides může na tomto snímku vygenerovat odpovídající tvary zástupných objektů.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Změna zděděného formátování nebo geometrie existujících zástupných objektů v rozvržení může ovlivnit závislé snímky. Nově přidaný zástupný objekt rozvržení není doplněn do existujících normálních snímků. Otestujte změny rozvržení na kopii prezentace a zkontrolujte každý závislý snímek.
{{% /alert %}}

## **Odstraňte nepoužívaná rozvržení snímků**

Použijte metodu [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) k odebrání rozvržení, na která neodkazuje žádný normální snímek. Metoda ponechá nedotčená rozvržení, která jsou stále používána.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Chcete‑li odstranit konkrétní rozvržení, nejprve použijte jeho metodu [get_HasDependingSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) nebo [GetDependingSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/getdependingslides/). Před voláním [ILayoutSlide::Remove](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/remove/) přesuňte všechny závislé snímky. Pokus o odstranění používaného rozvržení vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pptxeditexception/).

## **Řízení viditelnosti zápatí na rozvržení snímku**

Rozvržení má vlastní zástupné objekty zápatí, čísla snímků a datum‑čas. Použijte metodu [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) k řízení těchto zástupných objektů pro jedno rozvržení. To je užitečné například, když by rozvržení obsahu měla zobrazovat zápatí, ale rozvržení nadpisu ne.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Řízení viditelnosti zápatí v hlavním snímku a jeho podřízených rozvrženích**

Aby byla použita jednotná nastavení zápatí v celé hierarchii hlavního snímku, použijte metodu [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Metody šíření třídy [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslideheaderfootermanager/) působí na hlavní snímek a jeho závislé rozvržení snímků i normální snímky; nemají cíl jen jeden normální snímek.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Často kladené otázky**

**Jaký je rozdíl mezi hlavním snímkem a rozvržením snímku?**

Hlavní snímek definuje téma prezentace a sdílené formátování. Rozvržení snímku patří hlavnímu snímku a definuje jedno opakovaně použitelné uspořádání zástupných objektů. Normální snímky používají tato rozvržení a ukládají obsah specifický pro snímek.

**Mohu zkopírovat rozvržení snímku z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Při kopírování mezi prezentacemi také ověřte písma, témata, obrázky a další zdroje používané zdrojovým rozvržením.

**Co se stane, když upravím rozvržení, které je již používáno?**

Závislé snímky zdědí změny rozvržení, pokud lokálně nepřepíší ovlivněné formátování nebo objekty. Geometrie zástupných objektů a zděděné stylování se tak mohou najednou změnit na mnoha snímcích. Před úpravou rozvržení použijte [GetDependingSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/getdependingslides/) k určení ovlivněných snímků.

**Co se stane, pokud odstraním rozvržení, které je stále používáno?**

Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pptxeditexception/). Nejprve přesuňte závislé snímky, nebo použijte [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) k odstranění jen neodkazovaných rozvržení.