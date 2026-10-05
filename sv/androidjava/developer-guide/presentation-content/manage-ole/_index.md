---
title: Hantera OLE i presentationer på Android
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för Android via Java. Bädda in, uppdatera och exportera OLE-innehåll smidigt."
---
## **Introduktion**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) är en Microsoft‑teknik som gör det möjligt att placera data och objekt som skapats i en applikation i en annan applikation genom länking eller inbäddning. 

{{% /alert %}} 

Tänk dig ett diagram skapat i MS Excel. Diagrammet placeras sedan i en PowerPoint‑bild. Det Excel‑diagrammet betraktas som ett OLE‑objekt. 

- Ett OLE‑objekt kan visas som en ikon. I så fall, när du dubbelklickar på ikonen, öppnas diagrammet i dess associerade program (Excel), eller så blir du ombedd att välja ett program för att öppna eller redigera objektet.
- Ett OLE‑objekt kan visa sitt faktiska innehåll, till exempel innehållet i ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas, och du kan modifiera diagrammets data i PowerPoint.

[Aspose.Slides för Android via Java](https://products.aspose.com/slides/androidjava/) möjliggör att du infogar OLE Objects i bilder som OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Lägg till OLE‑objekt‑ramar i bilder**

Antag att du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objekt‑ram med Aspose.Slides för Android via Java, så kan du göra så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
1. Hämta en bilds referens via dess index.
1. Läs Excel‑filen som en byte‑array.
1. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) till bilden med byte‑arrayen och annan information om OLE‑objektet.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till ett diagram från en Excel‑fil till en bild som en OLE‑objekt‑ram med Aspose.Slides för Android via Java.  
**Obs** att konstruktorn för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) tar en inbäddningsbar objekt‑extension som andra parameter. Denna extension gör att PowerPoint korrekt kan tolka filtypen och välja rätt program för att öppna detta OLE‑objekt.

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

// Förbered data för OLE-objektet.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Lägg till OLE-objekt‑ramen på bilden.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Lägg till länkade OLE‑objekt‑ramar**

Aspose.Slides för Android via Java möjliggör att du lägger till en [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) utan att bädda in data, utan endast med en länk till filen.

Denna Java‑kod visar hur du lägger till en [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) med en länkad Excel‑fil till en bild:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Lägg till en OLE‑objekt‑ram med en länkad Excel‑fil.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Åtkomst till OLE‑objekt‑ramar**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller komma åt det på följande sätt:

1. Ladda en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. Hämta bildens referens genom att använda dess index.
3. Åtkomst till formen [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). I vårt exempel använde vi den tidigare skapade PPTX‑filen som har endast en form på den första bilden. Vi *castade* sedan det objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Detta var den önskade OLE‑objekt‑ramen som skulle nås.
4. När OLE‑objekt‑ramen har nåtts kan du utföra vilken operation som helst på den.

I exemplet nedan nås en OLE‑objekt‑ram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata.

