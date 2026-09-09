---
title: Gestire i segnaposti della presentazione in Python
linktitle: Gestire i segnaposti
type: docs
weight: 10
url: /it/python-java/manage-placeholder/
keywords:
- segnaposto
- segnaposto testo
- segnaposto immagine
- segnaposto grafico
- segnaposto contenuto
- testo di suggerimento
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come ispezionare e modificare i segnaposti di testo, immagine, grafico e contenuto e comprendere l'eredità dei segnaposti con Aspose.Slides per Python tramite Java."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un particolare tipo di contenuto in un modello di presentazione. Esempi comuni sono titolo, corpo, immagine, grafico e segnaposti di contenuto generico. A differenza di una forma ordinaria, un segnaposto può ereditare la posizione, le dimensioni, la formattazione e altre impostazioni da una diapositiva layout o da una diapositiva master.

Aspose.Slides espone le informazioni sui segnaposti tramite il metodo [Shape.getPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getPlaceholder). Il metodo restituisce un oggetto [Placeholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/placeholder/) o `None` per una forma normale. Usa [Placeholder.getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/placeholder/#getType) per determinare a cosa è destinato il segnaposto.

Il tipo di forma è ancora rilevante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto vuoto di testo, immagine, grafico o contenuto è comunemente rappresentato da un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/).
- Un segnaposto immagine popolato può essere rappresentato da un [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/).
- Un segnaposto grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/).
- Un segnaposto di contenuto può contenere diversi tipi di contenuto. Controlla sia [Placeholder.getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/placeholder/#getType) sia il tipo di forma a runtime invece di presumere che ogni segnaposto sia un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Avviso" %}}
[Placeholder.getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/placeholder/#getType) descrive il ruolo di un segnaposto; non garantisce il tipo di forma a runtime. Utilizza sempre un controllo del tipo prima di accedere a membri specifici di testo, immagine, grafico, tabella o media.
{{% /alert %}}

## **Comprendere l'eredità dei segnaposti**

I segnaposti formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposti a livello master.
2. Una diapositiva layout definisce la disposizione usata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposti per quella diapositiva e può ereditare dal suo layout.

Chiama [Shape.getBasePlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getBasePlaceholder) per spostarti di un livello verso l'alto nella gerarchia. Un segnaposto diapositiva di solito restituisce il suo segnaposto layout; un segnaposto layout può restituire il suo segnaposto master. Il metodo restituisce `None` quando la forma non ha un segnaposto base.

L'esempio seguente elenca i segnaposti nella prima diapositiva e riporta i loro segnaposti base:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Modificare un segnaposto su una diapositiva normale crea o modifica una sovrascrittura locale per quella diapositiva. Modificare il relativo layout o master può influenzare tutte le diapositive che ancora ereditano quell'impostazione. Una forma ordinaria locale non ha segnaposto base e non inizia a ereditare solo perché occupa le stesse coordinate.

## **Modificare il testo in un segnaposto**

I segnaposti titolo, titolo centrato, sottotitolo, corpo e testo normalmente supportano il testo. Verifica la presenza di un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) prima di usare il suo metodo [getTextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/#getTextFrame).

Questo esempio aggiorna il primo segnaposto titolo nella prima diapositiva e salva il risultato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Questo schema evita di trattare segnaposti immagine, grafico, tabella o media come [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/). Identifica inoltre il segnaposto per scopo invece di fidarsi di un indice di forma fragile.

## **Impostare il testo di prompt su un layout**

Il testo di prompt è l'istruzione mostrata in fase di progettazione in un segnaposto vuoto, ad esempio *Fare clic per aggiungere il titolo*. Imposta un testo di prompt personalizzato sul segnaposto layout invece di provare a raggiungerlo tramite la collezione di forme di una diapositiva normale. Accedi al layout tramite [Slide.getLayoutSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getLayoutSlide) e itera sulla collezione restituita da [BaseSlide.getShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getShapes).

L'esempio seguente modifica i prompt titolo e sottotitolo sul layout usato dalla prima diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il testo di prompt non è contenuto normale della diapositiva. È destinato ai segnaposti vuoti nelle applicazioni di editing come PowerPoint. Una volta che un utente o un programma fornisce contenuto reale, il prompt non è più visualizzato. Modificare un prompt non sostituisce nemmeno il testo esistente sulle diapositive che usano quel layout.

## **Aggiornare un segnaposto immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/), sostituisci l'immagine tramite [PictureFillFormat.getPicture](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#getPicture) e [Picture.setImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/picture/#setImage).
- Se è ancora un segnaposto vuoto, aggiungi un picture frame alle coordinate del segnaposto con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addPictureFrame) e rimuovi il segnaposto vuoto.

Il prossimo esempio supporta entrambi i casi e salva la presentazione:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La sostituzione creata per un segnaposto vuoto è un picture frame locale, non un nuovo segnaposto, perché [Shape.getPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getPlaceholder) non fornisce un setter. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se mantenere la relazione di segnaposto è essenziale, prepara e popola il segnaposto in PowerPoint prima, poi aggiorna il [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) risultante con Aspose.Slides.

Per trasparenza dell'immagine, ritaglio e altri effetti specifici dell'immagine, consulta [Gestire i picture frame](/slides/it/python-java/picture-frame/). Queste operazioni appartengono al picture frame o al picture fill, non ai metadati del segnaposto.

## **Lavorare con segnaposti grafico e contenuto**

Un segnaposto grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/). Questo esempio trova tale grafico sia per tipo di segnaposto sia per tipo a runtime, ne modifica il titolo e salva il file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Un segnaposto di contenuto generale di solito ha [PlaceholderType.Object](https://reference.aspose.com/slides/it/python-java/aspose.slides/placeholdertype/#Object). In PowerPoint funge da avviatore per diversi tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo che è stato popolato, ispeziona il tipo di forma reale per apprendere cosa contiene. Layout specializzati possono anche esporre [PlaceholderType.Chart](https://reference.aspose.com/slides/it/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/it/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/it/python-java/aspose.slides/placeholdertype/#Media) o [PlaceholderType.Diagram](https://reference.aspose.com/slides/it/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides non converte un segnaposto [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) vuoto in un [Chart](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/) semplicemente cambiando [Placeholder.getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/placeholder/#getType); il tipo non può essere modificato tramite l'API. Per riempire programmaticamente un'area grafico o contenuto vuota, aggiungi l'oggetto richiesto alle coordinate del segnaposto e poi rimuovi il segnaposto vuoto. L'esempio seguente lo fa per un grafico:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il grafico aggiunto è un grafico locale ordinario. Occupa l'area del segnaposto ma non eredita dal segnaposto layout. Usa gli articoli dedicati alla [gestione dei grafici](/slides/it/python-java/powerpoint-charts/) quando devi sostituire categorie, serie o dati del workbook.

## **Esempio completo: aggiornare testo o contenuto immagine**

L'esempio end‑to‑end seguente apre un modello, ricerca nella prima diapositiva un segnaposto titolo o immagine, controlla i tipi di segnaposto e di forma, aggiorna il contenuto appropriato e salva il risultato. L'esempio evita deliberatamente di presumere un indice di forma o di trattare ogni segnaposto come dello stesso tipo.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**Che cos'è un segnaposto base?**

Un segnaposto base è la forma corrispondente sul layout o sul master da cui un altro segnaposto eredita. Usa [Shape.getBasePlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getBasePlaceholder) per recuperarlo. Una forma locale ordinaria restituisce `None` perché non fa parte della gerarchia dei segnaposti.

**Posso cambiare tutti i titoli delle diapositive modificando un segnaposto layout?**

Puoi modificare la formattazione ereditata o il testo di prompt tramite un layout, ma il contenuto del titolo esistente è memorizzato sulle diapositive normali. Per sostituire il testo reale del titolo su tutta la presentazione, itera sulle diapositive e aggiorna ciascun segnaposto titolo.

**Come gestisco i segnaposti data, numero diapositiva, intestazione e piè di pagina?**

Usa i gestori di intestazione e piè di pagina nella diapositiva, nel layout, nel master, nelle note o nella raccolta di manuali appropriata. Vedi [Gestire intestazione e piè di pagina della presentazione](/slides/it/python-java/presentation-header-and-footer/) per esempi completi.