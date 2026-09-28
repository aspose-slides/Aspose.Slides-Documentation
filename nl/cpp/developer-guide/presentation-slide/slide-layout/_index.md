---
title: Toepassen of wijzigen van dia lay-outs in C++
linktitle: Dia lay-out
type: docs
weight: 60
url: /nl/cpp/slide-layout/
keywords:
- dia lay-out
- inhoud lay-out
- plaatsvervanger
- presentatiedesign
- dia-ontwerp
- ongebruikte lay-out
- voettekst-zichtbaarheid
- titel-dia
- titel en inhoud
- sectiekop
- twee inhoud
- vergelijking
- alleen titel
- lege lay-out
- inhoud met bijschrift
- afbeelding met bijschrift
- titel en verticale tekst
- verticale titel en tekst
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Dia lay-outs toepassen, maken en wijzigen in Aspose.Slides voor C++, placeholders toevoegen, ongebruikte lay-outs verwijderen en de zichtbaarheid van de voettekst regelen."
---
## **Overzicht**

Een dia‑lay-out bepaalt de posities en opmaak van placeholders zoals titels, tekst, afbeeldingen, grafieken en tabellen. Het toepassen van een lay-out geeft dia’s een consistente structuur, terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende lay-outs omvatten:

- **Title Slide**: Bevat titel‑ en ondertitel‑placeholders.
- **Title and Content**: Bevat een titel‑placeholder en een algemeen content‑placeholder.
- **Blank**: Bevat geen content‑placeholders en is handig wanneer elke vorm handmatig wordt gepositioneerd.

## **Begrijp lay‑erfenis**

Een presentatie heeft drie verwante niveaus:

1. Een [master slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/) definieert het thema, gedeelde opmaak, achtergronden en gemeenschappelijke objecten.
2. Een [layout slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/) behoort tot een master en definieert een specifieke rangschikking van placeholders.
3. Een [normal slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/) gebruikt één lay-out en slaat de ingevoerde inhoud voor die dia op.

Een normal slide erft thema en opmaak van zijn lay-out, en de lay-out erft van de master. Een direct op een normal slide ingestelde waarde overschrijft de geërfde waarde op dat niveau. Wanneer een normal slide wordt aangemaakt, worden de placeholder‑vormen gegenereerd vanuit de geselecteerde lay-out, terwijl de ingevoerde inhoud in die placeholders behoort tot de normal slide.

Voeg de benodigde placeholders toe aan een lay-out voordat je er dia’s van maakt. Een later toegevoegde placeholder aan een lay-out voegt niet automatisch een overeenkomstige placeholder‑vorm toe aan bestaande normal slides.

Deze relatie heeft twee belangrijke consequenties:

- Het wijzigen van geërfde opmaak of bestaande placeholder‑geometrie op een lay-out kan elke afhankelijke dia bijwerken. Controleer vóór het bewerken van een lay-out die al in gebruik is, de afhankelijke dia’s en bekijk de resulterende presentatie.
- Een lay-out die nog door een dia wordt gebruikt, kan niet worden verwijderd. Wijs eerst de afhankelijke dia’s opnieuw toe aan een andere lay-out, of verwijder alleen ongebruikte lay-outs.

Voor meer informatie over het bovenste niveau van deze hiërarchie, zie [Slide Master](/slides/nl/cpp/slide-master/).

Om geërfde logo’s of decoratieve master‑vormen op één dia of via een gedeelde lay-out te verbergen, zie [Control the Visibility of Master Graphics](/slides/nl/cpp/slide-master/). Het voorbeeld vergelijkt twee dia’s die dezelfde master gebruiken.

## **Selecteer en pas een dia‑lay-out toe**

Gebruik een lay-outtype wanneer de presentatie de standaard PowerPoint‑lay-outdefinities volgt. Lay-outnamen kunnen door de gebruiker worden bewerkt en gelokaliseerd, waardoor selectie op basis van naam minder betrouwbaar is, tenzij je de bron‑template beheert.

Het volgende voorbeeld zoekt naar **Title and Content** op de eerste master. Als die lay-out niet beschikbaar is, valt het expres terug op **Blank**. De tweede null‑check is nodig omdat een presentatie alleen aangepaste lay-outs kan bevatten. De geselecteerde lay-out wordt vervolgens toegepast op de eerste normal slide via de [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/set_layoutslide/)‑methode.

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

Het wijzigen van de lay-out van een dia verwijdert niet de gewone vormen die rechtstreeks aan de dia zijn toegevoegd. Placeholder‑posities, geërfde opmaak en de overeenkomst tussen bestaande placeholders en de nieuwe lay-out kunnen echter veranderen, dus inspecteer de output bij het schakelen tussen aanzienlijk verschillende lay-outs.

## **Voeg een lay-out‑dia toe**

