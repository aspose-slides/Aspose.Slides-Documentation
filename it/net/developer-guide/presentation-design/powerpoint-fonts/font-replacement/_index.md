---
title: Semplifica la sostituzione dei font nelle presentazioni in .NET
linktitle: Sostituzione dei font
type: docs
weight: 60
url: /it/net/font-replacement/
keywords:
- font
- sostituire font
- sostituzione font
- cambiare font
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Sostituisci i font in modo fluido in Aspose.Slides per .NET per garantire una tipografia coerente nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di sostituire un carattere con un altro in tutta la presentazione. Quando un carattere viene sostituito, tutte le occorrenze del carattere originale vengono cambiate nel nuovo carattere.

Per eseguire la sostituzione dei caratteri, carica la presentazione, definisci il carattere di origine e il carattere di sostituzione, chiama il metodo di sostituzione dei caratteri e salva la presentazione modificata come file PPTX. Questo approccio è utile quando si desidera intenzionalmente passare da una famiglia di caratteri a un'altra nell'intera presentazione.

## **Sostituzione dei font**

Se cambi idea sull'uso di un font, puoi sostituire quel font con un altro. Tutte le occorrenze del vecchio font saranno sostituite dal nuovo font. 

Aspose.Slides consente di sostituire un font in questo modo:

1. Carica la presentazione pertinente. 
2. Carica il font da sostituire.
3. Carica il nuovo font. 
4. Sostituisci il font. 
5. Scrivi la presentazione modificata come file PPTX.

Questo codice C# dimostra la sostituzione dei font:

```c#
// Carica una presentazione
Presentation presentation = new Presentation("Fonts.pptx");

// Carica il font sorgente che sarà sostituito
IFontData sourceFont = new FontData("Arial");

// Carica il nuovo font
IFontData destFont = new FontData("Times New Roman");

// Sostituisce i font
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Salva la presentazione
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Note" color="warning" %}} 

Per impostare regole che determinano cosa accade in determinate condizioni (ad esempio se un font non è accessibile), vedere [**Font Substitution**](/slides/it/net/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Qual è la differenza tra "font replacement", "font substitution" e "fallback fonts"?**

La sostituzione è un cambiamento intenzionale da una famiglia all'altra in tutto il documento. [Substitution](/slides/it/net/font-substitution/) è una regola del tipo "se il font non è disponibile, usa X". [Fallback](/slides/it/net/fallback-font/) viene applicato in modo puntuale per glifi mancanti individuali quando il font di base è installato ma non contiene i caratteri richiesti.

**La sostituzione si applica a master slide, layout, note e commenti?**

Sì. La sostituzione influisce su tutti gli oggetti della presentazione che utilizzano il font originale, incluse le master slide e le note; i commenti fanno parte del documento e vengono considerati dal motore dei font.

**Il font cambierà all'interno di oggetti OLE incorporati (ad esempio Excel)?**

No. [OLE content](/slides/it/net/manage-ole/) è gestito dalla sua applicazione. La sostituzione nella presentazione non riformatta i dati interni OLE; possono essere visualizzati come immagine o come contenuto esternamente modificabile.

**Posso sostituire un font solo in parte della presentazione (per slide o regioni)?**

È possibile una sostituzione mirata se si cambia il font a livello degli oggetti o intervalli richiesti anziché applicare una sostituzione globale a tutto il documento. La logica generale di selezione del font durante il rendering rimane la stessa.

**Come posso determinare in anticipo quali font utilizza la presentazione?**

Usa il [font manager] (https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/) della presentazione: fornisce un elenco delle [famiglie in uso] (https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getfonts/) e informazioni sui [font "unknown"/sostituzioni] (https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getsubstitutions/), che aiutano a pianificare la sostituzione.

**La sostituzione dei font funziona durante la conversione in PDF/immagini?**

Sì. Durante l'esportazione, Aspose.Slides applica la stessa [sequenza di selezione/sostituzione dei font](/slides/it/net/font-selection-sequence/), quindi una sostituzione effettuata in anticipo sarà rispettata durante la conversione.

**Devo installare il font di destinazione nel sistema o posso allegare una cartella di font?**

L'installazione non è necessaria: la libreria consente il [caricamento di font esterni](/slides/it/net/custom-font/) da cartelle utente per l'uso durante il [rendering e l'esportazione](/slides/it/net/convert-powerpoint/).

**La sostituzione risolverà i "tofu" (quadrati) al posto dei caratteri?**

Solo se il font di destinazione contiene effettivamente i glifi richiesti. In caso contrario, [configura il fallback](/slides/it/net/fallback-font/) per coprire i caratteri mancanti.