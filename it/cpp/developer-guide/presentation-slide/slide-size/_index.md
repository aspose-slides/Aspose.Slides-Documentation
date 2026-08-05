---
title: Modifica le dimensioni della diapositiva della presentazione in C++
linktitle: Dimensione diapositiva
type: docs
weight: 70
url: /it/cpp/slide-size/
keywords:
- dimensione diapositiva
- rapporto d'aspetto
- standard
- schermo largo
- 4:3
- 16:9
- imposta dimensione diapositiva
- cambia dimensione diapositiva
- dimensione diapositiva personalizzata
- dimensione diapositiva speciale
- dimensione diapositiva unica
- diapositiva a piena dimensione
- tipo di schermo
- non scalare
- assicurura adattamento
- massimizza
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con C++ e Aspose.Slides, ottimizzare le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides offre strumenti completi per regolare le dimensioni delle diapositive e il rapporto d'aspetto nelle presentazioni PowerPoint, critici sia per la stampa che per la visualizzazione su schermo. 

Dimensioni e rapporti d'aspetto delle diapositive più comuni:

- **Standard (rapporto d'aspetto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (rapporto d'aspetto 16:9)**: Consigliato per proiettori e display moderni.

Assicurati la coerenza in tutta la presentazione poiché una singola dimensione e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni delle diapositive all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="primary" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides usano il rapporto d'aspetto standard 4:3.
{{% /alert %}}

## **Modifica la dimensione della diapositiva nelle presentazioni**

Questo esempio di codice mostra come modificare la dimensione della diapositiva in una presentazione in C++ utilizzando Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Specifica dimensioni personalizzate delle diapositive nelle presentazioni**

Se trovi le dimensioni di diapositiva comuni (4:3 e 16:9) inadeguate per il tuo lavoro, potresti decidere di utilizzare una dimensione di diapositiva specifica o unica. Ad esempio, se prevedi di stampare diapositive a piena dimensione dalla tua presentazione su un layout di pagina personalizzato o se intendi visualizzare la tua presentazione su determinati tipi di schermo, potresti trarre vantaggio dall'utilizzare un'impostazione di dimensione personalizzata per la tua presentazione. 

Questo esempio di codice mostra come utilizzare Aspose.Slides per C++ per specificare una dimensione di diapositiva personalizzata per una presentazione in C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Formato carta A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Gestisci il contenuto della diapositiva dopo il ridimensionamento**

Dopo aver modificato la dimensione della diapositiva di una presentazione, i contenuti delle diapositive (immagini o oggetti, ad esempio) possono distorcersi. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, quando si cambia la dimensione della diapositiva di una presentazione, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti sulle diapositive.

A seconda di ciò che intendi fare o ottenere, puoi utilizzare una di queste impostazioni:

- `DoNotScale`

  Se NON vuoi che gli oggetti sulle diapositive vengano ridimensionati, usa questa impostazione.

- `EnsureFit`

  Se vuoi ridimensionare a una dimensione di diapositiva più piccola e hai bisogno che Aspose.Slides riduca gli oggetti delle diapositive per garantire che tutti si adattino alle diapositive (in questo modo eviti di perdere contenuti), usa questa impostazione. 

- `Maximize`

  Se vuoi ridimensionare a una dimensione di diapositiva più grande e hai bisogno che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione, usa questa impostazione. 

Questo esempio di codice mostra come utilizzare l'impostazione `Maximize` quando si modifica la dimensione della diapositiva di una presentazione:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

**Can I set a custom slide size using units other than inches (for example, points or millimeters)?**

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto equivale a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

**Will a very large custom slide size affect performance and memory usage during rendering?**

Sì. Dimensioni di diapositiva più grandi (in punti) combinate con una scala di rendering più alta comportano un aumento del consumo di memoria e tempi di elaborazione più lunghi. Mira a una dimensione di diapositiva pratica e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

**Can I define one non-standard slide size and then merge slides from presentations that have different sizes?**

Non è possibile [merge presentations](/slides/it/cpp/merge-presentation/) quando hanno dimensioni di diapositiva diverse — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire i contenuti esistenti tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive preservando la formattazione.

**Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?**

Sì. Aspose.Slides può generare miniature per [entire slides](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/getimage/) così come per [selected shapes](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/getimage/). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo una cornice e una geometria coerenti.