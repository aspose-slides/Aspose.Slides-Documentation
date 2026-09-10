---
title: Animare i grafici PowerPoint in Python tramite Java
linktitle: Grafici animati
type: docs
weight: 80
url: /it/python-java/animated-charts/
keywords:
- grafico
- grafico animato
- animazione del grafico
- serie del grafico
- categoria del grafico
- elemento di serie
- elemento di categoria
- aggiungi effetto
- tipo di effetto
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea grafici animati sorprendenti in Python tramite Java con Aspose.Slides. Potenzia le presentazioni con visual dinamici in file PPT e PPTX—inizia subito."
---
## **Introduzione**

Aspose.Slides for Python via Java supporta l'animazione degli elementi dei grafici. **Serie**, **Categorie**, **Elementi di Serie** e **Elementi di Categoria** possono essere animati usando il metodo [Sequence.addEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/#addEffect) e due enumerazioni: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/it/python-java/aspose.slides/effectchartmajorgroupingtype/) e [EffectChartMinorGroupingType](https://reference.aspose.com/slides/it/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Animazione delle Serie del Grafico**

Se desideri animare una serie di un grafico, scrivi il codice seguendo i passaggi elencati di seguito:

1. Carica una presentazione.  
2. Ottieni un riferimento all'oggetto grafico.  
3. Anima la serie.  
4. Scrivi il file della presentazione su disco.

L'esempio seguente anima le serie del grafico. Il grafico nel file di esempio contiene tre serie, quindi viene aggiunto un effetto per ciascun indice da 0 a 2. Aspose.Slides non verifica l'indice rispetto ai dati del grafico e un effetto aggiunto per una serie inesistente viene scritto nel file ma non anima nulla — mantieni l'indice inferiore al numero di serie nel tuo grafico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Carica la presentazione.
presentation = Presentation("ExistingChart.pptx")
try:
    # Ottieni un riferimento all'oggetto grafico.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Anima gli elementi del grafico.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Scrivi la presentazione modificata su disco.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animazione della Categoria del Grafico**

Se desideri animare una categoria di un grafico, scrivi il codice seguendo i passaggi elencati di seguito:

1. Carica una presentazione.  
2. Ottieni un riferimento all'oggetto grafico.  
3. Anima la categoria.  
4. Scrivi il file della presentazione su disco.

L'esempio seguente anima le categorie del grafico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Carica la presentazione.
presentation = Presentation("ExistingChart.pptx")
try:
    # Ottieni un riferimento all'oggetto grafico.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Anima gli elementi del grafico.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Scrivi la presentazione modificata su disco.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animazione in un Elemento di Serie**

Se desideri animare gli elementi di serie, scrivi il codice seguendo i passaggi elencati di seguito:

1. Carica una presentazione.  
2. Ottieni un riferimento all'oggetto grafico.  
3. Anima gli elementi di serie.  
4. Scrivi il file della presentazione su disco.

L'esempio seguente anima gli elementi di serie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Carica la presentazione.
presentation = Presentation("ExistingChart.pptx")
try:
    # Ottieni un riferimento all'oggetto grafico.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Anima gli elementi del grafico.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Scrivi la presentazione modificata su disco.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animazione in un Elemento di Categoria**

Se desideri animare gli elementi di categoria, scrivi il codice seguendo i passaggi elencati di seguito:

1. Carica una presentazione.  
2. Ottieni un riferimento all'oggetto grafico.  
3. Anima gli elementi di categoria.  
4. Scrivi il file della presentazione su disco.

L'esempio seguente anima gli elementi di categoria.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Carica la presentazione.
presentation = Presentation("ExistingChart.pptx")
try:
    # Ottieni un riferimento all'oggetto grafico.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Anima gli elementi del grafico.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Scrivi la presentazione modificata su disco.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Sono supportati diversi tipi di effetto (ad es., ingresso, enfasi, uscita) per i grafici come per le forme regolari?**  
Sì. Un grafico è trattato come una forma, quindi supporta i tipi standard di effetti di animazione, inclusi ingresso, enfasi e uscita, con pieno controllo tramite la timeline della diapositiva e le sequenze di animazione.

**Posso combinare l'animazione del grafico con le transizioni delle diapositive?**  
Sì. [Transitions](/slides/it/python-java/slide-transition/) si applicano alla diapositiva, mentre gli effetti di animazione si applicano agli oggetti sulla diapositiva. Puoi utilizzare entrambi nella stessa presentazione e controllarli in modo indipendente.

**Le animazioni dei grafici vengono conservate quando si salva in PPTX?**  
Sì. Quando [salvi in PPTX](/slides/it/python-java/save-presentation/), tutti gli effetti di animazione e il loro ordine vengono mantenuti perché fanno parte del modello nativo di animazione della presentazione.

**Posso leggere le animazioni dei grafici esistenti da una presentazione e modificarle?**  
Sì. L'API fornisce l'accesso alla timeline della diapositiva, alle sequenze e agli effetti, consentendo di ispezionare le animazioni dei grafici esistenti e di modificarle senza ricreare tutto da zero.

**Posso creare un video che includa le animazioni dei grafici usando Aspose.Slides?**  
Sì. Puoi [esportare una presentazione in video](/slides/it/python-java/convert-powerpoint-to-video/) mantenendo le animazioni, configurando i tempi e le altre impostazioni di esportazione in modo che il video risultante rifletta la riproduzione animata.