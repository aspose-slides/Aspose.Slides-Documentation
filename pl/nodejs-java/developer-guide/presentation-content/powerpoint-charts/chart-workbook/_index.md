---
title: Zarządzanie skoroszytami wykresów w prezentacjach przy użyciu JavaScript
linktitle: Skoroszyt wykresu
type: docs
weight: 70
url: /pl/nodejs-java/chart-workbook/
keywords:
- skoroszyt wykresu
- dane wykresu
- komórka skoroszytu
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny skoroszyt
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie skoroszytu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Poznaj Aspose.Slides dla Node.js via Java: łatwo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pośrednictwem strumieni skoroszytu, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Opisuje również pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu powiązanego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

Dla komórek skoroszytu, które reprezentują brakujące dane, zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/nodejs-java/chart-series/) aby poznać różnicę między pustą komórką a zerem oraz porównanie wykresu liniowego dostępnych trybów wyświetlania.

## **Uwzględnianie danych z ukrytych wierszy i kolumn**

Użyj [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly), aby kontrolować, czy wykres rysuje dane z ukrytych wierszy i kolumn arkusza. Ustaw na `true`, aby rysować tylko widoczne komórki, lub na `false`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odkrywa wierszy lub kolumn arkusza.

[przykładowa prezentacja](hidden-source-data.pptx) zawiera wykres słupkowy jako pierwszy kształt na pierwszym slajdzie. Osadzony arkusz, `Sheet1`, zawiera następujący zakres źródłowy, `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Sprzedaż detaliczna | C: Sprzedaż hurtowa (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych za pomocą [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) i odczytaj [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#isHidden), aby sprawdzić ich status ukrycia. Ta metoda raportuje status ukrycia bez jego zmiany. W tym pliku B2 jest widoczny, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje `false`, `true` i `true` odpowiednio.

Dla tego przykładu odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzony skoroszyt przy użyciu [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) i wczytaj go ponownie przy użyciu [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream). Przy uwzględnianiu wszystkich komórek użyj także [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange), aby przywrócić pełny zakres, w tym ukrytą kategorię luty. Prosta zmiana flagi nie wystarczy, aby odświeżyć buforowane dane wykresu i etykiety kategorii w tym przykładzie. Przykład konwertuje zwrócony bufor Node.js na tablicę bajtów Javy przed przekazaniem go do metody zapisu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Odśwież dane wykresu z osadzonego skoroszytu.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Przywróć kompletny zakres źródłowy, w tym ukryte kategorie.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Przykład zapisuje dwie wersje prezentacji: jedną z samymi widocznymi wartościami sprzedaży detalicznej (10 i 20) oraz drugą ze wszystkimi sześcioma wartościami. Poniższe obrazy ilustrują dwa tryby rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych skoroszytach.

| Tylko widoczne komórki (`true`) | Wszystkie komórki (`false`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości sprzedaży detalicznej 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości sprzedaży detalicznej i hurtowej dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) kontroluje sposób wyświetlania brakujących wartości; nie włącza ani nie wyłącza ukrytych danych źródłowych. Zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/nodejs-java/chart-series/#control-the-display-of-empty-cells) dla przykładu.

## **Pobieranie zakresu danych wykresu**

Przed aktualizacją danych skoroszytu w istniejącej prezentacji, sprawdź zakresy źródłowe, aby zidentyfikować, które komórki arkusza używa każdy wykres. Metoda [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getRange) zwraca bieżący zakres danych jako formułę kwalifikowaną arkuszem, np. `Sheet1!$A$1:$D$5`. Tutaj `Sheet1` to nazwa arkusza, `!` oddziela ją od zakresu komórek, a `$A$1:$D$5` określa komórki od A1 do D5, włącznie. Znaki dolara wskazują odwołania bezwzględne do wiersza i kolumny.

Metoda odczytuje bieżący zakres bez zmiany wykresu ani jego skoroszytu. Jeśli wykres nie używa skoroszytu jako źródła danych, zostaje rzucony `InvalidOperationException`. Więcej informacji można znaleźć w [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

Przykład otwiera prezentację i sprawdza kształty bezpośrednio na każdym slajdzie pod kątem wykresów. Wypisuje nazwę każdego wykresu i zakres źródłowy. Jeśli wykres nie używa skoroszytu, wypisuje komunikat i przechodzi do kolejnego wykresu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Odczytywanie i zapisywanie danych wykresu ze skoroszytu**

Aspose.Slides for Node.js via Java udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) i [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream), które umożliwiają odczyt i zapis skoroszytów danych wykresu (zawierających dane wykresu edytowane przy pomocy Aspose.Cells). **Uwaga**: dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Przykład używa prezentacji z wykresem jako pierwszym kształtem na pierwszym slajdzie. Odczytuje osadzony skoroszyt do tablicy bajtów, usuwa istniejące serie i kategorie oraz zapisuje z powrotem ten sam skoroszyt. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Walidacja układu wykresu po modyfikacji skoroszytu**

Kiedy zamieniasz osadzony skoroszyt na zmodyfikowany, wykres zachowuje pierwotne kolekcje serii i kategorii. To niezgodność może spowodować niepowodzenie [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#validateChartLayout) z błędem indeksu poza zakresem. Usuń istniejące serie i kategorie przed zapisaniem zaktualizowanego skoroszytu do wykresu. Przykład używa wykresu, który jest pierwszym kształtem na pierwszym slajdzie. Komentarz zaznacza miejsce, w którym miałaby nastąpić edycja skoroszytu; uruchamialny przykład zapisuje oryginalny skoroszyt z powrotem i waliduje układ w pamięci.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Zmodyfikuj bajty skoroszytu tutaj, na przykład przy użyciu Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Usunięcie kolekcji usuwa przestarzałe odwołania danych przed zapisaniem skoroszytu. Odbuduj wymagane mapowania serii i kategorii dla zaktualizowanego skoroszytu przed użyciem wykresu.

## **Ustawienie komórki skoroszytu jako etykiety danych wykresu**

Można używać tekstu z komórek skoroszytu jako etykiet danych wykresu.

Przykład dodaje wykres bąbelkowy z domyślnymi danymi do pierwszego slajdu istniejącej prezentacji. Używa komórek A10:A12 w arkuszu 0 dla pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje zaktualizowaną prezentację.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zarządzanie arkuszami**

Metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) zapewnia dostęp do arkuszy w skoroszycie wykresu. Przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje każdą nazwę arkusza w konsoli.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Określanie typu źródła danych**

Przykład tworzy trójwymiarowy wykres słupkowy z domyślnymi danymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa korzysta z literału łańcucha znaków; druga używa komórki C1 w arkuszu 0. Enumeracja [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) wybiera źródło dla każdej nazwy. Przykład zapisuje prezentację z zaktualizowanymi nazwami serii.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wykrywanie nieobsługiwanych formatów osadzonych skoroszytów**

Aspose.Slides nie obsługuje formatu binarnego skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Można użyć metody [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) na [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) wraz z enumeracją [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać takie wykresy. Przykład sprawdza kształty na pierwszym slajdzie istniejącej prezentacji, pomija kształty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym skoroszytem .xlsb.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Odczytaj lub zmodyfikuj obsługiwane dane skoroszytu wykresu tutaj.
    }
} finally {
    presentation.dispose();
}
```

