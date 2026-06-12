---
title: Aggiungere rettangoli alle presentazioni in .NET
linktitle: Rettangolo
type: docs
weight: 80
url: /it/net/rectangle/
keywords:
- aggiungere rettangolo
- creare rettangolo
- forma rettangolare
- rettangolo semplice
- rettangolo formattato
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Migliora le tue presentazioni PowerPoint aggiungendo rettangoli con Aspose.Slides per .NET—progetta e modifica facilmente le forme in modo programmatico."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme rettangolari alle diapositive PowerPoint usando Aspose.Slides. Copre la creazione di un rettangolo semplice, la creazione di un rettangolo formattato e il salvataggio della presentazione aggiornata come file PPTX.

Vedrai anche come applicare formattazioni di base al rettangolo, come colore di riempimento solido, colore della linea e larghezza della linea. Inoltre, le FAQ dell’articolo rimandano a compiti correlati sul rettangolo, inclusi angoli arrotondati, riempimenti con immagine, effetti visivi, collegamenti ipertestuali, blocchi della forma, opzioni di esportazione e proprietà effettive.

## **Crea un rettangolo semplice**
Come nei temi precedenti, anche questo riguarda l’aggiunta di una forma e, questa volta, la forma di cui parleremo è Rectangle. In questo argomento, abbiamo descritto come gli sviluppatori possono aggiungere rettangoli semplici o formattati alle loro diapositive usando Aspose.Slides per .NET. Per aggiungere un rettangolo semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Ottieni il riferimento di una diapositiva usando il suo indice.
3. Aggiungi un IAutoShape di tipo Rectangle usando il metodo AddAutoShape esposto dall'oggetto IShapes.
4. Scrivi la presentazione modificata come file PPTX.

Nell’esempio riportato di seguito, abbiamo aggiunto un rettangolo semplice alla prima diapositiva della presentazione.

```c#
 // Istanziare la classe Prseetation che rappresenta il PPTX
using (Presentation pres = new Presentation())
{

    // Ottieni la prima diapositiva
    ISlide sld = pres.Slides[0];

    // Aggiungi forma automatica di tipo rettangolo
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Scrivi il file PPTX su disco
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Crea un rettangolo formattato**
Per aggiungere un rettangolo formattato a una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Ottieni il riferimento di una diapositiva usando il suo indice.
3. Aggiungi un IAutoShape di tipo Rectangle usando il metodo AddAutoShape esposto dall'oggetto IShapes.
4. Imposta il tipo di riempimento del rettangolo su Solid.
5. Imposta il colore del rettangolo usando la proprietà SolidFillColor.Color esposta dall'oggetto FillFormat associato all'oggetto IShape.
6. Imposta il colore delle linee del rettangolo.
7. Imposta la larghezza delle linee del rettangolo.
8. Scrivi la presentazione modificata come file PPTX.

I passaggi sopra sono implementati nell’esempio riportato di seguito.

```c#
 // Istanziare la classe Prseetation che rappresenta il PPTX
using (Presentation pres = new Presentation())
{

    // Ottieni la prima diapositiva
    ISlide sld = pres.Slides[0];

    // Aggiungi una forma automatica di tipo rettangolo
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Applica alcune formattazioni alla forma rettangolare
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Applica alcune formattazioni alla linea del rettangolo
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Scrivi il file PPTX su disco
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Come aggiungo un rettangolo con angoli arrotondati?**

Utilizza il [shape type](https://reference.aspose.com/slides/it/net/aspose.slides/shapetype/) con angolo arrotondato e regola il raggio degli angoli nelle proprietà della forma; l'arrotondamento può essere applicato per ogni angolo tramite regolazioni geometriche.

**Come riempio un rettangolo con un'immagine (texture)?**

Seleziona il [fill type](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/), fornisci la sorgente dell'immagine e configura i [stretching/tiling modes](https://reference.aspose.com/slides/it/net/aspose.slides/picturefillmode/).

**Un rettangolo può avere ombra e bagliore?**

Sì. [Outer/inner shadow, glow, and soft edges](/slides/it/net/shape-effect/) sono disponibili con parametri regolabili.

**Posso trasformare un rettangolo in un pulsante con un collegamento ipertestuale?**

Sì. [Assign a hyperlink](/slides/it/net/manage-hyperlinks/) al clic della forma (salto a una diapositiva, file, indirizzo web o e‑mail).

**Come posso proteggere un rettangolo da spostamenti e modifiche?**

[Use shape locks](/slides/it/net/applying-protection-to-presentation/): puoi vietare spostamenti, ridimensionamenti, selezione o modifica del testo per preservare il layout.

**Posso convertire un rettangolo in un'immagine raster o SVG?**

Sì. Puoi [render the shape](http://reference.aspose.com/slides/it/net/aspose.slides/shape/getimage/) in un’immagine con dimensioni/scala specificate o [export it as SVG](https://reference.aspose.com/slides/it/net/aspose.slides/shape/writeassvg/) per uso vettoriale.

**Come ottengo rapidamente le proprietà effettive (effective) di un rettangolo considerando tema ed eredità?**

[Use the shape’s effective properties](/slides/it/net/shape-effective-properties/): l’API restituisce valori calcolati che tengono conto di stili del tema, layout e impostazioni locali, semplificando l’analisi della formattazione.