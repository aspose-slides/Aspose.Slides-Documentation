---
title: Gestire l'accessibilità delle presentazioni su Android
linktitle: Accessibilità della presentazione
type: docs
weight: 30
url: /it/androidjava/presentation-accessibility/
keywords:
- accessibilità della presentazione
- testo alternativo
- titolo del testo alternativo
- descrizione del testo alternativo
- contrassegnare come decorativo
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Android tramite Java aiuta ad automatizzare i controlli di accessibilità delle presentazioni in file PPT, PPTX e ODP—migliora l'esperienza del lettore di schermo e aumenta la conformità."
---
## **Introduzione**

Il testo alternativo aiuta le persone che utilizzano tecnologie assistive a comprendere il significato di immagini, grafici e altre forme informative. Questo articolo spiega come leggere e aggiornare i titoli e le descrizioni del testo alternativo con Aspose.Slides per Android tramite Java, distinguere le descrizioni di accessibilità dai nomi delle forme usati nel codice e verificare se una forma è contrassegnata come decorativa.

Queste funzionalità supportano l'accessibilità delle presentazioni, ma non la garantiscono. È necessario anche verificare l'ordine di lettura, il contrasto cromatico, la leggibilità del testo e altri requisiti di accessibilità.

## **Gestire i titoli e le descrizioni del testo alternativo**

Utilizzare il testo alternativo per spiegare il significato di immagini, grafici e altre forme informative alle persone che non possono vederle. I seguenti metodi e contenuti servono a scopi diversi:

| Metodo o contenuto | Scopo |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Un breve titolo per la descrizione alternativa. |
| [getAlternativeText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | Una descrizione significativa del contenuto o dello scopo della forma nel contesto della diapositiva. |
| [getName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getName--) | Il nome della forma, che il codice può usare per trovare una forma specifica nella presentazione. |
| Testo visibile | Contenuto visualizzato sulla diapositiva, come il testo di una forma o il titolo e le etichette di un grafico. L'aggiornamento del testo alternativo non modifica questo contenuto. |

Quando una presentazione viene riutilizzata come modello, il codice può trovare una forma tramite il nome restituito da [getName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getName--) prima di aggiornarla. Questo nome ha uno scopo diverso dal testo alternativo, che spiega ciò che il visual comunica al lettore. La ricerca per nome consente agli autori di migliorare o tradurre le descrizioni senza modificare il modo in cui il codice trova la forma. I nomi possono essere modificati e non sono garantiti univoci, quindi verificare che il nome corrisponda alla forma desiderata; vedere [Identifica e trova forme](/slides/it/androidjava/shape-manipulations/#identify-and-find-shapes).

L'esempio seguente richiede `input.pptx` con un'immagine di un ingresso ufficio come prima forma nella prima diapositiva. L'immagine non dovrebbe essere contrassegnata come decorativa. L'esempio legge e stampa il titolo e la descrizione attuali del testo alternativo, aggiorna entrambi i valori e salva la presentazione come `output.pptx`. Adattare la formulazione all'immagine reale e alle informazioni che trasmette.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aggiungere solo il testo alternativo non garantisce l'accessibilità della presentazione né la conformità agli standard di accessibilità. Revisionare le descrizioni per accuratezza e rilevanza, e verificare anche l'ordine di lettura, il contrasto cromatico, il testo leggibile e altri requisiti di accessibilità. I visual informativi non dovrebbero essere contrassegnati come decorativi; la sezione successiva mostra come verificare [isDecorative](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#isDecorative--).

## **Contrassegnare come decorativo**

Il flag “contrassegnare come decorativo” indica i visual puramente ornamentali affinché i lettori di schermo li ignorino, riducendo il rumore e mantenendo l'attenzione sul contenuto significativo. Applicarlo a sfondi, ornamenti e spaziatori—mai a grafici, icone o immagini che trasmettono informazioni. Aspose.Slides espone questo flag per il rilevamento e la convalida, consentendo controlli di accessibilità automatizzati e la pulizia.

![Segna come decorativo](mark_as_decorative.png)

Il seguente esempio di codice mostra come determinare se una forma è contrassegnata come decorativa.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **Domande frequenti**

**Cosa dovrei inserire nel titolo e nella descrizione del testo alternativo?**

Utilizzare un titolo breve per identificare l'argomento e una descrizione per spiegare le informazioni che il visual trasmette nel contesto della diapositiva. Per un grafico, descrivere la tendenza o il confronto rilevante anziché limitarsi a dire "grafico".

**Devo usare il testo alternativo per individuare le forme in un modello?**

Preferire trovare la forma tramite il nome restituito da [getName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getName--) e verificare che sia la forma prevista. Il testo alternativo può essere modificato o tradotto, il che può rompere il codice che cerca una descrizione esatta; vedere [Identifica e trova forme](/slides/it/androidjava/shape-manipulations/).

**Quando una forma dovrebbe essere contrassegnata come decorativa?**

Utilizzare il flag decorativo per visual che non aggiungono informazioni, come ornamenti ornamentali. Immagini e grafici che comunicano un significato necessitano di una descrizione adeguata.

**L'aggiunta di testo alternativo rende una presentazione completamente accessibile?**

No. Il testo alternativo copre solo una parte dell'accessibilità. È necessario anche revisionare l'ordine di lettura, il contrasto cromatico, la leggibilità del testo e altri requisiti applicabili; impostare solo queste proprietà non garantisce la conformità.