---
title: Formattare il testo della presentazione in .NET
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/net/text-formatting/
keywords:
- allineare il paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del carattere
- famiglia del carattere
- rotazione del testo
- angolo di rotazione
- riquadro di testo
- interlinea
- proprietà di adattamento automatico
- ancoraggio del riquadro di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Formattare e stilizzare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET. Personalizza caratteri, colori, allineamento e molto altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per .NET. Copre i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà dei caratteri, la rotazione, la spaziatura dei paragrafi, il comportamento di adattamento automatico, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Salvo indicazione contraria, gli esempi usano [sample.pptx](sample.pptx). La prima forma nella sua prima diapositiva è una casella di testo, e il suo primo paragrafo contiene il testo mostrato di seguito. Sia gli indici delle diapositive sia quelli delle forme partono da zero. Gli esempi che selezionano parti in grassetto usano la formattazione effettiva, inclusa la formattazione in grassetto ereditata:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedi [Cerca e sostituisci testo](/slides/it/net/search-and-replace-text/).

## **Imposta colore di sfondo del testo**

Usa [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usa [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) per porzioni di testo individuali.

L'esempio seguente imposta un'evidenziazione grigio chiaro come predefinita per il primo paragrafo. I colori di evidenziazione espliciti su porzioni individuali hanno la precedenza su questo valore predefinito:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Imposta il colore di evidenziazione per l'intero paragrafo.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Il risultato:

![Il paragrafo grigio](gray_paragraph.png)

L'esempio di codice seguente dimostra come impostare il colore di sfondo per **porzioni di testo con un carattere in grassetto**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Imposta il colore di evidenziazione per la porzione di testo.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Il risultato:

![Le porzioni di testo grigie](gray_text_portions.png)

## **Allinea paragrafi di testo**

Usa [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) per impostare l'allineamento dei paragrafi all'interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

L'esempio di codice seguente mostra come allineare il paragrafo al **centro**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Imposta l'allineamento del paragrafo al centro.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Il risultato:

![Il paragrafo allineato](aligned_paragraph.png)

## **Allinea i caratteri all'interno di una linea**

Usa [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) per allineare verticalmente le porzioni di testo di dimensioni di carattere diverse all'interno di una linea. Questa impostazione si applica all'intero paragrafo e controlla l'allineamento all'interno di ciascuna delle sue linee.

L'esempio autonomo seguente crea quattro caselle di testo etichettate su una diapositiva. Ogni paragrafo contiene lo stesso testo a 18, 36 e 54 punti, con un diverso allineamento del carattere. Usa Arial, disattiva l'adattamento automatico e l'andare a capo, e mantiene i riquadri di testo abbastanza grandi per una singola linea.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

Il risultato:

![Confronto di allineamento del carattere Baseline, Top, Center e Bottom con dimensioni di carattere miste](font_alignment.png)

L'allineamento dei caratteri utilizza le metriche del carattere, quindi i bordi visibili delle singole lettere non sono necessariamente allineati esattamente. L'esempio include sia una lettera maiuscola sia un discendente per mostrare la differenza tra l'allineamento baseline e bottom. La disponibilità e la sostituzione dei caratteri, i caratteri usati e la differenza nelle dimensioni del carattere influenzano il risultato. Le dimensioni del riquadro, i margini, l'interlinea, l'andare a capo e l'adattamento automatico influiscono anche sul layout; usa gli stessi caratteri e impostazioni di layout quando confronti le modalità.

Questa impostazione differisce da [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), che controlla l'allineamento orizzontale del paragrafo, e da [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), che posiziona il blocco di testo verticalmente all'interno della sua forma. La formattazione in apice e pedice tramite [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) sposta le singole porzioni rispetto alla baseline invece di impostare l'allineamento del carattere per le linee del paragrafo.

## **Imposta trasparenza per il testo**

La trasparenza del testo è controllata tramite il componente alfa del colore assegnato a [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). negli esempi seguenti, `alpha = 50` è un valore di canale alfa ARGB su scala 0–255, non una percentuale di trasparenza.

L'esempio di codice seguente mostra come applicare la trasparenza all'**intero paragrafo**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Imposta un riempimento nero semitrasparente per il testo.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Il risultato:

![Il paragrafo trasparente](transparent_paragraph.png)

Il seguente esempio di codice mostra come applicare la trasparenza a **porzioni di testo con un carattere in grassetto**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Imposta la trasparenza della porzione di testo.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Il risultato:

![Le porzioni di testo trasparenti](transparent_text_portions.png)

## **Imposta spaziatura dei caratteri per il testo**

Usa [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) per aumentare o ridurre la spaziatura tra i caratteri in una casella di testo. Gli esempi aggiungono 3 punti di spaziatura; valori negativi comprimono il testo.

Il seguente codice C# mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Nota: usare valori negativi per comprimere la spaziatura dei caratteri.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Espandi la spaziatura dei caratteri.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

L'esempio di codice seguente mostra come espandere la spaziatura dei caratteri in **porzioni di testo con un carattere in grassetto**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Nota: usare valori negativi per comprimere la spaziatura dei caratteri.
        portion.PortionFormat.Spacing = 3;  // Espandi la spaziatura dei caratteri.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Il risultato:

![La spaziatura dei caratteri nelle porzioni di testo](character_spacing_in_text_portions.png)

### **Disattiva kerning per caratteri specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint può ignorare i dati di kerning per alcuni caratteri, anche quando il carattere contiene informazioni di kerning valide e il kerning è attivato nelle impostazioni di PowerPoint.

Per rendere l'output renderizzato più simile a PowerPoint in tali casi, è possibile disattivare il kerning per le porzioni di testo che usano il carattere interessato. Imposta [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) a un valore maggiore della dimensione reale del carattere. Questo esempio richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva. Controlla i nomi di carattere effettivi, inclusi i caratteri ereditati, e imposta una soglia di 100 punti per le porzioni che usano Roboto. Questo disattiva il kerning per le porzioni corrispondenti con una dimensione del carattere inferiore a 100 punti:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Per il testo corrispondente al di sotto della soglia, questa impostazione impedisce il kerning e può aiutare ad allineare il rendering di Aspose.Slides all'output visivo di PowerPoint per i caratteri interessati da questo comportamento specifico di PowerPoint.

## **Gestisci le proprietà dei caratteri del testo**

Le proprietà dei caratteri possono essere impostate a livello di paragrafo tramite [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) o su singole porzioni tramite [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

L'esempio seguente imposta il carattere predefinito del primo paragrafo a Times New Roman 12 punti con formattazione grassetto, corsivo e sottolineatura puntata. La formattazione esplicita su porzioni individuali ha precedenza su questi valori predefiniti:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Imposta le proprietà del carattere per il paragrafo.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Il risultato:

![Le proprietà del carattere per il paragrafo](font_properties_for_paragraph.png)

Il seguente esempio applica Times New Roman 13 punti, formattazione corsiva e una sottolineatura puntata alle porzioni la cui formattazione effettiva è in grassetto:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Imposta le proprietà del carattere per la porzione di testo.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Il risultato:

![Le proprietà del carattere per le porzioni di testo](font_properties_for_text_portions.png)

## **Controlla la normalizzazione dell'altezza del testo**

Usa [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) quando si riproduce la tipografia di un modello o si indagano differenze nell'altezza dei caratteri. In PowerPoint, abilitare la normalizzazione allunga o comprime verticalmente i singoli caratteri per dare loro un'altezza visibile uniforme all'interno della porzione di testo. Non garantisce altezze di testo uguali tra caratteri diversi.

Imposta la proprietà su [NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) per abilitare o disabilitare esplicitamente la normalizzazione. `NullableBool.NotDefined` lascia l'impostazione locale non definita in modo che la porzione erediti il valore, ad esempio dal [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) del paragrafo. Non equivale a `False`. Usa [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) e leggi [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) per ottenere il valore booleano risolto.

L'esempio autonomo seguente richiede l'installazione di **Arial**. Crea due blocchi di testo contenenti le stesse lettere maiuscole, minuscole, discendenti e caratteri accentati a 54 punti. Entrambi i paragrafi abilitano la normalizzazione per impostazione predefinita. La porzione superiore la disabilita esplicitamente; la porzione inferiore la eredita. Le dimensioni del riquadro, i margini e la spaziatura dei paragrafi sono identici, con avvolgimento e adattamento automatico disabilitati per mantenere la coerenza del confronto. L'esempio stampa `False: False` e `NotDefined: True`, quindi salva "text_height_normalization.pptx".

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

Il confronto sotto è stato esportato dalla presentazione salvata. La riga superiore ha la normalizzazione disabilitata (`False`); la riga inferiore eredita l'impostazione abilitata (`NotDefined` → `True`). Mantieni Arial installato per riprodurre quest'aspetto.

![Testo Arial 54 punti con normalizzazione disabilitata sopra e normalizzazione ereditata abilitata sotto](text_height_normalization.png)

La normalizzazione modifica l'altezza del carattere senza modificare il valore assegnato di [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/), che specifica la dimensione del carattere in punti. Il paragrafico [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) controlla l'interlinea, mentre il [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) del riquadro di testo controlla come il testo o il suo contenitore si adattano per rientrare. Queste impostazioni hanno scopi diversi e possono influenzare il layout complessivo in modo indipendente. Per ulteriori informazioni sulla formattazione dei paragrafi e sull'ereditarietà, vedi [Gestisci paragrafo](/slides/it/net/manage-paragraph/).

## **Applica e rimuovi barrato**

Usa [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) su una porzione di testo per visualizzare correzioni, termini annullati o prezzi precedenti senza cancellare il testo originale. Impostalo su [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) per una o due linee attraverso il testo.

Per rimuovere il barrato, assegna `TextStrikethroughType.None`. Questo disabilita esplicitamente l'effetto, anche se la formattazione circostante specifica il barrato. Al contrario, `TextStrikethroughType.NotDefined` lascia l'impostazione locale non definita, consentendo alla porzione di ereditare la formattazione, ad esempio dal paragrafo. Non garantisce che il barrato sia rimosso. Usa [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) per leggere la formattazione risultante, includendo i valori ereditati.

L'esempio autonomo seguente crea tre confronti di prezzo. Ogni paragrafo ha porzioni separate per l'etichetta, il prezzo precedente e il prezzo corrente, quindi solo il prezzo precedente è interessato. La prima riga applica e poi rimuove il barrato; le altre righe mantengono il barrato singolo e doppio. Modificando questa proprietà si preserva il testo e le altre formattazioni, incluso il prezzo precedente in grassetto.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// Applica il barrato, quindi rimuovilo esplicitamente dal primo prezzo precedente.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Il risultato, dall'alto verso il basso: nessun barrato, barrato singolo e barrato doppio.

![Prezzi precedenti senza barrato, con barrato singolo e con barrato doppio](strikethrough.png)

## **Imposta rotazione del testo**

Usa [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) per impostare un'orientazione del testo predefinita all'interno di una forma.

Il seguente esempio di codice imposta l'orientazione del testo nella forma su [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), che ruota il testo di **90 gradi in senso antiorario**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Il risultato:

![La rotazione del testo](text_rotation.png)

## **Visualizza cifre affiancate in testo verticale**

Per mantenere insieme un numero a due cifre in un'etichetta giapponese verticale, inserisci entrambe le cifre in un'unica porzione di testo e imposta [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) su quella porzione. L'esempio utilizza [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) e MS Gothic 40 punti per entrambe le etichette. Solo il valore di [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) assegnato alla porzione numerica differisce.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

In PowerPoint, l'etichetta sinistra (`True`) mostra le cifre in posizione verticale e affiancate tra 和 e 年. Nell'etichetta destra (`False`), la coppia è ruotata di 90 gradi in senso orario. I caratteri giapponesi circostanti rimangono verticali in entrambe le etichette.

![Confronto PowerPoint di etichette di data verticali con cifre verticali a sinistra e cifre ruotate a destra.](vertical_date.png)

## **Imposta rotazione personalizzata per i riquadri di testo**

Usa [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) per impostare un angolo di rotazione personalizzato per un [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

L'esempio di codice seguente ruota il riquadro di testo di 3 gradi in senso orario all'interno della forma:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Il risultato:

![La rotazione personalizzata del testo](custom_text_rotation.png)

## **Imposta interlinea dei paragrafi**

Aspose.Slides fornisce [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), e [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) per controllare la spaziatura dei paragrafi. Queste proprietà sono usate come segue:

* Usa un valore positivo per specificare l'interlinea come percentuale dell'altezza della linea.
* Usa un valore negativo per specificare l'interlinea in punti.

L'esempio seguente imposta la spaziatura all'interno del primo paragrafo al 200% dell'altezza della linea (doppia interlinea):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

Il risultato:

![L'interlinea all'interno del paragrafo](line_spacing.png)

## **Controlla interruzione di linea**

Le regole di interruzione di linea dei paragrafi sono utili in blocchi di testo stretti e presentazioni che mescolano testo latino e orientale. Le seguenti proprietà appartengono a [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), quindi si applicano a un intero paragrafo:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) controlla le regole di interruzione di linea per il latino. In testi misti, cambiarla può anche modificare dove il testo orientale adiacente e la punteggiatura vanno a capo.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) controlla le regole di interruzione di linea per i caratteri orientali, incluse le restrizioni sui caratteri all'inizio e alla fine di una linea.

Queste regole non sostituiscono [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), che abilita l'andare a capo automatico all'interno di un riquadro di testo. Influenzano il layout quando avviene l'andare a capo; non inseriscono caratteri di interruzione di linea. Un'interruzione di linea esplicita forza una nuova linea all'interno del paragrafo indipendentemente dalla larghezza disponibile.

L'esempio autonomo seguente crea un blocco di testo stretto contenente testo cinese e latino. Imposta entrambe le proprietà di interruzione di linea esplicitamente e salva "line_breaking.pptx". Per sperimentare una delle regole, modifica il valore di quella proprietà mantenendo fissi gli altri parametri. L'esempio usa Arial 24 punti e SimSun con una larghezza del riquadro di 160 punti e margini orizzontali zero. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) è impostato su [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) così che la dimensione del testo e le dimensioni del riquadro rimangono fisse.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Controlla la punteggiatura penzolante**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) consente alla punteggiatura idonea di estendersi oltre il bordo destro della linea di testo invece di occupare la linea successiva. Si applica all'intero paragrafo ed è diverso da un rientro penzolante.

