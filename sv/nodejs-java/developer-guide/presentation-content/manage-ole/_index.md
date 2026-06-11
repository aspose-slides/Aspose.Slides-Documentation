---
title: Hantera OLE i presentationer med JavaScript
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/nodejs-java/manage-ole/
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
- länkt fil
- ändra OLE
- OLE-ikon
- OLE-titel
- extrahera OLE
- extrahera objekt
- extrahera fil
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för Node.js via Java. Bädda in, uppdatera och exportera OLE-innehåll sömlöst."
---
## **Introduktion**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) är en Microsoft‑teknik som gör det möjligt att placera data och objekt som skapats i en applikation i en annan applikation genom länka eller bädda in. 

{{% /alert %}} 

Tänk på ett diagram skapat i MS Excel. Diagrammet placeras sedan i en PowerPoint‑bild. Detta Excel‑diagram betraktas som ett OLE‑objekt. 

- Ett OLE‑objekt kan visas som en ikon. I så fall öppnas diagrammet i den tillhörande applikationen (Excel) när du dubbelklickar på ikonen, eller så blir du ombedd att välja en applikation för att öppna eller redigera objektet. 
- Ett OLE‑objekt kan visa sitt faktiska innehåll, till exempel innehållet i ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas och du kan ändra diagrammets data inom PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/sv/nodejs-java/) låter dig infoga OLE‑objekt i bilder som OLE‑objektrammar ([OleObjectFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/OleObjectFrame)).

## **Lägga till OLE‑objektramar i bilder**

Anta att du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objektram med Aspose.Slides for Node.js via Java, så kan du göra så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) .
1. Hämta en bilds referens via dess index.
1. Läs Excel‑filen som en bytearray.
1. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/OleObjectFrame) till bilden med bytearrayen och övrig information om OLE‑objektet.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan lade vi till ett diagram från en Excel‑fil till en bild som en OLE‑objektram med Aspose.Slides for Node.js via Java.  
**Obs!** att konstruktorn för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/OleEmbeddedDataInfo) tar en inbäddningsbar objekttillägg som andra parameter. Detta tillägg gör att PowerPoint korrekt kan tolka filtypen och välja rätt applikation för att öppna detta OLE‑objekt.

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Förbered data för OLE-objektet.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Lägg till OLE-objektramen på bilden.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Lägga till länkade OLE‑objektramar**

Aspose.Slides for Node.js via Java gör det möjligt att lägga till en [OleObjectFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/OleObjectFrame) utan att bädda in data, utan endast med en länk till filen.  

Denna JavaScript‑kod visar hur du lägger till en [OleObjectFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/OleObjectFrame) med en länkad Excel‑fil till en bild:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Lägg till en OLE-objektram med en länkad Excel-fil.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Åtkomst till OLE‑objektramar**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller komma åt det på följande sätt:

1. Ladda en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) .
2. Hämta bildens referens genom att använda dess index.
3. Kom åt [OleObjectFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/OleObjectFrame)-formen. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har endast en form på den första bilden.
4. När OLE‑objektramen har nåtts kan du utföra vilken operation som helst på den.

I exemplet nedan nås en OLE‑objektram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Hämta den inbäddade filens data.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Hämta filtillägget för den inbäddade filen.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Åtkomst till egenskaper för länkade OLE‑objektramar**

Aspose.Slides låter dig komma åt egenskaper för länkade OLE‑objektramar.  

