---
title: Přizpůsobení datových tabulek grafů v prezentacích pomocí Pythonu
linktitle: Datová tabulka
type: docs
url: /cs/python-java/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Přizpůsobte písma, okraje a legendární klíče datových tabulek grafů v prezentacích PowerPoint pomocí Aspose.Slides pro Python přes Java."
---
## **Overview**

Aspose.Slides for Python via Java vám umožňuje zobrazit datovou tabulku grafu a přizpůsobit její formátování textu, okraje a legendární klíče. Tento článek vysvětluje, jak povolit tabulku, naformátovat její text, ovládat každý typ okraje a zobrazit nebo skrýt legendární klíče. Příklady ukládají nakonfigurované grafy do souborů PPTX.

## **Set Font Properties**

Pro zobrazení datové tabulky grafu předáte `True` metodě [setDataTable](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#setDataTable). Pomocí [getChartDataTable](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#getChartDataTable) získáte přístup k tabulce a nastavíte její formátování textu.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Přidejte seskupený sloupcový graf na první snímek.
1. Povolte datovou tabulku grafu.
1. Zapněte tučný text pomocí [setFontBold](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setFontBold) a předáte `20` metodě [setFontHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setFontHeight) pro 20‑bodový text.
1. Uložte upravenou prezentaci.

Následující příklad vyžaduje soubor `test.pptx` v pracovním adresáři s alespoň jedním snímkem. Přidá graf s výchozími daty na pozici (50, 50) s šířkou 600 bodů a výškou 400 bodů. Uložený soubor `output.pptx` obsahuje graf s povolenou datovou tabulkou a aplikovaným nastavením písma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Customize Data Table Borders**

Povolte tabulku pomocí [Chart.setDataTable](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#setDataTable) a přistupujte k ní přes [Chart.getChartDataTable](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#getChartDataTable). Můžete nezávisle ovládat tři typy okrajů:

- [setBorderHorizontal](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datatable/#setBorderHorizontal) řídí horizontální okraje buněk.
- [setBorderVertical](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datatable/#setBorderVertical) řídí vertikální okraje buněk.
- [setBorderOutline](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datatable/#setBorderOutline) řídí vnější okraj tabulky.

Předáte `True` každé metodě, aby se okraje zobrazily, nebo `False`, aby se skryly. Následující příklad vytvoří seskupený sloupcový graf s výchozími daty, zobrazí horizontální okraje a vnější okraj a skryje vertikální okraje. Nevytváří se žádný vstupní soubor. Pozice a velikost grafu jsou zadány v bodech.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Níže uvedené srovnání používá stejná data grafu a nastavení legendárních klíčů ve všech čtyřech případech. Začíná se se všemi povolenými okraji, každá další varianta zakáže jen jedno nastavení okraje. Varianta vlevo dole odpovídá nastavení okrajů v příkladu.

![Tabulky dat grafu se všemi povolenými okraji, bez horizontálních okrajů, bez vertikálních okrajů a bez vnějšího okraje](data-table-borders.png)

## **Show or Hide Legend Keys**

Legenda klíče jsou malé barevné značky vedle názvů řad v datové tabulce. Pomáhají čtenářům přiřadit každý řádek tabulky k sérii grafu. Předáte `True` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datatable/#setShowLegendKey), aby se tyto značky zobrazily, nebo `False`, aby se skryly.

Samostatná legenda grafu je řízena pomocí [Chart.setLegend](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#setLegend). Tato nastavení jsou nezávislá: skrytí samostatné legendy neukryje klíče v datové tabulce a skrytí klíčů v tabulce neukryje samostatnou legendu.

Následující příklad vytvoří graf s výchozími daty, povolí jeho datovou tabulku a zobrazí legendární klíče uvnitř ní, zatímco skryje samostatnou legendu. Všechny okraje tabulky jsou výslovně povoleny. Vstupní prezentace není vyžadována. Chcete-li skrýt pouze klíče tabulky, předáte `False` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Níže uvedené srovnání ukazuje stejnou tabulku se zapnutými a vypnutými legendárními klíči. Všechny okraje zůstávají povoleny a samostatná legenda grafu je v obou případech skryta.

![Tabulky dat grafu s legendárními klíči zobrazenými vlevo a skrytými vpravo](data-table-legend-keys.png)

## **FAQ**

**Mohu zobrazit legendární klíče v datové tabulce grafu?**

Ano. Předáte `True` metodě [setShowLegendKey](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datatable/#setShowLegendKey), aby se legendární klíče zobrazily, nebo `False`, aby se skryly.

**Zůstane datová tabulka zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykresluje graf a jeho zobrazenou datovou tabulku jako součást snímku při exportu do [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/cs/python-java/convert-powerpoint-to-html/) nebo [obrázků](/slides/cs/python-java/convert-powerpoint-to-png/).

**Mohu pracovat s datovými tabulkami v grafech načtených ze šablony?**

Ano. Pro graf načtený ze stávající prezentace nebo šablony použijte [hasDataTable](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#hasDataTable) a [setDataTable](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#setDataTable) ke kontrole nebo změně, zda je jeho datová tabulka zobrazena.

**Jak mohu najít grafy, které mají povolenou datovou tabulku?**

Procházejte tvary na každém snímku, identifikujte grafy a zavolejte jejich metodu [hasDataTable](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#hasDataTable). Hodnota `True` označuje, že je datová tabulka povolena.