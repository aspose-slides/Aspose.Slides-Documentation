---
title: Gestire i master slide della presentazione in Python
linktitle: Master diapositiva
type: docs
weight: 80
url: /it/python-net/slide-master/
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
- Aspose.Slides
description: "Gestisci i master slide in Aspose.Slides per Python via .NET: accedi, modifica, clona, confronta e rimuovi i master slide in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce impostazioni di design condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un slide master è il modo consueto per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides for Python via .NET supporta lo stesso modello. Una presentazione può contenere una o più master slide, e ogni master slide può contenere diverse layout slide. Le diapositive normali di solito non fanno riferimento direttamente a una master slide. Invece, una diapositiva normale utilizza una layout slide, e quella layout slide appartiene a una master slide.

La gerarchia è:

1. **Slide master** – definisce il design e il tema condivisi.  
1. **Layout slide** – definisce una disposizione specifica di segnaposti e formattazione a livello di layout.  
1. **Diapositiva normale** – contiene il contenuto effettivo della presentazione e utilizza una layout slide.

![La gerarchia delle master slide, layout slide e slide normali](slide-master_2.jpg)

In Aspose.Slides, un slide master è rappresentato dalla classe [MasterSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslide/). Tutti i master slide in una presentazione sono disponibili tramite la collezione `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}

Quando la stessa proprietà è definita a più di un livello, prevale il livello più specifico. Per esempio, se un master slide e una layout slide definiscono entrambe uno sfondo, le diapositive basate su quel layout utilizzano lo sfondo del layout. Per ulteriori informazioni sulle layout slide, vedere [Apply or Change Slide Layouts](/python-net/slide-layout/).

{{% /alert %}}

## **Accedere ai Slide Master**

In PowerPoint, è possibile aprire la vista Slide Master dal menu **Vista** > **Slide Master**.

![Il comando Slide Master nella scheda Visualizza di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, usare la collezione `masters` per accedere ai master slide:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

È anche possibile ottenere il master slide usato da una diapositiva normale tramite il suo layout:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Cosa Contiene un Slide Master**

Un master slide è un oggetto simile a una diapositiva. Eredita il comportamento comune delle diapositive dalla classe [BaseSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/), quindi espone molte delle stesse proprietà della diapositiva utilizzate da diapositive normali e layout. I membri specifici del master sono elencati nella pagina API [MasterSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslide/).

I membri del master slide più usati includono:

| Membro | Scopo |
| --- | --- |
| `background` | Imposta lo sfondo a livello di master slide. |
| `shapes` | Memorizza le forme posizionate sul master, come loghi, cornici di immagini e testo condiviso. |
| `layout_slides` | Memorizza le layout slide che appartengono al master. |
| `theme_manager` | Fornisce accesso alle API del tema del master. |
| `header_footer_manager` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `get_depending_slides` | Restituisce le diapositive normali che dipendono dal master tramite i loro layout. |

## **Aggiungere un'Immagine a un Slide Master**

Quando si aggiunge un'immagine a un master slide, essa appare sulle diapositive che utilizzano layout da quel master. Questo è utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

L'esempio seguente aggiunge un logo al primo master slide:

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

Per ulteriori informazioni sui cornici immagine, vedere [Picture Frame](/python-net/picture-frame/).

## **Lavorare con i Segnaposti**

I segnaposti sono normalmente definiti sulle layout slide. Il master slide fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ogni layout decide quali segnaposti sono disponibili e dove sono posizionati.

In PowerPoint, i comandi dei segnaposti sono disponibili nella vista Slide Master.

![Il comando Inserisci Segnaposto nella vista Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavorare sulla layout slide che appartiene al master:

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

È anche possibile formattare forme segnaposto già presenti su un master slide. L'esempio seguente trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Segnaposto titolo formattato ereditato dalle diapositive normali](slide-master_8.png)

Per ulteriori opzioni di formattazione di segnaposti e testo, vedere [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) e [Text Formatting](/python-net/text-formatting/).

## **Modificare lo Sfondo di un Slide Master**

Uno sfondo master è ereditato da layout e diapositive che non lo sovrascrivono. L'esempio seguente imposta un colore di sfondo solido per il primo master slide:

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

Per argomenti correlati, vedere [Presentation Background](/python-net/presentation-background/) e [Presentation Theme](/python-net/presentation-theme/).

## **Clonare un Slide Master in un'Altra Presentazione**

Usare il metodo `add_clone` sulla classe [MasterSlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslidecollection/) per copiare un master slide in un'altra presentazione. Il master copiato può quindi essere usato da layout e diapositive nella presentazione di destinazione.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Se è necessario clonare le diapositive normali insieme al loro master, vedere [Clone Slides](/python-net/clone-slides/).

## **Aggiungere più Slide Master**

Una presentazione può contenere più master slide. Questo è utile quando diverse sezioni richiedono branding, struttura della pagina o impostazioni del tema differenti.

![Comandi PowerPoint per inserire e gestire i master slide](slide-master_9.jpg)

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

I master slide possono essere confrontati con il metodo `equals` ereditato dalla classe [BaseSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/). Il confronto verifica la struttura e il contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori univoci, come gli ID delle diapositive, o valori dinamici dei segnaposti, come la data corrente.

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

Per ulteriori informazioni, vedere [Compare Presentation Slides](/python-net/compare-slides/).

## **Impostare la Vista Slide Master come Vista Predefinita**

Usare la proprietà `last_view` sul [ViewProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/) della presentazione per controllare la vista che PowerPoint apre per prima. L'esempio seguente apre la presentazione in vista Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Per altre impostazioni della vista, vedere [Save Presentation](/python-net/save-presentation/).

## **Rimuovere i Master Slide Inutilizzati**

Le presentazioni a volte contengono master slide che non sono più usati da nessuna diapositiva normale. Rimuovere i master inutilizzati può ridurre la dimensione del file e semplificare la manutenzione del modello.

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

**Qual è la differenza tra un slide master e una layout slide?**

Un slide master definisce impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una layout slide appartiene a un slide master e definisce una disposizione specifica di segnaposti. Una diapositiva normale utilizza una layout slide, quindi eredita sia dal layout sia dal master.

**Una presentazione può contenere più slide master?**

Sì. Una presentazione può contenere più slide master. Utilizzare più master quando diverse sezioni necessitano di sistemi visivi o branding differenti.

**Devo aggiungere segnaposti a un master slide o a una layout slide?**

Nella maggior parte dei casi, aggiungere i segnaposti alle layout slide. Mettere gli elementi visivi condivisi e la formattazione comune sul master slide, quindi inserire i segnaposti di contenuto sulle layout che saranno usate dalle diapositive normali.

**Posso eliminare un master slide che è ancora in uso?**

No. Un master slide che ha diapositive dipendenti non può essere rimosso in modo sicuro. Spostare prima quelle diapositive su layout di un altro master, oppure usare un metodo di pulizia dei master non utilizzati che rimuove solo i master non in uso.