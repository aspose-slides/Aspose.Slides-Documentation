---
title: Gestire gli sfondi delle presentazioni in Python
linktitle: Sfondo diapositiva
type: docs
weight: 20
url: /it/python-net/presentation-background/
keywords:
- sfondo presentazione
- sfondo diapositiva
- colore solido
- colore sfumato
- sfondo immagine
- trasparenza sfondo
- proprietà sfondo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come impostare sfondi dinamici nei file PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite .NET, con suggerimenti di codice per migliorare le tue presentazioni."
---
## **Introduzione**

I colori solidi, le sfumature e le immagini sono comunemente usati per gli sfondi delle diapositive. È possibile impostare lo sfondo per una **diapositiva normale** (una singola diapositiva) o per una **diapositiva master** (applicata a più diapositive contemporaneamente).

![Sfondo PowerPoint](powerpoint-background.png)

## **Imposta uno sfondo a colore solido per una diapositiva normale**

Aspose.Slides consente di impostare un colore solido come sfondo per una diapositiva specifica in una presentazione, anche se la presentazione utilizza una diapositiva master. La modifica si applica solo alla diapositiva selezionata.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/python-net/aspose.slides/backgroundtype/) della diapositiva su `OWN_BACKGROUND`.
3. Imposta lo [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) dello sfondo della diapositiva su `SOLID`.
4. Utilizza la proprietà `solid_fill_color` su [FillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/) per specificare il colore solido dello sfondo.
5. Salva la presentazione modificata.

Il seguente esempio Python mostra come impostare un colore solido blu come sfondo per una diapositiva normale:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crea un'istanza della classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Imposta il colore di sfondo della diapositiva su blu.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Salva la presentazione su disco.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta uno sfondo a colore solido per la diapositiva master**

Aspose.Slides consente di impostare un colore solido come sfondo per la diapositiva master in una presentazione. La diapositiva master agisce come modello che controlla la formattazione per tutte le diapositive, quindi quando scegli un colore solido per lo sfondo della diapositiva master, questo viene applicato a ogni diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/python-net/aspose.slides/backgroundtype/) della diapositiva master (tramite `masters`) su `OWN_BACKGROUND`.
3. Imposta lo [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) dello sfondo della diapositiva master su `SOLID`.
4. Utilizza la proprietà `solid_fill_color` su [FillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/) per specificare il colore solido dello sfondo.
5. Salva la presentazione modificata.

Il seguente esempio Python mostra come impostare un colore solido (verde foresta) come sfondo per una diapositiva master:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crea un'istanza della classe Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Imposta il colore di sfondo della diapositiva master su verde foresta.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Salva la presentazione su disco.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta uno sfondo sfumato per una diapositiva**

Una sfumatura è un effetto grafico creato da una graduale variazione di colore. Quando viene usata come sfondo di una diapositiva, la sfumatura può rendere le presentazioni più artistiche e professionali. Aspose.Slides consente di impostare un colore sfumato come sfondo per le diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/python-net/aspose.slides/backgroundtype/) della diapositiva su `OWN_BACKGROUND`.
3. Imposta lo [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) dello sfondo della diapositiva su `GRADIENT`.
4. Utilizza la proprietà `gradient_format` su [FillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/) per configurare le impostazioni della sfumatura preferita.
5. Salva la presentazione modificata.

Il seguente esempio Python mostra come impostare un colore sfumato come sfondo per una diapositiva:

```python
import aspose.slides as slides

# Crea un'istanza della classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Applica un effetto gradiente allo sfondo.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Salva la presentazione su disco.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta un'immagine come sfondo di una diapositiva**

Oltre ai riempimenti solidi e sfumati, Aspose.Slides consente di utilizzare immagini come sfondi delle diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/python-net/aspose.slides/backgroundtype/) della diapositiva su `OWN_BACKGROUND`.
3. Imposta lo [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) dello sfondo della diapositiva su `PICTURE`.
4. Carica l'immagine che vuoi usare come sfondo della diapositiva.
5. Aggiungi l'immagine alla raccolta di immagini della presentazione.
6. Utilizza la proprietà `picture_fill_format` su [FillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/) per assegnare l'immagine come sfondo.
7. Salva la presentazione modificata.

Il seguente esempio Python mostra come impostare un'immagine come sfondo per una diapositiva:

```python
import aspose.slides as slides

# Crea un'istanza della classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Imposta le proprietà dell'immagine di sfondo.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Carica l'immagine.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Aggiungi l'immagine alla raccolta di immagini della presentazione.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Salva la presentazione su disco.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

Il seguente esempio di codice mostra come impostare il tipo di riempimento dello sfondo su un'immagine a mosaico e modificare le proprietà di mosaico:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Imposta l'immagine usata per il riempimento dello sfondo.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Imposta la modalità di riempimento immagine su Tile e regola le proprietà del tassello.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
Leggi di più: [**Tile Picture As Texture**](/slides/it/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifica la trasparenza dell'immagine di sfondo**

Potresti voler regolare la trasparenza dell'immagine di sfondo di una diapositiva per far risaltare i contenuti della diapositiva. Il seguente codice Python mostra come cambiare la trasparenza per l'immagine di sfondo di una diapositiva:

```python
transparency_value = 30  # Per esempio.

# Ottieni la collezione delle operazioni di trasformazione dell'immagine.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Trova un effetto di trasparenza a percentuale fissa esistente.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Imposta il nuovo valore di trasparenza.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Ottieni il valore di sfondo della diapositiva**

Aspose.Slides fornisce la classe [IBackgroundEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ibackgroundeffectivedata/) per recuperare i valori di sfondo effettivi di una diapositiva. Questa classe espone il [FillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/) e l'[EffectFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/effectformat/) effettivi.

Utilizzando la proprietà `background` della classe [BaseSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/), è possibile ottenere lo sfondo effettivo per una diapositiva.

Il seguente esempio Python mostra come ottenere il valore di sfondo effettivo di una diapositiva:

```python
import aspose.slides as slides

# Crea un'istanza della classe Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Recupera lo sfondo effettivo, tenendo conto di master, layout e tema.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**Posso ripristinare uno sfondo personalizzato e restaurare lo sfondo del tema/layout?**

Sì. Rimuovi il riempimento personalizzato della diapositiva e lo sfondo verrà nuovamente ereditato dal corrispondente [layout](/slides/it/python-net/slide-layout/)/[master](/slides/it/python-net/slide-master/) (cioè dallo [sfondo del tema](/slides/it/python-net/presentation-theme/)).

**Cosa succede allo sfondo se modifico in seguito il tema della presentazione?**

Se una diapositiva ha un proprio riempimento, rimarrà invariato. Se lo sfondo è ereditato dal [layout](/slides/it/python-net/slide-layout/)/[master](/slides/it/python-net/slide-master/), verrà aggiornato per corrispondere al [nuovo tema](/slides/it/python-net/presentation-theme/).