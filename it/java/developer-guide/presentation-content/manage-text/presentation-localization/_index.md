---
title: Automatizza la localizzazione delle presentazioni in Java
linktitle: Localizzazione della presentazione
type: docs
weight: 100
url: /it/java/presentation-localization/
keywords:
- cambia lingua
- controllo ortografico
- sopprimi controllo ortografico
- lingua di correzione
- ID lingua
- testo multilingue
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Imposta le lingue di correzione per il testo delle presentazioni PowerPoint e OpenDocument in Java con Aspose.Slides, includendo i valori predefiniti e i paragrafi multilingue."
---
## **Panoramica**

Aspose.Slides per Java ti consente di configurare i metadati di correzione per singole porzioni di testo. Usa [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) per identificare la lingua di correzione, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) per consentire o sopprimere i controlli ortografici e [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) per gestire lo stato più ampio “non correggere”. Poiché queste impostazioni sono applicate a livello di porzione, un paragrafo può contenere più lingue e regole di correzione differenti.

Questo articolo spiega come assegnare una lingua a un testo specifico, impostare la lingua predefinita per il nuovo testo con [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), creare paragrafi multilingue, scegliere tra `SpellCheck` e `ProofDisabled` e conservare le impostazioni desiderate quando si utilizza [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Queste proprietà memorizzano metadati per le applicazioni di presentazione; non traducono il testo, non eseguono controlli ortografici basati su dizionario né restituiscono parole errate.

## **Imposta la lingua di correzione per il testo**

Crea o carica una [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/), accedi alla porzione di testo necessaria tramite [IPortion.getPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/#getPortionFormat--), e assegna il suo identificatore di lingua. L’esempio seguente crea una forma, imposta l’inglese britannico come lingua di correzione e salva il risultato con [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la lingua predefinita per il nuovo testo**

Usa [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) per specificare la lingua di correzione che Aspose.Slides assegna al testo appena creato. Questa impostazione è utile quando la maggior parte o tutto il nuovo testo di una presentazione utilizza la stessa lingua. Non modifica i metadati di lingua del testo che ha già una lingua esplicita.

L’esempio seguente crea una presentazione il cui nuovo testo utilizza le regole di correzione tedesche:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utilizza più lingue in un singolo paragrafo**

Un [IParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/) contiene una raccolta di porzioni di testo. Crea una [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/) separata per ogni lingua e imposta il suo `LanguageId` in modo indipendente.

Questo esempio crea un paragrafo con porzioni in inglese e francese:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Abilita o sopprimi il controllo ortografico per porzioni individuali**

[IPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportionformat/) eredita le proprietà comuni del testo definite da [IBasePortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/). Accedi al formato di una porzione tramite [IPortion.getPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/#getPortionFormat--) e usa [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) per controllare se un’applicazione di presentazione può verificare l’ortografia per quella porzione. Il valore predefinito è `false`: `true` consente il controllo ortografico, mentre `false` lo sopprime.

L’impostazione si applica a singole porzioni di testo. Porzioni diverse nello stesso paragrafo possono quindi avere valori diversi. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) e `setSpellCheck` hanno scopi complementari: `setLanguageId` identifica la lingua di correzione, mentre `setSpellCheck` determina se i controlli ortografici sono consentiti per la porzione.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) controlla anch’esso la correzione, ma rappresenta lo stato più ampio “non correggere” come un [NullableBool](https://reference.aspose.com/slides/it/java/com.aspose.slides/nullablebool/). Usa `setSpellCheck` quando ti serve un interruttore booleano diretto per i controlli ortografici. Usa `setProofDisabled` quando devi preservare o controllare esplicitamente i metadati “non correggere” della presentazione, incluso lo stato `NotDefined`. Se imposti entrambe le proprietà, mantieni i valori coerenti; non combinare `setSpellCheck(true)` con `setProofDisabled(NullableBool.True)`.

Queste proprietà configurano i metadati di correzione utilizzati da PowerPoint e da altre applicazioni di presentazione. Aspose.Slides non li usa per eseguire controlli ortografici basati su dizionario né per restituire un elenco di parole errate.

L’esempio completo seguente crea una presentazione di input, la carica, assegna impostazioni di controllo ortografico e lingue di correzione diverse a due porzioni nello stesso paragrafo, salva il risultato, lo riapre e verifica i valori memorizzati:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 && 
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) && 
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 && 
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) && 
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) combina le porzioni adiacenti che hanno la stessa formattazione. Una differenza solo in `SpellCheck` non mantiene le porzioni separate; dopo la fusione, la porzione risultante conserva il valore `SpellCheck` della prima porzione. Se le porzioni necessitano di impostazioni di controllo ortografico diverse, chiama `joinPortionsWithSameFormatting` prima di assegnare tali impostazioni, oppure ispeziona i confini delle porzioni risultanti e riapplica le impostazioni successivamente. Le porzioni con valori `LanguageId` diversi rimangono separate perché la formattazione della lingua di correzione differisce.

## **FAQ**

**Un ID lingua traduce il testo?**

No. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) memorizza metadati di correzione per ortografia e grammatica; non altera il contenuto del testo. Traduci il testo separatamente, quindi imposta l’identificatore di lingua appropriato per ogni porzione tradotta.

**La lingua di correzione controlla i font, la sillabazione o l’interlinea?**

No. L’identificatore di lingua è solo per la correzione. Il rendering del testo e il layout dipendono principalmente dai [font](/slides/it/java/powerpoint-fonts/), dal sistema di scrittura e dalle impostazioni del riquadro di testo. Per un rendering affidabile, fornisci i font necessari, configura la [sostituzione del font](/slides/it/java/font-substitution/) o [incorpora i font](/slides/it/java/embedded-font/) nella presentazione.

**Un paragrafo può usare più lingue di correzione?**

Sì. Assegna ogni lingua a una porzione separata, come mostrato nell’esempio del paragrafo multilingue.

**Devo usare `setDefaultTextLanguage` o `setLanguageId`?**

Usa [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) quando desideri un valore predefinito per il testo appena creato. Usa [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) quando una porzione specifica necessita di una lingua di correzione esplicita o quando un paragrafo contiene più lingue.