---
title: Configura la sostituzione dei font nelle presentazioni usando Java
linktitle: Sostituzione dei font
type: docs
weight: 70
url: /it/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Configura le regole di sostituzione dei font e ispeziona i font sostituiti in Aspose.Slides per Java durante il rendering o la conversione di presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

La sostituzione dei font consente ad Aspose.Slides di utilizzare un font disponibile al posto di un font a cui non è possibile accedere quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il font assegnato al contenuto della presentazione.

È possibile definire il font da utilizzare quando un determinato font non è disponibile e si possono ispezionare le sostituzioni che Aspose.Slides effettuerà durante il rendering. Ciò aiuta a mantenere l'output coerente tra ambienti con diversi font installati.

## **Recuperare le sostituzioni dei font**

Utilizzare il metodo [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) per determinare quali font verranno sostituiti quando la presentazione viene renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsubstitutioninfo/) che identificano i nomi del font originale e del font sostituito.

Il seguente esempio Java elenca tutte le sostituzioni dei font per una presentazione:

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

## **Recuperare le sostituzioni dei font per le diapositive selezionate**

Utilizzare la sovraccarico [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) con un argomento `int[] slides` per ispezionare solo le sostituzioni necessarie a renderizzare diapositive specifiche. Questo è utile quando si sta renderizzando o esportando una parte di una presentazione, controllando una presentazione di grandi dimensioni in modo incrementale, individuando diapositive che dipendono da font non disponibili, preparando un pacchetto di font minimo per un server o container, o diagnosticando differenze di rendering senza elaborare diapositive non pertinenti.

L'array `slides` contiene indici diapositive basati su 1: `1` identifica la prima diapositiva. Al contrario, il metodo di accesso alla collezione [Presentation.getSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSlides--) utilizza indicizzazione basata su 0, quindi la stessa diapositiva viene acceduta come `presentation.getSlides().get_Item(0)`. Tenere presente questa differenza quando si costruisce l'array per evitare errori di offset.

Invocare la sovraccarico tramite il metodo [Presentation.getFontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getFontsManager--). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsubstitutioninfo/) che contiene i nomi del font originale e del font sostituito. Il risultato riflette l'ambiente font corrente, le regole di fallback configurate, le regole di sostituzione memorizzate in una [IFontSubstRuleCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsubstrulecollection/) e i [font caricati esternamente](/slides/it/java/custom-font/).

La stessa sostituzione può essere richiesta da più di una diapositiva selezionata. Eliminare i duplicati dei risultati quando si crea un inventario dei font o un report di preflight. Il seguente esempio mostra ogni sostituzione restituita e quindi crea un elenco ordinato di mappature di font uniche:

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

L'interfaccia [IFontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/) fornisce entrambe le sovraccarichi. Scegliere una in base all'ambito dell'operazione di rendering:

| Sovraccarico | Quando usarlo |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Hai bisogno di sostituzioni per l'intera presentazione. |
| [getSubstitutions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Hai bisogno di sostituzioni per un intervallo selezionato, controllo incrementale o esportazione parziale. |

## **Impostare le regole di sostituzione dei font**

Per specificare il font che Aspose.Slides deve utilizzare quando un font di origine non è disponibile:

1. Caricare la presentazione.
2. Creare definizioni di font per il font di origine e per il font sostitutivo.
3. Creare una [FontSubstRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsubstcondition/).
4. Aggiungere la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsubstrulecollection/).
5. Assegnare la collezione utilizzando il metodo [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Renderizzare o convertire la presentazione.

Il seguente esempio Java sostituisce `Arial` al posto di `SomeRareFont` quando `SomeRareFont` non è disponibile, e poi renderizza la prima diapositiva per verificare il risultato. Il font sostitutivo deve essere disponibile per Aspose.Slides.

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
Per una modifica incondizionata dei font utilizzati in tutta la presentazione, vedere [Sostituzione dei font](/slides/it/java/font-replacement/).
{{% /alert %}}

## **Limitazioni per i font delle equazioni matematiche**

Le regole di sostituzione dei font fanno parte del processo standard di selezione dei font utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un font inaccessibile con il font disponibile specificato da una regola.

Le equazioni Office Math hanno un requisito aggiuntivo. Se un'equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel font esatto per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro font matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo, e il rendering potrebbe comunque segnalare che **Cambria Math** è necessario.

Per renderizzare o convertire una tale presentazione, rendere **Cambria Math** disponibile per Aspose.Slides. Installarlo nel sistema operativo o caricarlo come [font esterno](/slides/it/java/custom-font/).

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra continuano ad applicarsi al testo normale della presentazione.

## **FAQ**

**Qual è la differenza tra font replacement e font substitution?**

[Font replacement](/slides/it/java/font-replacement/) modifica intenzionalmente un font con un altro in tutta la presentazione. La sostituzione dei font seleziona un font per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il font originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**

Le regole partecipano alla [sequenza di selezione dei font](/slides/it/java/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola viene utilizzata solo quando Aspose.Slides non può accedere al font di origine.

**Cosa succede quando un font è mancante e nessuna regola di sostituzione è configurata?**

Aspose.Slides seleziona il font disponibile più vicino in base al suo processo di selezione dei font. Il risultato dipende dai font disponibili nell'ambiente di runtime.

**Posso caricare font esterni per evitare la sostituzione?**

Sì. È possibile [caricare font esterni](/slides/it/java/custom-font/) affinché Aspose.Slides li utilizzi durante il rendering e la conversione.

**Aspose distribuisce font con la libreria?**

No. Sei responsabile di fornire i font e di rispettare le loro licenze.

**I risultati di sostituzione possono differire tra Windows, Linux e macOS?**

Sì. I font installati e i percorsi di ricerca dei font differiscono a seconda del sistema operativo, quindi un font disponibile su una macchina può richiedere una sostituzione su un'altra.

**Come posso rendere la selezione dei font coerente nelle conversioni batch?**

Utilizzare gli stessi file e versioni dei font su ogni macchina o container, [caricare i font esterni richiesti](/slides/it/java/custom-font/) e [incorporare i font](/slides/it/java/embedded-font/) quando le licenze lo consentono. È inoltre possibile chiamare [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) prima dell'esportazione per identificare sostituzioni inattese.