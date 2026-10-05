---
title: OLE beheren in presentaties op Android
linktitle: OLE beheren
type: docs
weight: 40
url: /nl/androidjava/manage-ole/
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
- OLE pictogram
- OLE titel
- OLE extraheren
- object extraheren
- bestand extraheren
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Optimaliseer het beheer van OLE‑objecten in PowerPoint‑ en OpenDocument‑bestanden met Aspose.Slides voor Android via Java. Sluit OLE‑inhoud in, werk deze bij en exporteer moeiteloos."
---
## **Inleiding**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt om gegevens en objecten die in de ene applicatie zijn gemaakt, in een andere applicatie te plaatsen via koppeling of insluiting. 

{{% /alert %}} 

Stel je een diagram voor dat in MS Excel is gemaakt. Het diagram wordt vervolgens in een PowerPoint‑dia geplaatst. Dat Excel‑diagram wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan verschijnen als een pictogram. In dat geval wordt, wanneer je dubbelklikt op het pictogram, het diagram geopend in de gekoppelde applicatie (Excel), of wordt je gevraagd een applicatie te selecteren om het object te openen of te bewerken.  
- Een OLE‑object kan de eigenlijke inhoud tonen, bijvoorbeeld de inhoud van een diagram. In dat geval wordt het diagram geactiveerd in PowerPoint, laadt de diagraminterface en kun je de diagramgegevens binnen PowerPoint wijzigen.

[Aspose.Slides voor Android via Java](https://products.aspose.com/slides/androidjava/) maakt het mogelijk om OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **OLE‑objectframes toevoegen aan dia's**

Aangenomen dat je al een diagram in Microsoft Excel hebt gemaakt en dit wilt insluiten in een dia als een OLE‑objectframe met Aspose.Slides voor Android via Java, kun je het als volgt doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑klasse.  
1. Haal de referentie naar een dia op via de index.  
1. Lees het Excel‑bestand in als een byte‑array.  
1. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) toe aan de dia met de byte‑array en aanvullende informatie over het OLE‑object.  
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een diagram uit een Excel‑bestand toegevoegd aan een dia als een OLE‑objectframe met Aspose.Slides voor Android via Java.  
**Opmerking** dat de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo)‑constructor een extensie van het in te voegen object als tweede parameter neemt. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste applicatie te kiezen om dit OLE‑object te openen.

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

// Voorbereiden van gegevens voor het OLE-object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Voeg het OLE-objectframe toe aan de dia.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Koppeling OLE‑objectframes toevoegen**

Aspose.Slides voor Android via Java maakt het mogelijk om een [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) toe te voegen zonder gegevens in te sluiten, maar alleen met een koppeling naar het bestand.

Deze Java‑code laat zien hoe je een [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) met een gekoppeld Excel‑bestand toevoegt aan een dia:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Voeg een OLE objectframe toe met een gekoppeld Excel-bestand.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE‑objectframes benaderen**

Als een OLE‑object al in een dia is ingesloten, kun je het als volgt eenvoudig vinden of benaderen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)‑shape. In ons voorbeeld gebruikten we de eerder gemaakte PPTX die slechts één shape heeft op de eerste dia. We casten dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Dit was het gewenste OLE‑objectframe dat benaderd moest worden.  
4. Zodra het OLE‑objectframe is benaderd, kun je er willekeurige bewerkingen op uitvoeren.

In het onderstaande voorbeeld worden een OLE‑objectframe (een Excel‑diagram ingesloten in een dia) en de bestandsgegevens ervan benaderd.

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Haal de gegevens van het ingebedde bestand op.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Haal de extensie van het ingebedde bestand op.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Eigenschappen van gekoppeld OLE‑objectframe benaderen**

Aspose.Slides maakt het mogelijk om eigenschappen van gekoppelde OLE‑objectframes te benaderen.

Deze Java‑code toont hoe je controleert of een OLE‑object gekoppeld is en vervolgens het pad naar het gekoppelde bestand opvraagt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Controleer of het OLE-object gekoppeld is.
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

In dit gedeelte gebruikt het codevoorbeeld hieronder [Aspose.Cells voor Android via Java](https://docs.aspose.com/cells/androidjava/).

{{% /alert %}}

Als een OLE‑object al in een dia is ingesloten, kun je dit object eenvoudig benaderen en de gegevens ervan wijzigen als volgt:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑klasse te maken.  
2. Haal de referentie naar de dia op via de index.  
3. Benader de OLE‑objectframe‑shape. In ons voorbeeld gebruikten we de eerder gemaakte PPTX die één shape heeft op de eerste dia. We casten dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Dit was het gewenste OLE‑objectframe dat benaderd moest worden.  
4. Zodra het OLE‑objectframe is benaderd, kun je er willekeurige bewerkingen op uitvoeren.  
5. Maak een `Workbook`‑object aan en benader de OLE‑gegevens.  
6. Benader het gewenste `Worksheet` en wijzig de gegevens.  
7. Sla het bijgewerkte `Workbook` op in een stream.  
8. Wijzig de OLE‑objectgegevens vanuit de stream.

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑diagram ingesloten in een dia) benaderd en worden de bestandsgegevens ervan aangepast om de diagramgegevens bij te werken.

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

