---
title: Configura la sostituzione dei font nelle presentazioni usando JavaScript
linktitle: Sostituzione dei font
type: docs
weight: 70
url: /it/nodejs-java/font-substitution/
keywords:
- font
- sostituzione del font
- sostituzione del font
- sostituisci font
- sostituzione del font
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Abilita una sostituzione ottimale dei font in Aspose.Slides per Node.js durante la conversione di presentazioni PowerPoint e OpenDocument in altri formati di file con JavaScript."
---
## **Panoramica**

La sostituzione dei font consente ad Aspose.Slides di utilizzare un altro font quando il font originale della presentazione non è disponibile durante il rendering o la conversione. È possibile verificare quali font sono stati sostituiti utilizzando il metodo `getSubstitutions` della classe `FontsManager`.

Aspose.Slides consente inoltre di definire regole di sostituzione dei font. Ad esempio, è possibile specificare che un font inaccessibile debba essere sostituito con un altro font disponibile e poi applicare tali regole tramite il gestore dei font della presentazione.

## **Impostare le regole di sostituzione dei font**

Aspose.Slides permette di impostare regole per i font che determinano cosa fare in determinate condizioni (ad esempio, quando un font non può essere accessibile) nel seguente modo:

1. Caricare la presentazione pertinente.
2. Caricare il font che verrà sostituito.
3. Caricare il nuovo font.
4. Aggiungere una regola per la sostituzione.
5. Aggiungere la regola alla raccolta delle regole di sostituzione dei font della presentazione.
6. Generare l'immagine della diapositiva per osservare l'effetto.

Questo codice JavaScript dimostra il processo di sostituzione dei font:

```javascript
// Carica una presentazione
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Carica il font sorgente che sarà sostituito
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Carica il nuovo font
    var destFont = new aspose.slides.FontData("Arial");
    // Aggiunge una regola di font per la sostituzione del font
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Aggiunge la regola alla collezione delle regole di sostituzione dei font
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Aggiunge la collezione di regole di font all'elenco delle regole
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // Il font Arial verrà usato al posto di SomeRareFont quando quest'ultimo è inaccessibile
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Salva l'immagine su disco nel formato JPEG
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Potresti voler vedere [**Font Replacement**](/slides/it/nodejs-java/font-replacement/).
{{% /alert %}}

## **Limitazioni per i font delle equazioni matematiche**

Le regole di sostituzione dei font partecipano al processo standard di selezione dei font utilizzato durante il rendering e la conversione. Sono adatte per scenari di testo regolare in cui Aspose.Slides può sostituire un font inaccessibile con un altro font disponibile secondo la regola configurata.

Tuttavia, le equazioni matematiche di Office hanno una limitazione importante. Se un'equazione è stata creata con **Cambria Math**, Aspose.Slides potrebbe comunque richiedere il font originale **Cambria Math** per calcolare e renderizzare correttamente il layout dell'equazione. Per questo motivo, la sostituzione di **Cambria Math** con un altro font matematico, come **STIX Two Math**, non è supportata per il rendering delle equazioni e potrebbe comunque generare un'eccezione che indica che **Cambria Math** è necessario.

Per convertire correttamente tali presentazioni, assicurati che **Cambria Math** sia disponibile per Aspose.Slides a runtime. Puoi installare il font nel sistema operativo o fornirlo come [font esterno](/slides/it/nodejs-java/custom-font/) in modo che partecipi al normale processo di selezione dei font durante il rendering e la conversione.

Questa limitazione è specifica al rendering delle equazioni. Le regole standard di sostituzione dei font descritte sopra si applicano ancora al testo normale della presentazione quando il font originale non è accessibile.

## **FAQ**

**Qual è la differenza tra sostituzione dei font e sostituzione (replacement) dei font?**

[Replacement](/slides/it/nodejs-java/font-replacement/) è una sovrascrittura forzata di un font con un altro su tutta la presentazione. La sostituzione è una regola che si attiva in una condizione specifica, ad esempio quando il font originale non è disponibile, e in tal caso viene utilizzato un font di riserva designato.

**Quando vengono applicate esattamente le regole di sostituzione?**

Le regole partecipano alla sequenza standard di [selezione del font](/slides/it/nodejs-java/font-selection-sequence/) valutata durante il caricamento, il rendering e la conversione; se il font scelto non è disponibile, viene applicata la sostituzione o la sostituzione forzata.

**Qual è il comportamento predefinito se né la sostituzione né la sostituzione forzata sono configurate e il font manca sul sistema?**

La libreria cercherà di scegliere il font di sistema più vicino disponibile, simile a quanto farebbe PowerPoint.

**Posso allegare font esterni personalizzati a runtime per evitare la sostituzione?**

Sì. È possibile [aggiungere font esterni](/slides/it/nodejs-java/custom-font/) a runtime così che la libreria li consideri per la selezione e il rendering, anche per le conversioni successive.

**Aspose distribuisce dei font con la libreria?**

No. Aspose non distribuisce font a pagamento o gratuiti; devi aggiungere e utilizzare i font a tua discrezione e responsabilità.

**Ci sono differenze nel comportamento di sostituzione su Windows, Linux e macOS?**

Sì. La ricerca dei font parte dalle directory dei font del sistema operativo. Il set di font disponibili per impostazione predefinita e i percorsi di ricerca differiscono tra le piattaforme, influenzando la disponibilità e la necessità di sostituzione.

**Come devo preparare l'ambiente per ridurre al minimo le sostituzioni inaspettate durante le conversioni batch?**

Sincronizza il set di font tra macchine o container, [aggiungi i font esterni](/slides/it/nodejs-java/custom-font/) richiesti per i documenti di output e [incorpora i font](/slides/it/nodejs-java/embedded-font/) nelle presentazioni quando possibile, così i font scelti saranno disponibili durante il rendering.