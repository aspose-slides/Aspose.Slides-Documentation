---
title: Automatizza la localizzazione delle presentazioni in .NET
linktitle: Localizzazione delle presentazioni
type: docs
weight: 100
url: /it/net/presentation-localization/
keywords:
- cambia lingua
- controllo ortografico
- sopprimi il controllo ortografico
- lingua di correzione
- ID lingua
- testo multilingue
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Imposta le lingue di correzione per il testo delle presentazioni PowerPoint e OpenDocument in .NET con Aspose.Slides, includendo valori predefiniti e paragrafi multilingue."
---
## **Panoramica**

Aspose.Slides per .NET consente di configurare i metadati di correzione per singole porzioni di testo. Usa [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/languageid/) per identificare la lingua di correzione, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/spellcheck/) per consentire o sopprimere i controlli ortografici e [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/proofdisabled/) per gestire lo stato più ampio di “non correggere”. Poiché queste impostazioni vengono applicate a livello di porzione, un paragrafo può contenere più lingue e regole di correzione diverse.

Questo articolo spiega come assegnare una lingua a un testo specifico, impostare la lingua predefinita per nuovo testo con [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/defaulttextlanguage/), creare paragrafi multilingue, scegliere tra `SpellCheck` e `ProofDisabled` e preservare le impostazioni previste quando si utilizza [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/joinportionswithsameformatting/). Queste proprietà memorizzano metadati per le applicazioni di presentazione; non traducono il testo, non eseguono il controllo ortografico basato su dizionario e non restituiscono parole errate.

## **Imposta la lingua di correzione per il testo**

Crea o carica una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/), accedi alla porzione di testo desiderata tramite [IPortion.PortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/portionformat/) e assegna il suo identificatore di lingua. L’esempio seguente crea una forma, imposta l’inglese britannico come lingua di correzione e salva il risultato con [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Imposta la lingua predefinita per nuovo testo**

Usa [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/defaulttextlanguage/) per specificare la lingua di correzione che Aspose.Slides assegna al testo appena creato. Questa impostazione è utile quando la maggior parte o tutto il nuovo testo di una presentazione utilizza la stessa lingua. Non modifica i metadati di lingua del testo che ha già una lingua esplicita.

L’esempio seguente crea una presentazione il cui nuovo testo utilizza le regole di correzione tedesche:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Usa più lingue in un unico paragrafo**

Un [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) contiene una raccolta di porzioni di testo. Crea una [Portion](https://reference.aspose.com/slides/it/net/aspose.slides/portion/) distinta per ciascuna lingua e imposta il suo `LanguageId` in modo indipendente.

Questo esempio crea un paragrafo con porzioni in inglese e francese:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Abilita o sopprimi il controllo ortografico per singole porzioni**

[IPortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iportionformat/) eredita le proprietà di testo comuni definite da [IBasePortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/). Accedi al formato di una porzione tramite [IPortion.PortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/portionformat/) e imposta [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/spellcheck/) per controllare se l’applicazione di presentazione può verificare l’ortografia per quella porzione. Il valore predefinito è `false`: `true` consente il controllo ortografico, mentre `false` lo sopprime.

L’impostazione si applica a singole porzioni di testo. Porzioni diverse nello stesso paragrafo possono quindi usare valori diversi. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/languageid/) e `SpellCheck` hanno scopi complementari: `LanguageId` identifica la lingua di correzione, mentre `SpellCheck` determina se i controlli ortografici sono consentiti per la porzione.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/proofdisabled/) controlla anch’esso la correzione, ma rappresenta lo stato più ampio “non correggere” come un [NullableBool](https://reference.aspose.com/slides/it/net/aspose.slides/nullablebool/). Usa `SpellCheck` quando ti serve un interruttore booleano diretto specifico per il controllo ortografico. Usa `ProofDisabled` quando devi preservare o controllare esplicitamente i metadati “non correggere” della presentazione, incluso lo stato `NotDefined`. Se imposti entrambe le proprietà, mantieni i loro valori coerenti; non combinare `SpellCheck = true` con `ProofDisabled = NullableBool.True`.

Queste proprietà configurano i metadati di correzione utilizzati da PowerPoint e altre applicazioni di presentazione. Aspose.Slides non le usa per eseguire il controllo ortografico basato su dizionario né per restituire un elenco di parole errate.

L’esempio completo seguente crea una presentazione di input, la carica, assegna impostazioni di controllo ortografico e lingue di correzione diverse a due porzioni nello stesso paragrafo, salva il risultato, lo riapre e verifica i valori memorizzati:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/joinportionswithsameformatting/) combina le porzioni adiacenti che hanno lo stesso formato. Una differenza solo in `SpellCheck` non mantiene separate tali porzioni; dopo che sono state unite, la porzione risultante conserva il valore `SpellCheck` della prima porzione. Se le porzioni necessitano di impostazioni di controllo ortografico diverse, chiama `JoinPortionsWithSameFormatting` prima di assegnare tali impostazioni, oppure ispeziona i confini delle porzioni risultanti e riapplica le impostazioni successivamente. Le porzioni con valori `LanguageId` diversi rimangono separate perché il loro formato di lingua di correzione differisce.

## **FAQ**

**Un ID lingua traduce il testo?**

No. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/languageid/) memorizza i metadati di correzione per ortografia e grammatica; non altera il contenuto del testo. Traduci il testo separatamente, quindi imposta l’identificatore di lingua appropriato per ciascuna porzione tradotta.

**La lingua di correzione controlla i caratteri, la sillabazione o l’interlinea?**

No. L’identificatore di lingua serve solo alla correzione. Il rendering e il layout del testo dipendono principalmente dai [font](/slides/it/net/powerpoint-fonts/) disponibili, dal sistema di scrittura e dalle impostazioni del riquadro di testo. Per un rendering affidabile, fornisci i font necessari, configura la [sostituzione dei font](/slides/it/net/font-substitution/) o [incorpora i font](/slides/it/net/embedded-font/) nella presentazione.

**Un paragrafo può usare più lingue di correzione?**

Sì. Assegna ogni lingua a una porzione separata, come mostrato nell’esempio di paragrafo multilingue.

**Devo usare `DefaultTextLanguage` o `LanguageId`?**

Usa [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/defaulttextlanguage/) quando vuoi un valore predefinito per il testo appena creato. Usa [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/languageid/) quando una porzione specifica richiede una lingua di correzione esplicita o quando un paragrafo contiene più lingue.