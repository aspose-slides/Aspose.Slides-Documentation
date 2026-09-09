---
title: Animare il testo PowerPoint in Python via Java
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
description: "Crea testo animato dinamico in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via Java, con esempi di codice Python facili da seguire e ottimizzati."
---
## **Panoramica**

Questo articolo spiega come lavorare con il testo animato in Aspose.Slides applicando effetti di animazione a singoli paragrafi e recuperando gli effetti già assegnati ai paragrafi in una casella di testo. Si concentra sui metodi API utilizzati per aggiungere animazioni a livello di paragrafo e ispezionare gli effetti di animazione dei paragrafi esistenti in una presentazione.

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

## **Recuperare gli effetti di animazione dei paragrafi**

Potresti voler recuperare gli effetti di animazione applicati a un paragrafo—ad esempio, per applicare tali effetti a un altro paragrafo o forma.

Aspose.Slides per Python via Java ti consente di ottenere tutti gli effetti di animazione applicati ai paragrafi contenuti in una casella di testo (forma). Questo esempio di codice mostra come ottenere gli effetti di animazione applicati a un paragrafo:

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

**Come si differenziano le animazioni del testo dalle transizioni delle diapositive e possono essere combinate?**

Le animazioni del testo controllano il comportamento di un oggetto nel tempo su una diapositiva, mentre le [transitions](/slides/it/python-java/slide-transition/) controllano il modo in cui le diapositive cambiano. Sono indipendenti e possono essere usate insieme; l'ordine di riproduzione è determinato dalla timeline dell'animazione e dalle impostazioni della transizione.

**Le animazioni del testo sono conservate durante l'esportazione in PDF o immagini?**

No. PDF e immagini raster sono statici, quindi vedrai un unico stato della diapositiva senza movimento. Per mantenere il movimento, usa l'esportazione in [video](/slides/it/python-java/convert-powerpoint-to-video/) o in [HTML](/slides/it/python-java/export-to-html5/).

**Le animazioni del testo funzionano nei layout e nel master della diapositiva?**

Gli effetti applicati agli oggetti di layout/master sono ereditati dalle diapositive, ma la loro tempistica e interazione con le animazioni a livello di diapositiva dipendono dalla sequenza finale sulla diapositiva.