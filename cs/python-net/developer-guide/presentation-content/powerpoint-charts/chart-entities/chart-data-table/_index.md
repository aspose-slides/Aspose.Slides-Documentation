---
title: Přizpůsobení tabulek dat grafu v prezentacích v Pythonu
linktitle: Datová tabulka
type: docs
url: /cs/python-net/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Přizpůsobte písma, okraje a klíče legendy v tabulkách dat grafu v prezentacích PowerPoint pomocí Aspose.Slides pro Python prostřednictvím .NET."
---
## **Přehled**

Aspose.Slides pro Python prostřednictvím .NET vám umožňuje zobrazit tabulku dat grafu a přizpůsobit její formátování textu, okraje a popisky legendy. Tento článek vysvětluje, jak povolit tabulku, formátovat její text, ovládat každý typ okraje a zobrazit nebo skrýt popisky legendy. Příklady ukládají nakonfigurované grafy do souborů PPTX.

## **Nastavení vlastností písma**

Chcete-li zobrazit tabulku dat grafu, nastavte [has_data_table](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/has_data_table/) na `True`. Použijte [chart_data_table](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/chart_data_table/) pro přístup k tabulce a nastavení formátování textu.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Přidejte na první snímek klastrový sloupcový graf.
3. Povolte tabulku dat grafu.
4. Povolte tučný text pomocí [font_bold](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/font_bold/) a nastavte [font_height](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/font_height/) na `20` pro 20‑bodový text.
5. Uložte upravenou prezentaci.

Následující příklad vyžaduje soubor `test.pptx` v pracovním adresáři s alespoň jedním snímkem. Přidá graf s výchozími daty na pozici (50, 50) se šířkou 600 bodů a výškou 400 bodů. Uložený soubor `output.pptx` obsahuje graf s povolenou tabulkou dat a aplikovanými nastaveními písma.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Přizpůsobení okrajů tabulky dat**

Povolit tabulku pomocí [Chart.has_data_table](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/has_data_table/) a získat k ní přístup přes [Chart.chart_data_table](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/chart_data_table/). Můžete nezávisle ovládat tři typy okrajů:

- [has_border_horizontal](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datatable/has_border_horizontal/) řídí vodorovné okraje buněk.
- [has_border_vertical](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datatable/has_border_vertical/) řídí svislé okraje buněk.
- [has_border_outline](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datatable/has_border_outline/) řídí vnější okraj tabulky.

Nastavte každou vlastnost na `True`, aby se okraje zobrazily, nebo na `False`, aby se skryly. Následující příklad vytvoří klastrový sloupcový graf s výchozími daty, zobrazí vodorovné okraje a vnější okraj a skryje svislé okraje. Nevytváří se žádný vstupní soubor. Pozice a velikost grafu jsou zadány v bodech.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

Srovnání níže používá stejná data grafu a nastavení klíčů legendy ve všech čtyřech případech. Začíná se se všemi povolenými okraji, každá následující varianta zakáže jen jednu vlastnost okraje. Varianta v levém dolním rohu odpovídá nastavením okrajů v příkladu.

![Tabulky dat grafu se všemi povolenými okraji, bez vodorovných okrajů, bez svislých okrajů a bez vnějšího okraje](data-table-borders.png)

## **Zobrazení nebo skrytí klíčů legendy**

Klíče legendy jsou malé barevné značky vedle názvů řad v tabulce dat. Pomáhají čtenářům přiřadit každý řádek tabulky k řadě grafu. Nastavte [show_legend_key](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datatable/show_legend_key/) na `True`, chcete-li tyto značky zobrazit, nebo na `False`, chcete-li je skrýt.

Samostatná legenda grafu je řízena pomocí [Chart.has_legend](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/has_legend/). Tato nastavení jsou nezávislá: skrytí samostatné legendy neskryje klíče uvnitř tabulky dat a skrytí klíčů v tabulce neskryje samostatnou legendu.

Následující příklad vytvoří graf s výchozími daty, povolí jeho tabulku dat a zobrazí v ní klíče legendy při skrytí samostatné legendy. Všechny okraje tabulky jsou explicitně povoleny. Není požadována žádná vstupní prezentace. Chcete-li skrýt pouze klíče tabulky, změňte `data_table.show_legend_key` na `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

Srovnání níže ukazuje stejnou tabulku s klíči legendy zapnutými a vypnutými. Všechny okraje zůstávají povoleny a samostatná legenda grafu je v obou případech skryta.

![Tabulky dat grafu s klíči legendy zobrazenými vlevo a skrytými vpravo](data-table-legend-keys.png)

## **Často kladené otázky**

**Mohu v tabulce dat grafu zobrazit klíče legendy?**

Ano. Nastavte [show_legend_key](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datatable/show_legend_key/) na `True` pro zobrazení klíčů legendy nebo na `False` pro jejich skrytí.

**Zůstane tabulka dat zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykreslí graf a jeho zobrazovanou tabulku dat jako součást snímku při exportu do [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/cs/python-net/convert-powerpoint-to-html/) nebo [images](/slides/cs/python-net/convert-powerpoint-to-png/).

**Mohu pracovat s tabulkami dat v grafech načtených ze šablony?**

Ano. Pro graf načtený z existující prezentace nebo šablony použijte [has_data_table](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/has_data_table/) k ověření nebo změně, zda je tabulka dat zobrazena.

**Jak mohu najít grafy, u kterých je povolena tabulka dat?**

Projděte tvary na každém snímku, identifikujte grafy a zkontrolujte jejich vlastnost [has_data_table](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/has_data_table/). Hodnota `True` značí, že je tabulka dat povolena.