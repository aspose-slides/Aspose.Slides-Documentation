---
title: Aggiungere forme di linea alle presentazioni in .NET
linktitle: Linea
type: docs
weight: 50
url: /it/net/Line/
keywords:
- linea
- creare linea
- aggiungere linea
- linea semplice
- configurare linea
- personalizzare linea
- stile tratteggio
- punta della freccia
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara a manipolare la formattazione delle linee nelle presentazioni PowerPoint con Aspose.Slides per .NET. Scopri proprietà, metodi ed esempi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere forme di linea alle diapositive PowerPoint in modo programmatico. Questo articolo mostra come creare una semplice linea e come personalizzarla affinché appaia come una freccia.

Imparerai come aggiungere una forma di linea a una diapositiva, regolare il suo aspetto visivo e salvare la presentazione aggiornata. Gli esempi si concentrano su impostazioni pratiche di formattazione della linea, come stile, larghezza, modello di tratteggio, opzioni di testa della freccia e colore di riempimento.

## **Creare una linea semplice**
Per aggiungere una semplice linea a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
- Ottieni il riferimento a una diapositiva utilizzando il suo indice.
- Aggiungi un'AutoShape di tipo Linea usando il metodo [AddAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/methods/addautoshape/index) esposto dall'oggetto Shapes.
- Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

```c#
// Istanziare la classe PresentationEx che rappresenta il file PPTX
using (Presentation pres = new Presentation())
{
    // Ottieni la prima diapositiva
    ISlide sld = pres.Slides[0];

    // Aggiungi un autoshape di tipo linea
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Scrivi il PPTX su disco
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Creare una linea a forma di freccia**
Aspose.Slides per .NET consente inoltre agli sviluppatori di configurare alcune proprietà della linea per renderla più accattivante. Proviamo a impostare alcune proprietà della linea affinché assomigli a una freccia. Segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) classe.
- Ottieni il riferimento a una diapositiva utilizzando il suo indice.
- Aggiungi un'AutoShape di tipo Linea usando il metodo [AddAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/methods/addautoshape/index) esposto dall'oggetto Shapes.
- Imposta lo **Line Style** su uno degli stili offerti da Aspose.Slides per .NET.
- Imposta la larghezza della linea.
- Imposta lo **[Dash Style](https://reference.aspose.com/slides/it/net/aspose.slides/linedashstyle)** della linea su uno degli stili offerti da Aspose.Slides per .NET.
- Imposta lo **[Arrow Head Style](https://reference.aspose.com/slides/it/net/aspose.slides/linearrowheadstyle)** e la lunghezza del punto di partenza della linea.
- Imposta lo **Arrow Head Style** e la lunghezza del punto finale della linea.
- Scrivi la presentazione modificata come file PPTX.

```c#
 // Istanziare la classe PresentationEx che rappresenta il file PPTX
 using (Presentation pres = new Presentation())
 {

     // Ottieni la prima diapositiva
     ISlide sld = pres.Slides[0];

     // Aggiungi un autoshape di tipo linea
     IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

     // Applica alcune formattazioni sulla linea
     shp.LineFormat.Style = LineStyle.ThickBetweenThin;
     shp.LineFormat.Width = 10;

     shp.LineFormat.DashStyle = LineDashStyle.DashDot;

     shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
     shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

     shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
     shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

     //Scrivi il PPTX su disco
     pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
 }
```

## **FAQ**

**Posso convertire una linea normale in un connettore in modo che si “aggancia” alle forme?**

No. Una linea normale (un [AutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) di tipo [Line](https://reference.aspose.com/slides/it/net/aspose.slides/shapetype/)) non diventa automaticamente un connettore. Per farla agganciare alle forme, utilizza il tipo dedicato [Connector](https://reference.aspose.com/slides/it/net/aspose.slides/connector/) e le [API corrispondenti](/slides/it/net/connector/) per le connessioni.

**Cosa devo fare se le proprietà di una linea sono ereditate dal tema e risulta difficile determinare i valori finali?**

[Leggi le proprietà effettive](/slides/it/net/shape-effective-properties/) tramite le interfacce [ILineFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ilineformateffectivedata/) / [ILineFillFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ilinefillformateffectivedata/) — queste tengono già conto dell’eredità e degli stili del tema.

**Posso bloccare una linea contro le modifiche (spostamento, ridimensionamento)?**

Sì. Le forme forniscono [oggetti di blocco](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/autoshapelock/) che consentono di [impedire le operazioni di modifica](/slides/it/net/applying-protection-to-presentation/).