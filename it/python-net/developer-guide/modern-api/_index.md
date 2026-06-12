---
title: Migliora l'elaborazione delle immagini con l'API Moderna
linktitle: API Moderna
type: docs
weight: 280
url: /it/python-net/modern-api/
keywords:
- API moderna
- disegno
- miniatura di diapositiva
- diapositiva in immagine
- miniatura di forma
- forma in immagine
- miniatura di presentazione
- presentazione in immagini
- aggiungi immagine
- aggiungi foto
- Python
- Aspose.Slides
description: "Modernizza l'elaborazione delle immagini delle diapositive sostituendo le API di imaging deprecate con l'API Moderna Python per un'automazione fluida di PowerPoint e OpenDocument."
---
## **Introduzione**

L'API pubblica di Aspose.Slides per Python dipende attualmente dai seguenti tipi `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

A partire dalla versione 24.4, questa API pubblica è **deprecata** a causa delle [modifiche](https://releases.aspose.com/slides/it/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) nell'API pubblica di Aspose.Slides per Python.

Per eliminare `aspose.pydrawing` dall'API pubblica, abbiamo introdotto l'**API Moderna**. I metodi che utilizzano `aspose.pydrawing.Image` e `aspose.pydrawing.Bitmap` sono deprecati e devono essere sostituiti con le loro controparti dell'API Moderna. I metodi che utilizzano `aspose.pydrawing.Graphics` sono deprecati e non hanno una sostituzione diretta nell'API Moderna.

Nelle versioni attuali, trattate l'API pubblica che dipende da `aspose.pydrawing` come legacy/deprecata. Utilizzate l'API Moderna per nuovo codice e per la migrazione dei flussi di lavoro di elaborazione delle immagini esistenti.

## **API Moderna**

Sono state aggiunte le seguenti classi ed enum all'API pubblica:

- [aspose.slides.IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) - rappresenta un'immagine raster o vettoriale.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/imageformat/) - rappresenta un formato di file immagine.
- [aspose.slides.Images](https://reference.aspose.com/slides/it/python-net/aspose.slides/images/) - fornisce metodi per creare e lavorare con [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/).

Utilizzate `get_image` per rendere una singola diapositiva o forma. Utilizzate `get_images` per rendere più diapositive della presentazione. Utilizzate i metodi di [Images](https://reference.aspose.com/slides/it/python-net/aspose.slides/images/) per caricare immagini, `add_image` con [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) per aggiungerle a una presentazione, e `replace_image` con [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) per aggiornare un'immagine esistente nella presentazione.

Uno scenario tipico di utilizzo della nuova API è il seguente:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **Sostituire il Codice Obsoleto con l'API Moderna**

Per una transizione più agevole, la nuova classe [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) rispecchia le API separate delle classi `aspose.pydrawing.Image` e `aspose.pydrawing.Bitmap`. Nella maggior parte dei casi è sufficiente sostituire le chiamate ai metodi che usano `aspose.pydrawing` con le loro controparti dell'API Moderna.

### **Ottenere una Miniatura di Diapositiva**

**API Deprecata:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**API Moderna:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Ottenere una Miniatura di Forma**

**API Deprecata:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**API Moderna:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Ottenere una Miniatura di Presentazione**

**API Deprecata:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**API Moderna:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Aggiungere un'Immagine a una Presentazione**

**API Deprecata:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**API Moderna:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Metodi e Proprietà da Rimuovere e le Loro Sostituzioni Moderne**

### **Classe Presentation**

|Firma del Metodo|Firma del Metodo Sostitutivo|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Nessuna sostituzione nell'API Moderna|
|save(fname, format, options, response, show_inline)|Nessuna sostituzione nell'API Moderna|
|print()|Nessuna sostituzione nell'API Moderna|
|print(printer_settings)|Nessuna sostituzione nell'API Moderna|
|print(printer_name)|Nessuna sostituzione nell'API Moderna|
|print(printer_settings, pres_name)|Nessuna sostituzione nell'API Moderna|

### **Classe Slide**

|Firma del Metodo|Firma del Metodo Sostitutivo|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Nessuna sostituzione nell'API Moderna|
|render_to_graphics(options, graphics, scale_x, scale_y)|Nessuna sostituzione nell'API Moderna|
|render_to_graphics(options, graphics, rendering_size)|Nessuna sostituzione nell'API Moderna|

### **Classe Shape**

|Firma del Metodo|Firma del Metodo Sostitutivo|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **Classe ImageCollection**

|Firma del Metodo|Firma del Metodo Sostitutivo|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **Classe PPImage**

|Firma del Metodo/Proprietà|Firma del Metodo/Proprietà Sostitutiva|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/image/)|

### **Classe ImageWrapperFactory**

|Firma del Metodo|Firma del Metodo Sostitutivo|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **Classe PatternFormat**

|Firma del Metodo|Firma del Metodo Sostitutivo|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/it/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/it/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **Classe IPatternFormatEffectiveData**

|Firma del Metodo|Firma del Metodo Sostitutivo|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/it/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Classe Output**

|Firma del Metodo|Firma del Metodo Sostitutivo|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **Supporto API per aspose.pydrawing.Graphics**

I metodi che usano `aspose.pydrawing.Graphics` sono deprecati e non hanno una sostituzione diretta nell'API Moderna.

Utilizzate i metodi di rendering delle immagini dell'API Moderna al posto dell'API che rende su `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**Perché `aspose.pydrawing.Graphics` è stato rimosso?**

Il supporto per `aspose.pydrawing.Graphics` è deprecato nell'API pubblica per unificare il lavoro di rendering e immagini, eliminare le dipendenze specifiche della piattaforma e passare a un approccio cross‑platform con [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/). Utilizzate `get_image` o `get_images` invece del rendering su `aspose.pydrawing.Graphics`.

**Qual è il vantaggio pratico di [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) rispetto a `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`?**

[IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) unifica la gestione di immagini raster e vettoriali, semplifica il salvataggio in vari formati tramite [ImageFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/imageformat/), riduce la dipendenza da pydrawing e rende il codice più portabile tra ambienti.

**La Modern API influirà sulle prestazioni di generazione delle miniature?**

Passare da `get_thumbnail` a `get_image` non peggiora gli scenari: i nuovi metodi offrono le stesse capacità di produrre immagini con opzioni e dimensioni, mantenendo il supporto per le opzioni di rendering. Il guadagno o la perdita specifica dipende dallo scenario, ma funzionalmente le sostituzioni sono equivalenti.