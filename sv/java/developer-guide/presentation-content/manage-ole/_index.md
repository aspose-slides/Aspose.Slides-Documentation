---
title: Hantera OLE i presentationer med Java
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/java/manage-ole/
keywords:
- OLE-objekt
- Objektlänkning & inbäddning
- lägga till OLE
- bädda in OLE
- lägga till objekt
- bädda in objekt
- lägga till fil
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
- Java
- Aspose.Slides
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för Java. Bädda in, uppdatera och exportera OLE-innehåll sömlöst."
---
## **Introduktion**

{{% alert color="info" title="Obs" %}}
OLE (Object Linking & Embedding) är en Microsoft‑teknik som gör det möjligt att placera data och objekt som skapats i ett program i ett annat program genom länkning eller inbäddning. 

Consider a chart created in MS Excel. The chart is then placed inside a PowerPoint slide. That Excel chart is considered an OLE object. 

- Ett OLE‑objekt kan visas som en ikon. I så fall öppnas diagrammet i den associerade applikationen (Excel) när du dubbelklickar på ikonen, eller så blir du ombedd att välja en applikation för att öppna eller redigera objektet.
- Ett OLE‑objekt kan visa sitt faktiska innehåll, till exempel ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas och du kan ändra diagrammets data i PowerPoint.

[Aspose.Slides för Java](https://products.aspose.com/slides/java/) låter dig infoga OLE‑objekt i bilder som OLE‑objektramramar ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).
{{% /alert %}} 

## **Lägg till OLE‑objektramramar i bilder**

Om du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objektramram med Aspose.Slides för Java, kan du göra så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. Hämta en bilds referens via dess index.
1. Läs Excel‑filen som en byte‑array.
1. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) till bilden med byte‑arrayen och annan information om OLE‑objektet.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan lade vi till ett diagram från en Excel‑fil i en bild som en OLE‑objektramram med Aspose.Slides för Java.  
**Obs** att konstruktorn för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) tar en inbäddningsbar objekt‑extension som andra parameter. Denna extension gör att PowerPoint korrekt kan tolka filtypen och välja rätt program för att öppna detta OLE‑objekt.

