---
title: OLE beheren in presentaties met Java
linktitle: OLE beheren
type: docs
weight: 40
url: /nl/java/manage-ole/
keywords:
- OLE-object
- Objectkoppeling & insluiting
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
- Java
- Aspose.Slides
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor Java. OLE-inhoud insluiten, bijwerken en naadloos exporteren."
---
## **Inleiding**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één toepassing zijn gemaakt, in een andere toepassing te plaatsen via koppelen of insluiten. 

{{% /alert %}} 

Beschouw een diagram dat is gemaakt in MS Excel. Het diagram wordt vervolgens in een PowerPoint‑dia geplaatst. Dat Excel‑diagram wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan verschijnen als een pictogram. In dat geval wordt, wanneer u dubbelklikt op het pictogram, het diagram geopend in de bijbehorende toepassing (Excel), of wordt u gevraagd een toepassing te selecteren om het object te openen of te bewerken.
- Een OLE‑object kan de eigenlijke inhoud weergeven, zoals de inhoud van een diagram. In dat geval wordt het diagram geactiveerd in PowerPoint, laadt de diagram‑interface en kunt u de gegevens van het diagram binnen PowerPoint wijzigen.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) maakt het mogelijk OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **OLE‑objectframes aan dia's toevoegen**

Stel dat u al een diagram in Microsoft Excel heeft gemaakt en dit wilt insluiten in een dia als OLE‑objectframe met Aspose.Slides for Java, dan kunt u dit als volgt doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) klasse.
1. Verkrijg een referentie naar de dia via de index.
1. Lees het Excel‑bestand in als een byte‑array.
1. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) toe aan de dia met de byte‑array en overige informatie over het OLE‑object.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het voorbeeld hieronder hebben we een diagram uit een Excel‑bestand aan een dia toegevoegd als OLE‑objectframe met Aspose.Slides for Java.
**Opmerking** dat de constructor van [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) een extensie van het in te sluiten object als tweede parameter ontvangt. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste toepassing te kiezen om dit OLE‑object te openen.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Gelinkte OLE‑objectframes toevoegen**

Aspose.Slides for Java maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) toe te voegen zonder gegevens in te sluiten, maar alleen met een koppeling naar het bestand.

Deze Java‑code laat zien hoe u een [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) met een gekoppeld Excel‑bestand aan een dia kunt toevoegen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Voeg een OLE‑objectframe toe met een gekoppeld Excel‑bestand.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Toegang tot OLE‑objectframes**

