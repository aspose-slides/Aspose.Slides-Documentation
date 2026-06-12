---
title: OLE beheren in presentaties met Java
linktitle: OLE beheren
type: docs
weight: 40
url: /nl/java/manage-ole/
keywords:
- OLE-object
- Objectkoppeling en -insluiting
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
- Java
- Aspose.Slides
description: "Optimaliseer het beheer van OLE‑objecten in PowerPoint‑ en OpenDocument‑bestanden met Aspose.Slides voor Java. Voeg OLE‑inhoud in, werk deze bij en exporteer naadloos."
---
## **Inleiding**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één toepassing zijn gemaakt, in een andere toepassing te plaatsen via koppelen of insluiten. 

{{% /alert %}} 

Beschouw een diagram dat in MS Excel is gemaakt. Het diagram wordt vervolgens in een PowerPoint‑dia geplaatst. Dat Excel‑diagram wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan als een pictogram verschijnen. In dat geval wordt bij dubbelklikken op het pictogram het diagram geopend in de bijbehorende toepassing (Excel), of u wordt gevraagd een toepassing te kiezen voor het openen of bewerken van het object. 
- Een OLE‑object kan zijn werkelijke inhoud weergeven, bijvoorbeeld de inhoud van een diagram. In dat geval wordt het diagram geactiveerd in PowerPoint, laadt de diagram‑interface en kunt u de diagram‑gegevens binnen PowerPoint aanpassen.

[Aspose.Slides for Java](https://products.aspose.com/slides/nl/java/) stelt u in staat OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OleObjectFrame)).

## **OLE‑objectframes aan dia's toevoegen**

Veronderstel dat u al een diagram in Microsoft Excel hebt gemaakt en het wilt insluiten in een dia als een OLE‑objectframe met Aspose.Slides for Java, dan kan dat als volgt:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Lees het Excel‑bestand in als een byte‑array.  
4. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OleObjectFrame) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.  
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

**Opmerking** dat de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OleEmbeddedDataInfo)‑constructor een uitbreidingsnaam voor het insluitbare object als tweede parameter neemt. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste toepassing te kiezen om dit OLE‑object te openen.

