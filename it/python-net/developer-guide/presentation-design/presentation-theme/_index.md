---
title: Gestire i temi delle presentazioni PowerPoint in Python
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/python-net/presentation-theme/
keywords:
- Tema PowerPoint
- Tema della presentazione
- Tema della diapositiva
- Impostare il tema
- Modificare il tema
- Gestire il tema
- Tema esterno
- THMX
- Colore del tema
- Palette aggiuntiva
- Carattere del tema
- Stile del tema
- Effetto del tema
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci i temi principali delle presentazioni in Aspose.Slides per Python tramite .NET per creare, personalizzare e convertire file PowerPoint con un'identità visiva coerente."
---
## **Introduzione**

Un tema della presentazione definisce un insieme coordinato di colori, caratteri, stili di sfondo, riempimenti, linee ed effetti. Gli oggetti sensibili al tema fanno riferimento a queste definizioni condivise invece di memorizzare ogni proprietà visiva come valore fisso, così un cambiamento del tema può aggiornare molti oggetti contemporaneamente.

In Aspose.Slides, il tema a livello di presentazione è disponibile tramite la proprietà [Presentation.master_theme](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/master_theme/). Una presentazione può contenere anche sovrascritture del tema a livelli inferiori. Un master può sovrascrivere il tema della presentazione tramite [MasterThemeManager.override_theme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/masterthememanager/override_theme/), un layout può sovrascrivere il tema ereditato tramite [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), e una singola diapositiva può fare lo stesso. In pratica, il tema effettivo per una diapositiva viene risolto attraverso questa catena di ereditarietà: tema della presentazione, sovrascrittura del master, sovrascrittura del layout e sovrascrittura della diapositiva.

![Componenti del tema: colori, caratteri, stili di sfondo ed effetti](theme-constituents.png)

Le sezioni seguenti mostrano i flussi di lavoro più comuni sul tema: ispezionare un tema, modificare colori e caratteri, copiare o applicare un tema, aggiornare stili di sfondo ed effetti, e leggere i valori effettivi dopo che ereditarietà e sovrascritture sono state risolte.

## **Ispezionare un tema**

L'oggetto [MasterTheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/mastertheme/) espone le proprietà [color_scheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/mastertheme/font_scheme/) e [format_scheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/mastertheme/format_scheme/). Ispezionare queste collezioni prima di modificarle è particolarmente utile quando una presentazione proviene da una fonte esterna, poiché il numero e il contenuto delle voci di stile possono variare.

L'esempio seguente legge le proprietà principali del tema e riporta quante voci di sfondo, riempimento, linea ed effetto sono memorizzate nel tema:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Se un file utilizza più master, non dare per scontato che ogni diapositiva abbia lo stesso tema effettivo. Ispeziona il master associato alla diapositiva e usa il flusso di lavoro sul tema effettivo mostrato più avanti in questo articolo quando potrebbero esserci sovrascritture a livello di layout o diapositiva.

## **Modificare i colori del tema**

I riempimenti, le linee e il testo sensibili al tema possono riferirsi a un colore logico dell'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/python-net/aspose.slides/schemecolor/). Quando cambi la voce corrispondente nel [ColorScheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/colorscheme/) del tema, tutti gli oggetti che ancora fanno riferimento a quel colore del tema vengono risolti sul nuovo valore. Gli oggetti che usano un colore RGB diretto non vengono modificati da un aggiornamento del colore del tema.

L'esempio end‑to‑end seguente crea una forma che utilizza `ACCENT4`, cambia il colore `accent4` del tema in rosso, salva la presentazione, la riapre e stampa il colore di riempimento effettivo:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Poiché il rettangolo rimane collegato a `ACCENT4`, il suo colore visibile diventa rosso dopo il cambio del tema. Se sostituisci il colore dello schema con un colore diretto sulla forma, le modifiche successive a `accent4` non influenzeranno più quel riempimento.

### **Usare i colori dalla tavolozza aggiuntiva**

PowerPoint genera varianti più chiare e più scure da un colore del tema applicando trasformazioni di colore. Aspose.Slides espone queste trasformazioni tramite l'enumerazione [ColorTransformOperation](https://reference.aspose.com/slides/it/python-net/aspose.slides/colortransformoperation/).

![Colori principali del tema e colori più chiari e più scuri generati dalla tavolozza aggiuntiva](additional-palette-colors.png)

**1** - Colori principali del tema.  
**2** - Varianti più chiare e più scure prodotte dai colori principali del tema.

