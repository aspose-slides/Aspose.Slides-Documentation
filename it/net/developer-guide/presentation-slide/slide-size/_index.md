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
- formato widescreen
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
- adatta
- massimizza
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
descriptions: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con .NET e Aspose.Slides, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides for .NET offre strumenti completi per regolare le dimensioni della diapositiva e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentali sia per la stampa sia per la visualizzazione su schermo. 

Dimensioni diapositive e rapporti più comuni:

- **Standard (rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (rapporto 16:9)**: Consigliato per proiettori e display moderni.

Assicurati che la tua presentazione sia coerente poiché una singola dimensione della diapositiva e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni della diapositiva all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="primary" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto 4:3 standard.
{{% /alert %}}

## **Come modificare le dimensioni della diapositiva in una presentazione**

Questo esempio dimostra come modificare le dimensioni della diapositiva di una presentazione con Aspose.Slides in C#:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Specifica dimensioni diapositive personalizzate**

Adattare le dimensioni della diapositiva alle tue esigenze specifiche, ad esempio per layout di carta unici o specifiche dello schermo, può essere vantaggioso. Ecco come impostare una dimensione di diapositiva personalizzata con Aspose.Slides per .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Formato carta A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Gestisci il contenuto della diapositiva dopo il ridimensionamento**

Dopo il ridimensionamento, i contenuti delle diapositive possono deformarsi. Puoi controllare come Aspose.Slides gestisce questo ridimensionamento:

- **`DoNotScale`**: Mantieni gli oggetti alle dimensioni originali per evitare il ridimensionamento.
- **`EnsureFit`**: Scala gli oggetti per adattarli a diapositive più piccole, prevenendo la perdita di contenuto.
- **`Maximize`**: Ingrandisce gli oggetti per adattarli a diapositive più grandi, garantendo coerenza estetica.

Esempio di utilizzo dell'impostazione `Maximize` per la regolazione delle dimensioni della diapositiva:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

**Posso impostare una dimensione di diapositiva personalizzata usando unità diverse da pollici (ad esempio, punti o millimetri)?**

Sì. Aspose.Slides utilizza internamente i punti, dove 1 punto equivale a 1/72 di pollice. Puoi convertire qualsiasi unità (ad esempio millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

**Una dimensione di diapositiva personalizzata molto grande influenzerà le prestazioni e l'uso della memoria durante il rendering?**

Sì. Dimensioni diapositive più grandi (in punti) combinati con una scala di rendering più alta comportano un aumento del consumo di memoria e tempi di elaborazione più lunghi. Mira a una dimensione di diapositiva pratica e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

**Posso definire una dimensione di diapositiva non standard e poi unire diapositive da presentazioni che hanno dimensioni diverse?**

Non è possibile [unire presentazioni](/slides/it/net/merge-presentation/) quando hanno dimensioni di diapositiva diverse — prima, ridimensiona una presentazione per farla coincidere con l'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/net/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive mantenendo la formattazione.

**Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione della diapositiva?**

Sì. Aspose.Slides può generare miniature per [tutte le diapositive](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage/) così come per [forme selezionate](https://reference.aspose.com/slides/it/net/aspose.slides/shape/getimage/). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo un inquadramento e una geometria coerenti.