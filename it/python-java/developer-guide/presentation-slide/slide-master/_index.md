---
title: Gestire i master slide della presentazione in Python via Java
linktitle: Master diapositiva
type: docs
weight: 70
url: /it/python-java/slide-master/
keywords:
- master diapositiva
- master diapositiva
- master diapositiva PPT
- master slide multipli
- confronta master slide
- sfondo
- segnaposto
- clona master slide
- copia master slide
- duplica master slide
- master slide inutilizzata
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Gestisci i master slide in Aspose.Slides per Python via Java: accedi, modifica, clona, confronta e rimuovi i master slide in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce impostazioni di design condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un slide master è il modo abituale per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per Python via Java supporta lo stesso modello. Una presentazione può contenere una o più master slide, e ogni master slide può contenere diverse layout slide. Le diapositive normali di solito non fanno riferimento direttamente a una master slide. Invece, una diapositiva normale utilizza una layout slide, e quella layout slide appartiene a una master slide.

La gerarchia è:

1. **Slide master** – definisce il design e il tema condivisi.  
1. **Layout slide** – definisce una disposizione specifica di segnaposti e formattazione a livello di layout.  
1. **Normal slide** – contiene il contenuto effettivo della presentazione e utilizza una layout slide.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

In Aspose.Slides, un slide master è rappresentato dalla classe [MasterSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/). Tutte le master slide in una presentazione sono disponibili tramite la collezione [Presentation.getMasters](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getMasters), che è rappresentata da [MasterSlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Eredità" %}}

Quando la stessa proprietà è definita a più di un livello, vince il livello più specifico. Per esempio, se una master slide e una layout slide definiscono entrambe uno sfondo, le diapositive basate su quel layout usano lo sfondo del layout. Per ulteriori informazioni sulle layout slide, vedere [Apply or Change Slide Layouts](/slides/it/python-java/slide-layout/).

{{% /alert %}}

## **Accedere ai master slide**

In PowerPoint, è possibile aprire la visualizzazione Slide Master da **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

In Aspose.Slides, usare la collezione [Presentation.getMasters](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getMasters) per accedere alle master slide:

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

È anche possibile ottenere la master slide utilizzata da una diapositiva normale attraverso il suo layout:

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

## **Cosa contiene una master slide**

Una master slide è un oggetto simile a una diapositiva. Eredita da [BaseSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/), quindi espone molte delle stesse proprietà di diapositiva usate da diapositive normali e di layout. I membri specifici della master sono elencati nella pagina API [MasterSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/).

I membri della master slide più comunemente usati includono:

| Member | Scopo |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getBackground) | Imposta lo sfondo della diapositiva a livello di master. |
| [getShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getShapes) | Contiene le forme posizionate sulla master, come loghi, cornici immagine e testo condiviso. |
| [getLayoutSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#getLayoutSlides) | Contiene le layout slide che appartengono alla master. |
| [getThemeManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#getThemeManager) | Fornisce l'accesso alle API del tema della master. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per la master e le sue layout figlie. |
| [getDependingSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#getDependingSlides) | Restituisce le diapositive normali che dipendono dalla master tramite i loro layout. |

## **Aggiungere un'immagine a una master slide**

Quando si aggiunge un'immagine a una master slide, essa appare nelle diapositive che usano i layout di quella master. È utile per loghi, filigrane, bande decorative e altri elementi visuali ricorrenti.

L'esempio seguente aggiunge un logo alla prima master slide:

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

Per ulteriori informazioni sulle cornici immagine, vedere [Picture Frame](/slides/it/python-java/picture-frame/).

## **Controllare la visibilità della grafica della master**

Usare [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#setShowMasterShapes) per nascondere la grafica ereditata dalla master, come loghi o forme decorative, senza eliminarla dalla master. Passare `False` a [Slide.setShowMasterShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#setShowMasterShapes) sulla diapositiva che deve omettere quelle grafiche e mantenerlo `True` sulle diapositive che devono visualizzarle.

L'esempio autonomo seguente crea una banda decorativa blu su una master e due diapositive che usano lo stesso layout vuoto. La banda è visibile sulla prima diapositiva e nascosta sulla seconda. Non è necessaria alcuna presentazione o immagine di input.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L'esempio utilizza il layout **Blank** fornito con una nuova presentazione e rimuove i segnaposti propri della diapositiva iniziale.

### **Scegliere l'ambito dell'impostazione**

Una diapositiva normale utilizza la sua master tramite [Slide.getLayoutSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getLayoutSlide) e [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#getMasterSlide). Impostare la proprietà su una singola diapositiva influisce solo su quella diapositiva. Passare `False` a [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#setShowMasterShapes) nasconde la grafica della master per le diapositive che usano quel layout condiviso, anche se la loro impostazione personale è `True`. Per nascondere le grafiche su una sola diapositiva, modificare la proprietà della diapositiva e lasciare invariato il layout condiviso.

L'impostazione non è supportata come controllo di visibilità sulla master slide stessa. Su una master, [getShowMasterShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#getShowMasterShapes) restituisce sempre `False`, e passare `True` a [setShowMasterShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#setShowMasterShapes) genera un'eccezione. Applicarla a una diapositiva normale o a un layout.

### **Distinguere grafica dallo sfondo**

| Operazione | Effetto |
| --- | --- |
| Nascondere la grafica della master | Controlla la visibilità delle forme ereditate dalla master senza eliminarle o modificare le forme proprie della diapositiva. |
| Modificare il riempimento dello sfondo della diapositiva | Cambia il colore, il gradiente o l'immagine di sfondo. La grafica della master è costituita da forme separate e può rimanere visibile sopra quello sfondo. Vedere [Presentation Background](/slides/it/python-java/presentation-background/). |
| Eliminare una forma dalla master | Rimuove la forma sorgente condivisa, quindi non è più disponibile per alcuna diapositiva che usa quella master. |

## **Lavorare con i segnaposti**

I segnaposti sono normalmente definiti sulle layout slide. La master slide fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ciascun layout decide quali segnaposti sono disponibili e dove sono posizionati.

In PowerPoint, i comandi dei segnaposti sono disponibili nella visualizzazione Slide Master.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavorare sulla layout slide che appartiene alla master:

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

È anche possibile formattare le forme segnaposto già esistenti su una master slide. L'esempio seguente trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

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

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Per ulteriori opzioni di formattazione di segnaposti e testo, vedere [Set Prompt Text in Placeholder](/slides/it/python-java/manage-placeholder/) e [Text Formatting](/slides/it/python-java/text-formatting/).

## **Modificare lo sfondo di una master slide**

Uno sfondo master è ereditato da layout e diapositive che non lo sovrascrivono. L'esempio seguente imposta un colore di sfondo solido per la prima master slide:

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

Per argomenti correlati, vedere [Presentation Background](/slides/it/python-java/presentation-background/) e [Presentation Theme](/slides/it/python-java/presentation-theme/).

## **Clonare una master slide in un'altra presentazione**

Usare [MasterSlideCollection.addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/#addClone) per copiare una master slide in un'altra presentazione. La master copiata può quindi essere usata da layout e diapositive nella presentazione di destinazione.

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

Se è necessario clonare le diapositive normali insieme alla loro master, vedere [Clone Slides](/slides/it/python-java/clone-slides/).

## **Aggiungere più master slide**

Una presentazione può contenere più master slide. È utile quando diverse sezioni richiedono marchi diversi, strutture di pagina o impostazioni di tema differenti.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

L'esempio seguente clona la master predefinita, assegna al clone uno sfondo diverso, crea una layout sotto quella master clonata e aggiunge una nuova diapositiva basata su quel layout:

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

## **Confrontare master slide**

Le master slide possono essere confrontate con il metodo [equals](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#equals) ereditato da [BaseSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/). Il confronto verifica struttura e contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori unici, come ID delle diapositive, né valori dinamici dei segnaposti, come la data corrente.

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

Per ulteriori informazioni, vedere [Compare Presentation Slides](/slides/it/python-java/compare-slides/).

## **Impostare la visualizzazione Slide Master come visualizzazione predefinita**

Usare il metodo [setLastView](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#setLastView) su [ViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/) per controllare la visualizzazione che PowerPoint apre per prima. L'esempio seguente apre la presentazione in visualizzazione Slide Master:

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

Per altre impostazioni di visualizzazione, vedere [Save Presentation](/slides/it/python-java/save-presentation/).

## **Rimuovere master slide inutilizzate**

Le presentazioni a volte contengono master slide che non sono più utilizzate da alcuna diapositiva normale. Rimuovere le master inutilizzate può ridurre la dimensione del file e semplificare la manutenzione dei template.

Usare [removeUnused](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/#removeUnused) per rimuovere le master inutilizzate dalla collezione [Presentation.getMasters](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getMasters):

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

È anche possibile usare il metodo a bassa codifica [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

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

Sì. Una presentazione può contenere più slide master. Utilizzare più master quando diverse sezioni necessitano di sistemi visivi o branding differenti.

**Devo aggiungere segnaposti a una master slide o a una layout slide?**

Nella maggior parte dei casi, aggiungere i segnaposti alle layout slide. Mettere gli elementi visivi condivisi e la formattazione comune sulla master slide, poi inserire i segnaposti di contenuto sulle layout che le diapositive normali utilizzeranno.

**Posso eliminare una master slide che è ancora utilizzata?**

No. Una master slide che ha diapositive dipendenti non può essere rimossa in modo sicuro direttamente. Spostare prima quelle diapositive su layout sotto un'altra master, oppure utilizzare un metodo di pulizia per master non usate che rimuove solo le master non presenti in alcuna diapositiva.