---
title: "Migliora le tue presentazioni con AutoFit in Python"
linktitle: "Impostazioni Autofit"
type: docs
weight: 30
url: /it/python-net/manage-autofit-settings/
keywords:
- "casella di testo"
- "autofit"
- "non autofit"
- "adatta testo"
- "riduci testo"
- "avvolgi testo"
- "ridimensiona forma"
- "PowerPoint"
- "presentazione"
- "Python"
- "Aspose.Slides"
description: "Scopri come gestire le impostazioni AutoFit in Aspose.Slides per Python via .NET per ottimizzare la visualizzazione del testo nelle tue presentazioni PowerPoint e OpenDocument e migliorare la leggibilità dei contenuti."
---
## **Introduzione**

Per impostazione predefinita, quando aggiungi una casella di testo, Microsoft PowerPoint utilizza l'impostazione **Ridimensiona forma per adattare il testo** per la casella di testo—ridimensiona automaticamente la casella di testo per garantire che il suo contenuto si adatti sempre.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Quando il testo nella casella di testo diventa più lungo o più grande, PowerPoint ingrandisce automaticamente la casella di testo—increase la sua altezza—aumenta la sua altezza—to allow it to hold more text.  
* Quando il testo nella casella di testo diventa più corto o più piccolo, PowerPoint riduce automaticamente la casella di testo—decreases its height—diminuisce la sua altezza—to clear redundant space.  

In PowerPoint, questi sono i 4 parametri o opzioni importanti che controllano il comportamento di autofit per una casella di testo:

* **Non Autofit**
* **Riduci testo in caso di overflow**
* **Ridimensiona forma per adattare il testo**
* **Avvolgi testo nella forma.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides per Python via .NET fornisce opzioni simili—alcune proprietà della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/)—che consentono di controllare il comportamento di autofit per le caselle di testo nelle presentazioni.

## **Ridimensiona forme per adattare il testo**

Se desideri che il testo in una casella si adatti sempre a quella casella dopo le modifiche al testo, devi usare l'opzione **Ridimensiona forma per adattare il testo**. Per specificare questa impostazione, imposta la proprietà [autofit_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/) su `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Questo codice Python mostra come specificare che un testo deve sempre adattarsi alla sua casella in una presentazione PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Se il testo diventa più lungo o più grande, la casella di testo verrà ridimensionata automaticamente (aumento dell'altezza) per garantire che tutto il testo vi si adatti. Se il testo diventa più corto, si verifica l'effetto opposto.

## **Non Autofit**

Se desideri che una casella di testo o una forma mantenga le proprie dimensioni indipendentemente dalle modifiche al testo contenuto, devi usare l'opzione **Non Autofit**. Per specificare questa impostazione, imposta la proprietà [autofit_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/) su `NONE`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Questo codice Python mostra come specificare che una casella di testo deve sempre mantenere le proprie dimensioni in una presentazione PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Quando il testo diventa troppo lungo per la casella, trabocca.

## **Riduci testo in caso di overflow**

Se un testo diventa troppo lungo per la sua casella, tramite l'opzione **Riduci testo in caso di overflow** è possibile specificare che la dimensione e la spaziatura del testo debbano essere ridotte per farlo entrare nella casella. Per specificare questa impostazione, imposta la proprietà [autofit_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/) su `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Questo codice Python mostra come specificare che un testo deve essere ridotto in caso di overflow in una presentazione PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Quando viene utilizzata l'opzione **Riduci testo in caso di overflow**, l'impostazione viene applicata solo quando il testo diventa troppo lungo per la sua casella.
{{% /alert %}}

## **Avvolgi testo**

Se desideri che il testo in una forma venga avvolto all'interno di quella forma quando il testo supera il bordo della forma (solo larghezza), devi usare il parametro **Avvolgi testo nella forma**. Per specificare questa impostazione, devi impostare la proprietà [wrap_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/) su `NullableBool.TRUE`.

Questo codice Python mostra come utilizzare l'impostazione Avvolgi testo in una presentazione PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}}
Se imposti la proprietà `wrap_text` su `NullableBool.FALSE` per una forma, quando il testo all'interno della forma supera la larghezza della forma, il testo si estende oltre i bordi della forma su un'unica riga.
{{% /alert %}}

## **FAQ**

**Le margini interni del riquadro di testo influiscono su AutoFit?**

Sì. Il padding (margini interni) riduce l'area utilizzabile per il testo, quindi AutoFit interviene prima—riducendo il carattere o ridimensionando la forma prima. Verifica e regola i margini prima di affinare AutoFit.

**Come interagisce AutoFit con le interruzioni di linea manuali e morbide?**

Le interruzioni forzate rimangono al loro posto, e AutoFit adatta la dimensione del carattere e la spaziatura intorno a esse. Rimuovere le interruzioni non necessarie riduce spesso l'intensità con cui AutoFit deve ridurre il testo.

**La modifica del font del tema o l'attivazione della sostituzione del font influiscono sui risultati di AutoFit?**

Sì. Sostituire con un font con metriche di glifo diverse cambia la larghezza/altezza del testo, il che può modificare la dimensione finale del carattere e l'avvolgimento delle linee. Dopo qualsiasi modifica o sostituzione del font, ricontrolla le diapositive.