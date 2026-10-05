---
title: Beheer OLE-objecten in presentaties in .NET
linktitle: Beheer OLE
type: docs
weight: 40
url: /nl/net/manage-ole/
keywords:
- OLE-object
- Objectkoppeling en -insluiting
- OLE toevoegen
- OLE insluiten
- object toevoegen
- object insluiten
- bestand toevoegen
- bestand insluiten
- gekoppeld object
- gekoppeld bestand
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
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor .NET. Sluit OLE-inhoud in, werk deze bij en exporteer ze moeiteloos."
---
## **Introductie**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één applicatie zijn gemaakt, in een andere applicatie te plaatsen via koppeling of insluiting. 

{{% /alert %}} 

Beschouw een grafiek die is gemaakt in MS Excel. Die grafiek wordt vervolgens in een PowerPoint‑dia geplaatst. Die Excel‑grafiek wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan verschijnen als een pictogram. In dat geval wordt, wanneer je dubbelklikt op het pictogram, de grafiek geopend in de bijbehorende applicatie (Excel), of wordt je gevraagd een applicatie te kiezen voor het openen of bewerken van het object. 
- Een OLE‑object kan de eigenlijke inhoud weergeven, bijvoorbeeld de inhoud van een grafiek. In dat geval wordt de grafiek geactiveerd in PowerPoint, de grafiek‑interface wordt geladen en kun je de gegevens van de grafiek binnen PowerPoint aanpassen.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) maakt het mogelijk OLE‑objecten in dia’s in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **OLE‑objectframes toevoegen aan dia’s**

Stel dat je al een grafiek in Microsoft Excel hebt gemaakt en deze wilt insluiten in een dia als OLE‑objectframe met Aspose.Slides for .NET, dan kun je dat op de volgende manier doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) klasse.
2. Haal een referentie naar een dia op via de index.
3. Lees het Excel‑bestand in als een byte‑array.
4. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het voorbeeld hieronder hebben we een grafiek uit een Excel‑bestand aan een dia toegevoegd als een [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) met Aspose.Slides for .NET.  
**Opmerking** dat de constructor van [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) een insluitbare object‑extensie als tweede parameter neemt. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste applicatie te kiezen om dit OLE‑object te openen.

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

### **Gekoppelde OLE‑objectframes toevoegen**

Aspose.Slides for .NET maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) toe te voegen zonder data in te sluiten, maar alleen met een koppeling naar het bestand.

Deze C#‑code laat zien hoe je een [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) met een gekoppeld Excel‑bestand aan een dia toevoegt:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Voeg een OLE-objectframe toe met een gekoppeld Excel‑bestand.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Toegang tot OLE‑objectframes**

Als een OLE‑object al is ingebed in een dia, kun je het op de volgende manier eenvoudig vinden of benaderen:

1. Laad een presentatie met het ingebedde OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) klasse te maken.
2. Haal de referentie van de dia op via de index.
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)‑vorm.  
   In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die slechts één vorm op de eerste dia bevat. We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Dit was het gewenste OLE‑objectframe om te benaderen.
4. Zodra het OLE‑objectframe is benaderd, kun je er elke bewerking op uitvoeren.

In het voorbeeld hieronder wordt een OLE‑objectframe (een Excel‑grafiekobject ingebed in een dia) en de bijbehorende bestandsdata benaderd.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Haal de eerste vorm op als een OLE-objectframe.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Haal de ingebedde bestandsdata op.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Haal de extensie van het ingebedde bestand op.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Eigenschappen van gekoppelde OLE‑objectframes benaderen**

Aspose.Slides maakt het mogelijk de eigenschappen van gekoppelde OLE‑objectframes te benaderen.

Deze C#‑code toont hoe je controleert of een OLE‑object gekoppeld is en vervolgens het pad naar het gekoppelde bestand verkrijgt:

