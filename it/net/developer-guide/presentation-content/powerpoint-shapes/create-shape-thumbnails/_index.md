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
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Genera miniature di forma di alta qualità dalle diapositive PowerPoint con Aspose.Slides per .NET – crea ed esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides per .NET è utilizzato per creare file di presentazione in cui ogni pagina è una diapositiva. Queste diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Tuttavia, a volte gli sviluppatori potrebbero aver bisogno di vedere le immagini delle forme separatamente in un visualizzatore di immagini. In questi casi, Aspose.Slides per .NET ti aiuta a generare immagini miniature delle forme della diapositiva. Come utilizzare questa funzionalità è descritto in questo articolo.

Questo articolo spiega come generare miniature diapositive in diversi modi:

- Generazione di una miniatura di forma all'interno di una diapositiva.
- Generazione di una miniatura di forma per una forma di diapositiva con dimensioni definite dall'utente.
- Generazione di una miniatura di forma nei limiti dell'aspetto di una forma.

## **Genera una miniatura di forma da una diapositiva**
Per generare una miniatura di forma da qualsiasi diapositiva utilizzando Aspose.Slides per .NET:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'immagine della miniatura della forma della diapositiva di riferimento con scala predefinita.
1. Salva l'immagine della miniatura in qualsiasi formato immagine desiderato.

L'esempio seguente genera una miniatura di forma.

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

## **Genera una miniatura con fattore di scala definito dall'utente**
Per generare la miniatura della forma di qualsiasi forma di diapositiva utilizzando Aspose.Slides per .NET:

1. Crea un'istanza della classe `Presentation`.
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'immagine della miniatura della diapositiva di riferimento con i limiti della forma.
1. Salva l'immagine della miniatura in qualsiasi formato immagine desiderato.

L'esempio seguente genera una miniatura con un fattore di scala definito dall'utente.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Scalatura lungo gli assi X e Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Crea una miniatura di forma basata sui limiti dell'aspetto**
Questo metodo per creare miniature di forme consente agli sviluppatori di generare una miniatura nei limiti dell'aspetto della forma. Tiene conto di tutti gli effetti della forma. La miniatura della forma generata è limitata dai limiti della diapositiva. Per generare una miniatura di qualsiasi forma di diapositiva nei limiti del suo aspetto, utilizza il seguente codice di esempio:

1. Crea un'istanza della classe `Presentation`.
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'immagine della miniatura della diapositiva di riferimento con i limiti della forma come aspetto.
1. Salva l'immagine della miniatura in qualsiasi formato immagine desiderato.

L'esempio seguente crea una miniatura generando una miniatura con un fattore di scala definito dall'utente.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Scalatura lungo gli assi X e Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**Quali formati immagine possono essere usati quando si salvano le miniature di forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/net/aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/net/aspose.slides/shape/writeassvg/) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti Shape e Appearance quando si rende una miniatura?**

`Shape` utilizza la geometria della forma; `Appearance` tiene conto degli [effetti visivi](/slides/it/net/shape-effect/) (ombreggiature, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Verrà comunque resa come miniatura?**

Una forma nascosta resta parte del modello e può essere renderizzata; il flag di nascondere influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell'immagine della forma.

**Sono supportate forme di gruppo, grafici, SmartArt e altri oggetti complessi?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/net/aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chart/) e [SmartArt](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/smartart/)) può essere salvato come miniatura o come SVG.

**I font installati a livello di sistema influenzano la qualità delle miniature per forme di testo?**

Sì. Dovresti [fornire i font necessari](/slides/it/net/custom-font/) (o [configurare le sostituzioni dei font](/slides/it/net/font-substitution/)) per evitare fallback indesiderati e il rientro del testo.