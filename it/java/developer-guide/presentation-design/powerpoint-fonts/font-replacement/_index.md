---
title: Ottimizzare la sostituzione dei caratteri nelle presentazioni usando Java
linktitle: Sostituzione del carattere
type: docs
weight: 60
url: /it/java/font-replacement/
keywords:
- carattere
- sostituire carattere
- sostituzione carattere
- cambiare carattere
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Sostituisci senza soluzione di continuità i caratteri in Aspose.Slides per Java per garantire una tipografia coerente nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di sostituire un carattere con un altro in tutta la presentazione. Quando un carattere viene sostituito, tutte le occorrenze del carattere originale vengono cambiate nel nuovo carattere.

Per eseguire la sostituzione dei caratteri, carica la presentazione, definisci il carattere di origine e il carattere di sostituzione, chiama il metodo di sostituzione dei caratteri e salva la presentazione modificata come file PPTX. Questo approccio è utile quando si desidera intenzionalmente passare da una famiglia di caratteri a un’altra in tutta la presentazione.

## **Sostituire i caratteri**

Se cambi idea sull'utilizzo di un carattere, puoi sostituire quel carattere con un altro. Tutte le occorrenze del vecchio carattere verranno sostituite dal nuovo carattere.

Aspose.Slides consente di sostituire un carattere in questo modo:

1. Carica la presentazione pertinente. 
2. Carica il carattere che verrà sostituito. 
3. Carica il nuovo carattere. 
4. Sostituisci il carattere. 
5. Scrivi la presentazione modificata come file PPTX.

```java
// Carica una presentazione
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Carica il carattere di origine che verrà sostituito
    IFontData sourceFont = new FontData("Arial");
    
    // Carica il nuovo carattere
    IFontData destFont = new FontData("Times New Roman");
    
    // Sostituisce i caratteri
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Salva la presentazione
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Per impostare regole che determinano cosa accade in determinate condizioni (ad esempio se un carattere non è accessibile), vedere [**Sostituzione dei caratteri**](/slides/it/java/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra "sostituzione del carattere", "sostituzione dei caratteri" e "font di fallback"?**

La sostituzione è un passaggio intenzionale da una famiglia all’altra in tutto il documento. [Sostituzione](/slides/it/java/font-substitution/) è una regola tipo "se il carattere non è disponibile, usa X". [Fallback](/slides/it/java/fallback-font/) viene applicato in modo mirato per singoli glifi mancanti quando il carattere di base è installato ma non contiene i caratteri richiesti.

**La sostituzione si applica a master slide, layout, note e commenti?**

Sì. La sostituzione influisce su tutti gli oggetti della presentazione che utilizzano il carattere originale, comprese le master slide e le note; i commenti fanno anche parte del documento e sono considerati dal motore dei caratteri.

**Il carattere cambierà all'interno di oggetti OLE incorporati (ad esempio Excel)?**

No. [Contenuto OLE](/slides/it/java/manage-ole/) è controllato dalla propria applicazione. La sostituzione nella presentazione non riformatta i dati OLE interni; può essere visualizzata come immagine o come contenuto modificabile esternamente.

**Posso sostituire un carattere solo in una parte della presentazione (per diapositive o regioni)?**

La sostituzione mirata è possibile se si cambia il carattere a livello degli oggetti/aree richiesti anziché applicare una sostituzione globale a tutto il documento. La logica di selezione dei caratteri complessiva durante il rendering rimane la stessa.

**Come posso determinare in anticipo quali caratteri utilizza la presentazione?**

Utilizza il [font manager](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/): fornisce un elenco delle [famiglie in uso](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/#getFonts--) e informazioni sulle [sostituzioni/\"unknown\" fonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/#getSubstitutions--), che aiutano a pianificare la sostituzione.

**La sostituzione dei caratteri funziona quando si converte in PDF/immagini?**

Sì. Durante l'esportazione, Aspose.Slides applica la stessa [sequenza di selezione/sostituzione dei caratteri](/slides/it/java/font-selection-sequence/), quindi una sostituzione eseguita in anticipo verrà rispettata durante la conversione.

**Devo installare il carattere di destinazione nel sistema o posso allegare una cartella di caratteri?**

L'installazione non è necessaria: la libreria consente di [caricare caratteri esterni](/slides/it/java/custom-font/) da cartelle utente per l'uso durante il [rendering e l'esportazione](/slides/it/java/convert-powerpoint/).

**La sostituzione risolverà i "tofu" (quadrati) al posto dei caratteri?**

Solo se il carattere di destinazione contiene effettivamente i glifi richiesti. In caso contrario, [configura il fallback](/slides/it/java/fallback-font/) per coprire i caratteri mancanti.