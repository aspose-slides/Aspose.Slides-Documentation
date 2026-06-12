---
title: Gestire le forme della presentazione in Java
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/java/shape-manipulations/
keywords:
- forma PowerPoint
- forma della presentazione
- forma su diapositiva
- trova forma
- clona forma
- rimuovi forma
- nascondi forma
- cambia ordine forma
- ottieni ID forma Interop
- testo alternativo forma
- formati di layout forma
- forma come SVG
- forma in SVG
- allinea forma
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Impara a creare, modificare e ottimizzare le forme in Aspose.Slides per Java e a realizzare presentazioni PowerPoint ad alte prestazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le forme nelle presentazioni usando Aspose.Slides. Mostra come trovare una forma su una diapositiva, clonarla, rimuoverla, nasconderla, modificare il suo ordine, ottenere il suo ID forma Interop e impostare il testo alternativo per l’identificazione e l’elaborazione successiva.

Include anche come accedere ai formati di layout per le forme, renderizzare una forma come SVG, allineare le forme su una diapositiva e utilizzare le proprietà di flip per la riflessione orizzontale e verticale. Inoltre, l’articolo contiene una breve FAQ su combinazione di forme, ordine di sovrapposizione e blocco delle forme.

## **Trova una forma su una diapositiva**
Questo argomento descriverà una tecnica semplice per facilitare gli sviluppatori nella ricerca di una forma specifica su una diapositiva senza usare il suo Id interno. È importante sapere che i file di presentazione PowerPoint non offrono alcun modo per identificare le forme su una diapositiva, tranne un Id interno univoco. Sembra difficile per gli sviluppatori trovare una forma usando il suo Id interno univoco. Tutte le forme aggiunte alle diapositive hanno un certo Testo Alternativo. Consigliamo agli sviluppatori di usare il testo alternativo per trovare una forma specifica. È possibile usare MS PowerPoint per definire il testo alternativo per gli oggetti che si prevede di modificare in futuro.

Dopo aver impostato il testo alternativo di una forma desiderata, è possibile aprire quella presentazione con Aspose.Slides per Java e iterare tutte le forme aggiunte a una diapositiva. Durante ogni iterazione, è possibile verificare il testo alternativo della forma e la forma con il testo corrispondente sarà quella richiesta. Per dimostrare meglio questa tecnica, abbiamo creato un metodo, [findShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) che esegue il trucco per trovare una forma specifica in una diapositiva e restituisce semplicemente quella forma.

```java
// Istanzia una classe Presentation che rappresenta il file della presentazione
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Testo alternativo della forma da trovare
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Implementazione del metodo per trovare una forma in una diapositiva usando il suo testo alternativo
public static IShape findShape(ISlide slide, String alttext)
{
    // Iterazione di tutte le forme nella diapositiva
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Se il testo alternativo della forma corrisponde a quello richiesto allora
        // Restituisce la forma
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Clona una forma**
Per clonare una forma su una diapositiva usando Aspose.Slides per Java:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Ottenere il riferimento di una diapositiva usando il suo indice.
1. Accedere alla collezione di forme della diapositiva di origine.
1. Aggiungere una nuova diapositiva alla presentazione.
1. Clonare le forme dalla collezione di forme della diapositiva di origine alla nuova diapositiva.
1. Salvare la presentazione modificata come file PPTX.

L’esempio sotto aggiunge una forma di gruppo a una diapositiva.

```java
// Istanzia la classe Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Scrivi il file PPTX su disco
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rimuovi una forma**
Aspose.Slides per Java consente agli sviluppatori di rimuovere qualsiasi forma. Per rimuovere la forma da una diapositiva, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Accedere alla prima diapositiva.
1. Trovare la forma con un TestoAlternativo specifico.
1. Rimuovere la forma.
1. Salvare il file su disco.