Als een OLE‑object al in een dia is ingesloten, kunt u het op de volgende manier eenvoudig vinden of benaderen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) klasse te maken.
2. Verkrijg de referentie van de dia met behulp van de index.
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) shape.  
   In ons voorbeeld gebruiken we de eerder gemaakte PPTX die slechts één shape bevat op de eerste dia. Vervolgens *casten* we dat object naar een [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Dit was het gewenste OLE‑objectframe om te benaderen.
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.

In het voorbeeld hieronder wordt een OLE‑objectframe (een Excel‑diagramobject ingesloten in een dia) en de bestandsgegevens ervan benaderd.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Haal de ingesloten bestandsgegevens op.
    // Haal de extensie van het ingesloten bestand op.
    // ...
}
```

### **Eigenschappen van gelinkte OLE‑objectframes benaderen**

Aspose.Slides maakt het mogelijk de eigenschappen van gelinkte OLE‑objectframes te benaderen.

Deze Java‑code laat zien hoe u controleert of een OLE‑object gelinkt is en vervolgens het pad naar het gelinkte bestand verkrijgt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Controleer of het OLE-object gelinkt is.
    if (oleFrame.isObjectLink()) {
        // Print het volledige pad naar het gekoppelde bestand.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Print het relatieve pad naar het gekoppelde bestand indien aanwezig.
        // Alleen PPT-presentaties kunnen het relatieve pad bevatten.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE‑objectgegevens wijzigen**

{{% alert color="info" title="Note" %}}

In dit gedeelte wordt de code‑voorbeeld hieronder gebruikt met [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Als een OLE‑object al in een dia is ingesloten, kunt u dat object eenvoudig benaderen en de gegevens ervan op de volgende manier wijzigen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) klasse te maken.
2. Verkrijg de referentie van de dia via de index. 
3. Benader de OLE‑objectframe‑shape.  
   In ons voorbeeld gebruiken we de eerder gemaakte PPTX die één shape bevat op de eerste dia. Vervolgens *casten* we dat object naar een [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Dit was het gewenste OLE‑objectframe om te benaderen.
4. Zodra het OLE‑objectframe is benaderd, kunt u elke bewerking uitvoeren.
5. Maak een `Workbook`‑object aan en benader de OLE‑gegevens.
6. Benader het gewenste `Worksheet` en pas de gegevens aan.
7. Sla de bijgewerkte `Workbook` op in een stream.
8. Wijzig de OLE‑objectgegevens vanuit de stream.

In het voorbeeld hieronder wordt een OLE‑objectframe (een Excel‑diagramobject ingesloten in een dia) benaderd en worden de bestandsgegevens gewijzigd om de diagramgegevens bij te werken.

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

    // Lees de OLE-objectgegevens als een Workbook-object.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Wijzig de werkboekgegevens.
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

Naast Excel‑diagrammen maakt Aspose.Slides for Java het mogelijk andere bestandstypen in dia's in te sluiten. U kunt bijvoorbeeld HTML‑, PDF‑ en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker op het ingevoegde object dubbelklikt, wordt het automatisch geopend in het bijbehorende programma, of krijgt de gebruiker de vraag welk programma moet worden gebruikt.

Deze Java‑code laat zien hoe u HTML en ZIP in een dia kunt insluiten:

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

## **Bestandstypen instellen voor ingesloten objecten**

Tijdens het werken met presentaties kan het nodig zijn oude OLE‑objecten te vervangen door nieuwe of een niet‑ondersteund OLE‑object te vervangen door een ondersteund object. Aspose.Slides for Java maakt het mogelijk het bestandstype voor een ingesloten object in te stellen, waardoor u de OLE‑frame‑gegevens of de extensie kunt bijwerken.

Deze Java‑code laat zien hoe u het bestandstype voor een ingesloten OLE‑object instelt op `zip`:

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

## **Pictogramafbeeldingen en titels instellen voor ingesloten objecten**

Na het insluiten van een OLE‑object wordt er automatisch een voorbeeld met een pictogramafbeelding toegevoegd. Dit voorbeeld is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als u een specifieke afbeelding en tekst als elementen in het voorbeeld wilt gebruiken, kunt u de pictogramafbeelding en titel instellen met Aspose.Slides for Java.

Deze Java‑code laat zien hoe u de pictogramafbeelding en titel voor een ingesloten object instelt:

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

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Voorkom dat een OLE‑objectframe wordt geschaald en verplaatst**

Nadat u een gelinkt OLE‑object aan een presentatiedia heeft toegevoegd, kunt u bij het openen van de presentatie in PowerPoint een bericht zien dat vraagt de koppelingen bij te werken. Als u op de knop “Update Links” klikt, kan dit de grootte en positie van het OLE‑objectframe wijzigen omdat PowerPoint de gegevens van het gelinkte OLE‑object bijwerkt en het voorbeeld ververst. Om te voorkomen dat PowerPoint vraagt de gegevens van het object bij te werken, roept u de [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-)‑methode van de [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) interface aan met `false`:

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

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑klasse die de OLE‑objecten bevat die u wilt extraheren.
2. Doorloop alle shapes in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe)‑shapes.
3. Benader de gegevens van ingesloten bestanden uit OLE‑objectframes en schrijf ze naar schijf.

Deze Java‑code laat zien hoe u bestanden die in een dia zijn ingesloten als OLE‑objecten kunt extraheren:

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

**Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?**

Wat zichtbaar is op de dia wordt gerenderd – het pictogram/vervangings‑beeld (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig, stel uw eigen preview‑afbeelding in om het verwachte uiterlijk in de geëxporteerde PDF te garanderen.

Om tevens het ingesloten bestand als PDF‑bijlage te behouden, roept u [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) aan met `true`. Deze optie is standaard uitgeschakeld. Voor een voorbeeld en instructies om de bijlage te controleren, zie [Preserve Embedded OLE Files as PDF Attachments](/slides/nl/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de shape: Aspose.Slides biedt [shape-level locks](/slides/nl/java/applying-protection-to-presentation/). Dit is geen encryptie, maar voorkomt effectief onbedoelde bewerkingen en verplaatsingen.

**Waarom “springt” een gekoppeld Excel‑object of verandert van grootte wanneer ik de presentatie open?**

PowerPoint kan het preview‑beeld van het gekoppelde OLE‑object vernieuwen. Voor een stabiel uiterlijk volgt u de praktijken beschreven in de [Working Solution for Worksheet Resizing](/slides/nl/java/working-solution-for-worksheet-resizing/) – ofwel het frame aanpassen aan het bereik, of het bereik schalen naar een vast frame en een passend vervangings‑beeld instellen.

**Worden relatieve paden voor gekoppelde OLE‑objecten behouden in het PPTX‑formaat?**

In PPTX is informatie over “relatieve paden” niet beschikbaar – alleen het volledige pad. Relatieve paden bestaan alleen in het oudere PPT‑formaat. Voor draagbaarheid geeft u de voorkeur aan betrouwbare absolute paden/toegankelijke URI’s of insluiting.