---
title: Gestire le forme della presentazione in PHP
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/php-java/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma di presentazione
- Forma su diapositiva
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
- PHP
- Aspose.Slides
description: "Impara come identificare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e ribaltare le forme della presentazione con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Aspose.Slides per PHP via Java rappresenta le forme su una diapositiva come una [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/). La collezione è sia il luogo in cui trovare e modificare le forme sia la fonte del loro ordine di impilamento: l'indice `0` è la forma più posteriore, mentre l'ultimo indice è la forma più anteriore.

Questo articolo segue quel modello. Prima spiega come identificare in modo affidabile una forma, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali trattano la formattazione a livello di layout, l'esportazione in SVG, l'allineamento e le impostazioni di ribaltamento. Ogni esempio è indipendente, così puoi utilizzare solo le operazioni di cui ha bisogno il tuo flusso di lavoro.

## **Identificare e trovare le forme**

Gli indici della collezione sono comodi durante l'elaborazione di un file noto, ma non sono identificatori stabili. Aggiungere, rimuovere o riordinare una forma può cambiare il suo indice. Scegli un identificatore in base a come la presentazione è creata e gestita:

- [Name](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getname/) è utile per modelli controllati dallo sviluppatore ed è facile da ispezionare nel riquadro Selezione di PowerPoint. I nomi possono essere modificati e non sono garantiti unici, quindi stabilire una convenzione di denominazione se il codice dipende da essi.
- [AlternativeText](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getalternativetext/) è utile quando una descrizione di accessibilità o un tag fornito dall'autore identifica già la forma. È visibile agli utenti, può essere localizzato o riscritto per l'accessibilità e non è garantito univoco. Non riutilizzare silenziosamente testi di accessibilità significativi come chiave di database.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getofficeinteropshapeid/) è un identificatore di sola lettura unico all'interno di una diapositiva e corrisponde all'ID forma usato dall'interoperabilità di PowerPoint. Usalo quando integri con PowerPoint o quando hai bisogno di un riferimento inequivocabile per tutta la durata di una forma. Una forma clonata o ricreata è una forma diversa e riceve un proprio ID.

Il metodo correlato [Shape::getUniqueId](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getuniqueid/) restituisce un identificatore con ambito di presentazione, ma tale identificatore è destinato a componenti aggiuntivi e può essere riassegnato. Non deve essere trattato come una chiave esterna permanente. Se l'identità a lungo termine è essenziale, conserva la mappatura nei dati dell'applicazione e verifica che la forma prevista esista ancora.

L'esempio seguente cerca per nome con confronto esatto e segnala l'ID interop a livello di diapositiva. Quando il modello non contiene la forma prevista, il codice segnala quel risultato invece di continuare con l'oggetto sbagliato.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Quando un'operazione è specifica per un tipo di forma, verifica la classe a runtime prima di usare membri specifici del tipo. Questo esempio aggiorna il testo e il testo alternativo solo se l'oggetto denominato è un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Modificare la collezione di forme**

I metodi per aggiungere, clonare, rimuovere e riordinare operano sulla collezione immediatamente. Se un'operazione cambia il numero o l'ordine delle forme, non continuare a fare affidamento sugli indici catturati prima di tale operazione.

### **Clonare una forma**

[ShapeCollection::addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addclone/) crea una copia indipendente e la aggiunge alla collezione di destinazione. [ShapeCollection::insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/insertclone/) crea anch'essa una copia ma la posiziona a un indice di ordine z specificato. Le sovraccariche che accettano coordinate spostano la clone senza cambiarne le dimensioni; le sovraccariche con larghezza e altezza possono ridimensionarla.

L'esempio crea una diapositiva di destinazione, clona un rettangolo etichettato in primo piano e inserisce un secondo clone in fondo. Le modifiche a ciascun clone non alterano la forma sorgente.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La clonazione copia il contenuto e la formattazione della forma, inclusi nome e testo alternativo. Assegna nuovi identificatori logici al clone quando tali valori devono essere unici. Le risorse usate da forme complesse sono gestite dalla presentazione, ma un clone rimane un nuovo elemento della collezione con una nuova identità di forma.

### **Rimuovere le forme**

[ShapeCollection::remove](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/remove/) elimina un oggetto forma specifico dalla sua collezione. Quando rimuovi più corrispondenze durante un'iterazione indicizzata, percorri dalla fine così ogni indice rimanente rimane valido.

Questo esempio rimuove ogni forma con un nome designato. Legge la forma all'indice corrente, non un elemento fisso della collezione, e non esegue cast inutili.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili rispetto agli indici salvati. Considera anche connettori, animazioni e altre funzionalità della presentazione che potrebbero fare riferimento all'oggetto rimosso; rimuovere una forma visibile può cambiare più del semplice aspetto della diapositiva.

