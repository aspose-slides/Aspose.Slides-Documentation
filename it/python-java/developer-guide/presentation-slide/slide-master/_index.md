---
title: Gestisci i master slide della presentazione in Python tramite Java
linktitle: Master diapositiva
type: docs
weight: 70
url: /it/python-java/slide-master/
keywords:
- master diapositiva
- master diapositiva
- master diapositiva PPT
- master diapositiva multipli
- confronta master diapositiva
- sfondo
- segnaposto
- clona master diapositiva
- copia master diapositiva
- duplica master diapositiva
- master diapositiva inutilizzata
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Gestisci i master slide in Aspose.Slides per Python tramite Java: accedi, modifica, clona, confronta e rimuovi i master slide in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce impostazioni di progettazione condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un slide master è il modo consueto per mantenere una presentazione coerente senza ripetere la stessa formattazione in ogni diapositiva.

Aspose.Slides for Python via Java supporta lo stesso modello. Una presentazione può contenere una o più master slide e ogni master slide può contenere diverse layout slide. Le diapositive normali di solito non fanno riferimento direttamente a una master slide. Invece, una diapositiva normale utilizza una layout slide, che appartiene a una master slide.

La gerarchia è:

1. **Slide master** - definisce il design e il tema condivisi.  
1. **Layout slide** - definisce una disposizione specifica di segnaposti e formattazione a livello di layout.  
1. **Normal slide** - contiene il contenuto effettivo della presentazione e utilizza una layout slide.

![La gerarchia delle master slide, layout slide e slide normali](slide-master_2.jpg)

