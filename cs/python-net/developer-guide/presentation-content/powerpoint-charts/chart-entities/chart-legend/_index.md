---
title: Přizpůsobení legend grafů v prezentacích pomocí Pythonu
linktitle: Legenda grafu
type: docs
url: /cs/python-net/chart-legend/
keywords:
- legenda grafu
- umístění legendy
- velikost písma
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro Python prostřednictvím .NET, abyste optimalizovali prezentace v PowerPointu a OpenDocument s upraveným formátováním legend."
---
## **Přehled**

Aspose.Slides pro Python poskytuje úplnou kontrolu nad legendami grafů, takže můžete učinit popisky dat čistými a připravenými k prezentaci. Můžete legendu zobrazit nebo skrýt, zvolit její umístění na snímku a upravit rozvržení tak, aby nedocházelo k překrytí s oblastí grafu. API umožňuje stylovat text a značky, jemně ladit odsazení a pozadí a formátovat okraje a výplně tak, aby odpovídaly vašemu motivu. Vývojáři mohou také přistupovat k jednotlivým položkám legendy, přejmenovávat je nebo je filtrovat, aby se zobrazovaly jen nejrelevantnější řady. Díky těmto možnostem zůstávají vaše grafy čitelné, konzistentní a v souladu s designovými standardy vaší prezentace.

## **Umístění legendy**

Pomocí Aspose.Slides můžete rychle řídit, kde se legenda grafu zobrazí a jak zapadá do rozvržení snímku. Naučte se, jak legendu umístit přesně.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek.
1. Přidejte graf na snímek.
1. Nastavte vlastnosti legendy.
1. Uložte prezentaci jako soubor PPTX.

V níže uvedeném příkladu nastavujeme pozici a velikost legendy grafu:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:

    # Získejte odkaz na snímek.
    slide = presentation.slides[0]

    # Přidejte na snímek sloupcový graf s klastrováním.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Nastavte vlastnosti legendy.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Uložte prezentaci na disk.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení velikosti písma legendy**

Legenda grafu by měla být stejně čitelná jako data, která vysvětluje. Tato sekce ukazuje, jak upravit velikost písma legendy, abyste mohli sladit typografii prezentace a zlepšit přístupnost.

1. Instancujte třídu [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Vytvořte graf.
1. Nastavte velikost písma.
1. Uložte prezentaci na disk.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení velikosti písma pro položku legendy**

Aspose.Slides vám umožňuje jemně doladit vzhled legend grafů formátováním jednotlivých položek. Níže uvedený příklad ukazuje, jak zaměřit konkrétní položku legendy a nastavit její vlastnosti, aniž byste měnili zbytek legendy.

1. Instancujte třídu [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Vytvořte graf.
1. Přistupte k položce legendy.
1. Nastavte vlastnosti položky.
1. Uložte prezentaci na disk.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Mohu povolit legendu tak, aby graf automaticky vyčlenil pro ni prostor místo překrytí?**

Ano. Použijte režim bez překrytí ([overlay](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/legend/overlay/) = `false`); v tomto případě se oblast grafu zmenší, aby uvolnila místo pro legendu.

**Mohu vytvořit víceliniové popisky legendy?**

Ano. Dlouhé popisky se automaticky zalamují, když není dostatek místa; vynucené zalomení řádku je podporováno pomocí znaků nového řádku v názvu řady.

**Jak zajistit, aby legenda sledovala barevné schéma motivu prezentace?**

Nenastavujte explicitní barvy/výplně/písma pro legendu ani její text. Ty pak zdědí nastavení z motivu a při změně designu se automaticky aktualizují.