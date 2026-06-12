---
title: Crea presentazioni in PHP
linktitle: Crea presentazione
type: docs
weight: 10
url: /it/php-java/create-presentation/
keywords:
- crea presentazione
- nuova presentazione
- crea PPT
- nuovo PPT
- crea PPTX
- nuovo PPTX
- crea ODP
- nuovo ODP
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Crea presentazioni con Aspose.Slides per PHP via Java — genera file PPT, PPTX e ODP e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione in Aspose.Slides, aggiungere contenuti semplici a una diapositiva e salvare il risultato come file. Mostra inoltre come creare e salvare una nuova presentazione, aprire una presentazione esistente in un formato supportato e salvarla in un altro formato. Inoltre, l'articolo include una breve FAQ che copre domande comuni relative a formati, modelli, dimensionamento delle diapositive, unità, utilizzo della memoria, threading, licenze, firme digitali e supporto VBA.

## **Creare una presentazione**

Per aggiungere una semplice linea piana a una diapositiva selezionata della presentazione, seguire i passaggi seguenti:

1. Creare un'istanza della classe Presentation.
2. Ottenere il riferimento di una diapositiva utilizzando il suo Index.
3. Aggiungere un'AutoShape di tipo Line utilizzando il metodo addAutoShape esposto dall'oggetto Shapes.
4. Scrivere la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

```php
  # Istanzia un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiungi un autoshape di tipo linea
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Quali formati posso usare per salvare una nuova presentazione?**

Puoi salvare in [PPTX, PPT e ODP](/slides/it/php-java/save-presentation/), ed esportare in [PDF](/slides/it/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/it/php-java/convert-powerpoint-to-xps/), [HTML](/slides/it/php-java/convert-powerpoint-to-html/), [SVG](/slides/it/php-java/convert-powerpoint-to-png/), e [immagini](/slides/it/php-java/convert-powerpoint-to-png/), tra gli altri.

**Posso partire da un modello (POTX/POTM) e salvare come un PPTX standard?**

Sì. Carica il modello e salvalo nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/php-java/supported-file-formats/).

**Come controllare la dimensione/rapporto d'aspetto della diapositiva quando creo una presentazione?**

Imposta la [dimensione della diapositiva](/slides/it/php-java/slide-size/) (comprese le preimpostazioni come 4:3 e 16:9 o dimensioni personalizzate) e scegli come ridimensionare il contenuto.

**In quali unità vengono misurate le dimensioni e le coordinate?**

In punti: 1 pollice corrisponde a 72 unità.

**Come gestire presentazioni molto grandi (con molti file multimediali) per ridurre l'uso della memoria?**

Utilizza le [strategie di gestione BLOB](/slides/it/php-java/manage-blob/), limita l'archiviazione in memoria sfruttando file temporanei e preferisci flussi di lavoro basati su file rispetto a stream interamente in memoria.

**Posso creare/salvare presentazioni in parallelo?**

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) da [thread multipli](/slides/it/php-java/multithreading/). Esegui istanze separate e isolate per thread o processo.

**Come rimuovere il watermark di prova e le limitazioni?**

[Applica una licenza](/slides/it/php-java/licensing/) una volta per processo. L'XML della licenza deve rimanere invariato e la configurazione della licenza dovrebbe essere sincronizzata se sono coinvolti più thread.

**Posso firmare digitalmente il PPTX che creo?**

Sì. Le [firme digitali](/slides/it/php-java/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

**Le macro (VBA) sono supportate nelle presentazioni create?**

Sì. Puoi [creare/modificare progetti VBA](/slides/it/php-java/presentation-via-vba/) e salvare file abilitati alle macro come PPTM/PPSM.