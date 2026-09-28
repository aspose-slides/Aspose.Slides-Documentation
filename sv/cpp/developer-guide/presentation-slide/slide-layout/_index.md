---
title: "Använda eller ändra bildlayouter i C++"
linktitle: "Bildlayout"
type: docs
weight: 60
url: /sv/cpp/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationdesign
- bilddesign
- oanvänd layout
- fotnotssynlighet
- titelsida
- titel och innehåll
- sektionstitel
- två innehåll
- jämförelse
- endast titel
- tom layout
- innehåll med bildtext
- bild med bildtext
- titel och vertikal text
- vertikal titel och text
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Använd, skapa och modifiera bildlayouter i Aspose.Slides för C++, lägg till platshållare, ta bort oanvända layouter och kontrollera fotnotssynlighet."
---
## **Översikt**

En bildlayout definierar positionerna och formateringen av platshållare som titlar, text, bilder, diagram och tabeller. Att tillämpa en layout ger bilder en konsekvent struktur samtidigt som varje bild kan innehålla eget innehåll.

De vanligaste layouterna inkluderar:

- **Titelbild**: Innehåller platshållare för titel och undertitel.
- **Titel och innehåll**: Innehåller en titelplatshållare och en allmän innehållsplatshållare.
- **Tom**: Innehåller inga innehållsplatshållare och är användbar när varje form placeras manuellt.

## **Förstå layoutarv**

En presentation har tre relaterade nivåer:

1. En [masterbild](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslide/) definierar temat, gemensam formatering, bakgrunder och gemensamma objekt.
1. En [layoutbild](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/) tillhör en master och definierar en särskild arrangemang av platshållare.
1. En [vanlig bild](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/) använder en layout och lagrar innehållet som matas in för den bilden.

En vanlig bild ärver tema och formatering från sin layout, och layouten ärver från sin master. Ett värde som sätts direkt på en vanlig bild åsidosätter det ärvda värdet på den nivån. När en vanlig bild skapas genereras dess platshållarformer från den valda layouten, medan innehållet som matas in i dessa platshållare tillhör den vanliga bilden.

Lägg till nödvändiga platshållare i en layout innan du skapar bilder från den. Att senare lägga till en ytterligare platshållare i en layout lägger inte automatiskt till en motsvarande platshållarform i befintliga vanliga bilder.

Denna relation har två viktiga konsekvenser:

- Att ändra ärvd formatering eller befintlig platshållargeometri i en layout kan uppdatera varje bild som är beroende av den. Innan du redigerar en layout som redan används, inspektera dess beroende bilder och granska den resulterande presentationen.
- En layout som fortfarande används av en bild kan inte tas bort. Tilldela först dess beroende bilder till en annan layout, eller ta bara bort oanvända layouter.

För mer information om den översta nivån i denna hierarki, se [Slide Master](/slides/sv/cpp/slide-master/).

För att dölja ärvda logotyper eller dekorativa masterformer på en bild eller via en gemensam layout, se [Control the Visibility of Master Graphics](/slides/sv/cpp/slide-master/). Exemplet jämför två bilder som använder samma master.

## **Välj och tillämpa en bildlayout**

Använd en layouttyp när presentationen följer standarddefinitionerna för PowerPoint‑layouter. Layoutnamn kan redigeras av användaren och kan lokaliseras, så namn‑baserad urval är mindre pålitligt om du inte kontrollerar källmallen.

Följande exempel letar efter **Titel och innehåll** på den första mastern. Om den layouten inte är tillgänglig faller den avsiktligt tillbaka till **Tom**. Den andra null‑kontrollen är nödvändig eftersom en presentation kan innehålla endast anpassade layouter. Den valda layouten tillämpas sedan på den första vanliga bilden via metoden [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/set_layoutslide/).

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

Att ändra en bilds layout tar inte bort vanliga former som lagts till direkt på bilden. Däremot kan platshållarpositioner, ärvd formatering och korrespondensen mellan befintliga platshållare och den nya layouten förändras, så inspektera resultatet när du växlar mellan väsentligt olika layouter.

## **Lägg till en layoutbild**

Urval och skapande är separata operationer. Det föregående exemplet väljer en befintlig layout; det skapar ingen. För att skapa en layout, anropa metoden [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterlayoutslidecollection/add/) på målmastarens layoutsamling.