L'esempio autonomo seguente abilita la punteggiatura penzolante in un riquadro di testo largo 100 punti e salva "hanging_punctuation.pptx". Con Arial 24 punti e margini orizzontali zero, il punto finale rimane dopo "sentence" e si estende oltre il bordo destro del testo. Imposta la proprietà su [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) per confrontare: con queste impostazioni, il punto occupa una linea separata. L'andare a capo è abilitato e l'adattamento automatico è disabilitato per mantenere fissa la larghezza disponibile.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

Non tutti i segni di punteggiatura possono penzolare. Le [condizioni di carattere e layout descritte sopra](#control-line-breaking) si applicano anche a questo confronto: modificare il carattere, la larghezza disponibile, i margini o le impostazioni di autofit può rimuovere la differenza visibile.

## **Imposta tipo di adattamento automatico per i riquadri di testo**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) determina come il testo si comporta quando supera i confini del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma. L'esempio seguente configura la forma per ridimensionarsi e adattarsi al testo e salva il risultato in "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Per contare le linee dopo l'andare a capo automatico e vedere come la larghezza del testo o della forma influisce sul risultato, vedi [Conta le linee renderizzate](/slides/it/net/manage-paragraph/). Il conteggio delle linee da solo non indica se il testo supera il contenitore.

## **Imposta ancoraggio dei riquadri di testo**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso. L'esempio seguente ancora il testo al fondo della prima forma e salva il risultato in "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Imposta tabulazione del testo**

Usa [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) e [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) per configurare le tabulazioni in un paragrafo. L'esempio seguente imposta l'intervallo di tabulazione predefinito a 100 punti e aggiunge una tabulazione allineata a sinistra a 30 punti. Queste impostazioni influenzano il testo contenente caratteri di tabulazione.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

Il risultato:

![Le tabulazioni del paragrafo](paragraph_tabs.png)

## **Imposta lingua di verifica**

Aspose.Slides fornisce [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), che consente di impostare la lingua di verifica per una porzione di testo. La lingua di verifica determina la lingua usata per il controllo ortografico e grammaticale in PowerPoint.

L'esempio seguente richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva e almeno un paragrafo. Sostituisce il contenuto del primo paragrafo con "1。", imposta SimSun come carattere e assegna la lingua di verifica Cinese semplificato (`zh-CN`). Salva il risultato in "proofing_language.pptx":

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Imposta la lingua di verifica a cinese semplificato.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Copia metadati della lingua**

Quando si copia testo multilingue da un modello, preserva sia [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) sia [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). L'esempio autonomo seguente crea una porzione sorgente con inglese USA come lingua e francese come lingua alternativa e copia il testo e gli identificatori in una porzione in una nuova presentazione.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// Se la sorgente non ha lingua alternativa, null cancella il valore di destinazione.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Per provare una sorgente senza lingua alternativa, ometti l'assegnazione di "fr-FR". L'identificatore alternativo sarà allora `null`, e la stessa istruzione di copia preserva la sua assenza senza introdurre un valore predefinito, anche se la destinazione aveva precedentemente una lingua alternativa assegnata.

Questi identificatori sono memorizzati come metadati della lingua. Preservarli non stabilisce quale dizionario PowerPoint seleziona per i controlli ortografici o grammaticali.

## **Imposta lingua predefinita**

Usa [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione. L'esempio seguente crea una presentazione con l'inglese USA come lingua predefinita del testo, aggiunge una casella di testo e stampa `en-US` per la sua prima porzione di testo.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Aggiungi una nuova forma rettangolare con testo.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Verifica la lingua della prima porzione.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Imposta stile di testo predefinito**

Per applicare la formattazione di testo predefinita a livello di presentazione, usa [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

L'esempio seguente imposta un carattere grassetto da 14 punti come predefinito per i paragrafi di livello superiore in una nuova presentazione e lo salva in "default_text_style.pptx". Il testo può ereditare questi valori predefiniti a meno che una formattazione più specifica non li sovrascriva.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Ottieni il formato del paragrafo di livello superiore.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Estrai testo con effetto tutto maiuscolo**

In PowerPoint, applicare l'effetto carattere **All Caps** fa apparire il testo in maiuscolo sulla diapositiva anche se originariamente è stato digitato in minuscolo. Quando si recupera una tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per corrispondere al testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) e converte la stringa restituita in maiuscolo quando il valore è `All`.

Questo esempio richiede "sample2.pptx" con una casella di testo come prima forma nella prima diapositiva. La prima porzione del primo paragrafo contiene "Hello, Aspose!" con l'effetto All Caps applicato, come mostrato di seguito.

![L'effetto All Caps](all_caps_effect.png)

L'esempio di codice seguente mostra come estrarre il testo con l'effetto **All Caps** applicato:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Come modifico il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, usa [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Itera attraverso le celle e aggiorna ciascuna cella tramite [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) e la formattazione dei paragrafi tramite [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Come applico un colore sfumato al testo su una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, usa [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Imposta [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) su [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.

Funzionalità correlata: [Formattare il testo nelle diapositive](/slides/it/features/text-formatting/).