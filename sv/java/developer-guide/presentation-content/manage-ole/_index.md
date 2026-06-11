---
title: Hantera OLE i presentationer med Java
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/java/manage-ole/
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
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för Java. Bädda in, uppdatera och exportera OLE-innehåll sömlöst."
---
## **Introduktion**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) är en Microsoft-teknik som gör att data och objekt som skapats i en applikation kan placeras i en annan applikation genom länkning eller inbäddning. 

{{% /alert %}} 

Tänk på ett diagram skapat i MS Excel. Diagrammet placeras sedan i en PowerPoint‑bild. Det Excel‑diagrammet betraktas som ett OLE‑objekt. 

- Ett OLE‑objekt kan visas som en ikon. I så fall öppnas diagrammet i den associerade applikationen (Excel) när du dubbelklickar på ikonen, eller så blir du ombedd att välja en applikation för att öppna eller redigera objektet. 
- Ett OLE‑objekt kan visa sitt faktiska innehåll, till exempel innehållet i ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas och du kan redigera diagrammets data i PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/sv/java/) gör det möjligt att infoga OLE‑objekt i bilder som OLE‑objekt‑ramar ([OleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/OleObjectFrame)).

## **Lägg till OLE‑objekt‑ramar i bilder**

Om du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objekt‑ram med Aspose.Slides for Java, kan du göra så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation). 
1. Hämta en bilds referens via dess index. 
1. Läs Excel‑filen som en byte‑array. 
1. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/OleObjectFrame) i bilden med byte‑arrayen och annan information om OLE‑objektet. 
1. Skriv den ändrade presentationen som en PPTX‑fil. 

I exempelnedan har vi lagt till ett diagram från en Excel‑fil i en bild som en OLE‑objekt‑ram med Aspose.Slides for Java.
**Obs** att konstruktorn för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/OleEmbeddedDataInfo) tar en inbäddningsbar objekt‑extension som andra parameter. Denna extension gör att PowerPoint korrekt kan tolka filtypen och välja rätt program för att öppna detta OLE‑objekt.

``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Förbered data för OLE-objektet.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Lägg till OLE-objektramen på bilden.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Lägg till länkade OLE‑objekt‑ramar**

Aspose.Slides for Java låter dig lägga till ett [OleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/OleObjectFrame) utan att bädda in data, utan endast med en länk till filen.

Denna Java‑kod visar hur du lägger till ett [OleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/OleObjectFrame) med en länkad Excel‑fil till en bild:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Lägg till en OLE-objektram med en länkad Excel-fil.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Åtkomst till OLE‑objekt‑ramar**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller komma åt det på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation). 
2. Hämta bildens referens genom att använda dess index. 
3. Kom åt formen [OleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/OleObjectFrame).
   I vårt exempel använde vi den tidigare skapade PPTX‑filen som har endast en form på den första bilden. Vi *castade* sedan det objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IOleObjectFrame). Detta var den önskade OLE‑objekt‑ramen som skulle nås. 
4. När OLE‑objekt‑ramen har nåtts kan du utföra vilken operation som helst på den. 

I exempelnedan nås en OLE‑objekt‑ram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata.

``` java 
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

### **Kom åt egenskaper för länkad OLE‑objekt‑ram**

Aspose.Slides låter dig komma åt egenskaper för länkade OLE‑objekt‑ramar.

Denna Java‑kod visar hur du kontrollerar om ett OLE‑objekt är länkat och sedan hämtar sökvägen till den länkade filen:

```java
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

{{% alert color="primary" %}} 

I det här avsnittet använder kodexemplet nedan [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt komma åt det objektet och ändra dess data på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation). 
2. Hämta bildens referens via dess index. 
3. Kom åt OLE‑objekt‑ramens form.
   I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på den första bilden. Vi *castade* sedan det objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IOleObjectFrame). Detta var den önskade OLE‑objekt‑ramen som skulle nås. 
