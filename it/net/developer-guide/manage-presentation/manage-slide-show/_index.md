---
title: Gestisci la presentazione in .NET
linktitle: Presentazione
type: docs
weight: 90
url: /it/net/manage-slide-show/
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
- uso dei tempi
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come gestire le presentazioni in Aspose.Slides per .NET. Controlla le transizioni delle diapositive, i tempi e molto altro nei formati PPT, PPTX e ODP con facilità."
---
## **Introduzione**

In Microsoft PowerPoint, le impostazioni della **Presentazione** sono uno strumento fondamentale per preparare e realizzare presentazioni professionali. Una delle funzionalità più importanti in questa sezione è **Configura presentazione**, che consente di personalizzare la presentazione per condizioni e pubblici specifici, garantendo flessibilità e comodità. Con questa funzionalità è possibile selezionare il tipo di presentazione (ad esempio, presentata da un relatore, visualizzata da un singolo utente o visualizzata in modalità chiosco), attivare o disattivare il loop, scegliere le diapositive specifiche da visualizzare e utilizzare i tempi. Questa fase di preparazione è fondamentale per rendere la presentazione più efficace e professionale.

`SlideShowSettings` è una proprietà della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) di tipo [SlideShowSettings](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slideshowsettings/), che consente di gestire le impostazioni della presentazione in un file PowerPoint. In questo articolo, esploreremo come utilizzare questa proprietà per configurare e controllare vari aspetti delle impostazioni della presentazione. 

## **Seleziona tipo di presentazione**

`SlideShowSettings.SlideShowType` definisce il tipo di presentazione, che può essere un'istanza delle seguenti classi: [PresentedBySpeaker](https://reference.aspose.com/slides/it/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/it/net/aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/it/net/aspose.slides/browsedatkiosk/). L'uso di questa proprietà consente di adattare la presentazione a diversi scenari d'uso, come chioschi automatizzati o presentazioni manuali.

Il seguente esempio di codice crea una nuova presentazione e imposta il tipo di presentazione su "Browsed by an individual" senza visualizzare la barra di scorrimento.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Abilita opzioni di presentazione**

`SlideShowSettings.Loop` determina se la presentazione deve ripetersi in un ciclo fino a quando non viene interrotta manualmente. Questo è utile per presentazioni automatizzate che devono funzionare continuamente. `SlideShowSettings.ShowNarration` determina se le narrazioni vocali devono essere riprodotte durante la presentazione. È utile per presentazioni automatizzate che contengono indicazioni vocali per il pubblico. `SlideShowSettings.ShowAnimation` determina se le animazioni aggiunte agli oggetti della diapositiva devono essere riprodotte. Questo è utile per fornire l'effetto visivo completo della presentazione.

Il seguente esempio di codice crea una nuova presentazione e imposta il loop della presentazione.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Seleziona diapositive da visualizzare**

La proprietà `SlideShowSettings.Slides` consente di selezionare un intervallo di diapositive da visualizzare durante la presentazione. Questo è utile quando è necessario mostrare solo una parte della presentazione anziché tutte le diapositive. Il seguente esempio di codice crea una nuova presentazione e imposta l'intervallo di diapositive da visualizzare dalle diapositive `2` alla `9`.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Usa avanzamento diapositive**

La proprietà `SlideShowSettings.UseTimings` consente di abilitare o disabilitare l'uso di tempi predefiniti per ciascuna diapositiva. Questo è utile per mostrare automaticamente le diapositive con durate di visualizzazione predefinite. L'esempio di codice riportato di seguito crea una nuova presentazione e disabilita l'uso dei tempi.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Mostra controlli multimediali**

La proprietà `SlideShowSettings.ShowMediaControls` determina se i controlli multimediali (ad esempio riproduci, pausa e stop) devono essere visualizzati durante la presentazione quando viene riprodotto contenuto multimediale (ad es. video o audio). Questo è utile quando si desidera dare al relatore il controllo della riproduzione multimediale durante la presentazione.

Il seguente esempio di codice crea una nuova presentazione e abilita la visualizzazione dei controlli multimediali.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Posso salvare una presentazione in modo che si apra direttamente in modalità presentazione?**

Sì. Salva il file in formato PPSX o PPSM; questi formati si avviano direttamente in modalità presentazione quando aperti in PowerPoint. In Aspose.Slides, scegli il formato di salvataggio corrispondente [durante l'esportazione](/slides/it/net/save-presentation/).

**Posso escludere singole diapositive dalla presentazione senza eliminarle dal file?**

Sì. Contrassegna una diapositiva come [Hidden](https://reference.aspose.com/slides/it/net/aspose.slides/slide/hidden/). Le diapositive nascoste rimangono nella presentazione ma non vengono visualizzate durante la presentazione.

**Aspose.Slides può riprodurre una presentazione o controllare una presentazione dal vivo sullo schermo?**

No. Aspose.Slides modifica, analizza e converte i file di presentazione; la riproduzione effettiva è gestita da un'applicazione di visualizzazione come PowerPoint.