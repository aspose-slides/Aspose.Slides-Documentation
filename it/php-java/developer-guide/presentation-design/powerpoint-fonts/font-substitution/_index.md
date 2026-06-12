---
title: "Configura la sostituzione dei font nelle presentazioni usando PHP"
linktitle: "Sostituzione dei font"
type: docs
weight: 70
url: /it/php-java/font-substitution/
keywords:
- font
- sostituzione font
- sostituzione dei font
- sostituzione font
- sostituzione dei font
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Abilita una sostituzione ottimale dei font in Aspose.Slides per PHP tramite Java durante la conversione di presentazioni PowerPoint e OpenDocument in altri formati di file."
---
## **Introduzione**

La sostituzione dei font consente a Aspose.Slides di utilizzare un altro font quando il font originale della presentazione non è disponibile durante il rendering o la conversione. È possibile verificare quali font sono stati sostituiti utilizzando il metodo `getSubstitutions` della classe `FontsManager`.

Aspose.Slides consente anche di definire regole di sostituzione dei font. Ad esempio, è possibile specificare che un font non accessibile debba essere sostituito con un altro font disponibile e quindi applicare tali regole tramite il gestore dei font della presentazione.

## **Impostare le regole di sostituzione dei font**

Aspose.Slides consente di impostare regole per i font che determinano cosa fare in determinate condizioni (ad esempio, quando un font non può essere accesso) in questo modo:

1. Carica la presentazione pertinente.
2. Carica il font che verrà sostituito.
3. Carica il nuovo font.
4. Aggiungi una regola per la sostituzione.
5. Aggiungi la regola alla raccolta di regole di sostituzione dei font della presentazione.
6. Genera l'immagine della diapositiva per osservare l'effetto.

Questo codice PHP dimostra il processo di sostituzione dei font:

```php
  # Carica una presentazione
  $pres = new Presentation("Fonts.pptx");
  try {
    # Carica il font di origine che verrà sostituito
    $sourceFont = new FontData("SomeRareFont");
    # Carica il nuovo font
    $destFont = new FontData("Arial");
    # Aggiunge una regola di font per la sostituzione del font
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Aggiunge la regola alla raccolta di regole di sostituzione dei font
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Aggiunge una raccolta di regole di font all'elenco delle regole
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Il font Arial verrà usato al posto di SomeRareFont quando quest'ultimo non è accessibile
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Salva l'immagine su disco nel formato JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert title="NOTE"  color="warning"   %}} 

Potresti voler vedere [**Sostituzione dei font**](/slides/it/php-java/font-replacement/).

{{% /alert %}}

## **Limitazioni per i font delle equazioni matematiche**

Le regole di sostituzione dei font partecipano al processo standard di selezione dei font utilizzato durante il rendering e la conversione. Sono adatte per scenari di testo regolare in cui Aspose.Slides può sostituire un font non accessibile con un altro font disponibile secondo la regola configurata.

Tuttavia, le equazioni matematiche di Office hanno una limitazione importante. Se un’equazione è stata creata con **Cambria Math**, Aspose.Slides potrebbe comunque richiedere il font originale **Cambria Math** per calcolare e rendere correttamente il layout dell’equazione. Per questo motivo, la sostituzione di **Cambria Math** con un altro font matematico, come **STIX Two Math**, non è supportata per il rendering delle equazioni e potrebbe comunque generare un’eccezione che indica che **Cambria Math** è necessario.

Per convertire correttamente tali presentazioni, assicurati che **Cambria Math** sia disponibile per Aspose.Slides a runtime. Puoi installare il font nel sistema operativo o fornire un [font esterno](/slides/it/php-java/custom-font/) in modo che partecipi al normale processo di selezione dei font durante il rendering e la conversione.

Questa limitazione è specifica per il rendering delle equazioni. Le regole di sostituzione dei font standard descritte sopra continuano ad applicarsi al testo regolare della presentazione quando il font originale non è accessibile.

## **FAQ**

**Qual è la differenza tra sostituzione del font e sostituzione dei font?**

[Replacement](/slides/it/php-java/font-replacement/) è una sovrascrittura forzata di un font con un altro su tutta la presentazione. La sostituzione è una regola che si attiva in una condizione specifica, ad esempio quando il font originale non è disponibile, e quindi viene utilizzato un font di fallback designato.

**Quando vengono applicate esattamente le regole di sostituzione?**

Le regole partecipano alla sequenza standard di [selezione dei font](/slides/it/php-java/font-selection-sequence/) che viene valutata durante il caricamento, il rendering e la conversione; se il font scelto non è disponibile, viene applicata la sostituzione o il rimpiazzo.

**Qual è il comportamento predefinito se né la sostituzione né la sostituzione sono configurate e il font manca nel sistema?**

La libreria cercherà di scegliere il font di sistema più vicino disponibile, similmente a come si comporterebbe PowerPoint.

**Posso allegare font esterni personalizzati a runtime per evitare la sostituzione?**

Sì. È possibile [aggiungere font esterni](/slides/it/php-java/custom-font/) a runtime in modo che la libreria li consideri per la selezione e il rendering, inclusa la conversione successiva.

**Aspose distribuisce font con la libreria?**

No. Aspose non distribuisce font a pagamento o gratuiti; aggiungi e utilizzi i font a tua discrezione e responsabilità.

**Esistono differenze nel comportamento della sostituzione su Windows, Linux e macOS?**

Sì. La scoperta dei font inizia dalle directory dei font del sistema operativo. L'insieme dei font disponibili per impostazione predefinita e i percorsi di ricerca differiscono tra le piattaforme, il che influisce sulla disponibilità e sulla necessità di sostituzione.

**Come dovrei preparare l'ambiente per ridurre al minimo le sostituzioni inaspettate durante conversioni batch?**

Sincronizza l'insieme di font tra macchine o contenitori, [aggiungi i font esterni](/slides/it/php-java/custom-font/) richiesti per i documenti di output e [incorpora i font](/slides/it/php-java/embedded-font/) nelle presentazioni quando possibile, così i font scelti sono disponibili durante il rendering.