4. När OLE‑objekt‑ramen har nåtts kan du utföra vilken operation som helst på den. 
5. Skapa ett `Workbook`‑objekt och kom åt OLE‑data. 
6. Kom åt önskat `Worksheet` och ändra datan. 
7. Spara det uppdaterade `Workbook` i en ström. 
8. Ändra OLE‑objekt‑datan från strömmen. 

I exempelnedan nås en OLE‑objekt‑ram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata ändras för att uppdatera diagrammets data.

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Läs OLE-objektdata som ett Workbook-objekt.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Modifiera Workbook-datat.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Ändra OLE-ramens objektdata.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram låter Aspose.Slides for Java dig bädda in andra filtyper i bilder. Till exempel kan du infoga HTML-, PDF- och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så uppmanas användaren att välja ett lämpligt program för att öppna det.

Denna Java‑kod visar hur du bäddar in HTML och ZIP i en bild:

```java
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

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller byta ut ett ej‑stödd OLE‑objekt mot ett stödd. Aspose.Slides for Java låter dig ange filtypen för ett inbäddat objekt, vilket gör att du kan uppdatera OLE‑ramens data eller dess extension.

Denna Java‑kod visar hur du anger filtypen för ett inbäddat OLE‑objekt till `zip`:

```java
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

Efter att ha bäddat in ett OLE‑objekt läggs en förhandsgranskning bestående av en ikonbild automatiskt till. Denna förhandsgranskning är vad användarna ser innan de kommer åt eller öppnar OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ange ikonbilden och titeln med Aspose.Slides for Java.

Denna Java‑kod visar hur du anger ikonbilden och titeln för ett inbäddat objekt:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Lägg till en bild i presentationens resurser.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Förhindra att en OLE‑objekt‑ram skalas och flyttas**

Efter att du har lagt till ett länkat OLE‑objekt till en presentationsbild kan du, när du öppnar presentationen i PowerPoint, få ett meddelande som ber dig uppdatera länkarna. Att klicka på knappen "Uppdatera länkar" kan ändra storlek och position för OLE‑objekt‑ramen eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och uppdaterar objektets förhandsgranskning. För att hindra PowerPoint från att be om att uppdatera objektets data, sätt metoden `setUpdateAutomatic` i gränssnittet [IOleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ioleobjectframe/) till `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Extrahera inbäddade filer**

Aspose.Slides for Java låter dig extrahera de filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller de OLE‑objekt du vill extrahera. 
2. Loopa igenom alla former i presentationen och kom åt formerna av typen [OLEObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/oleobjectframe). 
3. Kom åt data för de inbäddade filerna från OLE‑objekt‑ramarna och skriv den till disk. 

Denna Java‑kod visar hur du extraherar filer som är inbäddade i en bild som OLE‑objekt:

```java
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

**Kommer OLE‑innehållet att renderas när bilder exporteras till PDF/bilder?**

Det som syns på bilden renderas – ikonen/ersättningsbilden (förhandsgranskning). Det "levande" OLE‑innehållet körs inte under renderingen. Om så behövs, ange en egen förhandsgranskningsbild för att säkerställa önskat utseende i den exporterade PDF‑filen.

**Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?**

Lås formen: Aspose.Slides erbjuder [formnivå‑lås](/slides/sv/java/applying-protection-to-presentation/). Detta är ingen kryptering, men det förhindrar i praktiken oavsiktliga redigeringar och flyttning.

**Varför hoppar ett länkat Excel‑objekt eller ändrar storlek när jag öppnar presentationen?**

PowerPoint kan uppdatera förhandsgranskningen av det länkade OLE‑objektet. För ett stabilt utseende, följ praxis i [Working Solution for Worksheet Resizing](/slides/sv/java/working-solution-for-worksheet-resizing/) – antingen anpassa ramen till området, eller skala området till en fast ram och ange en lämplig ersättningsbild.

**Behåller PPTX‑formatet relativa sökvägar för länkade OLE‑objekt?**

I PPTX finns ingen information om "relativ sökväg" – endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet, föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller inbäddning.