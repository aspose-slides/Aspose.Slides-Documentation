---
title: Crea miniature di forme di presentazione in Python
linktitle: Miniature di forme
type: docs
weight: 70
url: /it/python-net/create-shape-thumbnails/
keywords:
- miniatura di forma
- immagine di forma
- renderizza forma
- renderizzazione della forma
- limiti visivi
- limiti della forma
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Genera miniature di forma di alta qualità da diapositive PowerPoint e OpenDocument con Aspose.Slides per Python tramite .NET – crea ed esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides per Python tramite .NET viene utilizzato per creare file di presentazione in cui ogni pagina è una diapositiva. È possibile visualizzare queste diapositive in Microsoft PowerPoint aprendo il file di presentazione. Tuttavia, gli sviluppatori a volte hanno bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In tali casi, Aspose.Slides può generare immagini in miniatura per le forme delle diapositive. Questo articolo spiega come utilizzare questa funzionalità.

## **Generare miniature di forme dalle diapositive**

Quando hai bisogno di un'anteprima di un oggetto specifico anziché dell'intera diapositiva, puoi renderizzare una miniatura per una singola forma. Aspose.Slides ti consente di esportare qualsiasi forma in un'immagine, facilitando la creazione di anteprime leggere, icone o risorse per l'elaborazione successiva.

Per generare una miniatura da qualsiasi forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo ID o indice.
1. Ottieni un riferimento a una forma su quella diapositiva.
1. Renderizza l'immagine miniatura della forma.
1. Salva l'immagine miniatura nel formato desiderato.

L'esempio seguente genera una miniatura di forma.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per aprire il file di presentazione.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Crea un'immagine con la scala predefinita.
    with shape.get_image() as thumbnail:
        # Salva l'immagine su disco in formato PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Generare miniature con un fattore di scala personalizzato**

Questa sezione mostra come generare miniature di forme con un fattore di scala definito dall'utente in Aspose.Slides. Controllando la scala, puoi regolare finemente le dimensioni della miniatura per adeguarle a anteprime, esportazioni o display ad alta risoluzione DPI.

Per generare una miniatura per qualsiasi forma su una diapositiva:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni una diapositiva tramite il suo ID o indice.
1. Ottieni la forma di destinazione su quella diapositiva.
1. Renderizza l'immagine miniatura della forma con la scala specificata.
1. Salva l'immagine miniatura nel formato desiderato.

L'esempio seguente genera una miniatura con un fattore di scala definito dall'utente.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Istanziare la classe Presentation per aprire il file di presentazione.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Crea un'immagine con la scala definita.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Salva l'immagine su disco in formato PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Generare miniature usando i limiti di aspetto di una forma**

Questa sezione mostra come generare una miniatura entro i limiti di aspetto di una forma. Tiene conto di tutti gli effetti della forma. La miniatura generata è limitata dai limiti della diapositiva.

Per generare una miniatura di qualsiasi forma della diapositiva entro i limiti del suo aspetto:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni una diapositiva tramite il suo ID o indice.
1. Ottieni la forma di destinazione su quella diapositiva.
1. Renderizza l'immagine miniatura della forma con i limiti specificati.
1. Salva l'immagine miniatura nel formato immagine desiderato.

L'esempio seguente crea una miniatura con limiti definiti dall'utente.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Istanziare la classe Presentation per aprire il file di presentazione.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Creare un'immagine della forma con i limiti di aspetto.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Salvare l'immagine su disco in formato PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Ottenere i limiti visivi effettivi di una forma**

Le proprietà del frame di una [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/)—`Shape.x`, `Shape.y`, `Shape.width` e `Shape.height`—descrivono il rettangolo memorizzato nel modello della presentazione. Il contenuto effettivamente renderizzato può estendersi oltre quel frame o occupare un rettangolo allineato sugli assi diverso. Rotazione, contorni, punte di freccia, layout e overflow del testo, geometria SmartArt generata e altri effetti di rendering possono tutti modificare l'area occupata.

Utilizza [Shape.get_visual_bounds](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_visual_bounds/) per calcolare quell'area occupata senza creare un'immagine. Il metodo restituisce un rettangolo a virgola mobile nelle coordinate della diapositiva. Il rettangolo restituito non è ritagliato alla diapositiva, quindi le sue coordinate possono essere negative quando il contenuto si estende oltre l'origine della diapositiva.

L'esempio seguente ottiene e confronta i limiti del frame e i limiti visivi:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Lo stesso rettangolo può essere utilizzato per allineare le forme vicine al suo bordo `left`, `right`, `top` o `bottom`; riservare spazio sufficiente in un layout generato; o rilevare contenuto al di fuori di una regione consentita. I limiti visivi sono particolarmente utili per SmartArt, caselle di testo, frecce, immagini, forme ruotate e forme di gruppo, dove il frame memorizzato potrebbe non rappresentare il risultato renderizzato completo.

Utilizza [Shape.get_visual_bounds](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_visual_bounds/) quando ti servono coordinate per il layout o la convalida e non hai bisogno di un bitmap. Utilizza [Shape.get_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_image/) quando devi renderizzare la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.SHAPE` dimensiona l'immagine in base ai limiti della forma, includendo le impostazioni del contorno, mentre `ShapeThumbnailBounds.APPEARANCE` la dimensiona in base all'aspetto della forma e limita il risultato ai limiti della diapositiva. Al contrario, `Shape.get_visual_bounds` restituisce solo il rettangolo calcolato e non lo ritaglia alla diapositiva.

## **FAQ**

**Quali formati immagine possono essere usati quando si salvano le miniature delle forme?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/python-net/aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/write_as_svg/) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti SHAPE e APPEARANCE quando si renderizza una miniatura?**

`SHAPE` utilizza la geometria della forma; `APPEARANCE` prende in considerazione i [effetti visivi](/slides/it/python-net/shape-effect/) (ombre, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Verrà comunque renderizzata come miniatura?**

Una forma nascosta rimane parte del modello e può essere renderizzata; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell'immagine della forma.

**Le forme di gruppo, i grafici, SmartArt e altri oggetti complessi sono supportati?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/) e [SmartArt](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/)) può essere salvato come miniatura o come SVG.

**I font installati nel sistema influiscono sulla qualità delle miniature delle forme di testo?**

Sì. Dovresti [fornire i font necessari](/slides/it/python-net/custom-font/) (o [configurare le sostituzioni dei font](/slides/it/python-net/font-substitution/)) per evitare fallback indesiderati e il riadattamento del testo.