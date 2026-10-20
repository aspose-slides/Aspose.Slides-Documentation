---
title: Működő megoldás a diagram átméretezésének PPTX-ben
type: docs
weight: 40
url: /hu/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezés
- Excel diagram
- OLE objektum
- diagram beágyazása
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Javítsa ki a váratlan diagram átméretezést PPTX-ben, amikor beágyazott Excel OLE objektumokat használ az Aspose.Slides for Android Java‑on keresztül. Állítson be rögzített diagramméreteket a diagram és az OLE keret méretének konzisztens megtartásához."
---
## **Áttekintés**

Az Aspose komponenseket használó PowerPoint‑prezentációkban OLE objektumként beágyazott Excel diagramok az első aktiválásuk után méretet változtathatnak. Ez a diagram megjelenésében észrevehető különbséget okozhat az aktiválás előtti és utáni állapot között. Ez a cikk elmagyarázza, miért történik a méretezés, és bemutatja, hogyan lehet megakadályozni azt úgy, hogy a rögzített diagramméreteket az OLE kerethez igazítjuk.

A [Excel diagramok létrehozása és OLE objektumként történő beágyazása a prezentációkba](/slides/hu/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) című cikkben ismertettük, hogyan lehet egy Excel diagramot létrehozni az Aspose.Cells for Android segítségével Java‑ban, és beágyazni azt egy PowerPoint‑prezentációba az Aspose.Slides for Android Java‑os változatával. Az [objektum előnézeti probléma](/slides/hu/androidjava/object-preview-issue-when-adding-oleobjectframe/) megoldásaként a diagram képét a diagram OLE objektumkeretéhez rendeltük. A kimeneti prezentációban, ha duplán kattint a diagram képet mutató OLE objektumkeretre, az Excel diagram aktiválódik. A felhasználók szerkeszthetik a beágyazott Excel munkafüzetet, majd a diához visszatérhetnek a aktivált munkafüzeten kívülre kattintva. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diához, és a méretezési tényező az OLE objektumkeret és a beágyazott Excel munkafüzet eredeti méreteitől függ.

## **Átméretezés oka**

A beágyazott Excel munkafüzet saját ablakmérettel rendelkezik, amelyet az Excel megpróbál megtartani, amikor az objektum első alkalommal aktiválódik. A diához tartozó OLE keret önállóan definiált méretekkel rendelkezik. Amikor az Excel munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik az objektum méretét, hogy megőrizzék a méretarányt a beágyazási folyamat részeként. A munkafüzet ablak és az OLE keret közötti eltérések ezért méretezési változást okozhatnak.

## **Működő megoldás**

Illessze a diagram méretét a diához tartozó OLE kerethez, és tartsa a diagram méreteit függetlenül a munkafüzet ablakától. Ez a megoldás új prezentációval vagy meglévő sablonnal egyaránt működik.

A példa az Aspose.Cells for Android Java‑os változatát, valamint az Aspose.Slides for Android Java‑os változatát igényli. Egy egyszerű oszlopdiagramot hoz létre egy aktív diagramlapon, és beágyazza a munkafüzetet XLS formátumban. Hívja a `FixedChartSize.createPresentation(getFilesDir())` metódust egy Android‑aktivitásból a kimenet az alkalmazás belső fájlkönyvtárába mentéséhez. Az OLE aktiváláshoz asztali PowerPoint és egy kompatibilis Excel‑telepítés szükséges. Diagram előnézeti kép nincs hozzárendelve; a diagram akkor válik láthatóvá, amikor az OLE objektum aktiválódik a PowerPointban.

A példa egy új prezentációt hoz létre 9.5 × 4 hüvelykes OLE kerettel, amely a bal szélétől 0.5 hüvelyk, a tetejétől 1 hüvelyk távolságra helyezkedik. A dia koordinátái és méretei pontokban vannak megadva (72 pont hüvelykenként). Egy meglévő prezentációhoz lásd a [Sablon használata](#use-a-template) szakaszt.

## **Rögzített diagramméret beállítása**

Helyezze a [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) értékét false-ra, hogy a diagram méretei függetlenek legyenek a munkafüzet ablakától. Állítsa be a [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) méreteit a [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) és a [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-) segítségével, átváltva a pontokat pixelekre 96 pixel hüvelykenként: a 684 × 288 pont méretű keret 912 × 384 pixelnek megfelelő diagramot jelent. Állítsa a [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) értékét a [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/) CUSTOM értékére. A példa a [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) metódussal ágyazza be a munkafüzetet, és egy 9.5 × 4 hüvelykes OLE kerettel menti a prezentációt.

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
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
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

                    // Dia koordinátái és méretei pontban vannak megadva (72 pont hüvelykenként).
                    float width = 684f; // 9,5 hüvelyk.
                    float height = 288f; // 4 hüvelyk.

                    chart.setSizeWithWindow(false);
                    // Átváltás pontokból diagram pixelre 96 pixel hüvelykenként.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Sablon használata**

Az átméretezési logika ugyanaz a meglévő prezentációk esetén is. A példa testreszabásához:

1. Töltse be a sablonprezentációt egy üres prezentáció helyett.  
1. Ellenőrizze, hogy az első dia legalább három alakzatot tartalmaz, majd a 2‑es indexű alakzatot használja helykitöltőként.  
1. Vegye a keret szélességét és magasságát erről az alakzatról a 684 és 288 rögzített értékek helyett. Tartsa változatlanul a méretezési számításokat.  
1. Adja hozzá az OLE keretet a helykitöltő pozíciójához a 36 és 72 rögzített koordináták helyett.  
1. Távolítsa el a helykitöltőt a prezentáció mentése előtt.

## **GYIK**

**Miért változik meg a beágyazott Excel diagram mérete a PowerPoint‑ban történő aktiválás után?**  
Ez azért történik, mert az Excel az első aktiváláskor megpróbálja visszaállítani az eredeti ablakméretet, míg a PowerPoint OLE objektumkerete saját méretekkel rendelkezik. A PowerPoint és az Excel egyeztetik a méretet az arány megtartása érdekében, ami a méretezést okozhat.

**Hogyan tarthatom egységben a diagram és az OLE keret méreteit?**  
Ezt úgy érheti el, hogy rögzített diagramméreteket állít be, amelyek megegyeznek az OLE kerettel, és a munkafüzet beágyazása előtt egy egyéni diagramnyomtatási méretet használ. A fenti példa bemutatja a szükséges beállításokat és egységátváltásokat.

**Elégséges a munkafüzet ablakméretének egyeztetése?**  
A munkafüzet ablakméretének egyeztetése önmagában nem biztosítja megbízhatóan, hogy az OLE keret ne változtassa meg méretét az aktiválás után. Használjon rögzített diagramméreteket, ahogy a példában látható.

**Ez a megoldás működik sablonalapú és új prezentációk esetén is?**  
Igen. Sablon esetén használja a helykitöltő méreteit és pozícióját. Új prezentáció esetén adja meg közvetlenül a keret méretét és pozícióját.

**Használhatom ezt a példát más táblázatkezelő programokban létrehozott diagramokkal?**  
A példa egy Aspose.Cells‑kel létrehozott Excel munkafüzetet használ. Nem mutatja be más táblázatkezelő programok aktiválási viselkedését.

## **Kapcsolódó szakaszok**

- [Excel diagramok létrehozása és OLE objektumként történő beágyazása a prezentációkba](/slides/hu/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)