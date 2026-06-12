---
title: Gestisci Slide Show in PHP
linktitle: Presentazione
type: docs
weight: 90
url: /it/php-java/manage-slide-show/
keywords:
- tipo di presentazione
- presentato dal relatore
- visualizzato da un individuo
- visualizzato in chiosco
- opzioni di presentazione
- ripetizione continua
- presentazione senza narrazione
- presentazione senza animazione
- colore della penna
- mostra diapositive
- presentazione personalizzata
- avanzamento diapositive
- manualmente
- utilizzando i tempi
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come gestire le presentazioni in Aspose.Slides per PHP tramite Java. Controlla le transizioni delle diapositive, i tempi e molto altro nei formati PPT, PPTX e ODP con facilità."
---
## **Introduzione**

In Microsoft PowerPoint, le impostazioni della **Slide Show** sono uno strumento fondamentale per preparare e presentare presentazioni professionali. Una delle funzionalità più importanti in questa sezione è **Set Up Show**, che consente di adattare la presentazione a condizioni e pubblico specifici, garantendo flessibilità e comodità. Con questa funzionalità è possibile selezionare il tipo di presentazione (ad es., presentata da un relatore, visualizzata da un individuo o visualizzata in un chiosco), abilitare o disabilitare il looping, scegliere le diapositive specifiche da mostrare e utilizzare i tempi. Questo passaggio nella preparazione è cruciale per rendere la presentazione più efficace e professionale.

`getSlideShowSettings` è un metodo della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) che restituisce un oggetto di tipo [SlideShowSettings](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowsettings/), permettendo di gestire le impostazioni della presentazione in un file PowerPoint. In questo articolo, esploreremo come utilizzare questo metodo per configurare e controllare vari aspetti delle impostazioni della presentazione. 

## **Seleziona tipo di presentazione**

`SlideShowSettings->setSlideShowType` definisce il tipo di presentazione, che può essere un'istanza delle seguenti classi: [PresentedBySpeaker](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/it/php-java/aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/it/php-java/aspose.slides/browsedatkiosk/). L'utilizzo di questo metodo consente di adattare la presentazione a diversi scenari di utilizzo, come chioschi automatizzati o presentazioni manuali.

L'esempio di codice seguente crea una nuova presentazione e imposta il tipo di presentazione su "Browsed by an individual" senza visualizzare la barra di scorrimento.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Abilita opzioni della presentazione**

`SlideShowSettings->setLoop` determina se la presentazione deve ripetersi in loop fino all'arresto manuale. È utile per presentazioni automatizzate che devono funzionare ininterrottamente. `SlideShowSettings->setShowNarration` determina se le narrazioni vocali devono essere riprodotte durante la presentazione. È utile per presentazioni automatizzate che contengono indicazioni vocali per il pubblico. `SlideShowSettings->setShowAnimation` determina se le animazioni aggiunte agli oggetti della diapositiva devono essere riprodotte. È utile per fornire l'effetto visivo completo della presentazione.

Il seguente esempio di codice crea una nuova presentazione e ripete la presentazione in loop.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Seleziona diapositive da mostrare**

Il metodo `SlideShowSettings->setSlides` consente di selezionare un intervallo di diapositive da mostrare durante la presentazione. È utile quando è necessario mostrare solo una parte della presentazione anziché tutte le diapositive. Il seguente esempio di codice crea una nuova presentazione e imposta l'intervallo di diapositive da visualizzare dalle diapositive `2` alla `9`.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Utilizza avanzamento delle diapositive**

Il metodo `SlideShowSettings->setUseTimings` consente di abilitare o disabilitare l'uso di tempi predefiniti per ciascuna diapositiva. È utile per mostrare automaticamente le diapositive con durate di visualizzazione predefinite. L'esempio di codice seguente crea una nuova presentazione e disabilita l'uso dei tempi.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Mostra controlli multimediali**

Il metodo `SlideShowSettings->setShowMediaControls` determina se i controlli multimediali (come riproduci, pausa e stop) devono essere visualizzati durante la presentazione quando viene riprodotto contenuto multimediale (ad es., video o audio). È utile quando si desidera dare al presentatore il controllo della riproduzione dei media durante la presentazione.

Il seguente esempio di codice crea una nuova presentazione e abilita la visualizzazione dei controlli multimediali.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **FAQ**

**Posso salvare una presentazione in modo che si apra direttamente in modalità slide show?**

Sì. Salva il file come PPSX o PPSM; questi formati avviano direttamente la presentazione quando vengono aperti in PowerPoint. In Aspose.Slides, scegli il formato di salvataggio corrispondente [durante l'esportazione](/slides/it/php-java/save-presentation/).

**Posso escludere diapositive individuali dalla presentazione senza eliminarle dal file?**

Sì. Contrassegna una diapositiva come [hidden](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/sethidden/). Le diapositive nascoste rimangono nella presentazione ma non vengono visualizzate durante la presentazione.

**Aspose.Slides può riprodurre una presentazione o controllare una presentazione live sullo schermo?**

No. Aspose.Slides modifica, analizza e converte i file di presentazione; la riproduzione effettiva è gestita da un'applicazione di visualizzazione come PowerPoint.