## **Zewnętrzny skoroszyt**

Aspose.Slides obsługuje używanie zewnętrznych skoroszytów jako źródła danych dla wykresów.

### **Utworzenie zewnętrznego skoroszytu**

Użyj [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) i [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook), aby wyeksportować osadzony skoroszyt wykresu do pliku i połączyć wykres z tym zewnętrznym skoroszytem.

Przykład tworzy wykres kołowy z domyślnymi danymi i eksportuje jego skoroszyt. Zakończy zapis pliku przed przypisaniem zewnętrznego skoroszytu jako źródła danych wykresu, a następnie zapisuje połączoną prezentację.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Ustawienie zewnętrznego skoroszytu**

Korzystając z metody [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook), można przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda może również służyć do aktualizacji ścieżki do zewnętrznego skoroszytu (jeśli został on przeniesiony).

Chociaż nie można edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, można nadal używać takich skoroszytów jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego skoroszytu, zostaje ona automatycznie przekształcona na pełną ścieżkę.

Przykład używa zewnętrznego skoroszytu, którego arkusz o nazwie `Sheet1` zawiera nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy skoroszyt i używa [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange), aby zamapować A1:B4 na jedną serię i trzy kategorie. Zapisuje prezentację z połączonym wykresem.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) kontroluje, czy skoroszyt jest ładowany.

