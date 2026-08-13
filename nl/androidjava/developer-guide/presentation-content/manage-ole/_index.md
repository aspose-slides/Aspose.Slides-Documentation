---
title: Beheer OLE in presentaties op Android
linktitle: Beheer OLE
type: docs
weight: 40
url: /nl/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: "Optimaliseer het beheer van OLE‑objecten in PowerPoint‑ en OpenDocument‑bestanden met Aspose.Slides for Android via Java. Sluit OLE‑inhoud in, werk het bij en exporteer het moeiteloos."
---
## **Inleiding**

{{% alert color="info" %}} 
OLE (Object Linking & Embedding) is een Microsoft-technologie die het mogelijk maakt gegevens en objecten die in een toepassing zijn gemaakt, in een andere toepassing te plaatsen via koppeling of insluiting. 
{{% /alert %}} 

Stel een diagram voor dat in MS Excel is gemaakt. Het diagram wordt vervolgens in een PowerPoint-dia geplaatst. Dat Excel-diagram wordt beschouwd als een OLE-object. 

- Een OLE-object kan verschijnen als een pictogram. In dat geval wordt het diagram bij dubbelklikken op het pictogram geopend in de bijbehorende toepassing (Excel), of wordt u gevraagd een toepassing te selecteren voor het openen of bewerken van het object. 
- Een OLE-object kan de daadwerkelijke inhoud weergeven, bijvoorbeeld de inhoud van een diagram. In dat geval wordt het diagram geactiveerd in PowerPoint, laadt de diagraminterface, en kunt u de gegevens van het diagram binnen PowerPoint aanpassen. 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/nl/androidjava/) maakt het mogelijk OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OleObjectFrame)).

## **OLE‑objectframes aan dia's toevoegen**

Aangenomen dat u al een diagram in Microsoft Excel hebt gemaakt en het wilt insluiten in een dia als OLE‑objectframe met Aspose.Slides for Android via Java, kunt u dit als volgt doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Lees het Excel‑bestand als een byte‑array.  
4. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OleObjectFrame) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.  
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

In het voorbeeld hieronder hebben we een diagram uit een Excel‑bestand aan een dia toegevoegd als OLE‑objectframe met Aspose.Slides for Android via Java.  
**Note** dat de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OleEmbeddedDataInfo) constructor een uitbreidbare objectextensie als tweede parameter neemt. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste toepassing te kiezen om dit OLE‑object te openen.  

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Gelinkte OLE‑objectframes toevoegen**

Aspose.Slides for Android via Java maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OleObjectFrame) toe te voegen zonder gegevens in te sluiten, alleen met een koppeling naar het bestand.  

Deze Java‑code laat zien hoe u een [OleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OleObjectFrame) met een gelinkte Excel‑file aan een dia toevoegt:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Voeg een OLE-objectframe toe met een gelinkt Excel-bestand.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Toegang tot OLE‑objectframes**

Als een OLE‑object al is ingesloten in een dia, kunt u het als volgt eenvoudig vinden of benaderen:  

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse te maken.  
2. Haal de referentie van de dia op door de index te gebruiken.  
3. Benader de vorm van het [OleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OleObjectFrame). In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die slechts één vorm op de eerste dia heeft. We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ioleobjectframe/). Dit was het gewenste OLE‑objectframe om te benaderen.  
4. Zodra het OLE‑objectframe is benaderd, kunt u elke bewerking erop uitvoeren.  

In het voorbeeld hieronder wordt een OLE‑objectframe (een Excel‑diagramobject ingesloten in een dia) en de bestandsgegevens ervan benaderd.  

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Haal de gegevens van het ingesloten bestand op.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Haal de extensie van het ingesloten bestand op.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Eigenschappen van gelinkte OLE‑objectframes benaderen**

Aspose.Slides maakt het mogelijk de eigenschappen van gelinkte OLE‑objectframes te benaderen.  

Deze Java‑code toont hoe u kunt controleren of een OLE‑object gelinkt is en vervolgens het pad naar het gelinkte bestand verkrijgt:  

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
In dit gedeelte gebruikt het onderstaande code‑voorbeeld [Aspose.Cells for Android via Java](/cells/androidjava/).  
{{% /alert %}}  

Als een OLE‑object al is ingesloten in een dia, kunt u dat object eenvoudig benaderen en de gegevens ervan op de volgende manier aanpassen:  

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Benader de vorm van het OLE‑objectframe. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die één vorm op de eerste dia heeft. We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ioleobjectframe/). Dit was het gewenste OLE‑objectframe om te benaderen.  
4. Zodra het OLE‑objectframe is benaderd, kunt u elke bewerking erop uitvoeren.  
5. Maak een `Workbook`‑object aan en benader de OLE‑gegevens.  
6. Benader het gewenste `Worksheet` en pas de gegevens aan.  
7. Sla het bijgewerkte `Workbook` op in een stream.  
8. Wijzig de OLE‑objectgegevens vanuit de stream.  

