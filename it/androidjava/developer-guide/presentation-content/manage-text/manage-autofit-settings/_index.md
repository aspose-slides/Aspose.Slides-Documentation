---
title: Migliora le tue presentazioni con AutoFit su Android
linktitle: Impostazioni Autofit
type: docs
weight: 30
url: /it/androidjava/manage-autofit-settings/
keywords:
- casella di testo
- adattamento automatico
- non autofit
- adatta testo
- riduci testo
- testo a capo
- ridimensiona forma
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestisci le impostazioni AutoFit in Aspose.Slides per Android tramite Java per ottimizzare la visualizzazione del testo nelle tue presentazioni PowerPoint e OpenDocument e migliorare la leggibilità del contenuto."
---
## **Introduzione**

Per impostazione predefinita, quando aggiungi una casella di testo, Microsoft PowerPoint utilizza l'impostazione **Resize shape to fix text** per la casella di testo: la ridimensiona automaticamente per garantire che il suo contenuto si adatti sempre. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Quando il testo nella casella di testo diventa più lungo o più grande, PowerPoint ingrandisce automaticamente la casella di testo—aumentandone l'altezza—per consentirne la visualizzazione di più testo. 
* Quando il testo nella casella di testo diventa più corto o più piccolo, PowerPoint riduce automaticamente la casella di testo—diminuendone l'altezza—per eliminare lo spazio superfluo. 

In PowerPoint, questi sono i 4 parametri o opzioni importanti che controllano il comportamento di autofit per una casella di testo: 

* **Non autofit**
* **Riduci testo in caso di overflow**
* **Ridimensiona forma per adattare testo**
* **Testo a capo nella forma**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides per Android tramite Java fornisce opzioni simili—alcune proprietà della classe [TextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrameFormat)—che consentono di controllare il comportamento di autofit per le caselle di testo nelle presentazioni.

## **Ridimensiona una forma per adattare il testo**

Se desideri che il testo in una casella si adatti sempre a quella casella dopo le modifiche al testo, devi utilizzare l'opzione **Resize shape to fix text**. Per specificare questa impostazione, imposta la proprietà [AutofitType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrameFormat)) su `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Questo codice Java mostra come specificare che un testo deve sempre adattarsi alla sua casella in una presentazione PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Se il testo diventa più lungo o più grande, la casella di testo verrà ridimensionata automaticamente (aumento dell'altezza) per garantire che tutto il testo vi si adatti. Se il testo diventa più corto, accade il contrario. 

## **Non autofit**

Se desideri che una casella di testo o una forma mantenga le proprie dimensioni indipendentemente dalle modifiche al testo contenuto, devi utilizzare l'opzione **Do not Autofit**. Per specificare questa impostazione, imposta la proprietà [AutofitType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrameFormat)) su `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Questo codice Java mostra come specificare che una casella di testo deve sempre mantenere le sue dimensioni in una presentazione PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Quando il testo diventa troppo lungo per la sua casella, trabocca. 

## **Riduci testo in caso di overflow**

Se un testo diventa troppo lungo per la sua casella, tramite l'opzione **Shrink text on overflow** è possibile specificare che dimensione e spaziatura del testo debbano essere ridotte per farlo rientrare nella casella. Per impostare questa opzione, imposta la proprietà [AutofitType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrameFormat)) su `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Questo codice Java mostra come specificare che un testo deve essere ridotto in caso di overflow in una presentazione PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Quando viene utilizzata l'opzione **Shrink text on overflow**, l'impostazione viene applicata solo quando il testo diventa troppo lungo per la casella. 
{{% /alert %}}

## **Testo a capo**

Se desideri che il testo in una forma venga avvolto all'interno di quella forma quando supera il bordo della forma (solo larghezza), devi utilizzare il parametro **Wrap text in shape**. Per impostare questa opzione, devi impostare la proprietà [WrapText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrameFormat)) su `true`.

Questo codice Java mostra come utilizzare l'impostazione Wrap Text in una presentazione PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Nota" color="warning" %}} 
Se imposti la proprietà `WrapText` su `False` per una forma, quando il testo all'interno della forma supera la larghezza della forma, il testo si estende oltre i bordi della forma su un'unica riga. 
{{% /alert %}}

## **FAQ**

**Le margini interni del frame di testo influenzano l'AutoFit?**

Sì. Il padding (margini interni) riduce l'area utilizzabile per il testo, quindi l'AutoFit interviene prima—riducendo il carattere o ridimensionando la forma più rapidamente. Controlla e regola i margini prima di affinare l'AutoFit.

**Come interagisce l'AutoFit con i ritorni a capo manuali e morbidi?**

I ritorni a capo forzati rimangono al loro posto e l'AutoFit adatta la dimensione del carattere e la spaziatura intorno a essi. Rimuovere i ritorni a capo non necessari riduce spesso l'aggressività con cui l'AutoFit deve ridurre il testo.

**Modificare il font del tema o attivare la sostituzione del font influisce sui risultati dell'AutoFit?**

Sì. Sostituire con un font con metriche dei glifi diverse modifica la larghezza/altezza del testo, il che può alterare la dimensione finale del carattere e l'interruzione di riga. Dopo ogni cambiamento o sostituzione del font, ricontrolla le diapositive.