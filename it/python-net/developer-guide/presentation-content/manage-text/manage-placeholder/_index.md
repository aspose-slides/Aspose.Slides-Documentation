---
title: Gestire i segnaposti della presentazione in Python
linktitle: Gestire i segnaposti
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
description: "Scopri come ispezionare e modificare i segnaposti di testo, immagine, grafico e contenuto e comprendere l'ereditarietà dei segnaposti con Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un particolare tipo di contenuto in un modello di presentazione. Esempi comuni sono segnaposti per titolo, corpo, immagine, grafico e contenuto di uso generale. A differenza di una forma ordinaria, un segnaposto può ereditare la sua posizione, dimensione, formattazione e altre impostazioni da una diapositiva layout o da una diapositiva master.

Aspose.Slides espone le informazioni del segnaposto tramite la proprietà [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/). La proprietà restituisce un oggetto [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) oppure `None` per una forma normale. Usa [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) per determinare cosa è destinato a contenere il segnaposto.

La classe della forma è ancora rilevante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto vuoto di testo, immagine, grafico o contenuto è comunemente rappresentato da un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
- Un segnaposto di immagine popolato può essere rappresentato da un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
- Un segnaposto di grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/).
- Un segnaposto di contenuto può contenere diversi tipi di contenuto. Controlla sia [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) sia la classe della forma a runtime invece di presumere che ogni segnaposto sia un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) descrive il ruolo di un segnaposto; non garantisce la classe della forma a runtime. Utilizza sempre un controllo di tipo prima di accedere a membri testuali, immagine, grafico, tabella o specifici dei media.
{{% /alert %}}

## **Comprendere l'ereditarietà dei segnaposti**

I segnaposti formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposti a livello master.
2. Una diapositiva layout definisce la disposizione utilizzata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposti per quella diapositiva e può ereditare dal suo layout.

Chiama [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) per spostarti un livello più in alto in questa gerarchia. Un segnaposto di diapositiva normalmente restituisce il suo segnaposto layout; un segnaposto layout può restituire il suo segnaposto master. Il metodo restituisce `None` quando la forma non ha un segnaposto base.

Il seguente esempio elenca i segnaposti nella prima diapositiva e riporta i loro segnaposti base:

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

Modificare un segnaposto su una diapositiva normale crea o cambia una sovrascrizione locale per quella diapositiva. Modificare il layout o il master correlato può influire su tutte le diapositive che ancora ereditano quell'impostazione. Una forma locale ordinaria non ha un segnaposto base e non inizia a ereditare solo perché occupa le stesse coordinate.

## **Rimuovere lo stato del segnaposto**

Quando si adatta un modello, usa [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) per mantenere un oggetto esistente come forma ordinaria. La sua proprietà [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) diventa `None`, ma la forma rimane nella collezione della diapositiva. Al contrario, [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) elimina la forma da quella collezione.

Il seguente esempio richiede `template.pptx` con almeno una diapositiva e un segnaposto di testo non vuoto sulla prima diapositiva. Usa un segnaposto con formattazione ereditata dal suo layout o master per vedere l'effetto della rimozione di quella relazione. L'esempio controlla che la stessa forma rimanga, richiama nuovamente il metodo sulla forma ora ordinaria e salva il risultato.

{{% alert color="warning" title="Warning" %}}
Rimuovere lo stato del segnaposto non preserva automaticamente le impostazioni di aspetto ereditate. L'esempio seguente lascia deliberatamente tali impostazioni inalterate, quindi l'output potrebbe apparire diverso. Una forma la cui posizione e dimensione sono interamente ereditate può avere coordinate e dimensioni pari a zero dopo la chiamata e diventare invisibile anche se rimane nella collezione.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # Chiamare il metodo su una forma ordinaria non ha alcun effetto.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

Per un segnaposto corrispondente, tutti e tre i controlli stampano `True`. Il testo rimane, ma la posizione, dimensione, rotazione, carattere, allineamento del paragrafo, margini del riquadro di testo, ancoraggio verticale, riempimento e impostazioni di linea ereditate possono cambiare quando la relazione del segnaposto viene rimossa. Ad esempio, la formattazione del titolo ereditata può tornare alla formattazione di testo ordinario. Vedi [Slide Layout](/slides/it/python-net/slide-layout/) per ulteriori informazioni sui layout.

Per conservare l'aspetto previsto, acquisisci la posizione, dimensione e rotazione risolte prima della chiamata e copia i valori di formattazione effettiva richiesti in variabili separate. Recupera tali valori tramite [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), e [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/). Non fare affidamento solo sul mantenimento degli oggetti di formattazione effettiva, poiché i loro valori di formattazione del testo possono cambiare dopo la rimozione della relazione. Applica esplicitamente i valori acquisiti alla forma ordinaria successivamente, includendo la famiglia di caratteri, dimensione, stile, colore, impostazioni del paragrafo, impostazioni del riquadro di testo, riempimento e linea utilizzati dal tuo modello.