Följande exempel lägger alltid till en ny **Titel och innehåll**‑layout med namnet `Report Title and Content`, och lägger sedan till en vanlig bild baserad på den. Layoutnamn måste vara unika inom samlingen.

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

Lägg till en layout endast när mallen verkligen behöver en ytterligare återanvändbar struktur. Om en lämplig layout redan finns, välj och återanvänd den i stället för att skapa en duplikat.

## **Lägg till platshållare i en layoutbild**

Metoden [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) tillhandahåller en [ILayoutPlaceholderManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/) för att lägga till platshållarformer i en layout.

| PowerPoint‑platshållare | Metod för `ILayoutPlaceholderManager` |
| ----------------------- | -------------------------------------- |
| ![Innehåll](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Innehåll (Vertikal)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertikal)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Bild](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagram](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tabell](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online‑bild](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Följande exempel verifierar att **Tom**‑layouten finns, lägger till fyra platshållare i den och skapar sedan en vanlig bild som använder den modifierade layouten. Ordningen är avsiktlig: platshållarna läggs till innan den vanliga bilden skapas, så att Aspose.Slides kan generera motsvarande platshållarformer på den bilden.

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

Resultatet:

![Platshållarna på layoutbilden](add_placeholders.png)

{{% alert color="warning" title="Varning" %}}
Att ändra ärvd formatering eller geometrin för befintliga layout‑platshållare kan påverka beroende bilder. En nylagd layout‑platshållare fylls inte i retroaktivt i befintliga vanliga bilder. Testa layout‑ändringar på en kopia av presentationen och inspektera varje beroende bild.
{{% /alert %}}

## **Ta bort oanvända layoutbilder**

Använd metoden [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) för att ta bort layouter som ingen vanlig bild refererar till. Metoden lämnar intakta de layouter som fortfarande används.

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

För att ta bort en specifik layout, använd först dess [get_HasDependingSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/)‑metod eller [GetDependingSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/getdependingslides/)‑metod. Tilldela om eventuella beroende bilder innan du anropar [ILayoutSlide::Remove](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/remove/). Försök att ta bort en layout som fortfarande används resulterar i ett [PptxEditException](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pptxeditexception/).

## **Styr fotnotens synlighet på en layoutbild**

En layout har sina egna fotnoter, bildnummer‑ och datum‑tid‑platshållare. Använd metoden [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) för att styra dessa platshållare för en layout. Detta är användbart när exempelvis innehållslayouter ska visa fotnoter men titel‑layouter inte ska.

Följande exempel väljer säkert en layout och gör dess fotnotselement synliga:

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

## **Styr fotnotens synlighet på en master och dess underliggande layouter**

För att tillämpa enhetliga fotnotinställningar över en master‑hierarki, använd metoden [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Spridningsmetoderna i [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslideheaderfootermanager/) verkar på mastern samt dess beroende layout‑bilder och vanliga bilder; de riktar sig inte enbart mot en enskild vanlig bild.

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

## **FAQ**

**Vad är skillnaden mellan en masterbild och en layoutbild?**

En masterbild definierar presentationens tema och gemensamma formatering. En layoutbild tillhör en master och definierar en återanvändbar arrangemang av platshållare. Vanliga bilder använder dessa layouter och lagrar bildspecifikt innehåll.

**Kan jag kopiera en layoutbild från en presentation till en annan?**

Ja. Lägg till en kopia i destinationssamlingen med metoden [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/igloballayoutslidecollection/addclone/). När du kopierar mellan presentationer, verifiera även teckensnitt, teman, bilder och andra resurser som används av källlayouten.

**Vad händer när jag ändrar en layout som redan är i bruk?**

Beroende bilder ärver layout‑ändringarna om de inte åsidosätter den påverkade formateringen eller objekten lokalt. Platshållargeometri och ärvd stil kan därför förändras på många bilder samtidigt. Använd [GetDependingSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/getdependingslides/) för att identifiera de påverkade bilderna innan du redigerar layouten.

**Vad händer om jag tar bort en layout som fortfarande används?**

Aspose.Slides kastar ett [PptxEditException](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pptxeditexception/). Tilldela först de beroende bilderna på nytt, eller använd [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) för att bara ta bort orefererade layouter.