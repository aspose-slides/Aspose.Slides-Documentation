---
title: Animare il testo PowerPoint su Android
linktitle: Testo animato
type: docs
weight: 60
url: /it/androidjava/animated-text/
keywords:
- testo animato
- animazione del testo
- paragrafo animato
- animazione del paragrafo
- effetto di animazione
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Crea testo animato dinamico in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Android, con esempi di codice Java facili da seguire e ottimizzati."
---
## **Panoramica**

Questo articolo spiega come lavorare con il testo animato in Aspose.Slides applicando effetti di animazione a singoli paragrafi e recuperando gli effetti già assegnati ai paragrafi in un riquadro di testo. Si concentra sui metodi API utilizzati per aggiungere animazioni a livello di paragrafo e per ispezionare gli effetti di animazione dei paragrafi esistenti in una presentazione.

## **Aggiungere effetti di animazione ai paragrafi**

Abbiamo aggiunto il metodo [**addEffect()**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) alle classi [**Sequence**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Sequence) e [**ISequence**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISequence). Questo metodo consente di aggiungere effetti di animazione a un singolo paragrafo. Il codice di esempio mostra come aggiungere un effetto di animazione a un singolo paragrafo:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // seleziona il paragrafo a cui aggiungere l'effetto
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // aggiungi l'effetto di animazione Fly al paragrafo selezionato
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ottenere gli effetti di animazione dei paragrafi**

Potresti decidere di scoprire gli effetti di animazione aggiunti a un paragrafo - ad esempio, in uno scenario potresti voler ottenere gli effetti di animazione in un paragrafo perché prevedi di applicare tali effetti a un altro paragrafo o forma.

Aspose.Slides per Android via Java consente di ottenere tutti gli effetti di animazione applicati ai paragrafi contenuti in un riquadro di testo (forma). Il codice di esempio mostra come ottenere gli effetti di animazione in un paragrafo:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**In che modo le animazioni del testo differiscono dalle transizioni delle diapositive e possono essere combinate?**

Le animazioni del testo controllano il comportamento di un oggetto nel tempo su una diapositiva, mentre le [transitions](/slides/it/androidjava/slide-transition/) controllano come le diapositive cambiano. Sono indipendenti e possono essere usate insieme; l'ordine di riproduzione è determinato dalla timeline dell'animazione e dalle impostazioni di transizione.

**Le animazioni del testo vengono conservate durante l'esportazione in PDF o immagini?**

No. PDF e immagini raster sono statiche, quindi vedrai un unico stato della diapositiva senza movimento. Per mantenere il movimento, usa l'esportazione in [video](/slides/it/androidjava/convert-powerpoint-to-video/) o in [HTML](/slides/it/androidjava/export-to-html5/).

**Le animazioni del testo funzionano nei layout e nel master delle diapositive?**

Gli effetti applicati agli oggetti layout/master vengono ereditati dalle diapositive, ma la loro tempistica e interazione con le animazioni a livello di diapositiva dipendono dalla sequenza finale sulla diapositiva.