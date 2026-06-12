---
title: Aggiungere diapositive alle presentazioni in PHP
linktitle: Aggiungi diapositiva
type: docs
weight: 10
url: /it/php-java/add-slide-to-presentation/
keywords:
- aggiungi diapositiva
- crea diapositiva
- diapositiva vuota
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Aggiungi facilmente diapositive alle tue presentazioni PowerPoint e OpenDocument usando Aspose.Slides per PHP via Java — inserimento diapositive fluido ed efficiente in pochi secondi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere diapositive alle presentazioni PowerPoint in modo programmatico. Una presentazione contiene diapositive master/layout e diapositive normali, e le diapositive normali sono ordinate mediante un indice basato su zero. Ogni diapositiva ha un ID univoco e i file di presentazione senza diapositive non sono supportati.

Questo articolo spiega come creare un oggetto `Presentation`, accedere alla sua collezione di diapositive, aggiungere una diapositiva vuota, lavorare con la diapositiva appena aggiunta e salvare la presentazione aggiornata. Copre anche argomenti correlati come l'inserimento di diapositive in una posizione specifica, l'utilizzo dei layout e la comprensione della diapositiva vuota presente in una presentazione appena creata.

## **Aggiungere una diapositiva a una presentazione**

Prima di parlare dell'aggiunta di diapositive ai file di presentazione, discutiamo alcuni fatti sulle diapositive. Ogni file di presentazione PowerPoint contiene una diapositiva **Master / Layout** e altre diapositive **Normali**. Ciò significa che un file di presentazione contiene almeno una o più diapositive. È importante sapere che i file di presentazione senza diapositive non sono supportati da Aspose.Slides per PHP via Java. Ogni diapositiva ha un Id univoco e tutte le Diapositive Normali sono ordinate secondo un indice basato su zero.

Aspose.Slides per PHP via Java consente agli sviluppatori di aggiungere diapositive vuote alla loro presentazione. Per aggiungere una diapositiva vuota nella presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
- Ottieni l'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/) utilizzando il metodo [getSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation#getSlides--) (collezione di oggetti Slide di contenuto) esposto dall'oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
- Aggiungi una diapositiva vuota alla presentazione alla fine della collezione di diapositive di contenuto chiamando i metodi [**addEmptySlide**](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/#addEmptySlide) esposti dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/).
- Esegui alcune operazioni con la diapositiva vuota appena aggiunta.
- Infine, scrivi il file della presentazione utilizzando l'oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).

```php
  # Instanzia la classe Presentation che rappresenta il file di presentazione
  $pres = new Presentation();
  try {
    # Instanzia la classe SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Aggiungi una diapositiva vuota alla collezione di Slides
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Esegui alcune operazioni sulla diapositiva appena aggiunta
    # Salva il file PPTX sul disco
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **FAQ**

**Posso inserire una nuova diapositiva in una posizione specifica, non solo alla fine?**

Sì. La libreria supporta le collezioni di diapositive e le operazioni [insert](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/insertclone/) , così puoi aggiungere una diapositiva all'indice richiesto invece che solo alla fine.

**I temi/stili vengono mantenuti quando si aggiunge una diapositiva basata su un layout?**

Sì. Un layout eredita la formattazione dal suo master, e la nuova diapositiva eredita dal layout selezionato e dal relativo master.

**Quale diapositiva è presente in una nuova presentazione "vuota" prima di aggiungere diapositive?**

Una presentazione appena creata contiene già una diapositiva vuota con indice zero. Questo è importante da considerare quando si calcolano gli indici di inserimento.

**Come scelgo il layout "giusto" per una nuova diapositiva se il master ha molte opzioni?**

Generalmente scegli il [LayoutSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/) che corrisponde alla struttura richiesta ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidelayouttype/)). Se tale layout manca, puoi [aggiungilo al master](/slides/it/php-java/slide-layout/) e poi usarlo.