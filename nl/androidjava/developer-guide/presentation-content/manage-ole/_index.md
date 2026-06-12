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
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor Android via Java. Voeg OLE-inhoud in, werk deze bij en exporteer deze moeiteloos."
---
## **Inleiding**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één applicatie zijn gemaakt, via koppeling of insluiting in een andere applicatie te plaatsen. 

{{% /alert %}} 

Stel een diagram voor dat in MS Excel is gemaakt. Het diagram wordt vervolgens in een PowerPoint‑dia geplaatst. Dat Excel‑diagram wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan verschijnen als een pictogram. In dat geval wordt, wanneer u dubbelklikt op het pictogram, het diagram geopend in de bijbehorende applicatie (Excel), of wordt u gevraagd een applicatie te kiezen voor het openen of bewerken van het object. 
- Een OLE‑object kan de eigenlijke inhoud tonen, bijvoorbeeld de inhoud van een diagram. In dat geval wordt het diagram geactiveerd in PowerPoint, laadt de diagram‑interface, en kunt u de gegevens van het diagram binnen PowerPoint aanpassen. 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/nl/androidjava/) stelt u in staat OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OleObjectFrame)).

## **OLE‑objectframes toevoegen aan dia's**

Aangenomen dat u al een diagram in Microsoft Excel hebt gemaakt en het wilt insluiten in een dia als een OLE‑objectframe met Aspose.Slides for Android via Java, kunt u dit op de volgende manier doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal via de index een referentie naar een dia op.  
3. Lees het Excel‑bestand in als een byte‑array.  
4. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OleObjectFrame) toe aan de dia, met de byte‑array en overige informatie over het OLE‑object.  
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

In het onderstaande voorbeeld hebben we een diagram uit een Excel‑bestand aan een dia toegevoegd als een OLE‑objectframe met Aspose.Slides for Android via Java.  
**Opmerking**: de constructor van [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OleEmbeddedDataInfo) neemt als tweede parameter een extensie van het in te sluiten object. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste applicatie te kiezen om dit OLE‑object te openen.

```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Bereid gegevens voor het OLE-object voor.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Voeg het OLE-objectframe toe aan de dia.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Gelinkte OLE‑objectframes toevoegen**

Aspose.Slides for Android via Java maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OleObjectFrame) toe te voegen zonder data in te sluiten, maar alleen met een koppeling naar het bestand.

Deze Java‑code laat zien hoe u een [OleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OleObjectFrame) met een gelinkt Excel‑bestand aan een dia kunt toevoegen:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Voeg een OLE-objectframe toe met een gelinkt Excel-bestand.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE‑objectframes benaderen**

Als er al een OLE‑object in een dia is ingesloten, kunt u het op de volgende manier gemakkelijk vinden of benaderen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OleObjectFrame)‑vorm. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die slechts één vorm op de eerste dia bevat.  Vervolgens *casten* we dat object naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ioleobjectframe/). Dit was het gewenste OLE‑objectframe om te benaderen.  
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke gewenste bewerking op uitvoeren.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een ingesloten Excel‑diagramobject in een dia) en de bijbehorende bestandsdata benaderd.

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Haal de ingesloten bestandsgegevens op.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Haal de extensie van het ingesloten bestand op.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Eigenschappen van gelinkte OLE‑objectframes benaderen**

Aspose.Slides stelt u in staat de eigenschappen van gelinkte OLE‑objectframes te benaderen.

Deze Java‑code toont hoe u kunt controleren of een OLE‑object gelinkt is en vervolgens het pad naar het gelinkte bestand kunt ophalen:

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

## **OLE‑objectdata wijzigen**

{{% alert color="primary" %}} 

In dit gedeelte maakt het onderstaande code‑voorbeeld gebruik van [Aspose.Cells for Android via Java](/cells/androidjava/).

{{% /alert %}}

Als er al een OLE‑object in een dia is ingesloten, kunt u het object benaderen en de gegevens als volgt wijzigen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Benader de OLE‑objectframe‑vorm. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die één vorm op de eerste dia bevat. We casten dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ioleobjectframe/). Dit was het gewenste OLE‑objectframe om te benaderen.  
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke gewenste bewerking op uitvoeren.  
5. Maak een `Workbook`‑object aan en krijg toegang tot de OLE‑data.  
6. Benader het gewenste `Worksheet` en pas de data aan.  
7. Sla het bijgewerkte `Workbook` op in een stream.  
8. Wijzig de OLE‑objectdata vanuit de stream.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een ingesloten Excel‑diagramobject in een dia) benaderd, en wordt de bestandsdata aangepast om de diagramdata bij te werken.

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Lees de OLE-objectdata als een Workbook-object.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Wijzig de workbook-gegevens.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Wijzig de OLE-frame-objectdata.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Andere bestandstypen insluiten in dia's**

Naast Excel‑diagrammen maakt Aspose.Slides for Android via Java het mogelijk andere bestandstypen in dia's in te sluiten. U kunt bijvoorbeeld HTML-, PDF- en ZIP-bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het bijbehorende programma, of krijgt de gebruiker de opdracht een geschikt programma te kiezen om het te openen.

Deze Java‑code laat zien hoe u HTML en ZIP in een dia kunt insluiten:

```java
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

