---
title: Renderizzare le diapositive di presentazione come immagini SVG in C++
linktitle: Diapositiva in SVG
type: docs
weight: 50
url: /it/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- salva PPT come SVG
- salva PPTX come SVG
- esporta PPT in SVG
- esporta PPTX in SVG
- renderizza diapositiva
- converti diapositiva
- esporta diapositiva
- immagine vettoriale
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come renderizzare le diapositive PowerPoint come immagini SVG utilizzando Aspose.Slides per C++. Visuali di alta qualità con semplici esempi di codice."
---
## **Panoramica**

Questo articolo spiega come renderizzare le diapositive di una presentazione come immagini SVG utilizzando Aspose.Slides. Descrive il formato SVG e i suoi vantaggi, inclusi scalabilità, accessibilità e idoneità per lo sviluppo web.

Imparerai come caricare un file di presentazione, scorrere le sue diapositive e salvare ogni diapositiva come file SVG separato. L'articolo copre i formati di presentazione PowerPoint e OpenDocument, inclusi PPT, PPTX, ODP e PPS, e mostra come eseguire la conversione programmaticamente con la classe `Presentation` e il metodo `WriteAsSvg`.

## **Formato SVG**

SVG, acronimo di Scalable Vector Graphics, è un tipo o formato grafico standard utilizzato per renderizzare immagini bidimensionali. SVG memorizza le immagini come vettori in XML con dettagli che ne definiscono il comportamento o l'aspetto.

SVG è uno dei pochi formati per immagini che soddisfa standard molto elevati in termini di scalabilità, interattività, prestazioni, accessibilità, programmabilità e altri. Per questi motivi è comunemente usato nello sviluppo web.

Potresti voler utilizzare file SVG quando è necessario

- **stampa la tua presentazione in un *formato molto grande***. Le immagini SVG possono scalare a qualsiasi risoluzione o livello. Puoi ridimensionare le immagini SVG tutte le volte necessarie senza sacrificare la qualità.
- **usa grafici e diagrammi delle tue diapositive in *diversi supporti o piattaforme***. La maggior parte dei lettori può interpretare i file SVG. 
- **usa le *dimensioni più piccole possibili per le immagini***. I file SVG sono generalmente più piccoli delle loro controparti ad alta risoluzione in altri formati, soprattutto quelli basati su bitmap (JPEG o PNG).

## **Renderizzare una Diapositiva come Immagine SVG**

Aspose.Slides per C++ consente di esportare le diapositive delle tue presentazioni come immagini SVG. Segui questi passaggi per generare le immagini SVG:

1. Crea un'istanza della classe Presentation.
2. Scorri tutte le diapositive nella presentazione.
3. Scrivi ogni diapositiva nel proprio file SVG tramite FileStream.

{{% alert color="primary" %}} 

Potresti provare la nostra [applicazione web gratuita](https://products.aspose.app/slides/it/conversion/ppt-to-svg) in cui abbiamo implementato la funzione di conversione da PPT a SVG di Aspose.Slides per C++.

{{% /alert %}} 

Questo codice di esempio in C++ mostra come convertire PPT in SVG utilizzando Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```

## **Domande frequenti**

**Perché l'SVG risultante può apparire diverso nei diversi browser?**

Il supporto per specifiche funzionalità SVG è implementato diversamente dai motori dei browser. I parametri [SVGOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/) aiutano a mitigare le incompatibilità.

**È possibile esportare non solo le diapositive ma anche singole forme in SVG?**

Sì. Qualunque [qualunque forma può essere salvata come SVG separato](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/writeassvg/), il che è comodo per icone, pittogrammi e riutilizzo di grafiche.

**È possibile combinare più diapositive in un unico SVG (striscia/documento)?**

Lo scenario standard è una diapositiva → un SVG. Combinare più diapositive in un unico canvas SVG è un passaggio di post‑processing effettuato a livello applicativo.