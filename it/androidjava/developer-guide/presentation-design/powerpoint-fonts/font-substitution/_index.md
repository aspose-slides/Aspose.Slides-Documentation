---
title: Configura la sostituzione dei caratteri nelle presentazioni su Android
linktitle: Sostituzione dei caratteri
type: docs
weight: 70
url: /it/androidjava/font-substitution/
keywords:
- carattere
- sostituire carattere
- sostituzione del carattere
- sostituzione del carattere
- sostituzione dei caratteri
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Abilita la sostituzione ottimale dei caratteri in Aspose.Slides per Android tramite Java durante la conversione di presentazioni PowerPoint e OpenDocument in altri formati di file."
---
## **Panoramica**

La sostituzione dei caratteri consente a Aspose.Slides di usare un altro carattere quando il carattere originale della presentazione non è disponibile durante il rendering o la conversione. È possibile verificare quali caratteri sono stati sostituiti utilizzando il metodo `getSubstitutions` dell'interfaccia `IFontsManager`.

Aspose.Slides consente inoltre di definire regole di sostituzione dei caratteri. Ad esempio, è possibile specificare che un carattere non accessibile debba essere sostituito con un altro carattere disponibile e poi applicare tali regole tramite il gestore dei caratteri della presentazione.

## **Imposta regole di sostituzione dei caratteri**

Aspose.Slides consente di impostare regole per i caratteri che determinano cosa deve essere fatto in determinate condizioni (ad esempio, quando un carattere non può essere accesso) in questo modo:

1. Carica la presentazione pertinente.
2. Carica il carattere che sarà sostituito.
3. Carica il nuovo carattere.
4. Aggiungi una regola per la sostituzione.
5. Aggiungi la regola alla raccolta delle regole di sostituzione dei caratteri della presentazione.
6. Genera l'immagine della diapositiva per osservare l'effetto.

Questo codice Java dimostra il processo di sostituzione dei caratteri:

```java
// Carica una presentazione
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Carica il carattere sorgente che sarà sostituito
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Carica il nuovo carattere
    IFontData destFont = new FontData("Arial");
    
    // Aggiunge una regola di sostituzione del carattere
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Aggiunge la regola alla collezione delle regole di sostituzione dei caratteri
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Aggiunge una collezione di regole di sostituzione dei caratteri alla lista delle regole
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Il carattere Arial sarà usato al posto di SomeRareFont quando quest'ultimo è inaccessibile
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Salva l'immagine su disco in formato JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Potresti voler vedere [**Sostituzione dei caratteri**](/slides/it/androidjava/font-replacement/).
{{% /alert %}}

## **Limitazioni per i caratteri delle equazioni matematiche**

Le regole di sostituzione dei caratteri partecipano al processo standard di selezione dei caratteri utilizzato durante il rendering e la conversione. Sono adatte per scenari di testo regolare in cui Aspose.Slides può sostituire un carattere non accessibile con un altro carattere disponibile secondo la regola configurata.

Tuttavia, le equazioni matematiche di Office hanno una limitazione importante. Se un'equazione è stata creata con **Cambria Math**, Aspose.Slides potrebbe comunque richiedere il carattere originale **Cambria Math** per calcolare e renderizzare correttamente il layout dell'equazione. Per questo motivo, la sostituzione di **Cambria Math** con un altro carattere matematico, come **STIX Two Math**, non è supportata per il rendering delle equazioni e potrebbe comunque generare un'eccezione che indica che è necessario **Cambria Math**.

Per convertire correttamente tali presentazioni, assicurati che **Cambria Math** sia disponibile per Aspose.Slides durante l'esecuzione. Puoi installare il carattere nel sistema operativo o fornirlo come [carattere esterno](/slides/it/androidjava/custom-font/) in modo che possa partecipare al normale processo di selezione dei caratteri durante il rendering e la conversione.

Questa limitazione è specifica per il rendering delle equazioni. Le regole standard di sostituzione dei caratteri descritte sopra si applicano comunque al testo normale della presentazione quando il carattere originale è inaccessibile.

## **FAQ**

**Qual è la differenza tra font replacement e font substitution?**

[Sostituzione](/slides/it/androidjava/font-replacement/) è una sovrascrittura forzata di un carattere con un altro su tutta la presentazione. La sostituzione è una regola che si attiva in una condizione specifica, ad esempio quando il carattere originale non è disponibile, e quindi viene utilizzato un carattere di riserva designato.

**Quando vengono applicate esattamente le regole di sostituzione?**

Le regole partecipano alla sequenza standard di [selezione del carattere](/slides/it/androidjava/font-selection-sequence/) che viene valutata durante il caricamento, il rendering e la conversione; se il carattere scelto non è disponibile, viene applicata la sostituzione o la sostituzione forzata.

**Qual è il comportamento predefinito se né la sostituzione né la sostituzione sono configurate e il carattere manca nel sistema?**

La libreria cercherà di scegliere il carattere di sistema più vicino disponibile, in modo simile a come si comporterebbe PowerPoint.

**Posso allegare caratteri esterni personalizzati a runtime per evitare la sostituzione?**

Sì. Puoi [aggiungere caratteri esterni](/slides/it/androidjava/custom-font/) a runtime in modo che la libreria li consideri per la selezione e il rendering, anche per le conversioni successive.

**Aspose distribuisce qualche carattere con la libreria?**

No. Aspose non distribuisce caratteri a pagamento o gratuiti; aggiungi e usi i caratteri a tua discrezione e responsabilità.

**Ci sono differenze nel comportamento di sostituzione su Windows, Linux e macOS?**

Sì. La scoperta dei caratteri inizia dalle directory dei caratteri del sistema operativo. L'insieme dei caratteri predefiniti disponibili e i percorsi di ricerca differiscono tra le piattaforme, il che influisce sulla disponibilità e sulla necessità di sostituzione.

**Come devo preparare l'ambiente per ridurre al minimo le sostituzioni inattese durante le conversioni batch?**

Sincronizza il set di caratteri tra macchine o container, [aggiungi i caratteri esterni](/slides/it/androidjava/custom-font/) richiesti per i documenti di output e [incorpora i caratteri](/slides/it/androidjava/embedded-font/) nelle presentazioni quando possibile, in modo che i caratteri scelti siano disponibili durante il rendering.