```java
// Crea l'oggetto Presentation
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo rettangolo
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Salva la presentazione su disco
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nascondi una forma**
Aspose.Slides per Java consente agli sviluppatori di nascondere qualsiasi forma. Per nascondere la forma da una diapositiva, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Accedere alla prima diapositiva.
1. Trovare la forma con un TestoAlternativo specifico.
1. Nascondere la forma.
1. Salvare il file su disco.

```java
// Istanzia la classe Presentation che rappresenta il PPTX
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo rettangolo
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Salva la presentazione su disco
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifica l’ordine della forma**
Aspose.Slides per Java consente agli sviluppatori di riordinare le forme. Il riordino specifica quale forma è in primo piano o sullo sfondo. Per riordinare le forme su una diapositiva, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Accedere alla prima diapositiva.
1. Aggiungere una forma.
1. Aggiungere del testo nella casella di testo della forma.
1. Aggiungere un’altra forma con le stesse coordinate.
1. Riordinare le forme.
1. Salvare il file su disco.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ottieni l’ID Interop della forma**
Aspose.Slides per Java consente agli sviluppatori di ottenere un identificatore unico della forma a livello di diapositiva, a differenza del metodo [getUniqueId](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#getUniqueId--) che fornisce un identificatore unico a livello di presentazione. Il metodo [getOfficeInteropShapeId](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) è stato aggiunto alle interfacce [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape) e alla classe [Shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/Shape). Il valore restituito da [getOfficeInteropShapeId](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) corrisponde al valore dell’Id dell’oggetto Microsoft.Office.Interop.PowerPoint.Shape. Di seguito è riportato un esempio di codice.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Ottenere l'identificatore unico della forma a livello di diapositiva
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta il Testo Alternativo per una forma**
Aspose.Slides per Java consente agli sviluppatori di impostare l’AlternateText di qualsiasi forma.
Le forme in una presentazione possono essere distinte tramite il metodo [AlternativeText](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) o il [Nome Forma](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#setName-java.lang.String-).
I metodi [setAlternativeText](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) e [getAlternativeText](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#getAlternativeText--) possono essere letti o impostati sia con Aspose.Slides sia con Microsoft PowerPoint.
Utilizzando questo metodo, è possibile etichettare una forma e svolgere diverse operazioni come rimuovere una forma, nascondere una forma o riordinare le forme su una diapositiva.
Per impostare l’AlternateText di una forma, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Accedere alla prima diapositiva.
1. Aggiungere qualsiasi forma alla diapositiva.
1. Eseguire alcune operazioni sulla forma appena aggiunta.
1. Scorrere le forme per trovare una forma.
1. Impostare l’AlternativeText.
1. Salvare il file su disco.

```java
// Instanzia la classe Presentation che rappresenta il PPTX
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo rettangolo
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Salva la presentazione su disco
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accedi ai formati di layout per una forma**
Aspose.Slides per Java fornisce un’API semplice per accedere ai formati di layout per una forma. Questo articolo dimostra come accedere ai formati di layout.

Di seguito è fornito un esempio di codice.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Renderizza una forma come SVG**
Ora Aspose.Slides per Java supporta il rendering di una forma come SVG. Il metodo [writeAsSvg](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (e le sue overload) è stato aggiunto alla classe [Shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/Shape) e all’interfaccia [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape). Questo metodo consente di salvare il contenuto della forma come file SVG. Lo snippet di codice sotto mostra come esportare la forma di una diapositiva in un file SVG.

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Allinea una forma**
Aspose.Slides consente di allineare le forme sia rispetto ai margini della diapositiva sia rispetto a loro stesse. A tale scopo, è stato aggiunto il metodo sovraccaricato [SlidesUtil.alignShape()](https://reference.aspose.com/slides/it/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). L’enumerazione [ShapesAlignmentType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ShapesAlignmentType) definisce le possibili opzioni di allineamento.

**Esempio 1**

Il codice sorgente qui sotto allinea le forme con indici 1, 2 e 4 lungo il bordo superiore della diapositiva.

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**Esempio 2**

L’esempio qui sotto mostra come allineare l’intera raccolta di forme rispetto alla forma più in basso della raccolta.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Proprietà di flip**

In Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapeframe/) fornisce il controllo sul mirroring orizzontale e verticale delle forme tramite le proprietà `flipH` e `flipV`. Entrambe le proprietà sono di tipo `byte`, consentendo valori `1` per indicare un flip, `0` per nessun flip o `-1` per usare il comportamento predefinito. Questi valori sono accessibili dal [Frame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getFrame--) di una forma.

Per modificare le impostazioni di flip, viene costruita una nuova istanza di [ShapeFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapeframe/) con la posizione e le dimensioni attuali della forma, i valori desiderati per `flipH` e `flipV` e l’angolo di rotazione. Assegnando questa istanza al [Frame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getFrame--) della forma e salvando la presentazione, si applicano le trasformazioni di mirroring e si scrivono nel file di output.

Supponiamo di avere un file sample.pptx in cui la prima diapositiva contiene una singola forma con impostazioni di flip predefinite, come mostrato di seguito.

![The shape to be flipped](shape_to_be_flipped.png)

Il codice seguente recupera le proprietà di flip attuali della forma e la ribalta sia orizzontalmente sia verticalmente.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Recupera la proprietà di flip orizzontale della forma.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Recupera la proprietà di flip verticale della forma.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Capovolgi orizzontalmente.
    byte flipV = NullableBool.True; // Capovolgi orizzontalmente.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Posso combinare forme (unione/intersezione/sottrazione) su una diapositiva come in un editor desktop?**

Non esiste un’API integrata per operazioni booleane. È possibile approssimarla costruendo manualmente il contorno desiderato—ad esempio calcolando la geometria risultante (tramite [GeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/geometrypath/)) e creando una nuova forma con quel contorno, rimuovendo opzionalmente le originali.

**Come posso controllare l’ordine di sovrapposizione (z-order) in modo che una forma rimanga sempre “in cima”?**

Modificare l’ordine di inserimento/spostamento all’interno della collezione di [shapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseslide/#getShapes--) della diapositiva. Per risultati prevedibili, finalizzare lo z-order dopo tutte le altre modifiche alla diapositiva.

**Posso “bloccare” una forma per impedire agli utenti di modificarla in PowerPoint?**

Sì. Impostare i flag di protezione a livello di forma ([shape-level protection flags](/slides/it/java/applying-protection-to-presentation/)) (ad es. blocco selezione, spostamento, ridimensionamento, modifica testo). Se necessario, riflettere le restrizioni sul master o sul layout. Nota che questa è una protezione a livello UI, non una funzione di sicurezza; per una protezione più forte, combinarla con restrizioni a livello di file come raccomandazioni di sola lettura o password ([read‑only recommendations or passwords](/slides/it/java/password-protected-presentation/)).