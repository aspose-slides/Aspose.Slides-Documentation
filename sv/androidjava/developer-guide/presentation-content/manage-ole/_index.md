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
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för Android via Java. Bädda in, uppdatera och exportera OLE-innehåll sömlöst."
---
## **Introduktion**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) är en Microsoft‑teknik som tillåter data och objekt skapade i ett program att placeras i ett annat program genom länkning eller inbäddning. 

{{% /alert %}} 

Tänk på ett diagram som skapats i MS Excel. Diagrammet placeras sedan i en PowerPoint‑bild. Det Excel‑diagrammet betraktas som ett OLE‑objekt. 

- Ett OLE‑objekt kan visas som en ikon. I så fall, när du dubbelklickar på ikonen, öppnas diagrammet i dess associerade program (Excel), eller du blir ombedd att välja ett program för att öppna eller redigera objektet. 
- Ett OLE‑objekt kan visa sitt faktiska innehåll, exempelvis innehållet i ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas och du kan ändra diagrammets data i PowerPoint.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/sv/androidjava/) gör det möjligt att infoga OLE‑objekt i bilder som OLE‑objekt‑ramar ([OleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OleObjectFrame)).

## **Lägg till OLE‑objekt‑ramar till bilder**

Förutsatt att du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objekt‑ram med Aspose.Slides for Android via Java, kan du göra så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).  
1. Hämta en bilds referens via dess index.  
1. Läs Excel‑filen som en byte‑array.  
1. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OleObjectFrame) till bilden med byte‑arrayen och annan information om OLE‑objektet.  
1. Skriv den modifierade presentationen som en PPTX‑fil.  

I exemplet nedan har vi lagt till ett diagram från en Excel‑fil till en bild som en OLE‑objekt‑ram med Aspose.Slides for Android via Java.  
**Obs** att konstruktorn för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OleEmbeddedDataInfo) tar en inbäddningsbar objekt‑extension som andra parameter. Denna extension gör att PowerPoint korrekt kan tolka filtypen och välja rätt program för att öppna detta OLE‑objekt.

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

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Lägg till länkade OLE‑objekt‑ramar**

Aspose.Slides for Android via Java gör det möjligt att lägga till en [OleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OleObjectFrame) utan att bädda in data, utan endast med en länk till filen.

Denna Java‑kod visar hur du lägger till en [OleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OleObjectFrame) med en länkad Excel‑fil till en bild:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Lägg till en OLE-objekt-ram med en länkad Excel-fil.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Kom åt OLE‑objekt‑ramar**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller komma åt det på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).  
2. Hämta referensen till bilden genom att använda dess index.  
3. Kom åt [OleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OleObjectFrame)-formen. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har endast en form på den första bilden. Vi *castade* sedan det objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ioleobjectframe/). Detta var den önskade OLE‑objekt‑ramen som skulle nås.  
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

    // Hämta filändelsen för den inbäddade filen.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Kom åt egenskaper för länkad OLE‑objekt‑ram**

Aspose.Slides gör det möjligt att komma åt egenskaper för länkade OLE‑objekt‑ramar.

Denna Java‑kod visar hur du kontrollerar om ett OLE‑objekt är länkat och sedan hämtar sökvägen till den länkade filen:

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

## **Ändra OLE‑objektsdata**

{{% alert color="info" %}} 

I det här avsnittet använder kodexemplet nedan [Aspose.Cells for Android via Java](/cells/androidjava/).

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt komma åt det objektet och ändra dess data på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).  
2. Hämta bildens referens via dess index.  
3. Kom åt OLE‑objekt‑ramens form. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på den första bilden. Vi *castade* sedan det objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ioleobjectframe/). Detta var den önskade OLE‑objekt‑ramen som skulle nås.  
4. När OLE‑objekt‑ramen har nåtts kan du utföra vilken operation som helst på den.  
5. Skapa ett `Workbook`‑objekt och kom åt OLE‑data.  
6. Kom åt önskat `Worksheet` och ändra datan.  
7. Spara den uppdaterade `Workbook` i en ström.  
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

    // Ändra OLE‑ramens objektdata.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram tillåter Aspose.Slides for Android via Java dig att bädda in andra filtyper i bilder. Till exempel kan du infoga HTML‑, PDF‑ och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så uppmanas användaren att välja ett lämpligt program för att öppna det.

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

## **Ställ in filtyper för inbäddade objekt**

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller ersätta ett icke‑stött OLE‑objekt med ett stödt. Aspose.Slides for Android via Java låter dig ange filtypen för ett inbäddat objekt, vilket gör att du kan uppdatera OLE‑ramens data eller dess filändelse.

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

## **Ställ in ikonbilder och titlar för inbäddade objekt**

Efter att ett OLE‑objekt har bäddats in läggs automatiskt en förhandsvisning bestående av en ikonbild till. Denna förhandsvisning är det som användarna ser innan de öppnar eller får åtkomst till OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsvisningen kan du ange ikonbilden och titeln med Aspose.Slides for Android via Java.

Denna Java‑kod visar hur du ställer in ikonbilden och titeln för ett inbäddat objekt:

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

## **Förhindra att en OLE‑objekt‑ram ändras i storlek eller flyttas**

När du har lagt till ett länkat OLE‑objekt i en presentationsbild och öppnar presentationen i PowerPoint kan du se ett meddelande som ber dig uppdatera länkarna. Att klicka på knappen ”Update Links” kan ändra storlek och position för OLE‑objekt‑ramen eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och uppdaterar förhandsvisningen. För att förhindra att PowerPoint ber om att uppdatera objektets data, sätt `setUpdateAutomatic`‑metoden på [IOleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ioleobjectframe/)‑gränssnittet till `false`:

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

Aspose.Slides for Android via Java låter dig extrahera filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller de OLE‑objekt du avser att extrahera.  
2. Loopa igenom alla former i presentationen och kom åt [OLEObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/oleobjectframe)-formerna.  
3. Kom åt data för inbäddade filer från OLE‑objekt‑ramarna och skriv den till disk.  

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

### Renderas OLE‑innehållet vid export av bilder till PDF/bilder?

Det som är synligt på bilden renderas – ikonen/ersättningsbilden (förhandsvisningen). Det ”levande” OLE‑innehållet körs inte under rendering. Vid behov kan du ange en egen förhandsvisningsbild för att säkerställa det förväntade utseendet i den exporterade PDF‑filen.

### Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?

Lås formen: Aspose.Slides erbjuder lås på formsnivå. Detta är inte kryptering, men det förhindrar effektivt oavsiktliga redigeringar och förflyttningar.

### Varför ”hoppar” ett länkat Excel‑objekt eller ändrar storlek när jag öppnar presentationen?

PowerPoint kan uppdatera förhandsvisningen av den länkade OLE‑objektet. För ett stabilt utseende, följ praxis från [Working Solution for Worksheet Resizing](/slides/sv/androidjava/working-solution-for-worksheet-resizing/) – anpassa antingen ramen till området, eller skala området till en fast ram och ange en lämplig ersättningsbild.

### Kommer relativa sökvägar för länkade OLE‑objekt att bevaras i PPTX‑formatet?

I PPTX‑formatet finns ingen information om ”relativ sökväg” – endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet bör du föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller inbäddning.