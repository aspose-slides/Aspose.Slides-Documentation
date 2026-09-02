---
title: Dia lay-outs toepassen of wijzigen in C++
linktitle: Dia lay-out
type: docs
weight: 60
url: /nl/cpp/slide-layout/
keywords:
- dia lay-out
- inhoud lay-out
- plaatsaanduiding
- presentatieontwerp
- diadesign
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
description: "Dia lay-outs toepassen, maken en wijzigen in Aspose.Slides voor C++, plaatsaanduidingen toevoegen, ongebruikte lay-outs verwijderen en de voettekst-zichtbaarheid regelen."
---
## **Overzicht**

Een dia‑lay‑out definieert de posities en opmaak van tijdelijke aanduidingen zoals titels, tekst, afbeeldingen, diagrammen en tabellen. Het toepassen van een lay‑out geeft dia’s een consistente structuur, terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende lay‑outs zijn:

- **Titel-dia**: Bevat titel‑ en subtitel‑plaatsaanduidingen.
- **Titel en inhoud**: Bevat een titel‑plaatsaanduiding en een algemene inhouds‑plaatsaanduiding.
- **Leeg**: Bevat geen inhouds‑plaatsaanduidingen en is nuttig wanneer elke vorm handmatig wordt gepositioneerd.

## **Begrijp lay‑out‑overerving**

Een presentatie heeft drie verwante niveaus:

1. Een [master‑dia](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/) definieert het thema, de gedeelde opmaak, achtergronden en gemeenschappelijke objecten.
2. Een [lay‑out‑dia](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/) behoort tot een master en definieert een specifieke rangschikking van plaatsaanduidingen.
3. Een [normale dia](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/) gebruikt één lay‑out en slaat de ingevoerde inhoud voor die dia op.

Een normale dia erft thema en opmaak van zijn lay‑out, en de lay‑out erft van de master. Een waarde die rechtstreeks op een normale dia wordt ingesteld, overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt aangemaakt, worden de plaatsaanduidings‑vormen gegenereerd uit de gekozen lay‑out, terwijl de ingevoerde inhoud in die plaatsaanduidingen tot de normale dia behoort.

Voeg de benodigde plaatsaanduidingen toe aan een lay‑out voordat je er dia's op baseert. Een later toegevoegde plaatsaanduiding aan een lay‑out voegt niet automatisch een overeenkomstige plaatsaanduidings‑vorm toe aan bestaande normale dia's.

Deze relatie heeft twee belangrijke consequenties:

- Het wijzigen van geërfde opmaak of bestaande plaatsaanduidings‑geometrie op een lay‑out kan elke afhankelijke dia updaten. Controleer vóór het bewerken van een al in gebruik zijnde lay‑out eerst de afhankelijke dia's en beoordeel de resulterende presentatie.
- Een lay‑out die nog door een dia wordt gebruikt, kan niet worden verwijderd. Wijs eerst de afhankelijke dia's opnieuw toe aan een andere lay‑out, of verwijder alleen ongebruikte lay‑outs.

Voor meer informatie over het bovenste niveau van deze hiërarchie, zie [Slide Master](/slides/nl/cpp/slide-master/).

## **Selecteer en pas een dia‑lay‑out toe**

Gebruik een lay‑outtype wanneer de presentatie de standaard PowerPoint‑lay‑outdefinities volgt. Lay‑outnamen zijn door de gebruiker bewerkbaar en kunnen worden gelokaliseerd, waardoor selectie op basis van naam minder betrouwbaar is tenzij je de bron‑template beheert.

Het volgende voorbeeld zoekt naar **Titel en inhoud** op de eerste master. Als die lay‑out niet beschikbaar is, valt het expres terug op **Leeg**. De tweede null‑controle is nodig omdat een presentatie alleen aangepaste lay‑outs kan bevatten. De geselecteerde lay‑out wordt vervolgens toegepast op de eerste normale dia via de [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/set_layoutslide/)‑methode.

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

Het wijzigen van de lay‑out van een dia verwijdert niet de gewone vormen die rechtstreeks aan de dia zijn toegevoegd. Plaatsaanduidingsposities, geërfde opmaak en de overeenkomst tussen bestaande plaatsaanduidingen en de nieuwe lay‑out kunnen echter veranderen, dus controleer de output bij het schakelen tussen wezenlijk verschillende lay‑outs.

## **Een lay‑out‑dia toevoegen**

Selectie en creatie zijn afzonderlijke handelingen. Het vorige voorbeeld selecteert een bestaande lay‑out; het maakt er geen nieuwe aan. Om een lay‑out te creëren, roep je de [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterlayoutslidecollection/add/)‑methode aan op de lay‑outcollectie van de doel‑master.

Het volgende voorbeeld voegt altijd een nieuwe **Titel en inhoud**‑lay‑out toe met de naam `Report Title and Content`, en voegt vervolgens een normale dia toe die daarop gebaseerd is. Lay‑outnamen moeten binnen de collectie uniek zijn.

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

