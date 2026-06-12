---
title: Ottimizza la sostituzione dei font nelle presentazioni usando Python
linktitle: Sostituzione Font
type: docs
weight: 60
url: /it/python-net/font-replacement/
keywords:
- font
- sostituire font
- sostituzione font
- cambiare font
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Sostituisci i font in modo fluido in Aspose.Slides Python tramite .NET per garantire una tipografia coerente nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides ti consente di sostituire un font con un altro in tutta la presentazione. Quando un font viene sostituito, tutte le istanze del font originale vengono cambiate nel nuovo font.

Per eseguire la sostituzione dei font, carica la presentazione, definisci il font di origine e il font di sostituzione, chiama il metodo di sostituzione del font e salva la presentazione modificata come file PPTX. Questo approccio è utile quando si desidera intenzionalmente passare da una famiglia di font a un'altra in tutta la presentazione.

## **Sostituzione Font**

Se cambi idea sull'uso di un font, puoi sostituire quel font con un altro. Tutte le istanze del vecchio font saranno sostituite dal nuovo font.

Aspose.Slides ti consente di sostituire un font in questo modo:

1. Carica la presentazione pertinente. 
2. Carica il font da sostituire. 
3. Carica il nuovo font. 
4. Sostituisci il font. 
5. Scrivi la presentazione modificata come file PPTX.

Questo codice Python dimostra la sostituzione dei font:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Carica una presentazione
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Carica il font di origine che verrà sostituito
    sourceFont = slides.FontData("Arial")

    # Carica il nuovo font
    destFont = slides.FontData("Times New Roman")

    # Sostituisce i font
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Salva la presentazione
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 

Per impostare regole che determinano cosa succede in determinate condizioni (ad esempio se un font non è accessibile), vedi [**Sostituzione Font**](/slides/it/python-net/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Qual è la differenza tra "font replacement", "font substitution" e "fallback fonts"?**

La sostituzione è un cambio intenzionale da una famiglia all'altra in tutto il documento. [Sostituzione](/slides/it/python-net/font-substitution/) è una regola del tipo "se il font non è disponibile, usa X". [Fallback](/slides/it/python-net/fallback-font/) viene applicato in modo mirato per glifi mancanti individuali quando il font di base è installato ma non contiene i caratteri richiesti.

**La sostituzione si applica a master slide, layout, note e commenti?**

Sì. La sostituzione influenza tutti gli oggetti della presentazione che utilizzano il font originale, incluse le master slide e le note; i commenti fanno anche parte del documento e sono considerati dal motore dei font.

**Il font cambierà all'interno di oggetti OLE incorporati (ad esempio Excel)?**

No. [Contenuto OLE](/slides/it/python-net/manage-ole/) è controllato dalla sua applicazione. La sostituzione nella presentazione non riformatta i dati OLE interni; questi possono essere visualizzati come immagine o come contenuto modificabile esternamente.

**Posso sostituire un font solo in parte della presentazione (per diapositive o regioni)?**

Una sostituzione mirata è possibile se si cambia il font a livello degli oggetti/intervalli necessari invece di applicare una sostituzione globale a tutto il documento. La logica di selezione dei font durante il rendering rimane la stessa.

**Come posso determinare in anticipo quali font utilizza la presentazione?**

Utilizza il [gestore dei font](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/): fornisce un elenco delle [famiglie in uso](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_fonts/) e informazioni sulle [sostituzioni/"font sconosciuti"] (https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_substitutions/), che aiutano a pianificare la sostituzione.

**La sostituzione dei font funziona durante la conversione in PDF/immagini?**

Sì. Durante l'esportazione, Aspose.Slides applica la stessa [sequenza di selezione/sostituzione dei font](/slides/it/python-net/font-selection-sequence/), quindi una sostituzione effettuata in anticipo verrà rispettata durante la conversione.

**Devo installare il font di destinazione nel sistema o posso allegare una cartella di font?**

L'installazione non è necessaria: la libreria consente il [caricamento di font esterni](/slides/it/python-net/custom-font/) dalle cartelle utente per l'uso durante il [rendering e l'esportazione](/slides/it/python-net/convert-powerpoint/).

**La sostituzione risolverà i "tofu" (quadrati) al posto dei caratteri?**

Solo se il font di destinazione contiene effettivamente i glifi richiesti. In caso contrario, [configura il fallback](/slides/it/python-net/fallback-font/) per coprire i caratteri mancanti.