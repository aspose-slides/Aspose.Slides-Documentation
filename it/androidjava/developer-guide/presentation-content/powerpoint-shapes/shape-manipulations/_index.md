---
title: Gestire le forme della presentazione su Android
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/androidjava/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma della presentazione
- Forma nella diapositiva
- Trova forma
- Clona forma
- Rimuovi forma
- Nascondi forma
- Cambia ordine forma
- Ottieni ID forma interop
- Testo alternativo forma
- Formati layout forma
- Forma come SVG
- Forma in SVG
- Allinea forma
- Ribalta forma
- PowerPoint
- Presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come identificare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e ribaltare le forme di una presentazione con Aspose.Slides per Android via Java."
---
## **Panoramica**

Aspose.Slides for Android via Java rappresenta le forme su una diapositiva come una [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/) ordinata. La collezione è sia il luogo in cui trovare e modificare le forme sia la fonte del loro ordine di sovrapposizione: l'indice `0` è la forma più arretrata, mentre l'ultimo indice è la forma più anteriore.

Questo articolo segue quel modello. Prima spiega come identificare una forma in modo affidabile, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali trattano la formattazione a livello di layout, l'esportazione SVG, l'allineamento e le impostazioni di ribaltamento. Ogni esempio è indipendente, così puoi utilizzare solo le operazioni richieste dal tuo flusso di lavoro.

## **Identificare e Trovare le Forme**

Gli indici della collezione sono comodi durante l'elaborazione di un file noto, ma non sono identificatori stabili. Aggiungere, rimuovere o riordinare una forma può cambiare il suo indice. Scegli un identificatore in base a come la presentazione è creata e mantenuta:

- [Name](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getName--) è utile per modelli controllati dallo sviluppatore ed è facile da ispezionare nel Pannello di selezione di PowerPoint. I nomi possono essere modificati e non sono garantiti unici, quindi stabilisci una convenzione di denominazione se il codice vi fa riferimento.
- [AlternativeText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getAlternativeText--) è utile quando una descrizione di accessibilità o un tag fornito dall'autore identifica già la forma. È visibile agli utenti, può essere localizzato o riscritto per l'accessibilità, e non è garantito unico. Non riutilizzare silenziosamente testo di accessibilità significativo come chiave di database.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) è un identificatore di sola lettura unico all'interno di una diapositiva e corrisponde all'ID forma usato dall'interoperabilità di PowerPoint. Usalo quando integri con PowerPoint o quando hai bisogno di un riferimento inequivocabile per tutta la durata di una forma. Una forma clonata o ricreata è una forma diversa e riceve un proprio ID.

Il metodo correlato [getUniqueId](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getUniqueId--) restituisce un identificatore a livello di presentazione, ma quell'identificatore è destinato ai componenti aggiuntivi e può essere riassegnato. Non dovrebbe essere trattato come una chiave esterna permanente. Se l'identità a lungo termine è fondamentale, conserva la mappatura nei dati dell'applicazione e verifica che la forma prevista esista ancora.

L'esempio seguente cerca per nome con confronto esatto e restituisce l'ID interop a livello di diapositiva. Quando il modello non contiene la forma prevista, il codice segnala quel risultato invece di continuare con l'oggetto errato.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Quando un'operazione è specifica a un tipo di forma, verifica l'interfaccia prima di usare membri specifici del tipo. Questo esempio aggiorna il testo e il testo alternativo solo se l'oggetto denominato è un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Modificare la Collezione di Forme**

I metodi add, clone, remove e reorder operano sulla collezione immediatamente. Se un'operazione modifica il numero o l'ordine delle forme, non continuare a fare affidamento sugli indici acquisiti prima di quell'operazione.

### **Clonare una Forma**

[addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) crea una copia indipendente e la aggiunge alla collezione di destinazione. [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) crea anch'essa una copia ma la colloca a un indice di ordine Z specificato. Le overload che accettano coordinate spostano il clone senza modificarne le dimensioni; le overload con larghezza e altezza possono anche ridimensionarlo.

L'esempio crea una diapositiva di destinazione, clona un rettangolo etichettato in primo piano e inserisce un secondo clone sullo sfondo. Le modifiche a ciascun clone non modificano la forma sorgente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il cloning copia il contenuto e la formattazione della forma, inclusi nome e testo alternativo. Assegna nuovi identificatori logici al clone quando quei valori devono essere unici. Le risorse utilizzate da forme complesse sono gestite dalla presentazione, ma un clone rimane un nuovo elemento della collezione con una nuova identità di forma.

### **Rimuovere Forme**

[remove](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) elimina un oggetto forma specifico dalla sua collezione. Quando si rimuovono più corrispondenze durante un'iterazione indicizzata, percorri la collezione dal fondo in modo che ogni indice rimanente rimanga valido.

