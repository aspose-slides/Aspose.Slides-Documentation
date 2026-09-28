---
title: Použít nebo změnit rozložení snímků v C++
linktitle: Rozložení snímku
type: docs
weight: 60
url: /cs/cpp/slide-layout/
keywords:
- rozložení snímku
- rozložení obsahu
- zástupný objekt
- návrh prezentace
- návrh snímku
- nepoužité rozložení
- viditelnost patičky
- titulní snímek
- titul a obsah
- hlavička sekce
- dvě oblasti obsahu
- srovnání
- pouze nadpis
- prázdné rozložení
- obsah s popiskem
- obrázek s popiskem
- nadpis a svislý text
- svislý nadpis a text
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Použijte, vytvářejte a upravujte rozložení snímků v Aspose.Slides pro C++, přidávejte zástupné objekty, odstraňujte nepoužitá rozložení a ovládejte viditelnost patičky."
---
## **Přehled**

Rozložení snímku určuje polohu a formátování zástupných objektů, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použití rozložení poskytuje snímkům konzistentní strukturu a zároveň umožňuje, aby každý snímek obsahoval svůj vlastní obsah.

Mezi nejčastější rozložení patří:

- **Title Slide**: Obsahuje zástupné objekty nadpisu a podnadpisu.
- **Title and Content**: Obsahuje zástupný objekt nadpisu a obecný zástupný objekt obsahu.
- **Blank**: Neobsahuje žádné zástupné objekty obsahu a je užitečné, když bude každý tvar umístěn ručně.

## **Pochopit dědičnost rozložení**

Prezentace má tři související úrovně:

1. A [master slide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/) určuje téma, sdílené formátování, pozadí a společné objekty.
1. A [layout slide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/) patří k masteru a určuje konkrétní uspořádání zástupných objektů.
1. A [normal slide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/) používá jedno rozložení a ukládá obsah zadaný pro tento snímek.

Normální snímek dědí téma a formátování ze svého rozložení a rozložení dědí od svého masteru. Hodnota nastavená přímo na normálním snímku přebije zděděnou hodnotu na této úrovni. Když je normální snímek vytvořen, jeho tvary zástupných objektů jsou generovány ze zvoleného rozložení, zatímco obsah zadaný do těchto zástupných objektů patří normálnímu snímku.

Přidejte požadované zástupné objekty do rozložení před vytvořením snímků z něj. Přidání dalšího zástupného objektu do rozložení později automaticky nepřidá odpovídající tvar zástupného objektu do existujících normálních snímků.

Tento vztah má dvě důležité důsledky:

- Změna zděděného formátování nebo existující geometrie zástupných objektů v rozložení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozložení, které již je používáno, zkontrolujte jeho závislé snímky a přezkoumejte vzniklou prezentaci.
- Rozložení, které je stále používáno snímkem, nelze odstranit. Nejprve přiřaďte jeho závislé snímky k jinému rozložení nebo odstraňte pouze nepoužívaná rozložení.

Pro více informací o nejvyšší úrovni této hierarchie navštivte [Slide Master](/slides/cs/cpp/slide-master/).

Chcete-li skrýt zděděná loga nebo dekorativní tvary masteru na jednom snímku nebo prostřednictvím sdíleného rozložení, podívejte se na [Control the Visibility of Master Graphics](/slides/cs/cpp/slide-master/). Příklad porovnává dva snímky používající stejný master.

## **Vybrat a použít rozložení snímku**

Používejte typ rozložení, když prezentace následuje standardní definice rozložení PowerPointu. Názvy rozložení lze upravovat a mohou být lokalizovány, takže výběr podle názvu je méně spolehlivý, pokud neovládáte zdrojovou šablonu.

Následující příklad hledá **Title and Content** na prvním masteru. Pokud toto rozložení není k dispozici, úmyslně přepne na **Blank**. Druhá kontrola null je nutná, protože prezentace může obsahovat pouze vlastní rozložení. Vybrané rozložení je pak použito na první normální snímek pomocí metody [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/set_layoutslide/).

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

Změna rozložení snímku neodstraňuje běžné tvary přidané přímo na snímek. Nicméně se mohou změnit pozice zástupných objektů, zděděné formátování a shoda mezi existujícími zástupnými objekty a novým rozložením, takže výstup při přepínání mezi výrazně odlišnými rozloženími zkontrolujte.

