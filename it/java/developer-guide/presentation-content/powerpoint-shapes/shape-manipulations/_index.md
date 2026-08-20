---
title: Gestire le forme della presentazione in Java
linktitle: Manipolazione forme
type: docs
weight: 40
url: /it/java/shape-manipulations/
keywords:
- forma PowerPoint
- forma della presentazione
- forma nella diapositiva
- trovare forma
- clonare forma
- rimuovere forma
- nascondere forma
- cambiare ordine forma
- ottenere ID forma interop
- testo alternativo forma
- formati layout forma
- forma come SVG
- forma in SVG
- allineare forma
- capovolgere forma
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come identificare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e capovolgere le forme della presentazione con Aspose.Slides per Java."
---
## **Panoramica**

Aspose.Slides for Java rappresenta le forme su una diapositiva come una [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/) ordinata. La collezione è sia il luogo in cui è possibile trovare e modificare le forme sia la fonte del loro ordine di impilamento: l’indice `0` è la forma più arretrata, mentre l’ultimo indice è la forma più frontale.

Questo articolo segue quel modello. Prima spiega come identificare in modo affidabile una forma, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali trattano la formattazione a livello di layout, l’esportazione SVG, l’allineamento e le impostazioni di flip. Ogni esempio è indipendente, così è possibile utilizzare solo le operazioni richieste dal proprio flusso di lavoro.

## **Identificare e Trovare le Forme**

Gli indici della collezione sono comodi durante l’elaborazione di un file conosciuto, ma non sono identificatori stabili. Aggiungere, rimuovere o riordinare una forma può cambiarne l’indice. Scegli un identificatore in base a come la presentazione è stata creata e mantenuta:

- [Name](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getName--) è utile per i modelli controllati dallo sviluppatore ed è facile da ispezionare nel riquadro di selezione di PowerPoint. I nomi possono essere modificati e non sono garantiti unici, quindi stabilisci una convenzione di denominazione se il codice dipende da essi.
- [AlternativeText](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getAlternativeText--) è utile quando una descrizione di accessibilità o un tag fornito dall’autore identifica già la forma. È visibile agli utenti, può essere localizzato o riscritto per l’accessibilità e non è garantito unico. Non riutilizzare silenziosamente un testo di accessibilità significativo come chiave di database.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) è un identificatore di sola lettura unico all’interno di una diapositiva e corrisponde all’ID della forma usato dall’interoperabilità di PowerPoint. Usalo quando integri con PowerPoint o quando ti serve un riferimento non ambiguo per tutta la durata di una forma. Una forma clonata o ricreata è una forma diversa e riceve un proprio ID.

Il metodo correlato [getUniqueId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getUniqueId--) restituisce un identificatore con ambito presentazione, ma quell’identificatore è destinato a componenti aggiuntivi e può essere riassegnato. Non dovrebbe essere trattato come chiave esterna permanente. Se è essenziale un’identità a lungo termine, conserva la mappatura nei dati dell’applicazione e verifica che la forma prevista esista ancora.

L’esempio seguente ricerca per nome con confronto esatto e segnala l’interoperability ID a livello di diapositiva. Quando il modello non contiene la forma attesa, il codice segnala quel risultato invece di continuare con l’oggetto sbagliato.

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

Quando un’operazione è specifica a un tipo di forma, verifica l’interfaccia prima di usare membri specifici del tipo. Questo esempio aggiorna il testo e il testo alternativo solo se l’oggetto nominato è un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/).

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

I metodi add, clone, remove e reorder operano sulla collezione immediatamente. Se un’operazione cambia il numero o l’ordine delle forme, non continuare a fare affidamento sugli indici catturati prima di quell’operazione.

### **Clonare una Forma**

[addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) crea una copia indipendente e la aggiunge alla collezione di destinazione. [insertClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) crea anch’essa una copia ma la posiziona a un indice di ordine Z specificato. Le overload che accettano coordinate spostano il clone senza modificarne le dimensioni; le overload con larghezza e altezza possono ridimensionarlo.

L’esempio crea una diapositiva di destinazione, clona un rettangolo etichettato in primo piano e inserisce un secondo clone in fondo. Le modifiche a ciascun clone non alterano la forma sorgente.

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

Il clonare copia il contenuto e la formattazione della forma, incluso il nome e il testo alternativo. Assegna nuovi identificatori logici al clone quando quei valori devono essere unici. Le risorse usate da forme complesse sono gestite dalla presentazione, ma un clone rimane un nuovo elemento della collezione con una nuova identità di forma.

### **Rimuovere Forme**

[remove](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) elimina un oggetto forma specifico dalla sua collezione. Quando si rimuovono più corrispondenze durante un’iterazione indicizzata, attraversa la collezione dal fondo in modo che ogni indice rimanente rimanga valido.

