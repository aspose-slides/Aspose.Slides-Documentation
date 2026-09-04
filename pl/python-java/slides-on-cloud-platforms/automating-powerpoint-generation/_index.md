---
title: "Automatyzacja generowania PowerPoint w Pythonie: Tworzenie dynamicznych prezentacji z łatwością"
linktitle: Automatyzacja generowania PowerPoint
type: docs
weight: 20
url: /pl/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- platformy chmurowe
- integracja chmurowa
- automatyzacja generowania PowerPoint
- programowe tworzenie prezentacji
- automatyzacja PowerPoint
- dynamiczne tworzenie slajdów
- zautomatyzowane raporty biznesowe
- automatyzacja PPT
- prezentacja Python
- Python
- Aspose.Slides
description: "Automatyzuj generowanie PowerPoint przy użyciu Aspose.Slides dla Pythona via Java: twórz prezentacje biznesowe z wykresami, tabelami i punktami wypunktowanymi w aplikacjach chmurowych."
---
## **Wprowadzenie**

Tworzenie prezentacji ręcznie staje się monotonne, gdy ich zawartość często się zmienia. Cotygodniowe raporty, materiały szkoleniowe i prezentacje dla klientów często mają wspólną strukturę, ale wymagają nowych danych przy każdym dostarczeniu.

Aspose.Slides for Python via Java pozwala generować te prezentacje z aplikacji Python. Możesz zintegrować tworzenie slajdów z portalami internetowymi, zadaniami zaplanowanymi i pracownikami w chmurze, wykorzystując dane z baz danych, API lub przesłanych plików.

## **Typowe przypadki użycia automatyzacji PowerPoint w Pythonie**

- **Raporty biznesowe i pulpity nawigacyjne:** przekształć dane sprzedażowe i wskaźniki wydajności w wykresy i tabele.
- **Spersonalizowane prezentacje sprzedażowe:** wypełnij slajdy danymi specyficznymi dla klienta, zachowując spójny projekt.
- **Materiał edukacyjny:** złoż lekcje, quizy i podsumowania kursów ze strukturalnych materiałów.
- **Wnioski oparte na danych i AI:** wykorzystaj wyniki analityki lub usług przetwarzania języka jako treść prezentacji.
- **Slajdy oparte na mediach:** połącz przesłane obrazy lub zrzuty ekranu z tekstem wyjaśniającym.
- **Przepływy dokumentów:** mapuj treść wyodrębnioną przez inne narzędzia na układy prezentacji.
- **Narzędzia deweloperskie:** generuj podsumowania wydań, przeglądy techniczne lub demonstracje z danych projektu.

## **Wymagania wstępne**

Postępuj zgodnie z [Instalacja](/slides/pl/python-java/installation/), aby skonfigurować Python, Javę, JPype i Aspose.Slides. W przypadku wdrożenia w chmurze, zapoznaj się również z [Prezentacje na platformach chmurowych](/slides/pl/python-java/slides-on-cloud-platforms/).

Przykład używa stałych danych biznesowych, aby mógł działać bez bazy danych lub zewnętrznego serwisu. Zastąp te wartości danymi z aplikacji podczas integrowania ich w przepływie raportów.

{{% alert color="info" title="Note" %}}
Możesz wypróbować przykład bez licencji, ale wynik ewaluacji zawiera znak wodny i podlega ograniczeniom ewaluacyjnym. Zobacz [Ewaluacja Aspose.Slides](/slides/pl/python-java/evaluate-aspose-slides/) po szczegóły i informacje o tymczasowej licencji.
{{% /alert %}}

## **Zbuduj prezentację**

Pełny skrypt poniżej tworzy jedną prezentację zawierającą cztery slajdy. Każdy krok używa tej samej prezentacji, a ostatni krok zapisuje ją jako `presentation.pptx`.

### **Utwórz slajd tytułowy**

