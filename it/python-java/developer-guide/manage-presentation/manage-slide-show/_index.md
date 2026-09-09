---
title: Gestire le presentazioni in Python tramite Java
linktitle: Presentazione
type: docs
weight: 90
url: /it/python-java/manage-slide-show/
keywords:
- tipo di presentazione
- presentato dal relatore
- visualizzato da singolo
- visualizzato al chiosco
- opzioni di presentazione
- ripetizione continua
- presentazione senza narrazione
- presentazione senza animazione
- colore della penna
- mostra diapositive
- presentazione personalizzata
- avanzare le diapositive
- manualmente
- con tempi
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come gestire le presentazioni in Aspose.Slides per Python tramite Java. Controlla le transizioni delle diapositive, i tempi e altro ancora per i formati PPT, PPTX e ODP con facilità."
---
## **Introduzione**

Le opzioni **Set Up Show** di Microsoft PowerPoint ti consentono di scegliere il tipo di presentazione, abilitare il looping, selezionare le diapositive e controllare come avanzano le diapositive. Con Aspose.Slides per Python tramite Java, puoi configurare queste opzioni programmaticamente e salvarle in un file di presentazione.

Il metodo [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlideShowSettings) restituisce un oggetto [SlideShowSettings](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowsettings/) che controlla queste opzioni. Gli esempi seguenti richiedono Aspose.Slides per Python tramite Java e un runtime Java compatibile. Ogni esempio avvia la JVM se necessario e rilascia la presentazione al termine.

## **Seleziona Tipo Presentazione**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowsettings/#setSlideShowType) definisce il tipo di presentazione, che può essere un'istanza delle seguenti classi: [PresentedBySpeaker](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/it/python-java/aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/it/python-java/aspose.slides/browsedatkiosk/). L'uso di questo metodo consente di adattare la presentazione a diversi scenari di utilizzo, come chioschi automatizzati o presentazioni manuali.

L'esempio di codice seguente crea una nuova presentazione e imposta il tipo di presentazione su "Browsed by an individual" senza visualizzare la barra di scorrimento.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Abilita Opzioni Presentazione**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowsettings/#setLoop) determina se la presentazione deve ripetersi in un ciclo fino a quando non viene interrotta manualmente. Questo è utile per presentazioni automatizzate che devono funzionare continuamente. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowsettings/#setShowNarration) determina se le narrazioni vocali devono essere riprodotte durante la presentazione. È utile per presentazioni automatizzate che contengono indicazioni vocali per il pubblico. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowsettings/#setShowAnimation) determina se le animazioni aggiunte agli oggetti delle diapositive devono essere riprodotte. Questo è utile per fornire l'effetto visivo completo della presentazione.

Il seguente esempio di codice crea una nuova presentazione e mette la presentazione in loop.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Seleziona Diapositive da Visualizzare**

Il metodo [SlideShowSettings.setSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowsettings/#setSlides) consente di selezionare un intervallo di diapositive da mostrare durante la presentazione. Questo è utile quando è necessario mostrare solo una parte della presentazione anziché tutte le diapositive. Il seguente esempio di codice crea una presentazione con nove diapositive e seleziona le diapositive da 2 a 9. L'intervallo utilizza numeri di diapositiva a base 1.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Crea nove diapositive in modo che l'intervallo selezionato esista.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlla Avanzamento Diapositiva**

Il metodo [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowsettings/#setUseTimings) consente di abilitare o disabilitare l'uso di tempi preimpostati per ogni diapositiva. Questo è utile per mostrare automaticamente le diapositive con durate di visualizzazione predefinite. L'esempio di codice seguente crea una nuova presentazione e disabilita l'uso dei tempi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mostra Controlli Media**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) determina se i controlli multimediali (come riproduci, pausa e arresta) devono essere visualizzati durante la presentazione quando viene riprodotto contenuto multimediale (ad es. video o audio). Questo è utile quando si desidera dare al presentatore il controllo della riproduzione multimediale durante la presentazione.

Il seguente esempio di codice crea una nuova presentazione e abilita la visualizzazione dei controlli multimediali.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso salvare una presentazione in modo che si apra direttamente in modalità presentazione?**

Sì. Salva il file come PPSX o PPSM; questi formati si avviano direttamente in modalità presentazione quando aperti in PowerPoint. In Aspose.Slides, scegli il formato di salvataggio corrispondente [during export](/slides/it/python-java/save-presentation/).

**Posso escludere diapositive individuali dalla presentazione senza eliminarle dal file?**

Sì. Contrassegna una diapositiva come [hidden](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#setHidden). Le diapositive nascoste rimangono nella presentazione ma non vengono visualizzate durante la presentazione.

**Aspose.Slides può riprodurre una presentazione o controllare una presentazione live sullo schermo?**

No. Aspose.Slides modifica, analizza e converte i file di presentazione; la riproduzione effettiva è gestita da un'applicazione di visualizzazione come PowerPoint.