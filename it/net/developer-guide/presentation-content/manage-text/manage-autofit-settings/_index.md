---
title: "Migliora le tue presentazioni con AutoFit in .NET"
linktitle: "Impostazioni Autofit"
type: docs
weight: 30
url: /it/net/manage-autofit-settings/
keywords:
- "casella di testo"
- "autofit"
- "non autofit"
- "adattare testo"
- "ridurre testo"
- "avvolgere testo"
- "ridimensionare forma"
- "PowerPoint"
- "presentazione"
- "C#"
- ".NET"
- "Aspose.Slides"
description: "Scopri come gestire le impostazioni AutoFit in Aspose.Slides per .NET per ottimizzare la visualizzazione del testo nelle tue presentazioni PowerPoint e OpenDocument e migliorare la leggibilità del contenuto."
---
## **Introduzione**

Per impostazione predefinita, quando aggiungi una casella di testo, Microsoft PowerPoint utilizza l’impostazione **Resize shape to fit text** per la casella di testo—ridimensiona automaticamente la casella di testo per garantire che il suo contenuto si adatti sempre.

![Una casella di testo in PowerPoint](textbox-in-powerpoint.png)

* Quando il testo nella casella di testo diventa più lungo o più grande, PowerPoint ingrandisce automaticamente la casella di testo—incrementandone l’altezza—per consentirle di contenere più testo.
* Quando il testo nella casella di testo diventa più corto o più piccolo, PowerPoint riduce automaticamente la casella di testo—diminuendone l’altezza—per eliminare lo spazio superfluo.

In PowerPoint, questi sono i quattro parametri o opzioni importanti che controllano il comportamento di autofit per una casella di testo:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Opzioni Autofit in PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides per .NET offre opzioni simili—proprietà della classe [TextFrameFormat](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat)—che consentono di controllare il comportamento di autofit per le caselle di testo nelle presentazioni.

## **Resize a Shape to Fit Text**

Se desideri che il testo in una casella si adatti sempre a quella casella dopo le modifiche al testo, devi utilizzare l’opzione **Resize shape to fit text**. Per specificare questa impostazione, imposta la proprietà `AutofitType` della classe [TextFrameFormat](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat) su `Shape`.

![Ridimensiona forma per adattare il testo](alwaysfit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Se il testo diventa più lungo o più grande, la casella di testo verrà ridimensionata automaticamente (aumentata in altezza) per assicurare che tutto il testo vi entri. Se il testo diventa più corto, avviene il contrario.

## **Do Not Autofit**

Se desideri che una casella di testo o una forma mantenga le proprie dimensioni indipendentemente dalle modifiche al testo contenuto, devi utilizzare l’opzione **Do not Autofit**. Per specificare questa impostazione, imposta la proprietà `AutofitType` della classe [TextFrameFormat](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat) su `None`.

![Impostazione "Do not Autofit" in PowerPoint](donotautofit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Quando il testo diventa troppo lungo per la sua casella, trabocca.

## **Shrink Text on Overflow**

Se il testo diventa troppo lungo per la sua casella, con l’opzione **Shrink text on overflow** puoi specificare che la dimensione e la spaziatura del testo debbano essere ridotte per farlo rientrare nella casella. Per specificare questa impostazione, imposta la proprietà `AutofitType` della classe [TextFrameFormat](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat) su `Normal`.

![Impostazione "Shrink text on overflow" in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}
Quando viene utilizzata l’opzione **Shrink text on overflow**, l’impostazione viene applicata solo quando il testo diventa troppo lungo per la sua casella.
{{% /alert %}}

## **Wrap Text**

Se desideri che il testo in una forma venga avvolto all’interno della stessa quando supera i bordi della forma (solo in larghezza), devi utilizzare il parametro **Wrap text in shape**. Per specificare questa impostazione, imposta la proprietà `WrapText` della classe [TextFrameFormat](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat) su `NullableBool.True`.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}} 
Se imposti la proprietà `WrapText` su `NullableBool.False` per una forma, quando il testo all’interno della forma supera la larghezza della forma, il testo si estende oltre i bordi della forma su un’unica riga.
{{% /alert %}}

## **FAQ**

**Le margini interni del riquadro di testo influiscono su AutoFit?**

Sì. Il padding (margini interni) riduce l’area utilizzabile per il testo, quindi AutoFit interviene prima—riducendo il carattere o ridimensionando la forma più rapidamente. Controlla e regola i margini prima di perfezionare AutoFit.

**Come interagisce AutoFit con interruzioni di riga manuali e flessibili?**

Le interruzioni forzate rimangono al loro posto, e AutoFit adatta la dimensione del carattere e la spaziatura intorno ad esse. Rimuovere interruzioni non necessarie riduce spesso l’intensità con cui AutoFit deve ridurre il testo.

**La modifica del carattere del tema o la sostituzione del carattere influiscono sui risultati di AutoFit?**

Sì. Sostituire con un carattere con metriche diverse altera la larghezza/altezza del testo, il che può cambiare la dimensione finale del carattere e l’avvolgimento delle righe. Dopo qualsiasi cambiamento o sostituzione del carattere, ricontrolla le diapositive.