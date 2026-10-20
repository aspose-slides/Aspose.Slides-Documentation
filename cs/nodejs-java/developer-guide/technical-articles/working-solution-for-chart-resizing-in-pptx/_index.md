---
title: Řešení pro změnu velikosti grafu v PPTX
type: docs
weight: 40
url: /cs/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- změna velikosti grafu
- graf Excel
- OLE objekt
- vložit graf
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Opravte neočekávanou změnu velikosti grafu v PPTX při používání vložených OLE objektů Excel s Aspose.Slides pro Node.js přes Java. Nastavte pevné rozměry grafu, aby byly velikosti grafu a OLE rámce konzistentní."
---
## **Přehled**

Grafy Excel vložené jako objekty OLE v prezentacích PowerPoint pomocí komponent Aspose mohou po první aktivaci změnit velikost. To může způsobit znatelný rozdíl ve vzhledu grafu před a po aktivaci. Tento článek vysvětluje, proč k přeměřování dochází, a ukazuje, jak tomu zabránit nastavením fixních rozměrů grafu tak, aby odpovídaly rámci OLE.

V [Vytvořit grafy Excel a vložit je jako objekty OLE v prezentacích](/slides/cs/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) jsme vysvětlili, jak vytvořit graf Excel pomocí Aspose.Cells pro Node.js přes Java a vložit jej do prezentace PowerPoint pomocí Aspose.Slides pro Node.js přes Java. Pro řešení [problému s náhledem objektu](/slides/cs/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek grafu k OLE objektovému rámci grafu. V výsledné prezentaci, když dvakrát kliknete na OLE objektový rámec zobrazující obrázek grafu, graf Excel se aktivuje. Uživatelé mohou upravovat vložený sešit Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE objektového rámce se změní, když se uživatel vrátí na snímek, a faktor změny velikosti se liší v závislosti na původních rozměrech jak OLE rámce, tak vloženého sešitu Excel.

## **Příčina změny velikosti**

Vložený sešit Excel má své vlastní rozměry okna, které se Excel snaží zachovat při první aktivaci objektu. OLE rámec na snímku má samostatně definované rozměry. Když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost objektu tak, aby zachovaly jeho proporce jako součást procesu vkládání. Rozdíly mezi oknem sešitu a OLE rámcem tedy mohou způsobit změnu velikosti objektu.

## **Fungující řešení**

Přizpůsobte velikost grafu OLE rámci na snímku a udržujte rozměry grafu nezávislé na okně sešitu. Toto řešení funguje jak pro novou prezentaci, tak pro existující šablonu.

Příklad vyžaduje Aspose.Cells pro Node.js přes Java a Aspose.Slides pro Node.js přes Java. Nainstalujte balíčky Node.js `aspose.cells`, `aspose.slides.via.java` a `java`. Spusťte níže uvedené dva skripty CommonJS v samostatných procesech Node.js, přičemž použijte stejný pracovní adresář, protože oba Aspose balíčky během načítání inicializují Java most. Vytvoří jednoduchý sloupcový graf na aktivním listu grafu a vloží sešit ve formátu XLS. Náhledový obrázek grafu není přiřazen; graf se zobrazí, když je OLE objekt v PowerPointu aktivován.

Příklad vytvoří novou prezentaci s OLE rámcem o rozměrech 9,5 × 4 palce, umístěným 0,5 palce od levého okraje a 1 palec od horního. Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec). Pro existující prezentaci viz [Použít šablonu](#use-a-template).

## **Nastavení fixní velikosti grafu**

Nastavte [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) na false, aby byly rozměry grafu nezávislé na okně sešitu. Nastavte rozměry pomocí [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) skrze [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) a [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), převedením bodů na pixely při 96 pixelech na palec: rámec o rozměrech 684 × 288 bodů odpovídá grafu o rozměrech 912 × 384 pixelů. Nastavte [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) na hodnotu CUSTOM typu `PrintSizeType`. Příklad vloží sešit pomocí [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) a uloží prezentaci s OLE rámcem o rozměrech 9,5 × 4 palce.

Uložte tento první skript jako `create-fixed-chart.js`. Vytvoří soubor `chart-fixed-size.xls` s grafem o rozměrech 912 × 384 pixelů, který odpovídá rámci 684 × 288 bodů použitým ve druhém skriptu. Vstupní sešit není vyžadován.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Přizpůsobte rozměry OLE rámce v bodech (72 bodů na palec).
    const width = 684; // 9,5 palce.
    const height = 288; // 4 palce.

    chart.setSizeWithWindow(false);
    // Převěďte body na pixely grafu pomocí 96 pixelů na palec.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Veškerá synchronní práce je dokončena; zastavte proces Java mostu.
process.exit(0);
```

Uložte druhý skript jako `embed-fixed-chart.js` a spusťte jej po `create-fixed-chart.js`. Načte vygenerovaný sešit XLS a uloží `chart-fixed-size.pptx`. Java most vyžaduje explicitní Java pole bajtů pro data sešitu a hodnoty typu Java float pro souřadnice a rozměry rámce. Přípona `xls` odpovídá formátu uloženého sešitu.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec).
    const width = 684; // 9,5 palce.
    const height = 288; // 4 palce.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Veškerá synchronní práce je dokončena; zastavte proces Java mostu.
process.exit(0);
```

## **Použít šablonu**

Logika velikosti je stejná pro existující prezentaci. Pro úpravu příkladu:

1. Načtěte šablonu prezentace místo vytváření prázdné prezentace.
2. Zkontrolujte, že první snímek obsahuje alespoň tři tvary, a poté použijte tvar s indexem 2 jako zástupný prvek.
3. Získejte šířku a výšku rámce z tohoto tvaru místo použití pevných hodnot 684 a 288. Použijte stejné rozměry ve skriptu pro tvorbu sešitu, zachovejte výpočty velikosti beze změny a před vložením znovu vygenerujte sešit XLS.
4. Přidejte OLE rámec na pozici zástupného prvku místo pevných souřadnic 36 a 72.
5. Odstraňte zástupný prvek před uložením prezentace.

## **Často kladené otázky**

**Proč se můj vložený graf Excel mění po aktivaci v PowerPointu?**  
K tomu dochází, protože Excel se při první aktivaci snaží obnovit původní velikost okna, zatímco OLE objektový rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel vyjednávají velikost tak, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Jak mohu udržet velikosti grafu a OLE rámce konzistentní?**  
Nastavte pevné rozměry grafu, které odpovídají OLE rámci, a použijte vlastní velikost tisku grafu před vložením sešitu. Výše uvedený příklad ukazuje potřebná nastavení a převody jednotek.

**Je přizpůsobení velikosti okna sešitu dostatečné?**  
Pouhé přizpůsobení velikosti okna sešitu spolehlivě nebrání změně velikosti OLE rámce po aktivaci. Použijte pevné rozměry grafu, jak je ukázáno v příkladu.

**Funguje toto řešení jak pro prezentace založené na šabloně, tak pro nové prezentace?**  
Ano. Pro šablonu použijte rozměry a umístění zástupného prvku. Pro novou prezentaci specifikujte rozměry a umístění rámce přímo.

**Mohu tento příklad použít s grafy vytvořenými v jiných tabulkových programech?**  
Příklad používá sešit Excel vytvořený pomocí Aspose.Cells. Neukazuje chování aktivace pro jiné tabulkové programy.

## **Související sekce**

- [Vytvořit grafy Excel a vložit je jako objekty OLE v prezentacích](/slides/cs/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)