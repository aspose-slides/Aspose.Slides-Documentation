---
title: Configura la sostituzione dei caratteri nelle presentazioni su Android
linktitle: Sostituzione dei caratteri
type: docs
weight: 70
url: /it/androidjava/font-substitution/
keywords:
- carattere
- carattere sostituto
- sostituzione dei caratteri
- sostituire il carattere
- sostituzione del carattere
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Configura le regole di sostituzione dei caratteri e ispeziona i caratteri sostituiti in Aspose.Slides per Android tramite Java durante il rendering o la conversione delle presentazioni."
---
## **Panoramica**

La sostituzione dei caratteri consente ad Aspose.Slides di utilizzare un carattere disponibile al posto di un carattere a cui non si può accedere quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il carattere assegnato al contenuto della presentazione.

È possibile definire il carattere da usare quando un carattere specifico non è disponibile e si possono esaminare le sostituzioni che Aspose.Slides eseguirà durante il rendering. Questo aiuta a mantenere l'output coerente tra i dispositivi Android e gli ambienti con caratteri disponibili diversi.

## **Ottenere le sostituzioni dei caratteri**

Utilizzare il metodo [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) per determinare quali caratteri saranno sostituiti quando la presentazione viene renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsubstitutioninfo/) che identificano i nomi del carattere originale e quello sostituito.

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

Utilizzare la sovraccarico [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) con un argomento `int[] slides` per esaminare solo le sostituzioni necessarie a renderizzare diapositive specifiche. Ciò è utile quando si renderizza o esporta una parte di una presentazione, si verifica una presentazione di grandi dimensioni in modo incrementale, si individuano diapositive che dipendono da caratteri non disponibili, si prepara un pacchetto di caratteri minimo per un'app Android o si diagnosticano differenze di rendering senza elaborare diapositive non correlate.

L'array `slides` contiene indici diapositive basati su 1: `1` identifica la prima diapositiva. Al contrario, l'accessore della collezione [Presentation.getSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlides--) utilizza un indice basato su 0, quindi la stessa diapositiva viene acceduta come `presentation.getSlides().get_Item(0)`. Tenere presente questa differenza quando si costruisce l'array per evitare errori di off‑by‑one.

Chiamare la sovraccarico tramite il metodo [Presentation.getFontsManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getFontsManager--) . Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsubstitutioninfo/) contenente i nomi del carattere originale e di quello sostituito. Il risultato riflette l'ambiente dei caratteri corrente, le regole di fallback configurate, le regole di sostituzione memorizzate in una [IFontSubstRuleCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontsubstrulecollection/), e i [caratteri caricati esternamente](/slides/it/androidjava/custom-font/).

La stessa sostituzione può essere richiesta da più di una diapositiva selezionata. Rimuovere i duplicati dai risultati quando si crea un inventario dei caratteri o un rapporto di preflight. Il seguente esempio riporta ogni sostituzione restituita e quindi crea un elenco ordinato di mappature di caratteri uniche:

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

L'interfaccia [IFontsManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontsmanager/) fornisce entrambe le sovraccarichi. Sceglierne una in base all'ambito dell'operazione di rendering:

| Sovraccarico | Usalo quando |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) senza argomenti | Hai bisogno delle sostituzioni per l'intera presentazione. |
| [getSubstitutions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) con `int[] slides` | Hai bisogno delle sostituzioni per un intervallo selezionato, un controllo incrementale o un'esportazione parziale. |

## **Impostare le regole di sostituzione dei caratteri**

Per specificare il carattere che Aspose.Slides deve utilizzare quando un carattere sorgente non è disponibile:

1. Caricare la presentazione.  
2. Creare le definizioni dei caratteri per i caratteri sorgente e di sostituzione.  
3. Creare una [FontSubstRule](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsubstcondition/).  
4. Aggiungere la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsubstrulecollection/).  
5. Assegnare la collezione utilizzando il metodo [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Renderizzare o convertire la presentazione.

Il seguente esempio Java sostituisce `Arial` con `SomeRareFont` quando `SomeRareFont` non è disponibile, quindi renderizza la prima diapositiva per verificare il risultato. Il carattere di sostituzione deve essere disponibile per Aspose.Slides.

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

Per una modifica incondizionata dei caratteri utilizzati in tutta la presentazione, vedere [Sostituzione dei caratteri](/slides/it/androidjava/font-replacement/).

{{% /alert %}}

## **Limitazioni per i caratteri delle equazioni matematiche**

Le regole di sostituzione dei caratteri fanno parte del processo standard di selezione dei caratteri utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un carattere inaccessibile con il carattere disponibile specificato da una regola.

Le equazioni di Office Math hanno un requisito aggiuntivo. Se un'equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel carattere esatto per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro carattere matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo e il rendering potrebbe comunque segnalare che **Cambria Math** è richiesto.

Per renderizzare o convertire una presentazione di questo tipo, rendere **Cambria Math** disponibile ad Aspose.Slides. Caricarlo come [carattere esterno](/slides/it/androidjava/custom-font/) affinché l'applicazione possa usarlo durante il rendering e la conversione.

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra continuano a valere per il testo regolare della presentazione.

## **FAQ**

**Qual è la differenza tra sostituzione dei caratteri e sostituzione dei caratteri?**

[Font replacement](/slides/it/androidjava/font-replacement/) modifica intenzionalmente un carattere con un altro in tutta la presentazione. La sostituzione dei caratteri seleziona un carattere per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il carattere originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**

Le regole partecipano alla [sequenza di selezione dei caratteri](/slides/it/androidjava/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola viene usata solo quando Aspose.Slides non può accedere al carattere sorgente.

**Cosa succede quando un carattere manca e nessuna regola di sostituzione è configurata?**

Aspose.Slides seleziona il carattere disponibile più vicino secondo il suo processo di selezione. Il risultato dipende dai caratteri disponibili nell'ambiente di runtime.

**Posso caricare caratteri esterni per evitare la sostituzione?**

Sì. È possibile [caricare caratteri esterni](/slides/it/androidjava/custom-font/) affinché Aspose.Slides li utilizzi durante il rendering e la conversione.

**Aspose distribuisce i caratteri con la libreria?**

No. È responsabilità dell'utente fornire i caratteri e rispettare le relative licenze.

**I risultati della sostituzione possono differire tra dispositivi Android?**

Sì. I caratteri di sistema disponibili possono variare tra versioni Android, dispositivi e produttori, quindi un carattere disponibile in un ambiente potrebbe richiedere una sostituzione in un altro.

**Come posso rendere la selezione dei caratteri coerente tra i dispositivi Android?**

Pacchettizzare gli stessi file di caratteri richiesti con l'applicazione, [caricarli come caratteri esterni](/slides/it/androidjava/custom-font/) e [incorporare i caratteri](/slides/it/androidjava/embedded-font/) quando le licenze lo consentono. È inoltre possibile chiamare [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) prima dell'esportazione per identificare eventuali sostituzioni inattese.