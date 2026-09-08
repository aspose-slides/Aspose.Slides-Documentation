---
title: Animare il testo di PowerPoint in Python via Java
linktitle: Testo animato
type: docs
weight: 60
url: /it/python-java/animated-text/
keywords:
- testo animato
- animazione del testo
- paragrafo animato
- animazione del paragrafo
- effetto di animazione
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea testo animato dinamico in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Python via Java, con esempi di codice Python facili da seguire e ottimizzati."
---
## **Panoramica**

Questo articolo spiega come lavorare con il testo animato in Aspose.Slides applicando effetti di animazione ai singoli paragrafi e recuperando gli effetti già assegnati ai paragrafi in un riquadro di testo. Si concentra sui metodi API usati per aggiungere animazione a livello di paragrafo e ispezionare gli effetti di animazione dei paragrafi esistenti in una presentazione.

## **Aggiungere effetti di animazione ai paragrafi**

Il metodo [addEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/#addEffect) della classe [Sequence](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/) consente di aggiungere effetti di animazione a un singolo paragrafo. Questo esempio di codice mostra come aggiungere un effetto di animazione a un singolo paragrafo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Seleziona il paragrafo a cui aggiungere un effetto.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Aggiungi un effetto di animazione Fly al paragrafo selezionato.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ottenere gli effetti di animazione dei paragrafi**

Potresti decidere di scoprire gli effetti di animazione aggiunti a un paragrafo—ad esempio, in uno scenario, vuoi ottenere gli effetti di animazione in un paragrafo perché intendi applicarli a un altro paragrafo o forma.

Aspose.Slides per Python via Java consente di ottenere tutti gli effetti di animazione applicati ai paragrafi contenuti in un riquadro di testo (forma). Questo esempio di codice mostra come ottenere gli effetti di animazione in un paragrafo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **FAQ**

**In che modo le animazioni di testo differiscono dalle transizioni delle diapositive e possono essere combinate?**

Le animazioni di testo controllano il comportamento degli oggetti nel tempo su una diapositiva, mentre le [transitions](/slides/it/python-java/slide-transition/) controllano come le diapositive cambiano. Sono indipendenti e possono essere usate insieme; l'ordine di riproduzione è determinato dalla timeline dell'animazione e dalle impostazioni della transizione.

**Le animazioni di testo sono conservate quando si esporta in PDF o immagini?**

No. PDF e immagini raster sono statici, quindi vedrai un unico stato della diapositiva senza movimento. Per mantenere il movimento, usa l'esportazione in [video](/slides/it/python-java/convert-powerpoint-to-video/) o [HTML](/slides/it/python-java/export-to-html5/).

**Le animazioni di testo funzionano nei layout e nel master della diapositiva?**

Gli effetti applicati a oggetti di layout/master sono ereditati dalle diapositive, ma la loro temporizzazione e interazione con le animazioni a livello di diapositiva dipendono dalla sequenza finale sulla diapositiva.