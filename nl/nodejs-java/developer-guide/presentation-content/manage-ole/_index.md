---
title: OLE beheren in presentaties met JavaScript
linktitle: OLE beheren
type: docs
weight: 40
url: /nl/nodejs-java/manage-ole/
keywords:
- OLE-object
- Objectkoppeling en insluiting
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Optimaliseer het beheer van OLE‑objecten in PowerPoint‑ en OpenDocument‑bestanden met Aspose.Slides voor Node.js via Java. Voeg OLE‑inhoud in, werk deze bij en exporteer ze moeiteloos."
---
## **Inleiding**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één applicatie zijn gemaakt, in een andere applicatie te plaatsen via koppelen of insluiten. 

{{% /alert %}} 

Beschouw een grafiek die is gemaakt in MS Excel. De grafiek wordt vervolgens geplaatst in een PowerPoint‑dia. Die Excel‑grafiek wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan verschijnen als een pictogram. In dat geval wordt de grafiek geopend in de bijbehorende toepassing (Excel) wanneer u dubbelklikt op het pictogram, of wordt u gevraagd om een toepassing te selecteren voor het openen of bewerken van het object. 
- Een OLE‑object kan ook zijn eigenlijke inhoud tonen, zoals de inhoud van een grafiek. In dat geval wordt de grafiek geactiveerd in PowerPoint, laadt de grafiekomgeving, en kunt u de gegevens van de grafiek bewerken binnen PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nl/nodejs-java/) stelt u in staat OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/OleObjectFrame)).

## **Toevoegen van OLE-objectframes aan dia's**

Stel dat u al een grafiek hebt gemaakt in Microsoft Excel en deze wilt insluiten in een dia als een OLE‑objectframe met Aspose.Slides for Node.js via Java, dan kunt u dit op de volgende manier doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.  
2. Haal de referentie van een dia op via de index.  
3. Lees het Excel‑bestand in als een byte‑array.  
4. Voeg de [OleObjectFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/OleObjectFrame) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.  
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

In het voorbeeld hieronder hebben we een grafiek uit een Excel‑bestand toegevoegd aan een dia als OLE‑objectframe met Aspose.Slides for Node.js via Java.  
**Opmerking** dat de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/OleEmbeddedDataInfo)‑constructor een extensie van het in te sluiten object neemt als tweede parameter. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste toepassing te kiezen om dit OLE‑object te openen.

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Bereid de gegevens voor het OLE-object voor.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Voeg het OLE-objectframe toe aan de dia.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Toevoegen van gekoppelde OLE-objectframes**

Aspose.Slides for Node.js via Java maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/OleObjectFrame) toe te voegen zonder data in te sluiten, maar alleen met een koppeling naar het bestand.

Deze JavaScript‑code laat zien hoe u een [OleObjectFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/OleObjectFrame) met een gekoppeld Excel‑bestand toevoegt aan een dia:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Voeg een OLE-objectframe toe met een gekoppeld Excel-bestand.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Toegang tot OLE-objectframes**

Als een OLE‑object al is ingesloten in een dia, kunt u het eenvoudig vinden of benaderen op de volgende manier:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/OleObjectFrame)‑vorm. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die slechts één vorm op de eerste dia heeft.  
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑grafiekobject ingesloten in een dia) en de bijbehorende bestandsdata benaderd.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Verkrijg de ingesloten bestandsgegevens.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Verkrijg de extensie van het ingesloten bestand.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Toegang tot eigenschappen van gekoppelde OLE-objectframes**

Aspose.Slides maakt het mogelijk de eigenschappen van gekoppelde OLE‑objectframes te benaderen.

