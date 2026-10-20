---
title: Pracovní řešení pro změnu velikosti grafu v PPTX
type: docs
weight: 40
url: /cs/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- změna velikosti grafu
- graf Excel
- OLE objekt
- vložit graf
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Opravte neočekávanou změnu velikosti grafu v souboru PPTX při používání vložených OLE objektů Excel s Aspose.Slides pro Android přes Java. Nastavte pevné rozměry grafu, aby byly velikosti grafu a OLE rámce konzistentní."
---
## **Přehled**

Excel grafy vložené jako OLE objekty v prezentacích PowerPoint pomocí komponent Aspose se mohou po jejich první aktivaci změnit velikost. To může způsobit znatelný rozdíl ve vzhledu grafu před a po aktivaci. Tento článek vysvětluje, proč k změně velikosti dochází, a ukazuje, jak tomu zabránit tím, že pevné rozměry grafu sladíme s OLE rámcem.

V [Vytvořit grafy Excel a vložit je jako OLE objekty v prezentacích](/slides/cs/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) jsme vysvětlili, jak vytvořit graf Excel pomocí Aspose.Cells pro Android přes Java a vložit jej do prezentace PowerPoint pomocí Aspose.Slides pro Android přes Java. K vyřešení [problému s náhledem objektu](/slides/cs/androidjava/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek grafu do OLE objektového rámce grafu. Ve výsledné prezentaci, když dvakrát kliknete na OLE objektový rámec zobrazující obrázek grafu, aktivuje se graf Excel. Uživatelé mohou upravovat vložený sešit Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE objektového rámce se změní, když se uživatel vrátí na snímek, a faktor změny velikosti se liší v závislosti na původních velikostech jak OLE objektového rámce, tak vloženého sešitu Excel.

## **Příčina změny velikosti**

Vložený sešit Excel má vlastní rozměry okna, které se Excel snaží zachovat při první aktivaci objektu. OLE rámec na snímku má nezávisle definované rozměry. Když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost objektu, aby udržely jeho proporce jako součást procesu vkládání. Rozdíly mezi oknem sešitu a OLE rámcem tedy mohou způsobit změnu velikosti objektu.

## **Fungující řešení**

Sladěte velikost grafu s OLE rámcem na snímku a udržujte rozměry grafu nezávislé na okně sešitu. Toto řešení funguje s novou prezentací i s existující šablonou.

Příklad vyžaduje Aspose.Cells pro Android přes Java a Aspose.Slides pro Android přes Java. Vytvoří jednoduchý sloupcový graf na aktivním listu grafu a vloží sešit ve formátu XLS. Zavolejte `FixedChartSize.createPresentation(getFilesDir())` z Android aktivity pro uložení výstupu do interního adresáře souborů aplikace. Aktivace OLE vyžaduje desktopovou verzi PowerPointu a kompatibilní instalaci Excelu. Náhledový obrázek grafu není přiřazen; graf se zobrazí, když je OLE objekt aktivován v PowerPointu.

Příklad vytvoří novou prezentaci s OLE rámcem o velikosti 9,5 × 4 palce umístěným 0,5 palce od levého okraje a 1 palec od horního okraje. Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec). Pro existující prezentaci viz [Použít šablonu](#use-a-template).

## **Nastavení pevné velikosti grafu**

Nastavte [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) na false, aby rozměry grafu byly nezávislé na okně sešitu. Nastavte rozměry pomocí [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) pomocí [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) a [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), přičemž převádíte body na pixely při 96 pixelech na palec: rámec o rozměrech 684 × 288 bodů odpovídá grafu o rozměrech 912 × 384 pixelů. Nastavte [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) na hodnotu CUSTOM typu [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Příklad vloží sešit pomocí [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) a uloží prezentaci s OLE rámcem o velikosti 9,5 × 4 palce.

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

                    // Souřadnice snímku a rozměry jsou v bodech (72 bodů na palec).
                    float width = 684f; // 9,5 palce.
                    float height = 288f; // 4 palce.

                    chart.setSizeWithWindow(false);
                    // Převést body na pixely grafu při 96 pixelech na palec.
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

## **Použít šablonu**

Logika velikosti je stejná pro existující prezentaci. Pro úpravu příkladu:

1. Načtěte šablonu prezentace místo vytvoření prázdné prezentace.
1. Zkontrolujte, že první snímek obsahuje alespoň tři tvary, a poté použijte tvar s indexem 2 jako zástupný znak.
1. Vezměte šířku a výšku rámce z tohoto tvaru místo použití pevných hodnot 684 a 288. Nechte výpočty velikosti nezměněné.
1. Přidejte OLE rámec na pozici zástupného znaku místo pevných souřadnic 36 a 72.
1. Odstraňte zástupný znak před uložením prezentace.

## **Často kladené otázky**

**Proč se můj vložený graf Excel mění po aktivaci v PowerPointu?**

K tomu dochází, protože Excel se při první aktivaci snaží obnovit původní velikost okna, zatímco OLE objektový rámec v PowerPointu má vlastní rozměry. PowerPoint a Excel vyjednávají velikost tak, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Jak mohu udržet velikosti grafu a OLE rámce konzistentní?**

Nastavte pevné rozměry grafu, které odpovídají OLE rámci, a použijte vlastní velikost tisku grafu před vložením sešitu. Výše uvedený příklad ukazuje požadovaná nastavení a převody jednotek.

**Je sladění velikosti okna sešitu dostačující?**

Pouhé sladění velikosti okna sešitu spolehlivě nebrání změně velikosti OLE rámce po aktivaci. Použijte pevné rozměry grafu, jak je ukázáno v příkladu.

**Funguje toto řešení jak pro prezentace založené na šabloně, tak pro nové prezentace?**

Ano. Pro šablonu použijte rozměry a pozici zástupného znaku. Pro novou prezentaci přímo zadejte rozměry a umístění rámce.

**Mohu použít tento příklad s grafy vytvořenými v jiných tabulkových programech?**

Příklad používá sešit Excel vytvořený pomocí Aspose.Cells. Neukazuje chování aktivace pro jiné tabulkové programy.

## **Související sekce**

- [Vytvořit grafy Excel a vložit je jako OLE objekty v prezentacích](/slides/cs/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)