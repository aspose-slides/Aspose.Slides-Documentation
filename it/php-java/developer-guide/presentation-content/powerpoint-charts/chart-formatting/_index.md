---
title: Formattazione dei grafici della presentazione in PHP
linktitle: Formattazione dei grafici
type: docs
weight: 60
url: /it/php-java/chart-formatting/
keywords:
  - formattazione grafico
  - formattazione grafico
  - entità grafico
  - proprietà del grafico
  - impostazioni del grafico
  - opzioni del grafico
  - proprietà del carattere
  - bordo arrotondato
  - PowerPoint
  - presentazione
  - PHP
  - Aspose.Slides
description: "Scopri la formattazione dei grafici in Aspose.Slides per PHP via Java e migliora la tua presentazione PowerPoint con uno stile professionale e accattivante."
---
## **Panoramica**

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave del grafico, come gli assi, le linee della griglia, i titoli, le legende, l'area di tracciamento e i riempimenti di parete, per migliorare l'aspetto e la leggibilità dei dati del grafico.

Dimostra inoltre come impostare le proprietà del carattere per il testo del grafico, applicare formati numerici predefiniti e personalizzati ai dati del grafico e abilitare gli angoli arrotondati per l'area del grafico. Insieme, questi esempi mostrano come controllare sia lo stile visivo sia la presentazione dei dati dei grafici in una presentazione.

## **Formattare le entità del grafico**
Aspose.Slides for PHP via Java consente agli sviluppatori di aggiungere grafici personalizzati alle proprie diapositive da zero. Questo articolo spiega come formattare diverse entità del grafico, inclusi l'asse delle categorie e l'asse dei valori.

Aspose.Slides for PHP via Java fornisce una semplice API per gestire diverse entità del grafico e formattarle utilizzando valori personalizzati:

1. Creare un'istanza della classe [**Presentation**](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottenere il riferimento di una diapositiva tramite il suo indice.
1. Aggiungere un grafico con dati predefiniti del tipo desiderato (in questo esempio useremo ChartType::LineWithMarkers).
1. Accedere all'asse dei valori del grafico e impostare le seguenti proprietà:
   1. Impostare **Line format** per le linee della griglia principale dell'asse dei valori
   1. Impostare **Line format** per le linee della griglia secondaria dell'asse dei valori
   1. Impostare **Number Format** per l'asse dei valori
   1. Impostare **Min, Max, Major and Minor units** per l'asse dei valori
   1. Impostare **Text Properties** per i dati dell'asse dei valori
   1. Impostare **Title** per l'asse dei valori
   1. Impostare **Line Format** per l'asse dei valori
1. Accedere all'asse delle categorie del grafico e impostare le seguenti proprietà:
   1. Impostare **Line format** per le linee della griglia principale dell'asse delle categorie
   1. Impostare **Line format** per le linee della griglia secondaria dell'asse delle categorie
   1. Impostare **Text Properties** per i dati dell'asse delle categorie
   1. Impostare **Title** per l'asse delle categorie
   1. Impostare **Label Positioning** per l'asse delle categorie
   1. Impostare **Rotation Angle** per le etichette dell'asse delle categorie
1. Accedere alla legenda del grafico e impostare le **Text Properties** per essa
1. Impostare la visualizzazione delle legende del grafico in modo che non si sovrappongano al grafico
1. Accedere all'**Secondary Value Axis** del grafico e impostare le seguenti proprietà:
   1. Abilitare l'**Value Axis** secondario
   1. Impostare **Line Format** per l'asse dei valori secondario
   1. Impostare **Number Format** per l'asse dei valori secondario
   1. Impostare **Min, Max, Major and Minor units** per l'asse dei valori secondario
