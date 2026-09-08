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
- adattare il testo
- ridurre il testo
- a capo automatico
- ridimensionare forma
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come gestire le impostazioni AutoFit in Aspose.Slides per Python tramite Java per ottimizzare la visualizzazione del testo nelle tue presentazioni PowerPoint e OpenDocument e migliorare la leggibilità del contenuto."
---
## **Introduzione**

Per impostazione predefinita, quando aggiungi una casella di testo, Microsoft PowerPoint utilizza l'impostazione **Ridimensiona forma per adattare il testo** per la casella di testo: ridimensiona automaticamente la casella di testo per garantire che il suo contenuto si adatti sempre.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Quando il testo nella casella di testo diventa più lungo o più grande, PowerPoint ingrandisce automaticamente la casella di testo—aumenta la sua altezza—per consentirgli di contenere più testo.  
* Quando il testo nella casella di testo diventa più corto o più piccolo, PowerPoint riduce automaticamente la casella di testo—diminuisce la sua altezza—per eliminare lo spazio ridondante.  

In PowerPoint, questi sono i 4 parametri o opzioni importanti che controllano il comportamento di autofit per una casella di testo:

* **Non Autofit**
* **Riduci il testo in caso di overflow**
* **Ridimensiona forma per adattare il testo**
* **A capo automatico nel forma**.

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java fornisce opzioni simili—alcune proprietà nella classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/)—che consentono di controllare il comportamento di autofit per le caselle di testo nelle presentazioni.

## **Ridimensiona una forma per adattare il testo**

Se desideri che il testo in una casella si adatti sempre alla stessa dopo modifiche al contenuto, devi usare l'opzione **Ridimensiona forma per adattare il testo**. Per specificare questa impostazione, utilizza il metodo [setAutofitType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setAutofitType) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/)) con [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Questo codice Python mostra come specificare che un testo deve sempre adattarsi alla propria casella in una presentazione PowerPoint:

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

Se il testo diventa più lungo o più grande, la casella di testo verrà ridimensionata automaticamente (aumento dell'altezza) per garantire che tutto il testo vi entri. Se il testo si accorcia, si verifica l'operazione inversa.

## **Non Autofit**

Se desideri che una casella di testo o una forma mantenga le proprie dimensioni indipendentemente dalle modifiche al testo contenuto, devi usare l'opzione **Non Autofit**. Per specificare questa impostazione, utilizza il metodo [setAutofitType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setAutofitType) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/)) con [None](https://reference.aspose.com/slides/it/python-java/aspose.slides/textautofittype/#None).

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

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
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Quando il testo diventa troppo lungo per la casella, trabocca fuori.

## **Riduci il testo in caso di overflow**

Se un testo supera le dimensioni della casella, tramite l'opzione **Riduci il testo in caso di overflow** è possibile specificare che la dimensione e la spaziatura del testo siano ridotte per farlo entrare nella casella. Per specificare questa impostazione, utilizza il metodo [setAutofitType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setAutofitType) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/)) con [Normal](https://reference.aspose.com/slides/it/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Questo codice Python mostra come specificare che un testo deve essere ridotto in caso di overflow in una presentazione PowerPoint:

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

{{% alert title="Nota" color="info" %}}

Quando viene utilizzata l'opzione **Riduci il testo in caso di overflow**, l'impostazione viene applicata solo quando il testo supera le dimensioni della casella.

{{% /alert %}}

## **A capo automatico**

Se desideri che il testo in una forma vada a capo all'interno della stessa quando supera il bordo (solo larghezza), devi usare il parametro **A capo automatico nella forma**. Per specificare questa impostazione, utilizza il metodo [setWrapText](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setWrapText) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/)) con [NullableBool.True](https://reference.aspose.com/slides/it/python-java/aspose.slides/nullablebool/#True).

Questo codice Python mostra come utilizzare l'impostazione A capo automatico in una presentazione PowerPoint:

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
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Avviso" color="warning" %}} 

Se usi il metodo [setWrapText](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setWrapText) con [NullableBool.False](https://reference.aspose.com/slides/it/python-java/aspose.slides/nullablebool/#False) per una forma, quando il testo all'interno della forma supera la larghezza della forma, il testo si estende oltre i bordi della forma su un'unica riga.

{{% /alert %}}

## **FAQ**

**I margini interni del riquadro di testo influenzano l'AutoFit?**

Sì. Il padding (margini interni) riduce l'area utilizzabile per il testo, quindi l'AutoFit si attiva prima—riducendo il carattere o ridimensionando la forma prima. Controlla e regola i margini prima di ottimizzare l'AutoFit.

**Come interagisce l'AutoFit con i ritorni a capo manuali e morbidi?**

I ritorni forzati rimangono in posizione, e l'AutoFit adatta la dimensione del carattere e la spaziatura attorno a essi. Rimuovere i ritorni non necessari riduce spesso l'aggressività con cui l'AutoFit deve ridurre il testo.

**La modifica del carattere del tema o la sostituzione del carattere influiscono sui risultati dell'AutoFit?**

Sì. Sostituire un carattere con metriche di glifo differenti modifica larghezza/altezza del testo, il che può alterare la dimensione finale del carattere e l'andamento del ritorno a capo. Dopo qualsiasi cambio o sostituzione di carattere, ricontrolla le diapositive.