---
title: Lösning för diagramstorleksändring i PPTX
type: docs
weight: 40
url: /sv/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagramstorleksändring
- Excel-diagram
- OLE-objekt
- bädda in diagram
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Rätta oväntad diagramstorleksändring i PPTX när inbäddade Excel OLE-objekt används med Aspose.Slides för Java. Lär dig två metoder med kod för att hålla storlekar konsekventa."
---
## **Bakgrund**

Det har observerats att Excel-diagram som bäddas in som OLE-objekt i en PowerPoint‑presentation via Aspose‑komponenter ändrar skala till en ospecificerad storlek efter sin första aktivering. Detta beteende orsakar en märkbar visuell skillnad i presentationen mellan diagrammets för‑ och efteraktiverings‑tillstånd. Aspose‑teamet har undersökt problemet i detalj och hittat en lösning. Denna artikel beskriver orsakerna till problemet samt den motsvarande åtgärden.

I den [föregående artikeln](/slides/sv/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) förklarade vi hur man skapar ett Excel‑diagram med Aspose.Cells för Java och bäddar in det i en PowerPoint‑presentation med Aspose.Slides för Java. För att lösa [objektförhandsgranskningsproblemet](/slides/sv/java/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi diagrammets bild till diagrammets OLE‑objekt‑ram. I den resulterande presentationen, när du dubbelklickar på OLE‑objekt‑ramen som visar diagrammets bild, aktiveras Excel‑diagrammet. Slutanvändare kan göra önskade ändringar i den underliggande Excel‑arbetsboken och sedan återgå till motsvarande bild genom att klicka utanför den aktiverade arbetsboken. Storleken på OLE‑objekt‑ramen ändras när användaren återvänder till bilden, och omfångsfaktorn varierar beroende på de ursprungliga storlekarna för både OLE‑objekt‑ramen och den inbäddade Excel‑arbetsboken.

## **Orsak till storleksändring**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. OLE‑objekt‑ramen har dock sin egen storlek. Enligt Microsoft, när Excel‑arbetsboken aktiveras, förhandlar Excel och PowerPoint om storleken och upprätthåller korrekta proportioner som en del av inbäddningsprocessen. Beroende på skillnaderna mellan Excel‑fönsterstorleken och OLE‑objekt‑ramens storlek eller position uppstår en storleksändring.

## **Fungerande lösning**

Det finns två möjliga scenarier för att skapa PowerPoint‑presentationer med Aspose.Slides för Java.

**Scenario 1:** Skapa en presentation baserad på en befintlig mall.

**Scenario 2:** Skapa en presentation från grunden.

Lösningen vi presenterar här gäller för båda scenarierna. Grunden för alla lösningsansatser är densamma: **det inbäddade OLE‑objektets fönsterstorlek ska matcha OLE‑objekt‑ramen i PowerPoint‑bilden**. Vi kommer nu att diskutera de två tillvägagångssätten för denna lösning.

## **Första tillvägagångssättet**

I detta tillvägagångssätt lär vi oss hur man ställer in fönsterstorleken för den inbäddade Excel‑arbetsboken så att den matchar storleken på OLE‑objekt‑ramen i PowerPoint‑bilden.

**Scenario 1**

Anta att vi har definierat en mall och vill skapa presentationer baserade på den. Föreställ dig att det finns en form på index 2 i mallen där vi vill placera en OLE‑ram som innehåller en inbäddad Excel‑arbetsbok. I detta scenario är OLE‑objekt‑ramens storlek fördefinierad – den matchar storleken på formen på index 2 i mallen. Allt vi behöver göra är att sätta arbetsbokens fönsterstorlek lika med formen's storlek. Följande kodsnutt uppfyller detta syfte:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Ange arbetsbokens fönsterbredd i tum (delat med 72 eftersom PowerPoint använder 72 punkter per tum).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Ange arbetsbokens fönsterhöjd i tum.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Spara arbetsboken till en minnesström.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Skapa en OLE‑objektsram med den inbäddade Excel‑datan.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**

Låt oss säga att vi vill skapa en presentation från grunden och inkludera en OLE‑objekt‑ram av godtycklig storlek med en inbäddad Excel‑arbetsbok. I kodsnutten nedan skapar vi en OLE‑objekt‑ram som är 4 tum hög och 9,5 tum bred på x = 0,5 tum och y = 1 tum på bilden. Vi sätter sedan Excel‑arbetsbokens fönster till samma storlek – 4 tum hög och 9,5 tum bred.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Önskad höjd.
int desiredHeight = 288; // 4 tum (4 * 72)
 
// Önskad bredd.
int desiredWidth = 684; // 9,5 tum (9,5 * 72)
 
// Definiera diagrammets storlek med ett fönster.
chart.setSizeWithWindow(true);
 
// Ställ in arbetsbokens fönsterbredd i tum (delat med 72 eftersom PowerPoint använder 72 punkter per tum).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// Ställ in arbetsbokens fönsterhöjd i tum.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// Spara arbetsboken till en minnesström.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Skapa en OLE‑objektsram med den inbäddade Excel‑datan.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 tum (0,5 * 72)
    72,  // y = 1 tum (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Andra tillvägagångssättet**

I detta tillvägagångssätt lär vi oss hur man ställer in diagrammets storlek i den inbäddade Excel‑arbetsboken så att den matchar OLE‑objekt‑ramens storlek i PowerPoint‑bilden. Detta tillvägagångssätt är användbart när diagrammets storlek är känd i förväg och aldrig kommer att förändras.

**Scenario 1**

Anta att vi har definierat en mall och vill skapa presentationer baserade på den. Föreställ dig att det finns en form på index 2 i mallen där vi avser att placera en OLE‑ram som innehåller en inbäddad Excel‑arbetsbok. I detta scenario är OLE‑ramens storlek fördefinierad – den matchar storleken på formen på index 2 i mallen. Allt vi behöver göra är att ställa in diagrammets storlek i arbetsboken så att den är lika med formens storlek. Följande kodsnutt uppfyller detta syfte:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Definiera diagrammets storlek utan fönster.
chart.setSizeWithWindow(false);
 
// Ange diagrammets bredd i pixlar (multiplicera med 96 eftersom Excel använder 96 pixlar per tum).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Ange diagrammets höjd i pixlar.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Definiera diagrammets utskriftsstorlek.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Spara arbetsboken till en minnesström.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Skapa en OLE‑objektsram med den inbäddade Excel‑datan.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**:

Anta att vi vill skapa en presentation från grunden och inkludera en OLE‑objekt‑ram av godtycklig storlek med en inbäddad Excel‑arbetsbok. I kodsnutten nedan skapar vi en OLE‑objekt‑ram med en höjd på 4 tum och en bredd på 9,5 tum på bilden på x = 0,5 tum och y = 1 tum. Vi ställer även in motsvarande diagramstorlek till samma dimensioner: en höjd på 4 tum och en bredd på 9,5 tum.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Önskad höjd.
int desiredHeight = 288; // 4 tum (4 * 72)
 
// Önskad bredd.
int desiredWidth = 684; // 9,5 tum (9,5 * 72)
 
// Definiera diagrammets storlek utan fönster.
chart.setSizeWithWindow(false);
 
// Ange diagrammets bredd i pixlar (delat med 72 för att få tum, multiplicerat med 96 eftersom Excel använder 96 pixlar per tum).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Ange diagrammets höjd i pixlar.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Spara arbetsboken till en minnesström.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Skapa en OLE‑objektsram med den inbäddade Excel‑datan.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 tum (0,5 * 72)
    72,  // y = 1 tum (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Slutsats**

Det finns två tillvägagångssätt för att åtgärda problem med diagrammets storleksändring. Valet av tillvägagångssätt beror på krav och användningsscenario. Båda metoderna fungerar på samma sätt oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen begränsning för OLE‑objekt‑ramens storlek i denna lösning.

## **FAQ**

### Varför ändras storleken på mitt inbäddade Excel‑diagram efter aktivering i PowerPoint?

Detta sker eftersom Excel försöker återställa den ursprungliga fönsterstorleken vid första aktiveringen, medan OLE‑objekt‑ramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att upprätthålla bildförhållandet, vilket kan leda till en storleksändring.

### Är det möjligt att helt förhindra detta storleksändringsproblem?

Ja. Genom att matcha Excel‑arbetsbokens fönsterstorlek eller diagrammets storlek till OLE‑objekt‑ramens storlek innan inbäddning kan du hålla diagrammets storlek konsekvent.

### Vilket tillvägagångssätt bör jag välja, att sätta arbetsbokens fönsterstorlek eller diagrammets storlek?

Använd **Tillvägagångssätt 1 (fönsterstorlek)** om du vill bevara arbetsbokens bildförhållande och eventuellt tillåta storleksändring senare.
Använd **Tillvägagångssätt 2 (diagramstorlek)** om diagrammets dimensioner är fasta och inte kommer att förändras efter inbäddning.

### Kommer dessa metoder att fungera både för mall‑baserade presentationer och nya presentationer?

Ja. Båda tillvägagångssätten fungerar lika för presentationer skapade från mallar och från grunden.

### Finns det någon gräns för OLE‑objekt‑ramens storlek?

Nej. Du kan sätta OLE‑ramen till vilken storlek som helst så länge den skalar korrekt i förhållande till arbetsboken eller diagrammet.

### Kan jag använda dessa metoder med diagram skapade i andra kalkylprogram?

Exemplen är avsedda för Excel‑diagram skapade med Aspose.Cells, men principerna gäller även för andra OLE‑kompatibla kalkylprogram så länge de stödjer liknande storleksalternativ.

## **Relaterade avsnitt**

- [Skapa Excel‑diagram och bädda in dem som OLE‑objekt i presentationer](/slides/sv/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)