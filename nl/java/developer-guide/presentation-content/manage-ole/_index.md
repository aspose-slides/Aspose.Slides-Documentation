---
title: Beheer OLE in presentaties met Java
linktitle: Beheer OLE
type: docs
weight: 40
url: /nl/java/manage-ole/
keywords:
- OLE‑object
- Object koppelen & insluiten
- OLE toevoegen
- OLE insluiten
- object toevoegen
- object insluiten
- bestand toevoegen
- bestand insluiten
- gelinkt object
- gelinkt bestand
- OLE wijzigen
- OLE‑pictogram
- OLE‑titel
- OLE extraheren
- object extraheren
- bestand extraheren
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Optimaliseer het beheer van OLE‑objecten in PowerPoint‑ en OpenDocument‑bestanden met Aspose.Slides voor Java. Voeg OLE‑inhoud in, werk het bij en exporteer het naadloos."
---
## **Inleiding**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één toepassing zijn gemaakt, in een andere toepassing te plaatsen via koppelen of insluiten. 

{{% /alert %}} 

Stel een diagram voor dat in MS Excel is gemaakt. Het diagram wordt vervolgens geplaatst in een PowerPoint‑dia. Dat Excel‑diagram wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan verschijnen als een pictogram. In dat geval wordt het diagram bij dubbelklikken op het pictogram geopend in de bijbehorende toepassing (Excel), of wordt u gevraagd een toepassing te selecteren om het object te openen of te bewerken. 
- Een OLE‑object kan zijn werkelijke inhoud weergeven, zoals de inhoud van een diagram. In dat geval wordt het diagram geactiveerd in PowerPoint, wordt de diagraminterface geladen, en kunt u de gegevens van het diagram binnen PowerPoint wijzigen.

[Aspose.Slides for Java](https://products.aspose.com/slides/nl/java/) stelt u in staat OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OleObjectFrame)).

## **OLE‑objectframes aan dia's toevoegen**

Veronderstel dat u al een diagram in Microsoft Excel hebt gemaakt en dit wilt insluiten in een dia als een OLE‑objectframe met behulp van Aspose.Slides for Java; u kunt dit op de volgende manier doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
1. Haal de referentie van een dia op via de index.  
1. Lees het Excel‑bestand in als een byte‑array.  
1. Voeg de [OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OleObjectFrame) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.  
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

In het onderstaande voorbeeld hebben we een diagram uit een Excel‑bestand aan een dia toegevoegd als een OLE‑objectframe met behulp van Aspose.Slides for Java.  
**Opmerking** dat de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OleEmbeddedDataInfo) constructor een extensie van het in te sluiten object als tweede parameter neemt. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste toepassing te kiezen om dit OLE‑object te openen.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Bereid de gegevens voor het OLE-object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Voeg het OLE-objectframe toe aan de dia.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Gelinkte OLE‑objectframes toevoegen**

Aspose.Slides for Java maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OleObjectFrame) toe te voegen zonder gegevens in te sluiten, maar alleen met een koppeling naar het bestand.  

Deze Java‑code toont hoe u een [OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OleObjectFrame) met een gelinkte Excel‑file aan een dia kunt toevoegen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Voeg een OLE‑objectframe toe met een gelinkte Excel‑file.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Toegang tot OLE‑objectframes**

Als een OLE‑object al in een dia is ingesloten, kunt u het op de volgende manier gemakkelijk vinden of openen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse te maken.  
2. Haal de referentie van de dia op met behulp van de index.  
3. Open de vorm van het [OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OleObjectFrame). In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die slechts één vorm op de eerste dia heeft.  We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IOleObjectFrame). Dit was het gewenste OLE‑objectframe dat geopend moest worden.  
4. Zodra het OLE‑objectframe geopend is, kunt u er elke bewerking op uitvoeren.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑diagramobject ingesloten in een dia) en de bijbehorende bestandsgegevens geopend.

