---
title: Přizpůsobení 3D grafů v prezentacích pomocí Pythonu
linktitle: 3D graf
type: docs
url: /cs/python-net/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se vytvářet a přizpůsobovat 3-D grafy v Aspose.Slides pro Python via .NET, s podporou souborů PPT, PPTX a ODP — zvyšte úroveň svých prezentací ještě dnes."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit 3D graf v Aspose.Slides konfigurací nastavení `rotation_3d` jako `rotation_x`, `rotation_y`, `depth_percents` a `right_angle_axes`. Prochází vytvořením prezentace, přidáním 3D grafu s výchozími daty, použitím požadovaných nastavení 3D pohledu a uložením upravené prezentace jako souboru PPTX.

## **Nastavení vlastností RotationX, RotationY a DepthPercents 3D grafu**

Aspose.Slides for Python via .NET poskytuje jednoduché API pro nastavení těchto vlastností. Následující článek vám pomůže, jak nastavit různé vlastnosti jako otáčení X, Y, **DepthPercents** atd. Vzorový kód aplikuje nastavení výše zmíněných vlastností.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Nastavte vlastnosti Rotation3D.
1. Zapište upravenou prezentaci do souboru PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation
with slides.Presentation() as presentation:
            
    # Získejte první snímek
    slide = presentation.slides[0]

    # Přidejte graf s výchozími daty
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Nastavení indexu listu s daty grafu
    defaultWorksheetIndex = 0

    # Získání listu s daty grafu
    fact = chart.chart_data.chart_data_workbook

    # Přidat sérii
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Přidat kategorie
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Nastavit vlastnosti Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Vzít druhou sérii grafu
    series = chart.chart_data.series[1]

    # Nyní naplňujeme data série
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Nastavit hodnotu OverLap
    series.parent_series_group.overlap = 100         

    # Uložit prezentaci na disk
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s příbuznými 3D typy vystavenými prostřednictvím výčtu [ChartType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/charttype/) v referenční příručce API nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat do obrázku pomocí [chart API](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/get_image/) nebo [renderovat celý snímek](/slides/cs/python-net/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete pixelově přesný náhled nebo chcete vložit graf do dokumentů, dashboardů nebo webových stránek bez nutnosti PowerPointu.

**Jak výkonná je tvorba a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky udržujte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a plochách grafu, omezte počet datových bodů na sérii, pokud je to možné, a renderujte do výstupu s vhodnou velikostí (rozlišení a rozměry), aby odpovídal cílovému zobrazení nebo požadavkům na tisk.