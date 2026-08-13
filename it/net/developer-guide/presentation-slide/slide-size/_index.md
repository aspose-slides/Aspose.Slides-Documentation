---
title: Modifica la dimensione della diapositiva della presentazione in .NET
linktitle: Dimensione diapositiva
type: docs
weight: 70
url: /it/net/slide-size/
keywords:
- dimensione diapositiva
- rapporto d'aspetto
- standard
- schermo widescreen
- 4:3
- 16:9
- imposta dimensione diapositiva
- cambia dimensione diapositiva
- dimensione diapositiva personalizzata
- dimensione diapositiva speciale
- dimensione diapositiva unica
- diapositiva a dimensione intera
- tipo di schermo
- non scalare
- garantire adattamento
- massimizzare
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con .NET e Aspose.Slides, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides per .NET fornisce strumenti completi per regolare la dimensione delle diapositive e il rapporto d'aspetto nelle presentazioni PowerPoint, critico sia per la stampa sia per la visualizzazione su schermo. 

Dimensioni e rapporti delle diapositive più comuni:

- **Standard (rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (rapporto 16:9)**: Consigliato per proiettori e display moderni.

Assicurati coerenza in tutta la presentazione, poiché una singola dimensione e rapporto d'aspetto della diapositiva si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni della diapositiva all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="info" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto 4:3 standard.
{{% /alert %}}

## **Come modificare la dimensione della diapositiva in una presentazione**

Questo esempio dimostra come modificare la dimensione della diapositiva di una presentazione con Aspose.Slides in C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Specificare dimensioni personalizzate della diapositiva**

Adattare la dimensione della diapositiva alle proprie esigenze specifiche, ad esempio per layout di carta unici o specifiche dello schermo, può essere vantaggioso. Ecco come impostare una dimensione personalizzata della diapositiva con Aspose.Slides per .NET:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // formato carta A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Gestire il contenuto della diapositiva dopo il ridimensionamento**

Dopo il ridimensionamento, il contenuto delle diapositive può distordersi. Puoi controllare come Aspose.Slides gestisce questo ridimensionamento:

- **`DoNotScale`**: Mantieni gli oggetti alle dimensioni originali per evitare il ridimensionamento.
- **`EnsureFit`**: Scala gli oggetti per adattarli a diapositive più piccole, prevenendo la perdita di contenuto.
- **`Maximize`**: Ingrandisci gli oggetti per adeguarli a diapositive più grandi per mantenere la coerenza estetica.

Esempio di utilizzo dell'impostazione `Maximize` per la regolazione della dimensione della diapositiva:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

### Posso impostare una dimensione personalizzata della diapositiva usando unità diverse da pollici (ad esempio, punti o millimetri)?

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto corrisponde a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e usare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

### Una dimensione personalizzata della diapositiva molto grande influirà sulle prestazioni e sull'utilizzo della memoria durante il rendering?

Sì. Dimensioni della diapositiva più grandi (in punti) combinate con una scala di rendering più alta comportano un aumento del consumo di memoria e tempi di elaborazione più lunghi. Punta a una dimensione pratica della diapositiva e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

### Posso definire una dimensione non standard della diapositiva e poi unire diapositive da presentazioni con dimensioni diverse?

Non è possibile [unire le presentazioni](/slides/it/net/merge-presentation/) quando hanno dimensioni di diapositiva diverse — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/net/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive mantenendo la formattazione.

### Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione della diapositiva?

Sì. Aspose.Slides può generare miniature per [intere diapositive](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage/) così come per [forme selezionate](https://reference.aspose.com/slides/it/net/aspose.slides/shape/getimage/). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto corrente della diapositiva, garantendo una composizione e una geometria coerenti.