Voeg alleen een lay‑out toe wanneer de template echt een extra herbruikbare structuur nodig heeft. Als er al een geschikte lay‑out bestaat, selecteer en hergebruik die in plaats van een duplicaat te maken.

## **Plaatsaanduidingen toevoegen aan een lay‑out‑dia**

De [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/)‑methode levert een [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/) voor het toevoegen van plaatsaanduidings‑vormen aan een lay‑out.

| PowerPoint‑plaatsaanduiding       | `ILayoutPlaceholderManager` Method |
| --------------------------------- | ---------------------------------- |
| ![Content](content.png)           | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                 | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png)     | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png)           | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png)               | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png)               | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)         | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)               | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png)  | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Het volgende voorbeeld controleert of de **Leeg**‑lay‑out bestaat, voegt er vier plaatsaanduidingen aan toe, en maakt vervolgens een normale dia die de gewijzigde lay‑out gebruikt. De volgorde is bewust gekozen: de plaatsaanduidingen worden toegevoegd voordat de normale dia wordt aangemaakt, zodat Aspose.Slides de overeenkomstige plaatsaanduidings‑vormen op die dia kan genereren.

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

![De plaatsaanduidingen op de lay‑out‑dia](add_placeholders.png)

{{% alert color="warning" title="Waarschuwing" %}}
Het wijzigen van geërfde opmaak of de geometrie van bestaande lay‑out‑plaatsaanduidingen kan invloed hebben op afhankelijke dia's. Een nieuw toegevoegde lay‑out‑plaatsaanduiding wordt niet automatisch achteraf toegevoegd aan bestaande normale dia's. Test lay‑out‑wijzigingen op een kopie van de presentatie en controleer elke afhankelijke dia.
{{% /alert %}}

## **Ongebruikte lay‑out‑dia's verwijderen**

Gebruik de [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)‑methode om lay‑outs te verwijderen waar geen normale dia naar verwijst. De methode laat lay‑outs die nog in gebruik zijn ongewijzigd.

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

Om één specifieke lay‑out te verwijderen, gebruik eerst de [get_HasDependingSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/)‑methode of de [GetDependingSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/getdependingslides/)‑methode. Wijs eventuele afhankelijke dia's opnieuw toe voordat je [ILayoutSlide::Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/remove/) aanroept. Een poging om een gebruikte lay‑out te verwijderen resulteert in een [PptxEditException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptxeditexception/).

## **Voettekst‑zichtbaarheid op een lay‑out‑dia regelen**

Een lay‑out heeft zijn eigen voettekst‑, dia‑nummer‑ en datum‑tijd‑plaatsaanduidingen. Gebruik de [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/)‑methode om die plaatsaanduidingen voor één lay‑out te beheren. Dit is handig wanneer bijvoorbeeld inhoud‑lay‑outs wel voetteksten moeten tonen, maar titel‑lay‑outs niet.

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

## **Voettekst‑zichtbaarheid op een master en diens onderliggende lay‑outs regelen**

Om consistente voettekstinstellingen toe te passen over een master‑hiërarchie, gebruik je de [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/get_headerfootermanager/)‑methode. De propagatiemethoden van [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslideheaderfootermanager/) werken op de master en zijn afhankelijke lay‑out‑dia's en normale dia's; ze richten zich niet alleen op één enkele normale dia.

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

**Wat is het verschil tussen een master‑dia en een lay‑out‑dia?**

Een master‑dia definieert het thema van de presentatie en de gedeelde opmaak. Een lay‑out‑dia behoort tot een master en definieert één herbruikbare rangschikking van plaatsaanduidingen. Normale dia's gebruiken die lay‑outs en slaan dia‑specifieke inhoud op.

**Kan ik een lay‑out‑dia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de doel‑collectie met de [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igloballayoutslidecollection/addclone/)‑methode. Bij het kopiëren tussen presentaties controleer je ook fonts, thema's, afbeeldingen en andere bronnen die door de bron‑lay‑out worden gebruikt.

**Wat gebeurt er als ik een lay‑out wijzig die al in gebruik is?**

Afhankelijke dia's erven de lay‑out‑wijzigingen tenzij ze de getroffen opmaak of objecten lokaal overschrijven. De geometrie van plaatsaanduidingen en geërfde styling kunnen daardoor in één keer op veel dia's veranderen. Gebruik [GetDependingSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/getdependingslides/) om de betrokken dia's te identificeren vóór het bewerken van de lay‑out.

**Wat gebeurt er als ik een lay‑out verwijder die nog in gebruik is?**

Aspose.Slides gooit een [PptxEditException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptxeditexception/). Wijs eerst de afhankelijke dia's opnieuw toe, of gebruik [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) om alleen niet‑gerefereerde lay‑outs te verwijderen.