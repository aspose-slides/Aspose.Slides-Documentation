---
title: Migliora le tue presentazioni con AutoFit in Python
linktitle: Impostazioni Autofit
type: docs
weight: 30
url: /it/python-java/manage-autofit-settings/
keywords:
- casella di testo
- autofit
- non autofit
- adatta testo
- riduci testo
- testo a capo
- ridimensiona forma
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come gestire le impostazioni AutoFit in Aspose.Slides per Python via Java per ottimizzare la visualizzazione del testo nelle tue presentazioni PowerPoint e OpenDocument e migliorare la leggibilità del contenuto."
---
## **Introduzione**

Per impostazione predefinita, quando aggiungi una casella di testo, Microsoft PowerPoint utilizza l’impostazione **Resize shape to fit text** per la casella di testo—ridimensiona automaticamente la casella di testo per garantire che il suo contenuto si adatti sempre.

![Casella di testo in PowerPoint](textbox-in-powerpoint.png)

* Quando il testo nella casella di testo diventa più lungo o più grande, PowerPoint ingrandisce automaticamente la casella di testo—aumenta la sua altezza—per consentire di contenere più testo.  
* Quando il testo nella casella di testo diventa più corto o più piccolo, PowerPoint riduce automaticamente la casella di testo—diminuisce la sua altezza—per eliminare lo spazio in eccesso.

In PowerPoint, questi sono i 4 parametri o opzioni importanti che controllano il comportamento di autofit per una casella di testo:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![opzioni autofit PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java fornisce opzioni simili—alcune proprietà nella classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/)—che consentono di controllare il comportamento di autofit per le caselle di testo nelle presentazioni.

## **Ridimensiona una forma per adattare il testo**

Se desideri che il testo in una casella si adatti sempre a quella casella dopo le modifiche al testo, devi utilizzare l’opzione **Resize shape to fit text**. Per specificare questa impostazione, usa il metodo [setAutofitType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setAutofitType) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/)) con [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/textautofittype/#Shape).

![impostazione alwaysfit PowerPoint](alwaysfit-setting-powerpoint.png)

Questo codice Python mostra come specificare che il testo deve sempre adattarsi alla sua casella in una presentazione PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Se il testo diventa più lungo o più grande, la casella di testo verrà ridimensionata automaticamente (aumento dell’altezza) per garantire che tutto il testo vi entri. Se il testo diventa più corto, avverrà il contrario.

## **Do Not Autofit**

Se vuoi che una casella di testo o una forma mantenga le proprie dimensioni indipendentemente dalle modifiche al testo contenuto, devi utilizzare l’opzione **Do not Autofit**. Per specificare questa impostazione, usa il metodo [setAutofitType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setAutofitType) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/)) con [None](https://reference.aspose.com/slides/it/python-java/aspose.slides/textautofittype/#None).

![impostazione donotautofit PowerPoint](donotautofit-setting-powerpoint.png)

Questo codice Python mostra come specificare che una casella di testo deve sempre mantenere le proprie dimensioni in una presentazione PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Quando il testo diventa troppo lungo per la sua casella, trabocca fuori.

## **Shrink Text on Overflow**

Se il testo diventa troppo lungo per la sua casella, puoi utilizzare l’opzione **Shrink text on overflow** per indicare che la dimensione e la spaziatura del testo devono essere ridotte per farlo entrare nella casella. Per specificare questa impostazione, usa il metodo [setAutofitType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setAutofitType) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/)) con [Normal](https://reference.aspose.com/slides/it/python-java/aspose.slides/textautofittype/#Normal).

![impostazione shrinktextonoverflow PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Questo codice Python mostra come specificare che il testo deve essere ridotto al trabocco in una presentazione PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
Quando viene utilizzata l’opzione **Shrink text on overflow**, l’impostazione viene applicata solo quando il testo diventa troppo lungo per la sua casella.  
{{% /alert %}}

## **Wrap Text**

Se vuoi che il testo in una forma vada a capo all’interno di quella forma quando il testo supera il bordo della forma (solo larghezza), devi utilizzare il parametro **Wrap text in shape**. Per specificare questa impostazione, devi usare il metodo [setWrapText](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setWrapText) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/)) con [NullableBool.True_](https://reference.aspose.com/slides/it/python-java/aspose.slides/nullablebool/#True).

Questo codice Python mostra come utilizzare l’impostazione Wrap Text in una presentazione PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
Se usi il metodo [setWrapText](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setWrapText) con [NullableBool.False](https://reference.aspose.com/slides/it/python-java/aspose.slides/nullablebool/#False) per una forma, quando il testo all’interno della forma diventa più lungo della larghezza della forma, il testo si estende oltre i bordi della forma su un’unica riga.  
{{% /alert %}}

## **FAQ**

**I margini interni della casella di testo influenzano l’AutoFit?**  
Sì. Il padding (margini interni) riduce l’area utile per il testo, quindi l’AutoFit si attiva prima—riducendo il carattere o ridimensionando la forma più rapidamente. Controlla e regola i margini prima di perfezionare l’AutoFit.

**Come interagisce l’AutoFit con interruzioni di riga manuali e morbide?**  
Le interruzioni forzate rimangono al loro posto, e l’AutoFit adatta dimensione e spaziatura del carattere intorno a esse. Rimuovere interruzioni inutili spesso diminuisce la necessità che l’AutoFit riduca aggressivamente il testo.

**La modifica del font del tema o la sostituzione del font influiscono sui risultati dell’AutoFit?**  
Sì. Sostituire un font con metriche di glifo diverse cambia larghezza/altezza del testo, il che può alterare la dimensione finale del font e l’interruzione delle linee. Dopo qualsiasi cambio o sostituzione di font, ricontrolla le diapositive.