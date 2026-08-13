---
title: Hantera OLE i presentationer med Java
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/java/manage-ole/
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
- Java
- Aspose.Slides
description: "Optimera hantering av OLE‑objekt i PowerPoint‑ och OpenDocument‑filer med Aspose.Slides för Java. Bädda in, uppdatera och exportera OLE‑innehåll sömlöst."
---
## **Introduktion**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) är en Microsoft‑teknik som gör att data och objekt som skapats i ett program kan placeras i ett annat program genom länkning eller inbäddning. 

{{% /alert %}} 

Tänk dig ett diagram som skapats i MS Excel. Diagrammet placeras sedan i en PowerPoint‑bild. Det Excel‑diagrammet betraktas som ett OLE‑objekt. 

- Ett OLE‑objekt kan visas som en ikon. I så fall öppnas diagrammet i den associerade applikationen (Excel) när du dubbelklickar på ikonen, eller så blir du ombedd att välja en applikation för att öppna eller redigera objektet. 
- Ett OLE‑objekt kan visa sitt faktiska innehåll, till exempel innehållet i ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas och du kan ändra diagrammets data i PowerPoint.

[Aspose.Slides för Java](https://products.aspose.com/slides/sv/java/) låter dig infoga OLE‑objekt i bilder som OLE‑objekt‑ramar ([OleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/OleObjectFrame)).

## **Lägg till OLE‑objekt‑ramar i bilder**

Förutsatt att du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objekt‑ram med Aspose.Slides för Java, kan du göra så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Läs Excel‑filen som en byte‑array.
4. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/OleObjectFrame) på bilden med byte‑arrayen och annan information om OLE‑objektet.
5. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan lade vi till ett diagram från en Excel‑fil i en bild som en OLE‑objekt‑ram med Aspose.Slides för Java.  
**Obs** att [OleEmbeddedDataInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/OleEmbeddedDataInfo)-konstruktorn tar en inbäddningsbar objekt‑extension som andra parameter. Denna extension gör att PowerPoint korrekt kan tolka filtypen och välja rätt program för att öppna detta OLE‑objekt.

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

### **Lägg till länkade OLE‑objekt‑ramar**

Aspose.Slides för Java låter dig lägga till en [OleObjectFrame] utan att bädda in data, utan endast med en länk till filen.

Den här Java‑koden visar hur du lägger till en [OleObjectFrame] med en länkad Excel‑fil i en bild:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Lägg till en OLE‑objektram med en länkad Excel‑fil.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Åtkomst till OLE‑objekt‑ramar**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller komma åt det på detta sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta bildens referens genom att använda dess index.
3. Kom åt formen [OleObjectFrame]. I vårt exempel använde vi den tidigare skapade PPTX‑filen som bara har en form på den första bilden. Vi *castade* sedan det objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IOleObjectFrame). Detta var den önskade OLE‑objekt‑ramen att komma åt.
4. När OLE‑objekt‑ramen är nådd kan du utföra valfri operation på den.

I exemplet nedan nås en OLE‑objekt‑ram (ett Excel‑diagram som är inbäddat i en bild) och dess fildata.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Hämta den inbäddade filens data.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Hämta den inbäddade filens filändelse.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Åtkomst till egenskaper för länkad OLE‑objekt‑ram**

Aspose.Slides låter dig komma åt egenskaper för länkade OLE‑objekt‑ramar.

Den här Java‑koden visar hur du kontrollerar om ett OLE‑objekt är länkat och sedan hämtar sökvägen till den länkade filen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Kontrollera om OLE‑objektet är länkat.
    if (oleFrame.isObjectLink()) {
        // Skriv ut den fullständiga sökvägen till den länkade filen.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Skriv ut den relativa sökvägen till den länkade filen om den finns.
        // Endast PPT‑presentationer kan innehålla den relativa sökvägen.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Ändra OLE‑objekt‑data**

{{% alert color="info" %}} 

I det här avsnittet använder kodexemplet nedan [Aspose.Cells för Java](/cells/java/).

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt komma åt det objektet och modifiera dess data på detta sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta bildens referens genom dess index. 
3. Kom åt OLE‑objekt‑ramens form. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på den första bilden. Vi *castade* sedan det objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IOleObjectFrame). Detta var den önskade OLE‑objekt‑ramen att komma åt.
4. När OLE‑objekt‑ramen är nådd kan du utföra valfri operation på den.
5. Skapa ett `Workbook`‑objekt och kom åt OLE‑datat.
6. Kom åt det önskade `Worksheet` och ändra datan.
7. Spara den uppdaterade `Workbook` i en ström.
8. Ändra OLE‑objekt‑datat från strömmen.

