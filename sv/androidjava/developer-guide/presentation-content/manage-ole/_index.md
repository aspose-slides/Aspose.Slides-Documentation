---
title: Hantera OLE i presentationer på Android
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för Android via Java. Bädda in, uppdatera och exportera OLE-innehåll sömlöst."
---
## **Introduktion**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) är en Microsoft-teknik som gör att data och objekt som skapats i ett program kan placeras i ett annat program genom länkning eller inbäddning. 

{{% /alert %}} 

Tänk på ett diagram som skapats i MS Excel. Diagrammet placeras sedan i en PowerPoint-bild. Det Excel-diagrammet betraktas som ett OLE‑objekt. 

- Ett OLE‑objekt kan visas som en ikon. I så fall öppnas diagrammet i den associerade applikationen (Excel) när du dubbelklickar på ikonen, eller så blir du ombedd att välja en applikation för att öppna eller redigera objektet. 
- Ett OLE‑objekt kan visa sitt faktiska innehåll, exempelvis innehållet i ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas och du kan modifiera diagrammets data i PowerPoint.

[Aspose.Slides för Android via Java](https://products.aspose.com/slides/sv/androidjava/) låter dig infoga OLE‑objekt i bilder som OLE‑objekt‑ramar ([OleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OleObjectFrame)).

## **Lägg till OLE‑objekt‑ramar i bilder**

Förutsatt att du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objekt‑ram med Aspose.Slides för Android via Java, kan du göra så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation). 
1. Hämta en bilds referens via dess index. 
1. Läs Excel‑filen som en byte‑array. 
1. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OleObjectFrame) i bilden med byte‑arrayen och annan information om OLE‑objektet. 
1. Skriv den ändrade presentationen som en PPTX‑fil. 

I exemplet nedan lade vi till ett diagram från en Excel‑fil i en bild som en OLE‑objekt‑ram med Aspose.Slides för Android via Java.  
**Obs!** att konstruktorn för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OleEmbeddedDataInfo) tar en inbäddningsbar objekttillägg som andra parameter. Detta tillägg gör att PowerPoint korrekt kan tolka filtypen och välja rätt program för att öppna detta OLE‑objekt.

```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Förbered data för OLE-objektet.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Lägg till OLE-objekt‑ramen på bilden.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Lägg till länkade OLE‑objekt‑ramar**

Aspose.Slides för Android via Java låter dig lägga till en [OleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OleObjectFrame) utan att bädda in data, utan endast med en länk till filen.

Denna Java‑kod visar hur du lägger till en [OleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OleObjectFrame) med en länkad Excel‑fil i en bild:

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

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation). 
2. Hämta referensen till bilden genom att använda dess index. 
3. Kom åt formen [OleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OleObjectFrame).  
   I vårt exempel använde vi den tidigare skapade PPTX‑filen som har endast en form på den första bilden. Vi *castade* sedan det objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ioleobjectframe/). Detta var den önskade OLE‑objekt‑ramen som skulle nås. 
4. När OLE‑objekt‑ramen har nåtts kan du utföra vilken operation som helst på den. 

I exemplet nedan nås en OLE‑objekt‑ram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata.

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Hämta inbäddad fildata.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Hämta den inbäddade filens filändelse.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Åtkomst till egenskaper för länkad OLE‑objekt‑ram**

Aspose.Slides låter dig komma åt egenskaper för en länkad OLE‑objekt‑ram.

Denna Java‑kod visar hur du kontrollerar om ett OLE‑objekt är länkat och sedan får sökvägen till den länkade filen:

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

## **Ändra OLE‑objektsdata**

{{% alert color="primary" %}} 

I det här avsnittet använder kodexemplet nedan [Aspose.Cells för Android via Java](/cells/androidjava/). 

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt komma åt det objektet och modifiera dess data på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation). 
2. Hämta bildens referens via dess index. 
3. Kom åt OLE‑objekt‑ramens form.  
   I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på den första bilden. Vi *castade* sedan det objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ioleobjectframe/). Detta var den önskade OLE‑objekt‑ramen som skulle nås. 
4. När OLE‑objekt‑ramen har nåtts kan du utföra vilken operation som helst på den. 
5. Skapa ett `Workbook`‑objekt och få åtkomst till OLE‑data. 
6. Hämta önskat `Worksheet` och ändra datan. 
7. Spara det uppdaterade `Workbook` i en ström. 
8. Ändra OLE‑objektets data från strömmen. 

I exemplet nedan nås en OLE‑objekt‑ram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata modifieras för att uppdatera diagrammets data.

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Läs OLE-objektdata som ett Workbook-objekt.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Modifiera workbook-data.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Ändra OLE-ramens objektdatar.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram tillåter Aspose.Slides för Android via Java att du bäddar in andra filtyper i bilder. Du kan till exempel infoga HTML-, PDF- och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så blir användaren ombedd att välja ett lämpligt program för att öppna det.

Denna Java‑kod visar hur du bäddar in HTML och ZIP i en bild:

```java
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

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller ersätta ett ej‑stödd OLE‑objekt med ett som stöds. Aspose.Slides för Android via Java låter dig ange filtypen för ett inbäddat objekt, vilket gör att du kan uppdatera OLE‑ramens data eller dess filändelse.

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

