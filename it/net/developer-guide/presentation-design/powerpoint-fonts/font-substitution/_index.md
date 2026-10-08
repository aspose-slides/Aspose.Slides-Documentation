---
title: Configurare la sostituzione dei font nelle presentazioni in .NET
linktitle: Sostituzione dei font
type: docs
weight: 70
url: /it/net/font-substitution/
keywords:
- font
- font sostitutivo
- sostituzione del font
- sostituire il font
- sostituzione del font
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Configura le regole di sostituzione dei font e ispeziona i font sostituiti in Aspose.Slides per .NET durante il rendering o la conversione di presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

La sostituzione dei font consente ad Aspose.Slides di utilizzare un font disponibile al posto di un font che non può essere accesso quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il font assegnato al contenuto della presentazione.

È possibile definire il font da utilizzare quando un determinato font non è disponibile e ispezionare le sostituzioni che Aspose.Slides effettuerà durante il rendering. Questo aiuta a mantenere l'output coerente tra ambienti con font installati diversi.

Se un font è disponibile ma non ha un tipo di carattere grassetto dedicato, vedere [Gestire i font senza un tipo di carattere grassetto dedicato](/slides/it/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Quella sezione spiega come rasterizzare il testo interessato durante l'esportazione in PDF e le conseguenze per la selezione del testo, la ricerca e il ridimensionamento.

## **Ottenere sostituzioni dei font**

Utilizzare il metodo [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) per determinare quali font verranno sostituiti quando la presentazione è renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) che identificano i nomi del font originale e di quello sostituito.

Il seguente esempio C# elenca tutte le sostituzioni dei font per una presentazione:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Ottenere sostituzioni dei font per le diapositive selezionate**

Utilizzare la sovraccarico [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) con un argomento `int[] slides` per ispezionare solo le sostituzioni necessarie a renderizzare diapositive specifiche. Questo è utile quando si renderizza o esporta una parte di una presentazione, si verifica incrementalmante una presentazione grande, si individuano diapositive che dipendono da font non disponibili, si prepara un pacchetto di font minimo per un server o un container, o si diagnosticano differenze di rendering senza elaborare diapositive non pertinenti.

L'array `slides` contiene indici delle diapositive basati su 1: `1` identifica la prima diapositiva. Al contrario, l'indicizzatore della raccolta [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) è basato su 0, quindi la stessa diapositiva si accede come `presentation.Slides[0]`. Tenere presente questa differenza quando si costruisce l'array per evitare errori di scarto di uno.

Chiamare la sovraccarico tramite la proprietà [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) contenente i nomi del font originale e di quello sostituito. Il risultato riflette l'ambiente font corrente e i [font caricati esternamente](/slides/it/net/custom-font/). Le regole di sostituzione memorizzate in una [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) modificano l'output renderizzato ma non vengono riflesse nel risultato.

La stessa sostituzione può essere richiesta da più di una diapositiva selezionata. Deduplicate i risultati quando si crea un inventario dei font o un rapporto di preflight. Il seguente esempio riporta ogni sostituzione restituita e quindi crea un elenco ordinato di mappature di font uniche:

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

L'interfaccia [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) fornisce entrambe le sovraccarichi. Scegliere una in base all'ambito dell'operazione di rendering:

| Sovraccarico | Quando usarlo |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) senza argomenti | Hai bisogno di sostituzioni per l'intera presentazione. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) con `int[] slides` | Hai bisogno di sostituzioni per un intervallo selezionato, verifica incrementale o esportazione parziale. |

## **Impostare regole di sostituzione dei font**

1. Caricare la presentazione.  
2. Creare definizioni di font per il font di origine e quello sostitutivo.  
3. Creare una [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).  
4. Aggiungere la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).  
5. Assegnare la raccolta alla proprietà [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).  
6. Renderizzare o convertire la presentazione.

Il seguente esempio C# sostituisce `Arial` con `SomeRareFont` quando `SomeRareFont` non è disponibile, e quindi renderizza la prima diapositiva per verificare il risultato. Il font sostitutivo deve essere disponibile per Aspose.Slides.

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
Per una modifica incondizionata dei font utilizzati in tutta la presentazione, vedere [Sostituzione dei font](/slides/it/net/font-replacement/).
{{% /alert %}}

## **Limitazioni per i font delle equazioni matematiche**

Le regole di sostituzione dei font fanno parte del processo standard di selezione dei font utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un font inaccessibile con il font disponibile specificato da una regola.

Le equazioni di Office Math hanno un requisito aggiuntivo. Se un'equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel font esatto per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro font matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo, e il rendering potrebbe comunque segnalare che **Cambria Math** è richiesto.

Per renderizzare o convertire una tale presentazione, rendere **Cambria Math** disponibile ad Aspose.Slides. Installarlo nel sistema operativo o caricarlo come [font esterno](/slides/it/net/custom-font/).

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra continuano a valere per il testo normale della presentazione.

## **FAQ**

**Qual è la differenza tra sostituzione dei font e sostituzione dei font?**

[**Sostituzione dei font**](/slides/it/net/font-replacement/) cambia intenzionalmente un font in un altro in tutta la presentazione. La sostituzione dei font seleziona un font per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il font originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**

Le regole partecipano alla [sequenza di selezione dei font](/slides/it/net/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola viene utilizzata solo quando Aspose.Slides non può accedere al font di origine.

**Cosa succede quando un font è mancante e non è configurata alcuna regola di sostituzione?**

Aspose.Slides seleziona il font disponibile più vicino in base al suo processo di selezione dei font. Il risultato dipende dai font disponibili nell'ambiente di runtime.

**Posso caricare font esterni per evitare la sostituzione?**

Sì. È possibile [caricare font esterni](/slides/it/net/custom-font/) affinché Aspose.Slides li usi durante il rendering e la conversione.

**Aspose distribuisce i font con la libreria?**

No. Sei responsabile di fornire i font e di rispettare le loro licenze.

**I risultati della sostituzione possono differire tra Windows, Linux e macOS?**

Sì. I font installati e i percorsi di ricerca dei font differiscono a seconda del sistema operativo, quindi un font disponibile su una macchina può richiedere una sostituzione su un'altra.

**Come posso rendere la selezione dei font coerente nelle conversioni batch?**

Utilizzare gli stessi file e versioni di font su ogni macchina o container, [caricare i font esterni richiesti](/slides/it/net/custom-font/) e [incorporare i font](/slides/it/net/embedded-font/) quando le licenze lo consentono. È inoltre possibile chiamare [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) prima dell'esportazione per identificare sostituzioni inattese.