``` java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Förbered data för OLE-objektet.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Lägg till OLE-objektrammen i bilden.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Lägg till länkade OLE‑objektramramar**

Aspose.Slides för Java låter dig lägga till en [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) utan att bädda in data, utan endast med en länk till filen.

Denna Java‑kod visar hur du lägger till en [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) med en länkad Excel‑fil i en bild:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Lägg till en OLE-objektram med en länkad Excel-fil.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Åtkomst till OLE‑objektramramar**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller komma åt det på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Hämta bildens referens genom att använda dess index.
3. Kom åt [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)‑formen. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har endast en form på den första bilden. Vi *castade* sedan det objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Detta var den önskade OLE‑objektramramen som skulle nås.
4. När OLE‑objektramramen har nåtts kan du utföra vilken operation som helst på den.

I exemplet nedan nås en OLE‑objektramram (ett Excel‑diagram som är inbäddat i en bild) och dess fildata.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Hämta den inbäddade fildatan.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Hämta den inbäddade filens filändelse.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Kom åt egenskaper för länkad OLE‑objektramram**

Aspose.Slides låter dig komma åt egenskaper för länkade OLE‑objektramramar.

Denna Java‑kod visar hur du kontrollerar om ett OLE‑objekt är länkat och sedan erhåller sökvägen till den länkade filen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Kontrollera om OLE-objektet är länkat.
    if (oleFrame.isObjectLink()) {
        // Skriv ut den fullständiga sökvägen till den länkade filen.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Skriv ut den relativa sökvägen till den länkade filen om den finns.
        // Endast PPT-presentationer kan innehålla den relativa sökvägen.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Ändra OLE‑objektdata**

{{% alert color="info" title="Obs" %}}
I det här avsnittet använder kodexemplet nedan [Aspose.Cells för Java](https://docs.aspose.com/cells/java/).
{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt komma åt det objektet och ändra dess data på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Hämta bildens referens via dess index. 
3. Kom åt OLE‑objektramformens form. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på den första bilden. Vi *castade* sedan det objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Detta var den önskade OLE‑objektramramen att nå.
4. När OLE‑objektramramen har nåtts kan du utföra vilken operation som helst på den.
5. Skapa ett `Workbook`‑objekt och komma åt OLE‑data.
6. Kom åt önskat `Worksheet` och ändra data.
7. Spara det uppdaterade `Workbook` i en ström.
8. Ändra OLE‑objektdatan från strömmen.

I exemplet nedan nås en OLE‑objektramram (ett Excel‑diagram som är inbäddat i en bild) och dess fildata ändras för att uppdatera diagrammets data.

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

    // Läs OLE-objektets data som ett Workbook-objekt.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Modifiera arbetsbokens data.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Ändra OLE-ramens objektsdata.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram låter Aspose.Slides för Java dig bädda in andra typer av filer i bilder. Till exempel kan du infoga HTML‑, PDF‑ och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så blir användaren ombedd att välja ett lämpligt program för att öppna det.

Denna Java‑kod visar hur du bäddar in HTML och ZIP i en bild:

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

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller ersätta ett ej stödd OLE‑objekt med ett som stöds. Aspose.Slides för Java låter dig ange filtypen för ett inbäddat objekt, vilket gör att du kan uppdatera OLE‑ramens data eller dess extension.

Denna Java‑kod visar hur du ställer in filtypen för ett inbäddat OLE‑objekt till `zip`:

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

Efter att ha bäddat in ett OLE‑objekt läggs automatiskt en förhandsgranskning bestående av en ikonbild till. Denna förhandsgranskning är vad användarna visar innan de når eller öppnar OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ange ikonbilden och titeln med Aspose.Slides för Java.

Denna Java‑kod visar hur du anger ikonbilden och titeln för ett inbäddat objekt:

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

// Ställ in en titel och bilden för OLE-förhandsgranskningen.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Förhindra att en OLE‑objektramram ändras i storlek eller position**

När du har lagt till ett länkat OLE‑objekt i en presentationsbild och öppnar presentationen i PowerPoint kan du få ett meddelande som ber dig uppdatera länkarna. Om du klickar på knappen "Update Links" kan storleken och positionen för OLE‑objektramramen ändras eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och uppdaterar förhandsgranskningen. För att förhindra att PowerPoint ber om att uppdatera objektets data, anropa metoden [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) på gränssnittet [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) med `false`:

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

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) som innehåller de OLE‑objekt du avser att extrahera.
2. Iterera igenom alla former i presentationen och nå [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe)‑formerna.
3. Kom åt data för inbäddade filer från OLE‑objektramramar och skriv dem till disk.

Denna Java‑kod visar hur du extraherar filer som är inbäddade i en bild som OLE‑objekt:

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

**Kommer OLE‑innehållet att renderas vid export av bilder till PDF/bilder?**

Det som syns på bilden renderas – ikonen/ersättningsbilden (förhandsgranskning). Det "levande" OLE‑innehållet körs inte under rendering. Vid behov kan du ange en egen förhandsgranskningsbild för att säkerställa önskat utseende i den exporterade PDF‑filen.

För att också bevara den inbäddade filen som en PDF‑bilaga, anropa [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) med `true`. Detta alternativ är inaktiverat som standard. För ett exempel och instruktioner för att kontrollera bilagan, se [Bevara inbäddade OLE‑filer som PDF‑bilagor](/slides/sv/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?**

Lås formen: Aspose.Slides erbjuder [formnivå‑lås](/slides/sv/java/applying-protection-to-presentation/). Detta är ingen kryptering, men det förhindrar effektivt oavsiktliga redigeringar och flyttning.

**Varför hoppar ett länkat Excel‑objekt eller ändrar storlek när jag öppnar presentationen?**

PowerPoint kan uppdatera förhandsgranskningen av det länkade OLE‑objektet. För ett stabilt utseende, följ riktlinjerna i [Arbetslösning för arbetsbladsskalning](/slides/sv/java/working-solution-for-worksheet-resizing/) – antingen anpassa ramen till omfånget, eller skala omfånget till en fast ram och ange en lämplig ersättningsbild.

**Kommer relativa sökvägar för länkade OLE‑objekt att bevaras i PPTX‑formatet?**

I PPTX finns ingen information om "relativ sökväg" – endast hela sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet bör du föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller inbäddning.