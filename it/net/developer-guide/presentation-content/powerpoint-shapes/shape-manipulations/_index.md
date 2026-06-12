---
title: Gestisci le forme della presentazione in .NET
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/net/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma della presentazione
- Forma sulla diapositiva
- Trova forma
- Clona forma
- Rimuovi forma
- Nascondi forma
- Modifica ordine delle forme
- Ottieni ID interop della forma
- Testo alternativo della forma
- Formati layout della forma
- Forma come SVG
- Forma in SVG
- Allinea forma
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara a creare, modificare e ottimizzare le forme in Aspose.Slides per .NET e a fornire presentazioni PowerPoint ad alte prestazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le forme nelle presentazioni usando Aspose.Slides. Mostra come trovare una forma su una diapositiva, clonarla, rimuoverla, nasconderla, modificarne l'ordine, ottenere il suo ID Interop, e impostare il testo alternativo per l'identificazione e l'elaborazione successiva.

Copre inoltre come accedere ai formati di layout per le forme, renderizzare una forma come SVG, allineare le forme su una diapositiva e utilizzare le proprietà di flip per la riflessione orizzontale e verticale. Inoltre, l'articolo include una breve FAQ su combinazione di forme, ordine di impilamento e blocco delle forme.

## **Trova una forma su una diapositiva**
Questo argomento descriverà una tecnica semplice per facilitare gli sviluppatori nella ricerca di una forma specifica su una diapositiva senza utilizzare il suo Id interno. È importante sapere che i file di presentazione PowerPoint non hanno alcun modo di identificare le forme su una diapositiva se non tramite un Id interno univoco. Sembra difficile per gli sviluppatori trovare una forma usando il suo Id interno univoco. Tutte le forme aggiunte alle diapositive hanno un testo alternativo. Suggeriamo agli sviluppatori di utilizzare il testo alternativo per trovare una forma specifica. È possibile usare MS PowerPoint per definire il testo alternativo per gli oggetti che si prevede di modificare in futuro.

