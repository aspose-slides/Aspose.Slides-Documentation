---
title: Gérer les infobulles dans les graphiques de présentation à l'aide de Python
linktitle: Infobulle
type: docs
url: /fr/python-java/callout/
keywords:
- infobulle de graphique
- utiliser une infobulle
- étiquette de données
- format d'étiquette
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Créer et styliser des infobulles dans Aspose.Slides pour Python via Java avec des exemples de code concis, compatibles avec PPT et PPTX pour automatiser les flux de travail de présentation."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les infobulles pour les étiquettes de données de graphique dans Aspose.Slides. Il montre comment utiliser la méthode [setShowLabelAsDataCallout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) pour afficher les étiquettes sous forme d'infobulles, comment configurer les paramètres d'étiquette liés aux infobulles pour un graphique en anneau, et indique que les infobulles et leur apparence sont conservées lors de l'exportation des présentations vers PDF, HTML5, SVG et les formats d'images matricielles.

## **Utilisation des infobulles**

Les méthodes [getShowLabelAsDataCallout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) et [setShowLabelAsDataCallout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) de la classe [DataLabelFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabelformat/) déterminent si une étiquette de données de graphique est affichée sous forme d'infobulle ou comme une étiquette de données ordinaire.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400)
    labels = chart.getChartData().getSeries().get_Item(0).getLabels()
    default_label_format = labels.getDefaultDataLabelFormat()
    default_label_format.setShowValue(True)
    default_label_format.setShowLabelAsDataCallout(True)
    labels.get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(False)

    presentation.save("DisplayCharts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir une infobulle pour un graphique en anneau**

Aspose.Slides pour Python via Java prend en charge la définition de la forme d'infobulle de l'étiquette de données de série pour un graphique en anneau. L'exemple suivant le montre.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat, TextAutofitType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, False)
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(False)

    for series_index in range(15):
        series_cell = workbook.getCell(0, 0, series_index + 1, f"SERIES {series_index}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        series.setExplosion(0)
        series.getParentSeriesGroup().setDoughnutHoleSize(jpype.JByte(20))
        series.getParentSeriesGroup().setFirstSliceAngle(351)

    for category_index in range(15):
        category_cell = workbook.getCell(0, category_index + 1, 0, f"CATEGORY {category_index}")
        chart.getChartData().getCategories().add(category_cell)
        for i in range(chart.getChartData().getSeries().size()):
            series = chart.getChartData().getSeries().get_Item(i)
            data_cell = workbook.getCell(0, category_index + 1, i + 1, jpype.JInt(1))
            data_point = series.getDataPoints().addDataPointForDoughnutSeries(data_cell)
            data_point.getFormat().getFill().setFillType(FillType.Solid)
            line_format = data_point.getFormat().getLine()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)
            line_format.setWidth(1)
            line_format.setStyle(LineStyle.Single)
            line_format.setDashStyle(LineDashStyle.Solid)
            if i == chart.getChartData().getSeries().size() - 1:
                label = data_point.getLabel()
                label.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape)
                label_format = label.getDataLabelFormat()
                portion_format = label_format.getTextFormat().getPortionFormat()
                portion_format.setFontBold(NullableBool.True_)
                font = FontData("DINPro-Bold")
                portion_format.setLatinFont(font)
                portion_format.setFontHeight(12)
                portion_format.getFillFormat().setFillType(FillType.Solid)
                portion_format.getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)
                label_format.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.WHITE)
                label_format.setShowValue(False)
                label_format.setShowCategoryName(True)
                label_format.setShowSeriesName(False)
                label_format.setShowLeaderLines(True)
                label_format.setShowLabelAsDataCallout(False)
                chart.validateChartLayout()
                label.setX(label.getX() + 0.5)
                label.setY(label.getY() + 0.5)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Les infobulles sont-elles conservées lors de la conversion d'une présentation en PDF, HTML5, SVG ou images ?**

Oui. Les infobulles font partie du rendu du graphique, de sorte que lors de l'exportation vers [PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/fr/python-java/export-to-html5/), [SVG](/slides/fr/python-java/render-a-slide-as-an-svg-image/) ou [images matricielles](/slides/fr/python-java/convert-powerpoint-to-png/), elles sont conservées avec le formatage de la diapositive.

**Les polices personnalisées fonctionnent-elles dans les infobulles, et leur apparence peut-elle être conservée lors de l'exportation ?**

Oui. Aspose.Slides prend en charge [l'intégration de polices](/slides/fr/python-java/embedded-font/) dans la présentation et contrôle l'intégration des polices lors des exportations comme le [PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/), garantissant que les infobulles conservent le même aspect sur différents systèmes.