In het voorbeeld hieronder wordt een OLE‑objectframe (een Excel‑diagramobject ingesloten in een dia) benaderd en worden de bestandsgegevens gewijzigd om de diagramgegevens bij te werken.  

```java 
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

Naast Excel‑diagrammen maakt Aspose.Slides for Android via Java het mogelijk andere soorten bestanden in dia's in te sluiten. U kunt bijvoorbeeld HTML, PDF en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het relevante programma, of krijgt de gebruiker de optie om een geschikt programma te selecteren.  

Deze Java‑code laat zien hoe u HTML en ZIP in een dia kunt insluiten:  

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Bestandstypen voor ingesloten objecten instellen**

Bij het werken met presentaties kan het nodig zijn oude OLE‑objecten te vervangen door nieuwe, of een niet‑ondersteund OLE‑object te vervangen door een ondersteund object. Aspose.Slides for Android via Java maakt het mogelijk het bestandstype voor een ingesloten object in te stellen, zodat u de OLE‑frame‑gegevens of de extensie kunt bijwerken.  

Deze Java‑code toont hoe u het bestandstype voor een ingesloten OLE‑object instelt op `zip`:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Wijzig het bestandstype naar ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Pictogrammen en titels instellen voor ingesloten objecten**

Na het insluiten van een OLE‑object wordt er automatisch een voorbeeld met een pictogramafbeelding toegevoegd. Dit voorbeeld is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als u een specifieke afbeelding en tekst als elementen in het voorbeeld wilt gebruiken, kunt u het pictogram en de titel instellen met Aspose.Slides for Android via Java.  

Deze Java‑code laat zien hoe u het pictogram en de titel voor een ingesloten object instelt:  

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Voeg een afbeelding toe aan de presentatiebronnen.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Voorkomen dat een OLE‑objectframe wordt geschaald of verplaatst**

Nadat u een gelinkt OLE‑object aan een presentatiedia hebt toegevoegd, kunt u bij het openen van de presentatie in PowerPoint een bericht zien waarin wordt gevraagd de koppelingen bij te werken. Het klikken op de knop “Update Links” kan de grootte en positie van het OLE‑objectframe wijzigen omdat PowerPoint de gegevens van het gelinkte OLE‑object bijwerkt en het voorbeeld ververst. Om te voorkomen dat PowerPoint vraagt de objectgegevens bij te werken, stelt u de `setUpdateAutomatic`‑methode van de [IOleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ioleobjectframe/) interface in op `false`:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ingesloten bestanden extraheren**

Aspose.Slides for Android via Java maakt het mogelijk bestanden die als OLE‑objecten in dia's zijn ingesloten, op de volgende manier te extraheren:  

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de OLE‑objecten bevat die u wilt extraheren.  
2. Loop door alle vormen in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/oleobjectframe) vormen.  
3. Benader de gegevens van ingesloten bestanden vanuit OLE‑objectframes en schrijf ze naar schijf.  

Deze Java‑code toont hoe u bestanden die in een dia als OLE‑objecten zijn ingesloten, kunt extraheren:  

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **FAQ**

### Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?
Wat zichtbaar is op de dia wordt gerenderd – het pictogram / de vervangende afbeelding (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig, stel uw eigen preview‑afbeelding in om te zorgen voor het verwachte uiterlijk in de geëxporteerde PDF.

### Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?
Vergrendel de vorm: Aspose.Slides biedt vergrendelingen op vormniveau. Dit is geen encryptie, maar voorkomt effectief accidentele bewerkingen en verplaatsingen.

### Waarom “springt” een gelinkt Excel‑object of verandert van grootte wanneer ik de presentatie open?
PowerPoint kan het voorbeeld van het gelinkte OLE vernieuwen. Voor een stabiel uiterlijk volgt u de praktijken uit de [Working Solution for Worksheet Resizing](/slides/nl/androidjava/working-solution-for-worksheet-resizing/) – pas het frame aan op het bereik, of schaal het bereik naar een vast frame en stel een passend vervangend beeld in.

### Worden relatieve paden voor gelinkte OLE‑objecten bewaard in het PPTX‑formaat?
In PPTX is informatie over “relatief pad” niet beschikbaar – alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid geeft u de voorkeur aan betrouwbare absolute paden/bereikbare URI’s of het insluiten.