---
title: Aggiungi forme di linea alle presentazioni in .NET
linktitle: Linea
type: docs
weight: 50
url: /it/net/line/
keywords:
- linea
- creare linea
- aggiungere linea
- linea semplice
- configurare linea
- personalizzare linea
- stile tratteggiato
- punta della freccia
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara a manipolare la formattazione delle linee nelle presentazioni PowerPoint con Aspose.Slides per .NET. Scopri proprietà, metodi ed esempi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere forme di linea alle diapositive PowerPoint in modo programmatico. Questo articolo mostra come creare una semplice linea e come personalizzare una linea in modo che appaia come una freccia.

Imparerai come aggiungere una forma di linea a una diapositiva, regolare il suo aspetto visivo e salvare la presentazione aggiornata. Gli esempi si concentrano su impostazioni pratiche di formattazione della linea come stile, spessore, pattern tratteggiato, opzioni di punta della freccia e colore di riempimento.

## **Crea una linea semplice**
Per aggiungere una semplice linea semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un’istanza della classe [Presentazione ](https://reference.aspose.com/slides/it/net/aspose.slides/presentation)class.
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un'AutoShape di tipo Linea usando il metodo [AddAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/methods/addautoshape/index) esposto dall'oggetto Shapes.
- Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

```c#
// Istanzia la classe PresentationEx che rappresenta il file PPTX
using (Presentation pres = new Presentation())
{
    // Ottieni la prima diapositiva
    ISlide sld = pres.Slides[0];

    // Aggiungi un'autoshape di tipo linea
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Scrivi il PPTX su disco
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Crea una linea a forma di freccia**
Aspose.Slides per .NET consente anche agli sviluppatori di configurare alcune proprietà della linea per renderla più accattivante. Proviamo a configurare alcune proprietà di una linea per farla apparire come una freccia. Segui i passaggi seguenti per farlo:

- Crea un’istanza della classe [Presentazione ](https://reference.aspose.com/slides/it/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/it/aspose.slides/)[](http://www.aspose.com/api/net/slides/it/aspose.slides/).
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un'AutoShape di tipo Linea usando il metodo AddAutoShape esposto dall'oggetto Shapes.
- Imposta lo Stile della Linea su uno degli stili offerti da Aspose.Slides per .NET.
- Imposta lo Spessore della linea.
- Imposta lo [Dash Style](https://reference.aspose.com/slides/it/net/aspose.slides/linedashstyle) della linea su uno degli stili offerti da Aspose.Slides per .NET.
- Imposta lo [Arrow Head Style](https://reference.aspose.com/slides/it/net/aspose.slides/linearrowheadstyle) e la Lunghezza del punto di inizio della linea.
- Imposta lo Stile della punta della freccia e la Lunghezza del punto finale della linea.
- Scrivi la presentazione modificata come file PPTX.

```c#
// Istanzia la classe PresentationEx che rappresenta il file PPTX
using (Presentation pres = new Presentation())
{

    // Ottieni la prima diapositiva
    ISlide sld = pres.Slides[0];

    // Aggiungi un'autoshape di tipo linea
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Applica alcune formattazioni alla linea
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

**Posso convertire una linea normale in un connettore in modo che si agganci alle forme?**

No. Una linea normale (un [AutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) di tipo [Line](https://reference.aspose.com/slides/it/net/aspose.slides/shapetype/)) non diventa automaticamente un connettore. Per farla agganciare alle forme, utilizza il tipo [Connector](https://reference.aspose.com/slides/it/net/aspose.slides/connector/) dedicato e le [API corrispondenti](/slides/it/net/connector/) per le connessioni.

**Cosa devo fare se le proprietà di una linea sono ereditate dal tema e risulta difficile determinare i valori finali?**

[Leggi le proprietà effettive](/slides/it/net/shape-effective-properties/) tramite le interfacce [ILineFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ilinefillformateffectivedata/) — queste considerano già l'ereditarietà e gli stili del tema.

**Posso bloccare una linea per impedirne la modifica (spostamento, ridimensionamento)?**

Sì. Le forme forniscono [oggetti di blocco](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/autoshapelock/) che consentono di [impedire operazioni di modifica](/slides/it/net/applying-protection-to-presentation/).