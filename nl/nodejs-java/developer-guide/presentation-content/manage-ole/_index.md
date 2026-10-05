---
title: Beheer OLE in presentaties met JavaScript
linktitle: Beheer OLE
type: docs
weight: 40
url: /nl/nodejs-java/manage-ole/
keywords:
- OLE object
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
description: "Optimaliseer het beheer van OLE‑objecten in PowerPoint‑ en OpenDocument‑bestanden met Aspose.Slides voor Node.js via Java. Voeg OLE‑inhoud in, werk bij en exporteer deze moeiteloos."
---
## **Inleiding**

{{% alert color="info" title="Opmerking" %}}

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt om gegevens en objecten die in één toepassing zijn gemaakt, via koppeling of insluiting in een andere toepassing te plaatsen.

{{% /alert %}} 

Beschouw een grafiek die in MS Excel is gemaakt. De grafiek wordt vervolgens in een PowerPoint‑dia geplaatst. Die Excel‑grafiek wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan als een pictogram verschijnen. In dat geval wordt bij dubbelklikken op het pictogram de grafiek geopend in de bijbehorende toepassing (Excel), of wordt u gevraagd een toepassing te selecteren om het object te openen of te bewerken.  
- Een OLE‑object kan de feitelijke inhoud weergeven, zoals de inhoud van een grafiek. In dat geval wordt de grafiek geactiveerd in PowerPoint, laadt de grafiekinterface en kunt u de gegevens van de grafiek binnen PowerPoint wijzigen.  

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) maakt het mogelijk OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **OLE‑objectframes aan dia's toevoegen**

Aangenomen dat u al een grafiek in Microsoft Excel hebt gemaakt en deze wilt insluiten in een dia als een OLE‑objectframe met behulp van Aspose.Slides for Node.js via Java, kunt u dit als volgt doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) klasse.  
1. Verkrijg een referentie naar een dia via de index.  
1. Lees het Excel‑bestand als een byte‑array.  
1. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.  
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

In het onderstaande voorbeeld hebben we een grafiek uit een Excel‑bestand aan een dia toegevoegd als een OLE‑objectframe met behulp van Aspose.Slides for Node.js via Java.  
**Opmerking** dat de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) constructor een extensie van het in te sluiten object als tweede parameter accepteert. Deze extensie stelt PowerPoint in staat om het bestandstype correct te interpreteren en de juiste toepassing te kiezen om dit OLE‑object te openen.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Gekoppelde OLE‑objectframes toevoegen**

Aspose.Slides for Node.js via Java maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) toe te voegen zonder data in te sluiten, maar alleen met een koppeling naar het bestand.  

Deze JavaScript‑code laat zien hoe u een [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) met een gekoppeld Excel‑bestand aan een dia kunt toevoegen:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Voeg een OLE‑objectframe toe met een gekoppeld Excel‑bestand.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE‑objectframes benaderen**

Als een OLE‑object al is ingesloten in een dia, kunt u het op deze manier eenvoudig vinden of benaderen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) klasse te maken.  
2. Verkrijg de referentie van de dia door de index te gebruiken.  
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) vorm. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die slechts één vorm heeft op de eerste dia.  
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑grafiekobject dat in een dia is ingesloten) en de bestandsgegevens ervan benaderd.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Haal de ingesloten bestandsgegevens op.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Haal de extensie van het ingesloten bestand op.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Eigenschappen van gekoppeld OLE‑objectframe benaderen**

Aspose.Slides maakt het mogelijk gekoppelde OLE‑objectframe‑eigenschappen te benaderen.  

Deze JavaScript‑code laat zien hoe u kunt controleren of een OLE‑object gekoppeld is en vervolgens het pad naar het gekoppelde bestand kunt verkrijgen:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Controleer of het OLE object gekoppeld is.
    if (oleFrame.isObjectLink()) {
        // Print het volledige pad naar het gekoppelde bestand.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Print het relatieve pad naar het gekoppelde bestand indien aanwezig.
        // Alleen PPT presentaties kunnen het relatieve pad bevatten.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE‑objectgegevens wijzigen**

{{% alert color="info" title="Opmerking" %}}

In dit gedeelte maakt het code‑voorbeeld hieronder gebruik van [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Als een OLE‑object al in een dia is ingesloten, kunt u dat object op deze manier eenvoudig benaderen en de gegevens ervan wijzigen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) klasse te maken.  
2. Verkrijg de referentie van de dia via de index.  
3. Benader de OLE‑objectframe‑vorm. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die één vorm heeft op de eerste dia.  
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.  
5. Maak een `Workbook`‑object aan en benader de OLE‑gegevens.  
6. Benader de gewenste `Worksheet` en wijzig de gegevens.  
7. Sla de bijgewerkte `Workbook` op in een stream.  
8. Wijzig de OLE‑objectgegevens vanuit de stream.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑grafiekobject ingesloten in een dia) benaderd, en worden de bestandsgegevens aangepast om de grafiekgegevens bij te werken.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // Lees de OLE‑objectgegevens als een Workbook‑object.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Pas de workbook‑gegevens aan.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Wijzig de OLE‑frame‑objectgegevens.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Andere bestandstypen in dia's insluiten**

