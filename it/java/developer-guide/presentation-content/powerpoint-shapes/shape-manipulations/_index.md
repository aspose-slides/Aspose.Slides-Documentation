---
title: Gestisci forme della presentazione in Java
linktitle: Manipolazione forme
type: docs
weight: 40
url: /it/java/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma della presentazione
- Forma su diapositiva
- Trova forma
- Clona forma
- Rimuovi forma
- Nascondi forma
- Cambia ordine forma
- Ottieni ID forma interop
- Testo alternativo forma
- Punto di regolazione forma
- Regolazione forma predefinita
- Geometria forma
- Formati layout forma
- Forma come SVG
- Forma in SVG
- Allinea forma
- Ribalta forma
- PowerPoint
- Presentazione
- Java
- Aspose.Slides
description: "Impara a identificare, regolare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e ribaltare le forme di presentazione con Aspose.Slides per Java."
---
## **Panoramica**

Aspose.Slides for Java rappresenta le forme su una diapositiva come una [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/) ordinata. La raccolta è sia il luogo in cui trovi e modifichi le forme sia la fonte del loro ordine di sovrapposizione: l’indice `0` è la forma più indietro, mentre l’ultimo indice è la forma più in avanti.

Questo articolo segue quel modello. Prima spiega come identificare una forma in modo affidabile e modificare i punti di regolazione predefiniti della forma, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali coprono la formattazione a livello di layout, l’esportazione SVG, l’allineamento e le impostazioni di ribaltamento. Ogni esempio è indipendente, così puoi utilizzare solo le operazioni richieste dal tuo flusso di lavoro.

## **Identificare e Trovare le Forme**

Gli indici della raccolta sono comodi durante l’elaborazione di un file noto, ma non sono identificatori stabili. Aggiungere, rimuovere o riordinare una forma può cambiarne l’indice. Scegli un identificatore in base a come la presentazione è creata e mantenuta:

- [Name](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getName--) è utile per modelli controllati dallo sviluppatore ed è facile da ispezionare nel Pannello di Selezione di PowerPoint. I nomi possono essere modificati e non sono garantiti univoci, quindi stabilisci una convenzione di denominazione se il codice dipende da essi.
- [AlternativeText](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getAlternativeText--) è utile quando una descrizione di accessibilità o un tag fornito dall’autore identifica già la forma. È visibile agli utenti, può essere localizzato o riscritto per l’accessibilità, e non è garantito unico. Non riutilizzare silenziosamente il testo di accessibilità significativo come chiave di database.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) è un identificatore di sola lettura unico all’interno di una diapositiva e corrisponde all’ID della forma usato dall’interoperabilità di PowerPoint. Usalo quando integri con PowerPoint o quando ti serve un riferimento inequivocabile per tutta la durata di una forma. Una forma clonata o ricreata è una forma diversa e riceve un proprio ID.

Il metodo correlato [getUniqueId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getUniqueId--) restituisce un identificatore a livello di presentazione, ma tale identificatore è destinato a componenti aggiuntivi e può essere riassegnato. Non dovrebbe essere trattato come una chiave esterna permanente. Se l’identità a lungo termine è essenziale, conserva la mappatura nei dati dell’applicazione e verifica che la forma prevista esista ancora.

Per un esempio pratico di lettura e aggiornamento sia del titolo del testo alternativo sia della descrizione, consulta [Manage Alternative Text Titles and Descriptions](/slides/it/java/presentation-accessibility/). Usa il testo alternativo per spiegare il significato visivo ai lettori, e tienilo separato dai nomi delle forme usati dal codice per trovarle.

Il seguente esempio cerca per nome con confronto esatto e restituisce l’ID interop a livello di diapositiva. Quando il modello non contiene la forma prevista, il codice segnala quel risultato invece di continuare con l’oggetto errato.

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

Quando un’operazione è specifica per un tipo di forma, controlla l’interfaccia prima di usare membri specifici del tipo. Questo esempio aggiorna il testo e il testo alternativo solo se l’oggetto nominato è un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/).

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

## **Identificare e Modificare le Regolazioni Predefinite della Forma**