```csharp
using Aspose.Slides;

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

{{% alert color="info" title="Note" %}}

In dit gedeelte gebruikt het code‑voorbeeld [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/).

{{% /alert %}}

Als een OLE‑object al is ingebed in een dia, kun je dat object eenvoudig benaderen en de data als volgt wijzigen:

1. Laad een presentatie met het ingebedde OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) klasse te maken.
2. Haal de referentie van de dia op via de index. 
3. Benader de [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)‑vorm.  
   In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die één vorm op de eerste dia bevat. We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Dit was het gewenste OLE‑objectframe om te benaderen.
4. Zodra het OLE‑objectframe is benaderd, kun je er elke bewerking op uitvoeren.
5. Maak een `Workbook`‑object aan en benader de OLE‑data.
6. Benader het gewenste `Worksheet` en pas de gegevens aan.
7. Sla het bijgewerkte `Workbook` op in een stream.
8. Wijzig de OLE‑objectdata vanuit de stream.

In het voorbeeld hieronder wordt een OLE‑objectframe (een Excel‑grafiekobject ingebed in een dia) benaderd en wordt de bestandsdata aangepast om de grafiekgegevens bij te werken.

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
                // Wijzig de workbook-data.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Verander de OLE-frameobjectdata.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Andere bestandstypen insluiten in dia’s**

Naast Excel‑grafieken maakt Aspose.Slides for .NET het mogelijk andere bestandstypen in dia’s in te sluiten. Zo kun je bijvoorbeeld HTML‑, PDF‑ en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het bijbehorende programma, of krijgt de gebruiker een prompt om een geschikt programma te kiezen.

Deze C#‑code laat zien hoe je HTML en ZIP in een dia kunt insluiten:

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

## **Bestandstypen instellen voor ingebedde objecten**

Bij het werken met presentaties kan het nodig zijn oude OLE‑objecten te vervangen door nieuwe of een niet‑ondersteund OLE‑object te vervangen door een ondersteund exemplaar. Aspose.Slides for .NET maakt het mogelijk het bestandstype voor een ingebed object in te stellen, zodat je de OLE‑framedata of de extensie kunt bijwerken.

Deze C#‑code toont hoe je het bestandstype voor een ingebed OLE‑object instelt op `zip`:

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

## **Pictogramafbeeldingen en titels instellen voor ingebedde objecten**

Na het insluiten van een OLE‑object wordt er automatisch een voorbeeld toegevoegd bestaande uit een pictogramafbeelding. Dit voorbeeld is wat gebruikers zien voordat ze het OLE‑object openen of benaderen. Als je een specifieke afbeelding en tekst wilt gebruiken als elementen in het voorbeeld, kun je via Aspose.Slides for .NET de pictogramafbeelding en titel instellen.

Deze C#‑code laat zien hoe je de pictogramafbeelding en titel voor een ingebed object instelt: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Voeg een afbeelding toe aan de presentatiemiddelen.
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

Nadat je een gekoppeld OLE‑object aan een presentatie‑dia hebt toegevoegd, kan PowerPoint bij het openen van de presentatie een bericht tonen dat vraagt de koppelingen bij te werken. Als je op “Update Links” klikt, kan de grootte en positie van het OLE‑objectframe veranderen omdat PowerPoint de data van het gekoppelde OLE‑object bijwerkt en het voorbeeld ververst. Om te voorkomen dat PowerPoint vraagt de data van het object bij te werken, zet je de `UpdateAutomatic`‑eigenschap van de [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) interface op `false`:

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

## **Ingebedde bestanden extraheren**

Aspose.Slides for .NET maakt het mogelijk bestanden die zijn ingebed in dia’s als OLE‑objecten te extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑klasse die de OLE‑objecten bevat die je wilt extraheren.
2. Loop door alle vormen in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)‑vormen.
3. Haal de data van de ingebedde bestanden uit de OLE‑objectframes en schrijf deze naar schijf.

Deze C#‑code laat zien hoe je bestanden die in een dia als OLE‑objecten zijn ingebed, kunt extraheren:

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

**Wordt de OLE‑inhoud gerenderd bij het exporteren van dia’s naar PDF/afbeeldingen?**

Wat zichtbaar is op de dia wordt gerenderd – het pictogram/substituut‑beeld (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien gewenst, stel een eigen preview‑afbeelding in om het verwachte uiterlijk in de geëxporteerde PDF te garanderen.

Om het ingebedde bestand tevens als PDF‑bijlage te behouden, zet je [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) op `true`. Deze optie is standaard uitgeschakeld. Zie een voorbeeld en instructies voor het controleren van de bijlage in [Preserve Embedded OLE Files as PDF Attachments](/slides/nl/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de vorm: Aspose.Slides biedt [shape‑level locks](/slides/nl/net/applying-protection-to-presentation/). Dit is geen encryptie, maar voorkomt effectief onbedoelde aanpassingen en verplaatsingen.

**Waarom “springt” een gekoppeld Excel‑object of verandert van grootte wanneer ik de presentatie open?**

PowerPoint kan het preview‑beeld van het gekoppelde OLE‑object vernieuwen. Voor een stabiel uiterlijk kun je de [Working Solution for Worksheet Resizing](/slides/nl/net/working-solution-for-worksheet-resizing/) volgen – ofwel het frame aanpassen aan het bereik, of het bereik schalen naar een vast frame en een geschikt substituut‑beeld instellen.

**Worden relatieve paden voor gekoppelde OLE‑objecten bewaard in het PPTX‑formaat?**

In PPTX is informatie over “relatieve paden” niet beschikbaar – alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid kun je beter betrouwbare absolute paden/toegankelijke URI’s of insluiting gebruiken.