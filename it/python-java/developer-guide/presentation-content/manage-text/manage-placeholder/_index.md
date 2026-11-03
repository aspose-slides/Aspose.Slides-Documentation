---
title: Gestire i segnaposti di presentazione in Python
linktitle: Gestire i segnaposti
type: docs
weight: 10
url: /it/python-java/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- segnaposto di contenuto
- testo di prompt
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Impara a ispezionare e modificare segnaposti di testo, immagine, grafico e contenuto e a comprendere l’eredità dei segnaposti con Aspose.Slides per Python tramite Java."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un particolare tipo di contenuto in un modello di presentazione. Esempi comuni sono segnaposti per titolo, corpo, immagine, grafico e contenuti di uso generale. A differenza di una forma ordinaria, un segnaposto può ereditare posizione, dimensione, formattazione e altre impostazioni da una diapositiva layout o da una diapositiva master.

Aspose.Slides espone le informazioni sui segnaposti tramite il metodo [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder). Il metodo restituisce un oggetto [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) o `None` per una forma normale. Utilizza [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) per determinare cosa il segnaposto è destinato a contenere.

Il tipo di forma rimane importante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto vuoto per testo, immagine, grafico o contenuto è comunemente rappresentato da un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
- Un segnaposto immagine già popolato può essere rappresentato da un [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/).
- Un segnaposto grafico già popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/).
- Un segnaposto di contenuto può contenere diversi tipi di contenuto. Controlla sia [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) sia il tipo di forma a runtime invece di presumere che ogni segnaposto sia un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) descrive il ruolo di un segnaposto; non garantisce il tipo di forma a runtime. Usa sempre un controllo di tipo prima di accedere a testo, immagine, grafico, tabella o membri specifici dei media.
{{% /alert %}}

## **Comprendere l’Ereditarietà dei Segnaposti**

I segnaposti formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposti a livello master.
2. Una diapositiva layout definisce la disposizione usata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposti per quella diapositiva e può ereditare dal suo layout.

Chiama [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) per spostarti un livello più in alto nella gerarchia. Un segnaposto di diapositiva normalmente restituisce il suo segnaposto di layout; un segnaposto di layout può restituire il suo segnaposto master. Il metodo restituisce `None` quando la forma non ha un segnaposto di base.

L’esempio seguente elenca i segnaposti nella prima diapositiva e segnala i loro segnaposti di base:

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

Modificare un segnaposto su una diapositiva normale crea o cambia una sovrascrittura locale per quella diapositiva. Modificare il layout o il master correlato può influenzare tutte le diapositive che ereditano ancora quell’impostazione. Una forma ordinaria locale non ha un segnaposto di base e non inizia a ereditare solo perché occupa le stesse coordinate.

## **Rimuovere lo Stato di Segnaposto**

Durante l’adattamento di un modello, utilizza [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) per mantenere un oggetto esistente come forma ordinaria. Il suo metodo [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) restituisce `None`, ma la forma rimane nella collezione della diapositiva. Al contrario, [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) elimina la forma da quella collezione.

L’esempio seguente richiede `template.pptx` con almeno una diapositiva e un segnaposto di testo non vuoto nella prima diapositiva. Usa un segnaposto con formattazione ereditata dal suo layout o master per vedere l’effetto della rimozione di quella relazione. L’esempio verifica che la stessa forma rimanga, chiama nuovamente il metodo sulla forma ora ordinaria e salva il risultato.

{{% alert color="warning" title="Warning" %}}
Rimuovere lo stato di segnaposto non preserva automaticamente le impostazioni di aspetto ereditate. L’esempio qui sotto lascia deliberatamente tali impostazioni inalterate, quindi l’output potrebbe apparire diverso.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # Chiamare il metodo su una forma ordinaria non ha alcun effetto.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

Per un segnaposto corrispondente, tutti e tre i controlli stampano `True`. Il testo rimane, ma posizione, dimensione, rotazione, carattere, allineamento del paragrafo, margini del riquadro di testo, ancoraggio verticale, riempimento e impostazioni di linea ereditate possono cambiare quando la relazione del segnaposto viene rimossa. Per esempio, la formattazione del titolo ereditata può tornare alla formattazione di testo ordinario. Vedi [Slide Layout](/slides/it/python-java/slide-layout/) per ulteriori informazioni sui layout.

Per conservare l’aspetto desiderato, cattura posizione, dimensione e rotazione risolte prima della chiamata e copia i valori di formattazione effettiva richiesti in variabili separate. Recupera tali valori tramite [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) e [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective). Non fare affidamento solo sugli oggetti effective-format, perché i loro valori di formattazione del testo possono cambiare dopo la rimozione della relazione. Applica esplicitamente i valori catturati alla forma ordinaria successivamente, includendo famiglia, dimensione, stile, colore del carattere, impostazioni del paragrafo, impostazioni del riquadro di testo, riempimento e linea usati dal tuo modello.

