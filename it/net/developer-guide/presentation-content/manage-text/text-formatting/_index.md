---
title: Formattare il testo della presentazione in .NET
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/net/text-formatting/
keywords:
- allineare paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del font
- famiglia del font
- rotazione del testo
- angolo di rotazione
- frame del testo
- interlinea
- proprietà di adattamento automatico
- ancoraggio del frame di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Formattare e stilizzare il testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET. Personalizza font, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET. Copre i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà del font, la rotazione, la spaziatura dei paragrafi, il comportamento di adattamento automatico, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Negli esempi seguenti, utilizzeremo un file chiamato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente testo:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedi [Cerca e Sostituisci Testo](/slides/it/net/search-and-replace-text/).

## **Imposta colore di sfondo del testo**

Utilizza [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/defaultportionformat/) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure utilizza [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/highlightcolor/) per singole porzioni di testo.

Il seguente esempio di codice mostra come impostare il colore di sfondo per l'**intero paragrafo**: 

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Imposta il colore di evidenziazione per l'intero paragrafo.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![Il paragrafo grigio](gray_paragraph.png)

L'esempio di codice qui sotto dimostra come impostare il colore di sfondo per **porzioni di testo con un font grassetto**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Il risultato:

![Le porzioni di testo grigie](gray_text_portions.png)

## **Allinea paragrafi di testo**

Utilizza [IParagraphFormat.Alignment](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/alignment/) per impostare l'allineamento del paragrafo all'interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato e così via.

Il seguente esempio di codice mostra come allineare il paragrafo al **centro**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Imposta l'allineamento del paragrafo al centro.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![Il paragrafo allineato](aligned_paragraph.png)

## **Imposta trasparenza per il testo**

La trasparenza del testo è controllata tramite la componente alfa del colore assegnato a [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/fillformat/). Negli esempi seguenti, `alpha = 50` è un valore alfa ARGB su scala 0–255, non una percentuale di trasparenza.

L'esempio di codice qui sotto mostra come applicare la trasparenza all'**intero paragrafo**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Imposta il colore di riempimento del testo a colore trasparente.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![Il paragrafo trasparente](transparent_paragraph.png)

Il seguente esempio di codice mostra come applicare la trasparenza a **porzioni di testo con un font grassetto**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Il risultato:

![Le porzioni di testo trasparenti](transparent_text_portions.png)

## **Imposta spaziatura dei caratteri per il testo**

Utilizza [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/spacing/) per espandere o ridurre la spaziatura tra i caratteri in una casella di testo.

Il seguente codice C# mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Espandi la spaziatura dei caratteri.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

L'esempio di codice qui sotto mostra come espandere la spaziatura dei caratteri in **porzioni di testo con un font grassetto**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Il risultato:

![La spaziatura dei caratteri nelle porzioni di testo](character_spacing_in_text_portions.png)

### **Disabilita il kerning per caratteri specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint può ignorare i dati di kerning per determinati caratteri, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per rendere l'output renderizzato più simile a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che utilizzano il carattere interessato. Imposta [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/kerningminimalsize/) a un valore significativamente più grande rispetto alla dimensione effettiva del carattere:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Questa impostazione impedisce l'applicazione del kerning alle porzioni di testo corrispondenti e può aiutare ad allineare il rendering di Aspose.Slides con l'output visivo di PowerPoint per i caratteri influenzati da questo comportamento specifico di PowerPoint.

## **Gestisci proprietà del font del testo**

Le proprietà del font possono essere impostate a livello di paragrafo tramite [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/defaultportionformat/) o su singole porzioni tramite [IPortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformat/).

Il seguente codice imposta il font e lo stile del testo per l'intero paragrafo: applica dimensione del font, grassetto, corsivo, sottolineatura puntinata e il font Times New Roman a tutte le porzioni del paragrafo.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Imposta le proprietà del font per il paragrafo.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![Le proprietà del font per il paragrafo](font_properties_for_paragraph.png)

L'esempio di codice qui sotto applica proprietà simili a **porzioni di testo con un font grassetto**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Il risultato:

