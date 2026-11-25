---
title: Personalizza grafici 3D in presentazioni usando PHP
linktitle: Grafico 3D
type: docs
url: /it/php-java/3d-chart/
keywords:
- grafico 3D
- rotazione
- profondità
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Crea grafici 3D in presentazioni PowerPoint con Aspose.Slides per PHP via Java. Regola rotazione, proporzioni di altezza, profondità del grafico e spaziatura tra le serie con esempi PHP."
---
## **Panoramica**

Aspose.Slides per PHP via Java consente di personalizzare la visualizzazione di un grafico 3D tramite il metodo [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). Questo articolo dimostra come regolare la rotazione, le proporzioni di altezza, la profondità, gli assi a angolo retto e lo spazio tra le serie, quindi salvare la presentazione nel formato PPTX.

## **Imposta la rotazione e la profondità di un grafico 3D**

L’esempio seguente crea una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) e utilizza [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) per aggiungere un grafico a colonne 3D impilato alla sua prima diapositiva. Sostituisce le serie e le categorie predefinite con due serie contenenti tre valori ciascuna. L’indice del foglio di lavoro `0` identifica il primo foglio dati del grafico; la riga `0` contiene i nomi delle serie e la colonna `0` contiene le etichette delle categorie.

I metodi [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) e [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) impostano la rotazione del grafico a 40 e 270 gradi, rispettivamente. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) ne imposta la profondità al 150 % della larghezza, mentre [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) abilita assi a angolo retto anziché prospettiva. La presentazione risultante contiene il grafico popolato con queste impostazioni di visualizzazione 3D.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Applica un riempimento immagine alla superficie di un grafico 3D**

È possibile riempire indipendentemente la [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), il [back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) e il [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) di un grafico 3D. Impostare il [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) della superficie su `Picture` e assegnare un’immagine. Impostare sia il [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) sia il [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) della superficie su `Stretch` per adattare una copia dell’immagine all’intera superficie.

Salvare [arrow.png](arrow.png) accanto allo script PHP. L’esempio ruota il grafico e alza il valore massimo sull’asse verticale in modo che il pavimento sia visibile tra le colonne. Quindi clona la diapositiva due volte e applica la freccia a una superficie diversa in ciascuna diapositiva. Tutti e tre i grafici mantengono gli stessi dati, l’angolo di visualizzazione e lo sfondo.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint mostra le tre diapositive come segue.

| Parete laterale | Parete posteriore | Pavimento |
| --- | --- | --- |
| ![Freccia che punta nel grafico lungo la parete laterale](side-wall.png) | ![Freccia che punta a destra lungo la parete posteriore](back-wall.png) | ![Freccia che punta a destra sul pavimento tra le colonne](floor.png) |

## **Regola le proporzioni di altezza di un grafico 3D**

Usare [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) per impostare l’altezza di un grafico 3D come percentuale della sua larghezza. Questo modifica le proporzioni della scena 3D senza ridimensionare l’oggetto grafico sulla diapositiva.

L’esempio seguente crea un grafico [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) con i dati predefiniti: tre serie e quattro categorie. Salva tre presentazioni con proporzioni di altezza del 50 %, 100 % e 200 %. La posizione, la larghezza e l’altezza del grafico rimangono fisse. I dati, la rotazione, la profondità, lo spazio tra le serie e la formattazione sono identici in tutti e tre i file; varia solo la percentuale di altezza.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Le immagini seguenti illustrano le stesse impostazioni di altezza nell’esempio .NET equivalente e sono state esportate con Microsoft PowerPoint. Una percentuale più piccola produce una scena più piatta, mentre una percentuale più grande produce una scena più alta all’interno dello stesso oggetto grafico. PowerPoint può anche regolare gli intervalli dei tic degli assi e la disposizione delle etichette per adattare la scena.

| Altezza: 50% | Altezza: 100% | Altezza: 200% |
| --- | --- | --- |
| ![Grafico a colonne 3D con altezza impostata al 50 percento della sua larghezza](height_percent_50.png) | ![Grafico a colonne 3D con altezza impostata al 100 percento della sua larghezza](height_percent_100.png) | ![Grafico a colonne 3D con altezza impostata al 200 percento della sua larghezza](height_percent_200.png) |

Questi metodi controllano diversi aspetti del grafico:

| Metodo | Effetto |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Altezza della scena 3D come percentuale della sua larghezza. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Altezza dell’oggetto grafico sulla diapositiva, in punti. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Profondità della scena 3D come percentuale della sua larghezza. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Spaziatura tra le serie lungo l’asse di profondità, come percentuale della larghezza del marcatore. |

