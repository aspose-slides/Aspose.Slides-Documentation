---
title: Modifica le dimensioni della diapositiva della presentazione in .NET
linktitle: Dimensione Diapositiva
type: docs
weight: 70
url: /it/net/slide-size/
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
- diapositiva a dimensione piena
- tipo schermo
- non scalare
- garantire adattamento
- massimizzare
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con .NET e Aspose.Slides, ottimizzare le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides per .NET fornisce strumenti completi per regolare le dimensioni delle diapositive e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentali sia per la stampa che per la visualizzazione su schermo. 

Dimensioni delle diapositive più comuni e rapporti:

- **Standard (rapporto d'aspetto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (rapporto d'aspetto 16:9)**: Consigliato per proiettori e display moderni.

Assicurati la coerenza in tutta la presentazione poiché una singola dimensione della diapositiva e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni delle diapositive all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="info" %}} 
Di default, le presentazioni create con Aspose.Slides utilizzano il rapporto d'aspetto standard 4:3.
{{% /alert %}}

Le pagine delle note e dei dispense hanno dimensioni separate dalle diapositive normali. Vedi [Notes Page Size](/slides/it/net/notes-size/) per modificare le loro dimensioni e orientamento.

## **Come modificare le dimensioni della diapositiva in una presentazione**

Questo esempio dimostra come modificare le dimensioni della diapositiva di una presentazione con Aspose.Slides in C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Specificare dimensioni personalizzate delle diapositive**

Personalizzare le dimensioni della diapositiva in base alle proprie esigenze specifiche, ad esempio per layout di carta unici o specifiche dello schermo, può essere vantaggioso. Ecco come impostare una dimensione personalizzata della diapositiva con Aspose.Slides per .NET:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Formato carta A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Gestire il contenuto della diapositiva dopo il ridimensionamento**

Dopo il ridimensionamento, il contenuto delle diapositive potrebbe deformarsi. Puoi controllare come Aspose.Slides gestisce questo ridimensionamento:

- **`DoNotScale`**: Mantieni gli oggetti alle dimensioni originali per evitare il ridimensionamento.
- **`EnsureFit`**: Ridimensiona gli oggetti per adattarli a diapositive più piccole, evitando la perdita di contenuto.
- **`Maximize`**: Ingrandisci gli oggetti per adattarli a diapositive più grandi, garantendo coerenza estetica.

Esempio di utilizzo dell'impostazione `Maximize` per la regolazione delle dimensioni della diapositiva:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

### Posso impostare una dimensione personalizzata della diapositiva utilizzando unità diverse dai pollici (ad esempio, punti o millimetri)?

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto equivale a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

### Una dimensione personalizzata della diapositiva molto grande influirà sulle prestazioni e sull'uso della memoria durante il rendering?

Sì. Dimensioni della diapositiva più grandi (in punti) combinate con una scala di rendering più alta portano a un maggiore consumo di memoria e a tempi di elaborazione più lunghi. Mira a una dimensione della diapositiva pratica e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

### Posso definire una dimensione della diapositiva non standard e poi unire diapositive da presentazioni che hanno dimensioni diverse?

Non è possibile [unire presentazioni](/slides/it/net/merge-presentation/) quando hanno dimensioni della diapositiva diverse — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/net/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive conservando la formattazione.

### Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione della diapositiva?

Sì. Aspose.Slides può rendere miniature per [diapositive intere](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage/) così come per [forme selezionate](https://reference.aspose.com/slides/it/net/aspose.slides/shape/getimage/). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo una cornatura e una geometria coerenti.