---
title: Configura la sostituzione dei caratteri nelle presentazioni in .NET
linktitle: Sostituzione dei caratteri
type: docs
weight: 70
url: /it/net/font-substitution/
keywords:
- carattere
- carattere di sostituzione
- sostituzione del carattere
- sostituire carattere
- sostituzione del carattere
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Configura le regole di sostituzione dei caratteri e ispeziona i caratteri sostituiti in Aspose.Slides per .NET durante il rendering o la conversione di presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

La sostituzione dei caratteri consente a Aspose.Slides di utilizzare un carattere disponibile al posto di un carattere che non può essere accesso quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il carattere assegnato al contenuto della presentazione.

È possibile definire il carattere da utilizzare quando un determinato carattere non è disponibile e ispezionare le sostituzioni che Aspose.Slides effettuerà durante il rendering. Ciò aiuta a mantenere l'output coerente tra ambienti con diversi caratteri installati.

## **Get Font Substitutions**

Usa il metodo [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) per determinare quali caratteri saranno sostituiti quando la presentazione viene renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) che identificano i nomi del carattere originale e di quello sostituito.

Il seguente esempio C# elenca tutte le sostituzioni di caratteri per una presentazione:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Get Font Substitutions for Selected Slides**

Usa la sovraccarico del metodo [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) con un argomento `int[] slides` per ispezionare solo le sostituzioni necessarie a renderizzare diapositive specifiche. Questo è utile quando si renderizza o si esporta una parte di una presentazione, si verifica incrementalmene una presentazione di grandi dimensioni, si individuano diapositive che dipendono da caratteri non disponibili, si prepara un pacchetto di caratteri minimo per un server o container, o si diagnosticano differenze di rendering senza elaborare diapositive non correlate.

L'array `slides` contiene indici delle diapositive basati su 1: `1` identifica la prima diapositiva. Al contrario, l'indicizzatore della collezione [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) è basato su 0, quindi la stessa diapositiva si accede come `presentation.Slides[0]`. Tieni presente questa differenza quando costruisci l'array per evitare errori di offset.

Chiama la versione sovraccaricata tramite la proprietà [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) che contiene i nomi del carattere originale e di quello sostituito. Il risultato riflette l'ambiente di caratteri corrente e i [caratteri caricati esternamente](/slides/it/net/custom-font/). Le regole di sostituzione memorizzate in una [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) modificano l'output renderizzato ma non sono riflesse nel risultato.

La stessa sostituzione può essere necessaria per più di una diapositiva selezionata. Rimuovi i duplicati dai risultati quando crei un inventario dei caratteri o un report preflight. Il seguente esempio restituisce ogni sostituzione restituita e quindi crea un elenco ordinato di associazioni di caratteri uniche:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

L'interfaccia [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) fornisce entrambe le versioni sovraccaricate. Scegli una in base all'ambito dell'operazione di rendering:

| Sovraccarico | Quando usarla |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) senza argomenti | Hai bisogno di sostituzioni per l'intera presentazione. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) con `int[] slides` | Hai bisogno di sostituzioni per un intervallo selezionato, verifica incrementale o esportazione parziale. |

## **Set Font Substitution Rules**

Per specificare il carattere che Aspose.Slides deve utilizzare quando un carattere di origine non è disponibile:

1. Carica la presentazione.
2. Crea le definizioni dei caratteri per i caratteri di origine e di sostituzione.
3. Crea una [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).
4. Aggiungi la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).
5. Assegna la collezione alla proprietà [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Renderizza o converti la presentazione.

Il seguente esempio C# sostituisce `Arial` con `SomeRareFont` quando `SomeRareFont` non è disponibile, quindi renderizza la prima diapositiva per verificare il risultato. Il carattere sostitutivo deve essere disponibile per Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
Per una modifica incondizionata dei caratteri utilizzati in tutta la presentazione, vedi [Sostituzione dei caratteri](/slides/it/net/font-replacement/).
{{% /alert %}}

## **Limitazioni per i caratteri delle equazioni matematiche**

Le regole di sostituzione dei caratteri fanno parte del processo standard di selezione dei caratteri utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un carattere inaccessibile con il carattere disponibile specificato da una regola.

Le equazioni Office Math hanno un requisito aggiuntivo. Se un'equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel carattere esatto per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro carattere matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo, e il rendering potrebbe comunque segnalare che **Cambria Math** è necessario.

Per renderizzare o convertire una presentazione di questo tipo, rendi disponibile **Cambria Math** a Aspose.Slides. Installa il carattere nel sistema operativo o caricalo come [font esterno](/slides/it/net/custom-font/).

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra si applicano ancora al testo normale della presentazione.

## **FAQ**

**What is the difference between font replacement and font substitution?**

[Font replacement](/slides/it/net/font-replacement/) cambia intenzionalmente un carattere in un altro in tutta la presentazione. Font substitution seleziona un carattere per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il carattere originale non è disponibile.

**When are substitution rules applied?**

Le regole partecipano alla [font selection sequence](/slides/it/net/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola viene usata solo quando Aspose.Slides non può accedere al carattere di origine.

**What happens when a font is missing and no substitution rule is configured?**

Aspose.Slides seleziona il carattere disponibile più vicino in base al suo processo di selezione dei caratteri. Il risultato dipende dai caratteri disponibili nell'ambiente di runtime.

**Can I load external fonts to avoid substitution?**

Sì. È possibile [caricare caratteri esterni](/slides/it/net/custom-font/) in modo che Aspose.Slides possa utilizzarli durante il rendering e la conversione.

**Does Aspose distribute fonts with the library?**

No. Sei responsabile di fornire i caratteri e di rispettare le relative licenze.

**Can substitution results differ between Windows, Linux, and macOS?**

Sì. I caratteri installati e le posizioni di ricerca dei caratteri differiscono a seconda del sistema operativo, quindi un carattere disponibile su una macchina può richiedere una sostituzione su un altro.

**How can I make font selection consistent in batch conversions?**

Usa gli stessi file di caratteri e versioni su ogni macchina o container, [caricare i caratteri esterni richiesti](/slides/it/net/custom-font/), e [incorporare i caratteri](/slides/it/net/embedded-font/) quando le licenze lo consentono. È inoltre possibile chiamare [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) prima dell'esportazione per identificare sostituzioni inattese.