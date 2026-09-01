---
title: Automatizzare la localizzazione delle presentazioni in C++
linktitle: Localizzazione della presentazione
type: docs
weight: 100
url: /it/cpp/presentation-localization/
keywords:
- cambio lingua
- controllo ortografico
- sopprimere il controllo ortografico
- lingua di correzione
- ID lingua
- testo multilingue
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Imposta le lingue di correzione per il testo delle presentazioni PowerPoint e OpenDocument in C++ con Aspose.Slides, includendo impostazioni predefinite e paragrafi multilingue."
---
## **Panoramica**

Aspose.Slides for C++ consente di configurare i metadati di correzione per singole porzioni di testo. Utilizza [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/set_languageid/) per identificare la lingua di correzione, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_spellcheck/) per consentire o sopprimere i controlli ortografici e [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_proofdisabled/) per gestire lo stato più ampio di "nessuna correzione". Poiché queste impostazioni vengono applicate a livello di porzione, un singolo paragrafo può contenere più lingue e regole di correzione differenti.

Questo articolo spiega come assegnare una lingua a testo specifico, impostare la lingua predefinita per nuovo testo con [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), creare paragrafi multilingue, scegliere tra `SpellCheck` e `ProofDisabled` e mantenere le impostazioni desiderate quando si utilizza [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/joinportionswithsameformatting/). Queste proprietà memorizzano metadati per le applicazioni di presentazione; non traducono il testo, non eseguono controlli ortografici basati su dizionario né restituiscono parole errate.

## **Imposta la lingua di correzione per il testo**

Crea o carica una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/), accedi alla porzione di testo desiderata tramite [IPortion::get_PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/get_portionformat/) e assegna il suo identificatore di lingua. L'esempio seguente crea una forma, imposta l'inglese britannico come lingua di correzione e salva il risultato con [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Imposta la lingua predefinita per il nuovo testo**

Utilizza [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) per specificare la lingua di correzione che Aspose.Slides assegna al testo creato di recente. Questa impostazione è utile quando la maggior parte o tutto il nuovo testo di una presentazione utilizza la stessa lingua. Non modifica i metadati linguistici del testo che ha già una lingua esplicita.

L'esempio seguente crea una presentazione il cui nuovo testo utilizza le regole di correzione tedesche:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Usa più lingue in un unico paragrafo**

Un [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/) contiene una raccolta di porzioni di testo. Crea una [Portion](https://reference.aspose.com/slides/it/cpp/aspose.slides/portion/) separata per ogni lingua e imposta il suo `LanguageId` in modo indipendente.

Questo esempio crea un paragrafo con porzioni in inglese e francese:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Abilita o sopprimi il controllo ortografico per le porzioni individuali**

[IPortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportionformat/) eredita le proprietà di testo comuni definite da [IBasePortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/). Accedi al formato di una porzione tramite [IPortion::get_PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/get_portionformat/) e chiama [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_spellcheck/) per controllare se un'applicazione di presentazione può verificare l'ortografia per quella porzione. Il valore predefinito è `false`: `true` consente il controllo ortografico, mentre `false` lo sopprime.

L'impostazione si applica a singole porzioni di testo. Porzioni diverse nello stesso paragrafo possono quindi utilizzare valori differenti. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_languageid/) e `SpellCheck` hanno scopi complementari: `LanguageId` identifica la lingua di correzione, mentre `SpellCheck` determina se i controlli ortografici sono consentiti per la porzione.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_proofdisabled/) controlla anch'esso la correzione, ma rappresenta lo stato più ampio di "non correggere" come un [NullableBool](https://reference.aspose.com/slides/it/cpp/aspose.slides/nullablebool/). Usa `SpellCheck` quando ti serve un interruttore Booleano diretto specifico per i controlli ortografici. Usa `ProofDisabled` quando devi preservare o controllare esplicitamente i metadati di "non correzione" della presentazione, incluso lo stato `NullableBool::NotDefined`. Se imposti entrambe le proprietà, mantieni i valori coerenti; non combinare `SpellCheck = true` con `ProofDisabled = NullableBool::True`.

Queste proprietà configurano i metadati di correzione utilizzati da PowerPoint e da altre applicazioni di presentazione. Aspose.Slides non le usa per eseguire controlli ortografici basati su dizionario né per restituire un elenco di parole errate.

L'esempio completo seguente crea una presentazione di ingresso, la carica, assegna impostazioni di controllo ortografico e lingue di correzione diverse a due porzioni nello stesso paragrafo, salva il risultato, lo riapre e verifica i valori memorizzati:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/joinportionswithsameformatting/) combina le porzioni adiacenti che hanno lo stesso formato. Una differenza solo in `SpellCheck` non mantiene separate tali porzioni; dopo la fusione, la porzione risultante conserva il valore `SpellCheck` della prima porzione. Se le porzioni richiedono impostazioni di controllo ortografico diverse, chiama `JoinPortionsWithSameFormatting` prima di assegnare tali impostazioni, oppure controlla i confini delle porzioni risultanti e riapplica le impostazioni in seguito. Le porzioni con valori `LanguageId` differenti rimangono separate perché il loro formato di lingua di correzione differisce.

## **FAQ**

**L'ID lingua traduce il testo?**

No. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/set_languageid/) memorizza metadati di correzione per ortografia e grammatica; non altera il contenuto del testo. Traduci il testo separatamente, quindi imposta l'identificatore di lingua appropriato per ogni porzione tradotta.

**La lingua di correzione controlla i caratteri, la sillabazione o l'andatura del testo?**

No. L'identificatore di lingua serve esclusivamente alla correzione. Il rendering e il layout del testo dipendono principalmente dai [font](/slides/it/cpp/powerpoint-fonts/) disponibili, dal sistema di scrittura e dalle impostazioni del riquadro di testo. Per un rendering affidabile, fornisci i font necessari, configura la [sostituzione dei font](/slides/it/cpp/font-substitution/) o [incorpora i font](/slides/it/cpp/embedded-font/) nella presentazione.

**Un paragrafo può usare più lingue di correzione?**

Sì. Assegna ogni lingua a una porzione separata, come mostrato nell'esempio del paragrafo multilingue.

**Devo usare `DefaultTextLanguage` o `LanguageId`?**

Utilizza [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) quando desideri un valore predefinito per il testo appena creato. Usa [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/set_languageid/) quando una specifica porzione necessita di una lingua di correzione esplicita o quando un paragrafo contiene più lingue.