Naast Excel‑grafieken maakt Aspose.Slides for Node.js via Java het mogelijk andere soorten bestanden in dia's in te sluiten. U kunt bijvoorbeeld HTML‑, PDF‑ en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het bijbehorende programma, of krijgt de gebruiker een prompt om een geschikt programma te selecteren om het te openen.  

Deze JavaScript‑code laat zien hoe u HTML en ZIP in een dia kunt insluiten:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

## **Bestandstypen voor ingesloten objecten instellen**

Bij het werken met presentaties kan het nodig zijn oude OLE‑objecten te vervangen door nieuwe, of een niet‑ondersteund OLE‑object te vervangen door een ondersteund object. Aspose.Slides for Node.js via Java maakt het mogelijk het bestandstype voor een ingesloten object in te stellen, zodat u de OLE‑frame‑gegevens of de extensie kunt bijwerken.  

Deze JavaScript‑code laat zien hoe u het bestandstype voor een ingesloten OLE‑object instelt op `zip`:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

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

## **Pictogramafbeeldingen en titels voor ingesloten objecten instellen**

Na het insluiten van een OLE‑object wordt automatisch een voorbeeld met een pictogramafbeelding toegevoegd. Dit voorbeeld is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als u een specifieke afbeelding en tekst wilt gebruiken als elementen in het voorbeeld, kunt u de pictogramafbeelding en de titel instellen met Aspose.Slides for Node.js via Java.  

Deze JavaScript‑code laat zien hoe u de pictogramafbeelding en titel voor een ingesloten object instelt:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Voeg een afbeelding toe aan de presentatieresources.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Stel een titel en de afbeelding in voor de OLE-preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Voorkomen dat een OLE‑objectframe wordt vergroot of verplaatst**

Nadat u een gekoppeld OLE‑object aan een presentatiedia hebt toegevoegd, kan PowerPoint bij het openen van de presentatie een bericht tonen waarin u wordt gevraagd de koppelingen bij te werken. Door op de knop "Koppelingen bijwerken" te klikken, kan de grootte en positie van het OLE‑objectframe wijzigen, omdat PowerPoint de gegevens van het gekoppelde OLE‑object bijwerkt en het voorbeeld ververst. Om te voorkomen dat PowerPoint vraagt de gegevens van het object bij te werken, roept u de [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic)‑methode van de [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/)‑klasse aan met `false`:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ingesloten bestanden extraheren**

Aspose.Slides for Node.js via Java maakt het mogelijk de in dia's ingesloten bestanden als OLE‑objecten op deze manier te extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑klasse die de OLE‑objecten bevat die u wilt extraheren.  
2. Doorloop alle vormen in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe)‑vormen.  
3. Benader de gegevens van ingesloten bestanden uit OLE‑objectframes en schrijf ze naar de schijf.  

Deze JavaScript‑code laat zien hoe u bestanden die in een dia zijn ingesloten als OLE‑objecten kunt extraheren:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

## **Veelgestelde vragen**

**Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?**

Wat zichtbaar is op de dia wordt gerenderd—het pictogram/substituutbeeld (preview). De "live" OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig kunt u uw eigen preview‑afbeelding instellen om de verwachte weergave in de geëxporteerde PDF te garanderen.  

Om ook het ingesloten bestand als PDF‑bijlage te behouden, roept u [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) aan met `true`. Deze optie is standaard uitgeschakeld. Voor een voorbeeld en instructies om de bijlage te controleren, zie [Preserve Embedded OLE Files as PDF Attachments](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de vorm: Aspose.Slides biedt vergrendelingen op vormniveau. Dit is geen encryptie, maar voorkomt effectief accidentele bewerkingen en verplaatsingen.

**Worden relatieve paden voor gekoppelde OLE‑objecten behouden in het PPTX‑formaat?**

In PPTX is informatie over "relatief pad" niet beschikbaar—alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid geeft u de voorkeur aan betrouwbare absolute paden/toegankelijke URI's of insluiten.