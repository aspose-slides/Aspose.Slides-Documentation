---
title: Configurare la sostituzione dei caratteri nelle presentazioni in C++
linktitle: Sostituzione dei caratteri
type: docs
weight: 70
url: /it/cpp/font-substitution/
keywords:
- carattere
- carattere sostituto
- sostituzione del carattere
- sostituire il carattere
- sostituzione del carattere
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Configura le regole di sostituzione dei caratteri e ispeziona i caratteri sostituiti in Aspose.Slides per C++ durante il rendering o la conversione di presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

La sostituzione dei caratteri consente ad Aspose.Slides di utilizzare un carattere disponibile al posto di un carattere che non può essere accesso quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il carattere assegnato al contenuto della presentazione.

È possibile definire il carattere da utilizzare quando un determinato carattere non è disponibile e si può ispezionare le sostituzioni che Aspose.Slides effettuerà durante il rendering. Questo aiuta a mantenere l'output coerente tra ambienti con diversi caratteri installati.

Se un carattere è disponibile ma non ha un tipo di grassetto dedicato, vedere [Gestire i caratteri senza un tipo di grassetto dedicato](/slides/it/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Quella sezione spiega come rasterizzare il testo interessato durante l'esportazione PDF e le conseguenze per la selezione del testo, la ricerca e la scalatura.

## **Ottenere le sostituzioni dei caratteri**

Utilizzare il metodo [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) per determinare quali caratteri saranno sostituiti quando la presentazione viene renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) che identificano i nomi dei caratteri originali e sostituiti.

Il seguente esempio C++ elenca tutte le sostituzioni dei caratteri per una presentazione:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Ottenere le sostituzioni dei caratteri per le diapositive selezionate**

Utilizzare la sovraccarico del metodo [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) con un argomento `System::ArrayPtr<int32_t> slides` per ispezionare solo le sostituzioni necessarie a renderizzare diapositive specifiche. Questo è utile quando si sta renderizzando o esportando una parte di una presentazione, controllando una presentazione di grandi dimensioni in modo incrementale, individuando diapositive che dipendono da caratteri non disponibili, preparando un pacchetto di caratteri minimo per un server o container, oppure diagnosticando differenze di rendering senza elaborare diapositive non correlate.

L'array `slides` contiene indici delle diapositive basati su 1: `1` identifica la prima diapositiva. Al contrario, il metodo [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) utilizza un indice basato su 0, quindi la stessa diapositiva è accessibile come `presentation->get_Slide(0)`. Tenere presente questa differenza quando si costruisce l'array per evitare errori di off-by-one.

Chiamare la sovraccarico tramite il metodo [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) che contiene i nomi dei caratteri originali e sostituiti. Il risultato riflette l'ambiente di caratteri corrente, le regole di fallback configurate, le regole di sostituzione memorizzate in una [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/) e i [caratteri caricati esternamente](/slides/it/cpp/custom-font/).

La stessa sostituzione può essere richiesta da più di una diapositiva selezionata. Rimuovere i duplicati dei risultati quando si crea un inventario dei caratteri o un report di preflight. Il seguente esempio segnala ogni sostituzione restituita e poi crea un elenco ordinato di mappature di caratteri uniche:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

L'interfaccia [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) fornisce entrambe le sovraccarichi. Scegliere quello più adatto al campo dell'operazione di rendering:

| Sovraccarico | Quando usarlo |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Hai bisogno di sostituzioni per l'intera presentazione. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | Hai bisogno di sostituzioni per un intervallo selezionato, controllo incrementale o esportazione parziale. |

## **Impostare le regole di sostituzione dei caratteri**

Per specificare il carattere che Aspose.Slides deve utilizzare quando un carattere sorgente non è disponibile:

1. Caricare la presentazione.
2. Creare definizioni di caratteri per i caratteri sorgente e sostitutivo.
3. Creare una [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/).
4. Aggiungere la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/).
5. Assegnare la collezione usando il metodo [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).
6. Renderizzare o convertire la presentazione.

Il seguente esempio C++ sostituisce `Arial` per `SomeRareFont` quando `SomeRareFont` non è disponibile, e quindi renderizza la prima diapositiva per verificare il risultato. Il carattere sostitutivo deve essere disponibile per Aspose.Slides.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Per una modifica incondizionata dei caratteri utilizzati in tutta la presentazione, vedere [Sostituzione del font](/slides/it/cpp/font-replacement/).
{{% /alert %}}

## **Limitazioni per i caratteri delle equazioni matematiche**

Le regole di sostituzione dei caratteri fanno parte del processo standard di selezione dei caratteri utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un carattere inaccessibile con il carattere disponibile specificato da una regola.

Le equazioni Office Math hanno un requisito aggiuntivo. Se un'equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel carattere esatto per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro carattere matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo, e il rendering potrebbe ancora segnalare che **Cambria Math** è richiesto.

Per renderizzare o convertire una tale presentazione, rendere **Cambria Math** disponibile a Aspose.Slides. Installarlo nel sistema operativo o caricarlo come [carattere esterno](/slides/it/cpp/custom-font/).

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra si applicano comunque al testo normale della presentazione.

## **FAQ**

**Qual è la differenza tra la sostituzione del font e la sostituzione del carattere?**

La [Sostituzione del font](/slides/it/cpp/font-replacement/) cambia intenzionalmente un font con un altro in tutta la presentazione. La sostituzione dei caratteri seleziona un font per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il font originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**

Le regole partecipano alla [sequenza di selezione dei font](/slides/it/cpp/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola viene utilizzata solo quando Aspose.Slides non può accedere al font sorgente.

**Cosa succede quando un font è mancante e nessuna regola di sostituzione è configurata?**

Aspose.Slides seleziona il font disponibile più vicino secondo il suo processo di selezione dei font. Il risultato dipende dai font disponibili nell'ambiente di runtime.

**Posso caricare font esterni per evitare la sostituzione?**

Sì. È possibile [caricare font esterni](/slides/it/cpp/custom-font/) affinché Aspose.Slides possa utilizzarli durante il rendering e la conversione.

**Aspose distribuisce i font con la libreria?**

No. Sei responsabile di fornire i font e di rispettare le loro licenze.

**I risultati di sostituzione possono differire tra Windows, Linux e macOS?**

Sì. I font installati e i percorsi di ricerca dei font differiscono per sistema operativo, quindi un font disponibile su una macchina può richiedere sostituzione su un'altra.

**Come posso rendere coerente la selezione dei font nelle conversioni batch?**

Utilizzare gli stessi file e versioni dei font su ogni macchina o container, [caricare i font esterni richiesti](/slides/it/cpp/custom-font/), e [incorporare i font](/slides/it/cpp/embedded-font/) quando le licenze lo consentono. È inoltre possibile chiamare [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) prima dell'esportazione per individuare sostituzioni inattese.