---
title: Formattare il testo della presentazione in .NET
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/net/text-formatting/
keywords:
- allineamento paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del font
- famiglia del font
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
description: "Formatta e stila il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET. Personalizza font, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET. Copre i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà dei font, la rotazione, la spaziatura dei paragrafi, il comportamento di adattamento automatico, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Salvo indicazione contraria, gli esempi utilizzano [sample.pptx](sample.pptx). La prima forma nella sua prima diapositiva è una casella di testo, e il suo primo paragrafo contiene il testo mostrato di seguito. Sia gli indici delle diapositive che delle forme sono basati su zero. Gli esempi che selezionano parti in grassetto utilizzano la formattazione effettiva, inclusa la formattazione in grassetto ereditata:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedere [Cerca e sostituisci testo](/slides/it/net/search-and-replace-text/).

## **Imposta colore di sfondo del testo**

Usa [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usa [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) per porzioni di testo individuali.

L'esempio seguente imposta un'evidenziazione grigio chiaro come predefinita per il primo paragrafo. I colori di evidenziazione espliciti sulle singole porzioni hanno la precedenza su questa impostazione predefinita:

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

L'esempio di codice seguente dimostra come impostare il colore di sfondo per **porzioni di testo con un font in grassetto**:

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

Usa [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) per impostare l'allineamento del paragrafo all'interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

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

## **Allinea i font all'interno di una riga**

Usa [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) per allineare verticalmente le porzioni di testo di diverse dimensioni di font all'interno di una riga. Questa impostazione si applica all'intero paragrafo e controlla l'allineamento all'interno di ciascuna delle sue righe.

L'esempio autonomo seguente crea quattro caselle di testo etichettate su una diapositiva. Ogni paragrafo contiene lo stesso testo a 18, 36 e 54 punti, con un diverso allineamento del font. Usa Arial, disabilita l'adattamento automatico e l'andare a capo, e mantiene i riquadri di testo sufficientemente grandi per una singola riga.

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

![Confronto di allineamento Baseline, Top, Center e Bottom con dimensioni di font miste](font_alignment.png)

L'allineamento del font utilizza le metriche del font, quindi i bordi visibili delle singole lettere non coincidono necessariamente. L'esempio include sia una lettera maiuscola sia un discendente per mostrare la differenza tra allineamento baseline e bottom. La disponibilità e la sostituzione dei font, i caratteri usati e la differenza nelle dimensioni dei font influenzano il risultato. Le dimensioni del riquadro, i margini, la spaziatura delle righe, l'andare a capo e l'adattamento automatico influenzano anche il layout; usa gli stessi font e impostazioni di layout quando confronti le modalità.

Questa impostazione differisce da [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), che controlla l'allineamento orizzontale del paragrafo, e da [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), che posiziona verticalmente il blocco di testo all'interno della sua forma. La formattazione in apice e pedice tramite [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) sposta le singole porzioni rispetto alla linea di base invece di impostare l'allineamento del font per le righe del paragrafo.

## **Imposta trasparenza per il testo**

La trasparenza del testo è controllata tramite il componente alfa del colore assegnato a [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Nei seguenti esempi, `alpha = 50` è un valore di canale alfa ARGB su scala 0–255, non una percentuale di trasparenza.

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

L'esempio di codice seguente mostra come applicare la trasparenza a **porzioni di testo con un font in grassetto**:

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

Usa [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) per espandere o comprimere la spaziatura tra i caratteri in una casella di testo. Gli esempi aggiungono 3 punti di spaziatura; valori negativi comprimono il testo.

Il seguente codice C# mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Espandi la spaziatura dei caratteri.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

L'esempio di codice seguente mostra come espandere la spaziatura dei caratteri in **porzioni di testo con un font in grassetto**:

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
        // Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
        portion.PortionFormat.Spacing = 3;  // Espandi la spaziatura dei caratteri.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Il risultato:

![La spaziatura dei caratteri nelle porzioni di testo](character_spacing_in_text_portions.png)

### **Disabilita il kerning per font specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint può ignorare i dati di kerning per certi font, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per rendere l'output renderizzato più simile a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che usano il font interessato. Imposta [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) a un valore maggiore della dimensione effettiva del font. Questo esempio richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva. Verifica i nomi dei font effective, inclusi i font ereditati, e imposta una soglia di 100 punti per le porzioni che usano Roboto. Ciò disabilita il kerning per le porzioni corrispondenti con una dimensione del font inferiore a 100 punti:

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

Per il testo corrispondente al di sotto della soglia, questa impostazione previene il kerning e può aiutare ad allineare il rendering di Aspose.Slides con l'output visivo di PowerPoint per i font influenzati da questo comportamento specifico di PowerPoint.

## **Gestisci proprietà del font del testo**

Le proprietà del font possono essere impostate a livello di paragrafo tramite [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) o su singole porzioni tramite [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

L'esempio seguente imposta il font predefinito del primo paragrafo a Times New Roman 12 punti con formattazione in grassetto, corsivo e sottolineatura puntinata. La formattazione esplicita su singole porzioni ha precedenza su queste impostazioni predefinite:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Imposta le proprietà del font per il paragrafo.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Il risultato:

![Le proprietà del font per il paragrafo](font_properties_for_paragraph.png)

L'esempio seguente applica Times New Roman 13 punti, formattazione in corsivo e una sottolineatura puntinata alle porzioni la cui formattazione effettiva è in grassetto:

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
        // Imposta le proprietà del font per la porzione di testo.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Il risultato:

![Le proprietà del font per le porzioni di testo](font_properties_for_text_portions.png)

## **Imposta rotazione del testo**

Usa [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) per impostare un'orientazione predefinita del testo all'interno di una forma.

L'esempio di codice seguente imposta l'orientazione del testo nella forma a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), che ruota il testo **di 90 gradi in senso antiorario**:

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

* Usa un valore positivo per specificare l'interlinea come percentuale dell'altezza della riga.
* Usa un valore negativo per specificare l'interlinea in punti.

L'esempio seguente imposta la spaziatura all'interno del primo paragrafo al 200% dell'altezza della riga (doppia interlinea):

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

## **Controlla interruzione di riga**

Le regole di interruzione di riga dei paragrafi sono utili in blocchi di testo stretti e presentazioni che mescolano testo latino e testuale asiatico orientale. Le seguenti proprietà appartengono a [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), quindi si applicano all'intero paragrafo:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) controlla le regole di interruzione di riga per il latino. In testo misto, cambiarlo può anche modificare dove il testo e la punteggiatura asiatici orientali adiacenti vanno a capo.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) controlla le regole di interruzione di riga per gli alfabeti asiatici orientali, incluse le restrizioni sui caratteri all'inizio e alla fine di una riga.

Queste regole non sostituiscono [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), che abilita l'andare a capo automatico all'interno di un riquadro di testo. Influenzano il layout quando avviene il ritorno a capo; non inseriscono caratteri di interruzione di riga. Un ritorno a capo esplicito forza una nuova riga nel paragrafo indipendentemente dalla larghezza disponibile.

L'esempio autonomo seguente crea un blocco di testo stretto contenente cinese e latino. Imposta esplicitamente entrambe le proprietà di interruzione di riga e salva "line_breaking.pptx". Per sperimentare con ciascuna regola, modifica il valore di quella proprietà mantenendo fisse le altre impostazioni. L'esempio utilizza Arial e SimSun a 24 punti con una larghezza del riquadro di 160 punti e margini orizzontali del riquadro di testo pari a zero. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) è impostato su [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) affinché la dimensione del testo e le dimensioni del riquadro rimangano fisse.

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

## **Controlla la punteggiatura sospesa**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) consente alla punteggiatura ammissibile di estendersi oltre il lato destro della riga di testo invece di occupare la riga successiva. Si applica all'intero paragrafo ed è diverso da un rientro sospeso.

L'esempio autonomo seguente abilita la punteggiatura sospesa in un riquadro di testo largo 100 punti e salva "hanging_punctuation.pptx". Con Arial a 24 punti e margini orizzontali del riquadro pari a zero, il punto finale rimane dopo "sentence" e si estende oltre il bordo destro del testo. Imposta la proprietà su [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) per confrontare: con queste impostazioni, il punto occupa una riga separata. L'andare a capo è abilitato e l'adattamento automatico è disabilitato per mantenere fissa la larghezza disponibile.

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

Non tutti i segni di punteggiatura possono sospendersi. Le [condizioni di font e layout descritte sopra](#control-line-breaking) si applicano anche a questo confronto: cambiare il font, la larghezza disponibile, i margini o le impostazioni di adattamento automatico può eliminare la differenza visibile.

## **Imposta tipo di adattamento automatico per i riquadri di testo**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) determina come il testo si comporta quando supera i confini del suo contenitore. Usalo per controllare se il testo si riduce, fuoriesce o ridimensiona automaticamente la forma. L'esempio seguente configura la forma per ridimensionarsi in modo da adattarsi al testo e salva il risultato in "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Per contare le righe dopo l'andare a capo automatico e vedere come la larghezza del testo o della forma cambia il risultato, vedere [Conta le righe renderizzate](/slides/it/net/manage-paragraph/). Il solo conteggio delle righe non indica se il testo supera il suo contenitore.

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

Usa [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) e [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) per configurare le tabulazioni in un paragrafo. L'esempio seguente imposta l'intervallo di tabulazione predefinito a 100 punti e aggiunge una tabulazione allineata a sinistra a 30 punti. Queste impostazioni influenzano il testo che contiene caratteri di tabulazione.

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

## **Imposta lingua di correzione**

Aspose.Slides fornisce [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), che consente di impostare la lingua di correzione per una porzione di testo. La lingua di correzione determina la lingua usata per i controlli ortografici e grammaticali in PowerPoint.

L'esempio seguente richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva e almeno un paragrafo. Sostituisce il contenuto del primo paragrafo con "1。", imposta SimSun come font e assegna la lingua di correzione Cinese semplificato (`zh-CN`). Salva il risultato in "proofing_language.pptx":

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

// Imposta la lingua di correzione a cinese semplificato.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Imposta lingua predefinita**

Usa [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione. L'esempio seguente crea una presentazione con l'inglese US come lingua di testo predefinita, aggiunge una casella di testo e stampa `en-US` per la sua prima porzione di testo.

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

L'esempio seguente imposta un font in grassetto da 14 punti come predefinito per i paragrafi di livello superiore in una nuova presentazione e lo salva in "default_text_style.pptx". Il testo può ereditare questi valori predefiniti a meno che una formattazione più specifica non li sovrascriva.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Get the top level paragraph format.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Estrai testo con l'effetto Tutte Maiuscole**

In PowerPoint, applicare l'effetto **All Caps** al font fa apparire il testo in maiuscolo sulla diapositiva anche se originariamente digitato in minuscolo. Quando si recupera una tale porzione di testo con Aspose.Slides, la libreria restituisce il testo così com'era stato inserito. Per corrispondere al testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) e converti la stringa restituita in maiuscolo quando il valore è `All`.

Questo esempio richiede "sample2.pptx" con una casella di testo come prima forma nella prima diapositiva. La prima porzione del primo paragrafo contiene "Hello, Aspose!" con l'effetto All Caps applicato, come mostrato di seguito.

![L'effetto Tutte Maiuscole](all_caps_effect.png)

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

**Come applico un colore gradiente al testo su una diapositiva PowerPoint?**

Per applicare un colore gradiente al testo, usa [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Imposta [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) su [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.