Bij het werken met presentaties moet u mogelijk oude OLE‑objecten vervangen door nieuwe, of een niet‑ondersteund OLE‑object vervangen door een ondersteund. Aspose.Slides for Android via Java maakt het mogelijk het bestandstype voor een ingesloten object in te stellen, waardoor u de OLE‑framedata of de extensie kunt bijwerken.

Deze Java‑code toont hoe u het bestandstype voor een ingesloten OLE‑object op `zip` instelt:

```java
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

Na het insluiten van een OLE‑object wordt er automatisch een preview toegevoegd die bestaat uit een pictogramafbeelding. Deze preview is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als u een specifieke afbeelding en tekst als elementen in de preview wilt gebruiken, kunt u met Aspose.Slides for Android via Java het pictogram en de titel instellen.

Deze Java‑code laat zien hoe u de pictogramafbeelding en titel voor een ingesloten object kunt instellen:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Voeg een afbeelding toe aan de presentatie‑resources.
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

## **Voorkomen dat een OLE‑objectframe wordt aangepast in grootte en positie**

Nadat u een gelinkt OLE‑object aan een presentatiedia hebt toegevoegd, kunt u bij het openen van de presentatie in PowerPoint een bericht zien dat vraagt de koppelingen bij te werken. Klikken op de knop "Update Links" kan de grootte en positie van het OLE‑objectframe wijzigen omdat PowerPoint de gegevens van het gelinkte OLE‑object bijwerkt en de preview ververst. Om te voorkomen dat PowerPoint vraagt de gegevens van het object bij te werken, stelt u de `setUpdateAutomatic`‑methode van de [IOleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ioleobjectframe/)‑interface in op `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Ingesloten bestanden extraheren**

Aspose.Slides for Android via Java maakt het mogelijk de in dia's ingesloten bestanden als OLE‑objecten op de volgende manier te extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse die de OLE‑objecten bevat die u wilt extraheren.  
2. Loop door alle vormen in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/oleobjectframe)‑vormen.  
3. Benader de data van ingesloten bestanden uit OLE‑objectframes en schrijf deze naar schijf.  

Deze Java‑code toont hoe u bestanden die in een dia zijn ingesloten als OLE‑objecten kunt extraheren:

```java
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

**Wordt de OLE‑content gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?**

Wat zichtbaar is op de dia wordt gerenderd — het pictogram/vervangende beeld (preview). De "live" OLE‑content wordt niet uitgevoerd tijdens het renderen. Indien nodig kunt u uw eigen preview‑afbeelding instellen om de verwachte weergave in de geëxporteerde PDF te garanderen.

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de vorm: Aspose.Slides biedt vergrendeling op vormniveau. Dit is geen encryptie, maar het voorkomt effectief onbedoelde bewerkingen en verplaatsing.

**Waarom "springt" een gelinkt Excel‑object of verandert van grootte wanneer ik de presentatie open?**

PowerPoint kan de preview van het gelinkte OLE vernieuwen. Voor een stabiele weergave kunt u de richtlijnen van de [Working Solution for Worksheet Resizing](/slides/nl/androidjava/working-solution-for-worksheet-resizing/) volgen — pas het frame aan op het bereik, of schaal het bereik naar een vast frame en stel een geschikt vervangend beeld in.

**Worden relatieve paden voor gelinkte OLE‑objecten bewaard in het PPTX‑formaat?**

In PPTX is informatie over "relatieve paden" niet beschikbaar — alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid geven we de voorkeur aan betrouwbare absolute paden/toegankelijke URI’s of insluiting.