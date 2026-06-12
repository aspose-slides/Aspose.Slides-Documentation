---
title: Formattare il testo della presentazione in C++
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/cpp/text-formatting/
keywords:
- evidenziare testo
- espressione regolare
- allineare paragrafo
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
- proprietà autofit
- ancoraggio del frame di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Formatta e stila il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per C++. Personalizza font, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per C++. Copre l'evidenziazione, i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà dei font, la rotazione, la spaziatura dei paragrafi, il comportamento di autofit, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Negli esempi seguenti, utilizzeremo un file chiamato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente testo:

![Sample text](sample_text.png)

## **Evidenziare il testo**

Utilizza il metodo [ITextFrame.HighlightText](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/highlighttext/) quando è necessario evidenziare il testo che corrisponde a un campione specifico all'interno di un frame di testo. Il metodo applica un colore di evidenziazione ai frammenti di testo corrispondenti e può essere usato con [ITextSearchOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextsearchoptions/) per controllare come viene eseguita la ricerca, ad esempio per corrispondere solo parole intere.

L'esempio di codice sottostante evidenzia tutte le occorrenze dei caratteri **"try"** e poi evidenzia solo la parola intera **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// Ottieni la prima forma dalla prima diapositiva.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Evidenzia la parola "try" nella forma.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Evidenzia la parola "to" nella forma.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The highlighted text](highlighted_text.png)

## **Evidenziare il testo usando le espressioni regolari**

Il metodo [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/highlightregex/) evidenzia le corrispondenze di testo trovate da un'espressione regolare. In C++, questa API è esposta su [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/).

L'esempio di codice sottostante evidenzia tutte le parole che contengono **sette o più caratteri**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Evidenzia tutte le parole con sette o più caratteri.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Impostare il colore di sfondo del testo**

Usa [IParagraphFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usa [IPortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportionformat/)`.HighlightColor` per singole porzioni di testo.

Il seguente esempio di codice mostra come impostare il colore di sfondo per l'**intero paragrafo**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Imposta il colore di evidenziazione per l'intero paragrafo.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The gray paragraph](gray_paragraph.png)

L'esempio di codice sottostante dimostra come impostare il colore di sfondo per **porzioni di testo con carattere in grassetto**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Imposta il colore di evidenziazione per la porzione di testo.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The gray text portions](gray_text_portions.png)

## **Allineare i paragrafi di testo**

Usa [IParagraphFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/)`.Alignment` per impostare l'allineamento del paragrafo all'interno di un frame di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

Il seguente esempio di codice mostra come allineare il paragrafo al **centro**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Imposta l'allineamento del paragrafo al centro.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The aligned paragraph](aligned_paragraph.png)

## **Impostare la trasparenza del testo**

La trasparenza del testo è controllata tramite il componente alpha del colore assegnato a [IPortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportionformat/)`.FillFormat`. Negli esempi seguenti, `alpha = 50` è un valore alpha del canale ARGB sulla scala 0-255, non una percentuale di trasparenza.

L'esempio di codice sottostante mostra come applicare la trasparenza all'**intero paragrafo**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Imposta il colore di riempimento del testo su colore trasparente.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The transparent paragraph](transparent_paragraph.png)

Il seguente esempio di codice mostra come applicare la trasparenza a **porzioni di testo con carattere in grassetto**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Imposta la trasparenza della porzione di testo.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The transparent text portions](transparent_text_portions.png)

## **Impostare la spaziatura dei caratteri per il testo**

Usa [IBasePortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/)`.Spacing` per espandere o comprimere la spaziatura tra i caratteri in una casella di testo.

Il seguente codice C++ mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

