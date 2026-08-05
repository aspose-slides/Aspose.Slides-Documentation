---
title: Crea miniature di forme di presentazione in .NET
linktitle: Miniature di forme
type: docs
weight: 70
url: /it/net/create-shape-thumbnails/
keywords:
- miniatura di forma
- immagine di forma
- render forma
- rendering di forma
- limiti visivi
- limiti di forma
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Genera miniature di forme ad alta qualità dalle diapositive PowerPoint con Aspose.Slides per .NET – crea ed esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides per .NET viene utilizzato per creare file di presentazione in cui ogni pagina è una diapositiva. Queste diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Ma a volte gli sviluppatori possono aver bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In tali casi, Aspose.Slides per .NET ti aiuta a generare immagini di anteprima delle forme della diapositiva. Come utilizzare questa funzionalità è descritto in questo articolo.  
Questo articolo spiega come generare le miniature delle diapositive in diversi modi:

- Generare una miniatura di una forma all'interno di una diapositiva.  
- Generare una miniatura di una forma per una forma di diapositiva con dimensioni definite dall'utente.  
- Generare una miniatura di una forma nei limiti dell'aspetto di una forma.

## **Generare una Miniatura di una Forma da una Diapositiva**
Per generare una miniatura di una forma da qualsiasi diapositiva usando Aspose.Slides per .NET:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva utilizzando il suo ID o indice.
1. Ottieni l'immagine della miniatura della forma della diapositiva di riferimento alla scala predefinita.
1. Salva l'immagine della miniatura in qualsiasi formato immagine desiderato.

L'esempio seguente genera una miniatura della forma.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Generare una Miniatura con Fattore di Scala Definito dall'Utente**
Per generare la miniatura della forma di qualsiasi forma di diapositiva usando Aspose.Slides per .NET:

1. Crea un'istanza della classe `Presentation`.
1. Ottieni il riferimento di qualsiasi diapositiva utilizzando il suo ID o indice.
1. Ottieni l'immagine della miniatura della diapositiva di riferimento con i limiti della forma.
1. Salva l'immagine della miniatura in qualsiasi formato immagine desiderato.

L'esempio seguente genera una miniatura con un fattore di scala definito dall'utente.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Scalatura sugli assi X e Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Creare una Miniatura dell'Aspetto di una Forma Basata sui Limiti**
Questo metodo per creare miniature di forme consente agli sviluppatori di generare una miniatura nei limiti dell'aspetto della forma. Tiene conto di tutti gli effetti della forma. La miniatura generata è limitata dai limiti della diapositiva. Per generare una miniatura di qualsiasi forma di diapositiva nei limiti del suo aspetto, utilizzare il seguente codice di esempio:

1. Crea un'istanza della classe `Presentation`.
1. Ottieni il riferimento di qualsiasi diapositiva utilizzando il suo ID o indice.
1. Ottieni l'immagine della miniatura della diapositiva di riferimento con i limiti della forma come aspetto.
1. Salva l'immagine della miniatura in qualsiasi formato immagine desiderato.

L'esempio seguente crea una miniatura con un fattore di scala definito dall'utente.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Scalatura sugli assi X e Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **Ottenere i Limiti Visivi Effettivi di una Forma**

Le proprietà del frame di [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/) — le sue proprietà `X`, `Y`, `Width` e `Height` — descrivono il rettangolo memorizzato nel modello della presentazione. Il contenuto realmente renderizzato può estendersi oltre quel frame o occupare un rettangolo allineato agli assi diverso. Rotazione, contorni, punte di freccia, layout del testo e overflow, geometria SmartArt generata e altri effetti di rendering possono tutti modificare l'area occupata.

Usa [GetVisualBounds](https://reference.aspose.com/slides/it/net/aspose.slides/shape/getvisualbounds/) per calcolare quell'area occupata senza creare un'immagine. Il metodo restituisce un [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) nelle coordinate della diapositiva. Il rettangolo restituito non è ritagliato alla diapositiva, quindi le sue coordinate possono essere negative quando il contenuto si estende oltre l'origine della diapositiva.

[GetVisualBounds](https://reference.aspose.com/slides/it/net/aspose.slides/shape/getvisualbounds/) non è attualmente dichiarato dall'interfaccia [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/). Pertanto, conserva la forma ottenuta dalla raccolta di forme della diapositiva come valore di interfaccia e castala solo quando chiami il metodo.

Il seguente esempio ottiene e confronta i limiti del frame e i limiti visivi:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

Il medesimo [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) può essere usato per allineare forme vicine al suo bordo `Left`, `Right`, `Top` o `Bottom`; riservare spazio sufficiente in un layout generato; o rilevare contenuti fuori da una regione consentita. I limiti visivi sono particolarmente utili per SmartArt, caselle di testo, frecce, immagini, forme ruotate e forme di gruppo, dove il frame memorizzato potrebbe non rappresentare il risultato renderizzato completo.

Usa [GetVisualBounds](https://reference.aspose.com/slides/it/net/aspose.slides/shape/getvisualbounds/) quando hai bisogno di coordinate per layout o validazione e non ti serve una bitmap. Usa [IShape.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/getimage/) quando devi renderizzare la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/it/net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensiona l'immagine in base ai limiti della forma, includendo le impostazioni del contorno, mentre `ShapeThumbnailBounds.Appearance` la dimensiona in base all'aspetto della forma e limita il risultato ai limiti della diapositiva. Al contrario, [GetVisualBounds](https://reference.aspose.com/slides/it/net/aspose.slides/shape/getvisualbounds/) restituisce solo il rettangolo calcolato e non lo ritaglia alla diapositiva.

## **FAQ**

**Quali formati immagine possono essere usati quando si salvano le miniature delle forme?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/net/aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/net/aspose.slides/shape/writeassvg/) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti Shape e Appearance quando si rende una miniatura?**  
`Shape` utilizza la geometria della forma; `Appearance` prende in considerazione [effetti visivi](/slides/it/net/shape-effect/) (ombreggiature, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Verrà comunque resa come miniatura?**  
Una forma nascosta rimane parte del modello e può essere resa; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell'immagine della forma.

**Le forme di gruppo, i grafici, SmartArt e altri oggetti complessi sono supportati?**  
Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/net/aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chart/), e [SmartArt](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/smartart/)) può essere salvato come miniatura o come SVG.

**I font installati a livello di sistema influenzano la qualità delle miniature per forme di testo?**  
Sì. È necessario [fornire i font richiesti](/slides/it/net/custom-font/) (o [configurare le sostituzioni dei font](/slides/it/net/font-substitution/)) per evitare fallback indesiderati e il riflusso del testo.