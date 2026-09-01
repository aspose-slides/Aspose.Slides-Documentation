---
title: Automatizza la localizzazione delle presentazioni in PHP
linktitle: Localizzazione delle presentazioni
type: docs
weight: 100
url: /it/php-java/presentation-localization/
keywords:
- cambio lingua
- controllo ortografico
- sopprimere controllo ortografico
- lingua di revisione
- ID lingua
- testo multilingue
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Imposta le lingue di revisione per il testo delle presentazioni PowerPoint e OpenDocument in PHP con Aspose.Slides, inclusi i valori predefiniti e i paragrafi multilingue."
---
## **Panoramica**

Aspose.Slides per PHP tramite Java consente di configurare i metadati di revisione per singole porzioni di testo. Usa [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLanguageId) per identificare la lingua di revisione, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setSpellCheck) per consentire o sopprimere i controlli ortografici e [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setProofDisabled) per controllare lo stato più ampio di nessuna revisione. Poiché queste impostazioni vengono applicate a livello di porzione, un paragrafo può contenere più lingue e diverse regole di revisione.

Questo articolo spiega come assegnare una lingua a testo specifico, impostare la lingua predefinita per il nuovo testo con [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), creare paragrafi multilingue, scegliere tra `SpellCheck` e `ProofDisabled` e conservare le impostazioni desiderate quando si utilizza [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Queste proprietà memorizzano i metadati per le applicazioni di presentazione; non traducono il testo, non eseguono il controllo ortografico basato su dizionario né restituiscono parole errate.

## **Imposta la lingua di revisione per il testo**

Crea o carica una [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/), accedi alla porzione di testo necessaria tramite [Portion::getPortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#getPortionFormat), e assegna il suo identificatore di lingua. L'esempio seguente crea una forma, imposta l'inglese britannico come lingua di revisione e salva il risultato con [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Imposta la lingua predefinita per il nuovo testo**

Usa [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) per specificare la lingua di revisione che Aspose.Slides assegna al testo appena creato. Questa impostazione è utile quando la maggior parte o tutto il nuovo testo in una presentazione utilizza la stessa lingua. Non modifica i metadati della lingua del testo che ha già una lingua esplicita.

L'esempio seguente crea una presentazione il cui nuovo testo utilizza le regole di revisione tedesche:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Usa più lingue in un singolo paragrafo**

Un [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/) contiene una collezione di porzioni di testo. Crea una [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) separata per ogni lingua e imposta il suo `LanguageId` in modo indipendente.

L'esempio crea un paragrafo con porzioni in inglese e francese:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Abilita o sopprimi il controllo ortografico per singole porzioni**

[PortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/portionformat/) eredita le proprietà di testo comuni definite da [BasePortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/). Accedi al formato di una porzione tramite [Portion::getPortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#getPortionFormat) e usa [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setSpellCheck) per controllare se un'applicazione di presentazione può verificare l'ortografia per quella porzione. Il valore predefinito è `false`: `true` consente il controllo ortografico, mentre `false` lo sopprime.

L'impostazione si applica a singole porzioni di testo. Diverse porzioni nello stesso paragrafo possono quindi usare valori diversi. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLanguageId) e `setSpellCheck` hanno scopi complementari: `setLanguageId` identifica la lingua di revisione, mentre `setSpellCheck` determina se i controlli ortografici sono consentiti per la porzione.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setProofDisabled) controlla anche la revisione, ma rappresenta lo stato più ampio di "non revisionare" come un [NullableBool](https://reference.aspose.com/slides/it/php-java/aspose.slides/nullablebool/). Usa `setSpellCheck` quando ti serve un interruttore booleano diretto specifico per i controlli ortografici. Usa `setProofDisabled` quando devi conservare o controllare esplicitamente i metadati di non revisione della presentazione, incluso il suo stato `NotDefined`. Se imposti entrambe le proprietà, mantieni i loro valori coerenti; non combinare `setSpellCheck(true)` con `setProofDisabled(NullableBool::True)`.

Queste proprietà configurano i metadati di revisione usati da PowerPoint e altre applicazioni di presentazione. Aspose.Slides non le utilizza per eseguire il controllo ortografico basato su dizionario o per restituire un elenco di parole errate.

L'esempio completo seguente crea una presentazione di input, la carica, assegna impostazioni di controllo ortografico e lingue di revisione diverse a due porzioni nello stesso paragrafo, salva il risultato, lo riapre e verifica i valori memorizzati:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) combina le porzioni adiacenti che hanno la stessa formattazione. Una differenza solo in `SpellCheck` non mantiene tali porzioni separate; dopo la fusione, la porzione risultante mantiene il valore `SpellCheck` della prima porzione. Se le porzioni necessitano di impostazioni di controllo ortografico diverse, chiama `joinPortionsWithSameFormatting` prima di assegnare tali impostazioni, oppure ispeziona i confini delle porzioni risultanti e riapplica le impostazioni in seguito. Le porzioni con valori `LanguageId` diversi rimangono separate poiché la loro formattazione della lingua di revisione differisce.

## **FAQ**

**Un ID lingua traduce il testo?**

No. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLanguageId) memorizza i metadati di revisione per ortografia e grammatica; non modifica il contenuto del testo. Traduci il testo separatamente, quindi imposta l'identificatore di lingua appropriato per ogni porzione tradotta.

**Controlla la lingua di revisione i caratteri, la sillabazione o l'interruzione di riga?**

No. L'identificatore di lingua è destinato alla revisione. Rendering e layout del testo dipendono principalmente dai [fonts](/slides/it/php-java/powerpoint-fonts/) disponibili, dal sistema di scrittura e dalle impostazioni del riquadro di testo. Per un rendering affidabile, fornisci i font necessari, configura la [font substitution](/slides/it/php-java/font-substitution/) o [embed fonts](/slides/it/php-java/embedded-font/) nella presentazione.

**Un paragrafo può utilizzare più lingue di revisione?**

Sì. Assegna ogni lingua a una porzione separata, come mostrato nell'esempio del paragrafo multilingue.

**Devo usare `setDefaultTextLanguage` o `setLanguageId`?**

Usa [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) quando vuoi un valore predefinito per il testo appena creato. Usa [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLanguageId) quando una specifica porzione necessita di una lingua di revisione esplicita o quando un paragrafo contiene più lingue.