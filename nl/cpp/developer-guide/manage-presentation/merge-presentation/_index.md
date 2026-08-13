---
title: Presentaties efficiënt samenvoegen in C++
linktitle: Presentaties samenvoegen
type: docs
weight: 40
url: /nl/cpp/merge-presentation/
keywords:
- PowerPoint samenvoegen
- presentaties samenvoegen
- dia's samenvoegen
- PPT samenvoegen
- PPTX samenvoegen
- ODP samenvoegen
- PowerPoint combineren
- presentaties combineren
- dia's combineren
- PPT combineren
- PPTX combineren
- ODP combineren
- C++
- Aspose.Slides
description: "Moeiteloos PowerPoint-presentaties (PPT, PPTX) en OpenDocument-presentaties (ODP) samenvoegen met Aspose.Slides voor C++, waardoor uw workflow wordt gestroomlijnd."
---
## **Overzicht**

Aspose.Slides stelt u in staat presentaties samen te voegen door dia's van de ene presentatie te klonen naar een andere. Dit artikel legt uit hoe u volledige presentaties of geselecteerde dia's kunt samenvoegen, een slide‑master of een specifieke lay‑out tijdens het samenvoegen kunt gebruiken, presentaties met verschillende diaformaten kunt behandelen, en samengevoegde dia's aan een sectie van een presentatie kunt toevoegen. Het behandelt ook praktische opmerkingen met betrekking tot samengevoegde inhoud, waaronder notities voor de spreker, opmerkingen, met wachtwoord beveiligde bronbestanden en thread‑gebruik.

## **Presentatie samenvoegen**

Wanneer u één presentatie met een andere samenvoegt, combineert u in feite hun dia's in één enkele presentatie om één bestand te verkrijgen.

{{% alert title="Info" color="info" %}}
De meeste presentatiesoftware (PowerPoint of OpenOffice) mist functies waarmee gebruikers presentaties op deze manier kunnen combineren.
{{% /alert %}}

