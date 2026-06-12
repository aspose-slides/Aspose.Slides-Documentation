---
title: PPT en PPTX naar JPG converteren in .NET
linktitle: PowerPoint naar JPG
type: docs
weight: 60
url: /nl/net/convert-powerpoint-to-jpg/
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
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint (PPT, PPTX) dia's naar hoogwaardige JPG-afbeeldingen in C# met Aspose.Slides voor .NET, gebruikmakend van snelle, betrouwbare codevoorbeelden."
---
## **Introductie**

Het converteren van PowerPoint- en OpenDocument-presentaties naar JPG-afbeeldingen helpt bij het delen van dia's, het optimaliseren van de prestaties en het insluiten van inhoud in websites of toepassingen. Aspose.Slides voor .NET stelt u in staat PPTX-, PPT- en ODP-bestanden om te zetten naar JPEG-afbeeldingen van hoge kwaliteit. Deze gids legt verschillende methoden voor conversie uit.

Met deze functies is het eenvoudig om uw eigen presentatieweergave te implementeren en een miniatuur voor elke dia te maken. Dit kan nuttig zijn als u dia's wilt beschermen tegen kopiëren of de presentatie in alleen-lezen-modus wilt tonen. Aspose.Slides stelt u in staat de volledige presentatie of een specifieke dia om te zetten naar afbeeldingsformaten.

## **Presentatiedia’s converteren naar JPG-afbeeldingen**

Dit zijn de stappen om een PPT-, PPTX- of ODP-bestand naar JPG te converteren:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
2. Haal het dia‑object van het type [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide) op uit de collectie [Presentation.Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/properties/slides).  
3. Maak een afbeelding van de dia met behulp van de methode [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/#getimage_5).  
4. Roep de methode [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/save/#save_3) aan op het afbeeldingsobject. Geef de uitvoernaam en het afbeeldingsformaat als argumenten op.

{{% alert color="primary" %}} 
**Opmerking:** De conversie van PPT, PPTX of ODP naar JPG verschilt van de conversie naar andere formaten in de Aspose.Slides .NET-API. Voor andere formaten gebruikt u doorgaans de methode [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/save/#save_5). Voor JPG-conversie moet u echter de methode [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/save/#save_3) gebruiken. 
{{% /alert %}} 

```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Maak een dia-afbeelding met de opgegeven schaal.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Sla de afbeelding op schijf op in JPEG-formaat.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Dia’s omzetten naar JPG met aangepaste afmetingen**

Om de afmetingen van de resulterende JPG-afbeeldingen te wijzigen, kunt u de afbeeldingsgrootte instellen door deze door te geven aan de methode [ISlide.GetImage(Size)](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/#getimage_6). Hierdoor kunt u afbeeldingen genereren met specifieke breedte- en hoogtewaarden, zodat de output voldoet aan uw vereisten voor resolutie en beeldverhouding. Deze flexibiliteit is vooral nuttig bij het genereren van afbeeldingen voor webtoepassingen, rapporten of documentatie, waar precieze afbeeldingsafmetingen vereist zijn.

```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Maak een dia-afbeelding met de opgegeven grootte.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Sla de afbeelding op schijf op in JPEG-formaat.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Opmerkingen renderen bij het opslaan van dia’s als afbeeldingen**

Aspose.Slides voor .NET biedt een functie waarmee u opmerkingen op de dia's van een presentatie kunt renderen wanneer u ze omzet naar JPG-afbeeldingen. Deze functionaliteit is vooral nuttig om annotaties, feedback of discussies die door collega's aan PowerPoint-presentaties zijn toegevoegd te behouden. Door deze optie in te schakelen, zorgt u ervoor dat opmerkingen zichtbaar zijn in de gegenereerde afbeeldingen, waardoor het eenvoudiger wordt om feedback te beoordelen en te delen zonder het oorspronkelijke presentiebestand te openen.

Stel, we hebben een presentiebestand "sample.pptx" met een dia die opmerkingen bevat:

![De dia met opmerkingen](slide_with_comments.png)

De volgende C#‑code zet de dia om naar een JPG-afbeelding terwijl de opmerkingen behouden blijven:

```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Stel opties in voor de dia-opmerkingen.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // Converteer de eerste dia naar een afbeelding.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

Het resultaat:

![De JPG-afbeelding met opmerkingen](image_with_comments.png)

## **Zie ook**

- [PowerPoint converteren naar GIF](/slides/nl/net/convert-powerpoint-to-animated-gif/)  
- [PowerPoint converteren naar PNG](/slides/nl/net/convert-powerpoint-to-png/)  
- [PowerPoint converteren naar TIFF](/slides/nl/net/convert-powerpoint-to-tiff/)  
- [PowerPoint converteren naar SVG](/slides/nl/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Om te zien hoe Aspose.Slides PowerPoint naar JPG-afbeeldingen converteert, probeer deze gratis online converters: PowerPoint [PPTX naar JPG](https://products.aspose.app/slides/nl/conversion/pptx-to-jpg) en [PPT naar JPG](https://products.aspose.app/slides/nl/conversion/ppt-to-jpg). 

{{% /alert %}} 

![Gratis online PPTX-naar-JPG-converter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose biedt een [GRATIS Collage‑webapp](https://products.aspose.app/slides/nl/collage). Met deze online service kunt u [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG naar PNG-afbeeldingen samenvoegen, [foto‑rasters](https://products.aspose.app/slides/nl/collage/photo-grid) maken, enzovoort.

Met dezelfde principes die in dit artikel worden beschreven, kunt u afbeeldingen van het ene formaat naar het andere converteren. Voor meer informatie, zie deze pagina's: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/net/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/net/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/net/conversion/jpg-to-png/); converteer [PNG naar JPG](https://products.aspose.com/slides/nl/net/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/net/conversion/png-to-svg/); converteer [SVG naar PNG](https://products.aspose.com/slides/nl/net/conversion/svg-to-png/). 

{{% /alert %}}

## **Veelgestelde vragen**

**Ondersteunt deze methode batchconversie?**  
Ja, Aspose.Slides ondersteunt batchconversie van meerdere dia’s naar JPG in één enkele bewerking.

**Ondersteunt de conversie SmartArt, grafieken en andere complexe objecten?**  
Ja, Aspose.Slides rendert alle inhoud, inclusief SmartArt, grafieken, tabellen, vormen en meer. De weergave‑nauwkeurigheid kan echter enigszins variëren ten opzichte van PowerPoint, vooral wanneer er aangepaste of ontbrekende lettertypen worden gebruikt.

**Zijn er beperkingen aan het aantal dia’s dat verwerkt kan worden?**  
Aspose.Slides zelf stelt geen strikte limieten aan het aantal dia’s dat u kunt verwerken. Bij zeer grote presentaties of afbeeldingen met hoge resolutie kunt u echter een out‑of‑memory‑fout tegenkomen.