Dopo aver impostato il testo alternativo di una forma desiderata, è possibile aprire quella presentazione con Aspose.Slides for .NET ed iterare attraverso tutte le forme aggiunte a una diapositiva. Durante ogni iterazione, è possibile verificare il testo alternativo della forma e la forma con il testo alternativo corrispondente sarà quella richiesta. Per dimostrare meglio questa tecnica, abbiamo creato un metodo, [TrovaForma](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/findshape/#findshape_1) che fa al caso tuo per trovare una forma specifica in una diapositiva e restituisce semplicemente quella forma.

```c#
public static void Run()
{
    // Instanzia una classe Presentation che rappresenta il file della presentazione
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Testo alternativo della forma da cercare
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Implementazione del metodo per trovare una forma in una diapositiva usando il suo testo alternativo
public static IShape FindShape(ISlide slide, string alttext)
{
    // Iterazione attraverso tutte le forme all'interno della diapositiva
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Se il testo alternativo della diapositiva corrisponde a quello richiesto allora
        // Restituisci la forma
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```

## **Clona una forma**
Per clonare una forma su una diapositiva usando Aspose.Slides for .NET:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottieni il riferimento di una diapositiva usando il suo indice.
1. Accedi alla raccolta di forme della diapositiva di origine.
1. Aggiungi una nuova diapositiva alla presentazione.
1. Clona le forme dalla raccolta di forme della diapositiva di origine alla nuova diapositiva.
1. Salva la presentazione modificata come file PPTX.

L'esempio seguente aggiunge una forma di gruppo a una diapositiva.

```c#
// Istanzia la classe Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Scrivi il file PPTX su disco
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```

## **Rimuovi una forma**
Aspose.Slides for .NET consente agli sviluppatori di rimuovere qualsiasi forma. Per rimuovere la forma da una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe `Presentation`.
1. Accedi alla prima diapositiva.
1. Trova la forma con uno Specifico AlternativeText.
1. Rimuovi la forma.
1. Salva il file su disco.

```c#
// Crea oggetto Presentation
Presentation pres = new Presentation();

// Ottieni la prima diapositiva
ISlide sld = pres.Slides[0];

// Aggiungi autoshape di tipo rettangolo
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Salva la presentazione su disco
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```

## **Nascondi una forma**
Aspose.Slides for .NET consente agli sviluppatori di nascondere qualsiasi forma. Per nascondere la forma da una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe `Presentation`.
1. Accedi alla prima diapositiva.
1. Trova la forma con uno Specifico AlternativeText.
1. Nascondi la forma.
1. Salva il file su disco.

```c#
// Istanzia la classe Presentation che rappresenta il PPTX
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = pres.Slides[0];

// Add autoshape of rectangle type
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Salva la presentazione su disco
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```

## **Modifica l'ordine delle forme**
Aspose.Slides for .NET consente agli sviluppatori di riordinare le forme. Il riordino specifica quale forma è in primo piano e quale è sullo sfondo. Per riordinare le forme in una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe `Presentation`.
1. Accedi alla prima diapositiva.
1. Aggiungi una forma.
1. Aggiungi del testo nella casella di testo della forma.
1. Aggiungi un'altra forma con le stesse coordinate.
1. Riordina le forme.
1. Salva il file su disco.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```

## **Ottieni l'ID Interop della forma**
Aspose.Slides for .NET consente agli sviluppatori di ottenere un identificatore univoco della forma a livello di diapositiva, in contrasto con la proprietà UniqueId, che fornisce un identificatore univoco a livello di presentazione. La proprietà OfficeInteropShapeId è stata aggiunta alle interfacce IShape e alla classe Shape. Il valore restituito dalla proprietà OfficeInteropShapeId corrisponde al valore dell'Id dell'oggetto Microsoft.Office.Interop.PowerPoint.Shape. Di seguito è riportato un esempio di codice.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Ottenere identificatore univoco della forma nell'ambito della diapositiva
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```

## **Imposta il testo alternativo per una forma**
Aspose.Slides for .NET consente agli sviluppatori di impostare l'AlternateText di qualsiasi forma. 
Le forme in una presentazione possono essere distinte tramite la proprietà AlternativeText o il nome della forma. 
La proprietà AlternativeText può essere letta o impostata usando Aspose.Slides così come Microsoft PowerPoint. 
Utilizzando questa proprietà, è possibile etichettare una forma e svolgere diverse operazioni come rimuovere una forma, 
nascondere una forma o riordinare le forme su una diapositiva.
Per impostare l'AlternateText di una forma, segui i passaggi seguenti:

1. Crea un'istanza della classe `Presentation`.
1. Accedi alla prima diapositiva.
1. Aggiungi qualsiasi forma alla diapositiva.
1. Esegui alcune operazioni sulla forma appena aggiunta.
1. Scorri le forme per trovare una forma.
1. Imposta l'AlternativeText.
1. Salva il file su disco.

```c#
// Istanzia la classe Presentation che rappresenta il PPTX
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = pres.Slides[0];

// Add autoshape of rectangle type
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// Save presentation to disk
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```

## **Accedi ai formati di layout per una forma**
Aspose.Slides for .NET fornisce un'API semplice per accedere ai formati di layout per una forma. Questo articolo dimostra come accedere ai formati di layout.

Di seguito è riportato un esempio di codice.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **Renderizza una forma come SVG**
Ora Aspose.Slides for .NET supporta il rendering di una forma come SVG. Il metodo WriteAsSvg (e le sue sovraccariche) è stato aggiunto alla classe Shape e all'interfaccia IShape. Questo metodo consente di salvare il contenuto della forma come file SVG. Il frammento di codice sotto mostra come esportare la forma di una diapositiva in un file SVG.

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## **Allinea una forma**

Attraverso il metodo sovraccaricato [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/methods/alignshapes/index), è possibile 

* allineare le forme rispetto ai margini di una diapositiva. Vedi Esempio 1. 
* allineare le forme rispetto alle altre. Vedi Esempio 2. 

L'enumerazione [ShapesAlignmentType](https://reference.aspose.com/slides/it/net/aspose.slides/shapesalignmenttype) definisce le opzioni di allineamento disponibili.

**Esempio 1**

Questo codice C# mostra come allineare le forme con gli indici 1,2 e 4 lungo il margine superiore di una diapositiva:
Il codice sorgente sotto allinea le forme con gli indici 1,2 e 4 lungo il bordo superiore della diapositiva.

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**Esempio 2**

Questo codice C# mostra come allineare un'intera collezione di forme rispetto alla forma inferiore della collezione:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **Proprietà di flip**

In Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/it/net/aspose.slides/shapeframe/) offre il controllo sul mirroring orizzontale e verticale delle forme tramite le proprietà `FlipH` e `FlipV`. Entrambe le proprietà sono di tipo [NullableBool](https://reference.aspose.com/slides/it/net/aspose.slides/nullablebool/), consentendo valori `True` per indicare un flip, `False` per nessun flip, o `NotDefined` per usare il comportamento predefinito. Questi valori sono accessibili dal [Frame](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/frame/) di una forma.

Per modificare le impostazioni di flip, si crea una nuova istanza di [ShapeFrame](https://reference.aspose.com/slides/it/net/aspose.slides/shapeframe/) con la posizione e le dimensioni correnti della forma, i valori desiderati per `FlipH` e `FlipV` e l'angolo di rotazione. Assegnando questa istanza al [Frame](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/frame/) della forma e salvando la presentazione, le trasformazioni di mirror vengono applicate e salvate nel file di output.

Supponiamo di avere un file sample.pptx in cui la prima diapositiva contiene una singola forma con impostazioni di flip predefinite, come mostrato di seguito.

![The shape to be flipped](shape_to_be_flipped.png)

Il seguente esempio di codice recupera le proprietà di flip attuali della forma e le inverte sia orizzontalmente sia verticalmente.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Recupera la proprietà di flip orizzontale della forma.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Recupera la proprietà di flip verticale della forma.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Flip orizzontale.
    NullableBool flipV = NullableBool.True; // Flip verticale.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Posso combinare le forme (unione/intersezione/sottrazione) su una diapositiva come in un editor desktop?**

Non esiste un'API incorporata per operazioni booleane. È possibile approssimarla costruendo manualmente il contorno desiderato—ad esempio, calcolando la geometria risultante (tramite [GeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides/geometrypath/)) e creando una nuova forma con quel contorno, rimuovendo opzionalmente le originali.

**Come posso controllare l'ordine di impilamento (z-order) in modo che una forma rimanga sempre “in cima”?**

Modifica l'ordine di inserimento/spostamento all'interno della collezione [shapes](https://reference.aspose.com/slides/it/net/aspose.slides/baseslide/shapes/) della diapositiva. Per risultati prevedibili, finalizza lo z-order dopo tutte le altre modifiche della diapositiva.

**Posso “bloccare” una forma per impedire agli utenti di modificarla in PowerPoint?**

Sì. Imposta i flag di protezione a livello di forma [/slides/it/net/applying-protection-to-presentation/](... ) (ad esempio, blocco selezione, spostamento, ridimensionamento, modifica del testo). Se necessario, estendi le restrizioni al master o al layout. Nota che questa è una protezione a livello UI, non una funzionalità di sicurezza; per una protezione più forte, combina con restrizioni a livello di file come [raccomandazioni di sola lettura o password](/slides/it/net/password-protected-presentation/).