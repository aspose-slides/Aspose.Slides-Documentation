---
title: Automatizzare la localizzazione della presentazione in JavaScript
linktitle: Localizzazione della presentazione
type: docs
weight: 100
url: /it/nodejs-java/presentation-localization/
keywords:
- cambiare lingua
- controllo ortografico
- sopprimere controllo ortografico
- lingua di correzione
- ID lingua
- testo multilingue
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Imposta le lingue di correzione per il testo delle presentazioni PowerPoint e OpenDocument in JavaScript con Aspose.Slides, includendo valori predefiniti e paragrafi multilingue."
---
## **Panoramica**

Aspose.Slides per Node.js tramite Java consente di configurare i metadati di correzione per singole porzioni di testo. Utilizza [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) per identificare la lingua di correzione, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) per consentire o sopprimere i controlli ortografici e [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) per controllare lo stato più ampio di nessuna correzione. Poiché queste impostazioni vengono applicate a livello di porzione, un paragrafo può contenere più lingue e diverse regole di correzione.

Questo articolo spiega come assegnare una lingua a testo specifico, impostare la lingua predefinita per nuovo testo con [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), creare paragrafi multilingue, scegliere tra `SpellCheck` e `ProofDisabled` e preservare le impostazioni desiderate quando si utilizza [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). Queste proprietà memorizzano i metadati per le applicazioni di presentazione; non traducono il testo, non eseguono controlli ortografici basati su dizionario e non restituiscono parole errate.

## **Imposta la lingua di correzione per il testo**

Crea o carica una [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/), accedi alla porzione di testo necessaria tramite [Portion.getPortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/#getPortionFormat--), e assegna il suo identificatore di lingua. Il seguente esempio crea una forma, imposta l'inglese britannico come lingua di correzione e salva il risultato con [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la lingua predefinita per il nuovo testo**

Utilizza [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) per specificare la lingua di correzione che Aspose.Slides assegna al testo appena creato. Questa impostazione è utile quando la maggior parte o tutto il nuovo testo in una presentazione utilizza la stessa lingua. Non modifica i metadati della lingua del testo che già ha una lingua esplicita.

Il seguente esempio crea una presentazione il cui nuovo testo utilizza le regole di correzione tedesche:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utilizza più lingue in un paragrafo**

Un [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) contiene una collezione di porzioni di testo. Crea una [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) separata per ogni lingua e imposta il suo `LanguageId` in modo indipendente.

Questo esempio crea un paragrafo con porzioni in inglese e francese:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Abilita o sopprimi il controllo ortografico per singole porzioni**

[PortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/) eredita le proprietà di testo comuni definite da [BasePortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/). Accedi al formato di una porzione tramite [Portion.getPortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/#getPortionFormat--) e utilizza [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) per controllare se un'applicazione di presentazione può verificare l'ortografia per quella porzione. Il valore predefinito è `false`: `true` consente il controllo ortografico, mentre `false` lo sopprime.

L'impostazione si applica a singole porzioni di testo. Porzioni diverse nello stesso paragrafo possono quindi utilizzare valori differenti. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) e `setSpellCheck` hanno scopi complementari: `setLanguageId` identifica la lingua di correzione, mentre `setSpellCheck` determina se i controlli ortografici sono consentiti per la porzione.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) controlla anche la correzione, ma rappresenta lo stato più ampio di "non correggere" come un [NullableBool](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/nullablebool/). Usa `setSpellCheck` quando hai bisogno di un interruttore booleano diretto specificamente per i controlli ortografici. Usa `setProofDisabled` quando devi conservare o controllare esplicitamente i metadati di non correzione della presentazione, incluso lo stato `NotDefined`. Se imposti entrambe le proprietà, mantieni coerenti i loro valori; non combinare `setSpellCheck(true)` con `setProofDisabled(NullableBool.True)`.

Queste proprietà configurano i metadati di correzione utilizzati da PowerPoint e altre applicazioni di presentazione. Aspose.Slides non le utilizza per eseguire controlli ortografici basati su dizionario o per restituire un elenco di parole errate.

Il seguente esempio completo crea una presentazione di input, la carica, assegna impostazioni di controllo ortografico e lingue di correzione differenti a due porzioni nello stesso paragrafo, salva il risultato, lo riapre e verifica i valori memorizzati:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) combina le porzioni adiacenti che hanno lo stesso formato. Una differenza solo in `SpellCheck` non mantiene tali porzioni separate; dopo che sono state unite, la porzione risultante mantiene il valore `SpellCheck` della prima porzione. Se le porzioni necessitano di impostazioni di controllo ortografico differenti, chiama `joinPortionsWithSameFormatting` prima di assegnare quelle impostazioni, oppure ispeziona i confini delle porzioni risultanti e riapplica le impostazioni successivamente. Le porzioni con valori `LanguageId` differenti rimangono separate perché il loro formato di lingua di correzione differisce.

## **FAQ**

**L'ID lingua traduce il testo?**

No. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) memorizza i metadati di correzione per ortografia e grammatica; non altera il contenuto del testo. Traduci il testo separatamente, quindi imposta l'identificatore di lingua appropriato per ciascuna porzione tradotta.

**La lingua di correzione controlla i caratteri, la sillabazione o l'interruzione di riga?**

No. L'identificatore della lingua è destinato alla correzione. Il rendering del testo e il layout dipendono principalmente dai [fonts](/slides/it/nodejs-java/powerpoint-fonts/) disponibili, dal sistema di scrittura e dalle impostazioni del riquadro di testo. Per un rendering affidabile, fornisci i font necessari, configura la [font substitution](/slides/it/nodejs-java/font-substitution/) o [embed fonts](/slides/it/nodejs-java/embedded-font/) nella presentazione.

**Un paragrafo può usare più lingue di correzione?**

Sì. Assegna ogni lingua a una porzione separata, come mostrato nell'esempio del paragrafo multilingue.

**Devo usare `setDefaultTextLanguage` o `setLanguageId`?**

Utilizza [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) quando desideri un valore predefinito per il testo appena creato. Utilizza [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) quando una specifica porzione necessita di una lingua di correzione esplicita o quando un paragrafo contiene più lingue.