---
title: Spravovat datové řady grafu v Pythonu
linktitle: Datové řady
type: docs
url: /cs/python-net/chart-series/
keywords:
- řady grafu
- překrytí řady
- barva řady
- barva kategorie
- název řady
- datový bod
- mezera řady
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se spravovat datové řady grafu v Pythonu pro PowerPoint (PPT/PPTX) s praktickými příklady kódu a osvědčenými postupy pro vylepšení vašich datových prezentací."
---
## **Přehled**

Tento článek popisuje roli [ChartSeries](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/) v Aspose.Slides pro Python, zaměřuje se na to, jak jsou data strukturována a vizualizována v prezentacích. Tyto objekty poskytují základní prvky, které definují jednotlivé sady datových bodů, kategorie a parametry vzhledu v grafu. Prací s [ChartSeries](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/), mohou vývojáři snadno integrovat podkladové zdroje dat a udržovat plnou kontrolu nad tím, jak jsou informace zobrazeny, což vede k dynamickým, na datech založeným prezentacím, které jasně předávají poznatky a analýzy.

Řada je řádek nebo sloupec čísel vykreslených v grafu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí řady**

Vlastnost [ChartSeries.overlap](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/overlap/) řídí, jak se sloupce a pruhy překrývají v 2D grafu, pomocí specifikace rozsahu od -100 do 100. Protože tato vlastnost je spojena se skupinou řad, nikoli s jednotlivou řadou grafu, je na úrovni řady jen pro čtení. Pro nastavení hodnot překrytí použijte vlastnost `parent_series_group.overlap` s možností čtení/zápisu, která aplikuje zadané překrytí na všechny řady v této skupině.

Níže je ukázka v Pythonu, která demonstruje, jak vytvořit prezentaci, přidat seskupený sloupcový graf, získat první řadu grafu, nastavit parametr překrytí a poté uložit výsledek jako soubor PPTX:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Přidejte seskupený sloupcový graf s výchozími daty.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Nastavte překrytí řady.
        series.parent_series_group.overlap = series_overlap

    # Uložte soubor prezentace na disk.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![The series overlap](series_overlap.png)

## **Změna barvy výplně řady**

Aspose.Slides usnadňuje přizpůsobení barev výplně řad grafu, což vám umožní zvýraznit konkrétní datové body a vytvořit vizuálně atraktivní grafy. To je dosaženo pomocí objektu [Format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/format/), který podporuje různé typy výplní, konfigurace barev a další pokročilé možnosti stylování. Po přidání grafu do snímku a získání požadované řady jednoduše získáte řadu a použijete vhodnou barvu výplně. Kromě plných výplní můžete využít také gradientní nebo vzorové výplně pro větší flexibilitu designu. Jakmile nastavíte barvy podle svých požadavků, uložte prezentaci, aby se aktualizovaný vzhled aplikoval.

Následující ukázka kódu v Pythonu ukazuje, jak změnit barvu první řady:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Přidejte seskupený sloupcový graf s výchozími daty.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Nastavte barvu první řady.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Uložte soubor prezentace na disk.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![The color of the series](series_color.png)

## **Přejmenování řady**

Aspose.Slides nabízí jednoduchý způsob, jak upravit názvy řad grafu, což usnadňuje označení dat jasně a smysluplně. Přístupem k příslušné buňce listu v datech grafu mohou vývojáři přizpůsobit, jak jsou data zobrazena. Tato úprava je zvláště užitečná, když je třeba názvy řad aktualizovat nebo upřesnit podle kontextu dat. Po přejmenování řady lze prezentaci uložit, aby změny zůstaly zachovány.

Níže je úryvek kódu v Pythonu, který demonstruje tento proces v praxi.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Přidejte seskupený sloupcový graf s výchozími daty.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Nastavte název první řady.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Uložte soubor prezentace na disk.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Následující kód v Pythonu ukazuje alternativní způsob, jak změnit název řady:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Přidejte seskupený sloupcový graf s výchozími daty.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Nastavte název první řady.
    series.name.as_cells[0].value = series_name

    # Uložte soubor prezentace na disk.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```