``` java 
import com.aspose.slides.*;

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

### **Eigenschappen van gelinkte OLE‑objectframes openen**

Aspose.Slides maakt het mogelijk de eigenschappen van gelinkte OLE‑objectframes te openen.  

Deze Java‑code toont hoe u kunt controleren of een OLE‑object gelinkt is en vervolgens het pad naar het gelinkte bestand opvraagt:

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 

In dit gedeelte gebruikt het onderstaande code‑voorbeeld [Aspose.Cells for Java](/cells/java/).  

{{% /alert %}}

Als een OLE‑object al in een dia is ingesloten, kunt u dat object op de volgende manier eenvoudig openen en de gegevens ervan wijzigen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Open de vorm van het OLE‑objectframe. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die één vorm op de eerste dia heeft. We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IOleObjectFrame). Dit was het gewenste OLE‑objectframe dat geopend moest worden.  
4. Zodra het OLE‑objectframe geopend is, kunt u er elke bewerking op uitvoeren.  
5. Maak een `Workbook`‑object aan en krijg toegang tot de OLE‑gegevens.  
6. Open de gewenste `Worksheet` en wijzig de gegevens.  
7. Sla de bijgewerkte `Workbook` op in een stream.  
8. Wijzig de OLE‑objectgegevens vanuit de stream.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑diagramobject ingesloten in een dia) geopend, en worden de bestandsgegevens aangepast om de diagramgegevens bij te werken.

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Lees de OLE‑objectgegevens als een Workbook‑object.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Pas de workbook‑gegevens aan.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Verander de OLE‑frame‑objectgegevens.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Andere bestandstypen in dia's insluiten**

Naast Excel‑diagrammen maakt Aspose.Slides for Java het mogelijk andere bestandstypen in dia's in te sluiten. U kunt bijvoorbeeld HTML-, PDF- en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het bijbehorende programma, of er wordt gevraagd een geschikt programma te selecteren om het te openen.

Deze Java‑code toont hoe u HTML en ZIP in een dia kunt insluiten:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

Bij het werken met presentaties moet u mogelijk oude OLE‑objecten vervangen door nieuwe, of een niet‑ondersteund OLE‑object vervangen door een ondersteund object. Aspose.Slides for Java maakt het mogelijk het bestandstype voor een ingesloten object in te stellen, zodat u de OLE‑frame‑gegevens of de extensie kunt bijwerken.

Deze Java‑code toont hoe u het bestandstype voor een ingesloten OLE‑object instelt op `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Pictogramafbeeldingen en titels voor ingesloten objecten instellen**

Na het insluiten van een OLE‑object wordt automatisch een preview met een pictogramafbeelding toegevoegd. Deze preview is wat gebruikers zien voordat ze het OLE‑object openen of bekijken. Als u een specifieke afbeelding en tekst wilt gebruiken als elementen in de preview, kunt u de pictogramafbeelding en titel instellen met Aspose.Slides for Java.

Deze Java‑code toont hoe u de pictogramafbeelding en titel voor een ingesloten object instelt:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **Voorkomen dat een OLE‑objectframe van grootte verandert of verplaatst wordt**

Nadat u een gelinkte OLE‑object aan een presentatiedia hebt toegevoegd, kunt u bij het openen van de presentatie in PowerPoint een bericht zien dat vraagt de koppelingen bij te werken. Klikken op de knop "Update Links" kan de grootte en positie van het OLE‑objectframe veranderen omdat PowerPoint de gegevens van het gelinkte OLE‑object bijwerkt en de preview ververst. Om te voorkomen dat PowerPoint vraagt de gegevens van het object bij te werken, zet u de `setUpdateAutomatic`‑methode van de [IOleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ioleobjectframe/) interface op `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ingesloten bestanden extraheren**

Aspose.Slides for Java maakt het mogelijk de in dia's ingesloten bestanden als OLE‑objecten op de volgende manier te extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse die de OLE‑objecten bevat die u wilt extraheren.  
2. Loop door alle vormen in de presentatie en open de [OLEObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/oleobjectframe)‑vormen.  
3. Open de gegevens van de ingesloten bestanden uit OLE‑objectframes en schrijf ze naar schijf.  

Deze Java‑code toont hoe u bestanden die in een dia zijn ingesloten als OLE‑objecten kunt extraheren:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

### Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?

Wat op de dia zichtbaar is, wordt gerenderd—het pictogram/substitutie‑beeld (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig, stel uw eigen preview‑afbeelding in om de verwachte weergave in de geëxporteerde PDF te garanderen.

### Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?

Vergrendel de vorm: Aspose.Slides biedt [vergrendelingen op vormniveau](/slides/nl/java/applying-protection-to-presentation/). Dit is geen encryptie, maar voorkomt effectief per ongeluk bewerken en verplaatsen.

### Waarom ‘springt’ een gelinkt Excel‑object of verandert van grootte wanneer ik de presentatie open?

PowerPoint kan de preview van de gelinkte OLE verfrissen. Voor een stabiele weergave kunt u de richtlijnen van de [Working Solution for Worksheet Resizing](/slides/nl/java/working-solution-for-worksheet-resizing/) volgen—pas het frame aan op het bereik, of schaal het bereik naar een vast frame en stel een passend substitutie‑beeld in.

### Worden relatieve paden voor gelinkte OLE‑objecten behouden in het PPTX‑formaat?

In PPTX is informatie over “relatief pad” niet beschikbaar—alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid heeft u de voorkeur voor betrouwbare absolute paden/toegankelijke URI’s of insluiting.