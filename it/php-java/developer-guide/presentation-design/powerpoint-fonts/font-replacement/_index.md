---
title: Semplifica la sostituzione dei caratteri nelle presentazioni usando PHP
linktitle: Sostituzione dei caratteri
type: docs
weight: 60
url: /it/php-java/font-replacement/
keywords:
- carattere
- sostituire carattere
- sostituzione del carattere
- cambiare carattere
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Sostituisci senza problemi i caratteri in Aspose.Slides per PHP tramite Java per garantire una tipografia coerente in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di sostituire un carattere con un altro in tutta la presentazione. Quando un carattere viene sostituito, tutte le istanze del carattere originale vengono cambiate nel nuovo carattere.

Per eseguire la sostituzione dei caratteri, carica la presentazione, definisci il carattere di origine e il carattere di sostituzione, chiama il metodo di sostituzione dei caratteri e salva la presentazione modificata come file PPTX. Questo approccio è utile quando desideri intenzionalmente passare da una famiglia di caratteri a un'altra in tutta la presentazione.

## **Sostituire i caratteri**

Se cambi idea sull'uso di un carattere, puoi sostituirlo con un altro carattere. Tutte le istanze del carattere vecchio verranno sostituite dal nuovo.

1. Carica la presentazione pertinente. 
2. Carica il carattere che sarà sostituito.
3. Carica il nuovo carattere. 
4. Sostituisci il carattere. 
5. Scrivi la presentazione modificata come file PPTX.

```php
  # Carica una presentazione
  $pres = new Presentation("Fonts.pptx");
  try {
    # Carica il carattere sorgente che sarà sostituito
    $sourceFont = new FontData("Arial");
    # Carica il nuovo carattere
    $destFont = new FontData("Times New Roman");
    # Sostituisce i caratteri
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Salva la presentazione
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Per impostare regole che determinano cosa accade in determinate condizioni (ad esempio se un carattere non è accessibile), consulta [**Sostituzione del carattere**](/slides/it/php-java/font-substitution/).
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra "sostituzione del carattere", "sostituzione del carattere" e "font di fallback"?**

La sostituzione è un passaggio intenzionale da una famiglia all'altra in tutto il documento. [Sostituzione](/slides/it/php-java/font-substitution/) è una regola del tipo "se il carattere non è disponibile, usa X". Il [fallback](/slides/it/php-java/fallback-font/) viene applicato in modo mirato per singoli glifi mancanti quando il carattere di base è installato ma non contiene i caratteri richiesti.

**La sostituzione si applica a master slide, layout, note e commenti?**

Sì. La sostituzione influisce su tutti gli oggetti della presentazione che utilizzano il carattere originale, incluse le master slide e le note; i commenti fanno anche parte del documento e vengono considerati dal motore dei caratteri.

**Il carattere cambierà all'interno di oggetti OLE incorporati (ad esempio, Excel)?**

No. Il [contenuto OLE](/slides/it/php-java/manage-ole/) è controllato dalla propria applicazione. La sostituzione nella presentazione non riformatta i dati OLE interni; possono essere visualizzati come immagine o come contenuto modificabile esternamente.

**Posso sostituire un carattere solo in parte della presentazione (per slide o regioni)?**

La sostituzione mirata è possibile se si modifica il carattere a livello degli oggetti/aree richiesti anziché applicare una sostituzione globale a tutto il documento. La logica complessiva di selezione dei caratteri durante il rendering rimane invariata.

**Come posso determinare in anticipo quali caratteri utilizza la presentazione?**

Utilizza il [font manager] della presentazione (https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/): fornisce un elenco delle [famiglie in uso](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getfonts/) e informazioni sulle [sostituzioni/"font sconosciuti"](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getsubstitutions/), che aiutano a pianificare la sostituzione.

**La sostituzione dei caratteri funziona durante la conversione in PDF/immagini?**

Sì. Durante l'esportazione, Aspose.Slides applica la stessa [sequenza di selezione/sostituzione dei caratteri](/slides/it/php-java/font-selection-sequence/), quindi una sostituzione effettuata in anticipo verrà rispettata durante la conversione.

**Devo installare il carattere di destinazione nel sistema o posso allegare una cartella di caratteri?**

L'installazione non è necessaria: la libreria consente il [caricamento di caratteri esterni](/slides/it/php-java/custom-font/) da cartelle utente per l'uso durante il [rendering e l'esportazione](/slides/it/php-java/convert-powerpoint/).

**La sostituzione correggerà i "tofu" (quadrati) al posto dei caratteri?**

Solo se il carattere di destinazione contiene effettivamente i glifi richiesti. In caso contrario, [configura il fallback](/slides/it/php-java/fallback-font/) per coprire i caratteri mancanti.