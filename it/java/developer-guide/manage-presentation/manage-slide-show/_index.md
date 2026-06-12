---
title: Gestisci la presentazione in Java
linktitle: Presentazione
type: docs
weight: 90
url: /it/java/manage-slide-show/
keywords:
- tipo di presentazione
- presentato dal relatore
- visualizzato da un singolo
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
- Java
- Aspose.Slides
description: "Scopri come gestire le presentazioni in Aspose.Slides per Java. Controlla le transizioni delle diapositive, i tempi e molto altro nei formati PPT, PPTX e ODP con facilità."
---
## **Introduzione**

In Microsoft PowerPoint, le impostazioni della **Slide Show** sono uno strumento fondamentale per preparare e presentare presentazioni professionali. Una delle funzionalità più importanti in questa sezione è **Set Up Show**, che consente di personalizzare la presentazione in base a condizioni e pubblici specifici, garantendo flessibilità e comodità. Con questa funzionalità, è possibile selezionare il tipo di presentazione (ad es., presentata da un relatore, visualizzata da un singolo utente o visualizzata in un chiosco), abilitare o disabilitare il loop, scegliere slide specifiche da visualizzare e utilizzare i tempi. Questa fase di preparazione è fondamentale per rendere la presentazione più efficace e professionale.

`getSlideShowSettings` è un metodo della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) che restituisce un oggetto di tipo [SlideShowSettings](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideshowsettings/), consentendo di gestire le impostazioni della slide show in una presentazione PowerPoint. In questo articolo, esploreremo come utilizzare questo metodo per configurare e controllare vari aspetti delle impostazioni della slide show. 

## **Seleziona tipo di presentazione**

`SlideShowSettings.setSlideShowType` definisce il tipo di slide show, che può essere un'istanza delle seguenti classi: [PresentedBySpeaker](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/it/java/com.aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/it/java/com.aspose.slides/browsedatkiosk/). L'utilizzo di questo metodo consente di adattare la presentazione a diversi scenari d'uso, come chioschi automatizzati o presentazioni manuali.

L'esempio di codice seguente crea una nuova presentazione e imposta il tipo di presentazione su "Browsed by an individual" senza visualizzare la barra di scorrimento.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Abilita opzioni di presentazione**

`SlideShowSettings.setLoop` determina se la slide show deve ripetersi in loop fino a quando non viene interrotta manualmente. Questo è utile per presentazioni automatizzate che devono funzionare continuamente. `SlideShowSettings.setShowNarration` determina se le narrazioni vocali devono essere riprodotte durante la slide show. È utile per presentazioni automatizzate che contengono indicazioni vocali per il pubblico. `SlideShowSettings.setShowAnimation` determina se le animazioni aggiunte agli oggetti della slide devono essere riprodotte. Questo è utile per fornire l'effetto visivo completo della presentazione.

Il seguente esempio di codice crea una nuova presentazione e ripete la slide show in loop.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Seleziona slide da visualizzare**

`SlideShowSettings.setSlides` consente di selezionare un intervallo di slide da mostrare durante la presentazione. È utile quando si desidera visualizzare solo una parte della presentazione anziché tutte le slide. Il seguente esempio di codice crea una nuova presentazione e imposta l'intervallo di slide da visualizzare dalla slide `2` alla slide `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Usa avanzamento slide**

`SlideShowSettings.setUseTimings` consente di abilitare o disabilitare l'uso di tempi predefiniti per ciascuna slide. È utile per mostrare automaticamente le slide con durate di visualizzazione predefinite. L'esempio di codice seguente crea una nuova presentazione e disabilita l'uso dei tempi.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Mostra controlli multimediali**

`SlideShowSettings.setShowMediaControls` determina se i controlli multimediali (come riproduci, pausa e stop) devono essere visualizzati durante la slide show quando viene riprodotto contenuto multimediale (ad es., video o audio). È utile quando si desidera fornire al relatore il controllo della riproduzione dei media durante la presentazione.

Il seguente esempio di codice crea una nuova presentazione e abilita la visualizzazione dei controlli multimediali.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Posso salvare una presentazione in modo che si apra direttamente in modalità slide show?**

Sì. Salva il file come PPSX o PPSM; questi formati si avviano direttamente in modalità slide show quando aperti in PowerPoint. In Aspose.Slides, scegli il formato di salvataggio corrispondente [durante l'esportazione](/slides/it/java/save-presentation/).

**Posso escludere slide individuali dalla presentazione senza cancellarle dal file?**

Sì. Contrassegna una slide come [nascosta](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#setHidden-boolean-). Le slide nascoste rimangono nella presentazione ma non vengono visualizzate durante la slide show.

**Aspose.Slides può riprodurre una slide show o controllare una presentazione live sullo schermo?**

No. Aspose.Slides modifica, analizza e converte i file di presentazione; la riproduzione effettiva è gestita da un'applicazione visualizzatore come PowerPoint.