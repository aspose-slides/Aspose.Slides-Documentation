---
title: Converteer PPT en PPTX naar JPG in C++
linktitle: PowerPoint naar JPG
type: docs
weight: 60
url: /nl/cpp/convert-powerpoint-to-jpg/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar JPG
- presentatie naar JPG
- dia naar JPG
- PPT naar JPG
- PPTX naar JPG
- PowerPoint opslaan als JPG
- presentatie opslaan als JPG
- dia opslaan als JPG
- PPT opslaan als JPG
- PPTX opslaan als JPG
- PPT exporteren naar JPG
- PPTX exporteren naar JPG
- C++
- Aspose.Slides
description: "Converteer PowerPoint (PPT, PPTX) dia's naar hoogwaardige JPG-afbeeldingen in C++ met Aspose.Slides met snelle, betrouwbare code-voorbeelden."
---
## **Inleiding**

Het converteren van PowerPoint- en OpenDocument-presentaties naar JPG-afbeeldingen helpt bij het delen van dia's, het optimaliseren van de prestaties en het insluiten van inhoud in websites of applicaties. Aspose.Slides for C++ stelt u in staat om PPTX-, PPT- en ODP-bestanden om te zetten naar JPEG-afbeeldingen van hoge kwaliteit. Deze gids beschrijft verschillende methoden voor conversie.

Met deze functies is het eenvoudig om uw eigen presentatieweergave te implementeren en een miniatuurafbeelding voor elke dia te maken. Dit kan handig zijn als u dia's wilt beschermen tegen kopiëren of de presentatie wilt tonen in alleen‑lezen modus. Aspose.Slides maakt het mogelijk om de volledige presentatie of een specifieke dia om te zetten naar afbeeldingsformaten.

## **Presentatiedia's omzetten naar JPG‑afbeeldingen**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse aan.  
1. Haal het dia‑object van het type [ISlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/) op uit de dia‑collectie van de presentatie.  
1. Maak een afbeelding van de dia met de [ISlide.GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/) methode.  
1. Roep de [IImage.Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/save/) methode aan op het afbeeldingobject. Geef de bestandsnaam van de uitvoer en het afbeeldingformaat als argumenten door.

{{% alert color="info" %}} 
**Opmerking:** Conversie van PPT, PPTX of ODP naar JPG verschilt van conversie naar andere formaten in de Aspose.Slides for C++ API. Voor andere formaten gebruikt u doorgaans de [IPresentation.Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/save/) methode. Voor JPG‑conversie moet u echter de [IImage.Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/save/) methode gebruiken.  
{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Maak een dia-afbeelding van de opgegeven schaal.
    auto image = slide->GetImage(scaleX, scaleY);

    // Sla de afbeelding op schijf op in JPEG-formaat.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Dia's omzetten naar JPG met aangepaste afmetingen**

Om de afmetingen van de gegenereerde JPG‑afbeeldingen te wijzigen, kunt u de beeldgrootte instellen door deze door te geven aan de [ISlide.GetImage(Size)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) methode. Hiermee kunt u afbeeldingen maken met specifieke breedte‑ en hoogtewaarden, zodat de uitvoer voldoet aan uw eisen voor resolutie en beeldverhouding. Deze flexibiliteit is vooral nuttig bij het genereren van afbeeldingen voor webapplicaties, rapporten of documentatie, waar precieze afmetingen vereist zijn.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Maak een dia-afbeelding van de opgegeven grootte.
    auto image = slide->GetImage(imageSize);

    // Sla de afbeelding op schijf op in JPEG-formaat.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Reacties weergeven bij het opslaan van dia's als afbeeldingen**

Aspose.Slides for C++ biedt een functie die het mogelijk maakt om opmerkingen op de dia's van een presentatie weer te geven bij het converteren naar JPG‑afbeeldingen. Deze functionaliteit is vooral nuttig om annotaties, feedback of discussies van medewerken in PowerPoint‑presentaties te behouden. Door deze optie in te schakelen, worden opmerkingen zichtbaar in de gegenereerde afbeeldingen, waardoor het makkelijker is om feedback te beoordelen en te delen zonder het oorspronkelijke presentatie‑bestand te openen.

Stel dat we een presentatiebestand "sample.pptx" hebben met een dia die opmerkingen bevat:

![De dia met opmerkingen](slide_with_comments.png)

De volgende C++‑code converteert de dia naar een JPG‑afbeelding terwijl de opmerkingen behouden blijven:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Stel opties in voor de dia-opmerkingen.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Converteer de eerste dia naar een afbeelding.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Het resultaat:

![De JPG‑afbeelding met opmerkingen](image_with_comments.png)

## **Zie ook**

- [PowerPoint naar GIF converteren](/slides/nl/cpp/convert-powerpoint-to-animated-gif/)
- [PowerPoint naar PNG converteren](/slides/nl/cpp/convert-powerpoint-to-png/)
- [PowerPoint naar TIFF converteren](/slides/nl/cpp/convert-powerpoint-to-tiff/)
- [PowerPoint naar SVG converteren](/slides/nl/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
Om te zien hoe Aspose.Slides PowerPoint naar JPG‑afbeeldingen converteert, probeer deze gratis online converters: PowerPoint [PPTX naar JPG](https://products.aspose.app/slides/nl/conversion/pptx-to-jpg) en [PPT naar JPG](https://products.aspose.app/slides/nl/conversion/ppt-to-jpg). 
{{% /alert %}}

![Gratis online PPTX‑naar‑JPG converter](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose biedt een [GRATIS Collage‑webapp](https://products.aspose.app/slides/nl/collage). Met deze online service kunt u [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑naar‑PNG‑afbeeldingen samenvoegen, [fotogrijen](https://products.aspose.app/slides/nl/collage/photo-grid) creëren, enzovoort.

Met dezelfde principes die in dit artikel worden beschreven, kunt u afbeeldingen van het ene formaat naar het andere converteren. Voor meer informatie, zie deze pagina's: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-png/), converteer [PNG naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-svg/), converteer [SVG naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/svg-to-png/). 

{{% /alert %}}

## **FAQ**

### Ondersteunt deze methode batch‑conversie?

Ja, Aspose.Slides laat batch‑conversie van meerdere dia's naar JPG toe in één enkele bewerking.

### Ondersteunt de conversie SmartArt, grafieken en andere complexe objecten?

Ja, Aspose.Slides rendert alle inhoud, inclusief SmartArt, grafieken, tabellen, vormen en meer. De weergave‑nauwkeurigheid kan echter iets afwijken van PowerPoint, vooral bij het gebruik van aangepaste of ontbrekende lettertypen.

### Zijn er beperkingen op het aantal dia's dat verwerkt kan worden?

Aspose.Slides zelf legt geen strikte limieten op het aantal dia's dat u kunt verwerken. U kunt echter een out‑of‑memory‑fout tegenkomen bij het werken met grote presentaties of afbeeldingen met hoge resolutie.