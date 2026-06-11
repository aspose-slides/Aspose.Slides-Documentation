---
title: Hantera OLE i presentationer med PHP
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/php-java/manage-ole/
keywords:
- OLE-objekt
- Objektlänkning & inbäddning
- lägg till OLE
- bädda in OLE
- lägg till objekt
- bädda in objekt
- lägg till fil
- bädda in fil
- länkat objekt
- länkat fil
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

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) är en Microsoft‑teknik som tillåter data och objekt som skapats i en applikation att placeras i en annan applikation genom länkning eller inbäddning. 

{{% /alert %}} 

Tänk på ett diagram skapat i MS Excel. Diagrammet placeras sedan i en PowerPoint‑bild. Det Excel‑diagrammet betraktas som ett OLE‑objekt. 

- Ett OLE‑objekt kan visas som en ikon. I så fall, när du dubbelklickar på ikonen, öppnas diagrammet i den associerade applikationen (Excel), eller så blir du ombedd att välja en applikation för öppning eller redigering av objektet. 
- Ett OLE‑objekt kan visa sitt faktiska innehåll, såsom innehållet i ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas, och du kan modifiera diagrammets data i PowerPoint.

[Aspose.Slides för PHP via Java](https://products.aspose.com/slides/sv/php-java/) gör att du kan infoga OLE‑objekt i bilder som OLE‑objekt‑ramar ([OleObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/)).

## **Lägg till OLE‑objektram i bilder**

Om du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objektram med Aspose.Slides för PHP via Java, kan du göra så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index.
1. Läs Excel‑filen som en byte‑array.
1. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/) till bilden med byte‑arrayen och annan information om OLE‑objektet.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan lade vi till ett diagram från en Excel‑fil i en bild som en OLE‑objektram med Aspose.Slides för PHP via Java.  
**Obs!** att konstruktorn för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleembeddeddatainfo/) tar en inbäddningsbar objekt‑extension som andra parameter. Denna extension gör att PowerPoint korrekt tolkar filtypen och väljer rätt applikation för att öppna detta OLE‑objekt.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Förbered data för OLE-objektet.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Lägg till OLE-objektram till bilden.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Lägg till länkade OLE‑objektram**

Aspose.Slides för PHP via Java gör det möjligt att lägga till en [OleObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/) utan att bädda in data, utan enbart med en länk till filen.

Denna PHP‑kod visar hur du lägger till en [OleObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/) med en länkad Excel‑fil till en bild:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Lägg till en OLE-objektram med en länkad Excel-fil.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Åtkomst till OLE‑objektram**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller komma åt det på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) .
2. Hämta bildens referens genom att använda dess index.
3. Kom åt [OleObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/)‑formen. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har endast en form på första bilden.
4. När OLE‑objektramen är nådd kan du utföra vilken operation som helst på den.

I exemplet nedan har en OLE‑objektram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata åtkomits.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Hämta den inbäddade filens data.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Hämta filändelsen för den inbäddade filen.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Åtkomst till egenskaper för länkad OLE‑objektram**

Aspose.Slides låter dig komma åt egenskaper för länkade OLE‑objektram.

Denna PHP‑kod visar hur du kontrollerar om ett OLE‑objekt är länkat och sedan får sökvägen till den länkade filen:

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

## **Ändra OLE‑objektdata**

{{% alert color="primary" %}} 

I det här avsnittet använder kodexemplet nedan [Aspose.Cells för PHP via Java](/cells/php-java/).

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt nå det objektet och ändra dess data på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) .
2. Hämta bildens referens via dess index. 
3. Kom åt [OleObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/)‑formen. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på första bilden.
4. När OLE‑objektramen är nådd kan du utföra vilken operation som helst på den.
5. Skapa ett `Workbook`‑objekt och nå OLE‑data.
6. Kom åt önskat `Worksheet` och ändra datan.
7. Spara det uppdaterade `Workbook` i en ström.
8. Ändra OLE‑objektets data från strömmen.

I exemplet nedan nås en OLE‑objektram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata modifieras för att uppdatera diagrammets data.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Läs OLE-objektets data som ett Workbook-objekt.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Modifiera arbetsbokens data.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Ändra OLE-ramens objektdata.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram låter Aspose.Slides för PHP via Java dig bädda in andra filtyper i bilder. Till exempel kan du infoga HTML‑, PDF‑ och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så blir användaren ombedd att välja ett lämpligt program för att öppna det.

Denna PHP‑kod visar hur du bäddar in HTML och ZIP i en bild:

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

## **Ställ in filtyper för inbäddade objekt**

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller ersätta ett icke‑stödd OLE‑objekt med ett stödd. Aspose.Slides för PHP via Java låter dig ange filtypen för ett inbäddat objekt, vilket möjliggör att uppdatera OLE‑ramens data eller dess extension.

Denna PHP‑kod visar hur du anger filtypen för ett inbäddat OLE‑objekt till `zip`:

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

## **Ställ in ikonbilder och titlar för inbäddade objekt**

Efter att ha inbäddat ett OLE‑objekt läggs automatiskt en förhandsgranskning bestående av en ikonbild till. Denna förhandsgranskning är vad användarna ser innan de når eller öppnar OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ange ikonbilden och titeln med Aspose.Slides för PHP via Java.

Denna PHP‑kod visar hur du anger ikonbilden och titeln för ett inbäddat objekt:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Lägg till en bild i presentationens resurser.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Förhindra att en OLE‑objektram ändras i storlek eller position**

Efter att du har lagt till ett länkat OLE‑objekt i en presentationsbild, kan du när du öppnar presentationen i PowerPoint få ett meddelande som ber dig uppdatera länkarna. Att klicka på knappen "Uppdatera länkar" kan ändra storlek och position för OLE‑objektramen eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och uppdaterar förhandsgranskningen. För att förhindra att PowerPoint frågar om att uppdatera objektets data, sätt `setUpdateAutomatic`‑metoden för [OleObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/)‑klassen till `false`:

```php
$oleFrame->setUpdateAutomatic(false);
```

## **Extrahera inbäddade filer**

Aspose.Slides för PHP via Java låter dig extrahera filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) som innehåller de OLE‑objekt du avser att extrahera.
2. Iterera igenom alla former i presentationen och åtkom [OLEObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/)‑formerna.
3. Kom åt data för de inbäddade filerna från OLE‑objektram och skriv den till disk.

Denna PHP‑kod visar hur du extraherar filer som är inbäddade i en bild som OLE‑objekt:

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

**Kommer OLE‑innehållet att renderas när man exporterar bilder till PDF/bilder?**

Det som är synligt på bilden renderas – ikonen/ersättningsbilden (förhandsgranskning). Det "live" OLE‑innehållet körs inte under rendering. Vid behov, ange en egen förhandsgranskningsbild för att säkerställa önskat utseende i den exporterade PDF‑filen.

**Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?**

Lås formen: Aspose.Slides erbjuder lås på formnivå. Detta är ingen kryptering, men det förhindrar effektivt oavsiktliga redigeringar och förflyttningar.

**Kommer relativa sökvägar för länkade OLE‑objekt att bevaras i PPTX‑formatet?**

I PPTX finns ingen information om "relativ sökväg" – endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet, föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller inbäddning.