L’impostazione dell’altezza influisce su grafici a colonne e a barre 3D, incluse le varianti cilindro, cono e piramide, così come su grafici 3D a linee, aree, torte e superfici. Il confronto sopra utilizza il tipo verificato `Column3D`. L’impostazione non modifica l’aspetto di un grafico 2D `ClusteredColumn` o di un grafico `BubbleWith3D`; questi nomi sono membri della classe [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Per altre impostazioni di aspetto del grafico, consultare [Chart Formatting](/slides/it/php-java/chart-formatting/).

## **Regola lo spazio tra le serie**

Usare [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) per controllare la distanza tra le serie di dati lungo l’asse di profondità di un grafico 3D, espressa come percentuale della larghezza del marcatore. Utilizzare valori da **0 a 500**, inclusi: `0` rimuove lo spazio, mentre valori più alti aumentano l’intervallo. Con una profondità del grafico fissa, aumentare lo spazio rende i marcatori più sottili lungo l’asse di profondità.

Accedere al gruppo tramite [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). L’impostazione si applica a tutte le serie del gruppo, non solo a quella usata per accedervi. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) restituisce lo spazio di profondità e riflette l’impostazione del gruppo genitore.

Questa impostazione influisce su grafici a colonne e a barre 3D, incluse le varianti cilindro, cono e piramide, nonché su grafici 3D a linee e a aree. L’aspetto dipende dal fatto che le serie siano disposte in profondità, raggruppate o impilate. Per un confronto chiaro degli spazi tra serie separate, usare `ChartType::Column3D` dalla classe [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Questi metodi controllano diversi aspetti del grafico:

| Metodo | Effetto |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Spaziatura tra le serie lungo l’asse di profondità, come percentuale della larghezza del marcatore. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Spaziatura tra i gruppi adiacenti di barre o colonne, come percentuale della larghezza della barra o colonna. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Profondità complessiva del grafico, come percentuale della larghezza del grafico. |

L’esempio autonomo seguente utilizza i dati di default del grafico, che contengono tre serie e quattro categorie. Salva due presentazioni con dati, rotazione, larghezza dello spazio e profondità del grafico identici; varia solo la profondità dello spazio.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Le immagini seguenti illustrano le stesse impostazioni di profondità dello spazio nell’esempio .NET equivalente e sono state esportate con Microsoft PowerPoint.

| Profondità del gap: 0% | Profondità del gap: 500% |
| --- | --- |
| ![Grafico a colonne 3D senza spazio tra le serie lungo l’asse di profondità](gap_depth_0.png) | ![Grafico a colonne 3D con un gap del 500 percento tra le serie lungo l’asse di profondità](gap_depth_500.png) |

## **Modifica il tipo di serie 3D e la forma della barra**

In un grafico a cilindri raggruppati, la prima serie inizia con una forma di barra cilindrica. L’esempio stampa i valori interi restituiti da [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) e [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) prima e dopo ogni modifica. La tabella fornisce i nomi costanti corrispondenti.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Modifica alla prima serie | Tipo di serie | Forma della barra |
| --- | --- | --- |
| Creazione del grafico | `ClusteredCylinder` | `Cylinder` |
| Impostare il tipo di serie su `ClusteredCone` | `ClusteredCone` | `Cone` |
| Impostare la forma della barra su `Box` | `ClusteredColumn3D` | `Box` |

Impostare la forma su `Box` modifica anche il tipo di serie in `ClusteredColumn3D`. Se il codice decide in base al tipo di serie, chiamare [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) dopo aver cambiato la forma. Un valore memorizzato prima dell’assegnazione selezionerebbe ancora il ramo `ClusteredCone`.

![Confronto PowerPoint che mostra la prima serie come cilindri, coni e colonne rettangolari da sinistra a destra](series-shapes.png)

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta le varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, oltre ai tipi 3D correlati esposti attraverso la classe [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Per un elenco preciso e aggiornato, consultare i membri di [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) nella referenza API della versione installata.

**Posso ottenere un’immagine raster di un grafico 3D per un report o il Web?**

Sì. È possibile esportare un grafico in un’immagine con [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) o [renderizzare l’intera diapositiva](/slides/it/php-java/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando serve un’anteprima raster o si desidera incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Qual è l’efficienza nella costruzione e renderizzazione di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per ottenere i migliori risultati, mantenere gli effetti 3D minimi, evitare texture pesanti su pareti e aree di tracciatura, limitare il numero di punti dati per serie quando possibile e renderizzare con una risoluzione e dimensioni adeguate al dispositivo di visualizzazione o stampa previsto.