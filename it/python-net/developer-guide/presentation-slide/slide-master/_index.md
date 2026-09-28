---
title: Gestisci i master slide della presentazione in Python
linktitle: Master diapositiva
type: docs
weight: 80
url: /it/python-net/slide-master/
keywords:
- master slide
- master diapositiva
- master slide PPT
- slide master multipli
- confronta master slide
- sfondo
- segnaposto
- clona master slide
- copia master slide
- duplica master slide
- master slide non utilizzato
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci i master slide in Aspose.Slides per Python via .NET: accedi, modifica, clona, confronta e rimuovi i master slide in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce impostazioni di design condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un slide master è il modo consueto per mantenere una presentazione coerente senza dover ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per Python via .NET supporta lo stesso modello. Una presentazione può contenere una o più slide master e ogni slide master può contenere diverse layout slide. Le diapositive normali di solito non fanno riferimento direttamente a una slide master. Invece, una diapositiva normale utilizza una layout slide, e quella layout slide appartiene a una slide master.

La gerarchia è:

1. **Slide master** – definisce il design e il tema condivisi.  
1. **Layout slide** – definisce una disposizione specifica di segnaposto e formattazione a livello di layout.  
1. **Normal slide** – contiene il contenuto reale della presentazione e utilizza una layout slide.

![La gerarchia di slide master, layout slide e diapositive normali](slide-master_2.jpg)

