---
title: Configura la sostituzione dei caratteri nelle presentazioni usando Java
linktitle: Sostituzione dei caratteri
type: docs
weight: 70
url: /it/java/font-substitution/
keywords:
- carattere
- carattere sostituito
- sostituzione del carattere
- sostituire il carattere
- sostituzione del carattere
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Configura le regole di sostituzione dei caratteri e ispeziona i caratteri sostituiti in Aspose.Slides per Java durante il rendering o la conversione di presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

La sostituzione dei caratteri consente a Aspose.Slides di utilizzare un carattere disponibile al posto di un carattere che non può essere accesso quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il carattere assegnato al contenuto della presentazione.

È possibile definire il carattere da utilizzare quando un determinato carattere non è disponibile e ispezionare le sostituzioni che Aspose.Slides effettuerà durante il rendering. Questo aiuta a mantenere l'output coerente tra ambienti con diversi caratteri installati.

Se un carattere è disponibile ma non ha un alfabeto grassetto dedicato, vedere [Gestire i caratteri senza un alfabeto grassetto dedicato](/slides/it/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Quella sezione spiega come rasterizzare il testo interessato durante l'esportazione PDF e le conseguenze per la selezione del testo, la ricerca e la scalatura.

## **Ottenere le sostituzioni dei caratteri**

Utilizzare il metodo [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) per determinare quali caratteri verranno sostituiti quando la presentazione è renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) che identificano i nomi dei caratteri originali e sostituiti.

Il seguente esempio Java elenca tutte le sostituzioni dei caratteri per una presentazione:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Ottenere le sostituzioni dei caratteri per le diapositive selezionate**

Utilizzare la sovraccarico [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) con un argomento `int[] slides` per ispezionare solo le sostituzioni necessarie a renderizzare diapositive specifiche. Questo è utile quando si renderizza o si esporta una parte di una presentazione, si verifica una presentazione di grandi dimensioni in modo incrementale, si individuano diapositive che dipendono da caratteri non disponibili, si prepara un pacchetto di caratteri minimo per un server o contenitore, o si diagnostica differenze di rendering senza elaborare diapositive non correlate.

L'array `slides` contiene indici delle diapositive basati su 1: `1` identifica la prima diapositiva. Al contrario, l'accessore di collezione [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) utilizza un indicizzamento basato su 0, quindi quella stessa diapositiva è accessibile come `presentation.getSlides().get_Item(0)`. Tenere presente questa differenza quando si costruisce l'array per evitare errori di scostamento di uno.

Chiamare la sovraccarico tramite il metodo [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) che contiene i nomi del carattere originale e di quello sostituito. Il risultato riflette l'ambiente dei caratteri corrente, le regole di fallback configurate e i [caratteri caricati esternamente](/slides/it/java/custom-font/). Le regole di sostituzione memorizzate in una [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) vengono applicate quando la presentazione è renderizzata, ma il risultato non le elenca; verificare i caratteri nel file di output.

La stessa sostituzione può essere richiesta da più di una diapositiva selezionata. Eliminare i duplicati dei risultati quando si crea un inventario dei caratteri o un rapporto di preflight. Il seguente esempio riporta ogni sostituzione restituita e poi crea un elenco ordinato di mapping di caratteri unici:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

L'interfaccia [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) fornisce entrambe le sovraccarichi. Scegliere quello più adatto all'ambito dell'operazione di rendering:

| Sovraccarico | Quando usarlo |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Hai bisogno delle sostituzioni per l'intera presentazione. |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Hai bisogno delle sostituzioni per un intervallo selezionato, verifica incrementale o esportazione parziale. |

## **Impostare le regole di sostituzione dei caratteri**

Per specificare il carattere che Aspose.Slides deve utilizzare quando un carattere sorgente non è disponibile:

1. Caricare la presentazione.
2. Creare definizioni di carattere per i caratteri sorgente e di sostituzione.
3. Creare una [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/).
4. Aggiungere la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/).
5. Assegnare la collezione usando il metodo [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Renderizzare o convertire la presentazione.

Il seguente esempio Java sostituisce `Arial` per `SomeRareFont` quando `SomeRareFont` non è disponibile, e quindi renderizza la prima diapositiva per verificare il risultato. Il carattere di sostituzione deve essere disponibile per Aspose.Slides.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Per una modifica incondizionata dei caratteri usati in tutta la presentazione, vedere [Sostituzione dei caratteri](/slides/it/java/font-replacement/).
{{% /alert %}}

## **Limitazioni per i caratteri delle equazioni matematiche**

Le regole di sostituzione dei caratteri fanno parte del processo standard di selezione dei caratteri utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un carattere non accessibile con il carattere disponibile specificato da una regola.

Le equazioni Office Math hanno un requisito aggiuntivo. Se un'equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel carattere esatto per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro carattere matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo, e il rendering potrebbe ancora segnalare che **Cambria Math** è necessario.

Per renderizzare o convertire una tale presentazione, rendere **Cambria Math** disponibile per Aspose.Slides. Installarlo nel sistema operativo o caricarlo come [carattere esterno](/slides/it/java/custom-font/).

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra si applicano ancora al testo della presentazione.

## **FAQ**

**Qual è la differenza tra la sostituzione dei caratteri e la sostituzione dei font?**

[Sostituzione dei caratteri](/slides/it/java/font-replacement/) cambia intenzionalmente un carattere con un altro in tutta la presentazione. La sostituzione dei caratteri seleziona un carattere per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il carattere originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**

Le regole partecipano alla [sequenza di selezione dei caratteri](/slides/it/java/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola è utilizzata solo quando Aspose.Slides non può accedere al carattere sorgente.

**Cosa succede quando un carattere è mancante e non è configurata alcuna regola di sostituzione?**

Aspose.Slides seleziona il carattere disponibile più vicino in base al suo processo di selezione dei caratteri. Il risultato dipende dai caratteri disponibili nell'ambiente di runtime.

**Posso caricare caratteri esterni per evitare la sostituzione?**

Sì. È possibile [caricare caratteri esterni](/slides/it/java/custom-font/) in modo che Aspose.Slides possa usarli durante il rendering e la conversione.

**Aspose distribuisce i caratteri con la libreria?**

No. Sei responsabile di fornire i caratteri e di rispettare le loro licenze.

**I risultati della sostituzione possono differire tra Windows, Linux e macOS?**

Sì. I caratteri installati e le posizioni di ricerca dei caratteri differiscono a seconda del sistema operativo, quindi un carattere disponibile su una macchina potrebbe richiedere una sostituzione su un'altra.

**Come posso rendere la selezione dei caratteri coerente nelle conversioni batch?**

Utilizzare gli stessi file di caratteri e versioni su ogni macchina o contenitore, [caricare i caratteri esterni richiesti](/slides/it/java/custom-font/), e [incorporare i caratteri](/slides/it/java/embedded-font/) quando le licenze lo consentono. È inoltre possibile chiamare [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) prima dell'esportazione per identificare sostituzioni inattese.