L'esempio seguente crea sei rettangoli basati su `ACCENT4`, applica trasformazioni di luminanza a cinque di essi e salva il risultato:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Queste varianti rimangono basate sul colore del tema. Se `accent4` cambia in seguito, i colori trasformati vengono ricalcolati dal nuovo valore `accent4`.

### **Mappare i valori di `SchemeColor` negli slot di `ColorScheme`**

L'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/python-net/aspose.slides/schemecolor/) usa `TEXT1`, `BACKGROUND1`, `TEXT2` e `BACKGROUND2`, mentre [ColorScheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/colorscheme/) espone gli stessi slot del tema come `dark1`, `light1`, `dark2` e `light2`. La mappatura è fissa:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Questi sono nomi alternativi per gli stessi slot del tema; non sono valori convertiti dinamicamente da una forma all'altra.

## **Modificare i caratteri del tema**

Uno schema di caratteri del tema contiene un set di caratteri principale per le intestazioni e un set secondario per il corpo del testo. Le proprietà [FontScheme.major](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/fontscheme/major/) e [FontScheme.minor](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/fontscheme/minor/) espongono tali set.

Gli identificatori di caratteri del tema compatibili con PowerPoint possono essere usati nella formattazione del testo:

* `+mn-lt` - Font corpo Latin (Minor Latin Font)
* `+mj-lt` - Font intestazione Latin (Major Latin Font)
* `+mn-ea` - Font corpo East Asian (Minor East Asian Font)
* `+mj-ea` - Font intestazione East Asian (Major East Asian Font)

L'esempio seguente crea un'intestazione che usa il carattere Latin principale del tema e una riga di corpo che usa il carattere Latin secondario del tema. Poi modifica i caratteri del tema e salva il risultato:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

L'intestazione segue il carattere principale e il testo del corpo segue il carattere secondario. Il testo che ha un nome di carattere esplicito invece di un identificatore del tema non cambierà automaticamente quando lo schema di caratteri del tema cambia.

