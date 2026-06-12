---
title: Gestisci la presentazione su Android
linktitle: Presentazione
type: docs
weight: 90
url: /it/androidjava/manage-slide-show/
keywords:
- tipo di presentazione
- presentata da relatore
- visualizzata da individuo
- visualizzata in chiosco
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
- Android
- Java
- Aspose.Slides
description: "Scopri come gestire le presentazioni in Aspose.Slides per Android tramite Java. Controlla le transizioni delle diapositive, i tempi e altro ancora per i formati PPT, PPTX e ODP con facilità."
---
## **Introduzione**

In Microsoft PowerPoint, le impostazioni della **Slide Show** sono uno strumento fondamentale per preparare e fornire presentazioni professionali. Una delle funzionalità più importanti in questa sezione è **Set Up Show**, che consente di adattare la presentazione a condizioni e pubblici specifici, garantendo flessibilità e comodità. Con questa funzionalità è possibile selezionare il tipo di presentazione (ad es., presentata da un relatore, visualizzata da un individuo o visualizzata in un chiosco), abilitare o disabilitare il looping, scegliere le diapositive specifiche da mostrare e utilizzare i tempi. Questo passaggio nella preparazione è fondamentale per rendere la presentazione più efficace e professionale.

`getSlideShowSettings` è un metodo della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) che restituisce un oggetto di tipo [SlideShowSettings](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowsettings/), che consente di gestire le impostazioni della slide show in una presentazione PowerPoint. In questo articolo, esploreremo come utilizzare questo metodo per configurare e controllare vari aspetti delle impostazioni della slide show. 

## **Seleziona tipo di presentazione**

`SlideShowSettings.setSlideShowType` definisce il tipo di slide show, che può essere un'istanza delle seguenti classi: [PresentedBySpeaker](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/browsedatkiosk/). Utilizzare questo metodo permette di adattare la presentazione a diversi scenari d'uso, come chioschi automatizzati o presentazioni manuali.

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

`SlideShowSettings.setLoop` determina se la slide show deve ripetersi in un ciclo fino a quando non viene interrotta manualmente. Questo è utile per presentazioni automatizzate che devono funzionare in modo continuo. `SlideShowSettings.setShowNarration` determina se le narrazioni vocali devono essere riprodotte durante la slide show. È utile per presentazioni automatizzate che contengono guide vocali per il pubblico. `SlideShowSettings.setShowAnimation` determina se le animazioni aggiunte agli oggetti della diapositiva devono essere eseguite. Questo è utile per fornire l'effetto visivo completo della presentazione.

Il seguente esempio di codice crea una nuova presentazione e ripete la slide show in loop.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Seleziona diapositive da mostrare**

Il metodo `SlideShowSettings.setSlides` consente di selezionare un intervallo di diapositive da mostrare durante la presentazione. Questo è utile quando si deve mostrare solo una parte della presentazione anziché tutte le diapositive. Il seguente esempio di codice crea una nuova presentazione e imposta l'intervallo di diapositive da visualizzare dalle diapositive `2` alle `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Usa avanzamento diapositive**

Il metodo `SlideShowSettings.setUseTimings` consente di abilitare o disabilitare l'uso di tempi preimpostati per ogni diapositiva. Questo è utile per mostrare automaticamente le diapositive con durate di visualizzazione predefinite. L'esempio di codice seguente crea una nuova presentazione e disabilita l'uso dei tempi.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Mostra controlli multimediali**

Il metodo `SlideShowSettings.setShowMediaControls` determina se i controlli multimediali (come riproduci, pausa e stop) devono essere visualizzati durante la slide show quando viene riprodotto contenuto multimediale (ad es., video o audio). Questo è utile quando si desidera dare al presentatore il controllo della riproduzione multimediale durante la presentazione.

Il seguente esempio di codice crea una nuova presentazione e abilita la visualizzazione dei controlli multimediali.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Posso salvare una presentazione in modo che si apra direttamente in modalità slide show?**

Sì. Salva il file come PPSX o PPSM; questi formati si avviano direttamente in modalità slide show quando vengono aperti in PowerPoint. In Aspose.Slides, scegli il formato di salvataggio corrispondente [durante l'esportazione](/slides/it/androidjava/save-presentation/).

**Posso escludere singole diapositive dalla presentazione senza cancellarle dal file?**

Sì. Marca una diapositiva come [nascosta](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Le diapositive nascoste rimangono nella presentazione ma non vengono visualizzate durante la slide show.

**Aspose.Slides può riprodurre una slide show o controllare una presentazione live sullo schermo?**

No. Aspose.Slides modifica, analizza e converte i file di presentazione; la riproduzione effettiva è gestita da un'applicazione di visualizzazione come PowerPoint.