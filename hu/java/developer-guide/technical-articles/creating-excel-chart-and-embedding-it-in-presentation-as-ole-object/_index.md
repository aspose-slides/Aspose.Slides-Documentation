---
title: Excel diagramok létrehozása és beágyazása prezentációkba OLE objektumként
type: docs
weight: 30
url: /hu/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel diagram
- diagram beágyazása
- OLE objektum
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Excel diagram létrehozása az Aspose.Cells for Java segítségével, és a munkafüzet beágyazása egy PowerPoint prezentációba az Aspose.Slides-val, diagram előnézettel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhat létre egy Excel oszlopdiagramot az Aspose.Cells for Java segítségével, és ágyazhatja be a munkafüzetet egy PowerPoint bemutatóba az Aspose.Slides for Java segítségével. A beágyazott munkafüzet tartalmazza a forrásadatokat és a diagramot is. Egy külön PNG előnézet jeleníti meg a diagramot a dián, mielőtt az OLE objektum aktiválódna.

Az eredmény egy beágyazott Excel objektum, nem natív PowerPoint diagram. A munkafüzet OLE-on keresztüli szerkesztéséhez olyan asztali alkalmazás szükséges, amely támogatja az OLE aktiválást, és kompatibilis Excel telepítéssel.

## **Előfeltételek**

Adja hozzá az Aspose.Cells for Java‑t és az Aspose.Slides for Java‑t a projektfüggőségekhez. Futtassa a példát egy Java metódusban. A Microsoft Office nem szükséges a bemutató előállításához ezekkel a könyvtárakkal.

Nincs szükség bemeneti fájlokra: a példa memóriában hozza létre az adatokat és a diagramot, majd a `OutputChart.pptx` fájlt a jelenlegi munkakönyvtárba írja. Licencet kell alkalmazni mindkét termékre, ha a kiértékelési módon kívül fut.

## **Hogyan működik a beágyazás**

1. Hozzon létre egy munkafüzetet egy adat munkalappal és egy diagramlaplappal.  
1. Tegye a diagramlapot aktívvá, hogy a munkafüzet a diagramon nyíljon meg.  
1. Állítsa be a munkafüzet OLE megjelenítési tartományát, és renderelje a diagramot PNG‑be.  
1. Mentse a munkafüzetet XLSX formátumban memóriába, és ágyazza be ezeket a bájtokat egy diára.  
1. Rendelje hozzá a PNG‑t az OLE objektum előnézeteként, és mentse a bemutatót PPTX‑ként.

A munkafüzet megjelenítési tartománya és a dián lévő keret különböző szerepeket töltenek be. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) nulláralapú kezdő/ befejező sor- és oszlopindexeket vár. A [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) ehelyett a felső sort, bal oszlopot, alsó sort és jobb oszlopot veszi. A példa a 55‑ös sorszámot és a 25‑ös oszlopszámot használja alsó‑jobb határként; ezek az értékek elrendezési választások, nem az adat sorok vagy oszlopok száma.

A diakeret pontokat használ. A példa a dián belül méretezi, és középre helyezi, miközben megőrzi a PNG arányait, ahelyett, hogy a előnézetet a dia kitöltésére nyújtaná.

## **Diagram létrehozása és beágyazása**

Az alábbi teljes példa a `DataSheet`‑t négy sorral és öt oszloppal tölti fel értékekkel. Minden sor diagram sorozattá válik. A `ChartSheet` kerül kiválasztásra aktív munkalapként a munkafüzet mentése előtt.

A munkafüzet kifejezetten XLSX‑ként mentésre kerül, ami megfelel a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/)‑nek átadott `xlsx` kiterjesztésnek. A PNG közvetlenül a bájtjaiból töltődik be köztes bitmap átalakítás nélkül. A [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)‑on keresztüli hozzárendelés felülírja az alapértelmezett OLE helykitöltőt.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // A diagram előnézetének renderelése és a szerkeszthető munkafüzet külön sorosítása.
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // Illessze a előnézetet a diára az arányok megváltoztatása nélkül.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```

## **Várt eredmény**

`OutputChart.pptx` egy diát tartalmaz egy beágyazott Excel munkafüzettel és egy diagram előnézettel. A munkafüzet az eredeti adatokat és egy négy sorozatos oszlopdiagramot tartalmaz. Az előnézet középre van helyezve a dián, és megtartja arányait.

![Excel oszlopdiagram, amely a beágyazott munkafüzet előnézeteként jelenik meg](excel-chart-ole-preview.png)

Egy kompatibilis asztali PowerPoint környezetben, ahol az Excel elérhető, duplakattintással aktiválhatja és szerkesztheti a beágyazott munkafüzetet. Az aktiválás és a szerkesztés a hostalkalmazás OLE‑támogatásától és biztonsági beállításaitól függ.

## **GYIK**

**Miért szükséges egy előnézeti kép?**

A beágyazott munkafüzet és a dián lévő előnézet külön tartalom. Biztosítson egy diagramképet, hogy a dia a diagramot mutassa az alapértelmezett „EMBEDDED OLE OBJECT” helykitöltő helyett. Lásd a [Objektum előnézeti probléma az OleObjectFrame hozzáadásakor](/slides/hu/java/object-preview-issue-when-adding-oleobjectframe/).

**Frissül automatikusan az előnézet, ha a kódban módosítom a munkafüzetet?**

Kezelje az előnézetet pillanatként. Ha programozottan frissíti a munkafüz let adatokat, generálja újra a diagramképet, és cserélje ki az előnézetet, valamint a beágyazott munkafüzet adatokat.

**Használhatok XLS‑et XLSX helyett?**

Igen. Mentse a munkafüzetet XLS formátumban, és használja a `xls` kiterjesztést a beágyazott adatként. A kiterjesztésnek meg kell egyeznie a tényleges munkafüzet formátummal; a kiterjesztés önmagában nem konvertálja az adatot.

**Miért változhat meg az objektum mérete aktiválás után?**

A hostalkalmazás frissítheti az OLE objektum megjelenését, amikor aktiválja a munkafüzetet. A munkafüzet OLE megjelenítési tartománya és a diakeret méretei is számítanak. Lásd a [Működő megoldás a diagram átméretezésére PPTX‑ben](/slides/hu/java/working-solution-for-chart-resizing-in-pptx/).

## **Kapcsolódó szakaszok**

- [Működő megoldás a diagram átméretezésére PPTX‑ben](/slides/hu/java/working-solution-for-chart-resizing-in-pptx/)
- [Objektum előnézeti probléma az OleObjectFrame hozzáadásakor](/slides/hu/java/object-preview-issue-when-adding-oleobjectframe/)
- [OLE objektumok automatikus frissítése PowerPoint kiegészítővel](/slides/hu/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)