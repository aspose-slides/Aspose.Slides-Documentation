---
title: Cambia la dimensione della diapositiva della presentazione in C++
linktitle: Dimensione della diapositiva
type: docs
weight: 70
url: /it/cpp/slide-size/
keywords:
- dimensione diapositiva
- rapporto d'aspetto
- standard
- widescreen
- 4:3
- 16:9
- imposta dimensione diapositiva
- cambia dimensione diapositiva
- dimensione diapositiva personalizzata
- dimensione diapositiva speciale
- dimensione diapositiva unica
- diapositiva a dimensione piena
- tipo di schermo
- non scalare
- assicurare adattamento
- massimizzare
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
descriptions: "Impara a ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con C++ e Aspose.Slides, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare le dimensioni della diapositiva e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentali sia per la stampa che per la visualizzazione su schermo. 

Dimensioni diapositive più comuni e rapporti:

- **Standard (rapporto d'aspetto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (rapporto d'aspetto 16:9)**: Consigliato per proiettori e display moderni.

Assicurati coerenza in tutta la presentazione poiché una singola dimensione della diapositiva e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni delle diapositive all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="primary" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto d'aspetto standard 4:3.
{{% /alert %}}

## **Modifica le dimensioni della diapositiva nelle presentazioni**

Questo esempio di codice mostra come modificare le dimensioni della diapositiva in una presentazione in C++ utilizzando Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Specifica dimensioni diapositive personalizzate nelle presentazioni**

Se trovi le dimensioni diapositive comuni (4:3 e 16:9) inadatte al tuo lavoro, potresti decidere di utilizzare una dimensione di diapositiva specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale dalla tua presentazione su un layout di pagina personalizzato o se intendi visualizzare la presentazione su determinati tipi di schermo, potresti trarre vantaggio dall'utilizzare un'impostazione di dimensione personalizzata per la tua presentazione. 

Questo esempio di codice mostra come utilizzare Aspose.Slides per C++ per specificare una dimensione di diapositiva personalizzata per una presentazione in C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Dimensione carta A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Gestisci il contenuto della diapositiva dopo il ridimensionamento**

Dopo aver modificato la dimensione della diapositiva di una presentazione, il contenuto delle diapositive (ad esempio immagini o oggetti) può diventare distorto. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, durante il cambiamento della dimensione della diapositiva di una presentazione, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti sulle diapositive.

A seconda di ciò che intendi fare o ottenere, puoi utilizzare una delle seguenti impostazioni:

- `DoNotScale`

  Se NON desideri che gli oggetti sulle diapositive vengano ridimensionati, usa questa impostazione.

- `EnsureFit`

  Se vuoi ridimensionare a una diapositiva più piccola e hai bisogno che Aspose.Slides riduca gli oggetti delle diapositive per garantire che tutti siano contenuti nelle diapositive (in questo modo eviti la perdita di contenuto), usa questa impostazione. 

- `Maximize`

  Se vuoi ridimensionare a una diapositiva più grande e hai bisogno che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione della diapositiva, usa questa impostazione. 

Questo esempio di codice mostra come utilizzare l'impostazione `Maximize` durante la modifica della dimensione della diapositiva di una presentazione:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

**Posso impostare una dimensione di diapositiva personalizzata usando unità diverse dagli pollici (ad esempio punti o millimetri)?**

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto equivale a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

**Una dimensione di diapositiva personalizzata molto grande influirà sulle prestazioni e sull'utilizzo della memoria durante il rendering?**

Sì. Dimensioni della diapositiva più grandi (in punti) combinate con una scala di rendering più elevata comportano un maggiore consumo di memoria e tempi di elaborazione più lunghi. Mira a una dimensione pratica della diapositiva e regola la scala di rendering solo se necessario per ottenere la qualità di output desiderata.

**Posso definire una dimensione di diapositiva non standard e poi unire diapositive da presentazioni con dimensioni diverse?**

Non è possibile [unire le presentazioni](/slides/it/cpp/merge-presentation/) quando hanno dimensioni di diapositive differenti — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive mantenendo la formattazione.

**Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione della diapositiva?**

Sì. Aspose.Slides può generare miniature per [intere diapositive](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/getimage/) così come per [forme selezionate](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/getimage/). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo un inquadramento e una geometria coerenti.