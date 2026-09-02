---
title: Gestisci i segnaposto della presentazione in Python
linktitle: Gestisci i segnaposto
type: docs
weight: 10
url: /it/python-net/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- segnaposto contenuto
- testo di suggerimento
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come ispezionare e modificare i segnaposto di testo, immagine, grafico e contenuto e comprendere l'ereditarietà dei segnaposto con Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un particolare tipo di contenuto in un modello di presentazione. Esempi comuni sono titolo, corpo, immagine, grafico e segnaposto di contenuto a uso generico. A differenza di una forma ordinaria, un segnaposto può ereditare posizione, dimensione, formattazione e altre impostazioni da una diapositiva layout o master.

Aspose.Slides espone le informazioni sui segnaposto tramite la proprietà [Shape.placeholder](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/placeholder/). La proprietà restituisce un oggetto [Placeholder](https://reference.aspose.com/slides/it/python-net/aspose.slides/placeholder/) o `None` per una forma normale. Usa [Placeholder.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/placeholder/type/) per determinare cosa il segnaposto è destinato a contenere.

La classe della forma è comunque importante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto vuoto di testo, immagine, grafico o contenuto è comunemente rappresentato da un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/).
- Un segnaposto immagine popolato può essere rappresentato da un [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/).
- Un segnaposto grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/).
- Un segnaposto di contenuto può contenere diversi tipi di contenuto. Controlla sia [Placeholder.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/placeholder/type/) sia la classe della forma a runtime invece di supporre che ogni segnaposto sia un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Avviso" %}}
[Placeholder.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/placeholder/type/) descrive il ruolo di un segnaposto; non garantisce la classe della forma a runtime. Usa sempre un controllo di tipo prima di accedere a membri specifici di testo, immagine, grafico, tabella o media.
{{% /alert %}}

## **Comprendere l'ereditarietà dei segnaposto**

I segnaposto formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposto a livello master.
2. Una diapositiva layout definisce la disposizione usata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposto per quella diapositiva e può ereditare dal suo layout.

Chiama [Shape.get_base_placeholder](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_base_placeholder/) per spostarti di un livello verso l'alto in questa gerarchia. Un segnaposto di diapositiva normalmente restituisce il suo segnaposto di layout; un segnaposto di layout può restituire il suo segnaposto master. Il metodo restituisce `None` quando la forma non ha un segnaposto di base.

L'esempio seguente elenca i segnaposto nella prima diapositiva e riporta i loro segnaposto di base:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Modificare un segnaposto su una diapositiva normale crea o cambia una sovrascrittura locale per quella diapositiva. Modificare il layout o il master correlato può influire su tutte le diapositive che ereditano ancora quella impostazione. Una forma ordinaria locale non ha un segnaposto di base e non inizia a ereditare solo perché occupa le stesse coordinate.

## **Modificare il testo in un segnaposto**

I segnaposto di titolo, titolo centrato, sottotitolo, corpo e testo normalmente supportano il testo. Controlla la presenza di un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) prima di utilizzare la sua proprietà [text_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/text_frame/).

Questo esempio aggiorna il primo segnaposto titolo nella prima diapositiva e salva il risultato:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Questo modello evita di trattare segnaposto di immagine, grafico, tabella o media come oggetti [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/). Identifica inoltre il segnaposto per scopo invece di affidarsi a un indice di forma fragile.

## **Impostare il testo di suggerimento su un layout**

Il testo di suggerimento è l'istruzione di design‑time visualizzata in un segnaposto vuoto, ad esempio *Click to add title*. Imposta il testo di suggerimento personalizzato sul segnaposto del layout anziché cercare di raggiungerlo tramite la collezione di forme di una diapositiva normale. Accedi al layout tramite [Slide.layout_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/layout_slide/) e itera su [LayoutSlide.shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/shapes/).

L'esempio seguente cambia i suggerimenti di titolo e sottotitolo sul layout utilizzato dalla prima diapositiva:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Il testo di suggerimento non è contenuto normale della diapositiva. È destinato ai segnaposto vuoti nelle applicazioni di editing come PowerPoint. Una volta che un utente o un programma fornisce contenuto reale, il suggerimento non viene più visualizzato. Modificare un suggerimento inoltre non sostituisce il testo esistente sulle diapositive che usano il layout.

