---
title: Beheer OLE in presentaties met PHP
linktitle: Beheer OLE
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
- PHP
- Aspose.Slides
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides for PHP via Java. Sluit OLE-inhoud in, werk deze bij en exporteer naadloos."
---
## **Introductie**

{{% alert color="primary" %}} 
OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één toepassing zijn gemaakt, in een andere toepassing te plaatsen via koppeling of insluiting. 
{{% /alert %}} 

Stel je een grafiek voor die gemaakt is in MS Excel. De grafiek wordt vervolgens geplaatst in een PowerPoint‑dia. Die Excel‑grafiek wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan als een pictogram verschijnen. In dat geval wordt de grafiek, wanneer je dubbelklikt op het pictogram, geopend in de bijbehorende toepassing (Excel), of wordt je gevraagd een toepassing te selecteren om het object te openen of te bewerken. 
- Een OLE‑object kan de eigenlijke inhoud tonen, zoals de inhoud van een grafiek. In dat geval wordt de grafiek geactiveerd in PowerPoint, laadt de grafiekinterface, en kun je de gegevens van de grafiek bewerken binnen PowerPoint.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/nl/php-java/) maakt het mogelijk OLE Objects in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/)).

## **OLE‑objectframes aan dia's toevoegen**

Stel dat je al een grafiek in Microsoft Excel hebt gemaakt en deze wilt insluiten in een dia als OLE‑objectframe met Aspose.Slides for PHP via Java, dan kun je dat als volgt doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.  
2. Haal de referentie van een dia op via de index.  
3. Lees het Excel‑bestand in als een byte‑array.  
4. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.  
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

In het voorbeeld hieronder hebben we een grafiek uit een Excel‑bestand aan een dia toegevoegd als OLE‑objectframe met Aspose.Slides for PHP via Java.  
**Opmerking** dat de constructor van [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleembeddeddatainfo/) een uitbreidbare object‑extensie als tweede parameter accepteert. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste toepassing te kiezen om dit OLE‑object te openen.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Bereid gegevens voor het OLE-object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Voeg het OLE-objectframe toe aan de dia.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Gekoppelde OLE‑objectframes toevoegen**

Aspose.Slides for PHP via Java maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/) toe te voegen zonder data in te sluiten, maar alleen met een koppeling naar het bestand.

Deze PHP‑code laat zien hoe je een [OleObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/) met een gekoppeld Excel‑bestand aan een dia kunt toevoegen:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Voeg een OLE-objectframe toe met een gekoppeld Excel-bestand.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Toegang tot OLE‑objectframes**

Als een OLE‑object al is ingevoegd in een dia, kun je het op deze manier gemakkelijk vinden of benaderen:

1. Laad een presentatie met het ingevoegde OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse te maken.  
2. Haal de referentie van de dia op met behulp van de index.  
3. Benader de vorm [OleObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/). In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die slechts één vorm op de eerste dia bevat.  
4. Zodra het OLE‑objectframe benaderd is, kun je er elke bewerking op uitvoeren.  

In het voorbeeld hieronder wordt een OLE‑objectframe (een Excel‑grafiekobject dat in een dia is ingevoegd) en de bestandsgegevens ervan benaderd.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Haal de gegevens van het ingesloten bestand op.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Haal de extensie van het ingesloten bestand op.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Eigenschappen van gekoppeld OLE‑objectframe benaderen**

Aspose.Slides maakt het mogelijk de eigenschappen van gekoppelde OLE‑objectframes te benaderen.

Deze PHP‑code laat zien hoe je kunt controleren of een OLE‑object is gekoppeld en vervolgens het pad naar het gekoppelde bestand kunt ophalen:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Controleer of het OLE-object gekoppeld is.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Print het volledige pad naar het gekoppelde bestand.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Print het relatieve pad naar het gekoppelde bestand indien aanwezig.
        // Alleen PPT-presentaties kunnen het relatieve pad bevatten.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **OLE‑objectgegevens wijzigen**

{{% alert color="primary" %}} 
In deze sectie gebruikt het code‑voorbeeld hieronder [Aspose.Cells for PHP via Java](/cells/php-java/).  
{{% /alert %}}

Als een OLE‑object al in een dia is ingevoegd, kun je dat object eenvoudig benaderen en de gegevens ervan op deze manier wijzigen:

