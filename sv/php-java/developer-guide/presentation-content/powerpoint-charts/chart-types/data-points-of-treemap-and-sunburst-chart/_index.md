---
title: Anpassa datapunkter i treemap och sunburst-diagram med PHP
linktitle: Datapunkter i treemap och sunburst-diagram
type: docs
url: /sv/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-diagram
- sunburst-diagram
- datapunkt
- etikettfärg
- grenfärg
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du hanterar datapunkter i treemap- och sunburst-diagram med Aspose.Slides för PHP via Java, kompatibel med PowerPoint-format."
---
## **Introduktion**

Bland andra typer av PowerPoint‑diagram finns två “hierarkiska” typer – **Treemap** och **Sunburst**‑diagram (även känt som Sunburst‑graf, Sunburst‑diagram, Radialdiagram, Radialgraf eller Flernivå‑tårtdiagram). Dessa diagram visar hierarkiska data organiserade som ett träd – från löv till grenens topp. Löv definieras av seriedatapunkterna, och varje efterföljande nästlade gruppering definieras av motsvarande kategori. Aspose.Slides för PHP via Java möjliggör formatering av datapunkter i Sunburst‑diagram och Treemap.

Här är ett Sunburst‑diagram, där data i kolumnen Series1 definierar löv‑noderna, medan andra kolumner definierar hierarkiska datapunkter:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Låt oss börja med att lägga till ett nytt Sunburst‑diagram i presentationen:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Se också" %}} 
- [**Skapa eller uppdatera PowerPoint‑presentationer diagram i PHP**](/slides/sv/php-java/create-chart/)
{{% /alert %}}

Om det behövs att formatera datapunkterna i diagrammet bör vi använda följande:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapointlevelsmanager/), 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapointlevel/) klasser 
och [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) metod 
ger åtkomst för att formatera datapunkter i Treemap‑ och Sunburst‑diagram. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapointlevelsmanager/)
används för att komma åt flernivåkategorier – det representerar behållaren för 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapointlevel/) objekt.
I princip är det en wrapper för 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartcategorylevelsmanager/) med
egenskaper som lagts till specifikt för datapunkter. 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapointlevel/) klassen har
två metoder: [**getFormat**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapointlevel/#getFormat) och 
[**getDataLabel**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapointlevel/#getLabel) som
ger åtkomst till motsvarande inställningar.

## **Visa ett datapunktvärde**
Visa värdet på datapunkten “Leaf 4”:

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ställ in en datapunktetikett och färg**
Ställ in datapunktetiketten för “Branch 1” så att den visar serienamnet (“Series1”) istället för kategorinamn. Ställ sedan in textfärgen till gul:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ställ in färg för datapunktgren**
Ändra färg på grenen “Steam 4”:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Kan jag ändra ordningen (sorteringen) på segment i Sunburst/Treemap?**

Nej. PowerPoint sorterar segment automatiskt (vanligtvis efter fallande värden, medurs). Aspose.Slides speglar detta beteende: du kan inte ändra ordningen direkt; du måste göra det genom att förbehandla data.

**Hur påverkar presentationens tema färgerna på segment och etiketter?**

Diagramfärger ärver presentationens [theme/palette](/slides/sv/php-java/presentation-theme/) såvida du inte explicit anger fyllningar/typsnitt. För konsekventa resultat bör du låsa in solida fyllningar och textformatering på de nivåer som krävs.

**Behåller export till PDF/PNG anpassade grenfärger och etikettinställningar?**

Ja. Vid export av presentationen bevaras diagraminställningarna (fyllningar, etiketter) i de exporterade formaten eftersom Aspose.Slides renderar med diagrammets formattering applicerad.

**Kan jag beräkna de faktiska koordinaterna för en etikett/element för att placera egna överlägg ovanpå diagrammet?**

Ja. När diagrammets layout har validerats är faktiska *x* och faktiska *y* tillgängliga för element (t.ex. en [DataLabel](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabel/)), vilket underlättar exakt placering av överlägg.