I exemplet nedan nås en OLE‑objekt‑ram (ett Excel‑diagram som är inbäddat i en bild) och dess fildata modifieras för att uppdatera diagrammets data.

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

    // Läs OLE‑objektets data som ett Workbook‑objekt.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Modifiera arbetsbokens data.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Ändra OLE‑ramens objektdatan.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram låter Aspose.Slides för Java dig bädda in andra typer av filer i bilder. Till exempel kan du infoga HTML-, PDF- och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så blir användaren ombedd att välja ett lämpligt program för att öppna det.

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

## **Ange filtyper för inbäddade objekt**

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller ersätta ett osupportat OLE‑objekt med ett supportat. Aspose.Slides för Java låter dig ange filtypen för ett inbäddat objekt, vilket gör att du kan uppdatera OLE‑ramens data eller dess extension.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Ändra filtypen till ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ange ikonbilder och titlar för inbäddade objekt**

Efter att ha bäddat in ett OLE‑objekt läggs automatiskt en förhandsgranskning bestående av en ikonbild till. Denna förhandsgranskning är vad användare ser innan de öppnar eller kommer åt OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ange ikonbild och titel med Aspose.Slides för Java.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Lägg till en bild i presentationens resurser.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Ange en titel och bilden för OLE‑förhandsgranskningen.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Förhindra att en OLE‑objekt‑ram ändras i storlek och position**

Efter att du lagt till ett länkat OLE‑objekt i en presentationsbild kan du, när du öppnar presentationen i PowerPoint, få ett meddelande som ber dig att uppdatera länkarna. Om du klickar på knappen “Uppdatera länkar” kan storlek och position för OLE‑objekt‑ramen ändras eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och uppdaterar förhandsgranskningen. För att förhindra att PowerPoint ber om att uppdatera objektets data, sätt `setUpdateAutomatic`‑metoden för [IOleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ioleobjectframe/)‑gränssnittet till `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Extrahera inbäddade filer**

Aspose.Slides för Java låter dig extrahera de filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)-klassen som innehåller de OLE‑objekt du vill extrahera.
2. Loopa igenom alla former i presentationen och kom åt formerna av typen [OLEObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/oleobjectframe).
3. Kom åt data för inbäddade filer från OLE‑objekt‑ramarna och skriv dem till disk.

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

## **Vanliga frågor**

### Kommer OLE‑innehållet att renderas när bilder exporteras till PDF/bilder?

Det som är synligt på bilden renderas – ikonen/ersättningsbilden (förhandsgranskning). Det “levande” OLE‑innehållet körs inte under rendering. Vid behov kan du ange en egen förhandsgranskningsbild för att säkerställa önskat utseende i den exporterade PDF‑filen.

### Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?

Lås formen: Aspose.Slides erbjuder [form‑nivå låsningar](/slides/sv/java/applying-protection-to-presentation/). Detta är ingen kryptering, men det förhindrar i praktiken oavsiktliga redigeringar och förflyttningar.

### Varför “hoppar” eller förändras storleken på ett länkat Excel‑objekt när jag öppnar presentationen?

PowerPoint kan uppdatera förhandsgranskningen av det länkade OLE‑objektet. För ett stabilt utseende, följ rekommendationerna i [Working Solution for Worksheet Resizing](/slides/sv/java/working-solution-for-worksheet-resizing/) – antingen anpassa ramen till intervallet, eller skala intervallet till en fast ram och ange en lämplig ersättningsbild.

### Bevaras relativa sökvägar för länkade OLE‑objekt i PPTX‑formatet?

I PPTX finns ingen information om “relativ sökväg” – endast den absoluta sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet bör du föredra pålitliga absoluta sökvägar/åtkomliga URI:er eller inbäddning.