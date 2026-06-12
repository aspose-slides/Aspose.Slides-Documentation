---
title: Migliora le tue presentazioni con AutoFit in JavaScript
linktitle: Impostazioni Autofit
type: docs
weight: 30
url: /it/nodejs-java/manage-autofit-settings/
keywords:
- casella di testo
- autofit
- non autofit
- adattare testo
- ridurre testo
- avvolgere testo
- ridimensionare forma
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: Gestisci le impostazioni AutoFit in Aspose.Slides per Node.js per ottimizzare la visualizzazione del testo nelle tue presentazioni PowerPoint e OpenDocument e migliorare la leggibilità dei contenuti.
---
## **Introduzione**

Per impostazione predefinita, quando aggiungi una casella di testo, Microsoft PowerPoint utilizza l'impostazione **Resize shape to fix text** per la casella di testo—ridimensiona automaticamente la casella di testo per garantire che il suo contenuto rientri sempre.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Quando il testo nella casella di testo diventa più lungo o più grande, PowerPoint ingrandisce automaticamente la casella di testo—increase its height—to allow it to hold more text.  
* Quando il testo nella casella di testo diventa più corto o più piccolo, PowerPoint riduce automaticamente la casella di testo—decreases its height—to clear redundant space.  

In PowerPoint, questi sono i 4 parametri o opzioni importanti che controllano il comportamento di autofit per una casella di testo:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js tramite Java fornisce opzioni simili—alcune proprietà nella classe [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat)—che consentono di controllare il comportamento di autofit per le caselle di testo nelle presentazioni.

## **Ridimensiona forma per adattare il testo**

Se desideri che il testo in una casella si adatti sempre alla casella dopo aver apportato modifiche al testo, devi utilizzare l'opzione **Resize shape to fix text**. Per impostare questa opzione, chiama il metodo [setAutofitType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat) con valore `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Questo codice JavaScript mostra come specificare che un testo deve sempre adattarsi alla sua casella in una presentazione PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Se il testo diventa più lungo o più grande, la casella di testo verrà ridimensionata automaticamente (aumento dell'altezza) per garantire che tutto il testo vi sia contenuto. Se il testo diventa più corto, si verifica l'operazione inversa. 

## **Do Not Autofit**

Se desideri che una casella di testo o una forma mantenga le proprie dimensioni indipendentemente dalle modifiche apportate al testo contenuto, devi utilizzare l'opzione **Do not Autofit**. Per impostare questa opzione, chiama il metodo [setAutofitType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat) con valore `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Questo codice JavaScript mostra come specificare che una casella di testo deve sempre mantenere le proprie dimensioni in una presentazione PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Quando il testo diventa troppo lungo per la sua casella, trabocca fuori. 

## **Shrink Text on Overflow**

Se un testo diventa troppo lungo per la sua casella, utilizzando l'opzione **Shrink text on overflow** è possibile specificare che la dimensione e la spaziatura del testo devono essere ridotte per farlo rientrare nella casella. Per impostare questa opzione, chiama il metodo [setAutofitType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat) con valore `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Questo codice JavaScript mostra come specificare che un testo deve essere ridotto in caso di overflow in una presentazione PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
Quando viene utilizzata l'opzione **Shrink text on overflow**, l'impostazione viene applicata solo quando il testo diventa troppo lungo per la sua casella. 
{{% /alert %}}

## **Wrap Text**

Se desideri che il testo all'interno di una forma venga avvolto all'interno della stessa quando il testo supera il bordo della forma (solo larghezza), devi utilizzare il parametro **Wrap text in shape**. Per impostare questa opzione, devi chiamare il metodo [setWrapText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat) con valore `true`.

Questo codice JavaScript mostra come utilizzare l'impostazione Wrap Text in una presentazione PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Nota" color="warning" %}} 
Se chiami il metodo `setWrapText` con valore `False` per una forma, quando il testo all'interno della forma supera la larghezza della stessa, il testo si estende oltre i bordi della forma su un'unica riga. 
{{% /alert %}}

## **FAQ**

**Le margini interni del frame di testo influenzano l'AutoFit?**

Sì. Il padding (margini interni) riduce l'area disponibile per il testo, quindi AutoFit si attiva prima—riducendo il carattere o ridimensionando la forma più rapidamente. Verifica e regola i margini prima di sintonizzare AutoFit.

**Come interagisce AutoFit con le interruzioni di riga manuali e morbide?**

Le interruzioni forzate rimangono al loro posto, e AutoFit adatta la dimensione del carattere e la spaziatura intorno a esse. Rimuovere interruzioni inutili riduce spesso l'intensità con cui AutoFit deve ridurre il testo.

**La modifica del carattere del tema o l'attivazione della sostituzione del carattere influisce sui risultati di AutoFit?**

Sì. Sostituire con un carattere che ha metriche dei glifi diverse cambia la larghezza/altezza del testo, il che può alterare la dimensione finale del carattere e l'avvolgimento delle linee. Dopo qualsiasi modifica o sostituzione del carattere, ricontrolla le diapositive.