Deze JavaScript‑code laat zien hoe u controleert of een OLE‑object is gekoppeld en vervolgens het pad naar het gekoppelde bestand opvraagt:

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Controleer of het OLE-object gekoppeld is.
    if (oleFrame.isObjectLink()) {
        // Print het volledige pad naar het gekoppelde bestand.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Print het relatieve pad naar het gekoppelde bestand indien aanwezig.
        // Alleen PPT-presentaties kunnen het relatieve pad bevatten.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Wijzigen van OLE-objectgegevens**

{{% alert color="primary" %}} 

In dit gedeelte maakt het onderstaande code‑voorbeeld gebruik van [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

Als een OLE‑object al in een dia is ingesloten, kunt u dat object eenvoudig benaderen en de gegevens ervan op de volgende manier wijzigen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Benader de OLE‑objectframe‑vorm. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die één vorm op de eerste dia heeft.  
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.  
5. Maak een `Workbook`‑object aan en benader de OLE‑data.  
6. Benader de gewenste `Worksheet` en wijzig de data.  
7. Sla het bijgewerkte `Workbook` op in een stream.  
8. Wijzig de OLE‑objectdata vanuit de stream.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑grafiekobject ingesloten in een dia) benaderd en wordt de bestandsdata aangepast om de grafiekgegevens bij te werken.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Lees de OLE‑objectdata als een Workbook‑object.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Wijzig de werkboekgegevens.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Wijzig de OLE‑frame‑objectgegevens.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Andere bestandstypen insluiten in dia's**

Naast Excel‑grafieken maakt Aspose.Slides for Node.js via Java het mogelijk andere soorten bestanden in dia's in te sluiten. U kunt bijvoorbeeld HTML-, PDF- en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het relevante programma, of wordt de gebruiker gevraagd een geschikt programma te kiezen om het te openen.

Deze JavaScript‑code laat zien hoe u HTML en ZIP in een dia kunt insluiten:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Bestandstypen instellen voor ingesloten objecten**

Bij het werken met presentaties kan het nodig zijn oude OLE‑objecten te vervangen door nieuwe of een niet‑ondersteund OLE‑object te vervangen door een ondersteund. Aspose.Slides for Node.js via Java maakt het mogelijk het bestandstype voor een ingesloten object in te stellen, zodat u de OLE‑frame‑gegevens of de extensie kunt bijwerken.

Deze JavaScript‑code laat zien hoe u het bestandstype voor een ingesloten OLE‑object instelt op `zip`:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Wijzig het bestandstype naar ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Pictogramafbeeldingen en titels instellen voor ingesloten objecten**

Na het insluiten van een OLE‑object wordt automatisch een preview met een pictogramafbeelding toegevoegd. Dit preview is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als u een specifieke afbeelding en tekst als elementen in het preview wilt gebruiken, kunt u de pictogramafbeelding en titel instellen met Aspose.Slides for Node.js via Java.

Deze JavaScript‑code laat zien hoe u de pictogramafbeelding en titel voor een ingesloten object instelt:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Voeg een afbeelding toe aan de presentatieresources.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Voorkomen dat een OLE-objectframe wordt gewijzigd in grootte en positie**

Nadat u een gekoppeld OLE‑object aan een presentatiedia hebt toegevoegd, kan PowerPoint bij het openen van de presentatie een bericht tonen waarin gevraagd wordt de koppelingen bij te werken. Het klikken op de knop "Update Links" kan de grootte en positie van het OLE‑objectframe wijzigen, omdat PowerPoint de gegevens van het gekoppelde OLE‑object bijwerkt en het preview ververst. Om te voorkomen dat PowerPoint vraagt de gegevens van het object bij te werken, gebruikt u de `setUpdateAutomatic`‑methode van de [OleObjectFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/oleobjectframe/)‑klasse met de waarde `false`:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **Ingesloten bestanden extraheren**

Aspose.Slides for Node.js via Java maakt het mogelijk om de in dia's ingesloten bestanden als OLE‑objecten te extraheren op de volgende manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse die de OLE‑objecten bevat die u wilt extraheren.  
2. Loop door alle vormen in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/OleObjectFrame)‑vormen.  
3. Benader de data van ingesloten bestanden uit OLE‑objectframes en schrijf deze naar schijf.  

Deze JavaScript‑code laat zien hoe u bestanden die in een dia zijn ingesloten als OLE‑objecten kunt extraheren:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **FAQ**

**Wordt de OLE-inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?**

Wat zichtbaar is op de dia wordt gerenderd — het pictogram/vervangende afbeelding (preview). De "live" OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig, stel uw eigen preview‑afbeelding in om het verwachte uiterlijk in de geëxporteerde PDF te waarborgen.

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de vorm: Aspose.Slides biedt vorm‑niveau vergrendelingen. Dit is geen encryptie, maar voorkomt effectief accidentele bewerkingen en verplaatsingen.

**Worden relatieve paden voor gekoppelde OLE‑objecten behouden in het PPTX‑formaat?**

In PPTX is informatie over "relatieve paden" niet beschikbaar — alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid heeft u de voorkeur aan betrouwbare absolute paden/toegankelijke URI's of insluiten.