## **Ange ikonavbilder och titlar för inbäddade objekt**

Efter att ha bäddat in ett OLE‑objekt läggs automatiskt en förhandsgranskning bestående av en ikonavbild till. Denna förhandsgranskning är vad användarna ser innan de kommer åt eller öppnar OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ange ikonavbilden och titeln med Aspose.Slides för Android via Java.

Denna Java‑kod visar hur du anger ikonavbilden och titeln för ett inbäddat objekt:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Lägg till en bild till presentationens resurser.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Ange en titel och bilden för OLE-förhandsgranskningen.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Förhindra att en OLE‑objekt‑ram ändras i storlek eller position**

När du har lagt till ett länkat OLE‑objekt i en presentationsbild och öppnar presentationen i PowerPoint kan du se ett meddelande som ber dig att uppdatera länkarna. Att klicka på knappen ”Uppdatera länkar” kan ändra storlek och position för OLE‑objekt‑ramen eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och uppdaterar förhandsgranskningen. För att förhindra att PowerPoint frågar om att uppdatera objektets data, sätt `setUpdateAutomatic`‑metoden för [IOleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ioleobjectframe/)‑gränssnittet till `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Extrahera inbäddade filer**

Aspose.Slides för Android via Java låter dig extrahera filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller de OLE‑objekt du avser att extrahera. 
2. Loopa igenom alla former i presentationen och kom åt formerna [OLEObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/oleobjectframe). 
3. Få åtkomst till data för inbäddade filer från OLE‑objekt‑ramar och skriv dem till disk. 

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

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **FAQ**

**Kommer OLE‑innehållet att renderas när man exporterar bilder till PDF/bilder?**

Det som syns på bilden renderas – ikonen/ersättningsbilden (förhandsgranskning). Det ”levande” OLE‑innehållet körs inte under rendering. Vid behov kan du ange en egen förhandsgranskningsbild för att säkerställa det förväntade utseendet i den exporterade PDF‑filen.

**Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?**

Lås formen: Aspose.Slides tillhandahåller lås på formnivå. Detta är ingen kryptering, men det förhindrar i praktiken oavsiktliga redigeringar och förflyttningar.

**Varför hoppar ett länkat Excel‑objekt eller ändrar storlek när jag öppnar presentationen?**

PowerPoint kan uppdatera förhandsgranskningen av den länkade OLE‑objektet. För ett stabilt utseende, följ praktikerna i [Working Solution for Worksheet Resizing](/slides/sv/androidjava/working-solution-for-worksheet-resizing/) – antingen anpassa ramen till området, eller skala området till en fast ram och ange en lämplig ersättningsbild.

**Kommer relativa sökvägar för länkade OLE‑objekt att bevaras i PPTX‑formatet?**

I PPTX finns ingen information om ”relativ sökväg” – endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet bör du föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller inbäddning.