1. Ora tracciare la prima serie del grafico sull'asse dei valori secondario
1. Impostare il colore di riempimento della parete posteriore del grafico
1. Impostare il colore di riempimento dell'area di tracciamento del grafico
1. Scrivere la presentazione modificata in un file PPTX

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    # Accesso alla prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiunta del grafico di esempio
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Impostazione del titolo del grafico
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Impostazione del formato delle linee della griglia principale per l'asse dei valori
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Impostazione del formato delle linee della griglia secondaria per l'asse dei valori
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Impostazione del formato numerico dell'asse dei valori
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Impostazione dei valori massimo e minimo del grafico
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Impostazione delle proprietà del testo dell'asse dei valori
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Impostazione del titolo dell'asse dei valori
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Impostazione del formato delle linee della griglia principale per l'asse delle categorie
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Impostazione del formato delle linee della griglia secondaria per l'asse delle categorie
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Impostazione delle proprietà del testo dell'asse delle categorie
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Impostazione del titolo dell'asse delle categorie
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Impostazione della posizione dell'etichetta dell'asse delle categorie
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Impostazione dell'angolo di rotazione delle etichette dell'asse delle categorie
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Impostazione delle proprietà del testo delle leggende
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Immagine per visualizzare le legende senza sovrapporre il grafico
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Impostazione dell'asse dei valori secondario
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Impostazione del formato numerico dell'asse dei valori secondario
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Impostazione dei valori massimo e minimo del grafico
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Impostazione del colore della parete posteriore del grafico
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Impostazione del colore dell'area di tracciamento
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Salva la presentazione
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Impostare le proprietà del carattere per un grafico**
Aspose.Slides for PHP via Java fornisce il supporto per impostare le proprietà relative al carattere per il grafico. Segui i passaggi seguenti per impostare le proprietà del carattere per il grafico.

- Istanziare l'oggetto della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
- Aggiungere un grafico nella diapositiva.
- Impostare l'altezza del carattere.
- Salvare la presentazione modificata.

Di seguito è riportato un esempio.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Impostare il formato numerico**
Aspose.Slides for PHP via Java fornisce una semplice API per gestire il formato dei dati del grafico:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Ottenere il riferimento di una diapositiva tramite il suo indice.
1. Aggiungere un grafico con dati predefiniti del tipo desiderato (questo esempio utilizza **ChartType::ClusteredColumn**).
1. Impostare il formato numerico predefinito tra i valori disponibili.
1. Scorrere le celle dei dati del grafico in ogni serie e impostare il formato numerico dei dati del grafico.
1. Salvare la presentazione.
1. Impostare un formato numerico personalizzato.
1. Scorrere le celle dei dati del grafico in ogni serie e impostare un diverso formato numerico dei dati del grafico.
1. Salvare la presentazione.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    # Accedi alla prima diapositiva della presentazione
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiunta di un grafico a colonne raggruppate predefinito
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Accesso alla raccolta delle serie del grafico
    $series = $chart->getChartData()->getSeries();
    # Scorri ogni serie del grafico
    foreach($series as $ser) {
      # Scorri ogni cella dati nella serie
      foreach($ser->getDataPoints() as $cell) {
        # Impostazione del formato numerico
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # Salvataggio della presentazione
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

I possibili valori predefiniti del formato numerico con il loro indice sono elencati di seguito:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Impostare i bordi arrotondati dell'area del grafico**
Aspose.Slides for PHP via Java fornisce il supporto per impostare l'area del grafico. I metodi [**hasRoundedCorners**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/hasroundedcorners/) e [**setRoundedCorners**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/setroundedcorners/) sono stati aggiunti alla classe [Chart](https://reference.aspose.com/slides/it/php-java/aspose.slides/Chart).

1. Istanziare l'oggetto della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Aggiungere un grafico nella diapositiva.
1. Impostare il tipo di riempimento e il colore di riempimento del grafico
1. Impostare la proprietà dei bordi arrotondati a True.
1. Salvare la presentazione modificata.

Di seguito è riportato un esempio.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso impostare riempimenti semitrasparenti per colonne/aree mantenendo il bordo opaco?**

Sì. La trasparenza del riempimento e il contorno vengono configurati separatamente. Questo è utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni dense.

**Come posso gestire le etichette dei dati quando si sovrappongono?**

Ridurre la dimensione del carattere, disabilitare componenti dell'etichetta non essenziali (ad esempio le categorie), impostare l'offset/posizione dell'etichetta, mostrare le etichette solo per i punti selezionati se necessario, oppure cambiare il formato in "valore + legenda".

**Posso applicare riempimenti a gradiente o a trama alle serie?**

Sì. Sono generalmente disponibili sia i riempimenti solidi sia quelli a gradiente/ trama. In pratica, usare i gradienti con parsimonia ed evitare combinazioni che diminuiscono il contrasto con la griglia e il testo.