In Aspose.Slides, un slide master è rappresentato dalla classe [MasterSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/) . Tutte le master slide in una presentazione sono disponibili tramite la collezione [Presentation.getMasters](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getMasters) , che è rappresentata da [MasterSlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
Quando la stessa proprietà è definita a più di un livello, prevale il livello più specifico. Per esempio, se una master slide e una layout slide definiscono entrambe uno sfondo, le diapositive basate su quel layout usano lo sfondo del layout. Per ulteriori informazioni sulle layout slide, vedere [Apply or Change Slide Layouts](/slides/it/python-java/slide-layout/) .
{{% /alert %}}

## **Accedere alle Slide Master**

In PowerPoint, puoi aprire la visualizzazione Slide Master da **View** > **Slide Master**.

![Il comando Slide Master nella scheda Visualizza di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, usa la collezione [Presentation.getMasters](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getMasters) per accedere alle master slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Puoi anche ottenere la master slide utilizzata da una diapositiva normale tramite il suo layout:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Cosa Contiene una Slide Master**

Una master slide è un oggetto simile a una diapositiva. Ereda da [BaseSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/) , quindi espone molte delle stesse proprietà delle diapositive usate da diapositive normali e di layout. I membri specifici della master sono elencati nella pagina API [MasterSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/) .

I membri della master slide più comunemente usati includono:

| Membro | Scopo |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getBackground) | Imposta lo sfondo della diapositiva a livello master. |
| [getShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getShapes) | Memorizza le forme inserite nella master, come loghi, cornici di immagine e testo condiviso. |
| [getLayoutSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#getLayoutSlides) | Memorizza le layout slide che appartengono alla master. |
| [getThemeManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#getThemeManager) | Fornisce l'accesso alle API del tema della master. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per la master e i suoi layout figli. |
| [getDependingSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#getDependingSlides) | Restituisce le diapositive normali che dipendono dalla master attraverso i loro layout. |

## **Aggiungere un'Immagine a una Slide Master**

Quando aggiungi un'immagine a una master slide, essa appare nelle diapositive che utilizzano layout da quella master. È utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

Il seguente esempio aggiunge un logo alla prima master slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per ulteriori informazioni sulle cornici immagine, vedere [Cornice Immagine](/slides/it/python-java/picture-frame/) .

## **Lavorare con i Segnaposti**

I segnaposti sono normalmente definiti sulle layout slide. La master slide fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ogni layout decide quali segnaposti sono disponibili e dove sono posizionati.

In PowerPoint, i comandi dei segnaposti sono disponibili nella visualizzazione Slide Master.

![Il comando Inserisci Segnaposto nella visualizzazione Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavora con la layout slide che appartiene alla master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Puoi anche formattare le forme dei segnaposti già esistenti su una master slide. Il seguente esempio trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Segnaposto titolo formattato ereditato dalle diapositive normali](slide-master_8.png)

Per ulteriori opzioni di formattazione di segnaposti e testo, vedere [Impostare Testo Prompt nel Segnaposto](/slides/it/python-java/manage-placeholder/) e [Formattazione del Testo](/slides/it/python-java/text-formatting/) .

## **Modificare lo Sfondo di una Slide Master**

Uno sfondo master è ereditato da layout e diapositive che non lo sovrascrivono. Il seguente esempio imposta un colore di sfondo solido per la prima master slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per argomenti correlati, vedere [Sfondo Presentazione](/slides/it/python-java/presentation-background/) e [Tema Presentazione](/slides/it/python-java/presentation-theme/) .

## **Clonare una Slide Master in un'Altra Presentazione**

Usa [MasterSlideCollection.addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/#addClone) per copiare una master slide in un'altra presentazione. La master copiata può poi essere usata da layout e diapositive nella presentazione di destinazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Se devi clonare diapositive normali insieme alla loro master, vedere [Clone Slides](/slides/it/python-java/clone-slides/) .

## **Aggiungere più Slide Master**

Una presentazione può contenere più master slide. È utile quando sezioni diverse richiedono branding, struttura della pagina o impostazioni del tema differenti.

![Comandi PowerPoint per inserire e gestire le master slide](slide-master_9.jpg)

Il seguente esempio clona la master predefinita, assegna al clone uno sfondo diverso, crea una layout sotto quella master clonata e aggiunge una nuova diapositiva basata su quel layout:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Confrontare le Slide Master**

Le master slide possono essere confrontate con il metodo [equals](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#equals) ereditato da [BaseSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/) . Il confronto verifica struttura e contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori unici, come gli ID delle diapositive, né valori dinamici dei segnaposti, come la data corrente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Per ulteriori informazioni, vedere [Confrontare Diapositive della Presentazione](/slides/it/python-java/compare-slides/) .

## **Impostare la Vista Slide Master come Vista Predefinita**

Usa il metodo [setLastView](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#setLastView) su [ViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/) per controllare la vista che PowerPoint apre per prima. Il seguente esempio apre la presentazione in modalità Slide Master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per ulteriori impostazioni della vista, vedere [Salvare Presentazione](/slides/it/python-java/save-presentation/) .

## **Rimuovere le Master Slide Inutilizzate**

Le presentazioni a volte contengono master slide che non sono più utilizzate da alcuna diapositiva normale. Rimuovere le master inutilizzate può ridurre la dimensione del file e semplificare la manutenzione del modello.

Usa [removeUnused](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/#removeUnused) per rimuovere le master inutilizzate dalla collezione [Presentation.getMasters](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getMasters) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Puoi anche usare il metodo low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/#removeUnusedMasterSlides) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Qual è la differenza tra una slide master e una layout slide?**

Una slide master definisce impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una layout slide appartiene a una master slide e definisce una disposizione specifica di segnaposti. Una diapositiva normale utilizza una layout slide, quindi eredita sia dal layout sia dalla master.

**Una presentazione può contenere più slide master?**

Sì. Una presentazione può contenere più slide master. Usa più master quando sezioni diverse necessitano di sistemi visivi o branding differenti.

**Devo aggiungere segnaposti a una master slide o a una layout slide?**

Nella maggior parte dei casi, aggiungi i segnaposti alle layout slide. Metti gli elementi visivi condivisi e la formattazione condivisa sulla master slide, poi inserisci i segnaposti di contenuto sulle layout che le diapositive normali utilizzeranno.

**Posso eliminare una master slide che è ancora in uso?**

No. Una master slide che ha diapositive dipendenti non può essere rimossa in modo sicuro direttamente. Prima sposta quelle diapositive a layout sotto un’altra master, oppure usa un metodo di pulizia delle master non usate che rimuove solo le master che non sono in uso.