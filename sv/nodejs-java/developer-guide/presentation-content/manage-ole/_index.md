---
title: Hantera OLE i presentationer med JavaScript
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/nodejs-java/manage-ole/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för Node.js via Java. Bädda in, uppdatera och exportera OLE-innehåll sömlöst."
---
## **Introduktion**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) är en Microsoft-teknik som tillåter data och objekt som skapats i en applikation att placeras i en annan applikation genom länkar eller inbäddning. 

{{% /alert %}} 

Tänk dig ett diagram skapat i MS Excel. Diagrammet placeras sedan i en PowerPoint-bild. Det Excel-diagrammet betraktas som ett OLE‑objekt. 

- Ett OLE‑objekt kan visas som en ikon. I så fall, när du dubbelklickar på ikonen, öppnas diagrammet i den associerade applikationen (Excel), eller så uppmanas du att välja en applikation för att öppna eller redigera objektet.
- Ett OLE‑objekt kan visa sitt faktiska innehåll, till exempel innehållet i ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas, och du kan modifiera diagrammets data i PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) låter dig infoga OLE‑objekt i bilder som OLE‑objekt‑ramar ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **Lägga till OLE‑objekt‑ramar i bilder**

Om du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objekt‑ram med Aspose.Slides for Node.js via Java, kan du göra så här:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) klassen.
2. Hämta en bilds referens via dess index.
3. Läs Excel‑filen som en byte‑array.
4. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) till bilden som innehåller byte‑arrayen och annan information om OLE‑objektet.
5. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan lade vi till ett diagram från en Excel‑fil i en bild som en OLE‑objekt‑ram med Aspose.Slides for Node.js via Java. **Note** att [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo)‑konstruktorn tar en inbäddningsbar objekt‑extension som andra parameter. Denna extension gör att PowerPoint korrekt kan tolka filtypen och välja rätt program för att öppna detta OLE‑objekt.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Lägga till länkade OLE‑objekt‑ramar**

Aspose.Slides for Node.js via Java låter dig lägga till en [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) utan att bädda in data utan endast med en länk till filen.

Denna JavaScript‑kod visar hur du lägger till en [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) med en länkad Excel‑fil till en bild:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Lägg till en OLE‑objekt‑ram med en länkad Excel‑fil.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Åtkomst till OLE‑objekt‑ramar**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller komma åt det på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) klassen.
2. Hämta referensen till bilden genom att använda dess index.
3. Kom åt [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)‑formen. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har endast en form på den första bilden.
4. När OLE‑objekt‑ramen är åtkomlig kan du utföra vilken operation som helst på den.

I exemplet nedan får man åtkomst till en OLE‑objekt‑ram (ett Excel‑diagram som är inbäddat i en bild) och dess fildata.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Hämta den inbäddade filens data.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Hämta den inbäddade filens filändelse.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Åtkomst till egenskaper för länkade OLE‑objekt‑ramar**

Aspose.Slides låter dig komma åt egenskaper för länkade OLE‑objekt‑ramar.

Denna JavaScript‑kod visar hur du kontrollerar om ett OLE‑objekt är länkat och sedan hämtar sökvägen till den länkade filen:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

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

{{% alert color="info" title="Note" %}}

I det här avsnittet använder kodexemplet nedan [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt komma åt det och modifiera dess data på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) klassen.
2. Hämta bildens referens via dess index. 
3. Kom åt OLE‑objekt‑ramens form. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på den första bilden.
4. När OLE‑objekt‑ramen är åtkomlig kan du utföra vilken operation som helst på den.
5. Skapa ett `Workbook`‑objekt och hämta OLE‑data.
6. Kom åt önskad `Worksheet` och ändra datan.
7. Spara den uppdaterade `Workbook` i en ström.
8. Ändra OLE‑objektets data från strömmen.

I exemplet nedan får man åtkomst till en OLE‑objekt‑ram (ett Excel‑diagram som är inbäddat i en bild) och dess fildata ändras för att uppdatera diagrammets data.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // Läs OLE-objektets data som ett Workbook-objekt.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Modifiera arbetsbokens data.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Ändra OLE-ramens objektdata.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram låter Aspose.Slides for Node.js via Java dig bädda in andra filtyper i bilder. Till exempel kan du infoga HTML-, PDF‑ och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så uppmanas användaren att välja ett lämpligt program för att öppna det.

Denna JavaScript‑kod visar hur du bäddar in HTML och ZIP i en bild:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller ersätta ett ej‑stödd OLE‑objekt med ett stödd. Aspose.Slides for Node.js via Java låter dig ange filtypen för ett inbäddat objekt, vilket gör att du kan uppdatera OLE‑ramens data eller dess extension.

Denna JavaScript‑kod visar hur du anger filtypen för ett inbäddat OLE‑objekt till `zip`:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

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

Efter att ha bäddat in ett OLE‑objekt läggs automatiskt en förhandsgranskning bestående av en ikonbild till. Denna förhandsgranskning är vad användarna ser innan de får åtkomst till eller öppnar OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ange ikonbilden och titeln med Aspose.Slides for Node.js via Java.

Denna JavaScript‑kod visar hur du anger ikonbilden och titeln för ett inbäddat objekt:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Lägg till en bild i presentationens resurser.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Ange en titel och bilden för OLE‑förhandsgranskningen.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Förhindra att en OLE‑objekt‑ram kan ändras i storlek och flyttas**

Efter att du har lagt till ett länkat OLE‑objekt i en presentationsbild, kan du när du öppnar presentationen i PowerPoint se ett meddelande som ber dig att uppdatera länkarna. Att klicka på knappen "Update Links" kan ändra storlek och position för OLE‑objekt‑ramen eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och uppdaterar objektets förhandsgranskning. För att förhindra att PowerPoint frågar om att uppdatera objektets data, anropa [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic)‑metoden i [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/)‑klassen med `false`:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Extrahera inbäddade filer**

Aspose.Slides for Node.js via Java låter dig extrahera filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑klassen som innehåller de OLE‑objekt du avser att extrahera.
2. Loopa igenom alla former i presentationen och få åtkomst till [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe)‑former.
3. Få åtkomst till data från inbäddade filer i OLE‑objekt‑ramar och skriv den till disk.

Denna JavaScript‑kod visar hur du extraherar filer som är inbäddade i en bild som OLE‑objekt:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

Det som är synligt på bilden renderas — ikonen/ersättningsbilden (förhandsgranskning). Det "levande" OLE‑innehållet körs inte under rendering. Vid behov, ange din egen förhandsgranskningsbild för att säkerställa önskat utseende i den exporterade PDF‑filen. För att även bevara den inbäddade filen som en PDF‑bilaga, anropa [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) med `true`. Detta alternativ är inaktiverat som standard. För ett exempel och instruktioner för att kontrollera bilagan, se [Preserve Embedded OLE Files as PDF Attachments](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?**

Lås formen: Aspose.Slides tillhandahåller lås på formnivå. Detta är inte kryptering, men det förhindrar effektivt oavsiktliga redigeringar och flyttning.

**Kommer relativa sökvägar för länkade OLE‑objekt att bevaras i PPTX‑formatet?**

I PPTX‑formatet finns ingen information om "relativ sökväg"—endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet bör du föredra pålitliga absoluta sökvägar/tillgängliga URI‑er eller inbäddning.