---
title: Beheer OLE-objecten in presentaties in .NET
linktitle: Beheer OLE
type: docs
weight: 40
url: /nl/net/manage-ole/
keywords:
- OLE-object
- Objectkoppeling & insluiting
- OLE toevoegen
- OLE insluiten
- object toevoegen
- object insluiten
- bestand toevoegen
- bestand insluiten
- gelinkt object
- gelinkt bestand
- OLE wijzigen
- OLE-pictogram
- OLE-titel
- OLE extraheren
- object extraheren
- bestand extraheren
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor .NET. Voeg OLE-inhoud in, werk bij en exporteer naadloos."
---
## **Inleiding**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt data en objecten die in één applicatie zijn gemaakt, in een andere applicatie te plaatsen via koppeling of insluiting. 

{{% /alert %}} 

Beschouw een grafiek die is gemaakt in MS Excel. De grafiek wordt vervolgens in een PowerPoint‑dia geplaatst. Die Excel‑grafiek wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan verschijnen als een pictogram. In dat geval wordt, wanneer u dubbelklikt op het pictogram, de grafiek geopend in de bijbehorende applicatie (Excel), of wordt u gevraagd een applicatie te selecteren voor het openen of bewerken van het object. 
- Een OLE‑object kan zijn feitelijke inhoud weergeven, zoals de inhoud van een grafiek. In dat geval wordt de grafiek geactiveerd in PowerPoint, laadt de grafiekomgeving en kunt u de gegevens van de grafiek binnen PowerPoint aanpassen.

[Aspose.Slides for .NET](https://products.aspose.com/slides/nl/net/) stelt u in staat OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe)).

## **OLE‑objectframes toevoegen aan dia's**

Stel dat u al een grafiek in Microsoft Excel hebt gemaakt en deze wilt insluiten in een dia als OLE‑objectframe met Aspose.Slides for .NET, dan gaat u als volgt te werk:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
2. Haal de referentie van een dia op via zijn index.  
3. Lees het Excel‑bestand in als een byte‑array.  
4. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe) toe aan de dia met de byte‑array en aanvullende informatie over het OLE‑object.  
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.  

In het onderstaande voorbeeld hebben we een grafiek uit een Excel‑bestand aan een dia toegevoegd als een [OleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe) met Aspose.Slides for .NET.  
**Opmerking** dat de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/net/aspose.slides.dom.ole/oleembeddeddatainfo/)‑constructor een extensie van het in te sluiten object als tweede parameter neemt. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste applicatie te kiezen om dit OLE‑object te openen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Bereid de gegevens voor het OLE-object voor.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Voeg het OLE-objectframe toe aan de dia.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Gelinkte OLE‑objectframes toevoegen**

Aspose.Slides for .NET stelt u in staat een [OleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe) toe te voegen zonder data in te sluiten, maar alleen met een koppeling naar het bestand.

Deze C#‑code laat zien hoe u een [OleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe) met een gelinkte Excel‑file aan een dia kunt toevoegen:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Voeg een OLE-objectframe toe met een gekoppeld Excel-bestand.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE‑objectframes benaderen**

Als een OLE‑object al is ingesloten in een dia, kunt u het eenvoudig vinden of benaderen als volgt:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse te maken.  
2. Haal de referentie van de dia op via zijn index.  
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe)‑vorm.  
   In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die slechts één vorm bevat op de eerste dia. Vervolgens *casten* we dat object naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleobjectframe). Dit was het gewenste OLE‑objectframe om te benaderen.  
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑grafiekobject ingesloten in een dia) en de onderliggende bestandsdata benaderd.

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Haal de eerste vorm op als een OLE-objectframe.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Haal de gegevens van het ingesloten bestand op.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Haal de extensie van het ingesloten bestand op.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Eigenschappen van gelinkte OLE‑objectframes benaderen**

Aspose.Slides stelt u in staat de eigenschappen van gelinkte OLE‑objectframes te benaderen.

Deze C#‑code laat zien hoe u kunt controleren of een OLE‑object gelinkt is en vervolgens het pad naar het gelinkte bestand verkrijgt:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Haal de eerste vorm op als een OLE-objectframe.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Controleer of het OLE-object gelinkt is.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Geef het volledige pad naar het gekoppelde bestand weer.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Geef het relatieve pad naar het gekoppelde bestand weer indien aanwezig.
        // Alleen PPT-presentaties kunnen het relatieve pad bevatten.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE‑objectgegevens wijzigen**

{{% alert color="info" %}} 

