---
title: Modifica la dimensione della diapositiva della presentazione in C++
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
- diapositiva a grandezza naturale
- tipo di schermo
- non ridimensionare
- adatta
- massimizza
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con C++ e Aspose.Slides, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare la dimensione delle diapositive e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentali sia per la stampa che per la visualizzazione su schermo. 

Dimensioni e rapporti d'aspetto più comuni:

- **Standard (rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (rapporto 16:9)**: Consigliato per proiettori e display moderni.

Assicurati che la presentazione sia coerente, poiché una singola dimensione della diapositiva e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni delle diapositive all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="info" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides usano il rapporto 4:3 standard.
{{% /alert %}}

Le pagine di note e di dispense hanno dimensioni separate dalle diapositive normali. Consulta [Notes Page Size](/slides/it/cpp/notes-size/) per modificare dimensione e orientamento.

## **Modifica la dimensione della diapositiva nelle presentazioni**

 Questo esempio di codice mostra come modificare la dimensione della diapositiva in una presentazione C++ usando Aspose.Slides:

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

## **Specificare dimensioni personalizzate della diapositiva nelle presentazioni**

Se le dimensioni di diapositiva comuni (4:3 e 16:9) non sono adatte al tuo lavoro, potresti decidere di utilizzare una dimensione specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale da una presentazione su un layout di pagina personalizzato o se intendi visualizzare la presentazione su determinati tipi di schermo, potresti trarre vantaggio dall'impostare una dimensione personalizzata per la presentazione. 

Questo esempio di codice mostra come usare Aspose.Slides per C++ per specificare una dimensione personalizzata della diapositiva in C++:

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

## **Gestire il contenuto della diapositiva dopo il ridimensionamento**

Dopo aver modificato la dimensione della diapositiva di una presentazione, il contenuto delle diapositive (immagini o oggetti, ad esempio) potrebbe risultare distorto. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, quando cambi la dimensione della diapositiva di una presentazione, puoi specificare un'impostazione che determina come Aspose.Slides gestisce il contenuto delle diapositive.

A seconda di ciò che intendi fare o ottenere, puoi utilizzare una di queste impostazioni:

- `DoNotScale`

  Se NON desideri che gli oggetti sulle diapositive vengano ridimensionati, usa questa impostazione.

- `EnsureFit`

  Se desideri ridurre a una dimensione di diapositiva più piccola e vuoi che Aspose.Slides riduca gli oggetti delle diapositive per assicurarsi che tutti siano contenuti (così eviti la perdita di contenuto), usa questa impostazione. 

- `Maximize`

  Se desideri aumentare a una dimensione di diapositiva più grande e vuoi che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione, usa questa impostazione. 

Questo esempio di codice mostra come usare l'impostazione `Maximize` quando si cambia la dimensione della diapositiva di una presentazione:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

### Posso impostare una dimensione di diapositiva personalizzata usando unità diverse da pollici (ad esempio punti o millimetri)?

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto equivale a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e usare i valori convertiti per definire larghezza e altezza della diapositiva.

### Una dimensione di diapositiva personalizzata molto grande influirà sulle prestazioni e sull'utilizzo della memoria durante il rendering?

Sì. Dimensioni di diapositiva più grandi (in punti) combinate con una scala di rendering più elevata comportano un aumento del consumo di memoria e tempi di elaborazione più lunghi. Mira a una dimensione pratica delle diapositive e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

### Posso definire una dimensione di diapositiva non standard e poi unire diapositive da presentazioni con dimensioni diverse?

Non è possibile [merge presentations](/slides/it/cpp/merge-presentation/) quando hanno dimensioni diverse — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive preservando la formattazione.

### Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione della diapositiva?

Sì. Aspose.Slides può generare miniature per [diapositive intere](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/getimage/) così come per [forme selezionate](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/getimage/). Le immagini risultanti riflettono la dimensione corrente della diapositiva e il rapporto d'aspetto, garantendo inquadrature e geometrie coerenti.