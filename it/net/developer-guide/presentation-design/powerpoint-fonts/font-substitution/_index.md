---
title: Configurare la sostituzione dei caratteri nelle presentazioni in .NET
linktitle: Sostituzione dei caratteri
type: docs
weight: 70
url: /it/net/font-substitution/
keywords:
- carattere
- sostituire carattere
- sostituzione dei caratteri
- rimpiazzare carattere
- sostituzione del carattere
- regola di sostituzione
- regola di rimpiazzo
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Configura le regole di sostituzione dei caratteri e ispeziona i caratteri sostituiti in Aspose.Slides per .NET durante il rendering o la conversione di presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

La sostituzione dei caratteri consente ad Aspose.Slides di utilizzare un carattere disponibile al posto di un carattere a cui non è possibile accedere quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il carattere assegnato al contenuto della presentazione.

È possibile definire il carattere da utilizzare quando un carattere specifico non è disponibile e ispezionare le sostituzioni che Aspose.Slides effettuerà durante il rendering. Questo aiuta a mantenere l'output coerente tra ambienti con caratteri installati diversi.

## **Ottenere le sostituzioni dei caratteri**

Utilizzare il metodo [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/getsubstitutions/) per determinare quali caratteri saranno sostituiti quando la presentazione viene renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/it/net/aspose.slides/fontsubstitutioninfo/) che identificano i nomi del carattere originale e di quello sostituito.

Il seguente esempio C# elenca tutte le sostituzioni dei caratteri per una presentazione:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Ottenere le sostituzioni dei caratteri per diapositive selezionate**

Utilizzare la sovraccarico di [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/getsubstitutions/) con un argomento `int[] slides` per ispezionare solo le sostituzioni necessarie a renderizzare diapositive specifiche. Questo è utile quando si renderizza o si esporta una parte di una presentazione, si controlla una presentazione di grandi dimensioni in modo incrementale, si individuano diapositive che dipendono da caratteri non disponibili, si prepara un pacchetto di caratteri minimo per un server o un contenitore, o si diagnosticano differenze di rendering senza elaborare diapositive non correlate.

L'array `slides` contiene indici diapositive basati su 1: `1` identifica la prima diapositiva. Al contrario, l'indicizzatore della collezione [Presentation.Slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slides/it/) è basato su 0, quindi la stessa diapositiva è accessibile come `presentation.Slides[0]`. Tenere presente questa differenza quando si costruisce l'array per evitare errori di “off‑by‑one”.

Chiamare la sovraccarico tramite la proprietà [Presentation.FontsManager](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/fontsmanager/). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/it/net/aspose.slides/fontsubstitutioninfo/) che contiene i nomi del carattere originale e di quello sostituito. Il risultato riflette l'ambiente dei caratteri corrente, le regole di fallback configurate, le regole di sostituzione memorizzate in una [IFontSubstRuleCollection](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsubstrulecollection/), e i [caratteri caricati esternamente](/slides/it/net/custom-font/).

La stessa sostituzione può essere richiesta da più di una diapositiva selezionata. De‑duplicare i risultati quando si crea un inventario dei caratteri o un rapporto di preflight. Il seguente esempio riporta ogni sostituzione restituita e poi crea un elenco ordinato di mappature di caratteri uniche:

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

L'interfaccia [IFontsManager](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/) fornisce entrambe le sovraccarichi. Scegliere quella più appropriata in base all'ambito dell'operazione di rendering:

| Sovraccarico | Quando usarlo |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/getsubstitutions/) senza argomenti | Hai bisogno delle sostituzioni per l'intera presentazione. |
| [GetSubstitutions](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/getsubstitutions/) con `int[] slides` | Hai bisogno delle sostituzioni per un intervallo selezionato, un controllo incrementale o un'esportazione parziale. |

## **Definire regole di sostituzione dei caratteri**

Per specificare il carattere che Aspose.Slides deve utilizzare quando un carattere sorgente non è disponibile:

1. Caricare la presentazione.  
2. Creare le definizioni dei caratteri per il carattere sorgente e quello sostituto.  
3. Creare una [FontSubstRule](https://reference.aspose.com/slides/it/net/aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/it/net/aspose.slides/fontsubstcondition/).  
4. Aggiungere la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/it/net/aspose.slides/fontsubstrulecollection/).  
5. Assegnare la collezione alla proprietà [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/fontsubstrulelist/).  
6. Renderizzare o convertire la presentazione.

Il seguente esempio C# sostituisce `Arial` con `SomeRareFont` quando `SomeRareFont` non è disponibile, e poi renderizza la prima diapositiva per verificare il risultato. Il carattere sostituto deve essere disponibile per Aspose.Slides.

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
Per una modifica incondizionata dei caratteri utilizzati in tutta la presentazione, vedere la sezione [Sostituzione dei caratteri](/slides/it/net/font-replacement/).
{{% /alert %}}

## **Limitazioni per i caratteri delle equazioni matematiche**

Le regole di sostituzione dei caratteri fanno parte del processo standard di selezione dei caratteri utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un carattere inaccessibile con quello disponibile specificato nella regola.

Le equazioni di Office Math hanno un requisito aggiuntivo. Se un’equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel carattere esatto per calcolare e renderizzare il layout dell’equazione. Una regola che sostituisce un altro carattere matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo e il rendering può comunque segnalare che **Cambria Math** è necessario.

Per renderizzare o convertire una presentazione di questo tipo, rendere **Cambria Math** disponibile per Aspose.Slides. Installarlo nel sistema operativo o caricarlo come [carattere esterno](/slides/it/net/custom-font/).

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra continuano a valere per il testo normale della presentazione.

## **FAQ**

**Qual è la differenza tra sostituzione dei caratteri e sostituzione (replacement) dei caratteri?**

[Font replacement](/slides/it/net/font-replacement/) modifica intenzionalmente un carattere in un altro in tutta la presentazione. La sostituzione dei caratteri seleziona un carattere per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il carattere originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**

Le regole partecipano alla [sequenza di selezione dei caratteri](/slides/it/net/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola è usata solo quando Aspose.Slides non riesce ad accedere al carattere sorgente.

** Cosa succede quando un carattere manca e nessuna regola di sostituzione è configurata?**

Aspose.Slides seleziona il carattere disponibile più vicino secondo il suo processo di selezione dei caratteri. Il risultato dipende dai caratteri presenti nell'ambiente di runtime.

**Posso caricare caratteri esterni per evitare la sostituzione?**

Sì. È possibile [caricare caratteri esterni](/slides/it/net/custom-font/) affinché Aspose.Slides li utilizzi durante il rendering e la conversione.

**Aspose distribuisce i caratteri con la libreria?**

No. È responsabilità dell'utente fornire i caratteri e rispettare le relative licenze.

**I risultati della sostituzione possono differire tra Windows, Linux e macOS?**

Sì. I caratteri installati e le posizioni di ricerca dei caratteri variano a seconda del sistema operativo, quindi un carattere disponibile su una macchina può richiedere sostituzione su un'altra.

**Come posso rendere coerente la selezione dei caratteri nelle conversioni batch?**

Usare gli stessi file e versioni dei caratteri su ogni macchina o contenitore, [caricare i caratteri esterni richiesti](/slides/it/net/custom-font/) e [incorporare i caratteri](/slides/it/net/embedded-font/) quando le licenze lo consentono. È inoltre possibile chiamare [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/getsubstitutions/) prima dell'esportazione per identificare sostituzioni inattese.