---
title: Personalizza le legende dei grafici nelle presentazioni in .NET
linktitle: Legenda del grafico
type: docs
url: /it/net/chart-legend/
keywords:
- legenda del grafico
- posizione della legenda
- dimensione del carattere
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Personalizza le legende dei grafici con Aspose.Slides per .NET per ottimizzare le presentazioni PowerPoint con una formattazione della legenda su misura."
---
## **Panoramica**

Aspose.Slides offre opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una legenda, impostare la dimensione del carattere per l'intera legenda e applicare la formattazione a una voce di legenda individuale.

Copre inoltre diversi comportamenti correlati nella FAQ, inclusa l'utilizzazione della modalità non sovrapposta in modo che l'area del grafico lasci spazio alla legenda, consentendo alle etichette lunghe di andare a capo o di utilizzare interruzioni di riga, e facendo ereditare la formattazione della legenda dal tema della presentazione quando non vengono applicate impostazioni esplicite di testo e riempimento.

## **Posizionamento della Legenda**
Per impostare le proprietà della leggenda, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
- Ottieni il riferimento della diapositiva.
- Aggiungi un grafico alla diapositiva.
- Imposta le proprietà della legenda.
- Scrivi la presentazione come file PPTX.

Nell'esempio riportato di seguito, abbiamo impostato la posizione e le dimensioni della legenda del grafico.

```c#
// Crea un'istanza della classe Presentation
Presentation presentation = new Presentation();

// Ottieni il riferimento della diapositiva
ISlide slide = presentation.Slides[0];

// Aggiungi un grafico a colonne raggruppate sulla diapositiva
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Imposta le proprietà della legenda
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Scrivi la presentazione su disco
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```

## **Imposta la Dimensione del Carattere di una Legenda**
Aspose.Slides per .NET consente agli sviluppatori di impostare la dimensione del carattere della legenda. Segui i passaggi seguenti:

- Instanzia la classe `Presentation`.
- Crea il grafico predefinito.
- Imposta la Dimensione del Carattere.
- Imposta il valore minimo dell'asse.
- Imposta il valore massimo dell'asse.
- Scrivi la presentazione su disco.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Imposta la Dimensione del Carattere di una Legenda Individuale**
Aspose.Slides per .NET consente agli sviluppatori di impostare la dimensione del carattere delle voci della legenda individuali. Segui i passaggi seguenti:

- Instanzia la classe `Presentation`.
- Crea il grafico predefinito.
- Accedi alla voce della legenda.
- Imposta la Dimensione del Carattere.
- Imposta il valore minimo dell'asse.
- Imposta il valore massimo dell'asse.
- Scrivi la presentazione su disco.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso abilitare la legenda in modo che il grafico riservi automaticamente spazio per essa invece di sovrapporla?**

Sì. Usa la modalità non sovrapposta ([Overlay](https://reference.aspose.com/slides/it/net/aspose.slides.charts/legend/overlay/) = `false`); in questo caso, l'area del grafico si ridurrà per ospitare la legenda.

**Posso creare etichette di legenda su più righe?**

Sì. Le etichette lunghe vanno a capo automaticamente quando lo spazio è insufficiente; le interruzioni di riga forzate sono supportate tramite caratteri di nuova riga nel nome della serie.

**Come faccio a far sì che la legenda segua lo schema di colori del tema della presentazione?**

Non impostare colori/riempimenti/caratteri espliciti per la legenda o per il suo testo. In tal caso erediteranno dal tema e si aggiorneranno correttamente quando il design cambia.