## **Andere bestandstypen insluiten in dia's**

Naast Excel‑diagrammen maakt Aspose.Slides voor Android via Java het mogelijk om andere soorten bestanden in dia's in te sluiten. Je kunt bijvoorbeeld HTML-, PDF- en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het relevante programma, of er wordt gevraagd een passend programma te selecteren.

Deze Java‑code laat zien hoe je HTML en ZIP in een dia insluit:

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

Bij het werken met presentaties moet je soms oude OLE‑objecten vervangen door nieuwe of een niet‑ondersteund OLE‑object vervangen door een ondersteund exemplaar. Aspose.Slides voor Android via Java maakt het mogelijk om het bestandstype voor een ingesloten object in te stellen, waardoor je de OLE‑frame‑gegevens of de extensie kunt bijwerken.

Deze Java‑code toont hoe je het bestandstype voor een ingesloten OLE‑object instelt op `zip`:

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

## **Pictogramafbeeldingen en titels voor ingesloten objecten instellen**

Na het insluiten van een OLE‑object wordt er automatisch een voorbeeld met een pictogramafbeelding toegevoegd. Dit voorbeeld is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als je een specifieke afbeelding en tekst wilt gebruiken als elementen in het voorbeeld, kun je met Aspose.Slides voor Android via Java het pictogram en de titel instellen.

Deze Java‑code laat zien hoe je de pictogramafbeelding en titel voor een ingesloten object instelt:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Voeg een afbeelding toe aan de presentatieresources.
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

## **Voorkomen dat een OLE‑objectframe van grootte verandert of wordt verplaatst**

Nadat je een gekoppeld OLE‑object aan een presentatiedia hebt toegevoegd, kun je bij het openen van de presentatie in PowerPoint een bericht zien waarin wordt gevraagd de koppelingen bij te werken. Het klikken op de knop **Update Links** kan de grootte en positie van het OLE‑objectframe wijzigen omdat PowerPoint de gegevens van het gekoppelde OLE‑object bijwerkt en het voorbeeld ververst. Om te voorkomen dat PowerPoint vraagt de objectgegevens bij te werken, roep je de [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-)‑methode van de [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/)‑interface aan met `false`:

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

Aspose.Slides voor Android via Java maakt het mogelijk om de in dia's als OLE‑objecten ingesloten bestanden als volgt te extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑klasse die de OLE‑objecten bevat die je wilt extraheren.  
2. Doorloop alle shapes in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe)‑shapes.  
3. Benader de gegevens van ingesloten bestanden vanuit OLE‑objectframes en schrijf ze naar schijf.

Deze Java‑code laat zien hoe je bestanden die in een dia als OLE‑objecten zijn ingesloten, extraheert:

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

**Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?**

Wat op de dia zichtbaar is, wordt gerenderd — het pictogram/substituut‑beeld (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien gewenst, stel je een eigen preview‑afbeelding in om het verwachte uiterlijk in de geëxporteerde PDF te garanderen.

Om het ingesloten bestand tevens als een PDF‑bijlage te behouden, roep je [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) aan met `true`. Deze optie is standaard uitgeschakeld. Zie voor een voorbeeld en instructies voor het controleren van de bijlage [Preserve Embedded OLE Files as PDF Attachments](/slides/nl/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de shape: Aspose.Slides biedt shape‑niveau vergrendelingen. Dit is geen encryptie, maar voorkomt effectief accidentele bewerkingen en verplaatsingen.

**Waarom “springt” of verandert een gekoppeld Excel‑object van grootte wanneer ik de presentatie open?**

PowerPoint kan het preview‑beeld van het gekoppelde OLE vernieuwen. Voor een stabiel uiterlijk kun je de richtlijnen volgen in de [Working Solution for Worksheet Resizing](/slides/nl/androidjava/working-solution-for-worksheet-resizing/): of het frame aanpassen aan het bereik, of het bereik schalen naar een vast frame en een passend substituut‑beeld instellen.

**Blijven relatieve paden voor gekoppelde OLE‑objecten behouden in het PPTX‑formaat?**

In PPTX is informatie over “relatieve paden” niet beschikbaar — alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid kun je beter betrouwbare absolute paden/URI’s gebruiken of insluiten.