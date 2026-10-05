---
title: Hantera OLE i presentationer med PHP
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/php-java/manage-ole/
keywords:
- OLE-objekt
- Objektlänkning och inbäddning
- lägg till OLE
- bädda in OLE
- lägg till objekt
- bädda in objekt
- lägg till fil
- bädda in fil
- länkat objekt
- länkad fil
- ändra OLE
- OLE-ikon
- OLE-titel
- extrahera OLE
- extrahera objekt
- extrahera fil
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för PHP via Java. Bädda in, uppdatera och exportera OLE-innehåll sömlöst."
---
## **Introduktion**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) är en Microsoft‑teknik som gör det möjligt att placera data och objekt som skapats i ett program i ett annat program genom länkning eller inbäddning. 

{{% /alert %}} 

Tänk på ett diagram som skapats i MS Excel. Diagrammet placeras sedan i en PowerPoint‑bild. Det Excel‑diagrammet betraktas som ett OLE‑objekt. 

- Ett OLE‑objekt kan visas som en ikon. I så fall öppnas diagrammet i dess associerade program (Excel) när du dubbelklickar på ikonen, eller så uppmanas du att välja ett program för att öppna eller redigera objektet.
- Ett OLE‑objekt kan visa sitt faktiska innehåll, till exempel innehållet i ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas och du kan ändra diagrammets data i PowerPoint.

[Aspose.Slides för PHP via Java](https://products.aspose.com/slides/php-java/) låter dig infoga OLE‑objekt i bilder som OLE‑objekt‑ramar ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **Lägg till OLE‑objekt‑ramar i bilder**

Om du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objekt‑ram med hjälp av Aspose.Slides för PHP via Java, kan du göra så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index.
1. Läs Excel‑filen som en byte‑array.
1. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) i bilden med byte‑arrayen och annan information om OLE‑objektet.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan lade vi till ett diagram från en Excel‑fil i en bild som en OLE‑objekt‑ram med Aspose.Slides för PHP via Java.  
**Obs** att konstruktorn för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) tar en inbäddningsbar objekt‑extension som andra parameter. Denna extension gör att PowerPoint korrekt kan tolka filtypen och välja rätt program för att öppna detta OLE‑objekt.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Förbered data för OLE-objektet.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Lägg till OLE-objektramen på bilden.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Lägg till länkade OLE‑objekt‑ramar**

Aspose.Slides för PHP via Java låter dig lägga till en [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) utan att bädda in data, utan endast med en länk till filen.

Den här PHP‑koden visar hur du lägger till en [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) med en länkad Excel‑fil till en bild:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Lägg till en OLE-objekt-ram med en länkad Excel-fil.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Åtkomst till OLE‑objekt‑ramar**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller komma åt det på detta sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Hämta referensen till bilden genom att använda dess index.
3. Kom åt formen [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). I vårt exempel använde vi den tidigare skapade PPTX‑filen som bara har en form på den första bilden.
4. När OLE‑objekt‑ramen har nåtts kan du utföra vilken operation som helst på den.

I exemplet nedan nås en OLE‑objekt‑ram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Hämta den inbäddade filens data.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Hämta den inbäddade filens filändelse.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Kom åt egenskaper för länkad OLE‑objekt‑ram**

Aspose.Slides låter dig komma åt egenskaper för länkade OLE‑objekt‑ramar.

Den här PHP‑koden visar hur du kontrollerar om ett OLE‑objekt är länkat och sedan får sökvägen till den länkade filen:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Kontrollera om OLE-objektet är länkat.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Skriv ut den fullständiga sökvägen till den länkade filen.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Skriv ut den relativa sökvägen till den länkade filen om den finns.
        // Endast PPT-presentationer kan innehålla den relativa sökvägen.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **Ändra OLE‑objektsdata**

{{% alert color="info" title="Note" %}}

