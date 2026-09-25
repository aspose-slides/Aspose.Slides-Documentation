---
title: Gestire l'accessibilità delle presentazioni in Java
linktitle: Accessibilità delle presentazioni
type: docs
weight: 30
url: /it/java/presentation-accessibility/
keywords:
- accessibilità delle presentazioni
- testo alternativo
- titolo del testo alternativo
- descrizione del testo alternativo
- contrassegna come decorativo
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Java aiuta ad automatizzare i controlli di accessibilità delle presentazioni nei file PPT, PPTX e ODP—migliora l'esperienza del lettore di schermo e aumenta la conformità."
---
## **Introduzione**

Il testo alternativo aiuta le persone che utilizzano tecnologie assistive a comprendere il significato di immagini, grafici e altre forme informative. Questo articolo spiega come leggere e aggiornare i titoli e le descrizioni del testo alternativo con Aspose.Slides per Java, distinguere le descrizioni di accessibilità dai nomi delle forme usati nel codice e verificare se una forma è contrassegnata come decorativa.

Queste funzionalità supportano l'accessibilità delle presentazioni, ma non la garantiscono. È necessario anche esaminare l'ordine di lettura, il contrasto dei colori, la leggibilità del testo e altri requisiti di accessibilità.

## **Gestire i Titoli e le Descrizioni del Testo Alternativo**

Usa il testo alternativo per spiegare il significato di immagini, grafici e altre forme informative a chi non può vederle. I metodi e i contenuti seguenti hanno scopi diversi:

| Metodo o contenuto | Scopo |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Un titolo breve per la descrizione alternativa. |
| [getAlternativeText](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getAlternativeText--) | Una descrizione significativa del contenuto o dello scopo della forma nel contesto della diapositiva. |
| [getName](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getName--) | Il nome della forma, che il codice può utilizzare per trovare una forma specifica nella presentazione. |
| Testo visibile | Contenuto visualizzato sulla diapositiva, come il testo di una forma o il titolo e le etichette di un grafico. L'aggiornamento del testo alternativo non modifica questo contenuto. |

Quando una presentazione viene riutilizzata come modello, il codice può trovare una forma tramite il nome restituito da [getName](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getName--) prima di aggiornarla. Questo nome ha uno scopo diverso dal testo alternativo, che spiega cosa comunica l'elemento visivo al lettore. La ricerca per nome consente agli autori di migliorare o tradurre le descrizioni senza modificare il modo in cui il codice individua la forma. I nomi possono essere modificati e non sono garantiti essere univoci, quindi verifica che il nome corrisponda alla forma prevista; vedi [Identify and Find Shapes](/slides/it/java/shape-manipulations/#identify-and-find-shapes).

L'esempio seguente richiede `input.pptx` con un'immagine di un ingresso ufficio come prima forma nella prima diapositiva. L'immagine non deve essere contrassegnata come decorativa. L'esempio legge e stampa il titolo e la descrizione attuali del testo alternativo, aggiorna entrambi i valori e salva la presentazione come `output.pptx`. Adatta la formulazione all'immagine reale e alle informazioni che trasmette.

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

Aggiungere solo il testo alternativo non garantisce l'accessibilità della presentazione né la conformità agli standard di accessibilità. Verifica l'accuratezza e la pertinenza delle descrizioni e controlla anche l'ordine di lettura, il contrasto dei colori, il testo leggibile e altri requisiti di accessibilità. I contenuti visivi informativi non dovrebbero essere contrassegnati come decorativi; la sezione successiva mostra come verificare [isDecorative](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#isDecorative--).

## **Contrassegnare come Decorativo**

Il flag “contrassegno come decorativo” indica elementi puramente ornamentali in modo che i lettori di schermo li ignorino, riducendo il rumore e mantenendo il focus sul contenuto significativo. Applicalo a sfondi, riccioli e spaziatori—mai a grafici, icone o immagini che trasmettono informazioni. Aspose.Slides espone questo flag per il rilevamento e la convalida, consentendo controlli di accessibilità automatizzati e pulizia.

![Segna come decorativo](mark_as_decorative.png)

Il frammento di codice seguente mostra come determinare se una forma è contrassegnata come decorativa.

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

## **FAQ**

**Cosa devo inserire nel titolo e nella descrizione del testo alternativo?**

Usa un titolo breve per identificare l'oggetto e una descrizione per spiegare l'informazione che il contenuto visivo trasmette nel contesto della diapositiva. Per un grafico, descrivi l'andamento o il confronto rilevante invece di limitarti a dire “grafico”.

**Devo usare il testo alternativo per individuare le forme in un modello?**

Preferisci trovare la forma tramite il nome restituito da [getName](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getName--) e verifica che sia la forma attesa. Il testo alternativo può essere modificato o tradotto, il che può interrompere il codice che ricerca una descrizione esatta; vedi [Identify and Find Shapes](/slides/it/java/shape-manipulations/).

**Quando una forma deve essere contrassegnata come decorativa?**

Usa il flag decorativo per elementi visivi che non aggiungono informazioni, come riccioli ornamentali. Immagini e grafici che comunicano significato necessitano di una descrizione appropriata invece.

**Aggiungere testo alternativo rende una presentazione totalmente accessibile?**

No. Il testo alternativo copre solo una parte dell'accessibilità. È necessario anche verificare l'ordine di lettura, il contrasto dei colori, la leggibilità del testo e altri requisiti applicabili; impostare solo queste proprietà non stabilisce la conformità.