---
title: Configura la sostituzione dei caratteri nelle presentazioni in C++
linktitle: Sostituzione dei caratteri
type: docs
weight: 70
url: /it/cpp/font-substitution/
keywords:
- carattere
- sostituzione del carattere
- sostituzione dei caratteri
- sostituire carattere
- sostituzione del carattere
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Configura le regole di sostituzione dei caratteri e visualizza i caratteri sostituiti in Aspose.Slides per C++ durante il rendering o la conversione di presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

La sostituzione dei caratteri consente ad Aspose.Slides di utilizzare un carattere disponibile al posto di un carattere che non può essere accesso quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il carattere assegnato al contenuto della presentazione.

È possibile definire il carattere da usare quando un determinato carattere non è disponibile e si possono esaminare le sostituzioni che Aspose.Slides eseguirà durante il rendering. Questo aiuta a mantenere l'output coerente in ambienti con diversi caratteri installati.

## **Ottenere le sostituzioni dei caratteri**

Utilizzare il metodo [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/getsubstitutions/) per determinare quali caratteri verranno sostituiti quando la presentazione viene renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsubstitutioninfo/) che identificano i nomi del carattere originale e di quello sostituito.

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

## **Ottenere le sostituzioni dei caratteri per diapositive selezionate**

Utilizzare la sovraccarico del metodo [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/getsubstitutions/) con l'argomento `System::ArrayPtr<int32_t> slides` per ispezionare solo le sostituzioni necessarie a renderizzare diapositive specifiche. È utile quando si renderizza o si esporta una parte di una presentazione, si verifica una presentazione di grandi dimensioni in modo incrementale, si individuano diapositive che dipendono da caratteri non disponibili, si prepara un pacchetto di caratteri minimo per un server o contenitore, o si diagnostica una differenza di rendering senza elaborare diapositive non correlate.

L'array `slides` contiene indici diapositive basati su 1: `1` identifica la prima diapositiva. Al contrario, il metodo [Presentation::get_Slide](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_slide/) utilizza un indice basato su 0, quindi la stessa diapositiva è accessibile con `presentation->get_Slide(0)`. Tenere presente questa differenza quando si costruisce l'array per evitare errori di offset.

Chiamare la sovraccarico tramite il metodo [Presentation::get_FontsManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_fontsmanager/). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsubstitutioninfo/) che contiene i nomi del carattere originale e di quello sostituito. Il risultato riflette l'ambiente dei caratteri corrente, le regole di fallback configurate, le regole di sostituzione memorizzate in una [IFontSubstRuleCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsubstrulecollection/) e i [caratteri caricati esternamente](/slides/it/cpp/custom-font/).

La stessa sostituzione può essere richiesta da più di una diapositiva selezionata. Rimuovere i duplicati quando si crea un inventario dei caratteri o un rapporto di preflight. Il seguente esempio riporta ogni sostituzione restituita e poi crea un elenco ordinato di mappature di caratteri uniche:

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

L'interfaccia [IFontsManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/) fornisce entrambe le sovraccarichi. Scegliere quella più adatta allo scopo dell'operazione di rendering:

| Sovraccarico | Quando usarlo |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/getsubstitutions/) senza argomenti | Sono necessarie le sostituzioni per l'intera presentazione. |
| [GetSubstitutions](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/getsubstitutions/) con `System::ArrayPtr<int32_t> slides` | Sono necessarie le sostituzioni per un intervallo selezionato, un controllo incrementale o un'esportazione parziale. |

## **Impostare le regole di sostituzione dei caratteri**

Per specificare il carattere che Aspose.Slides deve usare quando un carattere sorgente non è disponibile:

1. Caricare la presentazione.  
2. Creare le definizioni dei caratteri per il carattere sorgente e quello di sostituzione.  
3. Creare una [FontSubstRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsubstcondition/).  
4. Aggiungere la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsubstrulecollection/).  
5. Assegnare la collezione usando il metodo [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).  
6. Renderizzare o convertire la presentazione.

Il seguente esempio C++ sostituisce `Arial` con `SomeRareFont` quando `SomeRareFont` non è disponibile, quindi renderizza la prima diapositiva per verificare il risultato. Il carattere di sostituzione deve essere disponibile per Aspose.Slides.

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
Per una modifica incondizionata dei caratteri usati in tutta la presentazione, vedere [Sostituzione dei caratteri](/slides/it/cpp/font-replacement/).
{{% /alert %}}

## **Limitazioni per i caratteri delle equazioni matematiche**

Le regole di sostituzione dei caratteri fanno parte del processo standard di selezione dei caratteri utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un carattere non accessibile con quello disponibile specificato da una regola.

Le equazioni Office Math hanno un requisito aggiuntivo. Se un'equazione usa **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel carattere esatto per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro carattere matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo, e il rendering potrebbe comunque segnalare che **Cambria Math** è necessario.

Per renderizzare o convertire una presentazione di questo tipo, rendere **Cambria Math** disponibile ad Aspose.Slides. Installarlo nel sistema operativo o caricarlo come [carattere esterno](/slides/it/cpp/custom-font/).

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra continuano a valere per il testo normale della presentazione.

## **FAQ**

**Qual è la differenza tra sostituzione dei caratteri e sostituzione dei caratteri?**

[Font replacement](/slides/it/cpp/font-replacement/) cambia intenzionalmente un carattere con un altro in tutta la presentazione. La sostituzione dei caratteri seleziona un carattere per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il carattere originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**

Le regole partecipano alla [sequenza di selezione dei caratteri](/slides/it/cpp/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola è usata solo quando Aspose.Slides non può accedere al carattere sorgente.

** Cosa succede quando un carattere è mancante e non è configurata alcuna regola di sostituzione?**

Aspose.Slides seleziona il carattere più vicino disponibile secondo il suo processo di selezione dei caratteri. Il risultato dipende dai caratteri disponibili nell'ambiente di runtime.

**Posso caricare caratteri esterni per evitare la sostituzione?**

Sì. È possibile [caricare caratteri esterni](/slides/it/cpp/custom-font/) affinché Aspose.Slides li utilizzi durante il rendering e la conversione.

**Aspose distribuisce i caratteri con la libreria?**

No. È responsabilità dell'utente fornire i caratteri e rispettare le loro licenze.

**I risultati della sostituzione possono differire tra Windows, Linux e macOS?**

Sì. I caratteri installati e le posizioni di ricerca dei caratteri differiscono per sistema operativo, quindi un carattere disponibile su una macchina può richiedere sostituzione su un'altra.

**Come posso rendere la selezione dei caratteri coerente nelle conversioni batch?**

Usare gli stessi file e versioni dei caratteri su ogni macchina o contenitore, [caricare i caratteri esterni necessari](/slides/it/cpp/custom-font/) e [incorporare i caratteri](/slides/it/cpp/embedded-font/) quando le licenze lo consentono. È inoltre possibile chiamare [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/getsubstitutions/) prima dell'esportazione per identificare sostituzioni inattese.