I det här avsnittet använder kodexemplet nedan [Aspose.Cells för PHP via Java](https://docs.aspose.com/cells/php-java/).

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt komma åt det objektet och ändra dess data på detta sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Hämta bildens referens via dess index. 
3. Kom åt formen [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på den första bilden.
4. När OLE‑objekt‑ramen har nåtts kan du utföra vilken operation som helst på den.
5. Skapa ett `Workbook`‑objekt och kom åt OLE‑datan.
6. Kom åt önskad `Worksheet` och ändra data.
7. Spara den uppdaterade `Workbook` i en ström.
8. Ändra OLE‑objektets data från strömmen.

I exemplet nedan nås en OLE‑objekt‑ram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata modifieras för att uppdatera diagrammets data.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Läs OLE-objektdatan som ett Workbook-objekt.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Ändra arbetsbokens data.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Ändra OLE-ramobjektets data.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram tillåter Aspose.Slides för PHP via Java dig att bädda in andra filtyper i bilder. Till exempel kan du infoga HTML-, PDF‑ och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så uppmanas användaren att välja ett lämpligt program för att öppna det.

Den här PHP‑koden visar hur du bäddar in HTML och ZIP i en bild:

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

## **Ange filtyper för inbäddade objekt**

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller ersätta ett icke‑stött OLE‑objekt med ett stödt. Aspose.Slides för PHP via Java låter dig ange filtypen för ett inbäddat objekt, vilket möjliggör att uppdatera OLE‑ramens data eller dess extension.

Den här PHP‑koden visar hur du anger filtypen för ett inbäddat OLE‑objekt till `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Ändra filtypen till ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Ange ikonbilder och titlar för inbäddade objekt**

Efter att ha bäddat in ett OLE‑objekt läggs automatiskt en förhandsgranskning bestående av en ikonbild till. Denna förhandsgranskning är vad användarna ser innan de kommer åt eller öppnar OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ange ikonbilden och titeln med Aspose.Slides för PHP via Java.

Den här PHP‑koden visar hur du anger ikonbilden och titeln för ett inbäddat objekt:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Lägg till en bild i presentationens resurser.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Ange en titel och bilden för OLE-förhandsgranskningen.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Förhindra att en OLE‑objekt‑ram ändras i storlek och flyttas**

Efter att du har lagt till ett länkat OLE‑objekt i en presentationsbild kan du, när du öppnar presentationen i PowerPoint, få ett meddelande som ber dig att uppdatera länkarna. Om du klickar på knappen "Uppdatera länkar" kan storleken och positionen på OLE‑objekt‑ramen ändras eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och uppdaterar förhandsgranskningen. För att förhindra att PowerPoint ber om att uppdatera objektets data, anropa [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic)-metoden på [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)-klassen med `false`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Extrahera inbäddade filer**

Aspose.Slides för PHP via Java låter dig extrahera de filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) som innehåller de OLE‑objekt du avser att extrahera.
2. Iterera genom alla former i presentationen och kom åt formerna [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/).
3. Kom åt data för de inbäddade filerna från OLE‑objekt‑ramar och skriv den till disk.

Den här PHP‑koden visar hur du extraherar filer som är inbäddade i en bild som OLE‑objekt:

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

## **Vanliga frågor**

**Kommer OLE‑innehållet att renderas när bilder exporteras till PDF/bilder?**

Det som är synligt på bilden renderas – ikonen/ersättningsbilden (förhandsgranskning). Det "levande" OLE‑innehållet körs inte under rendering. Vid behov kan du ange en egen förhandsgranskningsbild för att säkerställa det förväntade utseendet i den exporterade PDF‑filen.

För att också bevara den inbäddade filen som en PDF‑bilaga, anropa [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) med `true`. Detta alternativ är inaktiverat som standard. För ett exempel och instruktioner för att kontrollera bilagan, se [Bevara inbäddade OLE‑filer som PDF‑bilagor](/slides/sv/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?**

Lås formen: Aspose.Slides tillhandahåller lås på formnivå. Detta är ingen kryptering, men det förhindrar i praktiken oavsiktliga redigeringar och flytt.

**Kommer relativa sökvägar för länkade OLE‑objekt att bevaras i PPTX‑formatet?**

I PPTX‑formatet finns ingen information om "relativa sökvägar" – endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet bör du föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller inbäddning.