Użyj początkowego slajdu w nowej [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i zastosuj układ tytułu. Wypełnij jego pola zastępcze tytułu i podtytułu nagłówkiem raportu oraz odbiorcą.

![Slajd tytułowy](slide_0.png)

### **Dodaj slajd z wykresem kolumnowym**

Dodaj pusty slajd i utwórz wykres za pomocą [ShapeCollection.addChart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addChart). Wypełnij wbudowany skoroszyt pięcioma regionami i jedną serią sprzedaży. Wartości pozostają edytowalne w PowerPoint.

![Slajd z wykresem](slide_1.png)

### **Dodaj slajd z tabelą**

Utwórz tabelę przy użyciu [ShapeCollection.addTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addTable) i wypełnij dwie kolumny nazwami metryk oraz wartościami. Przykład przekazuje jawne tablice Java typu double dla szerokości kolumn i wysokości wierszy przez JPype.

![Slajd z tabelą](slide_2.png)

### **Dodaj slajd podsumowania z punktami wypunktowanymi**

Utwórz kształt tekstowy i dodaj [Paragraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraph/) dla każdego elementu akcji. Zastosuj symbol wypunktowania i czarny tekst do każdego akapitu oraz usuń wypełnienie i obrys kształtu.

![Slajd z podsumowaniem](slide_3.png)

### **Zapisz prezentację**

Użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), aby zapisać plik PowerPoint. Zwolnij prezentację za pomocą [Presentation.dispose](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#dispose) w bloku `finally`.

### **Kompletny przykład w Pythonie**

Zapisz ten skrypt w zapisywalnym katalogu i uruchom go w skonfigurowanym powyżej środowisku Python. Uruchamia JVM tylko w razie potrzeby i pozostawia ją dostępną aż do zakończenia procesu. W przypadku użycia w notatnikach i usługach, zobacz [JVM lifecycle guidance](/slides/pl/python-java/limitations-and-api-differences/#import-the-library).

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # Utwórz slajd tytułowy.
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # Dodaj slajd z wykresem.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Dodaj slajd z tabelą.
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # Dodaj slajd podsumowujący.
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ilustracje pokazują odpowiadające slajdy z przykładu w Javie. Wygląd może się różnić w zależności od zainstalowanych czcionek i trybu ewaluacji.

## **Użycie przykładu w aplikacji chmurowej**

Pobierz dane raportu przed tworzeniem prezentacji, a następnie przekaż je do kroków tworzenia wykresu, tabeli i generowania tekstu. Użyj osobnej ścieżki wyjściowej dla każdego zadania. Po zapisaniu aplikacja może przesłać plik do pamięci obiektowej lub zwrócić go jako pobranie.

Utrzymuj JVM działającą pomiędzy zadaniami w tym samym procesie pracownika i zwalniaj każdą prezentację po zakończeniu jej zadania. Dołącz czcionki wymagane przez projekt raportu do wdrożenia, aby zmniejszyć różnice między środowiskami.

## **Podsumowanie**

Ten przykład generuje kompletną prezentację biznesową z Pythona, wykorzystując edytowalne wykresy, tabele i tekst. Zastąpienie przykładowych danych danymi aplikacji sprawia, że to samo podejście jest przydatne do cyklicznych raportów, prezentacji dla klientów i materiałów edukacyjnych.

## **FAQ**

**Czy skrypt wymaga Microsoft PowerPoint lub Excel?**

Nie. Aspose.Slides tworzy slajdy oraz wbudowany skoroszyt wykresu bez potrzeby posiadania którejkolwiek z tych aplikacji.

**Dlaczego przykład tabeli używa tablic Java?**

Podstawowa metoda przyjmuje tablice Java typu double. Jawne tablice ułatwiają zrozumienie typów liczbowych przekazywanych przez JPype.

**Czy mogę zapisać tę samą prezentację jako PDF lub ODP?**

Tak. Przed zwolnieniem prezentacji, zapisz ją pod inną nazwą pliku wyjściowego, używając odpowiedniej wartości [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/). Zobacz [Supported File Formats](/slides/pl/python-java/supported-file-formats/) po informacje o możliwościach poszczególnych formatów.

**Czy mogę użyć szablonu firmowego?**

Tak. Załaduj swój szablon zamiast tworzyć pustą prezentację, a następnie dostosuj układ i wybór pól zastępczych do tego szablonu. Przykład zakłada układy i kolejność pól zastępczych nowej domyślnej prezentacji.