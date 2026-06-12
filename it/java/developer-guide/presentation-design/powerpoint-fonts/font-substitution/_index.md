---
title: Configura la sostituzione dei font nelle presentazioni usando Java
linktitle: Sostituzione dei Font
type: docs
weight: 70
url: /it/java/font-substitution/
keywords:
- font
- font sostituto
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
description: "Abilita la sostituzione ottimale dei font in Aspose.Slides per Java durante la conversione di presentazioni PowerPoint e OpenDocument in altri formati di file."
---
## **Panoramica**

La sostituzione dei font consente ad Aspose.Slides di utilizzare un altro font quando il font originale della presentazione non è disponibile durante il rendering o la conversione. È possibile verificare quali font sono stati sostituiti utilizzando il metodo `getSubstitutions` dell'interfaccia `IFontsManager`.

Aspose.Slides permette anche di definire regole di sostituzione dei font. Ad esempio, è possibile specificare che un font inaccessibile debba essere sostituito con un altro font disponibile e quindi applicare tali regole tramite il gestore dei font della presentazione.

## **Imposta regole di sostituzione dei font**

Aspose.Slides consente di impostare regole per i font che determinano cosa fare in determinate condizioni (ad esempio, quando un font non può essere accesso) in questo modo:

1. Caricare la presentazione di interesse.  
2. Caricare il font da sostituire.  
3. Caricare il nuovo font.  
4. Aggiungere una regola per la sostituzione.  
5. Inserire la regola nella raccolta di regole di sostituzione dei font della presentazione.  
6. Generare l'immagine della diapositiva per osservare l'effetto.

Questo codice Java dimostra il processo di sostituzione dei font:

```java
// Carica una presentazione
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Carica il font di origine che sarà sostituito
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Carica il nuovo font
    IFontData destFont = new FontData("Arial");
    
    // Aggiunge una regola di font per la sostituzione del font
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Aggiunge la regola alla raccolta di regole di sostituzione dei font
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Aggiunge una raccolta di regole di font all'elenco delle regole
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Il font Arial verrà usato al posto di SomeRareFont quando quest'ultimo è inaccessibile
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Salva l'immagine sul disco nel formato JPEG
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

Potresti voler consultare [**Sostituzione dei Font**](/slides/it/java/font-replacement/). 

{{% /alert %}}

## **Limitazioni per i font delle equazioni matematiche**

Le regole di sostituzione dei font partecipano al processo standard di selezione dei font utilizzato durante il rendering e la conversione. Sono adeguate per scenari di testo normale in cui Aspose.Slides può sostituire un font inaccessibile con un altro font disponibile secondo la regola configurata.

Tuttavia, le equazioni matematiche di Office presentano una limitazione importante. Se un’equazione è stata creata con **Cambria Math**, Aspose.Slides potrebbe comunque richiedere il font originale **Cambria Math** per calcolare e rendere correttamente il layout dell’equazione. Per questo motivo, la sostituzione di **Cambria Math** con un altro font matematico, come **STIX Two Math**, non è supportata per il rendering delle equazioni e può ancora generare un’eccezione che indica che **Cambria Math** è necessario.

Per convertire correttamente tali presentazioni, assicurati che **Cambria Math** sia disponibile per Aspose.Slides durante l’esecuzione. È possibile installare il font nel sistema operativo o fornirlo come [font esterno](/slides/it/java/custom-font/) in modo che partecipi al normale processo di selezione dei font durante il rendering e la conversione.

Questa limitazione è specifica per il rendering delle equazioni. Le regole standard di sostituzione dei font descritte sopra continuano ad applicarsi al testo normale della presentazione quando il font originale è inaccessibile.

## **FAQ**

**Qual è la differenza tra sostituzione e sostituzione forzata dei font?**

[Replacement](/slides/it/java/font-replacement/) è una sovrascrittura forzata di un font con un altro per tutta la presentazione. La sostituzione è una regola che si attiva in una condizione specifica, ad esempio quando il font originale non è disponibile, e utilizza un font di fallback designato.

**Quando vengono applicate esattamente le regole di sostituzione?**

Le regole partecipano alla sequenza standard di [selezione dei font](/slides/it/java/font-selection-sequence/) valutata durante il caricamento, il rendering e la conversione; se il font scelto non è disponibile, viene applicata la sostituzione o la sovrascrittura.

**Qual è il comportamento predefinito se né la sostituzione né la sovrascrittura sono configurate e il font manca nel sistema?**

La libreria cercherà di scegliere il font di sistema più vicino disponibile, in modo simile a come si comporterebbe PowerPoint.

**Posso aggiungere font esterni personalizzati a runtime per evitare la sostituzione?**

Sì. È possibile [aggiungere font esterni](/slides/it/java/custom-font/) a runtime affinché la libreria li consideri per la selezione e il rendering, inclusi i successivi processi di conversione.

**Aspose distribuisce font con la libreria?**

No. Aspose non distribuisce font a pagamento o gratuiti; aggiungi e utilizzi i font a tua discrezione e responsabilità.

**Ci sono differenze nel comportamento della sostituzione su Windows, Linux e macOS?**

Sì. Il rilevamento dei font parte dalle directory dei font del sistema operativo. Il set di font disponibili di default e i percorsi di ricerca variano tra le piattaforme, influenzando la disponibilità e la necessità di sostituzione.

**Come devo preparare l’ambiente per minimizzare sostituzioni inattese durante conversioni batch?**

Sincronizza il set di font tra macchine o container, [aggiungi i font esterni](/slides/it/java/custom-font/) necessari per i documenti di output e [incorpora i font](/slides/it/java/embedded-font/) nelle presentazioni quando possibile, così i font scelti saranno disponibili durante il rendering.