```java 
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

### **Åtkomst till egenskaper för länkade OLE‑objekt‑ramar**

Aspose.Slides låter dig komma åt egenskaper för länkade OLE‑objekt‑ramar.

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

{{% alert color="info" title="Note" %}}

I det här avsnittet använder kodexemplet nedan [Aspose.Cells för Android via Java](https://docs.aspose.com/cells/androidjava/).

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt komma åt det objektet och ändra dess data på följande sätt:

1. Ladda en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. Hämta bildens referens via dess index. 
3. Åtkomst till OLE‑objekt‑ramens form. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på den första bilden. Vi *castade* sedan objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Detta var den önskade OLE‑objekt‑ramen som skulle nås.
4. När OLE‑objekt‑ramen har nåtts kan du utföra vilken operation som helst på den.
5. Skapa ett `Workbook`‑objekt och åtkom OLE‑data.
6. Åtkomst till önskad `Worksheet` och ändra data.
7. Spara den uppdaterade `Workbook`‑en i en ström.
8. Ändra OLE‑objektets data från strömmen.

I exemplet nedan nås en OLE‑objekt‑ram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata ändras för att uppdatera diagrammets data.

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

    // Läs OLE‑objektdata som ett Workbook‑objekt.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Ändra arbetsbokens data.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Ändra OLE‑ramobjektets data.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram tillåter Aspose.Slides för Android via Java att du bäddar in andra typer av filer i bilder. Till exempel kan du infoga HTML‑, PDF‑ och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så uppmanas användaren att välja ett lämpligt program för att öppna det.

Denna Java‑kod visar hur du bäddar in HTML och ZIP i en bild:

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

## **Ange filtyper för inbäddade objekt**

När du arbetar med presentationer kan det behövas att ersätta gamla OLE‑objekt med nya eller ersätta ett ej stödd OLE‑objekt med ett stödd. Aspose.Slides för Android via Java låter dig ange filtypen för ett inbäddat objekt, vilket möjliggör att du uppdaterar OLE‑ramens data eller dess extension.

Denna Java‑kod visar hur du sätter filtypen för ett inbäddat OLE‑objekt till `zip`:

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

Efter att ett OLE‑objekt har bäddats in läggs automatiskt en förhandsgranskning bestående av en ikonbild till. Denna förhandsgranskning är vad användare ser innan de kommer åt eller öppnar OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ange ikonbilden och titeln med Aspose.Slides för Android via Java.

Denna Java‑kod visar hur du anger ikonbilden och titeln för ett inbäddat objekt:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Lägg till en bild i presentationens resurser.
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

## **Förhindra att en OLE‑objekt‑ram kan ändras i storlek eller flyttas**

Efter att du har lagt till ett länkat OLE‑objekt på en presentationsbild kan du vid öppning av presentationen i PowerPoint få ett meddelande som ber dig att uppdatera länkarna. Att klicka på knappen "Update Links" kan ändra storlek och position för OLE‑objekt‑ramen eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och uppdaterar objektets förhandsgranskning. För att förhindra att PowerPoint frågar om att uppdatera objektets data, anropa metoden [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) på gränssnittet [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) med `false`:

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

## **Extrahera inbäddade filer**

Aspose.Slides för Android via Java låter dig extrahera filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) som innehåller de OLE‑objekt du avser att extrahera.
2. Loopa igenom alla former i presentationen och åtkom formerna av typen [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).
3. Åtkomst till data för inbäddade filer från OLE‑objekt‑ramar och skriv den till disk.

Denna Java‑kod visar hur du extraherar filer som är inbäddade i en bild som OLE‑objekt:

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

**Kommer OLE‑innehållet att renderas när slides exporteras till PDF/bilder?**

Det som är synligt på bilden renderas — ikonen/ersättningsbilden (förhandsgranskning). Det "levande" OLE‑innehållet körs inte under rendering. Vid behov, ange en egen förhandsgranskningsbild för att säkerställa det förväntade utseendet i den exporterade PDF‑filen.  

För att också bevara den inbäddade filen som en PDF‑bilaga, anropa [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) med `true`. Detta alternativ är inaktiverat som standard. För ett exempel och instruktioner för att kontrollera bilagan, se [Bevara inbäddade OLE‑filer som PDF‑bilagor](/slides/sv/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?**

Lås formen: Aspose.Slides erbjuder lås på formnivå. Detta är inte kryptering, men det förhindrar effektivt oavsiktliga redigeringar och flyttningar.

**Varför ”hoppar” eller ändrar storlek ett länkat Excel‑objekt när jag öppnar presentationen?**

PowerPoint kan uppdatera förhandsgranskningen av det länkade OLE‑objektet. För ett stabilt utseende, följ rekommendationerna i [Arbetslösning för omformning av kalkylblad](/slides/sv/androidjava/working-solution-for-worksheet-resizing/) — antingen anpassa ramen till intervallet, eller skala intervallet till en fast ram och ange en lämplig ersättningsbild.

**Kommer relativa sökvägar för länkade OLE‑objekt att bevaras i PPTX‑formatet?**

I PPTX finns ingen information om "relativ sökväg" — endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet, föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller inbäddning.