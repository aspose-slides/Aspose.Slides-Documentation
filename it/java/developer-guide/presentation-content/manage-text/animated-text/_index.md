---
title: Animare il testo di PowerPoint in Java
linktitle: Testo animato
type: docs
weight: 60
url: /it/java/animated-text/
keywords:
- testo animato
- animazione del testo
- paragrafo animato
- animazione del paragrafo
- effetto di animazione
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Crea testo animato dinamico in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Java, con esempi di codice Java facili da seguire e ottimizzati."
---
## **Panoramica**

Questo articolo spiega come lavorare con il testo animato in Aspose.Slides applicando effetti di animazione a singoli paragrafi e recuperando gli effetti già assegnati ai paragrafi in un riquadro di testo. Si concentra sui metodi API utilizzati per aggiungere animazioni a livello di paragrafo e ispezionare gli effetti di animazione dei paragrafi esistenti in una presentazione.

## **Aggiungere effetti di animazione ai paragrafi**

Abbiamo aggiunto il metodo [**addEffect()**](https://reference.aspose.com/slides/it/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) alle classi [**Sequence**](https://reference.aspose.com/slides/it/java/com.aspose.slides/Sequence) e [**ISequence**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISequence). Questo metodo consente di aggiungere effetti di animazione a un singolo paragrafo. Il codice di esempio mostra come aggiungere un effetto di animazione a un singolo paragrafo:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // selezionare il paragrafo a cui aggiungere l'effetto
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // aggiungere l'effetto di animazione Fly al paragrafo selezionato
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ottenere gli effetti di animazione dei paragrafi**

Potrebbe essere necessario scoprire gli effetti di animazione aggiunti a un paragrafo — ad esempio, in un caso potresti voler ottenere gli effetti di animazione in un paragrafo perché intendi applicare quegli effetti a un altro paragrafo o forma.

Aspose.Slides per Java consente di ottenere tutti gli effetti di animazione applicati ai paragrafi contenuti in un riquadro di testo (forma). Il codice di esempio mostra come ottenere gli effetti di animazione in un paragrafo:

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

**In che modo le animazioni di testo differiscono dalle transizioni delle diapositive e possono essere combinate?**

Le animazioni di testo controllano il comportamento degli oggetti nel tempo su una diapositiva, mentre le [transitions](/slides/it/java/slide-transition/) controllano come le diapositive cambiano. Sono indipendenti e possono essere usate insieme; l'ordine di riproduzione è determinato dalla linea temporale dell'animazione e dalle impostazioni di transizione.

**Le animazioni di testo vengono preservate durante l'esportazione in PDF o immagini?**

No. PDF e immagini raster sono statici, quindi vedrai un unico stato della diapositiva senza movimento. Per mantenere il movimento, utilizza l'esportazione in [video](/slides/it/java/convert-powerpoint-to-video/) o in [HTML](/slides/it/java/export-to-html5/).

**Le animazioni di testo funzionano nei layout e nello slide master?**

Gli effetti applicati a oggetti di layout/master vengono ereditati dalle diapositive, ma la loro tempistica e interazione con le animazioni a livello di diapositiva dipendono dalla sequenza finale sulla diapositiva.