In Aspose.Slides, una slide master è rappresentata dalla classe [MasterSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslide/). Tutte le slide master in una presentazione sono disponibili tramite la collezione `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}

Quando la stessa proprietà è definita a più di un livello, prevale il livello più specifico. Per esempio, se una slide master e una layout slide definiscono entrambe uno sfondo, le diapositive basate su quel layout usano lo sfondo del layout. Per ulteriori informazioni sulle layout slide, vedere [Apply or Change Slide Layouts](/slides/it/python-net/slide-layout/).

{{% /alert %}}

## **Accedere ai Slide Master**

In PowerPoint, è possibile aprire la vista Slide Master da **View** > **Slide Master**.

![Il comando Slide Master nella scheda Visualizza di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, usare la collezione `masters` per accedere alle slide master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

È inoltre possibile ottenere la slide master utilizzata da una diapositiva normale tramite il suo layout:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Cosa contiene un Slide Master**

Una slide master è un oggetto simile a una diapositiva. Eredità il comportamento comune delle diapositive dalla classe [BaseSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/), quindi espone molte delle stesse proprietà usate da diapositive normali e layout. I membri specifici del master sono elencati nella pagina API [MasterSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslide/).

I membri più utilizzati della slide master includono:

| Membro | Scopo |
| --- | --- |
| `background` | Imposta lo sfondo a livello di master. |
| `shapes` | Contiene le forme posizionate sul master, come loghi, cornici immagine e testo condiviso. |
| `layout_slides` | Contiene le layout slide appartenenti al master. |
| `theme_manager` | Fornisce l'accesso alle API del tema del master. |
| `header_footer_manager` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figlio. |
| `get_depending_slides` | Restituisce le diapositive normali che dipendono dal master tramite i loro layout. |

## **Aggiungere un'Immagine a un Slide Master**

Quando si aggiunge un'immagine a una slide master, essa appare sulle diapositive che usano layout di quel master. È utile per loghi, filigrane, bande decorative e altri elementi visivi ricorrenti.

L'esempio seguente aggiunge un logo alla prima slide master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Per ulteriori informazioni sulle cornici immagine, vedere [Picture Frame](/slides/it/python-net/picture-frame/).

## **Controllare la Visibilità della Grafica del Master**

Usare [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/show_master_shapes/) per nascondere la grafica ereditata dal master, come loghi o forme decorative, senza cancellarle dal master. Impostare [Slide.show_master_shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/show_master_shapes/) a `False` sulla diapositiva che deve omettere quelle grafiche e lasciarlo `True` su quelle che devono visualizzarle.

L'esempio autonomo seguente crea una banda decorativa blu su un master e due diapositive che usano lo stesso layout vuoto. La banda è visibile sulla prima diapositiva e nascosta sulla seconda. Non è necessaria alcuna presentazione o immagine di input.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

L'esempio utilizza il layout **Blank** fornito con una nuova presentazione e rimuove i segnaposto originali della diapositiva iniziale.

### **Scegliere l'Ambito dell'Impostazione**

Una diapositiva normale utilizza il suo master tramite [Slide.layout_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/layout_slide/) e [LayoutSlide.master_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslide/master_slide/). Impostare la proprietà su una singola diapositiva influisce solo su quella diapositiva. Impostare [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslide/show_master_shapes/) a `False` nasconde la grafica del master per tutte le diapositive che usano quel layout condiviso, anche se la loro impostazione personale è `True`. Per nascondere la grafica su una sola diapositiva, modificare la proprietà della diapositiva e mantenere invariato il layout condiviso.

L'impostazione non è supportata come controllo di visibilità sulla slide master stessa. Su un master restituisce sempre `False`, e assegnare `True` genera un'eccezione. Applicarla a una diapositiva normale o a un layout invece.

### **Distinguere la Grafica dallo Sfondo**

| Operazione | Effetto |
| --- | --- |
| Nascondere la grafica del master | Controlla la visibilità delle forme ereditate dal master senza cancellarle o modificare le forme proprie della diapositiva. |
| Modificare il riempimento di sfondo della diapositiva | Cambia il colore, il gradiente o l'immagine di sfondo. La grafica del master è costituita da forme separate e può rimanere visibile sopra quello sfondo. Vedere [Presentation Background](/slides/it/python-net/presentation-background/). |
| Eliminare una forma dal master | Rimuove la forma sorgente condivisa, quindi non è più disponibile per alcuna diapositiva che utilizza quel master. |

## **Lavorare con i Segnaposto**

I segnaposto sono normalmente definiti sui layout slide. Il master slide fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ogni layout decide quali segnaposto sono disponibili e dove posizionarli.

In PowerPoint, i comandi dei segnaposto sono disponibili nella vista Slide Master.

![Il comando Inserisci segnaposto nella vista Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposto con Aspose.Slides, lavorare sul layout slide che appartiene al master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

È anche possibile formattare le forme segnaposto già presenti su una slide master. L'esempio seguente individua il segnaposto del titolo e applica un riempimento a gradiente lineare:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Segnaposto titolo formattato ereditato dalle diapositive normali](slide-master_8.png)

Per ulteriori opzioni di formattazione dei segnaposto e del testo, vedere [Set Prompt Text in Placeholder](/slides/it/python-net/manage-placeholder/) e [Text Formatting](/slides/it/python-net/text-formatting/).

## **Modificare lo Sfondo di un Slide Master**

Uno sfondo master è ereditato da layout e diapositive che non lo sovrascrivono. L'esempio seguente imposta un colore di sfondo solido per la prima slide master:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

Per argomenti correlati, vedere [Presentation Background](/slides/it/python-net/presentation-background/) e [Presentation Theme](/slides/it/python-net/presentation-theme/).

## **Clonare un Slide Master in un'Altra Presentazione**

Usare il metodo `add_clone` sulla classe [MasterSlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslidecollection/) per copiare una slide master in un'altra presentazione. Il master copiato può quindi essere usato da layout e diapositive nella presentazione di destinazione.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Se è necessario clonare anche le diapositive normali insieme al loro master, vedere [Clone Slides](/slides/it/python-net/clone-slides/).

## **Aggiungere più Slide Master**

Una presentazione può contenere più slide master. È utile quando sezioni diverse richiedono branding, struttura di pagina o impostazioni del tema differenti.

![Comandi PowerPoint per inserire e gestire slide master](slide-master_9.jpg)

L'esempio seguente clona il master predefinito, assegna al clone uno sfondo diverso, ottiene un layout vuoto sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Confrontare i Slide Master**

I slide master possono essere confrontati con il metodo `equals` ereditato dalla classe [BaseSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/). Il confronto verifica struttura e contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori unici, come gli ID delle diapositive, o valori dinamici dei segnaposto, come la data corrente.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Per ulteriori informazioni, vedere [Compare Presentation Slides](/slides/it/python-net/compare-slides/).

## **Impostare la Vista Slide Master come Vista Predefinita**

Usare la proprietà `last_view` sull'oggetto [ViewProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/) della presentazione per controllare la vista che PowerPoint apre per prima. L'esempio seguente apre la presentazione in vista Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Per ulteriori impostazioni della vista, vedere [Save Presentation](/slides/it/python-net/save-presentation/).

## **Rimuovere Slide Master Inutilizzate**

A volte le presentazioni contengono slide master che non sono più usate da alcuna diapositiva normale. Rimuovere i master inutilizzati può ridurre le dimensioni del file e semplificare la manutenzione dei template.

Usare `remove_unused` per rimuovere i master inutilizzati dalla collezione `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

È anche possibile usare il metodo low‑code `remove_unused_master_slides` della classe [Compress](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Qual è la differenza tra uno slide master e una layout slide?**

Uno slide master definisce impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una layout slide appartiene a uno slide master e definisce una disposizione specifica di segnaposto. Una diapositiva normale usa una layout slide, quindi eredita sia dal layout sia dal master.

**Una presentazione può contenere più slide master?**

Sì. Una presentazione può contenere più slide master. Utilizzare più master quando sezioni diverse richiedono sistemi visivi o branding differenti.

**Devo aggiungere i segnaposto a uno slide master o a una layout slide?**

Nella maggior parte dei casi, aggiungere i segnaposto alle layout slide. Inserire gli elementi visivi condivisi e la formattazione comune sullo slide master, poi posizionare i segnaposto di contenuto sui layout che le diapositive normali utilizzeranno.

**Posso eliminare uno slide master che è ancora in uso?**

No. Uno slide master con diapositive dipendenti non può essere rimosso in modo sicuro. Prima spostare quelle diapositive su layout di un altro master, oppure usare un metodo di pulizia dei master non utilizzati che rimuove solo i master non in uso.