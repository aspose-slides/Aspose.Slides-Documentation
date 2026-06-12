---
title: Formattare il testo della presentazione in .NET
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/net/text-formatting/
keywords:
- evidenziazione del testo
- espressione regolare
- allineamento del paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del font
- famiglia di font
- rotazione del testo
- angolo di rotazione
- frame di testo
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
description: "Formattare e stilizzare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET. Personalizzare caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET. Copre l'evidenziazione, i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà del carattere, la rotazione, la spaziatura dei paragrafi, il comportamento di adattamento automatico, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Negli esempi seguenti usiamo un file chiamato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente testo:

![Testo di esempio](sample_text.png)

## **Evidenzia testo**

Utilizzare il metodo [ITextFrame.HighlightText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlighttext/) quando è necessario evidenziare il testo che corrisponde a un determinato campione all'interno di un frame di testo. Il metodo applica un colore di evidenziazione ai frammenti di testo corrispondenti e può essere usato con [TextSearchOptions](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/) per controllare come viene eseguita la ricerca, ad esempio per corrispondere solo parole intere.

L'esempio di codice seguente evidenzia tutte le occorrenze dei caratteri **"try"** e successivamente evidenzia solo la parola intera **"to"**.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Ottieni la prima forma dalla prima diapositiva.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Evidenzia la parola "try" nella forma.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Evidenzia la parola "to" nella forma.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![Il testo evidenziato](highlighted_text.png)

## **Evidenzia testo usando le espressioni regolari**

Il metodo [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlightregex/) evidenzia le corrispondenze di testo trovate da un'espressione regolare. In .NET, questa API è esposta su [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/).

L'esempio di codice seguente evidenzia tutte le parole che contengono **sette o più caratteri**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Evidenzia tutte le parole con sette o più caratteri.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![Il testo evidenziato usando l'espressione regolare](highlighted_text_using_regex.png)

## **Imposta colore di sfondo del testo**

Utilizzare [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/defaultportionformat/) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usare [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformat/highlightcolor/) per sezioni di testo individuali.

Il seguente esempio di codice mostra come impostare il colore di sfondo per l'**intero paragrafo**:

```cs
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

L'esempio di codice seguente dimostra come impostare il colore di sfondo per le **sezioni di testo con carattere grassetto**:

```cs
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

![Le sezioni di testo grigie](gray_text_portions.png)

## **Allinea paragrafi di testo**

Utilizzare [IParagraphFormat.Alignment](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/alignment/) per impostare l'allineamento del paragrafo all'interno di un frame di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

Il seguente esempio di codice mostra come allineare il paragrafo al **centro**:

```cs
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

La trasparenza del testo è controllata tramite il componente alfa del colore assegnato a [IPortionFormat.FillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformat/fillformat/). negli esempi seguenti, `alpha = 50` è un valore alfa ARGB su scala 0–255, non una percentuale di trasparenza.

L'esempio di codice seguente mostra come applicare trasparenza al **intero paragrafo**:

```cs
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

Il codice seguente applica trasparenza alle **sezioni di testo con carattere grassetto**:

```cs
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

![Le sezioni di testo trasparenti](transparent_text_portions.png)

## **Imposta spaziatura dei caratteri per il testo**

Utilizzare [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/spacing/) per espandere o comprimere la spaziatura tra i caratteri in una casella di testo.

Il seguente codice C# mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nota: usare valori negativi per comprimere la spaziatura dei caratteri.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Espandi la spaziatura dei caratteri.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

L'esempio di codice seguente mostra come espandere la spaziatura dei caratteri nelle **sezioni di testo con carattere grassetto**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Il risultato:

![La spaziatura dei caratteri nelle sezioni di testo](character_spacing_in_text_portions.png)

### **Disattiva kerning per font specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Questo può accadere perché PowerPoint potrebbe ignorare i dati di kerning per alcuni font, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per rendere l'output renderizzato più simile a PowerPoint in tali casi, è possibile disattivare il kerning per le sezioni di testo che utilizzano il font interessato. Impostare [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/kerningminimalsize/) a un valore significativamente più grande della dimensione effettiva del font:

```cs
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

Questa impostazione impedisce l'applicazione del kerning alle sezioni di testo corrispondenti e può aiutare ad allineare il rendering di Aspose.Slides all'output visivo di PowerPoint per i font colpiti da questo comportamento specifico di PowerPoint.