In dit gedeelte maakt het code‑voorbeeld hieronder gebruik van [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Als een OLE‑object al is ingesloten in een dia, kunt u dat object eenvoudig benaderen en de gegevens wijzigen als volgt:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse te maken.  
2. Haal de referentie van de dia op via zijn index.  
3. Benader de [OLEObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe)‑vorm.  
   In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die één vorm bevat op de eerste dia. Vervolgens *casten* we dat object naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleobjectframe). Dit was het gewenste OLE‑objectframe om te benaderen.  
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.  
5. Maak een `Workbook`‑object aan en benader de OLE‑data.  
6. Benader het gewenste `Worksheet` en wijzig de gegevens.  
7. Sla het bijgewerkte `Workbook` op in een stream.  
8. Vervang de OLE‑objectdata door de data uit de stream.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑grafiekobject ingesloten in een dia) benaderd, en wordt de onderliggende bestandsdata aangepast om de grafiekgegevens bij te werken.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Haal de eerste vorm op als een OLE-objectframe.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Lees de OLE-objectdata als een Workbook-object.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Wijzig de workbook-gegevens.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Wijzig de OLE-frame objectdata.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Andere bestandstypen insluiten in dia's**

Naast Excel‑grafieken maakt Aspose.Slides for .NET het mogelijk andere soorten bestanden in dia's in te sluiten. Zo kunt u HTML‑, PDF‑ en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt dit automatisch geopend in het bijbehorende programma, of krijgt de gebruiker de optie om een passend programma te selecteren.

Deze C#‑code laat zien hoe u HTML en ZIP in een dia kunt insluiten:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Bestandstypen voor ingesloten objecten instellen**

Bij het werken met presentaties kan het nodig zijn oude OLE‑objecten te vervangen door nieuwe, of een niet‑ondersteund OLE‑object te vervangen door een ondersteund exemplaar. Aspose.Slides for .NET stelt u in staat het bestandstype voor een ingesloten object in te stellen, waardoor u de OLE‑frame‑data of de extensie kunt bijwerken.

Deze C#‑code laat zien hoe u het bestandstype voor een ingesloten OLE‑object instelt op `zip`:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Wijzig het bestandstype naar ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Pictogramafbeeldingen en titels voor ingesloten objecten instellen**

Na het insluiten van een OLE‑object wordt er automatisch een voorbeeld‑pictogram afbeelding toegevoegd. Dit voorbeeld is wat gebruikers zien voordat zij het OLE‑object openen of benaderen. Als u een specifieke afbeelding en tekst wilt gebruiken in het voorbeeld, kunt u de pictogramafbeelding en titel instellen via Aspose.Slides for .NET.

Deze C#‑code laat zien hoe u de pictogramafbeelding en titel voor een ingesloten object instelt: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Voeg een afbeelding toe aan de presentatieresources.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Stel een titel en de afbeelding in voor de OLE-preview.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Voorkomen dat een OLE‑objectframe wordt vergroot/verplaatst**

Nadat u een gelinkt OLE‑object aan een presentatie‑dia hebt toegevoegd, kan PowerPoint bij het openen van de presentatie een bericht tonen waarin wordt gevraagd de koppelingen bij te werken. Door op de knop “Update Links” te klikken, kan de grootte en positie van het OLE‑objectframe wijzigen, omdat PowerPoint de gegevens van het gelinkte OLE‑object ververst en het voorbeeld bijwerkt. Om te voorkomen dat PowerPoint vraagt de objectdata bij te werken, stelt u de `UpdateAutomatic`‑eigenschap van de [IOleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleobjectframe/)‑interface in op `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Bewaar de grootte en positie van het OLE-objectframe wanneer PowerPoint de koppeling bijwerkt.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ingesloten bestanden extraheren**

Aspose.Slides for .NET maakt het mogelijk de in dia's ingesloten bestanden als OLE‑objecten te extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse die de OLE‑objecten bevat die u wilt extraheren.  
2. Loop door alle vormen in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe)‑vormen.  
3. Haal de data van de ingesloten bestanden op uit de OLE‑objectframes en schrijf deze naar schijf.  

Deze C#‑code laat zien hoe u bestanden die in een dia als OLE‑objecten zijn ingesloten, kunt extraheren:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **FAQ**

### Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?

Wat zichtbaar is op de dia wordt gerenderd — het pictogram/alternatieve afbeelding (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig, stel een eigen preview‑afbeelding in om het verwachte uiterlijk in de geëxporteerde PDF te waarborgen.

### Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?

Vergrendel de vorm: Aspose.Slides biedt [vergrendelingen op vormniveau](/slides/nl/net/applying-protection-to-presentation/). Dit is geen encryptie, maar voorkomt effectief onbedoelde bewerkingen en verplaatsingen.

### Waarom “springt” een gelinkte Excel‑object of verandert van grootte wanneer ik de presentatie open?

PowerPoint kan de preview van het gelinkte OLE‑object verversen. Voor een stabiel uiterlijk volgt u de richtlijnen van de [Working Solution for Worksheet Resizing](/slides/nl/net/working-solution-for-worksheet-resizing/) — pas het frame aan op het bereik, of schaalt u het bereik naar een vast frame en stelt u een passende vervangende afbeelding in.

### Worden relatieve paden voor gelinkte OLE‑objecten bewaard in het PPTX‑formaat?

In PPTX is informatie over “relatief pad” niet beschikbaar — alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid geeft u de voorkeur aan betrouwbare absolute paden/toegankelijke URI’s of aan insluiting.