[**Aspose.Slides for C++**](https://products.aspose.com/slides/nl/cpp/), maakt echter wel mogelijk om presentaties op verschillende manieren samen te voegen. U kunt presentaties samenvoegen met al hun vormen, stijlen, teksten, opmaak, opmerkingen, animaties, enz., zonder zich zorgen te hoeven maken over verlies van kwaliteit of gegevens.

**See also**

[Clone Slides](https://docs.aspose.com/slides/nl/cpp/clone-slides/)*.*

### **Wat kan worden samengevoegd**

Met Aspose.Slides kunt u

* volledige presentaties. Alle dia's van de presentaties komen in één presentatie terecht
* specifieke dia's. Geselecteerde dia's komen in één presentatie terecht
* presentaties in één formaat (PPT naar PPT, PPTX naar PPTX, enz.) en in verschillende formaten (PPT naar PPTX, PPTX naar ODP, enz.) naar elkaar.

{{% alert title="Note" color="warning" %}} 
Naast presentaties maakt Aspose.Slides het mogelijk om andere bestanden samen te voegen:

* [Images](https://products.aspose.com/slides/nl/cpp/merger/image-to-image/), zoals [JPG to JPG](https://products.aspose.com/slides/nl/cpp/merger/jpg-to-jpg/) of [PNG to PNG](https://products.aspose.com/slides/nl/cpp/merger/png-to-png/)
* Documents, zoals [PDF to PDF](https://products.aspose.com/slides/nl/cpp/merger/pdf-to-pdf/) of [HTML to HTML](https://products.aspose.com/slides/nl/cpp/merger/html-to-html/)
* En twee verschillende bestanden, zoals [image to PDF](https://products.aspose.com/slides/nl/cpp/merger/image-to-pdf/) of [JPG to PDF](https://products.aspose.com/slides/nl/cpp/merger/jpg-to-pdf/) of [TIFF to PDF](https://products.aspose.com/slides/nl/cpp/merger/tiff-to-pdf/).
{{% /alert %}}

### **Samenvoegopties**

U kunt opties toepassen die bepalen of

* elke dia in de uitvoerpresentatie een unieke stijl behoudt
* een specifieke stijl wordt gebruikt voor alle dia's in de uitvoerpresentatie. 

Om presentaties samen te voegen, biedt Aspose.Slides [AddClone](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) methoden (van de [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_slide_collection) interface). Er zijn verschillende implementaties van de `AddClone`‑methoden die de parameters voor het samenvoegen van presentaties definiëren. Elk Presentation‑object heeft een [Slides](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) collectie, zodat u een `AddClone`‑methode kunt aanroepen vanaf de presentatie waarin u dia's wilt samenvoegen. 

De `AddClone`‑methode retourneert een `ISlide`‑object, een kloon van de bron‑dia. De dia's in de uitvoerpresentatie zijn eenvoudigweg een kopie van de dia's uit de bron. Daarom kunt u de resulterende dia's aanpassen (bijvoorbeeld stijlen, opmaakopties of lay‑outs toepassen) zonder je zorgen te maken dat de bronpresentaties worden beïnvloed. 

## **Presentaties samenvoegen** 

Aspose.Slides biedt de [**AddClone (ISlide)**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) methode die u in staat stelt dia's te combineren terwijl de dia's hun lay‑out en stijl behouden (standaardparameters). 

Deze C++‑code toont hoe u presentaties kunt samenvoegen:

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

## **Presentaties samenvoegen met een dia‑master**

Aspose.Slides biedt de [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) methode die u in staat stelt dia's te combineren terwijl een slide‑master‑sjabloon wordt toegepast. Op deze manier kunt u, indien nodig, de stijl voor de dia's in de uitvoerpresentatie wijzigen. 

Deze C++‑code demonstreert de beschreven bewerking:

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

{{% alert title="Note" color="warning" %}} 
De dia‑lay‑out voor de slide‑master wordt automatisch bepaald. Wanneer een passende lay‑out niet kan worden bepaald, wordt de lay‑out van de bron‑dia gebruikt als de `allowCloneMissingLayout`‑boolean‑parameter van de `AddClone`‑methode op true staat. Anders wordt een [PptxEditException](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) opgegooid. 
{{% /alert %}}

Als u wilt dat de dia's in de uitvoerpresentatie een andere dia‑lay‑out hebben, gebruik dan de [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) methode in plaats van `AddClone` bij het samenvoegen. 

## **Specifieke dia's uit presentaties samenvoegen**

Het samenvoegen van specifieke dia's uit meerdere presentaties is handig voor het creëren van aangepaste slide‑decks. Aspose.Slides C++ maakt het mogelijk alleen de dia's te selecteren en te importeren die u nodig heeft. De API behoudt de opmaak, lay‑out en het ontwerp van de originele dia's.

De volgende C++‑code maakt een nieuwe presentatie, voegt titel‑dia's toe van twee andere presentaties, en slaat het resultaat op in een bestand:

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

// Verklaard in de code hierboven.
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

## **Presentaties samenvoegen met een dia‑lay‑out**

Deze C++‑code toont hoe u dia's uit presentaties kunt combineren terwijl u uw voorkeurs‑dia‑lay‑out toepast om één uitvoerpresentatie te krijgen:

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

## **Presentaties samenvoegen met verschillende diaformaten**

{{% alert title="Note" color="warning" %}} 
U kunt geen presentaties met verschillende diaformaten samenvoegen. 
{{% /alert %}}

Om twee presentaties met verschillende diaformaten samen te voegen, moet u één van de presentaties schalen zodat de grootte overeenkomt met die van de andere presentatie. 

Deze voorbeeldcode demonstreert de beschreven bewerking:

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

## **Dia's samenvoegen naar een presentatiesectie**

Deze C++‑code toont hoe u een specifieke dia kunt samenvoegen naar een sectie in een presentatie:

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

De dia wordt aan het einde van de sectie toegevoegd. 

{{% alert title="Tip" color="info" %}}
Aspose biedt een [FREE Collage web app](https://products.aspose.app/slides/nl/collage). Met deze online service kunt u [JPG to JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑naar‑PNG‑afbeeldingen samengevoegen, foto‑rasters ([photo grids](https://products.aspose.app/slides/nl/collage/photo-grid)) maken, enzovoort. 
{{% /alert %}}

## **FAQ**

### Worden notities voor de spreker bewaard tijdens het samenvoegen?

Ja. Bij het klonen van dia's neemt Aspose.Slides alle diacomponenten over, inclusief notities, opmaak en animaties.

### Worden opmerkingen en hun auteurs overgedragen?

Opmerkingen, als onderdeel van de dia‑inhoud, worden met de dia gekopieerd. Auteur‑labels van opmerkingen blijven behouden als opmerking‑objecten in de resulterende presentatie.

### Wat als de bronpresentatie met een wachtwoord beveiligd is?

Deze moet worden [geopend met het wachtwoord](/slides/nl/cpp/password-protected-presentation/) via [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/); na het laden kunnen die dia's veilig worden gekloond naar een onbeveiligd doelbestand (of ook naar een beveiligd bestand).

### Hoe thread‑safe is de samenvoegbewerking?

Gebruik dezelfde [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) instantie niet vanuit [meerdere threads](/slides/nl/cpp/multithreading/). De aanbevolen regel is “één document — één thread”; verschillende bestanden kunnen parallel in aparte threads worden verwerkt.