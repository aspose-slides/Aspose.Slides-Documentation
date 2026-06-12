---
title: Semplifica la sostituzione dei font nelle presentazioni usando JavaScript
linktitle: Sostituzione Font
type: docs
weight: 60
url: /it/nodejs-java/font-replacement/
keywords:
- font
- sostituire font
- sostituzione font
- cambia font
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Sostituisci i font senza interruzioni in JavaScript con Aspose.Slides per Node.js tramite Java per garantire una tipografia coerente nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di sostituire un font con un altro in tutta la presentazione. Quando un font viene sostituito, tutte le occorrenze del font originale vengono cambiate nel nuovo font.

Per eseguire la sostituzione dei font, carica la presentazione, definisci il font di origine e il font di sostituzione, chiama il metodo di sostituzione del font e salva la presentazione modificata come file PPTX. Questo approccio è utile quando si desidera intenzionalmente passare da una famiglia di font a un'altra nell'intera presentazione.

## **Sostituisci i font**

Se cambi idea sull'uso di un font, puoi sostituirlo con un altro font. tutte le occorrenze del vecchio font saranno sostituite dal nuovo font.

Aspose.Slides consente di sostituire un font in questo modo:

1. Carica la presentazione pertinente.  
2. Carica il font che verrà sostituito.  
3. Carica il nuovo font.  
4. Sostituisci il font.  
5. Scrivi la presentazione modificata come file PPTX.

Questo codice JavaScript dimostra la sostituzione dei font:

```javascript
// Carica una presentazione
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Carica il font sorgente che verrà sostituito
    var sourceFont = new aspose.slides.FontData("Arial");
    // Carica il nuovo font
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Sostituisce i font
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Salva la presentazione
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
Per impostare regole che determinano cosa succede in determinate condizioni (ad esempio se un font non è accessibile), vedi [**Font Substitution**](/slides/it/nodejs-java/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra "font replacement", "font substitution" e "fallback fonts"?**

La sostituzione è un passaggio intenzionale da una famiglia all'altra nell'intero documento. [Substitution](/slides/it/nodejs-java/font-substitution/) è una regola del tipo "se il font non è disponibile, usa X". [Fallback](/slides/it/nodejs-java/fallback-font/) viene applicato in modo mirato per singoli glifi mancanti quando il font di base è installato ma non contiene i caratteri richiesti.

**La sostituzione si applica a master slide, layout, note e commenti?**

Sì. La sostituzione influisce su tutti gli oggetti della presentazione che utilizzano il font originale, inclusi i master slide e le note; i commenti fanno parte del documento e sono considerati dal motore dei font.

**Il font cambierà all'interno degli oggetti OLE incorporati (ad esempio Excel)?**

No. [OLE content](/slides/it/nodejs-java/manage-ole/) è controllato dalla propria applicazione. La sostituzione nella presentazione non riformatta i dati OLE interni; potrebbe essere visualizzato come immagine o come contenuto modificabile esternamente.

**Posso sostituire un font solo in una parte della presentazione (per slide o regioni)?**

È possibile una sostituzione mirata se si cambia il font a livello degli oggetti o intervalli necessari anziché applicare una sostituzione globale a tutto il documento. La logica complessiva di selezione dei font durante il rendering rimane invariata.

**Come posso determinare in anticipo quali font utilizza la presentazione?**

Usa il [font manager] (https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/) della presentazione: fornisce un elenco delle [famiglie in uso] (https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getfonts/) e informazioni sulle [sostituzioni/"font sconosciuti"] (https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), utili per pianificare la sostituzione.

**La sostituzione dei font funziona durante la conversione in PDF/immagini?**

Sì. Durante l'esportazione, Aspose.Slides applica la stessa [sequenza di selezione/sostituzione dei font](/slides/it/nodejs-java/font-selection-sequence/), quindi una sostituzione effettuata in anticipo sarà rispettata durante la conversione.

**Devo installare il font di destinazione nel sistema o posso allegare una cartella di font?**

L'installazione non è necessaria: la libreria consente il [caricamento di font esterni](/slides/it/nodejs-java/custom-font/) da cartelle utente per l'uso durante il [rendering e l'esportazione](/slides/it/nodejs-java/convert-powerpoint/).

**La sostituzione risolverà i "tofu" (quadrati) al posto dei caratteri?**

Solo se il font di destinazione contiene effettivamente i glifi richiesti. In caso contrario, [configura il fallback](/slides/it/nodejs-java/fallback-font/) per coprire i caratteri mancanti.