La geometria della forma ereditata potrebbe dover essere assegnata esplicitamente tramite [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType). Per un segnaposto di testo rettangolare, ciò significa assegnare [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle); ripristinare solo il riempimento e la linea potrebbe non ripristinare il rettangolo visibile. I modelli con effetti aggiuntivi o formattazioni più complesse richiedono la gestione di tali impostazioni.

## **Modificare il Testo in un Segnaposto**

I segnaposti di titolo, titolo centrato, sottotitolo, corpo e testo supportano normalmente il testo. Verifica la presenza di un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) prima di utilizzare il suo metodo [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame).

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

Questo modello evita di trattare segnaposti immagine, grafico, tabella o media come un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Identifica inoltre il segnaposto per scopo invece di basarsi su un indice di forma fragile.

## **Impostare il Testo di Prompt su un Layout**

Il testo di prompt è l’istruzione di design‑time mostrata in un segnaposto vuoto, ad esempio *Fare clic per aggiungere titolo*. Imposta il testo di prompt personalizzato sul segnaposto del layout anziché tentare di raggiungerlo tramite la collezione di forme di una diapositiva normale. Accedi al layout tramite [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) e itera sulla collezione restituita da [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes).

L’esempio seguente modifica i prompt di titolo e sottotitolo sul layout usato dalla prima diapositiva:

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

Il testo di prompt non è contenuto normale della diapositiva. È destinato a segnaposti vuoti nelle applicazioni di editing come PowerPoint. Una volta che un utente o un programma fornisce contenuti reali, il prompt non viene più visualizzato. Modificare un prompt non sostituisce nemmeno il testo esistente sulle diapositive che usano quel layout.

## **Aggiornare un Segnaposto Immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), sostituisci l’immagine tramite [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) e [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage).
- Se è ancora un segnaposto vuoto, aggiungi un riquadro immagine alle coordinate del segnaposto con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) e rimuovi il segnaposto vuoto.

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

La sostituzione creata per un segnaposto vuoto è un riquadro immagine locale, non un nuovo segnaposto, perché [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) non fornisce un setter. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se mantenere la relazione del segnaposto è essenziale, prepara e popola il segnaposto in PowerPoint prima, quindi aggiorna il [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) risultante con Aspose.Slides.

Per trasparenza dell’immagine, ritaglio e altri effetti specifici dell’immagine, vedi [Manage Picture Frames](/slides/it/python-java/picture-frame/). tali operazioni appartengono al riquadro immagine o al riempimento immagine, non ai metadati del segnaposto.

## **Lavorare con Segnaposti Grafico e Contenuto**

Un segnaposto grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/). Questo esempio trova un grafico di questo tipo controllando sia il tipo di segnaposto sia il tipo di forma a runtime, ne modifica il titolo e salva il file:

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

Un segnaposto di contenuto generale di solito ha [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object). In PowerPoint funge da lanciatore per diversi tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo che è stato popolato, ispeziona il tipo di forma reale per capire cosa contiene. Layout specializzati possono anche esporre [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) o [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides non converte un segnaposto [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) vuoto in un [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) semplicemente cambiando [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType); il tipo non può essere modificato tramite l’API. Per riempire programmaticamente un’area grafico o contenuto vuota, aggiungi l’oggetto richiesto alle coordinate del segnaposto e poi rimuovi il segnaposto vuoto. L’esempio seguente fa ciò per un grafico:

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

Il grafico aggiunto è un grafico locale ordinario. Occupia l’area del segnaposto ma non eredita dal segnaposto layout. Usa gli articoli dedicati alla gestione dei [chart](/slides/it/python-java/powerpoint-charts/) quando devi sostituire categorie, serie o dati del workbook.

## **Esempio Completo: Aggiornare Testo o Immagine**

L’esempio end‑to‑end seguente apre un modello, cerca nella prima diapositiva un segnaposto titolo o immagine, controlla i tipi di segnaposto e di forma, aggiorna il contenuto appropriato e salva il risultato. L’esempio evita deliberatamente di presumere un indice di forma o di trattare tutti i segnaposti come lo stesso tipo.

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

**Che cos’è un segnaposto di base?**

Un segnaposto di base è la forma corrispondente nel layout o nel master da cui un altro segnaposto eredita. Usa [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) per recuperarlo. Una forma locale ordinaria restituisce `None` perché non fa parte della gerarchia dei segnaposti.

**Posso modificare tutti i titoli delle diapositive modificando un segnaposto layout?**

Puoi cambiare la formattazione ereditata o il testo di prompt tramite un layout, ma il contenuto reale del titolo è memorizzato sulle diapositive normali. Per sostituire il testo del titolo in tutta la presentazione, itera sulle diapositive e aggiorna ogni segnaposto titolo.

**Come gestisco i segnaposti data, numero diapositiva, intestazione e piè di pagina?**

Usa i gestori di intestazione e piè di pagina nello scope appropriato (diapositiva, layout, master, note o handout). Vedi [Manage Presentation Header and Footer](/slides/it/python-java/presentation-header-and-footer/) per esempi completi.