L'esempio di codice sottostante mostra come espandere la spaziatura dei caratteri in **porzioni di testo con carattere in grassetto**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Disabilitare il kerning per font specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Questo può accadere perché PowerPoint potrebbe ignorare i dati di kerning per alcuni font, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per rendere l'output renderizzato più simile a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che utilizzano il font interessato. Imposta [IPortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` a un valore significativamente più grande rispetto alla dimensione reale del font:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Questa impostazione impedisce l'applicazione del kerning alle porzioni di testo corrispondenti e può contribuire ad allineare il rendering di Aspose.Slides all'output visivo di PowerPoint per i font interessati da questo comportamento specifico di PowerPoint.

## **Gestire le proprietà dei font del testo**

Le proprietà dei font possono essere impostate a livello di paragrafo tramite [IParagraphFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` o su singole porzioni tramite [IPortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportionformat/).

Il seguente codice imposta il font e lo stile del testo per l'intero paragrafo: applica la dimensione del font, il grassetto, il corsivo, la sottolineatura punteggiata e il font Times New Roman a tutte le porzioni del paragrafo.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Imposta le proprietà del font per il paragrafo.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The font properties for the paragraph](font_properties_for_paragraph.png)

L'esempio di codice sottostante applica proprietà simili a **porzioni di testo con carattere in grassetto**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Imposta le proprietà del font per la porzione di testo.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Impostare la rotazione del testo**

Utilizza [ITextFrameFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` per impostare un orientamento del testo predefinito all'interno di una forma.

Il seguente esempio di codice imposta l'orientamento del testo nella forma su `Vertical270`, che ruota il testo di **90 gradi in senso antiorario**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The text rotation](text_rotation.png)

## **Impostare una rotazione personalizzata per i frame di testo**

Utilizza [ITextFrameFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/)`.RotationAngle` per impostare un angolo di rotazione personalizzato per un [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/).

L'esempio di codice sottostante ruota il frame di testo di 3 gradi in senso orario all'interno della forma:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The custom text rotation](custom_text_rotation.png)

## **Impostare l'interlinea dei paragrafi**

Aspose.Slides fornisce [IParagraphFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`, `IParagraphFormat.SpaceBefore` e `IParagraphFormat.SpaceWithin` per controllare la spaziatura dei paragrafi. Queste proprietà vengono usate come segue:

* Usa un valore positivo per specificare l'interlinea come percentuale dell'altezza della linea.
* Usa un valore negativo per specificare l'interlinea in punti.

Il seguente esempio di codice mostra come specificare l'interlinea all'interno del paragrafo:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The line spacing within the paragraph](line_spacing.png)

## **Impostare il tipo di Autofit per i frame di testo**

[ITextFrameFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/)`.AutofitType` determina come il testo si comporta quando supera i confini del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Impostare l'ancoraggio dei frame di testo**

[ITextFrameFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/)`.AnchoringType` definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Impostare la tabulazione del testo**

Usa [IParagraphFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` e `IParagraphFormat.Tabs` per configurare le tabulazioni in un paragrafo.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The paragraph tabs](paragraph_tabs.png)

## **Impostare la lingua di revisione**

Aspose.Slides fornisce [IPortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportionformat/)`.LanguageId`, che consente di impostare la lingua di revisione per una porzione di testo. La lingua di revisione determina la lingua utilizzata per il controllo ortografico e grammaticale in PowerPoint.

Il seguente esempio di codice mostra come impostare la lingua di revisione per una porzione di testo:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// Imposta l'Id di una lingua di revisione.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Impostare la lingua predefinita**

Utilizza [ILoadOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Add a new rectangle shape with text.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Check the first portion language.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Impostare lo stile predefinito del testo**

Per applicare la formattazione del testo predefinita a livello di presentazione, usa [IPresentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`.

Il seguente esempio di codice mostra come impostare un font in grassetto predefinito con dimensione 14 pt per tutto il testo in tutte le diapositive di una nuova presentazione.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Ottieni il formato del paragrafo di livello superiore.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Estrarre il testo con l'effetto tutto maiuscolo**

In PowerPoint, l'applicazione dell'effetto font **All Caps** fa apparire il testo in maiuscolo nella diapositiva anche se originariamente è stato digitato in minuscolo. Quando si recupera una tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per corrispondere al testo visualizzato, verifica [TextCapType](https://reference.aspose.com/slides/it/cpp/aspose.slides/textcaptype/) e converte la stringa restituita in maiuscolo quando il valore è `All`.

Supponiamo di avere la seguente casella di testo nella prima diapositiva del file sample2.pptx.

![The All Caps effect](all_caps_effect.png)

L'esempio di codice sottostante mostra come estrarre il testo con l'effetto **All Caps** applicato:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Come modificare il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, usa [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/). Itera le celle e aggiorna ogni cella attraverso [ICell](https://reference.aspose.com/slides/it/cpp/aspose.slides/icell/)`.TextFrame` e la formattazione dei paragrafi tramite [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/)`.ParagraphFormat`.

**Come applicare un colore sfumato al testo in una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, usa [IPortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportionformat/)`.FillFormat`. Imposta [IFillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifillformat/)`.FillType` su [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/)`.Gradient` e configura le fermate del gradiente, la direzione e la trasparenza.