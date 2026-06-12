---
title: Gestisci la presentazione in JavaScript
linktitle: Presentazione
type: docs
weight: 90
url: /it/nodejs-java/manage-slide-show/
keywords:
- tipo di presentazione
- presentata dal relatore
- visualizzata da un individuo
- visualizzata in modalità chiosco
- opzioni di presentazione
- ripetizione continua
- presentazione senza narrazione
- presentazione senza animazione
- colore della penna
- mostra slide
- presentazione personalizzata
- avanzamento slide
- manualmente
- con tempi
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci le presentazioni in JavaScript con Aspose.Slides per Node.js. Controlla le transizioni delle slide, i tempi e molto altro per i formati PPT, PPTX e ODP con facilità."
---
## **Introduzione**

In Microsoft PowerPoint, le impostazioni della **Presentazione** sono uno strumento fondamentale per preparare e fornire presentazioni professionali. Una delle funzionalità più importanti in questa sezione è **Imposta presentazione**, che consente di personalizzare la presentazione per condizioni e pubblici specifici, garantendo flessibilità e praticità. Con questa funzionalità è possibile selezionare il tipo di presentazione (ad es. presentata da un relatore, visualizzata da un individuo o visualizzata in modalità chiosco), abilitare o disabilitare il looping, scegliere slide specifiche da visualizzare e utilizzare i tempi. Questo passaggio nella preparazione è cruciale per rendere la presentazione più efficace e professionale.

`getSlideShowSettings` è un metodo della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) che restituisce un oggetto di tipo [SlideShowSettings](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowsettings/), il quale consente di gestire le impostazioni della presentazione in un file PowerPoint. In questo articolo esploreremo come utilizzare questo metodo per configurare e controllare vari aspetti delle impostazioni della presentazione. 

## **Seleziona tipo di presentazione**

`SlideShowSettings.setSlideShowType` definisce il tipo di presentazione, che può essere un'istanza delle seguenti classi: [PresentedBySpeaker](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/browsedatkiosk/). L'uso di questo metodo permette di adattare la presentazione a diversi scenari di utilizzo, come chioschi automatizzati o presentazioni manuali.

L'esempio di codice qui sotto crea una nuova presentazione e imposta il tipo di presentazione su "Visualizzata da un individuo" senza visualizzare la barra di scorrimento.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Abilita opzioni di presentazione**

`SlideShowSettings.setLoop` determina se la presentazione deve ripetersi in un ciclo fino a quando non viene interrotta manualmente. È utile per presentazioni automatizzate che devono funzionare ininterrottamente. `SlideShowSettings.setShowNarration` determina se le narrazioni vocali devono essere riprodotte durante la presentazione. È utile per presentazioni automatizzate che contengono indicazioni vocali per il pubblico. `SlideShowSettings.setShowAnimation` determina se le animazioni aggiunte agli oggetti delle slide devono essere riprodotte. Questo è importante per fornire l'effetto visivo completo della presentazione.

Il codice seguente crea una nuova presentazione e imposta il ciclo della presentazione.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Seleziona slide da mostrare**

Il metodo `SlideShowSettings.setSlides` consente di selezionare un intervallo di slide da visualizzare durante la presentazione. È utile quando si desidera mostrare solo una parte della presentazione invece di tutte le slide. L'esempio di codice seguente crea una nuova presentazione e imposta l'intervallo di slide da visualizzare dalla slide `2` alla slide `9`.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Usa avanzamento automatico delle slide**

Il metodo `SlideShowSettings.setUseTimings` consente di abilitare o disabilitare l'uso dei tempi predefiniti per ciascuna slide. È utile per far avanzare automaticamente le slide con durate di visualizzazione predefinite. L'esempio di codice qui sotto crea una nuova presentazione e disabilita l'uso dei tempi.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Mostra controlli multimediali**

Il metodo `SlideShowSettings.setShowMediaControls` determina se i controlli multimediali (come riproduci, metti in pausa e interrompi) devono essere visualizzati durante la presentazione quando viene riprodotto contenuto multimediale (ad es. video o audio). È utile quando si desidera dare al relatore il controllo sulla riproduzione dei media durante la presentazione.

Il codice seguente crea una nuova presentazione e abilita la visualizzazione dei controlli multimediali.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Posso salvare una presentazione in modo che si apra direttamente in modalità presentazione?**

Sì. Salva il file come PPSX o PPSM; questi formati avviano direttamente la presentazione quando vengono aperti in PowerPoint. In Aspose.Slides, scegli il formato di salvataggio corrispondente [durante l'esportazione](/slides/it/nodejs-java/save-presentation/).

**Posso escludere slide individuali dalla presentazione senza eliminarle dal file?**

Sì. Contrassegna una slide come [nascosta](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/sethidden/). Le slide nascoste rimangono nella presentazione ma non vengono visualizzate durante la presentazione.

**Aspose.Slides può riprodurre una presentazione o controllare una presentazione dal vivo sullo schermo?**

No. Aspose.Slides modifica, analizza e converte i file di presentazione; la riproduzione effettiva è gestita da un'applicazione visualizzatore come PowerPoint.