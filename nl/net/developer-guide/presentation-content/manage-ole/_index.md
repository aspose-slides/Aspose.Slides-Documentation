---
title: Beheer OLE-objecten in presentaties in .NET
linktitle: Beheer OLE
type: docs
weight: 40
url: /nl/net/manage-ole/
keywords:
- OLE-object
- "Object Koppelen & Insluiten"
- "OLE toevoegen"
- "OLE insluiten"
- "object toevoegen"
- "object insluiten"
- "bestand toevoegen"
- "bestand insluiten"
- "gelinkt object"
- "gelinkt bestand"
- "OLE wijzigen"
- "OLE-pictogram"
- "OLE-titel"
- "OLE extraheren"
- "object extraheren"
- "bestand extraheren"
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides for .NET. Voeg OLE-inhoud in, werk deze bij en exporteer deze moeiteloos."
---
## **Inleiding**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één applicatie zijn gemaakt, via koppeling of insluiting in een andere applicatie te plaatsen. 

{{% /alert %}} 

Stel je een diagram voor dat is gemaakt in MS Excel. Het diagram wordt vervolgens geplaatst in een PowerPoint‑dia. Dat Excel‑diagram wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan als een pictogram verschijnen. In dat geval wordt, wanneer je dubbelklikt op het pictogram, het diagram geopend in de bijbehorende applicatie (Excel), of wordt je gevraagd een applicatie te selecteren voor het openen of bewerken van het object. 
- Een OLE‑object kan de werkelijke inhoud weergeven, zoals de inhoud van een diagram. In dat geval wordt het diagram geactiveerd in PowerPoint, laadt de diagram‑interface, en kun je de gegevens van het diagram bewerken binnen PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/nl/net/) stelt je in staat OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe)).

## **OLE‑objectframes aan dia's toevoegen**

Aangenomen dat je al een diagram in Microsoft Excel hebt gemaakt en het wilt insluiten in een dia als een OLE‑objectframe met Aspose.Slides for .NET, kun je dit op de volgende manier doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Lees het Excel‑bestand in als een byte‑array.  
4. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.  
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.  

In het onderstaande voorbeeld hebben we een diagram uit een Excel‑bestand aan een dia toegevoegd als een [OleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe) met Aspose.Slides for .NET. **Opmerking** dat de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/net/aspose.slides.dom.ole/oleembeddeddatainfo/) constructor een extensie van het in te sluiten object als tweede parameter accepteert. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste applicatie te kiezen om dit OLE‑object te openen.

```csharp 
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

### **Gekoppelde OLE‑objectframes toevoegen**

Aspose.Slides for .NET maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe) toe te voegen zonder data in te sluiten, maar alleen met een koppeling naar het bestand.

Deze C#‑code laat zien hoe je een [OleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe) met een gekoppeld Excel‑bestand aan een dia toevoegt:

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Voeg een OLE-objectframe toe met een gekoppeld Excel-bestand.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Toegang tot OLE‑objectframes**

Als een OLE‑object al is ingesloten in een dia, kun je het eenvoudig vinden of er toegang toe krijgen op deze manier:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Toegang tot de [OleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe) vorm. In ons voorbeeld gebruikten we de eerder gemaakte PPTX die slechts één vorm heeft op de eerste dia.  We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleobjectframe). Dit was het gewenste OLE‑objectframe waarvoor toegang nodig is.  
4. Zodra het OLE‑objectframe benaderd is, kun je er elke bewerking op uitvoeren.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑diagramobject ingesloten in een dia) en de bijbehorende bestandsdata benaderd.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Haal de eerste vorm op als een OLE-objectframe.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Haal de ingesloten bestandsdata op.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Haal de extensie van het ingesloten bestand op.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Gekoppelde OLE‑objectframe‑eigenschappen benaderen**

Aspose.Slides biedt de mogelijkheid om gekoppelde OLE‑objectframe‑eigenschappen te benaderen.

Deze C#‑code laat zien hoe je controleert of een OLE‑object gekoppeld is en vervolgens het pad naar het gekoppelde bestand verkrijgt:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Haal de eerste vorm op als een OLE-objectframe.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Controleer of het OLE-object gekoppeld is.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Print het volledige pad naar het gekoppelde bestand.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Print het relatieve pad naar het gekoppelde bestand indien aanwezig.
        // Alleen PPT-presentaties kunnen het relatieve pad bevatten.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE‑objectdata wijzigen**

{{% alert color="primary" %}} 

In deze sectie gebruikt het codevoorbeeld hieronder [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Als een OLE‑object al is ingesloten in een dia, kun je dat object eenvoudig benaderen en de data op deze manier wijzigen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Toegang tot de [OLEObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe) vorm.   In ons voorbeeld gebruikten we de eerder gemaakte PPTX die één vorm heeft op de eerste dia. We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleobjectframe). Dit was het gewenste OLE‑objectframe waarvoor toegang nodig is.  
4. Zodra het OLE‑objectframe benaderd is, kun je er elke bewerking op uitvoeren.  
5. Maak een `Workbook`‑object aan en benader de OLE‑data.  
6. Benader het gewenste `Worksheet` en wijzig de data.  
7. Sla de bijgewerkte `Workbook` op in een stream.  
8. Wijzig de OLE‑objectdata vanuit de stream.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑diagramobject ingesloten in een dia) benaderd en wordt de bestandsdata aangepast om de diagramgegevens bij te werken.

```csharp 
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
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Pas de workbook-gegevens aan.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
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

