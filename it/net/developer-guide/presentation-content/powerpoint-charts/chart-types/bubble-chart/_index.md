---
title: Personalizza grafici a bolle nelle presentazioni in .NET
linktitle: Grafico a bolle
type: docs
url: /it/net/bubble-chart/
keywords:
- grafico a bolle
- dimensione bolla
- scala dimensioni
- rappresentazione dimensione
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea e personalizza potenti grafici a bolle in PowerPoint con Aspose.Slides per .NET per migliorare facilmente la visualizzazione dei dati."
---
## **Panoramica**

Questo articolo mostra come lavorare con i grafici a bolle in Aspose.Slides. Copre due opzioni di personalizzazione specifiche: la scala delle dimensioni delle bolle tramite la proprietà `BubbleSizeScale` e il controllo di come i valori delle dimensioni delle bolle vengono rappresentati tramite la proprietà `BubbleSizeRepresentation`.

Gli esempi dimostrano come creare un grafico a bolle, regolare la scala delle dimensioni e passare alla rappresentazione della dimensione della bolla usando la larghezza. L'articolo include anche una breve sezione FAQ che chiarisce il supporto per il tipo di grafico “Bubble with 3-D”, osserva che i limiti pratici del grafico dipendono dalle prestazioni e dalla versione di PowerPoint di destinazione, e spiega che l'esportazione preserva l'aspetto del grafico tramite il motore di rendering di Aspose.Slides.

## **Scala delle dimensioni del grafico a bolle**
Aspose.Slides per .NET fornisce il supporto per la scala delle dimensioni dei grafici a bolle. In Aspose.Slides per .NET sono state aggiunte le proprietà **IChartSeries.BubbleSizeScale** e **IChartSeriesGroup.BubbleSizeScale**. Di seguito è riportato un esempio di codice.  

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Rappresentare i dati come dimensioni del grafico a bolle**
È stata aggiunta la proprietà **BubbleSizeRepresentation** alle interfacce IChartSeries, IChartSeriesGroup e alle classi correlate. **BubbleSizeRepresentation** specifica come i valori delle dimensioni delle bolle sono rappresentati nel grafico a bolle. I valori possibili sono: **BubbleSizeRepresentationType.Area** e **BubbleSizeRepresentationType.Width**. Di conseguenza, è stato aggiunto l'enumerazione **BubbleSizeRepresentationType** per specificare i possibili modi di rappresentare i dati come dimensioni del grafico a bolle. Di seguito è riportato il codice di esempio.  

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**È supportato un "grafico a bolle con effetto 3-D" e in che modo differisce da uno normale?**

Sì. Esiste un tipo di grafico separato, “Bubble with 3-D”. Applica uno stile 3-D alle bolle ma non aggiunge un asse aggiuntivo; i dati rimangono X-Y-S (dimensione). Il tipo è disponibile nell'enumerazione [tipo di grafico](https://reference.aspose.com/slides/it/net/aspose.slides.charts/charttype/).

**Esiste un limite al numero di serie e punti in un grafico a bolle?**

Non esiste un limite rigido a livello di API; le restrizioni sono determinate dalle prestazioni e dalla versione di PowerPoint di destinazione. Si consiglia di mantenere un numero ragionevole di punti per garantire leggibilità e velocità di rendering.

**Come influenzerà l'esportazione l'aspetto di un grafico a bolle (PDF, immagini)?**

L'esportazione nei formati supportati preserva l'aspetto del grafico; il rendering è effettuato dal motore Aspose.Slides. Per i formati raster/vettoriali, si applicano le regole generali di rendering della grafica del grafico (risoluzione, anti-aliasing), quindi scegliere una DPI adeguata per la stampa.