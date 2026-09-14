---
title: Semplifica la sostituzione dei caratteri nelle presentazioni usando Python via Java
linktitle: Sostituzione dei caratteri
type: docs
weight: 60
url: /it/python-java/font-replacement/
keywords:
- carattere
- sostituire carattere
- sostituzione del carattere
- cambiare carattere
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Sostituisci i caratteri in modo fluido in Aspose.Slides per Python via Java per garantire una tipografia coerente nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides permette di sostituire un carattere con un altro in tutta la presentazione. Quando un carattere viene sostituito, tutte le istanze del carattere originale vengono cambiate nel nuovo carattere.

Per eseguire la sostituzione del carattere, carica la presentazione, definisci il carattere sorgente e il carattere di sostituzione, chiama il metodo di sostituzione del carattere e salva la presentazione modificata come file PPTX. Questo approccio è utile quando si desidera intenzionalmente passare da una famiglia di caratteri a un'altra in tutta la presentazione.

## **Sostituzione dei caratteri**

Se cambi idea su un carattere, puoi sostituire quel carattere con un altro. Tutte le istanze del vecchio carattere saranno sostituite dal nuovo. 

Aspose.Slides permette di sostituire un carattere in questo modo:

1. Carica la presentazione pertinente. 
2. Carica il carattere che verrà sostituito.
3. Carica il nuovo carattere. 
4. Sostituisci il carattere. 
5. Scrivi la presentazione modificata come file PPTX.

Questo codice Python dimostra la sostituzione dei caratteri:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# Carica una presentazione.
presentation = Presentation("Fonts.pptx")
try:
    # Carica il carattere sorgente che verrà sostituito.
    source_font = FontData("Arial")

    # Carica il nuovo carattere.
    destination_font = FontData("Times New Roman")

    # Sostituisci il carattere.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # Salva la presentazione.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}} 

Per impostare regole che determinano cosa succede in determinate condizioni (ad esempio se un carattere non è accessibile), vedere [Sostituzione dei caratteri](/slides/it/python-java/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Qual è la differenza tra "sostituzione del carattere", "sostituzione" e "caratteri di fallback"?**

La sostituzione è un cambio intenzionale da una famiglia all'altra in tutto il documento. [Sostituzione](/slides/it/python-java/font-substitution/) è una regola come "se il carattere non è disponibile, usa X." [Fallback](/slides/it/python-java/fallback-font/) viene applicato ai singoli glifi mancanti quando il carattere base è installato ma non contiene i caratteri richiesti.

**La sostituzione si applica a diapositive master, layout, note e commenti?**

Sì. La sostituzione interessa tutti gli oggetti della presentazione che usano il carattere originale, comprese le diapositive master e le note; i commenti fanno parte del documento e sono considerati dal motore dei caratteri.

**Il carattere cambia all'interno di oggetti OLE incorporati (ad esempio Excel)?**

No. [OLE content](/slides/it/python-java/manage-ole/) è gestito dalla propria applicazione. La sostituzione nella presentazione non riformatta i dati OLE interni; possono essere visualizzati come immagine o come contenuto modificabile esternamente.

**Posso sostituire un carattere solo in parte della presentazione (per diapositive o regioni)?**

È possibile eseguire una sostituzione mirata se cambi il carattere a livello degli oggetti o degli intervalli richiesti, anziché applicare una sostituzione globale a tutto il documento. La logica di selezione dei caratteri durante il rendering rimane invariata.

**Come posso determinare in anticipo quali caratteri utilizza la presentazione?**

Usa il [font manager] (https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/) della presentazione: fornisce un elenco delle [famiglie in uso] (https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getFonts) e informazioni su [sostituzioni/"caratteri sconosciuti"] (https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getSubstitutions), il che aiuta a pianificare la sostituzione.

**La sostituzione del carattere funziona durante la conversione in PDF/immagini?**

Sì. Durante l'esportazione, Aspose.Slides applica la stessa [sequenza di selezione/sostituzione dei caratteri](/slides/it/python-java/font-selection-sequence/), quindi una sostituzione eseguita in anticipo verrà rispettata durante la conversione.

**Devo installare il carattere di destinazione nel sistema o posso allegare una cartella di caratteri?**

L'installazione non è necessaria: la libreria consente il [caricamento di caratteri esterni](/slides/it/python-java/custom-font/) da cartelle utente per l'uso durante il [rendering e l'esportazione](/slides/it/python-java/convert-powerpoint/).

**La sostituzione risolverà il problema del "tofu" (quadrati) al posto dei caratteri?**

Solo se il carattere di destinazione contiene realmente i glifi richiesti. In caso contrario, [configura il fallback](/slides/it/python-java/fallback-font/) per coprire i caratteri mancanti.