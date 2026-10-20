---
title: Funkční řešení pro změnu velikosti grafu v PPTX
type: docs
weight: 40
url: /cs/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- změna velikosti grafu
- graf Excel
- OLE objekt
- vložit graf
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Opravte neočekávanou změnu velikosti grafu v PPTX při použití vložených OLE objektů Excel s Aspose.Slides pro Java. Nastavte pevné rozměry grafu, aby byly velikosti grafu a rámce OLE konzistentní."
---
## **Pozadí**

Grafy Excel vložené jako OLE objekty v prezentacích PowerPoint pomocí komponent Aspose mohou po první aktivaci změnit velikost. To může způsobit výrazný rozdíl ve vzhledu grafu před a po aktivaci. Tento článek vysvětluje, proč dochází k změně velikosti, a ukazuje, jak tomu předejít nastavením pevných rozměrů grafu tak, aby odpovídaly rámci OLE.

V [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/cs/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) jsme vysvětlili, jak vytvořit graf Excel pomocí Aspose.Cells for Java a vložit jej do prezentace PowerPoint pomocí Aspose.Slides for Java. Pro řešení [object preview issue](/slides/cs/java/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek grafu rámci OLE objektu grafu. V výstupní prezentaci, když dvakrát kliknete na rámec OLE objektu zobrazující obrázek grafu, aktivuje se graf Excel. Uživatelé mohou upravovat vložený sešit Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost rámce OLE objektu se změní, když se uživatel vrátí na snímek, a faktor změny velikosti se liší v závislosti na původních velikostech jak rámce OLE objektu, tak vloženého sešitu Excel.

## **Příčina změny velikosti**

Vložený sešit Excel má své vlastní rozměry okna, které se Excel snaží zachovat při první aktivaci objektu. Rámec OLE na snímku má samostatně definované rozměry. Když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost objektu tak, aby zachovaly proporce jako součást procesu vkládání. Rozdíly mezi oknem sešitu a rámcem OLE tak mohou způsobit změnu velikosti objektu.

## **Fungující řešení**

Nastavte velikost grafu tak, aby odpovídala rámci OLE na snímku, a ponechte rozměry grafu nezávislé na okně sešitu. Toto řešení funguje jak s novou prezentací, tak s existující šablonou.

Příklad vyžaduje Aspose.Cells for Java a Aspose.Slides for Java. Vytvoří jednoduchý sloupcový graf na aktivním listu grafu a vloží sešit ve formátu XLS. Žádný obrázek náhledu grafu není přiřazen; graf se zobrazí, když je OLE objekt v PowerPointu aktivován.

Příklad vytvoří novou prezentaci s OLE rámcem o velikosti 9,5 × 4 palce umístěným 0,5 palce od levého okraje a 1 palec od horního okraje. Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec). Pro existující prezentaci viz [Use a Template](#use-a-template).

## **Nastavte pevnou velikost grafu**

Nastavte [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) na false, aby rozměry grafu byly nezávislé na okně sešitu. Rozměry [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) nastavte pomocí [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) a [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), přičemž převedete body na pixely při 96 pixelech na palec: rámec měřící 684 × 288 bodů odpovídá grafu měřícímu 912 × 384 pixelů. Nastavte [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) na hodnotu CUSTOM typu [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Příklad vloží sešit pomocí [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) a uloží prezentaci s OLE rámcem o velikosti 9,5 × 4 palce.

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

        // Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec).
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

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **Použít šablonu**

Logika velikosti je stejná pro existující prezentaci. Pro úpravu příkladu:

1. Načtěte šablonu prezentace místo vytváření prázdné prezentace.  
2. Ověřte, že první snímek obsahuje alespoň tři tvary, a použijte tvar s indexem 2 jako zástupný znak.  
3. Vezměte šířku a výšku rámce z tohoto tvaru místo pevně zadaných hodnot 684 a 288. Nechte výpočty velikosti beze změny.  
4. Přidejte OLE rámec na pozici zástupného znaku místo pevných souřadnic 36 a 72.  
5. Odstraňte zástupný znak před uložením prezentace.

## **FAQ**

**Proč se můj vložený graf Excel po aktivaci v PowerPointu změní velikost?**

Stane se tak, protože Excel se pokouší obnovit původní velikost okna při první aktivaci, zatímco rámec OLE objektu v PowerPointu má své vlastní rozměry. PowerPoint a Excel vyjednávají velikost tak, aby zachovaly poměr stran, což může vést ke změně velikosti.

**Jak udržet velikosti grafu a rámce OLE konzistentní?**

Nastavte pevné rozměry grafu, které odpovídají rámci OLE, a použijte vlastní velikost tisku grafu před vložením sešitu. Výše uvedený příklad ukazuje potřebná nastavení a převody jednotek.

**Je nastavení velikosti okna sešitu dostačující?**

Pouze nastavení velikosti okna sešitu spolehlivě nebrání změně velikosti rámce OLE po aktivaci. Použijte pevné rozměry grafu, jak je ukázáno v příkladu.

**Funguje toto řešení jak pro prezentace založené na šabloně, tak pro nové prezentace?**

Ano. Pro šablonu použijte rozměry a pozici zástupného znaku. Pro novou prezentaci zadejte rozměry a pozici rámce přímo.

**Mohu použít tento příklad s grafy vytvořenými v jiných tabulkových programech?**

Příklad používá sešit Excel vytvořený pomocí Aspose.Cells. Nepředstavuje chování aktivace pro jiné tabulkové programy.

## **Související sekce**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/cs/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)