---
title: "Semplifica la sostituzione dei font nelle presentazioni su Android"
linktitle: "Sostituzione dei font"
type: docs
weight: 60
url: /it/androidjava/font-replacement/
keywords:
- font
- sostituire il font
- sostituzione del font
- cambiare il font
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Sostituisci i font in modo fluido in Aspose.Slides per Android tramite Java per garantire una tipografia coerente nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di sostituire un font con un altro in tutta la presentazione. Quando un font viene sostituito, tutte le istanze del font originale vengono cambiate nel nuovo font.

Per eseguire la sostituzione dei font, carica la presentazione, definisci il font di origine e il font di sostituzione, chiama il metodo di sostituzione dei font e salva la presentazione modificata come file PPTX. Questo approccio è utile quando si desidera passare intenzionalmente da una famiglia di font a un'altra in tutta la presentazione.

## **Sostituisci i Font**

Se cambi idea sull'uso di un font, puoi sostituire quel font con un altro. Tutte le istanze del vecchio font saranno sostituite dal nuovo font.

Aspose.Slides consente di sostituire un font in questo modo:

1. Carica la presentazione pertinente. 
2. Carica il font che sarà sostituito.
3. Carica il nuovo font. 
4. Sostituisci il font. 
5. Scrivi la presentazione modificata come file PPTX.

Questo codice Java dimostra la sostituzione dei font:

```java
// Carica una presentazione
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Carica il font sorgente che verrà sostituito
    IFontData sourceFont = new FontData("Arial");
    
    // Carica il nuovo font
    IFontData destFont = new FontData("Times New Roman");
    
    // Sostituisce i font
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Salva la presentazione
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Per impostare regole che determinano cosa succede in determinate condizioni (ad esempio se un font non è accessibile), vedere [**Sostituzione dei Font**](/slides/it/androidjava/font-substitution/).
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra "sostituzione dei font", "sostituzione dei font" e "font di fallback"?**

La sostituzione è un cambio intenzionale da una famiglia all'altra in tutto il documento. [Sostituzione](/slides/it/androidjava/font-substitution/) è una regola del tipo "se il font non è disponibile, utilizzare X". [Fallback](/slides/it/androidjava/fallback-font/) viene applicato in modo mirato per singoli glifi mancanti quando il font di base è installato ma non contiene i caratteri richiesti.

**La sostituzione si applica a master slide, layout, note e commenti?**

Sì. La sostituzione influisce su tutti gli oggetti della presentazione che utilizzano il font originale, inclusi i master slide e le note; i commenti fanno anche parte del documento e vengono considerati dal motore dei font.

**Il font cambierà all'interno di oggetti OLE incorporati (ad esempio, Excel)?**

No. [Contenuto OLE](/slides/it/androidjava/manage-ole/) è controllato dalla propria applicazione. La sostituzione nella presentazione non riformatta i dati OLE interni; questi possono essere visualizzati come immagine o come contenuto modificabile esternamente.

**Posso sostituire un font solo in una parte della presentazione (per diapositive o regioni)?**

Una sostituzione mirata è possibile se si modifica il font a livello degli oggetti o intervalli desiderati anziché applicare una sostituzione globale a tutto il documento. La logica complessiva di selezione dei font durante il rendering rimane invariata.

**Come posso determinare in anticipo quali font utilizza la presentazione?**

Usa il [gestore dei font] della presentazione (https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/): fornisce un elenco delle [famiglie in uso](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/#getFonts--) e informazioni sulle [sostituzioni/"font sconosciuti"](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--), che aiutano a pianificare la sostituzione.

**La sostituzione dei font funziona durante la conversione in PDF/immagini?**

Sì. Durante l'esportazione, Aspose.Slides applica la stessa [sequenza di selezione/sostituzione dei font](/slides/it/androidjava/font-selection-sequence/), quindi una sostituzione effettuata in anticipo sarà rispettata durante la conversione.

**Devo installare il font di destinazione nel sistema o posso allegare una cartella di font?**

L'installazione non è necessaria: la libreria consente il [caricamento di font esterni](/slides/it/androidjava/custom-font/) dalle cartelle utente per l'uso durante il [rendering e l'esportazione](/slides/it/androidjava/convert-powerpoint/).

**La sostituzione risolverà i "tofu" (quadrati) al posto dei caratteri?**

Solo se il font di destinazione contiene effettivamente i glifi richiesti. In caso contrario, [configura il fallback](/slides/it/androidjava/fallback-font/) per coprire i caratteri mancanti.