Le forme di geometria predefinita possono esporre punti di regolazione che controllano funzionalità come la dimensione degli angoli, le proporzioni delle frecce o gli angoli degli archi. Accedile tramite la raccolta di sola lettura [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/it/java/com.aspose.slides/igeometryshape/#getAdjustments--) . La raccolta è fornita dalla forma, ma ogni [IAdjustValue](https://reference.aspose.com/slides/it/java/com.aspose.slides/iadjustvalue/) contiene un valore che può essere modificato.

Non fare affidamento solo su un indice fisso della raccolta. Itera le regolazioni e ispeziona il metodo di sola lettura [getType](https://reference.aspose.com/slides/it/java/com.aspose.slides/iadjustvalue/#getType--) , il cui valore [ShapeAdjustmentType](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapeadjustmenttype/) descrive cosa controlla la regolazione. Il metodo di sola lettura [getName](https://reference.aspose.com/slides/it/java/com.aspose.slides/iadjustvalue/#getName--) fornisce informazioni aggiuntive di identificazione ed è particolarmente utile quando un preset contiene più di una regolazione con lo stesso tipo semantico.

Usa il metodo di valore che corrisponde al significato della regolazione:

| Tipo di regolazione | Scopo | Valore da modificare |
|---|---|---|
| `CornerSize` | Dimensione degli angoli arrotondati | [setRawValue](https://reference.aspose.com/slides/it/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Spessore della coda di una freccia | `setRawValue` |
| `ArrowheadLength` | Lunghezza della punta della freccia | `setRawValue` |
| `ArrowheadWidth` | Larghezza della punta della freccia | `setRawValue` |
| `StartAngle` | Angolo di inizio di una torta o arco | [setAngleValue](https://reference.aspose.com/slides/it/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Angolo finale di una torta o arco | `setAngleValue` |

`getType` e `getName` restituiscono informazioni di sola lettura. `getRawValue` e `setRawValue` lavorano con un intero nelle unità di geometria native del preset, mentre `getAngleValue` e `setAngleValue` lavorano con un angolo in gradi. Il numero, l’ordine, il significato e l’intervallo valido delle regolazioni dipendono dal preset [ShapeType](https://reference.aspose.com/slides/it/java/com.aspose.slides/igeometryshape/#getShapeType--). Un valore valido per un preset può essere non valido o avere un effetto diverso per un altro.

Quando `getType` restituisce `ShapeAdjustmentType.Custom`, l’API non riconosce un significato semantico standard. Ispeziona `getName`, il tipo di preset e il valore esistente, e lascia la regolazione invariata a meno che non si conosca il significato e l’intervallo previsto. Anche per i tipi riconosciuti, verifica se lo stesso tipo compare più volte prima di selezionare un valore. L’articolo [Connector](/slides/it/java/connector/) mostra questa situazione con le regolazioni di curvatura del connettore.

Il seguente esempio completo crea versioni predefinite e modificate di tre forme predefinite. Itera ogni regolazione, stampa il suo nome e tipo, modifica i valori relativi alle dimensioni tramite `setRawValue`, modifica gli angoli tramite `setAngleValue` e salva il risultato. La colonna sinistra mantiene la geometria predefinita; la colonna destra mostra il rettangolo arrotondato, la freccia a quattro punte e la torta regolati.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiunge intestazioni per le colonne di forme predefinite e regolate.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verificare il tipo semantico prima di cambiare un valore rende il codice esplicito sul suo intento ed evita di assumere che un indice di raccolta specifico abbia lo stesso significato tra forme predefinite diverse.

## **Modificare la Raccolta di Forme**

I metodi di aggiunta, clonazione, rimozione e riordinamento operano sulla raccolta immediatamente. Se un’operazione cambia il numero o l’ordine delle forme, non continuare a fare affidamento su indici catturati prima di tale operazione.

### **Clonare una Forma**

[addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) crea una copia indipendente e la aggiunge alla fine della raccolta di destinazione. [insertClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) crea anch’essa una copia ma la posiziona a un indice di ordine Z specificato. Le overload che accettano coordinate spostano il clone senza cambiarne le dimensioni; le overload con larghezza e altezza possono ridimensionarlo.

L’esempio crea una diapositiva di destinazione, clona un rettangolo etichettato in primo piano e inserisce un secondo clone sullo sfondo. Le modifiche a ciascun clone non influiscono sulla forma originale.

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

Clonare copia il contenuto e la formattazione della forma, inclusi nome e testo alternativo. Assegna nuovi identificatori logici al clone quando questi valori devono essere unici. Le risorse usate da forme complesse sono gestite dalla presentazione, ma un clone rimane un nuovo elemento della raccolta con una nuova identità di forma.

### **Rimuovere le Forme**

[remove](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) elimina un oggetto forma specifico dalla sua raccolta. Quando rimuovi più corrispondenze durante un’iterazione indicizzata, attraversa la raccolta dal fondo in modo che ogni indice rimanente rimanga valido.

Questo esempio rimuove ogni forma con un nome designato. Legge la forma all’indice corrente, non un elemento fisso della raccolta, e non effettua cast inutili.

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

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili dei soli indici salvati. Considera inoltre connettori, animazioni e altre funzionalità della presentazione che possono fare riferimento all’oggetto rimosso; rimuovere una forma visibile può alterare più che l’aspetto della diapositiva.

### **Nascondere una Forma**

Impostare [Hidden](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#setHidden-boolean-) su `true` mantiene la forma nella raccolta ma ne impedisce la comparsa nella presentazione normale. Il suo indice, la formattazione e il contenuto restano disponibili al codice, quindi nascondere è appropriato per elementi opzionali che possono essere ripristinati in seguito.

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

Nascondere non è eliminazione né sicurezza. L’oggetto può ancora essere scoperto e ri‑mostrato da un utente o dal codice, e rimane parte del file della presentazione.

### **Modificare l’Ordine Z**

Le forme sovrapposte sono disegnate secondo l’ordine della raccolta. [reorder](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) sposta una forma esistente a un indice di destinazione senza clonarla. L’indice `0` è lo sfondo; `size() - 1` è il primo piano.

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

Il rettangolo è creato per primo e inizialmente si trova dietro l’ellisse. Spostarlo all’indice finale lo porta in primo piano. Finalizza l’ordine Z dopo aver aggiunto o clonato tutte le forme correlate, perché tali operazioni aggiungono o inseriscono nuovi elementi nella raccolta e possono alterare lo stack previsto.

## **Ispezionare le Forme nelle Diapositive di Layout**

Diapositive normali, diapositive di layout e diapositive master hanno raccolte di forme separate. Una forma nella raccolta di layout non è lo stesso oggetto di una forma posizionata similmente su una diapositiva normale. Ispeziona le forme di layout quando devi comprendere o modificare la formattazione fornita da un layout.

Il seguente esempio legge per ogni forma di layout il suo [FillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getFillFormat--) e il suo [LineFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getLineFormat--) senza presumere che ogni forma sia un `AutoShape`.

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

[writeAsSvg](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) scrive il contenuto renderizzato di una singola forma su uno stream. Il risultato contiene la forma, non l’intero sfondo della diapositiva né le forme vicine.

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

Mantieni la presentazione aperta durante il rendering. L’output dipende dalla formattazione della forma e da risorse quali caratteri e immagini. Se ti serve l’intera composizione, esporta la diapositiva anziché una singola forma. Il chiamante possiede lo stream e deve chiuderlo.

## **Allineare le Forme**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) offre overload per allineare tutte le forme o soli gli indici di raccolta selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `alignToSlide` su `true` per usare i bordi della diapositiva; impostalo su `false` per allineare le forme selezionate l’una rispetto all’altra.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I riferimenti alle forme restituiti vengono convertiti nei loro indici correnti subito prima dell’allineamento.

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

L’allineamento modifica le posizioni, non l’ordine Z. L’allineamento relativo normalmente richiede almeno due forme, mentre la distribuzione orizzontale o verticale richiede un numero sufficiente di forme per definire la spaziatura. Ricalcola gli indici se modifichi la raccolta prima di chiamare il metodo.

## **Ribaltare una Forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapeframe/) memorizza posizione, dimensione, impostazioni di ribaltamento orizzontale e verticale e rotazione. I valori `getFlipH` e `getFlipV` utilizzano [NullableBool](https://reference.aspose.com/slides/it/java/com.aspose.slides/nullablebool/): `True` abilita il ribaltamento, `False` lo disabilita, e `NotDefined` preserva lo stato non specificato/predefinito.

La presentazione di input sottostante contiene una forma non ribaltata.

![The shape before flipping](shape_to_be_flipped.png)

L’esempio mantiene tutti gli altri valori del frame e sostituisce solo le due impostazioni di ribaltamento. Ciò è importante perché assegnare un nuovo [Frame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) sostituisce l’intero frame.

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

La forma salvata è specchiata orizzontalmente e verticalmente mantenendo posizione, dimensione e rotazione.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usare un indice di raccolta come identificatore di una forma?**

Solo per elaborazioni a breve termine quando la raccolta non cambierà prima dell’utilizzo dell’indice. Preferisci una convenzione di `Name` o `AlternativeText` validata per template creati, o `OfficeInteropShapeId` per lavori di interop a livello di diapositiva.

**Nascondere una forma la rimuove dall’ordine Z?**

No. Una forma nascosta rimane nella raccolta allo stesso indice. Può essere trovata, riordinata, modificata o resa nuovamente visibile.

**Perché una forma clonata è apparsa davanti a un’altra forma?**

`addClone` aggiunge il clone alla fine della raccolta, che corrisponde al fronte dell’ordine Z. Usa `insertClone` per scegliere l’indice iniziale o `reorder` dopo aver aggiunto tutte le forme.

**Posso usare un indice fisso per identificare una regolazione predefinita della forma?**

Solo dopo aver convalidato il preset esatto e il layout della raccolta. Preferisci iterare su `IGeometryShape.getAdjustments` e controllare `IAdjustValue.getType`; usa `IAdjustValue.getName` come informazione aggiuntiva quando lo stesso tipo semantico appare più volte.