Denna JavaScript‑kod visar hur du kontrollerar om ett OLE‑objekt är länkat och sedan hämtar sökvägen till den länkade filen:

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Kontrollera om OLE-objektet är länkat.
    if (oleFrame.isObjectLink()) {
        // Skriv ut den fullständiga sökvägen till den länkade filen.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Skriv ut den relativa sökvägen till den länkade filen om den finns.
        // Endast PPT-presentationer kan innehålla den relativa sökvägen.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Ändra OLE‑objektdata**

{{% alert color="primary" %}} 

I detta avsnitt använder kodexemplet nedan [Aspose.Cells for Java](/cells/java/).  

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt nå det och ändra dess data på följande sätt:

1. Ladda en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) .
2. Hämta bildens referens via dess index. 
3. Kom åt OLE‑objektramsformen. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på den första bilden.
4. När OLE‑objektramen har nåtts kan du utföra vilken operation som helst på den.
5. Skapa ett `Workbook`‑objekt och kom åt OLE‑data.
6. Kom åt det önskade `Worksheet`‑arket och ändra data.
7. Spara den uppdaterade `Workbook` i en ström.
8. Ändra OLE‑objektdatan från strömmen.

I exemplet nedan nås en OLE‑objektram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata ändras för att uppdatera diagrammets data.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Läs OLE-objektdata som ett Workbook-objekt.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Modifiera workbook-data.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Ändra OLE-ramens objektdatas.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram låter Aspose.Slides for Node.js via Java dig bädda in andra filtyper i bilder. Till exempel kan du infoga HTML-, PDF- och ZIP-filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så uppmanas användaren att välja ett lämpligt program för att öppna det.

Denna JavaScript‑kod visar hur du bäddar in HTML och ZIP i en bild:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ställa in filtyper för inbäddade objekt**

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller ersätta ett icke‑stödd OLE‑objekt med ett som stöds. Aspose.Slides for Node.js via Java låter dig ange filtypen för ett inbäddat objekt, så att du kan uppdatera OLE‑ramens data eller dess filändelse.

Denna JavaScript‑kod visar hur du anger filtypen för ett inbäddat OLE‑objekt till `zip`:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Ändra filtypen till ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ställa in ikonbilder och titlar för inbäddade objekt**

Efter att ha bäddat in ett OLE‑objekt läggs en förhandsgranskning bestående av en ikonbild automatiskt till. Denna förhandsgranskning är det användarna ser innan de får åtkomst till eller öppnar OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ange ikonbilden och titeln med Aspose.Slides for Node.js via Java.

Denna JavaScript‑kod visar hur du anger ikonbilden och titeln för ett inbäddat objekt:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Lägg till en bild i presentationens resurser.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Förhindra att OLE‑objektram ändras i storlek och position**

När du har lagt till ett länkat OLE‑objekt i en presentationsbild och öppnar presentationen i PowerPoint kan du se ett meddelande som ber dig att uppdatera länkarna. Om du klickar på knappen "Uppdatera länkar" kan storlek och position för OLE‑objektramen förändras eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och uppdaterar förhandsgranskningen. För att förhindra att PowerPoint frågar om att uppdatera objektets data, använd metoden `setUpdateAutomatic` i klassen [OleObjectFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/oleobjectframe/) med värdet `false`:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **Extrahera inbäddade filer**

Aspose.Slides for Node.js via Java låter dig extrahera de filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller de OLE‑objekt du tänker extrahera.
2. Loopa igenom alla former i presentationen och kom åt [OLEObjectFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/oleobjectframe)-formerna.
3. Hämta data för de inbäddade filerna från OLE‑objektramarna och skriv den till disk.

Denna JavaScript‑kod visar hur du extraherar filer som är inbäddade i en bild som OLE‑objekt:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **FAQ**

**Kommer OLE‑innehållet att renderas när bilder exporteras till PDF/bilder?**

Det som är synligt på bilden renderas – ikonen/ersättningsbilden (förhandsgranskning). Det "levande" OLE‑innehållet körs inte under rendering. Vid behov kan du ange en egen förhandsgranskningsbild för att säkerställa det förväntade utseendet i den exporterade PDF‑filen.

**Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?**

Lås formen: Aspose.Slides erbjuder lås på formnivå. Detta är inte kryptering, men det hindrar effektivt oavsiktliga ändringar och förflyttning.

**Kommer relativa sökvägar för länkade OLE‑objekt att bevaras i PPTX‑formatet?**

I PPTX finns ingen information om "relativ sökväg" – endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet bör du föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller bädda in filerna.