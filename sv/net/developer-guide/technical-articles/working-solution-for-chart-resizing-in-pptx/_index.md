---
title: Fungerande lösning för diagramomskalning i PPTX
type: docs
weight: 60
url: /sv/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagramomskalning
- Excel-diagram
- OLE-objekt
- bädda in diagram
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Åtgärda oväntad diagramomskalning i PPTX när du använder inbäddade Excel OLE-objekt med Aspose.Slides för .NET. Lär dig två metoder med kod för att hålla storlekarna konsekventa."
---
## **Bakgrund**

Det har observerats att Excel-diagram som bäddas in som OLE-objekt i en PowerPoint-presentation via Aspose-komponenter ändras till en ospecificerad skala efter deras första aktivering. Detta beteende orsakar en märkbar visuell skillnad i presentationen mellan diagrammets för- och efteraktiveringsstadier. Aspose-teamet har undersökt problemet i detalj och har hittat en lösning. Denna artikel beskriver orsakerna till problemet och den motsvarande åtgärden.

I den [föregående artikeln](/slides/sv/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), förklarade vi hur man skapar ett Excel-diagram med Aspose.Cells för .NET och bäddar in det i en PowerPoint-presentation med Aspose.Slides för .NET. För att åtgärda [objektförhandsgranskningsproblemet](/slides/sv/net/object-preview-issue-when-adding-oleobjectframe/), tilldelade vi diagrambilden till diagrammets OLE-objektram. I den genererade presentationen, när du dubbelklickar på OLE-objektramen som visar diagrambilden, aktiveras Excel-diagrammet. Slutanvändare kan göra önskade ändringar i den underliggande Excel-arbetsboken och sedan återgå till motsvarande bild genom att klicka utanför den aktiverade arbetsboken. Storleken på OLE-objektramen förändras när användaren återvänder till bilden, och omdimensioneringsfaktorn varierar beroende på de ursprungliga storlekarna för både OLE-objektramen och den inbäddade Excel-arbetsboken.

## **Orsak till omskalning**

Eftersom Excel-arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. OLE-objektramen har dock sin egen storlek. Enligt Microsoft, när Excel-arbetsboken aktiveras, förhandlar Excel och PowerPoint om storleken och behåller korrekta proportioner som en del av inbäddningsprocessen. Beroende på skillnaderna mellan Excel-fönstrets storlek och OLE-objektramens storlek eller position sker omskalning.

## **Fungerande lösning**

Det finns två möjliga scenarier för att skapa PowerPoint-presentationer med Aspose.Slides för .NET.

**Scenario 1:** Skapa en presentation baserad på en befintlig mall.

**Scenario 2:** Skapa en presentation från början.

Lösningen vi tillhandahåller här gäller för båda scenarierna. Grunden för alla lösningsmetoder är densamma: **det inbäddade OLE-objektets fönsterstorlek ska matcha OLE-objektramen i PowerPoint-bilden**. Vi kommer nu att diskutera de två tillvägagångssätten för denna lösning.

## **Första tillvägagångssättet**

I detta tillvägagångssätt kommer vi att lära oss hur man ställer in fönsterstorleken för den inbäddade Excel-arbetsboken så att den matchar storleken på OLE-objektramen i PowerPoint-bilden.

**Scenario 1**  

Anta att vi har definierat en mall och vill skapa presentationer baserade på den. Anta att det finns en form på index 2 i mallen där vi vill placera en OLE-ram som innehåller en inbäddad Excel-arbetsbok. I detta scenario är storleken på OLE-objektramen fördefinierad — den matchar storleken på formen på index 2 i mallen. Allt vi behöver göra är att sätta arbetsbokens fönsterstorlek lika med den formens storlek. Följande kodavsnitt tjänar detta ändamål:

```cs
// Definiera diagrammets storlek med ett fönster. 
chart.SizeWithWindow = true;

// Ange arbetsbokens fönsterbredd i tum (delat med 72 eftersom PowerPoint använder 72 pixlar per tum).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Ange arbetsbokens fönsterhöjd i tum.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Spara arbetsboken till en minnesström.
MemoryStream workbookStream = workbook.SaveToStream();

// Skapa en OLE-objektram med de inbäddade Excel-data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**  

Låt oss säga att vi vill skapa en presentation från början och inkludera en OLE-objektram av valfri storlek med en inbäddad Excel-arbetsbok. I följande kodavsnitt skapar vi en OLE-objektram som är 4 tum hög och 9,5 tum bred vid x = 0,5 tum och y = 1 tum på bilden. Vi sätter sedan Excel-arbetsbokens fönster till samma storlek — 4 tum hög och 9,5 tum bred.

```cs
// Vår önskade höjd.
int desiredHeight = 288; // 4 tum (4 * 72)

// Vår önskade bredd.
int desiredWidth = 684;//9.5 tum (9.5 * 72)

// Definiera diagrammets storlek med ett fönster.
chart.SizeWithWindow = true;