La geometria della forma ereditata potrebbe dover essere assegnata esplicitamente tramite [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/). Per un segnaposto di testo rettangolare, ciò significa assegnare [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/); ripristinare solo il riempimento e la linea potrebbe non ripristinare il rettangolo visibile. I modelli con effetti aggiuntivi o formattazione più complessa richiedono la gestione di tali impostazioni.

## **Modificare il testo in un segnaposto**

I segnaposti di titolo, titolo centrato, sottotitolo, corpo e testo supportano normalmente il testo. Verifica la presenza di [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) prima di utilizzare la sua proprietà [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/).

Questo esempio aggiorna il primo segnaposto di titolo sulla prima diapositiva e salva il risultato:

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

Questo modello evita di trattare i segnaposti di immagine, grafico, tabella o media come oggetti [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Identifica inoltre il segnaposto per scopo invece di fare affidamento su un indice di forma fragile.

## **Impostare il testo prompt su un layout**

Il testo prompt è l'istruzione di progettazione visualizzata in un segnaposto vuoto, ad esempio *Fai clic per aggiungere il titolo*. Imposta un testo prompt personalizzato sul segnaposto del layout invece di cercare di accedervi tramite la raccolta di forme di una diapositiva normale. Accedi al layout tramite [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) e itera su [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/).

Il seguente esempio cambia i prompt di titolo e sottotitolo sul layout utilizzato dalla prima diapositiva:

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

Il testo prompt non è contenuto normale di diapositiva. È destinato ai segnaposti vuoti nelle applicazioni di modifica come PowerPoint. Una volta che un utente o un programma fornisce contenuto reale, il prompt non viene più visualizzato. Modificare un prompt non sostituisce nemmeno il testo esistente sulle diapositive che usano il layout.

## **Aggiornare un segnaposto immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), sostituisci l'immagine tramite [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) e [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/).
- Se è ancora un segnaposto vuoto, aggiungi un frame immagine alle coordinate del segnaposto con [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) e rimuovi il segnaposto vuoto.

Il prossimo esempio gestisce entrambi i casi e salva la presentazione:

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

La sostituzione creata per un segnaposto vuoto è un frame immagine locale, non un nuovo segnaposto, poiché [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) è di sola lettura. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se mantenere la relazione del segnaposto è essenziale, prepara e popola il segnaposto in PowerPoint prima, quindi aggiorna il risultato [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) con Aspose.Slides.

Per la trasparenza dell'immagine, il ritaglio e altri effetti specifici delle immagini, vedi [Manage Picture Frames](/slides/it/python-net/picture-frame/). tali operazioni appartengono al frame immagine o al riempimento dell'immagine, non ai metadati del segnaposto.

## **Lavorare con segnaposti grafico e contenuto**

Un segnaposto di grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/). Questo esempio trova tale grafico sia per tipo di segnaposto sia per classe a runtime, cambia il suo titolo e salva il file:

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

Un segnaposto di contenuto generale solitamente ha [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/). In PowerPoint funge da avviatore per diversi tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo essere stato popolato, ispeziona la classe reale della forma per capire cosa contiene. I layout specializzati possono anche esporre [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), o [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/).

Aspose.Slides non converte un segnaposto [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vuoto in un [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) semplicemente modificando [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/); il tipo è di sola lettura. Per riempire programmaticamente un'area di grafico o contenuto vuota, aggiungi l'oggetto richiesto alle coordinate del segnaposto e poi rimuovi il segnaposto vuoto. Il seguente esempio lo fa per un grafico:

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

Il grafico aggiunto è un grafico locale ordinario. Occupa l'area del segnaposto ma non eredita dal segnaposto del layout. Usa gli articoli dedicati alla [chart management](/slides/it/python-net/powerpoint-charts/) quando devi sostituire le sue categorie, serie o dati della cartella di lavoro.

## **Esempio completo: Aggiornare testo o contenuto immagine**

Il seguente esempio end-to-end apre un modello, ricerca nella prima diapositiva un segnaposto di titolo o di immagine, verifica i tipi di segnaposto e forma, aggiorna il contenuto appropriato e salva l'output. L'esempio evita deliberatamente di presumere un indice di forma o di trattare ogni segnaposto come la stessa classe di forma.

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

**Cos'è un segnaposto base?**

Un segnaposto base è la forma corrispondente nel layout o nel master da cui un altro segnaposto eredita. Usa [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) per recuperarlo. Una forma locale ordinaria restituisce `None` perché non fa parte della gerarchia dei segnaposti.

**Posso cambiare tutti i titoli delle diapositive modificando un segnaposto del layout?**

Puoi cambiare la formattazione ereditata o il testo prompt tramite un layout, ma il contenuto del titolo esistente è memorizzato sulle diapositive normali. Per sostituire il testo del titolo effettivo in tutta la presentazione, itera sulle diapositive e aggiorna ciascun segnaposto di titolo.

**Come gestisco i segnaposti di data, numero diapositiva, intestazione e piè di pagina?**

Utilizza i gestori di intestazione e piè di pagina nel contesto appropriato (diapositiva, layout, master, note o opuscoli). Vedi [Manage Presentation Header and Footer](/slides/it/python-net/presentation-header-and-footer/) per esempi completi.