## **Aggiornare un segnaposto immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/), sostituisci l'immagine tramite [PictureFillFormat.picture](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/picture/) e [Picture.image](https://reference.aspose.com/slides/it/python-net/aspose.slides/picture/image/).
- Se è ancora un segnaposto vuoto, aggiungi un frame immagine alle coordinate del segnaposto con [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_picture_frame/) e rimuovi il segnaposto vuoto.

L'esempio successivo supporta entrambi i casi e salva la presentazione:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

La sostituzione creata per un segnaposto vuoto è un frame immagine locale, non un nuovo segnaposto, perché [Shape.placeholder](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/placeholder/) è di sola lettura. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se mantenere la relazione del segnaposto è essenziale, prepara e popola il segnaposto in PowerPoint prima, poi aggiorna il [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) risultante con Aspose.Slides.

Per trasparenza dell'immagine, ritaglio e altri effetti specifici dell'immagine, vedi [Manage Picture Frames](/slides/it/python-net/picture-frame/). Quelle operazioni appartengono al frame immagine o al riempimento immagine, non ai metadati del segnaposto.

## **Lavorare con segnaposto di grafico e contenuto**

Un segnaposto grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/). Questo esempio trova tale grafico sia per tipo di segnaposto sia per classe a runtime, ne cambia il titolo e salva il file:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Un segnaposto di contenuto generale solitamente ha [PlaceholderType.OBJECT](https://reference.aspose.com/slides/it/python-net/aspose.slides/placeholdertype/). In PowerPoint agisce da avviatore per diversi tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo che è stato popolato, ispeziona la classe della forma reale per capire cosa contiene. I layout specializzati possono anche esporre [PlaceholderType.CHART](https://reference.aspose.com/slides/it/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/it/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/it/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/it/python-net/aspose.slides/placeholdertype/), o [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/it/python-net/aspose.slides/placeholdertype/).

Aspose.Slides non converte un segnaposto [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) vuoto in un [Chart](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/) semplicemente modificando [Placeholder.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/placeholder/type/); il tipo è di sola lettura. Per riempire programmaticamente un'area grafico o contenuto vuota, aggiungi l'oggetto richiesto alle coordinate del segnaposto e poi rimuovi il segnaposto vuoto. L'esempio seguente lo fa per un grafico:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

Il grafico aggiunto è un grafico locale ordinario. Occupa l'area del segnaposto ma non eredita dal segnaposto del layout. Usa gli articoli dedicati alla [chart management](/slides/it/python-net/powerpoint-charts/) quando devi sostituire categorie, serie o dati della cartella di lavoro.

## **Esempio completo: aggiornare testo o contenuto immagine**

L'esempio end‑to‑end seguente apre un modello, ricerca nella prima diapositiva un segnaposto titolo o immagine, verifica i tipi di segnaposto e forma, aggiorna il contenuto appropriato e salva il risultato. L'esempio evita deliberatamente di supporre un indice di forma o di trattare ogni segnaposto con la stessa classe di forma.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Che cos'è un segnaposto di base?**

Un segnaposto di base è la forma corrispondente nel layout o nel master da cui un altro segnaposto eredita. Usa [Shape.get_base_placeholder](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_base_placeholder/) per recuperarlo. Una forma locale ordinaria restituisce `None` perché non fa parte della gerarchia dei segnaposto.

**Posso modificare tutti i titoli delle diapositive modificando un segnaposto layout?**

Puoi modificare la formattazione o il testo di suggerimento ereditato tramite un layout, ma il contenuto del titolo esistente è memorizzato sulle diapositive normali. Per sostituire il testo del titolo su tutta la presentazione, itera le diapositive e aggiorna ogni segnaposto titolo.

**Come gestisco i segnaposto data, numero diapositiva, intestazione e piè di pagina?**

Usa i manager di intestazione e piè di pagina nella diapositiva, layout, master, note o handout appropriati. Vedi [Manage Presentation Header and Footer](/slides/it/python-net/presentation-header-and-footer/) per esempi completi.

---
title: Gestisci i segnaposto della presentazione in Python
linktitle: Gestisci i segnaposto
type: docs
weight: 10
url: /it/python-net/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- segnaposto contenuto
- testo di suggerimento
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come ispezionare e modificare i segnaposto di testo, immagine, grafico e contenuto e comprendere l'ereditarietà dei segnaposto con Aspose.Slides per Python tramite .NET."
---