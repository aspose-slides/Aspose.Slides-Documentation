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
description: "Converteer PowerPoint (PPT, PPTX) dia's naar hoogwaardige JPG-afbeeldingen in C++ met Aspose.Slides met behulp van snelle, betrouwbare code‑voorbeelden."
---
## **Inleiding**

Het converteren van PowerPoint- en OpenDocument-presentaties naar JPG-afbeeldingen helpt bij het delen van dia's, het optimaliseren van de prestaties en het insluiten van inhoud in websites of applicaties. Aspose.Slides voor C++ stelt u in staat om PPTX-, PPT- en ODP-bestanden om te zetten naar JPEG-afbeeldingen van hoge kwaliteit. Deze gids legt verschillende methoden voor conversie uit.

Met deze functies is het eenvoudig om uw eigen presentatieweergave te implementeren en een miniatuur voor elke dia te maken. Dit kan nuttig zijn als u dia's wilt beschermen tegen kopiëren of de presentatie in alleen‑lezen modus wilt tonen. Aspose.Slides stelt u in staat om de gehele presentatie of een specifieke dia te converteren naar afbeeldingsformaten.

## **Presentatiedia's Converteren naar JPG-afbeeldingen**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse aan.
1. Haal het dia-object van het type [ISlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/)-type op uit de dia-collectie van de presentatie.
1. Maak een afbeelding van de dia met de [ISlide.GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/)-methode.
1. Roep de [IImage.Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/save/)-methode aan op het afbeeldingobject. Geef de uitvoerbestandsnaam en het afbeeldingsformaat als argumenten door.

{{% alert color="primary" %}} 
**Opmerking:** PPT-, PPTX- of ODP-naar-JPG-conversie verschilt van conversie naar andere formaten in de Aspose.Slides voor C++‑API. Voor andere formaten gebruikt u doorgaans de [IPresentation.Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/save/)-methode. Voor JPG‑conversie moet u echter de [IImage.Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/save/)-methode gebruiken.
{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Maak een dia-afbeelding met de opgegeven schaal.
    auto image = slide->GetImage(scaleX, scaleY);

    // Sla de afbeelding op schijf op in JPEG-formaat.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Dia's Converteren naar JPG met Aangepaste Afmetingen**

Om de afmetingen van de resulterende JPG‑afbeeldingen te wijzigen, kunt u de afbeeldingsgrootte instellen door deze door te geven aan de [ISlide.GetImage(Size)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method)-methode. Hiermee kunt u afbeeldingen genereren met specifieke breedte‑ en hoogte‑waarden, zodat de output voldoet aan uw eisen voor resolutie en beeldverhouding. Deze flexibiliteit is vooral handig bij het genereren van afbeeldingen voor webapplicaties, rapporten of documentatie, waar precieze afmetingen vereist zijn.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Maak een dia-afbeelding met de opgegeven grootte.
    auto image = slide->GetImage(imageSize);

    // Sla de afbeelding op schijf op in JPEG-formaat.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Opmerkingen Renderen bij Het Opslaan van Dia's als Afbeeldingen**

Aspose.Slides voor C++ biedt een functie waarmee u opmerkingen op de dia's van een presentatie kunt renderen bij het converteren naar JPG‑afbeeldingen. Deze functionaliteit is vooral nuttig om annotaties, feedback of discussies die door samenwerkers in PowerPoint‑presentaties zijn toegevoegd te behouden. Door deze optie in te schakelen, zijn opmerkingen zichtbaar in de gegenereerde afbeeldingen, waardoor het eenvoudiger wordt om feedback te beoordelen en te delen zonder het oorspronkelijke presentatiebestand te hoeven openen.

Stel dat we een presentatiebestand, "sample.pptx", hebben met een dia die opmerkingen bevat:

![De dia met opmerkingen](slide_with_comments.png)

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Stel opties in voor de opmerkingen van de dia.
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

![De JPG-afbeelding met opmerkingen](image_with_comments.png)

## **Zie Ook**

- [PowerPoint converteren naar GIF](/slides/nl/cpp/convert-powerpoint-to-animated-gif/)
- [PowerPoint converteren naar PNG](/slides/nl/cpp/convert-powerpoint-to-png/)
- [PowerPoint converteren naar TIFF](/slides/nl/cpp/convert-powerpoint-to-tiff/)
- [PowerPoint converteren naar SVG](/slides/nl/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Om te zien hoe Aspose.Slides PowerPoint naar JPG-afbeeldingen converteert, probeer deze gratis online converters: PowerPoint [PPTX naar JPG](https://products.aspose.app/slides/nl/conversion/pptx-to-jpg) en [PPT naar JPG](https://products.aspose.app/slides/nl/conversion/ppt-to-jpg). 
{{% /alert %}}

![Gratis online PPTX naar JPG-converter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose biedt een [GRATIS Collage-webapp](https://products.aspose.app/slides/nl/collage). Met deze online service kunt u [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG naar PNG-afbeeldingen samenvoegen, [fotogriezen](https://products.aspose.app/slides/nl/collage/photo-grid) maken, enzovoort. 

Met behulp van dezelfde principes die in dit artikel worden beschreven, kunt u afbeeldingen van het ene formaat naar het andere converteren. Voor meer informatie, zie deze pagina's: converteren [afbeelding naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/image-to-jpg/); converteren [JPG naar afbeelding](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-image/); converteren [JPG naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-png/), converteren [PNG naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-jpg/); converteren [PNG naar SVG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-svg/), converteren [SVG naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Ondersteunt deze methode batchconversie?**

Ja, Aspose.Slides ondersteunt batchconversie van meerdere dia's naar JPG in één bewerking.

**Ondersteunt de conversie SmartArt, diagrammen en andere complexe objecten?**

Ja, Aspose.Slides rendert alle inhoud, inclusief SmartArt, diagrammen, tabellen, vormen en meer. De rendervoorstelling kan echter iets afwijken van PowerPoint, vooral bij het gebruik van aangepaste of ontbrekende lettertypen.

**Zijn er beperkingen aan het aantal dia's dat verwerkt kan worden?**

Aspose.Slides zelf legt geen strikte limieten op aan het aantal dia's dat u kunt verwerken. Echter, u kunt een out-of-memory‑fout tegenkomen bij grote presentaties of afbeeldingen met hoge resolutie.