* Gdy `updateChartData` jest `false`, aktualizowana jest tylko ścieżka do skoroszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego skoroszytu, więc skoroszyt może być niedostępny.
* Gdy `updateChartData` jest `true`, dane wykresu są aktualizowane z docelowego skoroszytu.

Poniższy przykład przypisuje przykładowy adres URL z ustawionym `updateChartData` na `false`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego skoroszytu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Pobranie ścieżki zewnętrznego źródła danych skoroszytu wykresu**

Aby zidentyfikować skoroszyt powiązany z wykresem, sprawdź, czy wykres używa zewnętrznego źródła danych i pobierz jego ścieżkę.

Przykład sprawdza pierwszy kształt na pierwszym slajdzie prezentacji z połączonym zewnętrznym skoroszytem. Jeśli jest to wykres połączony ze zewnętrznym skoroszytem, przykład wypisuje [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) w konsoli. Następnie zapisuje kopię prezentacji.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Edycja danych wykresu**

Można edytować dane w zewnętrznych skoroszytach tak samo, jak w przypadku wewnętrznych. Gdy zewnętrzny skoroszyt nie może zostać załadowany, zostaje rzucony wyjątek.

Przykład używa wykresu, który jest pierwszym kształtem na pierwszym slajdzie i jest połączony z dostępnym zewnętrznym skoroszytem. Ustawia wartość opartą na komórce pierwszego punktu danych w pierwszej serii na 100 i zapisuje zaktualizowaną prezentację. Edycja wartości komórek może aktualizować powiązany zewnętrzny plik XLSX, dlatego warto używać kopii, jeśli trzeba zachować oryginalny skoroszyt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Odzyskiwanie skoroszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego skoroszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu z danych buforowanych w prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), wywołaj [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) i ustaw [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) na `true` przed otwarciem prezentacji.

Poniższy przykład JavaScript odtwarza dane skoroszytu dla wykresu, który jest pierwszym kształtem na pierwszym slajdzie i odwołuje się do niedostępnego zewnętrznego skoroszytu. Uzyskuje dostęp do odzyskanych danych za pośrednictwem [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getChartData) i [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Odczytaj lub zmodyfikuj odzyskane dane skoroszytu tutaj.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Jeśli zewnętrzny skoroszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides rzuca wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie buforowanych danych wykresu jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym skoroszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres posiada [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getDataSourceType) oraz [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych skoroszytów i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie przekształcona na ścieżkę bezwzględną. Prezentacja przechowuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie skoroszytu może wymagać aktualizacji odnośnika.

**Czy mogę używać skoroszytów znajdujących się na zasobach sieciowych/udziałach?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych skoroszytów bezpośrednio z Aspose.Slides nie jest obsługiwana – mogą być używane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX podczas zapisywania prezentacji?**

Prezentacja przechowuje [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath). Edycja danych wykresu opartej na komórkach może również aktualizować połączony lokalny plik XLSX. Użyj kopii skoroszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, gdy zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie przyjmuje hasła przy łączeniu. Typowym podejściem jest usunięcie zabezpieczenia wcześniej lub przygotowanie odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/java/)) i połączenie się z tą kopią.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.