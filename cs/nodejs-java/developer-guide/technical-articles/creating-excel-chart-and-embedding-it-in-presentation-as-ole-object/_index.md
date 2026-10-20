---
title: Vytvoření grafů Excel a jejich vložení do prezentací jako OLE objekty
type: docs
weight: 30
url: /cs/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- graf Excel
- vložit graf
- OLE objekt
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvořte graf Excel pomocí Aspose.Cells pro Node.js přes Javu a vložte sešit do prezentace PowerPoint pomocí Aspose.Slides, včetně náhledu grafu."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit sloupcový graf Excelu pomocí Aspose.Cells pro Node.js prostřednictvím Javy a vložit jeho sešit do prezentace PowerPoint pomocí Aspose.Slides pro Node.js prostřednictvím Javy. Vložený sešit obsahuje jak zdrojová data, tak graf. Samostatná ukázka PNG zobrazuje graf na snímku před aktivací objektu OLE.

Výsledkem je vložený objekt Excel, nikoli nativní graf PowerPointu. Úprava sešitu přes OLE vyžaduje desktopovou aplikaci, která podporuje aktivaci OLE a kompatibilní instalaci Excelu.

## **Požadavky**

Nainstalujte balíčky Node.js `aspose.cells`, `aspose.slides.via.java` a `java`. Spusťte příklady jako dva skripty CommonJS ve samostatných procesech Node.js: nejprve `create-chart.js`, poté `embed-chart.js`, přičemž použijete stejný pracovní adresář. Oba balíčky Aspose inicializují most Java během načítání, takže tyto ukázky je udržují v oddělených procesech. Microsoft Office není vyžadován pro generování prezentace s těmito knihovnami.

Žádný existující sešit nebo obrázek není potřeba. První skript vytvoří `ChartWorkbook.xlsx` a `ChartPreview.png`; druhý načte tyto soubory a zapíše `OutputChart.pptx` do aktuálního pracovního adresáře. Použijte licence pro oba produkty při běhu mimo režim hodnocení.

## **Jak funguje vkládání**

1. Vytvořte sešit s listem dat a listem grafu.  
1. Nastavte list grafu jako aktivní, aby se sešit otevřel na grafu.  
1. Nastavte OLE zobrazovací oblast sešitu a vykreslete graf do PNG.  
1. Uložte sešit jako XLSX a vložte jeho bajty do snímku v samostatném procesu Node.js.  
1. Přiřaďte PNG jako náhled objektu OLE a uložte prezentaci jako PPTX.  

Zobrazovací oblast sešitu a rámec na snímku mají různé role. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) používá nulové indexy pro počáteční/koncový řádek a sloupec. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) naproti tomu přijímá horní řádek, levý sloupec, dolní řádek a pravý sloupec. Příklad používá index řádku 55 a index sloupce 25 jako pravé dolní hranice; tyto hodnoty jsou volby rozvržení, ne počet řádků či sloupců dat.

Rámec snímku používá body. Příklad jej umístí do snímku a vycentruje, přičemž zachová poměr stran PNG, místo aby natahoval náhled tak, aby vyplnil celý snímek.

## **Vytvoření a vložení grafu**

Uložte první příklad jako `create-chart.js`. Naplní `DataSheet` čtyřmi řádky a pěti sloupci hodnot. Každý řádek se stane sérií grafu. `ChartSheet` je před uložením sešitu vybrán jako aktivní list.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Vykreslete náhled grafu a samostatně serializujte editovatelný sešit.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Veškerá synchronní práce je dokončena; zastavte proces Java mostu.
process.exit(0);
```

Uložte následující příklad jako `embed-chart.js`. Spusťte jej poté, co `create-chart.js` vytvořil oba vstupní soubory. Vycentruje OLE rámec a zachová poměr stran obrázku náhledu.

Druhý skript vloží uložený sešit a použije PNG jako jeho náhled. Sešit je explicitně uložen jako XLSX, což odpovídá příponě `xlsx` předané do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). PNG je načten přímo z bajtů bez mezikroku převodu bitmapy. Most Java vyžaduje explicitní pole bajtů Java pro obrázek a data sešitu a hodnoty typu float Java pro souřadnice rámce snímku. Přiřazení pomocí [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) nahradí výchozí zástupný objekt OLE.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Přizpůsobte náhled snímku bez změny jeho poměru stran.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Veškerá synchronní práce je dokončena; zastavte proces Java mostu.
process.exit(0);
```

## **Očekávaný výsledek**

`OutputChart.pptx` obsahuje jeden snímek s vloženým sešitem Excel a náhledem grafu. Sešit obsahuje originální data a sloupcový graf se čtyřmi sériemi. Náhled je vycentrován na snímku a zachovává své proporce.

![Sloupcový graf Excel zobrazený jako náhled vloženého sešitu](excel-chart-ole-preview.png)

V kompatibilním desktopovém prostředí PowerPoint s dostupným Excelem dvojklikněte na objekt pro aktivaci a úpravu vloženého sešitu. Aktivace a úpravy závisí na podpoře OLE hostitelské aplikace a na nastavení zabezpečení.

## **Často kladené otázky**

**Proč je potřeba obrázek náhledu?**

Vložený sešit a jeho náhled na snímku jsou samostatný obsah. Poskytněte obrázek grafu, aby snímek zobrazoval graf místo výchozího zástupného textu „EMBEDDED OLE OBJECT“. Viz [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**Aktualizuje se náhled automaticky, když v kódu změním sešit?**

Považujte náhled za snímek. Při programové aktualizaci dat sešitu znovu vygenerujte obrázek grafu a nahraďte náhled i data vloženého sešitu.

**Mohu použít XLS místo XLSX?**

Ano. Uložte sešit ve formátu XLS a použijte `xls` jako příponu vložených dat. Přípona musí odpovídat skutečnému formátu sešitu; změna přípony samotná data nepřevádí.

**Proč se objekt může po aktivaci změnit velikost?**

Hostitelská aplikace může po aktivaci sešitu aktualizovat prezentaci objektu OLE. Zobrazovací oblast OLE sešitu i rozměry rámce na snímku jsou důležité. Viz [Řešení pro změnu velikosti grafu v PPTX](/slides/cs/java/working-solution-for-chart-resizing-in-pptx/).

## **Související sekce**

- [Řešení pro změnu velikosti grafu v PPTX](/slides/cs/java/working-solution-for-chart-resizing-in-pptx/)
- [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)