Selectie en creatie zijn afzonderlijke handelingen. Het vorige voorbeeld selecteert een bestaande lay-out; het maakt er geen aan. Om een lay-out te maken, roep je de [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterlayoutslidecollection/add/)‑methode aan op de lay-outcollectie van de doel‑master.

Het volgende voorbeeld voegt altijd een nieuwe **Title and Content** lay-out toe met de naam `Report Title and Content`, en voegt vervolgens een normal slide toe die daarop gebaseerd is. Lay-outnamen moeten uniek zijn binnen de collectie.

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

Voeg een lay-out alleen toe wanneer de template werkelijk een extra herbruikbare structuur nodig heeft. Als er al een geschikte lay-out bestaat, selecteer en hergebruik die in plaats van een duplicaat te maken.

## **Voeg placeholders toe aan een lay-out‑dia**

De [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/)‑methode levert een [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/) voor het toevoegen van placeholder‑vormen aan een lay-out.

| PowerPoint‑placeholder | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![Inhoud](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Inhoud (Verticaal)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Tekst](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Tekst (Verticaal)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Afbeelding](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Grafiek](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tabel](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online‑afbeelding](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Het volgende voorbeeld controleert of de **Blank** lay-out bestaat, voegt er vier placeholders aan toe, en maakt vervolgens een normal slide die de aangepaste lay-out gebruikt. De volgorde is opzettelijk: de placeholders worden toegevoegd vóórdat de normal slide wordt aangemaakt, zodat Aspose.Slides de overeenkomstige placeholder‑vormen op die dia kan genereren.

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

Het resultaat:

![De placeholders op de lay-out‑dia](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Het wijzigen van geërfde opmaak of de geometrie van bestaande lay-out‑placeholders kan afhankelijke dia’s beïnvloeden. Een nieuw toegevoegde lay-out‑placeholder wordt niet achteraf toegevoegd aan bestaande normal slides. Test lay-out‑wijzigingen op een kopie van de presentatie en inspecteer elke afhankelijke dia.
{{% /alert %}}

## **Verwijder ongebruikte lay‑out‑dia’s**

Gebruik de [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)‑methode om lay-outs te verwijderen die door geen enkele normal slide worden gerefereerd. De methode laat lay-outs die nog in gebruik zijn onveranderd.

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

Om één specifieke lay-out te verwijderen, gebruik eerst zijn [get_HasDependingSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/)‑methode of [GetDependingSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/getdependingslides/)‑methode. Wijs alle afhankelijke dia’s opnieuw toe voordat je [ILayoutSlide::Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/remove/) aanroept. Een poging om een gebruikte lay-out te verwijderen resulteert in een [PptxEditException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptxeditexception/).

## **Regel de zichtbaarheid van voetteksten op een lay‑out‑dia**

Een lay-out heeft zijn eigen voettekst‑, dia‑nummer‑ en datum‑tijd‑placeholders. Gebruik de [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/)‑methode om die placeholders voor één lay-out te beheren. Dit is handig wanneer bijvoorbeeld content‑lay-outs voetteksten moeten tonen, maar titel‑lay-outs niet.

Het volgende voorbeeld selecteert veilig een lay‑out en maakt de voettekstelementen zichtbaar:

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

## **Regel de zichtbaarheid van voetteksten op een master en diens onderliggende lay‑outs**

Om consistente voettekstinstellingen toe te passen over een master‑hiërarchie, gebruik je de [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/get_headerfootermanager/)‑methode. De verspreidingsmethoden van [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslideheaderfootermanager/) werken op de master en zijn afhankelijke lay‑out‑dia’s en normal slides; ze richten zich niet alleen op één normal slide.

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

**Wat is het verschil tussen een master‑slide en een layout‑slide?**

Een master‑slide definieert het thema van de presentatie en gedeelde opmaak. Een layout‑slide behoort tot een master en definieert één herbruikbare rangschikking van placeholders. Normal slides gebruiken die lay-outs en slaan dia‑specifieke inhoud op.

**Kan ik een layout‑slide van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de bestemmingscollectie met de [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igloballayoutslidecollection/addclone/)‑methode. Bij het kopiëren tussen presentaties moet je ook lettertypen, thema’s, afbeeldingen en andere bronnen die door de bron‑lay-out worden gebruikt verifiëren.

**Wat gebeurt er als ik een lay-out die al in gebruik is wijzig?**

Afhankelijke dia’s erven de lay-outwijzigingen tenzij ze de betreffende opmaak of objecten lokaal overschrijven. Placeholder‑geometrie en geërfde styling kunnen daardoor tegelijk op veel dia’s veranderen. Gebruik [GetDependingSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/getdependingslides/) om de getroffen dia’s te identificeren voordat je de lay-out bewerkt.

**Wat gebeurt er als ik een lay-out die nog in gebruik is verwijder?**

Aspose.Slides werpt een [PptxEditException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptxeditexception/). Wijs eerst de afhankelijke dia’s opnieuw toe, of gebruik [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) om alleen niet‑gerefereerde lay-outs te verwijderen.