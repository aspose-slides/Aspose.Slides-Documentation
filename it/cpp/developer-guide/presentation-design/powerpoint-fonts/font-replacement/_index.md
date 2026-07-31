---
title: "Ottimizza la sostituzione dei font nelle presentazioni usando C++"
linktitle: "Sostituzione font"
type: docs
weight: 60
url: /it/cpp/font-replacement/
keywords:
- "font"
- "sostituire font"
- "sostituzione font"
- "cambiare font"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "C++"
- "Aspose.Slides"
description: "Sostituisci senza sforzo i font in Aspose.Slides per C++ per garantire una tipografia coerente in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di sostituire un font con un altro in tutta la presentazione. Quando un font viene sostituito, tutte le istanze del font originale vengono cambiate nel nuovo font.

Per eseguire la sostituzione del font, carica la presentazione, definisci il font di origine e il font di sostituzione, chiama il metodo di sostituzione del font e salva la presentazione modificata come file PPTX. Questo approccio è utile quando si desidera intenzionalmente passare da una famiglia di font a un'altra in tutta la presentazione.

## **Sostituire i font**

Se cambi idea sull'uso di un font, puoi sostituire quel font con un altro. Tutte le istanze del vecchio font verranno sostituite dal nuovo font. 

Aspose.Slides consente di sostituire un font in questo modo:

1. Carica la presentazione pertinente. 
2. Carica il font da sostituire.
3. Carica il nuovo font. 
4. Sostituisci il font. 
5. Scrivi la presentazione modificata come file PPTX.

Questo C++ code demonstrates font replacement:

``` cpp
// Carica una presentazione
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Carica il font sorgente da sostituire
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Carica il nuovo font
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Sostituisce i font
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Salva la presentazione
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Per impostare regole che determinano cosa succede in determinate condizioni (ad esempio, se un font non è accessibile), consulta [**Sostituzione font**](/slides/it/cpp/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra "font replacement", "font substitution" e "fallback fonts"?**

La sostituzione è uno scambio intenzionale da una famiglia all'altra su tutto il documento. [Substitution](/slides/it/cpp/font-substitution/) è una regola del tipo "se il font non è disponibile, usa X." [Fallback](/slides/it/cpp/fallback-font/) viene applicato in modo mirato per singoli glifi mancanti quando il font di base è installato ma non contiene i caratteri richiesti.

**La sostituzione si applica a master slide, layout, note e commenti?**

Sì. La sostituzione influisce su tutti gli oggetti della presentazione che utilizzano il font originale, inclusi master slide e note; i commenti fanno anche parte del documento e vengono considerati dal motore dei font.

**Il font cambierà all'interno di oggetti OLE incorporati (ad esempio, Excel)?**

No. [OLE content](/slides/it/cpp/manage-ole/) è controllato dalla sua applicazione proprietaria. La sostituzione nella presentazione non riformatta i dati OLE interni; potrebbero essere visualizzati come immagine o come contenuto modificabile esternamente.

**Posso sostituire un font solo in una parte della presentazione (per slide o regioni)?**

La sostituzione mirata è possibile se si cambia il font a livello degli oggetti/intervalli richiesti anziché applicare una sostituzione globale a tutto il documento. La logica complessiva di selezione del font durante il rendering rimane invariata.

**Come posso determinare in anticipo quali font utilizza la presentazione?**

Utilizza il [font manager](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/) della presentazione: fornisce un elenco delle [famiglie in uso](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/getfonts/) e informazioni sulle [sostituzioni/"font sconosciuti"](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/getsubstitutions/), che aiutano a pianificare la sostituzione.

**La sostituzione del font funziona durante la conversione in PDF/immagini?**

Sì. Durante l'esportazione, Aspose.Slides applica la stessa [font selection/substitution sequence](/slides/it/cpp/font-selection-sequence/), quindi una sostituzione eseguita in anticipo verrà rispettata durante la conversione.

**Devo installare il font di destinazione nel sistema o posso allegare una cartella di font?**

L'installazione non è necessaria: la libreria consente il [loading external fonts](/slides/it/cpp/custom-font/) da cartelle utente per l'uso durante il [rendering and export](/slides/it/cpp/convert-powerpoint/).

**La sostituzione risolverà i "tofu" (quadrati) al posto dei caratteri?**

Solo se il font di destinazione contiene effettivamente i glifi richiesti. In caso contrario, [configure fallback](/slides/it/cpp/fallback-font/) per coprire i caratteri mancanti.