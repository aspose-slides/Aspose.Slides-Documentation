---
title: Cambia le dimensioni della diapositiva della presentazione in C++
linktitle: Dimensione diapositiva
type: docs
weight: 70
url: /it/cpp/slide-size/
keywords:
- dimensione diapositiva
- rapporto d'aspetto
- standard
- schermo panoramico
- 4:3
- 16:9
- imposta dimensione diapositiva
- cambia dimensione diapositiva
- dimensione diapositiva personalizzata
- dimensione diapositiva speciale
- dimensione diapositiva unica
- diapositiva a grandezza piena
- tipo di schermo
- non scalare
- garantire adattamento
- massimizzare
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Impara come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con C++ e Aspose.Slides, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare le dimensioni delle diapositive e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentale sia per la stampa sia per la visualizzazione su schermo. 

Dimensioni e rapporti delle diapositive più comuni:

- **Standard (rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (rapporto 16:9)**: Raccomandato per proiettori e display moderni.

Assicurati coerenza in tutta la presentazione poiché una singola dimensione e rapporto d'aspetto della diapositiva si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni della diapositiva all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="info" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto standard 4:3.
{{% /alert %}}

## **Modifica la dimensione della diapositiva nelle presentazioni**

Questo esempio di codice mostra come modificare la dimensione della diapositiva in una presentazione C++ utilizzando Aspose.Slides:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Specifica dimensioni personalizzate della diapositiva nelle presentazioni**

Se trovi che le dimensioni standard delle diapositive (4:3 e 16:9) non siano adatte al tuo lavoro, potresti decidere di utilizzare una dimensione specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale dalla tua presentazione su un layout di pagina personalizzato o se intendi visualizzare la tua presentazione su determinati tipi di schermo, è probabile che tu tragga beneficio dall'utilizzare un'impostazione di dimensione personalizzata per la presentazione. 

Questo esempio di codice mostra come utilizzare Aspose.Slides per C++ per specificare una dimensione personalizzata della diapositiva in una presentazione C++:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Formato carta A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Gestisci il contenuto della diapositiva dopo il ridimensionamento**

Dopo aver modificato la dimensione della diapositiva di una presentazione, il contenuto delle diapositive (immagini o oggetti, ad esempio) può risultare distorto. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, durante il cambiamento della dimensione della diapositiva, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti sulle diapositive.

A seconda di ciò che intendi fare o ottenere, puoi utilizzare una delle seguenti impostazioni:

- `DoNotScale`

  Se NON vuoi che gli oggetti sulle diapositive vengano ridimensionati, usa questa impostazione.

- `EnsureFit`

  Se desideri ridimensionare a una dimensione della diapositiva più piccola e hai bisogno che Aspose.Slides riduca gli oggetti delle diapositive per garantire che tutti si adattino alle diapositive (in questo modo eviti la perdita di contenuti), usa questa impostazione. 

- `Maximize`

  Se desideri ridimensionare a una dimensione della diapositiva più grande e hai bisogno che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione, usa questa impostazione. 

Questo esempio di codice mostra come utilizzare l'impostazione `Maximize` quando si modifica la dimensione della diapositiva di una presentazione:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **Domande frequenti**

### Posso impostare una dimensione personalizzata della diapositiva usando unità diverse da pollici (ad esempio, punti o millimetri)?

Sì. Aspose.Slides utilizza internamente i punti, dove 1 punto equivale a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

### Una dimensione molto grande della diapositiva personalizzata influenzerà le prestazioni e l'utilizzo della memoria durante il rendering?

Sì. Dimensioni più grandi della diapositiva (in punti) combinate con una scala di rendering più alta comportano un aumento del consumo di memoria e tempi di elaborazione più lunghi. Mira a una dimensione pratica della diapositiva e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

### Posso definire una dimensione della diapositiva non standard e poi unire diapositive da presentazioni con dimensioni diverse?

Non è possibile [unire presentazioni](/slides/it/cpp/merge-presentation/) quando hanno dimensioni di diapositiva diverse — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire i contenuti esistenti tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive preservando la formattazione.

### Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispettano la nuova dimensione della diapositiva?

Sì. Aspose.Slides può generare miniature per [tutte le diapositive](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/getimage/) così come per le [forme selezionate](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/getimage/). Le immagini risultanti riflettono la dimensione corrente della diapositiva e il rapporto d'aspetto, garantendo un'inquadratura e una geometria coerenti.