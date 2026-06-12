---
title: Přizpůsobení tabulek dat grafu v Pythonu
linktitle: Datová tabulka
type: docs
url: /cs/python-net/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Přizpůsobte tabulky dat grafu v Pythonu pro PPT, PPTX a ODP pomocí Aspose.Slides a zvyšte efektivitu a atraktivitu prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tabulkami dat grafu v Aspose.Slides. Ukazuje, jak zobrazit tabulku dat pro graf a upravit její formátování textu nastavením vlastností písma, jako je tučný styl a výška písma. Příklad demonstruje načtení prezentace, přidání grafu, povolení tabulky dat grafu, aplikaci nastavení písma a uložení aktualizované prezentace.

Také obsahuje stručné odpovědi na často kladené otázky o zobrazování legendových klíčů v tabulce dat grafu, zachování tabulky dat při exportu, práci s grafy načtenými ze stávajících prezentací nebo šablon a identifikaci grafů, kde je tabulka dat povolena.

## **Nastavení vlastností písma pro tabulku dat grafu**
Aspose.Slides pro Python via .NET poskytuje podporu pro změnu barvy kategorií v řadě.  

1. Vytvořte objekt třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
1. Přidejte graf na snímek.
1. Nastavte tabulku grafu.
1. Nastavte výšku písma.
1. Uložte upravenou prezentaci.

Níže je uveden ukázkový příklad.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Mohu zobrazit malé legendové klíče vedle hodnot v tabulce dat grafu?**

Ano. Tabulka dat podporuje [legendové klíče](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datatable/show_legend_key/), a můžete je zapnout nebo vypnout.

**Bude tabulka dat zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykresluje graf jako součást snímku, takže exportovaný [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/cs/python-net/convert-powerpoint-to-html/)/[image](/slides/cs/python-net/convert-powerpoint-to-png/) obsahuje graf s jeho tabulkou dat.

**Jsou tabulky dat podporovány pro grafy pocházející ze souboru šablony?**

Ano. Pro libovolný graf načtený ze stávající prezentace nebo šablony můžete pomocí vlastností grafu zkontrolovat a změnit, zda je tabulka dat [zobrazena](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/has_data_table/).

**Jak mohu rychle zjistit, které grafy v souboru mají tabulku dat povolenu?**

Prohlédněte si vlastnost každého grafu, která udává, zda je tabulka dat [zobrazena](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/has_data_table/), a projděte snímky, abyste identifikovali grafy, kde je povolena.