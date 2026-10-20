---
title: Működő megoldás a diagram átméretezésére PPTX-ben
type: docs
weight: 40
url: /hu/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezés
- Excel diagram
- OLE objektum
- diagram beágyazása
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: Javítja a PPTX-ben előforduló váratlan diagram átméretezést, ha beágyazott Excel OLE-objektumokkal dolgozik az Aspose.Slides for Java-val. Állítson be rögzített diagramméreteket a diagram és az OLE-keret méretének konzisztens megtartásához.
---
## **Háttér**

Az Excel-diagramok, amelyek OLE-objektumként vannak beágyazva a PowerPoint‑prezentációkba Aspose‑komponensekkel, az első aktiválásuk után méretet változtathatnak. Ez észrevehető különbséget okozhat a diagram megjelenésében aktiválás előtt és után. Ez a cikk elmagyarázza, miért történik a méretezés, és bemutatja, hogyan lehet megelőzni azt úgy, hogy a rögzített diagramméreteket az OLE‑kerethez igazítjuk.

Az [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hu/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) cikkben bemutattuk, hogyan lehet Excel-diagramot létrehozni az Aspose.Cells for Java‑val, és beágyazni azt PowerPoint‑prezentációba az Aspose.Slides for Java‑val. Az [object preview issue](/slides/hu/java/object-preview-issue-when-adding-oleobjectframe/) megoldásaként a diagramképet rendeltük hozzá a diagram OLE‑objektumkeretéhez. A kimeneti prezentációban, ha duplán kattintunk a diagramképet megjelenítő OLE‑objektumkeretre, az Excel-diagram aktiválódik. A felhasználók szerkeszthetik a beágyazott Excel‑könyvvet, majd a aktivált könyvven kívülre kattintva visszatérhetnek a diára. Az OLE‑objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára, és a méretezési arány változik az eredeti OLE‑keret és a beágyazott Excel‑könyv mérete szerint.

## **A méretezés oka**

A beágyazott Excel‑könyvnek saját ablakmérete van, amelyet az Excel megpróbál megtartani, amikor az objektum első alkalommal aktiválódik. A dián lévő OLE‑keret független méreteket definiál. Amikor az Excel‑könyv aktiválódik, az Excel és a PowerPoint egyeztetik az objektum méretét, hogy a méretarányt megőrizzék az beágyazási folyamat részeként. Így a könyv ablakának és az OLE‑keretnek a méretei közti különbségek az objektum átméreteződését okozhatják.

## **Működő megoldás**

Igazítsuk a diagram méretét a dián lévő OLE‑kerethez, és tartsuk a diagram méreteit függetlenül a könyvablaktól. Ez a megoldás új prezentációval vagy meglévő sablonnal egyaránt működik.

A példához szükség van az Aspose.Cells for Java‑ra és az Aspose.Slides for Java‑ra. Egyszerű oszlopdiagramot hoz létre egy aktív diagramlapon, és beágyazza a könyvet XLS formátumban. Nem kerül diagram-előnézeti kép hozzárendelésre; a diagram láthatóvá válik, amikor az OLE‑objektum aktiválódik PowerPoint‑ban.

A példa egy új prezentációt hoz létre 9,5 × 4‑hüvelykes OLE‑kerettel, amely 0,5 hüvelykre van elhelyezve a bal szélétől és 1 hüvelykre a tetejétől. A dia koordinátái és méretei pontban vannak (72 pont per hüvelyk). Meglévő prezentáció esetén lásd a [Use a Template](#use-a-template) részt.

## **Rögzített diagramméret beállítása**

Állítsuk a [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) értékét **false**‑ra, hogy a diagram méretei függetlenek legyenek a könyvablaktól. A [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) méreteit a [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) és a [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-) segítségével állítsuk be, a pontokat pixelre konvertálva 96 pixel per hüvelyk alapján: egy 684 × 288 pont méretű keret 912 × 384 pixel méretű diagramnak felel meg. Állítsuk a [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) értékét a **CUSTOM** értékre a [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/)-ból. A példa a [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) segítségével ágyazza be a könyvet, és egy 9,5 × 4‑hüvelykes OLE‑kerettel menti a prezentációt.

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

        // A dia koordinátái és méretei pontokban vannak (72 pont per hüvelyk).
        float width = 684f; // 9,5 hüvelyk.
        float height = 288f; // 4 hüvelyk.

        chart.setSizeWithWindow(false);
        // Konvertálja a pontokat diagrampixelre 96 pixel per hüvelyk használatával.
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

## **Sablon használata**

A méretezési logika ugyanaz egy meglévő prezentációnál is. A példa adaptálásához:

1. Töltsük be a sablon‑prezentációt az üres prezentáció létrehozása helyett.  
2. Ellenőrizzük, hogy az első dia legalább három alakzatot tartalmaz‑e, majd a 2‑es indexű alakzatot használjuk helykitöltőként.  
3. A keret szélességét és magasságát vegyük azt az alakzatotól a fix 684 és 288 értékek helyett. A méretezési számításokat változatlanul hagyjuk.  
4. Adjunk hozzá OLE‑keretet a helykitöltő pozíciójához a fix 36 és 72 koordináták helyett.  
5. Távolítsuk el a helykitöltőt a prezentáció mentése előtt.

## **GYIK**

**Miért változik a beágyazott Excel‑diagram mérete a PowerPoint‑ban történő aktiválás után?**

Ez azért történik, mert az Excel megpróbálja visszaállítani az eredeti ablakméretet az első aktiváláskor, míg a PowerPoint‑ban az OLE‑objektumkeret saját méretekkel rendelkezik. A PowerPoint és az Excel egyeztetik a méretet a méretarány megtartása érdekében, ami a méretezést okozza.

**Hogyan tartható a diagram és az OLE‑keret mérete egységes?**

Állítsunk be fix diagramméreteket, amelyek megegyeznek az OLE‑kerettel, és használjunk egyedi diagramnyomtatási méretet a könyv beágyazása előtt. A fenti példa mutatja a szükséges beállításokat és egységkonverziókat.

**Elégséges-e a könyvablak méretének egyeztetése?**

A könyvablak méretének egyeztetése önmagában nem garantálja, hogy az OLE‑keret ne változzon méretben aktiválás után. Használjunk fix diagramméreteket, ahogy a példában látható.

**Működik ez a megoldás sablon‑alapú és új prezentációk esetén is?**

Igen. Sablonnál a helykitöltő méreteit és pozícióját használjuk. Új prezentációnál közvetlenül adjuk meg a keret méreteit és pozícióját.

**Használhatom ezt a példát más táblázatkezelő programokban létrehozott diagramokkal?**

A példa egy Aspose.Cells‑szel létrehozott Excel‑könyvet használ. Nem mutatja más táblázatkezelő programok aktiválási viselkedését.

## **Kapcsolódó szakaszok**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hu/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)