1. Laad een presentatie met het ingevoegde OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Benader de vorm [OleObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/). In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die één vorm op de eerste dia heeft.  
4. Zodra het OLE‑objectframe benaderd is, kun je er elke bewerking op uitvoeren.  
5. Maak een `Workbook`‑object aan en krijg toegang tot de OLE‑gegevens.  
6. Benader het gewenste `Worksheet` en wijzig de gegevens.  
7. Sla het bijgewerkte `Workbook` op in een stream.  
8. Wijzig de OLE‑objectgegevens vanuit de stream.  

In het voorbeeld hieronder wordt een OLE‑objectframe (een Excel‑grafiekobject dat in een dia is ingevoegd) benaderd, en worden de bestandsgegevens aangepast om de grafiekgegevens bij te werken.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

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

    // Verander de OLE-frame objectgegevens.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Andere bestandstypen in dia's insluiten**

Naast Excel‑grafieken maakt Aspose.Slides for PHP via Java het mogelijk andere bestandstypen in dia's in te sluiten. Je kunt bijvoorbeeld HTML-, PDF- en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het bijbehorende programma, of wordt de gebruiker gevraagd een geschikt programma te selecteren om het te openen.

Deze PHP‑code toont hoe je HTML en ZIP in een dia kunt insluiten:

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

## **Bestandstypen voor ingevoegde objecten instellen**

Wanneer je met presentaties werkt, moet je mogelijk oude OLE‑objecten vervangen door nieuwe, of een niet‑ondersteund OLE‑object vervangen door een ondersteund object. Aspose.Slides for PHP via Java maakt het mogelijk het bestandstype voor een ingevoegd object in te stellen, zodat je de OLE‑framedata of de extensie kunt bijwerken.

Deze PHP‑code laat zien hoe je het bestandstype voor een ingevoegd OLE‑object instelt op `zip`:

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

## **Pictogramafbeeldingen en titels voor ingevoegde objecten instellen**

Na het insluiten van een OLE‑object wordt automatisch een voorbeeld consisting of een pictogramafbeelding toegevoegd. Deze preview is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als je een specifieke afbeelding en tekst als elementen in de preview wilt gebruiken, kun je de pictogramafbeelding en titel instellen met Aspose.Slides for PHP via Java.

Deze PHP‑code laat zien hoe je de pictogramafbeelding en titel voor een ingevoegd object instelt:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Voeg een afbeelding toe aan de presentatieresources.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Stel een titel en de afbeelding in voor de OLE-preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Voorkom dat een OLE‑objectframe wordt vergroot/verkleind en verplaatst**

Na het toevoegen van een gekoppeld OLE‑object aan een presentatiedia, kun je bij het openen van de presentatie in PowerPoint een bericht zien dat vraagt de koppelingen bij te werken. Als je op de knop “Update Links” klikt, kan de grootte en positie van het OLE‑objectframe veranderen omdat PowerPoint de gegevens van het gekoppelde OLE‑object bijwerkt en de preview ververst. Om te voorkomen dat PowerPoint vraagt de gegevens van het object bij te werken, stel je de `setUpdateAutomatic`‑methode van de [OleObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/)‑klasse in op `false`:

```php
$oleFrame->setUpdateAutomatic(false);
```

## **Ingevoegde bestanden extraheren**

Aspose.Slides for PHP via Java maakt het mogelijk om de in dia's ingevoegde bestanden als OLE‑objecten op deze manier te extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse die de OLE‑objecten bevat die je wilt extraheren.  
2. Loop door alle vormen in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/)‑vormen.  
3. Benader de gegevens van de ingevoegde bestanden uit OLE‑objectframes en schrijf ze naar schijf.  

Deze PHP‑code toont hoe je bestanden die in een dia als OLE‑objecten zijn ingevoegd kunt extraheren:

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

**Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?**

Wat zichtbaar is op de dia wordt gerenderd – het pictogram/substituut‑beeld (preview). De "live" OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig kun je een eigen preview‑afbeelding instellen om de verwachte weergave in de geëxporteerde PDF te waarborgen.

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de vorm: Aspose.Slides biedt vergrendelingen op vormniveau. Dit is geen encryptie, maar voorkomt effectief accidentele bewerkingen en verplaatsingen.

**Worden relatieve paden voor gekoppelde OLE‑objecten behouden in het PPTX‑formaat?**

In PPTX is informatie over "relatieve paden" niet beschikbaar – alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid kun je beter betrouwbare absolute paden/toegankelijke URI's of insluiting gebruiken.