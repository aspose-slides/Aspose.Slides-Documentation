---
title: Automatizza la localizzazione delle presentazioni su Android
linktitle: Localizzazione della presentazione
type: docs
weight: 100
url: /it/androidjava/presentation-localization/
keywords:
- cambio lingua
- controllo ortografico
- sopprimere controllo ortografico
- lingua di revisione
- ID lingua
- testo multilingue
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Imposta le lingue di revisione per il testo delle presentazioni PowerPoint e OpenDocument su Android con Aspose.Slides per Android via Java, includendo impostazioni predefinite e paragrafi multilingue."
---
## **Panoramica**

Aspose.Slides for Android via Java consente di configurare i metadati di revisione per singole porzioni di testo. Utilizza [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) per identificare la lingua di revisione, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) per consentire o sopprimere i controlli ortografici e [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) per controllare lo stato più ampio “non revisionare”. Poiché queste impostazioni vengono applicate a livello di porzione, un paragrafo può contenere più lingue e regole di revisione differenti.

Questo articolo spiega come assegnare una lingua a testo specifico, impostare la lingua predefinita per il nuovo testo con [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), creare paragrafi multilingue, scegliere tra `SpellCheck` e `ProofDisabled` e conservare le impostazioni desiderate quando si utilizza [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Queste proprietà memorizzano i metadati per le applicazioni di presentazione; non traducono il testo, non eseguono il controllo ortografico basato su dizionario e non restituiscono parole errate.

## **Imposta la lingua di revisione per il testo**

Crea o carica una [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/), accedi alla porzione di testo necessaria tramite [IPortion.getPortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/#getPortionFormat--), e assegna il suo identificatore di lingua. L'esempio seguente crea una forma, imposta l'inglese britannico come lingua di revisione e salva il risultato con [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

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

Utilizza [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) per specificare la lingua di revisione che Aspose.Slides assegna al testo appena creato. Questa impostazione è utile quando la maggior parte o tutto il nuovo testo in una presentazione utilizza la stessa lingua. Non modifica i metadati della lingua del testo che ha già una lingua esplicita.

L'esempio seguente crea una presentazione il cui nuovo testo utilizza le regole di revisione tedesche:

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

## **Utilizza più lingue in un unico paragrafo**

Un [IParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/) contiene una collezione di porzioni di testo. Crea una [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/) separata per ogni lingua e imposta il suo `LanguageId` in modo indipendente.

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

## **Abilita o sopprimi il controllo ortografico per singole porzioni**

[IPortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportionformat/) eredita le proprietà di testo comuni definite da [IBasePortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/). Accedi al formato di una porzione tramite [IPortion.getPortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/#getPortionFormat--) e utilizza [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) per controllare se un'applicazione di presentazione può effettuare il controllo ortografico per quella porzione. Il valore predefinito è `false`: `true` consente il controllo ortografico, mentre `false` lo sopprime.

L'impostazione si applica a singole porzioni di testo. Porzioni diverse nello stesso paragrafo possono quindi usare valori differenti. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) e `setSpellCheck` hanno scopi complementari: `setLanguageId` identifica la lingua di revisione, mentre `setSpellCheck` determina se i controlli ortografici sono consentiti per la porzione.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) controlla anche la revisione, ma rappresenta lo stato più ampio “non revisionare” come un [NullableBool](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/nullablebool/). Usa `setSpellCheck` quando ti serve un interruttore booleano diretto specifico per i controlli ortografici. Usa `setProofDisabled` quando devi preservare o controllare esplicitamente i metadati “no proof” della presentazione, incluso lo stato `NotDefined`. Se imposti entrambe le proprietà, mantieni i valori coerenti; non combinare `setSpellCheck(true)` con `setProofDisabled(NullableBool.True)`.

Queste proprietà configurano i metadati di revisione utilizzati da PowerPoint e altre applicazioni di presentazione. Aspose.Slides non le usa per eseguire il controllo ortografico basato su dizionario né per restituire un elenco di parole errate.

L'esempio completo seguente crea una presentazione di input, la carica, assegna impostazioni di controllo ortografico e lingue di revisione diverse a due porzioni nello stesso paragrafo, salva il risultato, lo riapre e verifica i valori memorizzati:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) combina porzioni adiacenti che hanno la stessa formattazione. Una differenza in `SpellCheck` da sola non mantiene tali porzioni separate; dopo che sono state unite, la porzione risultante conserva il valore `SpellCheck` della prima porzione. Se le porzioni necessitano di impostazioni di controllo ortografico diverse, chiama `joinPortionsWithSameFormatting` prima di assegnare tali impostazioni, oppure ispeziona i confini della porzione risultante e riapplica le impostazioni in seguito. Le porzioni con valori `LanguageId` diversi rimangono separate perché la formattazione della lingua di revisione differisce.

## **FAQ**

**L'ID lingua traduce il testo?**

No. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) memorizza i metadati di revisione per ortografia e grammatica; non altera il contenuto del testo. Traduci il testo separatamente, quindi imposta l'identificatore di lingua appropriato per ogni porzione tradotta.

**La lingua di revisione controlla caratteri, sillabazione o interlinea?**

No. L'identificatore della lingua è destinato alla revisione. Il rendering del testo e il layout dipendono principalmente dai [font](/slides/it/androidjava/powerpoint-fonts/), dal sistema di scrittura e dalle impostazioni del riquadro di testo. Per un rendering affidabile, fornisci i font necessari, configura la [sostituzione dei font](/slides/it/androidjava/font-substitution/) o [incorpora i font](/slides/it/androidjava/embedded-font/) nella presentazione.

**Un paragrafo può usare più lingue di revisione?**

Sì. Assegna ogni lingua a una porzione separata, come mostrato nell'esempio del paragrafo multilingue.

**Devo usare `setDefaultTextLanguage` o `setLanguageId`?**

Usa [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) quando desideri un valore predefinito per il testo appena creato. Usa [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) quando una specifica porzione necessita di una lingua di revisione esplicita o quando un paragrafo contiene più lingue.