Le collezioni di caratteri principali e secondari possono contenere anche mappature di caratteri per sistemi di scrittura individuali, come cirillico, arabo, giapponese, georgiano e thaana. Per ispezionare, aggiungere, sostituire o rimuovere queste mappature, vedere [Script-Specific Theme Fonts](/slides/it/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Suggerimento" %}}
Per ulteriori informazioni sui caratteri della presentazione, vedere [PowerPoint Fonts](/slides/it/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Copiare o applicare un tema**

I flussi di lavoro seguenti risolvono diversi problemi legati al tema.

### **Applicare un tema esterno alle diapositive dipendenti da un master**

Usa [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) quando hai un file tema PowerPoint (`.thmx`) e desideri ridisegnare ogni diapositiva che dipende da un master particolare. Seleziona il master dalla collezione [Presentation.masters](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/masters/), che implementa [MasterSlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslidecollection/), e passa il percorso del file tema al metodo.

Il metodo esegue le seguenti operazioni:

1. Crea un nuovo master slide basato sul master selezionato.  
2. Applica il tema esterno al nuovo master.  
3. Assegna il nuovo master a tutte le diapositive che precedentemente dipendevano dal master selezionato.  
4. Restituisce il nuovo [IMasterSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterslide/).

L'esempio seguente applica un tema esterno alle diapositive che dipendono dal primo master e salva la presentazione:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Un tema non valido, corrotto o non supportato può generare un [PptxException](https://reference.aspose.com/slides/it/python-net/aspose.slides/pptxexception/) o una delle sue sotto‑classi relative al formato. Convalida i percorsi forniti dagli utenti, gestisci gli errori di accesso al file system e salva la presentazione solo dopo che il tema è stato applicato con successo.

Solo le diapositive che dipendevano dal master selezionato vengono riassegnate. Le diapositive associate ad altri master conservano i master e i temi esistenti. I colori, i caratteri, i riempimenti, le linee, gli sfondi e gli effetti sensibili al tema vengono risolti rispetto al tema esterno. I colori, i caratteri, i riempimenti e altre formattazioni assegnate direttamente possono rimanere invariati. Le sovrascritture a livello di layout e diapositiva possono anche avere la precedenza sui valori ereditati dal nuovo master.

Il tema può fare riferimento a caratteri non disponibili nell'ambiente di runtime. Per una resa ed esportazione coerenti, installa i caratteri richiesti, forniscili tramite [custom font sources](/slides/it/python-net/custom-font/), o configura la [font substitution](/slides/it/python-net/font-substitution/).

Questo è un flusso di lavoro diretto a livello di master: il metodo accetta un percorso a un file `.thmx` e non richiede la creazione manuale di sovrascritture di tema a livello di layout o diapositiva.

### **Applicare temi esterni diversi in una presentazione multi‑master**

Quando il master rilevante non è noto in anticipo, ottienilo da una diapositiva rappresentativa tramite [Slide.layout_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/layout_slide/) e [LayoutSlide.master_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslide/master_slide/). Conserva i riferimenti ai master originali prima di applicare i temi perché ogni chiamata crea un nuovo master nella presentazione.

L'esempio seguente usa diapositive di due sezioni per localizzare i loro master e applica un tema esterno diverso a ciascun gruppo:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

La prima chiamata influisce solo sulle diapositive che dipendevano da `first_group_master`, e la seconda solo su quelle che dipendevano da `second_group_master`. Le diapositive appartenenti a qualsiasi altro master non vengono ridisegnate.

### **Conservare il tema di origine durante lo spostamento di diapositive**

Se desideri spostare una diapositiva in un'altra presentazione conservando il design originale, clona il master di origine nella presentazione di destinazione con [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslidecollection/add_clone/), quindi clona la diapositiva con [SlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) e il master clonato. In questo modo master, layout e tema associato vengono trasferiti insieme.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Questo è il flusso di lavoro consigliato quando la diapositiva di origine deve apparire identica nella destinazione. Clonare semplicemente il contenuto su un master di destinazione non correlato può modificare colori, caratteri, sfondi ed effetti determinati dal tema.

### **Applicare valori di tema a una diapositiva esistente**

Se la diapositiva di destinazione deve rimanere sul master e layout correnti, inizializza una sovrascrittura a livello di diapositiva dal tema di origine. I metodi [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) e [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) copiano i tre componenti principali del tema nella sovrascrittura.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Ciò modifica il tema usato da quella diapositiva senza alterare il tema ereditato dalle altre diapositive. Per rimuovere la sovrascrittura locale e tornare ai valori ereditati, chiama [OverrideTheme.clear](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/overridetheme/clear/).

### **Applicare una sovrascrittura di tema a un layout**

Una sovrascrittura a livello di layout si applica alle diapositive che usano quel layout, a meno che una diapositiva specifica non abbia la propria sovrascrittura. Gli stessi metodi di inizializzazione possono essere usati tramite il [LayoutSlideThemeManager](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/layoutslidethememanager/) del layout:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Usa un tema a livello di master o presentazione quando molti layout e diapositive devono condividere lo stesso design di base, una sovrascrittura di layout quando una famiglia di layout necessita di uno stile diverso, e una sovrascrittura di diapositiva solo per eccezioni reali. Troppe sovrascritture a livello di diapositiva rendono più difficili da prevedere i cambiamenti globali del tema.

## **Aggiornare gli stili di sfondo del tema**

Gli sfondi del tema sono memorizzati in [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint può presentare più scelte di sfondo nella sua interfaccia rispetto al numero di definizioni di riempimento effettivamente memorizzate in questa collezione, poiché l'interfaccia può combinare riempimenti del tema con colori del tema e altri riferimenti di stile.

![Galleria di stili di sfondo di PowerPoint per un tema di presentazione](presentation-design_8.png)

Prima di usare uno stile di sfondo, ispeziona la collezione memorizzata e l'attuale [Background.style_index](https://reference.aspose.com/slides/it/python-net/aspose.slides/background/style_index/). `style_index` usa `0` per nessun riempimento tematico; i valori positivi sono riferimenti a stili di sfondo tematici. Questo è diverso dall'indicizzare direttamente una collezione Python, dove `[0]` indica il primo elemento memorizzato. Non dare per scontato che ogni presentazione contenga lo stesso numero di stili di riempimento di sfondo.

L'esempio seguente riporta il conteggio dei riempimenti di sfondo disponibili, assegna un riferimento di sfondo tematico al primo master e salva la presentazione:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato visibile dipende dalla voce del tema a cui il master fa riferimento e da eventuali sovrascritture di sfondo a livello di layout o diapositiva. Se una diapositiva usa il proprio sfondo, cambiare solo lo sfondo del master potrebbe non modificare quella diapositiva. Usa [Background.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/background/get_effective/) quando è necessario conoscere lo sfondo finale dopo l'applicazione dell'ereditarietà.

{{% alert color="warning" title="Avviso" %}}
Non trattare `style_index` come un indice di collezione basato su zero. Evita inoltre di codificare in modo fisso un numero di stile da un file e presumere che abbia lo stesso aspetto in un altro file; le definizioni di stile del tema sono specifiche della presentazione.
{{% /alert %}}

{{% alert color="info" title="Suggerimento" %}}
Per la formattazione diretta dello sfondo e l'ereditarietà dello sfondo, vedere [Presentation Background](/slides/it/python-net/presentation-background/).
{{% /alert %}}

## **Aggiornare gli effetti del tema**

Uno schema di formato del tema contiene collezioni separate di [FormatScheme.fill_styles](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/formatscheme/line_styles/) e [FormatScheme.effect_styles](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/formatscheme/effect_styles/). I temi tipici di Office spesso contengono tre voci di stile principali che corrispondono visivamente a formattazioni sottile, moderata e intensa, ma il codice dovrebbe ispezionare ogni collezione invece di assumere un conteggio fisso.

![Effetti tematici sottili, moderati e intensi applicati alla stessa forma](presentation-design_10.png)

Quando accedi a queste collezioni in Python, l'indice della collezione è basato su zero: `[0]` è il primo stile memorizzato e `[2]` è il terzo. Gli indici di riferimento di stile di una forma sono un concetto separato, esposti tramite [IShapeStyle](https://reference.aspose.com/slides/it/python-net/aspose.slides/ishapestyle/). Modificare uno stile del tema influisce sulle forme che fanno riferimento a quello stile; le forme con formattazione diretta possono rimanere invariate.

L'esempio seguente verifica che le voci di stile richieste esistano, modifica il primo stile di linea, il terzo stile di riempimento, abilita un'ombra esterna nel terzo stile di effetto e salva il risultato:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Per le forme che fanno riferimento a questi slot, il primo stile di linea del tema diventa rosso, il terzo stile di riempimento del tema diventa verde foresta solido, e il terzo stile di effetto ottiene un'ombra esterna con distanza di 10 punti. Il risultato visivo esatto dipende comunque da quali slot di stile ogni forma riferisce e se la formattazione diretta sovrascrive il tema.

![Stili di effetto del tema dopo la modifica di linea, riempimento e ombra](presentation-design_11.png)

## **Leggere i valori effettivi del tema**

Gli oggetti tema grezzi indicano ciò che è definito a un determinato livello. I valori effettivi indicano ciò che una diapositiva o una forma utilizza realmente dopo che ereditarietà e sovrascritture locali sono state risolte. Per una diapositiva, chiama [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Per uno sfondo, usa [Background.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/background/get_effective/), e per un riempimento, usa [FillFormat.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/get_effective/).

L'esempio seguente legge il tema effettivo, lo sfondo e il primo riempimento della forma da una diapositiva:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Usa i dati effettivi per diagnostica di rendering, convalida e confronti. Se ispezioni solo [Presentation.master_theme](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/master_theme/), potresti perdere un master, layout, diapositiva o sovrascrittura di forma che modifica l'aspetto finale.

## **FAQ**

**L'applicazione di un tema esterno influisce su tutte le diapositive della presentazione?**

No. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) riassegna solo le diapositive che dipendono dal master selezionato. Le diapositive che usano altri master mantengono i loro temi esistenti.

**Posso applicare un tema a una singola diapositiva senza cambiare il master?**

Sì. Usa il [SlideThemeManager](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/slidethememanager/) della diapositiva e inizializza la sua sovrascrittura di tema. La modifica rimane locale a quella diapositiva; le altre diapositive continuano a ereditare i loro temi esistenti.

**Qual è il modo più sicuro per trasferire un tema da una presentazione all'altra?**

Quando si sposta una diapositiva conservando l'aspetto di origine, clona il master di origine nella destinazione e clona la diapositiva con quel master usando [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslidecollection/add_clone/) e [SlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/). Questo mantiene insieme master, layout e tema.

**Come posso vedere i valori effettivi dopo ereditarietà e sovrascritture?**

Usa [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) per un tema di diapositiva o layout e i metodi corrispondenti di dati effettivi per oggetti di formato come [Background.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/background/get_effective/) e [FillFormat.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/get_effective/). Queste API restituiscono i valori risolti dopo l'applicazione di ereditarietà e sovrascritture.