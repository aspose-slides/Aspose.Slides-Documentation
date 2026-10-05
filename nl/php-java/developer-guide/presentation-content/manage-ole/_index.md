---
title: Beheer OLE in presentaties met PHP
linktitle: OLE beheren
type: docs
weight: 40
url: /nl/php-java/manage-ole/
keywords:
- OLE-object
- Objectkoppeling en insluiting
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
- PHP
- Aspose.Slides
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides for PHP via Java. Voeg OLE-inhoud in, werk het bij en exporteer het naadloos."
---
## **Introductie**

{{% alert color="info" title="Opmerking" %}}

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt om gegevens en objecten die in één applicatie zijn aangemaakt, in een andere applicatie te plaatsen via koppeling of insluiten. 

{{% /alert %}} 

Beschouw een grafiek die in MS Excel is aangemaakt. Die grafiek wordt vervolgens in een PowerPoint‑dia geplaatst. Die Excel‑grafiek wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan verschijnen als een pictogram. In dat geval wordt, wanneer u dubbelklikt op het pictogram, de grafiek geopend in de bijbehorende applicatie (Excel), of wordt u gevraagd een applicatie te kiezen om het object te openen of te bewerken.  
- Een OLE‑object kan de eigenlijke inhoud weergeven, zoals de inhoud van een grafiek. In dat geval wordt de grafiek geactiveerd in PowerPoint, laadt de grafiekinterface en kunt u de gegevens van de grafiek binnen PowerPoint aanpassen.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) maakt het mogelijk om OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **OLE‑objectframes toevoegen aan dia's**

Stel dat u al een grafiek in Microsoft Excel heeft aangemaakt en deze wilt insluiten in een dia als OLE‑objectframe met Aspose.Slides for PHP via Java, dan kan dat als volgt:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) klasse.  
1. Haal een referentie naar een dia op via de index.  
1. Lees het Excel‑bestand in als een byte‑array.  
1. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) toe aan de dia met de byte‑array en overige informatie over het OLE‑object.  
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een grafiek uit een Excel‑bestand toegevoegd aan een dia als OLE‑objectframe met Aspose.Slides for PHP via Java.  
**Opmerking** dat de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/)‑constructor een extensie van een in te sluiten object als tweede parameter accepteert. Deze extensie laat PowerPoint het bestandstype correct interpreteren en de juiste applicatie kiezen om dit OLE‑object te openen.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Gelinkte OLE‑objectframes toevoegen**

Aspose.Slides for PHP via Java maakt het mogelijk om een [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) toe te voegen zonder gegevens in te sluiten, maar alleen met een koppeling naar het bestand.

Deze PHP‑code laat zien hoe u een [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) met een gelinkte Excel‑file aan een dia kunt toevoegen:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Voeg een OLE-objectframe toe met een gelinkte Excel‑file.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Toegang tot OLE‑objectframes**

Als een OLE‑object al is ingesloten in een dia, kunt u het eenvoudig vinden of benaderen op deze manier:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) klasse te maken.  
2. Haal de referentie naar de dia op via de index.  
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑vorm. In ons voorbeeld gebruikten we de eerder gemaakte PPTX die slechts één vorm bevat op de eerste dia.  
4. Zodra het OLE‑objectframe is benaderd, kunt u elke bewerking erop uitvoeren.

In het onderstaande voorbeeld worden een OLE‑objectframe (een Excel‑grafiekobject ingesloten in een dia) en de bestandsgegevens ervan benaderd.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Haal de ingesloten bestandsgegevens op.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Haal de extensie van het ingesloten bestand op.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Eigenschappen van gelinkte OLE‑objectframe benaderen**

Aspose.Slides maakt het mogelijk om de eigenschappen van gelinkte OLE‑objectframes te benaderen.

Deze PHP‑code laat zien hoe u controleert of een OLE‑object gelinkt is en vervolgens het pad naar het gelinkte bestand opvraagt:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Controleer of het OLE object gelinkt is.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Druk het volledige pad naar het gelinkte bestand af.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Druk het relatieve pad naar het gelinkte bestand af indien aanwezig.
        // Alleen PPT presentaties kunnen het relatieve pad bevatten.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **OLE‑objectgegevens wijzigen**

{{% alert color="info" title="Opmerking" %}}

In dit gedeelte gebruikt het code‑voorbeeld hieronder [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/).

{{% /alert %}}