Výsledek:

![The series name](series_name.png)

## **Získání automatické barvy výplně řady**

Aspose.Slides pro Python vám umožňuje získat automatickou barvu výplně řady grafu v oblasti grafu. Po vytvoření instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/), můžete získat odkaz na požadovaný snímek podle indexu, poté přidat graf pomocí preferovaného typu (například `ChartType.CLUSTERED_COLUMN`). Přístupem k řadám v grafu můžete získat automatickou barvu výplně.

Následující kód v Pythonu podrobně demonstruje tento proces:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Přidejte seskupený sloupcový graf s výchozími daty.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Získejte barvu výplně řady.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```

Ukázkový výstup:

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Nastavení invertované barvy výplně pro řadu**

Když vaše datová řada obsahuje jak kladné, tak záporné hodnoty, jednoduché obarvení každého sloupce nebo pruhu stejnou barvou může graf učinit těžko čitelným. Aspose.Slides pro Python vám umožňuje přiřadit invertovanou barvu výplně – samostatnou výplň aplikovanou automaticky na datové body pod nulou – takže záporné hodnoty jsou okamžitě patrné. V této sekci se naučíte, jak tuto možnost povolit, vybrat vhodnou barvu a uložit aktualizovanou prezentaci.

Následující ukázka kódu demonstruje operaci:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Přidejte nové kategorie.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Přidejte novou řadu.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Naplněte data řady.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Nastavte nastavení barev pro řadu.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![The inverted solid fill color](inverted_solid_fill_color.png)

Můžete invertovat barvu výplně pro jediný datový bod namísto celé řady. Stačí získat požadovaný `ChartDataPoint` a nastavit jeho `invert_if_negative` vlastnost na `True`.

Následující ukázka kódu ukazuje, jak to provést:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Vymazání dat pro konkrétní datové body**

Někdy graf obsahuje testovací hodnoty, odlehlé body nebo zastaralé záznamy, které je třeba odstranit bez nutnosti přestavovat celou řadu. Aspose.Slides pro Python vám umožňuje cílit na libovolný datový bod podle indexu, vymazat jeho obsah a okamžitě obnovit graf, takže zbývající body se posunou a osy se automaticky přepočítají.

Následující ukázka kódu demonstruje operaci:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení šířky mezery řady**

Šířka mezery řady určuje množství volného prostoru mezi sousedními sloupci nebo pruhy – širší mezery zdůrazňují jednotlivé kategorie, zatímco užší mezery vytvářejí hustší, kompaktnější vzhled. Pomocí Aspose.Slides pro Python můžete tento parametr jemně doladit pro celou řadu, čímž získáte přesně vizuální rovnováhu, kterou vaše prezentace vyžaduje, aniž byste měnili podkladová data.

Následující ukázka kódu ukazuje, jak nastavit šířku mezery pro řadu:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Vytvořte prázdnou prezentaci.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte graf s výchozími daty.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Uložte prezentaci na disk.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # Nastavte hodnotu gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Uložte prezentaci na disk.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![The gap width](gap_width.png)

## **Často kladené otázky**

**Existuje omezení, kolik řad může jeden graf obsahovat?**

Aspose.Slides nevyžaduje žádný pevný limit na počet řad, které přidáte. Praktické omezení určuje čitelnost grafu a množství paměti dostupné vaší aplikaci.

**Co když jsou sloupce v rámci skupiny příliš blízko u sebe nebo naopak příliš daleko od sebe?**

Upravte nastavení [gap_width](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/gap_width/) pro tuto řadu (nebo její nadřazenou skupinu řad). Zvýšením hodnoty zvětšíte prostor mezi sloupci, snížením hodnoty je přiblížíte k sobě.