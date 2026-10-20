---
title: Werkende oplossing voor grafiekgrootte‑aanpassing in PPTX
type: docs
weight: 40
url: /nl/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafiekgrootte aanpassen
- Excel-grafiek
- OLE-object
- grafiek insluiten
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Los onverwachte aanpassing van grafiekgrootte in PPTX op wanneer ingebedde Excel OLE-objecten worden gebruikt met Aspose.Slides for Java. Stel vaste grafiekafmetingen in om de grafiek- en OLE-kadergroottes consistent te houden."
---
## **Achtergrond**

Excel‑grafieken die als OLE‑objecten in PowerPoint‑presentaties zijn ingebed met behulp van Aspose‑componenten, kunnen van grootte veranderen na hun eerste activering. Dit kan een duidelijk verschil veroorzaken in het uiterlijk van de grafiek vóór en na de activering. Dit artikel legt uit waarom het formaat wijzigt en toont hoe u dit kunt voorkomen door vaste grafiekafmetingen af te stemmen op het OLE‑kader.

In [Maak Excel‑grafieken en embed ze als OLE‑objecten in presentaties](/slides/nl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), hebben we uitgelegd hoe u een Excel‑grafiek maakt met Aspose.Cells for Java en deze in een PowerPoint‑presentatie embed met Aspose.Slides for Java. Om het [objectpreview‑probleem](/slides/nl/java/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we de grafiekafbeelding toegewezen aan het OLE‑objectkader van de grafiek. In de uitvoerpresentatie, wanneer u dubbelklikt op het OLE‑objectkader dat de grafiekafbeelding weergeeft, wordt de Excel‑grafiek geactiveerd. Gebruikers kunnen het ingebedde Excel‑werkboek bewerken en vervolgens terugkeren naar de dia door buiten het geopende werkboek te klikken. De grootte van het OLE‑objectkader verandert wanneer de gebruiker terugkeert naar de dia, en de vergrotingsfactor varieert afhankelijk van de oorspronkelijke afmetingen van zowel het OLE‑objectkader als het ingebedde Excel‑werkboek.

## **Oorzaak van de groottewijziging**

Het ingebedde Excel‑werkboek heeft eigen vensterafmetingen, die Excel probeert te behouden wanneer het object voor het eerst wordt geactiveerd. Het OLE‑kader op de dia heeft onafhankelijk gedefinieerde afmetingen. Wanneer het Excel‑werkboek wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte van het object om de verhoudingen te behouden als onderdeel van het embedproces. Verschillen tussen het werkboekvenster en het OLE‑kader kunnen daardoor leiden tot een wijziging van de objectgrootte.

## **Werkende oplossing**

Stem de grafiekgrootte af op het OLE‑kader op de dia en houd de grafiekafmetingen onafhankelijk van het werkboekvenster. Deze oplossing werkt zowel met een nieuwe presentatie als met een bestaand sjabloon.

Het voorbeeld vereist Aspose.Cells for Java en Aspose.Slides for Java. Het maakt een eenvoudige kolomgrafiek op een actief grafiekblad en embed het werkboek in XLS‑formaat. Er wordt geen voorbeeldafbeelding voor de grafiek toegewezen; de grafiek wordt zichtbaar wanneer het OLE‑object wordt geactiveerd in PowerPoint.

Het voorbeeld creëert een nieuwe presentatie met een OLE‑kader van 9,5 × 4 inch, gepositioneerd 0,5 inch vanaf de linkerrand en 1 inch vanaf de bovenkant. Dia‑coördinaten en afmetingen worden uitgedrukt in points (72 points per inch). Voor een bestaande presentatie, zie [Gebruik een sjabloon](#gebruik-een-sjabloon).

## **Stel een vaste grafiekgrootte in**

Stel [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) in op false zodat de grafiekafmetingen onafhankelijk zijn van het werkboekvenster. Stel de afmetingen van [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) in via [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) en [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), waarbij points worden omgezet naar pixels met 96 pixels per inch: een kader van 684 × 288 points komt overeen met een grafiek van 912 × 384 pixels. Stel [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) in op de CUSTOM‑waarde van [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Het voorbeeld embed het werkboek met [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) en slaat een presentatie op met een OLE‑kader van 9,5 × 4 inch.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Dia‑coördinaten en afmetingen zijn in points (72 points per inch).
        float width = 684f; // 9,5 inch.
        float height = 288f; // 4 inch.

        chart.setSizeWithWindow(false);
        // Zet points om naar grafiekpixels met 96 pixels per inch.
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **Gebruik een sjabloon**

De logica voor het bepalen van de grootte is hetzelfde voor een bestaande presentatie. Pas het voorbeeld als volgt aan:

1. Laad de sjabloonpresentatie in plaats van een lege presentatie te maken.  
2. Controleer of de eerste dia ten minste drie vormen bevat, en gebruik vervolgens de vorm op index 2 als de tijdelijke aanduiding.  
3. Neem de kaderbreedte en -hoogte uit die vorm in plaats van de vaste waarden 684 en 288 te gebruiken. Houd de berekeningen voor de afmetingen ongewijzigd.  
4. Voeg het OLE‑kader toe op de positie van de tijdelijke aanduiding in plaats van op de vaste coördinaten 36 en 72.  
5. Verwijder de tijdelijke aanduiding voordat u de presentatie opslaat.

## **Veelgestelde vragen**

**Waarom verandert mijn ingebedde Excel‑grafiek van grootte na activering in PowerPoint?**

Dit gebeurt omdat Excel bij de eerste activering probeert de oorspronkelijke venstergrootte te herstellen, terwijl het OLE‑objectkader in PowerPoint eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat de groottewijziging kan veroorzaken.

**Hoe kan ik de grafiek‑ en OLE‑kadergroottes consistent houden?**

Stel vaste grafiekafmetingen in die overeenkomen met het OLE‑kader en gebruik een aangepaste afdrukgrootte voor de grafiek voordat u het werkboek embedt. Het bovenstaande voorbeeld toont de benodigde instellingen en eenhedenconversies.

**Is het afstemmen op de werkboekvenstergrootte voldoende?**

Alleen het afstemmen op de werkboekvenstergrootte voorkomt niet betrouwbaar dat het OLE‑kader van grootte verandert na activering. Gebruik vaste grafiekafmetingen zoals getoond in het voorbeeld.

**Werkt deze oplossing zowel voor sjabloongebaseerde presentaties als voor nieuwe presentaties?**

Ja. Voor een sjabloon gebruikt u de afmetingen en positie van de tijdelijke aanduiding. Voor een nieuwe presentatie specificeert u de kaderafmetingen en positie direct.

**Kan ik dit voorbeeld gebruiken met grafieken die zijn gemaakt in andere spreadsheet‑programma’s?**

Het voorbeeld maakt gebruik van een Excel‑werkboek dat is aangemaakt met Aspose.Cells. Het demonstreert niet het activatie‑gedrag voor andere spreadsheet‑programma’s.

## **Gerelateerde secties**

- [Maak Excel‑grafieken en embed ze als OLE‑objecten in presentaties](/slides/nl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)