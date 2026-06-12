---
title: Crea Miniature delle Forme di Presentazione in Python
linktitle: Miniature delle Forme
type: docs
weight: 70
url: /it/python-net/create-shape-thumbnails/
keywords:
- miniatura forma
- immagine forma
- renderizzare forma
- renderizzazione forma
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Genera miniature di forma di alta qualità da diapositive PowerPoint e OpenDocument con Aspose.Slides per Python tramite .NET – crea ed esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides per Python tramite .NET viene utilizzato per creare file di presentazione in cui ogni pagina è una diapositiva. È possibile visualizzare queste diapositive in Microsoft PowerPoint aprendo il file di presentazione. Tuttavia, gli sviluppatori a volte potrebbero aver bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In tali casi, Aspose.Slides può generare immagini miniatura per le forme delle diapositive. Questo articolo spiega come utilizzare questa funzionalità.

## **Generare Miniature delle Forme dalle Diapositive**

Quando è necessario un'anteprima di un oggetto specifico anziché dell'intera diapositiva, è possibile renderizzare una miniatura per una forma individuale. Aspose.Slides consente di esportare qualsiasi forma in un'immagine, facilitando la creazione di anteprime leggere, icone o risorse per l'elaborazione successiva.

Per generare una miniatura da qualsiasi forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per ID o indice.
1. Ottenere un riferimento a una forma su quella diapositiva.
1. Renderizzare l'immagine miniatura della forma.
1. Salvare l'immagine miniatura nel formato desiderato.

L'esempio seguente genera una miniatura di una forma.

```py
import aspose.slides as slides

# Istanzia la classe Presentation per aprire il file di presentazione.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Crea un'immagine con la scala predefinita.
    with shape.get_image() as thumbnail:
        # Salva l'immagine su disco in formato PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Generare Miniature con un Fattore di Scala Personalizzato**

Questa sezione mostra come generare miniature di forme con un fattore di scala definito dall'utente in Aspose.Slides. Controllando la scala, è possibile perfezionare le dimensioni della miniatura per adattarle a anteprime, esportazioni o display ad alta risoluzione DPI.

Per generare una miniatura per qualsiasi forma su una diapositiva:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottenere una diapositiva per ID o indice.
1. Ottenere la forma target su quella diapositiva.
1. Renderizzare l'immagine miniatura della forma con la scala specificata.
1. Salvare l'immagine miniatura nel formato desiderato.

L'esempio seguente genera una miniatura con un fattore di scala definito dall'utente.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Istanzia la classe Presentation per aprire il file di presentazione.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Crea un'immagine con la scala definita.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Salva l'immagine su disco in formato PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Generare Miniature Utilizzando i Limiti di Aspetto della Forma**

Questa sezione mostra come generare una miniatura all'interno dei limiti di aspetto di una forma. Tiene conto di tutti gli effetti della forma. La miniatura generata è limitata dai bordi della diapositiva.

Per generare una miniatura di qualsiasi forma della diapositiva entro i limiti del suo aspetto:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottenere una diapositiva per ID o indice.
1. Ottenere la forma target su quella diapositiva.
1. Renderizzare l'immagine miniatura della forma con i limiti specificati.
1. Salvare l'immagine miniatura nel formato immagine desiderato.

L'esempio seguente crea una miniatura con limiti definiti dall'utente.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Istanzia la classe Presentation per aprire il file di presentazione.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Crea un'immagine della forma con i limiti di aspetto.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Salva l'immagine su disco in formato PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Quali formati immagine possono essere usati quando si salvano le miniature delle forme?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/python-net/aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/write_as_svg/) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti SHAPE e APPEARANCE quando si renderizza una miniatura?**

`SHAPE` utilizza la geometria della forma; `APPEARANCE` considera [effetti visivi](/slides/it/python-net/shape-effect/) (ombreggiature, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Verrà comunque renderizzata come miniatura?**

Una forma nascosta rimane parte del modello e può essere renderizzata; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell’immagine della forma.

**Le forme di gruppo, i grafici, SmartArt e altri oggetti complessi sono supportati?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/) e [SmartArt](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/)) può essere salvato come miniatura o come SVG.

**I font installati nel sistema influenzano la qualità delle miniature per le forme di testo?**

Sì. È necessario [fornire i font richiesti](/slides/it/python-net/custom-font/) (o [configurare le sostituzioni dei font](/slides/it/python-net/font-substitution/)) per evitare fallback indesiderati e riformattazioni del testo.