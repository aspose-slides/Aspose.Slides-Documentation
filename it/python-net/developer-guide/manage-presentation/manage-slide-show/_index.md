---
title: Gestisci la presentazione in Python
linktitle: Presentazione
type: docs
weight: 90
url: /it/python-net/manage-slide-show/
keywords:
- tipo di presentazione
- presentata da relatore
- sfogliata da individuo
- sfogliata in chiosco
- opzioni di presentazione
- loop continuo
- presentazione senza narrazione
- presentazione senza animazione
- colore della penna
- mostra diapositive
- presentazione personalizzata
- avanzamento diapositive
- manualmente
- uso dei tempi
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come gestire le presentazioni in Aspose.Slides per Python tramite .NET. Controlla le transizioni delle diapositive, i tempi e molto altro nei formati PPT, PPTX e ODP con facilità."
---
## **Introduzione**

In Microsoft PowerPoint, le impostazioni della **Presentazione** sono uno strumento fondamentale per preparare e fornire presentazioni professionali. Una delle funzionalità più importanti in questa sezione è **Set Up Show**, che consente di adattare la presentazione a condizioni e pubblico specifici, garantendo flessibilità e comodità. Con questa funzionalità, è possibile selezionare il tipo di presentazione (ad es. presentata da un relatore, sfogliata da un individuo o sfogliata in modalità chiosco), abilitare o disabilitare il looping, scegliere diapositive specifiche da visualizzare e utilizzare i tempi. Questo passaggio nella preparazione è fondamentale per rendere la presentazione più efficace e professionale.

`slide_show_settings` è una proprietà della classe [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) di tipo [SlideShowSettings](https://reference.aspose.com/slides/it/python-net/aspose.slides/slideshowsettings/), che consente di gestire le impostazioni della presentazione in un file PowerPoint. In questo articolo esploreremo come utilizzare questa proprietà per configurare e controllare vari aspetti delle impostazioni della presentazione.

## **Seleziona Tipo di Presentazione**

`SlideShowSettings.slide_show_type` definisce il tipo di presentazione, che può essere un'istanza delle seguenti classi: [PresentedBySpeaker](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/it/python-net/aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/it/python-net/aspose.slides/browsedatkiosk/). L'utilizzo di questa proprietà consente di adattare la presentazione a diversi scenari d'uso, come chioschi automatizzati o presentazioni manuali.

Il codice di esempio qui sotto crea una nuova presentazione e imposta il tipo di presentazione su "Sfogliata da un individuo" senza visualizzare la barra di scorrimento.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Abilita Opzioni di Presentazione**

`SlideShowSettings.loop` determina se la presentazione debba ripetersi in loop fino a quando non viene fermata manualmente. Questo è utile per presentazioni automatizzate che devono funzionare continuamente. `SlideShowSettings.show_narration` determina se le narrazioni vocali debbano essere riprodotte durante la presentazione. È utile per presentazioni automatizzate che contengono indicazioni vocali per il pubblico. `SlideShowSettings.show_animation` determina se le animazioni aggiunte agli oggetti delle diapositive debbano essere eseguite. Questo è utile per fornire l'effetto visivo completo della presentazione.

Il seguente esempio di codice crea una nuova presentazione e imposta la presentazione in loop.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Seleziona Diapositive da Mostrare**

La proprietà `SlideShowSettings.slides` consente di selezionare un intervallo di diapositive da mostrare durante la presentazione. Questo è utile quando è necessario mostrare solo una parte della presentazione anziché tutte le diapositive. Il seguente esempio di codice crea una nuova presentazione e imposta l'intervallo di diapositive da visualizzare dalle diapositive `2` alla `9`.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Utilizza Avanzamento Diapositive**

La proprietà `SlideShowSettings.use_timings` consente di abilitare o disabilitare l'uso dei tempi preimpostati per ogni diapositiva. Questo è utile per mostrare automaticamente le diapositive con durate di visualizzazione predefinite. Il codice di esempio qui sotto crea una nuova presentazione e disabilita l'uso dei tempi.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Mostra Controlli Multimediali**

La proprietà `SlideShowSettings.show_media_controls` determina se i controlli multimediali (come riproduci, pausa e stop) debbano essere visualizzati durante la presentazione quando viene riprodotto contenuto multimediale (ad es. video o audio). Questo è utile quando si desidera dare al presentatore il controllo sulla riproduzione dei media durante la presentazione.

Il seguente esempio di codice crea una nuova presentazione e abilita la visualizzazione dei controlli multimediali.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso salvare una presentazione in modo che si apra direttamente in modalità presentazione?**

Sì. Salva il file come PPSX o PPSM; questi formati vengono avviati direttamente in modalità presentazione quando aperti in PowerPoint. In Aspose.Slides, scegli il formato di salvataggio corrispondente [durante l'esportazione](/slides/it/python-net/save-presentation/).

**Posso escludere diapositive individuali dalla presentazione senza eliminarle dal file?**

Sì. Contrassegna una diapositiva come [nascosta](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/hidden/). Le diapositive nascoste rimangono nella presentazione ma non vengono visualizzate durante la presentazione.

**Aspose.Slides può riprodurre una presentazione o controllare una presentazione live sullo schermo?**

No. Aspose.Slides modifica, analizza e converte file di presentazione; la riproduzione effettiva è gestita da un'applicazione visualizzatore come PowerPoint.