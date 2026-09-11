---
title: Crea miniature delle forme di presentazione in Python via Java
linktitle: Miniature di forme
type: docs
weight: 70
url: /it/python-java/create-shape-thumbnails/
keywords:
- miniatura forma
- immagine forma
- render forma
- rendering della forma
- limiti visivi
- limiti forma
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Genera miniature di forme di alta qualità dalle diapositive PowerPoint con Aspose.Slides per Python via Java – crea e esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides for Python via Java può essere utilizzato per creare file di presentazione in cui ogni pagina corrisponde a una diapositiva. Le diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Tuttavia, gli sviluppatori a volte hanno bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In tali casi, Aspose.Slides for Python via Java li aiuta a generare immagini in miniatura delle forme della diapositiva.

Questo articolo spiega come generare le miniature delle forme in diversi modi:

- Generazione di una miniatura di una forma all'interno di una diapositiva.
- Generazione di una miniatura di una forma per una forma della diapositiva con dimensioni definite dall'utente.
- Generazione di una miniatura di una forma nei limiti dell'aspetto della forma.

## **Genera una miniatura di forma da una diapositiva**
Per generare una miniatura di una forma da qualsiasi diapositiva usando Aspose.Slides for Python via Java, eseguire i seguenti passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva utilizzando il suo ID o indice.
1. [Ottieni l'immagine in miniatura della forma](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage) di una forma sulla diapositiva di riferimento alla scala predefinita.
1. Salva l'immagine in miniatura nel formato immagine preferito.

Questo esempio di codice mostra come generare una miniatura di una forma da una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Istanzia una classe Presentation che rappresenta il file della presentazione.
presentation = Presentation("Thumbnail.pptx")
try:
    # Crea un'immagine a piena scala.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Salva l'immagine su disco in formato PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Genera una miniatura con un fattore di scala definito dall'utente**
Per generare la miniatura della forma di una diapositiva usando Aspose.Slides for Python via Java, eseguire i seguenti passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva utilizzando il suo ID o indice.
1. [Ottieni l'immagine in miniatura della forma](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage) di una forma sulla diapositiva di riferimento con dimensioni definite dall'utente.
1. Salva l'immagine in miniatura nel formato immagine preferito.

Questo esempio di codice mostra come generare una miniatura di una forma basata su un fattore di scala definito:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Istanzia una classe Presentation che rappresenta il file della presentazione.
presentation = Presentation("Thumbnail.pptx")
try:
    # Crea un'immagine scalata di un fattore 2 in entrambe le direzioni.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Salva l'immagine su disco in formato PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Crea una miniatura dell'aspetto della forma basata sui limiti**
Questo metodo di creazione delle miniature delle forme consente agli sviluppatori di generare una miniatura nei limiti dell'aspetto della forma. Tiene conto di tutti gli effetti della forma. La miniatura della forma generata è limitata dai limiti della diapositiva. Per generare una miniatura di una forma della diapositiva entro i limiti del suo aspetto, eseguire i seguenti passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva utilizzando il suo ID o indice.
1. Recupera l'immagine in miniatura di una forma sulla diapositiva di riferimento utilizzando i limiti dell'aspetto.
1. Salva l'immagine in miniatura nel formato immagine preferito.

Questo esempio di codice è basato sui passaggi sopra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Istanzia una classe Presentation che rappresenta il file della presentazione.
presentation = Presentation("Thumbnail.pptx")
try:
    # Crea un'immagine a piena scala.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Salva l'immagine su disco in formato PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Ottieni i limiti visivi effettivi di una forma**

Le proprietà del frame di [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/) — i suoi metodi [getX](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getWidth) e [getHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getHeight) — descrivono il rettangolo memorizzato nel modello della presentazione. Il contenuto effettivamente renderizzato può estendersi oltre quel frame o occupare un rettangolo allineato agli assi diverso. Rotazione, contorni, punte di freccia, layout e overflow del testo, geometria SmartArt generata e altri effetti di rendering possono modificare l'area occupata.

Usa [Shape.getVisualBounds](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getVisualBounds) per calcolare quell'area occupata senza creare un'immagine. Il metodo restituisce un [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) in coordinate della diapositiva. Il rettangolo restituito non è ritagliato alla diapositiva, quindi le sue coordinate possono essere negative quando il contenuto si estende oltre l'origine della diapositiva.

L'esempio seguente ottiene e confronta i limiti del frame e quelli visivi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

Lo stesso [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) può essere utilizzato per allineare le forme vicine al suo bordo sinistro, destro, superiore o inferiore; riservare spazio sufficiente in un layout generato; o rilevare contenuto al di fuori di una regione consentita. I limiti visivi sono particolarmente utili per SmartArt, caselle di testo, frecce, immagini, forme ruotate e forme di gruppo, dove il frame memorizzato potrebbe non rappresentare il risultato renderizzato completo.

Usa [Shape.getVisualBounds](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getVisualBounds) quando hai bisogno di coordinate per layout o validazione e non ti serve una bitmap. Usa [Shape.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage) quando devi renderizzare la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapethumbnailbounds/), [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapethumbnailbounds/#Shape) dimensiona l'immagine dai limiti della forma, includendo le impostazioni del contorno, mentre [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapethumbnailbounds/#Appearance) la dimensiona dall'aspetto della forma e limita il risultato ai limiti della diapositiva. Al contrario, [Shape.getVisualBounds](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getVisualBounds) restituisce solo il rettangolo calcolato e non lo ritaglia alla diapositiva.

## **FAQ**

**Quali formati immagine possono essere utilizzati quando si salvano le miniature delle forme?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/python-java/aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#writeAsSvgToBytes) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti Shape e Appearance durante il rendering di una miniatura?**

`Shape` utilizza la geometria della forma; `Appearance` prende in considerazione gli [effetti visivi](/slides/it/python-java/shape-effect/) (ombreggiature, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Viene comunque renderizzata come miniatura?**

Una forma nascosta rimane parte del modello e può essere renderizzata; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell'immagine della forma.

**Le forme di gruppo, i grafici, SmartArt e altri oggetti complessi sono supportati?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/), e [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/)) può essere salvato come miniatura o come SVG.

**I font installati sul sistema influenzano la qualità delle miniature delle forme di testo?**

Sì. È necessario [fornire i font richiesti](/slides/it/python-java/custom-font/) (o [configurare le sostituzioni di font](/slides/it/python-java/font-substitution/)) per evitare fallback indesiderati e riorganizzazioni del testo.