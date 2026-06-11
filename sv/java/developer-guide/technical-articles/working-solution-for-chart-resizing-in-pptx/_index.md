---
title: Fungerande lösning för diagramstorleksändring i PPTX
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
description: "Fixa oväntad diagramstorleksändring i PPTX när inbäddade Excel OLE-objekt används med Aspose.Slides for Java. Lär dig två metoder med kod för att hålla storlekar konsekventa."
---
## **Bakgrund**

Det har observerats att Excel-diagram som bäddas in som OLE-objekt i en PowerPoint-presentation via Aspose-komponenter får en ospecificerad skalning efter deras första aktivering. Detta beteende orsakar en märkbar visuell skillnad i presentationen mellan diagrammets tillstånd före och efter aktivering. Aspose-teamet har undersökt problemet i detalj och har hittat en lösning. Denna artikel beskriver orsakerna till problemet och den motsvarande åtgärden.

I den [föregående artikeln](/slides/sv/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) förklarade vi hur man skapar ett Excel-diagram med Aspose.Cells for Java och bäddar in det i en PowerPoint-presentation med Aspose.Slides for Java. För att åtgärda [objektförhandsgranskningsproblemet](/slides/sv/java/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi diagrammets bild till diagrammets OLE-objektram. I den resulterande presentationen, när du dubbelklickar på OLE-objektramen som visar diagrammets bild, aktiveras Excel-diagrammet. Slutanvändare kan göra önskade ändringar i den underliggande Excel-arbetsboken och sedan återgå till motsvarande bild genom att klicka utanför den aktiverade arbetsboken. Storleken på OLE-objektramen ändras när användaren återvänder till bilden, och ombildningsfaktorn varierar beroende på de ursprungliga storlekarna för både OLE-objektramen och den inbäddade Excel-arbetsboken.

## **Orsak till storleksändring**

Eftersom Excel-arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. OLE-objektramen har dock sin egen storlek. Enligt Microsoft, när Excel-arbetsboken aktiveras, förhandlar Excel och PowerPoint fram storleken och bibehåller korrekta proportioner som en del av inbäddningsprocessen. Beroende på skillnaderna mellan Excel-fönstrets storlek och OLE-objektramens storlek eller position uppstår en ombildning.

## **Fungerande lösning**

Det finns två möjliga scenarier för att skapa PowerPoint-presentationer med Aspose.Slides for Java.

**Scenario 1:** Skapa en presentation baserad på en befintlig mall.

**Scenario 2:** Skapa en presentation från grunden.

Lösningen vi presenterar här gäller för båda scenarierna. Grunden för alla lösningsmetoder är densamma: **det inbäddade OLE-objektets fönsterstorlek ska matcha OLE-objektramen i PowerPoint-bilden**. Vi kommer nu att diskutera de två tillvägagångssätten för denna lösning.

## **Första tillvägagångssättet**

I detta tillvägagångssätt lär vi oss hur man ställer in fönsterstorleken för den inbäddade Excel-arbetsboken så att den matchar storleken på OLE-objektramen i PowerPoint-bilden.

**Scenario 1**

Anta att vi har definierat en mall och vill skapa presentationer baserade på den. Föreställ dig att det finns en form på index 2 i mallen där vi vill placera en OLE-ram som innehåller en inbäddad Excel-arbetsbok. I detta scenario är storleken på OLE-objektramen fördefinierad – den matchar storleken på formen på index 2 i mallen. Allt vi behöver göra är att ställa in arbetsbokens fönsterstorlek lika med formens storlek. Följande kodsnutt fyller detta syfte:

```java
// Ställ in arbetsbokens fönsterbredd i tum (delat med 576 eftersom PowerPoint använder 576 pixlar per tum).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Ställ in arbetsbokens fönsterhöjd i tum.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Spara arbetsboken till en minnesström.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Skapa en OLE-objektram med de inbäddade Excel-data.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**

Låt oss säga att vi vill skapa en presentation från grunden och inkludera en OLE-objektram av godtycklig storlek med en inbäddad Excel-arbetsbok. I kodsnutten nedan skapar vi en OLE-objektram som är 4 tum hög och 9,5 tum bred på x = 0,5 tum och y = 1 tum på bilden. Vi ställer sedan in Excel-arbetsbokens fönster till samma storlek – 4 tum hög och 9,5 tum bred.

```java
// Vår önskade höjd.
int desiredHeight = 288; // 4 tum (4 * 72)
 
// Vår önskade bredd.
int desiredWidth = 684; // 9,5 tum (9.5 * 72)
 
// Definiera diagrammets storlek med ett fönster.
chart.setSizeWithWindow(true);
 
// Ställ in arbetsbokens fönsterbredd i tum (delat med 576 eftersom PowerPoint använder 576 pixlar per tum).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Ställ in arbetsbokens fönsterhöjd i tum.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Spara arbetsboken till en minnesström.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Skapa en OLE-objektram med de inbäddade Excel-data.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Andra tillvägagångssättet**

I detta tillvägagångssätt lär vi oss hur man ställer in diagrammets storlek i den inbäddade Excel-arbetsboken så att den matchar storleken på OLE-objektramen i PowerPoint-bilden. Detta tillvägagångssätt är användbart när diagrammets storlek är känd i förväg och aldrig kommer att förändras.

**Scenario 1**

Anta att vi har definierat en mall och vill skapa presentationer baserade på den. Föreställ dig att det finns en form på index 2 i mallen där vi avser att placera en OLE-ram som innehåller en inbäddad Excel-arbetsbok. I detta scenario är OLE-ramens storlek fördefinierad – den matchar storleken på formen på index 2 i mallen. Allt vi behöver göra är att ställa in diagrammets storlek i arbetsboken lika med formens storlek. Följande kodsnutt fyller detta syfte:

```java
// Definiera diagrammets storlek utan ett fönster.
chart.setSizeWithWindow(false);
 
// Ställ in diagrammets bredd i pixlar (multiplicera med 96 eftersom Excel använder 96 pixlar per tum).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Ställ in diagrammets höjd i pixlar.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Definiera diagrammets utskriftsstorlek.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Spara arbetsboken till en minnesström.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Skapa en OLE-objektram med de inbäddade Excel-data.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**:

Anta att vi vill skapa en presentation från grunden och inkludera en OLE-objektram av godtycklig storlek med en inbäddad Excel-arbetsbok. I kodsnutten nedan skapar vi en OLE-objektram med en höjd på 4 tum och en bredd på 9,5 tum på bilden på x = 0,5 tum och y = 1 tum. Vi ställer även in motsvarande diagramstorlek till samma dimensioner: en höjd på 4 tum och en bredd på 9,5 tum.

```java
// Vår önskade höjd.
int desiredHeight = 288; // 4 tum (4 * 72)
 
// Vår önskade bredd.
int desiredWidth = 684; // 9,5 tum (9.5 * 72)
 
// Definiera diagrammets storlek utan ett fönster.
chart.setSizeWithWindow(false);
 
// Ställ in diagrammets bredd i pixlar (multiplicera med 96 eftersom Excel använder 96 pixlar per tum).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Ställ in diagrammets höjd i pixlar.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Spara arbetsboken till en minnesström.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Skapa en OLE-objektram med de inbäddade Excel-data.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Slutsats**

Det finns två tillvägagångssätt för att lösa problemet med diagramstorleksändring. Valet av tillvägagångssätt beror på kraven och användningsfallet. Båda tillvägagångssätten fungerar på samma sätt oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen gräns för storleken på OLE-objektramen i denna lösning.

## **Vanliga frågor**

**Varför ändrar mitt inbäddade Excel-diagram storlek efter att det aktiveras i PowerPoint?**

Detta sker eftersom Excel försöker återställa den ursprungliga fönsterstorleken vid första aktiveringen, medan OLE-objektramen i PowerPoint har egna dimensioner. PowerPoint och Excel förhandlar fram storleken för att bibehålla bildförhållandet, vilket kan leda till ombildning.

**Kan man helt förhindra detta storleksändringsproblem?**

Ja. Genom att matcha Excel-arbetsbokens fönsterstorlek eller diagrammets storlek till OLE-objektramens storlek innan inbäddning kan du hålla diagrammets storlek konsekvent.

**Vilket tillvägagångssätt bör jag välja, att ställa in arbetsbokens fönsterstorlek eller diagrammets storlek?**

Använd **Tillvägagångssätt 1 (fönsterstorlek)** om du vill behålla arbetsbokens bildförhållande och eventuellt tillåta ombildning senare.  
Använd **Tillvägagångssätt 2 (diagramstorlek)** om diagrammets dimensioner är fasta och inte kommer att förändras efter inbäddning.

**Fungerar dessa metoder både för mallbaserade presentationer och nya presentationer?**

Ja. Båda tillvägagångssätten fungerar likadant för presentationer skapade från mallar och från grunden.

**Finns det någon gräns för storleken på OLE-objektramen?**

Nej. Du kan sätta OLE-ramen till vilken storlek som helst så länge den skalar korrekt i förhållande till arbetsboken eller diagrammet.

**Kan jag använda dessa metoder med diagram skapade i andra kalkylprogram?**

Exemplen är avsedda för Excel-diagram skapade med Aspose.Cells, men principerna gäller även för andra OLE‑kompatibla kalkylprogram så länge de stödjer liknande storleksalternativ.

## **Relaterade avsnitt**

- [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Uppdatera OLE-objekt automatiskt med ett PowerPoint‑tillägg](/slides/sv/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)