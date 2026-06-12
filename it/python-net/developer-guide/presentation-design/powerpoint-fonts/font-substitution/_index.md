---
title: Configura la sostituzione dei caratteri nelle presentazioni con Python
linktitle: Sostituzione dei caratteri
type: docs
weight: 70
url: /it/python-net/font-substitution/
keywords:
- carattere
- sostituzione carattere
- sostituzione del carattere
- sostituisci carattere
- sostituzione del carattere
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Abilita una sostituzione ottimale dei caratteri in Aspose.Slides per Python tramite .NET quando converti presentazioni PowerPoint e OpenDocument in altri formati di file."
---
## **Panoramica**

La sostituzione dei caratteri consente a Aspose.Slides di utilizzare un altro carattere quando il carattere originale della presentazione non è disponibile durante il rendering o la conversione. È possibile verificare quali caratteri sono stati sostituiti utilizzando il metodo `get_substitutions` della classe `FontsManager`.

Aspose.Slides consente anche di definire regole di sostituzione dei caratteri. Ad esempio, è possibile specificare che un carattere non accessibile debba essere sostituito con un altro carattere disponibile e quindi applicare tali regole tramite il gestore dei caratteri della presentazione.

## **Imposta regole di sostituzione**

Aspose.Slides consente di impostare regole per i caratteri che determinano cosa fare in determinate condizioni (ad esempio, quando un carattere non può essere accesso) in questo modo:

1. Caricare la presentazione pertinente.  
2. Caricare il carattere che sarà sostituito.  
3. Caricare il nuovo carattere.  
4. Aggiungere una regola per la sostituzione.  
5. Aggiungere la regola alla collezione di regole di sostituzione dei caratteri della presentazione.  
6. Generare l'immagine della diapositiva per osservare l'effetto.  

Questo codice Python dimostra il processo di sostituzione dei caratteri:

```python
import aspose.slides as slides

# Carica una presentazione
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Carica il carattere sorgente che verrà sostituito
    sourceFont = slides.FontData("SomeRareFont")

    # Carica il nuovo carattere
    destFont = slides.FontData("Arial")

    # Aggiunge una regola di font per la sostituzione
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Aggiunge la regola alla collezione di regole di sostituzione dei font
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Aggiunge la collezione di regole di font all'elenco delle regole
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #    Il carattere Arial verrà utilizzato al posto di SomeRareFont quando quest'ultimo non è accessibile
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Salva l'immagine su disco in formato JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 
Potresti voler vedere [**Sostituzione dei caratteri**](/slides/it/python-net/font-replacement/). 
{{% /alert %}}

## **Limitazioni per i caratteri delle equazioni matematiche**

Le regole di sostituzione dei caratteri partecipano al processo standard di selezione dei caratteri utilizzato durante il rendering e la conversione. Sono adatte per scenari di testo normale in cui Aspose.Slides può sostituire un carattere non accessibile con un altro carattere disponibile secondo la regola configurata.

Tuttavia, le equazioni matematiche di Office hanno una limitazione importante. Se un'equazione è stata creata con **Cambria Math**, Aspose.Slides potrebbe comunque richiedere il carattere originale **Cambria Math** per calcolare e renderizzare correttamente il layout dell'equazione. Per questo motivo, la sostituzione di **Cambria Math** con un altro carattere matematico, come **STIX Two Math**, non è supportata per il rendering delle equazioni e potrebbe comunque generare un'eccezione che indica che **Cambria Math** è richiesto.

Per convertire correttamente queste presentazioni, assicurati che **Cambria Math** sia disponibile per Aspose.Slides al momento dell'esecuzione. Puoi installare il carattere nel sistema operativo o fornirlo come [font esterno](/slides/it/python-net/custom-font/) in modo che possa partecipare al normale processo di selezione dei caratteri durante il rendering e la conversione.

Questa limitazione è specifica per il rendering delle equazioni. Le regole standard di sostituzione dei caratteri descritte sopra si applicano ancora al testo normale della presentazione quando il carattere originale non è accessibile.

## **FAQ**

**Qual è la differenza tra font replacement e font substitution?**  
[Replacement](/slides/it/python-net/font-replacement/) è una sovrascrittura forzata di un carattere con un altro in tutta la presentazione. La sostituzione è una regola che si attiva in una condizione specifica, ad esempio quando il carattere originale non è disponibile, e in tal caso viene utilizzato un carattere di fallback designato.

**Quando vengono applicate esattamente le regole di sostituzione?**  
Le regole partecipano alla sequenza standard di [selezione del carattere](/slides/it/python-net/font-selection-sequence/) che viene valutata durante il caricamento, il rendering e la conversione; se il carattere scelto non è disponibile, viene applicata la replacement o la substitution.

**Qual è il comportamento predefinito se né la replacement né la substitution sono configurate e il carattere è mancante sul sistema?**  
La libreria cercherà di scegliere il carattere di sistema più vicino disponibile, in modo simile a come si comporterebbe PowerPoint.

**Posso allegare font esterni personalizzati a runtime per evitare la sostituzione?**  
Sì. È possibile [aggiungere font esterni](/slides/it/python-net/custom-font/) a runtime in modo che la libreria li consideri per la selezione e il rendering, anche per le conversioni successive.

**Aspose distribuisce alcuni font con la libreria?**  
No. Aspose non distribuisce font a pagamento o gratuiti; aggiungi e utilizzi i font a tua discrezione e responsabilità.

**Ci sono differenze nel comportamento della substitution su Windows, Linux e macOS?**  
Sì. La scoperta dei font inizia dalle directory dei font del sistema operativo. Il set di font disponibili di default e i percorsi di ricerca differiscono tra le piattaforme, il che influisce sulla disponibilità e sulla necessità di substitution.

**Come dovrei preparare l'ambiente per minimizzare le substitution inattese durante le conversioni batch?**  
Sincronizza il set di font tra macchine o container, [aggiungi i font esterni](/slides/it/python-net/custom-font/) richiesti per i documenti di output, e [incorpora i font](/slides/it/python-net/embedded-font/) nelle presentazioni quando possibile affinché i font selezionati siano disponibili durante il rendering.