## **Přidat rozložení snímku**

Výběr a vytvoření jsou samostatné operace. Předchozí příklad vybírá existující rozložení; nevytváří nové. Pro vytvoření rozložení zavolejte metodu [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterlayoutslidecollection/add/) na kolekci rozložení cílového masteru.

Následující příklad vždy přidá nové rozložení **Title and Content** s názvem `Report Title and Content` a poté přidá normální snímek založený na tomto rozložení. Názvy rozložení musejí být v kolekci jedinečné.

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

Přidejte rozložení jen tehdy, když šablona skutečně potřebuje další opakovaně použitelné uspořádání. Pokud již existuje vhodné rozložení, vyberte a znovu jej použijte místo vytváření duplikátu.

## **Přidat zástupné objekty do rozložení snímku**

Metoda [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) poskytuje [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutplaceholdermanager/) pro přidávání tvarů zástupných objektů do rozložení.

| Zástupný objekt PowerPointu | `ILayoutPlaceholderManager` Method |
| --------------------------- | ---------------------------------- |
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

Následující příklad ověřuje, že rozložení **Blank** existuje, přidá k němu čtyři zástupné objekty a poté vytvoří normální snímek, který používá upravené rozložení. Pořadí je úmyslné: zástupné objekty jsou přidány před vytvořením normálního snímku, aby Aspose.Slides mohl vygenerovat odpovídající tvary zástupných objektů na tomto snímku.

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
Změna zděděného formátování nebo geometrie existujících zástupných objektů rozložení může ovlivnit závislé snímky. Nově přidaný zástupný objekt rozložení není doplněn do existujících normálních snímků. Otestujte změny rozložení na kopii prezentace a zkontrolujte každý závislý snímek.
{{% /alert %}}

## **Odstranit nepoužívaná rozložení snímků**

Použijte metodu [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) k odstranění rozložení, na která neodkazuje žádný normální snímek. Metoda ponechá rozložení, která jsou stále používána, nedotčena.

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

Pro odstranění konkrétního rozložení nejprve použijte jeho metodu [get_HasDependingSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) nebo [GetDependingSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/getdependingslides/). Přiřaďte všechny závislé snímky před voláním [ILayoutSlide::Remove](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/remove/). Pokud se pokusíte odstranit používané rozložení, dojde k vyvolání výjimky [PptxEditException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pptxeditexception/).

## **Ovládání viditelnosti patičky na rozložení snímku**

Rozložení má své vlastní zástupné objekty patičky, čísla snímku a data/času. Použijte metodu [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) pro ovládání těchto zástupných objektů u jednoho rozložení. To je užitečné například když rozložení obsahu má zobrazovat patičky, ale rozložení titulků ne.

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

## **Ovládání viditelnosti patičky na masteru a jeho podřízených rozloženíc**

Pro aplikaci jednotných nastavení patičky napříč hierarchií masteru použijte metodu [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Metody šíření [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslideheaderfootermanager/) fungují na masteru i na jeho závislých rozložení snímků a normálních snímcích; neaplikují se jen na jeden normální snímek.

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

**Jaký je rozdíl mezi master snímkem a layout snímkem?**

Master snímek určuje téma prezentace a sdílené formátování. Layout snímek patří k masteru a určuje jedno opakovaně použitelné uspořádání zástupných objektů. Normální snímky používají tato rozložení a ukládají obsah specifický pro snímek.

**Mohu zkopírovat layout snímek z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Při kopírování mezi prezentacemi také ověřte písma, motivy, obrázky a další zdroje použité zdrojovým rozložením.

**Co se stane, když upravím rozložení, které je již používáno?**

Závislé snímky zdědí změny rozložení, pokud místně nepřepíšou postižené formátování nebo objekty. Geometrie zástupných objektů a zděděné stylování se tak mohou najednou změnit na mnoha snímcích. Použijte [GetDependingSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/getdependingslides/) k identifikaci ovlivněných snímků před úpravou rozložení.

**Co se stane, pokud odstraním rozložení, které je stále používáno?**

Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pptxeditexception/). Nejprve přiřaďte závislé snímky, nebo použijte [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) k odstranění pouze neodkazovaných rozložení.