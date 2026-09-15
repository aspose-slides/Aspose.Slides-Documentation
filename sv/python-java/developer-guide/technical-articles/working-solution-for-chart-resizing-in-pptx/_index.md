---
title: Fungerande lösning för diagramomformning i PPTX
type: docs
weight: 40
url: /sv/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagramomformning
- Excel-diagram
- OLE-objekt
- bädda in diagram
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Fixa oväntad diagramomformning i PPTX när du använder inbäddade Excel OLE-objekt med Aspose.Slides för Python via Java. Lär dig två metoder med kod för att hålla storlekarna konsekventa."
---
## **Bakgrund**

Det har observerats att Excel-diagram som bäddas in som OLE-objekt i en PowerPoint-presentation via Aspose-komponenter ändras till en ospecificerad skala efter deras första aktivering. Detta beteende orsakar en märkbar visuell skillnad i presentationen mellan diagrammets för- och efteraktiveringsstatus. Aspose-teamet har undersökt problemet i detalj och har hittat en lösning. Denna artikel beskriver orsakerna till problemet och den motsvarande åtgärden.

I den [föregående artikeln](/slides/sv/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) förklarade vi hur man skapar ett Excel-diagram med Aspose.Cells för Python via Java och bäddar in det i en PowerPoint-presentation med Aspose.Slides för Python via Java. För att åtgärda [problemet med förhandsgranskning av objekt](/slides/sv/python-java/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi diagrambilden till diagrammets OLE-objektram. I den resulterande presentationen, när du dubbelklickar på OLE-objektramen som visar diagrambilden, aktiveras Excel-diagrammet. Slutanvändare kan göra önskade ändringar i den underliggande Excel-arbetsboken och sedan återgå till motsvarande bild genom att klicka utanför den aktiverade arbetsboken. Storleken på OLE-objektramen förändras när användaren återvänder till bilden, och omformningsfaktorn varierar beroende på de ursprungliga storlekarna för både OLE-objektramen och den inbäddade Excel-arbetsboken.

## **Orsak till storleksändring**

Eftersom Excel-arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. OLE-objektramen har dock sin egen storlek. Enligt Microsoft, när Excel-arbetsboken aktiveras, förhandlar Excel och PowerPoint om storleken och upprätthåller korrekta proportioner som en del av inbäddningsprocessen. Beroende på skillnaderna mellan Excel-fönstrets storlek och OLE-objektramens storlek eller position uppstår en omformning.

## **Fungerande lösning**

Det finns två möjliga scenarier för att skapa PowerPoint-presentationer med Aspose.Slides för Python via Java.

**Scenario 1:** Skapa en presentation baserad på en befintlig mall.

**Scenario 2:** Skapa en presentation från början.

Lösningen vi tillhandahåller här gäller för båda scenarierna. Grunden för alla lösningsmetoder är densamma: **det inbäddade OLE-objektets fönsterstorlek ska matcha OLE-objektramen i PowerPoint-bilden**. Vi kommer nu att diskutera de två angreppsätten för denna lösning.

## **Första tillvägagångssättet**

I detta tillvägagångssätt kommer vi att lära oss hur man ställer in fönsterstorleken för den inbäddade Excel-arbetsboken så att den matchar storleken på OLE-objektramen i PowerPoint-bilden.

**Scenario 1**

Anta att vi har definierat en mall och vill skapa presentationer baserade på den. Föreställ dig att det finns en form på index 2 i mallen där vi vill placera en OLE-ram som innehåller en inbäddad Excel-arbetsbok. I detta scenario är storleken på OLE-objektramen fördefinierad – den matchar storleken på formen på index 2 i mallen. Allt vi behöver göra är att ställa in arbetsbokens fönsterstorlek till samma storlek som formen. Följande kodsnutt tjänar detta ändamål:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jp    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

    # Ladda Excel-arbetsboken som innehåller diagrammet.
    chart = workbook.getWorksheets().get(0).getCharts().get(0)

    presentation = Presentation("template.pptx")
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().get_Item(2)

        # Ange arbetsbokens fönsterstorlek i tum (PowerPoint använder 72 punkter per tum).
        workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
        workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

        # Spara arbetsboken till en minnesström.
        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

        # Skapa en OLE-objektram med den inbäddade Excel-datan.
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
    finally:
        presentation.dispose()
```

**Scenario 2**

Låt oss säga att vi vill skapa en presentation från början och inkludera en OLE-objektram av godtycklig storlek med en inbäddad Excel-arbetsbok. I följande kodsnutt skapar vi en OLE-objektram som är 4 tum hög och 9,5 tum bred vid x = 0,5 tum och y = 1 tum på bilden. Vi ställer sedan in Excel-arbetsbokens fönster till samma storlek – 4 tum hög och 9,5 tum bred.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Ladda Excel-arbetsboken som innehåller diagrammet.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 tum (4 * 72).
    desired_width = 684  # 9,5 tum (9.5 * 72).

    # Definiera diagramstorleken med ett fönster.
    chart.setSizeWithWindow(True)

    # Ställ in arbetsbokens fönsterstorlek i tum (PowerPoint använder 72 punkter per tum).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Spara arbetsboken till en minnesström.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Skapa en OLE-objektram med den inbäddade Excel-datan.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Andra tillvägagångssättet**

I detta tillvägagångssätt kommer vi att lära oss hur man ställer in diagrammets storlek i den inbäddade Excel-arbetsboken så att den matchar storleken på OLE-objektramen i PowerPoint-bilden. Detta tillvägagångssätt är användbart när diagrammets storlek är känd i förväg och aldrig kommer att ändras.

**Scenario 1**

Anta att vi har definierat en mall och vill skapa presentationer baserade på den. Föreställ dig att det finns en form på index 2 i mallen där vi avser att placera en OLE-ram som innehåller en inbäddad Excel-arbetsbok. I detta scenario är OLE-ramens storlek fördefinierad – den matchar storleken på formen på index 2 i mallen. Allt vi behöver göra är att ställa in diagrammets storlek i arbetsboken till samma storlek som formen. Följande kodsnutt tjänar detta ändamål:

```python
import jpype
import asposecells
import asposeslides

if not jpage.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Ladda Excel-arbetsboken som innehåller diagrammet.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Definiera diagramstorleken utan ett fönster.
    chart.setSizeWithWindow(False)

    # Ställ in diagramstorleken i pixlar (Excel använder 96 pixlar per tum).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Definiera diagrammets utskriftsstorlek.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Spara arbetsboken till en minnesström.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Skapa en OLE-objektram med den inbäddade Excel-datan.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**:

Anta att vi vill skapa en presentation från början och inkludera en OLE-objektram av godtycklig storlek med en inbäddad Excel-arbetsbok. I följande kodsnutt skapar vi en OLE-objektram med en höjd på 4 tum och en bredd på 9,5 tum på bilden vid x = 0,5 tum och y = 1 tum. Vi ställer också in motsvarande diagramstorlek till samma dimensioner: en höjd på 4 tum och en bredd på 9,5 tum.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Ladda Excel-arbetsboken som innehåller diagrammet.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 tum (4 * 72).
    desired_width = 684  # 9.5 tum (9.5 * 72).

    # Definiera diagramstorleken utan ett fönster.
    chart.setSizeWithWindow(False)

    # Ställ in diagramstorleken i pixlar (Excel använder 96 pixlar per tum).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Spara arbetsboken till en minnesström.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Skapa en OLE-objektram med den inbäddade Excel-datan.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Slutsats**

Det finns två tillvägagångssätt för att åtgärda problemet med diagrammets storleksändring. Valet av tillvägagångssätt beror på kraven och användningsfallet. Båda tillvägagångssätt fungerar på samma sätt oavsett om presentationerna skapas från en mall eller från början. Dessutom finns det ingen begränsning för storleken på OLE-objektramen i denna lösning.

## **FAQ**

**Varför förändras mitt inbäddade Excel-diagram i storlek efter att det aktiverats i PowerPoint?**

Detta händer eftersom Excel försöker återställa den ursprungliga fönsterstorleken vid första aktiveringen, medan OLE-objektramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att upprätthålla bildförhållandet, vilket kan orsaka omformning.

**Är det möjligt att helt förhindra detta omformningsproblem?**

Ja. Genom att matcha Excel-arbetsbokens fönsterstorlek eller diagrammets storlek till OLE-objektramens storlek innan inbäddning kan du hålla diagrammens storlek konsistent.

**Vilket tillvägagångssätt bör jag använda, att ställa in arbetsbokens fönsterstorlek eller diagrammets storlek?**

Använd **Tillvägagångssätt 1 (fönsterstorlek)** om du vill behålla arbetsbokens bildförhållande och eventuellt tillåta omformning senare.  
Använd **Tillvägagångssätt 2 (diagramstorlek)** om diagrammets dimensioner är fasta och inte kommer att förändras efter inbäddning.

**Fungerar dessa metoder både med mallbaserade presentationer och nya presentationer?**

Ja. Båda tillvägagångssätten fungerar på samma sätt för presentationer skapade från mallar och från början.

**Finns det någon begränsning för storleken på OLE-objektramen?**

Nej. Du kan sätta OLE-ramen till vilken storlek som helst så länge den skalas korrekt till arbetsbokens eller diagrammets storlek.

**Kan jag använda dessa metoder med diagram skapade i andra kalkylprogram?**

Exemplen är avsedda för Excel-diagram skapade med Aspose.Cells, men principerna gäller även för andra OLE‑kompatibla kalkylprogram så länge de stödjer liknande storleksalternativ.

## **Relaterade avsnitt**

- [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)