### **Nascondere una forma**

Impostare [Shape::setHidden](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/sethidden/) a `true` mantiene la forma nella collezione ma impedisce che appaia nella presentazione normale. Il suo indice, la formattazione e il contenuto rimangono disponibili al codice, quindi nascondere è appropriato per elementi opzionali che possono essere ripristinati in seguito.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nascondere non è cancellazione né sicurezza. L'oggetto può ancora essere scoperto e reso nuovamente visibile da un utente o dal codice, e rimane parte del file della presentazione.

### **Modificare l'ordine Z**

Le forme sovrapposte sono dipinte nell'ordine della collezione. [ShapeCollection::reorder](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/reorder/) sposta una forma esistente a un indice di destinazione senza clonarla. L'indice `0` è il retro; `size() - 1` è il frontale.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il rettangolo viene creato per primo e inizialmente si trova dietro l'ellisse. Spostarlo all'indice finale lo porta in fronte. Finalizza l'ordine Z dopo aver aggiunto o clonato tutte le forme correlate, perché tali operazioni aggiungono o inseriscono nuovi elementi nella collezione e possono alterare lo stack previsto.

## **Ispezionare le forme nei layout diapositive**

Diapositive normali, layout e master hanno collezioni di forme separate. Una forma nella collezione di layout non è lo stesso oggetto di una forma simile posizionata su una diapositiva normale. Ispeziona le forme del layout quando devi comprendere o modificare la formattazione fornita da un layout.

L'esempio seguente legge il [FillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getfillformat/) e il [LineFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getlineformat/) di ogni forma del layout senza presumere che ogni forma sia una `AutoShape`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Modificare un layout può influire su più diapositive che lo utilizzano. Prima di cambiare una forma del layout, determina se una diapositiva normale eredita l'oggetto o contiene una sovrascrittura locale, e testa ogni diapositiva che utilizza quel layout.

## **Esportare una forma in SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/writeassvg/) scrive il contenuto renderizzato di una singola forma su uno stream. Il risultato contiene solo la forma, non l'intero sfondo della diapositiva o le forme vicine.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Mantieni la presentazione aperta durante il rendering. L'output dipende dalla formattazione della forma e da risorse come font e immagini. Se ti serve l'intera composizione, esporta la diapositiva anziché una singola forma. Il chiamante possiede lo stream e deve chiuderlo.

## **Allineare le forme**

[I metodi di SlideUtil::alignShapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideutil/alignshapes/) hanno overload che allineano tutte le forme o gli indici di collezione selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `alignToSlide` a `true` per usare i bordi della diapositiva; impostalo a `false` per allineare le forme selezionate relative l'una all'altra.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I riferimenti alle forme restituiti vengono convertiti nei loro indici correnti immediatamente prima dell'allineamento.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L'allineamento modifica le posizioni, non l'ordine Z. L'allineamento relativo normalmente richiede almeno due forme, mentre la distribuzione orizzontale o verticale necessita di un numero sufficiente di forme per definire la spaziatura. Ricalcola gli indici se modifichi la collezione prima di chiamare il metodo.

## **Ribaltare una forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapeframe/) memorizza posizione, dimensioni, impostazioni di ribaltamento orizzontale e verticale e rotazione. I valori `getFlipH` e `getFlipV` usano [NullableBool](https://reference.aspose.com/slides/it/php-java/aspose.slides/nullablebool/): `True` abilita il ribaltamento, `False` lo disabilita e `NotDefined` conserva lo stato non specificato/predefinito.

La presentazione di input sottostante contiene una forma non ribaltata.

![The shape before flipping](shape_to_be_flipped.png)

L'esempio preserva tutti gli altri valori del frame e sostituisce solo le due impostazioni di ribaltamento. Questo è importante perché assegnare un nuovo [Frame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/setframe/) sostituisce l'intero frame.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La forma salvata viene specchiata orizzontalmente e verticalmente mantenendo posizione, dimensioni e rotazione.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usare un indice di collezione come identificatore di una forma?**

Solo per elaborazioni a breve termine quando la collezione non cambierà prima dell'uso dell'indice. Preferisci una convenzione con `Name` o `AlternativeText` validata per modelli autori, o `OfficeInteropShapeId` per lavoro interop a livello di diapositiva.

**Nascondere una forma la rimuove dall'ordine Z?**

No. Una forma nascosta rimane nella collezione allo stesso indice. Può essere trovata, riordinata, modificata o resa di nuovo visibile.

**Perché una forma clonata è comparsa davanti a un’altra forma?**

`addClone` aggiunge il clone alla fine della collezione, che è il fronte dell'ordine Z. Usa `insertClone` per scegliere l'indice iniziale oppure `reorder` dopo aver aggiunto tutte le forme.