![Le proprietà del font per le porzioni di testo](font_properties_for_text_portions.png)

## **Imposta rotazione del testo**

Utilizza [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/textverticaltype/) per impostare un'orientazione di testo predefinita all'interno di una forma.

Il seguente esempio di codice imposta l'orientazione del testo nella forma su `Vertical270`, che ruota il testo **di 90 gradi in senso antiorario**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![La rotazione del testo](text_rotation.png)

## **Imposta rotazione personalizzata per i frame di testo**

Utilizza [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/rotationangle/) per impostare un angolo di rotazione personalizzato per un [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/).

Il codice qui sotto ruota il riquadro di testo di 3 gradi in senso orario all'interno della forma: 

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![La rotazione personalizzata del testo](custom_text_rotation.png)

## **Imposta interlinea dei paragrafi**

Aspose.Slides fornisce [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/spacebefore/), e [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/spacewithin/) per controllare la spaziatura dei paragrafi. Queste proprietà vengono utilizzate come segue:

* Utilizzare un valore positivo per specificare l'interlinea come percentuale dell'altezza della riga.
* Utilizzare un valore negativo per specificare l'interlinea in punti.

Il seguente esempio di codice mostra come specificare l'interlinea all'interno del paragrafo:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![L'interlinea nel paragrafo](line_spacing.png)

## **Imposta tipo di adattamento automatico per i frame di testo**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/autofittype/) determina come il testo si comporta quando supera i limiti del contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

Per contare le linee dopo l'avvolgimento automatico e vedere come cambia la larghezza del testo o della forma, vedi [Conta linee renderizzate](/slides/it/net/manage-paragraph/). Il conteggio delle linee da solo non indica se il testo supera il contenitore.

## **Imposta ancoraggio dei frame di testo**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/anchoringtype/) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Imposta tabulazione del testo**

Utilizza [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/defaulttabsize/) e [IParagraphFormat.Tabs](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/tabs/) per configurare le tabulazioni in un paragrafo.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![Le tabulazioni del paragrafo](paragraph_tabs.png)

## **Imposta lingua di revisione**

Aspose.Slides fornisce [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/languageid/), che consente di impostare la lingua di revisione per una porzione di testo. La lingua di revisione determina la lingua usata per il controllo ortografico e grammaticale in PowerPoint.

Il seguente esempio di codice mostra come impostare la lingua di revisione per una porzione di testo:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Imposta l'Id di una lingua di revisione.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Imposta lingua predefinita**

Utilizza [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/defaulttextlanguage/) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Aggiungi una nuova forma rettangolare con testo.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Controlla la lingua della prima porzione.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Imposta stile di testo predefinito**

Per applicare la formattazione di testo predefinita a livello di presentazione, utilizza [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/defaulttextstyle/).

Il seguente esempio di codice mostra come impostare un font predefinito in grassetto con dimensione 14 pt per tutto il testo di tutte le diapositive in una nuova presentazione.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // Ottieni il formato del paragrafo di livello superiore.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Estrai testo con l'effetto tutto maiuscolo**

In PowerPoint, l'applicazione dell'effetto **All Caps** al font fa apparire il testo in maiuscolo sulla diapositiva anche se originariamente è stato digitato in minuscolo. Quando si recupera tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per corrispondere al testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/it/net/aspose.slides/textcaptype/) e converte la stringa restituita in maiuscolo quando il valore è `All`.

Supponiamo di avere la seguente casella di testo nella prima diapositiva del file sample2.pptx.

![L'effetto tutto maiuscolo](all_caps_effect.png)

Il codice qui sotto mostra come estrarre il testo con l'effetto **All Caps** applicato:

```cs
using Aspose.Slides;

using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Come modificare il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, utilizza [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/). Itera attraverso le celle e aggiorna ciascuna cella tramite [ICell.TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/icell/textframe/) e la formattazione del paragrafo tramite [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/paragraphformat/).

**Come applicare un colore sfumato al testo in una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, utilizza [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/fillformat/). Imposta [IFillFormat.FillType](https://reference.aspose.com/slides/it/net/aspose.slides/ifillformat/filltype/) su [FillType.Gradient](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.