## **Andere bestandstypen in dia's insluiten**

Naast Excel‑diagrammen maakt Aspose.Slides for .NET het mogelijk om andere bestandstypen in dia's in te sluiten. Je kunt bijvoorbeeld HTML‑, PDF‑ en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het bijbehorende programma, of wordt de gebruiker gevraagd een geschikt programma te selecteren om het te openen.

Deze C#‑code laat zien hoe je HTML en ZIP in een dia insluit:

```c#
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

Bij het werken met presentaties moet je mogelijk oude OLE‑objecten vervangen door nieuwe of een niet‑ondersteund OLE‑object vervangen door een ondersteund. Aspose.Slides for .NET maakt het mogelijk om het bestandstype voor een ingesloten object in te stellen, zodat je de OLE‑framedata of de extensie kunt bijwerken.

Deze C#‑code laat zien hoe je het bestandstype voor een ingesloten OLE‑object instelt op `zip`:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Verander het bestandstype naar ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Pictogramafbeeldingen en titels voor ingesloten objecten instellen**

Na het insluiten van een OLE‑object wordt automatisch een voorbeeld toegevoegd bestaande uit een pictogramafbeelding. Dit voorbeeld is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als je een specifieke afbeelding en tekst wilt gebruiken als elementen in het voorbeeld, kun je de pictogramafbeelding en titel instellen met Aspose.Slides for .NET.

Deze C#‑code laat zien hoe je de pictogramafbeelding en titel voor een ingesloten object instelt: 

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Voeg een afbeelding toe aan de presentatiebronnen.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Stel een titel en de afbeelding in voor de OLE-preview.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Voorkomen dat een OLE‑objectframe wordt vergroot en verplaatst**

Nadat je een gekoppeld OLE‑object aan een presentatiedia hebt toegevoegd, kun je bij het openen van de presentatie in PowerPoint een bericht zien dat vraagt om de koppelingen bij te werken. Als je op de knop "Update Links" klikt, kan dit de grootte en positie van het OLE‑objectframe wijzigen omdat PowerPoint de data van het gekoppelde OLE‑object bijwerkt en het voorbeeld van het object ververst. Om te voorkomen dat PowerPoint vraagt om de data van het object bij te werken, stel je de `UpdateAutomatic`‑eigenschap van de [IOleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleobjectframe/) interface in op `false`:

```cs
oleFrame.UpdateAutomatic = false;
```

## **Ingesloten bestanden extraheren**

Aspose.Slides for .NET maakt het mogelijk de in dia's ingesloten bestanden als OLE‑objecten te extraheren op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de OLE‑objecten bevat die je wilt extraheren.  
2. Loop door alle vormen in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/oleobjectframe) vormen.  
3. Benader de data van ingesloten bestanden uit OLE‑objectframes en schrijf deze naar schijf.  

Deze C#‑code laat zien hoe je bestanden die in een dia zijn ingesloten als OLE‑objecten extraheert:

```c#
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

**Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?**

Wat zichtbaar is op de dia wordt gerenderd – het pictogram/plaatsvervangende afbeelding (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig kun je een eigen preview‑afbeelding instellen om de verwachte weergave in de geëxporteerde PDF te garanderen.

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de vorm: Aspose.Slides biedt [vergrendelingen op vormniveau](/slides/nl/net/applying-protection-to-presentation/). Dit is geen encryptie, maar voorkomt effectief accidentele bewerkingen en verplaatsing.

**Waarom “springt” een gekoppeld Excel‑object of verandert van grootte wanneer ik de presentatie open?**

PowerPoint kan de preview van de gekoppelde OLE vernieuwen. Voor een stabiele weergave kun je de [Working Solution for Worksheet Resizing](/slides/nl/net/working-solution-for-worksheet-resizing/) aanpak volgen – ofwel het frame aanpassen aan het bereik, of het bereik schalen naar een vast frame en een geschikt vervang‑afbeelding instellen.

**Worden relatieve paden voor gekoppelde OLE‑objecten bewaard in het PPTX‑formaat?**

In PPTX is informatie over “relatieve paden” niet beschikbaar – alleen het volledige pad. Relatieve paden bestaan alleen in het oudere PPT‑formaat. Voor draagbaarheid kun je beter betrouwbare absolute paden/toegankelijke URI’s of insluiting gebruiken.