Questo esempio rimuove ogni forma con un nome designato. Legge la forma all’indice corrente, non un elemento fisso della collezione, e non esegue cast non necessari.

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

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili rispetto agli indici salvati. Considera anche connettori, animazioni e altre funzionalità della presentazione che possono riferirsi all’oggetto rimosso; rimuovere una forma visibile può cambiare più del semplice aspetto della diapositiva.

### **Nascondere una Forma**

Impostare [Hidden](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#setHidden-boolean-) su `true` mantiene la forma nella collezione ma impedisce che appaia nella presentazione normale. Il suo indice, la formattazione e il contenuto rimangono disponibili al codice, quindi nascondere è appropriato per elementi opzionali che possono essere ripristinati in seguito.

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

Nascondere non è cancellazione né sicurezza. L’oggetto può ancora essere scoperto e reso visibile da un utente o da codice, e rimane parte del file della presentazione.

### **Modificare l’Ordine Z**

Le forme sovrapposte sono dipinte secondo l’ordine della collezione. [reorder](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) sposta una forma esistente a un indice di destinazione senza clonarla. L’indice `0` è il retro; `size() - 1` è il fronte.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il rettangolo viene creato per primo e inizialmente si trova dietro l’ellisse. Spostarlo all’indice finale lo porta in fronte. Finalizza l’ordine Z dopo aver aggiunto o clonato tutte le forme correlate, perché tali operazioni aggiungono o inseriscono nuovi elementi nella collezione e possono alterare lo stack previsto.

## **Ispezionare le Forme sui Layout**

Diapositive normali, layout e master hanno collezioni di forme separate. Una forma in una collezione di layout non è lo stesso oggetto di una forma posizionata in modo simile su una diapositiva normale. Ispeziona le forme di layout quando devi comprendere o modificare la formattazione fornita da un layout.

L’esempio seguente legge il [FillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getFillFormat--) e il [LineFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getLineFormat--) di ogni forma di layout senza presumere che ogni forma sia una `AutoShape`.

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

Modificare un layout può influire su più diapositive che lo utilizzano. Prima di cambiare una forma di layout, determina se una diapositiva normale eredita l’oggetto o contiene una sovrascrittura locale, e testa ogni diapositiva che usa quel layout.

## **Esportare una Forma in SVG**

[writeAsSvg](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) scrive il contenuto renderizzato di una singola forma in uno stream. Il risultato contiene solo la forma, non lo sfondo dell’intera diapositiva né le forme vicine.

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

Mantieni la presentazione aperta durante il rendering. L’output dipende dalla formattazione della forma e da risorse quali font e immagini. Se ti serve l’intera composizione, esporta la diapositiva anziché una forma individuale. Il chiamante possiede lo stream e deve chiuderlo.

## **Allineare le Forme**

Il metodo [SlideUtil.alignShapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) ha overload che allineano tutte le forme o solo gli indici di collezione selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `alignToSlide` su `true` per usare i bordi della diapositiva; impostalo su `false` per allineare le forme selezionate l’una rispetto all’altra.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I riferimenti alle forme restituiti vengono convertiti nei loro indici correnti immediatamente prima dell’allineamento.

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

L’allineamento cambia le posizioni, non l’ordine Z. Un allineamento relativo richiede normalmente almeno due forme, mentre la distribuzione orizzontale o verticale richiede un numero sufficiente di forme per definire la spaziatura. Ricalcola gli indici se modifichi la collezione prima di chiamare il metodo.

## **Capovolgere una Forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapeframe/) memorizza posizione, dimensioni, impostazioni di flip orizzontale e verticale, e rotazione. I suoi valori `getFlipH` e `getFlipV` usano [NullableBool](https://reference.aspose.com/slides/it/java/com.aspose.slides/nullablebool/): `True` abilita il flip, `False` lo disabilita, e `NotDefined` mantiene lo stato non specificato/predefinito.

La presentazione di input sottostante contiene una forma non capovolta.

![The shape before flipping](shape_to_be_flipped.png)

L’esempio conserva tutti gli altri valori del frame e sostituisce solo le due impostazioni di flip. Questo è importante perché assegnare un nuovo [Frame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) sostituisce l’intero frame.

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

La forma salvata è riflessa orizzontalmente e verticalmente mantenendo posizione, dimensioni e rotazione.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usare un indice di collezione come identificatore di una forma?**

Solo per elaborazioni a breve termine in cui la collezione non cambierà prima dell’uso dell’indice. Preferisci una convenzione validata di `Name` o `AlternativeText` per i modelli creati, o `OfficeInteropShapeId` per lavori di interop a livello di diapositiva.

**Nascondere una forma la rimuove dall’ordine Z?**

No. Una forma nascosta rimane nella collezione allo stesso indice. Può essere trovata, riordinata, modificata o resa visibile nuovamente.

**Perché una forma clonata è apparsa davanti a un’altra forma?**

`addClone` aggiunge il clone alla fine della collezione, che è il fronte dell’ordine Z. Usa `insertClone` per scegliere l’indice iniziale o `reorder` dopo aver aggiunto tutte le forme.