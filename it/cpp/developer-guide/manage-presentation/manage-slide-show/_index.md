---
title: Gestisci la presentazione in C++
linktitle: Presentazione
type: docs
weight: 90
url: /it/cpp/manage-slide-show/
keywords:
- tipo di presentazione
- presentata dal relatore
- visualizzata da individuo
- visualizzata su chiosco
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
- C++
- Aspose.Slides
description: "Scopri come gestire le presentazioni in Aspose.Slides per C++. Controlla le transizioni delle diapositive, i tempi e molto altro nei formati PPT, PPTX e ODP con facilità."
---
## **Introduzione**

In Microsoft PowerPoint, le impostazioni della **Slide Show** sono uno strumento fondamentale per preparare e fornire presentazioni professionali. Una delle funzionalità più importanti in questa sezione è **Set Up Show**, che consente di personalizzare la presentazione per condizioni e pubblici specifici, garantendo flessibilità e comodità. Con questa funzionalità, è possibile selezionare il tipo di presentazione (ad es., presentata da un relatore, visualizzata da un individuo o visualizzata su un chiosco), abilitare o disabilitare il looping, scegliere diapositive specifiche da visualizzare e utilizzare i tempi. Questo passaggio nella preparazione è cruciale per rendere la presentazione più efficace e professionale.

`get_SlideShowSettings` è un metodo della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) che restituisce un oggetto di tipo [SlideShowSettings](https://reference.aspose.com/slides/it/cpp/aspose.slides/slideshowsettings/), che consente di gestire le impostazioni della presentazione in una presentazione PowerPoint. In questo articolo, esploreremo come utilizzare questo metodo per configurare e controllare vari aspetti delle impostazioni della presentazione. 

## **Seleziona tipo di presentazione**

`SlideShowSettings.set_SlideShowType` definisce il tipo di presentazione, che può essere un'istanza delle seguenti classi: [PresentedBySpeaker](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/it/cpp/aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/it/cpp/aspose.slides/browsedatkiosk/). L'uso di questo metodo consente di adattare la presentazione a diversi scenari d'uso, come chioschi automatizzati o presentazioni manuali.

L'esempio di codice seguente crea una nuova presentazione e imposta il tipo di presentazione su "Browsed by an individual" senza visualizzare la barra di scorrimento.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Abilita opzioni di visualizzazione**

`SlideShowSettings.set_Loop` determina se la presentazione deve ripetersi in un ciclo fino a quando non viene arrestata manualmente. Ciò è utile per presentazioni automatizzate che devono funzionare in modo continuo. `SlideShowSettings.set_ShowNarration` determina se le narrazioni vocali debbano essere riprodotte durante la presentazione. È utile per presentazioni automatizzate che contengono indicazioni vocali per il pubblico. `SlideShowSettings.set_ShowAnimation` determina se le animazioni aggiunte agli oggetti della diapositiva debbano essere riprodotte. Questo è utile per fornire l'effetto visivo completo della presentazione.

Il seguente esempio di codice crea una nuova presentazione e mette in loop la presentazione.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Seleziona diapositive da mostrare**

Il metodo `SlideShowSettings.set_Slides` consente di selezionare un intervallo di diapositive da mostrare durante la presentazione. Questo è utile quando è necessario mostrare solo una parte della presentazione invece di tutte le diapositive. Il seguente esempio di codice crea una nuova presentazione e imposta l'intervallo di diapositive da visualizzare dalle diapositive `2` alla `9`.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Usa avanzamento diapositive**

Il metodo `SlideShowSettings.set_UseTimings` consente di abilitare o disabilitare l'uso di tempi predefiniti per ciascuna diapositiva. Questo è utile per mostrare automaticamente le diapositive con durate di visualizzazione predefinite. L'esempio di codice seguente crea una nuova presentazione e disabilita l'uso dei tempi.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mostra controlli multimediali**

Il metodo `SlideShowSettings.set_ShowMediaControls` determina se i controlli multimediali (come riproduci, pausa e stop) debbano essere visualizzati durante la presentazione quando viene riprodotto contenuto multimediale (ad es., video o audio). Questo è utile quando si desidera dare al presentatore il controllo della riproduzione multimediale durante la presentazione.

Il seguente esempio di codice crea una nuova presentazione e abilita la visualizzazione dei controlli multimediali.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Posso salvare una presentazione in modo che si apra direttamente in modalità presentazione?**

Sì. Salva il file come PPSX o PPSM; questi formati si avviano direttamente in modalità presentazione quando aperti in PowerPoint. In Aspose.Slides, scegli il formato di salvataggio corrispondente [durante l'esportazione](/slides/it/cpp/save-presentation/).

**Posso escludere singole diapositive dalla presentazione senza eliminarle dal file?**

Sì. Contrassegna una diapositiva come [nascosta](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/set_hidden/). Le diapositive nascoste rimangono nella presentazione ma non vengono visualizzate durante la presentazione.

**Aspose.Slides può riprodurre una presentazione o controllare una presentazione live sullo schermo?**

No. Aspose.Slides modifica, analizza e converte i file di presentazione; la riproduzione effettiva è gestita da un'applicazione di visualizzazione come PowerPoint.