## **Gestisci proprietà del carattere del testo**

Le proprietà del carattere possono essere impostate a livello di paragrafo tramite [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/defaultportionformat/) oppure su singole parti tramite [IPortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformat/).

Il seguente codice imposta il carattere e lo stile del testo per l'intero paragrafo: applica la dimensione del carattere, il grassetto, il corsivo, la sottolineatura a punti e il font Times New Roman a tutte le parti del paragrafo.

```cs
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

![Le proprietà del carattere per il paragrafo](font_properties_for_paragraph.png)

L'esempio di codice seguente applica proprietà simili alle **sezioni di testo con carattere grassetto**:

```cs
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

![Le proprietà del carattere per le sezioni di testo](font_properties_for_text_portions.png)

## **Imposta rotazione del testo**

Utilizzare [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/textverticaltype/) per impostare un orientamento del testo predefinito all'interno di una forma.

Il seguente esempio di codice imposta l'orientamento del testo nella forma su `Vertical270`, che ruota il testo di **90 gradi in senso antiorario**:

```cs
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

Utilizzare [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/rotationangle/) per impostare un angolo di rotazione personalizzato per un [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/).

L'esempio di codice seguente ruota il frame di testo di 3 gradi in senso orario all'interno della forma:

```cs
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

* Utilizzare un valore positivo per specificare l'interlinea come percentuale dell'altezza della linea.
* Utilizzare un valore negativo per specificare l'interlinea in punti.

Il seguente esempio di codice mostra come specificare l'interlinea all'interno del paragrafo:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![L'interlinea all'interno del paragrafo](line_spacing.png)

## **Imposta tipo di adattamento automatico per i frame di testo**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/autofittype/) determina come il testo si comporta quando supera i confini del suo contenitore. Usarlo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Imposta ancoraggio dei frame di testo**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/anchoringtype/) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Imposta tabulazione del testo**

Utilizzare [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/defaulttabsize/) e [IParagraphFormat.Tabs](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/tabs/) per configurare le tabulazioni in un paragrafo.

```cs
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

## **Imposta lingua di controllo**

Aspose.Slides fornisce [IPortionFormat.LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformat/languageid/), che consente di impostare la lingua di controllo per una sezione di testo. La lingua di controllo determina la lingua usata per il controllo ortografico e grammaticale in PowerPoint.

Il seguente esempio di codice mostra come impostare la lingua di controllo per una sezione di testo:

```cs
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

    // Imposta l'Id di una lingua di correzione.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Imposta lingua predefinita**

Utilizzare [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/defaulttextlanguage/) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione.

```cs
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

Per applicare la formattazione del testo predefinita a livello di presentazione, utilizzare [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/defaulttextstyle/).

Il seguente esempio di codice mostra come impostare un font grassetto predefinito con dimensione 14 pt per tutto il testo in tutte le diapositive in una nuova presentazione.

```cs
using (var presentation = new Presentation())
{
    // Recupera il formato del paragrafo di livello superiore.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Estrai testo con effetto tutto maiuscolo**

In PowerPoint, applicare l'effetto carattere **All Caps** fa apparire il testo in maiuscolo nella diapositiva anche se è stato originariamente digitato in minuscolo. Quando si recupera una tale sezione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per far corrispondere il testo visualizzato, controllare [TextCapType](https://reference.aspose.com/slides/it/net/aspose.slides/textcaptype/) e convertire la stringa restituita in maiuscolo quando il valore è `All`.

Supponiamo di avere la seguente casella di testo nella prima diapositiva del file sample2.pptx.

![L'effetto All Caps](all_caps_effect.png)

L'esempio di codice seguente mostra come estrarre il testo con l'effetto **All Caps** applicato:

```cs
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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Come modificare il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, utilizzare [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/). Iterare le celle e aggiornare ciascuna cella tramite [ICell.TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/icell/textframe/) e la formattazione del paragrafo tramite [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/paragraphformat/).

**Come applicare un colore sfumato al testo in una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, utilizzare [IPortionFormat.FillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformat/fillformat/). Impostare [IFillFormat.FillType](https://reference.aspose.com/slides/it/net/aspose.slides/ifillformat/filltype/) su [FillType.Gradient](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) e configurare le fermate del gradiente, la direzione e la trasparenza.