Als een OLE‑object al is ingesloten in een dia, kunt u dat object eenvoudig benaderen en de gegevens ervan wijzigen op deze manier:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) klasse te maken.  
2. Haal de referentie naar de dia op via de index.  
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑vorm. In ons voorbeeld gebruikten we de eerder gemaakte PPTX die één vorm heeft op de eerste dia.  
4. Zodra het OLE‑objectframe is benaderd, kunt u elke bewerking erop uitvoeren.  
5. Maak een `Workbook`‑object en benader de OLE‑gegevens.  
6. Benader het gewenste `Worksheet` en wijzig de gegevens.  
7. Sla het bijgewerkte `Workbook` op in een stream.  
8. Wijzig de OLE‑objectgegevens vanuit de stream.

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑grafiekobject ingesloten in een dia) benaderd, en worden de bestandsgegevens ervan aangepast om de grafiekgegevens bij te werken.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Lees de OLE-objectgegevens als een Workbook-object.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Pas de workbook-gegevens aan.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Wijzig de OLE-frame-objectgegevens.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Andere bestandstypen insluiten in dia's**

Naast Excel‑grafieken maakt Aspose.Slides for PHP via Java het mogelijk om andere soorten bestanden in dia's in te sluiten. U kunt bijvoorbeeld HTML‑, PDF‑ en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het bijbehorende programma, of wordt de gebruiker gevraagd een geschikt programma te selecteren.

Deze PHP‑code toont hoe u HTML en ZIP in een dia kunt insluiten:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Bestandstypen instellen voor ingesloten objecten**

Bij het werken met presentaties kan het nodig zijn oude OLE‑objecten te vervangen door nieuwe, of een niet‑ondersteund OLE‑object te vervangen door een ondersteund exemplaar. Aspose.Slides for PHP via Java maakt het mogelijk om het bestandstype voor een ingesloten object in te stellen, zodat u de OLE‑frame‑gegevens of extensie kunt bijwerken.

Deze PHP‑code laat zien hoe u het bestandstype voor een ingesloten OLE‑object instelt op `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Verander het bestandstype naar ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Pictogramafbeeldingen en titels instellen voor ingesloten objecten**

Na het insluiten van een OLE‑object wordt er automatisch een voorbeeld met een pictogramafbeelding toegevoegd. Dit voorbeeld is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als u een specifieke afbeelding en tekst wilt gebruiken als elementen in het voorbeeld, kunt u de pictogramafbeelding en titel instellen met Aspose.Slides for PHP via Java.

Deze PHP‑code laat zien hoe u de pictogramafbeelding en titel voor een ingesloten object instelt:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Voeg een afbeelding toe aan de presentatiemiddelen.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Voorkomen dat een OLE‑objectframe wordt vergroot en verplaatst**

Nadat u een gelinkt OLE‑object aan een presentatiedia heeft toegevoegd, kan PowerPoint bij het openen van de presentatie een bericht tonen dat vraagt om de koppelingen bij te werken. Het klikken op de knop “Update Links” kan de grootte en positie van het OLE‑objectframe wijzigen omdat PowerPoint de gegevens van het gelinkte OLE‑object actualiseert en het voorbeeld ververst. Om te voorkomen dat PowerPoint vraagt om de gegevens van het object bij te werken, roept u de [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic)‑methode van de [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑klasse aan met `false`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Ingesloten bestanden extraheren**

Aspose.Slides for PHP via Java maakt het mogelijk om de in dia's ingesloten bestanden als OLE‑objecten te extraheren op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑klasse die de OLE‑objecten bevat die u wilt extraheren.  
2. Doorloop alle vormen in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑vormen.  
3. Haal de gegevens van ingesloten bestanden uit de OLE‑objectframes en schrijf ze naar schijf.

Deze PHP‑code laat zien hoe u bestanden die in een dia zijn ingesloten als OLE‑objecten kunt extraheren:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **FAQ**

**Wordt de OLE‑inhoud gerenderd wanneer dia's worden geëxporteerd naar PDF/afbeeldingen?**

Wat zichtbaar is op de dia wordt gerenderd – het pictogram/substituut‑beeld (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig, stel uw eigen preview‑afbeelding in om de verwachte weergave in de geëxporteerde PDF te garanderen.

Om het ingesloten bestand ook als PDF‑bijlage te behouden, roept u [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) aan met `true`. Deze optie staat standaard uit. Voor een voorbeeld en instructies om de bijlage te controleren, zie [Preserve Embedded OLE Files as PDF Attachments](/slides/nl/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de vorm: Aspose.Slides biedt vergrendelingen op vormniveau. Dit is geen encryptie, maar voorkomt effectief accidentele bewerkingen en verplaatsingen.

**Worden relatieve paden voor gelinkte OLE‑objecten bewaard in het PPTX‑formaat?**

In PPTX‑bestanden is “relatieve pad”‑informatie niet beschikbaar – alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid heeft u beter betrouwbare absolute paden/toegankelijke URI’s of insluiting.