// Ange arbetsbokens fönsterbredd i tum.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Ange arbetsbokens fönsterhöjd i tum.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Spara arbetsboken till en minnesström.
MemoryStream workbookStream = workbook.SaveToStream();

// Skapa en OLE-objektram med de inbäddade Excel-data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Andra tillvägagångssättet**

I detta tillvägagångssätt kommer vi att lära oss hur man ställer in diagrammets storlek i den inbäddade Excel-arbetsboken så att den matchar storleken på OLE-objektramen i PowerPoint-bilden. Detta tillvägagångssätt är användbart när diagrammets storlek är känd i förväg och aldrig kommer att förändras.

**Scenario 1**  

Anta att vi har definierat en mall och vill skapa presentationer baserade på den. Anta att det finns en form på index 2 i mallen där vi avser att placera en OLE-ram som innehåller en inbäddad Excel-arbetsbok. I detta scenario är OLE-ramens storlek fördefinierad — den matchar storleken på formen på index 2 i mallen. Allt vi behöver göra är att sätta diagrammets storlek i arbetsboken lika med formens storlek. Följande kodavsnitt tjänar detta ändamål:

```cs
// Definiera diagrammets storlek utan fönster. 
chart.SizeWithWindow = false;

// Sätt diagrammets bredd i pixlar (multiplicera med 96 eftersom Excel använder 96 pixlar per tum).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Sätt diagrammets höjd i pixlar.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Definiera diagrammets utskriftsstorlek.
chart.PrintSize = PrintSizeType.Custom;

// Spara arbetsboken till en minnesström.
MemoryStream workbookStream = workbook.SaveToStream();

// Skapa en OLE-objektram med de inbäddade Excel-data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**  

Anta att vi vill skapa en presentation från början och inkludera en OLE-objektram av valfri storlek med en inbäddad Excel-arbetsbok. I följande kodavsnitt skapar vi en OLE-objektram med en höjd på 4 tum och en bredd på 9,5 tum på bilden vid x = 0,5 tum och y = 1 tum. Vi sätter även det motsvarande diagrammets storlek till samma dimensioner: en höjd på 4 tum och en bredd på 9,5 tum.

```cs
 // Vår önskade höjd.
int desiredHeight = 288; // 4 tum (4 * 576)

// Vår önskade bredd.
int desiredWidth = 684; // 9.5 tum (9.5 * 576)

// Definiera diagrammets storlek utan fönster. 
chart.SizeWithWindow = false;

// Sätt diagrammets bredd i pixlar.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Sätt diagrammets höjd i pixlar.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Spara arbetsboken till en minnesström.
MemoryStream workbookStream = workbook.SaveToStream();

// Skapa en OLE-objektram med de inbäddade Excel-data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Slutsats**

Det finns två tillvägagångssätt för att lösa problemet med diagramomskalning. Valet av tillvägagångssätt beror på krav och användningsfall. Båda tillvägagångssätten fungerar på samma sätt oavsett om presentationerna skapas från en mall eller från början. Dessutom finns det ingen gräns för storleken på OLE-objektramen i denna lösning.

## **FAQ**

**Varför ändrar mitt inbäddade Excel-diagram storlek efter att det aktiverats i PowerPoint?**  
Detta händer eftersom Excel försöker återställa den ursprungliga fönsterstorleken vid första aktivering, medan OLE‑objektramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att behålla bildförhållandet, vilket kan leda till omskalning.

**Är det möjligt att helt förhindra detta omskalningsproblem?**  
Ja. Genom att matcha Excel‑arbetsbokens fönsterstorlek eller diagrammets storlek till OLE‑objektramens storlek innan inbäddning kan du hålla diagrammens storlekar konsekventa.

**Vilket tillvägagångssätt bör jag använda, att sätta arbetsbokens fönsterstorlek eller att sätta diagrammets storlek?**  
Använd **Tillvägagångssätt 1 (fönsterstorlek)** om du vill behålla arbetsbokens bildförhållande och eventuellt tillåta storleksändring senare.  
Använd **Tillvägagångssätt 2 (diagramstorlek)** om diagrammets dimensioner är fasta och inte kommer att förändras efter inbäddning.

**Kommer dessa metoder att fungera med både mallbaserade presentationer och nya presentationer?**  
Ja. Båda tillvägagångssätten fungerar på samma sätt för presentationer skapade från mallar och från början.

**Finns det någon gräns för storleken på OLE‑objektramen?**  
Nej. Du kan sätta OLE‑ramen till vilken storlek som helst så länge den skalas lämpligt till arbetsbokens eller diagrammets storlek.

**Kan jag använda dessa metoder med diagram skapade i andra kalkylprogram?**  
Exemplen är utformade för Excel‑diagram skapade med Aspose.Cells, men principerna gäller även för andra OLE‑kompatibla kalkylprogram så länge de stöder liknande storleksalternativ.

## **Relaterade avsnitt**

- [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Uppdatera OLE-objekt automatiskt med ett PowerPoint‑tillägg](/slides/sv/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)