Questo esempio rimuove ogni forma con un nome designato. Legge la forma all'indice corrente, non un elemento fisso della collezione, e non esegue cast inutili.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili rispetto agli indici salvati. Considera anche connettori, animazioni e altre funzionalità della presentazione che potrebbero fare riferimento all'oggetto rimosso; rimuovere una forma visibile può modificare più che l'aspetto della diapositiva.

### **Nascondere una Forma**

Impostare [Hidden](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) su `true` mantiene la forma nella collezione ma impedisce che appaia nella presentazione normale. Il suo indice, la formattazione e il contenuto rimangono disponibili per il codice, quindi nascondere è appropriato per elementi opzionali che possono essere ripristinati in seguito.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nascondere non è cancellazione né sicurezza. L'oggetto può ancora essere scoperto e reso visibile da un utente o dal codice, e rimane parte del file della presentazione.

### **Modificare l'Ordine Z**

Le forme sovrapposte sono disegnate nell'ordine della collezione. [reorder](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) sposta una forma esistente a un indice di destinazione senza clonarla. L'indice `0` è lo sfondo; `size() - 1` è il fronte.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il rettangolo è creato per primo e inizialmente si trova dietro l'ellisse. Spostarlo all'indice finale lo porta in primo piano. Finalizza l'ordine Z dopo aver aggiunto o clonato tutte le forme correlate, perché quelle operazioni aggiungono o inseriscono nuovi elementi nella collezione e possono modificare lo stack previsto.

## **Ispezionare le Forme nei Layout**

Diapositive normali, layout e master hanno collezioni di forme separate. Una forma nella collezione di layout non è lo stesso oggetto di una forma posizionata in modo simile su una diapositiva normale. Ispeziona le forme di layout quando devi capire o modificare la formattazione fornita da un layout.

L'esempio seguente legge il [FillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getFillFormat--) e il [LineFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getLineFormat--) di ciascuna forma del layout senza assumere che ogni forma sia un `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Modificare un layout può influire su più diapositive che lo utilizzano. Prima di cambiare una forma di layout, determina se una diapositiva normale eredita l'oggetto o contiene una sovrascrittura locale, e verifica ogni diapositiva che usa quel layout.

## **Esportare una Forma in SVG**

[writeAsSvg](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) scrive il contenuto renderizzato di una singola forma su uno stream. Il risultato contiene la forma, non lo sfondo dell'intera diapositiva né le forme vicine.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Mantieni la presentazione aperta durante il rendering. L'output dipende dalla formattazione della forma e da risorse come caratteri e immagini. Se ti serve l'intera composizione, esporta la diapositiva anziché una singola forma. Il chiamante possiede lo stream e deve chiuderlo.

## **Allineare le Forme**

I sovraccarichi di [SlideUtil.alignShapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) allineano tutte le forme o gli indici di collezione selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `alignToSlide` su `true` per usare i bordi della diapositiva; impostalo su `false` per allineare le forme selezionate tra loro.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I riferimenti alle forme restituiti sono convertiti ai loro indici correnti subito prima dell'allineamento.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'allineamento modifica le posizioni, non l'ordine Z. L'allineamento relativo richiede normalmente almeno due forme, mentre la distribuzione orizzontale o verticale richiede un numero sufficiente di forme per definire la spaziatura. Ricalcola gli indici se modifichi la collezione prima di chiamare il metodo.

## **Ribaltare una Forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shapeframe/) memorizza posizione, dimensioni, impostazioni di ribaltamento orizzontale e verticale e rotazione. I valori `getFlipH` e `getFlipV` usano [NullableBool](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/nullablebool/): `True` abilita il ribaltamento, `False` lo disabilita e `NotDefined` mantiene lo stato non specificato/predefinito.

La presentazione di input qui sotto contiene una forma non ribaltata.

![The shape before flipping](shape_to_be_flipped.png)

L'esempio preserva tutti gli altri valori del frame e sostituisce solo le due impostazioni di ribaltamento. È importante perché assegnare un nuovo [Frame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) sostituisce l'intero frame.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La forma salvata è specchiata orizzontalmente e verticalmente mantenendo posizione, dimensioni e rotazione.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usare un indice di collezione come identificatore di una forma?**

Solo per elaborazioni di breve durata quando la collezione non cambierà prima dell'uso dell'indice. Preferisci una convenzione con `Name` o `AlternativeText` validata per i modelli creati, o `OfficeInteropShapeId` per lavori di interop a livello di diapositiva.

**Nascondere una forma la rimuove dall'ordine Z?**

No. Una forma nascosta rimane nella collezione allo stesso indice. Può essere trovata, riordinata, modificata o resa nuovamente visibile.

**Perché una forma clonata è apparsa davanti a un'altra forma?**

`addClone` aggiunge il clone alla fine della collezione, che corrisponde al fronte dell'ordine Z. Usa `insertClone` per scegliere l'indice iniziale o `reorder` dopo aver aggiunto tutte le forme.