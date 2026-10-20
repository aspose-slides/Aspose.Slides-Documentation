---
title: Vytvoření grafů Excel a jejich vložení do prezentací jako OLE objekty
type: docs
weight: 30
url: /cs/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel graf
- vložit graf
- OLE objekt
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvořte graf v Excelu pomocí Aspose.Cells for Android via Java a vložte sešit do PowerPoint prezentace pomocí Aspose.Slides for Android via Java, včetně náhledu grafu."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Cells for Android via Java vytvořit sloupcový graf v Excelu a vložit jeho sešit do PowerPoint prezentace pomocí Aspose.Slides for Android via Java. Vložený sešit obsahuje jak zdrojová data, tak graf. Samostatná náhledová PNG zobrazí graf na snímku před aktivací OLE objektu.

Výsledkem je vložený objekt Excel, nikoli nativní PowerPoint graf. Úprava sešitu přes OLE vyžaduje desktopovou aplikaci, která podporuje aktivaci OLE, a kompatibilní instalaci Excelu.

## **Požadavky**

Přidejte Aspose.Cells for Android via Java a Aspose.Slides for Android via Java do závislostí svého projektu. Zavolejte `ExcelChartEmbedding.createPresentation(getFilesDir())` z Android aktivity. Microsoft Office není vyžadován pro vytvoření prezentace s těmito knihovnami.

Žádné vstupní soubory nejsou potřeba: příklad vytvoří data a graf v paměti a poté zapíše `OutputChart.pptx` do interního adresáře souborů aplikace. Použijte licence pro oba produkty při spuštění mimo evaluační režim.

## **Jak funguje vkládání**

1. Vytvořte sešit s datovým listem a listem grafu.  
2. Aktivujte list grafu, aby se sešit otevřel na grafu.  
3. Nastavte OLE zobrazovací oblast sešitu a vykreslete graf do PNG.  
4. Uložte sešit jako XLSX v paměti a vložte tyto bajty do snímku.  
5. Přiřaďte PNG jako náhled OLE objektu a uložte prezentaci jako PPTX.

Oblast zobrazení sešitu a rámeček na snímku mají odlišné role. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) používá indexy řádků a sloupců počítané od nuly. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) naproti tomu přijímá horní řádek, levý sloupec, dolní řádek a pravý sloupec. Příklad používá index řádku 55 a index sloupce 25 jako pravé dolní hranice; tyto hodnoty jsou volby rozvržení, nikoli počet datových řádků nebo sloupců.

Rámeček snímku používá body. Příklad ho umístí do snímku a vycentruje, přičemž zachovává poměr stran PNG, místo aby natahoval náhled tak, aby vyplnil snímek.

## **Vytvoření a vložení grafu**

Následující kompletní příklad naplní `DataSheet` čtyřmi řádky a pěti sloupci hodnot. Každý řádek se stane sérií grafu. `ChartSheet` je vybrán jako aktivní list před uložením sešitu.

Sešit je explicitně uložen jako XLSX, aby odpovídal příponě `xlsx` předané do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/). PNG je načten přímo z jeho bajtů bez mezičlánku bitmapové konverze. Přiřazení přes [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) nahrazuje výchozí OLE zástupný prvek.

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

                // Vykreslete náhled grafu a samostatně serializujte upravitelný sešit.
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

                        // Umístěte náhled do snímku tak, aby se vešel, bez změny poměru stran.
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

## **Očekávaný výsledek**

`OutputChart.pptx` obsahuje jeden snímek s vloženým sešitem Excel a náhledem grafu. Sešit obsahuje původní data a sloupcový graf se čtyřmi sériemi. Náhled je vycentrován na snímku a zachovává své proporce.

![Sloupcový graf Excel zobrazený jako náhled vloženého sešitu](excel-chart-ole-preview.png)

V kompatibilním desktopovém prostředí PowerPointu s dostupným Excelem dvakrát klikněte na objekt, abyste aktivovali a upravili vložený sešit. Aktivace a úpravy závisí na podpoře OLE hostitelské aplikace a na nastavení zabezpečení.

## **Často kladené otázky**

**Proč je potřeba obrázek náhledu?**  
Vložený sešit a jeho náhled na snímku jsou samostatný obsah. Poskytněte obrázek grafu, aby snímek zobrazoval graf místo výchozího zástupného prvku „EMBEDDED OLE OBJECT“. Viz [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**Aktualizuje se náhled automaticky, když v kódu změním sešit?**  
Považujte náhled za snímek. Při programatické aktualizaci dat sešitu vygenerujte znovu obrázek grafu a nahraďte náhled i data vloženého sešitu.

**Mohu použít XLS místo XLSX?**  
Ano. Uložte sešit ve formátu XLS a použijte `xls` jako příponu vložených dat. Přípona musí odpovídat skutečnému formátu sešitu; pouhá změna přípony data nevyconvertuje.

**Proč se může objekt po aktivaci změnit velikost?**  
Hostitelská aplikace může po aktivaci sešitu aktualizovat vzhled OLE objektu. Na tom záleží jak na OLE zobrazovací oblasti sešitu, tak na rozměrech rámečku snímku. Viz [Řešení pro změnu velikosti listu](/slides/cs/androidjava/working-solution-for-worksheet-resizing/).

## **Související sekce**

- [Řešení pro změnu velikosti listu](/slides/cs/androidjava/working-solution-for-worksheet-resizing/)
- [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [Správa OLE](/slides/cs/androidjava/manage-ole/)