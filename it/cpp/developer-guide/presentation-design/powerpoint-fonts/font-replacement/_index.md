---
title: Snellire la sostituzione dei caratteri nelle presentazioni con C++
linktitle: Sostituzione dei Font
type: docs
weight: 60
url: /it/cpp/font-replacement/
keywords:
- font
- sostituire font
- sostituzione font
- cambiare font
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Sostituisci i font in modo fluido in Aspose.Slides per C++ per garantire una tipografia coerente nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di sostituire un carattere con un altro in tutta la presentazione. Quando un carattere viene sostituito, tutte le occorrenze del carattere originale vengono cambiate nel nuovo carattere.

Per eseguire la sostituzione dei caratteri, carica la presentazione, definisci il carattere di origine e il carattere di sostituzione, chiama il metodo di sostituzione dei caratteri e salva la presentazione modificata come file PPTX. Questo approccio è utile quando si desidera passare intenzionalmente da una famiglia di caratteri a un’altra in tutta la presentazione.

## **Sostituisci i Font**

Se cambi idea sull’utilizzo di un carattere, puoi sostituirlo con un altro carattere. Tutte le occorrenze del vecchio carattere verranno sostituite dal nuovo carattere.

Aspose.Slides consente di sostituire un carattere in questo modo:

1. Carica la presentazione pertinente.  
2. Carica il carattere che sarà sostituito.  
3. Carica il nuovo carattere.  
4. Sostituisci il carattere.  
5. Scrivi la presentazione modificata come file PPTX.

Questo codice C++ dimostra la sostituzione dei caratteri:

``` cpp
// Carica una presentazione
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Carica il font di origine che verrà sostituito
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Carica il nuovo font
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Sostituisce i font
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Salva la presentazione
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

Per impostare regole che determinano cosa succede in determinate condizioni (ad esempio, se un carattere non è accessibile), consulta [**Sostituzione dei Font**](/slides/it/cpp/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Qual è la differenza tra "font replacement", "font substitution" e "fallback fonts"?**

La sostituzione è un passaggio intenzionale da una famiglia all’altra in tutto il documento. [**Sostituzione dei Font**](/slides/it/cpp/font-substitution/) è una regola del tipo "se il carattere non è disponibile, usa X". [**Font di Fallback**](/slides/it/cpp/fallback-font/) viene applicato in modo puntuale per glifi mancanti individuali quando il carattere di base è installato ma non contiene i caratteri richiesti.

**La sostituzione si applica a master slide, layout, note e commenti?**

Sì. La sostituzione influisce su tutti gli oggetti della presentazione che utilizzano il carattere originale, inclusi master slide e note; i commenti fanno parte del documento e sono considerati dal motore dei caratteri.

**Il carattere cambierà all’interno di oggetti OLE incorporati (ad esempio, Excel)?**

No. I [contenuti OLE](/slides/it/cpp/manage-ole/) sono controllati dalla rispettiva applicazione. La sostituzione nella presentazione non riformatta i dati OLE interni; potrebbero essere visualizzati come immagine o come contenuto modificabile esternamente.

**Posso sostituire un carattere solo in una parte della presentazione (per slide o regioni)?**

È possibile una sostituzione mirata se si modifica il carattere a livello degli oggetti/intervalli richiesti anziché applicare una sostituzione globale all’intero documento. La logica di selezione dei caratteri durante il rendering rimane la stessa.

**Come posso determinare in anticipo quali caratteri utilizza la presentazione?**

Utilizza il [font manager](/slides/it/cpp/font-manager/) della presentazione: fornisce un elenco delle [famiglie in uso](/slides/it/cpp/font-manager/getfonts/) e informazioni sulle [sostituzioni/"font sconosciuti"](/slides/it/cpp/font-manager/getsubstitutions/), utili per pianificare la sostituzione.

**La sostituzione dei caratteri funziona durante la conversione in PDF/immagini?**

Sì. Durante l’esportazione, Aspose.Slides applica la stessa [sequenza di selezione/sostituzione dei caratteri](/slides/it/cpp/font-selection-sequence/), quindi una sostituzione eseguita in anticipo sarà rispettata durante la conversione.

**Devo installare il carattere di destinazione nel sistema o posso allegare una cartella di font?**

L’installazione non è obbligatoria: la libreria consente di [caricare font esterni](/slides/it/cpp/custom-font/) da cartelle utente per l’uso durante il [rendering e l’esportazione](/slides/it/cpp/convert-powerpoint/).

**La sostituzione risolverà i "tofu" (quadrati) al posto dei caratteri?**

Solo se il carattere di destinazione contiene effettivamente i glifi richiesti. In caso contrario, [configura il fallback](/slides/it/cpp/fallback-font/) per coprire i caratteri mancanti.