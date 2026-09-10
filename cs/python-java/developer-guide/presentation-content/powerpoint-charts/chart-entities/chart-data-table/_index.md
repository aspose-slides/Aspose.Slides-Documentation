---
title: Přizpůsobení tabulek dat grafů v prezentacích pomocí Pythonu
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
description: "Přizpůsobte tabulky dat grafů v Pythonu pro PPT a PPTX s Aspose.Slides for Python via Java a zvyšte efektivitu a atraktivitu prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tabulkami dat grafu v Aspose.Slides. Ukazuje, jak zobrazit tabulku dat pro graf a přizpůsobit formátování textu nastavením vlastností písma, jako je tučný styl a výška písma. Příklad demonstruje vytvoření prezentace, přidání grafu, povolení tabulky dat grafu, aplikaci nastavení písma a uložení aktualizované prezentace.

C také obsahuje stručné odpovědi na běžné otázky o zobrazování legendových klíčů v tabulce dat grafu, zachování tabulky dat při exportu, práci s grafy načtenými ze stávajících prezentací nebo šablon a identifikaci grafů, u nichž je tabulka dat povolena.

## **Nastavit vlastnosti písma pro tabulku dat grafu**

Aspose.Slides for Python via Java umožňuje zobrazit tabulku dat grafu a změnit vlastnosti písma jeho textu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Přidejte graf na snímek.
1. Zobrazte tabulku dat grafu.
1. Nastavte tučný styl a výšku písma textu v tabulce dat.
1. Uložte upravenou prezentaci.

Následující příklad demonstruje tyto kroky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Vytvořte prázdnou prezentaci.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu zobrazit malé legendové klíče vedle hodnot v tabulce dat grafu?**

Ano. Tabulka dat podporuje [legendové klíče](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datatable/#setShowLegendKey) a můžete je zapnout nebo vypnout.

**Zůstane tabulka dat zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykresluje graf jako součást snímku, takže exportovaný [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/cs/python-java/convert-powerpoint-to-html/)/[image](/slides/cs/python-java/convert-powerpoint-to-png/) obsahuje graf s jeho tabulkou dat.

**Jsou tabulky dat podporovány u grafů, které pocházejí ze souboru šablony?**

Ano. U libovolného grafu načteného ze stávající prezentace nebo šablony můžete pomocí vlastností grafu zkontrolovat a změnit, zda je tabulka dat [zobrazena](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#hasDataTable).

**Jak mohu rychle najít, které grafy v souboru mají povolenou tabulku dat?**

Prohlédněte vlastnost každého grafu, která uvádí, zda je tabulka dat [zobrazena](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#hasDataTable), a projděte snímky, abyste identifikovali grafy, u nichž je povolena.