``` java
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Voorbereiden van gegevens voor het OLE-object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// OLE-objectframe aan de dia toevoegen.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Gelinkte OLE‑objectframes toevoegen**

Aspose.Slides for Java stelt u in staat een [OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OleObjectFrame) toe te voegen zonder gegevens in te sluiten, maar alleen met een koppeling naar het bestand.

Deze Java‑code laat zien hoe u een [OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OleObjectFrame) met een gelinkte Excel‑file aan een dia toevoegt:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Voeg een OLE-objectframe toe met een gekoppeld Excel-bestand.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE‑objectframes benaderen**

Als een OLE‑object al is ingesloten in een dia, kunt u het op deze manier eenvoudig vinden of benaderen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OleObjectFrame)‑vorm. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die slechts één vorm heeft op de eerste dia. We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IOleObjectFrame). Dit was het gewenste OLE‑objectframe om te benaderen.  
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑diagramobject dat in een dia is ingesloten) en de bestandgegevens ervan benaderd.

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Haal de ingebedde bestandsgegevens op.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Haal de extensie van het ingebedde bestand op.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Eigenschappen van gelinkte OLE‑objectframes benaderen**

Aspose.Slides stelt u in staat de eigenschappen van gelinkte OLE‑objectframes te benaderen.

Deze Java‑code laat zien hoe u controleert of een OLE‑object gelinkt is en vervolgens het pad naar het gelinkte bestand krijgt:

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Controleer of het OLE-object gelinkt is.
    if (oleFrame.isObjectLink()) {
        // Print het volledige pad naar het gelinkte bestand.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Print het relatieve pad naar het gelinkte bestand indien aanwezig.
        // Alleen PPT-presentaties kunnen het relatieve pad bevatten.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE‑objectgegevens wijzigen**

{{% alert color="primary" %}} 

In dit gedeelte gebruikt het code‑voorbeeld hieronder [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

Als een OLE‑object al is ingesloten in een dia, kunt u het op deze manier eenvoudig benaderen en de gegevens wijzigen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Benader de OLE‑objectframe‑vorm. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die één vorm heeft op de eerste dia. We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IOleObjectFrame). Dit was het gewenste OLE‑objectframe om te benaderen.  
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.  
5. Maak een `Workbook`‑object aan en benader de OLE‑gegevens.  
6. Benader het gewenste `Worksheet` en wijzig de gegevens.  
7. Sla het bijgewerkte `Workbook` op in een stream.  
8. Wijzig de OLE‑objectgegevens vanuit de stream.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑diagramobject dat in een dia is ingesloten) benaderd, en worden de bestandgegevens aangepast om de diagramgegevens bij te werken.

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Lees de OLE-objectgegevens als een Workbook-object.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Wijzig de workbook-gegevens.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Wijzig de OLE-frame-objectgegevens.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Andere bestandstypen in dia's insluiten**

Naast Excel‑diagrammen stelt Aspose.Slides for Java u in staat andere bestandstypen in dia's in te sluiten. U kunt bijvoorbeeld HTML-, PDF- en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het relevante programma, of wordt de gebruiker gevraagd een passend programma te kiezen om het te openen.

Deze Java‑code laat zien hoe u HTML en ZIP in een dia kunt insluiten:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Bestandstypen voor ingesloten objecten instellen**

Bij het werken met presentaties kan het nodig zijn oude OLE‑objecten te vervangen door nieuwe, of een niet‑ondersteund OLE‑object te vervangen door een ondersteund. Aspose.Slides for Java stelt u in staat het bestandstype voor een ingesloten object in te stellen, zodat u de OLE‑frame‑gegevens of de extensie kunt bijwerken.

Deze Java‑code laat zien hoe u het bestandstype voor een ingesloten OLE‑object instelt op `zip`:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Verander het bestandstype naar ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Pictogramafbeeldingen en titels voor ingesloten objecten instellen**

Nadat u een OLE‑object heeft ingesloten, wordt er automatisch een voorbeeld met een pictogramafbeelding toegevoegd. Deze voorbeeldweergave is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als u een specifieke afbeelding en tekst wilt gebruiken als elementen in de voorbeeldweergave, kunt u de pictogramafbeelding en titel instellen met Aspose.Slides for Java.

Deze Java‑code laat zien hoe u de pictogramafbeelding en titel voor een ingesloten object instelt:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Voeg een afbeelding toe aan de presentatieresources.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Stel een titel en de afbeelding in voor de OLE-preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Voorkomen dat een OLE‑objectframe wordt vergroot/verplaatst**

Nadat u een gelinkte OLE‑object aan een presentatie‑dia hebt toegevoegd, kunt u bij het openen van de presentatie in PowerPoint een bericht zien waarin gevraagd wordt de koppelingen bij te werken. Als u op de knop "Update Links" klikt, kan de grootte en positie van het OLE‑objectframe veranderen omdat PowerPoint de gegevens van het gelinkte OLE‑object bijwerkt en de voorbeeldweergave ververst. Om te voorkomen dat PowerPoint vraagt de objectgegevens bij te werken, stelt u de `setUpdateAutomatic`‑methode van de [IOleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ioleobjectframe/)‑interface in op `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Ingesloten bestanden extraheren**

Aspose.Slides for Java stelt u in staat om de in dia's ingesloten bestanden als OLE‑objecten op deze manier te extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse aan die de OLE‑objecten bevat die u wilt extraheren.  
2. Loop door alle vormen in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/oleobjectframe)‑vormen.  
3. Benader de gegevens van ingesloten bestanden uit OLE‑objectframes en schrijf ze naar schijf.  

Deze Java‑code laat zien hoe u bestanden die in een dia zijn ingesloten als OLE‑objecten kunt extraheren:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

**Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?**

Wat er zichtbaar is op de dia wordt gerenderd — het pictogram/substituut‑beeld (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig, stel uw eigen preview‑afbeelding in om het verwachte uiterlijk in de geëxporteerde PDF te garanderen.

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de vorm: Aspose.Slides biedt [vergrendelingen op vormniveau](/slides/nl/java/applying-protection-to-presentation/). Dit is geen encryptie, maar voorkomt effectief per ongeluk bewerken en verplaatsen.

**Waarom “springt” een gelinkte Excel‑object of verandert van grootte wanneer ik de presentatie open?**

PowerPoint kan de preview van het gelinkte OLE verversen. Voor een stabiel uiterlijk volgt u de richtlijnen van de [Working Solution for Worksheet Resizing](/slides/nl/java/working-solution-for-worksheet-resizing/) — pas het frame aan op het bereik, of schaal het bereik naar een vast frame en stel een geschikt substituut‑beeld in.

**Worden relatieve paden voor gelinkte OLE‑objecten behouden in het PPTX‑formaat?**

In PPTX is informatie over “relatieve paden” niet beschikbaar — alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid geeft u de voorkeur aan betrouwbare absolute paden/toegankelijke URI's of het insluiten.