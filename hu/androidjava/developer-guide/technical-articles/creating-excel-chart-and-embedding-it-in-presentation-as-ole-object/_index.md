---
title: Excel-diagramok létrehozása és beágyazása prezentációkba OLE objektumként
type: docs
weight: 30
url: /hu/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- diagram beágyazása
- OLE-objektum
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Hozzon létre egy Excel-diagramot az Aspose.Cells for Android Java használatával, és ágyazza be a munkafüzetet egy PowerPoint prezentációba az Aspose.Slides for Android Java segítségével, diagram előnézettel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre Excel oszlopdiagramot az Aspose.Cells for Android Java segítségével, és ágyazhatjuk be a munkafüzetet egy PowerPoint prezentációba az Aspose.Slides for Android Java segítségével. A beágyazott munkafüzet tartalmazza a forrásadatokat és a diagramot is. Egy külön PNG előnézet jeleníti meg a diagramot a dián, mielőtt az OLE objektum aktiválódna.

Az eredmény egy beágyazott Excel objektum, nem natív PowerPoint diagram. A munkafüzet OLE-on keresztüli szerkesztéséhez olyan asztali alkalmazásra van szükség, amely támogatja az OLE aktiválást, és kompatibilis Excel telepítéssel.

## **Előfeltételek**

Adja hozzá az Aspose.Cells for Android Java és az Aspose.Slides for Android Java könyvtárakat a projekt függőségeihez. Hívja meg a `ExcelChartEmbedding.createPresentation(getFilesDir())` metódust egy Android aktivitásból. A Microsoft Office nem szükséges a prezentáció előállításához ezen könyvtárakkal.

Nem szükséges bemeneti fájl: a példa memóriában hozza létre az adatokat és a diagramot, majd a `OutputChart.pptx` fájlt az alkalmazás belső fájlkönyvtárába írja. Licencet kell alkalmazni mindkét termékre, ha nem értékelő módban futtatja.

## **Hogyan működik a beágyazás**

1. Hozzon létre egy munkafüzetet egy adat munkalappal és egy diagram munkalappal.  
2. Tegye a diagram munkalapot aktívvá, hogy a munkafüzet a diagramot jelenítse meg.  
3. Állítsa be a munkafüzet OLE megjelenítési tartományát, és renderelje a diagramot PNG formátumba.  
4. Mentse a munkafüzetet memóriában XLSX formátumban, és ágyazza be ezeket a bájtokat egy diára.  
5. Rendelje hozzá a PNG-t az OLE objektum előnézeteként, és mentse a prezentációt PPTX formátumban.

A munkafüzet megjelenítési tartománya és a diákeret külön szerepet tölt be. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) nullától kezdődő kezdő/értő sor- és oszlopindexeket vár. A [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) ehelyett a felső sor, bal oszlop, alsó sor és jobb oszlop értékeket veszi. A példa 55-ös sorindexet és 25-ös oszlopindexet használ a jobb alsó határként; ezek az értékek elrendezési választások, nem az adat sorok vagy oszlopok száma.

A diákeret pontokat használ. A példa a dián belül elhelyezi és középre igazítja, miközben megőrzi a PNG képarányát, ahelyett, hogy nyújtaná az előnézetet a teljes diára.

## **Diagram létrehozása és beágyazása**

Az alábbi teljes példa a `DataSheet` munkalapot négy sor és öt oszlop értékkel tölti fel. Minden sor egy diagram sorozattá válik. A `ChartSheet` a munkafüzet mentése előtt aktív munkalapként kerül kiválasztásra.

A munkafüzet explicit módon XLSX‑ként van mentve, amely megfelel az [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/)‑nek átadott `xlsx` kiterjesztésnek. A PNG közvetlenül a bájtjaiból kerül betöltésre, közbenső bitmap átalakítás nélkül. A [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) használatával a alapértelmezett OLE helyőrző helyettesítődik.

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
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
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

                // Készítse el a diagram előnézetét, és külön sorosítsa a szerkeszthető munkafüzetet.
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

                        // Igazítsa az előnézetet a dia méretéhez anélkül, hogy megváltoztatná a képarányt.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
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
    }
}
```

## **Várható eredmény**

`OutputChart.pptx` egy diát tartalmaz, amely beágyazott Excel munkafüzetet és egy diagram előnézetet tartalmaz. A munkafüzet az eredeti adatokat és egy négy sorozatú oszlopdiagramot tartalmaz. Az előnézet a dián középen helyezkedik el és megtartja arányait.

![Excel oszlopdiagram, amely a beágyazott munkafüzet előnézeti képeként jelenik meg](excel-chart-ole-preview.png)

Kompatibilis asztali PowerPoint környezetben, ahol az Excel elérhető, duplán kattintson az objektumra a beágyazott munkafüzet aktiválásához és szerkesztéséhez. Az aktiválás és a szerkesztés a host alkalmazás OLE támogatásától és a biztonsági beállításoktól függ.

## **GYIK**

**Miért szükséges egy előnézeti kép?**  
A beágyazott munkafüzet és a dia előnézete külön tartalom. Készítsen egy diagram képet, hogy a dia a diagramot jelenítse meg az alapértelmezett "EMBEDDED OLE OBJECT" helyőrző helyett. Lásd az [Objektum előnézeti probléma az OleObjectFrame hozzáadása során](/slides/hu/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**Frissül automatikusan az előnézet, ha a kódban módosítom a munkafüzetet?**  
Az előnézetet tekintse pillanatképként. Amikor programozottan frissíti a munkafüzet adatait, generálja újra a diagram képet, és cserélje le az előnézetet, valamint a beágyazott munkafüzet adatait.

**Használhatok XLS‑t az XLSX helyett?**  
Igen. Mentse a munkafüzetet XLS formátumban, és használja a `xls` kiterjesztést beágyazott adatként. A kiterjesztésnek meg kell egyeznie a tényleges munkafüzet formátummal; csak a kiterjesztés megváltoztatása nem konvertálja az adatot.

**Miért változhat az objektum mérete aktiválás után?**  
A host alkalmazás frissítheti az OLE objektum megjelenését, amikor aktiválja a munkafüzetet. A munkafüzet OLE megjelenítési tartománya és a diákeret méretei is számítanak. Lásd a [Működő megoldás a munkalap átméretezésére](/slides/hu/androidjava/working-solution-for-worksheet-resizing/).

## **Kapcsolódó szakaszok**

- [Működő megoldás a munkalap átméretezésére](/slides/hu/androidjava/working-solution-for-worksheet-resizing/)
- [Objektum előnézeti probléma az OleObjectFrame hozzáadása során](/slides/hu/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [OLE kezelése](/slides/hu/androidjava/manage-ole/)